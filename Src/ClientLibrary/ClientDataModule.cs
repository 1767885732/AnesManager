using System;
using System.Text.RegularExpressions;
using System.Configuration;
using Wis.Anes.ClientLibrary.Properties;
using Wis.Anes.Interface;

namespace Wis.Anes.ClientLibrary
{
    /// <summary>
    /// 客户端数据访问的入口
    /// </summary>
    public class ClientDataModule
    {
        //thread safe
        private static object _lock = new object();

        private static ClientDataModule _instance;

        //private static IDeptInOrOutMgr _iDeptInOrOutMgr = null;
        private static IDataModelProxy _proxy;
        private static IPermission _iPermission;
        //private static IBedMgr _iBedMgr;
        //private static IBloodGas _iBloodGas;
        //private static IBreath _iBreath;
        private static ICommon _iCommon;
        //private static IPatient _iPatient;
        private static IDict _iDict;
        //private static INursingPlan _iNursingPlan;
        //private static IOrder _iOrder;
        //private static ICareItems _iCareItems;
        //private static IChoiceItem _iChoiceItem;
        //private static IOperation _iOperation;
        private static ICareDocs _iCareDocs;
        //private static IWorkFlow _iWorkFlow;
        private static IStatistics _iStatistics;
        //private static ICheckReport _iCheckReport;
        private static IScore _iScore;
        private static IConfiguration _iConfiguration;
        //private static IContrastGraph _iContrastGraph;
        //private static IAilmentDiagnosis _iAilmentDiagnosis;
        //private static IEvaluate _iEvaluate;
        //private static IExplanationDoc _iExplanationDoc;
        //private static ITreatmentFlow _iTreatmentFlow;
        //private static IEmrUploadHelper _iEmrUploadHelper;
        //private static IElectronicOrders _iElectronicOrders;
        //private static INurseSchedule _iNurseSchedule;
        //private static IInfectionManage _infectionManage;
        //private static IOrderInformation _iOrderInformation = null;
        //private static IQualityControl _iQualityControl;
        //private static IPingGu _iPingGu;
        //private static IDoc _doc;

        private static IAnalgesic _iAnalgesic;
        private static IAnesMaster _iAnesMaster;
        private static IAnesthesiaSheet _iAnesthesiaSheet;
        private static ICPB _iCPB;
        private static IPatientInformations _iPatientInformations;
        private static ISync _iSync;

        public enum CallType { Local, Remote, LocalForSqlServer };
        static public string RemoteUrl = "";
        private ClientDataModule()
        {
        }

        ///// <summary>
        ///// 提供出入科管理的IDeptInOrOutMgr的接口属性
        ///// 访问：ClientDataModule.Instance.DeptInOrOutMgr
        ///// </summary>
        //public static IDeptInOrOutMgr DeptInOrOutMgr
        //{
        //    get
        //    {
        //        if (_iDeptInOrOutMgr == null)
        //        {
        //            _iDeptInOrOutMgr = (IDeptInOrOutMgr)DataModalProxy;

        //        }
        //        return _iDeptInOrOutMgr;
        //    }
        //}

