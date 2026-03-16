/*----------------------------------------------------------------
 // Copyright (C) 2007 北京拓扑工厂科技发展有限公司
 // 文件名：AnesMasterDA.cs
 // 文件功能描述：  主任客户端数据访问
 // 创建标识： 深蓝色右手 2011-8-24
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Wis.Anes.Data;

namespace Wis.Anes.DataAccess
{
   public class AnesMasterDA
    {
       /// <summary>
       /// 返回当天排班的所有手术
       /// </summary>
       /// <returns></returns>
       public DataTable GetTodayOperations()
       {
           IDatabase database = DatabaseFactory.Create();
           DataTable data = new DataTable();
           string sql = StoredScript.Get("AnesMaster_GetTodayOperations");

           database.Fill(sql, data);
           return data;

       }
    }
}
