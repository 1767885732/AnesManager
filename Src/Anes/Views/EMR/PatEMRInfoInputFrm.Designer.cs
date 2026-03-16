namespace Wis.Anes.Views.EMR
{
    partial class PatEMRInfoInputFrm
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
            this.lblPatId = new System.Windows.Forms.Label();
            this.cbxDept = new System.Windows.Forms.ComboBox();
            this.txtPatId = new System.Windows.Forms.TextBox();
            this.lblDeptId = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblPatName = new System.Windows.Forms.Label();
            this.txtPatName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblPatId
            // 
            this.lblPatId.AutoSize = true;
            this.lblPatId.Location = new System.Drawing.Point(35, 60);
            this.lblPatId.Name = "lblPatId";
            this.lblPatId.Size = new System.Drawing.Size(55, 14);
            this.lblPatId.TabIndex = 0;
            this.lblPatId.Text = "麻醉ID：";
            // 
            // cbxDept
            // 
            this.cbxDept.FormattingEnabled = true;
            this.cbxDept.Location = new System.Drawing.Point(105, 100);
            this.cbxDept.Name = "cbxDept";
            this.cbxDept.Size = new System.Drawing.Size(121, 22);
            this.cbxDept.TabIndex = 1;
            // 
            // txtPatId
            // 
            this.txtPatId.Location = new System.Drawing.Point(105, 57);
            this.txtPatId.Name = "txtPatId";
            this.txtPatId.Size = new System.Drawing.Size(121, 22);
            this.txtPatId.TabIndex = 2;
            // 
            // lblDeptId
            // 
            this.lblDeptId.AutoSize = true;
            this.lblDeptId.Location = new System.Drawing.Point(35, 103);
            this.lblDeptId.Name = "lblDeptId";
            this.lblDeptId.Size = new System.Drawing.Size(43, 14);
            this.lblDeptId.TabIndex = 3;
            this.lblDeptId.Text = "科室：";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(36, 152);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确认";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(145, 152);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblPatName
            // 
            this.lblPatName.AutoSize = true;
            this.lblPatName.Location = new System.Drawing.Point(35, 19);
            this.lblPatName.Name = "lblPatName";
            this.lblPatName.Size = new System.Drawing.Size(67, 14);
            this.lblPatName.TabIndex = 6;
            this.lblPatName.Text = "患者姓名：";
            // 
            // txtPatName
            // 
            this.txtPatName.Location = new System.Drawing.Point(105, 16);
            this.txtPatName.Name = "txtPatName";
            this.txtPatName.Size = new System.Drawing.Size(121, 22);
            this.txtPatName.TabIndex = 7;
            // 
            // PatEMRInfoInputFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 199);
            this.Controls.Add(this.txtPatName);
            this.Controls.Add(this.lblPatName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblDeptId);
            this.Controls.Add(this.txtPatId);
            this.Controls.Add(this.cbxDept);
            this.Controls.Add(this.lblPatId);
            this.Name = "PatEMRInfoInputFrm";
            this.Text = "电子病历调阅";
            this.Load += new System.EventHandler(this.PatEMRInfoInputFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPatId;
        private System.Windows.Forms.ComboBox cbxDept;
        private System.Windows.Forms.TextBox txtPatId;
        private System.Windows.Forms.Label lblDeptId;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblPatName;
        private System.Windows.Forms.TextBox txtPatName;
    }
}