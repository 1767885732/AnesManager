using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Interface;
using Wis.Anes.DataAccess;
using Wis.Anes.Framework;
using System.Data;

namespace Wis.Anes.BusinessComponent
{
    public class AnesthesiaSheetBC : IAnesthesiaSheet
    {


        public AnesInformations.AnesthesiaNurseDataTable GetAnesthesiaNurse(string patientID, decimal visitID, decimal operID)
        {
            return (new AnesthesiaSheetDA()).GetAnesthesiaNurse(patientID, visitID, operID);
        }

        public int UpdateAnesthesiaNurse(AnesInformations.AnesthesiaNurseDataTable dataTable)
        {
            return (new AnesthesiaSheetDA()).UpdateAnesthesiaNurse(dataTable);
        }

        public AnesInformations.OperationEqipDetailDataTable GetOperationEqipDetail(string patientID, decimal visitID, decimal operID)
        {
            return (new AnesthesiaSheetDA()).GetOperationEqipDetail(patientID, visitID, operID);
        }

        public int UpdateOperationEqipDetail(AnesInformations.OperationEqipDetailDataTable updateTable)
        {
            return (new AnesthesiaSheetDA()).UpdateOperationEqipDetail(updateTable);
        }

        public AnesInformations.AnesthesiaEventDataTable GetAnesthesiaEvent(string patientID, decimal visitID, decimal operID, decimal eventNo)
        {
            return (new AnesthesiaSheetDA()).GetAnesthesiaEvent(patientID, visitID, operID, eventNo);
        }
        public int UpdateAnesthesiaEvent(AnesInformations.AnesthesiaEventDataTable dataTable)
        {
            return (new AnesthesiaSheetDA()).UpdateAnesthesiaEvent(dataTable);
        }

        /// <summary>
        /// 获取麻醉信息
        /// </summary>
        /// <returns>麻醉信息表</returns>
        public AnesInformations.AnesthesiaEventDataTable GetAnesthesiaEvent()
        {
            return (new AnesthesiaSheetDA()).GetAnesthesiaEvent();
        }

        /// <summary>
        /// 获取麻醉信息
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <returns>麻醉信息表</returns>
        public AnesInformations.AnesthesiaEventDataTable GetAnesthesiaEvent(string patientID, decimal visitID)
        {
            return (new AnesthesiaSheetDA()).GetAnesthesiaEvent(patientID, visitID);
        }

        /// <summary>
        /// 获取麻醉信息
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <param name="itemClass">麻醉信息类型</param>
        /// <returns>麻醉信息表</returns>
        public AnesInformations.AnesthesiaEventDataTable GetAnesthesiaEvent(string patientID, decimal visitID, string itemClass)
        {
            return (new AnesthesiaSheetDA()).GetAnesthesiaEvent(patientID, visitID, itemClass);
        }

        /// <summary>
        /// 获取麻醉信息
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <param name="operID">手术ID</param>
        /// <returns>麻醉信息表</returns>
        public AnesInformations.AnesthesiaEventDataTable GetAnesthesiaEvent(string patientID, decimal visitID, decimal operID)
        {
            return (new AnesthesiaSheetDA()).GetAnesthesiaEvent(patientID, visitID, operID);
        }

        /// <summary>
        /// 获取麻醉信息
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <param name="itemClass">麻醉信息类型</param>
        /// <param name="operID">手术ID</param>
        /// <returns>麻醉信息表</returns>
        public AnesInformations.AnesthesiaEventDataTable GetAnesthesiaEvent(string patientID, decimal visitID, string itemClass, decimal operID)
        {
            return (new AnesthesiaSheetDA()).GetAnesthesiaEvent(patientID, visitID, itemClass, operID);
        }

        public string[] GetVitalSignTitles(string patientID, decimal visitID, decimal operID, decimal eventNo)
        {
            return (new AnesthesiaSheetDA()).GetVitalSignTitles(patientID, visitID, operID, eventNo);
        }




