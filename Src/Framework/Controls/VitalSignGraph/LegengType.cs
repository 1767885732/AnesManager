using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Wis.Anes.Framework.Controls
{
    [Serializable]
    public enum LegengType
    {
        [Description("水平")]
        Horizontal,
        [Description("垂直")]
        Vertical,
        [Description("无")]
        None
    }
}
