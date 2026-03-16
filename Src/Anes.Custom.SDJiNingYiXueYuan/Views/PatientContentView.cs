using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework;
using DevExpress.XtraEditors;

namespace Wis.Anes.Custom.CustomProject.Views
{
    [ToolboxItem(false)]
    public partial class PatientContentView : UserControl
    {
        public PatientContentView()
        {
            InitializeComponent();
        }
        public PatientContentView(PatientInformation patientInformation)
            : this()
        {
            _patientInformation = patientInformation;

        }
        private Dict.HisUserDataTable _doctorTable;
        private Dict.HisUserDataTable _nurseTable;

        public Dict.HisUserDataTable NurseTable
        {
            get
            {
                return _nurseTable;
            }
            set
            {
                _nurseTable = value;
            }
        }

        public Dict.HisUserDataTable DoctorTable
        {
            get
            {
                return _doctorTable;
            }
            set
            {
                _doctorTable = value;
            }
        }
        private PatientInformation _patientInformation;
        public PatientInformation PatientInformation
        {
            get { return _patientInformation; }
            set { _patientInformation = value; }

        }
        private bool _selected = false;
        public bool Selected
        {
            set
            {
                _selected = value;
                if (value == true)
                {
                    this.panel1.BackColor = Color.LightGray;
                    this.panel3.BackColor = Color.LightGray;
                }
                else
                {
                    this.panel1.BackColor = Color.Transparent;
                    this.panel3.BackColor = Color.Transparent;
                }

            }
            get
            {
                return _selected;
            }
        }
        public void InitalizeUI()
        {
            this.groupControl1.Text = string.Format("手术室 {0}", _patientInformation.OperRoom);
            string s = OperationStatusHelper.OperationStatusToString((OperationStatus)(int)_patientInformation.OperStatus);
            if (!string.IsNullOrEmpty(s))
            {
                Color color = Color.Black;
                if ((int)_patientInformation.OperStatus == (int)OperationStatus.OperationStart)
                {
                    color = Color.Yellow;

                }
                else if ((int)_patientInformation.OperStatus == (int)OperationStatus.AnesthesiaStart)
                {
                    color = Color.Red;

                }
                // this.statusLabel.Text = s;
                //this.statusLabel.ForeColor = color;
            }
            this.statusLabel.Text = s;
            labelControl2.Text = string.Format("患者 {0} {1} {2} {3}", _patientInformation.Sex, _patientInformation.Name, _patientInformation.PatientID, _patientInformation.InpNo.Equals(_patientInformation.PatientID) ? "" : _patientInformation.InpNo);
            labelControl3.Text = string.Format("手术 {0}", _patientInformation.OperationName);
            labelControl4.Text = string.Format("时间 {0}", _patientInformation.OperationTime.ToString("yyyy-MM-dd HH:mm"));

            labelControl2.ToolTip = labelControl2.Text;
            labelControl3.ToolTip = labelControl3.Text;
            labelControl4.ToolTip = labelControl4.Text;
            string text = _patientInformation.Surgeon;
            if (!string.IsNullOrEmpty(text))
            {
                if (_doctorTable != null)
                {
                    Dict.HisUserRow row = _doctorTable.FindByUSER_ID(text);
                    if (row != null)
                    {
                        text = row.USER_NAME;
                    }
                }

            }
            string anes = _patientInformation.AnesDoctor;
            if (!string.IsNullOrEmpty(anes))
            {
                if (_doctorTable != null)
                {
                    Dict.HisUserRow row = _doctorTable.FindByUSER_ID(anes);
                    if (row != null)
                    {
                        anes = row.USER_NAME;
                    }
                }
            }
            else
            {
                anes = "";
            }
            labelControl5.Text = string.Format("术者 {0}   麻醉 {1}", text, anes);

        }

        public event EventHandler DoubleClicked; 
        public event EventHandler Clicked;
        public event EventHandler MouseEntered;

        private void groupControl1_DoubleClick(object sender, EventArgs e)
        {
            if (DoubleClicked != null)
                DoubleClicked(this, EventArgs.Empty);
        }

        private void groupControl1_Click(object sender, EventArgs e)
        {
            if (Clicked != null)
                Clicked(this, EventArgs.Empty);
        }

        private void groupControl1_MouseEnter(object sender, EventArgs e)
        {
            if (MouseEntered != null)
                MouseEntered(this, EventArgs.Empty);

            this.panel1.BackColor = Color.FromArgb(29, 117, 181);
            this.panel3.BackColor = this.panel1.BackColor;
        }

        private void groupControl1_MouseLeave(object sender, EventArgs e)
        {
            this.panel1.BackColor = Color.Transparent;
            this.panel3.BackColor = this.panel1.BackColor;
        }
    }
}
