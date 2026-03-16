using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Documents;
using Wis.Anes.Framework;
using Wis.Anes.Framework.Documents.DefaultHandlers;
using Wis.Anes.BusinessEntity;
using Wis.Anes.DataAccess;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.Framework.Doc;
using Wis.Anes.Framework.Controls;
using Wis.Anes.Custom.CustomProject.AnesDocHandlers;
using Wis.Anes.Framework.Utilities;
using Wis.Anes.Custom.CustomProject.CustomSetting;
using Wis.Anes.Custom.CustomProject.Framework;
using DevExpress.XtraEditors;
using Wis.Anes.Framework.Views;

namespace Wis.Anes.Custom.CustomProject
{
    /// <summary>
    /// 麻醉单实现代码
    /// </summary>
    public partial class AnesDoc : CustomBaseDoc
    {
        /// <summary>
        /// 事件类型：0-麻醉 1-复苏
        /// </summary>
        private int _eventNo = 0;
        /// <summary>
        /// 麻醉单开始时间和结束时间
        /// </summary>
        private DateTimeRange _dateTimeRange = null;
        private DateTime _operTime;
        private string _anesMethod;
        AnesInformations.AnesthesiaEventDataTable _anesEvent = null;
        AnesInformations.VitalSignDataTable _vitalSign = null;

        public AnesDoc()
        {
            InitializeComponent();
            base.Caption = "麻醉单";
            this.BackColor = Color.White;
            base.DocKind = DocKind.Anes;
            //if (ApplicationConfiguration.IsPACUProgram)
            //{
            //    base.DocKind = DocKind.PACU;
            //    _eventNo = 1;
            //}
            base.ApplyDataTemplate.Visible = false;
            base.SaveDataTemplate.Visible = false;
            if (ApplicationConfiguration.IsYouDaoProgram)
            {
                _eventNo = 3;
            }
            ExtendApplicationContext.Current.EventNo = _eventNo;
            //_pageHours = 5;
            _pageHours = ApplicationConfiguration.AnesDocPageHours;
        }



        /// <summary>
        /// 初始化自定义的UIElementHandler
        /// </summary>
        /// <param name="handlers"></param>
        protected override void AddCustomUIElementHandlers(List<IUIElementHandler> handlers)
        {
            IUIElementHandler handlerTemp = null;
            foreach (IUIElementHandler handler in handlers)
            {
                if (handler is LabelHandler)
                {
                    handlerTemp = handler;
                    break;
                }
            }
            if (handlerTemp != null)
            {
                handlers.Remove(handlerTemp);
            }

            handlerTemp = null;
            foreach (IUIElementHandler handler in handlers)
            {
                if (handler is TextBoxHandler)
                {
                    handlerTemp = handler;
                    break;
                }
            }
            if (handlerTemp != null)
            {
                handlers.Remove(handlerTemp);
            }


            handlers.Add(new SDLabelHandler());
            handlers.Add(new SDTextBoxHandler());
            handlers.Add(new DrugGraphHandler());
            handlers.Add(new GridGraphHandler());
            handlers.Add(new SHATMedSheetHandler(0));
            handlers.Add(new AnesSheetDetailsHandler());
            handlers.Add(new VitalSignGraphHandler());
            handlers.Add(new LegengGraphHandler());
            //if (ReportViewer != null)
            //{
            //    ReportViewer.Paint -= new PaintEventHandler(ReportViewer_Paint);
            //    ReportViewer.Paint += new PaintEventHandler(ReportViewer_Paint);
            //}
        }

        //private void ReportViewer_Paint(object sender, PaintEventArgs e)
        //{
        //    CustomDraw(e.Graphics, 0, 0);
        //}

        //private void CustomDraw(Graphics g, float x, float y)
        //{
        //    Font font = new Font("宋体", 9);
        //    Brush brush = Brushes.Black;
        //    float left = 879;
        //    float top = 1000;
        //    float scale = 13.5f;
        //    float top1 = 26.4f;
        //    float ySpan = 14;
        //    g.DrawString("10", font, brush, x + left, y + top);
        //    g.DrawString("12", font, brush, x + left, y + top - top1);
        //    for (int i = 16; i < 41; i += 2)
        //    {
        //        g.DrawString(i.ToString(), font, brush, x + left, y + top - top1 - (i - ySpan) * scale);
        //    }
        //    g.DrawString("℃", font, brush, x + left, y + top - top1 - (42 - ySpan) * scale);
        //    font.Dispose();
        //}

