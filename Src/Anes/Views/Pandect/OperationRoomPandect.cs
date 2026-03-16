using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.ServiceProxies;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework;
using Wis.Anes.Framework.Views;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.Framework.Documents;
using Wis.Anes.Layouts;
using DevExpress.XtraEditors;
using Wis.Anes.Constants;


namespace Wis.Anes.Views
{
    /// <summary>
    /// 手术间(复苏室床位)概览
    /// </summary>
    [ToolboxItem(false)]
    public partial class OperationRoomPandect : BaseView
    {
        int colCount = 6;
        int rowCount = 4;
        int _bedType = 0;
        public int OrginWidth = 900;
        XtraScrollableControl _c;

        List<OperationRoomContent> OperationRoomContentList = new List<OperationRoomContent>();
        Dict.HisUserDataTable _doctorTable = null;

        private Dict.WisPatMonitorDataDictDataTable patMonitorDataDictDataTable = new Dict.WisPatMonitorDataDictDataTable();
        public OperationRoomPandect() : this(0) { }
        public OperationRoomPandect(int bedType) : this(bedType, false) { }

        protected bool isInitial = false;
        public bool NeedAlarm = true;

        public OperationRoomPandect(int bedType, bool canSelect)
        {
            _canSelect = canSelect;
            _bedType = bedType;



            if (ApplicationConfiguration.IsYouDaoProgram)
            {
                _bedType = 3;
            }


            InitializeComponent();

            _c = new XtraScrollableControl();
            this.Controls.Remove(this.medPanelMain);
            _c.Controls.Add(this.medPanelMain);
            _c.AutoScroll = true;
            this.Controls.Add(_c);
            _c.Dock = DockStyle.Fill;
            this.medPanelMain.Dock = DockStyle.Top;
            //this.medPanelMain.Height = 1500;
            medPanelMain.AutoSize = true;
        }


        public void Initial()
        {
            _doctorTable = DictProxy.GetHisUsers();
            InitOperationRoomContentList();
            GetOperationForOperationRoom();
            isInitial = true;


            Caption = ViewNames.PacuBed;

        }

