using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.Interface;
using Wis.Anes.BusinessComponent;
using System.Data;
using Wis.Anes.BusinessEntity;

namespace Wis.Anes.ServiceProxies
{
    public class PatientInformationsProxy
    {
        static IPatientInformations _iPatientInformations = new PatientInformationsBC();
        /// <summary>
        /// 获取某病人基本信息记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <returns>病人基本信息记录</returns>
        public static PatientBaseInformations.PatMasterIndexDataTable GetPatMasterIndexDataTable()
        {
            try
            {
                return _iPatientInformations.GetPatMasterIndexDataTable();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static PatientBaseInformations.PatsInHospitalDataTable GetPatsInHospital()
        {
            try
            {
                return _iPatientInformations.GetPatsInHospital();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static PatientBaseInformations.PatsInHospitalDataTable GetPatsInHospital(string patientID, decimal visitID)
        {
            try
            {
                return _iPatientInformations.GetPatsInHospital(patientID, visitID);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static int UpdatePatsInHospitalDataTable(PatientBaseInformations.PatsInHospitalDataTable dataTable)
        {
            try
            {
                return _iPatientInformations.UpdatePatsInHospitalDataTable(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获取某病人基本信息记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <returns>病人基本信息记录</returns>
        public static PatientBaseInformations.PatMasterIndexDataTable GetPatMasterIndexDataTable(string patientID)
        {
            try
            {
                return _iPatientInformations.GetPatMasterIndexDataTable(patientID);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        /// <summary>
        /// 更新病人基本信息记录
        /// </summary>
        /// <param name="patMasterIndexDataTable">病人基本信息数据集</param>
        /// <returns>更新受影响的行数</returns>
        public static int UpdatePatMasterIndexDataTable(PatientBaseInformations.PatMasterIndexDataTable patMasterIndexDataTable)
        {
            try
            {
                return _iPatientInformations.UpdatePatMasterIndexDataTable(patMasterIndexDataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获取某病人住院记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">病人本次住院标识</param>
        /// <returns>病人住院记录</returns>
        public static PatientBaseInformations.PatVisitDataTable GetVisitDataTable(string patientID, decimal visitID)
        {
            try
            {
                return _iPatientInformations.GetVisitDataTable(patientID, visitID);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        /// <summary>
        /// 更新病人住院记录
        /// </summary>
        /// <param name="patVisitDataTable">病人住院记录信息数据集</param>
        /// <returns>更新受影响的行数</returns>
        public static int UpdateVisitDataTable(PatientBaseInformations.PatVisitDataTable patVisitDataTable)
        {
            try
            {
                return _iPatientInformations.UpdateVisitDataTable(patVisitDataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 返回病人手术
        /// </summary>
        /// <param name="item_class"></param>
        /// <returns></returns>
        /// 
        public static PatientBaseInformations.PatOperationDataTable GetPatOperation()
        {
            try
            {
                return _iPatientInformations.GetPatOperation();

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        /// <summary>
        /// 返回病人手术
        /// </summary>
        /// <param name="item_class"></param>
        /// <returns></returns>
        public static PatientBaseInformations.PatOperationDataTable GetPatOperation(string patient_id, decimal visit_id, decimal schedule_id)
        {
            try
            {
                return _iPatientInformations.GetPatOperation(patient_id, visit_id, schedule_id);

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        /// <summary>
        /// 获得病人手术主记录oper_id
        /// </summary>
        /// <param name="patient_id"></param>
        /// <param name="visit_id"></param>
        /// <returns></returns>
        public static PatientBaseInformations.MaxValueDataTable GetOper_id(string patient_id, decimal visit_id)
        {
            try
            {
                return _iPatientInformations.GetOper_id(patient_id, visit_id);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public static decimal GetMaxEventItemNo(string patient_id, decimal visit_id, decimal oper_id)
        {
            try
            {
                PatientBaseInformations.MaxValueDataTable dataTable = _iPatientInformations.GetMaxEventItemNo(patient_id, visit_id, oper_id);
                if (dataTable != null && dataTable.Count > 0 && !dataTable[0].IsMaxValueNull())
                {
                    return dataTable[0].MaxValue;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取病人visit_id
        /// </summary>
        /// <param name="patient_id">病人ID</param>
        /// <returns></returns>
        public static PatientBaseInformations.MaxValueDataTable GetVisit_id(string patient_id)
        {
            try
            {
                return _iPatientInformations.GetVisit_id(patient_id);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        /// <summary>
        /// 获取所有麻醉系统用户表
        /// </summary>
        /// <returns>用户表强类型数据集</returns>
        public static PatientBaseInformations.PatientInformationDataTable GetPatientInformations(decimal operStatus, bool useMin)
        {
            try
            {
                return _iPatientInformations.GetPatientInformation(operStatus, useMin);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        /// <summary>
        /// 获取所有手术信息
        /// </summary>
        public static PatientBaseInformations.OperationsInfoDataTable GetHistoryOpertionsInfo()
        {
            try
            {
                return _iPatientInformations.GetHistoryOpertionsInfo();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        /// <summary>
        /// 获取所有手术信息
        /// </summary>
        public static PatientBaseInformations.OperationsInfoDataTable GetOpertionsInfo(decimal operStatus)
        {
            try
            {
                return _iPatientInformations.GetOpertionsInfo(operStatus);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static PatientBaseInformations.OperationsInfoDataTable GetOpertionsInfo(DateTime startTime, DateTime endTime)
        {
            try
            {
                return _iPatientInformations.GetOpertionsInfo(startTime, endTime);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        private static List<string> GetPatientList(DataTable dataTable)
        {
            List<string> list = new List<string>();
            if (dataTable != null && dataTable.Rows.Count > 0 && dataTable.Columns.Contains("PAT_ID")
                && dataTable.Columns.Contains("VISIT_ID") && dataTable.Columns.Contains("OPER_ID"))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["PAT_ID"] != System.DBNull.Value && row["VISIT_ID"] != System.DBNull.Value && row["OPER_ID"] != System.DBNull.Value && !string.IsNullOrEmpty(row["PAT_ID"].ToString()))
                    {
                        string patientID = row["PAT_ID"].ToString();
                        if (!list.Contains(patientID))
                        {
                            list.Add(patientID);
                        }
                    }
                    //if (list.Count > 1)
                    //{
                    //    break;
                    //}
                }
            }
            return list;
        }

        private static DataTable TransDataTable(List<string> list, string tableName)
        {
            DataTable Result = new DataTable();
            if (list.Count > 0)
            {
                string sql = "SELECT * FROM " + tableName + " WHERE PAT_ID IN ('" + string.Join("','", list.ToArray()) + "')";
                Result = new CommonBC().GetDataFromSQLString(sql);
            }
            return Result;
        }

        private static DataTable TransDataTable(DataTable dataTable, string tableName)
        {
            return TransDataTable(GetPatientList(dataTable),tableName);
        }

        private static DataTable TransOperationName(DataTable dataTable)
        {
            return TransDataTable(dataTable, "WIS_OPER_NAME");
        }

        private static DataTable TransOperationNo(DataTable dataTable)
        {
            return TransDataTable(dataTable, "WIS_OPER_SCHEDULE");
        }



        /// <summary>
        /// 根据条件获取患者信息表
        /// </summary>
        public static DataTable GetPatientListDataTable( string patientID,decimal visitID,decimal operID )
        {

          return  GetPatientListDataTable(DateTime.MinValue ,patientID,"","","","","","","","","");
        }
        /// <summary>
        /// 根据条件获取患者信息表
        /// </summary>
        public static DataTable GetPatientListDataTable(DateTime startDate, string patientID, string patientName, string anesthesiaDoctor, string departCode
            , string operationStatus, string asa, string operationName, string anesthesiaMethod, string age, string age1)
        {
            try
            {
                DataTable Result = _iPatientInformations.GetPatientListDataTable(startDate, patientID, patientName, anesthesiaDoctor, departCode
                , operationStatus, asa, operationName, anesthesiaMethod, age, age1);
                List<string> list = GetPatientList(Result);
                DataTable dataTable = TransDataTable(list, "WIS_OPER_NAME");
                DataTable dataTable2 = TransDataTable(list, "WIS_OPER_SCHEDULE");
                foreach (DataRow row in Result.Rows)
                {
                    if (row["OPER_NAME"] == System.DBNull.Value || string.IsNullOrEmpty(row["OPER_NAME"].ToString()) && dataTable != null && dataTable.Rows.Count > 0)
                    {
                        DataRow[] rows = dataTable.Select("PAT_ID = '" + row["PAT_ID"] + "' AND VISIT_ID = " + row["VISIT_ID"].ToString()
                            + " AND OPER_ID = " + row["OPER_ID"]);
                        if (rows.Length > 0)
                        {
                            List<string> operationNames = new List<string>();
                            foreach (DataRow row1 in rows)
                            {
                                if (row1["OPER_NAME"] != System.DBNull.Value && !string.IsNullOrEmpty(row1["OPER_NAME"].ToString()))
                                {
                                    operationNames.Add(row1["OPER_NAME"].ToString());
                                }
                            }
                            if (operationNames.Count > 0)
                            {
                                row["OPER_NAME"] = string.Join(",", operationNames.ToArray());
                            }
                        }
                    }
                    if (row["OPERATING_ROOM_NO"] == System.DBNull.Value || string.IsNullOrEmpty(row["OPERATING_ROOM_NO"].ToString()) && dataTable2 != null && dataTable2.Rows.Count > 0)
                    {
                        DataRow[] rows = dataTable2.Select("PAT_ID = '" + row["PAT_ID"] + "' AND VISIT_ID = " + row["VISIT_ID"].ToString()
                            + " AND SCHEDULE_ID = " + row["OPER_ID"]);
                        if (rows.Length ==1 )
                        {
                            if (rows[0]["OPERATING_ROOM_NO"] != System.DBNull.Value)
                            {
                                row["OPERATING_ROOM_NO"] = rows[0]["OPERATING_ROOM_NO"].ToString();
                            }
                        }
                    }
                }
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        /// <summary>
        /// 根据条件获取患者信息表
        /// </summary>
        public static DataTable GetPatientListDataTable(DateTime startDate, DateTime endDate, string patientID, string patientName, string anesthesiaDoctor, string departCode
            , string operationStatus, string asa, string operationName, string anesthesiaMethod, string age, string age1)
        {
            try
            {
                return _iPatientInformations.GetPatientListDataTable(startDate, endDate, patientID, patientName, anesthesiaDoctor, departCode
                , operationStatus, asa, operationName, anesthesiaMethod, age, age1);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

    }
}
