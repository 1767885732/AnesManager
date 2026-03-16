/*----------------------------------------------------------------
      // Copyright (C) 2008 北京拓扑工厂科技发展有限公司
      // 文件名：CareDocs.cs
      // 文件功能描述：医疗文书接口（麻醉单、复苏单除外）本地实现类
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
    /// 医疗文书接口（麻醉单、复苏单除外）本地实现类
    /// </summary>
    public partial class CareDocsDA
    {
        public CareDocs.WIS_CUSTOM_DATADataTable GetCustomData()
        {
            CareDocs.WIS_CUSTOM_DATADataTable data = new CareDocs.WIS_CUSTOM_DATADataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("CareDocs_GetCustomData");

            database.Fill(sql, data);
            return data;
        }

        public CareDocs.WIS_CUSTOM_DATADataTable GetCustomData(string patientID, decimal visitID, decimal operID)
        {
            CareDocs.WIS_CUSTOM_DATADataTable data = new CareDocs.WIS_CUSTOM_DATADataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("CareDocs_GetCustomDataByPatient");

            database.Fill(sql, data, new DbParameter[]{database.BuildDbParameter("PatientID", DbType.String, patientID)
                ,database.BuildDbParameter("VisitID", DbType.Decimal, visitID),database.BuildDbParameter("OperID", DbType.Decimal, operID)});
            return data;
        }

        public int UpdateCustomData(CareDocs.WIS_CUSTOM_DATADataTable dataTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dataTable, "WIS_CUSTOM_DATA");
        }

        /// <summary>
        /// 获取江苏术前访谈记录表
        /// </summary>
        /// <returns>江苏术前访谈记录表</returns>
        public AnesInformations.JSShuQianFangTanDataTable GetJSShuQianFangTanData()
        {
            AnesInformations.JSShuQianFangTanDataTable data = new AnesInformations.JSShuQianFangTanDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("AnesInformations_GetJSShuQianFangTanData");
            database.Fill(sql, data);
            return data;
            //return GetData<AnesInformations.JSShuQianFangTanDataTable>(GetSQL("JSShuQianFangTan"));
            //return new AnesInformationsTableAdapters.JSShuQianFangTanAdapter().GetData();
        }

        /// <summary>
        /// 获取江苏术前访谈记录表
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <param name="operID">手术ID</param>
        /// <returns>江苏术前访谈记录表</returns>
        public AnesInformations.JSShuQianFangTanDataTable GetJSShuQianFangTanData(string patientID, decimal visitID, decimal operID)
        {
            AnesInformations.JSShuQianFangTanDataTable data = new AnesInformations.JSShuQianFangTanDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("AnesInformations_GetJSShuQianFangTanBy");

            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patientID);
            DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visitID);
            DbParameter operIdParameter = database.BuildDbParameter("OperID", DbType.Decimal, operID);
            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter, operIdParameter });
            return data;
            //return GetData<AnesInformations.JSShuQianFangTanDataTable>(GetSQL("JSShuQianFangTanBy"),new object[]{patientID,visitID,operID});
            //return new AnesInformationsTableAdapters.JSShuQianFangTanAdapter().GetDataBy(patientID, visitID, operID);
        }

        /// <summary>
        /// 更新江苏术前访谈记录表
        /// </summary>
        /// <param name="jsShuQianFangTanDataTable"></param>
        /// <returns>更新的行数</returns>
        public int UpdateJSShuQianFangTanData(AnesInformations.JSShuQianFangTanDataTable updateTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(updateTable, "WIS_JS_PREOPER_INTERVIEW");
            // return UpdateData<AnesInformations.JSShuQianFangTanDataTable>(updateTable,GetSQL("JSShuQianFangTan"));
            //return new AnesInformationsTableAdapters.JSShuQianFangTanAdapter().Update(updateTable);
        }

        /// <summary>
        /// 获取江苏术后镇痛记录表
        /// </summary>
        /// <returns>江苏术后镇痛记录表</returns>
        public AnesInformations.JSShouHouZhenTongDataTable GetJSShouHouZhenTongData()
        {
            AnesInformations.JSShouHouZhenTongDataTable data = new AnesInformations.JSShouHouZhenTongDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("AnesInformations_GetJSShouHouZhenTongData");
            database.Fill(sql, data);
            return data;
            // return GetData<AnesInformations.JSShouHouZhenTongDataTable>(GetSQL("JSShouHouZhenTong"));
            //return new AnesInformationsTableAdapters.JSShouHouZhenTongAdapter().GetData();
        }

        /// <summary>
        /// 获取江苏术后镇痛记录表
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <param name="operID">手术ID</param>
        /// <returns>江苏术后镇痛记录表</returns>
        public AnesInformations.JSShouHouZhenTongDataTable GetJSShouHouZhenTongData(string patientID, decimal visitID, decimal operID)
        {
            AnesInformations.JSShouHouZhenTongDataTable data = new AnesInformations.JSShouHouZhenTongDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("AnesInformations_GetJSShouHouZhenTongDataBy");
            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patientID);
            DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visitID);
            DbParameter operIdParameter = database.BuildDbParameter("OperID", DbType.Decimal, operID);

            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter, operIdParameter });
            return data;

            // return GetData<AnesInformations.JSShouHouZhenTongDataTable>(GetSQL("JSShouHouZhenTongBy"),new object[]{patientID,visitID,operID});
            //return new AnesInformationsTableAdapters.JSShouHouZhenTongAdapter().GetDataBy(patientID, visitID, operID);
        }

        /// <summary>
        /// 更新江苏术后镇痛记录表
        /// </summary>
        /// <param name="jsShouHouZhenTongDataTable"></param>
        /// <returns>更新的行数</returns>
        public int UpdateJSShouHouZhenTongData(AnesInformations.JSShouHouZhenTongDataTable updateTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(updateTable, "WIS_JS_AFTEROPER_ANALGESIA");
            // return UpdateData<AnesInformations.JSShouHouZhenTongDataTable>(updateTable,GetSQL("JSShouHouZhenTong"));
            //return new AnesInformationsTableAdapters.JSShouHouZhenTongAdapter().Update(updateTable);
        }



        /// <summary>
        /// 术后病情
        /// </summary>
        /// <returns></returns>
        public AnesInformations.JSShuHouBingQingDataTable GetJSShuHouBingQingData()
        {
            AnesInformations.JSShuHouBingQingDataTable data = new AnesInformations.JSShuHouBingQingDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("AnesInformations_GetJSShuHouBingQingData");
            database.Fill(sql, data);
            return data;
            //return GetData<AnesInformations.JSShuHouBingQingDataTable>(GetSQL("JSShuHouBingQing"));
            //return new AnesInformationsTableAdapters.JSShuHouBingQingAdapter().GetData();
        }

        /// <summary>
        /// 术后病情
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        public AnesInformations.JSShuHouBingQingDataTable GetJSShuHouBingQingData(string patientID, decimal visitID, decimal operID)
        {
            AnesInformations.JSShuHouBingQingDataTable data = new AnesInformations.JSShuHouBingQingDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("AnesInformations_GetJSShuHouBingQingDataBy");
            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patientID);
            DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visitID);
            DbParameter operIdParameter = database.BuildDbParameter("OperID", DbType.Decimal, operID);

            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter, operIdParameter });
            return data;
            // return GetData<AnesInformations.JSShuHouBingQingDataTable>(GetSQL("JSShuHouBingQingBy"),new object[]{patientID,visitID,operID});
            //return new AnesInformationsTableAdapters.JSShuHouBingQingAdapter().GetDataBy(patientID, visitID, operID);
        }

        /// <summary>
        /// 更新术后病情
        /// </summary>
        /// <param name="jsMZKCaoZhuoDataTable"></param>
        /// <returns>更新的行数</returns>
        public int UpdateJSShuHouBingQingData(AnesInformations.JSShuHouBingQingDataTable updateTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(updateTable, "WIS_JS_AFTEROPER_CONDITION");

            // return UpdateData<AnesInformations.JSShuHouBingQingDataTable>(updateTable, GetSQL("JSShuHouBingQing"));
            //return new AnesInformationsTableAdapters.JSShuHouBingQingAdapter().Update(updateTable);
        }

        /// <summary>
        /// 术后随访
        /// </summary>
        /// <returns></returns>
        public AnesInformations.AnesthesiaInquiryDataTable GetAnesthesiaInquiryData()
        {
            AnesInformations.AnesthesiaInquiryDataTable data = new AnesInformations.AnesthesiaInquiryDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("AnesInformations_GetAnesthesiaInquiryData");
            database.Fill(sql, data);
            return data;
            // return GetData<AnesInformations.AnesthesiaInquiryDataTable>(GetSQL("AnesthesiaInquiry"));
            //return new AnesInformationsTableAdapters.AnesthesiaInquiryAdapter().GetData();
        }

        /// <summary>
        /// 术后随访
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        public AnesInformations.AnesthesiaInquiryDataTable GetAnesthesiaInquiryData(string patientID, decimal visitID, decimal operID)
        {
            AnesInformations.AnesthesiaInquiryDataTable data = new AnesInformations.AnesthesiaInquiryDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("AnesInformations_GetAnesthesiaInquiryDataBy");
            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patientID);
            DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visitID);
            DbParameter operIdParameter = database.BuildDbParameter("OperID", DbType.Decimal, operID);

            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter, operIdParameter });
            return data;
            // return GetData<AnesInformations.AnesthesiaInquiryDataTable>(GetSQL("AnesthesiaInquiryBy"),new object[]{patientID,visitID,operID});
            //return new AnesInformationsTableAdapters.AnesthesiaInquiryAdapter().GetDataBy(patientID, visitID, operID);
        }

        /// <summary>
        /// 更新术后随访
        /// </summary>
        /// <param name="jsMZKCaoZhuoDataTable"></param>
        /// <returns>更新的行数</returns>
        public int UpdateAnesthesiaInquiryData(AnesInformations.AnesthesiaInquiryDataTable updateTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(updateTable, "WIS_ANES_INQUIRY");
            // return UpdateData<AnesInformations.AnesthesiaInquiryDataTable>(updateTable, GetSQL("AnesthesiaInquiry"));
            //return new AnesInformationsTableAdapters.AnesthesiaInquiryAdapter().Update(updateTable);
        }







        /// <summary>
        /// 获取病人麻醉总结
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">病人本次住院标识</param>
        /// <param name="operID">手术号</param>
        /// <returns>病人麻醉总结记录</returns>
        public AnesInformations.AnesthesiaSummaryDataTable GetAnesthesiaSummary(string patientID, decimal visitID, decimal operID)
        {
            AnesInformations.AnesthesiaSummaryDataTable data = new AnesInformations.AnesthesiaSummaryDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("AnesInformations_GetAnesthesiaSummary");
            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patientID);
            DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visitID);
            DbParameter operIdParameter = database.BuildDbParameter("OperID", DbType.Decimal, operID);

            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter, operIdParameter });
            return data;
            // return GetData<AnesInformations.AnesthesiaSummaryDataTable>(GetSQL("AnesthesiaSummaryByKey"), new object[] { patientID, visitID, operID });
            //return new AnesInformationsTableAdapters.AnesthesiaSummaryAdapter().GetDataByKey(patientID, visitID, operID);
        }

        /// <summary>
        /// 更新病人麻醉总结
        /// </summary>
        /// <param name="anesthesiaPlanDataTable">病人麻醉总结数据集</param>
        /// <returns>更新受影响的行数</returns>
        public int UpdateAnesthesiaSummary(AnesInformations.AnesthesiaSummaryDataTable dataTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dataTable, "WIS_ANES_SUMMARY");
            //return UpdateData<AnesInformations.AnesthesiaSummaryDataTable>(dataTable, GetSQL("AnesthesiaSummaryByKey"), new object[] { "000000", 0, 0 });
            //return new AnesInformationsTableAdapters.AnesthesiaSummaryAdapter().Update(dataTable);
        }
        public CareDocs.PatMonitorDataExtDataTable GetPatMonitorDataExtDataTable(string patientID, decimal visitID, decimal operID)
        {
            IDatabase database = DatabaseFactory.Create();
            CareDocs.PatMonitorDataExtDataTable data = new CareDocs.PatMonitorDataExtDataTable();
            string sql = StoredScript.Get("LocalDataModelProxy_GetPatMonitorDataExtDataTable");
            DbParameter patientIDParameter = database.BuildDbParameter("pid", DbType.String, patientID);
            DbParameter visitIDParameter = database.BuildDbParameter("vid", DbType.Decimal, visitID);
            DbParameter operIDParameter = database.BuildDbParameter("oid", DbType.Decimal, operID);
            database.Fill(sql, data, new DbParameter[] { patientIDParameter, visitIDParameter, operIDParameter });
            return data;
        }
        public CareDocs.PatMonitorDataExtDataTable GetPatMonitorDataExtDataTableDesc(string patientID, decimal visitID, decimal operID)
        {
            IDatabase database = DatabaseFactory.Create();
            CareDocs.PatMonitorDataExtDataTable data = new CareDocs.PatMonitorDataExtDataTable();
            string sql = StoredScript.Get("LocalDataModelProxy_GetPatMonitorDataExtDataTableDesc");
            DbParameter patientIDParameter = database.BuildDbParameter("pid", DbType.String, patientID);
            DbParameter visitIDParameter = database.BuildDbParameter("vid", DbType.Decimal, visitID);
            DbParameter operIDParameter = database.BuildDbParameter("oid", DbType.Decimal, operID);
            database.Fill(sql, data, new DbParameter[] { patientIDParameter, visitIDParameter, operIDParameter });
            return data;
        }

        public CareDocs.PatMonitorDataHistoryDataTable GetPatMonitorDataHistory()
        {
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("CareDocs_GetPatMonitorDataHistory");
            CareDocs.PatMonitorDataHistoryDataTable dataTable = new CareDocs.PatMonitorDataHistoryDataTable();
            database.Fill(sql, dataTable);
            return dataTable;
        }

        public CareDocs.PatMonitorDataHistoryDataTable GetPatMonitorDataHistory(string patientID, decimal visitID, decimal operID)
        {
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("CareDocs_GetPatMonitorDataHistoryByPatient");
            CareDocs.PatMonitorDataHistoryDataTable dataTable = new CareDocs.PatMonitorDataHistoryDataTable();
            DbParameter patientIDParameter = database.BuildDbParameter("PATIENT_ID", DbType.String, patientID);
            DbParameter visitIDParameter = database.BuildDbParameter("VISIT_ID", DbType.Decimal, visitID);
            DbParameter operIDParameter = database.BuildDbParameter("OPER_ID", DbType.Decimal, operID);
            database.Fill(sql, dataTable, new DbParameter[] { patientIDParameter, visitIDParameter, operIDParameter });
            return dataTable;
        }

        public CareDocs.PatMonitorDataHistoryDataTable GetPatMonitorDataHistory(string patientID, decimal visitID, decimal operID, decimal dataType, decimal itemNo)
        {
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("CareDocs_GetPatMonitorDataHistoryByPatientAndDataTypeAndItemNo");
            CareDocs.PatMonitorDataHistoryDataTable dataTable = new CareDocs.PatMonitorDataHistoryDataTable();
            DbParameter patientIDParameter = database.BuildDbParameter("PATIENT_ID", DbType.String, patientID);
            DbParameter visitIDParameter = database.BuildDbParameter("VISIT_ID", DbType.Decimal, visitID);
            DbParameter operIDParameter = database.BuildDbParameter("OPER_ID", DbType.Decimal, operID);
            database.Fill(sql, dataTable, new DbParameter[] { patientIDParameter, visitIDParameter, operIDParameter 
                ,database.BuildDbParameter("ITEM_NO", DbType.Decimal, dataType),database.BuildDbParameter("DATA_TYPE", DbType.Decimal, itemNo)});
            return dataTable;
        }

        public string GetPatMonitorDataHistoryItemHeader(string patientID, decimal visitID, decimal operID, decimal data_type)
        {
            CareDocs.PatMonitorDataHistoryDataTable dataTable = GetPatMonitorDataHistory(patientID, visitID, operID, data_type, 0);
            if (dataTable != null && dataTable.Count == 1 && !dataTable[0].IsMONITOR_VALUENull() && !string.IsNullOrEmpty(dataTable[0].MONITOR_VALUE))
            {
                return dataTable[0].MONITOR_VALUE;
            }
            return "";
        }

        public string GetPatMonitorDataHistoryMaxValue(string patientID, decimal visitID, decimal operID, decimal data_type)
        {
            IDatabase database = DatabaseFactory.Create();

            DataTable dataTable = new DataTable();
            string sql = StoredScript.Get("LocalDataModelProxy_GetWIS_PAT_MONITOR_DATA_HISTORY_MaxValue");
            DbParameter patientIDParameter = database.BuildDbParameter("patient_id", DbType.String, patientID);
            DbParameter visitIDParameter = database.BuildDbParameter("visit_id", DbType.String, visitID);
            DbParameter operIDParameter = database.BuildDbParameter("oper_id", DbType.String, operID);
            DbParameter data_typeParameter = database.BuildDbParameter("data_type", DbType.Decimal, data_type);
            database.Fill(sql, dataTable, new DbParameter[] { patientIDParameter, visitIDParameter, operIDParameter, data_typeParameter });
            if (dataTable.Rows.Count == 1 && dataTable.Rows[0][0] != System.DBNull.Value)
            {
                return dataTable.Rows[0][0].ToString();
            }
            return "";
        }

        public CareDocs.OperationNameDataTable GetOperationName()
        {
            return DatabaseFactory.Create().GetTable<CareDocs.OperationNameDataTable>("WIS_OPER_NAME");
        }

        public CareDocs.OperationNameDataTable GetOperationName(string patientID, decimal visitID, decimal operID)
        {
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("CareDocs_GetOperationNameByPatient");
            CareDocs.OperationNameDataTable dataTable = new CareDocs.OperationNameDataTable();
            DbParameter patientIDParameter = database.BuildDbParameter("PatientID", DbType.String, patientID);
            DbParameter visitIDParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visitID);
            DbParameter operIDParameter = database.BuildDbParameter("OperID", DbType.Decimal, operID);
            database.Fill(sql, dataTable, new DbParameter[] { patientIDParameter, visitIDParameter, operIDParameter });
            return dataTable;
        }

        public int UpdateOperationName(CareDocs.OperationNameDataTable dataTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dataTable, "WIS_OPER_NAME");
        }

        public CareDocs.OperationCanceledDataTable GetOperationCanceled()
        {
            return DatabaseFactory.Create().GetTable<CareDocs.OperationCanceledDataTable>("WIS_OPER_CANCELED");
        }
        public CareDocs.OperationCanceledDataTable GetOperationCanceled(string patientID, decimal visitID)
        {
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("CareDocs_GetOperationCanceledByPatient1");
            CareDocs.OperationCanceledDataTable dataTable = new CareDocs.OperationCanceledDataTable();
            DbParameter patientIDParameter = database.BuildDbParameter("PATIENT_ID", DbType.String, patientID);
            DbParameter visitIDParameter = database.BuildDbParameter("VISIT_ID", DbType.Decimal, visitID);
            database.Fill(sql, dataTable, new DbParameter[] { patientIDParameter, visitIDParameter });
            return dataTable;
        }
        public CareDocs.OperationNameCanceledDataTable GetOperationNameCanceled(string patientID, decimal visitID, decimal cancelID)
        {
            IDatabase database = DatabaseFactory.Create();

            string sql = "select * from WIS_OPER_NAME_CANCELED WHERE PAT_ID = '" + patientID + "' AND VISIT_ID = " + visitID.ToString() + " AND CANCEL_ID = " + cancelID.ToString();
            CareDocs.OperationNameCanceledDataTable dataTable = new CareDocs.OperationNameCanceledDataTable();
            //DbParameter patientIDParameter = database.BuildDbParameter("PATIENT_ID", DbType.String, patientID);
            //DbParameter visitIDParameter = database.BuildDbParameter("VISIT_ID", DbType.Decimal, visitID);
            //DbParameter operIDParameter = database.BuildDbParameter("CANCEL_ID", DbType.Decimal, cancelID);
            //database.Fill(sql, dataTable, new DbParameter[] { patientIDParameter, visitIDParameter, operIDParameter });
            database.Fill(sql, dataTable);
            return dataTable;
        }
        public CareDocs.OperationCanceledDataTable GetOperationCanceled(string patientID, decimal visitID, decimal cancelID)
        {
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("CareDocs_GetOperationCanceledByPatient");
            CareDocs.OperationCanceledDataTable dataTable = new CareDocs.OperationCanceledDataTable();
            DbParameter patientIDParameter = database.BuildDbParameter("PATIENT_ID", DbType.String, patientID);
            DbParameter visitIDParameter = database.BuildDbParameter("VISIT_ID", DbType.Decimal, visitID);
            DbParameter operIDParameter = database.BuildDbParameter("CANCEL_ID", DbType.Decimal, cancelID);
            database.Fill(sql, dataTable, new DbParameter[] { patientIDParameter, visitIDParameter, operIDParameter });
            return dataTable;
        }

        public int UpdateOperationNameCanceled(CareDocs.OperationNameCanceledDataTable dataTable)
        {
            return DatabaseFactory.Create().Update(dataTable, "WIS_OPER_NAME_CANCELED");
        }

        public int UpdateOperationCanceled(CareDocs.OperationCanceledDataTable dataTable)
        {
            return DatabaseFactory.Create().Update(dataTable, "WIS_OPER_CANCELED");
        }

        public CareDocs.BloodGasMasterDataTable GetBloodGasMasterTable(string patient_id, decimal visit_id, decimal oper_id)
        {
            CareDocs.BloodGasMasterDataTable data = new CareDocs.BloodGasMasterDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("PatientBaseInformations_GetBloodGasMasterTable");

            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patient_id);
            DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visit_id);
            DbParameter OperIdParameter = database.BuildDbParameter("OperID", DbType.Decimal, oper_id);

            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter, OperIdParameter });
            return data;
        }

        public CareDocs.BloodGasMasterDataTable GetBloodGasMasterTable(string detailId)
        {
            CareDocs.BloodGasMasterDataTable data = new CareDocs.BloodGasMasterDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("PatientBaseInformations_GetBloodGasMasterTableByDetailId");

            DbParameter detaiIdParameter = database.BuildDbParameter("detailId", DbType.String, detailId);

            database.Fill(sql, data, new DbParameter[] { detaiIdParameter });
            return data;
        }

        public CareDocs.BloodGasMasterDataTable GetBloodGasMasterTable(DateTime startTime,DateTime endTime)
        {
            CareDocs.BloodGasMasterDataTable data = new CareDocs.BloodGasMasterDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("PatientBaseInformations_GetBloodGasMasterTableByDateTime");

            DbParameter startTimeParameter = database.BuildDbParameter("startTime", DbType.DateTime, startTime);
            DbParameter endTimeParameter = database.BuildDbParameter("endTime", DbType.DateTime, endTime);
            database.Fill(sql, data, new DbParameter[] { startTimeParameter, endTimeParameter });
            return data;
        }

        public CareDocs.BloodGasDetailDataTable GetBloodGasDetailTable(string detailId)
        {
            CareDocs.BloodGasDetailDataTable data = new CareDocs.BloodGasDetailDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("PatientBaseInformations_GetBloodGasDetailTable");
            DbParameter detaiIdParameter = database.BuildDbParameter("detailId", DbType.String, detailId);
            database.Fill(sql, data, new DbParameter[] { detaiIdParameter });
            return data;
        }

        public int UpdateBloodGasMaster(CareDocs.BloodGasMasterDataTable dataTable)
        {
            return DatabaseFactory.Create().Update(dataTable, "WIS_BLOOD_GAS_MASTER");
        }

        public int UpdateBloodGasDetail(CareDocs.BloodGasDetailDataTable dataTable)
        {
            return DatabaseFactory.Create().Update(dataTable, "WIS_BLOOD_GAS_DETAIL");
        }

        public CareDocs.UserScheduleDataTable GetUserSchedule()
        {
            return DatabaseFactory.Create().GetTable<CareDocs.UserScheduleDataTable>("MED_USER_SCHEDULE");
        }

        public CareDocs.UserScheduleDataTable GetUserSchedule(DateTime startTime, DateTime endTime)
        {
            CareDocs.UserScheduleDataTable data = new CareDocs.UserScheduleDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("CareDocs_GetUserScheduleByScheduleTime");
            DbParameter detaiIdParameter = database.BuildDbParameter("startTime", DbType.DateTime, startTime);
            DbParameter endTimeParameter = database.BuildDbParameter("endTime", DbType.DateTime, endTime);
            database.Fill(sql, data, new DbParameter[] { detaiIdParameter, endTimeParameter });
            return data;
        }

        public int UpdateUserSchedule(CareDocs.UserScheduleDataTable dataTable)
        {
            return DatabaseFactory.Create().Update(dataTable, "MED_USER_SCHEDULE");
        }

        public CareDocs.PatientMonitorDataDataTable GetPatientMonitorData()
        {
            return DatabaseFactory.Create().GetTable<CareDocs.PatientMonitorDataDataTable>("WIS_PATIENT_MONITOR_DATA");
        }

        public CareDocs.PatientMonitorDataDataTable GetPatientMonitorData(string patientID, decimal visitID, decimal operID)
        {
            CareDocs.PatientMonitorDataDataTable dataTable = new CareDocs.PatientMonitorDataDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("CareDocs_GetModifyedDataByPatient");
            DbParameter patientIDParameter = database.BuildDbParameter("PatientID", DbType.String, patientID);
            DbParameter visitIDParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visitID);
            DbParameter operIDParameter = database.BuildDbParameter("OperID", DbType.Decimal, operID);
            database.Fill(sql, dataTable, new DbParameter[] { patientIDParameter, visitIDParameter, operIDParameter });
            return dataTable;
        }

        public CareDocs.PatientMonitorDataDataTable GetPatientMonitorData(string patientID, decimal visitID, decimal operID, decimal eventNo)
        {
            CareDocs.PatientMonitorDataDataTable dataTable = new CareDocs.PatientMonitorDataDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("CareDocs_GetModifyedDataByPatientAndEventNo");
            DbParameter patientIDParameter = database.BuildDbParameter("PatientID", DbType.String, patientID);
            DbParameter visitIDParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visitID);
            DbParameter operIDParameter = database.BuildDbParameter("OperID", DbType.Decimal, operID);
            DbParameter eventNoParameter = database.BuildDbParameter("EventNo", DbType.Decimal, eventNo);
            database.Fill(sql, dataTable, new DbParameter[] { patientIDParameter, visitIDParameter, operIDParameter, eventNoParameter });
            return dataTable;
        }

        public CareDocs.PatientMonitorDataDataTable GetPatientMonitorData(string patientID, decimal visitID, decimal operID, DateTime timePoint, string itemName, decimal eventNo)
        {
            CareDocs.PatientMonitorDataDataTable dataTable = new CareDocs.PatientMonitorDataDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("CareDocs_GetModifyedDataByPatientAndTimePointAndItemNameAndEventNo");
            DbParameter patientIDParameter = database.BuildDbParameter("PatientID", DbType.String, patientID);
            DbParameter visitIDParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visitID);
            DbParameter operIDParameter = database.BuildDbParameter("OperID", DbType.Decimal, operID);
            DbParameter timePointParameter = database.BuildDbParameter("timepoint", DbType.DateTime, timePoint);
            DbParameter itemNameParameter = database.BuildDbParameter("itemname", DbType.String, itemName);
            DbParameter eventNoParameter = database.BuildDbParameter("eventno", DbType.Decimal, eventNo);
            database.Fill(sql, dataTable, new DbParameter[] { patientIDParameter, visitIDParameter, operIDParameter, timePointParameter, itemNameParameter, eventNoParameter });
            return dataTable;
        }

        public int UpdatePatientMonitorData(CareDocs.PatientMonitorDataDataTable dataTable)
        {
            return DatabaseFactory.Create().Update(dataTable, "WIS_PATIENT_MONITOR_DATA");
        }

        public int UpdatePatMonitorExtData(CareDocs.PatMonitorDataExtDataTable dataTable)
        {
            return DatabaseFactory.Create().Update(dataTable, "WIS_PAT_MONITOR_DATA_EXT");
        }

        public CareDocs.ModifyHistoryDataTable GetModifyHistory()
        {
            return DatabaseFactory.Create().GetTable<CareDocs.ModifyHistoryDataTable>("WIS_MODIFY_HISTORY");
        }
        public CareDocs.ModifyHistoryDataTable GetModifyHistory(string tableName, string fieldName)
        {
            CareDocs.ModifyHistoryDataTable dataTable = new CareDocs.ModifyHistoryDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("CareDocs_GetModifyHistoryByTableNameAndFieldName");
            DbParameter tableNameParameter = database.BuildDbParameter("TableName", DbType.String, tableName);
            DbParameter fieldNameParameter = database.BuildDbParameter("FieldName", DbType.String, tableName);
            database.Fill(sql, dataTable, new DbParameter[] { tableNameParameter, fieldNameParameter });
            return dataTable;
        }

        public int UpdateModifyHistory(CareDocs.ModifyHistoryDataTable dataTable)
        {
            return DatabaseFactory.Create().Update(dataTable, "WIS_MODIFY_HISTORY");
        }

        public int InsertNewModifyHistoryRecord(string tableName, string fieldName, string primaryKey, string newValue, string oldValue, DateTime modifyTime, string operatorName)
        {
            CareDocs.ModifyHistoryDataTable modifyHistoryDataTable = GetModifyHistory();
            CareDocs.ModifyHistoryRow row = modifyHistoryDataTable.NewModifyHistoryRow();
            row.TABLE_NAME = tableName;
            row.FIELD_NAME = fieldName;
            row.PRIMARY_KEY = primaryKey;
            row.NEW_VALUE = newValue;
            row.OLD_VALUE = oldValue;
            row.MODIFY_TIME = modifyTime;
            row.OPERATOR = operatorName;
            modifyHistoryDataTable.AddModifyHistoryRow(row);
            return UpdateModifyHistory(modifyHistoryDataTable);
        }
        public CareDocs.WIS_PACU_SCOREDataTable GetPACUSorce()
        {
            IDatabase database = DatabaseFactory.Create();
            return database.GetTable<CareDocs.WIS_PACU_SCOREDataTable>("WIS_PACU_SCORE");
        }
        //public CareDocs.WIS_PACU_SCOREDataTable GetPACUSorce(string patientID, decimal visitID, decimal operID)
        //{
        //    IDatabase database = DatabaseFactory.Create();
        //    CareDocs.WIS_PACU_SCOREDataTable data = new CareDocs.WIS_PACU_SCOREDataTable();
        //    string sql = StoredScript.Get("WIS_PACU_SCORE");
        //    DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patientID);
        //    DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visitID);
        //    DbParameter operIdParameter = database.BuildDbParameter("OperID", DbType.Decimal, operID);

        //    database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter, operIdParameter });
        //    return data;
        //}

        public int UpdatePACUSorce(CareDocs.WIS_PACU_SCOREDataTable dataTable)
        {
            //CareDocs.WIS_PACU_SCOREDataTable data = new CareDocs.WIS_PACU_SCOREDataTable();
            //IDatabase database = DatabaseFactory.Create();
            //string sql = StoredScript.Get("CareDocs_GetPACUSorce");
            //database.Fill(sql, data);
            //return data;

            IDatabase database = DatabaseFactory.Create();
            return database.Update(dataTable, "WIS_PACU_SCORE");
        }
        public void DeleteBloodGasDetail(string detailsId)
        {
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("CareDocs_DeleteBloodGasMaster");
            string sql1 = StoredScript.Get("CareDocs_DeleteBloodGasDetails");
            DbParameter detailsIdParameter = database.BuildDbParameter("detail_id", DbType.String, detailsId);
            DbParameter detailsIdParameter2 = database.BuildDbParameter("detail_id", DbType.String, detailsId);
            using (DbWrapTransaction transaction = database.CreateDbTransaction())
            {
                try
                {
                    database.ExecuteNonQuery(sql, new DbParameter[] { detailsIdParameter }, transaction);
                    database.ExecuteNonQuery(sql, new DbParameter[] { detailsIdParameter2 }, transaction);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();

                }

            }
        }
        /// <summary>
        /// 器材收费记录单
        /// </summary>
        /// <returns></returns>
        public CareDocs.MED_ANESTHESIA_DEVICEPRICEDataTable GetANESDEVICEPRICED()
        {
            IDatabase database = DatabaseFactory.Create();
            return database.GetTable<CareDocs.MED_ANESTHESIA_DEVICEPRICEDataTable>("MED_ANESTHESIA_DEVICEPRICE");
        }
        public int UpdateANESDEVICEPRICED(CareDocs.MED_ANESTHESIA_DEVICEPRICEDataTable dataTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dataTable, "MED_ANESTHESIA_DEVICEPRICE");
        }
        /// <summary>
        /// 手术清点记录
        /// </summary>
        /// <returns></returns>
        public CareDocs.MED_ANES_OPEREQUIPMENTRCDDataTable GetANESOPEREQUIPMENTRCD(string patientID, decimal visitID, decimal operID)
        {
            IDatabase database = DatabaseFactory.Create();
            CareDocs.MED_ANES_OPEREQUIPMENTRCDDataTable data = new CareDocs.MED_ANES_OPEREQUIPMENTRCDDataTable();
            string sql = StoredScript.Get("AnesInformations_GetOPEREQUIPMENTRCDData");
            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patientID);
            DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visitID);
            DbParameter operIdParameter = database.BuildDbParameter("OperID", DbType.Decimal, operID);

            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter, operIdParameter });
            return data;
            //return database.GetTable<CareDocs.MED_ANES_OPEREQUIPMENTRCDDataTable>("MED_ANES_OPEREQUIPMENTRCD");
        }
        /// <summary>
        /// 手术清点记录
        /// </summary>
        /// <returns></returns>
        public CareDocs.MED_ANES_OPEREQUIPMENTRCDDataTable GetANESOPEREQUIPMENTRCD()
        {
            IDatabase database = DatabaseFactory.Create();
            return database.GetTable<CareDocs.MED_ANES_OPEREQUIPMENTRCDDataTable>("MED_ANES_OPEREQUIPMENTRCD");
        }

        public int UpdateANESOPEREQUIPMENTRCD(CareDocs.MED_ANES_OPEREQUIPMENTRCDDataTable dataTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dataTable, "MED_ANES_OPEREQUIPMENTRCD");
        }


        /// <summary>
        /// 根据条件获取输液汇总
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <param name="_eventNo"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataTable GetSumLiquid(string patientID, decimal visitID, decimal operID, int eventNo, string type)
        {
            IDatabase database = DatabaseFactory.Create();

            string sql = "";
            //输液
            sql = " select sum(a.dosage) as total ,b.event_attr  from WIS_ANES_EVENT a left join WIS_ANES_EVENT_OPEN  b ";
            sql += "  on  a.item_name = b.item_name    ";
            sql += " and PAT_ID = '" + patientID + "' AND VISIT_ID =  '" + visitID + "' AND OPER_ID ='" + operID + "'  And EVENT_NO ='" + eventNo + "'";
            if (type == "")
            { }
            else
            {
                sql += " where 1=1  and b.event_attr = '" + type + "' ";
            }
            sql += " group by b.event_attr  ";
            DataTable dataTable = new DataTable();
            DatabaseFactory.Create().Fill(sql, dataTable);
            return dataTable;
        }
        /// <summary>
        /// 根据条件获取输血汇总
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <param name="_eventNo"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataTable GetSumBlood(string patientID, decimal visitID, decimal operID, int eventNo)
        {
            IDatabase database = DatabaseFactory.Create();
            string sql = "";
            sql = "  select sum(a.dosage) as total ,b.item_class  from WIS_ANES_EVENT a ";
            sql += " left join WIS_ANES_EVENT_OPEN  b   on  a.item_name = b.item_name    ";
            sql += " and PAT_ID = '" + patientID + "' AND VISIT_ID =  '" + visitID + "' AND OPER_ID ='" + operID + "'  And EVENT_NO ='" + eventNo + "'";
            sql += " where 1=1 and b.item_class ='B'  group by b.item_class  ";
            DataTable dataTable = new DataTable();
            DatabaseFactory.Create().Fill(sql, dataTable);
            return dataTable;
        }


        public DataTable GetPACUSorce(string patientID, int visitID, int operID)
        {
            IDatabase database = DatabaseFactory.Create();
            string sql = "";
            sql += " SELECT * from WIS_PACU_SCORE ";
            sql += " Where 1=1   ";
            sql += " and PAT_ID = '" + patientID + "' AND VISIT_ID =  '" + visitID + "' AND OPER_ID ='" + operID + "'" ;
            sql += " Order by   order_id ";
            DataTable dataTable = new DataTable();
            DatabaseFactory.Create().Fill(sql, dataTable);
            return dataTable;
        }
        public DataTable GetPACUOrders(string patientID, int visitID, int operID)
        {
            IDatabase database = DatabaseFactory.Create();
            string sql = "";
            sql += " SELECT * from MED_PACU_ORDERS ";
            sql += " Where 1=1   ";
            sql += " and PAT_ID = '" + patientID + "' AND VISIT_ID =  '" + visitID + "' AND OPER_ID ='" + operID + "'";
            sql += " Order by   order_id ";
            DataTable dataTable = new DataTable();
            DatabaseFactory.Create().Fill(sql, dataTable);
            return dataTable;
        }

        public CareDocs.WIS_INSTRUMENT_INVENTORYDataTable GetQiXieQingDian()
        {
            return DatabaseFactory.Create().GetTable<CareDocs.WIS_INSTRUMENT_INVENTORYDataTable>("WIS_INSTRUMENT_INVENTORY");
        }

        public CareDocs.WIS_INSTRUMENT_INVENTORYDataTable GetQiXieQingDian(string patientID, decimal visitID, decimal operID)
        {
            IDatabase database = DatabaseFactory.Create();
            CareDocs.WIS_INSTRUMENT_INVENTORYDataTable data = new CareDocs.WIS_INSTRUMENT_INVENTORYDataTable();
            string sql = StoredScript.Get("CareDocs_GetQiXieQingDianByPatientID");
            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patientID);
            DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visitID);
            DbParameter operIdParameter = database.BuildDbParameter("OperID", DbType.Decimal, operID);

            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter, operIdParameter });
            return data;
        }

        public int UpdateQiXieQingDian(CareDocs.WIS_INSTRUMENT_INVENTORYDataTable dataTable)
        {
            return DatabaseFactory.Create().Update(dataTable, "WIS_INSTRUMENT_INVENTORY");
        }

        public CareDocs.WIS_GRID_TEMPLET_MASTERDataTable GetGridTempletMaster()
        {
            return DatabaseFactory.Create().GetTable<CareDocs.WIS_GRID_TEMPLET_MASTERDataTable>("WIS_GRID_TEMPLET_MASTER");
        }

        public CareDocs.WIS_GRID_TEMPLET_MASTERDataTable GetGridTempletMasterByGuid(string templetGuid)
        {
            IDatabase database = DatabaseFactory.Create();
            CareDocs.WIS_GRID_TEMPLET_MASTERDataTable data = new CareDocs.WIS_GRID_TEMPLET_MASTERDataTable();
            string sql = StoredScript.Get("CareDocs_GetGridTempletMasterByTempletGuid");
            DbParameter templetGuidParameter = database.BuildDbParameter("TEMPLET_GUID", DbType.String, templetGuid);

            database.Fill(sql, data, new DbParameter[] { templetGuidParameter });
            return data;
        }

        public CareDocs.WIS_GRID_TEMPLET_MASTERDataTable GetGridTempletMaster(string templetFlag, string className, string templetName)
        {
            IDatabase database = DatabaseFactory.Create();
            CareDocs.WIS_GRID_TEMPLET_MASTERDataTable data = new CareDocs.WIS_GRID_TEMPLET_MASTERDataTable();
            string sql = StoredScript.Get("CareDocs_GetGridTempletMasterByTempletFlagAndClassNameAndTempletName");
            DbParameter templetFlagParameter = database.BuildDbParameter("GRID_TEMPLET_FLAG", DbType.String, templetFlag);
            DbParameter classNameParameter = database.BuildDbParameter("CLASS_NAME", DbType.String, className);
            DbParameter templetNameParameter = database.BuildDbParameter("TEMPLET_NAME", DbType.String, templetName);
            database.Fill(sql, data, new DbParameter[] { templetFlagParameter,classNameParameter, templetNameParameter });
            return data;
        }

        public CareDocs.WIS_GRID_TEMPLET_MASTERDataTable GetGridTempletMaster(string templetFlag, string className)
        {
            IDatabase database = DatabaseFactory.Create();
            CareDocs.WIS_GRID_TEMPLET_MASTERDataTable data = new CareDocs.WIS_GRID_TEMPLET_MASTERDataTable();
            string sql = StoredScript.Get("CareDocs_GetGridTempletMasterByTempletFlagAndClassName");
            DbParameter templetFlagParameter = database.BuildDbParameter("GRID_TEMPLET_FLAG", DbType.String, templetFlag);
            DbParameter classNameParameter = database.BuildDbParameter("CLASS_NAME", DbType.String, className);
            database.Fill(sql, data, new DbParameter[] { templetFlagParameter, classNameParameter });
            return data;
        }

        public DataTable GetGridTempletGroupByTempletFlag(decimal eventno)
        {
            IDatabase database = DatabaseFactory.Create();
            DataTable data = new DataTable();
            string sql = "SELECT GRID_TEMPLET_FLAG FROM WIS_GRID_TEMPLET_MASTER WHERE EVENT_NO=" + eventno.ToString() + "  GROUP BY GRID_TEMPLET_FLAG";
            database.Fill(sql, data);
            return data;
        }

        public DataTable GetGridTempletGroupByClassName(string templetFlag, decimal eventno,string creatBy)
        {
            IDatabase database = DatabaseFactory.Create();
            DataTable data = new DataTable();
            string sql = "SELECT CLASS_NAME FROM WIS_GRID_TEMPLET_MASTER WHERE GRID_TEMPLET_FLAG='" + templetFlag + "' AND EVENT_NO=" + eventno.ToString() + " AND CREATE_BY='"+creatBy+"'  GROUP BY CLASS_NAME";
            database.Fill(sql, data);
            return data;
        }

        public int UpdateGridTempletMaster(CareDocs.WIS_GRID_TEMPLET_MASTERDataTable dataTable)
        {
            return DatabaseFactory.Create().Update(dataTable, "WIS_GRID_TEMPLET_MASTER");
        }

        public CareDocs.WIS_GRID_TEMPLET_DETAILDataTable GetGridTempletDetail()
        {
            return DatabaseFactory.Create().GetTable<CareDocs.WIS_GRID_TEMPLET_DETAILDataTable>("WIS_GRID_TEMPLET_DETAIL");
        }

        public CareDocs.WIS_GRID_TEMPLET_DETAILDataTable GetGridTempletDetail(string templetGuid)
        {
            IDatabase database = DatabaseFactory.Create();
            CareDocs.WIS_GRID_TEMPLET_DETAILDataTable data = new CareDocs.WIS_GRID_TEMPLET_DETAILDataTable();
            string sql = StoredScript.Get("CareDocs_GetGridTempletDetailByTempletGuid");
            DbParameter templetGuidParameter = database.BuildDbParameter("TEMPLET_GUID", DbType.String, templetGuid);

            database.Fill(sql, data, new DbParameter[] { templetGuidParameter });
            return data;
        }

        public int UpdateGridTempletDetail(CareDocs.WIS_GRID_TEMPLET_DETAILDataTable dataTable)
        {
            return DatabaseFactory.Create().Update(dataTable, "WIS_GRID_TEMPLET_DETAIL");
        }

        public CareDocs.WIS_INSTRUMENT_TEMPLET_MASTERDataTable GetQiXieTempletMaster()
        {
            return DatabaseFactory.Create().GetTable<CareDocs.WIS_INSTRUMENT_TEMPLET_MASTERDataTable>("WIS_INSTRUMENT_TEMPLET_MASTER");
        }

        public CareDocs.WIS_INSTRUMENT_TEMPLET_MASTERDataTable GetQiXieTempletMasterByGuid(string templetGuid)
        {
            IDatabase database = DatabaseFactory.Create();
            CareDocs.WIS_INSTRUMENT_TEMPLET_MASTERDataTable data = new CareDocs.WIS_INSTRUMENT_TEMPLET_MASTERDataTable();
            string sql = StoredScript.Get("CareDocs_GetQiXieTempletMasterByTempletGuid");
            DbParameter templetGuidParameter = database.BuildDbParameter("TEMPLET_GUID", DbType.String, templetGuid);

            database.Fill(sql, data, new DbParameter[] { templetGuidParameter });
            return data;
        }

        public int UpdateQiXieTempletMaster(CareDocs.WIS_INSTRUMENT_TEMPLET_MASTERDataTable dataTable)
        {
            return DatabaseFactory.Create().Update(dataTable, "WIS_INSTRUMENT_TEMPLET_MASTER");
        }

        public CareDocs.WIS_INSTRUMENT_TEMPLET_DETAILDataTable GetQiXieTempletDetail()
        {
            return DatabaseFactory.Create().GetTable<CareDocs.WIS_INSTRUMENT_TEMPLET_DETAILDataTable>("WIS_INSTRUMENT_TEMPLET_DETAIL");
        }

        public CareDocs.WIS_INSTRUMENT_TEMPLET_DETAILDataTable GetQiXieTempletDetailByGuid(string templetGuid)
        {
            IDatabase database = DatabaseFactory.Create();
            CareDocs.WIS_INSTRUMENT_TEMPLET_DETAILDataTable data = new CareDocs.WIS_INSTRUMENT_TEMPLET_DETAILDataTable();
            string sql = StoredScript.Get("CareDocs_GetQiXieTempletDetailByTempletGuid");
            DbParameter templetGuidParameter = database.BuildDbParameter("TEMPLET_GUID", DbType.String, templetGuid);

            database.Fill(sql, data, new DbParameter[] { templetGuidParameter });
            return data;
        }

        public int UpdateQiXieTempletDetail(CareDocs.WIS_INSTRUMENT_TEMPLET_DETAILDataTable dataTable)
        {
            return DatabaseFactory.Create().Update(dataTable, "WIS_INSTRUMENT_TEMPLET_DETAIL");
        }

        /// <summary>
        /// 获取麻醉系统文书打印记录
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <param name="printUserID">打印用户</param>
        /// <param name="printDocName">文书类型名</param>
        /// <returns></returns>
        public CareDocs.MED_ANES_PRINTRECORDDataTable GetAnesPrintRecord(string patientID, int visitID, int operID, string printUserID, string printDocName)
        {
            IDatabase database = DatabaseFactory.Create();
            string sql = "";
            sql += " SELECT * from MED_ANES_PRINTRECORD ";
            sql += " Where 1=1   ";
            sql += " and PAT_ID = '" + patientID + "' AND VISIT_ID =  '" + visitID + "' AND OPER_ID ='" + operID + "'";
            sql += " and  PRINT_USERID  = '" + printUserID + "' AND PRINT_DOC_NAME =  '" + printDocName + "'" ;
            CareDocs.MED_ANES_PRINTRECORDDataTable dataTable = new CareDocs.MED_ANES_PRINTRECORDDataTable();
            DatabaseFactory.Create().Fill(sql, dataTable);
            return dataTable;
        }
        /// <summary>
        /// 获取麻醉系统文书打印记录,与用户无关
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <param name="printDocName">文书类型名</param>
        /// <returns></returns>
        public CareDocs.MED_ANES_PRINTRECORDDataTable GetAnesPrintRecord(string patientID, int visitID, int operID, string printDocName)
        {
            IDatabase database = DatabaseFactory.Create();
            string sql = "";
            sql += " SELECT * from MED_ANES_PRINTRECORD ";
            sql += " Where 1=1   ";
            sql += " and PAT_ID = '" + patientID + "' AND VISIT_ID =  '" + visitID + "' AND OPER_ID ='" + operID + "'";
            sql += " and PRINT_DOC_NAME =  '" + printDocName + "'";
            CareDocs.MED_ANES_PRINTRECORDDataTable dataTable = new CareDocs.MED_ANES_PRINTRECORDDataTable();
            DatabaseFactory.Create().Fill(sql, dataTable);
            return dataTable;
        }

        public int UpdateAnesPrintRecord(CareDocs.MED_ANES_PRINTRECORDDataTable dataTable)
        {
            return DatabaseFactory.Create().Update(dataTable, "MED_ANES_PRINTRECORD");
        }




        //public CareDocs.AnesDocCheckRecordDataTable GetAnesCareCheckRecord(string patientID, int visitID, int operID, string docName)
        //{
        //    IDatabase database = DatabaseFactory.Create();
        //    CareDocs.AnesDocCheckRecordDataTable data = new CareDocs.AnesDocCheckRecordDataTable();
        //    string sql = StoredScript.Get("CareDocs_GetDocCareCheckRecord");
        //    DbParameter patientIDParameter = database.BuildDbParameter("PATIENT_ID", DbType.String, patientID);
        //    DbParameter visitIDParameter = database.BuildDbParameter("VISIT_ID", DbType.Decimal, visitID);
        //    DbParameter operIDParameter = database.BuildDbParameter("OPER_ID", DbType.Decimal, operID);
        //    DbParameter docNameParameter = database.BuildDbParameter("DOC_NAME", DbType.String, docName);
        //    database.Fill(sql, data, new DbParameter[] { patientIDParameter, visitIDParameter, operIDParameter, docNameParameter });
        //    return data;
        //}

        public CareDocs.AnesDocCheckRecordDataTable GetAnesCareCheckRecord(string patientID, int visitID, int operID, string docName)
        {
            IDatabase database = DatabaseFactory.Create();
            CareDocs.AnesDocCheckRecordDataTable data = new CareDocs.AnesDocCheckRecordDataTable();
            string sql = StoredScript.Get("CareDocs_GetDocCareCheckRecord");
            DbParameter patientIDParameter = database.BuildDbParameter("PAT_ID", DbType.String, patientID);
            DbParameter visitIDParameter = database.BuildDbParameter("VISIT_ID", DbType.Decimal, visitID);
            DbParameter operIDParameter = database.BuildDbParameter("OPER_ID", DbType.Decimal, operID);
            DbParameter docNameParameter = database.BuildDbParameter("DOC_NAME", DbType.String, docName);
            database.Fill(sql, data, new DbParameter[] { patientIDParameter, visitIDParameter, operIDParameter, docNameParameter });
            return data;
        }

        public CareDocs.AnesDocCheckRecordDataTable GetAnesCareCheckRecord()
        {
            IDatabase database = DatabaseFactory.Create();
            CareDocs.AnesDocCheckRecordDataTable data = new CareDocs.AnesDocCheckRecordDataTable();
            string sql = "SELECT * FROM WIS_ANES_DOC_CHECK ";
            database.Fill(sql, data);
            return data;
        }
        public int UpdateAnesCareCheckRecord(CareDocs.AnesDocCheckRecordDataTable dataTable)
        {
            return DatabaseFactory.Create().Update(dataTable, "WIS_ANES_DOC_CHECK");
        }
        
    }
}