using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Wis.Anes.BusinessEntity;
using Wis.Anes.DataAccess;
using Wis.Anes.Framework.Utilities;

namespace Wis.Anes.Framework
{
    [ToolboxItem(false)]
    public partial class GridRowItemSelector : UserControl
    {
        private string initString = "";
        public GridRowItemSelector()
        {
            InitializeComponent();
            InitComboxData();
        }

        public GridRowItemSelector(string patientID, decimal visitID, decimal operID)
        {
            _patientID = patientID;
            _visitID = visitID;
            _operID = operID;
            InitializeComponent();
            InitComboxData();
        }

        private string _patientID;
        private decimal _visitID, _operID;
        private int _count = 0;
        private  Wis.Anes.BusinessEntity.Dict.AnesthesiaEventOpenDataTable _anesthesiaEventOpen;

        private bool _isPerformed = false;
        public bool IsPerformed
        {
            get
            {
                return _isPerformed;
            }
        }

        private void InitComboxData()
        {
            cmbTempletName.Properties.Items.Clear();
            cmbTempletName.Properties.Items.Add("");
            BusinessEntity.Configuations.ConfigTableDataTable configTable = new ConfigurationDA().GetConfigTableDataTable();
            if (configTable != null && configTable.Count > 0)
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
            cmbTempletName.SelectedIndex = 0;
        }

        public void SetList(string value)
        {
            initString = value;
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            string[] items = value.Split(';');
            if (items.Length >= 3)
            {
                string[] drugItems = items[0].Split(',');
                _count = drugItems.Length;
                foreach (string drugItem in drugItems)
                {
                    dataGridView1.Rows.Add(new string[] { drugItem });
                }
                string[] jingTiItems = items[1].Split(',');
                foreach (string jingTiItem in jingTiItems)
                {
                    dataGridView2.Rows.Add(new string[] { jingTiItem });
                }
                string[] jiaoTiItems = items[2].Split(',');
                foreach (string jiaoTiItem in jiaoTiItems)
                {
                    dataGridView3.Rows.Add(new string[] { jiaoTiItem });
                }
            }
        }

