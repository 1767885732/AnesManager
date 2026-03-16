using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wis.Anes.Framework.Controls
{
    public class CommonLabel : Label
    {
        [DisplayName("默认背景图")]
        public Image BackGroundImg { get; set; }

        [DisplayName("选中背景图")]
        public Image BackGroundImgSelected { get; set; }
        public CommonLabel()
        {
            this.MouseEnter += MenuButton_MouseEnter;
            this.MouseLeave += MenuButton_MouseLeave;
            this.Cursor = Cursors.Hand;
            Selected = false;
            this.AutoSize = false;
        }

        private bool _selected;
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

        protected override void OnClick(EventArgs e)
        {
            this.Selected = true;
            SetMenuStatus();
            base.OnClick(e);
        }

        private void MenuButton_MouseLeave(object sender, EventArgs e)
        {
            if (!Selected)
            {
                this.ForeColor = Color.White;
                this.Image = BackGroundImg;

            }

        }

        private void MenuButton_MouseEnter(object sender, EventArgs e)
        {
            if (!Selected)
            {
                this.Image = BackGroundImg;

                this.ForeColor = Color.White;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Selected)
            {
                this.Image = BackGroundImgSelected;

                //this.ForeColor = Color.FromArgb(102, 102, 102);
                this.ForeColor = Color.White;//hjc //黄色 ：Color.FromArgb(255, 225, 0);
                //this.BackColor = Color.FromArgb(76, 111, 237);
            }
            else
            {
                this.Image = BackGroundImg;

                this.ForeColor = Color.FromArgb(50, 90, 237);//hjc Color.White;
                //this.BackColor = Color.FromArgb(228, 234, 255);
            }
            Graphics g = e.Graphics;
            Font font = new Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            //Text

            //SizeF size = g.MeasureString(this.Text.Length > 5 ? this.Text.Substring(0, 4) + ".." : this.Text, font);
            SizeF size = g.MeasureString(this.Text, font);
            int x = 0, y = 0;

            var sizeImg = g.MeasureString("微软雅黑", font);
            x = (this.Width - (int)sizeImg.Width) / 2;
            y = 11;// (this.Height - (int)sizeImg.Height) / 2;

            g.DrawImage(this.Image, new Point(x - 12, y));

            //Pen pen = new Pen(Color.FromArgb(102, 102, 102));
            Pen pen = new Pen(Color.FromArgb(76, 111, 237));

            //绘制分割线
            g.DrawLine(pen, 119, 11, 119, 33);
            
            //Color foreColor = !Selected ? Color.White : Color.FromArgb(102, 102, 102);
            Color foreColor = !Selected ? Color.FromArgb(50, 90, 237) : Color.White;// 黄色： Color.FromArgb(255, 225, 0); //!Selected ? Color.White : Color.FromArgb(255, 225, 0);

            x = (this.Width - (int)size.Width) / 2;
            y = (this.Height - (int)size.Height) / 2;
            //g.DrawString(this.Text.Length > 5 ? this.Text.Substring(0, 4) + ".." : this.Text, this.Font, new SolidBrush(foreColor), new Point(x, y + 1));       
            g.DrawString(this.Text, font, new SolidBrush(foreColor), new Point(x, y + 1));      

        }

        public void SetMenuStatus()
        {
            if (this.Parent != null)
            {
                foreach (Control ctl in this.Parent.Controls)
                {
                    var menu = ctl as CommonLabel;
                    if (menu != null && menu != this && menu.Selected)
                    {
                        menu.Selected = false;
                        //menu.Image = BackGroundImg;
                    }
                }
            }
        }
    }
}