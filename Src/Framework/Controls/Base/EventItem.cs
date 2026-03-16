/*----------------------------------------------------------------
      // Copyright (C) 2010 北京拓扑工厂科技发展有限公司
      // 文件名：EventItem.cs
      // 文件功能描述：麻醉事件条目
      //
      // 
      // 创建标识：XXX-2011-01-14
      // 修改标识：
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;

namespace Wis.Anes.Framework.Controls.Base
{
    [Serializable]
    public class EventItem
    {
        private DateTime _startTime;
        public DateTime StartTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                _startTime = value;
            }
        }

        private string _eventName = "";
        public string EventName
        {
            get
            {
                return _eventName;
            }
            set
            {
                _eventName = value;
            }
        }

        public EventItem(DateTime startTime, string eventName)
        {
            _startTime = startTime;
            _eventName = eventName;
        }
    }
}
