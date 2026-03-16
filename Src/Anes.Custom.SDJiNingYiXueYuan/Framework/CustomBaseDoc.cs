using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Documents;
using Wis.Anes.Framework;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using Wis.Anes.DataAccess;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.Framework.Controls;
using Wis.Anes.Framework.Utilities;
using System.IO;

namespace Wis.Anes.Custom.CustomProject.Framework
{
    public partial class CustomBaseDoc : BaseDoc
    {
        //public static float PaperWidth = 19.5f;
        //public static float PaperHeight = 27f;



        //public static float PaperWidth = 21.0f;
        //public static float PaperHeight = 29.7f;
        public static float PaperWidth = ApplicationConfiguration.PrintPaperWidth;
        public static float PaperHeight = ApplicationConfiguration.PrintPaperHeight;
        public static float PaperLeftOff = ApplicationConfiguration.PaperLeftOff;
        public static float PaperTopOff = ApplicationConfiguration.PaperTopOff;
        [DllImport("EMRFSRVS.dll")]
        protected static extern int putfile(string host_addr, string local_file, string remote_file, int Protocol, int option);


        protected bool _needPostPDFWhenPrint = true;  // 是否要上传PDF


        // 是否要进行文书质控
        protected bool _needCheckWhenPrint = false;  


        public CustomBaseDoc()
        {
            //int width = (int)(PaperWidth / 2.54 * 100 + 0.5);
            //int height = (int)(PaperHeight / 2.54 * 100 + 0.5);
            //_paperSize = new System.Drawing.Printing.PaperSize("16K", width, height);
            int width = (int)(PaperWidth / 2.54 * 100 + 0.5);
            int height = (int)(PaperHeight / 2.54 * 100 + 0.5);
            _paperSize = new System.Drawing.Printing.PaperSize(ApplicationConfiguration.PrintPageName, width, height);
            btnMultiPrint.Visible = true;
        }


        public override void Initial()
        {
            base.Initial();
            if (CustomSetting.CustomSetting.PostPDF_Names != null)
            {
                foreach (string postname in CustomSetting.CustomSetting.PostPDF_Names)
                {
                    if (postname == Name)
                    {
                        _needPostPDFWhenPrint = true;
                        break;
                    }
                }
            }

            if (CustomSetting.CustomSetting.DocNameCheckList != null)
            {
                foreach (string docName in CustomSetting.CustomSetting.DocNameCheckList)
                {
                    if (docName == Name)
                    {
                        _needCheckWhenPrint = true;
                        break;
                    }
                }
            }
        }

        //生成PDF文件名
        protected string GeneratePDFFileName(ref int times)
        {
            // 获取病人ID
            string patientID = ExtendApplicationContext.Current.PatientContext.PatientID;
            decimal visitID = ExtendApplicationContext.Current.PatientContext.VisitID;
            decimal operID = (ExtendApplicationContext.Current.PatientContext.OperID);


            // 获取次数并更新
            DataTable dtData = DataContext.GetCurrent().GetData("WIS_CUSTOM_DATA");
            DataRow[] rows = dtData.Select("ITEM_NAME = '" + Name + ".PDF" + "'");


            if (rows.Length > 0)
            {
                times = Convert.ToInt32(rows[0]["ITEM_VALUE"]);
                times++;
                rows[0]["ITEM_VALUE"] = times;
            }
            else
            {
                DataRow row = dtData.NewRow();
                row["PAT_ID"] = patientID;
                row["Visit_ID"] = visitID;
                row["Oper_ID"] = operID;
                row["ITEM_NAME"] = Name + ".PDF";
                row["ITEM_VALUE"] = times;
                dtData.Rows.Add(row);
            }

            CommonDA commonDA = new CommonDA();
            commonDA.Update(dtData, "WIS_CUSTOM_DATA");

            //生成名称 patient_id + visit_id + 麻醉 + 文书名称 + oper_id + 次数
            string filename = patientID.ToString() + "_" + visitID.ToString() + "_麻醉_" + Name + "_" + operID.ToString() + "_" + times.ToString();
            return filename + ".pdf";

        }

