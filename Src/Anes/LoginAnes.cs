using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.Framework;
using Wis.Anes.ServiceProxies;
using Wis.Anes.Framework.Controls.Base;
using Wis.Anes;
using System.Runtime.InteropServices;

namespace AnesManager
{
    /// <summary>
    /// 
    /// </summary>
    public partial class LoginAnes : XtraForm
    {

        public LoginAnes()
        {
            InitializeComponent();
        }
        public LoginAnes(bool isVisible)
        {
            InitializeComponent();
            btnCancel.Visible = isVisible;
        }
        /// <summary>
        /// 初始化控件 位置
        /// </summary>
        /// <returns></returns>
        private void InitControlLocation()
        {
            //this.txtUserName.Location = new System.Drawing.Point(474, 201);
            //this.txtPassWord.Location = new System.Drawing.Point(474, 268);
            this.btnOK.Location = new System.Drawing.Point(506, 272);
            this.btnCancel.Location = new System.Drawing.Point(373, 272);
            this.txtUserName.BringToFront();
            this.txtPassWord.BringToFront();
            this.txtUserName.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtUserName.Properties.NullValuePrompt = "请输入用户名";
            this.txtPassWord.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtPassWord.Properties.NullValuePrompt = "请输入密码";
        }

        private void LoginAnes_Load(object sender, EventArgs e)
        {
            InitControlLocation();



            ////单机版 需要时放开
            //try
            //{
            //    if (File.Exists(System.Environment.CurrentDirectory + "\\Bin\\LocalKeyValue"))
            //    {
            //        DataTable aliasDictData = new DataTable();
            //        aliasDictData.ReadXml(System.Environment.CurrentDirectory + "\\Bin\\LocalKeyValue");
            //        if (aliasDictData != null && aliasDictData.Columns.Count > 0)
            //        {
            //            foreach (DataRow row in aliasDictData.Rows)
            //            {
            //                ExtendApplicationContext.Current.AliasDict.Add(row["key"].ToString(), row["value"].ToString());
            //            }
            //        }
            //    }
            //}
            //catch (Exception)
            //{
            //}



            try
            {
                txtUserName.Text = ApplicationConfiguration.UserLoginName;
                lbLockSystem.Visible = false;

                txtUserName.Properties.ReadOnly = false;


                if (this.Tag != null && this.Tag.Equals("LockSystem".ToUpper()))
                {
                    lbLockSystem.Visible = true;
                    txtUserName.Properties.ReadOnly = true;
                    txtUserName.BackColor = Color.White;
                }


                txtPassWord.Focus();
                if (ExtendApplicationContext.Current.ProgramArgs != null && ExtendApplicationContext.Current.ProgramArgs.Length > 2
                    && ExtendApplicationContext.Current.ProgramArgs[0].ToLower().Equals("autologin"))
                {
                    txtUserName.Text = ExtendApplicationContext.Current.ProgramArgs[1];
                    txtPassWord.Text = ExtendApplicationContext.Current.ProgramArgs[2];
                    btnOK.PerformClick();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            string loginName = txtUserName.Text.Trim().ToUpper();
            string loginPassWord = txtPassWord.Text.Trim();//.ToUpper();
            byte[] passWordBytes = Encoding.Default.GetBytes(loginPassWord);
            string passWordBase64 = Convert.ToBase64String(passWordBytes);
            loginPassWord = Sundries.Encrypto(loginPassWord);
            bool isLogin = false;

            try
            {
                isLogin = SystemHelper.Login(loginName, loginPassWord);

            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);

                this.DialogResult = DialogResult.None;
                this.Cursor = Cursors.Default;

                return;
            }
            if (isLogin)
            {
                //标记登录成功
                this.Tag = "LoginOK";

                ExtendApplicationContext.Current.LoginUserContext.PWD = loginPassWord;
                ExtendApplicationContext.Current.LoginUserContext.PWDBase64 = passWordBase64;
                //登录成功，加上配置
                ApplicationConfiguration.UserLoginName = loginName;
                //成功返回
                this.DialogResult = DialogResult.OK;


            }
            else
            {
                DialogResult dialogResult = XtraMessageBox.Show("您输入的密码或用户名有误，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassWord.Focus();
                //this.ShowDialog();
                //标记登录成功
                if (this.Tag != null && this.Tag.Equals("LockSystem".ToUpper()))
                {
                    this.Tag = "LockSystem".ToUpper();
                }
                else
                {
                    this.Tag = "LoginErr";
                }
                this.DialogResult = DialogResult.None;
            }

            this.Cursor = Cursors.Default;
        }


        private void GetPermissionByLoginUser()
        {





        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //如果是所动系统，则不关闭
            if (this.Tag != null && this.Tag.Equals("LockSystem".ToUpper()))
            {

                //txtUserName.Text = "";
                txtPassWord.Text = "";
                this.DialogResult = DialogResult.None;
            }
            else
            {
                this.Tag = "LoginCancel";
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void LoginAnes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F8))
            {
                DataBaseConfigFrm config = new DataBaseConfigFrm();
                if (config.ShowDialog() == DialogResult.OK)
                {
                    Application.Restart();
                }
            }
            else if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.F4)
            {
                if (this.Tag != null && this.Tag.Equals("LockSystem".ToUpper()))
                {
                    this.DialogResult = DialogResult.None;
                }
                else
                {
                    Application.Exit();
                }
            }

        }

        private void txtPassWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(13))
            {
                btnOK.PerformClick();
            }
        }

        private void picBack_Click(object sender, EventArgs e)
        {

        }



    }
    public static class DoWaterTextBox
    {
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]

        private static extern Int32 SendMessage
         (IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        /// <summary>
        /// 为TextBox设置水印文字
        /// </summary>
        /// <param name="textBox">TextBox</param>
        /// <param name="watermark">水印文字</param>
        public static void SetWatermark(this TextBox textBox, string watermark)
        {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, watermark);
        }
        /// <summary>
        /// 清除水印文字
        /// </summary>
        /// <param name="textBox">TextBox</param>
        public static void ClearWatermark(this TextBox textBox)
        {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, string.Empty);
        }
    }


}