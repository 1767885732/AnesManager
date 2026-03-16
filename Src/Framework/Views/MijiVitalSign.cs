using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Controls;
using Wis.Anes.BusinessEntity;
using DevExpress.XtraEditors;
using Wis.Anes.Framework.Controls.Base;
using System.Reflection;
using Wis.Anes.DataAccess;
using System.Collections;
using System.Drawing.Printing;
using System.IO;
using System.Drawing.Imaging;
using Wis.Anes.Framework.Utilities;
namespace Wis.Anes.Framework
{
    [ToolboxItem(false)]
    public partial class MijiVitalSign : XtraUserControl
    {
        private MedVitalSignGraph _vitalSignGraph;
        private AnesInformations.VitalSignDataTable _vitalSignDataTable;
        private decimal _eventNo;

        public MijiVitalSign()
        {
            InitializeComponent();
        }

        public MijiVitalSign(MedVitalSignGraph vitalSign,decimal eventNo):this()
        {
            _eventNo = eventNo;
            _vitalSignGraph = new MedVitalSignGraph();
            _vitalSignGraph.EventNo = eventNo;
            _vitalSignGraph.OriginHeight = _vitalSignGraph.Height;
            _vitalSignGraph.OriginWidth = _vitalSignGraph.Width - 20;
            _vitalSignGraph.BorderType = vitalSign.BorderType;
            _vitalSignGraph.BorderColor = vitalSign.BorderColor;
            _vitalSignGraph.PringColor = vitalSign.PringColor;
            _vitalSignGraph.IsPrintSingleCurveColor = vitalSign.IsPrintSingleCurveColor;
            _vitalSignGraph.BloodGasItems = vitalSign.BloodGasItems;
            _vitalSignGraph.GridColor = vitalSign.GridColor;
            _vitalSignGraph.ScaleValueFont = vitalSign.ScaleValueFont;
            _vitalSignGraph.ScaleValueColor = vitalSign.ScaleValueColor;
            _vitalSignGraph.GridLineWidth = vitalSign.GridLineWidth;
            _vitalSignGraph.GridDashStyle = vitalSign.GridDashStyle;
            _vitalSignGraph.MinDashStyle = vitalSign.MinDashStyle;
            _vitalSignGraph.MinScaleWidth = vitalSign.MinScaleWidth;
            _vitalSignGraph.MinScaleColor = vitalSign.MinScaleColor;
            _vitalSignGraph.YAxisBorderType = vitalSign.YAxisBorderType;
            _vitalSignGraph.YAxisBorderColor = vitalSign.YAxisBorderColor;
            _vitalSignGraph.YAxisBorderWidth = vitalSign.YAxisBorderWidth;
            _vitalSignGraph.IsDigitTop = vitalSign.IsDigitTop;
            _vitalSignGraph.CurveSymbolSize = vitalSign.CurveSymbolSize;
            _vitalSignGraph.YAxises = vitalSign.YAxises;
            _vitalSignGraph.CurveDetails = vitalSign.CurveDetails;
            _vitalSignGraph.TimeText = "时间";
            _vitalSignGraph.TimeAxisPositionType = TimeAxisPositionType.Top;
            _vitalSignGraph.HasEventMark = false;
            _vitalSignGraph.EndTime = _vitalSignGraph.StartTime.AddHours(1);
            _vitalSignGraph.ScaleType = ScaleType.Quarter;
            _vitalSignGraph.MinScaleCount = 15;
            _vitalSignGraph.MinYScaleCount = 2;
            _vitalSignGraph.CanUpdate = false;
            _vitalSignGraph.IsLegendFloat = false;
            _vitalSignGraph.DrawCurveLegend = true;
            _vitalSignGraph.OnlyShowFileMinute = false;
            _vitalSignGraph.RightWidthPercent = 0.1f;
            _vitalSignGraph.Dock = DockStyle.Fill;
            _vitalSignGraph.BringToFront();
            splitContainerControl1.Panel1.Controls.Add(_vitalSignGraph);

            dtStartTime.Properties.DisplayFormat.FormatString = "g";
        }

