using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Views;

namespace Wis.Anes.Views
{
    [Serializable(), ToolboxItem(false)]
    public partial class InfoCheckBeforeOperation : BaseView
    {
        public InfoCheckBeforeOperation()
        {
            InitializeComponent();
        }
    }
}
