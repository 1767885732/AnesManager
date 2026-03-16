using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Documents;
using Wis.Anes.DataAccess;
using Wis.Anes.Framework;
using Wis.Anes.Framework.Doc;
using Wis.Anes.Framework.Controls;
using Wis.Anes.Framework.Utilities;
using Wis.Anes.BusinessEntity;

namespace Wis.Anes.Custom.CustomProject.Default
{
    /// <summary>
    /// 术后登记
    /// </summary>
    public partial class RegisterAfterOperation : BaseDoc
    {
        MTextBox txtInRoomTime = null;
        MTextBox txtOutRoomTime = null;
        MTextBox txtOperStart = null;
        MTextBox txtOperEnd = null;

        public RegisterAfterOperation()
        {
            InitializeComponent();
            base.PrintButton.Visible = false;
            base.DocKind = DocKind.Default;
        }
        protected override void BuildData(Dictionary<string, DataTable> dataSource)
        {
           
            dataSource["WIS_OPER_MASTER"] = DataContext.GetCurrent().GetData("WIS_OPER_MASTER");
            dataSource["WIS_CUSTOM_DATA"] = DataContext.GetCurrent().GetData("WIS_CUSTOM_DATA");            
            dataSource["WIS_PAT_MASTER_INDEX"] = DataContext.GetCurrent().GetData("WIS_PAT_MASTER_INDEX");
            
        }
        protected override void OnSaveData(Dictionary<string, DataTable> dataSource)
        {
            base.OnSaveData(dataSource);
            AnesInformations.OperationMasterDataTable operationMasterDataTable = dataSource["WIS_OPER_MASTER"] as AnesInformations.OperationMasterDataTable;

            if (txtOutRoomTime.Text != "")
            {
                if (operationMasterDataTable[0].IsOPER_STATUSNull()||operationMasterDataTable[0].OPER_STATUS < (decimal)OperationStatus.OutOperationRoom)
                {
                    operationMasterDataTable[0].ANES_START_TIME = operationMasterDataTable[0].START_DATE_TIME;
                    operationMasterDataTable[0].ANES_END_TIME = operationMasterDataTable[0].END_DATE_TIME;
                    operationMasterDataTable[0].OPER_STATUS = (decimal)OperationStatus.OutOperationRoom;
                    ExtendApplicationContext.Current.PatientInformation.OperStatus = operationMasterDataTable[0].OPER_STATUS;
                    ExtendApplicationContext.Current.OperationStatus = OperationStatus.OutOperationRoom;
                }
            }
            ExtendApplicationContext.Current.PatientInformation.OperRoom = operationMasterDataTable[0].OPERATING_ROOM_NO;
            dataSource["WIS_OPER_MASTER"] = operationMasterDataTable;
            CommonDA commonDA = new CommonDA();
            commonDA.Update(dataSource["WIS_OPER_MASTER"], "WIS_OPER_MASTER");
            commonDA.Update(dataSource["WIS_PAT_MASTER_INDEX"], "WIS_PAT_MASTER_INDEX");
            commonDA.Update(dataSource["WIS_CUSTOM_DATA"], "WIS_CUSTOM_DATA");
        }

        public override bool OnCustomCheckBeforeSave()
        {
            bool bl = base.OnCustomCheckBeforeSave();
            foreach (IUIElementHandler handler in _UIElementHandlers)
            {
                if (handler.GetControlType == typeof(MTextBox) && handler.GetAllControls != null)
                {
                    foreach (Control ctl in handler.GetAllControls)
                    {
                        if (ctl is MTextBox)
                        {
                            MTextBox textbox = ctl as MTextBox;
                            if (!string.IsNullOrEmpty(textbox.InputNeededMessage)&&string.IsNullOrEmpty(textbox.Text.Trim()))
                            {
                                Dialog.MessageBox(textbox.InputNeededMessage);
                                return false;
                            }
                        }
                    }
                    foreach (Control ctl in handler.GetAllControls)
                    {
                        if (ctl is MTextBox)
                        {
                            if (ctl.Name == "txtInRoomTime")
                            {
                                txtInRoomTime = ctl as MTextBox;
                            }
                            else if (ctl.Name == "txtOutRoomTime")
                            {
                                txtOutRoomTime = ctl as MTextBox;
                            }
                            else if (ctl.Name == "txtOperStart")
                            {
                                txtOperStart = ctl as MTextBox;
                            }
                            else if (ctl.Name == "txtOperEnd")
                            {
                                txtOperEnd = ctl as MTextBox;
                            }
                        }
                    }
                    bl = checkTime();
                }
            }
            return bl;
        }

        private bool checkTime()
        {
            if (txtInRoomTime != null && txtOperStart != null && txtOperEnd != null && txtOutRoomTime != null)
            {
                if (txtInRoomTime.Text != "" && txtOperStart.Text!=""&&DateTime.Parse(txtOperStart.Text) < DateTime.Parse(txtInRoomTime.Text))
                {
                    Dialog.MessageBox("手术开始时间不可早于入室时间");
                    return false;
                }
                else if (txtOperEnd.Text != "" && txtOperStart.Text != "" && DateTime.Parse(txtOperEnd.Text) < DateTime.Parse(txtOperStart.Text))
                {
                    Dialog.MessageBox("手术结束时间不可早于手术开始时间");
                    return false;
                }
                else if (txtOutRoomTime.Text != "" && txtOperEnd.Text != "" && DateTime.Parse(txtOutRoomTime.Text) < DateTime.Parse(txtOperEnd.Text))
                {
                    Dialog.MessageBox("出室时间不可早于手术结束时间");
                    return false;
                }
            }
            return true;
        }
    }
}
