/*----------------------------------------------------------------
      // Copyright (C) 2010 北京拓扑工厂科技发展有限公司
      // 文件名：FloatFrm.cs
      // 文件功能描述：麻醉事件飘窗界面
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Wis.Anes.Framework.Utilities;
using Wis.Anes.Framework;
using Wis.Anes.ServiceProxies;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework.Controls.Base;
using Wis.Anes.Framework.Permissions;

namespace Wis.Anes.Views
{
    public partial class FloatFrm : DevExpress.XtraEditors.XtraForm
    {
        private AnesthesiaEventsEditor _anesthesiaEventsEditor = null;
        private Dictionary<string, string> anesClassTypes = null;
        public static bool isFloat;
        public static Point floatLocation;
        private int pages = 0;
        private int page = 0;
        private DataSet dataSet;
        private DataTable eventTable = null;
        /// <summary>
        /// 要传送的麻醉事件信息泛型集合
        /// </summary>
        private List<EventInfo> items = new List<EventInfo>();
        private List<SimpleButton> _pageIndexButtons = new List<SimpleButton>();
        private EventInfo eventInfo = null;
        private int eventNo = 0;
        private static readonly object addEvent = new object();
        public event EventHandler AddEvent
        {
            add
            {
                Events.AddHandler(addEvent, value);
            }
            remove
            {
                Events.RemoveHandler(addEvent, value);
            }
        }

        #region 方法

        /// <summary>
        /// 构造方法
        /// </summary>
        public FloatFrm()
        {
            dataSet = new DataSet();
            SetAnesClassTypes();
            InitializeComponent();
        }

        private void SetEvent()
        {
            EventHandler eventHandle = Events[addEvent] as EventHandler;
            if (eventHandle != null)
            {
                eventHandle(eventTable, null);
            }
        }

        /// <summary>
        /// 初始化Key对应相应的值
        /// </summary>
        private void SetAnesClassTypes()
        {
            anesClassTypes = new Dictionary<string, string>();
            anesClassTypes.Add("事件", "1");
            anesClassTypes.Add("麻药", "2");
            anesClassTypes.Add("输液", "3");
            //anesClassTypes.Add("出液", "D");//出量
            //by dhc 20200324 匹配字典
            anesClassTypes.Add("出量", "D");//出量
            anesClassTypes.Add("输氧", "4");
            anesClassTypes.Add("手术", "5");
            anesClassTypes.Add("麻醉", "6");
            anesClassTypes.Add("插管", "7");
            anesClassTypes.Add("拔管", "8");
            anesClassTypes.Add("辅助呼吸", "9");
            anesClassTypes.Add("控制呼吸", "A");
            anesClassTypes.Add("输血", "B");
            anesClassTypes.Add("用药", "C");
            anesClassTypes.Add("混合液", "X");
            anesClassTypes.Add("呼吸", "Y");
            anesClassTypes.Add("附记项目", "O");//ECG
            anesClassTypes.Add("镇痛泵", "W");
            anesClassTypes.Add("其他", "Z");
            anesClassTypes.Add("置管", "~");
        }

        private int _pageLines = 9;
        private int _rowButtons = 2;
        private bool _isEvent = false;
        private int _buttonWidth = 130;
        private int _pageButtonWidth = 30;
        private List<int> _dictIndexList = new List<int>();

        private void ReSetDictIndexList()
        {
            _dictIndexList.Clear();
            for (int i = 0; i < dataSet.Tables[Text].Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(txtPinYing.Text))
                {
                    _dictIndexList.Add(i);
                }
                else
                {
                    string itemName = "";
                    if (dataSet.Tables[Text].Rows[i]["ITEM_NAME"] != System.DBNull.Value)
                    {
                        itemName = dataSet.Tables[Text].Rows[i]["ITEM_NAME"].ToString();
                        if (!string.IsNullOrEmpty(itemName))
                        {
                            itemName = StringManage.GetPYString(itemName);
                        }
                    }
                    if (itemName.ToLower().Contains(txtPinYing.Text.ToLower()))
                    {
                        _dictIndexList.Add(i);
                    }
                }
            }
        }

        /// <summary>
        /// 获取常用量按钮
        /// </summary>
        /// <param name="pageIndex">当前页索引</param>
        private void AddDosageButton(int pageIndex)
        {
            textEdit1.Visible = false;
            ClearButton();
            if (pages == 0) return;
            int t = 45;
            int count = 0;
            int left = 25;
            _dosageButtons.Clear();

            int roundIndex = 0;
            int startIndex = pageIndex * _pageLines;
            if (_isEvent)
            {
                startIndex = pageIndex * _pageLines * _rowButtons;
            }
            SimpleButton simpleButton = null;
            for (int i = startIndex; i < _dictIndexList.Count; i++)
            {
                if (!_isEvent)
                {
                    int l = 15;
                    simpleButton = CreateButton(dataSet.Tables[Text].Rows[_dictIndexList[i]]["ITEM_NAME"].ToString());
                    if (!_dosageButtons.Contains(simpleButton))
                    {
                        _dosageButtons.Add(simpleButton);
                    }
                    simpleButton.Location = new Point(l, t);
                    simpleButton.Width = _buttonWidth;
                    simpleButton.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                    simpleButton.Tag = i;
                    simpleButton.Click += new EventHandler(btnDosage_Click);
                    l = l + simpleButton.Width + 5;
                    bool check = false;
                    double selectedDosage = SelectedDosage(dataSet.Tables[Text].Rows[_dictIndexList[i]]["ITEM_NO"].ToString(), dataSet.Tables[Text].Rows[_dictIndexList[i]]["ITEM_CLASS"].ToString());
                    int buttons = ApplicationConfiguration.DosageButtonsCount;
                    for (int j = 1; j <= buttons; j++)
                    {
                        if (dataSet.Tables[Text].Rows[_dictIndexList[i]]["STANDARD_DOSAGE_" + j.ToString()] != DBNull.Value && !dataSet.Tables[Text].Rows[_dictIndexList[i]]["STANDARD_DOSAGE_" + j.ToString()].Equals(string.Empty))
                        {
                            simpleButton = CreateButton(Round(double.Parse(dataSet.Tables[Text].Rows[_dictIndexList[i]]["STANDARD_DOSAGE_" + j.ToString()].ToString()), 2).ToString());
                            if (!_dosageButtons.Contains(simpleButton))
                            {
                                _dosageButtons.Add(simpleButton);
                            }
                            simpleButton.Tag = i;
                            simpleButton.Click += new EventHandler(btnDosage_Click);
                            simpleButton.Location = new Point(l, t);
                            l = l + simpleButton.Width + 5;
                            if (selectedDosage != 999999)
                            {
                                if (selectedDosage.Equals(double.Parse(simpleButton.Text)))
                                {
                                    simpleButton.ForeColor = Color.Chocolate;
                                    check = true;
                                }
                            }
                        }
                    }
                    if (selectedDosage != 999999 && !check)
                    {
                        if (selectedDosage == 0)
                        {
                            simpleButton = CreateButton("+");
                        }
                        else
                        {
                            simpleButton = CreateButton(Round(selectedDosage, 2).ToString());
                        }
                        simpleButton.ForeColor = Color.Chocolate;
                    }
                    else
                    {
                        simpleButton = CreateButton("?");
                    }
                    simpleButton.Tag = i;
                    simpleButton.Click += new EventHandler(btn_Click);
                    simpleButton.Location = new Point(l, t);

                    t = t + simpleButton.Height + 8;
                    if (!_dosageButtons.Contains(simpleButton))
                    {
                        _dosageButtons.Add(simpleButton);
                    }
                    count = count + 1;
                    if (count >= _pageLines)
                    {
                        return;
                    }
                }
                else
                {
                    simpleButton = CreateButton(dataSet.Tables[Text].Rows[_dictIndexList[i]]["ITEM_NAME"].ToString());
                    if (!_dosageButtons.Contains(simpleButton))
                    {
                        _dosageButtons.Add(simpleButton);
                    }
                    simpleButton.Location = new Point(left, t);
                    simpleButton.Width = _buttonWidth;
                    simpleButton.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                    simpleButton.Click += new EventHandler(btnDosage_Click);
                    left = left + simpleButton.Width + 25;
                    simpleButton.Tag = i;
                    if (!_dosageButtons.Contains(simpleButton))
                    {
                        _dosageButtons.Add(simpleButton);
                    }
                    count = count + 1;
                    if (count >= _pageLines * _rowButtons)
                    {
                        return;
                    }
                    roundIndex++;
                    if (roundIndex == _rowButtons)
                    {
                        roundIndex = 0;
                        t = t + simpleButton.Height + 8;
                        left = 25;
                    }
                }
            }
            foreach (Control control in Controls)
            {
                if (control is SimpleButton && control.Text.Equals("?"))
                {
                    control.Visible = false;
                }
            }
        }

        private List<SimpleButton> _dosageButtons = new List<SimpleButton>();

        private void ResetButtons(int pageIndex)
        {
            ReSetDictIndexList();
            AddDosageButton(pageIndex);
            AddPageButton();
            foreach (Control control in Controls)
            {
                if (control is SimpleButton && !control.Text.Equals("?"))
                {
                    control.Visible = true;
                }
            }
        }

        private void CalcPage()
        {
            int rowsCount = _dictIndexList.Count;
            int bn = _pageLines;
            if (_isEvent)
            {
                bn = bn * _rowButtons;
            }

            pages = rowsCount % bn == 0 ? rowsCount / bn : rowsCount / bn + 1;
        }

        /// <summary>
        /// 获取页码按钮
        /// </summary>
        private void AddPageButton()
        {
            if (pages < 2) return;
            int t = 400;
            int l = ButtonAreaWidth - (_pageButtonWidth + 4) * pages;
            foreach (SimpleButton button in _pageIndexButtons)
            {
                if (Controls.Contains(button))
                {
                    Controls.Remove(button);
                }
            }
            _pageIndexButtons.Clear();
            for (int i = 1; i <= pages; i++)
            {
                SimpleButton simpleButton = CreateButton(i.ToString());
                simpleButton.Size = new Size(_pageButtonWidth, _pageButtonWidth);
                simpleButton.Location = new Point(l + (simpleButton.Width + 4) * (i - 1), t);
                simpleButton.Click += new EventHandler(btnPage_Click);
                t = i / 15 * (simpleButton.Height + 4) + t;
                _pageIndexButtons.Add(simpleButton);
            }
        }

        /// <summary>
        /// 产生按钮方法
        /// </summary>
        /// <param name="text">按钮显示文本</param>
        private SimpleButton CreateButton(string text)
        {
            SimpleButton simpleButton = new SimpleButton();
            simpleButton.Visible = false;
            simpleButton.ForeColor = Color.Black;
            simpleButton.Cursor = System.Windows.Forms.Cursors.Hand;
            simpleButton.Size = new Size(40, 30);
            simpleButton.Text = text;
            simpleButton.ToolTip = text;
            this.Controls.Add(simpleButton);
            simpleButton.BringToFront();
            return simpleButton;
        }

        /// <summary>
        /// 清除窗体动态生产的按钮
        /// </summary>
        /// <param name="isCleanAll">是否全部清除，false则保留页码按钮</param>
        private void ClearButton()
        {
            foreach (Control ct in _dosageButtons)
            {
                this.Controls.Remove(ct);
            }
        }

        /// <summary>
        /// 返回当前事件已选择的常用量
        /// </summary>
        /// <param name="itemno">事件itemno</param>
        /// <param name="itemclass">事件itemclass</param>
        /// <returns>返回选择常用量，若当前行未选择返回0</returns>
        private double SelectedDosage(string itemno, string itemclass)
        {
            if (items.Count > 0)
            {
                foreach (EventInfo item in items)
                {
                    if (item.ItemNo.Equals(itemno) && item.ItemClass.Equals(itemclass))
                    {
                        return item.Dosage;
                    }
                }
            }
            return 999999;
        }

        /// <summary>
        /// 对小数四舍五入
        /// </summary>
        /// <param name="d">要处理的小数</param>
        /// <param name="i">要保留的小数位数</param>
        /// <returns>返回处理后值</returns>
        private double Round(double d, int i)
        {
            if (d >= 0)
            {
                d += 5 * Math.Pow(10, -(i + 1));
            }
            else
            {
                d += -5 * Math.Pow(10, -(i + 1));
            }
            string str = d.ToString();
            string[] strs = str.Split('.');
            int idot = str.IndexOf('.');
            string prestr = strs[0];
            string poststr = strs[1];
            if (poststr.Length > i)
            {
                poststr = str.Substring(idot + 1, i);
            }
            string strd = prestr + "." + poststr;
            d = Double.Parse(strd);
            return d;
        }

        private void ItemAdd(SimpleButton simpleButton)
        {
            eventInfo = new EventInfo();
            DataRow row = dataSet.Tables[Text].Rows[_dictIndexList[(int)(simpleButton.Tag)]];
            eventInfo.ItemNo = row["ITEM_NO"].ToString();
            eventInfo.ItemClass = row["ITEM_CLASS"].ToString();
            eventInfo.ItemName = row["ITEM_NAME"].ToString();
            eventInfo.ItemCode = row["ITEM_CODE"] == DBNull.Value ? null : row["ITEM_CODE"].ToString();
            eventInfo.ItemSpec = row["ITEM_SPEC"] == DBNull.Value ? null : row["ITEM_SPEC"].ToString();
            if (!_isEvent)
            {
                double dosage = 0;
                if (!double.TryParse(simpleButton.Text, out dosage))
                {
                    dosage = 0;
                }
                eventInfo.Dosage = dosage;
                eventInfo.DosageUnits = row["DOSAGE_UNITS"] == DBNull.Value ? null : row["DOSAGE_UNITS"].ToString();
                eventInfo.Administrator = row["ADMINISTRATOR"] == DBNull.Value ? null : row["ADMINISTRATOR"].ToString();
                if (row["PERFORM_SPEED"] != DBNull.Value)
                {
                    eventInfo.PerformSpeed = double.Parse(row["PERFORM_SPEED"].ToString());
                }
                eventInfo.SpeedUnit = row["SPEED_UNITS"] == DBNull.Value ? null : row["SPEED_UNITS"].ToString();
                if (row["CONCENTRATION"] != DBNull.Value)
                {
                    eventInfo.Concentration = double.Parse(row["CONCENTRATION"].ToString());
                }
                eventInfo.ConcentrationUnit = row["CONCENTRATION_UNITS"] == DBNull.Value ? null : row["CONCENTRATION_UNITS"].ToString();
                
            }
            if (row["DURATIVE_INDICATOR"] != DBNull.Value)
            {
                eventInfo.DuractiveIndicator = double.Parse(row["DURATIVE_INDICATOR"].ToString());
            }
            eventInfo.StartTime = timeEvent.Value;
            items.Add(eventInfo);
        }

        private void ItemRemove(SimpleButton simpleButton)
        {
            foreach (EventInfo item in items)
            {
                if (item.ItemNo.Equals(dataSet.Tables[Text].Rows[_dictIndexList[(int)(simpleButton.Tag)]]["ITEM_NO"].ToString()) &&
                    item.ItemClass.Equals(dataSet.Tables[Text].Rows[_dictIndexList[(int)(simpleButton.Tag)]]["ITEM_CLASS"].ToString()))
                {
                    items.Remove(item);
                    break;
                }
            }
        }

        private void TextVisible()
        {
            textEdit1.Visible = false;
            //simpleButton.Focus();
        }

        #endregion

        #region 事件
        private int ButtonAreaWidth = 330;
        private void FloatFrm_Load(object sender, EventArgs e)
        {
            if (!Framework.AccessControl.CheckModifyRight(PermissionContext.ANESRECORDOPER))
            {
                if (_anesthesiaEventsEditor != null)
                {
                    _anesthesiaEventsEditor.SetReadOnly(true);
                }
            }
            btnOK.Top = 2000;
            btnCancel.Top = 2000;
            btnOK.Enabled = false;
            btnCancel.Enabled = false;
            Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            if (ExtendApplicationContext.Current.SystemStatus == ProgramStatus.PACURecord)
            {
                eventNo = 1;
            }
            else if (ExtendApplicationContext.Current.SystemStatus == ProgramStatus.CPBReport)
            {
                eventNo = 2;
            }
            else if (ApplicationConfiguration.IsYouDaoProgram)
            {
                eventNo = 3;
            }
            //Width = _buttonWidth * _rowButtons + 24 * 2 + 20; //24 + _buttonWidth + 5 + Configurations.DosageButtonsCount * (40 + 5) + 40 + 40 + 24;
            //floatFormControl1.Width = ButtonAreaWidth;
            //floatFormControl1.Left = 5;
            //floatFormControl1.Top = -30;
            //floatFormControl1.Height += 300;
            //floatFormControl1.Dock = DockStyle.Fill;
            this.Location = floatLocation;
            //timeEvent.Location = new Point(floatFormControl1.Right - timeEvent.Width - 10, floatFormControl1.Top + floatFormControl1.TopHeight + 4);
            eventTable = AnesthesiaSheetProxy.GetAnesthesiaEvent(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID, eventNo);
            InitEventList();
            //Deactivate += new EventHandler(FloatFrm_Deactivate);
        }

        void FloatFrm_Deactivate(object sender, EventArgs e)
        {
            //Close();
        }

        private void InitEventList()
        {
            if (_anesthesiaEventsEditor == null)
            {
                _anesthesiaEventsEditor = new AnesthesiaEventsEditor(ExtendApplicationContext.Current.PatientInformation, eventNo);
                Controls.Add(_anesthesiaEventsEditor);
                _anesthesiaEventsEditor.Left = ButtonAreaWidth + 8;
                _anesthesiaEventsEditor.Width = Width - _anesthesiaEventsEditor.Left - 10;
                _anesthesiaEventsEditor.Top = 0;
                _anesthesiaEventsEditor.Height = 438;
                _anesthesiaEventsEditor.SaveHandle += new EventHandler(_anesthesiaEventsEditor_SaveHandle);
            }
            if (!string.IsNullOrEmpty(Text))
            {
                Text = Text.Trim();
                _anesthesiaEventsEditor.SetType(Text);
            }
            else
            {
                _anesthesiaEventsEditor.SetType("全部");
            }
        }

        void _anesthesiaEventsEditor_SaveHandle(object sender, EventArgs e)
        {
            SetEvent();
        }

        private void FloatFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            isFloat = false;
        }

        private void FloatFrm_TextChanged(object sender, EventArgs e)
        {
            this.Location = floatLocation;
            ClearButton();
            if (anesClassTypes.ContainsKey(Text) || EventTypeHelper.CPBEventType.ContainsKey(Text))
            {
                if (ExtendApplicationContext.Current.SystemStatus == ProgramStatus.CPBReport)
                {
                    _isEvent = Text.Equals("事件");
                }
                else
                {
                    _isEvent = ("234BCX".IndexOf(anesClassTypes[Text]) < 0);
                }

                //anesClassTypes.Add("事件", "1");
                //anesClassTypes.Add("麻药", "2");
                //anesClassTypes.Add("输液", "3");
                //anesClassTypes.Add("出量", "D");
                //anesClassTypes.Add("输氧", "4");
                //anesClassTypes.Add("手术", "5");
                //anesClassTypes.Add("麻醉", "6");
                //anesClassTypes.Add("插管", "7");
                //anesClassTypes.Add("拔管", "8");
                //anesClassTypes.Add("辅助呼吸", "9");
                //anesClassTypes.Add("控制呼吸", "A");
                //anesClassTypes.Add("输血", "B");
                //anesClassTypes.Add("用药", "C");
                //anesClassTypes.Add("混合液", "X");
                //anesClassTypes.Add("呼吸", "Y");
                //anesClassTypes.Add("附记项目", "O");//ECG
                //anesClassTypes.Add("镇痛泵", "W");
                //anesClassTypes.Add("其他", "Z");
                //anesClassTypes.Add("置管", "~");

                timeEvent.Value = DateTime.Now;

                if (!dataSet.Tables.Contains(Text))
                {
                    string itemClass = "";
                    DataTable dataTable = null;
                    if (ExtendApplicationContext.Current.SystemStatus == ProgramStatus.CPBReport)
                    {
                        itemClass = EventTypeHelper.CPBEventType[Text];
                        dataTable = CPBProxy.GetCPBEventOpen(itemClass);
                    }
                    else
                    {
                        if (Text.Equals("呼吸"))
                        {
                            dataTable = DictProxy.GetAnesthesiaEventOpenByhuxi();
                            for (int i = 0; i < dataTable.Rows.Count ; i++)
                            {
                                if (dataTable.Rows[i]["ITEM_NAME"].ToString() == "辅助呼吸")
                                {
                                    dataTable.Rows[i]["ITEM_CLASS"] = "9";
                                }
                                else if (dataTable.Rows[i]["ITEM_NAME"].ToString() == "控制呼吸")
                                {
                                    dataTable.Rows[i]["ITEM_CLASS"] = "A";
                                }
                                else if (dataTable.Rows[i]["ITEM_NAME"].ToString() == "自主呼吸")
                                {
                                    dataTable.Rows[i]["ITEM_CLASS"] = "Y";
                                }
                            }
                        }
                        else
                        {
                            itemClass = anesClassTypes[Text];
                            dataTable = DictProxy.GetAnesthesiaEventOpen(itemClass);
                        }
                    }
                    //if (Globals.SystemStatus == Globals.ProgramStatus.CPBReport)
                    //{
                    //    string sqlStr = "SELECT * FROM WIS_DICT_CPB_EVENT WHERE ITEM_CLASS=@ITEMCLASS ORDER BY ITEM_NO ";
                    //    adapter.SetSQL(sqlStr, new object[] {  });
                    //else
                    //{
                    //    string sqlStr = "SELECT * FROM WIS_ANES_EVENT_OPEN WHERE ITEM_CLASS=@ITEMCLASS ORDER BY ITEM_NO ";
                    //    adapter.SetSQL(sqlStr, new object[] { anesClassTypes[Text] });
                    //}
                    //adapter.Fill(dataTable);
                    dataSet.Tables.Add(dataTable);
                    dataTable.TableName = Text;
                }
                ReSetDictIndexList();
                CalcPage();
                AddDosageButton(0);
                AddPageButton();
                foreach (Control control in Controls)
                {
                    if (control is SimpleButton && !control.Text.Equals("?"))
                    {
                        control.Visible = true;
                    }
                }
            }
            if (_anesthesiaEventsEditor != null)
            {
                if (!string.IsNullOrEmpty(Text))
                {
                    _anesthesiaEventsEditor.SetType(Text);
                }
                else
                {
                    _anesthesiaEventsEditor.SetType("全部");
                }
            }
        }

        private void btnPage_Click(object sender, EventArgs e)
        {
            timeEvent.Value = DateTime.Now;
            ReSetDictIndexList();
            page = int.Parse((sender as SimpleButton).Text);
            AddDosageButton(page - 1);
            AddPageButton();
            foreach (Control control in Controls)
            {
                if (control is SimpleButton && !control.Text.Equals("?"))
                {
                    control.Visible = true;
                }
            }
        }

        private void btnDosage_Click(object sender, EventArgs e)
        {
            SimpleButton simpleButton = sender as SimpleButton;
            if (!simpleButton.Text.Equals("?"))
            {
                ItemAdd(simpleButton);
                btnOK_Click(null, null);
            }
        }

        private void textEdit1_Leave(object sender, EventArgs e)
        {
            textEdit1.Visible = false;
        }

        private void FloatFrm_Resize(object sender, EventArgs e)
        {
            if (_anesthesiaEventsEditor != null && Width > 0)
            {
                _anesthesiaEventsEditor.Width = Width - _anesthesiaEventsEditor.Left - 10;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (items.Count > 0)
                {
                    foreach (EventInfo info in items)
                    {
                        AnesInformations.AnesthesiaEventRow row =_anesthesiaEventsEditor.AddRow(info.ItemClass, info.ItemName, info.ItemSpec, info.ItemCode, info.Administrator,(decimal) info.Concentration
                            , info.ConcentrationUnit, (decimal)info.Dosage, info.DosageUnits, (decimal)info.PerformSpeed, info.SpeedUnit, ExtendApplicationContext.Current.LoginUserContext.HisUserID, "");
                        if (row != null)
                        {
                            row.START_DATE_TIME = timeEvent.Value;
                            row.DURATIVE_INDICATOR = (decimal)info.DuractiveIndicator;
                        }
                    }
                    items.Clear();
                }
            }
            catch(Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            SimpleButton simpleButton = sender as SimpleButton;
            if (!simpleButton.Text.Equals("?"))
            {
                ItemAdd(simpleButton);
                btnOK_Click(null, null);
            }
        }

        #endregion

        private void txtPinYing_EditValueChanged(object sender, EventArgs e)
        {
            ReSetDictIndexList();
            CalcPage();
            AddDosageButton(0);
            AddPageButton();
            foreach (Control control in Controls)
            {
                if (control is SimpleButton && !control.Text.Equals("?"))
                {
                    control.Visible = true;
                }
            }
        }

        private bool CheckSave()
        {
            if (_anesthesiaEventsEditor != null && _anesthesiaEventsEditor.IsDirty)
            {
                DialogResult result = Dialog.MessageBox("输入未保存，现在保存吗?", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                Application.DoEvents();
                if (result == DialogResult.No)
                {
                    return true;
                }
                else if (result == DialogResult.Cancel)
                {
                    return false;
                }
                else
                {
                    return _anesthesiaEventsEditor.Save();
                }
            }
            return true;
        }

        private void FloatFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CheckSave())
            {
                e.Cancel = true;
                return;
            }
            if (_anesthesiaEventsEditor != null && _anesthesiaEventsEditor.IsDataSaved)
            {
                //Control control = Globals.CurrentControl;
                //if (control != null && control is AnesthesiaRecordDocument)
                //{
                //    ((AnesthesiaRecordDocument)control).RefreshAllData();
                //}
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = panel1.ClientRectangle;
            rect.Width -= 1;
            rect.Height -= 1;
            e.Graphics.DrawRectangle(Pens.Silver, rect);
        }

    }

    /// <summary>
    /// 麻醉事件信息类
    /// </summary>
    [Serializable]
    public class EventInfo
    {
        private string itemNo;

        public string ItemNo
        {
            get { return itemNo; }
            set { itemNo = value; }
        }

        private string itemClass;

        public string ItemClass
        {
            get { return itemClass; }
            set { itemClass = value; }
        }

        private string itemName;

        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }

        private string itemCode;

        public string ItemCode
        {
            get { return itemCode; }
            set { itemCode = value; }
        }

        private string itemSpec;

        public string ItemSpec
        {
            get { return itemSpec; }
            set { itemSpec = value; }
        }

        private double dosage;

        public double Dosage
        {
            get { return dosage; }
            set { dosage = value; }
        }

        private string dosageUnits;

        public string DosageUnits
        {
            get { return dosageUnits; }
            set { dosageUnits = value; }
        }

        private DateTime startTime;

        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        private string administrator;

        public string Administrator
        {
            get { return administrator; }
            set { administrator = value; }
        }

        private double performSpeed;

        public double PerformSpeed
        {
            get { return performSpeed; }
            set { performSpeed = value; }
        }

        private string speedUnit;

        public string SpeedUnit
        {
            get { return speedUnit; }
            set { speedUnit = value; }
        }

        private double concentration;

        public double Concentration
        {
            get { return concentration; }
            set { concentration = value; }
        }

        private string concentrationUnit;

        public string ConcentrationUnit
        {
            get { return concentrationUnit; }
            set { concentrationUnit = value; }
        }

        private double duractiveIndicator;

        public double DuractiveIndicator
        {
            get { return duractiveIndicator; }
            set { duractiveIndicator = value; }
        }
    }
}
