using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Wis.Anes.Framework;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.BusinessEntity;
using Wis.Anes.DataAccess;
using Wis.Anes.Framework.Utilities;
using Wis.Anes.Framework.Views.PatientStatus;
using Wis.Anes.Framework.Views.Process;
using Wis.Anes.Framework.Doc;

namespace Wis.Anes.Framework.Views
{
    [Serializable(), ToolboxItem(false)]
    public partial class PatientStatusContrl : XtraUserControl
    {
        protected Dictionary<string, DateTime> _outPatients = new Dictionary<string, DateTime>();

        //Add By chengying.x @20140303 用于标识是否已经提示过多页，如果已提示过则置为True
        private bool FlagTip = false;
        //End Add

        public enum OperationLightStatus
        {
            Nomal = 0,
            Passed = 1,
            Light = 2

        }

        private static readonly object _refreshPatient = new object();
        public event EventHandler RefreshPatientHandler
        {
            add
            {
                Events.AddHandler(_refreshPatient, value);
            }
            remove
            {
                Events.RemoveHandler(_refreshPatient, value);
            }
        }


        private void RaiseRefreshPatient()
        {
            EventHandler eventHandle = Events[_refreshPatient] as EventHandler;
            if (eventHandle != null)
            {
                eventHandle(this, null);
            }
        }


        public PatientStatusContrl()
        {
            InitializeComponent();
        }


        private Image _NormalImage = null;
        private Image _PassedImage = null;
        private Image _LightImage = null;
        private Wis.Anes.Framework.IOperationStatusObserver _ServiceObject = null;
        public Image NormalImage
        {
            get { return _NormalImage; }
            set { _NormalImage = value; }
        }
        public Image PassedImage
        {
            get { return _PassedImage; }
            set { _PassedImage = value; }
        }
        public Image LightImage
        {
            get { return _LightImage; }
            set { _LightImage = value; }
        }

        private IPatientStatusAction patientStatusAction = null;
        public void SetPatientStatusAction(IPatientStatusAction patientStatusAction)
        {
            this.patientStatusAction = patientStatusAction;
        }

        public bool IsValid()
        {


            bool isValid = true;

            //int validateFlag = 0; //验证标志位:0 =无特殊消息 1=当前控件时间为空 2=当前控件时间不合规范 3=存在多页提示

            foreach (SinglePatientStatusConrol singlePatientStatusConrol in this.panelMain.Controls)
            {
                if (!singlePatientStatusConrol.IsValidated())
                {

                    isValid = false;

                }
            }
            FlagTip = false;
            return isValid;
        }

        /// <summary>
        /// 该 SinglePatientStatusConrol 服务的控件
        /// </summary>
        public IOperationStatusObserver ServiceObject
        {
            get { return _ServiceObject; }
            set { _ServiceObject = value; }
        }

