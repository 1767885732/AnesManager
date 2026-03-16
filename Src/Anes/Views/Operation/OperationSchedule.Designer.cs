namespace Wis.Anes.Views
{
    partial class OperationSchedule
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
            this.pnlBody = new DevExpress.XtraEditors.PanelControl();
            this.btnHisInfo = new DevExpress.XtraEditors.SimpleButton();
            this.dateTimePickerQuery = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtOtherUse = new Wis.Anes.Framework.Controls.DictTextBox();
            this.radioType = new DevExpress.XtraEditors.RadioGroup();
            this.labelControlName = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlList = new DevExpress.XtraGrid.GridControl();
            this.gridViewLeftList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRoom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnOutTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnOperationSequence = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAnesDoctor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAnesDoctor2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDept = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnBedNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPatName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPatID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnInpno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnWardCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnOperatoinName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAnesMethod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnOperationNurse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSupplyNurse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSurgeon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAssistant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStripInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuInfo = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).BeginInit();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimePickerQuery.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimePickerQuery.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherUse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLeftList)).BeginInit();
            this.contextMenuStripInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlBody.Controls.Add(this.btnHisInfo);
            this.pnlBody.Controls.Add(this.dateTimePickerQuery);
            this.pnlBody.Controls.Add(this.labelControl1);
            this.pnlBody.Controls.Add(this.txtOtherUse);
            this.pnlBody.Controls.Add(this.radioType);
            this.pnlBody.Controls.Add(this.labelControlName);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(809, 37);
            this.pnlBody.TabIndex = 7;
            // 
            // btnHisInfo
            // 
            this.btnHisInfo.Location = new System.Drawing.Point(419, 8);
            this.btnHisInfo.Name = "btnHisInfo";
            this.btnHisInfo.Size = new System.Drawing.Size(75, 23);
            this.btnHisInfo.TabIndex = 92;
            this.btnHisInfo.Text = "患者信息";
            this.btnHisInfo.Click += new System.EventHandler(this.btnHisInfo_Click);
            // 
            // dateTimePickerQuery
            // 
            this.dateTimePickerQuery.EditValue = null;
            this.dateTimePickerQuery.Location = new System.Drawing.Point(284, 8);
            this.dateTimePickerQuery.Name = "dateTimePickerQuery";
            this.dateTimePickerQuery.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateTimePickerQuery.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateTimePickerQuery.Size = new System.Drawing.Size(129, 21);
            this.dateTimePickerQuery.TabIndex = 91;
            this.dateTimePickerQuery.EditValueChanged += new System.EventHandler(this.dateTimePickerQuery_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(152, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 90;
            this.labelControl1.Text = "其他人";
            // 
            // txtOtherUse
            // 
            this.txtOtherUse.BindFieldName = "";
            this.txtOtherUse.BindList = "";
            this.txtOtherUse.BindTableName = "";
            this.txtOtherUse.BorderColor = System.Drawing.Color.LightGray;
            this.txtOtherUse.BottomLine = false;
            this.txtOtherUse.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtOtherUse.CanEdit = true;
            this.txtOtherUse.CelerityInputCodeColumnName = "USER_NAME";
            this.txtOtherUse.CelerityInputSqlWhere = "";
            this.txtOtherUse.CelerityInputTableName = "WIS_PERM_HIS_USER";
            this.txtOtherUse.CelerityInputValueColumnName = "USER_ID";
            this.txtOtherUse.Data = null;
            this.txtOtherUse.DefaultPrintText = "";
            this.txtOtherUse.DictTableName = "WIS_PERM_HIS_USER";
            this.txtOtherUse.DictValueFieldName = "USER_ID";
            this.txtOtherUse.DictWhereString = "";
            this.txtOtherUse.DisplayFieldName = "USER_NAME";
            this.txtOtherUse.DisplayMutiColFieldName = "USER_NAME,USER_ID,USER_DEPT";
            this.txtOtherUse.DotBorder = false;
            this.txtOtherUse.DotNumber = 0;
            this.txtOtherUse.ExamItemName = null;
            this.txtOtherUse.FieldName = "dictTextBox1";
            this.txtOtherUse.Format = "";
            this.txtOtherUse.HasLookUpItems = false;
            this.txtOtherUse.InitValue = "";
            this.txtOtherUse.InputNeededMessage = "";
            this.txtOtherUse.InputType = Wis.Anes.Framework.Controls.MedInputType.General;
            this.txtOtherUse.LabItemName = null;
            this.txtOtherUse.LimitedString = "";
            this.txtOtherUse.Location = new System.Drawing.Point(194, 8);
            this.txtOtherUse.LockInput = false;
            this.txtOtherUse.Maximum = null;
            this.txtOtherUse.MaxLength = 0;
            this.txtOtherUse.Minimum = null;
            this.txtOtherUse.Multiline = false;
            this.txtOtherUse.MultiSelect = false;
            this.txtOtherUse.MultiSign = false;
            this.txtOtherUse.Name = "txtOtherUse";
            this.txtOtherUse.NoPrint = false;
            this.txtOtherUse.NoPrintText = "";
            this.txtOtherUse.NullAble = true;
            this.txtOtherUse.OldForeColor = System.Drawing.Color.Black;
            this.txtOtherUse.PasswordChar = '\0';
            this.txtOtherUse.PrintTail = "";
            this.txtOtherUse.PrintXOffSet = 0F;
            this.txtOtherUse.PrintYOffSet = 0F;
            this.txtOtherUse.ProgramChanging = false;
            this.txtOtherUse.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtOtherUse.Properties.Appearance.Options.UseBackColor = true;
            this.txtOtherUse.Properties.Appearance.Options.UseTextOptions = true;
            this.txtOtherUse.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtOtherUse.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtOtherUse.ReadOnly = false;
            this.txtOtherUse.SelfValue = "";
            this.txtOtherUse.SelfValueChanged = false;
            this.txtOtherUse.Size = new System.Drawing.Size(84, 21);
            this.txtOtherUse.SourceFieldName = "";
            this.txtOtherUse.SourceTableName = "";
            this.txtOtherUse.StoredValue = "";
            this.txtOtherUse.TabIndex = 89;
            this.txtOtherUse.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtOtherUse.UnderLineOffset = 0F;
            this.txtOtherUse.WantValueBeforePrint = "";
            this.txtOtherUse.WordWrap = false;
            this.txtOtherUse.TextChanged += new System.EventHandler(this.txtOtherUse_TextChanged);
            // 
            // radioType
            // 
            this.radioType.Location = new System.Drawing.Point(12, 6);
            this.radioType.Name = "radioType";
            this.radioType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "全部"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "本人的")});
            this.radioType.Size = new System.Drawing.Size(121, 28);
            this.radioType.TabIndex = 87;
            this.radioType.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // labelControlName
            // 
            this.labelControlName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControlName.Appearance.Options.UseFont = true;
            this.labelControlName.Appearance.Options.UseTextOptions = true;
            this.labelControlName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControlName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControlName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControlName.Location = new System.Drawing.Point(514, 5);
            this.labelControlName.Name = "labelControlName";
            this.labelControlName.Size = new System.Drawing.Size(255, 29);
            this.labelControlName.TabIndex = 88;
            this.labelControlName.Text = "手术排台";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.gridControlList);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 37);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(809, 326);
            this.panelControl1.TabIndex = 8;
            // 
            // gridControlList
            // 
            this.gridControlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlList.Location = new System.Drawing.Point(0, 0);
            this.gridControlList.MainView = this.gridViewLeftList;
            this.gridControlList.Name = "gridControlList";
            this.gridControlList.Size = new System.Drawing.Size(809, 326);
            this.gridControlList.TabIndex = 7;
            this.gridControlList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewLeftList});
            // 
            // gridViewLeftList
            // 
            this.gridViewLeftList.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewLeftList.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Navy;
            this.gridViewLeftList.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewLeftList.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridViewLeftList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnId,
            this.gridColumnRoom,
            this.gridColumnOutTime,
            this.gridColumnOperationSequence,
            this.gridColumnAnesDoctor,
            this.gridColumnAnesDoctor2,
            this.gridColumn3,
            this.gridColumnDept,
            this.gridColumnBedNo,
            this.gridColumnPatName,
            this.gridColumnSex,
            this.gridColumnAge,
            this.gridColumnPatID,
            this.gridColumnInpno,
            this.gridColumnWardCode,
            this.gridColumnOperatoinName,
            this.gridColumn1,
            this.gridColumnAnesMethod,
            this.gridColumnOperationNurse,
            this.gridColumnSupplyNurse,
            this.gridColumnSurgeon,
            this.gridColumnAssistant});
            this.gridViewLeftList.GridControl = this.gridControlList;
            this.gridViewLeftList.Name = "gridViewLeftList";
            this.gridViewLeftList.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewLeftList.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewLeftList.OptionsSelection.MultiSelect = true;
            this.gridViewLeftList.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridViewLeftList.OptionsView.AllowCellMerge = true;
            this.gridViewLeftList.OptionsView.ColumnAutoWidth = false;
            this.gridViewLeftList.OptionsView.ShowGroupPanel = false;
            this.gridViewLeftList.OptionsView.ShowIndicator = false;
            this.gridViewLeftList.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewLeftList_RowClick);
            this.gridViewLeftList.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridViewLeftList_CustomDrawCell);
            this.gridViewLeftList.DoubleClick += new System.EventHandler(this.gridViewLeftList_DoubleClick);
            // 
            // gridColumnId
            // 
            this.gridColumnId.Caption = "序";
            this.gridColumnId.FieldName = "ROWNUM";
            this.gridColumnId.Name = "gridColumnId";
            this.gridColumnId.OptionsColumn.AllowEdit = false;
            this.gridColumnId.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumnId.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnId.OptionsColumn.AllowMove = false;
            this.gridColumnId.OptionsFilter.AllowAutoFilter = false;
            this.gridColumnId.Visible = true;
            this.gridColumnId.VisibleIndex = 0;
            this.gridColumnId.Width = 35;
            // 
            // gridColumnRoom
            // 
            this.gridColumnRoom.Caption = "术间";
            this.gridColumnRoom.FieldName = "OPERATING_ROOM_NO";
            this.gridColumnRoom.Name = "gridColumnRoom";
            this.gridColumnRoom.OptionsColumn.AllowEdit = false;
            this.gridColumnRoom.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnRoom.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnRoom.Visible = true;
            this.gridColumnRoom.VisibleIndex = 1;
            this.gridColumnRoom.Width = 48;
            // 
            // gridColumnOutTime
            // 
            this.gridColumnOutTime.Caption = "手术时间";
            this.gridColumnOutTime.DisplayFormat.FormatString = "t";
            this.gridColumnOutTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumnOutTime.FieldName = "SCHEDULED_DATE_TIME";
            this.gridColumnOutTime.Name = "gridColumnOutTime";
            this.gridColumnOutTime.OptionsColumn.AllowEdit = false;
            this.gridColumnOutTime.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnOutTime.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnOutTime.OptionsFilter.AllowAutoFilter = false;
            this.gridColumnOutTime.OptionsFilter.AllowFilter = false;
            // 
            // gridColumnOperationSequence
            // 
            this.gridColumnOperationSequence.Caption = "台次";
            this.gridColumnOperationSequence.FieldName = "OPERATING_ROOM_NO_SEQUENCE";
            this.gridColumnOperationSequence.Name = "gridColumnOperationSequence";
            this.gridColumnOperationSequence.OptionsColumn.AllowEdit = false;
            this.gridColumnOperationSequence.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnOperationSequence.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnOperationSequence.OptionsFilter.AllowAutoFilter = false;
            this.gridColumnOperationSequence.OptionsFilter.AllowFilter = false;
            this.gridColumnOperationSequence.Visible = true;
            this.gridColumnOperationSequence.VisibleIndex = 2;
            this.gridColumnOperationSequence.Width = 40;
            // 
            // gridColumnAnesDoctor
            // 
            this.gridColumnAnesDoctor.Caption = "麻醉医师";
            this.gridColumnAnesDoctor.FieldName = "ANES_DOCTOR_NAME";
            this.gridColumnAnesDoctor.Name = "gridColumnAnesDoctor";
            this.gridColumnAnesDoctor.OptionsColumn.AllowEdit = false;
            this.gridColumnAnesDoctor.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnAnesDoctor.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnAnesDoctor.Visible = true;
            this.gridColumnAnesDoctor.VisibleIndex = 3;
            this.gridColumnAnesDoctor.Width = 70;
            // 
            // gridColumnAnesDoctor2
            // 
            this.gridColumnAnesDoctor2.Caption = "麻醉医师2";
            this.gridColumnAnesDoctor2.FieldName = "ANES_ASSISTANT";
            this.gridColumnAnesDoctor2.Name = "gridColumnAnesDoctor2";
            this.gridColumnAnesDoctor2.OptionsColumn.AllowEdit = false;
            this.gridColumnAnesDoctor2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnAnesDoctor2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnAnesDoctor2.Visible = true;
            this.gridColumnAnesDoctor2.VisibleIndex = 4;
            this.gridColumnAnesDoctor2.Width = 70;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "麻醉医师3";
            this.gridColumn3.FieldName = "ANES_ASSISTANT_NAME2";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn3.Width = 70;
            // 
            // gridColumnDept
            // 
            this.gridColumnDept.Caption = "科室";
            this.gridColumnDept.FieldName = "OPERATING_DEPT_NAME";
            this.gridColumnDept.Name = "gridColumnDept";
            this.gridColumnDept.OptionsColumn.AllowEdit = false;
            this.gridColumnDept.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnDept.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnDept.Visible = true;
            this.gridColumnDept.VisibleIndex = 5;
            this.gridColumnDept.Width = 100;
            // 
            // gridColumnBedNo
            // 
            this.gridColumnBedNo.Caption = "床号";
            this.gridColumnBedNo.FieldName = "BED_NO";
            this.gridColumnBedNo.Name = "gridColumnBedNo";
            this.gridColumnBedNo.OptionsColumn.AllowEdit = false;
            this.gridColumnBedNo.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnBedNo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnBedNo.OptionsFilter.AllowAutoFilter = false;
            this.gridColumnBedNo.OptionsFilter.AllowFilter = false;
            this.gridColumnBedNo.Visible = true;
            this.gridColumnBedNo.VisibleIndex = 6;
            this.gridColumnBedNo.Width = 45;
            // 
            // gridColumnPatName
            // 
            this.gridColumnPatName.Caption = "患者姓名";
            this.gridColumnPatName.FieldName = "PAT_NAME";
            this.gridColumnPatName.Name = "gridColumnPatName";
            this.gridColumnPatName.OptionsColumn.AllowEdit = false;
            this.gridColumnPatName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnPatName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnPatName.OptionsFilter.AllowAutoFilter = false;
            this.gridColumnPatName.OptionsFilter.AllowFilter = false;
            this.gridColumnPatName.Visible = true;
            this.gridColumnPatName.VisibleIndex = 7;
            this.gridColumnPatName.Width = 70;
            // 
            // gridColumnSex
            // 
            this.gridColumnSex.Caption = "性别";
            this.gridColumnSex.FieldName = "SEX";
            this.gridColumnSex.Name = "gridColumnSex";
            this.gridColumnSex.OptionsColumn.AllowEdit = false;
            this.gridColumnSex.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnSex.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnSex.OptionsFilter.AllowAutoFilter = false;
            this.gridColumnSex.OptionsFilter.AllowFilter = false;
            this.gridColumnSex.Visible = true;
            this.gridColumnSex.VisibleIndex = 8;
            this.gridColumnSex.Width = 42;
            // 
            // gridColumnAge
            // 
            this.gridColumnAge.Caption = "年龄";
            this.gridColumnAge.FieldName = "PAT_AGE";
            this.gridColumnAge.Name = "gridColumnAge";
            this.gridColumnAge.OptionsColumn.AllowEdit = false;
            this.gridColumnAge.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnAge.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnAge.OptionsFilter.AllowAutoFilter = false;
            this.gridColumnAge.OptionsFilter.AllowFilter = false;
            this.gridColumnAge.Visible = true;
            this.gridColumnAge.VisibleIndex = 9;
            this.gridColumnAge.Width = 42;
            // 
            // gridColumnPatID
            // 
            this.gridColumnPatID.Caption = "患者ID";
            this.gridColumnPatID.FieldName = "PAT_ID";
            this.gridColumnPatID.Name = "gridColumnPatID";
            this.gridColumnPatID.OptionsColumn.AllowEdit = false;
            this.gridColumnPatID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnPatID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnPatID.OptionsFilter.AllowAutoFilter = false;
            this.gridColumnPatID.OptionsFilter.AllowFilter = false;
            this.gridColumnPatID.Visible = true;
            this.gridColumnPatID.VisibleIndex = 10;
            this.gridColumnPatID.Width = 90;
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
            this.gridColumnInpno.VisibleIndex = 11;
            // 
            // gridColumnWardCode
            // 
            this.gridColumnWardCode.Caption = "诊断";
            this.gridColumnWardCode.FieldName = "DIAG_BEFORE_OPER";
            this.gridColumnWardCode.Name = "gridColumnWardCode";
            this.gridColumnWardCode.OptionsColumn.AllowEdit = false;
            this.gridColumnWardCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnWardCode.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnWardCode.Visible = true;
            this.gridColumnWardCode.VisibleIndex = 12;
            this.gridColumnWardCode.Width = 125;
            // 
            // gridColumnOperatoinName
            // 
            this.gridColumnOperatoinName.Caption = "手术名称";
            this.gridColumnOperatoinName.FieldName = "OPER_NAME";
            this.gridColumnOperatoinName.Name = "gridColumnOperatoinName";
            this.gridColumnOperatoinName.OptionsColumn.AllowEdit = false;
            this.gridColumnOperatoinName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnOperatoinName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnOperatoinName.Visible = true;
            this.gridColumnOperatoinName.VisibleIndex = 13;
            this.gridColumnOperatoinName.Width = 125;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "备注";
            this.gridColumn1.FieldName = "NOTES_ON_OPERATION";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn1.OptionsFilter.AllowFilter = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 14;
            this.gridColumn1.Width = 110;
            // 
            // gridColumnAnesMethod
            // 
            this.gridColumnAnesMethod.Caption = "麻醉方式";
            this.gridColumnAnesMethod.FieldName = "ANES_METHOD";
            this.gridColumnAnesMethod.Name = "gridColumnAnesMethod";
            this.gridColumnAnesMethod.OptionsColumn.AllowEdit = false;
            this.gridColumnAnesMethod.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnAnesMethod.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnAnesMethod.Visible = true;
            this.gridColumnAnesMethod.VisibleIndex = 15;
            // 
            // gridColumnOperationNurse
            // 
            this.gridColumnOperationNurse.Caption = "洗手护士";
            this.gridColumnOperationNurse.FieldName = "FIRST_OPER_NURSE_NAME";
            this.gridColumnOperationNurse.Name = "gridColumnOperationNurse";
            this.gridColumnOperationNurse.OptionsColumn.AllowEdit = false;
            this.gridColumnOperationNurse.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnOperationNurse.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnOperationNurse.Visible = true;
            this.gridColumnOperationNurse.VisibleIndex = 16;
            // 
            // gridColumnSupplyNurse
            // 
            this.gridColumnSupplyNurse.Caption = "巡回护士";
            this.gridColumnSupplyNurse.FieldName = "FIRST_SUPPLY_NURSE_NAME";
            this.gridColumnSupplyNurse.Name = "gridColumnSupplyNurse";
            this.gridColumnSupplyNurse.OptionsColumn.AllowEdit = false;
            this.gridColumnSupplyNurse.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnSupplyNurse.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnSupplyNurse.Visible = true;
            this.gridColumnSupplyNurse.VisibleIndex = 17;
            // 
            // gridColumnSurgeon
            // 
            this.gridColumnSurgeon.Caption = "手术医师";
            this.gridColumnSurgeon.FieldName = "SURGEON_NAME";
            this.gridColumnSurgeon.Name = "gridColumnSurgeon";
            this.gridColumnSurgeon.OptionsColumn.AllowEdit = false;
            this.gridColumnSurgeon.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnSurgeon.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnSurgeon.Visible = true;
            this.gridColumnSurgeon.VisibleIndex = 18;
            // 
            // gridColumnAssistant
            // 
            this.gridColumnAssistant.Caption = "手术助手";
            this.gridColumnAssistant.FieldName = "FIRST_ASSISTANT_NAME";
            this.gridColumnAssistant.Name = "gridColumnAssistant";
            this.gridColumnAssistant.OptionsColumn.AllowEdit = false;
            this.gridColumnAssistant.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnAssistant.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnAssistant.Visible = true;
            this.gridColumnAssistant.VisibleIndex = 19;
            this.gridColumnAssistant.Width = 120;
            // 
            // timerRefresh
            // 
            this.timerRefresh.Enabled = true;
            this.timerRefresh.Interval = 300000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // contextMenuStripInfo
            // 
            this.contextMenuStripInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuInfo});
            this.contextMenuStripInfo.Name = "contextMenuStripInfo";
            this.contextMenuStripInfo.Size = new System.Drawing.Size(149, 26);
            // 
            // menuInfo
            // 
            this.menuInfo.Name = "menuInfo";
            this.menuInfo.Size = new System.Drawing.Size(148, 22);
            this.menuInfo.Text = "查看患者信息";
            this.menuInfo.Click += new System.EventHandler(this.menuInfo_Click);
            // 
            // OperationSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScroll = true;
            this.Caption = "手术进程";
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.pnlBody);
            this.Name = "OperationSchedule";
            this.Size = new System.Drawing.Size(809, 363);
            this.Load += new System.EventHandler(this.OperationProcess_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimePickerQuery.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimePickerQuery.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherUse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLeftList)).EndInit();
            this.contextMenuStripInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlBody;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControlList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewLeftList;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAnesDoctor;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnOperationSequence;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnInpno;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPatName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSex;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAge;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDept;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnWardCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnBedNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnOperatoinName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnOutTime;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSurgeon;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAssistant;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAnesMethod;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnRoom;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnOperationNurse;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSupplyNurse;
        private System.Windows.Forms.Timer timerRefresh;
        private DevExpress.XtraEditors.RadioGroup radioType;
        private DevExpress.XtraEditors.LabelControl labelControlName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPatID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAnesDoctor2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private Wis.Anes.Framework.Controls.DictTextBox txtOtherUse;
        private DevExpress.XtraEditors.DateEdit dateTimePickerQuery;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnId;
        private DevExpress.XtraEditors.SimpleButton btnHisInfo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripInfo;
        private System.Windows.Forms.ToolStripMenuItem menuInfo;

    }
}
