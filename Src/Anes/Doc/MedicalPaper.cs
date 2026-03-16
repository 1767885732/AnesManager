using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Wis.Anes.Framework.Views;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.Framework.Documents;
using Wis.Anes.Framework;


namespace Wis.Anes.Papers
{
    public partial class MedicalPaper : BaseView
    {
        public MedicalPaper()
        {
            InitializeComponent();
            this.Caption = "医疗文书";
        }

        private void MedicalPaper_Load(object sender, EventArgs e)
        {
            Initalization();
        }
        /// <summary>
        /// 界面初始化
        /// </summary>
        private void Initalization()
        {
            Dictionary<string, MedicalDocElement> docs = MedicalDocSettings.GetMedicalDocNameAndPath();
            foreach (KeyValuePair<string, MedicalDocElement> keyValuePair in docs)
            {
                Type t = Type.GetType(keyValuePair.Value.Type);
                BaseDoc baseDoc = Activator.CreateInstance(t) as BaseDoc;
                this.xtraScrollableControl1.Controls.Add(baseDoc);

                baseDoc.LoadReport(ExtendApplicationContext.Current.AppPath + keyValuePair.Value.Path);
                break;
            }
        }

       
    }
}
