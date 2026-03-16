
/*----------------------------------------------------------------
      // Copyright (C) 2008 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：MedReportDesignFrm.cs
      // 文件功能描述：报表设置控件
      //
      // 
      // 创建标识：于占涛-2008-10-20
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Com.MedicalSystem.Common.Utilities;
using System.Collections;
using System.Reflection;

namespace Com.ICIS.Common.Controls
{
    public partial class MedReportDesignControl :AnesBand
    {
        #region 自定义事件
        [Description("选中组件后触发该事件")]
        public event EventHandler SelectedControlEvent;
        [Description("数据发生变化触发该事件")]
        public event EventHandler DataChangedEvent;

        #endregion

        #region  私有变量
        /// <summary>
        /// 报表名称
        /// </summary>
        private string _reportName = string.Empty;
        /// <summary>
        /// 容器配置表名称
        /// </summary>
        private string _reportSettingsTableName = string.Empty;
        /// <summary>
        /// TextBox列表配置表名称
        /// </summary>         
        private string _textBoxListSettingsTableName = string.Empty;
        private string _customControlTableName = string.Empty;
        /// <summary>
        /// RichTextBox列表配置表名称
        /// </summary>
        private string _richTextBoxListSettingsTableName = string.Empty;
        /// <summary>
        /// DataGridView列表配置表名称
        /// </summary>
        private string _dataGridViewListSettingsTableName = string.Empty;
        /// <summary>
        /// Lable列表配置表名称
        /// </summary>         
        private string _labelListSettingsTableName = string.Empty;
        /// <summary>
        /// Panel列表配置表名称
        /// </summary>
        private string _panelListSettingsTableName = string.Empty;
        /// <summary>
        /// 是否是设计模式
        /// </summary>
        private bool _isDesignMode = false;
        /// <summary>
        /// 布局等是否发生过变化
        /// </summary>
        private bool _isChanged = false;
        /// <summary>
        /// 数据内容是否发生过变化
        /// </summary>
        private bool _dataIsChanged = false;
        ///// <summary>
        ///// 是否画边框
        ///// </summary>
        //private bool _drawBorder = true;
        /// <summary>
        /// 是否是修改数据模式
        /// </summary>
        private bool _updateMode = false;
        /// <summary>
        /// 是否读取容器大小位置
        /// </summary>
        private bool _loadReportSize = false;
        /// <summary>
        /// 是否是画矩形选择框
        /// </summary>    
        private bool _isDrawSelect = false;
        private Point _mouseOffset;
        private Point _drawOriginPoint;
        private DataSet _settingsDS = new DataSet("SettingsDS");
        private DataTable _reportSettingsDt = new DataTable();
        private DataTable _textBoxListSettingsDt = new DataTable();
        private DataTable _customControlTable = new DataTable();
        private DataTable _richTextBoxListSettingsDt = new DataTable();
        private DataTable _dataGridViewListSettingsDt = new DataTable();
        private DataTable _labelListSettingsDt = new DataTable();
        private DataTable _panelListSettingsDt = new DataTable();
        private Hashtable _bindTablesForKey = new Hashtable();
        private Hashtable _bindListTables = new Hashtable();
        private Hashtable _celerityInputTables = new Hashtable();
        private List<Control> _selectControls = new List<Control>();
        private Rectangle _rect = new Rectangle();
        #endregion

        #region 私有常量

        private const char LISTSEPARATOR = ',';//'ぁ';

        #endregion

        #region 属性

        public Control SelectControl
        {
            get
            {
                if (_selectControls != null && _selectControls.Count > 0)
                {
                    return _selectControls[0];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _selectControls.Clear();
                _selectControls.Add(value);
            }
        }

        /// <summary>
        /// 布局设置是否发生过变化
        /// </summary>
        [Browsable(false)]
        public bool IsChanged
        {
            get
            {
                return _isChanged;
            }
            set
            {
                _isChanged = value;
            }
        }
        /// <summary>
        /// 数据内容是否发生过变化
        /// </summary>
        public bool DataIsChanged
        {
            get
            {
                return _dataIsChanged;
            }
        }

        /// <summary>
        /// 是否是更新数据模式
        /// </summary>
        [Description("是否是更新数据模式"), Category("行为")]
        public bool UpdateMode
        {
            set
            {
                _updateMode = value;
            }
            get
            {
                return _updateMode;
            }
        }

        private string _configFileName;
        public string ConfigFileName
        {
            get
            {
                return _configFileName;
            }
            set
            {
                _configFileName = value;
                //if (_configFileName != null)
                //{
                //    RefreshSettings();
                //}
            }
        }

        /// <summary>
        /// 报表设置名称
        /// </summary>
        [Description("报表设置名称"), Category("行为")]
        public string ReportName
        {
            set
            {
                _reportName = value;
                _reportSettingsTableName = _reportName + "ReportSettingsTable";
                _textBoxListSettingsTableName = _reportName + "TextBoxListSettingsTable";
                _customControlTableName = _reportName + "_customControlTable";
                _richTextBoxListSettingsTableName = _reportName + "RichTextBoxListSettingsTable";
                _dataGridViewListSettingsTableName = _reportName + "DataGridViewListSettingsTable";
                _labelListSettingsTableName = _reportName + "LabelListSettingsTable";
                _panelListSettingsTableName = _reportName + "PanelListSettingsTable";

                _reportSettingsDt.TableName = _reportSettingsTableName;
                _textBoxListSettingsDt.TableName = _textBoxListSettingsTableName;
                _customControlTable.TableName = _customControlTableName;
                _richTextBoxListSettingsDt.TableName = _richTextBoxListSettingsTableName;
                _dataGridViewListSettingsDt.TableName = _dataGridViewListSettingsTableName;
                _labelListSettingsDt.TableName = _labelListSettingsTableName;
                _panelListSettingsDt.TableName = _panelListSettingsTableName;
            }
            get
            {
                return _reportName;
            }
        }

        /// <summary>
        /// 是否是设计模式
        /// </summary>
        [DefaultValue(false), Description("是否是设计模式"), Category("行为")]
        public bool IsDesignMode
        {
            set
            {
                _isDesignMode = value;
                this.AllowDrop = _isDesignMode;
                if (value)
                {
                    foreach (Control Control1 in this.Controls)
                    {
                        AddControlDesignModeEvent(Control1);
                    }
                }
                else
                {
                    foreach (Control Control1 in this.Controls)
                    {
                        RemoveControlDesignModeEvent(Control1);
                    }
                }
            }
            get
            {
                return _isDesignMode;
            }
        }

        /// <summary>
        /// 是否读取报表宽高边距配置
        /// </summary>
        [DefaultValue(false), Description("是否读取报表宽高边距配置"), Category("行为")]
        public bool LoadReportSize
        {
            set
            {
                _loadReportSize = value;
            }
            get
            {
                return _loadReportSize;
            }
        }

        /// <summary>
        /// 根据主键绑定数据列表
        /// </summary>
        [Browsable(false)]
        public Hashtable BindTablesForKey
        {
            get
            {
                return _bindTablesForKey;
            }
        }

        /// <summary>
        /// 绑定全部数据列表
        /// </summary>
        [Browsable(false)]
        public Hashtable BindListTables
        {
            get
            {
                return _bindListTables;
            }
        }

        public List<Control> SelectControls
        {
            get
            {
                return _selectControls;
            }
        }

        #endregion

        #region 构造函数

        public MedReportDesignControl() : this(null) { }
        public MedReportDesignControl(string configFileName)
        {
            if (!string.IsNullOrEmpty(configFileName))
            {
                _configFileName = configFileName;
            }
            InitializeComponent();
            //InitTable();
            //if (!string.IsNullOrEmpty(configFileName))
            //{
            //    RefreshSettings();
            //}
        }

        #endregion

        #region 私有方法
        private void InitTable()
        {
            #region 配置表初始化

            _reportSettingsDt.Columns.Add("DrawBorder");
            _reportSettingsDt.Columns.Add("Width");
            _reportSettingsDt.Columns.Add("Height");
            _reportSettingsDt.Columns.Add("Top");
            _reportSettingsDt.Columns.Add("Left");
            _reportSettingsDt.Columns.Add("BorderColor");

            _textBoxListSettingsDt.Columns.Add("Width");
            _textBoxListSettingsDt.Columns.Add("Height");
            _textBoxListSettingsDt.Columns.Add("Top");
            _textBoxListSettingsDt.Columns.Add("Left");
            _textBoxListSettingsDt.Columns.Add("ForeColor");
            //_textBoxListSettingsDt.Columns.Add("ReadOnly");
            _textBoxListSettingsDt.Columns.Add("Text");
            _textBoxListSettingsDt.Columns.Add("BackColor");
            _textBoxListSettingsDt.Columns.Add("Font");
            _textBoxListSettingsDt.Columns.Add("FontStyle");
            _textBoxListSettingsDt.Columns.Add("BindTableName");
            _textBoxListSettingsDt.Columns.Add("BindFieldName");
            _textBoxListSettingsDt.Columns.Add("CelerityInputTableName");
            _textBoxListSettingsDt.Columns.Add("CelerityInputValueColumnName");
            _textBoxListSettingsDt.Columns.Add("CelerityInputCodeColumnName");
            _textBoxListSettingsDt.Columns.Add("CelerityInputSqlWhere");
            _textBoxListSettingsDt.Columns.Add("BindList");
            _textBoxListSettingsDt.Columns.Add("Format");
            _textBoxListSettingsDt.Columns.Add("MultiSign");
            _textBoxListSettingsDt.Columns.Add("Multiline");

            _customControlTable.Columns.Add("Width");
            _customControlTable.Columns.Add("Height");
            _customControlTable.Columns.Add("Top");
            _customControlTable.Columns.Add("Left");
            _customControlTable.Columns.Add("ForeColor");
            //_customControlTable.Columns.Add("ReadOnly");
            _customControlTable.Columns.Add("Text");
            _customControlTable.Columns.Add("BackColor");
            _customControlTable.Columns.Add("Font");
            _customControlTable.Columns.Add("FontStyle");
            _customControlTable.Columns.Add("BindTableName");
            _customControlTable.Columns.Add("BindFieldName");
            _customControlTable.Columns.Add("CelerityInputTableName");
            _customControlTable.Columns.Add("CelerityInputValueColumnName");
            _customControlTable.Columns.Add("CelerityInputCodeColumnName");
            _customControlTable.Columns.Add("CelerityInputSqlWhere");
            _customControlTable.Columns.Add("BindList");
            _customControlTable.Columns.Add("Format");
            _customControlTable.Columns.Add("MultiSign");
            _customControlTable.Columns.Add("Multiline");

            _richTextBoxListSettingsDt.Columns.Add("Width");
            _richTextBoxListSettingsDt.Columns.Add("Height");
            _richTextBoxListSettingsDt.Columns.Add("Top");
            _richTextBoxListSettingsDt.Columns.Add("Left");
            _richTextBoxListSettingsDt.Columns.Add("ForeColor");
            _richTextBoxListSettingsDt.Columns.Add("Text");
            _richTextBoxListSettingsDt.Columns.Add("Font");
            _richTextBoxListSettingsDt.Columns.Add("FontStyle");

            _labelListSettingsDt.Columns.Add("Width");
            _labelListSettingsDt.Columns.Add("Height");
            _labelListSettingsDt.Columns.Add("Top");
            _labelListSettingsDt.Columns.Add("Left");
            _labelListSettingsDt.Columns.Add("ForeColor");
            _labelListSettingsDt.Columns.Add("Text");
            _labelListSettingsDt.Columns.Add("BackColor");
            _labelListSettingsDt.Columns.Add("Font");
            _labelListSettingsDt.Columns.Add("FontStyle");
            _labelListSettingsDt.Columns.Add("Name");

            _panelListSettingsDt.Columns.Add("Width");
            _panelListSettingsDt.Columns.Add("Height");
            _panelListSettingsDt.Columns.Add("Top");
            _panelListSettingsDt.Columns.Add("Left");
            _panelListSettingsDt.Columns.Add("BackColor");

            _dataGridViewListSettingsDt.Columns.Add("Width");
            _dataGridViewListSettingsDt.Columns.Add("Height");
            _dataGridViewListSettingsDt.Columns.Add("Top");
            _dataGridViewListSettingsDt.Columns.Add("Left");
            _dataGridViewListSettingsDt.Columns.Add("Columns");
            _dataGridViewListSettingsDt.Columns.Add("RowCount");
            _dataGridViewListSettingsDt.Columns.Add("TableName");
            _dataGridViewListSettingsDt.Columns.Add("Font");
            _dataGridViewListSettingsDt.Columns.Add("FontStyle");

            #endregion
        }

        private void InitControl(Com.MedicalSystem.Icu.DataSetModel.CareDocs.MED_DOCUMENT_DESIGN_MAINRow main, Com.MedicalSystem.Icu.DataSetModel.CareDocs.MED_DOCUMENT_DESIGN_DETAILDataTable detail)
        {
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                if (this.Controls[i].Name == "pan5")
                {
                    continue;
                }
                else
                {
                    this.Controls.Remove(Controls[i]);
                }
            }
            //this.Controls.Clear();

            #region 读取容器配置并设置容器

            if (main != null)
            {
                if (_loadReportSize)
                {
                    this.Width = (int)main.WEIDTH;
                    this.Height = (int)main.HEIGHT;
                    //if (int.TryParse(main.Rows[0]["Top"].ToString().Trim(), out Result))
                    //{
                    //    this.Top = Result;
                    //}
                    //if (int.TryParse(main.Rows[0]["Left"].ToString().Trim(), out Result))
                    //{
                    //    this.Left = Result;
                    //}
                    //this.BorderColor = AssemblyHelper.ColorFromString(_reportSettingsDt.Rows[0]["BorderColor"].ToString().Trim());
                }
                //this.DrawBorder = bool.Parse(_reportSettingsDt.Rows[0]["DrawBorder"].ToString().Trim());
            }
            #endregion

            foreach (Com.MedicalSystem.Icu.DataSetModel.CareDocs.MED_DOCUMENT_DESIGN_DETAILRow row in detail.Rows)
            {
                if (row.CONTROL_TYPE == "MedLabel")
                {
                    MedLabel MedLabel1 = new MedLabel();
                    MedLabel1.Left = (int)row.LEFT;
                    MedLabel1.Top = (int)row.TOP;
                    MedLabel1.Width = (int)row.WIDTH;
                    MedLabel1.Height = (int)row.HEIGHT;
                    MedLabel1.Text = row.TEXT;
                    MedLabel1.ForeColor = AssemblyHelper.ColorFromString(row.FORE_COLOR);
                    MedLabel1.BackColor = AssemblyHelper.ColorFromString(row.BACKCOLOR);
                    MedLabel1.Font = AssemblyHelper.ConvertStringToFont(row.FONT, row.FONT_STYLE);
                    if (_isDesignMode)
                    {
                        AddControlDesignModeEvent(MedLabel1);
                    }
                    else
                    {
                        this.MouseDown -= new MouseEventHandler(MedReportDesignControl_MouseDown);
                        this.MouseMove -= new MouseEventHandler(MedReportDesignControl_MouseMove);
                        this.MouseUp -= new MouseEventHandler(MedReportDesignControl_MouseUp);
                    }
                    this.Controls.Add(MedLabel1);
                }
                else if (row.CONTROL_TYPE == "MedTextBox")
                {
                    MedTextBox MedTextBox1 = new MedTextBox();
                    MedTextBox1.Left = (int)row.LEFT;
                    MedTextBox1.Top = (int)row.TOP;
                    MedTextBox1.Width = (int)row.WIDTH;
                    MedTextBox1.Height = (int)row.HEIGHT;
                    MedTextBox1.Text = row.TEXT;
                    MedTextBox1.Name = MedTextBox1.Text;
                    MedTextBox1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;// BorderStyle.None;
                    MedTextBox1.ForeColor = AssemblyHelper.ColorFromString(row.FORE_COLOR);
                    MedTextBox1.BackColor = AssemblyHelper.ColorFromString(row.BACKCOLOR);
                    MedTextBox1.BindTableName = row.BIND_TABLE_NAME;
                    if (MedTextBox1.BindTableName.Length > 0)
                    {
                        if (!_bindTablesForKey.ContainsKey(MedTextBox1.BindTableName))
                        {
                            _bindTablesForKey.Add(MedTextBox1.BindTableName, null);
                        }
                    }
                    MedTextBox1.BindFieldName = row.BIND_FIELD_NAME;
                    MedTextBox1.LockInput = !_updateMode;
                    MedTextBox1.Font = AssemblyHelper.ConvertStringToFont(row.FONT, row.FONT_STYLE);
                    if (_isDesignMode)
                    {
                        AddControlDesignModeEvent(MedTextBox1);
                    }
                    else
                    {
                        this.MouseDown -= new MouseEventHandler(MedReportDesignControl_MouseDown);
                        this.MouseMove -= new MouseEventHandler(MedReportDesignControl_MouseMove);
                        this.MouseUp -= new MouseEventHandler(MedReportDesignControl_MouseUp);
                        if (_updateMode)
                        {
                            MedTextBox1.Click += new EventHandler(Control_Click);
                            MedTextBox1.KeyDown += new KeyEventHandler(MedTextBox1_KeyDown);
                        }
                    }
                    MedTextBox1.CelerityInputTableName = row.CELERITY_INPUT_TABLE_NAME;
                    if (MedTextBox1.CelerityInputTableName.Length > 0)
                    {
                        if (!_celerityInputTables.ContainsKey(MedTextBox1.CelerityInputTableName))
                        {
                            _celerityInputTables.Add(MedTextBox1.CelerityInputTableName, null);
                        }
                    }
                    MedTextBox1.CelerityInputValueColumnName = row.CELERITY_INPUT_VALUE_COLUMN;
                    MedTextBox1.CelerityInputCodeColumnName = row.CELERITY_INPUT_CODE_COMUMN;
                    //MedTextBox1.CelerityInputSqlWhere = TextBoxSettingsRow["CelerityInputSqlWhere"].ToString().Trim();
                    MedTextBox1.BindList = row.BIND_LIST;
                    //MedTextBox1.Format = TextBoxSettingsRow["Format"].ToString().Trim();
                    //MedTextBox1.MultiSign = bool.Parse(TextBoxSettingsRow["MultiSign"].ToString().Trim());
                    //MedTextBox1.Multiline = bool.Parse(TextBoxSettingsRow["Multiline"].ToString().Trim());
                    MedTextBox1.OldForeColor = MedTextBox1.ForeColor;
                    this.Controls.Add(MedTextBox1);
                }
                else if (row.CONTROL_TYPE == "Panel")
                {
                    Panel panel1 = new Panel();
                    panel1.Left = (int)row.LEFT;
                    panel1.Top = (int)row.TOP;
                    panel1.Width = (int)row.WIDTH;
                    panel1.Height = (int)row.HEIGHT;
                    panel1.BackColor = AssemblyHelper.ColorFromString(row.BACKCOLOR);
                    if (_isDesignMode)
                    {
                        AddControlDesignModeEvent(panel1);
                    }
                    else
                    {
                        this.MouseDown -= new MouseEventHandler(MedReportDesignControl_MouseDown);
                        this.MouseMove -= new MouseEventHandler(MedReportDesignControl_MouseMove);
                        this.MouseUp -= new MouseEventHandler(MedReportDesignControl_MouseUp);
                    }
                    this.Controls.Add(panel1);
                }
            }


            List<Control> controls = new List<Control>();
            foreach (Control control in Controls)
            {
                controls.Add(control);
            }
            controls.Sort(new Comparison<Control>(delegate(Control control1, Control control2)
                {
                    if (control1.Top == control2.Top)
                    {
                        return control1.Left.CompareTo(control2.Left);
                    }
                    else
                    {
                        return control1.Top.CompareTo(control2.Top);
                    }
                }));
            for (int i = 0;i <controls.Count ; i++)
            {
                controls[i].TabIndex = i; 
            }
        }

        public int GetRepHeight()
        {
            int h = Height;
            if (_reportSettingsDt != null && _reportSettingsDt.Rows.Count > 0)
            {
                if (!int.TryParse(_reportSettingsDt.Rows[0]["Height"].ToString().Trim(), out h))
                {
                    h = Height;
                }
            }
            return h;
        }

        private void MedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(sender is MedTextBox)) return;
            //if (e.KeyCode == Keys.Enter && !(sender as MedTextBox).Multiline)
            if (e.KeyCode == Keys.Enter && !(sender as MedTextBox).Properties.AutoHeight)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void AddControlDesignModeEvent(Control control)
        {
            control.MouseDown += new MouseEventHandler(Control_MouseDown);
            control.MouseMove += new MouseEventHandler(Control_MouseMove);
            control.MouseUp += new MouseEventHandler(Control_MouseUp);
            control.KeyDown += new KeyEventHandler(Control_KeyDown);
        }
        private void RemoveControlDesignModeEvent(Control control)
        {
            control.MouseDown -= new MouseEventHandler(Control_MouseDown);
            control.MouseMove -= new MouseEventHandler(Control_MouseMove);
            control.MouseUp -= new MouseEventHandler(Control_MouseUp);
            control.KeyDown -= new KeyEventHandler(Control_KeyDown);
        }

        private void SetMedControlDotBorder(object control, bool sign)
        {
            if (control is MedTextBox)
            {
                (control as MedTextBox).DotBorder = sign;
            }
            else if (control is MedLabel)
            {
                (control as MedLabel).DotBorder = sign;
            }            
        }

        private void ChangeSelect()
        {
            if (SelectedControlEvent != null && _selectControls != null && _selectControls.Count > 0)
            {
                if (_selectControls[0] == null)
                {
                    return;
                }
                Control selectControl = _selectControls[0];
                if (selectControl.Name.Length == 0)
                {
                    selectControl.Name = selectControl.GetType().Name;
                }
                SelectedControlEvent(selectControl, null);
            }
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _mouseOffset = new Point(-e.X, -e.Y);
                if (!_selectControls.Contains(sender as Control))
                {
                    foreach (Control Control1 in _selectControls)
                    {
                        SetMedControlDotBorder(Control1, false);
                    }
                    _selectControls.Clear();
                    _selectControls.Add(sender as Control);
                    SetMedControlDotBorder(sender, true);
                }
                ChangeSelect();
            }
        }

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                foreach (Control control in _selectControls)
                {
                    control.Left += e.X + _mouseOffset.X;
                    control.Top += e.Y + _mouseOffset.Y;
                    _isChanged = true;
                    control.BringToFront();
                }
                //ChangeSelect();
            }
        }

        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                foreach (Control control in _selectControls)
                {
                    control.Left += e.X + _mouseOffset.X;
                    control.Top += e.Y + _mouseOffset.Y;
                    _isChanged = true;
                    control.BringToFront();
                }
                ChangeSelect();
            }
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (_selectControls != null && _selectControls.Count > 0)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    DeleteSelectControl();
                }
            }
        }

        private void Control_Click(object sender, EventArgs e)
        {
            if (sender is MedTextBox)
            {
                MedTextBox MedTextBox1 = sender as MedTextBox;
                if (MedTextBox1.Properties.ReadOnly || MedTextBox1.LockInput) return;
                #region 绑定下拉框或拼音快速录入
                if (MedTextBox1.BindList.Length > 0)
                {
                    if (MedTextBox1.BindList == "BindDataSource")
                    {
                        if (MedTextBox1.CelerityInputTableName.Length > 0 && MedTextBox1.CelerityInputValueColumnName.Length > 0 && MedTextBox1.CelerityInputCodeColumnName.Length > 0)
                        {
                            if (_celerityInputTables[MedTextBox1.CelerityInputTableName] != null)
                            {
                                DataTable CelerityInputDT = (DataTable)_celerityInputTables[MedTextBox1.CelerityInputTableName];
                                DataRow[] Rows = CelerityInputDT.Select(MedTextBox1.CelerityInputSqlWhere);
                                Dialog.ShowCustomSelection(Rows, MedTextBox1.CelerityInputCodeColumnName, MedTextBox1,
                                                             new Size(MedTextBox1.Width, 300),
                                                             new EventHandler(delegate(object sender1, EventArgs e1)
                                                             {
                                                                 if (sender1 is int)
                                                                 {
                                                                     int Result = (int)sender1;
                                                                     if (Result > -1)
                                                                     {
                                                                         MedTextBox1.SelfValue = Rows[Result][MedTextBox1.CelerityInputValueColumnName].ToString();
                                                                         MedTextBox1.SelfValueChanged = true;
                                                                         MedTextBox1.Text = Rows[Result][MedTextBox1.CelerityInputCodeColumnName].ToString();                                                                         
                                                                     }
                                                                 }
                                                                 else if (sender1 is int[])
                                                                 {
                                                                     int[] ResultArr = (int[])sender1;
                                                                     MedTextBox1.Text = string.Empty;
                                                                     String Text = string.Empty;
                                                                     String Value = string.Empty;
                                                                     foreach (int Result in ResultArr)
                                                                     {
                                                                         Value += Rows[Result][MedTextBox1.CelerityInputValueColumnName].ToString() + LISTSEPARATOR;
                                                                         Text += Rows[Result][MedTextBox1.CelerityInputCodeColumnName].ToString() + ",";                                                                         
                                                                     }
                                                                     if (Value.Length > 0)
                                                                     {
                                                                         MedTextBox1.SelfValue = Value.Remove(Value.Length - 1, 1);
                                                                         MedTextBox1.SelfValueChanged = true;
                                                                     }
                                                                     if (Text.Length > 0)
                                                                     {                                                                         
                                                                         MedTextBox1.Text = Text.Remove(Text.Length - 1, 1);                                                                      
                                                                     }                                                                    
                                                                 }
                                                             }), MedTextBox1.MultiSign);
                            }
                        }
                    }
                    else
                    {
                        string[] StrArr = MedTextBox1.BindList.Split(new char[] { '#' });
                        string[] StrArrView = StrArr[0].Split(new char[] { '@' });
                        string[] StrArrValue = new string[StrArrView.Length];
                        if (StrArr.Length == 1)
                        {
                            StrArrValue = StrArrView;
                        }
                        else if (StrArr.Length == 2)
                        {
                            StrArrValue = StrArr[1].Split(new char[] { '@' });
                        }
                        int TextBoxWidth = MedTextBox1.Width;
                        if (TextBoxWidth < 50)
                        {
                            TextBoxWidth = 50;
                        }
                        Dialog.ShowCustomSelection(StrArrView, string.Empty, MedTextBox1,
                                                     new Size(TextBoxWidth, 300),
                                                     new EventHandler(delegate(object sender1, EventArgs e1)
                                                     {
                                                         if (sender1 is int)
                                                         {
                                                             int Result = (int)sender1;
                                                             if (Result > -1)
                                                             {
                                                                 MedTextBox1.SelfValue = StrArrValue[Result];
                                                                 MedTextBox1.SelfValueChanged = true;
                                                                 MedTextBox1.Text = StrArrView[Result];                                                                 
                                                             }
                                                         }
                                                         else if (sender1 is int[])
                                                         {
                                                             int[] ResultArr = (int[])sender1;
                                                             MedTextBox1.Text = string.Empty;
                                                             MedTextBox1.SelfValue = string.Empty;
                                                             String Text = string.Empty;
                                                             String Value = string.Empty;
                                                             foreach (int Result in ResultArr)
                                                             {
                                                                 Value += StrArrValue[Result] + LISTSEPARATOR;
                                                                 Text += StrArrView[Result] + ",";                                                                 
                                                             }
                                                             if (Value.Length > 0)
                                                             {
                                                                 MedTextBox1.SelfValue = Value.Remove(Value.Length - 1, 1);
                                                                 MedTextBox1.SelfValueChanged = true;
                                                             }
                                                             if (Text.Length > 0)
                                                             {                                                                 
                                                                 MedTextBox1.Text = Text.Remove(Text.Length - 1, 1);                                                                 
                                                             }                                                            
                                                         }
                                                     }), MedTextBox1.MultiSign);
                    }
                }
                else
                {
                    if (MedTextBox1.CelerityInputTableName.Length > 0 && MedTextBox1.CelerityInputValueColumnName.Length > 0 && MedTextBox1.CelerityInputCodeColumnName.Length > 0)
                    {
                        if (_celerityInputTables[MedTextBox1.CelerityInputTableName] != null)
                        {
                            DataTable CelerityInputDT = (DataTable)_celerityInputTables[MedTextBox1.CelerityInputTableName];
                            DataRow[] Rows = CelerityInputDT.Select(MedTextBox1.CelerityInputSqlWhere);
                            if (Rows != null && Rows.Length > 0)
                            {
                                if (MedTextBox1.CelerityInputTableName.Equals("MedAnesthesiaInputDict"))
                                {
                                    List<DataRow> rows = new List<DataRow>(Rows);
                                    rows.Sort(new Comparison<DataRow>(delegate(DataRow row1, DataRow row2)
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
                                    Rows = rows.ToArray();
                                }
                            }
                            //DataTable CelerityInputDTQuery = CelerityInputDT.Clone();
                            //foreach (DataRow Row in Rows)
                            //{
                            //    CelerityInputDTQuery.ImportRow(Row);
                            //}
                            //CelerityInput celerityInput = new CelerityInput(CelerityInputDTQuery, MedTextBox1.CelerityInputValueColumnName, MedTextBox1.CelerityInputCodeColumnName);
                            //celerityInput.Apply(MedTextBox1, ",");
                            //return;
                            int w = MedTextBox1.Width;
                            if (w < 100)w = 100;
                            Dialog.ShowCustomSelection(Rows, MedTextBox1.CelerityInputValueColumnName, MedTextBox1, new Size(w, 300),
                                new EventHandler(delegate(object sender1, EventArgs e1)
                                {
                                    if (sender1 is int)
                                    {
                                        int Result = (int)sender1;
                                        if (Result > -1)
                                        {
                                            if (MedTextBox1.MultiSign)
                                            {
                                                if (!string.IsNullOrEmpty(MedTextBox1.Text)) MedTextBox1.Text += ",";
                                                MedTextBox1.Text += Rows[Result][MedTextBox1.CelerityInputValueColumnName].ToString();
                                                MedTextBox1.SelfValue = MedTextBox1.Text;
                                                MedTextBox1.SelfValueChanged = true;
                                            }
                                            else
                                            {
                                                MedTextBox1.SelfValue = Rows[Result][MedTextBox1.CelerityInputCodeColumnName].ToString();
                                                MedTextBox1.SelfValueChanged = true;
                                                MedTextBox1.Text = Rows[Result][MedTextBox1.CelerityInputValueColumnName].ToString();
                                            }
                                        }
                                    }
                                    else if (sender1 is int[])
                                    {
                                        int[] ResultArr = (int[])sender1;
                                        MedTextBox1.Text = string.Empty;
                                        String Text = string.Empty;
                                        String Value = string.Empty;
                                        foreach (int Result in ResultArr)
                                        {
                                            Value += Rows[Result][MedTextBox1.CelerityInputValueColumnName].ToString() + LISTSEPARATOR;
                                            Text += Rows[Result][MedTextBox1.CelerityInputCodeColumnName].ToString().Trim() + ",";
                                        }
                                        if (Value.Length > 0)
                                        {
                                            MedTextBox1.SelfValue = Value.Remove(Value.Length - 1, 1);
                                            MedTextBox1.SelfValueChanged = true;
                                        }
                                        if (Text.Length > 0)
                                        {
                                            MedTextBox1.Text = Text.Remove(Text.Length - 1, 1);
                                        }
                                    }
                                }));//, MedTextBox1.MultiSign
                        }
                    }
                }
                #endregion
            }
        }

        private void DateTimeControl_Click(object sender, EventArgs e)
        {
            if (sender is MedTextBox)
            {
                MedTextBox MedTextBox1 = sender as MedTextBox;
                if (MedTextBox1.Properties.ReadOnly || MedTextBox1.LockInput) return;
                DateTime DateTime1;
                DateTime.TryParse(MedTextBox1.SelfValue, out DateTime1);
                Dialog.ShowDateTimeSelector(DateTime1, MedTextBox1,
                                              new EventHandler(delegate(object sender1, EventArgs e1)
                                              {
                                                  if (sender1 is DateTime)
                                                  {
                                                      DateTime DateTime2 = (DateTime)sender1;
                                                      MedTextBox1.SelfValue = DateTime2.ToString();
                                                      MedTextBox1.SelfValueChanged = true;
                                                      if (MedTextBox1.Format.Length > 0)
                                                      {
                                                          MedTextBox1.Text = String.Format("{" + MedTextBox1.Format + "}", DateTime2);
                                                      }
                                                      else
                                                      {
                                                          MedTextBox1.Text = DateTime2.ToString();
                                                      }                                                      
                                                  }
                                              }));
            }
        }

        private void customControl_ValueChanged(object sender, EventArgs e)
        {
            if (sender is CustomControl)
            {
                CustomControl customControl = sender as CustomControl;
                if (_bindTablesForKey.ContainsKey(customControl.TableName))
                {
                    try
                    {
                        if (!customControl.TableName.ToLower().Equals("customdata"))
                        {
                            DataTable DT = (DataTable)_bindTablesForKey[customControl.TableName];
                            Type Type1 = DT.Columns[customControl.FieldName].DataType;
                            string Value = customControl.Value.ToString();
                            if (DT.Columns[customControl.FieldName].DataType == typeof(int))
                            {
                                int Result;
                                if (int.TryParse(Value, out Result))
                                {
                                    DT.Rows[0][customControl.FieldName] = Value;
                                }
                            }
                            else if (DT.Columns[customControl.FieldName].DataType == typeof(decimal))
                            {
                                decimal Result;
                                if (decimal.TryParse(Value, out Result))
                                {
                                    DT.Rows[0][customControl.FieldName] = Value;
                                }
                            }
                            else
                            {
                                DT.Rows[0][customControl.FieldName] = Value;
                            }
                        }
                        _dataIsChanged = true;
                        if (DataChangedEvent != null)
                        {
                            DataChangedEvent(sender, null);
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }

        private void Control_TextChanged(object sender, EventArgs e)
        {
            if (sender is MedTextBox)
            {
                MedTextBox MedTextBox1 = sender as MedTextBox;
                if (MedTextBox1.LockInput || MedTextBox1.Properties.ReadOnly)
                {
                    return;
                }
                //if (!MedTextBox1.SelfValueChanged)
                {
                    MedTextBox1.SelfValue = MedTextBox1.Text;
                }
                if (_bindTablesForKey.ContainsKey(MedTextBox1.BindTableName))
                {
                    try
                    {
                        if (!MedTextBox1.BindTableName.ToLower().Equals("customdata"))
                        {
                            DataTable DT = (DataTable)_bindTablesForKey[MedTextBox1.BindTableName];
                            Type Type1 = DT.Columns[MedTextBox1.BindFieldName].DataType;
                            string Value = MedTextBox1.Text;
                            if (MedTextBox1.SelfValue.Length > 0)
                            {
                                Value = MedTextBox1.SelfValue;
                            }
                            if (DT.Columns[MedTextBox1.BindFieldName].DataType == typeof(DateTime))
                            {
                                DateTime Result;
                                if (DateTime.TryParse(Value, out Result))
                                {
                                    DT.Rows[0][MedTextBox1.BindFieldName] = Result;
                                }
                            }
                            else if (DT.Columns[MedTextBox1.BindFieldName].DataType == typeof(int))
                            {
                                int Result;
                                if (int.TryParse(Value, out Result))
                                {
                                    DT.Rows[0][MedTextBox1.BindFieldName] = Value;
                                }
                            }
                            else if (DT.Columns[MedTextBox1.BindFieldName].DataType == typeof(float))
                            {
                                float Result;
                                if (float.TryParse(Value, out Result))
                                {
                                    DT.Rows[0][MedTextBox1.BindFieldName] = Value;
                                }
                            }
                            else if (DT.Columns[MedTextBox1.BindFieldName].DataType == typeof(decimal))
                            {
                                decimal Result;
                                if (string.IsNullOrEmpty(Value))
                                {
                                    DT.Rows[0][MedTextBox1.BindFieldName] = System.DBNull.Value;
                                }
                                else
                                {
                                    if (decimal.TryParse(Value, out Result))
                                    {
                                        DT.Rows[0][MedTextBox1.BindFieldName] = Value;
                                    }
                                    else
                                    {
                                        DT.Rows[0][MedTextBox1.BindFieldName] = 0;
                                    }
                                }
                            }
                            else
                            {
                                DT.Rows[0][MedTextBox1.BindFieldName] = Value;
                            }
                        }
                        if (MedTextBox1.OldForeColor == MedTextBox1.ForeColor)
                        {
                            Color Color1 = Color.FromArgb((int)((long)MedTextBox1.BackColor.ToArgb() + (long)MedTextBox1.ForeColor.ToArgb()) / 2);
                            MedTextBox1.ForeColor = Color1;
                        }
                        _dataIsChanged = true;
                        if (DataChangedEvent != null)
                        {
                            DataChangedEvent(sender, null);
                        }
                        base.OnTextChanged(e);
                    }
                    //catch (TargetInvocationException ex)
                    //{
                    //    if (ex.InnerException.Message == "输入字符串的格式不正确。")
                    //    {
                    //        Dialog.MessageBox(MedTextBox1.BindFieldName + "列" + "只允许输入" + Type1.FullName + "类型值。");
                    //        MedTextBox1.Text = string.Empty;
                    //    }
                    //}
                    catch //(ArgumentException)
                    {
                        //Dialog.MessageBox(MedTextBox1.BindFieldName + "列" + "最大长度为" + DT.Columns[MedTextBox1.BindFieldName].MaxLength.ToString() + "，输入超过范围。");
                        MedTextBox1.Text = string.Empty;
                    }
                }
            }
        }

        private void MedReportDesignControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ChangeSelect();
                _drawOriginPoint = e.Location;
                _rect.Location = new Point(-1, -1);
                _rect.Size = new Size(0, 0);
                foreach (Control Control1 in _selectControls)
                {
                    SetMedControlDotBorder(Control1, false);
                }
                _selectControls.Clear();
                _isDrawSelect = true;
            }
        }

        private void MedReportDesignControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_isDrawSelect)
                {
                    int RectOriginX = (e.X > _drawOriginPoint.X) ? _drawOriginPoint.X : e.X;
                    int RectOriginY = (e.Y > _drawOriginPoint.Y) ? _drawOriginPoint.Y : e.Y;
                    int RectWidth = Math.Abs(e.X - _drawOriginPoint.X) + 1;
                    int RectHeight = Math.Abs(e.Y - _drawOriginPoint.Y) + 1;
                    _rect = new Rectangle(RectOriginX, RectOriginY, RectWidth, RectHeight);
                    using (Graphics g = this.CreateGraphics())
                    {
                        g.Clear(this.BackColor);
                        Pen Pen1 = new Pen(Color.Black, 1);
                        Pen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                        g.DrawRectangle(Pen1, _rect);
                    }
                }
            }
        }

        private void MedReportDesignControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDrawSelect = false;
                foreach (Control Control1 in this.Controls)
                {
                    if (_rect.IntersectsWith(Control1.Bounds))
                    {
                        SetMedControlDotBorder(Control1, true);
                        _selectControls.Add(Control1);
                    }
                }
                if (_selectControls.Count == 0)
                {
                    _selectControls.Add(this);
                }
                ChangeSelect();
                Refresh();
            }
        }

        private int CompareByLeft(Control control1, Control control2)
        {
            int Result;
            if (control1.Left < control2.Left)
            {
                Result = -1;
            }
            else if (control1.Left == control2.Left)
            {
                Result = 0;
            }
            else
            {
                Result = 1;
            }
            return Result;
        }

        private int CompareByTop(Control control1, Control control2)
        {
            int Result;
            if (control1.Top < control2.Top)
            {
                Result = -1;
            }
            else if (control1.Top == control2.Top)
            {
                Result = 0;
            }
            else
            {
                Result = 1;
            }
            return Result;
        }

        public void BindFormatEvent(MedTextBox textBox)
        {
            textBox.Click -= new EventHandler(Control_Click);
            //textBox.KeyDown -= new KeyEventHandler(MedTextBox1_KeyDown);
            textBox.Click += new EventHandler(DateTimeControl_Click);
        }

        private void DataBind(MedTextBox medTextBox, DataTable bindTable)
        {
            if (bindTable.Rows.Count > 0)
            {
                try
                {
                    medTextBox.SelfValue = bindTable.Rows[0][medTextBox.BindFieldName].ToString();
                }
                catch { }
                string text = GetTextBoxTextForSelfValue(medTextBox);
                medTextBox.Text = text;
                if (medTextBox.Format.Length > 0)
                {
                    //if (bindTable.Columns[medTextBox.BindFieldName].DataType.ToString() == typeof(DateTime).ToString())
                    if (bindTable.Columns.Contains(medTextBox.BindFieldName))
                    {
                        DateTime DateTime1;
                        DateTime.TryParse(bindTable.Rows[0][medTextBox.BindFieldName].ToString(), out DateTime1);
                        medTextBox.SelfValue = bindTable.Rows[0][medTextBox.BindFieldName].ToString();
                        medTextBox.Text = String.Format("{" + medTextBox.Format + "}", DateTime1);
                        if (bindTable.Columns[medTextBox.BindFieldName].MaxLength > -1)
                        {
                            medTextBox.Properties.MaxLength = bindTable.Columns[medTextBox.BindFieldName].MaxLength;
                        }
                        if (_updateMode)
                        {
                            BindFormatEvent(medTextBox);
                        }
                        medTextBox.Properties.ReadOnly = true;
                    }
                }
            }
        }

        private void DataBind(CustomControl customControl, DataTable bindTable)
        {
            if (bindTable.Rows.Count > 0 && !bindTable.TableName.ToLower().Equals("customdata"))
            {
                customControl.Value = bindTable.Rows[0][customControl.FieldName].ToString();
            }
        }

        private string GetTextBoxTextForSelfValue(MedTextBox medTextBox)
        {           
            string Result = string.Empty;
            if(medTextBox.BindList.Length == 0)
            {
                if (medTextBox.CelerityInputValueColumnName != medTextBox.CelerityInputCodeColumnName && medTextBox.CelerityInputTableName.Length > 0
                    && medTextBox.CelerityInputValueColumnName.Length > 0 && medTextBox.CelerityInputCodeColumnName.Length > 0)
                {
                    if (_celerityInputTables[medTextBox.CelerityInputTableName] != null)
                    {
                        DataTable CelerityInputDT = (DataTable)_celerityInputTables[medTextBox.CelerityInputTableName];
                        DataRow[] Rows = CelerityInputDT.Select(medTextBox.CelerityInputSqlWhere);
                        foreach (DataRow row in Rows)
                        {
                            if (row[medTextBox.CelerityInputCodeColumnName].ToString().Equals(medTextBox.SelfValue))
                            {
                                return row[medTextBox.CelerityInputValueColumnName].ToString();
                            }
                        }
                    }
                }
                return medTextBox.SelfValue;                 
            }
            if (medTextBox.BindList == "BindDataSource")
            {
                if (_celerityInputTables[medTextBox.CelerityInputTableName] != null)
                {
                    DataTable CelerityInputDT = (DataTable)_celerityInputTables[medTextBox.CelerityInputTableName];
                    string[] Values = medTextBox.SelfValue.Split(new char[] { LISTSEPARATOR });
                    foreach (string Value in Values)
                    {
                        DataRow[] Rows = CelerityInputDT.Select(medTextBox.CelerityInputValueColumnName + " = '" + medTextBox.SelfValue + "'");
                        if (Rows.Length > 0)
                        {
                            Result += Rows[0][medTextBox.CelerityInputCodeColumnName].ToString() + ",";
                        }
                    }
                    if (Result.Length > 0)
                    {
                        Result = Result.Remove(Result.Length - 1, 1);
                    }                   
                }
                return Result;
            }
            else
            {
                string[] StrArr = medTextBox.BindList.Split(new char[] { '#' });
                string[] StrArrView = StrArr[0].Split(new char[] { '@' });
                string[] StrArrValue = medTextBox.SelfValue.Split(new char[] { LISTSEPARATOR });
                if (StrArr.Length == 1)
                {
                    StrArrValue = StrArrView;
                }
                else if (StrArr.Length == 2)
                {
                    StrArrValue = StrArr[1].Split(new char[] { '@' });
                }
                string[] Values = medTextBox.SelfValue.Split(new char[] { LISTSEPARATOR });                
                foreach (string Value in Values)
                {
                    for (int i = 0; i < StrArrValue.Length; i++)
                    {
                        if (Value == StrArrValue[i])
                        {
                            Result += StrArrView[i] + ",";
                            break;
                        }
                    }                                      
                }
                if (Result.Length > 0)
                {
                    Result = Result.Remove(Result.Length - 1, 1);
                }
                return Result;
            }
        }

        private Control[] AddControl(DesignableField[] designableFields)
        {
            List<Control> controls = new List<Control>();

            if (designableFields != null && designableFields.Length > 0)
            {
                foreach (Control Control1 in _selectControls)
                {
                    SetMedControlDotBorder(Control1, false);
                }
                _selectControls.Clear();
                foreach (DesignableField designableField in designableFields)
                {
                    Control control = designableField.GenControl();
                    if (control is CustomControl && _isDesignMode)
                    {
                        (control as CustomControl).BorderStyle = BorderStyle.FixedSingle;
                    }
                    if (control != null)
                    {
                        AddControlDesignModeEvent(control);
                        Controls.Add(control);
                        if (control is MedTextBox || control is CustomControl)
                        {
                            if (!string.IsNullOrEmpty(control.Text))
                            {
                                control.Text = (control as MedTextBox).BindFieldName;
                                control.ForeColor = Color.Blue;
                                //string text = control.Text;
                                //int index = 0;
                                //if (text.Length > 1 && int.TryParse(text.Substring(text.Length - 2), out index))
                                //{
                                //    text = text.Substring(0, text.Length - 2) + (index + 1).ToString();
                                //}
                                //if (int.TryParse(text.Substring(text.Length - 1), out index))
                                //{
                                //    text = text.Substring(0, text.Length - 1) + (index + 1).ToString();
                                //}
                                //else
                                //{
                                //    text = text + "0";
                                //}
                                //control.Text = text;
                                control.Name = control.Text;
                            }
                        }
                        controls.Add(control);
                        _selectControls.Add(control);
                        control.BringToFront();
                        SetMedControlDotBorder(control, true);
                    }
                }
                ChangeSelect();
                _isChanged = true;
            }
            if (controls.Count > 0)
            {
                return controls.ToArray();
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region 公开方法

        public override string ToString()
        {
            return _reportName + "(麻醉单基本信息设计器)";
        }

        /// <summary>
        /// 设置选中组件左边距
        /// </summary>
        /// <param name="left">左边距</param>
        /// <returns>成功返回1,选中组件为空返回0,设置边距不合理返回-1</returns>
        public int SetControlLeft(int left)
        {
            foreach (Control ctl in _selectControls)
            {
                ctl.Left = left;
            }
            _isChanged = true;
            return 1;
        }
        /// <summary>
        /// 设置选中组件上边距
        /// </summary>
        /// <param name="left">上边距</param>
        /// <returns>成功返回1,选中组件为空返回0,设置边距不合理返回-1</returns>
        public int SetControlTop(int top)
        {
            foreach (Control ctl in _selectControls)
            {
                ctl.Top = top;
            }
            _isChanged = true;
            return 1;
        }
        /// <summary>
        /// 设置选中组件宽度
        /// </summary>
        /// <param name="left">宽度</param>
        /// <returns>成功返回1,选中组件为空返回0,设置宽度不合理返回-1</returns>
        public int SetControlWidth(int width)
        {
            foreach (Control ctl in _selectControls)
            {
                ctl.Width = width;
            }
            _isChanged = true;
            return 1;
        }
        /// <summary>
        /// 设置选中组件高度
        /// </summary>
        /// <param name="left">高度</param>
        /// <returns>成功返回1,选中组件为空返回0,设置高度不合理返回-1</returns>
        public int SetControlHeight(int height)
        {
            foreach (Control ctl in _selectControls)
            {
                if (ctl.Name == "medPrintPreview1")
                {
                    this.Controls["pan5"].Height = height + 2;
                    break;
                }
                ctl.Height = height;
            }
            _isChanged = true;
            return 1;
        }
        /// <summary>
        /// 设置选中组件字体
        /// </summary>
        /// <param name="font">字体</param>
        /// <returns>成功返回1,选中组件为空返回0,设置字体为空返回-1</returns>
        public int SetControlFont(Font font)
        {
            if (font == null)
            {
                return -1;
            }
            foreach (Control Control in _selectControls)
            {
                Control.Font = font;
            }
            _isChanged = true;
            return 1;
        }
        /// <summary>
        /// 设置选中组件颜色
        /// </summary>
        /// <param name="font">颜色</param>
        /// <returns>成功返回1,选中组件为空返回0,设置颜色为空返回-1</returns>
        public int SetControlColor(Color color)
        {
            if (color == Color.Empty)
            {
                return -1;
            }
            foreach (Control Control1 in _selectControls)
            {
                if (Control1 is Panel)
                {
                    Control1.BackColor = color;
                }
                else
                {
                    Control1.ForeColor = color;
                }
            }
            _isChanged = true;
            return 1;
        }
        /// <summary>
        /// 删除选中组件
        /// </summary>        
        /// <returns>成功返回1,选中组件为空返回0,欲删除容器返回-1</returns>
        public int DeleteSelectControl()
        {
            if (_selectControls != null && _selectControls.Count > 0)
            {
                foreach (Control control in _selectControls)
                {
                    this.Controls.Remove(control);
                }
                _selectControls.Clear();
            }
            _isChanged = true;
            ChangeSelect();
            return 1;
        }
        /// <summary>
        /// 保存容器属性信息 
        /// </summary>
        public void SaveSettings()
        {
            #region 配置表初始化
            _settingsDS.Clear();
            if (System.IO.File.Exists(_configFileName))
            {
                _settingsDS.ReadXml(_configFileName);
            }
            if (_settingsDS.Tables.Contains(_reportSettingsTableName))
            {
                _reportSettingsDt = _settingsDS.Tables[_reportSettingsTableName];
            }
            else
            {
                if (_reportSettingsDt.DataSet != null)
                {
                    _reportSettingsDt.DataSet.Tables.Remove(_reportSettingsDt);
                }
                _settingsDS.Tables.Add(_reportSettingsDt);
            }
            if (_settingsDS.Tables.Contains(_textBoxListSettingsTableName))
            {
                _textBoxListSettingsDt = _settingsDS.Tables[_textBoxListSettingsTableName];
            }
            else
            {
                if (_textBoxListSettingsDt.DataSet != null)
                {
                    _textBoxListSettingsDt.DataSet.Tables.Remove(_textBoxListSettingsDt);
                }
                _textBoxListSettingsDt.Clear();
                _settingsDS.Tables.Add(_textBoxListSettingsDt);
            }
            if (_settingsDS.Tables.Contains(_customControlTableName))
            {
                _customControlTable = _settingsDS.Tables[_customControlTableName];
            }
            else
            {
                if (_customControlTable.DataSet != null)
                {
                    _customControlTable.DataSet.Tables.Remove(_customControlTable);
                }
                _customControlTable.Clear();
                _settingsDS.Tables.Add(_customControlTable);
            }
            if (_settingsDS.Tables.Contains(_richTextBoxListSettingsTableName))
            {
                _richTextBoxListSettingsDt = _settingsDS.Tables[_richTextBoxListSettingsTableName];
            }
            else
            {
                if (_richTextBoxListSettingsDt.DataSet != null)
                {
                    _richTextBoxListSettingsDt.DataSet.Tables.Remove(_richTextBoxListSettingsDt);
                }
                _richTextBoxListSettingsDt.Clear();
                _settingsDS.Tables.Add(_richTextBoxListSettingsDt);
            }
            if (_settingsDS.Tables.Contains(_labelListSettingsTableName))
            {
                _labelListSettingsDt = _settingsDS.Tables[_labelListSettingsTableName];
            }
            else
            {
                if (_labelListSettingsDt.DataSet != null)
                {
                    _labelListSettingsDt.DataSet.Tables.Remove(_labelListSettingsDt);
                }
                _labelListSettingsDt.Clear();
                _settingsDS.Tables.Add(_labelListSettingsDt);
            }
            if (_settingsDS.Tables.Contains(_panelListSettingsTableName))
            {
                _panelListSettingsDt = _settingsDS.Tables[_panelListSettingsTableName];
            }
            else
            {
                if (_panelListSettingsDt.DataSet != null)
                {
                    _panelListSettingsDt.DataSet.Tables.Remove(_panelListSettingsDt);
                }
                _panelListSettingsDt.Clear();
                _settingsDS.Tables.Add(_panelListSettingsDt);
            }
            if (_settingsDS.Tables.Contains(_dataGridViewListSettingsTableName))
            {
                _dataGridViewListSettingsDt = _settingsDS.Tables[_dataGridViewListSettingsTableName];
            }
            else
            {
                if (_dataGridViewListSettingsDt.DataSet != null)
                {
                    _dataGridViewListSettingsDt.DataSet.Tables.Remove(_dataGridViewListSettingsDt);
                }
                _dataGridViewListSettingsDt.Clear();
                _settingsDS.Tables.Add(_dataGridViewListSettingsDt);
            }
            int ReportSettingsDtCount = _reportSettingsDt.Rows.Count;
            for (int i = 0; i < ReportSettingsDtCount; i++)
            {
                _reportSettingsDt.Rows[0].Delete();
            }
            int TextBoxListSettingsDtCount = _textBoxListSettingsDt.Rows.Count;
            for (int i = 0; i < TextBoxListSettingsDtCount; i++)
            {
                _textBoxListSettingsDt.Rows[0].Delete();
            }
            TextBoxListSettingsDtCount = _customControlTable.Rows.Count;
            for (int i = 0; i < TextBoxListSettingsDtCount; i++)
            {
                _customControlTable.Rows[0].Delete();
            }
            int RichTextBoxListSettingsDtCount = _richTextBoxListSettingsDt.Rows.Count;
            for (int i = 0; i < RichTextBoxListSettingsDtCount; i++)
            {
                _richTextBoxListSettingsDt.Rows[0].Delete();
            }
            int LabelListSettingsDtCount = _labelListSettingsDt.Rows.Count;
            for (int i = 0; i < LabelListSettingsDtCount; i++)
            {
                _labelListSettingsDt.Rows[0].Delete();
            }
            int PanelListSettingsDtCount = _panelListSettingsDt.Rows.Count;
            for (int i = 0; i < PanelListSettingsDtCount; i++)
            {
                _panelListSettingsDt.Rows[0].Delete();
            }
            int DataGridViewListSettingsDtCount = _dataGridViewListSettingsDt.Rows.Count;
            for (int i = 0; i < DataGridViewListSettingsDtCount; i++)
            {
                _dataGridViewListSettingsDt.Rows[0].Delete();
            }
            #endregion

            #region 设置容器配置表
            DataRow ReportSettingsRow = _reportSettingsDt.NewRow();
            ReportSettingsRow["Width"] = this.Width;
            ReportSettingsRow["Height"] = this.Height;
            ReportSettingsRow["Top"] = 0;
            ReportSettingsRow["Left"] = this.Left;
            ReportSettingsRow["BorderColor"] = this.BorderColor.Name.ToString().Trim();
            ReportSettingsRow["DrawBorder"] = this.DrawBorder.ToString().Trim();
            _reportSettingsDt.Rows.Add(ReportSettingsRow);
            #endregion

            #region 设置TextBox,Label和Panle以及DataGridView列表
            foreach (Control Control1 in this.Controls)
            {
                if (Control1 is MedTextBox)
                {
                    DataRow TextBoxSettingsRow = _textBoxListSettingsDt.NewRow();
                    TextBoxSettingsRow["Width"] = Control1.Width;
                    TextBoxSettingsRow["Height"] = Control1.Height;
                    TextBoxSettingsRow["Top"] = Control1.Top;
                    TextBoxSettingsRow["Left"] = Control1.Left;
                    TextBoxSettingsRow["ForeColor"] = Control1.ForeColor.Name;
                    //TextBoxSettingsRow["ReadOnly"] = (Control1 as TextBox).ReadOnly.ToString().Trim();
                    TextBoxSettingsRow["Text"] = Control1.Text;
                    TextBoxSettingsRow["BackColor"] = Control1.BackColor.Name;
                    TextBoxSettingsRow["Font"] = Control1.Font.ToString().Trim();
                    TextBoxSettingsRow["FontStyle"] = Control1.Font.Style.ToString().Trim();
                    TextBoxSettingsRow["BindTableName"] = (Control1 as MedTextBox).BindTableName;
                    TextBoxSettingsRow["BindFieldName"] = (Control1 as MedTextBox).BindFieldName;
                    TextBoxSettingsRow["CelerityInputTableName"] = (Control1 as MedTextBox).CelerityInputTableName;
                    TextBoxSettingsRow["CelerityInputValueColumnName"] = (Control1 as MedTextBox).CelerityInputValueColumnName;
                    TextBoxSettingsRow["CelerityInputCodeColumnName"] = (Control1 as MedTextBox).CelerityInputCodeColumnName;
                    TextBoxSettingsRow["CelerityInputSqlWhere"] = (Control1 as MedTextBox).CelerityInputSqlWhere;
                    if (_textBoxListSettingsDt.Columns.Contains("BindList"))
                    {
                        TextBoxSettingsRow["BindList"] = (Control1 as MedTextBox).BindList;
                    }
                    TextBoxSettingsRow["Format"] = (Control1 as MedTextBox).Format;
                    TextBoxSettingsRow["MultiSign"] = (Control1 as MedTextBox).MultiSign;
                    TextBoxSettingsRow["Multiline"] = (Control1 as MedTextBox).Properties.AutoHeight;//.Multiline;
                    _textBoxListSettingsDt.Rows.Add(TextBoxSettingsRow);
                }
                else if (Control1 is CustomControl)
                {
                    DataRow TextBoxSettingsRow = _customControlTable.NewRow();
                    TextBoxSettingsRow["Width"] = Control1.Width;
                    TextBoxSettingsRow["Height"] = Control1.Height;
                    TextBoxSettingsRow["Top"] = Control1.Top;
                    TextBoxSettingsRow["Left"] = Control1.Left;
                    TextBoxSettingsRow["ForeColor"] = Control1.ForeColor.Name;
                    //TextBoxSettingsRow["ReadOnly"] = (Control1 as TextBox).ReadOnly.ToString().Trim();
                    TextBoxSettingsRow["Text"] = Control1.Text;
                    TextBoxSettingsRow["BackColor"] = Control1.BackColor.Name;
                    TextBoxSettingsRow["Font"] = (Control1 as CustomControl).Font.ToString().Trim();
                    TextBoxSettingsRow["FontStyle"] = (Control1 as CustomControl).Font.Style.ToString().Trim();
                    TextBoxSettingsRow["BindTableName"] = (Control1 as CustomControl).TableName;
                    TextBoxSettingsRow["BindFieldName"] = (Control1 as CustomControl).FieldName;
                    TextBoxSettingsRow["CelerityInputTableName"] = (Control1 as CustomControl).SourceTableName;
                    TextBoxSettingsRow["CelerityInputValueColumnName"] = (Control1 as CustomControl).ValueFieldName;
                    TextBoxSettingsRow["CelerityInputCodeColumnName"] = (Control1 as CustomControl).DisplayFieldName;
                    TextBoxSettingsRow["CelerityInputSqlWhere"] = (Control1 as CustomControl).SqlWhereFilter;
                    //TextBoxSettingsRow["BindList"] = (Control1 as MedTextBox).BindList;
                    //TextBoxSettingsRow["Format"] = (Control1 as MedTextBox).Format;
                    TextBoxSettingsRow["MultiSign"] = (Control1 as CustomControl).MultiSelect;
                    //TextBoxSettingsRow["Multiline"] = (Control1 as MedTextBox).Multiline;
                    _customControlTable.Rows.Add(TextBoxSettingsRow);
                }
                else if (Control1 is MedLabel)
                {
                    DataRow LabelSettingsRow = _labelListSettingsDt.NewRow();
                    LabelSettingsRow["Width"] = Control1.Width;
                    LabelSettingsRow["Height"] = Control1.Height;
                    LabelSettingsRow["Top"] = Control1.Top;
                    LabelSettingsRow["Left"] = Control1.Left;
                    LabelSettingsRow["ForeColor"] = Control1.ForeColor.Name;
                    LabelSettingsRow["Text"] = Control1.Text;
                    LabelSettingsRow["BackColor"] = Control1.BackColor.Name;
                    LabelSettingsRow["Font"] = Control1.Font.ToString().Trim();
                    LabelSettingsRow["FontStyle"] = Control1.Font.Style.ToString().Trim();
                    if (!_labelListSettingsDt.Columns.Contains("Name"))
                    {
                        _labelListSettingsDt.Columns.Add("Name");
                    }
                    LabelSettingsRow["Name"] = Control1.Name;
                    _labelListSettingsDt.Rows.Add(LabelSettingsRow);
                }
                else if (Control1 is Panel)
                {
                    DataRow PanelSettingsRow = _panelListSettingsDt.NewRow();
                    PanelSettingsRow["Top"] = Control1.Top;
                    PanelSettingsRow["Left"] = Control1.Left;
                    PanelSettingsRow["Width"] = Control1.Width;
                    PanelSettingsRow["Height"] = Control1.Height;
                    PanelSettingsRow["BackColor"] = Control1.BackColor.Name;
                    _panelListSettingsDt.Rows.Add(PanelSettingsRow);
                }
                else if (Control1 is RichTextBox)
                {
                    DataRow RichTextBoxSettingsRow = _richTextBoxListSettingsDt.NewRow();
                    RichTextBoxSettingsRow["Width"] = Control1.Width;
                    RichTextBoxSettingsRow["Height"] = Control1.Height;
                    RichTextBoxSettingsRow["Top"] = Control1.Top;
                    RichTextBoxSettingsRow["Left"] = Control1.Left;
                    RichTextBoxSettingsRow["ForeColor"] = Control1.ForeColor.Name;
                    RichTextBoxSettingsRow["Text"] = Control1.Text;
                    RichTextBoxSettingsRow["Font"] = Control1.Font.ToString().Trim();
                    RichTextBoxSettingsRow["FontStyle"] = Control1.Font.Style.ToString().Trim();
                    _richTextBoxListSettingsDt.Rows.Add(RichTextBoxSettingsRow);
                }
                else if (Control1 is MedDataGridView)
                {
                    DataRow DataGridViewListSettingsRow = _dataGridViewListSettingsDt.NewRow();
                    DataGridViewListSettingsRow["Width"] = Control1.Width;
                    DataGridViewListSettingsRow["Height"] = Control1.Height;
                    DataGridViewListSettingsRow["Top"] = Control1.Top;
                    DataGridViewListSettingsRow["Left"] = Control1.Left;
                    DataGridViewListSettingsRow["RowCount"] = (Control1 as MedDataGridView).RowCount;
                    DataGridViewListSettingsRow["Font"] = (Control1 as MedDataGridView).Font.ToString().Trim();
                    DataGridViewListSettingsRow["FontStyle"] = (Control1 as MedDataGridView).Font.Style.ToString().Trim();
                    //声明字符串数组，0存放列标题，1存放列宽度，2存放列数据源
                    string[] Columns = {"","",""};
                    foreach (DataGridViewColumn GridColumn in (Control1 as MedDataGridView).Columns)
                    {
                        Columns[0] += "@" + GridColumn.HeaderText;
                        Columns[1] += "@" + GridColumn.Width;
                        Columns[2] += "@" + GridColumn.DataPropertyName;
                    }
                    if (Columns[0].Length > 0)
                    {
                        Columns[0] = Columns[0].Remove(0,1);
                    }
                    if (Columns[1].Length > 0)
                    {
                        Columns[1] = Columns[1].Remove(0,1);
                    }
                    if (Columns[2].Length > 0)
                    {
                        Columns[2] = Columns[2].Remove(0,1);
                    }
                    DataGridViewListSettingsRow["Columns"] = Columns[0] + "#" + Columns[1] + "#" + Columns[2];
                    DataGridViewListSettingsRow["TableName"] = (Control1 as MedDataGrid).BindTableName;
                    _dataGridViewListSettingsDt.Rows.Add(DataGridViewListSettingsRow);
                }
            }
            #endregion

            _settingsDS.WriteXml(_configFileName, XmlWriteMode.IgnoreSchema);
            _isChanged = false;
        }
        /// <summary>
        /// 增加绑定依赖主键数据源
        /// </summary>
        /// <param name="bindTable">绑定数据源</param>
        /// <returns>为1成功,为0该数据源已经存在,-1欲绑定数据源为空,-2该Report没有绑定该DataTable</returns>
        public int RefreshBindTableForKey(DataTable bindTable)
        {
            if (bindTable == null)
            {
                return -1;
            }
            if (_bindTablesForKey.ContainsKey(bindTable.TableName))
            {
                _bindTablesForKey[bindTable.TableName] = bindTable;
            }
            else
            {
                return -2;
            }
            foreach (Control Control1 in this.Controls)
            {
                if (Control1 is MedTextBox)
                {
                    MedTextBox MedTextBox1 = Control1 as MedTextBox;
                    if (MedTextBox1.BindTableName == bindTable.TableName)
                    {                       
                        DataBind(MedTextBox1, bindTable);
                        //2008-11-20 于占涛屏蔽 原因如采用自动绑定，无法对TextBox的文本进行格式化
                        //MedTextBox1.DataBindings.Clear();
                        //MedTextBox1.DataBindings.Add("Text", bindTable, MedTextBox1.BindFieldName, false, DataSourceUpdateMode.OnValidation);                     
                        MedTextBox1.TextChanged += new EventHandler(Control_TextChanged);
                    }
                }
                else if (Control1 is CustomControl)
                {
                    CustomControl customControl = Control1 as CustomControl;
                    if (customControl.TableName == bindTable.TableName)
                    {
                        DataBind(customControl, bindTable);
                        customControl.ValueChanged += new EventHandler(customControl_ValueChanged);
                    }
                }
            }
            return 1;
        }

        /// <summary>
        /// 增加绑定返回列表的数据源
        /// </summary>
        /// <param name="bindTable">绑定数据源</param>
        /// <returns>为1成功,为0该数据源已经存在,-1欲绑定数据源为空,-2该Report没有绑定该DataTable</returns>
        public int RefreshBindListTable(DataTable bindTable)
        {
            if (bindTable == null)
            {
                return -1;
            }
            if (_bindListTables.ContainsKey(bindTable.TableName))
            {
                _bindListTables[bindTable.TableName] = bindTable;
            }
            else
            {
                return -2;
            }
            foreach (Control Control1 in this.Controls)
            {
                if (Control1 is MedDataGrid)
                {
                    MedDataGrid MedDataGridView1 = Control1 as MedDataGrid;
                    if (MedDataGridView1.BindTableName == bindTable.TableName)
                    {
                        MedDataGridView1.DataSource = bindTable;
                    }
                }
            }
            return 1;
        }
        /// <summary>
        /// 校验该Report是否包含该依赖主键的DataTable
        /// </summary>
        /// <param name="bindTableName">该DataTable名称</param>
        /// <returns>包含返回真，否则返回假</returns>
        public bool ContainBindTableForKey(string bindTableName)
        {
            return _bindTablesForKey.ContainsKey(bindTableName);
        }
        /// <summary>
        /// 校验该Report是否包含该返回列表的的DataTable
        /// </summary>
        /// <param name="bindTableName">该DataTable名称</param>
        /// <returns>包含返回真，否则返回假</returns>
        public bool ContainBindListTable(string bindTableName)
        {
            return _bindListTables.ContainsKey(bindTableName);
        }

        /// <summary>
        /// 校验该Report是否包含该快速录入数据源
        /// </summary>
        /// <param name="bindTableName">该DataTable名称</param>
        /// <returns>包含返回真，否则返回假</returns>
        public bool ContainCelerityInputTable(string celerityInputTableName)
        {
            return _celerityInputTables.ContainsKey(celerityInputTableName);
        }

        /// <summary>
        /// 增加快速录入数据源
        /// </summary>
        /// <param name="bindTable">快速录入数据源</param>
        /// <returns>为1成功,为0该数据源已经存在,-1欲绑定数据源为空,-2该Report没有绑定该快速录入数据源</returns>
        public int RefreshCelerityInputTable(DataTable celerityInputTable)
        {
            if (celerityInputTable == null)
            {
                return -1;
            }
            if (_celerityInputTables.ContainsKey(celerityInputTable.TableName))
            {
                _celerityInputTables[celerityInputTable.TableName] = celerityInputTable;
            }
            else
            {
                return -2;
            }
            return 1;
        }

        public void RefreshCustomControls()
        {
            foreach (Control control in Controls)
            {
                if (control is CustomControl)
                {
                    if (_celerityInputTables != null && _celerityInputTables.ContainsKey((control as CustomControl).SourceTableName))
                    {
                        DataTable table = _celerityInputTables[(control as CustomControl).SourceTableName] as DataTable;
                        if (table != null)
                        {
                            (control as CustomControl).SetTable(table);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 刷新报表容器设置信息
        /// </summary>
        public void RefreshSettings(Com.MedicalSystem.Icu.DataSetModel.CareDocs.MED_DOCUMENT_DESIGN_MAINRow main, Com.MedicalSystem.Icu.DataSetModel.CareDocs.MED_DOCUMENT_DESIGN_DETAILDataTable detail)
        {
            InitControl(main, detail);
        }
        /// <summary>
        /// 使所有选中组件左对齐
        /// </summary>
        public void AlignLeft()
        {
            if (_selectControls.Count > 0)
            {
                int MinLeft = _selectControls[0].Left;
                foreach (Control Control1 in _selectControls)
                {
                    if (Control1.Left < MinLeft)
                    {
                        MinLeft = Control1.Left;
                    }
                }
                foreach (Control Control1 in _selectControls)
                {
                    Control1.Left = MinLeft;
                }
            }
        }
        /// <summary>
        /// 使所有选中组件右对齐
        /// </summary>
        public void AlignRight()
        {
            if (_selectControls.Count > 0)
            {
                int MaxRight = _selectControls[0].Left + _selectControls[0].Width;
                foreach (Control Control1 in _selectControls)
                {
                    if (Control1.Left + Control1.Width > MaxRight)
                    {
                        MaxRight = Control1.Left + Control1.Width;
                    }
                }
                foreach (Control Control1 in _selectControls)
                {
                    Control1.Left = MaxRight - Control1.Width;
                }
            }
        }
        /// <summary>
        /// 使所有选中组件上对齐
        /// </summary>
        public void AlignTop()
        {
            if (_selectControls.Count > 0)
            {
                int MinTop = _selectControls[0].Top;
                foreach (Control Control1 in _selectControls)
                {
                    if (Control1.Top < MinTop)
                    {
                        MinTop = Control1.Top;
                    }
                }
                foreach (Control Control1 in _selectControls)
                {
                    Control1.Top = MinTop;
                }
            }
        }
        /// <summary>
        /// 使所有选中组件宽度相同
        /// </summary>
        public void AlignWidth()
        {
            if (_selectControls.Count > 0)
            {
                int MaxWidth = _selectControls[0].Width;
                foreach (Control Control1 in _selectControls)
                {
                    if (MaxWidth < Control1.Width)
                    {
                        MaxWidth = Control1.Width;
                    }
                }
                foreach (Control Control1 in _selectControls)
                {
                    Control1.Width = MaxWidth;
                }
            }
        }
        /// <summary>
        /// 使所有选中所见水平间距相等
        /// </summary>
        public void SetLevelSpace()
        {
            if (_selectControls.Count > 0)
            {
                int SumWidth = 0;
                int Space = 0;
                int Left = 0;
                _selectControls.Sort(CompareByLeft);
                int MinLeft = _selectControls[0].Left;
                int MaxLeft = _selectControls[_selectControls.Count - 1].Left + _selectControls[_selectControls.Count - 1].Width;
                foreach (Control Control1 in _selectControls)
                {
                    SumWidth += Control1.Width;
                }
                if (MaxLeft - MinLeft > SumWidth)
                {
                    Space = (MaxLeft - MinLeft - SumWidth) / (_selectControls.Count - 1);
                }
                foreach (Control Control1 in _selectControls)
                {
                    if (Control1.Left == MinLeft)
                    {
                        Left += MinLeft + Control1.Width + Space;
                        continue;
                    }
                    Control1.Left = Left;
                    Left += Control1.Width + Space;
                }
            }
        }

        /// <summary>
        /// 使所有选中所见垂直间距相等
        /// </summary>
        public void SetUprightSpace()
        {
            if (_selectControls.Count > 0)
            {
                int SumHeight = 0;
                int Space = 0;
                int Top = 0;
                _selectControls.Sort(CompareByTop);
                int MinTop = _selectControls[0].Top;
                int MaxTop = _selectControls[_selectControls.Count - 1].Top + _selectControls[_selectControls.Count - 1].Height;
                foreach (Control Control1 in _selectControls)
                {
                    SumHeight += Control1.Height;
                }
                if (MaxTop - MinTop > SumHeight)
                {
                    Space = (MaxTop - MinTop - SumHeight) / (_selectControls.Count - 1);
                }
                foreach (Control Control1 in _selectControls)
                {
                    if (Control1.Top == MinTop)
                    {
                        Top += MinTop + Control1.Height + Space;
                        continue;
                    }
                    Control1.Top = Top;
                    Top += Control1.Height + Space;
                }
            }
        }

        public override void DrawGraphics(Graphics g)
        {
            if (_isDesignMode && _drawBorder)
            {
                Rectangle rect = ClientRectangle;
                rect.Width += -1;
                rect.Height += -1;
                Pen P = new Pen(_borderColor);
                g.DrawRectangle(P, rect);
            }
            else
            {
                base.DrawGraphics(g);
            }
        }

        /// <summary>
        /// 恢复TextBox的前景色
        /// </summary>
        public void RevertTextBoxForeColor()
        { 
            foreach(Control Control1 in this.Controls)
            {
                if(Control1 is MedTextBox)
                {
                    (Control1 as MedTextBox).ForeColor = (Control1 as MedTextBox).OldForeColor;
                }
            }
            _dataIsChanged = false;
        }

        public void Copy()
        {
            if (_selectControls.Count > 0)
            {
                List<DesignableField> list = new List<DesignableField>();
                foreach (Control control in _selectControls)
                {
                    list.Add( new DesignableField(control));
                }
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter format = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                format.Serialize(ms, list);
                ms.Position = 0;
                Clipboard.SetData("Text", Sundries.EncodeWithString(ms));
            }
        }

        public void Paste()
        {
            try
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter format = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                object obj = format.Deserialize(Sundries.DecodeWithString(Clipboard.GetText()));
                if (obj is List<DesignableField>)
                {
                    List<DesignableField> list = obj as List<DesignableField>;
                    AddControl(list.ToArray());
                }
            }
            catch { }
        }

        #endregion

        #region 事件

        private void ReportDesignControl_DragEnter(object sender, DragEventArgs e)
        {
            if (_isDesignMode && e.Data.GetDataPresent(typeof(DesignableField)))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void ReportDesignControl_DragDrop(object sender, DragEventArgs e)
        {
            if (_isDesignMode && e.Data.GetDataPresent(typeof(DesignableField)))
            {
                Control[] controls = AddControl(new DesignableField[]{((DesignableField)e.Data.GetData(typeof(DesignableField)))});
                if (controls != null)
                {
                    foreach (Control control in controls)
                    {
                        control.Location = PointToClient(new Point(e.X, e.Y));
                    }
                }
            }
        }
        
        #endregion 事件

        public EventHandler Loaded;
        private void MedReportDesignControl_Load(object sender, EventArgs e)
        {
            //RefreshSettings();
            if (Loaded != null)
            {
                Loaded(sender, e);
            }
        }
    }
}
