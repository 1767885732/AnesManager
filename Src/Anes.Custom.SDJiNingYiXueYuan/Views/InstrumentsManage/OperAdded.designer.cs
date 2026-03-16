namespace Wis.Anes.Custom.CustomProject.Views
{
    partial class OperAdded
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
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.btnSave2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnDel2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd2 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl3 = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(592, 523);
            this.gridControl2.TabIndex = 3;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsBehavior.ReadOnly = true;
            this.gridView2.OptionsCustomization.AllowColumnMoving = false;
            this.gridView2.OptionsCustomization.AllowColumnResizing = false;
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsCustomization.AllowGroup = false;
            this.gridView2.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView2.OptionsCustomization.AllowSort = false;
            this.gridView2.OptionsMenu.EnableColumnMenu = false;
            this.gridView2.OptionsMenu.EnableFooterMenu = false;
            this.gridView2.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView2.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            this.gridView2.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView2_FocusedRowChanged);
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "器械名称";
            this.gridColumn14.FieldName = "ITEM_NAME";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 0;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "术前清点";
            this.gridColumn15.FieldName = "QUANTITY2";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 1;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "术中增加";
            this.gridColumn16.FieldName = "QUANTITY3";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 2;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.btnSave2);
            this.panelControl4.Controls.Add(this.btnDel2);
            this.panelControl4.Controls.Add(this.btnAdd2);
            this.panelControl4.Controls.Add(this.gridControl3);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl4.Location = new System.Drawing.Point(592, 0);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(366, 523);
            this.panelControl4.TabIndex = 2;
            // 
            // btnSave2
            // 
            this.btnSave2.Location = new System.Drawing.Point(179, 274);
            this.btnSave2.Name = "btnSave2";
            this.btnSave2.Size = new System.Drawing.Size(75, 23);
            this.btnSave2.TabIndex = 3;
            this.btnSave2.Text = "保存";
            this.btnSave2.Click += new System.EventHandler(this.btnSave2_Click);
            // 
            // btnDel2
            // 
            this.btnDel2.Location = new System.Drawing.Point(98, 274);
            this.btnDel2.Name = "btnDel2";
            this.btnDel2.Size = new System.Drawing.Size(75, 23);
            this.btnDel2.TabIndex = 2;
            this.btnDel2.Text = "删除";
            this.btnDel2.Click += new System.EventHandler(this.btnDel2_Click);
            // 
            // btnAdd2
            // 
            this.btnAdd2.Location = new System.Drawing.Point(17, 274);
            this.btnAdd2.Name = "btnAdd2";
            this.btnAdd2.Size = new System.Drawing.Size(75, 23);
            this.btnAdd2.TabIndex = 1;
            this.btnAdd2.Text = "添加";
            this.btnAdd2.Click += new System.EventHandler(this.btnAdd2_Click);
            // 
            // gridControl3
            // 
            this.gridControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridControl3.Location = new System.Drawing.Point(2, 2);
            this.gridControl3.MainView = this.gridView3;
            this.gridControl3.Name = "gridControl3";
            this.gridControl3.Size = new System.Drawing.Size(362, 257);
            this.gridControl3.TabIndex = 0;
            this.gridControl3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19});
            this.gridView3.GridControl = this.gridControl3;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView3.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView3.OptionsBehavior.AutoPopulateColumns = false;
            this.gridView3.OptionsCustomization.AllowColumnMoving = false;
            this.gridView3.OptionsCustomization.AllowColumnResizing = false;
            this.gridView3.OptionsCustomization.AllowFilter = false;
            this.gridView3.OptionsCustomization.AllowGroup = false;
            this.gridView3.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView3.OptionsCustomization.AllowSort = false;
            this.gridView3.OptionsMenu.EnableColumnMenu = false;
            this.gridView3.OptionsMenu.EnableFooterMenu = false;
            this.gridView3.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView3.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            this.gridView3.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            this.gridView3.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView3_CellValueChanged);
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "器械名称";
            this.gridColumn17.FieldName = "ITEM_NAME";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsColumn.ReadOnly = true;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 0;
            this.gridColumn17.Width = 90;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "序号";
            this.gridColumn18.FieldName = "ADD_NO";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.ReadOnly = true;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 1;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "添加数";
            this.gridColumn19.FieldName = "QUANTITY";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 2;
            this.gridColumn19.Width = 176;
            // 
            // OperAdded
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl2);
            this.Controls.Add(this.panelControl4);
            this.Name = "OperAdded";
            this.Size = new System.Drawing.Size(958, 523);
            this.Load += new System.EventHandler(this.OperAdded_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.SimpleButton btnSave2;
        private DevExpress.XtraEditors.SimpleButton btnDel2;
        private DevExpress.XtraEditors.SimpleButton btnAdd2;
        private DevExpress.XtraGrid.GridControl gridControl3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
    }
}
