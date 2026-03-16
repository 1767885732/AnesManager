using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.DataAccess;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.Framework.Documents;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using Wis.Anes.Framework.Utilities;
using Wis.Anes.Framework;
using Wis.Anes.ServiceProxies;

namespace Wis.Anes.Views.Patient.Process
{
    public delegate bool UpdateStateOperationStatusDelegate(OperationStatus status);

    public partial class OperationProcess : Wis.Anes.Framework.Views.BaseView
    {
        protected Font _fontCircle = new Font("宋体", 12);
        protected DataRow _selectRow = null; // 操作的行 
        protected int isTomorrow = 0;  // 0 今天　１　明天　　３　三天后
        private PacuMessage pm = null;
        protected Dictionary<string, int> _msgPatientInpNo = new Dictionary<string, int>(); // 用于记录已提示信息的患者住院号

        public OperationProcess()
        {
            InitializeComponent();
            isTomorrow = 0;
        }

        protected void RefreshDataSource()
        {
            //DataTable dt = new AnesMasterDA().GetTable("Oper_Process");

            CommonDA da = new CommonDA();
            DataTable dt = null;
            switch(isTomorrow)
            {
                case 0:
                    dt = da.GetDataWithPrimaryKey("wis_vw_operation_process");
                    //dt = da.GetDataWithPrimaryKey("Oper_Process");
                    break;
                case 1:
                    dt = da.GetDataWithPrimaryKey("wis_vw_operation_process_tm");
                    break;
                case 3:
                    dt = da.GetDataWithPrimaryKey("wis_vw_operation_process_threeday");
                    break;
            }

            if (dt == null)
                return;

            List<string> list = GetPatientList(dt);
            DataTable dataTable = TransDataTable(list, "WIS_OPER_NAME");
            foreach (DataRow row in dt.Rows)
            {
                if (row["OPER_NAME"] == System.DBNull.Value || string.IsNullOrEmpty(row["OPER_NAME"].ToString()) && dataTable != null && dataTable.Rows.Count > 0)
                {
                    DataRow[] rows = dataTable.Select("PAT_ID = '" + row["PAT_ID"] + "' AND VISIT_ID = " + row["VISIT_ID"].ToString()
                        + " AND OPER_ID = " + row["OPER_ID"]);
                    if (rows.Length > 0)
                    {
                        List<string> operationNames = new List<string>();
                        foreach (DataRow row1 in rows)
                        {
                            if (row1["OPER_NAME"] != System.DBNull.Value && !string.IsNullOrEmpty(row1["OPER_NAME"].ToString()))
                            {
                                operationNames.Add(row1["OPER_NAME"].ToString());
                            }
                        }
                        if (operationNames.Count > 0)
                        {
                            row["OPER_NAME"] = string.Join(",", operationNames.ToArray());
                        }
                    }
                }
            }
            // 更新手术序列
            //string currentRoom = "";
            //int index = 0;
            //foreach (DataRow row in dt.Rows)
            //{
            //    if (row["BED_LABEL"].ToString() != currentRoom)
            //    {
            //        currentRoom = row["BED_LABEL"].ToString();
            //        index = 1;
            //    }
            //    else
            //        index++;

            //    row["SEQUENCE"] = index;
            //}

            int topindex = gridViewLeftList.TopRowIndex;

            switch (radioType.SelectedIndex)
            {
                case 0:
                    dt.DefaultView.RowFilter = "";
                    break;
                case 1:
                    dt.DefaultView.RowFilter = "LOCATION = '6楼'";
                    break;
                case 2:
                    dt.DefaultView.RowFilter = "LOCATION = '7楼'";
                    break;
                case 3:
                    dt.DefaultView.RowFilter = "LOCATION = '8楼'";
                    break;
                case 4:
                    dt.DefaultView.RowFilter = "LOCATION = '门诊'";
                    break;
            }

            DataSource = dt;

            gridViewLeftList.TopRowIndex = topindex;

            _selectRow = null;
        }

