using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Views;
using System.Drawing.Printing;
using Wis.Anes.Custom.CustomProject.Framework;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.Framework.Utilities;
using DevExpress.XtraEditors;

namespace Wis.Anes.Custom.CustomProject.Views
{
    public partial class PatientBarCodePrinter : BaseView
    {
        public PatientBarCodePrinter()
        {
            InitializeComponent();
        }
        


        private void txtPrintFont_DoubleClick(object sender, EventArgs e)
        {
            SetFont(sender, e);
        }

        private void txtBarCodeFont_DoubleClick(object sender, EventArgs e)
        {
            SetFont(sender, e);
        }

        private void SetFont(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
           fontDialog.Font = textBox.Font  ;
            if (DialogResult.OK == fontDialog.ShowDialog())
            {
                textBox.Font= fontDialog.Font ;
                
            }
        }




        DataTable patientListDataTable = null ;
        //计算总页数
        int pageCount = 1 ;
        //每页打印患者数
        int printCountPerPage = 8;
        //单个患者每行打印个数
        int printCountEveryPatient = 2;
        //条码类
        Code39 code39 = null;

        private void btnPrint_Click(object sender, EventArgs e)
        {
            patientListDataTable = GetPatientList();
            //每页打印患者数
            printCountPerPage = 8;
            if (!int.TryParse(txtPrintCountPerPage.Text, out printCountPerPage))
            {
                printCountPerPage = 8;
            }


            //单个患者每行打印个数
            printCountEveryPatient = 2;
            if (!int.TryParse(txtPrintCountEveryPatient.Text, out printCountEveryPatient))
            {
                printCountEveryPatient = 2;
            }

            //总页数
            if (patientListDataTable.Rows.Count % printCountPerPage == 0)
            {
                pageCount = patientListDataTable.Rows.Count / printCountPerPage ;
            }
            else
            {
                pageCount = patientListDataTable.Rows.Count / printCountPerPage + 1;
            }
            
            code39 = new Code39();

            code39.Height = 40;
            code39.Magnify = 1;
            code39.ViewFont = txtBarCodeFont.Font;



            Print();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ((Form)this.Parent).Close();
        }


        public bool Print()
        {

            try
            {
                PrintDocument doc = new PrintDocument();
                doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);


                PageSetupDialog pageSetupDialog = new PageSetupDialog();

                //string _pageName = ApplicationConfiguration.PrintPageName;
                //if (!string.IsNullOrEmpty(_pageName))
                //{
                //    foreach (PaperSize ps in doc.PrinterSettings.PaperSizes)
                //    {
                //        if (ps.PaperName.ToLower().Equals(_pageName.ToLower()))
                //        {

                //            doc.PrinterSettings.DefaultPageSettings.PaperSize = ps;
                //            doc.DefaultPageSettings.PaperSize = ps;
                //            break;
                //        }
                //    }
                //}
                //else
                //{
                //    float paperWidth = CustomBaseDoc.PaperWidth / 2.54f * 100.0f;
                //    float paperHeight = CustomBaseDoc.PaperHeight / 2.54f * 100.0f;
                //    PaperSize ps = new System.Drawing.Printing.PaperSize(ApplicationConfiguration.PrintPageName, (int)paperWidth, (int)paperHeight);
                //    doc.PrinterSettings.DefaultPageSettings.PaperSize = ps;
                //    doc.DefaultPageSettings.PaperSize = ps;
                //}
                float paperWidth = CustomBaseDoc.PaperWidth / 2.54f * 100.0f;
                float paperHeight = CustomBaseDoc.PaperHeight / 2.54f * 100.0f;
                PaperSize ps = new System.Drawing.Printing.PaperSize(ApplicationConfiguration.PrintPageName, (int)paperWidth, (int)paperHeight);
                doc.PrinterSettings.DefaultPageSettings.PaperSize = ps;
                doc.DefaultPageSettings.PaperSize = ps;
                doc.DefaultPageSettings.Margins = new Margins(20, 20, 20, 20);

                PrintPreviewDialog preview = new PrintPreviewDialog();
                preview.WindowState = FormWindowState.Maximized;
                preview.Document = doc;
                preview.ShowDialog();





              
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
        }

        void doc_PrintPage(object sender, PrintPageEventArgs e)
        {

            // 纸张大小

            DoPrint(e);

            //Bitmap bit = new Bitmap(this.Width, this.Height);
            //this.tableLayoutPanel1.DrawToBitmap(bit, new Rectangle(0, 0, this.Width, this.Height));         //*********
            //e.Graphics.DrawImage(bit, 0, 0);
            //bit.Dispose();
        }

