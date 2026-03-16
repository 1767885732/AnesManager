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
using Wis.Anes.Framework.Utilities;
using Wis.Anes.Framework.Configurations;

namespace Wis.Anes
{
    public partial class PwdChangeFrm : XtraForm
    {
        public PwdChangeFrm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Shift键按下
        /// </summary>
        private bool _shiftDown = false;

        private string _userID = ApplicationConfiguration.UserLoginName; //ExtendApplicationContext.Current.LoginUserContext.UserID;

        private void button1_Click(object sender, EventArgs e)
        {
            if (SystemHelper.Login(_userID, ((_shiftDown) ? txtPassWord.Text.ToUpper().Trim() : Sundries.Encrypto(txtPassWord.Text.Trim()))))
            {
                if (txtNewPWD.Text.Trim() != "" && txtNewPWDtoo.Text.Trim() != "")
                {
                    if (txtNewPWD.Text.Trim() == txtNewPWDtoo.Text.Trim())
                    {
                        if (PermissionProxy.UpdateUsersPwd(_userID, Sundries.Encrypto(txtNewPWD.Text.Trim())) > 0)
                        {
                            ExtendApplicationContext.Current.LoginUserContext.PWD = Sundries.Encrypto(txtNewPWD.Text.Trim());
                            Dialog.MessageBox("密码修改成功", MessageBoxIcon.Asterisk);
                        }
                    }
                    else
                    {
                        Dialog.MessageBox("确认新密码错误", MessageBoxIcon.Information);
                    }
                }
                else
                {
                    Dialog.MessageBox("新密码不能为空", MessageBoxIcon.Information);
                }
            }
            else
            {
                Dialog.MessageBox("旧密码输入错误！", MessageBoxIcon.Information);
            }
        }

        private void PwdChangeFrm_KeyUp(object sender, KeyEventArgs e)
        {
            _shiftDown = false;
        }

        private void PwdChangeFrm_KeyDown(object sender, KeyEventArgs e)
        {
            _shiftDown = e.Shift;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}