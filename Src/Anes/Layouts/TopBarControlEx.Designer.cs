using Wis.Anes.Properties;

namespace Wis.Anes.Layouts
{
    partial class TopBarControlEx
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TopBarControlEx));
            this.lblName = new DevExpress.XtraEditors.LabelControl();
            this.lblPatientID = new DevExpress.XtraEditors.LabelControl();
            this.lblRoomNo = new DevExpress.XtraEditors.LabelControl();
            this.picPersonIcon = new System.Windows.Forms.PictureBox();
            this.picTopSpliter = new System.Windows.Forms.PictureBox();
            this.lblPatInfo = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblOperationName = new DevExpress.XtraEditors.LabelControl();
            this.lblOperationName0 = new DevExpress.XtraEditors.LabelControl();
            this.lblOperationTime = new DevExpress.XtraEditors.LabelControl();
            this.lblOperationTime0 = new DevExpress.XtraEditors.LabelControl();
            this.lblAnesAssistant = new DevExpress.XtraEditors.LabelControl();
            this.lblAnesAssistant0 = new DevExpress.XtraEditors.LabelControl();
            this.lblAnesDoctor = new DevExpress.XtraEditors.LabelControl();
            this.lblAnesDoctor0 = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.btnRefreshStatus = new DevExpress.XtraEditors.SimpleButton();
            this.mecicalDocBarControl1 = new Wis.Anes.Layouts.MecicalDocBarControl();
            this.patientStatusContrl1 = new Wis.Anes.Framework.Views.PatientStatusContrl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picPersonIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTopSpliter)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblName.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Appearance.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblName.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(172)))), ((int)(((byte)(172)))));
            this.lblName.Location = new System.Drawing.Point(105, 6);
            this.lblName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(32, 19);
            this.lblName.TabIndex = 3;
            this.lblName.Text = " 测试";
            this.lblName.Visible = false;
            this.lblName.Click += new System.EventHandler(this.lblName_Click);
            // 
            // lblPatientID
            // 
            this.lblPatientID.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblPatientID.Appearance.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblPatientID.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lblPatientID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPatientID.Location = new System.Drawing.Point(80, 32);
            this.lblPatientID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblPatientID.Name = "lblPatientID";
            this.lblPatientID.Size = new System.Drawing.Size(46, 20);
            this.lblPatientID.TabIndex = 52;
            this.lblPatientID.Text = "患者ID:";
            this.lblPatientID.Visible = false;
            this.lblPatientID.Click += new System.EventHandler(this.lblPatientID_Click);
            // 
            // lblRoomNo
            // 
            this.lblRoomNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRoomNo.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblRoomNo.Appearance.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRoomNo.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(111)))), ((int)(((byte)(237)))));
            this.lblRoomNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRoomNo.Location = new System.Drawing.Point(29, 6);
            this.lblRoomNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblRoomNo.Name = "lblRoomNo";
            this.lblRoomNo.Size = new System.Drawing.Size(105, 50);
            this.lblRoomNo.TabIndex = 51;
            this.lblRoomNo.Text = "02床  ";
            this.lblRoomNo.Visible = false;
            this.lblRoomNo.Click += new System.EventHandler(this.lblRoomNo_Click);
            // 
            // picPersonIcon
            // 
            this.picPersonIcon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.picPersonIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPersonIcon.Image = global::Wis.Anes.Properties.Resources.male_small;
            this.picPersonIcon.Location = new System.Drawing.Point(80, 6);
            this.picPersonIcon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picPersonIcon.Name = "picPersonIcon";
            this.picPersonIcon.Size = new System.Drawing.Size(27, 54);
            this.picPersonIcon.TabIndex = 57;
            this.picPersonIcon.TabStop = false;
            this.picPersonIcon.Click += new System.EventHandler(this.picPersonIcon_Click);
            // 
            // picTopSpliter
            // 
            this.picTopSpliter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picTopSpliter.Dock = System.Windows.Forms.DockStyle.Right;
            this.picTopSpliter.Location = new System.Drawing.Point(191, 0);
            this.picTopSpliter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picTopSpliter.Name = "picTopSpliter";
            this.picTopSpliter.Size = new System.Drawing.Size(3, 59);
            this.picTopSpliter.TabIndex = 56;
            this.picTopSpliter.TabStop = false;
            this.picTopSpliter.Visible = false;
            // 
            // lblPatInfo
            // 
            this.lblPatInfo.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblPatInfo.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPatInfo.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblPatInfo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblPatInfo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lblPatInfo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblPatInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPatInfo.Location = new System.Drawing.Point(7, 15);
            this.lblPatInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblPatInfo.Name = "lblPatInfo";
            this.lblPatInfo.Size = new System.Drawing.Size(163, 13);
            this.lblPatInfo.TabIndex = 54;
            this.lblPatInfo.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(199, 10);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(2, 369);
            this.labelControl1.TabIndex = 59;
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(714, 10);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(2, 369);
            this.labelControl2.TabIndex = 149;
            // 
            // lblOperationName
            // 
            this.lblOperationName.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblOperationName.Appearance.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblOperationName.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lblOperationName.Location = new System.Drawing.Point(287, 16);
            this.lblOperationName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblOperationName.Name = "lblOperationName";
            this.lblOperationName.Size = new System.Drawing.Size(0, 19);
            this.lblOperationName.TabIndex = 154;
            // 
            // lblOperationName0
            // 
            this.lblOperationName0.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblOperationName0.Appearance.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblOperationName0.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(172)))), ((int)(((byte)(172)))));
            this.lblOperationName0.Location = new System.Drawing.Point(207, 18);
            this.lblOperationName0.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblOperationName0.Name = "lblOperationName0";
            this.lblOperationName0.Size = new System.Drawing.Size(70, 20);
            this.lblOperationName0.TabIndex = 150;
            this.lblOperationName0.Text = "手术名称：";
            // 
            // lblOperationTime
            // 
            this.lblOperationTime.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblOperationTime.Appearance.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblOperationTime.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lblOperationTime.Location = new System.Drawing.Point(504, 57);
            this.lblOperationTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblOperationTime.Name = "lblOperationTime";
            this.lblOperationTime.Size = new System.Drawing.Size(0, 19);
            this.lblOperationTime.TabIndex = 157;
            // 
            // lblOperationTime0
            // 
            this.lblOperationTime0.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblOperationTime0.Appearance.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblOperationTime0.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(172)))), ((int)(((byte)(172)))));
            this.lblOperationTime0.Location = new System.Drawing.Point(428, 54);
            this.lblOperationTime0.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblOperationTime0.Name = "lblOperationTime0";
            this.lblOperationTime0.Size = new System.Drawing.Size(70, 20);
            this.lblOperationTime0.TabIndex = 153;
            this.lblOperationTime0.Text = "手术时间：";
            // 
            // lblAnesAssistant
            // 
            this.lblAnesAssistant.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblAnesAssistant.Appearance.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAnesAssistant.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lblAnesAssistant.Location = new System.Drawing.Point(498, 19);
            this.lblAnesAssistant.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblAnesAssistant.Name = "lblAnesAssistant";
            this.lblAnesAssistant.Size = new System.Drawing.Size(0, 19);
            this.lblAnesAssistant.TabIndex = 156;
            // 
            // lblAnesAssistant0
            // 
            this.lblAnesAssistant0.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblAnesAssistant0.Appearance.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAnesAssistant0.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(172)))), ((int)(((byte)(172)))));
            this.lblAnesAssistant0.Location = new System.Drawing.Point(428, 16);
            this.lblAnesAssistant0.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblAnesAssistant0.Name = "lblAnesAssistant0";
            this.lblAnesAssistant0.Size = new System.Drawing.Size(70, 20);
            this.lblAnesAssistant0.TabIndex = 152;
            this.lblAnesAssistant0.Text = "手术护士：";
            // 
            // lblAnesDoctor
            // 
            this.lblAnesDoctor.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblAnesDoctor.Appearance.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAnesDoctor.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lblAnesDoctor.Location = new System.Drawing.Point(281, 54);
            this.lblAnesDoctor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblAnesDoctor.Name = "lblAnesDoctor";
            this.lblAnesDoctor.Size = new System.Drawing.Size(0, 19);
            this.lblAnesDoctor.TabIndex = 155;
            // 
            // lblAnesDoctor0
            // 
            this.lblAnesDoctor0.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblAnesDoctor0.Appearance.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAnesDoctor0.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(172)))), ((int)(((byte)(172)))));
            this.lblAnesDoctor0.Location = new System.Drawing.Point(207, 49);
            this.lblAnesDoctor0.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblAnesDoctor0.Name = "lblAnesDoctor0";
            this.lblAnesDoctor0.Size = new System.Drawing.Size(70, 20);
            this.lblAnesDoctor0.TabIndex = 151;
            this.lblAnesDoctor0.Text = "手术医生：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picTopSpliter);
            this.panel1.Controls.Add(this.lblPatientID);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.picPersonIcon);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lblPatInfo);
            this.panel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(5, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(194, 59);
            this.panel1.TabIndex = 102;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblRoomNo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(74, 59);
            this.panel2.TabIndex = 9;
            // 
            // panelRight
            // 
            this.panelRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelRight.Controls.Add(this.btnRefreshStatus);
            this.panelRight.Location = new System.Drawing.Point(655, 0);
            this.panelRight.Margin = new System.Windows.Forms.Padding(0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(138, 58);
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
            this.mecicalDocBarControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.mecicalDocBarControl1.Appearance.Options.UseBackColor = true;
            this.mecicalDocBarControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mecicalDocBarControl1.DocButtonStartLeft = 160;
            this.mecicalDocBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mecicalDocBarControl1.Location = new System.Drawing.Point(0, 0);
            this.mecicalDocBarControl1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.mecicalDocBarControl1.Name = "mecicalDocBarControl1";
            this.mecicalDocBarControl1.PatientDocButtons = "";
            this.mecicalDocBarControl1.RefreshTimeSpan = 120;
            this.mecicalDocBarControl1.Size = new System.Drawing.Size(1015, 48);
            this.mecicalDocBarControl1.TabIndex = 101;
            // 
            // patientStatusContrl1
            // 
            this.patientStatusContrl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.patientStatusContrl1.Appearance.Options.UseBackColor = true;
            this.patientStatusContrl1.LightImage = null;
            this.patientStatusContrl1.Location = new System.Drawing.Point(722, 10);
            this.patientStatusContrl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.patientStatusContrl1.Name = "patientStatusContrl1";
            this.patientStatusContrl1.NormalImage = null;
            this.patientStatusContrl1.PassedImage = null;
            this.patientStatusContrl1.ServiceObject = null;
            this.patientStatusContrl1.Size = new System.Drawing.Size(727, 74);
            this.patientStatusContrl1.TabIndex = 100;
            this.patientStatusContrl1.Load += new System.EventHandler(this.patientStatusContrl1_Load);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.mecicalDocBarControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1015, 48);
            this.panel3.TabIndex = 158;
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Controls.Add(this.lblAnesAssistant0);
            this.panel4.Controls.Add(this.lblAnesDoctor);
            this.panel4.Controls.Add(this.lblOperationTime);
            this.panel4.Controls.Add(this.lblOperationName);
            this.panel4.Controls.Add(this.lblOperationTime0);
            this.panel4.Controls.Add(this.lblAnesAssistant);
            this.panel4.Controls.Add(this.patientStatusContrl1);
            this.panel4.Controls.Add(this.lblAnesDoctor0);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.lblOperationName0);
            this.panel4.Controls.Add(this.labelControl1);
            this.panel4.Controls.Add(this.labelControl2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1015, 80);
            this.panel4.TabIndex = 159;
            // 
            // TopBarControlEx
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TopBarControlEx";
            this.Size = new System.Drawing.Size(1015, 128);
            this.Load += new System.EventHandler(this.TopBarControl_Load);
            this.Click += new System.EventHandler(this.TopBarControl_Click);
            ((System.ComponentModel.ISupportInitialize)(this.picPersonIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTopSpliter)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picPersonIcon;
        private System.Windows.Forms.PictureBox picTopSpliter;
        //private DevExpress.XtraEditors.LabelControl lblPatInfoLine;
        private DevExpress.XtraEditors.LabelControl lblName;
        private DevExpress.XtraEditors.LabelControl lblPatientID;
        private DevExpress.XtraEditors.LabelControl lblPatInfo;
        private DevExpress.XtraEditors.LabelControl lblRoomNo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lblOperationName0;
        private DevExpress.XtraEditors.LabelControl lblOperationName;
        private DevExpress.XtraEditors.LabelControl lblAnesDoctor0;
        private DevExpress.XtraEditors.LabelControl lblAnesDoctor;
        private DevExpress.XtraEditors.LabelControl lblAnesAssistant0;
        private DevExpress.XtraEditors.LabelControl lblAnesAssistant;
        private DevExpress.XtraEditors.LabelControl lblOperationTime0;
        private DevExpress.XtraEditors.LabelControl lblOperationTime;
        private Wis.Anes.Framework.Views.PatientStatusContrl patientStatusContrl1;
        private MecicalDocBarControl mecicalDocBarControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelRight;
        private DevExpress.XtraEditors.SimpleButton btnRefreshStatus;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}
