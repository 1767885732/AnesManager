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

namespace Wis.Anes.Framework.Views.Process
{
    public partial class PacuRoomStatus : BaseView
    {
        protected int _scaleLeft = 100;        //坐标起始位置
        protected int _scaleTop = 30;
        protected double _startValue = 9;    //坐标起始值
        protected int _miniuteLength = 2;      //表示一分钟的长度

        protected Dictionary<string, Control> _roomCtrls = new Dictionary<string, Control>();

        public PacuRoomStatus()
        {
            InitializeComponent();
        }

        protected void RefreshDataSource()
        {
            try
            {
                DateTime timeValue = dateEdit1.DateTime.Date;
                DateTime time = timeValue.AddHours(_startValue);
                CommonDA commonDA = new CommonDA();
                //string sql = "select * from view_pacu_room_status where in_pacu_date_time >= :IN_DATE and in_pacu_date_time < :IN_DATE2";
                string sql = "select * from view_pacu_room_status where in_pacu_date_time >= @IN_DATE and in_pacu_date_time < @IN_DATE2";
                DataTable dtOperation = commonDA.GetDataFromSQLString(sql, new object[] { time, time.AddDays(1)});

                //sql = string.Format("select * from VIEW_OPERATON_COUNT where scheduled_date_time = '{0:yyyy-MM-dd}'",  time);
                //DataTable dtCount = commonDA.GetDataFromSQLString(sql);

                foreach (DataRow row in dtOperation.Rows)
                {
                    string roomNo = row["operating_room_no"].ToString();
                    OperationRoomProcess room = null;
                    if (_roomCtrls.ContainsKey(roomNo))
                        room = _roomCtrls[roomNo] as OperationRoomProcess;
                    else
                    {
                        room = new OperationRoomProcess(roomNo, false);
                        room.Dock = DockStyle.Top;
                        _roomCtrls.Add(roomNo, room);
                        panelControlMain.Controls.Add(room);
                    }
                }

                foreach (string roomNo in _roomCtrls.Keys)
                {
                    OperationRoomProcess room = _roomCtrls[roomNo] as OperationRoomProcess;

                    // 设置房间内容
                    DataRow[] operation = dtOperation.Select("OPERATING_ROOM_NO = '" + roomNo + "'");
                    for (int i = 0; i < operation.Length; i++)
                    {
                        //DataRow[] rowCount = dtCount.Select("OPERATING_ROOM_NO = '" + roomNo + "'");
                        room.SetPacuInfo(operation, time, _scaleLeft, _miniuteLength);
                    }
                }

                
            }
            catch (Exception err)
            {
                ExceptionHandler.Handle(err);
            }
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            RefreshDataSource();
        }

        private void pnlBody_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Black, _scaleLeft, _scaleTop, _scaleLeft + 1440, _scaleTop);
            for (int i = 0; i < 49; i++)
            {
                int x = _scaleLeft + i * _miniuteLength * 15; // 15分钟一个刻度
                int scaleLen = 5;
                if (i % 4 == 0)
                {
                    scaleLen = 11;
                    int time = i / 4 + Convert.ToInt32(_startValue); // 第二天
                    if (time > 24)
                        time -= 24;

                    e.Graphics.DrawString(time.ToString() + ":00", Font, Brushes.Blue, new PointF(x - 10, _scaleTop + 12));
                    
                }
                else if (i % 2 == 0)
                {
                    scaleLen = 8;
                }

               
                e.Graphics.DrawLine(Pens.Black, x, _scaleTop, x, _scaleTop + scaleLen);
            }

            //e.Graphics.DrawLine(Pens.Red, 220, 500, 220, 0);
        }

        private void OperationRoomStatus2_Load(object sender, EventArgs e)
        {
            dateEdit1.DateTime = DateTime.Now;
            RefreshDataSource();  

            ParentForm.FormClosed += new FormClosedEventHandler(ParentForm_FormClosed);

            panelControlMain.Focus();
        }

        protected void ParentForm_FormClosed(object sender, EventArgs e)
        {
            timerRefresh.Stop();
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            RefreshDataSource();
            panelControlMain.Focus();
        }

      

        private void tableLayoutPanel1_Scroll(object sender, ScrollEventArgs e)
        {
            // Console.Write(e.Type.ToString() + "\n");
            if (e.Type == ScrollEventType.ThumbPosition)
            {
                if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.HorizontalScroll)
                {
                    foreach (Control ctrl in _roomCtrls.Values)
                    {
                        OperationRoomProcess room = ctrl as OperationRoomProcess;
                        room.SetLabelXPos(e.NewValue);
                    }
                }
            }
        }

      
    }
}
