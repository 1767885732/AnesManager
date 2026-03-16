using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework.Controls;
using Wis.Anes.DataAccess;
using Wis.Anes.Framework.Utilities;

namespace Wis.Anes.Framework
{
    [ToolboxItem(false)]
    public partial class TimePointDrugEditor : UserControl
    {
        public TimePointDrugEditor()
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
                            row["keyStr"] = Wis.Anes.Framework.Controls.Base.StringManage.GetPYString(row.ITEM_NAME).ToLower();
                        }
                    }
                    dataGridViewSource.DataSource = _anesthesiaEventOpen;
                }
            }
        }

        public TimePointDrugEditor(string patientID, decimal visitID, decimal operID, decimal eventNo)
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

        private MedGridPoint _gridPoint;
        public void SetMedGridPoint(MedGridPoint point)
        {
            _gridPoint = point;
        }

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
            if(_anesthesiaEventDataTable != null)
            {
                for (int i = _anesthesiaEventDataTable.Count - 1; i >= 0; i--)
                {
                    if (((_anesthesiaEventDataTable[i].ITEM_CLASS.Equals(EventTypeHelper.GetAnesClassTypeString(AnesClassType.InBlood))
                        || _anesthesiaEventDataTable[i].ITEM_CLASS.Equals(EventTypeHelper.GetAnesClassTypeString(AnesClassType.InLiquid))) && (_anesthesiaEventDataTable[i].IsDOSAGENull() || _anesthesiaEventDataTable[i].DOSAGE <= 0))
                        || ((_anesthesiaEventDataTable[i].IsDOSAGENull() || _anesthesiaEventDataTable[i].DOSAGE <= 0) && (_anesthesiaEventDataTable[i].IsPERFORM_SPEEDNull() || _anesthesiaEventDataTable[i].PERFORM_SPEED <= 0)
                        && (_anesthesiaEventDataTable[i].ITEM_CLASS.Equals(EventTypeHelper.GetAnesClassTypeString(AnesClassType.Drug)) || _anesthesiaEventDataTable[i].ITEM_CLASS.Equals(EventTypeHelper.GetAnesClassTypeString(AnesClassType.AnesDrug)))
                        && (_anesthesiaEventDataTable[i].IsCONCENTRATIONNull() || _anesthesiaEventDataTable[i].CONCENTRATION <= 0)))
                    {
                        if (!_anesthesiaEventDataTable[i].ITEM_NAME.StartsWith("@")
                            && _anesthesiaEventDataTable[i].ITEM_NAME.ToLower().Contains("ml") && _anesthesiaEventDataTable[i].ITEM_NAME.ToLower().Contains("/"))
                        {
                        }
                        else
                        {
                            _anesthesiaEventDataTable[i].Delete();
                        }
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
                if (_gridPoint != null)
                {
                    foreach (AnesInformations.AnesthesiaEventRow row in _anesthesiaEventDataTable)
                    {
                        if (!row.IsITEM_NAMENull() && row.ITEM_NAME.Equals(_gridPoint.Text))
                        {
                            if (!row.IsSTART_DATE_TIMENull() && !row.START_DATE_TIME.Equals(_timePoint) && row.IsEND_DATE_TIMENull())
                            {
                                row.END_DATE_TIME = _timePoint;
                            }
                        }
                    }
                }
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
        }

        public bool GetVitalValues(DateTime timePoint)
        {
            _timePoint = timePoint;
            if (_anesthesiaEventDataTable != null)
            {
                dataGridViewTarget.CellValueChanged -= new DataGridViewCellEventHandler(dataGridViewTarget_CellValueChanged);
                LoadDefalutList();
                _anesthesiaEventDataTable.DefaultView.RowFilter = "(ITEM_CLASS = '" + EventTypeHelper.GetAnesClassTypeString(AnesClassType.AnesDrug) + "' OR ITEM_CLASS = '"
                    + EventTypeHelper.GetAnesClassTypeString(AnesClassType.Drug) + "') AND START_TIME >= '" + _timePoint.ToString("yyyy-MM-dd HH:mm")
                    + "' AND START_TIME < '" + _timePoint.AddMinutes(1).ToString("yyyy-MM-dd HH:mm") + "' AND ITEM_NAME <> '尿量'";
                dataGridViewTarget.CellValueChanged += new DataGridViewCellEventHandler(dataGridViewTarget_CellValueChanged);
            }
            return true;
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
            List<string> defaultList = GetSettings(_patientID, _visitID, _operID, 1);
            if (defaultList != null && defaultList.Count > 0)
            {
                foreach (string itemName in defaultList)
                {
                    if (!string.IsNullOrEmpty(itemName) && !string.IsNullOrEmpty(itemName.Trim()) && !itemName.Equals("尿量"))
                    {
                        AnesInformations.AnesthesiaEventRow anesthesiaEventRow = FindTimePointAnesthesiaEventRow(_anesthesiaEventDataTable.Select(
                            "ITEM_NAME = '" + itemName.Trim() + "'"));
                        if (anesthesiaEventRow == null)
                        {
                            bool find = false;
                            foreach (DataGridViewRow gridRow in dataGridViewSource.Rows)
                            {
                                if (gridRow.Cells["ITEM_NAME"].Value.ToString().Equals(itemName.Trim()))
                                {
                                    anesthesiaEventRow = AddAnesthesiaEventRowFromDataGridViewRow(gridRow);
                                    if (anesthesiaEventRow != null)
                                    {
                                        find = true;
                                        anesthesiaEventRow.SetDOSAGENull();
                                    }
                                    break;
                                }
                            }
                            if (!find)
                            {
                                AnesInformations.AnesthesiaEventRow row = _anesthesiaEventDataTable.NewAnesthesiaEventRow();
                                row.PAT_ID = _patientID;
                                row.VISIT_ID = _visitID;
                                row.OPER_ID = _operID;
                                row.EVENT_NO = _eventNo;
                                row.ITEM_NO = _itemNo++;
                                row.ITEM_CLASS = "2";
                                row.ITEM_NAME = itemName.Trim();
                                row.START_DATE_TIME = _timePoint;
                                _anesthesiaEventDataTable.AddAnesthesiaEventRow(row);
                                btnSave.Enabled = true;
                            }
                        }
                    }
                }
            }
            btnSave.Enabled = false;
        }

        private void WHYX_TimePointDrugEditor_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            btnSave.EnabledChanged += new EventHandler(btnSave_EnabledChanged);
        }

        private static readonly object _isDirtyChanged = new object();
        public event EventHandler IsDirtyChanged
        {
            add
            {
                Events.AddHandler(_isDirtyChanged, value);
            }
            remove
            {
                Events.RemoveHandler(_isDirtyChanged, value);
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

        private void radioGroupTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (radioGroupTypes.SelectedIndex)
            {
                case 1:
                    _rowFilterString = "ITEM_CLASS = '" + EventTypeHelper.GetAnesClassTypeString(AnesClassType.AnesDrug) + "'";
                    break;
                case 2:
                    _rowFilterString = "ITEM_CLASS = '" + EventTypeHelper.GetAnesClassTypeString(AnesClassType.Drug) + "'";
                    break;
                default:
                    _rowFilterString = "";
                    break;
            }
            _anesthesiaEventOpen.DefaultView.RowFilter = _rowFilterString;
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

        private void dataGridViewTarget_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if(_gridPoint.Value != null)
            //dataGridViewTarget.Rows[e.RowIndex].Cells[].Equals(_gridPoint.Text) ;
            //e.ColumnIndex
            btnSave.Enabled = true;
        }

        private void dataGridViewSource_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewSource.SelectedRows != null && dataGridViewSource.SelectedRows.Count == 1)
            {
                AddAnesthesiaEventRowFromDataGridViewRow(dataGridViewSource.SelectedRows[0]);
            }
        }

        private void dataGridViewSource_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                Wis.Anes.Framework.Utilities.GridViewHelper.DataGridViewCellPainting(e);
            }
            else if (sender.Equals(dataGridViewTarget))
            {
                if (dataGridViewTarget.Columns[e.ColumnIndex].Equals(DURATIVE_INDICATOR1))
                {
                    if (dataGridViewTarget.Rows[e.RowIndex].Cells["DURATIVE_INDICATOR1"].Value != System.DBNull.Value 
                        && dataGridViewTarget.Rows[e.RowIndex].Cells["DURATIVE_INDICATOR1"].Value != null)
                    {
                        e.Handled = true;
                        e.PaintBackground(e.ClipBounds, true);
                        StringFormat sf = new StringFormat();
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        if(((decimal)dataGridViewTarget.Rows[e.RowIndex].Cells["DURATIVE_INDICATOR1"].Value) == 1)
                        {
                            using (Brush brush = new SolidBrush((dataGridViewTarget.CurrentCell != null
                                && dataGridViewTarget.CurrentCell.Equals(dataGridViewTarget.Rows[e.RowIndex].Cells[e.ColumnIndex]))
                                ? e.CellStyle.SelectionForeColor : e.CellStyle.ForeColor))
                            {
                                e.Graphics.DrawString("√", e.CellStyle.Font, brush, new RectangleF(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height)
                                    , sf);
                            }
                        }
                    }
                }
            }
        }

        private bool _firstFocus = true;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (_firstFocus)
            {
                _firstFocus = false;
                foreach (DataGridViewRow row in dataGridViewTarget.Rows)
                {
                    if (row.Cells["ITEM_NAME1"].Value.Equals(_key))
                    {
                        dataGridViewTarget.CurrentCell = row.Cells["DOSAGE1"];
                        if (_gridPoint != null && _key.Equals(_gridPoint.Text))
                        {
                            if (!string.IsNullOrEmpty(_gridPoint.SpeedUnit) && (row.Cells["SPEED_UNIT1"].Value == null || row.Cells["SPEED_UNIT1"].Value == System.DBNull.Value
                                || string.IsNullOrEmpty(row.Cells["SPEED_UNIT1"].Value.ToString())))
                            {
                                row.Cells["SPEED_UNIT1"].Value = _gridPoint.SpeedUnit;
                            }
                            if (_gridPoint.Speed > 0 && (row.Cells["PERFORM_SPEED1"].Value == null || row.Cells["PERFORM_SPEED1"].Value == System.DBNull.Value
                                || ((decimal)row.Cells["PERFORM_SPEED1"].Value) <= 0))
                            {
                                row.Cells["PERFORM_SPEED1"].Value = _gridPoint.Speed;
                                dataGridViewTarget.CurrentCell = row.Cells["PERFORM_SPEED1"];
                            }
                        }
                        dataGridViewTarget.Focus();
                        dataGridViewTarget.BeginEdit(true);
                        break;
                    }
                }
            }
            //try
            //{
            //    if (dataGridViewTarget.Focused)
            //    {
            //        int rowIndex = dataGridViewTarget.CurrentRow.Index;
            //        dataGridViewTarget.CurrentCell = dataGridViewTarget.Rows[rowIndex].Cells["DOSAGE1"];
            //        dataGridViewTarget.BeginEdit(true);
            //    }
            //}
            //catch { }
        }

        private void dataGridViewTarget_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 1 && e.RowIndex >= 0 && dataGridViewTarget.CurrentRow != null)
            {
                if (e.ColumnIndex == 2 && (dataGridViewTarget.CurrentRow.Cells[2].Value == null || dataGridViewTarget.CurrentRow.Cells[2].Value == System.DBNull.Value))
                {
                }
                else
                {
                    timer1.Enabled = true;
                }
            }
        }

        private void dataGridViewTarget_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0 && e.RowIndex >= 0 && dataGridViewTarget.Columns[e.ColumnIndex].Equals(DURATIVE_INDICATOR1))
            {
                if (dataGridViewTarget.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null || dataGridViewTarget.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == System.DBNull.Value
                    || ((decimal)dataGridViewTarget.Rows[e.RowIndex].Cells[e.ColumnIndex].Value).Equals(0))
                {
                    dataGridViewTarget.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1;
                }
                else
                {
                    dataGridViewTarget.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            object result = Dialog.SingleInputSelect("请录入药名", "");
            if (result != null)
            {
                AnesInformations.AnesthesiaEventRow row = _anesthesiaEventDataTable.NewAnesthesiaEventRow();
                row.PAT_ID = _patientID;
                row.VISIT_ID = _visitID;
                row.OPER_ID = _operID;
                row.EVENT_NO = _eventNo;
                row.ITEM_NO = _itemNo++;
                row.ITEM_CLASS = "2";
                row.ITEM_NAME = result.ToString();
                row.START_DATE_TIME = _timePoint;
                _anesthesiaEventDataTable.AddAnesthesiaEventRow(row);
                LocateKey(result.ToString());
                _firstFocus = true;
                timer1.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        private void dataGridViewTarget_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewTarget.ReadOnly || e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                return;
            }
            if (dataGridViewTarget.Columns[e.ColumnIndex].HeaderText.Contains("单位"))
            {
                Rectangle rect = dataGridViewTarget.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                Dict.AnesthesiaInputDictDataTable dict = new DictDA().GetDictTable("用药单位");
                Dialog.ShowCustomSelection(dict, "ITEM_NAME", dataGridViewTarget, new Point(rect.Left, rect.Bottom), new Size(rect.Width, 300)
                    , new EventHandler(delegate(object s1, EventArgs e1)
                    {
                        if (s1 is int)
                        {
                            int index = (int)s1;
                            dataGridViewTarget.CurrentCell.Value = dict[index].ITEM_NAME;
                            dataGridViewTarget.CurrentCell = dataGridViewTarget.CurrentRow.Cells[0];
                            dataGridViewTarget.CurrentCell = dataGridViewTarget.CurrentRow.Cells[e.ColumnIndex];
                        }
                    }));
            }
        }


   }
}
