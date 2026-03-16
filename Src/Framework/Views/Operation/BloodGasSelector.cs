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
using Wis.Anes.Framework.Controls.Base;

namespace Wis.Anes.Framework
{
    [ToolboxItem(false)]
    public partial class BloodGasSelector : XtraUserControl
    {
        private string _patientID;
        private decimal _visitID;
        private decimal _operID;
        private CareDocsDA _careDocsDA;
        private DateTime _defaultDate=DateTime.Now.Date;

        public DateTime DefaultDate
        {
            get { return _defaultDate; }
            set { _defaultDate = value; }
        }

        private string _selectedDetailID="";

        public string SelectedDetailID
        {
            get { return _selectedDetailID; }
            set { _selectedDetailID = value; }
        }

        public BloodGasSelector()
        {
            InitializeComponent();
        }

        public BloodGasSelector(string patientID, decimal visitID, decimal operID):this()
        {
            _patientID = patientID;
            _visitID = visitID;
            _operID = operID;
            btnOK.Enabled = false;
        }

        private string GetDisplayName(CareDocs.BloodGasMasterRow row)
        {
            string itemText = "静脉";
            if (!row.IsNURSE_MEMO_1Null() && !string.IsNullOrEmpty(row.NURSE_MEMO_1.Trim()))
            {
                itemText = row.NURSE_MEMO_1;
            }
            return itemText;
        }

        private void resetListView()
        {
            btnOK.Enabled = false;
            listView1.Items.Clear();
            listView2.Items.Clear();
            List<BloodGasMaster> leftBloodGasMasters = new List<BloodGasMaster>();
            List<BloodGasMaster> rightBloodGasMasters = new List<BloodGasMaster>();
            CareDocs.BloodGasMasterDataTable bloodGasMasterDataTable = _careDocsDA.GetBloodGasMasterTable(dateEdit1.DateTime.Date, dateEdit1.DateTime.Date.AddDays(1));
            if (bloodGasMasterDataTable != null && bloodGasMasterDataTable.Count > 0)
            {
                BloodGasMaster bloodGasMaster;
                foreach (CareDocs.BloodGasMasterRow row in bloodGasMasterDataTable.Rows)
                {
                    if (!string.IsNullOrEmpty(row.PAT_ID) && row.PAT_ID == _patientID && row.VISIT_ID == _visitID && row.OPER_ID == _operID)
                    {
                        bloodGasMaster = new BloodGasMaster();
                        bloodGasMaster.DisplayName = GetDisplayName(row);
                        bloodGasMaster.Recorddate = row.RECORD_DATE_TIME;
                        bloodGasMaster.DetailId = row.DETAIL_ID;
                        leftBloodGasMasters.Add(bloodGasMaster);
                    }
                    else if (string.IsNullOrEmpty(row.PAT_ID) || (row.PAT_ID == "0" && row.VISIT_ID == 0))
                    {
                        bloodGasMaster = new BloodGasMaster();
                        bloodGasMaster.DisplayName = GetDisplayName(row);
                        bloodGasMaster.Recorddate = row.RECORD_DATE_TIME;
                        bloodGasMaster.DetailId = row.DETAIL_ID;
                        rightBloodGasMasters.Add(bloodGasMaster);
                    }
                }
                leftBloodGasMasters.Sort(new Comparison<BloodGasMaster>(delegate(BloodGasMaster bloodGasMaster1, BloodGasMaster bloodGasMaster2)
                {
                    return bloodGasMaster1.Recorddate.CompareTo(bloodGasMaster2.Recorddate);
                }));
                rightBloodGasMasters.Sort(new Comparison<BloodGasMaster>(delegate(BloodGasMaster bloodGasMaster1, BloodGasMaster bloodGasMaster2)
                {
                    return bloodGasMaster1.Recorddate.CompareTo(bloodGasMaster2.Recorddate);
                }));
                ListViewItem item;
                foreach (BloodGasMaster blgMaster in leftBloodGasMasters)
                {
                    item = listView1.Items.Add(blgMaster.Recorddate.ToString());
                    item.Tag = blgMaster.DetailId;
                    item.ToolTipText = blgMaster.DisplayName;
                }
                foreach (BloodGasMaster blgMaster in rightBloodGasMasters)
                {
                    item = listView2.Items.Add(blgMaster.Recorddate.ToString());
                    item.Tag = blgMaster.DetailId;
                    item.ToolTipText = blgMaster.DisplayName;
                }
            }
        }

        private void BloodGasSelector_Load(object sender, EventArgs e)
        {
            _careDocsDA = new CareDocsDA();
            dateEdit1.DateTime = DefaultDate;
            resetListView();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ParentForm.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //foreach (ListViewItem item in listView1.Items)
            //{
            //    if (item.Tag != null && item.Checked)
            //    {
            //        SelectedDetailID = item.Tag.ToString();
            //        break;
            //    }
            //}
            if (listView1.Items.Count > 0 && listView1.SelectedItems.Count == 1)
            {
                SelectedDetailID = listView1.SelectedItems[0].Tag.ToString();
                ParentForm.DialogResult = DialogResult.OK;
            }
            
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (listView1.Items.Count == 0 || listView1.FocusedItem == null || listView1.SelectedItems.Count == 0)
            {
                e.Cancel = true;
            }
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
            if (listView2.Items.Count == 0 || listView2.FocusedItem == null || listView2.SelectedItems.Count == 0)
            {
                e.Cancel = true;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listView1.FocusedItem != null)
            {
                CareDocs.BloodGasMasterDataTable bloodGasMasterDataTable = _careDocsDA.GetBloodGasMasterTable(listView1.FocusedItem.Tag.ToString());
                if(bloodGasMasterDataTable!=null&&bloodGasMasterDataTable.Count==1)
                {
                    bloodGasMasterDataTable[0].PAT_ID = "0";
                    bloodGasMasterDataTable[0].VISIT_ID = 0;
                    bloodGasMasterDataTable[0].OPER_ID = 0;
                    bloodGasMasterDataTable[0].SetNURSE_MEMO_1Null();
                    bloodGasMasterDataTable[0].SetNURSE_MEMO_2Null();
                    if (_careDocsDA.UpdateBloodGasMaster(bloodGasMasterDataTable) > 0)
                    {
                        resetListView();
                    }
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (listView2.FocusedItem != null)
            {
                CareDocs.BloodGasMasterDataTable bloodGasMasterDataTable = _careDocsDA.GetBloodGasMasterTable(listView2.FocusedItem.Tag.ToString());
                if (bloodGasMasterDataTable != null && bloodGasMasterDataTable.Count == 1)
                {
                    bloodGasMasterDataTable[0].PAT_ID = _patientID;
                    bloodGasMasterDataTable[0].VISIT_ID = _visitID;
                    bloodGasMasterDataTable[0].OPER_ID = _operID;
                    if (_careDocsDA.UpdateBloodGasMaster(bloodGasMasterDataTable) > 0)
                    {
                        resetListView();
                    }
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems != null && listView1.SelectedItems.Count == 1)
            {
                btnOK.Enabled = true;
            }
            else
            {
                btnOK.Enabled = false;
            }
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            resetListView();
        }
    }
}
