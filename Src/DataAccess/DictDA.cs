/*----------------------------------------------------------------
 // Copyright (C) 2007 北京拓扑工厂科技发展有限公司
 // 文件名：Dict.cs
 // 文件功能描述：
 //     字典业务处理类 //
 // 修改标识：
 // 修改描述：
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Data;
using System.Data.Common;
using System.Data;

namespace Wis.Anes.DataAccess
{
    /// <summary>
    /// 字典业务处理类
    /// </summary>
    public partial class DictDA
    {

        public Dict.DeptInfoDictDataTable GetDeptInfo()
        {
            Dict.DeptInfoDictDataTable data = new Dict.DeptInfoDictDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("Dict_GetDeptInfo");

            database.Fill(sql, data);
            return data;
            // return GetData<Dict.DeptInfoDictDataTable>(GetSQL("DeptInfoDict"));
            //return new DeptInfoDictAdapter().GetData();
        }
        public Dict.WIS_USER_ASA_GRADEDataTable GetAnesDocGradeDict()
        {
            string SQL = "SELECT * FROM WIS_USER_ASA_GRADE ORDER BY USER_NAME";
            Dict.WIS_USER_ASA_GRADEDataTable dt = new Dict.WIS_USER_ASA_GRADEDataTable();
            DatabaseFactory.Create().Fill(SQL, dt);
            return dt;
        }
        public int UpdateDeptInfo(Dict.DeptInfoDictDataTable dataTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dataTable, "WIS_DICT_DEPT_INFO");

            // return UpdateData<Dict.DeptInfoDictDataTable>(dataTable,GetSQL("DeptInfoDict"));
            //return new DeptInfoDictAdapter().Update(dataTable);
        }

        public Dict.PriceListDataTable GetPriceList()
        {
            Dict.PriceListDataTable data = new Dict.PriceListDataTable();

            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Dict_GetPriceList");
            database.Fill(sql, data);
            return data;
            //return GetData<Dict.PriceListDataTable>(GetSQL("PriceList"));
            //return new PriceListAdapter().GetData();
        }

        public Dict.PriceListDataTable GetPriceList(string itemClass)
        {
            Dict.PriceListDataTable data = new Dict.PriceListDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Dict_GetPriceListByItemClass");
            DbParameter itemClassParameter = database.BuildDbParameter("itemClass", DbType.String, itemClass);
            database.Fill(sql, data, new DbParameter[] { itemClassParameter });
            return data;
            //return GetData<Dict.PriceListDataTable>(GetSQL("PriceListByItemClass"),new object[]{itemClass});
            //return new PriceListAdapter().GetDataByItemClass(itemClass);
        }

        public int UpdatePriceList(Dict.PriceListDataTable dataTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dataTable, "WIS_PRICE_LIST");
            // return UpdateData<Dict.PriceListDataTable>(dataTable, GetSQL("PriceList"));
            //return new PriceListAdapter().Update(dataTable);
        }

        public Dict.AnesthesiaEventTempletDataTable GetAnesthesiaEventTemplet()
        {
            Dict.AnesthesiaEventTempletDataTable data = new Dict.AnesthesiaEventTempletDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Dict_GetAnesthesiaEventTemplet");
            database.Fill(sql, data);
            return data;
            // return GetData<Dict.AnesthesiaEventTempletDataTable>(GetSQL("AnesthesiaEventTemplet"));
            //return new AnesthesiaEventTempletAdapter().GetData();
        }
        public Dict.AnesthesiaEventTempletDataTable GetAnesthesiaEventTemplet(string templetName)
        {
            Dict.AnesthesiaEventTempletDataTable data = new Dict.AnesthesiaEventTempletDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Dict_GetAnesthesiaEventTempletByTempletName");
            DbParameter templetNameParameter = database.BuildDbParameter("TempletName", DbType.String, templetName);
            database.Fill(sql, data, new DbParameter[] { templetNameParameter });
            return data;
            // return GetData<Dict.AnesthesiaEventTempletDataTable>(GetSQL("AnesthesiaEventTempletByTempletName"), new object[] { templetName });
            //return new AnesthesiaEventTempletAdapter().GetDataByTempletName(templetName);
        }
        public int UpdateAnesthesiaEventTemplet(Dict.AnesthesiaEventTempletDataTable dateTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dateTable, "WIS_ANES_EVENT_TEMPLET");
            // return UpdateData<Dict.AnesthesiaEventTempletDataTable>(dateTable,GetSQL("AnesthesiaEventTemplet"));
            //return new AnesthesiaEventTempletAdapter().Update(dateTable);
        }

        public Dict.MonitorDictDataTable GetMonitorDict()
        {
            Dict.MonitorDictDataTable data = new Dict.MonitorDictDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Dict_GetMonitorDictAll");
            database.Fill(sql, data);
            return data;
        }
        public int UpdateAnesDocGradeDict(Dict.WIS_USER_ASA_GRADEDataTable dataTable)
        {
            return DatabaseFactory.Create().Update(dataTable, "WIS_USER_ASA_GRADE");
        }
        public Dict.MonitorDictDataTable GetMonitorDict(decimal wardType)
        {
            Dict.MonitorDictDataTable data = new Dict.MonitorDictDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Dict_GetMonitorDict");
            DbParameter wardtypeParameter = database.BuildDbParameter("wardType", DbType.Decimal, wardType);
            database.Fill(sql, data, new DbParameter[] { wardtypeParameter });
            return data;
            // return GetData<Dict.MonitorDictDataTable>(GetSQL("MonitorDict"),new object[]{eventNo});
            //return new DictTableAdapters.MonitorDictAdapter().GetData();
        }

        public Dict.MonitorDictDataTable GetMonitorDict(string itemType, decimal wardType)
        {
            Dict.MonitorDictDataTable data = new Dict.MonitorDictDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Dict_GetMonitorDictByItemType");
            DbParameter itemtypeParameter = database.BuildDbParameter("itemType", DbType.String, itemType);
            DbParameter wardtypeParameter = database.BuildDbParameter("wardType", DbType.Decimal, wardType);
            database.Fill(sql, data, new DbParameter[] { itemtypeParameter, wardtypeParameter });
            return data;
        }

        public int UpdateMonitorDict(Dict.MonitorDictDataTable dateTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dateTable, "WIS_DICT_MONITOR");
            // return UpdateData<Dict.MonitorDictDataTable>(dateTable, "select * from WIS_DICT_MONITOR");
            //return UpdateData<Dict.MonitorDictDataTable>(dateTable,GetSQL("MonitorDict"));
            //return new DictTableAdapters.MonitorDictAdapter().Update(dateTable);
        }

        /// <summary>
        /// 返回麻醉输入项目字典信息
        /// </summary>
        /// <returns>麻醉输入项目字典信息</returns>
        public Dict.AnesthesiaInputDictDataTable GetAnesthesiaInputDict()
        {
            Dict.AnesthesiaInputDictDataTable data = new Dict.AnesthesiaInputDictDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("Dict_GetAnesthesiaInputDict");
            database.Fill(sql, data);
            return data;
            // return GetData<Dict.AnesthesiaInputDictDataTable>(GetSQL("AnesthesiaInputDict"));
            //return new DictTableAdapters.MedAnesthesiaInputDictAdapter().GetData();
        }
        /// <summary>
        /// 返回常用术语字典信息
        /// </summary>
        /// <param name="item_class"></param>
        /// <returns></returns>
        public Dict.AnesthesiaInputDictDataTable GetDictTable(string item_class)
        {
            Dict.AnesthesiaInputDictDataTable data = new Dict.AnesthesiaInputDictDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Dict_GetAnesthesiaInputDictByItemClass");
            DbParameter itemClassParameter = database.BuildDbParameter("ITEM_CLASS", DbType.String, item_class);
            database.Fill(sql, data, new DbParameter[] { itemClassParameter });
            return data;

            // return GetData<Dict.AnesthesiaInputDictDataTable>(GetSQL("AnesthesiaInputDictByItemClass"), new object[] { item_class });
            //return new DictTableAdapters.MedAnesthesiaInputDictAdapter().GetDataByItemClass(item_class);
        }

        /// <summary>
        /// 更新常用术语字典信息
        /// </summary>
        /// <param name="InputDateble"></param>
        /// <returns></returns>
        public int UpdateAnesthesiaDictDT(Dict.AnesthesiaInputDictDataTable dateTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dateTable, "WIS_DICT_ANES_INPUT");
            //return UpdateData<Dict.AnesthesiaInputDictDataTable>(dateTable,GetSQL("AnesthesiaInputDict"));
            //return new DictTableAdapters.MedAnesthesiaInputDictAdapter().Update(dateTable);
        }
        /// <summary>
        /// 返回诊断字典信息
        /// </summary>
        /// <returns>诊断字典信息</returns>
        public Dict.WisDiagnosisDictDataTable GetDiagnosisDict()
        {
            Dict.WisDiagnosisDictDataTable data = new Dict.WisDiagnosisDictDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("Dict_GetDiagnosisDict");
            database.Fill(sql, data);
            return data;
            // return GetData<Dict.WisDiagnosisDictDataTable>(GetSQL("DiagnosisDict"));
            //return new DictTableAdapters.WisDiagnosisDictAdapter().GetData();
        }
        /// <summary>
        /// 更新诊断字典信息
        /// </summary>
        /// <param name="DiagnosisDictDataTable"></param>
        /// <returns></returns>
        public int UpdateDiagnosisDict(Dict.WisDiagnosisDictDataTable dateTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dateTable, "WIS_DICT_DIAGNOSIS");
            // return UpdateData<Dict.WisDiagnosisDictDataTable>(dateTable, GetSQL("DiagnosisDict"));
            //return new DictTableAdapters.WisDiagnosisDictAdapter().Update(dateTable);
        }

        /// <summary>
        /// 根据条件返回麻醉事件
        /// </summary>
        /// <param name="itemclass">条件</param>
        /// <returns></returns>
        public Dict.AnesthesiaEventOpenDataTable GetAnesthesiaEventOpen(string itemclass)
        {
            Dict.AnesthesiaEventOpenDataTable data = new Dict.AnesthesiaEventOpenDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("Dict_GetAnesthesiaEventOpenByItemclass");
            DbParameter itemClassParameter = database.BuildDbParameter("ITEM_CLASS", DbType.String, itemclass);
            database.Fill(sql, data, new DbParameter[] { itemClassParameter });
            return data;
            // return GetData<Dict.AnesthesiaEventOpenDataTable>(GetSQL("AnesthesiaEventOpenByItemclass"), new object[] { itemclass });
            //return new DictTableAdapters.AnesthesiaEventOpenAdapter().GetDataByItemclass(itemclass);
        }
        /// <summary>
        /// 返回麻醉事件字典信息
        /// </summary>
        /// <returns></returns>
        public Dict.AnesthesiaEventOpenDataTable GetAnesthesiaEventOpen()
        {
            Dict.AnesthesiaEventOpenDataTable data = new Dict.AnesthesiaEventOpenDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("Dict_GetAllEventOpen");
            database.Fill(sql, data);
            return data;
            //return GetData<Dict.AnesthesiaEventOpenDataTable>(GetSQL("AnesthesiaEventOpen"));
            //return new DictTableAdapters.AnesthesiaEventOpenAdapter().GetData();
        }
        /// <summary>
        /// 根据条件返回 吸入麻药,局部麻药,静脉麻药
        /// </summary>
        /// <param name="item_class"></param>
        /// <param name="EVENT_ATTR_2">1为吸入,2为局部,3为静脉</param>
        /// <returns></returns>
        public Dict.AnesthesiaEventOpenDataTable GetAnesthesiaEventOpen(string item_class, string EVENT_ATTR_2)
        {
            Dict.AnesthesiaEventOpenDataTable data = new Dict.AnesthesiaEventOpenDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("Dict_GetEventOpenByAttr");
            DbParameter itemClassParameter = database.BuildDbParameter("ITEM_CLASS", DbType.String, item_class);
            DbParameter eventParameter = database.BuildDbParameter("EVENT_ATTR_2", DbType.String, EVENT_ATTR_2);

            database.Fill(sql, data, new DbParameter[] { itemClassParameter, eventParameter });
            return data;
            // return GetData<Dict.AnesthesiaEventOpenDataTable>(GetSQL("AnesthesiaEventOpenByEVENT_ATTR"), new object[] { item_class,EVENT_ATTR_2 });
            //return new DictTableAdapters.AnesthesiaEventOpenAdapter().GetDataByEVENT_ATTR(item_class, EVENT_ATTR_2);
        }
        /// <summary>
        /// 根据条件查找呼吸
        /// </summary>
        /// <returns></returns>
        public Dict.AnesthesiaEventOpenDataTable GetAnesthesiaEventOpenByhuxi()
        {
            Dict.AnesthesiaEventOpenDataTable data = new Dict.AnesthesiaEventOpenDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("Dict_GetEventOpenByhuxi");
            DbParameter parameter1 = database.BuildDbParameter("Param1", DbType.String, "9");
            DbParameter parameter2 = database.BuildDbParameter("Param2", DbType.String, "A");
            DbParameter parameter3 = database.BuildDbParameter("Param3", DbType.String, "Y");

            DbParameter parameter4 = database.BuildDbParameter("Param4", DbType.String, "辅助呼吸");
            DbParameter parameter5 = database.BuildDbParameter("Param5", DbType.String, "控制呼吸");
            DbParameter parameter6 = database.BuildDbParameter("Param6", DbType.String, "自主呼吸");

            database.Fill(sql, data, new DbParameter[] { parameter1, parameter2, parameter3, parameter4, parameter5, parameter6 });
            return data;
            // return GetData<Dict.AnesthesiaEventOpenDataTable>(GetSQL("AnesthesiaEventOpenByhuxi"), new object[] { "9", "A", "Y", "辅助呼吸", "控制呼吸", "自主呼吸" });
            //return new DictTableAdapters.AnesthesiaEventOpenAdapter().GetDataByhuxi("9", "A", "Y", "辅助呼吸", "控制呼吸", "自主呼吸");
        }

        /// <summary>
        /// 更新麻醉事件字典信息
        /// </summary>
        /// <param name="EventOpenTable"></param>
        /// <returns></returns>
        public int UpdateAnesthesiaEventOpen(Dict.AnesthesiaEventOpenDataTable dateTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dateTable, "WIS_ANES_EVENT_OPEN");
            // return UpdateData<Dict.AnesthesiaEventOpenDataTable>(dateTable,GetSQL("AnesthesiaEventOpen"));
            //return new DictTableAdapters.AnesthesiaEventOpenAdapter().Update(dateTable);
        }

        /// <summary>
        /// 返回手术名称字典信息
        /// </summary>
        /// <returns></returns>
        public Dict.OperationDictDataTable GetOperationDict()
        {
            Dict.OperationDictDataTable data = new Dict.OperationDictDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Dict_GetOperationDict");
            database.Fill(sql, data);
            return data;
            // return GetData<Dict.OperationDictDataTable>(GetSQL("OperationDict"));
            //return new DictTableAdapters.OperationDictAdapter().GetData();
        }

        public int UpdateOperationDict(Dict.OperationDictDataTable dateTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dateTable, "WIS_DICT_OPERATION");
            // return UpdateData<Dict.OperationDictDataTable>(dateTable, GetSQL("OperationDict"));
            //return new DictTableAdapters.AnessthestaDictAdapter().Update(dateTable);
        }
        /// <summary>
        /// 返回麻醉方法字典信息
        /// </summary>
        /// <returns></returns>
        public Dict.AnessthestaDictDataTable GetAnesDict()
        {
            Dict.AnessthestaDictDataTable data = new Dict.AnessthestaDictDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Dict_GetAnesDict");
            database.Fill(sql, data);
            return data;


            //return GetData<Dict.AnessthestaDictDataTable>("SELECT * FROM WIS_DICT_ANES");
            //return GetData<Dict.AnessthestaDictDataTable>(GetSQL("AnessthestaDict"));
            //return new DictTableAdapters.AnessthestaDictAdapter().GetData();
        }

        public int UpdateAnesDict(Dict.AnessthestaDictDataTable dateTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dateTable, "WIS_DICT_ANES");
            // return UpdateData<Dict.AnessthestaDictDataTable>(dateTable,GetSQL("AnessthestaDict"));
            //return new DictTableAdapters.AnessthestaDictAdapter().Update(dateTable);
        }

        /// <summary>
        /// 获得HisUsers信息
        /// </summary>
        /// <returns></returns>
        public Dict.HisUserDataTable GetHisUsers(string USER_JOB)
        {
            Dict.HisUserDataTable data = new Dict.HisUserDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("Dict_GetHisUserByUserJob");
            DbParameter userJob = database.BuildDbParameter("userJob", DbType.String, USER_JOB);
            database.Fill(sql, data, new DbParameter[] { userJob });
            return data;
            // return GetData<Dict.HisUserDataTable>(GetSQL("HisUserByUserJob"), new object[] { USER_JOB });
            //return new DictTableAdapters.HisUserAdapter().GetDataByUserJob(USER_JOB);
        }

        public Dict.HisUserDataTable GetHisUsersDept(string USER_DEPT)
        {
            Dict.HisUserDataTable data = new Dict.HisUserDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("Dict_GetHisUserByUserDept");
            DbParameter userdept = database.BuildDbParameter("userdept", DbType.String, USER_DEPT);
            database.Fill(sql, data, new DbParameter[] { userdept });
            return data;
            // return GetData<Dict.HisUserDataTable>(GetSQL("HisUserByUserJob"), new object[] { USER_JOB });
            //return new DictTableAdapters.HisUserAdapter().GetDataByUserJob(USER_JOB);
        }
        public Dict.HisUserDataTable GetHisUsers()
        {
            Dict.HisUserDataTable data = new Dict.HisUserDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Dict_GetHisUsers");
            database.Fill(sql, data);
            return data;
            //return GetData<Dict.HisUserDataTable>(GetSQL("HisUser"));
            //return new DictTableAdapters.HisUserAdapter().GetData();
        }
        /// <summary>
        /// 获取医生姓名
        /// </summary>
        /// <returns></returns>
        public Dict.HisUserDataTable GetDoctor()
        {
            return GetHisUsers("医生");
        }
        /// <summary>
        /// 获取护士姓名
        /// </summary>
        /// <returns></returns>
        public Dict.HisUserDataTable GetNurse()
        {
            return GetHisUsers("护士");
        }
        /// <summary>
        /// 更新HisUsers
        /// </summary>
        /// <param name="HisUsersTable"></param>
        /// <returns></returns>
        public int UpdateHisUsers(Dict.HisUserDataTable dateTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dateTable, "WIS_PERM_HIS_USER");
        }
        /// <summary>
        /// 获取科室字典列表
        /// </summary>
        /// <returns></returns>
        public Dict.DeptDictDataTable GetDeptDict()
        {
            Dict.DeptDictDataTable data = new Dict.DeptDictDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Dict_GetDeptDict");

            database.Fill(sql, data);
            return data;
        }
        public Dict.DeptDictDataTable GetDeptDict(string deptCode)
        {
            Dict.DeptDictDataTable data = new Dict.DeptDictDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Dict_GetDeptDictByDeptCode");
            DbParameter patientId = database.BuildDbParameter("DEPT_CODE", DbType.String, deptCode);

            database.Fill(sql, data, new DbParameter[] { patientId });
            return data;
        }

        public Dict.CustomDataExtDataTable GetCustomDataExt()
        {
            Dict.CustomDataExtDataTable data = new Dict.CustomDataExtDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("Dict_GetCustomDataExt");
            database.Fill(sql, data);
            return data;
        }

        public Dict.CustomDataExtDataTable GetCustomDataExt(string patientID, decimal visitID, decimal operID)
        {
            Dict.CustomDataExtDataTable data = new Dict.CustomDataExtDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("Dict_GetCustomDataExtByPatient");
            database.Fill(sql, data, new DbParameter[] { database.BuildDbParameter("PatientID", DbType.String, patientID),
                database.BuildDbParameter("VisitID", DbType.Decimal, visitID),database.BuildDbParameter("OperID", DbType.Decimal, operID)});
            return data;
        }

        public int UpdateCustomDataExt(Dict.CustomDataExtDataTable dataTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dataTable, "WIS_CUSTOM_DATA_EXT");
        }

        public Dict.WIS_DICT_CUSTOM_FIELDDataTable GetCustomFieldDict()
        {
            Dict.WIS_DICT_CUSTOM_FIELDDataTable data = new Dict.WIS_DICT_CUSTOM_FIELDDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("Dict_GetCustomFieldDict");
            database.Fill(sql, data);
            return data;
        }

        public Dict.WIS_DICT_CUSTOM_FIELDDataTable GetTableDesc()
        {
            Dict.WIS_DICT_CUSTOM_FIELDDataTable data = new Dict.WIS_DICT_CUSTOM_FIELDDataTable();

            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Dict_GetTableDesc");
            database.Fill(sql, data);
            return data;

        }

        public Dict.WIS_DICT_CUSTOM_FIELDDataTable GetFieldDesc(string tableName)
        {
            Dict.WIS_DICT_CUSTOM_FIELDDataTable data = new Dict.WIS_DICT_CUSTOM_FIELDDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("Dict_GetTableDescByTableNames");
            DbParameter tableNameParameter = database.BuildDbParameter("FIELD_DESC", DbType.String, "TABLEOF" + tableName);

            database.Fill(sql, data, new DbParameter[] { tableNameParameter });
            return data;
        }

        public int UpdateCustomFieldDict(Dict.WIS_DICT_CUSTOM_FIELDDataTable dataTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dataTable, "WIS_DICT_CUSTOM_FIELD");
        }

        public Dict.DictSimpleTypesDataTable GetDictSimpleTypes()
        {
            Dict.DictSimpleTypesDataTable data = new Dict.DictSimpleTypesDataTable();

            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Dict_GetDictSimpleTypes");
            database.Fill(sql, data);
            return data;

        }

        public Dict.DictSimpleTypesDataTable GetDictSimpleTypes(string typeKey)
        {
            Dict.DictSimpleTypesDataTable data = new Dict.DictSimpleTypesDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("Dict_GetDictSimpleTypesByTypeKey");
            DbParameter tableNameParameter = database.BuildDbParameter("TYPEKEY", DbType.String, typeKey);

            database.Fill(sql, data, new DbParameter[] { tableNameParameter });
            return data;
        }

        public int UpdateDictSimpleTypes(Dict.DictSimpleTypesDataTable dataTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dataTable, "WIS_DICT_SIMPLETYPE");
        }

        public Dict.DictSimpleTypesTreeDataTable GetDictSimpleTypesTree()
        {
            Dict.DictSimpleTypesTreeDataTable data = new Dict.DictSimpleTypesTreeDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("Dict_GetDictSimpleTypesTree");
            database.Fill(sql, data);
            return data;
        }

        public int InsertDictSimpleTypesTree(string parentKey, string childKey)
        {
            Dict.DictSimpleTypesTreeDataTable dataTable = GetDictSimpleTypesTree();
            Dict.DictSimpleTypesTreeRow row = dataTable.NewDictSimpleTypesTreeRow();
            row.PARENT_TYPE_KEY = parentKey;
            row.CHILD_TYPE_KEY = childKey;
            dataTable.AddDictSimpleTypesTreeRow(row);
            return UpdateDictSimpleTypesTree(dataTable);
        }

        public int ModifyDictSimpleTypesTreeParent(string parentKey, string oldChildKey, string newChildKey)
        {
            Dict.DictSimpleTypesTreeDataTable dataTable = GetDictSimpleTypesTree();
            Dict.DictSimpleTypesTreeRow row = dataTable.FindByPARENT_TYPE_KEYCHILD_TYPE_KEY(parentKey, oldChildKey);
            if (row != null)
            {
                row.CHILD_TYPE_KEY = newChildKey;
            }
            return UpdateDictSimpleTypesTree(dataTable);
        }

        public int ModifyDictSimpleTypesTreeChild(string childKey, string oldParentKey, string newParentKey)
        {
            Dict.DictSimpleTypesTreeDataTable dataTable = GetDictSimpleTypesTree();
            Dict.DictSimpleTypesTreeRow row = dataTable.FindByPARENT_TYPE_KEYCHILD_TYPE_KEY(oldParentKey, childKey);
            if (row != null)
            {
                row.PARENT_TYPE_KEY = newParentKey;
            }
            return UpdateDictSimpleTypesTree(dataTable);
        }

        public int UpdateDictSimpleTypesTree(Dict.DictSimpleTypesTreeDataTable dataTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dataTable, "WIS_DICT_SIMPLETYPE_TREE");
        }

        public Dict.DocumentTempletDataTable GetDocumentTemplet()
        {
            Dict.DocumentTempletDataTable data = new Dict.DocumentTempletDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("Dict_GetDocumentTemplet");
            database.Fill(sql, data);
            return data;
        }
        public Dict.DocumentTempletDataTable GetDocumentTemplet(string userID, decimal isPrivate, decimal eventNo)
        {
            Dict.DocumentTempletDataTable data = new Dict.DocumentTempletDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("Dict_GetDocumentTempletByUserIDAndIsPrivate");
            database.Fill(sql, data, new DbParameter[] { database.BuildDbParameter("USER_ID", DbType.String, userID)
                ,database.BuildDbParameter("IsPrivate", DbType.Decimal, isPrivate)
            ,database.BuildDbParameter("EVENT_NO",DbType.Decimal,eventNo)});
            return data;
        }
        public Dict.DocumentTempletDataTable GetDocumentTemplet(string userID, string documentName, decimal eventNo)
        {
            Dict.DocumentTempletDataTable data = new Dict.DocumentTempletDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("Dict_GetDocumentTempletByUserIDAndDocumentName");
            database.Fill(sql, data, new DbParameter[] { database.BuildDbParameter("USER_ID", DbType.String, userID)
                ,database.BuildDbParameter("DOCUMENT_NAME", DbType.String, documentName)
            ,database.BuildDbParameter("EVENT_NO",DbType.Decimal,eventNo)});
            return data;
        }
        public Dict.DocumentTempletDataTable GetDocumentTemplet(string userID, decimal isPrivate, string documentName, decimal eventNo)
        {
            Dict.DocumentTempletDataTable data = new Dict.DocumentTempletDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("Dict_GetDocumentTempletByUserIDAndIsPrivateAndDocumentName");
            database.Fill(sql, data, new DbParameter[] { database.BuildDbParameter("USER_ID", DbType.String, userID)
                ,database.BuildDbParameter("ISPRIVATE", DbType.Decimal, isPrivate),database.BuildDbParameter("DOCUMENT_NAME", DbType.String, documentName)
            ,database.BuildDbParameter("EVENT_NO",DbType.Decimal,eventNo)});
            return data;
        }
        public Dict.DocumentTempletDataTable GetDocumentTemplet(string userID, decimal isPrivate, string documentName, decimal isJuBu, decimal eventNo)
        {
            Dict.DocumentTempletDataTable data = new Dict.DocumentTempletDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("Dict_GetDocumentTempletByUserIDAndIsPrivateAndDocumentNameAndIsJuBu");
            database.Fill(sql, data, new DbParameter[] { database.BuildDbParameter("USER_ID", DbType.String, userID)
                ,database.BuildDbParameter("IsPrivate", DbType.Decimal, isPrivate),database.BuildDbParameter("DOCUMENT_NAME", DbType.String, documentName)
                ,database.BuildDbParameter("IsJuBu", DbType.Decimal, isJuBu),database.BuildDbParameter("EVENT_NO",DbType.Decimal,eventNo)});
            return data;
        }
        public Dict.DocumentTempletDataTable GetDocumentTempletByClassName(string userID, decimal isPrivate, string className, string documentName, decimal eventNo)
        {
            Dict.DocumentTempletDataTable data = new Dict.DocumentTempletDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("Dict_GetDocumentTempletByUserIDAndIsPrivateAndClassNameAndDocumentName");
            database.Fill(sql, data, new DbParameter[] { database.BuildDbParameter("USER_ID", DbType.String, userID)
                ,database.BuildDbParameter("IsPrivate", DbType.Decimal, isPrivate),database.BuildDbParameter("CLASS_NAME", DbType.String, className)
                ,database.BuildDbParameter("DOCUMENT_NAME", DbType.String, documentName),database.BuildDbParameter("EVENT_NO",DbType.Decimal,eventNo)});
            return data;
        }
        public Dict.DocumentTempletDataTable GetDocumentTempletByClassName(string userID, decimal isPrivate, string className, string documentName, decimal isJuBu, decimal eventNo)
        {
            Dict.DocumentTempletDataTable data = new Dict.DocumentTempletDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("Dict_GetDocumentTempletByUserIDAndIsPrivateAndClassNameAndDocumentNameAndIsJuBu");
            database.Fill(sql, data, new DbParameter[] { database.BuildDbParameter("USER_ID", DbType.String, userID)
                ,database.BuildDbParameter("IsPrivate", DbType.Decimal, isPrivate),database.BuildDbParameter("CLASS_NAME", DbType.String, className)
                ,database.BuildDbParameter("DOCUMENT_NAME", DbType.String, documentName),database.BuildDbParameter("IsJuBu", DbType.Decimal, isJuBu)
            ,database.BuildDbParameter("EVENT_NO",DbType.Decimal,eventNo)});
            return data;
        }
        public Dict.DocumentTempletDataTable GetDocumentTempletPrivateAndPublic(string userID, decimal eventNo)
        {
            Dict.DocumentTempletDataTable data = new Dict.DocumentTempletDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Dict_GetDocumentTempletPrivateAndPublicByUserID");
            database.Fill(sql, data, new DbParameter[] { database.BuildDbParameter("USER_ID", DbType.String, userID), database.BuildDbParameter("EVENT_NO", DbType.Decimal, eventNo) });
            return data;
        }
        public Dict.DocumentTempletDataTable GetDocumentTempletPrivateAndPublic(string userID, string documentName, decimal eventNo)
        {
            Dict.DocumentTempletDataTable data = new Dict.DocumentTempletDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Dict_GetDocumentTempletPrivateAndPublicByUserIDAndDocumentName");
            database.Fill(sql, data, new DbParameter[] { database.BuildDbParameter("USER_ID", DbType.String, userID)
                ,database.BuildDbParameter("DOCUMENT_NAME", DbType.String, documentName)
                , database.BuildDbParameter("EVENT_NO", DbType.Decimal, eventNo) });
            return data;
        }
        public Dict.DocumentTempletDataTable GetDocumentTempletPrivateAndPublic(string userID, string documentName, decimal isJuBu, decimal eventNo)
        {
            Dict.DocumentTempletDataTable data = new Dict.DocumentTempletDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Dict_GetDocumentTempletPrivateAndPublicByUserIDAndDocumentNameAndIsJuBu");
            database.Fill(sql, data, new DbParameter[] { database.BuildDbParameter("USER_ID", DbType.String, userID)
                ,database.BuildDbParameter("DOCUMENT_NAME", DbType.String, documentName)
                ,database.BuildDbParameter("IsJuBu", DbType.Decimal, isJuBu)
                , database.BuildDbParameter("EVENT_NO", DbType.Decimal, eventNo) });
            return data;
        }
        public Dict.DocumentTempletDataTable GetDocumentTempletPrivateAndPublicByClassName(string userID, string className, string documentName, decimal eventNo)
        {
            Dict.DocumentTempletDataTable data = new Dict.DocumentTempletDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Dict_GetDocumentTempletPrivateAndPublicByUserIDAndClassNameAndDocumentName");
            database.Fill(sql, data, new DbParameter[] { database.BuildDbParameter("USER_ID", DbType.String, userID)
                ,database.BuildDbParameter("CLASS_NAME", DbType.String, className)
                ,database.BuildDbParameter("DOCUMENT_NAME", DbType.String, documentName)
                , database.BuildDbParameter("EVENT_NO", DbType.Decimal, eventNo) });
            return data;
        }
        public Dict.DocumentTempletDataTable GetDocumentTempletPrivateAndPublicByClassName(string userID, string className, string documentName, decimal isJuBu, decimal eventNo)
        {
            Dict.DocumentTempletDataTable data = new Dict.DocumentTempletDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Dict_GetDocumentTempletPrivateAndPublicByUserIDAndClassNameAndDocumentNameAndIsJuBu");
            database.Fill(sql, data, new DbParameter[] { database.BuildDbParameter("USER_ID", DbType.String, userID)
                ,database.BuildDbParameter("CLASS_NAME", DbType.String, className)
                ,database.BuildDbParameter("DOCUMENT_NAME", DbType.String, documentName)
                ,database.BuildDbParameter("IsJuBu", DbType.Decimal, isJuBu)
                , database.BuildDbParameter("EVENT_NO", DbType.Decimal, eventNo) });
            return data;
        }
        public int DeleteDocumentTempletByTempletGuid(string templetGuid)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.ExecuteNonQuery("delete from WIS_ANES_DOC_TEMPLET where TEMPLET_GUID='" + templetGuid + "'");
        }
        public int UpdateDocumentTemplet(Dict.DocumentTempletDataTable dataTable)
        {
            IDatabase database = DatabaseFactory.Create();
            return database.Update(dataTable, "WIS_ANES_DOC_TEMPLET");
        }

        /// <summary>
        /// 获取监测配置表
        /// </summary>
        /// <returns>监测配置表</returns>
        public Dict.MonitorFunctionCodeDataTable GetMonitorFunctionCode()
        {
            Dict.MonitorFunctionCodeDataTable data = new Dict.MonitorFunctionCodeDataTable();
            string sql = StoredScript.Get("AnesInformations_GetMonitorFunctionCode");

            IDatabase database = DatabaseFactory.Create();
            database.Fill(sql, data);
            return data;
        }

        public Dict.OperatingRoomDataTable GetOperatingRoomDict()
        {
            // return DatabaseFactory.Create().GetTable<Dict.OperatingRoomDataTable>("WIS_OPER_ROOM");
            // return DatabaseFactory.GetTableFromSQL<Dict.OperatingRoomDataTable>("SELECT * FROM WIS_OPER_ROOM ORDER BY ROOM_NO ASC");

            string SQL = "SELECT * FROM WIS_OPER_ROOM ORDER BY ROOM_NO ASC";
            Dict.OperatingRoomDataTable dt = new Dict.OperatingRoomDataTable();
            DatabaseFactory.Create().Fill(SQL, dt);
            return dt;
        }
        public Dict.OperatingRoomDataTable GetOperatingRoomDict(decimal bedType)
        {
            string SQL = "SELECT * FROM WIS_OPER_ROOM WHERE BED_TYPE = '" + bedType.ToString() + "'";
            Dict.OperatingRoomDataTable dt = new Dict.OperatingRoomDataTable();
            DatabaseFactory.Create().Fill(SQL, dt);
            return dt;
        }
        public int UpdateOperatingRoomDict(Dict.OperatingRoomDataTable dataTable)
        {
            return DatabaseFactory.Create().Update(dataTable, "WIS_OPER_ROOM");
        }
        public Dict.BloodGasDictDataTable GetBloodGasDict()
        {
            //return DatabaseFactory.Create().GetTable<Dict.BloodGasDictDataTable>("WIS_DICT_BLOOD_GAS");
            string SQL = "SELECT * FROM WIS_DICT_BLOOD_GAS ORDER BY BLG_SHOWID ASC";
            Dict.BloodGasDictDataTable dt = new Dict.BloodGasDictDataTable();
            DatabaseFactory.Create().Fill(SQL, dt);
            return dt;
        }
        public Dict.BloodGasDictDataTable GetBloodGasDict(string blgStatus)
        {
            Dict.BloodGasDictDataTable data = new Dict.BloodGasDictDataTable();
            string sql = StoredScript.Get("Dict_GetBloodGasDictByBlgStatus");

            IDatabase database = DatabaseFactory.Create();
            database.Fill(sql, data, new DbParameter[] { database.BuildDbParameter("BLG_STATUS", DbType.String, blgStatus) });
            return data;
        }
        public DataTable GetBlgGasDictPartial(string blgStatus)
        {
            DataTable data = new DataTable();
            string sql = StoredScript.Get("Dict_GetBloodGasDictPartialByBlgStatus");

            IDatabase database = DatabaseFactory.Create();
            database.Fill(sql, data, new DbParameter[] { database.BuildDbParameter("BLG_STATUS", DbType.String, blgStatus) });
            return data;
        }
        public int UpdateBloodGasDict(Dict.BloodGasDictDataTable dataTable)
        {
            return DatabaseFactory.Create().Update(dataTable, "WIS_DICT_BLOOD_GAS");
        }

        public Dict.HospitalConfigDataTable GetHospitalConfig()
        {
            return DatabaseFactory.Create().GetTable<Dict.HospitalConfigDataTable>("WIS_CONF_HOSPITAL");
        }

        public int UpdateHospitalConfig(Dict.HospitalConfigDataTable dataTable)
        {
            return DatabaseFactory.Create().Update(dataTable, "WIS_CONF_HOSPITAL");
        }

        public string GetHospitalName()
        {
            Dict.HospitalConfigDataTable dataTable = GetHospitalConfig();
            if (dataTable != null && dataTable.Count == 1&&!dataTable[0].IsHOSPITAL_NAMENull())
            {
                return dataTable[0].HOSPITAL_NAME;
            }
            return "";
        }
        public string GetHospitalID()
        {
            Dict.HospitalConfigDataTable dataTable = GetHospitalConfig();
            if (dataTable != null && dataTable.Count == 1)
            {
                return dataTable[0].HOSPITAL_ID;
            }
            return "";
        }
        public int GetMaxDicUserId()
        {
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Dict_GetMaxDicUserId");
            object max = database.ExecuteScalar(sql);
            if (max == null)
                return 0;
            else
                return Convert.ToInt32(max);

        }

        public Dict.HisUserDataTable GetUserIDByUserName(string userName)
        {
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Dict_GetUserNameByUserID");
            Dict.HisUserDataTable userTable = new Dict.HisUserDataTable();
            database.Fill(sql, userTable, new DbParameter[] { database.BuildDbParameter("user_name", DbType.String, userName) });
            return userTable;

        }

        /// <summary>
        /// 设置手术间患者
        /// </summary>
        /// <param name="operatingRoomDataTable">手术间表</param>
        /// <param name="roomNo">手时间号</param>
        /// <param name="wardCode">手术科室</param>
        public void SetOperatingRoomPatient(Dict.OperatingRoomDataTable operatingRoomDataTable, string roomNo, string wardCode, string patientID, decimal visitID, decimal operID)
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
        /// 设置监护设备对应患者
        /// </summary>
        /// <param name="wardType">科室类别（代表麻醉或者PACU）</param>
        /// <param name="wardCode">手术科室</param>
        /// <param name="roomNo">手术间号</param>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns>是否设置成功</returns>
        public bool SetMonitorDictPatient(decimal wardType, string wardCode, string roomNo, string patientID, decimal visitID, decimal operID)
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


        public Dict.WisPatMonitorDataDictDataTable GetPatMonitorDataDict()
        {
            IDatabase database = DatabaseFactory.Create();
            string sql = " select * from WIS_DICT_PAT_MONITOR_DATA WHERE PAT_ID ='0'";
            Dict.WisPatMonitorDataDictDataTable dt = new Dict.WisPatMonitorDataDictDataTable();
            database.Fill(sql, dt);
            return dt;

        }

        public int UpdatePatMonitorDataDict(Dict.WisPatMonitorDataDictDataTable dataTable)
        {
            return DatabaseFactory.Create().Update(dataTable, "WIS_DICT_PAT_MONITOR_DATA");
        }

        public Dict.WIS_DICT_BILL_CONFIGDataTable GetBillCfgDict()
        {
            IDatabase database = DatabaseFactory.Create();
            string sql = " select * from WIS_DICT_BILL_CONFIG";
            Dict.WIS_DICT_BILL_CONFIGDataTable dt = new Dict.WIS_DICT_BILL_CONFIGDataTable();
            database.Fill(sql, dt);
            return dt;

        }

        public int UpdateBillCfgDict(Dict.WIS_DICT_BILL_CONFIGDataTable dt)
        {
            return DatabaseFactory.Create().Update(dt, "WIS_DICT_BILL_CONFIG");
        }

        public Dict.OperationBillItemsDataTable GetOperationBillItems()
        {
            return DatabaseFactory.Create().GetTable<Dict.OperationBillItemsDataTable>("WIS_OPER_BILL_DETAIL");
        }

        public Dict.OperationBillItemsDataTable GetOperationBillItems(string patientID, decimal visitID, decimal operID)
        {
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Dict_GetOperationBillItems");
            Dict.OperationBillItemsDataTable dataTable = new Dict.OperationBillItemsDataTable();
            database.Fill(sql, dataTable, new DbParameter[] { database.BuildDbParameter("patientID", DbType.String, patientID)
            ,database.BuildDbParameter("visitID", DbType.Decimal, visitID),database.BuildDbParameter("operID", DbType.Decimal, operID)});
            return dataTable;
        }

        public int UpdateOperationBillItems(Dict.OperationBillItemsDataTable dt)
        {
            return DatabaseFactory.Create().Update(dt, "WIS_OPER_BILL_DETAIL");
        }

        public Dict.WIS_EQIP_MANAGEMENTDataTable GetEquipmentManagement(int deptType)
        {
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Dict_GetEquipmentManagement");
            Dict.WIS_EQIP_MANAGEMENTDataTable dataTable = new Dict.WIS_EQIP_MANAGEMENTDataTable();
            database.Fill(sql, dataTable, new DbParameter[] { database.BuildDbParameter("DeptType", DbType.Int32, deptType) });
            return dataTable;
        }
        public Dict.EQUIPMENTREPAIRSTATUSBYDAYDataTable GetEquipmentByDay()
        {
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Dict_GetEquipmentByDay");

            Dict.EQUIPMENTREPAIRSTATUSBYDAYDataTable dataTable = new Dict.EQUIPMENTREPAIRSTATUSBYDAYDataTable();

            database.Fill(sql, dataTable);
            return dataTable;
        }
        public Dict.EQUIPMENTREPAIRSTATUSBYDAYDataTable GetEquipmentByDay(DateTime dateTimePickerQuery, int deptType)
        {
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Dict_GetEquipmentByDay");
            Dict.EQUIPMENTREPAIRSTATUSBYDAYDataTable dataTable = new Dict.EQUIPMENTREPAIRSTATUSBYDAYDataTable();
            database.Fill(sql, dataTable, new DbParameter[] { database.BuildDbParameter("dateTimePickerQuery", DbType.String, dateTimePickerQuery.ToString("yyyy-MM-dd"))
            ,database.BuildDbParameter("dateTimePickerQueryEnd", DbType.String, dateTimePickerQuery.ToString("yyyy-MM-dd"))
            ,database.BuildDbParameter("DeptType", DbType.Int32, deptType)});
            return dataTable;
        }
        public Dict.EQUIPMENTREPAIRSTATUSBYDAYDataTable GetEquipmentByDay(int deptType, string instrumentCode, string instrumentName, string supplierName, string modelNumber, string serialNumber, string attribute, DateTime dateTimePickerQuery, DateTime dateTimePickerQueryEnd, bool repair)
        {
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Dict_GetEquipmentByDay");
            //if (!string.IsNullOrEmpty(instrumentCode) || !string.IsNullOrEmpty(instrumentName) || !string.IsNullOrEmpty(supplierName) ||
            //    !string.IsNullOrEmpty(modelNumber) || !string.IsNullOrEmpty(serialNumber) || !string.IsNullOrEmpty(attribute)|| repair)
            //{
            //    sql += " WHERE 1=1 ";
            //}
            if (!string.IsNullOrEmpty(instrumentCode))
            {
                sql += " AND A.INSTRUMENT_CODE LIKE '%" + instrumentCode + "%' ";
            }
            if (!string.IsNullOrEmpty(instrumentName))
            {
                sql += " AND A.INSTRUMENT_NAME LIKE '%" + instrumentName + "%' ";
            }
            if (!string.IsNullOrEmpty(supplierName))
            {
                sql += " AND A.SUPPLIER_NAME LIKE '%" + supplierName + "%' ";
            }
            if (!string.IsNullOrEmpty(modelNumber))
            {
                sql += " AND A.MODEL_NUMBER LIKE '%" + modelNumber + "%' ";
            }
            if (!string.IsNullOrEmpty(serialNumber))
            {
                sql += " AND A.SERIAL_NUMBER LIKE '%" + serialNumber + "%' ";
            }
            if (!string.IsNullOrEmpty(attribute))
            {
                sql += " AND A.ATTRIBUTE LIKE '%" + attribute + "%' ";
            }
            if (repair)
            {
                sql += " AND D.SITUATION IS NOT NULL ";
            }
            Dict.EQUIPMENTREPAIRSTATUSBYDAYDataTable dataTable = new Dict.EQUIPMENTREPAIRSTATUSBYDAYDataTable();
            database.Fill(sql, dataTable, new DbParameter[] { database.BuildDbParameter("dateTimePickerQuery", DbType.String, dateTimePickerQuery.ToString("yyyy-MM-dd"))
               ,database.BuildDbParameter("dateTimePickerQueryEnd",DbType.String,dateTimePickerQueryEnd.ToString("yyyy-MM-dd"))
             ,database.BuildDbParameter("DeptType", DbType.Int32, deptType)});
            return dataTable;
        }
        public int UpdateEquipmentManagement(Dict.WIS_EQIP_MANAGEMENTDataTable dt)
        {
            return DatabaseFactory.Create().Update(dt, "WIS_EQIP_MANAGEMENT");
        }
        public Dict.WIS_EQIP_REPAIRDataTable GetEquipmentRepair()
        {
            IDatabase database = DatabaseFactory.Create();
            string sql = "SELECT INSTRUMENT_CODE,REPAIR_COUNT,MAINTENANCE_TIME,SITUATION FROM WIS_EQIP_REPAIR ";
            Dict.WIS_EQIP_REPAIRDataTable dataTable = new Dict.WIS_EQIP_REPAIRDataTable();
            database.Fill(sql, dataTable);
            return dataTable;
        }
        public Dict.WIS_EQIP_STATUSDataTable GetEquipmentStatus()
        {
            IDatabase database = DatabaseFactory.Create();
            string sql = "SELECT INSTRUMENT_CODE,STATUS_COUNT,STATUS_TIME,STATUS FROM WIS_EQIP_STATUS ";
            Dict.WIS_EQIP_STATUSDataTable dataTable = new Dict.WIS_EQIP_STATUSDataTable();
            database.Fill(sql, dataTable);
            return dataTable;
        }
        public int UpdateEquipmentRepair(Dict.WIS_EQIP_REPAIRDataTable dt)
        {
            return DatabaseFactory.Create().Update(dt, "WIS_EQIP_REPAIR");
        }
        public int UpdateEquipmentStatus(Dict.WIS_EQIP_STATUSDataTable dt)
        {
            return DatabaseFactory.Create().Update(dt, "WIS_EQIP_STATUS");
        }

        public Dict.WIS_HIS_PATDataTable GetWisDisPat(string patid,string visitid)
        {
            IDatabase database = DatabaseFactory.Create();
            string sql = "SELECT WIS_PAT_ID,WIS_VISIT_ID,HIS_PAT_ID,HIS_INP_NO,HIS_VISIT_ID,CREATE_DATE_TIME,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05,RESERVED06,RESERVED07,RESERVED08 FROM WIS_HIS_PAT where WIS_PAT_ID='"+ patid + "' and WIS_VISIT_ID= '" + visitid + "' ";
            Dict.WIS_HIS_PATDataTable dataTable = new Dict.WIS_HIS_PATDataTable();
            database.Fill(sql, dataTable);
            return dataTable;
        }
    }
}
