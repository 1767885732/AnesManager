using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Score;
using Wis.Anes.Framework.Controls;

namespace Score.Common.Controls
{
    public partial class Goldman : BaseControl
    {
     
        #region  构造方法
     
        public Goldman() : this("",-1,-1) { }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="patientRow">病人信息</param>
        //public Goldman(DataSetModel.Patient.PatientRow patientRow) : this(patientRow, "GOLDMAN心脏高危因素评分") { }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="patientRow">病人信息</param>
        /// <param name="title">模块标题</param>
        //public Goldman(DataSetModel.Patient.PatientRow patientRow, string title)
        //    : base(patientRow, title)
        //{
        //    InitializeComponent();
        //}
        public Goldman(string patientID, decimal visitID, decimal deptID)
            : base(patientID, visitID, deptID, "GOLDMAN心脏高危因素评分") 
        {
            InitializeComponent();
            //dateTimePicker1.DateTime = DateTime.Now.Date.AddDays(-1);
            //if (!string.IsNullOrEmpty(_patientID))
            //{
            //    RefreshAll();
            //}
        }
        #endregion
        #region 私有变量
        /// <summary>
        /// 评分数据表
        /// </summary>
        private Wis.Anes.BusinessEntity.Score.PatientScoringResultDataTable patientScore;
        private Wis.Anes.BusinessEntity.Score.MED_GOLDMAN_SCORING_RESULTDataTable goldmanDataTable;
        private Wis.Anes.BusinessEntity.Score.MED_GOLDMAN_SCORING_RESULTDataTable goldmanTable;
        int s1=0;
        int s2=0;
        int s3=0;
        int s4=0;
        int s5=0;
        int s6=0;
        int s7=0;
        int s8=0;
        int s9=0;
        DateTime scoreDateTime;
       #endregion
        #region 方法
        /// <summary>
        /// 绑定数据到表格
        /// </summary>
        private void bindToDataGrid()
        {
            if (string.IsNullOrEmpty(_patientID))
                return;
            goldmanTable = DataOperator.GetDataGoldman(_patientID,_visitID,_deptID);

            patientScore = DataOperator.GetPatientScoringResultDt(_patientID, _visitID, _deptID, "goldman");
            dgvGoldman.AutoGenerateColumns = false;
            dgvGoldman.DataSource = patientScore;
            dgvGoldman.Columns[0].DataPropertyName = patientScore.Columns["SCORING_DATE_TIME"].ColumnName;
            dgvGoldman.Columns[1].DataPropertyName = patientScore.Columns["SCORING_VALUE"].ColumnName;
            dgvGoldman.Columns[2].DataPropertyName = patientScore.Columns["DEGREE"].ColumnName;
            dgvGoldman.Columns[3].DataPropertyName = patientScore.Columns["DEATH_PROBABILITY"].ColumnName;
            dgvGoldman.Columns[4].DataPropertyName = patientScore.Columns["PAT_CONDITION"].ColumnName;
            dgvGoldman.Columns[5].DataPropertyName = patientScore.Columns["OPERATOR"].ColumnName;
            Clear();
        }
        /// <summary>
        /// 设置曲线参数
        /// </summary>

        private void SetGraphParameters()
        {
            ///Y坐标轴
            myGraph1.MainPanel.YAxisList.Add(new MedAxis(this.Font, Brushes.Black, 100, 0, 20));
            myGraph1.MainPanel.YAxisList.MinSetp = 1;
            myGraph1.MainPanel.YAxisList.Pen.Color = Color.Black;

            ///X坐标轴
            MedAxis axis = new MedAxis(this.Font, Brushes.Black, 10, 1, 1f);
            myGraph1.MainPanel.XAxisList.Add(axis);
            myGraph1.MainPanel.XAxisList.MinSetp = 1;
            myGraph1.MainPanel.XAxisList.Pen.Color = Color.Black;

            ///其他属性
            myGraph1.MainPanel.LeftMargin = 10;
            myGraph1.MainPanel.BottomMargin = 20;
            myGraph1.MainPanel.RectBorderPen = Pens.Gray;

            myGraph1.MainPanel.HasAxisGridLine = false;
            myGraph1.MainPanel.XAxisTitleAtTop = false;
        }

