using System;
using System.Collections.Generic;
using System.Text;



namespace Wis.Anes.Framework.Controls
{
    public class MedPoint
    {
        private bool isAbnormal = true;
        /// <summary>
        /// 数据是否偏离参考值，为真没有偏离，为假表示偏离
        /// </summary>
        public bool IsAbnormal
        {
            set
            {
                isAbnormal = value;
            }
            get
            {
                return isAbnormal;
            }
        }

        private string refKeyID;
        /// <summary>
        /// 存放主键ID用
        /// </summary>
        public string RefKeyID
        {
            set
            {
                refKeyID = value;
            }
            get
            {
                return refKeyID;
            }
        }
        private MedSymbol symbol;

        public double X;
        public double Y;
        public string Memo;
        public MedSymbol Symbol { get { return symbol; } set { symbol = value; } }

        public MedPoint() : this(0, 0, null,null) { }
        public MedPoint(double X, double Y) : this(X, Y, null,null) { }
        public MedPoint(double X, double Y, MedSymbol symbol) : this(X, Y, symbol, null) { }
        public MedPoint(double X, double Y, MedSymbol symbol,string memo)
        {
            this.X = X;
            this.Y = Y;
            this.symbol = symbol;
            this.Memo = memo;
        }
    }
}
