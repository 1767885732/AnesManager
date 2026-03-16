using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Wis.Anes.Framework.Controls
{
    [Serializable]
    ///事件索引表格控件-保存单元格
    public class MedGridGraphSavedCell
    {
        public RectangleF Rect;
        public int StartIndex;
        public int EndIndex;
        public int StartCount;
        public MedGridGraphRow Row;
        public MedGridGraphSavedCell(MedGridGraphRow row, RectangleF rect, int startIndex, int endIndex, int startCount)
        {
            Row = row;
            Rect = rect;
            StartIndex = startIndex;
            EndIndex = endIndex;
            StartCount = startCount;
        }
    }
}
