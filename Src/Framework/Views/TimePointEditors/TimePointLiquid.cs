using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.BusinessEntity;
using Wis.Anes.DataAccess;
using Wis.Anes.Framework.Controls.Base;

namespace Wis.Anes.Framework
{
    [ToolboxItem(false)]
    public partial class TimePointLiquid : UserControl
    {
        public TimePointLiquid()
        {
            InitializeComponent();
            dataGridViewSource.AutoGenerateColumns = false;
            dataGridViewTarget.AutoGenerateColumns = false;
            if (!DesignMode)
            {
                _anesthesiaEventOpen = new DictDA().GetAnesthesiaEventOpen();
                if (_anesthesiaEventOpen != null)
                {
                    _anesthesiaEventOpen.Columns.Add("keyStr");
                    foreach (Dict.AnesthesiaEventOpenRow row in _anesthesiaEventOpen)
                    {
                        if (!row.IsITEM_NAMENull())
                        {
                            row["keyStr"] = StringManage.GetPYString(row.ITEM_NAME).ToLower();
                        }
                    }
                    _rowFilterString = "ITEM_CLASS = '" + EventTypeHelper.GetAnesClassTypeString(AnesClassType.InBlood) + "'"
                        + " OR ITEM_CLASS = '" + EventTypeHelper.GetAnesClassTypeString(AnesClassType.InLiquid) + "'";
                    _anesthesiaEventOpen.DefaultView.RowFilter = _rowFilterString;
                    dataGridViewSource.DataSource = _anesthesiaEventOpen;
                }
            }
        }

        public TimePointLiquid(string patientID, decimal visitID, decimal operID, decimal eventNo)
            : this()
        {
            _patientID = patientID;
            _visitID = visitID;
            _operID = operID;
            _eventNo = eventNo;
            if (!DesignMode)
            {
                _anesthesiaEventDataTable = new AnesthesiaSheetDA().GetAnesthesiaEvent(patientID, visitID, operID, eventNo);
                if (_anesthesiaEventDataTable != null)
                {
                    foreach (AnesInformations.AnesthesiaEventRow row in _anesthesiaEventDataTable)
                    {
                        if (row.ITEM_NO > _itemNo)
                        {
                            _itemNo = row.ITEM_NO;
                        }
                    }
                    dataGridViewTarget.DataSource = _anesthesiaEventDataTable;
                }
                _itemNo++;
            }
        }

        private string _patientID;
        private decimal _visitID, _operID;
        private decimal _eventNo = 0;
        private decimal _itemNo = 0;
        private string _key = "";
        private DateTime _timePoint;
        private Dict.AnesthesiaEventOpenDataTable _anesthesiaEventOpen = null;
        private AnesInformations.AnesthesiaEventDataTable _anesthesiaEventDataTable = null;
        private string _rowFilterString = "";

        public bool IsDirty
        {
            get
            {
                if (dataGridViewTarget.IsCurrentCellDirty)
                {
                    dataGridViewTarget.NotifyCurrentCellDirty(true);
                    btnSave.Enabled = true;
                    btnSave.Focus();
                }
                return btnSave.Enabled;
            }
        }

        private bool _isSaved = false;
        public bool IsSaved
        {
            get
            {
                return _isSaved;
            }
        }

        private bool IsDosageValid()
        {
            //foreach (DataGridViewRow row in dataGridViewTarget.Rows)
            //{
            //    if (row.Cells["DOSAGE1"].Value == null || row.Cells["DOSAGE1"].Value == System.DBNull.Value
            //        || ((decimal)row.Cells["DOSAGE1"].Value) < 0)
            //    {
            //        label1.ForeColor = Color.Red;
            //        label1.Text = "只有大于零的剂量才有效";
            //        dataGridViewTarget.CurrentCell = row.Cells["DOSAGE1"];
            //        dataGridViewTarget.BeginEdit(true);
            //        return false;
            //    }
            //}
            if(_anesthesiaEventDataTable != null)
            {
                for (int i = _anesthesiaEventDataTable.Count - 1; i >= 0; i--)
                {
                    if ((_anesthesiaEventDataTable[i].ITEM_CLASS.Equals(EventTypeHelper.GetAnesClassTypeString(AnesClassType.InBlood))
                        || _anesthesiaEventDataTable[i].ITEM_CLASS.Equals(EventTypeHelper.GetAnesClassTypeString(AnesClassType.InLiquid))) && (_anesthesiaEventDataTable[i].IsDOSAGENull() || _anesthesiaEventDataTable[i].DOSAGE <= 0))
                    {
                        _anesthesiaEventDataTable[i].Delete();
                    }
                }
            }
            return true;
        }

