using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.Framework;

namespace Wis.Anes.Layouts
{
    [Serializable()]
    [ToolboxItem(false)]
    public partial class MecicalDocBarControl : XtraUserControl
    {
        public MecicalDocBarControl()
        {
            InitializeComponent();
        }

        int _DocButtonStartLeft = 160;
        string _PatientDocButtons = "";
        int _RefreshTimeSpan = 120;
        public delegate void RefreshTimeSpanRequest(object sender, EventArgs e);
        public event RefreshTimeSpanRequest OnRefreshTimeSpanRequest;

        public string PatientDocButtons
        {
            get { return _PatientDocButtons; }
            set { _PatientDocButtons = value; }
        }
        /// <summary>
        /// 文书刷新时间间隔（秒）
        /// </summary>
        public int RefreshTimeSpan
        {
            get { return _RefreshTimeSpan; }
            set { _RefreshTimeSpan = value; }
        }

        /// <summary>
        /// 文书第一个按钮开始的左边位置
        /// </summary>
        public int DocButtonStartLeft
        {
            get { return _DocButtonStartLeft; }
            set { _DocButtonStartLeft = value; }
        }


        /// <summary>
        /// 设置背景图片
        /// </summary>
        /// <param name="picLogoImage"></param>
        /// <param name="picBackGroundImage"></param>
        /// <param name="picLbSelect"></param>
        /// <param name="picTopSpliter"></param>
        /// <param name="picPatientInfoLine"></param>
        public void SetBackGroundImage(Image picPanelClockImage, Image picBackGroundImage)
        {
            this.BackgroundImage = picBackGroundImage;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            panelClock.BackgroundImage = picPanelClockImage;
        }
        public void SetClockColor(Color forColor)
        {
            lb_Clock.ForeColor = forColor;
        }


        //文书选择下拉框
        public void SetDocSelectedType(List<string> docTypeList)
        {
            comboxDocType.Items.Clear();

            if (docTypeList.Count >= 1)
            {
                comboxDocType.Items.Add("全部");
            }


            for (int i = 0; i < docTypeList.Count; i++)
            {
                comboxDocType.Items.Add(docTypeList[i]);
                comboxDocType.Items.Add(docTypeList[i] + "(所有)");
            }

            if (comboxDocType.Items.Count == 0)
            {
                comboxDocType.Visible = false;
            }
            else
            {

                comboxDocType.Visible = true;
            }


        }

        //初始化时指定过滤类型
        private string defaultDocSelectedType = null;
        public void SetDefaultDocSelectedType(string defaultDocSelectedType)
        {
            this.defaultDocSelectedType = defaultDocSelectedType;
        }

        private void MecicalDocBarControl_Load(object sender, EventArgs e)
        {

            //计算时间项的位置

            lb_Clock.Top = (this.Height - this.lb_Clock.Height) / 2;
            lb_Clock.BackColor = Color.Transparent;
            lb_Clock.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //PatientDocButtonsList.Clear();

            comboxDocType.Visible = false;
        }

        private void timer_Clock_Tick(object sender, EventArgs e)
        {
            lb_Clock.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            ExtendApplicationContext.Current.ClockTick++;
            ExtendApplicationContext.Current.SystemRunClockTick++;

            if (RefreshTimeSpan <= 2)
            {
                RefreshTimeSpan = 120;
            }

            if (ExtendApplicationContext.Current.ClockTick % RefreshTimeSpan == 0)
            {
                ExtendApplicationContext.Current.ClockTick = 0;
                OnRefreshTimeSpanRequest(sender, e);
            }
        }

