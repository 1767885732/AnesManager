using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Devart.Data.Oracle;
using System.Configuration;

namespace Wis.Anes.Data.Database
{
    public class DevartOracleDatabase : IDatabase
    {
       private string _connectionString = string.Empty;

       public DevartOracleDatabase(string connectionString)
       {
           if(string.IsNullOrEmpty(connectionString))
               throw new ArgumentNullException("连接字符串不能为空");

           _connectionString = connectionString;
       }
        /// <summary>
        /// 根据指定的查询语句，将数据填充到数据表中
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="data">数据表</param>
       /// <returns>数据表</returns>
        public DataTable Fill(string sql, DataTable data)
        {
            DataTable dt = Fill(sql, data, null);

 
            return dt;
        }
        /// <summary>
        /// 根据指定的查询语句，参数,将数据填充到数据表中
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="data">数据表</param>
        /// <param name="parameters">参数</param>
        /// <returns>数据表</returns>
        public DataTable Fill(string sql, DataTable data, DbParameter[] parameters)
        {
            using (OracleDataAdapter adapter = new OracleDataAdapter(sql, _connectionString))
            {
                try
                {
                   
                    if (parameters != null)
                    {
                        adapter.SelectCommand.Parameters.AddRange(parameters);
                    }


                    //if (data.TableName == "")
                    //{ 
                    
                    
                    //}

                    if (!LocalConfig.LocalMode && ConnectionMonitor.GetCurrentMonitor().IsConnected)
                    {
                        adapter.Fill(data);
                        //add by zzc Update 时把数据更新到本地文件 20140318
                        DatabaseFactory.AddTableToDataSet(data, false);
                    }
                    else
                    {
                        LoadDataRow(sql, data, parameters);
                    }
                }
                catch (Exception ex)
                {
                  
                    DatabaseFactory.ThrowDataAccessException(ex);
                 
                }
                finally
                {
                    adapter.Dispose();
                }

                return data;
            }
        }

        private void LoadDataRow(string sql, DataTable data, DbParameter[] parameters)
        {
            DataTable dt = DatabaseFactory.GetTableFromDataSet(data.TableName);
            if (dt == null)
            {
                return;
            }



            //
            if (data.TableName == "PatientListDataTable")
            {

                dt.Clear();
       
                DataTable dtMaster = DatabaseFactory.GetTableFromDataSet("OperationMaster");
                DataTable dtPatIndex = DatabaseFactory.GetTableFromDataSet("PatMasterIndex");

                string patientId = "" ;
                for (int i = 0 ;i <dtMaster.Rows.Count ; i ++ )
                {
                    patientId = dtMaster.Rows[i]["PAT_ID"].ToString();
                    DataRow[] patRows = dtPatIndex.Select("PAT_ID = '" + patientId+ "'") ;


                    DataRow rowPatInList = dt.NewRow();
                    //遍历patientList
                    for (int iList = 0; iList < dt.Columns.Count; iList++)
                    {
                     

                        if (dt.Columns[iList].ColumnName == "START_DATE_TIME")
                        {
                            if (dtMaster.Rows[i]["IN_DATE_TIME"] == null )
                            { 
                                rowPatInList["START_DATE_TIME"] = dtMaster.Rows[i]["SCHEDULED_DATE_TIME"] ;
                            }
                            else
                            {
                                rowPatInList["START_DATE_TIME"] = dtMaster.Rows[i]["IN_DATE_TIME"];
                            }
                        }
                        else if (dtMaster.Columns.Contains( dt.Columns[iList].ColumnName))
                        {
                            rowPatInList[dt.Columns[iList].ColumnName] = dtMaster.Rows[i][dt.Columns[iList].ColumnName];
                        }
                        else if (patRows != null && patRows.Length > 0 && dtPatIndex.Columns.Contains(dt.Columns[iList].ColumnName))
                        {
                            rowPatInList[dt.Columns[iList].ColumnName] = patRows[0][dt.Columns[iList].ColumnName];
                        }
                    
                    }


                    //增加联合列
                    dt.Rows.Add(rowPatInList);
                    
                }


                //data.Merge(dt);
                //return;
            }


            if (dt.Rows.Count == 0 )
            {
                return;
            }
                
            //转大写
            string SQLTemp = sql.ToUpper();
            string SQLTempRowFilter = "";
            string SQLTempSort = "";



            //去掉连续的空格
            while (SQLTemp.Contains("  "))
            {
                SQLTemp = SQLTemp.Replace("  ", " ");
            }


            //参数处理
            if (parameters != null)
            {
                int index = 0;
                for (int i = 0; i < parameters.Length; i++)
                {
                    SQLTemp = SQLTemp.Replace(":" + parameters[i].ToString().ToUpper(), "'"+parameters[i].Value.ToString().ToUpper()+"'");
                    index = i;

                }
            }


            //排序判断 最后面的 "ORDER BY"
            if (SQLTemp.Contains("ORDER BY"))
            {
                SQLTempSort = SQLTemp.Substring(SQLTemp.LastIndexOf("ORDER BY") + 8, SQLTemp.Length - SQLTemp.LastIndexOf("ORDER BY") - 8);
                SQLTemp = SQLTemp.Substring(0, SQLTemp.Length - SQLTempSort.Length - ("ORDER BY").Length);
            }



            //判断  最后面的 "WHERE"
            if (SQLTemp.Contains("WHERE"))
            {
                SQLTempRowFilter = SQLTemp.Substring(SQLTemp.LastIndexOf("WHERE") + 5, SQLTemp.Length - SQLTemp.LastIndexOf("WHERE") - 5);
            }



            dt.DefaultView.Sort = SQLTempSort;
            dt.DefaultView.RowFilter = SQLTempRowFilter;


            DataTable dtNew = dt.DefaultView.ToTable();
            data.Merge(dtNew);


        }

