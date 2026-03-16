using System;
using System.Collections.Generic;
using System.Text;

namespace Wis.AccessControl.Entity
{
    [Serializable]
    public abstract class ExtendInfo
    {
        private IDictionary<string, string> _extendInfoDict = new Dictionary<string, string>();
        public IDictionary<string, string> ExtendInfoDict
        {
            get
            {
                return _extendInfoDict;
            }
        }
    }
}
