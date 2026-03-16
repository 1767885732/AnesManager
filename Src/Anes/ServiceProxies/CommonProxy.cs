using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.Interface;
using Wis.Anes.BusinessComponent;
using System.Data;

namespace Wis.Anes.ServiceProxies
{
    public class CommonProxy
    {
        static ICommon _iCommon = new CommonBC();
        /// <summary>
        /// 参数名翻译
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public static string TransParameter(string parameterName)
        {
            try
            {
                return _iCommon.TransParameter(parameterName);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        /// <summary>
        /// 获取服务器系统时间
        /// </summary>
        /// <returns>服务器时间</returns>
        public static DateTime GetSysDateTime()
        {
            try
            {
                return _iCommon.GetSysDateTime();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool TestConnection()
        {
            //Exception err = new Exception();
            //if (!_iCommon.TestConnection(ref err))
            //{
            //    DoError(err, false);
            //    Exception ex = new Exception("连接数据库失败，请配置数据库连接串，检查网络通信状况，或者与系统管理员联系。", err);
            //    throw ex;
            //    System.Windows.Forms.Application.Exit();
            //    return false;
            //}
            //return true;

            try
            {
                Exception err = new Exception();
                return _iCommon.TestConnection(ref err);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static bool TestConnection(string providerName, string serverAddress, string dataBaseName, string userID, string password, bool isWindowUser, ref Exception err)
        {
            try
            {
                return _iCommon.TestConnection(providerName, serverAddress, dataBaseName, userID, password, isWindowUser, ref err);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public static bool IsSQLServer()
        {
            try
            {
                return _iCommon.IsSQLServer();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public static bool IsOracle()
        {
            try
            {
                return _iCommon.IsOracle();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public static int ExecuteNonQuery(string sqlText)
        {
            try
            {
                return _iCommon.ExecuteNonQuery(sqlText);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public static object ExecuteScalar(string sqlText)
        {
            try
            {
                return _iCommon.ExecuteScalar(sqlText);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static System.Data.DataTable GetDataWithPrimaryKey(string tableName)
        {
            try
            {
                return _iCommon.GetDataWithPrimaryKey(tableName);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static System.Data.DataTable GetDataWithPrimaryKey(string tableName, string whereString)
        {
            try
            {
                return _iCommon.GetDataWithPrimaryKey(tableName, whereString);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static DataTable GetDataWithPrimaryKey(string tableName, string whereString, object[] parameters)
        {
            try
            {
                return _iCommon.GetDataWithPrimaryKey(tableName, whereString, parameters);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static int UpdateDataTable(System.Data.DataTable dataTable)
        {
            try
            {
                return _iCommon.UpdateDataTable(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static DataTable GetDataFromSQLString(string sqlText)
        {
            try
            {
                return _iCommon.GetDataFromSQLString(sqlText);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static DataTable GetDataFromSQLString(string sqlText, object[] parameters)
        {
            try
            {
                return _iCommon.GetDataFromSQLString(sqlText, parameters);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        /// <summary>
        /// 删除患者-删除患者对应的所有相关资料
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        public static void DeletePatient(string patientID, decimal visitID, decimal operID)
        {
            try
            {
                _iCommon.DeletePatient(patientID, visitID, operID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataColumn[] GetPrimaryKey(string tableName)
        {
            try
            {
                return _iCommon.GetPrimaryKey(tableName);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        public static string EncodeConnectionString(string connectionName, string providerName, string serverAddress, string dataBaseName, string userName, string password, bool isWindowUser)
        {
            try
            {
                return _iCommon.EncodeConnectionString(connectionName, providerName, serverAddress, dataBaseName, userName, password, isWindowUser);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static void DecodeConnectionString(string connectionString, ref string connectionName, ref string providerName, ref string serverAddress, ref string dataBaseName, ref string userName, ref string password, ref bool isWindowUser)
        {
            try
            {
                _iCommon.DecodeConnectionString(connectionString, ref connectionName, ref providerName, ref serverAddress, ref dataBaseName
               , ref userName, ref password, ref isWindowUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获取日期查询字符串
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string GetDateTimeQueryString(DateTime dateTime)
        {
            try
            {
                return _iCommon.GetDateTimeQueryString(dateTime);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        public static DataTable GetAcsArticleKeyWord()
        {
            try
            {
                return _iCommon.GetAcsArticleKeyWord();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        public static DataTable GetAcsContextByKeyWord(string keyWord)
        {
            try
            {
                return _iCommon.GetAcsContextByKeyWord( keyWord);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
