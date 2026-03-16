using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Utilities;
using System.IO;
using System.Runtime.InteropServices;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using Wis.Anes.Framework.Controls;
using System.Diagnostics;
using Wis.Anes.Framework.Views;
using Wis.Anes.BusinessEntity;
using Wis.Anes.ServiceProxies;
using Wis.Anes.Framework;
using Wis.Anes.Constants;
//using System.Data.OracleClient;

namespace Wis.Anes.Views
{
    public partial class DocumentsPanel : BaseView
    {
        # region 构造方法

        public DocumentsPanel() : this(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID) { }
        public DocumentsPanel(string patientID, decimal visitID, decimal operID) : this(patientID, visitID, operID, "病历病程") { }

        public DocumentsPanel(string patientID, decimal visitID, decimal operID, string title)
            //: base(patientID, visitID, operID, title)
        {
            Caption = ViewNames.HisDocuments;
            InitializeComponent();
            //medDataGridView1.AutoGenerateColumns = false;
            //medDataGridView1.Columns.Add(GenerateColumn("住院次数", "", 60));
            //medDataGridView1.Columns.Add(GenerateColumn("标题", "TOPIC", 146));
            //medDataGridView1.Columns.Add(GenerateColumn("创建者", "CREATOR_NAME", 120));
            //medDataGridView1.Columns.Add(GenerateColumn("最后修改时间", "LAST_MODIFY_DATE_TIME", 100));
            //medDataGridView1.Columns.Add(GenerateColumn("FILE_NO", "FILE_NO", 0));
            //medDataGridView1.Columns["FILE_NO"].Visible = false;
            RefreshDataa();
        }

        #endregion 构造方法

        #region 变量

        /// <summary>
        /// 病理病程索引表
        /// </summary>
        Sync.WIS_MR_INDEXDataTable mrIndexDT;
        Sync.WIS_MR_FILE_INDEXDataTable mrFileIndexDT;
        //Patient.MrFileIndexDataTable mrFileIndexDataTable;
        //DataTable mrFileIndexDataTable;
        string _patientID = null;
        decimal _visitID = 0;

        #endregion 变量

        #region 方法

        /// <summary>
        /// 刷新数据
        /// </summary>
        private  void RefreshDataa()
        {

            SyncProxy.SyncEMR(ExtendApplicationContext.Current.PatientInformation.PatientID, ExtendApplicationContext.Current.PatientInformation.VisitID ,null);



            if (this.gridView1.RowCount == 0) return;
            //if (this.medDataGridView1 == null) return;
            ///没有病人信息则不处理
            if (string.IsNullOrEmpty(_patientID)) return;

            //string sqlText = "SELECT     FILE_NO, TOPIC, LAST_MODIFY_DATE_TIME, FILE_NAME, CREATOR_NAME, VISIT_ID, PATIENT_ID"
            //    + " FROM WIS_MR_FILE_INDEX WHERE     (PATIENT_ID = '" +  _patientID 
            //    + "') AND (VISIT_ID = " + _visitID.ToString() +") OR (" + _visitID.ToString() +"= 0)";
            //string connStr = ConfigurationManager.ConnectionStrings[1].ConnectionString;

            //string[] configInfo = Com.Wis.Icu.ClientLibrary.ClientDataModule.GetSettings();
            //mrFileIndexDataTable = new DataTable();
            //if (configInfo[0] == "LocalForSqlServer")
            //{
            //    connStr = ConfigurationManager.ConnectionStrings[3].ConnectionString;
            //    SqlDataAdapter adapter = new SqlDataAdapter(sqlText, connStr);
            //    adapter.Fill(mrFileIndexDataTable);
            //}
            //else
            //{
            //    OleDbDataAdapter adapter = new OleDbDataAdapter(sqlText, connStr);
            //    adapter.Fill(mrFileIndexDataTable);//ClientLibrary.ClientDataModule.Patient.GetPatientFileIndex(_patientID, (int)_visitID);
            //}
            //if (mrFileIndexDataTable.Rows.Count < 1)
            //    return;
            /////添加空行到表
            ////AddEmptyRowToTable(mrFileIndexDataTable, 26, "FILE_NO");

            //this.medDataGridView1.DataSource = mrFileIndexDataTable;
        }

        //protected override void OnPatientChange(Com.Wis.Icu.Patient.PatientRow patientRow)
        //{
        //    RefreshData();
        //}

        #endregion 方法

        #region 事件

        /// <summary>
        /// 表格单元格需要数据事件
        /// </summary>
        /// <param name="sender">表格</param>
        /// <param name="e">事件参数</param>
        private void medDataGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            ///填写第一列数据
            //if ((e.ColumnIndex == 0) && ((decimal)mrFileIndexDataTable.Rows[e.RowIndex]["VISIT_ID"] > 0))
            //{
            //    e.Value = mrFileIndexDataTable.Rows[e.RowIndex]["VISIT_ID"];

            //}

        }

        #endregion 事件

        private void medDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        [DllImport("fsrv.dll")]
        private static extern int get_file(string host_addr, string remote_file, string local_file, int option);
        //private void medDataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    string fileName = "";
        //    string path = "";

        //    try
        //    {
        //        //Convert.ToInt32(medDataGridView1.Rows[e.RowIndex].Cells["FILE_NO"]);
        //        //mrFileIndexDT = DataHelper.GetMrFileIndex(_patientID, (int)_visitID, Convert.ToInt32(medDataGridView1.Rows[e.RowIndex].Cells["FILE_NO"].Value));
        //        if (mrFileIndexDT.Rows.Count > 0)
        //        {
        //            fileName = mrFileIndexDT.Rows[0]["file_name"].ToString();
        //            if (fileName == "")
        //            {
        //                return;
        //            }
        //        }
        //        mrIndexDT = DataHelper.GetMrIndex(_patientID, (int)_visitID);
        //        if (mrIndexDT.Rows.Count > 0)
        //        {
        //            string strpatienturl = string.Empty;
        //            string strlocaurl = string.Empty;
        //            string strpath = string.Empty;
        //            strpatienturl = _patientID;

