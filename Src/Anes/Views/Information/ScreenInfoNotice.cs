using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.ServiceProxies;

namespace Wis.Anes.Views
{

    [ToolboxItem(false)]
    public partial class ScreenInfoNotice : UserControl
    {
        public ScreenInfoNotice()
        {
            InitializeComponent();
        }

        private void ScreenInfoNotice_Load(object sender, EventArgs e)
        {
            if (ExtendApplicationContext.Current.PatientInformation != null )
            {    
                lbMsgHeader.Text = ExtendApplicationContext.Current.PatientInformation.OperRoom +  "手术室，" + ExtendApplicationContext.Current.PatientInformation.Name + "的家属";
            }
            else
            {
                lbMsgHeader.Text = "患者家属";
            }

            txtNoticeContext_TextChanged(null, null);

            ShowMsgGrid();
        }

        private void txtNoticeContext_TextChanged(object sender, EventArgs e)
        {
            if (chkPreMsg.Checked)
                lbMsg.Text = lbMsgHeader.Text + "，" + txtNoticeContext.Text ;
            else
                lbMsg.Text =  txtNoticeContext.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNoticeContext.Text))
            {
                string id = ExtendApplicationContext.Current.LoginUserContext.HisUserID + " " + DateTime.Now.Ticks;
                string sql = string.Format(@"insert into WIS_SCREEN_MSG (ID, MESSAGE, INSERT_TIME, COUNTS, STATUS, OTHER1, USER_ID, TYPE, DEPT_CODE)  values('{0}', '{1}', sysdate, '{3}', 1, null, '紧急公告', 2, '{2}')", id, lbMsg.Text, ApplicationConfiguration.OpertionDeptCode, numUDNoticeTime.Value);

                CommonProxy.ExecuteNonQuery(sql);
            }
            ShowMsgGrid();
        }

        private void ShowMsgGrid()
        {
            string sql = string.Format(@"SELECT MESSAGE,INSERT_TIME,COUNTS FROM WIS_SCREEN_MSG WHERE STATUS =1 AND TYPE =2 ORDER BY INSERT_TIME DESC ");
           DataTable dt =  CommonProxy.GetDataFromSQLString(sql);
           dgvMsg.DataSource = dt;
        }
        private void chkPreMsg_CheckedChanged(object sender, EventArgs e)
        {
            lbMsgHeader.Visible = chkPreMsg.Checked ;
            txtNoticeContext_TextChanged(null,null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ((Form)this.Parent).Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ShowMsgGrid();
        }



    }
}
