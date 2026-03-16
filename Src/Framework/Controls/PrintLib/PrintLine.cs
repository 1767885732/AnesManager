using System;
using System.Collections;
using System.Text;
using System.Drawing;
using System.Collections.Generic;

namespace Wis.Anes.Framework.Controls
{
    public class PrintLine : CollectionBase
    {

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
        /// 行高
        /// </summary>
        private int _height = 0;

        /// <summary>
        /// 行数
        /// </summary>
        private int _lineNumber = 1;

        /// <summary>
        /// 上一行
        /// </summary>
        private PrintLine _priorLine;

        /// <summary>
        /// 下一行
        /// </summary>
        private PrintLine _nextLine;

        /// <summary>
        /// 前景颜色
        /// </summary>
        private Color _foreColor;

        /// <summary>
        /// 医嘱标记
        /// </summary>
        private bool _orderTag;

        /// <summary>
        /// 字体
        /// </summary>
        private Font _font = new Font("宋体", 9);

        /// <summary>
        /// 每一个值所占的行数
        /// </summary>
        private List<int> _singleLineNumber = new List<int>();

        /// <summary>
        /// 不计算行数的列
        /// </summary>
        private int _notComputeColumn = -1;

        /// <summary>
        /// 截取的行数
        /// </summary>
        private int _removeLineNo = 0;

        /// <summary>
        /// 是否画时间列
        /// </summary>
        private bool _drawTime = true;

        /// <summary>
        /// 每行时间点
        /// </summary>
        private DateTime _timePoint = new DateTime(1900,1,1);

        /// <summary>
        /// 单元格上面的线是否画粗线
        /// </summary>
        private bool _drawBoldTopLine = false;

        /// <summary>
        /// 单元格下面的线是否画粗线
        /// </summary>
        private bool _drawBoldBottomLine = false;

        /// <summary>
        /// 上下画线的Size
        /// </summary>
        private float _drawBoldLinesize = 4f;

        /// <summary>
        /// 日期格式化样式
        /// </summary>
        private string _dateFormat = "dd/MM";

        /// <summary>
        /// 上边线颜色
        /// </summary>
        private Pen _topLinePen = new Pen(Color.Black);

        /// <summary>
        /// 所包括标题行
        /// </summary>
        protected List<PrintLine> _headLines = new List<PrintLine>();

        /// <summary>
        /// 每页的行数
        /// </summary>
        private int _lineNumberOfPage = 32;
        #endregion 变量

        #region 属性

