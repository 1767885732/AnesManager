using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.DataAccess;
using System.Data;
using Wis.Anes.Interface;

namespace Wis.Anes.BusinessComponent
{
    public class CommonBC : ICommon
    {
        /// <summary>
        /// 参数名翻译
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public string TransParameter(string parameterName)
        {
            return (new CommonDA()).TransParameter(parameterName);
        }

        /// <summary>
        /// 获取服务器系统时间
        /// </summary>
        /// <returns>服务器时间</returns>
        public DateTime GetSysDateTime()
        {
            return (new CommonDA()).GetSysDateTime();
        }

        public bool TestConnection(ref Exception err)
        {
            return (new CommonDA()).TestConnection(ref err);
        }

        public bool TestConnection(string providerName, string serverAddress, string dataBaseName, string userID, string password, bool isWindowUser, ref Exception err)
        {
            return (new CommonDA()).TestConnection(providerName, serverAddress, dataBaseName, userID, password, isWindowUser, ref err);
        }
        public bool IsSQLServer()
        {
            return (new CommonDA()).IsSQLServer();
        }
        public bool IsOracle()
        {
            return (new CommonDA()).IsOracle();
        }
        public int ExecuteNonQuery(string sqlText)
        {
            return (new CommonDA()).ExecuteNonQuery(sqlText);
        }
        public object ExecuteScalar(string sqlText)
        {
            return (new CommonDA()).ExecuteScalar(sqlText);
        }
        public DataTable GetDataWithPrimaryKey(string tableName)
        {
            return (new CommonDA()).GetDataWithPrimaryKey(tableName);
        }

        public DataTable GetDataWithPrimaryKey(string tableName, string whereString)
        {
            return (new CommonDA()).GetDataWithPrimaryKey(tableName, whereString);
        }

        public DataTable GetDataWithPrimaryKey(string tableName, string whereString, object[] parameters)
        {
            return (new CommonDA()).GetDataWithPrimaryKey(tableName, whereString, parameters);
        }
        public int UpdateDataTable(DataTable dataTable)
        {
            return (new CommonDA()).UpdateDataTable(dataTable);
        }
        public DataTable GetDataFromSQLString(string sqlText)
        {
            return (new CommonDA()).GetDataFromSQLString(sqlText);
        }

        public DataTable GetDataFromSQLString(string sqlText, object[] parameters)
        {
            return (new CommonDA()).GetDataFromSQLString(sqlText, parameters);
        }
        /// <summary>
        /// 删除患者-删除患者对应的所有相关资料
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        public void DeletePatient(string patientID, decimal visitID, decimal operID)
        {
            (new CommonDA()).DeletePatient(patientID, visitID, operID);
        }
        public DataColumn[] GetPrimaryKey(string tableName)
        {
            return (new CommonDA()).GetPrimaryKey(tableName);
        }

        public string EncodeConnectionString(string connectionName, string providerName, string serverAddress, string dataBaseName, string userName, string password, bool isWindowUser)
        {
            return (new CommonDA()).EncodeConnectionString(connectionName, providerName, serverAddress, dataBaseName, userName, password, isWindowUser);
        }

        public void DecodeConnectionString(string connectionString, ref string connectionName, ref string providerName, ref string serverAddress, ref string dataBaseName, ref string userName, ref string password, ref bool isWindowUser)
        {
            (new CommonDA()).DecodeConnectionString(connectionString, ref connectionName, ref providerName, ref serverAddress, ref dataBaseName
                , ref userName, ref password, ref isWindowUser);
        }
        /// <summary>
        /// 获取日期查询字符串
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public string GetDateTimeQueryString(DateTime dateTime)
        {
            return (new CommonDA()).GetDateTimeQueryString(dateTime);
        }



        public DataTable GetAcsArticleKeyWord()
        {
            return (new CommonDA()).GetAcsArticleKeyWord();
        }
        public DataTable GetAcsContextByKeyWord(string keyWord)
        {
            return (new CommonDA()).GetAcsContextByKeyWord(keyWord);
        }
        
    }
}
