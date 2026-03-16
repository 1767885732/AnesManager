namespace Wis.Anes.Framework.Views.BillManager
{
    partial class UserControl_BillLeftList
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
            this.gridControlLeftList = new DevExpress.XtraGrid.GridControl();
            this.gridViewLeftList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnITEM_CLASS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnITEM_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnITEM_SPEC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDOSAGE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnITEM_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLeftList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLeftList)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlLeftList
            // 
            this.gridControlLeftList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlLeftList.Location = new System.Drawing.Point(0, 0);
            this.gridControlLeftList.MainView = this.gridViewLeftList;
            this.gridControlLeftList.Name = "gridControlLeftList";
            this.gridControlLeftList.Size = new System.Drawing.Size(237, 524);
            this.gridControlLeftList.TabIndex = 5;
            this.gridControlLeftList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewLeftList});
            // 
            // gridViewLeftList
            // 
            this.gridViewLeftList.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridViewLeftList.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridViewLeftList.Appearance.Empty.BackColor = System.Drawing.Color.White;
            this.gridViewLeftList.Appearance.Empty.Options.UseBackColor = true;
            this.gridViewLeftList.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.gridViewLeftList.Appearance.Row.Options.UseBackColor = true;
            this.gridViewLeftList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnITEM_CLASS,
            this.gridColumnITEM_NAME,
            this.gridColumnITEM_SPEC,
            this.gridColumnDOSAGE,
            this.gridColumnITEM_CODE});
            this.gridViewLeftList.GridControl = this.gridControlLeftList;
            this.gridViewLeftList.Name = "gridViewLeftList";
            this.gridViewLeftList.OptionsBehavior.ReadOnly = true;
            this.gridViewLeftList.OptionsView.AllowCellMerge = true;
            this.gridViewLeftList.OptionsView.ShowGroupPanel = false;
            this.gridViewLeftList.OptionsView.ShowIndicator = false;
            // 
            // gridColumnITEM_CLASS
            // 
            this.gridColumnITEM_CLASS.Caption = "类别";
            this.gridColumnITEM_CLASS.FieldName = "ITEM_CLASS_NAME";
            this.gridColumnITEM_CLASS.Name = "gridColumnITEM_CLASS";
            this.gridColumnITEM_CLASS.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnITEM_CLASS.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnITEM_CLASS.OptionsColumn.FixedWidth = true;
            this.gridColumnITEM_CLASS.OptionsFilter.AllowAutoFilter = false;
            this.gridColumnITEM_CLASS.OptionsFilter.AllowFilter = false;
            this.gridColumnITEM_CLASS.Visible = true;
            this.gridColumnITEM_CLASS.VisibleIndex = 0;
            this.gridColumnITEM_CLASS.Width = 35;
            // 
            // gridColumnITEM_NAME
            // 
            this.gridColumnITEM_NAME.Caption = "事件";
            this.gridColumnITEM_NAME.FieldName = "ITEM_NAME";
            this.gridColumnITEM_NAME.Name = "gridColumnITEM_NAME";
            this.gridColumnITEM_NAME.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnITEM_NAME.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnITEM_NAME.OptionsFilter.AllowAutoFilter = false;
            this.gridColumnITEM_NAME.OptionsFilter.AllowFilter = false;
            this.gridColumnITEM_NAME.Visible = true;
            this.gridColumnITEM_NAME.VisibleIndex = 1;
            this.gridColumnITEM_NAME.Width = 60;
            // 
            // gridColumnITEM_SPEC
            // 
            this.gridColumnITEM_SPEC.Caption = "规格";
            this.gridColumnITEM_SPEC.FieldName = "ITEM_SPEC";
            this.gridColumnITEM_SPEC.Name = "gridColumnITEM_SPEC";
            this.gridColumnITEM_SPEC.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnITEM_SPEC.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnITEM_SPEC.OptionsColumn.FixedWidth = true;
            this.gridColumnITEM_SPEC.OptionsFilter.AllowAutoFilter = false;
            this.gridColumnITEM_SPEC.OptionsFilter.AllowFilter = false;
            this.gridColumnITEM_SPEC.Visible = true;
            this.gridColumnITEM_SPEC.VisibleIndex = 2;
            this.gridColumnITEM_SPEC.Width = 45;
            // 
            // gridColumnDOSAGE
            // 
            this.gridColumnDOSAGE.Caption = "剂量";
            this.gridColumnDOSAGE.FieldName = "DOSAGE";
            this.gridColumnDOSAGE.Name = "gridColumnDOSAGE";
            this.gridColumnDOSAGE.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnDOSAGE.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnDOSAGE.OptionsColumn.FixedWidth = true;
            this.gridColumnDOSAGE.OptionsFilter.AllowAutoFilter = false;
            this.gridColumnDOSAGE.OptionsFilter.AllowFilter = false;
            this.gridColumnDOSAGE.Visible = true;
            this.gridColumnDOSAGE.VisibleIndex = 3;
            this.gridColumnDOSAGE.Width = 35;
            // 
            // gridColumnITEM_CODE
            // 
            this.gridColumnITEM_CODE.Caption = "gridColumn1";
            this.gridColumnITEM_CODE.FieldName = "ITEM_CODE";
            this.gridColumnITEM_CODE.Name = "gridColumnITEM_CODE";
            // 
            // UserControl_BillLeftList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControlLeftList);
            this.Name = "UserControl_BillLeftList";
            this.Size = new System.Drawing.Size(237, 524);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLeftList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLeftList)).EndInit();
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
    }
}
