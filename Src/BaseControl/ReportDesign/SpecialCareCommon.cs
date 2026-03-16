using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Com.MedicalSystem.Common.Controls;
using Com.MedicalSystem.Common.Utilities;
using System.Text.RegularExpressions;
using System.Drawing.Printing;
using Com.ICIS.Common.Con;
using System.Collections;
using MedicalSystem.SmartReport.Viewer;
using System.Threading;
using Com.MedicalSystem.Icu;

namespace Com.ICIS.Icu
{
    public partial class SpecialCareCommon : BaseControl
    {

        #region 构造函数
        public SpecialCareCommon() : this(null) { }

        public SpecialCareCommon(MedicalSystem.Icu.DataSetModel.Patient.PatientRow patientRow) : this(patientRow, "福建省肿瘤医院") { }

        public SpecialCareCommon(MedicalSystem.Icu.DataSetModel.Patient.PatientRow patientRow, string title)
            : base(patientRow, title)
        {
            InitializeComponent();
            flowLayoutPanel1.BringToFront();
            DateTime dateTime = DataOperator.GetSysDate();
            dtp_StartTime.DateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 7, 1, 0);
            dtp_EndTime.DateTime = dtp_StartTime.DateTime.AddDays(1);//.AddSeconds(-1);
            try
            {
                printerSettingGraphics = new PrintDocument().PrinterSettings.CreateMeasurementGraphics();
            }
            catch (Exception)
            {
                printerSettingGraphics = new Form().CreateGraphics();//this.CreateGraphics();
            }
            
        }
        #endregion

        #region 变量
        /// <summary>
        /// 需要画斜线的列
        /// </summary>
        private Dictionary<string, string> CustomArray = new Dictionary<string, string>();
        /// <summary>
        /// 开始时间
        /// </summary>
        private DateTime startTime = DateTime.Now;
        /// <summary>
        /// 结束时间
        /// </summary>            
        private DateTime endTime = DateTime.Now.AddDays(1);
        /// <summary>
        /// 默认横向列模板字典
        /// </summary>
        private Dictionary<string, int> MainColumns = new Dictionary<string, int>();
        /// <summary>
        /// 默认竖向列模板
        /// </summary>
        private ArrayList MainVerticalColumns = new ArrayList();
        /// <summary>
        /// 竖向列模板数据绑定
        /// </summary>
        private List<string> MainVerticalDataBind = new List<string>();

        protected DataTable SourceTable;
        /// <summary>
        /// 查询时间
        /// </summary>
        private DateTime StartQueryTime = DateTime.Now;
        /// <summary>
        /// 显示打印页码
        /// </summary>
        private int lastDatePrintPageNo = 0;
        /// <summary>
        /// 总页数
        /// </summary>
        private int PageCount;
        /// <summary>
        /// 科室名称
        /// </summary>
        //private string DeptName = "";
        /// <summary>
        /// 总页码
        /// </summary>
        private int PageIndex = 0;

        /// <summary>
        /// 是否处于打印状态
        /// </summary>
        bool notPrint = true;

        public Graphics printerSettingGraphics;
        /// <summary>
        /// 指定打印页
        /// </summary>
        //private int PrintIndex = 0;
        /// <summary>
        /// 文书配置项明细
        /// </summary>
        DataSetModel.CareDocs.MED_DOCUMENT_DESIGN_DETAILDataTable detail = new Com.MedicalSystem.Icu.DataSetModel.CareDocs.MED_DOCUMENT_DESIGN_DETAILDataTable();
        /// <summary>
        /// 文书配置项主表
        /// </summary>
        DataSetModel.CareDocs.MED_DOCUMENT_DESIGN_MAINDataTable main = new Com.MedicalSystem.Icu.DataSetModel.CareDocs.MED_DOCUMENT_DESIGN_MAINDataTable();
        /// <summary>
        /// 表头部分高度
        /// </summary>
        //int largestTop = 0;
        /// <summary>
        /// 当前选中cell
        /// </summary>
        private PrintCell Currentcell;
        /// <summary>
        /// 自定义列头列表
        /// </summary>
        protected List<string> userDefineColumn = new List<string>();
        ///// <summary>
        ///// 自定义列头列表
        ///// </summary>
        //private List<int> indexColumnNo = new List<int>();
        /// <summary>
        /// 列头绑定名称列表
        /// </summary>
        private List<string> columnHead = new List<string>();

        private Dictionary<int, string> customColumnHead = new Dictionary<int, string>();
        /// <summary>
        /// HeadLine显示文本
        /// </summary>
        private ArrayList array = new ArrayList();
        /// <summary>
        /// HeadLine名称
        /// </summary>
        private ArrayList arrayName = new ArrayList();
        /// <summary>
        /// 缺省宽度
        /// </summary>
        private int DefaultWidth = 35;
        /// <summary>
        /// 缺省高度
        /// </summary>
        private int DefaultHeight = 35;
        /// <summary>
        /// 缺省行数
        /// </summary>
        private int DefaultLineCount = 10;
        /// <summary>
        /// TreeView最大横向深度
        /// </summary>
        private int MaxHorizontalLevel = 1;
        /// <summary>
        /// TreeView最大纵向深度
        /// </summary>
        private int MaxVerticalLevel = 1;
        /// <summary>
        /// 数据库中保存的树
        /// </summary>
        private DataSetModel.CareDocs.MED_SPECIALCARE_CONFIGDataTable dtTreeView;
        /// <summary>
        /// 列模板数
        /// </summary>
        private int HeaderRowCount = 0;
        /// <summary>
        /// 列头横向还是竖向，H为横向，V为竖向（固定时间列），“纵向”为竖向（不固定时间）
        /// </summary>
        protected string Direction = "H";
        /// <summary>
        /// 竖向显示列头表
        /// </summary>
        private DataTable VerticalTable;
        /// <summary>
        /// 横向显示列头表
        /// </summary>
        private DataTable HorizontalTable;
        /// <summary>
        /// 每页行数
        /// </summary>
        private int lineNumberOfPage = 30;
        /// <summary>
        /// 打印行
        /// </summary>
        private PrintLine line = null;
        /// <summary>
        /// 动态的列头数据
        /// </summary>
        private List<string> detailHead = new List<string>();

        List<int> numberColumn = new List<int>();//读取列头时间列顺序
        #endregion

