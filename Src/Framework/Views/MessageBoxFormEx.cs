using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Wis.Anes.Framework.Utilities;
using Wis.Anes.Framework.Controls;
using DevExpress.XtraEditors.Mask;
using Wis.Anes.Framework.Properties;
using Wis.Anes.Framework.Controls.Base;

namespace Wis.Anes.Framework.Views
{
    /// <summary>
    /// 消息对话框窗体
    /// </summary>
    public partial class MessageBoxFormEx : MessageBoxBaseFrm
    {

        #region 构造方法

        public MessageBoxFormEx()
        {
            InitializeComponent();
        }

        #endregion 构造方法

        #region 变量

        /// <summary>
        /// 消息提示文本
        /// </summary>
        private string _text;

        /// <summary>
        /// 消息显示按钮
        /// </summary>
        private MessageBoxButtons _buttons;

        /// <summary>
        /// 消息图标
        /// </summary>
        private MessageBoxIcon _icon;

        /// <summary>
        /// 简单输入选择类型
        /// </summary>
        private string singleInputSelectType;
        private string[] singleInputSelectTypes;

        /// <summary>
        /// 简单输入选择框控件
        /// </summary>
        private Control singleInputSelectControl;
        private Control[] singleInputSelectControls;
        private MedLabel[] inputLabels;

        /// <summary>
        /// 简单输入选择框结果
        /// </summary>
        private object resultObject;
        private object[] resultObjects;

        private int _timeOut = 0;

        #endregion 变量

        #region 方法

        /// <summary>
        /// 显示消息提示框
        /// </summary>
        /// <param name="text">提示内容</param>
        /// <param name="caption">框标题</param>
        /// <param name="buttons">可见按钮</param>
        /// <param name="icon">提示图标</param>
        /// <returns>用户点击结果</returns>
        public DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return Show(text, caption, buttons, icon, 0);
        }

