using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Views;
using Wis.Anes.Framework;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework.Controls;
using Wis.Anes.ServiceProxies;
using Wis.Anes.Framework.Utilities;

namespace Wis.Anes.Views
{
    [ToolboxItem(false)]
    public partial class MonitorDataEditor : BaseView
    {

        //private PatientInformation _patientInfo;
        private List<string> _items;
        private List<object> _values;
        private string _patientID;
        private decimal _visitID, _operID;
        private decimal _eventNo;
        //private Dictionary<string, string> _graphReDict;

        private object _result;

        public object Result
        {
            get { return _result; }
            set { _result = value; }
        }


        public object Result1
        {
            get { return _result; }
            set { _result = value; }
        }

        public MonitorDataEditor(string patientID, decimal visitID, decimal operID, List<string> items, DateTime startTime, List<object> values, decimal eventNo)
            :this(patientID,visitID,operID,items,eventNo)
        {
            _values = values;
            dateEdit1.DateTime = startTime.AddSeconds(double.Parse(txtInterval.Text));
            dateEdit1.DateTime = GetFiveMinuteTime(dateEdit1.DateTime);
            dateEdit2.DateTime = dateEdit1.DateTime.AddMinutes(5);
        }

        public MonitorDataEditor(string patientID,decimal visitID,decimal operID, List<string> items,decimal eventNo)
        {
            Caption = "插入体征数据";
            _eventNo = eventNo;
            _patientID = patientID;
            _visitID = visitID;
            _operID = operID;
            _items = items;
            InitializeComponent();
            dateEdit1.DateTime = DateTime.Now;
            dateEdit1.DateTime = GetFiveMinuteTime(dateEdit1.DateTime);
            dateEdit2.DateTime = dateEdit1.DateTime.AddMinutes(5);
        }

        private DateTime GetFiveMinuteTime(DateTime source)
        {
            DateTime dateTime = source;
            int minute = dateTime.Minute;
            while (minute % 5 != 0)
            {
                dateTime = dateTime.AddMinutes(1);
                minute = dateTime.Minute;
            }
            return dateTime;
        }

