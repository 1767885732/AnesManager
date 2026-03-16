using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Views;
using Wis.Anes.BusinessEntity;
using Wis.Anes.ServiceProxies;
using DevExpress.XtraEditors;

namespace Wis.Anes.Views
{
    public partial class DocumentsSelect : XtraForm
    {
        public DocumentsSelect()
        {
            InitializeComponent();
            //if (!DesignMode && System.IO.File.Exists(@"c:\mrtemp.doc"))
            //{
            //    axEPRReader1.OnFileOpen(@"c:\mrtemp.doc", 0, 1);
            //}
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
        }

    }
}