        public bool Save()
        {
            bool saved = false;
            if (_anesthesiaEventDataTable != null && IsDosageValid())
            {
                SetOxyGen();
                SetOutLiquid();
                int ret = new AnesthesiaSheetDA().UpdateAnesthesiaEvent(_anesthesiaEventDataTable);
                if (ret > 0)
                {
                    saved = true;
                    _isSaved = true;
                    btnSave.Enabled = false;
                    btnRefresh.Enabled = false;
                    label1.ForeColor = Color.Blue;
                    label1.Text = "保存成功";
                }
            }
            return saved;
        }

        public void LocateKey(string key)
        {
            _key = key;
            if (key.ToLower().Equals("o2") || key.Equals("氧气"))
            {
                radioGroupTypes.SelectedIndex = 2;
                //ChangeType(2);
            }
            else if (key.Equals("尿量") || key.Equals("失血量") || key.Equals("引流液"))
            {
                radioGroupTypes.SelectedIndex = 3;
            }
        }

        private void ClearTextBox()
        {
            txtOutBlood.Text = "";
            txtOutOther.Text = "";
            txtOxySpeed.Text = "";
            txtOxyThickNess.Text = "";
            txtYinLiu.Text = "";
            txtNiaoLiang.Text = "";
        }

        public bool GetVitalValues(DateTime timePoint)
        {
            _timePoint = timePoint;
            if (_anesthesiaEventDataTable != null)
            {
                txtOxySpeed.TextChanged -= new EventHandler(txtOxySpeed_TextChanged);
                txtOxyThickNess.TextChanged -= new EventHandler(txtOxyThickNess_TextChanged);
                dataGridViewTarget.CellValueChanged -= new DataGridViewCellEventHandler(dataGridViewTarget_CellValueChanged);
                ClearTextBox();
                LoadOxygen();
                LoadOutLiquid();
                LoadDefalutList();
                _anesthesiaEventDataTable.DefaultView.RowFilter = "(ITEM_CLASS = '" + EventTypeHelper.GetAnesClassTypeString(AnesClassType.InBlood) + "' OR ITEM_CLASS = '"
                    + EventTypeHelper.GetAnesClassTypeString(AnesClassType.InLiquid) + "') AND START_TIME >= '" + _timePoint.ToString("yyyy-MM-dd HH:mm")
                    + "' AND START_TIME < '" + _timePoint.AddMinutes(1).ToString("yyyy-MM-dd HH:mm") + "'";
                txtOxySpeed.TextChanged += new EventHandler(txtOxySpeed_TextChanged);
                txtOxyThickNess.TextChanged += new EventHandler(txtOxyThickNess_TextChanged);
                txtOutOther.TextChanged += new EventHandler(txtOutOther_TextChanged);
                txtOutBlood.TextChanged += new EventHandler(txtOutBlood_TextChanged);
                txtNiaoLiang.TextChanged += new EventHandler(txtNiaoLiang_TextChanged);
                dataGridViewTarget.CellValueChanged += new DataGridViewCellEventHandler(dataGridViewTarget_CellValueChanged);
            }
            return true;
        }

        private List<string> GetSettings(string patientID, decimal visitID, decimal operID, decimal itemType)
        {
            AnesInformations.WIS_PAT_DRUG_DETAILDataTable datatable = new AnesthesiaSheetDA().GetPatientDrugItem(patientID, visitID, operID, itemType);
            if (datatable == null || datatable.Count == 0)
            {
                return null;
            }
            else
            {
                List<string> list = new List<string>();
                foreach (AnesInformations.WIS_PAT_DRUG_DETAILRow row in datatable)
                {
                    if (!row.IsITEM_NAME_1Null())
                    {
                        list.Add(row.ITEM_NAME_1);
                    }
                    else
                    {
                        list.Add("");
                    }
                }
                return list;
            }
        }