        /// <summary>
        /// 显示消息提示框
        /// </summary>
        /// <param name="text">提示内容</param>
        /// <param name="caption">框标题</param>
        /// <param name="buttons">可见按钮</param>
        /// <param name="icon">提示图标</param>
        /// <param name="timeout">自动关闭所等待时间，如果不大于0则不自动关闭</param>
        /// <returns></returns>
        public DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, int timeout)
        {
            Text = caption;
            _text = text;
            _icon = icon;
            _buttons = buttons;
            _timeOut = timeout;
            switch (_buttons)
            {
                case MessageBoxButtons.OK:
                    btnOK.Visible = true;
                    CancelButton = btnOK;
                    break;
                case MessageBoxButtons.OKCancel:
                    btnOK.Visible = true;
                    btnCancel.Visible = true;
                    break;
                case MessageBoxButtons.YesNo:
                    btnOK.DialogResult = DialogResult.Yes;
                    btnOK.Text = "是";
                    btnCancel.DialogResult = DialogResult.No;
                    btnCancel.Text = "否";
                    btnOK.Visible = true;
                    btnCancel.Visible = true;
                    break;
                case MessageBoxButtons.RetryCancel:
                    btnOK.DialogResult = DialogResult.Retry;
                    btnOK.Text = "重试";
                    btnOK.Visible = true;
                    btnCancel.Visible = true;
                    break;
                case MessageBoxButtons.YesNoCancel:
                    btnOK.DialogResult = DialogResult.Yes;
                    btnOK.Text = "是";
                    btnOK.Visible = true;
                    btnCancel.Visible = true;
                    btnNo.Visible = true;
                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    btnOK.DialogResult = DialogResult.Abort;
                    btnOK.Text = "放弃";
                    btnNo.DialogResult = DialogResult.Retry;
                    btnNo.Text = "重试";
                    btnCancel.DialogResult = DialogResult.Ignore;
                    btnCancel.Text = "无效";
                    btnOK.Visible = true;
                    btnCancel.Visible = true;
                    btnNo.Visible = true;
                    break;
            }
            if (_timeOut > 0)
            {
                timer1.Enabled = true;
            }
            return ShowDialog();
        }

        /// <summary>
        /// 简单输入(选择)框
        /// </summary>
        /// <param name="text">提示内容</param>
        /// <param name="caption">框标题</param>
        /// <param name="initValue">初始值</param>
        /// <returns>输入选择结果</returns>
        public object SingleInputSelect(string text, string caption, object initValue)
        {
            return SingleInputSelect(text, caption, initValue, "yyyy-MM-dd HH:mm");
        }

        public struct InputStruct
        {
            public string Text;
            public string Caption;
            public object InitValue;
            public string InputFormat;
        }

        /// <summary>
        /// 复合输入(选择)框
        /// </summary>
        /// <param name="text">提示内容</param>
        /// <param name="caption">框标题</param>
        /// <param name="initValue">初始值</param>
        /// <param name="inputFormat">输入格式-日期输入时使用或者*号表示文本框为密码输入</param>
        /// <returns>输入选择结果</returns>
        public object[] MultiInputSelect(InputStruct[] inputParameters)
        {
            ///如果没有初始值则抛出异常
            foreach (InputStruct inputParameter in inputParameters)
            {
                if (inputParameter.InitValue == null)
                {
                    throw new Exception("Please give a not null initilized value!");
                }
            }

            resultObjects = new object[inputParameters.Length];
            singleInputSelectControls = new Control[inputParameters.Length];
            singleInputSelectTypes = new string[inputParameters.Length];
            inputLabels = new MedLabel[inputParameters.Length];

            for (int i = 0; i < inputParameters.Length; i++)
            {
                InputStruct inputParameter = inputParameters[i];
                //lblInput.Text = inputParameter.Text;
                //lblInput.Visible = true;

                Text = inputParameter.Caption;
                btnOK.Visible = true;
                btnCancel.Visible = true;
                inputLabels[i] = new MedLabel();
                inputLabels[i].Text = inputParameter.Text;

                ///输入类型
                singleInputSelectTypes[i] = inputParameter.InitValue.GetType().ToString();

                ///创建输入选择控件
                switch (singleInputSelectTypes[i])
                {
                    case "System.DateTime":
                        if (inputParameter.InputFormat.Equals("时间"))
                        {
                            //singleInputSelectControls[i] = new MaskedTextBox();
                            //(singleInputSelectControls[i] as MaskedTextBox).Mask = "00:00";
                            //(singleInputSelectControls[i] as MaskedTextBox).Font = new Font("微软雅黑", 20);
                            //(singleInputSelectControls[i] as MaskedTextBox).InsertKeyMode = InsertKeyMode.Overwrite;
                            //(singleInputSelectControls[i] as MaskedTextBox).Text = ((DateTime)inputParameter.InitValue).ToString("HH:mm");
                            //(singleInputSelectControls[i] as MaskedTextBox).KeyDown += Key_Down;
                            //(singleInputSelectControls[i] as MaskedTextBox).KeyUp += Key_Up;
                            //(singleInputSelectControls[i] as MaskedTextBox).TextChanged += Text_Changed;


                            //采用正则表达式方式   add  by colin
                            singleInputSelectControls[i] = new MaskBox();
                            (singleInputSelectControls[i] as MaskBox).Mask.EditMask = "([01][0-9]|2[0-3]):[0-5][0-9]";
                            (singleInputSelectControls[i] as MaskBox).Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                            (singleInputSelectControls[i] as MaskBox).Font = new Font("微软雅黑", 20);
                            (singleInputSelectControls[i] as MaskBox).EditText = ((DateTime)inputParameter.InitValue).ToString("HH:mm");
                            (singleInputSelectControls[i] as MaskBox).KeyDown += Key_Down;
                            (singleInputSelectControls[i] as MaskBox).KeyUp += Key_Up;
                            (singleInputSelectControls[i] as MaskBox).TextChanged += Text_Changed;
                        }
                        else
                        {
                            singleInputSelectControls[i] = new DevExpress.XtraEditors.DateEdit();
                            //(singleInputSelectControls[i] as DevExpress.XtraEditors.DateEdit).Format = DateTimePickerFormat.Custom;
                            (singleInputSelectControls[i] as DevExpress.XtraEditors.DateEdit).Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                            (singleInputSelectControls[i] as DevExpress.XtraEditors.DateEdit).Font = new Font("微软雅黑", 20);
                            //(singleInputSelectControls[i] as DevExpress.XtraEditors.DateEdit).CustomFormat = inputParameter.InputFormat;
                            (singleInputSelectControls[i] as DevExpress.XtraEditors.DateEdit).Properties.DisplayFormat.FormatString = inputParameter.InputFormat;
                            if (inputParameter.InputFormat.ToLower().Contains("hh:mm"))
                            {
                                //(singleInputSelectControls[i] as DevExpress.XtraEditors.DateEdit).ShowUpDown = true;
                            }
                            (singleInputSelectControls[i] as DevExpress.XtraEditors.DateEdit).DateTime = (DateTime)inputParameter.InitValue;
                        }
                        break;
                    default:
                        singleInputSelectControls[i] = new MedTextBox();
                        (singleInputSelectControls[i] as MedTextBox).Text = inputParameter.InitValue.ToString();
                        if (inputParameter.InputFormat.Equals("*"))
                        {
                            (singleInputSelectControls[i] as MedTextBox).Properties.PasswordChar = '*';
                        }
                        break;
                }

                singleInputSelectControls[i].Left = lblInput.Left;
                singleInputSelectControls[i].Width = ClientRectangle.Width - singleInputSelectControls[i].Left * 2;
                inputLabels[i].Left = lblInput.Left;
                inputLabels[i].Top = lblInput.Top + i * (inputLabels[i].Height + singleInputSelectControls[i].Height + 2);
                singleInputSelectControls[i].Top = inputLabels[i].Top + inputLabels[i].Height;
                Controls.Add(inputLabels[i]);
                Controls.Add(singleInputSelectControls[i]);
                singleInputSelectControls[i].TabIndex = i;

                //if (singleInputSelectControls[i] is MaskedTextBox)
                //{
                //    (singleInputSelectControls[i] as MaskedTextBox).Enter += new EventHandler(
                //        delegate(object sender1, EventArgs e1)
                //        {
                //            (sender1 as MaskedTextBox).SelectAll();
                //        }
                //    );
                //}



            }

            ShowDialog();

            return resultObjects;

        }


        /// <summary>
        /// 简单输入(选择)框
        /// </summary>
        /// <param name="text">提示内容</param>
        /// <param name="caption">框标题</param>
        /// <param name="initValue">初始值</param>
        /// <param name="inputFormat">输入格式-日期输入时使用或者*号表示文本框为密码输入</param>
        /// <returns>输入选择结果</returns>
        public object SingleInputSelect(string text, string caption, object initValue, string inputFormat)
        {
            ///如果没有初始值则抛出异常
            if (initValue == null)
            {
                throw new Exception("Please give a not null initilized value!");
            }

            resultObject = null;

            lblInput.Text = text;
            lblInput.Visible = true;
            Text = caption;
            btnOK.Visible = true;
            btnCancel.Visible = true;

            ///输入类型
            singleInputSelectType = initValue.GetType().ToString();

            ///创建输入选择控件
            switch (singleInputSelectType)
            {
                case "System.DateTime":
                    if (inputFormat.Equals("时间"))
                    {
                        //singleInputSelectControl = new MaskedTextBox();
                        //(singleInputSelectControl as MaskedTextBox).Mask = "00:00";
                        //(singleInputSelectControl as MaskedTextBox).Font = new Font("微软雅黑", 20);
                        //(singleInputSelectControl as MaskedTextBox).InsertKeyMode = InsertKeyMode.Overwrite;
                        //(singleInputSelectControl as MaskedTextBox).Text = ((DateTime)initValue).ToString("HH:mm");
                        //(singleInputSelectControl as MaskedTextBox).KeyDown += Key_Down;
                        //(singleInputSelectControl as MaskedTextBox).KeyUp += Key_Up;
                        //(singleInputSelectControl as MaskedTextBox).TextChanged += Text_Changed;


                        //采用正则表达式方式   add  by colin
                        //singleInputSelectControl = new MaskBox();
                        //(singleInputSelectControl as MaskBox).Mask.EditMask = "([01][0-9]|2[0-3]):[0-5][0-9]";
                        //(singleInputSelectControl as MaskBox).Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                        //(singleInputSelectControl as MaskBox).Font = new Font("微软雅黑", 20);
                        //(singleInputSelectControl as MaskBox).EditText = ((DateTime)initValue).ToString("HH:mm");
                        //(singleInputSelectControl as MaskBox).KeyDown += Key_Down;
                        //(singleInputSelectControl as MaskBox).KeyUp += Key_Up;
                        //(singleInputSelectControl as MaskBox).TextChanged += Text_Changed;
                        //整体护理弹出时间全选功能  2017-5-8 hh
                        singleInputSelectControl = new TextEdit();
                        (singleInputSelectControl as TextEdit).Properties.Mask.EditMask = "([01][0-9]|2[0-3]):[0-5][0-9]";
                        (singleInputSelectControl as TextEdit).Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                        (singleInputSelectControl as TextEdit).Font = new Font("微软雅黑", 20);
                        (singleInputSelectControl as TextEdit).Text = ((DateTime)initValue).ToString("HH:mm");
                        (singleInputSelectControl as TextEdit).KeyDown += Key_Down;
                        (singleInputSelectControl as TextEdit).KeyUp += Key_Up;
                        (singleInputSelectControl as TextEdit).TextChanged += Text_Changed;
                    }
                    else if (inputFormat.Equals("秒"))
                    {
                        //singleInputSelectControl = new MaskedTextBox();
                        //(singleInputSelectControl as MaskedTextBox).Mask = "00:00:00";
                        //(singleInputSelectControl as MaskedTextBox).Font = new Font("微软雅黑", 20);
                        //(singleInputSelectControl as MaskedTextBox).InsertKeyMode = InsertKeyMode.Overwrite;
                        //(singleInputSelectControl as MaskedTextBox).Text = ((DateTime)initValue).ToString("HH:mm:ss");
                        //(singleInputSelectControl as MaskedTextBox).KeyDown += Key_Down;
                        //(singleInputSelectControl as MaskedTextBox).KeyUp += Key_Up;
                        //(singleInputSelectControl as MaskedTextBox).TextChanged += Text_Changed;

                        //采用正则表达式方式   add  by colin
                        singleInputSelectControl = new MaskBox();
                        (singleInputSelectControl as MaskBox).Mask.EditMask = "([01][0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]";
                        (singleInputSelectControl as MaskBox).Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                        (singleInputSelectControl as MaskBox).Font = new Font("微软雅黑", 20);
                        (singleInputSelectControl as MaskBox).EditText = ((DateTime)initValue).ToString("HH:mm:ss");
                        (singleInputSelectControl as MaskBox).KeyDown += Key_Down;
                        (singleInputSelectControl as MaskBox).KeyUp += Key_Up;
                        (singleInputSelectControl as MaskBox).TextChanged += Text_Changed;
                    }
                    else if (inputFormat.Equals("长时间"))
                    {
                        //singleInputSelectControl = new MaskedTextBox();
                        //(singleInputSelectControl as MaskedTextBox).Mask = "0000-00-00 00:00";
                        //(singleInputSelectControl as MaskedTextBox).Font = new Font("微软雅黑", 20);
                        //(singleInputSelectControl as MaskedTextBox).InsertKeyMode = InsertKeyMode.Overwrite;
                        //(singleInputSelectControl as MaskedTextBox).Text = ((DateTime)initValue).ToString("yyyy-MM-dd HH:mm");
                        //(singleInputSelectControl as MaskedTextBox).KeyDown += Key_Down;
                        //(singleInputSelectControl as MaskedTextBox).KeyUp += Key_Up;
                        //(singleInputSelectControl as MaskedTextBox).TextChanged += Text_Changed;


                        //采用正则表达式方式   add  by colin
                        singleInputSelectControl = new MaskBox();
                        (singleInputSelectControl as MaskBox).Mask.EditMask = @"(\d{2}|\d{4})(?:\-)?([0]{1}\d{1}|[1]{1}[0-2]{1})(?:\-)?([0-2]{1}\d{1}|[3]{1}[0-1]{1})(?:\s)?([0-1]{1}\d{1}|[2]{1}[0-3]{1})(?::)?([0-5]{1}\d{1})(?::)?([0-5]{1}\d{1})";
                        (singleInputSelectControl as MaskBox).Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                        (singleInputSelectControl as MaskBox).Font = new Font("微软雅黑", 20);
                        (singleInputSelectControl as MaskBox).EditText = ((DateTime)initValue).ToString("yyyy-MM-dd HH:mm:ss");
                        (singleInputSelectControl as MaskBox).KeyDown += Key_Down;
                        (singleInputSelectControl as MaskBox).KeyUp += Key_Up;
                        (singleInputSelectControl as MaskBox).TextChanged += Text_Changed;
                    }
                    else
                    {
                        singleInputSelectControl = new DevExpress.XtraEditors.DateEdit();
                        //(singleInputSelectControl as DevExpress.XtraEditors.DateEdit).Format = DateTimePickerFormat.Custom;
                        (singleInputSelectControl as DevExpress.XtraEditors.DateEdit).Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        (singleInputSelectControl as DevExpress.XtraEditors.DateEdit).Font = new Font("微软雅黑", 20);
                        //(singleInputSelectControl as DevExpress.XtraEditors.DateEdit).CustomFormat = inputFormat;
                        (singleInputSelectControl as DevExpress.XtraEditors.DateEdit).Properties.DisplayFormat.FormatString = inputFormat;
                        if (inputFormat.ToLower().Contains("hh:mm"))
                        {
                            //(singleInputSelectControl as DevExpress.XtraEditors.DateEdit).ShowUpDown = true;
                        }
                        (singleInputSelectControl as DevExpress.XtraEditors.DateEdit).DateTime = (DateTime)initValue;
                    }
                    break;
                default:
                    singleInputSelectControl = new MedTextBox();
                    (singleInputSelectControl as MedTextBox).Text = initValue.ToString();
                    if (inputFormat.Equals("*"))
                    {
                        (singleInputSelectControl as MedTextBox).Properties.PasswordChar = '*';
                    }
                    break;
            }
            this.TopMost = false;//--设置成false，定位光标
            singleInputSelectControl.Left = lblInput.Left;
            singleInputSelectControl.Width = ClientRectangle.Width - singleInputSelectControl.Left * 2;
            singleInputSelectControl.Top = lblInput.Top + lblInput.Height + 5;
            Controls.Add(singleInputSelectControl);
            singleInputSelectControl.TabIndex = 0;

            //--修改为默认全选 add by byh 2015-12-9
            //if (singleInputSelectControl is MaskBox)
            //{
            //    (singleInputSelectControl as MaskBox).Enter += new EventHandler(
            //        delegate(object sender1, EventArgs e1)
            //        {
            //            (sender1 as MaskBox).MaskBoxSelectionStart = 0;
            //            (sender1 as MaskBox).MaskBoxSelectAll();
            //        }
            //    );
            //}
            if (singleInputSelectControl is TextEdit)
            {
                singleInputSelectControl.Focus();
                singleInputSelectControl.Select();
                ((BaseEdit)singleInputSelectControl).SelectAll();
            }
            else if (singleInputSelectControl is MaskBox)
            {
                (singleInputSelectControl as MaskBox).Enter += new EventHandler(
                    delegate(object sender1, EventArgs e1)
                    {
                        (sender1 as MaskBox).MaskBoxSelectionStart = 0;
                        (sender1 as MaskBox).MaskBoxSelectAll();
                    }
                );
            }
            ShowDialog();

            return resultObject;

        }

        /// <summary>
        /// 简单输入(选择)框
        /// </summary>
        /// <param name="text">提示内容</param>
        /// <param name="caption">框标题</param>
        /// <param name="initValue">初始值</param>
        /// <param name="inputFormat">输入格式-日期输入时使用或者*号表示文本框为密码输入</param>
        /// <param name="isCompleted">是否本频次结束</param>
        /// <returns>输入选择结果</returns>
        public object SingleInputSelect(string text, string caption, object initValue, string inputFormat, bool isCompleted)
        {
            ///如果没有初始值则抛出异常
            if (initValue == null)
            {
                throw new Exception("Please give a not null initilized value!");
            }

            resultObject = null;

            lblInput.Text = text;
            lblInput.Visible = true;
            //checkBox1.Visible = isCompleted;
            Text = caption;
            btnOK.Visible = true;
            btnCancel.Visible = true;

            ///输入类型
            singleInputSelectType = initValue.GetType().ToString();

            ///创建输入选择控件
            switch (singleInputSelectType)
            {
                case "System.DateTime":
                    if (inputFormat.Equals("时间"))
                    {

                        //singleInputSelectControl = new MaskedTextBox();
                        //(singleInputSelectControl as MaskedTextBox).Mask = "00:00";
                        //(singleInputSelectControl as MaskedTextBox).Font = new Font("微软雅黑", 20);
                        //(singleInputSelectControl as MaskedTextBox).InsertKeyMode = InsertKeyMode.Overwrite;
                        //(singleInputSelectControl as MaskedTextBox).Text = ((DateTime)initValue).ToString("HH:mm");
                        //(singleInputSelectControl as MaskedTextBox).KeyDown += Key_Down;
                        //(singleInputSelectControl as MaskedTextBox).KeyUp += Key_Up;
                        //(singleInputSelectControl as MaskedTextBox).TextChanged += Text_Changed;

                        //采用正则表达式方式   add  by colin
                        singleInputSelectControl = new MaskBox();
                        (singleInputSelectControl as MaskBox).Mask.EditMask = "([01][0-9]|2[0-3]):[0-5][0-9]";
                        (singleInputSelectControl as MaskBox).Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                        (singleInputSelectControl as MaskBox).Font = new Font("微软雅黑", 20);
                        (singleInputSelectControl as MaskBox).EditText = ((DateTime)initValue).ToString("HH:mm");
                        (singleInputSelectControl as MaskBox).KeyDown += Key_Down;
                        (singleInputSelectControl as MaskBox).KeyUp += Key_Up;
                        (singleInputSelectControl as MaskBox).TextChanged += Text_Changed;

                    }
                    else if (inputFormat.Equals("秒"))
                    {
                        //singleInputSelectControl = new MaskedTextBox();
                        //(singleInputSelectControl as MaskedTextBox).Mask = "00:00:00";
                        //(singleInputSelectControl as MaskedTextBox).Font = new Font("微软雅黑", 20);
                        //(singleInputSelectControl as MaskedTextBox).InsertKeyMode = InsertKeyMode.Overwrite;
                        //(singleInputSelectControl as MaskedTextBox).Text = ((DateTime)initValue).ToString("HH:mm:ss");
                        //(singleInputSelectControl as MaskedTextBox).KeyDown += Key_Down;
                        //(singleInputSelectControl as MaskedTextBox).KeyUp += Key_Up;
                        //(singleInputSelectControl as MaskedTextBox).TextChanged += Text_Changed;

                        //采用正则表达式方式   add  by colin
                        singleInputSelectControl = new MaskBox();
                        (singleInputSelectControl as MaskBox).Mask.EditMask = "([01][0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]";
                        (singleInputSelectControl as MaskBox).Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                        (singleInputSelectControl as MaskBox).Font = new Font("微软雅黑", 20);
                        (singleInputSelectControl as MaskBox).EditText = ((DateTime)initValue).ToString("HH:mm:ss");
                        (singleInputSelectControl as MaskBox).KeyDown += Key_Down;
                        (singleInputSelectControl as MaskBox).KeyUp += Key_Up;
                        (singleInputSelectControl as MaskBox).TextChanged += Text_Changed;

                    }
                    else
                    {
                        singleInputSelectControl = new DevExpress.XtraEditors.DateEdit();
                        //(singleInputSelectControl as DevExpress.XtraEditors.DateEdit).Format = DateTimePickerFormat.Custom;
                        (singleInputSelectControl as DevExpress.XtraEditors.DateEdit).Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        (singleInputSelectControl as DevExpress.XtraEditors.DateEdit).Font = new Font("微软雅黑", 20);
                        //(singleInputSelectControl as DevExpress.XtraEditors.DateEdit).CustomFormat = inputFormat;
                        (singleInputSelectControl as DevExpress.XtraEditors.DateEdit).Properties.DisplayFormat.FormatString = inputFormat;
                        if (inputFormat.ToLower().Contains("hh:mm"))
                        {
                            //(singleInputSelectControl as DevExpress.XtraEditors.DateEdit).ShowUpDown = true;
                        }
                        (singleInputSelectControl as DevExpress.XtraEditors.DateEdit).DateTime = (DateTime)initValue;
                    }
                    break;
                default:
                    singleInputSelectControl = new MedTextBox();
                    (singleInputSelectControl as MedTextBox).Text = initValue.ToString();
                    if (inputFormat.Equals("*"))
                    {
                        (singleInputSelectControl as MedTextBox).Properties.PasswordChar = '*';
                    }
                    break;
            }
            this.TopMost = false;//--设置成false，定位光标
            singleInputSelectControl.Left = lblInput.Left;
            singleInputSelectControl.Width = ClientRectangle.Width - singleInputSelectControl.Left * 2;
            singleInputSelectControl.Top = lblInput.Top + lblInput.Height + 5;
            Controls.Add(singleInputSelectControl);
            singleInputSelectControl.TabIndex = 0;

            if (singleInputSelectControl is TextEdit)
            {
                singleInputSelectControl.Focus();
                singleInputSelectControl.Select();
                ((BaseEdit)singleInputSelectControl).SelectAll();
            }
            else if (singleInputSelectControl is MaskBox)
            {
                (singleInputSelectControl as MaskBox).Enter += new EventHandler(
                    delegate(object sender1, EventArgs e1)
                    {
                        (sender1 as MaskBox).MaskBoxSelectionStart = 0;
                        (sender1 as MaskBox).MaskBoxSelectAll();
                    }
                );
            }


            ShowDialog();
            if (resultObject != null)
            {
                resultObject = resultObject.ToString() + "#" + checkBox1.Checked.ToString();
            }
            return resultObject;

        }

        /// <summary>
        /// 键盘按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Key_Down(object sender, KeyEventArgs e)
        {
            //if (sender is MaskedTextBox)
            //{
            //if ((sender as MaskedTextBox).SelectionStart == 2)
            //{
            //    (sender as MaskedTextBox).SelectionStart = 4;
            //}
            //}
        }

        /// <summary>
        /// 键盘按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Key_Up(object sender, KeyEventArgs e)
        {
            if (singleInputSelectControl is TextEdit && e.KeyCode == Keys.Enter)
            {
                singleInputSelectControl.Focus();
                singleInputSelectControl.Select();
                ((BaseEdit)singleInputSelectControl).SelectAll();
            }
            //if (sender is MaskBox)
            //{
            //    if ((sender as MaskBox).MaskBoxSelectionStart > (sender as MaskBox).MaskBoxText.Length)
            //    {
            //        (sender as MaskBox).MaskBoxSelectionStart = 0;
            //    }
            //}
            //if (sender is MaskedTextBox)
            //{
            //if((sender as MaskedTextBox).IsOverwriteMode = 
            //    ((sender as MaskedTextBox).SelectionStart == 2)
            //{
            //    (sender as MaskedTextBox).SelectionStart = 4;
            //}
            //}
        }

        /// <summary>
        /// 值改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Text_Changed(object sender, EventArgs e)
        {
            //if (sender is MaskedTextBox)
            //{
            //if (((sender as MaskedTextBox).GetPositionFromCharIndex( .SelectionStart == 1))
            //{
            //    (sender as MaskedTextBox).SelectionStart = 4;
            //}
            //}
        }

        /// <summary>
        /// 绘制提示信息
        /// </summary>
        /// <param name="e">绘制事件参数</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ///如果没有提示文本信息则不处理
            if (string.IsNullOrEmpty(_text))
            {
                return;
            }

            ///绘制提示图标
            switch (_icon)
            {
                case MessageBoxIcon.Error:
                    e.Graphics.DrawImage(Resources.Error, 50, 90);
                    break;
                case MessageBoxIcon.Warning:
                    e.Graphics.DrawImage(Resources.Warn, 50, 90);
                    break;
                case MessageBoxIcon.Information:
                    e.Graphics.DrawImage(Resources.Information, 50, 90);
                    break;
                case MessageBoxIcon.Question:
                    e.Graphics.DrawImage(Resources.Question, 50, 90);
                    break;
                case MessageBoxIcon.None:
                    break;
            }

            ///绘制提示文本
            e.Graphics.DrawString(_text, this.Font, new SolidBrush(this.ForeColor), new RectangleF(100, 95, 300, 250));
        }

        #endregion 方法

        #region 控件事件

        private void btnOK_Click(object sender, EventArgs e)
        {
            ///简单输入选择
            if (lblInput.Visible)
            {
                switch (singleInputSelectType)
                {
                    case "System.DateTime":
                        if (singleInputSelectControl is DevExpress.XtraEditors.DateEdit)
                        {
                            resultObject = (singleInputSelectControl as DevExpress.XtraEditors.DateEdit).DateTime;
                        }
                        else
                        {
                            try
                            {
                                //resultObject = DateTime.Parse((singleInputSelectControl as MaskedTextBox).Text);
                                
                                 resultObject = DateTime.Parse(singleInputSelectControl.Text);
                                                            
                            }
                            catch
                            {
                                Sundries.MessageBox("输入时间错误！", MessageBoxIcon.Error);
                                resultObject = null;
                            }
                        }
                        break;
                    default:
                        resultObject = (singleInputSelectControl as MedTextBox).Text;
                        break;
                }
            }
            else if ((singleInputSelectControls != null) && (singleInputSelectControls.Length > 0) && (singleInputSelectControls[0] != null))
            {
                for (int i = 0; i < singleInputSelectControls.Length; i++)
                {
                    switch (singleInputSelectTypes[i])
                    {
                        case "System.DateTime":
                            if (singleInputSelectControls[i] is DevExpress.XtraEditors.DateEdit)
                            {
                                resultObjects[i] = (singleInputSelectControls[i] as DevExpress.XtraEditors.DateEdit).DateTime;
                            }
                            else
                            {
                                try
                                {
                                    resultObjects[i] = DateTime.Parse(singleInputSelectControls[i].Text);
                                }
                                catch
                                {
                                    Sundries.MessageBox("输入时间错误！", MessageBoxIcon.Error);
                                    resultObjects[i] = null;
                                }
                            }
                            break;
                        default:
                            resultObjects[i] = (singleInputSelectControls[i] as MedTextBox).Text;
                            break;
                    }
                }
            }
        }

        #endregion 控件事件

        private void MessageBoxForm_Activated(object sender, EventArgs e)
        {
            if (singleInputSelectControl != null)
            {
                singleInputSelectControl.Focus();
                singleInputSelectControl.Select();
                ((BaseEdit)singleInputSelectControl).SelectAll();
            }
            else if ((singleInputSelectControls != null) && (singleInputSelectControls.Length > 0) && (singleInputSelectControls[0] != null) && (singleInputSelectControls[0].Visible))
            {
                singleInputSelectControls[0].Focus();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_timeOut > 0)
            {
                lblTimeOut.Text = string.Format("信息提示对话框系统将在{0}秒后自动关闭", _timeOut--);
            }
            else
            {
                Close();
            }
        }

        private void MessageBoxForm_Load(object sender, EventArgs e)
        {

        }

        private void lblInput_Paint(object sender, PaintEventArgs e)
        {
            //foreach (Control ctl in pnlTop.Controls)
            //    ctl.Refresh();
        }

    }
}
