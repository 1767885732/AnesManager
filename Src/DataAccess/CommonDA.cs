/*----------------------------------------------------------------
      // Copyright (C) 2008 北京拓扑工厂科技发展有限公司
      // 文件名：Common.cs
      // 文件功能描述：公共接口本地实现类
      //
      // 
      // 创建标识：XXX-2011-02-22
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Wis.Anes.BusinessEntity;
using System.IO;
using Wis.Anes.Data;
using System.Data.Common;

namespace Wis.Anes.DataAccess
{
    /// <summary>
    /// 公共接口本地实现类
    /// </summary>
    public partial class CommonDA 
    {
        /// <summary>
        /// 参数名翻译
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public string TransParameter(string parameterName)
        {
            return DatabaseFactory.TransParameter(parameterName);
        }

        public AnesInformations.DeptAsaGradeDataTable GetDeptAsaGrade(int year, int month)
        {
            string sqlText = StoredScript.Get("AnesInformations_GetDeptAsaGrade");

            IDatabase database = DatabaseFactory.Create();
            DbParameter yearParameter = database.BuildDbParameter("Year", DbType.Int32, year);
            DbParameter monthParameter = database.BuildDbParameter("Month", DbType.Int32, month);

            if (!(sqlText.Contains("一级") && sqlText.Contains("二级") && sqlText.Contains("三级")))
            {
                DataTable dataTable = new DataTable();

                database.Fill(sqlText, dataTable, new DbParameter[] { yearParameter, monthParameter });
               
                AnesInformations.DeptAsaGradeDataTable deptAsaGradeDataTable = new AnesInformations.DeptAsaGradeDataTable();

                string deptName = "";
                AnesInformations.DeptAsaGradeRow deptAsaGradeRow = null;
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["DEPT_NAME"] == System.DBNull.Value || string.IsNullOrEmpty(row["DEPT_NAME"].ToString())
                        || row["ASA_GRADE"] == System.DBNull.Value || string.IsNullOrEmpty(row["ASA_GRADE"].ToString())) continue;
                    if (deptName != row["DEPT_NAME"].ToString())
                    {
                        if (deptAsaGradeRow != null)
                        {
                            deptAsaGradeDataTable.AddDeptAsaGradeRow(deptAsaGradeRow);
                        }
                        deptName = row["DEPT_NAME"].ToString();
                        deptAsaGradeRow = deptAsaGradeDataTable.NewDeptAsaGradeRow();
                        deptAsaGradeRow.DEPT_NAME = deptName;
                        deptAsaGradeRow.YEAR = year;
                        deptAsaGradeRow.MONTH = month;
                    }

                    int count = (int)(decimal)row["Count"];
                    if (row["ASA_GRADE"].ToString().Equals("I"))
                    {
                        deptAsaGradeRow.一级 = count;
                    }
                    else if (row["ASA_GRADE"].ToString().Equals("Ⅱ"))
                    {
                        deptAsaGradeRow.二级 = count;
                    }
                    else if (row["ASA_GRADE"].ToString().Equals("Ⅲ"))
                    {
                        deptAsaGradeRow.三级 = count;
                    }
                    else if (row["ASA_GRADE"].ToString().Equals("Ⅳ"))
                    {
                        deptAsaGradeRow.四级 = count;
                    }
                    else if (row["ASA_GRADE"].ToString().Equals("Ⅴ"))
                    {
                        deptAsaGradeRow.五级 = count;
                    }
                }
                if (deptAsaGradeRow != null)
                {
                    deptAsaGradeDataTable.AddDeptAsaGradeRow(deptAsaGradeRow);
                }
                return deptAsaGradeDataTable;
            }
            else
            {
                AnesInformations.DeptAsaGradeDataTable data = new AnesInformations.DeptAsaGradeDataTable();
                database.Fill(sqlText, data, new DbParameter[] { yearParameter, monthParameter });
                return data;
                //return GetData<AnesInformations.DeptAsaGradeDataTable>(sqlText, new object[] { year, month });
            }
            //return new AnesInformationsTableAdapters.DeptAsaGradeAdapter().GetData(year, month);
        }

        public AnesInformations.AnesMethodTableDataTable GetAnesMethod(int year, int month)
        {
            AnesInformations.AnesMethodTableDataTable data = new AnesInformations.AnesMethodTableDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("AnesInformations_GetAnesMethod");
            DbParameter yearParameter = database.BuildDbParameter("Year", DbType.Int32, year);
            DbParameter monthParameter = database.BuildDbParameter("Month", DbType.Int32, month);

            database.Fill(sql, data, new DbParameter[] { yearParameter, monthParameter });
            return data;
            //return GetData<AnesInformations.AnesMethodTableDataTable>(GetSQL("AnesMethod"), new object[] { year, month });
            //return new AnesInformationsTableAdapters.AnesMethodTableAdapter().GetData(year, month);
        }

        /// <summary>
        /// 获取服务器系统时间
        /// </summary>
        /// <returns>服务器时间</returns>
        public DateTime GetSysDateTime()
        {

            //联网
            if (ConnectionMonitor.GetCurrentMonitor().IsConnected)
            {
                IDatabase database = DatabaseFactory.Create();
                DataTable data = new DataTable();
                data.TableName = "CurrentServerDateTime";
                database.Fill(StoredScript.Get("Common_GetSysDateTime"), data);

                if (data != null && data.Rows.Count > 0)
                {
                    return (DateTime)(data.Rows[0].ItemArray[0]);
                }
                return DateTime.Now;
            }
            else//断网
            {
                return DateTime.Now;
            }
    
        }

        public bool TestConnection(ref Exception err)
        {
            return DatabaseFactory.TestConnection(ref err);
        }

        public bool TestConnection(string providerName, string serverAddress, string dataBaseName, string userID, string password, bool isWindowUser, ref Exception err)
        {
            return DatabaseFactory.TestConnection(providerName, serverAddress, dataBaseName, userID, password, isWindowUser, ref err);
        }
        public bool IsSQLServer()
        {
            return DatabaseFactory.DefaultProviderName == DatabaseFactory.SqlClientProvider;
        }
        public bool IsOracle()
        {
            return DatabaseFactory.DefaultProviderName == DatabaseFactory.OracleClientProvider;
        }
        public int ExecuteNonQuery(string sqlText)
        {
            return DatabaseFactory.Create().ExecuteNonQuery(sqlText);
        }
        public object ExecuteScalar(string sqlText)
        {
            return DatabaseFactory.Create().ExecuteScalar(sqlText);
        }
        public DataTable GetDataWithPrimaryKey(string tableName)
        {

            IDatabase database = DatabaseFactory.Create();
            DataTable data = new DataTable();
            data.TableName = tableName;
            database.Fill(string.Format("select * from {0}", tableName), data);
            return data;
           // return DatabaseFactory.GetDataWithPrimaryKey(tableName);
        }

        public DataTable GetDataWithPrimaryKey(string tableName, string whereString)
        {
            return DatabaseFactory.GetDataWithPrimaryKey(tableName,whereString);
        }

        public DataTable GetDataWithPrimaryKey(string tableName, string whereString, object[] parameters)
        {
            return DatabaseFactory.GetDataWithPrimaryKey(tableName,whereString,parameters);
        }
        public int UpdateDataTable(DataTable dataTable)
        {
            return DatabaseFactory.UpdateDataTable(dataTable);
        }

        public int Update(DataTable data, string tableName)
        {
            IDatabase database = DatabaseFactory.Create();
            return  database.Update(data, tableName);
        }
        public DataTable GetDataFromSQLString(string sqlText)
        {
            return DatabaseFactory.GetDataFromSQLString(sqlText);
        }

        public DataTable GetDataFromSQLString(string sqlText, object[] parameters)
        {
            return DatabaseFactory.GetDataFromSQLString(sqlText,parameters);
        }

        public DataColumn[] GetPrimaryKey(string tableName)
        {
            return DatabaseFactory.GetPrimaryKey(tableName);
        }

        /// <summary>
        /// 获取日期查询字符串
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public string GetDateTimeQueryString(DateTime dateTime)
        {
            return DatabaseFactory.GetDateTimeQueryString(dateTime);
        }

        public string EncodeConnectionString(string connectionName, string providerName, string serverAddress, string dataBaseName, string userName, string password, bool isWindowUser)
        {
            return DatabaseFactory.EncodeConnectionString(connectionName, providerName, serverAddress, dataBaseName, userName, password, isWindowUser);
        }

        public void DecodeConnectionString(string connectionString, ref string connectionName, ref string providerName, ref string serverAddress, ref string dataBaseName, ref string userName, ref string password, ref bool isWindowUser)
        {
            DatabaseFactory.DecodeConnectionString(connectionString, ref connectionName, ref providerName, ref serverAddress, ref dataBaseName
                , ref userName, ref password, ref isWindowUser);
        }
        /// <summary>
        /// 删除患者-删除患者对应的所有相关资料
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        public void DeletePatient(string patientID, decimal visitID, decimal operID)
        {
            string whereString3 = " Where  PAT_ID = '" + patientID + "' and VISIT_ID = "
                + visitID.ToString();
            string whereString = " Where  PAT_ID = '" + patientID + "' and VISIT_ID = "
                + visitID.ToString() + " and OPER_ID = " + operID.ToString();
            string whereString2 = " Where  PAT_ID = '" + patientID + "'";
            string whereString1 = " Where  PAT_ID = '" + patientID + "' and VISIT_ID = "
                + visitID.ToString() + " and SCHEDULE_ID = " + operID.ToString();
            
            DatabaseFactory.Create().ExecuteNonQuery("Delete From WIS_ANES_NURSE " + whereString);
            DatabaseFactory.Create().ExecuteNonQuery("Delete From WIS_ANES_PLAN " + whereString);
            DatabaseFactory.Create().ExecuteNonQuery("Delete From WIS_ANES_RECOVERY " + whereString);
            DatabaseFactory.Create().ExecuteNonQuery("Delete From WIS_ANES_SUMMARY " + whereString);

            DatabaseFactory.Create().ExecuteNonQuery("Delete From WIS_CUSTOM_DATA " + whereString);
            DatabaseFactory.Create().ExecuteNonQuery("Delete From WIS_ANES_INQUIRY " + whereString);

            DatabaseFactory.Create().ExecuteNonQuery("Delete From WIS_OPER_MASTER " + whereString);
            DatabaseFactory.Create().ExecuteNonQuery("Delete From WIS_PATIENT_MONITOR_DATA " + whereString);

            DatabaseFactory.Create().ExecuteNonQuery("Delete From WIS_OPER_NAME " + whereString);
            DatabaseFactory.Create().ExecuteNonQuery("Delete From WIS_PAT_MONITOR_DATA " + whereString);
            DatabaseFactory.Create().ExecuteNonQuery("Delete From WIS_PAT_MONITOR_DATA_HISTORY " + whereString);
            DatabaseFactory.Create().ExecuteNonQuery("Delete From WIS_PAT_MASTER_INDEX " + whereString2);
            DatabaseFactory.Create().ExecuteNonQuery("Delete From WIS_PAT_VISIT " + whereString3);
            DatabaseFactory.Create().ExecuteNonQuery("Delete From WIS_PAT_IN_HOS " + whereString3);
            DatabaseFactory.Create().ExecuteNonQuery("Delete From WIS_OPER_SCHEDULE " + whereString1);
            DatabaseFactory.Create().ExecuteNonQuery("Delete From WIS_SCHEDULE_OPER_NAME " + whereString1);
        }


        //专家咨询
        public DataTable GetAcsContextByKeyWord(string keyWord)
        {

            DataTable dataTable = new DataTable();
            IDatabase database = DatabaseFactory.Create("AcsConn");
            string sql = StoredScript.Get("Acs_GetAcsContextByKeyWord");
            sql += " '%"+keyWord+"%'" ;

            database.Fill(sql, dataTable);
            return dataTable;


        }

        //专家咨询
        public DataTable GetAcsArticleKeyWord()
        {

            DataTable dataTable = new DataTable();
            IDatabase database = DatabaseFactory.Create("AcsConn");
            database.Fill("SELECT * FROM STANDARD_ARTICLE_KEYWORD ", dataTable);
            return dataTable;


        }

        //专家咨询
        public String GetApplicationVision()
        {

            string applicationVision = StoredScript.Get("Common_GetApplicationVision");
            return applicationVision;


        }



        //上传本地数据到服务器
        public void UpLoadDataToServer(DataSet ds)
        {
            DatabaseFactory.UpLoadDataToServer(ds);
        }

    }
}
