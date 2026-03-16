using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.BusinessEntity;
using Wis.Anes.DataAccess;

namespace Wis.Anes.Framework
{
    [ToolboxItem(false)]
    public partial class TimePointEventEditor : UserControl
    {
        public TimePointEventEditor()
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
                    _rowFilterString = "ITEM_CLASS = '" + EventTypeHelper.GetAnesClassTypeString(AnesClassType.Event) + "'";
                    _anesthesiaEventOpen.DefaultView.RowFilter = _rowFilterString;
                    dataGridViewSource.DataSource = _anesthesiaEventOpen;
                }
            }
        }

        public TimePointEventEditor(string patientID, decimal visitID, decimal operID, decimal eventNo)
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

        public bool Save()
        {
            bool saved = false;
            if (_anesthesiaEventDataTable != null)
            {
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
                _anesthesiaEventDataTable.DefaultView.RowFilter = "(ITEM_CLASS = '" + EventTypeHelper.GetAnesClassTypeString(AnesClassType.Event) 
                    + "') AND START_TIME >= '" + _timePoint.ToString("yyyy-MM-dd HH:mm")
                    + "' AND START_TIME < '" + _timePoint.AddMinutes(1).ToString("yyyy-MM-dd HH:mm") + "'";
                dataGridViewTarget.CellValueChanged += new DataGridViewCellEventHandler(dataGridViewTarget_CellValueChanged);
            }
            return true;
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

        private void WHYX_TimePointEventEditor_Load(object sender, EventArgs e)
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

        private void dataGridViewSource_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewSource.SelectedRows != null && dataGridViewSource.SelectedRows.Count == 1)
            {
                AddAnesthesiaEventRowFromDataGridViewRow(dataGridViewSource.SelectedRows[0]);
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

    }
}
