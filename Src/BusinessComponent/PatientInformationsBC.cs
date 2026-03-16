using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Interface;
using Wis.Anes.DataAccess;
using System.Data;

namespace Wis.Anes.BusinessComponent
{
    public class PatientInformationsBC:IPatientInformations
    {
        public PatientBaseInformations.OperationsInfoDataTable GetHistoryOpertionsInfo()
        {
            return (new PatientInformationsDA()).GetHistoryOpertionsInfo();
        }

        public PatientBaseInformations.OperationsInfoDataTable GetOpertionsInfo(decimal operStatus)
        {
            return (new PatientInformationsDA()).GetOpertionsInfo(operStatus);
        }

        public PatientBaseInformations.OperationsInfoDataTable GetOpertionsInfo(DateTime startTime, DateTime endTime)
        {
            return (new PatientInformationsDA()).GetOpertionsInfo(startTime, endTime);
        }
        /// <summary>
        /// 获取在院病人信息
        /// </summary>
        /// <returns></returns>
        public PatientBaseInformations.PatsInHospitalDataTable GetPatsInHospital()
        {
            return (new PatientInformationsDA()).GetPatsInHospital();
        }

        public PatientBaseInformations.PatsInHospitalDataTable GetPatsInHospital(string patientID, decimal visitID)
        {
            return (new PatientInformationsDA()).GetPatsInHospital(patientID, visitID);
        }

        public int UpdatePatsInHospitalDataTable(PatientBaseInformations.PatsInHospitalDataTable dataTable)
        {
            return (new PatientInformationsDA()).UpdatePatsInHospitalDataTable(dataTable);
        }

        /// <summary>
        /// 获取病人信息
        /// </summary>
        /// <returns></returns>
        public PatientBaseInformations.PatientInformationDataTable GetPatientInformation(decimal operStatus, bool useMin)
        {
            return (new PatientInformationsDA()).GetPatientInformation(operStatus, useMin);
        }
        /// <summary>
        /// 获取某病人基本信息记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <returns>病人基本信息记录</returns>
        public PatientBaseInformations.PatMasterIndexDataTable GetPatMasterIndexDataTable(string patientID)
        {
            return (new PatientInformationsDA()).GetPatMasterIndexDataTable(patientID);
        }
        /// <summary>
        /// 获取某病人基本信息记录
        /// </summary>
        /// <returns>病人基本信息记录</returns>
        public PatientBaseInformations.PatMasterIndexDataTable GetPatMasterIndexDataTable()
        {
            return (new PatientInformationsDA()).GetPatMasterIndexDataTable();
        }
        /// <summary>
        /// 更新病人基本信息记录
        /// </summary>
        /// <param name="patMasterIndexDataTable">病人基本信息数据集</param>
        /// <returns>更新受影响的行数</returns>
        public int UpdatePatMasterIndexDataTable(PatientBaseInformations.PatMasterIndexDataTable patMasterIndexDataTable)
        {
            return (new PatientInformationsDA()).UpdatePatMasterIndexDataTable(patMasterIndexDataTable);
        }
        /// <summary>
        /// 更新病人基本信息记录及病人手术主记录
        /// </summary>
        /// <param name="patMasterIndexDataTable">病人基本信息数据集</param>
        /// <returns>更新受影响的行数</returns>
        public int UpdatePatMasterIndexOperationMaster(PatientBaseInformations.PatMasterIndexDataTable patMasterIndexDataTable,
                                                        AnesInformations.OperationMasterDataTable operationMasterDataTable)
        {
            return (new PatientInformationsDA()).UpdatePatMasterIndexOperationMaster(patMasterIndexDataTable, operationMasterDataTable);
        }
        /// <summary>
        /// 获取某病人住院记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">病人本次住院标识</param>
        /// <returns>病人住院记录</returns>
        public PatientBaseInformations.PatVisitDataTable GetVisitDataTable(string patientID, decimal visitID)
        {
            return (new PatientInformationsDA()).GetVisitDataTable(patientID, visitID);
        }
        /// <summary>
        /// 更新病人住院记录
        /// </summary>
        /// <param name="patVisitDataTable">病人住院记录信息数据集</param>
        /// <returns>更新受影响的行数</returns>
        public int UpdateVisitDataTable(PatientBaseInformations.PatVisitDataTable patVisitDataTable)
        {
            return (new PatientInformationsDA()).UpdateVisitDataTable(patVisitDataTable);
        }
        /// <summary>
        /// 返回病人手术信息
        /// </summary>
        /// <returns></returns>
        public PatientBaseInformations.PatOperationDataTable GetPatOperation()
        {
            return (new PatientInformationsDA()).GetPatOperation();
        }
        /// <summary>
        /// 返回病人信息及手术信息
        /// </summary>
        /// <param name="patient_id"></param>
        /// <param name="visit_id"></param>
        /// <param name="schedule_id"></param>
        /// <returns></returns>
        public PatientBaseInformations.PatOperationDataTable GetPatOperation(string patient_id, decimal visit_id, decimal schedule_id)
        {
            return (new PatientInformationsDA()).GetPatOperation(patient_id, visit_id, schedule_id);
        }

