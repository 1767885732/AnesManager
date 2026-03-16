using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
//using Com.Wis.Anes.ClientLibrary;
using System.Windows.Forms;
using Wis.Anes.Framework.Utilities;
using System.ComponentModel;

namespace Wis.Anes.Framework
{
    [ToolboxItem(false)]
    public partial class AnesthesiaItemEdit : UserControl
    {
        public AnesthesiaItemEdit()
        {
            InitializeComponent();
        }

        List<string> _items = new List<string>();
        public List<string> Items
        {
            set
            {
                _items = value;
            }
        }

        private string _name1 = "";
        public string Name1
        {
            get
            {
                return _name1;
            }
            set
            {
                _name1 = value;
                medTextBox_Name1.Text = value;
            }
        }
        private string _name2 = "";
        public string Name2
        {
            get
            {
                return _name2;
            }
            set
            {
                _name2 = value;
                medTextBox_Name2.Text = value;
            }
        }
        private string _unit1 = "";
        public string Unit1
        {
            get
            {
                return _unit1;
            }
            set
            {
                _unit1 = value;
                medTextBox_Unit1.Text = value;
            }
        }
        private string _unit2 = "";
        public string Unit2
        {
            get
            {
                return _unit2;
            }
            set
            {
                _unit2 = value;
                medTextBox_Unit2.Text = value;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Name1 = medTextBox_Name1.Text;
            Name2 = medTextBox_Name2.Text;

            Unit1 = medTextBox_Unit1.Text;
            Unit2 = medTextBox_Unit2.Text;

            if (ParentForm != null && ParentForm.Modal)
            {
                ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (ParentForm != null && ParentForm.Modal)
            {
                ParentForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }

        private void medTextBox_Name1_Click(object sender, EventArgs e)
        {
            ShowSelection(sender as DevExpress.XtraEditors.TextEdit);
        }

        private void medTextBox_Unit1_Click(object sender, EventArgs e)
        {
        }

        private void ShowSelection(DevExpress.XtraEditors.TextEdit textBox)
        {
            if (textBox != null && _items.Count > 0)
            {
                Dialog.ShowCustomSelection(_items, "", textBox, new Point(0, textBox.Height), new Size(200, 400)
                , new EventHandler(delegate(object sender, EventArgs e)
                {
                    if (sender is int)
                    {
                        int index = (int)sender;
                        textBox.Text = _items[index];
                    }
                }));
            }
        }

        private void medTextBox_Name2_Click(object sender, EventArgs e)
        {
            ShowSelection(sender as DevExpress.XtraEditors.TextEdit);
        }

        private void medTextBox_Unit2_Click(object sender, EventArgs e)
        {
        }

        private void WHYX_AnesthesiaItemEdit_Load(object sender, EventArgs e)
        {
            if (ParentForm != null)
            {
                ParentForm.CancelButton = btnRefresh;
                ParentForm.AcceptButton = btnSave;
            }
        }
    }
}