        /// <summary>
        /// 刷新图表
        /// </summary>
        private void RefreshGraph()
        {
            myGraph1.MainPanel.CurveList.Clear();
            MedPointList points = new MedPointList();
            if (patientScore != null)
            {
                foreach (Wis.Anes.BusinessEntity.Score.PatientScoringResultRow row in patientScore)
                {
                    if (row.RowState != DataRowState.Deleted)
                        points.Add(points.Count + 1, (double)row.SCORING_VALUE);
                }
                myGraph1.MainPanel.CurveList.Add(new MedCurve(points));
            }
            myGraph1.Invalidate();
        }
        /// <summary>
        /// 计算分值
        /// </summary>
        /// <returns></returns>
        /// <summary>
        public int computeScore()
        {
            int score = 0;
            int lever=0;
            double deathRate=0;
         
            if(ckxs1_10.Checked)
            {
                score += 10;
                s1 = 10;
            }
            if(ckxs2_5.Checked)
            {
                score += 5;
                s2 = 5;
            }
            if(ckxs3_11.Checked)
            {
                score += 11;
                s3 = 11;
            }
            if(ckxs4_3.Checked)
            {
                score += 3;
                s4 = 3;
            }
            if(ckxs5_7.Checked)
            {
                score += 7;
                s5 = 7;
            }
            if(ckxs6_7.Checked)
            {
                score += 7;
                s6 = 7;
            }
            if(ckxs7_3.Checked)
            {
                score += 3;
                s7 = 3;
            }
            if(ckxs8_3.Checked)
            {
                score += 3;
                s8 = 3;
            }
            if(ckxs9_3.Checked)
            {
                score += 3;
                s9 = 3;
            }
            if(score>=0 && score<=5)
            {
                lever = 1;
                deathRate = 0.2;
            }
            else if(score >=6 && score<=12)
            {
                lever = 2;
                deathRate = 2;
            }
            else if(score>=13 && score<=25)
            {
                lever = 3;
                deathRate = 2;
            }
            else if(score>=26)
            {
                lever = 4;
                deathRate = 56;
            }
            txtDeathRate.Text = deathRate.ToString();
            txtLever.Text = lever.ToString();
            txtScore.Text = score.ToString();
            return score;
        }
        /// <summary>
        /// 保存评分结果
        /// </summary>
        /// <returns></returns>
        private int saveScoreResult()
        {
            if (txtScore.Text == "")
            {
                return -1;
            }
            string operatorNurse = DataOperator.OperatorNurse;
            if (operatorNurse == null)
            {
                return -1;
            }
            Wis.Anes.BusinessEntity.Score.PatientScoringResultRow addRow = (Wis.Anes.BusinessEntity.Score.PatientScoringResultRow)patientScore.NewRow();
            addRow.PAT_ID = _patientID;
            addRow.VISIT_ID = _visitID;
            addRow.DEP_ID = _deptID;
            addRow.SCORING_DATE_TIME = scoreDateTime;
            addRow.SCORING_METHOD = "goldman";
            addRow.SCORING_VALUE = decimal.Parse(txtScore.Text);
            addRow.DEGREE = txtLever.Text;
            addRow.DEATH_PROBABILITY = Decimal.Parse(txtDeathRate.Text)/100;
            addRow.PAT_CONDITION= txtMemo.Text;
            addRow.OPERATOR = operatorNurse;
            patientScore.AddPatientScoringResultRow(addRow);
            if (DataOperator.UpdatePatientScoringResult(patientScore) >= 0)
            {
                return 1;
            }                   
            else
            {
                Wis.Anes.Framework.Utilities.Dialog.MessageBox("保存失败！");
                return -1;
            }
        }

