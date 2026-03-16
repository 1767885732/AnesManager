using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Utilities;

namespace Wis.Anes.Framework.Views.BillManager
{
    public partial class UserControl_BillTempletSelect : UserControl
    {
        protected List<string> _list = null; // 选项
        protected bool _isSelect = true;   // 是否为选择 flase 则为保存
        public UserControl_BillTempletSelect(List<string> list, bool isSelect)
        {
            InitializeComponent();
            _list = list;
            _isSelect = isSelect;
        }

        public string TempletName
        {
            get { return txtName.Text; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_isSelect)
            {
                if (!_list.Contains(TempletName))
                {
                    Dialog.MessageBox("选择的模板不存在");
                    return;
                }
            }
            else
            {
                if (_list.Contains(TempletName))
                {
                    if(Dialog.MessageBox("输入的模板已存在，是否要覆盖?", "模板重复", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                }
            }

            ((Form)Parent).DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void txtOpertionRoom_DoubleClick(object sender, EventArgs e)
        {
            Dialog.ShowCustomSelection(_list, "", txtName, new Point(0, txtName.Height), new Size(txtName.Width, 300)
                    , new EventHandler(delegate(object s1, EventArgs e1)
                    {
                        int index = Convert.ToInt32(s1);
                        if (index > -1 && index < _list.Count)
                        {
                            txtName.Text = _list[index];
                        }
                    }));
        }
    }
}
