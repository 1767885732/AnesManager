using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Wis.Anes.Framework.Utilities;
using Wis.Anes.DataAccess;
using Wis.Anes.Framework.Documents;
using Wis.Anes.Framework.Configurations;

namespace Wis.Anes.Framework.Views
{
    public partial class CommitDocManage : BaseView
    {
        private DataTable emrData = null;
        private CommonDA commonDA = new CommonDA();
        string patientID = ExtendApplicationContext.Current.PatientContext.PatientID;
        decimal visitID = ExtendApplicationContext.Current.PatientContext.VisitID;
        decimal operID = ExtendApplicationContext.Current.PatientContext.OperID;
        private string[] PostPDF_Names = new string[] {"" };
        BaseDoc baseDoc = null;

        public CommitDocManage()
        {
            InitializeComponent();
        }

        private void RefreshInfo()
        {
            string sqlSelect = string.Format("where pat_id='{0}' and visit_id = '{1}' and mr_class = '麻醉' and archive_key = '{2}'", patientID, visitID, operID);
            emrData = commonDA.GetDataWithPrimaryKey("WIS_EMR_ARCHIVE_DETAIL".ToUpper(), sqlSelect);
            gridControl1.DataSource = emrData;
        }

        private void CancelCommitDoc_Load(object sender, EventArgs e)
        {
            RefreshInfo();
            if (!string.IsNullOrEmpty(ApplicationConfiguration.PostPDF_Names))
            {
                PostPDF_Names = ApplicationConfiguration.PostPDF_Names.Split(new char[] { ',' }, StringSplitOptions.None);
            }
        }


        //private void btnCancelCommit_Click(object sender, EventArgs e)
        //{
        //    if (emrData == null || emrData.Rows.Count == 0||gridView1.FocusedRowHandle<0)
        //    {
        //        return;
        //    }
        //    DataRow selectRow = gridView1.GetFocusedDataRow();
        //    if (selectRow != null)
        //    {
        //        if (XtraMessageBox.Show("确定撤销该文书的归档吗？", "提示信息", MessageBoxButtons.YesNo) == DialogResult.Yes)
        //        {
        //            object cancelReason = Dialog.SingleInputSelect("撤销原因：", "");
        //            if (cancelReason != null)
        //            {
        //                if (string.IsNullOrEmpty(cancelReason.ToString().Trim()))
        //                {
        //                    XtraMessageBox.Show("归档原因不能为空");
        //                    return;
        //                }
        //                string patientID = ExtendApplicationContext.Current.PatientContext.PatientID;
        //                decimal visitID = ExtendApplicationContext.Current.PatientContext.VisitID;
        //                decimal operID = ExtendApplicationContext.Current.PatientContext.OperID;
        //                string user = ExtendApplicationContext.Current.LoginUserContext.HisUserID;
        //                if (string.IsNullOrEmpty((new SyncDA()).SyncCancelCommitDoc(patientID, (int)visitID, (int)operID, user, selectRow["EMR_FILE_NAME"].ToString(), cancelReason.ToString().Trim(), "")))
        //                {
        //                    selectRow["ARCHIVE_STATUS"] = "未归档";
        //                    selectRow["emr_owner"] = user;
        //                    selectRow["operator"] = user;
        //                    selectRow["archive_date_time"] = DateTime.Now;
        //                    if (commonDA.UpdateDataTable(emrData) > 0)
        //                    {
        //                        XtraMessageBox.Show("撤销成功");
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        private void btnCommitAll_Click(object sender, EventArgs e)
        {
            string ret="";
            foreach (string doc in PostPDF_Names)
            {
                if (!string.IsNullOrEmpty(doc))
                {
                    ApplicationConfiguration.MedicalDocucementElement document = ApplicationConfiguration.GetMedicalDocument(doc);

                    try
                    {

                        Type t = Type.GetType(document.Type);
                        baseDoc = Activator.CreateInstance(t) as BaseDoc;
                        baseDoc.BackColor = Color.White;
                        baseDoc.Name = doc;
                        baseDoc.HideScrollBar();
                        baseDoc.Initial();
                        baseDoc.LoadReport(ExtendApplicationContext.Current.AppPath + document.Path);
                        if (!string.IsNullOrEmpty(baseDoc.CommitDocNoMess()))
                        {
                            ret += doc + "上传失败\r\n";
                        }
                        else
                        {
                            ret += doc + "上传成功\r\n";
                        }
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandler.Handle(ex);
                    }

                }
            }
            RefreshInfo();
            if (!string.IsNullOrEmpty(ret))
            {
                Dialog.MessageBox(ret);
            }
        }
    }
}
