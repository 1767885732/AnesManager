namespace AnesManager
{
    partial class LoginAnes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginAnes));
            this.txtPassWord = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.chkLocal = new DevExpress.XtraEditors.CheckEdit();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.lblSystemName = new System.Windows.Forms.Label();
            this.lbLockSystem = new System.Windows.Forms.Label();
            this.picBack = new System.Windows.Forms.PictureBox();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.pictureEdit2 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassWord.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLocal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPassWord
            // 
            this.txtPassWord.EditValue = "";
            this.txtPassWord.EnterMoveNextControl = true;
            this.txtPassWord.Location = new System.Drawing.Point(474, 268);
            this.txtPassWord.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 13.8F);
            this.txtPassWord.Properties.Appearance.Options.UseFont = true;
            this.txtPassWord.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtPassWord.Properties.NullText = "请输入密码";
            this.txtPassWord.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtPassWord.Properties.PasswordChar = '*';
            this.txtPassWord.Size = new System.Drawing.Size(213, 34);
            this.txtPassWord.TabIndex = 10;
            this.txtPassWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassWord_KeyPress);
            // 
            // txtUserName
            // 
            this.txtUserName.EditValue = "";
            this.txtUserName.EnterMoveNextControl = true;
            this.txtUserName.Location = new System.Drawing.Point(474, 201);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUserName.Properties.Appearance.Options.UseFont = true;
            this.txtUserName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtUserName.Properties.NullText = "请输入用户名";
            this.txtUserName.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtUserName.Size = new System.Drawing.Size(213, 34);
            this.txtUserName.TabIndex = 9;
            // 
            // chkLocal
            // 
            this.chkLocal.Location = new System.Drawing.Point(411, 419);
            this.chkLocal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkLocal.Name = "chkLocal";
            this.chkLocal.Properties.Caption = "离线";
            this.chkLocal.Size = new System.Drawing.Size(59, 22);
            this.chkLocal.TabIndex = 15;
            this.chkLocal.Visible = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(478, 414);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(51, 30);
            this.btnEdit.TabIndex = 13;
            this.btnEdit.Text = "配置";
            this.btnEdit.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.BackColor = System.Drawing.Color.White;
            this.btnCancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F);
            this.btnCancel.Appearance.Options.UseBackColor = true;
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(1049, 625);
            this.btnCancel.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.btnCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(136, 44);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(111)))), ((int)(((byte)(237)))));
            this.btnOK.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnOK.Appearance.Options.UseBackColor = true;
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Appearance.Options.UseForeColor = true;
            this.btnOK.Appearance.Options.UseTextOptions = true;
            this.btnOK.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnOK.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(897, 625);
            this.btnOK.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.btnOK.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnOK.Margin = new System.Windows.Forms.Padding(0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(136, 44);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "登录";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblSystemName
            // 
            this.lblSystemName.AutoSize = true;
            this.lblSystemName.BackColor = System.Drawing.Color.Transparent;
            this.lblSystemName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSystemName.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSystemName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(111)))), ((int)(((byte)(237)))));
            this.lblSystemName.Location = new System.Drawing.Point(429, 108);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(292, 45);
            this.lblSystemName.TabIndex = 20;
            this.lblSystemName.Text = "麻醉临床信息系统";
            // 
            // lbLockSystem
            // 
            this.lbLockSystem.AutoSize = true;
            this.lbLockSystem.BackColor = System.Drawing.Color.Transparent;
            this.lbLockSystem.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbLockSystem.ForeColor = System.Drawing.Color.Black;
            this.lbLockSystem.Location = new System.Drawing.Point(410, 481);
            this.lbLockSystem.Name = "lbLockSystem";
            this.lbLockSystem.Size = new System.Drawing.Size(272, 27);
            this.lbLockSystem.TabIndex = 19;
            this.lbLockSystem.Text = "系统锁定中，请输入密码解锁";
            // 
            // picBack
            // 
            this.picBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.picBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picBack.Image = ((System.Drawing.Image)(resources.GetObject("picBack.Image")));
            this.picBack.Location = new System.Drawing.Point(549, 414);
            this.picBack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picBack.Name = "picBack";
            this.picBack.Size = new System.Drawing.Size(133, 30);
            this.picBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBack.TabIndex = 17;
            this.picBack.TabStop = false;
            this.picBack.Visible = false;
            this.picBack.Click += new System.EventHandler(this.picBack_Click);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureEdit1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.EnterMoveNextControl = true;
            this.pictureEdit1.Location = new System.Drawing.Point(426, 194);
            this.pictureEdit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(282, 48);
            this.pictureEdit1.TabIndex = 25;
            // 
            // pictureEdit2
            // 
            this.pictureEdit2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureEdit2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureEdit2.EditValue = ((object)(resources.GetObject("pictureEdit2.EditValue")));
            this.pictureEdit2.EnterMoveNextControl = true;
            this.pictureEdit2.Location = new System.Drawing.Point(426, 261);
            this.pictureEdit2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureEdit2.Name = "pictureEdit2";
            this.pictureEdit2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit2.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit2.Size = new System.Drawing.Size(282, 48);
            this.pictureEdit2.TabIndex = 25;
            // 
            // LoginAnes
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImageStore")));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(762, 509);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lbLockSystem);
            this.Controls.Add(this.txtPassWord);
            this.Controls.Add(this.chkLocal);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblSystemName);
            this.Controls.Add(this.picBack);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.pictureEdit2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(762, 509);
            this.MinimumSize = new System.Drawing.Size(762, 509);
            this.Name = "LoginAnes";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.LoginAnes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginAnes_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.txtPassWord.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLocal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).EndInit();
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
        private System.Windows.Forms.Label lblSystemName;        
        private System.Windows.Forms.PictureBox picBack;
        private System.Windows.Forms.Label lbLockSystem;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit2;
    }
}