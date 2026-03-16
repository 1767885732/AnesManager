using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework.Utilities;
using Wis.Anes.DataAccess;

namespace Wis.Anes.Framework
{
    [ToolboxItem(false)]
    public partial class SetNewDocumentTemplet : UserControl
    {
        public Dict.DocumentTempletRow DialogResultData;

        Dict.OperationDictDataTable _operationDictDataTable;
        public SetNewDocumentTemplet()
        {
            InitializeComponent();
            btnOK.Enabled = false;
            checkEdit1.Checked = true;
            btnOK.Visible = true;
            btnCancel.Visible = true;
        }

        private void textEdit1_DoubleClick(object sender, EventArgs e)
        {
            Dialog.SelectFromDataTable(_operationDictDataTable, _operationDictDataTable.OPER_NAMEColumn.ColumnName, sender as Control, false);
        }

        private void SetNewDocumentTemplet_Load(object sender, EventArgs e)
        {
            DictDA dictDA = new DictDA();
            _operationDictDataTable = dictDA.GetOperationDict();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (ParentForm != null && ParentForm.Modal)
            {
                ParentForm.DialogResult = DialogResult.Cancel;
                DialogResultData = null;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEdit2.Text.Trim()))
            {
                XtraMessageBox.Show("模板名不能为空！", "提示信息");
                return;
            }

            DictDA dictDA = new DictDA();
            Dict.DocumentTempletDataTable documentTempletDataTable = dictDA.GetDocumentTemplet();

            if (documentTempletDataTable.Select("TEMPLET_NAME='" + textEdit2.Text.Trim() + "'").Length > 0)
            {
                XtraMessageBox.Show("模板名已存在！", "提示信息");
                return;
            }
            if (ParentForm != null && ParentForm.Modal)
            {
                ParentForm.DialogResult = DialogResult.OK;
                Dict.DocumentTempletRow row = documentTempletDataTable.NewDocumentTempletRow();
                row.TEMPLET_GUID = Guid.NewGuid().ToString();
                row.CLASS_NAME = string.IsNullOrEmpty(textEdit1.Text.Trim()) ? "通用" : textEdit1.Text.Trim();
                row.TEMPLET_NAME = textEdit2.Text.Trim();
                row.USER_ID = ExtendApplicationContext.Current.LoginUserContext.UserID;
                row.EVENT_NO = ExtendApplicationContext.Current.EventNo;
                row.IS_PRIVATE = checkEdit1.Checked ? 1 : 0;
                DialogResultData = row;
            }
        }

        private void textEdit2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEdit2.Text.Trim()))
            {
                btnOK.Enabled = false;
            }
            else
            {
                btnOK.Enabled = true;
            }
        }

        private void textEdit1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEdit2.Text.Trim()))
            {
                btnOK.Enabled = false;
            }
            else
            {
                btnOK.Enabled = true;
            }
        }
     
    }
}
