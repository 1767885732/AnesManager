using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.Framework.Controls;
using Wis.Anes.Framework.Documents;
using Wis.Anes.BusinessEntity;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Wis.Anes.Framework.Constants;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.Framework;
using Wis.Anes.Framework.Doc;
using Wis.Anes.Framework.Controls.Base;
using Wis.Anes.Custom.Views;

namespace Wis.Anes.Custom.CustomProject
{
    public class AnesSheetDetailsHandler : UIElementHandler<MedAnesSheetDetails>
    {
        /// <summary>
        /// 绑定数据源数据到控件
        /// </summary>
        /// <param name="control"></param>
        /// <param name="dataSources"></param>
        public override void BindDataToUI(MedAnesSheetDetails control, Dictionary<string, System.Data.DataTable> dataSources)
        {

            if (!dataSources.ContainsKey("AnesthesiaEvent"))
                throw new NotImplementedException(string.Format("在数据源中未找到名为{0}的表AnesInformations.AnesthesiaEventDataTable,请添加此绑定数据源!", "AnesthesiaEvent"));

            AnesInformations.AnesthesiaEventDataTable anesEventTable = dataSources["AnesthesiaEvent"] as AnesInformations.AnesthesiaEventDataTable;

            if (!dataSources.ContainsKey("WIS_OPER_MASTER"))
                throw new NotImplementedException(string.Format("在数据源中未找到名为{0}的表AnesInformations.OperationMasterDataTable,请添加此绑定数据源!", "WIS_OPER_MASTER"));

            AnesInformations.OperationMasterDataTable operationMasterDataTable = dataSources["WIS_OPER_MASTER"] as AnesInformations.OperationMasterDataTable;

            if (PagerSetting.PageTimeSpan.StartDateTime != DateTime.MinValue)
            {
                control.StartTime = PagerSetting.PageTimeSpan.StartDateTime;
                control.EndTime = PagerSetting.PageTimeSpan.EndDateTime;
            }


            control.Collections.Clear();

            if (control.Group)
            {
                MedAnesSheetDetailCollection collection;
                if (control.HasEvent)
                {
                    List<AnesClassType> anesClassList = new List<AnesClassType>();
                    anesClassList.Add(AnesClassType.Event);
                    if (control.HasZhiGuan)
                    {
                        anesClassList.Add(AnesClassType.PutPipe);
                    }
                    if (control.HasFuji)
                    {
                        anesClassList.Add(AnesClassType.ECG);
                    }
                    AnesClassType[] anesClasses = anesClassList.ToArray();
                    collection = GenDetailCollection(anesEventTable, anesClasses, "事件", CollectionType.Event, control.StartTime, null, AnesDrugShowType.Total, false, operationMasterDataTable);
                    control.Collections.Add(collection);
                    if (collection != null) collection.Color = control.EventColor;
                }
                if (control.HasAnesDrug)
                {
                    collection = AddAnesSheetDetailCollection(control, anesEventTable, AnesClassType.AnesDrug, "诱导", CollectionType.Drug, ApplicationConfiguration.YouDaoColor, control.StartTime, control.AnesDrugShowType, true, operationMasterDataTable);
                    collection = AddAnesSheetDetailCollection(control, anesEventTable, AnesClassType.AnesDrug, "麻药", CollectionType.Drug, control.AnesDrugColor, control.StartTime, control.AnesDrugShowType, false, operationMasterDataTable);
                }
                if (control.HasCommonDrug)
                {
                    collection = AddAnesSheetDetailCollection(control, anesEventTable, AnesClassType.Drug, "用药", CollectionType.Drug, control.DrugColor, control.StartTime, false, operationMasterDataTable);
                }
                //AddAnesSheetDetailCollection(control, anesEventTable, AnesClassType.Drug, "用药", CollectionType.Drug, control.DrugColor, control.StartTime, false, operationMasterDataTable);
                if (control.HasLiquid)
                {
                    collection = GenDetailCollection(anesEventTable, new AnesClassType[] { AnesClassType.InLiquid, AnesClassType.InBlood }, "输液和输血", CollectionType.Drug, control.StartTime, null, AnesDrugShowType.Total, false, operationMasterDataTable);
                    if (collection != null)
                    {
                        collection.Color = control.InLiquidColor;
                        control.Collections.Add(collection);
                    }
                }

                if (control.HasOutLiquid)
                {
                    collection = GenDetailCollection(anesEventTable, new AnesClassType[] { AnesClassType.OutLiquid }, "出液", CollectionType.Drug, control.StartTime, null, AnesDrugShowType.Total, false, operationMasterDataTable);
                    if (collection != null)
                    {
                        collection.Color = control.InLiquidColor;
                        control.Collections.Add(collection);
                    }
                }

                if (control.IsTimeOrder)
                {
                    MedAnesSheetDetailCollection collection99 = new MedAnesSheetDetailCollection("事件");
                    for (int i = control.Collections.Count - 1; i >= 0; i--)
                    {
                        MedAnesSheetDetailCollection cl = control.Collections[i];
                        collection99.Add(cl);
                        control.Collections.Remove(cl);
                    }
                    collection99.Sort();
                    for (int i = collection99.Points.Count - 1; i >= 0; i--)
                    {
                        collection99.Points[i].Index = i + 1;
                    }
                    control.Collections.Add(collection99);
                }
                else
                {
                    for (int i = control.Collections.Count - 1; i >= 0; i--)
                    {
                        MedAnesSheetDetailCollection cl = control.Collections[i];
                        if (cl != null && cl.Points != null)
                        {
                            for (int j = cl.Points.Count - 1; j >= 0; j--)
                            {
                                cl.Points[j].Color = cl.Color;
                            }
                        }
                    }
                }
            }
            else
            {
                List<AnesClassType> types = new List<AnesClassType>();


                foreach (int enumValue in Enum.GetValues(typeof(AnesClassType)))
                {
                    types.Add((AnesClassType)enumValue);
                }

                types.Remove(AnesClassType.DataModify);
                if (!control.HasEvent) types.Remove(AnesClassType.Event);
                if (!control.HasZhiGuan)
                {
                    types.Remove(AnesClassType.PutPipe);

                    types.Remove(AnesClassType.PullPipe);
                }
                if (!control.HasAnesDrug) types.Remove(AnesClassType.AnesDrug);

                if (!control.HasCommonDrug) types.Remove(AnesClassType.Drug);

                if (!control.HasFuji)
                {

                    types.Add(AnesClassType.ECG);
                }
                if (!control.HasLiquid)
                {
                    types.Remove(AnesClassType.InLiquid);
                }
                types.Remove(AnesClassType.InBlood);
                if (!control.HasOutLiquid)
                {
                    types.Remove(AnesClassType.OutLiquid);
                }
                MedAnesSheetDetailCollection collection00 = null;
                if (control.HasAnesDrug)
                {
                    collection00 = AddAnesSheetDetailCollection(control, anesEventTable, types.ToArray(), "事件", CollectionType.Event, control.EventColor, control.StartTime, null, AnesDrugShowType.Total, false, operationMasterDataTable);

                }
                else
                {
                    collection00 = AddAnesSheetDetailCollection(control, anesEventTable, types.ToArray(), "事件", CollectionType.Event, control.EventColor, control.StartTime, GetAnesClassTypeString(AnesClassType.AnesDrug), AnesDrugShowType.Total, false, operationMasterDataTable);
                }


                if (collection00 != null) collection00.Color = control.EventColor;





            }
            ////去掉重复的药
            //MedDrugGraph drugGraph = null;//GetAnesGraph<MedDrugGraph>();
            //foreach (IUIElementHandler handler in MedicalPaperUIElementHandlers)
            //{
            //    if (handler.GetControlType == typeof(MedDrugGraph) && handler.GetCurrentControl != null)
            //        drugGraph = handler.GetCurrentControl as MedDrugGraph;
            //}

            //if (drugGraph != null)
            //{
            //    for (int i = 0; i < drugGraph.Curves.Count; i++)
            //    {
            //        foreach (MedAnesSheetDetailCollection collect in control.Collections)
            //        {
            //            MedAnesSheetDetailPoint point = null;
            //            for (int ii = 0; ii < collect.Points.Count; ii++)
            //            {
            //                point = collect.Points[ii];
            //                if (point.Text.ToLower() == drugGraph.Curves[i].Text.ToLower())
            //                {
            //                    collect.Points.Remove(point);
            //                    ii = ii - 1;
            //                    // continue;
            //                }
            //            }
            //            //重新给序号
            //            for (int ii = 0; ii < collect.Points.Count; ii++)
            //            {
            //                point = collect.Points[ii];
            //                point.Index = ii + 1;

            //            }

            //        }
            //    }
            //}



            ////}

            ////去掉重复的输血输液
            //MedGridGraph gridGraph = null;// GetAnesGraph<MedGridGraph>();
            //foreach (IUIElementHandler handler in MedicalPaperUIElementHandlers)
            //{
            //    if (handler.GetControlType == typeof(MedGridGraph) && handler.GetCurrentControl != null)
            //        gridGraph = handler.GetCurrentControl as MedGridGraph;
            //}
            //if (gridGraph != null)
            //{
            //    for (int i = 0; i < gridGraph.Rows.Count; i++)
            //    {
            //        foreach (MedAnesSheetDetailCollection collect in control.Collections)
            //        {
            //            MedAnesSheetDetailPoint point = null;
            //            for (int ii = 0; ii < collect.Points.Count; ii++)
            //            {
            //                point = collect.Points[ii];
            //                if (point.Text.ToLower() == gridGraph.Rows[i].Text.ToLower())
            //                {
            //                    collect.Points.Remove(point);
            //                    ii = ii - 1;
            //                }
            //            }
            //            //重新给序号
            //            for (int ii = 0; ii < collect.Points.Count; ii++)
            //            {
            //                point = collect.Points[ii];
            //                point.Index = ii + 1;

            //            }

            //        }

            //    }
            //}
        }
        /// <summary>
        /// 绑定控件内容到数据源
        /// </summary>
        /// <param name="control"></param>
        /// <param name="dataSources"></param>
        public override void BindUIToData(MedAnesSheetDetails control, Dictionary<string, System.Data.DataTable> dataSources)
        {

        }
        /// <summary>
        /// 控件的属性事件设置
        /// </summary>
        /// <param name="control"></param>
        public override void ControlSetting(MedAnesSheetDetails control)
        {
            control.OriginWidth = control.Width;
            control.OriginHeight = control.Height;

            control.CustomEdit += new AnesBand.AnesBandEventHandle(control_CustomEdit);
        }

