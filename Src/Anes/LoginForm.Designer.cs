namespace Wis.Anes
{
    partial class LoginForm
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
            this.txtPassWord = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.chkLocal = new DevExpress.XtraEditors.CheckEdit();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSystemName = new System.Windows.Forms.Label();
            this.lbLockSystem = new System.Windows.Forms.Label();
            this.picBack = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassWord.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLocal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPassWord
            // 
            this.txtPassWord.EnterMoveNextControl = true;
            this.txtPassWord.Location = new System.Drawing.Point(665, 470);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtPassWord.Properties.PasswordChar = '*';
            this.txtPassWord.Size = new System.Drawing.Size(120, 19);
            this.txtPassWord.TabIndex = 10;
            this.txtPassWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassWord_KeyPress);
            // 
            // txtUserName
            // 
            this.txtUserName.EnterMoveNextControl = true;
            this.txtUserName.Location = new System.Drawing.Point(665, 439);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtUserName.Size = new System.Drawing.Size(170, 19);
            this.txtUserName.TabIndex = 9;
            // 
            // chkLocal
            // 
            this.chkLocal.Location = new System.Drawing.Point(609, 496);
            this.chkLocal.Name = "chkLocal";
            this.chkLocal.Properties.Caption = "离线";
            this.chkLocal.Size = new System.Drawing.Size(52, 19);
            this.chkLocal.TabIndex = 15;
            this.chkLocal.Visible = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(539, 487);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(45, 23);
            this.btnEdit.TabIndex = 13;
            this.btnEdit.Text = "配置";
            this.btnEdit.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(791, 499);
            this.btnCancel.LookAndFeel.SkinName = "MySkin_Blue1";
            this.btnCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 27);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(695, 499);
            this.btnOK.LookAndFeel.SkinName = "MySkin_Blue1";
            this.btnOK.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(85, 27);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(603, 471);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 14);
            this.label2.TabIndex = 16;
            this.label2.Text = "密  码：";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(603, 440);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 14;
            this.label1.Text = "用户名：";
            this.label1.Visible = false;
            // 
            // lblSystemName
            // 
            this.lblSystemName.AutoSize = true;
            this.lblSystemName.BackColor = System.Drawing.Color.Transparent;
            this.lblSystemName.ForeColor = System.Drawing.Color.White;
            this.lblSystemName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSystemName.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSystemName.Location = new System.Drawing.Point(603, 440);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(55, 14);
            this.lblSystemName.TabIndex = 20;
            this.lblSystemName.Text = "麻醉临床信息系统";
            this.lblSystemName.Visible = true;
            // 
            // lbLockSystem
            // 
            this.lbLockSystem.AutoSize = true;
            this.lbLockSystem.BackColor = System.Drawing.Color.Transparent;
            this.lbLockSystem.ForeColor = System.Drawing.Color.White;
            this.lbLockSystem.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbLockSystem.Location = new System.Drawing.Point(716, 358);
            this.lbLockSystem.Name = "lbLockSystem";
            this.lbLockSystem.Size = new System.Drawing.Size(90, 21);
            this.lbLockSystem.TabIndex = 19;
            this.lbLockSystem.Text = "系统锁定中，请输入密码解锁";
            // 
            // picBack
            // 
            this.picBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.picBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBack.Location = new System.Drawing.Point(27, 104);
            this.picBack.Name = "picBack";
            this.picBack.Size = new System.Drawing.Size(683, 269);
            this.picBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picBack.TabIndex = 17;
            this.picBack.TabStop = false;
            this.picBack.Click += new System.EventHandler(this.picBack_Click);
            // 
            // LoginForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            //this.ClientSize = new System.Drawing.Size(919, 561);            
            this.ClientSize = new System.Drawing.Size(447, 318);            
            this.Controls.Add(this.lbLockSystem);
            this.Controls.Add(this.txtPassWord);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.chkLocal);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSystemName);
            this.Controls.Add(this.picBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "LoginForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.txtPassWord.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLocal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtPassWord;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.CheckEdit chkLocal;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSystemName;        
        private System.Windows.Forms.PictureBox picBack;
        private System.Windows.Forms.Label lbLockSystem;
    }
}