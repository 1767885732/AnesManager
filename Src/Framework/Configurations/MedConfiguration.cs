using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using iMedical.CommonLib.Utility;
using System.Data.OracleClient;

namespace Wis.Anes.Framework.Configurations
{
    /// <summary>
    /// 配置类
    /// </summary>
    public static class MedConfiguration
    {

        #region 内部变量

        /// <summary>
        /// 科室代码
        /// </summary>
        private static string _wardCode;

        /// <summary>
        /// 登录用户ID
        /// </summary>
        private static string _userID;

        /// <summary>
        /// 登录用户名称
        /// </summary>
        private static string _userName;

        /// <summary>
        /// 科室名称
        /// </summary>
        private static string _wardName = "";

        /// <summary>
        /// 权限列表
        /// </summary>
        private static Hashtable _permissions = new Hashtable();

        #endregion 内部变量

        #region 常量

        #region 主键名
        /// <summary>
        /// 科室代码
        /// </summary>
        private const string WARD_CODE = "WARD_CODE";
        /// <summary>
        /// 登录用户
        /// </summary>
        private const string USERID = "USER_ID";
        /// <summary>
        /// 登录用户名称
        /// </summary>
        private const string USER_NAME = "USER_NAME";
        /// <summary>
        /// 新医嘱处理模式
        /// </summary>
        private const string NEW_ORDER_OPERATION_MODE = "NEW_ORDER_OPERATION_MODE";

        #endregion 主键名

        #region 默认值

        private const string IS_VALIDED = "IsValided";
        private const string DEFAULT_WARD_CODE = "H3";
        private const string DEFAULT_USER_ID = "SSCJ";
        private const string ORACLE_CLIENT_PROVIDER = "System.Data.OracleClient";
        private const string SQL_CLIENT_PROVIDER = "System.Data.SqlClient";
        private const string DEVART_CLIENT_PROVIDER = "Devart.Data.Oracle";
        private const string OLE_DB_PROVIDER = "System.Data.OleDb";
        private const string HOSPITAL_ABBREVIATION = "HospitalAbbreviation";
        private const string TOKEN = "Token";
        private const string CURRENT_USING_CONNECTION_STRING_NAME = "CurrentUsingConnectionStringName";
        private const string START_FORM = "StartForm";
        private const string CURRENT_SKIN_NAME = "CurrentSkinName";
        private const string HOSPITAL_NAME = "HospitalName";
        #endregion 默认值

        #endregion 常量

        #region 静态属性
        /// <summary>
        /// 科室
        /// </summary>
        public static string WardCode
        {
            get
            {
                if (string.IsNullOrEmpty(_wardCode))
                {
                    _wardCode = Read(WARD_CODE);
                    if (string.IsNullOrEmpty(_wardCode))
                        _wardCode = DEFAULT_WARD_CODE;
                }
                return _wardCode;
            }
            set
            {
                SetValue(ref _wardCode, WARD_CODE, value);
            }
        }

        /// <summary>
        /// 用户名称
        /// </summary>
        public static string UserName
        {
            get
            {
                if (string.IsNullOrEmpty(_userName))
                {
                    _userID = Read(USER_NAME);
                    if (string.IsNullOrEmpty(USER_NAME))
                    {
                        _userName = DEFAULT_USER_ID;
                    }
                }
                return _userName;
            }
            set
            {
                SetValue(ref _userName, USER_NAME, value);
            }
        
        }

        /// <summary>
        /// 用户ID
        /// </summary>
        public static string UserID
        {
            get
            {
                if (string.IsNullOrEmpty(_userID))
                {
                    _userID = Read(USERID);
                    if (string.IsNullOrEmpty(_userID)) _userID = DEFAULT_USER_ID;
                }
                return _userID;
            }
            set
            {
                SetValue(ref _userID, USERID, value);
            }
        }

        /// <summary>
        /// 科室名称
        /// </summary>
        public static string WardName
        {
            get
            {
                return _wardName;
            }
            set
            {
                _wardName = value;
            }
        }

        /// <summary>
        /// 医院缩写
        /// </summary>
        public static string HospitalAbbreviation
        {
            get
            {
                return Read(HOSPITAL_ABBREVIATION);
            }
        }

        //add by dhc 20200407
        /// <summary>
        /// 医院名称
        /// </summary>
        public static string HospitalName
        {
            get
            {
                return Read(HOSPITAL_NAME);
            }
        }

        /// <summary>
        /// 令牌
        /// </summary>
        public static string Token
        {
            get
            {
                return Read(TOKEN);
            }
        }
        
        /// <summary>
        /// 具有合法令牌
        /// </summary>
        public static bool HasToken
        {
            get
            {
                string token = Token;
                return (token == null || token.Trim().Equals("") || token == IS_VALIDED);
            }
        }

        public static System.Configuration.Configuration IcuAppConfig
        {
            get
            {
                string configPath = AppDomain.CurrentDomain.BaseDirectory + "\\IcuClient.exe";
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(configPath);
                return config;
            }
        }

