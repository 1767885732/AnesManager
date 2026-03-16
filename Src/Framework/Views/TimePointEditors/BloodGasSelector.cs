using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework.Controls.Base;
using Wis.Anes.DataAccess;

namespace Wis.Anes.Framework
{
    [ToolboxItem(false)]
    public partial class BloodGasSelector1 : UserControl
    {
        public BloodGasSelector1()
        {
            InitializeComponent();
        }

        public BloodGasSelector1(string patientID, decimal visitID, decimal operID)
            : this()
        {
            _patientID = patientID;
            _visitID = visitID;
            _operID = operID;
            ResetList(patientID, visitID, operID);
        }

        private string _patientID;
        private decimal _visitID, _operID;
        private bool _isSelected = false;
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
        }

        public void SetDate(DateTime dateTime)
        {
            dateEdit1.DateTime = dateTime;
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

        private bool IsDateSame(DateTime dt1, DateTime dt2)
        {
            return dt1.Date.Equals(dt2.Date);
        }

        private void ResetList(string patientID, decimal visitID, decimal operID)
        {
            listView1.Items.Clear();
            List<BloodGasMaster> bloodGasMasters = new List<BloodGasMaster>();
            CareDocs.BloodGasMasterDataTable bloodGasMasterDataTable = new CareDocsDA().GetBloodGasMasterTable(dateEdit1.DateTime, dateEdit1.DateTime.AddDays(1));
            if (bloodGasMasterDataTable != null && bloodGasMasterDataTable.Count > 0)
            {
                foreach (CareDocs.BloodGasMasterRow row in bloodGasMasterDataTable)
                {
                    if ((dateEdit1.DateTime > new DateTime(2000, 1, 1) && IsDateSame(row.RECORD_DATE_TIME, dateEdit1.DateTime) && row.PAT_ID.Equals("0") && !row.IsNURSE_MEMO_2Null() && row.NURSE_MEMO_2.Equals("ok"))
                        || (!row.PAT_ID.Equals("0") && patientID.Contains(row.PAT_ID.Trim())))
                    {
                        BloodGasMaster bloodGasMaster = new BloodGasMaster();
                        bloodGasMaster.DisplayName = GetDisplayName(row);
                        bloodGasMaster.Recorddate = row.RECORD_DATE_TIME;
                        bloodGasMaster.DetailId = row.DETAIL_ID;
                        bloodGasMasters.Add(bloodGasMaster);
                    }
                }
            }
            bloodGasMasters.Sort(new Comparison<BloodGasMaster>(delegate(BloodGasMaster bloodGasMaster1, BloodGasMaster bloodGasMaster2)
                {
                    return bloodGasMaster1.Recorddate.CompareTo(bloodGasMaster2.Recorddate);
                }));
            foreach (BloodGasMaster bloodGasMaster in bloodGasMasters)
            {
                ListViewItem item = listView1.Items.Add(bloodGasMaster.Recorddate.ToString());// + "(" + bloodGasMaster.DisplayName + ")");
                item.Tag = bloodGasMaster.DetailId;
                item.ToolTipText = bloodGasMaster.DisplayName;
            }
        }

        private bool _mulitSelect = true;
        public bool MulitSelect
        {
            get
            {
                return _mulitSelect;
            }
            set
            {
                _mulitSelect = value;
            }
        }

        public bool ShowTip
        {
            set
            {
                lblMessage.Visible = value;
            }
        }

        private bool _allowSwitchAE = true;
        public bool AllowSwitchAE
        {
            get
            {
                return _allowSwitchAE;
            }
            set
            {
                _allowSwitchAE = false;
            }
        }

        private string _selectedList = "";
        public string SelectedList
        {
            get
            {
                return _selectedList;
            }
            set
            {
                _selectedList = value;
                string selectedList = _selectedList;
                if (selectedList == null)
                {
                    selectedList = "";
                }
                else
                {
                    selectedList = "," + selectedList + ",";
                }
            }
        }

        public Dictionary<string,bool> TypeList
        {
            get
            {
                Dictionary<string, bool> list = new Dictionary<string, bool>();
                foreach (ListViewItem item in listView1.Items)
                {
                    list.Add(item.Tag.ToString(),item.ToolTipText.Equals("动脉"));
                }
                return list;
            }
        }

        private void WHYX_BloodGasSelector_Load(object sender, EventArgs e)
        {
            if (ParentForm != null)
            {
                ParentForm.AcceptButton = btnOK;
                ParentForm.CancelButton = btnCancel;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ParentForm != null && ParentForm.Modal)
            {
                string selectedList = "";
                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.Tag != null && item.Checked)
                    {
                        selectedList += "," + item.Tag.ToString();
                    }
                }
                if (!string.IsNullOrEmpty(selectedList))
                {
                    selectedList = selectedList.Substring(1);
                }
                _selectedList = selectedList;
                _isSelected = true;
                ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (ParentForm != null && ParentForm.Modal)
            {
                ParentForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            ResetList(_patientID, _visitID, _operID);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems == null || listView1.SelectedItems.Count != 1 || !_allowSwitchAE)
            {
                return;
            }
            string oldText = listView1.SelectedItems[0].ToolTipText;
            string text = oldText;
            if (!text.Equals("动脉"))
            {
                text = "动脉";
            }
            else
            {
                text = "静脉";
            }
            listView1.SelectedItems[0].Checked = true;
            listView1.SelectedItems[0].Text = listView1.SelectedItems[0].Text.Replace(oldText, text);
            listView1.SelectedItems[0].ToolTipText = text;
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (!_mulitSelect && e.Item.Checked)
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    if (!item.Equals(e.Item))
                    {
                        item.Checked = false;
                    }
                }
            }
        }

    }
}
