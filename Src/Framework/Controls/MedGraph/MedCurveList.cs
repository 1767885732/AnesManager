using System;
using System.Collections;
using System.Text;

namespace Wis.Anes.Framework.Controls
{
    public class MedCurveList : CollectionBase
    {
        public void Add(MedCurve curve)
        {
            List.Add(curve);
        }
        public MedCurve this[int index]
        {
            get { return ((MedCurve)List[index]); }
            set { List[index] = value; }
        }
    }
}
