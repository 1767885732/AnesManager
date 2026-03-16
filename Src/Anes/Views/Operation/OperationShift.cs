using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Views;
using Wis.Anes.BusinessEntity;
using Wis.Anes.ServiceProxies;
using Wis.Anes.Framework;
using Wis.Anes.Framework.Utilities;
using Wis.Anes.Constants;

namespace Wis.Anes.Views
{
    public partial class OperationShift : BaseView
    {
        private AnesInformations.OperShiftRecordDataTable _operShiftRecordDataTable = null;
        private Dict.HisUserDataTable _hisUserTable = new Dict.HisUserDataTable();
        private List<Dict.HisUserRow> _selectRows = new List<Dict.HisUserRow>();

        public OperationShift()
        {
            InitializeComponent();
            Caption = ViewNames.OperationShift;
        }

        public override void RefreshData()
        {
            base.RefreshData();
            dataGridView1.AutoGenerateColumns = false;
            _operShiftRecordDataTable = AnesthesiaSheetProxy.GetOperShiftRecordDataTable(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID);
            dataGridView1.DataSource = _operShiftRecordDataTable;
            if (_operShiftRecordDataTable != null && dataGridView1.RowCount > 0 && dataGridView1.CurrentRow != null)
            {
                btnDel.Enabled = true;
            }
            else
            {
                btnDel.Enabled = false;
            }
            btnSave.Enabled = false;
        }

        private void OperationShift_Load(object sender, EventArgs e)
        {
            if (!Framework.AccessControl.CheckModifyRight(ViewNames.OperationShift))
            {
                dataGridView1.ReadOnly = true;
            }
            _hisUserTable=DictProxy.GetHisUsers();
            (dataGridView1.Columns[2] as DataGridViewComboBoxColumn).DataSource = _hisUserTable;
            (dataGridView1.Columns[2] as DataGridViewComboBoxColumn).DisplayMember = "USER_NAME";
            (dataGridView1.Columns[2] as DataGridViewComboBoxColumn).ValueMember = "USER_ID";

            (dataGridView1.Columns[3] as DataGridViewComboBoxColumn).DataSource = _hisUserTable;
            (dataGridView1.Columns[3] as DataGridViewComboBoxColumn).DisplayMember = "USER_NAME";
            (dataGridView1.Columns[3] as DataGridViewComboBoxColumn).ValueMember = "USER_ID";

            RefreshData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_operShiftRecordDataTable == null)
                return;
            var row = _operShiftRecordDataTable.NewOperShiftRecordRow();
            row.PAT_ID = ExtendApplicationContext.Current.PatientContext.PatientID;
            row.VISIT_ID = ExtendApplicationContext.Current.PatientContext.VisitID;
            row.OPER_ID = ExtendApplicationContext.Current.PatientContext.OperID;
            decimal serialNo = -1;
            foreach (AnesInformations.OperShiftRecordRow dr in _operShiftRecordDataTable)
            {
                if (dr.SHIFT_NO > serialNo) serialNo = dr.SHIFT_NO;
            }
            serialNo++;
            row.SHIFT_NO = serialNo;
            _operShiftRecordDataTable.AddOperShiftRecordRow(row);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index >= 0)
            {
                _operShiftRecordDataTable.RemoveOperShiftRecordRow(_operShiftRecordDataTable[dataGridView1.CurrentRow.Index]);
                btnSave.Enabled = true;
                if (dataGridView1.CurrentRow != null)
                {
                    btnDel.Enabled = true;
                }
                else
                {
                    btnDel.Enabled = false;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_operShiftRecordDataTable != null)
            {
                foreach (AnesInformations.OperShiftRecordRow row in _operShiftRecordDataTable.Rows)
                {
                    if (row.IsSHIFT_DATE_TIMENull()||row.IsSHIFTED_BYNull()||row.IsSHIFT_PERSONNull()||row.IsSHIFT_DUTYNull())
                    {
                        Dialog.MessageBox("请补充完整除备注外的其他信息");
                        return;
                    }
                }
            }
            if (AnesthesiaSheetProxy.UpdateOperShiftRecordDataTable(_operShiftRecordDataTable)>0)
            {
                Dialog.MessageBox("保存成功!");
            }
            btnSave.Enabled = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (ParentForm != null && ParentForm.Modal)
            {
                ParentForm.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.ReadOnly || e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                return;
            }
            Rectangle rect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            if (e.ColumnIndex == 1)
            {
                Dialog.ShowDateTimeSelector(DateTime.Now, dataGridView1, new Point(rect.Left, rect.Bottom), new EventHandler(delegate(object s1, EventArgs e1)
                    {
                        if(s1 is DateTime)
                        {
                            dataGridView1.CurrentCell.Value = DateTime.Parse(s1.ToString());
                        }
                    }), "yyyy-MM-dd HH:mm");
            }
            else if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {
                
                Dialog.ShowCustomSelection(_hisUserTable, "USER_NAME", dataGridView1, new Point(rect.Left, rect.Bottom), new Size(rect.Width, 300)
                    , new EventHandler(delegate(object s1, EventArgs e1)
                    {
                        if (s1 is int)
                        {
                            int index = (int)s1;
                            dataGridView1.CurrentCell.Value = _hisUserTable[index].USER_ID;
                        }
                    }));
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (_operShiftRecordDataTable != null && dataGridView1.RowCount > 0 && dataGridView1.CurrentRow != null)
            {
                btnDel.Enabled = true;
            }
            else
            {
                btnDel.Enabled = false;
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Value != null)
            {
                Rectangle rect = e.CellBounds;
                if (e.Value.GetType() == typeof(Color))
                {
                    e.Handled = true;
                    e.PaintBackground(e.ClipBounds, true);
                    rect.Inflate(-10, -5);
                    e.Graphics.FillRectangle(new SolidBrush((Color)e.Value), rect);
                }
            }
            else if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                GridViewHelper.DataGridViewCellPainting(e);
            }
        }


    }
}
