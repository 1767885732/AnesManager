namespace Com.ICIS.Icu
{
    partial class FormatFrm
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
            this.listBox1 = new DevExpress.XtraEditors.ListBoxControl();
            this.btnConfirm = new Com.MedicalSystem.Common.Controls.MedButton();
            this.btnCancel = new Com.MedicalSystem.Common.Controls.MedButton();
            this.groupBox1 = new DevExpress.XtraEditors.GroupControl();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.textBox1 = new DevExpress.XtraEditors.TextEdit();
            this.cmbType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(3, 46);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(361, 304);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            //this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Location = new System.Drawing.Point(167, 392);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "确定";
            //this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            //this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(276, 392);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "放弃";
            //this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 353);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置格式";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(193, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 12);
            this.label1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(4, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(183, 21);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // cmbType
            // 
            this.cmbType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbType.Enabled = false;

            this.cmbType.Properties.Items.AddRange(new object[] {
            "日期类型",
            "数值类型"});
            this.cmbType.Location = new System.Drawing.Point(12, 12);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(158, 20);
            this.cmbType.TabIndex = 3;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbType);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 432);
            this.panel1.TabIndex = 4;
            // 
            // FormatFrm
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(391, 466);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormatFrm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormatFrm";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ListBoxControl listBox1;
        private DevExpress.XtraEditors.GroupControl groupBox1;
        private DevExpress.XtraEditors.TextEdit textBox1;
        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbType;
        private Com.MedicalSystem.Common.Controls.MedButton btnConfirm;
        private Com.MedicalSystem.Common.Controls.MedButton btnCancel;
        private DevExpress.XtraEditors.PanelControl panel1;
    }
}