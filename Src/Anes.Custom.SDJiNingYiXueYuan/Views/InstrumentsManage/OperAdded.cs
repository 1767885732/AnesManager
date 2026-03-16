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
using DevExpress.XtraEditors;

namespace Wis.Anes.Custom.CustomProject.Views
{
    public partial class OperAdded : BaseView
    {
        private CommonDA commDA = new CommonDA();
        private DataTable patientInstrumentsTable = null;
        private DataTable patientInstrumentsDistinctTable = null;
        private DataTable patientInstrumentsAddTable = null;
        string patientID = ExtendApplicationContext.Current.PatientInformation.PatientID;
        decimal visitID = ExtendApplicationContext.Current.PatientInformation.VisitID;
        decimal operID = ExtendApplicationContext.Current.PatientInformation.OperID;

        public OperAdded()
        {
            InitializeComponent();
        }

        private void RefreshPatientInstrumentsDistinctTable()
        {
            patientInstrumentsAddTable = commDA.GetDataWithPrimaryKey("MED_OPERATING_INSTRUMENTS_ADD", "where PATIENT_ID=@pid and  VISIT_ID=@vid and OPER_ID=@oid order by ITEM_NAME,ADD_NO", new object[] { patientID, visitID, operID });
            gridControl3.DataSource = patientInstrumentsAddTable;

            patientInstrumentsTable = commDA.GetDataWithPrimaryKey("MED_OPERATING_INSTRUMENTS", "where PATIENT_ID=@pid and  VISIT_ID=@vid and OPER_ID=@oid order by ITEM_NO", new object[] { patientID, visitID, operID });
            List<string> namelist = new List<string>();
            foreach (DataRow row in patientInstrumentsTable.Rows)
            {
                if (!namelist.Contains(row["ITEM_NAME"].ToString()))
                {
                    namelist.Add(row["ITEM_NAME"].ToString());
                    if (row["QUANTITY3"] == null || row["QUANTITY3"] == DBNull.Value)
                    {
                        DataRow[] rows = patientInstrumentsAddTable.Select("ITEM_NAME='" + row["ITEM_NAME"].ToString() + "'");
                        if (rows != null && rows.Length > 0)
                        {
                            string q = "";
                            foreach (DataRow prow in rows)
                            {
                                q += "+" + prow["QUANTITY"].ToString();
                            }
                            row["QUANTITY3"] = q;
                        }
                    }
                }
            }
            commDA.UpdateDataTable(patientInstrumentsTable);
            patientInstrumentsDistinctTable = commDA.GetDataWithPrimaryKey("MED_OPERATING_INSTRUMENTS", "where (ITEM_NO IN (SELECT min(ITEM_NO) FROM med_operating_instruments where  PATIENT_ID=@pid and  VISIT_ID=@vid and OPER_ID=@oid  GROUP BY item_name )) order by ITEM_NO", new object[] { patientID, visitID, operID });           
            namelist.Clear();
            foreach (DataRow row in patientInstrumentsTable.Rows)
            {
                if (!namelist.Contains(row["ITEM_NAME"].ToString()))
                {
                    namelist.Add(row["ITEM_NAME"].ToString());
                }
                else
                {
                    DataRow[] findrows = patientInstrumentsDistinctTable.Select("ITEM_NAME='" + row["ITEM_NAME"].ToString() + "'");
                    if (findrows != null && findrows.Length > 0)
                    {
                        findrows[0]["QUANTITY1"] = decimal.Parse(findrows[0]["QUANTITY1"].ToString()) + decimal.Parse(row["QUANTITY1"].ToString());
                        findrows[0]["QUANTITY2"] = decimal.Parse(findrows[0]["QUANTITY2"].ToString()) + decimal.Parse(row["QUANTITY2"].ToString());
                        row["QUANTITY4"] = 0;
                        row["QUANTITY5"] = 0;
                        //row["MEMO"] = "重复器械术中术后合并到最前";
                    }
                }
            }

            gridControl2.DataSource = patientInstrumentsDistinctTable;
            commDA.UpdateDataTable(patientInstrumentsTable);

            DataRow roww = gridView2.GetFocusedDataRow();
            if (roww != null && patientInstrumentsAddTable != null)
            {
                patientInstrumentsAddTable.DefaultView.RowFilter = "ITEM_NAME='" + roww["ITEM_NAME"].ToString() + "'";
            }

            btnAdd2.Enabled = gridView2.FocusedRowHandle >= 0;
            btnDel2.Enabled = gridView3.FocusedRowHandle >= 0;
            btnSave2.Enabled = false;
        }

