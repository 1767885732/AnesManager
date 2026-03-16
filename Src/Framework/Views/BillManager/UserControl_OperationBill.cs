/*----------------------------------------------------------------
      //北京拓扑工厂科技发展有限公司
      // 文件名：UserControl_OperationBill.cs
      // 文件功能描述：手术收费管理控件
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
    public partial class UserControl_OperationBill : UserControl_BillBase
    {
        public UserControl_OperationBill() : this(null, null, 0, 0) { }
        public UserControl_OperationBill(string patientID, string patientName, decimal visitID, decimal operID)
            : base(false, patientID, patientName, visitID, operID, 0)
        {
            _caption = "手术收费";
            InitializeComponent();
        }
    }
}
