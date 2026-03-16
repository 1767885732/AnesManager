using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.Framework.Controls;
using System.Data;
using Wis.Anes.Framework.Utilities;
using Wis.Anes.Framework.Controls.Base;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.BusinessEntity;
using System.ComponentModel;
using Wis.Anes.DataAccess;
using System.Windows.Forms;

namespace Wis.Anes.Framework.Documents.DefaultHandlers
{
    /// <summary>
    /// 
    /// </summary>
    public class TextBoxHandler : UIElementHandler<MTextBox>
    {


        string anes_doc = string.Empty;

        /// <summary>
        /// 绑定控件内容到数据源
        /// </summary>
        /// <param name="control"></param>
        /// <param name="dataSources"></param>
        public override void BindUIToData(MTextBox control, Dictionary<string, DataTable> dataSources)
        {
            if (string.IsNullOrEmpty(control.SourceTableName) || string.IsNullOrEmpty(control.SourceFieldName))
                return;
            if (control.ReadOnly == true || control.Enabled == false)
                return;
            if (string.IsNullOrEmpty(control.Text))
            {
                control.Data = DBNull.Value;
            }
            else
            {
                if (string.IsNullOrEmpty(control.DictTableName) && string.IsNullOrEmpty(control.DictValueFieldName))
                {
                    SetControlValue(control);
                }
                else if (control.CanEdit)
                {
                    //如果控件同时支持下拉框和文本编辑功能
                    //如果从下拉框中选择的值跟实际编辑的文本值不相同(表示用户修改了从下拉框中选择的值)
                    //则根据当前的文本值重新设置实际Data值
                    bool isAleadySetValue = false;
                    if (!string.IsNullOrEmpty(control.SelectedText) && control.SelectedText.Trim() != control.Text.Trim())
                    {
                        isAleadySetValue = true;
                        SetControlValue(control);
                    }
                    //添加SelectedData属性进行判断，以防止一些现场反映某些文本编辑方式下无法保存的问题
                    if (control.SelectedData != null && control.SelectedData != control.Data)
                    {
                        if (!string.IsNullOrEmpty(control.SelectedText) && control.SelectedText.Trim() == control.Text.Trim())
                        {
                            control.Data = control.SelectedData;
                        }
                        else
                        {
                            if (!isAleadySetValue)
                            {
                                SetControlValue(control);
                            }
                        }
                    }
                    //Modify @2014-02-14
                    //修复一个bug，操作步骤为第一次载入后双击下拉列表，不选择任何项目，直接编辑输入框，保存，由于control.Data有值导致不能保存当前输入的内容
                    //else if (control.SelectedData == null && (control.Data == null || control.Data == DBNull.Value)
                    else if (control.SelectedData == null && (control.Data == null || control.Data == DBNull.Value || control.Data != control.Text))
                    {
                        SetControlValue(control);
                    }
                    //End Modify
                }


            }
            if (control.SourceFieldName.Equals("CERVIX"))
            {
                object o = control.Data;
                string s = control.Text;
            }
            SetFieldValue(control.SourceTableName, control.SourceFieldName, control.Data);



        }


        string asagrade = string.Empty;

