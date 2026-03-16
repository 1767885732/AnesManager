using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework;
using Wis.Anes.Framework.Views;

namespace Wis.Anes.Views
{
    [ToolboxItem(false)]
    public partial class EditTemplet : BaseView
    {
        /// <summary>
        /// 模板管理构造方法
        /// </summary>
        public EditTemplet()
        {
            InitializeComponent();
        }


        private void CheckRight()
        {
            //if ((MainNavHelper.CheckRight("NewModelManager") & MainNavHelper.RightType.Modify) != MainNavHelper.RightType.Modify)
            //{
                
            //}
        }

        public override bool IsDirty
        {
            get
            {
                return eventTemplet1.IsDirty | documentTemplet1.IsDirty;
            }
        }

        public override bool Save()
        {
            bool b = false;
            if (eventTemplet1.IsDirty&&eventTemplet1.Save())
            {
                b = true;
            }
            if (documentTemplet1.IsDirty&&documentTemplet1.Save())
            {
                b = true;
            }
            return b;
        }

        /// <summary>
        /// 控件load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditTemplet_Load(object sender, EventArgs e)
        {

  
        }

        private void xtraTabControl1_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {

        }
    }
}
