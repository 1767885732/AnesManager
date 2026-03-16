namespace AnesCommunicator.View
{
    partial class EmergencyView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmergencyView));
            this.lblMessage = new DevExpress.XtraEditors.LabelControl();
            this.btnConfirm = new DevExpress.XtraEditors.SimpleButton();
            this.timerEmergency = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblOperName = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblAnesthesiaName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBedNo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblHeartRate = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblBreath = new System.Windows.Forms.Label();
            this.lblTemperature = new System.Windows.Forms.Label();
            this.lblBloodPressure = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblAnesthesiaDoctor = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblOperationNurse = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblSupplyNurse = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblSurgeon = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Appearance.Font = new System.Drawing.Font("宋体", 40F);
            this.lblMessage.Appearance.Options.UseBackColor = true;
            this.lblMessage.Appearance.Options.UseFont = true;
            this.lblMessage.Location = new System.Drawing.Point(156, 12);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(717, 53);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "【紧急】手术间{0}请求支援！";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirm.Appearance.Font = new System.Drawing.Font("宋体", 20F);
            this.btnConfirm.Appearance.Options.UseBackColor = true;
            this.btnConfirm.Appearance.Options.UseFont = true;
            this.btnConfirm.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnConfirm.Location = new System.Drawing.Point(731, 137);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(121, 55);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // timerEmergency
            // 
            this.timerEmergency.Enabled = true;
            this.timerEmergency.Interval = 1300;
            this.timerEmergency.Tick += new System.EventHandler(this.timerEmergency_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(145, 142);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label1.Location = new System.Drawing.Point(184, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "患者姓名:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Tahoma", 13F);
            this.lblName.Location = new System.Drawing.Point(278, 82);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(64, 22);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "王钱军";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label3.Location = new System.Drawing.Point(361, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "性别:";
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Font = new System.Drawing.Font("Tahoma", 13F);
            this.lblSex.Location = new System.Drawing.Point(419, 82);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(28, 22);
            this.lblSex.TabIndex = 4;
            this.lblSex.Text = "男";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label5.Location = new System.Drawing.Point(465, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 22);
            this.label5.TabIndex = 4;
            this.label5.Text = "年龄:";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("Tahoma", 13F);
            this.lblAge.Location = new System.Drawing.Point(523, 82);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(30, 22);
            this.lblAge.TabIndex = 4;
            this.lblAge.Text = "40";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label7.Location = new System.Drawing.Point(184, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 22);
            this.label7.TabIndex = 5;
            this.label7.Text = "手术名称:";
            // 
            // lblOperName
            // 
            this.lblOperName.AutoSize = true;
            this.lblOperName.Font = new System.Drawing.Font("Tahoma", 13F);
            this.lblOperName.Location = new System.Drawing.Point(278, 126);
            this.lblOperName.Name = "lblOperName";
            this.lblOperName.Size = new System.Drawing.Size(226, 22);
            this.lblOperName.TabIndex = 6;
            this.lblOperName.Text = "单侧腹股沟疝无张力修补术";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label9.Location = new System.Drawing.Point(184, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 22);
            this.label9.TabIndex = 5;
            this.label9.Text = "麻醉方法:";
            // 
            // lblAnesthesiaName
            // 
            this.lblAnesthesiaName.AutoSize = true;
            this.lblAnesthesiaName.Font = new System.Drawing.Font("Tahoma", 13F);
            this.lblAnesthesiaName.Location = new System.Drawing.Point(278, 148);
            this.lblAnesthesiaName.Name = "lblAnesthesiaName";
            this.lblAnesthesiaName.Size = new System.Drawing.Size(82, 22);
            this.lblAnesthesiaName.TabIndex = 6;
            this.lblAnesthesiaName.Text = "插管全麻";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label2.Location = new System.Drawing.Point(571, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "床号:";
            // 
            // lblBedNo
            // 
            this.lblBedNo.AutoSize = true;
            this.lblBedNo.Font = new System.Drawing.Font("Tahoma", 13F);
            this.lblBedNo.Location = new System.Drawing.Point(629, 82);
            this.lblBedNo.Name = "lblBedNo";
            this.lblBedNo.Size = new System.Drawing.Size(30, 22);
            this.lblBedNo.TabIndex = 4;
            this.lblBedNo.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label4.Location = new System.Drawing.Point(465, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 22);
            this.label4.TabIndex = 4;
            this.label4.Text = "心率:";
            // 
            // lblHeartRate
            // 
            this.lblHeartRate.AutoSize = true;
            this.lblHeartRate.Font = new System.Drawing.Font("Tahoma", 13F);
            this.lblHeartRate.Location = new System.Drawing.Point(523, 104);
            this.lblHeartRate.Name = "lblHeartRate";
            this.lblHeartRate.Size = new System.Drawing.Size(30, 22);
            this.lblHeartRate.TabIndex = 4;
            this.lblHeartRate.Text = "72";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label8.Location = new System.Drawing.Point(361, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 22);
            this.label8.TabIndex = 4;
            this.label8.Text = "呼吸:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label10.Location = new System.Drawing.Point(571, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 22);
            this.label10.TabIndex = 4;
            this.label10.Text = "体温:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label6.Location = new System.Drawing.Point(220, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 22);
            this.label6.TabIndex = 4;
            this.label6.Text = "血压:";
            // 
            // lblBreath
            // 
            this.lblBreath.AutoSize = true;
            this.lblBreath.Font = new System.Drawing.Font("Tahoma", 13F);
            this.lblBreath.Location = new System.Drawing.Point(419, 104);
            this.lblBreath.Name = "lblBreath";
            this.lblBreath.Size = new System.Drawing.Size(30, 22);
            this.lblBreath.TabIndex = 4;
            this.lblBreath.Text = "15";
            // 
            // lblTemperature
            // 
            this.lblTemperature.AutoSize = true;
            this.lblTemperature.Font = new System.Drawing.Font("Tahoma", 13F);
            this.lblTemperature.Location = new System.Drawing.Point(629, 104);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(45, 22);
            this.lblTemperature.TabIndex = 4;
            this.lblTemperature.Text = "36.5";
            // 
            // lblBloodPressure
            // 
            this.lblBloodPressure.AutoSize = true;
            this.lblBloodPressure.Font = new System.Drawing.Font("Tahoma", 13F);
            this.lblBloodPressure.Location = new System.Drawing.Point(278, 104);
            this.lblBloodPressure.Name = "lblBloodPressure";
            this.lblBloodPressure.Size = new System.Drawing.Size(67, 22);
            this.lblBloodPressure.TabIndex = 4;
            this.lblBloodPressure.Text = "120/70";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label11.Location = new System.Drawing.Point(184, 170);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 22);
            this.label11.TabIndex = 5;
            this.label11.Text = "手术医师:";
            // 
            // lblAnesthesiaDoctor
            // 
            this.lblAnesthesiaDoctor.AutoSize = true;
            this.lblAnesthesiaDoctor.Font = new System.Drawing.Font("Tahoma", 13F);
            this.lblAnesthesiaDoctor.Location = new System.Drawing.Point(278, 170);
            this.lblAnesthesiaDoctor.Name = "lblAnesthesiaDoctor";
            this.lblAnesthesiaDoctor.Size = new System.Drawing.Size(64, 22);
            this.lblAnesthesiaDoctor.TabIndex = 6;
            this.lblAnesthesiaDoctor.Text = "李泽华";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label12.Location = new System.Drawing.Point(359, 170);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 22);
            this.label12.TabIndex = 5;
            this.label12.Text = "洗手护士:";
            // 
            // lblOperationNurse
            // 
            this.lblOperationNurse.AutoSize = true;
            this.lblOperationNurse.Font = new System.Drawing.Font("Tahoma", 13F);
            this.lblOperationNurse.Location = new System.Drawing.Point(453, 170);
            this.lblOperationNurse.Name = "lblOperationNurse";
            this.lblOperationNurse.Size = new System.Drawing.Size(64, 22);
            this.lblOperationNurse.TabIndex = 6;
            this.lblOperationNurse.Text = "李泽华";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label13.Location = new System.Drawing.Point(535, 170);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 22);
            this.label13.TabIndex = 5;
            this.label13.Text = "巡回护士:";
            // 
            // lblSupplyNurse
            // 
            this.lblSupplyNurse.AutoSize = true;
            this.lblSupplyNurse.Font = new System.Drawing.Font("Tahoma", 13F);
            this.lblSupplyNurse.Location = new System.Drawing.Point(629, 170);
            this.lblSupplyNurse.Name = "lblSupplyNurse";
            this.lblSupplyNurse.Size = new System.Drawing.Size(64, 22);
            this.lblSupplyNurse.TabIndex = 6;
            this.lblSupplyNurse.Text = "李泽华";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label14.Location = new System.Drawing.Point(535, 148);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 22);
            this.label14.TabIndex = 5;
            this.label14.Text = "麻醉医师:";
            // 
            // lblSurgeon
            // 
            this.lblSurgeon.AutoSize = true;
            this.lblSurgeon.Font = new System.Drawing.Font("Tahoma", 13F);
            this.lblSurgeon.Location = new System.Drawing.Point(629, 148);
            this.lblSurgeon.Name = "lblSurgeon";
            this.lblSurgeon.Size = new System.Drawing.Size(64, 22);
            this.lblSurgeon.TabIndex = 6;
            this.lblSurgeon.Text = "李泽华";
            // 
            // EmergencyView
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 210);
            this.Controls.Add(this.lblSurgeon);
            this.Controls.Add(this.lblSupplyNurse);
            this.Controls.Add(this.lblOperationNurse);
            this.Controls.Add(this.lblAnesthesiaDoctor);
            this.Controls.Add(this.lblAnesthesiaName);
            this.Controls.Add(this.lblOperName);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblBloodPressure);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.lblTemperature);
            this.Controls.Add(this.lblBedNo);
            this.Controls.Add(this.lblBreath);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblHeartRate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "EmergencyView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "紧急情况";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblMessage;
        private DevExpress.XtraEditors.SimpleButton btnConfirm;
        private System.Windows.Forms.Timer timerEmergency;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblOperName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblAnesthesiaName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblBedNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblHeartRate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblBreath;
        private System.Windows.Forms.Label lblTemperature;
        private System.Windows.Forms.Label lblBloodPressure;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblAnesthesiaDoctor;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblOperationNurse;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblSupplyNurse;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblSurgeon;

    }
}