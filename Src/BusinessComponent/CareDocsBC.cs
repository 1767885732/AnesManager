using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.Interface;
using Wis.Anes.BusinessEntity;
using Wis.Anes.DataAccess;
using System.Data;

namespace Wis.Anes.BusinessComponent
{
    public class CareDocsBC : ICareDocs
    {
        public CareDocs.MED_ANES_OPEREQUIPMENTRCDDataTable GetANESOPEREQUIPMENTRCD()
        {
            return (new CareDocsDA()).GetANESOPEREQUIPMENTRCD();
        }
        public int UpdateANESOPEREQUIPMENTRCD(CareDocs.MED_ANES_OPEREQUIPMENTRCDDataTable dataTable)
        {
            return (new CareDocsDA()).UpdateANESOPEREQUIPMENTRCD(dataTable);
        }

        public CareDocs.MED_ANESTHESIA_DEVICEPRICEDataTable GetANESDEVICEPRICED()
        {
            return (new CareDocsDA()).GetANESDEVICEPRICED();
        }
        public int UpdateANESDEVICEPRICED(CareDocs.MED_ANESTHESIA_DEVICEPRICEDataTable dataTable)
        {
            return (new CareDocsDA()).UpdateANESDEVICEPRICED(dataTable);
        }

        public CareDocs.WIS_PACU_SCOREDataTable GetPACUSorce()
        {
            return (new CareDocsDA()).GetPACUSorce();
        }


        
        public int UpdatePACUSorce(CareDocs.WIS_PACU_SCOREDataTable dataTable)
        {
            return (new CareDocsDA()).UpdatePACUSorce(dataTable);
        }
        public CareDocs.WIS_CUSTOM_DATADataTable GetCustomData()
        {
            return (new CareDocsDA()).GetCustomData();
        }
        public CareDocs.WIS_CUSTOM_DATADataTable GetCustomData(string patientID, int visitID, int operID)
        {
            return (new CareDocsDA()).GetCustomData(patientID, visitID, operID);
        }
        public int UpdateCustomData(CareDocs.WIS_CUSTOM_DATADataTable dataTable)
        {
            return (new CareDocsDA()).UpdateCustomData(dataTable);
        }

        /// <summary>
        /// 获取江苏术后镇痛记录表
        /// </summary>
        /// <returns>江苏术后镇痛记录表</returns>
        public AnesInformations.JSShouHouZhenTongDataTable GetJSShouHouZhenTongData()
        {
            return (new CareDocsDA()).GetJSShouHouZhenTongData();
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
            return (new CareDocsDA()).GetJSShouHouZhenTongData(patientID, visitID, operID);
        }

        /// <summary>
        /// 获取江苏术前访谈记录表
        /// </summary>
        /// <returns>江苏术前访谈记录表</returns>
        public AnesInformations.JSShuQianFangTanDataTable GetJSShuQianFangTanData()
        {
            return (new CareDocsDA()).GetJSShuQianFangTanData();
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
            return (new CareDocsDA()).GetJSShuQianFangTanData(patientID, visitID, operID);
        }

        /// <summary>
        /// 更新江苏术前访谈记录表
        /// </summary>
        /// <param name="jsShuQianFangTanDataTable"></param>
        /// <returns>更新的行数</returns>
        public int UpdateJSShuQianFangTanData(AnesInformations.JSShuQianFangTanDataTable jsShuQianFangTanDataTable)
        {
            return (new CareDocsDA()).UpdateJSShuQianFangTanData(jsShuQianFangTanDataTable);
        }

        /// <summary>
        /// 更新江苏术后镇痛记录表
        /// </summary>
        /// <param name="jsShouHouZhenTongDataTable"></param>
        /// <returns>更新的行数</returns>
        public int UpdateJSShouHouZhenTongData(AnesInformations.JSShouHouZhenTongDataTable jsShouHouZhenTongDataTable)
        {
            return (new CareDocsDA()).UpdateJSShouHouZhenTongData(jsShouHouZhenTongDataTable);
        }


        /// <summary>
        /// 术后病情
        /// </summary>
        /// <returns></returns>
        public AnesInformations.JSShuHouBingQingDataTable GetJSShuHouBingQingData()
        {
            return (new CareDocsDA()).GetJSShuHouBingQingData();
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
            return (new CareDocsDA()).GetJSShuHouBingQingData(patientID, visitID, operID);
        }

