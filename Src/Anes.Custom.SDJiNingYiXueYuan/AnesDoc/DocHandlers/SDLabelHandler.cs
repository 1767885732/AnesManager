using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.Framework.Documents.DefaultHandlers;
using Wis.Anes.Framework.Controls;
using System.Windows.Forms;
using Wis.Anes.Framework.Doc;

namespace Wis.Anes.Custom.CustomProject.AnesDocHandlers
{
    public class SDLabelHandler : LabelHandler
    {
        public override void BindDataToUI(MLabel control, Dictionary<string, System.Data.DataTable> dataSources)
        {
            base.BindDataToUI(control, dataSources);

            if (control.Name == "PageIndex")
            {
                control.Text = string.Format("第{0}页/共{1}页", PagerSetting.CurrentPageIndex + 1, PagerSetting.TotalPageCount);
            }

        }

        /// <summary>
        /// 控件属性事件设置
        /// </summary>
        /// <param name="element"></param>
        public override void ControlSetting(MLabel control)
        {
            base.ControlSetting(control);
            if (control.Text.Replace("\r\n", "") == "双击此处统计" && control.NoPrint)
            {
                control.DoubleClick += new EventHandler(control_DoubleClick);
            }
        }

        void control_DoubleClick(object sender, EventArgs e)
        {
            foreach (IUIElementHandler handler in MedicalPaperUIElementHandlers)
            {
                if (handler is SDTextBoxHandler && handler.GetAllControls != null)
                {
                    foreach (Control control in handler.GetAllControls)
                    {
                        if (control is MTextBox)
                        {
                            MTextBox textBox = control as MTextBox;
                            if (!string.IsNullOrEmpty(textBox.SummaryName) && textBox.SummaryName.Trim() != string.Empty && textBox.SummaryName != "总出量" && textBox.SummaryName != "总入量")
                            {
                                DataContext.GetCurrent().CalTextValue(textBox, base.DataSource);
                            }
                        }
                    }
                    (handler as SDTextBoxHandler).callOutSum();
                    (handler as SDTextBoxHandler).callInSum();
                }
            }
        }
    }
}
