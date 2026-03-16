using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework.Utilities;
using Wis.Anes.DataAccess;

namespace Wis.Anes.Framework
{
    [ToolboxItem(false)]
    public partial class TimePointVitalSign : UserControl
    {
        public TimePointVitalSign()
        {
            InitializeComponent();
            Load += new EventHandler(TimePointVitalSign_Load);
        }

        public TimePointVitalSign(string patientID, decimal visitID, decimal operID, decimal eventNo,List<string> list)
            : this()
        {
            _patientID = patientID;
            _visitID = visitID;
            _operID = operID;
            _list = list;
            _eventNo = eventNo;
            if (_list != null)
            {
                foreach (string s in _list)
                {
                    CheckRowItem(s);
                }
            }
        }

        private string _patientID;
        private decimal _visitID, _operID;
        private decimal _eventNo = 0;
        private DateTime _timePoint;
        private NewMonitorData _newMonitorData;
        private List<string> _list;
        private object _oldValue;

        public bool GetVitalValues(DateTime timePoint)
        {
            _timePoint = timePoint;
            return GetVitalValues();
        }

        private DataGridViewRow CheckRowItem(string text)
        {
            string itemName = text;
            if (itemName.Equals("呼吸"))
            {
                itemName = "RR";
            }
            else if (itemName.Equals("中心静脉压"))
            {
                itemName = "CVP";
            }
            foreach (DataGridViewRow row in dataGridViewVitalSign.Rows)
            {
                if (row.Cells[0].Value.ToString().ToLower().Equals(itemName.ToLower()))
                {
                    return row;
                }
            }
            int index = dataGridViewVitalSign.Rows.Add(new object[] { itemName, "", "" });
            return dataGridViewVitalSign.Rows[index];
        }

        private bool IsEventItem(string itemName)
        {
            if (!string.IsNullOrEmpty(itemName))
            {
                if (itemName.ToLower().Equals("o2") || itemName.Equals("氧气") || itemName.Equals("七氟醚") || itemName.Equals("地氟醚") || itemName.Equals("异氟醚"))
                {
                    return true;
                }
            }
            return false;
        }

        public void LocateKey(string key)
        {
            if (IsEventItem(key))
            {
                return;
            }
            string[] keys = key.Split(',');
            AnesInformations.WIS_PAT_DRUG_DETAILDataTable datatable = new AnesthesiaSheetDA().GetPatientDrugItem(_patientID, _visitID, _operID);
            //if (datatable != null && datatable.Count > 0)
            //{
            //    foreach (DataSetModel.AnesInformations.WIS_PAT_DRUG_DETAILRow row in datatable)
            //    {
            //        if (!row.IsITEM_NAME1Null() && !string.IsNullOrEmpty(row.ITEM_NAME1) && !AnesthesiaRecord_CommonHelper.IsEventItem(row.ITEM_NAME1))
            //        {
            //            CheckRowItem(AnesthesiaRecord_CommonHelper.TransVitalSignName( row.ITEM_NAME1));
            //        }
            //        if (!row.IsITEM_NAME2Null() && !string.IsNullOrEmpty(row.ITEM_NAME2) && !AnesthesiaRecord_CommonHelper.IsEventItem(row.ITEM_NAME2))
            //        {
            //            CheckRowItem(AnesthesiaRecord_CommonHelper.TransVitalSignName(row.ITEM_NAME2));
            //        }
            //    }
            //}
            string[] items = new AnesthesiaSheetDA().GetVitalSignTitles(_patientID, _visitID, _operID, _eventNo);
            if (items != null && items.Length > 0)
            {
                foreach (string text in keys)
                {
                    if (!string.IsNullOrEmpty(text))
                    {
                        CheckRowItem(text);
                    }
                }
            }
            int index = 0;
            foreach (string text in keys)
            {
                if (!string.IsNullOrEmpty(text))
                {
                    CheckRowItem(text);
                }
                if (index++ > 1)
                {
                    break;
                }
            }
            string itemName = keys[0];
            if (keys.Length > 2)
            {
                itemName = keys[2];
            }
            if (itemName.Equals("呼吸"))
            {
                itemName = "RR";
            }
            else if (itemName.Equals("中心静脉压"))
            {
                itemName = "CVP";
            }
            if (!string.IsNullOrEmpty(itemName))
            {
                foreach (DataGridViewRow row in dataGridViewVitalSign.Rows)
                {
                    if (row.Cells[0].Value.ToString().ToLower().Equals(itemName.ToLower()))
                    {
                        dataGridViewVitalSign.CurrentCell = row.Cells[0];
                        break;
                    }
                }
            }
            dataGridViewVitalSign.Focus();
        }

        private List<string> GetList(AnesInformations.VitalSignDataTable vitalSignDataTable)
        {
            List<string> list = new List<string>();
            foreach (AnesInformations.VitalSignRow row in vitalSignDataTable)
            {
                if (!list.Contains(row.ITEM_NAME))
                {
                    list.Add(row.ITEM_NAME);
                }
            }
            return list;
        }

