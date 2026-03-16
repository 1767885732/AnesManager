using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Controls.Base;
using Wis.Anes.BusinessEntity;
using Wis.Anes.DataAccess;
using DevExpress.XtraEditors;
using Wis.Anes.Framework.Utilities;
using Wis.Anes.Framework.Configurations;

namespace Wis.Anes.Framework
{
    [ToolboxItem(false)]
    public partial class TimePointBloodGasEditor : UserControl
    {
        private string _patientID;
        private decimal _visitID;
        private decimal _operID;
        private string _detailID;
        private CareDocsDA _careDocsDA;

        public DateTime TimePoint
        {
            get { return dateEdit1.DateTime; }
            set { dateEdit1.DateTime = value; }
        }

        public TimePointBloodGasEditor()
        {
            InitializeComponent();
        }

        public TimePointBloodGasEditor(string patientID, decimal visitID, decimal operID, string detailID)
            : this()
        {
            dateEdit1.Properties.ReadOnly = true;
            _patientID = patientID;
            _visitID = visitID;
            _operID = operID;
            _detailID = detailID;
            if (!string.IsNullOrEmpty(ApplicationConfiguration.BloodGasTempletNames))
            {
                string[] names = ApplicationConfiguration.BloodGasTempletNames.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                if (names.Length > 0)
                {
                    foreach (string name in names)
                    {
                        comboBoxEditSample.Properties.Items.Add(name);
                    }
                }
            }
        }

        private void LoadGridList()
        {
            dataGridView1.Rows.Clear();
            string[] list = ExtendApplicationContext.Current.DefaultBloodGasItem.ToArray();
            if (!string.IsNullOrEmpty(comboBoxEditSample.Text.Trim()))
            {
                string itemsString = ApplicationConfiguration.GetFromConfigTable("BloodGasItems@" + comboBoxEditSample.Text.Trim());
                if (!string.IsNullOrEmpty(itemsString))
                {
                    string[] items = itemsString.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    if (items.Length > 0)
                    {
                        list = items;
                    }
                }
            }
            if (list != null && list.Length > 0)
            {
                foreach (string text in list)
                {
                    string name = text;
                    if (ExtendApplicationContext.Current.BloodGasItemDict.ContainsKey(text))
                    {
                        name = ExtendApplicationContext.Current.BloodGasItemDict[text];
                    }
                    dataGridView1.Rows.Add(new object[] { text, name, null });
                }
            }
        }

        private void LoadBloodGasList(string detailID)
        {
            LoadGridList();
            if (!string.IsNullOrEmpty(detailID))
            {
                CareDocs.BloodGasMasterDataTable bloodGasMasterDataTable = _careDocsDA.GetBloodGasMasterTable(detailID);
                if (bloodGasMasterDataTable != null && bloodGasMasterDataTable.Count == 1)
                {
                    dateEdit1.DateTime = bloodGasMasterDataTable[0].RECORD_DATE_TIME;
                    if (!bloodGasMasterDataTable[0].IsNURSE_MEMO_1Null() && bloodGasMasterDataTable[0].NURSE_MEMO_1.Contains("动脉"))
                    {
                        radioGroupBloodGasTypes.SelectedIndex = 1;
                    }
                    CareDocs.BloodGasDetailDataTable bloodGasDetailDataTable = _careDocsDA.GetBloodGasDetailTable(detailID);
                    if (bloodGasDetailDataTable != null && bloodGasDetailDataTable.Count > 0)
                    {
                        CareDocs.BloodGasDetailRow detailRow = null;
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            string code = row.Cells[0].Value.ToString();
                            detailRow = bloodGasDetailDataTable.FindByDETAIL_IDBLG_CODE(detailID, code);
                            if (detailRow != null)
                            {
                                row.Cells[2].Value = detailRow.IsBLG_VALUENull() ? null : detailRow.BLG_VALUE;
                            }
                        }
                    }
                }
            }
        }

