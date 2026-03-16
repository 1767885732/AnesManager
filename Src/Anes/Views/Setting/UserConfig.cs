/*----------------------------------------------------------------
      // Copyright (C) 2010 北京拓扑工厂科技发展有限公司
      // 文件名：UserConfig.cs
      // 文件功能描述：配置类
      //
      // 
      // 创建标识：
      // 修改标识：XXX-2010-09-26（优化代码、增加状态医疗文书配置）
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using Wis.Anes.Framework.Controls.Base;
using Wis.Anes.Framework.Controls;
using Wis.Anes.BusinessEntity;
using Wis.Anes.ServiceProxies;
using Wis.Anes.Framework.Utilities;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.Framework;
using Wis.Anes.Framework.Views;
using Wis.Anes.Layouts;
using Wis.Anes.Constants;
using System.Xml;
using System.IO;
using System.Collections;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;

namespace Wis.Anes.Views
{
    /// <summary>
    /// 配置类
    /// </summary>
    [ToolboxItem(false)]
    public partial class UserConfig : BaseView
    {
        #region 变量
        private PageSetupDialog pageSetupDialog;
        //private bool pdfChanged = false;
        private readonly string ButtonTitle = "按钮标题";
        private readonly string LiquidAttrs = "液体属性";
        #endregion 变量

        #region 方法

        /// <summary>
        /// 构造方法
        /// </summary>
        public UserConfig()
        {
            InitializeComponent();
            //systemConfig1.Load += new EventHandler(systemConfig1_Load);
            Caption = ViewNames.UserConfig;
            if (!DesignMode)
            {
                //if (!Globals.IsMdsd)
                //{
                //    tabControl1.TabPages.Remove(TabPageSystem);
                //}
                List<MemberDetail> list = AssemblyHelper.GetEnumList(typeof(ProLongedDrugUnitShowType), true);
                foreach (MemberDetail item in list)
                {
                    cmbProLonged.Properties.Items.Add(item);
                }
                list = AssemblyHelper.GetEnumList(typeof(NormalDrugUnitShowType), true);
                foreach (MemberDetail item in list)
                {
                    cmbDrugShow.Properties.Items.Add(item);
                }
            }
        }

        //void systemConfig1_Load(object sender, EventArgs e)
        //{
        //    if (!DesignMode)
        //    {
        //        systemConfig1.Init();
        //    }
        //}


        private void SetGridViewProperties(DataGridView grid)
        {
            grid.Columns.Add("Item", "Item");
            grid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.ColumnHeadersVisible = false;
            grid.RowHeadersVisible = false;
            grid.ReadOnly = true;
            grid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            grid.MultiSelect = false;
            grid.GridColor = grid.BackgroundColor;
        }

        /// <summary>
        /// 上移医疗文书顺序
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
        /// 下移医疗文书顺序
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

        #endregion 方法

        #region 事件

        private void btnPDFSet_Click(object sender, EventArgs e)
        {
            if (pageSetupDialog.ShowDialog() == DialogResult.OK)
            {
                //pdfChanged = true;
            }
        }

        private string GetOutList()
        {
            DataTable dataTable = null;
            if (dataGridViewOutList.DataSource != null && dataGridViewOutList.DataSource is DataTable)
            {
                dataTable = ((DataTable)dataGridViewOutList.DataSource);
            }
            string list = "";
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row[0] != null && row[0] != System.DBNull.Value && !string.IsNullOrEmpty(row[0].ToString()))
                    {
                        list += "," + row[0].ToString();
                    }
                }
                if (!string.IsNullOrEmpty(list))
                {
                    list = list.Substring(1);
                }
            }
            return list;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            int modifyDays = 0;
            if (!int.TryParse(txtModifyDays.Text, out modifyDays))
            {
                modifyDays = 0;
            }
            if (!string.IsNullOrEmpty(ApplicationConfiguration.GetCustomConfig("CanConfigOutList")))
            {
                ApplicationConfiguration.OutList = GetOutList();
            }
            ApplicationConfiguration.ModifyDays = modifyDays;
            //Configurations.QianBingXing = txtQianBingXing.Text;
            //Configurations.QuanXunHuan = txtQuanXunHuan.Text;
            //Configurations.HouBingXing = txtHouBingXing.Text;
            //Configurations.YouDaoColor = lblYouDaoColor.ForeColor;
            //if (Configurations.InOperationPanelTimeH != rdbHorizontal.Checked)
            //{
            //    Configurations.InOperationPanelTimeH = rdbHorizontal.Checked;
            //}
            ApplicationConfiguration.NoDosage = txtNoDosage.Text;
            ApplicationConfiguration.OpertionRoom = txtOpertionRoom.Text;
            ApplicationConfiguration.OpertionDeptCode = txtWardCode.Text;
            ApplicationConfiguration.AnesthesiaWardCode = txtAnesthesiaWardCode.Text;

            //持续用药自动结束 
            ApplicationConfiguration.DrugAutoStop = chkDrugAutoStop.Checked;
            ApplicationConfiguration.DrugAutoStopOperationStatus = cmbDrugStopOperationStatus.Text;


            int ret = 0;
            if (!int.TryParse(txtAnesthesiaNumber.Text, out ret))
            {
                ret = 120000;
            }
            ApplicationConfiguration.AnesthesiaNumber = ret;
            ApplicationConfiguration.SyncScheduleInfoMode = radioGroupSyncScheduleInfo.SelectedIndex;
            ApplicationConfiguration.SyncDateDiff = (int)numericUpDownSync.Value;
            ApplicationConfiguration.OperationDoneDays = (int)numericUpDownOperDone.Value;
            ApplicationConfiguration.CanRunManey = chkCanRunManey.Checked;
            ApplicationConfiguration.UseDefaultSelectedMonitorLabel = chkUseDefaultSelectedMonitorLabel.Checked;
            ApplicationConfiguration.DrugShow = cmbDrugShow.SelectedIndex;
            ApplicationConfiguration.ProLonged = cmbProLonged.SelectedIndex;
            ApplicationConfiguration.DoubleSelect = chkDoubleSelect.Checked;
            ApplicationConfiguration.PromptBeforeExit = chkPromptBeforeExit.Checked;
            ApplicationConfiguration.IsModifyVitalSignShowDifferent = chkModifyVitalSignShowDifferent.Checked;




            DataTable dataTable = dataGridView1.DataSource as DataTable;
            if (dataTable != null)
            {
                string buttons = ",";
                foreach (DataRow row in dataTable.Rows)
                {
                    buttons += row[ButtonTitle].ToString() + ",";
                }
                ApplicationConfiguration.AnesEventButtons = buttons.Substring(1);
            }
            dataTable = dataGridView2.DataSource as DataTable;
            if (dataTable != null)
            {
                string buttons = ",";
                foreach (DataRow row in dataTable.Rows)
                {
                    buttons += row[LiquidAttrs].ToString() + ",";
                }
                ApplicationConfiguration.LiquidAttrs = buttons.Substring(1);
            }
            dataTable = dataGridView3.DataSource as DataTable;
            Dict.BloodGasDictDataTable table = DictProxy.GetBloodGasDict();
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (DataRow rw in table.Rows)
                {
                    if (rw["BLG_CODE"].Equals(row["BLG_CODE"]) && rw["BLG_SHOWID"].Equals(row["BLG_SHOWID"]))
                    {
                        rw["BLG_NAME"] = row["BLG_NAME"];
                        rw["BLG_STATUS"] = ((bool)row["Selected"]) ? "1" : "0";
                    }
                }
            }
            DictProxy.UpdateBloodGasDict(table);

            //if (Globals.IsRichUser || Globals.IsMdsd)
            //{
            //    systemConfig1.Save();
            //}

            if (_PatMonitorDataDictDataTable != null)
            {
                DictProxy.UpdatePatMonitorDataDict(_PatMonitorDataDictDataTable);
            }
            if ((!ApplicationConfiguration.IsPACUProgram && (ExtendApplicationContext.Current.AppType == ApplicationType.Anesthesia)) && this.chkIsModifyMonitorSetting.Checked)
            {
                string path = Application.StartupPath + @"\DataLog.ini";
                if (File.Exists(path))
                {
                    StringBuilder retVal = new StringBuilder(500);
                    int num3 = WinAPI.GetPrivateProfileString("dept", "bed_no", "", retVal, 500, path);
                    string str3 = retVal.ToString();
                    if (!(!string.IsNullOrEmpty(str3) && this.txtOpertionRoom.Text.Trim().Equals(str3)))
                    {
                        WinAPI.WritePrivateProfileString("dept", "bed_no", this.txtOpertionRoom.Text.Trim(), path);
                    }
                }
                else
                {
                    Dialog.MessageBox("程序文件夹找不到名为DataLog.ini的采集配置文件");
                }
            }

            // 收费配置
            try
            {
                //Dict.WIS_DICT_BILL_CONFIGDataTable tableBillCfg = gridBillCfg.DataSource as Dict.WIS_DICT_BILL_CONFIGDataTable;
                //if (tableBillCfg != null)
                //    DictProxy.UpdateBillCfgDict(tableBillCfg);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "收费配置列表保存时发生错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }



            //文书上传设置

            ApplicationConfiguration.PDFServerUrl = txtPDFServerUrl.Text;
            ApplicationConfiguration.PDFLocalUrl = txtPDFLocalUrl.Text;


            ApplicationConfiguration.IsDeleteAfterCommitDoc = chkDeleteAfterCommitDoc.Checked;

            List<string> fileList = new List<string>();
            foreach (CheckedListBoxItem boxItem in chkUpFileList.Items)
            {
                if (boxItem.CheckState == CheckState.Checked)
                {
                    fileList.Add(boxItem.Value.ToString());
                }
            }
            ApplicationConfiguration.PostPDF_Names = string.Join(",", fileList.ToArray());



            fileList.Clear();
            foreach (CheckedListBoxItem boxItem in chkDocCheckList.Items)
            {
                if (boxItem.CheckState == CheckState.Checked)
                {
                    fileList.Add(boxItem.Value.ToString());
                }
            }
            ApplicationConfiguration.DocNameCheckList = string.Join(",", fileList.ToArray());


            //打印设置
            try
            {
                ApplicationConfiguration.PrintPageName = medTextBoxPageName.Text;
                //PrintPaperHeight
                float resultValue = 0f;
                if (!float.TryParse(medTextBoxPaperHeight.Text, out resultValue))
                {
                    resultValue = 0f;
                }
                ApplicationConfiguration.PrintPaperHeight = resultValue;

                //PrintPaperWidth
                resultValue = 0f;
                if (!float.TryParse(medTextBoxPaperWidth.Text, out resultValue))
                {
                    resultValue = 0f;
                }
                ApplicationConfiguration.PrintPaperWidth = resultValue;


                //PaperLeftOff
                resultValue = 0.5f;
                if (!float.TryParse(medTextBoxPaperLeftOff.Text, out resultValue))
                {
                    resultValue = 0.5f;
                }
                ApplicationConfiguration.PaperLeftOff = resultValue;

                //PaperTopOff
                resultValue = 1f;
                if (!float.TryParse(medTextBoxPaperTopOff.Text, out resultValue))
                {
                    resultValue = 1f;
                }
                ApplicationConfiguration.PaperTopOff = resultValue;


            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "打印设置保存时发生错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }




            ConfigurationProxy.UpdateConfigTableDataTable(ExtendApplicationContext.Current.ConfigTable);



        }

        private void SetOutList()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("列表");
            string outList = ApplicationConfiguration.OutList;
            if (!string.IsNullOrEmpty(outList))
            {
                string[] list = outList.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string text in list)
                {
                    DataRow row = dataTable.NewRow();
                    row[0] = text;
                    dataTable.Rows.Add(row);
                }
            }
            dataGridViewOutList.DataSource = dataTable;
        }

        private void UserConfig_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                if (ExtendApplicationContext.Current.LoginUserContext.IsManager)
                {
                    btnSuperConfig.Visible = true;
                }
                cmbDrugShow.SelectedIndex = ApplicationConfiguration.DrugShow;
                cmbProLonged.SelectedIndex = ApplicationConfiguration.ProLonged;
                chkDoubleSelect.Checked = ApplicationConfiguration.DoubleSelect;
                chkCanRunManey.Checked = ApplicationConfiguration.CanRunManey;
                chkUseDefaultSelectedMonitorLabel.Checked = ApplicationConfiguration.UseDefaultSelectedMonitorLabel;
                chkPromptBeforeExit.Checked = ApplicationConfiguration.PromptBeforeExit;

                chkModifyVitalSignShowDifferent.Checked = ApplicationConfiguration.IsModifyVitalSignShowDifferent;
                //Configurations.EventNo = (ApplicationConfiguration.PACUDesc.Equals("PACU") ? 1 : 0);
                txtModifyDays.Text = ApplicationConfiguration.ModifyDays.ToString();
                if (!string.IsNullOrEmpty(ApplicationConfiguration.GetCustomConfig("CanConfigOutList")))
                {
                    SetOutList();
                }
                else
                {
                    tabControl1.TabPages.Remove(xtraTabPage3);
                }
                //txtHouBingXing.Text = Configurations.HouBingXing;
                //txtQianBingXing.Text = Configurations.QianBingXing;
                //txtQuanXunHuan.Text = Configurations.QuanXunHuan;
                //lblYouDaoColor.ForeColor = Configurations.YouDaoColor;
                //if (Configurations.InOperationPanelTimeH)
                //{
                //    rdbHorizontal.Checked = true;
                //}
                //else
                //{
                //    rdbVertical.Checked = true;
                //}
                txtNoDosage.Text = ApplicationConfiguration.NoDosage;
                txtOpertionRoom.Text = ApplicationConfiguration.OpertionRoom;
                txtWardCode.Text = ApplicationConfiguration.OpertionDeptCode;
                txtAnesthesiaWardCode.Text = ApplicationConfiguration.AnesthesiaWardCode;


                //持续用药自动结束 
                chkDrugAutoStop.Checked = ApplicationConfiguration.DrugAutoStop;
                cmbDrugStopOperationStatus.Text = ApplicationConfiguration.DrugAutoStopOperationStatus;
                cmbDrugStopOperationStatus.Visible = chkDrugAutoStop.Checked;

                //打印设置
                medTextBoxPageName.Text = ApplicationConfiguration.PrintPageName;
                medTextBoxPaperHeight.Text = ApplicationConfiguration.PrintPaperHeight.ToString();
                medTextBoxPaperWidth.Text = ApplicationConfiguration.PrintPaperWidth.ToString();
                medTextBoxPaperLeftOff.Text = ApplicationConfiguration.PaperLeftOff.ToString();
                medTextBoxPaperTopOff.Text = ApplicationConfiguration.PaperTopOff.ToString();


                //文书上传设置
                txtPDFServerUrl.Text = ApplicationConfiguration.PDFServerUrl;
                txtPDFLocalUrl.Text = ApplicationConfiguration.PDFLocalUrl;

                chkDeleteAfterCommitDoc.Checked = ApplicationConfiguration.IsDeleteAfterCommitDoc;
                List<string> fileList = new List<string>();
                List<string> fileListDocCheck = new List<string>();
                if (!string.IsNullOrEmpty(ApplicationConfiguration.PostPDF_Names))
                {
                    IEnumerator ie = ApplicationConfiguration.PostPDF_Names.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).GetEnumerator();
                    while (ie.MoveNext())
                    {
                        fileList.Add(ie.Current.ToString());

                    }
                }

                if (!string.IsNullOrEmpty(ApplicationConfiguration.DocNameCheckList))
                {
                    IEnumerator ie = ApplicationConfiguration.DocNameCheckList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).GetEnumerator();
                    while (ie.MoveNext())
                    {
                        fileListDocCheck.Add(ie.Current.ToString());

                    }
                }

                Dictionary<string, MedicalDocElement> docKeyValuePairs = MedicalDocSettings.GetMedicalDocNameAndPath();

                foreach (KeyValuePair<string, MedicalDocElement> keyValuePair in docKeyValuePairs)
                {
                    CheckedListBoxItem boxItem = new CheckedListBoxItem(keyValuePair.Key, keyValuePair.Value.Key);
                    //上传文件检查
                    chkUpFileList.Items.Add(boxItem);



                    if (fileList.Contains(keyValuePair.Key))
                    {
                        boxItem.CheckState = CheckState.Checked;
                    }

                    CheckedListBoxItem boxItemDocCheck = new CheckedListBoxItem(keyValuePair.Key, keyValuePair.Value.Key);

                    //文书检查
                    chkDocCheckList.Items.Add(boxItemDocCheck);

                    if (fileListDocCheck.Contains(keyValuePair.Key))
                    {
                        boxItemDocCheck.CheckState = CheckState.Checked;
                    }

                }




                txtAnesthesiaNumber.Text = ApplicationConfiguration.AnesthesiaNumber.ToString();
                radioGroupSyncScheduleInfo.SelectedIndex = ApplicationConfiguration.SyncScheduleInfoMode;

                numericUpDownSync.Value = ApplicationConfiguration.SyncDateDiff;
                numericUpDownOperDone.Value = ApplicationConfiguration.OperationDoneDays;
                pageSetupDialog = new PageSetupDialog();
                //pageSetupDialog.PageSettings = new PageSettings();
                //pageSetupDialog.PrinterSettings = new PrinterSettings();
                //string printName = ApplicationConfiguration.PDFPrintName;
                //if (!string.IsNullOrEmpty(printName) && PrinterHelper.IsPrintExist(printName))
                //{
                //    pageSetupDialog.PrinterSettings.PrinterName = printName;
                //}
                //pageSetupDialog.PageSettings.Margins.Left = ApplicationConfiguration.PDFLeftMargin;


                string eventButtons = ApplicationConfiguration.AnesEventButtons;
                string[] buttons = eventButtons.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add(ButtonTitle);
                foreach (string text in buttons)
                {
                    DataRow row = dataTable.NewRow();
                    row[ButtonTitle] = text;
                    dataTable.Rows.Add(row);
                }
                dataGridView1.DataSource = dataTable;
                // dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                buttons = ApplicationConfiguration.LiquidAttrs.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                dataTable = new DataTable();
                dataTable.Columns.Add(LiquidAttrs);
                foreach (string text in buttons)
                {
                    DataRow row = dataTable.NewRow();
                    row[LiquidAttrs] = text;
                    dataTable.Rows.Add(row);
                }
                dataGridView2.DataSource = dataTable;

                dataTable = DictProxy.GetBloodGasDict();
                dataTable.Columns.Add("Selected", typeof(bool));
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["BLG_STATUS"].Equals("0"))
                    {
                        row["Selected"] = false;
                    }
                    if (row["BLG_STATUS"].Equals("1"))
                    {
                        row["Selected"] = true;
                    }
                }
                //this.dataGridView3.AutoGenerateColumns = false;
                dataGridView3.DataSource = dataTable;
                txtButtonsCount.Text = ApplicationConfiguration.DosageButtonsCount.ToString();

                //if (Globals.IsMdsd || Globals.IsRichUser)
                //{
                //    tabControl1.SelectedTabPage = TabPageSystem;
                //}




                if (ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_MONITOR_FUNC_CODE"))
                {
                    _monitorFunctionCode = ExtendApplicationContext.Current.CodeTables["WIS_MONITOR_FUNC_CODE"] as Dict.MonitorFunctionCodeDataTable;
                }
                if (_monitorFunctionCode == null)
                {
                    _monitorFunctionCode = DictProxy.GetMonitorFunctionCode();
                }
                _PatMonitorDataDictDataTable = DictProxy.GetPatMonitorDataDict();
                gridControlMonitor.DataSource = _PatMonitorDataDictDataTable;


                // 收费配置
                try
                {
                    //XmlDataDocument doc = new XmlDataDocument();
                    //string xmlpath = System.Configuration.ConfigurationManager.AppSettings.Get("BillCfgPath");
                    //if (xmlpath != null)
                    //{
                    //    doc.Load(xmlpath);
                    //    gridBillCfg.ColumnConfig = doc.LastChild.ChildNodes;

                    //    Dict.WIS_DICT_BILL_CONFIGDataTable table = DictProxy.GetBillCfgDict();
                    //    gridBillCfg.DataSource = table;
                    //}
                    //else
                    //{
                    //    Logger.Write("警告：收费配置列表初始化列时发生错误,缺少配置项BillCfgPath！");
                    //}

                }
                catch (Exception err)
                {
                    // MessageBox.Show(err.Message, "收费配置列表初始化列时发生错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ExceptionHandler.Handle(err);
                }
            }
        }


        //private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        //{
        //    if (e.RowIndex < 0 || e.ColumnIndex < 0)
        //    {
        //       // GridViewHelper.DataGridViewCellPainting(e);
        //    }
        //}

        private void txtWardCode_Click(object sender, EventArgs e)
        {
        }

        private void lblYouDaoColor_Click(object sender, EventArgs e)
        {
            //ColorDialog dialog = new ColorDialog();
            //if (dialog.ShowDialog() == DialogResult.OK)
            //{
            //    lblYouDaoColor.ForeColor = dialog.Color;
            //}
        }

        private void txtOpertionRoom_Click(object sender, EventArgs e)
        {
        }

        private void txtWardCode_DoubleClick(object sender, EventArgs e)
        {
            Dict.DeptDictDataTable deptDict = DictProxy.GetDeptDict();
            Dialog.ShowCustomSelection(deptDict, deptDict.DEPT_NAMEColumn.ToString(), txtWardCode, new Point(0, txtWardCode.Height), new Size(100, 300)
                , new EventHandler(delegate(object s1, EventArgs e1)
                {
                    if (s1 is int)
                    {
                        int index = (int)s1;
                        txtWardCode.Text = deptDict[index].DEPT_CODE;
                    }
                }));
        }

        private void txtOpertionRoom_DoubleClick(object sender, EventArgs e)
        {
            Dict.OperatingRoomDataTable room = DictProxy.GetOperatingRoomDict(0);
            Dialog.ShowCustomSelection(room, "ROOM_NO", txtOpertionRoom, new Point(0, txtOpertionRoom.Height), new Size(100, 300)
                , new EventHandler(delegate(object s1, EventArgs e1)
                {
                    if (s1 is int)
                    {
                        int index = (int)s1;
                        txtOpertionRoom.Text = room[index].ROOM_NO;
                    }
                    else if (s1 is int[])
                    {
                        string s = "";
                        foreach (int i in (s1 as int[]))
                        {
                            s = s + "," + room[i].ROOM_NO;
                        }
                        txtOpertionRoom.Text = s.Substring(1);
                    }
                }), true);
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)//控制管理员编号为数值
        {

            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '\b')// '\b'表示可以删除键有用
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {

        }


        private void btnSuperConfig_Click(object sender, EventArgs e)
        {
            DialogHostForm dialogHostForm = new DialogHostForm();
            dialogHostForm.StartPosition = FormStartPosition.CenterParent;
            dialogHostForm.Size = new Size(800, 600);
            //dialogHostForm.WindowState = FormWindowState.Maximized;
            dialogHostForm.Text = "超级配置";
            SystemConfig view = new SystemConfig();
            dialogHostForm.Child = view;
            dialogHostForm.ShowDialog();
        }


        //===================================体征配置项=======================//

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            Dialog.ShowCustomSelection(_monitorFunctionCode, "ITEM_NAME,ITEM_CODE", btnAddItem, new Size(300, 300), new EventHandler(AddItem));
        }

        //2014-5-27 周青 删除体征报警选项
        /// <summary>
        /// 删除体征报警选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            DataRow selectRow = gridView5.GetFocusedDataRow();

            if (selectRow != null)
            {
                for (int i = 0; i < _PatMonitorDataDictDataTable.Rows.Count; i++)
                {
                    Dict.WisPatMonitorDataDictRow dr = _PatMonitorDataDictDataTable.Rows[i] as Dict.WisPatMonitorDataDictRow;
                    if (dr.Equals(selectRow))
                    {
                        _PatMonitorDataDictDataTable.Rows[i].Delete();
                    }
                }
                DictProxy.UpdatePatMonitorDataDict(_PatMonitorDataDictDataTable);
            }
        }

        private Dict.MonitorFunctionCodeDataTable _monitorFunctionCode = null;
        private Dict.WisPatMonitorDataDictDataTable _PatMonitorDataDictDataTable = null;

        private void toolStripMenuNewItem_Click(object sender, EventArgs e)
        {
            Button btn = new Button();
            Dialog.ShowCustomSelection(_monitorFunctionCode, "ITEM_NAME", btn, new Size(300, 300), new EventHandler(AddItem));
            //VitalSignItemSelecter vitalSignItemSelecter = new VitalSignItemSelecter();
            //DialogHostForm dialogHostForm = new DialogHostForm("新增体征预警项", 400, 100);
            //dialogHostForm.Child = vitalSignItemSelecter;
            //dialogHostForm.ShowDialog();
        }
        private void AddItem(object sender, EventArgs e)
        {
            if (sender is int)
            {
                int index = (int)sender;
                if (_PatMonitorDataDictDataTable == null) _PatMonitorDataDictDataTable = new Dict.WisPatMonitorDataDictDataTable();

                foreach (Dict.WisPatMonitorDataDictRow dtRow in _PatMonitorDataDictDataTable.Rows)
                {
                    if (dtRow.DB_DATA_NAME.Trim().Equals(_monitorFunctionCode[index].ITEM_CODE)) return;
                }

                Dict.WisPatMonitorDataDictRow row = _PatMonitorDataDictDataTable.NewWisPatMonitorDataDictRow();
                row.DB_DATA_NAME = _monitorFunctionCode[index].ITEM_CODE;
                row.MONITOR_DATA_NAME = _monitorFunctionCode[index].ITEM_NAME;
                row.PAT_ID = "0";
                row.VISIT_ID = 0;

                _PatMonitorDataDictDataTable.Rows.Add(row);
                gridControlMonitor.DataSource = _PatMonitorDataDictDataTable;

            }
        }

        private void btnOutListAdd_Click(object sender, EventArgs e)
        {
            if (dataGridViewOutList.DataSource != null && dataGridViewOutList.DataSource is DataTable)
            {
                ((DataTable)dataGridViewOutList.DataSource).Rows.Add(new object[] { "" });
            }
        }

        private void btnAddInoperationButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource != null && dataGridView1.DataSource is DataTable)
            {
                ((DataTable)dataGridView1.DataSource).Rows.Add(new object[] { "" });
            }
        }

        #endregion 事件

        private void xtraTabPage3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }


        // 增加费用记录
        private void medButtonAddBillCfg_Click(object sender, EventArgs e)
        {
            gridBillCfg.AddNewRow();
        }

        private void chkDrugAutoStop_CheckedChanged(object sender, EventArgs e)
        {
            //持续用药自动结束 
            cmbDrugStopOperationStatus.Visible = chkDrugAutoStop.Checked;
        }

        //private void chkAcs_CheckedChanged(object sender, EventArgs e)
        //{
        //    txtAcsAddress.Visible = chkAcs.Checked;
        //    lbAcsAddress.Visible = chkAcs.Checked;
        //}



        //医疗文书完整性检查
        private void btnDocCheckItemUp_Click(object sender, EventArgs e)
        {
            if (chkDocCheckList.SelectedIndex > 0)
            {

            }
        }

        private void btnDocCheckItemDown_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 预警验证最小值一定小于最大值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView5_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            int _cellValueLow = 0;
            int _cellValueHigh = 0;

            GridView view = sender as GridView;
            view.ClearColumnErrors();
            int.TryParse(view.GetRowCellValue(e.RowHandle, "LOW_SIGNS_VALUES").ToString(), out _cellValueLow);
            int.TryParse(view.GetRowCellValue(e.RowHandle, "HIGH_SIGNS_VALUES").ToString(), out _cellValueHigh);

            if (_cellValueLow > _cellValueHigh)
            {
                e.Valid = false;
                view.SetColumnError(view.Columns["HIGH_SIGNS_VALUES"], "预警阀值上限必须大于下限！");
            }
        }

    }
}
