using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.Interface;
using Wis.Anes.DataAccess;
using Wis.Anes.BusinessEntity;
using System.Data;

namespace Wis.Anes.BusinessComponent
{
    public class SyncBC : ISync
    {
        #region ISync 成员

        public string SyncWriteHisOperStatus(string patientID, int visitID, int operID)
        {
            return (new SyncDA()).SyncWriteHisOperStatus(patientID,visitID,operID);
        }

        public string SyncOrderInfo(string patientID, int visitID)
        {
            return (new SyncDA()).SyncOrderInfo(patientID,visitID);
        }

        public string SyncPatientInfoAndInHospital(string patientID)
        {
            return (new SyncDA()).SyncPatientInfoAndInHospital(patientID);
        }

        public string SyncPatientInfoAndInHospitalByInpNo(string inpNo)
        {
            return (new SyncDA()).SyncPatientInfoAndInHospitalByInpNo(inpNo);
        }

        public string SyncScheduleInfo(string patientID)
        {
            return (new SyncDA()).SyncScheduleInfo(patientID);
        }
        public string SyncScheduleInfo(string patientID,int dateDiff)
        {
            return (new SyncDA()).SyncScheduleInfo(patientID, dateDiff);
        }
        public string SyncScheduleInfoByDeptCode(string performedcode)
        {
            return (new SyncDA()).SyncScheduleInfoByDeptCode(performedcode);
        }

        public string SyncLis(string patientID, EventHandler eventHandle)
        {
            return (new SyncDA()).SyncLis(patientID, eventHandle);
        }
        public string SyncLis(string patientID, decimal visitID, EventHandler eventHandle)
        {
            return (new SyncDA()).SyncLis(patientID, visitID, eventHandle);
        }
        public string SyncEMR(string patientID, decimal visitID, EventHandler eventHandle)
        {
            return (new SyncDA()).SyncEMR(patientID, visitID, eventHandle);
        }
        public string SyncPACS(string patientID, decimal visitID, EventHandler eventHandle)
        {
            return (new SyncDA()).SyncPACS(patientID, visitID, eventHandle);
        }
        public Sync.CheckReportDataTable GetCheckReport(string patientID, decimal visitID)
        {
            return (new SyncDA()).GetCheckReport(patientID, visitID);
        }
        public Sync.WIS_MR_INDEXDataTable GetMrIndex(string patientID, decimal visitID)
        {
            return (new SyncDA()).GetMrIndex(patientID, visitID);
        }
        public Sync.WIS_MR_FILE_INDEXDataTable GetMrFileIndex(string patientID, decimal visitID, decimal fileNo)
        {
            return (new SyncDA()).GetMrFileIndex(patientID, visitID, fileNo);
        }
        public Sync.LabQueryDataTable GetLabQuery(string patientID, decimal visitID)
        {
            return (new SyncDA()).GetLabQuery(patientID, visitID);
        }

        /// <summary>
        /// 获取检验信息主表
        /// </summary>
        /// <returns>检验信息主表</returns>
        public Sync.MedLabTestMasterDataTable GetLabTestMaster(string patientID, decimal visitID)
        {
            return (new SyncDA()).GetLabTestMaster(patientID, visitID);
        }
        /// <summary>
        /// 获取检验信息结果
        /// </summary>
        /// <returns>检验信息结果</returns>
        public Sync.MedLabResultDataTable GetLabResult(string testNo)
        {
            return (new SyncDA()).GetLabResult(testNo);
        }
        public DataTable GetOrders(string patientID, decimal visitID)
        {
            return (new SyncDA()).GetOrders(patientID, visitID);
        }

        public int SyncOperationNameToMaster(string patientID, decimal visitID, decimal operID)
        {
            return (new SyncDA()).SyncOperationNameToMaster(patientID, visitID, operID);
        }
        #endregion

    }
}
