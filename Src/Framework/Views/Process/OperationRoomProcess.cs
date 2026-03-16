using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Wis.Anes.Framework.Views.Process
{
    public partial class OperationRoomProcess : UserControl
    {
        private bool _isBig = false;

        public OperationRoomProcess(string roomNo, bool isbig)
        {
            InitializeComponent();
            labelRoomNo.Text = roomNo;

            _isBig = isbig;
            if (_isBig)
            {
                Height = 60;
                labelDoneCount.Font = new Font("微软雅黑", 16, FontStyle.Bold);
                labelAllCount.Font = new Font("微软雅黑", 16, FontStyle.Bold);
                labelRoomNo.Font = new Font("微软雅黑", 22, FontStyle.Bold);
                labelRoomNo.Size = new Size(85, 60);
                labelDoneCount.Size = new Size(50, 32);
                labelDoneCount.Location = new Point(90, 0);
                labelAllCount.Size = new Size(50, 32);
                labelAllCount.Location = new Point(90, 30);

            }
        }

        public void SetLabelXPos(int pos)
        {
            labelRoomNo.Location = new Point(pos, labelRoomNo.Location.Y);
            int loc = _isBig ? 90 : 50;
            labelAllCount.Location = new Point(pos + loc, labelAllCount.Location.Y);
            labelDoneCount.Location = new Point(pos + loc, labelDoneCount.Location.Y);
        }

        public void SetInfo(DataRow[] rows, DateTime dayStartTime, int startPos, int minuteLength, int allCount)
        {
            

            List<OperationBaseInfo> lists = new List<OperationBaseInfo>();
            foreach (Control ctrl in Controls)
            {
                if (ctrl is OperationBaseInfo)
                    lists.Add(ctrl as OperationBaseInfo);
            }

            foreach (OperationBaseInfo info in lists)
            {
                Controls.Remove(info);
            }

            int doneCount = 0;
            foreach (DataRow row in rows)
            {
                DateTime startTime = Convert.ToDateTime(row["IN_DATE_TIME"]);
                DateTime endTime = row.IsNull("OUT_DATE_TIME")? DateTime.MinValue : Convert.ToDateTime(row["OUT_DATE_TIME"]);
                double useTime = Convert.ToDouble(row["USE_TIME"]);
                int status = Convert.ToInt32(row["OPER_STATUS"]);
                string emergency = row["EMERGENCY"].ToString();
                string info1 = row["INFO1"].ToString();
                string info2 = row["INFO2"].ToString();

                if (status == 0)
                    continue;

                Dictionary<OperationStatus, DateTime> statusDic = new Dictionary<OperationStatus, DateTime>();

                if (status >= Convert.ToInt32(OperationStatus.AnesthesiaStart) && !row.IsNull("ANES_START_TIME"))
                    statusDic.Add(OperationStatus.AnesthesiaStart, Convert.ToDateTime(row["ANES_START_TIME"]));

                //if (status >= Convert.ToInt32(OperationStatus.FinishAnesBegin) && !row.IsNull("ANES_START_DATE_TIME"))
                //    statusDic.Add(OperationStatus.FinishAnesBegin, Convert.ToDateTime(row["ANES_START_DATE_TIME"]));

                //if(status >= Convert.ToInt32(OperationStatus.PlacePatient) && !row.IsNull("REQ_DATE_TIME"))
                //    statusDic.Add(OperationStatus.PlacePatient, Convert.ToDateTime(row["REQ_DATE_TIME"]));

                if (status >= Convert.ToInt32(OperationStatus.OperationStart) && !row.IsNull("START_DATE_TIME"))
                    statusDic.Add(OperationStatus.OperationStart, Convert.ToDateTime(row["START_DATE_TIME"]));

                if (status >= Convert.ToInt32(OperationStatus.AnesthesiaEnd) && !row.IsNull("ANES_END_TIME"))
                    statusDic.Add(OperationStatus.AnesthesiaEnd, Convert.ToDateTime(row["ANES_END_TIME"]));


                OperationBaseInfo baseInfo = new OperationBaseInfo(startTime, endTime, info1, info2, statusDic, emergency, useTime, _isBig);
                Controls.Add(baseInfo);
                doneCount++;

                TimeSpan spanTime = startTime - dayStartTime;
                baseInfo.Location = new Point(startPos + Convert.ToInt32(spanTime.TotalMinutes * minuteLength + 0.5), 2);
                if (useTime >= 0 && status >=35)
                {
                    int width1 = Convert.ToInt32(useTime * minuteLength * 60 + 0.5);
                    baseInfo.Width = width1 < 2 ? 2 : width1;
                }
                else
                {
                    TimeSpan span = DateTime.Now - startTime;
                    double totalH = span.TotalHours > 24 ? 24 : span.TotalHours;
                    int width = Convert.ToInt32(totalH * minuteLength * 60 + 0.5);
                    baseInfo.Width = width < 2 ? 2 : width;
                }

                baseInfo.Height = Height;

                string timeStr =  "入室时间:" + startTime.ToShortTimeString() ; 
                if(!row.IsNull("ANES_START_TIME"))
                    timeStr += " 麻醉开始时间:" + Convert.ToDateTime(row["ANES_START_TIME"]).ToShortTimeString();

                if(!row.IsNull("START_DATE_TIME"))
                    timeStr += " 手术开始时间:" + Convert.ToDateTime(row["START_DATE_TIME"]).ToShortTimeString(); 

                if(!row.IsNull("ANES_END_TIME"))
                    timeStr +=  "\r\n麻醉结束时间:" + Convert.ToDateTime(row["ANES_END_TIME"]).ToShortTimeString(); 

                if(!row.IsNull("OUT_DATE_TIME"))
                    timeStr +=  " 出室时间:" + Convert.ToDateTime(row["OUT_DATE_TIME"]).ToShortTimeString(); 

                string tooltip = timeStr  + " " + emergency  + "\r\n" + info1 + "\r\n" + info2;

                toolTip1.SetToolTip(baseInfo, tooltip);
            }

            labelAllCount.Text = allCount.ToString();
            labelDoneCount.Text = doneCount.ToString();
        }


        public void SetPacuInfo(DataRow[] rows, DateTime dayStartTime, int startPos, int minuteLength)
        {

            List<OperationBaseInfo> lists = new List<OperationBaseInfo>();
            foreach (Control ctrl in Controls)
            {
                if (ctrl is OperationBaseInfo)
                    lists.Add(ctrl as OperationBaseInfo);
            }

            foreach (OperationBaseInfo info in lists)
            {
                Controls.Remove(info);
            }

            int doneCount = 0;
            foreach (DataRow row in rows)
            {
                DateTime startTime = Convert.ToDateTime(row["IN_PACU_DATE_TIME"]);
                DateTime endTime = row.IsNull("OUT_PACU_DATE_TIME") ? DateTime.MinValue : Convert.ToDateTime(row["OUT_PACU_DATE_TIME"]);
                DateTime pipeTime = row.IsNull("PULEPIPETIME") ? DateTime.MinValue : Convert.ToDateTime(row["PULEPIPETIME"]);
              
                double useTime = Convert.ToDouble(row["USE_TIME"]);
                int status = Convert.ToInt32(row["OPER_STATUS"]);
                string emergency = row["EMERGENCY"].ToString();
                string info1 = row["INFO1"].ToString();
                string info2 = row["INFO2"].ToString();
                string hasPipe = row["HASPIPE"].ToString();

                if (status == 0)
                    continue;

                Dictionary<OperationStatus, DateTime> statusDic = new Dictionary<OperationStatus, DateTime>();

                if(hasPipe == "1")
                {
                    if(row.IsNull("PULEPIPETIME"))
                        statusDic.Add(OperationStatus.InPACU, endTime);
                    else
                        statusDic.Add(OperationStatus.InPACU, pipeTime);
                }
                else
                {
                    statusDic.Add(OperationStatus.InPACU, startTime); // 入室时间做为拔管时间
                }

                OperationBaseInfo baseInfo = new OperationBaseInfo(startTime, endTime, info1, info2, statusDic, emergency, useTime, _isBig);
                Controls.Add(baseInfo);
                doneCount++;

                TimeSpan spanTime = startTime - dayStartTime;
                baseInfo.Location = new Point(startPos + Convert.ToInt32(spanTime.TotalMinutes * minuteLength + 0.5), 2);
                if (useTime >= 0 && status >= 55 )
                {
                    int width1 = Convert.ToInt32(useTime * minuteLength * 60 + 0.5);
                    baseInfo.Width = width1 < 2 ? 2 : width1;
                }
                else
                {
                    TimeSpan span = DateTime.Now - startTime;
                    double totalH = span.TotalHours > 24 ? 24 : span.TotalHours;
                    int width = Convert.ToInt32(totalH * minuteLength * 60 + 0.5);
                    baseInfo.Width = width < 2 ? 2 : width;
                }

                baseInfo.Height = Height;

                string timeStr = "入室时间:" + startTime.ToShortTimeString();
               

                if (!row.IsNull("OUT_PACU_DATE_TIME"))
                    timeStr += " 出室时间:" + Convert.ToDateTime(row["OUT_PACU_DATE_TIME"]).ToShortTimeString();

                string tooltip = timeStr + "\r\n" + info1 + "\r\n" + info2;

                toolTip1.SetToolTip(baseInfo, tooltip);
            }

            labelAllCount.Visible = false;
            labelDoneCount.Text = doneCount.ToString();
        }
       
    }
}