        // 将PDF文件上传
        protected string PostPDF(string filename, int times)
        {
            string ret = "";
            int result = putfile(CustomSetting.CustomSetting.PostPDF_ServerURL, CustomSetting.CustomSetting.PostPDF_LocalURL + filename, filename, 1, 1);
            if (result == 0)
            {
                string path = ExtendApplicationContext.Current.PatientContext.PatientID.Substring(ExtendApplicationContext.Current.PatientContext.PatientID.Length - 3, 3) +
                     "\\" + ExtendApplicationContext.Current.PatientContext.PatientID.Substring(0, ExtendApplicationContext.Current.PatientContext.PatientID.Length - 3) +
                     "\\" + ExtendApplicationContext.Current.PatientContext.VisitID + "\\";
                DataContext.GetCurrent().InsertEmrArchiveRecord(Name, times, filename, path);
            }
            else ret = "上传失败！";

            if (ApplicationConfiguration.IsDeleteAfterCommitDoc)
            {
                if (File.Exists(CustomSetting.CustomSetting.PostPDF_LocalURL + filename))
                {
                    File.Delete(CustomSetting.CustomSetting.PostPDF_LocalURL + filename);
                }
            }
            return ret;
        }




        protected override void Print()
        {
            CustomPrinter printer = new CustomPrinter(this, _paperSize, _pageFromHeight, _pagePrintHeight, _pageName);
            if (_needPostPDFWhenPrint)
                printer.EndPrint += new PrintEventHandler(printer_EndPrint);
            //printer.Print();
            printer.Print(true);

        }



         // 将PDF文件上传
        protected void UpdateAnesDocCheckRecord(string docName)
        {
            DataContext.GetCurrent().UpdateAnesDocCheckRecord(  DataContext.GetCurrent().GetAnesDocCheckRecord(docName));
        }


        protected override bool CheckBeforePrint()
        {
            List<MTextBox> boxs = GetControls<MTextBox>();
            foreach (MTextBox textbox in boxs)
            {
                if (!string.IsNullOrEmpty(textbox.WantValueBeforePrint) && string.IsNullOrEmpty(textbox.Text.Trim()))
                {
                    Dialog.MessageBox(textbox.WantValueBeforePrint);
                    return false;
                }
            }


            List<MRichTextBox> boxs2 = GetControls<MRichTextBox>();
            foreach (MRichTextBox textbox in boxs2)
            {
                if (!string.IsNullOrEmpty(textbox.WantValueBeforePrint) && string.IsNullOrEmpty(textbox.Text.Trim()))
                {
                    Dialog.MessageBox(textbox.WantValueBeforePrint);
                    return false;
                }
            }

            return true;
        }

        // 结束打印事件， 生成PDF并上传
        void printer_EndPrint(object sender, PrintEventArgs e)
        {
            if (e.PrintAction == PrintAction.PrintToPrinter)
            {
                bool allPage = PagerSetting.AllowPage;
                PagerSetting.AllowPage = true;
                try
                {


                    if (ExtendApplicationContext.Current.CustomSettingContext.IsCheckDocCompelete)
                    {
                        //保存记录
                        UpdateAnesDocCheckRecord(Name);
                    }



                    int times = 1;
                    string fileName = GeneratePDFFileName(ref times);
                    ExportPDF(CustomSetting.CustomSetting.PostPDF_LocalURL + fileName);
                    PostPDF(fileName, times);
                }
                catch (Exception ex)
                {
                    ExceptionHandler.Handle(ex);
                }
                finally
                {
                    PagerSetting.AllowPage = allPage;
                }
            }
        }

        protected override void MultiPrint()
        {
            base.MultiPrint();
            MultiPrintFrm multiPrintFrm1 = new MultiPrintFrm();
            multiPrintFrm1.Show();
        }

        protected override string CommitDoc2()
        {
            string rett = "";
            if (ExtendApplicationContext.Current.CustomSettingContext.IsCheckDocCompelete)
            {
                //保存记录
                UpdateAnesDocCheckRecord(Name);
            }
            try
            {
                int times = 1;
                string fileName = GeneratePDFFileName(ref times);
                ExportPDF(CustomSetting.CustomSetting.PostPDF_LocalURL + fileName);
                rett = PostPDF(fileName, times);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rett;
        }

        /// <summary>
        /// 数据保存
        /// </summary>
        /// <param name="dataSource"></param>
        protected override void OnSaveData(Dictionary<string, DataTable> dataSource)
        {
            base.OnSaveData(dataSource);
            DataContext.GetCurrent().RefreshDataSource(dataSource);
        }
    }
}
