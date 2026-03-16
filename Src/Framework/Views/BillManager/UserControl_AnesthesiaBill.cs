/*----------------------------------------------------------------
      //北京拓扑工厂科技发展有限公司
      // 文件名：UserControl_AnesthesiaBill.cs
      // 文件功能描述：麻醉收费管理控件
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
    public partial class UserControl_AnesthesiaBill : UserControl_BillBase
    {
        public UserControl_AnesthesiaBill() : this(null,null,  0, 0) { }
        public UserControl_AnesthesiaBill(string patientID, string patientName, decimal visitID,decimal operID):base(true,patientID, patientName, visitID,operID,1)
        {
            _caption = "麻醉收费";
            InitializeComponent();
        }
    }
}
