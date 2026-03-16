namespace Wis.Anes.Layouts
{
    partial class TopBarControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TopBarControl));
            this.lblName = new DevExpress.XtraEditors.LabelControl();
            this.lblPatientID = new DevExpress.XtraEditors.LabelControl();
            this.lblRoomNo = new DevExpress.XtraEditors.LabelControl();
            this.picPersonIcon = new System.Windows.Forms.PictureBox();
            this.picTopSpliter = new System.Windows.Forms.PictureBox();
            this.lblPatInfoLine = new DevExpress.XtraEditors.LabelControl();
            this.lblPatInfo = new DevExpress.XtraEditors.LabelControl();
            this.picLogo = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.btnRefreshStatus = new DevExpress.XtraEditors.SimpleButton();
            this.mecicalDocBarControl1 = new Wis.Anes.Layouts.MecicalDocBarControl();
            this.patientStatusContrl1 = new Wis.Anes.Framework.Views.PatientStatusContrl();
            this.LogButton = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.picPersonIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTopSpliter)).BeginInit();
            this.picLogo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Appearance.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblName.Appearance.Options.UseBackColor = true;
            this.lblName.Appearance.Options.UseFont = true;
            this.lblName.Appearance.Options.UseForeColor = true;
            this.lblName.Appearance.Options.UseTextOptions = true;
            this.lblName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblName.Location = new System.Drawing.Point(107, 54);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(125, 21);
            this.lblName.TabIndex = 53;
            this.lblName.Text = "<姓名>";
            this.lblName.Visible = false;
            this.lblName.Click += new System.EventHandler(this.lblName_Click);
            // 
            // lblPatientID
            // 
            this.lblPatientID.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblPatientID.Appearance.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPatientID.Appearance.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblPatientID.Appearance.Options.UseBackColor = true;
            this.lblPatientID.Appearance.Options.UseFont = true;
            this.lblPatientID.Appearance.Options.UseForeColor = true;
            this.lblPatientID.Appearance.Options.UseTextOptions = true;
            this.lblPatientID.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblPatientID.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblPatientID.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblPatientID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPatientID.Location = new System.Drawing.Point(107, 24);
            this.lblPatientID.Name = "lblPatientID";
            this.lblPatientID.Size = new System.Drawing.Size(125, 21);
            this.lblPatientID.TabIndex = 52;
            this.lblPatientID.Text = "<患者ID>";
            this.lblPatientID.Visible = false;
            this.lblPatientID.Click += new System.EventHandler(this.lblPatientID_Click);
            // 
            // lblRoomNo
            // 
            this.lblRoomNo.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblRoomNo.Appearance.Font = new System.Drawing.Font("Arial Black", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomNo.Appearance.ForeColor = System.Drawing.Color.IndianRed;
            this.lblRoomNo.Appearance.Options.UseBackColor = true;
            this.lblRoomNo.Appearance.Options.UseFont = true;
            this.lblRoomNo.Appearance.Options.UseForeColor = true;
            this.lblRoomNo.Appearance.Options.UseTextOptions = true;
            this.lblRoomNo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblRoomNo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lblRoomNo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblRoomNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRoomNo.Location = new System.Drawing.Point(6, 9);
            this.lblRoomNo.Name = "lblRoomNo";
            this.lblRoomNo.Size = new System.Drawing.Size(70, 66);
            this.lblRoomNo.TabIndex = 51;
            this.lblRoomNo.Click += new System.EventHandler(this.lblRoomNo_Click);
            // 
            // picPersonIcon
            // 
            this.picPersonIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPersonIcon.Location = new System.Drawing.Point(79, 25);
            this.picPersonIcon.Name = "picPersonIcon";
            this.picPersonIcon.Size = new System.Drawing.Size(17, 20);
            this.picPersonIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPersonIcon.TabIndex = 57;
            this.picPersonIcon.TabStop = false;
            this.picPersonIcon.Click += new System.EventHandler(this.picPersonIcon_Click);
            // 
            // picTopSpliter
            // 
            this.picTopSpliter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picTopSpliter.Dock = System.Windows.Forms.DockStyle.Right;
            this.picTopSpliter.Location = new System.Drawing.Point(239, 0);
            this.picTopSpliter.Name = "picTopSpliter";
            this.picTopSpliter.Size = new System.Drawing.Size(3, 94);
            this.picTopSpliter.TabIndex = 56;
            this.picTopSpliter.TabStop = false;
            // 
            // lblPatInfoLine
            // 
            this.lblPatInfoLine.Appearance.Options.UseImage = true;
            this.lblPatInfoLine.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblPatInfoLine.Enabled = false;
            this.lblPatInfoLine.Location = new System.Drawing.Point(98, 50);
            this.lblPatInfoLine.Name = "lblPatInfoLine";
            this.lblPatInfoLine.Size = new System.Drawing.Size(128, 1);
            this.lblPatInfoLine.TabIndex = 55;
            // 
            // lblPatInfo
            // 
            this.lblPatInfo.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblPatInfo.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPatInfo.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblPatInfo.Appearance.Options.UseBackColor = true;
            this.lblPatInfo.Appearance.Options.UseFont = true;
            this.lblPatInfo.Appearance.Options.UseForeColor = true;
            this.lblPatInfo.Appearance.Options.UseTextOptions = true;
            this.lblPatInfo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblPatInfo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lblPatInfo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblPatInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPatInfo.Location = new System.Drawing.Point(6, 12);
            this.lblPatInfo.Name = "lblPatInfo";
            this.lblPatInfo.Size = new System.Drawing.Size(143, 10);
            this.lblPatInfo.TabIndex = 54;
            this.lblPatInfo.Visible = false;
            // 
            // picLogo
            // 
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picLogo.Controls.Add(this.LogButton);
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(182, 94);
            this.picLogo.TabIndex = 62;
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.picTopSpliter);
            this.panel1.Controls.Add(this.lblPatientID);
            this.panel1.Controls.Add(this.lblPatInfoLine);
            this.panel1.Controls.Add(this.lblRoomNo);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.picPersonIcon);
            this.panel1.Controls.Add(this.lblPatInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(182, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 94);
            this.panel1.TabIndex = 102;
            // 
            // panelRight
            // 
            this.panelRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelRight.Controls.Add(this.btnRefreshStatus);
            this.panelRight.Location = new System.Drawing.Point(655, 0);
            this.panelRight.Margin = new System.Windows.Forms.Padding(0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(138, 64);
            this.panelRight.TabIndex = 103;
            this.panelRight.Visible = false;
            // 
            // btnRefreshStatus
            // 
            this.btnRefreshStatus.Location = new System.Drawing.Point(12, 12);
            this.btnRefreshStatus.Name = "btnRefreshStatus";
            this.btnRefreshStatus.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshStatus.TabIndex = 58;
            this.btnRefreshStatus.Text = "更新状态";
            this.btnRefreshStatus.Click += new System.EventHandler(this.btnRefreshStatus_Click);
            // 
            // mecicalDocBarControl1
            // 
            this.mecicalDocBarControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mecicalDocBarControl1.DocButtonStartLeft = 160;
            this.mecicalDocBarControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mecicalDocBarControl1.Location = new System.Drawing.Point(0, 94);
            this.mecicalDocBarControl1.Name = "mecicalDocBarControl1";
            this.mecicalDocBarControl1.PatientDocButtons = "";
            this.mecicalDocBarControl1.RefreshTimeSpan = 120;
            this.mecicalDocBarControl1.Size = new System.Drawing.Size(881, 26);
            this.mecicalDocBarControl1.TabIndex = 101;
            // 
            // patientStatusContrl1
            // 
            this.patientStatusContrl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.patientStatusContrl1.Appearance.Options.UseBackColor = true;
            this.patientStatusContrl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.patientStatusContrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.patientStatusContrl1.LightImage = null;
            this.patientStatusContrl1.Location = new System.Drawing.Point(424, 0);
            this.patientStatusContrl1.Name = "patientStatusContrl1";
            this.patientStatusContrl1.NormalImage = null;
            this.patientStatusContrl1.PassedImage = null;
            this.patientStatusContrl1.ServiceObject = null;
            this.patientStatusContrl1.Size = new System.Drawing.Size(457, 94);
            this.patientStatusContrl1.TabIndex = 100;
            // 
            // LogButton
            // 
            this.LogButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogButton.Enabled = false;
            this.LogButton.Image = ((System.Drawing.Image)(resources.GetObject("LogButton.Image")));
            this.LogButton.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.LogButton.Location = new System.Drawing.Point(0, 0);
            this.LogButton.Name = "LogButton";
            this.LogButton.Size = new System.Drawing.Size(182, 94);
            this.LogButton.TabIndex = 1;
            this.LogButton.Visible = false;
            // 
            // TopBarControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.patientStatusContrl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.mecicalDocBarControl1);
            this.Controls.Add(this.panelRight);
            this.Name = "TopBarControl";
            this.Size = new System.Drawing.Size(881, 120);
            this.Load += new System.EventHandler(this.TopBarControl_Load);
            this.Click += new System.EventHandler(this.TopBarControl_Click);
            ((System.ComponentModel.ISupportInitialize)(this.picPersonIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTopSpliter)).EndInit();
            this.picLogo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picPersonIcon;
        private System.Windows.Forms.PictureBox picTopSpliter;
        private DevExpress.XtraEditors.LabelControl lblPatInfoLine;
        private DevExpress.XtraEditors.LabelControl lblName;
        private DevExpress.XtraEditors.LabelControl lblPatientID;
        private DevExpress.XtraEditors.LabelControl lblPatInfo;
        private DevExpress.XtraEditors.LabelControl lblRoomNo;
        private Wis.Anes.Framework.Views.PatientStatusContrl patientStatusContrl1;
        private System.Windows.Forms.Panel picLogo;
        private MecicalDocBarControl mecicalDocBarControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelRight;
        private DevExpress.XtraEditors.SimpleButton btnRefreshStatus;
        private DevExpress.XtraEditors.SimpleButton LogButton;
    }
}