        public int UpdatePatMonitorDate(AnesInformations.PatMonitorDateDataTable updateTable)
        {
            return (new AnesthesiaSheetDA()).UpdatePatMonitorDate(updateTable);
        }


        /// <summary>
        /// 获取原始监测数据表
        /// </summary>
        /// <returns>原始监测数据表</returns>
        public AnesInformations.PatMonitorDateDataTable GetPatMonitorDate()
        {
            return (new AnesthesiaSheetDA()).GetPatMonitorDate();
        }

        /// <summary>
        /// 获取原始监测数据表
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <returns>原始监测数据表</returns>
        public AnesInformations.PatMonitorDateDataTable GetPatMonitorDate(string patientID, decimal visitID)
        {
            return (new AnesthesiaSheetDA()).GetPatMonitorDate(patientID, visitID);
        }

        /// <summary>
        /// 获取原始监测数据表
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <param name="operID">手术ID</param>
        /// <returns>原始监测数据表</returns>
        public AnesInformations.PatMonitorDateDataTable GetPatMonitorDate(string patientID, decimal visitID, decimal operID, decimal eventNo)
        {
            return (new AnesthesiaSheetDA()).GetPatMonitorDate(patientID, visitID, operID, eventNo);
        }

        /// <summary>
        /// 获取手术主表
        /// </summary>
        /// <returns></returns>
        public AnesInformations.OperationMasterDataTable GetOperationMaster()
        {
            return (new AnesthesiaSheetDA()).GetOperationMaster();
        }
        public AnesInformations.OperationMasterDataTable GetOperationMaster(DateTime dtStart, DateTime dtEnd)
        {
            return (new AnesthesiaSheetDA()).GetOperationMaster(dtStart, dtEnd);
        }
        public AnesInformations.OperationMasterDataTable GetOperationMaster(decimal operStatusStart, decimal operStatusEnd, string roomNo)
        {
            return (new AnesthesiaSheetDA()).GetOperationMaster(operStatusStart, operStatusEnd, roomNo);
        }

        public AnesInformations.OperationMasterDataTable GetOperationMaster(string roomNo, decimal operStatus)
        {
            return (new AnesthesiaSheetDA()).GetOperationMaster(roomNo, operStatus);
        }

        /// <summary>
        /// 获取病人手术主表信息
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <param name="operID">手术ID</param>
        /// <returns>病人对应手术主表记录行</returns>
        public AnesInformations.OperationMasterDataTable GetOperationMaster(string patientID, decimal visitID, decimal operID)
        {
            return (new AnesthesiaSheetDA()).GetOperationMaster(patientID, visitID, operID);
        }
        /// <summary>
        /// 获取病人手术主表信息
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <param name="operID">手术ID</param>
        /// <returns>病人对应手术主表记录行</returns>
        public AnesInformations.OperationMasterDataTable GetOperationMaster(string patientID)
        {
            return (new AnesthesiaSheetDA()).GetOperationMaster(patientID);
        }

        /// <summary>
        /// 更新手术主表
        /// </summary>
        /// <param name="operationMasterDataTable">手术主表数据集</param>
        /// <returns>更新影响的行数</returns>
        public int UpdateOperationMaster(AnesInformations.OperationMasterDataTable operationMasterDataTable)
        {
            return (new AnesthesiaSheetDA()).UpdateOperationMaster(operationMasterDataTable);
        }

        /// <summary>
        /// 获取病人麻醉主记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">病人本次住院标识</param>
        /// <param name="operID">手术号</param>
        /// <returns>病人麻醉主记录</returns>
        public AnesInformations.AnesthesiaPlanDataTable GetAnesthesiaPlan(string patientID, decimal visitID, decimal operID)
        {
            return (new AnesthesiaSheetDA()).GetAnesthesiaPlan(patientID, visitID, operID);
        }