        private void LoadDefalutList()
        {
            List<string> list = GetSettings(_patientID, _visitID, _operID, 2);
            List<string> defaultList = new List<string>();
            if (list != null)
            {
                foreach (string s in list)
                {
                    if (!string.IsNullOrEmpty(s) && !defaultList.Contains(s))
                    {
                        defaultList.Add(s);
                    }
                }
            }
            list = GetSettings(_patientID, _visitID, _operID, 3);
            if (list != null)
            {
                foreach (string s in list)
                {
                    if (!string.IsNullOrEmpty(s) && !defaultList.Contains(s))
                    {
                        defaultList.Add(s);
                    }
                }
            }
            if (defaultList != null && defaultList.Count > 0)
            {
                foreach (string itemName in defaultList)
                {
                    if (!string.IsNullOrEmpty(itemName) && !string.IsNullOrEmpty(itemName.Trim()))
                    {
                        AnesInformations.AnesthesiaEventRow anesthesiaEventRow = FindTimePointAnesthesiaEventRow(_anesthesiaEventDataTable.Select(
                            "ITEM_NAME = '" + itemName.Trim() + "'"));
                        if (anesthesiaEventRow == null)
                        {
                            foreach (DataGridViewRow gridRow in dataGridViewSource.Rows)
                            {
                                if (gridRow.Cells["ITEM_NAME"].Value.ToString().Equals(itemName.Trim()))
                                {
                                    anesthesiaEventRow = AddAnesthesiaEventRowFromDataGridViewRow(gridRow);
                                    if (anesthesiaEventRow != null)
                                    {
                                        anesthesiaEventRow.SetDOSAGENull();
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            btnSave.Enabled = false;
        }

        private bool IsDateTimeSame(DateTime dt1, DateTime dt2)
        {
            return dt1.Date.Equals(dt2.Date) && dt1.Hour.Equals(dt2.Hour) && dt2.Minute.Equals(dt1.Minute);
        }

        private AnesInformations.AnesthesiaEventRow FindTimePointAnesthesiaEventRow(DataRow[] rows)
        {
            if (rows != null && rows.Length > 0)
            {
                foreach (DataRow row in rows)
                {
                    AnesInformations.AnesthesiaEventRow anesthesiaEventRow = row as AnesInformations.AnesthesiaEventRow;
                    if (anesthesiaEventRow != null && !anesthesiaEventRow.IsSTART_DATE_TIMENull() && IsDateTimeSame(anesthesiaEventRow.START_DATE_TIME, _timePoint))
                    {
                        return anesthesiaEventRow;
                    }
                }
            }
            return null;
       }

        private void LoadOxygen()
        {
            AnesInformations.AnesthesiaEventRow anesthesiaEventRow = FindTimePointAnesthesiaEventRow(_anesthesiaEventDataTable.Select("ITEM_NAME = '氧气' AND ITEM_CLASS = '"
                + EventTypeHelper.GetAnesClassTypeString(AnesClassType.InOxygen) + "'"));
            if (anesthesiaEventRow != null)
            {
                if (!anesthesiaEventRow.IsPERFORM_SPEEDNull())
                {
                    txtOxySpeed.Text = anesthesiaEventRow.PERFORM_SPEED.ToString();
                    _storeOxySpeed = txtOxySpeed.Text;
                }
                if (!anesthesiaEventRow.IsCONCENTRATIONNull())
                {
                    txtOxyThickNess.Text = anesthesiaEventRow.CONCENTRATION.ToString();
                    _storeOxyThickNess = txtOxyThickNess.Text;
                }
            }
        }

        private void LoadOutLiquid()
        {
            DataRow[] rows = _anesthesiaEventDataTable.Select("ITEM_NAME = '尿量' OR ITEM_NAME = '失血量' OR ITEM_NAME = '引流液'");
            if (rows != null && rows.Length > 0)
            {
                foreach (DataRow row in rows)
                {
                    AnesInformations.AnesthesiaEventRow anesthesiaEventRow = row as AnesInformations.AnesthesiaEventRow;
                    if (!anesthesiaEventRow.IsSTART_DATE_TIMENull() && IsDateTimeSame(anesthesiaEventRow.START_DATE_TIME, _timePoint) 
                        && !anesthesiaEventRow.IsDOSAGENull() && anesthesiaEventRow.DOSAGE > 0)
                    {
                        if (anesthesiaEventRow.ITEM_NAME.Equals("尿量"))
                        {
                            txtNiaoLiang.Text = anesthesiaEventRow.DOSAGE.ToString();
                        }
                        else if (anesthesiaEventRow.ITEM_NAME.Equals("失血量"))
                        {
                            txtOutBlood.Text = anesthesiaEventRow.DOSAGE.ToString();
                        }
                        else if (anesthesiaEventRow.ITEM_NAME.Equals("引流液"))
                        {
                            txtYinLiu.Text = anesthesiaEventRow.DOSAGE.ToString();
                        }
                    }
                }
            }
        }

        private decimal DecimalFromString(string decimalString)
        {
            decimal value = 0;
            if (!decimal.TryParse(decimalString, out value))
            {
                value = 0;
            }
            return value;
        }

        private void SetOutLiquid(string itemName, string itemValueString)
        {
            if (!_storeNiaoLiang.Equals(itemValueString))
            {
                AnesInformations.AnesthesiaEventRow anesthesiaEventRow = FindTimePointAnesthesiaEventRow(_anesthesiaEventDataTable.Select("ITEM_NAME = '" + itemName + "'"));
                decimal value = DecimalFromString(itemValueString);
                if (anesthesiaEventRow == null && !string.IsNullOrEmpty(itemValueString.Trim()) && value > 0)
                {
                    anesthesiaEventRow = _anesthesiaEventDataTable.NewAnesthesiaEventRow();
                    anesthesiaEventRow.PAT_ID = _patientID;
                    anesthesiaEventRow.VISIT_ID = _visitID;
                    anesthesiaEventRow.OPER_ID = _operID;
                    anesthesiaEventRow.EVENT_NO = _eventNo;
                    anesthesiaEventRow.ITEM_CLASS = EventTypeHelper.GetAnesClassTypeString(AnesClassType.Drug);
                    anesthesiaEventRow.ITEM_NO = _itemNo++;
                    anesthesiaEventRow.ITEM_NAME = itemName;
                    anesthesiaEventRow.START_DATE_TIME = _timePoint;
                    anesthesiaEventRow.DOSAGE_UNITS = "ml";
                    _anesthesiaEventDataTable.AddAnesthesiaEventRow(anesthesiaEventRow);
                }
                if (anesthesiaEventRow != null)
                {
                    if (string.IsNullOrEmpty(itemValueString.Trim()))
                    {
                        anesthesiaEventRow.Delete();
                    }
                    else
                    {
                        anesthesiaEventRow.DOSAGE = value;
                    }
                }
            }
        }

        private void SetOutLiquid()
        {
            SetOutLiquid("尿量", txtNiaoLiang.Text);
            SetOutLiquid("引流液", txtYinLiu.Text);
            SetOutLiquid("失血量", txtOutBlood.Text);
        }

        private void SetOxyGen()
        {
            if (!_storeOxyThickNess.Equals(txtOxyThickNess.Text) || !_storeOxySpeed.Equals(txtOxySpeed.Text))
            {
                AnesInformations.AnesthesiaEventRow anesthesiaEventRow = FindTimePointAnesthesiaEventRow(_anesthesiaEventDataTable.Select("ITEM_NAME = '氧气' AND ITEM_CLASS = '"
                    + EventTypeHelper.GetAnesClassTypeString(AnesClassType.InOxygen) + "'"));
                if (anesthesiaEventRow == null && (!string.IsNullOrEmpty(txtOxyThickNess.Text) || !string.IsNullOrEmpty(txtOxySpeed.Text)))
                {
                    string rowFilter = _anesthesiaEventOpen.DefaultView.RowFilter;
                    _anesthesiaEventOpen.DefaultView.RowFilter = "";
                    foreach (DataGridViewRow gridRow in dataGridViewSource.Rows)
                    {
                        if (gridRow.Cells["ITEM_NAME"].Value.ToString().ToLower().Equals("o2") || gridRow.Cells["ITEM_NAME"].Value.ToString().ToLower().Equals("氧气"))
                        {
                            anesthesiaEventRow = AddAnesthesiaEventRowFromDataGridViewRow(gridRow);
                            if (anesthesiaEventRow != null)
                            {
                                anesthesiaEventRow.SetDURATIVE_INDICATORNull();
                                anesthesiaEventRow.SetDOSAGENull();
                                anesthesiaEventRow.SetDOSAGE_UNITSNull();
                                anesthesiaEventRow.CONCENTRATION_UNITS = "%";
                                anesthesiaEventRow.SPEED_UNITS = "min/L";
                            }
                            break;
                        }
                    }
                    _anesthesiaEventOpen.DefaultView.RowFilter = rowFilter;
                }
                if (anesthesiaEventRow != null)
                {
                    if (string.IsNullOrEmpty(txtOxySpeed.Text) && string.IsNullOrEmpty(txtOxyThickNess.Text))
                    {
                        anesthesiaEventRow.Delete();
                    }
                    else
                    {
                        if (!_storeOxyThickNess.Equals(txtOxyThickNess.Text))
                        {
                            anesthesiaEventRow.CONCENTRATION = DecimalFromString(txtOxyThickNess.Text);
                        }
                        if (!_storeOxySpeed.Equals(txtOxySpeed.Text))
                        {
                            anesthesiaEventRow.PERFORM_SPEED = DecimalFromString(txtOxySpeed.Text);
                        }
                        if (anesthesiaEventRow.IsCONCENTRATIONNull() && anesthesiaEventRow.IsPERFORM_SPEEDNull() || ((!anesthesiaEventRow.IsPERFORM_SPEEDNull() && anesthesiaEventRow.PERFORM_SPEED.Equals(0))
                            && (!anesthesiaEventRow.IsCONCENTRATIONNull() && anesthesiaEventRow.CONCENTRATION.Equals(0))))
                        {
                            anesthesiaEventRow.Delete();
                        }
                    }
                }
            }
        }

        private AnesInformations.AnesthesiaEventRow AnesthesiaEventRowFromDataGridViewRow(DataGridViewRow girdRow)
        {
            if (_anesthesiaEventDataTable != null)
            {
                AnesInformations.AnesthesiaEventRow row = _anesthesiaEventDataTable.NewAnesthesiaEventRow();
                row.PAT_ID = _patientID;
                row.VISIT_ID = _visitID;
                row.OPER_ID = _operID;
                row.EVENT_NO = _eventNo;
                row.ITEM_CLASS = girdRow.Cells["ITEM_CLASS"].Value.ToString();
                row.ITEM_NAME = girdRow.Cells["ITEM_NAME"].Value.ToString();
                row.ITEM_SPEC = girdRow.Cells["ITEM_SPEC"].Value.ToString();
                row.ITEM_CODE = girdRow.Cells["ITEM_CODE"].Value.ToString();
                row.ADMINISTRATOR = girdRow.Cells["ADMINISTRATOR"].Value.ToString();
                if (girdRow.Cells["CONCENTRATION"].Value.ToString() != "")
                {
                    row.CONCENTRATION = Convert.ToDecimal(girdRow.Cells["CONCENTRATION"].Value.ToString());
                }
                row.CONCENTRATION_UNITS = girdRow.Cells["CONCENTRATION_UNITS"].Value.ToString();
                if (girdRow.Cells["DOSAGE"].Value.ToString() != "")
                {
                    row.DOSAGE = Convert.ToDecimal(girdRow.Cells["DOSAGE"].Value.ToString());
                }
                row.DOSAGE_UNITS = girdRow.Cells["DOSAGE_UNITS"].Value.ToString();
                if (girdRow.Cells["PERFORM_SPEED"].Value.ToString() != "")
                {
                    row.PERFORM_SPEED = Convert.ToDecimal(girdRow.Cells["PERFORM_SPEED"].Value.ToString());
                }
                row.SPEED_UNITS = girdRow.Cells["SPEED_UNITS"].Value.ToString();
                row.SUPPLIER_NAME = girdRow.Cells["SUPPLIER_NAME"].Value.ToString();
                //row.EVENT_ATTR = girdRow.Cells["EVENT_ATTR"].Value.ToString();
                if (girdRow.Cells["DURATIVE_INDICATOR"].Value != System.DBNull.Value)
                {
                    row.DURATIVE_INDICATOR = (decimal)girdRow.Cells["DURATIVE_INDICATOR"].Value;
                }
                return row;
            }
            else
            {
                return null;
            }
        }

        private AnesInformations.AnesthesiaEventRow AddAnesthesiaEventRowFromDataGridViewRow(DataGridViewRow girdRow)
        {
            AnesInformations.AnesthesiaEventRow anesthesiaEventRow = AnesthesiaEventRowFromDataGridViewRow(girdRow);
            if (anesthesiaEventRow != null)
            {
                anesthesiaEventRow.ITEM_NO = _itemNo++;
                anesthesiaEventRow.START_DATE_TIME = _timePoint;
                _anesthesiaEventDataTable.AddAnesthesiaEventRow(anesthesiaEventRow);
                btnSave.Enabled = true;
            }
            return anesthesiaEventRow;
        }

        private string _storeOxySpeed = "", _storeOxyThickNess = "", _storeNiaoLiang = "", _storeOutBlood = ""
            , _storeOutOther = "";
        private void txtOxySpeed_TextChanged(object sender, EventArgs e)
        {
            if (!_storeOxySpeed.Equals(txtOxySpeed.Text))
            {
                btnSave.Enabled = true;
            }
        }

        private void txtOxyThickNess_TextChanged(object sender, EventArgs e)
        {
            if (!_storeOxyThickNess.Equals(txtOxyThickNess.Text))
            {
                btnSave.Enabled = true;
            }
        }

        private void txtNiaoLiang_TextChanged(object sender, EventArgs e)
        {
            if (!_storeNiaoLiang.Equals(txtNiaoLiang.Text))
            {
                btnSave.Enabled = true;
            }
        }

        private void txtOutBlood_TextChanged(object sender, EventArgs e)
        {
            if (!_storeOutBlood.Equals(txtOutBlood.Text))
            {
                btnSave.Enabled = true;
            }
        }

        private void txtOutOther_TextChanged(object sender, EventArgs e)
        {
            if (!_storeOutOther.Equals(txtOutOther.Text))
            {
                btnSave.Enabled = true;
            }
        }

        private void dataGridViewTarget_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void dataGridViewSource_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                Wis.Anes.Framework.Utilities.GridViewHelper.DataGridViewCellPainting(e);
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string rowFilterString = _rowFilterString;
            if (!string.IsNullOrEmpty(rowFilterString) && !string.IsNullOrEmpty(txtFilter.Text))
            {
                rowFilterString += " AND keyStr Like '%" + txtFilter.Text.ToLower() + "%'";
            }
            else if (!string.IsNullOrEmpty(txtFilter.Text))
            {
                rowFilterString = "keyStr Like '% " + txtFilter.Text.ToLower() + "%'";
            }
            if (_anesthesiaEventOpen != null)
            {
                _anesthesiaEventOpen.DefaultView.RowFilter = rowFilterString;
                dataGridViewSource.DataSource = _anesthesiaEventOpen;
            }
        }

        private void dataGridViewSource_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewSource.SelectedRows != null && dataGridViewSource.SelectedRows.Count == 1)
            {
                AddAnesthesiaEventRowFromDataGridViewRow(dataGridViewSource.SelectedRows[0]);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private bool _firstFocus = true;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (_firstFocus)
            {
                _firstFocus = false;
                if (_key.ToLower().Equals("O2") || _key.Equals("氧气"))
                {
                    txtOxySpeed.Focus();
                }
                else if (_key.Equals("尿量"))
                {
                    txtNiaoLiang.Focus();
                }
                else
                {
                    foreach (DataGridViewRow row in dataGridViewTarget.Rows)
                    {
                        if (row.Cells["ITEM_NAME1"].Value.Equals(_key))
                        {
                            dataGridViewTarget.CurrentCell = row.Cells["ITEM_NAME1"];
                            dataGridViewTarget.Focus();
                            dataGridViewTarget.BeginEdit(true);
                            break;
                        }
                    }
                }
            }
            try
            {
                if (dataGridViewTarget.Focused)
                {
                    int rowIndex = dataGridViewTarget.CurrentRow.Index;
                    dataGridViewTarget.CurrentCell = dataGridViewTarget.Rows[rowIndex].Cells["DOSAGE1"];
                    dataGridViewTarget.BeginEdit(true);
                }
            }
            catch { }
        }

        private void WHYX_TimePointLiquid_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            btnSave.EnabledChanged += new EventHandler(btnSave_EnabledChanged);
        }

        private static readonly object _isDirtyChanged = new object();
        public event EventHandler IsDirtyChanged
        {
            add
            {
                Events.AddHandler(_isDirtyChanged,value);
            }
            remove
            {
                Events.RemoveHandler(_isDirtyChanged,value);
            }
        }

        private void btnSave_EnabledChanged(object sender, EventArgs e)
        {
            EventHandler eventHandle = Events[_isDirtyChanged] as EventHandler;
            if (eventHandle != null)
            {
                eventHandle(this, e);
            }
        }

        private void dataGridViewTarget_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 1 && e.RowIndex >= 0)
            {
                timer1.Enabled = true;
            }
        }

        private void dataGridViewTarget_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            label1.ForeColor = Color.Red;
            label1.Text = e.Exception.Message;
        }
    }
}