        public DataSet Fill(string sql, DataSet dataSet, string tableName)
        {
            return Fill(sql, null, dataSet, tableName); ;
        }

        public DataSet Fill(string sql, DbParameter parameters, DataSet dataSet, string tableName)
        {
            using (OracleDataAdapter adapter = new OracleDataAdapter(sql, _connectionString))
            {
                if (parameters != null)
                {
                    adapter.SelectCommand.Parameters.Add(parameters);
                }
                adapter.Fill(dataSet, tableName);
                return dataSet;
            }
        }
        /// <summary>
        /// 执行指定的SQL语句，并返回受影响的行数
        /// </summary>
        /// <param name="sql">SQL</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNonQuery(string sql)
        {
            return ExecuteNonQuery(sql, null,null);
           
        }
        /// <summary>
        /// 执行指定的SQL语句，并返回受影响的行数
        /// </summary>
        /// <param name="sql">SQL</param>
        /// <param name="parameter">参数</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNonQuery(string sql, DbParameter[] parameter)
        {
            return ExecuteNonQuery(sql, parameter, null);
            
        }
       
        /// <summary>
        /// 保存数据,并自动调用相应的Insert,Update,Delete语句
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Update(DataTable data, string tableName)
        {

            return Update(data, tableName, null);
        }
        /// <summary>
        /// 保存数据,并自动调用相应的Insert,Update,Delete语句
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Update(DataTable data)
        {
            return Update(data, data.TableName);
        }
        /// <summary>
        /// 执行指定的查询，并返回第一行，第一列的结果
        /// </summary>
        /// <param name="sql">SQL</param>
        /// <returns>结果</returns>
        public object ExecuteScalar(string sql)
        {
            return ExecuteScalar(sql, null);
        }
        /// <summary>
        /// 执行指定的查询，并返回结果中的第一行，第一列数据
        /// </summary>
        /// <param name="sql">SQL</param>
        /// <param name="parameters">参数</param>
        /// <returns>结果</returns>
        public object ExecuteScalar(string sql, DbParameter[] parameters)
        {
            OracleConnection connection = new OracleConnection(_connectionString);
            try
            {
                connection.Open();
                OracleCommand command = new OracleCommand(sql, connection);
                command.CommandType = CommandType.Text;
                if (parameters != null)
                    command.Parameters.AddRange(parameters);
                object result = command.ExecuteScalar();
                return result;
            }
            catch (Exception ex)
            {
                DatabaseFactory.ThrowDataAccessException(ex);
                return null;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        /// <summary>
        /// 生成查询参数
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="dbType"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public DbParameter BuildDbParameter(string parameterName, DbType dbType, object value)
        {
            OracleParameter parameter = new OracleParameter(string.Format(@":{0}", parameterName), dbType);
            parameter.Value = value;
            return parameter;
        }

        /// <summary>
        ///  执行指定的SQL语句，并返回受影响的行数,并添加事务
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql, DbWrapTransaction transaction)
        {
            return ExecuteNonQuery(sql, null, transaction);
        }
        /// <summary>
        ///  执行指定的SQL语句，并返回受影响的行数,并添加事务
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameter"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql, DbParameter[] parameter, DbWrapTransaction transaction)
        {
            OracleConnection connection = transaction == null ? new OracleConnection(_connectionString) : transaction.InnerDbConnection as OracleConnection;
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                OracleCommand command = new OracleCommand(sql, connection);
                command.CommandType = CommandType.Text;
                if (parameter != null)
                    command.Parameters.AddRange(parameter);
                if (transaction != null)
                    command.Transaction = transaction.InnerDbTransaction as OracleTransaction;
                int i = command.ExecuteNonQuery();
                return i;
            }
            catch (Exception ex)
            {
                DatabaseFactory.ThrowDataAccessException(ex);
                return -1;
            }
            finally
            {
                if (transaction == null)
                {
                    connection.Close();
                    connection.Dispose();
                }

            }
        }
        /// <summary>
        /// 保存数据,并自动调用相应的Insert,Update,Delete语句,并支持事务
        /// </summary>
        /// <param name="data"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public int Update(DataTable data, DbWrapTransaction transaction)
        {
            return Update(data, data.TableName, transaction);
        }