        private int currentPageIndex = 0;
        private void DoPrint(PrintPageEventArgs e)
        {

            Bitmap pageBitmap = new Bitmap(e.MarginBounds.Width, e.MarginBounds.Height);
            Graphics g = Graphics.FromImage(pageBitmap);



            int heightPerPatient = e.MarginBounds.Height / printCountPerPage;
            int weightPerPatient = e.MarginBounds.Width  / printCountEveryPatient;


            using (g)
            {
                PrintContext printContext = new PrintContext();
                List<PrintContext> printContextListPerPage = GetPrintContextListPerPage(currentPageIndex);
                currentPageIndex++;

                    for (int i = 0; i < printContextListPerPage.Count; i++)
                    {
                        //获取当前最新的
                        printContext = printContextListPerPage[i];
                        for (int j = 0; j < printCountEveryPatient; j++)
                        {


                            Bitmap bp = GetPatientCodeBarImage(printContext.BedNo, printContext.Name, printContext.Sex, printContext.Age, printContext.OperationRoom, printContext.Sex, printContext.ID, heightPerPatient, weightPerPatient, code39);
                            int bpLeft = weightPerPatient * j +e.MarginBounds.X;
                            int bpTop = heightPerPatient * i + e.MarginBounds.Y; ;
                            g.DrawImage(bp, bpLeft, bpTop);
                            bp.Dispose();
                        }

                    }
                    e.Graphics.DrawImage(pageBitmap, new RectangleF(e.MarginBounds.Left, e.MarginBounds.Top, (float)e.MarginBounds.Width, (float)e.MarginBounds.Height));
                    
                //下一页
                    if (currentPageIndex < pageCount )
                    {
                        e.HasMorePages = true;
                    }
                    else
                    {
                        currentPageIndex = 0;
                    }
                

                
            }
         
        }

        private List<PrintContext> GetPrintContextListPerPage(int currentPageIndex)
        {
            List<PrintContext> printContextList = new List<PrintContext>();
            DataRow row = null;
            for (int i = 0 ; i <printCountPerPage; i++)
            {
                if (currentPageIndex * printCountPerPage + i >= patientListDataTable.Rows.Count)
                {
                    break;
                }
                PrintContext printContext = new PrintContext();
                row = patientListDataTable.Rows[currentPageIndex * printCountPerPage+i];
                printContext.Name = row["Name"] != null ? row["Name"].ToString() : "";
                printContext.BedNo = row["BedNo"] != null ? row["BedNo"].ToString() : "";
                printContext.Sex = row["Sex"] != null ? row["Sex"].ToString() : "";
                printContext.Age = row["Age"] != null ? row["Age"].ToString() : "";
                printContext.OperationRoom = row["OperationRoom"] != null ? row["OperationRoom"].ToString() : "";
                printContext.Seq = row["Seq"] != null ? row["Seq"].ToString() : "";
                printContext.ID = row["ID"] != null ? row["ID"].ToString() : "";
                printContextList.Add(printContext);
            }

            return printContextList;
        }


        private Bitmap GetPatientCodeBarImage(string bedNo, string name, string sex, string age, string operationRoom, string seq, string ID, int heightPerPatient, int weightPerPatient, Code39 code39)
        {
            
            string printText1 = "床号：" + bedNo ;
            string printText2 = "姓名：" + name + " 性别：" + sex + " 年龄：" + age;
            string printText3 = "手术间：" + operationRoom + "  台次：" + seq;
            string printText4 = ID;

            Bitmap bpRes = new Bitmap((int)weightPerPatient, (int)heightPerPatient);
            
            Graphics g = Graphics.FromImage(bpRes);
            SizeF printTextSizeF = g.MeasureString(printText1, txtPrintFont.Font);
            using (g)
            {
                Brush brush = Brushes.Black;
                g.DrawString(printText1, txtPrintFont.Font, brush, 0.0f, 0.0f);
                g.DrawString(printText2, txtPrintFont.Font, brush, 0.0f, printTextSizeF.Height + 5);
                g.DrawString(printText3, txtPrintFont.Font, brush, 0.0f, (printTextSizeF.Height + 5) * 2);

                Bitmap bp = code39.GetCodeImage(printText4, Code39.Code39Model.Code39Normal, true);
                g.DrawImage(bp, 0, (printTextSizeF.Height + 5) * 3);
                bp.Dispose();
                //brush.Dispose();
            }

            return bpRes;

        }

        private DataTable GetPatientList()
        {

            //测试数据
            DataTable dt = new DataTable();
            dt.Columns.Add("BedNo", Type.GetType("System.String"));
            dt.Columns.Add("Name", Type.GetType("System.String"));
            dt.Columns.Add("Sex", Type.GetType("System.String"));
            dt.Columns.Add("Age", Type.GetType("System.String"));
            dt.Columns.Add("OperationRoom", Type.GetType("System.String"));
            dt.Columns.Add("Seq", Type.GetType("System.String"));
            dt.Columns.Add("ID", Type.GetType("System.String"));

            dt.Rows.Add(new object[] { "10", "张三", "男", "12岁", "东1", "1", "MZ490564" });
            dt.Rows.Add(new object[] { "11", "王三", "男", "11岁", "东2", "2", "MZ596564" });
            dt.Rows.Add(new object[] { "12", "里三", "男", "13岁", "东1", "3", "MZ498564" });
            dt.Rows.Add(new object[] { "13", "黑三", "男", "52岁", "东2", "1", "MZ493564" });
            dt.Rows.Add(new object[] { "14", "白三", "男", "42岁", "东1", "2", "MZ624564" });
            dt.Rows.Add(new object[] { "15", "黄三", "男", "52岁", "东1", "3", "MZ490564" });
            dt.Rows.Add(new object[] { "16", "鹂三", "男", "62岁", "东1", "2", "MZ590564" });
            dt.Rows.Add(new object[] { "17", "器三", "男", "22岁", "东1", "1", "MZ592534" });
            return dt;

        }
    }


    class PrintContext
    {
        public string BedNo = "";
        public string Name = "";
        public string Sex = "";
        public string Age = "";
        public string OperationRoom = "";
        public string Seq = "";
        public string ID = "";

    }
}