        private List<string> GetPatientList(DataTable dataTable)
        {
            List<string> list = new List<string>();
            if (dataTable != null && dataTable.Rows.Count > 0 && dataTable.Columns.Contains("PAT_ID")
                && dataTable.Columns.Contains("VISIT_ID") && dataTable.Columns.Contains("OPER_ID"))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["PAT_ID"] != System.DBNull.Value && row["VISIT_ID"] != System.DBNull.Value && row["OPER_ID"] != System.DBNull.Value && !string.IsNullOrEmpty(row["PAT_ID"].ToString()))
                    {
                        string patientID = row["PAT_ID"].ToString();
                        if (!list.Contains(patientID))
                        {
                            list.Add(patientID);
                        }
                    }
                    if (list.Count > 999)
                    {
                        break;
                    }
                }
            }
            return list;
        }

        private DataTable TransDataTable(List<string> list, string tableName)
        {
            DataTable Result = new DataTable();
            if (list.Count > 0)
            {
                string sql = "SELECT * FROM " + tableName + " WHERE PAT_ID IN ('" + string.Join("','", list.ToArray()) + "')";
                Result = new CommonDA().GetDataFromSQLString(sql);
            }
            return Result;
        }

        public DataTable DataSource
        {
            get
            {
                if (gridControlList != null && gridControlList.DataSource != null && gridControlList.DataSource is DataView)
                {
                    return (gridControlList.DataSource as DataView).Table;
                }
                return null;
            }
            set
            {
                if (gridControlList != null)
                {
                    gridControlList.DataSource = value.DefaultView;
                }
            }
        }


        private void gridViewLeftList_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            GridView view = gridControlList.MainView as GridView;
            if (view == null)
                return;

            DataRow row = view.GetDataRow(e.RowHandle);

            if (e.Column.AbsoluteIndex == 0)
            {
                if (row.Table.Columns.Contains("ISFINISH"))
                {
                    if (row["ISFINISH"].ToString() == "1")
                    {
                        e.Appearance.BackColor2 = Color.FromArgb(153, 204, 255);
                        e.Appearance.BackColor = Color.FromArgb(153, 204, 255);
                        e.Appearance.ForeColor = Color.DarkGreen;
                    }
                    else
                    {
                        e.Appearance.BackColor2 = Color.FromArgb(255, 255, 255);
                        e.Appearance.BackColor = Color.FromArgb(255, 255, 255);
                        e.Appearance.ForeColor = Color.Black;
                    }
                }
            }
            else if (!row.IsNull("OPER_STATUS"))
            {
                int status = Convert.ToInt32(row["OPER_STATUS"]);
                if (status >= Convert.ToInt32(OperationStatus.OperationStart) && status < Convert.ToInt32(OperationStatus.OperationEnd)) // 手术中
                {
                    e.Appearance.BackColor2 = Color.FromArgb(204, 255, 204);
                    e.Appearance.BackColor = Color.FromArgb(204, 255, 204);
                    e.Appearance.ForeColor = Color.Black; 
                }
                else if (status >= Convert.ToInt32(OperationStatus.InPACU) && status < Convert.ToInt32(OperationStatus.OutPACU)) // PACU
                {
                    e.Appearance.BackColor2 = Color.FromArgb(204, 153, 255);
                    e.Appearance.BackColor = Color.FromArgb(204, 153, 255);
                    e.Appearance.ForeColor = Color.Black;
                }
                else if (status >= Convert.ToInt32(OperationStatus.OutPACU)) // 病房
                {
                    e.Appearance.BackColor2 = Color.FromArgb(153, 204, 255);
                    e.Appearance.BackColor = Color.FromArgb(153, 204, 255);
                    e.Appearance.ForeColor = Color.Black;
                }
                else if (status == Convert.ToInt32(OperationStatus.CancelOperation)) // 取消
                {
                    e.Appearance.BackColor2 = Color.FromArgb(150, 150, 150);
                    e.Appearance.BackColor = Color.FromArgb(150, 150, 150);
                    e.Appearance.ForeColor = Color.Black;
                }
                //else if (status == Convert.ToInt32(OperationStatus.PlacePatient)) // 放置体位
                //{
                //    e.Appearance.BackColor2 = Color.FromArgb(186, 185, 217);
                //    e.Appearance.BackColor = Color.FromArgb(186, 185, 217);
                //    e.Appearance.ForeColor = Color.Black;
                //}
                //else if (status < Convert.ToInt32(OperationStatus.PlacePatient) && status >= (int)OperationStatus.FinishAnesBegin) // 等待
                //{
                //    e.Appearance.BackColor2 = Color.LightCoral;
                //    e.Appearance.BackColor =  Color.LightCoral;
                //    e.Appearance.ForeColor = Color.Black;
                //}
                //else if (status < Convert.ToInt32(OperationStatus.FinishAnesBegin) && status >= (int)OperationStatus.AnesthesiaStart) // 诱导
                //{
                //    e.Appearance.BackColor2 = Color.FromArgb(245, 182, 228);
                //    e.Appearance.BackColor = Color.FromArgb(245, 182, 228);
                //    e.Appearance.ForeColor = Color.Black;
                //}
                else if (status == Convert.ToInt32(OperationStatus.OperationEnd) || status == Convert.ToInt32(OperationStatus.AnesthesiaEnd) || status == Convert.ToInt32(OperationStatus.OutOperationRoom)) // 苏醒
                {
                    e.Appearance.BackColor2 = Color.FromArgb(255, 204, 153);
                    e.Appearance.BackColor = Color.FromArgb(255, 204, 153);
                    e.Appearance.ForeColor = Color.Black;
                }
                //else if (status > 0 && status <= (int)OperationStatus.Estimate)// 准备
                //{
                //    e.Appearance.BackColor2 = Color.FromArgb(255, 255, 153);
                //    e.Appearance.BackColor = Color.FromArgb(255, 255, 153);
                //    e.Appearance.ForeColor = Color.Black;
                //}
                else if (status == 0 && !row.IsNull("Prepare") )
                {
                    int prepare = Convert.ToInt32(row["Prepare"]);
                    string location = row["location"].ToString();
                    if ( (prepare == 1 && location != "6楼") || prepare == 2 || (prepare == 6) && location == "6楼")// 接病人途中
                    {
                        e.Appearance.BackColor2 = Color.FromArgb(192, 192, 0);
                        e.Appearance.BackColor = Color.FromArgb(192, 192, 0);
                        e.Appearance.ForeColor = Color.Black;
                    }
                }
            }
            else
            {
                if (!row.IsNull("Prepare") )  // 接病人途中
                {
                    int prepare = Convert.ToInt32(row["Prepare"]);
                    if ( prepare == 1 || Convert.ToInt32(row["Prepare"]) == 2)
                    {
                        e.Appearance.BackColor2 = Color.FromArgb(192, 192, 0);
                        e.Appearance.BackColor = Color.FromArgb(192, 192, 0);
                        e.Appearance.ForeColor = Color.Black;
                    }
                }
            }
            if (e.Column.Caption == "类别")
            {
                e.DisplayText = "●";
                e.Appearance.Font = _fontCircle;

                if (e.CellValue != null)
                {
                    switch (e.CellValue.ToString())
                    {
                        case "择期":
                            e.Appearance.ForeColor = Color.DarkGreen;
                            break;
                        case "急诊":
                            e.Appearance.ForeColor = Color.Maroon;
                            break;
                        case "加台":
                            e.Appearance.ForeColor = Color.Goldenrod;
                            break;
                        case "紧急":
                            e.Appearance.ForeColor = Color.Red;
                            break;
                        default:
                            e.Appearance.ForeColor = Color.DarkGreen;
                            break;
                    }
                }
                else
                {
                    e.Appearance.ForeColor = Color.DarkGreen;
                }
            }
        }

        private void OperationProcess_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                RefreshDataSource();
                if (!Framework.AccessControl.CheckModifyRight("手术进程"))
                {
                    btnNewOperation.Visible = false;
                }
            }

            ParentForm.FormClosed += new FormClosedEventHandler(ParentForm_FormClosed);
        }

        protected void ParentForm_FormClosed(object sender, EventArgs e)
        {
            timerRefresh.Stop();
        }

        // 准备手术
        /*
        private void menuPrepare_Click(object sender, EventArgs e)
        {
            if (_selectRow == null)
                return;

            _selectRow["PREPARE"] = 1;

            Dictionary<string, object> values = new Dictionary<string, object>();
            values.Add("JT", 1);

            _selectRow["OUT_PLACE"] = toolStripMenuAccept.Text;
            values.Add("RESERVED7", toolStripMenuAccept.Text);
            DateTime time = (new CommonDA()).GetSysDateTime();
            values.Add("FIRST_SHIFT_SUPPLY_DATETIME", time);
            UpdateMasterTable(_selectRow["PAT_ID"], _selectRow["VISIT_ID"], _selectRow["OPER_ID"], values);

            // 显示手术通知单
            ShowFormByDocName(_selectRow["PAT_ID"], _selectRow["VISIT_ID"], _selectRow["OPER_ID"], "手术通知单", -1, -1);

            _selectRow = null;
            RefreshDataSource();
        }*/

        // 转入PACU
        private void menuToPacu_Click(object sender, EventArgs e)
        {
            if (_selectRow == null)
                return;

            _selectRow["OPER_STATUS"] = Convert.ToInt32(OperationStatus.InPACU);
            _selectRow["PREPARE"] = 6;
  
            Dictionary<string, object> values = new Dictionary<string,object>();
            values.Add("JT", 6);
            values.Add("OPER_STATUS", Convert.ToInt32(OperationStatus.InPACU));
            DateTime time = (new CommonDA()).GetSysDateTime();
            values.Add("FIRST_SHIFT_SUPPLY_DATETIME", time);
            UpdateMasterTable(_selectRow["PAT_ID"], _selectRow["VISIT_ID"], _selectRow["OPER_ID"], values);


            _selectRow = null;
        }

        // 转入病房
        private void menuToSickroom_Click(object sender, EventArgs e)
        {
            if (_selectRow == null)
                return;

            _selectRow["OPER_STATUS"] = Convert.ToInt32(OperationStatus.TurnToSickRoom);
            _selectRow["PREPARE"] = 10;

            Dictionary<string, object> values = new Dictionary<string,object>();
            values.Add("JT", 10);
            values.Add("OPER_STATUS", Convert.ToInt32(OperationStatus.TurnToSickRoom));
            UpdateMasterTable(_selectRow["PAT_ID"], _selectRow["VISIT_ID"], _selectRow["OPER_ID"], values);

            _selectRow = null;
        }


        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = DataSource;
            if (dt == null)
                return;

            switch (radioType.SelectedIndex)
            {
                case 0:
                    dt.DefaultView.RowFilter = "";
                    break;
                case 1:
                    dt.DefaultView.RowFilter = "LOCATION = '6楼'";
                    break;
                case 2:
                    dt.DefaultView.RowFilter = "LOCATION = '7楼'";
                    break;
                case 3:
                    dt.DefaultView.RowFilter = "LOCATION = '8楼'";
                    break;
                case 4:
                    dt.DefaultView.RowFilter = "LOCATION = '卫星手术室'";
                    break;
                case 5:
                    dt.DefaultView.RowFilter = "LOCATION = '上房手术室'";
                    break;
                case 6:
                    dt.DefaultView.RowFilter = "LOCATION <> '6楼' AND LOCATION <> '7楼' AND LOCATION <> '8楼' AND LOCATION <> '卫星手术室'  AND LOCATION <> '上房手术室'";
                    break;
            }

            RefreshData();
        }



        /// <summary>
        /// 更新患者状态或者时间
        /// </summary>
        /// <param name="operationStatus">新状态</param>
        /// <param name="dt">状态对应时间</param>
        /// <returns></returns>
        public bool UpdateOperationStatus(string patientId, decimal visitId, decimal operId,  OperationStatus operationStatus)
        {
            AnesInformations.OperationMasterDataTable dataTable = (new AnesthesiaSheetDA()).GetOperationMaster(patientId, visitId, operId);
            if (dataTable != null && dataTable.Count == 1)
            {
                if (operationStatus != OperationStatus.InOperationRoom && operationStatus != OperationStatus.AnesthesiaStart
                    && operationStatus != OperationStatus.OperationStart && operationStatus != OperationStatus.AnesthesiaEnd
                    && operationStatus != OperationStatus.OperationEnd && operationStatus != OperationStatus.InPACU)
                {
                    ClearPatientRoom(patientId);
                    ClearPatientMonitor(patientId, 0);
                }

                dataTable[0].OPER_STATUS = (decimal)(int)operationStatus;
                
                //string fieldName = OperationStatusHelper.GetTimeFieldName(operationStatus);
                int result = (new AnesthesiaSheetDA()).UpdateOperationMaster(dataTable);

                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        ///清除患者手术间安排
        /// </summary>
        /// <param name="patientID"></param>
        public bool ClearPatientRoom(string patientID)
        {
            bool result = false;
            //加载手术间 字典
            Dict.OperatingRoomDataTable operatingRoomDataTable = null;
            //if (ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_OPER_ROOM"))
            //{
            //    operatingRoomDataTable = ExtendApplicationContext.Current.CodeTables["WIS_OPER_ROOM"] as Dict.OperatingRoomDataTable;
            //}
            //else
            {
                operatingRoomDataTable = (new DictDA()).GetOperatingRoomDict();
            }


            if (operatingRoomDataTable != null)
            {
                foreach (Dict.OperatingRoomRow row in operatingRoomDataTable)
                {
                    if (!row.IsPAT_IDNull() && row.PAT_ID.Equals(patientID))
                    {
                        row.SetPAT_IDNull();
                        row.SetVISIT_IDNull();
                        row.SetOPER_IDNull();
                    }
                }
                int ret = (new DictDA()).UpdateOperatingRoomDict(operatingRoomDataTable);
                if (ret > 0)
                {
                    result = true;
                }
            }
            return result;
        }


        /// <summary>
        ///清除患者设备安排
        /// </summary>
        /// <param name="patientID"></param>
        public bool ClearPatientMonitor(string patientID, decimal eventNo)
        {
            bool result = false;
            Dict.MonitorDictDataTable monitorTable = (new DictDA()).GetMonitorDict(eventNo);
            if (monitorTable != null)
            {
                foreach (Dict.MonitorDictRow row in monitorTable)
                {
                    if (!row.IsPAT_IDNull() && row.PAT_ID.Equals(patientID))
                    {
                        row.SetPAT_IDNull();
                        row.SetVISIT_IDNull();
                        row.SetOPER_IDNull();
                        if (eventNo == 0)
                        {
                            row.SetBED_NONull();
                        }
                    }
                }
                int ret = (new DictDA()).UpdateMonitorDict(monitorTable);
                if (ret > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        public void ShowFormByDocName(object patientId, object visitId, object operId, string docName, int width, int height)
        {
            ApplicationConfiguration.MedicalDocucementElement document = ApplicationConfiguration.GetMedicalDocument(docName);
            //没有找到退出
            if (string.IsNullOrEmpty(document.Caption))
            {
                return;
            }

            try
            {
                Type t = Type.GetType(document.Type);
                BaseDoc baseDoc = Activator.CreateInstance(t) as BaseDoc;
                
                // 设置指定的患者信息
                if (patientId != null)
                {
                    object[] objs = new object[3];
                    objs[0] = patientId;
                    objs[1] = visitId;
                    objs[2] = operId;
                    baseDoc.SetDocParameters(objs);
                }

                baseDoc.LoadReport(ExtendApplicationContext.Current.AppPath + document.Path);
    
                // 显示窗体
                XtraForm dialogHostForm = new XtraForm();
                dialogHostForm.Text = docName;

                if (width > 0)
                {
                    dialogHostForm.Width = width;
                    dialogHostForm.Height = height;
                }
                else
                {
                    dialogHostForm.MaximizeBox = true;
                    dialogHostForm.MinimizeBox = true;
                    dialogHostForm.ControlBox = true;
                    dialogHostForm.WindowState = FormWindowState.Maximized;
                }

                dialogHostForm.AutoScroll = true;
                dialogHostForm.StartPosition = FormStartPosition.CenterScreen;

                baseDoc.Dock = DockStyle.Fill;
                dialogHostForm.Controls.Add(baseDoc);
                dialogHostForm.ShowDialog();

            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }

        }

        private void btnNewOperation_Click(object sender, EventArgs e)
        {
            //获取普通绘制界面
            Dictionary<string, MedicalDocElement> docs = MedicalDocSettings.GetCustomForms();
            KeyValuePair<string, MedicalDocElement> keyValuePairDoc = new KeyValuePair<string, MedicalDocElement>();
            foreach (KeyValuePair<string, MedicalDocElement> keyValuePair in docs)
            {
                if (keyValuePair.Key.Trim() == "急诊登记")
                {
                    keyValuePairDoc = keyValuePair;
                    break;
                }
            }

            //没有找到退出
            if (string.IsNullOrEmpty(keyValuePairDoc.Key))
            {
                DialogResult dialogResult = XtraMessageBox.Show("自定义【新手术】模块加载失败，请检查配置！",
                                      "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                //读取配置 ，加载 急诊登记
                Type t = Type.GetType(keyValuePairDoc.Value.Type);
                Wis.Anes.Framework.Views.BaseView view = Activator.CreateInstance(t) as Wis.Anes.Framework.Views.BaseView;

                XtraForm dialogHostForm = new XtraForm();
                view.Caption = "新手术";
                dialogHostForm.Text = "新手术";
                dialogHostForm.Width = view.Width;
                dialogHostForm.Height = view.Height;
                dialogHostForm.AutoScroll = true;
                dialogHostForm.StartPosition = FormStartPosition.CenterScreen;

                view.Dock = DockStyle.Fill;
                dialogHostForm.Controls.Add(view);
                dialogHostForm.ShowDialog();
            }
            catch (Exception ex)
            {

                Exception excep = new Exception("自定义【新手术】模块加载失败，请检查配置！");
                ex.Source = excep.Source;
                ExceptionHandler.Handle(excep);
            }

            RefreshDataSource();
        }

        // 更新手术表信息
        protected void UpdateMasterTable(object patientId, object visitId, object operId, Dictionary<string, object> values)
        {
            AnesthesiaSheetDA anesthesiaSheetDA = new AnesthesiaSheetDA();
            AnesInformations.OperationMasterDataTable mt = anesthesiaSheetDA.GetOperationMaster(Convert.ToString(patientId), Convert.ToDecimal(visitId), Convert.ToDecimal(operId));
            if (mt.Count > 0)
            {
                foreach (KeyValuePair<string, object> pair in values)
                    mt[0][pair.Key] = pair.Value;
            }

            anesthesiaSheetDA.UpdateOperationMaster(mt);
        }


        // 更新手术表信息
        protected void UpdateRoomTable(object bedlabel, Dictionary<string, object> values)
        {
            DictDA dictDA = new DictDA();
            Dict.OperatingRoomDataTable mt = dictDA.GetOperatingRoomDict();
            DataRow[] rows = mt.Select(string.Format("BED_LABEL = '{0}'", bedlabel));
            if (rows.Length > 0)
            {
                foreach (KeyValuePair<string, object> pair in values)
                    rows[0][pair.Key] = pair.Value;
            }

            dictDA.UpdateOperatingRoomDict(mt);
        }

        public Dictionary<string, string[]> AquairResult()
        {
            CommonDA da = new CommonDA();
            DataTable dt = da.GetDataFromSQLString("select inp_no, AQUAIRED, DEAL_SEQUENCE  from prepare_aquair_all where (AQUAIRED = '√' or AQUAIRED = '×' or AQUAIRED = '＝') and oper_status < 35");

            Dictionary<string, string[]> result = new Dictionary<string, string[]>();
            if (dt == null)
                return result;

            foreach (DataRow row in dt.Rows)
            {
                string[] values = new string[2];
                values[0] = row["AQUAIRED"].ToString();
                values[1] = row["DEAL_SEQUENCE"].ToString();

                string inpNo = row["inp_no"].ToString();
                if(!result.ContainsKey(inpNo))
                    result.Add(inpNo, values);
            }

            return result;
        }


        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                try
                {
                    RefreshDataSource();

                    Dictionary<string, string[]> result = AquairResult();
                    if (result.Count == 0)
                        return;

                    string msg = "";

                    foreach (KeyValuePair<string, string[]> pair in result)
                    {
                        if (_msgPatientInpNo.ContainsKey(pair.Key.Trim()))
                        {
                            int kv = _msgPatientInpNo[pair.Key.Trim()];


                            if (pair.Value[0] == "√" && kv != 1)
                            {
                                msg += string.Format("准备室已准备接收病人{0}，请15分钟内将病人送至准备室。\n15分钟后申请可能被取消，需要重新申请", pair.Key);
                                _msgPatientInpNo[pair.Key.Trim()] = 1;
                            }
                            else if (pair.Value[0] == "＝" && kv != 2)
                            {
                                msg += string.Format("对不起，准备室目前无空床位，无法立即接收病人{0}。\n您是等待队列中第{1}位，请耐心等待，一旦床位空出，我们会及时接收。", pair.Key, pair.Value[1]);
                                _msgPatientInpNo[pair.Key.Trim()] = 2;
                            }
                            else if (pair.Value[0] == "×" && kv != 3)
                            {
                                msg += string.Format("病人{0}入准备室的申请因超时已被取消，请重新申请，谢谢\n", pair.Key);
                                _msgPatientInpNo[pair.Key.Trim()] = 3;
                            }

                            //_msgPatientInpNo.Add(pair.Key);
                        }
                    }
                    if (msg != "")
                    {
                        if (pm == null || pm.IsDisposed)
                        {
                            pm = new PacuMessage();
                        }
                        pm.SetContent(msg);
                        pm.Show();
                        pm.Location = new Point(Screen.PrimaryScreen.WorkingArea.Right - pm.Width, Screen.PrimaryScreen.WorkingArea.Height - pm.Height);
                    }

                    
                }
                catch (Exception err)
                {
                    ExceptionHandler.Handle(err);
                }
            }
        }





        private void toolStripMenuAccept_Click(object sender, EventArgs e)
        {
            if (_selectRow == null)
                return;

           
            if (_selectRow["PREPARE"]==DBNull.Value||(decimal)_selectRow["PREPARE"] != 1)
            {
                /*DataRow[] rows = DataSource.Select("bed_label='" + _selectRow["bed_label"].ToString() + "' ");
                if (rows != null && rows.Length > 1)
                {
                    DataRow[] otherRows = DataSource.Select("bed_label='" + _selectRow["bed_label"].ToString() + "'  and PREPARE=1 and (oper_status=0 or oper_status is null)");
                    if (otherRows != null && otherRows.Length > 0)
                    {
                        if (Dialog.MessageBox("该房间正在接收别的病人。是否暂停已安排的接收？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                        {
                            return;
                        }
                        otherRows[0]["OUT_PLACE"] = DBNull.Value;
                        Dictionary<string, object> updateValues = new Dictionary<string, object>();

                        otherRows[0]["PREPARE"] = DBNull.Value;

                        updateValues.Add("RESERVED7", DBNull.Value);
                        updateValues.Add("JT", DBNull.Value);
                        //DateTime time = (new CommonDA()).GetSysDateTime();
                        updateValues.Add("FIRST_SHIFT_SUPPLY_DATETIME", DBNull.Value);
                        UpdateMasterTable(otherRows[0]["PAT_ID"], otherRows[0]["VISIT_ID"], otherRows[0]["OPER_ID"], updateValues);
                    }
                }*/

                _selectRow["PREPARE"] = 1;
                _selectRow["OUT_PLACE"] = toolStripMenuAccept.Text;
                Dictionary<string, object> values = new Dictionary<string, object>();
                values.Add("JT", 1);
                values.Add("RESERVED7", toolStripMenuAccept.Text);
                DateTime time = (new CommonDA()).GetSysDateTime();
                values.Add("FIRST_SHIFT_SUPPLY_DATETIME", time);
                UpdateMasterTable(_selectRow["PAT_ID"], _selectRow["VISIT_ID"], _selectRow["OPER_ID"], values);

            }
            // 显示手术通知单
            ShowFormByDocName(_selectRow["PAT_ID"], _selectRow["VISIT_ID"], _selectRow["OPER_ID"], "手术通知单", -1, -1);

            _selectRow = null;
            RefreshDataSource();
        }

        private void toolStripStopAccept_Click(object sender, EventArgs e)
        {
            if (_selectRow == null)
                return;

            //if (_selectRow["PREPARE"].ToString() == "1")
            //    return;

            _selectRow["OUT_PLACE"] = DBNull.Value;
            Dictionary<string, object> updateValues = new Dictionary<string, object>();

            _selectRow["PREPARE"] = DBNull.Value;

            updateValues.Add("RESERVED7", DBNull.Value);
            updateValues.Add("JT", DBNull.Value);
            //DateTime time = (new CommonDA()).GetSysDateTime();
            updateValues.Add("FIRST_SHIFT_SUPPLY_DATETIME", DBNull.Value);
            UpdateMasterTable(_selectRow["PAT_ID"], _selectRow["VISIT_ID"], _selectRow["OPER_ID"], updateValues);
            RefreshDataSource();
        }

        private void toolStripCancelOper_Click(object sender, EventArgs e)
        {
            if (_selectRow == null)
                return;
            timerRefresh.Stop();
            if (DevExpress.XtraEditors.XtraMessageBox.Show("真的要取消患者“" + _selectRow["PAT_NAME"].ToString() + "”的手术吗？"
      , "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                object cancelReason = Dialog.SingleInputSelect("取消原因：", "");
                if (cancelReason == null)
                {
                    return;
                }
                if (ExtendApplicationContext.Current.PatientInformation != null)
                {
                    string PatientId = _selectRow["PAT_ID"].ToString();
                    decimal VisitId = (decimal)_selectRow["VISIT_ID"];
                    decimal OperId = (decimal)_selectRow["OPER_ID"];
                    if (ApplicationConfiguration.IsUpdateHisStatus)
                    {
                        try
                        {
                            //MessageBox.Show("回写调用");
                            string ret = (new SyncDA()).SyncWriteHisOperStatus(PatientId, (int)VisitId, (int)OperId);
                            //MessageBox.Show("调用结果：" + ret);
                        }
                        catch (Exception ex)
                        {
                            ExceptionHandler.Handle(ex);
                        }
                    }

                    CareDocsDA careDA = new CareDocsDA();
                    AnesthesiaSheetDA anesDA = new AnesthesiaSheetDA();
                    CareDocs.OperationCanceledDataTable dt = careDA.GetOperationCanceled(PatientId, (int)VisitId, (int)OperId);

                    if (dt != null)
                    {
                        AnesInformations.OperationMasterDataTable dtMaster = anesDA.GetOperationMaster(PatientId, (int)VisitId, (int)OperId);


                        CareDocs.OperationCanceledRow row = null;
                        AnesInformations.OperationMasterRow rowMaster = dtMaster.Count > 0 ? dtMaster[0] : null;


                        if (dt.Rows.Count < 1)
                        {
                            row = dt.NewOperationCanceledRow();
                            row.PAT_ID = PatientId;
                            row.VISIT_ID = VisitId;
                            row.OPERATION_ID = OperId.ToString();
                            row.CANCEL_ID = 0;
                            dt.Rows.Add(row);
                        }
                        else
                        {
                            row = dt[0];
                            row.CANCEL_ID++;
                        }

                        //if(string.IsNullOrEmpty(reason))
                        //   reason = radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Value.ToString();

                        row.CANCEL_REASON = cancelReason.ToString();

                        if (rowMaster != null)
                        {
                            if (!rowMaster.IsANES_ASSISTANTNull())
                                row.ANES_ASSISTANT = rowMaster.ANES_ASSISTANT;

                            if (!rowMaster.IsANES_DOCTORNull())
                                row.ANES_DOCTOR = rowMaster.ANES_DOCTOR;

                            if (!rowMaster.IsANES_METHODNull())
                                row.ANES_METHOD = rowMaster.ANES_METHOD;

                            if (!rowMaster.IsDEPT_STAYEDNull())
                                row.DEPT_STAYED = rowMaster.DEPT_STAYED;

                            if (!rowMaster.IsDIAG_BEFORE_OPERNull())
                                row.DIAG_BEFORE_OPER = rowMaster.DIAG_BEFORE_OPER;

                            if (!rowMaster.IsOPERATING_DEPTNull())
                                row.OPERATING_DEPT = rowMaster.OPERATING_DEPT;

                            if (!rowMaster.IsOPERATING_ROOMNull())
                                row.OPERATING_ROOM = rowMaster.OPERATING_ROOM;

                            if (!rowMaster.IsOPERATING_ROOM_NONull())
                                row.OPERATING_ROOM_NO = rowMaster.OPERATING_ROOM_NO;

                            if (!rowMaster.IsOPER_SCALENull())
                                row.OPER_SCALE = rowMaster.OPER_SCALE;

                            if (!rowMaster.IsSCHEDULED_DATE_TIMENull())
                                row.SCHEDULED_DATE_TIME = rowMaster.SCHEDULED_DATE_TIME;

                            if (!rowMaster.IsSURGEONNull())
                                row.SURGEON = rowMaster.SURGEON;

                            rowMaster.OPER_STATUS = -80;

                            anesDA.UpdateOperationMaster(dtMaster);
                        }

                        careDA.UpdateOperationCanceled(dt);
                    }
                }

                _selectRow = null;
            }
            RefreshDataSource();
            timerRefresh.Start();

            
        }

        private void toolStripToSickRoom_Click(object sender, EventArgs e)
        {
            if (_selectRow == null)
                return;
            _selectRow["OUT_PLACE"] = toolStripToSickRoom.Text;
            Dictionary<string, object> updateValues = new Dictionary<string, object>();



            _selectRow["OPER_STATUS"] = Convert.ToInt32(OperationStatus.TurnToSickRoom);
            _selectRow["PREPARE"] = 10;

            updateValues.Add("RESERVED7", toolStripToSickRoom.Text);
            updateValues.Add("JT", 10);
            updateValues.Add("OPER_STATUS", Convert.ToInt32(OperationStatus.TurnToSickRoom));
            DateTime time = (new CommonDA()).GetSysDateTime();
            updateValues.Add("FIRST_SHIFT_SUPPLY_DATETIME", time);

            //局麻
            if (!_selectRow.IsNull("anes_method") && (_selectRow["anes_method"].ToString().Contains("局部麻醉") || _selectRow["anes_method"].ToString().Contains("局麻")))
            {
                updateValues.Add("oper_status", Convert.ToInt32(OperationStatus.TurnToSickRoom));

                DateTime dt = DateTime.Now;
                dt.AddSeconds(-dt.Second);
                dt.AddMilliseconds(-dt.Millisecond);

                updateValues.Add("START_DATE_TIME", dt);
                updateValues.Add("ANES_START_TIME", dt);
                updateValues.Add("IN_DATE_TIME", dt);

                updateValues.Add("END_DATE_TIME", dt);
                updateValues.Add("ANES_END_TIME", dt);
                updateValues.Add("OUT_DATE_TIME", dt);
            }

            UpdateMasterTable(_selectRow["PAT_ID"], _selectRow["VISIT_ID"], _selectRow["OPER_ID"], updateValues);
            _selectRow = null;
            RefreshDataSource();
        }

        private void btnTomorrowList_Click(object sender, EventArgs e)
        {
            isTomorrow = 1;
            RefreshDataSource();
        }


        private void btnTodayList_Click(object sender, EventArgs e)
        {
            isTomorrow = 0;
            RefreshDataSource();
        }

        protected void CheckChange(string inp_no, string patient_id)
        {
            CommonDA commonDA = new CommonDA();
            DataTable dtMaster = commonDA.GetDataWithPrimaryKey("WIS_PAT_MASTER_INDEX", " WHERE INP_NO = '" + inp_no  + "'");
            if (dtMaster.Rows.Count == 2)
            {
                if (dtMaster.Rows[0]["PAT_ID"].ToString() == patient_id)
                {
                    RefreshPatInfo(patient_id, dtMaster.Rows[1]["PAT_ID"].ToString());
                }
                else
                {
                    RefreshPatInfo(patient_id, dtMaster.Rows[0]["PAT_ID"].ToString());
                }
            }
        }

        private void btnHisSync_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                SyncDA syncDA = new SyncDA();
                string ret;
                ret = syncDA.SyncScheduleInfo("");
                if (!string.IsNullOrEmpty(ret))
                {
                    ExceptionHandler.Handle(new Exception("同步手术申请信息失败\r\n" + ret));
                    ret = syncDA.SyncPatientInfoAndInHospital("");
                }
                if (string.IsNullOrEmpty(ret))
                {
                    // 将今天手术列表，明天手术列表，周一手术列表里的住院号不唯一的内容全部在刷一遍
                    CommonDA da = new CommonDA();
                    //DataTable dt = da.GetDataWithPrimaryKey("Oper_Process");
                    DataTable dt = da.GetDataWithPrimaryKey("wis_vw_operation_process");
                    foreach(DataRow row in dt.Rows)
                    {
                        CheckChange(row["INP_NO"].ToString(), row["PAT_ID"].ToString());
                    }

                    DataTable dtTm = da.GetDataWithPrimaryKey("wis_vw_operation_process_tm");
                    foreach (DataRow row in dtTm.Rows)
                    {
                        CheckChange(row["INP_NO"].ToString(), row["PAT_ID"].ToString());
                    }

                    DataTable dt3  = da.GetDataWithPrimaryKey("wis_vw_operation_process_threeday");
                    foreach (DataRow row in dt3.Rows)
                    {
                        CheckChange(row["INP_NO"].ToString(), row["PAT_ID"].ToString());
                    }

                    RefreshDataSource();
                    //Dialog.MessageBox(e.ViewName + "成功");
                }

                // 初始病区写入排班表RESEVED3字段
                SetOriginWardCode();

            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);

            }
            this.Cursor = Cursors.Default;
        }

        protected void SetOriginWardCode()
        {
            CommonDA commonDA = new CommonDA();
            string sql = "select * from WIS_OPER_MASTER where scheduled_date_time >= :SDATE and IRRITATE_NERVE is null";
            DataTable dtSchedule = commonDA.GetDataFromSQLString(sql, new object[] { DateTime.Today });
            ExceptionHandler.Handle(new Exception("要写入病区的数量为：" + dtSchedule.Rows.Count.ToString()), false);
            foreach (DataRow row in dtSchedule.Rows)
            {
                sql = string.Format("select ward_code from WIS_PAT_IN_HOS where pat_id  = '{0}'", row["PAT_ID"]);
                DataTable dtHos = commonDA.GetDataFromSQLString(sql);
                if (dtHos.Rows.Count > 0)
                {
                    row["IRRITATE_NERVE"] = dtHos.Rows[0]["WARD_CODE"];
                }
            }

            commonDA.Update(dtSchedule, "WIS_OPER_MASTER");
        }

        private void gridViewLeftList_DoubleClick(object sender, EventArgs e)
        {
            //if (_selectRow != null)
            //{
            //    if (_selectRow["PAT_ID"] != System.DBNull.Value && _selectRow["VISIT_ID"] != System.DBNull.Value && _selectRow["OPER_ID"] != System.DBNull.Value && !string.IsNullOrEmpty(_selectRow["PAT_ID"].ToString()))
            //    {
            //        ShowFormByDocName(_selectRow["PAT_ID"], _selectRow["VISIT_ID"], _selectRow["OPER_ID"], "手术信息", 825, 600);
            //        RefreshDataSource();
            //    }
            //    _selectRow = null;
            //}
        }


        protected void RefreshPatInfo(string patientidDes, string pateintidorg)
        {
            // 更新患者主信息
            CommonDA commonDA=new CommonDA();
            DataTable data = commonDA.GetDataWithPrimaryKey("WIS_PAT_MASTER_INDEX", " WHERE PAT_ID = '" + patientidDes + "' or PAT_ID = '" + pateintidorg + "'");
            if (data.Rows.Count == 2)
            {
                if(data.Rows[0]["PAT_ID"].ToString() == patientidDes)
                {
                    foreach (DataColumn column in data.Columns)
                    {
                        if (column.ColumnName.ToUpper() == "PAT_ID")
                            continue;

                        data.Rows[0][column] = data.Rows[1][column];
                    }

                    data.Rows[1].Delete();
                }
                else
                {
                    foreach (DataColumn column in data.Columns)
                    {
                        if (column.ColumnName.ToUpper() == "PAT_ID")
                            continue;

                        data.Rows[1][column] = data.Rows[0][column];
                    }

                    data.Rows[0].Delete();
                }

                 commonDA.UpdateDataTable(data) ;
                 commonDA.Update(data, "WIS_PAT_MASTER_INDEX");
            }
                                
             // 更新在院信息表
            DataTable data1 = commonDA.GetDataWithPrimaryKey("WIS_PAT_IN_HOS", " WHERE PAT_ID = '" + patientidDes + "' or PAT_ID = '" + pateintidorg + "'");
            if (data1.Rows.Count == 2)
            {
                if(data1.Rows[0]["PAT_ID"].ToString() == patientidDes)
                {
                    foreach (DataColumn column in data1.Columns)
                    {
                        if (column.ColumnName.ToUpper() == "PAT_ID")
                            continue;

                        data1.Rows[0][column] = data1.Rows[1][column];
                    }
                }
                else
                {
                    foreach (DataColumn column in data1.Columns)
                    {
                        if (column.ColumnName.ToUpper() == "PAT_ID")
                            continue;

                        data1.Rows[1][column] = data1.Rows[0][column];
                    }
                }

                commonDA.UpdateDataTable(data1);
                               
            }            
        }


        private void menuInpnoUpdate_Click(object sender, EventArgs e)
        {
            if (_selectRow == null) return;
            timerRefresh.Stop();
            object result = Dialog.SingleInputSelect("请输入住院号", "住院号更正", "", "");
            if (result != null && !string.IsNullOrEmpty(result.ToString().Trim()))
            {

                if (ApplicationConfiguration.SyncOpen)
                {
                    SyncDA syncDA = new SyncDA();
                    if (!string.IsNullOrEmpty(result.ToString().Trim()))
                    {
                        string ret = "";
                        try
                        {
                            ret = syncDA.SyncPatientInfoAndInHospitalByInpNo(result.ToString().Trim());
                        }
                        catch (Exception ex)
                        {
                            ExceptionHandler.Handle(ex);
                        }
                    }
                    CommonDA commonDA = new CommonDA();
                    string inpno = result.ToString().Trim();
                    string sql = string.Format("select * from WIS_PAT_MASTER_INDEX where inp_no = '{0}'", inpno);
                    DataTable dt = commonDA.GetDataFromSQLString(sql);
                    //DataTable dt = commonDA.GetDataWithPrimaryKey("WIS_PAT_MASTER_INDEX", " WHERE INP_NO = '" + result.ToString().Trim() + "'");
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        string msg = "输入的住院号" + inpno + "提取不到信息";
                        Dialog.MessageBox(msg + (dt == null ? "0" : "1"));
                        return;
                    }

                   DataRow[] otherRows = dt.Select("PAT_ID <> '" + _selectRow["PAT_ID"].ToString() + "'");
                   
                    if (otherRows.Length > 0)
                    {
                        DialogResult result2 = Dialog.MessageBox(string.Format("是否确定把住院号为【{0}】姓名为【{1}】的患者基本信息替换掉所选记录？", otherRows[0]["INP_NO"].ToString(), otherRows[0]["NAME"]), "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (result2 == DialogResult.OK)
                        {
                            RefreshPatInfo(_selectRow["PAT_ID"].ToString(), otherRows[otherRows.Length-1]["PAT_ID"].ToString());
                            //otherRows[otherRows.Length - 1].Delete();
                            commonDA.Update(dt, "WIS_PAT_MASTER_INDEX");
                            RefreshDataSource();
                            gridControlList.Refresh();
                        }
                    }   
                }
                else
                {
                    Dialog.MessageBox("住院号为空");
                }
            }
            timerRefresh.Start();
        }

        private void threedayslaterButton_Click(object sender, EventArgs e)
        {
            isTomorrow = 3;
            RefreshDataSource();
        }

        private void gridViewLeftList_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (!Framework.AccessControl.CheckModifyRight("手术进程"))
                return;

            _selectRow = gridViewLeftList.GetDataRow(e.RowHandle);
      
            if (e.Button == MouseButtons.Right)
            {

                if (_selectRow.IsNull("bed_label"))
                {
                    return;
                }

                int operstatus = 0;
                if (!_selectRow.IsNull("OPER_STATUS"))
                {
                    operstatus = Convert.ToInt32(_selectRow["OPER_STATUS"]);
                }
              

                menuInpnoUpdate.Visible = false;
                toolStripMenuAccept.Visible = false;
                toolStripStopAccept.Visible = false;
                toolStripCancelOper.Visible = false;
                toolStripToSickRoom.Visible = false;
                toolStripFinishRoom.Visible = false;
                toolStripCancelFinishRoom.Visible = false;
                toolStriptBedNo.Visible = false;
                toolStripMenuItemPrintInfo.Visible = false;

                //int operstatus = Convert.ToInt32(_selectRow["OPER_STATUS"]);
                if (gridViewLeftList.FocusedColumn.Caption == "病人目前所在" && operstatus >= 30 && isTomorrow == 0)
                {
                    Dict.AnesthesiaInputDictDataTable dict = (new DictDA()).GetDictTable("病人去向");
                    Dialog.ShowCustomSelection(dict, "ITEM_NAME", gridControlList, new Point(e.X, e.Y), new Size(80, 200)
                        , new EventHandler(delegate(object s1, EventArgs e1)
                        {
                            if (s1 is int)
                            {
                                int index = (int)s1;
                                _selectRow["OUT_PLACE"] = dict[index].ITEM_NAME;
                                Dictionary<string, object> updateValues = new Dictionary<string, object>();

                                updateValues.Add("RESERVED7", dict[index].ITEM_NAME);

                                UpdateMasterTable(_selectRow["PAT_ID"], _selectRow["VISIT_ID"], _selectRow["OPER_ID"], updateValues);

                            }
                        }));
                }
                else if (gridViewLeftList.FocusedColumn.Caption == "住院号")
                {
                    //menuInpnoUpdate.Visible = true;
                    //contextMenuStrip1.Show(gridControlList, e.X, e.Y);
                }
                else if (gridViewLeftList.FocusedColumn.Caption == "床位")
                {
                    toolStriptBedNo.Visible = true;
                    contextMenuStrip1.Show(gridControlList, e.X, e.Y);
                }
                else if (e.Column.AbsoluteIndex == 0 && isTomorrow == 0)
                {
                    if (_selectRow.Table.Columns.Contains("ISFINISH"))
                    {
                        if (_selectRow["ISFINISH"].ToString() == "1")
                            toolStripCancelFinishRoom.Visible = true;
                        else
                            toolStripFinishRoom.Visible = true;

                        contextMenuStrip1.Show(gridControlList, e.X, e.Y);
                    }
                }
                else if (operstatus == 0 && isTomorrow == 0)//gridViewLeftList.FocusedColumn.Caption == "病人目前所在" && 
                {
                    if (e.RowHandle >= 0)
                    {
                        if (_selectRow["PREPARE"] == DBNull.Value)//空
                        {
                            toolStripMenuAccept.Visible = true;
                            //toolStripMenuItem2.Visible = true;
                            toolStripCancelOper.Visible = true;
                            //toolStripMenuItem4.Visible = true;
                        }
                        else if ((decimal)_selectRow["PREPARE"] == 1)//接收状态
                        {
                            toolStripMenuAccept.Visible = true;
                            toolStripStopAccept.Visible = true;
                            toolStripCancelOper.Visible = true;
                            toolStripToSickRoom.Visible = true;
                        }
                    }
                    contextMenuStrip1.Show(gridControlList, e.X, e.Y);
                }
                else if (isTomorrow == 1)
                {
                    toolStripMenuItemPrintInfo.Visible = true;
                    contextMenuStrip1.Show(gridControlList, e.X, e.Y);
                }
                //else
                //{

                //    if (operstatus == 0)
                //    {
                //        if (e.RowHandle > 0)
                //        {
                //            DataRow preRow = gridViewLeftList.GetDataRow(e.RowHandle - 1);
                //            if (_selectRow["bed_label"].ToString() == preRow["bed_label"].ToString() && (preRow.IsNull("Out_place") || preRow["Out_place"].ToString().Trim() == ""))
                //            {
                //                return;
                //            }
                //        }
                //        menuPrepare.Visible = true;
                //        menuCancelOperation.Visible = true;

                //        if (!_selectRow.IsNull("anesthesia_method") && (_selectRow["anesthesia_method"].ToString().Contains("局部麻醉") || _selectRow["anesthesia_method"].ToString().Contains("局麻")))
                //        {
                //            menuInRoom.Visible = true;
                //        }
                //    }
                //    else if (operstatus > 0 && operstatus < 35)
                //    {
                //        if (!_selectRow.IsNull("anesthesia_method") && (_selectRow["anesthesia_method"].ToString().Contains("局部麻醉") || _selectRow["anesthesia_method"].ToString().Contains("局麻")))
                //        {
                //            menuOutRoom.Visible = true;
                //        }
                //    }

                //    contextMenuStripProcess.Show(gridControlList, e.X, e.Y);
                //}
            }
        }

        private void toolStripCancelFinishRoom_Click(object sender, EventArgs e)
        {
            if (_selectRow == null)
                return;

            Dictionary<string, object> updateValues = new Dictionary<string, object>();
            updateValues.Add("FINISH_DATE", DBNull.Value);
            UpdateRoomTable(_selectRow["BED_LABEL"], updateValues);

            _selectRow = null;
            RefreshDataSource();
        }

        private void toolStripFinishRoom_Click(object sender, EventArgs e)
        {
            if (_selectRow == null)
                return;

            Dictionary<string, object> updateValues = new Dictionary<string, object>();
            updateValues.Add("FINISH_DATE",  DateTime.Now);
            UpdateRoomTable(_selectRow["BED_LABEL"], updateValues);

            _selectRow = null;
            RefreshDataSource();
        }

        private void btnYesterday_Click(object sender, EventArgs e)
        {
            ShowFormByDocName(null, null, null, "昨日列表", -1, -1);
        }

        private void toolStriptBedNo_Click(object sender, EventArgs e)
        {
            if (_selectRow == null)
                return;

            timerRefresh.Stop();
            object result = Dialog.SingleInputSelect("请输入床位号", "床位号更正", "", "");
            if (result != null && !string.IsNullOrEmpty(result.ToString().Trim()))
            {
                Dictionary<string, object> updateValues = new Dictionary<string, object>();
                updateValues.Add("BED_NO", result.ToString());
                UpdateMasterTable(_selectRow["PAT_ID"], _selectRow["VISIT_ID"], _selectRow["OPER_ID"], updateValues);
            }
           
            RefreshDataSource();
            timerRefresh.Start();
        }

        private void toolStripAquairPrepare_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectRow == null)
                    return;


                string patient_ID = _selectRow["PAT_ID"].ToString();
                string inp_no = _selectRow["INP_NO"].ToString();
                decimal VISIT_ID = Convert.ToDecimal(_selectRow["VISIT_ID"]);
                decimal OPER_ID = Convert.ToDecimal(_selectRow["OPER_ID"]);

                DateTime time = (new CommonDA()).GetSysDateTime();

                Dictionary<string, object> values = new Dictionary<string, object>();
                values.Add("AT", 5);
                values.Add("INQUIRY_BEFORE_DATE", time);
                UpdateMasterTable(patient_ID, VISIT_ID, OPER_ID, values);
                //MessageBox.Show(patient_ID + "," + VISIT_ID.ToString() + "," + OPER_ID.ToString());

                if (!_msgPatientInpNo.ContainsKey(inp_no))
                    _msgPatientInpNo.Add(inp_no, 0);


                ShowFormByDocName(_selectRow["PAT_ID"], _selectRow["VISIT_ID"], _selectRow["OPER_ID"], "手术通知单", -1, -1);

            }
            catch (Exception err)
            {
                ExceptionHandler.Handle(err);
            }

        }

        private void 紧急申请ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectRow == null)
                    return;


                string patient_ID = _selectRow["PAT_ID"].ToString();
                string inp_no = _selectRow["INP_NO"].ToString();
                decimal VISIT_ID = Convert.ToDecimal(_selectRow["VISIT_ID"]);
                decimal OPER_ID = Convert.ToDecimal(_selectRow["OPER_ID"]);

                DateTime time = DateTime.Now.Date;

                Dictionary<string, object> values = new Dictionary<string, object>();
                values.Add("AT", 5);
                values.Add("INQUIRY_BEFORE_DATE", time);
                UpdateMasterTable(patient_ID, VISIT_ID, OPER_ID, values);
                //MessageBox.Show(patient_ID + "," + VISIT_ID.ToString() + "," + OPER_ID.ToString());

                if (!_msgPatientInpNo.ContainsKey(inp_no))
                    _msgPatientInpNo.Add(inp_no, 0);


                ShowFormByDocName(_selectRow["PAT_ID"], _selectRow["VISIT_ID"], _selectRow["OPER_ID"], "手术通知单", -1, -1);

            }
            catch (Exception err)
            {
                ExceptionHandler.Handle(err);
            }

        }

        private void toolStripMenuItemPrintInfo_Click(object sender, EventArgs e)
        {
            if (_selectRow == null)
                return;


            string patient_ID = _selectRow["PAT_ID"].ToString();
            string inp_no = _selectRow["INP_NO"].ToString();
            decimal VISIT_ID = Convert.ToDecimal(_selectRow["VISIT_ID"]);
            decimal OPER_ID = Convert.ToDecimal(_selectRow["OPER_ID"]);
            ShowFormByDocName(_selectRow["PAT_ID"], _selectRow["VISIT_ID"], _selectRow["OPER_ID"], "手术通知单", -1, -1);

        }
    }
}