        public byte[] Str2Arr(String s)
        {
            return (new UnicodeEncoding()).GetBytes(s);
        }

        public string Arr2Str(byte[] buffer)
        {
            return (new UnicodeEncoding()).GetString(buffer, 0, buffer.Length);
        }

        public string DecodeString(string base64String)
        {
            byte[] binaryData;
            binaryData = System.Convert.FromBase64String(base64String);
            return Arr2Str(binaryData);
        }

        /// <summary>
        /// 保存数据,并自动调用相应的Insert,Update,Delete语句,并支持事务
        /// </summary>
        /// <param name="data"></param>
        /// <param name="tableName"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public int Update(DataTable data, string tableName, DbWrapTransaction transaction)
        {
            if (tableName.ToLower().Equals("WIS_ANES_DOC") || tableName.ToLower().Equals("WIS_ANES_DOC_TEMPLET") || tableName.ToLower().Equals("WIS_CONF_INDEX") || tableName.ToLower().Equals("WIS_CONF_PAT_MONITOR"))
            {
                string sql = string.Format("select * from {0} where 1=2", tableName);

                OracleDataAdapter adapter = transaction == null ? new OracleDataAdapter(sql, _connectionString) : new OracleDataAdapter(sql, transaction.InnerDbConnection as OracleConnection);

                OracleCommandBuilder commandBuilder = new OracleCommandBuilder(adapter);

                commandBuilder.ConflictOption = ConflictOption.OverwriteChanges;
                if (transaction != null)
                {
                    OracleTransaction oracleTransaction = transaction.InnerDbTransaction as OracleTransaction;
                    if (commandBuilder.DataAdapter.InsertCommand != null)
                        commandBuilder.DataAdapter.InsertCommand.Transaction = oracleTransaction;
                    if (commandBuilder.DataAdapter.DeleteCommand != null)
                        commandBuilder.DataAdapter.DeleteCommand.Transaction = oracleTransaction;
                    if (commandBuilder.DataAdapter.UpdateCommand != null)
                        commandBuilder.DataAdapter.UpdateCommand.Transaction = oracleTransaction;
                    if (commandBuilder.DataAdapter.SelectCommand != null)
                        commandBuilder.DataAdapter.SelectCommand.Transaction = oracleTransaction;
                }
                try
                {
                    if (tableName.ToLower().Equals("WIS_CUSTOM_DATA"))
                    {
                        int i = 0;
                        if (data != null && data.Rows.Count > 0)
                        {
                            foreach (DataRow row in data.Rows)
                            {
                                i += UpdateCustomData(row["PAT_ID"], row["VISIT_ID"], row["OPER_ID"], row["ITEM_NAME"], row["ITEM_VALUE"]);
                            }
                        }
                        return i;
                    }
                    else
                    {
                        //add by zzc Update 时把数据更新到本地文件 20140318
                        DatabaseFactory.AddTableToDataSet(data, true);

                        if (!LocalConfig.LocalMode && ConnectionMonitor.GetCurrentMonitor().IsConnected)
                        {
                            int i = commandBuilder.DataAdapter.Update(data);
                            return i;
                        }
                        else
                        {
                            return data.Rows.Count;
                        }
                    }
                }
                catch (Exception ex)
                {
                    DatabaseFactory.ThrowDataAccessException(ex);
                    return -1;
                }
                finally
                {
                    if (transaction == null)
                    {
                        adapter.Dispose();
                    }
                }
            }
            else
            {
                string connection = ConfigurationManager.AppSettings["DevartOleConnection"];
                if (string.IsNullOrEmpty(connection))
                {
                    connection = "Provider=MSDAORA;Data Source=docare;Persist Security Info=True;Password=MedSurgery;User ID=MedSurgery";
                }
                else
                {
                    connection = DecodeString(connection);
                }

    

                return new OledbDatabase(connection).Update(data, tableName, transaction) ;
            }
        }

