using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Media;

using Wis.Anes.DataAccess;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.Framework.Documents;

using Wis.Anes.Framework.Utilities;

using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;

namespace Wis.Anes.Framework.Views.Process
{
    public partial class PACUProcess : BaseView
    {
        protected DataRow _selectRow = null; // 操作的行 
        protected static SoundPlayer _player = new SoundPlayer();

        public event EventHandler PatientSelected;
        protected static List<string> _msgPatientInpNo = new List<string>(); // 用于记录已提示信息的患者住院号
        protected static PacuMessage pm = null;

        static PACUProcess()
        {
            //_player.SoundLocation = "alarm.wav";
            //_player.Load();
        }

        public PACUProcess(Control ctrl)
        {
            InitializeComponent();

            try
            {
                ctrl.Dock = DockStyle.Fill;
                panelControl1.Controls.Add(ctrl);
              
                RefreshDataSource();
            }
            catch (Exception err)
            {
                ExceptionHandler.Handle(err);
            }
        }

        public DataTable PacuDataSource
        {
            get
            {
                if (gridControlList != null && gridControlList.DataSource != null && gridControlList.DataSource is DataTable)
                {
                    return gridControlList.DataSource as DataTable;
                }
                return null;
            }
            set
            {
                if (gridControlList != null)
                {
                    gridControlList.DataSource = value;
                }
            }
        }

        public DataTable WaitDataSource
        {
            get
            {
                if (gridControlWait != null && gridControlWait.DataSource != null && gridControlWait.DataSource is DataTable)
                {
                    return gridControlWait.DataSource as DataTable;
                }
                return null;
            }
            set
            {
                if (gridControlWait != null)
                {
                    gridControlWait.DataSource = value;
                }
            }
        }

        public static void CheckPacuWait()
        {
            CommonDA da = new CommonDA();
            DataTable dtWait = da.GetDataWithPrimaryKey("PACU_AQUAIR");

            foreach (DataRow row in dtWait.Rows)
            {
                if (row.IsNull("AQUAIRED") || string.IsNullOrEmpty(row["AQUAIRED"].ToString()))
                {
                    _player.Play();
                    break;
                }
            }
        }

        protected void RefreshDataSource()
        {
            CommonDA da = new CommonDA();
            DataTable dtPacu = da.GetDataWithPrimaryKey("PACU_Process");
            PacuDataSource = dtPacu;

            DataTable dtWait = da.GetDataWithPrimaryKey("PACU_AQUAIR");
            WaitDataSource = dtWait;

            _selectRow = null;

            // 获取今日总共收治病人
            DateTime dayCurrent = DateTime.Now;
            DateTime startTime, endTime;
            if (dayCurrent.Hour < 8)
            {
                startTime = dayCurrent.Date.AddDays(-1).AddHours(8);
                endTime = dayCurrent;
            }
            else
            {
                startTime = dayCurrent.Date.AddHours(8);
                endTime = dayCurrent;
            }

            string sql = @"select count(pat_id) as count from WIS_OPER_MASTER t where t.oper_status >= 45 and  t.in_pacu_date_time is not null and t.in_pacu_date_time < @ENDDATE and t.in_pacu_date_time > @STARTDATE";

            DataTable dt = da.GetDataFromSQLString(sql, new object[] { endTime, startTime });
            int count = Convert.ToInt32(dt.Rows[0]["COUNT"]);
            labelPacuCount.Text = count.ToString();
        }

        private void gridViewLeftList_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            GridView view = gridControlList.MainView as GridView;
            if (view == null)
                return;

            DataRow row = view.GetDataRow(e.RowHandle);
            string TimeSpan = row["TIME_SPAN"].ToString();

            string[] spanTimes = TimeSpan.Split(':');
            int hour = 0;
            if (!string.IsNullOrEmpty(spanTimes[0]))
            {
                if (spanTimes[0] == "###")
                {
                    hour = 99999;
                }
                else
                {
                    hour = Convert.ToInt32(spanTimes[0]);
                }
            }
            int minutes = string.IsNullOrEmpty(spanTimes[1]) ? 0 : Convert.ToInt32(spanTimes[1]);

