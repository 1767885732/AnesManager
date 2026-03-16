using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Wis.Anes.Views
{
    [ToolboxItem(false)]
    public partial class SpileInfoEditor : UserControl
    {
        private List<string> spileMethod = new List<string> { "诱导插管", "清醒插管" };
        private List<string> spileRoute = new List<string> { "经口", "经鼻(左)", "经鼻(右)" };
        private List<string> spileDepth = new List<string> { "10", "10.5", "11","11.5","12","12.5","13","13.5","14","14.5","15","15.5"
            ,"16","16.5","17","17.5","18","18.5","19","19.5","20","20.5","21","21.5","22","22.5","23","23.5","24","24.5","25"};
        private List<string> pipeType = new List<string> { "单腔管", "双腔管（左）","双腔管（右）" };
        private List<string> pipeModel = new List<string> { "2.5#", "3#", "3.5#", "4#", "4.5#", "5#", "5.5#", "6#", "6.5#", "7#", "7.5#"
            , "8#", "8.5#","9#","9.5#","10#","28F#左","28F#右","35F#左","35F#右","37F#左","37F#右","39F#左","39F#右","Univent" };
        private List<string> anesMethod = new List<string> { "吸入", "全静脉", "静吸复合" };
        
        public SpileInfoEditor()
        {
            InitializeComponent();
            InitControls();
        }

        public SpileInfoEditor(string memo)
        {
            InitializeComponent();
            InitControls();
            _memo = memo;
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

        private void InitControls()
        {
            chklistSpileMethod.Items.Clear();
            chklistSpileMethod.Items.AddRange(spileMethod.ToArray());
            chklistSpileRoute.Items.Clear();
            chklistSpileRoute.Items.AddRange(spileRoute.ToArray());
            chklistPipeType.Items.Clear();
            chklistPipeType.Items.AddRange(pipeType.ToArray());
            cmbSpileDepth.Properties.Items.Clear();
            cmbSpileDepth.Properties.Items.AddRange(spileDepth.ToArray());
            cmbPipeModel.Properties.Items.Clear();
            cmbPipeModel.Properties.Items.AddRange(pipeModel.ToArray());
            cmbAnesMethod.Properties.Items.Clear();
            cmbAnesMethod.Properties.Items.AddRange(anesMethod.ToArray());
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _memo = "";
            for (int i = 0; i < chklistSpileMethod.Items.Count; i++)
            {
                if (chklistSpileMethod.Items[i].CheckState.Equals(CheckState.Checked))
                {
                    _memo += _memo.Equals(string.Empty) ? chklistSpileMethod.Items[i].Value.ToString() : "," + chklistSpileMethod.Items[i].Value.ToString();
                }
            }
            for (int i = 0; i < chklistSpileRoute.Items.Count; i++)
            {
                if (chklistSpileRoute.Items[i].CheckState.Equals(CheckState.Checked))
                {
                    _memo += _memo.Equals(string.Empty) ? chklistSpileRoute.Items[i].Value.ToString() : "," + chklistSpileRoute.Items[i].Value.ToString();
                }
            }
            for (int i = 0; i < chklistPipeType.Items.Count; i++)
            {
                if (chklistPipeType.Items[i].CheckState.Equals(CheckState.Checked))
                {
                    _memo += _memo.Equals(string.Empty) ? chklistPipeType.Items[i].Value.ToString() : "," + chklistPipeType.Items[i].Value.ToString();
                }
            }
            if(!cmbPipeModel.Text.Trim().Equals(string.Empty))
            {
                _memo += _memo.Equals(string.Empty) ? "管号:" + cmbPipeModel.Text : ",管号:" + cmbPipeModel.Text;
                if (chkYouNang.Checked)
                {
                    _memo += "(有囊)";
                }
                else if (chkWuNang.Checked)
                {
                    _memo += "(无囊)";
                }
            }
            if (!cmbAnesMethod.Text.Trim().Equals(string.Empty))
            {
                _memo += _memo.Equals(string.Empty) ? cmbAnesMethod.Text : "," + cmbAnesMethod.Text;
            }
            if (!cmbSpileDepth.Text.Trim().Equals(string.Empty))
            {
                _memo += _memo.Equals(string.Empty) ? "深度:" + cmbSpileDepth.Text + "cm" : ",深度:" + cmbSpileDepth.Text + "cm";
            }
            if (ParentForm != null && ParentForm.Modal)
            {
                ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void WHYX_SpileInfoEditor_Load(object sender, EventArgs e)
        {
            if (ParentForm != null)
            {
                ParentForm.AcceptButton = btnOK;
                ParentForm.CancelButton = btnCancel;
            }
            if (!_memo.Trim().Equals(string.Empty))
            {
                string[] strs = _memo.Trim().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string str in strs)
                {
                    if (str.StartsWith("管号:") || str.StartsWith("管号："))
                    {
                        if (str.Contains("(有囊)"))
                        {
                            chkYouNang.Checked = true;
                        }
                        else
                        {
                            chkYouNang.Checked = false;
                        }
                        if (str.Contains("(无囊)"))
                        {
                            chkWuNang.Checked = true;
                        }
                        else
                        {
                            chkWuNang.Checked = false;
                        }
                        if (str.IndexOf("(") > 3)
                        {
                            cmbPipeModel.Text = str.Substring(3, str.IndexOf("(") - 3);
                        }
                        else
                        {
                            cmbPipeModel.Text = str.Substring(3);
                        }
                        continue;
                    }
                    if (str.StartsWith("深度:") || str.StartsWith("深度："))
                    {
                        cmbSpileDepth.Text = str.Substring(3).Replace("cm","").Replace("CM","");
                        continue;
                    }
                    bool isSet = false;
                    for (int i = 0; i < chklistSpileMethod.Items.Count; i++)
                    {
                        if (chklistSpileMethod.Items[i].Value.ToString().Equals(str))
                        {
                            chklistSpileMethod.Items[i].CheckState = CheckState.Checked;
                            isSet = true;
                            break;
                        }
                    }
                    if (isSet) continue;
                    for (int i = 0; i < chklistSpileMethod.Items.Count; i++)
                    {
                        if (chklistSpileMethod.Items[i].Value.ToString().Equals(str))
                        {
                            chklistSpileMethod.Items[i].CheckState = CheckState.Checked;
                            isSet = true;
                            break;
                        }
                    }
                    if (isSet) continue;
                    for (int i = 0; i < chklistSpileRoute.Items.Count; i++)
                    {
                        if (chklistSpileRoute.Items[i].Value.ToString().Equals(str))
                        {
                            chklistSpileRoute.Items[i].CheckState = CheckState.Checked;
                            isSet = true;
                            break;
                        }
                    }
                    if (isSet) continue;
                    for (int i = 0; i < chklistPipeType.Items.Count; i++)
                    {
                        if (chklistPipeType.Items[i].Value.ToString().Equals(str))
                        {
                            chklistPipeType.Items[i].CheckState = CheckState.Checked;
                            isSet = true;
                            break;
                        }
                    }
                    if (isSet) continue;
                    for (int i = 0; i < cmbAnesMethod.Properties.Items.Count; i++)
                    {
                        if (cmbAnesMethod.Properties.Items[i].ToString().Equals(str))
                        {
                            cmbAnesMethod.SelectedText = str;
                            isSet = true;
                            break;
                        }
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (ParentForm != null && ParentForm.Modal)
            {
                ParentForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }

        private void chkYouNang_CheckedChanged(object sender, EventArgs e)
        {
            if (chkYouNang.Checked)
            {
                chkWuNang.Checked = false;
            }
        }

        private void chkWuNang_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWuNang.Checked)
            {
                chkYouNang.Checked = false;
            }
        }
    }
}
