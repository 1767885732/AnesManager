using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Views;
using Wis.Anes.Framework;
using Wis.Anes.DataAccess;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.Framework.Utilities;
using DevExpress.XtraEditors;

namespace Wis.Anes.Custom.CustomProject.Views
{
    public partial class EmergencyRegister : BaseView
    {
        private bool bPatientID_Change = false;
        public bool ResultData = false;
        public EmergencyRegister()
        {
            InitializeComponent();
            Caption = "急诊登记";
            txtPatientID.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            txtOperRoomNo.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            dtBirthDay.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            dtScheduledTime.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
        }

        private void SyncPatientByPatientId(string patient_id)
        {
            if (ApplicationConfiguration.SyncOpen)
            {
                SyncDA syncDA = new SyncDA();
                if (!string.IsNullOrEmpty(patient_id))
                {
                    string ret = "";
                    try
                    {
                        ret = syncDA.SyncPatientInfoAndInHospital(patient_id);
                        ret = syncDA.SyncScheduleInfo(patient_id,ApplicationConfiguration.SyncDateDiff);
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandler.Handle(ex);
                    }
                }
            }
            btnSave.Enabled = true;
            AnesthesiaSheetDA anesthesiaSheetDA = new AnesthesiaSheetDA();
            AnesInformations.OperationMasterDataTable dtOperMaster = anesthesiaSheetDA.GetOperationMaster(patient_id);
            DataRow[] rows = dtOperMaster.Select(" scheduled_date_time >= '" + System.DateTime.Today + "' and scheduled_date_time < '" + System.DateTime.Today.AddDays(1) + "'and oper_status < 35 ");
            if (rows != null && rows.Length > 0)
            {
                DialogResult dresult = Dialog.MessageBox("患者 " + patient_id + " 已经在当天的手术列表中,是否继续？", "急诊录入提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dresult != DialogResult.Yes)
                {
                    btnSave.Enabled = false; ;
                }
            }
            if (patient_id != "")
            {
                DataTable dt = (new CommonDA()).GetDataWithPrimaryKey("WIS_PAT_MASTER_INDEX", " WHERE PAT_ID = '" + patient_id + "'");
                dtScheduledTime.EditValue = DateTime.Now.Date.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute);
                if (dt != null && dt.Rows.Count >= 1)
                {
                    txtPatientName.Text = dt.Rows[0]["NAME"] != null ? dt.Rows[0]["NAME"].ToString() : string.Empty;
                    txtPatientSex.Text = dt.Rows[0]["SEX"] != null ? dt.Rows[0]["SEX"].ToString() : string.Empty;
                    txtInpNo.Text = dt.Rows[0]["INP_NO"] != null ? dt.Rows[0]["INP_NO"].ToString() : string.Empty;
                    if (dt.Rows[0]["DATE_OF_BIRTH"] != null && dt.Rows[0]["DATE_OF_BIRTH"].ToString().Trim() != "")
                    {
                        dtBirthDay.EditValue = (DateTime)dt.Rows[0]["DATE_OF_BIRTH"];
                    }
                    else
                    {
                        dtBirthDay.EditValue = null;
                    }
                }
                dt = (new CommonDA()).GetDataWithPrimaryKey("WIS_PAT_IN_HOS", "WHERE PAT_ID = '" + patient_id + "'");
                if (dt != null && dt.Rows.Count >= 1)
                {
                    txtBedNo.Text = dt.Rows[0]["BED_NO"] != null ? dt.Rows[0]["BED_NO"].ToString() : string.Empty;
                    txtDepartStayed.SetData(dt.Rows[0]["DEPT_CODE"]);
                    if (txtDepartStayed.Data!=null&&txtDepartStayed.DictTableName != null && ExtendApplicationContext.Current.CodeTables.ContainsKey(txtDepartStayed.DictTableName.ToUpper()))
                    {
                        Dict.DeptDictDataTable dataTable = ExtendApplicationContext.Current.CodeTables[txtDepartStayed.DictTableName.ToUpper()] as Dict.DeptDictDataTable;
                        Dict.DeptDictRow dictRow = dataTable.FindByDEPT_CODE(txtDepartStayed.Data.ToString());
                        if (dictRow != null)
                        {
                            txtDepartStayed.Text = dictRow.DEPT_NAME;
                        }
                    }
                    txtDiagBeforeOperation.Text = dt.Rows[0]["DIAGNOSIS"] != null ? dt.Rows[0]["DIAGNOSIS"].ToString() : string.Empty;
                }
            }
        }

