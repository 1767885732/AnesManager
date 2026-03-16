using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework;
using Wis.Anes.BusinessEntity;
using Wis.Anes.ServiceProxies;
using Wis.Anes.Framework.Configurations;

namespace Wis.Anes.Views
{
    [ToolboxItem(false)]
    public partial class OperationRoomContent : UserControl
    {
        public OperationRoomContent(bool canSelect)
        {
            _canSelect = canSelect;
            InitializeComponent();
        }

        private bool _canSelect = false;
        public bool NeedAlarm = false;////是否需要 报警
        public bool HasViewAlarm = false; //是否已查看过 报警
        public int IndexKey = 0;
        public string OperRoomNo = "";
        public string OperRoomKey = "";
        public string AnesDoctor = "";
        public string OperDoctor = "";
        public string OperDate = "";
        public string PatientID = "";
        public string PID = "";
        public decimal VisitID = 0;
        public decimal OperID = 0;
        public string PatientName = "";
        public string OperStatus = "";
        public decimal OperStatusValue = -1;
        public string OperName = "";
        public string BedNo = "";
        public DateTime ScheduleDateTime = DateTime.Now;

        public string BedType = "0";

        
        private void OperationRoomContent_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            lbRoomNo.Parent = picMain;
            lbAnesDoctor.Parent = picMain;
            lbOperDoctor.Parent = picMain;
            lbOperDate.Parent = picMain;
            lbPatientID.Parent = picMain;
            lbPatientName.Parent = picMain;
            lbOperStatus.Parent = picMain;
            this.lbOperName.Parent = picMain;
            //RefreshValue();
            InitPopupMenu();
        }

        private ContextMenuStrip _popupMenu = null;
        private void InitPopupMenu()
        {
            _popupMenu = new ContextMenuStrip();
            ToolStripItem item1 = _popupMenu.Items.Add("出复苏室");
            item1.Click += new EventHandler(item1_Click);
            item1.Visible = false;
            ToolStripItem item2 = _popupMenu.Items.Add("取消入复苏室");//"回到准备手术");
            item2.Click += new EventHandler(item2_Click);
        }