        public SimpleButton _AnesDocButtom = null;
        private int btnWidth = 125;
        /// <summary>
        /// 生成文书按钮
        /// </summary>
        public void CreateDocButtons()
        {

            ClearDocButtons();

            //this.Invalidate();
            //判断是否有分号
            string sDocButtons1 = PatientDocButtons;
            if (string.IsNullOrEmpty(sDocButtons1))
            {
                sDocButtons1 = "";
            }
            int index = sDocButtons1.IndexOf(";");
            if (index >= 0)
            {
                sDocButtons1 = PatientDocButtons.Substring(0, index);
            }
            //string sDocButtons2 = PatientDocButtons.Substring(index + 1);

            string[] buttons = sDocButtons1.Split(',');
            int btnLeft = DocButtonStartLeft;
            int btnHeight = 34;
            int btnTop = 0;// (this.Height - btnHeight) / 2;
            int btnWidth = 125;
            Image bg = Image.FromFile(ExtendApplicationContext.Current.AppPath + @"Skin\ButtonBak.png");
            Image bgSelected = Image.FromFile(ExtendApplicationContext.Current.AppPath + @"Skin\ButtonBakSelected.png");

            KeyValuePair<string, MedicalDocElement> keyValuePair = new KeyValuePair<string, MedicalDocElement>();
            List<string> docTypeList = new List<string>();
            for (int i = 0; i < buttons.Length; i++)
            {
                if (string.IsNullOrEmpty(buttons[i].Trim())) continue;
                SimpleButton button = new SimpleButton();
                //button.TextAlign = ContentAlignment.MiddleCenter;
                button.BackgroundImage = bg;
                button.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;// DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                button.BackgroundImageLayout = ImageLayout.Stretch;
                button.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
                button.Appearance.ForeColor = Color.FromArgb(64,64,64);
                button.Appearance.Options.UseFont = true;
                button.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                button.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                button.Appearance.BackColor = Color.Transparent;// DevExpress.Utils.VertAlignment.Center;
                

                keyValuePair = GetDocKeyValuePair(buttons[i]);

                if (keyValuePair.Key != null)
                {
                    button.Text = keyValuePair.Value.Caption;
                    button.Tag = buttons[i];
                    string[] typeArr = keyValuePair.Value.Caption.Split(new char[] { '@' });
                    if (typeArr.Length > 1)
                    {
                        if (!docTypeList.Contains(typeArr[1].Trim()))
                            docTypeList.Add(typeArr[1].Trim());

                        button.Text = typeArr[0].Trim();
                        button.Name = keyValuePair.Value.Caption;
                    }
                }
                else
                {
                    button.Text = buttons[i];
                    button.Tag = buttons[i];
                    button.Name = buttons[i];
                }


                //button.Name = "B" + button.Text;
                button.Height = btnHeight;
                button.Left = btnLeft;
                //button.Name = "B" + button.Text + "LEFT" + btnLeft;
                button.Top = btnTop;
                button.Width = btnWidth;
                btnLeft += btnWidth;
                button.Visible = true;

                if (button.Tag.ToString() == "麻醉单")
                    _AnesDocButtom = button;

                button.Click += delegate
                {
                    //ff15428b
                    foreach (Control b in this.flowLayoutPanel1.Controls)
                    {
                        if (b is SimpleButton && b != button)
                        {
                            (b as SimpleButton).ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;// DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                            (b as SimpleButton).BackgroundImage = bg;
                            (b as SimpleButton).Appearance.ForeColor = Color.FromArgb(64, 64, 64);


                        }
                    }
                    button.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;// DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                    button.BackgroundImage = bgSelected;
                    button.Appearance.ForeColor = Color.FromArgb(76, 111, 237);

                    //button.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;

                };
                // _PatientDocButtonsList.Add(button);
                this.flowLayoutPanel1.Controls.Add(button);
            }
            //this.Controls.AddRange(PatientDocButtonsList.ToArray());



            //设置下拉框
            SetDocSelectedType(docTypeList);
            if (comboxDocType.Visible)
            {
                if (!string.IsNullOrEmpty(defaultDocSelectedType))
                {
                    comboxDocType.Text = defaultDocSelectedType;
                }
                else
                {
                    comboxDocType.SelectedItem = comboxDocType.Items[0];
                }
            }
            //调整位置
            ResizeDocBarControl();
            docControlUpDown.Value = 1;
        }




