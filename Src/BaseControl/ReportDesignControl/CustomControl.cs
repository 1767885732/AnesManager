using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Com.ICIS.Common.Controls
{
    public partial class CustomControl : UserControl
    {
        public CustomControl()
        {
            InitializeComponent();
        }

        #region 公用事件接口

        private static readonly object _valueChanged = new object();
        public event EventHandler ValueChanged
        {
            add
            {
                Events.AddHandler(_valueChanged, value);
            }
            remove
            {
                Events.RemoveHandler(_valueChanged, value);
            }
        }

        #endregion 公用事件接口

        #region 私有变量

        private DataRow[] _dataRows;

        #endregion 私有变量

        #region 属性
        private string _fieldName;
        public string FieldName
        {
            get
            {
                return _fieldName;
            }
            set
            {
                _fieldName = value;
            }
        }

        private string _tableName;
        public string TableName
        {
            get
            {
                return _tableName;
            }
            set
            {
                _tableName = value;
            }
        }

        private string _sourceTableName;
        public string SourceTableName
        {
            get
            {
                return _sourceTableName;
            }
            set
            {
                _sourceTableName = value;
            }
        }

        private string _displayFieldName;
        public string DisplayFieldName
        {
            get
            {
                return _displayFieldName;
            }
            set
            {
                _displayFieldName = value;
            }
        }

        private string _valueFieldName;
        public string ValueFieldName
        {
            get
            {
                return _valueFieldName;
            }
            set
            {
                _valueFieldName = value;
            }
        }

        private string _sqlWhereFilter;
        public string SqlWhereFilter
        {
            get
            {
                return string.IsNullOrEmpty(_sqlWhereFilter)?"":_sqlWhereFilter;
            }
            set
            {
                _sqlWhereFilter = value;
            }
        }

        private bool _multiSelect = false;
        public bool MultiSelect
        {
            get
            {
                return _multiSelect;
            }
            set
            {
                _multiSelect = value;
            }
        }

        private string _value;
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }


        private Font _font = new Font("宋体", 9);
        public new Font Font
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

        private bool _isDrawAll = false;
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

        private string _defaultPrintText;
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

        private Color _printColor = Color.Black;
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

        #endregion 属性

        public void SetTable(DataTable dataTable)
        {
            //List<string> list = new List<string>();
            _dataRows = null;
            if (!string.IsNullOrEmpty(_sqlWhereFilter))
            {
                _dataRows = dataTable.Select(_sqlWhereFilter);
            }
            else
            {
                _dataRows = dataTable.Select();
            }
            if (_dataRows != null)
            {
                if (dataTable.TableName.Equals("MedAnesthesiaInputDict"))
                {
                    List<DataRow> rows = new List<DataRow>(_dataRows);
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
                    _dataRows = rows.ToArray();
                }
                //foreach (DataRow row in _dataRows)
                //{
                //    list.Add(row[_displayFieldName].ToString());
                //}
                //SetList(list);
                SetList();
            }
            if (!string.IsNullOrEmpty(_value))// _value != null)
            {
                if (_dataRows != null && !string.IsNullOrEmpty(_displayFieldName))
                {
                    if (_multiSelect)
                    {
                        string vv = "," + _value.ToString() + ",";
                        for (int i = 0; i < _dataRows.Length; i++)
                        {
                            if (vv.Contains("," + _dataRows[i][_displayFieldName].ToString() + ","))
                            {
                                (Controls[string.Format("Control{0}", new object[] { i })] as CheckBox).Checked = true;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < _dataRows.Length; i++)
                        {
                            try
                            {
                                if (_dataRows[i][_valueFieldName].Equals(_value))
                                {
                                    (Controls[string.Format("Control{0}", new object[] { i })] as RadioButton).Checked = true;
                                }
                            }
                            catch (Exception ex)
                            {
                                string a = ex.Message;
                            }
                        }
                    }
                }
            }
        }

        public List<string> GetList()
        {
            List<string> list = new List<string>();
            if (_dataRows != null && _dataRows.Length > 0)
            {
                for (int index = 0; index < _dataRows.Length; index++)
                {
                    list.Add(_dataRows[index][_displayFieldName].ToString());
                }
            }
            return list;
        }

        int xOffSet = 19;
        private void SetList()
        {
            Controls.Clear();
            Control control = null;
            int top = 0;
            int left = 0;
            //int controlIndex = 0;
            for (int index = 0; index < _dataRows.Length; index++)
            {
                string text = _dataRows[index][_displayFieldName].ToString();
                if (_multiSelect)
                {
                    control = new CheckBox();
                    CheckBox checkBox = control as CheckBox;
                    checkBox.AutoSize = false;
                    checkBox.Text = text;
                    checkBox.Tag = index;
                    checkBox.Click += new EventHandler(checkBox_Click);
                    checkBox.Paint += new PaintEventHandler(checkBox_Paint);
                }
                else
                {
                    control = new RadioButton();
                    RadioButton radio = control as RadioButton;
                    radio.AutoSize = true;
                    radio.Text = text;
                    radio.Tag = index;
                    radio.Click += new EventHandler(radio_Click);
                }
                control.Font = _font;
                control.ForeColor = ForeColor;
                //control.Name = string.Format("Control{0}", new object[] { controlIndex++ });
                control.Name = string.Format("Control{0}", new object[] { index});
                if (left + xOffSet + (int)control.CreateGraphics().MeasureString(text, _font).Width > Width)
                {
                    left = 0;
                    top += 15;
                }
                else
                {
                }
                control.Top = top - 3;
                control.Left = left;
                control.Width = xOffSet + (int)control.CreateGraphics().MeasureString(text, _font).Width;
                left += xOffSet + (int)control.CreateGraphics().MeasureString(text, _font).Width;
                Controls.Add(control);
            }
            if (Controls.Count > 0) toolTip1.SetToolTip(this, null);
        }

        private void checkBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            CheckBox checkBox = sender as CheckBox;
            Rectangle rect = checkBox.ClientRectangle;
            rect.X = rect.X + xOffSet;
            g.FillRectangle(Brushes.White,rect );
            g.DrawString(checkBox.Text, checkBox.Font, new SolidBrush(checkBox.ForeColor), rect.X, rect.Y + 5);
        }

        private void RaiseValueChanged()
        {
            EventHandler eventHandle = Events[_valueChanged] as EventHandler;
            if (eventHandle != null)
            {
                eventHandle(this, null);
            }
        }

        private void CustomControl_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                if ((Parent == null) || !(Parent is MedReportDesignControl) || (Parent as MedReportDesignControl).IsDesignMode)
                {
                    string text = _tableName + "[" + _fieldName + "]:" + (_multiSelect ? "多选" : "单选");
                    toolTip1.SetToolTip(this, text);
                }
            }
        }

        private void radio_Click(object sender, EventArgs e)
        {
            string value = _dataRows[(int)(sender as RadioButton).Tag][_valueFieldName].ToString();
            if (!value.Equals(_value))
            {
                _value = value;
                RaiseValueChanged();
            }
        }

        private void checkBox_Click(object sender, EventArgs e)
        {
            string value = "";
            foreach (Control control in Controls)
            {
                if (control is CheckBox)
                {
                    CheckBox checkBox = control as CheckBox;
                    if (checkBox.Checked)
                    {
                        value += "," + checkBox.Text;
                    }
                }
            }
            if (!string.IsNullOrEmpty(value))
            {
                value = value.Substring(1);
            }
            if (!value.Equals(_value))
            {
                _value = value;
                RaiseValueChanged();
            }
        }

        public void DrawGraphics(Graphics g,float x,float y)
        {
            string checkStr = "√";
            float left = x;
            float top = y;
            foreach (Control ctl in Controls)
            {
                if (ctl is CheckBox)
                {
                    if ((ctl as CheckBox).Checked)
                    {
                        g.DrawString(checkStr, Font, new SolidBrush(ForeColor), left, top);
                    }
                    Rectangle rect = new Rectangle();
                    rect.X = 2 + (int)left;
                    rect.Y = (int)top;
                    rect.Width = -5 + (int)g.MeasureString(checkStr, Font).Width;
                    rect.Height = rect.Width;
                    g.DrawRectangle(new Pen(ForeColor),rect);
                    float xOffSet = g.MeasureString(checkStr, Font).Width;
                    g.DrawString(ctl.Text, Font, new SolidBrush(ForeColor), left + xOffSet, top);
                    left += xOffSet + g.MeasureString(ctl.Text, Font).Width;
                }
            }
        }

        private void CustomControl_DoubleClick(object sender, EventArgs e)
        {
            foreach (Control control in Controls)
            {
                if (control is RadioButton)
                {
                    (control as RadioButton).Checked = false;
                }
                _value = "";
                RaiseValueChanged();
            }
        }

        private void CustomControl_Paint(object sender, PaintEventArgs e)
        {
            if (Controls.Count == 0)
            {
                string text = toolTip1.GetToolTip(this);
                if(!string.IsNullOrEmpty(text))
                e.Graphics.DrawString(text , Font, new SolidBrush(ForeColor), 0, 0);
            }
        }

    }
}
