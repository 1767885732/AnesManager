using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.Framework.Documents;
using Wis.Anes.Framework.Controls;
using System.Drawing;
using Wis.Anes.BusinessEntity;
using System.Data;
using Wis.Anes.Framework.Constants;
using Wis.Anes.Framework;
using Wis.Anes.Framework.Doc;
using System.Windows.Forms;
using Wis.Anes.Custom.Views;
using Wis.Anes.DataAccess;

namespace Wis.Anes.Custom.CustomProject
{
    public class GridGraphHandler : UIElementHandler<MedGridGraph>
    {

        public AnesDoc _anesDoc = null;
        protected MedGridGraph _currentGraph = null;
        protected Dictionary<MedGridPoint, DataRow> _gridRows = new Dictionary<MedGridPoint, DataRow>();
        protected DateTime _currentTime = DateTime.MinValue;
        public Dictionary<int, Dictionary<MedGridGraphRow, double>> dosageList = new Dictionary<int, Dictionary<MedGridGraphRow, double>>();


        /// <summary>
        /// 绑定数据源数据到控件
        /// </summary>
        /// <param name="control"></param>
        /// <param name="dataSources"></param>
        public override void BindDataToUI(MedGridGraph control, Dictionary<string, System.Data.DataTable> dataSources)
        {
            if (!dataSources.ContainsKey("AnesthesiaEvent"))
                throw new NotImplementedException(string.Format("在数据源中未找到名为{0}的表AnesInformations.AnesthesiaEventDataTable,请添加此绑定数据源!", "AnesthesiaEvent"));

            AnesInformations.AnesthesiaEventDataTable anesEvent = dataSources["AnesthesiaEvent"] as AnesInformations.AnesthesiaEventDataTable;

            control.Rows.Clear();
            _gridRows.Clear();
            control.StartTime = PagerSetting.PageTimeSpan.StartDateTime;
            control.EndTime = PagerSetting.PageTimeSpan.EndDateTime;
            control.MinStartDateTime = PagerSetting.PageTimeSpan.OrigiStartDateTime;
            control.MaxEndDateTime = PagerSetting.PageTimeSpan.OrigiEndDateTime;

            Dictionary<string, GridRowAliasName> aNames = new Dictionary<string, GridRowAliasName>();
            MedGridGraphRow row;
            if (control.RowSettings != null)
            {
                foreach (GridRowAliasName aname in control.RowSettings)
                {
                    if (aname.AlwaysNeeded && !aNames.ContainsKey(aname.Alias))
                    {
                        aNames.Add(aname.Alias, aname);

                        row = new MedGridGraphRow(aname.Alias, Color.Black);
                        row.IsAverage = true;
                        row.DotNumber = aname.DotNumber;
                        control.Rows.Add(row);

                    }
                }
            }

            for (int i = 0; i < anesEvent.Count; i++)
            {
                DataRow dataRow = anesEvent[i];
                if (dataRow["ITEM_NAME"] == System.DBNull.Value) continue;
                string rowName = dataRow["ITEM_NAME"].ToString();
                if (!rowName.Contains("麻醉平面") && dataRow["DOSAGE"] == System.DBNull.Value)
                    continue;
                bool find = false;
                if (control.RowSettings != null)
                {
                    foreach (GridRowAliasName aname in control.RowSettings)
                    {
                        if (aname.Name.ToLower().Trim().Equals(rowName.ToLower().Trim()))
                        {
                            find = true;
                            rowName = aname.Alias;
                            break;
                        }
                    }
                }
                if (find)
                {
                    row = control.GetRow(rowName);
                    InLiquidType intype;

                    if (rowName.Contains("麻醉平面"))
                    {
                        if (dataRow["ITEM_CLASS"].ToString() == GetAnesClassTypeString(AnesClassType.InLiquid))
                        {
                            intype = InLiquidType.InLiquid;
                        }
                        else if (dataRow["ITEM_CLASS"].ToString() == GetAnesClassTypeString(AnesClassType.InBlood))
                        {
                            intype = InLiquidType.InBlood;
                        }
                        else
                        {
                            intype = InLiquidType.Other;
                        }
                        if (dataRow["DOSAGE_UNITS"] != System.DBNull.Value)
                        {
                            row.AddPoint((DateTime)dataRow["START_DATE_TIME"], i + 1, dataRow["ITEM_NAME"].ToString(), dataRow["DOSAGE_UNITS"].ToString(),intype);
                        }
                    }
                    else
                    {
                        if (dataRow["ITEM_CLASS"].ToString() == GetAnesClassTypeString(AnesClassType.InLiquid))
                        {
                            intype = InLiquidType.InLiquid;
                        }
                        else if (dataRow["ITEM_CLASS"].ToString() == GetAnesClassTypeString(AnesClassType.InBlood))
                        {
                            intype = InLiquidType.InBlood;
                        }
                        else
                        {
                            intype = InLiquidType.Other;
                        }
                        double value = (double)(decimal)dataRow["DOSAGE"];
                        row.AddPoint((DateTime)dataRow["START_DATE_TIME"], i + 1, dataRow["ITEM_NAME"].ToString(), value,intype);
                    }
                }
            }
            if (control.HasDrug)
            {
                AddGraphRow(control, anesEvent, new AnesClassType[] { AnesClassType.Drug }, "用药", Color.Black);
            }
            if (control.HasLiquid)
            {
                AddGraphRow(control, anesEvent, new AnesClassType[] { AnesClassType.InLiquid }, "", Color.Black);
            }
            //if (control.HasOutLiquid)
            //{
            //    AddGraphRow(control, anesEvent, new AnesClassType[] { AnesClassType.OutLiquid }, "", Color.Black);
            //}
            while (control.Rows.Count < control.MinRowCount)
            {
                control.Rows.Add(new MedGridGraphRow("", Color.Black));
            }
            while (control.Rows.Count > control.MinRowCount)
            {
                control.Rows.RemoveAt(control.Rows.Count - 1);
            }
            //AddGraphRow(control, anesEvent, new AnesClassType[] { AnesClassType.InBlood }, "输血液制品", Color.Black);
            AddGraphRow(control, anesEvent, new AnesClassType[] { AnesClassType.InBlood }, "", Color.Black);
            while (control.Rows.Count <= control.MaxRowCount - 3)
            {
                control.Rows.Add(new MedGridGraphRow("", Color.Black));
            }
            while (control.Rows.Count > control.MaxRowCount - 3)
            {
                control.Rows.RemoveAt(control.MaxRowCount - 3);
            }
            AddGraphRow(control, anesEvent, new AnesClassType[] { AnesClassType.OutLiquid }, "", Color.Black);
            while (control.Rows.Count < control.MaxRowCount)
            {
                control.Rows.Add(new MedGridGraphRow("", Color.Black));
            }
            while (control.Rows.Count > control.MaxRowCount)
            {
                control.Rows.RemoveAt(control.Rows.Count - 1);
            }

            List<MedGridGraphRow> rows = new List<MedGridGraphRow>();
            foreach (MedGridGraphRow row1 in control.Rows)
            {
                if (!aNames.ContainsKey(row1.Text))
                {
                    rows.Add(row1);
                }
            }
            foreach (MedGridGraphRow row1 in control.Rows)
            {
                if (aNames.ContainsKey(row1.Text))
                {
                    rows.Add(row1);
                }
            }
            for (int i = 0; i < rows.Count; i++)
            {
                MedGridGraphRow row1 = rows[i];
                if (i < 6)
                {
                    row1.XOffSet = 16;
                }
            }
            control.Rows = rows;
        }

