using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Wis.Anes.DataAccess;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.Framework.Documents;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;

namespace Wis.Anes.Framework.Views.Process
{
    public partial class AquairPacuCondition : BaseView
    {
        public AquairPacuCondition()
        {
            InitializeComponent();
        }

        public string PacuCondition
        {
            get { return radioGroupBreath.EditValue.ToString(); }
        }
    }
}
