using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Wis.Anes.Framework.Views;
using Wis.Anes.Framework.Utilities;
using Wis.Anes.Framework.Documents;

namespace Wis.Anes.Layouts
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
            this.AutoScroll = true;
            
        }
        public DialogHostForm(string caption, bool isMaximized)
            : this()
        {
            this.Text = caption;
            if (isMaximized)
            {
                this.MaximizeBox = true;
                this.MinimizeBox = true;
                this.ControlBox = true;

                this.WindowState = FormWindowState.Maximized;
            
            }

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
        private bool CheckSave()
        {
            if (this.Controls.Count == 1)
            {
                Control control = this.Controls[0];
                if (control is BaseView)
                {
                    BaseView baseControl = control as BaseView;
                    if (baseControl.IsDirty)
                    {
                        DialogResult result = Dialog.MessageBox("输入未保存，现在保存吗?", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        Application.DoEvents();
                        if (result == DialogResult.No)
                        {
                            return true;
                        }
                        else if (result == DialogResult.Cancel)
                        {
                            return false;
                        }
                        else
                        {
                            return baseControl.Save();
                        }
                    }
                }

                if (control is BaseDoc)
                {
                    BaseDoc doc = control as BaseDoc;
                    if (doc != null && doc.HasDirty())
                    {
                        DialogResult dialogResult = XtraMessageBox.Show("您当前的界面有未保存的数据,是否保存此数据?",
                                   "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            if (!doc.ValidateData())
                                return false;
                            else
                            {
                                if (!doc.OnCustomCheckBeforeSave())
                                    return false;
                                doc.Save();
                            }

                        }
                    }
                }
            }
            return true;
        }
        private void DialogHostForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CheckSave())
            {
                e.Cancel = true;
                return;
            }
            if (!CheckError())
            {
                e.Cancel = true;
                return;
            }
          
            //if ( Wis.Anes.Framework.Utilities.Dialog.MessageBox("是否退出系统?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 0) == DialogResult.No)
            //{
            //    e.Cancel = true;
            //}
        }

        private bool CheckError()
        {
            if (this.Controls.Count == 1)
            {
                Control control = this.Controls[0];

                if (control is Wis.Anes.Views.MonitorDataEditor)
                {
                    if (((Wis.Anes.Views.MonitorDataEditor)control).Result != null)
                    {

                        if (((Wis.Anes.Views.MonitorDataEditor)control).Result.ToString() == "None")
                        {
                            return false;
                        }

                    }

                }

                
            }
            return true;
        }
    }
}