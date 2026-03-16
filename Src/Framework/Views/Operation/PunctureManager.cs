using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Views;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework.Utilities;
using Wis.Anes.Framework;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.DataAccess;

namespace Wis.Anes.Views
{
    [ToolboxItem(false)]
    public partial class PunctureManager : BaseView
    {
        private AnesInformations.PunctureRecordDataTable _punctureRecordDataTable;
        private Dict.HisUserDataTable _hisUser;
        private Dict.AnesthesiaInputDictDataTable _anesthesiaInputDictDataTable;

        public PunctureManager()
        {
            InitializeComponent();
            Caption = "穿刺管理";
        }

        /// <summary>
        /// 刷新患者数据
        /// </summary>
        public override void RefreshData()
        {
            base.RefreshData();
            _punctureRecordDataTable = new AnesthesiaSheetDA().GetPunctureRecordDataTable(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID);
            if (_punctureRecordDataTable != null && _punctureRecordDataTable.Count > 0)
            {
                AnesInformations.PunctureRecordRow row = _punctureRecordDataTable[0];
                txtArteryPuncturePerson.Text = row.IsA_PUNCTURE_PERSONNull() ? string.Empty : row.A_PUNCTURE_PERSON;
                txtArteryPunctureNeedle.Text = row.IsA_PUNCTURE_NEEDLENull()?"": row.A_PUNCTURE_NEEDLE;
                txtArteryPuncturePosition.Text = row.IsA_PUNCTURE_POSITIONNull() ? "" : row.A_PUNCTURE_POSITION;
                chkArteryComplications1.Checked = !row.IsA_COMPLICATIONS_1Null() && row.A_COMPLICATIONS_1.Equals(1);
                chkArteryComplications2.Checked = !row.IsA_COMPLICATIONS_2Null() && row.A_COMPLICATIONS_2.Equals(1);
                chkArteryComplications3.Checked = !row.IsA_COMPLICATIONS_3Null() && row.A_COMPLICATIONS_3.Equals(1);
                txtVenousPuncturePerson.Text = row.IsV_PUNCTURE_PERSONNull() ? "" : row.V_PUNCTURE_PERSON;
                txtVenousPunctureNeedle.Text = row.IsV_PUNCTURE_NEEDLENull() ? "" : row.V_PUNCTURE_NEEDLE;
                txtVenousPuncturePosition.Text = row.IsV_PUNCTURE_POSITIONNull() ? "" : row.V_PUNCTURE_POSITION;
                chkVenousComplications1.Checked = !row.IsV_COMPLICATIONS_1Null() && row.V_COMPLICATIONS_1.Equals(1);
                chkVenousComplications2.Checked = !row.IsV_COMPLICATIONS_2Null() && row.V_COMPLICATIONS_2.Equals(1);
                chkVenousComplications3.Checked = !row.IsV_COMPLICATIONS_3Null() && row.V_COMPLICATIONS_3.Equals(1);
                chkVenousComplications4.Checked = !row.IsV_COMPLICATIONS_4Null() && row.V_COMPLICATIONS_4.Equals(1);
                chkVenousComplications5.Checked = !row.IsV_COMPLICATIONS_5Null() && row.V_COMPLICATIONS_5.Equals(1);
                txtNurse.Text = row.IsPUNCTURE_NURSENull() ? "" : row.PUNCTURE_NURSE;
                txtMemo.Text = row.IsMEMONull() ? "" : row.MEMO;
                timeEdit1.Time = row.IsRECORD_TIMENull() ? DateTime.Now : row.RECORD_TIME;
            }
            else
            {
                timeEdit1.Time = DateTime.Now;
            }
            btnSave.Enabled = false;
        }

        public override bool IsDirty
        {
            get
            {
                return btnSave.Enabled;
            }
        }

