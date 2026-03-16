namespace Wis.Anes.Views
{
    partial class OperationRoomContent
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
            this.lbRoomNo = new System.Windows.Forms.Label();
            this.lbAnesDoctor = new System.Windows.Forms.Label();
            this.lbOperDoctor = new System.Windows.Forms.Label();
            this.lbOperDate = new System.Windows.Forms.Label();
            this.picMain = new System.Windows.Forms.PictureBox();
            this.lbPatientID = new System.Windows.Forms.Label();
            this.lbPatientName = new System.Windows.Forms.Label();
            this.lbOperName = new System.Windows.Forms.Label();
            this.lbOperStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            this.SuspendLayout();
            // 
            // lbRoomNo
            // 
            this.lbRoomNo.AutoSize = true;
            this.lbRoomNo.BackColor = System.Drawing.Color.Transparent;
            this.lbRoomNo.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.lbRoomNo.Location = new System.Drawing.Point(0, 38);
            this.lbRoomNo.Name = "lbRoomNo";
            this.lbRoomNo.Size = new System.Drawing.Size(63, 32);
            this.lbRoomNo.TabIndex = 1;
            this.lbRoomNo.Text = "P01";
            this.lbRoomNo.Click += new System.EventHandler(this.lbRoomNo_Click);
            // 
            // lbAnesDoctor
            // 
            this.lbAnesDoctor.AutoSize = true;
            this.lbAnesDoctor.BackColor = System.Drawing.Color.Transparent;
            this.lbAnesDoctor.Font = new System.Drawing.Font("宋体", 10F);
            this.lbAnesDoctor.Location = new System.Drawing.Point(62, 30);
            this.lbAnesDoctor.Name = "lbAnesDoctor";
            this.lbAnesDoctor.Size = new System.Drawing.Size(63, 14);
            this.lbAnesDoctor.TabIndex = 2;
            this.lbAnesDoctor.Text = "麻醉医生";
            this.lbAnesDoctor.Click += new System.EventHandler(this.ControlClick);
            // 
            // lbOperDoctor
            // 
            this.lbOperDoctor.AutoSize = true;
            this.lbOperDoctor.BackColor = System.Drawing.Color.Transparent;
            this.lbOperDoctor.Font = new System.Drawing.Font("宋体", 10F);
            this.lbOperDoctor.Location = new System.Drawing.Point(62, 47);
            this.lbOperDoctor.Name = "lbOperDoctor";
            this.lbOperDoctor.Size = new System.Drawing.Size(63, 14);
            this.lbOperDoctor.TabIndex = 3;
            this.lbOperDoctor.Text = "手术医生";
            this.lbOperDoctor.Click += new System.EventHandler(this.ControlClick);
            // 
            // lbOperDate
            // 
            this.lbOperDate.AutoSize = true;
            this.lbOperDate.BackColor = System.Drawing.Color.Transparent;
            this.lbOperDate.Font = new System.Drawing.Font("宋体", 10F);
            this.lbOperDate.Location = new System.Drawing.Point(62, 64);
            this.lbOperDate.Name = "lbOperDate";
            this.lbOperDate.Size = new System.Drawing.Size(63, 14);
            this.lbOperDate.TabIndex = 4;
            this.lbOperDate.Text = "手术日期";
            this.lbOperDate.Click += new System.EventHandler(this.ControlClick);
            // 
            // picMain
            // 
            this.picMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.picMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picMain.Image = global::Wis.Anes.Properties.Resources.picOperRoomNoPerson;
            this.picMain.Location = new System.Drawing.Point(0, 0);
            this.picMain.Name = "picMain";
            this.picMain.Size = new System.Drawing.Size(210, 98);
            this.picMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMain.TabIndex = 6;
            this.picMain.TabStop = false;
            this.picMain.Click += new System.EventHandler(this.ControlClick);
            // 
            // lbPatientID
            // 
            this.lbPatientID.AutoSize = true;
            this.lbPatientID.BackColor = System.Drawing.Color.Transparent;
            this.lbPatientID.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPatientID.Location = new System.Drawing.Point(4, 3);
            this.lbPatientID.Name = "lbPatientID";
            this.lbPatientID.Size = new System.Drawing.Size(49, 19);
            this.lbPatientID.TabIndex = 7;
            this.lbPatientID.Text = "患者ID";
            this.lbPatientID.Click += new System.EventHandler(this.ControlClick);
            // 
            // lbPatientName
            // 
            this.lbPatientName.AutoSize = true;
            this.lbPatientName.BackColor = System.Drawing.Color.Transparent;
            this.lbPatientName.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPatientName.ForeColor = System.Drawing.Color.Blue;
            this.lbPatientName.Location = new System.Drawing.Point(88, 3);
            this.lbPatientName.Name = "lbPatientName";
            this.lbPatientName.Size = new System.Drawing.Size(61, 19);
            this.lbPatientName.TabIndex = 8;
            this.lbPatientName.Text = "患者姓名";
            this.lbPatientName.Click += new System.EventHandler(this.ControlClick);
            // 
            // lbOperName
            // 
            this.lbOperName.BackColor = System.Drawing.Color.Transparent;
            this.lbOperName.Font = new System.Drawing.Font("宋体", 10F);
            this.lbOperName.Location = new System.Drawing.Point(-3, 78);
            this.lbOperName.Name = "lbOperName";
            this.lbOperName.Size = new System.Drawing.Size(207, 14);
            this.lbOperName.TabIndex = 9;
            this.lbOperName.Text = "手术名称";
            this.lbOperName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbOperName.Click += new System.EventHandler(this.ControlClick);
            // 
            // lbOperStatus
            // 
            this.lbOperStatus.AutoSize = true;
            this.lbOperStatus.BackColor = System.Drawing.Color.Transparent;
            this.lbOperStatus.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbOperStatus.Location = new System.Drawing.Point(137, 7);
            this.lbOperStatus.Name = "lbOperStatus";
            this.lbOperStatus.Size = new System.Drawing.Size(63, 13);
            this.lbOperStatus.TabIndex = 10;
            this.lbOperStatus.Text = "手术状态";
            this.lbOperStatus.Click += new System.EventHandler(this.lbOperStatus_Click);
            // 
            // OperationRoomContent
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lbOperDate);
            this.Controls.Add(this.lbOperDoctor);
            this.Controls.Add(this.lbAnesDoctor);
            this.Controls.Add(this.lbPatientName);
            this.Controls.Add(this.lbOperStatus);
            this.Controls.Add(this.lbOperName);
            this.Controls.Add(this.lbPatientID);
            this.Controls.Add(this.lbRoomNo);
            this.Controls.Add(this.picMain);
            this.DoubleBuffered = true;
            this.Name = "OperationRoomContent";
            this.Size = new System.Drawing.Size(210, 98);
            this.Load += new System.EventHandler(this.OperationRoomContent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbRoomNo;
        private System.Windows.Forms.Label lbAnesDoctor;
        private System.Windows.Forms.Label lbOperDoctor;
        private System.Windows.Forms.Label lbOperDate;
        private System.Windows.Forms.PictureBox picMain;
        private System.Windows.Forms.Label lbPatientID;
        private System.Windows.Forms.Label lbPatientName;
        private System.Windows.Forms.Label lbOperName;
        private System.Windows.Forms.Label lbOperStatus;
    }
}
