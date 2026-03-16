using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Wis.Anes.Framework.Controls;
using Wis.Anes.Framework.Utilities;
using System.Diagnostics;
using Wis.Anes.Framework;
using Wis.Anes.Framework.Controls.Base;
using ApplicationFramework;

namespace Wis.Anes.Framework.Controls.Base
{
    /// <summary>
    /// 基础控件
    /// </summary>
    public partial class BaseControl : DevExpress.XtraEditors.XtraUserControl, IView
    {
        protected string PatientID
        {
            get { return PatientRow["PAT_ID"].ToString(); }
        }
        protected decimal VisitID
        {
            get { return Convert.ToDecimal(PatientRow["VISIT_ID"].ToString()); }
        }
        protected decimal DepID
        {
            get { return Convert.ToDecimal(PatientRow["DEP_ID"].ToString()); }
        }


        #region 构造方法

        /// <summary>
        /// 构造方法
        /// </summary>
        public BaseControl()
        {
            InitializeComponent();
            this.ControlAdded += new ControlEventHandler(BaseControl_ControlAdded);     
        }

        public BaseControl(DataRow patientRow,string title):this()
        {
            _patientRow = patientRow;
            Title = title;
        }

        public BaseControl(DataRow patientRow, string title,string showCode):this(patientRow, title)
        {
            _showCode = showCode;
        }

        #endregion

        #region 变量


        /// <summary>
        /// 病人信息
        /// </summary>
        DataRow _patientRow;
        /// <summary>
        /// 病人信息
        /// </summary>
        public DataRow PatientRow
        {
            get
            {
                return _patientRow;
            }
            set
            {
                _patientRow = value;
               
            }
        }


        /// <summary>
        /// 指示数据是否已经改变，用于用户强制控制数据是否改变，默认为false，如果为true则退出时强制保存；
        /// </summary>
        private bool _dataChanged;
        /// <summary>
        /// 指示数据是否已经改变，用于用户强制控制数据是否改变，默认为false，如果为true则退出时强制保存；
        /// </summary>
        protected bool DataChanged
        {
            get
            {
                return _dataChanged;
            }
            set
            {
                _dataChanged = value;
            }
        }


        /// <summary>
        /// 主表-改变会导致退出时保存；
        /// </summary>
        DataTable _mainTable;
        protected DataTable MainTable
        {
            get { return _mainTable; }
            set { _mainTable = value; }
        }

        List<BaseControl> _baseControlList = new List<BaseControl>();

        /// <summary>
        /// 需要控制的表集合-任何一个表的改变都会导致退出时保存；
        /// </summary>
        DataSet _dataSet = new DataSet();
        protected DataSet MainDataSet
        {
            get { return _dataSet; }
        }

        /// <summary>
        /// 标题
        /// </summary>
        string _title = "无标题";
        /// <summary>
        /// 控件标题
        /// </summary>
        [Description("控件标题")]
        public string Title
        {
            get
            {                
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        /// <summary>
        /// 表示
        /// </summary>
        string _showCode = "ZTHLJM";
        protected string ShowCode
        {
            get { return _showCode; }
        }
        /// <summary>
        /// 科室代码
        /// </summary>
        string _wardCode;
        /// <summary>
        /// 科室代码
        /// </summary>
        public string WardCode
        {
            get
            {
                return _wardCode;
            }
            set
            {
                _wardCode = value;
            }
        }


        /// <summary>
        /// 权限标志，为真拥有权限，为假没有权限
        /// </summary>
        bool _permissionsSign = true;

        /// <summary>
        /// 权限标志，为真拥有权限，为假没有权限
        /// </summary>
        protected bool PermissionsSign
        {
            get
            {
                return _permissionsSign;
            }
        }

        bool _isLoadOnceCalled;

        #endregion 变量

        #region 方法

        private void CheckPermissions()
        {
            _permissionsSign = AccessControl.CheckPermission(GetType().FullName);
        }

        private void BaseControl_Load(object sender, EventArgs e)
        {
            CheckPermissions();
            //if (PatientRow == null)
            //    return;
            LoadDataOnce();
            _isLoadOnceCalled = true;
            LoadData();
        }

        public void BaseControl_ControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control is BaseControl)
            {
                _baseControlList.Add(e.Control as BaseControl);
            }
        }

