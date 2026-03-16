/*----------------------------------------------------------------
      // Copyright (C) 2010 北京拓扑工厂科技发展有限公司
      // 文件名：ISync
      // 文件功能描述：His接口
      //
      // 
      // 创建标识：XXX-2011-01-14
      // 修改标识：
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.BusinessEntity;
using System.Data;

namespace Wis.Anes.Interface
{
    /// <summary>
    /// His接口
    /// </summary>
    public partial interface ISync
    {
        /// <summary>
        /// 回写手术状态到HIS
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        string SyncWriteHisOperStatus(string patientID, int visitID, int operID);
        /// <summary>
        /// 同步单病人医嘱信息
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        string SyncOrderInfo(string patientID, int visitID);
        /// <summary>
        /// 同步单病人基本信息及住院信息
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        string SyncPatientInfoAndInHospital(string patientID);
        /// <summary>
        /// 同步单病人基本信息及住院信息
        /// </summary>
        /// <param name="inpno">住院号</param>
        /// <returns></returns>
        string SyncPatientInfoAndInHospitalByInpNo(string inpNo);
        /// <summary>
        /// 同步病人申请或预约信息
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        string SyncScheduleInfo(string patientID);
        string SyncScheduleInfo(string patientID, int dateDiff);
        string SyncScheduleInfoByDeptCode(string performedcode);
        /// <summary>
        /// 根据病人ID提取同步检验信息
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="eventHandle"></param>
        string SyncLis(string patientID, EventHandler eventHandle);
        string SyncLis(string patientID, decimal visitID, EventHandler eventHandle);
        string SyncEMR(string patientID, decimal visitID, EventHandler eventHandle);
        string SyncPACS(string patientID, decimal visitID, EventHandler eventHandle);
        Sync.CheckReportDataTable GetCheckReport(string patientID, decimal visitID);
        Sync.WIS_MR_INDEXDataTable GetMrIndex(string patientID, decimal visitID);
        Sync.WIS_MR_FILE_INDEXDataTable GetMrFileIndex(string patientID, decimal visitID, decimal fileNo);
       
        Sync.LabQueryDataTable GetLabQuery(string patientID, decimal visitID);

        /// <summary>
        /// 获取检验信息主表
        /// </summary>
        /// <returns>检验信息主表</returns>
        Sync.MedLabTestMasterDataTable GetLabTestMaster(string patientID, decimal visitID);
        /// <summary>
        /// 获取检验信息结果
        /// </summary>
        /// <returns>检验信息结果</returns>
        Sync.MedLabResultDataTable GetLabResult(string testNo);

        DataTable GetOrders(string patientID, decimal visitID);


        int SyncOperationNameToMaster(string patientID, decimal visitID, decimal operID);


        // 上传PDF到HIS
        //Sync.WIS_EMR_ARCHIVE_DETAILDataTable GetEmrArchiveTable();
        //int UpdateEmrArchiveTable(Sync.WIS_EMR_ARCHIVE_DETAILDataTable dt);
        //string SyncOperationTimesInfo(string patientID, decimal visitID, decimal operID, DateTime dt, string type);
    }
}