        /// <summary>
        /// 绑定数据源数据到控件
        /// </summary>
        /// <param name="control"></param>
        /// <param name="dataSources"></param>
        public override void BindDataToUI(MTextBox control, Dictionary<string, DataTable> dataSources)
        {
            if (string.IsNullOrEmpty(control.SourceTableName) || string.IsNullOrEmpty(control.SourceFieldName))
                return;

            if (!dataSources.ContainsKey(control.SourceTableName.ToUpper()))
                throw new NotImplementedException(string.Format("在数据源中未找到名为{0}的表,请添加此绑定数据源!", control.SourceTableName.ToUpper()));
            if (dataSources[control.SourceTableName.ToUpper()].Rows.Count != 1 && control.SourceTableName.ToUpper() != "WIS_CUSTOM_DATA")
                throw new NotImplementedException(string.Format("在名为{0}的表中查询到多条记录,应仅只包含当前患者的唯一记录!", control.SourceTableName.ToUpper()));
            if (!dataSources[control.SourceTableName.ToUpper()].Columns.Contains(control.SourceFieldName) && control.SourceTableName.ToUpper() != "WIS_CUSTOM_DATA")
            {

                throw new NotImplementedException(string.Format("在名为{0}的表中未找到名为{1}的数据列!", control.SourceTableName.ToUpper(), control.SourceFieldName));
            }
            if (control.SourceTableName.Trim().ToUpper() != "WIS_CUSTOM_DATA")
            {
                int maxLength = dataSources[control.SourceTableName.ToUpper()].Columns[control.SourceFieldName].MaxLength;
                if (maxLength != -1)
                    control.MaxLength = maxLength;
            }
            if (!string.IsNullOrEmpty(control.InitValue) && control.InitValue.ToLower() == "datetoage")
            {
                PatientBaseInformations.PatMasterIndexDataTable dataTable = base.DataSource["WIS_PAT_MASTER_INDEX"] as PatientBaseInformations.PatMasterIndexDataTable;
                if (dataTable != null && dataTable.Count == 1 && !dataTable[0].IsDATE_OF_BIRTHNull())
                {
                    //control.InitValue =  DateDiff.CalAge(dataTable[0].DATE_OF_BIRTH, DateTime.Now);
                    control.InitValue = DateDiff.CalAge(dataTable[0].DATE_OF_BIRTH, (new CommonDA()).GetSysDateTime());
                }
                else
                {
                    control.InitValue = "未填";
                }
            }

            if (!string.IsNullOrEmpty(control.SourceTableName) && !string.IsNullOrEmpty(control.SourceFieldName))
            {
                control.SetData(GetFieldValue(control.SourceTableName, control.SourceFieldName));
            }
            object data = control.Data;
            //if (control.Data is DateTime && (IsDateTimeFomrat(control.Format) || IsFunctionFormat(control.Format)))
            //{

            //    control.Text = FormatDateTime((DateTime)control.Data, control.Format);

            //}
            if (control.Data is DateTime && (IsDateTimeFomrat(control.Format)))
            {
                control.Tag = "1";
                control.Text = FormatDateTime((DateTime)control.Data, control.Format);

            }
            else if (control.Data is DateTime && IsFunctionFormat(control.Format))
            {
                control.Tag = "1";
                control.Text = DateDiff.CalAge((DateTime)control.Data, DateTime.Now);

            }
            else if (!string.IsNullOrEmpty(control.DictTableName) && !string.IsNullOrEmpty(control.DictValueFieldName) && control.DictValueFieldName.ToLower() != control.DisplayFieldName.ToLower() && !control.MultiSelect)
            {
                control.Text = TransDictCode(control.DictTableName, control.DictValueFieldName, control.DisplayFieldName, control.DictWhereString, control.Data);
            }
            else if (control.MultiSelect)
            {
                if (control.Data != null)
                {
                    control.Text = control.Data.ToString();
                }
            }
            control.Data = data;
        }
        /// <summary>
        /// 控件事件设置
        /// </summary>
        /// <param name="control"></param>
        public override void ControlSetting(MTextBox control)
        {
            //ASA分级
            if (control.Name.ToLower() == "txtasagrade")
            {
                //Dialog.MessageBox("找到控件");
                control.TextChanged += new EventHandler(controlAnesGrade_TextChanged);
            }
            if (control.Name == "MedTextBoxAnesDoc")
            {
                control.TextChanged += new EventHandler(MedTextBoxAnesDoc_TextChanged);
                anes_doc = control.Value.ToString();
            }
            if (IsDateTimeFomrat(control.Format) || (!string.IsNullOrEmpty(control.DictTableName) && !string.IsNullOrEmpty(control.DictValueFieldName)))
            {
                if (ApplicationConfiguration.DoubleSelect && !IsDateTimeFomrat(control.Format))
                {
                    control.DoubleClick += delegate
                    {
                        ShowPopupForm(control);
                    };
                }
                else
                {
                    control.Click += delegate
                    {
                        ShowPopupForm(control);
                    };
                    control.Enter += delegate
                    {
                        ShowPopupForm(control);
                    };
                }


            }
            control.TextChanged += delegate
            {
                if (control.ReadOnly)
                {
                }
                else
                {
                    base.HasDirty = true;

                    if (!string.IsNullOrEmpty(control.DictTableName) && !string.IsNullOrEmpty(control.DictValueFieldName) && control.HasLookUpItems == false && control.CanEdit)
                    {
                        SetControlValue(control);
                    }
                }
            };
        }

