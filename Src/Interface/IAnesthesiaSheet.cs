/*----------------------------------------------------------------
 // Copyright (C) 2007 北京拓扑工厂科技发展有限公司
 // 文件名：IAnesthesiaSheet.cs
 // 文件功能描述：
 //      麻醉单(复苏单)接口类
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
    /// 麻醉单(复苏单)接口类
    /// </summary>
    public interface IAnesthesiaSheet
    {
        AnesInformations.AnesthesiaNurseDataTable GetAnesthesiaNurse(string patientID, decimal visitID, decimal operID);
        int UpdateAnesthesiaNurse(AnesInformations.AnesthesiaNurseDataTable dataTable);

        AnesInformations.OperationEqipDetailDataTable GetOperationEqipDetail(string patientID, decimal visitID, decimal operID);
        int UpdateOperationEqipDetail(AnesInformations.OperationEqipDetailDataTable updateTable);

        AnesInformations.AnesthesiaEventDataTable GetAnesthesiaEvent(string patientID, decimal visitID, decimal operID, decimal eventNo);
        /// <summary>
        /// 获取麻醉信息
        /// </summary>
        /// <returns>麻醉信息表</returns>
        AnesInformations.AnesthesiaEventDataTable GetAnesthesiaEvent();

        /// <summary>
        /// 获取麻醉信息
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <returns>麻醉信息表</returns>
        AnesInformations.AnesthesiaEventDataTable GetAnesthesiaEvent(string patientID, decimal visitID);

        /// <summary>
        /// 获取麻醉信息
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <param name="itemClass">麻醉信息类型</param>
        /// <returns>麻醉信息表</returns>
        AnesInformations.AnesthesiaEventDataTable GetAnesthesiaEvent(string patientID, decimal visitID, string itemClass);

        /// <summary>
        /// 获取麻醉信息
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <param name="operID">手术ID</param>
        /// <returns>麻醉信息表</returns>
        AnesInformations.AnesthesiaEventDataTable GetAnesthesiaEvent(string patientID, decimal visitID, decimal operID);

        int UpdateAnesthesiaEvent(AnesInformations.AnesthesiaEventDataTable dataTable);

        /// <summary>
        /// 获取麻醉信息
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <param name="itemClass">麻醉信息类型</param>
        /// <param name="operID">手术ID</param>
        /// <returns>麻醉信息表</returns>
        AnesInformations.AnesthesiaEventDataTable GetAnesthesiaEvent(string patientID, decimal visitID, string itemClass, decimal operID);
        /// <summary>
        /// 获取原始监测数据表
        /// </summary>
        /// <returns>原始监测数据表</returns>
        AnesInformations.PatMonitorDateDataTable GetPatMonitorDate();

        /// <summary>
        /// 获取原始监测数据表
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <returns>原始监测数据表</returns>
        AnesInformations.PatMonitorDateDataTable GetPatMonitorDate(string patientID, decimal visitID);

        /// <summary>
        /// 获取原始监测数据表
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <param name="operID">手术ID</param>
        /// <returns>原始监测数据表</returns>
        AnesInformations.PatMonitorDateDataTable GetPatMonitorDate(string patientID, decimal visitID, decimal operID, decimal eventNo);

        /// <summary>
        /// 获取手术主表
        /// </summary>
        /// <returns></returns>
        AnesInformations.OperationMasterDataTable GetOperationMaster();
        AnesInformations.OperationMasterDataTable GetOperationMaster(DateTime dtStart, DateTime dtEnd);
        AnesInformations.OperationMasterDataTable GetOperationMaster(decimal operStatusStart, decimal operStatusEnd, string roomNo);
        AnesInformations.OperationMasterDataTable GetOperationMaster(string roomNo, decimal operStatus);

        /// <summary>
        /// 更新手术主表
        /// </summary>
        /// <param name="operationMasterDataTable">手术主表数据集</param>
        /// <returns>更新影响的行数</returns>
        int UpdateOperationMaster(AnesInformations.OperationMasterDataTable operationMasterDataTable);

        /// <summary>
        /// 获取病人手术主表信息
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <param name="operID">手术ID</param>
        /// <returns>病人对应手术主表记录行</returns>
        AnesInformations.OperationMasterDataTable GetOperationMaster(string patientID, decimal visitID, decimal operID);
        /// <summary>
        /// 获取病人手术主表信息
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <param name="operID">手术ID</param>
        /// <returns>病人对应手术主表记录行</returns>
        AnesInformations.OperationMasterDataTable GetOperationMaster(string patientID);
        /// <summary>
        /// 获取病人麻醉主记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">病人本次住院标识</param>
        /// <param name="operID">手术号</param>
        /// <returns>病人麻醉主记录</returns>
        AnesInformations.AnesthesiaPlanDataTable GetAnesthesiaPlan(string patientID, decimal visitID, decimal operID);

        /// <summary>
        /// 更新病人麻醉主记录
        /// </summary>
        /// <param name="anesthesiaPlanDataTable">病人麻醉主记录数据集</param>
        /// <returns>更新受影响的行数</returns>
        int UpdateAnesthesiaPlan(AnesInformations.AnesthesiaPlanDataTable anesthesiaPlanDataTable);



        /// <summary>
        /// 获取监测数据表
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <param name="operID">手术ID</param>
        /// <returns>监测数据表</returns>
        AnesInformations.VitalSignDataTable GetVitalSignData(string patientID, decimal visitID, decimal operID, decimal eventNo);//,ref string[] items);
        AnesInformations.VitalSignDataTable GetVitalSignData(string patientID, decimal visitID, decimal operID, decimal eventNo, bool isHistory);//,ref string[] items);

        string[] GetVitalSignTitles(string patientID, decimal visitID, decimal operID, decimal eventNo);
        int UpdatePatMonitorDate(AnesInformations.PatMonitorDateDataTable updateTable);


        /// <summary>
        /// 获取江苏麻醉科操作记录表
        /// </summary>
        /// <returns>江苏麻醉科操作记录表</returns>
        AnesInformations.JSMZKCaoZhuoDataTable GetJSMZKCaoZhuoData();

        /// <summary>
        /// 获取江苏麻醉科操作记录表
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <param name="operID">手术ID</param>
        /// <returns>江苏麻醉科操作记录表</returns>
        AnesInformations.JSMZKCaoZhuoDataTable GetJSMZKCaoZhuoData(string patientID, decimal visitID, decimal operID);

        /// <summary>
        /// 更新江苏麻醉科操作记录表
        /// </summary>
        /// <param name="jsMZKCaoZhuoDataTable"></param>
        /// <returns>更新的行数</returns>
        int UpdateJSMZKCaoZhuoData(AnesInformations.JSMZKCaoZhuoDataTable jsMZKCaoZhuoDataTable);




        /// <summary>
        /// PACU
        /// </summary>
        /// <returns></returns>
        AnesInformations.AnesthesiaPACUDataTable GetAnesthesiaPACUData();

        /// <summary>
        /// PACU
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        AnesInformations.AnesthesiaPACUDataTable GetAnesthesiaPACUData(string patientID, decimal visitID, decimal operID);


        /// <summary>
        /// 更新PACU
        /// </summary>
        /// <param name="jsMZKCaoZhuoDataTable"></param>
        /// <returns>更新的行数</returns>
        int UpdateAnesthesiaPACUData(AnesInformations.AnesthesiaPACUDataTable updateTable);

        AnesInformations.VitalSignDataTable GetCPBVitalSignData(string patientID, decimal visitID, decimal operID, decimal eventNo);


        AnesInformations.WIS_PAT_DRUG_DETAILDataTable GetPatientDrugItem(string patientID, decimal visitID, decimal operID);
        AnesInformations.WIS_PAT_DRUG_DETAILDataTable GetPatientDrugItem(string patientID, decimal visitID, decimal operID,decimal itemType);
        int UpdatePatientDrugItem(AnesInformations.WIS_PAT_DRUG_DETAILDataTable dataTable);

        AnesInformations.PunctureRecordDataTable GetPunctureRecordDataTable();
        AnesInformations.PunctureRecordDataTable GetPunctureRecordDataTable(string patientID, decimal visitID, decimal operID);
        int UpdatePunctureRecordDataTable(AnesInformations.PunctureRecordDataTable dataTable);

        int UpdateOperationScheduleStatus(string patientID, decimal visitID, decimal operID, int status);

        /// <summary>
        /// 获取病人麻醉主记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">病人本次住院标识</param>
        /// <param name="operID">手术号</param>
        /// <returns>病人麻醉主记录</returns>
        AnesInformations.AnesOperHandoverDataTable GetAnesOperHandoverDataTable(string patientID, decimal visitID, decimal operID);

        /// <summary>
        /// 更新病人麻醉主记录
        /// </summary>
        /// <param name="anesthesiaPlanDataTable">病人麻醉主记录数据集</param>
        /// <returns>更新受影响的行数</returns>
        int UpdateAnesOperHandoverDataTable(AnesInformations.AnesOperHandoverDataTable dataTable);

        AnesthesiaSheet.ScheduledOperationNameDataTable GetScheduledOperationName(string patientID, decimal visitID, decimal operID);


        AnesInformations.OperShiftRecordDataTable GetOperShiftRecordDataTable();


        AnesInformations.OperShiftRecordDataTable GetOperShiftRecordDataTable(string patientID, decimal visitID, decimal operID);


        int UpdateOperShiftRecordDataTable(AnesInformations.OperShiftRecordDataTable dataTable);


        DataTable GetAnesAlarmMsg(string patientID, decimal visitID, decimal operID);
        int UpdateAnesAlarmMsg(DataTable dataTable);

        DataTable GetOperCanceledInfo();

        int UpdateCancelOper(string patientID, decimal visitID, decimal operID);
    }
}
