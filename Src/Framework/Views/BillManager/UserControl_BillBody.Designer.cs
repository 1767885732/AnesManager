namespace Wis.Anes.Framework.Views.BillManager
{
    partial class UserControl_BillBody
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridControlLeftList = new DevExpress.XtraGrid.GridControl();
            this.gridViewLeftList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnITEM_CLASS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumnITEM_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnITEM_SPEC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnITEM_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnUNIT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDOSAGE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnFee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.labelSumCost = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelAllCost = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLeftList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLeftList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelAllCost.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControlLeftList
            // 
            this.gridControlLeftList.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.gridControlLeftList.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControlLeftList.Location = new System.Drawing.Point(0, 0);
            this.gridControlLeftList.MainView = this.gridViewLeftList;
            this.gridControlLeftList.Name = "gridControlLeftList";
            this.gridControlLeftList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.gridControlLeftList.Size = new System.Drawing.Size(654, 502);
            this.gridControlLeftList.TabIndex = 5;
            this.gridControlLeftList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewLeftList});
            // 
            // gridViewLeftList
            // 
            this.gridViewLeftList.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.gridViewLeftList.Appearance.Row.BackColor2 = System.Drawing.Color.White;
            this.gridViewLeftList.Appearance.Row.Options.UseBackColor = true;
            this.gridViewLeftList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnITEM_CLASS,
            this.gridColumnITEM_NAME,
            this.gridColumnITEM_SPEC,
            this.gridColumnITEM_CODE,
            this.gridColumnUNIT,
            this.gridColumnDOSAGE,
            this.gridColumnPrice,
            this.gridColumnFee,
            this.gridColumn1,
            this.gridColumn2});
            this.gridViewLeftList.GridControl = this.gridControlLeftList;
            this.gridViewLeftList.Name = "gridViewLeftList";
            this.gridViewLeftList.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewLeftList.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewLeftList.OptionsView.ShowGroupPanel = false;
            this.gridViewLeftList.OptionsView.ShowIndicator = false;
            this.gridViewLeftList.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridViewLeftList_CustomDrawCell);
            this.gridViewLeftList.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridViewLeftList_ShowingEditor);
            // 
            // gridColumnITEM_CLASS
            // 
            this.gridColumnITEM_CLASS.Caption = "类别";
            this.gridColumnITEM_CLASS.ColumnEdit = this.repositoryItemTextEdit1;
            this.gridColumnITEM_CLASS.FieldName = "ITEM_CLASS_NAME";
            this.gridColumnITEM_CLASS.Name = "gridColumnITEM_CLASS";
            this.gridColumnITEM_CLASS.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnITEM_CLASS.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnITEM_CLASS.OptionsColumn.FixedWidth = true;
            this.gridColumnITEM_CLASS.OptionsFilter.AllowAutoFilter = false;
            this.gridColumnITEM_CLASS.OptionsFilter.AllowFilter = false;
            this.gridColumnITEM_CLASS.Visible = true;
            this.gridColumnITEM_CLASS.VisibleIndex = 0;
            this.gridColumnITEM_CLASS.Width = 35;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            this.repositoryItemTextEdit1.ReadOnly = true;
            // 
            // gridColumnITEM_NAME
            // 
            this.gridColumnITEM_NAME.Caption = "收费项目";
            this.gridColumnITEM_NAME.ColumnEdit = this.repositoryItemTextEdit1;
            this.gridColumnITEM_NAME.FieldName = "ITEM_NAME";
            this.gridColumnITEM_NAME.Name = "gridColumnITEM_NAME";
            this.gridColumnITEM_NAME.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnITEM_NAME.OptionsColumn.AllowSize = false;
            this.gridColumnITEM_NAME.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnITEM_NAME.OptionsFilter.AllowAutoFilter = false;
            this.gridColumnITEM_NAME.OptionsFilter.AllowFilter = false;
            this.gridColumnITEM_NAME.Visible = true;
            this.gridColumnITEM_NAME.VisibleIndex = 1;
            this.gridColumnITEM_NAME.Width = 275;
            // 
            // gridColumnITEM_SPEC
            // 
            this.gridColumnITEM_SPEC.Caption = "规格";
            this.gridColumnITEM_SPEC.FieldName = "ITEM_SPEC";
            this.gridColumnITEM_SPEC.Name = "gridColumnITEM_SPEC";
            this.gridColumnITEM_SPEC.OptionsColumn.AllowEdit = false;
            this.gridColumnITEM_SPEC.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnITEM_SPEC.OptionsColumn.AllowSize = false;
            this.gridColumnITEM_SPEC.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnITEM_SPEC.OptionsColumn.FixedWidth = true;
            this.gridColumnITEM_SPEC.OptionsFilter.AllowAutoFilter = false;
            this.gridColumnITEM_SPEC.OptionsFilter.AllowFilter = false;
            this.gridColumnITEM_SPEC.Visible = true;
            this.gridColumnITEM_SPEC.VisibleIndex = 2;
            this.gridColumnITEM_SPEC.Width = 100;
            // 
            // gridColumnITEM_CODE
            // 
            this.gridColumnITEM_CODE.Caption = "gridColumn1";
            this.gridColumnITEM_CODE.FieldName = "ITEM_CODE";
            this.gridColumnITEM_CODE.Name = "gridColumnITEM_CODE";
            // 
            // gridColumnUNIT
            // 
            this.gridColumnUNIT.Caption = "单位";
            this.gridColumnUNIT.FieldName = "UNITS";
            this.gridColumnUNIT.Name = "gridColumnUNIT";
            this.gridColumnUNIT.OptionsColumn.AllowEdit = false;
            this.gridColumnUNIT.OptionsColumn.AllowSize = false;
            this.gridColumnUNIT.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnUNIT.OptionsColumn.FixedWidth = true;
            this.gridColumnUNIT.OptionsFilter.AllowAutoFilter = false;
            this.gridColumnUNIT.OptionsFilter.AllowFilter = false;
            this.gridColumnUNIT.Visible = true;
            this.gridColumnUNIT.VisibleIndex = 4;
            this.gridColumnUNIT.Width = 55;
            // 
            // gridColumnDOSAGE
            // 
            this.gridColumnDOSAGE.Caption = "用量";
            this.gridColumnDOSAGE.DisplayFormat.FormatString = "{0:F2}";
            this.gridColumnDOSAGE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnDOSAGE.FieldName = "AMOUNT";
            this.gridColumnDOSAGE.Name = "gridColumnDOSAGE";
            this.gridColumnDOSAGE.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnDOSAGE.OptionsColumn.AllowSize = false;
            this.gridColumnDOSAGE.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnDOSAGE.OptionsColumn.FixedWidth = true;
            this.gridColumnDOSAGE.OptionsFilter.AllowAutoFilter = false;
            this.gridColumnDOSAGE.OptionsFilter.AllowFilter = false;
            this.gridColumnDOSAGE.Visible = true;
            this.gridColumnDOSAGE.VisibleIndex = 3;
            this.gridColumnDOSAGE.Width = 40;
            // 
            // gridColumnPrice
            // 
            this.gridColumnPrice.Caption = "价格(元)";
            this.gridColumnPrice.DisplayFormat.FormatString = "{0:F4}";
            this.gridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnPrice.FieldName = "PRICE";
            this.gridColumnPrice.Name = "gridColumnPrice";
            this.gridColumnPrice.OptionsColumn.AllowEdit = false;
            this.gridColumnPrice.OptionsColumn.AllowSize = false;
            this.gridColumnPrice.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnPrice.OptionsColumn.FixedWidth = true;
            this.gridColumnPrice.OptionsFilter.AllowAutoFilter = false;
            this.gridColumnPrice.OptionsFilter.AllowFilter = false;
            this.gridColumnPrice.Visible = true;
            this.gridColumnPrice.VisibleIndex = 5;
            this.gridColumnPrice.Width = 70;
            // 
            // gridColumnFee
            // 
            this.gridColumnFee.Caption = "费用(元)";
            this.gridColumnFee.DisplayFormat.FormatString = "{0:F4}";
            this.gridColumnFee.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnFee.FieldName = "COSTS";
            this.gridColumnFee.Name = "gridColumnFee";
            this.gridColumnFee.OptionsColumn.AllowEdit = false;
            this.gridColumnFee.OptionsColumn.AllowSize = false;
            this.gridColumnFee.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnFee.OptionsColumn.FixedWidth = true;
            this.gridColumnFee.OptionsFilter.AllowAutoFilter = false;
            this.gridColumnFee.OptionsFilter.AllowFilter = false;
            this.gridColumnFee.Visible = true;
            this.gridColumnFee.VisibleIndex = 6;
            this.gridColumnFee.Width = 70;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "原数量";
            this.gridColumn1.FieldName = "DOSAGE";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "原单位";
            this.gridColumn2.FieldName = "DOSAGE_UNITS";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(158, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "元";
            // 
            // labelSumCost
            // 
            this.labelSumCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSumCost.BackColor = System.Drawing.Color.Transparent;
            this.labelSumCost.ForeColor = System.Drawing.Color.Blue;
            this.labelSumCost.Location = new System.Drawing.Point(85, 6);
            this.labelSumCost.Name = "labelSumCost";
            this.labelSumCost.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelSumCost.Size = new System.Drawing.Size(70, 12);
            this.labelSumCost.TabIndex = 7;
            this.labelSumCost.Text = "0.00";
            this.labelSumCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(14, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "总计费用：";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.panelAllCost);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 502);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(654, 22);
            this.panel1.TabIndex = 7;
            // 
            // panelAllCost
            // 
            this.panelAllCost.BackColor = System.Drawing.Color.Transparent;
            this.panelAllCost.Controls.Add(this.label1);
            this.panelAllCost.Controls.Add(this.labelSumCost);
            this.panelAllCost.Controls.Add(this.label2);
            this.panelAllCost.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelAllCost.Location = new System.Drawing.Point(437, 0);
            this.panelAllCost.Name = "panelAllCost";
            this.panelAllCost.Size = new System.Drawing.Size(217, 22);
            this.panelAllCost.TabIndex = 8;
            // 
            // UserControl_BillBody
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControlLeftList);
            this.Controls.Add(this.panel1);
            this.Name = "UserControl_BillBody";
            this.Size = new System.Drawing.Size(654, 524);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLeftList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLeftList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panelAllCost.ResumeLayout(false);
            this.panelAllCost.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlLeftList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewLeftList;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnITEM_CLASS;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnITEM_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnITEM_SPEC;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDOSAGE;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnITEM_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnUNIT;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPrice;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnFee;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelSumCost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelAllCost;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
    }
}
