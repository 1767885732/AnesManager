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
using Wis.Anes.BusinessEntity;

namespace Wis.Anes.Custom.CustomProject.Views
{
    public partial class PreOperCheck : BaseView
    {
        private CommonDA commDA = new CommonDA();
        string patientID = ExtendApplicationContext.Current.PatientInformation.PatientID;
        decimal visitID = ExtendApplicationContext.Current.PatientInformation.VisitID;
        decimal operID = ExtendApplicationContext.Current.PatientInformation.OperID;
        private bool isAdd = false;
        private DataTable patientInstrumentsTable = null;

        public PreOperCheck()
        {
            InitializeComponent();
        }

        private bool CheckInstrumentName(string name)
        {
            foreach (DataRow row in patientInstrumentsTable.Rows)
            {
                if (row["ITEM_NAME"].ToString() == name)
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckInstrumentName(DataRow crow)
        {
            foreach (DataRow row in patientInstrumentsTable.Rows)
            {
                if (row["ITEM_NO"].ToString() != crow["ITEM_NO"].ToString() && row["ITEM_NAME"].ToString() == crow["ITEM_NAME"].ToString())
                {
                    return false;
                }
            }
            return true;
        }

        private void RefreshPatientInstrumentsTable()
        {
            patientInstrumentsTable = commDA.GetDataWithPrimaryKey("MED_OPERATING_INSTRUMENTS", "where PATIENT_ID=@pid and  VISIT_ID=@vid and OPER_ID=@oid order by ITEM_NO", new object[] { patientID, visitID, operID });
            gridControl1.DataSource = patientInstrumentsTable;
            gridView1.ExpandAllGroups();
            btnAdd.Enabled = true;
            btnDel.Enabled = gridView1.FocusedRowHandle >= 0 && gridView1.GetFocusedDataRow() != null && gridView1.GetFocusedDataRow()["BAR_CODE"].ToString() == "手术室器械添加项";
            btnSave.Enabled = false;
            btnApplyTemplet.Enabled = true;
        }

        private void PreOperCheck_Load(object sender, EventArgs e)
        {
            RefreshPatientInstrumentsTable();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            btnSave.Enabled = true;
            btnApplyTemplet.Enabled = false;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            isAdd = false;
            txtBarCode.Text = "";
            DataRow row = gridView1.GetFocusedDataRow();
            if (row != null)
            {
                txtInstrumentName.Text = row["ITEM_NAME"].ToString();
                txtCheckNum.Text = row["QUANTITY2"].ToString();
                txtBarCode.Text = row["BAR_CODE"].ToString();
            }

            txtInstrumentName.Enabled = txtBarCode.Text == "手术室器械添加项"; ;
            btnAdd.Enabled = true;
            btnSave.Enabled = false;
            btnDel.Enabled = txtBarCode.Text == "手术室器械添加项";
            btnApplyTemplet.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtBarCode.Text = "手术室器械添加项";
            txtCheckNum.EditValue = 0;
            txtInstrumentName.Text = "";

            isAdd = true;
            btnAdd.Enabled = false;
            btnSave.Enabled = false;
            btnDel.Enabled = false;
            txtInstrumentName.Enabled = true;
            btnApplyTemplet.Enabled = false;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DataRow row = gridView1.GetFocusedDataRow();
            if (row != null)
            {
                if (XtraMessageBox.Show(this, "确定删除该器械项吗？", "信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    row.Delete();
                    commDA.UpdateDataTable(patientInstrumentsTable);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInstrumentName.Text.Trim()))
            {
                XtraMessageBox.Show("器械名不可为空");
                return;
            }
            DataRow row;
            if (isAdd)
            {
                if (!CheckInstrumentName(txtInstrumentName.Text.Trim()))
                {
                    XtraMessageBox.Show("器械名已存在");
                    return;
                }
                row = patientInstrumentsTable.NewRow();
                row["PAT_ID"] = patientID;
                row["VISIT_ID"] = visitID;
                row["OPER_ID"] = operID;
                row["BAR_CODE"] = txtBarCode.Text;
                row["ITEM_NO"] = DataContext.GetCurrent().GetMaxNo("ITEM_NO", patientInstrumentsTable);
                row["ITEM_NAME"] = txtInstrumentName.Text.Trim();
                row["QUANTITY1"] = 0;
                patientInstrumentsTable.Rows.Add(row);
                gridView1.FocusedRowHandle = patientInstrumentsTable.Rows.Count - 1;
            }
            else
            {
                row = gridView1.GetFocusedDataRow();
                if (txtBarCode.Text == "手术室器械添加项" && !CheckInstrumentName(row))
                {
                    XtraMessageBox.Show("器械名已存在");
                    return;
                }

                if (commDA.ExecuteNonQuery("update MED_OPERATING_INSTRUMENTS_ADD set ITEM_NAME='" + txtInstrumentName.Text.Trim() + "' where PATIENT_ID='" + patientID + "' and  VISIT_ID=" + visitID.ToString() + " and OPER_ID=" + operID.ToString() + " and ITEM_NAME='" + row["ITEM_NAME"].ToString() + "'") > 0)
                {
                    row["ITEM_NAME"] = txtInstrumentName.Text.Trim();
                }
            }

            decimal d = 0;
            string str = txtCheckNum.Text;
            if (txtCheckNum.OldEditValue != null && txtCheckNum.Text == "")
            {
                str = txtCheckNum.OldEditValue.ToString();
            }
            if (decimal.TryParse(str, out d)) { }
            row["QUANTITY2"] = d;
            commDA.UpdateDataTable(patientInstrumentsTable);
            isAdd = false;
            btnAdd.Enabled = true;
            btnSave.Enabled = false;
            btnApplyTemplet.Enabled = true;
        }

        private void txtInstrumentName_EditValueChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnApplyTemplet.Enabled = false;
        }

        private void txtCheckNum_EditValueChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnApplyTemplet.Enabled = false;
        }

        private void btnApplyTemplet_Click(object sender, EventArgs e)
        {
            QiXieQingDianTemplet qiXieQingDianTemplet = new QiXieQingDianTemplet();
            qiXieQingDianTemplet.IsApply = true;
            XtraForm xtraForm = GetDialogForm("套用模板", qiXieQingDianTemplet);
            if (xtraForm.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(qiXieQingDianTemplet.DialogResultData))
            {
                if (string.IsNullOrEmpty(qiXieQingDianTemplet.DialogResultData)) return;
                CareDocs.WIS_INSTRUMENT_TEMPLET_DETAILDataTable qiXieTempletDetail = (new CareDocsDA()).GetQiXieTempletDetailByGuid(qiXieQingDianTemplet.DialogResultData);
                if (qiXieTempletDetail != null && qiXieTempletDetail.Count > 0)
                {
                    foreach (CareDocs.WIS_INSTRUMENT_TEMPLET_DETAILRow prow in qiXieTempletDetail.Rows)
                    {
                        if (CheckInstrumentName(prow.ITEM_NAME))
                        {
                            DataRow row = patientInstrumentsTable.NewRow();
                            row["PAT_ID"] = patientID;
                            row["VISIT_ID"] = visitID;
                            row["OPER_ID"] = operID;
                            row["BAR_CODE"] = "手术室器械添加项";
                            row["ITEM_NO"] = DataContext.GetCurrent().GetMaxNo("ITEM_NO", patientInstrumentsTable);
                            row["ITEM_NAME"] = prow.ITEM_NAME;
                            row["QUANTITY1"] = 0;
                            row["QUANTITY2"] = 0;
                            patientInstrumentsTable.Rows.Add(row);
                        }
                    }
                    commDA.UpdateDataTable(patientInstrumentsTable);
                    RefreshPatientInstrumentsTable();
                }
            }
        }

        private XtraForm GetDialogForm(string text, UserControl view)
        {
            XtraForm xtraForm = new XtraForm();
            xtraForm.Text = text;
            xtraForm.Controls.Add(view);
            view.Dock = DockStyle.Fill;
            xtraForm.Size = new Size(800, 600);
            xtraForm.StartPosition = FormStartPosition.CenterScreen;
            xtraForm.MaximizeBox = false;
            return xtraForm;
        }
    }
}
