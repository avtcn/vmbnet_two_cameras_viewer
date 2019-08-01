namespace CameraViewer1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel_Left = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelFPSCam1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelFramesCam1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.p_SetCam1 = new System.Windows.Forms.Panel();
            this.labelExposure1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.bT_Acqure = new System.Windows.Forms.Button();
            this.bT_OpenCamera = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelFPSCam2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelFramesCam2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.p_SetCam2 = new System.Windows.Forms.Panel();
            this.labelExposure2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.bT_Acqure2 = new System.Windows.Forms.Button();
            this.bT_OpenCamera2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.m_PictureBox = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel_Left.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.p_SetCam1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.p_SetCam2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Left
            // 
            this.panel_Left.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Left.Controls.Add(this.panel3);
            this.panel_Left.Controls.Add(this.panel4);
            this.panel_Left.Controls.Add(this.panel2);
            this.panel_Left.Controls.Add(this.panel1);
            this.panel_Left.Location = new System.Drawing.Point(1, 77);
            this.panel_Left.Margin = new System.Windows.Forms.Padding(2);
            this.panel_Left.Name = "panel_Left";
            this.panel_Left.Size = new System.Drawing.Size(1172, 586);
            this.panel_Left.TabIndex = 9;
            this.panel_Left.Resize += new System.EventHandler(this.panel_Left_Resize);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Location = new System.Drawing.Point(4, 453);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(585, 130);
            this.panel3.TabIndex = 30;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.labelFPSCam1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.labelFramesCam1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.p_SetCam1);
            this.groupBox1.Controls.Add(this.bT_OpenCamera);
            this.groupBox1.Location = new System.Drawing.Point(26, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(547, 123);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "相机1";
            // 
            // labelFPSCam1
            // 
            this.labelFPSCam1.AutoSize = true;
            this.labelFPSCam1.Font = new System.Drawing.Font("Consolas", 32F);
            this.labelFPSCam1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelFPSCam1.Location = new System.Drawing.Point(415, 46);
            this.labelFPSCam1.Name = "labelFPSCam1";
            this.labelFPSCam1.Size = new System.Drawing.Size(166, 51);
            this.labelFPSCam1.TabIndex = 28;
            this.labelFPSCam1.Text = "66.666";
            this.labelFPSCam1.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(417, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 26);
            this.label6.TabIndex = 27;
            this.label6.Text = "帧率";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // labelFramesCam1
            // 
            this.labelFramesCam1.AutoSize = true;
            this.labelFramesCam1.Font = new System.Drawing.Font("Consolas", 32F);
            this.labelFramesCam1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelFramesCam1.Location = new System.Drawing.Point(202, 46);
            this.labelFramesCam1.Name = "labelFramesCam1";
            this.labelFramesCam1.Size = new System.Drawing.Size(190, 51);
            this.labelFramesCam1.TabIndex = 26;
            this.labelFramesCam1.Text = "0123456";
            this.labelFramesCam1.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(204, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 26);
            this.label3.TabIndex = 25;
            this.label3.Text = "帧计数";
            // 
            // p_SetCam1
            // 
            this.p_SetCam1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.p_SetCam1.Controls.Add(this.labelExposure1);
            this.p_SetCam1.Controls.Add(this.label1);
            this.p_SetCam1.Controls.Add(this.trackBar1);
            this.p_SetCam1.Controls.Add(this.bT_Acqure);
            this.p_SetCam1.Location = new System.Drawing.Point(6, 46);
            this.p_SetCam1.Name = "p_SetCam1";
            this.p_SetCam1.Size = new System.Drawing.Size(190, 73);
            this.p_SetCam1.TabIndex = 24;
            // 
            // labelExposure1
            // 
            this.labelExposure1.AutoSize = true;
            this.labelExposure1.Location = new System.Drawing.Point(70, 55);
            this.labelExposure1.Name = "labelExposure1";
            this.labelExposure1.Size = new System.Drawing.Size(53, 12);
            this.labelExposure1.TabIndex = 26;
            this.labelExposure1.Text = "15.000ms";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "曝光时间";
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 10000;
            this.trackBar1.Location = new System.Drawing.Point(61, 28);
            this.trackBar1.Maximum = 800000;
            this.trackBar1.Minimum = 71;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(118, 45);
            this.trackBar1.SmallChange = 1000;
            this.trackBar1.TabIndex = 25;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Value = 100;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // bT_Acqure
            // 
            this.bT_Acqure.Location = new System.Drawing.Point(0, 0);
            this.bT_Acqure.Name = "bT_Acqure";
            this.bT_Acqure.Size = new System.Drawing.Size(119, 21);
            this.bT_Acqure.TabIndex = 22;
            this.bT_Acqure.Text = "开始采集/OnLine";
            this.bT_Acqure.UseVisualStyleBackColor = true;
            this.bT_Acqure.Click += new System.EventHandler(this.bT_Acqure_Click);
            // 
            // bT_OpenCamera
            // 
            this.bT_OpenCamera.Location = new System.Drawing.Point(6, 20);
            this.bT_OpenCamera.Name = "bT_OpenCamera";
            this.bT_OpenCamera.Size = new System.Drawing.Size(75, 21);
            this.bT_OpenCamera.TabIndex = 20;
            this.bT_OpenCamera.Text = "打开相机";
            this.bT_OpenCamera.UseVisualStyleBackColor = true;
            this.bT_OpenCamera.Click += new System.EventHandler(this.bT_OpenCamera_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Location = new System.Drawing.Point(595, 453);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(565, 130);
            this.panel4.TabIndex = 29;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.labelFPSCam2);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.labelFramesCam2);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.p_SetCam2);
            this.groupBox2.Controls.Add(this.bT_OpenCamera2);
            this.groupBox2.Location = new System.Drawing.Point(12, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(537, 123);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "相机2";
            // 
            // labelFPSCam2
            // 
            this.labelFPSCam2.AutoSize = true;
            this.labelFPSCam2.Font = new System.Drawing.Font("Consolas", 32F);
            this.labelFPSCam2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelFPSCam2.Location = new System.Drawing.Point(405, 46);
            this.labelFPSCam2.Name = "labelFPSCam2";
            this.labelFPSCam2.Size = new System.Drawing.Size(166, 51);
            this.labelFPSCam2.TabIndex = 32;
            this.labelFPSCam2.Text = "66.666";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(407, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 26);
            this.label8.TabIndex = 31;
            this.label8.Text = "帧率";
            // 
            // labelFramesCam2
            // 
            this.labelFramesCam2.AutoSize = true;
            this.labelFramesCam2.Font = new System.Drawing.Font("Consolas", 32F);
            this.labelFramesCam2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelFramesCam2.Location = new System.Drawing.Point(202, 46);
            this.labelFramesCam2.Name = "labelFramesCam2";
            this.labelFramesCam2.Size = new System.Drawing.Size(190, 51);
            this.labelFramesCam2.TabIndex = 30;
            this.labelFramesCam2.Text = "0123456";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(204, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 26);
            this.label10.TabIndex = 29;
            this.label10.Text = "帧计数";
            // 
            // p_SetCam2
            // 
            this.p_SetCam2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.p_SetCam2.Controls.Add(this.labelExposure2);
            this.p_SetCam2.Controls.Add(this.label2);
            this.p_SetCam2.Controls.Add(this.trackBar2);
            this.p_SetCam2.Controls.Add(this.bT_Acqure2);
            this.p_SetCam2.Location = new System.Drawing.Point(6, 46);
            this.p_SetCam2.Name = "p_SetCam2";
            this.p_SetCam2.Size = new System.Drawing.Size(190, 73);
            this.p_SetCam2.TabIndex = 24;
            // 
            // labelExposure2
            // 
            this.labelExposure2.AutoSize = true;
            this.labelExposure2.Location = new System.Drawing.Point(71, 55);
            this.labelExposure2.Name = "labelExposure2";
            this.labelExposure2.Size = new System.Drawing.Size(29, 12);
            this.labelExposure2.TabIndex = 26;
            this.labelExposure2.Text = "15ms";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 25;
            this.label2.Text = "曝光时间";
            // 
            // trackBar2
            // 
            this.trackBar2.LargeChange = 10000;
            this.trackBar2.Location = new System.Drawing.Point(62, 26);
            this.trackBar2.Maximum = 800000;
            this.trackBar2.Minimum = 71;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(118, 45);
            this.trackBar2.SmallChange = 1000;
            this.trackBar2.TabIndex = 25;
            this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar2.Value = 100;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // bT_Acqure2
            // 
            this.bT_Acqure2.Location = new System.Drawing.Point(0, 0);
            this.bT_Acqure2.Name = "bT_Acqure2";
            this.bT_Acqure2.Size = new System.Drawing.Size(119, 21);
            this.bT_Acqure2.TabIndex = 22;
            this.bT_Acqure2.Text = "开始采集/OnLine";
            this.bT_Acqure2.UseVisualStyleBackColor = true;
            this.bT_Acqure2.Click += new System.EventHandler(this.bT_Acqure2_Click);
            // 
            // bT_OpenCamera2
            // 
            this.bT_OpenCamera2.Location = new System.Drawing.Point(6, 19);
            this.bT_OpenCamera2.Name = "bT_OpenCamera2";
            this.bT_OpenCamera2.Size = new System.Drawing.Size(75, 21);
            this.bT_OpenCamera2.TabIndex = 20;
            this.bT_OpenCamera2.Text = "打开相机";
            this.bT_OpenCamera2.UseVisualStyleBackColor = true;
            this.bT_OpenCamera2.Click += new System.EventHandler(this.bT_OpenCamera2_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox4);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(595, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(565, 419);
            this.panel2.TabIndex = 28;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.Image = global::CameraViewer1.Properties.Resources.makoU503b;
            this.pictureBox4.Location = new System.Drawing.Point(12, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(531, 63);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 5;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(12, 68);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(531, 344);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.m_PictureBox);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(586, 419);
            this.panel1.TabIndex = 27;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = global::CameraViewer1.Properties.Resources.av1800u500c;
            this.pictureBox3.Location = new System.Drawing.Point(27, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(547, 63);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // m_PictureBox
            // 
            this.m_PictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_PictureBox.BackColor = System.Drawing.Color.White;
            this.m_PictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_PictureBox.BackgroundImage")));
            this.m_PictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.m_PictureBox.Location = new System.Drawing.Point(27, 68);
            this.m_PictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.m_PictureBox.Name = "m_PictureBox";
            this.m_PictureBox.Size = new System.Drawing.Size(547, 344);
            this.m_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.m_PictureBox.TabIndex = 3;
            this.m_PictureBox.TabStop = false;
            this.m_PictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.m_PictureBox_Paint);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.Crimson;
            this.pictureBox2.Image = global::CameraViewer1.Properties.Resources.av1800usb_top;
            this.pictureBox2.Location = new System.Drawing.Point(4, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1166, 72);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 664);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel_Left);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "VimbaSDK_DemoCode";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel_Left.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.p_SetCam1.ResumeLayout(false);
            this.p_SetCam1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.p_SetCam2.ResumeLayout(false);
            this.p_SetCam2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox m_PictureBox;
        private System.Windows.Forms.Panel panel_Left;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button bT_OpenCamera;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel p_SetCam2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Button bT_Acqure2;
        private System.Windows.Forms.Button bT_OpenCamera2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label labelFramesCam1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelFPSCam1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelFPSCam2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelFramesCam2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel p_SetCam1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button bT_Acqure;
        private System.Windows.Forms.Label labelExposure1;
        private System.Windows.Forms.Label labelExposure2;
    }
}

