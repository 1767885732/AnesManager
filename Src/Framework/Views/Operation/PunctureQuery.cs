using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Wis.Anes.Framework.Views;
using Wis.Anes.Framework;
using Wis.Anes.DataAccess;

namespace Wis.Anes.Views
{
    [ToolboxItem(false)]
    public partial class PunctureQuery : BaseView
    {
        public PunctureQuery()
        {
            InitializeComponent();
        }

        private void PunctureQuery_Load(object sender, EventArgs e)
        {
            Caption = "穿刺记录";
            dateTimePickerEnd.Value = DateTime.Now.Date;
            dateTimePickerStart.Value = DateTime.Now.Date.AddMonths(-1);
            List<LookUpEditItem> data1 = new List<LookUpEditItem>();
            data1.Add(new LookUpEditItem("是", 1M));
            data1.Add(new LookUpEditItem("否", 0M));
            repositoryItemLookUpEdit1.DataSource = data1;
            btnSearch.PerformClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = new StatisticsDA().GetPunctureQueryTable(dateTimePickerStart.Value, dateTimePickerEnd.Value.AddDays(1));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (ParentForm != null && ParentForm.Modal)
            {
                ParentForm.DialogResult = DialogResult.Cancel;
                //Globals.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
