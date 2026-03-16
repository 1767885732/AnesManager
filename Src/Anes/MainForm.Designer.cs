namespace Wis.Anes
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticLoginUser = new DevExpress.XtraBars.BarButtonItem();
            this.BarStatusCopyright = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.hideContainerRight = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.lastMonitorData1 = new Wis.Anes.Views.LastMonitorData();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.leftBarControl1 = new Wis.Anes.Layouts.LeftBarControl();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemMarqueeProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar();
            this.ShinBarSubItem = new DevExpress.XtraBars.BarSubItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.repositoryItemMarqueeProgressBar2 = new DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.repositoryItemHyperLinkEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.workSpaceControl1 = new Wis.Anes.Layouts.WorkSpaceControl();
            this.topBarControl1 = new Wis.Anes.Layouts.TopBarControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.timerResponse = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.hideContainerRight.SuspendLayout();
            this.dockPanel2.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.AllowCustomization = false;
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.AllowShowToolbarsPopup = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockControls.Add(this.standaloneBarDockControl1);
            this.barManager1.DockManager = this.dockManager1;
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barStaticLoginUser,
            this.BarStatusCopyright,
            this.barEditItem1,
            this.ShinBarSubItem,
            this.barStaticItem1,
            this.barButtonItem1});
            this.barManager1.MaxItemId = 20;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMarqueeProgressBar1,
            this.repositoryItemMarqueeProgressBar2,
            this.repositoryItemHyperLinkEdit1,
            this.repositoryItemHyperLinkEdit2,
            this.repositoryItemTextEdit1});
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticLoginUser),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarStatusCopyright)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DisableClose = true;
            this.bar3.OptionsBar.DisableCustomization = true;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.MultiLine = true;
            this.bar3.OptionsBar.RotateWhenVertical = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barStaticLoginUser
            // 
            this.barStaticLoginUser.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.barStaticLoginUser.Caption = "当前用户：MDSD";
            this.barStaticLoginUser.Id = 3;
            this.barStaticLoginUser.Name = "barStaticLoginUser";
            // 
            // BarStatusCopyright
            // 
            this.BarStatusCopyright.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.BarStatusCopyright.Caption = "版权所有 © 2014 XXX医疗科技。保留所有权利。";
            this.BarStatusCopyright.Id = 5;
            this.BarStatusCopyright.Name = "BarStatusCopyright";
            this.BarStatusCopyright.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(855, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 559);
            this.barDockControlBottom.Size = new System.Drawing.Size(855, 26);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 559);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(855, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 559);
            // 
            // standaloneBarDockControl1
            // 
            this.standaloneBarDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.standaloneBarDockControl1.Location = new System.Drawing.Point(0, 0);
            this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
            this.standaloneBarDockControl1.Size = new System.Drawing.Size(855, 122);
            this.standaloneBarDockControl1.Text = "standaloneBarDockControl1";
            // 
            // dockManager1
            // 
            this.dockManager1.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
            this.hideContainerRight});
            this.dockManager1.AutoHideSpeed = 10;
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // hideContainerRight
            // 
            this.hideContainerRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.hideContainerRight.Controls.Add(this.dockPanel2);
            this.hideContainerRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.hideContainerRight.Location = new System.Drawing.Point(835, 122);
            this.hideContainerRight.Name = "hideContainerRight";
            this.hideContainerRight.Size = new System.Drawing.Size(20, 437);
            // 
            // dockPanel2
            // 
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
            this.dockPanel2.Size = new System.Drawing.Size(135, 475);
            this.dockPanel2.Text = "体征数据";
            this.dockPanel2.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.lastMonitorData1);
            this.dockPanel2_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(200, 100);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // lastMonitorData1
            // 
            this.lastMonitorData1.BackColor = System.Drawing.Color.Black;
            this.lastMonitorData1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lastMonitorData1.Location = new System.Drawing.Point(0, 0);
            this.lastMonitorData1.Name = "lastMonitorData1";
            this.lastMonitorData1.Size = new System.Drawing.Size(200, 100);
            this.lastMonitorData1.TabIndex = 0;
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("715fc8ec-3142-484f-ae91-031c08b0f346");
            this.dockPanel1.Location = new System.Drawing.Point(0, 122);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.AllowDockBottom = false;
            this.dockPanel1.Options.AllowDockFill = false;
            this.dockPanel1.Options.AllowDockRight = false;
            this.dockPanel1.Options.AllowDockTop = false;
            this.dockPanel1.Options.FloatOnDblClick = false;
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.Options.ShowMaximizeButton = false;
            this.dockPanel1.OriginalSize = new System.Drawing.Size(148, 200);
            this.dockPanel1.Size = new System.Drawing.Size(148, 437);
            this.dockPanel1.Text = "导航栏";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.leftBarControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 25);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(142, 409);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // leftBarControl1
            // 
            this.leftBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftBarControl1.Location = new System.Drawing.Point(0, 0);
            this.leftBarControl1.Name = "leftBarControl1";
            this.leftBarControl1.Size = new System.Drawing.Size(142, 409);
            this.leftBarControl1.TabIndex = 0;
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "barEditItem1";
            this.barEditItem1.Edit = this.repositoryItemMarqueeProgressBar1;
            this.barEditItem1.Id = 6;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemMarqueeProgressBar1
            // 
            this.repositoryItemMarqueeProgressBar1.Name = "repositoryItemMarqueeProgressBar1";
            // 
            // ShinBarSubItem
            // 
            this.ShinBarSubItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.ShinBarSubItem.Caption = "皮肤";
            this.ShinBarSubItem.Id = 16;
            this.ShinBarSubItem.Name = "ShinBarSubItem";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "barStaticItem1";
            this.barStaticItem1.Id = 17;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "22";
            this.barButtonItem1.Id = 18;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // repositoryItemMarqueeProgressBar2
            // 
            this.repositoryItemMarqueeProgressBar2.Name = "repositoryItemMarqueeProgressBar2";
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            // 
            // repositoryItemHyperLinkEdit2
            // 
            this.repositoryItemHyperLinkEdit2.AutoHeight = false;
            this.repositoryItemHyperLinkEdit2.Name = "repositoryItemHyperLinkEdit2";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // workSpaceControl1
            // 
            this.workSpaceControl1.BackColor = System.Drawing.Color.White;
            this.workSpaceControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workSpaceControl1.Location = new System.Drawing.Point(148, 122);
            this.workSpaceControl1.Name = "workSpaceControl1";
            this.workSpaceControl1.Size = new System.Drawing.Size(687, 437);
            this.workSpaceControl1.TabIndex = 26;
            // 
            // topBarControl1
            // 
            this.topBarControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.topBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topBarControl1.LightImage = null;
            this.topBarControl1.Location = new System.Drawing.Point(2, 2);
            this.topBarControl1.MainFormRef = null;
            this.topBarControl1.Name = "topBarControl1";
            this.topBarControl1.NormalImage = null;
            this.topBarControl1.PassedImage = null;
            this.topBarControl1.Size = new System.Drawing.Size(851, 116);
            this.topBarControl1.TabIndex = 34;
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.topBarControl1);
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(855, 120);
            this.panelControl1.TabIndex = 42;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "MySkin_Blue1";
            // 
            // timerResponse
            // 
            this.timerResponse.Interval = 60000;
            this.timerResponse.Tick += new System.EventHandler(this.timerResponse_Tick);
            // 
            // MainForm
            // 
            this.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 585);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.workSpaceControl1);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.hideContainerRight);
            this.Controls.Add(this.standaloneBarDockControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.hideContainerRight.ResumeLayout(false);
            this.dockPanel2.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private Wis.Anes.Layouts.WorkSpaceControl workSpaceControl1;
        private Wis.Anes.Layouts.LeftBarControl leftBarControl1;
        private Wis.Anes.Layouts.TopBarControl topBarControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private Wis.Anes.Views.LastMonitorData lastMonitorData1;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerRight;
        private DevExpress.XtraBars.BarButtonItem barStaticLoginUser;
        private DevExpress.XtraBars.BarButtonItem BarStatusCopyright;
        private DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar repositoryItemMarqueeProgressBar2;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar repositoryItemMarqueeProgressBar1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit2;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.BarSubItem ShinBarSubItem;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private System.Windows.Forms.Timer timerResponse;
    }
}

