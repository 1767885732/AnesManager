/*----------------------------------------------------------------
      //北京拓扑工厂科技发展有限公司
      // 文件名：UserControl_BillLeftList.cs
      // 文件功能描述：收费管理界面左侧列表
      //
      // 
      // 创建标识：XXX-2011-09-23
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Wis.Anes.Framework.Views.BillManager
{
    [ToolboxItem(false)]
    public partial class UserControl_BillLeftList : UserControl
    {
        public UserControl_BillLeftList() { }
        public UserControl_BillLeftList(DataTable dataSource)
        {
            InitializeComponent();
            if (dataSource != null)
            {
                this.gridControlLeftList.DataSource = dataSource;
            }
        }
    }
}
