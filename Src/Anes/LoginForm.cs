/*----------------------------------------------------------------
// 北京拓扑工厂科技发展有限公司
// 文件名：Login.cs
// 文件功能描述：登陆界面
// 创建标识：XXX-2008-10-23
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Wis.Anes.Framework;
using Wis.Anes.ServiceProxies;
using Wis.Anes.Framework.Controls.Base;
using Wis.Anes;
using Wis.Anes.Framework.Configurations;
using System.IO;


namespace Wis.Anes
{
    /// <summary>
    /// 
    /// </summary>
    public partial class LoginForm : XtraForm
    {

        public LoginForm()
        {
            InitializeComponent();
        }
        public LoginForm(bool isVisible)
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
            //this.Width = Screen.PrimaryScreen.Bounds.Width;
            //this.Height = Screen.PrimaryScreen.Bounds.Height;
            
            //加载皮肤
            Image image = ApplicationConfiguration.GetSkinImage("登录界面2.png");
            
            if (image != null)
            {               
                picBack.Image = image;
                picBack.Left = (int)((Width - picBack.Width) / 2);
                picBack.Top = (int)((Height - picBack.Height) / 2);


                //txtUserName.Left += picBack.Left;
                //txtUserName.Top += picBack.Top;
                txtUserName.Left = picBack.Left + 180;
                txtUserName.Top = picBack.Top + 135;
                //txtPassWord.Left += picBack.Left;
                //txtPassWord.Top += picBack.Top;
                txtPassWord.Left = picBack.Left + 180;
                txtPassWord.Top = picBack.Top + 176;
                //btnOK.Left += picBack.Left;
                //btnOK.Top += picBack.Top;
                btnOK.Left = picBack.Left + 120;
                btnOK.Top = picBack.Top + 230;
                //btnCancel.Left += picBack.Left;
                //btnCancel.Top += picBack.Top;
                btnCancel.Left = picBack.Left + 250;
                btnCancel.Top = picBack.Top + 230;

                lblSystemName.Parent = picBack;
                lblSystemName.Left = 115;
                lblSystemName.Top = 60;
                lblSystemName.BackColor = Color.Transparent;

                //lbCopyRight.BackColor = Color.Transparent;
                //lbCopyRight.Parent = picBack;

                lbLockSystem.Parent = picBack;
                lbLockSystem.BackColor = Color.Transparent;
                lbLockSystem.Left = 220;
                lbLockSystem.Top = 230;
                //lbLockSystem.Left += picBack.Left;
                //lbLockSystem.Top += picBack.Top;
            }
        
        }

        private void LoginForm_Load(object sender, EventArgs e)
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
                lbLockSystem.Visible = false ;

                txtUserName.Properties.ReadOnly = false ;


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
            catch(Exception ex)
            {
                ExceptionHandler.Handle(ex) ;

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

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
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


    
}