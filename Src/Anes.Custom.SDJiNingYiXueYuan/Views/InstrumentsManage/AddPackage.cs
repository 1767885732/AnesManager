using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Views;
using Wis.Anes.DataAccess;
using Wis.Anes.Framework;
using Wis.Anes.Framework.Utilities;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors;

namespace Wis.Anes.Custom.CustomProject.Views
{
    public partial class AddPackage : BaseView
    {
        private CommonDA commDA = new CommonDA();
        private SyncDA syncDA = new SyncDA();
        string patientID = ExtendApplicationContext.Current.PatientInformation.PatientID;
        decimal visitID = ExtendApplicationContext.Current.PatientInformation.VisitID;
        decimal operID = ExtendApplicationContext.Current.PatientInformation.OperID;
        private DataTable packageMasterTable = null;
        private DataTable packageDetailTable = null;
        private DataTable patientInstrumentsTable = null;
        private DataTable patientInstrumentsAddTable = null;
        private PictureEdit pedDelete; //删除

        public AddPackage()
        {
            InitializeComponent();
        }

        private void GetPackageData(string barCode, int selectIdex)
        {
            DataRow[] rows = packageMasterTable.Select("BAR_CODE='" + barCode + "'");
            if (rows != null && rows.Length == 0)
            {
                using (BackgroundWorker worker = new BackgroundWorker())
                {
                    worker.DoWork += delegate(object sender, DoWorkEventArgs e)
                    {
                        //调用接口同步器械包主表与明细表
                        syncDA.SyncQiXieBao(barCode);
                    };
                    //worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
                    worker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
                    {
                        DataTable packageMasterTmp = commDA.GetDataWithPrimaryKey("MED_PACKAGE_MASTER", "where BAR_CODE=@barcode ", new object[] { barCode });
                        DataTable packageDetaiTmp = commDA.GetDataWithPrimaryKey("MED_PACKAGE_DETAIL", "where BAR_CODE=@barcode ", new object[] { barCode });
                        if (packageMasterTmp != null && packageMasterTable != null && packageMasterTmp.Rows.Count == 1)
                        {
                            packageMasterTable.ImportRow(packageMasterTmp.Rows[0]);
                            if (packageDetaiTmp != null)
                            {
                                foreach (DataRow row in packageDetaiTmp.Rows)
                                {
                                    packageDetailTable.ImportRow(row);

                                    DataRow newRow = patientInstrumentsTable.NewRow();
                                    newRow["PAT_ID"] = patientID;
                                    newRow["VISIT_ID"] = visitID;
                                    newRow["OPER_ID"] = operID;
                                    newRow["ITEM_NO"] = DataContext.GetCurrent().GetMaxNo("ITEM_NO", patientInstrumentsTable);
                                    newRow["ITEM_NAME"] = row["INSTRUMENT_NAME"].ToString();
                                    if (row["INSTRUMENT_CODE"] != DBNull.Value && !string.IsNullOrEmpty(row["INSTRUMENT_CODE"].ToString()))
                                    {
                                        newRow["ITEM_CODE"] = row["INSTRUMENT_CODE"].ToString();
                                    }
                                    newRow["BAR_CODE"] = row["BAR_CODE"].ToString();
                                    if (selectIdex == 1)
                                    {
                                        newRow["QUANTITY1"] = 0;
                                        newRow["QUANTITY2"] = 0;
                                        if (patientInstrumentsAddTable != null)
                                        {
                                            DataRow newRow2 = patientInstrumentsAddTable.NewRow();
                                            newRow2["PAT_ID"] = patientID;
                                            newRow2["VISIT_ID"] = visitID;
                                            newRow2["OPER_ID"] = operID;
                                            newRow2["ADD_NO"] = DataContext.GetCurrent().GetMaxNo("ADD_NO", patientInstrumentsAddTable.DefaultView.ToTable());
                                            newRow2["ITEM_NAME"] = row["INSTRUMENT_NAME"].ToString();
                                            newRow2["BAR_CODE"] = row["BAR_CODE"].ToString();
                                            newRow2["QUANTITY"] = decimal.Parse(row["QUANTITY"].ToString());
                                            patientInstrumentsAddTable.Rows.Add(newRow2);
                                        }
                                    }
                                    else
                                    {
                                        newRow["QUANTITY1"] = decimal.Parse(row["QUANTITY"].ToString());
                                        newRow["QUANTITY2"] = decimal.Parse(row["QUANTITY"].ToString());
                                    }
                                    patientInstrumentsTable.Rows.Add(newRow);
                                }
                                gridViewPackageMaster.ExpandMasterRow(packageDetailTable.Rows.Count - 1);
                                commDA.UpdateDataTable(patientInstrumentsTable);
                                commDA.UpdateDataTable(patientInstrumentsAddTable);
                                //回传器械包使用情况
                                //syncDA.SyncQiXieBao(barCode);
                            }
                        }
                    };
                    worker.RunWorkerAsync();
                }
            }
        }

