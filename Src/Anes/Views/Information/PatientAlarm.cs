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
using Wis.Anes.Layouts;

namespace Wis.Anes.Views
{
    public partial class PatientAlarm : BaseView
    {




        //患者预警
        public PatientAlarm()
        {
            InitializeComponent();
        }


        Font fontReaded = null;
        Font fontUnRead = null;
        DataTable dtAnesAlarmMsg = null;
        private void PatientAlarm_Load(object sender, EventArgs e)
        {

            fontReaded = new Font(dgvMsgAlarm.DefaultCellStyle.Font, FontStyle.Bold);
            fontUnRead = dgvMsgAlarm.DefaultCellStyle.Font;


            LoadAlarmMsg();
        }



        public void LoadAlarmMsg()
        {
            dtAnesAlarmMsg = AnesthesiaSheetProxy.GetAnesAlarmMsg(
        ExtendApplicationContext.Current.PatientContext.PatientID,
        ExtendApplicationContext.Current.PatientContext.VisitID,
        ExtendApplicationContext.Current.PatientContext.OperID);

            dgvMsgAlarm.DataSource = dtAnesAlarmMsg;

            CountUnReadMsg();
        
        }
        private void dgvMsgAlarm_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            if (dgvMsgAlarm.Rows[e.RowIndex].Cells["colCheck"].Value.ToString() == "0")
            {
                dgvMsgAlarm.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Font = fontReaded;
            }
            else
            {
                dgvMsgAlarm.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Font = fontUnRead;
            }
        }

        private void dgvMsgAlarm_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            if (dgvMsgAlarm.Rows[e.RowIndex].Cells["colCheck"].ColumnIndex == e.ColumnIndex)
            {
                return;
            }

            if (dgvMsgAlarm.Rows[e.RowIndex].Cells["colCheck"].Value.ToString() == "0")
            {
                dgvMsgAlarm.Rows[e.RowIndex].Cells["colCheck"].Value = "1";
            }
            else
            {
                dgvMsgAlarm.Rows[e.RowIndex].Cells["colCheck"].Value = "0";
            }

            dgvMsgAlarm.Refresh();

            CountUnReadMsg();

        }

        private void dgvMsgAlarm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            if (dgvMsgAlarm.Rows[e.RowIndex].Cells["colCheck"].ColumnIndex == e.ColumnIndex)
            {
                if (dgvMsgAlarm.Rows[e.RowIndex].Cells["colCheck"].Value.ToString() == "0")
                {
                    dgvMsgAlarm.Rows[e.RowIndex].Cells["colCheck"].Value = "1";
                }
                else
                {
                    dgvMsgAlarm.Rows[e.RowIndex].Cells["colCheck"].Value = "0";
                }

                dgvMsgAlarm.Refresh();
                CountUnReadMsg();
            }
        }



        private void CountUnReadMsg()
        {
            int count = 0;
            for (int i = 0; i < dgvMsgAlarm.RowCount; i++)
            {
                if (dgvMsgAlarm.Rows[i].Cells["colCheck"].Value.ToString() == "0")
                {
                    count++;
                }
            }

            Msg.Text = "您共有 " + count + " 条未读消息!";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AnesthesiaSheetProxy.UpdateAnesAlarmMsg(dtAnesAlarmMsg);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            ((Form)this.Parent).Close();
            
  
        }



    }




    public static class CurrentPatientAlarm
    {
        private static PatientAlarm patientAlarm = null;
        private static DialogHostForm dialogHostForm = null;
        public static PatientAlarm GetCurrentPatientAlarm()
        {
            if (patientAlarm != null)
            {
                patientAlarm.Dispose();
                patientAlarm = null;
            }
 
             patientAlarm = new PatientAlarm();
            
            return patientAlarm ;
        }

        public static DialogHostForm GetCurrentPatientAlarmForm(PatientAlarm patientAlarm)
        {
            if (dialogHostForm != null)
            {
                dialogHostForm.Dispose();
                dialogHostForm = null;
            }

            dialogHostForm = new DialogHostForm(patientAlarm.Caption, patientAlarm.Width, patientAlarm.Height + 30);
            dialogHostForm.Child = patientAlarm;
            

       
            return dialogHostForm;
        }
    }

}
