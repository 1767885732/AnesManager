using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Utilities;
using Wis.Anes.Framework.Views;
using Wis.Anes.BusinessEntity;
using Wis.Anes.ServiceProxies;
using Wis.Anes.Framework;
using Wis.Anes.Layouts;
using Wis.Anes.Framework.Configurations;

namespace Wis.Anes.Views
{
    public partial class PatMonitorEditor : BaseView
    {
        public PatMonitorEditor(string patientID,decimal visitID,decimal operID,decimal eventNo)
        {
            InitializeComponent();
            Load += new EventHandler(PatMonitorEditor_Load);
            if (eventNo == 2)
            {
                lblTitle.Text = "体外循环机数据";
            }

            _patientID = patientID;
            _visitID = visitID;
            _operID = operID;
            _eventNo = eventNo;
            
            //itemStrings = Configurations.CPBMonitorItemSetString.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            //_graphDict = new Dictionary<string, string>();
            //_graphReDict = new Dictionary<string, string>();
            //for (int i = 0; i < itemStrings.Length; i++)
            //{
            //    string[] s = itemStrings[i].Split(new string[] { "," }, StringSplitOptions.None);
            //    _graphDict.Add(s[0].Trim(), string.IsNullOrEmpty(s[1].Trim()) ? s[0].Trim() : s[1].Trim());
            //    _graphReDict.Add(string.IsNullOrEmpty(s[1].Trim()) ? s[0].Trim() : s[1].Trim(), s[0].Trim());
            //    itemStrings[i] = string.IsNullOrEmpty(s[1].Trim()) ? s[0].Trim() : s[1].Trim();
            //}

            btnAddItem.Visible = ExtendApplicationContext.Current.CustomSettingContext.IsShowAddProjAtResigister;
            
        }