        /// <summary>
        /// 获取病人手术主记录oper_id
        /// </summary>
        /// <param name="patient_id">病人ID</param>
        /// <param name="visit_id">本次住院标识</param>
        /// <returns></returns>
        public PatientBaseInformations.MaxValueDataTable GetOper_id(string patient_id, decimal visit_id)
        {
            return (new PatientInformationsDA()).GetOper_id(patient_id, visit_id);
        }

        public PatientBaseInformations.MaxValueDataTable GetMaxEventItemNo(string patient_id, decimal visit_id, decimal oper_id)
        {
            return (new PatientInformationsDA()).GetMaxEventItemNo(patient_id, visit_id, oper_id);
        }

        /// <summary>
        /// 获取病人visit_id
        /// </summary>
        /// <param name="patient_id">病人ID</param>
        /// <returns></returns>
        public PatientBaseInformations.MaxValueDataTable GetVisit_id(string patient_id)
        {
            return (new PatientInformationsDA()).GetVisit_id(patient_id);
        }

        /// <summary>
        /// 根据条件获取患者信息表
        /// </summary>
        public DataTable GetPatientListDataTable(DateTime startDate, string patientID, string patientName, string anesthesiaDoctor, string departCode
            , string operationStatus, string asa, string operationName, string anesthesiaMethod, string age, string age1)
        {
            return (new PatientInformationsDA()).GetPatientListDataTable(startDate, patientID, patientName, anesthesiaDoctor, departCode
                , operationStatus, asa, operationName, anesthesiaMethod, age, age1);
        }

        /// <summary>
        /// 根据条件获取患者信息表
        /// </summary>
        public DataTable GetPatientListDataTable(DateTime startDate, DateTime endDate, string patientID, string patientName, string anesthesiaDoctor, string departCode
            , string operationStatus, string asa, string operationName, string anesthesiaMethod, string age, string age1)
        {
            return (new PatientInformationsDA()).GetPatientListDataTable(startDate, endDate, patientID, patientName, anesthesiaDoctor, departCode
                , operationStatus, asa, operationName, anesthesiaMethod, age, age1);
        }

        public bool PatientIdIsExist(string patientId)
        {
            PatientInformationsDA patientInformationsDA = new PatientInformationsDA();
            return patientInformationsDA.PatientIdIsExist(patientId);
        }
        public DataTable GetPatientList(DateTime startDate, string patientID, string patientName, string anesthesiaDoctor, string departCode
            , string operationStatus, string asa, string operationName, string anesthesiaMethod, string age, string age1, string operationRoom)
        {
            PatientInformationsDA patientDA = new PatientInformationsDA();
            return patientDA.GetPatientList(startDate, patientID, patientName, anesthesiaDoctor, departCode
            ,  operationStatus,  asa,  operationName,  anesthesiaMethod,  age,  age1,operationRoom);
        }

    }
}
