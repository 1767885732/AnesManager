using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Wis.Anes.BusinessEntity;
using System.IO;
using System.Windows.Forms;
using Wis.Anes.Framework.Permissions;
using Wis.Anes.Framework.Controls;
using Wis.Anes.Framework.CustomSetting;
using System.Threading;
using Wis.Anes.Data;

namespace Wis.Anes.Framework
{
  
    /// <summary>
    /// 应用程序上下文类
    /// </summary>
   public  class ExtendApplicationContext
    {
        public readonly static ExtendApplicationContext Current = new ExtendApplicationContext();
        private string _patientId = string.Empty;
        private string _applicationName = string.Empty;
        private string _deptCode = string.Empty;
        private Dictionary<string, DataTable> _codeTables = new Dictionary<string, DataTable>();
        private PatientContext _patientContext = new PatientContext();
        private ConnectionMonitor _connectionMonitor = null;

        private CustomSettingContext _CustomSettingContext = new CustomSettingContext();
        private PatientInformation _PatientInformation = null ;
        private ProgramStatus _systemStatus = ProgramStatus.NoPatient;
        private OperationStatus _OperationStatus = OperationStatus.None;
        private string _ApplicationID = "ANESPERSONAL";
        private Dictionary<string, MedVitalSignCurveDetail> _VitalSignCurveDetailDict =  null ;
        private string _HospitalID = null;
        private long _ClockTick = 0;
        private long _SystemRunClockTick = 0;

        private int _IsMatchingUser = 2;
        //private string _ApplicationVersion = "ANES5"; //麻醉系统版本  默认5.0


        private NetStatus _NetStatus = NetStatus.Connected; //麻醉系统 是否在线
        private Thread _threadNetCheck = null;



        private ProgramProcess _SystemCurrentProcess = ProgramProcess.SystemStart;

        private string[] _programArgs;
        //系统运行参数
        public string[] ProgramArgs
        {
            get { return _programArgs; }
            set { _programArgs = value; }
        }
        //系统当前进程（单位秒）
        public ProgramProcess SystemCurrentProcess
        {
            get { return _SystemCurrentProcess; }
            set { _SystemCurrentProcess = value; }
        }

        ////系统当前版本
        //public string ApplicationVersion
        //{
        //    get { return _ApplicationVersion; }
        //    set { _ApplicationVersion = value; }
        //}
        //系统当前状态
        public NetStatus NetStatus
        {
            get { return _NetStatus; }
            set { _NetStatus = value; }
        }



        #region 单机版设置
        private DataSet _AnesInfoAllDataSet = Wis.Anes.Data.DatabaseFactory.AnesInfoAllDataSet;
        //全局麻醉信息
        public DataSet AnesInfoAllDataSet
        {
            get { return Wis.Anes.Data.DatabaseFactory.AnesInfoAllDataSet; }
            set
            {
                Wis.Anes.Data.DatabaseFactory.AnesInfoAllDataSet = value;
            }
        }

        private DataSet _AnesDictDataSet = Wis.Anes.Data.DatabaseFactory.AnesDictDataSet;
        //全局麻醉信息
        public DataSet AnesDictDataSet
        {
            get { return Wis.Anes.Data.DatabaseFactory.AnesDictDataSet; }
            set
            {
                Wis.Anes.Data.DatabaseFactory.AnesDictDataSet = value;
            }
        }

        private Dictionary<string, string> _aliasDict = new Dictionary<string, string>();

        public Dictionary<string, string> AliasDict
        {
            get { return Wis.Anes.Data.DatabaseFactory.AliasDict; }
            set { Wis.Anes.Data.DatabaseFactory.AliasDict = value; }
        }


        //实时判断网络状态
        public ConnectionMonitor ConnMonitor
        {
            get { return ConnectionMonitor.GetCurrentMonitor(); }
        }

        //单机模式
        public bool LocalMode
        {
            get { return LocalConfig.LocalMode; }
            set { LocalConfig.LocalMode = value; }
        }

        public bool IsDictLoaded
        {
            get { return LocalConfig.IsDictLoaded; }
            set { LocalConfig.IsDictLoaded = value; }
        }

        #endregion



        //系统当前进程（单位秒）
        public Thread ThreadNetCheck
        {
            get { return _threadNetCheck; }
            set { _threadNetCheck = value; }
        }


        //时钟控制（单位秒）
        public long ClockTick
        {
            get { return _ClockTick; }
            set { _ClockTick = value; }
        }
        //系统总共运行时间（单位秒）
        public long SystemRunClockTick
        {
            get { return _SystemRunClockTick; }
            set { _SystemRunClockTick = value; }
        }
       /// <summary>
       /// 常用客户化设置
       /// </summary>
        public CustomSettingContext CustomSettingContext
        {
            get { return _CustomSettingContext; }
            set { _CustomSettingContext = value; }
        }
        public string HospitalID
        {
            get { return _HospitalID; }
            set { _HospitalID = value; }
        }
        public Dictionary<string, MedVitalSignCurveDetail> VitalSignCurveDetailDict
       {
           get { return _VitalSignCurveDetailDict; }
           set { _VitalSignCurveDetailDict = value; }
       }
        public OperationStatus OperationStatus
        {
            get { return _OperationStatus; }
            set { _OperationStatus = value; }
        }
        public ProgramStatus SystemStatus
        {
            get { return _systemStatus; }
            set { _systemStatus = value; }
        }
        public PatientInformation PatientInformation
        {
            get { return _PatientInformation; }
            set { _PatientInformation = value; }
        }


