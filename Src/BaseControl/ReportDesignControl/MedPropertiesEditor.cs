/*----------------------------------------------------------------
      // Copyright (C) 2008 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：MedPropertiesEditor.cs
      // 文件功能描述：属性编辑器控件

      //
      // 
      // 创建标识：戴呈祥-2008-11-3
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Collections;
using Com.MedicalSystem.Common.Utilities;

namespace Com.ICIS.Common.Controls
{
    /// <summary>
    /// 属性编辑器控件
    /// </summary>
    public partial class MedPropertiesEditor : UserControl
    {

        private enum ButtonType
        {
            Custom,
            Color,
            Font,
            Enum,
            Boolean,
            DateTime,
            Image,
            Border,
            None
        }

        #region 构造方法

        public MedPropertiesEditor()
        {
            InitializeComponent();
            dataGridView1.DefaultCellStyle.Font = new Font("宋体", 9);
        }

        #endregion 构造方法

        #region 事件接口

        /// <summary>
        /// 自定义编辑器事件句柄
        /// </summary>
        /// <param name="sender">事件发起者</param>
        /// <param name="key">属性主键</param>
        public delegate void CustomEditorEventHandle(object sender, string key,object value);

        /// <summary>
        /// 自定义编辑器事件句柄
        /// </summary>
        private readonly static object _customEditorEventHandle = new object();

        /// <summary>
        /// 自定义编辑器事件句柄
        /// </summary>
        private readonly static object _valueChangedEventHandle = new object();

        /// <summary>
        /// 自定义编辑器事件
        /// </summary>
        [Description("自定义编辑器事件")]
        public event CustomEditorEventHandle CustomEdit
        {
            add
            {
                Events.AddHandler(_customEditorEventHandle, value);
            }
            remove
            {
                Events.RemoveHandler(_customEditorEventHandle, value);
            }
        }

        /// <summary>
        /// 值改变事件
        /// </summary>
        [Description("值改变事件")]
        public event CustomEditorEventHandle ValueChanged
        {
            add
            {
                Events.AddHandler(_valueChangedEventHandle, value);
            }
            remove
            {
                Events.RemoveHandler(_valueChangedEventHandle, value);
            }
        }

        #endregion 事件接口

        #region 常量

        #endregion 常量

        #region 变量

        private object _editObject;
        private ButtonType _buttonType = ButtonType.None;

        private int lastRowIndex = -1;

        #endregion 变量

        #region 属性

        public object EditObject
        {
            get
            {
                return _editObject;
            }
            set
            {
                _editObject = value;
                Reset();
            }
        }

        public int KeyWidth
        {
            get
            {
                return BandName.Width;
            }
            set
            {
                BandName.Width = value;
            }
        }

        #endregion 属性

        #region 方法

        public void Clear()
        {
            dataGridView1.Rows.Clear();
        }

        public void AddItem(string key, object value)
        {
            dataGridView1.Rows.Add(new object[] { key,value});
        }

        private void ShowButton()
        {
            DataGridViewCell cell = dataGridView1.CurrentCell;
            if(cell == null)return;
            Rectangle rect = dataGridView1.GetCellDisplayRectangle(cell.ColumnIndex, cell.RowIndex, true);
            btnChangeValue.Left = rect.Right - btnChangeValue.Width;
            btnChangeValue.Top = rect.Top;
            btnChangeValue.Height = rect.Height;
            btnChangeValue.Visible = true;
        }

        private ButtonType GetCellButtonType(DataGridViewCell cell)
        {
            if (cell != null)
            {
                Type cellType = _editObject.GetType().GetProperty(dataGridView1.Rows[cell.RowIndex].Cells[0].Value.ToString()).PropertyType;
                if (cellType.Equals(typeof(Color)))
                {
                    return ButtonType.Color;
                }
                else if (cellType.Equals(typeof(Font)))
                {
                    return ButtonType.Font;
                }
                else if (cellType.Equals(typeof(DateTime)))
                {
                    return ButtonType.DateTime;
                }
                else if (cellType.IsEnum)
                {
                    return ButtonType.Enum;
                }
                else if (cellType.Equals(typeof(bool)))
                {
                    return ButtonType.Boolean;
                }
                else if (cellType.Equals(typeof(Image)))
                {
                    return ButtonType.Image;
                }
                else if (cellType.Equals(typeof(BorderStyle)))
                {
                    return ButtonType.Border;
                }
                else if (cellType.Equals(typeof(int)) || cellType.Equals(typeof(string)) || cellType.Equals(typeof(float)) || cellType.Equals(typeof(double)))
                {
                    return ButtonType.None;
                }
            }
            return ButtonType.Custom;
        }

        private void Reset()
        {
            Clear();
            btnChangeValue.Visible = false;
            object editObject = _editObject;
            if (editObject == null) return;
            Type type = editObject.GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                string key = property.Name;
                if(GetDescription(key) != key)
                {
                    AddItem(key, property.GetValue(editObject, null));
                }
            }
            MedPropertiesEditor_Resize(null, null);
        }

        private bool SetValue(string key,object value)
        {
            object editObject = _editObject;
            if (editObject == null) return false;
            Type type = editObject.GetType();
            PropertyInfo property = type.GetProperty(key);
            try
            {
                AssemblyHelper.SetPropertyValue(property, editObject, value);
                return true;
            }
            catch (Exception ex)
            {
                Dialog.MessageBox(ex.Message, MessageBoxIcon.Error);
                return false;
            }
        }

        private object GetValue(string key)
        {
            object editObject = _editObject;
            if (editObject == null) return null;
            Type type = editObject.GetType();
            PropertyInfo property = type.GetProperty(key);
            try
            {
                object value = AssemblyHelper.GetPropertyValue(property, editObject);
                return value;
            }
            catch (Exception ex)
            {
                Dialog.MessageBox(ex.Message, MessageBoxIcon.Error);
                return null;
            }
        }

        private string GetDescription(string key)
        {
            object editObject = _editObject;
            if (editObject == null) return key;
            Type type = editObject.GetType();
            MemberInfo[] memberInfos = type.GetMember(key);
            if (memberInfos != null && memberInfos.Length > 0)
            {
                object[] objs = memberInfos[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (objs != null && objs.Length > 0)
                {
                    return ((DescriptionAttribute)objs[0]).Description;
                }
            }
            return key;
        }

        private string GetEnumName(Enum enumValue)
        {
            List<MemberDetail> enumList = AssemblyHelper.GetEnumList(enumValue.GetType());
            foreach (MemberDetail enumDetail in enumList)
            {
                if(enumDetail.Value.Equals(enumValue))
                {
                    return enumDetail.Name;
                }
            }
            return enumValue.ToString();
        }

        private string GetBooleanName(bool value)
        {
            return value?"真":"假";
        }

        public void Popup(List<MemberDetail> lst)
        {
            Rectangle rect = dataGridView1.GetCellDisplayRectangle(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex, true);
            Dialog.ShowCustomSelection(lst, "Name", dataGridView1, new Point(rect.Left, rect.Bottom), new Size(rect.Width, 300)
                , new EventHandler(delegate(object sender1, EventArgs e1)
            {
                if (sender1 is int)
                {
                    int index = (int)sender1;
                    dataGridView1.CurrentCell.Value = lst[index].Value;
                }
            }));
        }

        private void Popup()
        {
            Rectangle rect = dataGridView1.GetCellDisplayRectangle(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex, true);
            Dialog.ShowDateTimeSelector((DateTime)dataGridView1.CurrentCell.Value, this, new Point(rect.Left, rect.Bottom)
                , new EventHandler(delegate(object sender1, EventArgs e1)
            {
                if (sender1 is DateTime)
                {
                    dataGridView1.CurrentCell.Value = (DateTime)sender1;
                }
            }));
        }

        #endregion 方法

        #region 事件

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            btnChangeValue.Visible = false;
            if (e.RowIndex >= 0 && e.ColumnIndex == 0) timer1.Enabled = true;
            ButtonType type = GetCellButtonType(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);
            switch (type)
            {
                case ButtonType.None:
                    break;
                default:
                    _buttonType = type;
                    ShowButton();
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            try
            {
                int rowIndex = dataGridView1.CurrentRow.Index;
                if (lastRowIndex >= 0)
                {
                    rowIndex = lastRowIndex;
                    lastRowIndex = -1;
                }
                dataGridView1.CurrentCell = dataGridView1.Rows[rowIndex].Cells[1];
            }
            catch { }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            Rectangle rect = e.CellBounds;
            string showText;
            Font font = e.CellStyle.Font;
            if (e.ColumnIndex == 0)
            {
                e.Handled = true;
                e.PaintBackground(e.ClipBounds, true);
                showText = GetDescription(e.Value.ToString());
                e.Graphics.DrawString(showText, font, new SolidBrush(e.CellStyle.ForeColor), rect.X, rect.Y + (rect.Height - e.Graphics.MeasureString("A", font).Height) / 2);
            }
            else
            {
                ButtonType type = GetCellButtonType(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                switch (type)
                {
                    case ButtonType.Font:
                        e.Handled = true;
                        e.PaintBackground(e.ClipBounds, true);
                        showText = ((Font)e.Value).Name + "," + ((Font)e.Value).Size.ToString() + "pt";
                        e.Graphics.DrawString(showText, new Font(font.Name, font.Size, ((Font)e.Value).Style), new SolidBrush((e.RowIndex == dataGridView1.CurrentRow.Index) ? e.CellStyle.SelectionForeColor : e.CellStyle.ForeColor), rect.X, rect.Y + (rect.Height - e.Graphics.MeasureString("A", font).Height) / 2);
                        break;
                    case ButtonType.Color:
                        e.Handled = true;
                        e.PaintBackground(e.ClipBounds, true);
                        showText = ((Color)e.Value).Name;
                        Rectangle rect1 = new Rectangle(rect.X + 3, rect.Y + 3, rect.Height - 7, rect.Height - 7);
                        e.Graphics.FillRectangle(new SolidBrush((Color)e.Value), rect1);
                        e.Graphics.DrawRectangle(new Pen(dataGridView1.Columns[0].DefaultCellStyle.BackColor), rect1);
                        e.Graphics.DrawString(showText, font, new SolidBrush((e.RowIndex == dataGridView1.CurrentRow.Index) ? e.CellStyle.SelectionForeColor : e.CellStyle.ForeColor), rect1.Right + 2, rect.Y + (rect.Height - e.Graphics.MeasureString("A", font).Height) / 2);
                        break;
                    case ButtonType.Enum:
                        e.Handled = true;
                        e.PaintBackground(e.ClipBounds, true);
                        showText = GetEnumName((Enum)e.Value);
                        e.Graphics.DrawString(showText, font, new SolidBrush((e.RowIndex == dataGridView1.CurrentRow.Index) ? e.CellStyle.SelectionForeColor : e.CellStyle.ForeColor), rect.X, rect.Y + (rect.Height - e.Graphics.MeasureString("A", font).Height) / 2);
                        break;
                    case ButtonType.Boolean:
                        e.Handled = true;
                        e.PaintBackground(e.ClipBounds, true);
                        showText = GetBooleanName((bool)e.Value);
                        e.Graphics.DrawString(showText, font, new SolidBrush((e.RowIndex == dataGridView1.CurrentRow.Index) ? e.CellStyle.SelectionForeColor : e.CellStyle.ForeColor), rect.X, rect.Y + (rect.Height - e.Graphics.MeasureString("A", font).Height) / 2);
                        break;
                    case ButtonType.Image:
                        e.Handled = true;
                        e.PaintBackground(e.ClipBounds, true);
                        try
                        {
                            Image image = e.Value as Image;
                            if (image is Bitmap)
                            {
                                (image as Bitmap).MakeTransparent();
                            }
                            rect.Width = rect.Width - btnChangeValue.Width;
                            if (image.Width < rect.Width && image.Height < rect.Height)
                            {
                                e.Graphics.DrawImage(image, rect.X + (rect.Width - image.Width) / 2, rect.Y + (rect.Height - image.Height) / 2);
                            }
                            else
                            {
                                e.Graphics.DrawImage(image, rect);
                            }
                        }
                        catch
                        {
                        }
                        break;
                }
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            ButtonType type = GetCellButtonType(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);
            switch (type)
            {
                case ButtonType.None:
                    break;
                default:
                    e.Cancel = true;
                    btnChangeValue.PerformClick();
                    break;
            }
        }

        private void btnChangeValue_Click(object sender, EventArgs e)
        {
            switch (_buttonType)
            {
                case ButtonType.Color:
                    ColorDialog colorDialog = new ColorDialog();
                    colorDialog.Color = (Color)dataGridView1.CurrentCell.Value;
                    if (colorDialog.ShowDialog() == DialogResult.OK)
                    {
                        dataGridView1.CurrentCell.Value = colorDialog.Color;
                    }
                    break;
                case ButtonType.Font:
                    FontDialog fontDialog = new FontDialog();
                    fontDialog.Font = (Font)dataGridView1.CurrentCell.Value;
                    if (fontDialog.ShowDialog() == DialogResult.OK)
                    {
                        dataGridView1.CurrentCell.Value = fontDialog.Font;
                    }
                    break;
                case ButtonType.Enum:
                case ButtonType.Boolean:
                    List<MemberDetail> lst;
                    if (_buttonType == ButtonType.Enum)
                    {
                        lst = AssemblyHelper.GetEnumList(dataGridView1.CurrentCell.Value.GetType());
                    }
                    else
                    {
                        lst = new List<MemberDetail>();
                        lst.Add(new MemberDetail("真", true, null));
                        lst.Add(new MemberDetail("假", false, null));
                    }
                    Popup(lst);
                    break;
                case ButtonType.Border:
                    List<MemberDetail> lst2;
                    if (_buttonType == ButtonType.Enum)
                    {
                        lst2 = AssemblyHelper.GetEnumList(dataGridView1.CurrentCell.Value.GetType());
                    }
                    else
                    {
                        lst2 = new List<MemberDetail>();
                        lst2.Add(new MemberDetail("FixedSingle", BorderStyle.FixedSingle, null));
                        lst2.Add(new MemberDetail("Fixed3D", BorderStyle.Fixed3D, null));
                        lst2.Add(new MemberDetail("None", BorderStyle.None, null));
                    }
                    Popup(lst2);
                    break;
                case ButtonType.Custom:
                    CustomEditorEventHandle eventHandle = (CustomEditorEventHandle)Events[_customEditorEventHandle];
                    if (eventHandle != null) eventHandle(this,dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString(), dataGridView1.CurrentCell.Value);
                    break;
                case ButtonType.DateTime:
                    Popup();
                    break;
                case ButtonType.Image:
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "支持的图像(*.bmp;*.png;*.jpg;*.jpeg;*.gif;*.emf;*.wmf)|*.bmp;*.png;*.jpg;*.jpeg;*.gif;*.emf;*.emf|BMP图像(*.bmp)|*.bmp|PNG图像(*.png)|*.png|JPG图像(*.jpg;*.jpeg)|*.jpg;*.jpeg|GIF图像(*.gif)|*.gif|WMF图像(*.emf;*.wmf)|*.emf;*.wmf";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            dataGridView1.CurrentCell.Value = Image.FromFile(openFileDialog.FileName);
                        }
                        catch(Exception ex)
                        {
                            Dialog.MessageBox(ex.Message, MessageBoxIcon.Error);
                        }
                    }
                    break;
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                object oldValue = GetValue(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                object newValue = dataGridView1.CurrentCell.Value;
                if ((oldValue == null && newValue == null) || (newValue != null && newValue.Equals(oldValue)))
                {
                }
                else
                {
                    if (SetValue(dataGridView1.CurrentRow.Cells[0].Value.ToString(), newValue))
                    {
                        CustomEditorEventHandle eventHandle = (CustomEditorEventHandle)Events[_valueChangedEventHandle];
                        if (eventHandle != null) eventHandle(this, dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString(), dataGridView1.CurrentCell.Value);
                    }
                    else
                    {
                        dataGridView1.CurrentCell.Value = oldValue;
                        lastRowIndex = dataGridView1.CurrentRow.Index;
                        timer1.Enabled = true;
                    }
                }
            }
        }

        private void MedPropertiesEditor_Resize(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count * dataGridView1.RowTemplate.Height + dataGridView1.ColumnHeadersHeight > dataGridView1.Height)
            {
                dataGridView1.Columns[1].Width = dataGridView1.Width - dataGridView1.Columns[0].Width - 18;
            }
            else
            {
                dataGridView1.Columns[1].Width = dataGridView1.Width - dataGridView1.Columns[0].Width - 3;
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            btnChangeValue.Visible = false;
        }

        #endregion 事件

    }
}
