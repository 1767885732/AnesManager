using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Com.ICIS.Common.Con;
using MedicalSystem.SmartReport.Viewer;

namespace Com.ICIS.Icu.ReportDesign
{
    public partial class SmartReportHostControl : BaseControl
    {
        public SmartReportHostControl():base()
        {
            InitializeComponent();
        }
       
        public SmartReportHostControl(MedicalSystem.Icu.DataSetModel.Patient.PatientRow patientRow, string title,string reportName,bool allowSearch)
            : base(patientRow, title)
        {
            this._reportName = reportName;

            InitializeComponent();
            medButton4.Visible = allowSearch;
            medButton5.Visible = allowSearch;
            medButton5.Enabled = false;
        }
        private string _reportName;
        private ReportViewer _reportViewer;
       

        private void medButton1_Click(object sender, EventArgs e)
        {
            this._reportViewer.EndCurrentEdit();
            if (_reportViewer.XmlFormatBindingData.Rows[0].RowState == DataRowState.Unchanged && medButton5.Enabled==false)
            {
                MessageBox.Show("请填写表单数据", "ICU", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SaveReport();
            MessageBox.Show("表单数据已提交", "ICU", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveReport()
        {
            SaveData();
        }
        private void NewReport()
        {
            DataTable data = _reportViewer.XmlFormatBindingData;
            foreach (DataColumn dc in data.Columns)
            {
                if (dc.DataType == typeof(string))
                    data.Rows[0][dc] = string.Empty;
                if (dc.DataType == typeof(bool))
                    data.Rows[0][dc] = false;
                if (dc.DataType == typeof(DateTime))
                    data.Rows[0][dc] = DateTime.Today;
                if (dc.DataType == typeof(decimal))
                    data.Rows[0][dc] = decimal.Zero;
            }
            _reportViewer.XmlFormatBindingData = data;
            _reportViewer.CustomMappingData = null;
            medButton5.Enabled = false;
            _reportViewer.XmlFormatBindingData.AcceptChanges();
        }

        private void medButton2_Click(object sender, EventArgs e)
        {
            _reportViewer.PrintPreview();
          
        }

        private void medButton3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "pdf";
            saveFileDialog.Filter = "Pdf文档|*.pdf";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;
            _reportViewer.WriteToPdf(saveFileDialog.FileName);
        }

        private void medButton4_Click(object sender, EventArgs e)
        {
            int current = -1;
            if (this._reportViewer.CustomMappingData != null)
            {
                current = this._reportViewer.CustomMappingData.ReportMappingID;
            }
            SmartReportSearchFrm search = new SmartReportSearchFrm(this._reportName, this.PatientRow.PATIENT_ID + this.PatientRow.VISIT_ID, current);
            if (search.ShowDialog() == DialogResult.OK)
            {
                this._reportViewer.EndCurrentEdit();
                 if (medButton5.Enabled == false
                     && _reportViewer.XmlFormatBindingData.Rows[0].RowState == DataRowState.Modified 
                     && MessageBox.Show("是否保存当前表单页面的数据?", "ICU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                 {
                     SaveReport();
                 }
                 _reportViewer.CustomMappingData = search.MappingDataRow;
                 _reportViewer.XmlFormatBindingData = UIElementDataMapper.ToData(search.MappingDataRow.MapperData);
            }
            if (search.RemoveCurrentReportData)
            {
                NewReport();
            }
        }

        private void medButton5_Click(object sender, EventArgs e)
        {
            NewReport();
        }


        private void InitializeReport()
        {
            DataSetModel.Patient patient = new Com.MedicalSystem.Icu.DataSetModel.Patient();
            patient._Patient.LoadDataRow(this.PatientRow.ItemArray, true);

            _reportViewer = new ReportViewer();
            _reportViewer.ReportClientId = this.PatientRow.PATIENT_ID + this.PatientRow.VISIT_ID.ToString();
            _reportViewer.DataSet = patient;
            _reportViewer.Dock = DockStyle.Fill;
            _reportViewer.Name = "reportViewer";

            panel2.Controls.Add(_reportViewer);
        }


        protected override void LoadData()
        {
            InitializeReport();

            _reportViewer.LoadReport(_reportName);
            _reportViewer.XmlFormatBindingData.AcceptChanges();
        }

        protected override void SaveData()
        {
            _reportViewer.Submit("userId");
            medButton5.Enabled = true;
        }
    }
}
