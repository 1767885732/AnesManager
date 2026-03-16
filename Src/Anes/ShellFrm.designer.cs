using Wis.Anes.Controls;
using Wis.Anes.Framework.Controls;
using Wis.Anes.Properties;

namespace Wis.Anes
{
    partial class ShellFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShellFrm));
            this.toolTipBase = new System.Windows.Forms.ToolTip();
            this.btnMax = new Wis.Anes.Framework.Controls.MedButtonEx();
            this.btnRestore = new Wis.Anes.Framework.Controls.MedButtonEx();
            this.btnClose = new Wis.Anes.Framework.Controls.MedButtonEx();
            this.btnMin = new Wis.Anes.Framework.Controls.MedButtonEx();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.horizontalNavBar1 = new Wis.Anes.Framework.Controls.HorizontalNavBar();
            this.vitalsignsTestWarming = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labVitalSignsWarning = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labTestWarning = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.picBottom = new System.Windows.Forms.PictureBox();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.workSpaceControl1 = new Wis.Anes.Layouts.WorkSpaceControl();
            this.topBarControl1 = new Wis.Anes.Layouts.TopBarControlEx();
            this.picRight = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.hideContainerRight = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.lastMonitorData1 = new Wis.Anes.Views.LastMonitorData();
            this.picLeft = new System.Windows.Forms.PictureBox();
            this.leftBarControl1 = new Wis.Anes.Layouts.LeftBarControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager();
            this.tabPageContainer = new Wis.Anes.Framework.Controls.CommonTabControl();
            this.timerResponse = new System.Windows.Forms.Timer();
            this.pnlTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.vitalsignsTestWarming.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBottom)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRight)).BeginInit();
            this.picRight.SuspendLayout();
            this.panel3.SuspendLayout();
            this.hideContainerRight.SuspendLayout();
            this.dockPanel2.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
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
            this.btnMax.Location = new System.Drawing.Point(26, 4);
            this.btnMax.Margin = new System.Windows.Forms.Padding(4);
            this.btnMax.Name = "btnMax";
            this.btnMax.RoundStyle = Wis.Anes.Framework.Controls.RoundStyle.None;
            this.btnMax.Size = new System.Drawing.Size(20, 20);
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
            this.btnRestore.Location = new System.Drawing.Point(26, 4);
            this.btnRestore.Margin = new System.Windows.Forms.Padding(4);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.RoundStyle = Wis.Anes.Framework.Controls.RoundStyle.None;
            this.btnRestore.Size = new System.Drawing.Size(20, 20);
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
            this.btnClose.Location = new System.Drawing.Point(49, 4);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.RoundStyle = Wis.Anes.Framework.Controls.RoundStyle.None;
            this.btnClose.Size = new System.Drawing.Size(20, 20);
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
            this.btnMin.Location = new System.Drawing.Point(3, 4);
            this.btnMin.Margin = new System.Windows.Forms.Padding(4);
            this.btnMin.Name = "btnMin";
            this.btnMin.RoundStyle = Wis.Anes.Framework.Controls.RoundStyle.None;
            this.btnMin.Size = new System.Drawing.Size(20, 20);
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
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(111)))), ((int)(((byte)(237)))));
            this.pnlTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTop.ForeColor = System.Drawing.Color.White;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(374, 50);
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
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 34);
            this.label1.TabIndex = 24;
            this.label1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.flowLayoutPanel3);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.pnlTop);
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1157, 100);
            this.panel1.TabIndex = 23;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.flowLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(111)))), ((int)(((byte)(237)))));
            this.flowLayoutPanel3.Controls.Add(this.label3);
            this.flowLayoutPanel3.Controls.Add(this.label2);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.flowLayoutPanel3.Location = new System.Drawing.Point(935, 0);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(144, 50);
            this.flowLayoutPanel3.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 50);
            this.label3.TabIndex = 1;
            this.label3.Text = "您好:某某";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(1030, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(1030, 25, 6, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "userName";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(111)))), ((int)(((byte)(237)))));
            this.flowLayoutPanel1.Controls.Add(this.lblUserName);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(374, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(705, 50);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUserName.Location = new System.Drawing.Point(1030, 25);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(1030, 25, 6, 6);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(49, 20);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "userName";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUserName.Visible = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(111)))), ((int)(((byte)(237)))));
            this.panel4.Controls.Add(this.btnMax);
            this.panel4.Controls.Add(this.btnMin);
            this.panel4.Controls.Add(this.btnRestore);
            this.panel4.Controls.Add(this.btnClose);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1079, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(78, 50);
            this.panel4.TabIndex = 26;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutPanel2.Controls.Add(this.horizontalNavBar1);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 50);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1157, 50);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // horizontalNavBar1
            // 
            this.horizontalNavBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(90)))), ((int)(((byte)(237)))));
            this.horizontalNavBar1.Caption = null;
            this.horizontalNavBar1.Location = new System.Drawing.Point(4, 4);
            this.horizontalNavBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.horizontalNavBar1.Name = "horizontalNavBar1";
            this.horizontalNavBar1.Size = new System.Drawing.Size(1151, 50);
            this.horizontalNavBar1.TabIndex = 0;
            // 
            // vitalsignsTestWarming
            // 
            this.vitalsignsTestWarming.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.vitalsignsTestWarming.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.labVitalSignsWarning,
            this.toolStripStatusLabel2,
            this.labTestWarning,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.vitalsignsTestWarming.Location = new System.Drawing.Point(0, 651);
            this.vitalsignsTestWarming.Name = "vitalsignsTestWarming";
            this.vitalsignsTestWarming.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.vitalsignsTestWarming.Size = new System.Drawing.Size(1157, 29);
            this.vitalsignsTestWarming.TabIndex = 24;
            this.vitalsignsTestWarming.Text = "statusStrip1";
            this.vitalsignsTestWarming.Visible = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(95, 23);
            this.toolStripStatusLabel1.Text = "预警内容：";
            // 
            // labVitalSignsWarning
            // 
            this.labVitalSignsWarning.BackColor = System.Drawing.Color.Transparent;
            this.labVitalSignsWarning.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.labVitalSignsWarning.IsLink = true;
            this.labVitalSignsWarning.Name = "labVitalSignsWarning";
            this.labVitalSignsWarning.Size = new System.Drawing.Size(159, 23);
            this.labVitalSignsWarning.Text = "生命体征  0  项预警";
            this.labVitalSignsWarning.Click += new System.EventHandler(this.tCheckList_Click);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(21, 23);
            this.toolStripStatusLabel2.Text = "   ";
            // 
            // labTestWarning
            // 
            this.labTestWarning.BackColor = System.Drawing.Color.Transparent;
            this.labTestWarning.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.labTestWarning.IsLink = true;
            this.labTestWarning.Name = "labTestWarning";
            this.labTestWarning.Size = new System.Drawing.Size(159, 23);
            this.labTestWarning.Text = "检验信息  0  项预警";
            this.labTestWarning.Click += new System.EventHandler(this.tCheckList_Click);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(0, 23);
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(21, 23);
            this.toolStripStatusLabel4.Text = "   ";
            // 
            // picBottom
            // 
            this.picBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.picBottom.Location = new System.Drawing.Point(0, 831);
            this.picBottom.Margin = new System.Windows.Forms.Padding(4);
            this.picBottom.Name = "picBottom";
            this.picBottom.Size = new System.Drawing.Size(1157, 15);
            this.picBottom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBottom.TabIndex = 22;
            this.picBottom.TabStop = false;
            this.picBottom.Visible = false;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
            this.pnlContent.Controls.Add(this.workSpaceControl1);
            this.pnlContent.Controls.Add(this.topBarControl1);
            this.pnlContent.Controls.Add(this.picRight);
            this.pnlContent.Controls.Add(this.picLeft);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 100);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(4);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1446, 706);
            this.pnlContent.TabIndex = 25;
            // 
            // workSpaceControl1
            // 
            this.workSpaceControl1.BackColor = System.Drawing.Color.White;
            this.workSpaceControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workSpaceControl1.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.workSpaceControl1.Location = new System.Drawing.Point(15, 128);
            this.workSpaceControl1.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.workSpaceControl1.Name = "workSpaceControl1";
            this.workSpaceControl1.Size = new System.Drawing.Size(1416, 578);
            this.workSpaceControl1.TabIndex = 26;
            // 
            // topBarControl1
            // 
            this.topBarControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.topBarControl1.Appearance.Options.UseBackColor = true;
            this.topBarControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.topBarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBarControl1.LightImage = null;
            this.topBarControl1.Location = new System.Drawing.Point(15, 0);
            this.topBarControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.topBarControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.topBarControl1.MainFormRef = null;
            this.topBarControl1.Margin = new System.Windows.Forms.Padding(4);
            this.topBarControl1.Name = "topBarControl1";
            this.topBarControl1.NormalImage = null;
            this.topBarControl1.PassedImage = null;
            this.topBarControl1.Size = new System.Drawing.Size(1416, 128);
            this.topBarControl1.TabIndex = 24;
            // 
            // picRight
            // 
            this.picRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.picRight.Controls.Add(this.panel3);
            this.picRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.picRight.Location = new System.Drawing.Point(1431, 0);
            this.picRight.Margin = new System.Windows.Forms.Padding(4);
            this.picRight.Name = "picRight";
            this.picRight.Size = new System.Drawing.Size(15, 706);
            this.picRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRight.TabIndex = 21;
            this.picRight.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Blue;
            this.panel3.Controls.Add(this.hideContainerRight);
            this.panel3.Location = new System.Drawing.Point(0, 180);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(15, 65);
            this.panel3.TabIndex = 80;
            // 
            // hideContainerRight
            // 
            this.hideContainerRight.BackColor = System.Drawing.Color.Blue;
            this.hideContainerRight.Controls.Add(this.dockPanel2);
            this.hideContainerRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.hideContainerRight.Location = new System.Drawing.Point(-11, 0);
            this.hideContainerRight.Name = "hideContainerRight";
            this.hideContainerRight.Size = new System.Drawing.Size(26, 65);
            // 
            // dockPanel2
            // 
            this.dockPanel2.Appearance.BackColor = System.Drawing.Color.Blue;
            this.dockPanel2.Appearance.Options.UseBackColor = true;
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel2.ID = new System.Guid("9c59b230-3f15-4398-9bd5-61ecc8749664");
            this.dockPanel2.Location = new System.Drawing.Point(0, 0);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.Options.AllowDockBottom = false;
            this.dockPanel2.Options.AllowDockFill = false;
            this.dockPanel2.Options.AllowDockLeft = false;
            this.dockPanel2.Options.AllowDockTop = false;
            this.dockPanel2.Options.AllowFloating = false;
            this.dockPanel2.Options.FloatOnDblClick = false;
            this.dockPanel2.Options.ShowCloseButton = false;
            this.dockPanel2.Options.ShowMaximizeButton = false;
            this.dockPanel2.OriginalSize = new System.Drawing.Size(157, 200);
            this.dockPanel2.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel2.SavedIndex = 1;
            this.dockPanel2.Size = new System.Drawing.Size(157, 680);
            this.dockPanel2.Text = "体征数据";
            this.dockPanel2.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.lastMonitorData1);
            this.dockPanel2_Container.Location = new System.Drawing.Point(5, 28);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(147, 647);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // lastMonitorData1
            // 
            this.lastMonitorData1.BackColor = System.Drawing.Color.Black;
            this.lastMonitorData1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lastMonitorData1.Location = new System.Drawing.Point(0, 0);
            this.lastMonitorData1.Name = "lastMonitorData1";
            this.lastMonitorData1.Size = new System.Drawing.Size(147, 647);
            this.lastMonitorData1.TabIndex = 0;
            // 
            // picLeft
            // 
            this.picLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.picLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.picLeft.Location = new System.Drawing.Point(0, 0);
            this.picLeft.Margin = new System.Windows.Forms.Padding(4);
            this.picLeft.Name = "picLeft";
            this.picLeft.Size = new System.Drawing.Size(15, 706);
            this.picLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLeft.TabIndex = 22;
            this.picLeft.TabStop = false;
            // 
            // leftBarControl1
            // 
            this.leftBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftBarControl1.Location = new System.Drawing.Point(0, 0);
            this.leftBarControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.leftBarControl1.Name = "leftBarControl1";
            this.leftBarControl1.Size = new System.Drawing.Size(142, 409);
            this.leftBarControl1.TabIndex = 0;
            this.leftBarControl1.Visible = false;
            // 
            // dockManager1
            // 
            this.dockManager1.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
            this.hideContainerRight});
            this.dockManager1.AutoHideSpeed = 10;
            this.dockManager1.Form = this;
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // tabPageContainer
            // 
            this.tabPageContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPageContainer.CloseIcon = ((System.Drawing.Image)(resources.GetObject("tabPageContainer.CloseIcon")));
            this.tabPageContainer.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabPageContainer.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tabPageContainer.ItemSize = new System.Drawing.Size(120, 40);
            this.tabPageContainer.Location = new System.Drawing.Point(27, 208);
            this.tabPageContainer.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.tabPageContainer.Name = "tabPageContainer";
            this.tabPageContainer.SelectedIndex = 0;
            this.tabPageContainer.Size = new System.Drawing.Size(1103, 390);
            this.tabPageContainer.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabPageContainer.TabIndex = 26;
            this.tabPageContainer.Visible = false;
            // 
            // timerResponse
            // 
            this.timerResponse.Interval = 60000;
            this.timerResponse.Tick += new System.EventHandler(this.timerResponse_Tick);
            // 
            // ShellFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1157, 680);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.picBottom);
            this.Controls.Add(this.vitalsignsTestWarming);
            this.Font = new System.Drawing.Font("宋体", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ShellFrm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "手术麻醉临床信息系统";
            this.Load += new System.EventHandler(this.ShellFrm_Load);
            this.pnlTop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.vitalsignsTestWarming.ResumeLayout(false);
            this.vitalsignsTestWarming.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBottom)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picRight)).EndInit();
            this.picRight.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.hideContainerRight.ResumeLayout(false);
            this.dockPanel2.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTipBase;
        private System.Windows.Forms.Panel pnlTop;
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
        private System.Windows.Forms.PictureBox picBottom;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.PictureBox picLeft;
        private System.Windows.Forms.PictureBox picRight;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        //internal Controls.BedHeadInformation bedHeadInformation1;
        //private DevExpress.XtraTab.XtraTabControl tabPageContainer;
        private CommonTabControl tabPageContainer;
        private HorizontalNavBar horizontalNavBar1;

        private Wis.Anes.Layouts.WorkSpaceControl workSpaceControl1;
        private System.Windows.Forms.Timer timerResponse;
        private System.Windows.Forms.Label lblUserName;
        private Wis.Anes.Layouts.TopBarControlEx topBarControl1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerRight;
        private Wis.Anes.Views.LastMonitorData lastMonitorData1;
        private System.Windows.Forms.Panel panel3;
        private Wis.Anes.Layouts.LeftBarControl leftBarControl1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}