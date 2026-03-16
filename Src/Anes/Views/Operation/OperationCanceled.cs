using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Constants;
using Wis.Anes.Framework;
using Wis.Anes.Framework.Utilities;
using Wis.Anes.Framework.Views;
using Wis.Anes.ServiceProxies;

namespace Wis.Anes.Views
{
    public partial class OperationCanceled : BaseView
    {
        DataTable _operDataTable = new DataTable();
        public OperationCanceled()
        {
            InitializeComponent();
        }
        public override void RefreshData()
        {
            base.RefreshData();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AllowUserToAddRows = false;
            this.btnSave.Enabled = true;
            _operDataTable = AnesthesiaSheetProxy.GetOperCanceledInfo();
            dataGridView1.DataSource = _operDataTable;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;

        }

        private void OperationCanceled_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.label1.Text = "";

            DataGridViewRow row = this.dataGridView1.CurrentRow;
            if (row == null)
            {
                this.label1.Text = "请先选择一位患者！";
                return;
            }
            if (Dialog.MessageBox("确定还原患者“" + row.Cells[3].Value.ToString() + "”的手术吗？"
     , "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, 0) == DialogResult.No)
            {
                return;
            }
            string patId = row.Cells[0].Value.ToString();
            string visitId = row.Cells[1].Value.ToString();
            string operId = row.Cells[2].Value.ToString();
            int count = AnesthesiaSheetProxy.UpdateCancelOper(patId, decimal.Parse(visitId), decimal.Parse(operId));
            if (count > 0)
            {
                this.label1.Text = "数据还原成功！";
            }
            else
            {
                this.label1.Text = "数据还原失败！";
            }

            RefreshData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.label1.Text = "";
            RefreshData();
        }
    }
}
