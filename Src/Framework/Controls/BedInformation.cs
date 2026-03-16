using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wis.Anes.Framework.Controls
{
    /// <summary>
    /// 床位信息
    /// </summary>
    public class BedInformation
    {
        public BedInformation() { }
        public BedInformation(string bedNo, string name, int rowIndex) { BedNo = bedNo; Name = name; RowIndex = rowIndex; }
        public string BedNo;
        public string Name;
        public int RowIndex;
    }
}
