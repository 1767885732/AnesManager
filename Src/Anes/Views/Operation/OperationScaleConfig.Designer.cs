namespace Wis.Anes.Views
{
    partial class OperationScaleConfig
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
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOperation = new System.Windows.Forms.DataGridView();
            this.gbOperation = new System.Windows.Forms.GroupBox();
            this.chkShowSelected = new System.Windows.Forms.CheckBox();
            this.btnSearchOperation = new System.Windows.Forms.Button();
            this.txtOperationName = new Wis.Anes.Custom.CustomProject.Views.DictTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOperationCode = new Wis.Anes.Custom.CustomProject.Views.DictTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbUsers = new System.Windows.Forms.GroupBox();
            this.btnSearchUser = new System.Windows.Forms.Button();
            this.txtUserName = new Wis.Anes.Custom.CustomProject.Views.DictTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDeptCode = new Wis.Anes.Custom.CustomProject.Views.DictTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.chk1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperation)).BeginInit();
            this.gbOperation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOperationName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOperationCode.Properties)).BeginInit();
            this.gbUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeptCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AllowUserToResizeColumns = false;
            this.dgvUsers.AllowUserToResizeRows = false;
            this.dgvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column7,
            this.Column6,
            this.Column4,
            this.Column5});
            this.dgvUsers.Location = new System.Drawing.Point(6, 79);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.RowTemplate.Height = 23;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(323, 398);
            this.dgvUsers.TabIndex = 0;
            this.dgvUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellContentClick);
            // 
            // Column8
            // 
            this.Column8.HeaderText = "选择";
            this.Column8.Name = "Column8";
            this.Column8.Width = 40;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column7.DataPropertyName = "USER_DEPT";
            this.Column7.HeaderText = "科室ID";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column7.Visible = false;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "DEPT_NAME";
            this.Column6.HeaderText = "科室";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.DataPropertyName = "USER_ID";
            this.Column4.HeaderText = "用户工号";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 59;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column5.DataPropertyName = "USER_NAME";
            this.Column5.HeaderText = "用户名称";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 59;
            // 
            // dgvOperation
            // 
            this.dgvOperation.AllowUserToAddRows = false;
            this.dgvOperation.AllowUserToDeleteRows = false;
            this.dgvOperation.AllowUserToResizeColumns = false;
            this.dgvOperation.AllowUserToResizeRows = false;
            this.dgvOperation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOperation.BackgroundColor = System.Drawing.Color.White;
            this.dgvOperation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOperation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chk1,
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvOperation.Location = new System.Drawing.Point(6, 79);
            this.dgvOperation.Name = "dgvOperation";
            this.dgvOperation.RowHeadersVisible = false;
            this.dgvOperation.RowTemplate.Height = 23;
            this.dgvOperation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOperation.Size = new System.Drawing.Size(446, 398);
            this.dgvOperation.TabIndex = 1;
            // 
            // gbOperation
            // 
            this.gbOperation.Controls.Add(this.chkShowSelected);
            this.gbOperation.Controls.Add(this.btnSearchOperation);
            this.gbOperation.Controls.Add(this.txtOperationName);
            this.gbOperation.Controls.Add(this.label2);
            this.gbOperation.Controls.Add(this.txtOperationCode);
            this.gbOperation.Controls.Add(this.label1);
            this.gbOperation.Controls.Add(this.dgvOperation);
            this.gbOperation.Location = new System.Drawing.Point(378, 6);
            this.gbOperation.Name = "gbOperation";
            this.gbOperation.Size = new System.Drawing.Size(471, 486);
            this.gbOperation.TabIndex = 4;
            this.gbOperation.TabStop = false;
            this.gbOperation.Text = "手术信息一览";
            // 
            // chkShowSelected
            // 
            this.chkShowSelected.AutoSize = true;
            this.chkShowSelected.Location = new System.Drawing.Point(199, 53);
            this.chkShowSelected.Name = "chkShowSelected";
            this.chkShowSelected.Size = new System.Drawing.Size(182, 18);
            this.chkShowSelected.TabIndex = 29;
            this.chkShowSelected.Text = "搜索时显示所有已选中的项目";
            this.chkShowSelected.UseVisualStyleBackColor = true;
            this.chkShowSelected.Visible = false;
            // 
            // btnSearchOperation
            // 
            this.btnSearchOperation.Location = new System.Drawing.Point(345, 25);
            this.btnSearchOperation.Name = "btnSearchOperation";
            this.btnSearchOperation.Size = new System.Drawing.Size(75, 23);
            this.btnSearchOperation.TabIndex = 28;
            this.btnSearchOperation.Text = "搜索";
            this.btnSearchOperation.UseVisualStyleBackColor = true;
            this.btnSearchOperation.Click += new System.EventHandler(this.btnSearchOperation_Click);
            // 
            // txtOperationName
            // 
            this.txtOperationName.BindFieldName = "";
            this.txtOperationName.BindList = "";
            this.txtOperationName.BindTableName = "";
            this.txtOperationName.BorderColor = System.Drawing.Color.LightGray;
            this.txtOperationName.BottomLine = false;
            this.txtOperationName.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtOperationName.CanEdit = true;
            this.txtOperationName.CelerityInputCodeColumnName = "OPER_NAME";
            this.txtOperationName.CelerityInputSqlWhere = "";
            this.txtOperationName.CelerityInputTableName = "WIS_DICT_OPERATION";
            this.txtOperationName.CelerityInputValueColumnName = "OPER_CODE";
            this.txtOperationName.Data = null;
            this.txtOperationName.DefaultPrintText = "";
            this.txtOperationName.DictTableName = "WIS_DICT_OPERATION";
            this.txtOperationName.DictValueFieldName = "OPER_CODE";
            this.txtOperationName.DictWhereString = "";
            this.txtOperationName.DisplayFieldName = "OPER_NAME";
            this.txtOperationName.DotBorder = false;
            this.txtOperationName.DotNumber = 0;
            this.txtOperationName.ExamItemName = null;
            this.txtOperationName.FieldName = "txtSurgeonAssistant1";
            this.txtOperationName.Format = "";
            this.txtOperationName.HasLookUpItems = false;
            this.txtOperationName.InitValue = "";
            this.txtOperationName.InputNeededMessage = "";
            this.txtOperationName.InputType = Wis.Anes.Framework.Controls.MedInputType.General;
            this.txtOperationName.LabItemName = null;
            this.txtOperationName.LimitedString = "";
            this.txtOperationName.Location = new System.Drawing.Point(199, 26);
            this.txtOperationName.LockInput = false;
            this.txtOperationName.Maximum = null;
            this.txtOperationName.MaxLength = 20;
            this.txtOperationName.Minimum = null;
            this.txtOperationName.Multiline = false;
            this.txtOperationName.MultiSelect = false;
            this.txtOperationName.MultiSign = false;
            this.txtOperationName.Name = "txtOperationName";
            this.txtOperationName.NoPrint = false;
            this.txtOperationName.NoPrintText = "";
            this.txtOperationName.NullAble = true;
            this.txtOperationName.OldForeColor = System.Drawing.Color.Black;
            this.txtOperationName.PasswordChar = '\0';
            this.txtOperationName.PrintTail = "";
            this.txtOperationName.PrintXOffSet = 0F;
            this.txtOperationName.PrintYOffSet = 0F;
            this.txtOperationName.ProgramChanging = false;
            this.txtOperationName.Properties.Appearance.Options.UseTextOptions = true;
            this.txtOperationName.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtOperationName.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtOperationName.Properties.MaxLength = 20;
            this.txtOperationName.ReadOnly = false;
            this.txtOperationName.SelfValue = "";
            this.txtOperationName.SelfValueChanged = false;
            this.txtOperationName.Size = new System.Drawing.Size(118, 21);
            this.txtOperationName.SourceFieldName = "";
            this.txtOperationName.SourceTableName = "";
            this.txtOperationName.StoredValue = "";
            this.txtOperationName.TabIndex = 27;
            this.txtOperationName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtOperationName.UnderLineOffset = 0F;
            this.txtOperationName.WantValueBeforePrint = "";
            this.txtOperationName.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 14);
            this.label2.TabIndex = 26;
            this.label2.Text = "名称";
            // 
            // txtOperationCode
            // 
            this.txtOperationCode.BindFieldName = "";
            this.txtOperationCode.BindList = "";
            this.txtOperationCode.BindTableName = "";
            this.txtOperationCode.BorderColor = System.Drawing.Color.LightGray;
            this.txtOperationCode.BottomLine = false;
            this.txtOperationCode.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtOperationCode.CanEdit = true;
            this.txtOperationCode.CelerityInputCodeColumnName = "";
            this.txtOperationCode.CelerityInputSqlWhere = "";
            this.txtOperationCode.CelerityInputTableName = "";
            this.txtOperationCode.CelerityInputValueColumnName = "";
            this.txtOperationCode.Data = null;
            this.txtOperationCode.DefaultPrintText = "";
            this.txtOperationCode.DictTableName = "";
            this.txtOperationCode.DictValueFieldName = "";
            this.txtOperationCode.DictWhereString = "";
            this.txtOperationCode.DisplayFieldName = "";
            this.txtOperationCode.DotBorder = false;
            this.txtOperationCode.DotNumber = 0;
            this.txtOperationCode.ExamItemName = null;
            this.txtOperationCode.FieldName = "txtSurgeonAssistant1";
            this.txtOperationCode.Format = "";
            this.txtOperationCode.HasLookUpItems = false;
            this.txtOperationCode.InitValue = "";
            this.txtOperationCode.InputNeededMessage = "";
            this.txtOperationCode.InputType = Wis.Anes.Framework.Controls.MedInputType.General;
            this.txtOperationCode.LabItemName = null;
            this.txtOperationCode.LimitedString = "";
            this.txtOperationCode.Location = new System.Drawing.Point(56, 26);
            this.txtOperationCode.LockInput = false;
            this.txtOperationCode.Maximum = null;
            this.txtOperationCode.MaxLength = 8;
            this.txtOperationCode.Minimum = null;
            this.txtOperationCode.Multiline = false;
            this.txtOperationCode.MultiSelect = false;
            this.txtOperationCode.MultiSign = false;
            this.txtOperationCode.Name = "txtOperationCode";
            this.txtOperationCode.NoPrint = false;
            this.txtOperationCode.NoPrintText = "";
            this.txtOperationCode.NullAble = true;
            this.txtOperationCode.OldForeColor = System.Drawing.Color.Black;
            this.txtOperationCode.PasswordChar = '\0';
            this.txtOperationCode.PrintTail = "";
            this.txtOperationCode.PrintXOffSet = 0F;
            this.txtOperationCode.PrintYOffSet = 0F;
            this.txtOperationCode.ProgramChanging = false;
            this.txtOperationCode.Properties.Appearance.Options.UseTextOptions = true;
            this.txtOperationCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtOperationCode.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtOperationCode.Properties.MaxLength = 8;
            this.txtOperationCode.ReadOnly = false;
            this.txtOperationCode.SelfValue = "";
            this.txtOperationCode.SelfValueChanged = false;
            this.txtOperationCode.Size = new System.Drawing.Size(89, 21);
            this.txtOperationCode.SourceFieldName = "";
            this.txtOperationCode.SourceTableName = "";
            this.txtOperationCode.StoredValue = "";
            this.txtOperationCode.TabIndex = 25;
            this.txtOperationCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtOperationCode.UnderLineOffset = 0F;
            this.txtOperationCode.WantValueBeforePrint = "";
            this.txtOperationCode.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "编号";
            // 
            // gbUsers
            // 
            this.gbUsers.Controls.Add(this.btnSearchUser);
            this.gbUsers.Controls.Add(this.txtUserName);
            this.gbUsers.Controls.Add(this.label5);
            this.gbUsers.Controls.Add(this.txtDeptCode);
            this.gbUsers.Controls.Add(this.label3);
            this.gbUsers.Controls.Add(this.dgvUsers);
            this.gbUsers.Location = new System.Drawing.Point(12, 6);
            this.gbUsers.Name = "gbUsers";
            this.gbUsers.Size = new System.Drawing.Size(335, 486);
            this.gbUsers.TabIndex = 5;
            this.gbUsers.TabStop = false;
            this.gbUsers.Text = "用户信息列表";
            // 
            // btnSearchUser
            // 
            this.btnSearchUser.Location = new System.Drawing.Point(240, 52);
            this.btnSearchUser.Name = "btnSearchUser";
            this.btnSearchUser.Size = new System.Drawing.Size(89, 23);
            this.btnSearchUser.TabIndex = 32;
            this.btnSearchUser.Text = "搜索";
            this.btnSearchUser.UseVisualStyleBackColor = true;
            this.btnSearchUser.Click += new System.EventHandler(this.btnSearchUser_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.BindFieldName = "";
            this.txtUserName.BindList = "";
            this.txtUserName.BindTableName = "";
            this.txtUserName.BorderColor = System.Drawing.Color.LightGray;
            this.txtUserName.BottomLine = false;
            this.txtUserName.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtUserName.CanEdit = true;
            this.txtUserName.CelerityInputCodeColumnName = "USER_NAME";
            this.txtUserName.CelerityInputSqlWhere = "";
            this.txtUserName.CelerityInputTableName = "WIS_PERM_HIS_USER";
            this.txtUserName.CelerityInputValueColumnName = "USER_ID";
            this.txtUserName.Data = null;
            this.txtUserName.DefaultPrintText = "";
            this.txtUserName.DictTableName = "WIS_PERM_HIS_USER";
            this.txtUserName.DictValueFieldName = "USER_ID";
            this.txtUserName.DictWhereString = "";
            this.txtUserName.DisplayFieldName = "USER_NAME";
            this.txtUserName.DotBorder = false;
            this.txtUserName.DotNumber = 0;
            this.txtUserName.ExamItemName = null;
            this.txtUserName.FieldName = "txtSurgeonAssistant1";
            this.txtUserName.Format = "";
            this.txtUserName.HasLookUpItems = false;
            this.txtUserName.InitValue = "";
            this.txtUserName.InputNeededMessage = "";
            this.txtUserName.InputType = Wis.Anes.Framework.Controls.MedInputType.General;
            this.txtUserName.LabItemName = null;
            this.txtUserName.LimitedString = "";
            this.txtUserName.Location = new System.Drawing.Point(240, 25);
            this.txtUserName.LockInput = false;
            this.txtUserName.Maximum = null;
            this.txtUserName.MaxLength = 8;
            this.txtUserName.Minimum = null;
            this.txtUserName.Multiline = false;
            this.txtUserName.MultiSelect = false;
            this.txtUserName.MultiSign = false;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.NoPrint = false;
            this.txtUserName.NoPrintText = "";
            this.txtUserName.NullAble = true;
            this.txtUserName.OldForeColor = System.Drawing.Color.Black;
            this.txtUserName.PasswordChar = '\0';
            this.txtUserName.PrintTail = "";
            this.txtUserName.PrintXOffSet = 0F;
            this.txtUserName.PrintYOffSet = 0F;
            this.txtUserName.ProgramChanging = false;
            this.txtUserName.Properties.Appearance.Options.UseTextOptions = true;
            this.txtUserName.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtUserName.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtUserName.Properties.MaxLength = 8;
            this.txtUserName.ReadOnly = false;
            this.txtUserName.SelfValue = "";
            this.txtUserName.SelfValueChanged = false;
            this.txtUserName.Size = new System.Drawing.Size(89, 21);
            this.txtUserName.SourceFieldName = "";
            this.txtUserName.SourceTableName = "";
            this.txtUserName.StoredValue = "";
            this.txtUserName.TabIndex = 31;
            this.txtUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUserName.UnderLineOffset = 0F;
            this.txtUserName.WantValueBeforePrint = "";
            this.txtUserName.WordWrap = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(203, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 14);
            this.label5.TabIndex = 30;
            this.label5.Text = "姓名";
            // 
            // txtDeptCode
            // 
            this.txtDeptCode.BindFieldName = "";
            this.txtDeptCode.BindList = "";
            this.txtDeptCode.BindTableName = "";
            this.txtDeptCode.BorderColor = System.Drawing.Color.LightGray;
            this.txtDeptCode.BottomLine = false;
            this.txtDeptCode.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtDeptCode.CanEdit = false;
            this.txtDeptCode.CelerityInputCodeColumnName = "DEPT_NAME";
            this.txtDeptCode.CelerityInputSqlWhere = "";
            this.txtDeptCode.CelerityInputTableName = "WIS_DICT_DEPT";
            this.txtDeptCode.CelerityInputValueColumnName = "DEPT_CODE";
            this.txtDeptCode.Data = null;
            this.txtDeptCode.DefaultPrintText = "";
            this.txtDeptCode.DictTableName = "WIS_DICT_DEPT";
            this.txtDeptCode.DictValueFieldName = "DEPT_CODE";
            this.txtDeptCode.DictWhereString = "";
            this.txtDeptCode.DisplayFieldName = "DEPT_NAME";
            this.txtDeptCode.DotBorder = false;
            this.txtDeptCode.DotNumber = 0;
            this.txtDeptCode.ExamItemName = null;
            this.txtDeptCode.FieldName = "txtSurgeonAssistant1";
            this.txtDeptCode.Format = "";
            this.txtDeptCode.HasLookUpItems = false;
            this.txtDeptCode.InitValue = "";
            this.txtDeptCode.InputNeededMessage = "";
            this.txtDeptCode.InputType = Wis.Anes.Framework.Controls.MedInputType.General;
            this.txtDeptCode.LabItemName = null;
            this.txtDeptCode.LimitedString = "";
            this.txtDeptCode.Location = new System.Drawing.Point(43, 27);
            this.txtDeptCode.LockInput = false;
            this.txtDeptCode.Maximum = null;
            this.txtDeptCode.MaxLength = 8;
            this.txtDeptCode.Minimum = null;
            this.txtDeptCode.Multiline = false;
            this.txtDeptCode.MultiSelect = false;
            this.txtDeptCode.MultiSign = false;
            this.txtDeptCode.Name = "txtDeptCode";
            this.txtDeptCode.NoPrint = false;
            this.txtDeptCode.NoPrintText = "";
            this.txtDeptCode.NullAble = true;
            this.txtDeptCode.OldForeColor = System.Drawing.Color.Black;
            this.txtDeptCode.PasswordChar = '\0';
            this.txtDeptCode.PrintTail = "";
            this.txtDeptCode.PrintXOffSet = 0F;
            this.txtDeptCode.PrintYOffSet = 0F;
            this.txtDeptCode.ProgramChanging = false;
            this.txtDeptCode.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDeptCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtDeptCode.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtDeptCode.Properties.MaxLength = 8;
            this.txtDeptCode.ReadOnly = false;
            this.txtDeptCode.SelfValue = "";
            this.txtDeptCode.SelfValueChanged = false;
            this.txtDeptCode.Size = new System.Drawing.Size(117, 21);
            this.txtDeptCode.SourceFieldName = "";
            this.txtDeptCode.SourceTableName = "";
            this.txtDeptCode.StoredValue = "";
            this.txtDeptCode.TabIndex = 27;
            this.txtDeptCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDeptCode.UnderLineOffset = 0F;
            this.txtDeptCode.WantValueBeforePrint = "";
            this.txtDeptCode.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 14);
            this.label3.TabIndex = 26;
            this.label3.Text = "科室";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(646, 489);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 23);
            this.btnSave.TabIndex = 33;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(741, 489);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 23);
            this.btnClose.TabIndex = 34;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chk1
            // 
            this.chk1.HeaderText = "选择";
            this.chk1.Name = "chk1";
            this.chk1.Width = 40;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "OPERATION_CODE";
            this.Column1.HeaderText = "编号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "OPER_NAME";
            this.Column2.HeaderText = "手术名称";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "OPER_SCALE";
            this.Column3.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.Column3.HeaderText = "手术级别";
            this.Column3.Name = "Column3";
            // 
            // OperationScaleConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbUsers);
            this.Controls.Add(this.gbOperation);
            this.Name = "OperationScaleConfig";
            this.Size = new System.Drawing.Size(855, 538);
            this.Load += new System.EventHandler(this.OperationScaleConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperation)).EndInit();
            this.gbOperation.ResumeLayout(false);
            this.gbOperation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOperationName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOperationCode.Properties)).EndInit();
            this.gbUsers.ResumeLayout(false);
            this.gbUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeptCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.DataGridView dgvOperation;
        private System.Windows.Forms.GroupBox gbOperation;
        private System.Windows.Forms.Label label1;
        private Wis.Anes.Framework.Controls.DictTextBox txtSurgeonAssistant1;
        private Wis.Anes.Custom.CustomProject.Views.DictTextBox txtOperationCode;
        private Wis.Anes.Custom.CustomProject.Views.DictTextBox txtOperationName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearchOperation;
        private System.Windows.Forms.CheckBox chkShowSelected;
        private System.Windows.Forms.GroupBox gbUsers;
        private Wis.Anes.Custom.CustomProject.Views.DictTextBox txtDeptCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearchUser;
        private Wis.Anes.Custom.CustomProject.Views.DictTextBox txtUserName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column3;
    }
}
