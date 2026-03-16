using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.ComponentModel;
using DevExpress.XtraEditors;
using Wis.Anes.FrameWork;
using Wis.Anes.Framework.Controls;
using Wis.Anes.Properties;
using Wis.Anes.BusinessEntity;
using Wis.Anes.ServiceProxies;
using Wis.Anes.Framework;

namespace Wis.Anes.Controls
{
    /// <summary>
    /// 床号信息控件
    /// </summary>
    public class BedHeadInformation : DevExpress.XtraEditors.XtraUserControl, IRender
    {
        private DataTable _patients;
        private DataRow _currentPatient;

        public DataTable Patients
        {
            get
            {
                return _patients;
            }
            set
            {
                if (_patients != value)
                {
                    _patients = value;

                    //BedInfo.MED_DEPT_BED_COUNTDataTable allBedCount = DataOperator.GetAllBedRecord();
                    //BedInfo.MED_DEPT_BED_COUNTRow currentRow = allBedCount.FindByWARD_CODE(DataOperator.WardCode);

                    LoadPatients(_patients);
                    //icuBedSelect1.Patients = _patients;
                }
            }
        }

        public DataRow CurrentPatient
        {
            get
            {
                return _currentPatient;
            }
            set
            {
                if (_currentPatient != value)
                {
                    _currentPatient = value;
                    RefreshBedHeadInfo(_currentPatient);
                    icuBedSelect1.CurrentPatient = _currentPatient;
                }
            }
        }
        /// <summary>
        /// 病人类型
        /// </summary>
        public enum PatientTypeEnum
        {
            /// <summary>
            /// 在院病人
            /// </summary>
            InHospital,

            /// <summary>
            /// 历史病人
            /// </summary>
            History,

            /// <summary>
            /// 所有病人
            /// </summary>
            All
        }

        #region 事件

        [Description("选择不同病人事件")]
        public event EventHandler ItemChanged;

        [Description("选择不同病人事件")]
        public event EventHandler ItemChangedFinish;

        [Description("下拉列表展开事件")]
        public event EventHandler DropDown;

        [Description("下拉列表关闭事件")]
        public event EventHandler DropDownClosed;

        [Description("当前日期改变")]
        public event EventHandler CurrentDateChanged;

        [Description("日期选择下拉列表展开事件")]
        public event EventHandler DateDropDown;

        [Description("日期选择下拉列表关闭事件")]
        public event EventHandler DateDropDownClosed;

        #endregion 事件

        #region 私有变量

        private DevExpress.XtraEditors.LabelControl lblOperDays0;
        private DevExpress.XtraEditors.LabelControl lblOperName0;
        private DevExpress.XtraEditors.LabelControl lblMonitor0;
        private DevExpress.XtraEditors.LabelControl lblAlergy0;
        private DevExpress.XtraEditors.LabelControl lblAbnormal0;
        private DevExpress.XtraEditors.LabelControl lblOperDate0;
        private DevExpress.XtraEditors.LabelControl lblNurse0;
        private DevExpress.XtraEditors.LabelControl lblDoctor0;
        private DevExpress.XtraEditors.LabelControl lblWarm0;
        private DevExpress.XtraEditors.LabelControl lblOperDays;
        private ComboBoxEdit cmbPatientID;
        private DevExpress.XtraEditors.LabelControl lblOperName;
        private DevExpress.XtraEditors.LabelControl lblOperDate;
        private DevExpress.XtraEditors.LabelControl lblMonitor;
        private DevExpress.XtraEditors.LabelControl lblNurse;
        private DevExpress.XtraEditors.LabelControl lblAlergy;
        private DevExpress.XtraEditors.LabelControl lblAbnormal;
        private DevExpress.XtraEditors.LabelControl lblDoctor;
        private DevExpress.XtraEditors.LabelControl lblWarm;
        private DevExpress.XtraEditors.LabelControl lblPatientID;

