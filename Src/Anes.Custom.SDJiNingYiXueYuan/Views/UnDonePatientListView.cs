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
using Wis.Anes.Framework.Controls.Base;
using Wis.Anes.DataAccess;

namespace Wis.Anes.Custom.CustomProject.Views
{
    public partial class UnDonePatientListView : BaseView
    {
        #region  变量
        private DictDA _dictDA=null;
        private PatientInformationsDA _PatientInformationsDA = null;
        private int _patientCount = 4;
        private bool _isMin = false;
        private int _pageIndex = 0;
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
        private List<PatientContentView> _patients = new List<PatientContentView>();
        /// <summary>
        /// 字典清单
        /// </summary>
        //private Dict.AnessthestaDictDataTable _anesMethod;
        private Dict.HisUserDataTable _doctorTable;
        private Dict.HisUserDataTable _nurseTable;
        //private Dict.WisDiagnosisDictDataTable _diagnosisDictTable;
        //private Dict.OperationDictDataTable _optionDictTable;
        //private Dict.AnesthesiaInputDictDataTable _commonDictTable;
        //private Dict.DeptDictDataTable _deptDict;
        //private Dict.OperatingRoomDataTable _OperatingRoom;
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
        //private Image _docImage = null;
        //public Image DocumentImage
        //{
        //    get
        //    {
        //        return _docImage;
        //    }
        //    set
        //    {
        //        _docImage = value;
        //    }
        //}

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

        //private Image _panelBackGroundImage = null;
        //public Image PanelBackGroundImage
        //{
        //    get
        //    {
        //        return _panelBackGroundImage;
        //    }
        //    set
        //    {
        //        _panelBackGroundImage = value;
        //    }
        //}

        //private Image _normalRoomImage = null;
        //public Image NormalRoomImage
        //{
        //    get
        //    {
        //        return _normalRoomImage;
        //    }
        //    set
        //    {
        //        _normalRoomImage = value;
        //    }
        //}

        //private Image _selectRoomImage = null;
        //public Image SelectRoomImage
        //{
        //    get
        //    {
        //        return _selectRoomImage;
        //    }
        //    set
        //    {
        //        _selectRoomImage = value;
        //    }
        //}

        //private Image _mouseEnterRoomImage = null;
        //public Image MouseEnterRoomImage
        //{
        //    get
        //    {
        //        return _mouseEnterRoomImage;
        //    }
        //    set
        //    {
        //        _mouseEnterRoomImage = value;
        //    }
        //}

        //private Image _panelLeftImage = null;
        //public Image PanelLeftImage
        //{
        //    get
        //    {
        //        return _panelLeftImage;
        //    }
        //    set
        //    {
        //        _panelLeftImage = value;
        //    }
        //}

        //private Image _panelRightImage = null;
        //public Image PanelRightImage
        //{
        //    get
        //    {
        //        return _panelRightImage;
        //    }
        //    set
        //    {
        //        _panelRightImage = value;
        //    }
        //}

        //private Image _patImage = null;
        //public Image PatientImage
        //{
        //    get
        //    {
        //        return _patImage;
        //    }
        //    set
        //    {
        //        _patImage = value;
        //    }
        //}

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

        private PatientContentView _selectedPatient = null;
        public PatientContentView SelectedPatient
        {
            get
            {
                return _selectedPatient;
            }
        }

        private PatientContentView _showPatient = null;
        public PatientContentView ShowPatient
        {
            get
            {
                return _showPatient;
            }
        }
        //private decimal _operStatus = 99;
        //public OperationStatus OperationStatus
        //{
        //    get
        //    {
        //        return GetOperationStatus(_operStatus);
        //    }
        //    set
        //    {
        //        _operStatus = (decimal)(int)value;
        //        FilterData();
        //    }
        //}

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

        #endregion 属性

        #region 构造方法

        public UnDonePatientListView()
        {
            InitializeComponent(); 
            base.Caption = "术中患者列表";
            Init();
        }

        #endregion

        #region 方法

