using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Views;
using Wis.Anes.DataAccess;
using Wis.Anes.Framework;
using DevExpress.XtraEditors;
//using DevExpress.XtraGrid.Views.Grid;
//using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Wis.Anes.Custom.CustomProject.Views
{
    public partial class InstrumentsCheck : BaseView
    {
        private AddPackage addPackage = null;
        private PreOperCheck preOperCheck = null;
        private OperAdded operAdded = null;
        private AfterOperCheck afterOperCheck = null;

        public InstrumentsCheck()
        {
            InitializeComponent();
            base.Caption = "器械管理";
        }

        private void InstrumentsCheck_Load(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            addPackage = new AddPackage();
            pnlBody.Controls.Add(addPackage);
            addPackage.Dock = DockStyle.Fill;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnlBody.Controls.Clear();
            addPackage = new AddPackage();
            pnlBody.Controls.Add(addPackage);
            addPackage.Dock = DockStyle.Fill;
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnlBody.Controls.Clear();
            preOperCheck = new PreOperCheck();
            pnlBody.Controls.Add(preOperCheck);
            preOperCheck.Dock = DockStyle.Fill;
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnlBody.Controls.Clear();
            operAdded = new OperAdded();
            pnlBody.Controls.Add(operAdded);
            operAdded.Dock = DockStyle.Fill;
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnlBody.Controls.Clear();
            afterOperCheck = new AfterOperCheck();
            pnlBody.Controls.Add(afterOperCheck);
            afterOperCheck.Dock = DockStyle.Fill;
        }
    }
}
