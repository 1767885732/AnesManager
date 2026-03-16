using DevExpress.XtraEditors;
using Wis.Anes.BusinessEntity;
using Wis.Anes.DataAccess;
using Wis.Anes.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Wis.Anes.Views.EMR
{
    public partial class PatEMRInfoInputFrm : XtraForm
    {
        public PatEMRInfoInputFrm()
        {
            InitializeComponent();
        }

        public string PatientID
        {
            get
            {
                return txtPatId.Text;
            }
        }

        public string DeptID
        {
            get
            {
                return cbxDept.SelectedValue != null? cbxDept.SelectedValue.ToString() : "";
            }
        }

        private void PatEMRInfoInputFrm_Load(object sender, EventArgs e)
        {
            BindDept();
            txtPatId.Text = ExtendApplicationContext.Current.PatientContext.PatientID + "_" + ExtendApplicationContext.Current.PatientContext.VisitID;
            txtPatName.Text = ExtendApplicationContext.Current.PatientInformation.Name;
        }

        private void BindDept()
        {
            DictDA dictProxy = new DictDA();
            Dict.DeptDictDataTable dt = dictProxy.GetDeptDict();
            cbxDept.DisplayMember = "DEPT_NAME";
            cbxDept.ValueMember = "DEPT_CODE";
            cbxDept.DataSource = dt;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
