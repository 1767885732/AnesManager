/*----------------------------------------------------------------
      // Copyright (C) 2008 北京拓扑工厂科技发展有限公司
      // 文件名：Configuration.cs
      // 文件功能描述：配置接口本地实现类
      //
      // 
      // 创建标识：XXX-2011-02-22
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Wis.Anes.BusinessEntity;
using System.IO;
using Wis.Anes.Data;
using System.Data.Common;

namespace Wis.Anes.DataAccess
{
    /// <summary>
    /// 配置接口本地实现类
    /// </summary>
    public partial class ConfigurationDA 
    {
        public Configuations.UserTablesDataTable GetUserTables()
        {
            Configuations.UserTablesDataTable data = new Configuations.UserTablesDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("MyDataSet_GetUserTables");
            database.Fill(sql, data);
            return data;

            // return GetData<Configuations.UserTablesDataTable>(GetSQL("UserTables"));
            //return new ConfiguationsTableAdapters.UserTablesTableAdapter().GetData();
        }

        public Configuations.DocumentDataTable GetDocument()
        {
            Configuations.DocumentDataTable data = new Configuations.DocumentDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("MyDataSet_GetDocument");
            database.Fill(sql, data);
            return data;
            //  return GetData<Configuations.DocumentDataTable>(GetSQL("DocumentTable"));
        }

        public int UpdateDocument(Configuations.DocumentDataTable dataTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dataTable, "WIS_ANES_DOC");
            // return UpdateData<Configuations.DocumentDataTable>(dataTable, GetSQL("DocumentTable"));
        }

        public Configuations.ConfigTableDataTable GetConfigTableDataTable()
        {
            Configuations.ConfigTableDataTable data = new Configuations.ConfigTableDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("LocalDataModelProxy_GetConfigTableDataTable");
            database.Fill(sql, data);
            return data;
        }
        public int UpdateConfigTableDataTable(Configuations.ConfigTableDataTable data)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(data, "WIS_CONF_INDEX");
        }
        public Configuations.PatientMonitorConfigDataTable GetPatientMonitorConfigDataTable(string patientID, decimal visitID, decimal operID)
        {
            IDatabase database = DatabaseFactory.Create();
            Configuations.PatientMonitorConfigDataTable data = new Configuations.PatientMonitorConfigDataTable();
            string sql = StoredScript.Get("LocalDataModelProxy_GetPatientMonitorConfigDataTable");
            DbParameter patientIDParameter = database.BuildDbParameter("patientID", DbType.String, patientID);
            DbParameter visitIDParameter = database.BuildDbParameter("visitID", DbType.Decimal, visitID);
            DbParameter operIDParameter = database.BuildDbParameter("operID", DbType.Decimal, operID);
            database.Fill(sql, data, new DbParameter[] { patientIDParameter, visitIDParameter, operIDParameter });
            return data;
        }
        public int UpdatePatientMonitorConfigDataTable(Configuations.PatientMonitorConfigDataTable data)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(data, "WIS_CONF_PAT_MONITOR");
        }

        public Configuations.PatientMonitorConfigDataTable GetPatientJianCeConfigDataTable(string patientID, decimal visitID, decimal operID)
        {
            IDatabase database = DatabaseFactory.Create();
            Configuations.PatientMonitorConfigDataTable data = new Configuations.PatientMonitorConfigDataTable();
            string sql = StoredScript.Get("LocalDataModelProxy_GetPatientJianCeConfigDataTable");
            DbParameter patientIDParameter = database.BuildDbParameter("patientID", DbType.String, patientID);
            DbParameter visitIDParameter = database.BuildDbParameter("visitID", DbType.Decimal, visitID);
            DbParameter operIDParameter = database.BuildDbParameter("operID", DbType.Decimal, operID);
            database.Fill(sql, data, new DbParameter[] { patientIDParameter, visitIDParameter, operIDParameter });
            return data;
        }

        public int UpdatePatientJianCeConfigDataTable(Configuations.PatientMonitorConfigDataTable data)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(data, "WIS_CONF_ANES_MONITOR");
        }
    }
}