        public KeyValuePair<string, MedicalDocElement> GetDocKeyValuePair(string docName)
        {
            Dictionary<string, MedicalDocElement> docs = MedicalDocSettings.GetMedicalDocNameAndPath();
            foreach (KeyValuePair<string, MedicalDocElement> keyValuePair in docs)
            {
                if (keyValuePair.Key.Trim() == docName.Trim())
                {
                    return keyValuePair;
                }
            }
            return new KeyValuePair<string, MedicalDocElement>();

        }

        /// <summary>
        /// 清楚文书按钮
        /// </summary>
        public void ClearDocButtons()
        {
            //foreach (Control ctl in this.Controls)
            //{
            //    if (ctl is Button)
            //        this.Controls.Remove(ctl);

            //}
            List<Control> controls = new List<Control>();
            foreach (Control c in this.flowLayoutPanel1.Controls)
            {
                if (c != panelClock && c != lb_Clock && c != docControlUpDown && c != comboxDocType)
                {
                    controls.Add(c);
                }
            }
            foreach (Control c in controls)
            {
                this.flowLayoutPanel1.Controls.Remove(c);
            }
            controls.Clear();

        }
        private void ResizeDocBarControl()
        {
            int rightWidth = 0;
            comboxDocType.Left = docControlUpDown.Left - comboxDocType.Width;
            rightWidth = (comboxDocType.Visible ? comboxDocType.Width : 0) + docControlUpDown.Width;

            List<Control> controls = new List<Control>();
            foreach (Control c in this.flowLayoutPanel1.Controls)
            {
                if (c != panelClock && c != lb_Clock && c != docControlUpDown && c != comboxDocType)
                {
                    //先不可见
                    c.Visible = false;
                    //
                    if (comboxDocType.Visible == false || string.IsNullOrEmpty(comboxDocType.Text) || comboxDocType.Text.Equals("全部"))
                    {
                        controls.Add(c);
                    }
                    else if (!string.IsNullOrEmpty(comboxDocType.Text))
                    {

                        string strTemp = "(所有)";
                        if (comboxDocType.Text.Contains(strTemp))
                        {
                            //如果按照类型过滤的话
                            if (c.Name != null && (c.Name.ToString().Contains("@" + comboxDocType.Text.Substring(0, comboxDocType.Text.Length - strTemp.Length)) || !c.Name.Contains("@")))
                            {
                                controls.Add(c);
                            }
                        }
                        else
                        {
                            //如果按照类型过滤的话
                            if (c.Name != null && c.Name.ToString().Contains("@" + comboxDocType.Text))
                            {
                                controls.Add(c);
                            }
                        }

                    }

                }
            }

            int allowWidth = this.Width - DocButtonStartLeft - docControlUpDown.Width - (comboxDocType.Visible ? comboxDocType.Width : 0) - 10;
            int allowCount = allowWidth / btnWidth;
            if (allowCount <= 0)
            {
                controls.Clear();
                return;
            }
            int pageIndex = (int)docControlUpDown.Value;
            int pageCount = controls.Count / allowCount + 1;
            docControlUpDown.Maximum = pageCount;
            if (pageIndex > pageCount)
            {
                pageIndex = pageCount;
            }
            for (int i = 0; i < allowCount; i++)
            {
                int countIndex = allowCount * (pageIndex - 1) + i;
                if (countIndex >= controls.Count || countIndex < 0)
                {
                    break;
                }
                controls[countIndex].Left = DocButtonStartLeft + i * btnWidth;
                controls[countIndex].Visible = true;
            }

            controls.Clear();

        }

        private void docControlUpDown_ValueChanged(object sender, EventArgs e)
        {


            ResizeDocBarControl();
        }

        private void MecicalDocBarControl_Resize(object sender, EventArgs e)
        {

            ResizeDocBarControl();


        }

        private void comboxDocType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResizeDocBarControl();
        }







    }



}
