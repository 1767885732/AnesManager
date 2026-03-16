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
    public partial class LiquidSummeryEditor : UserControl
    {
        public LiquidSummeryEditor()
        {
            InitializeComponent();
        }

        public LiquidSummeryEditor(string memo)
        {
            InitializeComponent();
            memoEdit1.Text = memo;
        }

        private string _memo = "";
        public string Memo
        {
            get
            {
                return _memo;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _memo = memoEdit1.Text;
            ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (ParentForm != null && ParentForm.Modal)
            {
                ParentForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }

        private void WHYX_LiquidSummeryEditor_Load(object sender, EventArgs e)
        {
            if (ParentForm != null)
            {
                ParentForm.AcceptButton = btnOK;
                ParentForm.CancelButton = btnCancel;
                listBoxControl1.Items.Add("输液\r\n");
                listBoxControl1.Items.Add("机器血:  ml");
                listBoxControl1.Items.Add("血浆:  ml");
                listBoxControl1.Items.Add("冷沉淀:  ml");
                listBoxControl1.Items.Add("少白红:  u");
                listBoxControl1.Items.Add("悬浮红细胞:  u");
                listBoxControl1.Items.Add("血小板:  1人份");
                listBoxControl1.Items.Add("机器放血:  ml");
                listBoxControl1.Items.Add("洗涤红细胞:  ml");
                listBoxControl1.Items.Add("已输完");
                listBoxControl1.Items.Add("已输:  ml");
                listBoxControl1.Items.Add("余:  ml");
                listBoxControl1.Items.Add("回ICU");
                listBoxControl1.Items.Add("回CCU");
            }
        }

        private void listBoxControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBoxControl1.SelectedItem!=null&&listBoxControl1.SelectedIndex >= 0)
            {
                memoEdit1.Text +=(memoEdit1.Text.Trim().Equals(string.Empty)||memoEdit1.Text.Trim().Equals("输液"))?listBoxControl1.SelectedValue.ToString():","+ listBoxControl1.SelectedValue.ToString();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            memoEdit1.Text = string.Empty;
        }
    }
}
