using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Views;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework;
using Wis.Anes.ServiceProxies;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.DataAccess;
using DevExpress.XtraEditors;

namespace Wis.Anes.Views
{
    public partial class OperationScaleConfig : BaseView
    {


        public OperationScaleConfig()
        {
            InitializeComponent();
            this.dgvOperation.DataError += delegate(object sender, DataGridViewDataErrorEventArgs e) { };
        }
        private Dict.HisUserDataTable hisUserDataTable = null;
        private Dict.OperationDictDataTable operationDictDataTable = null;
        private Dict.DeptDictDataTable deptDictDataTable = null;
        private DataTable userListDataTable = null;
        private DataTable operationDataTable = null;
        private DataTable operScaleDict;
        PermissionDA permissionDA = new PermissionDA();
        private void OperationScaleConfig_Load(object sender, EventArgs e)
        {

            LoadDict();
            txtDeptCode.Data = ApplicationConfiguration.AnesthesiaWardCode;
            txtDeptCode.Text = deptDictDataTable.FindByDEPT_CODE(ApplicationConfiguration.AnesthesiaWardCode).DEPT_NAME;
            userListDataTable = permissionDA.GetUserList();
            operationDataTable = permissionDA.GetOperationList(txtDeptCode.Data.ToString());
            //dgvOperation.DataSource = operationDataTable;

            SearchUser();
            SearchOperation();
        }
        private void SearchOperation()
        {
            dgvOperation.DataSource = operationDataTable;


            int index = SelectOperation(operationDataTable);
            if (index <= 0 )
                return ;
            dgvOperation.Rows[index].Selected = true;
            //dgvUsers.CurrentRow = dgvUsers.Rows[index];
            dgvOperation.CurrentCell = dgvOperation.Rows[index].Cells[0];
        }

