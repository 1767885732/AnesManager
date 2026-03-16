using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.Interface;
using Wis.Anes.BusinessComponent;
using Wis.Anes.BusinessEntity;
using System.Data;

namespace Wis.Anes.ServiceProxies
{
    public class CareDocsProxy
    {
        static ICareDocs _iCareDocs = new CareDocsBC();
        /// <summary>
        /// 获取器材收费记录表
        /// </summary>
        /// <returns></returns>
        public static CareDocs.MED_ANESTHESIA_DEVICEPRICEDataTable GetANESDEVICEPRICED()
        {
            try
            {
                return _iCareDocs.GetANESDEVICEPRICED();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }
        /// <summary>
        ///  更新器材收费记录表
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        public static int UpdateANESDEVICEPRICED(CareDocs.MED_ANESTHESIA_DEVICEPRICEDataTable dataTable)
        {
            try
            {
                return _iCareDocs.UpdateANESDEVICEPRICED(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获取手术清点记录表
        /// </summary>
        /// <returns></returns>
        public static CareDocs.MED_ANES_OPEREQUIPMENTRCDDataTable GetANESOPEREQUIPMENTRCD()
        {
            try
            {
                return _iCareDocs.GetANESOPEREQUIPMENTRCD();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }
        /// <summary>
        ///  更新手术清点记录表
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        public static int UpdateANESOPEREQUIPMENTRCD(CareDocs.MED_ANES_OPEREQUIPMENTRCDDataTable dataTable)
        {
            try
            {
                return _iCareDocs.UpdateANESOPEREQUIPMENTRCD(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static CareDocs.WIS_CUSTOM_DATADataTable GetCustomData()
        {
            try
            {
                return _iCareDocs.GetCustomData();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }
        public static CareDocs.WIS_CUSTOM_DATADataTable GetCustomData(string patientID, int visitID, int operID)
        {
            try
            {
                return _iCareDocs.GetCustomData(patientID, visitID, operID);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }
        public static int UpdateCustomData(CareDocs.WIS_CUSTOM_DATADataTable dataTable)
        {
            try
            {
                return _iCareDocs.UpdateCustomData(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SaveCustomDataRow(CareDocs.WIS_CUSTOM_DATADataTable dataTable, string patientID, int visitID, int operID, string itemName, string itemValue)
        {
            CareDocs.WIS_CUSTOM_DATARow row1 = dataTable.FindByPAT_IDVISIT_IDOPER_IDITEM_NAME(patientID, visitID, operID, itemName);
            if (row1 == null)
            {
                AddCustomDataRow(dataTable, patientID, visitID, operID, itemName, itemValue);
            }
            else
            {
                row1.ITEM_VALUE = itemValue;
            }
        }

        public static CareDocs.WIS_CUSTOM_DATARow AddCustomDataRow(CareDocs.WIS_CUSTOM_DATADataTable dataTable, string patientID, int visitID, int operID, string itemName, string itemValue)
        {
            CareDocs.WIS_CUSTOM_DATARow row = dataTable.NewWIS_CUSTOM_DATARow();
            row.PAT_ID = patientID;
            row.VISIT_ID = visitID;
            row.OPER_ID = operID;
            row.ITEM_NAME = itemName;
            row.ITEM_VALUE = itemValue;
            dataTable.AddWIS_CUSTOM_DATARow(row);
            return row;
        }

        public static AnesInformations.JSShuQianFangTanDataTable GetJSShuQianFangTanData(string patientID, decimal visitID, decimal operID)
        {
            try
            {
                return _iCareDocs.GetJSShuQianFangTanData(patientID, visitID, operID);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }
        public static AnesInformations.JSShuQianFangTanDataTable GetJSShuQianFangTanData()
        {
            try
            {
                return _iCareDocs.GetJSShuQianFangTanData();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }
        public static AnesInformations.JSShouHouZhenTongDataTable GetJSShouHouZhenTongData(string patientID, decimal visitID, decimal operID)
        {
            try
            {
                return _iCareDocs.GetJSShouHouZhenTongData(patientID, visitID, operID);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }
        public static AnesInformations.JSShouHouZhenTongDataTable GetJSShouHouZhenTongData()
        {
            try
            {
                return _iCareDocs.GetJSShouHouZhenTongData();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        /// <summary>
        /// 更新江苏术后镇痛记录表
        /// </summary>
        /// <param name="jsShouHouZhenTongDataTable">江苏术后镇痛记录表</param>
        /// <returns>更新受影响的行数</returns>
        public static int UpdateJSShouHouZhenTongData(AnesInformations.JSShouHouZhenTongDataTable jsShouHouZhenTongDataTable)
        {
            try
            {
                return _iCareDocs.UpdateJSShouHouZhenTongData(jsShouHouZhenTongDataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 更新江苏术前访谈记录表
        /// </summary>
        /// <param name="jsMZKCaoZhuoDataTable">江苏术前访谈记录表</param>
        /// <returns>更新受影响的行数</returns>
        public static int UpdateJSShuQianFangTanData(AnesInformations.JSShuQianFangTanDataTable jsShuQianFangTanDataTable)
        {
            try
            {
                return _iCareDocs.UpdateJSShuQianFangTanData(jsShuQianFangTanDataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 术后病情
        /// </summary>
        /// <returns></returns>
        public static AnesInformations.JSShuHouBingQingDataTable GetJSShuHouBingQingData()
        {
            try
            {
                return _iCareDocs.GetJSShuHouBingQingData();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }
        /// <summary>
        /// 术后病情
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        public static AnesInformations.JSShuHouBingQingDataTable GetJSShuHouBingQingData(string patientID, decimal visitID, decimal operID)
        {
            try
            {
                return _iCareDocs.GetJSShuHouBingQingData(patientID, visitID, operID);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        /// <summary>
        /// 更新术后病情
        /// </summary>
        /// <param name="jsMZKCaoZhuoDataTable"></param>
        /// <returns>更新的行数</returns>
        public static int UpdateJSShuHouBingQingData(AnesInformations.JSShuHouBingQingDataTable updateTable)
        {
            try
            {
                return _iCareDocs.UpdateJSShuHouBingQingData(updateTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 术后随访
        /// </summary>
        /// <returns></returns>
        public static AnesInformations.AnesthesiaInquiryDataTable GetAnesthesiaInquiryData()
        {
            try
            {
                return _iCareDocs.GetAnesthesiaInquiryData();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        /// <summary>
        /// 术后随访
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        public static AnesInformations.AnesthesiaInquiryDataTable GetAnesthesiaInquiryData(string patientID, decimal visitID, decimal operID)
        {
            try
            {
                return _iCareDocs.GetAnesthesiaInquiryData(patientID, visitID, operID);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }
        /// <summary>
        /// 更新术后随访
        /// </summary>
        /// <param name="jsMZKCaoZhuoDataTable"></param>
        /// <returns>更新的行数</returns>
        public static int UpdateAnesthesiaInquiryData(AnesInformations.AnesthesiaInquiryDataTable updateTable)
        {
            try
            {
                return _iCareDocs.UpdateAnesthesiaInquiryData(updateTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取病人麻醉总结
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">病人本次住院标识</param>
        /// <param name="operID">手术号</param>
        /// <returns>病人麻醉总结记录</returns>
        public static AnesInformations.AnesthesiaSummaryDataTable GetAnesthesiaSummary(string patientID, decimal visitID, decimal operID)
        {
            try
            {
                return _iCareDocs.GetAnesthesiaSummary(patientID, visitID, operID);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }
        /// <summary>
        /// 更新病人麻醉总结
        /// </summary>
        /// <param name="anesthesiaPlanDataTable">病人麻醉总结数据集</param>
        /// <returns>更新受影响的行数</returns>
        public static int UpdateAnesthesiaSummary(AnesInformations.AnesthesiaSummaryDataTable anesthesiaSummaryDataTable)
        {
            try
            {
                return _iCareDocs.UpdateAnesthesiaSummary(anesthesiaSummaryDataTable);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }
        public static CareDocs.PatMonitorDataExtDataTable GetPatMonitorDataExtDataTable(string patientID, decimal visitID, decimal operID)
        {
            try
            {
                return _iCareDocs.GetPatMonitorDataExtDataTable(patientID, visitID, operID);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static CareDocs.PatMonitorDataExtDataTable GetPatMonitorDataExtDataTableDesc(string patientID, decimal visitID, decimal operID)
        {
            try
            {
                return _iCareDocs.GetPatMonitorDataExtDataTableDesc(patientID, visitID, operID);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static CareDocs.PatMonitorDataHistoryDataTable GetPatMonitorDataHistory()
        {
            try
            {
                return _iCareDocs.GetPatMonitorDataHistory();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static CareDocs.PatMonitorDataHistoryDataTable GetPatMonitorDataHistory(string patientID, decimal visitID, decimal operID)
        {
            try
            {
                return _iCareDocs.GetPatMonitorDataHistory(patientID, visitID, operID);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static CareDocs.PatMonitorDataHistoryDataTable GetPatMonitorDataHistory(string patientID, decimal visitID, decimal operID, decimal dataType, decimal itemNo)
        {
            try
            {
                return _iCareDocs.GetPatMonitorDataHistory(patientID, visitID, operID, dataType, itemNo);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        /// <summary>
        /// 获取采集数据项目行（Item = 0）
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <param name="data_type"></param>
        /// <returns></returns>
        public static string GetPatMonitorDataHistoryItemHeader(string patientID, decimal visitID, decimal operID, decimal data_type)
        {
            try
            {
                return _iCareDocs.GetPatMonitorDataHistoryItemHeader(patientID, visitID, operID, data_type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetPatMonitorDataHistoryMaxValue(string patientID, decimal visitID, decimal operID, decimal data_type)
        {
            try
            {
                return _iCareDocs.GetPatMonitorDataHistoryMaxValue(patientID, visitID, operID, data_type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static CareDocs.OperationNameDataTable GetOperationName()
        {
            try
            {
                return _iCareDocs.GetOperationName();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }
        public static CareDocs.OperationNameDataTable GetOperationName(string patientID, decimal visitID, decimal operID)
        {
            try
            {
                return _iCareDocs.GetOperationName(patientID, visitID, operID);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }
        public static int UpdateOperationName(CareDocs.OperationNameDataTable dataTable)
        {
            try
            {
                return _iCareDocs.UpdateOperationName(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static CareDocs.OperationCanceledDataTable GetOperationCanceled()
        {
            try
            {
                return _iCareDocs.GetOperationCanceled();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static CareDocs.OperationCanceledDataTable GetOperationCanceled(string patientID, decimal visitID, decimal cancelID)
        {
            try
            {
                return _iCareDocs.GetOperationCanceled(patientID, visitID, cancelID);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static int UpdateOperationCanceled(CareDocs.OperationCanceledDataTable dataTable)
        {
            try
            {
                return _iCareDocs.UpdateOperationCanceled(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static CareDocs.BloodGasMasterDataTable GetBloodGasMasterTable(string patient_id, decimal visit_id, decimal oper_id)
        {
            try
            {
                return _iCareDocs.GetBloodGasMasterTable(patient_id, visit_id, oper_id);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static CareDocs.BloodGasMasterDataTable GetBloodGasMasterTable(string detailId)
        {
            try
            {
                return _iCareDocs.GetBloodGasMasterTable(detailId);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static CareDocs.BloodGasDetailDataTable GetBloodGasDetailTable(string detailId)
        {
            try
            {
                return _iCareDocs.GetBloodGasDetailTable(detailId);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static int UpdateBloodGasMaster(CareDocs.BloodGasMasterDataTable dataTable)
        {
            try
            {
                return _iCareDocs.UpdateBloodGasMaster(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static int UpdateBloodGasDetail(CareDocs.BloodGasDetailDataTable dataTable)
        {
            try
            {
                return _iCareDocs.UpdateBloodGasDetail(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static void DeleteBloodGasData(string detailsId)
        {
            try
            {
                _iCareDocs.DeleteBloodGasDetail(detailsId);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static CareDocs.UserScheduleDataTable GetUserSchedule()
        {
            try
            {
                return _iCareDocs.GetUserSchedule();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static CareDocs.UserScheduleDataTable GetUserSchedule(DateTime startTime, DateTime endTime)
        {
            try
            {
                return _iCareDocs.GetUserSchedule(startTime, endTime);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static int UpdateUserSchedule(CareDocs.UserScheduleDataTable dataTable)
        {
            try
            {
                return _iCareDocs.UpdateUserSchedule(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static CareDocs.PatientMonitorDataDataTable GetPatientMonitorData()
        {
            try
            {
                return _iCareDocs.GetPatientMonitorData();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static CareDocs.PatientMonitorDataDataTable GetPatientMonitorData(string patientID, decimal visitID, decimal operID)
        {
            try
            {
                return _iCareDocs.GetPatientMonitorData(patientID, visitID, operID);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static CareDocs.PatientMonitorDataDataTable GetPatientMonitorData(string patientID, decimal visitID, decimal operID, decimal eventNo)
        {
            try
            {
                return _iCareDocs.GetPatientMonitorData(patientID, visitID, operID, eventNo);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static CareDocs.PatientMonitorDataDataTable GetPatientMonitorData(string patientID, decimal visitID, decimal operID, DateTime timePoint, string itemName, decimal eventNo)
        {
            try
            {
                return _iCareDocs.GetPatientMonitorData(patientID, visitID, operID, timePoint, itemName, eventNo);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static int UpdatePatientMonitorData(CareDocs.PatientMonitorDataDataTable dataTable)
        {
            try
            {
                return _iCareDocs.UpdatePatientMonitorData(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static CareDocs.ModifyHistoryDataTable GetModifyHistory()
        {
            try
            {
                return _iCareDocs.GetModifyHistory();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static CareDocs.ModifyHistoryDataTable GetModifyHistory(string tableName, string fieldName)
        {
            try
            {
                return _iCareDocs.GetModifyHistory(tableName, fieldName);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static int UpdateModifyHistory(CareDocs.ModifyHistoryDataTable dataTable)
        {
            try
            {
                return _iCareDocs.UpdateModifyHistory(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static int InsertNewModifyHistoryRecord(string tableName, string fieldName, string primaryKey, string newValue, string oldValue, DateTime modifyTime, string operatorName)
        {
            try
            {
                return _iCareDocs.InsertNewModifyHistoryRecord(tableName, fieldName, primaryKey, newValue, oldValue, modifyTime, operatorName);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static CareDocs.AnesDocCheckRecordDataTable GetAnesCareCheckRecord(string patientID, int visitID, int operID, string docName)
        {
            try
            {
                return _iCareDocs.GetAnesCareCheckRecord(patientID, visitID, operID, docName);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public static CareDocs.AnesDocCheckRecordDataTable GetAnesCareCheckRecord()
        {
            try
            {
                return _iCareDocs.GetAnesCareCheckRecord();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public static int UpdateAnesCareCheckRecord(CareDocs.AnesDocCheckRecordDataTable dataTable)
        {
            try
            {
                return _iCareDocs.UpdateAnesCareCheckRecord(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
