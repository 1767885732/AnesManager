using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using Com.MedicalSystem.Common.Utilities;

namespace Com.ICIS.Common.Controls
{
    public class MyVariables
    {
        private static string _deptName = "";
        [Description("科室名称")]
        public static string DeptName
        {
            get
            {
                return _deptName;
            }
            set
            {
                _deptName = value;
            }
        }

        private static string _operName = "";
        [Description("手术名称")]
        public static string OperName
        {
            get
            {
                return _operName;
            }
            set
            {
                _operName = value;
            }
        }

        private static string _totalInBlood = "0";
        [Description("总输血量")]
        public static string TotalInBlood
        {
            get
            {
                return _totalInBlood;
            }
            set
            {
                _totalInBlood = value;
            }
        }
        private static string _totalInLiquid = "0";
        [Description("总输液量")]
        public static string TotalInLiquid
        {
            get
            {
                return _totalInLiquid;
            }
            set
            {
                _totalInLiquid = value;
            }
        }

        private static string _totalNiaoLiang = "0";
        [Description("累计尿量")]
        public static string TotalNiaoLiang
        {
            get
            {
                return _totalNiaoLiang;
            }
            set
            {
                _totalNiaoLiang = value;
            }
        }

        [Description("总输入量")]
        public static string TotalIn
        {
            get
            {
                double totalIn = double.Parse(_totalInLiquid) + double.Parse(_totalInBlood);
                return totalIn.ToString();
            }
        }

        private static string _operationStartTime = "";
        [Description("手术开始时间")]
        public static string OperationStartTime
        {
            get
            {
                return _operationStartTime;
            }
            set
            {
                _operationStartTime = value;
            }
        }

        private static string _operationEndTime = "";
        [Description("手术结束时间")]
        public static string OperationEndTime
        {
            get
            {
                return _operationEndTime;
            }
            set
            {
                _operationEndTime = value;
            }
        }

        private static string _pageIndex = "";
        [Description("页码")]
        public static string PageIndex
        {
            get
            {
                return _pageIndex;
            }
            set
            {
                _pageIndex = value;
            }
        }

        private static string _pageCount = "";
        [Description("页数")]
        public static string PageCount
        {
            get
            {
                return _pageCount;
            }
            set
            {
                _pageCount = value;
            }
        }
    }

    [Serializable]
    public class DesignableField
    {
        #region 枚举
        public enum ClassType
        {
            Lable,
            TextBox,
            Line,
            RichTextBox,
            GrdiView,
            CustomControl
        }
        #endregion

        #region 私有变量
        private ClassType _classType;
        private bool _allowDrag;
        private bool _multiSign = false;
        private string _dataFieldName;
        private string _tableName;
        private string _viewText;
        private string _hint;
        private string _celerityInputTableName = string.Empty;
        private string _celerityInputValueColumnName = string.Empty;
        private string _celerityInputCodeColumnName = string.Empty;
        private string _celerityInputSqlWhere = string.Empty;
        private string _bindList = string.Empty;
        #endregion

        #region 构造函数
        public DesignableField(ClassType classType)
        {
            _classType = classType;
        }
        public DesignableField(Control control)
        {
            FromControl(control);
        }

        #endregion

        #region 属性
        [Description("控件类型"), Category("数据")]
        public ClassType Type
        {
            set
            {
                _classType = value;
            }
            get
            {
                return _classType;
            }
        }

        private string _name;
        [Description("名称"), Category("行为")]
        public string Name
        {
            set
            {
                _name = value;
            }
            get
            {
                return _name;
            }
        }

        private string _text;
        [Description("文本"), Category("行为")]
        public string Text
        {
            set
            {
                _text = value;
            }
            get
            {
                return _text;
            }
        }

        //[Description("允许拖动"), Category("行为")]
        public bool AllowDrag
        {
            set
            {
                _allowDrag = value;
            }
            get
            {
                return _allowDrag;
            }
        }

        //[Description("工具提示")]
        public string Hint
        {
            set
            {
                _hint = value;
            }
            get
            {
                return _hint;
            }
        }

        /// <summary>
        /// 快速录入绑定表名 
        /// </summary>
        [Description("字典表名"), Category("数据")]
        public string CelerityInputTableName
        {
            set
            {
                _celerityInputTableName = value;
            }
            get
            {
                return _celerityInputTableName;
            }
        }

