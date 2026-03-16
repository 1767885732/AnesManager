using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Wis.Anes.Framework
{
    public partial class DialogHostForm1 : DevExpress.XtraEditors.XtraForm
    {
        public DialogHostForm1()
        {
            InitializeComponent();
        }
        public DialogHostForm1(string caption, int width, int height)
            : this()
        {
            this.Text = caption;
            this.Width = width;
            this.Height = height;
            
        }
        public DialogHostForm1(string caption, bool isMaximized)
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
    }
}