        private void SyncPatientByInpNo(string inpNo)
        {
            if (ApplicationConfiguration.SyncOpen)
            {
                SyncDA syncDA = new SyncDA();
                if (!string.IsNullOrEmpty(inpNo))
                {
                    string ret = "";
                    try
                    {
                        ret = syncDA.SyncPatientInfoAndInHospitalByInpNo(inpNo);
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandler.Handle(ex);
                    }
                }
            }
            btnSave.Enabled = true;
            if (inpNo != "")
            {
                DataTable dt = (new CommonDA()).GetDataWithPrimaryKey("WIS_PAT_MASTER_INDEX", " WHERE INP_NO = '" + inpNo + "'");
                dtScheduledTime.EditValue = DateTime.Now.Date.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute);
                if (dt != null && dt.Rows.Count >= 1)
                {
                    txtPatientID.Text = dt.Rows[0]["PAT_ID"].ToString();
                    txtPatientID.ErrorText = string.Empty;
                    txtPatientName.Text = dt.Rows[0]["NAME"] != null ? dt.Rows[0]["NAME"].ToString() : string.Empty;
                    txtPatientSex.Text = dt.Rows[0]["SEX"] != null ? dt.Rows[0]["SEX"].ToString() : string.Empty;
                    if (dt.Rows[0]["DATE_OF_BIRTH"] != null && dt.Rows[0]["DATE_OF_BIRTH"].ToString().Trim() != "")
                    {
                        dtBirthDay.EditValue = (DateTime)dt.Rows[0]["DATE_OF_BIRTH"];
                    }
                    else
                    {
                        dtBirthDay.EditValue = null;
                    }
                }
                dt = (new CommonDA()).GetDataWithPrimaryKey("WIS_PAT_IN_HOS", "WHERE PAT_ID = '" + txtPatientID.Text + "'");
                if (dt != null && dt.Rows.Count >= 1)
                {
                    txtBedNo.Text = dt.Rows[0]["BED_NO"] != null ? dt.Rows[0]["BED_NO"].ToString() : string.Empty;
                    txtDepartStayed.SetData(dt.Rows[0]["DEPT_CODE"]);
                    if (txtDepartStayed.Data != null && txtDepartStayed.DictTableName != null && ExtendApplicationContext.Current.CodeTables.ContainsKey(txtDepartStayed.DictTableName.ToUpper()))
                    {
                        Dict.DeptDictDataTable dataTable = ExtendApplicationContext.Current.CodeTables[txtDepartStayed.DictTableName.ToUpper()] as Dict.DeptDictDataTable;
                        Dict.DeptDictRow dictRow = dataTable.FindByDEPT_CODE(txtDepartStayed.Data.ToString());
                        if (dictRow != null)
                        {
                            txtDepartStayed.Text = dictRow.DEPT_NAME;
                        }
                    }
                    txtDiagBeforeOperation.Text = dt.Rows[0]["DIAGNOSIS"] != null ? dt.Rows[0]["DIAGNOSIS"].ToString() : string.Empty;
                }
            }
        }

