using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.DataAccess;
using Wis.Anes.Framework.Controls;

namespace Wis.Anes.Framework
{
    [ToolboxItem(false)]
    public partial class TimePointItemsEditor : UserControl
    {
        public TimePointItemsEditor()
        {
            InitializeComponent();
        }

        public TimePointItemsEditor(string patientID, decimal visitID, decimal operID, decimal eventNo, MedDrugGraph drugGraph)
            : this()
        {
            _patientID = patientID;
            _visitID = visitID;
            _operID = operID;
            _eventNo = eventNo;

            List<string> list = new List<string>();
            if (drugGraph != null)
            {
                List<LineParameter> parameters = drugGraph.LineParameters;
                foreach (LineParameter parameter in parameters)
                {
                    if (!string.IsNullOrEmpty(parameter.Text) && !string.IsNullOrEmpty(parameter.Text.Trim()) && !list.Contains(parameter.Text.Trim()) && !parameter.Text.Trim().ToLower().Equals("o2"))
                    {
                        list.Add(parameter.Text.Trim());
                    }
                    if (!string.IsNullOrEmpty(parameter.Text2) && !string.IsNullOrEmpty(parameter.Text2.Trim()) && !list.Contains(parameter.Text2.Trim()) && !parameter.Text.Trim().ToLower().Equals("O2"))
                    {
                        list.Add(parameter.Text2.Trim());
                    }
                }
            }
            list.Remove("氧气");
            list.Remove("七氟醚");
            list.Remove("O2");
            list.Remove("o2");
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ToLower().StartsWith("ecg"))
                {
                    list.RemoveAt(i);
                    break;
                }
            }
            list.Add("ECG");
            list.Add("收缩压");
            list.Add("舒张压");
            list.Add("ABP收缩压");
            list.Add("ABP舒张压");
            list.Add("ABP平均压");
            list.Add("ART收缩压");
            list.Add("ART舒张压");
            list.Add("ART平均压");
            list.Add("肺动脉收缩压");
            list.Add("肺动脉舒张压");
            list.Add("心率");
            list.Add("体温");
            list.Add("直肠温");
            //list.Add("动脉收缩压");
            //list.Add("动脉舒张压");
            //list.Add("动脉收缩压2");
            //list.Add("动脉舒张压2");
            _timePointVitalSign = new TimePointVitalSign(patientID, visitID, operID, eventNo, list);
            _timePointVitalSign.Dock = DockStyle.Fill;
            xtraTabPageVitalSign.Controls.Add(_timePointVitalSign);

            _timePointLiquid = new TimePointLiquid(patientID, visitID, operID, eventNo);
            _timePointLiquid.Dock = DockStyle.Fill;
            xtraTabPageLiquid.Controls.Add(_timePointLiquid);

            _timePointDrugEditor = new TimePointDrugEditor(patientID, visitID, operID, eventNo);
            _timePointDrugEditor.Dock = DockStyle.Fill;
            xtraTabPageDrug.Controls.Add(_timePointDrugEditor);

            _timePointEventEditor = new TimePointEventEditor(patientID, visitID, operID, eventNo);
            _timePointEventEditor.Dock = DockStyle.Fill;
            xtraTabPageEvent.Controls.Add(_timePointEventEditor);

            _timePointBloodGasEditor = new TimePointBloodGasEditor1(patientID, visitID, operID, eventNo);
            _timePointBloodGasEditor.Dock = DockStyle.Fill;
            xtraTabPageBloodGas.Controls.Add(_timePointBloodGasEditor);