        private AnesInformations.AnesthesiaEventDataTable GetAnesthesiaEvent(AnesInformations.AnesthesiaEventDataTable anesEventTable, AnesClassType[] anesClasses)
        {
            if (anesEventTable != null && anesClasses != null && anesClasses.Length > 0)
            {
                string rowFilter = "(ITEM_CLASS = '" + GetAnesClassTypeString(anesClasses[0]) + "')";
                for (int i = 1; i < anesClasses.Length; i++)
                {
                    rowFilter += " OR (ITEM_CLASS = '" + GetAnesClassTypeString(anesClasses[i]) + "')";
                }
                anesEventTable.DefaultView.RowFilter = rowFilter;
                AnesInformations.AnesthesiaEventDataTable targetTable = new AnesInformations.AnesthesiaEventDataTable();
                CopyTable(anesEventTable.DefaultView.ToTable(), targetTable);
                //AnesInformations.AnesthesiaEventDataTable targetTable= anesEventTable.DefaultView.ToTable() as AnesInformations.AnesthesiaEventDataTable;
                return targetTable;
            }
            return null;
        }
        /// <summary>
        /// 复制数据表
        /// </summary>
        /// <param name="sourceTable">源数据表</param>
        /// <param name="targetTable">目标数据表</param>
        private void CopyTable(DataTable sourceTable, DataTable targetTable)
        {
            for (int i = 0; i < sourceTable.Rows.Count; i++)
            {
                DataRow row = targetTable.NewRow();
                for (int j = 0; j < sourceTable.Columns.Count; j++)
                {
                    row[j] = sourceTable.Rows[i][j];
                }
                targetTable.Rows.Add(row);
            }
        }


