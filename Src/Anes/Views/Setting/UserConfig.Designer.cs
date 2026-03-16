using DevExpress.XtraEditors.Controls;
using Wis.Anes.Views.Setting.CurstomGridView;

namespace Wis.Anes.Views
{
    partial class UserConfig
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
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnPDFSet = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox4 = new DevExpress.XtraEditors.GroupControl();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.txtOpertionRoom = new Wis.Anes.Framework.Controls.MedTextBox();
            this.label = new DevExpress.XtraEditors.LabelControl();
            this.chkCanRunManey = new DevExpress.XtraEditors.CheckEdit();
            this.label13 = new DevExpress.XtraEditors.LabelControl();
            this.txtButtonsCount = new Wis.Anes.Framework.Controls.MedTextBox();
            this.panel2 = new DevExpress.XtraEditors.PanelControl();
            this.txtModifyDays = new Wis.Anes.Framework.Controls.MedTextBox();
            this.label6 = new DevExpress.XtraEditors.LabelControl();
            this.txtNoDosage = new Wis.Anes.Framework.Controls.MedTextBox();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.tabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.numericUpDownOperDone = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDownSync = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.cmbDrugStopOperationStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.chkDrugAutoStop = new DevExpress.XtraEditors.CheckEdit();
            this.chkIsModifyMonitorSetting = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.radioGroupSyncScheduleInfo = new DevExpress.XtraEditors.RadioGroup();
            this.chkModifyVitalSignShowDifferent = new DevExpress.XtraEditors.CheckEdit();
            this.chkUseDefaultSelectedMonitorLabel = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cmbDrugShow = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cmbProLonged = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtAnesthesiaNumber = new Wis.Anes.Framework.Controls.MedTextBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.chkDoubleSelect = new DevExpress.XtraEditors.CheckEdit();
            this.txtAnesthesiaWardCode = new Wis.Anes.Framework.Controls.MedTextBox();
            this.txtWardCode = new Wis.Anes.Framework.Controls.MedTextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.chkPromptBeforeExit = new DevExpress.XtraEditors.CheckEdit();
            this.tabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.btnAddInoperationButton = new Wis.Anes.Framework.Controls.MedButton();
            this.dataGridView1 = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.dataGridView2 = new DevExpress.XtraGrid.GridControl();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.dataGridView3 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BLG_STATUS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.BLG_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BLG_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BLG_UNIT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.btnDeleteItem = new Wis.Anes.Framework.Controls.MedButton();
            this.btnAddItem = new Wis.Anes.Framework.Controls.MedButton();
            this.gridControlMonitor = new DevExpress.XtraGrid.GridControl();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.DB_DATA_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MONITOR_DATA_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LOW_SIGNS_VALUES = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HIGH_SIGNS_VALUES = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.btnOutListAdd = new Wis.Anes.Framework.Controls.MedButton();
            this.dataGridViewOutList = new DevExpress.XtraGrid.GridControl();
            this.gridViewOutList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabpageBillCfg = new DevExpress.XtraTab.XtraTabPage();
            this.medButtonAddBillCfg = new Wis.Anes.Framework.Controls.MedButton();
            this.gridBillCfg = new Wis.Anes.Views.Setting.CurstomGridView.CustomGridView();
            this.gridView7 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPDFLocalUrl = new Wis.Anes.Framework.Controls.MedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPDFServerUrl = new Wis.Anes.Framework.Controls.MedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chkUpFileList = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.chkDeleteAfterCommitDoc = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.medTextBoxPaperTopOff = new Wis.Anes.Framework.Controls.MedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.medTextBoxPaperLeftOff = new Wis.Anes.Framework.Controls.MedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.medTextBoxPaperWidth = new Wis.Anes.Framework.Controls.MedTextBox();
            this.medTextBoxPaperHeight = new Wis.Anes.Framework.Controls.MedTextBox();
            this.medTextBoxPageName = new Wis.Anes.Framework.Controls.MedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.xtraTabPage5 = new DevExpress.XtraTab.XtraTabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.chkDocCheckList = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.medPanel1 = new Wis.Anes.Framework.Controls.MedPanel();
            this.medLabel1 = new Wis.Anes.Framework.Controls.MedLabel();
            this.medPanel2 = new Wis.Anes.Framework.Controls.MedPanel();
            this.btnSuperConfig = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox4)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOpertionRoom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCanRunManey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtButtonsCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtModifyDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoDosage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOperDone)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSync)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDrugStopOperationStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDrugAutoStop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsModifyMonitorSetting.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupSyncScheduleInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkModifyVitalSignShowDifferent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUseDefaultSelectedMonitorLabel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDrugShow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProLonged.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnesthesiaNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDoubleSelect.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnesthesiaWardCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWardCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPromptBeforeExit.Properties)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMonitor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOutList)).BeginInit();
            this.tabpageBillCfg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBillCfg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).BeginInit();
            this.xtraTabPage4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPDFLocalUrl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPDFServerUrl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUpFileList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDeleteAfterCommitDoc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medTextBoxPaperTopOff.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medTextBoxPaperLeftOff.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medTextBoxPaperWidth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medTextBoxPaperHeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medTextBoxPageName.Properties)).BeginInit();
            this.xtraTabPage5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkDocCheckList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medPanel1)).BeginInit();
            this.medPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.medPanel2)).BeginInit();
            this.medPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(639, 10);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 37);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "取消";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(514, 10);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(115, 37);
            this.btnOK.TabIndex = 28;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnPDFSet
            // 
            this.btnPDFSet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPDFSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPDFSet.Location = new System.Drawing.Point(14, 26);
            this.btnPDFSet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPDFSet.Name = "btnPDFSet";
            this.btnPDFSet.Size = new System.Drawing.Size(87, 35);
            this.btnPDFSet.TabIndex = 30;
            this.btnPDFSet.Text = "PDF设置";
            this.btnPDFSet.Visible = false;
            this.btnPDFSet.Click += new System.EventHandler(this.btnPDFSet_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnPDFSet);
            this.groupBox4.Location = new System.Drawing.Point(19, 57);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(113, 78);
            this.groupBox4.TabIndex = 31;
            this.groupBox4.Text = "PDF设置";
            this.groupBox4.Visible = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(78, 31);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 18);
            this.label3.TabIndex = 32;
            this.label3.Text = "默认手术间";
            // 
            // txtOpertionRoom
            // 
            this.txtOpertionRoom.BindFieldName = "";
            this.txtOpertionRoom.BindList = "";
            this.txtOpertionRoom.BindTableName = "";
            this.txtOpertionRoom.BorderColor = System.Drawing.Color.LightGray;
            this.txtOpertionRoom.BottomLine = false;
            this.txtOpertionRoom.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtOpertionRoom.CanEdit = true;
            this.txtOpertionRoom.CelerityInputCodeColumnName = "";
            this.txtOpertionRoom.CelerityInputSqlWhere = "";
            this.txtOpertionRoom.CelerityInputTableName = "";
            this.txtOpertionRoom.CelerityInputValueColumnName = "";
            this.txtOpertionRoom.Data = null;
            this.txtOpertionRoom.DefaultPrintText = "";
            this.txtOpertionRoom.DictTableName = "";
            this.txtOpertionRoom.DictValueFieldName = "";
            this.txtOpertionRoom.DictWhereString = "";
            this.txtOpertionRoom.DisplayFieldName = "";
            this.txtOpertionRoom.DisplayMutiColFieldName = "";
            this.txtOpertionRoom.DotBorder = false;
            this.txtOpertionRoom.DotNumber = 0;
            this.txtOpertionRoom.ExamItemName = null;
            this.txtOpertionRoom.FieldName = "txtOpertionRoom";
            this.txtOpertionRoom.Format = "";
            this.txtOpertionRoom.HasLookUpItems = false;
            this.txtOpertionRoom.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtOpertionRoom.InitValue = "";
            this.txtOpertionRoom.InputNeededMessage = "";
            this.txtOpertionRoom.InputType = Wis.Anes.Framework.Controls.MedInputType.String;
            this.txtOpertionRoom.LabItemName = null;
            this.txtOpertionRoom.LimitedString = "~!@#$%^&*()?<>\":";
            this.txtOpertionRoom.Location = new System.Drawing.Point(160, 27);
            this.txtOpertionRoom.LockInput = false;
            this.txtOpertionRoom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOpertionRoom.Maximum = "50";
            this.txtOpertionRoom.MaxLength = 8;
            this.txtOpertionRoom.Minimum = "1";
            this.txtOpertionRoom.Multiline = false;
            this.txtOpertionRoom.MultiSelect = false;
            this.txtOpertionRoom.MultiSign = false;
            this.txtOpertionRoom.Name = "txtOpertionRoom";
            this.txtOpertionRoom.NoPrint = false;
            this.txtOpertionRoom.NoPrintText = "";
            this.txtOpertionRoom.NullAble = true;
            this.txtOpertionRoom.OldForeColor = System.Drawing.Color.Black;
            this.txtOpertionRoom.PasswordChar = '\0';
            this.txtOpertionRoom.PrintTail = "";
            this.txtOpertionRoom.PrintXOffSet = 0F;
            this.txtOpertionRoom.PrintYOffSet = 0F;
            this.txtOpertionRoom.ProgramChanging = false;
            this.txtOpertionRoom.Properties.Appearance.Options.UseTextOptions = true;
            this.txtOpertionRoom.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtOpertionRoom.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtOpertionRoom.Properties.MaxLength = 8;
            this.txtOpertionRoom.SelfValue = "";
            this.txtOpertionRoom.SelfValueChanged = false;
            this.txtOpertionRoom.Size = new System.Drawing.Size(191, 24);
            this.txtOpertionRoom.SourceFieldName = "";
            this.txtOpertionRoom.SourceTableName = "";
            this.txtOpertionRoom.StoredValue = "";
            this.txtOpertionRoom.TabIndex = 33;
            this.txtOpertionRoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtOpertionRoom.UnderLineOffset = 0F;
            this.txtOpertionRoom.WantValueBeforePrint = "";
            this.txtOpertionRoom.WordWrap = false;
            this.txtOpertionRoom.Click += new System.EventHandler(this.txtOpertionRoom_Click);
            this.txtOpertionRoom.DoubleClick += new System.EventHandler(this.txtOpertionRoom_DoubleClick);
            // 
            // label
            // 
            this.label.Location = new System.Drawing.Point(78, 139);
            this.label.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(75, 18);
            this.label.TabIndex = 36;
            this.label.Text = "麻醉科代码";
            // 
            // chkCanRunManey
            // 
            this.chkCanRunManey.Location = new System.Drawing.Point(363, 57);
            this.chkCanRunManey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkCanRunManey.Name = "chkCanRunManey";
            this.chkCanRunManey.Properties.Caption = "可多实例运行";
            this.chkCanRunManey.Size = new System.Drawing.Size(128, 22);
            this.chkCanRunManey.TabIndex = 35;
            this.chkCanRunManey.Visible = false;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(530, 64);
            this.label13.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 18);
            this.label13.TabIndex = 32;
            this.label13.Text = "常用量按钮个数";
            this.label13.Visible = false;
            // 
            // txtButtonsCount
            // 
            this.txtButtonsCount.BindFieldName = "";
            this.txtButtonsCount.BindList = "";
            this.txtButtonsCount.BindTableName = "";
            this.txtButtonsCount.BorderColor = System.Drawing.Color.LightGray;
            this.txtButtonsCount.BottomLine = false;
            this.txtButtonsCount.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtButtonsCount.CanEdit = true;
            this.txtButtonsCount.CelerityInputCodeColumnName = "";
            this.txtButtonsCount.CelerityInputSqlWhere = "";
            this.txtButtonsCount.CelerityInputTableName = "";
            this.txtButtonsCount.CelerityInputValueColumnName = "";
            this.txtButtonsCount.Data = null;
            this.txtButtonsCount.DefaultPrintText = "";
            this.txtButtonsCount.DictTableName = "";
            this.txtButtonsCount.DictValueFieldName = "";
            this.txtButtonsCount.DictWhereString = "";
            this.txtButtonsCount.DisplayFieldName = "";
            this.txtButtonsCount.DisplayMutiColFieldName = "";
            this.txtButtonsCount.DotBorder = false;
            this.txtButtonsCount.DotNumber = 0;
            this.txtButtonsCount.ExamItemName = null;
            this.txtButtonsCount.FieldName = "txtButtonsCount";
            this.txtButtonsCount.Format = "";
            this.txtButtonsCount.HasLookUpItems = false;
            this.txtButtonsCount.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtButtonsCount.InitValue = "";
            this.txtButtonsCount.InputNeededMessage = "";
            this.txtButtonsCount.InputType = Wis.Anes.Framework.Controls.MedInputType.Integer;
            this.txtButtonsCount.LabItemName = null;
            this.txtButtonsCount.LimitedString = "~!@#$%^&*()?<>\":";
            this.txtButtonsCount.Location = new System.Drawing.Point(650, 60);
            this.txtButtonsCount.LockInput = false;
            this.txtButtonsCount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtButtonsCount.Maximum = null;
            this.txtButtonsCount.MaxLength = 0;
            this.txtButtonsCount.Minimum = null;
            this.txtButtonsCount.Multiline = false;
            this.txtButtonsCount.MultiSelect = false;
            this.txtButtonsCount.MultiSign = false;
            this.txtButtonsCount.Name = "txtButtonsCount";
            this.txtButtonsCount.NoPrint = false;
            this.txtButtonsCount.NoPrintText = "";
            this.txtButtonsCount.NullAble = true;
            this.txtButtonsCount.OldForeColor = System.Drawing.Color.Black;
            this.txtButtonsCount.PasswordChar = '\0';
            this.txtButtonsCount.PrintTail = "";
            this.txtButtonsCount.PrintXOffSet = 0F;
            this.txtButtonsCount.PrintYOffSet = 0F;
            this.txtButtonsCount.ProgramChanging = false;
            this.txtButtonsCount.Properties.Appearance.Options.UseTextOptions = true;
            this.txtButtonsCount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtButtonsCount.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtButtonsCount.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtButtonsCount.SelfValue = "";
            this.txtButtonsCount.SelfValueChanged = false;
            this.txtButtonsCount.Size = new System.Drawing.Size(54, 24);
            this.txtButtonsCount.SourceFieldName = "";
            this.txtButtonsCount.SourceTableName = "";
            this.txtButtonsCount.StoredValue = "";
            this.txtButtonsCount.TabIndex = 33;
            this.txtButtonsCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtButtonsCount.UnderLineOffset = 0F;
            this.txtButtonsCount.Visible = false;
            this.txtButtonsCount.WantValueBeforePrint = "";
            this.txtButtonsCount.WordWrap = false;
            this.txtButtonsCount.Click += new System.EventHandler(this.txtOpertionRoom_Click);
            this.txtButtonsCount.DoubleClick += new System.EventHandler(this.txtOpertionRoom_DoubleClick);
            this.txtButtonsCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtModifyDays);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtNoDosage);
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.chkCanRunManey);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.txtButtonsCount);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 592);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(770, 111);
            this.panel2.TabIndex = 39;
            this.panel2.Visible = false;
            // 
            // txtModifyDays
            // 
            this.txtModifyDays.BindFieldName = "";
            this.txtModifyDays.BindList = "";
            this.txtModifyDays.BindTableName = "";
            this.txtModifyDays.BorderColor = System.Drawing.Color.LightGray;
            this.txtModifyDays.BottomLine = false;
            this.txtModifyDays.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtModifyDays.CanEdit = true;
            this.txtModifyDays.CelerityInputCodeColumnName = "";
            this.txtModifyDays.CelerityInputSqlWhere = "";
            this.txtModifyDays.CelerityInputTableName = "";
            this.txtModifyDays.CelerityInputValueColumnName = "";
            this.txtModifyDays.Data = null;
            this.txtModifyDays.DefaultPrintText = "";
            this.txtModifyDays.DictTableName = "";
            this.txtModifyDays.DictValueFieldName = "";
            this.txtModifyDays.DictWhereString = "";
            this.txtModifyDays.DisplayFieldName = "";
            this.txtModifyDays.DisplayMutiColFieldName = "";
            this.txtModifyDays.DotBorder = false;
            this.txtModifyDays.DotNumber = 0;
            this.txtModifyDays.ExamItemName = null;
            this.txtModifyDays.FieldName = "txtModifyDays";
            this.txtModifyDays.Format = "";
            this.txtModifyDays.HasLookUpItems = false;
            this.txtModifyDays.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtModifyDays.InitValue = "";
            this.txtModifyDays.InputNeededMessage = "";
            this.txtModifyDays.InputType = Wis.Anes.Framework.Controls.MedInputType.Integer;
            this.txtModifyDays.LabItemName = null;
            this.txtModifyDays.LimitedString = "";
            this.txtModifyDays.Location = new System.Drawing.Point(107, 17);
            this.txtModifyDays.LockInput = false;
            this.txtModifyDays.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtModifyDays.Maximum = "20";
            this.txtModifyDays.MaxLength = 0;
            this.txtModifyDays.Minimum = "1";
            this.txtModifyDays.Multiline = false;
            this.txtModifyDays.MultiSelect = false;
            this.txtModifyDays.MultiSign = false;
            this.txtModifyDays.Name = "txtModifyDays";
            this.txtModifyDays.NoPrint = false;
            this.txtModifyDays.NoPrintText = "";
            this.txtModifyDays.NullAble = true;
            this.txtModifyDays.OldForeColor = System.Drawing.Color.Black;
            this.txtModifyDays.PasswordChar = '\0';
            this.txtModifyDays.PrintTail = "";
            this.txtModifyDays.PrintXOffSet = 0F;
            this.txtModifyDays.PrintYOffSet = 0F;
            this.txtModifyDays.ProgramChanging = false;
            this.txtModifyDays.Properties.Appearance.Options.UseTextOptions = true;
            this.txtModifyDays.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtModifyDays.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtModifyDays.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtModifyDays.SelfValue = "";
            this.txtModifyDays.SelfValueChanged = false;
            this.txtModifyDays.Size = new System.Drawing.Size(91, 24);
            this.txtModifyDays.SourceFieldName = "";
            this.txtModifyDays.SourceTableName = "";
            this.txtModifyDays.StoredValue = "";
            this.txtModifyDays.TabIndex = 38;
            this.txtModifyDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtModifyDays.UnderLineOffset = 0F;
            this.txtModifyDays.WantValueBeforePrint = "";
            this.txtModifyDays.WordWrap = false;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(19, 19);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 18);
            this.label6.TabIndex = 39;
            this.label6.Text = "可修改天数";
            // 
            // txtNoDosage
            // 
            this.txtNoDosage.BindFieldName = "";
            this.txtNoDosage.BindList = "";
            this.txtNoDosage.BindTableName = "";
            this.txtNoDosage.BorderColor = System.Drawing.Color.LightGray;
            this.txtNoDosage.BottomLine = false;
            this.txtNoDosage.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtNoDosage.CanEdit = true;
            this.txtNoDosage.CelerityInputCodeColumnName = "";
            this.txtNoDosage.CelerityInputSqlWhere = "";
            this.txtNoDosage.CelerityInputTableName = "";
            this.txtNoDosage.CelerityInputValueColumnName = "";
            this.txtNoDosage.Data = null;
            this.txtNoDosage.DefaultPrintText = "";
            this.txtNoDosage.DictTableName = "";
            this.txtNoDosage.DictValueFieldName = "";
            this.txtNoDosage.DictWhereString = "";
            this.txtNoDosage.DisplayFieldName = "";
            this.txtNoDosage.DisplayMutiColFieldName = "";
            this.txtNoDosage.DotBorder = false;
            this.txtNoDosage.DotNumber = 0;
            this.txtNoDosage.ExamItemName = null;
            this.txtNoDosage.FieldName = "txtNoDosage";
            this.txtNoDosage.Format = "";
            this.txtNoDosage.HasLookUpItems = false;
            this.txtNoDosage.InitValue = "";
            this.txtNoDosage.InputNeededMessage = "";
            this.txtNoDosage.InputType = Wis.Anes.Framework.Controls.MedInputType.General;
            this.txtNoDosage.LabItemName = null;
            this.txtNoDosage.LimitedString = "~!@#$%^&?<>\"";
            this.txtNoDosage.Location = new System.Drawing.Point(346, 15);
            this.txtNoDosage.LockInput = false;
            this.txtNoDosage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNoDosage.Maximum = null;
            this.txtNoDosage.MaxLength = 0;
            this.txtNoDosage.Minimum = null;
            this.txtNoDosage.Multiline = false;
            this.txtNoDosage.MultiSelect = false;
            this.txtNoDosage.MultiSign = false;
            this.txtNoDosage.Name = "txtNoDosage";
            this.txtNoDosage.NoPrint = false;
            this.txtNoDosage.NoPrintText = "";
            this.txtNoDosage.NullAble = true;
            this.txtNoDosage.OldForeColor = System.Drawing.Color.Black;
            this.txtNoDosage.PasswordChar = '\0';
            this.txtNoDosage.PrintTail = "";
            this.txtNoDosage.PrintXOffSet = 0F;
            this.txtNoDosage.PrintYOffSet = 0F;
            this.txtNoDosage.ProgramChanging = false;
            this.txtNoDosage.Properties.Appearance.Options.UseTextOptions = true;
            this.txtNoDosage.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtNoDosage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtNoDosage.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtNoDosage.SelfValue = "";
            this.txtNoDosage.SelfValueChanged = false;
            this.txtNoDosage.Size = new System.Drawing.Size(385, 24);
            this.txtNoDosage.SourceFieldName = "";
            this.txtNoDosage.SourceTableName = "";
            this.txtNoDosage.StoredValue = "";
            this.txtNoDosage.TabIndex = 37;
            this.txtNoDosage.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNoDosage.UnderLineOffset = 0F;
            this.txtNoDosage.WantValueBeforePrint = "";
            this.txtNoDosage.WordWrap = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(208, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 18);
            this.label1.TabIndex = 36;
            this.label1.Text = "不用输入剂量名称";
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 51);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabPage = this.xtraTabPage1;
            this.tabControl1.Size = new System.Drawing.Size(777, 739);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.tabPage1,
            this.tabPage2,
            this.tabPage3,
            this.xtraTabPage2,
            this.xtraTabPage3,
            this.tabpageBillCfg,
            this.xtraTabPage4,
            this.xtraTabPage5});
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.panel3);
            this.xtraTabPage1.Controls.Add(this.panel1);
            this.xtraTabPage1.Controls.Add(this.groupBox1);
            this.xtraTabPage1.Controls.Add(this.chkIsModifyMonitorSetting);
            this.xtraTabPage1.Controls.Add(this.labelControl5);
            this.xtraTabPage1.Controls.Add(this.radioGroupSyncScheduleInfo);
            this.xtraTabPage1.Controls.Add(this.chkModifyVitalSignShowDifferent);
            this.xtraTabPage1.Controls.Add(this.chkUseDefaultSelectedMonitorLabel);
            this.xtraTabPage1.Controls.Add(this.labelControl4);
            this.xtraTabPage1.Controls.Add(this.cmbDrugShow);
            this.xtraTabPage1.Controls.Add(this.labelControl3);
            this.xtraTabPage1.Controls.Add(this.cmbProLonged);
            this.xtraTabPage1.Controls.Add(this.txtAnesthesiaNumber);
            this.xtraTabPage1.Controls.Add(this.labelControl2);
            this.xtraTabPage1.Controls.Add(this.chkDoubleSelect);
            this.xtraTabPage1.Controls.Add(this.txtAnesthesiaWardCode);
            this.xtraTabPage1.Controls.Add(this.txtWardCode);
            this.xtraTabPage1.Controls.Add(this.labelControl1);
            this.xtraTabPage1.Controls.Add(this.chkPromptBeforeExit);
            this.xtraTabPage1.Controls.Add(this.label);
            this.xtraTabPage1.Controls.Add(this.label3);
            this.xtraTabPage1.Controls.Add(this.panel2);
            this.xtraTabPage1.Controls.Add(this.txtOpertionRoom);
            this.xtraTabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(770, 703);
            this.xtraTabPage1.Text = "常规";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.numericUpDownOperDone);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Location = new System.Drawing.Point(159, 446);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(192, 42);
            this.panel3.TabIndex = 67;
            // 
            // numericUpDownOperDone
            // 
            this.numericUpDownOperDone.Location = new System.Drawing.Point(83, 6);
            this.numericUpDownOperDone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDownOperDone.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.numericUpDownOperDone.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownOperDone.Name = "numericUpDownOperDone";
            this.numericUpDownOperDone.Size = new System.Drawing.Size(41, 26);
            this.numericUpDownOperDone.TabIndex = 64;
            this.numericUpDownOperDone.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(14, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 18);
            this.label15.TabIndex = 66;
            this.label15.Text = "归档间隔";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(131, 10);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(23, 18);
            this.label17.TabIndex = 65;
            this.label17.Text = "天";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numericUpDownSync);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Location = new System.Drawing.Point(160, 396);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(192, 42);
            this.panel1.TabIndex = 67;
            // 
            // numericUpDownSync
            // 
            this.numericUpDownSync.Location = new System.Drawing.Point(83, 6);
            this.numericUpDownSync.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDownSync.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.numericUpDownSync.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSync.Name = "numericUpDownSync";
            this.numericUpDownSync.Size = new System.Drawing.Size(41, 26);
            this.numericUpDownSync.TabIndex = 64;
            this.numericUpDownSync.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 18);
            this.label14.TabIndex = 66;
            this.label14.Text = "同步间隔";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(131, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 18);
            this.label12.TabIndex = 65;
            this.label12.Text = "天";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelControl6);
            this.groupBox1.Controls.Add(this.cmbDrugStopOperationStatus);
            this.groupBox1.Controls.Add(this.chkDrugAutoStop);
            this.groupBox1.Location = new System.Drawing.Point(398, 59);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(354, 135);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "持续用药自动结束设置";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(29, 58);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(135, 18);
            this.labelControl6.TabIndex = 64;
            this.labelControl6.Text = "自动结束时手术状态";
            // 
            // cmbDrugStopOperationStatus
            // 
            this.cmbDrugStopOperationStatus.EditValue = "出手术室";
            this.cmbDrugStopOperationStatus.Location = new System.Drawing.Point(29, 84);
            this.cmbDrugStopOperationStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbDrugStopOperationStatus.Name = "cmbDrugStopOperationStatus";
            this.cmbDrugStopOperationStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDrugStopOperationStatus.Properties.Items.AddRange(new object[] {
            "手术结束",
            "麻醉结束",
            "出手术室"});
            this.cmbDrugStopOperationStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbDrugStopOperationStatus.Size = new System.Drawing.Size(152, 24);
            this.cmbDrugStopOperationStatus.TabIndex = 63;
            // 
            // chkDrugAutoStop
            // 
            this.chkDrugAutoStop.Location = new System.Drawing.Point(26, 26);
            this.chkDrugAutoStop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkDrugAutoStop.Name = "chkDrugAutoStop";
            this.chkDrugAutoStop.Properties.Caption = "持续用药自动结束";
            this.chkDrugAutoStop.Size = new System.Drawing.Size(249, 22);
            this.chkDrugAutoStop.TabIndex = 62;
            this.chkDrugAutoStop.CheckedChanged += new System.EventHandler(this.chkDrugAutoStop_CheckedChanged);
            // 
            // chkIsModifyMonitorSetting
            // 
            this.chkIsModifyMonitorSetting.Location = new System.Drawing.Point(394, 27);
            this.chkIsModifyMonitorSetting.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkIsModifyMonitorSetting.Name = "chkIsModifyMonitorSetting";
            this.chkIsModifyMonitorSetting.Properties.Caption = "同时修改采集床号配置";
            this.chkIsModifyMonitorSetting.Size = new System.Drawing.Size(207, 22);
            this.chkIsModifyMonitorSetting.TabIndex = 61;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(9, 355);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(150, 18);
            this.labelControl5.TabIndex = 60;
            this.labelControl5.Text = "同步手术申请信息方式";
            // 
            // radioGroupSyncScheduleInfo
            // 
            this.radioGroupSyncScheduleInfo.Location = new System.Drawing.Point(160, 351);
            this.radioGroupSyncScheduleInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioGroupSyncScheduleInfo.Name = "radioGroupSyncScheduleInfo";
            this.radioGroupSyncScheduleInfo.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroupSyncScheduleInfo.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroupSyncScheduleInfo.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "按科室"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "按时间")});
            this.radioGroupSyncScheduleInfo.Size = new System.Drawing.Size(191, 37);
            this.radioGroupSyncScheduleInfo.TabIndex = 59;
            // 
            // chkModifyVitalSignShowDifferent
            // 
            this.chkModifyVitalSignShowDifferent.Location = new System.Drawing.Point(291, 549);
            this.chkModifyVitalSignShowDifferent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkModifyVitalSignShowDifferent.Name = "chkModifyVitalSignShowDifferent";
            this.chkModifyVitalSignShowDifferent.Properties.Caption = "标记修改过的体征项";
            this.chkModifyVitalSignShowDifferent.Size = new System.Drawing.Size(249, 22);
            this.chkModifyVitalSignShowDifferent.TabIndex = 58;
            // 
            // chkUseDefaultSelectedMonitorLabel
            // 
            this.chkUseDefaultSelectedMonitorLabel.Location = new System.Drawing.Point(291, 517);
            this.chkUseDefaultSelectedMonitorLabel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkUseDefaultSelectedMonitorLabel.Name = "chkUseDefaultSelectedMonitorLabel";
            this.chkUseDefaultSelectedMonitorLabel.Properties.Caption = "选择默认监护仪";
            this.chkUseDefaultSelectedMonitorLabel.Size = new System.Drawing.Size(249, 22);
            this.chkUseDefaultSelectedMonitorLabel.TabIndex = 57;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(37, 301);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(120, 18);
            this.labelControl4.TabIndex = 56;
            this.labelControl4.Text = "单次用药显示格式";
            // 
            // cmbDrugShow
            // 
            this.cmbDrugShow.Location = new System.Drawing.Point(160, 297);
            this.cmbDrugShow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbDrugShow.Name = "cmbDrugShow";
            this.cmbDrugShow.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDrugShow.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbDrugShow.Size = new System.Drawing.Size(192, 24);
            this.cmbDrugShow.TabIndex = 55;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(37, 247);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(120, 18);
            this.labelControl3.TabIndex = 54;
            this.labelControl3.Text = "持续用药显示格式";
            // 
            // cmbProLonged
            // 
            this.cmbProLonged.Location = new System.Drawing.Point(160, 243);
            this.cmbProLonged.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbProLonged.Name = "cmbProLonged";
            this.cmbProLonged.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbProLonged.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbProLonged.Size = new System.Drawing.Size(192, 24);
            this.cmbProLonged.TabIndex = 53;
            // 
            // txtAnesthesiaNumber
            // 
            this.txtAnesthesiaNumber.BindFieldName = "";
            this.txtAnesthesiaNumber.BindList = "";
            this.txtAnesthesiaNumber.BindTableName = "";
            this.txtAnesthesiaNumber.BorderColor = System.Drawing.Color.LightGray;
            this.txtAnesthesiaNumber.BottomLine = false;
            this.txtAnesthesiaNumber.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtAnesthesiaNumber.CanEdit = true;
            this.txtAnesthesiaNumber.CelerityInputCodeColumnName = "";
            this.txtAnesthesiaNumber.CelerityInputSqlWhere = "";
            this.txtAnesthesiaNumber.CelerityInputTableName = "";
            this.txtAnesthesiaNumber.CelerityInputValueColumnName = "";
            this.txtAnesthesiaNumber.Data = null;
            this.txtAnesthesiaNumber.DefaultPrintText = "";
            this.txtAnesthesiaNumber.DictTableName = "";
            this.txtAnesthesiaNumber.DictValueFieldName = "";
            this.txtAnesthesiaNumber.DictWhereString = "";
            this.txtAnesthesiaNumber.DisplayFieldName = "";
            this.txtAnesthesiaNumber.DisplayMutiColFieldName = "";
            this.txtAnesthesiaNumber.DotBorder = false;
            this.txtAnesthesiaNumber.DotNumber = 0;
            this.txtAnesthesiaNumber.ExamItemName = null;
            this.txtAnesthesiaNumber.FieldName = "txtOpertionRoom";
            this.txtAnesthesiaNumber.Format = "";
            this.txtAnesthesiaNumber.HasLookUpItems = false;
            this.txtAnesthesiaNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtAnesthesiaNumber.InitValue = "";
            this.txtAnesthesiaNumber.InputNeededMessage = "";
            this.txtAnesthesiaNumber.InputType = Wis.Anes.Framework.Controls.MedInputType.String;
            this.txtAnesthesiaNumber.LabItemName = null;
            this.txtAnesthesiaNumber.LimitedString = "~!@#$%^&*()?<>\":";
            this.txtAnesthesiaNumber.Location = new System.Drawing.Point(160, 189);
            this.txtAnesthesiaNumber.LockInput = false;
            this.txtAnesthesiaNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAnesthesiaNumber.Maximum = "";
            this.txtAnesthesiaNumber.MaxLength = 8;
            this.txtAnesthesiaNumber.Minimum = "";
            this.txtAnesthesiaNumber.Multiline = false;
            this.txtAnesthesiaNumber.MultiSelect = false;
            this.txtAnesthesiaNumber.MultiSign = false;
            this.txtAnesthesiaNumber.Name = "txtAnesthesiaNumber";
            this.txtAnesthesiaNumber.NoPrint = false;
            this.txtAnesthesiaNumber.NoPrintText = "";
            this.txtAnesthesiaNumber.NullAble = true;
            this.txtAnesthesiaNumber.OldForeColor = System.Drawing.Color.Black;
            this.txtAnesthesiaNumber.PasswordChar = '\0';
            this.txtAnesthesiaNumber.PrintTail = "";
            this.txtAnesthesiaNumber.PrintXOffSet = 0F;
            this.txtAnesthesiaNumber.PrintYOffSet = 0F;
            this.txtAnesthesiaNumber.ProgramChanging = false;
            this.txtAnesthesiaNumber.Properties.Appearance.Options.UseTextOptions = true;
            this.txtAnesthesiaNumber.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtAnesthesiaNumber.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtAnesthesiaNumber.Properties.MaxLength = 8;
            this.txtAnesthesiaNumber.SelfValue = "";
            this.txtAnesthesiaNumber.SelfValueChanged = false;
            this.txtAnesthesiaNumber.Size = new System.Drawing.Size(191, 24);
            this.txtAnesthesiaNumber.SourceFieldName = "";
            this.txtAnesthesiaNumber.SourceTableName = "";
            this.txtAnesthesiaNumber.StoredValue = "";
            this.txtAnesthesiaNumber.TabIndex = 52;
            this.txtAnesthesiaNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAnesthesiaNumber.UnderLineOffset = 0F;
            this.txtAnesthesiaNumber.WantValueBeforePrint = "";
            this.txtAnesthesiaNumber.WordWrap = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(91, 193);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 18);
            this.labelControl2.TabIndex = 51;
            this.labelControl2.Text = "麻醉编号";
            // 
            // chkDoubleSelect
            // 
            this.chkDoubleSelect.Location = new System.Drawing.Point(23, 517);
            this.chkDoubleSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkDoubleSelect.Name = "chkDoubleSelect";
            this.chkDoubleSelect.Properties.Caption = "医疗文书双击弹出下拉选择框";
            this.chkDoubleSelect.Size = new System.Drawing.Size(249, 22);
            this.chkDoubleSelect.TabIndex = 50;
            // 
            // txtAnesthesiaWardCode
            // 
            this.txtAnesthesiaWardCode.BindFieldName = "";
            this.txtAnesthesiaWardCode.BindList = "";
            this.txtAnesthesiaWardCode.BindTableName = "";
            this.txtAnesthesiaWardCode.BorderColor = System.Drawing.Color.LightGray;
            this.txtAnesthesiaWardCode.BottomLine = false;
            this.txtAnesthesiaWardCode.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtAnesthesiaWardCode.CanEdit = true;
            this.txtAnesthesiaWardCode.CelerityInputCodeColumnName = "";
            this.txtAnesthesiaWardCode.CelerityInputSqlWhere = "";
            this.txtAnesthesiaWardCode.CelerityInputTableName = "";
            this.txtAnesthesiaWardCode.CelerityInputValueColumnName = "";
            this.txtAnesthesiaWardCode.Data = null;
            this.txtAnesthesiaWardCode.DefaultPrintText = "";
            this.txtAnesthesiaWardCode.DictTableName = "";
            this.txtAnesthesiaWardCode.DictValueFieldName = "";
            this.txtAnesthesiaWardCode.DictWhereString = "";
            this.txtAnesthesiaWardCode.DisplayFieldName = "";
            this.txtAnesthesiaWardCode.DisplayMutiColFieldName = "";
            this.txtAnesthesiaWardCode.DotBorder = false;
            this.txtAnesthesiaWardCode.DotNumber = 0;
            this.txtAnesthesiaWardCode.ExamItemName = null;
            this.txtAnesthesiaWardCode.FieldName = "txtOpertionRoom";
            this.txtAnesthesiaWardCode.Format = "";
            this.txtAnesthesiaWardCode.HasLookUpItems = false;
            this.txtAnesthesiaWardCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtAnesthesiaWardCode.InitValue = "";
            this.txtAnesthesiaWardCode.InputNeededMessage = "";
            this.txtAnesthesiaWardCode.InputType = Wis.Anes.Framework.Controls.MedInputType.String;
            this.txtAnesthesiaWardCode.LabItemName = null;
            this.txtAnesthesiaWardCode.LimitedString = "~!@#$%^&*()?<>\":";
            this.txtAnesthesiaWardCode.Location = new System.Drawing.Point(160, 135);
            this.txtAnesthesiaWardCode.LockInput = false;
            this.txtAnesthesiaWardCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAnesthesiaWardCode.Maximum = "";
            this.txtAnesthesiaWardCode.MaxLength = 8;
            this.txtAnesthesiaWardCode.Minimum = "";
            this.txtAnesthesiaWardCode.Multiline = false;
            this.txtAnesthesiaWardCode.MultiSelect = false;
            this.txtAnesthesiaWardCode.MultiSign = false;
            this.txtAnesthesiaWardCode.Name = "txtAnesthesiaWardCode";
            this.txtAnesthesiaWardCode.NoPrint = false;
            this.txtAnesthesiaWardCode.NoPrintText = "";
            this.txtAnesthesiaWardCode.NullAble = true;
            this.txtAnesthesiaWardCode.OldForeColor = System.Drawing.Color.Black;
            this.txtAnesthesiaWardCode.PasswordChar = '\0';
            this.txtAnesthesiaWardCode.PrintTail = "";
            this.txtAnesthesiaWardCode.PrintXOffSet = 0F;
            this.txtAnesthesiaWardCode.PrintYOffSet = 0F;
            this.txtAnesthesiaWardCode.ProgramChanging = false;
            this.txtAnesthesiaWardCode.Properties.Appearance.Options.UseTextOptions = true;
            this.txtAnesthesiaWardCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtAnesthesiaWardCode.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtAnesthesiaWardCode.Properties.MaxLength = 8;
            this.txtAnesthesiaWardCode.SelfValue = "";
            this.txtAnesthesiaWardCode.SelfValueChanged = false;
            this.txtAnesthesiaWardCode.Size = new System.Drawing.Size(191, 24);
            this.txtAnesthesiaWardCode.SourceFieldName = "";
            this.txtAnesthesiaWardCode.SourceTableName = "";
            this.txtAnesthesiaWardCode.StoredValue = "";
            this.txtAnesthesiaWardCode.TabIndex = 44;
            this.txtAnesthesiaWardCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAnesthesiaWardCode.UnderLineOffset = 0F;
            this.txtAnesthesiaWardCode.WantValueBeforePrint = "";
            this.txtAnesthesiaWardCode.WordWrap = false;
            // 
            // txtWardCode
            // 
            this.txtWardCode.BindFieldName = "";
            this.txtWardCode.BindList = "";
            this.txtWardCode.BindTableName = "";
            this.txtWardCode.BorderColor = System.Drawing.Color.LightGray;
            this.txtWardCode.BottomLine = false;
            this.txtWardCode.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtWardCode.CanEdit = true;
            this.txtWardCode.CelerityInputCodeColumnName = "";
            this.txtWardCode.CelerityInputSqlWhere = "";
            this.txtWardCode.CelerityInputTableName = "";
            this.txtWardCode.CelerityInputValueColumnName = "";
            this.txtWardCode.Data = null;
            this.txtWardCode.DefaultPrintText = "";
            this.txtWardCode.DictTableName = "";
            this.txtWardCode.DictValueFieldName = "";
            this.txtWardCode.DictWhereString = "";
            this.txtWardCode.DisplayFieldName = "";
            this.txtWardCode.DisplayMutiColFieldName = "";
            this.txtWardCode.DotBorder = false;
            this.txtWardCode.DotNumber = 0;
            this.txtWardCode.ExamItemName = null;
            this.txtWardCode.FieldName = "txtOpertionRoom";
            this.txtWardCode.Format = "";
            this.txtWardCode.HasLookUpItems = false;
            this.txtWardCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtWardCode.InitValue = "";
            this.txtWardCode.InputNeededMessage = "";
            this.txtWardCode.InputType = Wis.Anes.Framework.Controls.MedInputType.String;
            this.txtWardCode.LabItemName = null;
            this.txtWardCode.LimitedString = "~!@#$%^&*()?<>\":";
            this.txtWardCode.Location = new System.Drawing.Point(160, 81);
            this.txtWardCode.LockInput = false;
            this.txtWardCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWardCode.Maximum = "";
            this.txtWardCode.MaxLength = 80;
            this.txtWardCode.Minimum = "";
            this.txtWardCode.Multiline = false;
            this.txtWardCode.MultiSelect = false;
            this.txtWardCode.MultiSign = false;
            this.txtWardCode.Name = "txtWardCode";
            this.txtWardCode.NoPrint = false;
            this.txtWardCode.NoPrintText = "";
            this.txtWardCode.NullAble = true;
            this.txtWardCode.OldForeColor = System.Drawing.Color.Black;
            this.txtWardCode.PasswordChar = '\0';
            this.txtWardCode.PrintTail = "";
            this.txtWardCode.PrintXOffSet = 0F;
            this.txtWardCode.PrintYOffSet = 0F;
            this.txtWardCode.ProgramChanging = false;
            this.txtWardCode.Properties.Appearance.Options.UseTextOptions = true;
            this.txtWardCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtWardCode.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtWardCode.Properties.MaxLength = 80;
            this.txtWardCode.SelfValue = "";
            this.txtWardCode.SelfValueChanged = false;
            this.txtWardCode.Size = new System.Drawing.Size(191, 24);
            this.txtWardCode.SourceFieldName = "";
            this.txtWardCode.SourceTableName = "";
            this.txtWardCode.StoredValue = "";
            this.txtWardCode.TabIndex = 43;
            this.txtWardCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtWardCode.UnderLineOffset = 0F;
            this.txtWardCode.WantValueBeforePrint = "";
            this.txtWardCode.WordWrap = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(78, 85);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(75, 18);
            this.labelControl1.TabIndex = 41;
            this.labelControl1.Text = "手术室代码";
            // 
            // chkPromptBeforeExit
            // 
            this.chkPromptBeforeExit.Location = new System.Drawing.Point(23, 549);
            this.chkPromptBeforeExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkPromptBeforeExit.Name = "chkPromptBeforeExit";
            this.chkPromptBeforeExit.Properties.Caption = "退出程序时是否提示";
            this.chkPromptBeforeExit.Size = new System.Drawing.Size(183, 22);
            this.chkPromptBeforeExit.TabIndex = 40;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnAddInoperationButton);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(770, 702);
            this.tabPage1.Text = "麻醉记录总录入界面按钮";
            // 
            // btnAddInoperationButton
            // 
            this.btnAddInoperationButton.ActionName = null;
            this.btnAddInoperationButton.AutoImage = false;
            this.btnAddInoperationButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddInoperationButton.BindControl = null;
            this.btnAddInoperationButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddInoperationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddInoperationButton.HasBorder = true;
            this.btnAddInoperationButton.IsMenu = false;
            this.btnAddInoperationButton.IsMouseHover = true;
            this.btnAddInoperationButton.Location = new System.Drawing.Point(19, 580);
            this.btnAddInoperationButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddInoperationButton.MenuIndex = 0;
            this.btnAddInoperationButton.Name = "btnAddInoperationButton";
            this.btnAddInoperationButton.PageName = null;
            this.btnAddInoperationButton.Parameters = null;
            this.btnAddInoperationButton.ShortcutKeys = null;
            this.btnAddInoperationButton.ShowText = true;
            this.btnAddInoperationButton.Size = new System.Drawing.Size(80, 37);
            this.btnAddInoperationButton.TabIndex = 46;
            this.btnAddInoperationButton.Text = "新增";
            this.btnAddInoperationButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddInoperationButton.UseVisualStyleBackColor = true;
            this.btnAddInoperationButton.Click += new System.EventHandler(this.btnAddInoperationButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Location = new System.Drawing.Point(3, 4);
            this.dataGridView1.MainView = this.gridView3;
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(764, 566);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.dataGridView1;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView3.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView3.OptionsView.ShowColumnHeaders = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(770, 702);
            this.tabPage2.Text = "液体属性选项";
            // 
            // dataGridView2
            // 
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView2.Location = new System.Drawing.Point(3, 4);
            this.dataGridView2.MainView = this.gridView4;
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(764, 694);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView4});
            // 
            // gridView4
            // 
            this.gridView4.GridControl = this.dataGridView2;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView4.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView4.OptionsView.ShowColumnHeaders = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView3);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(770, 702);
            this.tabPage3.Text = "血气分析选项";
            // 
            // dataGridView3
            // 
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView3.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView3.Location = new System.Drawing.Point(0, 0);
            this.dataGridView3.MainView = this.gridView1;
            this.dataGridView3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemComboBox1});
            this.dataGridView3.Size = new System.Drawing.Size(770, 702);
            this.dataGridView3.TabIndex = 0;
            this.dataGridView3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.BLG_STATUS,
            this.BLG_CODE,
            this.BLG_NAME,
            this.BLG_UNIT});
            this.gridView1.GridControl = this.dataGridView3;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // BLG_STATUS
            // 
            this.BLG_STATUS.Caption = "是否显示";
            this.BLG_STATUS.ColumnEdit = this.repositoryItemCheckEdit1;
            this.BLG_STATUS.FieldName = "Selected";
            this.BLG_STATUS.Name = "BLG_STATUS";
            this.BLG_STATUS.OptionsColumn.AllowSize = false;
            this.BLG_STATUS.Visible = true;
            this.BLG_STATUS.VisibleIndex = 0;
            this.BLG_STATUS.Width = 80;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // BLG_CODE
            // 
            this.BLG_CODE.Caption = "血气分析项目";
            this.BLG_CODE.FieldName = "BLG_CODE";
            this.BLG_CODE.Name = "BLG_CODE";
            this.BLG_CODE.OptionsColumn.AllowEdit = false;
            this.BLG_CODE.Visible = true;
            this.BLG_CODE.VisibleIndex = 1;
            this.BLG_CODE.Width = 244;
            // 
            // BLG_NAME
            // 
            this.BLG_NAME.Caption = "项目自定义名称";
            this.BLG_NAME.FieldName = "BLG_NAME";
            this.BLG_NAME.Name = "BLG_NAME";
            this.BLG_NAME.Visible = true;
            this.BLG_NAME.VisibleIndex = 2;
            this.BLG_NAME.Width = 248;
            // 
            // BLG_UNIT
            // 
            this.BLG_UNIT.Caption = "单位";
            this.BLG_UNIT.FieldName = "BLG_UNIT";
            this.BLG_UNIT.Name = "BLG_UNIT";
            this.BLG_UNIT.Visible = true;
            this.BLG_UNIT.VisibleIndex = 3;
            this.BLG_UNIT.Width = 100;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.dataGridView3;
            this.gridView2.Name = "gridView2";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.btnDeleteItem);
            this.xtraTabPage2.Controls.Add(this.btnAddItem);
            this.xtraTabPage2.Controls.Add(this.gridControlMonitor);
            this.xtraTabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(770, 702);
            this.xtraTabPage2.Text = "体征报警选项";
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.ActionName = null;
            this.btnDeleteItem.AutoImage = false;
            this.btnDeleteItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDeleteItem.BindControl = null;
            this.btnDeleteItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteItem.HasBorder = true;
            this.btnDeleteItem.IsMenu = false;
            this.btnDeleteItem.IsMouseHover = true;
            this.btnDeleteItem.Location = new System.Drawing.Point(123, 580);
            this.btnDeleteItem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDeleteItem.MenuIndex = 0;
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.PageName = null;
            this.btnDeleteItem.Parameters = null;
            this.btnDeleteItem.ShortcutKeys = null;
            this.btnDeleteItem.ShowText = true;
            this.btnDeleteItem.Size = new System.Drawing.Size(80, 37);
            this.btnDeleteItem.TabIndex = 44;
            this.btnDeleteItem.Text = "删除";
            this.btnDeleteItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDeleteItem.ToolTip = "删除项目";
            this.btnDeleteItem.UseVisualStyleBackColor = true;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.ActionName = null;
            this.btnAddItem.AutoImage = false;
            this.btnAddItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddItem.BindControl = null;
            this.btnAddItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.HasBorder = true;
            this.btnAddItem.IsMenu = false;
            this.btnAddItem.IsMouseHover = true;
            this.btnAddItem.Location = new System.Drawing.Point(19, 580);
            this.btnAddItem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddItem.MenuIndex = 0;
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.PageName = null;
            this.btnAddItem.Parameters = null;
            this.btnAddItem.ShortcutKeys = null;
            this.btnAddItem.ShowText = true;
            this.btnAddItem.Size = new System.Drawing.Size(80, 37);
            this.btnAddItem.TabIndex = 43;
            this.btnAddItem.Text = "新增";
            this.btnAddItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddItem.ToolTip = "增加手工录入项目";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // gridControlMonitor
            // 
            this.gridControlMonitor.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridControlMonitor.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControlMonitor.Location = new System.Drawing.Point(0, 0);
            this.gridControlMonitor.MainView = this.gridView5;
            this.gridControlMonitor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControlMonitor.Name = "gridControlMonitor";
            this.gridControlMonitor.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit2});
            this.gridControlMonitor.Size = new System.Drawing.Size(770, 571);
            this.gridControlMonitor.TabIndex = 1;
            this.gridControlMonitor.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView5,
            this.gridView6});
            // 
            // gridView5
            // 
            this.gridView5.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.DB_DATA_NAME,
            this.MONITOR_DATA_NAME,
            this.LOW_SIGNS_VALUES,
            this.HIGH_SIGNS_VALUES});
            this.gridView5.GridControl = this.gridControlMonitor;
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView5.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView5.OptionsCustomization.AllowColumnMoving = false;
            this.gridView5.OptionsCustomization.AllowFilter = false;
            this.gridView5.OptionsCustomization.AllowGroup = false;
            this.gridView5.OptionsCustomization.AllowSort = false;
            this.gridView5.OptionsMenu.EnableColumnMenu = false;
            this.gridView5.OptionsView.ShowGroupPanel = false;
            this.gridView5.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView5_ValidateRow);
            // 
            // DB_DATA_NAME
            // 
            this.DB_DATA_NAME.Caption = "体征代码";
            this.DB_DATA_NAME.FieldName = "DB_DATA_NAME";
            this.DB_DATA_NAME.Name = "DB_DATA_NAME";
            this.DB_DATA_NAME.OptionsColumn.AllowEdit = false;
            this.DB_DATA_NAME.Visible = true;
            this.DB_DATA_NAME.VisibleIndex = 0;
            this.DB_DATA_NAME.Width = 111;
            // 
            // MONITOR_DATA_NAME
            // 
            this.MONITOR_DATA_NAME.Caption = "体征名称";
            this.MONITOR_DATA_NAME.FieldName = "MONITOR_DATA_NAME";
            this.MONITOR_DATA_NAME.Name = "MONITOR_DATA_NAME";
            this.MONITOR_DATA_NAME.OptionsColumn.AllowEdit = false;
            this.MONITOR_DATA_NAME.Visible = true;
            this.MONITOR_DATA_NAME.VisibleIndex = 1;
            this.MONITOR_DATA_NAME.Width = 160;
            // 
            // LOW_SIGNS_VALUES
            // 
            this.LOW_SIGNS_VALUES.Caption = "预警阀值下限（含）";
            this.LOW_SIGNS_VALUES.FieldName = "LOW_SIGNS_VALUES";
            this.LOW_SIGNS_VALUES.Name = "LOW_SIGNS_VALUES";
            this.LOW_SIGNS_VALUES.Visible = true;
            this.LOW_SIGNS_VALUES.VisibleIndex = 2;
            this.LOW_SIGNS_VALUES.Width = 187;
            // 
            // HIGH_SIGNS_VALUES
            // 
            this.HIGH_SIGNS_VALUES.Caption = "预警阀值上限（含）";
            this.HIGH_SIGNS_VALUES.FieldName = "HIGH_SIGNS_VALUES";
            this.HIGH_SIGNS_VALUES.Name = "HIGH_SIGNS_VALUES";
            this.HIGH_SIGNS_VALUES.Visible = true;
            this.HIGH_SIGNS_VALUES.VisibleIndex = 3;
            this.HIGH_SIGNS_VALUES.Width = 194;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // gridView6
            // 
            this.gridView6.GridControl = this.gridControlMonitor;
            this.gridView6.Name = "gridView6";
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.btnOutListAdd);
            this.xtraTabPage3.Controls.Add(this.dataGridViewOutList);
            this.xtraTabPage3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(770, 702);
            this.xtraTabPage3.Text = "出量显示列表";
            this.xtraTabPage3.Paint += new System.Windows.Forms.PaintEventHandler(this.xtraTabPage3_Paint);
            // 
            // btnOutListAdd
            // 
            this.btnOutListAdd.ActionName = null;
            this.btnOutListAdd.AutoImage = false;
            this.btnOutListAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOutListAdd.BindControl = null;
            this.btnOutListAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOutListAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOutListAdd.HasBorder = true;
            this.btnOutListAdd.IsMenu = false;
            this.btnOutListAdd.IsMouseHover = true;
            this.btnOutListAdd.Location = new System.Drawing.Point(19, 580);
            this.btnOutListAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOutListAdd.MenuIndex = 0;
            this.btnOutListAdd.Name = "btnOutListAdd";
            this.btnOutListAdd.PageName = null;
            this.btnOutListAdd.Parameters = null;
            this.btnOutListAdd.ShortcutKeys = null;
            this.btnOutListAdd.ShowText = true;
            this.btnOutListAdd.Size = new System.Drawing.Size(80, 37);
            this.btnOutListAdd.TabIndex = 45;
            this.btnOutListAdd.Text = "新增";
            this.btnOutListAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOutListAdd.UseVisualStyleBackColor = true;
            this.btnOutListAdd.Click += new System.EventHandler(this.btnOutListAdd_Click);
            // 
            // dataGridViewOutList
            // 
            this.dataGridViewOutList.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewOutList.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridViewOutList.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewOutList.MainView = this.gridViewOutList;
            this.dataGridViewOutList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridViewOutList.Name = "dataGridViewOutList";
            this.dataGridViewOutList.Size = new System.Drawing.Size(770, 571);
            this.dataGridViewOutList.TabIndex = 2;
            this.dataGridViewOutList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewOutList});
            // 
            // gridViewOutList
            // 
            this.gridViewOutList.GridControl = this.dataGridViewOutList;
            this.gridViewOutList.Name = "gridViewOutList";
            this.gridViewOutList.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewOutList.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewOutList.OptionsView.ShowColumnHeaders = false;
            this.gridViewOutList.OptionsView.ShowGroupPanel = false;
            // 
            // tabpageBillCfg
            // 
            this.tabpageBillCfg.Controls.Add(this.medButtonAddBillCfg);
            this.tabpageBillCfg.Controls.Add(this.gridBillCfg);
            this.tabpageBillCfg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabpageBillCfg.Name = "tabpageBillCfg";
            this.tabpageBillCfg.PageVisible = false;
            this.tabpageBillCfg.Size = new System.Drawing.Size(770, 702);
            this.tabpageBillCfg.Text = "收费配置";
            // 
            // medButtonAddBillCfg
            // 
            this.medButtonAddBillCfg.ActionName = null;
            this.medButtonAddBillCfg.AutoImage = false;
            this.medButtonAddBillCfg.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.medButtonAddBillCfg.BindControl = null;
            this.medButtonAddBillCfg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.medButtonAddBillCfg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.medButtonAddBillCfg.HasBorder = true;
            this.medButtonAddBillCfg.IsMenu = false;
            this.medButtonAddBillCfg.IsMouseHover = true;
            this.medButtonAddBillCfg.Location = new System.Drawing.Point(34, 617);
            this.medButtonAddBillCfg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.medButtonAddBillCfg.MenuIndex = 0;
            this.medButtonAddBillCfg.Name = "medButtonAddBillCfg";
            this.medButtonAddBillCfg.PageName = null;
            this.medButtonAddBillCfg.Parameters = null;
            this.medButtonAddBillCfg.ShortcutKeys = null;
            this.medButtonAddBillCfg.ShowText = true;
            this.medButtonAddBillCfg.Size = new System.Drawing.Size(80, 37);
            this.medButtonAddBillCfg.TabIndex = 46;
            this.medButtonAddBillCfg.Text = "新增";
            this.medButtonAddBillCfg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.medButtonAddBillCfg.UseVisualStyleBackColor = true;
            this.medButtonAddBillCfg.Click += new System.EventHandler(this.medButtonAddBillCfg_Click);
            // 
            // gridBillCfg
            // 
            this.gridBillCfg.ColumnConfig = null;
            this.gridBillCfg.DataSource = null;
            this.gridBillCfg.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridBillCfg.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridBillCfg.Location = new System.Drawing.Point(0, 0);
            this.gridBillCfg.MainView = this.gridView7;
            this.gridBillCfg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridBillCfg.Name = "gridBillCfg";
            this.gridBillCfg.Size = new System.Drawing.Size(770, 609);
            this.gridBillCfg.TabIndex = 3;
            this.gridBillCfg.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView7});
            // 
            // gridView7
            // 
            this.gridView7.GridControl = this.gridBillCfg;
            this.gridView7.Name = "gridView7";
            this.gridView7.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView7.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView7.OptionsView.ColumnAutoWidth = false;
            this.gridView7.OptionsView.ShowGroupPanel = false;
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Controls.Add(this.groupBox2);
            this.xtraTabPage4.Controls.Add(this.medTextBoxPaperTopOff);
            this.xtraTabPage4.Controls.Add(this.label9);
            this.xtraTabPage4.Controls.Add(this.medTextBoxPaperLeftOff);
            this.xtraTabPage4.Controls.Add(this.label8);
            this.xtraTabPage4.Controls.Add(this.medTextBoxPaperWidth);
            this.xtraTabPage4.Controls.Add(this.medTextBoxPaperHeight);
            this.xtraTabPage4.Controls.Add(this.medTextBoxPageName);
            this.xtraTabPage4.Controls.Add(this.label7);
            this.xtraTabPage4.Controls.Add(this.label5);
            this.xtraTabPage4.Controls.Add(this.label4);
            this.xtraTabPage4.Controls.Add(this.label2);
            this.xtraTabPage4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(770, 702);
            this.xtraTabPage4.Text = "文书打印及上传设置";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPDFLocalUrl);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtPDFServerUrl);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.chkUpFileList);
            this.groupBox2.Controls.Add(this.chkDeleteAfterCommitDoc);
            this.groupBox2.Controls.Add(this.labelControl7);
            this.groupBox2.Location = new System.Drawing.Point(26, 280);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(389, 399);
            this.groupBox2.TabIndex = 76;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "打印后文书上传设置";
            // 
            // txtPDFLocalUrl
            // 
            this.txtPDFLocalUrl.BindFieldName = "";
            this.txtPDFLocalUrl.BindList = "";
            this.txtPDFLocalUrl.BindTableName = "";
            this.txtPDFLocalUrl.BorderColor = System.Drawing.Color.LightGray;
            this.txtPDFLocalUrl.BottomLine = false;
            this.txtPDFLocalUrl.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtPDFLocalUrl.CanEdit = true;
            this.txtPDFLocalUrl.CelerityInputCodeColumnName = "";
            this.txtPDFLocalUrl.CelerityInputSqlWhere = "";
            this.txtPDFLocalUrl.CelerityInputTableName = "";
            this.txtPDFLocalUrl.CelerityInputValueColumnName = "";
            this.txtPDFLocalUrl.Data = null;
            this.txtPDFLocalUrl.DefaultPrintText = "";
            this.txtPDFLocalUrl.DictTableName = "";
            this.txtPDFLocalUrl.DictValueFieldName = "";
            this.txtPDFLocalUrl.DictWhereString = "";
            this.txtPDFLocalUrl.DisplayFieldName = "";
            this.txtPDFLocalUrl.DisplayMutiColFieldName = "";
            this.txtPDFLocalUrl.DotBorder = false;
            this.txtPDFLocalUrl.DotNumber = 0;
            this.txtPDFLocalUrl.EditValue = "D:\\PDF\\";
            this.txtPDFLocalUrl.ExamItemName = null;
            this.txtPDFLocalUrl.FieldName = "txtOpertionRoom";
            this.txtPDFLocalUrl.Format = "";
            this.txtPDFLocalUrl.HasLookUpItems = false;
            this.txtPDFLocalUrl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtPDFLocalUrl.InitValue = "";
            this.txtPDFLocalUrl.InputNeededMessage = "";
            this.txtPDFLocalUrl.InputType = Wis.Anes.Framework.Controls.MedInputType.String;
            this.txtPDFLocalUrl.LabItemName = null;
            this.txtPDFLocalUrl.LimitedString = "";
            this.txtPDFLocalUrl.Location = new System.Drawing.Point(167, 75);
            this.txtPDFLocalUrl.LockInput = false;
            this.txtPDFLocalUrl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPDFLocalUrl.Maximum = "";
            this.txtPDFLocalUrl.MaxLength = 80;
            this.txtPDFLocalUrl.Minimum = "";
            this.txtPDFLocalUrl.Multiline = false;
            this.txtPDFLocalUrl.MultiSelect = false;
            this.txtPDFLocalUrl.MultiSign = false;
            this.txtPDFLocalUrl.Name = "txtPDFLocalUrl";
            this.txtPDFLocalUrl.NoPrint = false;
            this.txtPDFLocalUrl.NoPrintText = "";
            this.txtPDFLocalUrl.NullAble = true;
            this.txtPDFLocalUrl.OldForeColor = System.Drawing.Color.Black;
            this.txtPDFLocalUrl.PasswordChar = '\0';
            this.txtPDFLocalUrl.PrintTail = "";
            this.txtPDFLocalUrl.PrintXOffSet = 0F;
            this.txtPDFLocalUrl.PrintYOffSet = 0F;
            this.txtPDFLocalUrl.ProgramChanging = false;
            this.txtPDFLocalUrl.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPDFLocalUrl.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtPDFLocalUrl.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtPDFLocalUrl.Properties.MaxLength = 80;
            this.txtPDFLocalUrl.SelfValue = "";
            this.txtPDFLocalUrl.SelfValueChanged = false;
            this.txtPDFLocalUrl.Size = new System.Drawing.Size(191, 24);
            this.txtPDFLocalUrl.SourceFieldName = "";
            this.txtPDFLocalUrl.SourceTableName = "";
            this.txtPDFLocalUrl.StoredValue = "";
            this.txtPDFLocalUrl.TabIndex = 78;
            this.txtPDFLocalUrl.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPDFLocalUrl.UnderLineOffset = 0F;
            this.txtPDFLocalUrl.WantValueBeforePrint = "";
            this.txtPDFLocalUrl.WordWrap = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(26, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(124, 18);
            this.label11.TabIndex = 77;
            this.label11.Text = "PDF本地存储地址";
            // 
            // txtPDFServerUrl
            // 
            this.txtPDFServerUrl.BindFieldName = "";
            this.txtPDFServerUrl.BindList = "";
            this.txtPDFServerUrl.BindTableName = "";
            this.txtPDFServerUrl.BorderColor = System.Drawing.Color.LightGray;
            this.txtPDFServerUrl.BottomLine = false;
            this.txtPDFServerUrl.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtPDFServerUrl.CanEdit = true;
            this.txtPDFServerUrl.CelerityInputCodeColumnName = "";
            this.txtPDFServerUrl.CelerityInputSqlWhere = "";
            this.txtPDFServerUrl.CelerityInputTableName = "";
            this.txtPDFServerUrl.CelerityInputValueColumnName = "";
            this.txtPDFServerUrl.Data = null;
            this.txtPDFServerUrl.DefaultPrintText = "";
            this.txtPDFServerUrl.DictTableName = "";
            this.txtPDFServerUrl.DictValueFieldName = "";
            this.txtPDFServerUrl.DictWhereString = "";
            this.txtPDFServerUrl.DisplayFieldName = "";
            this.txtPDFServerUrl.DisplayMutiColFieldName = "";
            this.txtPDFServerUrl.DotBorder = false;
            this.txtPDFServerUrl.DotNumber = 0;
            this.txtPDFServerUrl.EditValue = "192.168.0.241";
            this.txtPDFServerUrl.ExamItemName = null;
            this.txtPDFServerUrl.FieldName = "txtOpertionRoom";
            this.txtPDFServerUrl.Format = "";
            this.txtPDFServerUrl.HasLookUpItems = false;
            this.txtPDFServerUrl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtPDFServerUrl.InitValue = "";
            this.txtPDFServerUrl.InputNeededMessage = "";
            this.txtPDFServerUrl.InputType = Wis.Anes.Framework.Controls.MedInputType.String;
            this.txtPDFServerUrl.LabItemName = null;
            this.txtPDFServerUrl.LimitedString = "";
            this.txtPDFServerUrl.Location = new System.Drawing.Point(167, 40);
            this.txtPDFServerUrl.LockInput = false;
            this.txtPDFServerUrl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPDFServerUrl.Maximum = "";
            this.txtPDFServerUrl.MaxLength = 80;
            this.txtPDFServerUrl.Minimum = "";
            this.txtPDFServerUrl.Multiline = false;
            this.txtPDFServerUrl.MultiSelect = false;
            this.txtPDFServerUrl.MultiSign = false;
            this.txtPDFServerUrl.Name = "txtPDFServerUrl";
            this.txtPDFServerUrl.NoPrint = false;
            this.txtPDFServerUrl.NoPrintText = "";
            this.txtPDFServerUrl.NullAble = true;
            this.txtPDFServerUrl.OldForeColor = System.Drawing.Color.Black;
            this.txtPDFServerUrl.PasswordChar = '\0';
            this.txtPDFServerUrl.PrintTail = "";
            this.txtPDFServerUrl.PrintXOffSet = 0F;
            this.txtPDFServerUrl.PrintYOffSet = 0F;
            this.txtPDFServerUrl.ProgramChanging = false;
            this.txtPDFServerUrl.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPDFServerUrl.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtPDFServerUrl.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtPDFServerUrl.Properties.MaxLength = 80;
            this.txtPDFServerUrl.SelfValue = "";
            this.txtPDFServerUrl.SelfValueChanged = false;
            this.txtPDFServerUrl.Size = new System.Drawing.Size(191, 24);
            this.txtPDFServerUrl.SourceFieldName = "";
            this.txtPDFServerUrl.SourceTableName = "";
            this.txtPDFServerUrl.StoredValue = "";
            this.txtPDFServerUrl.TabIndex = 76;
            this.txtPDFServerUrl.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPDFServerUrl.UnderLineOffset = 0F;
            this.txtPDFServerUrl.WantValueBeforePrint = "";
            this.txtPDFServerUrl.WordWrap = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(139, 18);
            this.label10.TabIndex = 75;
            this.label10.Text = "PDF上传服务器地址";
            // 
            // chkUpFileList
            // 
            this.chkUpFileList.Location = new System.Drawing.Point(15, 145);
            this.chkUpFileList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkUpFileList.Name = "chkUpFileList";
            this.chkUpFileList.Size = new System.Drawing.Size(343, 198);
            this.chkUpFileList.TabIndex = 72;
            // 
            // chkDeleteAfterCommitDoc
            // 
            this.chkDeleteAfterCommitDoc.Location = new System.Drawing.Point(13, 351);
            this.chkDeleteAfterCommitDoc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkDeleteAfterCommitDoc.Name = "chkDeleteAfterCommitDoc";
            this.chkDeleteAfterCommitDoc.Properties.Caption = "文书上传后不本地保存";
            this.chkDeleteAfterCommitDoc.Size = new System.Drawing.Size(249, 22);
            this.chkDeleteAfterCommitDoc.TabIndex = 74;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(15, 120);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(105, 18);
            this.labelControl7.TabIndex = 73;
            this.labelControl7.Text = "选择上传文书：";
            // 
            // medTextBoxPaperTopOff
            // 
            this.medTextBoxPaperTopOff.BindFieldName = "";
            this.medTextBoxPaperTopOff.BindList = "";
            this.medTextBoxPaperTopOff.BindTableName = "";
            this.medTextBoxPaperTopOff.BorderColor = System.Drawing.Color.LightGray;
            this.medTextBoxPaperTopOff.BottomLine = false;
            this.medTextBoxPaperTopOff.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.medTextBoxPaperTopOff.CanEdit = true;
            this.medTextBoxPaperTopOff.CelerityInputCodeColumnName = "";
            this.medTextBoxPaperTopOff.CelerityInputSqlWhere = "";
            this.medTextBoxPaperTopOff.CelerityInputTableName = "";
            this.medTextBoxPaperTopOff.CelerityInputValueColumnName = "";
            this.medTextBoxPaperTopOff.Data = null;
            this.medTextBoxPaperTopOff.DefaultPrintText = "";
            this.medTextBoxPaperTopOff.DictTableName = "";
            this.medTextBoxPaperTopOff.DictValueFieldName = "";
            this.medTextBoxPaperTopOff.DictWhereString = "";
            this.medTextBoxPaperTopOff.DisplayFieldName = "";
            this.medTextBoxPaperTopOff.DisplayMutiColFieldName = "";
            this.medTextBoxPaperTopOff.DotBorder = false;
            this.medTextBoxPaperTopOff.DotNumber = 0;
            this.medTextBoxPaperTopOff.ExamItemName = null;
            this.medTextBoxPaperTopOff.FieldName = "txtOpertionRoom";
            this.medTextBoxPaperTopOff.Format = "";
            this.medTextBoxPaperTopOff.HasLookUpItems = false;
            this.medTextBoxPaperTopOff.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.medTextBoxPaperTopOff.InitValue = "";
            this.medTextBoxPaperTopOff.InputNeededMessage = "";
            this.medTextBoxPaperTopOff.InputType = Wis.Anes.Framework.Controls.MedInputType.String;
            this.medTextBoxPaperTopOff.LabItemName = null;
            this.medTextBoxPaperTopOff.LimitedString = "";
            this.medTextBoxPaperTopOff.Location = new System.Drawing.Point(193, 231);
            this.medTextBoxPaperTopOff.LockInput = false;
            this.medTextBoxPaperTopOff.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.medTextBoxPaperTopOff.Maximum = "";
            this.medTextBoxPaperTopOff.MaxLength = 20;
            this.medTextBoxPaperTopOff.Minimum = "";
            this.medTextBoxPaperTopOff.Multiline = false;
            this.medTextBoxPaperTopOff.MultiSelect = false;
            this.medTextBoxPaperTopOff.MultiSign = false;
            this.medTextBoxPaperTopOff.Name = "medTextBoxPaperTopOff";
            this.medTextBoxPaperTopOff.NoPrint = false;
            this.medTextBoxPaperTopOff.NoPrintText = "";
            this.medTextBoxPaperTopOff.NullAble = true;
            this.medTextBoxPaperTopOff.OldForeColor = System.Drawing.Color.Black;
            this.medTextBoxPaperTopOff.PasswordChar = '\0';
            this.medTextBoxPaperTopOff.PrintTail = "";
            this.medTextBoxPaperTopOff.PrintXOffSet = 0F;
            this.medTextBoxPaperTopOff.PrintYOffSet = 0F;
            this.medTextBoxPaperTopOff.ProgramChanging = false;
            this.medTextBoxPaperTopOff.Properties.Appearance.Options.UseTextOptions = true;
            this.medTextBoxPaperTopOff.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.medTextBoxPaperTopOff.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.medTextBoxPaperTopOff.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.medTextBoxPaperTopOff.Properties.MaxLength = 20;
            this.medTextBoxPaperTopOff.SelfValue = "";
            this.medTextBoxPaperTopOff.SelfValueChanged = false;
            this.medTextBoxPaperTopOff.Size = new System.Drawing.Size(191, 24);
            this.medTextBoxPaperTopOff.SourceFieldName = "";
            this.medTextBoxPaperTopOff.SourceTableName = "";
            this.medTextBoxPaperTopOff.StoredValue = "";
            this.medTextBoxPaperTopOff.TabIndex = 50;
            this.medTextBoxPaperTopOff.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.medTextBoxPaperTopOff.UnderLineOffset = 0F;
            this.medTextBoxPaperTopOff.WantValueBeforePrint = "";
            this.medTextBoxPaperTopOff.WordWrap = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 235);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(178, 18);
            this.label9.TabIndex = 49;
            this.label9.Text = "打印纸张上方预留（cm）";
            // 
            // medTextBoxPaperLeftOff
            // 
            this.medTextBoxPaperLeftOff.BindFieldName = "";
            this.medTextBoxPaperLeftOff.BindList = "";
            this.medTextBoxPaperLeftOff.BindTableName = "";
            this.medTextBoxPaperLeftOff.BorderColor = System.Drawing.Color.LightGray;
            this.medTextBoxPaperLeftOff.BottomLine = false;
            this.medTextBoxPaperLeftOff.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.medTextBoxPaperLeftOff.CanEdit = true;
            this.medTextBoxPaperLeftOff.CelerityInputCodeColumnName = "";
            this.medTextBoxPaperLeftOff.CelerityInputSqlWhere = "";
            this.medTextBoxPaperLeftOff.CelerityInputTableName = "";
            this.medTextBoxPaperLeftOff.CelerityInputValueColumnName = "";
            this.medTextBoxPaperLeftOff.Data = null;
            this.medTextBoxPaperLeftOff.DefaultPrintText = "";
            this.medTextBoxPaperLeftOff.DictTableName = "";
            this.medTextBoxPaperLeftOff.DictValueFieldName = "";
            this.medTextBoxPaperLeftOff.DictWhereString = "";
            this.medTextBoxPaperLeftOff.DisplayFieldName = "";
            this.medTextBoxPaperLeftOff.DisplayMutiColFieldName = "";
            this.medTextBoxPaperLeftOff.DotBorder = false;
            this.medTextBoxPaperLeftOff.DotNumber = 0;
            this.medTextBoxPaperLeftOff.ExamItemName = null;
            this.medTextBoxPaperLeftOff.FieldName = "txtOpertionRoom";
            this.medTextBoxPaperLeftOff.Format = "";
            this.medTextBoxPaperLeftOff.HasLookUpItems = false;
            this.medTextBoxPaperLeftOff.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.medTextBoxPaperLeftOff.InitValue = "";
            this.medTextBoxPaperLeftOff.InputNeededMessage = "";
            this.medTextBoxPaperLeftOff.InputType = Wis.Anes.Framework.Controls.MedInputType.String;
            this.medTextBoxPaperLeftOff.LabItemName = null;
            this.medTextBoxPaperLeftOff.LimitedString = "";
            this.medTextBoxPaperLeftOff.Location = new System.Drawing.Point(193, 183);
            this.medTextBoxPaperLeftOff.LockInput = false;
            this.medTextBoxPaperLeftOff.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.medTextBoxPaperLeftOff.Maximum = "";
            this.medTextBoxPaperLeftOff.MaxLength = 20;
            this.medTextBoxPaperLeftOff.Minimum = "";
            this.medTextBoxPaperLeftOff.Multiline = false;
            this.medTextBoxPaperLeftOff.MultiSelect = false;
            this.medTextBoxPaperLeftOff.MultiSign = false;
            this.medTextBoxPaperLeftOff.Name = "medTextBoxPaperLeftOff";
            this.medTextBoxPaperLeftOff.NoPrint = false;
            this.medTextBoxPaperLeftOff.NoPrintText = "";
            this.medTextBoxPaperLeftOff.NullAble = true;
            this.medTextBoxPaperLeftOff.OldForeColor = System.Drawing.Color.Black;
            this.medTextBoxPaperLeftOff.PasswordChar = '\0';
            this.medTextBoxPaperLeftOff.PrintTail = "";
            this.medTextBoxPaperLeftOff.PrintXOffSet = 0F;
            this.medTextBoxPaperLeftOff.PrintYOffSet = 0F;
            this.medTextBoxPaperLeftOff.ProgramChanging = false;
            this.medTextBoxPaperLeftOff.Properties.Appearance.Options.UseTextOptions = true;
            this.medTextBoxPaperLeftOff.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.medTextBoxPaperLeftOff.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.medTextBoxPaperLeftOff.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.medTextBoxPaperLeftOff.Properties.MaxLength = 20;
            this.medTextBoxPaperLeftOff.SelfValue = "";
            this.medTextBoxPaperLeftOff.SelfValueChanged = false;
            this.medTextBoxPaperLeftOff.Size = new System.Drawing.Size(191, 24);
            this.medTextBoxPaperLeftOff.SourceFieldName = "";
            this.medTextBoxPaperLeftOff.SourceTableName = "";
            this.medTextBoxPaperLeftOff.StoredValue = "";
            this.medTextBoxPaperLeftOff.TabIndex = 48;
            this.medTextBoxPaperLeftOff.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.medTextBoxPaperLeftOff.UnderLineOffset = 0F;
            this.medTextBoxPaperLeftOff.WantValueBeforePrint = "";
            this.medTextBoxPaperLeftOff.WordWrap = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 186);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(178, 18);
            this.label8.TabIndex = 47;
            this.label8.Text = "打印纸张左侧预留（cm）";
            // 
            // medTextBoxPaperWidth
            // 
            this.medTextBoxPaperWidth.BindFieldName = "";
            this.medTextBoxPaperWidth.BindList = "";
            this.medTextBoxPaperWidth.BindTableName = "";
            this.medTextBoxPaperWidth.BorderColor = System.Drawing.Color.LightGray;
            this.medTextBoxPaperWidth.BottomLine = false;
            this.medTextBoxPaperWidth.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.medTextBoxPaperWidth.CanEdit = true;
            this.medTextBoxPaperWidth.CelerityInputCodeColumnName = "";
            this.medTextBoxPaperWidth.CelerityInputSqlWhere = "";
            this.medTextBoxPaperWidth.CelerityInputTableName = "";
            this.medTextBoxPaperWidth.CelerityInputValueColumnName = "";
            this.medTextBoxPaperWidth.Data = null;
            this.medTextBoxPaperWidth.DefaultPrintText = "";
            this.medTextBoxPaperWidth.DictTableName = "";
            this.medTextBoxPaperWidth.DictValueFieldName = "";
            this.medTextBoxPaperWidth.DictWhereString = "";
            this.medTextBoxPaperWidth.DisplayFieldName = "";
            this.medTextBoxPaperWidth.DisplayMutiColFieldName = "";
            this.medTextBoxPaperWidth.DotBorder = false;
            this.medTextBoxPaperWidth.DotNumber = 0;
            this.medTextBoxPaperWidth.ExamItemName = null;
            this.medTextBoxPaperWidth.FieldName = "txtOpertionRoom";
            this.medTextBoxPaperWidth.Format = "";
            this.medTextBoxPaperWidth.HasLookUpItems = false;
            this.medTextBoxPaperWidth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.medTextBoxPaperWidth.InitValue = "";
            this.medTextBoxPaperWidth.InputNeededMessage = "";
            this.medTextBoxPaperWidth.InputType = Wis.Anes.Framework.Controls.MedInputType.String;
            this.medTextBoxPaperWidth.LabItemName = null;
            this.medTextBoxPaperWidth.LimitedString = "";
            this.medTextBoxPaperWidth.Location = new System.Drawing.Point(193, 135);
            this.medTextBoxPaperWidth.LockInput = false;
            this.medTextBoxPaperWidth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.medTextBoxPaperWidth.Maximum = "";
            this.medTextBoxPaperWidth.MaxLength = 20;
            this.medTextBoxPaperWidth.Minimum = "";
            this.medTextBoxPaperWidth.Multiline = false;
            this.medTextBoxPaperWidth.MultiSelect = false;
            this.medTextBoxPaperWidth.MultiSign = false;
            this.medTextBoxPaperWidth.Name = "medTextBoxPaperWidth";
            this.medTextBoxPaperWidth.NoPrint = false;
            this.medTextBoxPaperWidth.NoPrintText = "";
            this.medTextBoxPaperWidth.NullAble = true;
            this.medTextBoxPaperWidth.OldForeColor = System.Drawing.Color.Black;
            this.medTextBoxPaperWidth.PasswordChar = '\0';
            this.medTextBoxPaperWidth.PrintTail = "";
            this.medTextBoxPaperWidth.PrintXOffSet = 0F;
            this.medTextBoxPaperWidth.PrintYOffSet = 0F;
            this.medTextBoxPaperWidth.ProgramChanging = false;
            this.medTextBoxPaperWidth.Properties.Appearance.Options.UseTextOptions = true;
            this.medTextBoxPaperWidth.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.medTextBoxPaperWidth.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.medTextBoxPaperWidth.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.medTextBoxPaperWidth.Properties.MaxLength = 20;
            this.medTextBoxPaperWidth.SelfValue = "";
            this.medTextBoxPaperWidth.SelfValueChanged = false;
            this.medTextBoxPaperWidth.Size = new System.Drawing.Size(191, 24);
            this.medTextBoxPaperWidth.SourceFieldName = "";
            this.medTextBoxPaperWidth.SourceTableName = "";
            this.medTextBoxPaperWidth.StoredValue = "";
            this.medTextBoxPaperWidth.TabIndex = 46;
            this.medTextBoxPaperWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.medTextBoxPaperWidth.UnderLineOffset = 0F;
            this.medTextBoxPaperWidth.WantValueBeforePrint = "";
            this.medTextBoxPaperWidth.WordWrap = false;
            // 
            // medTextBoxPaperHeight
            // 
            this.medTextBoxPaperHeight.BindFieldName = "";
            this.medTextBoxPaperHeight.BindList = "";
            this.medTextBoxPaperHeight.BindTableName = "";
            this.medTextBoxPaperHeight.BorderColor = System.Drawing.Color.LightGray;
            this.medTextBoxPaperHeight.BottomLine = false;
            this.medTextBoxPaperHeight.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.medTextBoxPaperHeight.CanEdit = true;
            this.medTextBoxPaperHeight.CelerityInputCodeColumnName = "";
            this.medTextBoxPaperHeight.CelerityInputSqlWhere = "";
            this.medTextBoxPaperHeight.CelerityInputTableName = "";
            this.medTextBoxPaperHeight.CelerityInputValueColumnName = "";
            this.medTextBoxPaperHeight.Data = null;
            this.medTextBoxPaperHeight.DefaultPrintText = "";
            this.medTextBoxPaperHeight.DictTableName = "";
            this.medTextBoxPaperHeight.DictValueFieldName = "";
            this.medTextBoxPaperHeight.DictWhereString = "";
            this.medTextBoxPaperHeight.DisplayFieldName = "";
            this.medTextBoxPaperHeight.DisplayMutiColFieldName = "";
            this.medTextBoxPaperHeight.DotBorder = false;
            this.medTextBoxPaperHeight.DotNumber = 0;
            this.medTextBoxPaperHeight.ExamItemName = null;
            this.medTextBoxPaperHeight.FieldName = "txtOpertionRoom";
            this.medTextBoxPaperHeight.Format = "";
            this.medTextBoxPaperHeight.HasLookUpItems = false;
            this.medTextBoxPaperHeight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.medTextBoxPaperHeight.InitValue = "";
            this.medTextBoxPaperHeight.InputNeededMessage = "";
            this.medTextBoxPaperHeight.InputType = Wis.Anes.Framework.Controls.MedInputType.String;
            this.medTextBoxPaperHeight.LabItemName = null;
            this.medTextBoxPaperHeight.LimitedString = "";
            this.medTextBoxPaperHeight.Location = new System.Drawing.Point(193, 93);
            this.medTextBoxPaperHeight.LockInput = false;
            this.medTextBoxPaperHeight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.medTextBoxPaperHeight.Maximum = "";
            this.medTextBoxPaperHeight.MaxLength = 20;
            this.medTextBoxPaperHeight.Minimum = "";
            this.medTextBoxPaperHeight.Multiline = false;
            this.medTextBoxPaperHeight.MultiSelect = false;
            this.medTextBoxPaperHeight.MultiSign = false;
            this.medTextBoxPaperHeight.Name = "medTextBoxPaperHeight";
            this.medTextBoxPaperHeight.NoPrint = false;
            this.medTextBoxPaperHeight.NoPrintText = "";
            this.medTextBoxPaperHeight.NullAble = true;
            this.medTextBoxPaperHeight.OldForeColor = System.Drawing.Color.Black;
            this.medTextBoxPaperHeight.PasswordChar = '\0';
            this.medTextBoxPaperHeight.PrintTail = "";
            this.medTextBoxPaperHeight.PrintXOffSet = 0F;
            this.medTextBoxPaperHeight.PrintYOffSet = 0F;
            this.medTextBoxPaperHeight.ProgramChanging = false;
            this.medTextBoxPaperHeight.Properties.Appearance.Options.UseTextOptions = true;
            this.medTextBoxPaperHeight.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.medTextBoxPaperHeight.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.medTextBoxPaperHeight.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.medTextBoxPaperHeight.Properties.MaxLength = 20;
            this.medTextBoxPaperHeight.SelfValue = "";
            this.medTextBoxPaperHeight.SelfValueChanged = false;
            this.medTextBoxPaperHeight.Size = new System.Drawing.Size(191, 24);
            this.medTextBoxPaperHeight.SourceFieldName = "";
            this.medTextBoxPaperHeight.SourceTableName = "";
            this.medTextBoxPaperHeight.StoredValue = "";
            this.medTextBoxPaperHeight.TabIndex = 45;
            this.medTextBoxPaperHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.medTextBoxPaperHeight.UnderLineOffset = 0F;
            this.medTextBoxPaperHeight.WantValueBeforePrint = "";
            this.medTextBoxPaperHeight.WordWrap = false;
            // 
            // medTextBoxPageName
            // 
            this.medTextBoxPageName.BindFieldName = "";
            this.medTextBoxPageName.BindList = "";
            this.medTextBoxPageName.BindTableName = "";
            this.medTextBoxPageName.BorderColor = System.Drawing.Color.LightGray;
            this.medTextBoxPageName.BottomLine = false;
            this.medTextBoxPageName.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.medTextBoxPageName.CanEdit = true;
            this.medTextBoxPageName.CelerityInputCodeColumnName = "";
            this.medTextBoxPageName.CelerityInputSqlWhere = "";
            this.medTextBoxPageName.CelerityInputTableName = "";
            this.medTextBoxPageName.CelerityInputValueColumnName = "";
            this.medTextBoxPageName.Data = null;
            this.medTextBoxPageName.DefaultPrintText = "";
            this.medTextBoxPageName.DictTableName = "";
            this.medTextBoxPageName.DictValueFieldName = "";
            this.medTextBoxPageName.DictWhereString = "";
            this.medTextBoxPageName.DisplayFieldName = "";
            this.medTextBoxPageName.DisplayMutiColFieldName = "";
            this.medTextBoxPageName.DotBorder = false;
            this.medTextBoxPageName.DotNumber = 0;
            this.medTextBoxPageName.ExamItemName = null;
            this.medTextBoxPageName.FieldName = "txtOpertionRoom";
            this.medTextBoxPageName.Format = "";
            this.medTextBoxPageName.HasLookUpItems = false;
            this.medTextBoxPageName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.medTextBoxPageName.InitValue = "";
            this.medTextBoxPageName.InputNeededMessage = "";
            this.medTextBoxPageName.InputType = Wis.Anes.Framework.Controls.MedInputType.String;
            this.medTextBoxPageName.LabItemName = null;
            this.medTextBoxPageName.LimitedString = "";
            this.medTextBoxPageName.Location = new System.Drawing.Point(122, 46);
            this.medTextBoxPageName.LockInput = false;
            this.medTextBoxPageName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.medTextBoxPageName.Maximum = "";
            this.medTextBoxPageName.MaxLength = 20;
            this.medTextBoxPageName.Minimum = "";
            this.medTextBoxPageName.Multiline = false;
            this.medTextBoxPageName.MultiSelect = false;
            this.medTextBoxPageName.MultiSign = false;
            this.medTextBoxPageName.Name = "medTextBoxPageName";
            this.medTextBoxPageName.NoPrint = false;
            this.medTextBoxPageName.NoPrintText = "";
            this.medTextBoxPageName.NullAble = true;
            this.medTextBoxPageName.OldForeColor = System.Drawing.Color.Black;
            this.medTextBoxPageName.PasswordChar = '\0';
            this.medTextBoxPageName.PrintTail = "";
            this.medTextBoxPageName.PrintXOffSet = 0F;
            this.medTextBoxPageName.PrintYOffSet = 0F;
            this.medTextBoxPageName.ProgramChanging = false;
            this.medTextBoxPageName.Properties.Appearance.Options.UseTextOptions = true;
            this.medTextBoxPageName.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.medTextBoxPageName.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.medTextBoxPageName.Properties.MaxLength = 20;
            this.medTextBoxPageName.SelfValue = "";
            this.medTextBoxPageName.SelfValueChanged = false;
            this.medTextBoxPageName.Size = new System.Drawing.Size(262, 24);
            this.medTextBoxPageName.SourceFieldName = "";
            this.medTextBoxPageName.SourceTableName = "";
            this.medTextBoxPageName.StoredValue = "";
            this.medTextBoxPageName.TabIndex = 44;
            this.medTextBoxPageName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.medTextBoxPageName.UnderLineOffset = 0F;
            this.medTextBoxPageName.WantValueBeforePrint = "";
            this.medTextBoxPageName.WordWrap = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(119, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 18);
            this.label7.TabIndex = 11;
            this.label7.Text = "宽（cm）";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(119, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "长（cm）";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "纸张尺寸";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "纸张名称";
            // 
            // xtraTabPage5
            // 
            this.xtraTabPage5.Controls.Add(this.groupBox3);
            this.xtraTabPage5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xtraTabPage5.Name = "xtraTabPage5";
            this.xtraTabPage5.Size = new System.Drawing.Size(770, 702);
            this.xtraTabPage5.Text = "医疗文书完整性检查";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.chkDocCheckList);
            this.groupBox3.Controls.Add(this.labelControl8);
            this.groupBox3.Location = new System.Drawing.Point(19, 22);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(369, 428);
            this.groupBox3.TabIndex = 77;
            this.groupBox3.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 23);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(323, 18);
            this.label16.TabIndex = 75;
            this.label16.Text = "系统将会检查下列被打勾的医疗文书是否已完成";
            // 
            // chkDocCheckList
            // 
            this.chkDocCheckList.Location = new System.Drawing.Point(7, 99);
            this.chkDocCheckList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkDocCheckList.Name = "chkDocCheckList";
            this.chkDocCheckList.Size = new System.Drawing.Size(355, 321);
            this.chkDocCheckList.TabIndex = 72;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(7, 60);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(150, 18);
            this.labelControl8.TabIndex = 73;
            this.labelControl8.Text = "选择需要检查的文书：";
            // 
            // medPanel1
            // 
            this.medPanel1.Appearance.BackColor = System.Drawing.Color.White;
            this.medPanel1.Appearance.Options.UseBackColor = true;
            this.medPanel1.Controls.Add(this.medLabel1);
            this.medPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.medPanel1.Location = new System.Drawing.Point(0, 0);
            this.medPanel1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.medPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.medPanel1.Name = "medPanel1";
            this.medPanel1.Size = new System.Drawing.Size(777, 51);
            this.medPanel1.TabIndex = 40;
            // 
            // medLabel1
            // 
            this.medLabel1.Appearance.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.medLabel1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.medLabel1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.medLabel1.BottomLine = false;
            this.medLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.medLabel1.DotBorder = false;
            this.medLabel1.Image = null;
            this.medLabel1.Location = new System.Drawing.Point(2, 2);
            this.medLabel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.medLabel1.MultiLine = false;
            this.medLabel1.Name = "medLabel1";
            this.medLabel1.NoPrint = false;
            this.medLabel1.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.medLabel1.PrintXOffSet = 0F;
            this.medLabel1.PrintYOffSet = 0F;
            this.medLabel1.Size = new System.Drawing.Size(773, 47);
            this.medLabel1.SymbolType = Wis.Anes.Framework.Controls.MedSymbolType.None;
            this.medLabel1.TabIndex = 0;
            this.medLabel1.Text = "系统配置";
            this.medLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.medLabel1.VarKey = null;
            // 
            // medPanel2
            // 
            this.medPanel2.Appearance.BackColor = System.Drawing.Color.White;
            this.medPanel2.Appearance.Options.UseBackColor = true;
            this.medPanel2.Controls.Add(this.btnSuperConfig);
            this.medPanel2.Controls.Add(this.btnOK);
            this.medPanel2.Controls.Add(this.btnCancel);
            this.medPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.medPanel2.Location = new System.Drawing.Point(0, 790);
            this.medPanel2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.medPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.medPanel2.Name = "medPanel2";
            this.medPanel2.Size = new System.Drawing.Size(777, 64);
            this.medPanel2.TabIndex = 41;
            // 
            // btnSuperConfig
            // 
            this.btnSuperConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSuperConfig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuperConfig.Location = new System.Drawing.Point(22, 10);
            this.btnSuperConfig.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSuperConfig.Name = "btnSuperConfig";
            this.btnSuperConfig.Size = new System.Drawing.Size(115, 37);
            this.btnSuperConfig.TabIndex = 28;
            this.btnSuperConfig.Text = "超级配置";
            this.btnSuperConfig.Visible = false;
            this.btnSuperConfig.Click += new System.EventHandler(this.btnSuperConfig_Click);
            // 
            // UserConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.medPanel2);
            this.Controls.Add(this.medPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UserConfig";
            this.Size = new System.Drawing.Size(777, 854);
            this.Load += new System.EventHandler(this.UserConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox4)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtOpertionRoom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCanRunManey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtButtonsCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtModifyDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoDosage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOperDone)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSync)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDrugStopOperationStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDrugAutoStop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsModifyMonitorSetting.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupSyncScheduleInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkModifyVitalSignShowDifferent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUseDefaultSelectedMonitorLabel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDrugShow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProLonged.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnesthesiaNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDoubleSelect.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnesthesiaWardCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWardCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPromptBeforeExit.Properties)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMonitor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOutList)).EndInit();
            this.tabpageBillCfg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBillCfg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).EndInit();
            this.xtraTabPage4.ResumeLayout(false);
            this.xtraTabPage4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPDFLocalUrl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPDFServerUrl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUpFileList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDeleteAfterCommitDoc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medTextBoxPaperTopOff.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medTextBoxPaperLeftOff.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medTextBoxPaperWidth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medTextBoxPaperHeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medTextBoxPageName.Properties)).EndInit();
            this.xtraTabPage5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkDocCheckList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medPanel1)).EndInit();
            this.medPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.medPanel2)).EndInit();
            this.medPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnPDFSet;
        private DevExpress.XtraEditors.GroupControl groupBox4;
        private DevExpress.XtraEditors.LabelControl label3;
        private Wis.Anes.Framework.Controls.MedTextBox txtOpertionRoom;
        private DevExpress.XtraEditors.PanelControl panel2;
        private DevExpress.XtraEditors.LabelControl label;
        private Wis.Anes.Framework.Controls.MedTextBox txtNoDosage;
        private DevExpress.XtraEditors.LabelControl label1;
        private Wis.Anes.Framework.Controls.MedTextBox txtModifyDays;
        private DevExpress.XtraEditors.LabelControl label6;
        private DevExpress.XtraTab.XtraTabControl tabControl1;
        private DevExpress.XtraTab.XtraTabPage tabPage1;
        private DevExpress.XtraTab.XtraTabPage tabPage2;
        private DevExpress.XtraTab.XtraTabPage tabPage3;
        private DevExpress.XtraEditors.CheckEdit chkCanRunManey;
        private DevExpress.XtraEditors.LabelControl label13;
        private Wis.Anes.Framework.Controls.MedTextBox txtButtonsCount;
        private DevExpress.XtraGrid.GridControl dataGridView3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn BLG_STATUS;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn BLG_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn BLG_NAME;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.GridControl dataGridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.GridControl dataGridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        //private Com.Wis.Anes.SystemConfig systemConfig1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private Wis.Anes.Framework.Controls.MedPanel medPanel1;
        private Wis.Anes.Framework.Controls.MedLabel medLabel1;
        private Wis.Anes.Framework.Controls.MedPanel medPanel2;
        private DevExpress.XtraEditors.CheckEdit chkPromptBeforeExit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private Wis.Anes.Framework.Controls.MedTextBox txtAnesthesiaWardCode;
        private Wis.Anes.Framework.Controls.MedTextBox txtWardCode;
        private DevExpress.XtraEditors.CheckEdit chkDoubleSelect;
        private Wis.Anes.Framework.Controls.MedTextBox txtAnesthesiaNumber;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cmbProLonged;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ComboBoxEdit cmbDrugShow;
        private DevExpress.XtraEditors.CheckEdit chkUseDefaultSelectedMonitorLabel;
        private DevExpress.XtraEditors.SimpleButton btnSuperConfig;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraGrid.GridControl gridControlMonitor;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn DB_DATA_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn MONITOR_DATA_NAME;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView6;
        private DevExpress.XtraGrid.Columns.GridColumn LOW_SIGNS_VALUES;
        private DevExpress.XtraGrid.Columns.GridColumn HIGH_SIGNS_VALUES;
        private Wis.Anes.Framework.Controls.MedButton btnAddItem;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraGrid.GridControl dataGridViewOutList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewOutList;
        private Wis.Anes.Framework.Controls.MedButton btnOutListAdd;
        private DevExpress.XtraEditors.CheckEdit chkModifyVitalSignShowDifferent;

        private DevExpress.XtraTab.XtraTabPage tabpageBillCfg;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;

        private Wis.Anes.Framework.Controls.MedButton btnAddInoperationButton;
        private Wis.Anes.Views.Setting.CurstomGridView.CustomGridView gridBillCfg;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView7;
        private Wis.Anes.Framework.Controls.MedButton medButtonAddBillCfg;
        private DevExpress.XtraEditors.RadioGroup radioGroupSyncScheduleInfo;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraGrid.Columns.GridColumn BLG_UNIT;
        private DevExpress.XtraEditors.CheckEdit chkIsModifyMonitorSetting;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Wis.Anes.Framework.Controls.MedTextBox medTextBoxPaperWidth;
        private Wis.Anes.Framework.Controls.MedTextBox medTextBoxPaperHeight;
        private Wis.Anes.Framework.Controls.MedTextBox medTextBoxPageName;
        private System.Windows.Forms.Label label7;
        private Wis.Anes.Framework.Controls.MedTextBox medTextBoxPaperLeftOff;
        private System.Windows.Forms.Label label8;
        private Wis.Anes.Framework.Controls.MedTextBox medTextBoxPaperTopOff;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.CheckEdit chkDrugAutoStop;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.ComboBoxEdit cmbDrugStopOperationStatus;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.CheckedListBoxControl chkUpFileList;
        private DevExpress.XtraEditors.CheckEdit chkDeleteAfterCommitDoc;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private Wis.Anes.Framework.Controls.MedTextBox txtPDFServerUrl;
        private System.Windows.Forms.Label label10;
        private Wis.Anes.Framework.Controls.MedTextBox txtPDFLocalUrl;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericUpDownSync;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label16;
        private DevExpress.XtraEditors.CheckedListBoxControl chkDocCheckList;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private Wis.Anes.Framework.Controls.MedButton btnDeleteItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.NumericUpDown numericUpDownOperDone;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;

    }
}
