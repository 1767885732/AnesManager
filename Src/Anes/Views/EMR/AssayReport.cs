using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Views;
using Wis.Anes.ServiceProxies;
using Wis.Anes.Framework;
using Wis.Anes.Constants;
using Wis.Anes.Layouts;
using DevExpress.XtraGrid.Views.Grid;

namespace Wis.Anes.Views
{
    public partial class AssayReport : BaseView
    {
        private bool _querySign = false;
        string _patientID = null;
        decimal _visitID = 0;

        public AssayReport() : this(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID) { }

        public AssayReport(string patientID, decimal visitID, decimal operID) : this(patientID, visitID, operID, "检验") { }
        public AssayReport(string patientID, decimal visitID, decimal operID, string title)
        //: base(patientID, visitID, operID, title)
        {
            _patientID = patientID;
            _visitID = visitID;
            InitializeComponent();
            //dgvAssayMaster.AutoGenerateColumns = false;
            //dgvAssayResult.AutoGenerateColumns = false;
            SetPatientInformation();
        }

        public void SetPatientInformation()
        {
            Caption = ViewNames.HisAssay;
            gridControl1.DataSource = null;
            gridControl2.DataSource = null;
            //dgvAssayMaster.DataSource = null;
            //dgvAssayResult.DataSource = null;
            RefreshDataa();
        }

        private void RefreshDataa()
        {
            Query();
        }

        private void Query()
        {
            if (_querySign)
            {
                return;
            }
            _querySign = true;
            label1.Visible = true;
            //Com.Wis.Anes.DataModelProxy.ISync syncInterface = BussinessClassFactory.SyncInterface;

            //Com.Wis.Common.Utilities.Dialog.MessageBox("准备同步");
            string ret = SyncProxy.SyncLis(_patientID, _visitID, DocareSysInterfaceCompleted);
            Logger.Write($"SyncLis:{ret}");
            //Com.Wis.Common.Utilities.Dialog.MessageBox("同步完成,返回值是" + ret);
            QueryMasetr();
            _querySign = false;
            label1.Visible = false;


        }

        private void DocareSysInterfaceCompleted(object sender, EventArgs e)
        {
            QueryMasetr();
            _querySign = false;
            label1.Visible = false;
        }

        private void QueryMasetr()
        {
            gridControl1.DataSource = SyncProxy.GetLabTestMaster(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID);
            //dgvAssayMaster.DataSource = DataHelper.GetLabTestMaster(ActionFactory.PatientInformation.PatientID, ActionFactory.PatientInformation.VisitID);
        }

        //private void dgvAssayMaster_RowEnter(object sender, DataGridViewCellEventArgs e)
        //{
        //    QueryResult(e.RowIndex);
        //}

        private void QueryResult(int rowIndex)
        {
            if (rowIndex >= 0)
            {
                string TestNo = gridView1.GetDataRow(rowIndex)[0].ToString();
                gridControl2.DataSource = SyncProxy.GetLabResult(TestNo);
                //string TestNo = dgvAssayMaster[0, rowIndex].Value.ToString();
                //dgvAssayResult.DataSource = DataHelper.GetLabResult(TestNo);
            }
        }

        private void medButton1_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString("检验信息", new Font("宋体", 12), Brushes.Black, 0, 2);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            QueryResult(e.FocusedRowHandle);
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = gridControl2.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (view == null)
                return;
            DataRow row = view.GetDataRow(view.FocusedRowHandle);
            if (row != null && !row.IsNull("REPORT_ITEM_NAME"))
            {
                LabValueTrendChart labValueTrendChart = new LabValueTrendChart(row["REPORT_ITEM_NAME"].ToString());
                DialogHostForm dialogHostForm = new DialogHostForm(row["REPORT_ITEM_NAME"].ToString(), 600, 500);
                dialogHostForm.Child = labValueTrendChart;
                dialogHostForm.ShowDialog();
            }
        }

