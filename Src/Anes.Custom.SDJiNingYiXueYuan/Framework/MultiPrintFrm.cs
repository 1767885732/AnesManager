using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Wis.Anes.Framework.Configurations;
using DevExpress.XtraEditors.Controls;
using Wis.Anes.Framework.Documents;
using Wis.Anes.Framework;
using Wis.Anes.DataAccess;
using System.Collections;
using System.Xml;

namespace Wis.Anes.Custom.CustomProject.Framework
{
    public partial class MultiPrintFrm : DevExpress.XtraEditors.XtraForm
    {
        private List<string> fileList = new List<string>();
        public MultiPrintFrm()
        {
            InitializeComponent();
        }

        private void MultiPrintFrm_Load(object sender, EventArgs e)
        {
            //List<string> fileList = new List<string>();
            //foreach (CheckedListBoxItem boxItem in chkUpFileList.Items)
            //{
            //    if (boxItem.CheckState == CheckState.Checked)
            //    {
            //        fileList.Add(boxItem.Value.ToString());
            //    }
            //}

            if (!string.IsNullOrEmpty(ApplicationConfiguration.multiPrintNames))
            {
                IEnumerator ie = ApplicationConfiguration.multiPrintNames.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).GetEnumerator();
                while (ie.MoveNext())
                {
                    fileList.Add(ie.Current.ToString());
                }
            }


            Dictionary<string, MedicalDocElement> docKeyValuePairs = MedicalDocSettings.GetMedicalDocNameAndPath();

            foreach (KeyValuePair<string, MedicalDocElement> keyValuePair in docKeyValuePairs)
            {
                CheckedListBoxItem boxItemDocCheck = new CheckedListBoxItem(keyValuePair.Key, keyValuePair.Value.Key);
                chkDocCheckList.Items.Add(boxItemDocCheck);
                if (fileList.Contains(keyValuePair.Key))
                {
                    boxItemDocCheck.CheckState = CheckState.Checked;
                }
                if (GetPrintList().Count > 0)
                {
                    if (GetPrintList().Contains(ExtendApplicationContext.Current.PatientContext.PatientID))
                    {
                        label1.Text = "已打印";
                        label1.ForeColor = Color.Red;
                    }
                    else
                    {
                        label1.Text = "";
                    }
                }
               
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("文书是否要集中打印", "集中打印", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            if (!GetPrintList().Contains(ExtendApplicationContext.Current.PatientContext.PatientID))
            {
                mark(fileList);
            }
            //if (fileList.Count > 0)
            //{
            //    string text = "以下是已打印过的文书，是否继续\r\n";
            //    fileList.ForEach(f => text += f + "\r\n");
            //    DialogResult dialog = MessageBox.Show(text, "集中打印", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (dialog != DialogResult.Yes)
            //    {
            //        return;
            //    }
            //}

            foreach (CheckedListBoxItem item in chkDocCheckList.Items)
            {
                if (item.CheckState == CheckState.Checked)
                {
                     ApplicationConfiguration.MedicalDocucementElement document = ApplicationConfiguration.GetMedicalDocument(item.Value.ToString());

                    //没有找到退出
                    if (string.IsNullOrEmpty(document.Caption))
                    {
                        DialogResult dialogResult = XtraMessageBox.Show(string.Format("无法加载文书'{0}'的设计模版,请确保模版文件已经存在", item.Value.ToString()),
                                "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        continue;
                    }

                    try
                    {

                        Type t = Type.GetType(document.Type);
                        CustomBaseDoc baseDoc = Activator.CreateInstance(t) as CustomBaseDoc;
                        baseDoc.BackColor = Color.White;
                        baseDoc.Name = item.Value.ToString();
                        baseDoc.HideScrollBar();
                        baseDoc.Initial();
                        baseDoc.LoadReport(ExtendApplicationContext.Current.AppPath + document.Path);
                        baseDoc.PrintBaseDoc();

                        List<string> fileList = new List<string>();
                        foreach (CheckedListBoxItem boxItem in chkDocCheckList.Items)
                        {
                            if (boxItem.CheckState == CheckState.Checked)
                            {
                                fileList.Add(boxItem.Value.ToString());
                            }
                        }
                        ApplicationConfiguration.multiPrintNames = string.Join(",", fileList.ToArray());

                        (new ConfigurationDA()).UpdateConfigTableDataTable(ExtendApplicationContext.Current.ConfigTable);
                    }
                    catch
                    {

                    }
                }
            }

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mark(List<string> fileList)
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory + "printMark.xml";
 
            //创建文件格式对象
            XmlTextWriter xml = new XmlTextWriter(path, System.Text.Encoding.UTF8);
            xml.WriteStartDocument();//调用WriteStartDocument()方法来开始写入XML文档
            xml.WriteStartElement("print");
            xml.WriteElementString("printid",ExtendApplicationContext.Current.PatientContext.PatientID); //写根节点
            foreach (var item in fileList)
            {
                xml.WriteElementString("prtDoc", item);
            }
            xml.WriteEndElement();//关闭根节点
            xml.Flush();//刷新流
            xml.Close();//关闭流
        }

        private static string GetApplicationPath()
        {
            string path = Application.StartupPath;
            string folderName = String.Empty;
            while (folderName.ToLower() != "bin")
            {
                path = path.Substring(0, path.LastIndexOf("\\"));
                folderName = path.Substring(path.LastIndexOf("\\") + 1);
            }
            return path.Substring(0, path.LastIndexOf("\\") + 1);
        }

        private List<string> GetPrintList()
        {
            List<string> vs = new List<string>();
            string path = System.AppDomain.CurrentDomain.BaseDirectory + "printMark.xml";
            XmlTextReader xml = new XmlTextReader(path);//调用路径
            while (xml.Read())
            {
                if (xml.NodeType == XmlNodeType.Element)
                {
                    if (xml.Name == "printid")
                        vs.Add(xml.ReadElementString());
                }
            }
            xml.Close();//关闭流
            return vs;
        }
    }
}