        /// <summary>
        ///清除患者手术间安排
        /// </summary>
        /// <param name="patientID"></param>
        private bool ClearPatientRoom(string patientID)
        {
            bool result = false;
            Dict.OperatingRoomDataTable operatingRoomDataTable = DictProxy.GetOperatingRoomDict();
            if (operatingRoomDataTable != null)
            {
                foreach (Dict.OperatingRoomRow row in operatingRoomDataTable)
                {
                    if (!row.IsPAT_IDNull() && row.PAT_ID.Equals(patientID))
                    {
                        row.SetPAT_IDNull();
                        row.SetVISIT_IDNull();
                        row.SetOPER_IDNull();
                    }
                }
                int ret = DictProxy.UpdateOperatingRoomDict(operatingRoomDataTable);
                if (ret > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        ///清除患者设备安排
        /// </summary>
        /// <param name="patientID"></param>
        private bool ClearPatientMonitor(string patientID, decimal eventNo)
        {
            bool result = false;
            Dict.MonitorDictDataTable monitorTable = DictProxy.GetMonitorDict(eventNo);
            if (monitorTable != null)
            {
                foreach (Dict.MonitorDictRow row in monitorTable)
                {
                    if (!row.IsPAT_IDNull() && row.PAT_ID.Equals(patientID))
                    {
                        row.SetPAT_IDNull();
                        row.SetVISIT_IDNull();
                        row.SetOPER_IDNull();
                        if (eventNo == 0)
                        {
                            row.SetBED_NONull();
                        }
                    }
                }
                int ret = DictProxy.UpdateMonitorDict(monitorTable);
                if (ret > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        private bool UpdateOperationStatusOrStatusTime(OperationStatus operationStatus, DateTime? dt, bool updateStatus
            , OperationStatus oldOperationStatus, string patientID, decimal visitID, decimal operID, string bedNo)
        {
            AnesInformations.OperationMasterDataTable dataTable = AnesthesiaSheetProxy.GetOperationMaster(patientID, visitID, operID);
            if (dataTable != null && dataTable.Count == 1)
            {
                if (updateStatus)
                {
                    ///取消诱导室采集
                    if ((oldOperationStatus == OperationStatus.InYouDao) || (oldOperationStatus == OperationStatus.InPACU))
                    {
                        ClearPatientRoom(patientID);
                        ClearPatientMonitor(patientID, 1);

                        ///取消诱导室采集
                        ClearPatientMonitor(patientID, 0);
                    }
                    else if (operationStatus != OperationStatus.InOperationRoom && operationStatus != OperationStatus.AnesthesiaStart
                        && operationStatus != OperationStatus.OperationStart && operationStatus != OperationStatus.AnesthesiaEnd
                        && operationStatus != OperationStatus.OperationEnd && operationStatus != OperationStatus.InPACU)
                    {
                        ClearPatientRoom(patientID);
                        ClearPatientMonitor(patientID, 0);
                    }
                    if (operationStatus == OperationStatus.InYouDao || operationStatus == OperationStatus.InPACU)
                    {
                        string roomNo = "";
                        Dict.OperatingRoomDataTable operatingRoomDataTable = DictProxy.GetOperatingRoomDict();
                        if (operatingRoomDataTable != null)
                        {
                            List<string> bedNos = new List<string>();
                            foreach (Dict.OperatingRoomRow row in operatingRoomDataTable)
                            {
                                if (!row.IsBED_TYPENull() && (row.BED_TYPE.Equals("1") || row.BED_TYPE.Equals("3")))// 诱导部分也要取
                                {
                                    bedNos.Add(row.ROOM_NO);
                                }
                            }
                            if (bedNos.Count > 0)
                            {
                                //object bedNo = Dialog.SingleInputSelect("请选择床号", bedNos.ToArray());
                                //if (bedNo != null)
                                //{
                                //    roomNo = bedNo.ToString();
                                //}
                                //roomNo = bedNo;




                           
                                OperationRoomPandect operationRoomPandect = new OperationRoomPandect(1, true);
                                Wis.Anes.Layouts.DialogHostForm dialogHostForm = new Wis.Anes.Layouts.DialogHostForm("选择床位 - 双击空床位完成选择", 500, 500);
                                dialogHostForm.Child = operationRoomPandect;
                                dialogHostForm.ShowDialog();
                                if (operationRoomPandect.SelectedOperationRoomContent != null)
                                {
                                    roomNo = operationRoomPandect.SelectedOperationRoomContent.OperRoomKey;
                                }
                            }
                        }
                        if (string.IsNullOrEmpty(roomNo))
                        {
                            return false;
                        }
                        else
                        {
                            DictProxy.SetOperatingRoomPatient(operatingRoomDataTable, roomNo, ApplicationConfiguration.OpertionDeptCode, patientID
                                , visitID, operID);
                            DictProxy.UpdateOperatingRoomDict(operatingRoomDataTable);
                            DictProxy.SetMonitorDictPatient(1, ApplicationConfiguration.OpertionDeptCode, roomNo, patientID, visitID, operID);
                        }
                    }
                    else if (operationStatus == OperationStatus.InOperationRoom)
                    {
                        string roomNo = "";
                        Dict.OperatingRoomDataTable operatingRoomDataTable = DictProxy.GetOperatingRoomDict();
                        if (operatingRoomDataTable != null)
                        {
                            //roomNo = ActionFactory.PatientInformation.OperRoom;
                        }
                        if (string.IsNullOrEmpty(roomNo))
                        {
                            if (ApplicationConfiguration.UseDefaultOperatingRoom && !string.IsNullOrEmpty(ApplicationConfiguration.OpertionRoom) && !ApplicationConfiguration.OpertionRoom.Contains(","))
                            {
                                int ret = 0;
                                AnesInformations.OperationMasterDataTable operationMaster = AnesthesiaSheetProxy.GetOperationMaster(patientID, visitID, operID);
                                if (operationMaster != null && operationMaster.Count == 1)
                                {
                                    operationMaster[0].OPERATING_ROOM_NO = ApplicationConfiguration.OpertionRoom;
                                    ret = AnesthesiaSheetProxy.UpdateOperationMaster(operationMaster);
                                }
                                if (ret <= 0)
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (ApplicationConfiguration.UseDefaultOperatingRoom && !string.IsNullOrEmpty(ApplicationConfiguration.OpertionRoom) && !ApplicationConfiguration.OpertionRoom.Contains(",") && ! ApplicationConfiguration.OpertionRoom.Equals(roomNo))
                            {
                                //if (Dialog.MessageBox("要把当前患者从 " + roomNo + "号间转到" + Configurations.OpertionRoom + "号间吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                //{
                                //    return false;
                                //}
                                int ret = 0;
                                AnesInformations.OperationMasterDataTable operationMaster = AnesthesiaSheetProxy.GetOperationMaster(patientID, visitID, operID);
                                if (operationMaster != null && operationMaster.Count == 1)
                                {
                                    operationMaster[0].OPERATING_ROOM_NO = ApplicationConfiguration.OpertionRoom;
                                    ret = AnesthesiaSheetProxy.UpdateOperationMaster(operationMaster);
                                }
                                if (ret <= 0)
                                {
                                    return false;
                                }
                                else
                                {
                                    //ActionFactory.PatientInformation.OperRoom = Configurations.OpertionRoom;
                                    //lblRoomNo.Text = Globals.PatientInformation.OperRoom;
                                    //ActionFactory.MainFormBase.RefreshPatInfo();
                                }
                            }
                            DictProxy.SetOperatingRoomPatient(operatingRoomDataTable, roomNo, ApplicationConfiguration.OpertionDeptCode, patientID, visitID, operID);
                            DictProxy.UpdateOperatingRoomDict(operatingRoomDataTable);
                        }
                    }
                    dataTable[0].OPER_STATUS = (decimal)(int)operationStatus;
                }
                string fieldName = OperationStatusHelper.GetTimeFieldName(operationStatus);
                if (dt != null && !string.IsNullOrEmpty(fieldName))
                {
                    dataTable[0][fieldName] = dt;
                }
                int result = AnesthesiaSheetProxy.UpdateOperationMaster(dataTable);
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }

        private void item2_Click(object sender, EventArgs e)
        {
            UpdateOperationStatusOrStatusTime(OperationStatus.TurnToPACU, ScheduleDateTime, true, OperationStatus.InYouDao
                , PID, VisitID, OperID, BedNo);
            EventHandler eventHandle = Events[_statusChanged] as EventHandler;
            if (eventHandle != null)
            {
                eventHandle(this, null);
            }
        }

        private void item1_Click(object sender, EventArgs e)
        {
            UpdateOperationStatusOrStatusTime(OperationStatus.TurnToPACU, DateTime.Now, true, OperationStatus.InYouDao
                , PID, VisitID, OperID, BedNo);
            EventHandler eventHandle = Events[_statusChanged] as EventHandler;
            if (eventHandle != null)
            {
                eventHandle(this, null);
            }
        }
        public void Alarm()
        {
            if (NeedAlarm)
            {
                if (HasViewAlarm)
                {
                    lbRoomNo.BackColor = Color.Yellow;

                }
                else
                {
                    lbRoomNo.BackColor = Color.Red;
                }
            }
        }
        public void RefreshValue()
        {
            this.lbRoomNo.Text = OperRoomNo;
            lbAnesDoctor.Text = AnesDoctor;
            lbOperDoctor.Text = OperDoctor;
            lbOperDate.Text = OperDate;
            lbPatientID.Text = PatientID;
            lbPatientName.Text = PatientName;
            lbOperStatus.Text = OperStatus;
            if (OperStatus.Contains("手术"))
            {
                lbOperStatus.ForeColor = Color.Yellow;
            }
            else if (OperStatus.Contains("麻醉") || OperStatus.Contains("准备") || OperStatus.Contains("诱导"))
            {
                lbOperStatus.ForeColor = Color.Red;
            }
            else
            {
                lbOperStatus.ForeColor = Color.Black;
            }
            this.lbOperName.Text = OperName;
            //if (_canSelect || string.IsNullOrEmpty(PID) || !(((OperationStatus)(int)OperStatusValue) == OperationStatus.InYouDao || ((OperationStatus)(int)OperStatusValue) == OperationStatus.InPACU))
            //if (string.IsNullOrEmpty(PID) || !(((OperationStatus)(int)OperStatusValue) == OperationStatus.InYouDao || ((OperationStatus)(int)OperStatusValue) == OperationStatus.InPACU|| ((OperationStatus)(int)OperStatusValue) == OperationStatus.TurnToPACU))
            //{
            //    //SetPopupMenu(null);
            //}
            //else
            //{
            //    //SetPopupMenu(_popupMenu);
            //}
            if ((_canSelect && string.IsNullOrEmpty(PID)) || (!_canSelect && !string.IsNullOrEmpty(PID)))
            {
                Cursor = Cursors.Hand;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        private void lbRoomNo_Click(object sender, EventArgs e)
        {

        }

        public void SetPopupMenu(ContextMenuStrip popupMenu)
        {
            lbAnesDoctor.ContextMenuStrip = popupMenu;
            lbOperDate.ContextMenuStrip = popupMenu;
            lbOperDoctor.ContextMenuStrip = popupMenu;
            lbOperName.ContextMenuStrip = popupMenu;
            lbOperStatus.ContextMenuStrip = popupMenu;
            lbPatientID.ContextMenuStrip = popupMenu;
            lbPatientName.ContextMenuStrip = popupMenu;
            lbRoomNo.ContextMenuStrip = popupMenu;
            picMain.ContextMenuStrip = popupMenu;
        }

        private readonly static object _doubleClickEventHandle = new object();
        public event EventHandler DoDoubleClick
        {
            add
            {
                Events.AddHandler(_doubleClickEventHandle, value);
            }
            remove
            {
                Events.RemoveHandler(_doubleClickEventHandle, value);
            }
        }

        private readonly static object _statusChanged = new object();
        public event EventHandler StatusChanged
        {
            add
            {
                Events.AddHandler(_statusChanged, value);
            }
            remove
            {
                Events.RemoveHandler(_statusChanged, value);
            }
        }

        private void RaiseDoubleClick()
        {
            EventHandler eventHandle = Events[_doubleClickEventHandle] as EventHandler;
            if (eventHandle != null)
            {
                eventHandle(this, null);
            }
        }

        private void ControlClick(object sender, EventArgs e)
        {
            this.Focus();
            RaiseDoubleClick();
        }

        private void lbOperStatus_Click(object sender, EventArgs e)
        {

        }

        public bool Selected
        {
            set
            {
                if (value)
                {
                    lbRoomNo.ForeColor = Color.OrangeRed;
                }
                else
                {
                    lbRoomNo.ForeColor = Color.Black;
                }
            }
        }
        
    }
}
