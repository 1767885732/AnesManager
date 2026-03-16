using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.Interface;
using Wis.Anes.BusinessComponent;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework;
using System.Data;
using Wis.Anes.Framework.Configurations;

namespace Wis.Anes.ServiceProxies
{
    public class AnesthesiaSheetProxy
    {
        static IAnesthesiaSheet _iAnesthesiaSheet = new AnesthesiaSheetBC();
        static IPatientInformations _iPatientInformations = new PatientInformationsBC();
        static ICareDocs _icareDocs = new CareDocsBC();
        public static AnesInformations.AnesthesiaNurseDataTable GetAnesthesiaNurse(string patientID, decimal visitID, decimal operID)
        {
            try
            {
                return _iAnesthesiaSheet.GetAnesthesiaNurse(patientID, visitID, operID);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static int UpdateAnesthesiaNurse(AnesInformations.AnesthesiaNurseDataTable dataTable)
        {
            try
            {
                return _iAnesthesiaSheet.UpdateAnesthesiaNurse(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static AnesInformations.OperationEqipDetailDataTable GetOperationEqipDetail(string patientID, decimal visitID, decimal operID)
        {
            try
            {
                return _iAnesthesiaSheet.GetOperationEqipDetail(patientID, visitID, operID);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static int UpdateOperationEqipDetail(AnesInformations.OperationEqipDetailDataTable updateTable)
        {
            try
            {
                return _iAnesthesiaSheet.UpdateOperationEqipDetail(updateTable);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        /// <summary>
        /// 更新病人基本信息记录及病人手术主记录
        /// </summary>
        /// <param name="patMasterIndexDataTable">病人基本信息数据集</param>
        /// <returns>更新受影响的行数</returns>
        public static int UpdatePatMasterIndexOperationMaster(PatientBaseInformations.PatMasterIndexDataTable patMasterIndexDataTable,
                                                              AnesInformations.OperationMasterDataTable operationMasterDataTable)
        {
            try
            {
                return _iPatientInformations.UpdatePatMasterIndexOperationMaster(patMasterIndexDataTable, operationMasterDataTable);
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        /// <summary>
        /// 获取病人麻醉主记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">病人本次住院标识</param>
        /// <param name="operID">手术号</param>
        /// <returns>病人麻醉主记录</returns>
        public static AnesInformations.AnesthesiaPlanDataTable GetAnesthesiaPlan(string patientID, decimal visitID, decimal operID)
        {
            try
            {
                return _iAnesthesiaSheet.GetAnesthesiaPlan(patientID, visitID, operID);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        /// <summary>
        /// 获取病人手术主表信息
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <param name="operID">手术ID</param>
        /// <returns>病人对应手术主表记录行</returns>
        public static AnesInformations.OperationMasterDataTable GetOperationMaster(string patientID, decimal visitID, decimal operID)
        {
            try
            {
                AnesInformations.OperationMasterDataTable operationMasterDataTable = _iAnesthesiaSheet.GetOperationMaster(patientID, visitID, operID);
                if (operationMasterDataTable != null && operationMasterDataTable.Count == 1)
                {
                    if (operationMasterDataTable[0].IsANESTHESIANUMBERNull() || string.IsNullOrEmpty(operationMasterDataTable[0].ANESTHESIANUMBER.Trim()))
                    {
                        int ret = ApplicationConfiguration.AnesthesiaNumber;
                        ret++;
                        ApplicationConfiguration.AnesthesiaNumber = ret;
                        operationMasterDataTable[0].ANESTHESIANUMBER = ret.ToString();
                        UpdateOperationMaster(operationMasterDataTable);
                    }
                }
                return operationMasterDataTable;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public static AnesInformations.OperationMasterDataTable GetOperationMaster(string patientID)
        {
            try
            {
                return _iAnesthesiaSheet.GetOperationMaster(patientID);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static AnesInformations.OperationMasterDataTable GetOperationMaster(DateTime dtStart, DateTime dtEnd)
        {
            try
            {
                return _iAnesthesiaSheet.GetOperationMaster(dtStart, dtEnd);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static AnesInformations.OperationMasterDataTable GetOperationMaster(decimal operStatusStart, decimal operStatusEnd, string roomNo)
        {
            try
            {
                return _iAnesthesiaSheet.GetOperationMaster(operStatusStart, operStatusEnd, roomNo);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static AnesInformations.OperationMasterDataTable GetOperationMaster(string roomNo, decimal operStatus)
        {
            try
            {
                return _iAnesthesiaSheet.GetOperationMaster(roomNo, operStatus);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static int UpdateOperationStatus(string patientID, decimal visitID, decimal operID, OperationStatus operStatus)
        {
            AnesInformations.OperationMasterDataTable operationMasterDataTable = _iAnesthesiaSheet.GetOperationMaster(patientID
                , visitID, operID);
            if (operationMasterDataTable != null && operationMasterDataTable.Count == 1)
            {
                bool needUpdate = true;

                if (needUpdate)
                {
                    operationMasterDataTable[0].OPER_STATUS = (decimal)(int)operStatus;
                    operationMasterDataTable[0].END_DATE_TIME = DateTime.Now;
                    return _iAnesthesiaSheet.UpdateOperationMaster(operationMasterDataTable);
                }
            }
            return 0;
        }


        /// <summary>
        /// 更新手术主表
        /// </summary>
        /// <param name="operationMasterDataTable">手术主表数据集</param>
        /// <returns>更新影响的行数</returns>
        public static int UpdateOperationMaster(AnesInformations.OperationMasterDataTable operationMasterDataTable)
        {
            try
            {
                return _iAnesthesiaSheet.UpdateOperationMaster(operationMasterDataTable);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        /// <summary>
        /// 更新病人麻醉主记录
        /// </summary>
        /// <param name="anesthesiaPlanDataTable">病人麻醉主记录数据集</param>
        /// <returns>更新受影响的行数</returns>
        public static int UpdateAnesthesiaPlan(AnesInformations.AnesthesiaPlanDataTable anesthesiaPlanDataTable)
        {
            try
            {
                return _iAnesthesiaSheet.UpdateAnesthesiaPlan(anesthesiaPlanDataTable);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static AnesInformations.PatMonitorDateDataTable GetPatMonitorDate(string patientID, decimal visitID, decimal operID, decimal eventNo)
        {
            try
            {
                return _iAnesthesiaSheet.GetPatMonitorDate(patientID, visitID, operID, eventNo);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static string[] GetVitalSignTitles(string patientID, decimal visitID, decimal operID, decimal eventNo)
        {
            try
            {
                return _iAnesthesiaSheet.GetVitalSignTitles(patientID, visitID, operID, eventNo);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static AnesInformations.VitalSignDataTable GetVitalSignData(string patientID, decimal visitID, decimal operID, decimal eventNo)
        {
            if (ApplicationConfiguration.MergeMonitorData)
            {
                return GetVitalSignData(patientID, visitID, operID, -1, false);
            }
            else
            {
                return GetVitalSignData(patientID, visitID, operID, eventNo, false);
            }
        }

        public static AnesInformations.VitalSignDataTable GetVitalSignData(string patientID, decimal visitID, decimal operID, decimal eventNo, bool isHistory)//,ref string[] items)
        {
            try
            {
                return _iAnesthesiaSheet.GetVitalSignData(patientID, visitID, operID, eventNo, isHistory);//,ref items);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static int UpdatePatMonitorDate(AnesInformations.PatMonitorDateDataTable updateTable)
        {
            try
            {
                return _iAnesthesiaSheet.UpdatePatMonitorDate(updateTable);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        /// <summary>
        /// 更新麻醉事件字典信息
        /// </summary>
        /// <param name="EventOpenTable"></param>
        /// <returns></returns>
        public static int UpdateAnesthesiaEvent(AnesInformations.AnesthesiaEventDataTable dataTable)
        {
            try
            {
                int result = _iAnesthesiaSheet.UpdateAnesthesiaEvent(dataTable);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public static AnesInformations.AnesthesiaEventDataTable GetAnesthesiaEvent(string patientID, decimal visitID, decimal operID)
        {
            try
            {
                return _iAnesthesiaSheet.GetAnesthesiaEvent(patientID, visitID, operID);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static AnesInformations.AnesthesiaEventDataTable GetAnesthesiaEvent(string patientID, decimal visitID, decimal operID, decimal eventNo)
        {
            try
            {
                return _iAnesthesiaSheet.GetAnesthesiaEvent(patientID, visitID, operID, eventNo);
            }

            catch (Exception ex)
            {
                throw ex;

            }

        }

        public static AnesInformations.JSMZKCaoZhuoDataTable GetJSMZKCaoZhuoData(string patientID, decimal visitID, decimal operID)
        {
            try
            {
                return _iAnesthesiaSheet.GetJSMZKCaoZhuoData(patientID, visitID, operID);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public static AnesInformations.JSMZKCaoZhuoDataTable GetJSMZKCaoZhuoData()
        {
            try
            {
                return _iAnesthesiaSheet.GetJSMZKCaoZhuoData();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        /// <summary>
        /// 更新江苏麻醉科操作记录表
        /// </summary>
        /// <param name="jsMZKCaoZhuoDataTable">江苏麻醉科操作记录表</param>
        /// <returns>更新受影响的行数</returns>
        public static int UpdateJSMZKCaoZhuoData(AnesInformations.JSMZKCaoZhuoDataTable jsMZKCaoZhuoDataTable)
        {
            try
            {
                return _iAnesthesiaSheet.UpdateJSMZKCaoZhuoData(jsMZKCaoZhuoDataTable);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        /// <summary>
        /// PACU
        /// </summary>
        /// <returns></returns>
        public static AnesInformations.AnesthesiaPACUDataTable GetAnesthesiaPACUData()
        {
            try
            {
                return _iAnesthesiaSheet.GetAnesthesiaPACUData();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        /// <summary>
        /// PACU
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        public static AnesInformations.AnesthesiaPACUDataTable GetAnesthesiaPACUData(string patientID, decimal visitID, decimal operID)
        {
            try
            {
                return _iAnesthesiaSheet.GetAnesthesiaPACUData(patientID, visitID, operID);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        /// <summary>
        /// 更新PACU
        /// </summary>
        /// <param name="jsMZKCaoZhuoDataTable"></param>
        /// <returns>更新的行数</returns>
        public static int UpdateAnesthesiaPACUData(AnesInformations.AnesthesiaPACUDataTable updateTable)
        {
            try
            {
                return _iAnesthesiaSheet.UpdateAnesthesiaPACUData(updateTable);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static AnesInformations.VitalSignDataTable GetCPBVitalSignData(string patientID, decimal visitID, decimal operID, decimal eventNo)
        {
            try
            {
                return _iAnesthesiaSheet.GetCPBVitalSignData(patientID, visitID, operID, eventNo);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }




        public static int UpdatePatientDrugItem(AnesInformations.WIS_PAT_DRUG_DETAILDataTable updateTable)
        {
            try
            {
                return _iAnesthesiaSheet.UpdatePatientDrugItem(updateTable);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static AnesInformations.WIS_PAT_DRUG_DETAILDataTable GetPatientDrugItem(string patientID, decimal visitID, decimal operID)
        {
            try
            {
                return _iAnesthesiaSheet.GetPatientDrugItem(patientID, visitID, operID);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static AnesInformations.WIS_PAT_DRUG_DETAILDataTable GetPatientDrugItem(string patientID, decimal visitID, decimal operID, decimal itemType)
        {
            try
            {
                return _iAnesthesiaSheet.GetPatientDrugItem(patientID, visitID, operID, itemType);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static AnesInformations.PunctureRecordDataTable GetPunctureRecordDataTable()
        {
            try
            {
                return _iAnesthesiaSheet.GetPunctureRecordDataTable();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static AnesInformations.PunctureRecordDataTable GetPunctureRecordDataTable(string patientID, decimal visitID, decimal operID)
        {
            try
            {
                return _iAnesthesiaSheet.GetPunctureRecordDataTable(patientID, visitID, operID);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static int UpdatePunctureRecordDataTable(AnesInformations.PunctureRecordDataTable dataTable)
        {
            try
            {
                return _iAnesthesiaSheet.UpdatePunctureRecordDataTable(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static int UpdateOperationScheduleStatus(string patientID, decimal visitID, decimal operID, int status)
        {
            try
            {
                return _iAnesthesiaSheet.UpdateOperationScheduleStatus(patientID, visitID, operID, status);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static AnesInformations.AnesOperHandoverDataTable GetAnesOperHandoverDataTable(string patientID, decimal visitID, decimal operID)
        {
            try
            {
                return _iAnesthesiaSheet.GetAnesOperHandoverDataTable(patientID, visitID, operID);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static int UpdateAnesOperHandoverDataTable(AnesInformations.AnesOperHandoverDataTable dataTable)
        {
            try
            {
                return _iAnesthesiaSheet.UpdateAnesOperHandoverDataTable(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static AnesthesiaSheet.ScheduledOperationNameDataTable GetScheduledOperationName(string patientID, decimal visitID, decimal operID)
        {
            try
            {
                return _iAnesthesiaSheet.GetScheduledOperationName(patientID, visitID, operID);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static AnesInformations.OperShiftRecordDataTable GetOperShiftRecordDataTable()
        {
            try
            {
                return _iAnesthesiaSheet.GetOperShiftRecordDataTable();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static AnesInformations.OperShiftRecordDataTable GetOperShiftRecordDataTable(string patientID, decimal visitID, decimal operID)
        {
            try
            {
                return _iAnesthesiaSheet.GetOperShiftRecordDataTable(patientID, visitID, operID);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static int UpdateOperShiftRecordDataTable(AnesInformations.OperShiftRecordDataTable dataTable)
        {
            try
            {
                return _iAnesthesiaSheet.UpdateOperShiftRecordDataTable(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static AnesInformations.AnesthesiaEventRow CopyAnesthesiaEventRow(AnesInformations.AnesthesiaEventDataTable anesthestaEventDataTable, PatientContext patientContext, decimal eventNo, int index)
        {
            AnesInformations.AnesthesiaEventRow sourceRow = anesthestaEventDataTable[index];
            return CopyAnesthesiaEventRow(anesthestaEventDataTable, patientContext, eventNo, sourceRow);
        }

        public static AnesInformations.AnesthesiaEventRow CopyAnesthesiaEventRow(AnesInformations.AnesthesiaEventDataTable anesthestaEventDataTable
            , PatientContext patientContext, decimal eventNo, DataRow sourceRow)
        {
            AnesInformations.AnesthesiaEventRow row = NewAnesthesiaEventRow(anesthestaEventDataTable, patientContext, eventNo);
            CopyRowValue(row, sourceRow, "ITEM_CLASS");
            CopyRowValue(row, sourceRow, "ITEM_NAME");
            CopyRowValue(row, sourceRow, "ITEM_SPEC");
            CopyRowValue(row, sourceRow, "ITEM_CODE");
            CopyRowValue(row, sourceRow, "ADMINISTRATOR");
            CopyRowValue(row, sourceRow, "CONCENTRATION");
            CopyRowValue(row, sourceRow, "CONCENTRATION_UNITS");
            CopyRowValue(row, sourceRow, "DOSAGE");
            CopyRowValue(row, sourceRow, "DOSAGE_UNITS");
            CopyRowValue(row, sourceRow, "PERFORM_SPEED");
            CopyRowValue(row, sourceRow, "SPEED_UNITS");
            CopyRowValue(row, sourceRow, "PERFORM_SPEED");
            CopyRowValue(row, sourceRow, "EVENT_ATTR");
            return row;
        }

        public static AnesInformations.AnesthesiaEventRow NewAnesthesiaEventRow(AnesInformations.AnesthesiaEventDataTable anesthestaEventDataTable, PatientContext patientContext, decimal eventNo)
        {
            decimal maxItemNo = 0;
            DateTime dt = DateTime.MaxValue;
            foreach (AnesInformations.AnesthesiaEventRow dataRow in anesthestaEventDataTable)
            {
                if (dataRow.ITEM_NO > maxItemNo)
                {
                    maxItemNo = dataRow.ITEM_NO;
                }
                if (!dataRow.IsSTART_DATE_TIMENull() && dataRow.START_DATE_TIME < dt)
                {
                    dt = dataRow.START_DATE_TIME;
                }
            }
            if (dt == DateTime.MaxValue) dt = DateTime.Now;
            maxItemNo++;
            AnesInformations.AnesthesiaEventRow row = anesthestaEventDataTable.NewAnesthesiaEventRow();
            row.PAT_ID = patientContext.PatientID;
            row.VISIT_ID = patientContext.VisitID;
            row.OPER_ID = patientContext.OperID;
            row.EVENT_NO = eventNo;
            row.ITEM_NO = maxItemNo;
            DateTime dt1 = DateTime.Now;
            //DateTime dt1 = applyDateTime == DateTime.MinValue ? DateTime.Now : applyDateTime;
            row.START_DATE_TIME = new DateTime(dt.Year, dt.Month, dt.Day, dt1.Hour, dt1.Minute, 0);
            dt = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0);
            if (row.START_DATE_TIME < dt)
            {
                row.START_DATE_TIME = row.START_DATE_TIME.AddDays(1);
            }
            return row;
        }

        public static void CopyRowValue(DataRow targetRow, DataRow sourceRow, string columnName)
        {
            CopyRowValue(targetRow, columnName, sourceRow, columnName);
        }
        public static void CopyRowValue(DataRow targetRow, string targetColumnName, DataRow sourceRow, string sourceColumnName)
        {
            if (sourceRow[sourceColumnName] != System.DBNull.Value)
            {
                targetRow[targetColumnName] = sourceRow[sourceColumnName];
            }
        }



        public static DataTable GetAnesAlarmMsg(string patientID, decimal visitID, decimal operID)
        {


            try
            {
                return _iAnesthesiaSheet.GetAnesAlarmMsg(patientID, visitID, operID);
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public static int UpdateAnesAlarmMsg(DataTable dataTable)
        {

            try
            {
                return _iAnesthesiaSheet.UpdateAnesAlarmMsg(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static DataTable GetOperCanceledInfo()
        {
            try
            {
                return _iAnesthesiaSheet.GetOperCanceledInfo();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public static int UpdateCancelOper(string patientID, decimal visitID, decimal operID)
        {
            try
            {
                return _iAnesthesiaSheet.UpdateCancelOper(patientID, visitID, operID);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        public static DataTable GetPatientMonitorData(string patientID, decimal visitID, decimal operID)
        {
            try
            {
                return _icareDocs.GetPatientMonitorData(patientID, visitID, operID);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
