namespace Wis.Anes.Framework.Views.Process
{
    partial class PacuQuery
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
            this.pnlBody = new DevExpress.XtraEditors.PanelControl();
            this.dateEditQuery = new DevExpress.XtraEditors.DateEdit();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlList = new DevExpress.XtraGrid.GridControl();
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColumnInpno = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnPatName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnSex = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnAge = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnDept = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnWardCode = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnBedNo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnPipe = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnDrug = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).BeginInit();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditQuery.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditQuery.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlBody.Controls.Add(this.dateEditQuery);
            this.pnlBody.Controls.Add(this.btnPrint);
            this.pnlBody.Controls.Add(this.btnQuery);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1124, 34);
            this.pnlBody.TabIndex = 7;
            // 
            // dateEditQuery
            // 
            this.dateEditQuery.EditValue = null;
            this.dateEditQuery.Location = new System.Drawing.Point(18, 3);
            this.dateEditQuery.Name = "dateEditQuery";
            this.dateEditQuery.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditQuery.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditQuery.Size = new System.Drawing.Size(129, 21);
            this.dateEditQuery.TabIndex = 100;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(257, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 99;
            this.btnPrint.Text = "打印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(164, 3);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 99;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.gridControlList);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 34);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1124, 329);
            this.panelControl1.TabIndex = 8;
            // 
            // gridControlList
            // 
            this.gridControlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlList.Location = new System.Drawing.Point(0, 0);
            this.gridControlList.MainView = this.bandedGridView1;
            this.gridControlList.Name = "gridControlList";
            this.gridControlList.Size = new System.Drawing.Size(1124, 329);
            this.gridControlList.TabIndex = 7;
            this.gridControlList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView1});
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.bandedGridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Navy;
            this.bandedGridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.bandedGridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.bandedGridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
            this.bandedGridView1.Appearance.Row.Options.UseFont = true;
            this.bandedGridView1.AppearancePrint.BandPanel.BackColor = System.Drawing.Color.White;
            this.bandedGridView1.AppearancePrint.BandPanel.Options.UseBackColor = true;
            this.bandedGridView1.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White;
            this.bandedGridView1.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.gridColumnInpno,
            this.gridColumnPatName,
            this.gridColumnSex,
            this.gridColumnAge,
            this.gridColumnDept,
            this.gridColumnWardCode,
            this.gridColumnBedNo,
            this.gridColumnPipe,
            this.gridColumnDrug,
            this.gridColumn1,
            this.gridColumn2});
            this.bandedGridView1.GridControl = this.gridControlList;
            this.bandedGridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.bandedGridView1.Name = "bandedGridView1";
            this.bandedGridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridView1.OptionsBehavior.Editable = false;
            this.bandedGridView1.OptionsBehavior.ReadOnly = true;
            this.bandedGridView1.OptionsMenu.EnableColumnMenu = false;
            this.bandedGridView1.OptionsMenu.EnableFooterMenu = false;
            this.bandedGridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.bandedGridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            this.bandedGridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.bandedGridView1.OptionsPrint.UsePrintStyles = true;
            this.bandedGridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.bandedGridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.bandedGridView1.OptionsView.ColumnAutoWidth = false;
            this.bandedGridView1.OptionsView.ShowGroupPanel = false;
            this.bandedGridView1.OptionsView.ShowIndicator = false;
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridBand1.AppearanceHeader.Options.UseFont = true;
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.Caption = "2013-04-17    共   12例   PACU带管 1例 拔管  1 例    最后一例出室时间 16:00 PACU医师 不认识 没见过 陌生人";
            this.gridBand1.Columns.Add(this.gridColumnInpno);
            this.gridBand1.Columns.Add(this.gridColumnPatName);
            this.gridBand1.Columns.Add(this.gridColumnSex);
            this.gridBand1.Columns.Add(this.gridColumnAge);
            this.gridBand1.Columns.Add(this.gridColumnDept);
            this.gridBand1.Columns.Add(this.gridColumnWardCode);
            this.gridBand1.Columns.Add(this.gridColumnBedNo);
            this.gridBand1.Columns.Add(this.gridColumnPipe);
            this.gridBand1.Columns.Add(this.gridColumnDrug);
            this.gridBand1.Columns.Add(this.gridColumn1);
            this.gridBand1.Columns.Add(this.gridColumn2);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.OptionsBand.AllowHotTrack = false;
            this.gridBand1.OptionsBand.AllowMove = false;
            this.gridBand1.OptionsBand.AllowPress = false;
            this.gridBand1.OptionsBand.AllowSize = false;
            this.gridBand1.OptionsBand.FixedWidth = true;
            this.gridBand1.RowCount = 2;
            this.gridBand1.Width = 1050;
            // 
            // gridColumnInpno
            // 
            this.gridColumnInpno.Caption = "住院号";
            this.gridColumnInpno.FieldName = "INP_NO";
            this.gridColumnInpno.Name = "gridColumnInpno";
            this.gridColumnInpno.OptionsColumn.AllowEdit = false;
            this.gridColumnInpno.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnInpno.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnInpno.OptionsFilter.AllowAutoFilter = false;
            this.gridColumnInpno.OptionsFilter.AllowFilter = false;
            this.gridColumnInpno.Visible = true;
            // 
            // gridColumnPatName
            // 
            this.gridColumnPatName.Caption = "患者姓名";
            this.gridColumnPatName.FieldName = "NAME";
            this.gridColumnPatName.Name = "gridColumnPatName";
            this.gridColumnPatName.OptionsColumn.AllowEdit = false;
            this.gridColumnPatName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnPatName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnPatName.OptionsFilter.AllowAutoFilter = false;
            this.gridColumnPatName.OptionsFilter.AllowFilter = false;
            this.gridColumnPatName.Visible = true;
            this.gridColumnPatName.Width = 85;
            // 
            // gridColumnSex
            // 
            this.gridColumnSex.Caption = "性别";
            this.gridColumnSex.FieldName = "SEX";
            this.gridColumnSex.Name = "gridColumnSex";
            this.gridColumnSex.OptionsColumn.AllowEdit = false;
            this.gridColumnSex.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnSex.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnSex.Visible = true;
            this.gridColumnSex.Width = 55;
            // 
            // gridColumnAge
            // 
            this.gridColumnAge.Caption = "年龄";
            this.gridColumnAge.FieldName = "AGE";
            this.gridColumnAge.Name = "gridColumnAge";
            this.gridColumnAge.OptionsColumn.AllowEdit = false;
            this.gridColumnAge.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnAge.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnAge.OptionsFilter.AllowAutoFilter = false;
            this.gridColumnAge.OptionsFilter.AllowFilter = false;
            this.gridColumnAge.Visible = true;
            this.gridColumnAge.Width = 55;
            // 
            // gridColumnDept
            // 
            this.gridColumnDept.Caption = "科室";
            this.gridColumnDept.FieldName = "DEPT_NAME";
            this.gridColumnDept.Name = "gridColumnDept";
            this.gridColumnDept.OptionsColumn.AllowEdit = false;
            this.gridColumnDept.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnDept.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnDept.OptionsFilter.AllowAutoFilter = false;
            this.gridColumnDept.OptionsFilter.AllowFilter = false;
            this.gridColumnDept.Visible = true;
            // 
            // gridColumnWardCode
            // 
            this.gridColumnWardCode.Caption = "病区";
            this.gridColumnWardCode.FieldName = "WARD_NAME";
            this.gridColumnWardCode.Name = "gridColumnWardCode";
            this.gridColumnWardCode.OptionsColumn.AllowEdit = false;
            this.gridColumnWardCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnWardCode.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnWardCode.OptionsFilter.AllowAutoFilter = false;
            this.gridColumnWardCode.OptionsFilter.AllowFilter = false;
            this.gridColumnWardCode.Visible = true;
            // 
            // gridColumnBedNo
            // 
            this.gridColumnBedNo.Caption = "床位";
            this.gridColumnBedNo.FieldName = "BED_NO";
            this.gridColumnBedNo.Name = "gridColumnBedNo";
            this.gridColumnBedNo.OptionsColumn.AllowEdit = false;
            this.gridColumnBedNo.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnBedNo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnBedNo.Visible = true;
            this.gridColumnBedNo.Width = 55;
            // 
            // gridColumnPipe
            // 
            this.gridColumnPipe.Caption = "气管导管";
            this.gridColumnPipe.FieldName = "PULL_PIPE";
            this.gridColumnPipe.Name = "gridColumnPipe";
            this.gridColumnPipe.Visible = true;
            this.gridColumnPipe.Width = 125;
            // 
            // gridColumnDrug
            // 
            this.gridColumnDrug.Caption = "PACU用药";
            this.gridColumnDrug.FieldName = "DRUG_USE";
            this.gridColumnDrug.Name = "gridColumnDrug";
            this.gridColumnDrug.OptionsColumn.FixedWidth = true;
            this.gridColumnDrug.Visible = true;
            this.gridColumnDrug.Width = 200;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "入室时间";
            this.gridColumn1.DisplayFormat.FormatString = "T";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn1.FieldName = "IN_PACU_DATE_TIME";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.Width = 125;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "出室时间";
            this.gridColumn2.DisplayFormat.FormatString = "T";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn2.FieldName = "OUT_PACU_DATE_TIME";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.Width = 125;
            // 
            // PacuQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Caption = "手术进程";
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.pnlBody);
            this.Name = "PacuQuery";
            this.Size = new System.Drawing.Size(1124, 363);
            this.Load += new System.EventHandler(this.OperationProcess_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).EndInit();
            this.pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateEditQuery.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditQuery.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlBody;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControlList;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private DevExpress.XtraEditors.DateEdit dateEditQuery;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnInpno;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnPatName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnSex;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnAge;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnDept;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnWardCode;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnBedNo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnPipe;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnDrug;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraEditors.SimpleButton btnPrint;

    }
}
