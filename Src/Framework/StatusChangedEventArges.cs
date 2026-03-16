using System;
using System.Collections.Generic;
using System.Text;

namespace Wis.Anes.Framework
{
    /// <summary>
    ///手术状态改变事件参数
    /// </summary>
    public class StatusChangedEventArges:EventArgs
    {
        private string _name = string.Empty;

        public StatusChangedEventArges(string name)
        {
            this._name = name;
        }
        /// <summary>
        /// 状态名称
        /// </summary>
        public string StatusName
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
    }
}
