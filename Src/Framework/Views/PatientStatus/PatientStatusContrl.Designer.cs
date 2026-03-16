namespace Wis.Anes.Framework.Views
{
    partial class PatientStatusContrl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.popupMenuStatus = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButtonItemOperationSatusManager = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemToAnesEnd = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemTurnToRoom = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemTurnToICU = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemTrunToPACU = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDictTurnToPACU = new DevExpress.XtraBars.BarButtonItem();
            this.barManagerStatus = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelMain = new System.Windows.Forms.Panel();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // popupMenuStatus
            // 
            this.popupMenuStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemOperationSatusManager),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemToAnesEnd),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemTurnToRoom),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemTurnToICU),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemTrunToPACU),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemDictTurnToPACU),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)});
            this.popupMenuStatus.Manager = this.barManagerStatus;
            this.popupMenuStatus.Name = "popupMenuStatus";
            // 
            // barButtonItemOperationSatusManager
            // 
            this.barButtonItemOperationSatusManager.Caption = "转到状态【入手术室】";
            this.barButtonItemOperationSatusManager.Id = 13;
            this.barButtonItemOperationSatusManager.Name = "barButtonItemOperationSatusManager";
            this.barButtonItemOperationSatusManager.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemOperationSatusManager_ItemClick);
            // 
            // barButtonItemToAnesEnd
            // 
            this.barButtonItemToAnesEnd.Caption = "转到状态【麻醉结束】";
            this.barButtonItemToAnesEnd.Id = 17;
            this.barButtonItemToAnesEnd.Name = "barButtonItemToAnesEnd";
            this.barButtonItemToAnesEnd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemOperationSatusManager_ItemClick);
            // 
            // barButtonItemTurnToRoom
            // 
            this.barButtonItemTurnToRoom.Caption = "转入病房";
            this.barButtonItemTurnToRoom.Id = 15;
            this.barButtonItemTurnToRoom.Name = "barButtonItemTurnToRoom";
            this.barButtonItemTurnToRoom.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemTurnToRoom_ItemClick);
            // 
            // barButtonItemTurnToICU
            // 
            this.barButtonItemTurnToICU.Caption = "转入ICU";
            this.barButtonItemTurnToICU.Id = 18;
            this.barButtonItemTurnToICU.Name = "barButtonItemTurnToICU";
            this.barButtonItemTurnToICU.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemOperationSatusManager_ItemClick);
            // 
            // barButtonItemTrunToPACU
            // 
            this.barButtonItemTrunToPACU.Caption = "进复苏室";
            this.barButtonItemTrunToPACU.Id = 16;
            this.barButtonItemTrunToPACU.Name = "barButtonItemTrunToPACU";
            this.barButtonItemTrunToPACU.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemTrunToPACU_ItemClick);
            // 
            // barButtonItemDictTurnToPACU
            // 
            this.barButtonItemDictTurnToPACU.Caption = "进PACU室";
            this.barButtonItemDictTurnToPACU.Id = 19;
            this.barButtonItemDictTurnToPACU.Name = "barButtonItemDictTurnToPACU";
            this.barButtonItemDictTurnToPACU.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemDictTurnToPACU_ItemClick);
            // 
            // barManagerStatus
            // 
            this.barManagerStatus.DockControls.Add(this.barDockControlTop);
            this.barManagerStatus.DockControls.Add(this.barDockControlBottom);
            this.barManagerStatus.DockControls.Add(this.barDockControlLeft);
            this.barManagerStatus.DockControls.Add(this.barDockControlRight);
            this.barManagerStatus.Form = this;
            this.barManagerStatus.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItemOperationSatusManager,
            this.barButtonItemTurnToRoom,
            this.barButtonItemTurnToICU,
            this.barButtonItemTrunToPACU,
            this.barButtonItemToAnesEnd,
            this.barButtonItemDictTurnToPACU,
            this.barButtonItem1});
            this.barManagerStatus.MaxItemId = 22;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(500, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 58);
            this.barDockControlBottom.Size = new System.Drawing.Size(500, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 58);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(500, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 58);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(500, 58);
            this.panelMain.TabIndex = 4;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "转到死亡";
            this.barButtonItem1.Id = 20;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // PatientStatusContrl
            // 
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "PatientStatusContrl";
            this.Size = new System.Drawing.Size(500, 58);
            this.Load += new System.EventHandler(this.PatientStatusContrl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.PopupMenu popupMenuStatus;
        private DevExpress.XtraBars.BarManager barManagerStatus;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItemOperationSatusManager;
        private DevExpress.XtraBars.BarButtonItem barButtonItemTurnToRoom;
        private DevExpress.XtraBars.BarButtonItem barButtonItemTrunToPACU;
        private DevExpress.XtraBars.BarButtonItem barButtonItemDictTurnToPACU;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraBars.BarButtonItem barButtonItemToAnesEnd;
        private System.Windows.Forms.Panel panelMain;
        private DevExpress.XtraBars.BarButtonItem barButtonItemTurnToICU;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
    }
}