        private void OperationRoomPandect_Load(object sender, EventArgs e)
        {
            if (!isInitial)
                Initial();

            if (NeedAlarm)
            {
                patMonitorDataDictDataTable = DictProxy.GetPatMonitorDataDict();

                PatientAlarm();
            }
        }
        public string Order(object no)
        {
            string defaultOrder = "00000";

            if (no == null)
                return defaultOrder;

            if (string.IsNullOrEmpty(no.ToString()))
                return defaultOrder;

            if (no.ToString().Length <= 5)
            {
                string zeroString = "";
                for (int i = 1; i < 5 - no.ToString().Length; i++)
                {
                    zeroString += "0";
                }

                defaultOrder = zeroString + no.ToString();
            }

            return defaultOrder;
        }
        public void InitOperationRoomContentList()
        {
            Dict.OperatingRoomDataTable rooms = DictProxy.GetOperatingRoomDict();
            DataRow[] operationRoom = (_bedType == 1) ? rooms.Select("BED_TYPE = '" + _bedType.ToString() + "'", "BED_TYPE,BED_ID") : rooms.Select("BED_TYPE = '1' OR BED_TYPE = '0'", "BED_TYPE,BED_ID");
            //Add @2014-02-07，新增诱导床位筛选
            if (_bedType == 3)
                operationRoom = rooms.Select("BED_TYPE = '" + _bedType.ToString() + "'", "BED_TYPE,BED_ID");
            //End Add
            List<DataRow> operationRoomList = new List<DataRow>();

            for (int i = 0; i < operationRoom.Length; i++)
            {
                operationRoomList.Add(operationRoom[i]);
            }

            //2014-5-30 周青 content 排序方式有问题 故注释
            //operationRoomList.Sort(new Comparison<DataRow>(delegate(DataRow dataRow1, DataRow dataRow2)
            //{

            //    object roomNo1 = dataRow1["ROOM_NO"];
            //    object roomNo2 = dataRow2["ROOM_NO"];
            //    return Order(roomNo1).CompareTo(Order(roomNo2));
            //}));

            operationRoom = operationRoomList.ToArray();


            for (int i = 0; i < operationRoom.Length; i++)
            {
                OperationRoomContent operRoomContent = new OperationRoomContent(_canSelect);
                operRoomContent.IndexKey = i + 1;
                operRoomContent.OperRoomNo = operationRoom[i]["BED_LABEL"].ToString();
                operRoomContent.OperRoomKey = operationRoom[i]["ROOM_NO"].ToString();
                operRoomContent.BedType = operationRoom[i]["BED_TYPE"].ToString();
                //Add By xiasen.x@2014-02-07，手术间内容中新增病人的三个ID，方便诱导室床位进行病人信息匹配
                operRoomContent.PatientID = operationRoom[i]["PAT_ID"].ToString();
                operRoomContent.VisitID = !string.IsNullOrEmpty(operationRoom[i]["VISIT_ID"].ToString()) ? decimal.Parse(operationRoom[i]["VISIT_ID"].ToString()) : 0;
                operRoomContent.OperID = !string.IsNullOrEmpty(operationRoom[i]["OPER_ID"].ToString()) ? decimal.Parse(operationRoom[i]["OPER_ID"].ToString()) : 0;
                //End Add
                OperationRoomContentList.Add(operRoomContent);
            }
            int contentWidth = 0;
            int contentHeight = 0;

            if (OperationRoomContentList.Count > 0)
            {
                contentWidth = OperationRoomContentList[0].Width;
                contentHeight = OperationRoomContentList[0].Height;
            }

            int useWidth = this.Width < OrginWidth ? OrginWidth : this.Width;
            while (colCount * contentWidth >= useWidth)
            {
                colCount--;
            }
            if (colCount <= 0)
                return;
            if (OperationRoomContentList.Count % colCount > 0)
            {
                rowCount = OperationRoomContentList.Count / colCount + 1;
            }
            else
            {
                rowCount = OperationRoomContentList.Count / colCount;
            }

            int offX = (useWidth - colCount * contentWidth) / (colCount - 1 + 3) - 5;
            int offY = 5;

            OperationRoomContent operationRoomContent = null;
            int index = 0;
            //排序
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    index = (i * colCount) + j;
                    if (index >= OperationRoomContentList.Count)
                        break;
                    operationRoomContent = OperationRoomContentList[index];
                    operationRoomContent.Left = offX * (j + 1) + contentWidth * j;
                    operationRoomContent.Top = offY * (i + 1) + contentHeight * i;
                    operationRoomContent.Visible = true;
                    operationRoomContent.DoDoubleClick += new EventHandler(operationRoomContent_DoubleClick);
                    operationRoomContent.StatusChanged += new EventHandler(operationRoomContent_StatusChanged);
                }

            }
            // _c.Controls.AddRange(OperationRoomContentList.ToArray());
            medPanelMain.Controls.AddRange(OperationRoomContentList.ToArray());

        }

        private bool _changed = false;
        public bool Changed
        {
            get
            {
                return _changed;
            }
        }

        private void operationRoomContent_StatusChanged(object sender, EventArgs e)
        {
            GetPacuInfo();
            _changed = true;
        }

        private bool _canSelect = false;
        private OperationRoomContent _selectedOperationRoomContent = null;
        public OperationRoomContent SelectedOperationRoomContent
        {
            get
            {
                return _selectedOperationRoomContent;
            }
        }


        public event EventHandler PatientSelected;

        public void FirePatientSelectedEvent()
        {
            if (PatientSelected != null)
                PatientSelected(null, EventArgs.Empty);
        }


        private void operationRoomContent_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                OperationRoomContent operationRoomContent = sender as OperationRoomContent;
                operationRoomContent.HasViewAlarm = false;

                if (ExtendApplicationContext.Current.AppType == ApplicationType.Anesthesia)
                {

                    if (operationRoomContent != null)
                    {
                        if (_canSelect && string.IsNullOrEmpty(operationRoomContent.PID))
                        {
                            _selectedOperationRoomContent = operationRoomContent;
                            if (ParentForm != null)
                            {
                                ParentForm.DialogResult = DialogResult.OK;
                            }
                        }
                        else if (!_canSelect && !string.IsNullOrEmpty(operationRoomContent.PID))
                        {
                            //双击选中，全局变量赋值
                            PatientInformation patientInformation = new PatientInformation(operationRoomContent.PID,
                                operationRoomContent.VisitID, operationRoomContent.OperID, operationRoomContent.OperStatusValue, operationRoomContent.PatientName, operationRoomContent.OperRoomNo,
                                operationRoomContent.BedNo, "", 0, 0);
                            if (patientInformation != null)
                            {

                                ExtendApplicationContext.Current.PatientContext.PatientID = patientInformation.PatientID;
                                ExtendApplicationContext.Current.PatientContext.VisitID = patientInformation.VisitID;
                                ExtendApplicationContext.Current.PatientContext.OperID = patientInformation.OperID;
                            }
                            else
                            {
                                ExtendApplicationContext.Current.PatientContext.PatientID = "";
                            }
                            ExtendApplicationContext.Current.PatientInformation = patientInformation;

                            FirePatientSelectedEvent();
                            //ShowPatientDoc("麻醉单", operationRoomContent);
                            //operationRoomContent.HasViewAlarm = true;
                            //operationRoomContent.Alarm();
                            //if (ParentForm != null)
                            //{
                            //    ParentForm.DialogResult = DialogResult.OK;
                            //}
                        }
                    }
                }
                else if (ExtendApplicationContext.Current.AppType == ApplicationType.PACU || ExtendApplicationContext.Current.AppType == ApplicationType.YouDao)
                {


                    if (operationRoomContent != null)
                    {
                        if (_canSelect && string.IsNullOrEmpty(operationRoomContent.PID))
                        {
                            _selectedOperationRoomContent = operationRoomContent;
                            if (ParentForm != null)
                            {
                                ParentForm.DialogResult = DialogResult.OK;
                            }
                        }
                        else if (!_canSelect && !string.IsNullOrEmpty(operationRoomContent.PID))
                        {
                            //ShowPatientDoc("复苏单", operationRoomContent);

                            //双击选中，全局变量赋值
                            PatientInformation patientInformation = new PatientInformation(operationRoomContent.PID,
                                operationRoomContent.VisitID, operationRoomContent.OperID, operationRoomContent.OperStatusValue, operationRoomContent.PatientName, operationRoomContent.OperRoomNo,
                                operationRoomContent.BedNo, "", 0, 0);
                            if (patientInformation != null)
                            {

                                ExtendApplicationContext.Current.PatientContext.PatientID = patientInformation.PatientID;
                                ExtendApplicationContext.Current.PatientContext.VisitID = patientInformation.VisitID;
                                ExtendApplicationContext.Current.PatientContext.OperID = patientInformation.OperID;
                            }
                            else
                            {
                                ExtendApplicationContext.Current.PatientContext.PatientID = "";
                            }
                            ExtendApplicationContext.Current.PatientInformation = patientInformation;

                            FirePatientSelectedEvent();

                            //if (ParentForm != null)
                            //{
                            //    ParentForm.DialogResult = DialogResult.OK;
                            //}
                        }
                    }



                }

                RefreshSelect();
            }
            catch (Exception err)
            {
                ExceptionHandler.Handle(err);
            }
        }

        private void ShowPatientDoc(string docName, OperationRoomContent operationRoomContent)
        {
            Dictionary<string, MedicalDocElement> docs = MedicalDocSettings.GetMedicalDocNameAndPath();

            KeyValuePair<string, MedicalDocElement> keyValuePairDoc = new KeyValuePair<string, MedicalDocElement>();

            foreach (KeyValuePair<string, MedicalDocElement> keyValuePair in docs)
            {
                if (keyValuePair.Key.Trim() == docName.Trim())
                {
                    keyValuePairDoc = keyValuePair;
                    break;
                }
            }
            string pid = ExtendApplicationContext.Current.PatientContext.PatientID;
            decimal vid = ExtendApplicationContext.Current.PatientContext.VisitID;
            decimal oid = ExtendApplicationContext.Current.PatientContext.OperID;
            try
            {
                Type t = Type.GetType(keyValuePairDoc.Value.Type);
                ExtendApplicationContext.Current.PatientContext.PatientID = operationRoomContent.PID;
                ExtendApplicationContext.Current.PatientContext.VisitID = operationRoomContent.VisitID;
                ExtendApplicationContext.Current.PatientContext.OperID = operationRoomContent.OperID;
                BaseDoc baseDoc = Activator.CreateInstance(t) as BaseDoc;
                baseDoc.BackColor = Color.White;

                baseDoc.LoadReport(ExtendApplicationContext.Current.AppPath + keyValuePairDoc.Value.Path);
                DialogHostForm dialogHostForm = new DialogHostForm(docName, 1280, 768);
                dialogHostForm.Child = baseDoc;
                ExtendApplicationContext.Current.PatientContext.PatientID = pid;
                ExtendApplicationContext.Current.PatientContext.VisitID = vid;
                ExtendApplicationContext.Current.PatientContext.OperID = oid;

                dialogHostForm.ShowDialog();
            }
            catch
            {
                ExtendApplicationContext.Current.PatientContext.PatientID = pid;
                ExtendApplicationContext.Current.PatientContext.VisitID = vid;
                ExtendApplicationContext.Current.PatientContext.OperID = oid;
            }
        }

        private string GetStatusNameFromCode(int code)
        {
            return OperationStatusHelper.OperationStatusToString((OperationStatus)code);
        }

        private void GetOperationForOperationRoom()
        {
            if (_bedType.Equals(1))
            {
                GetPacuInfo();
            }
            else
            {
                GetOperationInfo();
                GetPacuInfoForALLView();
            }
        }

        private void GetPacuInfo()
        {
            Dict.OperatingRoomDataTable rooms = DictProxy.GetOperatingRoomDict();
            DataRow[] operationRoom = rooms.Select("BED_TYPE = '" + _bedType.ToString() + "'");
            OperationRoomContent operationRoomContent = null;
            for (int i = 0; i < OperationRoomContentList.Count; i++)
            {
                operationRoomContent = OperationRoomContentList[i];
                operationRoomContent.OperName = "";
                operationRoomContent.VisitID = 0;
                operationRoomContent.OperID = 0;
                operationRoomContent.OperStatus = "空    闲";
                operationRoomContent.Name = "";
                operationRoomContent.AnesDoctor = "";
                operationRoomContent.OperDoctor = "";
                operationRoomContent.OperDate = "";
                operationRoomContent.PatientID = "";
                operationRoomContent.PID = "";
                operationRoomContent.PatientName = "";
                operationRoomContent.OperName = "";
                operationRoomContent.BedNo = "";
                if (operationRoom != null && operationRoom.Length > 0)
                {
                    Dict.OperatingRoomRow operatingRoomRow = null;
                    foreach (DataRow row in operationRoom)
                    {
                        Dict.OperatingRoomRow operRow = row as Dict.OperatingRoomRow;
                        if (operRow.ROOM_NO.Equals(operationRoomContent.OperRoomKey))
                        {
                            operatingRoomRow = operRow;
                        }
                    }
                    if (operatingRoomRow != null)
                    {
                        operationRoomContent.PID = operatingRoomRow.IsPAT_IDNull() ? "" : operatingRoomRow.PAT_ID;
                        operationRoomContent.PatientID = operationRoomContent.PID; // (operationRoomContent.PID.Length > 6) ? operationRoomContent.PID.Substring(operationRoomContent.PID.Length - 6) : operationRoomContent.PID;
                        operationRoomContent.VisitID = operatingRoomRow.IsVISIT_IDNull() ? 0 : operatingRoomRow.VISIT_ID;
                        operationRoomContent.OperID = operatingRoomRow.IsOPER_IDNull() ? 0 : operatingRoomRow.OPER_ID;
                        if (!string.IsNullOrEmpty(operationRoomContent.PID))
                        {
                            PatientBaseInformations.PatMasterIndexDataTable patMaster = PatientInformationsProxy.GetPatMasterIndexDataTable(operationRoomContent.PID);
                            if (patMaster != null && patMaster.Count == 1 && !patMaster[0].IsNAMENull())
                            {
                                operationRoomContent.PatientName = patMaster[0].NAME;
                            }

                            AnesInformations.OperationMasterDataTable operationMaster = AnesthesiaSheetProxy.GetOperationMaster(operationRoomContent.PID
                                , operationRoomContent.VisitID, operationRoomContent.OperID);
                            if (operationMaster != null && operationMaster.Count == 1)
                            {
                                if (!operationMaster[0].OPER_STATUS.Equals((decimal)(int)OperationStatus.InPACU)
                                    && !operationMaster[0].OPER_STATUS.Equals((decimal)(int)OperationStatus.InYouDao))
                                {
                                    operationRoomContent.PID = "";
                                    operationRoomContent.PatientID = "";
                                    operationRoomContent.VisitID = 0;
                                    operationRoomContent.OperID = 0;
                                    operationRoomContent.PatientName = "";
                                }
                                else
                                {
                                    operationRoomContent.OperStatusValue = operationMaster[0].IsOPER_STATUSNull() ? -1 : operationMaster[0].OPER_STATUS;
                                    operationRoomContent.OperStatus = GetStatusNameFromCode((int)operationRoomContent.OperStatusValue);
                                    operationRoomContent.OperName = operationMaster[0].IsOPER_NAMENull() ? "" : operationMaster[0].OPER_NAME;
                                    operationRoomContent.AnesDoctor = operationMaster[0].IsANES_DOCTORNull() ? "" : operationMaster[0].ANES_DOCTOR;
                                    string text = operationRoomContent.AnesDoctor;
                                    if (!string.IsNullOrEmpty(text))
                                    {
                                        if (_doctorTable != null)
                                        {
                                            Dict.HisUserRow row = _doctorTable.FindByUSER_ID(text);
                                            if (row != null)
                                            {
                                                text = row.USER_NAME;
                                            }
                                        }
                                    }
                                    operationRoomContent.AnesDoctor = "麻醉：" + text;

                                    operationRoomContent.OperDoctor = operationMaster[0].IsSURGEONNull() ? "" : operationMaster[0].SURGEON;
                                    text = operationRoomContent.OperDoctor;
                                    if (!string.IsNullOrEmpty(text))
                                    {
                                        if (_doctorTable != null)
                                        {
                                            Dict.HisUserRow row = _doctorTable.FindByUSER_ID(text);
                                            if (row != null)
                                            {
                                                text = row.USER_NAME;
                                            }
                                        }
                                    }
                                    operationRoomContent.OperDoctor = "手术：" + text;

                                    operationRoomContent.BedNo = operationMaster[0].IsBED_NONull() ? "" : operationMaster[0].BED_NO;
                                    if (!operationMaster[0].IsSTART_DATE_TIMENull())
                                    {
                                        operationRoomContent.OperDate = "手术时间：" + operationMaster[0].START_DATE_TIME.ToString("MM-dd hh:mm");
                                    }
                                    else if (!operationMaster[0].IsSCHEDULED_DATE_TIMENull())
                                    {
                                        operationRoomContent.OperDate = "排班时间：" + operationMaster[0].SCHEDULED_DATE_TIME.ToString("MM-dd hh:mm");
                                    }
                                    operationRoomContent.ScheduleDateTime = operationMaster[0].SCHEDULED_DATE_TIME;
                                }
                            }
                        }
                    }
                }
                operationRoomContent.RefreshValue();
            }
        }

        private void GetOperationInfo()
        {
            //Modify @2014-02-12,不按照当天的时间来筛选，时间放开来

            DateTime dt = DateTime.Now.AddYears(-1);
            //dt = new DateTime(2011, 6, 28);
            //DateTime dt = System.DateTime.MinValue;
            //End Modify
            DataTable dataTable = PatientInformationsProxy.GetPatientListDataTable(dt, "", "", "", "", "", "", "", "", "", "");

            string operating_room_no = "";
            OperationRoomContent operationRoomContent = null;
            DataRow[] rows = null;
            DataRow patientInfo = null;
            for (int i = 0; i < OperationRoomContentList.Count; i++)
            {
                operationRoomContent = OperationRoomContentList[i];
                operating_room_no = operationRoomContent.OperRoomNo;
                //rows = dataTable.Select(" OPERATING_ROOM_NO ='" + operating_room_no + "' AND OPER_STATUS >= 5 AND  OPER_STATUS < 35");
                //Add @2014-02-07，对诱导床位的判断和手术间的床位不太相同，故新增
                if (ExtendApplicationContext.Current.AppType == ApplicationType.YouDao)
                {
                    rows = dataTable.Select(string.Format("PAT_ID = '{0}' AND VISIT_ID = {1} AND OPER_ID = {2}", operationRoomContent.PatientID, operationRoomContent.VisitID, operationRoomContent.OperID));
                }
                else
                {
                    //rows = dataTable.Select(" OPERATING_ROOM_NO ='" + operating_room_no + "' AND OPER_STATUS >= 5 AND  OPER_STATUS < 35");
                    rows = dataTable.Select(string.Format("PAT_ID = '{0}' AND VISIT_ID = {1} AND OPER_ID = {2} AND OPERATING_ROOM_NO ='{3}' AND OPER_STATUS >= 5 AND  OPER_STATUS < 35", operationRoomContent.PatientID, operationRoomContent.VisitID, operationRoomContent.OperID,operating_room_no));
                }
                //End Add
                if (rows != null && rows.Length > 0)
                {
                    patientInfo = rows[0];
                    operationRoomContent.OperName = patientInfo["PAT_ID"] == System.DBNull.Value ? "" : patientInfo["PAT_ID"].ToString();
                    operationRoomContent.VisitID = patientInfo["VISIT_ID"] == System.DBNull.Value ? 0 : decimal.Parse(patientInfo["VISIT_ID"].ToString());
                    operationRoomContent.OperID = patientInfo["OPER_ID"] == System.DBNull.Value ? 0 : decimal.Parse(patientInfo["OPER_ID"].ToString());

                    int status = int.Parse(patientInfo["OPER_STATUS"].ToString());
                    operationRoomContent.OperStatusValue = status;
                    operationRoomContent.OperStatus = GetStatusNameFromCode(status);

                    operationRoomContent.Name = patientInfo["NAME"] == System.DBNull.Value ? "" : patientInfo["NAME"].ToString();
                    operationRoomContent.PatientName = patientInfo["NAME"] == System.DBNull.Value ? "" : patientInfo["NAME"].ToString();
                    operationRoomContent.PID = patientInfo["PAT_ID"] == System.DBNull.Value ? "" : patientInfo["PAT_ID"].ToString();
                    operationRoomContent.PatientID = operationRoomContent.PID; // (operationRoomContent.PID.Length > 6) ? operationRoomContent.PID.Substring(operationRoomContent.PID.Length - 6) : operationRoomContent.PID;
                    operationRoomContent.OperName = patientInfo["OPER_NAME"] == System.DBNull.Value ? "" : patientInfo["OPER_NAME"].ToString();

                    operationRoomContent.AnesDoctor = patientInfo["ANES_DOCTOR"] == System.DBNull.Value ? "" : patientInfo["ANES_DOCTOR"].ToString();
                    string text = operationRoomContent.AnesDoctor;
                    if (!string.IsNullOrEmpty(text))
                    {

                        if (_doctorTable != null)
                        {
                            Dict.HisUserRow row = _doctorTable.FindByUSER_ID(text);
                            if (row != null)
                            {
                                text = row.USER_NAME;
                            }
                        }

                    }
                    operationRoomContent.AnesDoctor = "麻醉：" + text;
                    operationRoomContent.OperDoctor = patientInfo["SURGEON"] == System.DBNull.Value ? "" : patientInfo["SURGEON"].ToString();
                    text = operationRoomContent.OperDoctor;
                    if (!string.IsNullOrEmpty(text))
                    {
                        if (_doctorTable != null)
                        {
                            Dict.HisUserRow row = _doctorTable.FindByUSER_ID(text);
                            if (row != null)
                            {
                                text = row.USER_NAME;
                            }
                        }
                    }
                    operationRoomContent.OperDoctor = "手术：" + text;


                    operationRoomContent.BedNo = patientInfo["BED_NO"] == System.DBNull.Value ? "" : patientInfo["BED_NO"].ToString();
                    if (patientInfo["START_DATE_TIME"] == System.DBNull.Value)
                    {
                        operationRoomContent.OperDate = "";
                    }
                    else
                    {
                        operationRoomContent.OperDate = "时间：" + ((DateTime)patientInfo["START_DATE_TIME"]).ToString("MM-dd HH:mm");
                    }
                }
                else
                {
                    //因为诱导室床位中包含三个ID的信息，故此处要把病人ID也清掉
                    operationRoomContent.PatientID = "";
                    operationRoomContent.OperName = "";
                    operationRoomContent.VisitID = 0;
                    operationRoomContent.OperID = 0;
                    operationRoomContent.OperStatus = "空    闲";
                    operationRoomContent.Name = "";
                    operationRoomContent.AnesDoctor = "";
                    operationRoomContent.OperDoctor = "";
                    operationRoomContent.OperDate = "";
                    operationRoomContent.PatientID = "";
                    operationRoomContent.PID = "";
                    operationRoomContent.PatientName = "";
                    operationRoomContent.OperName = "";
                    operationRoomContent.BedNo = "";
                }
                operationRoomContent.RefreshValue();
            }
        }

        private void GetPacuInfoForALLView()
        {
            Dict.OperatingRoomDataTable rooms = DictProxy.GetOperatingRoomDict();
            DataRow[] operationRoom = rooms.Select("BED_TYPE = '1'");
            OperationRoomContent operationRoomContent = null;
            for (int i = 0; i < OperationRoomContentList.Count; i++)
            {

                operationRoomContent = OperationRoomContentList[i];
                if (operationRoomContent.BedType == "0" || operationRoomContent.BedType == "3")
                    continue;


                operationRoomContent.OperName = "";
                operationRoomContent.VisitID = 0;
                operationRoomContent.OperID = 0;
                operationRoomContent.OperStatus = "空    闲";
                operationRoomContent.Name = "";
                operationRoomContent.AnesDoctor = "";
                operationRoomContent.OperDoctor = "";
                operationRoomContent.OperDate = "";
                operationRoomContent.PatientID = "";
                operationRoomContent.PID = "";
                operationRoomContent.PatientName = "";
                operationRoomContent.OperName = "";
                operationRoomContent.BedNo = "";
                if (operationRoom != null && operationRoom.Length > 0)
                {
                    Dict.OperatingRoomRow operatingRoomRow = null;
                    foreach (DataRow row in operationRoom)
                    {
                        Dict.OperatingRoomRow operRow = row as Dict.OperatingRoomRow;
                        if (operRow.ROOM_NO.Equals(operationRoomContent.OperRoomKey))
                        {
                            operatingRoomRow = operRow;
                        }
                    }
                    if (operatingRoomRow != null)
                    {
                        operationRoomContent.PID = operatingRoomRow.IsPAT_IDNull() ? "" : operatingRoomRow.PAT_ID;
                        operationRoomContent.PatientID = operationRoomContent.PID; // (operationRoomContent.PID.Length > 6) ? operationRoomContent.PID.Substring(operationRoomContent.PID.Length - 6) : operationRoomContent.PID;
                        operationRoomContent.VisitID = operatingRoomRow.IsVISIT_IDNull() ? 0 : operatingRoomRow.VISIT_ID;
                        operationRoomContent.OperID = operatingRoomRow.IsOPER_IDNull() ? 0 : operatingRoomRow.OPER_ID;
                        if (!string.IsNullOrEmpty(operationRoomContent.PID))
                        {
                            PatientBaseInformations.PatMasterIndexDataTable patMaster = PatientInformationsProxy.GetPatMasterIndexDataTable(operationRoomContent.PID);
                            if (patMaster != null && patMaster.Count == 1 && !patMaster[0].IsNAMENull())
                            {
                                operationRoomContent.PatientName = patMaster[0].NAME;
                            }

                            AnesInformations.OperationMasterDataTable operationMaster = AnesthesiaSheetProxy.GetOperationMaster(operationRoomContent.PID
                                , operationRoomContent.VisitID, operationRoomContent.OperID);
                            if (operationMaster != null && operationMaster.Count == 1)
                            {
                                if (!operationMaster[0].OPER_STATUS.Equals((decimal)(int)OperationStatus.InPACU)
                                    && !operationMaster[0].OPER_STATUS.Equals((decimal)(int)OperationStatus.InYouDao))
                                {
                                    operationRoomContent.PID = "";
                                    operationRoomContent.PatientID = "";
                                    operationRoomContent.VisitID = 0;
                                    operationRoomContent.OperID = 0;
                                    operationRoomContent.PatientName = "";
                                }
                                else
                                {
                                    operationRoomContent.OperStatusValue = operationMaster[0].IsOPER_STATUSNull() ? -1 : operationMaster[0].OPER_STATUS;
                                    operationRoomContent.OperStatus = GetStatusNameFromCode((int)operationRoomContent.OperStatusValue);
                                    operationRoomContent.OperName = operationMaster[0].IsOPER_NAMENull() ? "" : operationMaster[0].OPER_NAME;
                                    operationRoomContent.AnesDoctor = operationMaster[0].IsANES_DOCTORNull() ? "" : operationMaster[0].ANES_DOCTOR;
                                    string text = operationRoomContent.AnesDoctor;
                                    if (!string.IsNullOrEmpty(text))
                                    {
                                        if (_doctorTable != null)
                                        {
                                            Dict.HisUserRow row = _doctorTable.FindByUSER_ID(text);
                                            if (row != null)
                                            {
                                                text = row.USER_NAME;
                                            }
                                        }
                                    }
                                    operationRoomContent.AnesDoctor = "麻醉：" + text;

                                    operationRoomContent.OperDoctor = operationMaster[0].IsSURGEONNull() ? "" : operationMaster[0].SURGEON;
                                    text = operationRoomContent.OperDoctor;
                                    if (!string.IsNullOrEmpty(text))
                                    {
                                        if (_doctorTable != null)
                                        {
                                            Dict.HisUserRow row = _doctorTable.FindByUSER_ID(text);
                                            if (row != null)
                                            {
                                                text = row.USER_NAME;
                                            }
                                        }
                                    }
                                    operationRoomContent.OperDoctor = "手术：" + text;

                                    operationRoomContent.BedNo = operationMaster[0].IsBED_NONull() ? "" : operationMaster[0].BED_NO;
                                    if (!operationMaster[0].IsSTART_DATE_TIMENull())
                                    {
                                        operationRoomContent.OperDate = "手术时间：" + operationMaster[0].START_DATE_TIME.ToString("MM-dd hh:mm");
                                    }
                                    else if (!operationMaster[0].IsSCHEDULED_DATE_TIMENull())
                                    {
                                        operationRoomContent.OperDate = "排班时间：" + operationMaster[0].SCHEDULED_DATE_TIME.ToString("MM-dd hh:mm");
                                    }
                                    operationRoomContent.ScheduleDateTime = operationMaster[0].SCHEDULED_DATE_TIME;
                                }
                            }
                        }
                    }
                }
                operationRoomContent.RefreshValue();
            }
        }
        public void PatientAlarm()
        {
            if (ExtendApplicationContext.Current.AppType == ApplicationType.Anesthesia)
            {
                OperationRoomContent operationRoomContent = null;
                AnesInformations.VitalSignDataTable vitalSignData = null;
                decimal value = 0;
                for (int i = 0; i < OperationRoomContentList.Count; i++)
                {
                    operationRoomContent = OperationRoomContentList[i];

                    operationRoomContent.NeedAlarm = false;

                    if (!string.IsNullOrEmpty(operationRoomContent.PID))
                    {
                        vitalSignData = AnesthesiaSheetProxy.GetVitalSignData(operationRoomContent.PID, operationRoomContent.VisitID, operationRoomContent.OperID, 0);
                        if (vitalSignData != null)
                        {
                            foreach (AnesInformations.VitalSignRow vitalSignRow in vitalSignData)
                            {
                                foreach (Dict.WisPatMonitorDataDictRow patMonitorDataDictRow in patMonitorDataDictDataTable)
                                {
                                    if (vitalSignRow.ITEM_CODE == patMonitorDataDictRow.DB_DATA_NAME)
                                    {

                                        if (!vitalSignRow.IsVALUENull())
                                        {

                                            value = decimal.Parse(vitalSignRow.VALUE);

                                            if (!patMonitorDataDictRow.IsLOW_SIGNS_VALUESNull() && value > 0)
                                            {
                                                if (value <= patMonitorDataDictRow.LOW_SIGNS_VALUES)
                                                {
                                                    operationRoomContent.NeedAlarm = true;
                                                }
                                            }

                                            if (!patMonitorDataDictRow.IsHIGH_SIGNS_VALUESNull() && value > 0)
                                            {
                                                if (value >= patMonitorDataDictRow.HIGH_SIGNS_VALUES)
                                                {
                                                    operationRoomContent.NeedAlarm = true;
                                                }
                                            }
                                            if (operationRoomContent.NeedAlarm == true)
                                            {
                                                break;
                                            }

                                        }// if (!vitalSignRow.IsVALUENull() )
                                    }
                                }


                                if (operationRoomContent.NeedAlarm == true)
                                {
                                    break;
                                }

                            }
                        }//end if (vitalSignData != null)

                        if (operationRoomContent.NeedAlarm == true)
                        {
                            operationRoomContent.Alarm();
                        }

                    }//if (!string.IsNullOrEmpty(operationRoomContent.PID))
                }

            }
        }
        private void timer_Refresh_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (_doctorTable == null)
            {
                _doctorTable = DictProxy.GetHisUsers();
            }


            GetOperationForOperationRoom();
            RefreshSelect();

            if (NeedAlarm)
                PatientAlarm();

            this.Cursor = Cursors.Default;
        }


        private void RefreshAllPatientsVitalSign()
        {

        }

        public void RefreshSelect()
        {
            foreach (OperationRoomContent operationRoomContent in medPanelMain.Controls)
            {
                if (ExtendApplicationContext.Current.PatientInformation != null
                    && operationRoomContent.PatientID == ExtendApplicationContext.Current.PatientInformation.PatientID
                    && operationRoomContent.VisitID == ExtendApplicationContext.Current.PatientInformation.VisitID
                    && operationRoomContent.OperID == ExtendApplicationContext.Current.PatientInformation.OperID)
                    operationRoomContent.Selected = true;
                else
                    operationRoomContent.Selected = false;

                operationRoomContent.Refresh();
            }
        }
    }
    public class CommandEventHandler
    {

    }
}
