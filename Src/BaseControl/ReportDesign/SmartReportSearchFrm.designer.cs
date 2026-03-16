namespace Com.ICIS.Icu
{
    partial class SmartReportSearchFrm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ok = new Com.MedicalSystem.Common.Controls.MedButton();
            this.btnCancel = new Com.MedicalSystem.Common.Controls.MedButton();
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.dataGridView1 = new Com.MedicalSystem.Common.Controls.MedDataGridView();
            this.TimePoint = new Com.MedicalSystem.Common.Controls.DataGridCalendarColumn();
            this.ReportName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReportMappingID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISVALID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReportClientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MapperData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateTime = new Com.MedicalSystem.Common.Controls.DataGridCalendarColumn();
            this.LastUpdateBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdateTime = new Com.MedicalSystem.Common.Controls.DataGridCalendarColumn();
            this.Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new DevExpress.XtraEditors.PanelControl();
            this.Last = new Com.MedicalSystem.Common.Controls.MedButton();
            this.next = new Com.MedicalSystem.Common.Controls.MedButton();
            this.Previous = new Com.MedicalSystem.Common.Controls.MedButton();
            this.First = new Com.MedicalSystem.Common.Controls.MedButton();
            this.Delete = new Com.MedicalSystem.Common.Controls.MedButton();
            this.panel2 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.medButton1 = new Com.MedicalSystem.Common.Controls.MedButton();
            this.dateTimePicker2 = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.dateTimePicker1 = new DevExpress.XtraEditors.DateEdit();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // ok
            // 
            this.ok.Cursor = System.Windows.Forms.Cursors.Hand;
            //this.ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ok.Location = new System.Drawing.Point(495, 11);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 1;
            this.ok.Text = "选择(&S)";
            //this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            //this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(587, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消(&C)";
            //this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(679, 432);
            this.panel1.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoDataError = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TimePoint,
            this.ReportName,
            this.ReportMappingID,
            this.ISVALID,
            this.ReportClientID,
            this.MapperData,
            this.CreateBy,
            this.CreateTime,
            this.LastUpdateBy,
            this.LastUpdateTime,
            this.Version});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.IsOwnerDrawColumnHead = true;
            this.dataGridView1.IsOwnerDrawRownHead = false;
            this.dataGridView1.Location = new System.Drawing.Point(0, 69);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(679, 321);
            this.dataGridView1.TabIndex = 5;
            // 
            // TimePoint
            // 
            this.TimePoint.DataPropertyName = "TimePoint";
            this.TimePoint.DateFormat = null;
            this.TimePoint.HeaderText = "时间点";
            this.TimePoint.Name = "TimePoint";
            this.TimePoint.ReadOnly = true;
            // 
            // ReportName
            // 
            this.ReportName.DataPropertyName = "ReportName";
            this.ReportName.HeaderText = "表单名称";
            this.ReportName.Name = "ReportName";
            this.ReportName.ReadOnly = true;
            // 
            // ReportMappingID
            // 
            this.ReportMappingID.DataPropertyName = "ReportMappingID";
            this.ReportMappingID.HeaderText = "ReportMappingID";
            this.ReportMappingID.Name = "ReportMappingID";
            this.ReportMappingID.ReadOnly = true;
            this.ReportMappingID.Visible = false;
            // 
            // ISVALID
            // 
            this.ISVALID.DataPropertyName = "ISVALID";
            this.ISVALID.HeaderText = "Column1";
            this.ISVALID.Name = "ISVALID";
            this.ISVALID.ReadOnly = true;
            this.ISVALID.Visible = false;
            // 
            // ReportClientID
            // 
            this.ReportClientID.DataPropertyName = "ReportClientID";
            this.ReportClientID.HeaderText = "ReportClientID";
            this.ReportClientID.Name = "ReportClientID";
            this.ReportClientID.ReadOnly = true;
            this.ReportClientID.Visible = false;
            // 
            // MapperData
            // 
            this.MapperData.DataPropertyName = "MapperData";
            this.MapperData.HeaderText = "MapperData";
            this.MapperData.Name = "MapperData";
            this.MapperData.ReadOnly = true;
            this.MapperData.Visible = false;
            // 
            // CreateBy
            // 
            this.CreateBy.DataPropertyName = "CreateBy";
            this.CreateBy.HeaderText = "创建人";
            this.CreateBy.Name = "CreateBy";
            this.CreateBy.ReadOnly = true;
            // 
            // CreateTime
            // 
            this.CreateTime.DataPropertyName = "CreateTime";
            this.CreateTime.DateFormat = null;
            this.CreateTime.HeaderText = "创建日期";
            this.CreateTime.Name = "CreateTime";
            this.CreateTime.ReadOnly = true;
            this.CreateTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CreateTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // LastUpdateBy
            // 
            this.LastUpdateBy.DataPropertyName = "LastUpdateBy";
            this.LastUpdateBy.HeaderText = "最后维护人";
            this.LastUpdateBy.Name = "LastUpdateBy";
            this.LastUpdateBy.ReadOnly = true;
            // 
            // LastUpdateTime
            // 
            this.LastUpdateTime.DataPropertyName = "LastUpdateTime";
            this.LastUpdateTime.DateFormat = null;
            this.LastUpdateTime.HeaderText = "最后维护时间";
            this.LastUpdateTime.Name = "LastUpdateTime";
            this.LastUpdateTime.ReadOnly = true;
            this.LastUpdateTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LastUpdateTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Version
            // 
            this.Version.DataPropertyName = "Version";
            this.Version.HeaderText = "版本";
            this.Version.Name = "Version";
            this.Version.ReadOnly = true;
            this.Version.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.Last);
            this.panel3.Controls.Add(this.next);
            this.panel3.Controls.Add(this.Previous);
            this.panel3.Controls.Add(this.First);
            this.panel3.Controls.Add(this.Delete);
            this.panel3.Controls.Add(this.ok);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 390);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(679, 42);
            this.panel3.TabIndex = 4;
            // 
            // Last
            // 
            this.Last.Cursor = System.Windows.Forms.Cursors.Hand;
            //this.Last.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Last.Location = new System.Drawing.Point(134, 11);
            this.Last.Name = "Last";
            this.Last.Size = new System.Drawing.Size(30, 23);
            this.Last.TabIndex = 1;
            this.Last.Text = ">>";
            //this.Last.UseVisualStyleBackColor = true;
            this.Last.Click += new System.EventHandler(this.Last_Click);
            // 
            // next
            // 
            this.next.Cursor = System.Windows.Forms.Cursors.Hand;
            //this.next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.next.Location = new System.Drawing.Point(98, 11);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(30, 23);
            this.next.TabIndex = 1;
            this.next.Text = ">";
            //this.next.UseVisualStyleBackColor = true;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // Previous
            // 
            this.Previous.Cursor = System.Windows.Forms.Cursors.Hand;
            //this.Previous.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Previous.Location = new System.Drawing.Point(62, 11);
            this.Previous.Name = "Previous";
            this.Previous.Size = new System.Drawing.Size(30, 23);
            this.Previous.TabIndex = 1;
            this.Previous.Text = "<";
            //this.Previous.UseVisualStyleBackColor = true;
            this.Previous.Click += new System.EventHandler(this.Previous_Click);
            // 
            // First
            // 
            this.First.Cursor = System.Windows.Forms.Cursors.Hand;
            //this.First.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.First.Location = new System.Drawing.Point(26, 11);
            this.First.Name = "First";
            this.First.Size = new System.Drawing.Size(30, 23);
            this.First.TabIndex = 1;
            this.First.Text = "<<";
            //this.First.UseVisualStyleBackColor = true;
            this.First.Click += new System.EventHandler(this.First_Click);
            // 
            // Delete
            // 
            this.Delete.Cursor = System.Windows.Forms.Cursors.Hand;
            //this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete.Location = new System.Drawing.Point(170, 11);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 23);
            this.Delete.TabIndex = 1;
            this.Delete.Text = "删除(&D)";
            //this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.medButton1);
            this.panel2.Controls.Add(this.dateTimePicker2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(679, 69);
            this.panel2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "开始日期：";
            // 
            // medButton1
            // 
            this.medButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            //this.medButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.medButton1.Location = new System.Drawing.Point(576, 22);
            this.medButton1.Name = "medButton1";
            this.medButton1.Size = new System.Drawing.Size(75, 23);
            this.medButton1.TabIndex = 4;
            this.medButton1.Text = "查询(&S)";
            //this.medButton1.UseVisualStyleBackColor = true;
            this.medButton1.Click += new System.EventHandler(this.medButton1_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(355, 22);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "结束日期：";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(72, 22);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // SmartReportSearchFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(686, 466);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SmartReportSearchFrm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查询选项";
            this.Load += new System.EventHandler(this.SmartReportSearchFrm_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Com.MedicalSystem.Common.Controls.MedButton ok;
        private Com.MedicalSystem.Common.Controls.MedButton btnCancel;
        private DevExpress.XtraEditors.PanelControl panel1;
        private Com.MedicalSystem.Common.Controls.MedDataGridView dataGridView1;
        private DevExpress.XtraEditors.PanelControl panel3;
        private DevExpress.XtraEditors.PanelControl panel2;
        private Com.MedicalSystem.Common.Controls.MedButton medButton1;
        private DevExpress.XtraEditors.DateEdit dateTimePicker2;
        private DevExpress.XtraEditors.LabelControl label2;
        private DevExpress.XtraEditors.DateEdit dateTimePicker1;
        private DevExpress.XtraEditors.LabelControl label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private Com.MedicalSystem.Common.Controls.MedButton Last;
        private Com.MedicalSystem.Common.Controls.MedButton next;
        private Com.MedicalSystem.Common.Controls.MedButton Previous;
        private Com.MedicalSystem.Common.Controls.MedButton First;
        private Com.MedicalSystem.Common.Controls.MedButton Delete;
        private Com.MedicalSystem.Common.Controls.DataGridCalendarColumn TimePoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportMappingID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISVALID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportClientID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MapperData;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateBy;
        private Com.MedicalSystem.Common.Controls.DataGridCalendarColumn CreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdateBy;
        private Com.MedicalSystem.Common.Controls.DataGridCalendarColumn LastUpdateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;
    }
}