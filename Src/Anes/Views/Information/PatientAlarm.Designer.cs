namespace Wis.Anes.Views
{
    partial class PatientAlarm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvMsgAlarm = new System.Windows.Forms.DataGridView();
            this.Patient_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VISIT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OPER_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MSG_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMsg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.Msg = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMsgAlarm)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMsgAlarm
            // 
            this.dgvMsgAlarm.AllowUserToAddRows = false;
            this.dgvMsgAlarm.AllowUserToDeleteRows = false;
            this.dgvMsgAlarm.AllowUserToResizeColumns = false;
            this.dgvMsgAlarm.AllowUserToResizeRows = false;
            this.dgvMsgAlarm.BackgroundColor = System.Drawing.Color.White;
            this.dgvMsgAlarm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMsgAlarm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Patient_ID,
            this.VISIT_ID,
            this.OPER_ID,
            this.MSG_NO,
            this.colCheck,
            this.colTime,
            this.colMsg});
            this.dgvMsgAlarm.Location = new System.Drawing.Point(0, 3);
            this.dgvMsgAlarm.Name = "dgvMsgAlarm";
            this.dgvMsgAlarm.RowHeadersVisible = false;
            this.dgvMsgAlarm.RowTemplate.Height = 23;
            this.dgvMsgAlarm.Size = new System.Drawing.Size(580, 299);
            this.dgvMsgAlarm.TabIndex = 0;
            this.dgvMsgAlarm.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMsgAlarm_CellContentDoubleClick);
            this.dgvMsgAlarm.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvMsgAlarm_CellPainting);
            this.dgvMsgAlarm.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMsgAlarm_CellContentClick);
            // 
            // Patient_ID
            // 
            this.Patient_ID.DataPropertyName = "PAT_ID";
            this.Patient_ID.HeaderText = "Patient_ID";
            this.Patient_ID.Name = "Patient_ID";
            this.Patient_ID.Visible = false;
            // 
            // VISIT_ID
            // 
            this.VISIT_ID.DataPropertyName = "VISIT_ID";
            this.VISIT_ID.HeaderText = "VISIT_ID";
            this.VISIT_ID.Name = "VISIT_ID";
            this.VISIT_ID.Visible = false;
            // 
            // OPER_ID
            // 
            this.OPER_ID.DataPropertyName = "OPER_ID";
            this.OPER_ID.HeaderText = "OPER_ID";
            this.OPER_ID.Name = "OPER_ID";
            this.OPER_ID.Visible = false;
            // 
            // MSG_NO
            // 
            this.MSG_NO.DataPropertyName = "MSG_NO";
            this.MSG_NO.HeaderText = "MSG_NO";
            this.MSG_NO.Name = "MSG_NO";
            this.MSG_NO.Visible = false;
            // 
            // colCheck
            // 
            this.colCheck.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colCheck.DataPropertyName = "READ_FLAG";
            this.colCheck.FalseValue = "0";
            this.colCheck.HeaderText = "已读";
            this.colCheck.MinimumWidth = 40;
            this.colCheck.Name = "colCheck";
            this.colCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colCheck.TrueValue = "1";
            this.colCheck.Width = 56;
            // 
            // colTime
            // 
            this.colTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTime.DataPropertyName = "MSG_TIME";
            dataGridViewCellStyle2.Format = "T";
            dataGridViewCellStyle2.NullValue = null;
            this.colTime.DefaultCellStyle = dataGridViewCellStyle2;
            this.colTime.HeaderText = "时间";
            this.colTime.MinimumWidth = 100;
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            // 
            // colMsg
            // 
            this.colMsg.DataPropertyName = "MSG";
            this.colMsg.HeaderText = "消息";
            this.colMsg.MinimumWidth = 420;
            this.colMsg.Name = "colMsg";
            this.colMsg.ReadOnly = true;
            this.colMsg.Width = 420;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(406, 309);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 27);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(493, 309);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 27);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Msg
            // 
            this.Msg.AutoSize = true;
            this.Msg.Location = new System.Drawing.Point(3, 315);
            this.Msg.Name = "Msg";
            this.Msg.Size = new System.Drawing.Size(91, 14);
            this.Msg.TabIndex = 2;
            this.Msg.Text = "当前无未读信息";
            // 
            // PatientAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Msg);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvMsgAlarm);
            this.Name = "PatientAlarm";
            this.Size = new System.Drawing.Size(583, 350);
            this.Load += new System.EventHandler(this.PatientAlarm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMsgAlarm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMsgAlarm;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label Msg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Patient_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn VISIT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn OPER_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MSG_NO;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMsg;

    }
}
