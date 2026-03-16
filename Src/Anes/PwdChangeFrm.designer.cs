namespace Wis.Anes
{
    partial class PwdChangeFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PwdChangeFrm));
            this.button1 = new Wis.Anes.Framework.Controls.MedButton();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.txtNewPWD = new System.Windows.Forms.TextBox();
            this.txtNewPWDtoo = new System.Windows.Forms.TextBox();
            this.button2 = new Wis.Anes.Framework.Controls.MedButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.ActionName = null;
            this.button1.AutoImage = false;
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.BindControl = null;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.HasBorder = true;
            this.button1.IsMenu = false;
            this.button1.IsMouseHover = true;
            this.button1.Location = new System.Drawing.Point(203, 175);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.MenuIndex = 0;
            this.button1.Name = "button1";
            this.button1.PageName = null;
            this.button1.Parameters = null;
            this.button1.ShortcutKeys = null;
            this.button1.ShowText = true;
            this.button1.Size = new System.Drawing.Size(100, 29);
            this.button1.TabIndex = 4;
            this.button1.Text = "确认";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPassWord
            // 
            this.txtPassWord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassWord.Location = new System.Drawing.Point(179, 32);
            this.txtPassWord.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.Size = new System.Drawing.Size(275, 25);
            this.txtPassWord.TabIndex = 1;
            // 
            // txtNewPWD
            // 
            this.txtNewPWD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewPWD.Location = new System.Drawing.Point(179, 129);
            this.txtNewPWD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNewPWD.Name = "txtNewPWD";
            this.txtNewPWD.PasswordChar = '*';
            this.txtNewPWD.Size = new System.Drawing.Size(275, 25);
            this.txtNewPWD.TabIndex = 3;
            // 
            // txtNewPWDtoo
            // 
            this.txtNewPWDtoo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewPWDtoo.Location = new System.Drawing.Point(179, 81);
            this.txtNewPWDtoo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNewPWDtoo.Name = "txtNewPWDtoo";
            this.txtNewPWDtoo.PasswordChar = '*';
            this.txtNewPWDtoo.Size = new System.Drawing.Size(275, 25);
            this.txtNewPWDtoo.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.ActionName = null;
            this.button2.AutoImage = false;
            this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button2.BindControl = null;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.HasBorder = true;
            this.button2.IsMenu = false;
            this.button2.IsMouseHover = true;
            this.button2.Location = new System.Drawing.Point(329, 175);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.MenuIndex = 0;
            this.button2.Name = "button2";
            this.button2.PageName = null;
            this.button2.Parameters = null;
            this.button2.ShortcutKeys = null;
            this.button2.ShowText = true;
            this.button2.Size = new System.Drawing.Size(100, 29);
            this.button2.TabIndex = 6;
            this.button2.Text = "取消";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(64, 34);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 18);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "旧密码";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(64, 84);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(45, 18);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "新密码";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(64, 132);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 18);
            this.labelControl3.TabIndex = 9;
            this.labelControl3.Text = "确认密码";
            // 
            // PwdChangeFrm
            // 
            this.AcceptButton = this.button1;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(481, 239);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtNewPWDtoo);
            this.Controls.Add(this.txtNewPWD);
            this.Controls.Add(this.txtPassWord);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Office 2007 Blue";
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "PwdChangeFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改密码";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PwdChangeFrm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PwdChangeFrm_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.TextBox txtNewPWD;
        private System.Windows.Forms.TextBox txtNewPWDtoo;
        private Wis.Anes.Framework.Controls.MedButton button1;
        private Wis.Anes.Framework.Controls.MedButton button2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}