        /// <summary>
        /// 更新病人麻醉主记录
        /// </summary>
        /// <param name="anesthesiaPlanDataTable">病人麻醉主记录数据集</param>
        /// <returns>更新受影响的行数</returns>
        public int UpdateAnesthesiaPlan(AnesInformations.AnesthesiaPlanDataTable anesthesiaPlanDataTable)
        {
            return (new AnesthesiaSheetDA()).UpdateAnesthesiaPlan(anesthesiaPlanDataTable);
        }

        /// <summary>
        /// 获取病人麻醉主记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">病人本次住院标识</param>
        /// <param name="operID">手术号</param>
        /// <returns>病人麻醉主记录</returns>
        public AnesInformations.VitalSignDataTable GetVitalSignData(string patientID, decimal visitID, decimal operID, decimal eventNo)//, ref string[] items)
        {
            return (new AnesthesiaSheetDA()).GetVitalSignData(patientID, visitID, operID, eventNo);//,ref items);
        }

        public AnesInformations.VitalSignDataTable GetVitalSignData(string patientID, decimal visitID, decimal operID, decimal eventNo, bool isHistory)//, ref string[] items)
        {
            return (new AnesthesiaSheetDA()).GetVitalSignData(patientID, visitID, operID, eventNo, isHistory);//,ref items);
        }



        /// <summary>
        /// 获取江苏麻醉科操作记录表
        /// </summary>
        /// <returns>江苏麻醉科操作记录表</returns>
        public AnesInformations.JSMZKCaoZhuoDataTable GetJSMZKCaoZhuoData()
        {
            return (new AnesthesiaSheetDA()).GetJSMZKCaoZhuoData();
        }

        /// <summary>
        /// 获取江苏麻醉科操作记录表
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <param name="operID">手术ID</param>
        /// <returns>江苏麻醉科操作记录表</returns>
        public AnesInformations.JSMZKCaoZhuoDataTable GetJSMZKCaoZhuoData(string patientID, decimal visitID, decimal operID)
        {
            return (new AnesthesiaSheetDA()).GetJSMZKCaoZhuoData(patientID, visitID, operID);
        }
        /// <summary>
        /// 更新江苏麻醉科操作记录表
        /// </summary>
        /// <param name="jsMZKCaoZhuoDataTable"></param>
        /// <returns>更新的行数</returns>
        public int UpdateJSMZKCaoZhuoData(AnesInformations.JSMZKCaoZhuoDataTable jsMZKCaoZhuoDataTable)
        {
            return (new AnesthesiaSheetDA()).UpdateJSMZKCaoZhuoData(jsMZKCaoZhuoDataTable);
        }



        /// <summary>
        /// PACU
        /// </summary>
        /// <returns></returns>
        public AnesInformations.AnesthesiaPACUDataTable GetAnesthesiaPACUData()
        {
            return (new AnesthesiaSheetDA()).GetAnesthesiaPACUData();
        }

        /// <summary>
        /// PACU
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        public AnesInformations.AnesthesiaPACUDataTable GetAnesthesiaPACUData(string patientID, decimal visitID, decimal operID)
        {
            return (new AnesthesiaSheetDA()).GetAnesthesiaPACUData(patientID, visitID, operID);
        }

        /// <summary>
        /// 更新PACU
        /// </summary>
        /// <param name="jsMZKCaoZhuoDataTable"></param>
        /// <returns>更新的行数</returns>
        public int UpdateAnesthesiaPACUData(AnesInformations.AnesthesiaPACUDataTable updateTable)
        {
            return (new AnesthesiaSheetDA()).UpdateAnesthesiaPACUData(updateTable);
        }

        public AnesInformations.VitalSignDataTable GetCPBVitalSignData(string patientID, decimal visitID, decimal operID, decimal eventNo)
        {
            return (new AnesthesiaSheetDA()).GetCPBVitalSignData(patientID, visitID, operID, eventNo);
        }


