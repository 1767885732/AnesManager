/*----------------------------------------------------------------
      // Copyright (C) 2010 北京拓扑工厂科技发展有限公司
      // 文件名：MonitorDataItem.cs
      // 文件功能描述：监护数据项目
      //
      // 
      // 创建标识：XXX-2010-11-01
      // 修改标识：
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Wis.Anes.Views
{
    /// <summary>
    /// 监护数据项目
    /// </summary>
    public class MonitorDataItem
    {
        private string _itemName;
        private double _minValue;
        private double _maxValue;
        private Color _color;
        private Font _font;

        public string ItemName
        {
            get
            {
                return _itemName;
            }
            set
            {
                _itemName = value;
            }
        }
        public double MinValue
        {
            get
            {
                return _minValue;
            }
            set
            {
                _minValue = value;
            }
        }
        public double MaxValue
        {
            get
            {
                return _maxValue;
            }
            set
            {
                _maxValue = value;
            }
        }
        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }
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
        public MonitorDataItem(string itemName, Color color,Font font, double minValue, double maxValue)
        {
            _itemName = itemName;
            _color = color;
            _minValue = minValue;
            _maxValue = maxValue;
            _font = font;
        }
        public MonitorDataItem(string itemName, Color color, Font font, double value)
            : this(itemName, color, font, value, value)
        {

        }
        public void Draw(Graphics g, float x, float y)
        {
            Draw(g, x, y, 0);
        }
        public void Draw(Graphics g, float x, float y,float width)
        {
            string text = _itemName;
            g.DrawString(text, _font, new SolidBrush(_color), x, y);
            float yOffSet = g.MeasureString(text, _font).Height + 5;
            text = _minValue.ToString();
            if (_maxValue != _minValue)
            {
                text += "/" + _maxValue.ToString();
                if (text.Equals("-1000/-1000"))
                {
                    text = "/";
                }
            }
            if (text.Equals("-1000"))
            {
                text = "";
            }
            if (width > 0)
            {
                g.DrawString(text, _font, new SolidBrush(_color), width - g.MeasureString(text,_font).Width, y + yOffSet);
            }
            else
            {
                g.DrawString(text, _font, new SolidBrush(_color), x, y + yOffSet);
            }
        }
    }
}
