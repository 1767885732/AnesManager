using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using Wis.Anes.Framework.Controls.Base;
using Wis.Anes.Framework.Documents;
using Wis.Anes.Framework;

namespace Wis.Anes.CostomDoc
{
    public partial class CustomCommonBase : BaseControl
    {
        public BaseDoc baseDoc;
        public CustomCommonBase(DataRow patientRow) : this(patientRow, "评估单多次评估(2)") { }

        public CustomCommonBase(DataRow patientRow, string title)
            : base(patientRow, title)
        {
            InitializeComponent();
        }

        protected override void LoadDataOnce()
        {
            splitContainerControl1.Panel2.Text = string.IsNullOrEmpty(this.Parent.Text) ? this.Name : this.Parent.Text;
            baseDoc = new BaseDoc();
            //baseDoc = new Com.ICIS.Icu.Designer.BaseDoc(PatientRow, "");
            baseDoc.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            baseDoc.Appearance.Options.UseFont = true;
            baseDoc.AutoScroll = true;
            baseDoc.Caption = "";
            baseDoc.Cursor = System.Windows.Forms.Cursors.Default;
            baseDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            baseDoc.DocKind = DocKind.Default;
            baseDoc.IsFirstLoading = true;
            baseDoc.Location = new System.Drawing.Point(0, 0);
            baseDoc.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            baseDoc.Name = "baseDoc";
            baseDoc.PageWidth = 0;
            //baseDoc.RecTime = new System.DateTime(((long)(0)));
            baseDoc.Size = new System.Drawing.Size(1118, 406);
            baseDoc.TabIndex = 0;
            baseDoc.Tag = this.Tag;
            //baseDoc.BtnAddVivible = true;
            //baseDoc.refreshEvent += new Com.ICIS.Icu.Designer.BaseDoc.EventRefreshEventHandler(baseDoc_refreshEvent);
            splitContainerControl1.Panel2.Controls.Add(this.baseDoc);
            this.AutoCalculate.Init(this.baseDoc);
        }

        private string _rec = "";

        private void baseDoc_refreshEvent(DateTime recTime)
        {
            DataRow drFocused = gridView1.GetFocusedDataRow();
            RefreshData();
        }

        protected override void LoadData()
        {
            RefreshData();
        }

