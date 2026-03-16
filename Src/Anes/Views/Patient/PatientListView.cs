using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Views;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework;
using Wis.Anes.Framework.Utilities;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.ServiceProxies;
using Wis.Anes.Framework.Controls.Base;

using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ViewInfo;

using Wis.Anes.Layouts;
//using Wis.Anes.Framework.Views;


namespace Wis.Anes.Views.Patient
{
    public partial class PatientListView : BaseView
    {
        protected int _normalCount = 20;
        public PatientListView()
        {
            InitializeComponent();
            Init();
        }

         #region  变量
        private DataTable _operationsInfoDataTable;
        public DataTable OperationsInfoDataTable
        {
            get
            {
                return _operationsInfoDataTable;
            }
        }
        /// <summary>
        /// 可选患者列表
        /// </summary>
        private List<PatientContentViewNew> _patients = new List<PatientContentViewNew>();
        /// <summary>
        /// 字典清单
        /// </summary>
        private Dict.AnessthestaDictDataTable _anesMethod;
        private Dict.HisUserDataTable _doctorTable;
        private Dict.HisUserDataTable _nurseTable;
        private Dict.WisDiagnosisDictDataTable _diagnosisDictTable;
        private Dict.OperationDictDataTable _optionDictTable;
        private Dict.AnesthesiaInputDictDataTable _commonDictTable;
        private Dict.DeptDictDataTable _deptDict;
        private Dict.OperatingRoomDataTable _OperatingRoom;
        #endregion 变量
        #region 事件接口
        private static readonly object _patientDoubleClick = new object();
        public event EventHandler PatientDoubleClick
        {
            add
            {
                Events.AddHandler(_patientDoubleClick, value);
            }
            remove
            {
                Events.RemoveHandler(_patientDoubleClick, value);
            }
        }

        private static readonly object _selectChanged = new object();
        public event EventHandler SelectChanged
        {
            add
            {
                Events.AddHandler(_selectChanged, value);
            }
            remove
            {
                Events.RemoveHandler(_selectChanged, value);
            }
        }

        private static readonly object _patientClick = new object();
        public event EventHandler PatientClick
        {
            add
            {
                Events.AddHandler(_patientClick, value);
            }
            remove
            {
                Events.RemoveHandler(_patientClick, value);
            }
        }
        #endregion 事件接口
        #region 属性接口
        private Image _docImage = null;
        public Image DocumentImage
        {
            get
            {
                return _docImage;
            }
            set
            {
                _docImage = value;
            }
        }

        private Color _borderColor = Color.FromArgb(0, 24, 120);
        public Color BorderColor
        {
            get
            {
                return _borderColor;
            }
            set
            {
                _borderColor = value;
            }
        }

        private Image _panelBackGroundImage = null;
        public Image PanelBackGroundImage
        {
            get
            {
                return _panelBackGroundImage;
            }
            set
            {
                _panelBackGroundImage = value;
            }
        }

        private Image _normalRoomImage = null;
        public Image NormalRoomImage
        {
            get
            {
                return _normalRoomImage;
            }
            set
            {
                _normalRoomImage = value;
            }
        }

        private Image _selectRoomImage = null;
        public Image SelectRoomImage
        {
            get
            {
                return _selectRoomImage;
            }
            set
            {
                _selectRoomImage = value;
            }
        }

        private Image _mouseEnterRoomImage = null;
        public Image MouseEnterRoomImage
        {
            get
            {
                return _mouseEnterRoomImage;
            }
            set
            {
                _mouseEnterRoomImage = value;
            }
        }

        private Image _panelLeftImage = null;
        public Image PanelLeftImage
        {
            get
            {
                return _panelLeftImage;
            }
            set
            {
                _panelLeftImage = value;
            }
        }

        private Image _panelRightImage = null;
        public Image PanelRightImage
        {
            get
            {
                return _panelRightImage;
            }
            set
            {
                _panelRightImage = value;
            }
        }

        private Image _patImage = null;
        public Image PatientImage
        {
            get
            {
                return _patImage;
            }
            set
            {
                _patImage = value;
            }
        }

        public int SelectedIndex
        {
            get
            {
                if (_selectedPatient != null)
                {
                    return _patients.IndexOf(_selectedPatient);
                }
                else
                {
                    return -1;
                }
            }
        }

        private PatientContentViewNew _selectedPatient = null;
        public PatientContentViewNew SelectedPatient
        {
            get
            {
                return _selectedPatient;
            }
        }

        private PatientContentViewNew _showPatient = null;
        public PatientContentViewNew ShowPatient
        {
            get
            {
                return _showPatient;
            }
        }
        private decimal _operStatus = 99;
        public OperationStatus OperationStatus
        {
            get
            {
                return GetOperationStatus(_operStatus);
            }
            set
            {
                _operStatus = (decimal)(int)value;
                FilterData();
            }
        }

        private Color _contentBackColor = Color.FromArgb(142, 193, 238);
        private Color ContentBackColor
        {
            get
            {
                return _contentBackColor;
            }
            set
            {
                //_contentBackColor = value;
                //pnlSearch.BackColor = value;
                //pnlBody.BackColor = value;
                //pnlBody1.BackColor = value;
            }
        }


        private Image _flagGeliImage = null;
        public Image FlagGeliImage
        {
            get
            {
                return _flagGeliImage;
            }
            set
            {
                _flagGeliImage = value;
            }
        }
        private Image _flagFangSheImage = null;
        public Image FlagFangSheImage
        {
            get
            {
                return _flagFangSheImage;
            }
            set
            {
                _flagFangSheImage = value;
            }
        }

        private Image _flagEmgerencyImage = null;
        public Image FlagEmgerencyImage
        {
            get
            {
                return _flagEmgerencyImage;
            }
            set
            {
                _flagEmgerencyImage = value;
            }
        }
        
        #endregion 属性
        #region 方法
        /// <summary>
        /// 构造方法
        /// </summary>
       

        //public PatientList(Color backColor,Color contentBackColor, Image normalRoomImage, Image selectRoomImage, Image mouseEnterRoomImage)
        //{
        //    InitializeComponent();
        //    ContentBackColor = contentBackColor;
        //    BackColor = backColor;
        //    panel2.BackColor = backColor;
        //    panel4.BackColor = backColor;
        //    _normalRoomImage = normalRoomImage;
        //    _selectRoomImage = selectRoomImage;
        //    _mouseEnterRoomImage = mouseEnterRoomImage;
        //    Init();
        //}

