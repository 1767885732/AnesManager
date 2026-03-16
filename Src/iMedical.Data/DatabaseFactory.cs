using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Wis.Anes.Data.Database;
using System.Data.Common;
using System.Data;
using System.IO;

namespace Wis.Anes.Data
{
    public static  class DatabaseFactory
    {
        private class DataBaseConfig
        {
            public string ConnectionName;
            public string ProviderName;
            public string ServerAddress;
            public string DataBaseName;
            public string UserName;
            public string Password;
            public bool IsWindowUser;

            public DataBaseConfig() { }
            public DataBaseConfig(string connectionName, string providerName, string serverAddress, string dataBaseName, string userName, string password, bool isWindowUser)
            {
                ConnectionName = connectionName;
                ProviderName = providerName;
                ServerAddress = serverAddress;
                DataBaseName = dataBaseName;
                UserName = userName;
                Password = password;
                IsWindowUser = isWindowUser;
            }

            public void Decode(string connectionString)
            {
                Stream stream = DecodeWithString(connectionString);
                stream.Position = 0;
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(stream);
                if (dataSet.Tables.Count > 0)
                {
                    DataTable dt = dataSet.Tables[0];
                    ConnectionName = dt.TableName;
                    ProviderName = dt.Rows[0][0].ToString();
                    ServerAddress = dt.Rows[1][0].ToString();
                    DataBaseName = dt.Rows[2][0].ToString();
                    UserName = dt.Rows[3][0].ToString();
                    Password = dt.Rows[4][0].ToString();
                    if (dt.Rows.Count > 5)
                    {
                        bool isWindowUser = false;
                        if (!bool.TryParse(dt.Rows[5][0].ToString(), out isWindowUser)) isWindowUser = false;
                        IsWindowUser = isWindowUser;
                    }
                    else
                    {
                        IsWindowUser = false;
                    }
                }
            }

            public string Encode()
            {
                DataTable dt = new DataTable();
                dt.TableName = ConnectionName;
                dt.Columns.Add("Item");
                DataRow dr = dt.NewRow();
                dr[0] = ProviderName;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr[0] = ServerAddress;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr[0] = DataBaseName;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr[0] = UserName;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr[0] = Password;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr[0] = IsWindowUser.ToString();
                dt.Rows.Add(dr);
                MemoryStream stream = new MemoryStream();
                dt.WriteXml(stream, XmlWriteMode.IgnoreSchema);
                stream.Position = 0;
                return EncodeWithString(stream);
            }

            private string EncodeWithString(Stream stream)
            {
                byte[] binaryData = StreamToBytes(stream);
                return System.Convert.ToBase64String(binaryData, 0, binaryData.Length);
            }

            private byte[] StreamToBytes(Stream stream)
            {
                byte[] result = new byte[stream.Length];
                stream.Read(result, 0, (int)stream.Length);
                return result;
            }

            private Stream DecodeWithString(string base64String)
            {
                byte[] binaryData;
                binaryData = System.Convert.FromBase64String(base64String);
                Stream stream = new MemoryStream(binaryData);
                return stream;
            }
        }

        private class MyDataAdapter
        {
            public const string SQLConnectionString = "docare";

            private DbDataAdapter _dataAdapter;
            private string _connectionString;
            private string _providerName;
            private static bool islocal;

            public static bool Islocal
            {
                get { return islocal; }
                set { islocal = value; }
            }

            public DbDataAdapter DataAdapter
            {
                get
                {
                    return _dataAdapter;
                }
            }

            public MyDataAdapter() : this(SQLConnectionString) { }

            public MyDataAdapter(string connectionName)
            {
                if (islocal)
                {
                    connectionName = "Medicalsystem.Anes.BusinessEntity.Properties.Settings.Default.OleConnectionString";
                }
                GenFromConnectionName(connectionName);
            }
            public MyDataAdapter(string provid, string constr)
            {
                _providerName = provid;
                _connectionString = constr;
            }
            public MyDataAdapter(string providerName, string serverAddress, string dataBaseName, string userID, string password, bool isWindowUser)
            {
                GenConnectionString(providerName, GetConnectionString(providerName, serverAddress, dataBaseName, userID, password, isWindowUser));
            }

            public DbConnection GetConnection()
            {
                return DbProviderFactories.GetFactory(_providerName).CreateConnection();
            }

            private static Dictionary<string, string> _connectionStrings = new Dictionary<string, string>();
            public static void SetConnectionName(string connectionName, string connectionString)
            {
                if (!_connectionStrings.ContainsKey(connectionName))
                {
                    _connectionStrings.Add(connectionName, connectionString);
                }
                else
                {
                    _connectionStrings[connectionName] = connectionString;
                }
            }

            private void GenFromConnectionName(string connectionName)
            {
                string connString = null;
                if (_connectionStrings.ContainsKey(connectionName))
                {
                    connString = _connectionStrings[connectionName];
                }
                else
                {
                    connString = ConfigurationManager.AppSettings[connectionName];
                }
                if (!string.IsNullOrEmpty(connString))
                {
                    DataBaseConfig dbConfig = new DataBaseConfig();
                    dbConfig.Decode(connString);
                    GenConnectionString(dbConfig.ProviderName, GetConnectionString(dbConfig.ProviderName, dbConfig.ServerAddress, dbConfig.DataBaseName, dbConfig.UserName, dbConfig.Password, dbConfig.IsWindowUser));
                }
            }