        private void PatMonitorEditor_Load(object sender, EventArgs e)
        {
            //if (Globals.ISWUHANYAXING)
            //{
            //    btnDeleteItem.Visible = false;
            //}
            if (ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_MONITOR_FUNC_CODE"))
            {
                _monitorFunctionCode = ExtendApplicationContext.Current.CodeTables["WIS_MONITOR_FUNC_CODE"] as Dict.MonitorFunctionCodeDataTable;
            }
            if(_monitorFunctionCode==null)
            {
                _monitorFunctionCode = DictProxy.GetMonitorFunctionCode();
            }
            Dict.MonitorFunctionCodeRow mFCRow = _monitorFunctionCode.FindByITEM_CODE("ECG");
            if (mFCRow == null)
            {
                mFCRow = _monitorFunctionCode.NewMonitorFunctionCodeRow();
                mFCRow.ITEM_NAME = "ECG";
                mFCRow.ITEM_CODE = "ECG";
                _monitorFunctionCode.AddMonitorFunctionCodeRow(mFCRow);
            }
            GetVitalSignDataTable();
        }

        private DataTable _vitalSignTable;
        private string _patientID;
        private decimal _visitID, _operID;
        private decimal _eventNo = 0;
        private NewMonitorData _newMonitorData;
        private bool _dataChanged = false;
        private double cellOldValue = 0;
        //string[] itemStrings;
        //private Dictionary<string, string> _graphDict;
        //private Dictionary<string, string> _graphReDict;

        public override bool IsDirty
        {
            get
            {
                return btnSave.Enabled;
            }
        }

        public bool IsDataSaved
        {
            get
            {
                return _dataChanged;
            }
        }

        public override bool Save()
        {
            bool saved = false;
            if (_newMonitorData != null)
            {
                saved = _newMonitorData.Save();
                if (saved)
                {
                    //DataHelper.ClearSheetVitalSign(_patientID, _visitID, _operID);
                    _dataChanged = false;
                    btnSave.Enabled = false;
                    btnRefresh.Enabled = false;
                    label1.ForeColor = Color.Blue;
                    label1.Text = "保存成功";
                }
            }
            return saved;
        }

        /// <summary>
        /// 锁死修改功能
        /// </summary>
        public void SetReadOnly(bool isReadOnly)
        {
            if (isReadOnly)
            {
                dataGridView2.ReadOnly = true;
                pnlButtonsContainer.Visible = false;
            }
            else
            {
                dataGridView2.ReadOnly = false;
                pnlButtonsContainer.Visible = true;
            }
        }

        private void GetVitalSignDataTable()
        {
            AnesInformations.VitalSignDataTable vitalSignDataTable;

            //if (_eventNo == 2)
            //{
                //vitalSignDataTable = DataHelper.GetCPBVitalSignData(_patientID, _visitID, _operID, _eventNo);
                //foreach (DataSetModel.AnesInformations.VitalSignRow row in vitalSignDataTable.Rows)
                //{
                //    if (_graphDict.ContainsKey(row.ITEM_NAME))
                //    {
                //        row.ITEM_NAME = _graphDict[row.ITEM_NAME];
                //    }
                //}
            //}
            //else
            //{
                vitalSignDataTable = AnesthesiaSheetProxy.GetVitalSignData(_patientID, _visitID, _operID, _eventNo);
            //}
            List<string> itemNames = new List<string>();
            if (vitalSignDataTable != null && vitalSignDataTable.Rows.Count > 0)
            {
                _vitalSignTable = new DataTable();
                _vitalSignTable.Columns.Add("代码");
                _vitalSignTable.Columns.Add("名称");
                Dictionary<string, int> rowDict = new Dictionary<string, int>();
                string[] list = AnesthesiaSheetProxy.GetVitalSignTitles(_patientID, _visitID, _operID, _eventNo);
                //Add @2014-02-20
                //新增默认体征项目
                if (list != null)
                {
                    List<string> itemList = new List<string>();
                    foreach (string item in list)
                    {
                        if (!itemList.Contains(item)) itemList.Add(item);
                    }
                    string[] defItems = ApplicationConfiguration.DefaultMonitorItems.Split(',');
                    if (defItems.Length > 0)
                    {
                        foreach (string item in defItems)
                        {
                            if (!itemList.Contains(item)) itemList.Add(item);
                        }
                    }
                    list = itemList.ToArray();
                }
                
                // 改优先排序
                List<string> codeList = new List<string>(list);
                List<string> tmpList = new List<string>();
                //心率、PLUSE、无创收缩压、无创舒张压、SP02、呼吸
                foreach (string s in "40,89,90,188,92".Split(','))
                {
                    if (codeList.Contains(s))
                    {
                        codeList.Remove(s);
                        tmpList.Add(s);
                    }
                }
                tmpList.AddRange(codeList);
                list = tmpList.ToArray();

                //End Add
                DataRow dtRow;
                foreach (string s in list)
                {
                    if(!rowDict.ContainsKey(s))
                        rowDict.Add(s, _vitalSignTable.Rows.Count);
                    dtRow = _vitalSignTable.NewRow();
                    dtRow[0] = s;
                    dtRow[1] = ExtendApplicationContext.Current.MonitorFunctionCodeDict.ContainsKey(s) ? ExtendApplicationContext.Current.MonitorFunctionCodeDict[s] : s;
                    _vitalSignTable.Rows.Add(dtRow);
                }

                //CareDocs.PatientMonitorDataDataTable patientMonitorDataDataTable = _careDocsDA.GetPatientMonitorData(patientID, visitID, operID, eventNo);
                DataTable dt = AnesthesiaSheetProxy.GetPatientMonitorData(_patientID, _visitID, _operID);
                foreach (AnesInformations.VitalSignRow row in vitalSignDataTable.Rows)
                {
                    string columnName = row.TIME_POINT.ToString("HH:mm");
                    if (!_vitalSignTable.Columns.Contains(columnName))
                    {
                        DataColumn column = new DataColumn(columnName, typeof(string));
                        column.Caption = row.TIME_POINT.ToString("yyyy-MM-dd HH:mm");
                        _vitalSignTable.Columns.Add(column);
                    }
                    DataRow[] dataRows = dt.Select("ITEM_NAME='" + row.ITEM_CODE+"'");
                    if (dataRows.Length > 0)
                    {
                        if (rowDict.ContainsKey(row.ITEM_CODE))
                        {
                            dtRow = _vitalSignTable.Rows[rowDict[row.ITEM_CODE]];
                        }
                        else
                        {
                            if (!rowDict.ContainsKey(row.ITEM_CODE))
                                rowDict.Add(row.ITEM_CODE, _vitalSignTable.Rows.Count);
                            dtRow = _vitalSignTable.NewRow();
                            dtRow[0] = row.ITEM_CODE;
                            _vitalSignTable.Rows.Add(dtRow);
                        }
                        
                    }
                    else//解决没有录入体征数据时，带不出采集数据
                    {
                        if (!rowDict.ContainsKey(row.ITEM_CODE))
                        {
                            rowDict.Add(row.ITEM_CODE, _vitalSignTable.Rows.Count);
                            dtRow = _vitalSignTable.NewRow();
                            dtRow[0] = row.ITEM_CODE;

                            _vitalSignTable.Rows.Add(dtRow);
                        }
                        else
                        {
                            dtRow = _vitalSignTable.Rows[rowDict[row.ITEM_CODE]];
                        }
                            
                        
                    }
                    dtRow[columnName] = row.VALUE;
                }
                dataGridView2.SelectionMode = DataGridViewSelectionMode.CellSelect;
                dataGridView2.DataSource = _vitalSignTable;
                for (int i = 2; i < dataGridView2.ColumnCount; i++)
                {
                    DataGridViewColumn column = dataGridView2.Columns[i];
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    column.ToolTipText = _vitalSignTable.Columns[i].Caption;
                }
                dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView2.Columns[0].ReadOnly = true;
                dataGridView2.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView2.Columns[0].Frozen = true;
                dataGridView2.Columns[0].Visible = false;
                dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView2.Columns[1].ReadOnly = true;
                dataGridView2.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView2.Columns[1].Frozen = true;
                dataGridView2.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;

            }
            else
            {
                _vitalSignTable = new DataTable();
                _vitalSignTable.Columns.Add("代码");
                _vitalSignTable.Columns.Add("名称");

                string[] items = (_eventNo == 2) ? null : AnesthesiaSheetProxy.GetVitalSignTitles(_patientID, _visitID, _operID, _eventNo);


                if (_eventNo == 1 && ExtendApplicationContext.Current.CustomSettingContext.IsAddPacuSpecialItems)//复苏项
                {
                    if (items != null)
                    {
                        string[] itemsCopy = new string[items.Length + 2];
                        itemsCopy[0] = "50008";
                        itemsCopy[1] = "50009";
                        for (int i = 0; i < items.Length; i++)
                        {
                            itemsCopy[i + 2] = items[i];
                        }

                        items = itemsCopy;
                    }
                    //50008 50009
                    
                }

                // 改优先排序
                List<string> codeList = new List<string>(items);
                List<string> tmpList = new List<string>();
                //心率、PLUSE、无创收缩压、无创舒张压、SP02、呼吸
                foreach (string s in "40,44,89,90,188,92".Split(','))
                {
                    if (codeList.Contains(s))
                    {
                        codeList.Remove(s);
                        tmpList.Add(s);
                    }
                }
                tmpList.AddRange(codeList);
                items = tmpList.ToArray();

                if (items != null && items.Length > 0)
                {
                    for (int i = 0; i < items.Length; i++)
                    {
                        DataRow row1 = _vitalSignTable.NewRow();
                        row1[0] = items[i];
                        row1[1] = ExtendApplicationContext.Current.MonitorFunctionCodeDict.ContainsKey(items[i]) ? ExtendApplicationContext.Current.MonitorFunctionCodeDict[items[i]] : items[i];
                        _vitalSignTable.Rows.Add(row1);
                    }

                    

                    dataGridView2.DataSource = _vitalSignTable;
                    dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView2.Columns[0].ReadOnly = true;
                    dataGridView2.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView2.Columns[0].Visible = false;
                    dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView2.Columns[1].ReadOnly = true;
                    dataGridView2.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            _newMonitorData = new NewMonitorData(_patientID, _visitID, _operID, _eventNo);
            if (dataGridView2.Height < 50) dataGridView2.Height = 200;
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string value;
            if (dataGridView2.CurrentCell.Value == System.DBNull.Value || string.IsNullOrEmpty(dataGridView2.CurrentCell.Value.ToString()))
            {
                value = "";
            }
            else
            {
                value = dataGridView2.CurrentCell.Value.ToString();
            }
            if (_eventNo == 2)
            {
                //string itemName = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                //if (_graphReDict.ContainsKey(itemName))
                //{
                //    itemName = _graphReDict[itemName];
                //}
                //_newMonitorData.SetItem(DateTime.Parse(((DataTable)dataGridView2.DataSource).Columns[dataGridView2.CurrentCell.ColumnIndex].Caption)
                //    , itemName, value, cellOldValue.ToString());
            }
            else
            {
                _newMonitorData.SetItem(DateTime.Parse(((DataTable)dataGridView2.DataSource).Columns[dataGridView2.CurrentCell.ColumnIndex].Caption)
                    , dataGridView2.CurrentRow.Cells[0].Value.ToString(), value, cellOldValue.ToString());
            }
            btnSave.Enabled = true;
            btnRefresh.Enabled = true;
            //timer1.Enabled = true;
        }

        private void ValidateNumber(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int newInteger = 0;
            float newdecimal = 0;
            if (((!int.TryParse(e.FormattedValue.ToString(), out newInteger) || newInteger < 0) &&
                (!float.TryParse(e.FormattedValue.ToString(), out newdecimal) || newdecimal < 0))
                && e.FormattedValue.ToString() != "")
            {
                DataGridView grid = (sender as DataGridView);
                //如果是 左侧瞳孔 50008 ， 或者 右侧瞳孔 50009
                if (grid.CurrentRow.Cells[0].Value.Equals("50008") || grid.CurrentRow.Cells[0].Value.Equals("50009"))
                {
                }
                else
                {
                    e.Cancel = true;
                    label1.ForeColor = Color.Red;

                    label1.Text = "“" + grid.CurrentRow.Cells[0].Value.ToString() + "”字段必须为非负数字类型";
                }
            }
            else
            {
                label1.ForeColor = Color.Blue;
                label1.Text = "要删除某时间点，必须选中整列!";
            }
        }

        private void dataGridView2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex > 1)
            {
                ValidateNumber(sender, e);
            }
            else
            {
                label1.ForeColor = Color.Blue;
                label1.Text = "要删除某时间点，必须选中整列!";
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedColumns != null && dataGridView2.SelectedColumns.Count > 0 && !dataGridView2.SelectedColumns.Contains(dataGridView2.Columns[0]))
            {
                btnDelete.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
            }
        }


        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                GridViewHelper.DataGridViewCellPainting(e);
            }
        }