            _timePointVitalSign.IsDirtyChanged += new EventHandler(_IsDirtyChanged);
            _timePointLiquid.IsDirtyChanged += new EventHandler(_IsDirtyChanged);
            _timePointDrugEditor.IsDirtyChanged += new EventHandler(_IsDirtyChanged);
            _timePointEventEditor.IsDirtyChanged += new EventHandler(_IsDirtyChanged);
            _timePointBloodGasEditor.IsDirtyChanged += new EventHandler(_IsDirtyChanged);
        }

        private void _IsDirtyChanged(object sender, EventArgs e)
        {
            dateEdit1.Enabled = !IsDirty;
        }

        private string _patientID;
        private decimal _visitID, _operID;
        private decimal _eventNo = 0;
        private TimePointVitalSign _timePointVitalSign;
        private TimePointLiquid _timePointLiquid;
        private TimePointDrugEditor _timePointDrugEditor;
        private TimePointEventEditor _timePointEventEditor;
        private TimePointBloodGasEditor1 _timePointBloodGasEditor;

        public DateTime TimePoint
        {
            get
            {
                return dateEdit1.DateTime;
            }
        }

        public void SetMedGridPoint(MedGridPoint point)
        {
            if (_timePointDrugEditor != null)
            {
                _timePointDrugEditor.SetMedGridPoint(point);
            }
        }

        public void SetTimePoint(DateTime timePoint)
        {
            dateEdit1.DateTimeChanged -= new EventHandler(dateEdit1_DateTimeChanged);
            dateEdit1.DateTime = timePoint;
            GetTimePointValues();
            dateEdit1.DateTimeChanged += new EventHandler(dateEdit1_DateTimeChanged);
        }

        public bool IsDirty
        {
            get
            {
                bool result = false;
                if (_timePointVitalSign != null && _timePointVitalSign.IsDirty)
                {
                    result = true;
                }
                else if (_timePointLiquid != null && _timePointLiquid.IsDirty)
                {
                    result = true;
                }
                else if (_timePointDrugEditor != null && _timePointDrugEditor.IsDirty)
                {
                    result = true;
                }
                else if (_timePointEventEditor != null && _timePointEventEditor.IsDirty)
                {
                    result = true;
                }
                else if (_timePointBloodGasEditor != null && _timePointBloodGasEditor.IsDirty)
                {
                    result = true;
                }
                return result;
            }
        }

        public bool IsSaved
        {
            get
            {
                bool result = false;
                if (_timePointVitalSign != null && _timePointVitalSign.IsSaved)
                {
                    result = true;
                }
                if (_timePointLiquid != null && _timePointLiquid.IsSaved)
                {
                    result = true;
                }
                if (_timePointDrugEditor != null && _timePointDrugEditor.IsSaved)
                {
                    result = true;
                }
                if (_timePointEventEditor != null && _timePointEventEditor.IsSaved)
                {
                    result = true;
                }
                if (_timePointBloodGasEditor != null && _timePointBloodGasEditor.IsSaved)
                {
                    result = true;
                }
                return result;
            }
        }

        public bool Save()
        {
            bool result = true;
            if (_timePointVitalSign != null && _timePointVitalSign.IsDirty && !_timePointVitalSign.Save())
            {
                result = false;
            }
            if (_timePointLiquid != null && _timePointLiquid.IsDirty && !_timePointLiquid.Save())
            {
                result = false;
            }
            if (_timePointDrugEditor != null && _timePointDrugEditor.IsDirty && !_timePointDrugEditor.Save())
            {
                result = false;
            }
            if (_timePointEventEditor != null && _timePointEventEditor.IsDirty && !_timePointEventEditor.Save())
            {
                result = false;
            }
            if (_timePointBloodGasEditor != null && _timePointBloodGasEditor.IsDirty && !_timePointBloodGasEditor.Save())
            {
                result = false;
            }
            return result;
        }

        public void LocateKey(int index, string key)
        {
            if (_timePointLiquid != null)
            {
                _timePointLiquid.LocateKey(key);
            }
            if (_timePointDrugEditor != null)
            {
                _timePointDrugEditor.LocateKey(key);
            }
            if (_timePointVitalSign != null && index == 4)
            {
                _timePointVitalSign.LocateKey(key);
            }
            if (_timePointEventEditor != null)
            {
                _timePointEventEditor.LocateKey(key);
            }
            if (_timePointBloodGasEditor != null)
            {
                _timePointBloodGasEditor.LocateKey(key);
            }
            xtraTabControl1.SelectedTabPageIndex = index;
            xtraTabControl1.SelectedTabPage.Focus();
        }

        private bool GetTimePointValues()
        {
            bool result = true;
            if (_timePointVitalSign != null && !_timePointVitalSign.GetVitalValues(dateEdit1.DateTime))
            {
                result = false;
            }
            if (_timePointLiquid != null && !_timePointLiquid.GetVitalValues(dateEdit1.DateTime))
            {
                result = false;
            }
            if (_timePointDrugEditor != null && !_timePointDrugEditor.GetVitalValues(dateEdit1.DateTime))
            {
                result = false;
            }
            if (_timePointEventEditor != null && !_timePointEventEditor.GetVitalValues(dateEdit1.DateTime))
            {
                result = false;
            }
            if (_timePointBloodGasEditor != null && !_timePointBloodGasEditor.GetVitalValues(dateEdit1.DateTime))
            {
                result = false;
            }
            return result;
        }

        private void SaveTimePointValues()
        {
        }

         private void dateEdit1_DateTimeChanged(object sender, EventArgs e)
        {
            GetTimePointValues();
        }

    }
}
