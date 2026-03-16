using System;
using System.Collections.Generic;
using System.Text;

namespace Wis.Anes.Framework
{
    public class NewMonitorDataItem
    {
        private DateTime _timePoint;
        public DateTime TimePoint
        {
            get
            {
                return _timePoint;
            }
        }

        private string _itemName;
        public string ItemName
        {
            get
            {
                return _itemName;
            }
        }

        private object _itemValue;
        public object ItemValue
        {
            get
            {
                return _itemValue;
            }
            set
            {
                _itemValue = value;
            }
        }

        private object _oldValue;
        public object OldValue
        {
            get
            {
                return _oldValue;
            }
            set
            {
                _oldValue = value;
            }
        }

        public NewMonitorDataItem(DateTime timePoint, string itemName, object itemValue, object oldvalue)
        {
            _timePoint = new DateTime(timePoint.Year, timePoint.Month, timePoint.Day, timePoint.Hour, timePoint.Minute, 0);
            _itemName = itemName;
            _itemValue = itemValue;
            _oldValue = oldvalue;
        }
    }
}
