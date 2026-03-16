using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Wis.Anes.Framework.Controls
{
    [Serializable]
    ///事件索引表格控件-数据填充类型
    public enum MedGridType
    {
        [Description("汇总")]
        Summery,
        [Description("索引")]
        Index,
    }
}