            if (hour > 0) 
            {
                e.Appearance.BackColor2 = Color.FromArgb(255, 153, 204);
                e.Appearance.BackColor = Color.FromArgb(255, 153, 204);
                e.Appearance.ForeColor = Color.Black;
            }
            else if (minutes < 30) 
            {
                e.Appearance.BackColor2 = Color.FromArgb(255, 255, 153);
                e.Appearance.BackColor = Color.FromArgb(255, 255, 153);
                e.Appearance.ForeColor = Color.Black;
            }
            else 
            {
                e.Appearance.BackColor2 = Color.FromArgb(204, 255, 204);
                e.Appearance.BackColor = Color.FromArgb(204, 255, 204);
                e.Appearance.ForeColor = Color.Black;
            }
            
        }

        private void gridViewWait_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                return;

            if (!AccessControl.CheckModifyRight("PACU进程"))
                return;

            _selectRow = gridViewWait.GetDataRow(e.RowHandle);

            menuCancelPermit.Visible = false;
            menuPermit.Visible = false;
            menuInPacu.Visible = false;

            if (string.IsNullOrEmpty(_selectRow["AQUAIRED"].ToString()) || _selectRow["AQUAIRED"].ToString() == "＝")
                menuPermit.Visible = true;
            else
            {
                menuCancelPermit.Visible = true;
                menuInPacu.Visible = true;
            }