        private void Init()
        {
            ///初始化字典
            if (!DesignMode)
            {
                // _doctorTable = DataHelper.GetHisUsers("医生");
                // _nurseTable = DataHelper.GetHisUsers("护士");

                if (ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_PERM_HIS_USER"))
                {
                    _doctorTable = ExtendApplicationContext.Current.CodeTables["WIS_PERM_HIS_USER"] as Dict.HisUserDataTable;
                    _nurseTable = ExtendApplicationContext.Current.CodeTables["WIS_PERM_HIS_USER"] as Dict.HisUserDataTable;
                }
                else
                {
                    _doctorTable = DictProxy.GetHisUsers();
                    _nurseTable = DictProxy.GetHisUsers();
                }
                if (ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_DICT_ANES"))
                {
                    _anesMethod = ExtendApplicationContext.Current.CodeTables["WIS_DICT_ANES"] as Dict.AnessthestaDictDataTable;
                }
                else
                {
                    _anesMethod = DictProxy.GetAnesDict();
                }
                if (ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_DICT_DIAGNOSIS"))
                {
                    _diagnosisDictTable = ExtendApplicationContext.Current.CodeTables["WIS_DICT_DIAGNOSIS"] as Dict.WisDiagnosisDictDataTable;
                }
                else
                {
                    _diagnosisDictTable = DictProxy.GetDiagnosisDict();
                }
                if (ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_DICT_OPERATION"))
                {
                    _optionDictTable = ExtendApplicationContext.Current.CodeTables["WIS_DICT_OPERATION"] as Dict.OperationDictDataTable;
                }
                else
                {
                    _optionDictTable = DictProxy.GetOperationDict();
                }
                if (ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_DICT_ANES_INPUT"))
                {
                    _commonDictTable = ExtendApplicationContext.Current.CodeTables["WIS_DICT_ANES_INPUT"] as Dict.AnesthesiaInputDictDataTable;
                }
                else
                {
                    _commonDictTable = DictProxy.GetAnesthesiaInputDict();
                }
                if (ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_DICT_DEPT"))
                {
                    _deptDict = ExtendApplicationContext.Current.CodeTables["WIS_DICT_DEPT"] as Dict.DeptDictDataTable;
                }
                else
                {
                    _deptDict = DictProxy.GetDeptDict();
                }
                if (ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_OPER_ROOM"))
                {
                    _OperatingRoom = ExtendApplicationContext.Current.CodeTables["WIS_OPER_ROOM"] as Dict.OperatingRoomDataTable;
                }
                else
                {
                    _OperatingRoom = DictProxy.GetOperatingRoomDict();
                }

            dateTimePickerQuery.DateTime =   DateTime.Today; //;
            txtRoomNo.Text = ApplicationConfiguration.OpertionRoom;
                //if (Globals.AppType == ApplicationType.OperationSchedule)
                //{
                //    txtStatus.Text = NewOperationStatus.OperationStatusToString(NewOperationStatus.OperationStatus.IsReady);
                //}





                /////初始化字典
                //if (!DesignMode)
                //{
                //    if ((MainNavHelper.CheckRight("急诊") & MainNavHelper.RightType.Modify) != MainNavHelper.RightType.Modify)
                //    {
                //        btnJiZhen.Visible = false;
                //    }
                //}
                AnesDoctorInIt();

                while (_patients.Count < _normalCount)
            {
                PatientContentViewNew patient = new PatientContentViewNew();
                //_patients.Insert(0,patient);
                _patients.Add(patient);

                //patient.BackColor = _contentBackColor;
                //patient.Visible = false;
                flowLayoutPanel1.Controls.Add(patient);

                patient.Clicked += new EventHandler(patient_Click);
                patient.DoubleClicked += new EventHandler(patient_DoubleClick);
                patient.Dock = DockStyle.Top;
                patient.BringToFront();
            }



            }
           
        }

        private void AnesDoctorInIt()
        {
            var DeptID = ExtendApplicationContext.Current.LoginUserContext.DeptID;
            string loginUser = ExtendApplicationContext.Current.LoginUserContext.LoginName;
            if (loginUser.ToUpper() == "ADMIN" || loginUser.ToUpper() == "MZK" || loginUser.ToUpper() == "ZZS")
            {
                txtAnesDoctor.DataSource = _doctorTable;
                txtAnesDoctor.ValueMember = "USER_NAME";
                txtAnesDoctor.DisplayMember = "USER_NAME";
            }
            else
            {
                txtAnesDoctor.DataSource = DictProxy.GetHisUsersDept(DeptID);
                txtAnesDoctor.ValueMember = "USER_NAME";
                txtAnesDoctor.DisplayMember = "USER_NAME";
            }
            txtAnesDoctor.SelectedIndex = -1;
        }
        /// <summary>
        /// 初始化 并设为第一页
        /// </summary>
        private void InitPatientDataTableAndPageIndex()
        {
            _pageIndex = 0;
            RefreshPatientDataTable();

            
            if (cmbPages.SelectedIndex != 0)
            { 
           //设为第一页
                cmbPages.SelectedIndexChanged -= new System.EventHandler(this.cmbPages_SelectedIndexChanged);
                cmbPages.SelectedIndex = 0;
                cmbPages.SelectedIndexChanged += new System.EventHandler(this.cmbPages_SelectedIndexChanged);
            }

        }


        private void pnlBody_Resize(object sender, EventArgs e)
        {


            int countTemp = _patientCount;
            _patientCount = GetPatientContentCountForOnePage(_isMin);
            if (countTemp != _patientCount)
                RefreshPatientDataTable();


        }

        /// <summary>
        /// 计算每页显示多少个信息
        /// </summary>
        /// <param name="isMin">是否最小化</param>
        /// <returns>返回每页显示多少个信息</returns>
        private int GetPatientContentCountForOnePage(bool isMin )
        {
            if (!string.IsNullOrEmpty(textEditPerPageCount.Text))
            {
                int count = 20;
                int.TryParse(textEditPerPageCount.Value.ToString(), out count);
                return count;
            }
            else
            {
                int res = 4;
                PatientContentViewNew patient = new PatientContentViewNew();
                //if (!isMin)
                //    patient.SetMaxHeight();
                //else
                //    patient.SetMinHeight();

                int remainHeight = flowLayoutPanel1.Height;

                res = (int)Math.Floor((double)remainHeight / (patient.Height + 8));
                patient.Dispose();
                patient = null;

                return res;
            }
        
        }
        /// <summary>
        /// 增加患者详细信息界面接口
        /// </summary>
        /// <param name="control"></param>
        public void AddControl(Control control)
        {
            pnlBodyRight.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pnlBodyRight.Controls.Add(control);
        }

        public void SetDetail(Control control)
        {
            if (pnlBodyRight.Controls.Count == 0 && control != null)
            {
                pnlBodyRight.Controls.Add(control);
            }
        }

        /// <summary>
        /// 重新获取数据
        /// </summary>
        public void RefreshPatientDataTable()
        {

            this.Visible = false;
            RefreshPatientDataTable("");
            this.Visible = true;
        }

        /// <summary>
        /// 重新更新指定患者信息
        /// </summary>
        public void RefreshPatientDataTable(string patientID, decimal visitID, decimal operID)
        {
            if (_operationsInfoDataTable != null)
            {


                //string patientID = patientInformation.PatientID ;
                // decimal visitID=patientInformation.VisitID ;
                //decimal operID =patientInformation.OperID ;

                DataTable dt = PatientInformationsProxy.GetPatientListDataTable(patientID, visitID, operID);
                DataRow[] rows=   dt.Select("PAT_ID = '" + patientID + "' AND VISIT_ID = '" + visitID + "' AND  OPER_ID = '" + operID + "'");
                

                DataRow[]  operationsInfoDataRows =  _operationsInfoDataTable.Select("PAT_ID = '" + patientID + "' AND VISIT_ID = '" + visitID + "' AND OPER_ID = '" + operID + "'");
                if (operationsInfoDataRows != null && operationsInfoDataRows.Length >= 1 && rows != null && rows.Length >=1)
                {
                    for (int i = 0; i < operationsInfoDataRows[0].ItemArray.GetLength(0); i++)
                    {
                        operationsInfoDataRows[0][i] = rows[0][i];
                    }
                    PatientInformation patientInformation = new PatientInformation(operationsInfoDataRows[0]);
                    //刷新_patients里的内容

                    if (_patients != null && _patients.Count > 0)
                    {
                        foreach (PatientContentViewNew patientSearch in _patients)
                        {
                            if (patientSearch.PatientInformation.PatientID == patientID && patientSearch.PatientInformation.VisitID == visitID && patientSearch.PatientInformation.OperID == operID)
                            {
                                patientSearch.PatientInformation = patientInformation;
                                patientSearch.InitalizeUI();
                                patientSearch.Refresh();
                                if (this.patientSelectedDetail != null )
                                    this.patientSelectedDetail.RefreshSelectedPatient(patientSearch.PatientInformation);
                                break;
                            }
                        }
 

                    }
                }
            }

        }

        /// <summary>
        /// 刷新选定的患者
        /// </summary>
        public void RefreshSelectedPatient(PatientContentViewNew patient)
        {
            this.patientSelectedDetail.RefreshSelectedPatient(patient.PatientInformation);
        }


        public static OperationStatus GetOperationStatus(decimal operStatus)
        {
            try
            {
                return (OperationStatus)(int)operStatus;
            }
            catch
            {
                return OperationStatus.None;
            }
        }

        /// <summary>
        /// 筛选并刷新列表
        /// </summary>
        private void FilterData()
        {
            FilterData(null);
        }

        protected void SetFilter()
        {
            string filter = "";
            //Modify By chengying.x @20140213 麻醉和复苏使用不同的radio控件，且使用不同的过滤条件
            if (ExtendApplicationContext.Current.AppType == ApplicationType.PACU)
            {
                switch (radioStatusPACU.SelectedIndex)
                {
                    case 0:
                        filter = "OPER_STATUS >= 35 AND IN_PACU_DATE_TIME IS NOT NULL ";
                        break;
                    case 1:
                        filter = "OPER_STATUS >= 40 and OPER_STATUS < 45 ";
                        break;
                    case 2:
                        filter = "OPER_STATUS >= 45 and OPER_STATUS < 55 AND IN_PACU_DATE_TIME IS NOT NULL"; 
                        break;
                    case 3:
                        filter = "OPER_STATUS >= 55 AND IN_PACU_DATE_TIME IS NOT NULL";
                        break;
                }
            }
            else
            {
                switch (radioStatus.SelectedIndex)
                {
                    case 0:
                        break;
                    case 1:
                        filter = "OPER_STATUS = 0";
                        break;
                    case 2:
                        filter = "OPER_STATUS >= 3 and OPER_STATUS < 35"; //入诱导室=3
                        break;
                    case 3:
                        filter = "OPER_STATUS >= 35";
                        break;
                }
            }
            //End Modify


            if (comboBoxOperRoom.SelectedIndex != -1)
            {
                string curfilter = string.Format("OPERATING_ROOM_NO = '{0}'", comboBoxOperRoom.Text);
                filter += (string.IsNullOrEmpty(filter) ? curfilter : " and " + curfilter + "");
            }


            string filterEng = "", filterPerson = "", filterGeLi = "", filterFangShe = "";

            if (checkEditPersonal.Checked)
            {
                //Modify by wenpei.x@2014-03-04
                //调整患者列表过滤条件为and
                //filterPerson = string.Format("anesthesia_doctor = '{0}' or anesthesia_assistant = '{0}' or second_anesthesia_assistant = '{0}'", ExtendApplicationContext.Current.LoginUserContext.HisUserID);
                //filter += (string.IsNullOrEmpty(filter) ? filterPerson : " and " + filterPerson + "");
                filterPerson = string.Format("(anes_doctor = '{0}' or anes_assistant = '{0}' or second_anes_assistant = '{0}' or anes_doctor = '{1}' or anes_assistant = '{1}' or second_anes_assistant = '{1}')"
                , new object[] { ExtendApplicationContext.Current.LoginUserContext.HisUserID, ExtendApplicationContext.Current.LoginUserContext.UserName });
                filter += (string.IsNullOrEmpty(filter) ? filterPerson : " and " + filterPerson + "");
            }

            if(chkEngency.Checked)
                filterEng = "emergency_indicator = 1";

               if (checkEditGeli.Checked)
                filterGeLi = "ISOLATION_INDICATOR = 2";

            if (checkEditFangshe.Checked)
                filterFangShe = "ISOLATION_INDICATOR = 3";

           

            if (!string.IsNullOrEmpty(filterEng)  || !string.IsNullOrEmpty(filterGeLi) || !string.IsNullOrEmpty(filterFangShe))
            {
                string curfilter = "";

                if (!string.IsNullOrEmpty(filterEng))
                    curfilter += filterEng;
                //Modify by wenpei.x@2014-03-04
                //调整患者列表过滤条件为and
                //if (!string.IsNullOrEmpty(filterPerson))
                //    curfilter += (string.IsNullOrEmpty(curfilter) ? filterPerson : " or " + filterPerson);

                //if (!string.IsNullOrEmpty(filterGeLi))
                //    curfilter += (string.IsNullOrEmpty(curfilter) ? filterGeLi : " or " + filterGeLi);

                //if (!string.IsNullOrEmpty(filterFangShe))
                //    curfilter += (string.IsNullOrEmpty(curfilter) ? filterFangShe : " or " + filterFangShe);
                if (!string.IsNullOrEmpty(filterGeLi))
                    curfilter += (string.IsNullOrEmpty(curfilter) ? filterGeLi : " and " + filterGeLi);

                if (!string.IsNullOrEmpty(filterFangShe))
                    curfilter += (string.IsNullOrEmpty(curfilter) ? filterFangShe : " and " + filterFangShe);
                filter += (string.IsNullOrEmpty(filter) ? curfilter : " and (" + curfilter + ")");
            }

          
            _operationsInfoDataTable.DefaultView.RowFilter = filter;


            switch (radioGroupSortOrder.SelectedIndex)
            {
                case 0:
                    _operationsInfoDataTable.DefaultView.Sort = "OPERATING_ROOM_NO, SEQUENCE";
                    break;
                case 1:
                    _operationsInfoDataTable.DefaultView.Sort = "START_DATE_TIME, OPERATING_ROOM_NO";
                    break;
            }

        }

        private int _patientCount = 4 ;

        private void FilterData(string patientID)
        {

            if (_operationsInfoDataTable == null)
                return;


            SetFilter();
            _patientCount = GetPatientContentCountForOnePage(_isMin);
            if (_patientCount < 0)
                _patientCount = 0;
           
            //Visible = false;
            cmbPages.Properties.Items.Clear();
            int pageCount = 1;
            if (_patientCount != 0)
            {
                pageCount = (int)_operationsInfoDataTable.DefaultView.Count / _patientCount;
            }
            else
            {
                pageCount = (int)_operationsInfoDataTable.DefaultView.Count / 4;
            }
            if (pageCount * _patientCount < _operationsInfoDataTable.DefaultView.Count) pageCount++;
            for (int i = 1; i <= pageCount; i++)
            {
                cmbPages.Properties.Items.Add(i.ToString());
            }
            if (cmbPages.Properties.Items.Count < 2)
            {

                
                cmbPages.Visible = false;
                btnFirst.Visible = false;
                btnNext.Visible = false;
                btnPrior.Visible = false;
                btnLast.Visible = false;
                //labelPageCount.Visible = false;
                //labelPatCount.Visible = false;
                
            }
            else
            {

                //panelControl2.Visible = true ;
                cmbPages.Visible = true;
                btnFirst.Visible = true;
                btnNext.Visible = true;
                btnPrior.Visible = true;
                btnLast.Visible = true;
                //labelPageCount.Visible = true;
                //labelPatCount.Visible = true;
      
            }

            panelControl2.Visible = ((int)_operationsInfoDataTable.DefaultView.Count )> 1;
 
            labelPageCount.Text = string.Format("共{0}页", pageCount);
            labelPatCount.Text = _operationsInfoDataTable.DefaultView.Count.ToString();

            foreach (PatientContentViewNew patient in _patients)
            {
                patient.CancelFocus();
                //pnlBody.Controls.Remove(patient);
            } 


            while (_patients.Count < _patientCount)
            {
                PatientContentViewNew patient = new PatientContentViewNew();
                //_patients.Insert(0,patient);
                _patients.Add(patient);

                //patient.BackColor = _contentBackColor;
                //patient.Visible = false;
                flowLayoutPanel1.Controls.Add(patient);

                patient.Clicked += new EventHandler(patient_Click);
                patient.DoubleClicked += new EventHandler(patient_DoubleClick);
                patient.Dock = DockStyle.Top;
                patient.BringToFront();
            }

            int count = _patientCount < _normalCount ? _normalCount : _patientCount;
            while (_patients.Count > count)
            {
                PatientContentViewNew patient = _patients[_patients.Count - 1];
                flowLayoutPanel1.Controls.Remove(patient);
                _patients.Remove(patient);
            }

        

            //_patients.Clear();
            string filtString = "";
            int patientIndex = 0;
            if (_operationsInfoDataTable != null && _operationsInfoDataTable.DefaultView.Count > 0 && _patients.Count > 0)
            {
                
                for (int i = _pageIndex * _patientCount; i < _operationsInfoDataTable.DefaultView.Count; i++)
                {
                    DataRow row = _operationsInfoDataTable.DefaultView[i].Row;
                    ///只处理符合当前手术状态的数据记录
                    if ((_operStatus != 99 && ( row["OPER_STATUS"] == System.DBNull.Value || (decimal)row["OPER_STATUS"] != _operStatus)) || (!string.IsNullOrEmpty(filtString) && !StringManage.GetPYString(row["NAME"].ToString()).ToLower().Contains(filtString)))
                    {
                        continue;
                    }
                    //if (!string.IsNullOrEmpty(txtRoomNo.Text))
                    //{
                    //    string roomNo = "," + txtRoomNo.Text.Trim() + ",";
                    //    if (!roomNo.Contains("," + row["OPERATING_ROOM_NO"].ToString().Trim() + ",")) continue;
                    //}
                    //PatientContentViewNew patient = new PatientContentViewNew(new PatientInformation(row));
                    PatientContentViewNew patient = _patients[patientIndex];
                    patient.PatientInformation = new PatientInformation(row);
                    patientIndex++;

                    toolTip1.SetToolTip(patient, "鼠标双击选中");

                    
                    patient.NurseTable = _nurseTable;
                    patient.DoctorTable = _doctorTable;

                    patient.FlagFangSheImage = FlagFangSheImage;
                    patient.FlagGeliImage = FlagGeliImage;
                    patient.FlagEmgerencyImage = FlagEmgerencyImage;
                    patient.InitalizeUI();

                    if (ExtendApplicationContext.Current.PatientInformation != null
                        && patient.PatientInformation.PatientID == ExtendApplicationContext.Current.PatientInformation.PatientID
                        && patient.PatientInformation.VisitID == ExtendApplicationContext.Current.PatientInformation.VisitID
                        && patient.PatientInformation.OperID == ExtendApplicationContext.Current.PatientInformation.OperID)
                        patient.Selected = true;

                    patient.Visible = true;
                    patient.Refresh();
                    //patient.BackColor = _contentBackColor;
                    
                    
                    //_patients.Add(patient);
                    //pnlBody.Controls.Add(patient);

                    //patient.Clicked += new EventHandler(patient_Click);
                    //patient.DoubleClicked += new EventHandler(patient_DoubleClick);
                    //patient.Click += new EventHandler(patient_MouseEnter);
                    
                    //patient.BringToFront();
                    //if (_patients.Count >= _patientCount) break;
                    if (patientIndex >= _patientCount) break;
                }

               
            }

            for (int i = _patients.Count -1; i >= patientIndex; i--)
                _patients[i].Visible = false;
            Visible = true;
        }

        private void patient_MouseEnter(object sender, EventArgs e)
        {
            foreach (PatientContentViewNew patient in _patients)
            {
                if (patient != sender)
                    patient.CancelFocus();
            } 


            PatientContentViewNew pcontent = sender as PatientContentViewNew;
           
            ShowPatientInformation(pcontent);
        }

        private DataTable SelectOperationRoom(DataTable operationsInfoDataTable)
        {
            DataTable res = null; 
             DataTable t = operationsInfoDataTable.Copy();
            // if (!string.IsNullOrEmpty(comboBoxOperRoom.Text) && txtRoomNo.Text.Length >= 1 )
            //{
            //    DataRow[] rows = _operationsInfoDataTable.Select("OPERATING_ROOM_NO = '" + txtRoomNo.Text + "'");
            //    t.Clear();
            //    foreach (DataRow row in rows)
            //        t.ImportRow(row);
            //}



             res = t;

             //复苏
             if (ExtendApplicationContext.Current.AppType == ApplicationType.PACU)
             {
                 DataTable temp = t.Copy();
                 DataRow[] rows = t.Select("oper_status >= 40 and oper_status <=55 ", "OPER_STATUS asc ");
                 temp.Clear();
                 foreach (DataRow row in rows)
                     temp.ImportRow(row);
                 res = temp;
             }
            
            return res;
        }
        private DataTable SortOperationTable(DataTable operationsInfoDataTable)
        {
            DataTable res = null;
            try
            {
                if  (ExtendApplicationContext.Current.AppType != ApplicationType.PACU)
                {
                    DataRow[] rows = operationsInfoDataTable.Select("OPER_STATUS >= 5 AND  OPER_STATUS < 35 ", "OPERATING_ROOM_NO,OPER_STATUS");
                DataRow[] rows00 = operationsInfoDataTable.Select("OPER_STATUS >= 0  AND OPER_STATUS < 5 OR  OPER_STATUS IS NULL ", "OPERATING_ROOM_NO");
                DataRow[] rows25 = operationsInfoDataTable.Select("OPER_STATUS >= 35 ", "OPERATING_ROOM_NO");
                DataTable t = operationsInfoDataTable.Clone();
                t.Clear();

                foreach (DataRow row in rows)
                    t.ImportRow(row);
                foreach (DataRow row in rows00)
                    t.ImportRow(row);
                foreach (DataRow row in rows25)
                    t.ImportRow(row);
                res = t;
                }
            
                //复苏
               else if (ExtendApplicationContext.Current.AppType == ApplicationType.PACU)
                {
                    DataRow[] rows45 = operationsInfoDataTable.Select("OPER_STATUS = 45  ");
                    DataRow[] rows4045 = operationsInfoDataTable.Select("OPER_STATUS >= 40  AND OPER_STATUS < 45 ");
                    DataRow[] rows4555 = operationsInfoDataTable.Select("OPER_STATUS > 45  AND OPER_STATUS <= 80 ");
                    DataTable t = operationsInfoDataTable.Clone();
                    t.Clear();

                    foreach (DataRow row in rows4045)
                        t.ImportRow(row);

                    foreach (DataRow row in rows45)
                        t.ImportRow(row);

                    foreach (DataRow row in rows4555)
                        t.ImportRow(row);
                    res = t;
                }

           
            }
            catch
            { 
                
            }
            return res;
        
        
        }
        /// <summary>
        /// 重新获取数据并定位当前患者
        /// </summary>
        public void RefreshPatientDataTable(string patientID)
        {
            
            Cursor oldCursor = Cursor;
            Cursor = Cursors.WaitCursor;

            if (pnlBodyRight.Controls.Count == 1)
            {
                pnlBodyRight.Controls[0].Visible = false;
            }

            string departCode = txtDeptCode.Text;
            if (!string.IsNullOrEmpty(departCode))
            {
                DataRow[] rows = _deptDict.Select("DEPT_NAME = '" + TransStr(departCode) + "'");
                if (rows.Length > 0 && rows[0]["DEPT_CODE"] != System.DBNull.Value)
                {
                    departCode = rows[0]["DEPT_CODE"].ToString();
                }
            }

            string operationStatus = txtStatus.Text;
            if (!string.IsNullOrEmpty(operationStatus))
            {
                operationStatus = ((int)OperationStatusHelper.OperationStatusFromString(operationStatus)).ToString();

            }
            string anesDoc = "";
            if (txtAnesDoctor.Text != "")
            {

                string userInfo = txtAnesDoctor.Text.Trim();
                anesDoc += userInfo + "#";

                //如果输如的是ID ，获取名字
                Dict.HisUserRow rowUser = _doctorTable.FindByUSER_ID(userInfo);
                if (rowUser != null)
                {
                    anesDoc += rowUser.USER_NAME + "#";
                }

                //通过输入的名字来获取 ID
                foreach (Dict.HisUserRow row in _doctorTable)
                {
                    if (row.USER_NAME == userInfo)
                    {
                        anesDoc += row.USER_ID + "#";
                    }
                }
                
                

            }

            // 将ASA转义成手术科室代码
            _operationsInfoDataTable = PatientInformationsProxy.GetPatientListDataTable(dateTimePickerQuery.DateTime.Date, txtPatientID.Text, txtName.Text, anesDoc
                , departCode, operationStatus, ApplicationConfiguration.OpertionDeptCode, txtOperationName.Text, txtAnesMethod.Text, txtAge.Text, txtAge1.Text);
            //_operationsInfoDataTable = PatientInformationsProxy.GetPatientListDataTable(dateTimePickerQuery.DateTime.Date, TransStr(txtPatientID.Text), TransStr(txtName.Text), TransStr(anesDoc)
            //    , TransStr(departCode), TransStr(operationStatus), TransStr(ApplicationConfiguration.OpertionDeptCode), TransStr(txtOperationName.Text), TransStr(txtAnesMethod.Text), TransStr(txtAge.Text), TransStr(txtAge1.Text));
            _operationsInfoDataTable = SortOperationTable(_operationsInfoDataTable);

            if (dateTimePickerQuery2.DateTime > DateTime.MinValue)
            {
                _operationsInfoDataTable = PatientInformationsProxy.GetPatientListDataTable(DateTime.MinValue, txtPatientID.Text, txtName.Text, anesDoc
               , departCode, operationStatus, ApplicationConfiguration.OpertionDeptCode, txtOperationName.Text, txtAnesMethod.Text, txtAge.Text, txtAge1.Text);
                // _operationsInfoDataTable = PatientInformationsProxy.GetPatientListDataTable(DateTime.MinValue, TransStr(txtPatientID.Text), TransStr(txtName.Text), TransStr(anesDoc)
                //, TransStr(departCode), TransStr(operationStatus), TransStr(ApplicationConfiguration.OpertionDeptCode), TransStr(txtOperationName.Text), TransStr(txtAnesMethod.Text), TransStr(txtAge.Text), TransStr(txtAge1.Text));

                DateTime endTime = dateTimePickerQuery2.DateTime.AddDays(1);
                List<DataRow> removeRow = new List<DataRow>();
                foreach (DataRow row in _operationsInfoDataTable.Rows)
                {
                    if (row.IsNull("START_DATE_TIME"))
                        continue;

                    DateTime dtCurrent = Convert.ToDateTime(row["START_DATE_TIME"]);
                    if (dtCurrent < dateTimePickerQuery.DateTime || dtCurrent > endTime)
                    {
                        removeRow.Add(row);
                    }
                }

                foreach (DataRow row in removeRow)
                    _operationsInfoDataTable.Rows.Remove(row);
            }
            else
            {
                //_operationsInfoDataTable = PatientInformationsProxy.GetPatientListDataTable(dateTimePickerQuery.DateTime.Date, txtPatientID.Text, txtName.Text, anesDoc
                //    , departCode, operationStatus, string.Empty, txtOperationName.Text, txtAnesMethod.Text, txtAge.Text, txtAge1.Text);
            }

           //_operationsInfoDataTable = SelectOperationRoom(_operationsInfoDataTable);
           //_operationsInfoDataTable =  SortOperationTable(_operationsInfoDataTable);

           if (!string.IsNullOrEmpty(txtPatientID.Text) || !string.IsNullOrEmpty(txtName.Text))
           {
               comboBoxOperRoom.Text = "";
           }

           //刷新的时候不改变 _pageIndex 值
            //_pageIndex = 0;
            if (_operationsInfoDataTable != null && _operationsInfoDataTable.Rows.Count == 0)
            {
                foreach (Control ctrl in flowLayoutPanel1.Controls)
                {
                    ctrl.Visible = false;
                }

                //pnlBody.Controls.Clear();
                if (pnlBodyRight.Controls.Count == 1)
                {
                    pnlBodyRight.Controls[0].Visible = false;
                }
                //Label lblMsg = new Label();
                //lblMsg.Text = "没有查到符合条件的数据。";
                //lblMsg.Left = 10;
                //lblMsg.Top = 5;
                //lblMsg.Width = 200;
                //pnlBody.Controls.Add(lblMsg);
                //btnMin.Visible = false;
                //lblMsg.Visible = true;

                labelPatCount.Text = "0";
                labelPageCount.Text = string.Format("共{0}页", 0);

                panelControl2.Visible = false;

            }
            else
            {
                //if (pnlBody.Controls.ContainsKey("lblMsg"))
                //{
                //    pnlBody.Controls.Remove(pnlBody.Controls.Find("lblMsg", false)[0]);
                //}                
                panelControl2.Visible = true;
                FilterData(patientID);
                btnSearch.Focus();
                //btnMin.Visible = true;
            }

            
            Cursor = oldCursor;
        }

        /// <summary>
        /// 去掉特殊字符
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string TransStr(string s)
        {
            string[] strs = new string[]{";","&","<",">","'","--","/","%","~",",","`","!","@","#","$","^",
            "*","(",")","+",":","<",">","?","/","\\","\"","{","}","[","]","-","_"," ","！","~","￥","…","（",
            "）"," ","——","、","。","."};
            foreach (string str in strs)
            {
                if (s.Contains(str))
                {
                    if (str == "'")
                        s = s.Replace(str, "''");
                    else s = s.Replace(str, "");
                }
            }
            return s;
        }
        private int _pageIndex = 0;

        private void SelectPatient(int index)
        {
            if (_patients.Count > index && index >= 0)
            {
                SelectPatient(_patients[index]);
            }
        }
        private void SelectPatient(PatientContentViewNew PatientContentViewNew)
        {


            RefreshPatientDataTable(PatientContentViewNew.PatientInformation.PatientID, PatientContentViewNew.PatientInformation.VisitID, PatientContentViewNew.PatientInformation.OperID);
            foreach (PatientContentViewNew patient in _patients)
            {
                if (!patient.Equals(PatientContentViewNew))
                {
                    patient.Selected = false;
                }
            }
            PatientContentViewNew.Selected = true;

            
            _selectedPatient = PatientContentViewNew;

            //双击选中，全局变量赋值
            PatientInformation patientInformation = PatientContentViewNew.PatientInformation;
            if (patientInformation != null) 
            {
                ExtendApplicationContext.Current.PatientContext.PatientID = patientInformation.PatientID;
                ExtendApplicationContext.Current.PatientContext.VisitID = patientInformation.VisitID;
                ExtendApplicationContext.Current.PatientContext.OperID = patientInformation.OperID;
            }
            else
            {
                ExtendApplicationContext.Current.PatientContext.PatientID = "";
            }
            ExtendApplicationContext.Current.PatientInformation = PatientContentViewNew.PatientInformation;
            TransOperationName();
            (Events[_selectChanged] as EventHandler)?.Invoke(this, null);
        }

        private void TransOperationName()
        {
            if (!string.IsNullOrEmpty(ExtendApplicationContext.Current.PatientContext.PatientID))
            {
                AnesInformations.OperationMasterDataTable operationMaster = AnesthesiaSheetProxy.GetOperationMaster(ExtendApplicationContext.Current.PatientContext.PatientID
                    , ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID);
                if(operationMaster != null && operationMaster.Count == 1 && (operationMaster[0].IsOPER_NAMENull() || string.IsNullOrEmpty(operationMaster[0].OPER_NAME)))
                {
                    CareDocs.OperationNameDataTable operationName = CareDocsProxy.GetOperationName(ExtendApplicationContext.Current.PatientContext.PatientID
                    , ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID);
                    if(operationName != null && operationName.Count > 0)
                    {
                        string operName = "";
                        foreach(CareDocs.OperationNameRow row in operationName)
                        {
                            operName += "," +row.OPER_NAME;
                        }
                        operationMaster[0].OPER_NAME = operName.Substring(1);
                        AnesthesiaSheetProxy.UpdateOperationMaster(operationMaster);
                    }
                }
            }
        }

        private void Search()
        {
            ApplicationConfiguration.PatientListDate = dateTimePickerQuery.DateTime.Date;
            if (comboBoxOperRoom.Text.Length == 1)
            {
                comboBoxOperRoom.Text = "0" + comboBoxOperRoom.Text;
            }

            InitPatientDataTableAndPageIndex();
      }

        //private void DrawPanel(Graphics g, Control control, Image image,string text)
        //{
        //    Rectangle rect = control.ClientRectangle;
        //    rect.X = control.Padding.Left - 1;
        //    rect.Width -= control.Padding.Left + control.Padding.Right - 1;
        //    rect.Y = 0;
        //    //rect.Height -= 10 + rect.Y;
        //    using (Brush brush = new SolidBrush(_contentBackColor))
        //    {
        //        g.FillRectangle(brush, new Rectangle(rect.X, rect.Top + 20, rect.Width, rect.Height));
        //    }
        //    using (Pen pen = new Pen(_borderColor))
        //    {
        //        g.DrawRectangle(pen, rect.X, rect.Y + 20, rect.Width, rect.Height - 20);
        //    }
        //    int height = 29;
        //    if (_panelBackGroundImage != null)
        //    {
        //        height = _panelBackGroundImage.Height;
        //        using (Brush brush1 = new TextureBrush(_panelBackGroundImage))
        //        {
        //            g.FillRectangle(brush1, rect.Left + 5, rect.Top, control.Width - rect.Left - 15, height);
        //        }
        //    }
        //    if (_panelLeftImage != null)
        //    {
        //        g.DrawImage(_panelLeftImage, rect.Left, rect.Top, _panelLeftImage.Width, height);
        //    }
        //    if (_panelRightImage != null)
        //    {
        //        g.DrawImage(_panelRightImage, rect.Right - _panelRightImage.Width + 1, rect.Top, _panelRightImage.Width, height);
        //    }
        //    //g.DrawImage(picPanelTop.Image, rect.Left, rect.Top - picPanelTop.Image.Height, rect.Width + 1, picPanelTop.Image.Height);
        //    if (image != null)
        //    {
        //        //g.DrawImage(image, rect.Left + 5, rect.Top - picPanelTop.Image.Height + 2);
        //        g.DrawImage(image, rect.Left + 10, rect.Top + (height - image.Height * .8f) / 2, (int)(image.Width * .8f), (int)(image.Height * .8f));
        //    }
        //    using (Font font = new Font("宋体", 10, FontStyle.Bold))
        //    {
        //        using (Brush brush2 = new SolidBrush(ApplicationConfiguration.SelectPatientTopColor))
        //        {
        //            g.DrawString(text, font, brush2, rect.Left + 35, rect.Top + (height - g.MeasureString(text, font).Height) / 2);
        //        }
        //    }
        //}

        #endregion 方法
        #region 事件

        private void patient_DoubleClick(object sender, EventArgs e)
        {
            SelectPatient(sender as PatientContentViewNew);

            ShowPatientInformation(sender as PatientContentViewNew);


            EventHandler eventHandle = Events[_patientDoubleClick] as EventHandler;
            if (eventHandle != null)
            {
                eventHandle(sender, e);
            }



        }

        private void patient_Click(object sender, EventArgs e)
        {
            foreach (PatientContentViewNew patient in _patients)
            {
                if (patient != sender)
                    patient.CancelFocus();
            } 


            ShowPatientInformation(sender as PatientContentViewNew);

        }

        /// <summary>
        /// 显示当前患者详细信息
        /// </summary>
        private void ShowPatientInformation(PatientContentViewNew patient)
        {
            _showPatient = patient;
            if (_showPatient != null)
            {
                if (pnlBodyRight.Controls.Count == 1)
                {
                    pnlBodyRight.Controls[0].Visible = true;
                }
            }
            EventHandler eventHandle = Events[_patientClick] as EventHandler;
            if (eventHandle != null)
            {
                eventHandle(this, null);
            }
        }

        private void txtKeyLetters_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void btnBeforeOperation_Click(object sender, EventArgs e)
        {
            _operStatus = 1;
            RefreshPatientDataTable();
        }

        private void btnInOperation_Click(object sender, EventArgs e)
        {
            _operStatus = 2;
            RefreshPatientDataTable();
        }

        private void btnAfterOperation_Click(object sender, EventArgs e)
        {
            _operStatus = 4;
            RefreshPatientDataTable();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            _operStatus = 99;
            RefreshPatientDataTable();
        }

        private void txtStatus_DoubleClick(object sender, EventArgs e)
        {
            bool multiSelect = false;
            List<string> list = OperationStatusHelper.OperationStatusList;
            Dialog.ShowCustomSelection(list, "", txtStatus, new Point(0, txtStatus.Height), new Size(200, 400)
                , new EventHandler(delegate(object sender1, EventArgs e1)
                {
                    if (!multiSelect)
                    {
                        if (sender1 is int)
                        {
                            int index = (int)sender1;
                            txtStatus.Text = list[index];
                        }
                    }
                    else
                    {
                        int[] selectedIndexes = sender1 as int[];
                        if (selectedIndexes != null)
                        {
                            string text = "";
                            foreach (int index in selectedIndexes)
                            {
                                text += "," + list[index];
                            }
                            txtStatus.Text = text.Substring(1);
                        }
                    }
                }), multiSelect);
        }

        /// <summary>
        /// 手术间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRoomNo_DoubleClick(object sender, EventArgs e)
        {
            Dialog.SelectFromDataTable(_OperatingRoom, _OperatingRoom.ROOM_NOColumn.ToString(), sender as Control, false);
        }

        /// <summary>
        /// 麻醉方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAnesMethod_DoubleClick(object sender, EventArgs e)
        {
            Dialog.SelectFromDataTable(_anesMethod, _anesMethod.ANES_NAMEColumn.ToString(), sender as Control, false);
        }

        /// <summary>
        /// 手术名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOperationName_DoubleClick(object sender, EventArgs e)
        {
            Dialog.SelectFromDataTable(_optionDictTable, _optionDictTable.OPER_NAMEColumn.ToString(), sender as Control, false);
        }

        /// <summary>
        /// 麻醉医生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAnesDoctor_DoubleClick(object sender, EventArgs e)
        {
            DataRow[] rows = _doctorTable.Select("USER_DEPT = '" + ApplicationConfiguration.AnesthesiaWardCode + "'");
            Dialog.SelectFromRows(rows, "USER_NAME", sender as Control, false);
        }

        /// <summary>
        /// ASA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAsa_DoubleClick(object sender, EventArgs e)
        {
            DataRow[] rows = _commonDictTable.Select("item_class = 'ASA分级'");
            List<DataRow> rowList = new List<DataRow>(rows);
            rowList.Sort(new Comparison<DataRow>(delegate(DataRow row1, DataRow row2)
            {
                if (row1["SERIAL_NO"] == System.DBNull.Value || row2["SERIAL_NO"] == System.DBNull.Value)
                {
                    return 0;
                }
                else
                {
                    return ((decimal)row1["SERIAL_NO"]).CompareTo((decimal)row2["SERIAL_NO"]);
                }
            }));
            rows = rowList.ToArray();
            Dialog.SelectFromRows(rows, "ITEM_NAME", sender as Control, false);
        }

        /// <summary>
        /// 科室
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDeptCode_DoubleClick(object sender, EventArgs e)
        {
            Dialog.SelectFromDataTable(_deptDict, _deptDict.DEPT_NAMEColumn.ToString(), sender as Control, false);
        }

        /// <summary>
        /// 诊断列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDiagnosis_DoubleClick(object sender, EventArgs e)
        {
            Dialog.SelectFromDataTable(_diagnosisDictTable, _diagnosisDictTable.DIAGNOSIS_NAMEColumn.ToString(), sender as Control, false);
        }

        /// <summary>
        /// 搜索按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        //今天清单按钮
        private void btnToday_Click(object sender, EventArgs e)
        {
            //dateTimePickerQuery.DateTime = DateTime.Today;

            //_pageIndex = 0;
            //RefreshPatientDataTable(System.DateTime.Today);
            //if (cmbPages.SelectedIndex != 0)
            //{
            //    //设为第一页
            //    cmbPages.SelectedIndexChanged -= new System.EventHandler(this.cmbPages_SelectedIndexChanged);
            //    cmbPages.SelectedIndex = 0;
            //    cmbPages.SelectedIndexChanged += new System.EventHandler(this.cmbPages_SelectedIndexChanged);
            //}

            RefreshDate(DateTime.Today);
            btnToday.Focus();
        }
        //明天排班清单按钮
        private void btnTommrow_Click(object sender, EventArgs e)
        {
            RefreshDate(DateTime.Today.AddDays(1));
            btnTommrow.Focus();
           
        }


        protected void RefreshDate(DateTime dt)
        {
            dateTimePickerQuery.DateTime = dt;

            _pageIndex = 0;
            RefreshPatientDataTable(dt);
            if (cmbPages.SelectedIndex != 0)
            {
                //设为第一页
                cmbPages.SelectedIndexChanged -= new System.EventHandler(this.cmbPages_SelectedIndexChanged);
                cmbPages.SelectedIndex = 0;
                cmbPages.SelectedIndexChanged += new System.EventHandler(this.cmbPages_SelectedIndexChanged);
            }
        }

        /// <summary>
        /// 重新DateTime刷新清单
        /// </summary>
        public void RefreshPatientDataTable(DateTime Date)
        {
            Cursor oldCursor = Cursor;
            Cursor = Cursors.WaitCursor;

            string departCode = txtDeptCode.Text;
            if (!string.IsNullOrEmpty(departCode))
            {
                DataRow[] rows = _deptDict.Select("DEPT_NAME = '" + departCode + "'");
                if (rows.Length > 0 && rows[0]["DEPT_CODE"] != System.DBNull.Value)
                {
                    departCode = rows[0]["DEPT_CODE"].ToString();
                }
            }

            string operationStatus = txtStatus.Text;
            if (!string.IsNullOrEmpty(operationStatus))
            {
                operationStatus = ((int)OperationStatusHelper.OperationStatusFromString(operationStatus)).ToString();
            }
            _operationsInfoDataTable = PatientInformationsProxy.GetPatientListDataTable(Date, txtPatientID.Text, txtName.Text, txtAnesDoctor.Text
                , departCode, operationStatus, ApplicationConfiguration.OpertionDeptCode, txtOperationName.Text, txtAnesMethod.Text, txtAge.Text, txtAge1.Text);

            _operationsInfoDataTable = SortOperationTable(_operationsInfoDataTable);
       
            _pageIndex = 0;
            if (_operationsInfoDataTable != null && _operationsInfoDataTable.Rows.Count == 0)
            {
                //pnlBody.Controls.Clear();
                foreach (Control ctrl in flowLayoutPanel1.Controls)
                {
                    ctrl.Visible = false;
                }

                if (pnlBodyRight.Controls.Count == 1)
                {
                    pnlBodyRight.Controls[0].Visible = false;
                }
                //Label lblMsg = new Label();
                //lblMsg.Text = "没有查到符合条件的数据。";
                //lblMsg.Left = 10;
                //lblMsg.Top = 5;
                //lblMsg.Width = 200;
                //pnlBody.Controls.Add(lblMsg);
                //btnMin.Visible = false;
                //lblMsg.Visible = true;

                labelPatCount.Text = "0";

                labelPageCount.Text = string.Format("共{0}页", 0);
                
            }
            else
            {
                //if (pnlBody.Controls.ContainsKey("lblMsg"))
                //{
                //    pnlBody.Controls.Remove(pnlBody.Controls.Find("lblMsg", false)[0]);
                //}
                FilterData(null);
            
                //btnMin.Visible = true;
            }
            Cursor = oldCursor;
        }
        /// <summary>
        /// 支持回车查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPatientID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar) == 13)
            {
                Search();
            }
        }

        /// <summary>
        /// 显示/隐藏更多查询条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMore_Click(object sender, EventArgs e)
        {
            if (btnMore.Text == ">>")
            {
                panelMore.Height = 105;
                btnMore.Text = "<<";
            }
            else
            {
                panelMore.Height = 0;
                btnMore.Text = ">>";
                txtAnesMethod.Text = "";
                dateTimePickerQuery2.Text = "";
                txtAnesDoctor.Text = "";
                txtAge.Text = "";
                txtAge1.Text = "";
                txtDeptCode.Text = "";
                txtOperationName.Text = "";
            }
           
        }

        private void btnJiZhen_Click(object sender, EventArgs e)
        {
            //获取普通绘制界面
            Dictionary<string, MedicalDocElement> docs = MedicalDocSettings.GetCustomForms();
            KeyValuePair<string, MedicalDocElement> keyValuePairDoc = new KeyValuePair<string, MedicalDocElement>();
            foreach (KeyValuePair<string, MedicalDocElement> keyValuePair in docs)
            {
                if (keyValuePair.Key.Trim() == "急诊登记")
                {
                    keyValuePairDoc = keyValuePair;
                    break;
                }
            }

            //没有找到退出
            if (string.IsNullOrEmpty(keyValuePairDoc.Key))
            {
                DialogResult dialogResult = XtraMessageBox.Show("自定义【急诊登记】模块加载失败，请检查配置！",
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
                //if (view.ResultData)
                {
                    Search();
                }
            }
            catch (Exception ex)
            {

                Exception excep = new Exception("自定义【急诊登记】模块加载失败，请检查配置！");
                ex.Source = excep.Source;
                ExceptionHandler.Handle(excep);
            }




        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {


            // DrawPanel(e.Graphics, (sender as Control), _docImage,"患者列表");


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {


              //DrawPanel(e.Graphics, (sender as Control), _patImage,"患者详情");


        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            //if (_isMin)
            //{
            //    foreach (PatientContentViewNew patient in _patients)
            //    {
            //        patient.SetMaxHeight();
            //    }
            //    //_patientCount = 4;
            //    _isMin = false;
            //    //设置显示量
            //    //FilterData(null);
            //    btnMin.Text = "收缩";
            //}
            //else
            //{
            //    foreach (PatientContentViewNew patient in _patients)
            //    {
            //        patient.SetMinHeight();
            //    }
            //   // _patientCount = 8;
            //    //_pageIndex = 0;
            //    _isMin = true;
                
            //    btnMin.Text = "展开";
            //}
            //_pageIndex = 0;
            //_patientCount = GetPatientContentCountForOnePage(_isMin);
            //FilterData(null);
        }

        private bool _isMin = false;

        private void cmbPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            _pageIndex = cmbPages.SelectedIndex;
            FilterData();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            cmbPages.SelectedIndex = 0;
        }

        private void btnPrior_Click(object sender, EventArgs e)
        {
            if (cmbPages.SelectedIndex > 0)
            {
                cmbPages.SelectedIndex--;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (cmbPages.SelectedIndex < cmbPages.Properties.Items.Count - 1)
            {
                cmbPages.SelectedIndex++;
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            cmbPages.SelectedIndex = cmbPages.Properties.Items.Count - 1;
        }

        #endregion 事件

        private void radioStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!radioStatus.Visible) return;
            switch (radioStatus.SelectedIndex)
            {
                case 1:
                    labelControlBefore.Visible = true;
                    labelControlIn.Visible = false;
                    this.labelControlAfter.Visible = false;
                    break;
                case 2:
                    labelControlBefore.Visible = false;
                    labelControlIn.Visible = true;
                    this.labelControlAfter.Visible = false;
                    break;
                case 3:
                    labelControlBefore.Visible = false;
                    labelControlIn.Visible = false;
                    this.labelControlAfter.Visible = true;
                    break;
                default:
                    labelControlBefore.Visible = false;
                    labelControlIn.Visible = false;
                    this.labelControlAfter.Visible = false;
                    break;
            }
            _pageIndex = 0;
            cmbPages.SelectedIndex = 0;
            flowLayoutPanel1.Focus();
            FilterData();
        }

        private void chkFilter_CheckedChanged(object sender, EventArgs e)
        {
            _pageIndex = 0;
            cmbPages.SelectedIndex = 0;
            FilterData();
        }

        private void comboBoxOperRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            _pageIndex = 0;
            cmbPages.SelectedIndex = 0;
            FilterData();
            txtPatientID.Focus();
        }

        private void PatientListView_Load(object sender, EventArgs e)
        {
            //pnlBody.AutoScroll = true;
            //pnlBody.VerticalScroll.Enabled = true;
            dateTimePickerQuery.Properties.MaxValue = DateTime.Now.AddYears(1);
            FlagGeliImage = ApplicationConfiguration.GetSkinImage("隔离.png"); ;
            FlagEmgerencyImage = ApplicationConfiguration.GetSkinImage("紧急.png"); ;
            FlagFangSheImage = ApplicationConfiguration.GetSkinImage("放射.png");

            comboBoxOperRoom.Properties.Items.Clear();

            DataTable table = ExtendApplicationContext.Current.CodeTables["WIS_OPER_ROOM"];
            table.DefaultView.RowFilter = "BED_TYPE = 0";
            foreach (DataRowView row in table.DefaultView)
            {
                string str = row["ROOM_NO"].ToString();
                comboBoxOperRoom.Properties.Items.Add(str);
            }

            if(!string.IsNullOrEmpty(ApplicationConfiguration.OpertionRoom))
                comboBoxOperRoom.Text = ApplicationConfiguration.OpertionRoom;

            InitPatientDataTableAndPageIndex();
            //Add By chengying.x @20140213 麻醉通过术前术中术后过滤，新增复苏根据复苏前、复苏中复苏后过滤。
            if (ExtendApplicationContext.Current.AppType == ApplicationType.PACU)
            {
                radioStatus.Visible = false;
                labelControlBefore.Visible = false;
                labelControlIn.Visible = false;
                labelControlAfter.Visible = false;
                radioStatusPACU.Visible = true;
                labelControlBeforePACU.Visible = false;
                labelControlInPACU.Visible = false;
                labelControlAfterPACU.Visible = false;
            }
            else
            {
                radioStatus.Visible = true;
                labelControlBefore.Visible = false;
                labelControlIn.Visible = false;
                labelControlAfter.Visible = false;
                radioStatusPACU.Visible = false;
                labelControlBeforePACU.Visible = false;
                labelControlInPACU.Visible = false;
                labelControlAfterPACU.Visible = false;
            }

            //End Add
        }

        private void radioStatusPACU_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!radioStatusPACU.Visible) return;
            switch (radioStatusPACU.SelectedIndex)
            {
                case 1:
                    labelControlBeforePACU.Visible = true;
                    labelControlInPACU.Visible = false;
                    labelControlAfterPACU.Visible = false;
                    break;
                case 2:
                    labelControlBeforePACU.Visible = false;
                    labelControlInPACU.Visible = true;
                    this.labelControlAfterPACU.Visible = false;
                    break;
                case 3:
                    labelControlBeforePACU.Visible = false;
                    labelControlInPACU.Visible = false;
                    this.labelControlAfterPACU.Visible = true;
                    break;
                default:
                    labelControlBeforePACU.Visible = false;
                    labelControlInPACU.Visible = false;
                    this.labelControlAfterPACU.Visible = false;
                    break;
            }
            _pageIndex = 0;
            cmbPages.SelectedIndex = 0;
            flowLayoutPanel1.Focus();
            FilterData();
        }

        private void comboBoxOperRoom_DoubleClick(object sender, EventArgs e)
        {
            comboBoxOperRoom.Text = ApplicationConfiguration.OpertionRoom;
        }

        private void txtPatientID_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void textEditPerPageCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                FilterData();
        }

        private void pnlBody_MouseDown(object sender, MouseEventArgs e)
        {
            this.Focus();
        }

        private void btnSearch_DoubleClick(object sender, EventArgs e)
        {
            radioStatus.SelectedIndex = 0;
            checkEditPersonal.Checked = false;
            chkEngency.Checked = false;
            checkEditFangshe.Checked = false;
            checkEditGeli.Checked = false;
            comboBoxOperRoom.Text = "";
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now.Date.AddDays(1);
            OperationSchedule view = new OperationSchedule(dt);
            view.PatientSelected += delegate
            {
                RefreshDate(view.SelectedDate);
                EventHandler eventHandle = Events[_selectChanged] as EventHandler;
                if (eventHandle != null)
                {
                    eventHandle(this, null);
                }
            };

            DialogHostForm dialogHostForm = new DialogHostForm("手术排台", true);
            //DialogHostForm dialogHostForm = new DialogHostForm("手术排台", 1000,800);
            dialogHostForm.Child = view;
            dialogHostForm.ShowDialog();
        }

        private void radioGroupSortOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            _pageIndex = 0;
            cmbPages.SelectedIndex = 0;
            FilterData();
        }

        private void dateTimePickerQuery_EditValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerQuery.Text != "")
                txtPatientID.Focus();
        }

        private void txtAge_Validating(object sender, CancelEventArgs e)
        {
            if (txtAge.Text.Trim() != "")
            {
                if (txtAge1.Text.Trim() != "")
                {
                    if (Convert.ToInt32(txtAge.Text.Trim()) > Convert.ToInt32(txtAge1.Text.Trim()))
                    {
                        Dialog.MessageBox("年龄范围输入有误，请重新输入。", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtAge.Text = "1";
                        txtAge.Focus();
                    }
                }
            }
            else
            {
                if (txtAge1.Text.Trim() != "")
                {
                    Dialog.MessageBox("年龄范围输入有误，请重新输入。","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    txtAge.Focus();
                }
            }
        }

        private void txtAge1_Validating(object sender, CancelEventArgs e)
        {
            if (txtAge1.Text.Trim() != "")
            {
                if (txtAge.Text.Trim() != "")
                {
                    if (Convert.ToInt32(txtAge.Text.Trim()) > Convert.ToInt32(txtAge1.Text.Trim()))
                    {
                        Dialog.MessageBox("年龄范围输入有误，请重新输入。", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtAge1.Text = "100";
                        txtAge1.Focus();
                    }
                }
            }
            else
            {
                if (txtAge.Text.Trim() != "")
                {
                    Dialog.MessageBox("年龄范围输入有误，请重新输入。", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAge1.Focus();
                }
            }
        }

        private void dateTimePickerQuery2_EditValueChanged(object sender, EventArgs e)
        {
            if(dateTimePickerQuery2.Text != "")
                txtPatientID.Focus();
        }

        private void btnCanceled_Click(object sender, EventArgs e)
        {
            OperationCanceled view = new OperationCanceled();
            DialogHostForm dialogHostForm = new DialogHostForm("已取消手术", 800,600);
            dialogHostForm.Child = view;
            dialogHostForm.ShowDialog();
        }
    }
}