        private bool CheckIsUsed(string barCode)
        {
            DataTable data = commDA.GetDataWithPrimaryKey("MED_OPERATING_INSTRUMENTS", " where bar_code='"+barCode+"' and bar_code not in (select bar_code from med_operating_instruments where PATIENT_ID=@pid and  VISIT_ID=@vid and OPER_ID=@oid)", new object[] { patientID, visitID, operID });
            if (data != null && data.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void AddPackage_Load(object sender, EventArgs e)
        {
            patientInstrumentsTable = commDA.GetDataWithPrimaryKey("MED_OPERATING_INSTRUMENTS", "where PATIENT_ID=@pid and  VISIT_ID=@vid and OPER_ID=@oid order by ITEM_NO", new object[] { patientID, visitID, operID });
            patientInstrumentsAddTable = commDA.GetDataWithPrimaryKey("MED_OPERATING_INSTRUMENTS_ADD", "where PATIENT_ID=@pid and  VISIT_ID=@vid and OPER_ID=@oid order by ITEM_NAME,ADD_NO", new object[] { patientID, visitID, operID });
            packageMasterTable = commDA.GetDataWithPrimaryKey("MED_PACKAGE_MASTER", " where bar_code in (select bar_code from med_operating_instruments where PATIENT_ID=@pid and  VISIT_ID=@vid and OPER_ID=@oid)", new object[] { patientID, visitID, operID });
            packageDetailTable = commDA.GetDataWithPrimaryKey("MED_PACKAGE_DETAIL", " where bar_code in (select bar_code from med_operating_instruments where PATIENT_ID=@pid and  VISIT_ID=@vid and OPER_ID=@oid)", new object[] { patientID, visitID, operID });
            DataSet ds = new DataSet();
            ds.Tables.Add(packageMasterTable);
            ds.Tables.Add(packageDetailTable);
            DataColumn keyColumn = ds.Tables["MED_PACKAGE_MASTER"].Columns["BAR_CODE"];         //主键
            DataColumn foreignColumn = ds.Tables["MED_PACKAGE_DETAIL"].Columns["BAR_CODE"];    //外键
            ds.Relations.Add("DetailView", keyColumn, foreignColumn);
            gridPackageMaster.DataSource = ds;
            gridPackageMaster.DataMember = "MED_PACKAGE_MASTER";
            if (gridViewPackageMaster.RowCount > 0)
            {
                gridViewPackageMaster.ExpandMasterRow(0);
            }
        }

        private void textEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(textEdit1.Text.Trim()))
                {
                    if (CheckIsUsed(textEdit1.Text))
                    {
                        GetPackageData(textEdit1.Text, radioGroupAddStage.SelectedIndex);
                        textEdit1.Text = string.Empty;
                    }
                    else
                    {
                        Dialog.MessageBox("该器械包条码已被使用！");
                    }
                }
            }
        }

        private void gridViewPackageMaster_MouseMove(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            GridHitInfo htInfo = view.CalcHitInfo(e.X, e.Y);
            if (!htInfo.InRowCell)
            {

                if (pedDelete != null)
                    pedDelete.Visible = false;
                return;
            }

            string name = htInfo.Column.FieldName; //取得鼠标所在的列名
            if ("BAR_CODE".Equals(name)) //判断是那一列中显示 删除图标
            {
                GridViewInfo vInfo = view.GetViewInfo() as GridViewInfo;
                GridCellInfo cInfo = vInfo.GetGridCellInfo(htInfo);
                if (pedDelete == null)
                {
                    pedDelete = new PictureEdit(); //实例删除图片按钮
                    pedDelete.Image = Properties.Resources.button_cancel;
                    pedDelete.Click += new EventHandler(ImgDel_Click); //注册删除事件   具体实践如下
                    gridPackageMaster.Controls.Add(pedDelete);
                }

                Rectangle r = new Rectangle(cInfo.Bounds.Right - 16, cInfo.Bounds.Bottom - 15, 15, 15); //调整显示图片位置
                pedDelete.Bounds = r; // 设定位置
                pedDelete.Tag = htInfo.RowHandle;
                r.X -= 16;
                pedDelete.Visible = true;
            }
            else
            {
                if (pedDelete != null)
                    pedDelete.Visible = false;
            }
        }

        /// <summary>
        /// 小图标删除点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        protected void ImgDel_Click(object sender, EventArgs e)
        {
            int rowhandle = (int)(sender as PictureEdit).Tag;
            if (Dialog.MessageBox("确定删除吗？", "信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                string barCode = packageMasterTable.Rows[rowhandle]["BAR_CODE"].ToString();
                DataRow[] rows1 = patientInstrumentsTable.Select("BAR_CODE='" + barCode + "'");
                if (rows1 != null && rows1.Length > 0)
                {
                    foreach (DataRow row in rows1)
                    {
                        row.Delete();
                    }
                }
                DataRow[] rows2 = patientInstrumentsAddTable.Select("BAR_CODE='" + barCode + "'");
                if (rows2 != null && rows2.Length > 0)
                {
                    foreach (DataRow row in rows2)
                    {
                        row.Delete();
                    }
                }
                commDA.UpdateDataTable(patientInstrumentsTable);
                commDA.UpdateDataTable(patientInstrumentsAddTable);
                DataRow[] rows3 = packageDetailTable.Select("BAR_CODE='" + barCode + "'");
                if (rows3 != null && rows3.Length > 0)
                {
                    foreach (DataRow row in rows3)
                    {
                        row.Delete();
                    }
                }
                packageMasterTable.Rows[rowhandle].Delete();
                packageMasterTable.AcceptChanges();
                packageDetailTable.AcceptChanges();
            }
        }

    }
}