        private void BindGridData(string value)
        {
            string[] items = value.Split(';');
            if (items.Length >= 3)
            {
                string[] drugItems = items[0].Split(',');
                if (drugItems.Length > 0)
                {
                    for (int i = 0; i < drugItems.Length; i++)
                    {
                        if (i > (dataGridView1.Rows.Count - 1)) break;
                        dataGridView1[0, i].Value = drugItems[i];
                    }
                }
                for (int i = drugItems.Length; i < dataGridView1.Rows.Count - 1; i++)
                {
                    dataGridView1[0, i].Value = "";
                }
                string[] jingTiItems = items[1].Split(',');
                if (jingTiItems.Length > 0)
                {
                    for (int i = 0; i < jingTiItems.Length; i++)
                    {
                        if (i > (dataGridView2.Rows.Count - 1)) break;
                        dataGridView2[0, i].Value = jingTiItems[i];
                    }
                }
                string[] jiaoTiItems = items[2].Split(',');
                if (jiaoTiItems.Length > 0)
                {
                    for (int i = 0; i < jiaoTiItems.Length; i++)
                    {
                        if (i > (dataGridView3.Rows.Count - 1)) break;
                        dataGridView3[0, i].Value = jiaoTiItems[i];
                    }
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

        private void SetButtonStatus()
        {
            btnInsert.Enabled = dataGridView1.Rows.Count < _count;
            btnDelete.Enabled = dataGridView1.Rows.Count > 0 && dataGridView1.CurrentRow != null;
            btnMoveDown.Enabled = dataGridView1.Rows.Count > 1 && dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index < dataGridView1.Rows.Count - 1;
            btnMoveUp.Enabled = dataGridView1.Rows.Count > 1 && dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index > 0;
        }

        private void SetButtonStatus(int index)
        {
            btnInsert.Enabled = dataGridView1.Rows.Count < _count;
            btnDelete.Enabled = dataGridView1.Rows.Count > 0 && index >= 0;
            btnMoveDown.Enabled = dataGridView1.Rows.Count > 1 && index < dataGridView1.Rows.Count - 1;
            btnMoveUp.Enabled = dataGridView1.Rows.Count > 1 && index > 0;
        }

        private void SetButtonStatus(DataGridView grid, SimpleButton moveDownButton, SimpleButton moveUpButton)
        {
            moveDownButton.Enabled = grid.Rows.Count > 1 && grid.CurrentRow != null && grid.CurrentRow.Index < grid.Rows.Count - 1;
            moveUpButton.Enabled = grid.Rows.Count > 1 && grid.CurrentRow != null && grid.CurrentRow.Index > 0;
        }

        private void SetButtonStatus(int index, DataGridView grid, SimpleButton moveDownButton, SimpleButton moveUpButton)
        {
            moveDownButton.Enabled = grid.Rows.Count > 1 && index < grid.Rows.Count - 1;
            moveUpButton.Enabled = grid.Rows.Count > 1 && index > 0;
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

        private bool SaveSetting(decimal itemType,DataGridView grid )
        {
            bool result = false;

            AnesInformations.WIS_PAT_DRUG_DETAILDataTable datatable;
            if (!string.IsNullOrEmpty(_patientID))
            {
                datatable = new AnesthesiaSheetDA().GetPatientDrugItem(_patientID, _visitID, _operID, itemType);
            }
            else
            {
                datatable = new AnesthesiaSheetDA().GetPatientDrugItem(ExtendApplicationContext.Current.PatientContext.PatientID
                    , ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID, itemType);
            }
            foreach (DataRow row in datatable.Rows)
            {
                row.Delete();
            }

            decimal serialNo = itemType*1000;
            foreach (DataGridViewRow row in grid.Rows)
            {
                string text = "";
                if (row.Cells[0].Value != null && !string.IsNullOrEmpty(row.Cells[0].Value.ToString()))
                {
                    text = row.Cells[0].Value.ToString();
                }
                AnesInformations.WIS_PAT_DRUG_DETAILRow itemRow = datatable.NewWIS_PAT_DRUG_DETAILRow();
                if (!string.IsNullOrEmpty(_patientID))
                {
                    itemRow.PAT_ID = _patientID;
                    itemRow.VISIT_ID = _visitID;
                    itemRow.OPER_ID = _operID;
                }
                else
                {
                    itemRow.PAT_ID = ExtendApplicationContext.Current.PatientContext.PatientID;
                    itemRow.VISIT_ID = ExtendApplicationContext.Current.PatientContext.VisitID;
                    itemRow.OPER_ID = ExtendApplicationContext.Current.PatientContext.OperID;
                }
                itemRow.SERIAL_NO = serialNo ++;
                itemRow.ITEM_NAME_1 = text;
                datatable.AddWIS_PAT_DRUG_DETAILRow(itemRow);
            }

            int ret = new AnesthesiaSheetDA() .UpdatePatientDrugItem(datatable);
            if (ret > 0)
            {
                result = true;
            }
            return result;
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                Wis.Anes.Framework.Utilities.GridViewHelper.DataGridViewCellPainting(e);
            }
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

        private void ShowSelector(Rectangle rect, DataGridView dataGridView, AnesClassType anesClass)
        {
            ShowSelector(rect, dataGridView, new AnesClassType[] { anesClass });
        }

        private void ShowSelector(Rectangle rect, DataGridView dataGridView,AnesClassType[] anesClasses)
        {
            DataRow[] sourceRows = GetSourceRows(anesClasses);
            if (sourceRows != null)
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
        }

        private DataRow[] GetSourceRows(AnesClassType[] anesClasses)
        {
            if (_anesthesiaEventOpen != null && _anesthesiaEventOpen.Count > 0)
            {
                return _anesthesiaEventOpen.Select(GetFilterString(anesClasses));
            }
            return null;
        }

        private void WHYX_GridRowItemSelector_Load(object sender, EventArgs e)
        {
            _anesthesiaEventOpen = new DictDA() .GetAnesthesiaEventOpen();
            if (ParentForm != null)
            {
                ParentForm.AcceptButton = btnOK;
                ParentForm.CancelButton = btnCancel;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (ParentForm != null && ParentForm.Modal)
            {
                ParentForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveSetting(1,dataGridView1);
            SaveSetting(2, dataGridView2);
            SaveSetting(3, dataGridView3);
            _isPerformed = true;
            ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Dialog.MessageBox("真的要删除当前行吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int index = dataGridView1.CurrentRow.Index;
                dataGridView1.Rows.RemoveAt(index);
                if (dataGridView1.Rows.Count > index)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[index].Cells[0];
                }
                else
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];
                    }
                    else
                    {
                        dataGridView1.CurrentCell = null;
                    }
                }
                SetButtonStatus();
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (grid.Equals(dataGridView1))
            {
                 SetButtonStatus(e.RowIndex,grid,btnMoveDown,btnMoveUp);
            }
            else if (grid.Equals(dataGridView2))
            {
                SetButtonStatus(e.RowIndex,grid,btnMoveDown1,btnMoveUp1);
            }
            else if(grid.Equals(dataGridView3))
            {
                SetButtonStatus(e.RowIndex,grid,btnMoveDown2,btnMoveUp2);
            }
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            SimpleButton button = sender as SimpleButton;
            if (button.Equals(btnMoveUp))
            {
                MoveUp(dataGridView1);
                SetButtonStatus(dataGridView1, btnMoveDown, btnMoveUp);
            }
            else if (button.Equals(btnMoveUp1))
            {
                MoveUp(dataGridView2);
                SetButtonStatus(dataGridView2, btnMoveDown1, btnMoveUp1);
            }
            else if (button.Equals(btnMoveUp2))
            {
                MoveUp(dataGridView3);
                SetButtonStatus(dataGridView3, btnMoveDown2, btnMoveUp2);
            }
            
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            SimpleButton button = sender as SimpleButton;
            if (button.Equals(btnMoveDown))
            {
                MoveDown(dataGridView1);
                SetButtonStatus(dataGridView1,btnMoveDown,btnMoveUp);
            }
            else if (button.Equals(btnMoveDown1))
            {
                MoveDown(dataGridView2);
                SetButtonStatus(dataGridView2, btnMoveDown1, btnMoveUp1);
            }
            else if (button.Equals(btnMoveDown2))
            {
                MoveDown(dataGridView3);
                SetButtonStatus(dataGridView3, btnMoveDown2, btnMoveUp2);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;
            dataGridView1.Rows.Insert(index, 1);
            dataGridView1.CurrentCell = dataGridView1.Rows[index].Cells[0];
            dataGridView1.CurrentCell.Value = "";
            SetButtonStatus();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            Rectangle rect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            ShowSelector(rect, dataGridView1,new AnesClassType[]{AnesClassType.AnesDrug,AnesClassType.Drug});
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            Rectangle rect = dataGridView2.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            ShowSelector(rect, dataGridView2,AnesClassType.InLiquid);
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            Rectangle rect = dataGridView3.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            ShowSelector(rect, dataGridView3,AnesClassType.InBlood);
        }

        private void cmbTempletName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTempletName.SelectedItem != null&&cmbTempletName.SelectedIndex > -1)
            {
                if (cmbTempletName.SelectedItem.ToString().Trim() == "")
                {
                    BindGridData(initString);
                }
                else
                {
                    string str = GetFromServer("Model." + cmbTempletName.SelectedItem.ToString().Trim());
                    if (str != null)
                    {
                        BindGridData(str);
                    }
                }
            }
        }


    }
}