            private string GetConnectionString(string providerName, string serverAddress, string dataBaseName, string userID, string password, bool isWindowUser)
            {
                string connString = "";
                if (providerName.ToLower().Equals("system.data.oracleclient"))
                {
                    string useDevart = ConfigurationManager.AppSettings["UseDevart"];
                    if (!string.IsNullOrEmpty(useDevart) && useDevart.ToLower().Equals("true"))
                    {
                        connString = string.Format("Data Source={0};Persist Security Info=True;User ID={1};Password={2};", new object[] { serverAddress, userID, password });
                    }
                    else
                    {
                        connString = string.Format("Data Source={0};Persist Security Info=True;User ID={1};Password={2};Unicode=True", new object[] { serverAddress, userID, password });
                    }
                }
                else if (providerName.ToLower().Equals("system.data.sqlclient"))
                {
                    connString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};Integrated Security={4}", new object[] { serverAddress, dataBaseName, userID, password, isWindowUser.ToString() });
                }
                else if (providerName.ToLower().Equals("system.data.oledb"))
                {
                    connString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}{1}.mdb;Jet OLEDB:Database Password={2};Persist Security Info={3}", new object[] { serverAddress, dataBaseName, password, isWindowUser.ToString() });
                }
                return connString;
            }

            private void GenConnectionString(string providerName, string connectionString)
            {
                _providerName = providerName;
                _connectionString = connectionString;
            }

            private DbParameter CreateParameter(string parameterName, object value)
            {
                if (_providerName != null && _connectionString != null)
                {
                    DbProviderFactory factory = DbProviderFactories.GetFactory(_providerName);
                    DbParameter parameter = factory.CreateParameter();
                    parameter.ParameterName = parameterName;
                    parameter.DbType = (DbType)Enum.Parse(typeof(DbType), value.GetType().Name);
                    parameter.Value = value;
                    return parameter;
                }
                return null;
            }

            private void Test(string sqlText, object[] values, string paraStr)
            {
                int idx = 0;
                int index = 0;
                index = sqlText.IndexOf(paraStr, index + 1);
                while (index > 0 && idx < values.Length)
                {
                    string aaa = sqlText.Substring(index);
                    int index1 = aaa.IndexOf(" ");
                    if (index1 > 0)
                    {
                        aaa = aaa.Substring(0, index1);
                    }
                    index1 = aaa.IndexOf(")");
                    if (index1 > 0)
                    {
                        aaa = aaa.Substring(0, index1);
                    }
                    index1 = aaa.IndexOf(",");
                    if (index1 > 0)
                    {
                        aaa = aaa.Substring(0, index1);
                    }
                    index1 = aaa.IndexOf("\r");
                    if (index1 > 0)
                    {
                        aaa = aaa.Substring(0, index1);
                    }
                    index1 = aaa.IndexOf("\n");
                    if (index1 > 0)
                    {
                        aaa = aaa.Substring(0, index1);
                    }
                    if (_dataAdapter.SelectCommand.Parameters == null || _dataAdapter.SelectCommand.Parameters.Count == 0
                        || !_dataAdapter.SelectCommand.Parameters.Contains(aaa))
                    {
                        DbParameter parameter = CreateParameter(aaa, values[idx++]);
                        if (parameter != null)
                        {
                            _dataAdapter.SelectCommand.Parameters.Add(parameter);
                        }
                    }
                    index = sqlText.IndexOf(paraStr, index + 1);
                }
            }