        //public override void CustomDraw(Graphics g)
        //{
        //    CustomDraw(g, 0, -13);
        //}

        /// <summary>
        /// 生成数据源
        /// </summary>
        /// <param name="dataSource"></param>
        protected override void BuildData(Dictionary<string, DataTable> dataSource)
        {
            dataSource.Clear();

            //string patientKey = ExtendApplicationContext.Current.PatientKey;

            var operationMaster = DataContext.GetCurrent().GetData("WIS_OPER_MASTER") as AnesInformations.OperationMasterDataTable;
            _operTime = operationMaster[0].SCHEDULED_DATE_TIME;
            _anesMethod = operationMaster[0].ANES_METHOD;
            _anesEvent = DataContext.GetCurrent().GetAnesthesiaEvent(_eventNo);
            //_anesEvent = DataContext.GetCurrent().GetAnesthesiaEvent();
            _vitalSign = DataContext.GetCurrent().GetVitalSignData(_eventNo);
            //_vitalSign = DataContext.GetCurrent().GetVitalSignData();

            dataSource["WIS_OPER_MASTER"] = operationMaster;
            dataSource["WIS_OPER_ANALGESIC"] = DataContext.GetCurrent().GetData("WIS_OPER_ANALGESIC");
            dataSource["WIS_CUSTOM_DATA"] = DataContext.GetCurrent().GetData("WIS_CUSTOM_DATA");
            dataSource["WIS_PAT_MONITOR_DATA_EXT"] = DataContext.GetCurrent().GetData("WIS_PAT_MONITOR_DATA_EXT");
            dataSource["WIS_ANES_OPER_HANDOVER"] = DataContext.GetCurrent().GetData("WIS_ANES_OPER_HANDOVER");
            dataSource["WIS_ANES_PLAN"] = DataContext.GetCurrent().GetData("WIS_ANES_PLAN");
            dataSource["WIS_PAT_MASTER_INDEX"] = DataContext.GetCurrent().GetData("WIS_PAT_MASTER_INDEX");
            dataSource["WIS_PAT_IN_HOS"] = DataContext.GetCurrent().GetData("WIS_PAT_IN_HOS");
            dataSource["WIS_PAT_VISIT"] = DataContext.GetCurrent().GetData("WIS_PAT_VISIT");
            dataSource["AnesAllEvent"] = _anesEvent;
            //获取起始时间和结束时间
            _dateTimeRange = base.GetGraphDateTime(_vitalSign, _anesEvent, _eventNo, operationMaster);
            _dateTimeRange.OrigiStartDateTime = _dateTimeRange.StartDateTime;
            _dateTimeRange.OrigiEndDateTime = _dateTimeRange.EndDateTime;

            base.AdjustDateTimeRange(TimeScaleType.FiveMinute, ref _dateTimeRange);

            if (_dateTimeRange.EndDateTime < _dateTimeRange.StartDateTime.AddHours(_pageHours))
            {
                _dateTimeRange.EndDateTime = _dateTimeRange.StartDateTime.AddHours(_pageHours);
            }
            AutoCalc();
        }
        /// <summary>
        /// 分页设置
        /// </summary>
        /// <param name="pagerSetting"></param>
        protected override void OnPagerSetting(PagerSetting pagerSetting)
        {
            pagerSetting.PagerDesc.Clear();
            pagerSetting.AllowPage = true;
            double hour = ((TimeSpan)(_dateTimeRange.EndDateTime - _dateTimeRange.StartDateTime)).TotalHours;
            int pageCount = (int)(hour / _pageHours);

            if (pageCount * _pageHours < hour)
            {
                pageCount++;
            }

            if (pageCount > 0)
            {
                for (int i = 0; i < pageCount; i++)
                {
                    pagerSetting.PagerDesc.Add(new PageDesc(i, true));
                    //计算当前页是否含有附页
                    if (HasAttachPage(i))
                    {
                        pagerSetting.PagerDesc.Add(new PageDesc(i, false));
                    }
                }
            }
            else
            {

            }
            

            //设置成第一页
            // pagerSetting.CurrentPageIndex = 0;
        }

