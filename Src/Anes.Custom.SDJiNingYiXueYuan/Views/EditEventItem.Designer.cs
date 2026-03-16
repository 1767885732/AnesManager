namespace Wis.Anes.Custom.Views
{
    partial class EditEventItem
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
            this.btnSave = new Wis.Anes.Framework.Controls.MedButton();
            this.chkContinued = new DevExpress.XtraEditors.CheckEdit();
            this.timeEditStart = new DevExpress.XtraEditors.TimeEdit();
            this.labelName = new DevExpress.XtraEditors.LabelControl();
            this.labelpath = new DevExpress.XtraEditors.LabelControl();
            this.txtDensity = new Wis.Anes.Framework.Controls.MedTextBox();
            this.txtSpeed = new Wis.Anes.Framework.Controls.MedTextBox();
            this.labelSpeed = new DevExpress.XtraEditors.LabelControl();
            this.txtDosage = new Wis.Anes.Framework.Controls.MedTextBox();
            this.labelDosage = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.timeEditEnd = new DevExpress.XtraEditors.TimeEdit();
            this.panelTop = new DevExpress.XtraEditors.PanelControl();
            this.checkEndDate = new DevExpress.XtraEditors.CheckEdit();
            this.panelBottom = new DevExpress.XtraEditors.PanelControl();
            this.chkDelete = new DevExpress.XtraEditors.CheckEdit();
            this.panelMid = new DevExpress.XtraEditors.PanelControl();
            this.txtDosageUnit = new Wis.Anes.Custom.CustomProject.Views.DictTextBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtSpeedUnit = new Wis.Anes.Custom.CustomProject.Views.DictTextBox();
            this.txtPathUnit = new Wis.Anes.Custom.CustomProject.Views.DictTextBox();
            this.txtPath = new Wis.Anes.Custom.CustomProject.Views.DictTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chkContinued.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDensity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpeed.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDosage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkDelete.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMid)).BeginInit();
            this.panelMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDosageUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpeedUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPathUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.ActionName = null;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.AutoImage = false;
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.BindControl = null;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.HasBorder = true;
            this.btnSave.IsMenu = false;
            this.btnSave.IsMouseHover = true;
            this.btnSave.Location = new System.Drawing.Point(185, 10);
            this.btnSave.MenuIndex = 0;
            this.btnSave.Name = "btnSave";
            this.btnSave.PageName = null;
            this.btnSave.Parameters = null;
            this.btnSave.ShortcutKeys = null;
            this.btnSave.ShowText = true;
            this.btnSave.Size = new System.Drawing.Size(99, 30);
            this.btnSave.TabIndex = 36;
            this.btnSave.Text = "确认(&O)";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkContinued
            // 
            this.chkContinued.Location = new System.Drawing.Point(14, 10);
            this.chkContinued.Name = "chkContinued";
            this.chkContinued.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkContinued.Properties.Appearance.ForeColor = System.Drawing.Color.DarkOrange;
            this.chkContinued.Properties.Appearance.Options.UseFont = true;
            this.chkContinued.Properties.Appearance.Options.UseForeColor = true;
            this.chkContinued.Properties.Caption = "持续用药";
            this.chkContinued.Size = new System.Drawing.Size(93, 22);
            this.chkContinued.TabIndex = 54;
            // 
            // timeEditStart
            // 
            this.timeEditStart.EditValue = new System.DateTime(2011, 4, 13, 0, 0, 0, 0);
            this.timeEditStart.Location = new System.Drawing.Point(129, 33);
            this.timeEditStart.Name = "timeEditStart";
            this.timeEditStart.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeEditStart.Properties.Appearance.Options.UseFont = true;
            this.timeEditStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeEditStart.Properties.DisplayFormat.FormatString = "g";
            this.timeEditStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditStart.Properties.Mask.EditMask = "g";
            this.timeEditStart.Properties.DoubleClick += new System.EventHandler(this.timeEditStart_Properties_DoubleClick);
            this.timeEditStart.Size = new System.Drawing.Size(168, 23);
            this.timeEditStart.TabIndex = 57;
            // 
            // labelName
            // 
            this.labelName.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelName.Appearance.Options.UseFont = true;
            this.labelName.Appearance.Options.UseForeColor = true;
            this.labelName.Location = new System.Drawing.Point(20, 8);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(30, 17);
            this.labelName.TabIndex = 58;
            this.labelName.Text = "名称";
            // 
            // labelpath
            // 
            this.labelpath.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelpath.Appearance.Options.UseFont = true;
            this.labelpath.Location = new System.Drawing.Point(16, 39);
            this.labelpath.Name = "labelpath";
            this.labelpath.Size = new System.Drawing.Size(33, 17);
            this.labelpath.TabIndex = 58;
            this.labelpath.Text = "途径:";
            // 
            // txtDensity
            // 
            this.txtDensity.BindFieldName = "";
            this.txtDensity.BindList = "";
            this.txtDensity.BindTableName = "";
            this.txtDensity.BorderColor = System.Drawing.Color.LightGray;
            this.txtDensity.BottomLine = false;
            this.txtDensity.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtDensity.CanEdit = true;
            this.txtDensity.CelerityInputCodeColumnName = "";
            this.txtDensity.CelerityInputSqlWhere = "";
            this.txtDensity.CelerityInputTableName = "";
            this.txtDensity.CelerityInputValueColumnName = "";
            this.txtDensity.Data = null;
            this.txtDensity.DefaultPrintText = "";
            this.txtDensity.DictTableName = "";
            this.txtDensity.DictValueFieldName = "";
            this.txtDensity.DictWhereString = "";
            this.txtDensity.DisplayFieldName = "";
            this.txtDensity.DisplayMutiColFieldName = "";
            this.txtDensity.DotBorder = false;
            this.txtDensity.DotNumber = 0;
            this.txtDensity.ExamItemName = null;
            this.txtDensity.FieldName = "txtOpertionRoom";
            this.txtDensity.Format = "";
            this.txtDensity.HasLookUpItems = false;
            this.txtDensity.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtDensity.InitValue = "";
            this.txtDensity.InputNeededMessage = "";
            this.txtDensity.InputType = Wis.Anes.Framework.Controls.MedInputType.Nurmeric;
            this.txtDensity.LabItemName = null;
            this.txtDensity.LimitedString = "";
            this.txtDensity.Location = new System.Drawing.Point(138, 38);
            this.txtDensity.LockInput = false;
            this.txtDensity.Maximum = "";
            this.txtDensity.MaxLength = 8;
            this.txtDensity.Minimum = "";
            this.txtDensity.Multiline = false;
            this.txtDensity.MultiSelect = false;
            this.txtDensity.MultiSign = false;
            this.txtDensity.Name = "txtDensity";
            this.txtDensity.NoPrint = false;
            this.txtDensity.NoPrintText = "";
            this.txtDensity.NullAble = true;
            this.txtDensity.OldForeColor = System.Drawing.Color.Black;
            this.txtDensity.PasswordChar = '\0';
            this.txtDensity.PrintTail = "";
            this.txtDensity.PrintXOffSet = 0F;
            this.txtDensity.PrintYOffSet = 0F;
            this.txtDensity.ProgramChanging = false;
            this.txtDensity.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDensity.Properties.Appearance.Options.UseFont = true;
            this.txtDensity.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDensity.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtDensity.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtDensity.Properties.MaxLength = 8;
            this.txtDensity.ReadOnly = false;
            this.txtDensity.SelfValue = "";
            this.txtDensity.SelfValueChanged = false;
            this.txtDensity.Size = new System.Drawing.Size(77, 23);
            this.txtDensity.SourceFieldName = "";
            this.txtDensity.SourceTableName = "";
            this.txtDensity.StoredValue = "";
            this.txtDensity.TabIndex = 55;
            this.txtDensity.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDensity.UnderLineOffset = 0F;
            this.txtDensity.WantValueBeforePrint = "";
            this.txtDensity.WordWrap = false;
            // 
            // txtSpeed
            // 
            this.txtSpeed.BindFieldName = "";
            this.txtSpeed.BindList = "";
            this.txtSpeed.BindTableName = "";
            this.txtSpeed.BorderColor = System.Drawing.Color.LightGray;
            this.txtSpeed.BottomLine = false;
            this.txtSpeed.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtSpeed.CanEdit = true;
            this.txtSpeed.CelerityInputCodeColumnName = "";
            this.txtSpeed.CelerityInputSqlWhere = "";
            this.txtSpeed.CelerityInputTableName = "";
            this.txtSpeed.CelerityInputValueColumnName = "";
            this.txtSpeed.Data = null;
            this.txtSpeed.DefaultPrintText = "";
            this.txtSpeed.DictTableName = "";
            this.txtSpeed.DictValueFieldName = "";
            this.txtSpeed.DictWhereString = "";
            this.txtSpeed.DisplayFieldName = "";
            this.txtSpeed.DisplayMutiColFieldName = "";
            this.txtSpeed.DotBorder = false;
            this.txtSpeed.DotNumber = 0;
            this.txtSpeed.ExamItemName = null;
            this.txtSpeed.FieldName = "txtOpertionRoom";
            this.txtSpeed.Format = "";
            this.txtSpeed.HasLookUpItems = false;
            this.txtSpeed.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtSpeed.InitValue = "";
            this.txtSpeed.InputNeededMessage = "";
            this.txtSpeed.InputType = Wis.Anes.Framework.Controls.MedInputType.Nurmeric;
            this.txtSpeed.LabItemName = null;
            this.txtSpeed.LimitedString = "";
            this.txtSpeed.Location = new System.Drawing.Point(56, 65);
            this.txtSpeed.LockInput = false;
            this.txtSpeed.Maximum = "";
            this.txtSpeed.MaxLength = 8;
            this.txtSpeed.Minimum = "";
            this.txtSpeed.Multiline = false;
            this.txtSpeed.MultiSelect = false;
            this.txtSpeed.MultiSign = false;
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.NoPrint = false;
            this.txtSpeed.NoPrintText = "";
            this.txtSpeed.NullAble = true;
            this.txtSpeed.OldForeColor = System.Drawing.Color.Black;
            this.txtSpeed.PasswordChar = '\0';
            this.txtSpeed.PrintTail = "";
            this.txtSpeed.PrintXOffSet = 0F;
            this.txtSpeed.PrintYOffSet = 0F;
            this.txtSpeed.ProgramChanging = false;
            this.txtSpeed.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpeed.Properties.Appearance.Options.UseFont = true;
            this.txtSpeed.Properties.Appearance.Options.UseTextOptions = true;
            this.txtSpeed.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtSpeed.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtSpeed.Properties.MaxLength = 8;
            this.txtSpeed.ReadOnly = false;
            this.txtSpeed.SelfValue = "";
            this.txtSpeed.SelfValueChanged = false;
            this.txtSpeed.Size = new System.Drawing.Size(77, 23);
            this.txtSpeed.SourceFieldName = "";
            this.txtSpeed.SourceTableName = "";
            this.txtSpeed.StoredValue = "";
            this.txtSpeed.TabIndex = 55;
            this.txtSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSpeed.UnderLineOffset = 0F;
            this.txtSpeed.WantValueBeforePrint = "";
            this.txtSpeed.WordWrap = false;
            // 
            // labelSpeed
            // 
            this.labelSpeed.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSpeed.Appearance.Options.UseFont = true;
            this.labelSpeed.Location = new System.Drawing.Point(15, 66);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(33, 17);
            this.labelSpeed.TabIndex = 58;
            this.labelSpeed.Text = "速度:";
            // 
            // txtDosage
            // 
            this.txtDosage.BindFieldName = "";
            this.txtDosage.BindList = "";
            this.txtDosage.BindTableName = "";
            this.txtDosage.BorderColor = System.Drawing.Color.LightGray;
            this.txtDosage.BottomLine = false;
            this.txtDosage.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtDosage.CanEdit = true;
            this.txtDosage.CelerityInputCodeColumnName = "";
            this.txtDosage.CelerityInputSqlWhere = "";
            this.txtDosage.CelerityInputTableName = "";
            this.txtDosage.CelerityInputValueColumnName = "";
            this.txtDosage.Data = null;
            this.txtDosage.DefaultPrintText = "";
            this.txtDosage.DictTableName = "";
            this.txtDosage.DictValueFieldName = "";
            this.txtDosage.DictWhereString = "";
            this.txtDosage.DisplayFieldName = "";
            this.txtDosage.DisplayMutiColFieldName = "";
            this.txtDosage.DotBorder = false;
            this.txtDosage.DotNumber = 0;
            this.txtDosage.ExamItemName = null;
            this.txtDosage.FieldName = "txtOpertionRoom";
            this.txtDosage.Format = "";
            this.txtDosage.HasLookUpItems = false;
            this.txtDosage.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtDosage.InitValue = "";
            this.txtDosage.InputNeededMessage = "";
            this.txtDosage.InputType = Wis.Anes.Framework.Controls.MedInputType.Nurmeric;
            this.txtDosage.LabItemName = null;
            this.txtDosage.LimitedString = "";
            this.txtDosage.Location = new System.Drawing.Point(56, 92);
            this.txtDosage.LockInput = false;
            this.txtDosage.Maximum = "";
            this.txtDosage.MaxLength = 8;
            this.txtDosage.Minimum = "";
            this.txtDosage.Multiline = false;
            this.txtDosage.MultiSelect = false;
            this.txtDosage.MultiSign = false;
            this.txtDosage.Name = "txtDosage";
            this.txtDosage.NoPrint = false;
            this.txtDosage.NoPrintText = "";
            this.txtDosage.NullAble = true;
            this.txtDosage.OldForeColor = System.Drawing.Color.Black;
            this.txtDosage.PasswordChar = '\0';
            this.txtDosage.PrintTail = "";
            this.txtDosage.PrintXOffSet = 0F;
            this.txtDosage.PrintYOffSet = 0F;
            this.txtDosage.ProgramChanging = false;
            this.txtDosage.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDosage.Properties.Appearance.Options.UseFont = true;
            this.txtDosage.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDosage.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtDosage.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtDosage.Properties.MaxLength = 8;
            this.txtDosage.ReadOnly = false;
            this.txtDosage.SelfValue = "";
            this.txtDosage.SelfValueChanged = false;
            this.txtDosage.Size = new System.Drawing.Size(77, 23);
            this.txtDosage.SourceFieldName = "";
            this.txtDosage.SourceTableName = "";
            this.txtDosage.StoredValue = "";
            this.txtDosage.TabIndex = 55;
            this.txtDosage.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDosage.UnderLineOffset = 0F;
            this.txtDosage.WantValueBeforePrint = "";
            this.txtDosage.WordWrap = false;
            // 
            // labelDosage
            // 
            this.labelDosage.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDosage.Appearance.Options.UseFont = true;
            this.labelDosage.Location = new System.Drawing.Point(15, 93);
            this.labelDosage.Name = "labelDosage";
            this.labelDosage.Size = new System.Drawing.Size(33, 17);
            this.labelDosage.TabIndex = 58;
            this.labelDosage.Text = "剂量:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(37, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 17);
            this.labelControl1.TabIndex = 58;
            this.labelControl1.Text = "起始时间:";
            // 
            // timeEditEnd
            // 
            this.timeEditEnd.EditValue = new System.DateTime(2011, 4, 13, 0, 0, 0, 0);
            this.timeEditEnd.Enabled = false;
            this.timeEditEnd.Location = new System.Drawing.Point(129, 60);
            this.timeEditEnd.Name = "timeEditEnd";
            this.timeEditEnd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeEditEnd.Properties.Appearance.Options.UseFont = true;
            this.timeEditEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeEditEnd.Properties.DisplayFormat.FormatString = "g";
            this.timeEditEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditEnd.Properties.Mask.EditMask = "g";
            this.timeEditEnd.Properties.DoubleClick += new System.EventHandler(this.timeEditEnd_Properties_DoubleClick);
            this.timeEditEnd.Size = new System.Drawing.Size(168, 23);
            this.timeEditEnd.TabIndex = 57;
            this.timeEditEnd.Leave += new System.EventHandler(this.timeEditEnd_Leave);
            // 
            // panelTop
            // 
            this.panelTop.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panelTop.Appearance.Options.UseBackColor = true;
            this.panelTop.Controls.Add(this.checkEndDate);
            this.panelTop.Controls.Add(this.labelName);
            this.panelTop.Controls.Add(this.timeEditStart);
            this.panelTop.Controls.Add(this.timeEditEnd);
            this.panelTop.Controls.Add(this.labelControl1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(313, 91);
            this.panelTop.TabIndex = 59;
            // 
            // checkEndDate
            // 
            this.checkEndDate.Location = new System.Drawing.Point(14, 59);
            this.checkEndDate.Name = "checkEndDate";
            this.checkEndDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEndDate.Properties.Appearance.Options.UseFont = true;
            this.checkEndDate.Properties.Caption = " 结束时间:";
            this.checkEndDate.Size = new System.Drawing.Size(91, 22);
            this.checkEndDate.TabIndex = 54;
            this.checkEndDate.CheckedChanged += new System.EventHandler(this.checkEndDate_CheckedChanged);
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnSave);
            this.panelBottom.Controls.Add(this.chkDelete);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBottom.Location = new System.Drawing.Point(0, 221);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(313, 49);
            this.panelBottom.TabIndex = 59;
            // 
            // chkDelete
            // 
            this.chkDelete.Location = new System.Drawing.Point(13, 8);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDelete.Properties.Appearance.ForeColor = System.Drawing.Color.DarkOrange;
            this.chkDelete.Properties.Appearance.Options.UseFont = true;
            this.chkDelete.Properties.Appearance.Options.UseForeColor = true;
            this.chkDelete.Properties.Caption = "删除用药";
            this.chkDelete.Size = new System.Drawing.Size(93, 22);
            this.chkDelete.TabIndex = 54;
            this.chkDelete.Visible = false;
            // 
            // panelMid
            // 
            this.panelMid.Controls.Add(this.txtDosageUnit);
            this.panelMid.Controls.Add(this.chkContinued);
            this.panelMid.Controls.Add(this.labelControl3);
            this.panelMid.Controls.Add(this.labelControl2);
            this.panelMid.Controls.Add(this.txtSpeedUnit);
            this.panelMid.Controls.Add(this.txtPathUnit);
            this.panelMid.Controls.Add(this.txtPath);
            this.panelMid.Controls.Add(this.labelpath);
            this.panelMid.Controls.Add(this.labelDosage);
            this.panelMid.Controls.Add(this.txtSpeed);
            this.panelMid.Controls.Add(this.labelSpeed);
            this.panelMid.Controls.Add(this.txtDensity);
            this.panelMid.Controls.Add(this.txtDosage);
            this.panelMid.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMid.Location = new System.Drawing.Point(0, 91);
            this.panelMid.Name = "panelMid";
            this.panelMid.Size = new System.Drawing.Size(313, 130);
            this.panelMid.TabIndex = 59;
            // 
            // txtDosageUnit
            // 
            this.txtDosageUnit.BindFieldName = "";
            this.txtDosageUnit.BindList = "";
            this.txtDosageUnit.BindTableName = "";
            this.txtDosageUnit.BorderColor = System.Drawing.Color.LightGray;
            this.txtDosageUnit.BottomLine = false;
            this.txtDosageUnit.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtDosageUnit.CanEdit = true;
            this.txtDosageUnit.CelerityInputCodeColumnName = "ITEM_NAME";
            this.txtDosageUnit.CelerityInputSqlWhere = "ITEM_CLASS = \'用药单位\'";
            this.txtDosageUnit.CelerityInputTableName = "WIS_DICT_ANES_INPUT";
            this.txtDosageUnit.CelerityInputValueColumnName = "ITEM_NAME";
            this.txtDosageUnit.Data = null;
            this.txtDosageUnit.DefaultPrintText = "";
            this.txtDosageUnit.DictTableName = "WIS_DICT_ANES_INPUT";
            this.txtDosageUnit.DictValueFieldName = "ITEM_NAME";
            this.txtDosageUnit.DictWhereString = "ITEM_CLASS = \'用药单位\'";
            this.txtDosageUnit.DisplayFieldName = "ITEM_NAME";
            this.txtDosageUnit.DisplayMutiColFieldName = "";
            this.txtDosageUnit.DotBorder = false;
            this.txtDosageUnit.DotNumber = 0;
            this.txtDosageUnit.ExamItemName = null;
            this.txtDosageUnit.FieldName = "txtAnesDoctor1";
            this.txtDosageUnit.Format = "";
            this.txtDosageUnit.HasLookUpItems = false;
            this.txtDosageUnit.InitValue = "";
            this.txtDosageUnit.InputNeededMessage = "";
            this.txtDosageUnit.InputType = Wis.Anes.Framework.Controls.MedInputType.General;
            this.txtDosageUnit.LabItemName = null;
            this.txtDosageUnit.LimitedString = "";
            this.txtDosageUnit.Location = new System.Drawing.Point(220, 92);
            this.txtDosageUnit.LockInput = false;
            this.txtDosageUnit.Maximum = null;
            this.txtDosageUnit.MaxLength = 8;
            this.txtDosageUnit.Minimum = null;
            this.txtDosageUnit.Multiline = false;
            this.txtDosageUnit.MultiSelect = false;
            this.txtDosageUnit.MultiSign = false;
            this.txtDosageUnit.Name = "txtDosageUnit";
            this.txtDosageUnit.NoPrint = false;
            this.txtDosageUnit.NoPrintText = "";
            this.txtDosageUnit.NullAble = true;
            this.txtDosageUnit.OldForeColor = System.Drawing.Color.Black;
            this.txtDosageUnit.PasswordChar = '\0';
            this.txtDosageUnit.PrintTail = "";
            this.txtDosageUnit.PrintXOffSet = 0F;
            this.txtDosageUnit.PrintYOffSet = 0F;
            this.txtDosageUnit.ProgramChanging = false;
            this.txtDosageUnit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDosageUnit.Properties.Appearance.Options.UseFont = true;
            this.txtDosageUnit.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDosageUnit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtDosageUnit.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtDosageUnit.Properties.MaxLength = 8;
            this.txtDosageUnit.ReadOnly = false;
            this.txtDosageUnit.SelfValue = "";
            this.txtDosageUnit.SelfValueChanged = false;
            this.txtDosageUnit.Size = new System.Drawing.Size(77, 23);
            this.txtDosageUnit.SourceFieldName = "";
            this.txtDosageUnit.SourceTableName = "";
            this.txtDosageUnit.StoredValue = "";
            this.txtDosageUnit.TabIndex = 59;
            this.txtDosageUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDosageUnit.UnderLineOffset = 0F;
            this.txtDosageUnit.WantValueBeforePrint = "";
            this.txtDosageUnit.WordWrap = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(250, 18);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(34, 14);
            this.labelControl3.TabIndex = 58;
            this.labelControl3.Text = "(单位)";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(166, 18);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(34, 14);
            this.labelControl2.TabIndex = 58;
            this.labelControl2.Text = "(浓度)";
            // 
            // txtSpeedUnit
            // 
            this.txtSpeedUnit.BindFieldName = "";
            this.txtSpeedUnit.BindList = "";
            this.txtSpeedUnit.BindTableName = "";
            this.txtSpeedUnit.BorderColor = System.Drawing.Color.LightGray;
            this.txtSpeedUnit.BottomLine = false;
            this.txtSpeedUnit.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtSpeedUnit.CanEdit = true;
            this.txtSpeedUnit.CelerityInputCodeColumnName = "ITEM_NAME";
            this.txtSpeedUnit.CelerityInputSqlWhere = "ITEM_CLASS = \'用药速度单位\'";
            this.txtSpeedUnit.CelerityInputTableName = "WIS_DICT_ANES_INPUT";
            this.txtSpeedUnit.CelerityInputValueColumnName = "ITEM_NAME";
            this.txtSpeedUnit.Data = null;
            this.txtSpeedUnit.DefaultPrintText = "";
            this.txtSpeedUnit.DictTableName = "WIS_DICT_ANES_INPUT";
            this.txtSpeedUnit.DictValueFieldName = "ITEM_NAME";
            this.txtSpeedUnit.DictWhereString = "ITEM_CLASS = \'用药速度单位\'";
            this.txtSpeedUnit.DisplayFieldName = "ITEM_NAME";
            this.txtSpeedUnit.DisplayMutiColFieldName = "";
            this.txtSpeedUnit.DotBorder = false;
            this.txtSpeedUnit.DotNumber = 0;
            this.txtSpeedUnit.ExamItemName = null;
            this.txtSpeedUnit.FieldName = "txtAnesDoctor1";
            this.txtSpeedUnit.Format = "";
            this.txtSpeedUnit.HasLookUpItems = false;
            this.txtSpeedUnit.InitValue = "";
            this.txtSpeedUnit.InputNeededMessage = "";
            this.txtSpeedUnit.InputType = Wis.Anes.Framework.Controls.MedInputType.General;
            this.txtSpeedUnit.LabItemName = null;
            this.txtSpeedUnit.LimitedString = "";
            this.txtSpeedUnit.Location = new System.Drawing.Point(220, 65);
            this.txtSpeedUnit.LockInput = false;
            this.txtSpeedUnit.Maximum = null;
            this.txtSpeedUnit.MaxLength = 8;
            this.txtSpeedUnit.Minimum = null;
            this.txtSpeedUnit.Multiline = false;
            this.txtSpeedUnit.MultiSelect = false;
            this.txtSpeedUnit.MultiSign = false;
            this.txtSpeedUnit.Name = "txtSpeedUnit";
            this.txtSpeedUnit.NoPrint = false;
            this.txtSpeedUnit.NoPrintText = "";
            this.txtSpeedUnit.NullAble = true;
            this.txtSpeedUnit.OldForeColor = System.Drawing.Color.Black;
            this.txtSpeedUnit.PasswordChar = '\0';
            this.txtSpeedUnit.PrintTail = "";
            this.txtSpeedUnit.PrintXOffSet = 0F;
            this.txtSpeedUnit.PrintYOffSet = 0F;
            this.txtSpeedUnit.ProgramChanging = false;
            this.txtSpeedUnit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpeedUnit.Properties.Appearance.Options.UseFont = true;
            this.txtSpeedUnit.Properties.Appearance.Options.UseTextOptions = true;
            this.txtSpeedUnit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtSpeedUnit.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtSpeedUnit.Properties.MaxLength = 8;
            this.txtSpeedUnit.ReadOnly = false;
            this.txtSpeedUnit.SelfValue = "";
            this.txtSpeedUnit.SelfValueChanged = false;
            this.txtSpeedUnit.Size = new System.Drawing.Size(77, 23);
            this.txtSpeedUnit.SourceFieldName = "";
            this.txtSpeedUnit.SourceTableName = "";
            this.txtSpeedUnit.StoredValue = "";
            this.txtSpeedUnit.TabIndex = 59;
            this.txtSpeedUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSpeedUnit.UnderLineOffset = 0F;
            this.txtSpeedUnit.WantValueBeforePrint = "";
            this.txtSpeedUnit.WordWrap = false;
            // 
            // txtPathUnit
            // 
            this.txtPathUnit.BindFieldName = "";
            this.txtPathUnit.BindList = "";
            this.txtPathUnit.BindTableName = "";
            this.txtPathUnit.BorderColor = System.Drawing.Color.LightGray;
            this.txtPathUnit.BottomLine = false;
            this.txtPathUnit.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtPathUnit.CanEdit = true;
            this.txtPathUnit.CelerityInputCodeColumnName = "ITEM_NAME";
            this.txtPathUnit.CelerityInputSqlWhere = "ITEM_CLASS = \'用药浓度单位\'";
            this.txtPathUnit.CelerityInputTableName = "WIS_DICT_ANES_INPUT";
            this.txtPathUnit.CelerityInputValueColumnName = "ITEM_NAME";
            this.txtPathUnit.Data = null;
            this.txtPathUnit.DefaultPrintText = "";
            this.txtPathUnit.DictTableName = "WIS_DICT_ANES_INPUT";
            this.txtPathUnit.DictValueFieldName = "ITEM_NAME";
            this.txtPathUnit.DictWhereString = "ITEM_CLASS = \'用药浓度单位\'";
            this.txtPathUnit.DisplayFieldName = "ITEM_NAME";
            this.txtPathUnit.DisplayMutiColFieldName = "";
            this.txtPathUnit.DotBorder = false;
            this.txtPathUnit.DotNumber = 0;
            this.txtPathUnit.ExamItemName = null;
            this.txtPathUnit.FieldName = "txtAnesDoctor1";
            this.txtPathUnit.Format = "";
            this.txtPathUnit.HasLookUpItems = false;
            this.txtPathUnit.InitValue = "";
            this.txtPathUnit.InputNeededMessage = "";
            this.txtPathUnit.InputType = Wis.Anes.Framework.Controls.MedInputType.General;
            this.txtPathUnit.LabItemName = null;
            this.txtPathUnit.LimitedString = "";
            this.txtPathUnit.Location = new System.Drawing.Point(220, 38);
            this.txtPathUnit.LockInput = false;
            this.txtPathUnit.Maximum = null;
            this.txtPathUnit.MaxLength = 8;
            this.txtPathUnit.Minimum = null;
            this.txtPathUnit.Multiline = false;
            this.txtPathUnit.MultiSelect = false;
            this.txtPathUnit.MultiSign = false;
            this.txtPathUnit.Name = "txtPathUnit";
            this.txtPathUnit.NoPrint = false;
            this.txtPathUnit.NoPrintText = "";
            this.txtPathUnit.NullAble = true;
            this.txtPathUnit.OldForeColor = System.Drawing.Color.Black;
            this.txtPathUnit.PasswordChar = '\0';
            this.txtPathUnit.PrintTail = "";
            this.txtPathUnit.PrintXOffSet = 0F;
            this.txtPathUnit.PrintYOffSet = 0F;
            this.txtPathUnit.ProgramChanging = false;
            this.txtPathUnit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPathUnit.Properties.Appearance.Options.UseFont = true;
            this.txtPathUnit.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPathUnit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtPathUnit.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtPathUnit.Properties.MaxLength = 8;
            this.txtPathUnit.ReadOnly = false;
            this.txtPathUnit.SelfValue = "";
            this.txtPathUnit.SelfValueChanged = false;
            this.txtPathUnit.Size = new System.Drawing.Size(77, 23);
            this.txtPathUnit.SourceFieldName = "";
            this.txtPathUnit.SourceTableName = "";
            this.txtPathUnit.StoredValue = "";
            this.txtPathUnit.TabIndex = 59;
            this.txtPathUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPathUnit.UnderLineOffset = 0F;
            this.txtPathUnit.WantValueBeforePrint = "";
            this.txtPathUnit.WordWrap = false;
            // 
            // txtPath
            // 
            this.txtPath.BindFieldName = "";
            this.txtPath.BindList = "";
            this.txtPath.BindTableName = "";
            this.txtPath.BorderColor = System.Drawing.Color.LightGray;
            this.txtPath.BottomLine = false;
            this.txtPath.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtPath.CanEdit = true;
            this.txtPath.CelerityInputCodeColumnName = "ITEM_NAME";
            this.txtPath.CelerityInputSqlWhere = "ITEM_CLASS = \'用药途径\'";
            this.txtPath.CelerityInputTableName = "WIS_DICT_ANES_INPUT";
            this.txtPath.CelerityInputValueColumnName = "ITEM_NAME";
            this.txtPath.Data = null;
            this.txtPath.DefaultPrintText = "";
            this.txtPath.DictTableName = "WIS_DICT_ANES_INPUT";
            this.txtPath.DictValueFieldName = "ITEM_NAME";
            this.txtPath.DictWhereString = "ITEM_CLASS = \'用药途径\'";
            this.txtPath.DisplayFieldName = "ITEM_NAME";
            this.txtPath.DisplayMutiColFieldName = "";
            this.txtPath.DotBorder = false;
            this.txtPath.DotNumber = 0;
            this.txtPath.ExamItemName = null;
            this.txtPath.FieldName = "txtAnesDoctor1";
            this.txtPath.Format = "";
            this.txtPath.HasLookUpItems = false;
            this.txtPath.InitValue = "";
            this.txtPath.InputNeededMessage = "";
            this.txtPath.InputType = Wis.Anes.Framework.Controls.MedInputType.General;
            this.txtPath.LabItemName = null;
            this.txtPath.LimitedString = "";
            this.txtPath.Location = new System.Drawing.Point(56, 38);
            this.txtPath.LockInput = false;
            this.txtPath.Maximum = null;
            this.txtPath.MaxLength = 8;
            this.txtPath.Minimum = null;
            this.txtPath.Multiline = false;
            this.txtPath.MultiSelect = false;
            this.txtPath.MultiSign = false;
            this.txtPath.Name = "txtPath";
            this.txtPath.NoPrint = false;
            this.txtPath.NoPrintText = "";
            this.txtPath.NullAble = true;
            this.txtPath.OldForeColor = System.Drawing.Color.Black;
            this.txtPath.PasswordChar = '\0';
            this.txtPath.PrintTail = "";
            this.txtPath.PrintXOffSet = 0F;
            this.txtPath.PrintYOffSet = 0F;
            this.txtPath.ProgramChanging = false;
            this.txtPath.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPath.Properties.Appearance.Options.UseFont = true;
            this.txtPath.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPath.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtPath.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtPath.Properties.MaxLength = 8;
            this.txtPath.ReadOnly = false;
            this.txtPath.SelfValue = "";
            this.txtPath.SelfValueChanged = false;
            this.txtPath.Size = new System.Drawing.Size(77, 23);
            this.txtPath.SourceFieldName = "";
            this.txtPath.SourceTableName = "";
            this.txtPath.StoredValue = "";
            this.txtPath.TabIndex = 59;
            this.txtPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPath.UnderLineOffset = 0F;
            this.txtPath.WantValueBeforePrint = "";
            this.txtPath.WordWrap = false;
            // 
            // EditEventItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelMid);
            this.Controls.Add(this.panelTop);
            this.Name = "EditEventItem";
            this.Size = new System.Drawing.Size(313, 271);
            this.Load += new System.EventHandler(this.EditEventItem_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EditEventItem_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.chkContinued.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDensity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpeed.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDosage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkDelete.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMid)).EndInit();
            this.panelMid.ResumeLayout(false);
            this.panelMid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDosageUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpeedUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPathUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Wis.Anes.Framework.Controls.MedButton btnSave;
        private DevExpress.XtraEditors.CheckEdit chkContinued;
        private DevExpress.XtraEditors.TimeEdit timeEditStart;
        private DevExpress.XtraEditors.LabelControl labelName;
        private DevExpress.XtraEditors.LabelControl labelpath;
        private Wis.Anes.Framework.Controls.MedTextBox txtDensity;
        private Wis.Anes.Framework.Controls.MedTextBox txtSpeed;
        private DevExpress.XtraEditors.LabelControl labelSpeed;
        private Wis.Anes.Framework.Controls.MedTextBox txtDosage;
        private DevExpress.XtraEditors.LabelControl labelDosage;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TimeEdit timeEditEnd;
        private DevExpress.XtraEditors.PanelControl panelTop;
        private DevExpress.XtraEditors.PanelControl panelBottom;
        private DevExpress.XtraEditors.PanelControl panelMid;
        private DevExpress.XtraEditors.CheckEdit checkEndDate;
        private Wis.Anes.Custom.CustomProject.Views.DictTextBox txtPath;
        private Wis.Anes.Custom.CustomProject.Views.DictTextBox txtPathUnit;
        private Wis.Anes.Custom.CustomProject.Views.DictTextBox txtDosageUnit;
        private Wis.Anes.Custom.CustomProject.Views.DictTextBox txtSpeedUnit;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.CheckEdit chkDelete;
    }
}
