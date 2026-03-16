using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Wis.Anes.Framework
{
    [ToolboxItem(false)]
    public partial class DrugSummeryInputor : UserControl
    {
        private List<DrugSummeryItem> _drugSummeryItemList = null;
        public List<DrugSummeryItem> DrugSummeryItemList
        {
            get
            {
                return _drugSummeryItemList;
            }
        }

        private bool _isPerformed = false;
        public bool IsPerformed
        {
            get
            {
                return _isPerformed;
            }
        }

        public DrugSummeryInputor()
        {
            InitializeComponent();
        }

        public DrugSummeryInputor(List<DrugSummeryItem> list):this()
        {
            _drugSummeryItemList = list;
        }

        private void DrugSummeryInputor_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                if (_drugSummeryItemList != null && _drugSummeryItemList.Count > 0)
                {
                    foreach (DrugSummeryItem item in _drugSummeryItemList)
                    {
                        dataGridView1.Rows.Add(new object[] { item.ItemName, item.Value });
                    }
                }
                if (ParentForm != null)
                {
                    ParentForm.AcceptButton = btnOK;
                    ParentForm.CancelButton = btnCancel;
                }
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                Wis.Anes.Framework.Utilities.GridViewHelper.DataGridViewCellPainting(e);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _drugSummeryItemList = new List<DrugSummeryItem>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                _drugSummeryItemList.Add(new DrugSummeryItem(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString()));
            }
            _isPerformed = true;
        }
    }
}
