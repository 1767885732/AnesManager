using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Com.MedicalSystem.Common.Utilities;

namespace Com.ICIS.Common.Controls
{
    public partial class MedDataGrid : UserControl
    {
        /// <summary>
        /// 自增ID列名称
        /// </summary>
        private const string FIDCOLUMNNAME = "MedFID";
        private int _pageCount = 1;
        private int _pageNum = 1;
        private int _rowCount = 0;
        private DataTable _dataSource = new DataTable();
        private DataTable _filtrateSource = new DataTable();
        private string _bindTableName = string.Empty;

        public bool VisiblePagePanel
        {
            set
            {
                panel1.Visible = value;
            }
            get
            {
                return panel1.Visible;
            }
        }
        public new Color BackColor
        {
            set
            {
                dataGridView1.BackgroundColor = value;
            }
            get
            {
                return dataGridView1.BackgroundColor;
            }
        }
        public string BindTableName
        {
            set
            {
                _bindTableName = value;
            }
            get
            {
                return _bindTableName;
            }
        }

        public bool ReadOnly
        {
            set
            {
                dataGridView1.ReadOnly = value;
            }
            get
            {
                return dataGridView1.ReadOnly;
            }
        }
        public DataGridViewColumnCollection Columns
        {
            get
            {
                return dataGridView1.Columns;
            }

        }
        /// <summary>
        /// 页数
        /// </summary>
        public int PageCount
        {
            set
            {
                _pageCount = value;
            }
            get
            {
                return _pageCount;
            }
        }
        /// <summary>
        /// 页码
        /// </summary>
        public int PageNum
        {
            get
            {
                return _pageNum;
            }
        }
        /// <summary>
        /// 每页行数
        /// </summary>
        public int RowCount
        {
            set
            {
                _rowCount = value;
            }
            get
            {
                return _rowCount;
            }
        }
        public DataTable DataSource
        {
            set
            {
                _dataSource = value;
                if (!_dataSource.Columns.Contains(FIDCOLUMNNAME))
                {
                    DataColumn MedFIDColumn = new DataColumn(FIDCOLUMNNAME, typeof(Int32));
                    _dataSource.Columns.Add(MedFIDColumn);
                }
                int FID = 0;
                foreach (DataRow Row in _dataSource.Rows)
                {
                    Row[FIDCOLUMNNAME] = FID++;
                }
                _filtrateSource = _dataSource.Clone();
                SetDataGridDataSource();
            }
            get
            {
                return _dataSource;
            }
        }

        private void SetDataGridDataSource()
        {
            if (_rowCount > 0)
            {
                string WhereSql = string.Empty;
                WhereSql = FIDCOLUMNNAME + " <" + Convert.ToString(_rowCount * _pageNum) + " AND " + FIDCOLUMNNAME + " >= " + Convert.ToString(_rowCount * (_pageNum - 1));
                DataRow[] DtRows = _dataSource.Select(WhereSql, FIDCOLUMNNAME + " ASC");
                _filtrateSource.Clear();
                foreach (DataRow Row in DtRows)
                {
                    _filtrateSource.ImportRow(Row);
                }
                dataGridView1.DataSource = _filtrateSource;
            }
            else
            {
                dataGridView1.DataSource = _dataSource;
            }
            if (_dataSource != null)
            {
                if (_rowCount > 0)
                {
                    _pageCount = _dataSource.Rows.Count / _rowCount;
                }
                if ((_dataSource.Rows.Count % _rowCount) > 0)
                {
                    _pageCount++;
                }
                lbalPageNo.Text = _pageNum.ToString() + "/" + _pageCount.ToString();
            }
        }

        public MedDataGrid()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowDrop = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.BackgroundColor = this.BackColor;
            Width = 400;
            Height = 200;
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
        }

        private void dataGridView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_pageNum == _pageCount)
            {
                return;
            }
            _pageNum++;
            SetDataGridDataSource();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_pageNum == 1)
            {
                return;
            }
            _pageNum--;
            SetDataGridDataSource();
        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DesignableField)))
            {
                if (sender is DataGridView)
                {
                    DesignableField DataField1 = ((DesignableField)e.Data.GetData(typeof(DesignableField)));
                    if (_bindTableName.Length == 0)
                    {
                        _bindTableName = DataField1.TableName;
                    }
                    else
                    {
                        if (_bindTableName != DataField1.TableName)
                        {
                            Dialog.MessageBox("同一个表格不允许添加多个数据表字段。");
                            return;
                        }
                    }
                    DataGridViewColumn GridColumn = new DataGridViewColumn();
                    string ColumnHeaderText = DataField1.Text;
                    object Result = Dialog.SingleInputSelect("请录入字段显示名称", ColumnHeaderText);
                    if (Result != null)
                    {
                        ColumnHeaderText = Result.ToString();
                    }
                    GridColumn.HeaderText = ColumnHeaderText;
                    GridColumn.DataPropertyName = DataField1.DataFieldName;
                    GridColumn.CellTemplate = new DataGridViewTextBoxCell();
                    dataGridView1.Columns.Add(GridColumn);
                }
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && ((Control)sender).Cursor != Cursors.SizeNS && ((Control)sender).Cursor != Cursors.SizeWE)
            {
                OnMouseDown(e);
            }
        }

        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && ((Control)sender).Cursor != Cursors.SizeNS && ((Control)sender).Cursor != Cursors.SizeWE)
            {
                OnMouseMove(e);
            }
        }

        private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && ((Control)sender).Cursor != Cursors.SizeNS && ((Control)sender).Cursor != Cursors.SizeWE)
            {
                OnMouseUp(e);
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            OnKeyDown(e);
        }

        /// <summary>
        /// 显示上一页数据内容
        /// </summary>
        public void PreviousPage()
        {
            btnPreviousPage.PerformClick();
        }
        /// <summary>
        /// 显示下一页数据内容
        /// </summary>
        public void NextPage()
        {
            btnNextPage.PerformClick();
        }
    }
}
