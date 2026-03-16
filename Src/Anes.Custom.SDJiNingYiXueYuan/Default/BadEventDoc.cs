using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Documents;
using Wis.Anes.Framework;
using Wis.Anes.DataAccess;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Custom.CustomProject.Framework;
using Wis.Anes.Framework.Controls;
using Wis.Anes.Framework.Utilities;

namespace Wis.Anes.Custom.CustomProject.Default
{
    public partial class BadEventDoc : CustomBaseDoc
    {
        public BadEventDoc()
        {
            InitializeComponent();
            base.DocKind = Wis.Anes.Framework.DocKind.Default;
            base.ApplyDataTemplate.Visible = false;
            base.SaveDataTemplate.Visible = false;
            base.PrintButton.Visible = true;
            //ParentChanged += new EventHandler(Doc_ParentChanged);
        }

      
        protected override void BuildData(Dictionary<string, DataTable> dataSource)
        {
            dataSource["WIS_ANES_BAD_EVENT"] = DataContext.GetCurrent().GetData("WIS_ANES_BAD_EVENT");
        }

        protected override void OnSaveData(Dictionary<string, DataTable> dataSource)
        {
            CommonDA commonDA = new CommonDA();

            DataTable dt =  dataSource["WIS_ANES_BAD_EVENT"];
            DataRow row = dt.Rows[0];
            if (!row.IsNull("EVENT_TYPE"))
            {
                if (row["EVENT_TYPE"].ToString() != "无不良事件")
                {
                    if (row["EVENT_TYPE"].ToString() != "非重大不良事件" || !row.IsNull("EVENT2"))
                        Dialog.MessageBox("您需要在24小时内将此事件书面上报科室");
                    else if (row["EVENT_TYPE"].ToString() == "非重大不良事件" || !row.IsNull("EVENT3"))
                        Dialog.MessageBox("您需要在24小时内将此事件口头上报科室");

                }
                else
                {
                    row["EVENT1"] = DBNull.Value;
                    row["EVENT2"] = DBNull.Value;
                    row["EVENT3"] = DBNull.Value;
                }
            }


            commonDA.Update(dataSource["WIS_ANES_BAD_EVENT"], "WIS_ANES_BAD_EVENT");
        }

    }
}
