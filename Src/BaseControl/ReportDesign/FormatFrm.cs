using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Com.MedicalSystem.Common.Utilities;
using Com.MedicalSystem.Common.Controls;

namespace Com.ICIS.Icu
{
    public partial class FormatFrm : DevExpress.XtraEditors.XtraForm
    {
        private string[] _dateFormat = new string[15]{ "0", "0:d", "0:D", "0:f", "0:F", "0:g", "0:G", "0:M", "0:R", "0:s", "0:t", "0:T", "0:u", "0:U", "0:Y"};
        private string[] _numberFormat = new string[6] {"0","0:N1", "0:N2", "0:N3", "0:F1", "0:F2"};
        private string _formatResult = string.Empty;
        public string FormatResult
        {
            get
            {
                return _formatResult;
            }
        }

        public FormatFrm()
        {
            InitializeComponent();
            cmbType.SelectedIndex = 0;
        }
        public DialogResult ShowForm()
        {            
            return ShowDialog();            
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (cmbType.SelectedIndex == 0)
            {
                DateTime Now = DateTime.Now;
                for (int i = 0; i < _dateFormat.Length; i++)
                {
                    listBox1.Items.Add(String.Format("{" + _dateFormat[i] + "}", Now));
                }
            }
            else
            {
                int j = 1234567;
                for (int i = 0; i < _numberFormat.Length; i++)
                {
                    listBox1.Items.Add(String.Format("{" + _numberFormat[i] + "}", j));
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType.SelectedIndex == 0)
            {
                textBox1.Text = _dateFormat[listBox1.SelectedIndex];                
            }
            else
            {
                textBox1.Text = _numberFormat[listBox1.SelectedIndex];                
            }
            label1.Text = listBox1.Items[listBox1.SelectedIndex].ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {   
                DateTime Now = DateTime.Now;
                int j = 1234567;
                if (cmbType.SelectedIndex == 0)
                {
                    label1.Text = String.Format("{" + textBox1.Text + "}",Now);
                }
                else
                {
                    label1.Text = String.Format("{" + textBox1.Text + "}", j);
                }
                _formatResult = textBox1.Text;
            }
            catch (FormatException)
            {
                _formatResult = string.Empty;
            }
        }
    }
}