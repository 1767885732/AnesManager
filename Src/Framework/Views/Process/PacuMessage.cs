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
    public partial class PacuMessage : XtraForm
    {
        public PacuMessage()
        {
            InitializeComponent();
        }

        public void SetContent(string str)
        {
            txtContent.Text = str;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
