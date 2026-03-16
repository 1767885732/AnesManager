using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Wis.Anes.Framework.Views.Process
{
    public partial class OperationBaseInfo : UserControl
    {
        protected DateTime _startTime;
        protected DateTime _endTime;
        protected string _emergency = "";
        protected string _info1 = "";
        protected string _info2 = "";
        protected Dictionary<OperationStatus, DateTime> _status;

        protected Brush _brushInOper = new SolidBrush(Color.FromArgb(204, 255, 204));
        protected Brush _brushPlacePatient = new SolidBrush(Color.FromArgb(186, 185, 217));
        protected Brush _brushBefAnes = new SolidBrush(Color.FromArgb(245, 182, 228));
        protected Brush _brushWake = new SolidBrush(Color.FromArgb(255, 204, 153));
        protected Brush _brushPrep = new SolidBrush(Color.FromArgb(255, 255, 153));
        protected Brush _brushPACU = new SolidBrush(Color.FromArgb(204, 224, 255));
        protected Brush _brushWait = new SolidBrush(Color.LightCoral);

        protected Brush _brushEnm = new SolidBrush(Color.Maroon);
        protected Brush _brushNor = new SolidBrush(Color.DarkGreen);
        protected Brush _brushAdd = new SolidBrush(Color.Goldenrod);
        protected Brush _brushImp = new SolidBrush(Color.Red);
        protected Font _fontEm = new Font("宋体", 12);
        protected bool _isBig = false;

        public OperationBaseInfo(DateTime dtStart, DateTime dtEnd, string info1, string info2, Dictionary<OperationStatus, DateTime> status, string emergency, double time, bool isBig)
        {
            InitializeComponent();

            _status = status;
            _emergency = emergency;
            _info1 = info1;
            _info2 = info2;
            _startTime = dtStart;
            _endTime = dtEnd;
            _isBig = isBig;
            if (isBig)
            {
                Height = (int)(Height * 1.5);
                _fontEm = new Font("宋体", 16);
            }

        }

        private void OperationBaseInfo_Paint(object sender, PaintEventArgs e)
        {
            // 绘制底色
            int startX = Width;
            if (_status.ContainsKey(OperationStatus.InPACU))
            {
                // 这里时间改为拔管时间
                if(_status[OperationStatus.InPACU].Equals(DateTime.MinValue))
                {
                    e.Graphics.FillRectangle(_brushInOper, 0, 0, startX, Height);
                    startX = 0;
                }
                else
                {
                    TimeSpan span = _status[OperationStatus.InPACU] - _startTime;
                    int len = Convert.ToInt32(span.TotalHours * 120 + 0.5);
                    e.Graphics.FillRectangle(_brushPACU, len, 0, startX - len, Height);
                    
                    startX = len;
                }

                /*
                e.Graphics.FillRectangle(_brushPACU, 0, 0, startX, Height);

                if (!DateTime.MinValue.Equals(_status[OperationStatus.InPACU]))
                {
                    TimeSpan span = _status[OperationStatus.InPACU] - _startTime;
                    int len = Convert.ToInt32(span.TotalHours * 120 + 0.5);

                    if (len > Width)
                        len = Width;

                    // 这里时间昨为拔管时间
                    e.Graphics.FillRectangle(Brushes.DarkGreen, len, 0, 3, Height);
                }
                
                startX = 0;*/
            }


            if (_status.ContainsKey(OperationStatus.AnesthesiaEnd))
            {
                TimeSpan span = _status[OperationStatus.AnesthesiaEnd] - _startTime;
                int len = Convert.ToInt32(span.TotalHours * 120 + 0.5);
                e.Graphics.FillRectangle(_brushWake, len, 0, startX - len, Height);
                startX = len;
            }

            if (_status.ContainsKey(OperationStatus.OperationStart))
            {
                TimeSpan span = _status[OperationStatus.OperationStart] - _startTime;
                int len = Convert.ToInt32(span.TotalHours * 120 + 0.5);

                e.Graphics.FillRectangle(_brushInOper, len, 0, startX - len, Height);
                startX = len;
            }


            //if (_status.ContainsKey(OperationStatus.PlacePatient))
            //{
            //    TimeSpan span = _status[OperationStatus.PlacePatient] - _startTime;
            //    int len = Convert.ToInt32(span.TotalHours * 120 + 0.5);

            //    e.Graphics.FillRectangle(_brushPlacePatient, len, 0, startX - len, Height);
            //    startX = len;
            //}

            //if (_status.ContainsKey(OperationStatus.FinishAnesBegin))
            //{
            //    TimeSpan span = _status[OperationStatus.FinishAnesBegin] - _startTime;
            //    int len = Convert.ToInt32(span.TotalHours * 120 + 0.5);

            //    e.Graphics.FillRectangle(_brushWait, len, 0, startX - len, Height);
            //    startX = len;
            //}
            

            if (_status.ContainsKey(OperationStatus.AnesthesiaStart))
            {
                TimeSpan span = _status[OperationStatus.AnesthesiaStart] - _startTime;
                int len = Convert.ToInt32(span.TotalHours * 120 + 0.5);

                e.Graphics.FillRectangle(_brushBefAnes, len, 0, startX - len, Height);
                startX = len;
            }

            if (startX > 0)
            {
                if(_status.ContainsKey(OperationStatus.InPACU))
                    e.Graphics.FillRectangle(_brushInOper, 0, 0, startX, Height);
                else
                    e.Graphics.FillRectangle(_brushPrep, 0, 0, startX, Height);
            }


            // 绘制文字
            Brush brush = Brushes.Black;
            switch (_emergency)
            {
                case "择期":
                    brush = _brushNor;
                    break;
                case "急诊":
                    brush = _brushEnm;
                    break;
                case "加台":
                    brush = _brushAdd;
                    break;
                case "紧急":
                    brush = _brushImp;
                    break;
            }

            e.Graphics.DrawString("●", _fontEm, brush, 4, 8);
            e.Graphics.DrawString(_info1, Font,  Brushes.Navy, 26, 9);

            int y = _isBig ? 30 : 26;
            e.Graphics.DrawString(_info2, Font, Brushes.Navy, 3, y);

            e.Graphics.DrawLine(Pens.Black, 0, 0, 0, Height);
            e.Graphics.DrawLine(Pens.Black, 0, 0, Width, 0);
            e.Graphics.DrawLine(Pens.Black, 0, Height - 3, Width, Height - 3);

            if (!_endTime.Equals(DateTime.MinValue))
                e.Graphics.DrawLine(Pens.Black, Width-1, 0, Width-1, Height);

            //string str = string.Format("Location = {0},{1}", Location.X, Location.Y);
            //e.Graphics.DrawString(str, Font, Brushes.Red, 0, 0);
        }
    }
}
