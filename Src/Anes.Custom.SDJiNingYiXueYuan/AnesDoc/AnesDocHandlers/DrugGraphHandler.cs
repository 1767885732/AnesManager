using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.Framework.Documents;
using Wis.Anes.Framework.Controls;
using Wis.Anes.BusinessEntity;
using System.Data;
using System.Drawing;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.Framework;
using System.Windows.Forms;
using Wis.Anes.Custom.Views;
using Wis.Anes.DataAccess;

namespace Wis.Anes.Custom.CustomProject
{
    public class DrugGraphHandler : UIElementHandler<MedDrugGraph>
    {


        protected MedDrugGraph _currentGraph = null;
        protected DateTime _currentTime = DateTime.MinValue;
        protected BaseDoc _attatchDoc;
        protected Dictionary<MedDrugPoint, DataRow> _drugRows = new Dictionary<MedDrugPoint, DataRow>();
        public Dictionary<int, Dictionary<MedDrugCurve, double>> dosageList = new Dictionary<int, Dictionary<MedDrugCurve, double>>();

        /// <summary>
        /// 绑定数据源数据到控件
        /// </summary>
        /// <param name="control"></param>
        /// <param name="dataSources"></param>
        public override void BindDataToUI(MedDrugGraph control, Dictionary<string, System.Data.DataTable> dataSources)
        {

            if (!dataSources.ContainsKey("AnesthesiaEvent"))
                throw new NotImplementedException(string.Format("在数据源中未找到名为{0}的表AnesInformations.AnesthesiaEventDataTable,请添加此绑定数据源!", "AnesthesiaEvent"));

            AnesInformations.AnesthesiaEventDataTable anesEvent = dataSources["AnesthesiaEvent"] as AnesInformations.AnesthesiaEventDataTable;
            
            
            
            bool isEndAnes = false;
            DateTime dtEndAnes = DateTime.Now;
            #region "持续用药随手术状态自动结束"

            //针对麻醉
            if (ApplicationConfiguration.DrugAutoStop && ExtendApplicationContext.Current.EventNo == 0 )
            {
                string operText = ApplicationConfiguration.DrugAutoStopOperationStatus;
                OperationStatus operStatus = OperationStatusHelper.OperationStatusFromString(operText);
                if (operStatus != OperationStatus.None)
                {
                    string timeField = OperationStatusHelper.GetTimeFieldName(operStatus);
                    DataTable dtMaster = DataContext.GetCurrent().GetData("WIS_OPER_MASTER");
                 
       
                    if (dtMaster != null && dtMaster.Rows.Count > 0 && !dtMaster.Rows[0].IsNull(timeField))
                    {
                        int status = 0;
                        if (!dtMaster.Rows[0].IsNull("OPER_STATUS"))
                        {
                            status = Convert.ToInt32(dtMaster.Rows[0]["OPER_STATUS"]);
                        }
                        //时如果没有持续用药没有自动结束的话，会按照配置的时间自动结束
                        //出手术室 35
                        if (status >= (int)operStatus)
                        {
                            dtEndAnes = (DateTime)dtMaster.Rows[0][timeField];
                            isEndAnes = true;

                            bool changed = false;
                            foreach (AnesInformations.AnesthesiaEventRow row in anesEvent.Rows)
                            {
                                if (row.IsDURATIVE_INDICATORNull())
                                    continue;

                                if (row.DURATIVE_INDICATOR.ToString() == "1" && row.IsEND_DATE_TIMENull())
                                {
                                    row.END_DATE_TIME = dtEndAnes;
                                    changed = true;
                                }
                            }

                            if (changed)
                            {
                                DataContext.GetCurrent().UpdateAnesthesiaEvent(anesEvent);
                            }
                        }
                    }
                }
            }//---->if (ApplicationConfiguration.DrugAutoStop)
            #endregion
            control.Curves.Clear();
            control.ProLongedDrugShowType = (ProLongedDrugUnitShowType)ApplicationConfiguration.ProLonged;
            control.DrugShowType = (NormalDrugUnitShowType)ApplicationConfiguration.DrugShow;
           
            control.StartTime = PagerSetting.PageTimeSpan.StartDateTime;
            control.EndTime = PagerSetting.PageTimeSpan.EndDateTime;
            control.MinStartDateTime = PagerSetting.PageTimeSpan.OrigiStartDateTime;
            control.MaxEndDateTime = PagerSetting.PageTimeSpan.OrigiEndDateTime;

            string itemClass = "," + GetAnesClassTypeString(AnesClassType.InOxygen) + ",";
            List<string> titles = new List<string>();
            foreach (AnesInformations.AnesthesiaEventRow row in anesEvent)
            {
                if (!row.IsITEM_CLASSNull() && !row.IsITEM_NAMENull() && itemClass.Contains("," + row.ITEM_CLASS + ",") && !titles.Contains(row.ITEM_NAME))
                {
                    titles.Add(row.ITEM_NAME);
                }
            }

            itemClass +=  GetAnesClassTypeString(AnesClassType.AnesDrug) + "," + GetAnesClassTypeString(AnesClassType.MixLiquid) + ",";
            foreach (AnesInformations.AnesthesiaEventRow row in anesEvent)
            {
                if (!row.IsITEM_CLASSNull() && !row.IsITEM_NAMENull() && itemClass.Contains("," + row.ITEM_CLASS + ",") && !titles.Contains(row.ITEM_NAME))
                {
                    titles.Add(row.ITEM_NAME);
                }

            }
            while (titles.Count > 7)
            {
                titles.Remove(titles[titles.Count - 1]);
            }
            while (titles.Count < 7)
            {
                titles.Add("");
            }
            itemClass += "C,";//用药
            foreach (AnesInformations.AnesthesiaEventRow row in anesEvent)
            {
                if (!row.IsITEM_CLASSNull() && !row.IsITEM_NAMENull() && row.ITEM_CLASS =="C" && !titles.Contains(row.ITEM_NAME)&&!row.IsADMINISTRATORNull()&&row.ADMINISTRATOR=="泵注")
                {
                    titles.Add(row.ITEM_NAME);
                }
            }
            foreach (AnesInformations.AnesthesiaEventRow row in anesEvent)
            {
                if (!row.IsITEM_CLASSNull() && !row.IsITEM_NAMENull() && row.ITEM_CLASS == "C" && !titles.Contains(row.ITEM_NAME))
                {
                    titles.Add(row.ITEM_NAME);
                }
            }
            int index = 0; //最多只能显示 drugGraph.LineParameters.Count 行，多的显示在明细中
            if (titles.Count > 0)
            {
                DateTime sysDatetTime = GetSysDateTime();
                foreach (string title in titles)
                {
                    index++;

                    //目前为 行
                    if (index > control.LineParameters.Count)//多的显示到备注中 2021926
                        break;

                    MedDrugCurve curve = new MedDrugCurve(title, GetRandomColor());
                    DataRow[] rows = anesEvent.Select("ITEM_NAME = '" + title + "'");
                    if (rows.Length > 0)
                    {
                        foreach (DataRow row in rows)
                        {
                            if (row["START_DATE_TIME"] != System.DBNull.Value && row["ITEM_CLASS"] != System.DBNull.Value && itemClass.Contains("," + row["ITEM_CLASS"].ToString() + ","))
                            {
                                PointType pointType = (GetDecimalValue(row["DURATIVE_INDICATOR"]) == 1 ? PointType.ProLonged : PointType.SinglePoint);
                                DateTime dt;
                                bool isArrow = false;

                                if (row["END_DATE_TIME"] != System.DBNull.Value)
                                {
                                    dt = (DateTime)row["END_DATE_TIME"];
                                }
                                else if (pointType == PointType.ProLonged)
                                {
                                  //  dt = (sysDatetTime < PagerSetting.PageTimeSpan.OrigiEndDateTime) ? sysDatetTime : PagerSetting.PageTimeSpan.OrigiEndDateTime;
                                  ////  dt = (DataHelper.GetSysDateTime() < dateTimeRangePage.EndDateTime) ? DataHelper.GetSysDateTime() : dateTimeRangePage.EndDateTime;

                                  //  isArrow = true;



                                    DateTime dtUse = isEndAnes ? dtEndAnes : sysDatetTime;

                                    dt = (dtUse < PagerSetting.PageTimeSpan.OrigiEndDateTime) ? dtUse : PagerSetting.PageTimeSpan.OrigiEndDateTime;
                                    //dt = (sysDatetTime < PagerSetting.PageTimeSpan.OrigiEndDateTime) ? sysDatetTime : PagerSetting.PageTimeSpan.OrigiEndDateTime;
                                    //  dt = (DataHelper.GetSysDateTime() < dateTimeRangePage.EndDateTime) ? DataHelper.GetSysDateTime() : dateTimeRangePage.EndDateTime;

                                    isArrow = !isEndAnes;
                                }
                                else
                                {
                                    dt = (DateTime)row["START_DATE_TIME"];
                                }
                                MedDrugPoint point = curve.AddPoint((DateTime)row["START_DATE_TIME"], GetDoubleValue(row["DOSAGE"]), GetStringValue(row["DOSAGE_UNITS"])
                                    , GetDoubleValue(row["CONCENTRATION"]), GetStringValue(row["CONCENTRATION_UNITS"]), GetStringValue(row["ADMINISTRATOR"])
                                    , dt, GetDoubleValue(row["PERFORM_SPEED"]), GetStringValue(row["SPEED_UNITS"]), pointType);
                                point.IsArrow = isArrow;
                                _drugRows.Add(point, row);

                            }
                        }
                    }
                    control.Curves.Add(curve);
                }
            }
        }

