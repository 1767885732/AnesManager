using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using Wis.Anes.Framework.Utilities;
using System.Threading;
using Wis.Anes.Framework.Controls.Base;

namespace Wis.Anes.Framework.Controls
{
    public class MedDataGridView : DataGridView
    {

        #region 构造方法

        public MedDataGridView()
        {
            SetSkin();
            Skin.Skin.SkinChanged += delegate
            {
                SetSkin();
                this.Refresh();
               
            };
        }
        private void SetSkin()
        {
            this.TopLeftHeaderCell = new MedDataGridViewTopLeftHeaderCell();
            DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.BackColor = Skin.Skin.GetGridViewAlternateRowColor();
            this.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Skin.Skin.GetGridViewBackColor(); ;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Skin.Skin.GetGridViewSelectedRowColor();
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DefaultCellStyle = dataGridViewCellStyle2;
        }
        #endregion 构造方法

        #region 变量

        /// <summary>
        /// 自画列头
        /// </summary>
        private bool _isOwnerDrawColumnHead = true;

        /// <summary>
        /// 自画行头
        /// </summary>
        private bool _isOwnerDrawRownHead = false;

        /// <summary>
        /// 是否拒绝输入
        /// </summary>
        private bool isRejectInput = false;

        /// <summary>
        /// 自动处理Data_Error
        /// </summary>
        private bool _autoDataError = true;

        /// <summary>
        /// 字符的首尾空格去掉
        /// </summary>
        private bool _stringTrim = true;

        #endregion 变量

        #region 属性

        /// <summary>
        /// 自画列头
        /// </summary>
        public bool IsOwnerDrawColumnHead
        {
            get
            {
                return _isOwnerDrawColumnHead;
            }
            set
            {
                _isOwnerDrawColumnHead = value;
                foreach (DataGridViewColumn column in Columns)
                {
                    if (column.HeaderCell is MedDataGridViewColumnHeaderCell)
                    {
                        (column.HeaderCell as MedDataGridViewColumnHeaderCell).IsOwnerDraw = _isOwnerDrawColumnHead;
                    }
                }
            }
        }

        /// <summary>
        /// 自画行头
        /// </summary>
        public bool IsOwnerDrawRownHead
        {
            get
            {
                return _isOwnerDrawRownHead;
            }
            set
            {
                _isOwnerDrawRownHead = value;
                foreach (DataGridViewRow row in Rows)
                {
                    if (row.HeaderCell is MedDataGridViewRowHeaderCell)
                    {
                        (row.HeaderCell as MedDataGridViewRowHeaderCell).IsOwnerDraw = _isOwnerDrawRownHead;
                    }
                }
            }
        }

        /// <summary>
        /// 去除字符的前后空格
        /// </summary>
        [Description("去除字符的前后空格")]
        public bool StringTrim
        {
            get
            {
                return _stringTrim;
            }
            set
            {
                _stringTrim = value;
            }
        }

        /// <summary>
        /// 自动处理Data_Error
        /// </summary>
        [Description("自动处理Data_Error")]
        public bool AutoDataError
        {
            get
            {
                return _autoDataError;
            }
            set
            {
                _autoDataError = value;
            }
        }

        #endregion 属性

        #region 方法

        /// <summary>
        /// 解决微软自动更新输入法为全角BUG
        /// </summary>
        /// <param name="e"></param>
        protected override void OnCellEnter(DataGridViewCellEventArgs e)
        {
            base.OnCellEnter(e);
            IntPtr HIme = WinAPI.ImmGetContext(this.Handle);
            if (WinAPI.ImmGetOpenStatus(HIme))  //如果输入法处于打开状态
            {
                int iMode = 0;
                int iSentence = 0;
                bool bSuccess = WinAPI.ImmGetConversionStatus(HIme, ref iMode, ref iSentence);  //检索输入法信息
                if (bSuccess)
                {
                    if ((iMode & WinAPI.IME_CMODE_FULLSHAPE) > 0)   //如果是全角
                        WinAPI.ImmSimulateHotKey(this.Handle, WinAPI.IME_CHOTKEY_SHAPE_TOGGLE);  //转换成半角
                }
            }
        }

