/*----------------------------------------------------------------
 // Copyright (C) 2007 北京拓扑工厂科技发展有限公司
 // 文件名：IDict.cs
 // 文件功能描述：
 //     字典接口类
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.BusinessEntity;
using System.Data;

namespace Wis.Anes.Interface
{
    /// <summary>
    /// 字典接口类
    /// </summary>
    public interface IDict
    {
        /// <summary>
        /// 返回手术名称字典信息
        /// </summary>
        /// <returns></returns>
        Dict.OperationDictDataTable GetOperationDict();
        int UpdateOperationDict(Dict.OperationDictDataTable dataTable);

        Dict.DeptInfoDictDataTable GetDeptInfo();
        int UpdateDeptInfo(Dict.DeptInfoDictDataTable dataTable);

        /// <summary>
        /// 获取价表
        /// </summary>
        /// <returns></returns>
        Dict.PriceListDataTable GetPriceList();
        Dict.PriceListDataTable GetPriceList(string itemClass);
        int UpdatePriceList(Dict.PriceListDataTable dataTable);

        Dict.AnesthesiaEventTempletDataTable GetAnesthesiaEventTemplet();
        Dict.AnesthesiaEventTempletDataTable GetAnesthesiaEventTemplet(string templetName);
        int UpdateAnesthesiaEventTemplet(Dict.AnesthesiaEventTempletDataTable dateTable);
        Dict.MonitorDictDataTable GetMonitorDict();
        Dict.MonitorDictDataTable GetMonitorDict(decimal wardType);

        Dict.MonitorDictDataTable GetMonitorDict(string itemType, decimal wardType);
        int UpdateMonitorDict(Dict.MonitorDictDataTable dateTable);


        /// <summary>
        /// 返回麻醉输入项目字典信息
        /// </summary>
        /// <returns>麻醉输入项目字典信息</returns>
        Dict.AnesthesiaInputDictDataTable GetAnesthesiaInputDict();
        int UpdateAnesthesiaDictDT(Dict.AnesthesiaInputDictDataTable InputDateble);
        Dict.AnesthesiaInputDictDataTable GetDictTable(string item_class);
        /// <summary>
        /// 返回麻醉事件字典信息
        /// </summary>
        /// <param name="item_class"></param>
        /// <returns></returns>
        Dict.AnesthesiaEventOpenDataTable GetAnesthesiaEventOpen(string item_class);
        /// <summary>
        /// 返回所有麻醉事件
        /// </summary>
        /// <returns></returns>
        Dict.AnesthesiaEventOpenDataTable GetAnesthesiaEventOpen();
        /// <summary>
        /// 根据条件返回 吸入麻药,局部麻药,静脉麻药
        /// </summary>
        /// <param name="item_class"></param>
        /// <param name="EVENT_ATTR_2">1为吸入,2为局部,3为静脉</param>
        /// <returns></returns>
        Dict.AnesthesiaEventOpenDataTable GetAnesthesiaEventOpen(string item_class, string EVENT_ATTR_2);
        /// <summary>
        /// 根据条件查找呼吸
        /// </summary>
        /// <returns></returns>
        Dict.AnesthesiaEventOpenDataTable GetAnesthesiaEventOpenByhuxi();

        /// <summary>
        /// 更新麻醉师见字典信息
        /// </summary>
        /// <param name="EventOpenTable"></param>
        /// <returns></returns>
        int UpdateAnesthesiaEventOpen(Dict.AnesthesiaEventOpenDataTable EventOpenTable);
        /// <summary>
        /// 返回诊断字典信息
        /// </summary>
        /// <returns>诊断字典信息</returns>
        Dict.WisDiagnosisDictDataTable GetDiagnosisDict();
        /// <summary>
        /// 更新诊断字典信息
        /// </summary>
        /// <param name="DiagnosisDictDataTable"></param>
        /// <returns></returns>
        int UpdateDiagnosisDict(Dict.WisDiagnosisDictDataTable DiagnosisDictDataTable);


        /// <summary>
        /// 返回麻醉方法字典信息
        /// </summary>
        /// <returns></returns>
        Dict.AnessthestaDictDataTable GetAnesDict();
        /// <summary>
        ///更新麻醉方法字典信息
        /// </summary>
        /// <param name="dictTable"></param>
        /// <returns></returns>
        int UpdateAnesDict(Dict.AnessthestaDictDataTable dictTable);


        /// <summary>
        /// 获得HisUsers信息
        /// </summary>
        /// <returns></returns>
        Dict.HisUserDataTable GetHisUsers(string USER_JOB);
        Dict.HisUserDataTable GetHisUsersDept(string USER_JOB);
        Dict.HisUserDataTable GetHisUsers();
        /// <summary>
        /// 更新HisUsers
        /// </summary>
        /// <param name="HisUsersTable"></param>
        /// <returns></returns>
        int UpdateHisUsers(Dict.HisUserDataTable hisuserDT);

        /// <summary>
        /// 获取科室字典列表
        /// </summary>
        /// <returns></returns>
        Dict.DeptDictDataTable GetDeptDict();
        Dict.DeptDictDataTable GetDeptDict(string deptCode);
        /// <summary>
        /// 获取医生姓名
        /// </summary>
        /// <returns></returns>
        Dict.HisUserDataTable GetDoctor();
        /// <summary>
        /// 获得护士姓名
        /// </summary>
        /// <returns></returns>
        Dict.HisUserDataTable GetNurse();


        Dict.CustomDataExtDataTable GetCustomDataExt();
        Dict.CustomDataExtDataTable GetCustomDataExt(string patientID, decimal visitID, decimal operID);
        int UpdateCustomDataExt(Dict.CustomDataExtDataTable dataTable);

        Dict.WIS_DICT_CUSTOM_FIELDDataTable GetCustomFieldDict();
        Dict.WIS_DICT_CUSTOM_FIELDDataTable GetTableDesc();
        Dict.WIS_DICT_CUSTOM_FIELDDataTable GetFieldDesc(string tableName);
        int UpdateCustomFieldDict(Dict.WIS_DICT_CUSTOM_FIELDDataTable dataTable);

        Dict.DictSimpleTypesDataTable GetDictSimpleTypes();
        Dict.DictSimpleTypesDataTable GetDictSimpleTypes(string typeKey);
        int UpdateDictSimpleTypes(Dict.DictSimpleTypesDataTable dataTable);

        Dict.DictSimpleTypesTreeDataTable GetDictSimpleTypesTree();
        int UpdateDictSimpleTypesTree(Dict.DictSimpleTypesTreeDataTable dataTable);
        int InsertDictSimpleTypesTree(string parentKey, string childKey);
        int ModifyDictSimpleTypesTreeParent(string parentKey, string oldChildKey, string newChildKey);
        int ModifyDictSimpleTypesTreeChild(string childKey, string oldParentKey, string newParentKey);

        Dict.DocumentTempletDataTable GetDocumentTemplet();
        Dict.DocumentTempletDataTable GetDocumentTemplet(string userID, decimal isPrivate, decimal eventNo);
        Dict.DocumentTempletDataTable GetDocumentTemplet(string userID, string documentName, decimal eventNo);
        Dict.DocumentTempletDataTable GetDocumentTemplet(string userID, decimal isPrivate, string documentName, decimal eventNo);
        Dict.DocumentTempletDataTable GetDocumentTemplet(string userID, decimal isPrivate, string documentName, decimal isJuBu, decimal eventNo);
        Dict.DocumentTempletDataTable GetDocumentTempletByClassName(string userID, decimal isPrivate, string className, string documentName, decimal eventNo);
        Dict.DocumentTempletDataTable GetDocumentTempletByClassName(string userID, decimal isPrivate, string className, string documentName, decimal isJuBu, decimal eventNo);
        Dict.DocumentTempletDataTable GetDocumentTempletPrivateAndPublic(string userID, decimal eventNo);
        Dict.DocumentTempletDataTable GetDocumentTempletPrivateAndPublic(string userID, string documentName, decimal eventNo);
        Dict.DocumentTempletDataTable GetDocumentTempletPrivateAndPublic(string userID, string documentName, decimal isJuBu, decimal eventNo);
        Dict.DocumentTempletDataTable GetDocumentTempletPrivateAndPublicByClassName(string userID, string className, string documentName, decimal eventNo);
        Dict.DocumentTempletDataTable GetDocumentTempletPrivateAndPublicByClassName(string userID, string className, string documentName, decimal isJuBu, decimal eventNo);
        int DeleteDocumentTempletByTempletGuid(string templetGuid);
        int UpdateDocumentTemplet(Dict.DocumentTempletDataTable dataTable);

        /// <summary>
        /// 获取监测配置表
        /// </summary>
        /// <returns>监测配置表</returns>
        Dict.MonitorFunctionCodeDataTable GetMonitorFunctionCode();
        Dict.OperatingRoomDataTable GetOperatingRoomDict();
        Dict.OperatingRoomDataTable GetOperatingRoomDict(decimal bedType);
        int UpdateOperatingRoomDict(Dict.OperatingRoomDataTable dataTable);

        Dict.BloodGasDictDataTable GetBloodGasDict();
        Dict.BloodGasDictDataTable GetBloodGasDict(string blgStatus);
        DataTable GetBlgGasDictPartial(string blgStaus);
        int UpdateBloodGasDict(Dict.BloodGasDictDataTable dataTable);

        Dict.HospitalConfigDataTable GetHospitalConfig();
        int UpdateHospitalConfig(Dict.HospitalConfigDataTable dataTable);
        string GetHospitalName();
        string GetHospitalID();
        int GetMaxDicUserId();

        Dict.HisUserDataTable GetUserIDByUserName(string userName);

        string GetInputDictByItemClassAndCode(string item_class, string item_code);

        Dict.WisPatMonitorDataDictDataTable GetPatMonitorDataDict();
        int UpdatePatMonitorDataDict(Dict.WisPatMonitorDataDictDataTable dataTable);


        /*付费配置字典*/
        Dict.WIS_DICT_BILL_CONFIGDataTable GetBillCfgDict();
        int UpdateBillCfgDict(Dict.WIS_DICT_BILL_CONFIGDataTable dt);
        Dict.OperationBillItemsDataTable GetOperationBillItems();
        Dict.OperationBillItemsDataTable GetOperationBillItems(string patientID, decimal visitID, decimal operID);
        int UpdateOperationBillItems(Dict.OperationBillItemsDataTable dt);
    }
}
