using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Views;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.Framework;
using Wis.Anes.ServiceProxies;
using Wis.Anes.Constants;
using System.Reflection;
using Wis.Anes.Framework.Controls.Base;
using System.IO;
using Wis.Anes.Framework.Utilities;
using Wis.Anes.Layouts;
using Wis.Anes.Framework.Controls;

namespace Wis.Anes.Views
{
    public partial class SystemConfig : BaseView
    {
        private ProgramStatus _programStatus = ProgramStatus.NoPatient;
        private Dictionary<ProgramStatus, string> _statusButtonStrList = new Dictionary<ProgramStatus, string>();
        private string[] _currentButtonStrings = new string[] { "", "", "", "", "" };
        private Dictionary<string, string> _operDocuments = new Dictionary<string, string>();
        private Dictionary<string, string> _operActions = new Dictionary<string, string>();

        public SystemConfig()
        {
            Caption = "超级配置";
            InitializeComponent();
        }

        #region 方法
        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="rowKey"></param>
        private void RemoveFromGrid(DataGridView grid, string rowKey)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(rowKey))
                {
                    grid.Rows.Remove(row);
                    break;
                }
            }
        }

        /// <summary>
        /// 下移
        /// </summary>
        /// <param name="grid"></param>
        private void MoveUp(DataGridView grid)
        {
            if (grid.CurrentRow != null)
            {
                int index = grid.CurrentRow.Index;
                if (index > 0)
                {
                    string text = grid.CurrentCell.Value.ToString();
                    grid.Rows.Remove(grid.CurrentRow);
                    grid.Rows.Insert(index - 1, text);
                    grid.CurrentCell = grid.Rows[index - 1].Cells[0];
                }
            }
        }

        /// <summary>
        /// 下移
        /// </summary>
        /// <param name="grid"></param>
        private void MoveDown(DataGridView grid)
        {
            if (grid.CurrentRow != null)
            {
                int index = grid.CurrentRow.Index;
                if (index < grid.Rows.Count - 1)
                {
                    string text = grid.CurrentCell.Value.ToString();
                    grid.Rows.Remove(grid.CurrentRow);
                    grid.Rows.Insert(index + 1, text);
                    grid.CurrentCell = grid.Rows[index + 1].Cells[0];
                }
            }
        }

        /// <summary>
        /// 导航菜单相关内容显示
        /// </summary>
        /// <param name="currentButtonStrings"></param>
        /// <param name="groupIndex"></param>
        private void SetNavigateAndGrid(string[] currentButtonStrings, int groupIndex)
        {
            leftBarControl1.SetCurrentViewNavigateButtons(_programStatus, _statusButtonStrList);
            List<string> menus = new List<string>();
            dgvMenuCanSelect.Rows.Clear();
            Type type = typeof(ViewNames);
            FieldInfo[] fieldInfos = type.GetFields();
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                dgvMenuCanSelect.Rows.Add(new string[] { fieldInfo.GetRawConstantValue().ToString().Trim() });
                menus.Add(fieldInfo.GetRawConstantValue().ToString().Trim());
            }
            Dictionary<string, MedicalDocElement> customViews = MedicalDocSettings.GetCustomForms();
            foreach (KeyValuePair<string, MedicalDocElement> keyValuePair in customViews)
            {
                if (!menus.Contains(keyValuePair.Key))
                {
                    dgvMenuCanSelect.Rows.Add(new string[] { keyValuePair.Key });
                    menus.Add(keyValuePair.Key);
                }
            }

            //by dhc 20200324 备选区域添加麻醉事件列表
            string anesEventStr = ApplicationConfiguration.AnesEventButtons;
            if (!string.IsNullOrEmpty(anesEventStr))
            {
                foreach (string eventButton in anesEventStr.Split(','))
                {
                    dgvMenuCanSelect.Rows.Add(new string[] { eventButton });
                    menus.Add(eventButton);
                }
            }

            dgvMenuSelected.Rows.Clear();
            foreach (string str in currentButtonStrings)
            {
                string[] groupButtons = str.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string text in groupButtons)
                {
                    string btnText = text;
                    if (btnText.Contains("\t")) btnText = btnText.Replace("\t", "");
                    while (btnText.Contains(" "))
                    {
                        btnText = btnText.Replace(" ", "");
                    }
                    if (!string.IsNullOrEmpty(btnText))
                    {
                        if (str == currentButtonStrings[groupIndex])
                        {
                            dgvMenuSelected.Rows.Add(new string[] { btnText });
                        }
                        RemoveFromGrid(dgvMenuCanSelect, btnText);
                    }
                }
            }
        }

        /// <summary>
        /// 修改缓存中导航菜单
        /// </summary>
        private void modifyButtonStrList()
        {
            if (dgvMenuSelected.Rows.Count > 0)
            {
                List<string> list = new List<string>();
                string str="";
                for (int i = 0; i < dgvMenuSelected.Rows.Count; i++)
                {
                    str+=dgvMenuSelected.Rows[i].Cells[0].Value.ToString().Trim()+",";
                }
                str = str.Substring(0, str.Length - 1);
                _currentButtonStrings[comboBoxEditSample.SelectedIndex] = str;
                _statusButtonStrList[_programStatus] =string.Join(";", _currentButtonStrings);
            }
            else
            {
                _currentButtonStrings[comboBoxEditSample.SelectedIndex] = "";
                _statusButtonStrList[_programStatus] = string.Join(";", _currentButtonStrings);
            }
        }

        /// <summary>
        /// 在内存中更新当前状态医疗文书配置
        /// </summary>
        private void ChangeOperDocument()
        {
            string s1 = "", s2 = "";
            foreach (DataGridViewRow row in dgvSelectedDoc.Rows)
            {
                s1 = s1 + "," + row.Cells[0].Value.ToString();
            }
            //foreach (DataGridViewRow row in dgvHide.Rows)
            //{
            //    s2 = s2 + "," + row.Cells[0].Value.ToString();
            //}
            if (s1.Length > 0 && s1.StartsWith(","))
            {
                s1 = s1.Substring(1);
            }
            if (s2.Length > 0 && s2.StartsWith(","))
            {
                s2 = s2.Substring(1);
            }
            string text = cmbOperationStatusNames.Text;
            _operDocuments[text] = s1;// +";" + s2;
        }

        private void ChangeOperAction()
        {
            string s1 = "";
            foreach (DataGridViewRow row in dgvSelectedActions.Rows)
            {
                s1 = s1 + "," + row.Cells[0].Value.ToString();
            }
            if (s1.Length > 0 && s1.StartsWith(","))
            {
                s1 = s1.Substring(1);
            }
            string key = cmbOperationStatusNames.Text;
            _operActions[key] = s1;
        }

        #endregion

        private void SystemConfig_Load(object sender, EventArgs e)
        {
            //常规
            chkDisplayLastMonitorData.Checked = ApplicationConfiguration.DisplayLastMonitorData;
            chkAllRights.Checked = ApplicationConfiguration.AllRights;
            chkSyncOpen.Checked = ApplicationConfiguration.SyncOpen;
            chkShowMainFormStatusBar.Checked = ApplicationConfiguration.ShowMainFormStatusBar;
            chkCheckDictInput.Checked = ApplicationConfiguration.CheckDictInput;
            switch (ApplicationConfiguration.PassWordType)
            {
                case ApplicationConfiguration.PassWordTypes.CaseSensitive:
                    radioGroupPassword.SelectedIndex = 1;
                    break;
                case ApplicationConfiguration.PassWordTypes.LowCase:
                    radioGroupPassword.SelectedIndex = 2;
                    break;
                default:
                    radioGroupPassword.SelectedIndex = 0;
                    break;
            }
            txtYouDaoRoomTitle.Text = ApplicationConfiguration.YouDaoRoomTitle;
            txtCustomSettingProvider.Text = ApplicationConfiguration.CustomSettingProvider;
            txtOperationInformationProvider.Text = ApplicationConfiguration.GetMedicalDocument(ViewNames.OperationInformation).ToString();
            txtOperationRegisterProvider.Text = ApplicationConfiguration.GetMedicalDocument(ViewNames.OperationRegister).ToString();
            txtPermissionProvider.Text = ApplicationConfiguration.PermissionProvider;
            txtCustomDllName.Text = ApplicationConfiguration.CustomDllName;
            List<string> list1 = ApplicationConfiguration.MedicalDocumentList;
            txtMedicalDocumentList.Text = string.Join(",", list1.ToArray());
            dgvDocumentClasses.Rows.Clear();
            foreach (string text in list1)
            {
                dgvDocumentClasses.Rows.Add(new object[] { text,ApplicationConfiguration.GetMedicalDocument(text)});
            }
            chkYouDao.Checked = ApplicationConfiguration.IsYouDaoProgram;
            //新增配置PACU系统管理
            chkPACUProgram.Checked = ApplicationConfiguration.IsPACUProgram;

            //专家咨询
            chkAcs.Checked = ApplicationConfiguration.IsConnACS;
            txtAcsAddress.Text = ApplicationConfiguration.AcsAddress;

            //麻醉单复苏单单页时间长度
            txtAnesDocRange.Text = ApplicationConfiguration.AnesDocRange.ToString();
            txtPACUDocRange.Text = ApplicationConfiguration.PACUDocRange.ToString();


            //程序登入后是否弹出显示术中患者列表
            chkIsShowUnDonePatientListView.Checked = ApplicationConfiguration.IsShowUnDonePatientList;
            chkPACUProcess.Checked = ApplicationConfiguration.IsPACUProcess;
            chkMergeMonitorData.Checked = ApplicationConfiguration.MergeMonitorData;
            chkShowDocumentScrollBar.Checked = ApplicationConfiguration.ShowDocumentScrollBar;
            chkUseDefaultOperatingRoom.Checked = ApplicationConfiguration.UseDefaultOperatingRoom;
            chkIsUpdateScheduleStatus.Checked = ApplicationConfiguration.IsUpdateScheduleStatus;
            chkIsUpdateHisStatus.Checked = ApplicationConfiguration.IsUpdateHisStatus;
            //手术状态
            foreach (string s in OperationStatusHelper.OperationStatusList)
            {
                dgvPatientStatusButtons.Rows.Add(new string[] { s });
            }
            string text1 = ApplicationConfiguration.PatientStatusButtons;
            if (!string.IsNullOrEmpty(text1))
            {
                string[] ss = text1.Split(',');
                foreach (string s in ss)
                {
                    dgvPatientStatusButtonsSelect.Rows.Add(new string[] { s });
                    RemoveFromGrid(dgvPatientStatusButtons, s);
                }
            }
            //导航菜单
            _statusButtonStrList.Add(ProgramStatus.NoPatient, ApplicationConfiguration.NoPatientButtons);
            _statusButtonStrList.Add(ProgramStatus.SelectPatient, ApplicationConfiguration.SelectPatientButtons);
            _statusButtonStrList.Add(ProgramStatus.AnesthesiaRecord, ApplicationConfiguration.AnesthesiaRecordButtons);
            _statusButtonStrList.Add(ProgramStatus.PACURecord, ApplicationConfiguration.PACUButtons);
            radioGroupProgramStatus.SelectedIndex = 0;
            comboBoxEditSample.SelectedIndex = 0;
            //文书菜单
            List<string> list = OperationStatusHelper.OperationStatusList;
            foreach (string text in list)
            {
                _operDocuments.Add(text, OperationStatusHelper.GetOperDocument(text));
                _operActions.Add(text, OperationStatusHelper.GetOperAction(text));
            }
            cmbOperationStatusNames.Properties.Items.AddRange(list.ToArray());
            cmbOperationStatusNames.SelectedIndex = 0;
            chkAutoGenDocument.Checked = ApplicationConfiguration.AutoGenDocument;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //常规
            ApplicationConfiguration.DisplayLastMonitorData=chkDisplayLastMonitorData.Checked ;
            ApplicationConfiguration.AllRights=chkAllRights.Checked;
            ApplicationConfiguration.SyncOpen=chkSyncOpen.Checked;
            ApplicationConfiguration.ShowMainFormStatusBar=chkShowMainFormStatusBar.Checked;
            ApplicationConfiguration.CheckDictInput=chkCheckDictInput.Checked;
            ApplicationConfiguration.PassWordType = (ApplicationConfiguration.PassWordTypes)radioGroupPassword.SelectedIndex;
            ApplicationConfiguration.YouDaoRoomTitle=txtYouDaoRoomTitle.Text;
            //if (!ApplicationConfiguration.CustomSettingProvider.Equals(txtCustomSettingProvider.Text))
            //{
            //    ApplicationConfiguration.CustomSettingProvider = txtCustomSettingProvider.Text;
            //}
            //if (!ApplicationConfiguration.PermissionProvider.Equals(txtPermissionProvider.Text))
            //{
            //    ApplicationConfiguration.PermissionProvider = txtPermissionProvider.Text;
            //}
            //if (!ApplicationConfiguration.CustomDllName.Equals(txtCustomDllName.Text))
            //{
            //    ApplicationConfiguration.CustomDllName = txtCustomDllName.Text;
            //}
            //if (!string.Join(",", ApplicationConfiguration.MedicalDocumentList.ToArray()).Equals(txtMedicalDocumentList.Text))
            //{
            //    ApplicationConfiguration.MedicalDocumentList = new List<string>(txtMedicalDocumentList.Text.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries));
            //}
            //foreach (DataGridViewRow row in dgvDocumentClasses.Rows)
            //{
            //    ApplicationConfiguration.SetMedicalDocument(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
            //}
            //ApplicationConfiguration.SetMedicalDocument(ViewNames.OperationInformation, txtOperationInformationProvider.Text);
            //ApplicationConfiguration.SetMedicalDocument(ViewNames.OperationRegister, txtOperationRegisterProvider.Text);
            ApplicationConfiguration.IsYouDaoProgram = chkYouDao.Checked;
            //PACU管理系统
            ApplicationConfiguration.IsPACUProgram = chkPACUProgram.Checked;




            ApplicationConfiguration.AnesDocRange = string.IsNullOrEmpty(txtAnesDocRange.Text) ? 4 : int.Parse(txtAnesDocRange.Text);
            ApplicationConfiguration.PACUDocRange = string.IsNullOrEmpty(txtPACUDocRange.Text) ? 4 : int.Parse(txtPACUDocRange.Text); 





            //程序登入后是否弹出显示术中患者列表
            ApplicationConfiguration.IsShowUnDonePatientList = chkIsShowUnDonePatientListView.Checked;



            ApplicationConfiguration.MergeMonitorData=chkMergeMonitorData.Checked;
            ApplicationConfiguration.ShowDocumentScrollBar=chkShowDocumentScrollBar.Checked;
            ApplicationConfiguration.UseDefaultOperatingRoom=chkUseDefaultOperatingRoom.Checked;
            ApplicationConfiguration.IsUpdateScheduleStatus = chkIsUpdateScheduleStatus.Checked;
            ApplicationConfiguration.IsUpdateHisStatus = chkIsUpdateHisStatus.Checked;
            //手术状态
            List<string> list = new List<string>();
            foreach (DataGridViewRow row in dgvPatientStatusButtonsSelect.Rows)
            {
                list.Add(row.Cells[0].Value.ToString());
            }
            ApplicationConfiguration.PatientStatusButtons = string.Join(",", list.ToArray());
            //导航菜单
            ExtendApplicationContext.Current.StatusButtonStrList = _statusButtonStrList;
            ApplicationConfiguration.NoPatientButtons = _statusButtonStrList[ProgramStatus.NoPatient];
            ApplicationConfiguration.SelectPatientButtons = _statusButtonStrList[ProgramStatus.SelectPatient];
            ApplicationConfiguration.AnesthesiaRecordButtons = _statusButtonStrList[ProgramStatus.AnesthesiaRecord];
            ApplicationConfiguration.PACUButtons = _statusButtonStrList[ProgramStatus.PACURecord];
            //文书菜单
            OperationStatusHelper.SetOperDocument(_operDocuments);
            OperationStatusHelper.SetOperAction(_operActions);
            ApplicationConfiguration.AutoGenDocument = chkAutoGenDocument.Checked;



            //zhuanjia zixun
            ApplicationConfiguration.IsConnACS = chkAcs.Checked;
            ApplicationConfiguration.AcsAddress = txtAcsAddress.Text;

            ApplicationConfiguration.IsPACUProcess = chkPACUProcess.Checked;

            //提交更新到数据库
            ConfigurationProxy.UpdateConfigTableDataTable(ExtendApplicationContext.Current.ConfigTable);
        }

        #region 手术状态设置页面相关事件
        private void dgvPatientStatusButtons_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (grid.CurrentCell != null)
            {
                string text = grid.CurrentCell.Value.ToString();
                grid.Rows.Remove(grid.CurrentRow);
                dgvPatientStatusButtonsSelect.Rows.Add(new string[] { text });
            }
        }

        private void dgvPatientStatusButtonsSelect_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (grid.CurrentCell != null)
            {
                string text = grid.CurrentCell.Value.ToString();
                grid.Rows.Remove(grid.CurrentRow);
                dgvPatientStatusButtons.Rows.Add(new string[] { text });
            }
        }

        private void btnStatusUp_Click(object sender, EventArgs e)
        {
            MoveUp(dgvPatientStatusButtonsSelect);
        }

        private void btnStatusDown_Click(object sender, EventArgs e)
        {
            MoveDown(dgvPatientStatusButtonsSelect);
        }
        #endregion

        #region 导航菜单设置页面相关事件
        private void btnNavMenuUp_Click(object sender, EventArgs e)
        {
            MoveUp(dgvMenuSelected);
            modifyButtonStrList();
        }

        private void btnNavMenuDown_Click(object sender, EventArgs e)
        {
            MoveDown(dgvMenuSelected);
            modifyButtonStrList();
        }

        private void dgvMenuCanSelect_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (grid.CurrentCell != null)
            {
                string text = grid.CurrentCell.Value.ToString();
                grid.Rows.Remove(grid.CurrentRow);
                dgvMenuSelected.Rows.Add(new string[] { text });
                modifyButtonStrList();
            }
        }

        private void dgvMenuSelected_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (grid.CurrentCell != null)
            {
                string text = grid.CurrentCell.Value.ToString();
                grid.Rows.Remove(grid.CurrentRow);
                dgvMenuCanSelect.Rows.Add(new string[] { text });
                modifyButtonStrList();
            }
        }

        private void radioGroupProgramStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (radioGroupProgramStatus.SelectedIndex)
            {
                case 0:
                    _programStatus = ProgramStatus.NoPatient;
                    break;
                case 1:
                    _programStatus = ProgramStatus.SelectPatient;
                    break;
                case 2:
                    _programStatus = ProgramStatus.AnesthesiaRecord;
                    break;
                case 3:
                    _programStatus = ProgramStatus.PACURecord;
                    break;
                default:
                    _programStatus = ProgramStatus.NoPatient;
                    break;
            }
            _currentButtonStrings = _statusButtonStrList[_programStatus].Split(new char[] { ';' }, StringSplitOptions.None);
            SetNavigateAndGrid(_currentButtonStrings, comboBoxEditSample.SelectedIndex);
        }

        private void comboBoxEditSample_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetNavigateAndGrid(_currentButtonStrings, comboBoxEditSample.SelectedIndex);
        }
        #endregion

        #region 文书菜单设置页面相关事件
        private void cmbOperationStatusNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDocumentNames.Rows.Clear();
            dgvActions.Rows.Clear();
            dgvSelectedDoc.Rows.Clear();
            dgvSelectedActions.Rows.Clear();

            //Dictionary<string, MedicalDocElement> docKeyValuePairs = MedicalDocSettings.GetMedicalDocNameAndPath();
            //foreach (KeyValuePair<string, MedicalDocElement> keyValuePair in docKeyValuePairs)
            //{
            //    dgvDocumentNames.Rows.Add(new string[] { keyValuePair.Key });
            //    dgvActions.Rows.Add(new string[] { keyValuePair.Key });
            //}
            List<string> docs = ApplicationConfiguration.MedicalDocumentList;
            foreach (string s in docs)
            {
                dgvDocumentNames.Rows.Add(new string[] { s });
                dgvActions.Rows.Add(new string[] { s });
            }
            dgvActions.Rows.Add(new string[] { ViewNames.SetMonitor });

            string text = cmbOperationStatusNames.Text;
            text = _operDocuments[text];
            if (!string.IsNullOrEmpty(text))
            {
                int index = text.IndexOf(";");
                string s1 = text;
                if (index >= 0)
                {
                    s1 = text.Substring(0, index);
                }
                //string s2 = text.Substring(index + 1);
                string[] list = s1.Split(',');
                foreach (string s in list)
                {
                    if (!string.IsNullOrEmpty(s))
                    {
                        dgvSelectedDoc.Rows.Add(new string[] { s });
                        RemoveFromGrid(dgvDocumentNames, s);
                    }
                }
            }

            text = _operActions[cmbOperationStatusNames.Text];
            if (!string.IsNullOrEmpty(text))
            {
                string[] list = text.Split(',');
                foreach (string s in list)
                {
                    if (!string.IsNullOrEmpty(s))
                    {
                        dgvSelectedActions.Rows.Add(new string[] { s });
                        RemoveFromGrid(dgvActions, s);
                    }
                }
            }
        }

        private void dgvDocumentNames_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (grid.CurrentCell != null)
            {
                string text = grid.CurrentCell.Value.ToString();
                grid.Rows.Remove(grid.CurrentRow);
                dgvSelectedDoc.Rows.Add(new string[] { text });
            }
            ChangeOperDocument();
        }

        private void dgvSelectedDoc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (grid.CurrentCell != null)
            {
                string text = grid.CurrentCell.Value.ToString();
                grid.Rows.Remove(grid.CurrentRow);
                dgvDocumentNames.Rows.Add(new string[] { text });
            }
            ChangeOperDocument();
        }

        private void dgvActions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (grid.CurrentCell != null)
            {
                string text = grid.CurrentCell.Value.ToString();
                grid.Rows.Remove(grid.CurrentRow);
                dgvSelectedActions.Rows.Add(new string[] { text });
            }
            ChangeOperAction();
        }

        private void dgvSelectedActions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (grid.CurrentCell != null)
            {
                string text = grid.CurrentCell.Value.ToString();
                grid.Rows.Remove(grid.CurrentRow);
                dgvActions.Rows.Add(new string[] { text });
            }
            ChangeOperAction();
        }

        private void btnDocUp_Click(object sender, EventArgs e)
        {
            MoveUp(dgvSelectedDoc);
            ChangeOperDocument();
        }

        private void btnDocDown_Click(object sender, EventArgs e)
        {
            MoveDown(dgvSelectedDoc);
            ChangeOperDocument();
        }

        private void btnActionUp_Click(object sender, EventArgs e)
        {
            MoveUp(dgvSelectedActions);
            ChangeOperAction();
        }

        private void btnActionDown_Click(object sender, EventArgs e)
        {
            MoveDown(dgvSelectedActions);
            ChangeOperAction();
        }

        #endregion

        private void txtCustomDllName_DoubleClick(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory,"*Custom*.Dll");
            if (files.Length > 0)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    files[i] = FileHelper.GetFileNameWithoutPathAndExt(files[i]);
                }
            }
            Dialog.ShowCustomSelection(files,null,txtCustomDllName,new Size(300,300),new EventHandler(delegate(object s1,EventArgs e1)
                {
                    if(s1 is int)
                    {
                        txtCustomDllName.Text = files[(int)s1];
                    }
                }));
        }

        private void txtPermissionProvider_EditValueChanged(object sender, EventArgs e)
        {

        }

        private string SetDocSettings(string initText)
        {
            string text = initText;
            DialogHostForm dialogHostForm = new DialogHostForm("", 600, 300);
            Panel panel = new Panel();
            Panel panel1 = new Panel();
            DataGridView grid = new DataGridView();
            dialogHostForm.Child = panel;
            grid.Columns.Add("Caption", "标题");
            grid.Columns.Add("Key", "键名");
            grid.Columns.Add("Path", "文件");
            grid.Columns.Add("Type", "类全名");
            grid.Columns[2].Width = 200;
            List<string> list = new List<string>();
            if (!string.IsNullOrEmpty(text))
            {
                list = new List<string>(text.Split(','));
            }
            if (list.Count > 4)
            {
                list[3] = list[3] + "," + list[4];
                list.RemoveRange(4, list.Count - 4);
            }
            while(list.Count < 4)
            {
                list.Add("");
            }
            grid.Rows.Add(list.ToArray());
            grid.Columns[1].ReadOnly = true;
            grid.Columns[2].ReadOnly = true;
            grid.Columns[3].ReadOnly = true;
            grid.RowHeadersVisible = false;
            grid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
            MedButton btn1 = new MedButton();
            btn1.Text = "确定";
            btn1.DialogResult = DialogResult.OK;
            MedButton btn2 = new MedButton();
            btn2.Text = "取消";
            btn2.DialogResult = DialogResult.Cancel;
            panel.Controls.Add(grid);
            panel.Controls.Add(panel1);
            panel1.Height = 50;
            panel1.Dock = DockStyle.Bottom;
            grid.Dock = DockStyle.Fill;
            panel1.Controls.Add(btn1);
            panel1.Controls.Add(btn2);
            btn1.Left = 10;
            btn1.Top = 5;
            btn2.Top = 5;
            btn2.Left = 100;
            if(dialogHostForm.ShowDialog() == DialogResult.OK)
            {
                text = grid.Rows[0].Cells[0].Value + "," + grid.Rows[0].Cells[1].Value + "," + grid.Rows[0].Cells[2].Value + "," + grid.Rows[0].Cells[3].Value;
            }
            return text;
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 3 && !string.IsNullOrEmpty(txtCustomDllName.Text))
                {
                    List<string> list = new List<string>();
                    string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*Custom*.Dll");
                    if (files.Length > 0)
                    {
                        foreach (string fileName in files)
                        {
                            string moduleName = FileHelper.GetFileNameWithoutPathAndExt(fileName);
                            if (moduleName.Equals(txtCustomDllName.Text))
                            {
                                Assembly assembly = Assembly.LoadFile(fileName);
                                Type[] types = assembly.GetTypes();
                                foreach (Type type in types)
                                {
                                    string typeName = type.FullName;
                                    string text = typeName + "," + moduleName;
                                    if (!list.Contains(text))
                                    {
                                        list.Add(text);
                                    }
                                }
                                break;
                            }
                        }
                    }
                    if (list.Count > 0)
                    {
                        Rectangle rect = grid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                        int w = rect.Width;
                        if (w < 400)
                        {
                            w = 400;
                        }
                        Dialog.ShowCustomSelection(list, null, grid,new Point(rect.Left, rect.Bottom), new Size(w, 300), new EventHandler(delegate(object s1, EventArgs e1)
                        {
                            if (s1 is int)
                            {
                                int index = (int)s1;
                                grid.CurrentCell.Value = list[(int)s1];
                                grid.CurrentCell = grid.CurrentRow.Cells[1];
                                grid.CurrentCell = grid.CurrentRow.Cells[e.ColumnIndex];
                            }
                        }));
                    }
                }
                else if (e.ColumnIndex == 2)
                {
                    string fileName = "";
                    if(grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                    {
                        fileName = grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        if(!string.IsNullOrEmpty(fileName.Trim()) && !fileName.StartsWith(AppDomain.CurrentDomain.BaseDirectory))
                        {
                            fileName = AppDomain.CurrentDomain.BaseDirectory + fileName;
                        }
                    }
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.DefaultExt = "xml";
                    dialog.Filter = "Xml Files|*.xml";
                    dialog.FileName = fileName;
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        fileName = dialog.FileName;
                        if (fileName.StartsWith(AppDomain.CurrentDomain.BaseDirectory))
                        {
                            fileName = fileName.Substring(AppDomain.CurrentDomain.BaseDirectory.Length);
                        }
                        grid.CurrentCell.Value = fileName;
                        grid.CurrentCell = grid.CurrentRow.Cells[0];
                        grid.CurrentCell = grid.CurrentRow.Cells[e.ColumnIndex];
                    }
                }
            }
        }

        private void txtOperationInformationProvider_DoubleClick(object sender, EventArgs e)
        {
            string text = SetDocSettings(txtOperationInformationProvider.Text);
            if (!txtOperationInformationProvider.Text.Equals(text))
            {
                txtOperationInformationProvider.Text = text;
            }
        }

        private void txtOperationRegisterProvider_DoubleClick(object sender, EventArgs e)
        {
            string text = SetDocSettings(txtOperationRegisterProvider.Text);
            if (!txtOperationRegisterProvider.Text.Equals(text))
            {
                txtOperationRegisterProvider.Text = text;
            }
        }

        private void dgvDocumentClasses_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 1)
                {
                    string text = "";
                    if (dgvDocumentClasses.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                    {
                        text = dgvDocumentClasses.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    }
                    text = SetDocSettings(text);
                    dgvDocumentClasses.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = text;
                    dgvDocumentClasses.CurrentCell = dgvDocumentClasses.Rows[e.RowIndex].Cells[0];
                    dgvDocumentClasses.CurrentCell = dgvDocumentClasses.Rows[e.RowIndex].Cells[e.ColumnIndex];
                }
            }
        }

        private void chkAcs_CheckedChanged(object sender, EventArgs e)
        {
            txtAcsAddress.Visible = chkAcs.Checked;
            lbAcsAddress.Visible = chkAcs.Checked;
        }

    }
}
