using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Wis.Anes
{
    public partial class AboutForm : DevExpress.XtraEditors.XtraForm
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}