        /// <summary>
        /// 分页导航事件
        /// </summary>
        /// <param name="currentPageIndex">当前页码</param>
        /// <param name="isMasterPage">是否为主页</param>
        /// <param name="dataSource">数据源</param>
        protected override void OnPageIndexChanged(int mainPageIndex, bool isMasterPage, Dictionary<string, DataTable> dataSource)
        {
            //根据页码获取本页的时间范围
            DateTimeRange dtRange = GetPageDateTimeRange(mainPageIndex);
            //根据时间范围设置一页的数据
            dataSource["AnesthesiaEvent"] = GetPageAnesEventDataByTimeSpan(dtRange);
            dataSource["VitalSignData"] = GetPageVitalSignDataByTimeSpan(dtRange);
            base.SetCurrentPageData(dtRange, isMasterPage, 5);

        }

        // <summary>
        // 文书上传前检查
        // </summary>
        // <returns></returns>
        //protected override bool CheckBeforeCommit()
        //{
        //    if (!AccessControl.CheckModifyRightForOperator("麻醉记录单") && ExtendApplicationContext.Current.AppType != ApplicationType.PACU)
        //    {
        //        Dialog.MessageBox("您没有上传该文书的权限！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return false;
        //    }
        //    AnesInformations.AnesthesiaEventDataTable anesEvent = DataContext.GetCurrent().GetAnesthesiaEvent(_eventNo);
        //    foreach (AnesInformations.AnesthesiaEventRow row in anesEvent)
        //    {
        //        PointType pointType = (GetDecimalValue(row["DURATIVE_INDICATOR"]) == 1 ? PointType.ProLonged : PointType.SinglePoint);
        //        if (pointType == PointType.ProLonged)
        //        {
        //            if (row["START_TIME"] != System.DBNull.Value)
        //            {
        //                if (row["END_DATE"] == System.DBNull.Value)
        //                {
        //                    Dialog.MessageBox("持续性 【" + row["ITEM_NAME"].ToString() + "】 已有开始时间，但是还没有结束时间，请确认文书完成后再上传 。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    return false;
        //                }
        //            }
        //        }
        //    }
        //    OperationStatus operStatus = ExtendApplicationContext.Current.OperationStatus;
        //    if (operStatus != OperationStatus.OutOperationRoom && operStatus != OperationStatus.TurnToPACU && operStatus != OperationStatus.TurnToSickRoom
        //         && operStatus != OperationStatus.InPACU && operStatus != OperationStatus.OutPACU && operStatus != OperationStatus.Done)
        //    {

        //        Dialog.MessageBox("只有 【出手术室】后才能上传麻醉单 。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return false;
        //    }

        //    return true;
        //}