        /// <summary>
        /// 上一行
        /// </summary>
        public PrintLine PriorLine
        {
            get
            {
                return _priorLine;
            }
            set
            {
                _priorLine = value;
            }
        }
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
                foreach (PrintCell cell in this)
                {
                    cell.Multiline = this._multiline;
                }
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
                foreach (PrintCell cell in this)
                {
                    cell.Font = this._font;
                }
            }
        }


        /// <summary>
        /// 下一行
        /// </summary>
        public PrintLine NextLine
        {
            get
            {
                return _nextLine;
            }
            set
            {
                _nextLine = value;
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
                foreach (PrintCell cell in this)
                {
                    cell.TextAlign = value;
                }
            }
        }

        /// <summary>
        /// 行高
        /// </summary>
        public int Height
        {
            get
            {
                if (_height <= 0)
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
                _singleLineHeight = value;
            }
        }

        /// <summary>
        /// 行宽
        /// </summary>
        public int Width
        {
            get
            {
                int _width = 0;
                foreach (PrintCell cell in this)
                {
                    _width += cell.Rect.Width;
                }
                return _width;
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
        /// 单元格
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public PrintCell this[int index]
        {
            get
            {
                return (PrintCell)List[index];
            }
            set
            {
                List[index] = value;
            }
        }

        /// <summary>
        /// 单行高度
        /// </summary>
        private int _singleLineHeight = 0;

        public int SingleLineHeight
        {
            get
            {
                return _singleLineHeight;
            }
            set
            {
                _singleLineHeight = value;
                foreach (PrintCell cell in this)
                {
                    cell.SingleLineHeight = value;
                }
            }
        }

        /// <summary>
        /// 前景颜色
        /// </summary>
        public Color ForeColor
        {
            get
            {
                return _foreColor;
            }
            set
            {
                _foreColor = value;
                foreach (PrintCell cell in this)
                {
                    cell.Brush = new SolidBrush(_foreColor);
                }
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
        public int NotComputeColumn
        {
            set
            {
                _notComputeColumn = value;
            }
        }

        /// <summary>
        /// 截取的行数
        /// </summary>
        public int RemoveLineNo
        {
            get
            {
                return _removeLineNo;
            }
            set
            {
                _removeLineNo = value;
            }
        }

        /// <summary>
        /// 是否画时间列
        /// </summary>
        public bool DrawTime
        {
            get
            {
                return _drawTime;
            }
            set
            {
                _drawTime = value;
            }
        }

        /// <summary>
        /// 单元格上面的线是否画粗线
        /// </summary>
        public bool DrawBoldTopLine
        {
            get
            {
                return _drawBoldTopLine;
            }
            set
            {
                _drawBoldTopLine = value;
            }
        }
        /// <summary>
        /// 单元格下面的线是否画粗线
        /// </summary>
        public bool DrawBoldBottomLine
        {
            get
            {
                return _drawBoldBottomLine;
            }
            set
            {
                _drawBoldBottomLine = value;
            }
        }

        /// <summary>
        /// 上下单元格的线粗
        /// 请使用 4f,3f,2f,1f表示
        /// </summary>
        public float DrawBoldLinesize
        {
            get
            { 
                return _drawBoldLinesize;
            }
            set
            {
                _drawBoldLinesize = value;
            }
        }


        /// <summary>
        /// 行的时间点
        /// </summary>
        public DateTime TimePoint
        {
            get
            {
                return _timePoint;
            }
            set
            {
                _timePoint = value;
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
                this[0].DateFormat = value;
            }
            get
            {
                return _dateFormat;
            }
        }

        /// <summary>
        /// 上边线颜色
        /// </summary>
        public Pen TopLinePen
        {
            get
            {
                return _topLinePen;
            }
            set
            {
                _topLinePen = value;
            }
        }
        /// <summary>
        /// 标题行
        /// </summary>
        public List<PrintLine> HeadLines
        {
            get
            {
                return _headLines;
            }
            set
            {
                _headLines = value;
            }
        }

        /// <summary>
        /// 每页的行数
        /// </summary>
        public int LineNumberOfPage
        {
            get
            {
                return _lineNumberOfPage;
            }
            set
            {
                _lineNumberOfPage = value;
            }
        }

        #endregion

        #region 方法

        public PrintLine()
        {
        }

        public void Refresh(Graphics graphicsSource, bool isPrint)
        {
            int column = 0;

            foreach (PrintCell cell in this)
            {
                cell.LineNumberOfPage = this.LineNumberOfPage;
                if (_orderTag == true)
                    cell.OrderTag = true;
                if (column == this._notComputeColumn)
                    cell.NotComputeColumn = true;
                cell.ColumnNo = column;
                cell.Refresh(graphicsSource, isPrint, _singleLineNumber);
                if (cell.Height > _height)
                {
                    _height = cell.Height;
                }
                if (cell.LineNumber > _lineNumber)
                {
                    _lineNumber = cell.LineNumber;
                }
                column++;
            }

            foreach (PrintCell cell in this)
            {
                cell.CurrentCellCellLineNo = _lineNumber;
                cell.Refresh(graphicsSource, isPrint, _singleLineNumber);
                cell.Height = _height;
                cell.CurrentCellCellLineNo = _lineNumber;
            }
            PrintCell.TotalCount = PrintCell.TotalCount + _lineNumber;
        }

        public void RefreshLine(Graphics graphicsSource, bool isPrint)
        {
            int column = 0;

            foreach (PrintCell cell in this)
            {
                cell.LineNumberOfPage = this.LineNumberOfPage;
                if (_orderTag == true)
                    cell.OrderTag = true;
                if (column == this._notComputeColumn)
                    cell.NotComputeColumn = true;
                cell.ColumnNo = column;
                cell.Refresh(graphicsSource, isPrint, _singleLineNumber);
                if (cell.Height > _height)
                {
                    _height = cell.Height;
                }
                if (cell.LineNumber > _lineNumber)
                {
                    _lineNumber = cell.LineNumber;
                }
                column++;
            }
        }

        /// <summary>
        /// 添加单元格
        /// </summary>
        /// <param name="cell">单元格</param>
        public void addCell(PrintCell cell)
        {
            if (cell.SingleLineHeight == 0)
            {
                cell.SingleLineHeight = _singleLineHeight;
            }
            //cell.Refresh();
            //if (cell.Height > _height)
            //{
            //    _height = cell.Height;
            //}
            //if (cell.LineNumber > _lineNumber)
            //{
            //    _lineNumber = cell.LineNumber;
            //}
            cell.ParentLine = this;
            List.Add(cell);
            //if(_height > _singleLineHeight)foreach (PrintCell cell0 in this) cell0.Height = _height;
        }

        /// <summary>
        /// 画行
        /// </summary>
        /// <param name="g">作图对象</param>
        /// <param name="line">行</param>
        /// <param name="topOffSet">顶端位移</param>
        /// <param name="leftOffSet">左边位移</param>
        public void Draw(Graphics g, int topOffSet, int leftOffSet, bool isPrint)
        {
            int columnNo = 0;
            foreach (PrintCell cell in this)
            {
                cell.ColumnNo = columnNo;
                columnNo++;
                cell.Draw(g, topOffSet, leftOffSet, isPrint);
            }
        }

        /// <summary>
        /// 复制本行
        /// </summary>
        /// <returns></returns>
        public PrintLine Copy()
        {
            PrintLine line = new PrintLine();
            foreach (PrintCell cell in this)
            {
                PrintCell ce = cell.Copy();
                line.addCell(ce);
            }
            return line;
        }
        #endregion
    }
}
