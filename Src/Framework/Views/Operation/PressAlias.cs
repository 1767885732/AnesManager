using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Wis.Anes.Framework
{
    [ToolboxItem(false)]
    public partial class PressAlias : UserControl
    {
        private bool _isPerformed;
        public bool IsPerformed
        {
            get
            {
                return _isPerformed;
            }
        }

        private string _memo = "";
        public string Memo
        {
            get
            {
                return _memo;
            }
            set
            {
                _memo = value;
            }
        }

        public PressAlias()
        {
            InitializeComponent();
        }

        private void PressAlias_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                if (ParentForm != null)
                {
                    ParentForm.AcceptButton = btnOK;
                    ParentForm.CancelButton = btnCancel;
                }
                if (!string.IsNullOrEmpty(_memo))
                {
                    int index = _memo.IndexOf(",");
                    if (index > 0)
                    {
                        textBox1.Text = _memo.Substring(0, index);
                        textBox2.Text = _memo.Substring(index + 1);
                    }
                    else
                    {
                        textBox1.Text = _memo;
                    }
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _memo = textBox1.Text + "," + textBox2.Text;
            _isPerformed = true;
        }
    }
}
