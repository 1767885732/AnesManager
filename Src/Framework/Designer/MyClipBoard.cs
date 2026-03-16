/*----------------------------------------------------------------
      // Copyright (C) 2008 北京拓扑工厂科技发展有限公司
      // 文件名：MyClipBoard.cs
      // 文件功能描述：自制剪切板
      //
      // 
      // 创建标识：XXX-2010-12-13
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;

namespace Wis.Anes.Framework.Designer
{
    public class MyClipBoard
    {
        private static object _data;
        public static object Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }
    }
}
