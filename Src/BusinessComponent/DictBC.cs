using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.Interface;
using Wis.Anes.DataAccess;
using Wis.Anes.BusinessEntity;
using System.Data;

namespace Wis.Anes.BusinessComponent
{
    public class DictBC : IDict
    {

        /// <summary>
        /// 返回手术名称字典信息
        /// </summary>
        /// <returns></returns>
        public Dict.OperationDictDataTable GetOperationDict()
        {
            return (new DictDA()).GetOperationDict();
        }

        public int UpdateOperationDict(Dict.OperationDictDataTable dateTable)
        {
            return (new DictDA()).UpdateOperationDict(dateTable);
        }
        public Dict.WIS_USER_ASA_GRADEDataTable GetAnesDocGradeDict()
        {
            return (new DictDA()).GetAnesDocGradeDict();
        }
        public Dict.DeptInfoDictDataTable GetDeptInfo()
        {
            return (new DictDA()).GetDeptInfo();
        }

        public int UpdateDeptInfo(Dict.DeptInfoDictDataTable dataTable)
        {
            return (new DictDA()).UpdateDeptInfo(dataTable);
        }

        public Dict.PriceListDataTable GetPriceList()
        {
            return (new DictDA()).GetPriceList();
        }

        public Dict.PriceListDataTable GetPriceList(string itemClass)
        {
            return (new DictDA()).GetPriceList(itemClass);
        }

        public int UpdatePriceList(Dict.PriceListDataTable dataTable)
        {
            return (new DictDA()).UpdatePriceList(dataTable);
        }

        public Dict.AnesthesiaEventTempletDataTable GetAnesthesiaEventTemplet()
        {
            return (new DictDA()).GetAnesthesiaEventTemplet();
        }
        public Dict.AnesthesiaEventTempletDataTable GetAnesthesiaEventTemplet(string templetName)
        {
            return (new DictDA()).GetAnesthesiaEventTemplet(templetName);
        }
        public int UpdateAnesthesiaEventTemplet(Dict.AnesthesiaEventTempletDataTable dateTable)
        {
            return (new DictDA()).UpdateAnesthesiaEventTemplet(dateTable);
        }

        public Dict.MonitorDictDataTable GetMonitorDict()
        {
            return (new DictDA()).GetMonitorDict();
        }

        public Dict.MonitorDictDataTable GetMonitorDict(decimal wardType)
        {
            return (new DictDA()).GetMonitorDict(wardType);
        }

        public Dict.MonitorDictDataTable GetMonitorDict(string itemType, decimal wardType)
        {
            return (new DictDA()).GetMonitorDict(itemType, wardType);
        }

        public int UpdateMonitorDict(Dict.MonitorDictDataTable dateTable)
        {
            return (new DictDA()).UpdateMonitorDict(dateTable);
        }

        /// <summary>
        /// 返回麻醉输入项目字典信息
        /// </summary>
        /// <returns>麻醉输入项目字典信息</returns>
        public Dict.AnesthesiaInputDictDataTable GetAnesthesiaInputDict()
        {
            return (new DictDA()).GetAnesthesiaInputDict();
        }
        /// <summary>
        /// 更新常用术语字典信息
        /// </summary>
        /// <param name="InputDateble"></param>
        /// <returns></returns>
        public int UpdateAnesthesiaDictDT(Dict.AnesthesiaInputDictDataTable InputDateble)
        {
            return (new DictDA()).UpdateAnesthesiaDictDT(InputDateble);
        }
        /// <summary>
        /// 返回诊断字典信息
        /// </summary>
        /// <returns>诊断字典信息</returns>
        public Dict.WisDiagnosisDictDataTable GetDiagnosisDict()
        {
            return (new DictDA()).GetDiagnosisDict();
        }
        /// <summary>
        /// 更新诊断信息字典
        /// </summary>
        /// <param name="DiagnosisDictDataTable"></param>
        /// <returns></returns>
        public int UpdateDiagnosisDict(Dict.WisDiagnosisDictDataTable DiagnosisDictDataTable)
        {
            return (new DictDA()).UpdateDiagnosisDict(DiagnosisDictDataTable);
        }
        /// <summary>
        /// 返回常用术语字典信息
        /// </summary>
        /// <param name="item_class">类别</param>
        /// <returns>常用术语字典信息</returns>
        public Dict.AnesthesiaInputDictDataTable GetDictTable(string item_class)
        {
            return (new DictDA()).GetDictTable(item_class);
        }
        /// <summary>
        /// 根据条件返回麻醉事件
        /// </summary>
        /// <param name="itemclass">条件</param>
        /// <returns></returns>
        public Dict.AnesthesiaEventOpenDataTable GetAnesthesiaEventOpen(string itemclass)
        {
            return (new DictDA()).GetAnesthesiaEventOpen(itemclass);
        }
        /// <summary>
        /// 更新麻醉事件字典信息
        /// </summary>
        /// <param name="EventOpenTable"></param>
        /// <returns></returns>
        public int UpdateAnesthesiaEventOpen(Dict.AnesthesiaEventOpenDataTable EventOpenTable)
        {
            return (new DictDA()).UpdateAnesthesiaEventOpen(EventOpenTable);
        }

