namespace Wis.Anes
{
    partial class SplashForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.marqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbMsg = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Wis.Anes.Properties.Resources.tab_selected;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(722, 415);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // marqueeProgressBarControl1
            // 
            this.marqueeProgressBarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.marqueeProgressBarControl1.EditValue = "应用程序正在初始化....";
            this.marqueeProgressBarControl1.Location = new System.Drawing.Point(0, 0);
            this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
            this.marqueeProgressBarControl1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(177)))), ((int)(((byte)(253)))));
            this.marqueeProgressBarControl1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.marqueeProgressBarControl1.Properties.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(255)))), ((int)(((byte)(251)))));
            this.marqueeProgressBarControl1.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.marqueeProgressBarControl1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.marqueeProgressBarControl1.Properties.MarqueeAnimationSpeed = 15;
            this.marqueeProgressBarControl1.Properties.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(255)))), ((int)(((byte)(251)))));
            this.marqueeProgressBarControl1.Size = new System.Drawing.Size(279, 20);
            this.marqueeProgressBarControl1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.lbMsg);
            this.panel1.Controls.Add(this.marqueeProgressBarControl1);
            this.panel1.Location = new System.Drawing.Point(364, 261);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 46);
            this.panel1.TabIndex = 7;
            // 
            // lbMsg
            // 
            this.lbMsg.BackColor = System.Drawing.Color.Transparent;
            this.lbMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbMsg.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(206)))), ((int)(((byte)(255)))));
            this.lbMsg.Location = new System.Drawing.Point(0, 23);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(279, 23);
            this.lbMsg.TabIndex = 6;
            this.lbMsg.Text = "开始获取系统配置...";
            this.lbMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SplashForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(722, 415);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SpalishScreen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SplashForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBarControl1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lbMsg;
    }
}