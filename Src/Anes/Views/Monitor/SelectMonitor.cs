using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Utilities;
using Wis.Anes.Framework;
using Wis.Anes.BusinessEntity;
using Wis.Anes.ServiceProxies;
using System.Runtime.InteropServices;
using Wis.Anes.Layouts;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.Framework.Views;
using Wis.Anes.Constants;
using Wis.Anes.Framework.Controls;

namespace Wis.Anes.Views
{
    [ToolboxItem(false)]
    public partial class SelectMonitor : BaseView
    {
        public SelectMonitor(PatientInformation patientInfo, decimal eventNo)
        {
            Caption = ViewNames.SetMonitor;
            _patientInfo = patientInfo;
            _eventNo = eventNo;
            InitializeComponent();
        }

        private string _selectedMonitorLabel = "";
        private string _selectedMZMachineLabel = "";
        private PatientInformation _patientInfo;
        private decimal _eventNo;
        private Dict.OperatingRoomDataTable _room;
        /// <summary>
        /// 监护仪表
        /// </summary>
        private Dict.MonitorDictDataTable _monitorTable;
        /// <summary>
        /// 麻醉机
        /// </summary>
        private Dict.MonitorDictDataTable _maZuiMachineTable;
        private DataGridView _maZuiMachineDataGridView;

        private void SelectMonitor_Load(object sender, EventArgs e)
        {
            if (_eventNo != 1 && _patientInfo == null)
            {
                return;
            }
            if (!DesignMode)
            {
                medDataGridView1.ReadOnly = false;
                if (_eventNo == 1)
                {
                    this.label1.Visible = false;
                    this.dateTimePicker1.Visible = false;
                    //pnlParameters.Visible = false;
                    _room = DictProxy.GetOperatingRoomDict();
                }
                else
                {
                    _maZuiMachineTable = DictProxy.GetMonitorDict("1", 0);
                    if (_maZuiMachineTable != null && _maZuiMachineTable.Count > 0)
                    {
                        if (ParentForm != null)
                        {
                            ParentForm.Height += 200;
                        }
                        else
                        {
                            Height += 200;
                        }
                        _maZuiMachineDataGridView = new DataGridView();
                        _maZuiMachineDataGridView.Height = 200;
                        _maZuiMachineDataGridView.Top = panel1.Top;
                        _maZuiMachineDataGridView.Width = medDataGridView1.Width;
                        Controls.Add(_maZuiMachineDataGridView);
                        InitGridView(_maZuiMachineDataGridView, "麻醉机");
                        _maZuiMachineDataGridView.DataSource = _maZuiMachineTable;
                        _maZuiMachineDataGridView.RowHeadersVisible = false;
                        _maZuiMachineDataGridView.BackgroundColor = Color.White;
                        _maZuiMachineDataGridView.AllowUserToAddRows = false;
                        _maZuiMachineDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        _maZuiMachineDataGridView.CellPainting += medDataGridView1_CellPainting;
                        _maZuiMachineDataGridView.CellContentClick += new DataGridViewCellEventHandler(medDataGridView1_CellContentClick);
                        panel1.Top += 200;
                    }
                }
                InitGridView(medDataGridView1, "监护仪");

                _monitorTable = DictProxy.GetMonitorDict("0", _eventNo);
                //DataRow[] rows = _monitorTable.Select("WARD_CODE = '" + ApplicationConfiguration.OpertionDeptCode + "'");
                DataRow[] rows = _monitorTable.Select();
                Dict.MonitorDictDataTable tt = (Dict.MonitorDictDataTable)_monitorTable.Clone();

                foreach (DataRow row in rows)
                {
                    tt.ImportRow(row);
                }
                _monitorTable = tt;

                medDataGridView1.DataSource = _monitorTable;
                medDataGridView1.MultiSelect = false;
                if (!Framework.AccessControl.CheckModifyRight(ViewNames.SetMonitor))
                {
                    medDataGridView1.ReadOnly = true;
                    if (_maZuiMachineDataGridView != null)
                    {
                        _maZuiMachineDataGridView.ReadOnly = true;
                    }
                    panel1.Enabled = false;
                }

                DataRow[] rows1 = _monitorTable.Select("PAT_ID = '" + _patientInfo.PatientID + "'");
                if (rows1.Length == 0)
                {
                    _selectedMonitorLabel = ApplicationConfiguration.SelectedMonitorLabel;
                }
                else if (rows1.Length == 1)
                {
                    _monotorLabel = rows1[0]["MONITOR_LABEL"].ToString();
                }
                if (_maZuiMachineTable != null && _maZuiMachineTable.Select("PAT_ID = '" + _patientInfo.PatientID + "'").Length == 0)
                {
                    _selectedMZMachineLabel = ApplicationConfiguration.SelectedMZMachineLabel;
                }
                FilterMonitor();
            }
        }