        public Dict.AnesthesiaEventOpenDataTable GetAnesthesiaEventOpen()
        {
            return (new DictDA()).GetAnesthesiaEventOpen();
        }

        public int UpdateAnesDocGradeDict(Dict.WIS_USER_ASA_GRADEDataTable dataTable)
        {
            return (new DictDA()).UpdateAnesDocGradeDict(dataTable);
        }
        /// <summary>
        /// 返回麻醉方法字典信息
        /// </summary>
        /// <returns></returns>
        public Dict.AnessthestaDictDataTable GetAnesDict()
        {
            return (new DictDA()).GetAnesDict();
        }
        /// <summary>
        /// 更新麻醉方法字典信息
        /// </summary>
        /// <param name="dictTable"></param>
        /// <returns></returns>
        public int UpdateAnesDict(Dict.AnessthestaDictDataTable dictTable)
        {
            return (new DictDA()).UpdateAnesDict(dictTable);
        }

        /// <summary>
        /// 根据条件返回 吸入麻药,局部麻药,静脉麻药
        /// </summary>
        /// <param name="item_class"></param>
        /// <param name="EVENT_ATTR_2">1为吸入,2为局部,3为静脉</param>
        /// <returns></returns>
        public Dict.AnesthesiaEventOpenDataTable GetAnesthesiaEventOpen(string item_class, string EVENT_ATTR_2)
        {
            return (new DictDA()).GetAnesthesiaEventOpen(item_class, EVENT_ATTR_2);
        }

        /// <summary>
        /// 根据条件查找呼吸
        /// </summary>
        /// <returns></returns>
        public Dict.AnesthesiaEventOpenDataTable GetAnesthesiaEventOpenByhuxi()
        {
            return (new DictDA()).GetAnesthesiaEventOpenByhuxi();
        }

        /// <summary>
        /// 获得HisUsers信息
        /// </summary>
        /// <returns></returns>
        public Dict.HisUserDataTable GetHisUsers(string USER_JOB)
        {
            return (new DictDA()).GetHisUsers(USER_JOB);
        }
        
        public Dict.HisUserDataTable GetHisUsersDept(string USER_JOB)
        {
            return (new DictDA()).GetHisUsersDept(USER_JOB);
        }
        public Dict.HisUserDataTable GetHisUsers()
        {
            return (new DictDA()).GetHisUsers();
        }
        /// <summary>
        /// 获取医生姓名
        /// </summary>
        /// <returns></returns>
        public Dict.HisUserDataTable GetDoctor()
        {
            return (new DictDA()).GetDoctor();
        }
        /// <summary>
        /// 获得护士姓名
        /// </summary>
        /// <returns></returns>
        public Dict.HisUserDataTable GetNurse()
        {
            return (new DictDA()).GetNurse();
        }
        /// <summary>
        /// 更新HisUsers
        /// </summary>
        /// <param name="HisUsersTable"></param>
        /// <returns></returns>
        public int UpdateHisUsers(Dict.HisUserDataTable hisuserDT)
        {
            return (new DictDA()).UpdateHisUsers(hisuserDT);
        }

        /// <summary>
        /// 获取科室字典列表
        /// </summary>
        /// <returns></returns>
        public Dict.DeptDictDataTable GetDeptDict()
        {
            return (new DictDA()).GetDeptDict();
        }
        public Dict.DeptDictDataTable GetDeptDict(string deptCode)
        {
            return (new DictDA()).GetDeptDict(deptCode);
        }


        public Dict.CustomDataExtDataTable GetCustomDataExt()
        {
            return (new DictDA()).GetCustomDataExt();
        }

        public Dict.CustomDataExtDataTable GetCustomDataExt(string patientID, decimal visitID, decimal operID)
        {
            return (new DictDA()).GetCustomDataExt(patientID, visitID, operID);
        }

        public int UpdateCustomDataExt(Dict.CustomDataExtDataTable dataTable)
        {
            return (new DictDA()).UpdateCustomDataExt(dataTable);
        }

