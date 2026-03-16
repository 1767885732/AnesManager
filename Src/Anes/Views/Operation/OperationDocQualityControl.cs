using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Views;
using Wis.Anes.Framework.Configurations;
using System.Collections;
using Wis.Anes.ServiceProxies;
using Wis.Anes.Framework;
using Wis.Anes.BusinessEntity;

namespace Wis.Anes.Views
{

    [ToolboxItem(false)]
    public partial class OperationDocQualityControl : BaseView
    {

        private List<string> DoctorList = new List<string>();
        private List<string> PatientList = new List<string>();

        private List<string> OperationStatusList = new List<string>();

        Dict.HisUserDataTable doctorTable = ExtendApplicationContext.Current.CodeTables["WIS_PERM_HIS_USER"] as Dict.HisUserDataTable;

        public OperationDocQualityControl()
        {
            InitializeComponent();
        }

        List<string> docCheckList = new List<string>();


        private void InitDocCheckList()
        {
            docCheckList.Clear();
            if (!string.IsNullOrEmpty(ApplicationConfiguration.DocNameCheckList))
            {
                IEnumerator ie = ApplicationConfiguration.DocNameCheckList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).GetEnumerator();
                while (ie.MoveNext())
                {
                    docCheckList.Add(ie.Current.ToString());

                }
            }
        }
        private void OperationDocQualityControl_Load(object sender, EventArgs e)
        {
            dateTimePickerQuery.DateTime = DateTime.Now;
            InitDocCheckList();

            InitDgvDocCheck();

            InitDgvDocCheckData();
            

        }


        private void InitDgvDocCheck()
        {
     
            IEnumerator ie = dgvDocCheck.Columns.GetEnumerator();
            while (ie.MoveNext())
            {
                if (ie.Current.GetType() == typeof(DataGridViewCheckBoxColumn))
                {
                    dgvDocCheck.Columns.Remove((DataGridViewColumn)ie.Current);
                }
            }

            for (int i = 0; i < docCheckList.Count; i++)
            {

                DataGridViewCheckBoxColumn chkColumn = new DataGridViewCheckBoxColumn();
                chkColumn.HeaderText = docCheckList[i];
                chkColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                chkColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                dgvDocCheck.Columns.Add(chkColumn);
            }
            

        }

        private void InitDgvDocCheckData()
        {

            dgvDocCheck.Rows.Clear();
            DataTable anesCareCheckRecord = CareDocsProxy.GetAnesCareCheckRecord();
            DataTable operationsInfoDataTable = PatientInformationsProxy.GetPatientListDataTable(dateTimePickerQuery.DateTime.Date, "", "", ""
               , "", "", ApplicationConfiguration.OpertionDeptCode, "", "","", "");

            operationsInfoDataTable = SetFilter(operationsInfoDataTable);
            dgvDocCheck.RowCount = operationsInfoDataTable.Rows.Count;
            for (int i = 0; i < operationsInfoDataTable.Rows.Count; i++)
            { 
                PatientInformation patientInformation = new PatientInformation(operationsInfoDataTable.Rows[i]);
                string colName = "" ;
                for (int j = 0; j < dgvDocCheck.ColumnCount; j++)
                { 
                    colName = dgvDocCheck.Columns[j].Name ;
                    switch  (colName)
                    {
                        case "ColumnPatientID":
                            dgvDocCheck.Rows[i].Cells[j].Value = patientInformation.PatientID;
                            break;
                        case "ColumnVisitID":
                            dgvDocCheck.Rows[i].Cells[j].Value = patientInformation.VisitID;
                            break;
                        case "ColumnOperID":
                            dgvDocCheck.Rows[i].Cells[j].Value = patientInformation.OperID;
                            break;
                        case "ColumnOperationDate":
                            dgvDocCheck.Rows[i].Cells[j].Value = patientInformation.OperationTime.ToString("yyyy-MM-dd hh:MM");
                            break;
                        case "ColumnOperationRoom":
                            dgvDocCheck.Rows[i].Cells[j].Value = patientInformation.OperRoom;
                            break;
                        case "ColumnOperationName":
                            dgvDocCheck.Rows[i].Cells[j].Value = patientInformation.OperationName;
                            break;
                        case "ColumnPatient":
                            dgvDocCheck.Rows[i].Cells[j].Value = patientInformation.Name;
                            break;
                        case "ColumnOperationStatus":
                            dgvDocCheck.Rows[i].Cells[j].Value = OperationStatusHelper.OperationStatusToString((OperationStatus)(int)patientInformation.OperStatus);
                            break;
                        case "ColumnAnesDoctor":
                            {
                                string anes = patientInformation.AnesDoctor;
                                if (!string.IsNullOrEmpty(anes))
                                {
                                    if (doctorTable != null)
                                    {
                                        Dict.HisUserRow row = doctorTable.FindByUSER_ID(anes);
                                        if (row != null)
                                        {
                                            anes = row.USER_NAME;
                                        }
                                    }
                                }
                                else
                                {
                                    anes = "";
                                }

                                dgvDocCheck.Rows[i].Cells[j].Value = anes;
                                break;
                            
                            }


                    }//end switch  (colName)
                }//end for (int j = 0; j < dgvDocCheck.ColumnCount; j++)


                //获取已生成的文书
                DataRow[] dataRows = anesCareCheckRecord.Select(" PAT_ID = '" + patientInformation.PatientID + "' AND VISIT_ID = " + patientInformation.VisitID + " AND OPER_ID = " + patientInformation.OperID );
                if (dataRows != null && dataRows.Length > 0)
                {
                    for (int index = 0; index < dataRows.Length; index++)
                    {
                        for (int j = 0; j < dgvDocCheck.ColumnCount; j++)
                        {
                            if (dgvDocCheck.Columns[j].HeaderText == dataRows[index]["DOC_NAME"].ToString())
                            {
                                dgvDocCheck.Rows[i].Cells[j].Value = 1;
                            }
                        }
                    }
                }

            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            InitDgvDocCheckData();
        }

        protected DataTable SetFilter(DataTable dt)
        {
            string filter = string.Format(" 1 = 1 " );

            if (!string.IsNullOrEmpty(txtOtherUse.Text))
            {
                filter += " and " + string.Format(@" ( ANES_DOCTOR = '{0}' or ANES_DOCTOR = '{1}' ) ", txtOtherUse.Text, txtOtherUse.Data);

            }
            else if (radioType.SelectedIndex == 1)
            {
                filter += " and " + string.Format(@" ( ANES_DOCTOR = '{0}' or ANES_ASSISTANT = '{1}' ) ", ExtendApplicationContext.Current.LoginUserContext.UserName, ExtendApplicationContext.Current.LoginUserContext.UserID);
            }

            dt.DefaultView.RowFilter = filter;
            dt.DefaultView.Sort = " OPERATING_ROOM_NO,  ANES_DOCTOR ";

            return dt.DefaultView.ToTable();
        }

        private void radioType_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);
        }
   
    }
}