        #region 属性
        /// <summary>
        /// 最小列宽
        /// </summary>
        private const int MINWIDTH = 40;
        /// <summary>
        /// 打印控件
        /// </summary>
        public MedPrintPreview PrintPreview
        {
            get
            {
                return printPreview1;
            }
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartDateTime
        {
            get
            {
                return startTime;
            }
            set
            {
                startTime = value;
            }
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndDateTime
        {
            get
            {
                return endTime;
            }
            set
            {
                endTime = value;
            }
        }
        /// <summary>
        /// 最后一次打印页码
        /// </summary>
        public int LastDatePrintPageNo
        {
            get
            {
                return lastDatePrintPageNo;
            }
            set
            {
                lastDatePrintPageNo = value;
            }
        }
        #endregion

        #region  方法
        /// <summary>
        /// 初始化打印控件
        /// </summary>
        public void initPrintControl()
        {
            getDesignControl();     //获取表单配置
            dtTreeView = DataOperator.GetSpecialCareAllColumns(Title, DataOperator.WardCode);
            HorizontalTable = dtTreeView.Clone();
            VerticalTable = dtTreeView.Clone();
            MaxHorizontalLevel = GetMaxTagLevelByDirection(dtTreeView);

            if (GetAttributes(0, "列头", "横向打印").Trim() == "是")
            {
                printPreview1._hengDa = true;
            }

            string direction = GetAttributes(0, "列头", "列头位置");
            if (direction == "纵向")
            {
                DataRow[] rows = dtTreeView.Select("project_level > 1 and project_attribute = '不固定行' and attribute_value = '是'");

                if (rows.Length > 0)
                {
                    Direction = "V";
                }
                else
                {
                    Direction = direction;
                }
                MaxVerticalLevel = GetMaxTagLevelByDirection(VerticalTable);
            }
            RefreshPreview();
            if (Direction == "V")
            {
                DataRow[] numberRows = HorizontalTable.Select("(project_category = '无' or project_category = '' or project_category is null) and project_attribute = '显示文本'", "START_INDEX ASC");

                foreach (DataRow row in numberRows)
                {
                    string attributeValue = GetAttributes(int.Parse(row["project_level"].ToString()), row["project_name"].ToString(), "显示文本");
                    int number = 0;
                    if (int.TryParse(attributeValue, out number))
                    {
                        numberColumn.Add(number);
                    }
                }
            }
        }
        /// <summary>
        /// 转换对齐方式
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private ContentAlignment ConvertContentAlignment(string text)
        {
            switch (text)
            {
                case "左对齐":
                    return ContentAlignment.MiddleLeft;
                case "右对齐":
                    return ContentAlignment.MiddleRight;
                default:
                    return ContentAlignment.MiddleCenter;
            }
        }
        /// <summary>
        /// 根据DataTable生成表格
        /// </summary>
        private bool DataTableToPrintPreview()
        {
            string selectString = string.Empty;
            bool tableDirection = true;//横向为true
            DataTable table = null;

            if (VerticalTable != null && VerticalTable.Rows.Count > 0)
            {
                tableDirection = false;//纵向
            }
            if (tableDirection)
            {
                selectString = "end_index is null and project_level > 0";
                table = dtTreeView;
            }
            else
            {
                selectString = "end_index is null and project_level > 1 and project_name <> '纵向' and project_name <> '横向'";
                table = HorizontalTable;
            }

            DataRow[] rows = table.Select(selectString, "START_INDEX ASC");
            foreach (DataRow row in rows)
            {
                string projectName = row["project_name"].ToString();

                if (!MainColumns.ContainsKey(projectName))
                {
                    int level = int.Parse(row["project_level"].ToString());
                    MainColumns.Add(projectName, int.Parse(GetAttributes(level, projectName, "列宽")));

                    string customLine = GetAttributes(level, projectName, "斜线");
                    if (customLine.Trim() != "" && customLine != "否")
                    {
                        CustomArray.Add(projectName, customLine);
                    }
                    if (projectName.Trim() != "开始时间")
                    {
                        array.Add(GetAttributes(level, projectName, "显示文本").Replace("\\", "\n"));
                    }
                    else
                    {
                        array.Add(DateTime.Now.Year.ToString() + "年");
                    }
                    arrayName.Add(projectName);
                }
            }

            if (!tableDirection)
            {
                DataRow[] rowsVertical = VerticalTable.Select(selectString, "START_INDEX ASC");
                foreach (DataRow row in rowsVertical)
                {
                    string projectName = row["project_name"].ToString();

                    if (!MainVerticalColumns.Contains(projectName))
                    {
                        MainVerticalColumns.Add(projectName);
                    }
                    if (row["PROJECT_ATTRIBUTE"].ToString() == "数据绑定" && row["ATTRIBUTE_VALUE"].ToString() != "")
                    {
                        MainVerticalDataBind.Add(row["ATTRIBUTE_VALUE"].ToString());
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// 刷新预览界面
        /// </summary>
        private void RefreshPreview()
        {
            printPreview1.HeadLines.Clear();
            printPreview1.DetailLines.Clear();
            array.Clear();
            CustomArray.Clear();
            arrayName.Clear();
            MainColumns.Clear();
            MainVerticalColumns.Clear();
            printPreview1.ColumnModules.Clear();
            HorizontalTable.Rows.Clear();
            VerticalTable.Rows.Clear();
            line = null;
            string direction = GetAttributes(0, "列头", "列头位置");

            if (direction == "横向")
            {
                MaxHorizontalLevel = GetMaxTagLevelByDirection(dtTreeView);
                GenerateHeaders(dtTreeView, direction, true);
            }
            else if (direction == "纵向")
            {
                bool nodeH = FindTreeNodeByText("横向");
                if (nodeH == false)//没有指定横向列头时
                {
                    MaxHorizontalLevel = GetMaxTagLevelByDirection(dtTreeView);
                    GenerateHeaders(dtTreeView, direction, true);
                }
                else//出现横向列头时
                {
                    bool nodeV = FindTreeNodeByText("纵向");
                    if (nodeV != false)//画纵向列头
                    {
                        GetRowsByDirection(HorizontalTable, "横向");
                        GetRowsByDirection(VerticalTable, "纵向");
                        MaxHorizontalLevel = GetMaxTagLevelByDirection(HorizontalTable);
                        MaxVerticalLevel = GetMaxTagLevelByDirection(VerticalTable);
                        if (VerticalTable.Rows.Count > 0)
                        {
                            for (int i = 2; i <= MaxVerticalLevel; i++)
                            {
                                DataRow[] rows = VerticalTable.Select("project_level = '" + i + "' and project_attribute = '列宽'", "START_INDEX ASC");
                                int cellWidth = 35;
                                if (!int.TryParse(rows[0]["attribute_value"].ToString(), out cellWidth))
                                {
                                    cellWidth = 35;
                                }
                                string proName = rows[0]["project_name"].ToString();
                                MainColumns.Add(proName, cellWidth);
                                arrayName.Add(proName);
                                array.Add(GetAttributes(i, proName, "显示文本").Replace("\\", "\n"));
                            }
                            GenerateHeaders(HorizontalTable, direction, true);

                            //画竖向列头
                            GenerateHeaders(HorizontalTable, direction, false);
                        }
                        else
                        {
                            GenerateHeaders(HorizontalTable, direction, true);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 设置总结与护理措施列模板合并列
        /// </summary>
        /// <param name="projectName"></param>
        private void SetPrintColumnModules(string projectName)
        {
            string selectString = "";
            if (projectName == "总结")
            {
                selectString = "project_name = '列头' and project_attribute = '总结列模板格式'";
            }
            else if (projectName == "护理措施项目")
            {
                selectString = "project_category='" + projectName + "' and project_attribute = '列模板格式'";
            }
            DataRow[] rows = dtTreeView.Select(selectString);
            if (rows.Length > 0 && rows[0]["attribute_value"] != null)
            {
                string[] values = rows[0]["attribute_value"].ToString().Split(',');
                List<int> intArray = new List<int>();
                List<string> stringArray = new List<string>();

                for (int i = 0; i < values.Length; i++)
                {
                    if (values[i].Contains("-"))
                    {
                        string[] num = values[i].Split('-');
                        int num1 = int.Parse(num[0]);
                        int num2 = int.Parse(num[1]);
                        if (i == 0 && num1 > 1)
                        {
                            intArray.Add(num1 - 1);
                            stringArray.Add("");
                        }
                        //if (intArray.Count > 0)
                        //{
                        //    for (int j = 0; j < num1 - intArray[intArray.Count - 1]; j++)
                        //    {
                        //        intArray.Add(1);
                        //        stringArray.Add("");
                        //    }
                        //}
                        intArray.Add(num2 - num1 + 1);
                        stringArray.Add("");
                    }
                }
                if (intArray.Count > 0 && stringArray.Count > 0)
                {
                    intArray.TrimExcess();
                    stringArray.TrimExcess();
                    ///行模板-该行包括一列(所有列合并用于总结整行打印)
                    printPreview1.ColumnModules.Add(projectName + "列模板格式", new PrintColumnModule(MainColumns, intArray.ToArray(), stringArray.ToArray()));
                }
            }
        }
        /// <summary>
        /// 根据名称查找节点
        /// </summary>
        /// <param name="nodeCollection"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        private bool FindTreeNodeByText(string text)
        {
            DataRow[] rows = dtTreeView.Select("project_name = '" + text + "'");
            if (rows.Length > 0)
                return true;
            else
                return false;   
        }
        /// <summary>
        /// 生成除了最下级列头行模板的其它行模板
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="direction">方向（横向、纵向）</param>
        private void DrawOtherHeaders(DataTable dt, string direction)
        {
            int oldEndIndex = -1;
            int startLevel = 1;
            int endLevel = MaxHorizontalLevel - 1;
            bool addVertical = false;
            if (direction == "纵向" && FindTreeNodeByText("纵向") != false)
            {
                startLevel++;
                if (VerticalTable.Rows.Count > 0)
                {
                    addVertical = true;
                }
            }
            if (dt.Rows.Count <= 0)
            {
                return;
            }
            for (int i = startLevel; i <= endLevel; i++)
            {
                oldEndIndex = -1;

                DataRow[] rows = dt.Select("project_level = '" + i.ToString() + "' and PROJECT_ATTRIBUTE = '显示文本' ", "START_INDEX ASC");

                List<int> intArray = new List<int>();
                List<string> stringArray = new List<string>();
                if (addVertical)
                {
                    for (int j = 2; j <= MaxVerticalLevel; j++)
                    {
                        intArray.Add(1);
                        stringArray.Add("");
                    }
                }
                foreach (DataRow r in rows)
                {
                    string rname = r["ATTRIBUTE_VALUE"].ToString();
                    int StartIndex = int.Parse(r["START_INDEX"].ToString());
                    if (r["END_INDEX"] != null && r["END_INDEX"].ToString().Trim() != "")
                    {
                        int EndIndex = int.Parse(r["END_INDEX"].ToString());
                        if (StartIndex != oldEndIndex + 1)
                        {
                            intArray.Add(StartIndex - oldEndIndex - 1);
                            stringArray.Add("");
                        }
                        intArray.Add(EndIndex - StartIndex + 1);
                        if (r["project_name"].ToString() != "开始时间")
                        {
                            stringArray.Add(rname.Replace(@"\", "\n"));
                        }
                        else 
                        {
                            stringArray.Add(DateTime.Now.Year.ToString() + "年");
                        }
                        oldEndIndex = EndIndex;
                    }
                }
                if (MaxHorizontalLevel > 1)
                {
                    intArray.TrimExcess();
                    stringArray.TrimExcess();
                    printPreview1.ColumnModules.Add(HeaderRowCount.ToString(), new PrintColumnModule(MainColumns, intArray.ToArray(), stringArray.ToArray(), 0));
                    PrintLine line;
                    ///列头一
                    line = printPreview1.addHeadLine(HeaderRowCount.ToString());
                    line.SingleLineHeight = int.Parse(GetAttributes(HeaderRowCount + 1, "", "行高"));
                    string[] strFont = GetAttributes(0, "列头", "列头字体").Split('&');
                    if (strFont.Length > 1)
                    {
                        line.Font = AssemblyHelper.ConvertStringToFont(strFont[0], strFont[1]);
                    }
                    line.TextAlign = ConvertContentAlignment(GetAttributes(0, "列头", "对齐方式"));
                    HeaderRowCount++;
                }
            }
        }
        /// <summary>
        /// 生成表格列模板
        /// </summary>
        /// <param name="drawNodes"></param>
        /// <param name="table"></param>
        /// <param name="direction"></param>
        /// <param name="drawDirection"></param>
        private void GenerateHeaders(DataTable table, string direction, bool drawDirection)
        {
            int rowNumber = 0;
            if (drawDirection)//画横向列头
            {
                HeaderRowCount = 0;

                if (DataTableToPrintPreview())
                {
                    //if ((direction == "纵向") && VerticalTable.Rows.Count > 0)
                    //{
                    //    printPreview1.LineNumberPerPage = MainVerticalColumns.Count - 1;
                    //}
                    //else if (direction == "横向" || VerticalTable.Rows.Count <= 0)
                    //{
                        string strLineNumberPerPage = GetAttributes(0, "列头", "每页行数");
                        if (strLineNumberPerPage.Trim() != "")
                        {
                            printPreview1.LineNumberPerPage = int.Parse(strLineNumberPerPage);
                        }
                    //}
                    lineNumberOfPage = printPreview1.LineNumberPerPage;
                    //PrintCell.LineNumberOfPage = lineNumberOfPage;
                    string strDefaultLineHeight = GetAttributes(0, "列头", "默认行高");
                    if (strDefaultLineHeight.Trim() != "")
                    {
                        printPreview1.DefaultLineHeight = int.Parse(strDefaultLineHeight);
                    }

                    printPreview1.ColumnModules.Add("columnModuleMain", new PrintColumnModule(MainColumns));

                    DrawOtherHeaders(table, direction);

                    line = printPreview1.addHeadLine("columnModuleMain", array.ToArray());

                    SetPrintColumnModules("总结");
                    SetPrintColumnModules("护理措施项目");

                    line.SingleLineHeight = int.Parse(GetAttributes(MaxHorizontalLevel, "", "行高"));
                    string[] strFont = GetAttributes(0, "列头", "列头字体").Split('&');
                    if (strFont.Length > 1)
                    {
                        line.Font = AssemblyHelper.ConvertStringToFont(strFont[0], strFont[1]);
                    }
                    line.TextAlign = ConvertContentAlignment(GetAttributes(0, "列头", "对齐方式"));

                    #region 设置RowSpan
                    for (int i = 0; i < line.Count; i++)
                    {
                        int iLevel = int.Parse(GetAttributes(0, arrayName[i].ToString(), "Level"));
                        if (i >= MaxVerticalLevel - 1)
                        {
                            //line[i].RowSpan = MaxHorizontalLevel - node.Level + 1; 
                            strFont = GetAttributes(iLevel, arrayName[i].ToString(), "字体").Split('&');
                            line[i].RowSpan = MaxHorizontalLevel - iLevel + 1;
                        }
                        else
                        {
                            line[i].RowSpan = MaxHorizontalLevel - 1;
                        }
                        if (strFont.Length > 1)
                        {
                            line[i].Font = AssemblyHelper.ConvertStringToFont(strFont[0], strFont[1]);
                        }
                        line[i].TextAlign = ConvertContentAlignment(GetAttributes(iLevel, arrayName[i].ToString(), "对齐方式"));
                    }
                    #endregion

                    printPreview1.addDetailLine(0, new object[] { "" });
                    if (direction == "纵向" && VerticalTable.Rows.Count > 0)
                    {
                        string strNumber = GetAttributes(0, "列头", "行数");

                        if (int.TryParse(GetAttributes(0, "列头", "行数"), out rowNumber))
                        {
                            for (int i = 0; i < rowNumber - 1; i++)
                            {
                                printPreview1.addDetailLine(0, new object[] { "" });
                            }
                        }
                        else
                        {
                            for (int i = 0; i < MainVerticalColumns.Count - 1; i++)
                            {
                                printPreview1.addDetailLine(0, new object[] { "" });
                            }
                        }
                    }
                }
            }
            else if (!drawDirection && line != null)//画竖向列头
            {
                DataRow[] childRows = VerticalTable.Select("project_level = '2' and project_attribute = '父节点' and attribute_value = '纵向'", "START_INDEX ASC");
                if (childRows.Length <= 0)
                {
                    return;
                }
                string parentName = "纵向";

                for (int i = 2; i <= MaxVerticalLevel; i++)
                {
                    DataRow[] rows = VerticalTable.Select("project_level = '" + i + "' and project_attribute = '显示文本'", "START_INDEX ASC");

                    foreach (DataRow row in rows)
                    {
                        int startIndex = int.Parse(row["START_INDEX"].ToString());
                        if (startIndex > 0)
                        {
                            if (row["end_index"] != null && row["end_index"].ToString().Trim() != "")
                            {
                                int endIndex = 0;
                                if (int.TryParse(row["end_index"].ToString(), out endIndex))
                                {
                                    printPreview1.DetailLines[endIndex - 1][i - 2].RowSpan = endIndex - startIndex + 1;
                                    printPreview1.DetailLines[endIndex - 1][i - 2].Value = row["attribute_value"].ToString().Replace("\\", "\n");
                                    printPreview1.DetailLines[endIndex - 1][i - 2].TextAlign = ContentAlignment.MiddleCenter;
                                    if (row["FONT"].ToString() != "")
                                    {
                                        printPreview1.DetailLines[endIndex - 1][i - 2].Font = AssemblyHelper.ConvertStringToFont(row["FONT"].ToString(), row["FONT_STYLE"].ToString());
                                    }
                                }
                            }
                            else
                            {
                                printPreview1.DetailLines[startIndex - 1][MaxVerticalLevel - 2].ColumnsSpan = MaxVerticalLevel - i + 1;
                                printPreview1.DetailLines[startIndex - 1][MaxVerticalLevel - 2].Value = row["attribute_value"].ToString().Replace("\\", "\n");
                                printPreview1.DetailLines[startIndex - 1][MaxVerticalLevel - 2].TextAlign = ContentAlignment.MiddleCenter;
                                if (row["FONT"].ToString() != "")
                                {
                                    printPreview1.DetailLines[startIndex - 1][MaxVerticalLevel - 2].Font = AssemblyHelper.ConvertStringToFont(row["FONT"].ToString(), row["FONT_STYLE"].ToString());
                                }
                                int width = 0;
                                for (int k = 0; k < printPreview1.DetailLines[startIndex - 1][MaxVerticalLevel - 2].ColumnsSpan; k++)
                                {
                                    width = width + printPreview1.DetailLines[startIndex - 1][MaxVerticalLevel - 2 - k].Rect.Width;
                                    if (k > 0)
                                    {
                                        printPreview1.DetailLines[startIndex - 1][MaxVerticalLevel - 2 - k].Value = "";
                                    }
                                }
                                //if (startIndex != 2)
                                //{
                                    printPreview1.DetailLines[startIndex - 1][MaxVerticalLevel - 2].Rect = new Rectangle(
                                        printPreview1.DetailLines[startIndex - 1][MaxVerticalLevel - 2].Rect.X, printPreview1.DetailLines[startIndex - 1][MaxVerticalLevel - 2].Rect.Y, width, printPreview1.DetailLines[startIndex - 1][MaxVerticalLevel - 2].Rect.Height);
                                //}
                            }
                        }
                        else
                        {
                            int itemLevel = int.Parse(row["project_level"].ToString());
                            string childName = GetAttributes(itemLevel, row["project_name"].ToString(), "父节点");

                            if (childName == parentName)
                            {
                                parentName = row["project_name"].ToString();
                                if (row["end_index"] == null || row["end_index"].ToString().Trim() == "")
                                {
                                    line[MaxVerticalLevel - 2].ColumnsSpan = MaxVerticalLevel - i + 1;
                                    line[MaxVerticalLevel - 2].Value = GetAttributes(itemLevel, parentName, "显示文本").Replace("\\", "\n");
                                    int width = 0;
                                    for (int k = 0; k < line[MaxVerticalLevel - 2].ColumnsSpan; k++)
                                    {
                                        width = width + line[MaxVerticalLevel - 2 - k].Rect.Width;
                                        if (k > 0)
                                        {
                                            line[MaxVerticalLevel - 2 - k].Value = "";
                                        }
                                    }
                                    if (startIndex != 2)
                                    {
                                        line[MaxVerticalLevel - 2].Rect = new Rectangle(
                                            line[MaxVerticalLevel - 2].Rect.X, line[MaxVerticalLevel - 2].Rect.Y, width, line[MaxVerticalLevel - 2].Rect.Height);
                                    }
                                }
                                string customLine = GetAttributes(int.Parse(row["project_level"].ToString()), row["project_name"].ToString(), "斜线");
                                if (customLine.Trim() != "" && customLine != "否")
                                {
                                    CustomArray.Add(parentName, customLine);
                                }
                            }
                        }
                    }
                }
            }
            //printPreview1.RefreshLines();
            //printPreview1.Invalidate();
        }
        /// <summary>
        /// 获取特护单各种属性
        /// </summary>
        /// <param name="node">所在列</param>
        /// <param name="AttributeName">需要获取的属性名称</param>
        /// <returns>属性值（String）</returns>
        private string GetAttributes(int cellLevel, string cellName, string AttributeName)
        {
            DataRow[] rows = null;
            switch (AttributeName)
            {
                case "Level":
                    rows = dtTreeView.Select("project_name = '" + cellName + "'");
                    if (rows.Length > 0)
                    {
                        object result = rows[0]["PROJECT_LEVEL"];
                        if (result != null && result.ToString().Trim() != "")
                            return result.ToString();
                    }
                    return cellLevel.ToString();
                case "名称":
                    return cellName;
                case "类型":
                    rows = dtTreeView.Select("project_level = '" + cellLevel + "' and project_name = '" + cellName + "'");
                    if (rows.Length > 0)
                    {
                        object result = rows[0]["PROJECT_CATEGORY"];
                        if (result != null && result.ToString().Trim() != "")
                            return result.ToString();
                    }
                    return "";
                case "行高":
                    rows = dtTreeView.Select("project_level = '" + cellLevel + "'  and PROJECT_ATTRIBUTE='" + AttributeName + "'");
                    if (rows.Length > 0)
                    {
                        object result = rows[0]["ATTRIBUTE_VALUE"];
                        if (result != null && result.ToString().Trim() != "")
                            return result.ToString();
                        else
                            return DefaultHeight.ToString();
                    }
                    return DefaultHeight.ToString();
                case "每页行数":
                case "默认行高":
                case "边框线宽度":
                    rows = dtTreeView.Select("project_level = '0' and  project_name = '列头' and PROJECT_ATTRIBUTE='" + AttributeName + "'");
                    if (rows.Length > 0)
                    {
                        object result = rows[0]["ATTRIBUTE_VALUE"];
                        if (result != null && result.ToString().Trim() != "")
                            return result.ToString();
                        else
                        {
                            if (AttributeName == "默认行高")
                                return DefaultHeight.ToString();
                            if (AttributeName == "每页行数")
                                return DefaultLineCount.ToString();
                        }
                    }
                    return "";
                case "字体":
                case "列头字体":
                case "行字体":
                    rows = dtTreeView.Select("project_level = '" + cellLevel + "' and project_name = '" + cellName + "'");
                    if (rows.Length > 0)
                    {
                        object result1 = rows[0]["FONT"];
                        object result2 = rows[0]["FONT_STYLE"];
                        if (result1 != null && result1.ToString().Trim() != "" && result2 != null && result2.ToString().Trim() != "")
                            return result1.ToString() + "&" + result2.ToString();
                    }
                    return "";
                default:
                    rows = dtTreeView.Select("project_level = '" + cellLevel + "' and project_name = '" + cellName + "' and PROJECT_ATTRIBUTE = '" + AttributeName + "'");
                    if (rows.Length > 0)
                    {
                        object result = rows[0]["ATTRIBUTE_VALUE"];
                        if (result != null && result.ToString().Trim() != "")
                            return result.ToString();
                        else
                        {
                            if (AttributeName == "列宽")
                                return DefaultWidth.ToString();
                            else
                                return "";
                        }
                    }
                    else if (AttributeName == "列宽")
                        return DefaultWidth.ToString();
                    return "";
            }
        }

        private int getTimePointNoAndXuDa()
        {
            DataRow[] row = dtTreeView.Select("PROJECT_ATTRIBUTE = '数据绑定' and ATTRIBUTE_VALUE = 'TIME_POINT'");
            return row.Length;
        }

        private void getDesignControl()
        {
            detail = DataOperator.GetDocumentDesignDetail(Title, DataOperator.WardCode);
            main = DataOperator.GetDocumentDesignMain(DataOperator.WardCode);
            main.DefaultView.RowFilter = "DOCUMENT_NAME='" + Title + "'";
            foreach (DataSetModel.CareDocs.MED_DOCUMENT_DESIGN_DETAILRow row in detail.Rows)
            {
                if (row.CONTROL_TYPE == "MedTextBox")
                {
                    row.TEXT = getItemValue(row.TEXT);
                }
            }
        }

        private void getColumnDataBind()
        {
            DataSetModel.CareDocs.MED_SPECIALCARE_CONFIGDataTable config = null;
            if (Direction != "V")
            {
                config = DataOperator.GetConfigChild(Title);
            }
            else
            {
                config = (DataSetModel.CareDocs.MED_SPECIALCARE_CONFIGDataTable)HorizontalTable;
            }
            columnHead.Clear();
            customColumnHead.Clear();
            int observeIndex = 1;
            int columnNoIndex = 2;

            foreach (DataSetModel.CareDocs.MED_SPECIALCARE_CONFIGRow row in config.Rows)
            {
                if (Direction != "V")
                {
                    if (row.PROJECT_CATEGORY == "观察类项目")
                    {
                        if (!row.IsATTRIBUTE_VALUENull() && row.ATTRIBUTE_VALUE == "自定义列")
                        {
                            customColumnHead.Add(columnNoIndex, null);
                            columnHead.Add("CANAL" + observeIndex.ToString());
                            observeIndex++;
                            columnNoIndex++;
                        }
                        else if (row.PROJECT_ATTRIBUTE == "数据绑定")
                        {
                            columnHead.Add("CANAL" + observeIndex.ToString());
                            observeIndex++;
                            columnNoIndex++;
                        }
                    }
                    if (row.PROJECT_CATEGORY != "观察类项目" && row.PROJECT_ATTRIBUTE == "数据绑定")
                    {
                        if (row.IsATTRIBUTE_VALUENull())
                        {
                            continue;
                        }
                        if (row.ATTRIBUTE_VALUE.Contains("InSignName"))
                        {
                            columnHead.Add("InSignName");
                            columnNoIndex++;
                            continue;
                        }
                        if (row.ATTRIBUTE_VALUE == "自定义列")
                        {
                            //customColumnHead.Add(columnNoIndex, null);
                            //columnHead.Add("CANAL" + observeIndex.ToString());
                            //observeIndex++;
                        }
                        else
                        {
                            columnHead.Add(row.ATTRIBUTE_VALUE);
                        }
                        columnNoIndex++;
                    }
                }
                else if (Direction == "V" && row.PROJECT_ATTRIBUTE == "显示文本")
                {
                    int numberColumn = -1;
                    if (int.TryParse(row.ATTRIBUTE_VALUE, out numberColumn))
                    {
                        if (numberColumn >= 0)
                        {
                            columnHead.Add("Canal" + row.ATTRIBUTE_VALUE);
                            columnNoIndex++;
                        }
                    }
                }
            }
        }

        private int getOrderColumnNo()
        {
            for (int i = 0; i < columnHead.Count; i++)
            {
                if (columnHead[i] == "InSignName")
                {
                    return i;
                }
            }
            return 4;
        }
        /// <summary>
        /// 判断猎头里是否有特殊列模板
        /// </summary>
        /// <param name="nurseDesc"></param>
        /// <param name="summury"></param>
        private void getColumnConfig(ref bool nurseDesc,ref bool summury)
        {
            nurseDesc = printPreview1.ColumnModules.ContainsKey("护理措施项目列模板格式");
            summury = printPreview1.ColumnModules.ContainsKey("总结列模板格式");
        }
        /// <summary>
        /// 刷新报表
        /// </summary>
        public virtual void RefreshReport()
        {
            if (PatientRow == null)
                return;
            //getDesignControl();     //获取表单配置
            getColumnDataBind();    //获取列头位置和绑定字段
            //PrintCell.LineNumberOfPage = lineNumberOfPage;
            notPrint = true;
            PrintLine line = null;
            if (!GetOtherTable(ref SourceTable))
            {
                userDefineColumn.Clear();
                FrmItemConfig.GetUserCustomHeader(PatientID, VisitID, DepID, Title, ref customColumnHead, ref  userDefineColumn);
                foreach (KeyValuePair<int ,string> var in customColumnHead)
                {
                    string newValue = "";
                    foreach (char c in var.Value)
                    {
                        newValue += c + "\r\n";
                    }
                    printPreview1.HeadLines[1][var.Key].Value = newValue;
                }
                SourceTable = DataOperator.GetSpecialCareCommon(Title, dtp_StartTime.DateTime, dtp_EndTime.DateTime, PatientRow.PATIENT_ID, (int)PatientRow.VISIT_ID,PatientRow.DEP_ID, userDefineColumn, checkBox1.Checked, Direction);
            }
            
            //SourceTable = getTestTable();
            if (SourceTable == null)
            {
                return;
            }
            if (SourceTable.Rows.Count > 0 && Direction == "H")
            {
                if (SourceTable.Columns.Contains("TimePoint"))
                {
                    SourceTable.DefaultView.Sort = "TimePoint ASC";
                }
            }
            DataTable DTSource = SourceTable.DefaultView.ToTable();

            string OldDate = string.Empty;
            string Date = string.Empty;
            string Time = string.Empty;
            int RowNo = 0;
            bool nurseTemplate = false,summaryTemplate = false;
            int timePointNo = getTimePointNoAndXuDa();
            getColumnConfig(ref nurseTemplate,ref summaryTemplate);

            if (Direction == "H")
            {
                ///清空明细行
                printPreview1.clearDetailLines();
            }
            else
            {
                ClearDetailLine();
                if (DTSource.Rows.Count > MainColumns.Count - (MaxVerticalLevel - 1))
                {
                    initDetailLines(DTSource.Rows.Count);
                }
            }
            
            if (cbxXuDa.Checked)
            {
                printPreview1.DrawAllCell = false;
                printPreview1.UpRowNo = -1;
            }
            printPreview1.DrawContent = false;
            printPreview1.OrderLineColumnNo = getOrderColumnNo() + timePointNo;

            foreach (DataRow row in DTSource.Rows)
            {
                if (DataOperator.HospitalID == "FJSL" && row["NURSING_TYPE"].ToString() == "总结")
                {
                    row["NURSING_DESC"] = "";
                }
                if (Direction == "V")
                {
                    for (int i = 0; i < numberColumn.Count; i++)
                    {
                        int number = numberColumn[i];
                        if (number == 0)
                            number = 24;
                        int rowIndex=GetRowIndex(row["allout"].ToString());
                        printPreview1.DetailLines[rowIndex][MaxVerticalLevel - 1 + i].Value = row["canal" + number.ToString()].ToString();
                        DataRow[] tempRows = VerticalTable.Select("project_name = '"+row["allout"].ToString()+"' and project_attribute = '不固定行'");
                        if (tempRows.Length > 0)
                        {
                            if (tempRows[0]["attribute_value"].ToString() == "是")
                            {
                                printPreview1.DetailLines[rowIndex][MaxVerticalLevel - 2].Value = row["insignname"].ToString();
                            }
                        }
                    }

                    continue;
                }
                string Time1 = string.Empty;
                #region 如果需要在特护单上显示的特护信息均为空，则不画该行

                bool AllColumnsIsEmpty = false, BeyondNurseIsEmpty = false;
                foreach (string ColumnName in columnHead)
                {
                    if (ColumnName == "NURSING_DESC" || ColumnName.ToUpper() == "UNDERWRITE")
                    {
                        continue;
                    }
                    object Value = getValue(row, ColumnName);
                    if (Value != null)
                    {
                        if (Value.ToString().Length > 0)
                        {
                            BeyondNurseIsEmpty = true;
                            break;
                        }
                    }
                }
                if (BeyondNurseIsEmpty || getValue(row, "NURSING_DESC").ToString() != string.Empty)
                {
                    AllColumnsIsEmpty = true;
                }
                if (!AllColumnsIsEmpty)
                {
                    continue;
                }
                #endregion
                RowNo++;
                #region 省略重复日期
                if (SourceTable.Columns.Contains("TimePoint"))
                {
                    if (OldDate == DateTime.Parse(getValue(row, "TimePoint").ToString()).ToString("MM") + "/" + DateTime.Parse(getValue(row, "TimePoint").ToString()).ToString("dd"))
                    {
                        Date = string.Empty;
                    }
                    else
                    {
                        OldDate = DateTime.Parse(getValue(row, "TimePoint").ToString()).ToString("MM") + "/" + DateTime.Parse(getValue(row, "TimePoint").ToString()).ToString("dd");
                        Date = OldDate;
                    }
                    //Time = DateTime.Parse(getValue(row, "TimePoint").ToString()).ToShortTimeString();
                    Time = DateTime.Parse(getValue(row, "TimePoint").ToString()).ToString("HH:mm");
                }

                #endregion
                string nursingType = getValue(row, "NURSING_TYPE").ToString();
                if (nurseTemplate && nursingType.Equals("总结"))
                {
                    if (BeyondNurseIsEmpty)
                    {
                        object[] obj1 = new object[columnHead.Count + timePointNo];
                        if (timePointNo == 1)
                        {
                            obj1[0] = DateTime.Parse(getValue(row, "TimePoint").ToString()).ToString("yyyy-MM-dd HH:mm");
                        }
                        else if (timePointNo == 2)
                        {
                            obj1[0] = Date;
                            obj1[1] = Time;
                        }

                        for (int i = 0; i < columnHead.Count; i++)
                        {
                            if (columnHead[i] == "NURSING_DESC")
                            {
                                obj1[timePointNo + i] = "";
                            }
                            else
                            {
                                obj1[timePointNo + i] = getValue(row, columnHead[i]);
                            }
                        }
                        line = printPreview1.addDetailLine(0, obj1);
                        line.TimePoint = DateTime.Parse(getValue(row, "TimePoint").ToString());
                        line = printPreview1.addDetailLine("护理措施项目列模板格式", GetSpecialTemplate("护理措施项目列模板格式", Date, Time, row));
                        line.TimePoint = DateTime.Parse(getValue(row, "TimePoint").ToString());
                    }
                    else
                    {
                        line = printPreview1.addDetailLine("护理措施项目列模板格式", GetSpecialTemplate("护理措施项目列模板格式", Date, Time, row));
                        line.TimePoint = DateTime.Parse(getValue(row, "TimePoint").ToString());
                    }
                    continue;
                }
                if (SourceTable.Columns.Contains("InSignName") && summaryTemplate && (row["InSignName"].ToString().Contains("总结") || row["InSignName"].ToString().Contains("小结") || row["InSignName"].ToString().Contains("小时")))
                {
                    line = printPreview1.addDetailLine("总结列模板格式", GetSpecialTemplate("总结列模板格式", Date, Time, row));
                    SetTopLineStyle(line);
                    continue;
                }

                object[] obj = new object[columnHead.Count + timePointNo];
                if (timePointNo == 1)
                {
                    obj[0] = DateTime.Parse(getValue(row, "TimePoint").ToString()).ToString("yyyy-MM-dd HH:mm");
                }
                else if (timePointNo == 2)
                {
                    obj[0] = Date;
                    obj[1] = Time;
                }
                if (Direction == "纵向")
                {
                    addDetailLine(row, RowNo - 1, SourceTable.Rows.Count);
                }
                else
                {
                    int underWrite = -1;
                    for (int i = 0; i < columnHead.Count; i++)
                    {
                        obj[timePointNo + i] = getValue(row, columnHead[i]);
                        if (columnHead[i] == "UnderWrite")
                        {
                            underWrite = timePointNo + i;
                        }
                    }
                    line = printPreview1.addDetailLine(0, obj);
                    if (underWrite > -1)
                    {
                        line[underWrite].SingleLineAlignBottom = false;
                    }
                    line.TimePoint = DateTime.Parse(getValue(row, "TimePoint").ToString());
                    if (SourceTable.Columns.Contains("InSignName") && (row["InSignName"].ToString().Contains("总结") || row["InSignName"].ToString().Contains("小结") || row["InSignName"].ToString().Contains("小时")))
                    {
                        SetTopLineStyle(line);
                    }
                }
            }

            printPreview1.RefreshLines();
            printPreview1.Invalidate();
            setPage(printPreview1);
        }

        private int GetRowIndex(string itemName)
        {
            int arrayIndex=MainVerticalColumns.IndexOf(itemName);
            return arrayIndex - 1;
        }

        private bool GetOtherTable(ref DataTable care)
        {
            DataRow[] row = dtTreeView.Select("PROJECT_ATTRIBUTE = '绑定表单名称'");
            if (row.Length > 0 && row[0]["ATTRIBUTE_VALUE"].ToString() != "")
            {
                SmartReportBusinessComponent businessComponent = new SmartReportBusinessComponent(row[0]["ATTRIBUTE_VALUE"].ToString(), PatientRow.PATIENT_ID + PatientRow.VISIT_ID.ToString());
                care = businessComponent.GetData(dtp_StartTime.DateTime, dtp_EndTime.DateTime);
                return true;
            }
            return false;
        }
        /// <summary>
        /// 纵向列头，如果数据超过一页，每页都先加上列头
        /// </summary>
        /// <param name="count"></param>
        private void initDetailLines(int count)
        {
            int pageNo = count / (MainColumns.Count - (MaxVerticalLevel - 1));
            if (count % (MainColumns.Count - (MaxVerticalLevel - 1)) != 0)
	        {
                pageNo++;
	        }
            for (int i = 1; i < pageNo; i++)
            {
                int rowNo = 0;
                for (int j = 0; j < MainVerticalColumns.Count - 1; j++)
                {
                    printPreview1.addDetailLine(0, new object[] { ""});
                    PrintLine line = printPreview1.DetailLines[printPreview1.DetailLines.Count - 1];
                    for (int k = 0; k < 5; k++)
                    {
                        line[k] = printPreview1.DetailLines[rowNo % (MainVerticalColumns.Count - 1)][k].Copy();
                    }
                    rowNo++;
                }
            }
        }

        private void ClearDetailLine()
        {
            //移除超过一页后的记录
            for (int i = printPreview1.DetailLines.Count - 1;i >= MainVerticalColumns.Count - 1; i--)
            {
                printPreview1.DetailLines.Remove(printPreview1.DetailLines[i]);
            }

            //清空第一页的数据
            for (int j = 0; j < printPreview1.DetailLines.Count; j++)
            {
                for (int i = MaxVerticalLevel - 1; i < MainColumns.Count; i++)
                {
                    printPreview1.DetailLines[j][i].Value = "";
                }
            }

            //if (printPreview1.DetailLines.Count < columnHead.Count)
            //{
            //    for (int i = MaxVerticalLevel - 1; i < MainColumns.Count; i++)
            //    {
            //        printPreview1.HeadLines[printPreview1.HeadLines.Count - 1][i].Value = "";
            //    }
            //}
            detailHead.Clear();
        }

        private void addDetailLine(DataRow row,int rowNo,int count)
        {
            int pageNo = rowNo / (MainColumns.Count - (MaxVerticalLevel - 1));
            if (count % (MainColumns.Count - (MaxVerticalLevel - 1)) != 0)
            {
                pageNo++;
            }
            int columnNo = (rowNo % (MainColumns.Count - (MaxVerticalLevel - 1))) + (MaxVerticalLevel - 1);
            if (MainVerticalColumns.Count - 1 < columnHead.Count)
            {
                for (int i = (pageNo - 1) * (MainVerticalColumns.Count - 1); i < (MainVerticalColumns.Count - 1) * pageNo; i++)
                {
                    printPreview1.DetailLines[i][columnNo].Value = getValue(row, MainVerticalDataBind[((i % (MainVerticalColumns.Count - 1)) + 1) % MainVerticalDataBind.Count]);
                }
                //printPreview1.HeadLines[printPreview1.HeadLines.Count - 1][columnNo].Value = getValue(row, MainVerticalDataBind[0]);
                detailHead.Add(getValue(row, MainVerticalDataBind[0]).ToString());
            }
            else
            {
                for (int i = (pageNo - 1) * (MainVerticalColumns.Count - 1); i < (MainVerticalColumns.Count - 1) * pageNo; i++)
                {
                    printPreview1.DetailLines[i][columnNo].Value = getValue(row, MainVerticalDataBind[i % MainVerticalDataBind.Count]);
                }
            }
        }

        private DataTable getTestTable()
        {
            DataTable testTable = new DataTable();
            DataColumn first = new DataColumn("time");
            testTable.Columns.Add(first);
            DataColumn second = new DataColumn("a");
            testTable.Columns.Add(second);
            DataColumn three = new DataColumn("b");
            testTable.Columns.Add(three);
            DataColumn four = new DataColumn("c");
            testTable.Columns.Add(four);
            DataColumn five = new DataColumn("d");
            testTable.Columns.Add(five);
            DataColumn six = new DataColumn("e");
            testTable.Columns.Add(six);
            DataColumn seven = new DataColumn("f");
            testTable.Columns.Add(seven);
            DataColumn eit = new DataColumn("g");
            testTable.Columns.Add(eit);
            DataColumn nine = new DataColumn("h");
            testTable.Columns.Add(nine);
            DataColumn ten = new DataColumn("i");
            testTable.Columns.Add(ten);
            testTable.Rows.Add(new string[] { "2008", "1", "12", "13","14","15", "16","17","18","19"});
            testTable.Rows.Add(new string[] { "2009", "2", "22", "23","24", "25", "26", "27", "28", "29" });
            testTable.Rows.Add(new string[] { "2010", "3", "32", "33", "34", "35", "36", "37", "38", "39" });
            testTable.Rows.Add(new string[] { "2011", "4", "42", "43", "44", "45", "46", "47", "48", "49" });
            testTable.Rows.Add(new string[] { "2012", "5", "52", "53", "54", "55", "56", "57", "58", "59" });
            testTable.Rows.Add(new string[] { "2013", "6", "62", "63", "64", "65", "66", "67", "68", "69" });
            testTable.Rows.Add(new string[] { "2014", "7", "72", "73", "74", "75", "76", "77", "78", "79" });
            return testTable;
        }
        /// <summary>
        /// 设置上边线格式
        /// </summary>
        /// <param name="line"></param>
        private void SetTopLineStyle(PrintLine line)
        {
            if (GetAttributes(0, "列头", "总结粗体线").Trim() == "是")
            {
                line.DrawBoldTopLine = true;
                string colorResult = GetAttributes(0, "列头", "总结粗体线颜色");
                System.Drawing.Color color = System.Drawing.Color.Black;
                switch (colorResult)
                {
                    case "红色":
                        color = System.Drawing.Color.Red;
                        break;
                    case "黑色":
                        color = System.Drawing.Color.Black;
                        break;
                    case "蓝色":
                        color = System.Drawing.Color.Blue;
                        break;
                    case "绿色":
                        color = System.Drawing.Color.Green;
                        break;
                    case "白色":
                        color = System.Drawing.Color.White;
                        break;
                    case "灰色":
                        color = System.Drawing.Color.Gray;
                        break;
                    default:
                        break;
                }
                line.TopLinePen = new Pen(color,4);
            }
        }
        /// <summary>
        /// 根据方向获取节点配置
        /// </summary>
        /// <param name="table">保存目标表</param>
        /// <param name="name">方向（横向、纵向）</param>
        private void GetRowsByDirection(DataTable table, string name)
        {
            DataRow[] rows = dtTreeView.Select("PROJECT_ATTRIBUTE = '父节点' and ATTRIBUTE_VALUE = '" + name + "'", "START_INDEX ASC");
            foreach (DataRow row in rows)
            {
                DataRow[] projectRows = dtTreeView.Select("project_name = '" + row["project_name"] + "'");
                foreach (DataRow r in projectRows)
                {
                    table.Rows.Add(r.ItemArray);
                }
                GetRowsByDirection(table, row["project_name"].ToString());
            }
        }
        /// <summary>
        /// 获取最大层深
        /// </summary>
        private int GetMaxTagLevelByDirection(DataTable directionTable)
        {
            if (directionTable != null && directionTable.Rows.Count > 0)
            {
                return int.Parse(directionTable.Compute("max(project_level)", "").ToString());
            }
            return 1;
        }

        private object[] GetSpecialTemplate(string templateName,string Date,string Time,DataRow row)
        {
            object[] obj;
            object content = "",contentAndName = "";

            if (templateName == "护理措施项目列模板格式")
	        {
        		content = getValue(row, "NURSING_DESC");
                contentAndName = content + "★" + "\t\t\t\t\t\t\t\t\t\t\t\t值班护士：" + getValue(row, "UnderWrite");
	        }
            else
	        {
                string[] inName = getValue(row, "InSignName").ToString().Split(new char[]{'★'});
                string[] inValue = ("入量总量：" + getValue(row, "InSignValue").ToString()).Split(new char[] { '★' });
                string[] outName = getValue(row, "OutSignName").ToString().Split(new char[]{'★'});
                string[] outValue = getValue(row, "OutSignValue").ToString().Split(new char[]{'★'});
                for (int i = 0; i < inName.Length; i++)
	            {
            		content = content + inName[i] + "：" + inValue[i] + "，";
	            }
                for (int i = 0; i < outName.Length; i++)
	            {
            		content = content + outName[i] + "：" + outValue[i] + "，";
	            }
                content = content.ToString().Substring(0,content.ToString().Length - 1);
                contentAndName = content;
	        }
            if (printPreview1.ColumnModules[templateName].Count == 1)
	        {
        		obj = new object[1];
                obj[0] = contentAndName;
	        }
            else if (printPreview1.ColumnModules[templateName].Count == 2)
	        {
        		obj = new object[2];
                obj[0] = content;
                obj[1] = getValue(row, "UnderWrite");
	        }
            else if (printPreview1.ColumnModules[templateName].Count == 3)
	        {
        		obj = new object[3];
                obj[0] = Date;
                obj[1] = Time;
                obj[2] = contentAndName;
	        }
            else
            {
                obj = new object[4];
                obj[0] = Date;
                obj[1] = Time;
                obj[3] = content;
                obj[4] = getValue(row, "UnderWrite");
            }
            return obj;
        }
        /// <summary>
        /// 计算医嘱字符串所占行数
        /// </summary>
        /// <param name="strValue"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        private int ComputeLineNo(string strValue, int width)
        {
            int lineNo = 1;
            string[] strFont = GetAttributes(0, "列头", "字体").Split('&');
            Font font = new Font("宋体", 9);
            if (strFont.Length > 1)
            {
                font = AssemblyHelper.ConvertStringToFont(strFont[0], strFont[1]);
            }
            printPreview1.Font = font;
            float w = width + 5;
            float stringWidth = printerSettingGraphics.MeasureString(strValue, font).Width;
            while (stringWidth > w)
            {
                lineNo++;
                int i;
                for (i = 1; i < strValue.Length; i++)
                {
                    if (printerSettingGraphics.MeasureString(strValue.Substring(0, i), font).Width > w)
                    {
                        break;
                    }
                }
                strValue = strValue.Substring(i - 1);
                stringWidth = printerSettingGraphics.MeasureString(strValue, font).Width;
            }
            return lineNo;
        }

        public void RefreshCmbPages()
        {
            try
            {
                if (PatientRow != null)
                {
                    LastDatePrintPageNo = DataOperator.GetLastDatePrintPageNo(PatientRow.PATIENT_ID, PatientRow.VISIT_ID, PatientRow.DEP_ID);
                }
                this.Cursor = Cursors.WaitCursor;
                cmbPages.Properties.Items.Clear();
                PageCount = printPreview1.PageCount;
                if (PageCount > 0)
                {
                    for (int i = 1; i <= PageCount; i++)
                    {
                        cmbPages.Properties.Items.Add(string.Format("第{0}页", i));
                    }
                    cmbPages.Text = "第1页";
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        /// <summary>
        /// 切换当前页
        /// </summary>
        private void ChangePage()
        {
            if (PageIndex < printPreview1.PageCount)
            {
                printPreview1.GotoPage(PageIndex);
            }
            cmbPages.Text = string.Format("第{0}页", PageIndex + 1);
        }

        private object getValue(DataRow dataRow, string columnName)
        {
            try
            {
                if (columnName.StartsWith("D-"))
                {
                    columnName = columnName.Substring(2);
                    return DateTime.Parse(dataRow[columnName].ToString()).ToString("MM") + "/" + DateTime.Parse(dataRow[columnName].ToString()).ToString("dd");
                }
                else if (columnName.StartsWith("T-"))
                {
                    columnName = columnName.Substring(2);
                    return DateTime.Parse(dataRow[columnName].ToString()).ToShortTimeString();
                }
                else if (columnName.StartsWith("DT-"))
                {
                    return DateTime.Parse(dataRow[columnName].ToString()).ToString("yyyy-MM-dd HH:mm");
                }
                else if (columnName.Contains(","))
                {
                    string[] names = columnName.Split(new char[] { ',' });
                    if (dataRow[names[0]].ToString() != "" || dataRow[names[1]].ToString() != "")
                    {
                        return dataRow[names[0]].ToString() + "/" + dataRow[names[1]].ToString();
                    }
                }
                else if (columnName == "NURSING_DESC")
                {
                    DataRow[] rows = dtTreeView.Select("project_category = '护理措施项目' and project_attribute = '显示签名'");
                    if (rows.Length > 0)
                    {
                        int level = int.Parse(rows[0]["project_level"].ToString());
                        string proName = rows[0]["project_name"].ToString();
                        if (rows[0]["attribute_value"].ToString().Trim() == "是")
                        {
                            int width = int.Parse(GetAttributes(level, proName, "列宽"));
                            string nursingString = dataRow[columnName].ToString();
                            if (nursingString.Trim().Length <= 0)
                            {
                                return dataRow[columnName].ToString();
                            }
                            int lineNo1 = ComputeLineNo(nursingString, width);
                            int lineNo2 = ComputeLineNo(nursingString + "哈哈哈哈哈", width);
                            string underWriter = dataRow["UnderWrite"].ToString();
                            if (lineNo1 != lineNo2)
                            {
                                string text = "";
                                AppendString(ref text, underWriter, 1, width);
                                return nursingString + "★" + text;
                            }
                            else
                            {
                                AppendString(ref nursingString, underWriter, lineNo1, width);
                                return nursingString;
                            }
                        }
                        else
                        {
                            return dataRow[columnName].ToString();
                        }
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                else
                {
                    return dataRow[columnName];
                }
            }
            catch
            {
                return string.Empty;
            }
            return null;
        }

        private void AppendString(ref string text, string underWriter, int lineNo, int width)
        {
            int index = text.Length;
            text += underWriter;
            int lineNoAfter = ComputeLineNo(text, width);
            bool add = false;
            while (lineNoAfter <= lineNo)
            {
                text = text.Insert(index, " ");
                add = true;
                lineNoAfter = ComputeLineNo(text, width);
            }
            if (add)
            {
                text = text.Remove(index, 1);
            }
        }

        private string getBedNo()
        {
            if (!PatientRow.IsBED_NONull())
            {
                return PatientRow.BED_NO;
            }
            else
            {
                DataSetModel.CareDocs.TransferDataTable transfer = DataOperator.GetTransfer(PatientRow.PATIENT_ID, PatientRow.VISIT_ID);
                for (int rowNo = transfer.Rows.Count - 1; rowNo >= 0; rowNo--)
                {
                    if (DateTime.Parse(transfer.Rows[rowNo]["ADMISSION_DATE_TIME"].ToString()) <= StartDateTime)
                    {
                        if (transfer.Rows[rowNo]["BED_NO"] != null && !string.IsNullOrEmpty(transfer.Rows[rowNo]["BED_NO"].ToString()))
                            return transfer.Rows[rowNo]["BED_NO"].ToString();
                    }
                }
            }
            return "";
        }

        private object getValue(DataRow dataRow, string columnName1, string columnName2)
        {
            try
            {
                if (dataRow[columnName1].ToString() != "" || dataRow[columnName2].ToString() != "")
                {
                    return dataRow[columnName1].ToString() + "/" + dataRow[columnName2].ToString();
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        private void DrawString(Graphics g, Font font, Brush brush, string text, ref int x, int y, int width, int xMargin)
        {
            g.DrawString(text, font, brush, x + (width - g.MeasureString(text, font).Width) / 2, y);
            g.DrawLine(new Pen(brush), x, y + g.MeasureString("A", font).Height, x + width, y + g.MeasureString("A", font).Height);
            x += width + xMargin;
        }

        private void DrawString(Graphics g, Font font, Brush brush, string text, ref int x, int y, int width)
        {
            DrawString(g, font, brush, text, ref x, y, width, 0);
        }

        private void DrawString(Graphics g, Font font, Brush brush, string text, int xMargin, ref int x, int y)
        {
            g.DrawString(text, font, brush, x, y);
            x += (int)g.MeasureString(text, font).Width + xMargin;
        }

        private void DrawString(Graphics g, Font font, Brush brush, string text, ref int x, int y)
        {
            DrawString(g, font, brush, text, 0, ref x, y);
        }
                /// <summary>
        /// 获取科室名称
        /// </summary>
        private string GetDeptName()
        {
            string DeptName;
            DataSetModel.CareDocs.DeptDictDataTable deptDictTable;
            deptDictTable = DataOperator.GetDeptDict(DataOperator.WardCode);
            if ((deptDictTable != null) && (deptDictTable.Count > 0) && (!deptDictTable[0].IsDEPT_NAMENull()))
            {
                DeptName = deptDictTable[0].DEPT_NAME;
            }
            else
            {
                DeptName = "";
            }
            return DeptName;
        }

        protected override void SaveData()
        {

        }

        protected override void LoadData()
        {
            int count = 0;
            if (txtRemoveNo.Text.Length > 0 && !int.TryParse(txtRemoveNo.Text, out count))
            {
                if (count < 0)
                {
                    Sundries.MessageBox("输入数值必须大于等于零！");
                    return;
                }
            }
            //else
            //{
            //    Sundries.MessageBox("输入数值格式不对！");
            //    return;
            //}
            printPreview1.RemoveLineNo = count;
            try
            {
                getDesignControl();     //获取表单配置
                RefreshReport();
            }
            catch (Exception exception)
            {
                Log.Error(exception.ToString());
                Sundries.MessageBox(exception.Message, MessageBoxIcon.Error);
            }
            RefreshCmbPages();
        }

        #endregion

        #region 事件
        
        private void medButton1_Click_1(object sender, EventArgs e)
        {
            LoadData();
        }

        private int printPreview1_CustomDrawTitle(Graphics g, int leftOffSet, int topOffSet, int lineWidth, int pageNo, int pageCount)
        {
            SolidBrush bursh = new SolidBrush(Color.Black);
            foreach (DataSetModel.CareDocs.MED_DOCUMENT_DESIGN_DETAILRow row in detail.Rows)
            {
                if (row.CONTROL_TYPE == "DevExpress.XtraEditors.PanelControl")
                {
                    Pen pen = new Pen(AssemblyHelper.ColorFromString(row.BACKCOLOR));
                    if (row.HEIGHT < row.WIDTH)
                        g.DrawLine(pen, (int)row.LEFT + leftOffSet - 1, (int)row.TOP, (int)row.LEFT + leftOffSet - 1 + (int)row.WIDTH, (int)row.TOP);
                    else
                        g.DrawLine(pen, (int)row.LEFT + leftOffSet - 1, (int)row.TOP, (int)row.LEFT + leftOffSet - 1 + (int)row.WIDTH, (int)row.TOP + (int)row.HEIGHT);
                }
                else
                {
                    Font font = AssemblyHelper.ConvertStringToFont(row.FONT, row.FONT_STYLE);
                    if (row.BIND_FIELD_NAME == "PAGE_NO")
                    {
                        int page = int.Parse(row.TEXT) + pageNo + 1;
                        g.DrawString(page.ToString(), font, bursh, (int)row.LEFT, (int)row.TOP);
                    }
                    else if (row.BIND_FIELD_NAME == "BED_NO" && txtBedNo.Text.Trim() != "")
                    {
                        g.DrawString(txtBedNo.Text.Trim(), font, bursh, (int)row.LEFT + leftOffSet, (int)row.TOP);
                    }
                    else
                    {
                        g.DrawString(row.TEXT, font, bursh, (int)row.LEFT + leftOffSet, (int)row.TOP);
                    }
                }
            }

            if (main.DefaultView.Count > 0 && main.DefaultView[0]["MAIN_TOP"].ToString() != "")
            {
                if (cbxXuDa.Checked && notPrint)
                {
                    //画行号
                    int titleHeight = int.Parse(main.DefaultView[0]["MAIN_TOP"].ToString()) - 28;
                    Font font1 = new Font("宋体", 8);
                    int top = titleHeight + 13, totalWidth = 0;
                    for (int i = 0; i < printPreview1.HeadLines.Count; i++)
                    {
                        top += printPreview1.HeadLines[i].Height;
                    }
                    for (int i = 0; i < printPreview1.ColumnModules[0].Count; i++)
                    {
                        totalWidth += printPreview1.ColumnModules[0][i].Width;
                    }
                    for (int i = 1; i <= printPreview1.LineNumberPerPage; i++)
                    {
                        g.DrawString(i.ToString(), font1, bursh, leftOffSet - 15, top + (printPreview1.DefaultLineHeight * i));
                    }
                }

                return int.Parse(main.DefaultView[0]["MAIN_TOP"].ToString()) - 28;
            }
            if (detail.Count > 0)
            {
                return int.Parse(detail.Rows[detail.Count - 1]["TOP"].ToString()) + int.Parse(detail.Rows[detail.Count - 1]["HEIGHT"].ToString()) - 20;
            }
            else
            {
                return topOffSet;
            }
        }

        public void setPage(MedPrintPreview print)
        {
            cmbPages.Properties.Items.Clear();
            for (int i = 1; i <= print.PageCount; i++)
            {
                cmbPages.Properties.Items.Add(string.Format("第{0}页", i));
            }
            cmbPages.Text = string.Format("第{0}页", print.PageIndex + 1);
            PageCount = print.PageCount;
        }

        private void btnSetPageNo_Click(object sender, EventArgs e)
        {
            object Result = Sundries.SingleInputSelect("最后一次打印页码", DataOperator.GetLastDatePrintPageNo(PatientRow.PATIENT_ID, PatientRow.VISIT_ID, PatientRow.DEP_ID));
            if (Result == null)
            {
                return;
            }
            else
            {
                if (Regex.IsMatch(Result.ToString(), @"^\d+$"))
                {
                    DataOperator.SetLastDatePrintPageNo(PatientRow.PATIENT_ID, PatientRow.VISIT_ID,PatientRow.DEP_ID, int.Parse(Result.ToString()));
                }
                else
                {
                    Sundries.MessageBox("打印页码请输入整数!");
                }
            }
        }

        private void btnPrintCurrentPage_Click(object sender, EventArgs e)
        {
            if (cbxXuDa.Checked)
            {
                printPreview1.DrawAllCell = false;
                printPreview1.DrawFoot = false;
            }
            else
            {
                printPreview1.DrawAllCell = true;
            }
            setStartPrintRowNo();
            notPrint = false;
            printPreview1.PrintCurrentPage = true;
            printPreview1.Print();
            txtRemoveNo.Text = "";
            txtStartRowNo.Text = "";
        }

        private void cmbPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PageIndex != cmbPages.SelectedIndex)
            {
                PageIndex = cmbPages.SelectedIndex;
                ChangePage();
            }
        }

        private void setStartPrintRowNo()
        {
            int no;
            if (txtStartRowNo.Text.Trim() != "")
            {
                if (int.TryParse(txtStartRowNo.Text, out no))
                {
                    printPreview1.UpRowNo = no;
                }
                else
                {
                    Sundries.MessageBox("输入字符必须为数字！");
                }
            }
            else
            {
                printPreview1.UpRowNo = -1;
            }
        }

        private void medButton3_Click(object sender, EventArgs e)
        {
            if (cbxXuDa.Checked)
            {
                printPreview1.DrawAllCell = false;
                printPreview1.DrawFoot = false;
                xuDaLineNo();
            }
            else
            {
                printPreview1.DrawAllCell = true;
            }
            printPreview1.PrintType = PrintTypeEnum.All;
            notPrint = false;
            setStartPrintRowNo();
            MedPrintPreview.ShowInOnePage = false;
            int count = 0;
            printPreview1.NoPrintTotal = cbxNoPrintTotal.Checked;
            printPreview1.Print();
            count = printPreview1.fullPageCount();
            DataOperator.SetLastDatePrintPageNo(PatientRow.PATIENT_ID, PatientRow.VISIT_ID,PatientRow.DEP_ID, lastDatePrintPageNo + count);
            txtRemoveNo.Text = "";
            txtStartRowNo.Text = "";
        }
        //福建省立医院续打要记录倒数第二页最后一个时间点，和下次续打从第几行开始打印
        private void xuDaLineNo()
        {
            DataSetModel.CareDocs.MED_PAGE_XUDA_FJSLDataTable xuDa = DataOperator.GetPageXuDa();
            DataSetModel.CareDocs.MED_PAGE_XUDA_FJSLRow row = xuDa.NewMED_PAGE_XUDA_FJSLRow();
            int nextSatrtNo = 0,removeNo = 0;
            DateTime nextSatrtTime = DateTime.Now;
            if (printPreview1.PageCount > 1)
            {
                for (int i = printPreview1.DetailLines.Count - 1; i >= 0; i--)
                {
                    if (printPreview1.DetailLines[i][0].StartTotalCount == 0)
                    {
                        removeNo = 0;
                        nextSatrtNo = printPreview1.DetailLines[printPreview1.DetailLines.Count - 1][0].StartTotalCount + printPreview1.DetailLines[printPreview1.DetailLines.Count - 1].LineNumber + 1;
                        nextSatrtTime = printPreview1.DetailLines[i].TimePoint;
                        break;
                    }
                    else if (printPreview1.DetailLines[i][0].StartTotalCount + printPreview1.DetailLines[i].LineNumber > printPreview1.LineNumberPerPage)
                    {
                        nextSatrtTime = printPreview1.DetailLines[i].TimePoint;
                        removeNo = printPreview1.LineNumberPerPage - printPreview1.DetailLines[i][0].StartTotalCount;
                        nextSatrtNo = printPreview1.DetailLines[printPreview1.DetailLines.Count - 1][0].StartTotalCount + printPreview1.DetailLines[printPreview1.DetailLines.Count - 1].LineNumber + 1;
                        break;
                    }
                }
            }
            else
            {
                nextSatrtTime = printPreview1.DetailLines[0].TimePoint;
                if (!row.IsREMOVE_NONull())
	            {
                    removeNo = (int)row.REMOVE_NO;
	            }
                else
                {
                    removeNo = 0;
                }
                nextSatrtNo = printPreview1.DetailLines[printPreview1.DetailLines.Count - 1][0].StartTotalCount + printPreview1.DetailLines[printPreview1.DetailLines.Count - 1].LineNumber + 1;
            }
            row.REMOVE_NO = removeNo;
            row.PATIENT_ID = PatientRow.PATIENT_ID;
            row.VISIT_ID = PatientRow.VISIT_ID;
            row.START_NO = nextSatrtNo;
            row.START_TIME = nextSatrtTime;
            if (xuDa.Count > 0)
            {
                xuDa.Rows[0].Delete();
            }
            xuDa.AddMED_PAGE_XUDA_FJSLRow(row);
            DataOperator.UpdatePageXuDa(xuDa);
        }

        private int printPreview1_CustomDrawFoot(Graphics g, int leftOffSet, int topOffSet, int lineWidth, int pageNo, int pageCount)
        {
            return topOffSet;
        }

        private void cmbPages_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (PageIndex != cmbPages.SelectedIndex)
            {
                PageIndex = cmbPages.SelectedIndex;
                ChangePage();
            }
        }

        private string getItemValue(string itemName)
        {
            switch (itemName)
            {
                case "NAME":
                    return PatientRow.NAME;
                case "SEX":
                    return PatientRow.SEX;
                case "AGE":
                    if (!PatientRow.IsDATE_OF_BIRTHNull())
                    {
                        int year = DateTime.Now.Year - PatientRow.DATE_OF_BIRTH.Year;
                        if (year >= 2)
                        {
                            return year.ToString();
                        }
                    }
                    return "";
                case "BED_NO":
                    if (!PatientRow.IsBED_LABELNull())
                    {
                        return PatientRow.BED_NO;
                    }
                    else
                    {
                        DataSetModel.CareDocs.TransferDataTable transfer = DataOperator.GetTransfer(PatientRow.PATIENT_ID, PatientRow.VISIT_ID);
                        for (int rowNo = transfer.Rows.Count - 1; rowNo >= 0; rowNo--)
                        {
                            if (DateTime.Parse(transfer.Rows[rowNo]["ADMISSION_DATE_TIME"].ToString()) <= StartDateTime)
                            {
                                if (transfer.Rows[rowNo]["BED_NO"] != null && !string.IsNullOrEmpty(transfer.Rows[rowNo]["BED_NO"].ToString()))
                                    return transfer.Rows[rowNo]["BED_NO"].ToString();
                            }
                        }
                        return "";
                    }
                case "WARD_CODE":
                    DataSetModel.CareDocs.DeptDictDataTable deptDictTable1 = DataOperator.GetDeptDict(DataOperator.WardCode);
                    if ((deptDictTable1 != null) && (deptDictTable1.Count > 0) && (!deptDictTable1[0].IsDEPT_NAMENull()))
                    {
                        return deptDictTable1[0].DEPT_NAME;
                    }
                    else
                    {
                        return "";
                    }
                case "DEPT_TO":
                    DataSetModel.CareDocs.DeptDictDataTable deptDictTable;
                    string deptCode = "";
                    if (!PatientRow.IsBED_NONull())
                    {
                        DataSetModel.Patient.PatsInHospitalDataTable patsTable;
                        patsTable = DataOperator.GetPatInfo(DataOperator.WardCode, PatientRow.PATIENT_ID, (int)PatientRow.VISIT_ID, PatientRow.DEP_ID);
                        if (patsTable.Rows.Count > 0)
                        {
                            deptDictTable = DataOperator.GetDeptDict(patsTable.Rows[0]["RESERVED02"].ToString());
                            if ((deptDictTable != null) && (deptDictTable.Count > 0) && (!deptDictTable[0].IsDEPT_NAMENull()))
                            {
                                return deptDictTable[0].DEPT_NAME;
                            }
                            else
                            {
                                return "";
                            }
                        }
                    }
                    else
                    {
                        DataSetModel.CareDocs.TransferDataTable transfer = DataOperator.GetTransfer(PatientRow.PATIENT_ID, (int)PatientRow.VISIT_ID);
                        if (transfer.Rows.Count > 0)
                        {
                            for (int rowNo = transfer.Rows.Count - 1; rowNo >= 0; rowNo--)
                            {
                                if (DateTime.Parse(transfer.Rows[rowNo]["ADMISSION_DATE_TIME"].ToString()) <= StartDateTime)
                                {
                                    if (transfer.Rows[rowNo]["DEPT_STAYED"] != null && !string.IsNullOrEmpty(transfer.Rows[rowNo]["DEPT_STAYED"].ToString()))
                                        deptCode = transfer.Rows[rowNo]["DEPT_STAYED"].ToString();
                                }
                            }
                            deptDictTable = DataOperator.GetDeptDict(transfer.Rows[0]["DEPT_STAYED"].ToString());
                            if ((deptDictTable != null) && (deptDictTable.Count > 0) && (!deptDictTable[0].IsDEPT_NAMENull()))
                            {
                                return deptDictTable[0].DEPT_NAME;
                            }
                            else
                            {
                                return "";
                            }
                        }
                    }
                    return "";
                case "PATIENT_ID":
                    return PatientRow.PATIENT_ID;
                case "INP_NO":
                    return PatientRow.INP_NO;
                case "WEIGHT":
                    if (!PatientRow.IsBODY_WEIGHTNull())
                    {
                        return PatientRow.BODY_WEIGHT.ToString();
                    }
                    return "";
                case "DIAGNOSE":
                    return PatientRow.DIAGNOSIS;
                case "TIME":
                    return dtp_StartTime.DateTime.ToShortDateString();
                case "TRANFER_DATE":
                    DataSetModel.CareDocs.TransferDataTable transfer2 = DataOperator.GetTransfer(PatientRow.PATIENT_ID, PatientRow.VISIT_ID);
                    for (int rowNo = transfer2.Rows.Count - 1; rowNo >= 0; rowNo--)
                    {
                        if (DateTime.Parse(transfer2.Rows[rowNo]["ADMISSION_DATE_TIME"].ToString()) <= StartDateTime)
                        {
                            if (transfer2.Rows[rowNo]["ADMISSION_DATE_TIME"] != null && !string.IsNullOrEmpty(transfer2.Rows[rowNo]["ADMISSION_DATE_TIME"].ToString()))
                                return DateTime.Parse(transfer2.Rows[rowNo]["ADMISSION_DATE_TIME"].ToString()).ToShortDateString();
                        }
                    }
                    return "";
                case "DAYS_AFTER_OPERATION":
                    if (!PatientRow.IsOPERATING_DATENull())
                    {
                        double days = ((TimeSpan)(dtp_StartTime.DateTime - PatientRow.OPERATING_DATE)).TotalDays;
                        return ((int)days).ToString();
                    }
                    return "";
                case "ALERGY_DRUGS":
                    return PatientRow.ALERGY_DRUGS;
                case "PAGE_NO":
                    return DataOperator.GetLastDatePrintPageNo(PatientRow.PATIENT_ID, (int)PatientRow.VISIT_ID, PatientRow.DEP_ID).ToString();
            }
            return "";
        }

        private void SpecialCareCommon_Load(object sender, EventArgs e)
        {
            
        }

        protected override void LoadDataOnce()
        {
            initPrintControl();
            RefreshCmbPages();
        }

        private int printPreview1_CustomDrawPageHead(Graphics g, int leftOffSet, int topOffSet, int lineWidth, int pageNo, int pageCount)
        {
            int iHeadLineHeight = 0;
            int endIndex = MaxHorizontalLevel;
            if (VerticalTable.Rows.Count > 0)
            {
                endIndex--;
            }

            if (CustomArray.Count > 0)
            {
                foreach (KeyValuePair<string, string> obj in CustomArray)
                {
                    int Index = 0;
                    foreach (KeyValuePair<string, int> keyvalue in MainColumns)
                    {
                        if (keyvalue.Key.ToString() != obj.Key.ToString())
                        {
                            Index++;
                        }
                        else
                            break;
                    }
                    int leftX = printPreview1.ColumnModules[0].GetColumnLeft(Index) + leftOffSet;
                    int rightX = leftX + (int)MainColumns[obj.Key.ToString()];
                    int leftY = 0;
                    int rightY = topOffSet;
                    int CellLevel = int.Parse(GetAttributes(0, obj.Key.ToString(), "Level"));
                    if (VerticalTable.Rows.Count > 0)
                    {
                        CellLevel--;
                    }

                    for (int i = 0; i < CellLevel - 1; i++)
                    {
                        rightY += printPreview1.HeadLines[i].Height;
                    }
                    leftY = rightY;

                    for (int i = CellLevel - 1; i < endIndex; i++)
                    {
                        leftY += printPreview1.HeadLines[i].Height;
                    }
                    //画列头的斜线
                    Pen p = new Pen(Color.Black, 1);
                    if (obj.Value == "右斜线")
                    {
                        g.DrawLine(p, new Point(leftX, leftY), new Point(rightX, rightY));
                    }
                    else if (obj.Value == "左斜线")
                    {
                        g.DrawLine(p, new Point(leftX, rightY), new Point(rightX, leftY));
                    }
                }
            }

            //画表格边框粗线
            string strWidth = GetAttributes(0, "列头", "边框线宽度");
            int Width = 1;
            if (int.TryParse(strWidth, out Width))
            {
                if (Width > 1)
                {
                    iHeadLineHeight = 0;
                    for (int i = 0; i < endIndex; i++)
                    {
                        iHeadLineHeight += printPreview1.HeadLines[i].Height;
                    }
                    Pen p1 = new Pen(new SolidBrush(Color.Black), Width);
                    int iTopLeftX = printPreview1.ColumnModules[0].GetColumnLeft(MainColumns.Count) + leftOffSet;
                    int iBottomLeftY = iHeadLineHeight + printPreview1.DefaultLineHeight * printPreview1.LineNumberPerPage + topOffSet;
                    g.DrawLine(p1, new Point(leftOffSet, topOffSet), new Point(iTopLeftX, topOffSet));
                    g.DrawLine(p1, new Point(leftOffSet, topOffSet), new Point(leftOffSet, iBottomLeftY));
                    g.DrawLine(p1, new Point(iTopLeftX, topOffSet), new Point(iTopLeftX, iBottomLeftY));
                    g.DrawLine(p1, new Point(leftOffSet, iBottomLeftY), new Point(iTopLeftX, iBottomLeftY));
                }
            }

            //纵向的更新列头数据
            if (Direction == "纵向")
            {
                Rectangle rect;
                for (int i = MaxVerticalLevel - 1; i < MainColumns.Count; i++)
                {
                    rect = new Rectangle(leftOffSet + printPreview1.HeadLines[printPreview1.HeadLines.Count - 1][i].Rect.Left, topOffSet + printPreview1.HeadLines[printPreview1.HeadLines.Count - 1][i].Rect.Top, printPreview1.HeadLines[printPreview1.HeadLines.Count - 1][i].Rect.Width, printPreview1.HeadLines[printPreview1.HeadLines.Count - 1][i].Rect.Height);
                    if (pageNo * (MainColumns.Count - (MaxVerticalLevel - 1)) + i - (MaxVerticalLevel - 1) < detailHead.Count)
                    {
                        g.FillRectangle(Brushes.White, rect);
                        g.DrawRectangle(Pens.Black, rect);
                        printPreview1.HeadLines[printPreview1.HeadLines.Count - 1][i].DrawString(g, detailHead[pageNo * (MainColumns.Count - (MaxVerticalLevel - 1)) + i - (MaxVerticalLevel - 1)].ToString(), rect);
                    }
                    else
                    {
                        g.FillRectangle(Brushes.White, rect);
                        g.DrawRectangle(Pens.Black, rect);
                    }
                }
            }
            DrawCustom(g, leftOffSet, topOffSet, lineWidth, pageNo, pageCount);
            return 0;
        }

        public virtual void DrawCustom(Graphics g, int leftOffSet, int topOffSet, int lineWidth, int pageNo, int pageCount)
        {

        }

        private void btnColumnConfig_Click(object sender, EventArgs e)
        {
            FrmItemConfig.patientID = PatientID;
            FrmItemConfig.visitID = VisitID;
            FrmItemConfig.depID = DepID;
            FrmItemConfig.columnHead = customColumnHead;
            FrmItemConfig.UserDefineColumn = userDefineColumn;
            FrmItemConfig.projectName = Title;
            FrmItemConfig con = new FrmItemConfig();
            con.ShowDialog();
        }

        private void btnModifyTotal_Click(object sender, EventArgs e)
        {
            string[] splitString = Currentcell.Value.ToString().Split('★');

            Currentcell.Value = medTextBox1.Text;
            Currentcell.setStringValue(medTextBox1.Text, 0);

            for (int i = 1; i < splitString.Length; i++)
            {
                Currentcell.setStringValue(splitString[i], i);
                Currentcell.Value = Currentcell.Value + "★" + splitString[i];
            }
            panel1.Visible = false;
        }

        private void printPreview1_CellDoubleClick(PrintCell cell, object sender, EventArgs e)
        {
            if (cell.Value != null && (cell.Value.ToString().Contains("总结") || cell.Value.ToString().Contains("小结") || cell.Value.ToString().Contains("小时")))
            {
                Currentcell = cell;
                panel1.Visible = true;
                if (cell.Value.ToString().Contains("★"))
                {
                    string[] splitString = cell.Value.ToString().Split('★');
                    medTextBox1.Text = splitString[0];
                }
                else
                {
                    medTextBox1.Text = cell.Value.ToString();
                }
                medTextBox1.Focus();
                return;
            }
        }

        private void medButton4_Click(object sender, EventArgs e)
        {
            if (PageIndex >= PageCount - 1)
            {
                PageIndex = 0;
            }
            else
            {
                PageIndex++;
            }
            ChangePage();
        }

        private void medButton2_Click(object sender, EventArgs e)
        {
            if (PageIndex > 0)
            {
                PageIndex--;
            }
            else
            {
                PageIndex = PageCount;
            }
            ChangePage();
        }

        #endregion

        private void btnSaveBedNo_Click(object sender, EventArgs e)
        {
            panelBed.Visible = false;
        }

        private void btnModifyBedNo_Click(object sender, EventArgs e)
        {
            panelBed.Visible = true;
        }

        private void btnPageReflash_Click(object sender, EventArgs e)
        {
            MedicalSystem.Icu.DataSetModel.CareDocs.MED_PAGE_XUDA_FJSLDataTable xuDa = DataOperator.GetPageXuDa();
            if (xuDa.Count > 0)
            {
                MedicalSystem.Icu.DataSetModel.CareDocs.MED_PAGE_XUDA_FJSLRow row = (DataSetModel.CareDocs.MED_PAGE_XUDA_FJSLRow)xuDa.Rows[0];
                dtp_StartTime.DateTime = row.START_TIME;
                txtRemoveNo.Text = row.REMOVE_NO.ToString();
                txtStartRowNo.Text = row.START_NO.ToString();
            }
            int count = 0;
            try
            {
                if (txtRemoveNo.Text.Length > 0 && !int.TryParse(txtRemoveNo.Text, out count))
                {
                    Com.MedicalSystem.Common.Utilities.Sundries.MessageBox("输入数值必须大于等于零！");
                    return;
                }
            }
            catch (Exception)
            {
                Com.MedicalSystem.Common.Utilities.Sundries.MessageBox("输入数值格式不对！");
                return;
            }
            printPreview1.RemoveLineNo = count;

            getDesignControl();     //获取表单配置
            RefreshReport();
        }
    }
}
