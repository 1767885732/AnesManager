using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Score.Common.Controls
{
    public partial class AnesScore : DevExpress.XtraEditors.XtraUserControl
    {
        public AnesScore(string patientID, decimal visitID, decimal deptID)
        {
            InitializeComponent(patientID, visitID, deptID);
            
        }
    }
}
