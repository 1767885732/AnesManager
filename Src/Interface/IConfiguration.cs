/*----------------------------------------------------------------
 // Copyright (C) 2007 北京拓扑工厂科技发展有限公司
 // 文件名：IConfiguration.cs
 // 文件功能描述：
 //     配置接口类
 // 
 // 创建标识：
 //     XXX 2011-2-22
 // 修改标识：
 // 修改描述：
 //
 // 修改标识：
 // 修改描述：
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.BusinessEntity;


namespace Wis.Anes.Interface
{
    /// <summary>
    /// 配置接口类
    /// </summary>
    public interface IConfiguration
    {
        Configuations.UserTablesDataTable GetUserTables();
        Configuations.DocumentDataTable GetDocument();
        int UpdateDocument(Configuations.DocumentDataTable dataTable);
        Configuations.PatientMonitorConfigDataTable GetPatientMonitorConfigDataTable(string patientID, decimal visitID, decimal operID);
        int UpdatePatientMonitorConfigDataTable(Configuations.PatientMonitorConfigDataTable data);

        Configuations.ConfigTableDataTable GetConfigTableDataTable();
        int UpdateConfigTableDataTable(Configuations.ConfigTableDataTable data);
    }
}
