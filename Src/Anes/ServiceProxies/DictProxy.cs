using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Interface;
using System.Data;
using Wis.Anes.BusinessComponent;

namespace Wis.Anes.ServiceProxies
{
    public class DictProxy
    {
        static IDict _iDict = new DictBC();
        /// <summary>
        /// 返回手术名称字典信息
        /// </summary>
        /// <returns></returns>
        public static Dict.OperationDictDataTable GetOperationDict()
        {
            try
            {
                return _iDict.GetOperationDict();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static int UpdateOperationDict(Dict.OperationDictDataTable dataTable)
        {
            try
            {
                return _iDict.UpdateOperationDict(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static Dict.DeptInfoDictDataTable GetDeptInfo()
        {
            try
            {
                return _iDict.GetDeptInfo();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static int UpdateDeptInfo(Dict.DeptInfoDictDataTable dataTable)
        {
            try
            {
                return _iDict.UpdateDeptInfo(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static Dict.PriceListDataTable GetPriceList()
        {
            try
            {
                return _iDict.GetPriceList();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static Dict.PriceListDataTable GetPriceList(string itemClass)
        {
            try
            {
                return _iDict.GetPriceList(itemClass);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static int UpdatePriceList(Dict.PriceListDataTable dataTable)
        {
            try
            {
                return _iDict.UpdatePriceList(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }



        /// <summary>
        /// 获取麻醉输入项目字典信息记录
        /// </summary>        
        /// <returns>麻醉输入项目字典信息记录</returns>
        public static Dict.AnesthesiaInputDictDataTable GetAnesthesiaInputDict()
        {
            try
            {
                return _iDict.GetAnesthesiaInputDict();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }
        /// <summary>
        /// 返回诊断字典信息
        /// </summary>
        /// <returns>诊断字典信息</returns>
        public static Dict.WisDiagnosisDictDataTable GetDiagnosisDict()
        {
            try
            {
                return _iDict.GetDiagnosisDict();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        /// <summary>
        /// 返回常用术语字典信息
        /// </summary>
        /// <param name="item_class">类别</param>
        /// <returns>常用术语字典信息</returns>
        /// 
        public static Dict.AnesthesiaInputDictDataTable GetDict(string item_class)
        {
            try
            {
                return _iDict.GetDictTable(item_class);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static string GetInputDictByItemClassAndCode(string item_class, string item_code)
        {
            return _iDict.GetInputDictByItemClassAndCode(item_class,item_code);
        }
        /// <summary>
        /// 更新常用术语字典信息
        /// </summary>
        /// <param name="InputDatable"></param>
        /// <returns>常用术语字典信息</returns>
        public static int UpdateAnesthesiaDictDT(Dict.AnesthesiaInputDictDataTable InputDatable)
        {
            try
            {
                return _iDict.UpdateAnesthesiaDictDT(InputDatable);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        /// <summary>
        /// 更新麻醉事件字典信息
        /// </summary>
        /// <param name="EventOpenTable"></param>
        /// <returns></returns>
        public static int UpdateAnesthesiaEventOpen(Dict.AnesthesiaEventOpenDataTable EventOpenTable)
        {
            try
            {
                return _iDict.UpdateAnesthesiaEventOpen(EventOpenTable);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        /// <summary>
        /// 返回麻醉事件字典信息
        /// </summary>
        /// <param name="item_class">事件类别</param>
        /// <returns>麻醉事件字典信息</returns>
        public static Dict.AnesthesiaEventOpenDataTable GetAnesthesiaEventOpen(string item_class)
        {
            try
            {
                return _iDict.GetAnesthesiaEventOpen(item_class);
            }
            catch (Exception ex)
            {

                throw ex;
                
            }
        }

        /// <summary>
        /// 返回所有麻醉事件字典信息
        /// </summary>
        /// <returns></returns>
        public static Dict.AnesthesiaEventOpenDataTable GetAnesthesiaEventOpen()
        {
            try
            {
                return _iDict.GetAnesthesiaEventOpen();

            }
            catch (Exception ex)
            {

                throw ex;
                
            }
        }

        /// <summary>
        /// 返回麻醉方法字典信息
        /// </summary>
        /// <returns></returns>
        public static Dict.AnessthestaDictDataTable GetAnesDict()
        {
            try
            {
                return _iDict.GetAnesDict();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        /// <summary>
        /// 更新麻醉方法字典信息
        /// </summary>
        /// <param name="DictTable"></param>
        /// <returns></returns>
        public static int UpdateDict(Dict.AnessthestaDictDataTable DictTable)
        {
            try
            {
                return _iDict.UpdateAnesDict(DictTable);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        /// <summary>
        /// 返回手术间字典信息
        /// </summary>
        /// <returns></returns>
        public static Dict.OperatingRoomDataTable GetOperatingRoomDict()
        {
            try
            {
                return _iDict.GetOperatingRoomDict();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static Dict.OperatingRoomDataTable GetOperatingRoomDict(decimal bedType)
        {
            try
            {
                return _iDict.GetOperatingRoomDict(bedType);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        /// <summary>
        /// 更新手术间字典信息
        /// </summary>
        /// <param name="DictTable"></param>
        /// <returns></returns>
        public static int UpdateOperatingRoomDict(Dict.OperatingRoomDataTable DictTable)
        {
            try
            {
                return _iDict.UpdateOperatingRoomDict(DictTable);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static int UpdateDiagnosisDict(Dict.WisDiagnosisDictDataTable dataTable)
        {
            try
            {
                return _iDict.UpdateDiagnosisDict(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据条件返回 吸入麻药,局部麻药,静脉麻药
        /// </summary>
        /// <param name="item_class"></param>
        /// <param name="EVENT_ATTR_2">1为吸入,2为局部,3为静脉</param>
        /// <returns></returns>
        public static Dict.AnesthesiaEventOpenDataTable GetAnesthesiaEventOpen(string item_class, string EVENT_ATTR_2)
        {
            try
            {
                return _iDict.GetAnesthesiaEventOpen(item_class, EVENT_ATTR_2);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        /// <summary>
        /// 根据条件查找呼吸
        /// </summary>
        /// <returns></returns>
        public static Dict.AnesthesiaEventOpenDataTable GetAnesthesiaEventOpenByhuxi()
        {
            try
            {
                return _iDict.GetAnesthesiaEventOpenByhuxi();
            }
            catch (Exception ex)
            {
                throw ex;

                
            }
        }

        /// <summary>
        /// 获得HisUsers信息
        /// </summary>
        /// <returns></returns>
        public static Dict.HisUserDataTable GetHisUsers(string USER_JOB)
        {
            try
            {
                return _iDict.GetHisUsers(USER_JOB);
            }
            catch (Exception ex)
            {

                throw ex;
                
            }

        }
        /// <summary>
        /// 获取HIS表里的最大USER_ID值 
        /// </summary>
        /// <returns></returns>
        public static int GetMaxHisUserId()
        {

            try
            {
                return _iDict.GetMaxDicUserId();
            }
            catch (Exception ex)
            {

                throw ex;
                
            }
        }
        /// <summary>
        /// 获得HisUsers信息
        /// </summary>
        /// <returns></returns>
        public static Dict.HisUserDataTable GetHisUsers()
        {
            try
            {
                return _iDict.GetHisUsers();
            }
            catch (Exception ex)
            {

                throw ex;
                
            }

        }

        /// <summary>
        /// 获取医生姓名
        /// </summary>
        /// <returns></returns>
        public static Dict.HisUserDataTable GetDoctor()
        {
            try
            {
                return _iDict.GetDoctor();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        /// <summary>
        /// 获得护士姓名
        /// </summary>
        /// <returns></returns>
        public static Dict.HisUserDataTable GetNurse()
        {
            try
            {
                return _iDict.GetNurse();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        /// <summary>
        /// 更新HisUsers
        /// </summary>
        /// <param name="HisUsersTable"></param>
        /// <returns></returns>
        public static int UpdateHisUsers(Dict.HisUserDataTable hisuserDT)
        {
            try
            {
                return _iDict.UpdateHisUsers(hisuserDT);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static Dict.MonitorDictDataTable GetMonitorDict()
        {
            try
            {
                return _iDict.GetMonitorDict();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static Dict.MonitorDictDataTable GetMonitorDict(decimal wardType)
        {
            try
            {
                return _iDict.GetMonitorDict(wardType);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static Dict.MonitorDictDataTable GetMonitorDict(string itemType, decimal wardType)
        {
            try
            {
                return _iDict.GetMonitorDict(itemType, wardType);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static int UpdateMonitorDict(Dict.MonitorDictDataTable dateTable)
        {
            try
            {
                return _iDict.UpdateMonitorDict(dateTable);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static Dict.AnesthesiaEventTempletDataTable GetAnesthesiaEventTemplet()
        {
            try
            {
                return _iDict.GetAnesthesiaEventTemplet();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static Dict.AnesthesiaEventTempletDataTable GetAnesthesiaEventTemplet(string templetName)
        {
            try
            {
                return _iDict.GetAnesthesiaEventTemplet(templetName);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static int UpdateAnesthesiaEventTemplet(Dict.AnesthesiaEventTempletDataTable dateTable)
        {
            try
            {
                return _iDict.UpdateAnesthesiaEventTemplet(dateTable);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        /// <summary>
        /// 获取科室字典列表
        /// </summary>
        /// <returns>科室字典列表</returns>
        public static Dict.DeptDictDataTable GetDeptDict()
        {
            try
            {
                return _iDict.GetDeptDict();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static Dict.DeptDictDataTable GetDeptDict(string deptCode)
        {
            try
            {
                return _iDict.GetDeptDict(deptCode);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

 

        public static Dict.CustomDataExtDataTable GetCustomDataExt()
        {
            try
            {
                return _iDict.GetCustomDataExt();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static Dict.CustomDataExtDataTable GetCustomDataExt(string patientID, decimal visitID, decimal operID)
        {
            try
            {
                return _iDict.GetCustomDataExt(patientID, visitID, operID);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static int UpdateCustomDataExt(Dict.CustomDataExtDataTable dataTable)
        {
            try
            {
                return _iDict.UpdateCustomDataExt(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static void SaveCustomDataExtRow(Dict.CustomDataExtDataTable dataTable, string patientID, int visitID, int operID, string itemName, byte[] itemValue)
        {
            Dict.CustomDataExtRow row1 = dataTable.FindByPAT_IDVISIT_IDOPER_IDITEM_NAME(patientID, visitID, operID, itemName);
            if (row1 == null)
            {
                AddCustomDataExtRow(dataTable, patientID, visitID, operID, itemName, itemValue);
            }
            else
            {
                row1.ITEM_VALUE = itemValue;
            }
        }

        public static Dict.CustomDataExtRow AddCustomDataExtRow(Dict.CustomDataExtDataTable dataTable, string patientID, int visitID, int operID, string itemName, byte[] itemValue)
        {
            Dict.CustomDataExtRow row = dataTable.NewCustomDataExtRow();
            row.PAT_ID = patientID;
            row.VISIT_ID = visitID;
            row.OPER_ID = operID;
            row.ITEM_NAME = itemName;
            row.ITEM_VALUE = itemValue;
            dataTable.AddCustomDataExtRow(row);
            return row;
        }

        public static Dict.WIS_DICT_CUSTOM_FIELDDataTable GetCustomFieldDict()
        {
            try
            {

                return _iDict.GetCustomFieldDict();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static Dict.WIS_DICT_CUSTOM_FIELDDataTable GetTableDesc()
        {
            try
            {
                return _iDict.GetTableDesc();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static Dict.WIS_DICT_CUSTOM_FIELDDataTable GetFieldDesc(string tableName)
        {
            try
            {
                return _iDict.GetFieldDesc(tableName);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static int UpdateCustomFieldDict(Dict.WIS_DICT_CUSTOM_FIELDDataTable dataTable)
        {
            try
            {
                return _iDict.UpdateCustomFieldDict(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static void AddCustomFieldDictRow(Dict.WIS_DICT_CUSTOM_FIELDDataTable dataTable, string fieldName) { AddCustomFieldDictRow(dataTable, fieldName, "", ""); }
        public static void AddCustomFieldDictRow(Dict.WIS_DICT_CUSTOM_FIELDDataTable dataTable, string fieldName, string fieldType, string fieldDesc)
        {
            Dict.WIS_DICT_CUSTOM_FIELDRow row = dataTable.NewWIS_DICT_CUSTOM_FIELDRow();
            row.FIELD_NAME = fieldName;
            row.FIELD_TYPE = fieldType;
            row.FIELD_DESC = fieldDesc;
            dataTable.AddWIS_DICT_CUSTOM_FIELDRow(row);
        }

        public static Dict.DictSimpleTypesDataTable GetDictSimpleTypes()
        {
            try
            {
                return _iDict.GetDictSimpleTypes();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static Dict.DictSimpleTypesDataTable GetDictSimpleTypes(string typeKey)
        {
            try
            {
                return _iDict.GetDictSimpleTypes(typeKey);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static int UpdateDictSimpleTypes(Dict.DictSimpleTypesDataTable dataTable)
        {
            try
            {
                return _iDict.UpdateDictSimpleTypes(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static Dict.DictSimpleTypesTreeDataTable GetDictSimpleTypesTree()
        {
            try
            {
                return _iDict.GetDictSimpleTypesTree();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static int UpdateDictSimpleTypesTree(Dict.DictSimpleTypesTreeDataTable dataTable)
        {
            try
            {
                return _iDict.UpdateDictSimpleTypesTree(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static int InsertDictSimpleTypesTree(string parentKey, string childKey)
        {
            try
            {
                return _iDict.InsertDictSimpleTypesTree(parentKey, childKey);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static int ModifyDictSimpleTypesTreeParent(string parentKey, string oldChildKey, string newChildKey)
        {
            try
            {
                return _iDict.ModifyDictSimpleTypesTreeParent(parentKey, oldChildKey, newChildKey);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static int ModifyDictSimpleTypesTreeChild(string childKey, string oldParentKey, string newParentKey)
        {
            try
            {
                return _iDict.ModifyDictSimpleTypesTreeChild(childKey, oldParentKey, newParentKey);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }


        public static Dict.DocumentTempletDataTable GetDocumentTemplet()
        {
            try
            {
                return _iDict.GetDocumentTemplet();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }
        public static Dict.DocumentTempletDataTable GetDocumentTemplet(string userID, decimal isPrivate, decimal eventNo)
        {
            try
            {
                return _iDict.GetDocumentTemplet(userID, isPrivate, eventNo);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }
        public static Dict.DocumentTempletDataTable GetDocumentTemplet(string userID, string documentName, decimal eventNo)
        {
            try
            {
                return _iDict.GetDocumentTemplet(userID, documentName, eventNo);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }
        public static Dict.DocumentTempletDataTable GetDocumentTemplet(string userID, decimal isPrivate, string documentName, decimal eventNo)
        {
            try
            {
                return _iDict.GetDocumentTemplet(userID, isPrivate, documentName, eventNo);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }
        public static Dict.DocumentTempletDataTable GetDocumentTemplet(string userID, decimal isPrivate, string documentName, decimal isJuBu, decimal eventNo)
        {
            try
            {
                return _iDict.GetDocumentTemplet(userID, isPrivate, documentName, isJuBu, eventNo);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }
        public static int UpdateDocumentTemplet(Dict.DocumentTempletDataTable dataTable)
        {
            try
            {
                return _iDict.UpdateDocumentTemplet(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }
        public static Dict.DocumentTempletDataTable GetDocumentTempletByClassName(string userID, decimal isPrivate, string className, string documentName, decimal eventNo)
        {
            try
            {
                return _iDict.GetDocumentTempletByClassName(userID, isPrivate, className, documentName, eventNo);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }
        public static Dict.DocumentTempletDataTable GetDocumentTempletByClassName(string userID, decimal isPrivate, string className, string documentName, decimal isJuBu, decimal eventNo)
        {
            try
            {
                return _iDict.GetDocumentTempletByClassName(userID, isPrivate, className, documentName, isJuBu, eventNo);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static Dict.DocumentTempletDataTable GetDocumentTempletPrivateAndPublic(string userID, decimal eventNo)
        {
            try
            {
                return _iDict.GetDocumentTempletPrivateAndPublic(userID, eventNo);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }
        public static Dict.DocumentTempletDataTable GetDocumentTempletPrivateAndPublic(string userID, string documentName, decimal eventNo)
        {
            try
            {
                return _iDict.GetDocumentTempletPrivateAndPublic(userID, documentName, eventNo);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }
        public static Dict.DocumentTempletDataTable GetDocumentTempletPrivateAndPublic(string userID, string documentName, decimal isJuBu, decimal eventNo)
        {
            try
            {
                return _iDict.GetDocumentTempletPrivateAndPublic(userID, documentName, isJuBu, eventNo);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }
        public static Dict.DocumentTempletDataTable GetDocumentTempletPrivateAndPublicByClassName(string userID, string className, string documentName, decimal eventNo)
        {
            try
            {
                return _iDict.GetDocumentTempletPrivateAndPublicByClassName(userID, className, documentName, eventNo);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }
        public static Dict.DocumentTempletDataTable GetDocumentTempletPrivateAndPublicByClassName(string userID, string className, string documentName, decimal isJuBu, decimal eventNo)
        {
            try
            {
                return _iDict.GetDocumentTempletPrivateAndPublicByClassName(userID, className, documentName, isJuBu, eventNo);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }
        public static int DeleteDocumentTempletByTempletGuid(string templetGuid)
        {
            try
            {
                return _iDict.DeleteDocumentTempletByTempletGuid(templetGuid);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static Dict.MonitorFunctionCodeDataTable GetMonitorFunctionCode()
        {
            try
            {
                return _iDict.GetMonitorFunctionCode();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static Dict.BloodGasDictDataTable GetBloodGasDict()
        {
            try
            {
                return _iDict.GetBloodGasDict();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static Dict.BloodGasDictDataTable GetBloodGasDict(string blgStatus)
        {
            try
            {
                return _iDict.GetBloodGasDict(blgStatus);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static DataTable GetBlgGasDictPartial(string blgStatus)
        {
            try
            {
                return _iDict.GetBlgGasDictPartial(blgStatus);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static int UpdateBloodGasDict(Dict.BloodGasDictDataTable dataTable)
        {
            try
            {
                return _iDict.UpdateBloodGasDict(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static Dict.HospitalConfigDataTable GetHospitalConfig()
        {
            try
            {
                return _iDict.GetHospitalConfig();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static Dict.HisUserDataTable GetUserIDByUserName(string userName)
        {
            try
            {
                return _iDict.GetUserIDByUserName(userName);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static int UpdateHospitalConfig(Dict.HospitalConfigDataTable dataTable)
        {
            try
            {
                return _iDict.UpdateHospitalConfig(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static string GetHospitalName()
        {
            try
            {
                return _iDict.GetHospitalName();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string GetHospitalID()
        {
            try
            {
                return _iDict.GetHospitalName();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 清除监护设备对应患者
        /// </summary>
        /// <param name="wardType">科室类别（代表麻醉或者PACU）</param>
        /// <param name="wardCode">手术科室</param>
        /// <param name="roomNo">手术间号</param>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns>是否清除成功</returns>
        public static bool ClearMonitorDictPatient(decimal wardType, string wardCode, string roomNo, string patientID, decimal visitID, decimal operID)
        {
            if (!string.IsNullOrEmpty(wardCode) && !string.IsNullOrEmpty(roomNo) && !string.IsNullOrEmpty(patientID))
            {
                Dict.MonitorDictDataTable monitorTable = GetMonitorDict(wardType);
                if (monitorTable != null)
                {
                    foreach (Dict.MonitorDictRow row in monitorTable)
                    {
                        if (!row.IsWARD_CODENull() && !row.IsBED_NONull() && !row.IsPAT_IDNull() && !row.IsVISIT_IDNull() && !row.IsOPER_IDNull()
                            && row.WARD_CODE.Equals(wardCode) && row.BED_NO.Equals(roomNo) && row.PAT_ID.Equals(patientID) && row.VISIT_ID.Equals(visitID)
                            && row.OPER_ID.Equals(operID))
                        {
                            row.SetPAT_IDNull();
                            row.SetVISIT_IDNull();
                            row.SetOPER_IDNull();
                        }
                    }
                    int ret = UpdateMonitorDict(monitorTable);
                    if (ret > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 设置监护设备对应患者
        /// </summary>
        /// <param name="wardType">科室类别（代表麻醉或者PACU）</param>
        /// <param name="wardCode">手术科室</param>
        /// <param name="roomNo">手术间号</param>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns>是否设置成功</returns>
        public static bool SetMonitorDictPatient(decimal wardType, string wardCode, string roomNo, string patientID, decimal visitID, decimal operID)
        {
            if (!string.IsNullOrEmpty(wardCode) && !string.IsNullOrEmpty(roomNo) && !string.IsNullOrEmpty(patientID))
            {
                Dict.MonitorDictDataTable monitorTable = GetMonitorDict(wardType);
                if (monitorTable != null)
                {
                    foreach (Dict.MonitorDictRow row in monitorTable)
                    {
                        if (!row.IsWARD_CODENull() && !row.IsBED_NONull() && row.WARD_CODE.Equals(wardCode) && row.BED_NO.Equals(roomNo))
                        {
                            row.PAT_ID = patientID;
                            row.VISIT_ID = visitID;
                            row.OPER_ID = operID;
                        }
                    }
                    int ret = UpdateMonitorDict(monitorTable);
                    if (ret > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 获取患者手术间号
        /// </summary>
        /// <param name="operatingRoomDataTable">手术间表</param>
        /// <param name="roomNo">手时间号</param>
        /// <param name="wardCode">手术科室</param>
        private static string GetOperatingRoomNo(Dict.OperatingRoomDataTable operatingRoomDataTable, string patientID, decimal visitID, decimal operID)
        {
            if (operatingRoomDataTable != null && !string.IsNullOrEmpty(patientID))
            {
                foreach (Dict.OperatingRoomRow row in operatingRoomDataTable)
                {
                    if (!row.IsPAT_IDNull() && !row.IsVISIT_IDNull() && !row.IsOPER_IDNull() && row.PAT_ID.Equals(patientID)
                        && row.VISIT_ID.Equals(visitID) && row.OPER_ID.Equals(operID))
                    {
                        return row.ROOM_NO;
                    }
                }
            }
            return "";
        }

        /// <summary>
        /// 设置手术间患者
        /// </summary>
        /// <param name="operatingRoomDataTable">手术间表</param>
        /// <param name="roomNo">手时间号</param>
        /// <param name="wardCode">手术科室</param>
        public static void SetOperatingRoomPatient(Dict.OperatingRoomDataTable operatingRoomDataTable, string roomNo, string wardCode, string patientID, decimal visitID, decimal operID)
        {
            Dict.OperatingRoomRow row = operatingRoomDataTable.FindByROOM_NODEPT_CODE(roomNo, wardCode);
            if (row != null)
            {
                row.PAT_ID = patientID;
                row.VISIT_ID = visitID;
                row.OPER_ID = operID;
            }
        }

        /// <summary>
        /// 清除手术间患者
        /// </summary>
        /// <param name="operatingRoomDataTable">手术间表</param>
        /// <param name="roomNo">手时间号</param>
        /// <param name="wardCode">手术科室</param>
        public static void ClearOperatingRoomPatient(Dict.OperatingRoomDataTable operatingRoomDataTable, string roomNo, string wardCode)
        {
            Dict.OperatingRoomRow row = operatingRoomDataTable.FindByROOM_NODEPT_CODE(roomNo, wardCode);
            if (row != null)
            {
                row.SetPAT_IDNull();
                row.SetVISIT_IDNull();
                row.SetOPER_IDNull();
            }
        }
        public static Dict.WisPatMonitorDataDictDataTable GetPatMonitorDataDict()
        {
            try
            {
                return _iDict.GetPatMonitorDataDict();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int UpdatePatMonitorDataDict(Dict.WisPatMonitorDataDictDataTable dataTable)
        {
            try
            {
                return _iDict.UpdatePatMonitorDataDict(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static Dict.WIS_DICT_BILL_CONFIGDataTable GetBillCfgDict()
        {
            return _iDict.GetBillCfgDict();
        }

        public static int UpdateBillCfgDict(Dict.WIS_DICT_BILL_CONFIGDataTable dt)
        {
            return _iDict.UpdateBillCfgDict(dt);
        }

        /// <summary>
        /// 获得HisUsers信息
        /// </summary>
        /// <returns></returns>
        public static Dict.HisUserDataTable GetHisUsersDept(string USER_JOB)
        {
            try
            {
                return _iDict.GetHisUsersDept(USER_JOB);
            }
            catch (Exception ex)
            {

                throw ex;

            }

        }

        
    }
}
 