        System.Threading.Thread t1 = new System.Threading.Thread(new System.Threading.ThreadStart(Msg));
        private void MedTextBoxAnesDoc_TextChanged(object sender, EventArgs e)
        {
            anes_doc = (sender as MTextBox).Value.ToString();
            controlAnesGrade_TextChanged(null, null);

        }
        //进入麻醉单后，系统根据填写的ASA分级和主麻匹配判断，如麻醉医生越级不匹配，
        //弹出提示：“您已超权限，是否继续进行此项操作？”选择是，则继续越级操作，选择否，光标自动跳至主麻填写框，    
        private void controlAnesGrade_TextChanged(object sender, EventArgs e)
        {
            ExtendApplicationContext.Current.IsYueJi = false;
            t1.Abort();
            //string anes_doc = string.Empty;

            if (string.IsNullOrEmpty(anes_doc))
            {
                AnesInformations.OperationMasterDataTable dt = new AnesthesiaSheetDA().GetOperationMaster(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID);
                if (dt.Rows.Count > 0)
                    anes_doc = dt.Rows[0]["ANES_DOCTOR"].ToString();
            }
            //if (anes_doc == ExtendApplicationContext.Current.LoginUserContext.HisUserID || anes_doc == ExtendApplicationContext.Current.LoginUserContext.UserName)
            {
                asagrade = sender == null ? asagrade : (sender as MTextBox).Value.ToString();
                if (string.IsNullOrEmpty(asagrade.Trim()))
                {
                    ExtendApplicationContext.Current.IsYueJi = false;
                    return;
                }
                //Dialog.MessageBox(asagrade);
                Dict.WIS_USER_ASA_GRADEDataTable WIS_USER_ASA_GRADEDataTable = (new DictDA()).GetAnesDocGradeDict();
                DataRow[] ROWS = WIS_USER_ASA_GRADEDataTable.Select("USER_ID='" + anes_doc + "' OR USER_NAME='" + anes_doc + "'");
                bool isWarning = false;
                int i_grade = 0;
                int.TryParse(asagrade.Replace("Ⅰ", "1").Replace("Ⅱ", "2").Replace("Ⅲ", "3").Replace("Ⅳ", "4").Replace("Ⅴ", "5").Replace("Ⅵ", "6"), out i_grade);
                int write_grade = i_grade;
                if (write_grade == 0)
                    return;
                int user_grade = 1;
                int u_grade = 0;
                if (ROWS.Length > 0)
                {
                    string[] asa_g = ROWS[0]["ASA_GRADE"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string s in asa_g)
                    {
                        if (string.IsNullOrEmpty(s))
                            continue;
                        int.TryParse(s.Replace("Ⅰ", "1").Replace("Ⅱ", "2").Replace("Ⅲ", "3").Replace("Ⅳ", "4").Replace("Ⅴ", "5").Replace("Ⅵ", "6"), out u_grade);
                        int user_grade_temp = u_grade;
                        if (user_grade_temp > user_grade)
                        {
                            user_grade = user_grade_temp;
                        }
                    }
                    if (write_grade > user_grade)
                    {
                        isWarning = true;
                        ExtendApplicationContext.Current.IsYueJi = true;
                    }
                }
                else
                {
                    isWarning = true;
                    ExtendApplicationContext.Current.IsYueJi = true;
                }
                if (isWarning)
                {
                    //DialogResult res = Dialog.MessageBox(string.Format("您已超权限，是否继续进行此项操作？主麻：{0}，登录用户ID：{1}，登录用户名称{2}。", ExtendApplicationContext.Current.PatientInformation.AnesDoctor, ExtendApplicationContext.Current.LoginUserContext.HisUserID, ExtendApplicationContext.Current.LoginUserContext.UserName), "提示", System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question);

                    //if (res == DialogResult.OK)
                    //{
                    //    //txtAnesDoc.Focus();
                    //    if (txtAnesDoc == null)
                    //    {
                    //        //isFocus = true;
                    //    }
                    //}

                    //Dialog.MessageBox("您已越权操作。");
                    if (t1.ThreadState == System.Threading.ThreadState.Stopped)
                        t1.Start();
                    //t1.Abort();


                }
                else
                    ExtendApplicationContext.Current.IsYueJi = false;
            }

        }
        private static void Msg()
        {
            if (Dialog.MessageBox("您已越权操作。") == DialogResult.OK)
            {

            }
        }
        /// <summary>
        /// 设置控件的实际值
        /// </summary>
        /// <param name="control"></param>
        protected void SetControlValue(MTextBox control)
        {
            if (control.MultiSelect)
            {
                control.Data = control.Text;
            }
            else
            {
                if (control.InputType == MedInputType.Integer)
                    control.Data = Convert.ToInt32(control.Text);
                else if (control.InputType == MedInputType.String || control.InputType == MedInputType.General)
                    control.Data = control.Text;
                else if (control.InputType == MedInputType.Nurmeric && !string.IsNullOrEmpty(control.Text.Trim()))
                    control.Data = Convert.ToDecimal(control.Text);
                else if (control.InputType == MedInputType.Date || control.InputType == MedInputType.Time)
                    control.Data = Convert.ToDateTime(control.Text);
            }
            if (control.Data is DateTime && !string.IsNullOrEmpty(control.Format) && (control.SourceTableName.ToUpper() == "WIS_CUSTOM_DATA" || base.DataSource[control.SourceTableName].Columns[control.SourceFieldName].DataType == typeof(string)))
            {
                control.Data = FormatDateTime((DateTime)control.Data, control.Format);
            }
        }
        /// <summary>
        /// 从字典下拉框中选择
        /// </summary>
        /// <param name="textBox"></param>
        private void ShowPopupForm(MTextBox textbox)
        {
            //如果只读 退出
            if (textbox.ReadOnly)
                return;
            //如果是时间下拉框
            if (IsDateTimeFomrat(textbox.Format))
            {
                DateTime dateTime;
                if (textbox.Data != null && textbox.Data is DateTime)
                {
                    dateTime = (DateTime)textbox.Data;
                }
                else if (!DateTime.TryParse(textbox.Text.Replace(",", "-").Replace("/", "-"), out dateTime))
                {
                    dateTime = DateTime.Now;
                }
                string replaceString = "-";
                string formatString = TransDateFormat(textbox.Format, replaceString);
                if (ExtendApplicationContext.Current.CustomSettingContext.IsShowDevDateTimeEditor)
                {
                    ShowDevDateTimeEditor(textbox, dateTime, formatString);
                }
                else
                {
                    ShowDateTimeSelector(textbox, dateTime, formatString);
                }
            }
            else
            {
                ShowSeletion(textbox);
            }

        }
        /// <summary>
        /// 列表下拉框
        /// </summary>
        /// <param name="textBox"></param>
        private void ShowSeletion(MTextBox textbox)
        {
            string whereCondition = textbox.DictWhereString;
            if (string.IsNullOrEmpty(textbox.DictWhereString) && textbox.DictTableName.ToUpper().Trim().Equals("WIS_OPER_ROOM"))
            {
                string bedType = "0";
                //if (Configurations.IsYouDaoProgram || Globals.SystemStatus == Globals.ProgramStatus.PACURecord)
                //{
                //    bedType = "1";
                //}
                whereCondition = "BED_TYPE = '" + bedType + "'";
            }
            DataRow[] rows = BuildPopupItemsData(textbox.DictTableName, whereCondition);
            string displayName = !string.IsNullOrEmpty(textbox.DisplayFieldName) ? textbox.DisplayFieldName.ToUpper() : textbox.DictValueFieldName.ToUpper();
            //Add by wenpei.x@2014-02-12
            //新增人员选择下拉框显示User_ID
            int selectionWith = textbox.Width;
            if (textbox.DictTableName.ToUpper().Trim().Equals("WIS_PERM_HIS_USER"))
            {
                displayName += ",USER_ID";
                selectionWith = textbox.Width * 2;
            }
            //end
            textbox.HasLookUpItems = rows.Length > 0;
            Dialog.ShowCustomSelection(rows, displayName, textbox,
               new System.Drawing.Size(selectionWith, 300), new EventHandler(delegate(object sender1, EventArgs e1)
               {
                   if (sender1 is int)
                   {
                       int result = (int)sender1;
                       if (result > -1)
                       {
                           if (textbox.MultiSelect)
                           {
                               if (textbox.Data == null || string.IsNullOrEmpty(textbox.Data.ToString().Trim()))
                               {
                                   textbox.SelectedData = rows[result][textbox.DictValueFieldName].ToString();
                                   //textbox.Data = rows[result][textbox.DictValueFieldName].ToString();
                               }
                               else
                               {
                                   textbox.SelectedData = textbox.Data.ToString() + "," + rows[result][textbox.DictValueFieldName].ToString();
                                   //textbox.Data = textbox.Data.ToString() + "," + rows[result][textbox.DictValueFieldName].ToString();
                               }
                               textbox.ProgramChanging = true;
                               if (string.IsNullOrEmpty(textbox.Text.Trim()))
                               {
                                   textbox.SelectedText = rows[result][textbox.DisplayFieldName].ToString();
                               }
                               else
                               {
                                   textbox.SelectedText = textbox.Text + "," + rows[result][textbox.DisplayFieldName].ToString();
                               }
                           }
                           else
                           {
                               textbox.SelectedData = rows[result][textbox.DictValueFieldName].ToString();
                               //textbox.Data = rows[result][textbox.DictValueFieldName].ToString();
                               textbox.ProgramChanging = true;
                               textbox.SelectedText = rows[result][textbox.DisplayFieldName].ToString();
                           }
                       }
                   }

               }));
        }
        /// <summary>
        ///显示下拉时间选择框
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="dateTime"></param>
        /// <param name="formatString"></param>
        private void ShowDateTimeSelector(MTextBox textbox, DateTime dateTime, string formatString)
        {
            Dialog.ShowDateTimeSelector(dateTime, textbox,
                 new EventHandler(delegate(object sender, EventArgs e)
                 {
                     if (sender is DateTime)
                     {
                         textbox.Data = (DateTime)sender;
                         textbox.SetText();
                     }
                 }), formatString);
        }

        private void ShowDevDateTimeEditor(MTextBox textbox, DateTime dateTime, string formatString)
        {
            string editFormatString = "d";
            if (formatString.Equals("yyyy-MM-dd"))
            {
                editFormatString = "d";
            }
            else if (formatString.Equals("yyyy年MM月dd日"))
            {
                formatString = "D";
                editFormatString = "d";
            }
            else if (formatString.Equals("yyyy-MM-dd HH:mm"))
            {
                editFormatString = "t";
            }
            else if (formatString.Equals("HH:mm"))
            {
                editFormatString = "t";
            }
            Dialog.ShowDevDateTimeEditor(dateTime, textbox, new System.Drawing.Rectangle(0, 0, textbox.Width, textbox.Height), new EventHandler(delegate(object sender, EventArgs e)
                {
                    if (sender != null && sender.ToString() != string.Empty)
                    {
                        textbox.Data = (DateTime)sender;
                        textbox.SetText();
                    }
                    else
                    {
                        textbox.Data = null;
                        textbox.Text = string.Empty;
                    }
                }), formatString, editFormatString);
        }
    }
}