        private void SearchUser()
        {
            DataTable t = userListDataTable.Copy();

            t.Clear();
            if (!string.IsNullOrEmpty(txtDeptCode.Text))
            {

                DataRow[] rows = userListDataTable.Select(" USER_DEPT = '" + txtDeptCode.Data.ToString() + "'");
                foreach (DataRow row in rows)
                    t.ImportRow(row);
            }

            dgvUsers.DataSource = t;

            int index = SelectUser(t);
            if (dgvUsers.RowCount > 0)
            {
                dgvUsers.Rows[index].Selected = true;
                //dgvUsers.CurrentRow = dgvUsers.Rows[index];
                dgvUsers.CurrentCell = dgvUsers.Rows[index].Cells[0];
            }
        }
        private int SelectOperation(DataTable dataTable)
        {
            int index = -1;

            if (!string.IsNullOrEmpty(txtOperationCode.Text))
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    if (dataTable.Rows[i]["OPER_CODE"].ToString().Contains(txtOperationCode.Text))
                    {
                        index = i;
                        return index;
                    }
                }
            }
            if (index == -1 && txtOperationName.Data != null && !string.IsNullOrEmpty(txtOperationName.Data.ToString()))
            {


                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    if (dataTable.Rows[i]["OPER_CODE"].ToString() == txtOperationName.Data.ToString())
                    {
                        index = i;
                        return index;
                    }
                }
            }


            return index;
        }
        private int SelectUser(DataTable dataTable)
        {
            int index = 0;
            if (txtUserName.Data != null && !string.IsNullOrEmpty(txtUserName.Data.ToString()))
            {


                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    if (dataTable.Rows[i]["USER_ID"].ToString() == txtUserName.Data.ToString())
                    {
                        index = i;
                        return index;
                    }
                }
            }
            return index;
        }
        private void LoadDict()
        {
            operScaleDict = new DataTable();
            operScaleDict.Columns.Add("Value", typeof(decimal));
            operScaleDict.Columns.Add("Text", typeof(string));
            for (int i = 0; i <= 4; i++)
            {
                DataRow row = operScaleDict.NewRow();
                row["Value"] = i;
                switch (i)
                {
                    case 1: row["Text"] = "一级"; break;
                    case 2: row["Text"] = "二级"; break;
                    case 3: row["Text"] = "三级"; break;
                    case 4: row["Text"] = "四级"; break;
                }
                operScaleDict.Rows.Add(row);
            }
            Column3.DataSource = operScaleDict;
            Column3.ValueMember = "Value";
            Column3.DisplayMember = "Text";
            //获取用户列表
            if (ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_PERM_HIS_USER"))
            {
                hisUserDataTable = ExtendApplicationContext.Current.CodeTables["WIS_PERM_HIS_USER"] as Dict.HisUserDataTable;
            }
            else
            {
                hisUserDataTable = DictProxy.GetHisUsers();
            }


            //获取手术信息字典表
            if (ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_DICT_OPERATION"))
            {
                operationDictDataTable = ExtendApplicationContext.Current.CodeTables["WIS_DICT_OPERATION"] as Dict.OperationDictDataTable;
            }
            else
            {
                operationDictDataTable = DictProxy.GetOperationDict();
            }

            //科室字典表
            if (ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_DICT_DEPT"))
            {
                deptDictDataTable = ExtendApplicationContext.Current.CodeTables["WIS_DICT_DEPT"] as Dict.DeptDictDataTable;
            }
            else
            {
                deptDictDataTable = DictProxy.GetDeptDict();
            }

        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            SearchUser();
            operationDataTable = permissionDA.GetOperationList(txtDeptCode.Data.ToString());
            dgvOperation.DataSource = operationDataTable;
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0)
            {
                return;
            }
            DataGridView dgv = (DataGridView)sender;



            if (e.ColumnIndex == 0)
            {



                for (int i = 0; i < dgv.RowCount; i++)
                {
                    dgv.Rows[i].Cells[0].Value = false;
                }
          
            }
            else
            {
                return;
            }



            string selectedUserID = string.Empty;
            int userIDColIndex = -1;
            for (int j = 0; j < dgv.ColumnCount; j++)
            {
                if (!string.IsNullOrEmpty(dgv.Columns[j].DataPropertyName) && dgv.Columns[j].DataPropertyName.ToLower() == "user_id")
                {
                    userIDColIndex = j;
                    break;
                }
            }
            if (userIDColIndex != -1)
            {
                dgv.EndEdit();
                if (dgv.Rows[e.RowIndex].Cells[0].Value != null && dgv.Rows[e.RowIndex].Cells[0].Value.ToString().ToLower() == "true")
                {
                    selectedUserID = dgv.Rows[e.RowIndex].Cells[userIDColIndex].Value.ToString();
                    ShowOperationListByUserID(selectedUserID);
                }
                else
                {
                    ShowOperationListByUserID("");
                }
            }


        }

        private void btnSearchOperation_Click(object sender, EventArgs e)
        {
            SearchOperation();



        }

        private void ShowOperationListByUserID(string selectedUserID)
        {
            DataGridView dgv = dgvOperation;






            //有选中行
            if (!string.IsNullOrEmpty(selectedUserID))
            {


                int opertionCodeIndex = -1;
                int opertionNameIndex = -1;

                for (int j = 0; j < dgv.ColumnCount; j++)
                {
                    if (!string.IsNullOrEmpty(dgv.Columns[j].DataPropertyName))
                    {

                        if (dgv.Columns[j].DataPropertyName.ToLower() == "oper_code")
                        {
                            opertionCodeIndex = j;
                        }
                        else if (dgv.Columns[j].DataPropertyName.ToLower() == "OPER_NAME")
                        {
                            opertionNameIndex = j;
                        }
                    }
                }




                Common.OPER_SCALE_CONFIGDataTable operationScale = permissionDA.GetOperationScaleConfigByUserID(selectedUserID);


                for (int i = 0; i < dgv.RowCount; i++)
                {
                    dgv.Rows[i].Cells[0].Value = false;

                    foreach (Common.OPER_SCALE_CONFIGRow row in operationScale)
                    {
                        if (row.OPER_CODE == dgv.Rows[i].Cells[opertionCodeIndex].Value.ToString() && row.OPER_NAME == dgv.Rows[i].Cells[opertionNameIndex].Value.ToString())
                        {

                            dgv.Rows[i].Cells[0].Value = true;
                        }

                    }

                }
            }
            else
            {

                for (int i = 0; i < dgv.RowCount; i++)
                {
                    dgv.Rows[i].Cells[0].Value = false;

                }
            }


        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dgvUsers;
            string selectedUserID = string.Empty;
            int userIDColIndex = -1;
            for (int j = 0; j < dgv.ColumnCount; j++)
            {
                if (!string.IsNullOrEmpty(dgv.Columns[j].DataPropertyName) && dgv.Columns[j].DataPropertyName.ToLower() == "user_id")
                {
                    userIDColIndex = j;
                    break;
                }
            }
            if (userIDColIndex != -1)
            {
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    if (dgv.Rows[i].Cells[0].Value != null && dgv.Rows[i].Cells[0].Value.ToString().ToLower() == "true")
                    {

                        selectedUserID = dgv.Rows[i].Cells[userIDColIndex].Value.ToString();
                        break;
                    }
                }
            }
            //有选中行
            if (!string.IsNullOrEmpty(selectedUserID))
            {
                Common.OPER_SCALE_CONFIGDataTable operationScale = permissionDA.GetOperationScaleConfigByUserID(selectedUserID);
                Common.MED_USER_VS_OPERSCALEDataTable operScaleConfig = permissionDA.GetOperationConfigByDeptCode(txtDeptCode.Data.ToString());
                //foreach (Common.OPER_SCALE_CONFIGRow row in operationScale)
                //{
                //    row.Delete();
                //}
                dgv = dgvOperation;

                int opertionCodeIndex = -1;
                int opertionNameIndex = -1;
                int opertionScaleIndex = -1;
                for (int j = 0; j < dgv.ColumnCount; j++)
                {
                    if (!string.IsNullOrEmpty(dgv.Columns[j].DataPropertyName))
                    {

                        if (dgv.Columns[j].DataPropertyName.ToLower() == "oper_code")
                        {
                            opertionCodeIndex = j;
                        }
                        else if (dgv.Columns[j].DataPropertyName.ToLower() == "OPER_NAME")
                        {
                            opertionNameIndex = j;
                        }
                        else if (dgv.Columns[j].DataPropertyName.ToLower() == "oper_scale")
                        {
                            opertionScaleIndex = j;
                        }
                    }
                }
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    if (dgv.Rows[i].Cells[0].Value != null && dgv.Rows[i].Cells[0].Value.ToString().ToLower() == "true")
                    {
                        DataRow[] tempDataRows = operationScale.Select(string.Format("OPER_NAME='{0}'", dgv.Rows[i].Cells[opertionNameIndex].Value.ToString()));
                        if (tempDataRows.Length == 0)
                        {
                            Common.OPER_SCALE_CONFIGRow row = operationScale.NewOPER_SCALE_CONFIGRow();

                            row.USER_ID = selectedUserID;
                            row.OPER_CODE = dgv.Rows[i].Cells[opertionCodeIndex].Value.ToString();
                            row.OPER_NAME = dgv.Rows[i].Cells[opertionNameIndex].Value.ToString();
                            operationScale.AddOPER_SCALE_CONFIGRow(row);
                        }
                    }
                    if (!string.IsNullOrEmpty(dgv.Rows[i].Cells[opertionScaleIndex].Value.ToString()))
                    {
                        DataRow[] tempDataRows = operScaleConfig.Select(string.Format("OPER_NAME='{0}'", dgv.Rows[i].Cells[opertionNameIndex].Value.ToString()));
                        Common.MED_USER_VS_OPERSCALERow row = tempDataRows.Length > 0 ? tempDataRows[0] as Common.MED_USER_VS_OPERSCALERow : operScaleConfig.NewMED_USER_VS_OPERSCALERow();
                        row.DEPT_CODE = txtDeptCode.Data.ToString();
                        row.OPER_NAME = dgv.Rows[i].Cells[opertionNameIndex].Value.ToString();
                        row.OPER_SCALE = Convert.ToDecimal(dgv.Rows[i].Cells[opertionScaleIndex].Value.ToString());
                        if (row.RowState == DataRowState.Detached) operScaleConfig.AddMED_USER_VS_OPERSCALERow(row);
                    }
                }

                int ii = permissionDA.UpdateOperationScaleConfig(operationScale);
                int result = permissionDA.UpdateOperationScaleConfigDept(operScaleConfig);
                if (ii >= 0)
                {
                    XtraMessageBox.Show("数据保存成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ((Form)this.Parent).Close();
        }


    }
}