        /// <summary>
        /// 更新术后病情
        /// </summary>
        /// <param name="jsMZKCaoZhuoDataTable"></param>
        /// <returns>更新的行数</returns>
        public int UpdateJSShuHouBingQingData(AnesInformations.JSShuHouBingQingDataTable updateTable)
        {
            return (new CareDocsDA()).UpdateJSShuHouBingQingData(updateTable);
        }

        /// <summary>
        /// 术后随访
        /// </summary>
        /// <returns></returns>
        public AnesInformations.AnesthesiaInquiryDataTable GetAnesthesiaInquiryData()
        {
            return (new CareDocsDA()).GetAnesthesiaInquiryData();
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
            return (new CareDocsDA()).GetAnesthesiaInquiryData(patientID, visitID, operID);
        }

        /// <summary>
        /// 更新术后随访
        /// </summary>
        /// <param name="jsMZKCaoZhuoDataTable"></param>
        /// <returns>更新的行数</returns>
        public int UpdateAnesthesiaInquiryData(AnesInformations.AnesthesiaInquiryDataTable updateTable)
        {
            return (new CareDocsDA()).UpdateAnesthesiaInquiryData(updateTable);
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
            return (new CareDocsDA()).GetAnesthesiaSummary(patientID, visitID, operID);
        }

        /// <summary>
        /// 更新病人麻醉总结
        /// </summary>
        /// <param name="anesthesiaPlanDataTable">病人麻醉总结数据集</param>
        /// <returns>更新受影响的行数</returns>
        public int UpdateAnesthesiaSummary(AnesInformations.AnesthesiaSummaryDataTable anesthesiaSummaryDataTable)
        {
            return (new CareDocsDA()).UpdateAnesthesiaSummary(anesthesiaSummaryDataTable);
        }

        public CareDocs.PatMonitorDataExtDataTable GetPatMonitorDataExtDataTable(string patientID, decimal visitID, decimal operID)
        {
            return (new CareDocsDA()).GetPatMonitorDataExtDataTable(patientID, visitID, operID);
        }
        public CareDocs.PatMonitorDataExtDataTable GetPatMonitorDataExtDataTableDesc(string patientID, decimal visitID, decimal operID)
        {
            return (new CareDocsDA()).GetPatMonitorDataExtDataTableDesc(patientID, visitID, operID);
        }

        public string GetPatMonitorDataHistoryItemHeader(string patientID, decimal visitID, decimal operID, decimal data_type)
        {
            return (new CareDocsDA()).GetPatMonitorDataHistoryItemHeader(patientID, visitID, operID, data_type);
        }
        public string GetPatMonitorDataHistoryMaxValue(string patientID, decimal visitID, decimal operID, decimal data_type)
        {
            return (new CareDocsDA()).GetPatMonitorDataHistoryMaxValue(patientID, visitID, operID, data_type);
        }
        public CareDocs.PatMonitorDataHistoryDataTable GetPatMonitorDataHistory()
        {
            return (new CareDocsDA()).GetPatMonitorDataHistory();
        }
        public CareDocs.PatMonitorDataHistoryDataTable GetPatMonitorDataHistory(string patientID, decimal visitID, decimal operID)
        {
            return (new CareDocsDA()).GetPatMonitorDataHistory(patientID, visitID, operID);
        }
        public CareDocs.PatMonitorDataHistoryDataTable GetPatMonitorDataHistory(string patientID, decimal visitID, decimal operID, decimal dataType, decimal itemNo)
        {
            return (new CareDocsDA()).GetPatMonitorDataHistory(patientID, visitID, operID, dataType, itemNo);
        }
        public CareDocs.OperationNameDataTable GetOperationName()
        {
            return (new CareDocsDA()).GetOperationName();
        }
        public CareDocs.OperationNameDataTable GetOperationName(string patientID, decimal visitID, decimal operID)
        {
            return (new CareDocsDA()).GetOperationName(patientID, visitID, operID);
        }
        public int UpdateOperationName(CareDocs.OperationNameDataTable dataTable)
        {
            return (new CareDocsDA()).UpdateOperationName(dataTable);
        }

        public CareDocs.OperationCanceledDataTable GetOperationCanceled()
        {
            return (new CareDocsDA()).GetOperationCanceled();
        }
        public CareDocs.OperationCanceledDataTable GetOperationCanceled(string patientID, decimal visitID, decimal cancelID)
        {
            return (new CareDocsDA()).GetOperationCanceled(patientID, visitID, cancelID);
        }
        public int UpdateOperationCanceled(CareDocs.OperationCanceledDataTable dataTable)
        {
            return (new CareDocsDA()).UpdateOperationCanceled(dataTable);
        }

