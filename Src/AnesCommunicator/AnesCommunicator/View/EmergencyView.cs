using AnesCommunicator.BaseType;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnesCommunicator.View
{
    /// <summary>
    /// 紧急呼叫弹出窗体
    /// </summary>
    public partial class EmergencyView : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="strOperationInformations"></param>
        public EmergencyView(string strOperationInformations)
        {
            InitializeComponent();
            try
            {
                OperationInformations operationInformations = JsonConvert.DeserializeObject<OperationInformations>(strOperationInformations);

                // 显示患者信息
                if (operationInformations != null)
                {
                    lblMessage.Text = string.Format(operationInformations.EmergencyCall.Message, operationInformations.EmergencyCall.OperatingRoom);
                    lblName.Text = operationInformations.PatientInfo.Name;
                    lblSex.Text = operationInformations.PatientInfo.Sex;
                    lblAge.Text = operationInformations.PatientInfo.Age;
                    lblBedNo.Text = operationInformations.PatientInfo.BedNo;
                    lblBloodPressure.Text = operationInformations.PatientSignInfo.BloodPressure;
                    lblBreath.Text = operationInformations.PatientSignInfo.Breath;
                    lblHeartRate.Text = operationInformations.PatientSignInfo.HeartRate;
                    lblTemperature.Text = operationInformations.PatientSignInfo.Temperature;
                    lblOperName.Text = operationInformations.OperationInfo.OperationName;
                    lblAnesthesiaName.Text = operationInformations.OperationInfo.AnesthesiaMethod;
                    lblAnesthesiaDoctor.Text = operationInformations.OperationInfo.AnesthesiaDoctor;
                    lblSurgeon.Text = operationInformations.OperationInfo.Surgeon;
                    lblOperationNurse.Text = operationInformations.OperationInfo.OperationNurse;
                    lblSupplyNurse.Text = operationInformations.OperationInfo.SupplyNurse;
                }
                else
                {
                    label1.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    label5.Visible = false;
                    label6.Visible = false;
                    label7.Visible = false;
                    label8.Visible = false;
                    label9.Visible = false;
                    label10.Visible = false;
                    label11.Visible = false;
                    label12.Visible = false;
                    label13.Visible = false;
                    label14.Visible = false;
                    lblName.Visible = false;
                    lblSex.Visible = false;
                    lblAge.Visible = false;
                    lblBedNo.Visible = false;
                    lblOperName.Visible = false;
                    lblAnesthesiaName.Visible = false;
                    lblBloodPressure.Visible = false;
                    lblBreath.Visible = false;
                    lblHeartRate.Visible = false;
                    lblTemperature.Visible = false;
                    lblAnesthesiaDoctor.Visible = false;
                    lblSurgeon.Visible = false;
                    lblOperationNurse.Visible = false;
                    lblSupplyNurse.Visible = false;
                }
            }
            catch
            {
                lblMessage.Text = strOperationInformations;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                lblName.Visible = false;
                lblSex.Visible = false;
                lblAge.Visible = false;
                lblBedNo.Visible = false;
                lblOperName.Visible = false;
                lblAnesthesiaName.Visible = false;
                lblBloodPressure.Visible = false;
                lblBreath.Visible = false;
                lblHeartRate.Visible = false;
                lblTemperature.Visible = false;
                lblAnesthesiaDoctor.Visible = false;
                lblSurgeon.Visible = false;
                lblOperationNurse.Visible = false;
                lblSupplyNurse.Visible = false;
            }
        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 背景闪耀变色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerEmergency_Tick(object sender, EventArgs e)
        {
            if (this.BackColor == Color.Red)
            {
                this.BackColor = Color.FromArgb(255, 255, 128, 0);
            }
            else
            {
                this.BackColor = Color.Red;
            }
        }
    }
}
