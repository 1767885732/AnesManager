/*----------------------------------------------------------------
      // Copyright (C) 2008 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：AnesBand.cs
      // 文件功能描述：麻醉单区域基类
      //
      // 
      // 创建标识：戴呈祥-2008-11-11
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Com.ICIS.Common.Controls
{
    /// <summary>
    /// 边框类型
    /// </summary>
    [Serializable]
    public enum BorderType
    {
        /// <summary>
        /// 矩形
        /// </summary>
        [Description("矩形")]
        Rectangle,
        /// <summary>
        /// 无顶矩形
        /// </summary>
        [Description("无顶矩形")]
        NoTop,
        /// <summary>
        /// 无底矩形
        /// </summary>
        [Description("无底矩形")]
        NoBottom,
        /// <summary>
        /// 右下线
        /// </summary>
        [Description("右下线")]
        RightBottom,
        /// <summary>
        /// 无
        /// </summary>
        [Description("无")]
        None
    }


    /// <summary>
    /// 麻醉单区域基类
    /// </summary>
    [Serializable]
    public partial class AnesBand : DevExpress.XtraEditors.XtraUserControl
    {
        #region 构造方法

        public AnesBand()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw, true);
        }

        #endregion 构造方法

        #region 事件接口

        public delegate void AnesBandEventHandle(AnesBand sender,object selectObject,EventArgs e); 

        protected static readonly object _customEditEventHandle = new object();

        /// <summary>
        /// 自定义编辑事件
        /// </summary>
        [Description("自定义编辑事件")]
        public event AnesBandEventHandle CustomEdit
        {
            add
            {
                Events.AddHandler(_customEditEventHandle, value);
            }
            remove
            {
                Events.RemoveHandler(_customEditEventHandle, value);
            }
        }

        #endregion 事件接口

        #region 变量

        /// <summary>
        /// 缩放比率
        /// </summary>
        protected float _scaleRate = 1;

        /// <summary>
        /// 原始作图宽度
        /// </summary>
        private float _originWidth = 100;

        /// <summary>
        /// 原始作图高度
        /// </summary>
        private float _originHeight = 100;

        /// <summary>
        /// 边框颜色
        /// </summary>
        protected Color _borderColor = Color.Red;

        /// <summary>
        /// 刻度值颜色
        /// </summary>
        protected Color _scaleValueColor = Color.Red;

        /// <summary>
        /// 是否画边框
        /// </summary>
        protected bool _drawBorder = true;

        /// <summary>
        /// 边框宽度
        /// </summary>
        protected int _borderWidth = 1;

        protected BorderType _borderType = BorderType.Rectangle;

        #endregion 变量

        #region 属性

        public BorderType BorderType
        {
            get
            {
                return _borderType;
            }
            set
            {
                _borderType = value;
            }
        }

        /// <summary>
        /// 边框宽度
        /// </summary>
        public int BorderWidth
        {
            get
            {
                return _borderWidth;
            }
            set
            {
                _borderWidth = value;
            }
        }

        /// <summary>
        /// 是否画边框
        /// </summary>
        [Description("是否画边框"), Category("外观")]
        public bool DrawBorder
        {
            get
            {
                return _drawBorder;
            }
            set
            {
                _drawBorder = value;
                Refresh();
            }
        }

        /// <summary>
        /// 刻度值颜色
        /// </summary>
        public Color ScaleValueColor
        {
            get
            {
                return _scaleValueColor;
            }
            set
            {
                _scaleValueColor = value;
            }
        }

        /// <summary>
        /// 边框颜色
        /// </summary>
        public Color BorderColor
        {
            get
            {
                return _borderColor;
            }
            set
            {
                _borderColor = value;
                _scaleValueColor = value;
            }
        }

        /// <summary>
        /// 缩放比率
        /// </summary>
        public float ScaleRate
        {
            get
            {
                return _scaleRate;
            }
            set
            {
                _scaleRate = value;
                Height = (int)(_scaleRate * _originHeight);
                Invalidate();
            }
        }

        /// <summary>
        /// 原始作图宽度
        /// </summary>
        public float OriginWidth
        {
            get
            {
                return _originWidth;
            }
            set
            {
                _originWidth = value;
            }
        }

        /// <summary>
        /// 原始作图高度
        /// </summary>
        public float OriginHeight
        {
            get
            {
                return _originHeight;
            }
            set
            {
                _originHeight = value;
            }
        }

        public Rectangle OriginRect
        {
            get
            {
                return new Rectangle(0, 0, (int)_originWidth, (int)(_originHeight));
            }
        }

        #endregion 属性

        #region 方法

        /// <summary>
        /// 绘制控件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.ResetTransform();
            ///等比缩放
            e.Graphics.ScaleTransform(_scaleRate, _scaleRate);
            DrawGraphics(e.Graphics);
        }

        /// <summary>
        /// 画边框
        /// </summary>
        protected virtual void DoDrawBorder(Graphics g)
        {
            if (_drawBorder && _borderType != BorderType.None)
            {
                Rectangle rect = OriginRect;
                rect.Width += -2;
                rect.Height += -1;
                rect.X += 1;
                g.FillRectangle(new SolidBrush(BackColor), rect);
                Pen P = new Pen(_borderColor,_borderWidth);
                switch (_borderType)
                {
                    case BorderType.Rectangle:
                        g.DrawLine(P, rect.Left, rect.Top, rect.Left, rect.Bottom);
                        g.DrawLine(P, rect.Right, rect.Top, rect.Right, rect.Bottom);
                        g.DrawLine(P, rect.Left, rect.Top, rect.Right, rect.Top);
                        g.DrawLine(P, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
                        break;
                    case BorderType.NoTop:
                        g.DrawLine(P, rect.Left, rect.Top, rect.Left, rect.Bottom);
                        g.DrawLine(P, rect.Right, rect.Top, rect.Right, rect.Bottom);
                        g.DrawLine(P, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
                        break;
                    case BorderType.RightBottom:
                        g.DrawLine(P, rect.Right, rect.Top, rect.Right, rect.Bottom);
                        g.DrawLine(P, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
                        break;
                    case BorderType.NoBottom:
                        g.DrawLine(P, rect.Left, rect.Top, rect.Left, rect.Bottom);
                        g.DrawLine(P, rect.Right, rect.Top, rect.Right, rect.Bottom);
                        g.DrawLine(P, rect.Left, rect.Top, rect.Right, rect.Top);
                        break;
                }
            }
        }

        /// <summary>
        /// 重画区域-子类应该重写该方法
        /// </summary>
        /// <param name="g"></param>
        public virtual void DrawGraphics(Graphics g)
        {
            DoDrawBorder(g);
        }

        #endregion 方法

    }
}
