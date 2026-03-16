using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Wis.Anes.Framework.Controls;
using Wis.Anes.Framework.Controls.Base;
using DevExpress.XtraEditors;

namespace Wis.Anes.Framework.Controls
{
    /// <summary>
    /// 自定义Label
    /// </summary>
    public class MedLabelEx:DevExpress.XtraEditors.LabelControl
    {
        #region 变量

        /// <summary>
        /// 边框颜色-必须设置自定义边框为True
        /// </summary>
        private Color _borderColor = Color.LightGray;

        /// <summary>
        /// 自定义边框
        /// </summary>
        private bool _customBorder = false;

        private Image _backGroundImage;
        /// <summary>
        /// 是否画虚线边框
        /// </summary>
        private bool _dotBorder = false;

        /// <summary>
        /// 多行
        /// </summary>
        private bool _multiLine = false;
        #endregion 变量

        #region 属性

        public Image BackGroundImage
        {
            get
            {
                return _backGroundImage;
            }
            set
            {
                _backGroundImage = value;
            }
        }

        /// <summary>
        /// 边框颜色-必须设置自定义边框为True
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
            }
        }

        /// <summary>
        /// 自定义边框
        /// </summary>
        public bool CustomBorder
        {
            get
            {
                return _customBorder;
            }
            set
            {
                _customBorder = value;
                if (_customBorder) this.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;// System.Windows.Forms.BorderStyle.None;
            }
        }
        [Description("多行")]
        public bool MultiLine
        {
            get
            {
                return _multiLine;
            }
            set
            {
                _multiLine = value;
            }
        }

        /// <summary>
        /// 是否画虚线边框
        /// </summary>
        [Description("是否画虚线边框")]
        public bool DotBorder
        {
            get
            {
                return _dotBorder;
            }
            set
            {
                _dotBorder = value;
                Refresh();
            }
        }

        private string _varKey;
        public string VarKey
        {
            get
            {
                return _varKey;
            }
            set
            {
                _varKey = value;
            }
        }

        private MedSymbolType _symbolType = MedSymbolType.None;
        public MedSymbolType SymbolType
        {
            get
            {
                return _symbolType;
            }
            set
            {
                _symbolType = value;
            }
        }
        #endregion 属性

        #region 方法

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            RectangleF rectF = new RectangleF(0, 0, Width, Height);
            if (_backGroundImage != null)
            {
                e.Graphics.FillRectangle(new TextureBrush(_backGroundImage), this.ClientRectangle);
                e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), 0, 0);
            }
            if (_symbolType != MedSymbolType.None)
            {
                MedSymbol symbol = new MedSymbol(_symbolType);
                symbol.Size = 8;
                symbol.Pen = new Pen(ForeColor);
                symbol.Draw(e.Graphics, rectF.X + symbol.Size / 2, rectF.Y + symbol.Size / 2);
            }
            else if (_multiLine)
            {
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Near;
                //RectangleF rectF1 = new RectangleF(ClientRectangle);
                e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), rectF, sf);
            }
            //else
            //{
            //    e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), rectF.X, rectF.Y);
            //}
            if (_customBorder)
            {
                ///画边框
                e.Graphics.DrawRectangle(new Pen(_borderColor), 
                    new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1));
            }
        }

        /// <summary>
        /// 消息控制
        /// </summary>
        /// <param name="m">消息参数</param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            int WM_PAINT = 0xF;

            ///自行处理画控件消息 - 保证控件外观符合自定义需求
            if (m.Msg == WM_PAINT)
            {
                using (Graphics g = Graphics.FromHwnd(this.Handle))
                {
                    if (_dotBorder) //这里判断是否画选中边框
                    {
                        Pen Pen1 = new Pen(Color.Black, 1);
                        Pen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                        g.DrawRectangle(Pen1, this.ClientRectangle.Left, this.ClientRectangle.Top, this.ClientRectangle.Width - 1,
                                        this.ClientRectangle.Height - 1);
                    }
                }
            }
        }
        #endregion 方法
    }
}