            public void SetSQL(string sqlText) { SetSQL(sqlText, null, true); }
            public void SetSQL(string sqlText, bool createOtherCommand) { SetSQL(sqlText, null, createOtherCommand); }
            public void SetSQL(string sqlText, object[] parameters) { SetSQL(sqlText, parameters, true); }
            public void SetSQL(string sqlText, object[] parameters, bool createOtherCommand)
            {
                if (_providerName != null && _connectionString != null)
                {
                    string useDevart = ConfigurationManager.AppSettings["UseDevart"];
                    string transSql = sqlText;
                    if (_providerName.ToLower().Equals("System.Data.OracleClient".ToLower()) && !string.IsNullOrEmpty(useDevart) && useDevart.ToLower().Equals("true"))
                    {
                        _dataAdapter = new Devart.Data.Oracle.OracleDataAdapter();
                        Devart.Data.Oracle.OracleCommandBuilder dbCommandBuilder = new Devart.Data.Oracle.OracleCommandBuilder();
                        Devart.Data.Oracle.OracleCommand dbCommand = new Devart.Data.Oracle.OracleCommand();
                        Devart.Data.Oracle.OracleConnection dbConnection = new Devart.Data.Oracle.OracleConnection();
                        dbConnection.ConnectionString = _connectionString;
                        dbCommand.Connection = dbConnection;
                        _dataAdapter.SelectCommand = dbCommand;
                        //if (_dataAdapter is System.Data.OracleClient.OracleDataAdapter)
                        //{
                        //    transSql = transSql.Replace("@", ":");
                        //}
                        dbCommand.CommandText = transSql;
                        if (parameters != null && parameters.Length > 0)
                        {
                            if (parameters is DbParameter[])
                            {
                                dbCommand.Parameters.AddRange(parameters);
                            }
                            else
                            {
                                //Test(sqlText, parameters);
                                string paraStr = "@";
                                if (_dataAdapter is System.Data.OracleClient.OracleDataAdapter)
                                {
                                    paraStr = ":";
                                }
                                Test(transSql, parameters, paraStr);
                            }
                        }
                        if (_dataAdapter is System.Data.OracleClient.OracleDataAdapter && dbCommand.Parameters != null)
                        {
                            foreach (DbParameter parameter in dbCommand.Parameters)
                            {
                                parameter.ParameterName = parameter.ParameterName.Replace("@", ":");
                            }
                        }
                        if (createOtherCommand)
                        {
                            dbCommandBuilder.DataAdapter = (Devart.Data.Oracle.OracleDataAdapter)_dataAdapter;
                            try
                            {
                                _dataAdapter.DeleteCommand = dbCommandBuilder.GetDeleteCommand();
                                _dataAdapter.UpdateCommand = dbCommandBuilder.GetUpdateCommand();
                                _dataAdapter.InsertCommand = dbCommandBuilder.GetInsertCommand();
                            }
                            catch { }
                        }
                    }
                    else
                    {
                        DbProviderFactory factory = DbProviderFactories.GetFactory(_providerName);
                        _dataAdapter = factory.CreateDataAdapter();
                        DbCommandBuilder dbCommandBuilder = factory.CreateCommandBuilder();
                        DbCommand dbCommand = factory.CreateCommand();
                        DbConnection dbConnection = factory.CreateConnection();
                        dbConnection.ConnectionString = _connectionString;
                        dbCommand.Connection = dbConnection;
                        _dataAdapter.SelectCommand = dbCommand;
                        if (_dataAdapter is System.Data.OracleClient.OracleDataAdapter)
                        {
                            transSql = transSql.Replace("@", ":");
                        }
                        dbCommand.CommandText = transSql;
                        if (parameters != null && parameters.Length > 0)
                        {
                            if (parameters is DbParameter[])
                            {
                                dbCommand.Parameters.AddRange(parameters);
                            }
                            else
                            {
                                //Test(sqlText, parameters);
                                string paraStr = "@";
                                if (_dataAdapter is System.Data.OracleClient.OracleDataAdapter)
                                {
                                    paraStr = ":";
                                }
                                Test(transSql, parameters, paraStr);
                            }
                        }
                        if (_dataAdapter is System.Data.OracleClient.OracleDataAdapter && dbCommand.Parameters != null)
                        {
                            foreach (DbParameter parameter in dbCommand.Parameters)
                            {
                                parameter.ParameterName = parameter.ParameterName.Replace("@", ":");
                            }
                        }
                        if (createOtherCommand)
                        {
                            dbCommandBuilder.DataAdapter = _dataAdapter;
                            try
                            {
                                _dataAdapter.DeleteCommand = dbCommandBuilder.GetDeleteCommand();
                                _dataAdapter.UpdateCommand = dbCommandBuilder.GetUpdateCommand();
                                _dataAdapter.InsertCommand = dbCommandBuilder.GetInsertCommand();
                            }
                            catch { }
                        }
                    }
                }
            }

        }

        public const string defaultConnectionStringName = "docare";
        public const string oldDbConnectionStringName = "Medicalsystem.Anes.BusinessEntity.Properties.Settings.Default.OleConnectionString";

        public const string OracleClientProvider = "system.data.oracleclient";
        public const string SqlClientProvider = "system.data.sqlclient";
        public const string OleDbProvider = "system.data.oledb";

        private static string _providerName = string.Empty;
        private static string _connectionString = string.Empty;


        public static DataSet AnesInfoAllDataSet = new DataSet();
        public static DataSet AnesDictDataSet = new DataSet();
        public static Dictionary<string, string> AliasDict = new Dictionary<string, string>();


        public static string DefaultProviderName
        {
            get
            {
                 return _providerName;
            }
        }

        private static void Init(bool throwErr)
        {
            if (string.IsNullOrEmpty(_providerName))
            {
                string encryptedString = ConfigurationManager.AppSettings[DatabaseFactory.defaultConnectionStringName];
                if (string.IsNullOrEmpty(encryptedString))
                {
                    if (throwErr)
                    {
                        throw new ConfigurationErrorsException(string.Format("配置文件中找不到名为'{0}'的默认数据库库连接字符串", DatabaseFactory.defaultConnectionStringName));
                    }
                }
                else
                {
                    EncryptionDecryptionHelper decryption = new EncryptionDecryptionHelper();
                    string useDevart = ConfigurationManager.AppSettings["UseDevart"];
                    if (!string.IsNullOrEmpty(useDevart) && useDevart.ToLower().Equals("true"))
                    {
                        _connectionString = decryption.Decode(encryptedString).Replace("Unicode=True;", "").Replace("Unicode=True", "");
                    }
                    else
                    {
                        _connectionString = decryption.Decode(encryptedString);
                    }
                    _providerName = decryption.ProviderName.ToLower();
                }
            }
        }
            
        public static IDatabase Create()
        {
            Init(false);
            if (string.IsNullOrEmpty(_providerName))
            {
                return null;
            }
            else
            {
                return Create(_connectionString, _providerName);
            }
        }

        public static IDatabase Create(string connectionStringName)
        {
            string encryptedString = ConfigurationManager.AppSettings[connectionStringName];
            if (string.IsNullOrEmpty(encryptedString))
            {
                encryptedString = ConfigurationManager.AppSettings[DatabaseFactory.defaultConnectionStringName];
            }
            if (string.IsNullOrEmpty(encryptedString))
            {
                throw new ConfigurationErrorsException(string.Format("配置文件中找不到名为'{0}'的数据库库连接字符串", connectionStringName));
            }
            EncryptionDecryptionHelper decryption = new EncryptionDecryptionHelper();
            string useDevart = ConfigurationManager.AppSettings["UseDevart"];
            string connectionString;
            if (!string.IsNullOrEmpty(useDevart) && useDevart.ToLower().Equals("true"))
            {
                connectionString = decryption.Decode(encryptedString).Replace("Unicode=True;", "").Replace("Unicode=True", "");
            }
            else
            {
                connectionString = decryption.Decode(encryptedString);
            }
            return Create(connectionString, decryption.ProviderName.ToLower());
        }

        private static IDatabase Create(string connectionString,string providerName)
        {
            if (providerName == DatabaseFactory.OracleClientProvider)
            {
                string useDevart = ConfigurationManager.AppSettings["UseDevart"];
                if (!string.IsNullOrEmpty(useDevart) && useDevart.ToLower().Equals("true"))
                {
                    return new DevartOracleDatabase(connectionString );
                }
                else
                {
                    return new OracleDatabase(connectionString);
                }
            }
            else if (providerName == DatabaseFactory.SqlClientProvider)
            {
                return new SqlDatabase(connectionString);
            }
            else if (providerName == DatabaseFactory.OleDbProvider)
            {
                return new OledbDatabase(connectionString);
            }
            else
            {
                throw new NotSupportedException(providerName);
            }
        }

        /// <summary>
        /// 参数名翻译
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public static string TransParameter(string parameterName)
        {
            if (DatabaseFactory.DefaultProviderName == DatabaseFactory.OleDbProvider)
                return "?";
            else if (DatabaseFactory.DefaultProviderName == DatabaseFactory.OracleClientProvider)
                return ":" + parameterName;
            else if (DatabaseFactory.DefaultProviderName == DatabaseFactory.SqlClientProvider)
                return "@" + parameterName;
            else
                throw new NotSupportedException(DatabaseFactory.DefaultProviderName);
        }

        private static string GetConnectionString(string providerName, string serverAddress, string dataBaseName, string userID, string password, bool isWindowUser)
        {
            string connString = "";
            if (providerName.ToLower().Equals("system.data.oracleclient"))
            {
                connString = string.Format("Data Source={0};Persist Security Info=True;User ID={1};Password={2};Unicode=True", new object[] { serverAddress, userID, password });
            }
            else if (providerName.ToLower().Equals("system.data.sqlclient"))
            {
                connString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};Integrated Security={4}", new object[] { serverAddress, dataBaseName, userID, password, isWindowUser.ToString() });
            }
            else if (providerName.ToLower().Equals("system.data.oledb"))
            {
                connString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}{1}.mdb;Jet OLEDB:Database Password={2};Persist Security Info={3}", new object[] { serverAddress, dataBaseName, password, isWindowUser.ToString() });
            }
            return connString;
        }

        public static bool TestConnection(ref Exception err)
        {
            if (!string.IsNullOrEmpty(_connectionString))
            {
                DbConnection dbConnection = new MyDataAdapter().GetConnection(); 
                dbConnection.ConnectionString = _connectionString;
                try
                {
                    dbConnection.Open();
                    return true;
                }
                catch (Exception ex) { err = ex; }
                finally
                {
                    dbConnection.Close();
                }
            }
            return false;
        }

        public static bool TestConnection(string providerName, string serverAddress, string dataBaseName, string userID, string password, bool isWindowUser,ref Exception err)
        {
            if (providerName != null)
            {
                string connectionString = GetConnectionString(providerName, serverAddress, dataBaseName, userID, password, isWindowUser);
                if (!string.IsNullOrEmpty(connectionString))
                {
                    DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);
                    DbConnection dbConnection = factory.CreateConnection();
                    dbConnection.ConnectionString = connectionString;
                    try
                    {
                        dbConnection.Open();
                        return true;
                    }
                    catch (Exception ex) { err = ex; }
                    finally
                    {
                        dbConnection.Close();
                    }
                }
            }
            return false;
        }

        public static DataTable GetDataFromSQLString(string sqlText)
        {
            return GetDataFromSQLString(sqlText, "");
        }

        public static DataTable GetDataFromSQLString(string sqlText, string tableName)
        {
            return GetDataFromSQLString(sqlText, null,tableName);
        }


        public static DataTable GetDataFromSQLStringNoKey(string sqlText)
        {
            IDatabase database = DatabaseFactory.Create();
            MyDataAdapter adapter = new MyDataAdapter();//_providerName, _connectionString);
            adapter.SetSQL(sqlText);
            DbDataAdapter dataAdapter = adapter.DataAdapter;

            DataTable dataTable = new DataTable();




            dataAdapter.Fill(dataTable);


            //add by zzc 全局DataSet 加载数据 20140410
            //AddTableToDataSet(dataTable, false);


            return dataTable;
        }

        public static DataTable GetDataFromSQLString(string sqlText, object[] parameters)
        {
            return GetDataFromSQLString(sqlText, parameters, "");
        }

        public static DataTable GetDataFromSQLString(string sqlText, object[] parameters, string tableName)
        {
            MyDataAdapter adapter = new MyDataAdapter();
            if (parameters == null)
            {
                adapter.SetSQL(sqlText);
            }
            else
            {
                adapter.SetSQL(sqlText, parameters);
            }
            DbDataAdapter dataAdapter = adapter.DataAdapter;
            MissingSchemaAction oldMissingSchemaAction = dataAdapter.MissingSchemaAction;
            dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            DataTable dataTable = new DataTable();
            if (!string.IsNullOrEmpty(tableName))
            {
                dataTable.TableName = tableName;
            }
            if (!LocalConfig.LocalMode&&ConnectionMonitor.GetCurrentMonitor().IsConnected)
            {
                dataAdapter.Fill(dataTable);
                dataAdapter.MissingSchemaAction = oldMissingSchemaAction;
                //add by zzc 全局DataSet 加载数据 20140314
                AddTableToDataSet(dataTable, false);
            }
            else
            {
                LoadDataRow(sqlText, dataTable, parameters);
            }

            return dataTable;
        }

        /// <summary>
        /// 获取带主键的表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDataWithPrimaryKey(string tableName)
        {
            return GetDataWithPrimaryKey(tableName, "");
        }

        public static DataTable GetDataWithPrimaryKey(string tableName, string whereString)
        {
            return GetDataWithPrimaryKey(tableName, whereString, null);
        }

        public static DataTable GetDataWithPrimaryKey(string tableName, string whereString, object[] parameters)
        {
            DataTable dataTable = new DataTable();
            dataTable.TableName = tableName;
            dataTable = GetDataFromSQLString("Select * from " + tableName + " " + whereString, parameters,tableName);


            //add by zzc 全局DataSet 加载数据 20140314
            //AddTableToDataSet(dataTable,false );

            return dataTable;
        }

        public static int UpdateDataTable(DataTable dataTable)
        {
            MyDataAdapter adapter = new MyDataAdapter();
            adapter.SetSQL("Select * from " + dataTable.TableName + " Where 1 = 2");
            DbDataAdapter dataAdapter = adapter.DataAdapter;

            DatabaseFactory.AddTableToDataSet(dataTable, true);
            if (!LocalConfig.LocalMode && ConnectionMonitor.GetCurrentMonitor().IsConnected)
            {
                return dataAdapter.Update(dataTable);
            }
            else
            {
                return dataTable.Rows.Count;
            }
        }

        public static DataColumn[] GetPrimaryKey(string tableName)
        {
            MyDataAdapter adapter = new MyDataAdapter();
            adapter.SetSQL("Select * from " + tableName + " Where 1 = 2");
            DbDataAdapter dataAdapter = adapter.DataAdapter;
            MissingSchemaAction oldMissingSchemaAction = dataAdapter.MissingSchemaAction;
            dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataAdapter.MissingSchemaAction = oldMissingSchemaAction;
            return dataTable.PrimaryKey;
        }

        /// <summary>
        /// 获取日期查询字符串
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string GetDateTimeQueryString(DateTime dateTime)
        {
            return "'" + dateTime.ToString("yyyy-MM-dd") + "'";
        }

        public static DbParameter CreateParameter(string parameterName, object value)
        {
            if (_providerName != null && _connectionString != null)
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory(_providerName);
                DbParameter parameter = factory.CreateParameter();
                parameter.ParameterName = parameterName;
                parameter.DbType = (DbType)Enum.Parse(typeof(DbType), value.GetType().Name);
                parameter.Value = value;
                return parameter;
            }
            return null;
        }

        private static void GenParameters(DbDataAdapter adapter,string sqlText, object[] values, string paraStr)
        {
            int idx = 0;
            int index = 0;
            index = sqlText.IndexOf(paraStr, index + 1);
            while (index > 0 && idx < values.Length)
            {
                string aaa = sqlText.Substring(index);
                int index1 = aaa.IndexOf(" ");
                if (index1 > 0)
                {
                    aaa = aaa.Substring(0, index1);
                }
                index1 = aaa.IndexOf(")");
                if (index1 > 0)
                {
                    aaa = aaa.Substring(0, index1);
                }
                index1 = aaa.IndexOf(",");
                if (index1 > 0)
                {
                    aaa = aaa.Substring(0, index1);
                }
                index1 = aaa.IndexOf("\r");
                if (index1 > 0)
                {
                    aaa = aaa.Substring(0, index1);
                }
                index1 = aaa.IndexOf("\n");
                if (index1 > 0)
                {
                    aaa = aaa.Substring(0, index1);
                }
                if (adapter.SelectCommand.Parameters == null || adapter.SelectCommand.Parameters.Count == 0
                    || !adapter.SelectCommand.Parameters.Contains(aaa))
                {
                    DbParameter parameter = CreateParameter(aaa, values[idx++]);
                    if (parameter != null)
                    {
                        adapter.SelectCommand.Parameters.Add(parameter);
                    }
                }
                index = sqlText.IndexOf(paraStr, index + 1);
            }
        }

        public static T GetTableFromSQL<T>(string sql) where T : DataTable
        {
            Type type = typeof(T);
            T dataTable = (T)type.Assembly.CreateInstance(type.FullName);
            DbDataAdapter adapter = GetDataAdapter(sql);
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DbDataAdapter GetDataAdapter(string sqlText) { return GetDataAdapter(sqlText, null, true); }
        public static DbDataAdapter GetDataAdapter(string sqlText, bool createOtherCommand) { return GetDataAdapter(sqlText, null, createOtherCommand); }
        public static DbDataAdapter GetDataAdapter(string sqlText, object[] parameters) { return GetDataAdapter(sqlText, parameters, true); }
        public static DbDataAdapter GetDataAdapter(string sqlText, object[] parameters, bool createOtherCommand)
        {
            if (_providerName != null && _connectionString != null)
            {
                string transSql = sqlText;
                DbProviderFactory factory = DbProviderFactories.GetFactory(_providerName);
                DbDataAdapter dataAdapter = factory.CreateDataAdapter();
                DbCommandBuilder dbCommandBuilder = factory.CreateCommandBuilder();
                DbCommand dbCommand = factory.CreateCommand();
                DbConnection dbConnection = factory.CreateConnection();
                dbConnection.ConnectionString = _connectionString;
                dbCommand.Connection = dbConnection;
                dataAdapter.SelectCommand = dbCommand;
                if (dataAdapter is System.Data.OracleClient.OracleDataAdapter)
                {
                    transSql = transSql.Replace("@", ":");
                }
                dbCommand.CommandText = transSql;
                if (parameters != null && parameters.Length > 0)
                {
                    if (parameters is DbParameter[])
                    {
                        dbCommand.Parameters.AddRange(parameters);
                    }
                    else
                    {
                        string paraStr = "@";
                        if (dataAdapter is System.Data.OracleClient.OracleDataAdapter)
                        {
                            paraStr = ":";
                        }
                        GenParameters(dataAdapter, transSql, parameters, paraStr);
                    }
                }
                if (dataAdapter is System.Data.OracleClient.OracleDataAdapter && dbCommand.Parameters != null)
                {
                    foreach (DbParameter parameter in dbCommand.Parameters)
                    {
                        parameter.ParameterName = parameter.ParameterName.Replace("@", ":");
                    }
                }
                if (createOtherCommand)
                {
                    dbCommandBuilder.DataAdapter = dataAdapter;
                    try
                    {
                        dataAdapter.DeleteCommand = dbCommandBuilder.GetDeleteCommand();
                        dataAdapter.UpdateCommand = dbCommandBuilder.GetUpdateCommand();
                        dataAdapter.InsertCommand = dbCommandBuilder.GetInsertCommand();
                    }
                    catch { }
                }
                return dataAdapter;
            }
            return null;
        }

        public static string EncodeConnectionString(string connectionName, string providerName, string serverAddress, string dataBaseName, string userName, string password, bool isWindowUser)
        {
            return new DataBaseConfig(connectionName, providerName, serverAddress, dataBaseName, userName, password, isWindowUser).Encode();
        }

        public static void DecodeConnectionString(string connectionString, ref string connectionName, ref string providerName, ref string serverAddress, ref string dataBaseName, ref string userName, ref string password, ref bool isWindowUser)
        {
            DataBaseConfig dbConfig = new DataBaseConfig();
            dbConfig.Decode(connectionString);
            connectionName = dbConfig.ConnectionName;
            providerName = dbConfig.ProviderName;
            serverAddress = dbConfig.ServerAddress;
            dataBaseName = dbConfig.DataBaseName;
            userName = dbConfig.UserName;
            password = dbConfig.Password;
            isWindowUser = dbConfig.IsWindowUser;
        }

        public static void ThrowDataAccessException(Exception ex)
        {
            WriteErrorLog(ex);
            throw new DataAccessException("如果您看到了这个提示,我们表示抱歉,请联系管理员处理.", ex);
        }

        /// <summary>
        ///  将异常的有关情况记录至日志
        /// </summary>
        /// <param name="ex"></param>
        public static void WriteErrorLog(Exception ex)
        {
            Object thisLock = new Object();
            lock (thisLock)
            {
                System.IO.StreamWriter LogTxt;
                string AppFilePath = @"Log\" +  DateTime.Today.ToString("yyyyMMdd") + ".txt";
                if (System.IO.File.Exists(AppFilePath))
                {
                    LogTxt = File.AppendText(AppFilePath);
                }
                else
                {
                    LogTxt = File.CreateText(AppFilePath);
                }
                try
                {
                    LogTxt.WriteLine("异常发生时，服务器时间为 :\t" + DateTime.Now.ToString());
                    if (ex.Message != null)
                    {
                        LogTxt.WriteLine("事件消息为:\t" + ex.Message);
                    }
                    if (ex.StackTrace != null)
                    {
                        LogTxt.WriteLine("异常发生时，调用堆栈上的桢的字符串表现形式:\t" + ex.StackTrace);
                    }
                    if (ex.TargetSite != null && ex.TargetSite.Name != null)
                    {
                        LogTxt.WriteLine("引发当前异常的函数为:\t" + ex.TargetSite.Name);
                    }
                    if (ex.Source != null)
                    {
                        LogTxt.WriteLine("导致错误的应用程序或对象的名称为:\t" + ex.Source);
                    }
                    LogTxt.WriteLine();
                    LogTxt.WriteLine();
                }
                finally
                {
                    LogTxt.Close();
                }
            }
        }


        //判断datatable 是否一样 或者 先导出XML字符串，然后再比较
        public static bool IsSame(DataTable dt1, DataTable dt2)
        {
            DataTable dt3 = new DataTable();
            dt3.Merge(dt1);
            dt3.AcceptChanges();

            dt3.Merge(dt2);
            DataTable dt4 = dt3.GetChanges();
            return dt4 == null || dt4.Rows.Count == 0;
        }


        public static DataTable GetTableFromDataSet(string tableName)
        {
            DataTable t = null ;
            if (DatabaseFactory.AnesInfoAllDataSet.Tables.Contains(tableName)) //如果内存有
            {
                t = DatabaseFactory.AnesInfoAllDataSet.Tables[tableName];
                
            }
            else if (DatabaseFactory.AnesDictDataSet.Tables.Contains(tableName)) //如果内存有
            {
                t = DatabaseFactory.AnesDictDataSet.Tables[tableName];

            }
            else //本地加载文件到内存
            {
                if (AliasDict.ContainsKey(tableName))
                {
                    byte[] dataSetBytes = DataBinaryHelper.ReadFileToByteBuffer(System.Environment.CurrentDirectory + "\\Bin\\Tables\\" + AliasDict[tableName]);

                    t = DataBinaryHelper.BinaryToDataTable(dataSetBytes, tableName);
                }
            
            }
            return t;
        }

        public static List<string> NeedUpdateTableNames
        {
            get
            {
                List<string> list = new List<string>();
                list.Add("AnesthesiaEvent");
                list.Add("AnesthesiaPlan");
                list.Add("AnesthesiaSummary");
                list.Add("BloodGasMaster");
                list.Add("MED_ANALGESIC_RECORD");
                list.Add("MED_ANES_PREPARE");
                list.Add("WIS_CUSTOM_DATA");
                list.Add("MED_GRID_RECORD");
                list.Add("WIS_OPER_ANALGESIC");
                list.Add("MED_SAFE_CHECK");
                list.Add("MED_USER_LOGIN_REC");
                list.Add("OperationMaster");
                list.Add("PatientMonitorData");
                list.Add("MED_PROGRESS_NOTE");
                list.Add("MED_PACU_RECORD");
                return list;
            }
        }

        public static List<string> DictTableNames
        {
            get
            {
                List<string> list = new List<string>();
                list.Add("MedAnesthesiaInputDict");
                list.Add("MonitorFunctionCode");
                list.Add("HospitalConfig");
                list.Add("Permissios");
                list.Add("WisDiagnosisDict");
                list.Add("OperationDict");
                list.Add("HisUser");
                //list.Add("Users");//登陆时加载单个用户记录，不全
                list.Add("WIS_DICT_ANES_COMM");
                list.Add("AnessthestaDict");
                list.Add("MedDeptDict");
                list.Add("WIS_DICT_OCCUPATION");
                list.Add("WIS_DICT_CPB_METHOD");
                list.Add("WIS_DICT_CPB_INPUT");
                list.Add("AnesthesiaEventOpen");
                list.Add("BloodGasDict");
                list.Add("MonitorDict");
                list.Add("WIS_DICT_BILL_ITEM_CLASS");
                list.Add("med_case_dict");
                list.Add("med_case_dosage_description");
                list.Add("ConfigTable");
                list.Add("OperatingRoom");
                list.Add("MedPatMonitorDataDict");
                return list;
            }
        }

        public static void AddTableToDataSet(DataTable data , bool needUpdate)
        {
            //AddTableToDictDataSet(data, needUpdate);

            //如果不需要保存文件，侧退出
            if (!LocalConfig.NeedSaveLocalFile)
                return;
            //属于字典表 则不用处理
            //if (DictTableNames.Contains(data.TableName))
            //{
            //    return;
            //}

            bool bChange = false;
            DataTable dtTemp = null;

            if (!DatabaseFactory.AnesInfoAllDataSet.Tables.Contains(data.TableName))
            {
                DatabaseFactory.AnesInfoAllDataSet.Tables.Add(data);
                bChange = true; 
            }
            else
            {
                if (!DictTableNames.Contains(data.TableName)||LocalConfig.IsDictLoaded==false)
                {
                    if (DatabaseFactory.AnesInfoAllDataSet.Tables.Contains(data.TableName))
                    {
                        DataTable t = DatabaseFactory.AnesInfoAllDataSet.Tables[data.TableName];
                        // 如果 行数一直，则不保存，因为 行数一直字段变化时，needUpdate 改为true
                        if (t.Rows.Count == data.Rows.Count && !needUpdate)
                        {
                            bChange = false;
                        }
                        else
                        {
                            t.Merge(data, false);

                            string[] columnsArray = null;
                            if (t.PrimaryKey != null && t.PrimaryKey.Length > 0)
                            {
                                columnsArray = new string[t.PrimaryKey.Length];

                                for (int i = 0; i < t.PrimaryKey.Length; i++)
                                {
                                    columnsArray[i] = t.PrimaryKey[i].ColumnName;
                                }

                            }
                            else
                            {
                                columnsArray = new string[t.Columns.Count];

                                for (int i = 0; i < t.Columns.Count; i++)
                                {
                                    columnsArray[i] = t.Columns[i].ColumnName;
                                }
                            }


                            t = t.DefaultView.ToTable(true, columnsArray);

                            dtTemp = t.GetChanges();

                            if (dtTemp == null || (dtTemp != null && dtTemp.Rows.Count == 0))
                            {
                                bChange = false;

                            }
                            else
                            {

                                bChange = true;
                            }
                        }
                    }
                    else
                    {
                        DatabaseFactory.AnesInfoAllDataSet.Tables.Add(data);
                    }
                }
            }

            if ((needUpdate || bChange )  &&( DatabaseFactory.AnesInfoAllDataSet.Tables.Count > 0))
            {

                if (LocalConfig.NeedSaveLocalFile)
                {
                    //byte[] dataSetBytes = DataBinaryHelper.DataSetToBinary(DatabaseFactory.AnesInfoAllDataSet);
                    //DataBinaryHelper.SaveToFile(dataSetBytes, System.Environment.CurrentDirectory + "\\Bin\\hospital.mdsd");
                    DataTable t = DatabaseFactory.AnesInfoAllDataSet.Tables[data.TableName];
                    byte[] dataSetBytes = DataBinaryHelper.DataTableToBinary(t);
                    string filename = "";
                    if (AliasDict.ContainsKey(t.TableName))
                    {
                        filename = AliasDict[t.TableName];
                    }
                    else
                    {
                        filename = Guid.NewGuid().ToString();
                        AliasDict.Add(t.TableName, filename);
                    }
                    DataBinaryHelper.SaveToFile(dataSetBytes, System.Environment.CurrentDirectory + "\\Bin\\Tables\\" + filename);
                    DataTable aliasDictData = new DataTable();
                    aliasDictData.TableName = "LocalKeyValue";
                    aliasDictData.Columns.Add("key");
                    aliasDictData.Columns.Add("value");
                    foreach (string key in AliasDict.Keys)
                    {
                        DataRow newrow = aliasDictData.NewRow();
                        newrow["key"] = key;
                        newrow["value"] = AliasDict[key];
                        aliasDictData.Rows.Add(newrow);
                    }
                    aliasDictData.AcceptChanges();
                    aliasDictData.WriteXml(System.Environment.CurrentDirectory + "\\Bin\\LocalKeyValue",XmlWriteMode.WriteSchema,true);

                }

            }
        }

        private static void LoadDataRow(string sql, DataTable data, object[] parameters)
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

                string patientId = "";
                for (int i = 0; i < dtMaster.Rows.Count; i++)
                {
                    patientId = dtMaster.Rows[i]["PAT_ID"].ToString();
                    DataRow[] patRows = dtPatIndex.Select("PAT_ID = '" + patientId + "'");


                    DataRow rowPatInList = dt.NewRow();
                    //遍历patientList
                    for (int iList = 0; iList < dt.Columns.Count; iList++)
                    {


                        if (dt.Columns[iList].ColumnName == "START_DATE_TIME")
                        {
                            if (dtMaster.Rows[i]["IN_DATE_TIME"] == null)
                            {
                                rowPatInList["START_DATE_TIME"] = dtMaster.Rows[i]["SCHEDULED_DATE_TIME"];
                            }
                            else
                            {
                                rowPatInList["START_DATE_TIME"] = dtMaster.Rows[i]["IN_DATE_TIME"];
                            }
                        }
                        else if (dtMaster.Columns.Contains(dt.Columns[iList].ColumnName))
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


            if (dt.Rows.Count == 0)
            {
                data.Merge(dt);
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
                    if (parameters[i] is System.Decimal)
                    {
                        SQLTemp = SQLTemp.Replace(parameters[i].ToString().ToUpper(), parameters[i].ToString());
                    }
                    else
                    {
                        SQLTemp = SQLTemp.Replace(parameters[i].ToString().ToUpper(), "'" + parameters[i].ToString() + "'");
                    }
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

        public static int UpLoadDataToServer(DataSet ds)
        {
            int n = 0;
            if (ds.Tables.Count > 0)
            {
                if (ConnectionMonitor.GetCurrentMonitor().IsConnected)
                {
                    IDatabase database = DatabaseFactory.Create();
                    DataSet tds = new DataSet();
                    foreach (DataTable dt in ds.Tables)
                    {
                        //if (dt.TableName == "OperationMaster" || dt.TableName == "PatMasterIndex" || dt.TableName == "WIS_CUSTOM_DATA")
                        if (NeedUpdateTableNames.Contains(dt.TableName))
                        {
                            LocalConfig.NeedSaveLocalFile = false;

                            database.Update(dt);

                            LocalConfig.NeedSaveLocalFile = true;
                            tds.Tables.Add(dt.Copy());
                        }
                    }
                    byte[] bytes= DataBinaryHelper.DataSetToBinary(tds);
                    DataBinaryHelper.SaveToFile(bytes, System.Environment.CurrentDirectory + "\\Bin\\SaveBackUp\\" + DateTime.Now.ToString());
                    n = 1;
                }
            }
            return n;
        }
        
    }


}
