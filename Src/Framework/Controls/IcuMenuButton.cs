using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Wis.Anes.Framework.Controls
{
    public class IcuMenuButton:Label
    {
        [DisplayName("图标")]
        public Image ICON { get; set; }

        [DisplayName("图标选中状态")]
        public Image ICONSelected { get; set; }

        [DisplayName("默认背景图")]
        public Image BackGroundImg { get; set; }

        [DisplayName("选中背景图")]
        public Image BackGroundImgSelected { get; set; }

        private bool _canClose = false;

        private bool _selected = false;

        private string _caption = string.Empty;

        private System.Windows.Forms.ToolTip toolTip1;

        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                this.Refresh();
            }
        }

        public bool CanClose
        {
            get
            {
                return _canClose;
            }

            set
            {
                _canClose = value;
            }
        }

        /// <summary>
        /// 标题
        /// </summary>
        public string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
            }
        }

        public IcuMenuButton()
        {
            this.Cursor = Cursors.Hand;
            toolTip1 = new ToolTip();
            this.MouseEnter += MenuButton_MouseEnter;
            this.MouseLeave += MenuButton_MouseLeave;

        }

        public IcuMenuButton(string caption):this()
        {
            this.Caption = caption;
        }

        public void PerformClick()
        {
            this.OnClick(new EventArgs());
        }

        private void MenuButton_MouseLeave(object sender, EventArgs e)
        {
            if (!Selected)
                this.Image = BackGroundImg;
        }

        private void MenuButton_MouseEnter(object sender, EventArgs e)
        {
            if (!Selected)
                this.Image = BackGroundImg;
            toolTip1.SetToolTip(this, Text);
        }

        protected override void OnClick(EventArgs e)
        {
            if (CanClose)
            {
                if (((System.Windows.Forms.MouseEventArgs)e).Location.X > this.Width - 15 && ((System.Windows.Forms.MouseEventArgs)e).Location.Y < 15)
                {
                    if (this.Parent != null)
                    {
                        this.Parent.Controls.Remove(this);
                        base.OnClick(null);
                        return;
                    }

                }
            }

            this.Selected = true;
            SetMenuStatus();
            base.OnClick(e);
        }

        protected override void OnDoubleClick(EventArgs e)
        {

        }

        public void SetMenuStatus()
        {
            if (this.Parent != null)
            {
                foreach (Control ctl in this.Parent.Controls)
                {
                    var menu = ctl as IcuMenuButton;
                    if (menu != null && menu != this && menu.Selected)
                    {
                        menu.Selected = false;
                        //menu.Image = BackGroundImg;
                    }
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Selected)
            {
                this.Image = BackGroundImgSelected;
            }
            else
            {
                this.Image = BackGroundImg;
            }
            Graphics g = e.Graphics;
            g.DrawImage(this.Image, new Point(0, 0));
            
            SizeF size = g.MeasureString(this.Text.Length > 5 ? this.Text.Substring(0, 4) + ".." : this.Text, this.Font);
            int x = 0, y = 0;

            //using (Pen pen = new Pen(Color.FromArgb(229, 229, 229)))
            //{
            //    g.DrawLine(pen, 0, 1, 0, this.Height - 1);
            //}

            Image img = Selected ? ICONSelected : ICON;
            //画图标
            if (img != null)
            {
                y = (this.Height - img.Height - (int)size.Height) / 2;
                //x = (this.Width - img.Width) / 2;
                x = (this.Width - img.Width - (int)size.Width) / 2;
                g.DrawImage(img, new Point(x, y - 2));
                x += img.Width + 2;
                //y = y + img.Height;
            }
            //Text

            Color foreColor = Selected ? Color.FromArgb(52, 90, 237) : Color.White;

            //x = (this.Width - (int)size.Width) / 2;
            g.DrawString(this.Text.Length > 5 ? this.Text.Substring(0, 4) + ".." : this.Text, this.Font, new SolidBrush(foreColor), new Point(x, y + 1));
            if (CanClose)
                g.DrawString("x", this.Font, new SolidBrush(foreColor), new Point(this.Width - 15, 0));

        }
        #region ItemClick
        public delegate void ItemClickEventHandler(object sender, ItemClickEventArgs e);

        public event ItemClickEventHandler ItemClick; //声明事件

        public class ItemClickEventArgs : EventArgs
        {
            public IcuMenuButton Item { get; set; } = null;

            public ItemClickEventArgs(IcuMenuButton MenuButton) : base()
            {
                Item = MenuButton;
            }
        }
        #endregion
    }
}
