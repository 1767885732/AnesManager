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
using Wis.Anes.DataAccess;

namespace Wis.Anes.Views.Information
{
    [ToolboxItem(false)]
    public partial class OperationNotice : UserControl
    {
        private string msgText = "";
        private string patientDept_Code = "";
        public OperationNotice()
        {
            DataTable dt = GetPatientDeptCode(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.OperID, ExtendApplicationContext.Current.PatientContext.VisitID);
            if (dt != null)
            {
                patientDept_Code = dt.Rows[0]["dept_stayed"].ToString();
                msgText = dt.Rows[0]["dept_name"].ToString() + "的护士请注意：贵科，" + dt.Rows[0]["bed_no"].ToString() +"床 姓名"+
                    dt.Rows[0]["name"].ToString() +
                   " 性别" + dt.Rows[0]["sex"].ToString() +" 年龄" + dt.Rows[0]["AGE"].ToString() +"岁"+
                   " 住院号" + dt.Rows[0]["INP_NO"] + ",即将在" + dt.Rows[0]["operating_room_no"].ToString() +"号手术间"+
                   "做" + dt.Rows[0]["OPER_NAME"].ToString() + "手术，请做好术前准备！";
            }
            else
            {
                patientDept_Code = "";
                msgText = "科室的护士请注意，贵科，" +
                        ExtendApplicationContext.Current.PatientInformation.BedNo + "床 姓名" +
                        ExtendApplicationContext.Current.PatientInformation.Name + " 性别" +
                        ExtendApplicationContext.Current.PatientInformation.Sex +
                        " 住院号" + ExtendApplicationContext.Current.PatientInformation.InpNo +
                        ",即将在" + ExtendApplicationContext.Current.PatientInformation.OperRoom + "号手术间" +
                        "做"  +ExtendApplicationContext.Current.PatientInformation.OperationName + "手术，请做好术前准备！";
            }

            InitializeComponent();
        }

        private void OperationNotification_Load(object sender, EventArgs e)
        {
            lbMsg.Text = msgText;
            txtNoticeContext.Text = msgText;
            txtNoticeContext_TextChanged(null, null);

            ShowMsgGrid();
        }

        private void txtNoticeContext_TextChanged(object sender, EventArgs e)
        {
            lbMsg.Text = txtNoticeContext.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNoticeContext.Text))
            {
                string id = ExtendApplicationContext.Current.LoginUserContext.HisUserID + " " + DateTime.Now.ToString("yyyyMMddHHmmss");
                string sql = string.Format(@"insert into WIS_ANES_COMMUNICT_PLATFORM (ID,MESSAGE,INSERT_TIME,STATE,USER_ID,DEPT_CODE,OPER_DEPT_CODE,PAT_ID,VISIT_ID,OPER_ID) 
                                             values('{0}', '{1}', sysdate, 0, '{2}','{3}', '{4}','{5}',{6},{7})",
                                                     id, lbMsg.Text, ExtendApplicationContext.Current.LoginUserContext.HisUserID, patientDept_Code, ApplicationConfiguration.OpertionDeptCode,
                                                     ExtendApplicationContext.Current.PatientContext.PatientID,ExtendApplicationContext.Current.PatientContext.VisitID,ExtendApplicationContext.Current.PatientContext.OperID);

                CommonProxy.ExecuteNonQuery(sql);
            }
            ShowMsgGrid();
        }

        private void ShowMsgGrid()
        {
            string sql = string.Format(@"SELECT MESSAGE,INSERT_TIME FROM WIS_ANES_COMMUNICT_PLATFORM ORDER BY INSERT_TIME DESC ");
            DataTable dt = CommonProxy.GetDataFromSQLString(sql);
            dgvMsg.DataSource = dt;
        }
        private void chkPreMsg_CheckedChanged(object sender, EventArgs e)
        {
            txtNoticeContext_TextChanged(null, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ((Form)this.Parent).Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ShowMsgGrid();
        }

        private DataTable GetPatientDeptCode(string patientId, decimal operId, decimal visitId)
        {
            DataTable dt = null;
            if (!string.IsNullOrEmpty(patientId) && !string.IsNullOrEmpty(operId.ToString()) && !string.IsNullOrEmpty(visitId.ToString()))
            {
                string sql = @"select pat.inp_no,pat.name,pat.sex,Datepart(Yy,GETDATE()) - Datepart(yy,pat.date_of_birth) AS AGE, dict.dept_name,master.dept_stayed,master.bed_no,master.operating_room_no,master.oper_name 
                                from WIS_OPER_MASTER master 
                                left join WIS_DICT_DEPT dict on master.dept_stayed=dict.dept_code
                                left join WIS_PAT_MASTER_INDEX pat on pat.pat_id=master.pat_id
                                where master.pat_id='" + patientId + "' and master.oper_id='" + operId + "' and master.visit_id='" + visitId + "' ";
                //string sql = @"select pat.inp_no,pat.name,pat.sex,TO_CHAR(SYSDATE,'YYYY') - TO_CHAR(pat.date_of_birth,'YYYY') AS AGE, dict.dept_name,master.dept_stayed,master.bed_no,master.operating_room_no,master.oper_name 
                //                from WIS_OPER_MASTER master 
                //                left join WIS_DICT_DEPT dict on master.dept_stayed=dict.dept_code
                //                left join WIS_PAT_MASTER_INDEX pat on pat.pat_id=master.pat_id
                //                where master.pat_id='" + patientId + "' and master.oper_id='" + operId + "' and master.visit_id='" + visitId + "' ";
                CommonDA da = new CommonDA();
                dt = da.GetDataFromSQLString(sql);
            }
            return dt;
        }
    }
}
