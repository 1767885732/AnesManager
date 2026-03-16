/*----------------------------------------------------------------
 // Copyright (C) 2007 北京拓扑工厂科技发展有限公司
 // 文件名：AnesMasterBC.cs
 // 文件功能描述：  主任客户端业务层 
 // 创建标识： 深蓝色右手 2011-8-24
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.Interface;
using System.Data;
using Wis.Anes.DataAccess;

namespace Wis.Anes.BusinessComponent
{
   public class AnesMasterBC:IAnesMaster
    {
       /// <summary>
       /// 返回当天排班的所有手术
       /// </summary>
       /// <returns></returns>
        public DataTable GetTodayOperations()
        {
            AnesMasterDA anesMasterDA = new AnesMasterDA();
            return  anesMasterDA.GetTodayOperations();
        }

       
    }
}