        private int UpdateCustomData(object patientID, object visitID, object operID, object itemName, object itemValue)
        {
            string sql = "SELECT * FROM WIS_CUSTOM_DATA WHERE PAT_ID = '" + patientID.ToString() + "' AND VISIT_ID = " + visitID.ToString() 
                + " AND OPER_ID = " + operID.ToString() + " AND ITEM_NAME = '" + itemName.ToString() + "'";
            DataTable dataTable = new DataTable();
            Fill(sql, dataTable);

            //modify by zzc 
            #region 
            //if(dataTable.Rows.Count == 1)
            //{
            //    string value = (itemValue == System.DBNull.Value)?"":itemValue.ToString();
            //    sql = "UPDATE WIS_CUSTOM_DATA SET ITEM_VALUE = '" + value + "' WHERE PAT_ID = '" + patientID.ToString() + "' AND VISIT_ID = " + visitID.ToString()
            //        + " AND OPER_ID = " + operID.ToString() + " AND ITEM_NAME = '" + itemName.ToString() + "'";
            //    return ExecuteNonQuery(sql);
            //}
            //else if (dataTable.Rows.Count == 0)
            //{
            //    string value = (itemValue == System.DBNull.Value) ? "" : itemValue.ToString();
            //    sql = "INSERT INTO WIS_CUSTOM_DATA (ITEM_VALUE,PAT_ID,VISIT_ID,OPER_ID,ITEM_NAME) VALUES('" + value + "','" + patientID.ToString() + "'," + visitID.ToString()
            //        + "," + operID.ToString() + ",'" + itemName.ToString() + "')";
            //    return ExecuteNonQuery(sql);
            //}
            string value = (itemValue == System.DBNull.Value) ? "" : itemValue.ToString();
            if (dataTable.Rows.Count == 1)
            {
               

                dataTable.Rows[0]["ITEM_VALUE"] = value;
                Update(dataTable);
            
            }
            else if (dataTable.Rows.Count == 0)
            {
                DataRow row = dataTable.NewRow();
                row["PAT_ID"] = patientID.ToString();
                row["VISIT_ID"] = visitID.ToString();
                row["OPER_ID"] = operID.ToString();
                row["ITEM_NAME"] = itemName.ToString();
                row["ITEM_VALUE"] = value;
                dataTable.Rows.Add(row);
                Update(dataTable);
            }
            #endregion

            return -1;
        }
        /// <summary>
        /// 根据拿指定的SQL语句生成DataAdapter
        /// </summary>
        /// <param name="data"></param>
        /// <param name="tableName"></param>
        /// <param name="sqlWidthColmns"></param>
        /// <returns></returns>
        public int Update(string sqlWidthColmns, DataTable data)
        {


            OracleDataAdapter adapter = new OracleDataAdapter(sqlWidthColmns, _connectionString);

            OracleCommandBuilder commandBuilder = new OracleCommandBuilder(adapter);

            commandBuilder.ConflictOption = ConflictOption.OverwriteChanges;

            try
            {
                //add by zzc Update 时把数据更新到本地文件 20140318
                DatabaseFactory.AddTableToDataSet(data, true);

                if (!LocalConfig.LocalMode && ConnectionMonitor.GetCurrentMonitor().IsConnected)
                {
                    int i = commandBuilder.DataAdapter.Update(data);
                    return i;
                }
                else
                {
                    return data.Rows.Count;
                }
            }
            catch (Exception ex)
            {
                DatabaseFactory.ThrowDataAccessException(ex);
                return -1;
            }
            finally
            {

                adapter.Dispose();

            }
        }
        /// <summary>
        /// 创建一个事务
        /// </summary>
        /// <returns></returns>
        public DbWrapTransaction CreateDbTransaction()
        {
           
            DbWrapTransaction dbWrapTransaction = new DbWrapTransaction(new OracleConnection(_connectionString));
            return dbWrapTransaction;

        }

        public DbConnection CreateConnection()
        {
            return new OracleConnection(_connectionString);
        }

        public DbDataAdapter CreateDbDataAdapter()
        {
            OracleDataAdapter adapter = new OracleDataAdapter();
            DbConnection connection = CreateConnection();
            adapter.SelectCommand = (OracleCommand)connection.CreateCommand();
            return adapter;
        }

        public DbCommandBuilder CreateDbCommandBuilder()
        {
            return new OracleCommandBuilder();
        }

        public T GetTable<T>(string tableName) where T : DataTable
        {
            string sql = "SELECT * FROM " + tableName;
            Type type = typeof(T);
            T dataTable = (T)type.Assembly.CreateInstance(type.FullName);
            Fill(sql, dataTable);
            return dataTable;
        }
      
      
    }
}