        private void MonitorDataEditor_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                if (_items != null && _items.Count > 0)
                {
                    //string[] itemStrings = Configurations.CPBMonitorItemSetString.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                    //_graphReDict = new Dictionary<string, string>();
                    //for (int i = 0; i < itemStrings.Length; i++)
                    //{
                    //    string[] s = itemStrings[i].Split(new string[] { "," }, StringSplitOptions.None);
                    //    _graphReDict.Add(string.IsNullOrEmpty(s[1].Trim()) ? s[0].Trim() : s[1].Trim(), s[0].Trim());
                    //}

                    int top = txtInterval.Bottom + 10;
                    int left1 = label1.Left;
                    int left2 = txtInterval.Left;
                    int height = btnOK.Top - top - 10;
                    int columnIndex = 0, columnCount = ((_items.Count > 5) ? 2 : 1);
                    int width = -30 + (int)(Width - left1 * 2) / columnCount;
                    Dict.MonitorFunctionCodeDataTable monitorFunctionCodeDataTable = null;
                    if (ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_MONITOR_FUNC_CODE"))
                    {
                        monitorFunctionCodeDataTable = ExtendApplicationContext.Current.CodeTables["WIS_MONITOR_FUNC_CODE"] as Dict.MonitorFunctionCodeDataTable;
                    }
                    else
                    {
                        monitorFunctionCodeDataTable = DictProxy.GetMonitorFunctionCode();
                    }
                    for (int i = 0; i < _items.Count; i++)
                    {
                        string item = _items[i];
                        Label label = new Label();
                        label.Text = ExtendApplicationContext.Current.MonitorFunctionCodeDict.ContainsKey(item) ? ExtendApplicationContext.Current.MonitorFunctionCodeDict[item] : item;
                        label.Location = new Point(left1 + (30 + width) * columnIndex, top);
                        //if (_graphReDict.ContainsKey(item))
                        //{
                        //    item = _graphReDict[item];
                        //}
                        MedTextBox textBox = new MedTextBox();
                        if (_values != null && _values.Count > i)
                        {
                            textBox.Text = _values[i].ToString();
                        }
                        textBox.Location = new Point(left2 + (30 + width) * columnIndex, top);
                        textBox.Width = width - left2 - left1;
                        textBox.Tag = item;
                        textBox.EnterMoveNextControl = true;
                        textBox.TextChanged += new EventHandler(textBox_TextChanged);
                        label.Top += 2;// textBox.Top + (int)((textBox.Height - label.Height) / 2);
                        Controls.Add(label);
                        Controls.Add(textBox);
                        label.BringToFront();
                        bool isNumeric = true;
                        if (monitorFunctionCodeDataTable != null && monitorFunctionCodeDataTable.Count > 0)
                        {
                            foreach (Dict.MonitorFunctionCodeRow row in monitorFunctionCodeDataTable)
                            {
                                if (row.ITEM_CODE.Equals(item))
                                {
                                    if (!row.IsITEM_UNITSNull() && !string.IsNullOrEmpty(row.ITEM_UNITS))
                                    {
                                        Label labelUnit = new Label();
                                        labelUnit.Text = row.ITEM_UNITS;
                                        labelUnit.Top = label.Top;
                                        labelUnit.Left = textBox.Right + 5;
                                        Controls.Add(labelUnit);
                                    }
                                    if (!row.IsVALUE_TYPENull() && (row.VALUE_TYPE == 1))
                                    {
                                        isNumeric = false;
                                    }
                                    break;
                                }
                            }
                        }
                        if (isNumeric)
                        {
                            textBox.InputType = MedInputType.Nurmeric;
                        }
                        textBox.BringToFront();
                        if (columnIndex < columnCount - 1)
                        {
                            columnIndex++;
                        }
                        else
                        {
                            top += textBox.Height + 10;
                            columnIndex = 0;
                        }
                    }
                    btnOK.Top = top;
                    btnCancel.Top = top;
                    lblMessage.Top = top;
                    Height = btnOK.Bottom + 10;
                    if (ParentForm != null)
                    {
                        ParentForm.Height = btnOK.Bottom + 50;
                        //ParentForm.AcceptButton = btnOK;
                        ParentForm.CancelButton = btnCancel;
                    }
                }
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            bool enable = false;
            foreach (Control control in (sender as Control).Parent.Controls)
            {
                if (control is MedTextBox && !control.Equals(txtInterval))
                {
                    if (!string.IsNullOrEmpty(control.Text))
                    {
                        enable = true;
                        break;
                    }
                }
            }
            btnOK.Enabled = enable;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            try
            {
                if (dateEdit1.DateTime > dateEdit2.DateTime)
                {
                    //Dialog.MessageBox("开始时间不能大于结束时间",  MessageBoxIcon.Information);
                    //MessageBox.Show("开始时间不能大于结束时间","提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    label5.Text = "开始时间不能大于结束时间";
                    _result = DialogResult.None;
                }
                else if (((TimeSpan)(dateEdit2.DateTime - dateEdit1.DateTime)).TotalHours > 8)
                {
                    //Dialog.MessageBox("每次添加体征数据的时间区域请保持在8小时以内！", MessageBoxIcon.Information);
                    label5.Text = "每次添加体征数据的时间区域请保持在8小时以内";
                    _result = DialogResult.None;
                }
                else
                {

                    //MonitorData monitorData = new MonitorData(_patientInfo,_eventNo);//, _items);
                    NewMonitorData newMonitorData = new NewMonitorData(_patientID, _visitID, _operID, _eventNo);
                    DateTime dt = dateEdit1.DateTime;
                    dt = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0);
                    while (dt <= dateEdit2.DateTime)
                    {
                        AnesInformations.VitalSignDataTable vitalSignDataTable = AnesthesiaSheetProxy.GetVitalSignData(_patientID, _visitID, _operID, _eventNo);
                        int index = _items.Count - 1;
                        foreach (Control control in Controls)
                        {
                            if (control is MedTextBox && !control.Equals(txtInterval))
                            {
                                string text = (control as MedTextBox).Text;
                                //if (string.IsNullOrEmpty(text)) text = "0";
                                //monitorData.SetValue(index--, dt, double.Parse(text));
                                string oldvalue = "0";
                                if (vitalSignDataTable != null && vitalSignDataTable.Rows.Count > 0)
                                {
                                    foreach (AnesInformations.VitalSignRow row in vitalSignDataTable)
                                    {
                                        if (dt == row.TIME_POINT && (control as MedTextBox).Tag.ToString() == row.ITEM_CODE)
                                        {
                                            oldvalue = row.VALUE.ToString();
                                        }
                                    }
                                }
                                //如果是空，则不覆盖20120928
                                if (!string.IsNullOrEmpty(text))
                                {
                                    newMonitorData.SetItem(dt, (control as MedTextBox).Tag.ToString(), text, oldvalue);
                                }
                            }
                        }
                        dt = dt.AddSeconds(double.Parse(txtInterval.Text));
                    }
                    //monitorData.Save();
                    newMonitorData.Save();
                    _result = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                Dialog.MessageBox(ex.Message, MessageBoxIcon.Information);
                _result = DialogResult.None;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _result = DialogResult.Cancel;
        }

        private void dateTimePicker1_Validating(object sender, CancelEventArgs e)
        {
            if (dateEdit1.DateTime > dateEdit2.DateTime)
            {
                lblMessage.Text = "开始时间不能大于结束时间";
                //e.Cancel = true;
            }
            else
            {
                lblMessage.Text = "";
            }
        }
    }
}