        private void Init()
        {
            ///初始化字典
            if (!DesignMode)
            {
                _dictDA = new DictDA();
                _PatientInformationsDA = new PatientInformationsDA();
                if (ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_PERM_HIS_USER"))
                {
                    _doctorTable = ExtendApplicationContext.Current.CodeTables["WIS_PERM_HIS_USER"] as Dict.HisUserDataTable;
                    _nurseTable = ExtendApplicationContext.Current.CodeTables["WIS_PERM_HIS_USER"] as Dict.HisUserDataTable;
                }
                else
                {
                    _doctorTable = _dictDA.GetHisUsers();
                    _nurseTable = _dictDA.GetHisUsers();
                }
                //if (ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_DICT_ANES"))
                //{
                //    _anesMethod = ExtendApplicationContext.Current.CodeTables["WIS_DICT_ANES"] as Dict.AnessthestaDictDataTable;
                //}
                //else
                //{
                //    _anesMethod = _dictDA.GetAnesDict();
                //}
                //if (ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_DICT_DIAGNOSIS"))
                //{
                //    _diagnosisDictTable = ExtendApplicationContext.Current.CodeTables["WIS_DICT_DIAGNOSIS"] as Dict.WisDiagnosisDictDataTable;
                //}
                //else
                //{
                //    _diagnosisDictTable = _dictDA.GetDiagnosisDict();
                //}
                //if (ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_DICT_OPERATION"))
                //{
                //    _optionDictTable = ExtendApplicationContext.Current.CodeTables["WIS_DICT_OPERATION"] as Dict.OperationDictDataTable;
                //}
                //else
                //{
                //    _optionDictTable = _dictDA.GetOperationDict();
                //}
                //if (ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_DICT_ANES_INPUT"))
                //{
                //    _commonDictTable = ExtendApplicationContext.Current.CodeTables["WIS_DICT_ANES_INPUT"] as Dict.AnesthesiaInputDictDataTable;
                //}
                //else
                //{
                //    _commonDictTable = _dictDA.GetAnesthesiaInputDict();
                //}
                //if (ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_DICT_DEPT"))
                //{
                //    _deptDict = ExtendApplicationContext.Current.CodeTables["WIS_DICT_DEPT"] as Dict.DeptDictDataTable;
                //}
                //else
                //{
                //    _deptDict = _dictDA.GetDeptDict();
                //}
                //if (ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_OPER_ROOM"))
                //{
                //    _OperatingRoom = ExtendApplicationContext.Current.CodeTables["WIS_OPER_ROOM"] as Dict.OperatingRoomDataTable;
                //}
                //else
                //{
                //    _OperatingRoom = _dictDA.GetOperatingRoomDict();
                //}
                //txtRoomNo.Text = ApplicationConfiguration.OpertionRoom;
                InitPatientDataTableAndPageIndex();
            }
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

        private void SelectPatient(int index)
        {
            if (_patients.Count > index && index >= 0)
            {
                SelectPatient(_patients[index]);
            }
        }

        private void SelectPatient(PatientContentView PatientContentView)
        {
            foreach (PatientContentView patient in _patients)
            {
                if (!patient.Equals(PatientContentView))
                {
                    patient.Selected = false;
                }
            }
            PatientContentView.Selected = true;
            _selectedPatient = PatientContentView;

            //双击选中，全局变量赋值
            PatientInformation patientInformation = PatientContentView.PatientInformation;
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
            ExtendApplicationContext.Current.PatientInformation = PatientContentView.PatientInformation;
        }

        /// <summary>
        /// 重新获取数据并定位当前患者
        /// </summary>
        public void RefreshPatientDataTable()
        {
            Cursor oldCursor = Cursor;
            Cursor = Cursors.WaitCursor;

            _operationsInfoDataTable = _PatientInformationsDA.GetUnDonePatientList("");
            _operationsInfoDataTable = SelectOperationRoom(_operationsInfoDataTable);
            //_operationsInfoDataTable = SortOperationTable(_operationsInfoDataTable);

            //刷新的时候不改变 _pageIndex 值
            //_pageIndex = 0;
            if (_operationsInfoDataTable != null && _operationsInfoDataTable.Rows.Count == 0)
            {
                pnlBody.Controls.Clear();
                if (pnlBody.Controls.Count == 1)
                {
                    pnlBody.Controls[0].Visible = false;
                }
                Label lblMsg = new Label();
                lblMsg.Text = "没有查到符合条件的数据。";
                lblMsg.Left = 10;
                lblMsg.Top = 5;
                lblMsg.Width = 200;
                pnlBody.Controls.Add(lblMsg);
                btnMin.Visible = false;
                lblMsg.Visible = true;
            }
            else
            {
                if (pnlBody.Controls.ContainsKey("lblMsg"))
                {
                    pnlBody.Controls.Remove(pnlBody.Controls.Find("lblMsg", false)[0]);
                }
                FilterData();
            }
            Cursor = oldCursor;
        }

        private DataTable SelectOperationRoom(DataTable operationsInfoDataTable)
        {
            DataTable res = null;
            DataTable t = operationsInfoDataTable.Copy();
            if (!string.IsNullOrEmpty(ApplicationConfiguration.OpertionRoom))
            {
                DataRow[] rows = _operationsInfoDataTable.Select("OPERATING_ROOM_NO = '" + ApplicationConfiguration.OpertionRoom + "'");
                t.Clear();
                foreach (DataRow row in rows)
                    t.ImportRow(row);
            }
            res = t;
            return res;
        }

        private DataTable SortOperationTable(DataTable operationsInfoDataTable)
        {
            DataTable res = null;
            try
            {
                if (ExtendApplicationContext.Current.AppType != ApplicationType.PACU)
                {
                    DataRow[] rows = operationsInfoDataTable.Select("OPER_STATUS >= 5 AND  OPER_STATUS < 25 ", "OPER_STATUS desc ");
                    DataRow[] rows00 = operationsInfoDataTable.Select("OPER_STATUS >= 0  AND OPER_STATUS < 5 OR  OPER_STATUS IS NULL ");
                    DataRow[] rows25 = operationsInfoDataTable.Select("OPER_STATUS >= 25 ");
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


            }
            catch
            {

            }
            return res;
        }

        private void FilterData()//(string patientID)
        {

            if (_operationsInfoDataTable == null)
                return;

            _patientCount = GetPatientContentCountForOnePage(_isMin);

            Visible = false;
            cmbPages.Properties.Items.Clear();
            int pageCount = 1;
            if (_patientCount != 0)
            {
                pageCount = (int)_operationsInfoDataTable.Rows.Count / _patientCount;
            }
            else
            {
                pageCount = (int)_operationsInfoDataTable.Rows.Count / 4;
            }
            if (pageCount * _patientCount < _operationsInfoDataTable.Rows.Count) pageCount++;
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
            }
            else
            {
                cmbPages.Visible = true;
                btnFirst.Visible = true;
                btnNext.Visible = true;
                btnPrior.Visible = true;
                btnLast.Visible = true;
            }

            foreach (PatientContentView patient in _patients)
            {
                pnlBody.Controls.Remove(patient);
            }
            _patients.Clear();
            //string filtString = "";
            if (_operationsInfoDataTable != null && _operationsInfoDataTable.Rows.Count > 0)
            {

                for (int i = _pageIndex * _patientCount; i < _operationsInfoDataTable.Rows.Count; i++)
                {
                    DataRow row = _operationsInfoDataTable.Rows[i];
                    PatientContentView patient = new PatientContentView(new PatientInformation(row));

                    toolTip1.SetToolTip(patient, "鼠标双击选中");

                    patient.NurseTable = _nurseTable;
                    patient.DoctorTable = _doctorTable;
                    patient.InitalizeUI();
                    patient.BackColor = _contentBackColor;

                    _patients.Add(patient);
                    pnlBody.Controls.Add(patient);

                    patient.DoubleClicked += new EventHandler(patient_DoubleClick);
                    //patient.MouseEntered += new EventHandler(patient_MouseEnter);
                    patient.Dock = DockStyle.Top;
                    patient.BringToFront();
                    if (_patients.Count >= _patientCount) break;
                }
            }
            Visible = true;
        }

        /// <summary>
        /// 计算每页显示多少个信息
        /// </summary>
        /// <param name="isMin">是否最小化</param>
        /// <returns>返回每页显示多少个信息</returns>
        private int GetPatientContentCountForOnePage(bool isMin)
        {
            int res = 4;
            PatientContentView patient = new PatientContentView();
            res = (pnlBody.Height / (patient.Height + 8));
            patient.Dispose();
            patient = null;
            return res;
        }

        #endregion

        #region 事件

        private void patient_DoubleClick(object sender, EventArgs e)
        {
            SelectPatient(sender as PatientContentView);
            //EventHandler eventHandle = Events[_patientDoubleClick] as EventHandler;
            //if (eventHandle != null)
            //{
            //    eventHandle(sender, e);
            //}
            if (ParentForm != null && ParentForm.Modal)
            {
                ParentForm.DialogResult = DialogResult.OK;
                ParentForm.Close();
            }
        }

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

    }
}