        private MedAnesSheetDetailCollection AddAnesSheetDetailCollection(MedAnesSheetDetails anesDetail, AnesInformations.AnesthesiaEventDataTable anesEventTable, AnesClassType anesClassType, string collectionText, CollectionType collectionType, Color collectionColor, DateTime startDate, bool isYouDao, AnesInformations.OperationMasterDataTable operationMasterDataTable)
        {
            return AddAnesSheetDetailCollection(anesDetail, anesEventTable, anesClassType, collectionText, collectionType, collectionColor, startDate, AnesDrugShowType.Total, isYouDao, operationMasterDataTable);
        }

        private MedAnesSheetDetailCollection AddAnesSheetDetailCollection(MedAnesSheetDetails anesDetail, AnesInformations.AnesthesiaEventDataTable anesEventTable, AnesClassType anesClassType, string collectionText, CollectionType collectionType, Color collectionColor, DateTime startDate, AnesDrugShowType drugShowType, bool isYouDao, AnesInformations.OperationMasterDataTable operationMasterDataTable)
        {
            return AddAnesSheetDetailCollection(anesDetail, anesEventTable, new AnesClassType[] { anesClassType }, collectionText, collectionType, collectionColor, startDate, null, drugShowType, isYouDao, operationMasterDataTable);
        }

