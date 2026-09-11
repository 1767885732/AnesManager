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
using Wis.Anes.Framework.Doc;
using Wis.Anes.Framework.Controls;

namespace Wis.Anes.Custom.CustomProject.Default
{
    public partial class DefaultDoc : CustomBaseDoc
    {
        private DateTime _operTime;
        private string _anesMethod;
        public DefaultDoc()
        {
            InitializeComponent();
            base.DocKind = DocKind.Default;
            base.ApplyDataTemplate.Visible = true;
            base.SaveDataTemplate.Visible = false;
        }

        protected override void BuildData(Dictionary<string, DataTable> dataSource)
        {
            var operationMaster = DataContext.GetCurrent().GetData("WIS_OPER_MASTER") as AnesInformations.OperationMasterDataTable;
            _operTime = operationMaster[0].SCHEDULED_DATE_TIME;
            _anesMethod = operationMaster[0].ANES_METHOD;

            dataSource["WIS_OPER_MASTER"] = operationMaster;
            dataSource["WIS_PAT_IN_HOS"] = DataContext.GetCurrent().GetData("WIS_PAT_IN_HOS");
            dataSource["WIS_CUSTOM_DATA"] = DataContext.GetCurrent().GetData("WIS_CUSTOM_DATA");
            //dataSource["WIS_OPER_SCHEDULE"] = DataContext.GetCurrent().GetData("WIS_OPER_SCHEDULE");
            dataSource["WIS_PAT_VISIT"] = DataContext.GetCurrent().GetData("WIS_PAT_VISIT");
            dataSource["WIS_PAT_MASTER_INDEX"] = DataContext.GetCurrent().GetData("WIS_PAT_MASTER_INDEX");
            dataSource["WIS_ANES_SUMMARY"] = DataContext.GetCurrent().GetData("WIS_ANES_SUMMARY");
            dataSource["WIS_ANES_PLAN"] = DataContext.GetCurrent().GetData("WIS_ANES_PLAN");
            dataSource["WIS_OPER_ANALGESIC"] = DataContext.GetCurrent().GetData("WIS_OPER_ANALGESIC");
        }

        protected override void OnSaveData(Dictionary<string, DataTable> dataSource)
        {
            base.OnSaveData(dataSource);
            CommonDA commonDA = new CommonDA();
            commonDA.Update(dataSource["WIS_OPER_MASTER"], "WIS_OPER_MASTER");
            //commonDA.Update(dataSource["WIS_PAT_IN_HOS"], "WIS_PAT_IN_HOS");
            commonDA.Update(dataSource["WIS_CUSTOM_DATA"], "WIS_CUSTOM_DATA");
            //commonDA.Update(dataSource["WIS_OPER_SCHEDULE"], "WIS_OPER_SCHEDULE");
            commonDA.Update(dataSource["WIS_PAT_VISIT"], "WIS_PAT_VISIT");
            commonDA.Update(dataSource["WIS_PAT_MASTER_INDEX"], "WIS_PAT_MASTER_INDEX");
            commonDA.Update(dataSource["WIS_ANES_SUMMARY"], "WIS_ANES_SUMMARY");
            commonDA.Update(dataSource["WIS_ANES_PLAN"], "WIS_ANES_PLAN");
            commonDA.Update(dataSource["WIS_OPER_ANALGESIC"], "WIS_OPER_ANALGESIC");
        }

        protected override void OnViewBuilded(List<IUIElementHandler> handlers, Dictionary<string, DataTable> dataSources)
        {
            ShowAnesDate();

            DateTime boundary = new DateTime(2026, 9, 8);
            if (_operTime > boundary)
            {
                // ZFNAME-HX (MRichTextBox): 显示"呼吸回路套件"
                List<MRichTextBox> richList = ReportViewer.GetControls<MRichTextBox>();
                foreach (MRichTextBox textBox in richList)
                {
                    if (textBox.Name.Trim().Equals("ZFNAME-HX", StringComparison.OrdinalIgnoreCase))
                    {
                        textBox.Text = "呼吸回路套件";
                    }
                }

                // ZFNAME-HX-PRICE (MTextBox): 初始值设为52
                List<MTextBox> boxList = ReportViewer.GetControls<MTextBox>();
                foreach (MTextBox textBox in boxList)
                {
                    if (textBox.Name.Trim().Equals("ZFNAME-HX-PRICE", StringComparison.OrdinalIgnoreCase))
                    {
                        textBox.InitValue = "52";
                    }
                }
            }
        }
        private void ShowAnesDate()
        {
            //手术日期_operTime BuildData数据加载时赋值
            //判断日期小于2022.5.11的麻醉方法显示WIS_OPER_MASTER 中的ANES_METHOD
            if (DateTime.Compare(_operTime, DateTime.Parse("2022-05-11")) < 0)
            {
                List<MTextBox> list = ReportViewer.GetControls<MTextBox>();
                foreach (MTextBox textBox in list)
                {
                    if (textBox.Name.Trim() == "MTextBoxAnesMethod")
                    {
                        textBox.Text = _anesMethod;
                        textBox.SelectedData = _anesMethod;
                    }
                }
            }

        }
    }
}