        private Dict.HisUserDataTable _doctorTable;
        private Dict.HisUserDataTable _nurseTable;

        /// <summary>
        /// 获取数据开始时间
        /// </summary>
        private DateTime startDateTime = DateTime.Now;
        private LabelControl lblUserName;
        private LabelControl lblPatientID0;
        private LabelControl labelControl1;
        private IcuBedSelect icuBedSelect1;

        /// <summary>
        /// 病人类型-默认为在院病人
        /// </summary>
        private PatientTypeEnum _patientType = PatientTypeEnum.InHospital;

        #endregion

        #region 属性
        /// 病人ID
        /// </summary>
        string PatientID
        {
            get
            {
                return this.cmbPatientID.Text;
            }
            set
            {
                this.lblPatientID0.Text = value;
                this.cmbPatientID.Text = value;
            }
        }

        /// <summary>
        /// 入科时间
        /// </summary>
        string Warm
        {
            get
            {
                return this.lblWarm0.Text;
            }
            set
            {
                this.lblWarm0.Text = value;
            }
        }

        /// <summary>
        /// 医生
        /// </summary>
        string Doctor
        {
            get
            {
                return this.lblDoctor0.Text;
            }
            set
            {
                this.lblDoctor0.Text = value;
            }
        }

        /// <summary>
        /// 护士
        /// </summary>
        string Nurse
        {
            get
            {
                return this.lblNurse0.Text;
            }
            set
            {
                this.lblNurse0.Text = value;
            }
        }

        /// <summary>
        /// 手术日期
        /// </summary>
        string ScheduleDate
        {
            get
            {
                return this.lblOperDate0.Text;
            }
            set
            {
                this.lblOperDate0.Text = value;
            }
        }

        /// <summary>
        /// 术后天数
        /// </summary>
        string DaysAfterOperation
        {
            get
            {
                return this.lblOperDays0.Text;
            }
            set
            {
                this.lblOperDays0.Text = value;
            }
        }

        /// <summary>
        /// 病人姓名
        /// </summary>
        string PatientName
        {
            get
            {
                return "";
            }
        }

        /// <summary>
        /// 阳性
        /// </summary>
        string Abnormal
        {
            get
            {
                return this.lblAbnormal0.Text;
            }
            set
            {
                this.lblAbnormal0.Text = value;
            }
        }

        /// <summary>
        /// 过敏史
        /// </summary>
        string Alergy
        {
            get
            {
                return this.lblAlergy0.Text;
            }
            set
            {
                this.lblAlergy0.Text = value;
            }
        }

        /// <summary>
        /// 设备
        /// </summary>
        string Monitor
        {
            get
            {
                return this.lblMonitor0.Text;
            }
            set
            {
                this.lblMonitor0.Text = value;
            }
        }

        /// <summary>
        /// 手术名称
        /// </summary>
        string OperName
        {
            get
            {
                return lblOperName0.Text;
            }
            set
            {
                lblOperName0.Text = value;
            }
        }

        /// <summary>
        /// 病人类型-默认为在院病人
        /// </summary>
        public PatientTypeEnum PatientType
        {
            get
            {
                return _patientType;
            }
            set
            {
                _patientType = value;
                if (_patientType == PatientTypeEnum.InHospital)
                {
                    icuBedSelect1.Enabled = true;
                    icuBedSelect1.SetStatus(true, "");
                }
                else
                {
                    icuBedSelect1.Enabled = false;
                    icuBedSelect1.SetStatus(false, this.CurrentPatient["NAME"].ToString());
                }
            }
        }

        #endregion

        #region 构造方法

        public BedHeadInformation()
        {
            InitializeComponent();
            //this.BackgroundImage = Resources.BedHeadInfoBack;
            try
            {
                _doctorTable = ExtendApplicationContext.Current.CodeTables["WIS_PERM_HIS_USER"] as Dict.HisUserDataTable;
                _nurseTable = ExtendApplicationContext.Current.CodeTables["WIS_PERM_HIS_USER"] as Dict.HisUserDataTable;
            }
            catch (Exception)
            {

                //throw;
            }            
        }

