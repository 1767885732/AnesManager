/*----------------------------------------------------------------
      // Copyright (C) 2008 北京拓扑工厂科技发展有限公司
      // 文件名：DataHelper.cs
      // 文件功能描述：应用层数据辅助类
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Wis.Anes.Framework.Utilities;
using Wis.Anes.Framework.Controls;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Data;
using System.Drawing.Printing;
using System.Reflection;
using Wis.Anes.Framework.Controls.Base;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework;

namespace Wis.Anes.ServiceProxies
{
    /// <summary>
    /// 应用层数据辅助类
    /// </summary>
    public partial class SystemHelper
    {
        public static DataTable ListToTable(IList list, Type type, string tableName)
        {
            DataTable dataTable = new DataTable();
            dataTable.TableName = tableName;
            List<MemberDetail> memberDetails = AssemblyHelper.GetPropertyList(type, true);
            foreach (MemberDetail memberDetail in memberDetails)
            {
                dataTable.Columns.Add(memberDetail.Name);
            }
            foreach (object obj in list)
            {
                DataRow row = dataTable.NewRow();
                foreach (MemberDetail memberDetail in memberDetails)
                {
                    PropertyInfo propertyInfo = memberDetail.PropertyInfo;
                    row[memberDetail.Name] = AssemblyHelper.GetPropertyValue(propertyInfo, obj);
                }
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }

        public static void ListFromTable(IList list,Type type,DataTable dataTable)
        {
            if (dataTable != null)
            {
                List<MemberDetail> memberDetails = AssemblyHelper.GetPropertyList(type);
                foreach (DataRow row in dataTable.Rows)
                {
                    object obj = Activator.CreateInstance(type);
                    foreach (MemberDetail memberDetail in memberDetails)
                    {
                        PropertyInfo propertyInfo = memberDetail.PropertyInfo;
                        if (dataTable.Columns.Contains(memberDetail.Name) && row[memberDetail.Name] != System.DBNull.Value)
                        {
                            try
                            {
                                AssemblyHelper.SetPropertyValue(propertyInfo, obj, row[memberDetail.Name].ToString());
                            }
                            catch (Exception ex)
                            {
                                Dialog.MessageBox(ex.Message, MessageBoxIcon.Information);
                            }
                        }
                    }
                    list.Add(obj);
                }
            }
        }

        public static void AdjustDateTimeRange(TimeScaleType timeScaleType,ref DateTimeRange dateTimeRange)
        {
            if (timeScaleType != TimeScaleType.None)
            {
                switch (timeScaleType)
                {
                    case TimeScaleType.FiveMinute:
                        ModMinute(ref dateTimeRange.StartDateTime, 5);
                        break;
                    case TimeScaleType.Quarter:
                        ModMinute(ref dateTimeRange.StartDateTime, 15);
                        break;
                    case TimeScaleType.HaveHour:
                        ModMinute(ref dateTimeRange.StartDateTime, 30);
                        break;
                }
            }
        }

        public static void ModMinute(ref DateTime dateTime, int modNumber)
        {
            dateTime = dateTime.AddMinutes(-dateTime.Minute % modNumber);
        }

        /// <summary>
        /// 生成动态列
        /// </summary>
        /// <param name="title"></param>
        /// <param name="fieldName"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public static DataGridViewColumn GenerateColumn(string title, string fieldName, int width)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.HeaderText = title;
            column.DataPropertyName = fieldName;
            column.Name = fieldName;
            column.Width = width;
            return column;
        }
        /// <summary>
        /// 生成动态列
        /// </summary>
        /// <param name="title"></param>
        /// <param name="fieldName"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public static DataGridViewColumn GenerateColumn(string title, string fieldName, int width, bool read)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = title;
            column.DataPropertyName = fieldName;
            column.Name = fieldName;
            column.Width = width;
            column.ReadOnly = read;
            return column;
        }
        /// <summary>
        /// 生成动态列
        /// </summary>
        /// <param name="title"></param>
        /// <param name="fieldName"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public static DataGridViewColumn GenerateColumn(string title, string fieldName, int width, bool read, bool visible)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = title;
            column.DataPropertyName = fieldName;
            column.Name = fieldName;
            column.Width = width;
            column.ReadOnly = read;
            column.Visible = visible;
            return column;
        }
        /// <summary>
        /// 生成动态列
        /// </summary>
        /// <param name="title"></param>
        /// <param name="fieldName"></param>
        /// <param name="width"></param>
        /// <param name="listItems"></param>
        /// <returns></returns>
        public static DataGridViewColumn GenerateColumn(string title, string fieldName, int width, string[] listItems)
        {
            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
            foreach (string itemValue in listItems)
            {
                column.Items.Add(itemValue);
            }
            column.HeaderText = title;
            column.DataPropertyName = fieldName;
            column.Width = width;
            column.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            return column;
        }

        public static byte[] GetBytes(int number)
        {
            byte[] buffer = new byte[sizeof(int)];
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = (byte)(number >> (i * 8));
            }
            return buffer;
        }

        public static void DrawString(Graphics g, string text, int height)
        {
            Font font = new Font("宋体", 10, FontStyle.Bold);
            g.DrawString(text, font, Brushes.White, 3, (height - g.MeasureString("A", font).Height) / 2 - 1);
            g.DrawString(text, font, Brushes.Black, 2, (height - g.MeasureString("A", font).Height) / 2);
        }

        /// <summary>
        /// 调整时间的日期为指定日期，并保证不小于该日期（小于时日期加1）
        /// </summary>
        /// <param name="theDate">指定日期</param>
        /// <param name="sourceDateTime">要调整的日期</param>
        /// <returns>调整后的日期</returns>
        public static DateTime PraseDate(DateTime theDate, DateTime sourceDateTime)
        {
            DateTime date = new DateTime(theDate.Year, theDate.Month, theDate.Day, sourceDateTime.Hour, sourceDateTime.Minute,0);
            DateTime date1 = new DateTime(theDate.Year, theDate.Month, theDate.Day, theDate.Hour, theDate.Minute,0);
            if (date < date1) date = date.AddDays(1);
            return date;
        }

        public static void InformationChanged(PatientInformation patientInformation)
        {
            if (patientInformation != null)
            {
                ExtendApplicationContext.Current.PatientContext.PatientID = patientInformation.PatientID;
                ExtendApplicationContext.Current.PatientContext.VisitID = patientInformation.VisitID;
                ExtendApplicationContext.Current.PatientContext.OperID = patientInformation.OperID;
            }
            else
            {
                ExtendApplicationContext.Current.PatientContext.PatientID = null;
            }
            if (patientInformation != null && ExtendApplicationContext.Current.PatientInformation != null && ExtendApplicationContext.Current.PatientInformation.Equals(patientInformation)) return;
            ExtendApplicationContext.Current.PatientInformation = patientInformation;
        }

    }
}
