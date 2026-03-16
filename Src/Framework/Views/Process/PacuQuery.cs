using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Wis.Anes.DataAccess;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.Framework.Documents;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using Wis.Anes.Framework.Utilities;

namespace Wis.Anes.Framework.Views.Process
{
    public partial class PacuQuery : BaseView
    {
        protected DataRow _selectRow = null; // 操作的行 
       
        public PacuQuery()
        {
            InitializeComponent();
        }

        protected void RefreshDataSource()
        {
            //DataTable dt = new AnesMasterDA().GetTable("Operation_Process");

            CommonDA da = new CommonDA();
            string sql = string.Format("select * from VIEW_PACU_PIPE_AND_DRUG where to_char(scheduled_date_time, 'yyyy-MM-dd') = '{0:yyyy-MM-dd}'", dateEditQuery.DateTime);
            DataTable dt = da.GetDataFromSQLString(sql);
            
            if (dt == null)
                return;
       
            //sql = 

            //int topindex = gridViewLeftList.TopRowIndex;
            dt.DefaultView.RowFilter = "pull_pipe = '保留' or drug_use is not null";
            DataSource = dt;
            //gridViewLeftList.TopRowIndex = topindex;

            _selectRow = null;

            DataRow[] rows = dt.Select("pull_pipe = '保留'");
            DateTime dtMax = DateTime.MinValue;
            int outPull = 0;
            List<string> doctors = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                if (!row.IsNull("out_pacu_date_time"))
                {
                    DateTime dtCur = Convert.ToDateTime(row["out_pacu_date_time"]);
                    if (dtCur > dtMax)
                        dtMax = dtCur;

                    if (row["out_pull_pipe"].ToString() == "拔除")
                        outPull++;

                    if(!doctors.Contains(row["PACU_DOCTOR"].ToString()))
                        doctors.Add(row["PACU_DOCTOR"].ToString());
                }
            }

            string doctor = doctors.Count > 0 ? doctors[0] : "";
            for (int i = 1; i < doctors.Count; i++)
            {
                doctor += "," + doctors[i];
            }

            string str = string.Format("{0:yyyy-MM-dd}  共 {1}例  PACU带管 {2}例  PACU拔管  {3}例  最后一例出室时间 {4:HH:mm}  PACU医师:{5}",
                dateEditQuery.DateTime, DataSource.Rows.Count, rows.Length, outPull, dtMax.AddMinutes(20), doctor);
            gridBand1.Caption = str;
        }

        public DataTable DataSource
        {
            get
            {
                if (gridControlList != null && gridControlList.DataSource != null && gridControlList.DataSource is DataView)
                {
                    return (gridControlList.DataSource as DataView).Table;
                }
                return null;
            }
            set
            {
                if (gridControlList != null)
                {
                    gridControlList.DataSource = value.DefaultView;
                }
            }
        }

        private void OperationProcess_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                dateEditQuery.DateTime = DateTime.Now;
                RefreshDataSource();
            }
        }

        protected void ParentForm_FormClosed(object sender, EventArgs e)
        {
        }

       
        public void ShowFormByDocName(object patientId, object visitId, object operId, string docName, int width, int height)
        {
            ApplicationConfiguration.MedicalDocucementElement document = ApplicationConfiguration.GetMedicalDocument(docName);
            //没有找到退出
            if (string.IsNullOrEmpty(document.Caption))
            {
                return;
            }

            try
            {
                Type t = Type.GetType(document.Type);
                BaseDoc baseDoc = Activator.CreateInstance(t) as BaseDoc;
                
                // 设置指定的患者信息
                if (patientId != null)
                {
                    object[] objs = new object[3];
                    objs[0] = patientId;
                    objs[1] = visitId;
                    objs[2] = operId;
                    baseDoc.SetDocParameters(objs);
                }

                baseDoc.LoadReport(ExtendApplicationContext.Current.AppPath + document.Path);
    
                // 显示窗体
                XtraForm dialogHostForm = new XtraForm();
                dialogHostForm.Text = docName;

                if (width > 0)
                {
                    dialogHostForm.Width = width;
                    dialogHostForm.Height = height;
                }
                else
                {
                    dialogHostForm.MaximizeBox = true;
                    dialogHostForm.MinimizeBox = true;
                    dialogHostForm.ControlBox = true;
                    dialogHostForm.WindowState = FormWindowState.Maximized;
                }

                dialogHostForm.AutoScroll = true;
                dialogHostForm.StartPosition = FormStartPosition.CenterScreen;

                baseDoc.Dock = DockStyle.Fill;
                dialogHostForm.Controls.Add(baseDoc);
                dialogHostForm.ShowDialog();

            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            RefreshDataSource();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //System.Drawing.Printing.PageSettings setting = new System.Drawing.Printing.PageSettings();
            //setting.Landscape = true;
            //DevExpress.XtraPrinting.PrintHelper.SetPageSettings(setting);
            //gridControlList.Print();
            ////DevExpress.XtraPrinting.PrintHelper.ShowPrintDialog(gridControlList);



            DevExpress.XtraPrintingLinks.CompositeLink compositeLink = new DevExpress.XtraPrintingLinks.CompositeLink();
            DevExpress.XtraPrinting.PrintingSystem ps = new DevExpress.XtraPrinting.PrintingSystem();

            compositeLink.PrintingSystem = ps;
            compositeLink.Landscape = true;
            compositeLink.PaperKind = System.Drawing.Printing.PaperKind.A4;

            DevExpress.XtraPrinting.PrintableComponentLink link = new DevExpress.XtraPrinting.PrintableComponentLink(ps);
            ps.PageSettings.Landscape = true;
            link.Component = this.gridControlList;
            compositeLink.Links.Add(link);

            link.CreateDocument();  //建立文档
            ps.PreviewFormEx.Show();//进行预览
        }
    }
}
