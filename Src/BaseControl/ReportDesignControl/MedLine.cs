using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;

namespace Com.ICIS.Common.Controls
{
    public enum MedLineType
    {
        [Description("垂直")]
        Vertical,
        [Description("水平")]
        Horizontal,
        [Description("普通")]
        Normal
    }

    public class MedLine2
    {
        private Color _color = Color.Red;
        [Description("颜色")]
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

        private int _width = 1;
        [Description("宽度")]
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }
        private float _x1, _x2, _y1, _y2;
        [Description("X1")]
        public float X1
        {
            get
            {
                return _x1;
            }
            set
            {
                _x1 = value;
            }
        }
        [Description("X2")]
        public float X2
        {
            get
            {
                return _x2;
            }
            set
            {
                _x2 = value;
            }
        }
        [Description("Y1")]
        public float Y1
        {
            get
            {
                return _y1;
            }
            set
            {
                _y1 = value;
            }
        }

        [Description("Y2")]
        public float Y2
        {
            get
            {
                return _y2;
            }
            set
            {
                _y2 = value;
            }
        }

        private MedLineType _type = MedLineType.Normal;
        [Description("类型")]
        public MedLineType Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }
    }
}