        /// <summary>
        ///打印前检查，判断是否可以打印
        /// </summary>
        /// <returns></returns>
        protected override bool CheckBeforePrint()
        {
         

            if (!AccessControl.CheckModifyRightForOperator("麻醉记录单") && ExtendApplicationContext.Current.AppType != ApplicationType.PACU)
            {
                Dialog.MessageBox("您没有打印该文书的权限！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            //var operationMaster = DataContext.GetCurrent().GetData("WIS_OPER_MASTER") as AnesInformations.OperationMasterDataTable;
            AnesInformations.AnesthesiaEventDataTable anesEvent = DataContext.GetCurrent().GetAnesthesiaEvent(_eventNo);
            foreach (AnesInformations.AnesthesiaEventRow row in anesEvent)
            {
                PointType pointType = (GetDecimalValue(row["DURATIVE_INDICATOR"]) == 1 ? PointType.ProLonged : PointType.SinglePoint);
                if (pointType == PointType.ProLonged)
                {
                    if (row["START_DATE_TIME"] != System.DBNull.Value)
                    {
                        if (row["END_DATE_TIME"] == System.DBNull.Value)
                        {
                            if (Dialog.MessageBox("持续性 【" + row["ITEM_NAME"].ToString() + "】 已有开始时间，但是还没有结束时间，请确认是否继续打印 。", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            OperationStatus operStatus = ExtendApplicationContext.Current.OperationStatus;
            if (operStatus != OperationStatus.OutOperationRoom && operStatus != OperationStatus.TurnToPACU && operStatus != OperationStatus.TurnToSickRoom
                 && operStatus != OperationStatus.InPACU && operStatus != OperationStatus.OutPACU && operStatus != OperationStatus.Done)
            {
                //Dialog.MessageBox("只有 【转入病房】 或者【转入复苏】后才能打印麻醉单 。");
                //Dialog.MessageBox("只有 【出手术室】后才能打印麻醉单 。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (Dialog.MessageBox("病人还未 【出手术室】，是否继续打印 。", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
                {
                    return false;
                }
            }

			return base.CheckBeforePrint();
            //return true;
        }

        /// <summary>
        /// 自定义刷新数据
        /// </summary>
        /// <param name="currentPageIndex"></param>
        /// <param name="isMasterPage"></param>
        /// <param name="dataSource"></param>
        protected override void OnCustomRefresh(int mainPageIndex, bool isMasterPage, Dictionary<string, DataTable> dataSource)
        {
            //根据页码获取本页的时间范围
            DateTimeRange dtRange = GetPageDateTimeRange(mainPageIndex);

            //根据时间范围设置一页的数据
            dataSource["AnesthesiaEvent"] = GetPageAnesEventDataByTimeSpan(dtRange, true);
            dataSource["VitalSignData"] = GetPageVitalSignDataByTimeSpan(dtRange, true);

            base.RefreshCurrentControls(dtRange, new Type[] { typeof(MedAnesSheetDetails), typeof(MedDrugGraph), typeof(MedVitalSignGraph), typeof(MedLegengGraph) }, isMasterPage, 5);
        }
        /// <summary>
        /// 自定义刷新数据时候触发事件
        /// </summary>
        /// <param name="currentPageIndex"></param>
        /// <param name="isMasterPage"></param>
        /// <param name="dataSource"></param>
        //protected override void OnAfterRefreshData()
        //{
        //    foreach (IUIElementHandler handler in _UIElementHandlers)
        //    {
        //        if (handler is SDTextBoxHandler)
        //        {
        //            ((SDTextBoxHandler)handler).CalSumLiquidAndBlood();

        //                handler.HasDirty = false;

        //        }
        //    }
        //}
        /// <summary>
        /// 数据保存
        /// </summary>
        /// <param name="dataSource"></param>
        protected override void OnSaveData(Dictionary<string, DataTable> dataSource)
        {
            var td = dataSource["WIS_OPER_MASTER"];
            string ot = td.Rows[0]["OUT_DATE_TIME"].ToString();
            string st = td.Rows[0]["OPER_STATUS"].ToString();
            DataTable res1 = dataSource["WIS_CUSTOM_DATA"];
            var res = dataSource["WIS_CUSTOM_DATA"].Rows[0]["ITEM_NAME"].ToString();
            if (ot != "")
            {
                if (!IsExistItem_Name(res1))
                {
                    DialogResult dialogResult = XtraMessageBox.Show("未选择病人回病室状态，是否保存?",
                       "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }

                string ItemValue = GetItem_Value(res1);
                td.Rows[0]["OPER_STATUS"] = ItemValue;
                OperationStatus operationStatus = OperationStatus.IsReady;
                if (ItemValue == "40")
                {
                    operationStatus = OperationStatus.TurnToPACU;
                }else if(ItemValue == "61")
                {
                    operationStatus = OperationStatus.TurnToICU;
                }
                else
                {
                    operationStatus = OperationStatus.TurnToSickRoom;
                }
                if (operationStatus != ExtendApplicationContext.Current.OperationStatus)
                {
                    PatientStatusContrl patientStatusContrl = new PatientStatusContrl();
                    if (patientStatusContrl.UpdateOperationStatusOrStatusTime(operationStatus, DateTime.MinValue, true, ExtendApplicationContext.Current.OperationStatus))
                    {
                        patientStatusContrl.NoifyOperationStatusChange(operationStatus);
                    }
                }
            }


            //AnesInformations.AnesthesiaEventDataTable anesEvent = DataContext.GetCurrent().GetAnesthesiaEvent(_eventNo);
            //return;
            //麻醉单下角保存按钮，判断ASA分级和麻醉医生是否匹配，是否有越级，如越级，不允许保存。提示：您已越权操作。     
            if (ExtendApplicationContext.Current.IsYueJi)
            {
                Dialog.MessageBox("您已越权操作。");
                return;
            }


            base.OnSaveData(dataSource);
            CommonDA commonDA = new CommonDA();
            //commonDA.Update(dataSource["WIS_OPER_MASTER"], "WIS_OPER_MASTER");
            commonDA.Update(td, "WIS_OPER_MASTER");
            commonDA.Update(dataSource["WIS_OPER_ANALGESIC"], "WIS_OPER_ANALGESIC");
            commonDA.Update(dataSource["WIS_CUSTOM_DATA"], "WIS_CUSTOM_DATA");
            commonDA.Update(dataSource["WIS_ANES_OPER_HANDOVER"], "WIS_ANES_OPER_HANDOVER");
            commonDA.Update(dataSource["WIS_ANES_PLAN"], "WIS_ANES_PLAN");
            commonDA.Update(dataSource["WIS_PAT_MASTER_INDEX"], "WIS_PAT_MASTER_INDEX");
            //commonDA.Update(dataSource["WIS_PAT_IN_HOS"],"WIS_PAT_IN_HOS");

            foreach (IUIElementHandler handler in _UIElementHandlers)
            {
                if (handler.GetControlType == typeof(MedVitalSignGraph) && handler.GetCurrentControl != null)
                {
                    MedVitalSignGraph vitalSign = handler.GetCurrentControl as MedVitalSignGraph;
                    if (vitalSign.NewMonitorData != null)
                        vitalSign.NewMonitorData.Save();
                }
            }
        }

        /// <summary>
        /// 根据时间范围获取一页的体征数据
        /// </summary>
        /// <param name="dtRange"></param>
        /// <returns></returns>
        private AnesInformations.VitalSignDataTable GetPageVitalSignDataByTimeSpan(DateTimeRange dtRange)
        {
            return GetPageVitalSignDataByTimeSpan(dtRange, false);
        }
        /// <summary>
        /// 根据时间范围获取一页的体征数据
        /// </summary>
        /// <param name="dtRange"></param>
        /// <returns></returns>
        private AnesInformations.VitalSignDataTable GetPageVitalSignDataByTimeSpan(DateTimeRange dtRange, bool isRefresh)
        {
            AnesInformations.VitalSignDataTable dtVitalSignClone = new AnesInformations.VitalSignDataTable();

            if (isRefresh)
            {
                _vitalSign = DataContext.GetCurrent().GetVitalSignData(_eventNo);
                //_vitalSign = DataContext.GetCurrent().GetVitalSignData();
            }
            foreach (AnesInformations.VitalSignRow row in _vitalSign)
            {
                if (row.TIME_POINT >= dtRange.StartDateTime && row.TIME_POINT <= dtRange.EndDateTime)
                {
                    dtVitalSignClone.ImportRow(row);
                }
            }
            return dtVitalSignClone;
        }
        /// <summary>
        /// 根据时间范围获取一页的麻醉事件数据
        /// </summary>
        /// <param name="dtRange"></param>
        /// <returns></returns>
        private AnesInformations.AnesthesiaEventDataTable GetPageAnesEventDataByTimeSpan(DateTimeRange dtRange)
        {
            return GetPageAnesEventDataByTimeSpan(dtRange, false);
        }
        /// <summary>
        /// 根据时间范围获取一页的麻醉事件数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="dtRange"></param>
        /// <returns></returns>
        private AnesInformations.AnesthesiaEventDataTable GetPageAnesEventDataByTimeSpan(DateTimeRange dtRange, bool isRefresh)
        {
            //只显示当页
            //AnesInformations.AnesthesiaEventDataTable dtAnesthesiaEventClone = (AnesInformations.AnesthesiaEventDataTable)_anesEvent.Clone();
            AnesInformations.AnesthesiaEventDataTable dtAnesthesiaEventClone = new AnesInformations.AnesthesiaEventDataTable();

            if (isRefresh)
            {

                _anesEvent = DataContext.GetCurrent().GetAnesthesiaEvent(_eventNo);
                base.DataSource["AnesAllEvent"] = _anesEvent;
            }

            foreach (AnesInformations.AnesthesiaEventRow row in _anesEvent)
            {
                //有起始时间，如没有，则不显示
                if (!row.IsSTART_DATE_TIMENull())
                {
                    //如果起始时间《 控件 上起始时间
                    if (row.START_DATE_TIME < dtRange.StartDateTime)
                    {
                        //没有结束时间
                        if (row.IsEND_DATE_TIMENull())
                        {
                            if (!row.IsDURATIVE_INDICATORNull() && (row.DURATIVE_INDICATOR == 1))
                            {
                                dtAnesthesiaEventClone.ImportRow(row);
                                continue;
                            }

                            if (row.ITEM_NAME.Contains("呼吸"))
                            {
                                dtAnesthesiaEventClone.ImportRow(row);
                                continue;
                            }
                        }
                        else//有结束时间
                        {
                            if (row.END_DATE_TIME <= dtRange.StartDateTime)
                            {

                            }
                            else
                            {
                                dtAnesthesiaEventClone.ImportRow(row);
                            }
                        }

                    }//end if (row.START_TIME < dtRange.startTime)
                    else//如果起始时间 》=  控件 上起始时间
                    {
                        //没有结束时间
                        if (row.IsEND_DATE_TIMENull())
                        {
                            if (row.START_DATE_TIME < dtRange.EndDateTime)//起始时间   《  控件 上结束时间 
                            {
                                dtAnesthesiaEventClone.ImportRow(row);
                            }
                        }
                        else//有结束时间
                        {
                            if (row.START_DATE_TIME < dtRange.EndDateTime)
                            {
                                dtAnesthesiaEventClone.ImportRow(row);
                            }

                        }
                    }
                }

            }
            return dtAnesthesiaEventClone;
        }
        /// <summary>
        /// 根据页码获取每页的时间范围
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        private DateTimeRange GetPageDateTimeRange(int pageIndex)
        {
            DateTime startTime = _dateTimeRange.StartDateTime.AddHours(pageIndex * _pageHours);
            DateTime endTime = startTime.AddHours(_pageHours);
            DateTimeRange dtRange = new DateTimeRange(startTime, endTime);

            dtRange.OrigiStartDateTime = _dateTimeRange.OrigiStartDateTime;
            dtRange.OrigiEndDateTime = _dateTimeRange.OrigiEndDateTime;

            return dtRange;
        }
        /// <summary>
        /// 判读每页是否有附页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        private bool HasAttachPage(int pageIndex)
        {
            //根据页码获取本页的时间范围和数据
            DateTimeRange dtRange = GetPageDateTimeRange(pageIndex);
            base.DataSource["AnesthesiaEvent"] = GetPageAnesEventDataByTimeSpan(dtRange);

            //获取控件MedAnesSheetDetails
            MedAnesSheetDetails anesSheetDetails = null;
            //刷新数据.计算是否有附页
            foreach (IUIElementHandler handler in base._UIElementHandlers)
            {
                handler.PagerSetting.PageTimeSpan = dtRange;
                if (handler.GetControlType == typeof(MedDrugGraph) && handler.GetCurrentControl != null)
                    handler.RefreshData();
                if (handler.GetControlType == typeof(MedGridGraph) && handler.GetCurrentControl != null)
                    handler.RefreshData();
                if (handler.GetControlType == typeof(MedAnesSheetDetails) && handler.GetCurrentControl != null)
                {
                    anesSheetDetails = handler.GetCurrentControl as MedAnesSheetDetails;
                    anesSheetDetails.StartTime = dtRange.StartDateTime;
                    anesSheetDetails.EndTime = dtRange.EndDateTime;
                    handler.RefreshData();



                }

            }

            if (anesSheetDetails == null)
                return false;





            int totalCount = anesSheetDetails.TotalCount > 0 ? anesSheetDetails.TotalCount : 5;
            anesSheetDetails.StartIndex = 0;
            int cnt = 0;
            int n = 0;
            if (anesSheetDetails.Group)
            {

                //分组时 先重新绘制分组获取 DrawListCount 20140210
                Graphics g = Graphics.FromHwnd(anesSheetDetails.Handle);
                anesSheetDetails.DrawCollections(g);
                g.Dispose();
                anesSheetDetails.StartIndex = 0;
                cnt = anesSheetDetails.DrawListCount;
            }
            else
            {
                Graphics g = anesSheetDetails.CreateGraphics();
                float leftOffset = g.MeasureString("99", anesSheetDetails.DetailFont).Width;
                for (int i = 0; i < anesSheetDetails.Collections.Count; i++)
                {
                    if (anesSheetDetails.Collections[i] == null)
                        continue;
                    for (int j = 0; j < anesSheetDetails.Collections[i].Points.Count; j++)
                    {
                        if (anesSheetDetails.Collections[i].Points[j].StartTime >= dtRange.StartDateTime && anesSheetDetails.Collections[i].Points[j].StartTime < dtRange.StartDateTime.AddHours(_pageHours))
                        {
                            cnt++;
                            anesSheetDetails.Collections[i].Points[j].Index = cnt;//更新序号
                            List<string> list = anesSheetDetails.GetPointStrings(g, anesSheetDetails.Collections[i].Points[j], (int)anesSheetDetails.GetMainRect().X + leftOffset, (int)anesSheetDetails.GetMainRect().Y + anesSheetDetails.TopOffSet, anesSheetDetails.ColumnWidth - leftOffset);
                            if (list.Count > 1 && cnt < (totalCount - n))
                            {
                                n += list.Count - 1;
                            }
                        }
                    }
                }
            }
            //判断当前页是否有附页
            if (cnt > (totalCount - n))
            {
                return true;
            }
            return false;
        }


        public decimal GetDecimalValue(object rowValue)
        {
            if (rowValue != System.DBNull.Value && rowValue is decimal)
            {
                return (decimal)rowValue;
            }
            else
            {
                return 0;
            }
        }

        public override void Initial()
        {
            base.Initial();
            //if (this.Caption == "麻醉单")
            {
                this.OnReportViewMouseDown += (control_MouseDown);
            }
        }

        //Add by wenpei.x@2014-03-04
        //新增麻醉单单页打印
        private void control_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                //ToolStripMenuItem item = new ToolStripMenuItem("打印-麻醉单正反面");
                //item.Click += new EventHandler(delegate(object sender1, EventArgs e1)
                //{
                //    NurseCustomPrinter nursePrinter = new NurseCustomPrinter(this, _paperSize, _pageFromHeight, _pagePrintHeight, _pageName);
                //    nursePrinter.GetNurseDocPrinterList(GetNursePrinters("麻醉单", "麻醉单反面"));
                //    nursePrinter.PLPrint();
                //});
                //menu.Items.Add(item);

                //Add by wenpei.x@2014-03-04
                //新增麻醉单单页打印
                ToolStripMenuItem item1 = new ToolStripMenuItem("打印-麻醉单当前页");
                item1.Click += new EventHandler(delegate(object sender1, EventArgs e1)
                {
                    SingleCustomPrinter printer = new SingleCustomPrinter(this, _paperSize, _pageFromHeight, _pagePrintHeight, _pageName);
                    printer.PrintCurrentPage();
                });
                menu.Items.Add(item1);

                menu.Show(Control.MousePosition);
            }
        }

        protected void AutoCalc()
        {
            List<MTextBox> list = ReportViewer.GetControls<MTextBox>();
            foreach (MTextBox textBox in list)
            {
                if (textBox.Name.ToUpper().Equals("TXTBOOLD"))
                {
                    textBox.Text = GetTotalByClass("B");
                }

                if (textBox.Name.ToUpper().Equals("TXTLIQUID"))
                {
                    textBox.Text = GetTotalByClass("3");
                }


                if (textBox.Name.ToUpper().Equals("TXTRULIANG"))
                {
                    string num1 = GetTotalByClass("B");
                    string num2 = GetTotalByClass("3");
                    textBox.Text = (Convert.ToDecimal(num1) + Convert.ToDecimal(num2)).ToString();
                }

                //出血量 
                if (textBox.Name.ToUpper().Equals("MTEXTBOXLOSTBLOOD"))
                {
                    textBox.Text = GetTotalByClass("D","出血");
                }

                //尿量 
                if (textBox.Name.ToUpper().Equals("MTEXTBOXURINE"))
                {
                    textBox.Text = GetTotalByClass("D","尿量");
                }

                //总出量
                if (textBox.Name.ToUpper().Equals("MTEXTBOXALLOUT"))
                {
                    textBox.Text = GetTotalByClass("D");
                }
            }
        }

        private string GetTotalByClass(string itemClass)
        {
            decimal totalDosage = 0;
            DataRow[] rows = _anesEvent.Select(string.Format(" ITEM_CLASS = '{0}'", itemClass.ToUpper()));
            //此类事件不存在
            if (rows == null || rows.Length == 0) return totalDosage.ToString();
            foreach (AnesInformations.AnesthesiaEventRow row in rows)
            {
                if (!row.IsDOSAGE_UNITSNull())
                    totalDosage += row.IsDOSAGENull() ? 0 : row.DOSAGE;
            }
            return totalDosage.ToString();
        }

        private string GetTotalByClass(string itemClass,string itemName)
        {
            decimal totalDosage = 0;
            DataRow[] rows = _anesEvent.Select(string.Format(" ITEM_CLASS = '{0}' AND ITEM_NAME = '{1}' ", itemClass.ToUpper(),itemName));
            //此类事件不存在
            if (rows == null || rows.Length == 0) return totalDosage.ToString();
            foreach (AnesInformations.AnesthesiaEventRow row in rows)
            {
                if (!row.IsDOSAGE_UNITSNull())
                    totalDosage += row.IsDOSAGENull() ? 0 : row.DOSAGE;
            }
            return totalDosage.ToString();
        }

        private bool IsExistItem_Name(DataTable dt)
        {
            //string res = "false";
            bool flag = true;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string ITEM_NAME = dr["ITEM_NAME"].ToString();
                    if (ITEM_NAME == "手术结束.回病室")
                    {
                        if (dr["ITEM_Value"].ToString() == "")
                        {
                            //res = dr["ITEM_Value"].ToString();
                            flag = false;
                        }
                        
                    }
                }

                //if (!flag)
                //{
                //    res = "";
                //}
            }
            else {
                flag = false;
            }
            return flag;
        }

        private string GetItem_Value(DataTable dt)
        {
            string res = "";
            string result = "";
            foreach (DataRow dr in dt.Rows)
            {
                string ITEM_NAME = dr["ITEM_NAME"].ToString();
                if (ITEM_NAME == "手术结束.回病室")
                {

                   res = dr["ITEM_VALUE"].ToString();

                }
            }
            if (res == "2")
            {
                result = "60";
            }else if(res == "1")
            {
                result = "40";
            }
            else if (res == "3")
            {
                result = "61";
            }
            else
            {
                result = "35";
            }
            return result;
        }

        protected override void OnViewBuilded(List<IUIElementHandler> handlers, Dictionary<string, DataTable> dataSources)
        {
            ShowAnesDate();
        }

        /// <summary>
        /// 麻醉方法绑定的数据源变动,2022.5.11以前的数据显示原来的数据源，之后的显示新的
        /// </summary>
        private void ShowAnesDate()
        {
            //手术日期_operTime BuildData数据加载时赋值
            //判断日期小于2022.5.11的麻醉方法显示WIS_OPER_MASTER 中的ANES_METHOD
            if (DateTime.Compare(_operTime, DateTime.Parse("2022-05-11")) < 0)
            {
                List<MTextBox> list = ReportViewer.GetControls<MTextBox>();
                foreach (MTextBox textBox in list)
                {
                    //麻醉记录单1中的textid  MTextBox2147483629 麻醉记录单2 MTextBox2147483639
                    if (textBox.Name.Trim() == "MTextBoxAnesMethod")
                    {
                        textBox.Text = _anesMethod;
                        textBox.SelectedData=_anesMethod;//下拉框的text需要设置SelectedData，否则无法获取
                    }
                }
            }

        }

    }
}
