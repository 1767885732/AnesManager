/*----------------------------------------------------------------
      // Copyright (C) 2008 北京拓扑工厂科技发展有限公司
      // 文件名：IPatientBaseInformations.cs
      // 文件功能描述：病人基本信息接口
      //
      // 
      // 创建标识：XXX-2008-10-23
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Wis.Anes.BusinessEntity;

namespace Wis.Anes.Interface
{
    /// <summary>
    /// 病人基本信息接口
    /// </summary>
    public interface IPatientInformations
    {

        PatientBaseInformations.OperationsInfoDataTable GetHistoryOpertionsInfo();
        PatientBaseInformations.OperationsInfoDataTable GetOpertionsInfo(decimal operStatus);
        PatientBaseInformations.OperationsInfoDataTable GetOpertionsInfo(DateTime startTime, DateTime endTime);
        /// <summary>
        /// 获取在院病人信息
        /// </summary>
        PatientBaseInformations.PatsInHospitalDataTable GetPatsInHospital();
        PatientBaseInformations.PatsInHospitalDataTable GetPatsInHospital(string patientID, decimal visitID);
        int UpdatePatsInHospitalDataTable(PatientBaseInformations.PatsInHospitalDataTable dataTable);
        /// <summary>
        /// 获取病人信息
        /// </summary>
        /// <returns></returns>
        PatientBaseInformations.PatientInformationDataTable GetPatientInformation(decimal operStatus,bool useMin);
        /// <summary>
        /// 获取某病人基本信息记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <returns>病人基本信息记录</returns>
        PatientBaseInformations.PatMasterIndexDataTable GetPatMasterIndexDataTable(string patientID);
        /// <summary>
        /// 获取某病人基本信息记录
        /// </summary>
        /// <returns>病人基本信息记录</returns>
        PatientBaseInformations.PatMasterIndexDataTable GetPatMasterIndexDataTable();
        /// <summary>
        /// 更新病人基本信息记录
        /// </summary>
        /// <param name="patMasterIndexDataTable">病人基本信息数据集</param>
        /// <returns>更新受影响的行数</returns>
        int UpdatePatMasterIndexDataTable(PatientBaseInformations.PatMasterIndexDataTable patMasterIndexDataTable);
        /// <summary>
        /// 更新病人基本信息记录及病人手术主记录
        /// </summary>
        /// <param name="patMasterIndexDataTable">病人基本信息数据集</param>
        /// <returns>更新受影响的行数</returns>
        int UpdatePatMasterIndexOperationMaster(PatientBaseInformations.PatMasterIndexDataTable patMasterIndexDataTable,
                                                AnesInformations.OperationMasterDataTable operationMasterDataTable);
        /// <summary>
        /// 获取某病人住院记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">病人本次住院标识</param>
        /// <returns>病人住院记录</returns>
        PatientBaseInformations.PatVisitDataTable GetVisitDataTable(string patientID, decimal visitID);
        /// <summary>
        /// 更新病人住院记录
        /// </summary>
        /// <param name="patVisitDataTable">病人住院记录信息数据集</param>
        /// <returns>更新受影响的行数</returns>
        int UpdateVisitDataTable(PatientBaseInformations.PatVisitDataTable patVisitDataTable);
        /// <summary>
        /// 返回病人手术信息
        /// </summary>
        /// <returns></returns>
        PatientBaseInformations.PatOperationDataTable GetPatOperation();
        /// <summary>
        /// 返回病人信息及手术信息
        /// </summary>
        /// <param name="patient_id"></param>
        /// <param name="visit_id"></param>
        /// <param name="schedule_id"></param>
        /// <returns></returns>
        PatientBaseInformations.PatOperationDataTable GetPatOperation(string patient_id, decimal visit_id, decimal schedule_id);

        /// <summary>
        /// 获取病人手术住记录oper_id
        /// </summary>
        /// <param name="patient_id">病人ID</param>
        /// <param name="visit_id">本次住院标识</param>
        /// <returns></returns>
        PatientBaseInformations.MaxValueDataTable GetOper_id(string patient_id, decimal visit_id);
        PatientBaseInformations.MaxValueDataTable GetMaxEventItemNo(string patient_id, decimal visit_id,decimal oper_id);

        /// <summary>
        /// 获取病人visit_id
        /// </summary>
        /// <param name="patient_id">病人ID</param>
        /// <returns></returns>
        PatientBaseInformations.MaxValueDataTable GetVisit_id(string patient_id);


       
        /// <summary>
        /// 根据条件获取患者信息表
        /// </summary>
        DataTable GetPatientListDataTable(DateTime startDate,DateTime endDate, string patientID, string patientName, string anesthesiaDoctor, string departCode
                    , string operationStatus, string asa, string operationName, string anesthesiaMethod, string age, string age1);

        bool PatientIdIsExist(string patientId);

        DataTable GetPatientListDataTable(DateTime startDate, string patientID, string patientName, string anesthesiaDoctor, string departCode
            , string operationStatus, string asa, string operationName, string anesthesiaMethod, string age, string age1);

        DataTable GetPatientList(DateTime startDate, string patientID, string patientName, string anesthesiaDoctor, string departCode
            , string operationStatus, string asa, string operationName, string anesthesiaMethod, string age, string age1,string operationRoom);
    }
}
