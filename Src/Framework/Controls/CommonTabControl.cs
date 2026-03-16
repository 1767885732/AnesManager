using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Wis.Anes.Framework.Properties;

namespace Wis.Anes.Framework.Controls
{
    public class ClosePageEventArgs : EventArgs
    {
        public ClosePageEventArgs(TabPage prevPage, TabPage page)
        {
            PrevPage = prevPage;
            Page = page;
        }

        public TabPage PrevPage { get; }

        public TabPage Page { get; }
    }

    public class CommonTabPageChangedEventArgs : EventArgs
    {
        public CommonTabPageChangedEventArgs(TabPage prevPage, TabPage page)
        {
            PrevPage = prevPage;
            Page = page;
        }

        public TabPage PrevPage { get; }

        public TabPage Page { get; }
    }

    public class CommonTabControl : TabControl
    {
        private ContextMenuStrip menuStrip = null;

        public event EventHandler CloseButtonClick;
        public delegate void CommonTabPageChangedEventHandler(object sender, CommonTabPageChangedEventArgs e);
        public event CommonTabPageChangedEventHandler SelectedPageChanged;

        public Image CloseIcon { get; set; }

        public CommonTabControl() : base()
        {
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.SizeMode = TabSizeMode.Fixed;

            CloseIcon = Resources.close2;

            Size size = new Size(100, 40);
            ItemSize = size;

            this.SetStyle(
                ControlStyles.UserPaint |                      // 控件将自行绘制，而不是通过操作系统来绘制  
                ControlStyles.OptimizedDoubleBuffer |  // 该控件首先在缓冲区中绘制，而不是直接绘制到屏幕上，这样可以减少闪烁  
                ControlStyles.AllPaintingInWmPaint |           // 控件将忽略 WM_ERASEBKGND 窗口消息以减少闪烁  
                ControlStyles.ResizeRedraw |                   // 在调整控件大小时重绘控件  
                ControlStyles.SupportsTransparentBackColor,    // 控件接受 alpha 组件小于 255 的 BackColor 以模拟透明  
                true);                                         // 设置以上值为 true  
            this.UpdateStyles();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Rectangle rec = this.ClientRectangle;
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.FromArgb(174, 174, 174));
            Brush brush;

            //设置背景与tabpage边框
            g.DrawRectangle(pen, ClientRectangle.X + 1, ClientRectangle.Y + 1, ClientRectangle.Width - 2, ClientRectangle.Height - 2);
            g.DrawLine(pen, ClientRectangle.X + 1, ClientRectangle.Y + 43, ClientRectangle.X + ClientRectangle.Width - 1, ClientRectangle.Y + 43);

            //绘制标签
            for (int i = 0; i < this.TabPages.Count; i++)
            {
                Rectangle r = GetTabRect(i);
                if (i == this.SelectedIndex)
                {
                    r.Height += 2;
                    g.FillRectangle(new SolidBrush(Color.FromArgb(244, 244, 244)), r);
                    brush = new SolidBrush(Color.Black);
                }
                else
                {
                    brush = new SolidBrush(Color.FromArgb(174, 174, 174));
                }
                //绘制标签边框
                g.DrawLines(pen, new Point[] { new Point(r.X - 1 + r.Width, r.Y + r.Height + 1), new Point(r.X - 1 + r.Width, r.Y - 1) });
                //绘制标签文字
                Font font = new Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
                string title = this.TabPages[i].Text;
                title = title.Length > 5 ? title.Substring(0, 4) + ".." : title;
                g.DrawString(title, font, brush, new PointF(r.X + font.Size, r.Y / 2 + font.Size / 2 + 2));
                //绘制关闭按钮
                r.Offset(r.Width - CloseIcon.Width - 6, r.Height / 2 - 8);
                g.DrawImage(CloseIcon, new Point(r.X, r.Y));
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            //判断点击区域，若左键点击到关闭按钮则关闭标签
            //关闭选中标签
            Point p = e.Location;
            Rectangle rectTabTitle = GetTabRect(this.SelectedIndex);
            if (e.Button == MouseButtons.Left)
            {
                rectTabTitle.Offset(rectTabTitle.Width - CloseIcon.Width - 6, rectTabTitle.Height / 2 - 8);
                rectTabTitle.Width = CloseIcon.Width;
                rectTabTitle.Height = CloseIcon.Height;
                if (rectTabTitle.Contains(p))
                {
                    //点击标签页关闭按钮
                    ClosePageEventArgs eventArgs = new ClosePageEventArgs(SelectedTab, SelectedTab);
                    OnCloseButtonClick(this, eventArgs);
                }
            }
            //右键提供菜单，用于关闭tabpage或整个tabcontrol
            else if (e.Button == MouseButtons.Right)
            {
                if (rectTabTitle.Contains(p))
                {
                    menuStrip = new ContextMenuStrip();
                    ToolStripMenuItem itemCloseAll = new ToolStripMenuItem("关闭所有页");
                    itemCloseAll.Click += ItemCloseAll_Click;
                    ToolStripMenuItem itemCloseCurrent = new ToolStripMenuItem("关闭当前页");
                    itemCloseCurrent.Click += ItemCloseCurrent_Click;
                    menuStrip.Items.AddRange(new ToolStripItem[] { itemCloseAll, itemCloseCurrent });
                    SelectedTab.ContextMenuStrip = menuStrip;
                    SelectedTab.ContextMenuStrip.Show(this, p);
                }
                SelectedTab.ContextMenuStrip = null;
            }
        }

        private void ItemCloseCurrent_Click(object sender, EventArgs e)
        {
            //关闭单个标签
            //this.TabPages.Remove(SelectedTab);
            ClosePageEventArgs eventArgs = new ClosePageEventArgs(SelectedTab, SelectedTab);
            OnCloseButtonClick(this, eventArgs);
        }

        private void ItemCloseAll_Click(object sender, EventArgs e)
        {
            //关闭所有标签
            //this.TabPages.Clear();
            ClosePageEventArgs eventArgs = new ClosePageEventArgs(null, SelectedTab);
            OnCloseButtonClick(this, eventArgs);
        }

        public override Rectangle DisplayRectangle
        {
            get
            {
                //消除page边框
                Rectangle rect = base.DisplayRectangle;
                return new Rectangle(rect.Left - 2, rect.Top + 0, rect.Width + 4, rect.Height + 2);
            }
        }

        protected void OnCloseButtonClick(object sender, EventArgs e)
        {
            //定制关闭逻辑
            if (CloseButtonClick != null)
            {
                CloseButtonClick(sender, e);
            }
            //默认关闭逻辑
            else
            {
                ClosePageEventArgs eventArgs = e as ClosePageEventArgs;
                if (eventArgs.PrevPage == null)
                {
                    //关闭所有标签页
                    this.TabPages.Clear();
                }
                else
                {
                    //关闭单个标签页
                    this.TabPages.Remove(SelectedTab);
                }
            }
            if (this.TabPages.Count == 0)
            {
                //this.Hide();
            }
        }

        protected void OnSelectedPageChanged(object sender, CommonTabPageChangedEventArgs e)
        {
            if (SelectedPageChanged != null)
            {
                SelectedPageChanged(sender, e);
            }
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            CommonTabPageChangedEventArgs eventArgs = new CommonTabPageChangedEventArgs(SelectedTab, SelectedTab);
            OnSelectedPageChanged(this, eventArgs);
            //Refresh();
        }
    }
}