       /// <summary>
       /// 应用程序权限ID
       /// </summary>
        public string ApplicationID
        {
            get { return _ApplicationID; }
            set { _ApplicationID = value; }
        }
        private LoginUserContext _loginUserContext = new LoginUserContext();

        private ApplicationType _appType = ApplicationType.Anesthesia;
        public ApplicationType AppType
        {
            get
            {
                return _appType;
            }
            set
            {
                _appType = value;
            }
        }
        public LoginUserContext LoginUserContext
        {
            get { return _loginUserContext; }
            set { _loginUserContext = value; }
        }
        private PermissionContext _permissionContext = new PermissionContext();

        public PermissionContext PermissionContext
        {
            get { return _permissionContext; }
            set { _permissionContext = value; }
        }

        private ExtendApplicationContext()
        {
        }
        /// <summary>
        /// 格式化后的患者唯一KEY
        /// </summary>
        public string PatientKey
        {
            get
            {
                return string.Format("{0}:{1}:{2}",Current.PatientContext.PatientID,Current.PatientContext.VisitID,Current.PatientContext.OperID);
            }
        }

        /// <summary>
        /// 患者基本信息
        /// </summary>
        public PatientContext PatientContext
        {
            get
            {
                return _patientContext;
            }
            set
            {
                _patientContext = value;
            }
        }
        /// <summary>
        /// 应用程序名
        /// </summary>
        public string ApplicationName
        {
            get
            {
                return _applicationName;
            }
            set
            {
                _applicationName = value;
            }
        }
        /// <summary>
        /// 科室代码
        /// </summary>
        public string DeptCode
        {
            get
            {
                return _deptCode;
            }
            set
            {
                _deptCode = value;
            }
        }
        /// <summary>
        /// 字典表
        /// </summary>
        public Dictionary<string, DataTable> CodeTables
        {
            get
            {
                return _codeTables;
            }
            set
            {
                _codeTables = value;
            }
        }

  
 

        /// <summary>
        /// 是否超级配置
        /// </summary>
        private bool _isSystemConfig = false;
        public bool IsSystemConfig
        {
            set
            {
                _isSystemConfig = value;
            }
            get
            {
                return _isSystemConfig;
            }
        }

        private BusinessEntity.Configuations.ConfigTableDataTable _configTable;

        public BusinessEntity.Configuations.ConfigTableDataTable ConfigTable
        {
            get { return _configTable; }
            set { _configTable = value; }
        }

        private Dictionary<ProgramStatus, string> _statusButtonStrList = new Dictionary<ProgramStatus, string>();

        public Dictionary<ProgramStatus, string> StatusButtonStrList
        {
            get { return _statusButtonStrList; }
            set { _statusButtonStrList = value; }
        }
        
        private DateTime _anesStartTime = DateTime.Now;

        public DateTime AnesStartTime
        {
            get
            {
                return _anesStartTime;
            }
            set
            {
                _anesStartTime = value;
            }
        }
       private decimal _eventNo = 0;


       public decimal EventNo
       {
           get
           {
               return _eventNo;
           }
           set
           {
               _eventNo = value;
           }
       }
       private string _appPath = string.Empty;
       public string AppPath
       {
           get
           {
               if (string.IsNullOrEmpty(_appPath))
               {
                   string path = Application.ExecutablePath;
                   if (path.Contains(@"\"))
                   {
                       int pos = path.LastIndexOf(@"\");
                       path = path.Remove(pos + 1);
                   }
                   if (!path.EndsWith(@"\"))
                       path += @"\";
                   _appPath=path;
                   
               }
               return _appPath;
           }
       }
       private const string DOCUMENTS = "Document";

        

       

        /// <summary>
        /// 医疗文书路径
        /// </summary>
        public string DocumentPath
        {
            get
            {
                string path = AppPath + DOCUMENTS + @"\";
                CheckDirectory(path);
                return path;
            }
        }

        private void CheckDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!Directory.Exists(path))
            {
                throw new Exception(string.Format("目录{0}不存在，并且无法创建", path));
            }
        }

        private Dictionary<string, string> _monitorFunctionCodeDict = new Dictionary<string, string>();

        public Dictionary<string, string> MonitorFunctionCodeDict
        {
            get { return _monitorFunctionCodeDict; }
            set { _monitorFunctionCodeDict = value; }
        }

        private Dictionary<string, string> _bloodGasItemDict = new Dictionary<string, string>();

        public Dictionary<string, string> BloodGasItemDict
        {
            get { return _bloodGasItemDict; }
            set { _bloodGasItemDict = value; }
        }

        private List<string> _defaultBloodGasItem = new List<string>();

        public List<string> DefaultBloodGasItem
        {
            get { return _defaultBloodGasItem; }
            set { _defaultBloodGasItem = value; }
        }


        private bool _isYueJi = false;

        public bool IsYueJi
        {
            get { return _isYueJi; }
            set { _isYueJi = value; }
        }


        public int IsMatchingUser
        {
            get { return _IsMatchingUser; }
            set { _IsMatchingUser = value; }
        }


    }
}

