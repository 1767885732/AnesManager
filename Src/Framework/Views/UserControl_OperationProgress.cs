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
using DevExpress.XtraTreeList.Nodes;

namespace Wis.Anes.Framework
{
    public partial class UserControl_OperationProgress  : BaseView
    {
        private string _patientID;
        private decimal _visitID, _operID;

        public UserControl_OperationProgress() : this("", 0, 0) { }
        public UserControl_OperationProgress(string patientID, decimal visitID, decimal operID)
        {
            Caption = "手术进程";
            _patientID = patientID;
            _visitID = visitID;
            _operID = operID;
            InitializeComponent();
            dateEdit1.EditValue = null;
            if (!DesignMode)
            {
                Load += new EventHandler(UserControl_OperationProgress_Load);
            }
        }

        private void UserControl_OperationProgress_Load(object sender, EventArgs e)
        {
            foreach (Control control in panelControl1.Controls)
            {
                control.BackColor = panelControl1.BackColor;
            }
            InitTreeList();
            LoadPatientData();
        }

        private void LoadPatientData()
        {
            if (!string.IsNullOrEmpty(_patientID))
            {

                PatientBaseInformations.PatMasterIndexDataTable patMasterIndexDataTable = (new PatientInformationsDA()).GetPatMasterIndexDataTable(_patientID);
                if (patMasterIndexDataTable != null && patMasterIndexDataTable.Rows.Count == 1)
                {
                    if (!patMasterIndexDataTable[0].IsNAMENull())
                    {
                        txtPatientName.Text = patMasterIndexDataTable[0].NAME;
                    }
                    if (!patMasterIndexDataTable[0].IsSEXNull())
                    {
                        txtPatientSex.Text = patMasterIndexDataTable[0].SEX;
                    }
                    if (!patMasterIndexDataTable[0].IsDATE_OF_BIRTHNull())
                    {
                        dtBirthDay.EditValue = patMasterIndexDataTable[0].DATE_OF_BIRTH;
                    }
                }

                AnesInformations.AnesthesiaPlanDataTable anesthesiaPlanDataTable = (new AnesthesiaSheetDA()).GetAnesthesiaPlan(_patientID, _visitID, _operID);
                if (anesthesiaPlanDataTable != null && anesthesiaPlanDataTable.Rows.Count == 1)
                {
                    if (!anesthesiaPlanDataTable[0].IsOPER_NAMENull())
                    {
                        txtOperationName.Text = anesthesiaPlanDataTable[0].OPER_NAME;
                    }
                }

                //PatientBaseInformations.PatsInHospitalDataTable patsInHospitalDataTable = (new PatientInformationsDA()).GetPatsInHospital(_patientID);
                //{
                //}

                AnesInformations.OperationMasterDataTable operationMasterDataTable = (new AnesthesiaSheetDA()).GetOperationMaster(_patientID, _visitID, _operID);
                if (operationMasterDataTable != null && operationMasterDataTable.Count == 1)
                {
                    txtPatientID.Text = operationMasterDataTable[0].PAT_ID;
                    if (!operationMasterDataTable[0].IsBED_NONull())
                    {
                        txtBedNo.Text = operationMasterDataTable[0].BED_NO;
                    }
                    if (!operationMasterDataTable[0].IsDEPT_STAYEDNull())
                    {
                        txtDepartStayed.Text = operationMasterDataTable[0].DEPT_STAYED;
                    }
                    if (!operationMasterDataTable[0].IsDIAG_BEFORE_OPERNull())
                    {
                        txtDiagBeforeOperation.Text = operationMasterDataTable[0].DIAG_BEFORE_OPER;
                    }
                    if (!operationMasterDataTable[0].IsPAT_CONDITIONNull())
                    {
                        txtPatientCondition.Text = operationMasterDataTable[0].PAT_CONDITION;
                    }
                    if (!operationMasterDataTable[0].IsSCHEDULED_DATE_TIMENull())
                    {
                        dtScheduledTime.EditValue = operationMasterDataTable[0].SCHEDULED_DATE_TIME;
                    }
                    if (!operationMasterDataTable[0].IsSEQUENCENull())
                    {
                        txtSequence.Text = operationMasterDataTable[0].SEQUENCE.ToString();
                    }
                    if (!operationMasterDataTable[0].IsOPERATING_ROOM_NONull())
                    {
                        txtOperRoomNo.Text = operationMasterDataTable[0].OPERATING_ROOM_NO;
                    }
                    if (!operationMasterDataTable[0].IsISOLATION_INDICATORNull())
                    {
                        txtIsolationIndicator.Text = operationMasterDataTable[0].ISOLATION_INDICATOR.ToString();
                    }
                    //if (txtEmergency.Data != null && txtEmergency.Data.ToString().Trim() != "" && decimal.TryParse(txtEmergency.Data.ToString().Trim(), out result)) masterRow.ISOLATION_INDICATOR = result;
                    if (!operationMasterDataTable[0].IsOPER_SCALENull())
                    {
                        txtOperationScale.Text = operationMasterDataTable[0].OPER_SCALE;
                    }
                    if (!operationMasterDataTable[0].IsANES_METHODNull())
                    {
                        txtAnesMethod.Text = operationMasterDataTable[0].ANES_METHOD;
                    }
                    if (!operationMasterDataTable[0].IsANES_DOCTORNull())
                    {
                        txtAnesDoctor1.SetData(operationMasterDataTable[0].ANES_DOCTOR);
                    }
                    if (!operationMasterDataTable[0].IsSECOND_ANES_DOCTORNull())
                    {
                        txtAnesDoctor2.SetData(operationMasterDataTable[0].SECOND_ANES_DOCTOR);
                    }
                    if (!operationMasterDataTable[0].IsTHIRD_ANES_DOCTORNull())
                    {
                        txtAnesDoctor3.SetData(operationMasterDataTable[0].THIRD_ANES_DOCTOR);
                    }
                    if (!operationMasterDataTable[0].IsSURGEONNull())
                    {
                        txtSurgeon.SetData(operationMasterDataTable[0].SURGEON);
                    }
                    if (!operationMasterDataTable[0].IsFIRST_OPER_NURSENull())
                    {
                        txtOperationNurse1.SetData(operationMasterDataTable[0].FIRST_OPER_NURSE);
                    }
                    if (!operationMasterDataTable[0].IsFIRST_SUPPLY_NURSENull())
                    {
                        txtSupplyNurse1.SetData(operationMasterDataTable[0].FIRST_SUPPLY_NURSE);
                    }
                    //if (txtAnesAssistant1.Data != null && txtAnesAssistant1.Data.ToString().Trim() != "") masterRow.ANES_ASSISTANT = txtAnesAssistant1.Data.ToString().Trim();
                    //if (txtAnesAssistant2.Data != null && txtAnesAssistant2.Data.ToString().Trim() != "") masterRow.SECOND_ANES_ASSISTANT = txtAnesAssistant2.Data.ToString().Trim();
                    //if (txtAnesAssistant4.Data != null && txtAnesAssistant4.Data.ToString().Trim() != "") masterRow.FOURTH_ANES_ASSISTANT = txtAnesAssistant4.Data.ToString().Trim();
                    //if (txtQieKouClass.Data != null && txtQieKouClass.Data.ToString().Trim() != "") masterRow.INCISION_CLASS = txtQieKouClass.Data.ToString().Trim();
                    //if (txtQieKouNum.Text.Trim() != "" && decimal.TryParse(txtQieKouNum.Text.Trim(), out result)) masterRow.INCISION_NUMBER = result;
                    //if (txtSurgeonAssistant1.Data != null && txtSurgeonAssistant1.Data.ToString().Trim() != "") masterRow.FIRST_ASSISTANT = txtSurgeonAssistant1.Data.ToString().Trim();
                    //if (txtSurgeonAssistant2.Data != null && txtSurgeonAssistant2.Data.ToString().Trim() != "") masterRow.SECOND_ASSISTANT = txtSurgeonAssistant2.Data.ToString().Trim();
                    //if (txtSurgeonAssistant3.Data != null && txtSurgeonAssistant3.Data.ToString().Trim() != "") masterRow.THIRD_ASSISTANT = txtSurgeonAssistant3.Data.ToString().Trim();
                    //if (txtSurgeonAssistant4.Data != null && txtSurgeonAssistant4.Data.ToString().Trim() != "") masterRow.FOURTH_ASSISTANT = txtSurgeonAssistant4.Data.ToString().Trim();
                    //if (txtOperationNurse2.Data != null && txtOperationNurse2.Data.ToString().Trim() != "") masterRow.SECOND_OPER_NURSE = txtOperationNurse2.Data.ToString().Trim();
                    //if (txtSupplyNurse2.Data != null && txtSupplyNurse2.Data.ToString().Trim() != "") masterRow.SECOND_SUPPLY_NURSE = txtSupplyNurse2.Data.ToString().Trim();
                    //if (txtSupplyNurse3.Data != null && txtSupplyNurse3.Data.ToString().Trim() != "") masterRow.THIRD_SUPPLY_NURSE = txtSupplyNurse3.Data.ToString().Trim();
                    //if (txtOperationName.Text.Trim() != "") masterRow.OPER_NAME = txtOperationName.Text.Trim();

                }
                DataTable dataTable = new CommonDA().GetDataWithPrimaryKey("WIS_OPER_MASTER", " WHERE PAT_ID = '" + _patientID + "' AND VISIT_ID = " + _visitID.ToString()
                    + " AND OPER_ID = " + _operID.ToString());
                if (dataTable != null && dataTable.Rows.Count == 1 && dataTable.Rows[0]["OPER_PROCESS"] != System.DBNull.Value)
                {
                }
                else
                {
                    dataTable = new CommonDA().GetDataWithPrimaryKey("WIS_OPER_SCHEDULE", " WHERE PAT_ID = '" + _patientID + "' AND VISIT_ID = " + _visitID.ToString()
                    + " AND schedule_id = " + _operID.ToString());
                }
                if (dataTable != null && dataTable.Rows.Count == 1 && dataTable.Rows[0]["OPER_PROCESS"] != System.DBNull.Value)
                //if (!operationMasterDataTable[0].IsDANBINGZHONGNull())
                {
                    string[] list = dataTable.Rows[0]["OPER_PROCESS"].ToString().Split(',');

                    foreach (TreeListNode node in treeList1.Nodes)
                    {
                        if (node.GetDisplayText(0).Equals(list[0]))
                        {
                            node.Checked = true;
                        }
                        if (node.HasChildren)
                        {
                            foreach (TreeListNode node1 in node.Nodes)
                            {
                                if (node1.GetDisplayText(0).Equals(list[0]))
                                {
                                    node1.Checked = true;
                                }
                            }
                        }
                    }
                    if (list.Length > 2)
                    {
                        textEdit1.Text = list[2];
                        DateTime dt;
                        if (DateTime.TryParse(list[1], out dt))
                        {
                            dateEdit1.DateTime = dt;
                        }
                    }
                    else if (list.Length > 1)
                    {
                        textEdit1.Text = list[1];
                    }
                }
            }
        }

