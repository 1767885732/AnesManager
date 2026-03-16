/*----------------------------------------------------------------
 // Copyright (C) 2007 北京拓扑工厂科技发展有限公司
 // 文件名：IAnesMaster.cs
 // 文件功能描述：  主任客户端接口类
 // 创建标识： 深蓝色右手 2011-8-24
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Wis.Anes.Interface
{
   public interface IAnesMaster
    {
       DataTable GetTodayOperations();
    }
}