        public bool IsDirty
        {
            get
            {
                if (dataGridViewVitalSign.IsCurrentCellDirty)
                {
                    dataGridViewVitalSign.NotifyCurrentCellDirty(true);
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
            if (_newMonitorData != null)
            {
                saved = _newMonitorData.Save();
                if (saved)
                {
                    btnSave.Enabled = false;
                    btnRefresh.Enabled = false;
                    label1.ForeColor = Color.Blue;
                    label1.Text = "保存成功";
                }
            }
            if (saved)
            {
                _isSaved = true;
            }
            return saved;
        }

        private bool IsDateTimeSame(DateTime dt1, DateTime dt2)
        {
            return dt1.Date.Equals(dt2.Date) && dt1.Hour.Equals(dt2.Hour) && dt2.Minute.Equals(dt1.Minute);
        }

        private bool GetVitalValues()
        {
            _newMonitorData = new NewMonitorData(_patientID, _visitID, _operID, _eventNo);
            AnesInformations.VitalSignDataTable vitalSignDataTable = new AnesthesiaSheetDA().GetVitalSignData(_patientID, _visitID, _operID, _eventNo);
            if (vitalSignDataTable != null)
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                foreach (AnesInformations.VitalSignRow row in vitalSignDataTable)
                {
                    if (IsDateTimeSame(row.TIME_POINT, _timePoint))
                    {
                        string value = "";
                        if (!row.IsVALUENull())
                        {
                            value = row.VALUE;
                        }
                        if (!dict.ContainsKey(row.ITEM_NAME))
                        {
                            dict.Add(row.ITEM_NAME, value);
                        }
                        else
                        {
                            dict[row.ITEM_NAME] = value;
                        }
                    }
                }
                List<string> list = GetList(vitalSignDataTable);
                foreach (string item in list)
                {
                    string value = "";
                    if (dict.ContainsKey(item))
                    {
                        value = dict[item];
                    }
                    string itemName = item;
                    if (itemName.Equals("呼吸"))
                    {
                        itemName = "RR";
                    }
                    else if (itemName.Equals("中心静脉压"))
                    {
                        itemName = "CVP";
                    }
                    CheckRowItem(itemName).Cells[1].Value = value;
                }
            }
            return true;
        }

        private void TimePointVitalSign_Load(object sender, EventArgs e)
        {
            btnSave.EnabledChanged += new EventHandler(btnSave_EnabledChanged);
        }

        private void dataGridViewVitalSign_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 1 && e.RowIndex >= 0)
            {
                timer1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            try
            {
                int rowIndex = dataGridViewVitalSign.CurrentRow.Index;
                dataGridViewVitalSign.CurrentCell = dataGridViewVitalSign.Rows[rowIndex].Cells[1];
                dataGridViewVitalSign.BeginEdit(true);
            }
            catch { }
        }

        private void dataGridViewVitalSign_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 1 && dataGridViewVitalSign.CurrentCell != null)
            {
                _oldValue = dataGridViewVitalSign.CurrentCell.Value;
            }
        }

        private void dataGridViewVitalSign_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                GridViewHelper.DataGridViewCellPainting(e);
            }
        }

        private void dataGridViewVitalSign_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_newMonitorData != null && dataGridViewVitalSign.CurrentRow != null)
            {
                string itemName = dataGridViewVitalSign.CurrentRow.Cells[0].Value.ToString();
                if (itemName.Equals("CVP"))
                {
                    itemName = "中心静脉压";
                }
                else if (itemName.Equals("RR"))
                {
                    itemName = "呼吸";
                }
                _newMonitorData.SetItem(_timePoint, itemName, dataGridViewVitalSign.CurrentRow.Cells[1].Value, _oldValue);
                btnSave.Enabled = true;
                btnRefresh.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<string> noAdd = new List<string>();
            foreach (DataGridViewRow gridRow in dataGridViewVitalSign.Rows)
            {
                noAdd.Add(gridRow.Cells[0].Value.ToString());
            }
            Dict.MonitorFunctionCodeDataTable monitorFunctionCode = new DictDA().GetMonitorFunctionCode();
            List<string> list = new List<string>();
            foreach (Dict.MonitorFunctionCodeRow row in monitorFunctionCode)
            {
                if (!row.IsITEM_NAMENull() && !noAdd.Contains(row.ITEM_NAME) && !list.Contains(row.ITEM_NAME))
                {
                    list.Add(row.ITEM_NAME);
                }
            }
            Dialog.ShowCustomSelection(list, "", btnAdd, new Size(300, 300), new EventHandler(
                delegate(object s1, EventArgs e1)
                {
                    if (s1 is int)
                    {
                        int index = (int)s1;
                        string s = list[index];
                        index = dataGridViewVitalSign.Rows.Add();
                        dataGridViewVitalSign.Rows[index].Cells[0].Value = s;
                    }
                }
            ));
        }


    }
}
