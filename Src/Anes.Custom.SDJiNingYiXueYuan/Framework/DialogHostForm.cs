using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using Wis.Anes.Framework.Configurations;
using Wis.Anes.Framework;
using Wis.Anes.Framework.Documents;

namespace Wis.Anes.Custom
{
    public partial class DialogHostForm : DevExpress.XtraEditors.XtraForm
    {
        public DialogHostForm()
        {
            InitializeComponent();
        }
        public DialogHostForm(string caption, int width, int height)
            : this()
        {
            this.Text = caption;
            this.Width = width;
            this.Height = height;
            
        }
        public DialogHostForm(string caption, bool isMaximized)
            : this()
        {
            this.Text = caption;
            if (isMaximized)
                this.WindowState = FormWindowState.Maximized;
        }
        public Control Child
        {
            set
            {
                if (value != null)
                {
                    value.Dock = DockStyle.Fill;
                    this.Controls.Add(value);
                }
               
            }
        }

        public static void ShowFormByDocName(string docName, int width, int height)
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
                //baseDoc.BackColor = Color.White;
                baseDoc.LoadReport(ExtendApplicationContext.Current.AppPath + document.Path);
                //baseDoc.Dock = DockStyle.Fill;
                DialogHostForm dialogHostForm = new DialogHostForm(docName, width, height);
                dialogHostForm.Child = baseDoc;
                dialogHostForm.ShowDialog();

            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }

        }
    }
}