        /// <summary>
        /// 设置行头
        /// </summary>
        public void SetRowHead()
        {
            foreach (DataGridViewRow row in Rows)
            {
                if (!(row.HeaderCell is MedDataGridViewRowHeaderCell))
                {
                    row.HeaderCell = new MedDataGridViewRowHeaderCell(_isOwnerDrawRownHead);
                }
            }
        }

        /// <summary>
        /// 自定义列标题
        /// </summary>
        /// <param name="e"></param>
        protected override void OnColumnAdded(DataGridViewColumnEventArgs e)
        {
            base.OnColumnAdded(e);
            e.Column.HeaderCell = new MedDataGridViewColumnHeaderCell(e.Column.HeaderCell.Value);
        }

        /// <summary>
        /// 设置行标题
        /// </summary>
        /// <param name="index">行索引</param>
        /// <param name="title">行标题</param>
        public void SetRowTitle(int index, string title)
        {
            if ((index > -1) && (index < Rows.Count) && (Rows[index].HeaderCell is MedDataGridViewRowHeaderCell))
            {
               (Rows[index].HeaderCell as MedDataGridViewRowHeaderCell).Title = title;
                Rows[index].HeaderCell.Value = title;
            }
        }

        #region 2010-06-07
        /// <summary>
        /// 设置行标题显示颜色
        /// </summary>
        /// <param name="index">行索引</param>
        /// <param name="brush">行标题显示颜色</param>
        public void SetRowTitleDisplayStyle(int index, Brush brush)
        {
            if ((index > -1) && (index < Rows.Count) && (Rows[index].HeaderCell is MedDataGridViewRowHeaderCell))
                (Rows[index].HeaderCell as MedDataGridViewRowHeaderCell).TitleBruse = brush;
        }
        #endregion


        /// <summary>
        /// 数据格式错误提示
        /// </summary>
        /// <param name="displayErrorDialogIfNoHandler"></param>
        /// <param name="e"></param>
        protected override void OnDataError(bool displayErrorDialogIfNoHandler, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.GetType() == typeof(ThreadStateException))
                return;

            if (_autoDataError)
            {
                if ((displayErrorDialogIfNoHandler) && !e.Exception.Message.Equals("DataGridViewComboBoxCell 值无效。") && !e.Exception.Message.Equals("DataGridViewComboBoxCell value is not valid."))
                {
                    Type valueType = this[e.ColumnIndex, e.RowIndex].ValueType;
                    if (valueType == typeof(int) || valueType == typeof(decimal) || valueType == typeof(float) || valueType == typeof(double))
                    {
                        Sundries.MessageBox("请输入数字！", 2);
                    }
                    else
                    {
                        Sundries.MessageBox("输入不正确，请重新输入！", 2);
                    }
                    this[e.ColumnIndex, e.RowIndex].Selected = true;
                }
            }
            else
            {
                base.OnDataError(displayErrorDialogIfNoHandler, e);
            }
        }

        protected override void OnCellEndEdit(DataGridViewCellEventArgs e)
        {
            if (StringTrim && this[e.ColumnIndex, e.RowIndex].Value != null && !string.IsNullOrEmpty(this[e.ColumnIndex, e.RowIndex].Value.ToString()))
            {
                this[e.ColumnIndex, e.RowIndex].Value = this[e.ColumnIndex, e.RowIndex].Value.ToString().Trim();
            }
            base.OnCellEndEdit(e);
        }

        protected override void OnCellBeginEdit(DataGridViewCellCancelEventArgs e)
        {
            string columnName = Columns[e.ColumnIndex].DataPropertyName;
            if ((!string.IsNullOrEmpty(columnName)) && (columnName.Trim() != string.Empty) && (DataSource is System.Data.DataTable))
            {
                if ((DataSource as System.Data.DataTable).Columns[columnName].DataType.Name == "String")
                {
                    ImeMode = ImeMode.NoControl;
                }
                else
                {
                    ImeMode = ImeMode.Disable;
                }
            }
            base.OnCellBeginEdit(e);
        }


