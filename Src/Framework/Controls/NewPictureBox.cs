/*----------------------------------------------------------------
      // Copyright (C) 2008 北京拓扑工厂科技发展有限公司
      // 文件名：NewPictureBox.cs
      // 文件功能描述：新图片
      //
      // 
      // 创建标识：XXX-2010-12-13
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Controls.Base;

namespace Wis.Anes.Framework.Controls
{
    [ToolboxItem(false), Description("新图片")]
    public class NewPictureBox:PictureBox,IPrintable
    {
        public NewPictureBox()
        {
            Paint += new PaintEventHandler(NewPictureBox_Paint);
        }

        bool _noPrint = false;
        [Description("不打印")]
        public bool NoPrint
        {
            get
            {
                return _noPrint;
            }
            set
            {
                _noPrint = value;
            }
        }

        public delegate void CustomDrawEventHandler(Graphics g, float x, float y, object sender, EventArgs e); 

        private static readonly object _customDraw = new object();
        public event CustomDrawEventHandler CustomDraw
        {
            add
            {
                Events.AddHandler(_customDraw, value);
            }
            remove
            {
                Events.RemoveHandler(_customDraw, value);
            }
        }

        public void Draw(Graphics g, float x, float y)
        {
            if (Image != null)
            {
                g.DrawImage(Image, x, y, Width, Height);
            }
            else
            {
                CustomDrawEventHandler eventHandle = Events[_customDraw] as CustomDrawEventHandler;
                if (eventHandle != null)
                {
                    eventHandle(g,x,y,this, null);
                }
            }
        }

        private void NewPictureBox_Paint(object sender, PaintEventArgs e)
        {
            CustomDrawEventHandler eventHandle = Events[_customDraw] as CustomDrawEventHandler;
            if (eventHandle != null)
            {
                eventHandle(e.Graphics, 0, 0, sender, null);
            }
        }
    }
}