        /// <summary>
        /// 快速录入绑定值字段名
        /// </summary>
        [Description("字典值字段"), Category("数据")]
        public string CelerityInputValueColumnName
        {
            set
            {
                _celerityInputValueColumnName = value;
            }
            get
            {
                return _celerityInputValueColumnName;
            }
        }
        /// <summary>
        /// 快速录入绑定拼音字段名
        /// </summary>
        [Description("字典字段名"), Category("数据")]
        public string CelerityInputCodeColumnName
        {
            set
            {
                _celerityInputCodeColumnName = value;
            }
            get
            {
                return _celerityInputCodeColumnName;
            }
        }
        /// <summary>
        /// 快速录入过滤条件
        /// </summary>
        [Description("字典过滤条件"), Category("数据")]
        public string CelerityInputSqlWhere
        {
            set
            {
                _celerityInputSqlWhere = value;
            }
            get
            {
                return _celerityInputSqlWhere;
            }
        }
        /// <summary>
        /// 下拉框绑定列表，用@分割
        /// </summary>
        [Description("下拉列表(@分割)"), Category("数据")]
        public string BindList
        {
            set
            {
                _bindList = value;
            }
            get
            {
                return _bindList;
            }
        }
        /// <summary>
        /// 下拉框绑定类型标志位，真为多选，假为单选
        /// </summary>
        [Description("多选"), Category("数据")]
        public bool MultiSign
        {
            set
            {
                _multiSign = value;
            }
            get
            {
                return _multiSign;
            }
        }
        /// <summary>
        /// 绑定字段名
        /// </summary>
        [Description("字段名")]
        public string DataFieldName
        {
            set
            {
                _dataFieldName = value;
            }
            get
            {
                return _dataFieldName;
            }
        }   
        /// <summary>
        /// 绑定表名
        /// </summary>
        [Description("表名")]
        public string TableName
        {
            set
            {
                _tableName = value;
            }
            get
            {
                return _tableName;
            }
        }

        [Browsable(false)]
        public string ViewText
        {
            set
            {
                _viewText = value;
            }
            get
            {
                return _viewText;
            }
        }

        private Color _color = Color.Black;
        [Description("颜色")]
        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }
        private Color _backColor = System.Drawing.SystemColors.Window;
        [Description("背景颜色")]
        public Color BackColor
        {
            get
            {
                return _backColor;
            }
            set
            {
                _backColor = value;
            }
        }

        private DevExpress.XtraEditors.Controls.BorderStyles _border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
        [Description("边框样式")]
        public DevExpress.XtraEditors.Controls.BorderStyles Border
        {
            get
            {
                return _border;
            }
            set
            {
                _border = value;
            }
        }

        private Font _font = new Font("宋体", 12);
        [Description("字体")]
        public Font Font
        {
            get
            {
                return _font;
            }
            set
            {
                _font = value;
            }
        }

        private int _left = 0;
        [Description("左边距")]
        public int Left
        {
            get
            {
                return _left;
            }
            set
            {
                _left = value;
            }
        }

        private int _top = 0;
        [Description("顶边距")]
        public int Top
        {
            get
            {
                return _top;
            }
            set
            {
                _top = value;
            }
        }

        private int _width = 80;
        [Description("宽度")]
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        private int _height = 15;
        [Description("高度")]
        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        private bool _multiLine = false;
        [Description("多行")]
        public bool MultiLine
        {
            get
            {
                return _multiLine;
            }
            set
            {
                _multiLine = value;
            }
        }

        private DevExpress.Utils.WordWrap _wordWrap = DevExpress.Utils.WordWrap.NoWrap;
        [Description("自动换行")]
        public DevExpress.Utils.WordWrap WordWrap
        {
            get
            {
                return _wordWrap;
            }
            set
            {
                _wordWrap = value;
            }
        }

        private bool _readOnly = false;
        [Description("只读")]
        public bool ReadOnly
        {
            get
            {
                return _readOnly;
            }
            set
            {
                _readOnly = value;
            }
        }

        private string _defaultPrintText;
        [Description("默认打印文本")]
        public string DefaultPrintText
        {
            get
            {
                return string.IsNullOrEmpty(_defaultPrintText) ? "" : _defaultPrintText;
            }
            set
            {
                _defaultPrintText = value;
            }
        }

        private string _noPrintText;
        [Description("不打印文本")]
        public string NoPrintText
        {
            get
            {
                return string.IsNullOrEmpty(_noPrintText) ? "" : _noPrintText;
            }
            set
            {
                _noPrintText = value;
            }
        }