        //private void RefreshPatient(string patient_id)
        //{
        //    if (ApplicationConfiguration.SyncOpen)
        //    {
        //        SyncDA syncDA = new SyncDA();
        //        if (!string.IsNullOrEmpty(patient_id))
        //        {
        //            string ret = "";
        //            try
        //            {
        //                ret = syncDA.SyncPatientInfoAndInHospital(patient_id);
        //                Dialog.MessageBox("尝试传入PATIENT_ID同步基本信息返回信息："+ret);
        //                ret = syncDA.SyncScheduleInfo(patient_id);
        //                Dialog.MessageBox("尝试传入PATIENT_ID同步手术预约返回信息：" + ret);
        //                DataTable dt = (new CommonDA()).GetDataWithPrimaryKey("WIS_PAT_MASTER_INDEX", " WHERE PAT_ID = '" + patient_id + "' OR INP_NO='" + patient_id + "'");
        //                Dialog.MessageBox("病人基本信息记录：" + dt.Rows.Count.ToString());
        //                if (dt==null||(dt!=null&&dt.Rows.Count==0))
        //                {
        //                    ret = syncDA.SyncPatientInfoAndInHospitalByInpNo(patient_id);
        //                    Dialog.MessageBox("尝试传入住院号同步基本信息返回信息：" + ret);
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                ExceptionHandler.Handle(ex);
        //            }
        //        }
        //    }
        //    btnSave.Enabled = true;
        //    AnesthesiaSheetDA anesthesiaSheetDA = new AnesthesiaSheetDA();
        //    AnesInformations.OperationMasterDataTable dtOperMaster = anesthesiaSheetDA.GetOperationMaster(patient_id);
        //    DataRow[] rows = dtOperMaster.Select(" scheduled_date_time >= '" + System.DateTime.Today + "' and scheduled_date_time < '" + System.DateTime.Today.AddDays(1) + "'and oper_status < 35 ");
        //    if (rows != null && rows.Length > 0)
        //    {
        //        DialogResult dresult = Dialog.MessageBox("患者 " + patient_id + " 已经在当天的手术列表中,是否继续？", "急症录入提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        //        if (dresult != DialogResult.Yes)
        //        {
        //            btnSave.Enabled = false; ;
        //        }
        //    }
        //    if (patient_id != "")
        //    {
        //        DataTable dt = (new CommonDA()).GetDataWithPrimaryKey("WIS_PAT_MASTER_INDEX", " WHERE PAT_ID = '" + patient_id + "' OR INP_NO='" + patient_id + "'");
        //        Dialog.MessageBox("提取病人基本信息记录：" + dt.Rows.Count.ToString());
        //        dtScheduledTime.EditValue = DateTime.Now.Date.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute);
        //        if (dt != null && dt.Rows.Count >= 1)
        //        {
        //            txtPatientName.Text = dt.Rows[0]["NAME"] != null ? dt.Rows[0]["NAME"].ToString() : string.Empty;
        //            txtPatientSex.Text = dt.Rows[0]["SEX"] != null ? dt.Rows[0]["SEX"].ToString() : string.Empty;
        //            if (dt.Rows[0]["DATE_OF_BIRTH"] != null && dt.Rows[0]["DATE_OF_BIRTH"].ToString().Trim() != "")
        //            {
        //                dtBirthDay.EditValue = (DateTime)dt.Rows[0]["DATE_OF_BIRTH"];
        //            }
        //            else
        //            {
        //                dtBirthDay.EditValue = null;
        //            }
        //        }
        //    }
        //}

        private void EmergencyRegister_Load(object sender, EventArgs e)
        {
            txtPatientID.Focus();
        }

        private void txtPatientID_Leave(object sender, EventArgs e)
        {
            //如果没有改变，直接返回
            //if (!bPatientID_Change) return;
            //bPatientID_Change = false;
            //RefreshPatient(txtPatientID.Text.Trim());
            SyncPatientByPatientId(txtPatientID.Text.Trim());
        }