        /// <summary>
        /// 数据连接配置文件
        /// </summary>
        public static System.Configuration.Configuration IcuConfig
        {
            get {
                string configPath = AppDomain.CurrentDomain.BaseDirectory + "\\Icu.config";
                ExeConfigurationFileMap map = new ExeConfigurationFileMap { ExeConfigFilename = configPath };
                System.Configuration.Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
                return config;
            }
        }

        /// <summary>
        /// 不使用Oracle客户端
        /// </summary>
        public static string NoUserOracleClient
        {
            get
            {
                if (IcuConfig.AppSettings.Settings["NoUserOracleClient"].Value.ToString() == null)
                {
                    return string.Empty;
                }
                return IcuConfig.AppSettings.Settings["NoUserOracleClient"].Value.ToString();
            }
        }

        /// <summary>
        /// 是否为英文库
        /// </summary>
        public static string UserEn
        {
            get
            {
                if (IcuConfig.AppSettings.Settings["User_En"].Value.ToString() == null)
                {
                    return string.Empty;
                }
                return IcuConfig.AppSettings.Settings["User_En"].Value.ToString();
            }
        }

        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionString
        {
            get
            {                
                if (IcuConfig.ConnectionStrings.ConnectionStrings[MedConfiguration.CurrentUsingConnectionStringName] == null)
                {
                    return string.Empty;
                }
                return Cryptography.Decrypt(IcuConfig.ConnectionStrings.ConnectionStrings[MedConfiguration.CurrentUsingConnectionStringName].ConnectionString);
            }
        }

        /// <summary>
        /// 获取连接字符串的提供者名称
        /// </summary>
        public static string ProviderName
        {
            get
            {
                if (IcuConfig.ConnectionStrings.ConnectionStrings[MedConfiguration.CurrentUsingConnectionStringName] == null)
                {
                    return string.Empty;
                }
                return IcuConfig.ConnectionStrings.ConnectionStrings[MedConfiguration.CurrentUsingConnectionStringName].ProviderName;
            }
        }
        /// <summary>
        /// 当前适用的连接字符串的名称
        /// </summary>
        public static string CurrentUsingConnectionStringName
        {
            get
            {
                string name = Read(CURRENT_USING_CONNECTION_STRING_NAME);
                if (string.IsNullOrEmpty(name))
                    name = "ICU";
                return name;
            }
        }
        /// <summary>
        /// 当前启动的Form
        /// MainForm 护士站
        /// MainFormDoctor 医生站
        /// </summary>
        public static string StartForm
        {
            get
            {
                string name = Read(START_FORM);
                if (string.IsNullOrEmpty(name))
                    name = "MainForm";
                return name;
            }
        }
        /// <summary>
        /// 当前使用的皮肤名称
        /// ExtendDarkBlue
        /// ExtendBlue
        /// </summary>
        public static string CurrentSkinName
        {
            get
            {
                string name = Read(CURRENT_SKIN_NAME);
                if (string.IsNullOrEmpty(name))
                    name = "ExtendBlue";
                return name;
            }
        }

        public static string ClientIP
        {
            get
            {
                return NetTools.GetLocalIPV4Address();
            }
        }

        public static int ClientPort
        {
            get
            {
                string clientPort = Read("CLIENT_PORT");
                int iClientPort;
                if (string.IsNullOrEmpty(clientPort) ||
                    !int.TryParse(clientPort, out iClientPort))
                    return 8080;
                return iClientPort;
            }
        }

