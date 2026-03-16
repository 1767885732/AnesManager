namespace Wis.Anes.Framework.Views.Process
{
    partial class OperationRoomProcess
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelRoomNo = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.labelAllCount = new System.Windows.Forms.Label();
            this.labelDoneCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelRoomNo
            // 
            this.labelRoomNo.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelRoomNo.ForeColor = System.Drawing.Color.Black;
            this.labelRoomNo.Location = new System.Drawing.Point(3, 0);
            this.labelRoomNo.Name = "labelRoomNo";
            this.labelRoomNo.Size = new System.Drawing.Size(53, 54);
            this.labelRoomNo.TabIndex = 0;
            this.labelRoomNo.Text = "000";
            this.labelRoomNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAllCount
            // 
            this.labelAllCount.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelAllCount.ForeColor = System.Drawing.Color.Blue;
            this.labelAllCount.Location = new System.Drawing.Point(50, 25);
            this.labelAllCount.Name = "labelAllCount";
            this.labelAllCount.Size = new System.Drawing.Size(35, 29);
            this.labelAllCount.TabIndex = 0;
            this.labelAllCount.Text = "00";
            this.labelAllCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDoneCount
            // 
            this.labelDoneCount.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelDoneCount.ForeColor = System.Drawing.Color.Green;
            this.labelDoneCount.Location = new System.Drawing.Point(50, 0);
            this.labelDoneCount.Name = "labelDoneCount";
            this.labelDoneCount.Size = new System.Drawing.Size(35, 29);
            this.labelDoneCount.TabIndex = 0;
            this.labelDoneCount.Text = "00";
            this.labelDoneCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OperationRoomProcess
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.labelDoneCount);
            this.Controls.Add(this.labelAllCount);
            this.Controls.Add(this.labelRoomNo);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "OperationRoomProcess";
            this.Size = new System.Drawing.Size(541, 54);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelRoomNo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label labelAllCount;
        private System.Windows.Forms.Label labelDoneCount;
    }
}