        private void AddDrugCurves(MedDrugGraph control, AnesInformations.AnesthesiaEventDataTable anesEvent, string classTypeString)
        {

        }

        /// <summary>
        /// 绑定控件内容到数据源
        /// </summary>
        /// <param name="control"></param>
        /// <param name="dataSources"></param>
        public override void BindUIToData(MedDrugGraph control, Dictionary<string, System.Data.DataTable> dataSources)
        {
            
        }
        /// <summary>
        ///  控件设置
        /// </summary>
        /// <param name="control"></param>
        public override void ControlSetting(MedDrugGraph control)
        {
            _currentGraph = control;
            control.OriginWidth = control.Width;
            control.OriginHeight = control.Height;
            control.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(control_MouseDoubleClick);
            control.MouseClick += new MouseEventHandler(control_MouseClick);
        }

        protected void control_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                RectangleF rectf = _currentGraph.GetMainRect();
                if (!rectf.Contains(e.Location.X, e.Location.Y))
                    return;

                if (e.Button == MouseButtons.Right)
                {
                    //Modify by wenpei.x@2014-03-04
                    //优化右击用药快速输入药品
                    #region 旧处理
                    //_currentGraph.SetMousePosition(e.Location);
                    //if (_currentGraph.MouseTime > DateTime.MinValue)
                    //{
                    //    MedDrugPoint pt = _currentGraph.SelectedPoint;
                    //    if (pt == null)
                    //    {
                    //        _currentTime = _currentGraph.MouseTime;

                    //        if (!ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_ANES_EVENT_OPEN"))
                    //            throw new NotImplementedException(string.Format("当前上下文缓存中不存在名为{0}的字典表", "WIS_ANES_EVENT_OPEN"));

                    //        Dict.AnesthesiaEventOpenDataTable eventOpenTable = ExtendApplicationContext.Current.CodeTables["WIS_ANES_EVENT_OPEN"] as Dict.AnesthesiaEventOpenDataTable;

                    //        int Line = (int)Math.Ceiling((double)e.Location.Y / _currentGraph.Height * _currentGraph.LineParameters.Count);
                    //        if (Line == 1)
                    //        {
                    //            eventOpenTable.DefaultView.RowFilter = "ITEM_CLASS = '4'";
                    //        }
                    //        else if (Line == 2)
                    //        {
                    //            eventOpenTable.DefaultView.RowFilter = "ITEM_NAME = '七氟烷'";
                    //        }
                    //        else
                    //        {
                    //            eventOpenTable.DefaultView.RowFilter = "ITEM_CLASS = '2' or ITEM_CLASS = 'C'";
                    //        }

                    //        DataTable sourceTable = eventOpenTable.DefaultView.ToTable();
                    //        PopupDrugSelector.ShowSelector(sourceTable, _currentGraph, e.Location, _currentTime, this, "麻药及用药", 0);

                    //    }

                    #endregion
                    _currentGraph.SetMousePosition(e.Location);
                    decimal eventNo = ExtendApplicationContext.Current.EventNo;
                    if (_currentGraph.MouseTime > DateTime.MinValue)
                    {
                        MedDrugPoint pt = _currentGraph.SelectedPoint;
                        _currentTime = _currentGraph.MouseTime;
                        if (pt == null)
                        {

                            if (!ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_ANES_EVENT_OPEN"))
                                throw new NotImplementedException(string.Format("当前上下文缓存中不存在名为{0}的字典表", "WIS_ANES_EVENT_OPEN"));

                            Dict.AnesthesiaEventOpenDataTable eventOpenTable = ExtendApplicationContext.Current.CodeTables["WIS_ANES_EVENT_OPEN"] as Dict.AnesthesiaEventOpenDataTable;
                            AnesInformations.AnesthesiaEventDataTable anesEvent = this.DataSource["AnesthesiaEvent"] as AnesInformations.AnesthesiaEventDataTable;
                            int Line = (int)Math.Ceiling(((double)e.Location.Y- _currentGraph.TopOffSet) / _currentGraph.Height * _currentGraph.LineParameters.Count);
                            //if (Line == 1)
                            //{
                            //    eventOpenTable.DefaultView.RowFilter = "ITEM_CLASS = '4'";
                            //}
                            //else if (Line == 2)
                            //{
                            //    eventOpenTable.DefaultView.RowFilter = "ITEM_NAME = '七氟烷'";
                            //}
                            //else

                            if (_currentGraph.Curves.Count < Line)
                            {
                                eventOpenTable.DefaultView.RowFilter = "ITEM_CLASS = '2' or ITEM_CLASS = 'C'";
                                DataTable sourceTable = eventOpenTable.DefaultView.ToTable();
                                PopupDrugSelector.ShowSelector(sourceTable, _currentGraph, e.Location, _currentTime != DateTime.MinValue ? _currentTime : DateTime.Now, this, "麻药及用药", eventNo);
                            }
                            else
                            {
                                if (_currentGraph.GetMainRect().X > e.Location.X) return;
                                eventOpenTable.DefaultView.RowFilter = string.Format("ITEM_NAME='{0}'", _currentGraph.Curves[Line - 1].Text);
                                DataRow row = eventOpenTable.DefaultView.ToTable().Rows[0];
                                AnesInformations.AnesthesiaEventRow eventRow = DataContext.GetCurrent().NewAnesthesiaEventRow(anesEvent, eventNo);
                                eventRow.ITEM_CLASS = row["ITEM_CLASS"].ToString();
                                eventRow.ITEM_NAME = row["ITEM_NAME"].ToString();
                                eventRow.ITEM_SPEC = row["ITEM_SPEC"].ToString();
                                eventRow.ITEM_CODE = row["ITEM_CODE"].ToString();
                                eventRow.START_DATE_TIME = _currentTime;

                                //add by chenyu 2012-11-07 begin 添加晶体胶体相关属性
                                if (!row.IsNull("EVENT_ATTR"))
                                    eventRow.EVENT_ATTR = row["EVENT_ATTR"].ToString();
                                //add end

                                if (!string.IsNullOrEmpty(_currentGraph.Curves[Line - 1].Points[0].Route))
                                    eventRow.ADMINISTRATOR = _currentGraph.Curves[Line - 1].Points[0].Route;

                                if (!string.IsNullOrEmpty(_currentGraph.Curves[Line - 1].Points[0].ThickNessUnit))
                                    eventRow.CONCENTRATION_UNITS = _currentGraph.Curves[Line - 1].Points[0].ThickNessUnit;

                                if (!string.IsNullOrEmpty(_currentGraph.Curves[Line - 1].Points[0].Unit))
                                    eventRow.DOSAGE_UNITS = _currentGraph.Curves[Line - 1].Points[0].Unit;

                                if (!string.IsNullOrEmpty(_currentGraph.Curves[Line - 1].Points[0].SpeedUnit))
                                    eventRow.SPEED_UNITS = _currentGraph.Curves[Line - 1].Points[0].SpeedUnit;

                                if (!row.IsNull("SUPPLIER_NAME"))
                                    eventRow.SUPPLIER_NAME = row["SUPPLIER_NAME"].ToString();

                                if (!string.IsNullOrEmpty(_currentGraph.Curves[Line - 1].Points[0].ThickNess.ToString()))
                                    eventRow.CONCENTRATION = (decimal)_currentGraph.Curves[Line - 1].Points[0].ThickNess;

                                if (!string.IsNullOrEmpty(_currentGraph.Curves[Line - 1].Points[0].Value.ToString()))
                                    eventRow.DOSAGE = Convert.ToDecimal(_currentGraph.Curves[Line - 1].Points[0].Value);

                                if (!string.IsNullOrEmpty(_currentGraph.Curves[Line - 1].Points[0].Speed.ToString()))
                                    eventRow.PERFORM_SPEED = (decimal)_currentGraph.Curves[Line - 1].Points[0].Speed;

                                if (!row.IsNull("DURATIVE_INDICATOR"))
                                    eventRow.DURATIVE_INDICATOR = Convert.ToDecimal(row["DURATIVE_INDICATOR"]);
                                EditEventItem editItem = new EditEventItem();
                                editItem.DataSource = eventRow;
                                editItem.ItemType = EditEventItem.ItemTypes.MedicineItem;
                                DialogHostForm dialogHostForm = new DialogHostForm(editItem.Caption, 320, 300);
                                dialogHostForm.Child = editItem;
                                dialogHostForm.Text = "新增麻药用药数据";
                                editItem.TitleColor = Color.Blue;
                                DialogResult result = dialogHostForm.ShowDialog();
                                if (result == DialogResult.OK)
                                {
                                    eventRow.ITEM_NO = new AnesthesiaSheetDA().GetMaxItemNO(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID, eventNo) + 1;
                                    anesEvent.Rows.Add(eventRow);
                                    DataContext.GetCurrent().UpdateAnesthesiaEvent(anesEvent);

                                    //_handler.DataSource["AnesthesiaEvent"].ImportRow(eventRow);

                                    RefreshData();
                                    _currentGraph.Refresh();
                                }
                            }

                        }
                        else
                        {
                            DataRow row = _drugRows[pt];

                            AnesInformations.AnesthesiaEventDataTable anesEvent = base.DataSource["AnesthesiaEvent"] as AnesInformations.AnesthesiaEventDataTable;
                            //anesEvent.DefaultView.RowFilter = string.Format("ITEM_CLASS = '{0}' and ITEM_NO = '{1}'", row["ITEM_CLASS"], row["ITEM_NO"]);

                            EditEventItem editItem = new EditEventItem();
                            editItem.DataSource = row;
                            editItem.ItemType = EditEventItem.ItemTypes.MedicineItem;
                            editItem.IsAllowDel = true;
                            DialogHostForm dialogHostForm = new DialogHostForm("修改麻药用药数据", 320, 300);
                            dialogHostForm.Child = editItem;
                            editItem.TitleColor = Color.DarkOrange;
                            if (dialogHostForm.ShowDialog() == DialogResult.OK)
                            {
                                if (editItem != null && editItem.IsDelete)
                                {
                                    // 去掉allevent的数据，防止没有刷新数据时再次添加时报错
                                    AnesInformations.AnesthesiaEventDataTable allEvent = base.DataSource["AnesAllEvent"] as AnesInformations.AnesthesiaEventDataTable;
                                    DataRow[] rows = allEvent.Select(string.Format("ITEM_CLASS = '{0}' and ITEM_NO = {1}", row["ITEM_CLASS"], row["ITEM_NO"]));
                                    if(rows.Length > 0)
                                    {
                                        allEvent.Rows.Remove(rows[0]);
                                    }
                                    row.Delete();
                                }
                                DataContext.GetCurrent().UpdateAnesthesiaEvent(anesEvent);
                                RefreshData();
                                _currentGraph.Refresh();
                            }
                        }
                    }
                }
            }
            catch (Exception err)
            {
            }
        }


        protected void control_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RectangleF rectf = _currentGraph.GetMainRect();
            _currentGraph.SetMouseDoubleClick(e.Location);
            if (!rectf.Contains(e.Location.X, e.Location.Y))
                return;

            if (_currentGraph.MouseTime > DateTime.MinValue)
            {

            }

        }

    }
}
