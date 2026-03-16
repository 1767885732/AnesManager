/*----------------------------------------------------------------
      // Copyright (C) 2010 北京拓扑工厂科技发展有限公司
      // 文件名：LastMonitorData.cs
      // 文件功能描述：最新监护数据展示
      //
      // 
      // 创建标识：XXX-2010-11-01
      // 修改标识：
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework;
using Wis.Anes.BusinessEntity;
using Wis.Anes.ServiceProxies;
using Wis.Anes.Layouts;

namespace Wis.Anes.Views
{
    /// <summary>
    /// 最新监护数据展示
    /// </summary>
    [ToolboxItem(false)]
    public class LastMonitorData : UserControl
    {
        private Timer timer1;
        private IContainer components;
        private List<MonitorDataItem> _items = new List<MonitorDataItem>();

        public List<MonitorDataItem> Items
        {
            get
            {
                return _items;
            }
        }

        public LastMonitorData()
        {
            //@临时注释 测试用
            InitializeComponent();
            if (!DesignMode)
            {
                Load += new EventHandler(LastMonitorData_Load);
            }
        }




        private Dict.WisPatMonitorDataDictDataTable patMonitorDataDictDataTable = new Dict.WisPatMonitorDataDictDataTable();




        private void LastMonitorData_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                patMonitorDataDictDataTable = DictProxy.GetPatMonitorDataDict();


                // 暂时注释掉
                refreshData();
                if (Parent != null)
                {
                    Parent.MouseMove += new MouseEventHandler(Parent_MouseMove);
                }
                MouseClick += new MouseEventHandler(LastMonitorData_MouseClick);
            }
        }

        private void Test()
        {
            if (Parent != null && Parent.Dock == DockStyle.Right)
            {
                Parent.Visible = false;
                return;
            }
            Font font = new Font("黑体", 20);
            _items.Add(new MonitorDataItem("血压", Color.Blue, font, 85, 46));
            _items.Add(new MonitorDataItem("动脉压", Color.Red, font, 118, 68));
            //_items.Add(new MonitorDataItem("平均压", Color.FromArgb(128,254,128), font, 89));
            _items.Add(new MonitorDataItem("ETCO2", Color.FromArgb(96, 192, 96), font, 27));
            _items.Add(new MonitorDataItem("呼吸", Color.FromArgb(255, 0, 255), font, 10));
            _items.Add(new MonitorDataItem("肛温", Color.FromArgb(120, 0, 239), font, 34.5));
            _items.Add(new MonitorDataItem("SPO2", Color.FromArgb(122, 122, 242), font, 100));
            _items.Add(new MonitorDataItem("心率", Color.FromArgb(128, 252, 0), font, 96));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_items != null && _items.Count > 0)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                float yOffSet = 2;
                float ySpan = ((float)(Height - yOffSet)) / (float)_items.Count;
                foreach (MonitorDataItem item in _items)
                {
                    item.Draw(e.Graphics, 10, yOffSet, 140);
                    yOffSet += ySpan;
                }
            }
        }



        public void refreshData()
        {
            _items.Clear();
            decimal dataType = 0;
            if (ExtendApplicationContext.Current.SystemStatus == ProgramStatus.PACURecord)
            {
                dataType = 1;
            }
            if (!string.IsNullOrEmpty(ExtendApplicationContext.Current.PatientContext.PatientID))
            {

                if (ExtendApplicationContext.Current.VitalSignCurveDetailDict != null)
                {
                    AnesInformations.VitalSignDataTable vitalSignDataTable = AnesthesiaSheetProxy.GetVitalSignData(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID, dataType);

                    SetPatientAlarmInfo(vitalSignDataTable);

                    if (vitalSignDataTable.Rows.Count > 0)
                    {
                        Font font = new Font("黑体", 9);
                        DateTime lastTime = vitalSignDataTable[vitalSignDataTable.Count - 1].TIME_POINT;
                        Dictionary<string, MonitorDataItem> dict = new Dictionary<string, MonitorDataItem>();
                        foreach (AnesInformations.VitalSignRow row in vitalSignDataTable.Select("TIME_POINT='" + lastTime.ToString() + "'"))
                        {
                            if (ExtendApplicationContext.Current.VitalSignCurveDetailDict.ContainsKey(row.ITEM_CODE))
                            {
                                double d = 0;
                                if (!double.TryParse(row.VALUE, out d))
                                {
                                    d = 0;
                                }
                                if (d > 0)
                                {
                                    if (row.ITEM_NAME.Contains("收缩压") || row.ITEM_NAME.Contains("舒张压"))
                                    {
                                        string key = row.ITEM_NAME.Replace("收缩压", "").Replace("舒张压", "");
                                        if (!dict.ContainsKey(key))
                                        {
                                            dict.Add(key, new MonitorDataItem(key, TrancColor(ExtendApplicationContext.Current.VitalSignCurveDetailDict[row.ITEM_CODE].Color), font, d));
                                        }
                                        if (row.ITEM_NAME.Contains("收缩压"))
                                        {
                                            dict[key].MinValue = d;
                                        }
                                        else
                                        {
                                            dict[key].MaxValue = d;
                                        }
                                    }
                                    else
                                    {
                                        _items.Add(new MonitorDataItem(row.ITEM_NAME, TrancColor(ExtendApplicationContext.Current.VitalSignCurveDetailDict[row.ITEM_CODE].Color), font, d));
                                    }
                                }
                            }
                        }
                        if (dict.Count > 0)
                        {
                            Dictionary<string, MonitorDataItem>.Enumerator enum1 = dict.GetEnumerator();
                            while (enum1.MoveNext())
                            {
                                _items.Add(enum1.Current.Value);
                                string key = enum1.Current.Value.ItemName;
                                if (key.Length > 0 && key[key.Length - 1] >= '1' && key[key.Length - 1] <= '9')
                                {
                                    key = key.Substring(0, key.Length - 1) + "压" + key[key.Length - 1];
                                }
                                else
                                {
                                    if (key.Length == 0)
                                    {
                                        key = "血";
                                    }
                                    key += "压";
                                }
                                enum1.Current.Value.ItemName = key;
                            }
                        }
                        if (_items.Count > 0)
                        {
                            float fontSize = 12;
                            if (_items.Count < 10)
                            {
                                fontSize = 16;
                            }
                            foreach (MonitorDataItem item in _items)
                            {
                                item.Font = new Font("黑体", fontSize);
                            }
                        }
                    }
                }
            }
            if (_items.Count == 0)
            {
                Test();
            }
            else
            {
                //if (Parent != null && Parent.Dock == DockStyle.Right && ApplicationConfiguration.DisplayLastMonitorData && Globals.CurrentControl is AnesthesiaRecord)
                //{
                //    Parent.Visible = true;
                //}
                Parent.Visible = true;
            }
        }



        private Color TrancColor(Color source)
        {
            byte r = source.R;
            byte g = source.G;
            byte b = source.B;
            if (r < 205)
            {
                r += 50;
            }
            if (g < 205)
            {
                g += 50;
            }
            if (b < 205)
            {
                b += 50;
            }
            return Color.FromArgb(r, g, b);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // LastMonitorData
            // 
            this.Name = "LastMonitorData";
            this.ResumeLayout(false);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            refreshData();
        }

        private int _width = 10;
        int width = 1;

        private void LastMonitorData_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Parent.Width > width)
                {
                    _width = Parent.Width;
                    Parent.Width = width;
                }
            }
        }

        private void Parent_MouseMove(object sender, MouseEventArgs e)
        {
            if (Parent.Width == width)
            {
                Parent.Width = _width;
            }
        }





        public void SetPatientAlarmInfo(AnesInformations.VitalSignDataTable vitalSignData)
        {
            if (ExtendApplicationContext.Current.AppType == ApplicationType.Anesthesia)
            {
                patMonitorDataDictDataTable = DictProxy.GetPatMonitorDataDict();
                decimal value = 0;
                string msg = "";
                bool bNeedAlarm = false;

                if (vitalSignData != null && vitalSignData.Rows.Count > 0)
                {

                    DataTable dtAnesAlarmMsg = AnesthesiaSheetProxy.GetAnesAlarmMsg(
              ExtendApplicationContext.Current.PatientContext.PatientID,
              ExtendApplicationContext.Current.PatientContext.VisitID,
              ExtendApplicationContext.Current.PatientContext.OperID);

                    DateTime lastTime = vitalSignData[vitalSignData.Count - 1].TIME_POINT;

                    foreach (AnesInformations.VitalSignRow vitalSignRow in vitalSignData.Select("TIME_POINT='" + lastTime.ToString() + "'"))
                    {

                        if (dtAnesAlarmMsg != null && dtAnesAlarmMsg.Rows.Count > 0)
                        {
                            DataRow[] dataRow = dtAnesAlarmMsg.Select("MSG_TIME = '" + vitalSignRow.TIME_POINT.ToString() + "'  and  ALARM_ITEM = '" + vitalSignRow.ITEM_CODE + "'");
                            if (dataRow != null && dataRow.Length > 0)
                            {
                                continue; //判断是否有记录
                            }
                        }


                        foreach (Dict.WisPatMonitorDataDictRow patMonitorDataDictRow in patMonitorDataDictDataTable)
                        {
                            if (vitalSignRow.ITEM_CODE == patMonitorDataDictRow.DB_DATA_NAME)
                            {

                                if (!vitalSignRow.IsVALUENull())
                                {
                                    value = decimal.Parse(vitalSignRow.VALUE);

                                    if (!patMonitorDataDictRow.IsLOW_SIGNS_VALUESNull() && value > 0)
                                    {
                                        //2014-5-30 周青 患者预警大于最大值小于最小值
                                        //if (value <= patMonitorDataDictRow.LOW_SIGNS_VALUES)
                                        if (value < patMonitorDataDictRow.LOW_SIGNS_VALUES)
                                        {



                                            msg = vitalSignRow.TIME_POINT.ToString("yyyy-MM-dd hh:mm:ss") + " " + patMonitorDataDictRow.MONITOR_DATA_NAME + " 值为:" + value + " 低于预设的警戒值 : " + patMonitorDataDictRow.LOW_SIGNS_VALUES;

                                            DataRow row = dtAnesAlarmMsg.NewRow();

                                            row["PAT_ID"] = ExtendApplicationContext.Current.PatientContext.PatientID;
                                            row["VISIT_ID"] = ExtendApplicationContext.Current.PatientContext.VisitID;
                                            row["OPER_ID"] = ExtendApplicationContext.Current.PatientContext.OperID;
                                            row["MSG_NO"] = Guid.NewGuid().ToString();
                                            row["ALARM_ITEM"] = vitalSignRow.ITEM_CODE;

                                            row["RECORD_TIME"] = DateTime.Now;
                                            row["MSG_TIME"] = vitalSignRow.TIME_POINT;
                                            row["MSG"] = msg;
                                            row["READ_FLAG"] = "0";

                                            dtAnesAlarmMsg.Rows.Add(row);

                                            bNeedAlarm = true ;
                                        }
                                    }

                                    if (!patMonitorDataDictRow.IsHIGH_SIGNS_VALUESNull() && value > 0)
                                    {
                                        //2014-5-30 周青 患者预警大于最大值小于最小值
                                        //if (value >= patMonitorDataDictRow.HIGH_SIGNS_VALUES)
                                        if (value > patMonitorDataDictRow.HIGH_SIGNS_VALUES)
                                        {

                                            msg = vitalSignRow.TIME_POINT.ToString("yyyy-MM-dd hh:mm:ss") + " " + patMonitorDataDictRow.MONITOR_DATA_NAME + " 值为:" + value + " 高于预设的警戒值 : " + patMonitorDataDictRow.HIGH_SIGNS_VALUES;

                                            DataRow row = dtAnesAlarmMsg.NewRow();

                                            row["PAT_ID"] = ExtendApplicationContext.Current.PatientContext.PatientID;
                                            row["VISIT_ID"] = ExtendApplicationContext.Current.PatientContext.VisitID;
                                            row["OPER_ID"] = ExtendApplicationContext.Current.PatientContext.OperID;
                                            row["MSG_NO"] = Guid.NewGuid().ToString();
                                            row["ALARM_ITEM"] = vitalSignRow.ITEM_CODE;
                                            row["RECORD_TIME"] = DateTime.Now;
                                            row["MSG_TIME"] = vitalSignRow.TIME_POINT;
                                            row["MSG"] = msg;
                                            row["READ_FLAG"] = "0";

                                            dtAnesAlarmMsg.Rows.Add(row);

                                            bNeedAlarm = true ;
                                        }
                                    }


                                }// if (!vitalSignRow.IsVALUENull() )

                            }


                        }

                    }


                    AnesthesiaSheetProxy.UpdateAnesAlarmMsg(dtAnesAlarmMsg);



                }
               // bNeedAlarm = true;
                if (bNeedAlarm)
                {

                    PatientAlarm patientAlarm = CurrentPatientAlarm.GetCurrentPatientAlarm();
                    patientAlarm.Caption = "患者预警提示: " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    //patientAlarm.LoadAlarmMsg();
                    DialogHostForm dialogHostForm = CurrentPatientAlarm.GetCurrentPatientAlarmForm( patientAlarm );


                    dialogHostForm.StartPosition = FormStartPosition.Manual;
                    dialogHostForm.Left = Screen.PrimaryScreen.Bounds.Width - dialogHostForm.Width - 20;
                    dialogHostForm.Top = Screen.PrimaryScreen.Bounds.Height - dialogHostForm.Height - 40;
                    dialogHostForm.TopMost = true;
                    dialogHostForm.Show();


                        

                }

            }
        }


    }
}