        /// 保存评分明细选项
        /// </summary>
        /// <returns></returns>
        private int saveDetail()
        {
            if (txtScore.Text == "")
            {
                Wis.Anes.Framework.Utilities.Dialog.MessageBox("请先评分，再保存！");
                return -1;
            }
            if (ckxs1_10.Checked)
            {
                s1 = 10;
            }
            if (ckxs2_5.Checked)
            {
                s2 = 5;
            }
            if (ckxs3_11.Checked)
            {
                s3 = 11;
            }
            if (ckxs4_3.Checked)
            {
                s4 = 3;
            }
            if (ckxs5_7.Checked)
            {
                s5 = 7;
            }
            if (ckxs6_7.Checked)
            {
                s6 = 7;
            }
            if (ckxs7_3.Checked)
            {
                s7 = 3;
            }
            if (ckxs8_3.Checked)
            {
                s8 = 3;
            }
            if (ckxs9_3.Checked)
            {
                s9 = 3;
            }
            goldmanDataTable = new Wis.Anes.BusinessEntity.Score.MED_GOLDMAN_SCORING_RESULTDataTable();
            Wis.Anes.BusinessEntity.Score.MED_GOLDMAN_SCORING_RESULTRow row = goldmanDataTable.NewMED_GOLDMAN_SCORING_RESULTRow();
            row.PAT_ID = _patientID;
            row.VISIT_ID = _visitID;
            //row.DEP_ID = _deptID;
            scoreDateTime = DataOperator.GetSysDate();
            row.SCORING_DATE_TIME = scoreDateTime;
            row.S1 = s1;
            //row.S2 = s2;
            row.S3 = s3;
            row.S4 =s4;
            row.S5 = s5;
            row.S6 = s6;
            row.S7 =s7;
            row.S8 = s8;
            row.S9 = s9;
            row.MEMO = this.txtMemo.Text;
            goldmanDataTable.Rows.Add(row);
            return DataOperator.UpdateGoldman(goldmanDataTable);
        }
        private void Clear() 
        {
            ckxs1_10.Checked = false;
            ckxs2_5.Checked = false;
            ckxs3_11.Checked = false;
            ckxs4_3.Checked = false;
            ckxs5_7.Checked = false;
            ckxs6_7.Checked = false;
            ckxs7_3.Checked = false;
            ckxs8_3.Checked = false;
            ckxs9_3.Checked = false;
            txtDeathRate.Text = "";
            txtLever.Text = "";
            txtMemo.Text = "";
            txtScore.Text = "";
        }
        private Boolean getIndex(int value)
        {
            Boolean choose =false;
            if (value != 0)
            {
                choose = true;
            }
            return choose;
        }
        /// <summary>
        /// 显示内容
        /// </summary>
        /// <param name="deTable"></param>
        private void pushValue(Wis.Anes.BusinessEntity.Score.MED_GOLDMAN_SCORING_RESULTDataTable goldman_DataTable)
        {
            ckxs1_10.Checked = getIndex(int.Parse(goldman_DataTable.Rows[0]["S1"].ToString().Trim()));
            ckxs2_5.Checked = getIndex(int.Parse(goldman_DataTable.Rows[0]["S2"].ToString().Trim()));
            ckxs3_11.Checked = getIndex(int.Parse(goldman_DataTable.Rows[0]["S3"].ToString().Trim()));
            ckxs4_3.Checked = getIndex(int.Parse(goldman_DataTable.Rows[0]["S4"].ToString().Trim()));
            ckxs5_7.Checked = getIndex(int.Parse(goldman_DataTable.Rows[0]["S5"].ToString().Trim()));
            ckxs6_7.Checked = getIndex(int.Parse(goldman_DataTable.Rows[0]["S6"].ToString().Trim()));
            ckxs7_3.Checked = getIndex(int.Parse(goldman_DataTable.Rows[0]["S7"].ToString().Trim()));
            ckxs8_3.Checked = getIndex(int.Parse(goldman_DataTable.Rows[0]["S8"].ToString().Trim()));
            ckxs9_3.Checked = getIndex(int.Parse(goldman_DataTable.Rows[0]["S9"].ToString().Trim()));
            txtScore.Text = dgvGoldman.SelectedRows[0].Cells["SCORING_VALUE"].Value.ToString();
            txtLever.Text = dgvGoldman.SelectedRows[0].Cells["DEGREE"].Value.ToString();
            txtDeathRate.Text = dgvGoldman.SelectedRows[0].Cells["DEATH_PROBABILITY"].Value.ToString(); 
            txtMemo.Text = goldman_DataTable.Rows[0]["memo"].ToString();
        }
        /// <summary>
        /// 获取dataGirdView选中行索引
        /// </summary>
        /// <returns></returns>
        private int findMainTableIndex()
        {
            int deleteBeforeSelect = 0, exsitRow = 0, index;
            for (int i = 0; i < patientScore.Rows.Count; i++)
            {
                if (patientScore.Rows[i].RowState == DataRowState.Deleted)
                    deleteBeforeSelect++;
                else
                    exsitRow++;
                if (exsitRow >= dgvGoldman.SelectedRows[0].Index + 1)
                    break;
            }
            for (index = dgvGoldman.SelectedRows[0].Index + deleteBeforeSelect; index < patientScore.Rows.Count; index++)
            {
                if (patientScore.Rows[index].RowState == DataRowState.Deleted)
                    continue;
                else
                {
                    break;
                }
            }
            return index;
        }