        private void InitVitalSign()
        {
            if (_vitalSignGraph != null && _vitalSignDataTable != null && _vitalSignDataTable.Count > 0)
            {
                _vitalSignGraph.Curves.Clear();
                _vitalSignGraph.StartTime = ((DateTime)dtStartTime.EditValue).AddMinutes(-((DateTime)dtStartTime.EditValue).Minute % 5);
                _vitalSignGraph.EndTime = comboBox1.SelectedIndex <= 0 ? _vitalSignGraph.StartTime.AddMinutes(60) : _vitalSignGraph.StartTime.AddMinutes(60 / (comboBox1.SelectedIndex * 2));
                Dictionary<string, MedVitalSignCurveDetail> dict = new Dictionary<string, MedVitalSignCurveDetail>();
                List<MedVitalSignCurveDetail> userVitalSets =GetUserVitalShowSet(_eventNo);
                ///形成曲线字典
                foreach (MedVitalSignCurveDetail vitalSet in userVitalSets)
                {
                    if (!string.IsNullOrEmpty(vitalSet.CurveCode) && !dict.ContainsKey(vitalSet.CurveCode))
                    {
                        dict.Add(vitalSet.CurveCode, vitalSet);
                    }
                    else if (string.IsNullOrEmpty(vitalSet.CurveCode) && !string.IsNullOrEmpty(vitalSet.CurveName))//兼容苏大附一（name为表示）
                    {
                        foreach (AnesInformations.VitalSignRow vrow in _vitalSignDataTable.Rows)
                        {
                            if (vrow.ITEM_NAME.Equals(vitalSet.CurveName) && !dict.ContainsKey(vrow.ITEM_CODE))
                            {
                                dict.Add(vrow.ITEM_CODE, vitalSet);
                                break;
                            }
                        }
                    }
                }
                foreach (MedVitalSignCurveDetail detail in _vitalSignGraph.CurveDetails)
                {
                    if (!string.IsNullOrEmpty(detail.CurveCode) && !dict.ContainsKey(detail.CurveCode))
                    {
                        dict.Add(detail.CurveCode, detail);
                    }
                }
                DateTime dgStartTime = DateTime.MinValue;
                if (_vitalSignDataTable != null && _vitalSignDataTable.Count > 0)
                {
                    List<string> itemNames = new List<string>();
                    for (int i = 0; i < _vitalSignDataTable.Count; i++)
                    {
                        if (!itemNames.Contains(_vitalSignDataTable[i].ITEM_CODE)) itemNames.Add(_vitalSignDataTable[i].ITEM_CODE);
                    }
                    #region 逐条增加曲线
                    foreach (string item in itemNames)
                    {
                        if (dict.ContainsKey(item) && !dict[item].Visible) continue;
                        MedVitalSignCurveDetail vitalSignCurveDetail = null;
                        if (dict.ContainsKey(item))
                        {
                            vitalSignCurveDetail = dict[item];
                        }
                        DataRow[] rows = _vitalSignDataTable.Select("ITEM_CODE = '" + item + "'");
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
                                _vitalSignGraph.CurveDetails.Add(vitalSignCurveDetail);
                                curve = new MedVitalSignCurve(vitalSignCurveDetail.CurveName, item, vitalSignCurveDetail.YAxisIndex, color, symbol, isDigit);
                                curve.DotNumber = vitalSignCurveDetail.DotNumber;
                            }
                            if (symbol != null)
                            {
                                symbol.Size = _vitalSignGraph.CurveSymbolSize;
                            }
                            if (curve != null)
                            {

                                for (int i = 0; i < rows.Length; i++)
                                {
                                    int mu = (int)((TimeSpan)((DateTime)rows[i]["TIME_POINT"] - _vitalSignGraph.StartTime)).TotalMinutes;
                                    if (curve.IsDigit)
                                    {
                                        if (dict.ContainsKey(curve.Code) && ((mu % 2) == 0) && Convert.ToDouble(rows[i]["VALUE"]) > 0)
                                        {
                                            curve.Points.Add(new MedVitalSignPoint((DateTime)rows[i]["TIME_POINT"], Convert.ToDouble(rows[i]["VALUE"]), curve));
                                        }
                                    }
                                    else
                                    {
                                        curve.Points.Add(new MedVitalSignPoint((DateTime)rows[i]["TIME_POINT"], Convert.ToDouble(rows[i]["VALUE"]), curve));
                                    }

                                }
                                if (curve.Points.Count > 0)
                                {
                                    _vitalSignGraph.Curves.Add(curve);
                                }
                            }
                        }
                    }
                    #endregion 逐条增加曲线
                }
                _vitalSignGraph.Invalidate();
            }
        }

        private void InitGrid()
        {
            if (_vitalSignDataTable != null && _vitalSignDataTable.Rows.Count > 0)
            {
                List<string> itemNames = new List<string>();
                DataTable _vitalSignTable;
                _vitalSignTable = new DataTable();
                _vitalSignTable.Columns.Add("代码");
                _vitalSignTable.Columns.Add("名称");
                Dictionary<string, int> rowDict = new Dictionary<string, int>();
                string[] list = (new AnesthesiaSheetDA()).GetVitalSignTitles(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID, _eventNo);
                DataRow dtRow;
                foreach (string s in list)
                {
                    if (!rowDict.ContainsKey(s))
                        rowDict.Add(s, _vitalSignTable.Rows.Count);
                    dtRow = _vitalSignTable.NewRow();
                    dtRow[0] = s;
                    dtRow[1] = ExtendApplicationContext.Current.MonitorFunctionCodeDict.ContainsKey(s) ? ExtendApplicationContext.Current.MonitorFunctionCodeDict[s] : s;
                    _vitalSignTable.Rows.Add(dtRow);

                }
                foreach (AnesInformations.VitalSignRow row in _vitalSignDataTable.Rows)
                {
                    string columnName = row.TIME_POINT.ToString("HH:mm");
                    if (!_vitalSignTable.Columns.Contains(columnName))
                    {
                        DataColumn column = new DataColumn(columnName, typeof(string));
                        column.Caption = row.TIME_POINT.ToString("yyyy-MM-dd HH:mm");
                        _vitalSignTable.Columns.Add(column);
                    }
                    if (rowDict.ContainsKey(row.ITEM_CODE))
                    {
                        dtRow = _vitalSignTable.Rows[rowDict[row.ITEM_CODE]];
                    }
                    else
                    {
                        if (!rowDict.ContainsKey(row.ITEM_CODE))
                            rowDict.Add(row.ITEM_CODE, _vitalSignTable.Rows.Count);
                        dtRow = _vitalSignTable.NewRow();
                        dtRow[0] = row.ITEM_CODE;
                        _vitalSignTable.Rows.Add(dtRow);
                    }
                    dtRow[columnName] = row.VALUE;
                }
                dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
                dataGridView1.DataSource = _vitalSignTable;
                dataGridView1.Columns[0].Visible = false;
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    DataGridViewColumn column = dataGridView1.Columns[i];
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
        }

        private void RefreshAll()
        {
            if (dtStartTime.EditValue == null)
            {
                Dialog.MessageBox("温馨提示：请先输入起始时间。");
                return;
            }
            //DataHelper.ClearSheetVitalSign(Globals.PatientID, Globals.VisitID, Globals.OperID);
            //_vitalSignDataTable = DataHelper.GetVitalSignData(Globals.PatientID, Globals.VisitID, Globals.OperID, _eventNo, true);
            _vitalSignGraph.StartTime = ((DateTime)dtStartTime.EditValue).AddMinutes(-((DateTime)dtStartTime.EditValue).Minute % 5);
            _vitalSignGraph.EndTime = comboBox1.SelectedIndex <= 0 ? _vitalSignGraph.StartTime.AddMinutes(60) : _vitalSignGraph.StartTime.AddMinutes(60 / (comboBox1.SelectedIndex * 2));
            _vitalSignGraph.Invalidate();
            //InitGrid();
        }

        protected List<MedVitalSignCurveDetail> GetUserVitalShowSet(decimal eventNo)
        {
            List<MedVitalSignCurveDetail> list = new List<MedVitalSignCurveDetail>();
            BusinessEntity.Configuations.PatientMonitorConfigDataTable configTable = (new ConfigurationDA()).GetPatientMonitorConfigDataTable(
               ExtendApplicationContext.Current.PatientContext.PatientID,
               ExtendApplicationContext.Current.PatientContext.VisitID,
               ExtendApplicationContext.Current.PatientContext.OperID
               );
            if (configTable.Count > 0 && !configTable[0].IsCONTENTNull())
            {
                System.IO.MemoryStream stream = new System.IO.MemoryStream(configTable[0].CONTENT);
                stream.Position = 0;
                DataSet ds = new DataSet();
                ds.ReadXml(stream);
                if (ds.Tables.Count > 0)
                {
                    string tableName = "UserVitalShowSet" + ((eventNo < 0) ? 0 : eventNo).ToString();
                    DataTable dataTable = ds.Tables[tableName];
                    ListFromTable(list, typeof(MedVitalSignCurveDetail), dataTable);
                }
                ds.Dispose();
                stream.Close();
                stream.Dispose();
            }
            return list;
        }

        protected void ListFromTable(IList list, Type type, DataTable dataTable)
        {
            if (dataTable != null)
            {
                List<MemberDetail> memberDetails = AssemblyHelper.GetPropertyList(type);
                foreach (DataRow row in dataTable.Rows)
                {
                    object obj = Activator.CreateInstance(type);
                    foreach (MemberDetail memberDetail in memberDetails)
                    {
                        PropertyInfo propertyInfo = memberDetail.PropertyInfo;
                        if (dataTable.Columns.Contains(memberDetail.Name) && row[memberDetail.Name] != System.DBNull.Value)
                        {
                            try
                            {
                                AssemblyHelper.SetPropertyValue(propertyInfo, obj, row[memberDetail.Name].ToString());
                            }
                            catch (Exception ex)
                            {
                                XtraMessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    list.Add(obj);
                }
            }
        }

        /// <summary>
        /// 获取一个随机的颜色
        /// </summary>
        /// <returns></returns>
        protected Color GetRandomColor()
        {
            //System.Threading.Thread.Sleep(1);
            Random rand = new Random();
            int r = rand.Next(255);
            int g = rand.Next(255);
            int b = rand.Next(255);
            return Color.FromArgb(r, g, b);
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

        private void MijiVitalSign_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("60分钟");
            comboBox1.Items.Add("30分钟");
            comboBox1.Items.Add("15分钟");
            comboBox1.SelectedIndex = 0;
            _vitalSignDataTable = (new AnesthesiaSheetDA()).GetVitalSignData(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID, _eventNo, true);
            if (_vitalSignDataTable != null && _vitalSignDataTable.Count > 0)
            {
                dtStartTime.EditValue = (_vitalSignDataTable[0].TIME_POINT).AddMinutes(-(_vitalSignDataTable[0].TIME_POINT).Minute % 5);
            }
            InitVitalSign();
            InitGrid();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            RefreshAll();
        }

        //Add By chengying.x @20140221 新增密集体征数据打印功能
        private void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            DataTable dtPatientInfo = new PatientInformationsDA().GetPatientInfo(ExtendApplicationContext.Current.PatientContext.PatientID,
                ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID);
            e.Graphics.DrawString("患者密集体征数据", new Font(new FontFamily("黑体"), 15), System.Drawing.Brushes.Black, 500, 10);
            if (dtPatientInfo.Rows.Count == 1)
            {
                e.Graphics.DrawString("姓名:", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 50, 60);
                e.Graphics.DrawString(dtPatientInfo.Rows[0]["NAME"].ToString(), new Font(new FontFamily("黑体"), 10), System.Drawing.Brushes.Black, 100, 60);
                e.Graphics.DrawString("性别:", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 200, 60);
                e.Graphics.DrawString(dtPatientInfo.Rows[0]["SEX"].ToString(), new Font(new FontFamily("黑体"), 10), System.Drawing.Brushes.Black, 250, 60);
                e.Graphics.DrawString("年龄:", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 350, 60);
                e.Graphics.DrawString(dtPatientInfo.Rows[0]["AGE"].ToString(), new Font(new FontFamily("黑体"), 10), System.Drawing.Brushes.Black, 400, 60);
                e.Graphics.DrawString("住院号:", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 500, 60);
                e.Graphics.DrawString(dtPatientInfo.Rows[0]["INP_NO"].ToString(), new Font(new FontFamily("黑体"), 10), System.Drawing.Brushes.Black, 550, 60);
                e.Graphics.DrawString("科室:", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 650, 60);
                e.Graphics.DrawString(dtPatientInfo.Rows[0]["DEPT_NAME"].ToString(), new Font(new FontFamily("黑体"), 10), System.Drawing.Brushes.Black, 700, 60);
            }

            _vitalSignGraph.BackColor = Color.Transparent;
            _vitalSignGraph.Draw(e.Graphics, 40, 100);

        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument doc = new PrintDocument();
            doc.DefaultPageSettings.Landscape = true;

            _vitalSignGraph.BackHeight = _vitalSignGraph.Height;
            _vitalSignGraph.IsPrinting = true;
            _vitalSignGraph.Height = (int)(_vitalSignGraph.Height / _vitalSignGraph.ShowZoomRate);
            doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);
            PageSetupDialog pageSetupDialog = new PageSetupDialog();
            PaperSize ps = new PaperSize();
            ps.Width = (int)(19.5 / 2.54 * 100);
            ps.Height = (int)(27.0 / 2.54 * 100);

            doc.PrinterSettings.DefaultPageSettings.PaperSize = ps;
            doc.DefaultPageSettings.PaperSize = ps;

            doc.DefaultPageSettings.Margins = new Margins(2, 2, 2, 2);

            pageSetupDialog.Document = doc;
            pageSetupDialog.AllowMargins = true;
            pageSetupDialog.AllowPaper = true;
            if (pageSetupDialog.ShowDialog() == DialogResult.OK)
            {
                PrintPreviewDialog preview = new PrintPreviewDialog();
                preview.WindowState = FormWindowState.Maximized;
                preview.Document = doc;
                preview.ShowDialog();
            }

            _vitalSignGraph.IsPrinting = false;

        }
        //End Add

    }
}