        /// <summary>
        /// treelist初始化
        /// </summary>
        private void InitTreeList()
        {
            treeList1.Nodes.Clear();
            string[] list = ApplicationConfiguration.OpertionProgressList.Split(',');
            foreach (string s in list)
            {
                if (!string.IsNullOrEmpty(s))
                {
                    TreeListNode node = treeList1.AppendNode(new object[] { s }, null);
                    if (s.Equals("术中"))
                    {
                        string[] list1 = ApplicationConfiguration.OpertionProgressInOperationList.Split(',');
                        foreach (string s1 in list1)
                        {
                            if (!string.IsNullOrEmpty(s1))
                            {
                                treeList1.AppendNode(new object[] { s1 }, node);
                            }
                        }
                    }
                }
            }
            treeList1.ExpandAll();
        }

        public override bool Save()
        {
            bool ret = false;
            if (!string.IsNullOrEmpty(_patientID))
            {
                DataTable dataTable = new CommonDA().GetDataWithPrimaryKey("WIS_OPER_MASTER", " WHERE PAT_ID = '" + _patientID + "' AND VISIT_ID = " + _visitID.ToString()
                    + " AND OPER_ID = " + _operID.ToString());
                if (dataTable != null && dataTable.Rows.Count == 1)
                {
                    string s = "";
                    foreach (TreeListNode node in treeList1.Nodes)
                    {
                        if (node.Checked)
                        {
                            s = node.GetDisplayText(0);
                        }
                        if (node.HasChildren)
                        {
                            foreach (TreeListNode node1 in node.Nodes)
                            {
                                if (node1.Checked)
                                {
                                    s = node1.GetDisplayText(0);
                                }
                            }
                        }
                    }
                    if (dateEdit1.EditValue != null)
                    {
                        if (dataTable.Rows[0]["OPER_PROCESS"] != System.DBNull.Value && dataTable.Rows[0]["OPER_PROCESS"].ToString().EndsWith("," + textEdit1.Text))
                        {

                        }
                        else
                        {
                            dataTable.Rows[0]["OPER_PROCESS"] = s + "," + dateEdit1.DateTime.ToString("yyyy-MM-dd HH:mm") + "," + textEdit1.Text;
                        }
                    }
                    else
                    {
                        dataTable.Rows[0]["OPER_PROCESS"] = s;
                    }
                    int result = new CommonDA().UpdateDataTable(dataTable);
                    if (result == 1)
                    {
                        ret = true;
                    }
                }
                //else
                {
                    dataTable = new CommonDA().GetDataWithPrimaryKey("WIS_OPER_SCHEDULE", " WHERE PAT_ID = '" + _patientID + "' AND VISIT_ID = " + _visitID.ToString()
                        + " AND schedule_id = " + _operID.ToString());
                    if (dataTable != null && dataTable.Rows.Count == 1)
                    {
                        string s = "";
                        foreach (TreeListNode node in treeList1.Nodes)
                        {
                            if (node.Checked)
                            {
                                s = node.GetDisplayText(0);
                            }
                            if (node.HasChildren)
                            {
                                foreach (TreeListNode node1 in node.Nodes)
                                {
                                    if (node1.Checked)
                                    {
                                        s = node1.GetDisplayText(0);
                                    }
                                }
                            }
                        }
                        if (dateEdit1.EditValue != null)
                        {
                            if (dataTable.Rows[0]["OPER_PROCESS"] != System.DBNull.Value && dataTable.Rows[0]["OPER_PROCESS"].ToString().EndsWith("," + textEdit1.Text))
                            {

                            }
                            else
                            {
                                dataTable.Rows[0]["OPER_PROCESS"] = s + "," + dateEdit1.DateTime.ToString("yyyy-MM-dd HH:mm") + "," + textEdit1.Text;
                            }
                        }
                        else
                        {
                            dataTable.Rows[0]["OPER_PROCESS"] = s;
                        }
                        int result = new CommonDA().UpdateDataTable(dataTable);
                        if (result == 1)
                        {
                            ret = true;
                        }
                    }
                }
            }
            return ret;
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex >= 0)
            {
                textEdit1.Text = radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Value.ToString();
            }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            DateTime dt;
            if (string.IsNullOrEmpty(textEdit1.Text) || string.IsNullOrEmpty(textEdit1.Text.Trim()))
            {
                dt = DateTime.MinValue;
            }
            else
            {
                int se = -1;
                if (int.TryParse(textEdit1.Text.Trim(), out se))
                {
                    dt = DateTime.Now.AddMinutes(se);
                }
                else
                {
                    dt = DateTime.MinValue;
                }
            }
            if (dt > DateTime.MinValue)
            {
                dateEdit1.DateTime = dt;
            }
            else
            {
                dateEdit1.EditValue = null;
            }
            Save();
        }

        private void treeList1_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e.Node.HasChildren)
            {
                e.Node.Checked = false;
            }
            if (e.Node.Checked)
            {
                foreach (TreeListNode node in treeList1.Nodes)
                {
                    if (node.Checked && !node.Equals(e.Node))
                    {
                        node.Checked = false;
                    }
                    if (node.HasChildren)
                    {
                        foreach (TreeListNode node1 in node.Nodes)
                        {
                            if (node1.Checked && !node1.Equals(e.Node))
                            {
                                node1.Checked = false;
                            }
                        }
                    }
                }
                if (e.Node.GetDisplayText(0).Equals("麻醉结束"))
                {
                    textEdit1.Text = "45";
                }
            }
            Save();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }
    }
}
