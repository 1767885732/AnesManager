/*----------------------------------------------------------------
// Copyright (C) 2008 北京拓扑工厂科技发展有限公司
// 文件名：ExtendTextBoxHandler.cs
// 文件功能描述：上海儿童医学中心手术风险评估单TextBox控件
// 创建标识：深蓝色右手 2011-08-29
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.Framework.Documents.DefaultHandlers;
using Wis.Anes.Framework.Controls;
using System.Data;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework.Documents;

namespace Wis.Anes.Custom.CustomProject.Default
{
    public class ExtendTextBoxHandler : TextBoxHandler
    {
        public override void BindUIToData(MTextBox control, Dictionary<string, DataTable> dataSources)
        {
            if (string.IsNullOrEmpty(control.SourceTableName) || string.IsNullOrEmpty(control.SourceFieldName))
                return;
            if (control.Text.EndsWith("岁"))
                return;
            if (string.IsNullOrEmpty(control.Text))
            {
                control.Data = DBNull.Value;
            }
            else
            {
                if (string.IsNullOrEmpty(control.DictTableName) && string.IsNullOrEmpty(control.DictValueFieldName))
                {
                    SetControlValue(control);
                }

            }

            SetFieldValue(control.SourceTableName, control.SourceFieldName, control.Data);
        }
    }
}
