using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Wis.Anes.Framework.Utilities;
using Wis.Anes.Framework.Controls;
using Wis.Anes.Framework.Views;
using Wis.Anes.Framework;
using Wis.Anes.BusinessEntity;
using Wis.Anes.ServiceProxies;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.Framework.Constants;
using Wis.Anes.Layouts;

namespace Wis.Anes.Views
{
    public partial class AnesthesiaEventsEditor : BaseView
    {
        #region 构造方法

        public AnesthesiaEventsEditor(PatientInformation patientInfo, decimal eventNo)
        {
            _eventNo = eventNo;
            InitializeComponent();
            if (eventNo == 2)
            {
                //lblTitle.Text = "体外循环事件";
            }
            if (!ApplicationConfiguration.ShowYouDao)
            {
                btnYouDao1.Visible = false;
                lblTypes.Left -= btnDelete.Left - btnYouDao1.Left;
                cmbTypes.Left -= btnDelete.Left - btnYouDao1.Left;
                label1.Left -= btnDelete.Left - btnYouDao1.Left;
                btnDelete.Left = btnYouDao1.Left;
                lblYouDaoColor.Visible = false;
            }
            dataGridView1.AutoGenerateColumns = false;
            PerformPatientInformationChanged(patientInfo);
        }

        #endregion 构造方法


        #region 事件接口

        private static readonly object _dataChangedEventHandle = new object();
        public event EventHandler DataChanged
        {
            add
            {
                Events.AddHandler(_dataChangedEventHandle, value);
            }
            remove
            {
                Events.RemoveHandler(_dataChangedEventHandle, value);
            }
        }

        #endregion 事件接口

        #region 变量

        private string validValue = "valid";
        private bool _dataChanged = false;

        private decimal _maxItemNo = 0;

        private decimal _eventNo = 0;

        /// <summary>
        /// 病人基本信息
        /// </summary>
        private PatientInformation _patientInfo;
        private bool _showCloseButton = false;

        private bool _lock = false;

        private AnesInformations.AnesthesiaEventDataTable _anesthesiaEventDataTable;

        //private OperationStatus _operStatus = OperationStatus.Inoperation;

        #endregion 变量

        #region 属性

        //public void AddOper()
        //{
        //    if (_operStatus == OperationStatus.Inoperation)
        //    {
        //        if (!IsEventNameExists(Globals.OPERATIONSTART))
        //        {
        //            AddRow(Globals.OPERATIONSTART);
        //            dataGridView1.Focus();
        //        }
        //        else if (!IsEventNameExists(Globals.OPERATIONEND))
        //        {
        //            AddRow(Globals.OPERATIONEND);
        //            dataGridView1.Focus();
        //        }
        //    }
        //    else if (_operStatus == OperationStatus.InPACU)
        //    {
        //        if (!IsEventNameExists(Globals.PACUEND))
        //        {
        //            AddRow(Globals.PACUEND);
        //            dataGridView1.Focus();
        //        }
        //    }
        //}

        //public void AddAnes()
        //{
        //    if (_operStatus == OperationStatus.Inoperation)
        //    {
        //        if (!IsEventNameExists(Globals.ANESSTART))
        //        {
        //            AddRow(Globals.ANESSTART);
        //        }
        //        else if (!IsEventNameExists(Globals.ANESEND))
        //        {
        //            AddRow(Globals.ANESEND);
        //        }
        //    }
        //    else if (_operStatus == OperationStatus.InPACU)
        //    {
        //        if (!IsEventNameExists(Globals.PACUSTART))
        //        {
        //            AddRow(Globals.PACUSTART);
        //        }
        //    }
        //}

        /// <summary>
        /// 显示关闭按钮
        /// </summary>
        public bool ShowCloseButton
        {
            get
            {
                return _showCloseButton;
            }
            set
            {
                _showCloseButton = value;
                btnClose.Visible = false;
                if (_showCloseButton)
                {
                    if (ParentForm != null)
                    {
                        btnClose.Visible = _showCloseButton;
                        ParentForm.CancelButton = btnClose;
                    }
                }
                else
                {
                    //dataGridView2.Visible = false;
                    pnlTitle.Visible = false;
                }
            }
        }

        /// <summary>
        /// 麻醉开始时间
        /// </summary>
        private DateTime _startTime = DateTime.MaxValue;
        /// <summary>
        /// 麻醉开始时间
        /// </summary>
        private DateTime AnesDateTime
        {
            get
            {
                if (_anesthesiaEventDataTable.Count == 1)
                {
                    foreach (AnesInformations.AnesthesiaEventRow row in _anesthesiaEventDataTable)
                    {
                        if (!row.IsSTART_DATE_TIMENull())
                        {
                            _startTime = row.START_DATE_TIME;
                        }
                    }
                }
                else if (_startTime.Equals(DateTime.MaxValue) && _anesthesiaEventDataTable.Count > 1)
                {
                    ResetStartTime();
                }
                if (!_startTime.Equals(DateTime.MaxValue))
                {
                    return _startTime;
                }
                else
                {
                    return DateTime.Now;
                }
            }
        }

        #endregion 属性

        #region 方法

        public void SetEventType(string typeName)
        {
            btnClose.Visible = true;
            btnCancel.Visible = true;
            BorderStyle = BorderStyle.FixedSingle;
            //GetEventTypeAndBind(typeName);
        }

