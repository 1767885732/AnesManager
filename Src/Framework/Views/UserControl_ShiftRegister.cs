using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Utilities;
using Wis.Anes.Framework.Views;
using Wis.Anes.DataAccess;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework.Controls.Base;
using Wis.Anes.Framework.Configurations;
using DevExpress.XtraEditors;

namespace Wis.Anes.Framework
{
    public partial class UserControl_ShiftRegister : BaseView
    {

        private string _patientID;
        private decimal _visitID, _operID;

        public UserControl_ShiftRegister() : this("", 0, 0) { }
        public UserControl_ShiftRegister(string patientID,decimal visitID,decimal operID)
        {
            Caption = "手术交班";
            _patientID = patientID;
            _visitID = visitID;
            _operID = operID;
            InitializeComponent();
            Load += new EventHandler(UserControl_ShiftRegister_Load);
        }
        AnesInformations.AnesOperHandoverDataTable anesOperHandoverDataTable = new AnesthesiaSheetDA().GetAnesOperHandoverDataTable(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID);
     
        private void UserControl_ShiftRegister_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                if (ParentForm != null)
                {
                    ParentForm.AcceptButton = btnOK;
                    ParentForm.CancelButton = btnCancel;
                }
                dateEdit1.DateTime = DateTime.Now;
                dateEdit2.DateTime = DateTime.Now;
                Dict.HisUserDataTable hisUserDict = ExtendApplicationContext.Current.CodeTables["WIS_PERM_HIS_USER"] as Dict.HisUserDataTable;
                if (!string.IsNullOrEmpty(_patientID))
                {
                    AnesInformations.OperationMasterDataTable operationMaster = new AnesthesiaSheetDA().GetOperationMaster(_patientID, _visitID, _operID);
                    if (operationMaster != null && operationMaster.Count == 1)
                    {
                        if (!operationMaster[0].IsANES_DOCTORNull())
                        {
                            txtAnesDoctor.Text = GetHisUserName(operationMaster[0].ANES_DOCTOR, hisUserDict);
                        }
                        if (!operationMaster[0].IsSECOND_ANES_DOCTORNull())
                        {
                            txtSecondAnesDoctor.Text = GetHisUserName(operationMaster[0].SECOND_ANES_DOCTOR, hisUserDict);
                        }
                        if (!operationMaster[0].IsFIRST_OPER_NURSENull())
                        {
                            txtFirstOperNurse.Text = GetHisUserName(operationMaster[0].FIRST_OPER_NURSE, hisUserDict);
                        }
                        if (!operationMaster[0].IsSECOND_OPER_NURSENull())
                        {
                            txtSecondOperNurse.Text = GetHisUserName(operationMaster[0].SECOND_OPER_NURSE, hisUserDict);
                        }
                        if (!operationMaster[0].IsFIRST_SUPPLY_NURSENull())
                        {
                            txtFirstSuppleNurse.Text = GetHisUserName(operationMaster[0].FIRST_SUPPLY_NURSE, hisUserDict);
                        }
                        if (!operationMaster[0].IsSECOND_SUPPLY_NURSENull())
                        {
                            txtSecondSuppleNurse.Text = GetHisUserName(operationMaster[0].SECOND_SUPPLY_NURSE, hisUserDict);
                        }
                    }

                    if (anesOperHandoverDataTable != null && anesOperHandoverDataTable.Count >= 1)
                    {
                        AnesInformations.AnesOperHandoverRow anesOperHandoverRow = anesOperHandoverDataTable[0];
                        if (!anesOperHandoverRow.IsFIRST_ANES_DOCTORNull())
                        {
                            txtAnesDoctor1.SetData(anesOperHandoverRow.FIRST_ANES_DOCTOR);
                            txtAnesDoctor1.Text = GetHisUserName(anesOperHandoverRow.FIRST_ANES_DOCTOR, hisUserDict);
                        }
                        if (!anesOperHandoverRow.IsSECOND_ANES_DOCTORNull())
                        {
                            txtSecondAnesDoctor1.SetData(anesOperHandoverRow.SECOND_ANES_DOCTOR);
                            txtSecondAnesDoctor1.Text = GetHisUserName(anesOperHandoverRow.SECOND_ANES_DOCTOR, hisUserDict);
                        }
                        if (!anesOperHandoverRow.IsFIRST_OPER_NURSENull())
                        {
                            txtFirstOperNurse1.SetData(anesOperHandoverRow.FIRST_OPER_NURSE);
                            txtFirstOperNurse1.Text = GetHisUserName(anesOperHandoverRow.FIRST_OPER_NURSE, hisUserDict);
                        }
                        if (!anesOperHandoverRow.IsSECOND_ANES_DOCTORNull())
                        {
                            txtSecondOperNurse1.SetData(anesOperHandoverRow.SECOND_OPER_NURSE);
                            txtSecondOperNurse1.Text = GetHisUserName(anesOperHandoverRow.SECOND_OPER_NURSE, hisUserDict);
                        }
                        if (!anesOperHandoverRow.IsTHIRD_OPER_NURSENull())
                        {
                            txtFirstSuppleNurse1.SetData(anesOperHandoverRow.THIRD_OPER_NURSE);
                            txtFirstSuppleNurse1.Text = GetHisUserName(anesOperHandoverRow.THIRD_OPER_NURSE, hisUserDict);
                        }
                        if (!anesOperHandoverRow.IsOTHERNull())
                        {
                            txtSecondSuppleNurse1.SetData(anesOperHandoverRow.OTHER);
                            txtSecondSuppleNurse1.Text = GetHisUserName(anesOperHandoverRow.OTHER, hisUserDict);
                        }
                        if (!anesOperHandoverRow.IsHANDOVER_DATE_TIME_1Null())
                        {
                            dateEdit1.DateTime = anesOperHandoverRow.HANDOVER_DATE_TIME_1;
                        }
                        if (!anesOperHandoverRow.IsHANDOVER_DATE_TIME_2Null())
                        {
                            dateEdit2.DateTime = anesOperHandoverRow.HANDOVER_DATE_TIME_2;
                        }
                    }
                    else if (anesOperHandoverDataTable != null && anesOperHandoverDataTable.Count == 0)
                    {
                        AnesInformations.AnesOperHandoverRow anesOperHandoverRow= anesOperHandoverDataTable.NewAnesOperHandoverRow();
                        anesOperHandoverRow.PAT_ID = _patientID;
                        anesOperHandoverRow.VISIT_ID = _visitID;
                        anesOperHandoverRow.OPER_ID = _operID;
                        
                        anesOperHandoverDataTable.AddAnesOperHandoverRow(anesOperHandoverRow);
                    }
                }

            }
        }
        private string GetHisUserName(string userInfo, Dict.HisUserDataTable userTable)
        {
            Dict.HisUserRow row = userTable.FindByUSER_ID(userInfo);

            if (row != null)
            {
                return row.USER_NAME;
            }
            else
            {
                return userInfo;
            }


        }
        private void txtCode2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtFirstNurse_EditValueChanged(object sender, EventArgs e)
        {

        }


        private void Login(string loginName, string loginPassWord)
        {

            this.Cursor = Cursors.WaitCursor;


            loginPassWord = Sundries.Encrypto(loginPassWord);
            bool isLogin = false;

            try
            {
                isLogin = CommonSysemHelper.Login(loginName, loginPassWord);

            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
            if (isLogin)
            {

                //登录成功，加上配置
                ApplicationConfiguration.UserLoginName = loginName;

            }
            else
            {
                DialogResult dialogResult = XtraMessageBox.Show("您输入的密码或用户名有误，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            this.Cursor = Cursors.Default; 
        }
        private void btnOK_Click(object sender, EventArgs e)
        {

            //if (!string.IsNullOrEmpty(txtAnesDoctor1.Text))
            //{
            //    object result = Dialog.SingleInputSelect("请录入接班医生 " + txtAnesDoctor1.Text + " 密码", "", "*");
            //    if (result != null)
            //    {

            //        Login(txtAnesDoctor1.Text, result.ToString());


            //    }
            //    else
            //    {
            //        return ;
            //    }
            //}


            AnesInformations.AnesOperHandoverRow anesOperHandoverRow = anesOperHandoverDataTable[0];
            anesOperHandoverRow.FIRST_ANES_DOCTOR = txtAnesDoctor1.Data == null ? "" : txtAnesDoctor1.Data.ToString() ;
            anesOperHandoverRow.SECOND_ANES_DOCTOR = txtSecondAnesDoctor1.Data == null ? "" : txtSecondAnesDoctor1.Data.ToString();
            anesOperHandoverRow.FIRST_OPER_NURSE = txtFirstOperNurse1.Data == null ? "" : txtFirstOperNurse1.Data.ToString();
            anesOperHandoverRow.SECOND_OPER_NURSE = txtSecondOperNurse1.Data == null ? "" : txtSecondOperNurse1.Data.ToString();
            anesOperHandoverRow.THIRD_OPER_NURSE = txtFirstSuppleNurse1.Data == null ? "" : txtFirstSuppleNurse1.Data.ToString();
            anesOperHandoverRow.OTHER = txtSecondSuppleNurse1.Data == null ? "" : txtSecondSuppleNurse1.Data.ToString();

            if (!string.IsNullOrEmpty(txtAnesDoctor1.Text) || !string.IsNullOrEmpty(txtSecondAnesDoctor1.Text))
            {
                anesOperHandoverRow.HANDOVER_DATE_TIME_1 = dateEdit1.DateTime;
            }

            if (!string.IsNullOrEmpty(txtFirstOperNurse1.Text) || !string.IsNullOrEmpty(txtSecondOperNurse1.Text) || !string.IsNullOrEmpty(txtFirstSuppleNurse1.Text) || !string.IsNullOrEmpty(txtSecondSuppleNurse1.Text))
            {
                anesOperHandoverRow.HANDOVER_DATE_TIME_2 = dateEdit2.DateTime;
            }

            if (new AnesthesiaSheetDA().UpdateAnesOperHandoverDataTable(anesOperHandoverDataTable) > 0)
            {
                // DialogResult = DialogResult.OK;
                XtraMessageBox.Show("保存成功", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtSecondNurse_EditValueChanged(object sender, EventArgs e)
        {

        }


        private void txtAnesDoctor1_TextChanged(object sender, EventArgs e)
        {
            //btnOK.Enabled = !string.IsNullOrEmpty(txtAnesDoctor1.Text);
        }

        private void dateEdit1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if ((DateTime)e.NewValue > DateTime.Now.AddDays(2) || (DateTime)e.NewValue < DateTime.Now.AddDays(-2))
            {
                Dialog.MessageBox("您选择的时间超出当前时间2天，请验证后再输入。");
                e.Cancel = true;
            }
        }

        private void dateEdit2_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if ((DateTime)e.NewValue > DateTime.Now.AddDays(2) || (DateTime)e.NewValue < DateTime.Now.AddDays(-2))
            {
                Dialog.MessageBox("您选择的时间超出当前时间2天，请验证后再输入。");
                e.Cancel = true;
            }
        }
    }
}
