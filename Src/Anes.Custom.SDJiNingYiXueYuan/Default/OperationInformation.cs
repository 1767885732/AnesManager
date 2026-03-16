using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Documents;
using Wis.Anes.Framework.Doc;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.Framework;
using Wis.Anes.DataAccess;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework.Controls;
using Wis.Anes.Framework.Utilities;

namespace Wis.Anes.Custom.CustomProject.Default
{
    /// <summary>
    /// 手术信息
    /// </summary>
    public partial class OperationInformation : BaseDoc
    {
        public OperationInformation()
        {
            InitializeComponent();
            base.PrintButton.Visible = false;
            base.DocKind = DocKind.Default;
            base.HideScrollBar();
        }

        bool isRoomnoORSequenceChanged = false;

        private void ctl_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((sender as MTextBox).Text))
                isRoomnoORSequenceChanged = true;
        }

        protected override void OnViewBuilded(List<IUIElementHandler> handlers, Dictionary<string, DataTable> dataSources)
        {
            List<MTextBox> textBoxs = this.GetControls<MTextBox>();
            foreach (MTextBox ctl in textBoxs)
            {
                if (ctl.Name == "MtextRoomNo" || ctl.Name == "MtextSeqence")
                {
                    ctl.TextChanged += new EventHandler(ctl_TextChanged);
                }
            }
        }

        protected override void BuildData(Dictionary<string, DataTable> dataSource)
        {
            isRoomnoORSequenceChanged = false;

            dataSource["WIS_OPER_MASTER"] = DataContext.GetCurrent().GetData("WIS_OPER_MASTER");
            
            dataSource["WIS_PAT_MASTER_INDEX"] = DataContext.GetCurrent().GetData("WIS_PAT_MASTER_INDEX");

            
        }
        protected override void OnSaveData(Dictionary<string, DataTable> dataSource)
        {
            if (isRoomnoORSequenceChanged) Dialog.MessageBox("温馨提示：修改手术间号和台次将会影响当前已安排手术，请结合实际情况修改。");
            base.OnSaveData(dataSource);
            CommonDA commonDA = new CommonDA();
            commonDA.Update(dataSource["WIS_OPER_MASTER"], "WIS_OPER_MASTER");
            commonDA.Update(dataSource["WIS_PAT_MASTER_INDEX"], "WIS_PAT_MASTER_INDEX");
            AnesInformations.OperationMasterDataTable operationMasterDataTable = dataSource["WIS_OPER_MASTER"] as AnesInformations.OperationMasterDataTable;
            if (ExtendApplicationContext.Current.PatientInformation.OperRoom != operationMasterDataTable[0].OPERATING_ROOM_NO)
            {
                ExtendApplicationContext.Current.PatientInformation.OperRoom = operationMasterDataTable[0].OPERATING_ROOM_NO;
            }
            //台次
            if (!operationMasterDataTable[0].IsSEQUENCENull() && ExtendApplicationContext.Current.PatientInformation.Sequence != operationMasterDataTable[0].SEQUENCE.ToString())
            {
                ExtendApplicationContext.Current.PatientInformation.Sequence = operationMasterDataTable[0].SEQUENCE.ToString();
            }
            if (!operationMasterDataTable[0].IsEMERGENCY_INDICATORNull() && ExtendApplicationContext.Current.PatientInformation.Emgerency != operationMasterDataTable[0].EMERGENCY_INDICATOR)
            {
                ExtendApplicationContext.Current.PatientInformation.Emgerency = (int)operationMasterDataTable[0].EMERGENCY_INDICATOR ;
            }
            if (!operationMasterDataTable[0].IsISOLATION_INDICATORNull()&& ExtendApplicationContext.Current.PatientInformation.Isolation != operationMasterDataTable[0].ISOLATION_INDICATOR)
            {
                ExtendApplicationContext.Current.PatientInformation.Isolation = (int)operationMasterDataTable[0].ISOLATION_INDICATOR;
            }
        }
       
    }
}
