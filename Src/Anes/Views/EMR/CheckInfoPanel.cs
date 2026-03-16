/*----------------------------------------------------------------
      // Copyright (C) 2005 北京拓扑工厂科技发展有限公司
      // 文件名：CheckInfoPanel.cs
      // 文件功能描述：检查信息类
      //
      // 
      // 创建标识：XXX-2007-12-27
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using Wis.Anes.BusinessEntity;
using Wis.Anes.ServiceProxies;
using Wis.Anes.Framework;
using Wis.Anes.Framework.Views;
using Wis.Anes.Constants;

namespace Wis.Anes.Views
{
    /// <summary>
    /// 检查信息类
    /// </summary>
    public partial class CheckInfoPanel : BaseView
    {
        private string Keys = string.Empty;
        string _patientID = null;
        decimal _visitID = 0;

        # region 构造方法

        public CheckInfoPanel() : this(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID) { }

        public CheckInfoPanel(string patientID, decimal visitID, decimal operID) : this(patientID, visitID, operID, "检查") { }
        public CheckInfoPanel(string patientID, decimal visitID, decimal operID, string title)
        //: base(patientID, visitID, operID, title)
        {
            ClassInit();
        }

        public CheckInfoPanel(string patientID, decimal visitID, decimal operID, string title, string keys)
        //: base(patientID,visitID,operID, title)
        {
            Keys = keys;
            ClassInit();
        }

        private void ClassInit() {
            Caption = ViewNames.HisCheckInfo;
            InitializeComponent();
            //medDataGridView1.AutoGenerateColumns = false;
            //medDataGridView1.Columns.Add(GenerateColumn("检查名称", "exam_sub_class", 186));
            //medDataGridView1.Columns.Add(GenerateColumn("检查日期", "exam_date_time", 120));
            //medDataGridView1.Columns.Add(GenerateColumn("报告日期", "report_date_time", 120));
            if (!string.IsNullOrEmpty(Keys)) {
                string[] dates = Keys.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                DateTime dt;
                if (dates != null && dates.Length > 1 && DateTime.TryParse(dates[1], out dt)) {
                    //dateTimePicker1.Value = dt;
                    dateEdit1.DateTime = dt;
                }
                else {
                    //dateTimePicker1.Value = DateTime.Now;
                    dateEdit1.DateTime = DateTime.Now;
                }
            }
            else {
                //dateTimePicker1.Value = DateTime.Now;
                dateEdit1.DateTime = DateTime.Now;
            }
            //dateTimePicker2.Value = DateTime.Now.AddDays(1);
            dateEdit2.DateTime = DateTime.Now.AddDays(1);
            RefreshDataa();
        }
        #endregion 构造方法

        #region 变量

        /// <summary>
        /// 检查信息表
        /// </summary>
        Sync.CheckReportDataTable checkReportDataTable;

        #endregion 变量

        #region 方法

        /// <summary>
        /// 刷新数据
        /// </summary>
        private void RefreshDataa() {
            //if (this.medDataGridView1 == null) return;
            if (this.gridView1.RowCount == 0) return;
            ///没有病人信息则不处理
            if (string.IsNullOrEmpty(_patientID)) return;

            checkReportDataTable = SyncProxy.GetCheckReport(_patientID, _visitID);
            //checkReportDataTable = ClientLibrary.ClientDataModule.CheckReport.GetCheckReportByDate(_patientID, _visitID, dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
            //checkReportDataTable.ColumnChanged += new DataColumnChangeEventHandler(
            //    delegate(object sender, DataColumnChangeEventArgs e) { checkReportDataTable.RejectChanges(); });
            this.gridControl1.DataSource = checkReportDataTable;
            //this.medDataGridView1.DataSource = checkReportDataTable;         
            //AddEmptyRowToTable(checkReportDataTable, 26, "");
            this.medTextBox1.DataBindings.Clear();
            this.medTextBox1.DataBindings.Add(new Binding("Text", checkReportDataTable, "EXAM_PARA"));
            this.medTextBox2.DataBindings.Clear();
            this.medTextBox2.DataBindings.Add(new Binding("Text", checkReportDataTable, "DESCRIPTION"));
            this.medTextBox3.DataBindings.Clear();
            this.medTextBox3.DataBindings.Add(new Binding("Text", checkReportDataTable, "IMPRESSION"));
            this.medTextBox4.DataBindings.Clear();
            this.medTextBox4.DataBindings.Add(new Binding("Text", checkReportDataTable, "RECOMMENDATION"));
        }

        //protected override void OnPatientChange(Com.Wis.Icu.Patient.PatientRow patientRow)
        //{
        //    RefreshData();
        //}

        #endregion 方法

        private void CheckInfoPanel_Enter(object sender, EventArgs e) {
            if (checkReportDataTable != null && checkReportDataTable.Count > 0 && Keys != null && Keys.Length > 0) {
                int Index = 0;

                foreach (Sync.CheckReportRow CheckRow in checkReportDataTable) {
                    string RowKeys = CheckRow.EXAM_SUB_CLASS + "," + CheckRow.EXAM_DATE_TIME.ToString() + "," + (CheckRow.IsREPORT_DATE_TIMENull() ? "" : CheckRow.REPORT_DATE_TIME.ToString());
                    if (RowKeys == Keys) {
                        //medDataGridView1.ClearSelection();
                        //medDataGridView1.Rows[Index].Selected = true;
                        gridView1.ClearSelection();
                        gridView1.SelectRow(Index);
                        break;
                    }
                    else {
                        Index++;
                    }
                }
            }
        }

        private void btnQuary_Click(object sender, EventArgs e) {
            RefreshDataa();
        }
        /// <summary>
        /// 同步检查信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void medButton1_Click(object sender, EventArgs e) {
            try {
                //if (DataOperator.HospitalID == HospitalIDList.YANTAI)
                //{
                //    string laPath = Directory.GetCurrentDirectory();
                //    string lsParm = laPath + @"\MdcHisView\MdcHisView.exe";
                //    Process p = new Process();
                //    p.StartInfo.FileName = lsParm;
                //    p.StartInfo.Arguments = _patientID;
                //    p.Start();
                //}
                //else if (DataOperator.HospitalID == HospitalIDList.ANYANGZHONGLIU)
                //{
                //    string laPath = Directory.GetCurrentDirectory();
                //    string lsParm = laPath + @"\ReportViewer\ReportViewer.exe";
                //    Process p = new Process();
                //    p.StartInfo.FileName = lsParm;
                //    p.StartInfo.Arguments = _patientID;
                //    p.Start();
                //}
                //else
                {
                    SyncProxy.GetCheckReport(_patientID, (int)_visitID);
                    RefreshData();
                    //Sundries.MessageBox("提取检查信息完成！");
                }
            }
            catch {

                // Sundries.MessageBox(ee.Message);
            }
        }

        private void dateEdit2_Validating(object sender, CancelEventArgs e) {
            if (dateEdit2.DateTime < dateEdit1.DateTime) {
                (sender as DevExpress.XtraEditors.DateEdit).ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                (sender as DevExpress.XtraEditors.DateEdit).ErrorText = label1.Text + "不能大于" + label2.Text;
                e.Cancel = true;
                return;
            }
        }
    }
}
