using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Com.MedicalSystem.Common.Utilities;
using Com.MedicalSystem.Icu.DataSetModel;
using Com.MedicalSystem.Icu;

namespace AnesScore.Controls
{
    public partial class AnesScoreMain : DevExpress.XtraEditors.XtraUserControl
    {


        public AnesScoreMain()
        {
            InitializeComponent();
        }
        public AnesScoreMain(string patientID, decimal visitID, decimal deptID)
        {
            InitializeComponent();
            InitAnesScore(patientID, visitID, deptID);
        }

        private void InitAnesScore(string patientID, decimal visitID, decimal deptID)
        {
            //Patient.PatientBaseDataTable patientTable = Com.MedicalSystem.Icu.DataOperator.GetPatientBase(patientID, visitID, deptID);
            //if (patientTable.Rows.Count > 0)
            //{
            //    Com.MedicalSystem.Icu.DataSetModel.Patient.PatientDataTable table = new Com.MedicalSystem.Icu.DataSetModel.Patient.PatientDataTable();
            //    Com.MedicalSystem.Icu.DataSetModel.Patient.PatientRow row = table.NewPatientRow();
            //    row.PATIENT_ID = patientTable[0].PATIENT_ID;
            //    row.VISIT_ID = patientTable[0].VISIT_ID;
            //    row.DEP_ID = patientTable[0].DEP_ID;
            //    ScoresPanel scoresPanel = new ScoresPanel(row);
            //    tabPage1.Controls.Add(scoresPanel);
            //}



            Com.MedicalSystem.Icu.DataSetModel.Patient.PatientDataTable table = new Com.MedicalSystem.Icu.DataSetModel.Patient.PatientDataTable();
            Com.MedicalSystem.Icu.DataSetModel.Patient.PatientRow row = table.NewPatientRow();
            row.PATIENT_ID = patientID;
            row.VISIT_ID = visitID;
            row.DEP_ID = deptID;
            
            //ScoresPanel scoresPanel = new ScoresPanel(row);
            //scoresPanel.Dock = DockStyle.Fill;
            //this.Controls.Add(scoresPanel);

        }



    }
}
