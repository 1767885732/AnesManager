/*----------------------------------------------------------------
 // Copyright (C) 2007 北京拓扑工厂科技发展有限公司
 // 文件名：ICommon.cs
 // 文件功能描述：
 //     公共接口类
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
    /// 公共接口类
    /// </summary>
    public interface ICommon
    {
        /// <summary>
        /// 参数名翻译
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        string TransParameter(string parameterName);

        /// <summary>
        /// 获取服务器系统时间
        /// </summary>
        /// <returns>服务器时间</returns>
        DateTime GetSysDateTime();

        bool TestConnection(string providerName, string serverAddress, string dataBaseName, string userID, string password, bool isWindowUser,ref Exception err);
        bool IsSQLServer();
        bool IsOracle();

        bool TestConnection(ref Exception err);
        int ExecuteNonQuery(string sqlText);
        object ExecuteScalar(string sqlText);
        DataTable GetDataWithPrimaryKey(string tableName);
        DataTable GetDataWithPrimaryKey(string tableName, string whereString);
        DataTable GetDataWithPrimaryKey(string tableName, string whereString, object[] parameters);
        int UpdateDataTable(DataTable dataTable);
        DataTable GetDataFromSQLString(string sqlText);
        DataTable GetDataFromSQLString(string sqlText, object[] parameters);
        DataColumn[] GetPrimaryKey(string tableName);
        string EncodeConnectionString(string connectionName, string providerName, string serverAddress, string dataBaseName, string userName, string password, bool isWindowUser);
        void DecodeConnectionString(string connectionString, ref string connectionName, ref string providerName, ref string serverAddress, ref string dataBaseName, ref string userName, ref string password, ref bool isWindowUser);
    
        /// <summary>
        /// 获取日期查询字符串
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        string GetDateTimeQueryString(DateTime dateTime);

        /// <summary>
        /// 删除患者-删除患者对应的所有相关资料
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        void DeletePatient(string patientID, decimal visitID, decimal operID);


        DataTable GetAcsArticleKeyWord();
        DataTable GetAcsContextByKeyWord(string keyWord);
    }
}
