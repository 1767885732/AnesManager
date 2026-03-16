using Wis.Anes.Framework.Utilities;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Wis.Anes.Framework.Views
{
    /// <summary>
    /// 基类窗口代码模块
    /// </summary>
    public partial class MessageBoxBaseFrm : Form
    {
        #region 常量

        private const int IME_CMODE_FULLSHAPE = 0x8;
        private const int IME_CHOTKEY_SHAPE_TOGGLE = 0x11;

        #endregion 常量

        #region 私有变量

        /// <summary>
        /// 鼠标位置
        /// </summary>
        private int XX = -1, YY = -1;

        private bool _isMovable = true,_lockMouseEvent = false;

        private Font _titleFont = new Font("微软雅黑", 9f);

        private Color _titleFontColor = Color.Black;

        #endregion 私有变量

        #region 属性

        /// <summary>
        /// 是否锁定(禁用)鼠标事件
        /// </summary>
        public bool LockMouseEvent
        {
            get
            {
                return _lockMouseEvent;
            }
            set
            {
                _lockMouseEvent = value;
            }
        }

        /// <summary>
        /// 窗口是否可移动
        /// </summary>
        public bool IsMovable
        {
            get
            {
                return _isMovable;
            }
            set
            {
                _isMovable = value;
            }
        }

        public Font TitleFont
        {
            get
            {
                return _titleFont;
            }
            set
            {
                _titleFont = value;
            }
        }

        public Color TitleFontColor
        {
            get
            {
                return _titleFontColor;
            }
            set
            {
                _titleFontColor = value;
            }
        }

        #endregion

        #region 构造方法

        /// <summary>
        /// 构造方法
        /// </summary>
        public MessageBoxBaseFrm()
        {
            InitializeComponent();
        }

        #endregion

        #region 方法

        /// <summary>
        /// 解决微软自动更新输入法为全角BUG
        /// </summary>
        /// <param name="e"></param>
        protected override void OnActivated(EventArgs e)
        {
            try
            {
                base.OnActivated(e);
                IntPtr HIme = WinAPI.ImmGetContext(this.Handle);
                if (WinAPI.ImmGetOpenStatus(HIme))  //如果输入法处于打开状态
                {
                    int iMode = 0;
                    int iSentence = 0;
                    bool bSuccess = WinAPI.ImmGetConversionStatus(HIme, ref iMode, ref iSentence);  //检索输入法信息
                    if (bSuccess)
                    {
                        if ((iMode & WinAPI.IME_CMODE_FULLSHAPE) > 0)   //如果是全角
                            WinAPI.ImmSimulateHotKey(this.Handle, WinAPI.IME_CHOTKEY_SHAPE_TOGGLE);  //转换成半角
                    }

                }
            }
            catch
            { 
            
            }
        }        

        private void PaintTitlePanel()
        {
            using (Graphics g = pnlTop.CreateGraphics())
            {
                //Rectangle rect = pnlTop.Bounds;

                #region 画窗体图标
                g.DrawString(Text, _titleFont, new SolidBrush(_titleFontColor), 2, (pnlTop.Height - g.MeasureString("A", _titleFont).Height) / 2 + 2);

                #endregion 画窗体图标
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!DesignMode)
            {
                PaintTitlePanel();
                pnlTop.Refresh();
                btnClose.Refresh();
            }
        }

        #endregion 方法

        #region 窗体事件

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender">窗体</param>
        /// <param name="e">事件参数</param>
        private void BaseFrm_Load(object sender, EventArgs e)
        {

        }

        #endregion 窗体事件

        #region 控件事件

        /// <summary>
        /// 点击关闭窗体按钮
        /// </summary>
        /// <param name="sender">关闭按钮</param>
        /// <param name="e">事件参数</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 画标题Panel事件
        /// </summary>
        /// <param name="sender">标题Panel</param>
        /// <param name="e">事件参数</param>
        private void pnlTop_Paint(object sender, PaintEventArgs e)
        {
            PaintTitlePanel();
        }

        /// <summary>
        /// 标题Panel大小改变事件
        /// </summary>
        /// <param name="sender">标题Panel</param>
        /// <param name="e">事件参数</param>
        private void pnlTop_Resize(object sender, EventArgs e)
        {
            btnClose.Left = pnlTop.Width - btnClose.Width - 5;
        }

        /// <summary>
        /// 标题Panel鼠标按下事件
        /// </summary>
        /// <param name="sender">标题Panel</param>
        /// <param name="e">事件参数</param>
        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) || (this.WindowState == FormWindowState.Normal))
            {
                XX = e.X;
                YY = e.Y;
            }
        }

        /// <summary>
        /// 标题Panel鼠标放开事件
        /// </summary>
        /// <param name="sender">标题Panel</param>
        /// <param name="e">事件参数</param>
        private void pnlTop_MouseUp(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) || (this.WindowState == FormWindowState.Normal))
            {
                XX = -1;
                YY = -1;
            }
        }

        /// <summary>
        /// 标题Panel鼠标移动事件
        /// </summary>
        /// <param name="sender">标题Panel</param>
        /// <param name="e">事件参数</param>
        private void pnlTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal && (XX > -1) && (YY > -1))
            {
                this.Left += e.X - XX;
                this.Top += e.Y - YY;
            }
        }

        #endregion 控件事件


    }
}