            contextMenuStripPacu.Show(gridControlWait, e.X, e.Y);
        }

        // 更新手术表信息
        protected static void UpdateMasterTable(object patientId, object visitId, object operId, Dictionary<string, object> values)
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

        private void menuPermit_Click(object sender, EventArgs e)
        {
            if (_selectRow == null)
                return;

            DateTime time = (new CommonDA()).GetSysDateTime();

            _selectRow["AQUAIRED"] = "√";
            _selectRow["AQUAIRED_TIME"] = time;


            Dictionary<string, object> values = new Dictionary<string, object>();
            values.Add("JT", 6);
            values.Add("RESERVED10", time);
            //values.Add("OPER_STATUS", Convert.ToInt32(OperationStatus.TurnToPACU));
            UpdateMasterTable(_selectRow["PAT_ID"], _selectRow["VISIT_ID"], _selectRow["OPER_ID"], values);
        }

        private void menuCancelPermit_Click(object sender, EventArgs e)
        {
            if (_selectRow == null)
                return;

            _selectRow["AQUAIRED"] = "×";
            _selectRow["AQUAIRED_TIME"] = DBNull.Value;
           
            Dictionary<string, object> values = new Dictionary<string, object>();
            values.Add("JT", 4);
            values.Add("RESERVED10", DBNull.Value);
            //values.Add("OPER_STATUS", Convert.ToInt32(OperationStatus.OutOperationRoom));
            UpdateMasterTable(_selectRow["PAT_ID"], _selectRow["VISIT_ID"], _selectRow["OPER_ID"], values);
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            RefreshDataSource();

        }

        private void gridViewWait_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            DataRow row = gridViewWait.GetDataRow(e.RowHandle);

            if (!row.IsNull("AQUAIRED_TIME"))
            {

                DateTime dt = Convert.ToDateTime(row["AQUAIRED_TIME"]);

                TimeSpan span = DateTime.Now - dt;

                if (span.TotalMinutes > 15)
                {
                    e.Appearance.BackColor2 = Color.FromArgb(153, 204, 255);
                    e.Appearance.BackColor = Color.FromArgb(153, 204, 255);
                    e.Appearance.ForeColor = Color.Black;
                }
            }
            if (!row.IsNull("AQUAIR_PACU_TIME"))
            {

                DateTime dt = Convert.ToDateTime(row["AQUAIR_PACU_TIME"]);

                TimeSpan span = DateTime.Now - dt;
                if (!row.IsNull("AQUAIRED") && (row["AQUAIRED"].ToString() == "×" || row["AQUAIRED"].ToString() == ""))
                {

                }
                else
                {
                    if (span.TotalMinutes > 15)
                    {
                        e.Appearance.BackColor2 = Color.Red;
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.Black;
                    }
                }
            }
        }


        public void FirePatientSelectedEvent()
        {
            if (PatientSelected != null)
                PatientSelected(this, EventArgs.Empty);
        }

        private void menuInPacu_Click(object sender, EventArgs e)
        {
            if (_selectRow == null)
                return;

            if (_selectRow.IsNull("OPER_STATUS") || Convert.ToInt32(_selectRow["OPER_STATUS"]) < 35)
            {
                Dialog.MessageBox("该患者还没有出手术室");
                return;
            }

            PatientInformation patientInformation = new PatientInformation(_selectRow["PAT_ID"].ToString(),
                          Convert.ToDecimal(_selectRow["Visit_ID"]), Convert.ToDecimal(_selectRow["Oper_ID"]), Convert.ToDecimal(_selectRow["OPER_STATUS"]),
                          _selectRow["PAT_NAME"].ToString(), _selectRow["BED_LABEL"].ToString(), _selectRow["BED_NO"].ToString(), _selectRow["INP_NO"].ToString(), 0, 0);
            if (patientInformation != null)
            {
                ExtendApplicationContext.Current.PatientContext.PatientID = patientInformation.PatientID;
                ExtendApplicationContext.Current.PatientContext.VisitID = patientInformation.VisitID;
                ExtendApplicationContext.Current.PatientContext.OperID = patientInformation.OperID;
            }
            else
            {
                ExtendApplicationContext.Current.PatientContext.PatientID = "";
            }
            ExtendApplicationContext.Current.PatientInformation = patientInformation;

            FirePatientSelectedEvent();
        }

        private void menuWait_Click(object sender, EventArgs e)
        {
            if (_selectRow == null)
                return;

            DateTime time = (new CommonDA()).GetSysDateTime();

            _selectRow["AQUAIRED"] = "＝";
            _selectRow["AQUAIRED_TIME"] = time;


            Dictionary<string, object> values = new Dictionary<string, object>();
            values.Add("JT", 7);
            values.Add("RESERVED10", time);
            //values.Add("OPER_STATUS", Convert.ToInt32(OperationStatus.TurnToPACU));
            UpdateMasterTable(_selectRow["PAT_ID"], _selectRow["VISIT_ID"], _selectRow["OPER_ID"], values);
        }

        #region 手术室调用部分
        public static bool AquireInPACU()
        {
            try
            {
                AquairPacuCondition pacuCondition = new AquairPacuCondition();
                DialogHostForm1 form = new DialogHostForm1("额外申请条件", 300, 160);
                form.Child = pacuCondition;
                if (form.ShowDialog() != DialogResult.OK)
                    return false;

                DateTime time = (new CommonDA()).GetSysDateTime();

                Dictionary<string, object> values = new Dictionary<string, object>();
                values.Add("JT", 5);
                values.Add("RESERVED9", time);
                values.Add("RESERVED6", pacuCondition.PacuCondition);
                UpdateMasterTable(ExtendApplicationContext.Current.PatientInformation.PatientID, ExtendApplicationContext.Current.PatientInformation.VisitID,
                    ExtendApplicationContext.Current.PatientInformation.OperID, values);

                if (!_msgPatientInpNo.Contains(ExtendApplicationContext.Current.PatientInformation.InpNo.Trim()))
                    _msgPatientInpNo.Add(ExtendApplicationContext.Current.PatientInformation.InpNo.Trim());

                return true;
            }
            catch (Exception err)
            {
                ExceptionHandler.Handle(err);
                return false;
            }

        }

        public static  Dictionary<string, string[]> AquairResult()
        {
            CommonDA da = new CommonDA();
            DataTable dt = da.GetDataFromSQLString("select inp_no, AQUAIRED, DEAL_SEQUENCE  from pacu_aquair_all where (AQUAIRED = '√' or AQUAIRED = '×' or AQUAIRED = '＝') and oper_status < 35");

            Dictionary<string, string[]> result = new Dictionary<string, string[]>();
            if (dt == null)
                return result;
            
            foreach (DataRow row in dt.Rows)
            {
                string[] values = new string[2];
                values[0] =  row["AQUAIRED"].ToString();
                values[1] = row["DEAL_SEQUENCE"].ToString();
                result.Add(row["inp_no"].ToString(), values);
            }

            return result;
        }


        public static void ShowPacuMsg()
        {
            Dictionary<string, string[]> result = AquairResult();
            if (result.Count == 0)
                return;

            string msg = "";

            foreach (KeyValuePair<string, string[]> pair in result)
            {
                if (_msgPatientInpNo.Contains(pair.Key.Trim()))
                {
                    if (pair.Value[0] == "√")
                        msg += string.Format("PACU已准备接收病人{0}，请15分钟内将病人送至PACU。\n15分钟后申请可能被取消，需要重新申请，谢谢。", pair.Key);
                    else if (pair.Value[0] == "＝")
                        msg += string.Format("对不起，PACU目前无空床位，无法立即接收病人{0}。\n您是等待队列中第{1}位，请耐心等待，一旦床位空出，我们会及时接收。", pair.Key, pair.Value[1]);
                    else
                        msg += string.Format("病人{0}入PACU的申请因超时已被取消，请重新申请，谢谢\n", pair.Key);

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

        #endregion 手术室调用部分
    }
}