        public Dict.WIS_DICT_CUSTOM_FIELDDataTable GetCustomFieldDict()
        {
            return (new DictDA()).GetCustomFieldDict();
        }
        public Dict.WIS_DICT_CUSTOM_FIELDDataTable GetTableDesc()
        {
            return (new DictDA()).GetTableDesc();
        }
        public Dict.WIS_DICT_CUSTOM_FIELDDataTable GetFieldDesc(string tableName)
        {
            return (new DictDA()).GetFieldDesc(tableName);
        }
        public int UpdateCustomFieldDict(Dict.WIS_DICT_CUSTOM_FIELDDataTable dataTable)
        {
            return (new DictDA()).UpdateCustomFieldDict(dataTable);
        }
        public Dict.DictSimpleTypesDataTable GetDictSimpleTypes()
        {
            return (new DictDA()).GetDictSimpleTypes();
        }
        public Dict.DictSimpleTypesDataTable GetDictSimpleTypes(string typeKey)
        {
            return (new DictDA()).GetDictSimpleTypes(typeKey);
        }
        public int UpdateDictSimpleTypes(Dict.DictSimpleTypesDataTable dataTable)
        {
            return (new DictDA()).UpdateDictSimpleTypes(dataTable);
        }
        public Dict.DictSimpleTypesTreeDataTable GetDictSimpleTypesTree()
        {
            return (new DictDA()).GetDictSimpleTypesTree();
        }
        public int UpdateDictSimpleTypesTree(Dict.DictSimpleTypesTreeDataTable dataTable)
        {
            return (new DictDA()).UpdateDictSimpleTypesTree(dataTable);
        }
        public int InsertDictSimpleTypesTree(string parentKey, string childKey)
        {
            return (new DictDA()).InsertDictSimpleTypesTree(parentKey, childKey);
        }
        public int ModifyDictSimpleTypesTreeParent(string parentKey, string oldChildKey, string newChildKey)
        {
            return (new DictDA()).ModifyDictSimpleTypesTreeParent(parentKey, oldChildKey, newChildKey);
        }
        public int ModifyDictSimpleTypesTreeChild(string childKey, string oldParentKey, string newParentKey)
        {
            return (new DictDA()).ModifyDictSimpleTypesTreeChild(childKey, oldParentKey, newParentKey);
        }
        public Dict.DocumentTempletDataTable GetDocumentTemplet()
        {
            return (new DictDA()).GetDocumentTemplet();
        }
        public Dict.DocumentTempletDataTable GetDocumentTemplet(string userID, decimal isPrivate, decimal eventNo)
        {
            return (new DictDA()).GetDocumentTemplet(userID, isPrivate, eventNo);
        }
        public Dict.DocumentTempletDataTable GetDocumentTemplet(string userID, decimal isPrivate, string documentName, decimal eventNo)
        {
            return (new DictDA()).GetDocumentTemplet(userID, isPrivate, documentName, eventNo);
        }
        public Dict.DocumentTempletDataTable GetDocumentTemplet(string userID, string documentName, decimal eventNo)
        {
            return (new DictDA()).GetDocumentTemplet(userID, documentName, eventNo);
        }
        public Dict.DocumentTempletDataTable GetDocumentTemplet(string userID, decimal isPrivate, string documentName, decimal isJuBu, decimal eventNo)
        {
            return (new DictDA()).GetDocumentTemplet(userID, isPrivate, documentName, isJuBu, eventNo);
        }
        public int UpdateDocumentTemplet(Dict.DocumentTempletDataTable dataTable)
        {
            return (new DictDA()).UpdateDocumentTemplet(dataTable);
        }
        public Dict.DocumentTempletDataTable GetDocumentTempletByClassName(string userID, decimal isPrivate, string className, string documentName, decimal eventNo)
        {
            return (new DictDA()).GetDocumentTempletByClassName(userID, isPrivate, className, documentName, eventNo);
        }
        public Dict.DocumentTempletDataTable GetDocumentTempletByClassName(string userID, decimal isPrivate, string className, string documentName, decimal isJuBu, decimal eventNo)
        {
            return (new DictDA()).GetDocumentTempletByClassName(userID, isPrivate, className, documentName, isJuBu, eventNo);
        }
        public Dict.DocumentTempletDataTable GetDocumentTempletPrivateAndPublic(string userID, decimal eventNo)
        {
            return (new DictDA()).GetDocumentTempletPrivateAndPublic(userID, eventNo);
        }
        public Dict.DocumentTempletDataTable GetDocumentTempletPrivateAndPublic(string userID, string documentName, decimal eventNo)
        {
            return (new DictDA()).GetDocumentTempletPrivateAndPublic(userID, documentName, eventNo);
        }
        public Dict.DocumentTempletDataTable GetDocumentTempletPrivateAndPublic(string userID, string documentName, decimal isJuBu, decimal eventNo)
        {
            return (new DictDA()).GetDocumentTempletPrivateAndPublic(userID, documentName, isJuBu, eventNo);
        }
        public Dict.DocumentTempletDataTable GetDocumentTempletPrivateAndPublicByClassName(string userID, string className, string documentName, decimal eventNo)
        {
            return (new DictDA()).GetDocumentTempletPrivateAndPublicByClassName(userID, className, documentName, eventNo);
        }
        public Dict.DocumentTempletDataTable GetDocumentTempletPrivateAndPublicByClassName(string userID, string className, string documentName, decimal isJuBu, decimal eventNo)
        {
            return (new DictDA()).GetDocumentTempletPrivateAndPublicByClassName(userID, className, documentName, isJuBu, eventNo);
        }
        public int DeleteDocumentTempletByTempletGuid(string templetGuid)
        {
            return (new DictDA()).DeleteDocumentTempletByTempletGuid(templetGuid);
        }