        private void RefreshData()
        {
            baseDoc.PatientRow = PatientRow;
            baseDoc.ReLoad();
            gridControl1.DataSource = baseDoc.DataSource["MED_ICU_DOCTOR_MANUAL_DATA_ALL"];
            this.AutoCalculate.RefreshValue();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow drFocused = gridView1.GetFocusedDataRow();
            if (drFocused != null)
            {
                //if (drFocused["RECORDING_TIME"].ToString() != baseDoc.RecTime.ToString())
                //{
                //    baseDoc.RecTime = DateTime.Parse(drFocused["RECORDING_TIME"].ToString());
                //    baseDoc.RefreshData();
                //}

            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            DataRow drFocused = gridView1.GetFocusedDataRow();
            if (drFocused != null)
            {
                if (Sundries.MessageBox("确定要删除该条评估吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, 0) == DialogResult.Yes)
                {
                    //if (DataOperator.DeleteScoreAndAssessmentResult(PatientRow.PATIENT_ID, PatientRow.VISIT_ID, PatientRow.DEP_ID, drFocused["MANUAL_NAME"].ToString(), DateTime.Parse(drFocused["RECORDING_TIME"].ToString())) > 0)
                    //{
                    //    RefreshData();
                    //}
                }
            }
        }

        #region 自动计算相关
        private AutoCal cal = new AutoCal();
        protected AutoCal AutoCalculate
        {
            get
            {
                return cal;
            }
        }
        public class CellValueChangeArgs
        {
            private decimal _OldValue = 0;
            private decimal _NewValue = 0;
            public decimal OldValue
            {
                get
                {
                    return _OldValue;
                }
            }
            public decimal NewValue
            {
                get
                {
                    return _NewValue;
                }
            }
            public CellValueChangeArgs(decimal oldValue, decimal newValue)
            {
                this._OldValue = oldValue;
                this._NewValue = newValue;
            }
        }
        public class AutoCalCell
        {
            public delegate void ValueChanged(AutoCalCell sender, CellValueChangeArgs e);
            public event ValueChanged OnValueChanged;
            private const char TagSplitToken = ';';
            private string Tag = "";
            private decimal _Value = 0;
            private string currentCell = "";
            private TextBox _CurrentText;
            public bool Readonly
            {
                get
                {
                    return this._CurrentText.ReadOnly;
                }
                set
                {
                    this._CurrentText.ReadOnly = value;
                }
            }
            public decimal Value
            {
                get
                {
                    return _Value;
                }
                set
                {
                    this._Value = value;
                    if (this._Value != 0)
                    {
                        this._CurrentText.Text = this._Value.ToString();
                    }
                }
            }
            public string CurrentCell
            {
                get
                {

                    return currentCell;
                }
                set
                {
                    currentCell = value;
                }
            }
            public TextBox CurrentText
            {
                get
                {
                    return _CurrentText;
                }
            }
            private List<string> sumCells = new List<string>();
            public List<string> SumCells
            {
                get
                {
                    return sumCells;
                }
            }
            public bool HasSumCell
            {
                get
                {
                    return sumCells.Count > 0;
                }
            }
            private Dictionary<string, decimal> sumDic = new Dictionary<string, decimal>();


            public AutoCalCell(TextBox text)
            {
                this._CurrentText = text;
                this.Tag = text.Tag.ToString();
                this._Value = ToDecimal(text.Text);
                text.KeyUp += new KeyEventHandler(text_KeyUp);
                Init();
            }

            void text_KeyUp(object sender, KeyEventArgs e)
            {
                try
                {
                    TextBox txt = sender as TextBox;
                    if (txt != null)
                    {
                        decimal value = ToDecimal(txt.Text);
                        if (this.Value != value)
                        {

                            if (OnValueChanged != null)
                            {
                                OnValueChanged(this, new CellValueChangeArgs(this._Value, value));
                            }
                            this._Value = value;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Write("自动计算保存" + ex.ToString());
                }
            }
            private void Init()
            {
                string[] tagAttr = this.Tag.Split(TagSplitToken);
                if (tagAttr.Length > 0)
                {
                    currentCell = tagAttr[0];
                }

                if (tagAttr.Length > 1)
                {
                    for (int i = 1; i < tagAttr.Length; i++)
                    {
                        sumCells.Add(tagAttr[i]);
                    }
                }
            }

            public void SetValue(decimal value)
            {
                this._Value = value;
                this._CurrentText.Text = this._Value.ToString();
            }


            protected decimal ToDecimal(object value)
            {
                decimal outValue = 0;
                decimal.TryParse(value.ToString(), out outValue);
                return outValue;
            }
        }

        public class AutoCal
        {
            Dictionary<string, AutoCalCell> _Cells = new Dictionary<string, AutoCalCell>();

            public AutoCal()
            {

            }

            public void Init(BaseDoc _ParentPanel)
            {
                List<TextBox> list = _ParentPanel.ReportViewer.GetControls<TextBox>();
                foreach (TextBox text in list)
                {
                    if (text.Tag != null && text is TextBox)
                    {
                        AutoCalCell cell = new AutoCalCell(text as TextBox);

                        cell.OnValueChanged += new AutoCalCell.ValueChanged(SetValue);
                        if (!_Cells.ContainsKey(cell.CurrentCell))
                        {
                            _Cells.Add(cell.CurrentCell, cell);
                        }
                    }
                }
                //foreach (Control ctl in _ParentPanel.Controls)
                //{
                //    if (ctl.Tag != null && ctl.Tag.ToString().ToLower() == "true")
                //    {
                //    }

                //    if (ctl is Panel)
                //    {
                //        Init(ctl as Panel);
                //    }
                //    else
                //    {
                //        if (ctl.Tag != null && ctl is TextBox)
                //        {
                //            AutoCalCell cell = new AutoCalCell(ctl as TextBox);

                //            cell.OnValueChanged += new AutoCalCell.ValueChanged(SetValue);
                //            _Cells.Add(cell.CurrentCell, cell);
                //        }
                //    }
                //}
            }
            public void RefreshValue()
            {
                foreach (KeyValuePair<string, AutoCalCell> kvp in _Cells)
                {
                    AutoCalCell cell = kvp.Value;
                    if (cell != null && cell.CurrentText != null)
                    {
                        cell.Value = ToDecimal(cell.CurrentText.Text);
                    }
                }
            }
            private void SetValue(AutoCalCell sender, CellValueChangeArgs e)
            {
                foreach (string cellTag in sender.SumCells)
                {
                    AutoCalCell cell = GetCell(cellTag);
                    if (cell == null)
                    {
                        continue;
                    }
                    decimal oldValue = cell.Value;
                    cell.Value += (e.NewValue - e.OldValue);
                    if (cell.HasSumCell)
                    {
                        SetValue(cell, new CellValueChangeArgs(oldValue, cell.Value));
                    }
                }
            }

            private AutoCalCell GetCell(string currentCellTag)
            {
                if (_Cells.ContainsKey(currentCellTag))
                {
                    return this._Cells[currentCellTag];
                }
                return null;
            }

            public void Clear()
            {
                foreach (KeyValuePair<string, AutoCalCell> kvp in this._Cells)
                {
                    kvp.Value.Value = 0;
                }
            }
            protected decimal ToDecimal(object value)
            {
                decimal outValue = 0;
                decimal.TryParse(value.ToString(), out outValue);
                return outValue;
            }

        }
        #endregion
    }
}
