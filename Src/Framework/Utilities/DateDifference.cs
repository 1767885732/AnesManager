using System;
using System.Collections.Generic;
using System.Text;

namespace Wis.Anes.Framework.Utilities
{

    public class DateDiff
    {

        private static DateDifference dateDifference = null;
        public static string CalAge(DateTime fromDate, DateTime toDate)
        {
            if (dateDifference == null)
            {
                dateDifference = new DateDifference();
            }
            //计算年龄
            dateDifference.CalAge(fromDate, toDate);

            //大于7岁显示年
            if (dateDifference.Years > 7)
            {
                return dateDifference.Years + "岁";
            }

            //大于1岁小于7岁显示岁和月
            if (dateDifference.Years >= 1)
            {

                return dateDifference.Years + "岁" + dateDifference.Months + "月";

            }
            else//小于1岁显示月和天
            {
                return dateDifference.Months + "月" + dateDifference.Days + "天";
            }
        }

    }
    internal class DateDifference
    {
        /// <summary>
        /// 定义天数
        /// 二月在计算中会重定义，用-1先定义
        /// </summary>
        private int[] monthDay = new int[12] { 31, -1, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };


        private DateTime fromDate;


        private DateTime toDate;


        private int year;
        private int month;
        private int day;


        public void CalAge(DateTime d1, DateTime d2)
        {

            int increment;

            if (d1 > d2)
            {
                this.fromDate = d2;
                this.toDate = d1;
            }
            else
            {
                this.fromDate = d1;
                this.toDate = d2;
            }

            /// 
            /// 计算日
            /// 
            increment = 0;

            if (this.fromDate.Day > this.toDate.Day)
            {
                increment = this.monthDay[this.fromDate.Month - 1];

            }
            /// 二月
            if (increment == -1)
            {
                if (DateTime.IsLeapYear(this.fromDate.Year))
                {
                    // 闰月
                    increment = 29;
                }
                else
                {
                    increment = 28;
                }
            }
            if (increment != 0)
            {
                day = (this.toDate.Day + increment) - this.fromDate.Day;
                increment = 1;
            }
            else
            {
                day = this.toDate.Day - this.fromDate.Day;
            }

            ///
            ///计算月
            ///
            if ((this.fromDate.Month + increment) > this.toDate.Month)
            {
                this.month = (this.toDate.Month + 12) - (this.fromDate.Month + increment);
                increment = 1;
            }
            else
            {
                this.month = (this.toDate.Month) - (this.fromDate.Month + increment);
                increment = 0;
            }

            ///
            /// year calculation
            ///
            this.year = this.toDate.Year - (this.fromDate.Year + increment);
        }

        public override string ToString()
        {
            //return base.ToString();
            return this.year + " 年, " + this.month + "月, " + this.day + " 天";
        }

        public int Years
        {
            get
            {
                return this.year;
            }
        }

        public int Months
        {
            get
            {
                return this.month;
            }
        }

        public int Days
        {
            get
            {
                return this.day;
            }
        }

    }
}