        /// <summary>
        /// 获取监测配置表
        /// </summary>
        /// <returns>监测配置表</returns>
        public Dict.MonitorFunctionCodeDataTable GetMonitorFunctionCode()
        {
            return (new DictDA()).GetMonitorFunctionCode();
        }

        public Dict.OperatingRoomDataTable GetOperatingRoomDict()
        {
            return (new DictDA()).GetOperatingRoomDict();
        }
        public Dict.OperatingRoomDataTable GetOperatingRoomDict(decimal bedType)
        {
            return (new DictDA()).GetOperatingRoomDict(bedType);
        }
        public int UpdateOperatingRoomDict(Dict.OperatingRoomDataTable dataTable)
        {
            return (new DictDA()).UpdateOperatingRoomDict(dataTable);
        }
        public Dict.BloodGasDictDataTable GetBloodGasDict()
        {
            return (new DictDA()).GetBloodGasDict();
        }
        public Dict.BloodGasDictDataTable GetBloodGasDict(string blgStatus)
        {
            return (new DictDA()).GetBloodGasDict(blgStatus);
        }
        public DataTable GetBlgGasDictPartial(string blgStatus)
        {
            return (new DictDA()).GetBlgGasDictPartial(blgStatus);
        }
        public int UpdateBloodGasDict(Dict.BloodGasDictDataTable dataTable)
        {
            return (new DictDA()).UpdateBloodGasDict(dataTable);
        }

        public Dict.HospitalConfigDataTable GetHospitalConfig()
        {
            return (new DictDA()).GetHospitalConfig();
        }

        public int UpdateHospitalConfig(Dict.HospitalConfigDataTable dataTable)
        {
            return (new DictDA()).UpdateHospitalConfig(dataTable);
        }
        public string GetHospitalName()
        {
            return (new DictDA()).GetHospitalName();
        }
        public string GetHospitalID()
        {
            return (new DictDA()).GetHospitalID();
        }
        public int GetMaxDicUserId()
        {
            return (new DictDA()).GetMaxDicUserId();

        }
        public Dict.HisUserDataTable GetUserIDByUserName(string userName)
        {
            return (new DictDA()).GetUserIDByUserName(userName);
        }

        public string GetInputDictByItemClassAndCode(string item_class, string item_code)
        {
            Dict.AnesthesiaInputDictDataTable dictDataTable = GetDictTable(item_class);
            string res = item_code;
            bool isFind = false;
            if (dictDataTable != null && dictDataTable.Rows.Count >= 1)
            {
                foreach (Dict.AnesthesiaInputDictRow anesthesiaInputDictRow in dictDataTable)
                {
                    if (!anesthesiaInputDictRow.IsITEM_CODENull() && anesthesiaInputDictRow.ITEM_CODE == item_code)
                    {
                        res = anesthesiaInputDictRow.ITEM_NAME;
                        isFind = true;
                        break;
                    }
                }
            }
            if (!isFind)
            {
                res = item_code;
            }
            return res;
        }
        public Dict.WisPatMonitorDataDictDataTable GetPatMonitorDataDict()
        {
            return (new DictDA()).GetPatMonitorDataDict();
        }
        public int UpdatePatMonitorDataDict(Dict.WisPatMonitorDataDictDataTable dataTable)
        {
            return (new DictDA()).UpdatePatMonitorDataDict(dataTable);
        }


        public Dict.WIS_DICT_BILL_CONFIGDataTable GetBillCfgDict()
        {
            return (new DictDA()).GetBillCfgDict(); 
        } 
        
        public int UpdateBillCfgDict(Dict.WIS_DICT_BILL_CONFIGDataTable dt)
        {
            return (new DictDA()).UpdateBillCfgDict(dt);
        }

        public Dict.OperationBillItemsDataTable GetOperationBillItems()
        {
            return (new DictDA()).GetOperationBillItems();
        }

        public Dict.OperationBillItemsDataTable GetOperationBillItems(string patientID, decimal visitID, decimal operID)
        {
            return (new DictDA()).GetOperationBillItems(patientID,visitID,operID);
        }

        public int UpdateOperationBillItems(Dict.OperationBillItemsDataTable dt)
        {
            return (new DictDA()).UpdateOperationBillItems(dt);
        }
    }
}
