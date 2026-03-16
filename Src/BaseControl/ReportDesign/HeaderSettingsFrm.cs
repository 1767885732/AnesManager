using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Com.MedicalSystem.Common.Controls;
using Com.MedicalSystem.Common.Utilities;
using System.Text.RegularExpressions;
using Com.MedicalSystem.Common.Con;
using System.Threading;

namespace Com.ICIS.Icu
{
    public partial class HeaderSettingsFrm : DevExpress.XtraEditors.XtraForm
    {
        #region 字段
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
        /// 配置单的名称
        /// </summary>
        private string strDocsName = "";
        /// <summary>
        /// 默认横向列模板字典
        /// </summary>
        private Dictionary<string, int> MainColumns = new Dictionary<string, int>();
        /// <summary>
        /// 默认竖向列模板
        /// </summary>
        private ArrayList MainVerticalColumns = new ArrayList();
        /// <summary>
        /// HeadLine显示文本
        /// </summary>
        private ArrayList array = new ArrayList();
        /// <summary>
        /// HeadLine名称
        /// </summary>
        private ArrayList arrayName = new ArrayList();
        /// <summary>
        /// 列模板数
        /// </summary>
        private int HeaderRowCount = 0;
        /// <summary>
        /// 数据库中保存的树
        /// </summary>
        private DataSetModel.CareDocs.MED_SPECIALCARE_CONFIGDataTable dtTreeView;
        /// <summary>
        /// 界面中显示属性值
        /// </summary>
        private DataTable dtAttribute = new DataTable("Attribute");
        /// <summary>
        /// 自动生成项目编号
        /// </summary>
        private int ItemIndex = 1;
        /// <summary>
        /// TreeView最大横向深度
        /// </summary>
        private int MaxHorizontalLevel = 1;
        /// <summary>
        /// TreeView最大纵向深度
        /// </summary>
        private int MaxVerticalLevel = 1;
        /// <summary>
        /// 科室代码
        /// </summary>
        private string strWardCode = DataOperator.WardCode;
        /// <summary>
        /// 画列头
        /// </summary>
        private Com.MedicalSystem.Common.Controls.MedPrintPreview medPrintPreview1 = new MedPrintPreview();
        /// <summary>
        /// GridView中的下拉框
        /// </summary>
        private List<DevExpress.XtraEditors.ComboBoxEdit> combxList = new List<DevExpress.XtraEditors.ComboBoxEdit>();
        /// <summary>
        /// 需要画斜线的列
        /// </summary>
        private Dictionary<string, string> CustomArray = new Dictionary<string, string>();
        /// <summary>
        /// 编辑控件
        /// </summary>
        DataGridViewTextBoxEditingControl editControl;
        /// <summary>
        /// 当前GridView中的旧值
        /// </summary>
        private string oldValue = string.Empty;
        /// <summary>
        /// 竖向显示列头表
        /// </summary>
        private DataTable VerticalTable;
        /// <summary>
        /// 横向显示列头表
        /// </summary>
        private DataTable HorizontalTable;
        /// <summary>
        /// 打印行
        /// </summary>
        private PrintLine line = null;
        #endregion

        #region 构造方法

        public HeaderSettingsFrm()
        {
            InitializeComponent();
        }

        public HeaderSettingsFrm(Com.MedicalSystem.Common.Controls.MedPrintPreview print)
        {
            medPrintPreview1 = print;
            medPrintPreview1.CustomDrawPageHead += new MedPrintPreview.PrintPreviewCustomDrawEvent(medPrintPreview1_CustomDrawPageHead);
            InitializeComponent();
        }

        public HeaderSettingsFrm(string DocsName, Com.MedicalSystem.Common.Controls.MedPrintPreview print)
        {
            medPrintPreview1 = print;
            medPrintPreview1.CustomDrawPageHead += new MedPrintPreview.PrintPreviewCustomDrawEvent(medPrintPreview1_CustomDrawPageHead);
            strDocsName = DocsName;
            InitializeComponent();
        }

        #endregion

        #region 方法