        /// <summary>
        /// 绑定控件内容到数据源
        /// </summary>
        /// <param name="control"></param>
        /// <param name="dataSources"></param>
        public override void BindUIToData(MedGridGraph control, Dictionary<string, System.Data.DataTable> dataSources)
        {

        }
        /// <summary>
        /// 控件的属性事件设置
        /// </summary>
        /// <param name="control"></param>
        public override void ControlSetting(MedGridGraph control)
        {
            control.OriginWidth = control.Width;
            control.OriginHeight = control.Height;
            control.CustomDraw -= new System.Windows.Forms.PaintEventHandler(control_CustomDraw);
            control.CustomDraw += new System.Windows.Forms.PaintEventHandler(control_CustomDraw);



                        _currentGraph = control;
            control.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(control_MouseDoubleClick);


            control.MouseClick += new MouseEventHandler(control_MouseClick);
        }

        private void control_CustomDraw(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            MedGridGraph gridgraph = sender as MedGridGraph;
            Graphics g = e.Graphics;
            Font font = new Font("宋体", 9);
            Brush brush = Brushes.Black;
            //g.FillRectangle(Brushes.White, new Rectangle(gridgraph.OriginRect.X + (int)gridgraph.TitleWidth, 1, 16, gridgraph.OriginRect.Height * 6 / 9 - 2));
            //g.DrawString("输", font, brush, gridgraph.OriginRect.X + (int)gridgraph.TitleWidth + 1, 30);
            //g.DrawString("液", font, brush, gridgraph.OriginRect.X + (int)gridgraph.TitleWidth + 1, 45);
            string str = "输\r\n液";
            float strheight = (gridgraph.OriginRect.Height * gridgraph.MinRowCount / gridgraph.MaxRowCount - g.MeasureString("输液", font).Height * 2) / 2;
            g.DrawString(str, font, brush, gridgraph.OriginRect.X + 1, strheight);
            g.DrawLine(new Pen(gridgraph.BorderColor), gridgraph.OriginRect.X, gridgraph.OriginRect.Height * gridgraph.MinRowCount / gridgraph.MaxRowCount, gridgraph.OriginRect.X + (int)gridgraph.TitleWidth, gridgraph.OriginRect.Height * gridgraph.MinRowCount / gridgraph.MaxRowCount);
            str = "输\r\n血";
            strheight = gridgraph.OriginRect.Height * gridgraph.MinRowCount / gridgraph.MaxRowCount + (gridgraph.OriginRect.Height * (gridgraph.MaxRowCount - gridgraph.MinRowCount - 3) / gridgraph.MaxRowCount - g.MeasureString("输液", font).Height * 2) / 2;
            g.DrawString(str, font, brush, gridgraph.OriginRect.X + 1, strheight);
            //g.DrawString("输", font, brush, gridgraph.OriginRect.X + 1, 30);
            //g.DrawString("液", font, brush, gridgraph.OriginRect.X + 1, 45);

            //g.DrawLine(new Pen(gridgraph.RowGridColor), gridgraph.OriginRect.X + 1 + (int)gridgraph.TitleWidth + 16, 1, gridgraph.OriginRect.X + 1 + (int)gridgraph.TitleWidth + 16, gridgraph.OriginRect.Height * 6 / 9 - 2);
            //g.DrawLine(new Pen(gridgraph.BorderColor), gridgraph.OriginRect.X + 1, gridgraph.OriginRect.Height * 6 / 9 - 1, gridgraph.OriginRect.X + (int)gridgraph.TitleWidth - 1, gridgraph.OriginRect.Height * 6 / 9 - 1);
            g.DrawLine(new Pen(gridgraph.BorderColor), gridgraph.OriginRect.X, gridgraph.OriginRect.Height * (gridgraph.MaxRowCount - 3) / gridgraph.MaxRowCount, gridgraph.OriginRect.X + (int)gridgraph.TitleWidth, gridgraph.OriginRect.Height * (gridgraph.MaxRowCount - 3) / gridgraph.MaxRowCount);
            g.FillRectangle(Brushes.White, new Rectangle(gridgraph.OriginRect.X + 1, gridgraph.OriginRect.Y + 1, gridgraph.OriginRect.X + (int)gridgraph.TitleWidth - 2, 2));
            font.Dispose();
        }