        private MedAnesSheetDetailCollection AddAnesSheetDetailCollection(MedAnesSheetDetails anesDetail, AnesInformations.AnesthesiaEventDataTable anesEventTable, AnesClassType[] anesClasses, string collectionText, CollectionType collectionType, Color collectionColor, DateTime startDate, string filtItemName, AnesDrugShowType drugShowType, bool isYouDao, AnesInformations.OperationMasterDataTable operationMasterDataTable)
        {
            MedAnesSheetDetailCollection collection = GenDetailCollection(anesEventTable, anesClasses, collectionText, collectionType, startDate, filtItemName, drugShowType, isYouDao, operationMasterDataTable);
            if (collection != null)
            {
                collection.Color = collectionColor;
                anesDetail.Collections.Add(collection);
            }
            return collection;
        }

        private MedAnesSheetDetailCollection GenDetailCollection(AnesInformations.AnesthesiaEventDataTable anesEventTable, AnesClassType[] anesClasses, string collectionText, CollectionType collectionType, DateTime startDate, string filtItemName, AnesDrugShowType drugShowType, bool isYouDao, AnesInformations.OperationMasterDataTable operationMasterDataTable)
        {
            MedAnesSheetDetailCollection collection = new MedAnesSheetDetailCollection(collectionText);
            AnesInformations.AnesthesiaEventDataTable anesthesiaEventDataTable;
            ///获取事件数据
            if (anesClasses != null)
            {
                anesthesiaEventDataTable = GetAnesthesiaEvent(anesEventTable, anesClasses);
            }
            else
            {
                anesthesiaEventDataTable = anesEventTable;
            }
            if (anesthesiaEventDataTable != null && anesthesiaEventDataTable.Count > 0)
            {
                int idx = 0;//麻药超过7条的显示 20210926
                int idxC = 0;//用药超过5条的显示20210926
                foreach (AnesInformations.AnesthesiaEventRow row in anesthesiaEventDataTable)
                {
                    if(row.ITEM_CLASS=="2"|| row.ITEM_CLASS == "4")
                    {
                        if (idx < 7)
                        {
                            idx++;
                            continue;
                        }
                    }

                    if (row.ITEM_CLASS == "C")
                    {
                        if (idxC < 5)
                        {
                            idxC++;
                            continue;
                        }
                    }
                    if (!isYouDao && !row.IsEVENT_ATTRNull() && row.EVENT_ATTR.Equals(EventNames.YOUDAONUMBER)) continue;
                    if (isYouDao && (row.IsEVENT_ATTRNull() || !row.EVENT_ATTR.Equals(EventNames.YOUDAONUMBER))) continue;
                    if (row.IsITEM_NAMENull()) continue;
                    for (int i = 0; i < 1; i++)
                    {
                        if (!string.IsNullOrEmpty(filtItemName))
                        {
                            if (!row.IsITEM_CLASSNull() && filtItemName.Equals(row.ITEM_CLASS))
                            {
                                continue;
                            }
                        }
                        switch (collectionType)
                        {
                            case CollectionType.Event:
                                MedAnesSheetDetailPoint pt = null;
                                if (!row.IsSTART_DATE_TIMENull() && !row.IsEND_DATE_TIMENull() && !IsTimeEvent(row.ITEM_NAME))
                                {
                                    DateTime startTime = PraseDate(startDate, row.START_DATE_TIME);
                                    DateTime endTime = PraseDate(startDate, row.END_DATE_TIME);
                                    if (endTime > startTime)
                                    {
                                        pt = new MedAnesSheetDetailPoint(startTime, endTime, row.ITEM_NAME, row);
                                        collection.Points.Add(pt);
                                        pt.Color = collection.Color;
                                    }
                                    else
                                    {
                                        pt = new MedAnesSheetDetailPoint(startTime, row.ITEM_NAME, row);
                                        collection.Points.Add(pt);
                                        pt.Color = collection.Color;
                                    }
                                }
                                else if (!row.IsSTART_DATE_TIMENull() && !IsTimeEvent(row.ITEM_NAME))
                                {
                                    //pt = new MedAnesSheetDetailPoint(PraseDate(startDate, row.START_TIME), row.ITEM_NAME, row);
                                    pt = new MedAnesSheetDetailPoint(row.START_DATE_TIME, row.ITEM_NAME);
                                    collection.Points.Add(pt);
                                    pt.Color = collection.Color;
                                }
                                if (pt != null)
                                {
                                    if (!row.IsDOSAGE_UNITSNull())
                                    {
                                        pt.Unit = row.DOSAGE_UNITS;
                                    }
                                    if (!row.IsDOSAGENull() && row.DOSAGE > 0)
                                    {
                                        pt.Value = (double)row.DOSAGE;
                                    }
                                    if (!row.IsADMINISTRATORNull())
                                    {
                                        pt.Route = row.ADMINISTRATOR;
                                    }
                                }
                                break;
                            case CollectionType.Drug:
                                if (!row.IsSTART_DATE_TIMENull() && !row.IsDOSAGE_UNITSNull() && !row.IsDOSAGENull())
                                {
                                    bool canAdd = true;
                                    if (drugShowType != AnesDrugShowType.Total)
                                    {
                                        AnesDrugShowType stype = (!row.IsDURATIVE_INDICATORNull() && row.DURATIVE_INDICATOR == 1) ? AnesDrugShowType.ProLonged : AnesDrugShowType.SinglePoint;
                                        canAdd = stype == drugShowType;
                                    }
                                    if (canAdd)//&& (_items == null || !_items.Contains(row.ITEM_NAME)))
                                    {
                                        double value = 0;
                                        if (!row.IsDOSAGENull()) value = (double)row.DOSAGE;
                                        if (!row.IsEND_DATE_TIMENull())
                                        {
                                            DateTime startTime = PraseDate(startDate, row.START_DATE_TIME);
                                            DateTime endTime = PraseDate(startDate, row.END_DATE_TIME);
                                            if (endTime > startTime)
                                            {
                                                MedAnesSheetDetailPoint ppt = new MedAnesSheetDetailPoint(startTime, endTime, row.ITEM_NAME, value, row.DOSAGE_UNITS, (row.IsADMINISTRATORNull() ? "" : row.ADMINISTRATOR), row);
                                                collection.Points.Add(ppt);
                                                ppt.Color = collection.Color;
                                            }
                                            else
                                            {
                                                MedAnesSheetDetailPoint ppt = new MedAnesSheetDetailPoint(startTime, row.ITEM_NAME, value, row.DOSAGE_UNITS, (row.IsADMINISTRATORNull() ? "" : row.ADMINISTRATOR), row);
                                                collection.Points.Add(ppt);
                                                ppt.Color = collection.Color;
                                            }
                                        }
                                        else
                                        {
                                            MedAnesSheetDetailPoint ppt = new MedAnesSheetDetailPoint(PraseDate(startDate, row.START_DATE_TIME), row.ITEM_NAME, value, row.DOSAGE_UNITS, (row.IsADMINISTRATORNull() ? "" : row.ADMINISTRATOR), row);
                                            collection.Points.Add(ppt);
                                            ppt.Color = collection.Color;
                                        }
                                    }
                                }
                                break;
                        }
                    }
                }




            }


            if (collectionType == CollectionType.Event)
            {
                if (operationMasterDataTable != null && operationMasterDataTable.Count == 1)
                {
                    if (ExtendApplicationContext.Current.EventNo == 0)
                    {
                        //Modify @2014-02-12，判断当前页的时间范围内是否有入手术室和出手术室事件
                        if (!operationMasterDataTable[0].IsIN_DATE_TIMENull() &&
                            operationMasterDataTable[0].IN_DATE_TIME >= PagerSetting.PageTimeSpan.StartDateTime &&
                            operationMasterDataTable[0].IN_DATE_TIME <= PagerSetting.PageTimeSpan.EndDateTime)//入手术室
                        {
                            MedAnesSheetDetailPoint pt = new MedAnesSheetDetailPoint(operationMasterDataTable[0].IN_DATE_TIME, EventNames.INDATETIME, null);
                            pt.Color = collection.Color;
                            collection.Points.Add(pt);

                        }

                        if (!operationMasterDataTable[0].IsSTART_DATE_TIMENull() &&
                            operationMasterDataTable[0].START_DATE_TIME >= PagerSetting.PageTimeSpan.StartDateTime &&
                            operationMasterDataTable[0].START_DATE_TIME <= PagerSetting.PageTimeSpan.EndDateTime)//手术开始
                        {
                            MedAnesSheetDetailPoint pt = new MedAnesSheetDetailPoint(operationMasterDataTable[0].START_DATE_TIME, EventNames.OPERATIONSTART,null);
                            pt.Color = collection.Color;
                            collection.Points.Add(pt);
                        }

                        if (!operationMasterDataTable[0].IsEND_DATE_TIMENull() &&
                            operationMasterDataTable[0].END_DATE_TIME >= PagerSetting.PageTimeSpan.StartDateTime &&
                            operationMasterDataTable[0].END_DATE_TIME <= PagerSetting.PageTimeSpan.EndDateTime)//手术结束
                        {
                            MedAnesSheetDetailPoint pt = new MedAnesSheetDetailPoint(operationMasterDataTable[0].END_DATE_TIME, EventNames.OPERATIONEND, null);
                            pt.Color = collection.Color;
                            collection.Points.Add(pt);
                        }



                        /*苏大不需要显示大事件
                        if (!operationMasterDataTable[0].IsANES_START_TIMENull())//麻醉开始
                        {
                            MedAnesSheetDetailPoint pt = new MedAnesSheetDetailPoint(operationMasterDataTable[0].ANES_START_TIME, Globals.ANESSTART);
                            pt.Color = collection.Color;
                            collection.Points.Add(pt);
                        }
                        if (!operationMasterDataTable[0].IsSTART_DATE_TIMENull())//手术开始
                        {
                            MedAnesSheetDetailPoint pt = new MedAnesSheetDetailPoint(operationMasterDataTable[0].START_DATE_TIME, Globals.OPERATIONSTART);
                            pt.Color = collection.Color;
                            collection.Points.Add(pt);
                        }
                        if (!operationMasterDataTable[0].IsEND_DATE_TIMENull())//手术结束
                        {
                            MedAnesSheetDetailPoint pt = new MedAnesSheetDetailPoint(operationMasterDataTable[0].END_DATE_TIME, Globals.OPERATIONEND);
                            pt.Color = collection.Color;
                            collection.Points.Add(pt);
                        }
                        if (!operationMasterDataTable[0].IsANES_END_TIMENull())//麻醉结束
                        {
                            MedAnesSheetDetailPoint pt = new MedAnesSheetDetailPoint(operationMasterDataTable[0].ANES_END_TIME, Globals.ANESEND);
                            pt.Color = collection.Color;
                            collection.Points.Add(pt);
                        }
                  *  */
                        if (!operationMasterDataTable[0].IsOUT_DATE_TIMENull() &&
                       operationMasterDataTable[0].OUT_DATE_TIME >= PagerSetting.PageTimeSpan.StartDateTime &&
                       operationMasterDataTable[0].OUT_DATE_TIME <= PagerSetting.PageTimeSpan.EndDateTime)//出手术室
                        {
                            MedAnesSheetDetailPoint pt = new MedAnesSheetDetailPoint(operationMasterDataTable[0].OUT_DATE_TIME, "出手术室", null);
                            pt.Color = collection.Color;
                            collection.Points.Add(pt);
                        }
                    }
                    //End Modify
                    else if (ExtendApplicationContext.Current.EventNo == 1)
                    {
                        if (!operationMasterDataTable[0].IsIN_PACU_DATE_TIMENull())//进PACU
                        {
                            MedAnesSheetDetailPoint pt = new MedAnesSheetDetailPoint(operationMasterDataTable[0].IN_PACU_DATE_TIME, EventNames.INPACU, null);
                            pt.Color = collection.Color;
                            collection.Points.Add(pt);
                        }
                        if (!operationMasterDataTable[0].IsOUT_PACU_DATE_TIMENull())//出PACU
                        {
                            MedAnesSheetDetailPoint pt = new MedAnesSheetDetailPoint(operationMasterDataTable[0].OUT_PACU_DATE_TIME, EventNames.OUTPACU, null);
                            pt.Color = collection.Color;
                            collection.Points.Add(pt);
                        }
                    }
                }
            }
            collection.Sort();
            collection.CollectionType = collectionType;
            return collection;
        }
        /// <summary>
        /// 调整时间的日期为指定日期，并保证不小于该日期（小于时日期加1）
        /// </summary>
        /// <param name="theDate">指定日期</param>
        /// <param name="sourceDateTime">要调整的日期</param>
        /// <returns>调整后的日期</returns>
        private DateTime PraseDate(DateTime theDate, DateTime sourceDateTime)
        {
            DateTime date = new DateTime(theDate.Year, theDate.Month, theDate.Day, sourceDateTime.Hour, sourceDateTime.Minute, sourceDateTime.Second);
            DateTime date1 = new DateTime(theDate.Year, theDate.Month, theDate.Day, theDate.Hour, theDate.Minute, theDate.Second);
            if (date < date1) date = date.AddDays(1);
            return date;
        }
        protected AnesClassType GetAnesTypeFromString(string classstr)
        {
            string anesClassTypeStrings = "0123456789ABCXYOZ~DU";
            int index = anesClassTypeStrings.IndexOf(classstr);
            if (index < 0)
                return AnesClassType.Unknow;

            return (AnesClassType)index;
        }
        protected void control_CustomEdit(AnesBand sender, object selectObject, EventArgs e)
        {
            MedAnesSheetDetailPoint pt = selectObject as MedAnesSheetDetailPoint;
            if (pt == null)
                return;


            if (pt.DataRow == null)
                return;

            AnesInformations.AnesthesiaEventDataTable anesEvent = base.DataSource["AnesthesiaEvent"] as AnesInformations.AnesthesiaEventDataTable;
            DataRow[] rows = anesEvent.Select(string.Format("ITEM_NO = {0}", pt.DataRow["ITEM_NO"]));
            if (rows.Length < 1)
                return;
            DataRow row = rows[0];
            AnesClassType anestype = GetAnesTypeFromString(row["ITEM_CLASS"].ToString());

            EditEventItem editItem = new EditEventItem();
            editItem.DataSource = row;
            editItem.IsAllowDel = true;
            editItem.ItemType = EditEventItem.ItemTypes.EventItem;
            string title = "";

            switch (anestype)
            {
                case AnesClassType.AnesDrug:
                case AnesClassType.Drug:
                    title = "用药";
                    editItem.ItemType = EditEventItem.ItemTypes.MedicineItem;
                    break;
                case AnesClassType.InBlood:
                case AnesClassType.InLiquid:
                    editItem.ItemType = EditEventItem.ItemTypes.MedicineItem;
                    title = "输血及输液";
                    break;
                case AnesClassType.InOxygen:
                    title = "输氧";
                    editItem.ItemType = EditEventItem.ItemTypes.MedicineItem;
                    break;
                case AnesClassType.PullPipe:
                case AnesClassType.PutPipe:
                case AnesClassType.Event:
                    title = "事件";
                    break;
                default:
                    title = "其它";
                    editItem.ItemType = EditEventItem.ItemTypes.OtherItem;
                    break;
            }


            DialogHostForm dialogHostForm = new DialogHostForm(title, 320, editItem.ItemType == EditEventItem.ItemTypes.MedicineItem ? 350 : 170);
            dialogHostForm.Child = editItem;
            if (dialogHostForm.ShowDialog() == DialogResult.OK)
            {
                if (editItem != null && editItem.IsDelete)
                {
                    row.Delete();
                }
                DataContext.GetCurrent().UpdateAnesthesiaEvent(anesEvent);
                RefreshData();
                GetCurrentControl.Refresh();
            }
        }




        //刷新数据时重新绑定数据源 20140210
        public override void RefreshData()
        {
            foreach (MedAnesSheetDetails control in GetAllControls)
            {
                MedAnesSheetDetails medAnesSheetDetails = (MedAnesSheetDetails)control;
                BindDataToUI(control, DataSource);

            }
        }








    }
}