        /// <summary>
        /// 刷新预览界面
        /// </summary>
        private void RefreshPreview()
        {
            medPrintPreview1.HeadLines.Clear();
            medPrintPreview1.DetailLines.Clear();
            array.Clear();
            CustomArray.Clear();
            arrayName.Clear();
            MainColumns.Clear();
            MainVerticalColumns.Clear();
            medPrintPreview1.ColumnModules.Clear();
            if (HorizontalTable != null)
            {
                HorizontalTable.Rows.Clear();
            }
            if (VerticalTable != null)
            {
                VerticalTable.Rows.Clear();
            }
            line = null;
            string direction = GetAttributes(0, "列头", "列头位置");

            if (direction == "横向")
            {
                MaxHorizontalLevel = GetMaxTagLevelByDirection(dtTreeView);
                GenerateHeaders(treeViewHeader.Nodes, dtTreeView, direction, true);
            }
            else if (direction == "纵向")
            {
                TreeNode nodeH = FindTreeNodeByText(treeViewHeader.Nodes, "横向");
                if (nodeH == null)//没有指定横向列头时
                {
                    MaxHorizontalLevel = GetMaxTagLevelByDirection(dtTreeView);
                    GenerateHeaders(treeViewHeader.Nodes, dtTreeView, direction, true);
                }
                else//出现横向列头时
                {
                    TreeNode nodeV = FindTreeNodeByText(treeViewHeader.Nodes, "纵向");
                    if (nodeV != null)//画纵向列头
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
                            GenerateHeaders(treeViewHeader.Nodes, HorizontalTable, direction, true);

                            //画竖向列头
                            GenerateHeaders(treeViewHeader.Nodes, HorizontalTable, direction, false);
                        }
                        else
                        {
                            GenerateHeaders(treeViewHeader.Nodes, HorizontalTable, direction, true);
                        }
                    }
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
        private void GenerateHeaders(TreeNodeCollection drawNodes, DataTable table, string direction, bool drawDirection)
        {
            int rowNumber = 0;
            if (drawDirection)//画横向列头
            {
                if (drawNodes == null)
                {
                    return;
                }
                HeaderRowCount = 0;

                //if (DataTableToPrintPreview())
                if (TreeToTable(drawNodes))
                {
                    RefreshTag(treeViewHeader.Nodes[0].Nodes);
                    if ((direction == "纵向") && VerticalTable.Rows.Count > 0)
                    {
                        medPrintPreview1.LineNumberPerPage = MainVerticalColumns.Count - 1;
                        //PrintCell.LineNumberOfPage = medPrintPreview1.LineNumberPerPage;
                    }
                    else if (direction == "横向" || VerticalTable.Rows.Count <= 0)
                    {
                        string strLineNumberPerPage = GetAttributes(0, "列头", "每页行数");
                        if (strLineNumberPerPage.Trim() != "")
                        {
                            medPrintPreview1.LineNumberPerPage = int.Parse(strLineNumberPerPage);
                        }
                    }
                    string strDefaultLineHeight = GetAttributes(0, "列头", "默认行高");
                    if (strDefaultLineHeight.Trim() != "")
                    {
                        medPrintPreview1.DefaultLineHeight = int.Parse(strDefaultLineHeight);
                    }

                    medPrintPreview1.ColumnModules.Add("columnModuleMain", new PrintColumnModule(MainColumns));

                    DrawOtherHeaders(table, direction);

                    line = medPrintPreview1.addHeadLine("columnModuleMain", array.ToArray());

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
                        TreeNode node = FindTreeNodeByText(treeViewHeader.Nodes, arrayName[i].ToString());
                        if (i >= MaxVerticalLevel - 1)
                        {
                            line[i].RowSpan = MaxHorizontalLevel - node.Level + 1; strFont = GetAttributes(node.Level, node.Name, "字体").Split('&');
                            //line[i].RowSpan = MaxLevel - int.Parse(GetAttributes(0, arrayName[i].ToString(), "Level")) + 1;
                        }
                        else
                        {
                            line[i].RowSpan = MaxHorizontalLevel - 1;
                        }
                        if (strFont.Length > 1)
                        {
                            line[i].Font = AssemblyHelper.ConvertStringToFont(strFont[0], strFont[1]);
                        }
                        line[i].TextAlign = ConvertContentAlignment(GetAttributes(node.Level, node.Name, "对齐方式"));
                    }
                    #endregion

                    medPrintPreview1.addDetailLine(0, new object[] { "" });
                    if (direction == "纵向" && VerticalTable.Rows.Count > 0)
                    {
                        string strNumber = GetAttributes(0, "列头", "行数");

                        if (int.TryParse(GetAttributes(0, "列头", "行数"), out rowNumber))
                        {
                            for (int i = 0; i < rowNumber - 1; i++)
                            {
                                medPrintPreview1.addDetailLine(0, new object[] { "" });
                            }
                        }
                        else
                        {
                            for (int i = 0; i < MainVerticalColumns.Count - 1; i++)
                            {
                                medPrintPreview1.addDetailLine(0, new object[] { "" });
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
                        if (startIndex > 0)//为第一个节点的项目
                        {
                            if (row["end_index"] != null && row["end_index"].ToString().Trim() != "")//不是最下面的子节点
                            {
                                int endIndex = 0;
                                if (int.TryParse(row["end_index"].ToString(), out endIndex))
                                {
                                    medPrintPreview1.DetailLines[endIndex - 1][i - 2].RowSpan = endIndex - startIndex + 1;
                                    medPrintPreview1.DetailLines[endIndex - 1][i - 2].Value = row["attribute_value"].ToString().Replace("\\", "\n");
                                    medPrintPreview1.DetailLines[endIndex - 1][i - 2].TextAlign = ContentAlignment.MiddleCenter;
                                }
                            }
                            else
                            {
                                medPrintPreview1.DetailLines[startIndex - 1][MaxVerticalLevel - 2].ColumnsSpan = MaxVerticalLevel - i + 1;
                                medPrintPreview1.DetailLines[startIndex - 1][MaxVerticalLevel - 2].Value = row["attribute_value"].ToString().Replace("\\", "\n");
                                medPrintPreview1.DetailLines[startIndex - 1][MaxVerticalLevel - 2].TextAlign = ContentAlignment.MiddleCenter;
                                int width = 0;
                                for (int k = 0; k < medPrintPreview1.DetailLines[startIndex - 1][MaxVerticalLevel - 2].ColumnsSpan; k++)
                                {
                                    width = width + medPrintPreview1.DetailLines[startIndex - 1][MaxVerticalLevel - 2 - k].Rect.Width;
                                    if (k > 0)
                                    {
                                        medPrintPreview1.DetailLines[startIndex - 1][MaxVerticalLevel - 2 - k].Value = "";
                                    }
                                }
                                //if (startIndex != 2)//不为2是指不是纵向列头中最上面节点
                                //{
                                    medPrintPreview1.DetailLines[startIndex - 1][MaxVerticalLevel - 2].Rect = new Rectangle(
                                        medPrintPreview1.DetailLines[startIndex - 1][MaxVerticalLevel - 2].Rect.X, medPrintPreview1.DetailLines[startIndex - 1][MaxVerticalLevel - 2].Rect.Y, width, medPrintPreview1.DetailLines[startIndex - 1][MaxVerticalLevel - 2].Rect.Height);
                                //}
                            }
                        }
                        else
                        {
                            int itemLevel=int.Parse(row["project_level"].ToString());
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
            medPrintPreview1.RefreshLines();
            medPrintPreview1.Invalidate();
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
                    medPrintPreview1.ColumnModules.Add(projectName + "列模板格式", new PrintColumnModule(MainColumns, intArray.ToArray(), stringArray.ToArray()));
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
        /// 根据TreeView画表格
        /// </summary>
        /// <param name="nodes">列头的子节点</param>
        /// <returns></returns>
        private bool TreeToTable(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Parent != null && node.Name != "纵向" && node.Name != "横向" && node.Nodes.Count <= 0)
                {
                    if (node.FullPath.Contains("\\纵向") && VerticalTable.Rows.Count > 0)
                    {
                        if (!MainVerticalColumns.Contains(node.Name))
                        {
                            MainVerticalColumns.Add(node.Name);
                            node.Tag = MainVerticalColumns.Count - 1;
                        }
                        else
                        {
                            Sundries.MessageBox("已经包含相同竖向的列！");
                            return false;
                        }
                    }
                    else
                    {
                        if (!MainColumns.ContainsKey(node.Name))
                        {
                            MainColumns.Add(node.Name, int.Parse(GetAttributes(node.Level, node.Name, "列宽")));
                            string customLine = GetAttributes(node.Level, node.Name, "斜线");
                            if (customLine.Trim() != "" && customLine != "否")
                            {
                                CustomArray.Add(node.Name, customLine);
                            }
                            node.Text = node.Text.Replace(@"\", "\n");
                            array.Add(node.Text);
                            arrayName.Add(node.Name);
                            node.Tag = MainColumns.Count - 1 - MaxVerticalLevel + 1;
                        }
                        else
                        {
                            Sundries.MessageBox("已经包含相同横向的列！");
                            return false;
                        }
                    }
                    UpdateTableTagValue(node, dtTreeView);
                    if (HorizontalTable.Rows.Count > 0)
                    {
                        UpdateTableTagValue(node, HorizontalTable);
                    }
                    if (VerticalTable.Rows.Count > 0)
                    {
                        UpdateTableTagValue(node, VerticalTable);
                    }
                }
                if (node.Nodes.Count > 0)
                {
                    TreeToTable(node.Nodes);
                }
            }
            return true;
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
                    array.Add(GetAttributes(level, projectName, "显示文本").Replace("\\", "\n"));
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
                }
            }
            return true;
        }
        /// <summary>
        /// 刷新Tag值
        /// </summary>
        /// <param name="nodeCollection"></param>
        private void RefreshTag(TreeNodeCollection nodeCollection)
        {
            foreach (TreeNode node in nodeCollection)
            {
                if (node.Nodes.Count > 0)
                {
                    string objStart = null;
                    string objEnd = null;

                    ComputeTagStart(node, ref objStart);
                    ComputeTagEnd(node, ref objEnd);

                    if (objStart != null && objEnd != null)
                    {
                        node.Tag = objStart + "," + objEnd;
                        UpdateTableTagValue(node, dtTreeView);
                        if (HorizontalTable.Rows.Count > 0)
                        {
                            UpdateTableTagValue(node, HorizontalTable);
                        }
                        if (VerticalTable.Rows.Count > 0)
                        {
                            UpdateTableTagValue(node, VerticalTable);
                        };
                    }
                    RefreshTag(node.Nodes);
                }
            }
        }
        /// <summary>
        /// 计算节点第一个子节点的占位符
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private void ComputeTagStart(TreeNode node, ref string objStart)
        {
            if (node.Nodes.Count > 0)
            {
                ComputeTagStart(node.FirstNode, ref objStart);
            }
            else
            {
                objStart = node.Tag.ToString();
            }
        }
        /// <summary>
        /// 计算节点最后一个子节点的占位符
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private void ComputeTagEnd(TreeNode node, ref string objEnd)
        {
            if (node.Nodes.Count > 0)
            {
                ComputeTagEnd(node.LastNode, ref objEnd);
            }
            else
            {
                objEnd = node.Tag.ToString();
            }
        }
       /// <summary>
        /// 生成除了最下级列头行模板的其它行模板
       /// </summary>
       /// <param name="dt">DataTable</param>
       /// <param name="direction">方向（横向、纵向）</param>
        private void DrawOtherHeaders(DataTable dt,string direction)
        {
            int oldEndIndex = -1;
            int startLevel = 1;
            int endLevel = MaxHorizontalLevel - 1;
            bool addVertical = false;
            if (direction == "纵向" && FindTreeNodeByText(treeViewHeader.Nodes, "纵向") != null)
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
                    medPrintPreview1.ColumnModules.Add(HeaderRowCount.ToString(), new PrintColumnModule(MainColumns, intArray.ToArray(), stringArray.ToArray(), 0));
                    PrintLine line;
                    ///列头一
                    line = medPrintPreview1.addHeadLine(HeaderRowCount.ToString());
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
        /// 根据名称查找节点
        /// </summary>
        /// <param name="nodeCollection"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        private TreeNode FindTreeNodeByText(TreeNodeCollection nodeCollection, string text)
        {
            foreach (TreeNode node in nodeCollection)
            {
                if (node.Name == text)
                {
                    return node;
                }
                TreeNode foundChildNode = FindTreeNodeByText(node.Nodes, text);
                if (foundChildNode != null)
                {
                    return foundChildNode;
                }
            }
            return null; // Not found.   
        }
        /// <summary>
        /// 计算节点所占行数
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="count"></param>
        private void ComputeColumns(TreeNode node, ref int count)
        {
            if (node.Tag != null)
            {
                string tagName = node.Tag.ToString();
                if (tagName.Contains(","))
                {
                    string[] strSpit = tagName.Split(',');
                    count = int.Parse(strSpit[0]) - int.Parse(strSpit[1]) + 1;
                }
            }
        }
        /// <summary>
        /// 选中节点后查找其所有相关属性并显示
        /// </summary>
        /// <param name="node"></param>
        private void SearchTableByNode(TreeNode node)
        {
            if (node != null)
            {
                foreach (DataGridViewRow row in medDGrdViewAttribute.Rows)
                {
                    string value = GetAttributes(node.Level, node.Name, row.Cells[0].Value.ToString());
                    if (value.Trim() != "")
                    {
                        row.Cells[1].Value = value;
                    }
                }
            }
        }
        /// <summary>
        /// 保存树某子节点的属性值
        /// </summary>
        /// <param name="node"></param>
        private void UpdateTableByTreeNode(TreeNode node)
        {
            foreach (DataGridViewRow row in medDGrdViewAttribute.Rows)
            {
                string strCellName = row.Cells[0].Value.ToString();
                object[] objArray = null;
                switch (strCellName)
                {
                    case "Level":
                        break;
                    case "名称":
                    case "类型":
                        DataRow[] rows = dtTreeView.Select("PROJECT_LEVEL = '" + node.Level.ToString() + "' and PROJECT_NAME = '" + node.Name + "'");

                        foreach (DataRow temp in rows)
                        {
                            if (strCellName == "类型")
                            {
                                temp["PROJECT_CATEGORY"] = row.Cells[1].Value.ToString();
                            }
                            else
                            {
                                temp["PROJECT_NAME"] = row.Cells[1].Value.ToString();
                            }
                        }
                        if (strCellName == "名称")
                        {
                            DataRow[] rowsParent = dtTreeView.Select("PROJECT_ATTRIBUTE = '父节点' and ATTRIBUTE_VALUE = '" + node.Name + "'");
                            foreach (DataRow temp in rowsParent)
                            {
                                temp["ATTRIBUTE_VALUE"] = row.Cells[1].Value.ToString();
                            }
                            node.Name = row.Cells[1].Value.ToString();
                        }
                        break;
                    case "行高":
                    case "行字体"://所有层深相同的节点行高、行字体都更新为一致
                        DataRow[] rowLevel = dtTreeView.Select("PROJECT_LEVEL = '" + node.Level.ToString() + "' and PROJECT_ATTRIBUTE = '" + strCellName + "'");
                        foreach (DataRow temp in rowLevel)
                        {
                            temp["ATTRIBUTE_VALUE"] = GetGridViewAttribute(strCellName);
                        }
                        break;
                    case "每页行数":
                    case "默认行高":
                    case "左边距":
                        DataRow[] rowParent = dtTreeView.Select("project_level = '0' and project_name = '列头' and PROJECT_ATTRIBUTE = '" + strCellName + "'");
                        if (rowParent.Length > 0)
                        {
                            rowParent[0]["ATTRIBUTE_VALUE"] = row.Cells[1].Value;
                        }
                        else
                        {
                            DataRow[] newRowParent = dtTreeView.Select("project_level = '0' and project_name = '列头'");
                            DataSetModel.CareDocs.MED_SPECIALCARE_CONFIGRow newRow = dtTreeView.NewMED_SPECIALCARE_CONFIGRow();
                            objArray = newRowParent[0].ItemArray;
                            newRow.PROJECT_LEVEL = 0;
                            newRow.PROJECT_NAME = "列头";
                            newRow.PROJECT_ATTRIBUTE = strCellName;
                            newRow.ATTRIBUTE_VALUE = row.Cells[1].Value.ToString();
                            newRow.PROJECT_CATEGORY = "其它";
                            newRow.START_INDEX = 0;
                            if (objArray[6] != null && objArray[6].ToString().Trim() != "")
                            {
                                newRow.END_INDEX = (decimal)objArray[6];
                            }
                            newRow.SPECIALCARE_DOCS_NAME = objArray[7].ToString();
                            newRow.WARD_CODE = strWardCode;
                            newRow.FONT = objArray[9].ToString();
                            newRow.FONT_STYLE = objArray[10].ToString();
                            dtTreeView.Rows.Add(newRow);
                        }
                        break;
                    case "字体":
                    case "列头字体":
                        DataRow[] rowFont = null;
                        if (strCellName == "字体")
                        {
                            rowFont = dtTreeView.Select("PROJECT_LEVEL = '" + node.Level.ToString() + "' and PROJECT_NAME = '" + node.Name + "'");
                        }
                        else
                        {
                            rowFont = dtTreeView.Select("PROJECT_LEVEL = '0' and PROJECT_NAME = '列头'");
                        }
                        string strFont = row.Cells[1].Value.ToString();

                        if (strFont.Contains("&"))
                        {
                            string[] fontArray = strFont.Split('&');
                            foreach (DataRow temp in rowFont)
                            {
                                temp["FONT"] = fontArray[0];
                                temp["FONT_STYLE"] = fontArray[1];
                            }
                        }
                        break;
                    default:
                        DataRow[] rows1 = dtTreeView.Select("PROJECT_LEVEL = '" + node.Level + "' and PROJECT_NAME = '" + node.Name + "' and PROJECT_ATTRIBUTE = '" + strCellName + "'");
                        if (rows1.Length > 0)
                        {
                            rows1[0]["ATTRIBUTE_VALUE"] = row.Cells[1].Value;
                        }
                        else
                        {
                            DataRow[] newRowDefault = dtTreeView.Select("PROJECT_LEVEL = '" + node.Level + "' and PROJECT_NAME = '" + node.Name + "'");
                            DataSetModel.CareDocs.MED_SPECIALCARE_CONFIGRow newRow = dtTreeView.NewMED_SPECIALCARE_CONFIGRow();
                            objArray = newRowDefault[0].ItemArray;
                            newRow.PROJECT_LEVEL = node.Level;
                            newRow.PROJECT_NAME = node.Name;
                            newRow.PROJECT_ATTRIBUTE = strCellName;
                            newRow.ATTRIBUTE_VALUE = row.Cells[1].Value.ToString();
                            newRow.PROJECT_CATEGORY = objArray[4].ToString();
                            if (objArray[5] != null && objArray[5].ToString().Trim() != "")
                            {
                                newRow.START_INDEX = (decimal)objArray[5];
                            }
                            if (objArray[6] != null && objArray[6].ToString().Trim() != "")
                            {
                                newRow.END_INDEX = (decimal)objArray[6];
                            }
                            newRow.SPECIALCARE_DOCS_NAME = objArray[7].ToString();
                            newRow.WARD_CODE = strWardCode;
                            newRow.FONT = objArray[9].ToString();
                            newRow.FONT_STYLE = objArray[10].ToString();
                            dtTreeView.Rows.Add(newRow);
                        }
                        if (strCellName == "列宽" && VerticalTable.Rows.Count > 0)
                        {
                            DataRow[] rowsCellWidth = VerticalTable.Select("PROJECT_LEVEL = '" + node.Level + "' and PROJECT_ATTRIBUTE = '" + strCellName + "'");
                            foreach (DataRow cellWidthRow in rowsCellWidth)
                            {
                                DataRow[] rowsTreeView = dtTreeView.Select("project_name = '" + cellWidthRow["PROJECT_Name"].ToString() + "' and PROJECT_ATTRIBUTE = '列宽'");
                                rowsTreeView[0]["attribute_value"] = row.Cells[1].Value;
                            }
                        }
                        break;
                }
            }
        }
        /// <summary>
        /// 根据TreeNode删除表中相关数据
        /// </summary>
        /// <param name="node"></param>
        private void DeleteTreeTableByNode(TreeNode node)
        {
            DataRow[] rows = dtTreeView.Select("PROJECT_LEVEL = '" + node.Level.ToString() + "' and PROJECT_NAME = '" + node.Name + "'");
            foreach (DataRow row in rows)
            {
                row.Delete();
            }
        }
        /// <summary>
        /// 删除表中已删除项的所有子项
        /// </summary>
        /// <param name="nodes"></param>
        private void SearchDeleteNode(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                DeleteTreeTableByNode(node);
                if (node.Nodes.Count > 0)
                {
                    SearchDeleteNode(node.Nodes);
                }
            }
        }
        /// <summary>
        /// 根据数据表生成树
        /// </summary>
        private void GenerateTreeView()
        {
            DataRow[] rows = dtTreeView.Select("PROJECT_LEVEL = '0' and PROJECT_NAME = '列头' and PROJECT_ATTRIBUTE='显示文本'");
            if (rows.Length > 0)
            {
                treeViewHeader.Nodes.Clear();
                TreeNode rootNode = new TreeNode();
                rootNode.Name = "列头";
                rootNode.Text = rows[0]["ATTRIBUTE_VALUE"].ToString();
                rootNode.Tag = "0,0";
                AppendChild(rootNode);
                treeViewHeader.Nodes.Add(rootNode);
                treeViewHeader.ExpandAll();
            }
        }
        /// <summary>
        /// 添加树的子节点
        /// </summary>
        /// <param name="node"></param>
        private void AppendChild(TreeNode node)
        {
            DataRow[] rows = dtTreeView.Select("PROJECT_ATTRIBUTE = '父节点' and ATTRIBUTE_VALUE = '" + node.Name + "'", "START_INDEX ASC");
            foreach (DataRow row in rows)
            {
                TreeNode newNode = new TreeNode();
                newNode.Name = row["PROJECT_NAME"].ToString();
                DataRow[] rowsText = dtTreeView.Select("PROJECT_NAME = '" + newNode.Name + "' and PROJECT_ATTRIBUTE = '显示文本'");
                newNode.Text = rowsText[0]["ATTRIBUTE_VALUE"].ToString();

                if (row["START_INDEX"] != null && row["START_INDEX"].ToString().Trim() != "")
                {
                    newNode.Tag = row["START_INDEX"];
                }
                if (row["END_INDEX"] != null && row["END_INDEX"].ToString().Trim() != "")
                {
                    newNode.Tag += "," + row["END_INDEX"];
                }
                AppendChild(newNode);
                node.Nodes.Add(newNode);
            }
        }
        /// <summary>
        /// 更新数据表中起始字段的值
        /// </summary>
        /// <param name="node"></param>
        private void UpdateTableTagValue(TreeNode node,DataTable table)
        {
            DataRow[] rows = table.Select("project_level = '" + node.Level + "' and project_name = '" + node.Name + "'");
            foreach (DataRow row in rows)
            {
                if (node.Tag != null)
                {
                    if (node.Tag.ToString().Contains(","))
                    {
                        string[] strTag = node.Tag.ToString().Split(',');
                        row["START_INDEX"] = strTag[0];
                        row["END_INDEX"] = strTag[1];
                    }
                    else
                    {
                        row["START_INDEX"] = node.Tag.ToString();
                        row["END_INDEX"] = DBNull.Value;
                    }
                }
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
        /// <summary>
        /// 检查新节点名称是否已经使用
        /// </summary>
        /// <param name="name">节点新名称</param>
        /// <returns>是为已经使用</returns>
        private bool CheckNodeNameIsAlreadyUsed(string name)
        {
            DataRow[] rows = dtTreeView.Select("PROJECT_NAME = '" + name + "'");
            if (rows.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
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
        /// <summary>
        /// 根据类别获取属性列表
        /// </summary>
        /// <param name="node"></param>
        /// <param name="category"></param>
        private void GetCategoryAttributes(TreeNode node, string category, object sender)
        {
            for (int i = 0; i < combxList.Count; i++)
            {
                medPanel.Controls.Remove(combxList[i]);
            }
            combxList.Clear();
            DataTable dt = null;
            if (node != null && node.Parent != null)
            {
                string strCategory = GetAttributes(node.Level, node.Name, "类型");
                if (strCategory.Trim() != "")
                    dt = DataOperator.GetDictAttribute(strCategory);
                else
                    dt = DataOperator.GetDictAttribute("无");
            }
            else if (node != null && node.Parent == null)
            {
                dt = DataOperator.GetDictAttribute("列头");
            }
            else
            {
                dt = DataOperator.GetDictAttribute(category);
            }
            medDGrdViewAttribute.DataSource = dt;
            medDGrdViewAttribute.Columns[0].HeaderText = "属性";
            medDGrdViewAttribute.Columns[0].ReadOnly = true;
            medDGrdViewAttribute.Columns[1].HeaderText = "值";
            foreach (DataRow row in dt.Rows)
            {
                string strRow = row[1].ToString();
                DevExpress.XtraEditors.ComboBoxEdit box = new DevExpress.XtraEditors.ComboBoxEdit();
                box.Tag = row[0];
                if (strRow.Contains("|"))
                {
                    string[] spitstring = strRow.Split('|');
                    foreach (string str in spitstring)
                    {
                        box.Properties.Items.Add(str);
                    }
                    if (box.Properties.Items.Count > 0)
                    {
                        row[1] = box.Properties.Items[0].ToString();
                    }
                    box.SelectedIndexChanged += new EventHandler(box_SelectedIndexChanged);
                }
                else if (row[0].ToString() == "类型")
                {
                    DataTable dtDICTName = DataOperator.GetSpecialCareDICTName();
                    foreach (DataRow rowname in dtDICTName.Rows)
                    {
                        box.Properties.Items.Add(rowname[0].ToString());
                    }
                    box.SelectedIndexChanged += new EventHandler(box_CategorySelectedIndexChanged);
                }
                else
                {
                    continue;
                }
                box.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                combxList.Add(box);
            }
            if (node != null)
                SearchTableByNode(node);
            else
            {
                foreach (DataGridViewRow row in medDGrdViewAttribute.Rows)
                {
                    switch (row.Cells[0].Value.ToString())
                    {
                        case "Level":
                            row.Cells[1].Value = treeViewHeader.SelectedNode.Level;
                            break;
                        case "名称":
                            row.Cells[1].Value = treeViewHeader.SelectedNode.Name;
                            break;
                        case "显示文本":
                            row.Cells[1].Value = treeViewHeader.SelectedNode.Text;
                            break;
                        case "类型":
                            if (sender is DevExpress.XtraEditors.ComboBoxEdit)
                                row.Cells[1].Value = ((DevExpress.XtraEditors.ComboBoxEdit)sender).Text;
                            break;
                    }
                }
            }
        }
        /// <summary>
        /// 获取GridView中的属性值
        /// </summary>
        /// <param name="attributeName"></param>
        /// <returns></returns>
        private string GetGridViewAttribute(string attributeName)
        {
            foreach (DataGridViewRow row in medDGrdViewAttribute.Rows)
            {
                if (row.Cells[0].Value.ToString().Trim() == attributeName)
                {
                    return row.Cells[1].Value.ToString();
                }
            }
            return "";
        }
        /// <summary>
        /// 移动TreeNode
        /// </summary>
        /// <param name="bIsUp">true为向上，反则向下</param>
        private void MoveTreeNode(bool bIsUp)
        {
            TreeNode nodePre = null;
            if (bIsUp)
            {
                nodePre = treeViewHeader.SelectedNode.PrevNode;
            }
            else
            {
                nodePre = treeViewHeader.SelectedNode.NextNode;
            }
            if (nodePre != null)
            {
                TreeNode temp = new TreeNode();
                treeViewHeader.SelectedNode = temp;
                temp.Name = nodePre.Name;
                temp.Text = nodePre.Text;
                temp.Tag = nodePre.Tag;
                nodePre.Text = treeViewHeader.SelectedNode.Text;
                nodePre.Name = treeViewHeader.SelectedNode.Name;
                nodePre.Tag = treeViewHeader.SelectedNode.Tag;
                treeViewHeader.SelectedNode.Name = temp.Name;
                treeViewHeader.SelectedNode.Tag = temp.Tag;
                treeViewHeader.SelectedNode.Text = temp.Text;
                RefreshPreview();
            }
        }

        #endregion

        #region 窗体事件

        private void medDGrdViewAttribute_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex != -1)
            {
                string strValue = medDGrdViewAttribute.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (strValue == "字体" || strValue == "列头字体")
                {
                    FontDialog dialog = new FontDialog();
                    if (DialogResult.OK == dialog.ShowDialog())
                    {
                        Font myfont = dialog.Font;
                        medDGrdViewAttribute.Rows[e.RowIndex].Cells[1].Value = myfont.ToString() + "&" + myfont.Style.ToString();
                    }
                }
            }
        }

        private void HeaderSettings_Load(object sender, EventArgs e)
        {
            medDGrdViewAttribute.StringTrim = false;
            DataSetModel.CareDocs.MED_CONFIG_DOCS_NAMEDataTable dtNames = DataOperator.GetSpecialCareDocsNames(strWardCode);

            if (cmbBoxDocsName.Properties.Items.Count <= 0)
            {
                foreach (DataRow row in dtNames)
                {
                    cmbBoxDocsName.Properties.Items.Add(row[0].ToString());
                }
                if (cmbBoxDocsName.Properties.Items.Count > 0)
                {
                    cmbBoxDocsName.SelectedIndex = 0;
                }
                if (strDocsName != "")
                {
                    cmbBoxDocsName.Text = strDocsName;
                }
            }
            dtTreeView = DataOperator.GetSpecialCareAllColumns(cmbBoxDocsName.Text, strWardCode);
            HorizontalTable = dtTreeView.Clone();
            VerticalTable = dtTreeView.Clone();

            if (dtTreeView.Rows.Count > 0)
            {
                GenerateTreeView();
                RefreshPreview();
            }
            DataColumn dcAttribute = new DataColumn("Attribute");
            DataColumn dcValue = new DataColumn("Value");
            dcAttribute.Caption = "属性";
            dcValue.Caption = "值";
            dcAttribute.ReadOnly = true;
            dtAttribute.Columns.Add(dcAttribute);
            dtAttribute.Columns.Add(dcValue);
            //GetChildDataSet();
        }

        private void medBtnAdd_Click(object sender, EventArgs e)
        {
            if (treeViewHeader.Nodes.Count <= 0)
            {
                if (cmbBoxDocsName.Text.Trim() != "")
                {
                    GetCategoryAttributes(null, "列头", sender);
                    TreeNode rootnode = new TreeNode("列头");
                    rootnode.Name = "列头";
                    treeViewHeader.Nodes.Add(rootnode);
                    DataRow drNew = dtTreeView.NewRow();
                    drNew["PROJECT_LEVEL"] = "0";
                    drNew["PROJECT_NAME"] = "列头";
                    drNew["PROJECT_ATTRIBUTE"] = "显示文本";
                    drNew["ATTRIBUTE_VALUE"] = "列头";
                    drNew["PROJECT_CATEGORY"] = "其它";
                    drNew["SPECIALCARE_DOCS_NAME"] = cmbBoxDocsName.Text;
                    drNew["WARD_CODE"] = strWardCode;
                    dtTreeView.Rows.Add(drNew);

                    foreach (DataGridViewRow row in medDGrdViewAttribute.Rows)
                    {
                        if (row.Cells[0].Value.ToString() != "列头字体")
                        {
                            DataRow drParentAtt = dtTreeView.NewRow();
                            drParentAtt["PROJECT_LEVEL"] = "0";
                            drParentAtt["PROJECT_NAME"] = "列头";
                            drParentAtt["PROJECT_ATTRIBUTE"] = row.Cells[0].Value;
                            drParentAtt["ATTRIBUTE_VALUE"] = row.Cells[1].Value;
                            drParentAtt["PROJECT_CATEGORY"] = "其它";
                            drParentAtt["SPECIALCARE_DOCS_NAME"] = cmbBoxDocsName.Text;
                            drParentAtt["WARD_CODE"] = strWardCode;
                            dtTreeView.Rows.Add(drParentAtt);
                        }
                    }
                }
                else
                {
                    Sundries.MessageBox("请输入配置单的名称");
                }
                return;
            }
            if (treeViewHeader.SelectedNode != null)
            {
                if (treeViewHeader.SelectedNode.Parent == null && VerticalTable.Rows.Count > 0)
                {
                    return;
                }
                TreeNode node = new TreeNode();
                node.Text = "项目" + ItemIndex;

                while (CheckNodeNameIsAlreadyUsed(node.Text))
                {
                    ItemIndex++;
                    node.Text = "项目" + ItemIndex;
                }
                node.Name = node.Text;
                treeViewHeader.SelectedNode.Nodes.Add(node);
                treeViewHeader.SelectedNode.Expand();
                treeViewHeader.SelectedNode = node;
                if (node.Level > MaxHorizontalLevel)
                {
                    MaxHorizontalLevel = node.Level;
                }
                node.Parent.Tag = null;
                int startIndex = 0;
                if (node.Parent != null)
                {
                    if (node.PrevNode == null)
                    {
                        if (node.Parent.Tag != null)
                        {
                            if (node.Parent.Tag.ToString().Contains(","))
                            {
                                startIndex = int.Parse(node.Parent.Tag.ToString().Split(',')[0]);
                            }
                            else
                            {
                                startIndex = int.Parse(node.Parent.Tag.ToString());
                            }
                        }
                        else
                        {
                            startIndex = 0;
                        }
                    }
                    else
                    {
                        string stringStart = "";
                        ComputeTagEnd(node.PrevNode, ref stringStart);
                        startIndex = int.Parse(stringStart) + 1;
                    }
                }
                GetCategoryAttributes(null, "无", sender);
                foreach (DataGridViewRow row in medDGrdViewAttribute.Rows)
                {
                    string strRowValue = row.Cells[0].Value.ToString();
                    switch (strRowValue)
                    {
                        case "类型":
                            break;
                        case "Level":
                            row.Cells[1].Value = node.Level;
                            break;
                        case "名称":
                            row.Cells[1].Value = node.Name;
                            break;
                        case "字体":
                            break;
                        default:
                            if (strRowValue == "显示文本")
                                row.Cells[1].Value = node.Text;
                            DataRow drNew = dtTreeView.NewRow();
                            drNew["PROJECT_LEVEL"] = node.Level;
                            drNew["PROJECT_NAME"] = node.Name;
                            drNew["PROJECT_ATTRIBUTE"] = row.Cells[0].Value.ToString();
                            if (row.Cells[0].Value.ToString() == "行高")
                                drNew["ATTRIBUTE_VALUE"] = GetAttributes(node.Level, node.Name, "行高");
                            else if (row.Cells[1].Value.ToString().Trim() != "")
                                drNew["ATTRIBUTE_VALUE"] = row.Cells[1].Value.ToString();
                            drNew["PROJECT_CATEGORY"] = GetGridViewAttribute("类别");
                            drNew["START_INDEX"] = startIndex;
                            drNew["SPECIALCARE_DOCS_NAME"] = cmbBoxDocsName.Text;
                            drNew["WARD_CODE"] = strWardCode;

                            dtTreeView.Rows.Add(drNew);
                            break;
                    }
                }
                DataRow drParent = dtTreeView.NewRow();
                drParent["PROJECT_LEVEL"] = node.Level;
                drParent["PROJECT_NAME"] = node.Name;
                drParent["PROJECT_ATTRIBUTE"] = "父节点";
                if (node.Parent != null)
                {
                    drParent["ATTRIBUTE_VALUE"] = node.Parent.Name;
                }
                else
                {
                    drParent["ATTRIBUTE_VALUE"] = "";
                }
                drParent["PROJECT_CATEGORY"] = GetGridViewAttribute("类别");
                drParent["START_INDEX"] = startIndex;
                drParent["SPECIALCARE_DOCS_NAME"] = cmbBoxDocsName.Text;
                drParent["WARD_CODE"] = strWardCode;
                dtTreeView.Rows.Add(drParent);
            }
            RefreshPreview();
            treeViewHeader.Focus();
        }

        private void treeViewHeader_AfterSelect(object sender, TreeViewEventArgs e)
        {
            GetCategoryAttributes(e.Node, "", sender);
        }

        private void box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (treeViewHeader.SelectedNode != null && treeViewHeader.SelectedNode.Name == "列头" && ((DevExpress.XtraEditors.ComboBoxEdit)sender).Text == "纵向")
            {
                if (treeViewHeader.SelectedNode.Nodes.Count > 0)
                {
                    if (DialogResult.No == Sundries.MessageBox("更换列头显示模式为竖向后，所有列头的子节点都将清空，确定继续吗？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        return;
                    }
                    treeViewHeader.SelectedNode.Nodes.Clear();
                }
                TreeNode hNode = new TreeNode();
                hNode.Text = "横向";
                hNode.Name = "横向";
                hNode.Tag = "0";
                DataRow drNewH = dtTreeView.NewRow();
                DataRow drNewHText = dtTreeView.NewRow();
                drNewHText["PROJECT_LEVEL"] = "1";
                drNewHText["PROJECT_NAME"] = "横向";
                drNewHText["PROJECT_ATTRIBUTE"] = "显示文本";
                drNewHText["ATTRIBUTE_VALUE"] = "横向";
                drNewHText["PROJECT_CATEGORY"] = "无";
                drNewHText["SPECIALCARE_DOCS_NAME"] = cmbBoxDocsName.Text;
                drNewHText["WARD_CODE"] = strWardCode;
                drNewHText["START_INDEX"] = "0";
                dtTreeView.Rows.Add(drNewHText);
                drNewH["PROJECT_LEVEL"] = "1";
                drNewH["PROJECT_NAME"] = "横向";
                drNewH["PROJECT_ATTRIBUTE"] = "父节点";
                drNewH["ATTRIBUTE_VALUE"] = "列头";
                drNewH["PROJECT_CATEGORY"] = "无";
                drNewH["SPECIALCARE_DOCS_NAME"] = cmbBoxDocsName.Text;
                drNewH["WARD_CODE"] = strWardCode;
                drNewH["START_INDEX"] = "0";
                dtTreeView.Rows.Add(drNewH);
                treeViewHeader.SelectedNode.Nodes.Add(hNode);
                TreeNode vNode = new TreeNode("纵向");
                vNode.Name = "纵向";
                vNode.Tag = "1";
                treeViewHeader.SelectedNode.Nodes.Add(vNode);
                DataRow drNewV = dtTreeView.NewRow();
                drNewV["PROJECT_LEVEL"] = "1";
                drNewV["PROJECT_NAME"] = "纵向";
                drNewV["PROJECT_ATTRIBUTE"] = "父节点";
                drNewV["ATTRIBUTE_VALUE"] = "列头";
                drNewV["PROJECT_CATEGORY"] = "无";
                drNewV["SPECIALCARE_DOCS_NAME"] = cmbBoxDocsName.Text;
                drNewV["WARD_CODE"] = strWardCode;
                drNewV["START_INDEX"] = "1";
                dtTreeView.Rows.Add(drNewV);
                DataRow drNewVText = dtTreeView.NewRow();
                drNewVText["PROJECT_LEVEL"] = "1";
                drNewVText["PROJECT_NAME"] = "纵向";
                drNewVText["PROJECT_ATTRIBUTE"] = "显示文本";
                drNewVText["ATTRIBUTE_VALUE"] = "纵向";
                drNewVText["PROJECT_CATEGORY"] = "无";
                drNewVText["SPECIALCARE_DOCS_NAME"] = cmbBoxDocsName.Text;
                drNewVText["WARD_CODE"] = strWardCode;
                drNewVText["START_INDEX"] = "1";
                dtTreeView.Rows.Add(drNewVText);
                medDGrdViewAttribute.CurrentCell.Value = ((DevExpress.XtraEditors.ComboBoxEdit)sender).Text;
                this.medBtnSaveAttribute_Click(sender, e);
                treeViewHeader.SelectedNode.Expand();
                RefreshPreview();
            }
            medDGrdViewAttribute.CurrentCell.Value = ((DevExpress.XtraEditors.ComboBoxEdit)sender).Text;
            ((DevExpress.XtraEditors.ComboBoxEdit)sender).Visible = false;
        }

        private void box_CategorySelectedIndexChanged(object sender, EventArgs e)
        {
            medDGrdViewAttribute.CurrentCell.Value = ((DevExpress.XtraEditors.ComboBoxEdit)sender).Text;
            GetCategoryAttributes(null, ((DevExpress.XtraEditors.ComboBoxEdit)sender).Text, sender);
        }

        private void medBtnSaveAttribute_Click(object sender, EventArgs e)
        {
            if (treeViewHeader.SelectedNode != null && treeViewHeader.SelectedNode.Parent != null)
            {
                string name = GetGridViewAttribute("名称");
                if (name != treeViewHeader.SelectedNode.Name)
                {
                    if (CheckNodeNameIsAlreadyUsed(name))
                    {
                        Sundries.MessageBox("该名称已经存在！");
                        return;
                    }
                }
                UpdateTableByTreeNode(treeViewHeader.SelectedNode);
                treeViewHeader.SelectedNode.Name = name;
                treeViewHeader.SelectedNode.Text = GetGridViewAttribute("显示文本");
            }
            else if (treeViewHeader.SelectedNode != null)
            {
                UpdateTableByTreeNode(treeViewHeader.SelectedNode);
            }

            RefreshPreview();
            treeViewHeader.Focus();
        }

        private void medBtnDelete_Click(object sender, EventArgs e)
        {
            if (treeViewHeader.SelectedNode != null)
            {
                if (treeViewHeader.SelectedNode.Parent != null)
                {
                    if (VerticalTable.Rows.Count > 0 && treeViewHeader.SelectedNode.Level == 1)
                    {
                        return;
                    }
                    DeleteTreeTableByNode(treeViewHeader.SelectedNode);
                    SearchDeleteNode(treeViewHeader.SelectedNode.Nodes);
                    MaxHorizontalLevel = GetMaxTagLevelByDirection(HorizontalTable);
                    MaxVerticalLevel = GetMaxTagLevelByDirection(VerticalTable);
                    treeViewHeader.Nodes.Remove(treeViewHeader.SelectedNode);
                    RefreshPreview();
                }
                else
                {
                    if (DialogResult.OK == Sundries.MessageBox("您确定删除整张配置单吗？", "提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                    {
                        dtTreeView.Rows.Clear();
                        dtTreeView = DataOperator.GetSpecialCareAllColumns(cmbBoxDocsName.Text, strWardCode);
                        foreach (DataRow row in dtTreeView.Rows)
                        {
                            row.Delete();
                        }
                        treeViewHeader.Nodes.Clear();
                        MaxHorizontalLevel = 1;
                        RefreshPreview();
                    }
                }
            }
            treeViewHeader.Focus();
        }

        private void btnSaveDocs_Click(object sender, EventArgs e)
        {
            if (cmbBoxDocsName.Text.Trim() == "")
            {
                Sundries.MessageBox("请选择或输入配置单的名称！");
                return;
            }
          
            ThreadPool.QueueUserWorkItem(delegate
                   {
                       WaitFrm splashForm = new WaitFrm();
                       splashForm.ShowDialog();
                   });
            try
            {
                if (DataOperator.UpdateSpecialCareAllColumns(dtTreeView) <= 0)
                {
                    SplashFormCallBackNotifier.DoCallBack();
                    Sundries.MessageBox("没有保存任何数据");
                }
                else
                {
                    SplashFormCallBackNotifier.DoCallBack();
                    Sundries.MessageBox("保存成功！");
                    this.Close();
                }
            }
            catch (Exception exception)
            {
                SplashFormCallBackNotifier.DoCallBack();
                Sundries.MessageBox(exception.Message, MessageBoxIcon.Error);
            }
           
           
        }

        private void medBtnUp_Click(object sender, EventArgs e)
        {
            if (treeViewHeader.SelectedNode != null)
            {
                MoveTreeNode(true);
            }
            treeViewHeader.Focus();
        }

        private void medBtnDown_Click(object sender, EventArgs e)
        {
            if (treeViewHeader.SelectedNode != null)
            {
                MoveTreeNode(false);
            }
            treeViewHeader.Focus();
        }

        private int medPrintPreview1_CustomDrawPageHead(Graphics g, int leftOffSet, int topOffSet, int lineWidth, int pageNo, int pageCount)
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
                   
                    //for (int i = Index; i < MainColumns.Count; i++)
                    //{
                    //    if (medPrintPreview1.HeadLines[0][i].ColumnsSpan > 1)
                    //    {
                    //        Index = Index + medPrintPreview1.HeadLines[0][i].ColumnsSpan - 1;
                    //        break;
                    //    }
                    //}
                    int leftX = medPrintPreview1.ColumnModules[0].GetColumnLeft(Index) + leftOffSet;
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
                        rightY += medPrintPreview1.HeadLines[i].Height;
                    }
                    leftY = rightY;
                   
                    for (int i = CellLevel - 1; i < endIndex; i++)
                    {
                        leftY += medPrintPreview1.HeadLines[i].Height;
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
                        iHeadLineHeight += medPrintPreview1.HeadLines[i].Height;
                    }
                    Pen p1 = new Pen(new SolidBrush(Color.Black), Width);
                    int iTopLeftX = medPrintPreview1.ColumnModules[0].GetColumnLeft(MainColumns.Count) + leftOffSet;
                    int iBottomLeftY = iHeadLineHeight + medPrintPreview1.DefaultLineHeight * medPrintPreview1.LineNumberPerPage + topOffSet;
                    g.DrawLine(p1, new Point(leftOffSet, topOffSet), new Point(iTopLeftX, topOffSet));
                    g.DrawLine(p1, new Point(leftOffSet, topOffSet), new Point(leftOffSet, iBottomLeftY));
                    g.DrawLine(p1, new Point(iTopLeftX, topOffSet), new Point(iTopLeftX, iBottomLeftY));
                    g.DrawLine(p1, new Point(leftOffSet, iBottomLeftY), new Point(iTopLeftX, iBottomLeftY));
                }
            }
            return 0;
        }

        private void medBtnRefsh_Click(object sender, EventArgs e)
        {
            medPrintPreview1.HeadLines.Clear();
            medPrintPreview1.DetailLines.Clear();
            array.Clear();
            CustomArray.Clear();
            arrayName.Clear();
            MainColumns.Clear();
            medPrintPreview1.ColumnModules.Clear();
            HeaderRowCount = 0;
            MaxHorizontalLevel = 1;
            MaxVerticalLevel = 1;
            MainVerticalColumns.Clear();
            VerticalTable.Dispose();
            HorizontalTable.Dispose();
            dtAttribute.Columns.Clear();
            dtAttribute.Rows.Clear();
            dtTreeView.Rows.Clear();
            dtTreeView.Dispose();
            if (HorizontalTable != null)
            {
                HorizontalTable.Dispose();
            }
            if (VerticalTable != null)
            {
                VerticalTable.Dispose();
            }
            ItemIndex = 1;
            treeViewHeader.Nodes.Clear();
            HeaderSettings_Load(sender, e);
        }

        private void FKeyDown(object sender, KeyEventArgs e)
        {
            DataGridViewCell cell = medDGrdViewAttribute.CurrentCell;
            if (cell == null)
            {
                return;
            }

            if (e.KeyCode == Keys.F11)
            {
                if (cell.ColumnIndex == 0 || medDGrdViewAttribute.Rows[cell.RowIndex].Cells[0].Value.ToString() != "数据绑定")
                {
                    return;
                }
                DataTable dataTable = new DataTable();
                DataColumn name = new DataColumn("name");
                DataColumn code = new DataColumn("code");
                DataColumn fid = new DataColumn("fid");
                dataTable.Columns.Add(name);
                dataTable.Columns.Add(code);
                dataTable.Columns.Add(fid);

                int i = 0;
                DataSetModel.CareDocs.SpecialCareCommonDataTable dtCommon = new Com.MedicalSystem.Icu.DataSetModel.CareDocs.SpecialCareCommonDataTable();
                foreach (DataColumn column in dtCommon.Columns)
                {
                    if (!column.ColumnName.ToUpper().StartsWith("CANAL"))
                    {
                        if (column.ColumnName == "TimePoint")
                        {
                            column.ColumnName = "TIME_POINT";
                        }
                        DataRow row = dataTable.NewRow();
                        row["name"] = column.ColumnName;
                        row["code"] = column.ColumnName;
                        row["fid"] = i;
                        i++;
                        dataTable.Rows.Add(row);
                    }
                }
                DataRow customrow = dataTable.NewRow();
                customrow["name"] = "自定义列";
                customrow["code"] = "zdyl";
                customrow["fid"] = i;
                dataTable.Rows.Add(customrow);
                i++;

                DataRow customrow1 = dataTable.NewRow();
                customrow1["name"] = "泵用医嘱";
                customrow1["code"] = "byyz";
                customrow1["fid"] = i;
                dataTable.Rows.Add(customrow1);
                i++;

                DataRow customrow2 = dataTable.NewRow();
                customrow2["name"] = "静脉";
                customrow2["code"] = "jm";
                customrow2["fid"] = i;
                dataTable.Rows.Add(customrow2);
                i++;

                DataRow customrow3 = dataTable.NewRow();
                customrow3["name"] = "胃肠";
                customrow3["code"] = "wc";
                customrow3["fid"] = i;
                dataTable.Rows.Add(customrow3);
                i++;

                DataRow customrow4 = dataTable.NewRow();
                customrow4["name"] = "途径";
                customrow4["code"] = "tj";
                customrow4["fid"] = i;
                dataTable.Rows.Add(customrow4);
                i++;

                DataRow customrow5 = dataTable.NewRow();
                customrow5["name"] = "总入量";
                customrow5["code"] = "zrl";
                customrow5["fid"] = i;
                dataTable.Rows.Add(customrow5);
                i++;

                DataRow customrow6 = dataTable.NewRow();
                customrow6["name"] = "总出量";
                customrow6["code"] = "zcl";
                customrow6["fid"] = i;
                dataTable.Rows.Add(customrow6);
                i++;

                DataRow customrow7 = dataTable.NewRow();
                customrow7["name"] = "尿量";
                customrow7["code"] = "nl";
                customrow7["fid"] = i;
                dataTable.Rows.Add(customrow7);
                i++;

                DataRow customrow8 = dataTable.NewRow();
                customrow8["name"] = "便量";
                customrow8["code"] = "bl";
                customrow8["fid"] = i;
                dataTable.Rows.Add(customrow8);
                i++;

                DataRow customrow9 = dataTable.NewRow();
                customrow9["name"] = "累计";
                customrow9["code"] = "lj";
                customrow9["fid"] = i;
                dataTable.Rows.Add(customrow9);
                i++;

                DataRow customrow10 = dataTable.NewRow();
                customrow10["name"] = "每小时入量";
                customrow10["code"] = "mxsrl";
                customrow10["fid"] = i;
                dataTable.Rows.Add(customrow10);
                i++;

                DataRow customrow11 = dataTable.NewRow();
                customrow11["name"] = "平衡";
                customrow11["code"] = "ph";
                customrow11["fid"] = i;
                dataTable.Rows.Add(customrow11);
                i++;

                DataRow customrow12 = dataTable.NewRow();
                customrow12["name"] = "签名";
                customrow12["code"] = "qm";
                customrow12["fid"] = i;
                dataTable.Rows.Add(customrow12);
                i++;

                CelerityInputFrm InputFrm = new CelerityInputFrm(dataTable, "name", "code", "fid");
                Rectangle rect = medDGrdViewAttribute.GetCellDisplayRectangle(cell.ColumnIndex, cell.RowIndex, true);
                Point pt = rect.Location;
                pt.Offset(PointToScreen(medDGrdViewAttribute.Location));

                InputFrm.ShowDialog(cell, pt);

                if (cell.Value.ToString() != oldValue)
                {
                    medDGrdViewAttribute.CurrentCell = medDGrdViewAttribute.Rows[0].Cells[0];
                    medDGrdViewAttribute.CurrentCell = cell;
                }
            }
        }

        private void medDGrdViewAttribute_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            editControl = (DataGridViewTextBoxEditingControl)e.Control;
            editControl.KeyDown += FKeyDown;
        }

        private void medDGrdViewAttribute_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (editControl != null)
            {
                editControl.KeyDown -= FKeyDown;
            }
        }    
        
        private void medDGrdViewAttribute_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            ///保存旧值
            oldValue = medDGrdViewAttribute.CurrentCell.Value.ToString();

            if (e.ColumnIndex == 1 && e.RowIndex != -1)
            {
                for (int i = 0; i < combxList.Count; i++)
                {
                    DevExpress.XtraEditors.ComboBoxEdit c = combxList[i];
                    if (c.Tag != null && c.Tag.ToString() == medDGrdViewAttribute.Rows[e.RowIndex].Cells[0].Value.ToString())
                    {
                        Rectangle R;
                        R = medDGrdViewAttribute.GetCellDisplayRectangle(medDGrdViewAttribute.CurrentCell.ColumnIndex, medDGrdViewAttribute.CurrentCell.RowIndex, false);  //获取单元格位置
                        c.SetBounds(R.X + medDGrdViewAttribute.Location.X, R.Y + medDGrdViewAttribute.Location.Y, R.Width, R.Height);
                        c.Visible = true;
                        medPanel.Controls.Add(c);
                        c.BringToFront();
                        c.Focus();
                    }
                    else if (c.Tag != null)
                    {
                        c.Visible = false;
                    }
                }
            }
        }

        private void HeaderSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            //medPrintPreview1.HeadLines.Clear();
            //medPrintPreview1.DetailLines.Clear();
            //medPrintPreview1.ColumnModules.Clear();
            //medPrintPreview1.Dispose();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.Opacity = ((double)(100 - trackBar1.Value) / 100);
        }

        #endregion
    }
}