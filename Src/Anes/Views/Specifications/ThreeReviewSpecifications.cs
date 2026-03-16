using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Views;
using Wis.Anes.DataAccess;

namespace Wis.Anes.Views
{
    public partial class ThreeReviewSpecifications : BaseView
    {
        public ThreeReviewSpecifications()
        {
            InitializeComponent();
        }
        private DateTime startTime = DateTime.MinValue;
        private DateTime endTime = DateTime.MinValue;

        private void ThreeReviewSpecifications_Load(object sender, EventArgs e)
        {

            dateTimePickerEndTime.Value = DateTime.Now;
            dateTimePickerStartTime.Value = dateTimePickerEndTime.Value.AddMonths(-1);

            startTime = new DateTime(dateTimePickerStartTime.Value.Year, dateTimePickerStartTime.Value.Month, dateTimePickerStartTime.Value.Day, 0, 0, 0);
            endTime = new DateTime(dateTimePickerEndTime.Value.Year, dateTimePickerEndTime.Value.Month, dateTimePickerEndTime.Value.Day, 23, 59, 59); 

            Search();
            
           
        }

        private void Search()
        {

            ShowAnesthesiaMethod();
            ShowASAGrade();
            ShowThreeReview();
            ShowInPACUCount();
            ShowStewardScore4Count();
            ShowAnalyzeSpec("术前首次预防用抗菌药物时间");
            ShowAnalyzeSpec("术中是否追加");
        }

        private void ShowAnesthesiaMethod()
        {


           DataTable dt = (new StatisticsDA()).GetAnesthesiaMethod(startTime, endTime);

           dgvAnesMethod.DataSource = dt;
        }
        private void ShowASAGrade()
        {


            DataTable dt = (new StatisticsDA()).GetASAGrade(startTime, endTime);
            dgvASAGrade.DataSource = dt;
        }

        private void ShowAnalyzeSpec(string itemSpec)
        {
            DataTable dt = (new StatisticsDA()).GetAnalyzeSpec(startTime, endTime, "三甲指标_"+itemSpec);
            if (itemSpec == "术前首次预防用抗菌药物时间")
                dgvKangJunDrug.DataSource = dt;
            else if (itemSpec == "术中是否追加")
                dgvKangJunDrugAdded.DataSource = dt;
            
            
        }

        private void ShowInPACUCount()
        {
            txtInPACUCount.Text = "0";

            DataTable dt = (new StatisticsDA()).GetInPACUCount(startTime, endTime);
            if (dt != null && dt.Rows.Count > 0)
            {
                txtInPACUCount.Text = dt.Rows[0]["ITEM_COUNT"].ToString();
                return;
            }
        }

        private void ShowStewardScore4Count()
        {
            txtStewardScore.Text = "0";

            DataTable dt = (new StatisticsDA()).GetStewardScore4(startTime, endTime);
            if (dt != null && dt.Rows.Count > 0)
            {
                txtStewardScore.Text = dt.Rows[0]["ITEM_COUNT"].ToString();
                return;
            }

        }
        private void ShowAnesOtherEvent(DataTable dt)
        {
            dgvAnesOtherEvent.Rows.Clear();
            dgvAnesOtherEvent.RowCount = 7;
            dgvAnesOtherEvent.Rows[0].Cells[0].Value = "麻醉中发生未预期的意识障碍例数";
            dgvAnesOtherEvent.Rows[1].Cells[0].Value = "麻醉中出现氧饱和度重度降低例数";
            dgvAnesOtherEvent.Rows[2].Cells[0].Value = "全身麻醉结束时使用催醒药物例数";
            dgvAnesOtherEvent.Rows[3].Cells[0].Value = "麻醉中因误咽误吸引发呼吸道梗阻例数";
            dgvAnesOtherEvent.Rows[4].Cells[0].Value = "麻醉意外死亡例数";
            dgvAnesOtherEvent.Rows[5].Cells[0].Value = "其他非预期的相关事件例数";
            dgvAnesOtherEvent.Rows[6].Cells[0].Value = "合计";

            DataRow[] rows = dt.Select("ITEM_NAME LIKE '三甲指标_非预期事件_%'");
            if (rows == null)
                return;


            int count = 0;
            for (int i = 0; i < rows.Length; i++)
            {
                string itemName = rows[i]["ITEM_NAME"].ToString();
                itemName = itemName.Replace("三甲指标_非预期事件_", "");
                int value = int.Parse(rows[i]["ITEM_COUNT"].ToString() == "" ? "0" : rows[i]["ITEM_COUNT"].ToString());

                count += value;


                for (int j = 0; j < dgvAnesOtherEvent.Rows.Count; j++)
                {
                    if (dgvAnesOtherEvent.Rows[j].Cells[0].Value.ToString().Contains(itemName))
                    {
                        dgvAnesOtherEvent.Rows[j].Cells[1].Value = value;
                        break;
                    }
                }

                
            }

            dgvAnesOtherEvent.Rows[6].Cells[1].Value = count ;
        }

        private void ShowThreeReview()
        {

            DataTable dt = (new StatisticsDA()).GetThreeReview(startTime, endTime);
            ShowAnesOtherEvent(dt);

            txtShuHouZhenTong.Text = "0";
            txtXinFeiFuSu.Text = "0";
            txtXinFeiFuSuSuccess.Text = "0";

            DataRow[] rows = null ;

            rows =  dt.Select("ITEM_NAME = '三甲指标_术后镇痛'");
            if (rows != null && rows.Length >=1 )
                txtShuHouZhenTong.Text = rows[0]["ITEM_COUNT"].ToString() ;

            rows =  dt.Select("ITEM_NAME = '三甲指标_心肺复苏'");
            if (rows != null && rows.Length >=1 )
                txtXinFeiFuSu.Text = rows[0]["ITEM_COUNT"].ToString() ;

            rows = dt.Select("ITEM_NAME = '三甲指标_复苏成功'");
            if (rows != null && rows.Length >= 1)
                txtXinFeiFuSuSuccess.Text = rows[0]["ITEM_COUNT"].ToString();



        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            startTime = new DateTime(dateTimePickerStartTime.Value.Year, dateTimePickerStartTime.Value.Month, dateTimePickerStartTime.Value.Day, 0, 0, 0);
            endTime = new DateTime(dateTimePickerEndTime.Value.Year, dateTimePickerEndTime.Value.Month, dateTimePickerEndTime.Value.Day, 23, 59, 59); 
            Search();
        }
    }
}