        public override bool Save()
        {
            bool b = false;
            AnesInformations.PunctureRecordRow row;
            if (_punctureRecordDataTable != null && _punctureRecordDataTable.Count > 0)
            {
                row = _punctureRecordDataTable[0];
            }
            else
            {
                row = _punctureRecordDataTable.NewPunctureRecordRow();
                row.PAT_ID = ExtendApplicationContext.Current.PatientContext.PatientID;
                row.VISIT_ID = ExtendApplicationContext.Current.PatientContext.VisitID;
                row.OPER_ID = ExtendApplicationContext.Current.PatientContext.OperID;
                _punctureRecordDataTable.AddPunctureRecordRow(row);
            }
            if (string.IsNullOrEmpty(txtArteryPuncturePerson.Text.Trim()))
            {
                row.SetA_PUNCTURE_PERSONNull();
            }
            else
            {
                row.A_PUNCTURE_PERSON = txtArteryPuncturePerson.Text.Trim();
            }
            if (string.IsNullOrEmpty(txtArteryPunctureNeedle.Text.Trim()))
            {
                row.SetA_PUNCTURE_NEEDLENull();
            }
            else
            {
                row.A_PUNCTURE_NEEDLE = txtArteryPunctureNeedle.Text.Trim();
            }
            if (string.IsNullOrEmpty(txtArteryPuncturePosition.Text.Trim()))
            {
                row.SetA_PUNCTURE_POSITIONNull();
            }
            else
            {
                row.A_PUNCTURE_POSITION = txtArteryPuncturePosition.Text.Trim();
            }
            if (string.IsNullOrEmpty(txtVenousPuncturePerson.Text.Trim()))
            {
                row.SetV_PUNCTURE_PERSONNull();
            }
            else
            {
                row.V_PUNCTURE_PERSON = txtVenousPuncturePerson.Text.Trim();
            }
            if (string.IsNullOrEmpty(txtArteryPunctureNeedle.Text.Trim()))
            {
                row.SetV_PUNCTURE_NEEDLENull();
            }
            else
            {
                row.V_PUNCTURE_NEEDLE = txtArteryPunctureNeedle.Text.Trim();
            }
            if (string.IsNullOrEmpty(txtVenousPuncturePosition.Text.Trim()))
            {
                row.SetV_PUNCTURE_POSITIONNull();
            }
            else
            {
                row.V_PUNCTURE_POSITION = txtVenousPuncturePosition.Text.Trim();
            }
            if (string.IsNullOrEmpty(txtNurse.Text.Trim()))
            {
                row.SetPUNCTURE_NURSENull();
            }
            else
            {
                row.PUNCTURE_NURSE = txtNurse.Text.Trim();
            }
            if (string.IsNullOrEmpty(txtMemo.Text.Trim()))
            {
                row.SetMEMONull();
            }
            else
            {
                row.MEMO = txtMemo.Text.Trim();
            }
            if (timeEdit1.Time.Equals(DateTime.MinValue))
            {
                row.SetRECORD_TIMENull();
            }
            else
            {
                row.RECORD_TIME = timeEdit1.Time;
            }
            row.A_COMPLICATIONS_1 = chkArteryComplications1.Checked ? 1 : 0;
            row.A_COMPLICATIONS_2 = chkArteryComplications2.Checked ? 1 : 0;
            row.A_COMPLICATIONS_3 = chkArteryComplications3.Checked ? 1 : 0;
            row.V_COMPLICATIONS_1 = chkVenousComplications1.Checked ? 1 : 0;
            row.V_COMPLICATIONS_2 = chkVenousComplications2.Checked ? 1 : 0;
            row.V_COMPLICATIONS_3 = chkVenousComplications3.Checked ? 1 : 0;
            row.V_COMPLICATIONS_4 = chkVenousComplications4.Checked ? 1 : 0;
            row.V_COMPLICATIONS_5 = chkVenousComplications5.Checked ? 1 : 0;
            if (new AnesthesiaSheetDA().UpdatePunctureRecordDataTable(_punctureRecordDataTable) > 0)
            {
                b = true;
            }
            return b;
        }

