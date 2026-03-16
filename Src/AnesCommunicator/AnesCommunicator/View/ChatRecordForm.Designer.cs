namespace AnesCommunicator.View
{
    partial class ChatRecordForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lblAlarm = new System.Windows.Forms.Label();
            this.btnSendAll = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtMessageRecord = new System.Windows.Forms.RichTextBox();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnRight = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.btnLeft = new DevExpress.XtraEditors.SimpleButton();
            this.txtFilter = new DevExpress.XtraEditors.TextEdit();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.lblAlarm);
            this.panelControl2.Controls.Add(this.btnSendAll);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 432);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(523, 48);
            this.panelControl2.TabIndex = 3;
            // 
            // lblAlarm
            // 
            this.lblAlarm.AutoSize = true;
            this.lblAlarm.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblAlarm.ForeColor = System.Drawing.Color.Red;
            this.lblAlarm.Location = new System.Drawing.Point(5, 18);
            this.lblAlarm.Name = "lblAlarm";
            this.lblAlarm.Size = new System.Drawing.Size(0, 14);
            this.lblAlarm.TabIndex = 6;
            // 
            // btnSendAll
            // 
            this.btnSendAll.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnSendAll.Appearance.Options.UseFont = true;
            this.btnSendAll.Location = new System.Drawing.Point(424, 10);
            this.btnSendAll.Name = "btnSendAll";
            this.btnSendAll.Size = new System.Drawing.Size(87, 30);
            this.btnSendAll.TabIndex = 2;
            this.btnSendAll.Text = "退出";
            this.btnSendAll.Click += new System.EventHandler(this.btnSendAll_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtMessageRecord);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 40);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(523, 392);
            this.panelControl1.TabIndex = 4;
            // 
            // txtMessageRecord
            // 
            this.txtMessageRecord.AutoWordSelection = true;
            this.txtMessageRecord.BackColor = System.Drawing.Color.White;
            this.txtMessageRecord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessageRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessageRecord.HideSelection = false;
            this.txtMessageRecord.Location = new System.Drawing.Point(2, 2);
            this.txtMessageRecord.Name = "txtMessageRecord";
            this.txtMessageRecord.ReadOnly = true;
            this.txtMessageRecord.Size = new System.Drawing.Size(519, 388);
            this.txtMessageRecord.TabIndex = 2;
            this.txtMessageRecord.Text = "";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnRight);
            this.panelControl3.Controls.Add(this.btnSearch);
            this.panelControl3.Controls.Add(this.btnLeft);
            this.panelControl3.Controls.Add(this.txtFilter);
            this.panelControl3.Controls.Add(this.dtpDate);
            this.panelControl3.Controls.Add(this.label1);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(523, 29);
            this.panelControl3.TabIndex = 4;
            // 
            // btnRight
            // 
            this.btnRight.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnRight.Appearance.Options.UseFont = true;
            this.btnRight.Location = new System.Drawing.Point(225, 4);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(44, 22);
            this.btnRight.TabIndex = 7;
            this.btnRight.Text = ">";
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.Location = new System.Drawing.Point(467, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(44, 22);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "搜索";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnLeft.Appearance.Options.UseFont = true;
            this.btnLeft.Location = new System.Drawing.Point(177, 4);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(44, 22);
            this.btnLeft.TabIndex = 7;
            this.btnLeft.Text = "<";
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(345, 5);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(116, 21);
            this.txtFilter.TabIndex = 6;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(58, 5);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(115, 22);
            this.dtpDate.TabIndex = 5;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.Appearance.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.label1.Appearance.Options.UseFont = true;
            this.label1.Appearance.Options.UseForeColor = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "日期:";
            // 
            // ChatRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 480);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.Name = "ChatRecordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "消息记录";
            this.Load += new System.EventHandler(this.ChatRecordForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSendAll;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.LabelControl label1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblAlarm;
        private DevExpress.XtraEditors.TextEdit txtFilter;
        private System.Windows.Forms.RichTextBox txtMessageRecord;
        private DevExpress.XtraEditors.SimpleButton btnRight;
        private DevExpress.XtraEditors.SimpleButton btnLeft;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
    }
}