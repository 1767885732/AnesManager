/*----------------------------------------------------------------
      // Copyright (C) 2008 北京拓扑工厂科技发展有限公司
      // 文件名：PatientBaseInformations.cs
      // 文件功能描述：病人基本信息接口本地实现类
      //
      // 
      // 创建标识：XXX-2008-10-23
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Data;
using System.Data;
using System.Configuration;

namespace Wis.Anes.DataAccess
{
    /// <summary>
    /// 病人基本信息类
    /// </summary>
    public partial class PatientInformationsDA 
    {
        public PatientBaseInformations.OperationsInfoDataTable GetHistoryOpertionsInfo()
        {
            PatientBaseInformations.OperationsInfoDataTable data = new PatientBaseInformations.OperationsInfoDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("PatientBaseInformations_GetHistoryOpertionsInfo");
            database.Fill(sql, data); 
            return data;
            //return GetData<PatientBaseInformations.OperationsInfoDataTable>(GetSQL("OperationsInfo"));
            //return new PatientBaseInformationsTableAdapters.OperationsInfoTableAdapter().GetDataAll();
        }

        public PatientBaseInformations.OperationsInfoDataTable GetOpertionsInfo(decimal operStatus)
        {
            PatientBaseInformations.OperationsInfoDataTable data = new PatientBaseInformations.OperationsInfoDataTable();
            IDatabase database = DatabaseFactory.Create();
            DbParameter operStatusParameter = database.BuildDbParameter("OperStatus", DbType.Decimal, operStatus);
            string sql = StoredScript.Get("PatientBaseInformations_GetOperationsInfoByOperStatus");
            database.Fill(sql, data, new DbParameter[] { operStatusParameter });
            return data;
            //return GetData<PatientBaseInformations.OperationsInfoDataTable>(GetSQL("OperationsInfoByOperStatus"), new object[] { operStatus });
            //return new PatientBaseInformationsTableAdapters.OperationsInfoTableAdapter().GetData(operStatus);
        }

        public PatientBaseInformations.OperationsInfoDataTable GetOpertionsInfo(DateTime startTime,DateTime endTime)
        {
            PatientBaseInformations.OperationsInfoDataTable data = new PatientBaseInformations.OperationsInfoDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("PatientBaseInformations_GetOperationsInfoByStartTime");
            DbParameter startTimeParameter = database.BuildDbParameter("startTime", DbType.DateTime, startTime);
            DbParameter endTimeParameter = database.BuildDbParameter("endTime", DbType.DateTime, endTime);

            database.Fill(sql, data, new DbParameter[] { startTimeParameter, endTimeParameter });
            return data;
            //return GetData<PatientBaseInformations.OperationsInfoDataTable>(GetSQL("OperationsInfoByStartTime"), new object[] { startTime, endTime });
            //return new PatientBaseInformationsTableAdapters.OperationsInfoTableAdapter().GetDataByStartTime(startTime,endTime);
        }
        /// <summary>
        /// 获取在院病人信息
        /// </summary>
        /// <returns></returns>
        public PatientBaseInformations.PatsInHospitalDataTable GetPatsInHospital()
        {
            PatientBaseInformations.PatsInHospitalDataTable data = new PatientBaseInformations.PatsInHospitalDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("PatientBaseInformations_GetPatsInHospital");
            database.Fill(sql, data);
            return data;
           // return GetData<PatientBaseInformations.PatsInHospitalDataTable>(GetSQL("PatsInHospital"));
            //return new PatientBaseInformationsTableAdapters.PatsInHospitalAdapter().GetData();
        }

        public PatientBaseInformations.PatsInHospitalDataTable GetPatsInHospital(string patientID)
        {
            PatientBaseInformations.PatsInHospitalDataTable data = new PatientBaseInformations.PatsInHospitalDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("PatientBaseInformations_GetPatsInHospitalByPatientID");
            DbParameter patientIdParameter = database.BuildDbParameter("PATIENT_ID", DbType.String, patientID);
            database.Fill(sql, data, new DbParameter[] { patientIdParameter });
            return data;
        }

        public PatientBaseInformations.PatsInHospitalDataTable GetPatsInHospital(string patientID, decimal visitID)
        {
            PatientBaseInformations.PatsInHospitalDataTable data = new PatientBaseInformations.PatsInHospitalDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("PatientBaseInformations_GetPatsInHospitalBy");
            DbParameter patientIdParameter = database.BuildDbParameter("PATIENT_ID", DbType.String, patientID);
            DbParameter visitIdParameter = database.BuildDbParameter("VISIT_ID", DbType.Decimal, visitID);

            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter });
            return data;
            //string sqlText = GetSQL("PatsInHospital");
            //if (sqlText.ToLower().Contains(" where "))
            //{
            //    sqlText += " AND PATIENT_ID = '" + patientID + "' AND VISIT_ID " + visitID.ToString();
            //}
            //else
            //{
            //    sqlText += " WHERE PATIENT_ID = '" + patientID + "' AND VISIT_ID = " + visitID.ToString();
            //}
           // return GetData<PatientBaseInformations.PatsInHospitalDataTable>(sqlText);
            //return new PatientBaseInformationsTableAdapters.PatsInHospitalAdapter().GetData();
        }

        public int UpdatePatsInHospitalDataTable(PatientBaseInformations.PatsInHospitalDataTable dataTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return  database.Update(dataTable, "WIS_PAT_IN_HOS");
            //return UpdateData<PatientBaseInformations.PatsInHospitalDataTable>(dataTable, GetSQL("PatsInHospital"));
        }
        /// <summary>
        /// 获取病人信息 
        /// </summary>
        /// <returns></returns>
        public PatientBaseInformations.PatientInformationDataTable GetPatientInformation(decimal operStatus, bool useMin)
        {
            PatientBaseInformations.PatientInformationDataTable data = new PatientBaseInformations.PatientInformationDataTable();
            IDatabase database = DatabaseFactory.Create();
            DbParameter operStatusParameter = database.BuildDbParameter("OperStatus", DbType.Decimal, operStatus);
            if (useMin)
            {
                string sql = StoredScript.Get("PatientBaseInformations_PatientInformationByMinOperStauts");
                database.Fill(sql, data, new DbParameter[] { operStatusParameter });
               // return GetData<PatientBaseInformations.PatientInformationDataTable>(GetSQL("PatientInformationByMinOperStauts"), new object[] { operStatus });
                //return new PatientBaseInformationsTableAdapters.PatientInformationAdapter().GetDataByMinOperStauts(operStatus);
            }
            else
            {
                string sql = StoredScript.Get("PatientBaseInformations_GetPatientInformation");
                database.Fill(sql, data, new DbParameter[] { operStatusParameter });
               // return GetData<PatientBaseInformations.PatientInformationDataTable>(GetSQL("PatientInformation"), new object[] { operStatus });
                //return new PatientBaseInformationsTableAdapters.PatientInformationAdapter().GetData(operStatus);
            }
            return data;
        }
        /// <summary>
        /// 获取某病人基本信息记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <returns>病人基本信息记录</returns>
        public PatientBaseInformations.PatMasterIndexDataTable GetPatMasterIndexDataTable(string patientID)
        {
            PatientBaseInformations.PatMasterIndexDataTable data = new PatientBaseInformations.PatMasterIndexDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("PatientBaseInformations_GetPatMasterIndexByPatient");
            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patientID);
            database.Fill(sql, data, new DbParameter[] { patientIdParameter });

            return data;
            //return GetData<PatientBaseInformations.PatMasterIndexDataTable>(GetSQL("PatMasterIndexByPatient"), new object[] { patientID });
            //return new PatientBaseInformationsTableAdapters.PatMasterIndexAdapter().GetDataBy(patientID);
        }
        /// <summary>
        /// 获取某病人基本信息记录
        /// </summary>
        /// <returns>病人基本信息记录</returns>
        public PatientBaseInformations.PatMasterIndexDataTable GetPatMasterIndexDataTable()
        {
            PatientBaseInformations.PatMasterIndexDataTable data = new PatientBaseInformations.PatMasterIndexDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("PatientBaseInformations_GetPatMasterIndex");
            database.Fill(sql, data);
            return data;
           // return GetData<PatientBaseInformations.PatMasterIndexDataTable>(GetSQL("PatMasterIndex"));
            //return new PatientBaseInformationsTableAdapters.PatMasterIndexAdapter().GetData();
        }
        /// <summary>
        /// 更新病人基本信息记录
        /// </summary>
        /// <param name="patMasterIndexDataTable">病人基本信息数据集</param>
        /// <returns>更新受影响的行数</returns>
        public int UpdatePatMasterIndexDataTable(PatientBaseInformations.PatMasterIndexDataTable dataTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dataTable, "WIS_PAT_MASTER_INDEX");
           // return UpdateData<PatientBaseInformations.PatMasterIndexDataTable>(dataTable,GetSQL("PatMasterIndex"));
            //return new PatientBaseInformationsTableAdapters.PatMasterIndexAdapter().Update(dataTable);
        }

        /// <summary>
        /// 更新病人基本信息记录及病人手术主记录
        /// </summary>
        /// <param name="patMasterIndexDataTable">病人基本信息数据集</param>
        /// <returns>更新受影响的行数</returns>
        public int UpdatePatMasterIndexOperationMaster(PatientBaseInformations.PatMasterIndexDataTable patMasterIndexDataTable,
                                                        AnesInformations.OperationMasterDataTable operationMasterDataTable)
        {
            //try
            //{
               // UpdatePatMasterIndexDataTable(patMasterIndexDataTable);
               // UpdateOperationMaster(operationMasterDataTable);
                IDatabase database = DatabaseFactory.Create();
                using (DbWrapTransaction transaction = database.CreateDbTransaction())
                {
                    database.Update(patMasterIndexDataTable, "WIS_PAT_MASTER_INDEX");
                    database.Update(operationMasterDataTable, "WIS_OPER_MASTER");
                    transaction.Commit();
                    return 1;
                }
                 
               
            //}
            //catch { return -1; }
            //PatientBaseInformationsTableAdapters.PatMasterIndexAdapter PatMasterIndexAdapter1 = new PatientBaseInformationsTableAdapters.PatMasterIndexAdapter();
            //AnesInformationsTableAdapters.OperationMasterAdapter OperationMasterAdapter1 = new AnesInformationsTableAdapters.OperationMasterAdapter();

            //DbTransaction DbTransaction1 = DataFunction.BeginTransaction(PatMasterIndexAdapter1);
            //try
            //{
            //    DataFunction.SetTransaction(OperationMasterAdapter1, DbTransaction1);
            //    PatMasterIndexAdapter1.Update(patMasterIndexDataTable);
            //    OperationMasterAdapter1.Update(operationMasterDataTable);
            //    DbTransaction1.Commit();
            //    return 1;
            //}
            //catch
            //{
            //    DbTransaction1.Rollback();
            //    return -1;
            //}
        }

        /// <summary>
        /// 获取某病人住院记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">病人本次住院标识</param>
        /// <returns>病人住院记录</returns>
        public PatientBaseInformations.PatVisitDataTable GetVisitDataTable(string patientID, decimal visitID)
        {
            PatientBaseInformations.PatVisitDataTable data = new PatientBaseInformations.PatVisitDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("PatientBaseInformations_GetVisitDataTable");
            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patientID);
            DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visitID);

            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter });
            return data;

            //return GetData<PatientBaseInformations.PatVisitDataTable>(GetSQL("PatVisitByPatient"), new object[] { patientID ,visitID});
            //return new PatientBaseInformationsTableAdapters.PatVisitAdapter().GetData(patientID, visitID);
        }

        /// <summary>
        /// 更新病人住院记录
        /// </summary>
        /// <param name="patVisitDataTable">病人住院记录信息数据集</param>
        /// <returns>更新受影响的行数</returns>
        public int UpdateVisitDataTable(PatientBaseInformations.PatVisitDataTable dataTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dataTable, "WIS_PAT_VISIT");
           // return UpdateData<PatientBaseInformations.PatVisitDataTable>(dataTable, GetSQL("PatVisitByPatient"), new object[] { "000000", 0 });
            //return new PatientBaseInformationsTableAdapters.PatVisitAdapter().Update(dataTable);
        }

        /// <summary>
        /// 返回病人手术信息
        /// </summary>
        /// <returns></returns>
        public PatientBaseInformations.PatOperationDataTable GetPatOperation()
        {
            PatientBaseInformations.PatOperationDataTable data = new PatientBaseInformations.PatOperationDataTable();
            IDatabase database = DatabaseFactory.Create();
           
            string sql = StoredScript.Get("PatientBaseInformations_GetPatOperation");

            database.Fill(sql, data);
            return data;
           // return GetData<PatientBaseInformations.PatOperationDataTable>(GetSQL("PatOperation"));
            //return new PatientBaseInformationsTableAdapters.PatOperationTableAdapter().GetData();
        }
        /// <summary>
        /// 返回病人信息以及手术信息
        /// </summary>
        /// <returns></returns>

        public PatientBaseInformations.PatOperationDataTable GetPatOperation(string patient_id, decimal visit_id, decimal schedule_id)
        {
            PatientBaseInformations.PatOperationDataTable data = new PatientBaseInformations.PatOperationDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("PatientBaseInformations_GetPatOperationByPatient");
            DbParameter patientIdParameter = database.BuildDbParameter("patient_id", DbType.String, patient_id);
            DbParameter visitIdParameter = database.BuildDbParameter("visit_id", DbType.Decimal, visit_id);
            DbParameter scheduleIdParameter = database.BuildDbParameter("SCHEDULE_ID", DbType.Decimal, schedule_id);
            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter, scheduleIdParameter });
            return data;
           // return GetData<PatientBaseInformations.PatOperationDataTable>(GetSQL("PatOperationByPatient"),new object[]{patient_id,visit_id,schedule_id});
            //return new PatientBaseInformationsTableAdapters.PatOperationTableAdapter().GetDataBy(patient_id, visit_id, schedule_id);
        }
       
       
        /// <summary>
        /// 获取病人主记录表Oder_id
        /// </summary>
        /// <param name="patient_id">病人ID</param>
        /// <param name="visit_id">本次住院标识</param>
        /// <returns></returns>
        public PatientBaseInformations.MaxValueDataTable GetOper_id(string patient_id, decimal visit_id)
        {
            PatientBaseInformations.MaxValueDataTable data = new PatientBaseInformations.MaxValueDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("PatientBaseInformations_GetMaxValueOperID");
            DbParameter patientIdParameter = database.BuildDbParameter("patient_id", DbType.String, patient_id);
            DbParameter visitIdParameter = database.BuildDbParameter("visit_id", DbType.Decimal, visit_id);

            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter });
            return data;
           // return GetData<PatientBaseInformations.MaxValueDataTable>(GetSQL("MaxValueOperID"),new object[]{patient_id,visit_id});
            //return new PatientBaseInformationsTableAdapters.MaxValueTableAdapter().GetMaxOperID(patient_id, visit_id);
        }

        public PatientBaseInformations.MaxValueDataTable GetMaxEventItemNo(string patient_id, decimal visit_id, decimal oper_id)
        {
            PatientBaseInformations.MaxValueDataTable data = new PatientBaseInformations.MaxValueDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("PatientBaseInformations_GetMaxEventItemNo");

            DbParameter patientIdParameter = database.BuildDbParameter("PatientID", DbType.String, patient_id);
            DbParameter visitIdParameter = database.BuildDbParameter("VisitID", DbType.Decimal, visit_id);
            DbParameter OperIdParameter = database.BuildDbParameter("OperID", DbType.Decimal, oper_id);

            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter, OperIdParameter });
            return data;
            //return GetData<PatientBaseInformations.MaxValueDataTable>(GetSQL("MaxValueEventItemNo"), new object[] { patient_id, visit_id ,oper_id});

            //return new PatientBaseInformationsTableAdapters.MaxValueTableAdapter().GetMaxEventItemNo(patient_id, visit_id, oper_id);
        }

        /// <summary>
        /// 获取病人visit_id
        /// </summary>
        /// <param name="patient_id">病人ID</param>
        /// <returns></returns>
        public PatientBaseInformations.MaxValueDataTable GetVisit_id(string patient_id) 
        {
            PatientBaseInformations.MaxValueDataTable data = new PatientBaseInformations.MaxValueDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("PatientBaseInformations_GetMaxValueVisitID");
            DbParameter patientIdParameter = database.BuildDbParameter("PATIENT_ID", DbType.String, patient_id);

            database.Fill(sql, data, new DbParameter[] { patientIdParameter });
            return data;
            //return GetData<PatientBaseInformations.MaxValueDataTable>(GetSQL("MaxValueVisitID"), new object[] { patient_id });
            //return new PatientBaseInformationsTableAdapters.MaxValueTableAdapter().GetMaxVisitID(patient_id);
        }


        /// <summary>
        /// 根据条件获取患者信息表
        /// </summary>
        public DataTable GetPatientListDataTable(DateTime startDate, string patientID, string patientName, string anesthesiaDoctor, string departCode
            , string operationStatus, string asa, string operationName, string anesthesiaMethod, string age, string age1)
        {
            bool hasScheduleTable = false;
            //string s = System.Configuration.ConfigurationManager.AppSettings["PatientListHasScheduleTable"];
            //if (!string.IsNullOrEmpty(s) && s.ToLower().Equals("true"))
            //{
            //    hasScheduleTable = true;
            //}
            return GetPatientListDataTable(startDate, patientID, patientName, anesthesiaDoctor, departCode, operationStatus
                , asa, operationName, anesthesiaMethod, age, age1, hasScheduleTable);
        }

        /// <summary>
        /// 根据条件获取患者信息表
        /// </summary>
        public DataTable GetPatientListDataTable(DateTime startDate, string patientID, string patientName, string anesthesiaDoctor, string departCode
            , string operationStatus, string asa, string operationName, string anesthesiaMethod, string age, string age1, bool hasScheduleTable)
        {
            DataTable dataTable = GetPatientListDataTable2(startDate, patientID, patientName, anesthesiaDoctor, departCode, operationStatus
                , asa, operationName, anesthesiaMethod, age, age1);
            if (hasScheduleTable)
            {
                DataTable dataTable1 = GetPatientListDataTable1(startDate, patientID, patientName, anesthesiaDoctor, departCode, operationStatus
                , asa, operationName, anesthesiaMethod, age, age1);
                if (dataTable1 != null)
                {
                    if (dataTable == null)
                    {
                        dataTable = dataTable1;
                    }
                    else
                    {
                        dataTable.Merge(dataTable1);
                    }
                }
            }
            return dataTable;
        }

        /// <summary>
        /// 根据条件获取患者信息表
        /// </summary>
        public DataTable GetPatientListDataTable1(DateTime startDate, string patientID, string patientName, string anesthesiaDoctor, string departCode
            , string operationStatus, string asa, string operationName, string anesthesiaMethod, string age, string age1)
        {
            IDatabase database = DatabaseFactory.Create();
            DateTime dtStart = startDate;
            DateTime dtEnd = dtStart.AddDays(1);
            List<object> objects = new List<object>();
            //string sqlText = "SELECT distinct A.PAT_ID,VISIT_ID,OPER_ID,OPER_STATUS,NAME,OPERATING_ROOM_NO,BED_NO,SEQUENCE ,   "
            //+ " ANES_DOCTOR,SECOND_ANES_DOCTOR,THIRD_ANES_DOCTOR,ANES_ASSISTANT,SECOND_ANES_ASSISTANT,SURGEON,FIRST_ASSISTANT,SECOND_ASSISTANT,THIRD_ASSISTANT,FOURTH_ASSISTANT,FOURTH_ANES_ASSISTANT,FIRST_OPER_NURSE,SECOND_OPER_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,THIRD_SUPPLY_NURSE,"
            //+ "SCHEDULED_DATE_TIME START_DATE_TIME,SURGEON,OPER_NAME,OPER_SCALE FROM WIS_OPER_MASTER A,WIS_PAT_MASTER_INDEX B WHERE "
            //     + "A.PAT_ID = B.PAT_ID  ";
            string sqlText = "SELECT distinct A.PAT_ID,VISIT_ID,OPER_ID,0 OPER_STATUS,NAME,OPERATING_ROOM_NO,BED_NO,SEQUENCE ,  B.INP_NO,  "
            + " ANES_DOCTOR,SECOND_ANES_DOCTOR,THIRD_ANES_DOCTOR,ANES_ASSISTANT,SECOND_ANES_ASSISTANT,SURGEON,FIRST_ASSISTANT,SECOND_ASSISTANT,THIRD_ASSISTANT,FOURTH_ASSISTANT,FOURTH_ANES_ASSISTANT,FIRST_OPER_NURSE,SECOND_OPER_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,THIRD_SUPPLY_NURSE,"
            + "SCHEDULED_DATE_TIME START_DATE_TIME,SURGEON,OPER_NAME,OPER_SCALE FROM WIS_OPER_SCHEDULE A,WIS_PAT_MASTER_INDEX B WHERE "
                 + "A.PAT_ID = B.PAT_ID  ";
            // AND (OPER_STATUS != -1 OR OPER_STATUS =)";
            //string sqlText = "SELECT A.PAT_ID,A.VISIT_ID,A.OPER_ID,A.OPER_STATUS,B.NAME,A.OPERATING_ROOM_NO,A.BED_NO,A.ANES_DOCTOR,"
            //+ "A.SCHEDULED_DATE_TIME START_DATE_TIME,A.SURGEON,A.OPER_NAME,A.OPER_SCALE,C.ASA_GRADE FROM WIS_OPER_MASTER A "
            //+ " LEFT OUTER JOIN WIS_PAT_MASTER_INDEX B ON A.PAT_ID = B.PAT_ID LEFT OUTER JOIN WIS_ANES_PLAN C ON "
            //+ " A.PAT_ID = C.PATIENT_ID AND A.VISIT_ID=C.VISIT_ID AND A.OPER_ID=C.OPER_ID WHERE A.OPER_STATUS >= -1";
            List<DbParameter> parameters = new List<DbParameter>();
            if (startDate > DateTime.MinValue && startDate < DateTime.MaxValue)
            {
                sqlText = sqlText + " AND (A.SCHEDULED_DATE_TIME >= " + DatabaseFactory.TransParameter("startTime") + ") AND (SCHEDULED_DATE_TIME <= " + DatabaseFactory.TransParameter("endTime") + ")";
                parameters.Add(database.BuildDbParameter("startTime", DbType.DateTime, dtStart));
                parameters.Add(database.BuildDbParameter("endTime", DbType.DateTime, dtEnd));
            }
            string pID = patientID;
            if (!string.IsNullOrEmpty(pID))
            {
                sqlText = sqlText + " AND (A.PAT_ID LIKE '%" + pID + "%' OR B.INP_NO LIKE '%" + pID + "%')";
            }
            string name = patientName;
            if (!string.IsNullOrEmpty(name))
            {
                sqlText = sqlText + " AND (B.NAME LIKE '%" + name + "%')";
            }
            string text = anesthesiaDoctor;
            if (!string.IsNullOrEmpty(text))
            {
                //text为用#分割的名字和ID组合
                string[] docsArr = text.Split(new char[] { '#' });
                sqlText = sqlText + " AND ( 1 = 2 ";
                for (int i = 0; i < docsArr.Length; i++)
                {
                    if (docsArr[i].Length > 0)
                    {

                        sqlText = sqlText + " OR (A.ANES_DOCTOR LIKE '%" + docsArr[i] + "%' )";
                        sqlText = sqlText + " OR (A.SECOND_ANES_DOCTOR LIKE '%" + docsArr[i] + "%' )";
                        sqlText = sqlText + " OR (A.THIRD_ANES_DOCTOR LIKE '%" + docsArr[i] + "%' )";
                        sqlText = sqlText + " OR (A.ANES_ASSISTANT LIKE '%" + docsArr[i] + "%' )";
                        sqlText = sqlText + " OR (A.SECOND_ANES_ASSISTANT LIKE '%" + docsArr[i] + "%' )";
                        sqlText = sqlText + " OR (A.THIRD_ANES_ASSISTANT LIKE '%" + docsArr[i] + "%' )";
                        sqlText = sqlText + " OR (A.FOURTH_ANES_ASSISTANT LIKE '%" + docsArr[i] + "%' )";
                    }
                }
                sqlText = sqlText + " ) ";
            }
            text = departCode;
            if (!string.IsNullOrEmpty(text))
            {
                //DataRow[] rows = _deptDict.Select("DEPT_NAME = '" + text + "'");
                //if (rows.Length > 0 && rows[0]["DEPT_CODE"] != System.DBNull.Value)
                //{
                //    text = rows[0]["DEPT_CODE"].ToString();
                //}
                sqlText = sqlText + " AND (DEPT_STAYED = '" + text + "')";
            }
            text = operationStatus;
            if (!string.IsNullOrEmpty(text))
            {
                //NewOperationStatus.OperationStatus operationStatus = NewOperationStatus.OperationStatusFromString(text);
                //sqlText = sqlText + " AND (OPER_STATUS = " + ((int)operationStatus).ToString() + ")";
                sqlText = sqlText + " AND (A.OPER_STATUS = " + text + ")";
            }
            //text = txtDoctor.Text;
            //if (!string.IsNullOrEmpty(text))
            //{
            //    sqlText = sqlText + " AND (SURGEON = '" + text + "')";
            //}
            //text = txtDiagnosis.Text;
            //if (!string.IsNullOrEmpty(text))
            //{
            //    sqlText = sqlText + " AND (DIAG_BEFORE_OPER LIKE '%" + text + "%')";
            //}
            //text = asa;
            //if (!string.IsNullOrEmpty(text))
            //{
            //    sqlText = sqlText + " AND (C.ASA_GRADE = '" + text + "')";
            //}
            text = operationName;
            if (!string.IsNullOrEmpty(text))
            {
                sqlText = sqlText + " AND (A.OPER_NAME LIKE '%" + text + "%')";
            }
            text = anesthesiaMethod;
            if (!string.IsNullOrEmpty(text))
            {
                sqlText = sqlText + " AND (A.ANES_METHOD LIKE '%" + text + "%')";
            }
            text = age;
            if (!string.IsNullOrEmpty(text))
            {
                int theAge = 0;
                if (int.TryParse(text, out theAge))
                {
                    DateTime dtStart1 = DateTime.Now.AddYears(-theAge);
                    dtStart1 = new DateTime(dtStart1.Year, 1, 1);
                    DateTime dtEnd1 = dtStart1.AddYears(1).AddSeconds(-1);
                    if (!string.IsNullOrEmpty(age1))
                    {
                        if (int.TryParse(age1, out theAge))
                        {
                            dtStart1 = new DateTime(DateTime.Now.Year - theAge, 1, 1);
                        }
                    }
                    sqlText = sqlText + " AND (DATE_OF_BIRTH >= " + DatabaseFactory.TransParameter("dtStart1") + " AND DATE_OF_BIRTH < " + DatabaseFactory.TransParameter("dtEnd1") + ")";
                    parameters.Add(database.BuildDbParameter("dtStart1", DbType.DateTime, dtStart1));
                    parameters.Add(database.BuildDbParameter("dtEnd1", DbType.DateTime, dtEnd1));
                }
            }
            sqlText = sqlText + " ORDER BY OPER_STATUS , A.OPERATING_ROOM_NO,SEQUENCE,START_DATE_TIME  ";
            DataTable dataTable = new DataTable();
            if (parameters.Count > 0)
            {
                DatabaseFactory.Create().Fill(sqlText, dataTable, parameters.ToArray());
            }
            else
            {
                DatabaseFactory.Create().Fill(sqlText, dataTable);
            }
            if (dataTable != null)
            {
                dataTable.DefaultView.RowFilter = "(OPER_STATUS >= 0) OR (OPER_STATUS IS NULL)";
                dataTable = dataTable.DefaultView.ToTable();
            }
            return dataTable;
        }

        /// <summary>
        /// 根据条件获取患者信息表
        /// </summary>
        public DataTable GetPatientListDataTable2(DateTime startDate, string patientID, string patientName, string anesthesiaDoctor, string departCode
            , string operationStatus, string asa, string operationName, string anesthesiaMethod, string age, string age1)
        {
            IDatabase database = DatabaseFactory.Create();
            DateTime dtStart = startDate;
            DateTime dtEnd = dtStart.AddDays(1);
            List<object> objects = new List<object>();

            // asa 被定义成科室


            string sqlText = " SELECT * FROM ( SELECT distinct A.PAT_ID AS PAT_ID ,VISIT_ID,OPER_ID,OPER_STATUS,NAME ,OPERATING_ROOM_NO,BED_NO,SEQUENCE , B.INP_NO AS INP_NO , A.emergency_indicator, A.ISOLATION_INDICATOR, "
            + " ANES_DOCTOR,SECOND_ANES_DOCTOR,THIRD_ANES_DOCTOR,ANES_ASSISTANT,SECOND_ANES_ASSISTANT,SURGEON,FIRST_ASSISTANT,SECOND_ASSISTANT,THIRD_ASSISTANT,FOURTH_ASSISTANT,THIRD_ANES_ASSISTANT,FOURTH_ANES_ASSISTANT,FIRST_OPER_NURSE,SECOND_OPER_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,THIRD_SUPPLY_NURSE,"

            + "  CASE WHEN IN_DATE_TIME IS NULL THEN SCHEDULED_DATE_TIME else IN_DATE_TIME end as START_DATE_TIME ,OPER_NAME,ANES_METHOD,DEPT_STAYED, "
            + " OPER_SCALE ,SCHEDULED_DATE_TIME ,DATE_OF_BIRTH, IN_DATE_TIME ,operating_room,IN_PACU_DATE_TIME FROM "
            + " WIS_OPER_MASTER A,WIS_PAT_MASTER_INDEX B WHERE "            
            + "A.PAT_ID = B.PAT_ID   ) AS C WHERE 1=1 ";
            
            List<DbParameter> parameters = new List<DbParameter>();
            if (startDate > DateTime.MinValue && startDate < DateTime.MaxValue)
            {
                sqlText = sqlText + " AND ((SCHEDULED_DATE_TIME >= " + DatabaseFactory.TransParameter("startTime") + " AND SCHEDULED_DATE_TIME < " + DatabaseFactory.TransParameter("endTime") + ")"
                               + " OR (IN_DATE_TIME >= " + DatabaseFactory.TransParameter("startTime") + " AND IN_DATE_TIME <= " + DatabaseFactory.TransParameter("endTime") + "))";
 
                parameters.Add(database.BuildDbParameter("startTime", DbType.DateTime, dtStart));
                parameters.Add(database.BuildDbParameter("endTime", DbType.DateTime, dtEnd));
            }
            string pID = patientID;
            if (!string.IsNullOrEmpty(pID))
            {
                sqlText = sqlText + " AND (PAT_ID LIKE '%" + pID + "%' OR INP_NO LIKE '%" + pID + "%')";
            }
            string name = patientName;
            if (!string.IsNullOrEmpty(name))
            {
                sqlText = sqlText + " AND (NAME LIKE '%" + name + "%')";
            }

            if (!string.IsNullOrEmpty(asa))
            {
                //sqlText = sqlText + " AND (operating_room = '" + asa + "')"; 
                string[] depts = asa.Split(',');
                string dept= string.Join("','", depts);
                sqlText = sqlText + " AND (operating_room in ('" + dept + "'))"; //龙山支持查多个科室
            }

            string text = anesthesiaDoctor;
            if (!string.IsNullOrEmpty(text))
            {
                //text为用#分割的名字和ID组合
                string[] docsArr = text.Split(new char[] { '#' });
                sqlText = sqlText + " AND ( 1 = 2 ";
                for (int i = 0; i < docsArr.Length; i++)
                {
                    if (docsArr[i].Length > 0)
                    {

                        sqlText = sqlText + " OR (ANES_DOCTOR LIKE '%" + docsArr[i] + "%' )";
                        sqlText = sqlText + " OR (SECOND_ANES_DOCTOR LIKE '%" + docsArr[i] + "%' )";
                        sqlText = sqlText + " OR (THIRD_ANES_DOCTOR LIKE '%" + docsArr[i] + "%' )";
                        sqlText = sqlText + " OR (ANES_ASSISTANT LIKE '%" + docsArr[i] + "%' )";
                        sqlText = sqlText + " OR (SECOND_ANES_ASSISTANT LIKE '%" + docsArr[i] + "%' )";
                        sqlText = sqlText + " OR (THIRD_ANES_ASSISTANT LIKE '%" + docsArr[i] + "%' )";
                        sqlText = sqlText + " OR (FOURTH_ANES_ASSISTANT LIKE '%" + docsArr[i] + "%' )";
                    }
                }
                sqlText = sqlText + " ) ";
            }
            text = departCode;
            if (!string.IsNullOrEmpty(text))
            {                
                sqlText = sqlText + " AND (DEPT_STAYED = '" + text + "')";
            }
            text = operationStatus;
            if (!string.IsNullOrEmpty(text))
            {                
                sqlText = sqlText + " AND (OPER_STATUS = " + text + ")";
            }            
            text = operationName;
            if (!string.IsNullOrEmpty(text))
            {
                sqlText = sqlText + " AND (OPER_NAME LIKE '%" + text + "%')";
            }
            text = anesthesiaMethod;
            if (!string.IsNullOrEmpty(text))
            {
                sqlText = sqlText + " AND (ANES_METHOD LIKE '%" + text + "%')";
            }
            text = age;
            if (!string.IsNullOrEmpty(text))
            {
                int theAge = 0;
                if (int.TryParse(text, out theAge))
                {
                    DateTime dtStart1 = DateTime.Now.AddYears(-theAge);
                    dtStart1 = new DateTime(dtStart1.Year, 1, 1);
                    DateTime dtEnd1 = dtStart1.AddYears(1).AddSeconds(-1);
                    if (!string.IsNullOrEmpty(age1))
                    {
                        if (int.TryParse(age1, out theAge))
                        {
                            dtStart1 = new DateTime(DateTime.Now.Year - theAge, 1, 1);
                        }
                    }
                    sqlText = sqlText + " AND (DATE_OF_BIRTH >= " + DatabaseFactory.TransParameter("dtStart1") + " AND DATE_OF_BIRTH < " + DatabaseFactory.TransParameter("dtEnd1") + ")";
                    parameters.Add(database.BuildDbParameter("dtStart1", DbType.DateTime, dtStart1));
                    parameters.Add(database.BuildDbParameter("dtEnd1", DbType.DateTime, dtEnd1));
                }  
            }
 
            sqlText = sqlText + " ORDER BY OPER_STATUS , OPERATING_ROOM_NO,SEQUENCE,START_DATE_TIME  ";
            DataTable dataTable = new DataTable();
            dataTable.TableName = "PatientListDataTable2";
            
            if (parameters.Count > 0)
            {
                DatabaseFactory.Create().Fill(sqlText, dataTable, parameters.ToArray());
            }
            else
            {
                DatabaseFactory.Create().Fill(sqlText, dataTable);
            }
            if (dataTable != null)
            {
                dataTable.DefaultView.RowFilter = "(OPER_STATUS >= 0) OR (OPER_STATUS IS NULL)";
                dataTable = dataTable.DefaultView.ToTable();
            }
            return dataTable;
        }

        public DataTable GetUnDonePatientList(string operRoomNo)
        {
            //IDatabase database = DatabaseFactory.Create();
            DataTable dataTable = new DataTable();
            string sqlText = "SELECT distinct A.PAT_ID,VISIT_ID,OPER_ID,OPER_STATUS,NAME,OPERATING_ROOM_NO,BED_NO,SEQUENCE , B.INP_NO, A.emergency_indicator, A.ISOLATION_INDICATOR,  "
            + " ANES_DOCTOR,SECOND_ANES_DOCTOR,THIRD_ANES_DOCTOR,ANES_ASSISTANT,SECOND_ANES_ASSISTANT,SURGEON,FIRST_ASSISTANT,SECOND_ASSISTANT,THIRD_ASSISTANT,FOURTH_ASSISTANT,FOURTH_ANES_ASSISTANT,FIRST_OPER_NURSE,SECOND_OPER_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,THIRD_SUPPLY_NURSE,"
            + "SCHEDULED_DATE_TIME START_DATE_TIME,SURGEON,OPER_NAME,OPER_SCALE FROM WIS_OPER_MASTER A,WIS_PAT_MASTER_INDEX B WHERE "
                 + "A.PAT_ID = B.PAT_ID AND  (A.OPER_STATUS >= 5 AND A.OPER_STATUS < 35) ";
            if (!string.IsNullOrEmpty(operRoomNo))
            {
                sqlText += " AND A.OPERATING_ROOM_NO='" + operRoomNo + "' ";
            }
            sqlText += " ORDER BY A.OPER_STATUS,A.OPERATING_ROOM_NO ";
            DatabaseFactory.Create().Fill(sqlText, dataTable);
            if (dataTable != null)
            {
                dataTable.DefaultView.RowFilter = "(OPER_STATUS >= 0) OR (OPER_STATUS IS NULL)";
                dataTable = dataTable.DefaultView.ToTable();
            }
            return dataTable;
        }


        /// <summary>
        /// 根据条件获取患者信息表
        /// </summary>
        public DataTable GetPatientListDataTable(DateTime startDate,DateTime endDate, string patientID, string patientName, string anesthesiaDoctor, string departCode
            , string operationStatus, string asa, string operationName, string anesthesiaMethod, string age, string age1)
        {
            IDatabase database = DatabaseFactory.Create();
            DateTime dtStart = startDate;
            if (endDate <= startDate)
            {
                dtStart.AddDays(1);
            }
            endDate = dtStart;
            DateTime dtEnd = endDate;

            List<object> objects = new List<object>();
            string sqlText = "SELECT distinct A.PAT_ID,VISIT_ID,OPER_ID,OPER_STATUS,NAME,OPERATING_ROOM_NO,BED_NO,SEQUENCE ,   "
            + " ANES_DOCTOR,SECOND_ANES_DOCTOR,THIRD_ANES_DOCTOR,ANES_ASSISTANT,SECOND_ANES_ASSISTANT,SURGEON,FIRST_ASSISTANT,SECOND_ASSISTANT,THIRD_ASSISTANT,FOURTH_ASSISTANT,FOURTH_ANES_ASSISTANT,FIRST_OPER_NURSE,SECOND_OPER_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,THIRD_SUPPLY_NURSE,"
            + "SCHEDULED_DATE_TIME START_DATE_TIME,SURGEON,OPER_NAME,OPER_SCALE FROM WIS_OPER_MASTER A,WIS_PAT_MASTER_INDEX B WHERE "
                 + "A.PAT_ID = B.PAT_ID";// AND (OPER_STATUS != -1 OR OPER_STATUS =)";
            //string sqlText = "SELECT A.PAT_ID,A.VISIT_ID,A.OPER_ID,A.OPER_STATUS,B.NAME,A.OPERATING_ROOM_NO,A.BED_NO,A.ANES_DOCTOR,"
            //+ "A.SCHEDULED_DATE_TIME START_DATE_TIME,A.SURGEON,A.OPER_NAME,A.OPER_SCALE,C.ASA_GRADE FROM WIS_OPER_MASTER A "
            //+ " LEFT OUTER JOIN WIS_PAT_MASTER_INDEX B ON A.PAT_ID = B.PATIENT_ID LEFT OUTER JOIN WIS_ANES_PLAN C ON "
            //+ " A.PAT_ID = C.PATIENT_ID AND A.VISIT_ID=C.VISIT_ID AND A.OPER_ID=C.OPER_ID WHERE A.OPER_STATUS >= -1";
            List<DbParameter> parameters = new List<DbParameter>();
            if (startDate > DateTime.MinValue && startDate < DateTime.MaxValue)
            {
                sqlText = sqlText + " AND (A.SCHEDULED_DATE_TIME >= " + DatabaseFactory.TransParameter("startTime") + ") AND (SCHEDULED_DATE_TIME <= " + DatabaseFactory.TransParameter("endTime") + ")";
                parameters.Add(database.BuildDbParameter("startTime", DbType.DateTime, dtStart));
                parameters.Add(database.BuildDbParameter("endTime", DbType.DateTime, dtEnd));
            }
            string pID = patientID;
            if (!string.IsNullOrEmpty(pID))
            {
                sqlText = sqlText + " AND (A.PAT_ID LIKE '%" + pID + "%')";
            }
            string name = patientName;
            if (!string.IsNullOrEmpty(name))
            {
                sqlText = sqlText + " AND (B.NAME LIKE '%" + name + "%')";
            }
            string text = anesthesiaDoctor;
            if (!string.IsNullOrEmpty(text))
            {
                sqlText = sqlText + " AND (A.ANES_DOCTOR LIKE '%" + text + "%')";
            }
            text = departCode;
            if (!string.IsNullOrEmpty(text))
            {
                //DataRow[] rows = _deptDict.Select("DEPT_NAME = '" + text + "'");
                //if (rows.Length > 0 && rows[0]["DEPT_CODE"] != System.DBNull.Value)
                //{
                //    text = rows[0]["DEPT_CODE"].ToString();
                //}
                sqlText = sqlText + " AND (DEPT_STAYED = '" + text + "')";
            }
            text = operationStatus;
            if (!string.IsNullOrEmpty(text))
            {
                //NewOperationStatus.OperationStatus operationStatus = NewOperationStatus.OperationStatusFromString(text);
                //sqlText = sqlText + " AND (OPER_STATUS = " + ((int)operationStatus).ToString() + ")";
                sqlText = sqlText + " AND (A.OPER_STATUS = " + text + ")";
            }
            //text = txtDoctor.Text;
            //if (!string.IsNullOrEmpty(text))
            //{
            //    sqlText = sqlText + " AND (SURGEON = '" + text + "')";
            //}
            //text = txtDiagnosis.Text;
            //if (!string.IsNullOrEmpty(text))
            //{
            //    sqlText = sqlText + " AND (DIAG_BEFORE_OPER LIKE '%" + text + "%')";
            //}
            //text = asa;
            //if (!string.IsNullOrEmpty(text))
            //{
            //    sqlText = sqlText + " AND (C.ASA_GRADE = '" + text + "')";
            //}
            text = operationName;
            if (!string.IsNullOrEmpty(text))
            {
                sqlText = sqlText + " AND (A.OPER_NAME LIKE '%" + text + "%')";
            }
            text = anesthesiaMethod;
            if (!string.IsNullOrEmpty(text))
            {
                sqlText = sqlText + " AND (A.ANES_METHOD LIKE '%" + text + "%')";
            }
            text = age;
            if (!string.IsNullOrEmpty(text))
            {
                int theAge = 0;
                if (int.TryParse(text, out theAge))
                {
                    DateTime dtStart1 = DateTime.Now.AddYears(-theAge);
                    dtStart1 = new DateTime(dtStart1.Year, 1, 1);
                    DateTime dtEnd1 = dtStart1.AddYears(1).AddSeconds(-1);
                    if (!string.IsNullOrEmpty(age1))
                    {
                        if (int.TryParse(age1, out theAge))
                        {
                            dtStart1 = new DateTime(DateTime.Now.Year - theAge, 1, 1);
                        }
                    }
                    sqlText = sqlText + " AND (DATE_OF_BIRTH >= " + DatabaseFactory.TransParameter("dtStart1") + " AND DATE_OF_BIRTH < " + DatabaseFactory.TransParameter("dtEnd1") + ")";


                    parameters.Add(database.BuildDbParameter("dtStart1", DbType.DateTime, dtStart1));
                    parameters.Add(database.BuildDbParameter("dtEnd1", DbType.DateTime, dtEnd1));
                }

            }
            sqlText = sqlText + " ORDER BY OPER_STATUS , A.OPERATING_ROOM_NO,SEQUENCE,START_DATE_TIME  ";
            DataTable dataTable = new DataTable();
            if (parameters.Count > 0)
            {
                DatabaseFactory.Create().Fill(sqlText, dataTable, parameters.ToArray());
            }
            else
            {
                DatabaseFactory.Create().Fill(sqlText, dataTable);
            }
            if (dataTable != null)
            {
                dataTable.DefaultView.RowFilter = "(OPER_STATUS >= 0) OR (OPER_STATUS IS NULL)";
                dataTable = dataTable.DefaultView.ToTable();
            }
            return dataTable;
        }

        public bool PatientIdIsExist(string patientId)
        {
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("PatientBaseInformations_PatientIdIsExist");
            DbParameter idParameter = database.BuildDbParameter("patientId", DbType.String, patientId);

            PatientBaseInformations.PatMasterIndexDataTable data = new PatientBaseInformations.PatMasterIndexDataTable();
            database.Fill(sql, data, new DbParameter[] { idParameter });

            return data.Count > 0;

        }

        /// <summary>
        /// 根据条件获取患者信息表
        /// </summary>
        public DataTable GetPatientList(DateTime startDate, string patientID, string patientName, string anesthesiaDoctor, string departCode
            , string operationStatus, string asa, string operationName, string anesthesiaMethod, string age, string age1,string operationRoom)
        {
            IDatabase database = DatabaseFactory.Create();
            DateTime dtStart = startDate;
            DateTime dtEnd = dtStart.AddDays(1);
            List<object> objects = new List<object>();
            string sqlText = "SELECT A.PAT_ID,VISIT_ID,OPER_ID,OPER_STATUS,NAME,OPERATING_ROOM_NO,OPERATING_ROOM_NO,BED_NO,ANES_DOCTOR,SCHEDULED_DATE_TIME, START_DATE_TIME,SURGEON,OPER_NAME,OPER_SCALE,ANES_ASSISTANT,SEQUENCE,DEPT_STAYED,SEX,DATE_OF_BIRTH,INCISION_CLASS,INCISION_NUMBER ,C.DEPT_NAME,"
                +"DIAG_BEFORE_OPER,PAT_CONDITION,ISOLATION_INDICATOR,ANES_METHOD,SECOND_ANES_DOCTOR,THIRD_ANES_DOCTOR,SECOND_ANES_ASSISTANT,FIRST_ASSISTANT,SECOND_ASSISTANT,THIRD_ASSISTANT,FOURTH_ASSISTANT,FOURTH_ANES_ASSISTANT,FIRST_OPER_NURSE,SECOND_OPER_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,THIRD_SUPPLY_NURSE"
                + " FROM WIS_OPER_MASTER A JOIN WIS_PAT_MASTER_INDEX B ON "
                + "A.PAT_ID = B.PAT_ID LEFT JOIN WIS_DICT_DEPT C ON A.DEPT_STAYED=C.DEPT_CODE " +
              "WHERE 1=1" ;// AND (OPER_STATUS != -1 OR OPER_STATUS =)";
            //string sqlText = "SELECT A.PAT_ID,A.VISIT_ID,A.OPER_ID,A.OPER_STATUS,B.NAME,A.OPERATING_ROOM_NO,A.BED_NO,A.ANES_DOCTOR,"
            //+ "A.SCHEDULED_DATE_TIME START_DATE_TIME,A.SURGEON,A.OPER_NAME,A.OPER_SCALE,C.ASA_GRADE FROM WIS_OPER_MASTER A "
            //+ " LEFT OUTER JOIN WIS_PAT_MASTER_INDEX B ON A.PAT_ID = B.PAT_ID LEFT OUTER JOIN WIS_ANES_PLAN C ON "
            //+ " A.PAT_ID = C.PATIENT_ID AND A.VISIT_ID=C.VISIT_ID AND A.OPER_ID=C.OPER_ID WHERE A.OPER_STATUS >= -1";
            List<DbParameter> parameters = new List<DbParameter>();
            if (startDate > DateTime.MinValue && startDate < DateTime.MaxValue)
            {
                sqlText = sqlText + " AND (A.SCHEDULED_DATE_TIME >= " + DatabaseFactory.TransParameter("startTime") + ") AND (SCHEDULED_DATE_TIME <= " + DatabaseFactory.TransParameter("endTime") + ")";
                parameters.Add(database.BuildDbParameter("startTime", DbType.DateTime, dtStart));
                parameters.Add(database.BuildDbParameter("endTime", DbType.DateTime, dtEnd));
            }
            string pID = patientID;
            if (!string.IsNullOrEmpty(pID))
            {
                sqlText = sqlText + " AND (A.PAT_ID LIKE '%" + pID + "%')";
            }
            string name = patientName;
            if (!string.IsNullOrEmpty(name))
            {
                sqlText = sqlText + " AND (B.NAME LIKE '%" + name + "%')";
            }
            string text = anesthesiaDoctor;
            if (!string.IsNullOrEmpty(text))
            {
                sqlText = sqlText + " AND (A.ANES_DOCTOR LIKE '%" + text + "%')";
            }
            text = departCode;
            if (!string.IsNullOrEmpty(text))
            {
                //DataRow[] rows = _deptDict.Select("DEPT_NAME = '" + text + "'");
                //if (rows.Length > 0 && rows[0]["DEPT_CODE"] != System.DBNull.Value)
                //{
                //    text = rows[0]["DEPT_CODE"].ToString();
                //}
                sqlText = sqlText + " AND (DEPT_STAYED = '" + text + "')";
            }
            text = operationStatus;
            if (!string.IsNullOrEmpty(text))
            {
                //NewOperationStatus.OperationStatus operationStatus = NewOperationStatus.OperationStatusFromString(text);
                //sqlText = sqlText + " AND (OPER_STATUS = " + ((int)operationStatus).ToString() + ")";
                sqlText = sqlText + " AND (A.OPER_STATUS = " + text + ")";
            }
            //text = txtDoctor.Text;
            //if (!string.IsNullOrEmpty(text))
            //{
            //    sqlText = sqlText + " AND (SURGEON = '" + text + "')";
            //}
            //text = txtDiagnosis.Text;
            //if (!string.IsNullOrEmpty(text))
            //{
            //    sqlText = sqlText + " AND (DIAG_BEFORE_OPER LIKE '%" + text + "%')";
            //}
            //text = asa;
            //if (!string.IsNullOrEmpty(text))
            //{
            //    sqlText = sqlText + " AND (C.ASA_GRADE = '" + text + "')";
            //}
            text = operationName;
            if (!string.IsNullOrEmpty(text))
            {
                sqlText = sqlText + " AND (A.OPER_NAME LIKE '%" + text + "%')";
            }
            text = anesthesiaMethod;
            if (!string.IsNullOrEmpty(text))
            {
                sqlText = sqlText + " AND (A.ANES_METHOD LIKE '%" + text + "%')";
            }
            text = operationRoom;
            if (!string.IsNullOrEmpty(text))
            {
                sqlText = sqlText + " AND ( A.OPERATING_ROOM_NO= '"+ text +"')";
               
            }
            text = age;
            if (!string.IsNullOrEmpty(text))
            {
                int theAge = 0;
                if (int.TryParse(text, out theAge))
                {
                    DateTime dtStart1 = DateTime.Now.AddYears(-theAge);
                    dtStart1 = new DateTime(dtStart1.Year, 1, 1);
                    DateTime dtEnd1 = dtStart1.AddYears(1).AddSeconds(-1);
                    if (!string.IsNullOrEmpty(age1))
                    {
                        if (int.TryParse(age1, out theAge))
                        {
                            dtStart1 = new DateTime(DateTime.Now.Year - theAge, 1, 1);
                        }
                    }
                    sqlText = sqlText + " AND (DATE_OF_BIRTH >= " + DatabaseFactory.TransParameter("dtStart1") + " AND DATE_OF_BIRTH < " + DatabaseFactory.TransParameter("dtEnd1") + ")";
                    parameters.Add(database.BuildDbParameter("dtStart1", DbType.DateTime, dtStart1));
                    parameters.Add(database.BuildDbParameter("dtEnd1", DbType.DateTime, dtEnd1));
                }
            }
            sqlText = sqlText + " ORDER BY  A.OPERATING_ROOM_NO,SCHEDULED_DATE_TIME,SEQUENCE ";
            DataTable dataTable = new DataTable();
            if (parameters.Count > 0)
            {
                DatabaseFactory.Create().Fill(sqlText, dataTable, parameters.ToArray());
            }
            else
            {
                DatabaseFactory.Create().Fill(sqlText, dataTable);
            }
            if (dataTable != null)
            {
                dataTable.DefaultView.RowFilter = "(OPER_STATUS >= 0) OR (OPER_STATUS IS NULL)";
                dataTable = dataTable.DefaultView.ToTable();
            }
            return dataTable;
        }

        public int UpdateCommunicateState(int state, string ID)
        {
            int Result = -1;
            IDatabase _iDatabase = DatabaseFactory.Create();
            if (_iDatabase != null)
            {
                try
                {
                    _iDatabase = DatabaseFactory.Create();
                    string Sql = string.Format("UPDATE WIS_ANES_COMMUNICT_PLATFORM SET STATE = {0} WHERE ID = '{1}'", state, ID);

                    Result = _iDatabase.ExecuteNonQuery(Sql);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return Result;
        }

        //Add By chengying.x @20140221 获取患者信息
        public DataTable GetPatientInfo(string patientid, decimal visitid, decimal operid)
        {
            IDatabase database = DatabaseFactory.Create();
            string strSql = @"SELECT P.NAME,P.INP_NO,M.PAT_ID,M.VISIT_ID,M.OPER_ID,NVL(D.DEPT_NAME,M.DEPT_STAYED) DEPT_NAME,P.SEX,P.DATE_OF_BIRTH,trunc(months_between(sysdate,P.DATE_OF_BIRTH)/12) AGE
                              FROM WIS_OPER_MASTER M 
                              LEFT OUTER JOIN WIS_PAT_MASTER_INDEX P ON M.PAT_ID=P.PAT_ID
                              LEFT OUTER JOIN WIS_DICT_DEPT D ON M.DEPT_STAYED=D.DEPT_CODE WHERE M.PAT_ID='" + patientid + "' AND VISIT_ID=" + visitid + " AND OPER_ID=" + operid;
            DataTable dataTable = new DataTable();
            DatabaseFactory.Create().Fill(strSql, dataTable);
            return dataTable;

        }
        //End Add
    }
}