using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Wis.Anes.BusinessEntity;
using Wis.Anes.DataAccess;

namespace Wis.Anes.Framework.Views.Equipment
{
    public partial class EquipmentRepair : XtraForm
    {
        private Dict.EQUIPMENTREPAIRSTATUSBYDAYRow _equipmentRow;
        private Dict.WIS_EQIP_REPAIRDataTable _equipmentRepair;
        DictDA _dictDA = new DictDA();
        public EquipmentRepair(Dict.EQUIPMENTREPAIRSTATUSBYDAYRow equipmentRow,DateTime dt)
        {
            InitializeComponent();
            this._equipmentRow = equipmentRow;
            this.dateEditMaintenanceTime.DateTime = dt;
            _equipmentRepair = _dictDA.GetEquipmentRepair();

        }
        private void EquipmentRepair_Load(object sender, EventArgs e)
        {
            try
            {
                if (_equipmentRow == null)
                    return;
                txtInstrumentCode.Text = _equipmentRow.INSTRUMENT_CODE;
                txtInstrumentName.Text = _equipmentRow.INSTRUMENT_NAME;
                txtSituation.Text = _equipmentRow.SITUATION;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int repairCount = 0;
            if (_equipmentRepair == null)
                return;
            Dict.WIS_EQIP_REPAIRRow rRow = _equipmentRepair.FindByINSTRUMENT_CODEREPAIR_COUNT(_equipmentRow.INSTRUMENT_CODE, _equipmentRow.REPAIR_COUNT);
            string tt = "";
            if (!_equipmentRow.IsMAINTENANCE_TIMENull())
            {
                tt = _equipmentRow.MAINTENANCE_TIME.ToString("yyyy-MM-dd");
            }
            
            string mt=dateEditMaintenanceTime.DateTime.ToString("yyyy-MM-dd");
            if (rRow!=null && tt.Equals(mt))
            {
                rRow.SITUATION = txtSituation.Text;
            }
            else
            {
                foreach (Dict.WIS_EQIP_REPAIRRow reRow in _equipmentRepair.Rows)
                {
                    if (reRow.INSTRUMENT_CODE.Equals(txtInstrumentCode.Text))
                    {
                        if (reRow.REPAIR_COUNT > repairCount)
                            repairCount = Convert.ToInt32(reRow.REPAIR_COUNT);
                    }
                }
                repairCount++;
                var row = _equipmentRepair.NewWIS_EQIP_REPAIRRow();
                row.INSTRUMENT_CODE = txtInstrumentCode.Text;
                row.REPAIR_COUNT = repairCount;
                row.MAINTENANCE_TIME = dateEditMaintenanceTime.DateTime;
                row.SITUATION = txtSituation.Text;
                _equipmentRepair.AddWIS_EQIP_REPAIRRow(row);
            }
                if (_dictDA.UpdateEquipmentRepair(_equipmentRepair) > 0)
                {
                    MessageBox.Show("保存成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    this.DialogResult = DialogResult.OK;
                }
            
            _equipmentRepair.AcceptChanges();
        }
    }
}