        public void SetText(string text)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (text.Equals(row.Cells["EventName"].Value))
                {
                    if (row.Cells["Column9"].Value != System.DBNull.Value)
                    {
                        dataGridView1.CurrentCell = row.Cells["Column9"];
                    }
                    else if (row.Cells["Column8"].Value != System.DBNull.Value)
                    {
                        dataGridView1.CurrentCell = row.Cells["Column8"];
                    }
                    else
                    {
                        dataGridView1.CurrentCell = row.Cells["Column10"];
                    }
                    dataGridView1.Focus();
                    break;
                }
            }
        }

        public void SetText(string text, DateTime startTime)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (text.Equals(row.Cells["EventName"].Value) && startTime.Equals((DateTime)row.Cells["StartTime"].Value))
                {
                    if (row.Cells["Column9"].Value != System.DBNull.Value)
                    {
                        dataGridView1.CurrentCell = row.Cells["Column9"];
                    }
                    else if (row.Cells["Column8"].Value != System.DBNull.Value)
                    {
                        dataGridView1.CurrentCell = row.Cells["Column8"];
                    }
                    else
                    {
                        dataGridView1.CurrentCell = row.Cells["Column10"];
                    }
                    dataGridView1.Focus();
                    break;
                }
            }
        }

        private void RaiseDataChanged()
        {
            EventHandler eventHandle = Events[_dataChangedEventHandle] as EventHandler;
            if (eventHandle != null)
            {
                eventHandle(this, null);
            }
        }

        protected void PerformPatientInformationChanged(PatientInformation patientInfo)
        {
            _patientInfo = patientInfo;
            if (patientInfo != null)
            {
                txtPatientID.Text = _patientInfo.PatientID;
                txtName.Text = _patientInfo.Name;
                //BindEventTable();
            }
        }

        /// <summary>
        /// 绑定病人麻醉事件
        /// </summary>
        private void BindEventTable()
        {
            _anesthesiaEventDataTable = AnesthesiaSheetProxy.GetAnesthesiaEvent(_patientInfo.PatientID, _patientInfo.VisitID, _patientInfo.OperID, _eventNo);
            //ActionFactory.AnesthestaEventDataTable = _anesthesiaEventDataTable;
            //ActionFactory.AnesthestaEventDataTable = DataHelper.GetAnesthesiaEvent(_patientInfo.PatientID, _patientInfo.VisitID, _patientInfo.OperID,_eventNo);
            _anesthesiaEventDataTable.DefaultView.Sort = "START_DATE_TIME";
            dataGridView1.DataSource = _anesthesiaEventDataTable;
        }

        private string GetTypeName(string itemType)
        {
            if (_eventNo == 2)
            {
                //Dictionary<string, string>.Enumerator enumerator = Globals.CPBEventType.GetEnumerator();
                //while (enumerator.MoveNext())
                //{
                //    if (enumerator.Current.Value.Equals(itemType))
                //    {
                //        return enumerator.Current.Key;
                //    }
                //}
            }
            else
            {
                if (EventTypeHelper.List.ContainsKey(itemType))
                {
                    return EventTypeHelper.List[itemType];
                }
            }
            return "";
        }

        public override bool IsDirty
        {
            get
            {
                return btnSave.Enabled;
            }
        }

        public bool IsDataChanged
        {
            get
            {
                return btnSave.Enabled;
            }
        }

        public bool IsDataSaved
        {
            get
            {
                return _dataChanged;
            }
        }

        public override bool Save()
        {
            if (!CheckItems())
            {
                return false;
            }
            bool saved = false;
            if (btnSave.Enabled)
            {
                if (_eventNo == 1 && _anesthesiaEventDataTable != null && _anesthesiaEventDataTable.Count > 0)
                {
                    foreach (AnesInformations.AnesthesiaEventRow row in _anesthesiaEventDataTable)
                    {
                        if (row.RowState != DataRowState.Deleted && row.ITEM_NO < 500) row.ITEM_NO += 500;

                    }
                }
                if (AnesthesiaSheetProxy.UpdateAnesthesiaEvent(_anesthesiaEventDataTable) > 0)
                {
                    //AnesInformations.OperationMasterDataTable operationMaster = AnesthesiaSheetProxy.GetOperationMaster(_patientInfo.PatientID, _patientInfo.VisitID, _patientInfo.OperID);
                    //AnesInformations.AnesthesiaPlanDataTable anesPlan = AnesthesiaSheetProxy.GetAnesthesiaPlan(_patientInfo.PatientID, _patientInfo.VisitID, _patientInfo.OperID);
                    //MyVariables.OperationStartTime = "";
                    //MyVariables.OperationEndTime = "";
                    //MyVariables.AnesStartTime = "";
                    //MyVariables.AnesEndTime = "";
                    //string zhenTongBeng = "";//镇痛泵
                    //foreach (AnesInformations.AnesthesiaEventRow row in _anesthesiaEventDataTable)
                    //{
                    //    if (row.ITEM_NAME.Equals(Globals.INDATETIME))
                    //    {
                    //        if (!row.IsSTART_TIMENull())
                    //        {
                    //            operationMaster[0].IN_DATE_TIME = row.START_TIME;
                    //        }
                    //        else
                    //        {
                    //            operationMaster[0].SetIN_DATE_TIMENull();
                    //        }
                    //    }
                    //    if (row.ITEM_NAME.Equals(Globals.OPERATIONSTART))
                    //    {
                    //        if (!row.IsSTART_TIMENull())
                    //        {
                    //            MyVariables.OperationStartTime = row.START_TIME.ToString("yyyy-MM-dd HH:mm");
                    //            operationMaster[0].START_DATE_TIME = row.START_TIME;
                    //        }
                    //        else
                    //        {
                    //            operationMaster[0].SetSTART_DATE_TIMENull();
                    //        }
                    //    }
                    //    if (row.ITEM_NAME.Equals(Globals.OPERATIONEND))
                    //    {
                    //        if (!row.IsSTART_TIMENull())
                    //        {
                    //            MyVariables.OperationEndTime = row.START_TIME.ToString("yyyy-MM-dd HH:mm");
                    //            operationMaster[0].END_DATE_TIME = row.START_TIME;
                    //        }
                    //        else
                    //        {
                    //            operationMaster[0].SetEND_DATE_TIMENull();
                    //        }
                    //    }
                    //    if (row.ITEM_NAME.Equals(Globals.ANESSTART))
                    //    {
                    //        if (!row.IsSTART_TIMENull())
                    //        {
                    //            MyVariables.AnesStartTime = row.START_TIME.ToString("yyyy-MM-dd HH:mm");
                    //            anesPlan[0].ANES_START_TIME = row.START_TIME;
                    //        }
                    //        else
                    //        {
                    //            anesPlan[0].SetANES_START_TIMENull();
                    //        }
                    //    }
                    //    if (row.ITEM_NAME.Equals(Globals.ANESEND))
                    //    {
                    //        if (!row.IsSTART_TIMENull())
                    //        {
                    //            MyVariables.AnesEndTime = row.START_TIME.ToString("yyyy-MM-dd HH:mm");
                    //            anesPlan[0].ANES_END_TIME = row.START_TIME;
                    //            operationMaster[0].OUT_DATE_TIME = row.START_TIME;
                    //        }
                    //        else
                    //        {
                    //            anesPlan[0].SetANES_END_TIMENull();
                    //            operationMaster[0].SetOUT_DATE_TIMENull();
                    //        }
                    //    }
                    //    //if (!row.IsITEM_CLASSNull() && !row.IsITEM_NAMENull())
                    //    //{
                    //    //    Dict.AnesthesiaEventOpenDataTable anesthesiaEventOpenDataTable = DataHelper.GetAnesthesiaEventOpen();
                    //    //    foreach (Dict.AnesthesiaEventOpenRow dictRow in anesthesiaEventOpenDataTable)
                    //    //    {
                    //    //        if (!dictRow.IsITEM_NAMENull() && !dictRow.IsEVENT_ATTR_2Null() && dictRow.ITEM_CLASS.Equals(row.ITEM_CLASS)
                    //    //            && row.ITEM_NAME.Trim().ToLower().StartsWith(dictRow.ITEM_NAME.Trim().Replace(" ", "").ToLower()) && dictRow.EVENT_ATTR_2.Equals("镇痛泵"))
                    //    //        //&& dictRow.ITEM_NAME.Equals(row.ITEM_NAME) && dictRow.EVENT_ATTR_2.Equals("镇痛泵"))
                    //    //        {
                    //    //            zhenTongBeng += "," + dictRow.ITEM_NAME;
                    //    //        }
                    //    //    }
                    //    //}
                    //}
                    //if (!string.IsNullOrEmpty(zhenTongBeng)) zhenTongBeng = zhenTongBeng.Substring(1);
                    //operationMaster[0].ANALGESIC_PUMPS = zhenTongBeng;
                    //DataHelper.UpdateOperationMaster(operationMaster);
                    //int ret = DataHelper.UpdateAnesthesiaPlan(anesPlan);

                    //if(!row.EVENT_ATTR
                    //if (Configurations.DocareSync)
                    //{
                    //    //OperationSync.SyncLC001(_patientInfo.PatientID, _patientInfo.VisitID, _patientInfo.OperID, DateTime.Now, "", "");
                    //}
                    saved = true;
                    btnSave.Enabled = false;
                    btnRefresh.Enabled = false;
                }
            }
            if (saved)
            {
                _dataChanged = true;
                label1.ForeColor = Color.Blue;
                label1.Text = "保存成功";
                btnSave.Enabled = false;
                btnRefresh.Enabled = false;
                CallSaveHandle();
                //if (Configurations.IsLocal)
                //{
                //    FileHelper.WriteHistry(_patientInfo.PatientID, _patientInfo.VisitID, _patientInfo.OperID);
                //}
            }
            return saved;
        }

        private static readonly object _saveHandle = new object();
        public event EventHandler SaveHandle
        {
            add
            {
                Events.AddHandler(_saveHandle, value);
            }
            remove
            {
                Events.RemoveHandler(_saveHandle, value);
            }
        }

        private void CallSaveHandle()
        {
            EventHandler eventHandle = Events[_saveHandle] as EventHandler;
            if (eventHandle != null)
            {
                eventHandle(null, null);
            }
        }

        private void ValidateNumber(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int newInteger = 0;
            float newdecimal = 0;
            if (((!int.TryParse(e.FormattedValue.ToString(), out newInteger) || newInteger < 0) &&
                (!float.TryParse(e.FormattedValue.ToString(), out newdecimal) || newdecimal < 0))
                && e.FormattedValue.ToString() != "")
            {
                e.Cancel = true;
                //if (sender.Equals(dataGridView2) && Configurations.InOperationPanelTimeH)
                //{
                //    label1.Text = (sender as DataGridView).CurrentRow.Cells[0].Value.ToString() + "字段必须为非负数字类型";
                //}
                //else
                {
                    label1.ForeColor = Color.Red;
                    label1.Text = (sender as DataGridView).Columns[e.ColumnIndex].HeaderText + "字段必须为非负数字类型";
                }
            }
            else
            {
                label1.ForeColor = Color.Blue;
                label1.Text = "要删除某时间点，必须选中整行!";
            }
        }

        private AnesInformations.AnesthesiaEventRow NewRow()
        {
            return AnesthesiaSheetProxy.NewAnesthesiaEventRow(_anesthesiaEventDataTable, ExtendApplicationContext.Current.PatientContext, _eventNo);
        }

        private AnesInformations.AnesthesiaEventRow NewRow(string eventName)
        {
            AnesInformations.AnesthesiaEventRow row = NewRow();
            row.ITEM_CLASS = "1";
            row.ITEM_NAME = eventName;
            return row;
        }

        public AnesInformations.AnesthesiaEventRow NewRow(string itemClass, string itemName)
        {
            AnesInformations.AnesthesiaEventRow row = NewRow();
            row.ITEM_CLASS = itemClass;
            row.ITEM_NAME = itemName;
            return row;
        }

        private AnesInformations.AnesthesiaEventRow NewRow(string itemClass, string itemName, string itemSpec
            , string itemCode, string administrator, decimal concentration, string concentrationUnit, decimal dosage
            , string dosageUnit, decimal performSpeed, string speedUnit, string supplierName, string eventAttr)
        {
            AnesInformations.AnesthesiaEventRow row = NewRow();
            string typeName = GetTypeName(itemClass);
            if (typeName.Equals("麻药") || typeName.Equals("药剂") || typeName.Equals("输出") || typeName.Equals("用药") || typeName.Equals("输血")
                || typeName.Equals("输液") || typeName.Equals("出量") || typeName.Equals("输氧") || typeName.Equals("氧气"))
            {
                //if (typeName.Equals("输血") || typeName.Equals("输液"))
                //{
                //    row.ADMINISTRATOR = administrator;
                //    row.DOSAGE = dosage;
                //    row.DOSAGE_UNITS = dosageUnit;
                //}
                //else 
                //    if (typeName.Equals("输氧") || typeName.Equals("氧气"))
                //{
                //    row.ADMINISTRATOR = administrator;
                //    row.PERFORM_SPEED = performSpeed;
                //    row.SPEED_UNIT = speedUnit;
                //}
                //else
                {
                    row.ITEM_SPEC = itemSpec;
                    row.ADMINISTRATOR = administrator;
                    row.CONCENTRATION = concentration;
                    row.CONCENTRATION_UNITS = concentrationUnit;
                    row.DOSAGE = dosage;
                    row.DOSAGE_UNITS = dosageUnit;
                    row.PERFORM_SPEED = performSpeed;
                    row.SPEED_UNITS = speedUnit;
                }
            }
            row.ITEM_CLASS = itemClass;
            row.ITEM_NAME = itemName;
            row.ITEM_CODE = itemCode;
            row.SUPPLIER_NAME = supplierName;
            row.EVENT_ATTR = eventAttr;
            return row;
        }

        private AnesInformations.AnesthesiaEventRow NewRow(DataGridViewRow girdRow)
        {
            AnesInformations.AnesthesiaEventRow row = NewRow();
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
            if (girdRow.Cells["DURATIVE_INDICATOR1"].Value != System.DBNull.Value)
            {
                row.DURATIVE_INDICATOR = (decimal)girdRow.Cells["DURATIVE_INDICATOR1"].Value;
            }
            if (girdRow.Cells["EVENT_ATTR"].Value != System.DBNull.Value)
            {
                row.EVENT_ATTR = girdRow.Cells["EVENT_ATTR"].Value.ToString();
            }
            return row;
        }

        public void CopySpeedRow()
        {
            try
            {
                AnesInformations.AnesthesiaEventRow row = AnesthesiaSheetProxy.CopyAnesthesiaEventRow(_anesthesiaEventDataTable, ExtendApplicationContext.Current.PatientContext, _eventNo, dataGridView1.CurrentRow.Index);
                DataRow sourceRow = _anesthesiaEventDataTable[dataGridView1.CurrentRow.Index];
                if (sourceRow["END_DATE_TIME"] == System.DBNull.Value)
                {
                    sourceRow["END_DATE_TIME"] = DateTime.Now;
                    sourceRow["DURATIVE_INDICATOR"] = 1;
                }
                row.START_DATE_TIME = (DateTime)sourceRow["END_DATE_TIME"];
                //row.SetDOSAGE_UNITSNull();
                //row.SetDOSAGENull();
                //row.SetCONCENTRATION_UNITNull();
                //row.SetCONCENTRATIONNull();
                AddRow(row);
                row.DURATIVE_INDICATOR = 1;
                dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells["Column9"];
            }
            catch { }
        }

        public void CopyConcentrationRow()
        {
            try
            {
                DataRow sourceRow = _anesthesiaEventDataTable[dataGridView1.CurrentRow.Index];
                AnesInformations.AnesthesiaEventRow row = AnesthesiaSheetProxy.CopyAnesthesiaEventRow(_anesthesiaEventDataTable, ExtendApplicationContext.Current.PatientContext, _eventNo, dataGridView1.CurrentRow.Index);
                if (sourceRow["END_DATE_TIME"] == System.DBNull.Value)
                {
                    sourceRow["END_DATE_TIME"] = DateTime.Now;
                    sourceRow["DURATIVE_INDICATOR"] = 1;
                }
                row.START_DATE_TIME = (DateTime)sourceRow["END_DATE_TIME"];
                //row.SetDOSAGE_UNITSNull();
                //row.SetDOSAGENull();
                //row.SetSPEED_UNITNull();
                //row.SetPERFORM_SPEEDNull();
                AddRow(row);
                row.DURATIVE_INDICATOR = 1;
                dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells["Column8"];
            }
            catch { }
        }

        private void AddRow(AnesInformations.AnesthesiaEventRow row)
        {
            _anesthesiaEventDataTable.AddAnesthesiaEventRow(row);
            btnSave.Enabled = true;
            btnRefresh.Enabled = true;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells["ItemNo"].Value.ToString().Equals(row.ITEM_NO.ToString()))
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells["StartTime"];
                    break;
                }
            }
            if (cmbTypes.SelectedIndex > 0)
            {
                int index = cmbTypes.Properties.Items.IndexOf(EventTypeHelper.List[row.ITEM_CLASS]);
                if (cmbTypes.Properties.Items.Count > index && index >= 0)
                {
                    cmbTypes.SelectedIndex = index;
                }
                else
                {
                    cmbTypes.SelectedIndex = 0;
                }
            }
        }

        private AnesInformations.AnesthesiaEventRow NewRow(DataRow row)
        {
            return AnesthesiaSheetProxy.CopyAnesthesiaEventRow(_anesthesiaEventDataTable, ExtendApplicationContext.Current.PatientContext, _eventNo, row);
        }


        //Add By chengying.x @20140213 新增事件模板
        public AnesInformations.AnesthesiaEventRow AddRow(object obj, Nullable<DateTime> startTime, decimal durative)
        {
            AnesInformations.AnesthesiaEventRow row = null;
            if (obj is DataGridViewRow)
            {
                row = NewRow(obj as DataGridViewRow);
            }
            else if (obj is DataRow)
            {
                row = NewRow(obj as DataRow);
            }
            else
            {
                row = NewRow(obj.ToString());
            }
            if (startTime != null)
            {
                row.START_DATE_TIME = (DateTime)startTime;
            }

            if (durative != 0)
            {
                if (durative != 999)
                {
                    row.END_DATE_TIME = (DateTime)row.START_DATE_TIME.AddMinutes(double.Parse(durative.ToString())); // 结束时间为起始时间 + 持续(分钟)
                }
                row.DURATIVE_INDICATOR = 1;
                row.DURATIVE = durative.ToString();
            }

            AddRow(row);
            return row;
        }
        //End Add



        private void AddRow() { AddRow(""); }
        public AnesInformations.AnesthesiaEventRow AddRow(object obj)
        {
            return AddRow(obj, null, null);
        }
        public AnesInformations.AnesthesiaEventRow AddRow(object obj, Nullable<DateTime> startTime, Nullable<DateTime> endDate)
        {
            AnesInformations.AnesthesiaEventRow row = null;
            if (obj is DataGridViewRow)
            {
                row = NewRow(obj as DataGridViewRow);
            }
            else if (obj is DataRow)
            {
                row = NewRow(obj as DataRow);
            }
            else
            {
                row = NewRow(obj.ToString());
            }
            if (startTime != null)
            {
                row.START_DATE_TIME = (DateTime)startTime;
            }
            if (endDate != null)
            {
                row.END_DATE_TIME = (DateTime)endDate;
                row.DURATIVE_INDICATOR = 1;
            }
            AddRow(row);
            return row;
        }

        public AnesInformations.AnesthesiaEventRow AddRow(string itemClass, string itemName, string itemSpec
            , string itemCode, string administrator, decimal concentration, string concentrationUnit, decimal dosage
            , string dosageUnit, decimal performSpeed, string speedUnit, string supplierName, string eventAttr)
        {
            AnesInformations.AnesthesiaEventRow row = NewRow(itemClass, itemName, itemSpec, itemCode, administrator, concentration, concentrationUnit
                , dosage, dosageUnit, performSpeed, speedUnit, supplierName, eventAttr);
            row.PAT_ID = _patientInfo.PatientID;
            row.VISIT_ID = _patientInfo.VisitID;
            row.OPER_ID = _patientInfo.OperID;
            row.EVENT_NO = _eventNo;
            AddRow(row);
            return row;
        }

        private DataGridViewRow GetGridRowByEventName(string eventName)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["EventName"].Value != null && row.Cells["EventName"].Value.ToString().Equals(eventName))
                {
                    return row;
                }
            }
            return null;
        }

        private bool IsEventNameExists(string eventName)
        {
            return GetGridRowByEventName(eventName) != null;
        }

        private DateTime TransDateTime(DateTime dateTime)
        {
            DateTime dt = AnesDateTime;
            dt = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0);
            DateTime dt1 = dateTime;
            dt1 = new DateTime(dt.Year, dt.Month, dt.Day, dt1.Hour, dt1.Minute, 0);
            if (dt1.AddHours(12) < dt) dt1 = dt1.AddDays(1);
            return dt1;
        }

        public void RefreshRow(AnesInformations.AnesthesiaEventRow row)
        {
            //if (Globals.Time > DateTime.MinValue)
            //{
            //    row.START_TIME = Globals.Time;
            //    Globals.Time = DateTime.MinValue;
            //    if (dataGridView1.CurrentRow != null)
            //    {
            //        string typeName = GetTypeName(dataGridView1.CurrentRow.Cells["ItemType"].Value.ToString());
            //        if (typeName.Equals("事件") && btnClose.Visible)
            //        {
            //            btnClose.PerformClick();
            //        }
            //        dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells["Column10"];
            //    }
            //}
            //_isNew = true;
            dataGridView1.Focus();
        }

        public bool CheckItems()
        {

            //获取无剂量药品
            string noDosage = ",";
            DataTable dataTable = DictProxy.GetDict("无剂量药品");
            //DataRow[] rows = dataTable.Select(" ITEM_CLASS = '无剂量药品'");
            //if (rows != null && rows.Length > 0)
            //{
            //    foreach (DataRow row in rows)
            //    {
            //        noDosage += row["ITEM_NAME"] + ",";
            //    }

            //}
            foreach (DataRow row in dataTable.Rows)
            {
                noDosage += row["ITEM_NAME"] + ",";
            }
            noDosage += ",";
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                if (row.Cells["EventName"].Value == null || row.Cells["EventName"].Value == System.DBNull.Value
                    || string.IsNullOrEmpty(row.Cells["EventName"].Value.ToString()))
                {
                    label1.ForeColor = Color.Red;
                    label1.Text = "必须输入名称";
                    dataGridView1.CurrentCell = row.Cells["EventName"];
                    dataGridView1.Focus();
                    return false;
                }
                //else if(row.Cells["EventName"].Value.ToString().Length>60)
                //{
                //    label1.ForeColor = Color.Red;
                //    label1.Text = "名称字符长度不可超过60";
                //    dataGridView1.CurrentCell = row.Cells["EventName"];
                //    dataGridView1.Focus();
                //    return false;
                //}
                string typeName = GetTypeName(row.Cells["ItemType"].Value.ToString());
                if (typeName.Equals("麻药") || typeName.Equals("用药") || typeName.Equals("输血") || typeName.Equals("输液") || typeName.Equals("出量"))
                {
                    if (!typeName.Equals("输血") && (row.Cells["Column7"].Value == System.DBNull.Value || row.Cells["Column7"].Value == null || string.IsNullOrEmpty(row.Cells["Column7"].Value.ToString())))
                    {
                        if (typeName.Equals("输液"))
                        {
                            row.Cells["Column7"].Value = "ivgtt";
                        }
                        else
                        {
                            //dataGridView1.CurrentCell = row.Cells["Column7"];
                            //Dialog.MessageBox("必须填写途径", MessageBoxIcon.Information);
                            //dataGridView1.Focus();
                            //return false;
                        }
                    }
                    if (row.Cells["StartTime"].Value != System.DBNull.Value)
                    {
                        string text = "," + row.Cells["EventName"].Value.ToString() + ",";



                        if (!noDosage.Contains(text) && row.Cells["Column9"].Value == System.DBNull.Value && row.Cells["Column8"].Value == System.DBNull.Value
                            && row.Cells["Column10"].Value == System.DBNull.Value)
                        {
                            if (row.Cells["EventName"].Value == System.DBNull.Value || row.Cells["EventName"].Value == null
                                || (!row.Cells["EventName"].Value.ToString().StartsWith("@") && row.Cells["EventName"].Value.ToString().ToLower().Contains("ml") && row.Cells["EventName"].Value.ToString().ToLower().Contains("/")))
                            {
                            }
                            else
                            {
                                dataGridView1.CurrentCell = row.Cells["Column10"];
                                label1.ForeColor = Color.Red;
                                label1.Text = "必须输入剂量";
                                dataGridView1.Focus();
                                return false;
                            }
                        }
                        if (row.Cells["Column10"].Value != System.DBNull.Value)
                        {
                            if (row.Cells["DosageUnit"].Value == System.DBNull.Value)
                            {
                                dataGridView1.CurrentCell = row.Cells["DosageUnit"];
                                label1.ForeColor = Color.Red;
                                label1.Text = "必须输入剂量单位";
                                dataGridView1.Focus();
                                return false;
                            }
                        }
                        else if (!noDosage.Contains(text) && row.Cells["Column8"].Value != System.DBNull.Value)
                        {
                            if (row.Cells["Column1"].Value == System.DBNull.Value)
                            {
                                dataGridView1.CurrentCell = row.Cells["Column1"];
                                label1.ForeColor = Color.Red;
                                label1.Text = "必须输入浓度单位";
                                dataGridView1.Focus();
                                return false;
                            }
                        }
                        else if (!noDosage.Contains(text) && row.Cells["Column9"].Value != System.DBNull.Value)
                        {
                            if (row.Cells["Column3"].Value == System.DBNull.Value)
                            {
                                dataGridView1.CurrentCell = row.Cells["Column3"];
                                label1.ForeColor = Color.Red;
                                label1.Text = "必须输入速度单位";
                                dataGridView1.Focus();
                                return false;
                            }
                        }
                    }
                }
                //string eventName = row.Cells["EventName"].Value.ToString();
                //foreach (Dict.AnesthesiaEventOpenRow dictRow in eventDict)
                //{
                //    if (!dictRow.IsITEM_NAMENull() && !dictRow.IsEVENT_ATTR_2Null()// && dictRow.ITEM_CLASS.Equals(row.ITEM_CLASS)
                //        && eventName.Trim().ToLower().StartsWith(dictRow.ITEM_NAME.Trim().Replace(" ", "").ToLower()) && dictRow.EVENT_ATTR_2.Equals("镇痛泵"))
                //    //&& dictRow.ITEM_NAME.Equals(row.ITEM_NAME) && dictRow.EVENT_ATTR_2.Equals("镇痛泵"))
                //    {
                //        int index = dictRow.ITEM_NAME.Trim().Replace(" ", "").Length;
                //        string other = eventName.Trim().Substring(index);
                //        bool find = false;
                //        foreach (char c in other)
                //        {
                //            if (c >= '0' && c <= '9')
                //            {
                //                find = true;
                //                break;
                //            }
                //        }
                //        if (!find)
                //        {
                //            Dialog.MessageBox("镇痛泵必须输入用药");
                //            dataGridView1.CurrentCell = row.Cells["EventName"];
                //            dataGridView1.Focus();
                //            return false;
                //        }
                //    }
                //}
            }
            return true;
        }

        private bool isEmptyDate(string dateString)
        {
            return (string.IsNullOrEmpty(dateString) || dateString.Trim().Equals(":"));
        }

        private void ResetStartTime()
        {
            foreach (AnesInformations.AnesthesiaEventRow row in _anesthesiaEventDataTable)
            {
                if (!row.IsSTART_DATE_TIMENull() && _startTime > row.START_DATE_TIME)
                {
                    _startTime = row.START_DATE_TIME;
                }
            }
        }

        #endregion 方法

        #region 控件事件

        #region dataGridView1事件
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].DataPropertyName.Equals("START_DATE_TIME")
                            || dataGridView1.Columns[e.ColumnIndex].DataPropertyName.Equals("END_DATE_TIME"))
            {
                e.Cancel = true;
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Equals(Column8) || dataGridView1.Columns[e.ColumnIndex].Equals(Column9)
                || dataGridView1.Columns[e.ColumnIndex].Equals(Column10))
            {
                if (validValue.Equals(""))
                {
                    validValue = "valid";
                    dataGridView1.CurrentCell.Value = System.DBNull.Value;
                    e.Cancel = false;
                }
                else
                {
                }
            }
            else
            {
                Dialog.MessageBox(e.Exception.Message, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    Color colr = Color.White;
            //    if (i == e.RowIndex)
            //    {
            //        colr = Color.DeepSkyBlue;
            //    }
            //    dataGridView1.Rows[i].DefaultCellStyle.BackColor = colr;

            //}
            //if (dataGridView1.ReadOnly || e.RowIndex == -1 || e.ColumnIndex == -1)
            //{
            //    return;
            //}
            //if (!CanEdit(e.RowIndex, e.ColumnIndex))
            //{
            //    return;
            //}
            //if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("DosageUnit"))
            //{
            //    if (!dataGridView1.CurrentRow.Cells["EventName"].Value.ToString().Contains("麻醉平面"))
            //    {
            //        Rectangle rect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            //        Dict.AnesthesiaInputDictDataTable dict = DictProxy.GetDict("用药单位");
            //        Dialog.ShowCustomSelection(dict, "ITEM_NAME", dataGridView1, new Point(rect.Left, rect.Bottom), new Size(rect.Width, 300)
            //            , new EventHandler(delegate (object s1, EventArgs e1)
            //            {
            //                if (s1 is int)
            //                {
            //                    int index = (int)s1;
            //                    dataGridView1.CurrentCell.Value = dict[index].ITEM_NAME;
            //                    dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells["StartTime"];
            //                    dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells[e.ColumnIndex];
            //                }
            //            }));
            //    }
            //}
            //else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("Column3"))
            //{
            //    Rectangle rect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            //    Dict.AnesthesiaInputDictDataTable dict = DictProxy.GetDict("用药速度单位");
            //    Dialog.ShowCustomSelection(dict, "ITEM_NAME", dataGridView1, new Point(rect.Left, rect.Bottom), new Size(rect.Width, 300)
            //        , new EventHandler(delegate (object s1, EventArgs e1)
            //        {
            //            if (s1 is int)
            //            {
            //                int index = (int)s1;
            //                dataGridView1.CurrentCell.Value = dict[index].ITEM_NAME;
            //                dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells["StartTime"];
            //                dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells[e.ColumnIndex];
            //            }
            //        }));
            //}
            //else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("Column1"))
            //{
            //    Rectangle rect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            //    Dict.AnesthesiaInputDictDataTable dict = DictProxy.GetDict("用药浓度单位");
            //    Dialog.ShowCustomSelection(dict, "ITEM_NAME", dataGridView1, new Point(rect.Left, rect.Bottom), new Size(rect.Width, 300)
            //        , new EventHandler(delegate (object s1, EventArgs e1)
            //        {
            //            if (s1 is int)
            //            {
            //                int index = (int)s1;
            //                dataGridView1.CurrentCell.Value = dict[index].ITEM_NAME;
            //                dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells["StartTime"];
            //                dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells[e.ColumnIndex];
            //            }
            //        }));
            //}
            //else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("Column7"))
            //{
            //    Rectangle rect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            //    Dict.AnesthesiaInputDictDataTable dict = DictProxy.GetDict("用药途径");

            //    Dialog.ShowCustomSelection(dict, "ITEM_NAME", dataGridView1, new Point(rect.Left, rect.Bottom), new Size(rect.Width, 300)
            //        , new EventHandler(delegate (object s1, EventArgs e1)
            //        {
            //            if (s1 is int)
            //            {
            //                int index = (int)s1;
            //                dataGridView1.CurrentCell.Value = dict[index].ITEM_NAME;
            //                if (dataGridView1.CurrentCell.Value.ToString().Contains("泵"))
            //                {
            //                    dataGridView1.CurrentRow.Cells["DURATIVE_INDICATOR"].Value = 1;
            //                }
            //                dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells["StartTime"];
            //                dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells[e.ColumnIndex];
            //            }
            //        }));

            //    //Dialog.ShowCustomSelection(dict, "ITEM_NAME", dataGridView1, new Point(rect.Left, rect.Bottom), new Size(65, 300)
            //    //    , new EventHandler(delegate(object s1, EventArgs e1)
            //    //    {
            //    //        if (s1 is int)
            //    //        {
            //    //            int index = (int)s1;
            //    //            dataGridView1.CurrentCell.Value = dict[index].ITEM_NAME;
            //    //            if (dataGridView1.CurrentCell.Value.ToString().Contains("泵"))
            //    //            {
            //    //                dataGridView1.CurrentRow.Cells["DURATIVE_INDICATOR"].Value = 1;
            //    //            }
            //    //            dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells["StartTime"];
            //    //            dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells[e.ColumnIndex];
            //    //        }
            //    //    }));
            //}
            //else
            //{
            //    dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            //}
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (_lock) return;
            if (e.ColumnIndex == 4 || e.ColumnIndex == 6 || e.ColumnIndex == 8)
            {
                validValue = e.FormattedValue.ToString();
                if (validValue.Equals(""))
                {
                    dataGridView1.CurrentCell.Value = System.DBNull.Value;



                    //如果是 呼吸，允许输入数值的同时 加上单位
                    if (e.RowIndex >= 0 && e.ColumnIndex == 8 && dataGridView1.Rows[e.RowIndex].Cells["EventName"].Value != null
            && dataGridView1.Rows[e.RowIndex].Cells["EventName"].Value != System.DBNull.Value)
                    {
                        string typeName = GetTypeName(dataGridView1.Rows[e.RowIndex].Cells["ItemType"].Value.ToString());
                        if (typeName.Equals("呼吸"))
                        {
                            if (dataGridView1.Rows[e.RowIndex].Cells["EventName"].Value.ToString().Contains("呼吸"))
                            {
                                dataGridView1.Rows[e.RowIndex].Cells["DosageUnit"].Value = "";
                            }
                        }


                    }

                    //e.Cancel = true;
                }
                else
                {
                    ValidateNumber(sender, e);

                    //如果是 呼吸，允许输入数值的同时 加上单位
                    if (e.RowIndex >= 0 && e.ColumnIndex == 8 && dataGridView1.Rows[e.RowIndex].Cells["EventName"].Value != null
            && dataGridView1.Rows[e.RowIndex].Cells["EventName"].Value != System.DBNull.Value)
                    {
                        string typeName = GetTypeName(dataGridView1.Rows[e.RowIndex].Cells["ItemType"].Value.ToString());
                        if (typeName.Equals("呼吸"))
                        {
                            if (dataGridView1.Rows[e.RowIndex].Cells["EventName"].Value.ToString().Contains("呼吸"))
                            {
                                dataGridView1.Rows[e.RowIndex].Cells["DosageUnit"].Value = "次/分";
                            }
                        }


                    }
                }
                return;
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("EventName"))
            {
                if (e.FormattedValue != null && e.FormattedValue.ToString().Length > 60)
                {

                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = false;
                    label1.ForeColor = Color.Red;
                    label1.Text = dataGridView1.Columns[e.ColumnIndex].HeaderText + " 输入错误,字符长度不可大于60";
                    e.Cancel = true;
                    return;
                }
                else if (string.IsNullOrEmpty(e.FormattedValue.ToString().Trim()))
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = false;
                    label1.ForeColor = Color.Red;
                    label1.Text = dataGridView1.Columns[e.ColumnIndex].HeaderText + " 输入错误,事件名称不能为空";
                    e.Cancel = true;
                    return;
                }
            }
            else if (dataGridView1.Columns[e.ColumnIndex].DataPropertyName.Equals("START_DATE_TIME")
                || dataGridView1.Columns[e.ColumnIndex].DataPropertyName.Equals("END_DATE_TIME"))
            {

                if (dataGridView1.Columns[e.ColumnIndex].DataPropertyName.Equals("START_DATE_TIME"))
                {
                    bool isNullOrEmpty = false;
                    if (e.FormattedValue == null)
                    {
                        isNullOrEmpty = true;
                    }
                    else
                    {
                        if (isEmptyDate(e.FormattedValue.ToString()))
                        {
                            isNullOrEmpty = true;
                        }
                        if (isNullOrEmpty)
                        {
                            label1.ForeColor = Color.Red;
                            label1.Text = dataGridView1.Columns[e.ColumnIndex].HeaderText + " 输入错误，必须输入【发生时间】！ ";
                            e.Cancel = true;
                            return;
                        }

                    }

                }

                if (e.FormattedValue != null && !isEmptyDate(e.FormattedValue.ToString()))
                {
                    DateTime date = new DateTime();
                    if ((!DateTime.TryParse(e.FormattedValue.ToString(), out date)) && e.FormattedValue.ToString() != "")
                    {

                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = false;
                        e.FormattedValue.ToString().Remove(0, e.FormattedValue.ToString().Length);
                        label1.ForeColor = Color.Red;
                        label1.Text = dataGridView1.Columns[e.ColumnIndex].HeaderText + " 输入错误,格式为 小时:分钟";
                        e.Cancel = true;
                        return;
                    }
                }
                if (!isEmptyDate(e.FormattedValue.ToString()))
                {


                    //判断结束时间
                    if (dataGridView1.Columns[e.ColumnIndex] == EndDate)
                    {
                        DateTime dt1 = DateTime.Parse(e.FormattedValue.ToString());
                        if ((dataGridView1.CurrentRow.Cells["StartTime"].Value is DateTime) && (DateTime)dataGridView1.CurrentRow.Cells["StartTime"].Value > dt1)
                        {
                            DateTime dt2 = (DateTime)dataGridView1.CurrentRow.Cells["StartTime"].Value;
                            label1.ForeColor = Color.Red;
                            label1.Text = dataGridView1.Columns[e.ColumnIndex].HeaderText + " 输入错误，结束时间【" + dt1.ToString("yyyy-MM-dd HH:mm") + "】小于开始时间【" + dt2.ToString("yyyy-MM-dd HH:mm") + "】！";
                            e.Cancel = true;
                            return;
                            // e.Cancel = true;

                        }
                        else
                        {
                            DateTime dtStart = (DateTime)dataGridView1.CurrentRow.Cells["StartTime"].Value;
                            
                            if (dtStart.AddHours(48) < dt1)
                            {
                                Dialog.MessageBox("结束时间【" + dt1.ToString("yyyy-MM-dd HH:mm") + "】超过开始时间【" + dtStart.ToString("yyyy-MM-dd HH:mm") + "】48小时以上。");
                                dataGridView1.CurrentRow.Cells["EndDate"].Value= System.DBNull.Value;

                            }
                            if (dtStart.AddHours(48) < dt1 && dtStart.AddHours(24) > dt1)
                            {
                                if (Dialog.MessageBox("结束时间【" + dt1.ToString("yyyy-MM-dd HH:mm") + "】超过开始时间【" + dtStart.ToString("yyyy-MM-dd HH:mm") + "】24小时以上，请确认？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 0) == DialogResult.Yes)
                                {
                                    //dataGridView1.CurrentRow.Cells["EndDate"].Value = dt1.AddDays(1);
                                }
                                else
                                {
                                    e.Cancel = true;
                                }
                            }
                        }
                        /*
                        dt1 = TransDateTime(dt1);
                        if ((dataGridView1.CurrentRow.Cells["StartTime"].Value is DateTime) && (DateTime)dataGridView1.CurrentRow.Cells["StartTime"].Value > dt1)
                        {
                            if (dataGridView1.CurrentRow.Cells["EndDate"].Value is DateTime && (DateTime)dataGridView1.CurrentRow.Cells["EndDate"].Value == dt1.AddDays(1))
                            {
                            }
                            else
                            {
                                if (Dialog.MessageBox("该时间段跨天吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 0) == DialogResult.Yes)
                                {
                                    //dataGridView1.CurrentRow.Cells["EndDate"].Value = dt1.AddDays(1);
                                }
                                else
                                {
                                    e.Cancel = true;
                                }
                            }
                        }
                        */

                    }
                }
            }



            label1.ForeColor = Color.Blue;
            label1.Text = "要删除某时间点，必须选中整行!";
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_lock) return;
            if (dataGridView1.CurrentRow != null)
            {
                if (dataGridView1.Columns[e.ColumnIndex] == EndDate || dataGridView1.Columns[e.ColumnIndex] == StartTime)
                {
                    if (!isEmptyDate(dataGridView1.CurrentRow.Cells[e.ColumnIndex].Value.ToString()))
                    {
                        if (dataGridView1.Columns[e.ColumnIndex] == StartTime)
                        {
                            //2011年7月13号 注释
                            //DateTime dt1 = DateTime.Parse(dataGridView1.CurrentRow.Cells[e.ColumnIndex].Value.ToString());
                            //dt1 = TransDateTime(dt1);
                            //ResetStartTime();
                        }
                        else
                        {
                            //2011年7月13号 注释
                            //DateTime dt2 = DateTime.Parse(dataGridView1.CurrentRow.Cells[e.ColumnIndex].Value.ToString());
                            //DateTime dt1 = TransDateTime(dt2);
                            //if ((dataGridView1.CurrentRow.Cells["StartTime"].Value is DateTime) && (DateTime)dataGridView1.CurrentRow.Cells["StartTime"].Value > dt1)
                            //{
                            //    //if (Dialog.MessageBox("该时间段跨天吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 0) == DialogResult.Yes)
                            //    {
                            //        dataGridView1.CurrentRow.Cells["EndDate"].Value = dt1.AddDays(1);
                            //    }
                            //    //else
                            //    {
                            //    }
                            //}
                            //else if ((dataGridView1.CurrentRow.Cells["StartTime"].Value is DateTime) && (DateTime)dataGridView1.CurrentRow.Cells["StartTime"].Value <= dt2.AddDays(-1))
                            //{
                            //    while ((DateTime)dataGridView1.CurrentRow.Cells["StartTime"].Value <= dt2.AddDays(-1))
                            //    {
                            //        dt2 = dt2.AddDays(-1);
                            //    }
                            //    dataGridView1.CurrentRow.Cells["EndDate"].Value = dt2;
                            //}

                            DateTime dt1 = (DateTime)dataGridView1.CurrentRow.Cells["EndDate"].Value;

                            DateTime dtStart = (DateTime)dataGridView1.CurrentRow.Cells["StartTime"].Value;

                            if (dtStart.AddHours(48) < dt1)
                            {
                                //Dialog.MessageBox("结束时间【" + dt1.ToString("yyyy-MM-dd HH:mm") + "】超过开始时间【" + dtStart.ToString("yyyy-MM-dd HH:mm") + "】48小时以上。");
                                dataGridView1.CurrentRow.Cells["EndDate"].Value = System.DBNull.Value;

                            }
                        }
                    }
                    if (!isEmptyDate(dataGridView1.CurrentRow.Cells["EndDate"].Value.ToString()) && !isEmptyDate(dataGridView1.CurrentRow.Cells["StartTime"].Value.ToString())
                        && dataGridView1.CurrentRow.Cells["EndDate"].Value != dataGridView1.CurrentRow.Cells["StartTime"].Value)
                    {
                        dataGridView1.CurrentRow.Cells["DURATIVE_INDICATOR"].Value = 1;
                        dataGridView1.CurrentRow.Cells["Duration"].Value = (int)((DateTime)dataGridView1.CurrentRow.Cells["EndDate"].Value - (DateTime)dataGridView1.CurrentRow.Cells["StartTime"].Value).TotalMinutes;
                    }
                    else
                    {
                        //dataGridView1.CurrentRow.Cells["DURATIVE_INDICATOR"].Value = 0;
                    }
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Duration" && dataGridView1.CurrentRow.Cells["Duration"].Value != null)
                {
                    if (string.IsNullOrEmpty(dataGridView1.CurrentRow.Cells["Duration"].Value.ToString())) dataGridView1.CurrentRow.Cells["Duration"].Value = 0;
                    //dataGridView1.CurrentRow.Cells["EndDate"].Value = ((DateTime)dataGridView1.CurrentRow.Cells["StartTime"].Value).AddMinutes(int.Parse(dataGridView1.CurrentRow.Cells["Duration"].Value.ToString()));
                }
                btnSave.Enabled = true;
                btnRefresh.Enabled = true;
            }
        }

        private Color _colorReadOnlyBack = Color.FromArgb(0xf8, 0xf8, 0xf8);

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {           
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                GridViewHelper.DataGridViewCellPainting(e);
            }
            else if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Equals(DURATIVE_INDICATOR))
            {
                
                e.Handled = true;
                Rectangle rect = e.CellBounds;
                e.PaintBackground(e.ClipBounds, true);
                if (!CanEdit(e.RowIndex, e.ColumnIndex))
                {
                    Rectangle rect1 = new Rectangle(rect.Left + 1, rect.Top + 1, rect.Width - 2, rect.Height - 2);
                    e.Graphics.FillRectangle(new SolidBrush(_colorReadOnlyBack), rect1);
                }
                if (e.Value != null && e.Value.ToString().Equals("1"))
                {
                    string text = "->";
                    Color foreColor = (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.RowIndex == e.RowIndex
                            && dataGridView1.CurrentCell.ColumnIndex == e.ColumnIndex)
                            ? e.CellStyle.SelectionForeColor : e.CellStyle.ForeColor;
                    if (!CanEdit(e.RowIndex, e.ColumnIndex))
                    {
                        foreColor = Color.FromArgb(0x66, 0x66, 0x66);
                    }
                    e.Graphics.DrawString(text, e.CellStyle.Font
                        , new SolidBrush(foreColor), rect.X + 1
                        , rect.Y + (rect.Height - e.Graphics.MeasureString("A", e.CellStyle.Font).Height) / 2);
                }
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Value != null && e.Value != System.DBNull.Value)
            {
                e.Handled = true;
                Rectangle rect = e.CellBounds;
                e.PaintBackground(e.ClipBounds, true);
                if (!CanEdit(e.RowIndex, e.ColumnIndex))
                {
                    Rectangle rect1 = new Rectangle(rect.Left + 1, rect.Top + 1, rect.Width - 2, rect.Height - 2);
                    e.Graphics.FillRectangle(new SolidBrush(_colorReadOnlyBack), rect1);
                }
                string text = e.Value.ToString();
                if (e.ColumnIndex == 0)
                {
                    text = GetTypeName(e.Value.ToString());
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Equals(StartTime) || dataGridView1.Columns[e.ColumnIndex].Equals(EndDate))
                {
                    text = ((DateTime)e.Value).ToString("MM-dd HH:mm");
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Equals(Column13))
                {
                    text = ((DateTime)e.Value).ToString("yyyy-MM-dd");
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Equals(Column10) || dataGridView1.Columns[e.ColumnIndex].Equals(Column8)
                    || dataGridView1.Columns[e.ColumnIndex].Equals(Column9))
                {
                    text = ((decimal)e.Value).ToString("F3").Replace(".000", "");
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Equals(EventName))
                {
                    string attr = "";
                    if (dataGridView1.Rows[e.RowIndex].Cells["EVENTATTR"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["EVENTATTR"].Value != System.DBNull.Value)
                    {
                        attr = dataGridView1.Rows[e.RowIndex].Cells["EVENTATTR"].Value.ToString().Trim();
                    }
                    text += " " + attr;
                }
                if (!string.IsNullOrEmpty(text))
                {
                    object eventAttr = dataGridView1.Rows[e.RowIndex].Cells[EVENTATTR.Name].Value;
                    bool isYouDao = (eventAttr != null && eventAttr.ToString().Equals(EventNames.YOUDAONUMBER));
                    Color foreColor = (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.RowIndex == e.RowIndex
                        && dataGridView1.CurrentCell.ColumnIndex == e.ColumnIndex)
                        ? e.CellStyle.SelectionForeColor : (isYouDao ? ApplicationConfiguration.YouDaoColor : e.CellStyle.ForeColor);
                    if (!CanEdit(e.RowIndex, e.ColumnIndex))
                    {
                        foreColor = Color.FromArgb(0x66, 0x66, 0x66);
                    }
                    if (dataGridView1.Columns[e.ColumnIndex].Equals(EndDate) && dataGridView1.Rows[e.RowIndex].Cells["StartTime"].Value is DateTime
                        && dataGridView1.Rows[e.RowIndex].Cells["EndDate"].Value is DateTime && (DateTime)dataGridView1.Rows[e.RowIndex].Cells["StartTime"].Value
                        < (DateTime)dataGridView1.Rows[e.RowIndex].Cells["EndDate"].Value && TransDateTime((DateTime)dataGridView1.Rows[e.RowIndex].Cells["StartTime"].Value)
                        > TransDateTime((DateTime)dataGridView1.Rows[e.RowIndex].Cells["EndDate"].Value))
                    {
                        foreColor = Color.Red;
                    }
                    e.Graphics.DrawString(text, e.CellStyle.Font
                        , new SolidBrush(foreColor), rect.X + 1
                        , rect.Y + (rect.Height - e.Graphics.MeasureString("A", e.CellStyle.Font).Height) / 2);
                }
            }
            else if (!CanEdit(e.RowIndex, e.ColumnIndex))
            {
                e.Handled = true;
                Rectangle rect = e.CellBounds;
                e.PaintBackground(e.ClipBounds, true);
                if (!CanEdit(e.RowIndex, e.ColumnIndex))
                {
                    Rectangle rect1 = new Rectangle(rect.Left + 1, rect.Top + 1, rect.Width - 2, rect.Height - 2);
                    e.Graphics.FillRectangle(new SolidBrush(_colorReadOnlyBack), rect1);
                }
                if (e.Value != null && e.Value != System.DBNull.Value)
                {
                    string text = e.Value.ToString();
                    if (!string.IsNullOrEmpty(text))
                    {
                        Color foreColor = (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.RowIndex == e.RowIndex
                            && dataGridView1.CurrentCell.ColumnIndex == e.ColumnIndex)
                            ? e.CellStyle.SelectionForeColor : e.CellStyle.ForeColor;
                        if (!CanEdit(e.RowIndex, e.ColumnIndex))
                        {
                            foreColor = Color.FromArgb(0x66, 0x66, 0x66);
                        }
                        e.Graphics.DrawString(text, e.CellStyle.Font
                            , new SolidBrush(foreColor), rect.X + 1
                            , rect.Y + (rect.Height - e.Graphics.MeasureString("A", e.CellStyle.Font).Height) / 2);
                    }
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!CanEdit(e.RowIndex, e.ColumnIndex))
            {
                return;
            }
            if (dataGridView1.ReadOnly || e.ColumnIndex == -1 || e.RowIndex == -1)
            {
                return;
            }
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name.Equals("EndDate") && (dataGridView1.CurrentCell.Value == null
                || string.IsNullOrEmpty(dataGridView1.CurrentCell.Value.ToString())))
            {
                try
                {
                    dataGridView1.CurrentCell.Value = DateTime.Now;
                    dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells["StartTime"];
                    dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells["EndDate"];
                }
                catch
                {
                }
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Equals(Column13))
            {
                DateTime dt = (DateTime)dataGridView1.Rows[e.RowIndex].Cells["Column13"].Value;
                dt = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0);
                object result = Dialog.SingleInputSelect("请输入日期", "麻醉日期", dt, "yyyy-MM-dd");
                if (result != null)
                {
                    DateTime dt1 = (DateTime)result;
                    dt1 = new DateTime(dt1.Year, dt1.Month, dt1.Day, dt.Hour, dt.Minute, 0);
                    if (!dt.Equals(dt1))
                    {
                        int n = (dt1 - dt).Days;
                        if (n >= 1 || n <= -1)
                        {
                            DialogResult res = Dialog.MessageBox("您选的日期跨越了 " + Math.Abs(n) + " 天，请确认。", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (res == DialogResult.No)
                            {
                                return;
                            }
                        }

                        _lock = true;
                        dataGridView1.CurrentCell.Value = dt1;
                        ResetStartTime();
                        _lock = false;
                        btnSave.Enabled = true;
                        btnRefresh.Enabled = true;
                    }
                }
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("DosageUnit"))
            {
                if (!dataGridView1.CurrentRow.Cells["EventName"].Value.ToString().Contains("麻醉平面"))
                {
                    Rectangle rect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    Dict.AnesthesiaInputDictDataTable dict = DictProxy.GetDict("用药单位");
                    Dialog.ShowCustomSelection(dict, "ITEM_NAME", dataGridView1, new Point(rect.Left, rect.Bottom), new Size(rect.Width, 300)
                        , new EventHandler(delegate (object s1, EventArgs e1)
                        {
                            if (s1 is int)
                            {
                                int index = (int)s1;
                                dataGridView1.CurrentCell.Value = dict[index].ITEM_NAME;
                                dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells["StartTime"];
                                dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells[e.ColumnIndex];
                            }
                        }));
                }
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("Column3"))
            {
                Rectangle rect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                Dict.AnesthesiaInputDictDataTable dict = DictProxy.GetDict("用药速度单位");
                Dialog.ShowCustomSelection(dict, "ITEM_NAME", dataGridView1, new Point(rect.Left, rect.Bottom), new Size(rect.Width, 300)
                    , new EventHandler(delegate (object s1, EventArgs e1)
                    {
                        if (s1 is int)
                        {
                            int index = (int)s1;
                            dataGridView1.CurrentCell.Value = dict[index].ITEM_NAME;
                            dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells["StartTime"];
                            dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells[e.ColumnIndex];
                        }
                    }));
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("Column1"))
            {
                Rectangle rect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                Dict.AnesthesiaInputDictDataTable dict = DictProxy.GetDict("用药浓度单位");
                Dialog.ShowCustomSelection(dict, "ITEM_NAME", dataGridView1, new Point(rect.Left, rect.Bottom), new Size(rect.Width, 300)
                    , new EventHandler(delegate (object s1, EventArgs e1)
                    {
                        if (s1 is int)
                        {
                            int index = (int)s1;
                            dataGridView1.CurrentCell.Value = dict[index].ITEM_NAME;
                            dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells["StartTime"];
                            dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells[e.ColumnIndex];
                        }
                    }));
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("Column7"))
            {
                Rectangle rect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                Dict.AnesthesiaInputDictDataTable dict = DictProxy.GetDict("用药途径");

                Dialog.ShowCustomSelection(dict, "ITEM_NAME", dataGridView1, new Point(rect.Left, rect.Bottom), new Size(rect.Width, 300)
                    , new EventHandler(delegate (object s1, EventArgs e1)
                    {
                        if (s1 is int)
                        {
                            int index = (int)s1;
                            dataGridView1.CurrentCell.Value = dict[index].ITEM_NAME;
                            if (dataGridView1.CurrentCell.Value.ToString().Contains("泵"))
                            {
                                dataGridView1.CurrentRow.Cells["DURATIVE_INDICATOR"].Value = 1;
                            }
                            dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells["StartTime"];
                            dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells[e.ColumnIndex];
                        }
                    }));

                //Dialog.ShowCustomSelection(dict, "ITEM_NAME", dataGridView1, new Point(rect.Left, rect.Bottom), new Size(65, 300)
                //    , new EventHandler(delegate(object s1, EventArgs e1)
                //    {
                //        if (s1 is int)
                //        {
                //            int index = (int)s1;
                //            dataGridView1.CurrentCell.Value = dict[index].ITEM_NAME;
                //            if (dataGridView1.CurrentCell.Value.ToString().Contains("泵"))
                //            {
                //                dataGridView1.CurrentRow.Cells["DURATIVE_INDICATOR"].Value = 1;
                //            }
                //            dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells["StartTime"];
                //            dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells[e.ColumnIndex];
                //        }
                //    }));
            }
            else
            {
                dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            }

            //else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("ItemType"))
            //{
            //    Rectangle rect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            //    Dialog.ShowCustomSelection(EventTypeDict.List , "Value", dataGridView1, new Point(rect.Left, rect.Bottom), new Size(65, 100)
            //        , new EventHandler(delegate(object s1, EventArgs e1)
            //        {
            //            if (s1 is int)
            //            {
            //                int index = (int)s1;
            //                dataGridView1.CurrentCell.Value = EventTypeDict.List.GetKey(index);
            //            }
            //        }));
            //}
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Equals(DURATIVE_INDICATOR))
            {
                if (CanEdit(e.RowIndex, e.ColumnIndex))
                {
                    if (dataGridView1.CurrentRow.Cells["DURATIVE_INDICATOR"].Value != null && dataGridView1.CurrentRow.Cells["DURATIVE_INDICATOR"].Value.ToString().Equals("1"))
                    {
                        dataGridView1.CurrentRow.Cells["DURATIVE_INDICATOR"].Value = 0;
                    }
                    else
                    {
                        dataGridView1.CurrentRow.Cells["DURATIVE_INDICATOR"].Value = 1;
                    }
                }
            }
        }

        private int _doubleClickCount = 0;

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
            {
                btnDelete.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
            }
        }

        private bool CanEdit(int rowIndex, int columnIndex)
        {
            bool result = true;




            if (rowIndex < 0 || columnIndex < 1)// || columnIndex == dataGridView1.Columns.IndexOf(DURATIVE_INDICATOR))
            {
                result = false;
            }
            else
            {
                DataGridViewColumn column = dataGridView1.Columns[columnIndex];
                string typeName = GetTypeName(dataGridView1.Rows[rowIndex].Cells["ItemType"].Value.ToString());
                if (typeName.Equals("麻药") || typeName.Equals("药剂") || typeName.Equals("输出") || typeName.Equals("用药") || typeName.Equals("输血")
                    || typeName.Equals("输液") || typeName.Equals("出量") || typeName.Equals("镇痛") || typeName.Equals("抗生素") || typeName.Equals("特殊材料") || typeName.Equals("诱导") || typeName.Equals("输氧") || typeName.Equals("氧气"))
                {

                    //if (typeName.Equals("输血") || typeName.Equals("输液"))
                    //{
                    //    if (column.Equals(EventName) || column.Equals(StartTime) || column.Equals(Column10) || column.Equals(DosageUnit) || column.Equals(Column13)
                    //        || column.Equals(Column7))
                    //    {
                    //    }
                    //    else
                    //    {
                    //        result = false;
                    //    }
                    //}
                    //else 
                    //    if (typeName.Equals("输氧") || typeName.Equals("氧气"))
                    //{
                    //    if (column.Equals(EventName) || column.Equals(StartTime) || column.Equals(Column3) || column.Equals(Column9) || column.Equals(Column13)
                    //        || column.Equals(Column7) || column.Equals(EndDate) || column.Equals(DURATIVE_INDICATOR))
                    //    {
                    //    }
                    //    else
                    //    {
                    //        result = false;
                    //    }
                    //}
                }
                else
                {
                    if (column.Equals(EventName) || column.Equals(StartTime) || column.Equals(EndDate) || column.Equals(Column13))
                    {
                    }
                    else
                    {
                        result = false;
                    }
                }
            }


            if (rowIndex >= 0 && columnIndex > 0 && dataGridView1.Columns[columnIndex].Equals(DosageUnit) && dataGridView1.Rows[rowIndex].Cells["EventName"].Value != null
                && dataGridView1.Rows[rowIndex].Cells["EventName"].Value != System.DBNull.Value)
            {
                string typeName = GetTypeName(dataGridView1.Rows[rowIndex].Cells["ItemType"].Value.ToString());
                if (typeName.Equals("事件"))
                {
                    if (dataGridView1.Rows[rowIndex].Cells["EventName"].Value.ToString().Contains("麻醉平面"))
                    {
                        result = true;
                    }
                }

            }
            //如果是 呼吸，允许输入数值
            if (rowIndex >= 0 && columnIndex > 0 && dataGridView1.Columns[columnIndex].Equals(Column10) && dataGridView1.Rows[rowIndex].Cells["EventName"].Value != null
    && dataGridView1.Rows[rowIndex].Cells["EventName"].Value != System.DBNull.Value)
            {
                string typeName = GetTypeName(dataGridView1.Rows[rowIndex].Cells["ItemType"].Value.ToString());
                if (typeName.Equals("呼吸"))
                {
                    if (dataGridView1.Rows[rowIndex].Cells["EventName"].Value.ToString().Contains("呼吸"))
                    {
                        result = true;
                    }
                }

            }
            //如果是 呼吸，DURATIVE_INDICATOR 列 允许输入数值
            if (rowIndex >= 0 && columnIndex > 0 && dataGridView1.Columns[columnIndex].Equals(DURATIVE_INDICATOR) && dataGridView1.Rows[rowIndex].Cells["EventName"].Value != null
    && dataGridView1.Rows[rowIndex].Cells["EventName"].Value != System.DBNull.Value)
            {
                string typeName = GetTypeName(dataGridView1.Rows[rowIndex].Cells["ItemType"].Value.ToString());
                if (typeName.Equals("呼吸"))
                {
                    if (dataGridView1.Rows[rowIndex].Cells["EventName"].Value.ToString().Contains("呼吸"))
                    {
                        result = true;
                    }
                }

            }
            //如果是 瞳孔，允许输入数值
            if (rowIndex >= 0 && columnIndex > 0 && dataGridView1.Columns[columnIndex].Equals(Column10) && dataGridView1.Rows[rowIndex].Cells["EventName"].Value != null
    && dataGridView1.Rows[rowIndex].Cells["EventName"].Value != System.DBNull.Value)
            {
                string typeName = GetTypeName(dataGridView1.Rows[rowIndex].Cells["ItemType"].Value.ToString());
                if (typeName.Equals("其他"))
                {
                    if (dataGridView1.Rows[rowIndex].Cells["EventName"].Value.ToString().Contains("瞳孔监测"))
                    {
                        result = true;
                    }
                }

            }
            return result;
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            bool canEdit = CanEdit(e.RowIndex, e.ColumnIndex);
            if (!canEdit)
            {
                e.Cancel = true;
            }
            else
            {
                //dataGridView1.get
            }
        }


        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (editControl != null)
            {
                editControl.KeyDown -= Integer_KeyDown;
                editControl.KeyPress -= Integer_KeyPress;
            }
        }

        /// <summary>
        /// 整数输入控制-键盘按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Integer_KeyDown(object sender, KeyEventArgs e)
        {
            isRejectInput = false;
            if ((e.Modifiers & Keys.Shift) == Keys.Shift)
            {
                isRejectInput = true;
                e.Handled = true;
                return;
            }
            ///数字0-9
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                ///数字键区域0-9
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    ///退格键或者减号键
                    if ((e.KeyCode != Keys.Back) && (e.KeyCode != Keys.Subtract))
                    {
                        if (_inputType == MedInputType.Integer)
                        {
                            isRejectInput = true;
                        }
                        else if (e.KeyCode != Keys.Decimal || (e.KeyCode == Keys.Decimal && (sender as Control).Text.Contains(".")))
                        {
                            if (e.KeyCode != Keys.OemPeriod || (e.KeyCode == Keys.OemPeriod && (sender as Control).Text.Contains(".")))
                                isRejectInput = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 整数输入控制-键盘输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Integer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isRejectInput == true)
            {
                e.Handled = true; //设置该次键入未能通过验证
                isRejectInput = false;
            }

        }

        DataGridViewTextBoxEditingControl editControl;
        bool isRejectInput;
        MedInputType _inputType = MedInputType.General;

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            e.Control.TextChanged -= editor_TextChanged;
            e.Control.TextChanged += editor_TextChanged;
            if (e.Control is DataGridViewTextBoxEditingControl)
            {
                editControl = (DataGridViewTextBoxEditingControl)e.Control;

                if (grid.CurrentCell != null && grid.CurrentRow != null && (grid.Columns[grid.CurrentCell.ColumnIndex].Equals(Column8)
                    || grid.Columns[grid.CurrentCell.ColumnIndex].Equals(Column9) || grid.Columns[grid.CurrentCell.ColumnIndex].Equals(Column10)))
                {
                    _inputType = MedInputType.Nurmeric;
                    editControl.KeyDown += Integer_KeyDown;
                    editControl.KeyPress += Integer_KeyPress;
                }
            }
            //if (grid.Columns[grid.CurrentCell.ColumnIndex].Equals(StartTime) || grid.Columns[grid.CurrentCell.ColumnIndex].Equals(EndDate))
            //{
            //    e.Control.Visible = false;
            //    Rectangle rect = grid.GetCellDisplayRectangle(grid.CurrentCell.ColumnIndex, grid.CurrentCell.RowIndex, true);
            //    DateTime dt = (grid.CurrentCell.Value == null || grid.CurrentCell.Value == DBNull.Value || grid.CurrentCell.Value.Equals("")) ? DateTime.MinValue : (DateTime)grid.CurrentCell.Value;
            //    Dialog.ShowDevDateTimeEditor(dt, dataGridView1, rect, new EventHandler(delegate(object s1, EventArgs e1)
            //    {
            //        if (s1 != null && s1.ToString() != string.Empty && DateTime.Parse(s1.ToString()) != DateTime.MinValue)
            //        {
            //            grid.CurrentCell.Value = ((DateTime)s1);//.ToString("yyyy-MM-dd HH:mm");
            //        }
            //        else
            //        {
            //            grid.CurrentCell.Value = null;
            //        }
            //    }), "t");
            //}
            //object d = grid.CurrentCell.Value;
        }

        private void editor_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        #endregion  dataGridView1事件

        public void SetReadOnly(bool isReadOnly)
        {
            if (isReadOnly)
            {
                dataGridView1.ReadOnly = true;
                pnlBottom.Visible = false;
                dataGridView1.ContextMenuStrip = null;
            }
            else
            {
                dataGridView1.ReadOnly = false;
                pnlBottom.Visible = true;
                dataGridView1.ContextMenuStrip = contextMenuStrip1;
            }
        }

        private void AnesthesiaDrugEventEdit_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                if (ParentForm != null && ParentForm.Name == "FloatFrm")
                {
                    btnApplyModel.Visible = false;
                    btnSaveModel.Visible = false;
                }
                _maxItemNo = PatientInformationsProxy.GetMaxEventItemNo(_patientInfo.PatientID, _patientInfo.VisitID, _patientInfo.OperID);
                this.StartTime.Mask = "00:00";
                this.EndDate.Mask = "00:00";
                string buttonDockString = ConfigurationHelper.Read(Name + ".ButtonDock");
                //DataHelper.ClearSheetAnesthesiaEvent(_patientInfo.PatientID, _patientInfo.VisitID, _patientInfo.OperID);
                BindEventTable();
                lblYouDaoColor.ForeColor = ApplicationConfiguration.YouDaoColor;
                cmbTypes.Properties.Items.Clear();
                cmbTypes.Properties.Items.Add("全部");
                Dictionary<string, string>.Enumerator enumerator;
                if (_eventNo != 2)
                {
                    enumerator = EventTypeHelper.List.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        if (!cmbTypes.Properties.Items.Contains(enumerator.Current.Value))
                        {
                            cmbTypes.Properties.Items.Add(enumerator.Current.Value);
                        }
                    }
                }
                else
                {
                    //enumerator = Globals.CPBEventType.GetEnumerator();
                    //while (enumerator.MoveNext())
                    //{
                    //    cmbTypes.Properties.Items.Add(enumerator.Current.Key);
                    //}
                }
            }
        }

        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                _anesthesiaEventDataTable.AcceptChanges();

            string selector = cmbTypes.EditValue == null ? "" : cmbTypes.EditValue.ToString();
            //BindEventTable();
            SetType(selector);
        }

        private void toolStripMenuItemInsert_Click(object sender, EventArgs e)
        {
            AddRow();
        }

        private void toolStripMenuItemEmpty_Click(object sender, EventArgs e)
        {
            int count = dataGridView1.Rows.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                dataGridView1.Rows.RemoveAt(i);
                btnSave.Enabled = true;
                btnRefresh.Enabled = true;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //DataHelper.ClearSheetAnesthesiaEvent(_patientInfo.PatientID, _patientInfo.VisitID, _patientInfo.OperID);
            BindEventTable();
            if (cmbTypes.SelectedIndex >= 0)
            {
                SetType(cmbTypes.Properties.Items[cmbTypes.SelectedIndex].ToString());
            }
            btnSave.Enabled = false;
            btnRefresh.Enabled = false;
        }

        private void toolStripMenuItemYouDao_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > -1 && _anesthesiaEventDataTable.Rows.Count > 0 && dataGridView1.CurrentRow != null
                && dataGridView1.CurrentRow.Index >= 0)
            {
                if (dataGridView1.CurrentRow.Cells["EVENTATTR"].Value == null || dataGridView1.CurrentRow.Cells["EVENTATTR"].Value == System.DBNull.Value
                    || string.IsNullOrEmpty(dataGridView1.CurrentRow.Cells["EVENTATTR"].Value.ToString()))
                {
                    dataGridView1.CurrentRow.Cells["EVENTATTR"].Value = EventNames.YOUDAONUMBER;
                }
                else
                {
                    dataGridView1.CurrentRow.Cells["EVENTATTR"].Value = System.DBNull.Value;
                }
                btnSave.Enabled = true;
                btnRefresh.Enabled = true;
            }
        }

        private void lblYouDaoColor_DoubleClick(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                lblYouDaoColor.ForeColor = dialog.Color;
                ApplicationConfiguration.YouDaoColor = lblYouDaoColor.ForeColor;
                dataGridView1.Refresh();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.Rows.Count > 0 && dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.RowIndex >= 0)
            {
                if (Dialog.MessageBox("真的要删除当前所选记录吗？\r\n该操作不可恢复！", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, 0)
                    == DialogResult.Yes)
                {
                    Application.DoEvents();
                    if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
                    {
                        for (int i = dataGridView1.SelectedRows.Count - 1; i >= 0; i--)
                        {
                            dataGridView1.Rows.Remove(dataGridView1.SelectedRows[i]);
                        }
                    }
                    //else
                    //{
                    //    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                    //}
                    btnSave.Enabled = true;
                    btnRefresh.Enabled = true;
                    btnSave.PerformClick();
                }
            }
        }

        private void btnYouDao1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
            {
                for (int i = dataGridView1.SelectedRows.Count - 1; i >= 0; i--)
                {
                    if (dataGridView1.SelectedRows[i].Cells["EVENTATTR"].Value == null || dataGridView1.SelectedRows[i].Cells["EVENTATTR"].Value == System.DBNull.Value
                        || string.IsNullOrEmpty(dataGridView1.SelectedRows[i].Cells["EVENTATTR"].Value.ToString()))
                    {
                        dataGridView1.SelectedRows[i].Cells["EVENTATTR"].Value = EventNames.YOUDAONUMBER;
                    }
                    else
                    {
                        dataGridView1.SelectedRows[i].Cells["EVENTATTR"].Value = System.DBNull.Value;
                    }
                }
                btnSave.Enabled = true;
                btnRefresh.Enabled = true;
            }
            else
            {
                Dialog.MessageBox("请通过行头选择要操作的行！", 6);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckItems()) return;
                if (btnSave.Enabled)
                {
                    Save();
                }
                Parent.Controls.Remove(this);
                if (_dataChanged)
                {
                    RaiseDataChanged();
                }
            }
            catch
            {
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Parent.Controls.Remove(this);
        }

        private void ToolStripMenuItemChangeSpeed_Click(object sender, EventArgs e)
        {
            CopySpeedRow();
        }

        private void ToolStripMenuItemThick_Click(object sender, EventArgs e)
        {
            CopyConcentrationRow();
        }

        public void SetType(string typeName)
        {
            if (_anesthesiaEventDataTable != null)
            {
                string newTypeName = "全部";
                if (cmbTypes.SelectedIndex >= 0 && cmbTypes.Properties.Items[cmbTypes.SelectedIndex].ToString().Equals(typeName))
                {
                    newTypeName = typeName;
                }
                else
                {
                    for (int i = 0; i < cmbTypes.Properties.Items.Count; i++)
                    {
                        if (cmbTypes.Properties.Items[i].ToString().Equals(typeName))
                        {
                            cmbTypes.SelectedIndex = i;
                            newTypeName = typeName;
                            break;
                        }
                    }
                }
                if (newTypeName.Equals("全部"))
                {
                    _anesthesiaEventDataTable.DefaultView.RowFilter = "";
                    Column7.Visible = true;
                    Column8.Visible = true;
                    Column1.Visible = true;
                    Column9.Visible = true;
                    Column3.Visible = true;
                    Column10.Visible = true;
                    DosageUnit.Visible = true;
                    DURATIVE_INDICATOR.Visible = true;
                    EndDate.Visible = true;
                }
                else
                {
                    if (newTypeName.Equals("呼吸"))
                    {
                        //Modify by wenpei.x@2014-02-10
                        //呼吸的筛选不能以名称包含呼吸为准，需要过滤类别为9 A Y的麻醉事件
                        //_anesthesiaEventDataTable.DefaultView.RowFilter = "ITEM_NAME like '%呼吸%'";
                        _anesthesiaEventDataTable.DefaultView.RowFilter = "ITEM_CLASS ='9' OR ITEM_CLASS ='A' OR ITEM_CLASS ='Y'";
                    }
                    else
                    {
                        if (_eventNo == 2)
                        {
                            //_anesthesiaEventDataTable.DefaultView.RowFilter = "ITEM_CLASS = '" + Globals.CPBEventType[newTypeName] + "'";
                        }
                        else
                        {
                            _anesthesiaEventDataTable.DefaultView.RowFilter = "ITEM_CLASS = '" + EventTypeHelper.SwitchKeyValue[newTypeName] + "'";
                        }
                    }
                    switch (newTypeName)
                    {
                        case "输氧":
                        case "氧气":
                        //Column7.Visible = true;
                        //Column8.Visible = false;
                        //Column1.Visible = false;
                        //Column9.Visible = true;
                        //Column3.Visible = true;
                        //Column10.Visible = false;
                        //DosageUnit.Visible = false;
                        //DURATIVE_INDICATOR.Visible = true;
                        //EndDate.Visible = true;
                        //break;
                        case "输血":
                        case "输液":
                        case "出量":
                        case "诱导":
                        case "镇痛":
                        case "抗生素":
                        case "特殊材料":
                        //Column7.Visible = true;
                        //Column8.Visible = false;
                        //Column1.Visible = false;
                        //Column9.Visible = false;
                        //Column3.Visible = false;
                        //Column10.Visible = true;
                        //DosageUnit.Visible = true;
                        //DURATIVE_INDICATOR.Visible = false;
                        //EndDate.Visible = false;
                        //break;
                        case "麻药":
                        case "用药":
                        case "药剂":
                        case "输出":
                            Column7.Visible = true;
                            Column8.Visible = true;
                            Column1.Visible = true;
                            Column9.Visible = true;
                            Column3.Visible = true;
                            Column10.Visible = true;
                            DosageUnit.Visible = true;
                            DURATIVE_INDICATOR.Visible = true;
                            EndDate.Visible = true;
                            break;
                        case "呼吸":
                            Column7.Visible = false;
                            Column8.Visible = false;
                            Column1.Visible = false;
                            Column9.Visible = false;
                            Column3.Visible = false;
                            //Column10.Visible = false;
                            DURATIVE_INDICATOR.Visible = false;
                            break;
                        default:
                            Column7.Visible = false;
                            Column8.Visible = false;
                            Column1.Visible = false;
                            Column9.Visible = false;
                            Column3.Visible = false;
                            Column10.Visible = false;
                            //DosageUnit.Visible = false;
                            DURATIVE_INDICATOR.Visible = false;
                            //EndDate.Visible = false;
                            break;
                    }
                }
            }
        }

        private void cmbTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTypes.SelectedIndex >= 0 && _anesthesiaEventDataTable != null)
            {
                SetType(cmbTypes.Properties.Items[cmbTypes.SelectedIndex].ToString());
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            ToolStripMenuItemThick.Visible = false;
            ToolStripMenuItemChangeSpeed.Visible = false;
            toolStripMenuItemEmpty.Visible = false;
            toolStripMenuItem1Times.Visible = false;
            toolStripMenuItem2Times.Visible = false;
            toolStripMenuItem3Times.Visible = false;
            toolStripMenuItem4Times.Visible = false;
            toolStripMenuItem5Times.Visible = false;
            toolStripMenuItem6Times.Visible = false;
            ToolStripMenuItem分次.Visible = false;
            if (dataGridView1.Rows.Count > 0)
            {
                toolStripMenuItemEmpty.Visible = true;
                if (dataGridView1.CurrentRow != null)
                {
                    if (dataGridView1.CurrentRow.Cells["ItemType"].Value != null && dataGridView1.CurrentRow.Cells["ItemType"].Value != System.DBNull.Value
                        && dataGridView1.CurrentRow.Cells["EventName"].Value != null && dataGridView1.CurrentRow.Cells["EventName"].Value != System.DBNull.Value
                        && dataGridView1.CurrentRow.Cells["StartTime"].Value != null && dataGridView1.CurrentRow.Cells["StartTime"].Value != System.DBNull.Value)
                    {
                        if (dataGridView1.CurrentRow.Cells["Column8"].Value != null && dataGridView1.CurrentRow.Cells["Column8"].Value != System.DBNull.Value
                            && dataGridView1.CurrentRow.Cells["Column1"].Value != null && dataGridView1.CurrentRow.Cells["Column1"].Value != System.DBNull.Value)
                        {
                            ToolStripMenuItemThick.Visible = true;
                        }
                        if (dataGridView1.CurrentRow.Cells["Column9"].Value != null && dataGridView1.CurrentRow.Cells["Column9"].Value != System.DBNull.Value
                            && dataGridView1.CurrentRow.Cells["Column3"].Value != null && dataGridView1.CurrentRow.Cells["Column3"].Value != System.DBNull.Value)
                        {
                            ToolStripMenuItemChangeSpeed.Visible = true;
                        }
                    }
                    string anesClasses = EventTypeHelper.GetAnesClassTypeString(AnesClassType.Drug) + EventTypeHelper.GetAnesClassTypeString(AnesClassType.AnesDrug);
                    if (dataGridView1.CurrentRow.Cells["EventName"].Value != null && dataGridView1.CurrentRow.Cells["EventName"].Value != System.DBNull.Value
                        && dataGridView1.CurrentRow.Cells["ItemType"].Value != null && dataGridView1.CurrentRow.Cells["ItemType"].Value != System.DBNull.Value
                        && anesClasses.Contains(dataGridView1.CurrentRow.Cells["ItemType"].Value.ToString().Trim()))
                    {
                        //toolStripMenuItem1Times.Visible = true;
                        //toolStripMenuItem2Times.Visible = true;
                        //toolStripMenuItem3Times.Visible = true;
                        //toolStripMenuItem4Times.Visible = true;
                        //toolStripMenuItem5Times.Visible = true;
                        //toolStripMenuItem6Times.Visible = true;
                        //ToolStripMenuItem分次.Visible = true;
                    }
                }
            }
        }

        private void ToolStripMenuItem分次_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem分次.Checked = !ToolStripMenuItem分次.Checked;
            SetTimes();
        }

        private void SetTimes()
        {
            string text = "";
            if (dataGridView1.CurrentRow.Cells["EVENTATTR"].Value != null && dataGridView1.CurrentRow.Cells["EVENTATTR"].Value != System.DBNull.Value)
            {
                text = dataGridView1.CurrentRow.Cells["EVENTATTR"].Value.ToString().Trim();
            }
            text = text.Replace("分次", "");
            SetTimes(text);
        }

        private void SetTimes(string text)
        {
            if (ToolStripMenuItem分次.Checked)
            {
                dataGridView1.CurrentRow.Cells["EVENTATTR"].Value = text.Replace("×1", "") + "分次";
            }
            else
            {
                dataGridView1.CurrentRow.Cells["EVENTATTR"].Value = text.Replace("×1", "");
            }
            dataGridView1.Invalidate();
        }

        private void toolStripMenuItem2Times_Click(object sender, EventArgs e)
        {
            SetTimes((sender as ToolStripItem).Text);
        }

        Dict.AnesthesiaEventTempletDataTable _anesthesiaEventTemplet;
        private void btnApplyModel_Click(object sender, EventArgs e)
        {
            EventTemplet view = new EventTemplet(_eventNo);
            DialogHostForm dialogHostForm = new DialogHostForm("套用模板", view.Width + 110, view.Height);
            dialogHostForm.Child = view;
            dialogHostForm.ShowDialog();
            object result = view.DialogResultData;
            if (result != null)
            {
                EventTempletDetail templet = (EventTempletDetail)result;
                _anesthesiaEventTemplet = DictProxy.GetAnesthesiaEventTemplet(templet.Name);
                if (_anesthesiaEventDataTable == null)
                {
                    _anesthesiaEventDataTable = new AnesInformations.AnesthesiaEventDataTable();
                }
                foreach (Dict.AnesthesiaEventTempletRow row in _anesthesiaEventTemplet.Rows)
                {
                    if (!templet.IsApplyDosage)
                    {
                        row.SetDOSAGENull();
                    }

                    //Add By chengying.x @20140213
                    double d = row.IsSTART_AFTER_INPUTNull() ? 0 : double.Parse(row.START_AFTER_INPUT.ToString());

                    decimal dDurative = row.IsDURATIVENull() ? 0 : row.DURATIVE;   // 持续(分钟)
                    AddRow(row, templet.StartTime.AddMinutes(d), dDurative);
                    //End Add
                    //AddRow(row);
                }
            }
        }

        private void btnSaveModel_Click(object sender, EventArgs e)
        {
            if (!CheckItems())
            {
                return;
            }
            if (_anesthesiaEventDataTable != null && _anesthesiaEventDataTable.Count > 0)
            {
                if (_eventNo == 1)
                {
                    foreach (AnesInformations.AnesthesiaEventRow row in _anesthesiaEventDataTable)
                    {
                        if (row.ITEM_NO < 500) row.ITEM_NO += 500;
                    }
                }
                SetNewEventTemplet view = new SetNewEventTemplet();
                DialogHostForm dialogHostForm = new DialogHostForm("保存模板", view.Width + 90, view.Height + 30);
                dialogHostForm.Child = view;
                dialogHostForm.ShowDialog();
                object result = view.DialogResultData;
                if (result != null)
                {
                    EventTempletDetail templet = (EventTempletDetail)result;
                    _anesthesiaEventTemplet = DictProxy.GetAnesthesiaEventTemplet(templet.Name);
                    //Add By chengying.x @20140213
                    DateTime topEventTime = DateTime.MinValue;
                    if (_anesthesiaEventDataTable.Count > 0)
                    {
                        //计算最小开始时间
                        topEventTime = _anesthesiaEventDataTable[0].START_DATE_TIME;
                        foreach (AnesInformations.AnesthesiaEventRow eventRow1 in _anesthesiaEventDataTable.Rows)
                        {
                            if (!string.IsNullOrEmpty(eventRow1.START_DATE_TIME.ToString()) && (topEventTime >= eventRow1.START_DATE_TIME)) topEventTime = eventRow1.START_DATE_TIME;
                        }
                    }
                    //End Add
                    foreach (AnesInformations.AnesthesiaEventRow eventRow in _anesthesiaEventDataTable.Rows)
                    {
                        Dict.AnesthesiaEventTempletRow row = _anesthesiaEventTemplet.NewAnesthesiaEventTempletRow();
                        row.TEMPLET_CLASS = _eventNo.ToString();
                        row.ANES_METHOD = string.IsNullOrEmpty(templet.AnesMethod.Trim()) ? "通用" : templet.AnesMethod.Trim();
                        row.TEMPLET = templet.Name;
                        row.ITEM_CLASS = eventRow.ITEM_CLASS;
                        row.ITEM_NO = eventRow.ITEM_NO;
                        row.ITEM_NAME = eventRow.ITEM_NAME;

                        if (!eventRow.IsITEM_CODENull())
                        {
                            row.ITEM_CODE = eventRow.ITEM_CODE;
                        }
                        if (!eventRow.IsITEM_SPECNull())
                        {
                            row.ITEM_SPEC = eventRow.ITEM_SPEC;
                        }
                        if (!eventRow.IsCONCENTRATIONNull())
                        {
                            row.CONCENTRATION = eventRow.CONCENTRATION;
                        }
                        if (!eventRow.IsPERFORM_SPEEDNull())
                        {
                            row.PERFORM_SPEED = eventRow.PERFORM_SPEED;
                        }
                        if (!eventRow.IsSPEED_UNITSNull())
                        {
                            row.SPEED_UNITS = eventRow.SPEED_UNITS;
                        }
                        if (!eventRow.IsDOSAGENull())
                        {
                            row.DOSAGE = eventRow.DOSAGE;
                        }
                        if (!eventRow.IsDOSAGE_UNITSNull())
                        {
                            row.DOSAGE_UNITS = eventRow.DOSAGE_UNITS;
                        }
                        if (!eventRow.IsADMINISTRATORNull())
                        {
                            row.ADMINISTRATOR = eventRow.ADMINISTRATOR;
                        }
                        if (!eventRow.IsDURATIVE_INDICATORNull())
                        {
                            row.DURATIVE_INDICATOR = eventRow.DURATIVE_INDICATOR;
                        }
                        if (!eventRow.IsMETHODNull())
                        {
                            row.METHOD = eventRow.METHOD;
                        }
                        if (!eventRow.IsEVENT_ATTRNull())
                        {
                            row.EVENT_ATTR = eventRow.EVENT_ATTR;
                        }
                        if (!eventRow.IsCONCENTRATION_UNITSNull())
                        {
                            row.CONCENTRATION_UNITS = eventRow.CONCENTRATION_UNITS;
                        }
                        if (!eventRow.IsBILL_ATTRNull())
                        {
                            row.BILL_ATTR = eventRow.BILL_ATTR;
                        }

                        //Add By chengying.x @20140213 
                        if (!eventRow.IsDURATIVENull())
                        {
                            row.DURATIVE = decimal.Parse(eventRow.DURATIVE);
                        }
                        row.START_AFTER_INPUT = 0;
                        if (topEventTime != DateTime.MinValue)
                        {
                            row.START_AFTER_INPUT = (decimal)((int)(eventRow.START_DATE_TIME - topEventTime).TotalMinutes);
                        }
                        //End Add
                        row.CREATE_BY = templet.Owner;
                        _anesthesiaEventTemplet.AddAnesthesiaEventTempletRow(row);
                    }
                    if (DictProxy.UpdateAnesthesiaEventTemplet(_anesthesiaEventTemplet) > 0)
                    {
                        Dialog.MessageBox("模板保存成功！");
                    }
                }
            }
            else
            {
                Dialog.MessageBox("麻醉事件为空无法保存模板！");
            }
        }
        #endregion 控件事件

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                _anesthesiaEventDataTable.DefaultView.RowFilter = "ITEM_NAME like '%" + textBox1.Text + "%'";
            }
            textBox1.Visible = false;
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            foreach (AnesInformations.AnesthesiaEventRow row in _anesthesiaEventDataTable)
            {
                if (!row.IsITEM_NAMENull() && !list.Contains(row.ITEM_NAME))
                {
                    list.Add(row.ITEM_NAME);
                }
            }
            Dialog.ShowCustomSelection(list, "", textBox1, new Size(300, 300), delegate (object s1, EventArgs e1)
            {
                if (s1 is int)
                {
                    int index = (int)s1;
                    textBox1.Text = list[index];
                }
            });
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                Color colr = Color.White;
                if (i == e.RowIndex)
                {
                    colr = Color.DeepSkyBlue;
                }
                dataGridView1.Rows[i].DefaultCellStyle.BackColor = colr;

            }
        }

        private void dataGridView1_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            
        }
    }
}