        private MedSymbolType _symbolType = MedSymbolType.None;
        [Description("标识类型")]
        public MedSymbolType SymbolType
        {
            get
            {
                return _symbolType;
            }
            set
            {
                _symbolType = value;
            }
        }

        private Image _image;
        [Description("图像")]
        public Image Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
            }
        }

        private bool _isDrawAll = false;
        [Description("绘制所有")]
        public bool IsDrawAll
        {
            get
            {
                return _isDrawAll;
            }
            set
            {
                _isDrawAll = value;
            }
        }

        private Color _printColor = Color.Black;
        [Description("打印颜色")]
        public Color PrintColor
        {
            get
            {
                return _printColor;
            }
            set
            {
                _printColor = value;
            }
        }

        #endregion        

        private void FromControl(Control control)
        {
            if (control is MedLabel)
            {
                MedLabel label = control as MedLabel;
                _classType = ClassType.Lable;
                _multiLine = label.MultiLine;
                _text = label.Text;
                _left = label.Left;
                _color = label.ForeColor;
                _font = label.Font;
                _width = label.Width;
                _height = label.Height;
                _top = label.Top;
                _symbolType = label.SymbolType;
                _backColor = label.BackColor;
                if (!string.IsNullOrEmpty(label.Name) && !label.Name.Equals("MedLabel"))
                {
                    _name = label.Name;
                }
                _image = label.Appearance.Image;
            }
            else if (control is MedTextBox)
            {
                MedTextBox textBox = control as MedTextBox;
                _classType = ClassType.TextBox;
                _left = textBox.Left;
                _color = textBox.ForeColor;
                _font = textBox.Font;
                _width = textBox.Width;
                _height = textBox.Height;
                _top = textBox.Top;
                _tableName = textBox.BindTableName;
                _dataFieldName = textBox.BindFieldName;
                _celerityInputTableName = textBox.CelerityInputTableName;
                _celerityInputValueColumnName = textBox.CelerityInputValueColumnName;
                _celerityInputCodeColumnName = textBox.CelerityInputCodeColumnName;
                _celerityInputSqlWhere = textBox.CelerityInputSqlWhere;
                _bindList = textBox.BindList;
                _multiSign = textBox.MultiSign;
                _multiLine = textBox.Properties.AutoHeight;//.Multiline;
                _text = textBox.Text;
                _wordWrap = textBox.Properties.Appearance.TextOptions.WordWrap;//.WordWrap;
                _readOnly = textBox.Properties.ReadOnly;
                _defaultPrintText = textBox.DefaultPrintText;
                _noPrintText = textBox.NoPrintText;
                _backColor = textBox.BackColor;
                _border = textBox.BorderStyle;
            }
            else if (control is CustomControl)
            {
                CustomControl customControl = control as CustomControl;
                _classType = ClassType.CustomControl;
                _left = customControl.Left;
                _color = customControl.ForeColor;
                _font = customControl.Font;
                _width = customControl.Width;
                _height = customControl.Height;
                _top = customControl.Top;
                _tableName = customControl.TableName;
                _dataFieldName = customControl.FieldName;
                _celerityInputTableName = customControl.SourceTableName;
                _celerityInputValueColumnName = customControl.ValueFieldName;
                _celerityInputCodeColumnName = customControl.DisplayFieldName;
                _celerityInputSqlWhere = customControl.SqlWhereFilter;
                _multiSign = customControl.MultiSelect;
                _isDrawAll = customControl.IsDrawAll;
                _text = customControl.Name;
                _defaultPrintText = customControl.DefaultPrintText;
                _printColor = customControl.PrintColor;
                _backColor = customControl.BackColor;
            }
            else if (control is Panel)
            {
                Panel panel = control as Panel;
                _classType = ClassType.Line;
                _left = panel.Left;
                _color = panel.ForeColor;
                _font = panel.Font;
                _width = panel.Width;
                _height = panel.Height;
                _top = panel.Top;
                _backColor = panel.BackColor;
            }
        }

        #region 公有方法

        public void UpdateControl(Control control)
        {
            switch (_classType)
            {
                case ClassType.Lable:
                    control.Text = _text;
                    control.Width = _width;
                    control.Height = _height;
                    control.Left = _left;
                    control.Top = _top;
                    control.Font = _font;
                    control.ForeColor = _color;
                    control.BackColor = _backColor;
                    (control as MedLabel).SymbolType = _symbolType;
                    (control as MedLabel).Appearance.Image = _image;
                    (control as MedLabel).MultiLine = _multiLine;
                    (control as MedLabel).AutoSize = true;
                    control.Name = _name;
                    (control as MedLabel).BorderStyle = _border;
                    break;
                case ClassType.CustomControl:
                    CustomControl custonControl = control as CustomControl;
                    custonControl.Width = _width;
                    custonControl.Height = _height;
                    custonControl.Left = _left;
                    custonControl.Top = _top;
                    custonControl.Font = _font;
                    custonControl.ForeColor = _color;
                    custonControl.BackColor = _backColor;
                    custonControl.TableName = _tableName;
                    custonControl.FieldName = _dataFieldName;
                    custonControl.SourceTableName = _celerityInputTableName;
                    custonControl.DisplayFieldName = _celerityInputCodeColumnName;
                    custonControl.ValueFieldName = _celerityInputValueColumnName;
                    custonControl.SqlWhereFilter = _celerityInputSqlWhere;
                    custonControl.MultiSelect = _multiSign;
                    custonControl.IsDrawAll = _isDrawAll;
                    control.Text = _text;
                    control.Name = _text;
                    custonControl.DefaultPrintText = _defaultPrintText;
                    custonControl.PrintColor = _printColor;
                    break;
                case ClassType.TextBox:
                    control.Text = _text;
                    control.Width = _width;
                    control.Height = _height;
                    control.Left = _left;
                    control.Top = _top;
                    control.Font = _font;
                    control.ForeColor = _color;
                    control.BackColor = _backColor;
                    (control as MedTextBox).BorderStyle = _border;
                    (control as MedTextBox).BindTableName = _tableName;
                    (control as MedTextBox).BindFieldName = _dataFieldName;
                    (control as MedTextBox).CelerityInputTableName = _celerityInputTableName;
                    (control as MedTextBox).CelerityInputValueColumnName = _celerityInputValueColumnName;
                    (control as MedTextBox).CelerityInputCodeColumnName = _celerityInputCodeColumnName;
                    (control as MedTextBox).CelerityInputSqlWhere = _celerityInputSqlWhere;
                    (control as MedTextBox).BindList = _bindList;
                    (control as MedTextBox).MultiSign = _multiSign;
                    //(control as MedTextBox).Multiline = _multiLine;
                    //(control as MedTextBox).WordWrap = _wordWrap;
                    //(control as MedTextBox).ReadOnly = _readOnly;
                    (control as MedTextBox).Properties.AutoHeight = _multiLine;
                    (control as MedTextBox).Properties.Appearance.TextOptions.WordWrap = _wordWrap;
                    (control as MedTextBox).Properties.ReadOnly = _readOnly;
                    (control as MedTextBox).DefaultPrintText = _defaultPrintText;
                    (control as MedTextBox).NoPrintText = _noPrintText;
                    break;
                case ClassType.Line:
                    control.BackColor = _color;
                    control.Width = _width;
                    control.Height = 2;
                    control.Left = _left;
                    control.Top = _top;
                    control.Name = "线";
                    //(control as Panel).BorderStyle = BorderStyle.FixedSingle;
                    break;
                case ClassType.RichTextBox:
                    //control.BackColor = _backColor;
                    control.Width = 300;
                    control.Height = 100;
                    break;
                case ClassType.GrdiView:
                    //control.BackColor = this.BackColor;
                    control.Width = 400;
                    control.Height = 200;
                    break;
            }
        }

        public Control GenControl()
        {
            Control control = null;
            switch (_classType)
            {
                case ClassType.Lable:
                    control = new MedLabel();
                    break;
                case ClassType.TextBox:
                    control = new MedTextBox();
                    break;
                case ClassType.Line:
                    control = new Panel();
                    break;
                case ClassType.RichTextBox:
                    control = new RichTextBox();
                    //control.BackColor = _backColor;
                    control.Name = "文本编辑";
                    break;
                case ClassType.GrdiView:
                    int RowCount = 0;
                    object Result = Dialog.SingleInputSelect("每页显示行数？0为不限制。", RowCount);
                    if (Result != null)
                    {
                        int.TryParse(Result.ToString(), out RowCount);
                    }
                    control = new MedDataGridView();
                    (control as MedDataGridView).ReadOnly = true;
                    //control.BackColor = this.BackColor;
                    control.Name = "数据表格";
                    (control as MedDataGridView).RowCount = RowCount;
                    break;
                case ClassType.CustomControl:
                    control = new CustomControl();
                    break;
            }
            if (control != null)
            {
                UpdateControl(control);
            }
            return control;
        }

        #endregion 
    }
}
