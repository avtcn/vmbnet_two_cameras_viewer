using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using AVT.VmbAPINET;
namespace CameraViewer1
{
    public delegate void ImageReceivedHandler(Image img);

    public class AVT_Cam
    {

        //
        private const int m_RingBitmapSize = 2;
        private readonly object m_ImageInUseSyncLock = new object();
        private RingBitmap m_RingBitmap = null;
        private bool m_ImageInUse = true;
        //

        private ImageReceivedHandler ImageHandler = null;
        public bool IsOpen { get; set; }
        public bool IsAcquring { get; set; }
        public Camera m_Cam { get; set; }

        public AVT_Cam()
        {
            IsOpen = false;
            IsAcquring = false;
            m_Cam = null;
            m_RingBitmap = new RingBitmap(m_RingBitmapSize);
        }

        public bool ImageInUse
        {
            get
            {
                lock (m_ImageInUseSyncLock)
                {
                    return m_ImageInUse;
                }
            }

            set
            {
                lock (m_ImageInUseSyncLock)
                {
                    m_ImageInUse = value;
                }
            }
        }

        public bool OpenCamera()
        {
            try
            {
                this.m_Cam.Open(VmbAccessModeType.VmbAccessModeFull);
                if (m_Cam.InterfaceType == VmbInterfaceType.VmbInterfaceEthernet)
                {
                    m_Cam.Features["GVSPAdjustPacketSize"].RunCommand();//自动调整数据包大小
                    while (false == m_Cam.Features["GVSPAdjustPacketSize"].IsCommandDone())
                    {
                        // Do Nothing
                    }
                }
                AdjustPixelFormat(m_Cam);
                IsOpen = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void CloseCamera()
        {
            try
            {
                if (IsAcquring)//实际上直接关闭相机也可以
                {
                    StopAcquisition();
                }
                m_Cam.Close();
                IsOpen = false;
            }
            catch
            {
            }
        }

        public void SendSoftwareTrigger()
        {
            if (null == this.m_Cam)
            {
                throw new NullReferenceException("No camera retrieved.");
            }
            this.m_Cam.Features["TriggerSoftware"].RunCommand();
            while (false == m_Cam.Features["TriggerSoftware"].IsCommandDone())
            {
                // Do nothing
            }

        }

        public void Set_TriggerSource(int Tri_index)
        {
            if (null == this.m_Cam)
            {
                throw new NullReferenceException("No camera retrieved.");
            }
            switch (Tri_index)
            {
                case 1:
                    this.m_Cam.Features["TriggerSource"].EnumValue = "Freerun";
                    break;
                case 2:
                    this.m_Cam.Features["TriggerSource"].EnumValue = "Line1";
                    break;
                case 3:
                    this.m_Cam.Features["TriggerSource"].EnumValue = "Software";
                    break;
            }
            // And switch it on or off
            this.m_Cam.Features["TriggerMode"].EnumValue = "On";

        }

        public string ReadTriggerSource()
        {
            if (null == this.m_Cam)
            {
                throw new NullReferenceException("No camera retrieved.");
            }
            if (null != this.m_Cam)
            {
                return m_Cam.Features["TriggerSource"].EnumValue;
            }
            else
            {
                return "Freerun";
            }
        }

        public double ReadExposureTime()
        {
            if (null == this.m_Cam)
            {
                throw new NullReferenceException("No camera retrieved.");
            }
            if (m_Cam.Features.ContainsName("ExposureTime"))//目前千兆网相机中Goldeye的属性名称略有不同
            {
                return m_Cam.Features["ExposureTime"].FloatValue;
            }
            else
            {
                return m_Cam.Features["ExposureTimeAbs"].FloatValue;
            }

        }

        public void Set_ExposureTime(double time)
        {
            if (null == this.m_Cam)
            {
                throw new NullReferenceException("No camera retrieved.");
            }
            if (m_Cam.Features.ContainsName("ExposureTime"))//目前千兆网相机中Goldeye的属性名称略有不同
            {
                m_Cam.Features["ExposureTime"].FloatValue = time;
            }
            else
            {
                m_Cam.Features["ExposureTimeAbs"].FloatValue = time;
            }

        }

        private void m_CamOnFrameReceived(Frame frame)
        {
            if (VmbFrameStatusType.VmbFrameStatusComplete == frame.ReceiveStatus)
            {
                Image img = null;
                //img = ConvertFrame1(frame); // inuse cause frame speed delay
                img = ConvertFrame(frame);

                if (null != ImageHandler && null != img)
                {
                    ImageHandler(img);
                }
            }
            try
            {
                m_Cam.QueueFrame(frame);
            }
            catch
            {
                // Do nothing
                //System.Diagnostics.Debug.WriteLine("camera " + index + ":  name is " + m_Camera.Name + ", model is " + m_Camera.Model);
            }
        }

        public void StartAcquisition(ImageReceivedHandler ImageReceived)
        {
            if (null == this.m_Cam)
            {
                throw new NullReferenceException("No camera retrieved.");
            }

            m_RingBitmap = new RingBitmap(m_RingBitmapSize);
            m_ImageInUse = true;

            ImageHandler = ImageReceived;
            try
            {
                m_Cam.OnFrameReceived += new Camera.OnFrameReceivedHandler(m_CamOnFrameReceived);//注册图像接收事件
                m_Cam.StartContinuousImageAcquisition(9);
                //m_Cam.Features["AcquisitionStart"].RunCommand();//作用和上一句相同，但是标准写法是这一句
                IsAcquring = true;
            }
            catch { }
        }

        public void StopAcquisition()
        {
            if (null == this.m_Cam)
            {
                throw new NullReferenceException("No camera retrieved.");
            }
            try
            {
                m_Cam.OnFrameReceived -= m_CamOnFrameReceived;
                m_Cam.StopContinuousImageAcquisition();
                IsAcquring = false;
                //m_Cam.Features["AcquisitionStop"].RunCommand();//作用和上一句相同，但是标准写法是这一句
            }
            catch { }
        }

        public Image AcquireSingleImage()
        {
            // Open camera          
            if (null == this.m_Cam)
            {
                throw new NullReferenceException("No camera retrieved.");
            }
            Frame frame = null;
            try
            {
                this.m_Cam.AcquireSingleImage(ref frame, 2000);
                return ConvertFrame(frame);
            }
            catch
            {
                return null;
            }
        }
        private Image ConvertFrame1(Frame frame)
        {
            if (null == frame)
            {
                throw new ArgumentNullException("frame");
            }

            // Check if the image is valid
            if (VmbFrameStatusType.VmbFrameStatusComplete != frame.ReceiveStatus)
            {
                throw new Exception("Invalid frame received. Reason: " + frame.ReceiveStatus.ToString());
            }

            // define return variable
            Image image = null;

            // check if current image is in use,
            // if not we drop the frame to get not in conflict with GUI
            if (ImageInUse)
            {
                // Convert raw frame data into image (for image display)
                m_RingBitmap.FillNextBitmap(frame);

                image = m_RingBitmap.Image;
                ImageInUse = false;
            }

            return image;
        }
        private Image ConvertFrame(Frame frame)
        {
            if (null == frame)
            {
                throw new ArgumentNullException("frame");
            }
            //Check if the image is valid
            if (VmbFrameStatusType.VmbFrameStatusComplete != frame.ReceiveStatus)
            {
                throw new Exception("Invalid frame received. Reason: " + frame.ReceiveStatus.ToString());
            }
            // m_Cam.QueueFrame(frame);

            //Convert raw frame data into image (for image display)
            Image image = null;
            switch (frame.PixelFormat)
            {
                case VmbPixelFormatType.VmbPixelFormatMono8:
                    {
                        Bitmap bitmap = new Bitmap((int)frame.Width, (int)frame.Height, PixelFormat.Format8bppIndexed);

                        //Set greyscale palette
                        ColorPalette palette = bitmap.Palette;
                        for (int i = 0; i < palette.Entries.Length; i++)
                        {
                            palette.Entries[i] = Color.FromArgb(i, i, i);
                        }
                        bitmap.Palette = palette;

                        //Copy image data
                        BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, (int)frame.Width, (int)frame.Height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
                        try
                        {
                            //Copy image data line by line
                            for (int y = 0; y < (int)frame.Height; y++)
                            {
                                System.Runtime.InteropServices.Marshal.Copy(frame.Buffer, y * (int)frame.Width, new IntPtr(bitmapData.Scan0.ToInt64() + y * bitmapData.Stride), (int)frame.Width);
                            }
                        }
                        finally
                        {
                            bitmap.UnlockBits(bitmapData);
                        }

                        image = bitmap;
                    }
                    break;

                case VmbPixelFormatType.VmbPixelFormatBgr8:
                    {
                        Bitmap bitmap = new Bitmap((int)frame.Width, (int)frame.Height, PixelFormat.Format24bppRgb);

                        //Copy image data
                        BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, (int)frame.Width, (int)frame.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                        try
                        {
                            //Copy image data line by line
                            for (int y = 0; y < (int)frame.Height; y++)
                            {
                                System.Runtime.InteropServices.Marshal.Copy(frame.Buffer,
                                                                                y * ((int)frame.Width) * 3,
                                                                                new IntPtr(bitmapData.Scan0.ToInt64() + y * bitmapData.Stride),
                                                                                ((int)(frame.Width) * 3));
                            }
                        }
                        finally
                        {
                            bitmap.UnlockBits(bitmapData);
                        }

                        image = bitmap;
                    }
                    break;

                default:
                    throw new Exception("Current pixel format is not supported by this example (only Mono8 and BRG8Packed are supported).");
            }

            return image;
        }

        private void AdjustPixelFormat(Camera camera)
        {
            if (null == camera)
            {
                throw new ArgumentNullException("camera");
            }

            string[] supportedPixelFormats = new string[] { "BGR8Packed", "Mono8" };
            //Check for compatible pixel format
            Feature pixelFormatFeature = camera.Features["PixelFormat"];

            //Determine current pixel format
            string currentPixelFormat = pixelFormatFeature.EnumValue;

            //Check if current pixel format is supported
            bool currentPixelFormatSupported = false;
            foreach (string supportedPixelFormat in supportedPixelFormats)
            {
                if (string.Compare(currentPixelFormat, supportedPixelFormat, StringComparison.Ordinal) == 0)
                {
                    currentPixelFormatSupported = true;
                    break;
                }
            }

            //Only adjust pixel format if we not already have a compatible one.
            if (false == currentPixelFormatSupported)
            {
                //Determine available pixel formats
                string[] availablePixelFormats = pixelFormatFeature.EnumValues;

                //Check if there is a supported pixel format
                bool pixelFormatSet = false;
                foreach (string supportedPixelFormat in supportedPixelFormats)
                {
                    foreach (string availablePixelFormat in availablePixelFormats)
                    {
                        if ((string.Compare(supportedPixelFormat, availablePixelFormat, StringComparison.Ordinal) == 0)
                            && (pixelFormatFeature.IsEnumValueAvailable(supportedPixelFormat) == true))
                        {
                            //Set the found pixel format
                            pixelFormatFeature.EnumValue = supportedPixelFormat;
                            pixelFormatSet = true;
                            break;
                        }
                    }

                    if (true == pixelFormatSet)
                    {
                        break;
                    }
                }

                if (false == pixelFormatSet)
                {
                    throw new Exception("None of the pixel formats that are supported by this example (Mono8 and BRG8Packed) can be set in the camera.");
                }
            }
        }
    }
}
