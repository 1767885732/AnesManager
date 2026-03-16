using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework;
using Wis.Anes.Framework.Views;
using Wis.Anes.Framework.Utilities;

namespace Wis.Anes.Custom.Views
{

    public partial class EditEventItem : BaseView
    {
        public enum ItemTypes
        {
            EventItem,
            MedicineItem,
            OtherItem,
        }


        protected ItemTypes _itemType;   // 类型
        protected DataRow _dataRow;    // 数据

        public EditEventItem()
        {
            InitializeComponent();

        }

        public Color TitleColor
        {
            get { return labelName.ForeColor; }
            set { labelName.ForeColor = value; }
        }

        public ItemTypes ItemType
        {
            get { return _itemType; }
            set { _itemType = value; }
        }

        public DataRow DataSource
        {
            get { return _dataRow; }
            set { _dataRow = value; }
        }

        public bool IsDelete
        {
            get
            {
                return chkDelete.Checked;
            }
            set
            {
                chkDelete.Checked = value;
            }
        }

        public bool IsAllowDel
        {
            get
            {
                return chkDelete.Visible;
            }
            set
            {
                chkDelete.Visible = value;
            }
        }

        private void EditEventItem_Load(object sender, EventArgs e)
        {
            labelName.Text = _dataRow["ITEM_NAME"].ToString();
            chkDelete.Text = "删除";
            timeEditStart.Time = (DateTime)_dataRow["START_DATE_TIME"];
            if (_dataRow.IsNull("END_DATE_TIME"))
            {
                timeEditEnd.Time = DateTime.Now;
                timeEditEnd.Enabled = false;
                checkEndDate.Checked = false;
            }
            else
            {
                timeEditEnd.Time = (DateTime)_dataRow["END_DATE_TIME"];
                timeEditEnd.Enabled = true;
                checkEndDate.Checked = true;
            }

            if (_itemType == ItemTypes.EventItem)
            {
                if (_dataRow["ITEM_NAME"].ToString().EndsWith("呼吸"))
                {
                    panelMid.Height = 65;
                    foreach (Control ctl in panelMid.Controls)
                    {
                        ctl.Visible = false;
                    }
                    chkContinued.Text = "持续";
                    labelDosage.Text = "频率";
                    labelDosage.Location = new Point(16, 39);
                    txtDosage.Location = new Point(56, 38);
                    chkContinued.Visible = true;
                    labelDosage.Visible = true;
                    txtDosage.Visible = true;
                }
                else
                {
                    panelMid.Visible = false;
                    return;
                }
            }

            if (!_dataRow.IsNull("DURATIVE_INDICATOR"))
                chkContinued.Checked = _dataRow["DURATIVE_INDICATOR"].ToString() == "1" ? true : false;

            if (!_dataRow.IsNull("ADMINISTRATOR"))
                txtPath.Text = _dataRow["ADMINISTRATOR"].ToString();

            if (!_dataRow.IsNull("CONCENTRATION"))
                txtDensity.Text = _dataRow["CONCENTRATION"].ToString();

            if (!_dataRow.IsNull("CONCENTRATION_UNITS"))
                txtPathUnit.Text = _dataRow["CONCENTRATION_UNITS"].ToString();

            if (!_dataRow.IsNull("PERFORM_SPEED"))
                txtSpeed.Text = _dataRow["PERFORM_SPEED"].ToString();

            if (!_dataRow.IsNull("SPEED_UNITS"))
                txtSpeedUnit.Text = _dataRow["SPEED_UNITS"].ToString();

            if (!_dataRow.IsNull("DOSAGE"))
                txtDosage.Text = _dataRow["DOSAGE"].ToString();

            if (!_dataRow.IsNull("DOSAGE_UNITS"))
                txtDosageUnit.Text = _dataRow["DOSAGE_UNITS"].ToString();
        }

        private void checkEndDate_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEndDate.Checked)
            {
                timeEditEnd.Enabled = true;
                //chkContinued.Checked = true;
            }
            else
            {
                timeEditEnd.Enabled = false;
                //chkContinued.Checked = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _dataRow["START_DATE_TIME"] = timeEditStart.Time;
            if (!checkEndDate.Checked)
                _dataRow["END_DATE_TIME"] = DBNull.Value;
            else
                _dataRow["END_DATE_TIME"] = timeEditEnd.Time;

            if (chkContinued.Checked)
                _dataRow["DURATIVE_INDICATOR"] = 1;
            else if (!_dataRow.IsNull("DURATIVE_INDICATOR"))
                _dataRow["DURATIVE_INDICATOR"] = 0;

            if (txtPath.Text.Trim() == "")
                _dataRow["ADMINISTRATOR"] = DBNull.Value;
            else
                _dataRow["ADMINISTRATOR"] = txtPath.Text.Trim();

            if (txtDensity.Text.Trim() == "")
                _dataRow["CONCENTRATION"] = DBNull.Value;
            else
                _dataRow["CONCENTRATION"] = Convert.ToDouble(txtDensity.Text);

            if (txtPathUnit.Text.Trim() == "")
                _dataRow["CONCENTRATION_UNITS"] = DBNull.Value;
            else
                _dataRow["CONCENTRATION_UNITS"] = txtPathUnit.Text.Trim();

            if (txtSpeed.Text.Trim() == "")
                _dataRow["PERFORM_SPEED"] = DBNull.Value;
            else
                _dataRow["PERFORM_SPEED"] = Convert.ToDouble(txtSpeed.Text);

            if (txtSpeedUnit.Text.Trim() == "")
                _dataRow["SPEED_UNITS"] = DBNull.Value;
            else
                _dataRow["SPEED_UNITS"] = txtSpeedUnit.Text.Trim();

            if (txtDosage.Text.Trim() == "")
                _dataRow["DOSAGE"] = DBNull.Value;
            else
                _dataRow["DOSAGE"] = Convert.ToDouble(txtDosage.Text);

            if (txtDosageUnit.Text.Trim() == "")
                _dataRow["DOSAGE_UNITS"] = DBNull.Value;
            else
                _dataRow["DOSAGE_UNITS"] = txtDosageUnit.Text.Trim();

        }

        private void timeEditStart_Properties_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs me = e as MouseEventArgs;
            if (me.X < 150)
            {
                timeEditStart.Time = DateTime.Now;
            }
        }

        private void timeEditEnd_Properties_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs me = e as MouseEventArgs;
            if (me.X < 150)
            {
                timeEditEnd.Time = DateTime.Now;
            }
        }

        /// <summary>
        /// 验证输入的结束时间是否大于开始时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timeEditEnd_Leave(object sender, EventArgs e)
        {
            if (timeEditEnd.Time < timeEditStart.Time)
            {

                if (Dialog.MessageBox("结束时间必须大于开始时间，是否继续！", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    timeEditEnd.Time = timeEditStart.Time.AddMinutes(1);//验证输入的结束时间是否大于开始时间 若false 则开始时间加一分钟
                }
            }
        }

        private void EditEventItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(13))
            {
                btnSave.PerformClick();
            }
        }


    }


}
