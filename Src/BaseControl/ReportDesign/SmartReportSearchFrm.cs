using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Com.MedicalSystem.Common.Utilities;
using Com.MedicalSystem.Common.Controls;
using MedicalSystem.SmartReport.Viewer;
using MedicalSystem.SmartReport.Viewer.BusinessEntity;

namespace Com.ICIS.Icu
{
    public partial class SmartReportSearchFrm : BaseFrm
    {
        private string _reportName;
        private string _reportClientId;
        private int _mappingDataId;
        private bool _removeCurrentData = false;

        private SmartReportBusinessComponent _businessComponent;
        private ReportMappingData.MappingDataRow _mappingDataRow;
     
        public SmartReportSearchFrm(string reportName,string reportClientId,int mappingDataId)
        {
            InitializeComponent();
            this._reportName = reportName;
            this._reportClientId = reportClientId;
            this._mappingDataId = mappingDataId;
            InitalizeButtons(false);
            _businessComponent = new SmartReportBusinessComponent(this._reportName, this._reportClientId);
        }

        private void medButton1_Click(object sender, EventArgs e)
        {
            DateTime start = new DateTime(this.dateTimePicker1.DateTime.Year, this.dateTimePicker1.DateTime.Month, this.dateTimePicker1.DateTime.Day, 0, 0, 0);
            DateTime end = new DateTime(this.dateTimePicker2.DateTime.Year, this.dateTimePicker2.DateTime.Month, this.dateTimePicker2.DateTime.Day, 23, 59, 59);
            if (end < start)
            {
                this.errorProvider1.SetError(this.dateTimePicker2, "开始时间必须大于结束时间");
                return;
            }
           
            Label loading = new Label();
            loading.Image = Com.MedicalSystem.Common.Con.Properties.Resources.load; 
            loading.ImageAlign = ContentAlignment.MiddleLeft;
            loading.Width = 120;
            loading.Height = 30;
            loading.Location = new Point(this.dataGridView1.Width / 2-50, this.dataGridView1.Height / 2);
            loading.Name = "loading";
            loading.Text = "   加载中...";
            loading.TextAlign = ContentAlignment.MiddleCenter;
            loading.BackColor = Color.Transparent;
          
            this.dataGridView1.Controls.Add(loading);
            InitalizeButtons(false);

            using (BackgroundWorker worker = new BackgroundWorker())
            {
                worker.DoWork += delegate(object sender1, DoWorkEventArgs e1)
                {
                   e1.Result = _businessComponent.GetReports(start, end);
                };
                worker.RunWorkerCompleted += delegate(object sender2, RunWorkerCompletedEventArgs e2)
                {
                    ReportMappingData data = e2.Result as ReportMappingData;
                    this.bindingSource1.DataSource = data;
                    this.bindingSource1.DataMember = data.MappingData.TableName;
                    this.dataGridView1.DataSource = this.bindingSource1;
                    InitalizeButtons(this.dataGridView1.Rows.Count > 0);
                    this.dataGridView1.Controls.RemoveByKey("loading");
                };
                worker.RunWorkerAsync();
            }
           
            
        }

        private void InitalizeButtons(bool enable)
        {
            this.First.Enabled = enable;
            this.Previous.Enabled = enable;
            this.next.Enabled = enable;
            this.Last.Enabled = enable;
            this.Delete.Enabled = enable;
            this.First.Enabled = enable;
            this.ok.Enabled = enable;
        }
        private void First_Click(object sender, EventArgs e)
        {
            this.bindingSource1.MoveFirst();
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            this.bindingSource1.MovePrevious();
        }

        private void next_Click(object sender, EventArgs e)
        {
            this.bindingSource1.MoveNext();
        }

        private void Last_Click(object sender, EventArgs e)
        {
            this.bindingSource1.MoveLast();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if ((this.bindingSource1.Current != null)
                && MessageBox.Show("是否删除所选择的表单数据?", "ICU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
               
                DataRowView dataRowView = this.bindingSource1.Current as DataRowView;
                if (dataRowView != null)
                {
                    _mappingDataRow = dataRowView.Row as ReportMappingData.MappingDataRow;
                    _mappingDataRow.IsValid = 0;
                   
                }
                ReportMappingData data = this.bindingSource1.DataSource as ReportMappingData;

                if (data != null)
                {
                    _businessComponent.SaveReport(data);
                }
               
                if (_mappingDataRow.ReportMappingID == this._mappingDataId)
                {
                    _removeCurrentData = true;
                }
                this.bindingSource1.RemoveCurrent();
                data.AcceptChanges();
                this.ok.Enabled = this.dataGridView1.Rows.Count > 0;
            }
                
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (this.bindingSource1.Current != null)
            {
                DataRowView dataRowView = this.bindingSource1.Current as DataRowView;
                if (dataRowView != null)
                {
                    _mappingDataRow = dataRowView.Row as ReportMappingData.MappingDataRow;
                   
                }
            }

            FormOpacityHelper(DialogResult.OK);
        }
      

        public ReportMappingData.MappingDataRow MappingDataRow
        {
            get { return _mappingDataRow; }
            set { _mappingDataRow = value; }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            FormOpacityHelper(DialogResult.Cancel);
        }

        public bool RemoveCurrentReportData
        {
            get { return this._removeCurrentData; }
         
        }

        private void SmartReportSearchFrm_Load(object sender, EventArgs e)
        {
            FormOpacityHelper();
        }
        private void FormOpacityHelper()

        {
            this.Opacity = 0;
            Timer timer = new Timer();
            timer.Interval = 25;
            timer.Tick += delegate
            {
                if (this.Opacity != 1)
                {
                    this.Opacity = this.Opacity + 0.1;
                }
                else
                {
                    timer.Stop();
                    timer.Dispose();
                   
                }
            };
            timer.Start();
        }
        private void FormOpacityHelper(DialogResult dialogResult)
        {
            Timer timer = new Timer();
            timer.Interval = 25;
            timer.Tick += delegate
            {
                if (this.Opacity != 0)
                {
                    this.Opacity = this.Opacity - 0.1;
                }
                else
                {
                    timer.Stop();
                    timer.Dispose();
                    this.DialogResult = dialogResult;
                }
            };
            timer.Start();
        }

       
       
    }
   
}