        private void SavePatientInstrumentAddTable()
        {
            commDA.UpdateDataTable(patientInstrumentsAddTable);
            List<string> namelist = new List<string>();
            foreach (DataRow row in patientInstrumentsTable.Rows)
            {
                if (!namelist.Contains(row["ITEM_NAME"].ToString()))
                {
                    namelist.Add(row["ITEM_NAME"].ToString());
                    DataRow[] rows = patientInstrumentsAddTable.Select("ITEM_NAME='" + row["ITEM_NAME"].ToString() + "'");
                    if (rows != null && rows.Length > 0)
                    {
                        string q = "";
                        foreach (DataRow prow in rows)
                        {
                            q += "+" + prow["QUANTITY"].ToString();
                        }
                        row["QUANTITY3"] = q;
                    }
                    else
                    {
                        row["QUANTITY3"] = DBNull.Value;
                    }
                }
            }
            commDA.UpdateDataTable(patientInstrumentsTable);
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow row = gridView2.GetFocusedDataRow();
            if (row != null && patientInstrumentsAddTable != null)
            {
                patientInstrumentsAddTable.DefaultView.RowFilter = "ITEM_NAME='" + row["ITEM_NAME"].ToString() + "'";
            }
            btnAdd2.Enabled = gridView2.FocusedRowHandle >= 0;
            btnDel2.Enabled = gridView3.FocusedRowHandle >= 0;
            btnSave2.Enabled = false;
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            DataRow row1 = gridView2.GetFocusedDataRow();
            if (row1 != null)
            {
                DataRow row2 = patientInstrumentsAddTable.NewRow();
                row2["PAT_ID"] = patientID;
                row2["VISIT_ID"] = visitID;
                row2["OPER_ID"] = operID;
                row2["ADD_NO"] = DataContext.GetCurrent().GetMaxNo("ADD_NO", patientInstrumentsAddTable.DefaultView.ToTable());
                row2["ITEM_NAME"] = row1["ITEM_NAME"].ToString();
                row2["QUANTITY"] = 0;
                patientInstrumentsAddTable.Rows.Add(row2);
            }
            btnAdd2.Enabled = false;
            btnSave2.Enabled = true;
        }

        private void btnDel2_Click(object sender, EventArgs e)
        {
            DataRow row = gridView3.GetFocusedDataRow();
            if (row != null)
            {
                if (row["BAR_CODE"] != null && row["BAR_CODE"] != DBNull.Value && row["BAR_CODE"].ToString().Length > 0)
                {
                    XtraMessageBox.Show(this, "该项属于术中添加的器械包[" + row["BAR_CODE"].ToString() + "]，不能删除，只能改变数量！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (XtraMessageBox.Show(this, "确定删除该器械添加项吗？", "信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    row.Delete();
                    SavePatientInstrumentAddTable();
                    RefreshPatientInstrumentsDistinctTable();
                }
            }
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            SavePatientInstrumentAddTable();
            RefreshPatientInstrumentsDistinctTable();
        }

        private void gridView3_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            btnSave2.Enabled = true;
        }

        private void OperAdded_Load(object sender, EventArgs e)
        {
            RefreshPatientInstrumentsDistinctTable();
        }
    }
}
