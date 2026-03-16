using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Documents;
using Wis.Anes.Framework.Controls.Base;
using DevExpress.XtraCharts;
using Wis.Anes.Framework;
using Score;

namespace Wis.Anes.CostomDoc
{
    public partial class CustomAssessmentBase : BaseControl
    {
        public BaseDoc baseDoc;
        Series _scoreSeries { get { return chartControl1.GetSeriesByName("Series 1"); } }
        public CustomAssessmentBase(DataRow patientRow) : this(patientRow, "评估单多次评估") { }

        public CustomAssessmentBase(DataRow patientRow, string title)
            : base(patientRow, title)
        {
            InitializeComponent();
            _scoreSeries.ValueDataMembersSerializable = "SCORING_VALUE";
            _scoreSeries.ArgumentDataMember = "ENTER_DATE_TIME";
        }

        protected override void LoadDataOnce()
        {
            splitContainerControl1.Panel2.Text = string.IsNullOrEmpty(this.Parent.Text) ? this.Name : this.Parent.Text;
            //baseDoc = new BaseDoc(PatientRow, "");
            baseDoc = new BaseDoc();
            baseDoc.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            baseDoc.Appearance.Options.UseFont = true;
            baseDoc.AutoScroll = true;
            baseDoc.Caption = "";
            baseDoc.Cursor = System.Windows.Forms.Cursors.Default;
            baseDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            baseDoc.DocKind = DocKind.Default;
            baseDoc.IsFirstLoading = true;
            baseDoc.Location = new System.Drawing.Point(0, 0);
            baseDoc.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            baseDoc.Name = "baseDoc";
            baseDoc.PageWidth = 0;
            //baseDoc.RecTime = new System.DateTime(((long)(0)));
            baseDoc.Size = new System.Drawing.Size(1118, 406);
            baseDoc.TabIndex = 0;
            baseDoc.Tag = this.Tag;
            //baseDoc.BtnAddVivible = true;
            //baseDoc.refreshEvent += new Com.ICIS.Icu.Designer.BaseDoc.EventRefreshEventHandler(baseDoc_refreshEvent);
            splitContainerControl1.Panel2.Controls.Add(this.baseDoc);
        }

        private string _rec = "";

        private void baseDoc_refreshEvent(DateTime recTime)
        {
            int focusHandler = 0;
            DataRow drFocused = gridView1.GetFocusedDataRow();
            if (drFocused != null)
            {
                focusHandler = gridView1.FocusedRowHandle;
                //if (drFocused["SCORING_DATE_TIME"].ToString() != recTime.ToString())
                //{
                RefreshData();
                //}
            }
            gridView1.FocusedRowHandle = focusHandler;
        }

        protected override void LoadData()
        {
            RefreshData();
        }

        private void RefreshData()
        {
            baseDoc.PatientRow = PatientRow;
            baseDoc.ReLoad();
            gridControl1.DataSource = baseDoc.DataSource["WIS_PAT_SCORING_RESULT"];
            _scoreSeries.DataSource = baseDoc.DataSource["WIS_PAT_SCORING_RESULT"];
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow drFocused = gridView1.GetFocusedDataRow();
            if (drFocused != null)
            {
                //if (drFocused["SCORING_DATE_TIME"].ToString() != baseDoc.RecTime.ToString())
                //{
                //    baseDoc.RecTime = DateTime.Parse(drFocused["SCORING_DATE_TIME"].ToString());
                //    baseDoc.RefreshData();
                //}

            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            DataRow drFocused = gridView1.GetFocusedDataRow();
            if (drFocused != null)
            {
                if (Sundries.MessageBox("确定要删除该条评分吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, 0) == DialogResult.Yes)
                {
                    //if (DataOperator.DeleteScoreAndAssessmentResult(drFocused["PAT_ID"].ToString(), int.Parse(drFocused["VISIT_ID"].ToString()), int.Parse(drFocused["DEP_ID"].ToString()), drFocused["SCORING_METHOD"].ToString(), DateTime.Parse(drFocused["SCORING_DATE_TIME"].ToString())) > 0)
                    //{
                    //    RefreshData();
                    //}
                }
            }
        }
    }
}