        public int UpdatePatientDrugItem(AnesInformations.WIS_PAT_DRUG_DETAILDataTable updateTable)
        {
            return (new AnesthesiaSheetDA()).UpdatePatientDrugItem(updateTable);
        }

        public AnesInformations.WIS_PAT_DRUG_DETAILDataTable GetPatientDrugItem(string patientID, decimal visitID, decimal operID)
        {
            return (new AnesthesiaSheetDA()).GetPatientDrugItem(patientID, visitID, operID);
        }

        public AnesInformations.WIS_PAT_DRUG_DETAILDataTable GetPatientDrugItem(string patientID, decimal visitID, decimal operID, decimal itemType)
        {
            return (new AnesthesiaSheetDA()).GetPatientDrugItem(patientID, visitID, operID, itemType);
        }

        public AnesInformations.PunctureRecordDataTable GetPunctureRecordDataTable()
        {
            return (new AnesthesiaSheetDA()).GetPunctureRecordDataTable();
        }

        public AnesInformations.PunctureRecordDataTable GetPunctureRecordDataTable(string patientID, decimal visitID, decimal operID)
        {
            return (new AnesthesiaSheetDA()).GetPunctureRecordDataTable(patientID, visitID, operID);
        }

        public int UpdatePunctureRecordDataTable(AnesInformations.PunctureRecordDataTable dataTable)
        {
            return (new AnesthesiaSheetDA()).UpdatePunctureRecordDataTable(dataTable);
        }
        public int UpdateOperationScheduleStatus(string patientID, decimal visitID, decimal operID, int status)
        {
            return (new AnesthesiaSheetDA()).UpdateOperationScheduleStatus(patientID, visitID, operID, status);
        }

        public AnesInformations.AnesOperHandoverDataTable GetAnesOperHandoverDataTable(string patientID, decimal visitID, decimal operID)
        {
            return (new AnesthesiaSheetDA()).GetAnesOperHandoverDataTable(patientID, visitID, operID);
        }

        public int UpdateAnesOperHandoverDataTable(AnesInformations.AnesOperHandoverDataTable dataTable)
        {
            return (new AnesthesiaSheetDA()).UpdateAnesOperHandoverDataTable(dataTable);
        }

        public AnesthesiaSheet.ScheduledOperationNameDataTable GetScheduledOperationName(string patientID, decimal visitID, decimal operID)
        {
            return (new AnesthesiaSheetDA()).GetScheduledOperationName(patientID, visitID, operID);
        }

        public AnesInformations.OperShiftRecordDataTable GetOperShiftRecordDataTable()
        {
            return (new AnesthesiaSheetDA()).GetOperShiftRecordDataTable();
        }

        public AnesInformations.OperShiftRecordDataTable GetOperShiftRecordDataTable(string patientID, decimal visitID, decimal operID)
        {
            return (new AnesthesiaSheetDA()).GetOperShiftRecordDataTable(patientID, visitID, operID);
        }

        public int UpdateOperShiftRecordDataTable(AnesInformations.OperShiftRecordDataTable dataTable)
        {
            return (new AnesthesiaSheetDA()).UpdateOperShiftRecordDataTable(dataTable);
        }



        public DataTable GetAnesAlarmMsg(string patientID, decimal visitID, decimal operID)
        {
            return (new AnesthesiaSheetDA()).GetAnesAlarmMsg(patientID, visitID, operID);
        }

        public int UpdateAnesAlarmMsg(DataTable dataTable)
        {
            return (new AnesthesiaSheetDA()).UpdateAnesAlarmMsg(dataTable);
        }
        public DataTable GetOperCanceledInfo()
        {
            return (new AnesthesiaSheetDA()).GetOperCanceledInfo();
        }
        public int UpdateCancelOper(string patientID, decimal visitID, decimal operID)
        {
            return (new AnesthesiaSheetDA()).UpdateCancelOper(patientID, visitID, operID);
        }

    }
}