        /// <summary>
        /// 根据标题从MedGridGraph中寻找MedGridGraphRow
        /// </summary>
        /// <param name="gridGraph"></param>
        /// <param name="rowTitle"></param>
        /// <returns></returns>
        private MedGridGraphRow FindGridRow(MedGridGraph gridGraph, string rowTitle)
        {
            foreach (MedGridGraphRow row in gridGraph.Rows)
            {
                if (row.Text.Equals(rowTitle))
                {
                    return row;
                }
            }
            return null;
        }

        /// <summary>
        /// 添加新行到MedGridGraph
        /// </summary>
        /// <param name="gridGraph"></param>
        /// <param name="anesEventTable"></param>
        /// <param name="anesClasses"></param>
        /// <param name="rowTitle"></param>
        /// <param name="rowColor"></param>
        /// <param name="liquidSettings"></param>
        private void AddGraphRow(MedGridGraph gridGraph, AnesInformations.AnesthesiaEventDataTable anesEventTable, AnesClassType[] anesClasses, string rowTitle, Color rowColor)
        {
            InLiquidType intype;
            string selectString = "(ITEM_CLASS = '" + GetAnesClassTypeString(anesClasses[0]) + "')";
            for (int i = 1; i < anesClasses.Length; i++)
            {
                selectString += " OR (ITEM_CLASS = '" + GetAnesClassTypeString(anesClasses[i]) + "')";
            }

            anesEventTable.DefaultView.Sort = "START_DATE_TIME";
            anesEventTable.DefaultView.RowFilter = selectString;
            //DataRow[] dataRows = anesEventTable.DefaultView.ToTable().Select();// anesEventTable.Select(selectString);
            if (anesEventTable.DefaultView.Count > 0)
            {
                if (!ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_ANES_EVENT_OPEN"))
                    throw new NotImplementedException(string.Format("当前上下文缓存中不存在名为{0}的字典表", "WIS_ANES_EVENT_OPEN"));

                Dict.AnesthesiaEventOpenDataTable eventOpenTable = ExtendApplicationContext.Current.CodeTables["WIS_ANES_EVENT_OPEN"] as Dict.AnesthesiaEventOpenDataTable;

                MedGridGraphRow row = null;
                Dictionary<string, string> dict = new Dictionary<string, string>();

                if (!string.IsNullOrEmpty(rowTitle))
                {
                    row = new MedGridGraphRow(rowTitle, rowColor);
                    row.IsDetail = gridGraph.IsLiquidDetail;
                    gridGraph.Rows.Add(row);
                }

                DateTime sysDateTime = GetSysDateTime();

                for (int i = 0; i < anesEventTable.DefaultView.Count; i++)
                {
                    DataRow dataRow = anesEventTable.DefaultView[i].Row;
                    if (dataRow["START_DATE_TIME"] != System.DBNull.Value && dataRow["ITEM_NAME"] != System.DBNull.Value && !IsTimeEvent(dataRow["ITEM_NAME"].ToString()))
                    {
                        string itemName = dataRow["ITEM_NAME"].ToString();
                        double value = 0;
                        if (dataRow["DOSAGE"] != System.DBNull.Value) value = GetDoubleValue(dataRow["DOSAGE"]);
                        if (dataRow["ITEM_CLASS"].ToString() == GetAnesClassTypeString(AnesClassType.InLiquid))
                        {
                            intype = InLiquidType.InLiquid;
                        }
                        else if (dataRow["ITEM_CLASS"].ToString() == GetAnesClassTypeString(AnesClassType.InBlood))
                        {
                            intype = InLiquidType.InBlood;
                        }
                        else
                        {
                            intype = InLiquidType.Other;
                        }
                        if (dict.Count > 0)
                        {
                            if (dataRow["EVENT_ATTR"] == System.DBNull.Value || !dict.ContainsKey(dataRow["EVENT_ATTR"].ToString())) continue;
                            row = FindGridRow(gridGraph, dict[dataRow["EVENT_ATTR"].ToString()]);
                            MedGridPoint point = row.AddPoint((DateTime)dataRow["START_DATE_TIME"], i + 1, itemName, value, intype);
                            _gridRows.Add(point, dataRow);
                            continue;
                        }
                        else if (string.IsNullOrEmpty(rowTitle))
                        {
                            string alias = itemName;
                            if (string.IsNullOrEmpty(alias)) continue;
                            row = FindGridRow(gridGraph, alias);
                            if (row == null)
                            {
                                row = new MedGridGraphRow(alias, rowColor);
                                //判断是否是持续
                                if (dataRow["END_DATE_TIME"] != System.DBNull.Value || (dataRow["durative_indicator"] != System.DBNull.Value) && (dataRow["durative_indicator"].ToString() == "1"))
                                {
                                    row.IsLine = true;
                                }
                                else
                                {
                                    row.IsLine = false;
                                }
                                gridGraph.Rows.Add(row);
                            }
                        }
                        bool find = false;
                        if ((anesClasses[0] == AnesClassType.InBlood || anesClasses[0] == AnesClassType.InLiquid) && eventOpenTable != null && eventOpenTable.Count > 0)
                        {
                            DataRow[] rows = eventOpenTable.Select("ITEM_NAME = '" + itemName + "'");
                            if (rows != null && rows.Length > 0)
                            {
                                if (rows[0]["EVENT_ATTR_2"] != System.DBNull.Value)
                                {
                                    MedGridPoint point = null;
                                    if (row.IsLine)
                                    {
                                        DateTime dt = DateTime.MinValue;
                                        bool isArrow = false;
                                        if (dataRow["END_DATE_TIME"] != System.DBNull.Value)
                                        {
                                            dt = (DateTime)dataRow["END_DATE_TIME"];
                                            isArrow = false;
                                        }
                                        else
                                        {
                                            dt = (sysDateTime < gridGraph.MaxEndDateTime) ? sysDateTime : gridGraph.MaxEndDateTime;
                                            isArrow = true;
                                        }
                                        point = row.AddPoint((DateTime)dataRow["START_DATE_TIME"], dt, i + 1, itemName, value, rows[0]["EVENT_ATTR_2"].ToString(),intype);

                                        row.Points[row.Points.Count - 1].IsArrow = isArrow;
                                        row.Points[row.Points.Count - 1].Unit = dataRow.IsNull("DOSAGE_UNITS") ? "" : dataRow["DOSAGE_UNITS"].ToString();
                                    }
                                    else
                                    {
                                        point = row.AddPoint((DateTime)dataRow["START_DATE_TIME"], i + 1, itemName, value, rows[0]["EVENT_ATTR_2"].ToString(), intype);
                                        row.Points[row.Points.Count - 1].Unit = dataRow.IsNull("DOSAGE_UNITS") ? "" : dataRow["DOSAGE_UNITS"].ToString();
                                    }
                                    _gridRows.Add(point, dataRow);
                                    find = true;
                                }
                            }
                        }
                        if (!find)
                        {
                            MedGridPoint point = null;
                            if (row.IsLine)
                            {
                                DateTime dt = DateTime.MinValue;
                                bool isArrow = false;
                                if (dataRow["END_DATE_TIME"] != System.DBNull.Value)
                                {
                                    dt = (DateTime)dataRow["END_DATE_TIME"];
                                    isArrow = false;
                                }
                                else
                                {
                                    dt = (sysDateTime < gridGraph.MaxEndDateTime) ? sysDateTime : gridGraph.MaxEndDateTime;
                                    isArrow = true;
                                }


                                point = row.AddPoint((DateTime)dataRow["START_DATE_TIME"], dt, i + 1, itemName, value, "", intype);
                                row.Points[row.Points.Count - 1].IsArrow = isArrow;
                                row.Points[row.Points.Count - 1].Unit = dataRow.IsNull("DOSAGE_UNITS") ? "" : dataRow["DOSAGE_UNITS"].ToString();
                            }
                            else
                            {
                                point = row.AddPoint((DateTime)dataRow["START_DATE_TIME"], i + 1, itemName, value, intype);
                                row.Points[row.Points.Count - 1].Unit = dataRow.IsNull("DOSAGE_UNITS") ? "" : dataRow["DOSAGE_UNITS"].ToString();
                            }
                            _gridRows.Add(point, dataRow);
                        }
                    }
                }
            }
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
                    _currentGraph.SetMousePosition(e.Location);
                    if (_currentGraph.MouseTime > DateTime.MinValue)
                    {
                        MedGridPoint pt = _currentGraph.SelectedPoint;
                        _currentTime = _currentGraph.MouseTime;
                        //Modify by wenpei.x@2014-03-04
                        //优化右击用药快速输入药品
                        //if (pt == null)
                        //{


                        //        _currentTime = _currentGraph.MouseTime;

                        //        if (!ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_ANES_EVENT_OPEN"))
                        //            throw new NotImplementedException(string.Format("当前上下文缓存中不存在名为{0}的字典表", "WIS_ANES_EVENT_OPEN"));

                        //        Dict.AnesthesiaEventOpenDataTable eventOpenTable = ExtendApplicationContext.Current.CodeTables["WIS_ANES_EVENT_OPEN"] as Dict.AnesthesiaEventOpenDataTable;
                        //        eventOpenTable.DefaultView.RowFilter = "ITEM_CLASS = '3' or ITEM_CLASS = 'B'";
                        //        DataTable sourceTable = eventOpenTable.DefaultView.ToTable();

                        //        PopupDrugSelector.ShowSelector(sourceTable, _currentGraph, e.Location, _currentTime, this, "输血及输液", 0);
                        //    
                        //}
                        decimal eventNo =ExtendApplicationContext.Current.EventNo;
                        if (pt == null)
                        {

                            if (!ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_ANES_EVENT_OPEN"))
                                throw new NotImplementedException(string.Format("当前上下文缓存中不存在名为{0}的字典表", "WIS_ANES_EVENT_OPEN"));
                            AnesInformations.AnesthesiaEventDataTable anesEvent = this.DataSource["AnesthesiaEvent"] as AnesInformations.AnesthesiaEventDataTable;
                            Dict.AnesthesiaEventOpenDataTable eventOpenTable = ExtendApplicationContext.Current.CodeTables["WIS_ANES_EVENT_OPEN"] as Dict.AnesthesiaEventOpenDataTable;
                            int Line = (int)Math.Ceiling((double)e.Location.Y / _currentGraph.Height * _currentGraph.Rows.Count);
                            if (_currentGraph.Rows[Line - 1].Points.Count == 0 || Line == 7 || Line == 8 || Line == 9)
                            {
                                if (Line == 6)
                                {
                                    eventOpenTable.DefaultView.RowFilter = "ITEM_CLASS = 'B'";
                                }
                                else if (Line == 7 || Line == 8 || Line == 9)
                                {
                                    eventOpenTable.DefaultView.RowFilter = "ITEM_CLASS = 'D'";
                                }
                                else
                                {
                                    eventOpenTable.DefaultView.RowFilter = "ITEM_CLASS = '3'";
                                }
                                DataTable sourceTable = eventOpenTable.DefaultView.ToTable();

                                PopupDrugSelector.ShowSelector(sourceTable, _currentGraph, e.Location, _currentTime != DateTime.MinValue ? _currentTime : DateTime.Now, this, "输血及输液", eventNo);
                            }
                            else
                            {
                                if (_currentGraph.GetMainRect().X > e.Location.X) return;
                                eventOpenTable.DefaultView.RowFilter = string.Format("ITEM_NAME='{0}' and (ITEM_CLASS = 'B' or ITEM_CLASS = 'D' or ITEM_CLASS = '3')", _currentGraph.Rows[Line - 1].Text);
                                if (eventOpenTable.DefaultView.ToTable().Rows.Count == 0) return;
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
                                DataRow firstrow = _gridRows[_currentGraph.Rows[Line - 1].Points[0]];
                                if (!firstrow.IsNull("ADMINISTRATOR"))
                                    eventRow.ADMINISTRATOR = firstrow["ADMINISTRATOR"].ToString();

                                if (!string.IsNullOrEmpty(_currentGraph.Rows[Line - 1].Points[0].ThickNessUnit))
                                    eventRow.CONCENTRATION_UNITS = _currentGraph.Rows[Line - 1].Points[0].ThickNessUnit;

                                if (!string.IsNullOrEmpty(_currentGraph.Rows[Line - 1].Points[0].Unit))
                                    eventRow.DOSAGE_UNITS = _currentGraph.Rows[Line - 1].Points[0].Unit;

                                if (!string.IsNullOrEmpty(_currentGraph.Rows[Line - 1].Points[0].SpeedUnit))
                                    eventRow.SPEED_UNITS = _currentGraph.Rows[Line - 1].Points[0].SpeedUnit;

                                if (!row.IsNull("SUPPLIER_NAME"))
                                    eventRow.SUPPLIER_NAME = row["SUPPLIER_NAME"].ToString();

                                if (!string.IsNullOrEmpty(_currentGraph.Rows[Line - 1].Points[0].ThickNess.ToString()))
                                    eventRow.CONCENTRATION = (decimal)_currentGraph.Rows[Line - 1].Points[0].ThickNess;

                                if (!string.IsNullOrEmpty(_currentGraph.Rows[Line - 1].Points[0].Value.ToString()))
                                    eventRow.DOSAGE = Convert.ToDecimal(_currentGraph.Rows[Line - 1].Points[0].Value);

                                if (!string.IsNullOrEmpty(_currentGraph.Rows[Line - 1].Points[0].Speed.ToString()))
                                    eventRow.PERFORM_SPEED = (decimal)_currentGraph.Rows[Line - 1].Points[0].Speed;

                                if (!row.IsNull("DURATIVE_INDICATOR"))
                                    eventRow.DURATIVE_INDICATOR = Convert.ToDecimal(row["DURATIVE_INDICATOR"]);
                                EditEventItem editItem = new EditEventItem();
                                editItem.DataSource = eventRow;
                                editItem.ItemType = EditEventItem.ItemTypes.MedicineItem;
                                DialogHostForm dialogHostForm = new DialogHostForm(editItem.Caption, 320, 300);
                                dialogHostForm.Child = editItem;
                                dialogHostForm.Text = "新增输血及输液数据";
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
                            DataRow row = _gridRows[pt];

                            AnesInformations.AnesthesiaEventDataTable anesEvent = base.DataSource["AnesthesiaEvent"] as AnesInformations.AnesthesiaEventDataTable;
                            //anesEvent.DefaultView.RowFilter = string.Format("ITEM_CLASS = '{0}' and ITEM_NO = '{1}'", row["ITEM_CLASS"], row["ITEM_NO"]);

                            EditEventItem editItem = new EditEventItem();
                            editItem.DataSource = row;
                            editItem.ItemType = EditEventItem.ItemTypes.MedicineItem;
                            editItem.IsAllowDel = true;
                            editItem.TitleColor = Color.DarkOrange;
                            DialogHostForm dialogHostForm = new DialogHostForm("修改输血及输液数据", 320, 300);
                            dialogHostForm.Child = editItem;
                            if (dialogHostForm.ShowDialog() == DialogResult.OK)
                            {
                                if (editItem != null && editItem.IsDelete)
                                {
                                    // 去掉allevent的数据，防止没有刷新数据时再次添加时报错
                                    AnesInformations.AnesthesiaEventDataTable allEvent = base.DataSource["AnesAllEvent"] as AnesInformations.AnesthesiaEventDataTable;
                                    DataRow[] rows = allEvent.Select(string.Format("ITEM_CLASS = '{0}' and ITEM_NO = {1}", row["ITEM_CLASS"], row["ITEM_NO"]));
                                    if (rows.Length > 0)
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
                ExceptionHandler.Handle(err);
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
