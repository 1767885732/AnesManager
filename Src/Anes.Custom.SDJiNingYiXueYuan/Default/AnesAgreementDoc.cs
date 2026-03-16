using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Documents;
using Wis.Anes.DataAccess;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework;
using Wis.Anes.Custom.CustomProject.Framework;

namespace Wis.Anes.Custom.CustomProject.Default
{
    /// <summary>
    /// 麻醉同意书
    /// </summary>
    public partial class AnesAgreementDoc : CustomBaseDoc
    {
        public AnesAgreementDoc()
        {
            _pageFromHeight = true;
            InitializeComponent();
            base.DocKind = DocKind.Default;
            base.ApplyDataTemplate.Visible = false ;
            base.SaveDataTemplate.Visible = false;
        }
        protected override void BuildData(Dictionary<string, DataTable> dataSource)
        {
            dataSource["WIS_OPER_MASTER"] = DataContext.GetCurrent().GetData("WIS_OPER_MASTER");
            dataSource["WIS_PAT_IN_HOS"] = DataContext.GetCurrent().GetData("WIS_PAT_IN_HOS");
            dataSource["WIS_CUSTOM_DATA"] = DataContext.GetCurrent().GetData("WIS_CUSTOM_DATA");
            dataSource["WIS_OPER_SCHEDULE"] = DataContext.GetCurrent().GetData("WIS_OPER_SCHEDULE");
            dataSource["WIS_PAT_VISIT"] = DataContext.GetCurrent().GetData("WIS_PAT_VISIT");
            dataSource["WIS_PAT_MASTER_INDEX"] = DataContext.GetCurrent().GetData("WIS_PAT_MASTER_INDEX");
            dataSource["WIS_ANES_PLAN"] = DataContext.GetCurrent().GetData("WIS_ANES_PLAN");
        }

        protected override void OnSaveData(Dictionary<string, DataTable> dataSource)
        {
            base.OnSaveData(dataSource);
            CommonDA commonDA = new CommonDA();
            commonDA.Update(dataSource["WIS_OPER_MASTER"], "WIS_OPER_MASTER");
            commonDA.Update(dataSource["WIS_CUSTOM_DATA"], "WIS_CUSTOM_DATA");
            commonDA.Update(dataSource["WIS_OPER_SCHEDULE"], "WIS_OPER_SCHEDULE");
            commonDA.Update(dataSource["WIS_PAT_VISIT"], "WIS_PAT_VISIT");
            commonDA.Update(dataSource["WIS_PAT_MASTER_INDEX"], "WIS_PAT_MASTER_INDEX");
            commonDA.Update(dataSource["WIS_ANES_PLAN"], "WIS_ANES_PLAN");
        }
        
        
    }
}
