using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.BusinessEntity;
using Wis.Anes.DataAccess;
using Wis.Anes.Framework.Utilities;

namespace Wis.Anes.Framework
{
    [ToolboxItem(false)]
    public partial class AnesDrugTemplet : UserControl
    {
        private DataRow[] _sourceRowsDrug;
        private DataRow[] _sourceRowsLiquid;
        public AnesDrugTemplet()
        {
            InitializeComponent();
            InitComboxData();
        }

        private void InitComboxData()
        {
            cmbTempletName.Properties.Items.Clear();
            BusinessEntity.Configuations.ConfigTableDataTable configTable = new ConfigurationDA().GetConfigTableDataTable();
            if (configTable != null && configTable.Count>0)
            {
                DataRow[] rows = configTable.Select("Para_Key like 'Model.%'");
                if (rows != null && rows.Length > 0)
                {
                    foreach (DataRow row in rows)
                    {
                        if (row["Para_Key"] != null)
                        {
                            cmbTempletName.Properties.Items.Add(row["Para_Key"].ToString().Substring(6));
                        }
                    }
                }
            }
            cmbTempletName.SelectedIndex = -1;
        }

        private void BindGridData(string value)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();

            string[] items = value.Split(';');//new char[]{';'},StringSplitOptions.RemoveEmptyEntries);
            if (items.Length >= 3)
            {
                string[] drugItems = items[0].Split(',');
                foreach (string drugItem in drugItems)
                {
                    //if (drugItem.Equals(string.Empty)) continue;
                    dataGridView1.Rows.Add(new string[] { drugItem });
                }
                string[] jingTiItems = items[1].Split(',');
                foreach (string jingTiItem in jingTiItems)
                {
                    //if (jingTiItems.Equals(string.Empty)) continue;
                    dataGridView2.Rows.Add(new string[] { jingTiItem });
                }
                string[] jiaoTiItems = items[2].Split(',');
                foreach (string jiaoTiItem in jiaoTiItems)
                {
                    //if (jingTiItems.Equals(string.Empty)) continue;
                    dataGridView3.Rows.Add(new string[] { jiaoTiItem });
                }
            }            

        }

        private string GetFromServer(string key)
        {
            BusinessEntity.Configuations.ConfigTableDataTable configTable = new ConfigurationDA().GetConfigTableDataTable();
            if (!string.IsNullOrEmpty(key) && configTable != null)
            {
                DataRow[] rows = configTable.Select("Para_Key = '" + key + "'");
                if (rows != null && rows.Length == 1 && rows[0]["Para_Value"] != System.DBNull.Value && rows[0]["Para_Value"] != new byte[] { 0 })
                {
                    return StringHelper.Arr2Str((byte[])rows[0]["Para_Value"]);
                }
            }
            return null;
        }

        private void SaveToServer(string key, string value)
        {
            BusinessEntity.Configuations.ConfigTableDataTable configTable = new ConfigurationDA().GetConfigTableDataTable();
            if (!string.IsNullOrEmpty(key) && configTable != null)
            {
                DataRow[] rows = configTable.Select("Para_Key = '" + key + "'");
                if (rows != null && rows.Length == 1)
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        rows[0]["Para_Value"] = new byte[] { 0 };
                    }
                    else
                    {
                        rows[0]["Para_Value"] = StringHelper.Str2Arr(value);
                    }
                }
                else
                {
                    BusinessEntity.Configuations.ConfigTableRow row = configTable.NewConfigTableRow();
                    row.Para_Key = key;
                    if (string.IsNullOrEmpty(value))
                    {
                        row["Para_Value"] = new byte[] { 0 }; ;
                    }
                    else
                    {
                        row.Para_Value = StringHelper.Str2Arr(value);
                    }
                    configTable.AddConfigTableRow(row);
                }

