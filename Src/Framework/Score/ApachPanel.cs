/*----------------------------------------------------------------
// Copyright (C) 2005 北京拓扑工厂科技发展有限公司
// 文件名：
// 文件功能描述：Glasgow昏迷评分
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.BusinessEntity;
using Wis.Anes.DataAccess;
using Wis.Anes.Framework.Controls;
using Wis.Anes.Framework.Utilities;

namespace Wis.Anes.Framework.ScoreControls
{
    [ToolboxItem(false)]
    public partial class ApachPanel : UserControl
    {
        #region 构造方法

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="patientRow">病人信息</param>
        public ApachPanel() : this("APACHE Ⅱ评分") { }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="patientRow">病人信息</param>
        /// <param name="title">模块标题</param>
        public ApachPanel(string title)
        {
            _title = title;
            InitializeComponent();
        }

        #endregion 构造方法

        #region 变量

        private string _patientID,_title;
        private decimal _visitID, _operID;
        /// <summary>
        /// 评分数据表
        /// </summary>
        private Score.PatientScoringResultDataTable appcheScore;

        /// <summary>
        /// 评分时间
        /// </summary>
        private DateTime scoreDateTime = new CommonDA().GetSysDateTime();

        /// <summary>
        /// Nort数据表
        /// </summary>
        private Score.WIS_SCORE_APA_RESULTDataTable GlasgowTable;

        private Score.WIS_SCORE_APA_RESULTDataTable gcsTable;

        /// <summary>
        /// 评分 总分数
        /// </summary>
        private int scornum;
        /// <summary>
        /// 评分的单独分值
        /// </summary>
        //private int eyes_reflect = -1;
        /// <summary>
        /// 评分的单独分值
        /// </summary>
        //private int talk_reflect = -1;
        /// <summary>
        /// 评分的单独分值
        /// </summary>
        //private int limb_reflect = -1;
        /// <summary>
        /// 评分单独值
        /// </summary>
        string[] numscor = new string[25];

        #endregion

        #region 方法
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
            if (appcheScore != null)
            {
                foreach (Score.PatientScoringResultRow row in appcheScore)
                {
                    if (row.RowState != DataRowState.Deleted)
                        points.Add(points.Count + 1, (double)row.SCORING_VALUE);
                }
                myGraph1.MainPanel.CurveList.Add(new MedCurve(points));
            }
            myGraph1.Invalidate();
        }
        /// <summary>
        /// 绑定数据到表格
        /// </summary>
        private void bindToDataGrid()
        {
            if (string.IsNullOrEmpty(_patientID))
            {
                return;
            }
            gcsTable = new ScoreDA().GetAPAInfo(_patientID, _visitID,_operID);
            appcheScore = new ScoreDA().GetPatientScoringResultDt(_patientID, _visitID,_operID, "Apache Ⅱ");
            dgvApache.AutoGenerateColumns = false;
            dgvApache.DataSource = appcheScore;
            dgvApache.Columns[0].DataPropertyName = appcheScore.Columns["SCORING_DATE_TIME"].ColumnName;
            dgvApache.Columns[1].DataPropertyName = appcheScore.Columns["SCORING_VALUE"].ColumnName;
            dgvApache.Columns[2].DataPropertyName = appcheScore.Columns["DEGREE"].ColumnName;
            dgvApache.Columns[3].DataPropertyName = appcheScore.Columns["DEATH_PROBABILITY"].ColumnName;
            dgvApache.Columns[4].DataPropertyName = appcheScore.Columns["PAT_CONDITION"].ColumnName;
            dgvApache.Columns[5].DataPropertyName = appcheScore.Columns["OPERATOR"].ColumnName;
        }

        ///// <summary>
        ///// 刷新数据
        ///// </summary>
        //protected override void RefreshAll()
        //{
        //    //SetGraphParameters();
        //    bindToDataGrid();
        //    RefreshGraph();
        //}


        /// <summary>
        /// 计算评分分值
        /// </summary>
        /// <returns></returns>
        private int GlasgowScore()
        {
            int num = 0;

            numscor = new string[25];
            foreach (object obj in panel1.Controls)
            {
                if (obj is GroupBox)
                {
                    GroupBox gb = (GroupBox) obj;
                    //只循环groupBox2 - groupBox14
                    if (gb.Name != "groupBox1" && gb.Name != "groupBox16"
                        && gb.Name != "groupBox17" && gb.Name != "groupBox18" && gb.Name != "groupBox19" && gb.Name != "groupBox20")
                    {
                        foreach (RadioButton cb in gb.Controls)
                        {
                            if (cb.Checked)
                            {
                                if (cb.Text != "")
                                {
                                    //groupBox的名字 取数字部分    Checkbox去文本的分数 放入相应的数字中
                                    numscor[Convert.ToInt32(gb.Name.Substring(8))] += "*"+ Convert.ToInt32(cb.Text.Substring(0, 1));
                                    num += Convert.ToInt32(cb.Text.Substring(0, 1));
                                }

                            }
                        }
                    }
                    else if(gb.Name != "groupBox1")
                    {
                        foreach (RadioButton rb in gb.Controls)
                        {
                            if (rb.Checked)
                            {
                                if (rb.Text != "")
                                {
                                    //groupBox的名字 取数字部分    Checkbox去文本的分数 放入相应的数字中
                                    numscor[Convert.ToInt32(gb.Name.Substring(8))] += "*" + Convert.ToInt32(rb.Text.Substring(0, 1));
                                    num += Convert.ToInt32(rb.Text.Substring(0, 1));
                                }

                            }
                        }
                    }
                }
            }

            return num;
        }

        /// <summary>
        /// 保存Crams明细
        /// </summary>
        /// <returns></returns>
        private int SaveCramsScore()
        {
            if (txtScore.Text == "")
            {
                Dialog.MessageBox("请先评分，再保存！");
                return -1;
            }
            GlasgowTable = new Score.WIS_SCORE_APA_RESULTDataTable();
            Score.WIS_SCORE_APA_RESULTRow row = GlasgowTable.NewWIS_SCORE_APA_RESULTRow();
            row.PAT_ID = _patientID;
            row.VISIT_ID = _visitID;
            row.SCORING_DATE_TIME = dtpTime.Value;
            row.RECTAL_TEMP = numscor[2];
            row.MEAN_ARTERIAL_P = numscor[3];
            row.HEART_RATE = numscor[4];
            row.RESPIRATORY = numscor[5];
            row.OXYGENATION = numscor[6];
            row.ARTERIAL_BLOOD = numscor[7];
            row.SERUM_SODIUM = numscor[8];
            row.SERUM_POTAS = numscor[9];
            row.SERUM_CREATININE = numscor[10];
            row.BLOOD_CELLSTH = numscor[11];
            row.BLOOD_CELLCO = numscor[12];
            row.GLASGOW = numscor[13];
            row.HCO3 = numscor[14];
            row.AGEFACTOR_SCORE = numscor[15];
            row.CHRONIC_LIVER = numscor[16];
            row.CHRONIC_CARD = numscor[17];
            row.CHRONIC_RESP = numscor[18];
            row.CHRONIC_RENAL = numscor[19];
            row.CHRONIC_IMMUNE = numscor[20];
            row.MEMO = this.tex_DescriptionIllness.Text.Trim();

            GlasgowTable.Rows.Add(row);
            return new ScoreDA().UpdateAPA(GlasgowTable);
        }

        /// <summary>
        /// 保存评分结果
        /// </summary>
        /// <returns></returns>
        private int saveScoreResult()
        {
            if ( txtScore.Text == "")
            {
                return -1;
            }
            string operatorNurse = ExtendApplicationContext.Current.LoginUserContext.UserName;
            if (operatorNurse == null)
            {
                return -1;
            }
            Score.PatientScoringResultRow addRow = (Score.PatientScoringResultRow)appcheScore.NewRow();
            addRow.PAT_ID = _patientID;
            addRow.VISIT_ID = _visitID;
            addRow.SCORING_DATE_TIME = dtpTime.Value;
            addRow.SCORING_METHOD = "Apache Ⅱ";
            addRow.SCORING_VALUE = decimal.Parse(txtScore.Text);
            //addRow.DEGREE = txtDeathRate.Text.Trim();
            addRow.PAT_CONDITION = tex_DescriptionIllness.Text;
            addRow.OPERATOR = operatorNurse;
            appcheScore.AddPatientScoringResultRow(addRow);
            if (new ScoreDA().UpdatePatientScoringResult(appcheScore) >= 0)
            {
                return 1;
            }
            else
            {
                Dialog.MessageBox("保存失败！");
                return -1;
            }
        }

        /// <summary>
        /// 清空方法
        /// </summary>
        private void Reset()
        {
            //eyes_reflect = -1;
            //talk_reflect = -1;
            //limb_reflect = -1;
            foreach (object obj in panel1.Controls)
            {
                if (obj is GroupBox)
                {
                    GroupBox gb = (GroupBox)obj;
                    //只循环groupBox2 - groupBox14
                    if (gb.Name != "groupBox1" && gb.Name != "groupBox16"
                        && gb.Name != "groupBox17" && gb.Name != "groupBox18" && gb.Name != "groupBox19" && gb.Name != "groupBox20")
                    {
                        foreach (RadioButton cb in gb.Controls)
                        {
                            if (cb.Checked)
                            {
                                cb.Checked = false;

                            }
                        }
                    }
                    else if (gb.Name != "groupBox1")
                    {
                        foreach (RadioButton rb in gb.Controls)
                        {
                            if (rb.Checked)
                            {
                                rb.Checked = false;

                            }
                        }
                    }
                }
            }

            this.tex_DescriptionIllness.Text = "";
            //this.txtDeathRate.Text = "";
            this.txtScore.Text = "";
        }
        /// <summary>
        /// 删除信息
        /// </summary>
        private void deleteinfo()
        {
            if (dgvApache.Rows.Count > 0 && dgvApache.SelectedRows != null)
            {
                gcsTable.Rows[quaryIndex()].Delete();
                appcheScore.Rows[findMainTableIndex()].Delete();

                RefreshGraph();
                Reset();
                if (dgvApache.Rows.Count > 0)
                {
                    dgvApache.Rows[0].Selected = true;
                }
            }
        }

        private int findMainTableIndex()
        {
            int deleteBeforeSelect = 0, exsitRow = 0, index;
            for (int i = 0; i < appcheScore.Rows.Count; i++)
            {
                if (appcheScore.Rows[i].RowState == DataRowState.Deleted)
                    deleteBeforeSelect++;
                else
                    exsitRow++;
                if (exsitRow >= dgvApache.SelectedRows[0].Index + 1)
                    break;
            }
            for (index = dgvApache.SelectedRows[0].Index + deleteBeforeSelect; index < appcheScore.Rows.Count; index++)
            {
                if (appcheScore.Rows[index].RowState == DataRowState.Deleted)
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
            for (int rowNo = 0; rowNo < gcsTable.Rows.Count; rowNo++)
            {
                if (gcsTable.Rows[rowNo].RowState != DataRowState.Deleted)
                {
                    if (gcsTable.Rows[rowNo]["SCORING_DATE_TIME"].ToString() == appcheScore.Rows[findMainTableIndex()]["SCORING_DATE_TIME"].ToString())
                        return rowNo;
                }
            }
            return -1;
        }

        /// <summary>
        /// 显示内容
        /// </summary>
        /// <param name="deTable"></param>
        private void pushValue(Score.WIS_SCORE_APA_RESULTDataTable cTable)
        {
           BindCheckorRB(cTable.Rows[0][3].ToString().Split(new char[] { '*' }),groupBox2);
           BindCheckorRB(cTable.Rows[0][4].ToString().Split(new char[] { '*' }), groupBox3);
           BindCheckorRB(cTable.Rows[0][5].ToString().Split(new char[] { '*' }), groupBox4);
           BindCheckorRB(cTable.Rows[0][6].ToString().Split(new char[] { '*' }), groupBox5);
           BindCheckorRB(cTable.Rows[0][7].ToString().Split(new char[] { '*' }), groupBox6);
           BindCheckorRB(cTable.Rows[0][8].ToString().Split(new char[] { '*' }), groupBox7);
           BindCheckorRB(cTable.Rows[0][9].ToString().Split(new char[] { '*' }), groupBox8);
           BindCheckorRB(cTable.Rows[0][10].ToString().Split(new char[] { '*' }), groupBox9);
           BindCheckorRB(cTable.Rows[0][11].ToString().Split(new char[] { '*' }), groupBox10);
           BindCheckorRB(cTable.Rows[0][12].ToString().Split(new char[] { '*' }), groupBox11);
           BindCheckorRB(cTable.Rows[0][13].ToString().Split(new char[] { '*' }), groupBox12);
           BindCheckorRB(cTable.Rows[0][14].ToString().Split(new char[] { '*' }), groupBox13);
           BindCheckorRB(cTable.Rows[0][15].ToString().Split(new char[] { '*' }), groupBox14);
           BindCheckorRB(cTable.Rows[0][16].ToString().Split(new char[] { '*' }), groupBox15);

           BindCheckorRB(cTable.Rows[0][18].ToString().Split(new char[] { '*' }), groupBox16);
           BindCheckorRB(cTable.Rows[0][19].ToString().Split(new char[] { '*' }), groupBox17);
           BindCheckorRB(cTable.Rows[0][20].ToString().Split(new char[] { '*' }), groupBox18);
           BindCheckorRB(cTable.Rows[0][21].ToString().Split(new char[] { '*' }), groupBox19);
           BindCheckorRB(cTable.Rows[0][22].ToString().Split(new char[] { '*' }), groupBox20);


           dtpTime.Text = cTable.Rows[0]["SCORING_DATE_TIME"].ToString();

            //病情描述
            this.tex_DescriptionIllness.Text = cTable.Rows[0]["memo"].ToString();
        }

        private void BindCheckorRB(string [] strrow, GroupBox groupBox)
        {

            if (groupBox.Name != "groupBox16" && groupBox.Name != "groupBox17" &&
                groupBox.Name != "groupBox18" && groupBox.Name != "groupBox19" && groupBox.Name != "groupBox20")
            {

                foreach (RadioButton cb in groupBox.Controls)
                {
                    for (int i = 0; i <= strrow.Length - 1; i++)
                    {
                        if (cb.Text != "")
                        {
                            if (cb.Text.Substring(0, 1) == strrow[i])
                            {
                                cb.Checked = true;
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (RadioButton rb in groupBox.Controls)
                {
                    for (int i = 0; i <= strrow.Length - 1; i++)
                    {
                        if (rb.Text.Substring(0, 1) == strrow[i])
                        {
                            rb.Checked = true;
                        }
                    }
                }
            }
               
        }

        #endregion
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GlasgowPanel_Load(object sender, EventArgs e)
        {
            SetGraphParameters();
            bindToDataGrid();
            RefreshGraph();
        }
        /// <summary>
        /// 评分按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScore_Click(object sender, EventArgs e)
        {
            scornum = GlasgowScore();
            this.txtScore.Text = scornum.ToString();
        }
        /// <summary>
        /// 保存明细表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveCramsScore() > 0 && saveScoreResult() > 0)
            {
                bindToDataGrid();
                RefreshGraph();
                Dialog.MessageBox("保存成功");
                dtpTime.Value = new CommonDA().GetSysDateTime();
            }
            else
            {
                Dialog.MessageBox("保存失败");
            }
        }
        /// <summary>
        /// 清空按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }
        /// <summary>
        /// 删除评分总分
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_dele_Click(object sender, EventArgs e)
        {
            try
            {
                deleteinfo();
            }
            catch
            {
            }
        }
        /// <summary>
        /// 保存评分总分
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveScore_Click(object sender, EventArgs e)
        {
            if (new ScoreDA().UpdatePatientScoringResult(appcheScore) >= 0)
            {
                if (new ScoreDA().UpdateAPA(gcsTable) >= 0)
                {
                    RefreshGraph();
                    Dialog.MessageBox("保存成功！");
                }
            }
            else
            {
                Dialog.MessageBox("保存失败！");
            }
        }
        /// <summary>
        /// 选择评分总分
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvApache_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            Reset();
            GlasgowTable = new ScoreDA().GetAPAInfo(_patientID, _visitID,_operID, (DateTime)dgvApache.Rows[e.RowIndex].Cells[0].Value);
            this.txtScore.Text = this.dgvApache.Rows[e.RowIndex].Cells[1].Value.ToString();
            pushValue(GlasgowTable);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox13_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox12_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox11_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox10_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox15_Enter(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void groupBox16_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox17_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void groupBox18_Enter(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void groupBox19_Enter(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void groupBox20_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tex_DescriptionIllness_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void checkBox26_CheckedChanged(object sender, EventArgs e)
        {

        }



       


    }
}
