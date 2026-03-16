namespace Wis.Anes.Views.Information
{
    partial class OperationNotice
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoticeContext = new Wis.Anes.Framework.Controls.DictTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvMsg = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbMsg = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoticeContext.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMsg)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "通知内容：";
            // 
            // txtNoticeContext
            // 
            this.txtNoticeContext.BindFieldName = "";
            this.txtNoticeContext.BindList = "";
            this.txtNoticeContext.BindTableName = "";
            this.txtNoticeContext.BorderColor = System.Drawing.Color.LightGray;
            this.txtNoticeContext.BottomLine = false;
            this.txtNoticeContext.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtNoticeContext.CanEdit = true;
            this.txtNoticeContext.CelerityInputCodeColumnName = "ITEM_NAME";
            this.txtNoticeContext.CelerityInputSqlWhere = "ITEM_CLASS = \'手术提醒信息\'";
            this.txtNoticeContext.CelerityInputTableName = "WIS_DICT_ANES_INPUT";
            this.txtNoticeContext.CelerityInputValueColumnName = "ITEM_CODE";
            this.txtNoticeContext.Data = null;
            this.txtNoticeContext.DefaultPrintText = "";
            this.txtNoticeContext.DictTableName = "WIS_DICT_ANES_INPUT";
            this.txtNoticeContext.DictValueFieldName = "ITEM_CODE";
            this.txtNoticeContext.DictWhereString = "ITEM_CLASS = \'手术提醒信息\'";
            this.txtNoticeContext.DisplayFieldName = "ITEM_NAME";
            this.txtNoticeContext.DotBorder = false;
            this.txtNoticeContext.DotNumber = 0;
            this.txtNoticeContext.EditValue = "";
            this.txtNoticeContext.ExamItemName = null;
            this.txtNoticeContext.FieldName = "txtNoticeTime";
            this.txtNoticeContext.Format = "";
            this.txtNoticeContext.HasLookUpItems = false;
            this.txtNoticeContext.InitValue = "";
            this.txtNoticeContext.InputNeededMessage = "";
            this.txtNoticeContext.InputType = Wis.Anes.Framework.Controls.MedInputType.General;
            this.txtNoticeContext.LabItemName = null;
            this.txtNoticeContext.LimitedString = "";
            this.txtNoticeContext.Location = new System.Drawing.Point(76, 21);
            this.txtNoticeContext.LockInput = false;
            this.txtNoticeContext.Maximum = null;
            this.txtNoticeContext.MaxLength = 0;
            this.txtNoticeContext.Minimum = null;
            this.txtNoticeContext.Multiline = true;
            this.txtNoticeContext.MultiSelect = false;
            this.txtNoticeContext.MultiSign = false;
            this.txtNoticeContext.Name = "txtNoticeContext";
            this.txtNoticeContext.NoPrint = false;
            this.txtNoticeContext.NoPrintText = "";
            this.txtNoticeContext.NullAble = true;
            this.txtNoticeContext.OldForeColor = System.Drawing.Color.Black;
            this.txtNoticeContext.PasswordChar = '\0';
            this.txtNoticeContext.PrintTail = "";
            this.txtNoticeContext.PrintXOffSet = 0F;
            this.txtNoticeContext.PrintYOffSet = 0F;
            this.txtNoticeContext.ProgramChanging = false;
            this.txtNoticeContext.Properties.Appearance.Options.UseTextOptions = true;
            this.txtNoticeContext.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtNoticeContext.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtNoticeContext.ReadOnly = false;
            this.txtNoticeContext.SelfValue = "";
            this.txtNoticeContext.SelfValueChanged = false;
            this.txtNoticeContext.Size = new System.Drawing.Size(500, 21);
            this.txtNoticeContext.SourceFieldName = "";
            this.txtNoticeContext.SourceTableName = "";
            this.txtNoticeContext.StoredValue = "";
            this.txtNoticeContext.TabIndex = 4;
            this.txtNoticeContext.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNoticeContext.UnderLineOffset = 0F;
            this.txtNoticeContext.WantValueBeforePrint = "";
            this.txtNoticeContext.WordWrap = false;
            this.txtNoticeContext.TextChanged += new System.EventHandler(this.txtNoticeContext_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvMsg);
            this.groupBox2.Location = new System.Drawing.Point(16, 221);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 153);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "通知队列";
            // 
            // dgvMsg
            // 
            this.dgvMsg.BackgroundColor = System.Drawing.Color.White;
            this.dgvMsg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMsg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvMsg.Location = new System.Drawing.Point(1, 17);
            this.dgvMsg.Name = "dgvMsg";
            this.dgvMsg.RowHeadersVisible = false;
            this.dgvMsg.RowTemplate.Height = 23;
            this.dgvMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvMsg.Size = new System.Drawing.Size(553, 130);
            this.dgvMsg.TabIndex = 11;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(485, 380);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(64, 20);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbMsg);
            this.groupBox1.Location = new System.Drawing.Point(17, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(559, 122);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "消息预览";
            // 
            // lbMsg
            // 
            this.lbMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMsg.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMsg.ForeColor = System.Drawing.Color.Maroon;
            this.lbMsg.Location = new System.Drawing.Point(3, 17);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(553, 102);
            this.lbMsg.TabIndex = 0;
            this.lbMsg.Text = "XX科室的护士";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(485, 190);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(64, 20);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(398, 190);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 20);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "INSERT_TIME";
            this.Column1.HeaderText = "添加时间";
            this.Column1.MinimumWidth = 80;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 120;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "MSG";
            this.Column2.HeaderText = "通知内容";
            this.Column2.MinimumWidth = 120;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // OperationNotice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtNoticeContext);
            this.Controls.Add(this.label1);
            this.Name = "OperationNotice";
            this.Size = new System.Drawing.Size(579, 415);
            this.Load += new System.EventHandler(this.OperationNotification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtNoticeContext.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMsg)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Wis.Anes.Framework.Controls.DictTextBox txtNoticeContext;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvMsg;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lbMsg;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}