        //            strlocaurl = strpatienturl.Substring(strpatienturl.Length - 2);
        //            strpath = strpatienturl.Substring(0, strpatienturl.Length - 2);
        //            path = mrIndexDT.Rows[0]["access_path"].ToString();
        //            if (path == "")
        //            {
        //                return;
        //            }
        //            //path = path.Replace(':', '$');
        //            path += "\\" + strlocaurl + "\\" + strpath;

        //            if (System.IO.File.Exists(@"c:\mrtemp.doc"))
        //            {
        //                System.IO.File.Delete(@"c:\mrtemp.doc");
        //            }
        //            int result = get_file("192.168.1.53", path + @"\" + fileName, @"c:\mrtemp.doc", 1);
        //            if (result >= 0 && System.IO.File.Exists(@"c:\mrtemp.doc"))
        //            {
        //                DocumentsSelect ds = new DocumentsSelect();
        //                ds.ShowDialog();
        //            }
        //        }

        //        //object fileName1 = (object)"\\\\192.168.1.53\\" + path + "\\" + fileName;



        //        //if (DialogResult.Yes == Sundries.MessageBox("路径是否为    \\\\192.168.1.53\\" + path + "\\" + fileName, "路径", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk))
        //        //{
        //        //Microsoft.Office.Interop.Word.ApplicationClass oWordApp = new Microsoft.Office.Interop.Word.ApplicationClass();

        //        //object readOnly = true; 
        //        //object isVisible = true;
        //        //object missing = System.Reflection.Missing.Value;
        //        //oWordApp.Visible = true;
        //        //Microsoft.Office.Interop.Word.Document oWordDoc = oWordApp.Documents.Open(ref   fileName1, ref   missing, ref   readOnly,
        //        //ref   missing, ref   missing, ref   missing, ref   missing, ref   missing, ref   missing, ref   
        //        //missing, ref   missing, ref   isVisible, ref   missing, ref   missing, ref   missing, ref   missing);


        //        //}




        //    }
        //    catch (Exception ex)
        //    {
        //        Dialog.MessageBox(ex.Message,MessageBoxIcon.Information);
        //    }
        //}

        private void btnQuary_Click(object sender, EventArgs e)
        {
            //switch (DataOperator.HospitalID)
            //{
            //    case HospitalIDList.NANCHANG:
            //        Process.Start("IExplore.exe", @"http://192.168.11.248:9080/ZYEMR/QueryServlet?inpatientid=" + _patientID + "_" + _visitID.ToString() + "&&type=zyjl");
            //        break;
            //    case HospitalIDList.ANYANGZHONGLIU:
            //        //OracleConnection conn = new OracleConnection("Data Source=docare;Password=medicu;User ID=medicu");
            //        //OracleDataAdapter da = new OracleDataAdapter("select his_visit_id from med_vs_his_pat where med_PATIENT_id = '" + _patientID + "' and med_visit_id= '" + _visitID + "'", conn);
            //        ////OracleCommand ocom = new OracleCommand();
            //        //DataSet ds = new DataSet();
            //        //da.Fill(ds);
            //        CheckReport.MED_VS_HIS_PATDataTable ds = DataOperator.GetHisVisitId(_patientID, _visitID);

            //        string laPath = Directory.GetCurrentDirectory();
            //        string lsParm = laPath + @"\dzsq\request.exe";
            //        Process p = new Process();
            //        p.StartInfo.FileName = lsParm;
            //        p.StartInfo.Arguments = "2" + ds.Rows[0]["his_visit_id"].ToString();
            //        p.Start();
            //        break;
            //}
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                string fileName = "";
                string path = "";

                try
                {
                    mrFileIndexDT = SyncProxy.GetMrFileIndex(_patientID, (int)_visitID, Convert.ToInt32(gridView1.GetFocusedRowCellValue("FILE_NO")));
                    if (mrFileIndexDT.Rows.Count > 0)
                    {
                        fileName = mrFileIndexDT.Rows[0]["file_name"].ToString();
                        if (fileName == "")
                        {
                            return;
                        }
                    }
                    mrIndexDT = SyncProxy.GetMrIndex(_patientID, (int)_visitID);
                    if (mrIndexDT.Rows.Count > 0)
                    {
                        string strpatienturl = string.Empty;
                        string strlocaurl = string.Empty;
                        string strpath = string.Empty;
                        strpatienturl = _patientID;

                        strlocaurl = strpatienturl.Substring(strpatienturl.Length - 2);
                        strpath = strpatienturl.Substring(0, strpatienturl.Length - 2);
                        path = mrIndexDT.Rows[0]["access_path"].ToString();
                        if (path == "")
                        {
                            return;
                        }
                        //path = path.Replace(':', '$');
                        path += "\\" + strlocaurl + "\\" + strpath;

                        if (System.IO.File.Exists(@"c:\mrtemp.doc"))
                        {
                            System.IO.File.Delete(@"c:\mrtemp.doc");
                        }
                        int result = get_file("192.168.1.53", path + @"\" + fileName, @"c:\mrtemp.doc", 1);
                        if (result >= 0 && System.IO.File.Exists(@"c:\mrtemp.doc"))
                        {
                            DocumentsSelect ds = new DocumentsSelect();
                            ds.ShowDialog();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Dialog.MessageBox(ex.Message, MessageBoxIcon.Information);
                }
            }
        }

    }
}