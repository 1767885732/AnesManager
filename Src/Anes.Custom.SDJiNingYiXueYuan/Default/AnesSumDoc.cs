using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Custom.CustomProject.Framework;
using Wis.Anes.Framework.Doc;
using Wis.Anes.Framework;
using Wis.Anes.Custom.CustomProject.AnesDocHandlers;
using Wis.Anes.DataAccess;
using Wis.Anes.Framework.Documents.DefaultHandlers;

namespace Wis.Anes.Custom.CustomProject.Default
{
    public partial class AnesSumDoc : CustomBaseDoc
    {
        public AnesSumDoc()
        {
            InitializeComponent();
            base.DocKind = DocKind.Default;
            base.ApplyDataTemplate.Visible = true;
            base.SaveDataTemplate.Visible = false;
        }

        /// <summary>
        /// 初始化自定义的UIElementHandler
        /// </summary>
        /// <param name="handlers"></param>
        protected override void AddCustomUIElementHandlers(List<IUIElementHandler> handlers)
        {
            IUIElementHandler handlerTemp = null;
            foreach (IUIElementHandler handler in handlers)
            {
                if (handler is LabelHandler)
                {
                    handlerTemp = handler;
                    break;
                }
            }
            if (handlerTemp != null)
            {
                handlers.Remove(handlerTemp);
            }

            handlerTemp = null;
            foreach (IUIElementHandler handler in handlers)
            {
                if (handler is TextBoxHandler)
                {
                    handlerTemp = handler;
                    break;
                }
            }
            if (handlerTemp != null)
            {
                handlers.Remove(handlerTemp);
            }
            handlers.Add(new CustomTextBoxHandler());
        }

        protected override void BuildData(Dictionary<string, DataTable> dataSource)
        {
            dataSource["WIS_OPER_MASTER"] = DataContext.GetCurrent().GetData("WIS_OPER_MASTER");
            dataSource["WIS_PAT_IN_HOS"] = DataContext.GetCurrent().GetData("WIS_PAT_IN_HOS");
            dataSource["WIS_CUSTOM_DATA"] = DataContext.GetCurrent().GetData("WIS_CUSTOM_DATA");
            dataSource["WIS_OPER_SCHEDULE"] = DataContext.GetCurrent().GetData("WIS_OPER_SCHEDULE");
            dataSource["WIS_PAT_VISIT"] = DataContext.GetCurrent().GetData("WIS_PAT_VISIT");
            dataSource["WIS_PAT_MASTER_INDEX"] = DataContext.GetCurrent().GetData("WIS_PAT_MASTER_INDEX");
            dataSource["WIS_ANES_SUMMARY"] = DataContext.GetCurrent().GetData("WIS_ANES_SUMMARY");
            dataSource["WIS_ANES_PLAN"] = DataContext.GetCurrent().GetData("WIS_ANES_PLAN");
            dataSource["AnesAllEvent"] = DataContext.GetCurrent().GetAnesthesiaEvent();
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
            commonDA.Update(dataSource["WIS_ANES_SUMMARY"], "WIS_ANES_SUMMARY");
            commonDA.Update(dataSource["WIS_ANES_PLAN"], "WIS_ANES_PLAN");
        }
    }
}
