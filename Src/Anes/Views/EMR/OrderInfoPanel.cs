using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Views;
using Wis.Anes.BusinessEntity;
using Wis.Anes.ServiceProxies;
using Wis.Anes.Constants;
using Wis.Anes.Framework;

namespace Wis.Anes.Views
{
    [ToolboxItem(false)]
    public partial class OrderInfoPanel : BaseView
    {
        protected string  _patientId = "";
        protected decimal _visitId = 0;
        protected System.Data.DataTable _datatable;
        public OrderInfoPanel()
        {
            _patientId = ExtendApplicationContext.Current.PatientContext.PatientID;
            _visitId = ExtendApplicationContext.Current.PatientContext.VisitID;
            InitializeComponent();
            Caption = ViewNames.HisOrderInfo;
        }


        public OrderInfoPanel(string patientId, decimal visitId)
        {
            _patientId = patientId;
            _visitId = visitId;
            InitializeComponent();
            Caption = ViewNames.HisOrderInfo;
        }

        private void OrderInfoPanel_Load(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show("医嘱调用");
                string ret = SyncProxy.SyncOrderInfo(_patientId, (int)_visitId);
                //MessageBox.Show("调用结果：" + ret);
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
            List<LookUpEditItem> data1 = new List<LookUpEditItem>();
            data1.Add(new LookUpEditItem("临时", 0M));
            data1.Add(new LookUpEditItem("长期", 1M));
            repositoryItemLookUpEdit1.DataSource = data1;
            _datatable = SyncProxy.GetOrders(_patientId, _visitId);

            
            radioGroup1.SelectedIndex = 0;
            radioGroup2.SelectedIndex = 0;
            _datatable.DefaultView.RowFilter = "";

            gridControl1.DataSource = _datatable.DefaultView;
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filter = "";
            switch (radioGroup1.SelectedIndex)
            {
                case 0:
                    filter = "";
                    break;
                case 1:
                    filter = "REPEAT_INDICATOR = 0";
                    break;
                case 2:
                    filter = "REPEAT_INDICATOR = 1";
                    break;
            }


            if(radioGroup2.SelectedIndex > 0)
            {
                string curFilter = string.Format("Order_Status = '{0}'", radioGroup2.SelectedIndex);
                filter = string.IsNullOrEmpty(filter) ? curFilter : filter + " and " + curFilter;
            }

            _datatable.DefaultView.RowFilter = filter;
        }
    }
}