        /// <summary>
        ///  加载界面所需数据
        /// </summary>
        /// <returns>
        /// 返回主数据表,如果没有返回空
        /// </returns>
        protected virtual void LoadData()
        {
        }

        /// <summary>
        ///  加载界面所需数据只加载一次
        /// </summary>
        protected virtual void LoadDataOnce()
        {

        }
        /// <summary>
        /// 保存数据
        /// </summary>
        protected virtual void SaveData()
        {
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        public virtual void RefreshData()
        {
        }

        /// <summary>
        /// 更改实体时激活此方法
        /// </summary>
        public virtual void Notify(bool isForce)
        {
            if (isForce || PatientRow != ApplicationManager<DataRow>.CurrentData)
            {
                try
                {
                    CheckHasDataChangedThenSaveData();
                    PatientRow = ApplicationManager<DataRow>.CurrentData;
                    if (_isLoadOnceCalled)
                    {
                        LoadData();
                        NotifyChild(isForce);
                    }
                }
                catch (Exception ex)
                {
                    Sundries.MessageBox(ex.Message, MessageBoxIcon.Error);
                }
            }
        }

        public void CheckHasDataChangedThenSaveData()
        {
            bool isDataChanged = (DataChanged || (MainDataSet.GetChanges() !=null &&MainDataSet.GetChanges().Tables.Count > 0) || (MainTable != null && MainTable.GetChanges() != null && MainTable.GetChanges().Rows.Count > 0));
            if (isDataChanged)
            {
                DoSave();
            }
        }

        private void DoSave()
        {
            if (Sundries.MessageBox("数据已改变，是否保存？", Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SaveData();
            }
        }

        private void NotifyChild(bool isForce)
        {
            foreach (BaseControl ctl in _baseControlList)
            {
                ctl.Notify(isForce);
            }
        }
        /// <summary>
        /// 解决微软自动更新输入法为全角BUG
        /// </summary>
        /// <param name="e"></param>
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            IntPtr HIme = WinAPI.ImmGetContext(this.Handle);
            if (WinAPI.ImmGetOpenStatus(HIme))  //如果输入法处于打开状态
            {
                int iMode = 0;
                int iSentence = 0;
                bool bSuccess = WinAPI.ImmGetConversionStatus(HIme, ref iMode, ref iSentence);  //检索输入法信息
                if (bSuccess)
                {
                    if ((iMode & WinAPI.IME_CMODE_FULLSHAPE) > 0)   //如果是全角
                        WinAPI.ImmSimulateHotKey(this.Handle,WinAPI.IME_CHOTKEY_SHAPE_TOGGLE);  //转换成半角
                }

            }
        } 

        #endregion


        /// <summary>
        /// 生成动态列
        /// </summary>
        /// <param name="title"></param>
        /// <param name="fieldName"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        protected DataGridViewColumn GenerateColumn(string title, string fieldName, int width)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = title;
            column.DataPropertyName = fieldName;
            column.Name = fieldName;
            column.Width = width;
            return column;
        }

        #region IView 成员
        private bool _isFirstLoad = true;
        public bool IsFirstLoading
        {
            get
            {
                return _isFirstLoad;
            }
            set
            {
                _isFirstLoad = value; ;
            }
        }

        #endregion
        #region 类型转换
        protected decimal ToDecimal(object value)
        {
            decimal outValue = 0;
            decimal.TryParse(value.ToString(), out outValue);
            return outValue;
        }
        protected double ToDouble(object value)
        {
            double outValue = 0;
            double.TryParse(value.ToString(), out outValue);
            return outValue;
        }
        #endregion

        #region 获取控件
        public List<T> GetControls<T>() where T : Control
        {
            List<T> controls = new List<T>();
            GetControls<T>(this, controls);
            return controls;
        }
        private void GetControls<T>(Control parent, List<T> list) where T : Control
        {
            //if (parent.GetType().Equals(typeof(T)))
            if (parent is T)
            {
                list.Add((T)parent);
            }
            //else
            {
                foreach (Control control in parent.Controls)
                {
                    GetControls<T>(control, list);
                }
            }
        }
        #endregion

    }
}
