namespace Wis.Anes.Views
{
    partial class FloatFrm
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
            this.timeEvent = new System.Windows.Forms.DateTimePicker();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtPinYing = new DevExpress.XtraEditors.TextEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPinYing.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timeEvent
            // 
            this.timeEvent.CustomFormat = "HH:mm";
            this.timeEvent.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeEvent.Location = new System.Drawing.Point(112, 18);
            this.timeEvent.Name = "timeEvent";
            this.timeEvent.Size = new System.Drawing.Size(93, 26);
            this.timeEvent.TabIndex = 4;
            this.timeEvent.Visible = false;
            // 
            // textEdit1
            // 
            this.textEdit1.EditValue = "";
            this.textEdit1.Location = new System.Drawing.Point(744, 37);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEdit1.Properties.MaxLength = 8;
            this.textEdit1.Size = new System.Drawing.Size(47, 24);
            this.textEdit1.TabIndex = 5;
            this.textEdit1.ToolTip = "若为无剂量项目请在键盘输入\"+\"键";
            this.textEdit1.Visible = false;
            this.textEdit1.Leave += new System.EventHandler(this.textEdit1_Leave);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(608, 455);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(79, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定";
            this.btnOK.Visible = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(702, 455);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(11, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(129, 20);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "拼音快速检索";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtPinYing);
            this.panelControl1.Controls.Add(this.panel1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(335, 438);
            this.panelControl1.TabIndex = 9;
            // 
            // txtPinYing
            // 
            this.txtPinYing.EditValue = "";
            this.txtPinYing.Location = new System.Drawing.Point(177, 6);
            this.txtPinYing.Name = "txtPinYing";
            this.txtPinYing.Size = new System.Drawing.Size(153, 24);
            this.txtPinYing.TabIndex = 0;
            this.txtPinYing.ToolTip = "拼音搜索字符串";
            this.txtPinYing.EditValueChanged += new System.EventHandler(this.txtPinYing_EditValueChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.timeEvent);
            this.panel1.Location = new System.Drawing.Point(10, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 356);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // FloatFrm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(810, 462);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.LookAndFeel.SkinName = "Office 2013";
            this.MaximizeBox = false;
            this.Name = "FloatFrm";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 24);
            this.Text = "FloatFrm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FloatFrm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FloatFrm_FormClosed);
            this.Load += new System.EventHandler(this.FloatFrm_Load);
            this.TextChanged += new System.EventHandler(this.FloatFrm_TextChanged);
            this.Resize += new System.EventHandler(this.FloatFrm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPinYing.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker timeEvent;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.Label lblTitle;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.TextEdit txtPinYing;
    }
}