        private void CheckSaveButtonStatus()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!string.IsNullOrEmpty(row.Cells[2].ErrorText))
                {
                    btnSave.Enabled = false;
                    return;
                }
            }
            bool find = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[2].FormattedValue != null && !string.IsNullOrEmpty(row.Cells[2].FormattedValue.ToString().Trim()))
                {
                    find = true;
                    break;
                }
            }
            btnSave.Enabled = find;
        }

        private void TimePointBloodGasEditor_Load(object sender, EventArgs e)
        {
            _careDocsDA = new CareDocsDA();
            if (!string.IsNullOrEmpty(_detailID))
            {
                CareDocs.BloodGasMasterDataTable bloodGasMasterDataTable = _careDocsDA.GetBloodGasMasterTable(_detailID);
                if (bloodGasMasterDataTable != null && bloodGasMasterDataTable.Count == 1)
                {
                    if (!bloodGasMasterDataTable[0].IsNURSE_MEMO_2Null() && bloodGasMasterDataTable[0].NURSE_MEMO_2.StartsWith("ok@"))
                    {
                        comboBoxEditSample.SelectedItem = bloodGasMasterDataTable[0].NURSE_MEMO_2.Replace("ok@", "");
                    }
                }
            }
            else if(string.IsNullOrEmpty(_detailID)&&comboBoxEditSample.Properties.Items.Count>0)
            {
                comboBoxEditSample.SelectedIndex=0;
            }
            LoadBloodGasList(_detailID);
            btnSave.Enabled = false;
        }

        private void btnSelectBloodGas_Click(object sender, EventArgs e)
        {
            XtraForm form = new XtraForm();
            form.StartPosition = FormStartPosition.CenterScreen;
            BloodGasSelector bloodGasSelector = new BloodGasSelector(_patientID, _visitID, _operID);
            bloodGasSelector.DefaultDate = dateEdit1.DateTime.Date;
            form.Width = bloodGasSelector.Width;
            form.Height = bloodGasSelector.Height;
            bloodGasSelector.Dock = DockStyle.Fill;
            form.Controls.Add(bloodGasSelector);
            form.Text = "选择血气记录";
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(bloodGasSelector.SelectedDetailID))
                {
                    _detailID = bloodGasSelector.SelectedDetailID;
                    LoadBloodGasList(_detailID);
                    btnSave.Enabled = true;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[2].Value = null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CareDocs.BloodGasMasterDataTable bloodGasMasterDataTable = _careDocsDA.GetBloodGasMasterTable(_patientID, _visitID, _operID);
            if (bloodGasMasterDataTable == null) return;
            CareDocs.BloodGasMasterRow row = null;
            if (string.IsNullOrEmpty(_detailID))
            {
                _detailID = TimePoint.ToString("yyyy-MM-dd HH:mm") + "|" + Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
                row = bloodGasMasterDataTable.NewBloodGasMasterRow();
                row.PAT_ID = _patientID;
                row.VISIT_ID = _visitID;
                row.OPER_ID = _operID;
                row.RECORD_DATE_TIME = TimePoint;
                row.OP_DATE_TIME = DateTime.Now;
                row.OPERATOR = string.IsNullOrEmpty(ExtendApplicationContext.Current.LoginUserContext.HisUserID) ? ExtendApplicationContext.Current.LoginUserContext.LoginName : ExtendApplicationContext.Current.LoginUserContext.HisUserID;
                row.DETAIL_ID = _detailID;
                bloodGasMasterDataTable.AddBloodGasMasterRow(row);
            }
            else
            {
                row=bloodGasMasterDataTable.FindByDETAIL_ID(_detailID);
            }
            if(row==null) return;
            if (radioGroupBloodGasTypes.SelectedIndex == 1)
            {
                row.NURSE_MEMO_1 = "动脉";
            }
            else
            {
                row.SetNURSE_MEMO_1Null();
            }
            row.NURSE_MEMO_2 = "ok@"+comboBoxEditSample.Text.Trim();
            if (_careDocsDA.UpdateBloodGasMaster(bloodGasMasterDataTable) < 0) return;
            CareDocs.BloodGasDetailDataTable detailTable = _careDocsDA.GetBloodGasDetailTable(_detailID);
            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                string blgCode = drow.Cells[0].Value.ToString();
                CareDocs.BloodGasDetailRow detailRow = detailTable.FindByDETAIL_IDBLG_CODE(_detailID, blgCode);
                if (detailRow == null)
                {
                    detailRow = detailTable.NewBloodGasDetailRow();
                    detailRow.DETAIL_ID = _detailID;
                    detailRow.BLG_CODE = blgCode;
                    detailTable.AddBloodGasDetailRow(detailRow);
                }
                detailRow.OP_DATE = DateTime.Now;
                detailRow.OPERATOR = string.IsNullOrEmpty(ExtendApplicationContext.Current.LoginUserContext.HisUserID) ? ExtendApplicationContext.Current.LoginUserContext.LoginName : ExtendApplicationContext.Current.LoginUserContext.HisUserID;
                string value = "";
                if (drow.Cells[2].Value != null && drow.Cells[2].Value != System.DBNull.Value)
                {
                    value = drow.Cells[2].Value.ToString();
                }
                detailRow.BLG_VALUE = value;
            }
            if(_careDocsDA.UpdateBloodGasDetail(detailTable)<0) return;
            ParentForm.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ParentForm.DialogResult = DialogResult.Cancel;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CheckSaveButtonStatus();
        }

        private void radioGroupBloodGasTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSaveButtonStatus();
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                if (e.FormattedValue != null && !e.FormattedValue.Equals(string.Empty))
                {
                    double d = 0;
                    if(!double.TryParse(e.FormattedValue.ToString().Trim(),out d))
                    {
                        dataGridView1[e.ColumnIndex, e.RowIndex].ErrorText = "输入值不是有效的血气值";
                        btnSave.Enabled = false;
                        return;
                    }
                    else if (e.FormattedValue.ToString().Trim().Length > 6)
                    {
                        dataGridView1[e.ColumnIndex, e.RowIndex].ErrorText = "输入值长度不可大于6";
                        btnSave.Enabled = false;
                        return;
                    }
                }
                    dataGridView1[e.ColumnIndex, e.RowIndex].ErrorText = string.Empty;
            }
        }

        private void comboBoxEditSample_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBloodGasList(_detailID);
        }
    }
}