        private void dataGridView2_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                cellOldValue = double.Parse(dataGridView2.CurrentCell.Value.ToString().Trim());
            }
            catch
            {
                cellOldValue = 0.0;
            }
        }

        private void pnlBody_Paint(object sender, PaintEventArgs e)
        {
            //Rectangle rect = e.ClipRectangle;
            //rect.X += 1;
            //rect.Width -= 2;
            //Color color = pnlBody.BackColor;
            //int r = color.R;
            //int g = color.G;
            //int b = color.B;
            //if (r > 50)
            //{
            //    r -= 50;
            //}
            //if (g > 50)
            //{
            //    g -= 50;
            //}
            //if (b > 50)
            //{
            //    b -= 50;
            //}
            //e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(r, g, b)), rect);
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            //string[] list;
            if (_eventNo == 2)
            {
                //list = Configurations.CPBMonitorItemSetString.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                //for (int i = 0; i < list.Length; i++)
                //{
                //    string[] s = list[i].Split(new string[] { "," }, StringSplitOptions.None);
                //    list[i] = string.IsNullOrEmpty(s[1].Trim()) ? s[0].Trim() : s[1].Trim();
                //}
                //object reason = Dialog.SingleInputSelect("请输入手工录入项目名称", list);
                //if (reason == null) return;
                //if (_vitalSignTable == null) _vitalSignTable = new DataTable();
                //if (_vitalSignTable.Columns.Count == 0) _vitalSignTable.Columns.Add("名称");
                //foreach (DataRow dtRow in _vitalSignTable.Rows)
                //{
                //    if (dtRow[0].ToString().Trim().Equals(reason.ToString().Trim())) return;
                //}
                //DataRow row = _vitalSignTable.NewRow();
                //row[0] = reason.ToString();
                //_vitalSignTable.Rows.Add(row);
                //dataGridView2.DataSource = _vitalSignTable;
                //dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dataGridView2.Columns[0].ReadOnly = true;
                //dataGridView2.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            else
            {
                Dialog.ShowCustomSelection(_monitorFunctionCode, "ITEM_NAME", btnAddItem, new Size(300, 300), new EventHandler(AddItem));
            }
        }

        private void AddItem(object sender, EventArgs e)
        {
            if (sender is int)
            {
                int index = (int)sender;
                if (_vitalSignTable == null) _vitalSignTable = new DataTable();
                if (_vitalSignTable.Columns.Count == 0)
                {
                    _vitalSignTable.Columns.Add("代码");
                    _vitalSignTable.Columns.Add("名称");
                }
                foreach (DataRow dtRow in _vitalSignTable.Rows)
                {
                    if (dtRow[0].ToString().Trim().Equals(_monitorFunctionCode[index].ITEM_CODE)) return;
                }
                DataRow row = _vitalSignTable.NewRow();
                row[0] = _monitorFunctionCode[index].ITEM_CODE;
                row[1] = _monitorFunctionCode[index].ITEM_NAME;
                _vitalSignTable.Rows.Add(row);
                dataGridView2.DataSource = _vitalSignTable;
                dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView2.Columns[0].ReadOnly = true;
                dataGridView2.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private Dict.MonitorFunctionCodeDataTable _monitorFunctionCode = null;

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetVitalSignDataTable();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Dialog.MessageBox("真的要删除所选列的数据吗？", "提示" , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool result = false;
                NewMonitorData monitorData = new NewMonitorData(_patientID, _visitID, _operID, _eventNo);
                for (int i = 0; i < dataGridView2.SelectedColumns.Count; i++)
                {
                    DateTime timePoint = DateTime.Parse(((DataTable)dataGridView2.DataSource).Columns[dataGridView2.SelectedColumns[i].Index].Caption);
                    if (monitorData.Delete(timePoint))
                    {
                        result = true;
                    }
                }
                if (result)
                {
                    _dataChanged = true;
                    GetVitalSignDataTable();
                }
            }
        }

        private void btnInsertColumns_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                int columnIndex = -1;
                if (dataGridView2.SelectedColumns != null && dataGridView2.SelectedColumns.Count > 0)
                {
                    columnIndex = dataGridView2.SelectedColumns[0].Index;
                }
                List<string> items = new List<string>();
                List<object> values = new List<object>();
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    items.Add(row.Cells[0].Value.ToString());
                    if (columnIndex > 1)
                    {
                        object v = row.Cells[columnIndex].Value;
                        if (v == System.DBNull.Value)
                        {
                            values.Add("0");
                        }
                        else
                        {
                            values.Add(v.ToString());
                        }
                    }
                }
                MonitorDataEditor monitorEditor;
                if (columnIndex > 1)
                {
                    monitorEditor = new MonitorDataEditor(_patientID, _visitID, _operID, items
                        , DateTime.Parse(((DataTable)dataGridView2.DataSource).Columns[columnIndex].Caption), values, _eventNo);
                }
                else
                {
                    monitorEditor = new MonitorDataEditor(_patientID, _visitID, _operID, items, _eventNo);
                }
                DialogHostForm dialogHostForm = new DialogHostForm(monitorEditor.Caption, monitorEditor.Width, monitorEditor.Height+30);
                dialogHostForm.Child = monitorEditor;
                dialogHostForm.ShowDialog();
                object result = monitorEditor.Result;
                if (result != null && result is DialogResult && (DialogResult)result == DialogResult.OK)
                {
                    GetVitalSignDataTable();
                    _dataChanged = true;
                    //dialogHostForm.Close()
                }
            }
        }

        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            Control control = e.Control;
            if (control is System.Windows.Forms.DataGridViewTextBoxEditingControl)
            {
                System.Windows.Forms.DataGridViewTextBoxEditingControl editor = control as System.Windows.Forms.DataGridViewTextBoxEditingControl;
                editor.TextChanged -= new EventHandler(editor_TextChanged);
                editor.TextChanged += new EventHandler(editor_TextChanged);
            }
        }

        private void editor_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null && dataGridView2.CurrentRow.Index >= 0)
            {
                if (Dialog.MessageBox("真的要删当前体征项目吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool result = false;
                    NewMonitorData monitorData = new NewMonitorData(_patientID, _visitID, _operID, _eventNo);
                    if (monitorData.Delete(dataGridView2.CurrentRow.Cells[0].Value.ToString()))
                    {
                        result = true;
                    }
                    if (result)
                    {
                        _dataChanged = true;
                        GetVitalSignDataTable();
                    }
                }
            }
        }

    }
}
