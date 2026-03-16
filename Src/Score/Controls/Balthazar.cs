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
    public partial class Balthazar : BaseControl
    {
        #region  构造方法
        public Balthazar() : this("",-1,-1) { }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="patientRow">病人信息</param>
        //public Balthazar(DataSetModel.Patient.PatientRow patientRow) : this(patientRow, "Balthazar胰腺病变CT严重性指数评分") { }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="patientRow">病人信息</param>
        /// <param name="title">模块标题</param>
        //public Balthazar(DataSetModel.Patient.PatientRow patientRow, string title)
        //    : base(patientRow, title)
        //{
        //    InitializeComponent();
        //}
        public Balthazar(string patientID, decimal visitID, decimal deptID)
            : base(patientID, visitID, deptID, "Balthazar胰腺病变CT严重性指数评分") 
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
        private Wis.Anes.BusinessEntity.Score.MED_BALTHAZAR_SCORING_RESULTDataTable balthazarDataTable;
        private Wis.Anes.BusinessEntity.Score.MED_BALTHAZAR_SCORING_RESULTDataTable balthazarTable;
        DateTime scoreDateTime;
       /// <summary>
       ///胰腺CT分级分值
       /// </summary>
        private int S1;
        /// <summary>
        /// 病变范围分值
        /// </summary>
        private int S2;
        #endregion
        /// <summary>
        /// 刷新数据
        /// </summary>
        protected override void RefreshAll()
        {
            base.RefreshAll();
            bindToDataGrid();
            RefreshGraph();
        }
        /// <summary>
        /// 绑定数据到表格
        /// </summary>
        private void bindToDataGrid()
        {
            if (string.IsNullOrEmpty(_patientID))
                return;
            balthazarTable = DataOperator.GetDataBalthazar(_patientID,_visitID,_deptID);

            patientScore = DataOperator.GetPatientScoringResultDt(_patientID,_visitID,_deptID, "balthazar");
            dgvBalthazar.AutoGenerateColumns = false;
            dgvBalthazar.DataSource = patientScore;
            dgvBalthazar.Columns[0].DataPropertyName = patientScore.Columns["SCORING_DATE_TIME"].ColumnName;
            dgvBalthazar.Columns[1].DataPropertyName = patientScore.Columns["SCORING_VALUE"].ColumnName;
            dgvBalthazar.Columns[2].DataPropertyName = patientScore.Columns["MEMO"].ColumnName;
            dgvBalthazar.Columns[3].DataPropertyName = patientScore.Columns["OPERATOR"].ColumnName;
            //Clear();
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
        /// 获取胰腺病CT分级分值
        /// </summary>
        /// <returns></returns>
        private int getS1()
        {
            int score = 0;
            foreach (RadioButton rbtn in gbCT.Controls)
            {
                if (rbtn.Checked)
                {
                    switch (rbtn.Text.Trim())
                    {
                        case "A级(胰腺正常)":
                            score = 0;
                            break;
                        case "B级(胰腺局部或弥漫性肿大，外形不光滑，实质不均，程度较轻)":

                            score = 1;
                            break;
                        case "C级(胰腺边缘不规则，质地更加不均匀)":

                            score = 2;
                            break;
                        case "D级(胰腺呈广泛蜂窝状改变，显著重大，有炎症表现)":
                            score = 3;
                            break;
                        case "E级(胰腺广泛坏死，胰周脂肪坏死，胰外多处或广泛积液)":
                            score = 4;
                            break;
                        default:
                            break;
                    }
                    break;
                }
            }
            return score;
        }
        /// <summary>
        /// 获取坏死范围分值
        /// </summary>
        /// <returns></returns>

        private int getS2()
        {
            int score = 0;
            foreach (RadioButton rbtn in gbNecrotic.Controls)
            {
                if (rbtn.Checked)
                {
                    switch (rbtn.Text.Trim())
                    {
                        case "无坏死":
                            score = 0;
                            break;
                        case "坏死≤1/2":

                            score = 2;
                            break;
                        case "坏死≤1/3":

                            score = 4;
                            break;
                        case "坏死>1/2":
                            score = 6;
                            break;
                        default:
                            break;
                    }
                    break;
                }
            }
            return score;
        }
        /// <summary>
        /// 计算评分结果
        /// </summary>
        /// <returns></returns>
        public int computeScore()
        {
            int scoreValue = 0;
            S1 = getS1();
            S2 = getS2();
            scoreValue = S1 + S2;
            if (scoreValue >= 0)
            {
                txtScore.Text = scoreValue.ToString();
                return scoreValue;
            }
            else
            {
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
            balthazarDataTable = new Wis.Anes.BusinessEntity.Score.MED_BALTHAZAR_SCORING_RESULTDataTable();
            Wis.Anes.BusinessEntity.Score.MED_BALTHAZAR_SCORING_RESULTRow row = balthazarDataTable.NewMED_BALTHAZAR_SCORING_RESULTRow();
            row.PAT_ID = _patientID;
            row.VISIT_ID = _visitID;
            //row.DEP_ID = _deptID;
            scoreDateTime = DataOperator.GetSysDate();
            row.SCORING_DATE_TIME = scoreDateTime;
            row.S1 = getS1();
            row.S2 = getS2();
            row.MEMO = this.txtMemo.Text;
            balthazarDataTable.Rows.Add(row);
            return DataOperator.UpdateBalthazar(balthazarDataTable);
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
            addRow.SCORING_METHOD = "balthazar";
            addRow.SCORING_VALUE = decimal.Parse(txtScore.Text);
            addRow.MEMO = txtMemo.Text;
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
                if (exsitRow >= dgvBalthazar.SelectedRows[0].Index + 1)
                    break;
            }
            for (index = dgvBalthazar.SelectedRows[0].Index + deleteBeforeSelect; index < patientScore.Rows.Count; index++)
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
            for (int rowNo = 0; rowNo < balthazarTable.Rows.Count; rowNo++)
            {
                if (balthazarTable.Rows[rowNo].RowState != DataRowState.Deleted)
                {
                    if (balthazarTable.Rows[rowNo]["SCORING_DATE_TIME"].ToString() == patientScore.Rows[findMainTableIndex()]["SCORING_DATE_TIME"].ToString())
                        return rowNo;
                }
            }
            return -1;
        }

        /// <summary>
        /// 显示内容
        /// </summary>
        /// <param name="deTable"></param>
        private void pushValue(Wis.Anes.BusinessEntity.Score.MED_BALTHAZAR_SCORING_RESULTDataTable BalthazarTable)
        {
            Clear();
            foreach (RadioButton rbut in gbCT.Controls)
            {

                //活动
                if (rbut.Name == "rbtns1_" + BalthazarTable.Rows[0]["S1"].ToString())
                {
                    rbut.Checked = true;
                    break;
                }
            }
            foreach (RadioButton rbut in gbNecrotic.Controls)
            {
                //呼吸
                if (rbut.Name == "rbtns2_" + BalthazarTable.Rows[0]["s2"].ToString())
                {
                    rbut.Checked = true;
                    break;
                }
            }
            
            txtScore.Text = dgvBalthazar.SelectedRows[0].Cells["scoreValue"].Value.ToString();
            txtMemo.Text = patientScore.Rows[0]["MEMO"].ToString();
        }

        public void Clear() 
        {
            foreach (RadioButton rbut in gbCT.Controls)
            {
                //活动
               rbut.Checked = false ;
               
            }
            foreach (RadioButton rbut in gbNecrotic.Controls)
            {
                //呼吸
               rbut.Checked = false;
            }
            txtMemo.Text = "";
            txtScore.Text = "";
        }

        #region 事件

        private void Balthazar_Load(object sender, EventArgs e)
        {
            bindToDataGrid();
            SetGraphParameters();
           
        }

        private void btnScore_Click(object sender, EventArgs e)
        {
            computeScore();
        }

        private void dgvBalthazar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0)
            {
                return;
            }
            else
            {
                balthazarDataTable = DataOperator.GetBalthazar(_patientID,_visitID,_deptID,
                                 (DateTime)dgvBalthazar.Rows[e.RowIndex].Cells[0].Value);
                pushValue(balthazarDataTable);
            }
        }
/// <summary>
///  保存评分结果按钮事件
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
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
/// 删除评分记录按钮
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void btn_dele_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBalthazar.Rows.Count > 0 && dgvBalthazar.SelectedRows != null)
                {
                    balthazarTable.Rows[quaryIndex()].Delete();
                    patientScore.Rows[findMainTableIndex()].Delete();
                    RefreshGraph();
                    Clear();
                    if (dgvBalthazar.Rows.Count > 0)
                    {
                        dgvBalthazar.Rows[0].Selected = true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
/// <summary>
/// 保存删除评分结果按钮
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void btnSaveScore_Click(object sender, EventArgs e)
        {
            if (DataOperator.UpdatePatientScoringResult(patientScore) >= 0)
            {
                if (DataOperator.UpdateBalthazar(balthazarTable) >= 0)
                {

                    RefreshGraph();
                    bindToDataGrid();
                    Wis.Anes.Framework.Utilities.Dialog.MessageBox("保存成功！");
                }
            }
            else
            {
                Wis.Anes.Framework.Utilities.Dialog.MessageBox("保存失败！");

            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Clear();
        }
        #endregion
    }
}
