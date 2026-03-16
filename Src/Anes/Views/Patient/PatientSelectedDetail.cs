using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework;
using Wis.Anes.ServiceProxies;
using Wis.Anes.BusinessEntity;

namespace Wis.Anes.Views.Patient
{
    [ToolboxItem(false)]
    public partial class PatientSelectedDetail : UserControl
    {
        public PatientSelectedDetail()
        {
            InitializeComponent();
            try
            {
                _doctorTable = ExtendApplicationContext.Current.CodeTables["WIS_PERM_HIS_USER"] as Dict.HisUserDataTable;
                _nurseTable = ExtendApplicationContext.Current.CodeTables["WIS_PERM_HIS_USER"] as Dict.HisUserDataTable;
                _anesMethod = ExtendApplicationContext.Current.CodeTables["WIS_DICT_ANES"] as Dict.AnessthestaDictDataTable;
                _diagnosisDictTable = ExtendApplicationContext.Current.CodeTables["WIS_DICT_DIAGNOSIS"] as Dict.WisDiagnosisDictDataTable;
                _optionDictTable = ExtendApplicationContext.Current.CodeTables["WIS_DICT_OPERATION"] as Dict.OperationDictDataTable;
                _commonDictTable = ExtendApplicationContext.Current.CodeTables["WIS_DICT_ANES_INPUT"] as Dict.AnesthesiaInputDictDataTable;
                _deptDict = ExtendApplicationContext.Current.CodeTables["WIS_DICT_DEPT"] as Dict.DeptDictDataTable;
                _OperatingRoom = ExtendApplicationContext.Current.CodeTables["WIS_OPER_ROOM"] as Dict.OperatingRoomDataTable;
            }
            catch (Exception ex)
            {
                //ExceptionHandler.Handle(ex);
            }
            ClearAllInfo();
        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// 字典清单
        /// </summary>
        private Dict.AnessthestaDictDataTable _anesMethod;
        private Dict.HisUserDataTable _doctorTable;
        private Dict.HisUserDataTable _nurseTable;
        private Dict.WisDiagnosisDictDataTable _diagnosisDictTable;
        private Dict.OperationDictDataTable _optionDictTable;
        private Dict.AnesthesiaInputDictDataTable _commonDictTable;
        private Dict.DeptDictDataTable _deptDict;
        private Dict.OperatingRoomDataTable _OperatingRoom;

        public void SetPatientDict()
        {


        }
        /// <summary>
        /// 刷新选定的患者
        /// </summary>
        public void RefreshSelectedPatient(PatientInformation patientInformation)
        {
            ClearAllInfo();
            PatientBaseInformations.PatsInHospitalDataTable inhospitalDataTable = PatientInformationsProxy.GetPatsInHospital(patientInformation.PatientID, patientInformation.VisitID);
            AnesInformations.OperationMasterDataTable operationMasterDataTable = AnesthesiaSheetProxy.GetOperationMaster(patientInformation.PatientID, patientInformation.VisitID, patientInformation.OperID);
            PatientBaseInformations.PatMasterIndexDataTable patMasterIndexDataTable = PatientInformationsProxy.GetPatMasterIndexDataTable(patientInformation.PatientID);
            AnesInformations.OperationMasterRow operationMasterRow = null;
            PatientBaseInformations.PatMasterIndexRow patMasterIndexRow = null;
            PatientBaseInformations.PatsInHospitalRow inhospitalRow = null;

            if (operationMasterDataTable.Rows.Count >= 1)
            {
                operationMasterRow = (AnesInformations.OperationMasterRow)operationMasterDataTable.Rows[0];
            }
            if (patMasterIndexDataTable.Rows.Count >= 1)
            {
                patMasterIndexRow = (PatientBaseInformations.PatMasterIndexRow)patMasterIndexDataTable.Rows[0];
            }

            if (inhospitalDataTable != null && inhospitalDataTable.Rows.Count > 0)
            {
                inhospitalRow = inhospitalDataTable[0];
            }


            //如果主表信息为空，退出
            if (patMasterIndexRow == null || operationMasterRow == null)
            {
                return;
            }

            if (inhospitalRow != null)
            {
                if (!inhospitalRow.IsPREPAYMENTSNull())
                    labelControlFeeDone.Text = inhospitalRow.PREPAYMENTS.ToString();

                if (!inhospitalRow.IsTOTAL_COSTSNull())
                    labelControlFeeNeed.Text = inhospitalRow.TOTAL_COSTS.ToString();
            }

            lbc_PatientID.Text = patientInformation.PatientID;
            lbc_PatientName.Text = patientInformation.Name;
            lbc_BedNo.Text = patientInformation.BedNo;

            if (!patMasterIndexRow.IsIDENTITYNull())
                labelControlJob.Text = patMasterIndexRow.IDENTITY;



            if (!patMasterIndexRow.IsID_NONull())
                labelIDCode.Text = patMasterIndexRow.ID_NO;

            if (!patMasterIndexRow.IsSEXNull())
            {
                lbc_Sex.Text = patMasterIndexRow.SEX;
            }

            if (!patMasterIndexRow.IsINP_NONull())
                labelInpNo.Text = patMasterIndexRow.INP_NO;


            if (!patMasterIndexRow.IsCHARGE_TYPENull())
                labelControlChargeType.Text = patMasterIndexRow.CHARGE_TYPE;


            if (!patMasterIndexRow.IsMAILING_ADDRESSNull())
                labelControlAddress.Text = patMasterIndexRow.MAILING_ADDRESS;


            if (!patMasterIndexRow.IsNEXT_OF_KINNull())
                labelControlContact.Text = patMasterIndexRow.NEXT_OF_KIN;

            if (!patMasterIndexRow.IsNEXT_OF_KIN_PHONENull())
                labelControlPhone.Text = patMasterIndexRow.NEXT_OF_KIN_PHONE;

            if (!patMasterIndexRow.IsDATE_OF_BIRTHNull())
            {
                //lbc_BirthDate.Text = patMasterIndexRow.DATE_OF_BIRTH.ToString("yyyy-MM-dd");

                DateTime dtNow = DateTime.Now;
                //int yeardis = dtNow.Year - patMasterIndexRow.DATE_OF_BIRTH.Year;
                //int mondis = dtNow.Month - patMasterIndexRow.DATE_OF_BIRTH.Month;
                //int daydis = dtNow.Day - patMasterIndexRow.DATE_OF_BIRTH.Day;
                //if (yeardis > 1)
                //    labelAge.Text = yeardis.ToString() + "岁";
                //else if (yeardis * 12 - mondis > 12)
                //    labelAge.Text = "1岁";
                //else if (yeardis * 12 - mondis < 1)
                //    labelAge.Text = (dtNow - patMasterIndexRow.DATE_OF_BIRTH).TotalDays.ToString() + "天";
                //else
                //    labelAge.Text = (yeardis * 12 - mondis).ToString() + "月";

                labelAge.Text = Wis.Anes.Framework.Utilities.DateDiff.CalAge(patMasterIndexRow.DATE_OF_BIRTH, dtNow);

            }
            if (!operationMasterRow.IsDEPT_STAYEDNull())
            {

                Dict.DeptDictRow deptDictRow = _deptDict.FindByDEPT_CODE(operationMasterRow.DEPT_STAYED);
                if (deptDictRow != null)
                {
                    lbc_WardCode.Text = deptDictRow.DEPT_NAME;
                }
                else
                {
                    lbc_WardCode.Text = operationMasterRow.DEPT_STAYED;
                }
            }

            //判断术前术后，读取诊断信息
            bool isBeforeOperation = true;
            if (!operationMasterRow.IsOPER_STATUSNull())
            {
                decimal operStatus = operationMasterRow.OPER_STATUS;
                if (operStatus > (int)OperationStatus.InOperationRoom)
                {
                    isBeforeOperation = false;
                }
            }
            if (isBeforeOperation)
            {
                if (!operationMasterRow.IsDIAG_BEFORE_OPERNull())
                {

                    Dict.WisDiagnosisDictRow diagnosisDictRow = _diagnosisDictTable.FindByDIAGNOSIS_CODE(operationMasterRow.DIAG_BEFORE_OPER);
                    if (diagnosisDictRow != null)
                    {
                        lbc_ZhenDuan.Text = diagnosisDictRow.DIAGNOSIS_NAME;
                    }
                    else
                    {
                        lbc_ZhenDuan.Text = operationMasterRow.DIAG_BEFORE_OPER;
                    }
                }
            }
            else
            {
                if (!operationMasterRow.IsDIAG_AFTER_OPERNull())
                {

                    Dict.WisDiagnosisDictRow diagnosisDictRow = _diagnosisDictTable.FindByDIAGNOSIS_CODE(operationMasterRow.DIAG_AFTER_OPER);
                    if (diagnosisDictRow != null)
                    {
                        lbc_ZhenDuan.Text = diagnosisDictRow.DIAGNOSIS_NAME;
                    }
                    else
                    {
                        lbc_ZhenDuan.Text = operationMasterRow.DIAG_AFTER_OPER;
                    }
                }
            }

            //病情
            if (!operationMasterRow.IsPAT_CONDITIONNull())
            {
                lbc_BingQing.Text = operationMasterRow.PAT_CONDITION;
            }
            //手术名称
            if (!operationMasterRow.IsOPER_NAMENull())
            {

                Dict.OperationDictRow operationDictRow = _optionDictTable.FindByOPER_NAME(operationMasterRow.OPER_NAME);
                if (operationDictRow != null)
                {
                    lbc_OperationName.Text = operationDictRow.OPER_NAME;
                }
                else
                {
                    lbc_OperationName.Text = operationMasterRow.OPER_NAME;
                }
            }

            //急诊择期
            if (!operationMasterRow.IsEMERGENCY_INDICATORNull())
            {

                lbc_JiZhenZeQi.Text = "择期";
                if (!operationMasterRow.IsEMERGENCY_INDICATORNull() && operationMasterRow.EMERGENCY_INDICATOR == 1)
                    lbc_JiZhenZeQi.Text = "急诊";

                //lbc_JiZhenZeQi.Text = DictProxy.GetInputDictByItemClassAndCode("急诊择期", operationMasterRow.EMERGENCY_INDICATOR.ToString());


            }
            //手术日期
            if (!operationMasterRow.IsSCHEDULED_DATE_TIMENull())
            {
                lbc_OperationTime.Text = operationMasterRow.SCHEDULED_DATE_TIME.ToString("yyyy-MM-dd hh:mm");
            }
            //台次
            if (!operationMasterRow.IsSEQUENCENull())
            {
                lbc_TaiCi.Text = operationMasterRow.SEQUENCE.ToString();
            }
            //手术间
            if (!operationMasterRow.IsOPERATING_ROOM_NONull())
            {
                lbc_OperationRoom.Text = operationMasterRow.OPERATING_ROOM_NO;
            }
            //隔离
            if (!operationMasterRow.IsISOLATION_INDICATORNull())
            {
                if (operationMasterRow.ISOLATION_INDICATOR == 2)
                    lbc_Geli.Text = "隔离";
                else if (operationMasterRow.ISOLATION_INDICATOR == 3)
                    lbc_Geli.Text = "放射";

                //lbc_Geli.Text = DictProxy.GetInputDictByItemClassAndCode("隔离方式", operationMasterRow.ISOLATION_INDICATOR.ToString());
            }
            //手术等级
            if (!operationMasterRow.IsOPER_SCALENull())
            {
                lbc_ShoushuDengJi.Text = DictProxy.GetInputDictByItemClassAndCode("手术等级", operationMasterRow.OPER_SCALE);
            }


            //麻醉方法
            if (!operationMasterRow.IsANES_METHODNull())
            {
                bool isFind = false;
                foreach (Dict.AnessthestaDictRow row in _anesMethod)
                {
                    if (!row.IsANES_CODENull() && row.ANES_CODE.Equals(operationMasterRow.ANES_METHOD))
                    {
                        lbc_AnesMethod.Text = row.ANES_NAME;
                        isFind = true;
                        break;
                    }
                }

                if (!isFind)
                {
                    lbc_AnesMethod.Text = operationMasterRow.ANES_METHOD;
                }

            }

            //切口等级
            if (!operationMasterRow.IsINCISION_CLASSNull())
            {                
                lbc_QieKouDengJi.Text = DictProxy.GetInputDictByItemClassAndCode("切口等级", operationMasterRow.INCISION_CLASS);//operationMasterRow.INCISION_CLASS);//接口临时把接口等级值放到reserved6字段了。
            }
            //切口个数
            if (!operationMasterRow.IsINCISION_NUMBERNull())
            {
                lbc_QieKouGeShu.Text = operationMasterRow.INCISION_NUMBER.ToString();
            }

            if (!operationMasterRow.IsANES_DOCTORNull())
                lbc_AnesDoctor01.Text = GetHisUserName(operationMasterRow.ANES_DOCTOR, this._doctorTable);

            if (!operationMasterRow.IsSECOND_ANES_DOCTORNull())
                //lbc_AnesDoctor02.Text = GetHisUserName(operationMasterRow.SECOND_ANES_DOCTOR, this._doctorTable);

                if (!operationMasterRow.IsTHIRD_ANES_DOCTORNull())
                    //lbc_AnesDoctor03.Text = GetHisUserName(operationMasterRow.THIRD_ANES_DOCTOR, this._doctorTable);

                    if (!operationMasterRow.IsANES_ASSISTANTNull())
                        lbc_AnesAssistant01.Text = GetHisUserName(operationMasterRow.ANES_ASSISTANT, this._doctorTable);

            if (!operationMasterRow.IsSECOND_ANES_ASSISTANTNull())
                lbc_AnesAssistant02.Text = GetHisUserName(operationMasterRow.SECOND_ANES_ASSISTANT, this._doctorTable);

            if (!operationMasterRow.IsSURGEONNull())
                lbc_OperDoctor.Text = GetHisUserName(operationMasterRow.SURGEON, this._doctorTable);

            if (!operationMasterRow.IsFIRST_ASSISTANTNull())
                lbc_OperAssistant01.Text = GetHisUserName(operationMasterRow.FIRST_ASSISTANT, this._doctorTable);

            if (!operationMasterRow.IsSECOND_ASSISTANTNull())
                lbc_OperAssistant02.Text = GetHisUserName(operationMasterRow.SECOND_ASSISTANT, this._doctorTable);

            if (!operationMasterRow.IsTHIRD_ASSISTANTNull())
                lbc_OperAssistant03.Text = GetHisUserName(operationMasterRow.THIRD_ASSISTANT, this._doctorTable);

            if (!operationMasterRow.IsFOURTH_ASSISTANTNull())
                lbc_OperAssistant04.Text = GetHisUserName(operationMasterRow.FOURTH_ASSISTANT, this._doctorTable);

            if (!operationMasterRow.IsFOURTH_ANES_ASSISTANTNull())
                lbc_AnesGuanZhu.Text = GetHisUserName(operationMasterRow.FOURTH_ANES_ASSISTANT, this._doctorTable);

            if (!operationMasterRow.IsFIRST_OPER_NURSENull())
                lbc_OperNurse01.Text = GetHisUserName(operationMasterRow.FIRST_OPER_NURSE, this._nurseTable);

            if (!operationMasterRow.IsSECOND_OPER_NURSENull())
                lbc_OperNurse02.Text = GetHisUserName(operationMasterRow.SECOND_OPER_NURSE, this._nurseTable);

            if (!operationMasterRow.IsFIRST_SUPPLY_NURSENull())
                lbc_SupplyNurse01.Text = GetHisUserName(operationMasterRow.FIRST_SUPPLY_NURSE, this._nurseTable);

            if (!operationMasterRow.IsSECOND_SUPPLY_NURSENull())
                lbc_SupplyNurse02.Text = GetHisUserName(operationMasterRow.SECOND_SUPPLY_NURSE, this._nurseTable);

            if (!operationMasterRow.IsTHIRD_SUPPLY_NURSENull())
                lbc_SupplyNurse03.Text = GetHisUserName(operationMasterRow.THIRD_SUPPLY_NURSE, this._nurseTable);
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
        private void ClearAllInfo()
        {
           

            //基本信息
            lbc_PatientID.Text = "";
            labelInpNo.Text = string.Empty;
            lbc_PatientName.Text = "";
            labelAge.Text = "";
            lbc_Sex.Text = "";

            lbc_BedNo.Text = "";
            lbc_WardCode.Text = "";
            //lbc_BirthDate.Text = "";            
            labelControlChargeType.Text = "";

            labelControlAddress.Text = string.Empty;
            labelIDCode.Text = "";
            labelControlPhone.Text = string.Empty;
            labelControlContact.Text = string.Empty;

            labelControlJob.Text = string.Empty;
            labelControlFeeDone.Text = string.Empty;
            labelControlFeeNeed.Text = string.Empty;

            //手术信息
            lbc_ZhenDuan.Text = "";
            lbc_BingQing.Text = "";
            lbc_OperationName.Text = "";
            lbc_JiZhenZeQi.Text = "";
            lbc_OperationTime.Text = "";
            lbc_TaiCi.Text = "";
            lbc_OperationRoom.Text = "";
            lbc_Geli.Text = "";
            lbc_ShoushuDengJi.Text = "";
            lbc_AnesMethod.Text = "";
            lbc_QieKouDengJi.Text = "";
            lbc_QieKouGeShu.Text = "";

            //手术人员
            lbc_AnesDoctor01.Text = "";
            //lbc_AnesDoctor02.Text = "";
            //lbc_AnesDoctor03.Text = "";
            lbc_AnesAssistant01.Text = "";
            lbc_AnesAssistant02.Text = "";
            lbc_AnesGuanZhu.Text = "";
            lbc_OperDoctor.Text = "";
            lbc_OperAssistant01.Text = "";
            lbc_OperAssistant02.Text = "";
            lbc_OperAssistant03.Text = "";
            lbc_OperAssistant04.Text = "";
            lbc_OperNurse01.Text = "";
            lbc_OperNurse02.Text = "";
            lbc_SupplyNurse01.Text = "";
            lbc_SupplyNurse02.Text = "";
            lbc_SupplyNurse03.Text = "";

        }       
    }
}