        #endregion

        #region 方法

        /// <summary>
        /// 增加病人ID选项
        /// </summary>
        /// <param name="patientid">病人ID</param>
        public void AddItem(string patientid)
        {
            this.cmbPatientID.Properties.Items.Add(patientid);
        }

        public void setNameBackImage()
        {
            //lblName0.Appearance.Image = Skin.Skin.GetNameBackImage();
        }

        public void SetBedItemIndex(int index)
        {
            icuBedSelect1.ItemIndex = index;
        }

        /// <summary>
        /// 清空选项
        /// </summary>
        public void Clear()
        {
            icuBedSelect1.Clear();
            this.cmbPatientID.Properties.Items.Clear();
        }

        /// <summary>
        /// 初始化组件
        /// </summary>
        private void InitializeComponent()
        {
            this.lblOperDays0 = new DevExpress.XtraEditors.LabelControl();
            this.lblOperName0 = new DevExpress.XtraEditors.LabelControl();
            this.lblMonitor0 = new DevExpress.XtraEditors.LabelControl();
            this.lblAlergy0 = new DevExpress.XtraEditors.LabelControl();
            this.lblAbnormal0 = new DevExpress.XtraEditors.LabelControl();
            this.lblOperDate0 = new DevExpress.XtraEditors.LabelControl();
            this.lblNurse0 = new DevExpress.XtraEditors.LabelControl();
            this.lblDoctor0 = new DevExpress.XtraEditors.LabelControl();
            this.lblWarm0 = new DevExpress.XtraEditors.LabelControl();
            this.lblOperDays = new DevExpress.XtraEditors.LabelControl();
            this.lblOperName = new DevExpress.XtraEditors.LabelControl();
            this.lblOperDate = new DevExpress.XtraEditors.LabelControl();
            this.lblMonitor = new DevExpress.XtraEditors.LabelControl();
            this.lblNurse = new DevExpress.XtraEditors.LabelControl();
            this.lblAlergy = new DevExpress.XtraEditors.LabelControl();
            this.lblAbnormal = new DevExpress.XtraEditors.LabelControl();
            this.lblDoctor = new DevExpress.XtraEditors.LabelControl();
            this.lblWarm = new DevExpress.XtraEditors.LabelControl();
            this.lblPatientID = new DevExpress.XtraEditors.LabelControl();
            this.cmbPatientID = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblUserName = new DevExpress.XtraEditors.LabelControl();
            this.lblPatientID0 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.icuBedSelect1 = new Wis.Anes.Framework.Controls.IcuBedSelect();
            this.SuspendLayout();
            // 
            // lblOperDays0
            // 
            this.lblOperDays0.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblOperDays0.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblOperDays0.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lblOperDays0.Appearance.Options.UseBackColor = true;
            this.lblOperDays0.Appearance.Options.UseFont = true;
            this.lblOperDays0.Appearance.Options.UseForeColor = true;
            this.lblOperDays0.Location = new System.Drawing.Point(1007, 32);
            this.lblOperDays0.Name = "lblOperDays0";
            this.lblOperDays0.Size = new System.Drawing.Size(64, 21);
            this.lblOperDays0.TabIndex = 50;
            this.lblOperDays0.Text = "手术天数";
            // 
            // lblOperName0
            // 
            this.lblOperName0.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblOperName0.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblOperName0.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lblOperName0.Appearance.Options.UseBackColor = true;
            this.lblOperName0.Appearance.Options.UseFont = true;
            this.lblOperName0.Appearance.Options.UseForeColor = true;
            this.lblOperName0.Location = new System.Drawing.Point(814, 32);
            this.lblOperName0.Name = "lblOperName0";
            this.lblOperName0.Size = new System.Drawing.Size(64, 21);
            this.lblOperName0.TabIndex = 49;
            this.lblOperName0.Text = "手术名称";
            // 
            // lblMonitor0
            // 
            this.lblMonitor0.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblMonitor0.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblMonitor0.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lblMonitor0.Appearance.Options.UseBackColor = true;
            this.lblMonitor0.Appearance.Options.UseFont = true;
            this.lblMonitor0.Appearance.Options.UseForeColor = true;
            this.lblMonitor0.Location = new System.Drawing.Point(1510, 12);
            this.lblMonitor0.Name = "lblMonitor0";
            this.lblMonitor0.Size = new System.Drawing.Size(32, 21);
            this.lblMonitor0.TabIndex = 48;
            this.lblMonitor0.Text = "设备";
            this.lblMonitor0.Visible = false;
            // 
            // lblAlergy0
            // 
            this.lblAlergy0.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblAlergy0.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAlergy0.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblAlergy0.Appearance.Options.UseBackColor = true;
            this.lblAlergy0.Appearance.Options.UseFont = true;
            this.lblAlergy0.Appearance.Options.UseForeColor = true;
            this.lblAlergy0.Location = new System.Drawing.Point(1349, 4);
            this.lblAlergy0.Name = "lblAlergy0";
            this.lblAlergy0.Size = new System.Drawing.Size(48, 21);
            this.lblAlergy0.TabIndex = 47;
            this.lblAlergy0.Text = "过敏史";
            // 
            // lblAbnormal0
            // 
            this.lblAbnormal0.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblAbnormal0.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAbnormal0.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lblAbnormal0.Appearance.Options.UseBackColor = true;
            this.lblAbnormal0.Appearance.Options.UseFont = true;
            this.lblAbnormal0.Appearance.Options.UseForeColor = true;
            this.lblAbnormal0.Location = new System.Drawing.Point(1438, 12);
            this.lblAbnormal0.Name = "lblAbnormal0";
            this.lblAbnormal0.Size = new System.Drawing.Size(32, 21);
            this.lblAbnormal0.TabIndex = 46;
            this.lblAbnormal0.Text = "阳性";
            this.lblAbnormal0.Visible = false;
            // 
            // lblOperDate0
            // 
            this.lblOperDate0.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblOperDate0.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblOperDate0.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lblOperDate0.Appearance.Options.UseBackColor = true;
            this.lblOperDate0.Appearance.Options.UseFont = true;
            this.lblOperDate0.Appearance.Options.UseForeColor = true;
            this.lblOperDate0.Location = new System.Drawing.Point(631, 32);
            this.lblOperDate0.Name = "lblOperDate0";
            this.lblOperDate0.Size = new System.Drawing.Size(153, 21);
            this.lblOperDate0.TabIndex = 44;
            this.lblOperDate0.Text = "2019-03-26 12:25:30";
            // 
            // lblNurse0
            // 
            this.lblNurse0.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblNurse0.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblNurse0.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lblNurse0.Appearance.Options.UseBackColor = true;
            this.lblNurse0.Appearance.Options.UseFont = true;
            this.lblNurse0.Appearance.Options.UseForeColor = true;
            this.lblNurse0.Location = new System.Drawing.Point(524, 32);
            this.lblNurse0.Name = "lblNurse0";
            this.lblNurse0.Size = new System.Drawing.Size(32, 21);
            this.lblNurse0.TabIndex = 43;
            this.lblNurse0.Text = "护士";
            // 
            // lblDoctor0
            // 
            this.lblDoctor0.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblDoctor0.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDoctor0.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lblDoctor0.Appearance.Options.UseBackColor = true;
            this.lblDoctor0.Appearance.Options.UseFont = true;
            this.lblDoctor0.Appearance.Options.UseForeColor = true;
            this.lblDoctor0.Location = new System.Drawing.Point(423, 32);
            this.lblDoctor0.Name = "lblDoctor0";
            this.lblDoctor0.Size = new System.Drawing.Size(32, 21);
            this.lblDoctor0.TabIndex = 42;
            this.lblDoctor0.Text = "医生";
            // 
            // lblWarm0
            // 
            this.lblWarm0.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblWarm0.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblWarm0.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lblWarm0.Appearance.Options.UseBackColor = true;
            this.lblWarm0.Appearance.Options.UseFont = true;
            this.lblWarm0.Appearance.Options.UseForeColor = true;
            this.lblWarm0.Location = new System.Drawing.Point(442, 32);
            this.lblWarm0.Name = "lblWarm0";
            this.lblWarm0.Size = new System.Drawing.Size(153, 21);
            this.lblWarm0.TabIndex = 41;
            this.lblWarm0.Text = "2019-03-26 12:25:30";
            // 
            // lblOperDays
            // 
            this.lblOperDays.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblOperDays.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblOperDays.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lblOperDays.Appearance.Options.UseBackColor = true;
            this.lblOperDays.Appearance.Options.UseFont = true;
            this.lblOperDays.Appearance.Options.UseForeColor = true;
            this.lblOperDays.Location = new System.Drawing.Point(1007, 4);
            this.lblOperDays.Name = "lblOperDays";
            this.lblOperDays.Size = new System.Drawing.Size(68, 21);
            this.lblOperDays.TabIndex = 40;
            this.lblOperDays.Text = "术后天数:";
            // 
            // lblOperName
            // 
            this.lblOperName.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblOperName.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblOperName.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lblOperName.Appearance.Options.UseBackColor = true;
            this.lblOperName.Appearance.Options.UseFont = true;
            this.lblOperName.Appearance.Options.UseForeColor = true;
            this.lblOperName.Location = new System.Drawing.Point(814, 4);
            this.lblOperName.Name = "lblOperName";
            this.lblOperName.Size = new System.Drawing.Size(68, 21);
            this.lblOperName.TabIndex = 38;
            this.lblOperName.Text = "手术名称:";
            // 
            // lblOperDate
            // 
            this.lblOperDate.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblOperDate.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblOperDate.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lblOperDate.Appearance.Options.UseBackColor = true;
            this.lblOperDate.Appearance.Options.UseFont = true;
            this.lblOperDate.Appearance.Options.UseForeColor = true;
            this.lblOperDate.Location = new System.Drawing.Point(631, 4);
            this.lblOperDate.Name = "lblOperDate";
            this.lblOperDate.Size = new System.Drawing.Size(68, 21);
            this.lblOperDate.TabIndex = 37;
            this.lblOperDate.Text = "手术日期:";
            // 
            // lblMonitor
            // 
            this.lblMonitor.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblMonitor.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblMonitor.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lblMonitor.Appearance.Options.UseBackColor = true;
            this.lblMonitor.Appearance.Options.UseFont = true;
            this.lblMonitor.Appearance.Options.UseForeColor = true;
            this.lblMonitor.Location = new System.Drawing.Point(1471, 12);
            this.lblMonitor.Name = "lblMonitor";
            this.lblMonitor.Size = new System.Drawing.Size(36, 21);
            this.lblMonitor.TabIndex = 36;
            this.lblMonitor.Text = "设备:";
            this.lblMonitor.Visible = false;
            // 
            // lblNurse
            // 
            this.lblNurse.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblNurse.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblNurse.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lblNurse.Appearance.Options.UseBackColor = true;
            this.lblNurse.Appearance.Options.UseFont = true;
            this.lblNurse.Appearance.Options.UseForeColor = true;
            this.lblNurse.Location = new System.Drawing.Point(524, 4);
            this.lblNurse.Name = "lblNurse";
            this.lblNurse.Size = new System.Drawing.Size(36, 21);
            this.lblNurse.TabIndex = 35;
            this.lblNurse.Text = "护士:";
            // 
            // lblAlergy
            // 
            this.lblAlergy.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblAlergy.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAlergy.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lblAlergy.Appearance.Options.UseBackColor = true;
            this.lblAlergy.Appearance.Options.UseFont = true;
            this.lblAlergy.Appearance.Options.UseForeColor = true;
            this.lblAlergy.Location = new System.Drawing.Point(1283, 4);
            this.lblAlergy.Name = "lblAlergy";
            this.lblAlergy.Size = new System.Drawing.Size(52, 21);
            this.lblAlergy.TabIndex = 34;
            this.lblAlergy.Text = "过敏史:";
            // 
            // lblAbnormal
            // 
            this.lblAbnormal.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblAbnormal.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAbnormal.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lblAbnormal.Appearance.Options.UseBackColor = true;
            this.lblAbnormal.Appearance.Options.UseFont = true;
            this.lblAbnormal.Appearance.Options.UseForeColor = true;
            this.lblAbnormal.Location = new System.Drawing.Point(1405, 12);
            this.lblAbnormal.Name = "lblAbnormal";
            this.lblAbnormal.Size = new System.Drawing.Size(36, 21);
            this.lblAbnormal.TabIndex = 33;
            this.lblAbnormal.Text = "阳性:";
            this.lblAbnormal.Visible = false;
            // 
            // lblDoctor
            // 
            this.lblDoctor.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblDoctor.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDoctor.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lblDoctor.Appearance.Options.UseBackColor = true;
            this.lblDoctor.Appearance.Options.UseFont = true;
            this.lblDoctor.Appearance.Options.UseForeColor = true;
            this.lblDoctor.Location = new System.Drawing.Point(423, 4);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(36, 21);
            this.lblDoctor.TabIndex = 31;
            this.lblDoctor.Text = "医生:";
            // 
            // lblWarm
            // 
            this.lblWarm.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblWarm.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblWarm.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lblWarm.Appearance.Options.UseBackColor = true;
            this.lblWarm.Appearance.Options.UseFont = true;
            this.lblWarm.Appearance.Options.UseForeColor = true;
            this.lblWarm.Location = new System.Drawing.Point(442, 4);
            this.lblWarm.Name = "lblWarm";
            this.lblWarm.Size = new System.Drawing.Size(68, 21);
            this.lblWarm.TabIndex = 30;
            this.lblWarm.Text = "入科日期:";
            // 
            // lblPatientID
            // 
            this.lblPatientID.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblPatientID.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblPatientID.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lblPatientID.Appearance.Options.UseBackColor = true;
            this.lblPatientID.Appearance.Options.UseFont = true;
            this.lblPatientID.Appearance.Options.UseForeColor = true;
            this.lblPatientID.Location = new System.Drawing.Point(297, 4);
            this.lblPatientID.Name = "lblPatientID";
            this.lblPatientID.Size = new System.Drawing.Size(53, 21);
            this.lblPatientID.TabIndex = 29;
            this.lblPatientID.Text = "患者ID:";
            // 
            // cmbPatientID
            // 
            this.cmbPatientID.Location = new System.Drawing.Point(0, 0);
            this.cmbPatientID.Name = "cmbPatientID";
            this.cmbPatientID.Size = new System.Drawing.Size(100, 21);
            this.cmbPatientID.TabIndex = 61;
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.Appearance.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.lblUserName.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(191)))));
            this.lblUserName.Appearance.Options.UseFont = true;
            this.lblUserName.Appearance.Options.UseForeColor = true;
            this.lblUserName.Location = new System.Drawing.Point(1569, 3);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(97, 26);
            this.lblUserName.TabIndex = 54;
            this.lblUserName.Text = "userName";
            // 
            // lblPatientID0
            // 
            this.lblPatientID0.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblPatientID0.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblPatientID0.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lblPatientID0.Appearance.Options.UseBackColor = true;
            this.lblPatientID0.Appearance.Options.UseFont = true;
            this.lblPatientID0.Appearance.Options.UseForeColor = true;
            this.lblPatientID0.Location = new System.Drawing.Point(297, 32);
            this.lblPatientID0.Name = "lblPatientID0";
            this.lblPatientID0.Size = new System.Drawing.Size(17, 21);
            this.lblPatientID0.TabIndex = 56;
            this.lblPatientID0.Text = "ID";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(287, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(2, 58);
            this.labelControl1.TabIndex = 59;
            // 
            // icuBedSelect1
            // 
            this.icuBedSelect1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.icuBedSelect1.CurrentPatient = null;
            this.icuBedSelect1.DropDownHeight = 300;
            this.icuBedSelect1.DropDownWidth = 500;
            this.icuBedSelect1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.icuBedSelect1.ItemIndex = -1;
            this.icuBedSelect1.Location = new System.Drawing.Point(0, 0);
            this.icuBedSelect1.Name = "icuBedSelect1";
            this.icuBedSelect1.Patients = null;
            this.icuBedSelect1.Size = new System.Drawing.Size(282, 58);
            this.icuBedSelect1.TabIndex = 60;
            // 
            // BedHeadInformation
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Controls.Add(this.icuBedSelect1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lblPatientID0);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblOperName0);
            this.Controls.Add(this.lblMonitor0);
            this.Controls.Add(this.lblOperDate0);
            this.Controls.Add(this.lblNurse0);
            this.Controls.Add(this.lblDoctor0);
            this.Controls.Add(this.cmbPatientID);
            this.Controls.Add(this.lblOperName);
            this.Controls.Add(this.lblOperDate);
            this.Controls.Add(this.lblMonitor);
            this.Controls.Add(this.lblNurse);
            this.Controls.Add(this.lblDoctor);
            this.Controls.Add(this.lblPatientID);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "BedHeadInformation";
            this.Size = new System.Drawing.Size(1663, 58);
            this.Load += new System.EventHandler(this.BedHeadInformation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /// <summary>
        /// 控件大小改变事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            icuBedSelect1.DropDownWidth = this.Width ;
            lblUserName.Left = this.Width - 187;
            lblUserName.Top = 13;
        }

        public void SetUserName(string userName)
        {
            lblUserName.Text = userName;
        }

        /// <summary>
        /// 病人改变事件
        /// </summary>
        /// <param name="sender">事件触发者</param>
        /// <param name="e">事件参数</param>
        private void Item_Changed(object sender, EventArgs e)
        {
            //通过床号改变病人
            CurrentPatient = icuBedSelect1.CurrentPatient;
            if (ItemChanged != null)
                ItemChanged(this, new EventArgs());
        }


        /// <summary>
        /// 病人改变事件结束
        /// </summary>
        /// <param name="sender">事件触发者</param>
        /// <param name="e">事件参数</param>
        private void Item_ChangedFinish(object sender, EventArgs e)
        {
            if (ItemChangedFinish != null)
            {
                ItemChangedFinish(this, new EventArgs());
            }
        }

        public void RefreshBedHeadInfo(DataRow patientRow)
        {          
            PatientID = patientRow["PAT_ID"].ToString();

            if (PatientType == PatientTypeEnum.InHospital)
            {
                AnesInformations.OperationMasterDataTable operationMasterDataTable = AnesthesiaSheetProxy.GetOperationMaster(patientRow["PAT_ID"].ToString(), Convert.ToDecimal(patientRow["VISIT_ID"].ToString()), Convert.ToDecimal(patientRow["OPER_ID"].ToString()));                
                AnesInformations.OperationMasterRow operationMasterRow = null;

                if (operationMasterDataTable.Rows.Count >= 1)
                {
                    operationMasterRow = (AnesInformations.OperationMasterRow)operationMasterDataTable.Rows[0];
                }
                else
                {
                    return;
                }

                if (!operationMasterRow.IsSURGEONNull())
                    Doctor = GetHisUserName(operationMasterRow.SURGEON, this._doctorTable);

                if (!operationMasterRow.IsFIRST_OPER_NURSENull())
                    Nurse = GetHisUserName(operationMasterRow.FIRST_OPER_NURSE, this._nurseTable);                
                
                if (patientRow["START_DATE_TIME"] == System.DBNull.Value)
                {
                    ScheduleDate = DateTime.MinValue.ToString();
                }
                else
                {
                    ScheduleDate = patientRow["START_DATE_TIME"].ToString();
                }
            }
            else
            {
                Doctor = string.Empty;
                Nurse = string.Empty;
                DaysAfterOperation = string.Empty;
                ScheduleDate = string.Empty;
            }
        }

        private void LoadPatients(DataTable patients)
        {
            if (patients == null)
                return;
            Clear();
            icuBedSelect1.Patients = _patients;
        }        
        #endregion

        #region 控件事件

        /// <summary>
        /// 病人ID下拉框按键事件
        /// </summary>
        /// <param name="sender">事件触发者</param>
        /// <param name="e">事件参数</param>
        private void cmbPatientID_KeyDown(object sender, KeyEventArgs e)
        {
            ///回车键触发
            if (e.KeyCode == Keys.Return)
            {
                Item_Changed(sender, e);
            }
        }

        /// <summary>
        /// 控件装载事件
        /// </summary>
        /// <param name="sender">事件触发者</param>
        /// <param name="e">事件参数</param>
        private void BedHeadInformation_Load(object sender, EventArgs e)
        {
            ///设置双缓存
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw, true);

            ///添加事件控制
            this.icuBedSelect1.ItemChanged += new EventHandler(Item_Changed);
            this.icuBedSelect1.DropDown += new EventHandler(
                delegate(object sender1, EventArgs e1)
                {
                    if (DropDown != null)
                        DropDown(sender1, e1);
                }
            );
            this.icuBedSelect1.DropDownClosed += new EventHandler(
                delegate(object sender2, EventArgs e2)
                {
                    if (DropDownClosed != null)
                        DropDownClosed(sender2, e2);
                }
            );
            this.icuBedSelect1.ItemChangedFinish += new EventHandler(Item_ChangedFinish);
            cmbPatientID.SelectedIndexChanged += new EventHandler(Item_Changed);
        }

        #endregion 控件事件


        #region IRender 成员

        public void Rendering(object data)
        {
           DataTable resultData = data as DataTable;
            if (resultData == null)
                return;
            Patients = resultData;
            //选择默认患者
            if (Patients.Rows.Count > 0)
            {

                if (CurrentPatient == null ||
                    (CurrentPatient != null && Patients.Select("PAT_ID='" + CurrentPatient["PAT_ID"].ToString() + "'").Length == 0)
                    || (CurrentPatient != null && Patients.Select("PAT_ID='" + CurrentPatient["PAT_ID"].ToString() + "' AND BED_NO='" + CurrentPatient["BED_NO"].ToString() + "'").Length == 0))
                {
                    //ApplicationManager.CurrentPatient = Patients[CalculateCurrentIndex(ClientDataModule.PatientId, Patients)];
                    //CurrentPatient = ApplicationManager.CurrentPatient;
                    Refresh();
                }
            }

        }

        //static int CalculateCurrentIndex(string patiendID, DataTable patients)
        //{
        //    if (string.IsNullOrEmpty(patiendID))
        //        return 0;
        //    for (int idx = 0; idx < patients.Rows.Count; idx++)
        //    {
        //        if (patients[idx].PATIENT_ID == patiendID)
        //        {
        //            return idx;
        //        }
        //    }
        //    return 0;
        //}

        #endregion

        private string GetHisUserName(string userInfo, Dict.HisUserDataTable userTable)
        {
            Dict.HisUserRow row = userTable.FindByUSER_ID(userInfo);

            if (row != null)
            {
                return row.USER_NAME;
            }
            else
            {
                return userInfo;
            }
        }
    }
}
