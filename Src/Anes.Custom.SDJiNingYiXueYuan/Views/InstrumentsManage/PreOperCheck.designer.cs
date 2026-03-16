namespace Wis.Anes.Custom.CustomProject.Views
{
    partial class PreOperCheck
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txtBarCode = new DevExpress.XtraEditors.TextEdit();
            this.txtCheckNum = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtInstrumentName = new DevExpress.XtraEditors.TextEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnDel = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnApplyTemplet = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheckNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInstrumentName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(525, 478);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.AutoPopulateColumns = false;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowColumnResizing = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            this.gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn10, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "条形码";
            this.gridColumn10.FieldName = "BAR_CODE";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.ReadOnly = true;
            this.gridColumn10.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "器械名";
            this.gridColumn11.FieldName = "ITEM_NAME";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.ReadOnly = true;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 0;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "打包数";
            this.gridColumn12.FieldName = "QUANTITY1";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.ReadOnly = true;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 1;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "清点数";
            this.gridColumn13.FieldName = "QUANTITY2";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.ReadOnly = true;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 2;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnApplyTemplet);
            this.panelControl2.Controls.Add(this.txtBarCode);
            this.panelControl2.Controls.Add(this.txtCheckNum);
            this.panelControl2.Controls.Add(this.labelControl4);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.txtInstrumentName);
            this.panelControl2.Controls.Add(this.btnSave);
            this.panelControl2.Controls.Add(this.btnDel);
            this.panelControl2.Controls.Add(this.btnAdd);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl2.Location = new System.Drawing.Point(525, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(407, 478);
            this.panelControl2.TabIndex = 3;
            // 
            // txtBarCode
            // 
            this.txtBarCode.Location = new System.Drawing.Point(16, 102);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(100, 21);
            this.txtBarCode.TabIndex = 9;
            this.txtBarCode.Visible = false;
            // 
            // txtCheckNum
            // 
            this.txtCheckNum.Location = new System.Drawing.Point(249, 59);
            this.txtCheckNum.Name = "txtCheckNum";
            this.txtCheckNum.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCheckNum.Size = new System.Drawing.Size(85, 21);
            this.txtCheckNum.TabIndex = 7;
            this.txtCheckNum.EditValueChanged += new System.EventHandler(this.txtCheckNum_EditValueChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(207, 62);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 14);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "清点数";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(16, 62);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "器械名";
            // 
            // txtInstrumentName
            // 
            this.txtInstrumentName.Location = new System.Drawing.Point(58, 59);
            this.txtInstrumentName.Name = "txtInstrumentName";
            this.txtInstrumentName.Size = new System.Drawing.Size(129, 21);
            this.txtInstrumentName.TabIndex = 4;
            this.txtInstrumentName.EditValueChanged += new System.EventHandler(this.txtInstrumentName_EditValueChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(178, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(97, 16);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(16, 16);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnApplyTemplet
            // 
            this.btnApplyTemplet.Location = new System.Drawing.Point(259, 16);
            this.btnApplyTemplet.Name = "btnApplyTemplet";
            this.btnApplyTemplet.Size = new System.Drawing.Size(75, 23);
            this.btnApplyTemplet.TabIndex = 10;
            this.btnApplyTemplet.Text = "套用模板";
            this.btnApplyTemplet.Click += new System.EventHandler(this.btnApplyTemplet_Click);
            // 
            // PreOperCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl2);
            this.Name = "PreOperCheck";
            this.Size = new System.Drawing.Size(932, 478);
            this.Load += new System.EventHandler(this.PreOperCheck_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheckNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInstrumentName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit txtBarCode;
        private DevExpress.XtraEditors.TextEdit txtCheckNum;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtInstrumentName;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnDel;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnApplyTemplet;
    }
}