        private void txtPatientID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)32))
            {
                e.Handled = true;
            }
            /////回车处理
            if (e.KeyChar.Equals((char)13))
            {
                if (txtPatientID.Text.Trim() != string.Empty)
                {
                    //RefreshPatient(txtPatientID.Text.Trim());
                    SyncPatientByPatientId(txtPatientID.Text.Trim());
                }
            }
        }

        private void txtPatientID_TextChanged(object sender, EventArgs e)
        {
            bPatientID_Change = true;
        }

        private void txtPatientID_Validating(object sender, CancelEventArgs e)
        {
            if (txtPatientID.Text.Trim() == string.Empty)
            {
                txtPatientID.ErrorText = "患者ID不能为空";
                //e.Cancel = true;
            }
            else
            {
                txtPatientID.ErrorText = string.Empty;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPatientID.Text.Trim()) || (lblInpNoVisible.Visible && string.IsNullOrEmpty(txtInpNo.Text.Trim())) || string.IsNullOrEmpty(txtOperRoomNo.Text.Trim()))
            {
                Dialog.MessageBox("符号*标记的为必填项，请完成信息");
                return;
            }
            PatientBaseInformations.PatMasterIndexDataTable patMasterIndexDataTable = (new PatientInformationsDA()).GetPatMasterIndexDataTable(txtPatientID.Text.Trim());
            if (patMasterIndexDataTable != null && patMasterIndexDataTable.Count == 0)
            {
                PatientBaseInformations.PatMasterIndexRow patMasterIndexRow = patMasterIndexDataTable.NewPatMasterIndexRow();
                patMasterIndexRow.PAT_ID = txtPatientID.Text.Trim();
                patMasterIndexRow.INP_NO = string.IsNullOrEmpty(txtInpNo.Text.Trim()) ? patMasterIndexRow.PAT_ID : txtInpNo.Text.Trim();
                if (txtPatientName.Text.Trim() != "") patMasterIndexRow.NAME = txtPatientName.Text.Trim();
                if (txtPatientSex.Text.Trim() != "") patMasterIndexRow.SEX = txtPatientSex.Text.Trim();
                if (dtBirthDay.EditValue != null && ((DateTime)dtBirthDay.EditValue) != DateTime.MinValue) patMasterIndexRow.DATE_OF_BIRTH = (DateTime)dtBirthDay.EditValue;
                patMasterIndexDataTable.AddPatMasterIndexRow(patMasterIndexRow);
            }
            AnesInformations.OperationMasterDataTable operationMasterDataTable = (new AnesthesiaSheetDA()).GetOperationMaster(txtPatientID.Text.Trim());
            AnesInformations.AnesthesiaPlanDataTable anesthesiaPlanDataTable = null;
            if (operationMasterDataTable != null)
            {
                AnesInformations.OperationMasterRow masterRow = operationMasterDataTable.NewOperationMasterRow();
                masterRow.PAT_ID = txtPatientID.Text.Trim();
                masterRow.VISIT_ID = 1;
                //DateTime dtInHospitaldate=DateTime.MinValue;
                PatientBaseInformations.PatsInHospitalDataTable patsInHospitalDataTable = (new PatientInformationsDA()).GetPatsInHospital(masterRow.PAT_ID);
                foreach (PatientBaseInformations.PatsInHospitalRow prow in patsInHospitalDataTable.Rows)
                {
                    if (prow.VISIT_ID > masterRow.VISIT_ID)
                    {
                        masterRow.VISIT_ID = prow.VISIT_ID;
                        //dtInHospitaldate = prow.ADMISSION_DATE_TIME;
                    }
                }
                //if (dtInHospitaldate!=DateTime.MinValue&&Dialog.MessageBox("患者 " + masterRow.PATIENT_ID + " 最近一次入院时间为" + dtInHospitaldate.ToString() + ",是否重新住院？", "急症录入提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                //{
                //    masterRow.VISIT_ID += 1;
                //}
                masterRow.OPER_ID = 0;
                foreach (AnesInformations.OperationMasterRow row in operationMasterDataTable.Rows)
                {
                    if (row.VISIT_ID > masterRow.VISIT_ID)
                    {
                        masterRow.VISIT_ID = row.VISIT_ID;
                        masterRow.OPER_ID = row.OPER_ID;
                    }
                    else if (row.VISIT_ID == masterRow.VISIT_ID)
                    {
                        if (row.OPER_ID > masterRow.OPER_ID)
                        {
                            masterRow.OPER_ID = row.OPER_ID;
                        }
                    }
                }
                masterRow.OPER_ID += 1;
                if (txtBedNo.Text.Trim() != "") masterRow.BED_NO = txtBedNo.Text.Trim();
                if (txtDepartStayed.Data != null && txtDepartStayed.Data.ToString().Trim() != "") masterRow.DEPT_STAYED = txtDepartStayed.Data.ToString().Trim();
                if (txtDiagBeforeOperation.Text.Trim() != "") masterRow.DIAG_BEFORE_OPER = txtDiagBeforeOperation.Text.Trim();
                if (txtPatientCondition.Text.Trim() != "") masterRow.PAT_CONDITION = txtPatientCondition.Text.Trim();
                if (dtScheduledTime.EditValue != null && ((DateTime)dtScheduledTime.EditValue) != DateTime.MinValue) masterRow.SCHEDULED_DATE_TIME = (DateTime)dtScheduledTime.EditValue;
                decimal result = 0;
                if (txtSequence.Text.Trim() != "" && decimal.TryParse(txtSequence.Text.Trim(), out result)) masterRow.SEQUENCE = result;
                if (txtOperRoomNo.Text.Trim() != "") masterRow.OPERATING_ROOM_NO = txtOperRoomNo.Text.Trim();
                if (txtIsolationIndicator.Data != null && txtIsolationIndicator.Data.ToString().Trim() != "" && decimal.TryParse(txtIsolationIndicator.Data.ToString().Trim(), out result)) masterRow.ISOLATION_INDICATOR = result;
                if (txtEmergency.Data != null && txtEmergency.Data.ToString().Trim() != "" && decimal.TryParse(txtEmergency.Data.ToString().Trim(), out result)) masterRow.EMERGENCY_INDICATOR = result;
                if (txtOperationScale.Text.Trim() != "") masterRow.OPER_SCALE = txtOperationScale.Text.Trim();
                if (txtAnesMethod.Text.Trim() != "") masterRow.ANES_METHOD = txtAnesMethod.Text.Trim();
                if (txtAnesDoctor1.Data != null && txtAnesDoctor1.Data.ToString().Trim() != "") masterRow.ANES_DOCTOR = txtAnesDoctor1.Data.ToString().Trim();
                if (txtAnesDoctor2.Data != null && txtAnesDoctor2.Data.ToString().Trim() != "") masterRow.SECOND_ANES_DOCTOR = txtAnesDoctor2.Data.ToString().Trim();
                if (txtAnesDoctor3.Data != null && txtAnesDoctor3.Data.ToString().Trim() != "") masterRow.THIRD_ANES_DOCTOR = txtAnesDoctor3.Data.ToString().Trim();
                if (txtAnesAssistant1.Data != null && txtAnesAssistant1.Data.ToString().Trim() != "") masterRow.ANES_ASSISTANT = txtAnesAssistant1.Data.ToString().Trim();
                if (txtAnesAssistant2.Data != null && txtAnesAssistant2.Data.ToString().Trim() != "") masterRow.SECOND_ANES_ASSISTANT = txtAnesAssistant2.Data.ToString().Trim();
                if (txtAnesAssistant4.Data != null && txtAnesAssistant4.Data.ToString().Trim() != "") masterRow.FOURTH_ANES_ASSISTANT = txtAnesAssistant4.Data.ToString().Trim();
                if (txtQieKouClass.Data != null && txtQieKouClass.Data.ToString().Trim() != "") masterRow.INCISION_CLASS = txtQieKouClass.Data.ToString().Trim();
                if (txtQieKouNum.Text.Trim() != "" && decimal.TryParse(txtQieKouNum.Text.Trim(), out result)) masterRow.INCISION_NUMBER = result;
                if (txtSurgeon.Data != null && txtSurgeon.Data.ToString().Trim() != "") masterRow.SURGEON = txtSurgeon.Data.ToString().Trim();
                if (txtSurgeonAssistant1.Data != null && txtSurgeonAssistant1.Data.ToString().Trim() != "") masterRow.FIRST_ASSISTANT = txtSurgeonAssistant1.Data.ToString().Trim();
                if (txtSurgeonAssistant2.Data != null && txtSurgeonAssistant2.Data.ToString().Trim() != "") masterRow.SECOND_ASSISTANT = txtSurgeonAssistant2.Data.ToString().Trim();
                if (txtSurgeonAssistant3.Data != null && txtSurgeonAssistant3.Data.ToString().Trim() != "") masterRow.THIRD_ASSISTANT = txtSurgeonAssistant3.Data.ToString().Trim();
                if (txtSurgeonAssistant4.Data != null && txtSurgeonAssistant4.Data.ToString().Trim() != "") masterRow.FOURTH_ASSISTANT = txtSurgeonAssistant4.Data.ToString().Trim();
                if (txtOperationNurse1.Data != null && txtOperationNurse1.Data.ToString().Trim() != "") masterRow.FIRST_OPER_NURSE = txtOperationNurse1.Data.ToString().Trim();
                if (txtOperationNurse2.Data != null && txtOperationNurse2.Data.ToString().Trim() != "") masterRow.SECOND_OPER_NURSE = txtOperationNurse2.Data.ToString().Trim();
                if (txtSupplyNurse1.Data != null && txtSupplyNurse1.Data.ToString().Trim() != "") masterRow.FIRST_SUPPLY_NURSE = txtSupplyNurse1.Data.ToString().Trim();
                if (txtSupplyNurse2.Data != null && txtSupplyNurse2.Data.ToString().Trim() != "") masterRow.SECOND_SUPPLY_NURSE = txtSupplyNurse2.Data.ToString().Trim();
                if (txtSupplyNurse3.Data != null && txtSupplyNurse3.Data.ToString().Trim() != "") masterRow.THIRD_SUPPLY_NURSE = txtSupplyNurse3.Data.ToString().Trim();
                if (txtOperationName.Text.Trim() != "") masterRow.OPER_NAME = txtOperationName.Text.Trim();
                masterRow.OPER_STATUS = 0;
                if (!string.IsNullOrEmpty(ApplicationConfiguration.OpertionDeptCode)) masterRow.OPERATING_ROOM = ApplicationConfiguration.OpertionDeptCode;
                operationMasterDataTable.AddOperationMasterRow(masterRow);




                //更新 排班表AnesthesiaPlanDataTable
                anesthesiaPlanDataTable = (new AnesthesiaSheetDA()).GetAnesthesiaPlan(masterRow.PAT_ID, masterRow.VISIT_ID, masterRow.OPER_ID);

                if (anesthesiaPlanDataTable != null && anesthesiaPlanDataTable.Rows.Count == 0)
                {
                    AnesInformations.AnesthesiaPlanRow anesthesiaPlanRow = anesthesiaPlanDataTable.NewAnesthesiaPlanRow();
                    anesthesiaPlanRow.PAT_ID = masterRow.PAT_ID;
                    anesthesiaPlanRow.VISIT_ID = masterRow.VISIT_ID;
                    anesthesiaPlanRow.OPER_ID = masterRow.OPER_ID;
                    anesthesiaPlanRow.OPER_NAME = txtOperationName.Text.Trim();
                    anesthesiaPlanDataTable.AddAnesthesiaPlanRow(anesthesiaPlanRow);
                }
            }
            try
            {
                (new PatientInformationsDA()).UpdatePatMasterIndexDataTable(patMasterIndexDataTable);
                (new AnesthesiaSheetDA()).UpdateOperationMaster(operationMasterDataTable);


                //更新 排班表AnesthesiaPlanDataTable
                (new AnesthesiaSheetDA()).UpdateAnesthesiaPlan(anesthesiaPlanDataTable);
                Dialog.MessageBox("保存成功！");
                ResultData = true;
                ParentForm.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }

        private void dtBirthDay_Validating(object sender, CancelEventArgs e)
        {
            DateEdit dt = sender as DateEdit;
            if (dtBirthDay.EditValue != null && dtScheduledTime.EditValue != null && (DateTime)dtBirthDay.EditValue > (DateTime)dtScheduledTime.EditValue)
            {
                dt.ErrorText = "手术日期应晚于出生日期";
                e.Cancel = true;
            }
            else
            {
                dt.ErrorText = string.Empty;
            }
        }

        private void txtOperRoomNo_Validating(object sender, CancelEventArgs e)
        {
            if (txtOperRoomNo.Text.Trim() == string.Empty)
            {
                txtOperRoomNo.ErrorText = "手术间不能为空";
                //e.Cancel = true;
            }
            else
            {
                txtOperRoomNo.ErrorText = string.Empty;
            }
        }

        private void txtInpNo_Validating(object sender, CancelEventArgs e)
        {
            //if (txtInpNo.Text.Trim() == string.Empty)
            //{
            //    txtInpNo.ErrorText = "住院号不能为空";
            //    //e.Cancel = true;
            //}
            //else
            //{
            //    txtInpNo.ErrorText = string.Empty;
            //}
        }

        private void txtInpNo_Leave(object sender, EventArgs e)
        {
            //如果没有改变，直接返回
            //if (!bPatientID_Change) return;
            //bPatientID_Change = false;
            SyncPatientByInpNo(txtInpNo.Text.Trim());
        }

        private void txtInpNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)32))
            {
                e.Handled = true;
            }
            /////回车处理
            if (e.KeyChar.Equals((char)13))
            {
                if (txtInpNo.Text.Trim() != string.Empty)
                {
                    SyncPatientByInpNo(txtInpNo.Text.Trim());
                }
            }
        }
    }
}