        private int quaryIndex()
        {
            for (int rowNo = 0; rowNo < goldmanTable.Rows.Count; rowNo++)
            {
                if (goldmanTable.Rows[rowNo].RowState != DataRowState.Deleted)
                {
                    if (goldmanTable.Rows[rowNo]["SCORING_DATE_TIME"].ToString() == patientScore.Rows[findMainTableIndex()]["SCORING_DATE_TIME"].ToString())
                        return rowNo;
                }
            }
            return -1;
        }
        #endregion
        #region 事件
        private void Goldman_Load(object sender, EventArgs e)
        {
            bindToDataGrid();
            SetGraphParameters();
            Clear();
        }
        /// <summary>
        /// 评分按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScore_Click(object sender, EventArgs e)
        {
            computeScore();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveDetail() > 0 && saveScoreResult() > 0)
            {
                RefreshGraph();
                Wis.Anes.Framework.Utilities.Dialog.MessageBox("保存成功");
                bindToDataGrid();
                Clear();
            }
        }
        /// <summary>
        /// 清空按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void dgvGoldman_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            goldmanDataTable = DataOperator.GetGoldman(_patientID, _visitID, _deptID,
                  (DateTime)dgvGoldman.Rows[e.RowIndex].Cells[0].Value);      
            pushValue(goldmanDataTable);
        }
       
/// <summary>
/// 删除按钮
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void btn_dele_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvGoldman.Rows.Count > 0 && dgvGoldman.SelectedRows != null)
                {
                    goldmanTable.Rows[quaryIndex()].Delete();
                    patientScore.Rows[findMainTableIndex()].Delete();
                    RefreshGraph();
                    Clear();
                    if (dgvGoldman.Rows.Count > 0)
                    {
                        dgvGoldman.Rows[0].Selected = true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void btnSaveScore_Click(object sender, EventArgs e)
        {
            if (DataOperator.UpdatePatientScoringResult(patientScore) >= 0 && DataOperator.UpdateGoldman(goldmanTable) >= 0)
            {
                RefreshGraph();
                bindToDataGrid();
                Wis.Anes.Framework.Utilities.Dialog.MessageBox("保存成功！");
            }
            else
            {
                Wis.Anes.Framework.Utilities.Dialog.MessageBox("保存失败！");
            }
        }
        #endregion
    }
}
