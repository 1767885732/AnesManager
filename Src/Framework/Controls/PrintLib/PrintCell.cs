using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Wis.Anes.Framework.Controls
{
    /// <summary>
    /// 单元数据类型
    /// </summary>
    public enum PrintCellDataType
    {
        /// <summary>
        /// 数字
        /// </summary>
        Numeric,
        /// <summary>
        /// 字符串
        /// </summary>
        String,
        /// <summary>
        /// 日期
        /// </summary>
        Date
    }

    /// <summary>
    /// 打印单元格类
    /// </summary>
    public class PrintCell : IDisposable
    {

        /// <summary>
        /// 强制分行符号
        /// </summary>
        public const string LINESPLITCHAR = "★";

        #region 构造方法

        public PrintCell()
        {
        }

        #endregion

        #region 变量

        /// <summary>
        /// 是否允许多行
        /// </summary>
        private bool _multiline = false;

        /// <summary>
        /// 文本对齐方式
        /// </summary>
        private ContentAlignment _textAlign = ContentAlignment.MiddleLeft;

        /// <summary>
        /// 单行是否放置在最底下一行
        /// </summary>
        private bool _singleLineAlignBottom = false;

        /// <summary>
        /// 行数
        /// </summary>
        private int _lineNumber = 1;

        /// <summary>
        /// 分割后的值
        /// </summary>
        private List<string> _stringValues;

        /// <summary>
        /// 单元格高度
        /// </summary>
        private int _height = 0;

        /// <summary>
        /// 值
        /// </summary>
        private object _value;
        /// <summary>
        /// 单元区域
        /// </summary>
        private Rectangle _rect;
        /// <summary>
        /// 单行高度
        /// </summary>
        private int _singleLineHeight = 0;
        /// <summary>
        /// 是否有内线--多行时是否需要画内部横线
        /// </summary>
        private bool _hasInnerLine = true;

        /// <summary>
        /// 是否分割成多行
        /// </summary>
        private bool _isBreakLine = true;

        /// <summary>
        /// 字体
        /// </summary>
        private Font _font = new Font("宋体", 9);

        /// <summary>
        /// 画刷
        /// </summary>
        private Brush _brush = Brushes.Black;

        /// <summary>
        /// 画笔
        /// </summary>
        private Pen _pen = Pens.Black;

        /// <summary>
        /// 单元上边位移
        /// </summary>
        private int _cellTop = 0;

        /// <summary>
        /// 单元格格式
        /// </summary>
        private string _format = "";

        /// <summary>
        /// 垂直合并行数
        /// </summary>
        private int _rowSpan = 1;

        /// <summary>
        /// 横向合并行数
        /// </summary>
        private int _columnsSpan = 1;

        /// <summary>
        /// 所属行
        /// </summary>
        private PrintLine _parentLine;

        /// <summary>
        /// 数据类型
        /// </summary>
        private PrintCellDataType _dataType;

        /// <summary>
        /// 签名护士
        /// </summary>
        private string _signNurse;

        /// <summary>
        /// 医嘱标记
        /// </summary>
        private bool _orderTag;

        /// <summary>
        /// 不计算行数的列
        /// </summary>
        private bool _notComputeColumn = false;

        /// <summary>
        /// 日期和时间
        /// </summary>
        private string[] _dateAndTime = new string[2];

        /// <summary>
        /// 开始时的总行数
        /// </summary>
        private int _startTotalCount = 0;

        /// <summary>
        /// 总行数
        /// </summary>
        private static int _totalCount = 0;

        /// <summary>
        /// 当前cell所属列数
        /// </summary>
        private int _columnNo;

        /// <summary>
        /// 当前单元格最大行数
        /// </summary>
        private int _currentCellLineNo = 0;

        /// <summary>
        /// 第一次刷新
        /// </summary>
        private static bool _firstFlash = true;

        /// <summary>
        /// 每页行数
        /// </summary>
        private static int _divisionNumberPerPage = 32;

        /// <summary>
        /// 全部内容在一页显示
        /// </summary>
        private static bool _showInOnePage = false;

        /// <summary>
        /// 该cell一行显示几个字符
        /// </summary>
        private int _showLetterNo = -1;

        /// <summary>
        /// 竖直划粗线的列
        /// </summary>
        private int _boldVerticalLine = -1;

        /// <summary>
        /// 日期格式化样式
        /// </summary>
        private string _dateFormat = "dd/MM";

        /// <summary>
        /// 每页最后一行签名
        /// </summary>
        public string lastLineWrite = "";


        /// <summary>
        /// 跳过重新修改计算每页第一行日期算法
        /// </summary>
        private bool _bSkipDateTimeFirstLine = false;
        /// <summary>
        /// 不能换行的特殊字符
        /// </summary>
        public static List<string> specialCharacter = new List<string>();
        /// <summary>
        /// 需要判断特殊字符的列
        /// </summary>
        public bool specialCharacterColumns = false;
        #endregion 变量

        #region 事件

        public delegate void HeightChangedEvent(int newHeight);
        public event HeightChangedEvent HeightChanged;

        #endregion

        #region 属性

        //public static int LineNumberOfPage = 0;
        public int LineNumberOfPage = 32;

        /// <summary>
        /// 是否允许多行
        /// </summary>
        public bool Multiline
        {
            get
            {
                return _multiline;
            }
            set
            {
                _multiline = value;
            }
        }

        /// <summary>
        /// 签名护士
        /// </summary>
        public string SignNurse
        {
            get
            {
                return _signNurse;
            }
            set
            {
                _signNurse = value;
            }
        }

        /// <summary>
        /// 单行是否放置在最底下一行
        /// </summary>
        public bool SingleLineAlignBottom
        {
            get
            {
                return _singleLineAlignBottom;
            }
            set
            {
                _singleLineAlignBottom = value;
            }
        }

        /// <summary>
        /// 文本对齐方式
        /// </summary>
        public ContentAlignment TextAlign
        {
            get
            {
                return _textAlign;
            }
            set
            {
                _textAlign = value;
            }
        }

        /// <summary>
        /// 所属行
        /// </summary>
        public PrintLine ParentLine
        {
            get
            {
                return _parentLine;
            }
            set
            {
                _parentLine = value;
            }
        }

        /// <summary>
        /// 单元格格式
        /// </summary>
        public string Format
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _format = value;
                }
            }
        }

        /// <summary>
        /// 单元上边位移
        /// </summary>
        public int CellTop
        {
            get
            {
                return _cellTop;
            }
        }

        /// <summary>
        /// 行数
        /// </summary>
        public int LineNumber
        {
            get
            {
                return _lineNumber;
            }
        }

        /// <summary>
        /// 单元格高度
        /// </summary>
        public int Height
        {
            get
            {
                if (_height == 0)
                {
                    return _singleLineHeight;
                }
                else
                {
                    return _height;
                }
            }
            set
            {
                if (value < _singleLineHeight) return;
                _height = value;
                CalcLineNumber();
                _rect.Height = _height;
                if (HeightChanged != null) HeightChanged(_height);
            }
        }

        /// <summary>
        /// 垂直合并行数
        /// </summary>
        public int RowSpan
        {
            get
            {
                return _rowSpan;
            }
            set
            {
                if (value > 0)
                {
                    _rowSpan = value;
                }
            }
        }

        /// <summary>
        /// 横向合并列数
        /// </summary>
        public int ColumnsSpan
        {
            get
            {
                return _columnsSpan;
            }
            set
            {
                if (value > 0)
                {
                    _columnsSpan = value;
                }
            }
        }

        /// <summary>
        /// 数据类型
        /// </summary>
        public PrintCellDataType DataType
        {
            get
            {
                return _dataType;
            }
            set
            {
                _dataType = value;
            }
        }


        /// <summary>
        /// 值
        /// </summary>
        public object Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        /// <summary>
        /// 单元区域
        /// </summary>
        public Rectangle Rect
        {
            get
            {
                return _rect;
            }
            set
            {
                _rect = value;
            }
        }

        /// <summary>
        /// 单行高度
        /// </summary>
        public int SingleLineHeight
        {
            get
            {
                return _singleLineHeight;
            }
            set
            {
                _singleLineHeight = value;
                if (_lineNumber >= 1)
                {
                    _rect.Height = _lineNumber * _singleLineHeight;
                    _height = _rect.Height;
                }
                else
                {
                    _rect.Height = _singleLineHeight;
                    _height = _singleLineHeight;
                }
            }
        }

        /// <summary>
        /// 是否有内线--多行时是否需要画内部横线
        /// </summary>
        public bool HasInnerLine
        {
            get
            {
                return _hasInnerLine;
            }
            set
            {
                _hasInnerLine = value;
            }
        }

        /// <summary>
        /// 是否分割成多行
        /// </summary>
        public bool IsBreakLine
        {
            get
            {
                return _isBreakLine;
            }
            set
            {
                _isBreakLine = value;
            }
        }

        /// <summary>
        /// 字体
        /// </summary>
        public Font Font
        {
            get
            {
                return _font;
            }
            set
            {
                _font = value;
            }
        }

        /// <summary>
        /// 画刷
        /// </summary>
        public Brush Brush
        {
            get
            {
                return _brush;
            }
            set
            {
                _brush = value;
            }
        }

        /// <summary>
        /// 画笔
        /// </summary>
        public Pen Pen
        {
            get
            {
                return _pen;
            }
            set
            {
                _pen = value;
            }
        }

        /// <summary>
        /// 医嘱标记
        /// </summary>
        public bool OrderTag
        {
            get
            {
                return _orderTag;
            }
            set
            {
                _orderTag = value;
            }
        }

        /// <summary>
        /// 不计算行数的列
        /// </summary>
        public bool NotComputeColumn
        {
            set
            {
                _notComputeColumn = value;
            }
        }

        /// <summary>
        /// 当前cell所属列数
        /// </summary>
        public int ColumnNo
        {
            get
            {
                return _columnNo;
            }
            set
            {
                _columnNo = value;
            }
        }

        /// <summary>
        /// 总行数
        /// </summary>
        public static int TotalCount
        {
            get
            {
                return _totalCount;
            }
            set
            {
                _totalCount = value;
            }
        }

        /// <summary>
        /// 当前单元格最大行数
        /// </summary>
        public int CurrentCellCellLineNo
        {
            get
            {
                return _currentCellLineNo;
            }
            set
            {
                _currentCellLineNo = value;
            }
        }

        /// <summary>
        /// 第一次刷新
        /// </summary>
        public static bool FirstFlash
        {
            get
            {
                return _firstFlash;
            }
            set
            {
                _firstFlash = value;
            }
        }

        /// <summary>
        /// 每页行数
        /// </summary>
        public static int DivisionNumberPerPage
        {
            get
            {
                return _divisionNumberPerPage;
            }
            set
            {
                if (value > 0)
                {
                    _divisionNumberPerPage = value;
                }
            }
        }

        /// <summary>
        /// 全部内容在一页显示
        /// </summary>
        public static bool ShowInOnePage
        {
            get
            {
                return _showInOnePage;
            }
            set
            {
                _showInOnePage = value;
            }
        }

        /// <summary>
        /// 该cell一行显示几个字符
        /// </summary>
        public int ShowLetterNo
        {
            get
            {
                return _showLetterNo;
            }
            set
            {
                _showLetterNo = value;
            }
        }

        /// <summary>
        /// 该cell开始时的总行数
        /// </summary>
        public int StartTotalCount
        {
            get
            {
                return _startTotalCount;
            }
        }

        /// <summary>
        /// 画粗线的列
        /// </summary>
        public int BoldVerticalLine
        {
            set
            {
                _boldVerticalLine = value;
            }
        }
        #endregion

        private bool _yeah = true;
        public bool Yeah
        {
            get { return _yeah; }
            set
            {
                _yeah = value;
            }
        }

        /// <summary>
        /// 日期格式化样式
        /// </summary>
        public string DateFormat
        {
            set
            {
                _dateFormat = value;
            }
            get
            {
                return _dateFormat;
            }
        }


        /// <summary>
        /// 跳过重新修改计算每页第一行日期算法
        /// </summary>
        public bool SkipDateTimeFirstLine
        {
            get
            {
                return _bSkipDateTimeFirstLine;
            }
            set
            {
                _bSkipDateTimeFirstLine = value;
            }
        }

        /// <summary>
        /// 跳过重新修改计算每页第一行日期算法
        /// </summary>
        public List<string> StringValues
        {
            get
            {
                return _stringValues;
            }
        }

        #region 方法

        /// <summary>
        /// 计算行数
        /// </summary>
        private void CalcLineNumber()
        {
            _lineNumber = 1;
            int y = _singleLineHeight;
            while (y < _height)
            {
                y += _singleLineHeight;
                _lineNumber++;
            }
        }

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="value">字符串值</param>
        /// <param name="width">占位宽度</param>
        /// <param name="g">作图对象</param>
        /// <param name="font">字体</param>
        /// <returns>分割结果</returns>
        private List<string> MakeSplitString(string value, float width, Graphics g, Font font, bool isPrint, List<int> _singleLineNumber)
        {
            List<string> stringValues = new List<string>();
            string strValue = value;
            string[] values = strValue.Split((new string[] { LINESPLITCHAR }), StringSplitOptions.None);
            for (int i = 0; i < values.Length; i++)
            {
                if (_isBreakLine)
                {
                    if (_orderTag == true)
                        SplitString(i, width, g, font, stringValues, isPrint, values, _singleLineNumber);
                    else
                        SplitString(values[i], width, g, font, stringValues, isPrint);
                }
                else
                {
                    stringValues.Add(values[i]);
                }
            }
            return stringValues;
        }

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="value">字符串值</param>
        /// <param name="width">占位宽度</param>
        /// <param name="g">作图对象</param>
        /// <param name="font">字体</param>
        /// <returns>分割结果</returns>
        public List<string> SplitString(string value, float width, Graphics g, Font font, bool isPrint)
        {
            List<string> stringValues = new List<string>();
            SplitString(value, width, g, font, stringValues, isPrint);
            return stringValues;
        }

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="value">字符串值</param>
        /// <param name="width">占位宽度</param>
        /// <param name="g">作图对象</param>
        /// <param name="font">字体</param>
        /// <param name="splitString">强制分割符</param>
        /// <returns>分割结果</returns>
        public List<string> SplitString(string value, float width, Graphics g, Font font, string splitString, bool isPrint)
        {
            List<string> stringValues = new List<string>();
            string strValue = value;
            string[] values = strValue.Split((new string[] { splitString }), StringSplitOptions.None);
            for (int i = 0; i < values.Length; i++)
            {
                SplitString(values[i], width, g, font, stringValues, isPrint);
            }
            return stringValues;
        }

        /// <summary>
        /// 每页第一行加时间点
        /// </summary>
        /// <param name="value">字符串值</param>
        /// <param name="width">占位宽度</param>
        /// <param name="g">作图对象</param>
        /// <param name="font">字体</param>
        /// <param name="stringValues">分割结果</param>
        private void SplitTime(string value, float width, Graphics g, Font font, List<string> stringValues, bool isPrint)
        {
            string strValue = value;
            strValue = strValue.Replace("※", "");
            strValue = strValue.Replace("@", "");
            int letterRowNo = 1;
            string[] values = strValue.Split((new string[] { LINESPLITCHAR }), StringSplitOptions.None);
            if (_columnNo != 0)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    for (letterRowNo = 1; _showLetterNo * letterRowNo * 2 <= values[i].Length; letterRowNo++)
                    {
                        stringValues.Add(values[i].Substring((letterRowNo - 1) * (_showLetterNo * 2), 6));
                    }
                    stringValues.Add(values[i].Substring((letterRowNo - 1) * (_showLetterNo * 2)));
                }
            }
            else
            {
                for (int i = 0; i < values.Length; i++)
                {
                    stringValues.Add(values[i]);
                }
            }
            if (_yeah && (_columnNo == 0 || _columnNo == 1))
            {
                //if条件正确执行的代码是原始代码 else是毓黄顶后添加的
                //执行毓黄顶的代码单子第2页以后第2行会出现空白行
                //暂时未找到解决办法 只能先用这个办法了..

                for (int futureLineNo = _startTotalCount + 1; futureLineNo <= _startTotalCount + _currentCellLineNo; futureLineNo++)
                {
                    if (_startTotalCount % LineNumberOfPage == 0)
                    {
                        if (_columnNo == 0 && ParentLine.TimePoint != new DateTime(1900, 1, 1))
                        {
                            if (_dateFormat == "dd/MM")
                            {
                                stringValues[0] = ParentLine.TimePoint.ToString("dd") + "/" + ParentLine.TimePoint.ToString("MM");
                            }
                            else if (_dateFormat == "dd/MM hh:mm")
                            {
                                stringValues[0] = ParentLine.TimePoint.ToString("dd") + "/" + ParentLine.TimePoint.ToString("MM") + " " + ParentLine.TimePoint.ToShortTimeString();
                            }
                            else if (_dateFormat == "MM/dd hh:mm")
                            {
                                stringValues[0] = (ParentLine.TimePoint.ToString("MM") + "/" + ParentLine.TimePoint.ToString("dd") + " " + ParentLine.TimePoint.ToShortTimeString());
                            }
                            else if (_dateFormat == "MM.dd")
                            {
                                stringValues[0] = ParentLine.TimePoint.ToString("MM") + "." + ParentLine.TimePoint.ToString("dd");
                            }
                            else if (_dateFormat.StartsWith("-"))
                            {
                                stringValues[0] = _dateFormat.Substring(1);
                            }
                            else
                            {
                                stringValues[0] = ParentLine.TimePoint.ToString(_dateFormat);
                            }
                        }
                        return;
                    }
                    if (futureLineNo % LineNumberOfPage == 1 && _startTotalCount != 0)
                    {
                        int pageNo = futureLineNo / LineNumberOfPage;
                        for (int lineNo = 0; lineNo < LineNumberOfPage * pageNo - _startTotalCount - 1; lineNo++)
                        {
                            stringValues.Add("");
                        }
                        if (_columnNo == 0 && this.ParentLine.TimePoint != new DateTime(1900, 1, 1))
                        {
                            if (_dateFormat == "dd/MM")
                            {
                                stringValues.Add(ParentLine.TimePoint.ToString("dd") + "/" + ParentLine.TimePoint.ToString("MM"));
                            }
                            else if (_dateFormat == "dd/MM hh:mm")
                            {
                                stringValues.Add(ParentLine.TimePoint.ToString("dd") + "/" + ParentLine.TimePoint.ToString("MM") + " " + ParentLine.TimePoint.ToShortTimeString());
                            }
                            else if (_dateFormat == "MM/dd hh:mm")
                            {
                                stringValues.Add(ParentLine.TimePoint.ToString("MM") + "/" + ParentLine.TimePoint.ToString("dd") + " " + ParentLine.TimePoint.ToShortTimeString());
                            }
                            else if (_dateFormat == "MM.dd")
                            {
                                stringValues.Add(ParentLine.TimePoint.ToString("MM") + "." + ParentLine.TimePoint.ToString("dd"));
                            }
                            else if (_dateFormat.StartsWith("-"))
                            {
                                stringValues.Add(_dateFormat.Substring(1));
                            }
                            else
                            {
                                stringValues.Add(ParentLine.TimePoint.ToString(_dateFormat));
                            }
                        }
                        else if (_columnNo == 0)
                            stringValues.Add(_dateAndTime[0]);
                        else
                            stringValues.Add(_dateAndTime[1]);
                    }
                }
                if (strValue.Trim() != "")
                {
                    if (_columnNo == 0 && !strValue.Contains(":"))
                        _dateAndTime[0] = strValue;
                    else
                        _dateAndTime[1] = strValue;
                }
            }
        }

        /// <summary>
        /// 计算医嘱字符串所占行数
        /// </summary>
        /// <param name="strValue"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public static int ComputeLineNo(string strValue, int width, Graphics printerSettingGraphics, Font font)
        {
            int lineNo = 1;
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
                        if (printerSettingGraphics.MeasureString(strValue.Substring(0, i), font).Width - w < 2)
                        {
                            i++;
                        }
                        break;
                    }
                }

                NumberDoNotBreakLine(strValue, w, printerSettingGraphics, font, ref i);


                strValue = strValue.Substring(i - 1);
                stringWidth = printerSettingGraphics.MeasureString(strValue, font).Width;
            }
            return lineNo;
        }
        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="value">字符串值</param>
        /// <param name="width">占位宽度</param>
        /// <param name="g">作图对象</param>
        /// <param name="font">字体</param>
        /// <param name="stringValues">分割结果</param>
        private void SplitString(string value, float width, Graphics g, Font font, List<string> stringValues, bool isPrint)
        {
            string strValue = value;
            strValue = strValue.Replace("※", "");
            strValue = strValue.Replace("@", "");
            float stringWidth = g.MeasureString(strValue, font).Width;

            //float w = width;

            float w = width + 5;

            //if (isPrint)
            //{
            //    w += 1;
            //}
            //if (!isPrint)
            //{
            //    if (width == 480)
            //        w -= 20;
            //}
            List<int> specialCharacterIndex = new List<int>();
            List<int> specialCharacterLength = new List<int>();
            
            while (stringWidth > w)
            {
                if (specialCharacterColumns)
                {
                    getSpecialCharacterIndex(specialCharacterIndex, specialCharacterLength, strValue);
                }
                int i = 0;
                //for (i = 1; i < strValue.Length; i++)
                //{
                //    if (g.MeasureString(strValue.Substring(0, i), font).Width > w)
                //    {
                //        if (g.MeasureString(strValue.Substring(0, i), font).Width - w < 2)
                //        {
                //            i++;
                //        }
                //        if (specialCharacterColumns)  //解决特殊字符要在一行的问题
                //        {
                //            getHuanHangIndex(specialCharacterIndex, specialCharacterLength, ref i);
                //        }
                //        break;
                //    }
                //}

                int end = strValue.Length - 1;
                for (int start = 0; start <= end; )
                {
                    i = start + (end - start) / 2;
                    if (start == end)
                    {
                        i = start;
                        if (g.MeasureString(strValue.Substring(0, i), font).Width - w < 2)
                        {
                            i++;
                        }
                        if (specialCharacterColumns)  //解决特殊字符要在一行的问题
                        {
                            getHuanHangIndex(specialCharacterIndex, specialCharacterLength, ref i);
                        }
                        break;
                    }
                    else if (g.MeasureString(strValue.Substring(0, i + 1),font).Width > width - 1) end = i - 1;
                    else start = i + 1;
                } 

                #region 2010-05-14 数字不要断行显示
                //2010-05-14 数字不要断行显示
                NumberDoNotBreakLine(strValue, w, g, font, ref i);
                #endregion

                stringValues.Add(strValue.Substring(0, i - 1));
                strValue = strValue.Substring(i - 1);
                stringWidth = g.MeasureString(strValue, font).Width;
            }
            stringValues.Add(strValue);
            //if (_yeah && (_columnNo == 0 || _columnNo == 1))
            //{
            //    //if条件正确执行的代码是原始代码 else是毓黄顶后添加的
            //    //执行毓黄顶的代码单子第2页以后第2行会出现空白行
            //    //暂时未找到解决办法 只能先用这个办法了..

            //    for (int futureLineNo = _startTotalCount + 1; futureLineNo <= _startTotalCount + _currentCellLineNo; futureLineNo++)
            //    {
            //        if (_startTotalCount % LineNumberOfPage == 0 && _startTotalCount != 0)
            //        {
            //            if (_columnNo == 0 && ParentLine.TimePoint != new DateTime(1900, 1, 1))
            //            {
            //                if (_dateFormat == "dd/MM")
            //                {
            //                    stringValues[0] = ParentLine.TimePoint.ToString("dd") + "/" + ParentLine.TimePoint.ToString("MM");
            //                }
            //                else if (_dateFormat == "dd/MM hh:mm")
            //                {
            //                    stringValues[0] = ParentLine.TimePoint.ToString("dd") + "/" + ParentLine.TimePoint.ToString("MM") + " " + ParentLine.TimePoint.ToShortTimeString();
            //                }
            //                else if (_dateFormat == "MM.dd")
            //                {
            //                    stringValues[0] = ParentLine.TimePoint.ToString("MM") + "." + ParentLine.TimePoint.ToString("dd");
            //                }
            //                else if (_dateFormat.StartsWith("-"))
            //                {
            //                    stringValues[0] = _dateFormat.Substring(1);
            //                }
            //                else
            //                {
            //                    stringValues[0] = ParentLine.TimePoint.ToString(_dateFormat);
            //                }
            //            }
            //            return;
            //        }
            //        //解决第一行就换页情况
            //        if (futureLineNo == 1 && _startTotalCount == 0 && _currentCellLineNo > LineNumberOfPage)
            //        {
            //            for (int lineNo = 0; lineNo < LineNumberOfPage - 1; lineNo++)
            //            {
            //                stringValues.Add("");
            //            }
            //            if (_columnNo == 0 && this.ParentLine.TimePoint != new DateTime(1900, 1, 1))
            //            {
            //                if (_dateFormat == "dd/MM")
            //                {
            //                    stringValues.Add(ParentLine.TimePoint.ToString("dd") + "/" + ParentLine.TimePoint.ToString("MM"));
            //                }
            //                else if (_dateFormat == "dd/MM hh:mm")
            //                {
            //                    stringValues.Add(ParentLine.TimePoint.ToString("dd") + "/" + ParentLine.TimePoint.ToString("MM") + " " + ParentLine.TimePoint.ToShortTimeString());
            //                }
            //                else if (_dateFormat == "MM.dd")
            //                {
            //                    stringValues.Add(ParentLine.TimePoint.ToString("MM") + "." + ParentLine.TimePoint.ToString("dd"));
            //                }
            //                else if (_dateFormat.StartsWith("-"))
            //                {
            //                    stringValues.Add(_dateFormat.Substring(1));
            //                }
            //                else
            //                {
            //                    stringValues.Add(ParentLine.TimePoint.ToString(_dateFormat));
            //                }
            //            }
            //            else if (_columnNo == 0)
            //                stringValues.Add(_dateAndTime[0]);
            //            else
            //                stringValues.Add(_dateAndTime[1]);
            //        }
            //        if (futureLineNo % LineNumberOfPage == 1 && _startTotalCount != 0)
            //        {
            //            int pageNo = futureLineNo / LineNumberOfPage;
            //            if ((_startTotalCount + _currentCellLineNo) / LineNumberOfPage - _startTotalCount / LineNumberOfPage > 1 && pageNo > 1)
            //            {
            //                //for (int lineNo = 0; lineNo < LineNumberOfPage * pageNo - _startTotalCount - 2; lineNo++)
            //                for (int lineNo = 0; lineNo < LineNumberOfPage; lineNo++)
            //                {
            //                    stringValues.Add("");
            //                }
            //            }
            //            else
            //            {
            //                for (int lineNo = 0; lineNo < LineNumberOfPage * pageNo - _startTotalCount - 1; lineNo++)
            //                {
            //                    stringValues.Add("");
            //                }
            //            }
            //            if (_columnNo == 0 && this.ParentLine.TimePoint != new DateTime(1900, 1, 1))
            //            {
            //                if (_dateFormat == "dd/MM")
            //                {
            //                    stringValues.Add(ParentLine.TimePoint.ToString("dd") + "/" + ParentLine.TimePoint.ToString("MM"));
            //                }
            //                else if (_dateFormat == "dd/MM hh:mm")
            //                {
            //                    stringValues.Add(ParentLine.TimePoint.ToString("dd") + "/" + ParentLine.TimePoint.ToString("MM") + " " + ParentLine.TimePoint.ToShortTimeString());
            //                }
            //                else if (_dateFormat == "MM.dd")
            //                {
            //                    stringValues.Add(ParentLine.TimePoint.ToString("MM") + "." + ParentLine.TimePoint.ToString("dd"));
            //                }
            //                else if (_dateFormat.StartsWith("-"))
            //                {
            //                    stringValues.Add(_dateFormat.Substring(1));
            //                }
            //                else
            //                {
            //                    stringValues.Add(ParentLine.TimePoint.ToString(_dateFormat));
            //                }
            //            }
            //            else if (_columnNo == 0)
            //                stringValues.Add(_dateAndTime[0]);
            //            else
            //                stringValues.Add(_dateAndTime[1]);
            //        }
            //    }
            //    if (strValue.Trim() != "")
            //    {
            //        if (_columnNo == 0 && !strValue.Contains(":"))
            //            _dateAndTime[0] = strValue;
            //        else
            //            _dateAndTime[1] = strValue;
            //    }
            //}
            

            if (Math.Abs(_startTotalCount) >= LineNumberOfPage)
            {
                _startTotalCount = _startTotalCount % LineNumberOfPage;
            }

            #region 2010-5-28重新修改计算每页第一行日期算法
            //2010-5-28重新修改计算每页第一行日期算法
            if (_yeah && (_columnNo == 0 || _columnNo == 1))
            {
                #region 2010-06-04
                //谁加的这个判断?? 这个数组到这里必然为空 这样判断会影响到其他医院 所以暂时注释掉.
                //if (_dateAndTime[0] == null || _dateAndTime[1] == null)
                //{
                //    return;
                //}
                if (_bSkipDateTimeFirstLine)
                {
                    return;
                }
                #endregion

                bool firstLine = false;   //是否截除行加空格了
                //截除行后第一行时间点
                if (_currentCellLineNo > 1 && _startTotalCount < 0 && _startTotalCount + _currentCellLineNo > 0)
                {
                    if (strValue.Trim() != "")
                    {
                        if (_columnNo == 0 && !strValue.Contains(":"))
                            _dateAndTime[0] = strValue;
                        else
                            _dateAndTime[1] = strValue;
                    }
                    int startCount = _startTotalCount;
                    if (Math.Abs(_startTotalCount) >= LineNumberOfPage)
                    {
                        startCount = _startTotalCount % LineNumberOfPage;
                    }
                    //for (int i = 0; i < -1 - _startTotalCount; i++)
                    for (int i = 0; i < -1 - startCount; i++)
                    {
                        stringValues.Add("");
                    }
                    AddFormatTime(stringValues, true);
                    firstLine = true;
                }
                //记录正好是第一行,把日期加上
                else if (_startTotalCount % LineNumberOfPage == 0)
                {
                    AddFormatTime(stringValues, false);
                }

                //换页的情况
                if (_currentCellLineNo > 1 && (_startTotalCount / LineNumberOfPage != (_startTotalCount + _currentCellLineNo) / LineNumberOfPage))
                {
                    if ((_startTotalCount + _currentCellLineNo) % LineNumberOfPage == 0 && (_startTotalCount + _currentCellLineNo) / LineNumberOfPage - _startTotalCount / LineNumberOfPage == 1)
                    {

                    }
                    else
                    {
                        if (strValue.Trim() != "")
                        {
                            if (_columnNo == 0 && !strValue.Contains(":"))
                                _dateAndTime[0] = strValue;
                            else
                                _dateAndTime[1] = strValue;
                        }
                        if (firstLine)    //截除行后第一行已经加过时间点,但是这个数据翻页
                        {
                            for (int j = 0; j < LineNumberOfPage - 1; j++)
                            {
                                stringValues.Add("");
                            }
                            AddFormatTime(stringValues, true);
                        }
                        else
                        {
                            //换一页
                            for (int i = 0; i < LineNumberOfPage - 1 - _startTotalCount % LineNumberOfPage; i++)
                            {
                                stringValues.Add("");
                            }
                            AddFormatTime(stringValues, true);
                        }
                        //超过一页
                        int totalPageNo = (_startTotalCount + _currentCellLineNo) / LineNumberOfPage - _startTotalCount / LineNumberOfPage;
                        //
                        for (int i = 0; i < totalPageNo - 1 ; i++)
                        {
                            for (int j = 0; j < LineNumberOfPage - 1; j++)
                            {
                                stringValues.Add("");
                            }
                            AddFormatTime(stringValues, true);
                        }
                    }
                }
                
            }

            if (lastLineWrite != "")
            {
                for (int futureLineNo = _startTotalCount + 1; futureLineNo <= _startTotalCount + _currentCellLineNo; futureLineNo++)
                {
                    if (futureLineNo % LineNumberOfPage == 0)
                    {
                        int pageNo = futureLineNo / LineNumberOfPage;
                        for (int lineNo = _startTotalCount + 2; lineNo < futureLineNo; lineNo++)
                        {
                            stringValues.Add("");
                        }
                        stringValues.Add(lastLineWrite);
                    }
                }
            }
            #endregion
            
            #endregion 暂时注销

        }

        private void AddFormatTime(List<string> stringValues,bool isAdd)
        {
            if (isAdd)
            {
                if (_columnNo == 0 && this.ParentLine.TimePoint != new DateTime(1900, 1, 1))
                {
                    if (_dateFormat == "dd/MM")
                    {
                        stringValues.Add(ParentLine.TimePoint.ToString("dd") + "/" + ParentLine.TimePoint.ToString("MM"));
                    }
                    else if (_dateFormat == "dd/MM hh:mm")
                    {
                        stringValues.Add(ParentLine.TimePoint.ToString("dd") + "/" + ParentLine.TimePoint.ToString("MM") + " " + ParentLine.TimePoint.ToShortTimeString());
                    }
                    else if (_dateFormat == "MM/dd hh:mm")
                    {
                        stringValues.Add(ParentLine.TimePoint.ToString("MM") + "/" + ParentLine.TimePoint.ToString("dd") + " " + ParentLine.TimePoint.ToShortTimeString());
                    }
                    else if (_dateFormat == "MM.dd")
                    {
                        stringValues.Add(ParentLine.TimePoint.ToString("MM") + "." + ParentLine.TimePoint.ToString("dd"));
                    }
                    else if (_dateFormat.StartsWith("-"))
                    {
                        stringValues.Add(_dateFormat.Substring(1));
                    }
                    else
                    {
                        stringValues.Add(ParentLine.TimePoint.ToString(_dateFormat));
                    }
                }
                else if (_columnNo == 0)
                    stringValues.Add(_dateAndTime[0]);
                else
                    stringValues.Add(_dateAndTime[1]);
            }
            else
            {
                if (_columnNo == 0 && this.ParentLine.TimePoint != new DateTime(1900, 1, 1))
                {
                    if (_dateFormat == "dd/MM")
                    {
                        stringValues[0] = (ParentLine.TimePoint.ToString("dd") + "/" + ParentLine.TimePoint.ToString("MM"));
                    }
                    else if (_dateFormat == "dd/MM hh:mm")
                    {
                        stringValues[0] = (ParentLine.TimePoint.ToString("dd") + "/" + ParentLine.TimePoint.ToString("MM") + " " + ParentLine.TimePoint.ToShortTimeString());
                    }
                    else if (_dateFormat == "MM/dd hh:mm")
                    {
                        stringValues[0] = (ParentLine.TimePoint.ToString("MM") + "/" + ParentLine.TimePoint.ToString("dd") + " " + ParentLine.TimePoint.ToShortTimeString());
                    }
                    else if (_dateFormat == "MM/dd HH:mm")
                    {
                        stringValues[0] = (ParentLine.TimePoint.ToString("MM") + "/" + ParentLine.TimePoint.ToString("dd") + " " + ParentLine.TimePoint.ToShortTimeString());
                    }
                    else if (_dateFormat == "MM.dd")
                    {
                        stringValues[0] = (ParentLine.TimePoint.ToString("MM") + "." + ParentLine.TimePoint.ToString("dd"));
                    }
                    else if (_dateFormat.StartsWith("-"))
                    {
                        stringValues[0] = (_dateFormat.Substring(1));
                    }
                    else
                    {
                        stringValues[0] = (ParentLine.TimePoint.ToString(_dateFormat));
                    }
                }
                else if (_columnNo == 0 && !string.IsNullOrEmpty(_dateAndTime[0]))
                    stringValues[0] = (_dateAndTime[0]);
                
            }
        }
        /// <summary>
        /// 获取特殊字符的下标
        /// </summary>
        /// <param name="specialCharacterIndex"></param>
        /// <param name="specialCharacterLength"></param>
        /// <param name="strValue"></param>
        private void getSpecialCharacterIndex(List<int> specialCharacterIndex, List<int> specialCharacterLength, string strValue)
        {
            specialCharacterIndex.Clear();
            specialCharacterLength.Clear();
            foreach (string str in specialCharacter)
            {
                int strIndex = strValue.IndexOf(str);
                if (strIndex > -1)
                {
                    specialCharacterIndex.Add(strIndex);
                    specialCharacterLength.Add(str.Length);
                }
            }
        }
        /// <summary>
        /// 获取有特殊字符时换行的下标
        /// </summary>
        /// <param name="specialCharacterIndex"></param>
        /// <param name="specialCharacterLength"></param>
        /// <param name="currentIndex"></param>
        /// <returns></returns>
        private void getHuanHangIndex(List<int> specialCharacterIndex, List<int> specialCharacterLength,ref int currentIndex)
        {
            int characterIndex = 0;
            foreach (int strIndex in specialCharacterIndex)
            {
                if (strIndex > currentIndex)
                {
                    break;
                }
                else if (strIndex < currentIndex - 1 && strIndex + specialCharacterLength[characterIndex] >= currentIndex - 1)
                {
                    currentIndex = strIndex + 1;
                    break;
                }
                characterIndex++;
            }
            return;
        }
        /// <summary>
        /// 分割字符串(加入医嘱标识)
        /// </summary>
        /// <param name="value">字符串值</param>
        /// <param name="width">占位宽度</param>
        /// <param name="g">作图对象</param>
        /// <param name="font">字体</param>
        /// <param name="stringValues">分割结果</param>
        private void SplitString(int index, float width, Graphics g, Font font, List<string> stringValues, bool isPrint, string[] sourceValue, List<int> _singleLineNumber)
        {
            string strValue = sourceValue[index];
            
            float stringWidth;
            if (strValue.Contains("※") || strValue.Contains("@"))
            {
                stringWidth = g.MeasureString(strValue.Substring(1), font).Width;
            }
            else
            {
                stringWidth = g.MeasureString(strValue, font).Width;
            }
            float w = width + 5;
            //float w = width;
            bool split = false;
            int lineNumber = 1;
            //if (isPrint)
            //{
            //    w += 1;
            //}
            //if (!isPrint)
            //{
            //    if (width >= 150 && width <= 155)
            //        w -= 6;
            //    else if (width == 725)
            //        w -= 28;
            //}
            List<int> specialCharacterIndex = new List<int>();
            List<int> specialCharacterLength = new List<int>();
           
            while (stringWidth > w)
            {
                if (specialCharacterColumns)
                {
                    getSpecialCharacterIndex(specialCharacterIndex, specialCharacterLength, strValue);
                }
                lineNumber++;
                split = true;
                int i = 0;
                //for (i = 1; i < strValue.Length; i++)
                //{
                //    if (strValue.Contains("※") || strValue.Contains("@"))
                //    {
                //        if (g.MeasureString(strValue.Substring(1, i), font).Width > w)
                //        {

                //            if (g.MeasureString(strValue.Substring(1, i), font).Width - w < 2)
                //            {
                //                i++;
                //            }
                //            i++;
                //            if (specialCharacterColumns)  //解决特殊字符要在一行的问题
                //            {
                //                getHuanHangIndex(specialCharacterIndex, specialCharacterLength, ref i);
                //            }
                //            break;
                //        }

                //    }
                //    else
                //    {
                //        if (g.MeasureString(strValue.Substring(0, i), font).Width > w)
                //        {
                //            if (g.MeasureString(strValue.Substring(0, i), font).Width - w < 2)
                //            {
                //                i++;
                //            }
                //            if (specialCharacterColumns)  //解决特殊字符要在一行的问题
                //            {
                //                getHuanHangIndex(specialCharacterIndex, specialCharacterLength, ref i);
                //            }
                //            break;
                //        }
                //    }
                //}

                int end = strValue.Length - 1;
                for (int start = 0; start <= end; )
                {
                    i = start + (end - start) / 2;
                    if (start == end)
                    {
                        i = start;
                        if (g.MeasureString(strValue.Substring(0, i), font).Width - w < 2)
                        {
                            i++;
                        }
                        if (strValue.Contains("※") || strValue.Contains("@"))
                        {
                            i++;
                        }
                        if (specialCharacterColumns)  //解决特殊字符要在一行的问题
                        {
                            getHuanHangIndex(specialCharacterIndex, specialCharacterLength, ref i);
                        }
                        break;
                    }
                    else if (g.MeasureString(strValue.Substring(0, i + 1), font).Width > width - 1) end = i - 1;
                    else start = i + 1;
                } 


                #region 2010-05-14 数字不要断行显示
                //2010-05-14 数字不要断行显示
                NumberDoNotBreakLine(strValue, w, g, font, ref i);
                #endregion
                if (sourceValue[index].Contains("※"))
                {
                    if (index < sourceValue.Length - 1)
                    {
                        if (sourceValue[index + 1].Contains("@"))
                        {
                            if (!strValue.Substring(0, i - 1).Contains("※"))
                            {
                                stringValues.Add("@" + strValue.Substring(0, i - 1));
                            }
                            else
                                stringValues.Add(strValue.Substring(0, i - 1));
                        }
                        else
                            stringValues.Add(strValue.Substring(0, i - 1));
                    }
                    else
                        stringValues.Add(strValue.Substring(0, i - 1));
                }
                else if (sourceValue[index].Contains("@") && !strValue.Contains("@"))
                {
                    stringValues.Add("@" + strValue.Substring(0, i - 1));
                }
                else
                    stringValues.Add(strValue.Substring(0, i - 1));
                strValue = strValue.Substring(i - 1);
                stringWidth = g.MeasureString(strValue, font).Width;
            }
            if (index < sourceValue.Length - 1)
            {
                if (split == true && sourceValue[index + 1].Contains("@"))
                    stringValues.Add("@" + strValue);
                else
                    stringValues.Add(strValue);
            }
            else if (index >= sourceValue.Length - 1 && sourceValue[index].Contains("@") && !strValue.Contains("@"))
                stringValues.Add("@" + strValue);
            else
                stringValues.Add(strValue);
            //if (index != _notComputeColumn)
            if (_notComputeColumn == false)
            {
                if (_singleLineNumber.Count <= index)
                    _singleLineNumber.Add(lineNumber);
                else if (_singleLineNumber[index] > lineNumber)
                {
                    while (_singleLineNumber[index] > lineNumber)
                    {
                        stringValues.Add("");
                        lineNumber++;
                    }
                }
                else if (_singleLineNumber[index] < lineNumber)
                {
                    _singleLineNumber[index] = lineNumber;
                }
            }
        }

        /// <summary>
        /// 格式化输出字符串
        /// </summary>
        /// <param name="value">要输出的对象</param>
        /// <returns>格式化结果</returns>
        public static string FormatValue(object value, string format)
        {
            string strValue;
            if (format.Equals("/"))
            {
                strValue = value.ToString();
            }
            else
            {
                if (((format != null) && (!string.IsNullOrEmpty(format)) && (!format.Equals("")) && (value is DateTime))
                    || ((value is float) || (value is decimal) || (value is double)))
                {
                    try
                    {
                        if (value is DateTime)
                        {
                            strValue = ((DateTime)value).ToString(format);
                            if (format.Contains("/"))
                            {
                                strValue = strValue.Replace("-", "/");
                            }
                        }
                        else if ((value is float) || (value is decimal) || (value is double))
                        {
                            strValue = ((double)value).ToString().Trim();
                        }
                        else
                        {
                            strValue = value.ToString();
                        }
                    }
                    catch
                    {
                        strValue = value.ToString();
                    }
                }
                else
                {
                    strValue = value.ToString();
                }
            }

            return strValue;
        }

        /// <summary>
        /// 刷新单元格
        /// </summary>
        public void Refresh(Graphics g, bool isPrint, List<int> _singleLineNumber)
        {
            ///清空缓存
            _stringValues = null;
            _height = 0;
            string v;
            if (_firstFlash == true)
                _startTotalCount = _totalCount;

            ///空值不处理
            if (_value == null) return;

            string strValue = FormatValue(_value, _format);
            if (strValue.Contains("低于机体需要量"))
            {
                int bb = 1;
                bb++;
                int c;
                c = bb;
            }
            ///分割行
            if (_showLetterNo != -1)
            {
                _stringValues = new List<string>();
                v = FormatValue(_value, _format);
                if (v.Equals("要量"))
                {
                    //string a;
                    //a = "a";
                }
                SplitTime(v, _rect.Width, g, _font, _stringValues, false);
                //_stringValues.Add(v);
                _height = _singleLineHeight * _stringValues.Count;
            }
            else if (((_isBreakLine) && (!(_format.Equals("/")))) || (strValue.Contains(LINESPLITCHAR)))
            {
                if (strValue.Contains(LINESPLITCHAR))
                {
                    _stringValues = MakeSplitString(strValue, _rect.Width, g, _font, isPrint, _singleLineNumber);
                }
                else
                {
                    _stringValues = SplitString(strValue, _rect.Width, g, _font, isPrint);
                }
                _height = _singleLineHeight * _stringValues.Count;

                if (!string.IsNullOrEmpty(_signNurse) && !(_signNurse == ""))
                {
                    if (g.MeasureString(_stringValues[_stringValues.Count - 1] + _signNurse, _font).Width + 20 > _rect.Width)
                    {
                        _height += _singleLineHeight;
                    }
                }

                if (_height > _singleLineHeight)
                {
                    _rect.Height = _height;
                }
                else
                {
                    _rect.Height = _singleLineHeight;
                }
            }
            else
            {
                _stringValues = new List<string>();
                v = FormatValue(_value, _format);
                if (v.Equals("要量"))
                {
                    //int b;
                    //b = 1;
                }
                _stringValues.Add(v);
                _height = _singleLineHeight;
            }

            if (_multiline)
            {
                string Temp = string.Empty;
                int i = 0;
                foreach (string CopyStr in _stringValues)
                {
                    if (i == _stringValues.Count)
                    {
                        Temp += CopyStr;
                    }
                    else
                    {
                        Temp += CopyStr + "\r\n";
                    }
                    i++;
                }
                if (Temp.Length > 0)
                {
                    _stringValues.Clear();
                    _stringValues.Add(Temp);
                    _height = _singleLineHeight;
                }
            }

            /////保证空行为空
            //if (!(_height > _singleLineHeight))
            //{
            //    _stringValues = null;
            //}

            ///非空行激活用户高度改变事件
            if (_stringValues != null)
            {
                if (HeightChanged != null)
                {
                    HeightChanged(Height);
                }
            }

            ///计算行数
            CalcLineNumber();
        }

        /// <summary>
        /// 绘制单行
        /// </summary>
        /// <param name="g">作图对象</param>
        /// <param name="topOffSet">纵向位移</param>
        /// <param name="leftOffSet">横向位移</param>
        /// <param name="lineIndex">索引</param>
        public void DrawSingleLine(Graphics g, int topOffSet, int leftOffSet, int lineIndex, bool isPrint)
        {
            DrawSingleLine(g, topOffSet, leftOffSet, lineIndex, false, isPrint);
        }

        /// <summary>
        /// 绘制行边框
        /// </summary>
        /// <param name="g">作图对象</param>
        /// <param name="topOffSet">纵向位移</param>
        /// <param name="leftOffSet">横向位移</param>
        /// <param name="lineIndex">索引</param>
        public void DrawSingleLineRec(Graphics g, int topOffSet, int leftOffSet, int lineIndex, bool isPrint)
        {
            DrawSingleLine(g, topOffSet, leftOffSet, lineIndex, true, isPrint);
        }

        /// <summary>
        /// 绘制单行
        /// </summary>
        /// <param name="g">作图对象</param>
        /// <param name="topOffSet">纵向位移</param>
        /// <param name="leftOffSet">横向位移</param>
        /// <param name="lineIndex">索引</param>
        /// <param name="onlyDrawBorder">是否只绘制边框</param>
        public void DrawSingleLine(Graphics g, int topOffSet, int leftOffSet, int lineIndex, bool onlyDrawBorder, bool isPrint)
        {
            //列合并
            if (_columnsSpan > 1)
            {
                int widthSpan = 0;
                if (_columnsSpan > _columnNo + 1)
                {
                    _columnsSpan = _columnNo + 1;
                }
                for (int i = 1; i < _columnsSpan; i++)  //计算宽度
                {
                    widthSpan = widthSpan + _parentLine[ColumnNo - i]._rect.Width;
                }
                Rectangle rect3 = new Rectangle(leftOffSet + _rect.X - widthSpan, topOffSet, _rect.Width + widthSpan, _rect.Height);
                g.FillRectangle(Brushes.White, rect3);
                g.DrawRectangle(_pen, rect3);
                DrawString(g, this.Value.ToString(), new RectangleF(rect3.X, rect3.Y, rect3.Width, rect3.Height));
                return;
            }
            ///设置纵向位移
            if ((lineIndex == 0) && !onlyDrawBorder)
            {
                _cellTop = topOffSet;
            }

            ///清理区域
            g.FillRectangle(Brushes.Transparent, new Rectangle(leftOffSet + _rect.X, topOffSet, _rect.Width, _singleLineHeight));

            ///画左边
            g.DrawLine(_pen, leftOffSet + _rect.X, topOffSet, leftOffSet + _rect.X, topOffSet + _singleLineHeight);

            ///左边画粗线
            if (_boldVerticalLine == this._columnNo)
            {
                g.DrawLine(new Pen(Color.Black, 4f), leftOffSet + _rect.X, topOffSet, leftOffSet + _rect.X, topOffSet + _singleLineHeight);
            }

            ///画右边
            g.DrawLine(_pen, leftOffSet + _rect.X + _rect.Width, topOffSet, leftOffSet + _rect.X + _rect.Width, topOffSet + _singleLineHeight);

            ///画上边
            if ((lineIndex == 0) || (_hasInnerLine))
            {
                g.DrawLine(_pen, leftOffSet + _rect.X, topOffSet, leftOffSet + _rect.X + _rect.Width, topOffSet);
            }

            ///上面画粗线
            if (lineIndex == 0 && this._parentLine.DrawBoldTopLine == true && !onlyDrawBorder)
            {
                if (this._parentLine.TopLinePen.Color == Color.Black)
                {
                    g.DrawLine(new Pen(Color.Black,_parentLine.DrawBoldLinesize), leftOffSet + _rect.X, topOffSet, leftOffSet + _rect.X + _rect.Width, topOffSet);
                }
                else
                {
                    g.DrawLine(this._parentLine.TopLinePen, leftOffSet + _rect.X, topOffSet, leftOffSet + _rect.X + _rect.Width, topOffSet);
                }
            }

            ///画下边
            if ((_startTotalCount + lineIndex + 1) % _divisionNumberPerPage == 0 && !isPrint && _showInOnePage == true)
            {
                if ((lineIndex == _lineNumber - 1) || ((lineIndex == 0) && (_lineNumber <= 1)) || (_hasInnerLine))
                {
                    g.DrawLine(new Pen(Color.Blue, 10f), leftOffSet + _rect.X, topOffSet + _singleLineHeight, leftOffSet + _rect.X + _rect.Width, topOffSet + _singleLineHeight);
                }
            }
            else
            {
                if ((lineIndex == _lineNumber - 1) || ((lineIndex == 0) && (_lineNumber <= 1)) || (_hasInnerLine))
                {
                    g.DrawLine(_pen, leftOffSet + _rect.X, topOffSet + _singleLineHeight, leftOffSet + _rect.X + _rect.Width, topOffSet + _singleLineHeight);
                }
            }
            //下边画粗线
            if ((lineIndex == _lineNumber - 1) &&  this._parentLine.DrawBoldBottomLine == true && !onlyDrawBorder)
            {
                if (this._parentLine.TopLinePen.Color == Color.Black)
                {
                    g.DrawLine(new Pen(Color.Black, _parentLine.DrawBoldLinesize), leftOffSet + _rect.X, topOffSet + _singleLineHeight, leftOffSet + _rect.X + _rect.Width, topOffSet + _singleLineHeight);
                }
                else
                {
                    g.DrawLine(this._parentLine.TopLinePen, leftOffSet + _rect.X, topOffSet + _singleLineHeight, leftOffSet + _rect.X + _rect.Width, topOffSet + _singleLineHeight);
                }
            }

            //是否画时间列
            if ((_columnNo == 0 || _columnNo == 1) && this._parentLine.DrawTime == false && (_startTotalCount + lineIndex) % LineNumberOfPage != 0)
                return;

            ///写字
            if (!onlyDrawBorder)
            {
                string value = string.Empty;

                if (_stringValues != null)
                {
                    ///放置底部
                    if ((_singleLineAlignBottom) && (lineIndex == _lineNumber - 1))
                    {
                        value = _stringValues[0].ToString();
                    }
                    else if ((_stringValues.Count > lineIndex) && (!_singleLineAlignBottom))
                    {
                        if (_stringValues[lineIndex] == null)
                        {
                            _stringValues[lineIndex] = string.Empty;
                        }
                        value = _stringValues[lineIndex].ToString();
                    }
                }

                if ((!string.IsNullOrEmpty(value)) && (!value.Equals("")))
                {
                    if (value.Contains("※") || value.Contains("@"))
                        DrawString(g, value.Substring(1), new RectangleF(leftOffSet + _rect.X, topOffSet, _rect.Width, _singleLineHeight));
                    else
                        DrawString(g, value, new RectangleF(leftOffSet + _rect.X, topOffSet, _rect.Width, _singleLineHeight));
                }

                if (!string.IsNullOrEmpty(_signNurse) && !(_signNurse == "") && (lineIndex == (LineNumber - 1)))
                {
                    g.DrawString(_signNurse, Font, Brush, leftOffSet + _rect.X + _rect.Width - g.MeasureString(_signNurse, Font).Width, topOffSet + (_singleLineHeight - g.MeasureString("A", Font).Height) / 2);
                    //DrawString(g, _signNurse, new RectangleF(leftOffSet + _rect.X, topOffSet, _rect.Width, _singleLineHeight));
                }
            }
        }

        /// <summary>
        /// 绘制旁边画线的单行
        /// </summary>
        /// <param name="g">作图对象</param>
        /// <param name="topOffSet">纵向位移</param>
        /// <param name="leftOffSet">横向位移</param>
        /// <param name="lineIndex">索引</param>
        /// <param name="onlyDrawBorder">是否只绘制边框</param>
        public void DrawSingleLineWithRec(Graphics g, int topOffSet, int leftOffSet, int lineIndex, bool onlyDrawBorder, bool isPrint)
        {
            //列合并
            if (_columnsSpan > 1)
            {
                int widthSpan = 0;
                if (_columnsSpan > _columnNo + 1)
                {
                    _columnsSpan = _columnNo + 1;
                }
                for (int i = 1; i < _columnsSpan; i++)  //计算宽度
                {
                    widthSpan = widthSpan + _parentLine[ColumnNo - i]._rect.Width;
                }
                Rectangle rect3 = new Rectangle(leftOffSet + _rect.X - widthSpan, topOffSet, _rect.Width + widthSpan, _rect.Height);
                g.FillRectangle(Brushes.White, rect3);
                g.DrawRectangle(_pen, rect3);
                DrawString(g, this.Value.ToString(), new RectangleF(rect3.X, rect3.Y, rect3.Width, rect3.Height));
                return;
            }
            ///设置纵向位移
            if ((lineIndex == 0) && !onlyDrawBorder)
            {
                _cellTop = topOffSet;
            }

            ///清理区域
            g.FillRectangle(Brushes.Transparent, new Rectangle(leftOffSet + _rect.X, topOffSet, _rect.Width, _singleLineHeight));

            ///画左边
            g.DrawLine(_pen, leftOffSet + _rect.X, topOffSet, leftOffSet + _rect.X, topOffSet + _singleLineHeight);

            ///画右边
            g.DrawLine(_pen, leftOffSet + _rect.X + _rect.Width, topOffSet, leftOffSet + _rect.X + _rect.Width, topOffSet + _singleLineHeight);

            ///画上边
            if ((lineIndex == 0) || (_hasInnerLine))
            {
                g.DrawLine(_pen, leftOffSet + _rect.X, topOffSet, leftOffSet + _rect.X + _rect.Width, topOffSet);
            }

            ///上面画粗线
            if (lineIndex == 0 && this._parentLine.DrawBoldTopLine == true && !onlyDrawBorder)
            {
                if (this._parentLine.TopLinePen.Color == Color.Black)
                {
                    g.DrawLine(new Pen(Color.Black, _parentLine.DrawBoldLinesize), leftOffSet + _rect.X, topOffSet, leftOffSet + _rect.X + _rect.Width, topOffSet);
                }
                else
                {
                    g.DrawLine(this._parentLine.TopLinePen, leftOffSet + _rect.X, topOffSet, leftOffSet + _rect.X + _rect.Width, topOffSet);
                }
            }

            ///画下边
            if ((_startTotalCount + lineIndex + 1) % _divisionNumberPerPage == 0 && !isPrint && _showInOnePage == true)
            {
                g.DrawLine(new Pen(Color.Blue, 10f), leftOffSet + _rect.X, topOffSet + _singleLineHeight, leftOffSet + _rect.X + _rect.Width, topOffSet + _singleLineHeight);
            }
            else
            {
                if ((lineIndex == _lineNumber - 1) || ((lineIndex == 0) && (_lineNumber <= 1)) || (_hasInnerLine))
                {
                    g.DrawLine(_pen, leftOffSet + _rect.X, topOffSet + _singleLineHeight, leftOffSet + _rect.X + _rect.Width, topOffSet + _singleLineHeight);
                }
            }
            //下边画粗线
            if ((lineIndex == _lineNumber - 1) && this._parentLine.DrawBoldBottomLine == true && !onlyDrawBorder)
            {
                if (this._parentLine.TopLinePen.Color == Color.Black)
                {
                    g.DrawLine(new Pen(Color.Black, _parentLine.DrawBoldLinesize), leftOffSet + _rect.X, topOffSet + _singleLineHeight, leftOffSet + _rect.X + _rect.Width, topOffSet + _singleLineHeight);
                }
                else
                {
                    g.DrawLine(this._parentLine.TopLinePen, leftOffSet + _rect.X, topOffSet + _singleLineHeight, leftOffSet + _rect.X + _rect.Width, topOffSet + _singleLineHeight);
                }
            }
            ///写字
            if (!onlyDrawBorder)
            {
                string value = string.Empty;

                if (_stringValues != null)
                {
                    ///放置底部
                    if ((_singleLineAlignBottom) && (lineIndex == _lineNumber - 1))
                    {
                        value = _stringValues[0].ToString();
                    }
                    else if ((_stringValues.Count > lineIndex) && (!_singleLineAlignBottom))
                    {
                        value = _stringValues[lineIndex].ToString();
                    }
                }

                //if ((!string.IsNullOrEmpty(value)) && (!value.Equals("")))
                if (!string.IsNullOrEmpty(value))
                {
                    if (value.Contains("※") || value.Contains("@"))
                        DrawString(g, value.Substring(1), new RectangleF(leftOffSet + _rect.X, topOffSet, _rect.Width, _singleLineHeight));
                    else
                        DrawString(g, value, new RectangleF(leftOffSet + _rect.X, topOffSet, _rect.Width, _singleLineHeight));
                    if (lineIndex < _stringValues.Count - 1 && value.Contains("※"))
                    {
                        if (_stringValues[lineIndex + 1].Contains("@"))
                        {
                            g.DrawLine(_pen, leftOffSet + _rect.X + _rect.Width - 15, topOffSet + 4, leftOffSet + _rect.X + _rect.Width - 5, topOffSet + 4);
                            g.DrawLine(_pen, leftOffSet + _rect.X + _rect.Width - 5, topOffSet + 4, leftOffSet + _rect.X + _rect.Width - 5, topOffSet + _singleLineHeight);
                        }
                        else if (_stringValues[lineIndex + 1].Contains("#"))
                            return;
                        else if (_stringValues[lineIndex + 1].Contains("※"))
                            return;
                        else
                        {
                            for (int li = lineIndex + 2; li < _stringValues.Count; li++)
                            {
                                if (_stringValues[li].Contains("@"))
                                {
                                    g.DrawLine(_pen, leftOffSet + _rect.X + _rect.Width - 15, topOffSet + 4, leftOffSet + _rect.X + _rect.Width - 5, topOffSet + 4);
                                    g.DrawLine(_pen, leftOffSet + _rect.X + _rect.Width - 5, topOffSet + 4, leftOffSet + _rect.X + _rect.Width - 5, topOffSet + _singleLineHeight);
                                    break;
                                }
                                else if (_stringValues[li].Contains("※"))
                                    break;
                            }
                        }
                    }
                    else if (value.Contains("@"))
                    {
                        if (lineIndex < _stringValues.Count - 1)
                        {
                            if (_stringValues[lineIndex + 1].Contains("@"))
                                g.DrawLine(_pen, leftOffSet + _rect.X + _rect.Width - 5, topOffSet, leftOffSet + _rect.X + _rect.Width - 5, topOffSet + _singleLineHeight);
                            else
                            {
                                g.DrawLine(_pen, leftOffSet + _rect.X + _rect.Width - 15, topOffSet + _singleLineHeight - 4, leftOffSet + _rect.X + _rect.Width - 5, topOffSet + _singleLineHeight - 4);
                                g.DrawLine(_pen, leftOffSet + _rect.X + _rect.Width - 5, topOffSet, leftOffSet + _rect.X + _rect.Width - 5, topOffSet + _singleLineHeight - 4);
                            }
                        }
                        else
                        {
                            g.DrawLine(_pen, leftOffSet + _rect.X + _rect.Width - 15, topOffSet + _singleLineHeight - 4, leftOffSet + _rect.X + _rect.Width - 5, topOffSet + _singleLineHeight - 4);
                            g.DrawLine(_pen, leftOffSet + _rect.X + _rect.Width - 5, topOffSet, leftOffSet + _rect.X + _rect.Width - 5, topOffSet + _singleLineHeight - 4);
                        }
                    }
                }
                else
                {
                    if (_stringValues == null)
                        return;
                    for (int li = lineIndex + 1; li < _stringValues.Count; li++)
                    {
                        if (_stringValues[li].Contains("@"))
                        {
                            g.DrawLine(_pen, leftOffSet + _rect.X + _rect.Width - 5, topOffSet, leftOffSet + _rect.X + _rect.Width - 5, topOffSet + _singleLineHeight);
                            break;
                        }
                        else if (_stringValues[li].Contains("※"))
                            break;
                    }
                }

                if (!string.IsNullOrEmpty(_signNurse) && !(_signNurse == "") && (lineIndex == (LineNumber - 1)))
                {
                    g.DrawString(_signNurse, Font, Brush, leftOffSet + _rect.X + _rect.Width - g.MeasureString(_signNurse, Font).Width, topOffSet + (_singleLineHeight - g.MeasureString("A", Font).Height) / 2);
                }
            }
        }

        /// <summary>
        /// 合并行高
        /// </summary>
        /// <returns>合并行高</returns>
        private int SpanHeight()
        {
            int height = 0;
            if (_rowSpan > 1)
            {
                int span = _rowSpan;
                PrintLine line = _parentLine.PriorLine;
                while ((span > 1) && (line != null))
                {
                    height += line.Height;
                    span--;
                    line = line.PriorLine;
                }
                if (_startTotalCount != 0)
                {
                    if (height > _startTotalCount % LineNumberOfPage * _singleLineHeight)
                    {
                        return _startTotalCount % LineNumberOfPage * _singleLineHeight;
                    }
                }
            }
            return height;
        }

        /// <summary>
        /// 画单元格
        /// </summary>
        /// <param name="g">作图对象</param>
        /// <param name="topOffSet">顶端位移</param>
        /// <param name="leftOffSet">左边位移</param>
        public void Draw(Graphics g, int topOffSet, int leftOffSet, bool isPrint)
        {
            int height = SpanHeight();
            int downHeight = 0;
            //列合并
            if (_columnsSpan > 1)
            {
                int widthSpan = 0, rowSpanHeight = 0; ;
                if (_columnsSpan > _columnNo + 1)
                {
                    _columnsSpan = _columnNo + 1;
                }
                for (int i = 1; i < _columnsSpan; i++)  //计算宽度
                {
                    widthSpan = widthSpan + _parentLine[ColumnNo - i]._rect.Width;
                }
                if (this.RowSpan > 1)
                {
                    PrintLine line = this.ParentLine;
                    for (int i = 0; i < this.RowSpan - 1; i++)
                    {
                        line = line.PriorLine;
                        rowSpanHeight = rowSpanHeight + line.LineNumber * line.SingleLineHeight;
                    }
                }
                //Rectangle rect3 = new Rectangle(leftOffSet + _rect.X - widthSpan, topOffSet - rowSpanHeight, _rect.Width + widthSpan, _rect.Height + rowSpanHeight);
                Rectangle rect3 = new Rectangle(leftOffSet + _rect.X - widthSpan, topOffSet - rowSpanHeight, _rect.Width, _rect.Height + rowSpanHeight);
                g.FillRectangle(Brushes.White, rect3);
                g.DrawRectangle(_pen, rect3);
                DrawString(g, this.Value.ToString(), new RectangleF(rect3.X, rect3.Y, rect3.Width, rect3.Height));
                return;
            }
            //行合并，处理换页情况
            if (_parentLine.NextLine != null && _parentLine.NextLine.Count > ColumnNo && _parentLine.NextLine[ColumnNo].RowSpan > 1)
            {
                if (_startTotalCount % LineNumberOfPage > _parentLine.NextLine[ColumnNo]._startTotalCount % LineNumberOfPage)
                {
                    if (_parentLine.NextLine[ColumnNo]._startTotalCount % LineNumberOfPage == 0)
                    {
                        downHeight = _parentLine.NextLine[ColumnNo].Height;
                    }
                    else
                    {
                        downHeight = (_parentLine.NextLine.LineNumber - _parentLine.NextLine[ColumnNo]._startTotalCount % LineNumberOfPage) * _singleLineHeight;
                    }
                    if (_parentLine.NextLine[ColumnNo].Value != this.Value)
                    {
                        Rectangle rect1 = new Rectangle(leftOffSet + _rect.X, topOffSet + height, _rect.Width, downHeight);
                        g.FillRectangle(Brushes.White, rect1);
                        g.DrawRectangle(_pen, rect1);
                    }
                }
            }
            if (_startTotalCount != 0 && _startTotalCount / LineNumberOfPage != (_startTotalCount + _parentLine.LineNumber) / LineNumberOfPage)
            {
                int topHeight = 0;
                downHeight = -((_startTotalCount + _parentLine.LineNumber) % LineNumberOfPage) * _singleLineHeight;
                foreach (PrintLine line in _parentLine.HeadLines)
                {
                    topHeight += line.Height;
                }
                if (topOffSet - height < topHeight)
                {
                    height = 0;
                    downHeight = -((LineNumberOfPage - _startTotalCount) % LineNumberOfPage) * _singleLineHeight;
                }
                Rectangle rect2 = new Rectangle(leftOffSet + _rect.X, topOffSet - height, _rect.Width, _rect.Height + height + downHeight);
                g.FillRectangle(Brushes.White, rect2);
                g.DrawRectangle(_pen, rect2);
                DrawString(g, this.Value.ToString(), new RectangleF(rect2.X, rect2.Y, rect2.Width, rect2.Height));
                return;
            }
            //int height = SpanHeight();
            //Rectangle rect = new Rectangle(leftOffSet + _rect.X, topOffSet - height, _rect.Width, _rect.Height + height);
            Rectangle rect = new Rectangle(leftOffSet + _rect.X, topOffSet - height, _rect.Width, _rect.Height + height + downHeight);
            g.FillRectangle(Brushes.White, rect);
            g.DrawRectangle(_pen, rect);

            int y = topOffSet;
            if (_stringValues != null)
            {
                foreach (string strValue in _stringValues)
                {
                    //DrawString(g, strValue, new RectangleF(rect.X, rect.Y - height, rect.Width, rect.Height + height));
                    if (_rowSpan > 1 && this.Value.ToString() != "")
                    {
                        DrawString(g, this.Value.ToString(), new RectangleF(rect.X, rect.Y, rect.Width, rect.Height));
                    }
                    else
                    {
                        DrawString(g, strValue, new RectangleF(rect.X, rect.Y, rect.Width, rect.Height));
                    }
                    if (_hasInnerLine && (y > topOffSet))
                    {
                        g.DrawLine(Pen, leftOffSet + _rect.X, y - height, leftOffSet + _rect.X + _rect.Width, y - height);
                    }
                    y += _singleLineHeight;
                }
                if ((_lineNumber > _stringValues.Count) && _hasInnerLine && RowSpan < 2)
                {
                    for (int i = _stringValues.Count; i < _lineNumber; i++)
                    {
                        g.DrawLine(Pen, leftOffSet + _rect.X, y - height, leftOffSet + _rect.X + _rect.Width, y - height);
                        y += _singleLineHeight;
                    }
                }
            }
            else
            {
                DrawString(g, _value.ToString(), new RectangleF(leftOffSet + _rect.X, topOffSet - height, _rect.Width, _singleLineHeight + height));
                if ((_lineNumber > 1) && _hasInnerLine && RowSpan < 2)
                {
                    y = topOffSet;
                    for (int i = 1; i < _lineNumber; i++)
                    {
                        y += _singleLineHeight;
                        g.DrawLine(Pen, leftOffSet + _rect.X, y - height, leftOffSet + _rect.X + _rect.Width, y - height);
                    }
                }
            }
        }

        /// <summary>
        /// 画单行文本字符串
        /// </summary>
        /// <param name="g"></param>
        /// <param name="strValue"></param>
        /// <param name="rectF"></param>
        public void DrawString(Graphics g, string strValue, RectangleF rectF)
        {
            if (_format.Equals("/"))
            {
                if (!(strValue.Replace(",", "").Trim() == ""))
                {
                    string strDraw;
                    int splitIndex = strValue.IndexOf(",");
                    g.DrawLine(_pen, rectF.X, rectF.Y + rectF.Height - 10, rectF.X + rectF.Width, rectF.Y + 10);
                    try
                    {
                        strDraw = (double.Parse(strValue.Substring(0, splitIndex))).ToString();
                    }
                    catch
                    {
                        strDraw = strValue.Substring(0, splitIndex);
                    }
                    g.DrawString(strDraw, _font, _brush, rectF.X + (rectF.Width - g.MeasureString(strDraw, _font).Width) / 2, rectF.Y + 1);
                    try
                    {
                        strDraw = (double.Parse(strValue.Substring(splitIndex + 1))).ToString();
                    }
                    catch
                    {
                        strDraw = strValue.Substring(splitIndex + 1);
                    }
                    g.DrawString(strDraw, _font, _brush, rectF.X + (rectF.Width - g.MeasureString(strDraw, _font).Width) / 2, rectF.Y + 18);
                }
            }
            else
            {
                string strDraw = strValue;// strValue.Replace(LINESPLITCHAR, "");
                if ((_isBreakLine) || (g.MeasureString(strDraw, _font).Width <= rectF.Width))
                {
                    switch (TextAlign)
                    {
                        case ContentAlignment.MiddleLeft:
                            g.DrawString(strDraw, _font, _brush, rectF.X, rectF.Y + (rectF.Height - g.MeasureString(strDraw, _font).Height) / 2);
                            break;
                        case ContentAlignment.MiddleCenter:
                            g.DrawString(strDraw, _font, _brush, rectF.X + (rectF.Width - g.MeasureString(strDraw, _font).Width) / 2, rectF.Y + (rectF.Height - g.MeasureString(strValue, _font).Height) / 2);
                            break;
                        case ContentAlignment.TopLeft:
                            if (strDraw.Length > _showLetterNo && _showLetterNo != -1)
                            {
                                g.DrawString(strDraw.Substring(0, _showLetterNo), _font, _brush, rectF.X, rectF.Y + 5);
                                g.DrawString(strDraw.Substring(_showLetterNo), _font, _brush, rectF.X, rectF.Y + _font.Size + 9);
                            }
                            else
                                g.DrawString(strDraw, _font, _brush, rectF.X, rectF.Y);
                            break;
                        case ContentAlignment.MiddleRight:
                            g.DrawString(strDraw, _font, _brush, rectF.X + (rectF.Width - g.MeasureString(strDraw, _font).Width), rectF.Y + (rectF.Height - g.MeasureString(strValue, _font).Height) / 2);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        /// <summary>
        /// 获取表格对应的日期时间点
        /// </summary>
        /// <param name="getPriorLine">是否取上一行的时间点</param>
        /// <returns></returns>
        public DateTime GetLineDateTime(bool getPriorLine)
        {
            PrintLine HaveTimeLine;
            //int CheckResult = -1;
            DateTime ResultDateTimePoint = new DateTime(1900, 1, 1);
            if (getPriorLine)
            {
                HaveTimeLine = ParentLine.PriorLine;
            }
            else
            {
                HaveTimeLine = ParentLine;
            }
            //if (HaveTimeLine != null)
            //{
            //    if (HaveTimeLine[0].Value == null || HaveTimeLine[1].Value == null)
            //    {
            //        return ResultDateTimePoint;
            //    }
            //    ///校验月
            //    int.TryParse(HaveTimeLine[0].Value.ToString().Split('-')[0], out CheckResult);
            //    if (CheckResult == 0 || CheckResult > 12)
            //    {
            //        return ResultDateTimePoint;
            //    }
            //    ///校验日
            //    int.TryParse(HaveTimeLine[0].Value.ToString().Split('-')[1], out CheckResult);
            //    if (CheckResult == 0 || CheckResult > 31)
            //    {
            //        return ResultDateTimePoint;
            //    }
            //    ///校验小时
            //    if (!int.TryParse(HaveTimeLine[1].Value.ToString().Split(':')[0], out CheckResult))
            //    {
            //        return ResultDateTimePoint;
            //    }
            //    if (CheckResult > 24)
            //    {
            //        return ResultDateTimePoint;
            //    }
            //    ///校验分钟
            //    if (!int.TryParse(HaveTimeLine[1].Value.ToString().Split(':')[1], out CheckResult))
            //    {
            //        return ResultDateTimePoint;
            //    }
            //    if (CheckResult > 60)
            //    {
            //        return ResultDateTimePoint;
            //    }
            //    ResultDateTimePoint = new DateTime(DateTime.Now.Year,
            //                                          int.Parse(HaveTimeLine[0].Value.ToString().Split('-')[0]),
            //                                          int.Parse(HaveTimeLine[0].Value.ToString().Split('-')[1]),
            //                                          int.Parse(HaveTimeLine[1].Value.ToString().Split(':')[0]),
            //                                          int.Parse(HaveTimeLine[1].Value.ToString().Split(':')[1]),
            //                                          0);
            //}
            return HaveTimeLine.TimePoint;
        }

        public void setStringValue(string newValue, int index)
        {
            if (_stringValues != null)
            {
                if (index < _stringValues.Count)
                {
                    _stringValues[index] = newValue;
                }
            }

        }

        public PrintCell Copy()
        {
            PrintCell cell = new PrintCell();
            cell._stringValues = new List<string>();
            if (this._stringValues != null)
            {
                for (int i = 0; i < _stringValues.Count; i++)
                {
                    cell._stringValues.Add(_stringValues[i]);
                }
            }
            cell._height = this._height;
            cell._rect = this._rect;
            cell._singleLineHeight = this._singleLineHeight;
            cell._brush = this._brush;
            cell._pen = this._pen;
            cell._cellTop = this._cellTop;
            cell._rowSpan = this._rowSpan;
            cell._columnsSpan = this._columnsSpan;
            cell.Value = this.Value;
            cell._parentLine = this._parentLine;
            cell._textAlign = this._textAlign;
            return cell;
        }

        /// <summary>
        /// Dispose-释放资源
        /// </summary>
        public void Dispose()
        {
            _stringValues = null;
        }

        #region Function 2010-05-14

        #region 2010-05-14 数字不要断行显示
        //2010-05-14 数字不要断行显示
        public static void NumberDoNotBreakLine(string strValue, float w, Graphics g, Font font, ref int i)
        {
            if (i < strValue.Length + 1 && i > 1)
            {
                string strTest = strValue.Substring(i - 2, 2);

                double dTestValue;
                if (double.TryParse(strTest, out dTestValue) == true)
                {
                    int j, k;
                    //往前寻找
                    for (j = 1; j < i - 2; j++)
                    {
                        strTest = strValue[i - 2 - j] + strTest;

                        if (double.TryParse(strTest, out dTestValue) == true)
                        {
                            continue;
                        }
                        else
                        {
                            strTest = strTest.Substring(1);
                            break;
                        }
                    }

                    //往后寻找
                    for (k = i; k < strValue.Length; k++)
                    {
                        strTest = strTest + strValue[k];

                        if (double.TryParse(strTest, out dTestValue) == true)
                        {
                            continue;
                        }
                        else
                        {
                            strTest = strTest.Substring(0, strTest.Length - 1);
                            break;
                        }
                    }

                    //数字不超过一行的宽度，否则换行也没有意义
                    if (g.MeasureString(strTest, font).Width > w)
                    {
                        //DoNothing
                    }
                    else
                    {
                        //重新截位
                        i -= j;
                    }
                }
            }
        }

        #endregion

        #endregion
    }
}
