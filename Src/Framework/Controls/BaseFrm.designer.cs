using Wis.Anes.Framework.Properties;

namespace Wis.Anes.Framework.Controls
{
    partial class BaseFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseFrm));
            this.toolTipBase = new System.Windows.Forms.ToolTip();
            this.btnMax = new MedButtonEx();
            this.btnRestore = new MedButtonEx();
            this.btnClose = new MedButtonEx();
            this.btnMin = new MedButtonEx();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.picBottom = new System.Windows.Forms.PictureBox();
            this.picTop = new System.Windows.Forms.PictureBox();
            this.picRight = new System.Windows.Forms.PictureBox();
            this.picLeft = new System.Windows.Forms.PictureBox();
            this.vitalsignsTestWarming = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labVitalSignsWarning = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labTestWarning = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeft)).BeginInit();
            this.vitalsignsTestWarming.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMax
            // 
            this.btnMax.AllowFocus = false;
            this.btnMax.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnMax.Appearance.Options.UseForeColor = true;
            this.btnMax.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMax.Image = ((System.Drawing.Image)(resources.GetObject("btnMax.Image")));
            this.btnMax.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnMax.Location = new System.Drawing.Point(585, 4);
            this.btnMax.Name = "btnMax";
            this.btnMax.Size = new System.Drawing.Size(20, 21);
            this.btnMax.TabIndex = 23;
            this.btnMax.TabStop = false;
            this.toolTipBase.SetToolTip(this.btnMax, "最大化");
            this.btnMax.Visible = false;
            this.btnMax.Click += new System.EventHandler(this.btnMax_Click);
            this.btnMax.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMax_MouseDown);
            this.btnMax.MouseEnter += new System.EventHandler(this.btnMax_MouseEnter);
            this.btnMax.MouseLeave += new System.EventHandler(this.btnMax_MouseLeave);
            // 
            // btnRestore
            // 
            this.btnRestore.AllowFocus = false;
            this.btnRestore.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRestore.Appearance.Options.UseForeColor = true;
            this.btnRestore.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRestore.BackgroundImage")));
            this.btnRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestore.Image = ((System.Drawing.Image)(resources.GetObject("btnRestore.Image")));
            this.btnRestore.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnRestore.Location = new System.Drawing.Point(585, 4);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(20, 21);
            this.btnRestore.TabIndex = 24;
            this.btnRestore.TabStop = false;
            this.toolTipBase.SetToolTip(this.btnRestore, "还原");
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            this.btnRestore.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRestore_MouseDown);
            this.btnRestore.MouseEnter += new System.EventHandler(this.btnRestore_MouseEnter);
            this.btnRestore.MouseLeave += new System.EventHandler(this.btnRestore_MouseLeave);
            // 
            // btnClose
            // 
            this.btnClose.AllowFocus = false;
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnClose.Location = new System.Drawing.Point(618, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(20, 21);
            this.btnClose.TabIndex = 11;
            this.btnClose.TabStop = false;
            this.toolTipBase.SetToolTip(this.btnClose, "关闭");
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseDown);
            this.btnClose.MouseEnter += new System.EventHandler(this.btnClose_MouseEnter);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            // 
            // btnMin
            // 
            this.btnMin.AllowFocus = false;
            this.btnMin.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnMin.Appearance.Options.UseForeColor = true;
            this.btnMin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMin.BackgroundImage")));
            this.btnMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMin.Image = ((System.Drawing.Image)(resources.GetObject("btnMin.Image")));
            this.btnMin.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnMin.Location = new System.Drawing.Point(552, 4);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(20, 21);
            this.btnMin.TabIndex = 9;
            this.btnMin.TabStop = false;
            this.toolTipBase.SetToolTip(this.btnMin, "最小化");
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            this.btnMin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMin_MouseDown);
            this.btnMin.MouseEnter += new System.EventHandler(this.btnMin_MouseEnter);
            this.btnMin.MouseLeave += new System.EventHandler(this.btnMin_MouseLeave);
            // 
            // pnlTop
            // 
            this.pnlTop.BackgroundImage = Resources.top_bg;
            this.pnlTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.btnMax);
            this.pnlTop.Controls.Add(this.btnRestore);
            this.pnlTop.Controls.Add(this.btnClose);
            this.pnlTop.Controls.Add(this.btnMin);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(2, 2);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(648, 31);
            this.pnlTop.TabIndex = 1;
            this.pnlTop.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTop_Paint);
            this.pnlTop.DoubleClick += new System.EventHandler(this.pnlTop_DoubleClick);
            this.pnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);
            this.pnlTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseMove);
            this.pnlTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseUp);
            this.pnlTop.Resize += new System.EventHandler(this.pnlTop_Resize);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(-1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 50);
            this.label1.TabIndex = 24;
            // 
            // picBottom
            // 
            this.picBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.picBottom.Image = ((System.Drawing.Image)(resources.GetObject("picBottom.Image")));
            this.picBottom.Location = new System.Drawing.Point(2, 341);
            this.picBottom.Name = "picBottom";
            this.picBottom.Size = new System.Drawing.Size(648, 2);
            this.picBottom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBottom.TabIndex = 22;
            this.picBottom.TabStop = false;
            // 
            // picTop
            // 
            this.picTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.picTop.Image = ((System.Drawing.Image)(resources.GetObject("picTop.Image")));
            this.picTop.Location = new System.Drawing.Point(2, 0);
            this.picTop.Name = "picTop";
            this.picTop.Size = new System.Drawing.Size(648, 2);
            this.picTop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTop.TabIndex = 21;
            this.picTop.TabStop = false;
            // 
            // picRight
            // 
            this.picRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.picRight.Image = ((System.Drawing.Image)(resources.GetObject("picRight.Image")));
            this.picRight.Location = new System.Drawing.Point(650, 0);
            this.picRight.Name = "picRight";
            this.picRight.Size = new System.Drawing.Size(2, 343);
            this.picRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRight.TabIndex = 20;
            this.picRight.TabStop = false;
            // 
            // picLeft
            // 
            this.picLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.picLeft.Image = ((System.Drawing.Image)(resources.GetObject("picLeft.Image")));
            this.picLeft.Location = new System.Drawing.Point(0, 0);
            this.picLeft.Name = "picLeft";
            this.picLeft.Size = new System.Drawing.Size(2, 343);
            this.picLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLeft.TabIndex = 19;
            this.picLeft.TabStop = false;
            // 
            // vitalsignsTestWarming
            // 
            this.vitalsignsTestWarming.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.labVitalSignsWarning,
            this.toolStripStatusLabel2,
            this.labTestWarning,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.vitalsignsTestWarming.Location = new System.Drawing.Point(2, 316);
            this.vitalsignsTestWarming.Name = "vitalsignsTestWarming";
            this.vitalsignsTestWarming.Size = new System.Drawing.Size(648, 25);
            this.vitalsignsTestWarming.TabIndex = 24;
            this.vitalsignsTestWarming.Text = "statusStrip1";
            this.vitalsignsTestWarming.Visible = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(79, 20);
            this.toolStripStatusLabel1.Text = "预警内容：";
            // 
            // labVitalSignsWarning
            // 
            this.labVitalSignsWarning.BackColor = System.Drawing.Color.Transparent;
            this.labVitalSignsWarning.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.labVitalSignsWarning.IsLink = true;
            this.labVitalSignsWarning.Name = "labVitalSignsWarning";
            this.labVitalSignsWarning.Size = new System.Drawing.Size(131, 20);
            this.labVitalSignsWarning.Text = "生命体征  0  项预警";
            this.labVitalSignsWarning.Click += new System.EventHandler(this.tCheckList_Click);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(20, 20);
            this.toolStripStatusLabel2.Text = "   ";
            // 
            // labTestWarning
            // 
            this.labTestWarning.BackColor = System.Drawing.Color.Transparent;
            this.labTestWarning.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.labTestWarning.IsLink = true;
            this.labTestWarning.Name = "labTestWarning";
            this.labTestWarning.Size = new System.Drawing.Size(131, 20);
            this.labTestWarning.Text = "检验信息  0  项预警";
            this.labTestWarning.Click += new System.EventHandler(this.tCheckList_Click);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(0, 20);
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(20, 20);
            this.toolStripStatusLabel4.Text = "   ";
            // 
            // BaseFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(652, 343);
            this.Controls.Add(this.vitalsignsTestWarming);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.picBottom);
            this.Controls.Add(this.picTop);
            this.Controls.Add(this.picRight);
            this.Controls.Add(this.picLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BaseFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BaseFrm";
            this.Load += new System.EventHandler(this.BaseFrm_Load);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeft)).EndInit();
            this.vitalsignsTestWarming.ResumeLayout(false);
            this.vitalsignsTestWarming.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTipBase;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.PictureBox picBottom;
        private System.Windows.Forms.PictureBox picTop;
        private System.Windows.Forms.PictureBox picRight;
        private System.Windows.Forms.PictureBox picLeft;
        private MedButtonEx btnMin;
        private MedButtonEx btnClose;
        private MedButtonEx btnRestore;
        private MedButtonEx btnMax;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        protected System.Windows.Forms.ToolStripStatusLabel labVitalSignsWarning;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        protected System.Windows.Forms.ToolStripStatusLabel labTestWarning;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        public System.Windows.Forms.StatusStrip vitalsignsTestWarming;

    }
}