        public void SetBackground(Image bg)
        {
            foreach (Control c in this.panelMain.Controls)
            {
                if (c is SinglePatientStatusConrol)
                {
                    c.BackgroundImage = bg;
                    c.BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
        }

        /// <summary>
        /// 生成状态按钮
        /// </summary>
        public void CreatePatientStatusButtons(string sPatientStatus)
        {


            this.panelMain.Controls.Clear();
            //判断是否为有效状态
            if (sPatientStatus.Length <= 0)
            {
                return;
            }

            string[] buttons = sPatientStatus.Split(',');
            int btnLeft = 0;
            int btnHeight = 40;
            int btnTop = (this.Height - btnHeight) / 2;
            int btnWidth = 130;
            int btnSpace = ((int)(Screen.PrimaryScreen.Bounds.Width - this.Left) / 8);
            SinglePatientStatusConrol singlePatientStatusConrol = null;
            for (int i = 0; i < buttons.Length; i++)
            {
                singlePatientStatusConrol = new SinglePatientStatusConrol();
                singlePatientStatusConrol.StatusName = buttons[i];
                singlePatientStatusConrol.Name = "S" + singlePatientStatusConrol.StatusName;
                singlePatientStatusConrol.NormalImage = NormalImage;
                singlePatientStatusConrol.PassedImage = PassedImage;
                singlePatientStatusConrol.LightImage = LightImage;
                singlePatientStatusConrol.BackgroundImage = BackgroundImage;
                singlePatientStatusConrol.BackgroundImageLayout = ImageLayout.Stretch;
                singlePatientStatusConrol.SetStatusLightImage(OperationLightStatus.Nomal);
                singlePatientStatusConrol.Height = btnHeight;
                singlePatientStatusConrol.Left = btnLeft;
                singlePatientStatusConrol.Top = btnTop;
                singlePatientStatusConrol.Width = btnWidth;
                //注册观察项
                singlePatientStatusConrol.ServicePatientStatusContrl = this;
                if (btnSpace > (btnWidth + 10))
                {
                    btnLeft += btnSpace;
                }
                else
                {
                    btnLeft += btnWidth + 10;
                }
                this.panelMain.Controls.Add(singlePatientStatusConrol);
            }


        }
        /// <summary>
        /// 设置手术状态灯
        /// </summary>
        /// <param name="operationStatus"></param>
        public void SetStatusLight(OperationStatus operationStatus)
        {

            int operationStatusValue = (int)operationStatus;
            foreach (SinglePatientStatusConrol singlePatientStatusConrol in this.panelMain.Controls)
            {
                int operationStatusValueTemp = (int)OperationStatusHelper.OperationStatusFromString(singlePatientStatusConrol.StatusName);
                if (operationStatusValueTemp < operationStatusValue)
                {
                    singlePatientStatusConrol.SetStatusLightImage(OperationLightStatus.Passed);
                }
                else if (operationStatusValueTemp == operationStatusValue)
                {
                    singlePatientStatusConrol.SetStatusLightImage(OperationLightStatus.Light);
                }
                else
                {
                    singlePatientStatusConrol.SetStatusLightImage(OperationLightStatus.Nomal);
                }
            }
        }

        /// <summary>
        /// 设置手术状态按扭时间
        /// </summary>
        /// <param name="operationStatus"></param>
        public void SetOperationStatusTimeText(OperationStatus operationStatus)
        {
            int operationStatusValue = (int)operationStatus;
            OperationStatus operStatus = OperationStatus.None;
            AnesInformations.OperationMasterDataTable dataTable = (new AnesthesiaSheetDA()).GetOperationMaster(ExtendApplicationContext.Current.PatientInformation.PatientID, ExtendApplicationContext.Current.PatientInformation.VisitID, ExtendApplicationContext.Current.PatientInformation.OperID);

            //判断 GetTimeFieldName
            if (dataTable.Count > 0)
            {

                foreach (SinglePatientStatusConrol singlePatientStatusConrol in this.panelMain.Controls)
                {
                    int operationStatusValueTemp = (int)OperationStatusHelper.OperationStatusFromString(singlePatientStatusConrol.StatusName);
                    //先时间清空数据,
                    singlePatientStatusConrol.SetOperationStatusTimeText(DateTime.MinValue);

                    if (operationStatusValueTemp <= operationStatusValue)
                    {

                        operStatus = OperationStatusHelper.OperationStatusFromString(singlePatientStatusConrol.StatusName);
                        //获取字段
                        string dtField = OperationStatusHelper.GetTimeFieldName(operStatus);

                        OperationStatusHelper.GetTimeFieldName(operStatus);
                        DateTime StatusTime = DateTime.MinValue;
                        if (!string.IsNullOrEmpty(dataTable[0][dtField].ToString()))
                        {
                            StatusTime = ((DateTime)dataTable[0][dtField]);
                        }

                        //singlePatientStatusConrol.LastTime = StatusTime;
                        singlePatientStatusConrol.SetOperationStatusTimeText(StatusTime);

                        //if (singlePatientStatusConrol.StatusName == "入手术室" || singlePatientStatusConrol.StatusName == "出手术室")
                        //{
                        //    if (StatusTime != DateTime.MinValue && !AccessControl.CheckModifyRight("入室时间"))
                        //    {

                        //        singlePatientStatusConrol.Enabled = false;

                        //    }
                        //    else
                        //    {
                        //        singlePatientStatusConrol.Enabled = true;

                        //    }
                        //}
                    }
                    else
                    {
                        singlePatientStatusConrol.Enabled = true;
                    }

                }
            }


        }

        /// <summary>
        /// 验证时间
        /// </summary>
        /// <param name="singleConrol">控件本身</param>
        /// <param name="validateFlag">验证标志位 0无特殊消息 1当前控件时间为空 2当前控件时间不合规范 3 多页提示</param>
        public bool OnSinglePatientStatusConrolTimeValidate(SinglePatientStatusConrol singleConrol)
        {
            //获取当前控件状态


            int operationStatusValue = (int)OperationStatusHelper.OperationStatusFromString(singleConrol.StatusName);
           

            //如果该状态是已过或者当前状态，则不能为空
            if (singleConrol.ConrolLightStatus != OperationLightStatus.Nomal && operationStatusValue >= 5 )
            {
                ////如果该状态是已过或者当前状态，则不能为空
                //if (singleConrol.ConrolLightStatus != OperationLightStatus.Nomal)
                //{
                if (singleConrol.IsDateTimeEmpty())
                {
                    if (singleConrol.Enabled)
                    {
                        XtraMessageBox.Show("【" + singleConrol.StatusName + "】 时间 不能为空，请重新输入！",
                                       "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //validateFlag = 1; //验证标志位:0 =无特殊消息 1=当前控件时间为空 2=当前控件时间不合规范 3=存在多页提示


                        return false;
                    }
                    else
                    {
                        singleConrol.RobackTime();
                    }
                }
            }

            if (singleConrol.IsDateTimeEmpty())
                return true;



            if (ExtendApplicationContext.Current.AppType == ApplicationType.PACU)
            {
                AnesInformations.OperationMasterDataTable dataTable = (new AnesthesiaSheetDA()).GetOperationMaster(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID);
                if (dataTable != null && dataTable.Count == 1)
                {
                    if (!dataTable[0].IsOUT_DATE_TIMENull())
                    {
                        if (singleConrol.ControlDateTime < dataTable[0].OUT_DATE_TIME)
                        {
                            if (singleConrol.Enabled)
                            {
                                XtraMessageBox.Show("【" + singleConrol.StatusName + "】 时间 [" + singleConrol.ControlDateTime + "] 大于 【出手术室】时间 [" + dataTable[0].OUT_DATE_TIME + "]，请重新输入！",
              "系统提示", MessageBoxButtons.OK,MessageBoxIcon.Information);
                                return false;
                            }
                            else
                            {
                                singleConrol.RobackTime();
                            }
                        }
                    }
                }


            }


            //循环判断前面的状态是否有时间未输入
            foreach (SinglePatientStatusConrol singlePatientStatusConrol in this.panelMain.Controls)
            {
                int operationStatusValueTemp = (int)OperationStatusHelper.OperationStatusFromString(singlePatientStatusConrol.StatusName);
                    
                //判断前面的状态是否有时间未输入
                if (operationStatusValueTemp < operationStatusValue)
                {
                    if (!singlePatientStatusConrol.IsDateTimeEmpty())
                    {
                        //判断时间录入是否正确
                        if (singlePatientStatusConrol.ControlDateTime > singleConrol.ControlDateTime)
                        {
                            if (singleConrol.Enabled)
                            {
                                XtraMessageBox.Show("【" + singlePatientStatusConrol.StatusName + "】 时间 [" + singlePatientStatusConrol.ControlDateTime + "] 大于 【" + singleConrol.StatusName + "】时间 [" + singleConrol.ControlDateTime + "]，请重新输入！",
                                    "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //validateFlag = 2; //验证标志位:0 =无特殊消息 1=当前控件时间为空 2=当前控件时间不合规范 3=存在多页提示
                                return false;
                            }
                            else
                            {
                                singleConrol.RobackTime();
                            }
                        }

                    }
                }
                else
                {
                    if (!singlePatientStatusConrol.IsDateTimeEmpty())
                    {

                        //判断时间录入是否正确
                        if (singlePatientStatusConrol.ControlDateTime < singleConrol.ControlDateTime)
                        {
                            if (singleConrol.Enabled)
                            {
                                XtraMessageBox.Show("【" + singleConrol.StatusName + "】 时间[" + singleConrol.ControlDateTime + "]  大于 【" + singlePatientStatusConrol.StatusName + "】时间[" + singlePatientStatusConrol.ControlDateTime + "] ，请重新输入！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //validateFlag =2; //验证标志位:0 =无特殊消息 1=当前控件时间为空 2=当前控件时间不合规范 3=存在多页提示
                                return false;
                            }
                            else
                            {
                                singleConrol.RobackTime();
                            }
                        }


                    }

                }
            }
            string info = "麻醉单";
            if (ExtendApplicationContext.Current.AppType == ApplicationType.PACU)
            {
                info = "复苏单";
            }

            //if (singleConrol.LastTime != singleConrol.ControlDateTime)
            //{
            //录入正确的话 判断是否 翻页 翻页的话 提示
            if (!FlagTip)
            {
                foreach (SinglePatientStatusConrol singlePatientStatusConrol in this.panelMain.Controls)
                {
                    int operationStatusValueTemp = (int)OperationStatusHelper.OperationStatusFromString(singlePatientStatusConrol.StatusName);
                    if (!singlePatientStatusConrol.IsDateTimeEmpty())
                    {
                        //Modify @2014-02-14,判断是否造成分页时按照实际麻醉单一页的时间跨度来计算

                        //if (singleConrol.ControlDateTime > singlePatientStatusConrol.ControlDateTime.AddHours(4))
                        if (singleConrol.ControlDateTime > singlePatientStatusConrol.ControlDateTime.AddHours(ApplicationConfiguration.AnesDocPageHours))
                        {
                            if (singleConrol.Enabled)
                            {
                                DialogResult dialogRes = XtraMessageBox.Show("您输入的 【" + singleConrol.StatusName + "】 时间 [" + singleConrol.ControlDateTime + "] 将会造成" + info + "多页，是否继续？",
                                 "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                //validateFlag = 3; //验证标志位:0 =无特殊消息 1=当前控件时间为空 2=当前控件时间不合规范 3=存在多页提示
                                FlagTip = true;
                                if (dialogRes == DialogResult.No)
                                {
                                    return false;
                                }
                                else
                                {
                                    break;
                                }

                            }
                            else
                            {
                                singleConrol.RobackTime();
                            }
                        }
                        //else if (singleConrol.ControlDateTime < singlePatientStatusConrol.ControlDateTime.AddHours(-4))
                        else if (singleConrol.ControlDateTime < singlePatientStatusConrol.ControlDateTime.AddHours(-ApplicationConfiguration.AnesDocPageHours))
                        //End Modify
                        {
                            if (singleConrol.Enabled)
                            {
                                DialogResult dialogRes = XtraMessageBox.Show("您输入的 【" + singleConrol.StatusName + "】 时间 [" + singleConrol.ControlDateTime + "] 将会造成" + info + "多页，是否继续？",
                                "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                //validateFlag = 3; //验证标志位:0 =无特殊消息 1=当前控件时间为空 2=当前控件时间不合规范 3=存在多页提示
                                FlagTip = true;
                                if (dialogRes == DialogResult.No)
                                {
                                    singleConrol.RobackTime();
                                    return false;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                singleConrol.RobackTime();
                            }
                        }
                    }
                }
            }
            //}

            //// 判断当前时间是否在有效范围内
            //if (singleConrol.StatusName == "入手术室" || singleConrol.StatusName == "出手术室")
            //{
            //    if (singleConrol.LastTime != singleConrol.ControlDateTime && !AccessControl.CheckModifyRight("入室时间"))
            //    {
            //        DateTime dtNow = new CommonDA().GetSysDateTime();
            //        string validHours = ApplicationConfiguration.WorkHourRange;
            //        double hours = Convert.ToDouble(validHours);

            //        TimeSpan span = dtNow - singleConrol.ControlDateTime;
            //        if (Math.Abs(span.TotalHours) > hours)
            //        {
            //            Dialog.MessageBox("所输入的时间不在所允许的范围内");
            //            return false;
            //        }

            //        string msg = string.Format(singleConrol.StatusName + "时间为：{0::yyyy-MM-dd HH:mm}\n确认时间后将不能修改，是否确认？",
            //            singleConrol.ControlDateTime);

            //        if (Dialog.MessageBox(msg, "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            //        {
            //            return false;
            //        }

            //        singleConrol.Enabled = false;
            //    }
            //}

            if (singleConrol.StatusName == "出手术室")
            {
                string _patientID = ExtendApplicationContext.Current.PatientContext.PatientID;
                decimal _visitID = ExtendApplicationContext.Current.PatientContext.VisitID;
                decimal _operID = ExtendApplicationContext.Current.PatientContext.OperID;
                CareDocs.WIS_CUSTOM_DATADataTable customData = new CareDocsDA().GetCustomData(_patientID, (int)_visitID, (int)_operID);
                SaveCustomDataRow(customData, _patientID, (int)_visitID, (int)_operID, "麻醉单编号", "", singleConrol);
                int ret = new CareDocsDA().UpdateCustomData(customData);
                if (ret <= 0)
                {
                    //Dialog.MessageBox("生成麻醉单编号失败！");
                }
            }

            SetValueAndUpdateStatus(singleConrol);
            //反写麻醉开始，麻醉结束，手术开始，手术结束时间
            PostHisOperationTimes(singleConrol.StatusName, singleConrol.ControlDateTime);
            //singleConrol.LastTime = singleConrol.ControlDateTime;
            return true;


        }
        /// <summary>
        /// 保存自定义表数据
        /// </summary>
        private void SaveCustomDataRow(CareDocs.WIS_CUSTOM_DATADataTable dataTable, string patientID, int visitID, int operID, string itemName, string itemValue, SinglePatientStatusConrol singleConrol)
        {
            CareDocs.WIS_CUSTOM_DATARow row1 = dataTable.FindByPAT_IDVISIT_IDOPER_IDITEM_NAME(patientID, visitID, operID, itemName);
            if (row1 == null)
            {
                CommonDA da = new CommonDA();
                DataTable table = da.GetDataFromSQLString("SELECT * FROM WIS_CUSTOM_DATA WHERE ITEM_NAME='" + itemName + "' AND PAT_ID + convert(nvarchar(20),VISIT_ID) + convert(nvarchar(20),OPER_ID) <>'" + patientID  + visitID + operID + "' AND ITEM_VALUE LIKE '" + singleConrol.ControlDateTime.Year + "%' ORDER BY ITEM_VALUE DESC ");
                //DataTable table = da.GetDataFromSQLString("SELECT * FROM WIS_CUSTOM_DATA WHERE ITEM_NAME='" + itemName + "' AND PAT_ID||VISIT_ID||OPER_ID<>'" + patientID  + visitID + operID + "' AND ITEM_VALUE LIKE '" + singleConrol.ControlDateTime.Year + "%' ORDER BY ITEM_VALUE DESC ");
                //CareDocs.WIS_CUSTOM_DATADataTable customTable = table as CareDocs.WIS_CUSTOM_DATADataTable;
                if (table.Rows.Count == 0)
                {
                    itemValue = singleConrol.ControlDateTime.Year + "00000";
                }
                else
                {
                    itemValue = (Convert.ToInt32(table.Rows[0]["ITEM_VALUE"].ToString()) + 1).ToString();
                }
                AddCustomDataRow(dataTable, patientID, visitID, operID, itemName, itemValue);
            }
        }
        private CareDocs.WIS_CUSTOM_DATARow AddCustomDataRow(CareDocs.WIS_CUSTOM_DATADataTable dataTable, string patientID, int visitID, int operID, string itemName, string itemValue)
        {
            CareDocs.WIS_CUSTOM_DATARow row = dataTable.NewWIS_CUSTOM_DATARow();
            row.PAT_ID = patientID;
            row.VISIT_ID = visitID;
            row.OPER_ID = operID;
            row.ITEM_NAME = itemName;
            row.ITEM_VALUE = itemValue;
            dataTable.AddWIS_CUSTOM_DATARow(row);
            return row;
        }
        /// <summary>
        /// 设置时间值更新状态
        /// </summary>
        private void SetValueAndUpdateStatus(SinglePatientStatusConrol singleConrol)
        {
            //设置控件样式
            if (singleConrol.IsDateTimeEmpty())
            {

                singleConrol.SetStyle(false);
            }

            else
            {
                singleConrol.SetStyle(true);

                //更新时间和状态
                OperationStatus operationStatusNew = OperationStatusHelper.OperationStatusFromString(singleConrol.StatusName);
                OperationStatus operationStatusNow = ExtendApplicationContext.Current.OperationStatus;

                if ((int)operationStatusNew > (int)operationStatusNow)
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatusNew, singleConrol.ControlDateTime, true, operationStatusNow))
                    {
                        NoifyOperationStatusChange(operationStatusNew);

                    }
                }
                else
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatusNew, singleConrol.ControlDateTime, false, operationStatusNow))
                    {
                        NoifyOperationTimeChange();
                    }
                }



                //更新Schedule表中 Status
                if (operationStatusNew == OperationStatus.InOperationRoom || operationStatusNew == OperationStatus.AnesthesiaStart || operationStatusNew == OperationStatus.OperationStart)
                {
                    if (ApplicationConfiguration.IsUpdateScheduleStatus)
                    {
                        (new AnesthesiaSheetDA()).UpdateOperationScheduleStatus(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID, 3);
                    }
                }

                //排班状态更新回传HIS
                if (operationStatusNew == OperationStatus.InOperationRoom || operationStatusNew == OperationStatus.OutOperationRoom)
                {
                    if (ApplicationConfiguration.IsUpdateScheduleStatus)
                    {
                        string ret = (new SyncDA()).SyncWriteHisOperStatus(ExtendApplicationContext.Current.PatientContext.PatientID, (int)ExtendApplicationContext.Current.PatientContext.VisitID, (int)ExtendApplicationContext.Current.PatientInformation.OperID, 0);
                        //if (!string.IsNullOrEmpty(ret))
                        //    Dialog.MessageBox(ret);
                    }
                }

                //手术状态更新，回传His
                if (operationStatusNew == OperationStatus.InOperationRoom || operationStatusNew == OperationStatus.OutOperationRoom)
                {


                    if (ApplicationConfiguration.IsUpdateHisStatus)
                    {
                        try
                        {
                            //MessageBox.Show("回写调用");
                            string ret = (new SyncDA()).SyncWriteHisOperStatus(ExtendApplicationContext.Current.PatientContext.PatientID, (int)ExtendApplicationContext.Current.PatientContext.VisitID, (int)ExtendApplicationContext.Current.PatientInformation.OperID, 1);
                            //if (!string.IsNullOrEmpty(ret))
                            //    Dialog.MessageBox(ret);
                            //MessageBox.Show("调用结果：" + ret);
                        }
                        catch (Exception ex)
                        {
                            ExceptionHandler.Handle(ex);
                        }
                    }
                }
            }

        }
        /// <summary>
        /// 验证是否可被触发
        /// </summary>
        /// <param name="singleConrol"></param>
        public bool OnSinglePatientStatusConrolTimeClick(SinglePatientStatusConrol singleConrol)
        {

            //if (singleConrol.StatusName == "入手术室" && (int)ExtendApplicationContext.Current.OperationStatus == 0)
            //{
            //    DialogResult dr = XtraMessageBox.Show("患者未经过诱导流程，是否跳过诱导直接入手术室？",
            //                      "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //    if (dr != DialogResult.Yes)
            //    {
            //        return false;
            //    }
            //}
            // else if (singleConrol.StatusName == "入手术室" && (int)ExtendApplicationContext.Current.OperationStatus > 0 && (int)ExtendApplicationContext.Current.OperationStatus < 4)
            if (singleConrol.StatusName == "入手术室" && (int)ExtendApplicationContext.Current.OperationStatus > 0 && (int)ExtendApplicationContext.Current.OperationStatus < 4)
            {
                DialogResult dr = XtraMessageBox.Show("患者诱导流程还没结束，请等待患者出诱导室。",
                  "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }


            return true;
        }

        /// <summary>
        /// 设置状态控件是否可用
        /// </summary>
        public void SetPatientStatusContrlReadOnly(bool readonlyable)
        {
            

                //循环判断前面的状态是否有时间未输入
            foreach (Control ctrl in this.panelMain.Controls)
            {
                SinglePatientStatusConrol singlePatientStatusConrol = ctrl as SinglePatientStatusConrol;
                if (singlePatientStatusConrol != null)
                    singlePatientStatusConrol.SetPatientStatusContrlReadOnly(readonlyable);
                //if (ExtendApplicationContext.Current.IsMatchingUser == 0)
                //{
                //    singlePatientStatusConrol.SetPatientStatusContrlReadOnly(false);
                //}
            }

        }
        /// <summary>
        /// 时间按钮被按下时触发
        /// </summary>
        /// <param name="singleConrol"></param>
        /// <returns></returns>
        public bool OnSinglePatientStatusConrolTimeKeyDown(SinglePatientStatusConrol singleConrol)
        {

            if (string.IsNullOrEmpty(ExtendApplicationContext.Current.PatientContext.PatientID))
            {
                XtraMessageBox.Show("还未选择患者，无法输入时间！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }


            return CanEnterConrolTime(singleConrol);

        }

        private bool CanEnterConrolTime(SinglePatientStatusConrol singleConrol)
        {

            //诱导室检查
            if (ExtendApplicationContext.Current.AppType == ApplicationType.YouDao)
            {
                //Add By xiasen.x@2014-02-07，出诱导室时不进行是否有空床位的判断
                if (singleConrol.StatusName.Equals("出诱导室"))
                    return true;
                //End Add
                DictDA dictDA = new DictDA();
                Dict.OperatingRoomDataTable roomdict = dictDA.GetOperatingRoomDict(3);
                bool haslest = false;
                foreach (Dict.OperatingRoomRow row in roomdict.Rows)
                {
                    if (row.IsPAT_IDNull() || string.IsNullOrEmpty(row.PAT_ID))
                    {
                        haslest = true;
                        break;
                    }
                }
                if (haslest)
                {
                    return true;
                }
                else
                {
                    XtraMessageBox.Show(string.Format("诱导室无剩余床位"), "提示信息");
                    return false;
                }
            }


            //如果是PACU 不检查手术室，PACU室通常只有1个 只要检查床位
            if (ExtendApplicationContext.Current.AppType == ApplicationType.PACU)
            {
                return true;
            }
            if (!AccessControl.CheckModifyRight("麻醉记录单"))
            {
                XtraMessageBox.Show(string.Format("您没有操作该文书的权限"), "提示信息");
                return true;
            }




            if (singleConrol.ConrolLightStatus == OperationLightStatus.Nomal)
            {
                //判断该手术室是否有其他病人
                //string roomNo = ActionFactory.PatientInformation.OperRoom;
                string roomNo = ExtendApplicationContext.Current.PatientInformation.OperRoom;
                AnesthesiaSheetDA anesthesiaSheetDA = new AnesthesiaSheetDA();
                AnesInformations.OperationMasterDataTable operationMasterDataTable = anesthesiaSheetDA.GetOperationMaster(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID);
                foreach (AnesInformations.OperationMasterRow mrow in operationMasterDataTable.Rows)
                {
                    if (!mrow.IsOPERATING_ROOM_NONull())
                    {
                        roomNo = mrow.OPERATING_ROOM_NO;
                    }
                    break;
                }

                //2014-5-27 周青 两个不同的科室有相同OPERATION_ROOM的情况
                string deptCode = ApplicationConfiguration.OpertionDeptCode;
                AnesInformations.OperationMasterDataTable masterDataTable = anesthesiaSheetDA.GetOperationMaster(5, 30, roomNo, deptCode);

                if (masterDataTable != null && masterDataTable.Count > 0)
                {
                    foreach (AnesInformations.OperationMasterRow mrow in masterDataTable.Rows)
                    {
                        if (mrow.PAT_ID != ExtendApplicationContext.Current.PatientContext.PatientID || mrow.VISIT_ID != ExtendApplicationContext.Current.PatientContext.VisitID || mrow.OPER_ID != ExtendApplicationContext.Current.PatientContext.OperID)
                        {
                            DialogResult dialogres = XtraMessageBox.Show(string.Format("手术间【{0}】已存在PatientID为【{1}】且还未出手术间的患者手术记录", roomNo, mrow.PAT_ID), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            return false;
                        }
                    }
                }
            }


            //获取当前控件状态
            int operationStatusValue = (int)OperationStatusHelper.OperationStatusFromString(singleConrol.StatusName);


            //循环判断前面的状态是否有时间未输入
            bool LastHasValue = true;
            SinglePatientStatusConrol lastCtrl = null;
            foreach (SinglePatientStatusConrol singlePatientStatusConrol in this.panelMain.Controls)
            {
                int operationStatusValueTemp = (int)OperationStatusHelper.OperationStatusFromString(singlePatientStatusConrol.StatusName);
                if (operationStatusValueTemp == 35)
                {
                    //DialogResult dialogResult = XtraMessageBox.Show("请确认是否直接出手术室！",
                    //                "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    //if (dialogResult == DialogResult.OK)
                    //{
                    //    LastHasValue = true;
                    //}
                    //foreach (SinglePatientStatusConrol singlePatientStatusConrol1 in this.panelMain.Controls)
                    //{
                    //    if (singlePatientStatusConrol1.ControlDateTime.ToString() == "")
                    //    {
                    //        singlePatientStatusConrol1.ControlDateTime = Convert.ToDateTime("1900-01-01 00:00:00");
                    //    }
                    //}
                    //foreach (SinglePatientStatusConrol singlePatientStatusConrol in this.panelMain.Controls)
                    //{
                    //    if (singlePatientStatusConrol.StatusName == "出手术室")
                    //    {
                    //        if (singlePatientStatusConrol.ControlDateTime.ToString() != "")
                    //        {
                    //            foreach (SinglePatientStatusConrol singlePatientStatusConrol1 in this.panelMain.Controls)
                    //            {
                    //                if (singlePatientStatusConrol1.ControlDateTime.ToString() == "")
                    //                {
                    //                    singlePatientStatusConrol1.ControlDateTime = Convert.ToDateTime("1900-01-01 00:00:00");
                    //                }
                    //            }
                    //        }
                    //    }
                    //}

                    LastHasValue = true;
                }
                else
                {
                    //判断前面的状态是否有时间未输入
                    if (operationStatusValueTemp < operationStatusValue)
                    {
                        if (singlePatientStatusConrol.IsDateTimeEmpty())
                        {

                            LastHasValue = false;
                            lastCtrl = singlePatientStatusConrol;
                        }
                        else
                        {
                            LastHasValue = true;
                        }
                    }
                }
                

            }


            if (!LastHasValue && lastCtrl != null)
            {
                XtraMessageBox.Show("请先输入 【" + lastCtrl.StatusName + "】状态时间！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;

        }


        /// <summary>
        /// 设置手术状态,更新主界面
        /// </summary>
        /// <param name="operationStatus"></param>
        public void NoifyOperationStatusChange(OperationStatus operationStatus)
        {
            if (_ServiceObject != null && _ServiceObject is IOperationStatusObserver)
            {
                ((IOperationStatusObserver)_ServiceObject).NoifyOperationStatusChange(operationStatus);
            }
        }

        /// <summary>
        /// 设置手术时间改变,更新 文书
        /// </summary>
        /// <param name="operationStatus"></param>
        public void NoifyOperationTimeChange()
        {
            if (_ServiceObject != null && _ServiceObject is IOperationStatusObserver)
            {
                ((IOperationStatusObserver)_ServiceObject).NoifyOperationTimeChange();
            }
        }


        #region "弹出菜单控制"

        /// <summary>
        /// 鼠标按下，界面事件弹出
        /// </summary>
        /// <param name="caption"></param>
        public void OnPopUpOperationSatusMouseDown(SinglePatientStatusConrol singleConrol)
        {
            OperationStatus operationStatus = OperationStatusHelper.OperationStatusFromString(singleConrol.StatusName);

            if (singleConrol.ConrolLightStatus == OperationLightStatus.Light)
            {
                //出手术室
                if (operationStatus == OperationStatus.OutOperationRoom)//出手术室
                {
                    SetPopUpBarVisible(true);
                    SetPopUpOperationSatusManagerVisible(true);
                    SetPopUpOperationSatusPACU(true);
                    SetPopUpOperationSatusManagerCaption("转到状态【入手术室】");
                    SetPopUpOperationSatusManagerCaption2("");
                }
                else if (operationStatus == OperationStatus.InOperationRoom)//入手术室
                {
                    SetPopUpBarVisible(false);
                    SetPopUpOperationSatusManagerVisible(true);
                    SetPopUpOperationSatusPACU(false);
                    SetPopUpOperationSatusManagerCaption("取消状态【入手术室】");
                    SetPopUpOperationSatusManagerCaption2("");
                }
                else if (operationStatus == OperationStatus.AnesthesiaStart)//麻醉开始
                {
                    SetPopUpBarVisible(false);
                    SetPopUpOperationSatusManagerVisible(true);
                    SetPopUpOperationSatusPACU(false);
                    SetPopUpOperationSatusManagerCaption("转到状态【入手术室】");
                    SetPopUpOperationSatusManagerCaption2("转到状态【麻醉结束】");
                }
                else if (operationStatus == OperationStatus.OperationStart)//手术开始
                {
                    SetPopUpBarVisible(false);
                    SetPopUpOperationSatusManagerVisible(true);
                    SetPopUpOperationSatusPACU(false);
                    SetPopUpOperationSatusManagerCaption("转到状态【麻醉开始】");
                    SetPopUpOperationSatusManagerCaption2("");
                }
                else if (operationStatus == OperationStatus.OperationEnd)//手术结束
                {
                    SetPopUpBarVisible(false);
                    SetPopUpOperationSatusManagerVisible(true);
                    SetPopUpOperationSatusManagerCaption("转到状态【手术开始】");
                    SetPopUpOperationSatusManagerCaption2("");
                }
                else if (operationStatus == OperationStatus.AnesthesiaEnd)//麻醉结束
                {
                    SetPopUpBarVisible(false);
                    SetPopUpOperationSatusManagerVisible(true);
                    SetPopUpOperationSatusPACU(false);
                    SetPopUpOperationSatusManagerCaption("转到状态【手术结束】");
                    SetPopUpOperationSatusManagerCaption2("");
                }


                else if (operationStatus == OperationStatus.InPACU)//入复苏室
                {
                    SetPopUpBarVisible(false);
                    SetPopUpOperationSatusManagerVisible(true);
                    SetPopUpOperationSatusManagerCaption("取消状态【入复苏室】");
                    SetPopUpOperationSatusManagerCaption2("");
                }


                else if (operationStatus == OperationStatus.InYouDao)//入诱导室
                {
                    SetPopUpBarVisible(false);
                    SetPopUpOperationSatusManagerVisible(true);
                    SetPopUpOperationSatusManagerCaption("取消状态【入诱导室】");
                }
                else if (operationStatus == OperationStatus.OutYouDao)//入诱导室
                {
                    SetPopUpBarVisible(false);
                    SetPopUpOperationSatusManagerVisible(false);
                    //SetPopUpOperationSatusManagerVisible(true);
                    //SetPopUpOperationSatusManagerCaption("转到状态【入诱导室】");
                }


                else if (operationStatus == OperationStatus.OutPACU)//出复苏室
                {
                    barButtonItemTurnToRoom.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    barButtonItemTurnToICU.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    SetPopUpOperationSatusManagerVisible(true);
                    SetPopUpOperationSatusManagerCaption("转到状态【入复苏室】");
                }
                popupMenuStatus.ShowPopup(Control.MousePosition);
            }


        }
        /// <summary>
        /// 设置弹出菜单名称
        /// </summary>
        /// <param name="caption"></param>
        public void SetPopUpOperationSatusManagerCaption(string caption)
        {
            barButtonItemOperationSatusManager.Caption = caption;
        }
        public void SetPopUpOperationSatusManagerVisible(bool bVisible)
        {
            if (bVisible)
            {
                barButtonItemOperationSatusManager.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                barButtonItemOperationSatusManager.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }


        public void SetPopUpOperationSatusManagerCaption2(string caption)
        {
            if (string.IsNullOrEmpty(caption))
                barButtonItemToAnesEnd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            else
            {
                barButtonItemToAnesEnd.Caption = caption;
                barButtonItemToAnesEnd.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
        }

        //设置转入病房、转PACU是否可见
        public void SetPopUpBarVisible(bool bVisible)
        {
            if (bVisible)
            {
                barButtonItemTurnToRoom.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barButtonItemTrunToPACU.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barButtonItemTurnToICU.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barButtonItemDictTurnToPACU.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                barButtonItemTurnToRoom.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItemTrunToPACU.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItemTurnToICU.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItemDictTurnToPACU.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        private void PatientStatusContrl_Load(object sender, EventArgs e)
        {
            //初始化弹出框状态
            barButtonItemOperationSatusManager.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barButtonItemTurnToRoom.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barButtonItemTrunToPACU.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barButtonItemToAnesEnd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barButtonItemDictTurnToPACU.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

        }

        public void SetPopUpOperationSatusPACU(bool bVisible)
        {
            if (bVisible)
            {
                if (ApplicationConfiguration.IsPACUProcess)
                {
                    barButtonItemTrunToPACU.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    barButtonItemTrunToPACU.Caption = "入PACU室申请";
                    barButtonItemDictTurnToPACU.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    barButtonItemDictTurnToPACU.Caption = "进PACU室";
                }
                else
                {
                    barButtonItemTrunToPACU.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    barButtonItemTrunToPACU.Caption = "入PACU室申请";
                    barButtonItemDictTurnToPACU.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    barButtonItemDictTurnToPACU.Caption = "进PACU室";
                }
            }
            else
            {
                barButtonItemTrunToPACU.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItemTrunToPACU.Caption = "入PACU室申请";
                barButtonItemDictTurnToPACU.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItemDictTurnToPACU.Caption = "进PACU室";
            }
        }

        private void barButtonItemOperationSatusManager_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult res = XtraMessageBox.Show("此操作将改变状态，确定执行？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.No)
                return;

            string statusCap = "";
            OperationStatus operationStatus = OperationStatus.IsReady;

            if (e.Item.Caption.Contains("取消状态【入手术室】"))
            {
                AnesInformations.OperationMasterDataTable data = (new AnesthesiaSheetDA()).GetOperationMaster(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID);
                if (data != null && data.Count > 0 && !data[0].IsINDUCE_START_TIMENull())
                {
                    operationStatus = OperationStatus.OutYouDao;
                }
                else
                {
                    operationStatus = OperationStatus.IsReady;
                }


                //operationStatus = OperationStatus.IsReady;

                if (operationStatus != ExtendApplicationContext.Current.OperationStatus)
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatus, DateTime.MinValue, true, ExtendApplicationContext.Current.OperationStatus))
                    {
                        ClearPatientRoom(ExtendApplicationContext.Current.PatientContext.PatientID);
                        ClearPatientMonitor(ExtendApplicationContext.Current.PatientContext.PatientID, 0);
                        NoifyOperationStatusChange(operationStatus);

                    }
                }
                //删除时间
                foreach (SinglePatientStatusConrol singlePatientStatusConrol in this.panelMain.Controls)
                {
                    //先时间清空数据,
                    singlePatientStatusConrol.SetOperationStatusTimeText(DateTime.MinValue);
                }
            }

            else if (e.Item.Caption.Contains("转到状态【入手术室】"))
            {

                operationStatus = OperationStatus.InOperationRoom;

                if (operationStatus != ExtendApplicationContext.Current.OperationStatus)
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatus, DateTime.MinValue, true, ExtendApplicationContext.Current.OperationStatus))
                    {
                        NoifyOperationStatusChange(operationStatus);
                    }
                }
                statusCap = "入手术室";
            }
            else if (e.Item.Caption.Contains("转到状态【麻醉开始】"))
            {
                operationStatus = OperationStatus.AnesthesiaStart;

                if (operationStatus != ExtendApplicationContext.Current.OperationStatus)
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatus, DateTime.MinValue, true, ExtendApplicationContext.Current.OperationStatus))
                    {
                        NoifyOperationStatusChange(operationStatus);
                    }
                }
                statusCap = "麻醉开始";
            }
            else if (e.Item.Caption.Contains("转到状态【手术开始】"))
            {

                operationStatus = OperationStatus.OperationStart;

                if (operationStatus != ExtendApplicationContext.Current.OperationStatus)
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatus, DateTime.MinValue, true, ExtendApplicationContext.Current.OperationStatus))
                    {
                        NoifyOperationStatusChange(operationStatus);
                    }
                }
                statusCap = "手术开始";
            }
            else if (e.Item.Caption.Contains("转到状态【手术结束】"))
            {

                operationStatus = OperationStatus.OperationEnd;

                if (operationStatus != ExtendApplicationContext.Current.OperationStatus)
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatus, DateTime.MinValue, true, ExtendApplicationContext.Current.OperationStatus))
                    {
                        NoifyOperationStatusChange(operationStatus);
                    }
                }

