/*----------------------------------------------------------------
      // Copyright (C) 2008 北京拓扑工厂科技发展有限公司
      // 文件名：AnesthesiaSheet.cs
      // 文件功能描述：麻醉单(复苏单)接口本地实现类
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
    /// 麻醉单(复苏单)接口本地实现类
    /// </summary>
    public class AnesthesiaSheetDA
    {
        private CareDocsDA _careDocsDA = new CareDocsDA();
        private DictDA _dictDA = new DictDA();

        public AnesInformations.AnesthesiaNurseDataTable GetAnesthesiaNurse(string patientID, decimal visitID, decimal operID)
        {
            AnesInformations.AnesthesiaNurseDataTable data = new AnesInformations.AnesthesiaNurseDataTable();

            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("AnesInformations_GetAnesthesiaNurse");

            DbParameter patientId = database.BuildDbParameter("patiendID", DbType.String, patientID);
            DbParameter visitId = database.BuildDbParameter("visitID", DbType.Decimal, visitID);
            DbParameter operId = database.BuildDbParameter("operID", DbType.Decimal, operID);

            database.Fill(sql, data, new DbParameter[] { patientId, visitId, operId });

            return data;

        }

        public int UpdateAnesthesiaNurse(AnesInformations.AnesthesiaNurseDataTable dataTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dataTable, "WIS_ANES_NURSE");

        }

        public AnesInformations.OperationEqipDetailDataTable GetOperationEqipDetail(string patientID, decimal visitID, decimal operID)
        {
            AnesInformations.OperationEqipDetailDataTable data = new AnesInformations.OperationEqipDetailDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("AnesInformations_GetOperationEqipDetail");

            DbParameter patientId = database.BuildDbParameter("patientId", DbType.String, patientID);
            DbParameter visitId = database.BuildDbParameter("visitId", DbType.Decimal, visitID);
            DbParameter operId = database.BuildDbParameter("operId", DbType.Decimal, operID);

            database.Fill(sql, data, new DbParameter[] { patientId, visitId, operId });

            return data;

        }

        public int UpdateOperationEqipDetail(AnesInformations.OperationEqipDetailDataTable dataTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dataTable, "WIS_OPER_EQIP_DETAIL");

        }

        /// <summary>
        /// 获取麻醉信息
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <param name="operID">手术ID</param>
        /// <returns>麻醉信息表</returns>
        public AnesInformations.AnesthesiaEventDataTable GetAnesthesiaEvent(string patientID, decimal visitID, decimal operID, decimal eventNo)
        {
            AnesInformations.AnesthesiaEventDataTable data = new AnesInformations.AnesthesiaEventDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("AnesInformations_GetAnesthesiaEventBy");

            DbParameter patientId = database.BuildDbParameter("PatientID", DbType.String, patientID);
            DbParameter visitId = database.BuildDbParameter("VisitID", DbType.Decimal, visitID);
            DbParameter operId = database.BuildDbParameter("OperID", DbType.Decimal, operID);
            DbParameter eventNumber = database.BuildDbParameter("EventNo", DbType.Decimal, eventNo);

            database.Fill(sql, data, new DbParameter[] { patientId, visitId, operId, eventNumber });
            //持续时间未存到数据库里面，故加载时需要重新计算
            if (data.Count > 0)
            {
                foreach (AnesInformations.AnesthesiaEventRow dr in data)
                {
                    if (!dr.IsEND_DATE_TIMENull() && dr.END_DATE_TIME != DateTime.MinValue && dr.END_DATE_TIME != DateTime.MaxValue)
                    {
                        TimeSpan ts = dr.END_DATE_TIME - dr.START_DATE_TIME;
                        dr.DURATIVE = ts.TotalMinutes.ToString();
                    }
                }
            }
            return data;

        }

        /// <summary>
        /// 获取麻醉信息
        /// </summary>
        /// <returns>麻醉信息表</returns>
        public AnesInformations.AnesthesiaEventDataTable GetAnesthesiaEvent()
        {
            AnesInformations.AnesthesiaEventDataTable data = new AnesInformations.AnesthesiaEventDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("AnesInformations_GetAnesthesiaEvent");
            database.Fill(sql, data);
            return data;

        }

        /// <summary>
        /// 获取麻醉信息
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <returns>麻醉信息表</returns>
        public AnesInformations.AnesthesiaEventDataTable GetAnesthesiaEvent(string patientID, decimal visitID)
        {
            AnesInformations.AnesthesiaEventDataTable data = new AnesInformations.AnesthesiaEventDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("AnesInformations_AnesthesiaEventByPatient");

            DbParameter patientId = database.BuildDbParameter("PatientID", DbType.String, patientID);
            DbParameter visitId = database.BuildDbParameter("VisitID", DbType.Decimal, visitID);

            database.Fill(sql, data, new DbParameter[] { patientId, visitId });
            return data;

        }

        /// <summary>
        /// 获取麻醉信息
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <param name="itemClass">麻醉信息类型</param>
        /// <returns>麻醉信息表</returns>
        public AnesInformations.AnesthesiaEventDataTable GetAnesthesiaEvent(string patientID, decimal visitID, string itemClass)
        {
            AnesInformations.AnesthesiaEventDataTable data = new AnesInformations.AnesthesiaEventDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("AnesInformations_AnesthesiaEventByPatientAndItemClass");
            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patientID);
            DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visitID);
            DbParameter itemClassParameter = database.BuildDbParameter("ItemClass", DbType.String, itemClass);
            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter, itemClassParameter });

            return data;

        }

        /// <summary>
        /// 获取麻醉信息
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <param name="operID">手术ID</param>
        /// <returns>麻醉信息表</returns>
        public AnesInformations.AnesthesiaEventDataTable GetAnesthesiaEvent(string patientID, decimal visitID, decimal operID)
        {
            AnesInformations.AnesthesiaEventDataTable data = new AnesInformations.AnesthesiaEventDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("AnesInformations_AnesthesiaEventByPatientAndOperID");

            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patientID);
            DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visitID);
            DbParameter operIdParameter = database.BuildDbParameter("OperID", DbType.Decimal, operID);

            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter, operIdParameter });
            return data;

        }

        /// <summary>
        /// 获取麻醉信息
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <param name="itemClass">麻醉信息类型</param>
        /// <param name="operID">手术ID</param>
        /// <returns>麻醉信息表</returns>
        public AnesInformations.AnesthesiaEventDataTable GetAnesthesiaEvent(string patientID, decimal visitID, string itemClass, decimal operID)
        {
            AnesInformations.AnesthesiaEventDataTable data = new AnesInformations.AnesthesiaEventDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("AnesInformations_AnesthesiaEventByPatientAndItemClassAndOperID");

            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patientID);
            DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visitID);
            DbParameter itemClassParameter = database.BuildDbParameter("ItemClass", DbType.String, itemClass);
            DbParameter operIdParameter = database.BuildDbParameter("OperID", DbType.Decimal, operID);

            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter, itemClassParameter, operIdParameter });
            return data;

        }

        public int UpdateAnesthesiaEvent(AnesInformations.AnesthesiaEventDataTable dataTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dataTable, "WIS_ANES_EVENT");
        }



        #region "麻醉6.0体征数据获取"

        public int UpdatePatientMonitor(AnesInformations.PatMonitorDateDataTable dataTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dataTable, "WIS_PATIENT_MONITOR");
        }

        /// <summary>
        /// 获取原始监测数据表
        /// </summary>
        /// <returns>原始监测数据表</returns>
        public AnesInformations.PatientMonitorDataTable GetPatientMonitor()
        {
            AnesInformations.PatientMonitorDataTable data = new AnesInformations.PatientMonitorDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("AnesInformations_PatientMonitor");
            database.Fill(sql, data);
            return data;

        }

        /// <summary>
        /// 获取原始监测数据表
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <returns>原始监测数据表</returns>
        public AnesInformations.PatientMonitorDataTable GetPatientMonitor(string patientID, decimal visitID)
        {
            AnesInformations.PatientMonitorDataTable data = new AnesInformations.PatientMonitorDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("AnesInformations_PatientMonitorByPatient");
            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patientID);
            DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visitID);

            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter });
            return data;

        }

        /// <summary>
        /// 获取原始监测数据表
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <param name="operID">手术ID</param>
        /// <returns>原始监测数据表</returns>
        public AnesInformations.PatientMonitorDataTable GetPatientMonitor(string patientID, decimal visitID, decimal operID, decimal eventNo)
        {
            AnesInformations.PatientMonitorDataTable data = new AnesInformations.PatientMonitorDataTable();
            IDatabase database = DatabaseFactory.Create();


            string sql;

            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patientID);
            DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visitID);
            DbParameter operIdParameter = database.BuildDbParameter("OperID", DbType.Decimal, operID);
            DbParameter eventNoParameter = database.BuildDbParameter("EventNo", DbType.Decimal, eventNo);

            if (eventNo > 9)
            {
                sql = StoredScript.Get("AnesInformations_PatientMonitorByPatientAndEventNo");


            }
            else
            {
                sql = StoredScript.Get("AnesInformations_PatientMonitorByPatientAndOperID"); //GetSQL("PatMonitorDateByPatientAndOperID");
                eventNoParameter = database.BuildDbParameter("dataType", DbType.Decimal, eventNo);
                //这个地方我有点看不懂,在PatMonitorDateByPatientAndOperID中定义了参数@dataType,但是在查询参数中却未曾见到dataType -------2011/1/24  by leo
            }
            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter, operIdParameter, eventNoParameter });
            return data;

        }

        public AnesInformations.PatientMonitorDataTable GetPatientMonitorHistory(string patientID, decimal visitID, decimal operID, decimal eventNo)
        {


            AnesInformations.PatientMonitorDataTable data = new AnesInformations.PatientMonitorDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("AnesInformations_GetPatientMonitorHistory");

            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patientID);
            DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visitID);
            DbParameter operIdParameter = database.BuildDbParameter("OperID", DbType.Decimal, operID);
            DbParameter eventNoParameter = database.BuildDbParameter("dataType", DbType.Decimal, eventNo);

            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter, operIdParameter, eventNoParameter });
            return data;
        }





        #endregion








        public int UpdatePatMonitorDate(AnesInformations.PatMonitorDateDataTable dataTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dataTable, "WIS_PAT_MONITOR_DATA");
        }

        /// <summary>
        /// 获取原始监测数据表
        /// </summary>
        /// <returns>原始监测数据表</returns>
        public AnesInformations.PatMonitorDateDataTable GetPatMonitorDate()
        {
            AnesInformations.PatMonitorDateDataTable data = new AnesInformations.PatMonitorDateDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("AnesInformations_PatMonitorDate");
            database.Fill(sql, data);
            return data;

        }

        /// <summary>
        /// 获取原始监测数据表
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <returns>原始监测数据表</returns>
        public AnesInformations.PatMonitorDateDataTable GetPatMonitorDate(string patientID, decimal visitID)
        {
            AnesInformations.PatMonitorDateDataTable data = new AnesInformations.PatMonitorDateDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("AnesInformations_PatMonitorDateByPatient");
            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patientID);
            DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visitID);

            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter });
            return data;

        }

        /// <summary>
        /// 获取原始监测数据表
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <param name="operID">手术ID</param>
        /// <returns>原始监测数据表</returns>
        public AnesInformations.PatMonitorDateDataTable GetPatMonitorDate(string patientID, decimal visitID, decimal operID, decimal eventNo)
        {
            AnesInformations.PatMonitorDateDataTable data = new AnesInformations.PatMonitorDateDataTable();
            IDatabase database = DatabaseFactory.Create();


            string sql;

            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patientID);
            DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visitID);
            DbParameter operIdParameter = database.BuildDbParameter("OperID", DbType.Decimal, operID);
            DbParameter eventNoParameter = database.BuildDbParameter("EventNo", DbType.Decimal, eventNo);

            if (eventNo > 9)
            {
                sql = StoredScript.Get("AnesInformations_PatMonitorDateByPatientAndEventNo");


            }
            else
            {
                sql = StoredScript.Get("AnesInformations_PatMonitorDateByPatientAndOperID"); //GetSQL("PatMonitorDateByPatientAndOperID");
                eventNoParameter = database.BuildDbParameter("dataType", DbType.Decimal, eventNo);
                //这个地方我有点看不懂,在PatMonitorDateByPatientAndOperID中定义了参数@dataType,但是在查询参数中却未曾见到dataType -------2011/1/24  by leo
            }
            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter, operIdParameter, eventNoParameter });
            return data;

        }

        public AnesInformations.PatMonitorDateDataTable GetPatMonitorDataHistory(string patientID, decimal visitID, decimal operID, decimal eventNo)
        {


            AnesInformations.PatMonitorDateDataTable data = new AnesInformations.PatMonitorDateDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("AnesInformations_GetPatMonitorDataHistory");

            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patientID);
            DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visitID);
            DbParameter operIdParameter = database.BuildDbParameter("OperID", DbType.Decimal, operID);
            DbParameter eventNoParameter = database.BuildDbParameter("dataType", DbType.Decimal, eventNo);

            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter, operIdParameter, eventNoParameter });
            return data;
        }



        /// <summary>
        /// 获取手术主表
        /// </summary>
        /// <returns>手术主表</returns>
        public AnesInformations.OperationMasterDataTable GetOperationMaster()
        {
            AnesInformations.OperationMasterDataTable data = new AnesInformations.OperationMasterDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("AnesInformations_GetOperationMaster");
            database.Fill(sql, data);
            return data;

        }
        /// <summary>
        /// 获取手术主表
        /// </summary>
        /// <returns>手术主表</returns>
        public AnesInformations.OperationMasterDataTable GetOperationMaster(DateTime dtStart, DateTime dtEnd)
        {
            AnesInformations.OperationMasterDataTable data = new AnesInformations.OperationMasterDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("AnesInformations_GetOperationMasterByDate");
            DbParameter startTimeParameter = database.BuildDbParameter("startTime", DbType.DateTime, dtStart);
            DbParameter endTimeParameter = database.BuildDbParameter("endTime", DbType.DateTime, dtEnd);
            database.Fill(sql, data, new DbParameter[] { startTimeParameter, endTimeParameter });
            return data;

        }
        /// <summary>
        /// 获取病人手术主表信息
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <param name="operID">手术ID</param>
        /// <returns>病人对应手术主表记录行</returns>
        public AnesInformations.OperationMasterDataTable GetOperationMaster(string patientID, decimal visitID, decimal operID)
        {
            AnesInformations.OperationMasterDataTable data = new AnesInformations.OperationMasterDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("AnesInformations_OperationMasterByPatientAndOperID");
            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patientID);
            DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visitID);
            DbParameter operIdParameter = database.BuildDbParameter("OperID", DbType.Decimal, operID);
            try
            {
                database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter, operIdParameter });

            }
            catch (Exception ex)
            {
                if (data.HasErrors)
                {
                    DataRow[] drs = data.GetErrors();
                }
            }
            return data;

        }
        /// <summary>
        /// 获取病人手术主表信息
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <param name="operID">手术ID</param>
        /// <returns>病人对应手术主表记录行</returns>
        public AnesInformations.OperationMasterDataTable GetOperationMaster(string patientID)
        {
            AnesInformations.OperationMasterDataTable data = new AnesInformations.OperationMasterDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("AnesInformations_OperationMasterByPatient");
            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patientID);

            database.Fill(sql, data, new DbParameter[] { patientIdParameter });

            return data;

        }
        public AnesInformations.OperationMasterDataTable GetOperationMaster(decimal operStatusStart, decimal operStatusEnd, string roomNo)
        {
            AnesInformations.OperationMasterDataTable data = new AnesInformations.OperationMasterDataTable();
            IDatabase database = DatabaseFactory.Create();

            DbParameter roomNoParameter = database.BuildDbParameter("roomNo", DbType.String, roomNo);
            DbParameter operStatusStartParameter = database.BuildDbParameter("operStatusStart", DbType.String, operStatusStart);
            DbParameter operStatusEndParameter = database.BuildDbParameter("operStatusEnd", DbType.String, operStatusEnd);
            string sql = StoredScript.Get("AnesInformations_OperationMasterByRoom");

            database.Fill(sql, data, new DbParameter[] { roomNoParameter, operStatusStartParameter, operStatusEndParameter });
            return data;
        }

        public AnesInformations.OperationMasterDataTable GetOperationMaster(decimal operStatusStart, decimal operStatusEnd, string roomNo, string deptCode)
        {
            AnesInformations.OperationMasterDataTable data = new AnesInformations.OperationMasterDataTable();
            IDatabase database = DatabaseFactory.Create();

            DbParameter roomNoParameter = database.BuildDbParameter("roomNo", DbType.String, roomNo);
            DbParameter deptCodeParameter = database.BuildDbParameter("OPERATING_ROOM", DbType.String, deptCode);
            DbParameter operStatusStartParameter = database.BuildDbParameter("operStatusStart", DbType.String, operStatusStart);
            DbParameter operStatusEndParameter = database.BuildDbParameter("operStatusEnd", DbType.String, operStatusEnd);
            string sql = StoredScript.Get("AnesInformations_OperationMasterByRoomANDRoomNo");

            database.Fill(sql, data, new DbParameter[] { roomNoParameter, deptCodeParameter, operStatusStartParameter, operStatusEndParameter });
            return data;
        }

        public AnesInformations.OperationMasterDataTable GetOperationMaster(string roomNo, decimal operStatus)
        {
            AnesInformations.OperationMasterDataTable data = new AnesInformations.OperationMasterDataTable();
            IDatabase database = DatabaseFactory.Create();

            DbParameter roomNoParameter = database.BuildDbParameter("roomNo", DbType.String, roomNo);
            DbParameter operStatusParameter = database.BuildDbParameter("operStatus", DbType.Decimal, operStatus);

            string sql = StoredScript.Get("AnesInformations_OperationMasterByRoomNo");

            database.Fill(sql, data, new DbParameter[] { roomNoParameter, operStatusParameter });
            return data;

        }

        /// <summary>
        /// 更新手术主表
        /// </summary>
        /// <param name="operationMasterDataTable">手术主表数据集</param>
        /// <returns>更新影响的行数</returns>
        public int UpdateOperationMaster(AnesInformations.OperationMasterDataTable dataTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dataTable, "WIS_OPER_MASTER");

        }

        /// <summary>
        /// 获取病人麻醉主记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">病人本次住院标识</param>
        /// <param name="operID">手术号</param>
        /// <returns>病人麻醉主记录</returns>
        public AnesInformations.AnesthesiaPlanDataTable GetAnesthesiaPlan(string patientID, decimal visitID, decimal operID)
        {
            AnesInformations.AnesthesiaPlanDataTable data = new AnesInformations.AnesthesiaPlanDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("AnesInformations_GetAnesthesiaPlan");

            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patientID);
            DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visitID);
            DbParameter operIdParameter = database.BuildDbParameter("OperID", DbType.Decimal, operID);

            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter, operIdParameter });
            return data;


        }

        /// <summary>
        /// 更新病人麻醉主记录
        /// </summary>
        /// <param name="anesthesiaPlanDataTable">病人麻醉主记录数据集</param>
        /// <returns>更新受影响的行数</returns>
        public int UpdateAnesthesiaPlan(AnesInformations.AnesthesiaPlanDataTable dataTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dataTable, "WIS_ANES_PLAN");

        }

        /// <summary>
        /// 所有采集项目字典
        /// </summary>
        public Dictionary<string, string> GetMonitorFunctionCodeDict()
        {
            Dictionary<string, string> monitorFunctionCodeDict = new Dictionary<string, string>();
            Dict.MonitorFunctionCodeDataTable monitorFunctionCodeDataTable = _dictDA.GetMonitorFunctionCode();
            if (monitorFunctionCodeDataTable != null && monitorFunctionCodeDataTable.Count > 0)
            {
                foreach (Dict.MonitorFunctionCodeRow codeRow in monitorFunctionCodeDataTable.Rows)
                {
                    if (!monitorFunctionCodeDict.ContainsKey(codeRow.ITEM_CODE))
                    {
                        if (!codeRow.IsITEM_NAMENull())
                            monitorFunctionCodeDict.Add(codeRow.ITEM_CODE, codeRow.ITEM_NAME);
                    }
                }
            }
            if (!monitorFunctionCodeDict.ContainsKey("ECG"))
            {
                monitorFunctionCodeDict.Add("ECG", "ECG");
            }
            return monitorFunctionCodeDict;
        }

        public AnesInformations.PatMonitorDateDataTable GetPatMonitorTitleRow(string patientID, decimal visitID, decimal operID)
        {
            AnesInformations.PatMonitorDateDataTable data = new AnesInformations.PatMonitorDateDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("AnesInformations_PatMonitorTitleRow");
            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patientID);
            DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visitID);
            DbParameter operIdParameter = database.BuildDbParameter("OperID", DbType.Decimal, operID);
            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter, operIdParameter });
            return data;

        }

        /// <summary>
        /// 取采集项目code和名称字典
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <param name="eventNo"></param>
        /// <returns></returns>
        public string[] GetVitalSignTitles(string patientID, decimal visitID, decimal operID, decimal eventNo)
        {
            string[] monitorValues = null;
            List<string> monitorValueList = new List<string>();
            Dictionary<string, string> monitorFunctionCodeDict = GetMonitorFunctionCodeDict();




            string applicationVision = new CommonDA().GetApplicationVision();
            if (applicationVision == "ANES5")//如果是麻醉5.0版本 
            {

                //现 麻醉、复苏 检测采集项目，只取数据表中第一行 作为依据 ,固定为 0 ， 2011-10-19 修改
                //AnesInformations.PatMonitorDateDataTable patMonitorDateDataTable = GetPatMonitorDate(patientID, visitID, operID, eventNo);
                AnesInformations.PatMonitorDateDataTable patMonitorDateDataTable = GetPatMonitorTitleRow(patientID, visitID, operID);




                if (patMonitorDateDataTable != null && patMonitorDateDataTable.Count > 0)
                {
                    AnesInformations.PatMonitorDateRow row = patMonitorDateDataTable[0];
                    foreach (AnesInformations.PatMonitorDateRow rw in patMonitorDateDataTable.Rows)
                    {
                        if (rw.ITEM_NO == 0)
                        {
                            row = rw;
                            break;
                        }
                    }
                    if (row.ITEM_NO == 0 && !row.IsMONITOR_VALUENull())
                    {
                        string monitorValue = row.MONITOR_VALUE.Trim();
                        if (!monitorValue.Trim().Equals(""))
                        {

                            int indexOfChar = monitorValue.IndexOf("=");
                            if (indexOfChar == -1)
                            {
                                indexOfChar = 0;
                            }
                            else
                            {
                                indexOfChar = indexOfChar + 1;
                            }
                            monitorValue = monitorValue.Substring(indexOfChar);
                            monitorValues = monitorValue.Split(new string[] { "=", "," }, StringSplitOptions.RemoveEmptyEntries);
                        }
                    }
                }

                if (monitorValues != null && monitorValues.Length > 0)
                {
                    //monitorValueList = new List<string>();
                    foreach (string str in monitorValues)
                    {
                        monitorValueList.Add(str.Trim());
                    }
                }



            }//end if (applicationVision == "ANES5")//如果是麻醉5.0版本 
            else //如果是麻醉6.0版本 
            {
                AnesInformations.PatientMonitorDataTable patientMonitorDataTable = GetPatientMonitor(patientID, visitID, operID, eventNo);

                if (patientMonitorDataTable != null && patientMonitorDataTable.Count > 0)
                {
                    decimal d = 0;
                    foreach (AnesInformations.PatientMonitorRow row in patientMonitorDataTable.Rows)
                    {
                        if (decimal.TryParse(row.ITEM_CODE.Trim(), out d))
                        {
                            if (!monitorValueList.Contains(row.ITEM_CODE.Trim()))
                            {
                                monitorValueList.Add(row.ITEM_CODE.Trim());
                            }
                        }
                        else
                        {
                            string codeStr = "0";
                            foreach (KeyValuePair<string, string> keyValuePair in monitorFunctionCodeDict)
                            {
                                if (keyValuePair.Value.Equals(row.ITEM_CODE) && decimal.TryParse(keyValuePair.Key, out d))
                                {
                                    if (codeStr == "0")
                                    {
                                        codeStr = keyValuePair.Key;
                                    }
                                    else if (d < decimal.Parse(codeStr))
                                    {
                                        codeStr = keyValuePair.Key;
                                    }
                                }
                            }
                            if (codeStr != "0" && !monitorValueList.Contains(codeStr.Trim()))
                            {
                                monitorValueList.Add(codeStr.Trim());
                            }
                        }
                    }
                }




            }


            if (monitorValueList.Count == 0)
            {
                Dict.MonitorDictDataTable mointorDictDataTable = _dictDA.GetMonitorDict(eventNo);
                if (mointorDictDataTable != null)
                {
                    foreach (Dict.MonitorDictRow row in mointorDictDataTable)
                    {
                        if ((!row.IsPAT_IDNull() && !row.IsVISIT_IDNull() && !row.IsOPER_IDNull() && row.PAT_ID.Equals(patientID)
                            && row.VISIT_ID.Equals(visitID) && row.OPER_ID.Equals(operID)) && !row.IsCURRENT_RECV_ITEMSNull())
                        {
                            string[] strs = row.CURRENT_RECV_ITEMS.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (string str in strs)
                            {
                                if (!string.IsNullOrEmpty(str.Trim()) && !monitorValueList.Contains(str.Trim()))
                                {
                                    monitorValueList.Add(str.Trim());
                                }
                            }
                        }
                    }
                    if (monitorValueList.Count == 0)
                    {
                        foreach (Dict.MonitorDictRow row in mointorDictDataTable)
                        {
                            if ((row.IsPAT_IDNull() || (!row.IsPAT_IDNull() && string.IsNullOrEmpty(row.PAT_ID))) && !row.IsCURRENT_RECV_ITEMSNull())
                            {
                                string[] strs = row.CURRENT_RECV_ITEMS.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                foreach (string str in strs)
                                {
                                    if (!string.IsNullOrEmpty(str.Trim()) && !monitorValueList.Contains(str.Trim()))
                                    {
                                        monitorValueList.Add(str.Trim());
                                    }
                                }
                            }
                        }
                    }
                }
            }




            CareDocs.PatMonitorDataExtDataTable patMonitorDataExtDataTable = _careDocsDA.GetPatMonitorDataExtDataTable(patientID, visitID, operID);
            if (patMonitorDataExtDataTable != null && patMonitorDataExtDataTable.Count > 0)
            {
                foreach (CareDocs.PatMonitorDataExtRow row in patMonitorDataExtDataTable)
                {
                    if (!row.IsITEM_VALUENull() && !row.IsITEM_NAMENull() && !row.IsUNITSNull() && !string.IsNullOrEmpty(row.UNITS) && !monitorValueList.Contains(row.ITEM_CODE))
                    {
                        monitorValueList.Add(row.ITEM_CODE);
                    }
                }
            }





            CareDocs.PatientMonitorDataDataTable modifyedData = _careDocsDA.GetPatientMonitorData(patientID, visitID, operID, eventNo);
            if (modifyedData != null && modifyedData.Count > 0)
            {
                decimal d = 0;
                foreach (CareDocs.PatientMonitorDataRow row in modifyedData.Rows)
                {
                    if (decimal.TryParse(row.ITEM_NAME.Trim(), out d))
                    {
                        if (!monitorValueList.Contains(row.ITEM_NAME.Trim()))
                        {
                            monitorValueList.Add(row.ITEM_NAME.Trim());
                        }
                    }
                    else
                    {
                        string codeStr = "0";
                        foreach (KeyValuePair<string, string> keyValuePair in monitorFunctionCodeDict)
                        {
                            if (keyValuePair.Value.Equals(row.ITEM_NAME) && decimal.TryParse(keyValuePair.Key, out d))
                            {
                                if (codeStr == "0")
                                {
                                    codeStr = keyValuePair.Key;
                                }
                                else if (d < decimal.Parse(codeStr))
                                {
                                    codeStr = keyValuePair.Key;
                                }
                            }
                        }
                        if (codeStr != "0" && !monitorValueList.Contains(codeStr.Trim()))
                        {
                            monitorValueList.Add(codeStr.Trim());
                        }
                    }
                }
            }

            if (monitorValueList.Count == 0)
            {
                monitorValueList = new List<string>(new string[] { "40", "44", "65", "66", "71", "92", "188", "112", "148", "89", "90" });
            }

            return monitorValueList.ToArray();
        }

        public AnesInformations.VitalSignDataTable GetVitalSignData(string patientID, decimal visitID, decimal operID, decimal eventNo)
        {
            return GetVitalSignData(patientID, visitID, operID, eventNo, false);
        }

        private void TransVitalSignData(AnesInformations.VitalSignDataTable vitalSignDataTable, DataTable patMonitorDataDataTable, string[] monitorValues)
        {

            if (monitorValues != null && string.IsNullOrEmpty(monitorValues[monitorValues.Length - 1]))
            {
                List<string> list = new List<string>(monitorValues);
                list.RemoveAt(list.Count - 1);
                monitorValues = list.ToArray();
            }
            string applicationVision = new CommonDA().GetApplicationVision();
            if (applicationVision == "ANES5")//如果是麻醉5.0版本 
            {


                if (monitorValues != null)
                {
                    Dictionary<string, string> monitorFunctionCodeDict = GetMonitorFunctionCodeDict();
                    //List<DateTime> times = new List<DateTime>();
                    ///读取监测原始数据并按体征项目名称解析出来
                    for (int i = 0; i < patMonitorDataDataTable.Rows.Count; i++)
                    {
                        if ((decimal)patMonitorDataDataTable.Rows[i]["ITEM_NO"] == 0) continue;
                        string value = patMonitorDataDataTable.Rows[i]["MONITOR_VALUE"].ToString().Trim();
                        if (!value.Trim().Equals(""))
                        {
                            string[] values = value.Split(new string[] { "=", "," }, StringSplitOptions.RemoveEmptyEntries);
                            bool find = false;
                            for (int i1 = 1; i1 < values.Length; i1++)
                            {
                                double d = 0;
                                if (!double.TryParse(values[i1], out d)) d = 0;
                                if (d > 0)
                                {
                                    find = true;
                                    break;
                                }
                            }
                            if (!find) continue;
                            DateTime time = DateTime.Parse(values[0].Trim());
                            //if(times.Contains(time))continue;
                            //times.Add(time);
                            int index = 0;
                            int loopCount = monitorValues.Length;
                            if (loopCount > values.Length - 1) loopCount = values.Length - 1;
                            for (int j = 1; j <= loopCount; j++)
                            {
                                if (values[j] != null && !values[j].Trim().Equals(""))
                                {
                                    double theValue = double.Parse(values[j].Trim());
                                    AnesInformations.VitalSignRow row = vitalSignDataTable.FindByTIME_POINTITEM_CODE(time, monitorValues[index]);
                                    if (row == null)
                                    {
                                        row = vitalSignDataTable.NewVitalSignRow();
                                        row.ITEM_CODE = monitorValues[index];
                                        row.ITEM_NAME = monitorFunctionCodeDict.ContainsKey(monitorValues[index]) ? monitorFunctionCodeDict[monitorValues[index]] : monitorValues[index];
                                        row.TIME_POINT = time;
                                        row.VALUE = theValue.ToString();
                                        vitalSignDataTable.AddVitalSignRow(row);
                                    }
                                    else if (row.IsVALUENull() || string.IsNullOrEmpty(row.VALUE))
                                    {
                                        row.VALUE = theValue.ToString();
                                    }
                                    index++;
                                }
                            }
                        }
                    }
                }
            } //end if (applicationVision == "ANES5")//如果是麻醉5.0版本 

            else//麻醉6.0版本 
            {

                if (vitalSignDataTable == null) vitalSignDataTable = new AnesInformations.VitalSignDataTable();
                if (patMonitorDataDataTable != null && patMonitorDataDataTable.Rows.Count > 0)
                {
                    Dictionary<string, string> monitorFunctionCodeDict = GetMonitorFunctionCodeDict();
                    foreach (AnesInformations.PatientMonitorRow row in patMonitorDataDataTable.Rows)
                    {
                        if (string.IsNullOrEmpty(row.ITEM_VALUE) || row.ITEM_VALUE.Equals("NULL"))
                        {
                            continue;
                        }

                        AnesInformations.VitalSignRow vsRow = vitalSignDataTable.FindByTIME_POINTITEM_CODE(row.TIME_POINT, row.ITEM_CODE);
                        if (vsRow == null)
                        {
                            vsRow = vitalSignDataTable.NewVitalSignRow();
                            vsRow.ITEM_CODE = row.ITEM_CODE;
                            vsRow.ITEM_NAME = row.ITEM_NAME;
                            vsRow.TIME_POINT = row.TIME_POINT;
                            vsRow.VALUE = row.ITEM_VALUE;
                            vitalSignDataTable.AddVitalSignRow(vsRow);
                        }
                        else if (row.IsITEM_VALUENull() || string.IsNullOrEmpty(row.ITEM_VALUE))
                        {
                            vsRow.VALUE = row.ITEM_VALUE;
                        }
                    }
                }

            } //end else  麻醉6.0版本 

        }

        /// <summary>
        /// 获取监测数据表
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <param name="operID">手术ID</param>
        /// <returns>监测数据表</returns>
        public AnesInformations.VitalSignDataTable GetVitalSignData(string patientID, decimal visitID, decimal operID, decimal eventNo, bool isHistory)
        {
            string applicationVision = StoredScript.Get("Common_GetApplicationVision");
            if (applicationVision == "ANES5")//如果是麻醉5.0版本
            {
                DataTable patMonitorDateDataTable = new AnesInformations.PatMonitorDateDataTable();
                AnesInformations.VitalSignDataTable vitalSignDataTable = null;
                if (isHistory)
                {
                    patMonitorDateDataTable = GetPatMonitorDataHistory(patientID, visitID, operID, ((eventNo < 0) ? 0 : eventNo));
                    if (patMonitorDateDataTable != null && patMonitorDateDataTable.Rows.Count > 0)
                    {
                        vitalSignDataTable = new AnesInformations.VitalSignDataTable();
                        string[] monitorValues = GetVitalSignTitles(patientID, visitID, operID, eventNo);
                        TransVitalSignData(vitalSignDataTable, patMonitorDateDataTable, monitorValues);
                    }
                }
                else
                {
                    if (eventNo < 0)
                    {
                        patMonitorDateDataTable = GetPatMonitorDate(patientID, visitID, operID, 1);
                        if (patMonitorDateDataTable != null && patMonitorDateDataTable.Rows.Count > 0)
                        {
                            vitalSignDataTable = new AnesInformations.VitalSignDataTable();
                            string[] monitorValues = GetVitalSignTitles(patientID, visitID, operID, 1);
                            TransVitalSignData(vitalSignDataTable, patMonitorDateDataTable, monitorValues);
                        }
                        patMonitorDateDataTable = GetPatMonitorDate(patientID, visitID, operID, 0);
                        if (patMonitorDateDataTable != null && patMonitorDateDataTable.Rows.Count > 0)
                        {
                            if (vitalSignDataTable == null)
                            {
                                vitalSignDataTable = new AnesInformations.VitalSignDataTable();
                            }
                            string[] monitorValues = GetVitalSignTitles(patientID, visitID, operID, 0);
                            TransVitalSignData(vitalSignDataTable, patMonitorDateDataTable, monitorValues);
                        }
                    }
                    else
                    {
                        patMonitorDateDataTable = GetPatMonitorDate(patientID, visitID, operID, eventNo);
                        if (patMonitorDateDataTable != null && patMonitorDateDataTable.Rows.Count > 0)
                        {
                            vitalSignDataTable = new AnesInformations.VitalSignDataTable();
                            string[] monitorValues = GetVitalSignTitles(patientID, visitID, operID, eventNo);
                            TransVitalSignData(vitalSignDataTable, patMonitorDateDataTable, monitorValues);
                        }
                    }
                }
                if (vitalSignDataTable == null) vitalSignDataTable = new AnesInformations.VitalSignDataTable();
                //Modify by wenpei.x@2014-03-04
                //修复复苏单读取体征数据时读取了麻醉机数据的bug
                if (eventNo < 1)
                {
                    var dataTXT = GetVitalSignDataTXT(patientID, visitID, operID, eventNo);
                    if (dataTXT != null && dataTXT.Count > 0)
                    {
                        foreach (AnesInformations.VitalSignRow row in dataTXT)
                        {
                            AnesInformations.VitalSignRow nrow = vitalSignDataTable.FindByTIME_POINTITEM_CODE(row.TIME_POINT, row.ITEM_CODE);
                            if (nrow == null)
                            {
                                vitalSignDataTable.ImportRow(row);
                            }
                            else
                            {
                                nrow.VALUE = row.VALUE;
                            }
                        }
                    }
                }
                if (!isHistory)
                {
                    AddModifyData(ref vitalSignDataTable, patientID, visitID, operID, ((eventNo < 0) ? 0 : eventNo));
                }
                if (vitalSignDataTable != null && vitalSignDataTable.Count > 0)
                {
                    //vitalSignDataTable.DefaultView.Sort = "TIME_POINT";
                    //vitalSignDataTable = vitalSignDataTable.DefaultView.ToTable() as AnesInformations.VitalSignDataTable;
                    SortTable(vitalSignDataTable, "TIME_POINT");//,ITEM_NAME");
                }
                return vitalSignDataTable;
            }
            else //如果是麻醉6.0 及以上版本
            {

                DataTable patientMonitorDataTable = new AnesInformations.PatientMonitorDataTable();
                AnesInformations.VitalSignDataTable vitalSignDataTable = null;
                if (isHistory)
                {
                    patientMonitorDataTable = GetPatientMonitorHistory(patientID, visitID, operID, ((eventNo < 0) ? 0 : eventNo));
                    if (patientMonitorDataTable != null && patientMonitorDataTable.Rows.Count > 0)
                    {
                        vitalSignDataTable = new AnesInformations.VitalSignDataTable();
                        string[] monitorValues = GetVitalSignTitles(patientID, visitID, operID, eventNo);
                        TransVitalSignData(vitalSignDataTable, patientMonitorDataTable, monitorValues);
                    }
                }
                else
                {
                    if (eventNo < 0)
                    {
                        patientMonitorDataTable = GetPatientMonitor(patientID, visitID, operID, 1);
                        if (patientMonitorDataTable != null && patientMonitorDataTable.Rows.Count > 0)
                        {
                            vitalSignDataTable = new AnesInformations.VitalSignDataTable();
                            string[] monitorValues = GetVitalSignTitles(patientID, visitID, operID, 1);
                            TransVitalSignData(vitalSignDataTable, patientMonitorDataTable, monitorValues);
                        }
                        patientMonitorDataTable = GetPatientMonitor(patientID, visitID, operID, 0);
                        if (patientMonitorDataTable != null && patientMonitorDataTable.Rows.Count > 0)
                        {
                            if (vitalSignDataTable == null)
                            {
                                vitalSignDataTable = new AnesInformations.VitalSignDataTable();
                            }
                            string[] monitorValues = GetVitalSignTitles(patientID, visitID, operID, 0);
                            TransVitalSignData(vitalSignDataTable, patientMonitorDataTable, monitorValues);
                        }
                    }
                    else
                    {
                        patientMonitorDataTable = GetPatientMonitor(patientID, visitID, operID, eventNo);
                        if (patientMonitorDataTable != null && patientMonitorDataTable.Rows.Count > 0)
                        {
                            vitalSignDataTable = new AnesInformations.VitalSignDataTable();
                            string[] monitorValues = GetVitalSignTitles(patientID, visitID, operID, eventNo);
                            TransVitalSignData(vitalSignDataTable, patientMonitorDataTable, monitorValues);
                        }
                    }
                }
                if (vitalSignDataTable == null) vitalSignDataTable = new AnesInformations.VitalSignDataTable();

                //Modify by wenpei.x@2014-03-04
                //修复复苏单读取体征数据时读取了麻醉机数据的bug
                if (eventNo < 1)
                {
                    var dataTXT = GetVitalSignDataTXT(patientID, visitID, operID, eventNo);
                    if (dataTXT != null && dataTXT.Count > 0)
                    {
                        foreach (AnesInformations.VitalSignRow row in dataTXT)
                        {
                            AnesInformations.VitalSignRow nrow = vitalSignDataTable.FindByTIME_POINTITEM_CODE(row.TIME_POINT, row.ITEM_CODE);
                            if (nrow == null)
                            {
                                vitalSignDataTable.ImportRow(row);
                            }
                            else
                            {
                                nrow.VALUE = row.VALUE;
                            }
                        }
                    }
                }
                if (!isHistory)
                {
                    AddModifyData(ref vitalSignDataTable, patientID, visitID, operID, ((eventNo < 0) ? 0 : eventNo));
                }
                if (vitalSignDataTable != null && vitalSignDataTable.Count > 0)
                {
                    //vitalSignDataTable.DefaultView.Sort = "TIME_POINT";
                    //vitalSignDataTable = vitalSignDataTable.DefaultView.ToTable() as AnesInformations.VitalSignDataTable;
                    SortTable(vitalSignDataTable, "TIME_POINT");//,ITEM_NAME");
                }
                return vitalSignDataTable;


            }

        }
        /// <summary>
        /// 排序数据表
        /// </summary>
        /// <param name="sourceTable">源数据表</param>
        /// <param name="sortColumnName">要排序的列</param>
        private void SortTable(DataTable sourceTable, string sortColumnName)
        {

            //if (sourceTable == null || sourceTable.Rows.Count == 0 || !sourceTable.Columns.Contains(sortColumnName)) return;
            sourceTable.DefaultView.Sort = sortColumnName;
            DataTable table = sourceTable.DefaultView.ToTable();
            sourceTable.Clear();
            CopyTable(table, sourceTable);

        }
        private void CopyTable(DataTable sourceTable, DataTable targetTable)
        {
            for (int i = 0; i < sourceTable.Rows.Count; i++)
            {
                DataRow row = targetTable.NewRow();
                for (int j = 0; j < sourceTable.Columns.Count; j++)
                {
                    row[j] = sourceTable.Rows[i][j];
                }
                targetTable.Rows.Add(row);
            }
        }
        private void AddModifyData(ref AnesInformations.VitalSignDataTable vitalSignDataTable, string patientID, decimal visitID, decimal operID, decimal eventNo)
        {
            CareDocs.PatientMonitorDataDataTable modifyedData = _careDocsDA.GetPatientMonitorData(patientID, visitID, operID, eventNo);
            if (vitalSignDataTable == null) vitalSignDataTable = new AnesInformations.VitalSignDataTable();
            if (modifyedData != null && modifyedData.Rows.Count > 0)
            {
                Dictionary<string, string> monitorFunctionCodeDict = GetMonitorFunctionCodeDict();
                foreach (CareDocs.PatientMonitorDataRow row in modifyedData.Rows)
                {
                    if (string.IsNullOrEmpty(row.ITEM_VALUE) || row.ITEM_VALUE.Equals("NULL"))
                    {
                        continue;
                    }
                    AnesInformations.VitalSignRow vsRow = vitalSignDataTable.FindByTIME_POINTITEM_CODE(row.TIME_POINT, row.ITEM_NAME);
                    if (vsRow == null)//兼容苏大附一（新旧合一）
                    {
                        foreach (AnesInformations.VitalSignRow vrow in vitalSignDataTable.Rows)
                        {
                            if (vrow.TIME_POINT.Equals(row.TIME_POINT) && vrow.ITEM_NAME.Equals(row.ITEM_NAME))
                            {
                                vsRow = vrow;
                            }
                        }
                        if (vsRow == null)
                        {
                            bool isAdd = false;
                            foreach (AnesInformations.VitalSignRow vrow in vitalSignDataTable.Rows)
                            {
                                if (vrow.ITEM_NAME.Equals(row.ITEM_NAME))
                                {
                                    isAdd = true;
                                    vsRow = vitalSignDataTable.NewVitalSignRow();
                                    vsRow.TIME_POINT = row.TIME_POINT;
                                    vsRow.ITEM_CODE = vrow.ITEM_CODE;
                                    vsRow.ITEM_NAME = vrow.ITEM_NAME;

                                    //20110818新增，手动修改体征标志
                                    vsRow.Flag = "1";
                                    break;
                                }
                            }
                            if (isAdd && vsRow != null)
                            {
                                vitalSignDataTable.AddVitalSignRow(vsRow);
                            }
                        }
                    }
                    if (vsRow != null)
                    {
                        vsRow.VALUE = row.ITEM_VALUE;

                        //20110818新增，手动修改体征标志
                        vsRow.Flag = "1";
                    }
                    else
                    {
                        vsRow = vitalSignDataTable.NewVitalSignRow();
                        vsRow.ITEM_CODE = row.ITEM_NAME;
                        vsRow.TIME_POINT = row.TIME_POINT;
                        vsRow.ITEM_NAME = monitorFunctionCodeDict.ContainsKey(row.ITEM_NAME) ? monitorFunctionCodeDict[row.ITEM_NAME] : row.ITEM_NAME;
                        vsRow.VALUE = row.ITEM_VALUE;

                        //20110818新增，手动修改体征标志
                        vsRow.Flag = "1";

                        vitalSignDataTable.AddVitalSignRow(vsRow);
                    }
                }
            }
        }

        public AnesInformations.VitalSignDataTable GetVitalSignDataTXT(string patientID, decimal visitID, decimal operID, decimal eventNo)
        {
            AnesInformations.VitalSignDataTable vitalSignDataTable = null;
            Dictionary<string, string> monitorFunctionCodeDict = GetMonitorFunctionCodeDict();
            CareDocs.PatMonitorDataExtDataTable patMonitorDataExtDataTable = _careDocsDA.GetPatMonitorDataExtDataTable(patientID, visitID, operID);
            if (patMonitorDataExtDataTable != null && patMonitorDataExtDataTable.Count > 0)
            {
                vitalSignDataTable = new AnesInformations.VitalSignDataTable();

                foreach (CareDocs.PatMonitorDataExtRow row in patMonitorDataExtDataTable.Rows)
                {
                    AnesInformations.VitalSignRow vitalSignRow = null;
                    if (!row.IsITEM_VALUENull() && !row.IsITEM_NAMENull() && !row.IsUNITSNull() && !string.IsNullOrEmpty(row.UNITS))
                    {
                        vitalSignRow = vitalSignDataTable.FindByTIME_POINTITEM_CODE(row.TIME_POINT, row.ITEM_CODE);
                        if (vitalSignRow == null)
                        {
                            vitalSignRow = vitalSignDataTable.NewVitalSignRow();
                            vitalSignRow.ITEM_CODE = row.ITEM_CODE;
                            vitalSignRow.ITEM_NAME = row.ITEM_NAME;
                            vitalSignRow.TIME_POINT = row.TIME_POINT;
                            vitalSignRow.VALUE = row.ITEM_VALUE;
                            vitalSignDataTable.AddVitalSignRow(vitalSignRow);
                        }
                        else
                        {
                            vitalSignRow.VALUE = row.ITEM_VALUE;
                        }

                    }
                }
            }
            //CareDocs.PatientMonitorDataDataTable patientMonitorDataDataTable = _careDocsDA.GetPatientMonitorData(patientID, visitID, operID, eventNo);
            //if (vitalSignDataTable == null)
            //{
            //    vitalSignDataTable = new AnesInformations.VitalSignDataTable();
            //}
            //if (patientMonitorDataDataTable != null && patientMonitorDataDataTable.Count > 0)
            //{
            //    foreach (CareDocs.PatientMonitorDataRow row in patientMonitorDataDataTable.Rows)
            //    {
            //        AnesInformations.VitalSignRow vitalSignRow = null;
            //        vitalSignRow = vitalSignDataTable.FindByTIME_POINTITEM_CODE(row.TIME_POINT, row.ITEM_NAME);
            //        if (vitalSignRow == null)
            //        {
            //            vitalSignRow = vitalSignDataTable.NewVitalSignRow();
            //            vitalSignRow.ITEM_CODE = row.ITEM_NAME;
            //            vitalSignRow.ITEM_NAME = monitorFunctionCodeDict.ContainsKey(row.ITEM_NAME) ? monitorFunctionCodeDict[row.ITEM_NAME] : row.ITEM_NAME;
            //            vitalSignRow.TIME_POINT = row.TIME_POINT;
            //            vitalSignRow.VALUE = row.ITEM_VALUE;
            //            vitalSignDataTable.AddVitalSignRow(vitalSignRow);
            //        }
            //        else
            //        {
            //            vitalSignRow.VALUE = row.ITEM_VALUE;
            //        }
            //    }
            //}
            return vitalSignDataTable;
        }

        /// <summary>
        /// 获取江苏麻醉科操作记录表
        /// </summary>
        /// <returns>江苏麻醉科操作记录表</returns>
        public AnesInformations.JSMZKCaoZhuoDataTable GetJSMZKCaoZhuoData()
        {
            AnesInformations.JSMZKCaoZhuoDataTable data = new AnesInformations.JSMZKCaoZhuoDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("AnesInformations_GetJSMZKCaoZhuoData");
            database.Fill(sql, data);
            return data;

        }

        /// <summary>
        /// 获取江苏麻醉科操作记录表
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <param name="operID">手术ID</param>
        /// <returns>江苏麻醉科操作记录表</returns>
        public AnesInformations.JSMZKCaoZhuoDataTable GetJSMZKCaoZhuoData(string patientID, decimal visitID, decimal operID)
        {
            AnesInformations.JSMZKCaoZhuoDataTable data = new AnesInformations.JSMZKCaoZhuoDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("AnesInformations_GetJSMZKCaoZhuoDataBy");
            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patientID);
            DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visitID);
            DbParameter operIdParameter = database.BuildDbParameter("OperID", DbType.Decimal, operID);


            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter, operIdParameter });
            return data;

        }

        /// <summary>
        /// 更新江苏麻醉科操作记录表
        /// </summary>
        /// <param name="jsMZKCaoZhuoDataTable"></param>
        /// <returns>更新的行数</returns>
        public int UpdateJSMZKCaoZhuoData(AnesInformations.JSMZKCaoZhuoDataTable updateTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(updateTable, "WIS_JS_ANES_OPERATION");

        }


        /// <summary>
        /// PACU
        /// </summary>
        /// <returns></returns>
        public AnesInformations.AnesthesiaPACUDataTable GetAnesthesiaPACUData()
        {
            AnesInformations.AnesthesiaPACUDataTable data = new AnesInformations.AnesthesiaPACUDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("AnesInformations_GetAnesthesiaPACUData");
            database.Fill(sql, data);
            return data;

        }

        /// <summary>
        /// PACU
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        public AnesInformations.AnesthesiaPACUDataTable GetAnesthesiaPACUData(string patientID, decimal visitID, decimal operID)
        {
            AnesInformations.AnesthesiaPACUDataTable data = new AnesInformations.AnesthesiaPACUDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("AnesInformations_GetAnesthesiaPACUDataBy");
            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patientID);
            DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visitID);
            DbParameter operIdParameter = database.BuildDbParameter("OperID", DbType.Decimal, operID);

            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter, operIdParameter });
            return data;

        }
        public DataTable GetOperationScheduleData(string patientID, decimal visitID)
        {
            DataTable data = new DataTable();

            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("PatientBaseInformations_GetOperationSchedule");
            DbParameter patientIdParameter = database.BuildDbParameter("PATIENT_ID", DbType.String, patientID);
            DbParameter visitIdParameter = database.BuildDbParameter("VISIT_ID", DbType.Decimal, visitID);

            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter });
            return data;
        }

        public DataTable GetOperationScheduleData(string patientID, decimal visitID, decimal scheduleID)
        {
            DataTable data = new DataTable();

            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("PatientBaseInformations_GetOperationScheduleByKeys");
            DbParameter patientIdParameter = database.BuildDbParameter("PATIENT_ID", DbType.String, patientID);
            DbParameter visitIdParameter = database.BuildDbParameter("VISIT_ID", DbType.Decimal, visitID);
            DbParameter scheduleParameter = database.BuildDbParameter("SCHEDULE_ID", DbType.Decimal, scheduleID);
            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter, scheduleParameter });
            return data;
        }
        /// <summary>
        /// 更新PACU
        /// </summary>
        /// <param name="jsMZKCaoZhuoDataTable"></param>
        /// <returns>更新的行数</returns>
        public int UpdateAnesthesiaPACUData(AnesInformations.AnesthesiaPACUDataTable updateTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(updateTable, "WIS_ANES_RECOVERY");

        }

        public AnesInformations.VitalSignDataTable GetCPBVitalSignData(string patientID, decimal visitID, decimal operID, decimal eventNo)
        {
            AnesInformations.VitalSignDataTable vitalSignDataTable = null;
            Dictionary<string, string> monitorFunctionCodeDict = GetMonitorFunctionCodeDict();
            CareDocs.PatMonitorDataExtDataTable patMonitorDataExtDataTable = _careDocsDA.GetPatMonitorDataExtDataTable(patientID, visitID, operID);
            if (patMonitorDataExtDataTable != null && patMonitorDataExtDataTable.Count > 0)
            {
                vitalSignDataTable = new AnesInformations.VitalSignDataTable();

                foreach (CareDocs.PatMonitorDataExtRow row in patMonitorDataExtDataTable.Rows)
                {
                    AnesInformations.VitalSignRow vitalSignRow = null;
                    if (int.Parse(row.ITEM_CODE) >= 800 && int.Parse(row.ITEM_CODE) < 900 && !row.IsITEM_VALUENull() && !string.IsNullOrEmpty(row.UNITS) && !row.UNITS.Equals("Sec") && !row.UNITS.Equals("L"))
                    {
                        vitalSignRow = vitalSignDataTable.FindByTIME_POINTITEM_CODE(row.TIME_POINT, row.ITEM_CODE);
                        if (vitalSignRow == null)
                        {
                            vitalSignRow = vitalSignDataTable.NewVitalSignRow();
                            vitalSignRow.ITEM_CODE = row.ITEM_CODE;
                            vitalSignRow.ITEM_NAME = row.ITEM_NAME;
                            vitalSignRow.TIME_POINT = row.TIME_POINT;
                            vitalSignRow.VALUE = row.ITEM_VALUE;
                            vitalSignDataTable.AddVitalSignRow(vitalSignRow);
                        }
                        else
                        {
                            vitalSignRow.VALUE = row.ITEM_VALUE;
                        }

                    }
                }

            }
            CareDocs.PatientMonitorDataDataTable patientMonitorDataDataTable = _careDocsDA.GetPatientMonitorData(patientID, visitID, operID, eventNo);
            if (vitalSignDataTable == null)
            {
                vitalSignDataTable = new AnesInformations.VitalSignDataTable();
            }
            if (patientMonitorDataDataTable != null && patientMonitorDataDataTable.Count > 0)
            {
                foreach (CareDocs.PatientMonitorDataRow row in patientMonitorDataDataTable.Rows)
                {
                    AnesInformations.VitalSignRow vitalSignRow = null;
                    vitalSignRow = vitalSignDataTable.FindByTIME_POINTITEM_CODE(row.TIME_POINT, row.ITEM_NAME);
                    if (vitalSignRow == null)
                    {
                        vitalSignRow = vitalSignDataTable.NewVitalSignRow();
                        vitalSignRow.ITEM_CODE = row.ITEM_NAME;
                        vitalSignRow.ITEM_NAME = monitorFunctionCodeDict.ContainsKey(row.ITEM_NAME) ? monitorFunctionCodeDict[row.ITEM_NAME] : row.ITEM_NAME;
                        vitalSignRow.TIME_POINT = row.TIME_POINT;
                        vitalSignRow.VALUE = row.ITEM_VALUE;
                        vitalSignDataTable.AddVitalSignRow(vitalSignRow);
                    }
                    else
                    {
                        vitalSignRow.VALUE = row.ITEM_VALUE;
                    }
                }
            }
            return vitalSignDataTable;
        }

        /// <summary>
        /// 获取麻醉信息
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <param name="itemClass">麻醉信息类型</param>
        /// <param name="operID">手术ID</param>
        /// <returns>麻醉信息表</returns>
        public AnesInformations.WIS_PAT_DRUG_DETAILDataTable GetPatientDrugItem(string patientID, decimal visitID, decimal operID)
        {
            return GetPatientDrugItem(patientID, visitID, operID, 0);
        }

        public AnesInformations.WIS_PAT_DRUG_DETAILDataTable GetPatientDrugItem(string patientID, decimal visitID, decimal operID, decimal itemType)
        {
            AnesInformations.WIS_PAT_DRUG_DETAILDataTable data = new AnesInformations.WIS_PAT_DRUG_DETAILDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = " SELECT * FROM WIS_PAT_DRUG_DETAIL WHERE PAT_ID = '" + patientID + "' AND VISIT_ID = "
                + visitID + " AND OPER_ID = " + operID + " AND SERIAL_NO >= " + (itemType * 1000).ToString() +
                " AND SERIAL_NO < " + (itemType * 1000 + 1000).ToString() + " ORDER BY SERIAL_NO ";
            database.Fill(sql, data);
            return data;
        }

        /// <summary>
        /// 更新PACU
        /// </summary>
        /// <param name="jsMZKCaoZhuoDataTable"></param>
        /// <returns>更新的行数</returns>
        public int UpdatePatientDrugItem(AnesInformations.WIS_PAT_DRUG_DETAILDataTable updateTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(updateTable, "WIS_PAT_DRUG_DETAIL");
        }

        public AnesInformations.PunctureRecordDataTable GetPunctureRecordDataTable()
        {
            return DatabaseFactory.Create().GetTable<AnesInformations.PunctureRecordDataTable>("WIS_PUNCTURE_RECORD");
        }

        public AnesInformations.PunctureRecordDataTable GetPunctureRecordDataTable(string patientID, decimal visitID, decimal operID)
        {
            AnesInformations.PunctureRecordDataTable data = new AnesInformations.PunctureRecordDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("AnesInformations_GetPunctureRecordDataTable");
            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patientID);
            DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visitID);
            DbParameter OperIdParameter = database.BuildDbParameter("OperID", DbType.Decimal, operID);
            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter, OperIdParameter });
            return data;
        }

        public int UpdatePunctureRecordDataTable(AnesInformations.PunctureRecordDataTable dataTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dataTable, "WIS_PUNCTURE_RECORD");
        }

        public int UpdateOperationScheduleStatus(string patientID, decimal visitID, decimal operID, int status)
        {
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("AnesInformations_UpdateOperationScheduleStatus");
            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patientID);
            DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visitID);
            DbParameter OperIdParameter = database.BuildDbParameter("OperID", DbType.Decimal, operID);
            DbParameter statusParameter = database.BuildDbParameter("Status", DbType.Decimal, status);
            return database.ExecuteNonQuery(sql, new DbParameter[] { patientIdParameter, visitIdParameter, OperIdParameter, statusParameter });
        }

        public AnesInformations.AnesOperHandoverDataTable GetAnesOperHandoverDataTable(string patientID, decimal visitID, decimal operID)
        {
            AnesInformations.AnesOperHandoverDataTable data = new AnesInformations.AnesOperHandoverDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("AnesInformations_GetAnesOperHandoverDataTable");
            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patientID);
            DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visitID);
            DbParameter OperIdParameter = database.BuildDbParameter("OperID", DbType.Decimal, operID);
            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter, OperIdParameter });
            return data;
        }

        public int UpdateAnesOperHandoverDataTable(AnesInformations.AnesOperHandoverDataTable dataTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dataTable, "WIS_ANES_OPER_HANDOVER");
        }

        public AnesthesiaSheet.ScheduledOperationNameDataTable GetScheduledOperationName(string patientID, decimal visitID, decimal operID)
        {
            AnesthesiaSheet.ScheduledOperationNameDataTable data = new AnesthesiaSheet.ScheduledOperationNameDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("AnesthesiaSheet_GetScheduledOperationName");
            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patientID);
            DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visitID);
            DbParameter OperIdParameter = database.BuildDbParameter("OperID", DbType.Decimal, operID);
            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter, OperIdParameter });
            return data;
        }

        public AnesInformations.OperShiftRecordDataTable GetOperShiftRecordDataTable()
        {
            return DatabaseFactory.Create().GetTable<AnesInformations.OperShiftRecordDataTable>("WIS_OPER_SHIFT_RECORD");
        }

        public AnesInformations.OperShiftRecordDataTable GetOperShiftRecordDataTable(string patientID, decimal visitID, decimal operID)
        {
            AnesInformations.OperShiftRecordDataTable data = new AnesInformations.OperShiftRecordDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("AnesInformations_GetOperShiftRecordDataTable");
            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patientID);
            DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visitID);
            DbParameter OperIdParameter = database.BuildDbParameter("OperID", DbType.Decimal, operID);
            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter, OperIdParameter });
            return data;
        }

        public int UpdateOperShiftRecordDataTable(AnesInformations.OperShiftRecordDataTable dataTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dataTable, "WIS_OPER_SHIFT_RECORD");
        }

        public DataTable GetAnesAlarmMsg(string patientID, decimal visitID, decimal operID)
        {

            DataTable data = new DataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = " select * from WIS_ANES_ALARM_MSG Where PAT_ID = '" + patientID + "' and VISIT_ID = "
            + visitID.ToString() + " and OPER_ID = " + operID.ToString() + " ORDER BY MSG_NO DESC ";


            database.Fill(sql, data);
            return data;
        }

        public int UpdateAnesAlarmMsg(DataTable dataTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dataTable, "WIS_ANES_ALARM_MSG");
        }



        public decimal GetMaxItemNO(string patientID, decimal visitID, decimal operID, decimal eventNo)
        {
            int result = 0;
            DataTable data = new DataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = string.Format("SELECT MAX(ITEM_NO) FROM WIS_ANES_EVENT WHERE PAT_ID='{0}' AND VISIT_ID={1} AND OPER_ID={2} AND EVENT_NO={3}", patientID, visitID.ToString(), operID.ToString(), eventNo.ToString());


            database.Fill(sql, data);
            if (data.Rows.Count > 0)
            {
                result = Convert.ToInt16(string.IsNullOrEmpty(data.Rows[0][0].ToString()) ? 0 : data.Rows[0][0]);
            }
            return result;
        }
        public DataTable GetOperCanceledInfo()
        {

            DataTable data = new DataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql =string.Format( " select PATIENT_ID,VISIT_ID,OPER_ID,NAME,SEX,DEPT_NAME,SCHEDULED_DATE_TIME,ANESTHESIA_METHOD,OPER_NAME from OPERATION_INFO Where SCHEDULED_DATE_TIME >='{0}' and SCHEDULED_DATE_TIME <='{1}' and OPER_STATUS ='-80' ORDER BY SCHEDULED_DATE_TIME desc",DateTime.Now.AddDays(-30).ToString(),DateTime.Now.ToString());

            database.Fill(sql, data);
            return data;
        }

        public int UpdateCancelOper(string patientID, decimal visitID, decimal operID)
        {
            IDatabase database = DatabaseFactory.Create();
            string sql = string.Format("UPDATE WIS_OPER_MASTER SET OPER_STATUS= '0' WHERE PAT_ID ='{0}' AND VISIT_ID ={1} AND OPER_ID = {2}", patientID, visitID, operID);
            string sqlCancel = string.Format("DELETE WIS_OPER_CANCELED WHERE PAT_ID ='{0}' AND VISIT_ID ={1} AND SCHEDULED_DATE_TIME = (SELECT SCHEDULED_DATE_TIME FROM WIS_OPER_MASTER WHERE  PAT_ID ='{0}' AND VISIT_ID ={1} AND OPER_ID = {2})", patientID, visitID, operID);

            int cm1 = database.ExecuteNonQuery(sql);
            int cm2 = database.ExecuteNonQuery(sqlCancel);
            return cm1;
        }
    }
}
