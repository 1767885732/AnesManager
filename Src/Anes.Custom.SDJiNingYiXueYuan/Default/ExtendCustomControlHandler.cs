/*----------------------------------------------------------------
// Copyright (C) 2008 北京拓扑工厂科技发展有限公司
// 文件名：ExtendCustomControlHandler.cs
// 文件功能描述：上海儿童医学中心手术风险评估单自定义控件
// 创建标识：深蓝色右手 2011-08-29
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.Framework.Documents;
using Wis.Anes.Framework.Controls;
using Wis.Anes.Framework.Doc;
using Wis.Anes.Framework.Documents.DefaultHandlers;
using System.Configuration;
using Wis.Anes.Framework.Controls.Base;
using System.Text.RegularExpressions;
using Wis.Anes.Framework.Utilities;

namespace Wis.Anes.Custom.CustomProject.Default
{
    public class ExtendCustomControlHandler : CustomControlHandler
    {
        private Dictionary<string, List<CustomControl>> _groupCustomControls = new Dictionary<string, List<CustomControl>>();
        private MTextBox _text1;
        private MTextBox _text2;
        private MTextBox _text3;
        private MTextBox _text4;

        private CustomControl _nnisControl;

        
        public override void BindUIToData(CustomControl control, Dictionary<string, System.Data.DataTable> dataSources)
        {
            if (string.IsNullOrEmpty(control.SourceTableName) || string.IsNullOrEmpty(control.SourceFieldName))
                return;
           

            object value = null;
            if (control.MultiSelect)
            {
                Type type = typeof(string);
                if (control.SourceTableName.ToUpper().Equals("WIS_CUSTOM_DATA"))
                {
                }
                else
                {
                    type = dataSources[control.SourceTableName.ToUpper()].Columns[control.SourceFieldName].DataType;
                }
                value = AssemblyHelper.GetValueFromString(type, control.Value);
            }
            else
            {
                value = control.SimpleValue;
            }

            SetFieldValue(control.SourceTableName, control.SourceFieldName, value);
        }
        public override void ControlSetting(CustomControl control)
        {
            base.ControlSetting(control);

            if (control.Name == "CustomControl1")
                _nnisControl = control;

            foreach (IUIElementHandler handler in base.MedicalPaperUIElementHandlers)
            {
                if (handler is TextBoxHandler)
                {
                    TextBoxHandler h = handler as TextBoxHandler;
                    foreach (MTextBox text in h.GetCurrentControls)
                    {
                        if (text.Name.Trim() == "MTextBox21")
                        {
                            _text1 = text;
                            _text1.TextChanged+= new EventHandler(MTextBox_ValueChanged);
                        }
                        else if (text.Name.Trim() == "MTextBox22")
                        {
                            _text2 = text;
                            _text2.TextChanged += new EventHandler(MTextBox_ValueChanged);
                        }
                        else if (text.Name.Trim() == "MTextBox23")
                        {
                            _text3 = text;
                            _text3.TextChanged += new EventHandler(MTextBox_ValueChanged);
                        }
                        else if (text.Name.Trim() == "MTextBox24")
                        {
                            _text4 = text;
                            //_text4.TextChanged += new EventHandler(MTextBox_ValueChanged);
                        }
                           

                    }
                    break;
                }
            }

            if (!string.IsNullOrEmpty(control.GroupName))
            {
                if (!_groupCustomControls.ContainsKey(control.GroupName))
                    _groupCustomControls.Add(control.GroupName, new List<CustomControl>());

                if (!_groupCustomControls[control.GroupName].Contains(control))
                    _groupCustomControls[control.GroupName].Add(control);

                control.ValueChanged += delegate
                {
                    //单选
                    if (control.SimpleValue != null)
                    {
                        List<CustomControl> controls = _groupCustomControls[control.GroupName];
                        foreach (CustomControl c in controls)
                        {
                            if (c != control)
                            {
                                c.SimpleValue = null;
                                c.Value = string.Empty;
                            }
                        }

                    }
                    //计算评分
                    //CalculateRiskAssessmentData();
                };
            }

        }
        /// <summary>
        /// 计算评分的方法
        /// </summary>
        public void CalculateRiskAssessmentData()
        {
            //获取相关控件
            if (_text1 == null || _text2 == null || _text3 == null || _text4 == null)
            {
                foreach (IUIElementHandler handler in base.MedicalPaperUIElementHandlers)
                {
                    if (handler is TextBoxHandler)
                    {
                        TextBoxHandler h = handler as TextBoxHandler;
                        foreach (MTextBox text in h.GetCurrentControls)
                        {
                            if (text.Name.Trim() == "MTextBox21")
                                _text1 = text;
                            else if (text.Name.Trim() == "MTextBox22")
                                _text2 = text;
                            else if (text.Name.Trim() == "MTextBox23")
                                _text3 = text;
                            else if (text.Name.Trim() == "MTextBox24")
                                _text4 = text;
                    
                        }
                        break;
                    }
                }
            }
            if (_text1 == null || _text2 == null || _text3 == null || _text4 == null)
            {
                //throw new ConfigurationErrorsException("手术风险评估模版文件配置有误,未找到最后一行相关的控件");
            }
            //计算手术切口清洁程度
            _text1.Text=string.Empty;
            SetControlValue(_groupCustomControls["手术切口清洁程度"], _text1);
            //计算麻醉ASA分级
            _text2.Text = string.Empty;
             SetControlValue(_groupCustomControls["ASA分级"], _text2);
            //计算手术持续时间
            _text3.Text = string.Empty;
            SetControlValue(_groupCustomControls["手术持续时间"], _text3);
           
            //计算总分
            _text4.Text = "0";
            if (!string.IsNullOrEmpty(_text1.Text.Trim()))
            {
                _text4.Text = (Convert.ToInt32(_text4.Text) + Convert.ToInt32(_text1.Text.Trim())).ToString();
            }
            if (!string.IsNullOrEmpty(_text2.Text.Trim()))
            {
                _text4.Text = (Convert.ToInt32(_text4.Text) + Convert.ToInt32(_text2.Text.Trim())).ToString();
            }
            if (!string.IsNullOrEmpty(_text3.Text.Trim()))
            {
                _text4.Text = (Convert.ToInt32(_text4.Text) + Convert.ToInt32(_text3.Text.Trim())).ToString();
            }
            _nnisControl.SimpleValue = Convert.ToInt32(_text4.Text.Trim());
        }

        public void CalculateRiskAssessmentDataLongShan(string val)
        {
            //获取相关控件

            //foreach (IUIElementHandler handler in base.MedicalPaperUIElementHandlers)
            //{
            //    if (handler is TextBoxHandler)
            //    {
            //        TextBoxHandler h = handler as TextBoxHandler;
            //        foreach (MTextBox text in h.GetCurrentControls)
            //        {
            //            if (text.Name.Trim() == "MTextBox21")
            //                _text1 = text;
            //            else if (text.Name.Trim() == "MTextBox22")
            //                _text2 = text;
            //            else if (text.Name.Trim() == "MTextBox23")
            //                _text3 = text;
            //            else if (text.Name.Trim() == "MTextBox24")
            //                _text4 = text;

            //        }
            //        break;
            //    }
            //} 


            ////计算手术切口清洁程度
            //_text1.Text = string.Empty;
            //SetControlValue(_groupCustomControls["手术切口清洁程度"], _text1);
            ////计算麻醉ASA分级
            //_text2.Text = string.Empty;
            //SetControlValue(_groupCustomControls["ASA分级"], _text2);
            ////计算手术持续时间
            //_text3.Text = string.Empty;
            //SetControlValue(_groupCustomControls["手术持续时间"], _text3);
            var dt = DataContext.GetCurrent().GetData("WIS_OPER_MASTER");
            if(dt.Rows[0]["START_DATE_TIME"].ToString()!="" && dt.Rows[0]["START_DATE_TIME"].ToString() != "")
            {
                DateTime dtst = DateTime.Parse(dt.Rows[0]["START_DATE_TIME"].ToString());
                DateTime dten = DateTime.Parse(dt.Rows[0]["END_DATE_TIME"].ToString());
                TimeSpan ts = dten - dtst;
                if (ts.Hours > 3)
                {
                    _text3.Text = "1";
                }
                else
                {
                    _text3.Text = "0";
                }
                //计算总分
                _text4.Text = "0";
                if (!string.IsNullOrEmpty(_text1.Text.Trim()))
                {
                    _text4.Text = (Convert.ToInt32(_text4.Text) + Convert.ToInt32(_text1.Text.Trim()) + Convert.ToInt32(_text3.Text.Trim())).ToString();
                }
                if (!string.IsNullOrEmpty(_text2.Text.Trim()))
                {
                    _text4.Text = (Convert.ToInt32(_text4.Text) + Convert.ToInt32(_text2.Text.Trim()) + Convert.ToInt32(_text3.Text.Trim())).ToString();
                }
            }
            else
            {
                _text4.Text = "0";
                if (!string.IsNullOrEmpty(_text1.Text.Trim()))
                {
                    _text4.Text = (Convert.ToInt32(_text4.Text) + Convert.ToInt32(_text1.Text.Trim())).ToString();
                }
                if (!string.IsNullOrEmpty(_text2.Text.Trim()))
                {
                    _text4.Text = (Convert.ToInt32(_text4.Text) + Convert.ToInt32(_text2.Text.Trim()) ).ToString();
                }
                if (!string.IsNullOrEmpty(_text3.Text.Trim()))
                {
                    _text4.Text = (Convert.ToInt32(_text4.Text) + Convert.ToInt32(_text3.Text.Trim())).ToString();
                }
            }


            _nnisControl.SimpleValue = Convert.ToInt32(_text4.Text.Trim())+1;
            //_nnisControl.DefaultItems = Convert.ToInt32(_text4.Text.Trim()) + 1;
        }

        /// <summary>
        /// 设置控件的值
        /// </summary>
        /// <param name="customControls"></param>
        /// <param name="text"></param>
        private void SetControlValue(List<CustomControl> customControls, MTextBox text)
        {
            foreach (CustomControl customControl in customControls)
            {
                if (customControl.SimpleValue != null)
                {
                    int v;
                    if (int.TryParse(customControl.SimpleValue.ToString(), out v))
                    {
                        text.Text = v.ToString();
                        break;
                    }
                }
            }
        }

        protected void MTextBox_ValueChanged(object sender, EventArgs e)
        {
            MTextBox mTextBox = sender as MTextBox;
            var mValue = mTextBox.Text;
            if (IsInt(mValue))
            {
                if(Int32.Parse(mValue) >1|| Int32.Parse(mValue) < 0)
                {
                    mTextBox.Text = "";
                    //Dialog.MessageBox("提示：请输入0或1。");
                }
                else
                {
                    CalculateRiskAssessmentDataLongShan(mValue);
                }
                
            }
            else
            {
                mTextBox.Text = "";
                //Dialog.MessageBox("提示：请输入0或1。");
                //return;
            }

            

        }

        

        public static bool IsInt(string value)
        {
            if (value == "0" || value == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
            //return Regex.IsMatch(value, @"^[+-]?\d*$");
        }

    }
}
