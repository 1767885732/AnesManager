namespace Wis.Anes.Views
{
    partial class OperationDocQualityControl
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
            this.dgvDocCheck = new System.Windows.Forms.DataGridView();
            this.ColumnPatientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnVisitID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOperID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOperationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOperationRoom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOperationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPatient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOperationStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAnesDoctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimePickerQuery = new DevExpress.XtraEditors.DateEdit();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.txtOtherUse = new Wis.Anes.Framework.Controls.DictTextBox();
            this.radioType = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimePickerQuery.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimePickerQuery.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherUse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDocCheck
            // 
            this.dgvDocCheck.AllowUserToAddRows = false;
            this.dgvDocCheck.AllowUserToDeleteRows = false;
            this.dgvDocCheck.AllowUserToResizeColumns = false;
            this.dgvDocCheck.AllowUserToResizeRows = false;
            this.dgvDocCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDocCheck.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDocCheck.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocCheck.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPatientID,
            this.ColumnVisitID,
            this.ColumnOperID,
            this.ColumnOperationDate,
            this.ColumnOperationRoom,
            this.ColumnOperationName,
            this.ColumnPatient,
            this.ColumnOperationStatus,
            this.ColumnAnesDoctor});
            this.dgvDocCheck.Location = new System.Drawing.Point(6, 43);
            this.dgvDocCheck.Name = "dgvDocCheck";
            this.dgvDocCheck.ReadOnly = true;
            this.dgvDocCheck.RowHeadersVisible = false;
            this.dgvDocCheck.RowTemplate.Height = 23;
            this.dgvDocCheck.Size = new System.Drawing.Size(1217, 417);
            this.dgvDocCheck.TabIndex = 0;
            // 
            // ColumnPatientID
            // 
            this.ColumnPatientID.Frozen = true;
            this.ColumnPatientID.HeaderText = "PatientID";
            this.ColumnPatientID.Name = "ColumnPatientID";
            this.ColumnPatientID.ReadOnly = true;
            this.ColumnPatientID.Visible = false;
            // 
            // ColumnVisitID
            // 
            this.ColumnVisitID.Frozen = true;
            this.ColumnVisitID.HeaderText = "ColumnVisitID";
            this.ColumnVisitID.Name = "ColumnVisitID";
            this.ColumnVisitID.ReadOnly = true;
            this.ColumnVisitID.Visible = false;
            // 
            // ColumnOperID
            // 
            this.ColumnOperID.Frozen = true;
            this.ColumnOperID.HeaderText = "ColumnOperID";
            this.ColumnOperID.Name = "ColumnOperID";
            this.ColumnOperID.ReadOnly = true;
            this.ColumnOperID.Visible = false;
            // 
            // ColumnOperationDate
            // 
            this.ColumnOperationDate.HeaderText = "手术日期";
            this.ColumnOperationDate.MinimumWidth = 100;
            this.ColumnOperationDate.Name = "ColumnOperationDate";
            this.ColumnOperationDate.ReadOnly = true;
            this.ColumnOperationDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnOperationRoom
            // 
            this.ColumnOperationRoom.HeaderText = "手术间";
            this.ColumnOperationRoom.MinimumWidth = 60;
            this.ColumnOperationRoom.Name = "ColumnOperationRoom";
            this.ColumnOperationRoom.ReadOnly = true;
            this.ColumnOperationRoom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnOperationRoom.Width = 60;
            // 
            // ColumnOperationName
            // 
            this.ColumnOperationName.HeaderText = "手术名称";
            this.ColumnOperationName.MinimumWidth = 100;
            this.ColumnOperationName.Name = "ColumnOperationName";
            this.ColumnOperationName.ReadOnly = true;
            // 
            // ColumnPatient
            // 
            this.ColumnPatient.HeaderText = "患者";
            this.ColumnPatient.MinimumWidth = 60;
            this.ColumnPatient.Name = "ColumnPatient";
            this.ColumnPatient.ReadOnly = true;
            this.ColumnPatient.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnPatient.Width = 60;
            // 
            // ColumnOperationStatus
            // 
            this.ColumnOperationStatus.HeaderText = "状态";
            this.ColumnOperationStatus.MinimumWidth = 60;
            this.ColumnOperationStatus.Name = "ColumnOperationStatus";
            this.ColumnOperationStatus.ReadOnly = true;
            this.ColumnOperationStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnOperationStatus.Width = 60;
            // 
            // ColumnAnesDoctor
            // 
            this.ColumnAnesDoctor.HeaderText = "麻醉医生";
            this.ColumnAnesDoctor.MinimumWidth = 80;
            this.ColumnAnesDoctor.Name = "ColumnAnesDoctor";
            this.ColumnAnesDoctor.ReadOnly = true;
            this.ColumnAnesDoctor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnAnesDoctor.Width = 80;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "手术间";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 60;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "患者名称";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 60;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 60;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "手术状态";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 60;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "麻醉医生";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 60;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 60;
            // 
            // dateTimePickerQuery
            // 
            this.dateTimePickerQuery.EditValue = null;
            this.dateTimePickerQuery.Location = new System.Drawing.Point(294, 14);
            this.dateTimePickerQuery.Name = "dateTimePickerQuery";
            this.dateTimePickerQuery.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTimePickerQuery.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateTimePickerQuery.Size = new System.Drawing.Size(175, 21);
            this.dateTimePickerQuery.TabIndex = 82;
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Location = new System.Drawing.Point(475, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(50, 25);
            this.btnSearch.TabIndex = 85;
            this.btnSearch.Text = "搜索";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            this.txtOtherUse.Location = new System.Drawing.Point(195, 14);
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
            this.txtOtherUse.TabIndex = 91;
            this.txtOtherUse.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtOtherUse.UnderLineOffset = 0F;
            this.txtOtherUse.WantValueBeforePrint = "";
            this.txtOtherUse.WordWrap = false;
            // 
            // radioType
            // 
            this.radioType.Location = new System.Drawing.Point(21, 13);
            this.radioType.Name = "radioType";
            this.radioType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "全部"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "本人的")});
            this.radioType.Size = new System.Drawing.Size(121, 23);
            this.radioType.TabIndex = 90;
            this.radioType.SelectedIndexChanged += new System.EventHandler(this.radioType_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(153, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 92;
            this.labelControl1.Text = "其他人";
            // 
            // OperationDocQualityControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtOtherUse);
            this.Controls.Add(this.radioType);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dateTimePickerQuery);
            this.Controls.Add(this.dgvDocCheck);
            this.Name = "OperationDocQualityControl";
            this.Size = new System.Drawing.Size(1230, 467);
            this.Load += new System.EventHandler(this.OperationDocQualityControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimePickerQuery.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimePickerQuery.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherUse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioType.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDocCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DevExpress.XtraEditors.DateEdit dateTimePickerQuery;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPatientID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnVisitID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOperID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOperationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOperationRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOperationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOperationStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAnesDoctor;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private Wis.Anes.Framework.Controls.DictTextBox txtOtherUse;
        private DevExpress.XtraEditors.RadioGroup radioType;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