        // add by shiyu.duan for 主板本升级 anes-00012 异常值特殊颜色标注提示
        private void gridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            GridView view = gridControl2.MainView as GridView;
            if (view == null)
            {
                return;
            }
            string referenceResult = string.Empty;
            Decimal upperBound, lowerBound, cellValue = 0;
            if (e.Column.FieldName == "RESULT")
            {
                DataRow curRow = view.GetDataRow(e.RowHandle);
                // 获取参考值
                referenceResult = curRow["REFERENCE_RESULT"].ToString();
                if (referenceResult.Contains("-"))
                {
                    int indexOfMinus = -1;

                    //add by dhc 20200514
                    if (referenceResult.IndexOf('-') != referenceResult.LastIndexOf('-'))//处理带复数范围
                    {
                        indexOfMinus = referenceResult.IndexOf('-', referenceResult.IndexOf('-') + 1);//取第二个'-'作为范围分隔符
                    }
                    else
                    {
                        indexOfMinus = referenceResult.IndexOf('-');
                    }

                    if (Decimal.TryParse(referenceResult.Substring(0, indexOfMinus), out lowerBound) &&
                        Decimal.TryParse(referenceResult.Substring(indexOfMinus + 1), out upperBound))
                    {
                        if (Decimal.TryParse(e.CellValue.ToString(), out cellValue))
                        {
                            // 高于参考值
                            if (cellValue > upperBound)
                            {
                                e.Appearance.ForeColor = Color.Red;
                                if (!e.DisplayText.Contains("↑"))
                                    e.DisplayText += "↑";
                            }
                            // 低于参考值
                            else if (cellValue < lowerBound)
                            {
                                e.Appearance.ForeColor = Color.Blue;
                                if (!e.DisplayText.Contains("↓"))
                                    e.DisplayText += "↓";
                            }
                        }
                    }
                }
                else if (referenceResult.Contains("<"))//处理'<'、'>'、'≥'、'≤'
                {
                    if (Decimal.TryParse(referenceResult.Substring(referenceResult.IndexOf('<') + 1), out upperBound))
                    {
                        if (Decimal.TryParse(e.CellValue.ToString(), out cellValue))
                        {
                            // 高于参考值
                            if (cellValue >= upperBound)
                            {
                                e.Appearance.ForeColor = Color.Red;
                                if (!e.DisplayText.Contains("↑"))
                                    e.DisplayText += "↑";
                            }
                        }
                    }
                }
                else if (referenceResult.Contains("≤"))//处理'<'、'>'、'≥'、'≤'
                {
                    if (Decimal.TryParse(referenceResult.Substring(referenceResult.IndexOf('≤') + 1), out upperBound))
                    {
                        if (Decimal.TryParse(e.CellValue.ToString(), out cellValue))
                        {
                            // 高于参考值
                            if (cellValue > upperBound)
                            {
                                e.Appearance.ForeColor = Color.Red;
                                if (!e.DisplayText.Contains("↑"))
                                    e.DisplayText += "↑";
                            }
                        }
                    }
                }
                else if (referenceResult.Contains(">"))//处理'<'、'>'、'≥'、'≤'
                {
                    if (Decimal.TryParse(referenceResult.Substring(referenceResult.IndexOf('>') + 1), out lowerBound))
                    {
                        if (Decimal.TryParse(e.CellValue.ToString(), out cellValue))
                        {
                            // 低于参考值
                            if (cellValue <= lowerBound)
                            {
                                e.Appearance.ForeColor = Color.Blue;
                                if (!e.DisplayText.Contains("↓"))
                                    e.DisplayText += "↓";
                            }
                        }
                    }
                }
                else if (referenceResult.Contains("≥"))//处理'<'、'>'、'≥'、'≤'
                {
                    if (Decimal.TryParse(referenceResult.Substring(referenceResult.IndexOf('≥') + 1), out lowerBound))
                    {
                        if (Decimal.TryParse(e.CellValue.ToString(), out cellValue))
                        {
                            // 低于参考值
                            if (cellValue < lowerBound)
                            {
                                e.Appearance.ForeColor = Color.Blue;
                                if (!e.DisplayText.Contains("↓"))
                                    e.DisplayText += "↓";
                            }
                        }
                    }
                }
            }
        }
    }
}