                new ConfigurationDA().UpdateConfigTableDataTable(configTable);
            }
        }

        private void DeleteFromServer(string key)
        {
            BusinessEntity.Configuations.ConfigTableDataTable configTable = new ConfigurationDA().GetConfigTableDataTable();
            if (!string.IsNullOrEmpty(key) && configTable != null)
            {
                BusinessEntity.Configuations.ConfigTableRow configRow = configTable.FindByPara_Key(key);
                if (configRow!=null)
                {
                    configRow.Delete();
                    new ConfigurationDA() .UpdateConfigTableDataTable(configTable);
                }
            }
        }

        /// <summary>
        /// 上移行
        /// </summary>
        /// <param name="grid"></param>
        private void MoveUp(DataGridView grid)
        {
            if (grid.CurrentRow != null)
            {
                int index = grid.CurrentRow.Index;
                if (index > 0)
                {
                    string text = grid.CurrentCell.Value.ToString();
                    grid.Rows.Remove(grid.CurrentRow);
                    grid.Rows.Insert(index - 1, text);
                    grid.CurrentCell = grid.Rows[index - 1].Cells[0];
                }
            }
        }

        /// <summary>
        /// 下移行
        /// </summary>
        /// <param name="grid"></param>
        private void MoveDown(DataGridView grid)
        {
            if (grid.CurrentRow != null)
            {
                int index = grid.CurrentRow.Index;
                if (index < grid.Rows.Count - 1)
                {
                    string text = grid.CurrentCell.Value.ToString();
                    grid.Rows.Remove(grid.CurrentRow);
                    grid.Rows.Insert(index + 1, text);
                    grid.CurrentCell = grid.Rows[index + 1].Cells[0];
                }
            }
        }

        private void SetEditButtonStatus(bool enable)
        {
            btnDel.Enabled = enable;
            dataGridView1.Enabled = enable;
            dataGridView2.Enabled = enable;
            dataGridView3.Enabled = enable;
            btnMoveUp1.Enabled = enable;
            btnMoveUp2.Enabled = enable;
            btnMoveUp3.Enabled = enable;
            btnMoveDown1.Enabled = enable;
            btnMoveDown2.Enabled = enable;
            btnMoveDown3.Enabled = enable;
            btnInsert1.Enabled = enable;
            btnInsert2.Enabled = enable;
            btnInsert3.Enabled = enable;
            btnDelete1.Enabled = enable;
            btnDelete2.Enabled = enable;
            btnDelete3.Enabled = enable;
        }

        private void cmbTempletName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTempletName.SelectedIndex != -1 && cmbTempletName.SelectedItem != null && cmbTempletName.SelectedItem.ToString().Trim() != string.Empty)
            {
                SetEditButtonStatus(true);
                string str = GetFromServer("Model." + cmbTempletName.SelectedItem.ToString().Trim());
                if (str != null)
                {
                    BindGridData(str);
                }
                else
                {
                    BindGridData("");
                }
            }
            else
            {
                BindGridData("");
                SetEditButtonStatus(false);
                return;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = textEdit1.Text.Trim();
            if (!string.IsNullOrEmpty(name))
           {
               foreach (object obj in cmbTempletName.Properties.Items)
               {
                   if (obj.ToString().Equals(name.ToString().Trim()))
                   {
                       lblAddMessage.Text="模板名已存在,请填写其他名称";
                       return;
                   }
               }
               cmbTempletName.Properties.Items.Add(name.ToString().Trim());
               cmbTempletName.SelectedItem = name.ToString().Trim();
               btnAdd.Enabled = false;
               btnSave.Enabled = false;
               textEdit1.Text = "";
           }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult result = Wis.Anes.Framework.Utilities.Dialog.MessageBox("模板删除后不可恢复，您确定要删除吗？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result.Equals(DialogResult.OK))
            {
                if (cmbTempletName.SelectedItem != null && cmbTempletName.SelectedItem.ToString() != string.Empty)
                {
                    DeleteFromServer("Model." + cmbTempletName.SelectedItem.ToString());
                    cmbTempletName.Properties.Items.Remove(cmbTempletName.SelectedItem);
                    cmbTempletName.SelectedIndex = -1;
                    BindGridData("");
                    SetEditButtonStatus(false);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbTempletName.SelectedItem != null && cmbTempletName.SelectedItem.ToString().Trim() != "")
            {
                List<string> list = new List<string>();
                List<string> list1 = new List<string>();

                foreach (DataGridViewRow drow1 in dataGridView1.Rows)
                {
                    if (drow1.Cells[0].Value != null && !string.IsNullOrEmpty(drow1.Cells[0].Value.ToString().Trim()))
                    {
                        list1.Add(drow1.Cells[0].Value.ToString().Trim());
                    }
                    else
                    {
                        list1.Add(" ");
                    }
                }
                list.Add(string.Join(",", list1.ToArray()));
                List<string> list2 = new List<string>();
                foreach (DataGridViewRow drow2 in dataGridView2.Rows)
                {
                    if (drow2.Cells[0].Value != null && !string.IsNullOrEmpty(drow2.Cells[0].Value.ToString().Trim()))
                    {
                        list2.Add(drow2.Cells[0].Value.ToString().Trim());
                    }
                }
                list.Add(string.Join(",", list2.ToArray()));
                List<string> list3 = new List<string>();
                foreach (DataGridViewRow drow3 in dataGridView3.Rows)
                {
                    if (drow3.Cells[0].Value != null && !string.IsNullOrEmpty(drow3.Cells[0].Value.ToString().Trim()))
                    {
                        list3.Add(drow3.Cells[0].Value.ToString().Trim());
                    }
                }
                list.Add(string.Join(",", list3.ToArray()));
                string value = string.Join(";", list.ToArray());
                SaveToServer("Model." + cmbTempletName.SelectedItem.ToString(), value);
                btnSave.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (ParentForm != null && ParentForm.Modal)
            {
                ParentForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            lblAddMessage.Text = string.Empty;
            btnAdd.Enabled = (textEdit1.Text.Trim()!=string.Empty);
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void btnMoveUp1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1 && dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index > 0)
            {
                MoveUp(dataGridView1);
                btnSave.Enabled = true;
            }
        }

        private void btnMoveDown1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 1 && dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index > -1 && dataGridView1.CurrentRow.Index < dataGridView1.Rows.Count - 1)
            {
                MoveDown(dataGridView1);
                btnSave.Enabled = true;
            }
        }

        private void btnInsert1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(new string[] { "" });
            btnSave.Enabled = true;
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0 &&dataGridView1.CurrentRow!=null)
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                btnSave.Enabled = true;
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void btnMoveUp2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 1 && dataGridView2.CurrentRow != null && dataGridView2.CurrentRow.Index > 0)
            {
                MoveUp(dataGridView2);
                btnSave.Enabled = true;
            }
        }

        private void btnMoveDown2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.RowCount > 1 && dataGridView2.CurrentRow != null && dataGridView2.CurrentRow.Index > -1 && dataGridView2.CurrentRow.Index < dataGridView2.Rows.Count - 1)
            {
                MoveDown(dataGridView2);
                btnSave.Enabled = true;
            }
        }

        private void btnInsert2_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Add(new string[] { "" });
            btnSave.Enabled = true;
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0 && dataGridView2.CurrentRow != null)
            {
                dataGridView2.Rows.Remove(dataGridView2.CurrentRow);
                btnSave.Enabled = true;
            }
        }

        private void btnMoveUp3_Click(object sender, EventArgs e)
        {
            if (dataGridView3.Rows.Count > 1 && dataGridView3.CurrentRow != null && dataGridView3.CurrentRow.Index > 0)
            {
                MoveUp(dataGridView3);
                btnSave.Enabled = true;
            }
        }

        private void btnMoveDown3_Click(object sender, EventArgs e)
        {
            if (dataGridView3.RowCount > 1 && dataGridView3.CurrentRow != null && dataGridView3.CurrentRow.Index > -1 && dataGridView3.CurrentRow.Index < dataGridView3.Rows.Count - 1)
            {
                MoveDown(dataGridView3);
                btnSave.Enabled = true;
            }
        }

        private void btnInsert3_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Add(new string[] { "" });
            btnSave.Enabled = true;
        }

        private void btnDelete3_Click(object sender, EventArgs e)
        {
            if (dataGridView3.Rows.Count > 0 && dataGridView3.CurrentRow != null)
            {
                dataGridView3.Rows.Remove(dataGridView3.CurrentRow);
                btnSave.Enabled = true;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || _sourceRowsDrug == null || _sourceRowsDrug.Length == 0)
            {
                return;
            }
            Rectangle rect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            ShowSelector(rect, dataGridView1, _sourceRowsDrug);
  
        }

        private void ShowSelector(Rectangle rect, DataGridView dataGridView,DataRow[] sourceRows)
        {
            Dialog.ShowCustomSelection(sourceRows, "ITEM_NAME", dataGridView, new Point(rect.Left, rect.Bottom), new Size(rect.Width, 300)
                , new EventHandler(delegate(object sender1, EventArgs e1)
                {
                    if (sender1 is int)
                    {
                        int index = (int)sender1;
                        dataGridView.CurrentCell.Value = sourceRows[index]["ITEM_NAME"].ToString();
                        index = dataGridView.CurrentCell.RowIndex;
                        if (index < dataGridView.Rows.Count - 1)
                        {
                            dataGridView.CurrentCell = dataGridView.Rows[index + 1].Cells[0];
                            dataGridView.CurrentCell = dataGridView.Rows[index].Cells[0];
                        }
                        else if (index > 0)
                        {
                            dataGridView.CurrentCell = dataGridView.Rows[index - 1].Cells[0];
                            dataGridView.CurrentCell = dataGridView.Rows[index].Cells[0];
                        }
                    }
                }));
        }

        /// <summary>
        /// 获取筛选字符串
        /// </summary>
        /// <param name="anesClasses"></param>
        /// <returns></returns>
        private string GetFilterString(AnesClassType[] anesClasses)
        {
            string selectString = "(ITEM_CLASS = '" + EventTypeHelper.GetAnesClassTypeString(anesClasses[0]) + "')";
            for (int i = 1; i < anesClasses.Length; i++)
            {
                selectString += " OR (ITEM_CLASS = '" + EventTypeHelper.GetAnesClassTypeString(anesClasses[i]) + "')";
            }
            return selectString;
        }

        private void AnesDrugTemplet_Load(object sender, EventArgs e)
        {
            Dict.AnesthesiaEventOpenDataTable anesthesiaEventOpen = new DictDA().GetAnesthesiaEventOpen();
            if (anesthesiaEventOpen != null && anesthesiaEventOpen.Count > 0)
            {
                _sourceRowsDrug = anesthesiaEventOpen.Select(GetFilterString(new AnesClassType[] { AnesClassType.AnesDrug, AnesClassType.Drug }));
                _sourceRowsLiquid = anesthesiaEventOpen.Select(GetFilterString(new AnesClassType[] { AnesClassType.InLiquid, AnesClassType.InBlood }));
            }
            if (ParentForm != null)
            {
                ParentForm.CancelButton = btnCancel;
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || _sourceRowsLiquid == null || _sourceRowsLiquid.Length == 0)
            {
                return;
            }
            Rectangle rect = dataGridView2.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            ShowSelector(rect, dataGridView2, _sourceRowsLiquid);
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || _sourceRowsLiquid == null || _sourceRowsLiquid.Length == 0)
            {
                return;
            }
            Rectangle rect = dataGridView3.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            ShowSelector(rect, dataGridView3, _sourceRowsLiquid);
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                GridViewHelper.DataGridViewCellPainting(e);
            }
        }
    }
}
