using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using AVT.VmbAPINET;

//这里相机2的代码与相机1是重复的，主要是为了同时操作两个相机。多相机并且想让程序更简洁的话，可以创建类似CameraIndex的对象，重用大部分的界面和代码
namespace CameraViewer1
{
   
    public partial class Form1 : Form
    {
        private Vimba m_Vimba = null;
        private AVT_Cam Camera1, Camera2; 
        private CameraCollection cameras;               // A list of tracking handles of AVT::VmbAPINET::Camera objects

        double Cam1_ExpTime = 1500;
       // string Cam1_TriggerSource = "Freerun";

        double Cam2_ExpTime = 1500;
       // string Cam2_TriggerSource = "Freerun";

        Queue<Frame> Cam1_ImageQueue=new Queue<Frame>();
        object lockImagequeue = new object();

        private int m_Frames_Cam1 = 0;
        private int m_Frames_Cam2 = 0; 
        private double m_FPS_Cam1 = 0;
        private double m_FPS_Cam2 = 0;
        private static int sizeQueue = 60;
        private Queue<long> m_QueueCam1 = new Queue<long>(sizeQueue + 1);
        private Queue<long> m_QueueCam2 = new Queue<long>(sizeQueue + 1);

        private string GetCameraId(string pattern)
        {
            foreach (Camera camera in cameras)
            {
                if (camera.Name.Contains(pattern))
                {
                    return camera.Id;
                }
            }

            return "XXXXXXXXXXXXXXXXXXX";
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Init_Camera()
        {
           
            try
            {
                Camera1 = new AVT_Cam();
                //Camera1.m_Cam  = m_Vimba.GetCameraByID("192.168.4.66");//两种方式都可以
                Camera1.m_Cam  = m_Vimba.GetCameraByID(GetCameraId("Mako"));
                //Camera1.m_Cam = m_Vimba.GetCameraByID("DEV_000F31F4298E") ;           
                bT_OpenCamera.Enabled = true;                            
            }
            catch(Exception exception)
            {
                bT_OpenCamera.Enabled = false;
                System.Diagnostics.Trace.WriteLine("Could not start camera 0. Reason: " + exception.Message); 
            }

            try
            {
                Camera2 = new AVT_Cam();
                //Camera2.m_Cam = m_Vimba.GetCameraByID("192.168.0.12");
                Camera2.m_Cam  = m_Vimba.GetCameraByID(GetCameraId("Guppy"));
                //Camera2.m_Cam = m_Vimba.GetCameraByID("DEV_000F314D5B52");
                bT_OpenCamera2.Enabled = true;                             
            }
            catch(Exception exception)
            {
                bT_OpenCamera2.Enabled = false;
                System.Diagnostics.Trace.WriteLine("Could not start camera 1. Reason: " + exception.Message); 
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            try 
            {
                Vimba vimba = new Vimba();
                vimba.Startup();
                m_Vimba = vimba;
                cameras = m_Vimba.Cameras;              // Fetch all cameras known to Vimba

                Init_Camera();
                updateControls();
                updateControls2();               
            }
            catch(Exception exception)
            {
               // LogError("Could not startup Vimba API. Reason: " + exception.Message); 
               System.Diagnostics.Trace.WriteLine("Could not startup Vimba API. Reason: " + exception.Message); 
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (null == m_Vimba)
            {
                throw new Exception("Vimba has not been started.");
            }
            m_Vimba.Shutdown();
            m_Vimba = null;           
        }
            
        private void bT_OpenCamera_Click(object sender, EventArgs e)
        {
            if (!Camera1.IsOpen)
            {
                bool IsOpen= Camera1.OpenCamera();
                if (IsOpen)
                {                                               
                   Cam1_ExpTime = Camera1.ReadExposureTime();
                   trackBar1.Value = (int)Cam1_ExpTime;
                  // Camera1.Set_TriggerSource(1);                                                 
                }               
            }
            else
            {
                Camera1.CloseCamera();
            }
            updateControls();            
                
        }
        private void bT_OpenCamera2_Click(object sender, EventArgs e)
        {
            if (!Camera2.IsOpen)
            {
                
                bool IsOpen = Camera2.OpenCamera();
                if (IsOpen)
                {                                               
                    Cam2_ExpTime = Camera2.ReadExposureTime();
                    trackBar2.Value = (int)Cam2_ExpTime;
                   // Camera2.Set_TriggerSource(1);                   
                }               
            }
            else
            {
                Camera2.CloseCamera();
            }
            updateControls2();  

        }
        private void bT_Acqure_Click(object sender, EventArgs e)
        {
            if (!(Camera1.IsAcquring))
            {
                Camera1.StartAcquisition(mCam1_OnFrameReceived);//委托图像接收                              
               
            }
            else
            {
                Camera1.StopAcquisition();
                
            }
            updateControls();
        }
        private void bT_Acqure2_Click(object sender, EventArgs e)
        {
            if (!(Camera2.IsAcquring))
            {
                Camera2.StartAcquisition(mCam2_OnFrameReceived);//委托图像接收               
            }
            else
            {
                Camera2.StopAcquisition();
            }
            updateControls2();

        }
       
        private void mCam1_OnFrameReceived(Image image)
        {
            if (InvokeRequired == true)
            {
                BeginInvoke(new ImageReceivedHandler(this.mCam1_OnFrameReceived), image);
                return;
            }

            m_PictureBox.Image = image;
            m_Frames_Cam1++;
            labelFramesCam1.Text = m_Frames_Cam1.ToString();

            //在此处可以对图像处理，帧率比较快的话建议在此处另开线程          
            // FPS
            DateTime currentDate = DateTime.Now;
            long endTicks = currentDate.Ticks;
            m_QueueCam1.Enqueue(endTicks);
            while (m_QueueCam1.Count > sizeQueue)
            {
                m_QueueCam1.Dequeue();
            }

            if (m_QueueCam1.Count > 2)
            {
                long beginTicks = m_QueueCam1.Peek();
                long span = endTicks - beginTicks;

                // .Ticks 得到的值是自公历 0001-01-01 00:00:00:000 至此的以 100 ns（即 1/10000 ms）为单位的时间数。 
                double fps = (m_QueueCam1.Count - 1) * 10000 * 1000.0 / span;
                labelFPSCam1.Text = String.Format("{0:N3}", fps);
            }
            else
            {
                labelFPSCam1.Text = String.Format("{0:N3}", 0);
            } 
        }


        private void mCam2_OnFrameReceived(Image image)
        {
            if (InvokeRequired == true)
            {
                BeginInvoke(new ImageReceivedHandler(this.mCam2_OnFrameReceived), image);
                return;
            }
            pictureBox1.Image = image;
            m_Frames_Cam2++;
            labelFramesCam2.Text = m_Frames_Cam2.ToString();

            // FPS for camera 2
            DateTime currentDate = DateTime.Now;
            long endTicks = currentDate.Ticks;
            m_QueueCam2.Enqueue(endTicks);
            while (m_QueueCam2.Count > sizeQueue)
            {
                m_QueueCam2.Dequeue();
            }

            if (m_QueueCam2.Count > 2)
            {
                long beginTicks = m_QueueCam2.Peek();
                long span = endTicks - beginTicks;

                // .Ticks 得到的值是自公历 0001-01-01 00:00:00:000 至此的以 100 ns（即 1/10000 ms）为单位的时间数。 
                double fps = (m_QueueCam2.Count - 1) * 10000 * 1000.0 / span;
                labelFPSCam2.Text = String.Format("{0:N3}", fps);
            }
            else
            {
                labelFPSCam2.Text = String.Format("{0:N3}", 0);
            }
        }
       
        private void updateControls()
        {           
            if (Camera1.IsOpen)
            {
                bT_OpenCamera.Text = "关闭相机";
                p_SetCam1.Enabled = true;//任何关于相机的设置都要在相机打开的前提下，设置触发方式或者曝光时间则尽量要在相机停止采集的状态下
               
                if (Camera1.IsAcquring)
                {
                    bT_Acqure.Text = "停止采集/OffLine";

                }
                else
                {
                    bT_Acqure.Text = "开始采集/OnLine";
                }
            }
            else
            {             
                bT_OpenCamera.Text = "打开相机";
                p_SetCam1.Enabled = false;
            }
        }

        private void updateControls2()
        {
            if (Camera2.IsOpen)
            {
                bT_OpenCamera2.Text = "关闭相机";
                p_SetCam2.Enabled = true;//任何关于相机的设置都要在相机打开的前提下，设置触发方式或者曝光时间则尽量要在相机停止采集的状态下

                if (Camera2.IsAcquring)
                {
                    bT_Acqure2.Text = "停止采集/OffLine";
                }
                else
                {
                    bT_Acqure2.Text = "开始采集/OnLine";
                }
            }
            else
            {
                bT_OpenCamera2.Text = "打开相机";
                p_SetCam2.Enabled = false;
            }
        }


        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Cam1_ExpTime = trackBar1.Value;
            Camera1.Set_ExposureTime(Cam1_ExpTime);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            Cam2_ExpTime = trackBar2.Value;
            Camera2.Set_ExposureTime(Cam2_ExpTime);
        }

        
        private void panel_Left_Resize(object sender, EventArgs e)//窗口调整
        {
            int pW = panel_Left.Width;
            int pH = panel_Left.Height;
            int pX = panel_Left.Location.X;
            int pY = panel_Left.Location.Y;

            panel1.SetBounds(1,1,(int)( pW*0.49),pH-130);
            panel2.SetBounds(1 + (int)(pW * 0.5),1, (int)(pW * 0.49), pH - 130);
            panel3.SetBounds(1, 1 + (pH - 125), (int)(pW * 0.49), 120);
            panel4.SetBounds(1 + (int)(pW * 0.5), 1 + (pH - 125), (int)(pW * 0.49), 120);
        }

        private void m_PictureBox_Paint(object sender, PaintEventArgs e)
        {
           // Camera1.ImageInUse = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
           // Camera2.ImageInUse = true;
        }

        

       
             
    }
}