        public CareDocs.BloodGasMasterDataTable GetBloodGasMasterTable(string patient_id, decimal visit_id, decimal oper_id)
        {
            return (new CareDocsDA()).GetBloodGasMasterTable(patient_id, visit_id, oper_id);
        }

        public CareDocs.BloodGasMasterDataTable GetBloodGasMasterTable(string detailId)
        {
            return (new CareDocsDA()).GetBloodGasMasterTable(detailId);
        }

        public CareDocs.BloodGasDetailDataTable GetBloodGasDetailTable(string detailId)
        {
            return (new CareDocsDA()).GetBloodGasDetailTable(detailId);
        }

        public int UpdateBloodGasMaster(CareDocs.BloodGasMasterDataTable dataTable)
        {
            return (new CareDocsDA()).UpdateBloodGasMaster(dataTable);
        }

        public int UpdateBloodGasDetail(CareDocs.BloodGasDetailDataTable dataTable)
        {
            return (new CareDocsDA()).UpdateBloodGasDetail(dataTable);
        }


        public CareDocs.UserScheduleDataTable GetUserSchedule()
        {
            return (new CareDocsDA()).GetUserSchedule();
        }

        public CareDocs.UserScheduleDataTable GetUserSchedule(DateTime startTime, DateTime endTime)
        {
            return (new CareDocsDA()).GetUserSchedule(startTime, endTime);
        }

        public int UpdateUserSchedule(CareDocs.UserScheduleDataTable dataTable)
        {
            return (new CareDocsDA()).UpdateUserSchedule(dataTable);
        }

        public CareDocs.PatientMonitorDataDataTable GetPatientMonitorData()
        {
            return (new CareDocsDA()).GetPatientMonitorData();
        }

        public CareDocs.PatientMonitorDataDataTable GetPatientMonitorData(string patientID, decimal visitID, decimal operID)
        {
            return (new CareDocsDA()).GetPatientMonitorData(patientID, visitID, operID);
        }

        public CareDocs.PatientMonitorDataDataTable GetPatientMonitorData(string patientID, decimal visitID, decimal operID, decimal eventNo)
        {
            return (new CareDocsDA()).GetPatientMonitorData(patientID, visitID, operID, eventNo);
        }

        public CareDocs.PatientMonitorDataDataTable GetPatientMonitorData(string patientID, decimal visitID, decimal operID, DateTime timePoint, string itemName, decimal eventNo)
        {
            return (new CareDocsDA()).GetPatientMonitorData(patientID, visitID, operID, timePoint, itemName, eventNo);
        }

        public int UpdatePatientMonitorData(CareDocs.PatientMonitorDataDataTable dataTable)
        {
            return (new CareDocsDA()).UpdatePatientMonitorData(dataTable);
        }

        public CareDocs.ModifyHistoryDataTable GetModifyHistory()
        {
            return (new CareDocsDA()).GetModifyHistory();
        }

        public CareDocs.ModifyHistoryDataTable GetModifyHistory(string tableName, string fieldName)
        {
            return (new CareDocsDA()).GetModifyHistory(tableName, fieldName);
        }

        public int UpdateModifyHistory(CareDocs.ModifyHistoryDataTable dataTable)
        {
            return (new CareDocsDA()).UpdateModifyHistory(dataTable);
        }

        public int InsertNewModifyHistoryRecord(string tableName, string fieldName, string primaryKey, string newValue, string oldValue, DateTime modifyTime, string operatorName)
        {
            return (new CareDocsDA()).InsertNewModifyHistoryRecord(tableName, fieldName, primaryKey, newValue, oldValue, modifyTime, operatorName);
        }
        public void DeleteBloodGasDetail(string detailsId)
        {
            (new CareDocsDA()).DeleteBloodGasDetail(detailsId);
        }


        public CareDocs.AnesDocCheckRecordDataTable GetAnesCareCheckRecord(string patientID, int visitID, int operID, string docName)
        {
            return (new CareDocsDA()).GetAnesCareCheckRecord(patientID, visitID, operID, docName);
        }
        public CareDocs.AnesDocCheckRecordDataTable GetAnesCareCheckRecord()
        {
            return (new CareDocsDA()).GetAnesCareCheckRecord();
        }
        public int UpdateAnesCareCheckRecord(CareDocs.AnesDocCheckRecordDataTable dataTable)
        {
            return (new CareDocsDA()).UpdateAnesCareCheckRecord(dataTable);
        }

    }
}