        /// <summary>
        /// 删除选择行
        /// </summary>
        /// <param name="grid">主表显示视图</param>
        public void DeleteSelectRows()
        {
            if (SelectedRows != null)
            {
                foreach (DataGridViewRow row in SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        Rows.Remove(row);
                    }
                }
            }
        }
        /// <summary>
        /// 生成动态列
        /// </summary>
        /// <param name="title"></param>
        /// <param name="fieldName"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public DataGridViewColumn GenerateCheckBoxColumn(string title, string fieldName, int width)
        {
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            column.HeaderText = title;
            column.DataPropertyName = fieldName;
            column.Name = fieldName;
            column.Width = width;
            Columns.Add(column);
            return column;
        }
        /// <summary>
        /// 生成动态列
        /// </summary>
        /// <param name="title"></param>
        /// <param name="fieldName"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public DataGridViewColumn GenerateColumn(string title, string fieldName, int width)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = title;
            column.DataPropertyName = fieldName;
            column.Name = fieldName;
            column.Width = width;
            Columns.Add(column);
            return column;
        }
        /// <summary>
        /// 生成动态列
        /// </summary>
        /// <param name="title"></param>
        /// <param name="fieldName"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public DataGridViewColumn GenerateColumn(string title, string fieldName, int width, bool read)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = title;
            column.DataPropertyName = fieldName;
            column.Name = fieldName;
            column.Width = width;
            column.ReadOnly = read;
            Columns.Add(column);
            return column;
        }
        /// <summary>
        /// 生成动态列
        /// </summary>
        /// <param name="title"></param>
        /// <param name="fieldName"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public DataGridViewColumn GenerateColumn(string title, string fieldName, int width, bool read, bool visible)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = title;
            column.DataPropertyName = fieldName;
            column.Name = fieldName;
            column.Width = width;
            column.ReadOnly = read;
            column.Visible = visible;
            Columns.Add(column);
            return column;
        }
        /// <summary>
        /// 生成动态列
        /// </summary>
        /// <param name="title"></param>
        /// <param name="fieldName"></param>
        /// <param name="width"></param>
        /// <param name="listItems"></param>
        /// <returns></returns>
        public DataGridViewColumn GenerateColumn(string title, string fieldName, int width, string[] listItems)
        {
            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
            foreach (string itemValue in listItems)
            {
                column.Items.Add(itemValue);
            }
            column.HeaderText = title;
            column.DataPropertyName = fieldName;
            column.Width = width;
            column.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            Columns.Add(column);
            return column;
        }

        /// <summary>
        /// 生成动态列
        /// </summary>
        /// <param name="title"></param>
        /// <param name="fieldName"></param>
        /// <param name="width"></param>
        /// <param name="listItems"></param>
        /// <returns></returns>
        public DataGridViewColumn GenerateCheckBoxColumn(string title, string fieldName, int width, bool read, bool visible)
        {
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            column.HeaderText = title;
            column.DataPropertyName = fieldName;
            column.Name = fieldName;
            column.Width = width;
            column.ReadOnly = read;
            column.Visible = visible;
            Columns.Add(column);
            return column;
        }

        #endregion

        #region 私有类

        #region 左上角类

        private class MedDataGridViewTopLeftHeaderCell : DataGridViewTopLeftHeaderCell
        {

            #region 私有变量

            /// <summary>
            /// 是否自画
            /// </summary>
            private bool _isOwnerDraw = true;

            #endregion

            #region 构造方法

            public MedDataGridViewTopLeftHeaderCell() : base() { }

            #endregion

            #region 属性

            /// <summary>
            /// 是否自画
            /// </summary>
            public bool IsOwnerDraw
            {
                get
                {
                    return _isOwnerDraw;
                }
                set
                {
                    _isOwnerDraw = value;
                }
            }

            #endregion

            #region 方法

            protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
            {
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
                if (_isOwnerDraw)
                {
                    Rectangle rect = new Rectangle(cellBounds.Location, cellBounds.Size);
                    rect.Inflate(0, 0);
                    using (Image bitmap = Skin.Skin.GetGridViewHeaderImage())
                    {
                        using (Bitmap bmp = new Bitmap(bitmap.Width, rect.Height))
                        {
                            using (Graphics g = Graphics.FromImage(bmp))
                            {
                                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                                g.DrawImage(bitmap, new Rectangle(0, 0, bitmap.Width, rect.Height));
                                graphics.FillRectangle(new SolidBrush(Color.LightGray), rect);
                                graphics.FillRectangle(new TextureBrush(bmp), rect);
                            }
                        }
                    }
                }
            }

            #endregion 方法

        }


        #endregion 左上角类

        #region 列头类

        private class MedDataGridViewColumnHeaderCell : DataGridViewColumnHeaderCell
        {

            #region 私有变量

            /// <summary>
            /// 是否自画
            /// </summary>
            private bool _isOwnerDraw = true;

            #endregion

            #region 属性

            /// <summary>
            /// 是否自画
            /// </summary>
            public bool IsOwnerDraw
            {
                get
                {
                    return _isOwnerDraw;
                }
                set
                {
                    _isOwnerDraw = value;
                }
            }

            #endregion

            #region 构造方法

            public MedDataGridViewColumnHeaderCell() : base() { }

            public MedDataGridViewColumnHeaderCell(object title) : base() { base.Value = title; }

            #endregion

            #region 方法

            protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates dataGridViewElementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
            {
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, dataGridViewElementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
                if (_isOwnerDraw)
                {
                    Rectangle rect = new Rectangle(cellBounds.Location, cellBounds.Size);
                    rect.Inflate(0, 0);

                    using (Image bitmap = Skin.Skin.GetGridViewHeaderImage())
                    {
                        using (Bitmap bmp = new Bitmap(bitmap.Width, rect.Height))
                        {
                            using (Graphics g = Graphics.FromImage(bmp))
                            {
                                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                                g.DrawImage(bitmap, new Rectangle(0, 0, bitmap.Width, rect.Height));
                                graphics.FillRectangle(new SolidBrush(Color.LightGray), rect);
                                graphics.FillRectangle(new TextureBrush(bmp), rect);
                            }
                        }
                    }
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Center;
                    string strValue = Value.ToString();
                    Font drawFont = new Font("微软雅黑", 9);//, FontStyle.Bold);
                    if (graphics.MeasureString(strValue, drawFont).Width <= rect.Width)
                    {
                        rect.Offset(0, (int)((rect.Height - graphics.MeasureString(strValue, drawFont).Height) / 2));
                    }
                    graphics.DrawString(strValue, drawFont, Brushes.White, rect, sf);
                }
            }

            #endregion
        }

        #endregion

        #region 行头类

        public class MedDataGridViewRowHeaderCell : DataGridViewRowHeaderCell
        {
            #region 私有变量

            /// <summary>
            /// 是否自画
            /// </summary>
            private bool _isOwnerDraw = false;

            /// <summary>
            /// 行标题
            /// </summary>
            private string _title;

            #region 2010-06-07
            /// <summary>
            /// 行标题显示颜色
            /// </summary>
            private Brush _titleBruse = Brushes.Black;
            #endregion

            #endregion

            #region 属性

            /// <summary>
            /// 是否自画
            /// </summary>
            public bool IsOwnerDraw
            {
                get
                {
                    return _isOwnerDraw;
                }
                set
                {
                    _isOwnerDraw = value;
                }
            }

            /// <summary>
            /// 行标题
            /// </summary>
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

            #region 2010-06-07
            /// <summary>
            /// 行标题显示颜色
            /// </summary>
            public Brush TitleBruse
            {
                get
                {
                    return _titleBruse;
                }
                set
                {
                    _titleBruse = value;
                }
            }
            #endregion

            #endregion

            #region 构造方法

            public MedDataGridViewRowHeaderCell() : base() { }

            public MedDataGridViewRowHeaderCell(bool isOwnDraw) : base() { _isOwnerDraw = isOwnDraw; }

            public MedDataGridViewRowHeaderCell(string title) : this() { _title = title; }

            #endregion

            #region 方法

            protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
            {
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
                if (_isOwnerDraw)
                {
                    Rectangle rect = new Rectangle(cellBounds.Location, cellBounds.Size);
                    rect.Inflate(0, -1);

                    graphics.FillRectangle(new SolidBrush(Skin.Skin.GetGridViewLeftMenu()), rect);

                    if (_title != null)
                    {
                        StringFormat sf = new StringFormat();
                        sf.Alignment = StringAlignment.Center;
                        Font drawFont = new Font("微软雅黑", 9);//, FontStyle.Bold);
                        if (graphics.MeasureString(_title, drawFont).Width <= rect.Width)
                        {
                            rect.Offset(0, (int)((rect.Height - graphics.MeasureString(_title, drawFont).Height) / 2));
                        }


                        #region 2010-06-07
                        graphics.DrawString(_title, drawFont, _titleBruse, rect, sf);
                        #endregion

                    }
                }
            }

            #endregion
        }

        #endregion

        #endregion
    }

}
