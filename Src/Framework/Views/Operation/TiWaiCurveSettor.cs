using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.DataAccess;
using Wis.Anes.BusinessEntity;

namespace Wis.Anes.Views
{
    [ToolboxItem(false)]
    public partial class TiWaiCurveSettor : UserControl
    {
        public TiWaiCurveSettor()
        {
            InitializeComponent();
        }

        public TiWaiCurveSettor(string patientID,decimal visitID,decimal operID)
        {
            _patientID = patientID;
            _visitID = visitID;
            _operID = operID;
            InitializeComponent();
        }

        private string _patientID;
        private decimal _visitID, _operID;

        private bool _isPerformed = false;
        public bool IsPerformed
        {
            get
            {
                return _isPerformed;
            }
        }

        private void WHYX_TiWaiCurveSettor_Load(object sender, EventArgs e)
        {
            if (ParentForm != null)
            {
                ParentForm.AcceptButton = btnOK;
                ParentForm.CancelButton = btnCancel;
            }
        }

        public void SetList(List<string> list)
        {
            SetList(listView1, list);
            SetList(listView2, list);
            SetList(listView3, list);
            LoadSetting();
        }

        private void SetList(ListView listView, List<string> list)
        {
            listView.Items.Clear();
            foreach (string text in list)
            {
                ListViewItem item = listView.Items.Add(text);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveSetting();
            _isPerformed = true;
            ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (ParentForm != null && ParentForm.Modal)
            {
                ParentForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }

        private string GetSettings()
        {
            return GetSetting(listView1) + "{}" + GetSetting(listView2) + "{}" + GetSetting(listView3);
        }

        private string GetSetting(ListView listView)
        {
            string value = "";
            foreach (ListViewItem item in listView.Items)
            {
                if (item.Checked)
                {
                    value += "[]" + item.Text;
                }
            }
            if (!string.IsNullOrEmpty(value))
            {
                value = value.Substring(2);
            }
            return value;
        }


        private CareDocs.WIS_CUSTOM_DATARow AddCustomDataRow(CareDocs.WIS_CUSTOM_DATADataTable dataTable, string patientID, int visitID, int operID, string itemName, string itemValue)
        {
            CareDocs.WIS_CUSTOM_DATARow row = dataTable.NewWIS_CUSTOM_DATARow();
            row.PAT_ID = patientID;
            row.VISIT_ID = visitID;
            row.OPER_ID = operID;
            row.ITEM_NAME = itemName;
            row.ITEM_VALUE = itemValue;
            dataTable.AddWIS_CUSTOM_DATARow(row);
            return row;
        }

        private void SaveCustomDataRow(CareDocs.WIS_CUSTOM_DATADataTable dataTable, string patientID, int visitID, int operID, string itemName, string itemValue)
        {
            CareDocs.WIS_CUSTOM_DATARow row1 = dataTable.FindByPAT_IDVISIT_IDOPER_IDITEM_NAME(patientID, visitID, operID, itemName);
            if (row1 == null)
            {
                AddCustomDataRow(dataTable, patientID, visitID, operID, itemName, itemValue);
            }
            else
            {
                row1.ITEM_VALUE = itemValue;
            }
        }

        private bool SaveSetting()
        {
            if (string.IsNullOrEmpty(_patientID))
            {
                return false;
            }
            bool result = false;
            string value = GetSettings();

            CareDocs.WIS_CUSTOM_DATADataTable customData = new CareDocsDA(). GetCustomData(_patientID, (int)_visitID, (int)_operID);
            SaveCustomDataRow(customData, _patientID, (int)_visitID, (int)_operID, "体外循环显示曲线设置", value);
            int ret = new CareDocsDA().UpdateCustomData(customData);
            if (ret > 0)
            {
                result = true;
            }
            return result;
        }

        private void SetListViewSelect(ListView listView,string selectStrings)
        {
            string[] setItems = selectStrings.Split(new string[] { "[]" }, StringSplitOptions.RemoveEmptyEntries);
            if (setItems != null && setItems.Length > 0)
            {
                foreach (string s in setItems)
                {
                    foreach (ListViewItem item in listView.Items)
                    {
                        if (item.Text.Equals(s))
                        {
                            item.Checked = true;
                        }
                    }
                }
            }
        }


        public static string TiWaiSettingStrings
        {
            get
            {
                return "鼻咽温[]肛温[]呼吸[]平均动脉压[]心率[]收缩压[]舒张压[]动脉收缩压[]动脉舒张压{}鼻咽温[]肛温[]呼吸[]平均动脉压[]收缩压[]舒张压[]动脉收缩压[]动脉舒张压{}鼻咽温[]肛温[]呼吸[]平均动脉压[]心率[]收缩压[]舒张压[]动脉收缩压[]动脉舒张压";
            }
        }
        private void LoadSetting()
        {
            if (string.IsNullOrEmpty(_patientID))
            {
                return;
            }
            CareDocs.WIS_CUSTOM_DATADataTable customData = new CareDocsDA().GetCustomData(_patientID, (int)_visitID, (int)_operID);
            CareDocs.WIS_CUSTOM_DATARow row = customData.FindByPAT_IDVISIT_IDOPER_IDITEM_NAME(_patientID, _visitID, _operID, "体外循环显示曲线设置");
            string settingStrings = TiWaiSettingStrings;
            if (row != null && !row.IsITEM_VALUENull() && !string.IsNullOrEmpty(row.ITEM_VALUE))
            {
                settingStrings = row.ITEM_VALUE;
            }
            string[] setts = settingStrings.Split(new string[] { "{}" }, StringSplitOptions.None);
            if (setts != null && setts.Length == 3)
            {
                SetListViewSelect(listView1, setts[0]);
                SetListViewSelect(listView2, setts[1]);
                SetListViewSelect(listView3, setts[2]);
            }
        }
    }
}
