using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.Framework;
using Wis.Anes.Framework.Utilities;
using System.Data;
using DevExpress.XtraEditors.Repository;

namespace Wis.Anes.Framework.Controls
{
    public class DictTextBox : Wis.Anes.Framework.Controls.MedTextBox
    {
        public DictTextBox()
        {
            if (Wis.Anes.Framework.Configurations.ApplicationConfiguration.DoubleSelect)
            {
                DoubleClick += new EventHandler(DictTextBox_DoubleClick);
            }
            else
            {
                Click += new EventHandler(DictTextBox_Click);
            }
        }

        private void DictTextBox_Click(object sender, EventArgs e)
        {
            ShowSeletion(this);
        }

        private void DictTextBox_DoubleClick(object sender, EventArgs e)
        {
            ShowSeletion(this);
        }

        /// <summary>
        /// 列表下拉框
        /// </summary>
        /// <param name="textBox"></param>
        private void ShowSeletion(Wis.Anes.Framework.Controls.MedTextBox textbox)
        {
            if (string.IsNullOrEmpty(textbox.DictTableName) || !ExtendApplicationContext.Current.CodeTables.ContainsKey(textbox.DictTableName))
            {
                return;
            }
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
            else if (!string.IsNullOrEmpty(textbox.DictWhereString) && textbox.DictTableName.ToUpper().Trim().Equals("WIS_PERM_HIS_USER".ToUpper()))
            {
                if (textbox.DictWhereString.Contains("AppDefinedDeptCode"))
                {
                    string deptCode = Wis.Anes.Framework.Configurations.ApplicationConfiguration.AnesthesiaWardCode;
                    if (string.IsNullOrEmpty(deptCode))
                    {
                        deptCode = "";
                    }
                    whereCondition  = textbox.DictWhereString.Replace("AppDefinedDeptCode", deptCode);
                }
            
            }


            DataRow[] rows = ExtendApplicationContext.Current.CodeTables[textbox.DictTableName].Select(whereCondition);

            string displayName = !string.IsNullOrEmpty(textbox.DisplayFieldName) ? textbox.DisplayFieldName : textbox.DictValueFieldName;

            if (!string.IsNullOrEmpty(textbox.DisplayMutiColFieldName))
            {
                displayName = textbox.DisplayMutiColFieldName;
            }
            textbox.HasLookUpItems = rows.Length > 0;
            Dialog.ShowCustomSelection(rows, displayName, textbox,
               new System.Drawing.Size(textbox.Width, 300), new EventHandler(delegate(object sender1, EventArgs e1)
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
                                   textbox.Data = rows[result][textbox.DictValueFieldName].ToString();
                               }
                               else
                               {
                                   textbox.Data = textbox.Data.ToString() + "," + rows[result][textbox.DictValueFieldName].ToString();
                               }
                               textbox.ProgramChanging = true;
                               if (string.IsNullOrEmpty(textbox.Text.Trim()))
                               {
                                   textbox.Text = rows[result][textbox.DisplayFieldName].ToString();
                               }
                               else
                               {
                                   textbox.Text = textbox.Text + "," + rows[result][textbox.DisplayFieldName].ToString();
                               }
                           }
                           else
                           {
                               textbox.Data = rows[result][textbox.DictValueFieldName].ToString();
                               textbox.ProgramChanging = true;
                               textbox.Text = rows[result][textbox.DisplayFieldName].ToString();
                           }
                       }
                   }

               }));
        }
    }
}