        private void InitGridView(DataGridView gridView, string machineType)
        {
            gridView.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn column = (DataGridViewTextBoxColumn)SystemHelper.GenerateColumn(machineType, "MONITOR_LABEL", 160);
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridView.Columns.Add(column);
            gridView.Columns.Add(SystemHelper.GenerateColumn("开始时间", "DATALOG_START_TIME", 120));
            gridView.Columns.Add(SystemHelper.GenerateColumn("默认记录间隔", "DEFAULT_RECV_FREQUENCY", 80));
            gridView.Columns.Add(SystemHelper.GenerateColumn("实际记录间隔", "CURRENT_RECV_FREQUENCY", 80));
            gridView.Columns.Add(SystemHelper.GenerateColumn(@"采集次数/秒", "CURRENT_RECVTIMES_UPLIMIT", 80));
            if (_eventNo != 0)
            {
                gridView.Columns["DATALOG_START_TIME"].Visible = false;
                //gridView.Columns["DEFAULT_RECV_FREQUENCY"].Visible = false;
                //gridView.Columns["CURRENT_RECV_FREQUENCY"].Visible = false;
                //gridView.Columns["CURRENT_RECVTIMES_UPLIMIT"].Visible = false;
            }
            gridView.Columns.Add(SystemHelper.GenerateColumn((_eventNo == 1) ? "床位号" : "手术间", "BED_NO", 45));

            gridView.Columns.Add(SystemHelper.GenerateColumn("PAT_ID", "PAT_ID", 20));
            gridView.Columns.Add(SystemHelper.GenerateColumn("VISIT_ID", "VISIT_ID", 20));
            gridView.Columns.Add(SystemHelper.GenerateColumn("OPER_ID", "OPER_ID", 20));
            gridView.Columns.Add(SystemHelper.GenerateColumn("DRIVER_PROG", "DRIVER_PROG", 20));
            gridView.Columns.Add(SystemHelper.GenerateColumn("CURRENT_RECV_ITEMS", "CURRENT_RECV_ITEMS", 20));
            gridView.Columns["PAT_ID"].Visible = false;
            gridView.Columns["VISIT_ID"].Visible = false;
            gridView.Columns["OPER_ID"].Visible = false;
            gridView.Columns["DRIVER_PROG"].Visible = false;
            gridView.Columns["CURRENT_RECV_ITEMS"].Visible = false;

            for (int j = 0; j < gridView.ColumnCount; j++)
            {
                if (gridView.Columns[j].Visible == true)
                {
                    gridView.Columns[j].ReadOnly = true;
                }
            }

            //添加复选列
            DataGridViewCheckBoxColumn columnCheck = new DataGridViewCheckBoxColumn();

            columnCheck.HeaderText = "选择";
            columnCheck.DataPropertyName = "MONITOR_SELECT";
            columnCheck.Name = "MONITOR_SELECT";
            columnCheck.Width = 40;
            columnCheck.ReadOnly = false;
            columnCheck.FalseValue = false;
            columnCheck.TrueValue = true;

            gridView.Columns.Add(columnCheck);
        }

        private string _monotorLabel = "";
        private void FilterMonitor()
        {
            //if (!_showAll && !string.IsNullOrEmpty(_monotorLabel))
            //{
            //    _monitorTable.DefaultView.RowFilter = "MONITOR_LABEL = '" + _monotorLabel + "'";
            //}
        }

