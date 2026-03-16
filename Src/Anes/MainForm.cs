/*----------------------------------------------------------------
// 北京拓扑工厂科技发展有限公司
// 文件名：MainForm.cs
// 文件功能描述：主界面
// 创建标识：XXX-2008-10-23
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Wis.Anes.Framework;
using Wis.Anes.Framework.Views;
using Wis.Anes.Constants;
using Wis.Anes;
using Wis.Anes.Papers;
using Wis.Anes.Views;
using Wis.Anes.ServiceProxies;
using Wis.Anes.Framework.Designer;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.Framework.Documents;
using Wis.Anes.BusinessEntity;
using System.Diagnostics;
using Wis.Anes.Layouts;
using Wis.Anes.Framework.Permissions;

using Wis.Anes.Framework.Utilities;
using Wis.Anes.Views.Patient;
using DevExpress.XtraBars;
using Wis.Anes.Framework.CustomSetting;
using Wis.Anes;
using Wis.Anes.Framework.Views.BillManager;
using Wis.Anes.DataAccess;
using Wis.Anes.Framework.Doc;
using Wis.Anes.Framework.Documents.DefaultHandlers;
using Wis.Anes.Framework.Views.Process;
using Wis.Anes.Views.Information;
using Wis.Anes.Views.Patient.Process;
using Score.Common.Controls;

namespace Wis.Anes
{
    /// <summary>
    /// 主界面窗体
    /// </summary>
    public partial class MainForm : XtraForm
    {
        public MainForm()
        {
            InitializeComponent();



            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);


            //初始化时最小化，防止闪烁
            //this.WindowState = FormWindowState.Minimized;

            this.Opacity = 0;
        }

        /// <summary>
        /// 选择患者界面
        /// </summary>
        private PatientListView _patients = null;
        //BaseDoc _patientInfoDoc=null;

        /// <summary>
        /// 飘窗
        /// </summary>
        private FloatFrm floatFrm;

        //截获窗体最大化最小化消息

        private bool isLockSystem = false;
        private void InitalizeUI()
        {
            //获取配置信息
            try
            {
                // PopulateCodeTables();
                panelControl1.Width = this.standaloneBarDockControl1.Width;
                this.topBarControl1.Width = panelControl1.Width;
                this.topBarControl1.MecicalDocBarControl.Width = panelControl1.Width;

                //ExtendApplicationContext.Current.ConfigTable = ConfigurationProxy.GetConfigTableDataTable();
                barStaticLoginUser.Caption = "当前用户：" + ExtendApplicationContext.Current.LoginUserContext.UserName;

                this.workSpaceControl1.SizeChanged += new EventHandler(workSpaceControl1_SizeChanged);



                OperationDone();
                SplashFormHelper.MessageNotify("正在初始化字典项目...");

                PopulateCodeTables();
                SplashFormHelper.MessageNotify("正在初始化采集项目...");
                LoadMonitorFunctionCodeDict();
                SplashFormHelper.MessageNotify("正在初始化血气项目...");
                LoadBloodGasItem();
                //加载用户权限
                SplashFormHelper.MessageNotify("正在初始化用户权限...");
                LoadUserPermissions();

                SplashFormHelper.MessageNotify("正在初始化左侧导航栏...");
                InitLeftBarControl();

                SplashFormHelper.MessageNotify("正在初始化主工作区...");
                InitWorkSpaceControl();
                SplashFormHelper.MessageNotify("正在初始化上方状态栏...");
                InitTopBarControl();
                SplashFormHelper.MessageNotify("正在初始化医疗文书...");
                InitMecicalDocBarControl();
                SplashFormHelper.MessageNotify("正在初始化系统皮肤...");
                if (_patients != null)
                    _patients.Focus();



                workSpaceControl1.operationRoomPandect.Initial();
                workSpaceControl1.operationRoomPandect.PatientSelected += new EventHandler(patients_SelectChanged2);
                this.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);




                //进度框置顶 防止 窗体变大时闪烁
                //SplashFormHelper.MessageNotify("TopMost");

                //this.WindowState = FormWindowState.Maximized;


                this.Opacity = 100;
                SplashFormHelper.HideSplashForm();

            }
            catch (Exception ex)
            {
                SplashFormHelper.HideSplashForm();
                ExceptionHandler.Handle(ex);
                Application.Exit();
            }



        }

        protected void OperationDone()
        {
            CommonProxy.ExecuteNonQuery(string.Format("UPDATE WIS_OPER_MASTER SET OPER_STATUS = 80 WHERE (OUT_DATE_TIME + {0}) <= SYSDATE", ApplicationConfiguration.OperationDoneDays));
        }

        void workSpaceControl1_SizeChanged(object sender, EventArgs e)
        {
            //如果为竖屏
            //if (Screen.PrimaryScreen.Bounds.Width < Screen.PrimaryScreen.Bounds.Height)
            //{
            //    if (this.dockPanel1.Visibility == DevExpress.XtraBars.Docking.DockVisibility.AutoHide)
            //        this.workSpaceControl1.Padding = new Padding(0, 0, 0, 0);
            //    else
            //    {
            //        if (this.workSpaceControl1.Controls[0] is BaseDoc)
            //        {
            //            this.workSpaceControl1.Padding = new Padding(50, 0, 0, 0);
            //        }

            //    }
            //}
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;

            }

            #region 单机版 需要时放开
            ////单机版 需要时放开

            //if (ExtendApplicationContext.Current.LocalMode) //  单机模式下
            //{
            //    SplashFormHelper.MessageNotify("正在加载本地数据...");
            //    //加载二进制
            //    //byte[] dataSetBytes = DataBinaryHelper.ReadFileToByteBuffer(System.Environment.CurrentDirectory + "\\Bin\\hospital.mdsd");
            //    //ExtendApplicationContext.Current.AnesInfoAllDataSet = DataBinaryHelper.BinaryToDataSet(dataSetBytes);
            //    DirectoryInfo dir = new DirectoryInfo(System.Environment.CurrentDirectory + "\\Bin\\Tables\\");
            //    if (dir.Exists)
            //    {
            //        FileInfo[] fileInfos = dir.GetFiles();
            //        if (fileInfos != null && fileInfos.Length > 0)
            //        {
            //            foreach (FileInfo fileInfo in fileInfos)
            //            {
            //                byte[] dataSetBytes = DataBinaryHelper.ReadFileToByteBuffer(fileInfo.FullName);
            //                DataTable data = DataBinaryHelper.BinaryToDataTable(dataSetBytes);
            //                if (data != null)
            //                {
            //                    if (!ExtendApplicationContext.Current.AliasDict.ContainsKey(data.TableName))
            //                    {
            //                        ExtendApplicationContext.Current.AliasDict.Add(data.TableName, fileInfo.Name);
            //                    }
            //                    if (!ExtendApplicationContext.Current.AnesInfoAllDataSet.Tables.Contains(data.TableName))
            //                    {
            //                        ExtendApplicationContext.Current.AnesInfoAllDataSet.Tables.Add(data);
            //                    }
            //                }
            //            }
            //            //string f = "";
            //        }
            //    }
            //}
            //else
            //{

            //    //加载10天患者主表到本地
            //    AnesInformations.OperationMasterDataTable opm = AnesthesiaSheetProxy.GetOperationMaster(DateTime.Now.AddDays(-10), DateTime.Now);
            //    //加载当天患者基本信息到本地

            //    string patientID = "";
            //    foreach (AnesInformations.OperationMasterRow opmr in opm)
            //    {
            //        patientID = opmr.PATIENT_ID;
            //        PatientInformationsProxy.GetPatMasterIndexDataTable(patientID);

            //    }

            //    //加载监护仪字典信息到本地
            //    DictProxy.GetMonitorFunctionCode();
            //}

            #endregion

            ExtendApplicationContext.Current.SystemCurrentProcess = ProgramProcess.SystemBeforeLoad;
            ExtendApplicationContext.Current.ConfigTable = ConfigurationProxy.GetConfigTableDataTable();
            InitalizeSystem();
            InitalizeUI();
            if (ExtendApplicationContext.Current.AppType == ApplicationType.Anesthesia && ExtendApplicationContext.Current.CustomSettingContext.IsShowUnDonePatientListView)
            {
                DataTable dt = new PatientInformationsDA().GetUnDonePatientList(ApplicationConfiguration.OpertionRoom);
                if (dt != null && dt.Rows.Count > 0)
                {
                    Dictionary<string, MedicalDocElement> docs = MedicalDocSettings.GetCustomForms();
                    KeyValuePair<string, MedicalDocElement> keyValuePairDoc = new KeyValuePair<string, MedicalDocElement>();
                    foreach (KeyValuePair<string, MedicalDocElement> keyValuePair in docs)
                    {
                        if (keyValuePair.Key.Trim() == "术中患者")
                        {
                            keyValuePairDoc = keyValuePair;
                            break;
                        }
                    }

                    //没有找到退出
                    if (string.IsNullOrEmpty(keyValuePairDoc.Key))
                    {
                        DialogResult dialogResult = XtraMessageBox.Show("自定义【术中患者】模块加载失败，请检查配置！",
                                              "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    try
                    {
                        //读取配置 ，加载 急诊登记
                        Type t = Type.GetType(keyValuePairDoc.Value.Type);
                        BaseView view = Activator.CreateInstance(t) as BaseView;
                        DialogHostForm dialogHostForm = new DialogHostForm(view.Caption, view.Width, view.Height);
                        dialogHostForm.Child = view;
                        dialogHostForm.ShowDialog();
                        if (dialogHostForm.DialogResult == DialogResult.OK)
                        {
                            ChangePatient();
                        }
                    }
                    catch (Exception ex)
                    {
                        Exception excep = new Exception("自定义【术中患者】模块加载失败，请检查配置！");
                        ex.Source = excep.Source;
                        ExceptionHandler.Handle(excep);
                    }
                }
            }


            ExtendApplicationContext.Current.SystemCurrentProcess = ProgramProcess.SystemAfterLoad;
            timerResponse.Start();
        }

        /// <summary>
        /// 初始化系统参数
        /// </summary>
        private void InitalizeSystem()
        {

            if (ApplicationConfiguration.IsPACUProgram)
            {
                //制定PACU
                ExtendApplicationContext.Current.AppType = ApplicationType.PACU;
                //制定EventNo
                ExtendApplicationContext.Current.EventNo = 1;
                //this.Text = "麻醉临床信息系统—复苏子系统";

            }
            else if (ApplicationConfiguration.IsNurseProgram)
            {
                ExtendApplicationContext.Current.AppType = ApplicationType.Nurse;
            }
            else if (ApplicationConfiguration.IsDirectorProgram)
            {
                ExtendApplicationContext.Current.AppType = ApplicationType.Director;
            }
            else if (ApplicationConfiguration.IsYouDaoProgram)
            {
                ExtendApplicationContext.Current.AppType = ApplicationType.YouDao;
                ExtendApplicationContext.Current.EventNo = 3;
            }
            Text = ApplicationConfiguration.AppTitle;

            try
            {
                //读取配置 ，加载 CustomSetting
                string customSettingKey = ApplicationConfiguration.CustomSettingProvider;
                //System.Reflection.Assembly.Load();

                Type t = Type.GetType(customSettingKey);
                ICustomSetting customSetting = Activator.CreateInstance(t) as ICustomSetting;
                if (customSetting != null)
                {
                    customSetting.InitCustomSetting();
                }
                else
                {
                    Exception e = new Exception("自定义 客户化模块加载失败，请检查配置，启动系统默认 客户化模块！");
                    e.Source = "加载  客户化模块";
                    ExceptionHandler.Handle(e);
                }
            }
            catch (Exception ex)
            {

                Exception e = new Exception("自定义 客户化模块加载失败，请检查配置，启动系统默认 客户化模块！");
                e.Source = ex.StackTrace;
                ExceptionHandler.Handle(e);
            }

            ExtendApplicationContext.Current.HospitalID = DictProxy.GetHospitalID();

            DateTime serverTime = CommonProxy.GetSysDateTime();
            CommonSysemHelper.SetLocalSystemDate(serverTime);
        }

        /// <summary>
        /// 加载用户登录权限
        /// </summary>
        private void LoadUserPermissions()
        {
            // ApplicationConfiguration.PermissionModel
            Permissions.PermissiosDataTable permissionList = PermissionProxy.GetPermissionByLoginName(ExtendApplicationContext.Current.ApplicationID, ExtendApplicationContext.Current.LoginUserContext.LoginName);
            if (permissionList != null)
            {
                foreach (Permissions.PermissiosRow permission in permissionList)
                {
                    Framework.AccessControl.AddPermission(permission.PERMISSION_KEY, permission.IS_VALID);
                }
            }

            try
            {
                //读取配置 ，加载 PermissionProvider
                string permissionProvider = ApplicationConfiguration.PermissionProvider;
                //System.Reflection.Assembly.Load();

                Type t = Type.GetType(permissionProvider);
                PermissionProvider permissionProviderCustom = Activator.CreateInstance(t) as PermissionProvider;
                if (permissionProviderCustom != null)
                {
                    Framework.AccessControl.PermissionProviderCustom = permissionProviderCustom;
                }
            }
            catch (Exception ex)
            {

                Exception e = new Exception("自定义权限模块加载失败，请检查配置，启动系统默认权限模块！");
                e.Source = ex.Source;
                ExceptionHandler.Handle(e);
            }
        }


        /// <summary>
        /// 所有采集项目字典
        /// </summary>
        private void LoadMonitorFunctionCodeDict()
        {

            Dict.MonitorFunctionCodeDataTable monitorFunctionCodeDataTable = null;
            if (ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_MONITOR_FUNC_CODE"))
            {
                monitorFunctionCodeDataTable = ExtendApplicationContext.Current.CodeTables["WIS_MONITOR_FUNC_CODE"] as Dict.MonitorFunctionCodeDataTable;
            }
            else
            {
                monitorFunctionCodeDataTable = DictProxy.GetMonitorFunctionCode();
            }
            if (monitorFunctionCodeDataTable != null && monitorFunctionCodeDataTable.Count > 0)
            {
                foreach (Dict.MonitorFunctionCodeRow codeRow in monitorFunctionCodeDataTable.Rows)
                {
                    if (!ExtendApplicationContext.Current.MonitorFunctionCodeDict.ContainsKey(codeRow.ITEM_CODE))
                    {
                        ExtendApplicationContext.Current.MonitorFunctionCodeDict.Add(codeRow.ITEM_CODE, codeRow.ITEM_NAME);
                    }
                }
            }
            if (!ExtendApplicationContext.Current.MonitorFunctionCodeDict.ContainsKey("ECG"))
            {
                ExtendApplicationContext.Current.MonitorFunctionCodeDict.Add("ECG", "ECG");
            }
        }

        /// <summary>
        /// 初始化血气代码名称字典及默认显示项目
        /// </summary>
        private void LoadBloodGasItem()
        {
            Dict.BloodGasDictDataTable bloodGasDictDataTable = DictProxy.GetBloodGasDict();
            if (bloodGasDictDataTable != null && bloodGasDictDataTable.Count > 0)
            {
                foreach (Dict.BloodGasDictRow row in bloodGasDictDataTable.Rows)
                {
                    if (!ExtendApplicationContext.Current.BloodGasItemDict.ContainsKey(row.BLG_CODE))
                    {
                        ExtendApplicationContext.Current.BloodGasItemDict.Add(row.BLG_CODE, row.BLG_NAME);
                    }
                    if (row.BLG_STATUS == "1")
                    {
                        if (!ExtendApplicationContext.Current.DefaultBloodGasItem.Contains(row.BLG_CODE))
                        {
                            ExtendApplicationContext.Current.DefaultBloodGasItem.Add(row.BLG_CODE);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 加载字典表数据
        /// </summary>
        private void PopulateCodeTables()
        {
            List<KeyValue> list = DictTableNamesDropDownEditor.Tables;
            //ExtendApplicationContext.Current.CodeTables.Clear();

            foreach (KeyValue keyValue in list)
            {
                if (!ExtendApplicationContext.Current.CodeTables.ContainsKey(keyValue.Value))
                {
                    if (keyValue.Value.ToUpper() == "WIS_MONITOR_FUNC_CODE")
                    {
                        Dict.MonitorFunctionCodeDataTable dt = DictProxy.GetMonitorFunctionCode();
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }
                    //药品字典表
                    else if (keyValue.Value.ToUpper() == "WIS_ANES_EVENT_OPEN")
                    {
                        Dict.AnesthesiaEventOpenDataTable dt = DictProxy.GetAnesthesiaEventOpen();
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }//WIS_OPER_ROOM
                    else if (keyValue.Value.ToUpper() == "WIS_OPER_ROOM".ToUpper())
                    {
                        Dict.OperatingRoomDataTable dt = DictProxy.GetOperatingRoomDict();
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }
                    else if (keyValue.Value.ToUpper() == "WIS_DICT_ANES_INPUT".ToUpper())//录入字典表
                    {
                        Dict.AnesthesiaInputDictDataTable dt = DictProxy.GetAnesthesiaInputDict();
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }
                    else if (keyValue.Value.ToUpper() == "WIS_DICT_DIAGNOSIS".ToUpper())//诊断字典表
                    {
                        Dict.WisDiagnosisDictDataTable dt = DictProxy.GetDiagnosisDict();
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }
                    else if (keyValue.Value.ToUpper() == "WIS_DICT_OPERATION".ToUpper())//手术名称字典表
                    {
                        Dict.OperationDictDataTable dt = DictProxy.GetOperationDict();
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }
                    else if (keyValue.Value.ToUpper() == "WIS_PERM_HIS_USER".ToUpper())//医护人员字典表
                    {
                        Dict.HisUserDataTable dt = DictProxy.GetHisUsers();
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }
                    else if (keyValue.Value.ToUpper() == "WIS_DICT_ANES".ToUpper())//麻醉方法字典表
                    {
                        Dict.AnessthestaDictDataTable dt = DictProxy.GetAnesDict();
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }
                    else if (keyValue.Value.ToUpper() == "WIS_PRICE_LIST")//药品耗材字典表
                    {
                        Dict.PriceListDataTable dt = DictProxy.GetPriceList();
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }
                    else if (keyValue.Value.ToUpper() == "WIS_DICT_DEPT".ToUpper())//科室字典
                    {
                        Dict.DeptDictDataTable dt = DictProxy.GetDeptDict();
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }
                    else if (keyValue.Value.ToUpper() == "WIS_DICT_BLOOD_GAS")
                    {
                        Dict.BloodGasDictDataTable dt = DictProxy.GetBloodGasDict();
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }
                    else//WIS_DICT_ANES_COMM
                    {
                        DataTable dt = CommonProxy.GetDataWithPrimaryKey(keyValue.Value);
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }
                }
            }

            //如果连专家系统，则加载
            if (ApplicationConfiguration.IsConnACS)
            {
                DataTable dt = CommonProxy.GetAcsArticleKeyWord();
                ExtendApplicationContext.Current.CodeTables.Add("STANDARD_ARTICLE_KEYWORD", dt);
            }

            //加载HISUSER列表
        }


        #region "顶端栏目项目  相关事件处理"
        /// <summary>
        /// 初始化上边栏目项目
        /// </summary>
        private void InitTopBarControl()
        {

            try
            {
                // this.topBarControl1.SetBackGroundImage(ApplicationConfiguration.GetSkinImage("logo.jpg"), ApplicationConfiguration.GetSkinImage("top_bj.jpg"), ApplicationConfiguration.GetSkinImage("topspliter.png"), ApplicationConfiguration.GetSkinImage("PatientInfoLine.jpg"), ApplicationConfiguration.GetSkinImage("患者.png"));
                this.topBarControl1.SetBackGroundImage(ApplicationConfiguration.GetSkinImage("logo.jpg"), ApplicationConfiguration.GetSkinImage("TopBack.jpg"), ApplicationConfiguration.GetSkinImage("topspliter.gif"), ApplicationConfiguration.GetSkinImage("PatientInfoLine.jpg"), ApplicationConfiguration.GetSkinImage("People.jpg"), ApplicationConfiguration.GetSkinImage("TopBack.jpg"));


                this.topBarControl1.NormalImage = ApplicationConfiguration.GetSkinImage("NormalImage.png");
                this.topBarControl1.PassedImage = ApplicationConfiguration.GetSkinImage("PassedImage.png");
                this.topBarControl1.LightImage = ApplicationConfiguration.GetSkinImage("LightImage.png");

                //设置状态灯图片
                this.topBarControl1.SetStatusLightImage();


                //获取当前状态状态按钮
                string text = ApplicationConfiguration.PatientStatusButtons;
                this.topBarControl1.CreatePatientStatusButtons(text);

                this.topBarControl1.SetPatientStatusAction(new PandectOperationStatusAction());
                this.topBarControl1.MainFormRef = this;
                this.topBarControl1.StatusChangedEvent += new EventHandler<StatusChangedEventArges>(StatusChangedEventHandler);
                this.topBarControl1.RefreshStatusEvent += new EventHandler(RefreshStatus);
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }

        /// <summary>
        /// 顶端手术状态改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StatusChangedEventHandler(object sender, StatusChangedEventArges e)
        {

        }






        #endregion


        #region "PatientListView 选中 事件相关处理"
        /// <summary>
        /// 选患者界面单击患者事件-显示右侧详细信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patients_PatientClick(object sender, EventArgs e)
        {
            if (floatFrm != null)
            {
                floatFrm.Close();
            }
            PatientContentViewNew patient = (sender as PatientListView).ShowPatient;
            if (patient == null) patient = (sender as PatientListView).SelectedPatient;
            if (patient != null)
            {
                if (_patients != null)
                {
                    this._patients.RefreshSelectedPatient(patient);
                }

                //BaseDoc doc = workSpaceControl1.CurrentControl as BaseDoc;
                //if (doc == null)
                //{
                //    PatientInformation patientInformation = patient.PatientInformation;
                //    if (patientInformation != null)
                //    {
                //        ExtendApplicationContext.Current.PatientContext.PatientID = patientInformation.PatientID;
                //        ExtendApplicationContext.Current.PatientContext.VisitID = patientInformation.VisitID;
                //        ExtendApplicationContext.Current.PatientContext.OperID = patientInformation.OperID;
                //    }
                //    else
                //    {
                //        ExtendApplicationContext.Current.PatientContext.PatientID = "";
                //    }
                //    ExtendApplicationContext.Current.PatientInformation = patientInformation;

                //    RefreshPatientInfo();

                //}




            }
        }


        private void patients_SelectChanged2(object sender, EventArgs e)
        {
            BaseDoc doc = workSpaceControl1.CurrentControl as BaseDoc;
            if (doc != null)
            {
                string oldName = doc.Name;
                patients_SelectChanged(sender, e);

                if (ExtendApplicationContext.Current.AppType == ApplicationType.Anesthesia)
                {
                    if (Framework.AccessControl.CheckModifyRightForOperator(doc.Name))//有Modify权限
                    {
                        doc.SetAllControlEditable(true);
                    }
                    else
                    {
                        doc.SetAllControlEditable(false);
                    }

                    if (doc.AllowSingleDocModify())
                    {
                        doc.SetAllControlEditable(true);
                    }
                }

                if (workSpaceControl1.CurrentControl.Name != oldName)
                {
                    workSpaceControl1.AddDocToWorkSpace(doc);
                    doc.RefreshData(true);
                }
            }
        }

        /// <summary>
        /// 选患者界面选中患者后事件-主界面同步更新->激活患者默认操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patients_SelectChanged(object sender, EventArgs e)
        {

            topBarControl1.SetPatientStatusContrlEnable(false);
            ChangePatient();

            /*防止没有配置默认界面时，对状态栏仍可进行编辑的操作
            bool enable = false;
            if (!Framework.AccessControl.CheckDoneDocumentRight())
            {
                enable = false;
                topBarControl1.SetPatientStatusContrlEnable(enable);
            }
            else
            {
                topBarControl1.SetPatientStatusContrlEnable(enable);
                if (ExtendApplicationContext.Current.AppType == ApplicationType.Anesthesia)
                {
                    if (Framework.AccessControl.CheckModifyRightForOperator("麻醉单"))//有Modify权限
                    {
                        topBarControl1.SetPatientStatusContrlReadOnly(true);
                    }
                    else
                    {
                        topBarControl1.SetPatientStatusContrlReadOnly(false);
                    }
                }
                else if (ExtendApplicationContext.Current.AppType == ApplicationType.PACU)
                {
                    topBarControl1.SetPatientStatusContrlReadOnly(true);
                }
            }*/
        }

        /// <summary>
        /// 改变患者信息
        /// </summary>
        private void ChangePatient()
        {
            Cursor = Cursors.WaitCursor;

            RefreshPatientInfo();
            if (ExtendApplicationContext.Current.PatientInformation != null)
            {
                ExtendApplicationContext.Current.SystemStatus = ProgramStatus.SelectPatient;
                OperationStatus operationStatus = (OperationStatus)(int)ExtendApplicationContext.Current.PatientInformation.OperStatus;
                SetOperationStatus(operationStatus);
                this.leftBarControl1.SetCurrentViewNavigateButtons();
                leftBarControl1.SetLockPatBtn();
            }





            Cursor = Cursors.Default;
        }

        /// <summary>
        /// 设置手术状态
        /// </summary>
        /// <param name="operationStatus"></param>
        public void SetOperationStatus(OperationStatus operationStatus)
        {


            if (string.IsNullOrEmpty(ExtendApplicationContext.Current.PatientInformation.OperRoom)
                && operationStatus != OperationStatus.CancelOperation)
            {
                XtraMessageBox.Show("检测到当前手术未设定【手术间】，请先从【手术信息】模块中填写明确信息！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowFormByDocName(ViewNames.OperationInformation, 850, 600);
                //if (string.IsNullOrEmpty(ExtendApplicationContext.Current.PatientInformation.OperRoom)) return;
            }


            ExtendApplicationContext.Current.OperationStatus = operationStatus;
            RefreshOperationStatus();
            //if (_patients != null)
            //{
            //    _patients.RefreshPatientDataTable(ExtendApplicationContext.Current.PatientInformation.PatientID, ExtendApplicationContext.Current.PatientInformation.VisitID, ExtendApplicationContext.Current.PatientInformation.OperID);
            //}
        }





        //定时刷新麻醉单或复苏单
        public void RefreshAnesDocOnRefreshTimeSpan()
        {
            if (ExtendApplicationContext.Current.AppType == ApplicationType.Anesthesia || ExtendApplicationContext.Current.AppType == ApplicationType.PACU)
            {
                var current = GetCurrentControl();
                if (current is BaseDoc)
                {
                    BaseDoc doc = current as BaseDoc;
                    if (doc.HasDirty())
                    {
                        if (!doc.ValidateData())
                        {
                            return;
                        }
                        else
                        {
                            doc.Save(false);
                        }
                    }

                    Cursor = Cursors.WaitCursor;
                    try
                    {

                        doc.RefreshData();
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandler.Handle(ex);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }
                }
            }

        }
        public void CustomRefreshAnesDoc()
        {

            if (ExtendApplicationContext.Current.AppType == ApplicationType.Anesthesia || ExtendApplicationContext.Current.AppType == ApplicationType.PACU)
            {
                var current = GetCurrentControl();
                if (current is BaseDoc)
                {
                    BaseDoc doc = current as BaseDoc;
                    Cursor = Cursors.WaitCursor;
                    try
                    {
                        doc.CustomRefresh();
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandler.Handle(ex);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }

                }
            }



        }




        bool isRefreshCurrentWorkControlFinished = true;
        //刷新当前工作区域文书
        public void RefreshCurrentWorkControl()
        {
            if (isRefreshCurrentWorkControlFinished == false)
                return;

            isRefreshCurrentWorkControlFinished = false;
            if (ExtendApplicationContext.Current.AppType == ApplicationType.Anesthesia || ExtendApplicationContext.Current.AppType == ApplicationType.PACU || ExtendApplicationContext.Current.AppType == ApplicationType.YouDao)
            {
                var current = GetCurrentControl();
                if (current is BaseDoc)
                {
                    BaseDoc doc = current as BaseDoc;
                    if (doc.HasDirty())
                    {
                        DialogResult dialogResult = XtraMessageBox.Show("您当前的界面有未保存的数据,是否保存此数据?",
                            "提示信息", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            if (!doc.ValidateData())
                            {
                                isRefreshCurrentWorkControlFinished = true;
                                return;
                            }
                            else
                            {
                                if (!doc.OnCustomCheckBeforeSave()) return;
                                doc.Save();
                            }
                        }
                        else if (dialogResult == DialogResult.Cancel)
                        {
                            isRefreshCurrentWorkControlFinished = true;
                            return;
                        }

                    }

                    Cursor = Cursors.WaitCursor;
                    try
                    {

                        doc.RefreshData();
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandler.Handle(ex);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }

                }



            }
            isRefreshCurrentWorkControlFinished = true;


        }
        public void RefreshOperationStatus()
        {
            if (ExtendApplicationContext.Current.AppType == ApplicationType.Anesthesia || ExtendApplicationContext.Current.AppType == ApplicationType.PACU || ExtendApplicationContext.Current.AppType == ApplicationType.YouDao
                  || ExtendApplicationContext.Current.AppType == ApplicationType.Nurse || ExtendApplicationContext.Current.AppType == ApplicationType.Director)
            {
                // 加载 当前状态下文书按钮
                RefreshPatientDocButtons(ExtendApplicationContext.Current.OperationStatus);


                //执行当前状态下特殊操作，如弹出监护仪等
                DoOperationStatusActions(ExtendApplicationContext.Current.OperationStatus);


                //更新患者列表信息
                _patients.RefreshPatientDataTable(ExtendApplicationContext.Current.PatientInformation.PatientID, ExtendApplicationContext.Current.PatientInformation.VisitID, ExtendApplicationContext.Current.PatientInformation.OperID);



                if (ExtendApplicationContext.Current.PatientInformation != null)
                {
                    //设置手术状态灯
                    this.topBarControl1.SetStatusLight(ExtendApplicationContext.Current.OperationStatus);

                    //设置手术时间
                    this.topBarControl1.SetOperationStatusTimeText(ExtendApplicationContext.Current.OperationStatus);
                }

            }
        }

        /// <summary>
        /// 执行手术状态默认动作
        /// </summary>
        /// <param name="operationStatus"></param>
        private void DoOperationStatusActions(OperationStatus operationStatus)
        {
            string text = OperationStatusHelper.GetOperAction(operationStatus);
            //if (ExtendApplicationContext.Current.AppType.Equals(ApplicationType.CardiopulmonaryBypass))
            //{
            //    text = "";
            //    if (Configurations.IsCPBEditorFirst)
            //    {
            //        text = "转中登记";
            //    }
            //}
            if (string.IsNullOrEmpty(text)) return;

            string[] actions = text.Split(',');
            foreach (string s in actions)
            {
                if (!string.IsNullOrEmpty(s))
                {
                    ExecuteAction(s);
                }
            }
        }
        /// <summary>
        /// 执行手术状态默认动作,和超级配置关联
        /// </summary>
        /// <param name="actionName"></param>
        protected virtual void ExecuteAction(string actionName)
        {
            DateTime dt = DateTime.Now;

            switch (actionName)
            {
                case "麻醉单":
                    if (this.topBarControl1.MecicalDocBarControl._AnesDocButtom != null)
                    {
                        this.topBarControl1.MecicalDocBarControl._AnesDocButtom.PerformClick();
                    }
                    else
                    {
                        ShowDocByDocName(ApplicationConfiguration.AnesDocName);
                    }

                    break;
                case ViewNames.SetMonitor:
                    {
                        SelectMonitor setMonitor = new SelectMonitor(ExtendApplicationContext.Current.PatientInformation, ExtendApplicationContext.Current.EventNo);
                        this.workSpaceControl1.ShowViewDialog(setMonitor, setMonitor.Width, setMonitor.Height + 30);
                        break;
                    }
                default:
                    ShowDocByDocName(actionName);
                    break;
            }
        }

        /// <summary>
        /// 刷新患者信息头（顶部左边患者信息提示栏）
        /// </summary>
        private void RefreshPatientInfo()
        {
            if (ExtendApplicationContext.Current.PatientInformation != null)
            {
                #region Modify @2014-02-14 复苏程序的手术间号显示为复苏床位号
                //topBarControl1.RefreshPatientInfo(ExtendApplicationContext.Current.PatientInformation.OperRoom, ExtendApplicationContext.Current.PatientInformation.PatientID, ExtendApplicationContext.Current.PatientInformation.Name);
                BusinessEntity.Dict.OperatingRoomDataTable dt = new DataAccess.DictDA().GetOperatingRoomDict();
                BusinessEntity.Dict.OperatingRoomRow[] row = null;
                if (dt != null && dt.Rows.Count > 0)
                {
                    row = dt.Select(string.Format("PAT_ID='{0}' AND VISIT_ID={1} AND OPER_ID={2}", (string)ExtendApplicationContext.Current.PatientInformation.PatientID,
                        ExtendApplicationContext.Current.PatientInformation.VisitID, ExtendApplicationContext.Current.PatientInformation.OperID)) as BusinessEntity.Dict.OperatingRoomRow[];
                }
                if (ExtendApplicationContext.Current.AppType == ApplicationType.PACU && row != null && row.Length > 0)
                {
                    topBarControl1.RefreshPatientInfo(row[0].ROOM_NO, (string)ExtendApplicationContext.Current.PatientInformation.PatientID, (string)ExtendApplicationContext.Current.PatientInformation.Name);
                }
                else
                {
                    topBarControl1.RefreshPatientInfo((string)ExtendApplicationContext.Current.PatientInformation.OperRoom, (string)ExtendApplicationContext.Current.PatientInformation.PatientID, (string)ExtendApplicationContext.Current.PatientInformation.Name);
                }
                #endregion
                //topBarControl1.RefreshPatientInfo((string)ExtendApplicationContext.Current.PatientInformation.OperRoom, (string)ExtendApplicationContext.Current.PatientInformation.PatientID, (string)ExtendApplicationContext.Current.PatientInformation.Name);

                //string text = OperationStatusHelper.OperationStatusToString((OperationStatus)(int)ExtendApplicationContext.Current.PatientInformation.OperStatus);
                //if (string.IsNullOrEmpty(text)) text = "未定义";
                //lblPatInfo.Text = "当前状态:" + text;
                //if (_noTopButtons)
                //{
                //    picPatientInfoBak.Invalidate();
                //}
            }
        }
        #endregion


        #region "工作区域(workSpaceControl)  相关事件处理"


        /// <summary>
        /// 初始化工作区域项目
        /// </summary>
        private void InitWorkSpaceControl()
        {

            try
            {
                this.workSpaceControl1.ViewChangedEvent += new EventHandler<ViewChangedEventArgs>(workSpaceControl1_ViewChanged);
                if (_patients == null)
                {
                    //生成患者信息列表
                    //_patients = new PatientListView(ApplicationConfiguration.SelectPatientBackColor, ApplicationConfiguration.PatientNormalBackColor, ApplicationConfiguration.GetSkinImage("Room.jpg")
                    //, ApplicationConfiguration.GetSkinImage("Room1.jpg"), ApplicationConfiguration.GetSkinImage("Room.jpg"));

                    _patients = new PatientListView();
                    _patients.PatientClick += new EventHandler(patients_PatientClick);

                    _patients.SelectChanged += new EventHandler(patients_SelectChanged);
                }

                workSpaceControl1.Initial(_patients);

                ReturnPatientList();
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }


        }

        /// <summary>
        /// 返回患者清单
        /// </summary>
        public void ReturnPatientList()
        {


            try
            {
                //Modify by xiasen.x@20140530,切换用户时不进行时间节点的验证
                //避免用户点击查看麻醉单后不做任何操作，但是切换用户时不断地提示造成麻醉单分页
                //if (!topBarControl1.PatientStatusControl.IsValid()) return;
                //End Modify
                RefreshCurrentWorkControl();
                workSpaceControl1.AddPatientView();
                //this.workSpaceControl1.AddViewToWorkSpace(_patients, "PatientListView");

                foreach (Control c in this.topBarControl1.MecicalDocBarControl.Controls)
                {
                    if (c is SimpleButton)
                    {
                        SimpleButton btn = c as SimpleButton;
                        if (btn.ButtonStyle != DevExpress.XtraEditors.Controls.BorderStyles.Simple)
                            btn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                    }
                }
                _patients.Focus();
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }
        /// <summary>
        /// 获取当前工作区域 子窗体
        /// </summary>
        /// <returns></returns>
        public Control GetCurrentControl()
        {
            return workSpaceControl1.CurrentControl;

            /*if (workSpaceControl1.Controls.Count > 0)
            {
                return workSpaceControl1.Controls[0];
            }
            else
            {
                return workSpaceControl1;
            }*/
        }

        /// <summary>
        /// 根据主窗体界面改变左侧导航菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void workSpaceControl1_ViewChanged(object sender, ViewChangedEventArgs e)
        {
            if (floatFrm != null && FloatFrm.isFloat)
            {
                floatFrm.Close();
            }
            Control ctl = GetCurrentControl();
            string anesDocName = ApplicationConfiguration.AnesDocName;
            //Dictionary<string, MedicalDocElement> docs = MedicalDocSettings.GetMedicalDocNameAndPath();
            //List<string> docs = ApplicationConfiguration.MedicalDocumentList;

            //KeyValuePair<string, MedicalDocElement> keyValuePairAnesDoc = new KeyValuePair<string, MedicalDocElement>();



            if (string.IsNullOrEmpty(e.ViewName))
            {
                if (ExtendApplicationContext.Current.AppType == ApplicationType.Anesthesia)
                {
                    if (Framework.AccessControl.CheckModifyRightForOperator("麻醉记录单") || Framework.AccessControl.CheckModifyRightForOperator("麻醉单") ||
                        Framework.AccessControl.CheckModifyRightForOperator("麻醉记录"))
                        topBarControl1.SetPatientStatusContrlEnable(true);
                    else topBarControl1.SetPatientStatusContrlEnable(false);
                }
                else if (ExtendApplicationContext.Current.AppType == ApplicationType.PACU)
                {
                    if (Framework.AccessControl.CheckModifyRightForOperator("复苏记录单") || Framework.AccessControl.CheckModifyRightForOperator("复苏单") ||
                        Framework.AccessControl.CheckModifyRightForOperator("PACU") || Framework.AccessControl.CheckModifyRightForOperator("PACU单") ||
                        Framework.AccessControl.CheckModifyRightForOperator("PACU记录单"))
                        topBarControl1.SetPatientStatusContrlEnable(true);
                    else topBarControl1.SetPatientStatusContrlEnable(false);
                }
                else topBarControl1.SetPatientStatusContrlEnable(true);
            }
            else
            {
                topBarControl1.SetPatientStatusContrlEnable(false);
            }


            if (ExtendApplicationContext.Current.PatientInformation != null && ctl != null)
            {
                if (ctl is BaseDoc)
                {
                    BaseDoc doc = ctl as BaseDoc;
                    if (doc.DocKind.Equals(DocKind.Anes))
                    {
                        ExtendApplicationContext.Current.SystemStatus = ProgramStatus.AnesthesiaRecord;
                    }
                    else if (doc.DocKind.Equals(DocKind.PACU))
                    {
                        ExtendApplicationContext.Current.SystemStatus = ProgramStatus.PACURecord;
                    }
                    else if (doc.DocKind.Equals(DocKind.CPB))
                    {
                        ExtendApplicationContext.Current.SystemStatus = ProgramStatus.CPBReport;
                    }
                    else
                    {
                        ExtendApplicationContext.Current.SystemStatus = ProgramStatus.SelectPatient;
                    }
                }
                else
                {
                    ExtendApplicationContext.Current.SystemStatus = ProgramStatus.SelectPatient;
                }
                this.leftBarControl1.SetCurrentViewNavigateButtons();
                leftBarControl1.SetLockPatBtn();
            }
        }
        #endregion

        #region 状态栏初始化
        private void PopulateSkinToolBarItems()
        {
            List<string> skins = new List<string>();
            PopulateSkinToolBarItems(this.ShinBarSubItem, skins);

            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.XtraBars.BarSubItem bonusSkins = new DevExpress.XtraBars.BarSubItem();
            bonusSkins.Caption = "BonusSkins";
            this.ShinBarSubItem.AddItem(bonusSkins);
            PopulateSkinToolBarItems(bonusSkins, skins);

            DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.XtraBars.BarSubItem officeSkins = new DevExpress.XtraBars.BarSubItem();
            officeSkins.Caption = "OfficeSkins";
            this.ShinBarSubItem.AddItem(officeSkins);
            PopulateSkinToolBarItems(officeSkins, skins);

            skins.Clear();
        }

        private void PopulateSkinToolBarItems(BarSubItem barButtonItem, List<string> skins)
        {
            foreach (DevExpress.Skins.SkinContainer skinContainer in DevExpress.Skins.SkinManager.Default.Skins)
            {
                if (!skins.Contains(skinContainer.SkinName))
                {
                    DevExpress.XtraBars.BarButtonItem barItem = new DevExpress.XtraBars.BarButtonItem();
                    barItem.Caption = skinContainer.SkinName;
                    barItem.Name = skinContainer.SkinName;
                    if (barItem.Name == "MySkin_Blue1")
                        barItem.Caption = "默认皮肤";
                    barItem.ItemClick += delegate
                    {
                        this.defaultLookAndFeel1.LookAndFeel.SkinName = barItem.Name;
                        if (barItem.Name == "MySkin_Blue1")
                        {
                            this.topBarControl1.MecicalDocBarControl.SetBackGroundImage(ApplicationConfiguration.GetSkinImage("clock.jpg"), ApplicationConfiguration.GetSkinImage("TabPageRight.gif"));
                            this.topBarControl1.SetBackGroundImage(ApplicationConfiguration.GetSkinImage("logo.jpg"), ApplicationConfiguration.GetSkinImage("TopBack.jpg"), ApplicationConfiguration.GetSkinImage("topspliter.gif"), ApplicationConfiguration.GetSkinImage("PatientInfoLine.jpg"), ApplicationConfiguration.GetSkinImage("People.jpg"), ApplicationConfiguration.GetSkinImage("TopBack.jpg"));
                            this.topBarControl1.MecicalDocBarControl.SetClockColor(Color.White);
                            this.topBarControl1.ShowLogButtom(false);
                        }
                        else
                        {
                            this.topBarControl1.MecicalDocBarControl.SetBackGroundImage(ApplicationConfiguration.GetSkinImage("闹钟.png"), ApplicationConfiguration.GetSkinImage("中间背景2.png"));
                            this.topBarControl1.SetBackGroundImage(ApplicationConfiguration.GetSkinImage("logo3.png"), ApplicationConfiguration.GetSkinImage("topBg2.jpg"), ApplicationConfiguration.GetSkinImage("topspliter.gif"), ApplicationConfiguration.GetSkinImage("PatientInfoLine.jpg"), ApplicationConfiguration.GetSkinImage("People.jpg"), ApplicationConfiguration.GetSkinImage("topBg2.jpg"));
                            this.topBarControl1.MecicalDocBarControl.SetClockColor(this.topBarControl1.MecicalDocBarControl.ForeColor);
                            this.topBarControl1.ShowLogButtom(false);
                        }


                    };
                    barButtonItem.AddItem(barItem);
                    skins.Add(skinContainer.SkinName);
                }


            }
        }
        #endregion

        #region "文书状态栏  相关事件处理"



        /// <summary>
        /// 初始化文书工作栏
        /// </summary>
        private void InitMecicalDocBarControl()
        {

            try
            {
                this.topBarControl1.MecicalDocBarControl.SetBackGroundImage(ApplicationConfiguration.GetSkinImage("clock.jpg"), ApplicationConfiguration.GetSkinImage("TabPageRight.gif"));
                int _RefreshTimeSpan = ApplicationConfiguration.RefreshTimeSpan;
                if (_RefreshTimeSpan <= 2)
                {
                    _RefreshTimeSpan = 120;
                }
                this.topBarControl1.MecicalDocBarControl.RefreshTimeSpan = _RefreshTimeSpan;
                this.topBarControl1.MecicalDocBarControl.OnRefreshTimeSpanRequest += new MecicalDocBarControl.RefreshTimeSpanRequest(this.OnRefreshTimeSpanRefreshDoc);
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }

        //刷新麻醉单等文书 定时
        private void OnRefreshTimeSpanRefreshDoc(object sender, EventArgs e)
        {
            var current = GetCurrentControl();
            if (current is BaseDoc)
            {
                BaseDoc doc = current as BaseDoc;
                if (doc.DocKind == DocKind.Anes || doc.DocKind == DocKind.PACU)
                    RefreshAnesDocOnRefreshTimeSpan();
            }
        }


        /// <summary>
        /// 根据手术状态刷新文书工具栏
        /// </summary>
        /// <param name="operationStatus"></param>
        private void RefreshPatientDocButtons(OperationStatus operationStatus)
        {

            //string text = OperationStatusHelper.GetOperDocument(operationStatus);
            //mecicalDocBarControl1.PatientDocButtons = text;
            //mecicalDocBarControl1.DocButtonStartLeft = this.leftBarControl1.Width + 10;
            //mecicalDocBarControl1.CreateDocButtons();
            //// 获取文书按钮列表
            ////List<Button> PatientDocButtonsList = mecicalDocBarControl1.PatientDocButtonsList;
            //foreach (Control ctl in mecicalDocBarControl1.Controls)
            //{
            //    if (ctl is SimpleButton)
            //        ctl.Click += new EventHandler(docButton_Click);
            //}



            string text = OperationStatusHelper.GetOperDocument(operationStatus);
            topBarControl1.MecicalDocBarControl.PatientDocButtons = text;
            //topBarControl1.MecicalDocBarControl.DocButtonStartLeft = this.leftBarControl1.Width + 275;
            topBarControl1.MecicalDocBarControl.CreateDocButtons();
            // 获取文书按钮列表
            //List<Button> PatientDocButtonsList = topBarControl1.MecicalDocBarControl.PatientDocButtonsList;
            foreach (Control ctl in topBarControl1.MecicalDocBarControl.Controls)
            {
                if (ctl is SimpleButton)
                    ctl.Click += new EventHandler(docButton_Click);
            }

        }

        /// <summary>
        /// 文书按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void docButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ExtendApplicationContext.Current.PatientContext.PatientID))
                return;
            SimpleButton docButton = (SimpleButton)sender;

            string strDocName = (docButton.Tag == null) ? "" : docButton.Tag.ToString();

            //if ("麻醉单,麻醉记录单".Contains(docButton.Tag.ToString()))
            //{
            //    AnesInformations.AnesthesiaPlanDataTable dt = new AnesthesiaSheetDA().GetAnesthesiaPlan(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID);
            //    if (dt.Rows.Count > 0)
            //    {
            //        if (string.IsNullOrEmpty(dt.Rows[0]["ASA_GRADE"].ToString()))
            //        {
            //            Dialog.MessageBox("请于[术前访视单]中填写ASA分级。");
            //            return;
            //        }
            //    }
            //}
            
            //传入值
            ShowDocByDocName(docButton.Tag.ToString());

            this.workSpaceControl1.Focus();
        }


        /// <summary>
        /// 在工作区域显示文书
        /// </summary>
        /// <param name="docName"></param>
        public void ShowDocByDocName(string docName)
        {
            //获取当前工作区域 子窗体
            var current = GetCurrentControl();

            #region <<当前是BaseDoc或是其派生类的处理>>
            if (current is BaseDoc)
            {
                BaseDoc doc = current as BaseDoc;

                #region <<当前界面是否需要保存验证>>
                if (doc.HasDirty())
                {
                    DialogResult dialogResult = XtraMessageBox.Show("您当前的界面有未保存的数据,是否保存此数据?",
                        "提示信息", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (!doc.ValidateData())
                            return;
                        else
                        {
                            if (!doc.OnCustomCheckBeforeSave()) return;
                            doc.Save();
                        }

                    }
                    else if (dialogResult == DialogResult.Cancel)
                        return;
                }
                #endregion

                #region <<再次请求“麻醉单”时的处理>>
                //麻醉单已经打开，请求的还是麻醉单，则直接刷新，不用重新Load
                if (doc.DocKind == DocKind.Anes && docName == "麻醉单")
                {

                    Cursor = Cursors.WaitCursor;
                    try
                    {
                        doc.RefreshData();
                        this.workSpaceControl1.RaiseEvent("");
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandler.Handle(ex);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }

                    return;
                }
                #endregion
            }
            #endregion



            ApplicationConfiguration.MedicalDocucementElement document = ApplicationConfiguration.GetMedicalDocument(docName);

            //没有找到退出
            if (string.IsNullOrEmpty(document.Caption))
            {
                DialogResult dialogResult = XtraMessageBox.Show(string.Format("无法加载文书'{0}'的设计模版,请确保模版文件已经存在", docName),
                        "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.workSpaceControl1.AddDocToWorkSpace(null);
                return;
            }

            try
            {

                Type t = Type.GetType(document.Type);
                BaseDoc baseDoc = Activator.CreateInstance(t) as BaseDoc;
                baseDoc.BackColor = Color.White;
                baseDoc.Name = docName;
                baseDoc.HideScrollBar();
                baseDoc.Initial();



                baseDoc.LoadReport(ExtendApplicationContext.Current.AppPath + document.Path);
                if (baseDoc.DocKind == DocKind.Anes)
                {
                    baseDoc.AfterPrint += new Wis.Anes.Framework.Documents.BaseDoc.EventAfterPrint(AfterPrint);

                }
                this.workSpaceControl1.AddDocToWorkSpace(baseDoc);


                //baseDoc.RefreshLoginInfo += delegate { barStaticLoginUser.Caption = "当前用户：" + ExtendApplicationContext.Current.LoginUserContext.UserName; };


                //通过一个定时器来降低文书界面闪烁的烦恼
                Timer a = new Timer();
                a.Interval = 1;
                a.Tick += delegate
                {
                    baseDoc.ShowScrollBar();
                    //销毁定义器
                    a.Enabled = false;
                    a.Stop();
                    a.Dispose();

                };
                a.Enabled = true;






                var currentbaseDoc = GetCurrentControl();
                //Modify By wenpei.x@2013-06-03
                //文书改为只有麻醉单检查操作者
                //if (ExtendApplicationContext.Current.AppType == ApplicationType.Anesthesia)
                //{
                //    if (Framework.AccessControl.CheckModifyRightForOperator(docName))//有Modify权限
                //    {



                //        if (currentbaseDoc is BaseDoc)
                //        {
                //            ((BaseDoc)currentbaseDoc).SetAllControlEditable(true);
                //        }
                //    }
                //    else
                //    {
                //        if (currentbaseDoc is BaseDoc)
                //        {
                //            ((BaseDoc)currentbaseDoc).SetAllControlEditable(false);
                //        }
                //    }
                //    if (currentbaseDoc is BaseDoc)
                //    {
                //        if (((BaseDoc)currentbaseDoc).AllowSingleDocModify())
                //        {
                //            ((BaseDoc)currentbaseDoc).SetAllControlEditable(true);
                //        }
                //    }
                //}
                //else if (ExtendApplicationContext.Current.AppType == ApplicationType.PACU)
                //{
                //    if ((currentbaseDoc is BaseDoc) && ((BaseDoc)currentbaseDoc).DocKind == DocKind.Anes && docName == "麻醉单")
                //    {
                //        if (Framework.AccessControl.CheckModifyRightForOperator("麻醉单"))//有Modify权限
                //        {
                //            if (currentbaseDoc is BaseDoc)
                //            {
                //                ((BaseDoc)currentbaseDoc).SetAllControlEditable(true);
                //            }
                //        }
                //        else
                //        {
                //            if (currentbaseDoc is BaseDoc)
                //            {
                //                ((BaseDoc)currentbaseDoc).SetAllControlEditable(false);
                //            }
                //        }
                //    }
                //    else
                //    {
                //        if (currentbaseDoc is BaseDoc)
                //        {

                //            ((BaseDoc)currentbaseDoc).SetAllControlEditable(true);
                //        }
                //    }

                //}
                if (ExtendApplicationContext.Current.OperationStatus == OperationStatus.Done)
                {
                    ((BaseDoc)currentbaseDoc).SetAllControlEditable(false);
                    return;
                }
                if (ExtendApplicationContext.Current.AppType == ApplicationType.Anesthesia)
                {
                    if (docName.Contains("麻醉单") || docName.Contains("麻醉记录单") || ((BaseDoc)currentbaseDoc).DocKind == DocKind.Anes)
                    {
                        if (Framework.AccessControl.CheckModifyRightForOperator(docName))//有Modify权限
                        {



                            if (currentbaseDoc is BaseDoc)
                            {
                                ((BaseDoc)currentbaseDoc).SetAllControlEditable(true);
                            }
                        }
                        else
                        {
                            if (currentbaseDoc is BaseDoc)
                            {
                                ((BaseDoc)currentbaseDoc).SetAllControlEditable(false);
                            }
                        }
                    }
                    else
                    {
                        if (Framework.AccessControl.CheckModifyRight(docName))//有Modify权限
                        {



                            if (currentbaseDoc is BaseDoc)
                            {
                                ((BaseDoc)currentbaseDoc).SetAllControlEditable(true);
                            }
                        }
                        else
                        {
                            if (currentbaseDoc is BaseDoc)
                            {
                                ((BaseDoc)currentbaseDoc).SetAllControlEditable(false);
                            }
                        }
                    }
                    if (currentbaseDoc is BaseDoc)
                    {
                        if (((BaseDoc)currentbaseDoc).AllowSingleDocModify())
                        {
                            ((BaseDoc)currentbaseDoc).SetAllControlEditable(true);
                        }
                    }
                }
                else if (ExtendApplicationContext.Current.AppType == ApplicationType.PACU)
                {
                    if ((currentbaseDoc is BaseDoc) && ((BaseDoc)currentbaseDoc).DocKind == DocKind.Anes && docName == "麻醉单")
                    {
                        if (Framework.AccessControl.CheckModifyRightForOperator("麻醉单"))//有Modify权限
                        {
                            if (currentbaseDoc is BaseDoc)
                            {
                                ((BaseDoc)currentbaseDoc).SetAllControlEditable(true);
                            }
                        }
                        else
                        {
                            if (currentbaseDoc is BaseDoc)
                            {
                                ((BaseDoc)currentbaseDoc).SetAllControlEditable(false);
                            }
                        }
                    }
                    else
                    {
                        if (Framework.AccessControl.CheckModifyRight(docName))//有Modify权限
                        {



                            if (currentbaseDoc is BaseDoc)
                            {
                                ((BaseDoc)currentbaseDoc).SetAllControlEditable(true);
                            }
                        }
                        else
                        {
                            if (currentbaseDoc is BaseDoc)
                            {
                                ((BaseDoc)currentbaseDoc).SetAllControlEditable(false);
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }


        // 打印后触发事件 用于刷新界面
        private void AfterPrint(object sender, EventArgs e)
        {
            if (ExtendApplicationContext.Current.AppType == ApplicationType.Anesthesia)
            {

                var current = GetCurrentControl();
                if (current is BaseDoc)
                {
                    BaseDoc doc = ((BaseDoc)current);
                    //左侧导航栏刷新
                    this.leftBarControl1.SetCurrentViewNavigateButtons(true);
                    leftBarControl1.SetLockPatBtn();
                    string strDocName = string.IsNullOrEmpty(doc.Name) ? "麻醉单" : doc.Name;

                    if (Framework.AccessControl.CheckModifyRightForOperator(strDocName))//有Modify权限
                    {
                        //文书刷新
                        doc.SetAllControlEditable(true);
                        //顶部控件刷新
                        topBarControl1.SetPatientStatusContrlReadOnly(true);
                    }
                    else
                    {
                        doc.SetAllControlEditable(false);
                        //顶部控件刷新
                        topBarControl1.SetPatientStatusContrlReadOnly(false);
                    }
                }

            }
        }
        #endregion


        #region 左侧导航相关

        /// <summary>
        /// 初始化左边栏目项目
        /// </summary>
        private void InitLeftBarControl()
        {
            ExtendApplicationContext.Current.StatusButtonStrList.Add(ProgramStatus.NoPatient, ApplicationConfiguration.NoPatientButtons);
            ExtendApplicationContext.Current.StatusButtonStrList.Add(ProgramStatus.SelectPatient, ApplicationConfiguration.SelectPatientButtons);
            ExtendApplicationContext.Current.StatusButtonStrList.Add(ProgramStatus.AnesthesiaRecord, ApplicationConfiguration.AnesthesiaRecordButtons);
            ExtendApplicationContext.Current.StatusButtonStrList.Add(ProgramStatus.PACURecord, ApplicationConfiguration.PACUButtons);
            ExtendApplicationContext.Current.StatusButtonStrList.Add(ProgramStatus.CPBReport, ApplicationConfiguration.CPBReportButtons);
            this.leftBarControl1.SetCurrentViewNavigateButtons();
            leftBarControl1.SetLockPatBtn();
            this.leftBarControl1.ViewChangedEvent += new EventHandler<ViewChangedEventArgs>(leftBarControl1_ViewChangedEventHandler);

        }



        /// <summary>
        /// 左边导航界面改变事件 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void leftBarControl1_ViewChangedEventHandler(object sender, ViewChangedEventArgs e)
        {
            if (e.ViewName.StartsWith("飘窗@"))  //飘窗
            {
                string key = e.ViewName.Replace("飘窗@", "");//事件类型中文名
                if (!string.IsNullOrEmpty(key))
                {
                    Control control = sender as Control;
                    int left = control.Width + 4;
                    FloatFrm.floatLocation = control.PointToScreen(new Point(left, 4));
                    if (!(FloatFrm.isFloat))
                    {
                        floatFrm = new FloatFrm();
                        floatFrm.AddEvent += new EventHandler(floatFrm_AddEvent);
                        floatFrm.Text = key;
                        FloatFrm.isFloat = true;
                        floatFrm.Width = 1024;
                        floatFrm.Left = (int)((Screen.PrimaryScreen.Bounds.Width - 1024) / 2);
                        floatFrm.ShowDialog();
                        floatFrm.BringToFront();
                    }
                    else
                    {
                        floatFrm.Text = key;
                    }
                }
            }
            else
            {
                if (floatFrm != null && FloatFrm.isFloat)
                {
                    floatFrm.Close();
                }
                if (ShowCustomForm(e.ViewName))
                {
                    Control control = GetCurrentControl();
                    if (control != null && control is BaseDoc)
                    {
                        BaseDoc doc = control as BaseDoc;
                        foreach (IUIElementHandler handler in doc.GetUIElementHandlers())
                        {
                            if (handler is GridViewHandler)
                            {
                                handler.RefreshData();
                                break;
                            }
                        }
                    }
                    return;
                }
                //Add @2014-02-12,在患者操作下配置按钮时，判断是否有当前选中患者，若无，则提示
                if (e.ViewName == ViewNames.HisAssay)  //检验信息
                {
                    if (ExtendApplicationContext.Current.PatientInformation == null)
                    {
                        Dialog.MessageBox("提示：请选中一个患者后再进行操作。");
                        return;
                    }
                    this.workSpaceControl1.ShowViewDialog(new AssayReport(), 800, 600);
                }
                else if (e.ViewName == ViewNames.HisCheckInfo)  //检查结果
                {
                    // 
                    if (ExtendApplicationContext.Current.PatientInformation == null)
                    {
                        Dialog.MessageBox("提示：请选中一个患者后再进行操作。");
                        return;
                    }
                    if (ExtendApplicationContext.Current.CustomSettingContext.IsHisCheckInfo)
                    {
                        this.workSpaceControl1.ShowViewDialog(new CheckInfoPanel(), 800, 600);
                    }
                    else
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(ExtendApplicationContext.Current.PatientInformation.PatientID))
                                SyncProxy.SyncPACS(ExtendApplicationContext.Current.PatientInformation.PatientID, ExtendApplicationContext.Current.PatientInformation.VisitID, null);
                        }
                        catch
                        { }
                    }
                }
                else if (e.ViewName == ViewNames.HisDocuments)  //病历病程
                {
                    if (ExtendApplicationContext.Current.PatientInformation == null)
                    {
                        Dialog.MessageBox("提示：请选中一个患者后再进行操作。");
                        return;
                    }
                    if (ExtendApplicationContext.Current.CustomSettingContext.IsCheckInfoShowDialog)
                    {
                        this.workSpaceControl1.ShowViewDialog(new DocumentsPanel(), 800, 600);
                    }
                    else
                    {

                        
                        try
                        {
                            if (!string.IsNullOrEmpty(ExtendApplicationContext.Current.PatientInformation.PatientID))
                            {
                                //SyncProxy.SyncEMR(ExtendApplicationContext.Current.PatientInformation.PatientID, ExtendApplicationContext.Current.PatientInformation.VisitID, null);

                                //调用第三方电子病历界面
                                string exePath = ConfigurationHelper.Read("EMRExePath");
                                string exeUid = ConfigurationHelper.Read("EMRExeUid");
                                string exePwd = ConfigurationHelper.Read("EMRExePwd");

                                string runargs = string.Format("run:INVOKERPATIENTEMR;uid:{0};pwd:{1};jzlsh:{2};DLKSBH:{3};", exeUid, exePwd, "", "");
                                //string runargs = "run:INVOKERPATIENTEMR;uid:9998;pwd:;jzlsh:17000270001;DLKSBH:00000001;";
                                string executeablePath = exePath;//@"E:\Company Projects\Old.EMR\trunk\sources\EMR\JMZ.EMRInvoker\bin\EMR外部调用接口\JMZ.EMRInvoker.exe";
                                ProcessStartInfo psi = new ProcessStartInfo();
                                psi.FileName = executeablePath; //设置执行路径
                                psi.UseShellExecute = false;
                                psi.WorkingDirectory = System.IO.Path.GetDirectoryName(executeablePath);//设置程序的执行目录,这样程序运行会读取该目录类的配置运行程序
                                psi.CreateNoWindow = true;
                                psi.Arguments = runargs;//执行的参数
                                System.Diagnostics.Process.Start(psi);

                            }

                        }
                        catch
                        { }
                    }

                    //


                }
                else if (e.ViewName == ViewNames.HisOrderInfo)  //医嘱信息
                {
                    if (ExtendApplicationContext.Current.PatientInformation == null)
                    {
                        Dialog.MessageBox("提示：请选中一个患者后再进行操作。");
                        return;
                    }
                    this.workSpaceControl1.ShowViewDialog(new OrderInfoPanel(), 800, 600);
                }
                else if (e.ViewName == ViewNames.AboutView)  //关于界面
                {
                    AboutForm aboutForm = new AboutForm();
                    aboutForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                    aboutForm.ShowDialog();
                }
                else if (e.ViewName == ViewNames.BloodMove)  //血液动力
                {
                    this.workSpaceControl1.ShowViewDialog(new HemodynamicsFigureOut(), 800, 620);
                }
                else if (e.ViewName == ViewNames.BloodGasData)  //血气分析
                {
                    if (ExtendApplicationContext.Current.PatientInformation == null)
                    {
                        Dialog.MessageBox("提示：请选中一个患者后再进行操作。");
                        return;
                    }
                    this.workSpaceControl1.ShowViewDialog(new BloodGasDataEditor(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID), 800, 600);
                }
                else if (e.ViewName == ViewNames.EditDict)  //字典
                {
                    this.workSpaceControl1.ShowViewDialog(new EditDict(), 800, 600);
                }
                else if (e.ViewName == ViewNames.ChangePassword)  //修改密码
                {
                    new PwdChangeFrm().ShowDialog();
                }
                else if (e.ViewName == ViewNames.OperationShift)  //手术交班
                {
                    if (ExtendApplicationContext.Current.PatientInformation == null)
                    {
                        Dialog.MessageBox("提示：请选中一个患者后再进行操作。");
                        return;
                    }
                    //this.workSpaceControl1.ShowViewDialog(new OperationShift(), 800, 600);
                    UserControl_ShiftRegister shiftRegister = new UserControl_ShiftRegister(ExtendApplicationContext.Current.PatientContext.PatientID
                        , ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID);
                    this.workSpaceControl1.ShowViewDialog(shiftRegister, shiftRegister.Width, shiftRegister.Height + 20);

                    barStaticLoginUser.Caption = "当前用户：" + ExtendApplicationContext.Current.LoginUserContext.UserName;
                }
                else if (e.ViewName == ViewNames.CommitDocManage)//归档管理
                {
                    CommitDocManage cancelCommitDoc = new CommitDocManage();
                    cancelCommitDoc.Caption = "归档管理";
                    this.workSpaceControl1.ShowViewDialog(cancelCommitDoc, cancelCommitDoc.Width, cancelCommitDoc.Height);
                }
                else if (e.ViewName == ViewNames.PunctureManager)  //穿刺管理
                {
                    this.workSpaceControl1.ShowViewDialog(new PunctureManager(), 800, 600);
                }
                else if (e.ViewName == ViewNames.InOperation)  //术中登记
                {
                    if (ExtendApplicationContext.Current.PatientInformation == null)
                    {
                        Dialog.MessageBox("提示：请选中一个患者后再进行操作。");
                        return;
                    }
                    this.workSpaceControl1.ShowViewDialog(new InOperation(ExtendApplicationContext.Current.PatientInformation, ExtendApplicationContext.Current.EventNo), (int)(Screen.PrimaryScreen.Bounds.Width * 0.9f), (int)(Screen.PrimaryScreen.Bounds.Height * 0.9f));
                    floatFrm_AddEvent(null, null);
                }
                else if (e.ViewName == ViewNames.PACUInOperation)  //复苏登记
                {
                    if (ExtendApplicationContext.Current.PatientInformation == null)
                    {
                        Dialog.MessageBox("提示：请选中一个患者后再进行操作。");
                        return;
                    }
                    this.workSpaceControl1.ShowViewDialog(new InOperation(ExtendApplicationContext.Current.PatientInformation, ExtendApplicationContext.Current.EventNo), (int)(Screen.PrimaryScreen.Bounds.Width * 0.9f), (int)(Screen.PrimaryScreen.Bounds.Height * 0.9f));
                    floatFrm_AddEvent(null, null);
                }
                else if (e.ViewName == ViewNames.LockSystem)//锁定系统
                {
                    LoginForm loginForm = new LoginForm(false);
                    loginForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                    loginForm.Tag = "LockSystem".ToUpper();

                    DialogResult dialogResult = loginForm.ShowDialog();
                    if (dialogResult != DialogResult.OK)
                    {
                        loginForm.DialogResult = DialogResult.None;
                        //isLockSystem = true;
                        //Application.Exit();
                        //loginForm.ShowDialog();
                        return;
                    }
                }
                else if (e.ViewName == ViewNames.EditTemplet)  //模板管理
                {

                    EditTemplet editTemplet = new EditTemplet();
                    editTemplet.Caption = "模板维护管理";
                    this.workSpaceControl1.ShowViewDialog(editTemplet, 800, 600);
                }
                else if (e.ViewName == ViewNames.SetMonitor)  //监护仪设置
                {
                    if (ExtendApplicationContext.Current.PatientInformation == null)
                    {
                        Dialog.MessageBox("提示：请选中一个患者后再进行操作。");
                        return;
                    }
                    SelectMonitor setMonitor = new SelectMonitor(ExtendApplicationContext.Current.PatientInformation, ExtendApplicationContext.Current.EventNo);
                    this.workSpaceControl1.ShowViewDialog(setMonitor, setMonitor.Width, setMonitor.Height);
                }
                else if (e.ViewName == ViewNames.OperationRoomPandect)  //手术概览
                {
                    OperationRoomPandect operationRoomPandect = new OperationRoomPandect();
                    operationRoomPandect.Caption = "手术概览";
                    // this.workSpaceControl1.ShowViewDialog(operationRoomPandect, 1000, 800);
                    // this.workSpaceControl1.ShowViewDialog(operationRoomPandect, (int)(Screen.PrimaryScreen.Bounds.Width * 0.9f), (int)(Screen.PrimaryScreen.Bounds.Height * 0.9f));
                    //this.workSpaceControl1.ShowViewDialog(operationRoomPandect, (int)(Screen.PrimaryScreen.Bounds.Width * 0.9f), (int)(Screen.PrimaryScreen.Bounds.Height * 1.3f));
                    this.workSpaceControl1.ShowViewDialog2(operationRoomPandect, true);
                }
                else if (e.ViewName == ViewNames.QueryStat)  //查询统计
                {
                    Process run = new Process();
                    run.StartInfo.FileName = ApplicationConfiguration.AnesQueryAddress;//
                    run.Start();

                    //WebBrowser bro = new WebBrowser();
                    //string str = ExtendApplicationContext.Current.LoginUserContext.UserID + "\r" + ExtendApplicationContext.Current.LoginUserContext.PWD;
                    //byte[] bytes = System.Text.ASCIIEncoding.Default.GetBytes(str);
                    //bro.Navigate("http://127.0.0.1/AnesQuery/checkin.aspx", "_newblank", bytes, "");
                }
                else if (e.ViewName == ViewNames.UserConfig)  //系统配置
                {
                    UserConfig userConfig = new UserConfig();
                    this.workSpaceControl1.ShowViewDialog(userConfig, userConfig.Width, userConfig.Height);
                }
                else if (e.ViewName == ViewNames.OperationInformation || e.ViewName == ViewNames.OperationRegister)  //手术信息
                {
                    if (ExtendApplicationContext.Current.PatientInformation == null)
                    {
                        Dialog.MessageBox("提示：请选中一个患者后再进行操作。");
                        return;
                    }
                    ShowFormByDocName(e.ViewName, 850, 600);
                    topBarControl1.RefreshPatientInfo(ExtendApplicationContext.Current.PatientInformation.OperRoom, ExtendApplicationContext.Current.PatientInformation.PatientID, ExtendApplicationContext.Current.PatientInformation.Name);
                    _patients.RefreshPatientDataTable(ExtendApplicationContext.Current.PatientInformation.PatientID, ExtendApplicationContext.Current.PatientInformation.VisitID, ExtendApplicationContext.Current.PatientInformation.OperID);

                    //刷新权限
                    if (ExtendApplicationContext.Current.AppType == ApplicationType.Anesthesia)
                    {
                        if (Framework.AccessControl.CheckModifyRightForOperator("麻醉单"))//有Modify权限
                        {
                            topBarControl1.SetPatientStatusContrlReadOnly(true);
                        }
                        else
                        {
                            topBarControl1.SetPatientStatusContrlReadOnly(false);
                        }
                    }
                    else if (ExtendApplicationContext.Current.AppType == ApplicationType.PACU)
                    {
                        topBarControl1.SetPatientStatusContrlReadOnly(true);
                    }
                    
                }
                //Add By xiasen.x@2014-05-28,不良事件
                else if (e.ViewName == ViewNames.BadEvent)
                {
                    if (ExtendApplicationContext.Current.PatientInformation == null)
                    {
                        Dialog.MessageBox("提示：请选中一个患者后再进行操作。");
                        return;
                    }
                    ShowFormByDocName(e.ViewName, 1000, 700);
                    topBarControl1.RefreshPatientInfo(ExtendApplicationContext.Current.PatientInformation.OperRoom, ExtendApplicationContext.Current.PatientInformation.PatientID, ExtendApplicationContext.Current.PatientInformation.Name);
                    _patients.RefreshPatientDataTable(ExtendApplicationContext.Current.PatientInformation.PatientID, ExtendApplicationContext.Current.PatientInformation.VisitID, ExtendApplicationContext.Current.PatientInformation.OperID);

                }
                else if (e.ViewName == ViewNames.PatientCodePrint)  //条码打印
                {
                    Wis.Anes.Custom.CustomProject.Views.PatientBarCodePrinter patientBarCodePrinter = new Wis.Anes.Custom.CustomProject.Views.PatientBarCodePrinter();

                    this.workSpaceControl1.ShowViewDialog(patientBarCodePrinter, patientBarCodePrinter.Width, patientBarCodePrinter.Height + 50);

                }

                else if (e.ViewName == ViewNames.RegisterAfterOperation)//术后登记
                {
                    if (ExtendApplicationContext.Current.PatientInformation == null)
                    {
                        Dialog.MessageBox("提示：请选中一个患者后再进行操作。");
                        return;
                    }
                    ShowFormByDocName(ViewNames.RegisterAfterOperation, 850, 650);
                    floatFrm_AddEvent(null, null);
                    RefreshOperationStatus();
                    topBarControl1.RefreshPatientInfo(ExtendApplicationContext.Current.PatientInformation.OperRoom, ExtendApplicationContext.Current.PatientInformation.PatientID, ExtendApplicationContext.Current.PatientInformation.Name);
                    _patients.RefreshPatientDataTable(ExtendApplicationContext.Current.PatientInformation.PatientID, ExtendApplicationContext.Current.PatientInformation.VisitID, ExtendApplicationContext.Current.PatientInformation.OperID);
                }
                //else if (e.ViewName == ViewNames.ZhenTongDengJi)//镇痛登记
                //{
                //    ShowFormByDocName(ViewNames.ZhenTongDengJi, 850, 650);
                //    floatFrm_AddEvent(null, null);
                //}
                else if (e.ViewName == ViewNames.PatientSelectedInfo)//患者详情
                {
                    if (ExtendApplicationContext.Current.PatientInformation == null)
                    {
                        Dialog.MessageBox("提示：请选中一个患者后再进行操作。");
                        return;
                    }
                    ShowFormByDocName(ViewNames.PatientSelectedInfo, 850, 650);
                }
                else if (e.ViewName == ViewNames.CancelOperation)//取消手术
                {
                    if (ExtendApplicationContext.Current.PatientInformation == null)
                    {
                        Dialog.MessageBox("提示：请选中一个患者后再进行操作。");
                        return;
                    }
                    if (ExtendApplicationContext.Current.OperationStatus >= OperationStatus.OutOperationRoom)
                    {
                        Dialog.MessageBox("该患者已完成手术，无法取消");
                        return;
                    }
                    if (Dialog.MessageBox("真的要取消患者“" + ExtendApplicationContext.Current.PatientInformation.Name + "”的手术吗？"
      , "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, 0) == DialogResult.No)
                    {
                        return;
                    }
                    object cancelReason = Dialog.SingleInputSelect("取消原因：", "");
                    if (cancelReason == null)
                    {
                        return;
                    }
                    if (ExtendApplicationContext.Current.PatientInformation != null)
                    {
                        if (ApplicationConfiguration.IsUpdateHisStatus)
                        {
                            try
                            {
                                //MessageBox.Show("回写调用");
                                string ret = SyncProxy.SyncWriteHisOperStatus(ExtendApplicationContext.Current.PatientContext.PatientID, (int)ExtendApplicationContext.Current.PatientContext.VisitID, (int)ExtendApplicationContext.Current.PatientInformation.OperID);
                                //MessageBox.Show("调用结果：" + ret);
                            }
                            catch (Exception ex)
                            {
                                ExceptionHandler.Handle(ex);
                            }
                        }
                        ExtendApplicationContext.Current.SystemStatus = ProgramStatus.NoPatient;
                        leftBarControl1.SetCurrentViewNavigateButtons();
                        topBarControl1.CancelOrCommitOperation(OperationStatus.CancelOperation, cancelReason.ToString());
                        SystemHelper.InformationChanged(null);
                        topBarControl1.RefreshPatientInfo("", "", "");
                        ReturnPatientList();
                        _patients.RefreshPatientDataTable();
                    }
                }

                else if (e.ViewName == ViewNames.SyncHis)//HIS同步
                {
                    if (ExtendApplicationContext.Current.CustomSettingContext.IsSyncScheduleInfo)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        try
                        {
                            string ret;
                            if (ApplicationConfiguration.SyncScheduleInfoMode == 0)
                            {
                                ret = SyncProxy.SyncScheduleInfoByDeptCode(ApplicationConfiguration.OpertionDeptCode);
                            }
                            else
                            {
                                ret = SyncProxy.SyncScheduleInfo("");
                            }


                            if (!string.IsNullOrEmpty(ret))
                            {
                                ExceptionHandler.Handle(new Exception("同步手术申请信息失败\r\n" + ret));
                                ret = SyncProxy.SyncPatientInfoAndInHospital("");// syncInterface.SyncPatientInfoAndInHospital("");
                            }
                            if (string.IsNullOrEmpty(ret))
                            {
                                Dialog.MessageBox(e.ViewName + "成功");
                            }

                        }
                        catch (Exception ex)
                        {
                            ExceptionHandler.Handle(ex);

                        }
                        this.Cursor = Cursors.Default;
                    }

                }
                else if (e.ViewName == ViewNames.LockPatient)//病案提交
                {
                    if (ExtendApplicationContext.Current.PatientInformation == null)
                    {
                        Dialog.MessageBox("提示：请选中一个患者后再进行操作。");
                        return;
                    }
                    if (ExtendApplicationContext.Current.OperationStatus < OperationStatus.OutOperationRoom)
                    {
                        Dialog.MessageBox("该患者手术未完成或未离开手术间，无法归档。");
                        return;
                    }

                    if (ExtendApplicationContext.Current.OperationStatus.Equals(OperationStatus.Done))
                    {
                        Dialog.MessageBox("该患者病案资料已提交");
                        return;
                    }
                    if (Dialog.MessageBox("真的要将患者“" + ExtendApplicationContext.Current.PatientInformation.Name + "”麻醉资料提交吗？\r\n提交后患者资料将不能再进行任何形式的更改!"
                        , "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, 0) == DialogResult.No)
                    {
                        return;
                    }

                    topBarControl1.CancelOrCommitOperation(OperationStatus.Done, "");
                    leftBarControl1.SetLockPatBtn();
                }
                else if (e.ViewName == ViewNames.PacuBed)//复苏床位
                {

                    OperationRoomPandect operationRoomPandect = new OperationRoomPandect(1, false);
                    operationRoomPandect.PatientSelected += new EventHandler(patients_SelectChanged);

               
                    #region <<原来的代码>>

                    //this.workSpaceControl1.ShowViewDialog(operationRoomPandect, 800, 600);

                    #endregion

                    this.workSpaceControl1.ShowViewDialog(operationRoomPandect, 880, 600);


                }
                else if (e.ViewName == ViewNames.AnesthesiaFee)//麻醉收费
                {

                    if (ExtendApplicationContext.Current.PatientInformation == null)
                    {
                        Dialog.MessageBox("提示：请选中一个患者后再进行操作。");
                        return;
                    }
                    this.workSpaceControl1.ShowViewDialog(new UserControl_AnesthesiaBill(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientInformation.Name,
                        ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientInformation.OperID), 1000, 700);


                }
                else if (e.ViewName == ViewNames.OperationFee) // 手术收费
                {
                    if (ExtendApplicationContext.Current.PatientInformation == null)
                    {
                        Dialog.MessageBox("提示：请选中一个患者后再进行操作。");
                        return;
                    }
                    this.workSpaceControl1.ShowViewDialog(new UserControl_OperationBill(/*"263625", "test", 1, 1), 750, 700); //*/ ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientInformation.Name,
                        ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientInformation.OperID), 750, 700);


                }
                else if (e.ViewName == ViewNames.DocQualityControl)//文书质控
                {

                    OperationDocQualityControl operationDocQualityControl = new OperationDocQualityControl();
                    operationDocQualityControl.Caption = "文书质控";
                    this.workSpaceControl1.ShowViewDialog(operationDocQualityControl, 1100, 600);
                    // this.workSpaceControl1.ShowViewDialog(operationRoomPandect, (int)(Screen.PrimaryScreen.Bounds.Width * 0.9f), (int)(Screen.PrimaryScreen.Bounds.Height * 0.9f));
                    //this.workSpaceControl1.ShowViewDialog(operationRoomPandect, (int)(Screen.PrimaryScreen.Bounds.Width * 0.9f), (int)(Screen.PrimaryScreen.Bounds.Height * 1.3f));


                }
                else if (e.ViewName == ViewNames.PACUProgress) // 复苏进程
                {

                    PACUProcess process = new PACUProcess(new OperationRoomPandect(1));
                    process.PatientSelected += new EventHandler(patients_SelectChanged);
                    this.workSpaceControl1.ShowViewDialog(process, true);
                }
                else if (e.ViewName == ViewNames.AnesthesiaScore)// 麻醉评分
                {
                    if (ExtendApplicationContext.Current.PatientInformation == null)
                    {
                        Dialog.MessageBox("提示：请选中一个患者后再进行操作。");
                        return;
                    }
                    AnesScore anesScore = new AnesScore(ExtendApplicationContext.Current.PatientInformation.PatientID,
                        ExtendApplicationContext.Current.PatientInformation.VisitID, 1);

                    DialogHostForm dialogHostForm = new DialogHostForm("麻醉评分", 1024, 600);
                    dialogHostForm.Child = anesScore;
                    dialogHostForm.ShowDialog();

                    //                AnesScoreMain anesScore = new AnesScoreMain(ExtendApplicationContext.Current.PatientInformation.PatientID,
                    //ExtendApplicationContext.Current.PatientInformation.VisitID, 1);
                    //                DialogHostForm dialogHostForm = new DialogHostForm("麻醉评分", 1280, 768);
                    //                dialogHostForm.Child = anesScore;
                    //                dialogHostForm.ShowDialog();

                }
                else if (e.ViewName == ViewNames.ThreeReviewSpecifications)//三甲指标
                {

                    ThreeReviewSpecifications threeReviewSpecifications = new ThreeReviewSpecifications();
                    threeReviewSpecifications.Caption = "麻醉质控";
                    this.workSpaceControl1.ShowViewDialog(threeReviewSpecifications, 860, 600);

                }
                else if (e.ViewName == ViewNames.InformFMembers)//InformFMembers
                {
                    if (ExtendApplicationContext.Current.PatientInformation == null)
                    {
                        Dialog.MessageBox("提示：请选中一个患者后再进行操作。");
                        return;
                    }
                    ScreenInfoNotice screenInfoNotice = new ScreenInfoNotice();
                    DialogHostForm dialogHostForm = new DialogHostForm("家属公告信息", 800, 500);
                    dialogHostForm.Child = screenInfoNotice;
                    dialogHostForm.ShowDialog();

                    //                    Wis.Anes.Views.Information.PatientCustom screenInfoNotice = new  Wis.Anes.Views.Information.PatientCustom();
                    //DialogHostForm dialogHostForm = new DialogHostForm("术前病例讨论记录", 800,500);
                    //dialogHostForm.Child = screenInfoNotice;
                    //dialogHostForm.ShowDialog();


                }
                else if (e.ViewName == ViewNames.OperationNotification)//手术提醒
                {
                    if (ExtendApplicationContext.Current.PatientInformation == null)
                    {
                        Dialog.MessageBox("提示：请选中一个患者后再进行操作。");
                        return;
                    }
                    OperationNotice operationNotification = new OperationNotice();
                    DialogHostForm dialogHostForm = new DialogHostForm("手术提醒信息", 800, 500);
                    dialogHostForm.Child = operationNotification;
                    dialogHostForm.ShowDialog();
                }
                else if (e.ViewName == ViewNames.AnesPath) // 麻醉路径
                {
                    AnesPath anesPath = new AnesPath();
                    DialogHostForm dialogHostForm = new DialogHostForm("麻醉路径", 800, 600);
                    dialogHostForm.Child = anesPath;
                    dialogHostForm.ShowDialog();
                }
                else if (e.ViewName == ViewNames.OperationScaleConfig)//手术等级配置
                {

                    OperationScaleConfig operationScaleConfig = new OperationScaleConfig();
                    operationScaleConfig.Caption = "手术等级配置";
                    this.workSpaceControl1.ShowViewDialog(operationScaleConfig, 860, 600);

                }
                else if (e.ViewName == ViewNames.PacuRoomStatus) //复苏状态
                {
                    this.workSpaceControl1.ShowViewDialog(new PacuRoomStatus(), true);
                }
                else if (e.ViewName == ViewNames.PatientAlarm)//患者预警
                {

                    PatientAlarm patientAlarm = new PatientAlarm();
                    patientAlarm.Caption = "患者预警提示";

                    DialogHostForm dialogHostForm = new DialogHostForm(patientAlarm.Caption, patientAlarm.Width, patientAlarm.Height + 30);
                    dialogHostForm.StartPosition = FormStartPosition.Manual;
                    dialogHostForm.Child = patientAlarm;
                    dialogHostForm.Left = Screen.PrimaryScreen.Bounds.Width - dialogHostForm.Width - 20;
                    dialogHostForm.Top = Screen.PrimaryScreen.Bounds.Height - dialogHostForm.Height - 40;
                    dialogHostForm.TopMost = true;
                    dialogHostForm.ShowDialog();


                }
                //End Add
                //else if (e.ViewName == ViewNames.SyncHisFee) // 价表同步
                //{

                //}
                //else if (e.ViewName == ViewNames.OperationProgress)//手术进程
                //{
                //    this.workSpaceControl1.ShowViewDialog(new UserControl_OperationProgress(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientInformation.OperID), 800, 600);
                //}
                else if (e.ViewName == ViewNames.OperationProgress)//手术进程
                {
                    this.workSpaceControl1.ShowViewDialog(new OperationProcess(), true);
                    //this.workSpaceControl1.ShowViewDialog(new UserControl_OperationProgress(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientInformation.OperID), 800, 600);
                }
                else if (e.ViewName == ViewNames.AnesEditEquipment) //器材维护UserControl_EquipmentEdit
                {
                    UserControl_EquipmentEdit equipmentEdit = new UserControl_EquipmentEdit(0);
                    equipmentEdit.Caption = "麻醉器材维护";
                    this.workSpaceControl1.ShowViewDialog(equipmentEdit, equipmentEdit.Width, equipmentEdit.Height);

                }
                else if (e.ViewName == ViewNames.OperEditEquipment) //器材维护UserControl_EquipmentEdit
                {
                    UserControl_EquipmentEdit equipmentEdit = new UserControl_EquipmentEdit(1);
                    equipmentEdit.Caption = "手术器材维护";
                    this.workSpaceControl1.ShowViewDialog(equipmentEdit, equipmentEdit.Width, equipmentEdit.Height);

                }
                else if (e.ViewName == ViewNames.InstrumentsCheck)//器械管理
                {
                    Wis.Anes.Custom.CustomProject.Views.InstrumentsCheck instrumentsCheck = new Wis.Anes.Custom.CustomProject.Views.InstrumentsCheck();
                    instrumentsCheck.Caption = "器械管理";
                    this.workSpaceControl1.ShowViewDialog(instrumentsCheck, 860, 600);

                }
            }
        }

        public void ShowFormByDocName(string docName, int width, int height)
        {
            ApplicationConfiguration.MedicalDocucementElement document = ApplicationConfiguration.GetMedicalDocument(docName);
            //没有找到退出
            if (string.IsNullOrEmpty(document.Caption))
            {
                return;
            }


            try
            {
                Type t = Type.GetType(document.Type);
                BaseDoc baseDoc = Activator.CreateInstance(t) as BaseDoc;
                //baseDoc.BackColor = Color.White;
                baseDoc.LoadReport(ExtendApplicationContext.Current.AppPath + document.Path);
                //baseDoc.Dock = DockStyle.Fill;
                DialogHostForm dialogHostForm = new DialogHostForm(docName, width, height);
                dialogHostForm.Child = baseDoc;


                if (Framework.AccessControl.CheckModifyRightForOperator(docName))//有Modify权限
                    baseDoc.SetAllControlEditable(true);
                else
                {
                    baseDoc.SetAllButtonsEnable(false);
                    baseDoc.SetAllControlEditable(false);
                }
                if (baseDoc.AllowSingleDocModify())
                    baseDoc.SetAllControlEditable(true);

                dialogHostForm.ShowDialog();

            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }

        }


        private bool ShowCustomForm(string viewName)
        {
            Dictionary<string, MedicalDocElement> views = MedicalDocSettings.GetCustomForms();

            KeyValuePair<string, MedicalDocElement> keyValuePairView = new KeyValuePair<string, MedicalDocElement>();

            foreach (KeyValuePair<string, MedicalDocElement> keyValuePair in views)
            {
                if (keyValuePair.Key.Trim() == viewName.Trim())
                {
                    keyValuePairView = keyValuePair;
                    break;
                }
            }

            //没有找到退出
            if (string.IsNullOrEmpty(keyValuePairView.Key))
            {
                return false;
            }
            try
            {
                Type t = Type.GetType(keyValuePairView.Value.Type);
                BaseView view = Activator.CreateInstance(t) as BaseView;
                this.workSpaceControl1.ShowViewDialog(view, view.Width, view.Height);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
                return false;
            }
        }

        private void floatFrm_AddEvent(object sender, EventArgs e)
        {
            Control control = GetCurrentControl();
            if (control != null && control is BaseDoc)
            {
                BaseDoc doc = control as BaseDoc;
                doc.RefreshData();
            }
        }
        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var current = GetCurrentControl();
            if (current is BaseDoc)
            {
                BaseDoc doc = current as BaseDoc;
                if (doc.HasDirty())
                {
                    DialogResult dialogResult = XtraMessageBox.Show("您当前的界面有未保存的数据,是否保存数据并退出系统?",
                        "提示信息", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (!doc.ValidateData())
                            return;
                        else
                        {
                            if (!doc.OnCustomCheckBeforeSave()) return;
                            doc.Save();
                        }

                    }
                    else if (dialogResult == DialogResult.Cancel)
                    {

                        e.Cancel = true;



                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //e.Cancel = true;

                    }

                }
                else
                {
                    if (XtraMessageBox.Show("是否退出系统?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {

                        e.Cancel = true;


                    }
                    //Add by wenpei.x@2014-02-11
                    //新增日志处理，记录验证是否为e.Cancel = true;造成的程序无法关闭
                    else
                    {
                        if (e.Cancel) ExceptionHandler.Handle((new Exception("关闭程序时发现e.Cancel = true;")), false);
                        e.Cancel = false;
                    }
                }
            }
            else
            {
                if (XtraMessageBox.Show("是否退出系统?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {


                    e.Cancel = true;



                }
                //Add by wenpei.x@2014-02-11
                //新增日志处理，记录验证是否为e.Cancel = true;造成的程序无法关闭
                else
                {
                    if (e.Cancel) ExceptionHandler.Handle((new Exception("关闭程序时发现e.Cancel = true;")), false);
                    e.Cancel = false;
                }
            }

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Logger.Write("系统运行了：" + ExtendApplicationContext.Current.SystemRunClockTick + " 秒");
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {

        }






        protected void RefreshStatus(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ExtendApplicationContext.Current.PatientContext.PatientID))
            {
                AnesInformations.OperationMasterDataTable dtMaster = ServiceProxies.AnesthesiaSheetProxy.GetOperationMaster(ExtendApplicationContext.Current.PatientContext.PatientID,
                        ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID);

                if (dtMaster.Rows.Count > 0)
                {
                    ExtendApplicationContext.Current.PatientInformation.OperRoom = dtMaster[0].OPERATING_ROOM_NO;
                    ExtendApplicationContext.Current.PatientInformation.OperStatus = dtMaster[0].OPER_STATUS;

                    patients_SelectChanged(sender, e);
                }
            }

        }

        private void timerResponse_Tick(object sender, EventArgs e)
        {
            string sql = string.Format(@"SELECT ID,MESSAGE,INSERT_TIME FROM WIS_ANES_COMMUNICT_PLATFORM WHERE PAT_ID ='{0}' AND VISIT_ID = {1} AND OPER_ID = {2} AND STATE = 2 ORDER BY INSERT_TIME DESC ",
                ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID);
            DataTable dt = CommonProxy.GetDataFromSQLString(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    new PatientInformationsDA().UpdateCommunicateState(3, dr["ID"].ToString());
                    if (MessageBox.Show("消息【" + dr["MESSAGE"].ToString() + "】临床已收到。") == DialogResult.OK)
                    {
                        new PatientInformationsDA().UpdateCommunicateState(4, dr["ID"].ToString());
                    }
                }
            }
        }

    }
}