        private static DbConnectionStringBuilder _connectionStringBuilder;
        /// <summary>
        /// 获取当前适用的连接字符串构造器
        /// </summary>
        public static DbConnectionStringBuilder ConnectionStringBuilder
        {
            get
            {
                if(_connectionStringBuilder == null){

                    if (ProviderName == ORACLE_CLIENT_PROVIDER)
                    {
                        _connectionStringBuilder =  new OracleConnectionStringBuilder(ConnectionString);
                    }
                    else if (ProviderName == DEVART_CLIENT_PROVIDER)
                    {
                        _connectionStringBuilder = new Devart.Data.Oracle.OracleConnectionStringBuilder(ConnectionString);
                    }                    
                    else if (ProviderName == SQL_CLIENT_PROVIDER)
                    {
                        //_connectionStringBuilder =   new SqlConnectionStringBuilder(ConnectionString);
                        _connectionStringBuilder = new OleDbConnectionStringBuilder(ConnectionString);
                    }
                    else if (ProviderName == OLE_DB_PROVIDER)
                    {
                        _connectionStringBuilder =   new OleDbConnectionStringBuilder(ConnectionString);
                    }
                }
                return _connectionStringBuilder;
            }
        }
        /// <summary>
        /// 获取数据库实例,Oracle是本地服务名,Sql是数据库名称
        /// </summary>
        public static string DBInstance
        {
            get
            {
                if (ConnectionStringBuilder == null)
                    return null;
                if (ConnectionStringBuilder is OleDbConnectionStringBuilder)
                {
                    if(ConnectionStringBuilder.ContainsKey("Provider"))
                    {
                        if (ConnectionStringBuilder["Provider"].ToString() == "sqloledb")
                        {
                        return ConnectionStringBuilder["Initial Catalog"].ToString();
                        }
                        else
                        {
                            return ConnectionStringBuilder["Data Source"].ToString();
                        }
                    }
                    else
                    {
                        return ConnectionStringBuilder["Data Source"].ToString();
                    }
                    
                }
                if(ConnectionStringBuilder is OracleConnectionStringBuilder)
                {
                    return ConnectionStringBuilder["Data Source"].ToString();
                }
                if (ConnectionStringBuilder is Devart.Data.Oracle.OracleConnectionStringBuilder)
                {
                    if (NoUserOracleClient.ToLower() == "true")
                        return ConnectionStringBuilder["Sid"].ToString();
                    else
                        return ConnectionStringBuilder["Data Source"].ToString();
                }
                if (ConnectionStringBuilder is SqlConnectionStringBuilder)
                {
                    return ConnectionStringBuilder["Initial Catalog"].ToString();
                }
                return null;
            }
        }
        /// <summary>
        /// 获取数据库登录用户名
        /// </summary>
        public static string DBLoginUser
        {
            get
            {
                if (ConnectionStringBuilder == null)
                    return null;
                return ConnectionStringBuilder["User ID"].ToString();
            }
        }
        /// <summary>
        /// 获取数据库登录密码
        /// </summary>
        public static string DBLoginPassword
        {
            get
            {
                if (ConnectionStringBuilder == null)
                    return null;
                return ConnectionStringBuilder["Password"].ToString();
            }
        }
        /// <summary>
        /// 获取SqlServer的服务器IP地址或者域名(非SqlServer连接字符串时返回null)
        /// </summary>
        public  static string SqlServerIP
        {
            get{

                if (ConnectionStringBuilder != null)// && ConnectionStringBuilder is SqlConnectionStringBuilder)
                {
                    return ConnectionStringBuilder["Data Source"].ToString();
                }

                return null;
            }
        }

        /// <summary>
        /// 是否新医嘱处理模式
        /// </summary>
        public static bool NewOrderOperationMode
        {
            get
            {
                string s = Read(NEW_ORDER_OPERATION_MODE);
                if(s == null)
                    return false;
                return (s == "1");
            }
            set
            {
                Save(NEW_ORDER_OPERATION_MODE, (value?"1":"0"));
            }
        }

        #endregion 静态属性

        #region 静态方法

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="valName">内部变量名称</param>
        /// <param name="key">主键</param>
        /// <param name="value">值</param>
        private static void SetValue(ref string valName, string key, string value)
        {
            valName = value;
            Save(key, value);
        }

        /// <summary>
        /// 读取设置
        /// </summary>
        /// <param name="key">主键</param>
        /// <returns>对应值</returns>
        private static string Read(string key)
        {
            //不会抛掷异常,无需捕捉,对应key无值时返回null
            return ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        /// 保存设置
        /// </summary>
        /// <param name="key">主键</param>
        /// <param name="value">对应值</param>
        public static void Save(string key, string value)
        {
            if (Read(key) == value)
                return;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);      
            config.AppSettings.Settings.Remove(key);
            config.AppSettings.Settings.Add(key, value);
            config.Save();
        }

        public static void Save(string key,MedConfigurationClassArrayData classArray)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.Sections.Remove(key);
            config.Sections.Add(key, classArray);
            config.Save();
            ConfigurationManager.RefreshSection(key);
        }

        public static MedConfigurationClassArrayData GetClassArray(string key)
        {
            try
            {
                return ConfigurationManager.GetSection(key) as MedConfigurationClassArrayData;
            }
            catch { return null; } 
        }
        /// <summary>
        /// 校验是否拥有某权限
        /// </summary>
        /// <param name="permissionKey">权限名称</param>
        /// <returns>拥有权限返回真否则返回假</returns>
        public static bool CheckPermission(string permissionKey)
        {
            return _permissions.ContainsKey(permissionKey);
        }
        /// <summary>
        /// 根据权限名称来筛选
        /// </summary>
        /// <param name="permissionName"></param>
        /// <returns></returns>
        public static bool CheckPermissionByName(string permissionName)
        {
            return _permissions.ContainsValue(permissionName);
        }

        /// <summary>
        /// 增加权限
        /// </summary>
        /// <param name="permissionKey">权限关键字</param>
        /// <param name="value">是否拥有权限</param>
        /// <returns>增加成功返回真，失败返回假</returns>
        public static bool AddPermission(string permissionKey, string value)
        {
            if (_permissions.ContainsKey(permissionKey))
                return false;
            _permissions.Add(permissionKey, value);
            return true;
        }

        #endregion 方法
    }
}
