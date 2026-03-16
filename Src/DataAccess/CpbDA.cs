/*----------------------------------------------------------------
      // Copyright (C) 2008 北京拓扑工厂科技发展有限公司
      // 文件名：CPB.cs
      // 文件功能描述：体外循环接口本地实现类
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
    /// 体外循环接口本地实现类
    /// </summary>
    public partial class CpbDA 
    {

        public CPB.CPBBlgRecordDataTable GetCPBBlgRecordTable(string patient_id, decimal visit_id, decimal oper_id)
        {
            CPB.CPBBlgRecordDataTable data = new CPB.CPBBlgRecordDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("CPB_GetCPBBlgRecordTableByPatient");
            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patient_id);
            DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visit_id);
            DbParameter OperIdParameter = database.BuildDbParameter("OperID", DbType.Decimal, oper_id);
            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter, OperIdParameter });
            return data;
        }

        public int UpdateCPBBlgRecordTable(CPB.CPBBlgRecordDataTable dataTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dataTable, "WIS_CPB_BLG_RECORD");
        }

        public CPB.CPBPreCheckRecordDataTable GetCPBPreCheckRecord()
        {
            return DatabaseFactory.Create().GetTable<CPB.CPBPreCheckRecordDataTable>("WIS_CPB_PRE_CHECK_RECORD");
        }

        public CPB.CPBPreCheckRecordDataTable GetCPBPreCheckRecord(string patient_id, decimal visit_id, decimal oper_id)
        {
            CPB.CPBPreCheckRecordDataTable data = new CPB.CPBPreCheckRecordDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("CPB_GetCPBPreCheckRecordByPatient");
            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patient_id);
            DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visit_id);
            DbParameter OperIdParameter = database.BuildDbParameter("OperID", DbType.Decimal, oper_id);
            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter, OperIdParameter });
            return data;
        }

        public int UpdateCPBPreCheckRecord(CPB.CPBPreCheckRecordDataTable dataTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dataTable, "WIS_CPB_PRE_CHECK_RECORD");
        }

        public CPB.CPBPrimingDataDataTable GetCPBPrimingData(string patient_id, decimal visit_id, decimal oper_id)
        {
            CPB.CPBPrimingDataDataTable data = new CPB.CPBPrimingDataDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("CPB_GetCPBPrimingDataByPatient");
            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patient_id);
            DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visit_id);
            DbParameter OperIdParameter = database.BuildDbParameter("OperID", DbType.Decimal, oper_id);
            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter, OperIdParameter });
            return data;
        }

        public CPB.CPBInputDictDataTable GetCPBInputDict()
        {
            return DatabaseFactory.Create().GetTable<CPB.CPBInputDictDataTable>("WIS_DICT_CPB_INPUT");
        }

        public CPB.CPBInputDictDataTable GetCPBInputDict(string itemClass)
        {
            CPB.CPBInputDictDataTable data = new CPB.CPBInputDictDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("CPB_GetCPBInputDict");
            DbParameter patientIdParameter = database.BuildDbParameter("ITEM_CLASS", DbType.String, itemClass);
            database.Fill(sql, data, new DbParameter[] { patientIdParameter });
            return data;
        }

        public int UpdateCPBInputDict(CPB.CPBInputDictDataTable dataTable)
        {
            return DatabaseFactory.Create().Update(dataTable, "WIS_DICT_CPB_INPUT");
        }


        public CPB.CPBEventOpenDataTable GetCPBEventOpen()
        {
            return DatabaseFactory.Create().GetTable<CPB.CPBEventOpenDataTable>("WIS_DICT_CPB_EVENT");
        }

        public CPB.CPBEventOpenDataTable GetCPBEventOpen(string itemClass)
        {
            CPB.CPBEventOpenDataTable data = new CPB.CPBEventOpenDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("CPB_GetCPBEventOpen");
            DbParameter patientIdParameter = database.BuildDbParameter("ITEM_CLASS", DbType.String, itemClass);
            database.Fill(sql, data, new DbParameter[] { patientIdParameter });
            return data;
        }

        public int UpdateCPBEventOpen(CPB.CPBEventOpenDataTable dataTable)
        {
            return DatabaseFactory.Create().Update(dataTable, "WIS_DICT_CPB_EVENT");
        }

        public CPB.CPBMethodDictDataTable GetCPBMethodDict()
        {
            return DatabaseFactory.Create().GetTable<CPB.CPBMethodDictDataTable>("WIS_DICT_CPB_METHOD");
        }

        public int UpdateCPBMethodDict(CPB.CPBMethodDictDataTable dataTable)
        {
            return DatabaseFactory.Create().Update(dataTable, "WIS_DICT_CPB_METHOD");
        }

        public CPB.CPBMasterDataTable GetCPBMasterTable(string patient_id, decimal visit_id, decimal oper_id)
        {
            CPB.CPBMasterDataTable data = new CPB.CPBMasterDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("CPB_GetCPBMasterTableByPatient");
            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patient_id);
            DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visit_id);
            DbParameter OperIdParameter = database.BuildDbParameter("OperID", DbType.Decimal, oper_id);
            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter, OperIdParameter });
            return data;
        }

        public int UpdateCPBMasterTable(CPB.CPBMasterDataTable dataTable)
        {
            return DatabaseFactory.Create().Update(dataTable, "WIS_CPB_MASTER");
        }

        public CPB.CPBExamInfoDataTable GetCPBExamInfo(string patient_id, decimal visit_id, decimal oper_id)
        {
            CPB.CPBExamInfoDataTable data = new CPB.CPBExamInfoDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("CPB_GetCPBExamInfoByPatient");
            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patient_id);
            DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visit_id);
            DbParameter OperIdParameter = database.BuildDbParameter("OperID", DbType.Decimal, oper_id);
            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter, OperIdParameter });
            return data;
        }

        public int UpdateCPBExamInfo(CPB.CPBExamInfoDataTable dataTable)
        {
            return DatabaseFactory.Create().Update(dataTable, "WIS_CPB_EXAM_INFO");
        }

        public CPB.CPBSummaryDataTable GetCPBSummary(string patient_id, decimal visit_id, decimal oper_id)
        {
            CPB.CPBSummaryDataTable data = new CPB.CPBSummaryDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("CPB_GetCPBSummaryByPatient");
            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patient_id);
            DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visit_id);
            DbParameter OperIdParameter = database.BuildDbParameter("OperID", DbType.Decimal, oper_id);
            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter, OperIdParameter });
            return data;
        }

        public int UpdateCPBSummary(CPB.CPBSummaryDataTable dataTable)
        {
            return DatabaseFactory.Create().Update(dataTable, "WIS_CPB_SUMMARY");
        }

        public void UpdateCPBEvents(DataTable data)
        {
            IDatabase database = DatabaseFactory.Create();

            string sql=string.Empty;
            foreach(DataColumn c in data.Columns)
            {
                if(string.IsNullOrEmpty(sql))
                   sql="select "+c.ColumnName+" ";
                else
                    sql+=", "+c.ColumnName;
            }
            sql+= " from WIS_ANES_EVENT where 1=2 ";

            database.Update(sql,data);
        }
    }
}