        /// <summary>
        /// ClientDataModule唯一实例
        /// </summary>
        public static ClientDataModule Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ClientDataModule();
                        }
                    }
                }
                return _instance;
            }
        }
        /// <summary>
        /// 设置Remoting配置
        /// </summary>
        /// <param name="callType">访问类型本地还是Remote</param>
        /// <param name="channelType">通道类型</param>
        /// <param name="ip">IP地址</param>
        /// <param name="port">端口号</param>
        public static void SetRemotingSettings(CallType callType, string channelType, string ip, string port, string clentID, string hospitalID, string webServiceAdd)
        {
            if (callType == CallType.Remote)
            {
                if (channelType.Trim().ToUpper() != "HTTP" && channelType.Trim().ToUpper() != "TCP")
                {
                    throw new Exception("通道类型只可以为TCP,HTTP二者之一,设置失败,请重新设置!");
                }
            }
            Settings Config = Settings.Default;
            if (callType == CallType.Remote)
            {
                string Pattern = @"^(((\d{1,2})|(1\d{2})|(2[0-4]\d)|(25[0-5]))(\.|,)){1,3}((\d{1,2})|(1\d{2})|(2[0-4]\d)|(25[0-5]))$";
                if (!Regex.IsMatch(ip, Pattern))
                {
                    throw new Exception("IP地址格式错误,设置失败,请重新设置!");
                }
                if (!Regex.IsMatch(port, @"^\d+$"))
                {
                    throw new Exception("端口格式错误,设置失败,请重新设置!");
                }
                if (int.Parse(port) > 65535)
                {
                    throw new Exception("端口号错误,设置失败,请重新设置!");
                }
                string Url = channelType + "://" + ip + ":" + port + "/icu.rem";
                Config.Url = Url;
            }
            Config.Type = callType.ToString();
            Config.ClentID = clentID;
            Config.HospitalID = hospitalID;
            Config.WebServiceAddress = webServiceAdd;
            Config.Save();
        }

        /// <summary>
        /// 获取本地配置配置
        /// </summary>
        /// <returns>配置信息,不会返回null</returns>
        public static string[] GetSettings()
        {
            string[] configInfo = new string[5];
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ClientDataModuleSettings remoteSection = (ClientDataModuleSettings)config.GetSection("clientDataModule");
            if (remoteSection != null)
            {
                configInfo[0] = remoteSection.CallType;
                configInfo[1] = remoteSection.ClentID;
                configInfo[2] = remoteSection.HospitalID;
                configInfo[3] = remoteSection.RemotingUrl;
                configInfo[4] = "";
            }
            return configInfo;
        }

        /// <summary>
        /// 病人主索引
        /// </summary>
        public static int PatientIndex
        {
            get
            {
                return Settings.Default.PatientIndex;
            }
            set
            {
                if (Settings.Default.PatientIndex != value)
                {
                    Settings.Default.PatientIndex = value;
                    Settings.Default.Save();
                }
            }
        }

        /// <summary>
        /// 病人主索引
        /// </summary>
        public static string PatientId
        {
            get
            {
                return Settings.Default.PatientId;
            }
            set
            {
                if (Settings.Default.PatientId != value)
                {
                    Settings.Default.PatientId = value;
                    Settings.Default.Save();
                }
            }
        }

        /// <summary>
        /// 提供数据访问的IDataModelProxy的接口属性
        /// 访问：ClientDataModule.Instance.DataModalProxy
        /// </summary>
        static internal IDataModelProxy DataModalProxy
        {
            get
            {
                if (_proxy == null)
                {
                    lock (_lock)
                    {
                        if (_proxy == null)
                        {
                            string Url = "", Type = "";
                            ClientDataModuleSettings setting = ClientDataModuleSettings.GetSection();

                            Url = setting.Type + "://" + setting.RemotingUrl + ":" + setting.Port + "/icu.rem";
                            Type = setting.CallType;
                            if (Type.ToLower() == "remoting")
                            {
                                //_proxy = (IDataModelProxy)new RemoteDataModelProxy(Url);
                            }
                            else
                            {
                                //_proxy = (IDataModelProxy)new LocalDataModelProxy();
                            }
                        }
                    }
                }
                return _proxy;
            }
        }

        /// <summary>
        /// 提供权限管理的IPermission的接口属性
        /// 访问：ClientDataModule.Instance.Permission
        /// </summary>
        public static IPermission Permission
        {
            get
            {
                return (IPermission)DataModalProxy;
            }
        }

        ///// <summary>
        ///// 提供床位管理的IBedMgr的接口属性
        ///// 访问：ClientDataModule.Instance.BedMgr
        ///// </summary>
        //public static IBedMgr BedMgr
        //{
        //    get
        //    {
        //        if (_iBedMgr == null)
        //        {
        //            _iBedMgr = (IBedMgr)DataModalProxy;

        //        }
        //        return _iBedMgr;
        //    }
        //}

        //public static IQualityControl QualityControl
        //{
        //    get
        //    {
        //        if (_iQualityControl == null)
        //        {
        //            _iQualityControl = (IQualityControl)DataModalProxy;

        //        }
        //        return _iQualityControl;
        //    }
        //}

        ///// <summary>
        ///// 提供床位管理的IBedMgr的接口属性
        ///// 访问：ClientDataModule.Instance.IBloodGas
        ///// </summary>
        //public static IBloodGas BloodGas
        //{
        //    get
        //    {
        //        if (_iBloodGas == null)
        //        {
        //            _iBloodGas = (IBloodGas)DataModalProxy;

        //        }
        //        return _iBloodGas;
        //    }
        //}

        ///// <summary>
        ///// 提供床位管理的IBedMgr的接口属性
        ///// 访问：ClientDataModule.Instance.IBreath
        ///// </summary>
        //public static IBreath Breath
        //{
        //    get
        //    {
        //        if (_iBreath == null)
        //        {
        //            _iBreath = (IBreath)DataModalProxy;

        //        }
        //        return _iBreath;
        //    }
        //}

        /// <summary>
        /// 提供通用管理的ICommon的接口属性
        /// 访问：ClientDataModule.Instance.Common
        /// </summary>
        public static ICommon Common
        {
            get
            {
                if (_iCommon == null)
                {
                    _iCommon = (ICommon)DataModalProxy;

                }
                return _iCommon;
            }
        }

        ///// <summary>
        ///// 提供病人信息和监护仪管理的IPatient的接口属性
        ///// 访问：ClientDataModule.Instance.Patient
        ///// </summary>
        //public static IPatient Patient
        //{
        //    get
        //    {
        //        if (_iPatient == null)
        //        {
        //            _iPatient = (IPatient)DataModalProxy;

        //        }
        //        return _iPatient;
        //    }
        //}


        /// <summary>
        /// 提供数据字典的IDict的接口属性
        /// 访问：ClientDataModule.Instance.Dict
        /// </summary>
        public static IDict Dict
        {
            get
            {
                if (_iDict == null)
                {
                    _iDict = (IDict)DataModalProxy;

                }
                return _iDict;
            }
        }

        ///// <summary>
        ///// 提供数据字典的IDict的接口属性
        ///// 访问：ClientDataModule.Instance.NursingPlan
        ///// </summary>
        //public static INursingPlan NursingPlan
        //{
        //    get
        //    {
        //        if (_iNursingPlan == null)
        //        {
        //            _iNursingPlan = (INursingPlan)DataModalProxy;

        //        }
        //        return _iNursingPlan;
        //    }
        //}
        ///// <summary>
        ///// 提供医嘱的IOrder的接口属性
        ///// 访问：ClientDataModule.Instance.Order
        ///// </summary>
        //public static IOrder Order
        //{
        //    get
        //    {
        //        if (_iOrder == null)
        //        {
        //            _iOrder = (IOrder)DataModalProxy;

        //        }
        //        return _iOrder;
        //    }
        //}

        ///// <summary>
        ///// 提供ICareItems的接口属性
        ///// 访问：ClientDataModule.Instance.CareItems
        ///// </summary>
        //public static ICareItems CareItems
        //{
        //    get
        //    {
        //        if (_iCareItems == null)
        //        {
        //            _iCareItems = (ICareItems)DataModalProxy;

        //        }
        //        return _iCareItems;
        //    }
        //}

        ///// <summary>
        ///// 提供IChoiceItem的接口属性
        ///// 访问：ClientDataModule.Instance.ChoiceItem
        ///// </summary>
        //public static IChoiceItem ChoiceItem
        //{
        //    get
        //    {
        //        if (_iChoiceItem == null)
        //        {
        //            _iChoiceItem = (IChoiceItem)DataModalProxy;

        //        }
        //        return _iChoiceItem;
        //    }
        //}

        //public static IOperation Operation
        //{
        //    get
        //    {
        //        if (_iOperation == null)
        //        {
        //            _iOperation = (IOperation)DataModalProxy;

        //        }
        //        return _iOperation;
        //    }
        //}

        /// <summary>
        /// 提供ICareDocs的接口属性
        /// 访问：ClientDataModule.Instance.CareDocs
        /// </summary>
        public static ICareDocs CareDocs
        {
            get
            {
                if (_iCareDocs == null)
                {
                    _iCareDocs = (ICareDocs)DataModalProxy;

                }
                return _iCareDocs;
            }
        }

        ///// <summary>
        ///// 提供IWorkFlow的接口属性
        ///// 访问：ClientDataModule.Instance.WorkFlow
        ///// </summary>
        //public static IWorkFlow WorkFlow
        //{
        //    get
        //    {
        //        if (_iWorkFlow == null)
        //        {
        //            _iWorkFlow = (IWorkFlow)DataModalProxy;

        //        }
        //        return _iWorkFlow;
        //    }
        //}
        ///// <summary>
        ///// 提供访问ICheckReport的接口属性
        ///// 访问ClientDataModule.Instance.CheckReport
        ///// </summary>
        //public static ICheckReport CheckReport
        //{
        //    get
        //    {
        //        if (_iCheckReport == null)
        //        {
        //            _iCheckReport = (ICheckReport)DataModalProxy;
        //        }
        //        return _iCheckReport;
        //    }
        //}
        /// <summary>
        /// 提供访问IScore的接口属性
        /// 访问ClientDataModule.Instance.Score
        /// </summary>
        public static IScore Score
        {
            get
            {
                if (_iScore == null)
                {
                    _iScore = (IScore)DataModalProxy;
                }
                return _iScore;
            }
        }
        /// <summary>
        /// 提供访问IConfiguration的接口属性
        /// 访问ClientDataModule.Instance.Configuration
        /// </summary>
        public static IConfiguration Configuration
        {
            get
            {
                if (_iConfiguration == null)
                {
                    _iConfiguration = (IConfiguration)DataModalProxy;
                }
                return _iConfiguration;
            }
        }

        /// <summary>
        /// 提供访问IStatistics的接口属性
        /// </summary>
        public static IStatistics Statistics
        {
            get
            {
                if (_iStatistics == null)
                {
                    _iStatistics = (IStatistics)DataModalProxy;
                }
                return _iStatistics;
            }
        }
        ///// <summary>
        ///// 提供访问IContrastGraph的接口属性
        ///// </summary>
        //public static IContrastGraph ContrastGraph
        //{
        //    get
        //    {
        //        if (_iContrastGraph == null)
        //        {
        //            _iContrastGraph = (IContrastGraph)DataModalProxy;
        //        }
        //        return _iContrastGraph;
        //    }
        //}
        ///// <summary>
        ///// 提供访问IAilmentDiagnosis的接口属性
        ///// </summary>
        //public static IAilmentDiagnosis AilmentDiagnosis
        //{
        //    get
        //    {
        //        if (_iAilmentDiagnosis == null)
        //        {
        //            _iAilmentDiagnosis = (IAilmentDiagnosis)DataModalProxy;
        //        }
        //        return _iAilmentDiagnosis;
        //    }
        //}
        ///// <summary>
        ///// 提供访问ITransfer的接口属性
        ///// </summary>
        //public static IEvaluate Evaluate
        //{
        //    get
        //    {
        //        if (_iEvaluate == null)
        //        {
        //            _iEvaluate = (IEvaluate)DataModalProxy;
        //        }
        //        return _iEvaluate;
        //    }
        //}

        ///// <summary>
        ///// 提供访问ITransfer的接口属性
        ///// </summary>
        //public static IExplanationDoc ExplanationDoc
        //{
        //    get
        //    {
        //        if (_iExplanationDoc == null)
        //        {
        //            _iExplanationDoc = (IExplanationDoc)DataModalProxy;
        //        }
        //        return _iExplanationDoc;
        //    }
        //}

        //public static ITreatmentFlow TreatmentFlow
        //{
        //    get
        //    {
        //        if (_iTreatmentFlow == null)
        //        {
        //            _iTreatmentFlow = (ITreatmentFlow)DataModalProxy;
        //        }
        //        return _iTreatmentFlow;
        //    }
        //}

        //public static IEmrUploadHelper EmrUploadHelper
        //{
        //    get
        //    {
        //        if (_iEmrUploadHelper == null)
        //        {
        //            _iEmrUploadHelper = (IEmrUploadHelper)DataModalProxy;
        //        }
        //        return _iEmrUploadHelper;
        //    }
        //}

        //public static IElectronicOrders ElectronicOrders
        //{
        //    get
        //    {
        //        if (_iElectronicOrders == null)
        //        {
        //            _iElectronicOrders = (IElectronicOrders)DataModalProxy;
        //        }
        //        return _iElectronicOrders;
        //    }
        //}

        //public static INurseSchedule NurseSchedule
        //{
        //    get
        //    {
        //        if (_iNurseSchedule == null)
        //        {
        //            _iNurseSchedule = (INurseSchedule)DataModalProxy;
        //        }
        //        return _iNurseSchedule;
        //    }
        //}

        //public static IInfectionManage InfectionManage
        //{
        //    get
        //    {
        //        if (_infectionManage == null)
        //        {
        //            _infectionManage = (IInfectionManage)DataModalProxy;
        //        }
        //        return _infectionManage;
        //    }
        //}

        //public static IOrderInformation OrderInformation
        //{
        //    get
        //    {
        //        if (_iOrderInformation == null)
        //        {
        //            _iOrderInformation = (IOrderInformation)DataModalProxy;
        //        }
        //        return _iOrderInformation;
        //    }
        //}

        //public static IPingGu PingGuDan
        //{
        //    get
        //    {
        //        if (_iPingGu == null)
        //        {
        //            _iPingGu = (IPingGu)DataModalProxy;

        //        }

        //        return _iPingGu;
        //    }

        //}

        //public static IDoc Doc
        //{
        //    get
        //    {
        //        if (_doc == null)
        //            _doc = (IDoc)DataModalProxy;

        //        return _doc;
        //    }
        //}

        public static IAnalgesic Analgesic
        {
            get
            {
                if (_iAnalgesic == null)
                    _iAnalgesic = (IAnalgesic)DataModalProxy;

                return _iAnalgesic;
            }
        }

        public static IAnesMaster AnesMaster
        {
            get
            {
                if (_iAnesMaster == null)
                    _iAnesMaster = (IAnesMaster)DataModalProxy;

                return _iAnesMaster;
            }
        }

        public static IAnesthesiaSheet AnesthesiaSheet
        {
            get
            {
                if (_iAnesthesiaSheet == null)
                    _iAnesthesiaSheet = (IAnesthesiaSheet)DataModalProxy;

                return _iAnesthesiaSheet;
            }
        }

        public static ICPB CPB
        {
            get
            {
                if (_iCPB == null)
                    _iCPB = (ICPB)DataModalProxy;

                return _iCPB;
            }
        }

        public static IPatientInformations PatientInformations
        {
            get
            {
                if (_iPatientInformations == null)
                    _iPatientInformations = (IPatientInformations)DataModalProxy;

                return _iPatientInformations;
            }
        }

        public static ISync Sync
        {
            get
            {
                if (_iSync == null)
                    _iSync = (ISync)DataModalProxy;

                return _iSync;
            }
        }
    }
}
