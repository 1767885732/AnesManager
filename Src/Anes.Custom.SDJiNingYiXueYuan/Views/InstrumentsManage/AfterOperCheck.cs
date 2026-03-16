using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.DataAccess;
using Wis.Anes.Framework;

namespace Wis.Anes.Custom.CustomProject.Views
{
    public partial class AfterOperCheck : UserControl
    {
        private CommonDA commDA = new CommonDA();
        private DataTable patientInstrumentsTable = null;
        private DataTable patientInstrumentsDistinctTable = null;
        private DataTable patientInstrumentsAddTable = null;
        string patientID = ExtendApplicationContext.Current.PatientInformation.PatientID;
        decimal visitID = ExtendApplicationContext.Current.PatientInformation.VisitID;
        decimal operID = ExtendApplicationContext.Current.PatientInformation.OperID;

        public AfterOperCheck()
        {
            InitializeComponent();
        }

        private void RefreshPatientInstrumentsDistinctTable()
        {
            patientInstrumentsAddTable = commDA.GetDataWithPrimaryKey("MED_OPERATING_INSTRUMENTS_ADD", "where PATIENT_ID=@pid and  VISIT_ID=@vid and OPER_ID=@oid order by ITEM_NAME,ADD_NO", new object[] { patientID, visitID, operID });
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
            btnSave.Enabled = false;
        }

        private void SavePatientInstrumentsTable()
        {
            List<string> namelist = new List<string>();
            foreach (DataRow row in patientInstrumentsDistinctTable.Rows)
            {
                DataRow[] findrows = patientInstrumentsTable.Select("ITEM_NAME='" + row["ITEM_NAME"].ToString() + "'");
                if (findrows != null && findrows.Length > 0)
                {
                    if (row["QUANTITY4"] != null && row["QUANTITY4"] != DBNull.Value)
                    {
                        findrows[0]["QUANTITY4"] = decimal.Parse(row["QUANTITY4"].ToString());
                    }
                    else
                    {
                        findrows[0]["QUANTITY4"] = DBNull.Value;
                    }
                    if (row["QUANTITY5"] != null && row["QUANTITY5"] != DBNull.Value)
                    {
                        findrows[0]["QUANTITY5"] = decimal.Parse(row["QUANTITY5"].ToString());
                    }
                    else
                    {
                        findrows[0]["QUANTITY5"] = DBNull.Value;
                    }
                    if (row["MEMO"] != null && row["MEMO"] != DBNull.Value)
                    {
                        findrows[0]["MEMO"] = row["MEMO"];
                    }
                    else
                    {
                        findrows[0]["MEMO"] = DBNull.Value;
                    }
                }
            }
            commDA.UpdateDataTable(patientInstrumentsTable);
        }

        private void AfterOperCheck_Load(object sender, EventArgs e)
        {
            RefreshPatientInstrumentsDistinctTable();
        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshPatientInstrumentsDistinctTable();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SavePatientInstrumentsTable();
            btnSave.Enabled = false;
        }

        private void gridView2_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            DataRow row = gridView2.GetFocusedDataRow();
            if (gridView2.FocusedColumn.FieldName == "QUANTITY4")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.Value = null;
                    row["QUANTITY4"] = DBNull.Value;
                }
                else
                {
                    if (e.Value != null && e.Value.ToString().Length > 2)
                    {
                        e.Valid = false;
                        e.ErrorText = "输入数字位数过大";
                    }
                }
            }
            else if (gridView2.FocusedColumn.FieldName == "QUANTITY5")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.Value = null;
                    row["QUANTITY5"] = DBNull.Value;
                }
                else
                {
                    if (e.Value != null && e.Value.ToString().Length > 2)
                    {
                        e.Valid = false;
                        e.ErrorText = "输入数字位数过大";
                    }
                }
            }
            else if (gridView2.FocusedColumn.FieldName == "MEMO")
            {
                if (e.Value != null && e.Value.ToString().Length > 50)
                {
                    e.Valid = false;
                    e.ErrorText = "输入备注内容长度不可大于50";
                }
            }
        }
    }
}
