using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Views;
using Wis.Anes.ServiceProxies;
using Wis.Anes.Framework;
using Wis.Anes.Constants;
using Wis.Anes.Framework.Controls;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework.Utilities;

namespace Wis.Anes.Views
{
    public partial class PatientEMRInfo : BaseView
    {
        protected string   _patientId;
        protected decimal _visitId;

        public PatientEMRInfo(string patientID, decimal visitId)
        {
            _patientId = patientID;
            _visitId = visitId;
            InitializeComponent();
        }

        private void PatientEMRInfo_Load(object sender, EventArgs e)
        {
            try
            {
                PatientBaseInformations.PatMasterIndexDataTable patMasterIndexDataTable = PatientInformationsProxy.GetPatMasterIndexDataTable(_patientId);
                PatientBaseInformations.PatMasterIndexRow patMasterIndexRow = null;

                PatientBaseInformations.PatsInHospitalDataTable patInHospital = PatientInformationsProxy.GetPatsInHospital(_patientId, _visitId);
                PatientBaseInformations.PatsInHospitalRow patInHospitalRow = null;

                if (patMasterIndexDataTable != null && patMasterIndexDataTable.Rows.Count >= 1)
                {
                    patMasterIndexRow = (PatientBaseInformations.PatMasterIndexRow)patMasterIndexDataTable.Rows[0];
                }

                if (patInHospital != null && patInHospital.Rows.Count >= 1)
                {
                    patInHospitalRow = patInHospital[0];
                }

                //如果主表信息为空，退出
                if (patMasterIndexRow == null )
                    return;

                lbc_PatientID.Text = patMasterIndexRow.PAT_ID;
                lbc_PatientName.Text = patMasterIndexRow.NAME;

                if(patInHospitalRow != null)
                    lbc_BedNo.Text = patInHospitalRow.BED_NO;

                if (!patMasterIndexRow.IsID_NONull())
                    labelIDCode.Text = patMasterIndexRow.ID_NO;

                if (!patMasterIndexRow.IsSEXNull())
                    lbc_Sex.Text = patMasterIndexRow.SEX;

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
                    int yeardis = dtNow.Year - patMasterIndexRow.DATE_OF_BIRTH.Year;
                    int mondis = dtNow.Month - patMasterIndexRow.DATE_OF_BIRTH.Month;
                    int daydis = dtNow.Day - patMasterIndexRow.DATE_OF_BIRTH.Day;
                    if (yeardis > 1)
                        labelAge.Text = yeardis.ToString() + "岁";
                    else if (yeardis * 12 - mondis > 12)
                        labelAge.Text = "1岁";
                    else if (yeardis * 12 - mondis < 1)
                        labelAge.Text = (dtNow - patMasterIndexRow.DATE_OF_BIRTH).TotalDays.ToString() + "天";
                    else
                        labelAge.Text = (yeardis * 12 - mondis).ToString() + "月";

                }
                if (patInHospitalRow != null && !patInHospitalRow.IsDEPT_CODENull())
                {
                    Dict.DeptDictDataTable deptDict = ExtendApplicationContext.Current.CodeTables["WIS_DICT_DEPT"] as Dict.DeptDictDataTable;
                    Dict.DeptDictRow deptDictRow = deptDict.FindByDEPT_CODE(patInHospitalRow.DEPT_CODE);
                    if (deptDictRow != null)
                    {
                        lbc_WardCode.Text = deptDictRow.DEPT_NAME;
                    }
                    else
                    {
                        lbc_WardCode.Text = patInHospitalRow.DEPT_CODE;
                    }
                }


                AssayReport report = new AssayReport(_patientId, _visitId, 0);
                report.Dock = DockStyle.Fill;
                xtraTabPageTestInfo.Controls.Add(report);


                string ret = SyncProxy.SyncPACS(_patientId, _visitId, null);
                if (ret != "")
                {
                    //ExceptionHandler.Handle(new Exception(ret));
                }

                CheckInfoPanel info = new CheckInfoPanel(_patientId, _visitId, 0);
                info.Dock = DockStyle.Fill;
                xtraTabPageCheckResult.Controls.Add(info);


                OrderInfoPanel order = new OrderInfoPanel(_patientId, _visitId);
                order.Dock = DockStyle.Fill;
                xtraTabPageDoctorOrder.Controls.Add(order);

            }
            catch (Exception err)
            {
                ExceptionHandler.Handle(err);
            }
        }

        private void btnHisDocument_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(_patientId))
                {
                    //SyncProxy.SyncEMR(ExtendApplicationContext.Current.PatientInformation.PatientID, ExtendApplicationContext.Current.PatientInformation.VisitID, null);
                    //用户工号；用户姓名；；科室代码；科室名称；0；0；2
                    string deptName = "";
                    if (ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_DICT_DEPT"))
                    {
                        Dict.DeptDictDataTable deptDict = ExtendApplicationContext.Current.CodeTables["WIS_DICT_DEPT"] as Dict.DeptDictDataTable;
                        Dict.DeptDictRow row = deptDict.FindByDEPT_CODE(ExtendApplicationContext.Current.LoginUserContext.DeptID);
                        if (row != null)
                        {
                            deptName = row.DEPT_NAME;
                        }
                    }

                    string operatorInfo = ExtendApplicationContext.Current.LoginUserContext.LoginName + ";" + ExtendApplicationContext.Current.LoginUserContext.UserName + ";;";
                    operatorInfo += ExtendApplicationContext.Current.LoginUserContext.DeptID + ";" + deptName + ";0;0;4";
                    string performedcode = ";";



                    AnesInformations.OperationMasterDataTable operationMasterDataTable = AnesthesiaSheetProxy.GetOperationMaster(_patientId, _visitId, 0);
                    AnesInformations.OperationMasterRow operationMasterRow = null;
                    if (operationMasterDataTable != null && operationMasterDataTable.Count >= 1)
                    {
                        operationMasterRow = operationMasterDataTable[0];
                    }
                    if (operationMasterRow != null)
                    {
                        performedcode = operationMasterRow.DEPT_STAYED;
                        if (ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_DICT_DEPT"))
                        {
                            Dict.DeptDictDataTable deptDict = ExtendApplicationContext.Current.CodeTables["WIS_DICT_DEPT"] as Dict.DeptDictDataTable;
                            Dict.DeptDictRow row = deptDict.FindByDEPT_CODE(performedcode);
                            if (row != null)
                            {
                                performedcode = performedcode + ";" + row.DEPT_NAME;
                            }
                        }
                    }


                    //string reuslt = SyncProxy.SyncEMR2(_patientId,_visitId, operatorInfo, this.Handle.ToString(), performedcode);

                    //if (!string.IsNullOrEmpty(reuslt))
                    //    Dialog.MessageBox(reuslt);
                }


                //string exePath = ExtendApplicationContext.Current.AppPath + "\\MedDoc\\电子病历查看.exe";
                //string exePara = ExtendApplicationContext.Current.PatientInformation.PatientID + " " + ExtendApplicationContext.Current.PatientInformation.VisitID;

                //Process.Start(exePath, exePara);


            }
            catch (Exception err)
            {
                ExceptionHandler.Handle(err);
            }
        }
    }
}
