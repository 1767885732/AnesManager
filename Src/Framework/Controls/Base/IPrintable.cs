using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Wis.Anes.Framework.Controls.Base
{
    public interface IPrintable
    {
        void Draw(Graphics g, float x, float y);
        bool NoPrint{get;}
    }
}