        private void PunctureManager_Load(object sender, EventArgs e)
        {
            if (!AccessControl.CheckModifyRight("穿刺管理"))
            {
                this.txtArteryPunctureNeedle.Enabled = false;
                this.txtArteryPuncturePerson.Enabled = false;
                this.txtArteryPuncturePosition.Enabled = false;
                this.txtVenousPunctureNeedle.Enabled = false;
                this.txtVenousPuncturePerson.Enabled = false;
                this.txtVenousPuncturePosition.Enabled = false;
                txtMemo.Enabled = false;
                txtNurse.Enabled = false;
                this.chkArteryComplications1.Enabled = false;
                this.chkArteryComplications2.Enabled = false;
                this.chkArteryComplications3.Enabled = false;
                this.chkVenousComplications1.Enabled = false;
                this.chkVenousComplications2.Enabled = false;
                this.chkVenousComplications3.Enabled = false;
                this.chkVenousComplications4.Enabled = false;
                this.chkVenousComplications5.Enabled = false;
                timeEdit1.Enabled = false;
            }
            _hisUser = new DictDA() .GetHisUsers();
            _anesthesiaInputDictDataTable = new DictDA().GetAnesthesiaInputDict();
            RefreshData();
        }

        private void txtArteryPuncturePerson_DoubleClick(object sender, EventArgs e)
        {
            //DataHelper.SelectFromDataTable(_hisUser, "USER_NAME", sender as Control, false);
            DevExpress.XtraEditors.TextEdit textBox=sender as DevExpress.XtraEditors.TextEdit;
            if (textBox.Equals(txtArteryPuncturePerson) || textBox.Equals(txtVenousPuncturePerson) || textBox.Equals(txtNurse))
            {
                DataRow[] rows;
                if (sender.Equals(txtNurse))
                {
                    rows = _hisUser.Select("USER_DEPT = '" + ApplicationConfiguration.AnesthesiaWardCode + "' AND USER_JOB = '护士'");
                }
                else
                {
                    rows = _hisUser.Select("USER_DEPT = '" + ApplicationConfiguration.AnesthesiaWardCode + "' AND USER_JOB = '医生'");
                }
            Dialog.ShowCustomSelection(rows,  "USER_NAME", textBox,
                        new System.Drawing.Size(textBox.Width, 300), new EventHandler(delegate(object sender1, EventArgs e1)
                         {
                             if (sender1 is int)
                             {
                                 int result = (int)sender1;
                                 if (result > -1)
                                 {
                                     if (string.IsNullOrEmpty(textBox.Text.Trim()))
                                     {
                                         textBox.Text = rows[result]["USER_NAME"].ToString();
                                     }
                                     else
                                     {
                                         textBox.Text = textBox.Text + "," + rows[result]["USER_NAME"].ToString();
                                     }
                                 }
                             }
                         }));
            }
            else if(textBox.Equals(txtArteryPunctureNeedle))
            {
                DataRow[] rows = _anesthesiaInputDictDataTable.Select("ITEM_CLASS='动脉穿刺针'");
                Dialog.SelectFromRows(rows, "ITEM_NAME", sender as Control, false);
            }
            else if (textBox.Equals(txtArteryPuncturePosition))
            {
                DataRow[] rows = _anesthesiaInputDictDataTable.Select("ITEM_CLASS='动脉穿刺点'");
                Dialog.SelectFromRows(rows, "ITEM_NAME", sender as Control, false);
            }
            else if (textBox.Equals(txtVenousPuncturePerson))
            {
                DataRow[] rows = _anesthesiaInputDictDataTable.Select("ITEM_CLASS='深静脉穿刺针'");
                Dialog.SelectFromRows(rows, "ITEM_NAME", sender as Control, false);
            }
            else if (textBox.Equals(txtVenousPuncturePosition))
            {
                DataRow[] rows = _anesthesiaInputDictDataTable.Select("ITEM_CLASS='深静脉穿刺点'");
                Dialog.SelectFromRows(rows, "ITEM_NAME", sender as Control, false);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                Dialog.MessageBox("保存成功！");
            }
            btnSave.Enabled = false;
        }

        private void btnQueryInfo_Click(object sender, EventArgs e)
        {
            PunctureQuery view = new PunctureQuery();
            DialogHostForm1 dialogHostForm = new DialogHostForm1("穿刺记录",800,600);
            dialogHostForm.Child = view;
            dialogHostForm.ShowDialog();
        }

        private void txtArteryPuncturePerson_EditValueChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void chkArteryComplications1_EditValueChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void timeEdit1_EditValueChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }
    }
}
