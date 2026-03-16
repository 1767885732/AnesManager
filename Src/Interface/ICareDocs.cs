/*----------------------------------------------------------------
 // Copyright (C) 2007 北京拓扑工厂科技发展有限公司
 // 文件名：ICareDocs.cs
 // 文件功能描述：
 //      医疗文书接口类（麻醉单、复苏单除外）
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
using System.Data;

namespace Wis.Anes.Interface
{
    /// <summary>
    /// 医疗文书接口类（麻醉单、复苏单除外）
    /// </summary>
    public interface ICareDocs
    {

        /// <summary>
        /// 获取江苏术后镇痛记录表
        /// </summary>
        /// <returns>江苏术后镇痛记录表</returns>
        AnesInformations.JSShouHouZhenTongDataTable GetJSShouHouZhenTongData();

        /// <summary>
        /// 获取江苏术后镇痛记录表
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <param name="operID">手术ID</param>
        /// <returns>江苏术后镇痛记录表</returns>
        AnesInformations.JSShouHouZhenTongDataTable GetJSShouHouZhenTongData(string patientID, decimal visitID, decimal operID);

        /// <summary>
        /// 获取江苏术前访谈记录表
        /// </summary>
        /// <returns>江苏术前访谈记录表</returns>
        AnesInformations.JSShuQianFangTanDataTable GetJSShuQianFangTanData();

        /// <summary>
        /// 获取江苏术前访谈记录表
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <param name="operID">手术ID</param>
        /// <returns>江苏术前访谈记录表</returns>
        AnesInformations.JSShuQianFangTanDataTable GetJSShuQianFangTanData(string patientID, decimal visitID, decimal operID);

        /// <summary>
        /// 更新江苏术前访谈记录表
        /// </summary>
        /// <param name="jsShuQianFangTanDataTable"></param>
        /// <returns>更新的行数</returns>
        int UpdateJSShuQianFangTanData(AnesInformations.JSShuQianFangTanDataTable jsShuQianFangTanDataTable);

        /// <summary>
        /// 更新江苏术后镇痛记录表
        /// </summary>
        /// <param name="jsShouHouZhenTongDataTable"></param>
        /// <returns>更新的行数</returns>
        int UpdateJSShouHouZhenTongData(AnesInformations.JSShouHouZhenTongDataTable jsShouHouZhenTongDataTable);



        /// <summary>
        /// 术后病情
        /// </summary>
        /// <returns></returns>
        AnesInformations.JSShuHouBingQingDataTable GetJSShuHouBingQingData();

        /// <summary>
        /// 术后病情
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        AnesInformations.JSShuHouBingQingDataTable GetJSShuHouBingQingData(string patientID, decimal visitID, decimal operID);

        /// <summary>
        /// 更新术后病情
        /// </summary>
        /// <param name="jsMZKCaoZhuoDataTable"></param>
        /// <returns>更新的行数</returns>
        int UpdateJSShuHouBingQingData(AnesInformations.JSShuHouBingQingDataTable updateTable);

        /// <summary>
        /// 术后随访
        /// </summary>
        /// <returns></returns>
        AnesInformations.AnesthesiaInquiryDataTable GetAnesthesiaInquiryData();

        /// <summary>
        /// 术后随访
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        AnesInformations.AnesthesiaInquiryDataTable GetAnesthesiaInquiryData(string patientID, decimal visitID, decimal operID);

        /// <summary>
        /// 更新术后随访
        /// </summary>
        /// <param name="jsMZKCaoZhuoDataTable"></param>
        /// <returns>更新的行数</returns>
        int UpdateAnesthesiaInquiryData(AnesInformations.AnesthesiaInquiryDataTable updateTable);






        /// <summary>
        /// 获取病人麻醉总结
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">病人本次住院标识</param>
        /// <param name="operID">手术号</param>
        /// <returns>病人麻醉总结记录</returns>
        AnesInformations.AnesthesiaSummaryDataTable GetAnesthesiaSummary(string patientID, decimal visitID, decimal operID);
        /// <summary>
        /// 更新病人麻醉总结
        /// </summary>
        /// <param name="anesthesiaPlanDataTable">病人麻醉总结数据集</param>
        /// <returns>更新受影响的行数</returns>
        int UpdateAnesthesiaSummary(AnesInformations.AnesthesiaSummaryDataTable anesthesiaSummaryDataTable);
        CareDocs.WIS_CUSTOM_DATADataTable GetCustomData();
        CareDocs.WIS_CUSTOM_DATADataTable GetCustomData(string patientID, int visitID, int operID);
        int UpdateCustomData(CareDocs.WIS_CUSTOM_DATADataTable dataTable);
        CareDocs.PatMonitorDataExtDataTable GetPatMonitorDataExtDataTable(string patientID, decimal visitID, decimal operID);
        CareDocs.PatMonitorDataExtDataTable GetPatMonitorDataExtDataTableDesc(string patientID, decimal visitID, decimal operID);

        CareDocs.PatMonitorDataHistoryDataTable GetPatMonitorDataHistory();
        CareDocs.PatMonitorDataHistoryDataTable GetPatMonitorDataHistory(string patientID, decimal visitID, decimal operID);
        CareDocs.PatMonitorDataHistoryDataTable GetPatMonitorDataHistory(string patientID, decimal visitID, decimal operID, decimal dataType, decimal itemNo);
        /// <summary>
        /// 获取采集数据项目行（Item = 0）
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <param name="data_type"></param>
        /// <returns></returns>
        string GetPatMonitorDataHistoryItemHeader(string patientID, decimal visitID, decimal operID, decimal data_type);
        string GetPatMonitorDataHistoryMaxValue(string patientID, decimal visitID, decimal operID, decimal data_type);

        CareDocs.OperationNameDataTable GetOperationName();
        CareDocs.OperationNameDataTable GetOperationName(string patientID, decimal visitID, decimal operID);
        int UpdateOperationName(CareDocs.OperationNameDataTable dataTable);

        CareDocs.OperationCanceledDataTable GetOperationCanceled();
        CareDocs.OperationCanceledDataTable GetOperationCanceled(string patientID, decimal visitID, decimal cancelID);
        int UpdateOperationCanceled(CareDocs.OperationCanceledDataTable dataTable);

        CareDocs.BloodGasMasterDataTable GetBloodGasMasterTable(string patient_id, decimal visit_id, decimal oper_id);
        CareDocs.BloodGasMasterDataTable GetBloodGasMasterTable(string detailId);
        int UpdateBloodGasMaster(CareDocs.BloodGasMasterDataTable dataTable);
        CareDocs.BloodGasDetailDataTable GetBloodGasDetailTable(string detailId);
        int UpdateBloodGasDetail(CareDocs.BloodGasDetailDataTable dataTable);

        CareDocs.UserScheduleDataTable GetUserSchedule();
        CareDocs.UserScheduleDataTable GetUserSchedule(DateTime startTime,DateTime endTime);
        int UpdateUserSchedule(CareDocs.UserScheduleDataTable dataTable);

        CareDocs.PatientMonitorDataDataTable GetPatientMonitorData();
        CareDocs.PatientMonitorDataDataTable GetPatientMonitorData(string patient_id, decimal visit_id, decimal oper_id);
        CareDocs.PatientMonitorDataDataTable GetPatientMonitorData(string patient_id, decimal visit_id, decimal oper_id, decimal eventNo);
        CareDocs.PatientMonitorDataDataTable GetPatientMonitorData(string patient_id, decimal visit_id, decimal oper_id,DateTime timePoint, string itemName, decimal eventNo);
        int UpdatePatientMonitorData(CareDocs.PatientMonitorDataDataTable dataTable);

        CareDocs.ModifyHistoryDataTable GetModifyHistory();
        CareDocs.ModifyHistoryDataTable GetModifyHistory(string tableName, string fieldName);
        int UpdateModifyHistory(CareDocs.ModifyHistoryDataTable dataTable);
        int InsertNewModifyHistoryRecord(string tableName, string fieldName, string primaryKey, string newValue, string oldValue, DateTime modifyTime, string operatorName);

        void DeleteBloodGasDetail(string detailsId);
        /// <summary>
        /// PACU观察指标/评分
        /// </summary>
        /// <returns></returns>
        CareDocs.WIS_PACU_SCOREDataTable GetPACUSorce();
        int UpdatePACUSorce(CareDocs.WIS_PACU_SCOREDataTable dataTable);
        /// <summary>
        /// 手术收费记录单
        /// </summary>
        /// <returns></returns>
        CareDocs.MED_ANESTHESIA_DEVICEPRICEDataTable GetANESDEVICEPRICED();
        int UpdateANESDEVICEPRICED(CareDocs.MED_ANESTHESIA_DEVICEPRICEDataTable dataTable);

        /// <summary>
        /// 手术清点记录
        /// </summary>
        /// <returns></returns>
       CareDocs.MED_ANES_OPEREQUIPMENTRCDDataTable GetANESOPEREQUIPMENTRCD();
       int UpdateANESOPEREQUIPMENTRCD(CareDocs.MED_ANES_OPEREQUIPMENTRCDDataTable dataTable);



       int UpdateAnesCareCheckRecord(CareDocs.AnesDocCheckRecordDataTable dataTable);
       CareDocs.AnesDocCheckRecordDataTable GetAnesCareCheckRecord(string patientID, int visitID, int operID, string docName);
       CareDocs.AnesDocCheckRecordDataTable GetAnesCareCheckRecord();
    }


}
