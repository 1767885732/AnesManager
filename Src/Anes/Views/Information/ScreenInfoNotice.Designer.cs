namespace Wis.Anes.Views
{
    partial class ScreenInfoNotice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lbMsg = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkPreMsg = new System.Windows.Forms.CheckBox();
            this.lbMsgHeader = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.numUDNoticeTime = new System.Windows.Forms.NumericUpDown();
            this.dgvMsg = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNoticeContext = new Wis.Anes.Framework.Controls.DictTextBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDNoticeTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMsg)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoticeContext.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "公告次数";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "公告内容";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.lbMsg);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Location = new System.Drawing.Point(15, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(622, 73);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "消息预览";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(539, 44);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lbMsg
            // 
            this.lbMsg.AutoSize = true;
            this.lbMsg.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMsg.ForeColor = System.Drawing.Color.Maroon;
            this.lbMsg.Location = new System.Drawing.Point(10, 24);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(137, 14);
            this.lbMsg.TabIndex = 0;
            this.lbMsg.Text = "XX手术室XXX的家属";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(458, 44);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkPreMsg
            // 
            this.chkPreMsg.AutoSize = true;
            this.chkPreMsg.Checked = true;
            this.chkPreMsg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPreMsg.Location = new System.Drawing.Point(154, 48);
            this.chkPreMsg.Name = "chkPreMsg";
            this.chkPreMsg.Size = new System.Drawing.Size(108, 16);
            this.chkPreMsg.TabIndex = 6;
            this.chkPreMsg.Text = "自动附加消息头";
            this.chkPreMsg.UseVisualStyleBackColor = true;
            this.chkPreMsg.CheckedChanged += new System.EventHandler(this.chkPreMsg_CheckedChanged);
            // 
            // lbMsgHeader
            // 
            this.lbMsgHeader.AutoSize = true;
            this.lbMsgHeader.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMsgHeader.Location = new System.Drawing.Point(268, 50);
            this.lbMsgHeader.Name = "lbMsgHeader";
            this.lbMsgHeader.Size = new System.Drawing.Size(118, 12);
            this.lbMsgHeader.TabIndex = 7;
            this.lbMsgHeader.Text = "XX手术室XXX的家属";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(562, 344);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // numUDNoticeTime
            // 
            this.numUDNoticeTime.Location = new System.Drawing.Point(72, 46);
            this.numUDNoticeTime.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUDNoticeTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUDNoticeTime.Name = "numUDNoticeTime";
            this.numUDNoticeTime.Size = new System.Drawing.Size(46, 21);
            this.numUDNoticeTime.TabIndex = 10;
            this.numUDNoticeTime.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // dgvMsg
            // 
            this.dgvMsg.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMsg.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMsg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMsg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMsg.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMsg.Location = new System.Drawing.Point(6, 20);
            this.dgvMsg.Name = "dgvMsg";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMsg.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMsg.RowHeadersVisible = false;
            this.dgvMsg.RowTemplate.Height = 23;
            this.dgvMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvMsg.Size = new System.Drawing.Size(610, 152);
            this.dgvMsg.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvMsg);
            this.groupBox2.Location = new System.Drawing.Point(15, 160);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(622, 178);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "公告队列";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(512, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "（支持字典双击下拉）";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "INSERT_TIME";
            this.dataGridViewTextBoxColumn1.HeaderText = "添加时间";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 80;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "COUNTS";
            this.dataGridViewTextBoxColumn2.HeaderText = "次数";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 40;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 40;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "MSG";
            this.dataGridViewTextBoxColumn3.HeaderText = "公告内容";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 120;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            this.txtNoticeContext.CelerityInputSqlWhere = "ITEM_CLASS = \'家属公告信息\'";
            this.txtNoticeContext.CelerityInputTableName = "WIS_DICT_ANES_INPUT";
            this.txtNoticeContext.CelerityInputValueColumnName = "ITEM_CODE";
            this.txtNoticeContext.Data = null;
            this.txtNoticeContext.DefaultPrintText = "";
            this.txtNoticeContext.DictTableName = "WIS_DICT_ANES_INPUT";
            this.txtNoticeContext.DictValueFieldName = "ITEM_CODE";
            this.txtNoticeContext.DictWhereString = "ITEM_CLASS = \'家属公告信息\'";
            this.txtNoticeContext.DisplayFieldName = "ITEM_NAME";
            this.txtNoticeContext.DisplayMutiColFieldName = "";
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
            this.txtNoticeContext.Location = new System.Drawing.Point(72, 17);
            this.txtNoticeContext.LockInput = false;
            this.txtNoticeContext.Maximum = null;
            this.txtNoticeContext.MaxLength = 0;
            this.txtNoticeContext.Minimum = null;
            this.txtNoticeContext.Multiline = false;
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
            this.txtNoticeContext.Size = new System.Drawing.Size(565, 21);
            this.txtNoticeContext.SourceFieldName = "";
            this.txtNoticeContext.SourceTableName = "";
            this.txtNoticeContext.StoredValue = "";
            this.txtNoticeContext.TabIndex = 3;
            this.txtNoticeContext.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNoticeContext.UnderLineOffset = 0F;
            this.txtNoticeContext.WantValueBeforePrint = "";
            this.txtNoticeContext.WordWrap = false;
            this.txtNoticeContext.TextChanged += new System.EventHandler(this.txtNoticeContext_TextChanged);
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
            // Column3
            // 
            this.Column3.DataPropertyName = "COUNTS";
            this.Column3.HeaderText = "次数";
            this.Column3.MinimumWidth = 40;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 40;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "MSG";
            this.Column2.HeaderText = "公告内容";
            this.Column2.MinimumWidth = 120;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ScreenInfoNotice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.numUDNoticeTime);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbMsgHeader);
            this.Controls.Add(this.chkPreMsg);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNoticeContext);
            this.Controls.Add(this.label1);
            this.Name = "ScreenInfoNotice";
            this.Size = new System.Drawing.Size(668, 370);
            this.Load += new System.EventHandler(this.ScreenInfoNotice_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDNoticeTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMsg)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtNoticeContext.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Wis.Anes.Framework.Controls.DictTextBox txtNoticeContext;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbMsg;
        private System.Windows.Forms.CheckBox chkPreMsg;
        private System.Windows.Forms.Label lbMsgHeader;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.NumericUpDown numUDNoticeTime;
        private System.Windows.Forms.DataGridView dgvMsg;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}
