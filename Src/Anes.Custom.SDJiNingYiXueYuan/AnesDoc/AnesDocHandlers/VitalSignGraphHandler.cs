using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.Framework.Documents;
using Wis.Anes.Framework.Controls;
using Wis.Anes.BusinessEntity;
using System.Data;
using Wis.Anes.DataAccess;
using System.Collections;
using System.Reflection;
using Wis.Anes.Framework.Controls.Base;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using Wis.Anes.Framework.Constants;
using System.Drawing;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.Framework.Utilities;
using Wis.Anes.Framework;
using Wis.Anes.Framework.Doc;


namespace Wis.Anes.Custom.CustomProject
{
    public class VitalSignGraphHandler : UIElementHandler<MedVitalSignGraph>
    {
        //private AnesInformations.VitalSignDataTable _VitalSignData;

        private AnesInformations.VitalSignDataTable _VitalSignData;
        protected DateTime _currentTime = DateTime.MinValue;
        protected MedVitalSignGraph _currentGraph = null;

        private decimal _eventNo = 0;
        /// <summary>
        /// 绑定数据源数据到控件
        /// </summary>
        /// <param name="control"></param>
        /// <param name="dataSources"></param>
        public override void BindDataToUI(MedVitalSignGraph control, Dictionary<string, System.Data.DataTable> dataSources)
        {
            if (!dataSources.ContainsKey("AnesthesiaEvent"))
                throw new NotImplementedException(string.Format("在数据源中未找到名为{0}的表AnesInformations.AnesthesiaEventDataTable,请添加此绑定数据源!", "AnesthesiaEvent"));
            if (!dataSources.ContainsKey("VitalSignData"))
                throw new NotImplementedException(string.Format("在数据源中未找到名为{0}的表AnesInformations.VitalSignDataTable,请添加此绑定数据源!", "VitalSignData"));
            if (!dataSources.ContainsKey("AnesAllEvent"))
                throw new NotImplementedException(string.Format("在数据源中未找到名为{0}的表AnesInformations.AnesthesiaEventDataTable,请添加此绑定数据源!", "AnesAllEvent"));           

            AnesInformations.VitalSignDataTable vitalSignData = dataSources["VitalSignData"] as AnesInformations.VitalSignDataTable;
            AnesInformations.AnesthesiaEventDataTable anesEvent = dataSources["AnesthesiaEvent"] as AnesInformations.AnesthesiaEventDataTable;
            AnesInformations.AnesthesiaEventDataTable anesAllEvent = dataSources["AnesAllEvent"] as AnesInformations.AnesthesiaEventDataTable;
            //CareDocs.PatMonitorDataExtDataTable patMonitorDataExt = dataSources["WIS_PAT_MONITOR_DATA_EXT"] as CareDocs.PatMonitorDataExtDataTable;
            //_VitalSignData = vitalSignData;

            if (control != null)
            {
                control.Curves.Clear();
                control.StartTime = PagerSetting.PageTimeSpan.StartDateTime;
                control.EndTime = PagerSetting.PageTimeSpan.EndDateTime;
                control.MinStartDateTime = PagerSetting.PageTimeSpan.OrigiStartDateTime;
                control.MaxEndDateTime = PagerSetting.PageTimeSpan.OrigiEndDateTime;
                _eventNo = ExtendApplicationContext.Current.EventNo;//control.EventNo;
                Dictionary<string, MedVitalSignCurveDetail> dict = new Dictionary<string, MedVitalSignCurveDetail>();
                List<MedVitalSignCurveDetail> userVitalSets = GetUserVitalShowSet(control.EventNo);
                ///形成曲线字典
                foreach (MedVitalSignCurveDetail vitalSet in userVitalSets)
                {
                    if (!string.IsNullOrEmpty(vitalSet.CurveCode) && !dict.ContainsKey(vitalSet.CurveCode))
                    {
                        dict.Add(vitalSet.CurveCode, vitalSet);
                    }
                    else if (string.IsNullOrEmpty(vitalSet.CurveCode) && !string.IsNullOrEmpty(vitalSet.CurveName))//兼容苏大附一（name为表示）
                    {
                        foreach (AnesInformations.VitalSignRow vrow in vitalSignData.Rows)
                        {
                            if (vrow.ITEM_NAME.Equals(vitalSet.CurveName) && !dict.ContainsKey(vrow.ITEM_CODE))
                            {
                                dict.Add(vrow.ITEM_CODE, vitalSet);
                                break;
                            }
                        }
                    }
                }
                foreach (MedVitalSignCurveDetail detail in control.CurveDetails)
                {
                    if (!string.IsNullOrEmpty(detail.CurveCode) && !dict.ContainsKey(detail.CurveCode))
                    {
                        dict.Add(detail.CurveCode, detail);
                    }
                    //else if (string.IsNullOrEmpty(detail.CurveCode) && !string.IsNullOrEmpty(detail.CurveName) && !dict.ContainsKey(detail.CurveName))
                    //{
                    //    dict.Add(detail.CurveName, detail);
                    //}
                }

                ExtendApplicationContext.Current.VitalSignCurveDetailDict = dict;

                bool IsModifyVitalSignShowDifferent = ApplicationConfiguration.IsModifyVitalSignShowDifferent;
                DateTime dgStartTime = DateTime.MinValue;
                if (vitalSignData != null && vitalSignData.Count > 0)
                {
                    List<string> itemNames = new List<string>();
                    for (int i = 0; i < vitalSignData.Count; i++)
                    {
                        if (!itemNames.Contains(vitalSignData[i].ITEM_CODE.Trim())) itemNames.Add(vitalSignData[i].ITEM_CODE.Trim());
                    }

                    ///逐条增加曲线
                    #region 逐条增加曲线
                    foreach (string item in itemNames)
                    {
                        if (dict.ContainsKey(item) && !dict[item].Visible) continue;

                        MedVitalSignCurveDetail vitalSignCurveDetail = null;
                        if (dict.ContainsKey(item))
                        {
                            vitalSignCurveDetail = dict[item];
                        }
                        else if (ExtendApplicationContext.Current.MonitorFunctionCodeDict.ContainsKey(item) && dict.ContainsKey(ExtendApplicationContext.Current.MonitorFunctionCodeDict[item]))
                        {
                            vitalSignCurveDetail = dict[ExtendApplicationContext.Current.MonitorFunctionCodeDict[item]];
                        }
                        DataRow[] rows = vitalSignData.Select("ITEM_CODE = '" + item + "'");
                        if (rows != null && rows.Length > 0)
                        {
                            Color color;
                            bool isDigit = false;
                            MedVitalSignCurve curve = null;
                            MedSymbol symbol = null;
                            if (vitalSignCurveDetail != null)
                            {
                                if (vitalSignCurveDetail.SymbolType == MedSymbolType.Image)
                                {
                                    try
                                    {
                                        symbol = new MedSymbol(Image.FromStream(Sundries.DecodeWithString(vitalSignCurveDetail.SymbolEntry)));
                                    }
                                    catch
                                    {
                                        symbol = new MedSymbol(MedSymbolType.None);
                                    }
                                }
                                else
                                {
                                    symbol = new MedSymbol(vitalSignCurveDetail.SymbolType);
                                }
                                if (vitalSignCurveDetail.SymbolType == MedSymbolType.Text)
                                {
                                    symbol.Text = vitalSignCurveDetail.SymbolEntry;
                                }
                                color = vitalSignCurveDetail.Color;
                                isDigit = vitalSignCurveDetail.ShowType == MedCurveShowType.Digit;
                                if (dict.ContainsKey(item))
                                {
                                    isDigit = dict[item].ShowType == MedCurveShowType.Digit;
                                    color = dict[item].Color;
                                }
                                curve = new MedVitalSignCurve(vitalSignCurveDetail.CurveName, item, vitalSignCurveDetail.YAxisIndex, color, symbol, isDigit);
                                curve.DotNumber = vitalSignCurveDetail.DotNumber;
                            }
                            else
                            {
                                color = GetRandomColor();
                                isDigit = false;
                                symbol = GetRandomSymbol();
                                vitalSignCurveDetail = new MedVitalSignCurveDetail();
                                vitalSignCurveDetail.Color = color;
                                vitalSignCurveDetail.CurveCode = item;
                                vitalSignCurveDetail.CurveName = ExtendApplicationContext.Current.MonitorFunctionCodeDict.ContainsKey(item) ? ExtendApplicationContext.Current.MonitorFunctionCodeDict[item] : item;
                                vitalSignCurveDetail.DotNumber = 0;
                                vitalSignCurveDetail.ShowType = MedCurveShowType.Line;
                                vitalSignCurveDetail.SymbolEntry = "";
                                vitalSignCurveDetail.YAxisIndex = 0;
                                vitalSignCurveDetail.Visible = true;
                                control.CurveDetails.Add(vitalSignCurveDetail);
                                curve = new MedVitalSignCurve(vitalSignCurveDetail.CurveName, item, vitalSignCurveDetail.YAxisIndex, color, symbol, isDigit);
                                curve.DotNumber = vitalSignCurveDetail.DotNumber;
                            }
                            if (symbol != null)
                            {
                                symbol.Size = 8f;
                            }



                            bool isModify = false;

                            if (curve != null)
                            {

                                for (int i = 0; i < rows.Length; i++)
                                {
                                    DateTime dt1 = (DateTime)rows[i]["TIME_POINT"];
                                    DateTime dt2 = control.StartTime.AddSeconds(-control.StartTime.Second);
                                    TimeSpan timeSpan = dt1.Subtract(dt2);
                                    int mu = (int)Math.Round(timeSpan.TotalMinutes, 0);
                                    //int mu = (int)((TimeSpan)((DateTime)rows[i]["TIME_POINT"] - control.StartTime.AddSeconds(-control.StartTime.Second))).TotalMinutes;
                                    if (curve.IsDigit || control.InterValControl == InterValControlType.ControlAll)
                                    {
                                        string value = rows[i]["VALUE"].ToString();
                                        double d = 0;
                                        if (double.TryParse(value, out d) && d >= 0)
                                        {
                                            if (dict.ContainsKey(curve.Code) && ((mu % (int)dict[curve.Code].ShowTimeInterval) == 0) && Convert.ToDouble(rows[i]["VALUE"]) > 0)
                                            {
                                                if (vitalSignCurveDetail.HideStartTime != DateTime.MinValue)
                                                {
                                                    if (vitalSignCurveDetail.HideStartTime == vitalSignCurveDetail.HideEndTime)
                                                    {
                                                        continue;
                                                    }
                                                    else if (vitalSignCurveDetail.HideStartTime < vitalSignCurveDetail.HideEndTime)
                                                    {
                                                        if (((DateTime)rows[i]["TIME_POINT"]) >= vitalSignCurveDetail.HideStartTime && ((DateTime)rows[i]["TIME_POINT"]) <= vitalSignCurveDetail.HideEndTime)
                                                        {
                                                            continue;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (((DateTime)rows[i]["TIME_POINT"]) >= vitalSignCurveDetail.HideStartTime || ((DateTime)rows[i]["TIME_POINT"]) <= vitalSignCurveDetail.HideEndTime)
                                                        {
                                                            continue;
                                                        }
                                                    }
                                                }

                                                //curve.Points.Add(new MedVitalSignPoint((DateTime)rows[i]["TIME_POINT"], Convert.ToDouble(rows[i]["VALUE"]), curve));

                                                // 20110818新增 ，是否为修改点
                                                if (IsModifyVitalSignShowDifferent)
                                                {
                                                    isModify = false;
                                                    if (rows[i]["FLAG"] != null && rows[i]["FLAG"].ToString() == "1")
                                                    {
                                                        isModify = true;
                                                    }

                                                    curve.Points.Add(new MedVitalSignPoint((DateTime)rows[i]["TIME_POINT"], Convert.ToDouble(rows[i]["VALUE"]), curve, isModify));
                                                }
                                                else
                                                {
                                                    curve.Points.Add(new MedVitalSignPoint((DateTime)rows[i]["TIME_POINT"], Convert.ToDouble(rows[i]["VALUE"]), curve));

                                                }
                                            }
                                        }
                                        else
                                        {

                                            // curve.Points.Add(new MedVitalSignPoint((DateTime)rows[i]["TIME_POINT"], rows[i]["VALUE"].ToString(), curve));

                                            // 20110818新增 ，是否为修改点
                                            if (IsModifyVitalSignShowDifferent)
                                            {
                                                isModify = false;
                                                if (rows[i]["FLAG"] != null && rows[i]["FLAG"].ToString() == "1")
                                                {
                                                    isModify = true;
                                                }
                                                curve.Points.Add(new MedVitalSignPoint((DateTime)rows[i]["TIME_POINT"], rows[i]["VALUE"].ToString(), curve, isModify));
                                            }
                                            else
                                            {
                                                curve.Points.Add(new MedVitalSignPoint((DateTime)rows[i]["TIME_POINT"], rows[i]["VALUE"].ToString(), curve));
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (Convert.ToDouble(rows[i]["VALUE"]) > 0)
                                        {
                                            if (vitalSignCurveDetail.HideStartTime != DateTime.MinValue)
                                            {
                                                if (vitalSignCurveDetail.HideStartTime < vitalSignCurveDetail.HideEndTime)
                                                {
                                                    if (((DateTime)rows[i]["TIME_POINT"]) >= vitalSignCurveDetail.HideStartTime && ((DateTime)rows[i]["TIME_POINT"]) <= vitalSignCurveDetail.HideEndTime)
                                                    {
                                                        continue;
                                                    }
                                                }
                                                else if (vitalSignCurveDetail.HideStartTime > vitalSignCurveDetail.HideEndTime)
                                                {
                                                    if (((DateTime)rows[i]["TIME_POINT"]) >= vitalSignCurveDetail.HideStartTime || ((DateTime)rows[i]["TIME_POINT"]) <= vitalSignCurveDetail.HideEndTime)
                                                    {
                                                        continue;
                                                    }
                                                }
                                            }
                                            //curve.Points.Add(new MedVitalSignPoint((DateTime)rows[i]["TIME_POINT"], Convert.ToDouble(rows[i]["VALUE"]), curve));

                                            // 20110818新增 ，是否为修改点
                                            if (IsModifyVitalSignShowDifferent)
                                            {
                                                isModify = false;
                                                if (rows[i]["FLAG"] != null && rows[i]["FLAG"].ToString() == "1")
                                                {
                                                    isModify = true;
                                                }

                                                curve.Points.Add(new MedVitalSignPoint((DateTime)rows[i]["TIME_POINT"], Convert.ToDouble(rows[i]["VALUE"]), curve, isModify));
                                            }
                                            else
                                            {

                                                curve.Points.Add(new MedVitalSignPoint((DateTime)rows[i]["TIME_POINT"], Convert.ToDouble(rows[i]["VALUE"]), curve));

                                            }
                                        }
                                    }
                                }
                                if (curve.Points.Count > 0)
                                {
                                    control.Curves.Add(curve);
                                }
                            }
                        }
                    }
                    #endregion 逐条增加曲线
                }
                ///事件标记
                #region 事件标志
                if (control.HasEventMark)
                {
                    DateTime[] twStartTime = new DateTime[] { DateTime.MinValue, DateTime.MinValue, DateTime.MinValue };
                    DateTime[] twEndTime = new DateTime[] { DateTime.Now, DateTime.Now, DateTime.Now };
                    MedSymbol[] twSymbol = new MedSymbol[] { null, null, null };
                    EventMark eventMark = new EventMark();
                    eventMark.Title = "";// "标记";
                    Color color = Color.Black;
                    string alias = "";
                    MedSymbol symbol = null;
                    MedSymbolCurveDetail detail = null;

                    if (!dataSources.ContainsKey("WIS_OPER_MASTER"))
                        throw new NotImplementedException(string.Format("在数据源中未找到名为{0}的表AnesInformations.OperationMasterDataTable,请添加此绑定数据源!", "OperationMaster"));

                    AnesInformations.OperationMasterDataTable operationMasterDataTable = dataSources["WIS_OPER_MASTER"] as AnesInformations.OperationMasterDataTable;


                    //AddAnesStartEventMark(control, eventMark);
                    if (operationMasterDataTable != null && operationMasterDataTable.Count == 1)
                    {

                        //if (!operationMasterDataTable[0].IsIN_DATE_TIMENull())//入手术室
                        //{
                        //    AddAnesEventMark(control, eventMark, operationMasterDataTable[0].IN_DATE_TIME, Globals.INDATETIME);
                        //}
                        if (_eventNo == 0)
                        {
                            if (!operationMasterDataTable[0].IsANES_START_TIMENull())//麻醉开始
                            {
                                AddAnesEventMark(control, eventMark, operationMasterDataTable[0].ANES_START_TIME, EventNames.ANESSTART);
                            }
                            if (!operationMasterDataTable[0].IsSTART_DATE_TIMENull())//手术开始
                            {
                                AddAnesEventMark(control, eventMark, operationMasterDataTable[0].START_DATE_TIME, EventNames.OPERATIONSTART);
                            }
                            if (!operationMasterDataTable[0].IsEND_DATE_TIMENull())//手术结束
                            {
                                AddAnesEventMark(control, eventMark, operationMasterDataTable[0].END_DATE_TIME, EventNames.OPERATIONEND);
                            }
                            if (!operationMasterDataTable[0].IsANES_END_TIMENull())//麻醉结束
                            {
                                AddAnesEventMark(control, eventMark, operationMasterDataTable[0].ANES_END_TIME, EventNames.ANESEND);
                            }
                            //if (!operationMasterDataTable[0].IsOUT_DATE_TIMENull())//出手术室
                            //{
                            //    AddAnesEventMark(control, eventMark, operationMasterDataTable[0].OUT_DATE_TIME, "出手术室");
                            //}
                        }
                        else if (_eventNo == 1)
                        {
                            //if (!operationMasterDataTable[0].IsIN_PACU_DATE_TIMENull())//进PACU
                            //{
                            //    AddAnesEventMark(control, eventMark, operationMasterDataTable[0].IN_PACU_DATE_TIME, EventNames.INPACU);
                            //}
                            //if (!operationMasterDataTable[0].IsOUT_PACU_DATE_TIMENull())//出PACU
                            //{
                            //    AddAnesEventMark(control, eventMark, operationMasterDataTable[0].OUT_PACU_DATE_TIME, EventNames.OUTPACU);
                            //}
                        }
                    }

                    string itemClass = GetAnesClassTypeString(AnesClassType.AnesDrug);
                    #region 从事件表增加点
                    control.CPBTtimeList.Clear();
                    foreach (AnesInformations.AnesthesiaEventRow row in anesAllEvent)
                    {
                        if (!row.IsSTART_DATE_TIMENull() && !row.IsITEM_NAMENull() && !row.IsITEM_CLASSNull() && (row.ITEM_NAME == "体外循环开始" || row.ITEM_NAME == "体外循环结束"
                          || row.ITEM_NAME == "阻断升主动脉" || row.ITEM_NAME == "开放升主动脉") && !control.CPBTtimeList.ContainsKey(row.START_DATE_TIME))
                        {
                            control.CPBTtimeList.Add(row.START_DATE_TIME, row.ITEM_NAME);
                        }
                    }
                    foreach (AnesInformations.AnesthesiaEventRow row in anesEvent)
                    {
                        if (!row.IsSTART_DATE_TIMENull() && !row.IsITEM_NAMENull() && !row.IsITEM_CLASSNull() && (row.ITEM_NAME == "体外循环开始" || row.ITEM_NAME == "体外循环结束"
                                 || row.ITEM_NAME == "阻断升主动脉" || row.ITEM_NAME == "开放升主动脉") && !control.CPBTtimeList.ContainsKey(row.START_DATE_TIME))
                        {
                            control.CPBTtimeList.Add(row.START_DATE_TIME, row.ITEM_NAME);
                        }
                        if (!row.IsSTART_DATE_TIMENull() && !row.IsITEM_NAMENull() && !row.IsITEM_CLASSNull() && !row.ITEM_CLASS.Equals(itemClass))
                        {
                            ///麻醉特殊处理
                            if (IsAnesthesiaEvent(row.ITEM_NAME)) continue;
                            symbol = null;
                            detail = GetVitalSignEventMark(control, row.ITEM_NAME);
                            color = Color.Black;
                            alias = "";
                            if (detail != null)
                            {
                                symbol = new MedSymbol(detail.SymbolType);
                                if (symbol.SymbolType == MedSymbolType.Text)
                                {
                                    symbol.Text = detail.SymbolEntry;
                                }
                                color = detail.Color;
                            }
                            else
                            {

                                if (IsOperationEvent(row.ITEM_NAME))
                                {
                                    detail = GetVitalSignEventMark(control, "手术");
                                    if (detail != null)
                                    {
                                        symbol = new MedSymbol(detail.SymbolType);
                                        if (symbol.SymbolType == MedSymbolType.Text)
                                        {
                                            symbol.Text = detail.SymbolEntry;
                                        }
                                        color = detail.Color;
                                        alias = "手术";
                                    }
                                    else
                                    {
                                        symbol = new MedSymbol(MedSymbolType.Operation);
                                    }
                                }
                                else if (row.ITEM_CLASS.Equals(GetAnesClassTypeString(AnesClassType.PutPipe)))
                                {
                                    detail = GetVitalSignEventMark(control, "插管");
                                    if (detail != null)
                                    {
                                        symbol = new MedSymbol(detail.SymbolType);
                                        if (symbol.SymbolType == MedSymbolType.Text)
                                        {
                                            symbol.Text = detail.SymbolEntry;
                                        }
                                        color = detail.Color;
                                        alias = "插管";
                                    }
                                }
                                else if (row.ITEM_CLASS.Equals(GetAnesClassTypeString(AnesClassType.ZhiGuan)))
                                {
                                    detail = GetVitalSignEventMark(control, "置管");
                                    if (detail != null)
                                    {
                                        symbol = new MedSymbol(detail.SymbolType);
                                        if (symbol.SymbolType == MedSymbolType.Text)
                                        {
                                            symbol.Text = detail.SymbolEntry;
                                        }
                                        color = detail.Color;
                                        alias = "置管";
                                    }
                                }
                                else if (row.ITEM_CLASS.Equals(GetAnesClassTypeString(AnesClassType.PullPipe)))
                                {
                                    detail = GetVitalSignEventMark(control, "拔管");
                                    if (detail != null)
                                    {
                                        symbol = new MedSymbol(detail.SymbolType);
                                        if (symbol.SymbolType == MedSymbolType.Text)
                                        {
                                            symbol.Text = detail.SymbolEntry;
                                        }
                                        color = detail.Color;
                                        alias = "拔管";
                                    }
                                }
                            }
                            bool find = false;
                            if (symbol != null)
                            {
                                symbol.Size = 8f;
                                symbol.Pen = new Pen(color);
                                for (int i = 0; i < twStartTime.Length; i++)
                                {
                                    if (row.ITEM_NAME == GetTwText(i))
                                    {
                                        twStartTime[i] = row.START_DATE_TIME;
                                        if (!row.IsEND_DATE_TIMENull())
                                        {
                                            twEndTime[i] = row.END_DATE_TIME;
                                        }
                                        twSymbol[i] = symbol;
                                        if (i > 0) twEndTime[i - 1] = row.START_DATE_TIME;
                                        find = true;
                                        break;
                                    }
                                }
                                if (!find)
                                {
                                    eventMark.AddPoint(row.START_DATE_TIME, 0, row.ITEM_NAME, symbol, color, alias);
                                }
                            }

                        }
                    }
                    #endregion 从事件表增加点
                    #region 点集优化
                    for (int i = 0; i < twStartTime.Length; i++)
                    {
                        if (twStartTime[i] > DateTime.MinValue)
                        {
                            if (twEndTime[i] > twStartTime[i].AddDays(1))
                            {
                                twEndTime[i] = twStartTime[i].AddDays(1);
                            }
                            if (twEndTime[i] < twStartTime[i])
                            {
                                twEndTime[i] = twStartTime[i].AddHours(4);
                            }
                            string text = GetTwText(i);
                            MedVitalSignCurve curve = control.GetCurve(text);
                            if (curve == null)
                            {
                                curve = new MedVitalSignCurve(text, 0, twSymbol[i].Pen.Color, twSymbol[i]);
                                curve.CanUpdate = false;
                                control.Curves.Add(curve);
                            }
                            DateTime dt = twStartTime[i];
                            while (dt <= twEndTime[i])
                            {
                                curve.AddPoint(dt, 5);
                                dt = dt.AddMinutes(5);
                            }
                            if (dt < twEndTime[i].AddMinutes(5))
                            {
                                curve.AddPoint(twEndTime[i], 5);
                            }
                        }
                    }

                    #endregion 点集优化
                    #region 从明细增加点

                    MedAnesSheetDetails anesDetail = null;

                    foreach (IUIElementHandler handler in this.MedicalPaperUIElementHandlers)
                    {
                        if (handler.GetControlType == typeof(MedAnesSheetDetails) && handler.GetCurrentControl != null)
                        {
                            anesDetail = handler.GetCurrentControl as MedAnesSheetDetails;
                        }
                    }
                    if (anesDetail != null)
                    {
                        foreach (MedAnesSheetDetailCollection collection in anesDetail.Collections)
                        {
                            if (collection != null && collection.Points != null)
                            {
                                foreach (MedAnesSheetDetailPoint point in collection.Points)
                                {
                                    ///麻醉特殊处理
                                    if (IsAnesthesiaEvent(point.Text)) continue;
                                    EventMarkPoint p = eventMark.Points.Find(new Predicate<EventMarkPoint>(delegate(EventMarkPoint empt)
                                    {
                                        return empt.Text.Equals(point.Text) && empt.TimePoint.Equals(point.StartTime);
                                    }));
                                    if (p == null)
                                    {
                                        eventMark.AddPoint(point.StartTime, point.Index, point.Text, null, point.Color, point.Text);
                                    }
                                }
                            }
                        }
                    }
                    #endregion 从明细增加点

                    eventMark.ReSort();

                    control.EventMark = eventMark;

                }
                #endregion 事件标志
                if (!string.IsNullOrEmpty(control.BreathPara1) && !string.IsNullOrEmpty(control.BreathPara2) && !string.IsNullOrEmpty(control.BreathPara3))
                {
                    control.BreathParaName1 = DataContext.GetCurrent().GetMonitorFunctionName(control.BreathPara1);
                    control.BreathParaName2 = DataContext.GetCurrent().GetMonitorFunctionName(control.BreathPara2);
                    control.BreathParaName3 = DataContext.GetCurrent().GetMonitorFunctionName(control.BreathPara3);
                }
                ControlBreath(anesEvent, control, dict);
                #region 血气记录
                control.BloodGasItems = DataContext.GetCurrent().GetBloodGasItems(ExtendApplicationContext.Current.PatientContext.PatientID,
                    ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID);
                #endregion

            }
        }

        public override void BindUIToData(MedVitalSignGraph control, Dictionary<string, System.Data.DataTable> dataSources)
        {

        }
        public override void ControlSetting(MedVitalSignGraph control)
        {

            control.Curves.Clear();
            control.OriginWidth = control.Width;
            control.OriginHeight = control.Height;
            control.ValueChanged -= new EventHandler<VitalSignPointEventArgs>(_vitalGraph_ValueChanged);
            control.ValueChanged += new EventHandler<VitalSignPointEventArgs>(_vitalGraph_ValueChanged);
            control.ControlBreathStartDoubleClick -= new EventHandler(control_ControlBreathStartDoubleClick);
            control.ControlBreathStartDoubleClick += new EventHandler(control_ControlBreathStartDoubleClick);
            control.SignPointMouseMove += new EventHandler<VitalSignPointEventArgs>(control_SignPointMouseMove);
            if (AccessControl.CheckModifyRightForOperator("麻醉记录单") || ExtendApplicationContext.Current.AppType == ApplicationType.PACU)
            {
                control.ContextMenuStrip = CreatVitalGraphMenu();
                control.NewMonitorData = new NewMonitorData(ExtendApplicationContext.Current.PatientContext.PatientID,
                ExtendApplicationContext.Current.PatientContext.VisitID,
                ExtendApplicationContext.Current.PatientContext.OperID, ExtendApplicationContext.Current.EventNo);
                if (control.IsShowBloodGas)
                {
                    control.MouseDoubleClick += new MouseEventHandler(vitalSignGraph_DoubleClick);
                }
            }
            else
            {
                control.CanUpdate = true;
            }
            control.CustomDraw += new PaintEventHandler(control_CustomDraw);
        }

        void control_CustomDraw(object sender, PaintEventArgs e)
        {
            MedVitalSignGraph vitalGraph = sender as MedVitalSignGraph;
            if (vitalGraph != null && !string.IsNullOrEmpty(vitalGraph.BreathPara1) && !string.IsNullOrEmpty(vitalGraph.BreathPara2) && !string.IsNullOrEmpty(vitalGraph.BreathPara3))
            {
                string breathParaName1 = DataContext.GetCurrent().GetMonitorFunctionName(vitalGraph.BreathPara1);
                string breathParaName2 = DataContext.GetCurrent().GetMonitorFunctionName(vitalGraph.BreathPara2);
                string breathParaName3 = DataContext.GetCurrent().GetMonitorFunctionName(vitalGraph.BreathPara3);
                DrawControlBreathPara(e.Graphics, Pens.Black, vitalGraph.LegendFont, Brushes.Black, new PointF((float)(vitalGraph.OriginRect.X+vitalGraph.TitleWidth + 40), (float)(vitalGraph.OriginRect.Height - vitalGraph.EventMarkHeight/2)), 4
        , new List<string>(new string[] { breathParaName1, breathParaName2, breathParaName3 }));
            }
            e.Graphics.DrawString("标    记", vitalGraph.Font, Brushes.Black, vitalGraph.OriginRect.Width * vitalGraph.LeftWidthPercent - 55, vitalGraph.OriginRect.Height-17);
        }

        private void DrawControlBreathPara(Graphics g, Pen pen, Font font, Brush brush, PointF pointF, float lineLength, List<string> list)
        {
            g.DrawLine(pen, pointF.X, pointF.Y - lineLength, pointF.X, pointF.Y);
            string text = list[1];
            g.DrawString(text, font, brush, pointF.X - g.MeasureString(text, font).Width / 2, pointF.Y - lineLength - g.MeasureString(text, font).Height);
            float lineLength1 = lineLength * (float)Math.Tan(Math.PI / 4);
            g.DrawLine(pen, pointF.X, pointF.Y, pointF.X - lineLength1, pointF.Y + lineLength1);
            text = list[0];
            g.DrawString(text, font, brush, pointF.X - lineLength1 - g.MeasureString(text, font).Width, pointF.Y + lineLength1);
            g.DrawLine(pen, pointF.X, pointF.Y, pointF.X + lineLength1, pointF.Y + lineLength1);
            text = list[2];
            g.DrawString(text, font, brush, pointF.X + lineLength1, pointF.Y + lineLength1);
        }

        void control_SignPointMouseMove(object sender, VitalSignPointEventArgs e)
        {
            MedVitalSignGraph control = sender as MedVitalSignGraph;
            AnesInformations.OperationMasterDataTable operationMasterDataTable = null;
            try
            {
               operationMasterDataTable = base.DataSource["WIS_OPER_MASTER"] as AnesInformations.OperationMasterDataTable;
             }
            catch(Exception ex)
            {
                ExceptionHandler.Handle(ex, false);
            }

                if (operationMasterDataTable != null && operationMasterDataTable.Count == 1)
                {
                    AnesInformations.OperationMasterRow masterRow = operationMasterDataTable[0];
                    if (ExtendApplicationContext.Current.EventNo == 0)
                    {
                        if (!masterRow.IsIN_PACU_DATE_TIMENull() && !string.IsNullOrEmpty(masterRow.IN_PACU_DATE_TIME.ToString()))
                        {
                            if (e.Point.Time >= masterRow.IN_PACU_DATE_TIME)
                            {
                                control.SetCurrentPosMove(false);
                            }
                        }
                    }
                    else if (ExtendApplicationContext.Current.EventNo == 1)
                    {
                        if (!masterRow.IsOUT_DATE_TIMENull() && !string.IsNullOrEmpty(masterRow.OUT_DATE_TIME.ToString()))
                        {
                            if (e.Point.Time <= masterRow.OUT_DATE_TIME)
                            {
                                control.SetCurrentPosMove(false);
                            }
                        }
                    }
                }            
            

        }

        private void control_ControlBreathStartDoubleClick(object sender, EventArgs e)
        {
            MedVitalSignGraph vitalSignGraph = sender as MedVitalSignGraph;
            if (vitalSignGraph != null && vitalSignGraph.SelectedPoint != null && vitalSignGraph.SelectedBreathControlTime != null)
            {
                if (!string.IsNullOrEmpty(vitalSignGraph.BreathPara1) && !string.IsNullOrEmpty(vitalSignGraph.BreathPara2) && !string.IsNullOrEmpty(vitalSignGraph.BreathPara3))
                {
                    UserControl_BreathParas breathParas;
                    //if (vitalSignGraph.SelectedBreathControlTime.list != null && vitalSignGraph.SelectedBreathControlTime.list.Count == 3)
                    if (vitalSignGraph.BreathParalList.ContainsKey(vitalSignGraph.SelectedPoint.Time) && !string.IsNullOrEmpty(vitalSignGraph.BreathParalList[vitalSignGraph.SelectedPoint.Time].Para1)
                         && !string.IsNullOrEmpty(vitalSignGraph.BreathParalList[vitalSignGraph.SelectedPoint.Time].Para2) && !string.IsNullOrEmpty(vitalSignGraph.BreathParalList[vitalSignGraph.SelectedPoint.Time].Para3))
                    {
                        breathParas = new UserControl_BreathParas(vitalSignGraph.SelectedPoint.Time, vitalSignGraph.BreathPara1, vitalSignGraph.BreathPara2, vitalSignGraph.BreathPara3
                            , vitalSignGraph.BreathParalList[vitalSignGraph.SelectedPoint.Time].Para1, vitalSignGraph.BreathParalList[vitalSignGraph.SelectedPoint.Time].Para2
                            , vitalSignGraph.BreathParalList[vitalSignGraph.SelectedPoint.Time].Para3);
                    }
                    else
                    {
                        breathParas = new UserControl_BreathParas(vitalSignGraph.SelectedPoint.Time, vitalSignGraph.BreathPara1, vitalSignGraph.BreathPara2, vitalSignGraph.BreathPara3);
                    }
                    DialogHostForm1 dialogHostForm = new DialogHostForm1("呼吸参数", breathParas.Width, breathParas.Height);
                    dialogHostForm.Child = breathParas;
                    dialogHostForm.ShowDialog();
                    if (breathParas.ResultList != null && breathParas.ResultList.Count == 3)
                    {
                        if (DataContext.GetCurrent().SetBreathParas(ExtendApplicationContext.Current.PatientContext.PatientID,
                    ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID, vitalSignGraph.SelectedPoint.Time
                            , vitalSignGraph.BreathPara1, vitalSignGraph.BreathPara2, vitalSignGraph.BreathPara3, breathParas.ResultList[0], breathParas.ResultList[1]
                            , breathParas.ResultList[2]))
                        {
                            RefreshData();
                            vitalSignGraph.Invalidate();
                        }
                    }
                    if (breathParas.delBreathParas)//取消呼吸模式
                    {
                        if (DataContext.GetCurrent().SetBreathParas(ExtendApplicationContext.Current.PatientContext.PatientID,
                    ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID, vitalSignGraph.SelectedPoint.Time
                            , vitalSignGraph.BreathPara1, vitalSignGraph.BreathPara2, vitalSignGraph.BreathPara3, null, null, null))
                        {
                            RefreshData();
                            vitalSignGraph.Invalidate();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 呼吸控制
        /// </summary>
        /// <param name="anesEvent"></param>
        /// <param name="vitalSignGraph"></param>
        protected void ControlBreath(AnesInformations.AnesthesiaEventDataTable anesEvent, MedVitalSignGraph vitalSignGraph, Dictionary<string, MedVitalSignCurveDetail> dict)
        {
            if (anesEvent != null)
            {
                DataRow[] rows = anesEvent.Select("ITEM_NAME LIKE '%呼吸%' ");
                if (rows.Length == 0) return;
                //最大体征时间
                DateTime maxVitalSignTime = DateTime.MaxValue;

                //控制呼吸时间列表
                List<MedVitalSignBreathControlTime> listControlTime = new List<MedVitalSignBreathControlTime>();
                MedVitalSignCurve curveBreath = null;
                //获取体征当前时间 及 呼吸曲线
                for (int i = 0; i < vitalSignGraph.Curves.Count; i++)
                {
                    if (vitalSignGraph.Curves[i].Text.Contains("呼吸"))
                    {
                        curveBreath = vitalSignGraph.Curves[i];
                        continue;
                    }
                    for (int j = 0; j < vitalSignGraph.Curves[i].Points.Count; j++)
                    {
                        if (maxVitalSignTime == DateTime.MaxValue)
                        {
                            maxVitalSignTime = vitalSignGraph.Curves[i].Points[j].Time;
                        }
                        else if (maxVitalSignTime < vitalSignGraph.Curves[i].Points[j].Time)
                        {
                            maxVitalSignTime = vitalSignGraph.Curves[i].Points[j].Time;
                        }
                    }
                }



                if (curveBreath == null)//生成曲线
                {
                    foreach (MedVitalSignCurveDetail detail in vitalSignGraph.CurveDetails)
                    {
                        if (detail.CurveName.Contains("呼吸"))
                        {
                            curveBreath = CreateCurve(detail);
                            vitalSignGraph.Curves.Add(curveBreath);
                            break;
                        }
                    }
                }

                if (curveBreath != null)
                {
                    curveBreath.LineMaxscale = 20;
                    vitalSignGraph.BreathControlTime.Clear();
                    //Add @2014-02-12,刷新时清掉控制呼吸的三个参数
                    vitalSignGraph.BreathParalList.Clear();
                    //End Add
                    listControlTime.AddRange(BreathTimeList("自主呼吸", anesEvent, vitalSignGraph, dict));
                    listControlTime.AddRange(BreathTimeList("控制呼吸", anesEvent, vitalSignGraph, dict));
                    listControlTime.AddRange(BreathTimeList("辅助呼吸", anesEvent, vitalSignGraph, dict));


                    //排序 listControlTime
                    listControlTime.Sort(new Comparison<MedVitalSignBreathControlTime>(delegate(MedVitalSignBreathControlTime controlTime1, MedVitalSignBreathControlTime controlTime2)
                    {
                        return controlTime1.oStartTime.CompareTo(controlTime2.oStartTime);
                    }));


                    //
                    //调整  listControlTime ，使得时间无重叠 
                    if (listControlTime.Count > 1)
                    {
                        MedVitalSignBreathControlTime breathControlTime1 = null;
                        MedVitalSignBreathControlTime breathControlTime2 = null;
                        for (int i = 0; i < listControlTime.Count - 1; i++)
                        {
                            breathControlTime1 = listControlTime[i];
                            breathControlTime2 = listControlTime[i + 1];
                            if (breathControlTime1.endTime >= breathControlTime2.startTime)
                            {
                                breathControlTime1.endTime = breathControlTime2.startTime.AddMinutes(-5);
                            }
                        }
                    }
                    MedVitalSignPoint point = null;//删除所有时间段内的点
                    for (int kk = 0; kk < listControlTime.Count; kk++)
                    {
                        DateTimeRange range = new DateTimeRange(listControlTime[kk].startTime, listControlTime[kk].endTime);
                        for (int i = 0; i < curveBreath.Points.Count; i++)
                        {
                            point = curveBreath.Points[i];
                            if (point.Time >= range.StartDateTime && point.Time <= range.EndDateTime)
                            {
                                curveBreath.Points.Remove(point);
                                i--;
                            }

                        }
                        DateTime dt = range.StartDateTime;
                        dt = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0);
                        while (dt <= range.EndDateTime)
                        {
                            point = new MedVitalSignPoint(dt, listControlTime[kk].breathValue, curveBreath);
                            curveBreath.Points.Add(point);
                            //dt = dt.AddMinutes(5);
                            //加入新点20120927
                            dt = dt.AddMinutes(listControlTime[kk].showTimeInterval);

                        }
                        curveBreath.Points.Sort(new Comparison<MedVitalSignPoint>(delegate(MedVitalSignPoint point1, MedVitalSignPoint point2)
                        {
                            return point1.Time.CompareTo(point2.Time);
                        }));
                    }

                }
                vitalSignGraph.BreathControlTimeList = listControlTime;
            }

        }
        /// <summary>
        /// 获取呼吸时间列表
        /// </summary>
        /// <param name="breathType"></param>
        /// <param name="anesEvent"></param>
        /// <param name="vitalSignGraph"></param>
        /// <returns></returns>
        private List<MedVitalSignBreathControlTime> BreathTimeList(string breathType, AnesInformations.AnesthesiaEventDataTable anesEvent, MedVitalSignGraph vitalSignGraph, Dictionary<string, MedVitalSignCurveDetail> dict)
        {

            DataRow[] rows = anesEvent.Select("ITEM_NAME LIKE '%" + breathType + "%' ");

            DateTime controlStartTime = DateTime.MinValue;
            DateTime controlEndTime = DateTime.MaxValue;


            double dBreathValue = -1;

            //控制呼吸时间列表
            List<MedVitalSignBreathControlTime> listControlTime = new List<MedVitalSignBreathControlTime>();
            DateTime sysDatetTime = GetSysDateTime();
            foreach (DataRow row in rows)
            {
                //初始化值
                controlStartTime = DateTime.MinValue;
                controlEndTime = DateTime.MaxValue;

                AnesInformations.AnesthesiaEventRow anesthesiaEventRow = row as AnesInformations.AnesthesiaEventRow;
                if (!anesthesiaEventRow.IsSTART_DATE_TIMENull())
                {
                    controlStartTime = anesthesiaEventRow.START_DATE_TIME;
                }
                if (!anesthesiaEventRow.IsEND_DATE_TIMENull())
                {
                    controlEndTime = anesthesiaEventRow.END_DATE_TIME;
                }
                if (!anesthesiaEventRow.IsDOSAGENull())
                {
                    dBreathValue = (double)anesthesiaEventRow.DOSAGE;
                }
                else
                {
                    dBreathValue = 0;
                }

                //有开始时间  并且有体征数据 并且有呼吸值
                if (controlStartTime != DateTime.MinValue && dBreathValue >= 0)
                {
                    //没有结束时间
                    if (controlEndTime == DateTime.MaxValue)
                    {
                        controlEndTime = (sysDatetTime < PagerSetting.PageTimeSpan.OrigiEndDateTime) ? sysDatetTime : PagerSetting.PageTimeSpan.OrigiEndDateTime;
                        //controlEndTime = (DataHelper.GetSysDateTime() < dateTimeRangePage.EndDateTime) ? DataHelper.GetSysDateTime() : dateTimeRangePage.EndDateTime;
                    }
                    DateTimeRange range = new DateTimeRange(controlStartTime, controlEndTime);
                    AdjustDateTimeRange(TimeScaleType.FiveMinute, ref range);

                    //控制呼吸
                    MedVitalSignBreathControlTime breathControlTime = new MedVitalSignBreathControlTime();
                    breathControlTime.startTime = range.StartDateTime;
                    breathControlTime.endTime = range.EndDateTime;

                    breathControlTime.oStartTime = controlStartTime;
                    breathControlTime.oEndTime = controlEndTime;

                    breathControlTime.breathValue = dBreathValue;



                    //新增显示频率 20120927
                    int timeSpan = 10;
                    string breathName = "呼吸";
                    Color color = Color.Magenta;
                    //设置初始值
                    foreach (MedVitalSignCurveDetail detail in dict.Values)
                    {
                        if (detail.CurveName.Equals("呼吸"))
                        {
                            color = detail.Color;
                            break;
                        }
                    }
                    foreach (MedVitalSignCurveDetail detail in dict.Values)
                    {
                        if (breathType == "自主呼吸")
                            breathName = "呼吸";
                        else
                            breathName = breathType;

                        if (detail.CurveName.Equals(breathName))
                        {
                            color = detail.Color ; 

                            switch (detail.ShowTimeInterval)
                            {
                                case MedShowTimeInterval.Five:
                                    timeSpan = 5;
                                    break;
                                case MedShowTimeInterval.Fifiteen:
                                    timeSpan = 15;
                                    break;
                                case MedShowTimeInterval.Ten:
                                    timeSpan = 10;
                                    break;
                                case MedShowTimeInterval.Twenty:
                                    timeSpan = 20;
                                    break;
                                case MedShowTimeInterval.HalfHour:
                                    timeSpan = 30;
                                    break;
                                case MedShowTimeInterval.Hour:
                                    timeSpan = 60;
                                    break;
                            }
                        }
                    }
                    //新增显示频率 20120927
                    breathControlTime.showTimeInterval = timeSpan;
                    breathControlTime.curveColor = color;

                    if (breathType.Contains("控制呼吸"))
                    {
                        breathControlTime.BreathType = BreathControlType.ControlBreath;
                       
                        
                        if (!string.IsNullOrEmpty(vitalSignGraph.BreathPara1) && !string.IsNullOrEmpty(vitalSignGraph.BreathPara2) && !string.IsNullOrEmpty(vitalSignGraph.BreathPara3))
                        {
                            CareDocs.PatMonitorDataExtDataTable patMonitorDataExtDataTable = new CareDocsDA().GetPatMonitorDataExtDataTable(
                                    ExtendApplicationContext.Current.PatientContext.PatientID,
                            ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID);
                            if (patMonitorDataExtDataTable != null)
                            {
                                DataRow[] rows1 = patMonitorDataExtDataTable.Select("ITEM_CODE = '" + vitalSignGraph.BreathPara1
                               + "' OR ITEM_CODE = '" + vitalSignGraph.BreathPara2 + "' OR ITEM_CODE = '" + vitalSignGraph.BreathPara3 + "'");
                                if (rows1 != null && rows1.Length > 0)
                                {
                                    foreach (DataRow r1 in rows1)
                                    {
                                        CareDocs.PatMonitorDataExtRow rr = r1 as CareDocs.PatMonitorDataExtRow;
                                        if (!vitalSignGraph.BreathParalList.ContainsKey(rr.TIME_POINT))
                                        {
                                            vitalSignGraph.BreathParalList.Add(rr.TIME_POINT, new MedVitalSignGraph.BreathPara());
                                        }
                                        if (!rr.IsITEM_VALUENull())
                                        {
                                            if (rr.ITEM_CODE.Equals(vitalSignGraph.BreathPara1))
                                            {
                                                vitalSignGraph.BreathParalList[rr.TIME_POINT].Para1 = rr.ITEM_VALUE;
                                            }
                                            else if (rr.ITEM_CODE.Equals(vitalSignGraph.BreathPara2))
                                            {
                                                vitalSignGraph.BreathParalList[rr.TIME_POINT].Para2 = rr.ITEM_VALUE;
                                            }
                                            else if (rr.ITEM_CODE.Equals(vitalSignGraph.BreathPara3))
                                            {
                                                vitalSignGraph.BreathParalList[rr.TIME_POINT].Para3 = rr.ITEM_VALUE;
                                            }
                                        }
                                    }
                                }
                                //List<string> list = new List<string>();
                                //DataRow[] rows1 = patMonitorDataExtDataTable.Select("ITEM_CODE = '" + vitalSignGraph.BreathPara1 + "' AND TIME_POINT = '" + breathControlTime.startTime.ToString() + "'");
                                //if (rows1.Length == 1)
                                //{
                                //    list.Add(rows1[0]["ITEM_VALUE"].ToString());
                                //}
                                //else
                                //{
                                //    list.Add("");
                                //}
                                //rows1 = patMonitorDataExtDataTable.Select("ITEM_CODE = '" + vitalSignGraph.BreathPara2 + "' AND TIME_POINT = '" + breathControlTime.startTime.ToString() + "'");
                                //if (rows1.Length == 1)
                                //{
                                //    list.Add(rows1[0]["ITEM_VALUE"].ToString());
                                //}
                                //else
                                //{
                                //    list.Add("");
                                //}
                                //rows1 = patMonitorDataExtDataTable.Select("ITEM_CODE = '" + vitalSignGraph.BreathPara3 + "' AND TIME_POINT = '" + breathControlTime.startTime.ToString() + "'");
                                //if (rows1.Length == 1)
                                //{
                                //    list.Add(rows1[0]["ITEM_VALUE"].ToString());
                                //}
                                //else
                                //{
                                //    list.Add("");
                                //}
                                //if (!string.IsNullOrEmpty(list[0]) || !string.IsNullOrEmpty(list[1]) || !string.IsNullOrEmpty(list[2]))
                                //{
                                //    breathControlTime.list = list;
                                //}
                            }
                        }
                    }
                    else if (breathType.Contains("辅助呼吸"))
                        breathControlTime.BreathType = BreathControlType.HelpBreath;
                    else if (breathType.Contains("自主呼吸"))
                        breathControlTime.BreathType = BreathControlType.FreeBreath;


                    listControlTime.Add(breathControlTime);

                }
            }
            return listControlTime;
        }

        /// <summary>
        /// 创建体征曲线
        /// </summary>
        /// <param name="vitalSignCurveDetail"></param>
        /// <returns></returns>
        private MedVitalSignCurve CreateCurve(MedVitalSignCurveDetail vitalSignCurveDetail)
        {
            Color color;
            bool isDigit = false;
            MedVitalSignCurve curve = null;
            MedSymbol symbol = null;
            if (vitalSignCurveDetail != null)
            {
                if (vitalSignCurveDetail.SymbolType == MedSymbolType.Image)
                {
                    try
                    {
                        symbol = new MedSymbol(Image.FromStream(Sundries.DecodeWithString(vitalSignCurveDetail.SymbolEntry)));
                    }
                    catch
                    {
                        symbol = new MedSymbol(MedSymbolType.None);
                    }
                }
                else
                {
                    symbol = new MedSymbol(vitalSignCurveDetail.SymbolType);
                }
                if (vitalSignCurveDetail.SymbolType == MedSymbolType.Text)
                {
                    symbol.Text = vitalSignCurveDetail.SymbolEntry;
                }
                color = vitalSignCurveDetail.Color;
                isDigit = vitalSignCurveDetail.ShowType == MedCurveShowType.Digit;
                curve = new MedVitalSignCurve(vitalSignCurveDetail.CurveName, vitalSignCurveDetail.CurveCode, vitalSignCurveDetail.YAxisIndex, color, symbol, isDigit);
                curve.DotNumber = vitalSignCurveDetail.DotNumber;
            }

            return curve;
        }


        private void _vitalGraph_ValueChanged(object sender, VitalSignPointEventArgs e)
        {
            MedVitalSignGraph control = sender as MedVitalSignGraph;
            if (control.NewMonitorData != null)
            {
                control.NewMonitorData.SetItem(e.Point.Time, e.Point.Curve.Code, e.Point.Value.ToString(), e.OldValue.ToString());
                AnesInformations.VitalSignDataTable _VitalSignData = base.DataSource["VitalSignData"] as AnesInformations.VitalSignDataTable;
                AnesInformations.VitalSignRow vitalSignRow = _VitalSignData.FindByTIME_POINTITEM_CODE(e.Point.Time, e.Point.Curve.Code);
                if (vitalSignRow != null)
                {
                    vitalSignRow.VALUE = e.Point.Value.ToString();
                    base.DataSource["VitalSignData"] = _VitalSignData;
                }
                base.HasDirty = true; 
            }
        }

        private ContextMenuStrip CreatVitalGraphMenu()
        {
            ContextMenuStrip popupMenu = new ContextMenuStrip();
            popupMenu.Items.Add("个性化体征显示", null, new EventHandler(toolStripMenuItemVitalShowSet_Click));
            popupMenu.Items.Add("密集体征显示", null, new EventHandler(toolStripMenuItemMiJiVitalShow_Click));
            popupMenu.Items.Add("取消血气", null, new EventHandler(toolStripMenuItemCanelBloodGas_Click));
            popupMenu.Opening += new System.ComponentModel.CancelEventHandler(popupMenu_Opening);
            return popupMenu;
        }

        private void popupMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MedVitalSignGraph vitalGraph = null;
            foreach (IUIElementHandler handler in MedicalPaperUIElementHandlers)
            {
                if (handler.GetControlType == typeof(MedVitalSignGraph) && handler.GetCurrentControl != null)
                    vitalGraph = handler.GetCurrentControl as MedVitalSignGraph;
            }

            if (vitalGraph == null)
                return;

            _currentGraph = vitalGraph;
            if (vitalGraph.IsMouseInMark)
            {
                e.Cancel = true;
                if (vitalGraph.MousePostion.X > 0 && vitalGraph.MousePostion.Y > 0 && vitalGraph.MouseTime > DateTime.MinValue)
                {
                    _currentTime = vitalGraph.MouseTime;

                    if (!ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_ANES_EVENT_OPEN"))
                        throw new NotImplementedException(string.Format("当前上下文缓存中不存在名为{0}的字典表", "WIS_ANES_EVENT_OPEN"));

                    Dict.AnesthesiaEventOpenDataTable eventOpenTable = ExtendApplicationContext.Current.CodeTables["WIS_ANES_EVENT_OPEN"] as Dict.AnesthesiaEventOpenDataTable;
                    eventOpenTable.DefaultView.RowFilter = "ITEM_CLASS = '1' or ITEM_CLASS = '7' or ITEM_CLASS = '8' or ITEM_CLASS = '9' or ITEM_CLASS ='A' or ITEM_CLASS ='U' or ITEM_CLASS ='Y'";
                    eventOpenTable.DefaultView.Sort = "ITEM_CLASS,ITEM_NO";
                    DataTable sourceTable = eventOpenTable.DefaultView.ToTable();

                    PopupDrugSelector.ShowSelector(sourceTable, _currentGraph, _currentGraph.MousePostion, _currentTime, this, "事件", 0);
                }
            }
            else
            {
                if (vitalGraph.MouseTime >= vitalGraph.StartTime && vitalGraph.MouseTime <= vitalGraph.EndTime && vitalGraph.SelectedBlood != null)
                {
                    vitalGraph.ContextMenuStrip.Items[2].Visible = true; ;
                }
                else
                {
                    vitalGraph.ContextMenuStrip.Items[2].Visible = false;
                }
            }

        }

        private void vitalSignGraph_DoubleClick(object sender, MouseEventArgs e)
        {
            MedVitalSignGraph vitalGraph = null;
            foreach (IUIElementHandler handler in MedicalPaperUIElementHandlers)
            {
                if (handler.GetControlType == typeof(MedVitalSignGraph) && handler.GetCurrentControl != null)
                    vitalGraph = handler.GetCurrentControl as MedVitalSignGraph;
            }
            if (vitalGraph != null && vitalGraph.MouseTime >= vitalGraph.StartTime && vitalGraph.MouseTime <= vitalGraph.EndTime && e.Y < 200)
            {
                string detailID = "";
                if (vitalGraph.SelectedBlood != null)
                {
                    detailID = vitalGraph.SelectedBlood.DetailId;
                }
                XtraForm form = new XtraForm();
                form.StartPosition = FormStartPosition.CenterScreen;
                TimePointBloodGasEditor timePointBloodGasEditor = new TimePointBloodGasEditor(ExtendApplicationContext.Current.PatientContext.PatientID,
                    ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID, detailID);
                timePointBloodGasEditor.TimePoint = vitalGraph.MouseTime;
                form.Width = 580;
                form.Height = 400;
                timePointBloodGasEditor.Dock = DockStyle.Fill;
                form.Controls.Add(timePointBloodGasEditor);
                form.Text = "血气记录";
                form.ShowDialog();
                RefreshData();
                vitalGraph.Invalidate();
            }
        }

        private void toolStripMenuItemCanelBloodGas_Click(object sender, EventArgs e)
        {
            MedVitalSignGraph vitalGraph = null;
            foreach (IUIElementHandler handler in MedicalPaperUIElementHandlers)
            {
                if (handler.GetControlType == typeof(MedVitalSignGraph) && handler.GetCurrentControl != null)
                    vitalGraph = handler.GetCurrentControl as MedVitalSignGraph;
            }
            if (DataContext.GetCurrent().CancelBloodGas(vitalGraph) > 0)
            {
                RefreshData();
                vitalGraph.Invalidate();
            }
        }

        private void toolStripMenuItemMiJiVitalShow_Click(object sender, EventArgs e)
        {
            MedVitalSignGraph vitalGraph = null;
            foreach (IUIElementHandler handler in MedicalPaperUIElementHandlers)
            {
                if (handler.GetControlType == typeof(MedVitalSignGraph) && handler.GetCurrentControl != null)
                    vitalGraph = handler.GetCurrentControl as MedVitalSignGraph;
            }
            if (vitalGraph != null)
            {
                XtraForm form = new XtraForm();
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Width = 1000;
                form.Height = 700;
                MijiVitalSign mijiVitalSign = new MijiVitalSign(vitalGraph, _eventNo);
                mijiVitalSign.Dock = DockStyle.Fill;
                form.Controls.Add(mijiVitalSign);
                form.Text = "密集体征显示";
                form.ShowDialog();
            }
        }

        private void toolStripMenuItemVitalShowSet_Click(object sender, EventArgs e)
        {
            List<MedVitalSignCurveDetail> list = GetUserVitalShowSet(_eventNo);
            Dictionary<string, MedVitalSignCurveDetail> dict = new Dictionary<string, MedVitalSignCurveDetail>();
            AnesInformations.VitalSignDataTable _VitalSignData = base.DataSource["VitalSignData"] as AnesInformations.VitalSignDataTable;
            foreach (MedVitalSignCurveDetail vitalSet in list)
            {
                if (!string.IsNullOrEmpty(vitalSet.CurveCode) && !dict.ContainsKey(vitalSet.CurveCode))
                {
                    dict.Add(vitalSet.CurveCode, vitalSet);
                }
                else if (string.IsNullOrEmpty(vitalSet.CurveCode) && !string.IsNullOrEmpty(vitalSet.CurveName))
                {
                    foreach (AnesInformations.VitalSignRow vrow in _VitalSignData.Rows)
                    {
                        if (vrow.ITEM_NAME.Equals(vitalSet.CurveName) && !dict.ContainsKey(vrow.ITEM_CODE))
                        {
                            dict.Add(vrow.ITEM_CODE, vitalSet);
                            break;
                        }
                    }
                }
            }
            MedVitalSignGraph _vitalGraph = null;
            foreach (IUIElementHandler handler in MedicalPaperUIElementHandlers)
            {
                if (handler.GetControlType == typeof(MedVitalSignGraph) && handler.GetCurrentControl != null)
                    _vitalGraph = handler.GetCurrentControl as MedVitalSignGraph;
            }
            if (_vitalGraph != null)
            {
                foreach (MedVitalSignCurve curve in _vitalGraph.Curves)
                {
                    if (!string.IsNullOrEmpty(curve.Code) && !dict.ContainsKey(curve.Code))
                    {
                        MedVitalSignCurveDetail vitalSet = new MedVitalSignCurveDetail();
                        vitalSet.CurveName = curve.Text;
                        vitalSet.CurveCode = string.IsNullOrEmpty(curve.Code) ? curve.Text : curve.Code;
                        vitalSet.Color = curve.Color;
                        if (GetVitalSignDetail(_vitalGraph, vitalSet.CurveCode) != null)
                        {
                            vitalSet.ShowTimeInterval = GetVitalSignDetail(_vitalGraph, vitalSet.CurveCode).ShowTimeInterval;
                        }
                        if (curve.IsDigit) vitalSet.ShowType = MedCurveShowType.Digit;
                        vitalSet.SymbolType = curve.Symbol.SymbolType;
                        if (vitalSet.SymbolType == MedSymbolType.Text)
                        {
                            vitalSet.SymbolEntry = curve.Symbol.Text;
                        }
                        vitalSet.YAxisIndex = curve.YAxisIndex;
                        vitalSet.DotNumber = curve.DotNumber;
                        if (!dict.ContainsKey(vitalSet.CurveCode))
                        {
                            dict.Add(vitalSet.CurveCode, vitalSet);
                            list.Add(vitalSet);
                        }
                    }
                }
            }

            MedVitalSignCurveDetail breath = null;
            MedVitalSignCurveDetail contrlbreath = null;
            MedVitalSignCurveDetail helpbreath = null;
            foreach (MedVitalSignCurveDetail vitalSet in list)
            {
                if (vitalSet.CurveName == "呼吸")
                    breath = vitalSet;
                else if (vitalSet.CurveName == "控制呼吸")
                    contrlbreath = vitalSet;
                else if (vitalSet.CurveName == "辅助呼吸")
                    helpbreath = vitalSet;
            }

            if (breath != null && contrlbreath == null)
            {
                MedVitalSignCurveDetail vitalSet = new MedVitalSignCurveDetail();
                vitalSet.CurveName = "控制呼吸";
                vitalSet.Color = breath.Color;
                vitalSet.CurveCode = "kzhx";
                vitalSet.DotNumber = breath.DotNumber;
                vitalSet.ShowTimeInterval = breath.ShowTimeInterval;
                vitalSet.SymbolEntry = breath.SymbolEntry;
                vitalSet.SymbolType = breath.SymbolType;
                vitalSet.Visible = breath.Visible;
                vitalSet.YAxisIndex = breath.YAxisIndex;
                list.Add(vitalSet);
            }
            if (breath != null && helpbreath == null)
            {
                MedVitalSignCurveDetail vitalSet = new MedVitalSignCurveDetail();
                vitalSet.CurveName = "辅助呼吸";
                vitalSet.Color = breath.Color;
                vitalSet.CurveCode = "fzhx";
                vitalSet.DotNumber = breath.DotNumber;
                vitalSet.ShowTimeInterval = breath.ShowTimeInterval;
                vitalSet.SymbolEntry = breath.SymbolEntry;
                vitalSet.SymbolType = breath.SymbolType;
                vitalSet.Visible = breath.Visible;
                vitalSet.YAxisIndex = breath.YAxisIndex;
                list.Add(vitalSet);
            }


            XtraForm form = new XtraForm();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Width = 1000;
            form.Height = 600;
            VitalSignShowEditor vitalSignShowEditor = new VitalSignShowEditor(list);
            vitalSignShowEditor.Dock = DockStyle.Fill;
            form.Controls.Add(vitalSignShowEditor);
            form.Text = "个性化体征显示设置";

            object result = form.ShowDialog();
            if (result != null && (DialogResult)result == DialogResult.OK)
            {
                string tableName = "UserVitalShowSet" + ((_eventNo < 0) ? 0 : _eventNo).ToString();
                DataTable dataTable = new DataTable(tableName);//复苏单可约定数据表名称为UserVitalShowSet1,末尾与EventNo关联
                System.Reflection.PropertyInfo[] propertyInfos = typeof(MedVitalSignCurveDetail).GetProperties();
                foreach (System.Reflection.PropertyInfo propertyInfo in propertyInfos)
                {
                    dataTable.Columns.Add(propertyInfo.Name);
                }
                foreach (MedVitalSignCurveDetail obj in list)
                {
                    DataRow row = dataTable.NewRow();
                    foreach (System.Reflection.PropertyInfo propertyInfo in propertyInfos)
                    {
                        row[propertyInfo.Name] = AssemblyHelper.GetPropertyValue(propertyInfo, obj);
                    }
                    dataTable.Rows.Add(row);
                }
                System.IO.MemoryStream stream = new System.IO.MemoryStream();
                dataTable.WriteXml(stream);
                stream.Position = 0;
                byte[] bytes = FileHelper.StreamToBytes(stream);

                ConfigurationDA configurationDA = new ConfigurationDA();
                Configuations.PatientMonitorConfigDataTable configTable = configurationDA.GetPatientMonitorConfigDataTable(
                    ExtendApplicationContext.Current.PatientContext.PatientID,
                    ExtendApplicationContext.Current.PatientContext.VisitID,
                    ExtendApplicationContext.Current.PatientContext.OperID);

                if (configTable == null || configTable.Count == 0)
                {
                    configTable = new Configuations.PatientMonitorConfigDataTable();
                    Configuations.PatientMonitorConfigRow newRow = configTable.NewPatientMonitorConfigRow();
                    newRow.PAT_ID = ExtendApplicationContext.Current.PatientContext.PatientID;
                    newRow.VISIT_ID = ExtendApplicationContext.Current.PatientContext.VisitID;
                    newRow.OPER_ID = ExtendApplicationContext.Current.PatientContext.OperID;
                    configTable.AddPatientMonitorConfigRow(newRow);
                }
                configTable[0].CONTENT = bytes;
                if (configurationDA.UpdatePatientMonitorConfigDataTable(configTable) > 0)
                {
                    RefreshData();
                    _vitalGraph.Invalidate();

                }
                stream.Close();
                stream.Dispose();
            }
        }

        /// <summary>
        /// 从曲线明细设置集合读取曲线明细
        /// </summary>
        /// <param name="vitalSignGraph"></param>
        /// <param name="itemName"></param>
        /// <returns></returns>
        private MedVitalSignCurveDetail GetVitalSignDetail(MedVitalSignGraph vitalSignGraph, string itemCode)
        {
            foreach (MedVitalSignCurveDetail detail in vitalSignGraph.CurveDetails)
            {
                if (!string.IsNullOrEmpty(detail.CurveCode))
                {
                    if (detail.CurveCode.ToLower().Trim().Equals(itemCode.ToLower().Trim()))
                    {
                        return detail;
                    }
                }
                else
                {
                    if (detail.CurveName.ToLower().Trim().Equals(itemCode.ToLower().Trim()))//兼容以前曲线以Name为唯一标示
                    {
                        return detail;
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// 是否为麻醉事件
        /// </summary>
        /// <param name="eventName"></param>
        /// <returns></returns>
        public static bool IsAnesthesiaEvent(string eventName)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(eventName))
            {
                string ev = eventName.Trim();
                result = ev.Equals(EventNames.ANESSTART) || ev.Equals(EventNames.ANESEND);
            }
            return result;
        }


        private MedSymbolCurveDetail GetVitalSignEventMark(MedVitalSignGraph vitalSignGraph, string curveText)
        {
            foreach (MedSymbolCurveDetail curveDetail in vitalSignGraph.EventMarkSettings)
            {
                string text1 = curveText.Trim();
                string text2 = curveDetail.Text.Trim();
                if (text1.ToLower().Equals(text2.ToLower()) || text1.ToLower().StartsWith(text2.ToLower() + "("))
                {
                    return curveDetail;
                }
                else if ((text2.EndsWith("%") && text1.StartsWith(text2.Substring(0, text2.Length - 2))) ||
                    (text2.StartsWith("%") && text1.EndsWith(text2.Substring(1))) ||
                    (text2.StartsWith("%") && text2.EndsWith("%") && text1.Contains(text2.Substring(1, text2.Length - 2))))
                {
                    return curveDetail;
                }
            }
            return null;
        }

        private bool IsOperationEvent(string eventName)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(eventName))
            {
                string ev = eventName.Trim();
                result = ev.Equals(EventNames.OPERATIONSTART) || ev.Equals(EventNames.OPERATIONEND);
            }
            return result;
        }
        /// <summary>
        /// 随机标识
        /// </summary>
        private MedSymbol GetRandomSymbol()
        {
            System.Threading.Thread.Sleep(1);
            Random rand = new Random();
            return new MedSymbol((MedSymbolType)rand.Next((int)MedSymbolType.Image) - 1);

        }
        /// <summary>
        /// 增加麻醉事件
        /// </summary>
        /// <param name="vitalSignGraph"></param>
        /// <param name="eventMark"></param>
        private void AddAnesEventMark(MedVitalSignGraph vitalSignGraph, EventMark eventMark, DateTime eventTime, string anesFlag)
        {
            Color color = Color.Black;
            string alias = "";
            MedSymbol symbol = null;
            MedSymbolCurveDetail detail = GetVitalSignEventMark(vitalSignGraph, anesFlag);
            if (detail != null)
            {
                symbol = new MedSymbol(detail.SymbolType);
                if (symbol.SymbolType == MedSymbolType.Text)
                {
                    symbol.Text = detail.SymbolEntry;
                }
                symbol.Pen = new Pen(detail.Color);
                color = detail.Color;
                alias = anesFlag;
            }
            else
            {
                symbol = new MedSymbol(MedSymbolType.Anesthesia);
            }
            eventMark.AddPoint(eventTime, 0, anesFlag, symbol, color, alias);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private string GetTwText(int index)
        {
            string text = null;
            switch (index)
            {
                case 0:
                    text = ApplicationConfiguration.GetAppSetting("QianBingXing");
                    if (string.IsNullOrEmpty(text))
                        text = "前并行";
                    break;
                case 1:
                    text = ApplicationConfiguration.GetAppSetting("QuanXunHuan");
                    if (string.IsNullOrEmpty(text))
                        text = "全循环";
                    break;
                case 2:
                    text = ApplicationConfiguration.GetAppSetting("HouBingXing");
                    if (string.IsNullOrEmpty(text))
                        text = "后并行";
                    break;
            }
            return text;
        }
        /// <summary>
        /// 增加麻醉开始事件
        /// </summary>
        /// <param name="vitalSignGraph"></param>
        /// <param name="eventMark"></param>
        private void AddAnesStartEventMark(MedVitalSignGraph vitalSignGraph, EventMark eventMark)
        {
            Color color = Color.Black;
            string alias = "麻醉";
            MedSymbol symbol = null;
            MedSymbolCurveDetail detail = GetVitalSignEventMark(vitalSignGraph, alias);
            if (detail != null)
            {
                symbol = new MedSymbol(detail.SymbolType);
                if (symbol.SymbolType == MedSymbolType.Text)
                {
                    symbol.Text = detail.SymbolEntry;
                }
                symbol.Pen = new Pen(detail.Color);
                color = detail.Color;
                alias = "麻醉";
            }
            else
            {
                symbol = new MedSymbol(MedSymbolType.Anesthesia);
            }
            //eventMark.AddPoint(Globals.AnesStartTime, 0, EventNames.ANESSTART, symbol, color, alias);

        }

    }
}