        private void medDataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                GridViewHelper.DataGridViewCellPainting(e);
            }
            else if (_eventNo == 0)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && gridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != System.DBNull.Value && gridView.Columns[e.ColumnIndex].Name.ToLower() != "MONITOR_SELECT".ToLower())
                {
                    string text = "";
                    if (gridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                        text = gridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                    //如果占用的话 用红色标记
                    if (!string.IsNullOrEmpty(text) && gridView.Rows[e.RowIndex].Cells["PAT_ID"].Value != System.DBNull.Value && !string.IsNullOrEmpty(
                        gridView.Rows[e.RowIndex].Cells["PAT_ID"].Value.ToString()))
                    {
                        e.Handled = true;
                        e.PaintBackground(e.ClipBounds, true);
                        Rectangle rect = e.CellBounds;
                        rect.Inflate(-1, -1);
                        e.Graphics.FillRectangle(Brushes.LightGray, rect);

                        //如果是自己的话 则选中
                        if (gridView.Rows[e.RowIndex].Cells["PAT_ID"].Value.ToString().ToLower() == _patientInfo.PatientID.ToLower())
                        {
                            gridView.Rows[e.RowIndex].Cells["MONITOR_SELECT"].Value = true;
                            if (gridView.Rows.Count > 1)
                            {
                                _monotorLabel = gridView.Rows[e.RowIndex].Cells["MONITOR_LABEL"].Value.ToString();
                                FilterMonitor();
                            }
                            e.Graphics.FillRectangle(Brushes.Green, rect);
                        }

                        e.Graphics.DrawString(text, e.CellStyle.Font, new SolidBrush(Color.White), e.CellBounds.X + 1, e.CellBounds.Y + 4);
                    }
                    else
                    {
                        if (ApplicationConfiguration.UseDefaultSelectedMonitorLabel && (!string.IsNullOrEmpty(_selectedMonitorLabel) || !string.IsNullOrEmpty(_selectedMZMachineLabel)) && (gridView.Rows[e.RowIndex].Cells["MONITOR_LABEL"].Value != System.DBNull.Value)
                            && (gridView.Rows[e.RowIndex].Cells["MONITOR_LABEL"].Value != null)
                            && ((gridView.Rows[e.RowIndex].Cells["MONITOR_LABEL"].Value.ToString().Equals(_selectedMonitorLabel)) || (gridView.Rows[e.RowIndex].Cells["MONITOR_LABEL"].Value.ToString().Equals(_selectedMZMachineLabel))))
                        {
                            e.Handled = true;
                            e.PaintBackground(e.ClipBounds, true);
                            Rectangle rect = e.CellBounds;
                            rect.Inflate(-1, -1);
                            e.Graphics.FillRectangle(Brushes.Red, rect);

                            gridView.Rows[e.RowIndex].Cells["MONITOR_SELECT"].Value = true;
                            e.Graphics.FillRectangle(Brushes.BlueViolet, rect);

                            e.Graphics.DrawString(text, e.CellStyle.Font, new SolidBrush(Color.White), e.CellBounds.X + 1, e.CellBounds.Y + 4);
                        }
                    }
                }


            }
            else if (_eventNo == 1)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && gridView.Columns[e.ColumnIndex].DataPropertyName.ToLower().Equals("bed_no")
                    && gridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != System.DBNull.Value)
                {
                    string text = gridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    if (!string.IsNullOrEmpty(text))
                    {
                        e.Handled = true;
                        e.PaintBackground(e.ClipBounds, true);
                        DataRow[] rows = _room.Select("ROOM_NO = '" + text + "'");
                        if (rows != null && rows.Length == 1 && rows[0]["BED_LABEL"] != System.DBNull.Value)
                        {
                            text = rows[0]["BED_LABEL"].ToString();
                            if (!string.IsNullOrEmpty(text))
                            {
                                e.Graphics.DrawString(text, e.CellStyle.Font, new SolidBrush((gridView.CurrentRow != null && gridView.CurrentRow.Index == e.RowIndex)
                                    ? e.CellStyle.SelectionForeColor : e.CellStyle.ForeColor), e.CellBounds.X + 1, e.CellBounds.Y + 4);
                            }
                        }
                    }
                }
            }
        }

        private void medDataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (_eventNo == 0 && e.RowIndex >= 0)
            {
                if (medDataGridView1.Rows[e.RowIndex].Cells[2].Value != null)
                {
                    txtInterval1.Text = medDataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                }
                if (medDataGridView1.Rows[e.RowIndex].Cells[3].Value != null)
                {
                    txtInterval2.Text = medDataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                }
                if (medDataGridView1.Rows[e.RowIndex].Cells[4].Value != null)
                {
                    txtTimes.Text = medDataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                }
                dateTimePicker1.Value = DateTime.Now;
            }
        }

        private void ChangeRow(int rowIndex)
        {
            if (_eventNo == 0 && rowIndex >= 0)
            {

                if (_monitorTable[rowIndex]["DEFAULT_RECV_FREQUENCY"] != System.DBNull.Value)
                {
                    txtInterval1.Text = _monitorTable[rowIndex]["DEFAULT_RECV_FREQUENCY"].ToString();
                }
                if (_monitorTable[rowIndex]["CURRENT_RECV_FREQUENCY"] != System.DBNull.Value)
                {
                    txtInterval2.Text = _monitorTable[rowIndex]["CURRENT_RECV_FREQUENCY"].ToString();
                }
                if (_monitorTable[rowIndex]["CURRENT_RECVTIMES_UPLIMIT"] != System.DBNull.Value)
                {
                    txtTimes.Text = _monitorTable[rowIndex]["CURRENT_RECVTIMES_UPLIMIT"].ToString();
                }
                dateTimePicker1.Value = DateTime.Now;
            }
        }

        private int Save(DataGridView gridView, Dict.MonitorDictDataTable dataTable, int machineType)
        {
            string SelectedMonitorLabel = "";
            for (int i = 0; i < gridView.RowCount; i++)
            {


                if (gridView.Rows[i].Cells["MONITOR_SELECT"].Value != null && gridView.Rows[i].Cells["MONITOR_SELECT"].Value.ToString().ToLower() == "true")
                {
                    Dict.MonitorDictRow selectRow = dataTable[i];
                    if (!selectRow.IsPAT_IDNull() && !string.IsNullOrEmpty(selectRow.PAT_ID))
                    {
                        if (selectRow.PAT_ID != _patientInfo.PatientID)
                        {
                            //Dialog.MessageBox("您选择的监护仪正被病人 " + selectRow.PATIENT_ID + " 使用， 请重新选择。", MessageBoxIcon.Information);
                            //gridView.Rows[i].Cells["MONITOR_SELECT"].Value = false;
                            //return -1;
                            if (DialogResult.Yes == Dialog.MessageBox("您选择的监护仪正被病人 " + selectRow.PAT_ID + " 使用， 是否强制使用此监护仪？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                                break;
                            else
                            {
                                gridView.Rows[i].Cells["MONITOR_SELECT"].Value = false;
                                return -1;
                            }
                        }
                    }

                }

            }

            //modified by chenyu begin 2012-09-21
            //MonitorSelect 列的位置
            int indexMonitorSelect = -1;
            for (int j = 0; j < gridView.ColumnCount; j++)
            {
                if (gridView.Columns[j].Name == "MONITOR_SELECT")
                {
                    indexMonitorSelect = j;
                    break;
                }

            }
            //如果复选列的位置 不存在的话 退出
            if (indexMonitorSelect < 0)
                return -1;

            int Selectedindex = -1;
            for (int i = 0; i < gridView.RowCount; i++)
            {

                Dict.MonitorDictRow myRow = dataTable[i];

                if (gridView.Rows[i].Cells["MONITOR_SELECT"].Value != null && gridView.Rows[i].Cells["MONITOR_SELECT"].Value.ToString().ToLower() == "true")
                {
                    #region Add @2014-02-14 监护仪绑定手术间号，复苏绑定复苏床位号
                    //myRow.BED_NO = _patientInfo.OperRoom;
                    SelectedMonitorLabel = myRow.MONITOR_LABEL;
                    Selectedindex = i;
                    BusinessEntity.Dict.OperatingRoomDataTable dt = new DataAccess.DictDA().GetOperatingRoomDict();
                    BusinessEntity.Dict.OperatingRoomRow[] row = null;
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        row = dt.Select(string.Format("PAT_ID='{0}' AND VISIT_ID={1} AND OPER_ID={2}", (string)ExtendApplicationContext.Current.PatientInformation.PatientID,
                            ExtendApplicationContext.Current.PatientInformation.VisitID, ExtendApplicationContext.Current.PatientInformation.OperID)) as BusinessEntity.Dict.OperatingRoomRow[];
                    }
                    if (ExtendApplicationContext.Current.AppType == ApplicationType.PACU && row != null && row.Length > 0)
                    {
                        myRow.BED_NO = row[0].ROOM_NO;
                    }
                    else
                    {
                        myRow.BED_NO = _patientInfo.OperRoom;
                    }
                    #endregion
                    myRow.PAT_ID = _patientInfo.PatientID;
                    myRow.VISIT_ID = _patientInfo.VisitID;
                    myRow.OPER_ID = _patientInfo.OperID;
                    myRow.DATALOG_START_TIME = dateTimePicker1.Value;
                    if (string.IsNullOrEmpty(txtInterval1.Text))
                    {
                        myRow.DEFAULT_RECV_FREQUENCY = 0;
                    }
                    else
                    {
                        myRow.DEFAULT_RECV_FREQUENCY = decimal.Parse(txtInterval1.Text);
                    }
                    if (string.IsNullOrEmpty(txtInterval2.Text))
                    {
                        myRow.CURRENT_RECV_FREQUENCY = 0;
                    }
                    else
                    {
                        myRow.CURRENT_RECV_FREQUENCY = decimal.Parse(txtInterval2.Text);
                    }
                    decimal times = 0;
                    if (!decimal.TryParse(txtTimes.Text, out times))
                    {
                        times = 0;
                    }
                    myRow.CURRENT_RECV_TIMES_UPLIMIT = times;
                }
                else
                {//没有选种的话
                    //如果这一行是他自己的话，则表示去除着一个监护设置
                    if (!myRow.IsPAT_IDNull() && myRow.PAT_ID == _patientInfo.PatientID)
                    {
                        myRow.BED_NO = null;
                        myRow.PAT_ID = null;
                        myRow.VISIT_ID = 0;
                        myRow.OPER_ID = 0;
                        myRow.SetDATALOG_START_TIMENull();
                    }

                }


            }

            //如果选中监护仪 则，启动程序
            if (Selectedindex > -1)
            {
                ApplicationConfiguration.MonitorLabel = SelectedMonitorLabel;
                Dict.MonitorDictRow row = dataTable[Selectedindex];

                bool yes = true;
                if (!row.IsDRIVER_PROGNull())
                {
                    string exeName = row.DRIVER_PROG;
                    if (!string.IsNullOrEmpty(exeName))
                    {
                        if (!exeName.ToLower().EndsWith(".exe"))
                        {
                            exeName = exeName + ".exe";
                        }
                        exeName = ExtendApplicationContext.Current.AppPath + exeName;
                        //exeName = Globals.AppPath + "runCaiji.bat";
                        if (System.IO.File.Exists(exeName))
                        {
                            ShellExecute(0, "Open", exeName, "", "", 0);
                            yes = true;
                        }
                        else
                        {
                            //Dialog.MessageBox("采集程序" + exeName + "不存在", MessageBoxIcon.Information);
                        }
                    }
                }
                if (!yes)
                {
                    Dialog.MessageBox("采集程序没启动", MessageBoxIcon.Information);
                }
                if (!row.IsCURRENT_RECV_ITEMSNull() && !string.IsNullOrEmpty(row.CURRENT_RECV_ITEMS))
                {
                    AnesInformations.PatMonitorDateDataTable patMonitorDateDataTable = AnesthesiaSheetProxy.GetPatMonitorDate(_patientInfo.PatientID, _patientInfo.VisitID, _patientInfo.OperID, 0);
                    if (patMonitorDateDataTable != null && patMonitorDateDataTable.Count == 0)
                    {
                        AnesInformations.PatMonitorDateRow row1 = patMonitorDateDataTable.NewPatMonitorDateRow();
                        row1.PAT_ID = _patientInfo.PatientID;
                        row1.VISIT_ID = _patientInfo.VisitID;
                        row1.OPER_ID = _patientInfo.OperID;
                        row1.ITEM_NO = 0;
                        if (_eventNo == 0)
                            row1.DATA_TYPE = "0";
                        else if (_eventNo == 1)
                            row1.DATA_TYPE = "1";
                        row1.MONITOR_VALUE = DateTime.Now.ToString("yy-MM-dd HH:mm") + "= " + row.CURRENT_RECV_ITEMS;
                        patMonitorDateDataTable.AddPatMonitorDateRow(row1);
                        AnesthesiaSheetProxy.UpdatePatMonitorDate(patMonitorDateDataTable);
                    }
                }
            }

            #region 旧处理
            //if (_eventNo == 0)
            //{
            //    //MonitorSelect 列的位置
            //    int indexMonitorSelect = -1;
            //    for (int j = 0; j < gridView.ColumnCount; j++)
            //    {
            //        if (gridView.Columns[j].Name == "MONITOR_SELECT")
            //        {
            //            indexMonitorSelect = j;
            //            break;
            //        }

            //    }
            //    //如果复选列的位置 不存在的话 退出
            //    if (indexMonitorSelect < 0)
            //        return -1;

            //    int Selectedindex = -1;
            //    for (int i = 0; i < gridView.RowCount; i++)
            //    {

            //        Dict.MonitorDictRow myRow = dataTable[i];

            //        if (gridView.Rows[i].Cells["MONITOR_SELECT"].Value != null && gridView.Rows[i].Cells["MONITOR_SELECT"].Value.ToString().ToLower() == "true")
            //        {
            //            SelectedMonitorLabel = myRow.MONITOR_LABEL;
            //            Selectedindex = i;
            //            myRow.BED_NO = _patientInfo.OperRoom;
            //            myRow.PATIENT_ID = _patientInfo.PatientID;
            //            myRow.VISIT_ID = _patientInfo.VisitID;
            //            myRow.OPER_ID = _patientInfo.OperID;
            //            myRow.DATALOG_START_TIME = dateTimePicker1.Value;
            //            if (string.IsNullOrEmpty(txtInterval1.Text))
            //            {
            //                myRow.DEFAULT_RECV_FREQUENCY = 0;
            //            }
            //            else
            //            {
            //                myRow.DEFAULT_RECV_FREQUENCY = decimal.Parse(txtInterval1.Text);
            //            }
            //            if (string.IsNullOrEmpty(txtInterval2.Text))
            //            {
            //                myRow.CURRENT_RECV_FREQUENCY = 0;
            //            }
            //            else
            //            {
            //                myRow.CURRENT_RECV_FREQUENCY = decimal.Parse(txtInterval2.Text);
            //            }
            //            decimal times = 0;
            //            if (!decimal.TryParse(txtTimes.Text, out times))
            //            {
            //                times = 0;
            //            }
            //            myRow.CURRENT_RECVTIMES_UPLIMIT = times;
            //        }
            //        else
            //        {//没有选种的话
            //            //如果这一行是他自己的话，则表示去除着一个监护设置
            //            if (!myRow.IsPATIENT_IDNull() && myRow.PATIENT_ID == _patientInfo.PatientID)
            //            {
            //                myRow.BED_NO = null;
            //                myRow.PATIENT_ID = null;
            //                myRow.VISIT_ID = 0;
            //                myRow.OPER_ID = 0;
            //                myRow.SetDATALOG_START_TIMENull();
            //            }

            //        }


            //    }

            //    //如果选中监护仪 则，启动程序
            //    if (Selectedindex > -1)
            //    {
            //        ApplicationConfiguration.MonitorLabel = SelectedMonitorLabel;
            //        Dict.MonitorDictRow row = dataTable[Selectedindex];

            //        bool yes = false;
            //        if (!row.IsDRIVER_PROGNull())
            //        {
            //            string exeName = row.DRIVER_PROG;
            //            if (!string.IsNullOrEmpty(exeName))
            //            {
            //                if (!exeName.ToLower().EndsWith(".exe"))
            //                {
            //                    exeName = exeName + ".exe";
            //                }
            //                exeName = ExtendApplicationContext.Current.AppPath + exeName;
            //                //exeName = Globals.AppPath + "runCaiji.bat";
            //                if (System.IO.File.Exists(exeName))
            //                {
            //                    ShellExecute(0, "Open", exeName, "", "", 0);
            //                    yes = true;
            //                }
            //                else
            //                {
            //                    Dialog.MessageBox("采集程序" + exeName + "不存在", MessageBoxIcon.Information);
            //                }
            //            }
            //        }
            //        if (!yes)
            //        {
            //            Dialog.MessageBox("采集程序没启动", MessageBoxIcon.Information);
            //        }
            //        if (!row.IsCURRENT_RECV_ITEMSNull() && !string.IsNullOrEmpty(row.CURRENT_RECV_ITEMS))
            //        {
            //            AnesInformations.PatMonitorDateDataTable patMonitorDateDataTable = AnesthesiaSheetProxy.GetPatMonitorDate(_patientInfo.PatientID, _patientInfo.VisitID, _patientInfo.OperID, 0);
            //            if (patMonitorDateDataTable != null && patMonitorDateDataTable.Count == 0)
            //            {
            //                AnesInformations.PatMonitorDateRow row1 = patMonitorDateDataTable.NewPatMonitorDateRow();
            //                row1.PATIENT_ID = _patientInfo.PatientID;
            //                row1.VISIT_ID = _patientInfo.VisitID;
            //                row1.OPER_ID = _patientInfo.OperID;
            //                row1.ITEM_NO = 0;
            //                row1.DATA_TYPE = "0";
            //                row1.MONITOR_VALUE = DateTime.Now.ToString("yy-MM-dd HH:mm") + "= " + row.CURRENT_RECV_ITEMS;
            //                patMonitorDateDataTable.AddPatMonitorDateRow(row1);
            //                AnesthesiaSheetProxy.UpdatePatMonitorDate(patMonitorDateDataTable);
            //            }
            //        }
            //    }
            //}
            //else if (_eventNo == 1)
            //{
            //}
            #endregion
            //modified by chenyu 2012-09-21 end

            int result = DictProxy.UpdateMonitorDict(dataTable);
            if (result > 0 && !string.IsNullOrEmpty(SelectedMonitorLabel))
            {
                if (machineType == 0)
                {
                    ApplicationConfiguration.SelectedMonitorLabel = SelectedMonitorLabel;
                }
                else if (machineType == 1)
                {
                    ApplicationConfiguration.SelectedMZMachineLabel = SelectedMonitorLabel;
                }
            }
            return result;
        }

        [DllImportAttribute("shell32.dll")]
        private static extern IntPtr ShellExecute(int hWnd, string Operation, string FileName, string Dir, string Parameters, int ShowCmd);

        private void btnOK_Click(object sender, EventArgs e)
        {
            //_monitorTable.DefaultView.RowFilter = "";
            ParentForm.DialogResult = DialogResult.None;


            if (medDataGridView1 != null)
            {
                Save(medDataGridView1, _monitorTable, 0);
            }
            if (_maZuiMachineDataGridView != null)
            {
                Save(_maZuiMachineDataGridView, _maZuiMachineTable, 1);
            }
            FilterMonitor();
        }

        private void medDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_eventNo == 1 && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                BedManager bed;
                if (ExtendApplicationContext.Current.AppType == ApplicationType.YouDao)
                {
                    bed = new BedManager(3);
                }
                else
                {
                    bed = new BedManager();
                }
                bed.IsSelecting = true;
                DialogHostForm dialogHostForm = new DialogHostForm("选择床位", 800, 600);
                dialogHostForm.Child = bed;
                dialogHostForm.ShowDialog();
                object result = bed.DialogResultData;//Globals.ShowDialog(bed, "选择床位");
                if (result != null && !string.IsNullOrEmpty(result.ToString()))
                {
                    medDataGridView1.Rows[e.RowIndex].Cells["BED_NO"].Value = result.ToString();
                }
            }
        }

        private void medDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && gridView.Columns[e.ColumnIndex].Name == "MONITOR_SELECT")
            {
                for (int i = 0; i < gridView.RowCount; i++)
                {
                    gridView.Rows[i].Cells[e.ColumnIndex].Value = false;
                }
                gridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
            }
        }

        private bool _showAll = false;
        private void btnAll_Click(object sender, EventArgs e)
        {
            _showAll = !_showAll;
            if (_showAll)
            {
                _monitorTable.DefaultView.RowFilter = "";
            }
            else
            {
                FilterMonitor();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //btnOK.PerformClick();
            //ParentForm.DialogResult = DialogResult.OK;
        }


    }
}
