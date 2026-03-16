namespace Wis.Anes.Custom.CustomProject.Views
{
    partial class AddPackage
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
            this.gridViewPackageDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridPackageMaster = new DevExpress.XtraGrid.GridControl();
            this.gridViewPackageMaster = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.radioGroupAddStage = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPackageDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPackageMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPackageMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupAddStage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridViewPackageDetail
            // 
            this.gridViewPackageDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn8,
            this.gridColumn9});
            this.gridViewPackageDetail.GridControl = this.gridPackageMaster;
            this.gridViewPackageDetail.Name = "gridViewPackageDetail";
            this.gridViewPackageDetail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewPackageDetail.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewPackageDetail.OptionsBehavior.AutoPopulateColumns = false;
            this.gridViewPackageDetail.OptionsBehavior.Editable = false;
            this.gridViewPackageDetail.OptionsBehavior.ReadOnly = true;
            this.gridViewPackageDetail.OptionsCustomization.AllowColumnMoving = false;
            this.gridViewPackageDetail.OptionsCustomization.AllowColumnResizing = false;
            this.gridViewPackageDetail.OptionsCustomization.AllowFilter = false;
            this.gridViewPackageDetail.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridViewPackageDetail.OptionsCustomization.AllowSort = false;
            this.gridViewPackageDetail.OptionsDetail.AllowZoomDetail = false;
            this.gridViewPackageDetail.OptionsMenu.EnableColumnMenu = false;
            this.gridViewPackageDetail.OptionsMenu.EnableFooterMenu = false;
            this.gridViewPackageDetail.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewPackageDetail.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            this.gridViewPackageDetail.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.gridViewPackageDetail.OptionsView.ColumnAutoWidth = false;
            this.gridViewPackageDetail.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "器械名称";
            this.gridColumn8.CustomizationCaption = "器械名称";
            this.gridColumn8.FieldName = "INSTRUMENT_NAME";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "数量";
            this.gridColumn9.CustomizationCaption = "数量";
            this.gridColumn9.FieldName = "QUANTITY";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            // 
            // gridPackageMaster
            // 
            this.gridPackageMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.gridViewPackageDetail;
            gridLevelNode1.RelationName = "DetailView";
            this.gridPackageMaster.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridPackageMaster.Location = new System.Drawing.Point(0, 88);
            this.gridPackageMaster.MainView = this.gridViewPackageMaster;
            this.gridPackageMaster.Name = "gridPackageMaster";
            this.gridPackageMaster.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit1});
            this.gridPackageMaster.Size = new System.Drawing.Size(894, 411);
            this.gridPackageMaster.TabIndex = 4;
            this.gridPackageMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPackageMaster,
            this.gridViewPackageDetail});
            // 
            // gridViewPackageMaster
            // 
            this.gridViewPackageMaster.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.gridViewPackageMaster.GridControl = this.gridPackageMaster;
            this.gridViewPackageMaster.Name = "gridViewPackageMaster";
            this.gridViewPackageMaster.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewPackageMaster.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewPackageMaster.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridViewPackageMaster.OptionsBehavior.AutoPopulateColumns = false;
            this.gridViewPackageMaster.OptionsBehavior.Editable = false;
            this.gridViewPackageMaster.OptionsBehavior.ReadOnly = true;
            this.gridViewPackageMaster.OptionsCustomization.AllowColumnMoving = false;
            this.gridViewPackageMaster.OptionsCustomization.AllowColumnResizing = false;
            this.gridViewPackageMaster.OptionsCustomization.AllowFilter = false;
            this.gridViewPackageMaster.OptionsCustomization.AllowGroup = false;
            this.gridViewPackageMaster.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridViewPackageMaster.OptionsCustomization.AllowSort = false;
            this.gridViewPackageMaster.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridViewPackageMaster.OptionsDetail.AllowZoomDetail = false;
            this.gridViewPackageMaster.OptionsDetail.AutoZoomDetail = true;
            this.gridViewPackageMaster.OptionsDetail.ShowDetailTabs = false;
            this.gridViewPackageMaster.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.CheckDefaultDetail;
            this.gridViewPackageMaster.OptionsMenu.EnableColumnMenu = false;
            this.gridViewPackageMaster.OptionsMenu.EnableFooterMenu = false;
            this.gridViewPackageMaster.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewPackageMaster.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            this.gridViewPackageMaster.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.gridViewPackageMaster.OptionsView.ShowGroupPanel = false;
            this.gridViewPackageMaster.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gridViewPackageMaster_MouseMove);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "条形码";
            this.gridColumn1.FieldName = "BAR_CODE";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 160;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "包名";
            this.gridColumn2.FieldName = "PACKAGE_NAME";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 282;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "灭菌日期";
            this.gridColumn3.FieldName = "STERILIZE_DATE";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.FixedWidth = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 100;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "锅次";
            this.gridColumn4.FieldName = "TODAY_USE_TIMES";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.FixedWidth = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 50;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "有效日期";
            this.gridColumn5.FieldName = "EXP_DATE";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.FixedWidth = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 100;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "打包人";
            this.gridColumn6.FieldName = "PACKAGE_OPERATOR";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.FixedWidth = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 50;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "备注";
            this.gridColumn7.FieldName = "MEMO";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.FixedWidth = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemPictureEdit1.NullText = "删除";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.radioGroupAddStage);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.textEdit1);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(894, 88);
            this.panelControl1.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(17, 19);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(96, 14);
            this.labelControl3.TabIndex = 63;
            this.labelControl3.Text = "器械包添加阶段：";
            this.labelControl3.Visible = false;
            // 
            // radioGroupAddStage
            // 
            this.radioGroupAddStage.EditValue = ((short)(0));
            this.radioGroupAddStage.Location = new System.Drawing.Point(122, 15);
            this.radioGroupAddStage.Name = "radioGroupAddStage";
            this.radioGroupAddStage.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroupAddStage.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroupAddStage.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "术前"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "术中")});
            this.radioGroupAddStage.Size = new System.Drawing.Size(126, 24);
            this.radioGroupAddStage.TabIndex = 62;
            this.radioGroupAddStage.Visible = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(539, 48);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(276, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "（若手工写入条形码，则在输入完成时请按回车键）";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(122, 45);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(398, 21);
            this.textEdit1.TabIndex = 1;
            this.textEdit1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textEdit1_KeyDown);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(17, 48);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(84, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "器械包条形码：";
            // 
            // AddPackage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridPackageMaster);
            this.Controls.Add(this.panelControl1);
            this.Name = "AddPackage";
            this.Size = new System.Drawing.Size(894, 499);
            this.Load += new System.EventHandler(this.AddPackage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPackageDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPackageMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPackageMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupAddStage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridPackageMaster;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPackageDetail;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPackageMaster;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.RadioGroup radioGroupAddStage;
    }
}
