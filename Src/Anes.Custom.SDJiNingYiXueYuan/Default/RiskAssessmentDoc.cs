/*----------------------------------------------------------------
// Copyright (C) 2008 北京拓扑工厂科技发展有限公司
// 文件名：RiskAssessmentDoc.cs
// 文件功能描述：上海儿童医学中心手术风险评估单
// 创建标识：深蓝色右手 2011-08-29
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Documents;
using Wis.Anes.DataAccess;
using Wis.Anes.Framework.Doc;
using Wis.Anes.Framework.Documents.DefaultHandlers;
using Wis.Anes.Custom.CustomProject.Framework;

namespace Wis.Anes.Custom.CustomProject.Default
{
    /// <summary>
    /// 手术风险评估单
    /// </summary>
    public partial class RiskAssessmentDoc : BaseDoc  
    {
        public RiskAssessmentDoc()
        {
            InitializeComponent();
            _pageName = "A4";
            base.DocKind = Wis.Anes.Framework.DocKind.Default;
            base.ApplyDataTemplate.Visible = false ;
            base.SaveDataTemplate.Visible = false;
        }

        protected override void AddCustomUIElementHandlers(List<Wis.Anes.Framework.Doc.IUIElementHandler> handlers)
        {
            IUIElementHandler handlerTemp = null;
            IUIElementHandler handlerTemp2 = null;

            foreach (IUIElementHandler handler in handlers)
            {
                if (handler is TextBoxHandler)
                {
                    handlerTemp = handler;
                }
                if (handler is CustomControlHandler)
                {
                    handlerTemp2 = handler;
                }
            }
            if (handlerTemp != null)
            {
                handlers.Remove(handlerTemp);
            }
            if (handlerTemp2 != null)
            {
                handlers.Remove(handlerTemp2);
            }

            handlers.Add(new ExtendTextBoxHandler());
            handlers.Add(new ExtendCustomControlHandler());
            //handlers.Add(new SHAT.AnesDocHandlers.ShanXiYKDXDYFSYYCheckBoxHandler());
        }
        protected override void BuildData(Dictionary<string, DataTable> dataSource)
        {
            dataSource["WIS_OPER_MASTER"] = DataContext.GetCurrent().GetData("WIS_OPER_MASTER");
            dataSource["WIS_CUSTOM_DATA"] = DataContext.GetCurrent().GetData("WIS_CUSTOM_DATA");
            dataSource["WIS_ANES_PLAN"] = DataContext.GetCurrent().GetData("WIS_ANES_PLAN");
            dataSource["WIS_PAT_MASTER_INDEX"] = DataContext.GetCurrent().GetData("WIS_PAT_MASTER_INDEX");
        }

        protected override void OnSaveData(Dictionary<string, DataTable> dataSource)
        {
            CommonDA commonDA = new CommonDA();
            commonDA.Update(dataSource["WIS_OPER_MASTER"], "WIS_OPER_MASTER");
            commonDA.Update(dataSource["WIS_CUSTOM_DATA"], "WIS_CUSTOM_DATA");
            commonDA.Update(dataSource["WIS_ANES_PLAN"], "WIS_ANES_PLAN");
            commonDA.Update(dataSource["WIS_PAT_MASTER_INDEX"], "WIS_PAT_MASTER_INDEX");
        }
        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // RiskAssessmentDoc
            // 
            this.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "RiskAssessmentDoc";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }


    }
}
