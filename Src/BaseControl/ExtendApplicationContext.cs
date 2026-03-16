using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Com.ICIS.Common.Con
{
    public class ExtendApplicationContext
    {
        public readonly static ExtendApplicationContext Current = new ExtendApplicationContext();
        private Dictionary<string, DataTable> _codeTables = new Dictionary<string, DataTable>();
        /// <summary>
        /// ×Öµä±í
        /// </summary>
        public Dictionary<string, DataTable> CodeTables
        {
            get
            {
                return _codeTables;
            }
            set
            {
                _codeTables = value;
            }
        }
    }
}