                statusCap = "手术结束";
            }
            else if (e.Item.Caption.Contains("转到状态【麻醉结束】"))
            {

                operationStatus = OperationStatus.AnesthesiaEnd;

                if (operationStatus != ExtendApplicationContext.Current.OperationStatus)
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatus, DateTime.Now, true, ExtendApplicationContext.Current.OperationStatus))
                    {
                        NoifyOperationStatusChange(operationStatus);
                    }
                }

                statusCap = "麻醉结束";
            }
            else if (e.Item.Caption.Contains("转入病房"))
            {

                operationStatus = OperationStatus.TurnToSickRoom;

                if (operationStatus != ExtendApplicationContext.Current.OperationStatus)
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatus, DateTime.MinValue, true, ExtendApplicationContext.Current.OperationStatus))
                    {
                        NoifyOperationStatusChange(operationStatus);
                    }
                }
                SaveSetting("2");
                statusCap = "转入病房";
            }
            else if (e.Item.Caption.Contains("转入ICU"))
            {

                operationStatus = OperationStatus.TurnToICU;

                if (operationStatus != ExtendApplicationContext.Current.OperationStatus)
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatus, DateTime.MinValue, true, ExtendApplicationContext.Current.OperationStatus))
                    {
                        NoifyOperationStatusChange(operationStatus);
                    }
                }
                SaveSetting("3");
                statusCap = "转入ICU";
            }
            else if (e.Item.Caption.Contains("入PACU室申请"))
            {
                if (PACUProcess.AquireInPACU())
                {
                    XtraMessageBox.Show("已提交入PACU室申请，正在等待PACU室确认", "提示信息", MessageBoxButtons.OK);
                }
                else
                    XtraMessageBox.Show("提交申请失败，请检查数据连接", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (e.Item.Caption.Contains("进PACU室"))
            {
                if (!CheckBedForTrun())//如果没有空床
                {
                    XtraMessageBox.Show("PACU室内没有空缺的床位，暂时不能转入，请稍候再试！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                operationStatus = OperationStatus.TurnToPACU;
                //AquireInPACU(3);
                SaveSetting("1");
                if (operationStatus != ExtendApplicationContext.Current.OperationStatus)
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatus, DateTime.MinValue, true, ExtendApplicationContext.Current.OperationStatus))
                    {
                        NoifyOperationStatusChange(operationStatus);
                    }
                }

                statusCap = "准备复苏";
            }
            else if (e.Item.Caption.Contains("进复苏室"))
            {


                if (!CheckBedForTrun())//如果没有空床
                {
                    XtraMessageBox.Show("复苏室内没有空缺的床位，暂时不能转入，请稍候再试！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                operationStatus = OperationStatus.TurnToPACU;


                if (operationStatus != ExtendApplicationContext.Current.OperationStatus)
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatus, DateTime.MinValue, true, ExtendApplicationContext.Current.OperationStatus))
                    {
                        NoifyOperationStatusChange(operationStatus);
                    }
                }

                statusCap = "准备复苏";
            }
            else if (e.Item.Caption.Contains("取消状态【入复苏室】"))
            {

                operationStatus = OperationStatus.TurnToPACU;

                if (operationStatus != ExtendApplicationContext.Current.OperationStatus)
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatus, DateTime.MinValue, true, ExtendApplicationContext.Current.OperationStatus))
                    {
                        NoifyOperationStatusChange(operationStatus);
                    }
                }
                statusCap = "准备复苏";
            }
            //else if (e.Item.Caption.Contains("转到状态【入复苏室】"))
            //{

            //    operationStatus = OperationStatus.InPACU;

            //    if (operationStatus != ExtendApplicationContext.Current.OperationStatus)
            //    {
            //        if (UpdateOperationStatusOrStatusTime(operationStatus, DateTime.MinValue, true, ExtendApplicationContext.Current.OperationStatus))
            //        {
            //            NoifyOperationStatusChange(operationStatus);
            //        }
            //    }
            //    statusCap = "入复苏室";
            //}

            else if (e.Item.Caption.Contains("取消状态【入诱导室】"))
            {

                operationStatus = OperationStatus.IsReady;

                if (operationStatus != ExtendApplicationContext.Current.OperationStatus)
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatus, DateTime.MinValue, true, ExtendApplicationContext.Current.OperationStatus))
                    {
                        ClearPatientRoom(ExtendApplicationContext.Current.PatientContext.PatientID);
                        ClearPatientMonitor(ExtendApplicationContext.Current.PatientContext.PatientID, 0);
                        NoifyOperationStatusChange(operationStatus);

                    }
                }
                //删除时间
                foreach (SinglePatientStatusConrol singlePatientStatusConrol in this.panelMain.Controls)
                {
                    //先时间清空数据,
                    singlePatientStatusConrol.SetOperationStatusTimeText(DateTime.MinValue);
                }
            }
            else if (e.Item.Caption.Contains("转到死亡"))
            {

                operationStatus = OperationStatus.Dead;

                if (operationStatus != ExtendApplicationContext.Current.OperationStatus)
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatus, DateTime.MinValue, true, ExtendApplicationContext.Current.OperationStatus))
                    {
                        NoifyOperationStatusChange(operationStatus);
                    }
                }

                statusCap = "转到死亡";
            }
            if (statusCap == "")
                return;

            AnesInformations.OperationMasterDataTable dataTable = (new AnesthesiaSheetDA()).GetOperationMaster(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID);
            if (dataTable == null || dataTable.Count != 1)
            {
                return;
            }


            int operationStatusValue = (int)OperationStatusHelper.OperationStatusFromString(statusCap);
            //循环判断将后面的状态置空
            foreach (SinglePatientStatusConrol singlePatientStatusConrol in this.panelMain.Controls)
            {
                int operationStatusValueTemp = (int)OperationStatusHelper.OperationStatusFromString(singlePatientStatusConrol.StatusName);

                //判断后面的状态是否有时间
                if (operationStatusValueTemp > operationStatusValue)
                {

                    string fdName = OperationStatusHelper.GetTimeFieldName(OperationStatusHelper.OperationStatusFromString(singlePatientStatusConrol.StatusName));
                    dataTable[0][fdName] = DBNull.Value;
                    singlePatientStatusConrol.SetOperationStatusTimeText(DateTime.MinValue);
                }

            }
            (new AnesthesiaSheetDA()).UpdateOperationMaster(dataTable);
        }


        private bool CheckBedForTrun()
        {
            bool isFind = false;
            //加载手术间 字典
            Dict.OperatingRoomDataTable operatingRoomDataTable = null;
            if (ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_OPER_ROOM"))
            {
                operatingRoomDataTable = ExtendApplicationContext.Current.CodeTables["WIS_OPER_ROOM"] as Dict.OperatingRoomDataTable;
            }
            else
            {
                operatingRoomDataTable = (new DictDA()).GetOperatingRoomDict();
            }


            if (operatingRoomDataTable != null)
            {
                List<string> bedNos = new List<string>();
                foreach (Dict.OperatingRoomRow row in operatingRoomDataTable)
                {
                    if (!row.IsBED_TYPENull() && row.BED_TYPE.Equals("1"))
                    {
                        if (row.IsPAT_IDNull())
                        {
                            isFind = true;
                            break;
                        }
                        else
                        {
                            string bedPatientID = row.PAT_ID;
                            if (string.IsNullOrEmpty(row.PAT_ID)) //有空床
                            {
                                isFind = true;
                                break;
                            }
                            else
                            {

                            }
                        }


                    }
                }
            }

            return isFind;

        }
        private void barButtonItemTurnToRoom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            barButtonItemOperationSatusManager_ItemClick(sender, e);
        }

        private void barButtonItemTrunToPACU_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barButtonItemOperationSatusManager_ItemClick(sender, e);
        }
        private void barButtonItemDictTurnToPACU_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barButtonItemOperationSatusManager_ItemClick(sender, e);
        }
        #endregion


        #region "时间状态事件处理"

        /// <summary>
        ///清除患者手术间安排
        /// </summary>
        /// <param name="patientID"></param>
        public bool ClearPatientRoom(string patientID)
        {
            bool result = false;
            //加载手术间 字典
            Dict.OperatingRoomDataTable operatingRoomDataTable = null;
            //if (ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_OPER_ROOM"))
            //{
            //    operatingRoomDataTable = ExtendApplicationContext.Current.CodeTables["WIS_OPER_ROOM"] as Dict.OperatingRoomDataTable;
            //}
            //else
            {
                operatingRoomDataTable = (new DictDA()).GetOperatingRoomDict();
            }


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
                int ret = (new DictDA()).UpdateOperatingRoomDict(operatingRoomDataTable);
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
        public bool ClearPatientMonitor(string patientID, decimal eventNo)
        {
            bool result = false;
            Dict.MonitorDictDataTable monitorTable = (new DictDA()).GetMonitorDict(eventNo);
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
                int ret = (new DictDA()).UpdateMonitorDict(monitorTable);
                if (ret > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// 更新患者状态或者时间
        /// </summary>
        /// <param name="operationStatus">新状态</param>
        /// <param name="dt">状态对应时间</param>
        /// <returns></returns>
        public bool UpdateOperationStatusOrStatusTime(OperationStatus operationStatus, DateTime dt, bool updateStatus, OperationStatus oldOperationStatus)
        {
            AnesInformations.OperationMasterDataTable dataTable = (new AnesthesiaSheetDA()).GetOperationMaster(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID);
            if (dataTable != null && dataTable.Count == 1)
            {
                if (updateStatus)
                {
                    ///取消诱导室采集
                    if (oldOperationStatus == OperationStatus.InYouDao || oldOperationStatus == OperationStatus.InPACU)
                    {
                        ClearPatientRoom(ExtendApplicationContext.Current.PatientContext.PatientID);
                        ClearPatientMonitor(ExtendApplicationContext.Current.PatientContext.PatientID, 1);

                        ClearPatientMonitor(ExtendApplicationContext.Current.PatientContext.PatientID, 0);///取消诱导室采集
                        
                    }
                    else if (operationStatus == OperationStatus.OutOperationRoom)
                    {

                        ClearPatientRoom(ExtendApplicationContext.Current.PatientContext.PatientID);
                        if (_outPatients.ContainsKey(ExtendApplicationContext.Current.PatientContext.PatientID))
                        {
                            _outPatients[ExtendApplicationContext.Current.PatientContext.PatientID] = dt;
                        }
                        else
                        {
                            _outPatients.Add(ExtendApplicationContext.Current.PatientContext.PatientID, dt);
                        }
                    }
                    else if (operationStatus != OperationStatus.InOperationRoom && operationStatus != OperationStatus.AnesthesiaStart
                        && operationStatus != OperationStatus.OperationStart && operationStatus != OperationStatus.AnesthesiaEnd
                        && operationStatus != OperationStatus.OperationEnd && operationStatus != OperationStatus.InPACU)
                    {
                        //dataTable[0].IN_PACU_DATE_TIME = DateTime.Now;
                        ClearPatientRoom(ExtendApplicationContext.Current.PatientContext.PatientID);
                        ClearPatientMonitor(ExtendApplicationContext.Current.PatientContext.PatientID, 0);
                    }
                    if (operationStatus == OperationStatus.InYouDao || operationStatus == OperationStatus.InPACU)
                    {
                        string roomNo = "";
                        dataTable[0].IN_PACU_DATE_TIME = DateTime.Now;
                        //加载手术间 字典
                        Dict.OperatingRoomDataTable operatingRoomDataTable = null;
                        //if (ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_OPER_ROOM"))
                        //{
                        //    operatingRoomDataTable = ExtendApplicationContext.Current.CodeTables["WIS_OPER_ROOM"] as Dict.OperatingRoomDataTable;
                        //}
                        //else
                        {
                            operatingRoomDataTable = (new DictDA()).GetOperatingRoomDict();
                        }


                        if (operatingRoomDataTable != null)
                        {
                            List<string> bedNos = new List<string>();
                            foreach (Dict.OperatingRoomRow row in operatingRoomDataTable)
                            {
                                if (!row.IsBED_TYPENull() && (row.BED_TYPE.Equals("1") || row.BED_TYPE.Equals("3")))//诱导液加上
                                {
                                    bedNos.Add(row.ROOM_NO);
                                }
                            }
                            if (bedNos.Count > 0)
                            {
                                //object bedNo = Dialog.SingleInputSelect("请选择床号", bedNos.ToArray());
                                if (patientStatusAction != null)
                                {
                                    object bedNo = patientStatusAction.Excute(operationStatus);
                                    if (bedNo != null)
                                    {
                                        roomNo = bedNo.ToString();
                                    }
                                }



                            }
                        }
                        if (string.IsNullOrEmpty(roomNo))
                        {
                            return false;
                        }
                        else
                        {
                            (new DictDA()).SetOperatingRoomPatient(operatingRoomDataTable, roomNo, ApplicationConfiguration.OpertionDeptCode, ExtendApplicationContext.Current.PatientContext.PatientID
                                , ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID);
                            (new DictDA()).UpdateOperatingRoomDict(operatingRoomDataTable);
                            (new DictDA()).SetMonitorDictPatient(1, ApplicationConfiguration.OpertionDeptCode, roomNo, ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID);
                        }
                    }
                    else if (operationStatus == OperationStatus.InOperationRoom)
                    {
                        string roomNo = "";
                        //加载手术间 字典
                        Dict.OperatingRoomDataTable operatingRoomDataTable = null;
                        //if (ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_OPER_ROOM"))
                        //{
                        //    operatingRoomDataTable = (Dict.OperatingRoomDataTable)ExtendApplicationContext.Current.CodeTables["WIS_OPER_ROOM"];
                        //}
                        //else
                        {
                            operatingRoomDataTable = (new DictDA()).GetOperatingRoomDict();
                        }


                        if (operatingRoomDataTable != null)
                        {
                            roomNo = ExtendApplicationContext.Current.PatientInformation.OperRoom;
                        }
                        if (string.IsNullOrEmpty(roomNo))
                        {
                            if (ApplicationConfiguration.UseDefaultOperatingRoom && !string.IsNullOrEmpty(ApplicationConfiguration.OpertionRoom) && !ApplicationConfiguration.OpertionRoom.Contains(","))
                            {
                                int ret = 0;
                                AnesInformations.OperationMasterDataTable operationMaster = (new AnesthesiaSheetDA()).GetOperationMaster(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID);
                                if (operationMaster != null && operationMaster.Count == 1)
                                {
                                    operationMaster[0].OPERATING_ROOM_NO = ApplicationConfiguration.OpertionRoom;
                                    ret = (new AnesthesiaSheetDA()).UpdateOperationMaster(operationMaster);
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
                            if (ApplicationConfiguration.UseDefaultOperatingRoom && !string.IsNullOrEmpty(ApplicationConfiguration.OpertionRoom) && !ApplicationConfiguration.OpertionRoom.Contains(",") && !ApplicationConfiguration.OpertionRoom.Equals(roomNo))
                            {
                                if (Dialog.MessageBox("要把当前患者从 " + roomNo + "号间转到" + ApplicationConfiguration.OpertionRoom + "号间吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                {
                                    return false;
                                }
                                int ret = 0;
                                AnesInformations.OperationMasterDataTable operationMaster = (new AnesthesiaSheetDA()).GetOperationMaster(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID);
                                if (operationMaster != null && operationMaster.Count == 1)
                                {
                                    operationMaster[0].OPERATING_ROOM_NO = ApplicationConfiguration.OpertionRoom;
                                    ret = (new AnesthesiaSheetDA()).UpdateOperationMaster(operationMaster);
                                }
                                if (ret <= 0)
                                {
                                    return false;
                                }
                                else
                                {
                                    ExtendApplicationContext.Current.PatientInformation.OperRoom = ApplicationConfiguration.OpertionRoom;
                                    RaiseRefreshPatient();

                                    //刷新 界面

                                    //lblRoomNo.Text = ExtendApplicationContext.Current.PatientInformation.OperRoom;

                                    //ActionFactory.MainFormBase.RefreshPatInfo();

                                }
                            }
                            (new DictDA()).SetOperatingRoomPatient(operatingRoomDataTable, roomNo, ApplicationConfiguration.OpertionDeptCode, ExtendApplicationContext.Current.PatientContext.PatientID
                                , ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID);
                            (new DictDA()).UpdateOperatingRoomDict(operatingRoomDataTable);
                        }
                    }else if(operationStatus == OperationStatus.Dead)
                    {
                        ClearPatientRoom(ExtendApplicationContext.Current.PatientContext.PatientID);
                        ClearPatientMonitor(ExtendApplicationContext.Current.PatientContext.PatientID, 0);
                    }
                    dataTable[0].OPER_STATUS = (decimal)(int)operationStatus;
                }
                string fieldName = OperationStatusHelper.GetTimeFieldName(operationStatus);
                if (dt != DateTime.MinValue && dt != DateTime.MaxValue && dt != null)
                {
                    dataTable[0][fieldName] = dt;
                }
                int result = (new AnesthesiaSheetDA()).UpdateOperationMaster(dataTable);

                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }




        /// <summary>
        /// 取消手术 病案提交
        /// </summary>
        public bool CancelOrCommitOperation(OperationStatus operationStatus, string cancelReason)
        {

            if (operationStatus == OperationStatus.Done || operationStatus == OperationStatus.CancelOperation)
            {

                ClearPatientRoom(ExtendApplicationContext.Current.PatientContext.PatientID);
                ClearPatientMonitor(ExtendApplicationContext.Current.PatientContext.PatientID, 0);


                if (UpdateOperationStatusOrStatusTime(operationStatus, DateTime.MinValue, true, ExtendApplicationContext.Current.OperationStatus))
                {
                    NoifyOperationStatusChange(operationStatus);
                }
                ExtendApplicationContext.Current.OperationStatus = operationStatus;
                if (operationStatus == OperationStatus.CancelOperation)
                {
                    AnesInformations.OperationMasterDataTable masterTable = (new AnesthesiaSheetDA()).GetOperationMaster(ExtendApplicationContext.Current.PatientInformation.PatientID, ExtendApplicationContext.Current.PatientInformation.VisitID, ExtendApplicationContext.Current.PatientInformation.OperID);
                    if (masterTable.Count > 0)
                    {
                        CareDocsDA careDocsDA = new CareDocsDA();
                        CareDocs.OperationCanceledDataTable cdata = careDocsDA.GetOperationCanceled(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID);
                        decimal maxno = 0;
                        if (cdata != null && cdata.Count > 0)
                        {
                            foreach (CareDocs.OperationCanceledRow row in cdata)
                            {
                                if (row.CANCEL_ID > maxno)
                                {
                                    maxno = row.CANCEL_ID;
                                }
                            }
                        }
                        maxno++;
                        CareDocs.OperationCanceledRow OperationCanceledRow = cdata.NewOperationCanceledRow();
                        OperationCanceledRow.PAT_ID = masterTable[0].PAT_ID;
                        OperationCanceledRow.VISIT_ID = masterTable[0].VISIT_ID;
                        OperationCanceledRow.CANCEL_ID = maxno;
                        if (!masterTable[0].IsDEPT_STAYEDNull())
                        {
                            OperationCanceledRow.DEPT_STAYED = masterTable[0].DEPT_STAYED;
                        }
                        if (!masterTable[0].IsSCHEDULED_DATE_TIMENull())
                        {
                            OperationCanceledRow.SCHEDULED_DATE_TIME = masterTable[0].SCHEDULED_DATE_TIME;
                        }
                        if (!masterTable[0].IsOPERATING_ROOMNull())
                        {
                            OperationCanceledRow.OPERATING_ROOM = masterTable[0].OPERATING_ROOM;
                        }
                        if (!masterTable[0].IsOPERATING_ROOM_NONull())
                        {
                            OperationCanceledRow.OPERATING_ROOM_NO = masterTable[0].OPERATING_ROOM_NO;
                        }
                        if (!masterTable[0].IsSEQUENCENull())
                        {
                            OperationCanceledRow.SEQUENCE = masterTable[0].SEQUENCE;
                        }
                        if (!masterTable[0].IsDIAG_BEFORE_OPERNull())
                        {
                            OperationCanceledRow.DIAG_BEFORE_OPER = masterTable[0].DIAG_BEFORE_OPER;
                        }
                        if (!masterTable[0].IsPAT_CONDITIONNull())
                        {
                            OperationCanceledRow.PAT_CONDITION = masterTable[0].PAT_CONDITION;
                        }
                        if (!masterTable[0].IsOPER_SCALENull())
                        {
                            OperationCanceledRow.OPER_SCALE = masterTable[0].OPER_SCALE;
                        }
                        if (!OperationCanceledRow.IsISOLATION_INDICATORNull())
                        {
                            OperationCanceledRow.ISOLATION_INDICATOR = masterTable[0].ISOLATION_INDICATOR;
                        }
                        if (!masterTable[0].IsOPERATING_DEPTNull())
                        {
                            OperationCanceledRow.OPERATING_DEPT = masterTable[0].OPERATING_DEPT;
                        }
                        if (!masterTable[0].IsSURGEONNull())
                        {
                            OperationCanceledRow.SURGEON = masterTable[0].SURGEON;
                        }
                        if (!masterTable[0].IsFIRST_ASSISTANTNull())
                        {
                            OperationCanceledRow.FIRST_ASSISTANT = masterTable[0].FIRST_ASSISTANT;
                        }
                        if (!masterTable[0].IsSECOND_ASSISTANTNull())
                        {
                            OperationCanceledRow.SECOND_ASSISTANT = masterTable[0].SECOND_ASSISTANT;
                        }
                        if (!masterTable[0].IsTHIRD_ASSISTANTNull())
                        {
                            OperationCanceledRow.THIRD_ASSISTANT = masterTable[0].THIRD_ASSISTANT;
                        }
                        if (!masterTable[0].IsFOURTH_ASSISTANTNull())
                        {
                            OperationCanceledRow.FOURTH_ASSISTANT = masterTable[0].FOURTH_ASSISTANT;
                        }
                        if (!masterTable[0].IsANES_METHODNull())
                        {
                            OperationCanceledRow.ANES_METHOD = masterTable[0].ANES_METHOD;
                        }
                        if (!masterTable[0].IsANES_DOCTORNull())
                        {
                            OperationCanceledRow.ANES_DOCTOR = masterTable[0].ANES_DOCTOR;
                        }
                        if (!masterTable[0].IsANES_ASSISTANTNull())
                        {
                            OperationCanceledRow.ANES_ASSISTANT = masterTable[0].ANES_ASSISTANT;
                        }
                        if (!masterTable[0].IsBLOOD_TRAN_DOCTORNull())
                        {
                            OperationCanceledRow.BLOOD_TRAN_DOCTOR = masterTable[0].BLOOD_TRAN_DOCTOR;
                        }
                        if (!masterTable[0].IsOPERATION_IDNull())
                        {
                            OperationCanceledRow.OPERATION_ID = masterTable[0].OPERATION_ID;
                        }
                        OperationCanceledRow.CANCEL_REASON = cancelReason;
                        OperationCanceledRow.ENTERED_BY = ExtendApplicationContext.Current.LoginUserContext.HisUserID;
                        cdata.AddOperationCanceledRow(OperationCanceledRow);
                        if (careDocsDA.UpdateOperationCanceled(cdata) > 0)
                        {
                            CareDocs.OperationNameDataTable operationNamePatientTable = careDocsDA.GetOperationName(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID,
    ExtendApplicationContext.Current.PatientContext.OperID);
                            if (operationNamePatientTable != null && operationNamePatientTable.Count > 0)
                            {
                                CareDocs.OperationNameCanceledDataTable OperationNameCanceledTable = careDocsDA.GetOperationNameCanceled(OperationCanceledRow.PAT_ID, OperationCanceledRow.VISIT_ID, OperationCanceledRow.CANCEL_ID);
                                if (OperationNameCanceledTable != null)
                                {
                                    if (OperationNameCanceledTable.Count > 0)
                                    {
                                        foreach (CareDocs.OperationNameCanceledRow crow in OperationNameCanceledTable)
                                        {
                                            crow.Delete();
                                        }
                                        careDocsDA.UpdateOperationNameCanceled(OperationNameCanceledTable);
                                    }
                                    foreach (CareDocs.OperationNameRow orow in operationNamePatientTable)
                                    {
                                        CareDocs.OperationNameCanceledRow newrow = OperationNameCanceledTable.NewOperationNameCanceledRow();
                                        newrow.PAT_ID = OperationCanceledRow.PAT_ID;
                                        newrow.VISIT_ID = OperationCanceledRow.VISIT_ID;
                                        newrow.CANCEL_ID = OperationCanceledRow.CANCEL_ID;
                                        newrow.OPER_NO = orow.OPER_NO;
                                        newrow.OPER_NAME = orow.OPER_NAME;
                                        if (!orow.IsOPER_SCALENull())
                                        {
                                            newrow.OPER_SCALE = orow.OPER_SCALE;
                                        }
                                        if (!orow.IsOPER_CODENull())
                                        {
                                            newrow.OPER_CODE = orow.OPER_CODE;
                                        }
                                        OperationNameCanceledTable.AddOperationNameCanceledRow(newrow);
                                    }
                                    careDocsDA.UpdateOperationNameCanceled(OperationNameCanceledTable);
                                }
                            }
                        }
                    }

                }
                return true;
            }
            return false;

        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                try
                {
                    DateTime dtNow = DateTime.Now;
                    List<string> removePat = new List<string>();
                    foreach (KeyValuePair<string, DateTime> outPat in _outPatients)
                    {
                        if (dtNow >= outPat.Value)
                        {
                            ClearPatientMonitor(outPat.Key, 0);
                            removePat.Add(outPat.Key);
                        }
                    }

                    foreach (string patId in removePat)
                    {
                        _outPatients.Remove(patId);
                    }
                }
                catch (Exception err)
                {
                    ExceptionHandler.Handle(err, false);
                }

                // 处理复苏申请
                try
                {
                    if (ExtendApplicationContext.Current.AppType == ApplicationType.Anesthesia)
                    {
                        PACUProcess.ShowPacuMsg();
                    }
                    else if (ExtendApplicationContext.Current.AppType == ApplicationType.PACU)
                    {
                        PACUProcess.CheckPacuWait();
                    }
                }
                catch (Exception err)
                {
                }

            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barButtonItemOperationSatusManager_ItemClick(sender, e);
        }

        private void SaveSetting(string value)
        {
            string _patientID = ExtendApplicationContext.Current.PatientContext.PatientID;
            decimal _visitID = ExtendApplicationContext.Current.PatientContext.VisitID;
            decimal _operID = ExtendApplicationContext.Current.PatientContext.OperID;
            CareDocs.WIS_CUSTOM_DATADataTable customData = new CareDocsDA().GetCustomData(_patientID, (int)_visitID, (int)_operID);
            SaveCustomDataRow(customData, _patientID, (int)_visitID, (int)_operID, "手术结束.回病室", value);
            int ret = new CareDocsDA().UpdateCustomData(customData);
        }
        private void SaveCustomDataRow(CareDocs.WIS_CUSTOM_DATADataTable dataTable, string patientID, int visitID, int operID, string itemName, string itemValue)
        {
            CareDocs.WIS_CUSTOM_DATARow row1 = dataTable.FindByPAT_IDVISIT_IDOPER_IDITEM_NAME(patientID, visitID, operID, itemName);
            if (row1 == null)
            {
                AddCustomDataRow(dataTable, patientID, visitID, operID, itemName, itemValue);
            }
            else
            {
                row1.ITEM_VALUE = itemValue;
            }
        }

        private void PostHisOperationTimes(string StatusName,DateTime dt)
        {
            SyncDA syncDA = new SyncDA();
            string ret;
            if (StatusName == "麻醉开始")
            {
                ret = syncDA.SyncOperationTimesInfo(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID,dt, "MES0083");
            }
            else if(StatusName == "手术开始")
            {
                ret = syncDA.SyncOperationTimesInfo(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID, dt, "MES0082");

            }
            else if (StatusName == "手术结束")
            {
                ret = syncDA.SyncOperationTimesInfo(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID, dt, "MES0085");

            }
            else if (StatusName == "麻醉结束")
            {
                ret = syncDA.SyncOperationTimesInfo(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID, dt, "MES0084");

            }
        }
    }
}
