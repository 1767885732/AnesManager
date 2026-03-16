using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.Interface;
using Wis.Anes.BusinessComponent;
using Wis.Anes.BusinessEntity;
using System.Data;

namespace Wis.Anes.ServiceProxies
{
    public class SyncProxy
    {
        static ISync _iSync = new SyncBC();
        public static string SyncWriteHisOperStatus(string patientID, int visitID, int operID)
        {
            try
            {
                
                return _iSync.SyncWriteHisOperStatus(patientID,visitID,operID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string SyncOrderInfo(string patientID, int visitID)
        {
            try
            {
                return _iSync.SyncOrderInfo(patientID,visitID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string SyncPatientInfoAndInHospital(string patientID)
        {
            try
            {
                return _iSync.SyncPatientInfoAndInHospital(patientID);
            }
            catch (Exception ex)
            {
                throw ex;
                //return "SyncPatientInfoAndInHospital Error";
            }
        }
        public static string SyncPatientInfoAndInHospitalByInpNo(string inpNo)
        {
            try
            {
                return _iSync.SyncPatientInfoAndInHospitalByInpNo(inpNo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string SyncScheduleInfo(string patientID)
        {
            try
            {
                return _iSync.SyncScheduleInfo(patientID);
            }
            catch (Exception ex)
            {
                throw ex;
                //return "SyncScheduleInfo Error";
            }
        }

        public static string SyncScheduleInfoByDeptCode(string performedcode)
        {
            try
            {
                return _iSync.SyncScheduleInfoByDeptCode(performedcode);
            }
            catch (Exception ex)
            {
                throw ex;
                //return "SyncScheduleInfo Error";
            }
        }

        public static string SyncLis(string patientID, EventHandler eventHandle)
        {
            try
            {
                string ret = _iSync.SyncLis(patientID, eventHandle);
                if (!string.IsNullOrEmpty(ret))
                {
                    //DoError(new Exception(ret));
                }
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string SyncLis(string patientID,decimal visitID, EventHandler eventHandle)
        {
            try
            {
                string ret = _iSync.SyncLis(patientID, visitID, eventHandle);
                if (!string.IsNullOrEmpty(ret))
                {
                    //DoError(new Exception(ret));
                }
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string SyncEMR(string patientID, decimal visitID, EventHandler eventHandle)
        {
            try
            {
                string ret = _iSync.SyncEMR(patientID, visitID, eventHandle);
                if (!string.IsNullOrEmpty(ret))
                {
                    //DoError(new Exception(ret));
                }
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string SyncPACS(string patientID, decimal visitID, EventHandler eventHandle)
        {
            try
            {
                string ret = _iSync.SyncPACS(patientID, visitID, eventHandle);
                if (!string.IsNullOrEmpty(ret))
                {
                    //DoError(new Exception(ret));
                }
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Sync.CheckReportDataTable GetCheckReport(string patientID, decimal visitID)
        {
            try
            {
                return _iSync.GetCheckReport(patientID, visitID);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static Sync.WIS_MR_INDEXDataTable GetMrIndex(string patientID, decimal visitID)
        {
            try
            {
                return _iSync.GetMrIndex(patientID, visitID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Sync.WIS_MR_FILE_INDEXDataTable GetMrFileIndex(string patientID, decimal visitID, decimal fileNo)
        {
            try
            {
                return _iSync.GetMrFileIndex(patientID, visitID, fileNo);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static Sync.LabQueryDataTable GetLabQuery(string patientID, decimal visitID)
        {
            try
            {
                return _iSync.GetLabQuery(patientID, visitID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取检验信息主表
        /// </summary>
        /// <returns>检验信息主表</returns>
        public static Sync.MedLabTestMasterDataTable GetLabTestMaster(string patientID, decimal visitID)
        {
            try
            {
                return _iSync.GetLabTestMaster(patientID, visitID);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        /// <summary>
        /// 获取检验信息结果
        /// </summary>
        /// <returns>检验信息结果</returns>
        public static Sync.MedLabResultDataTable GetLabResult(string testNo)
        {
            try
            {
                return _iSync.GetLabResult(testNo);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static DataTable GetOrders(string patientID, decimal visitID)
        {
            try
            {
                return _iSync.GetOrders(patientID,visitID);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static int SyncOperationNameToMaster(string patientID, decimal visitID, decimal operID)
        {
            try
            {
                return _iSync.SyncOperationNameToMaster(patientID, visitID, operID);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        

    }
}
