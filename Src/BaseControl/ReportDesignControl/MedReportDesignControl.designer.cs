namespace Com.ICIS.Common.Controls
{
    partial class MedReportDesignControl
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
            this.SuspendLayout();
            // 
            // MedReportDesignControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Name = "MedReportDesignControl";
            this.Size = new System.Drawing.Size(765, 386);
            this.Load += new System.EventHandler(this.MedReportDesignControl_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MedReportDesignControl_MouseMove);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.ReportDesignControl_DragDrop);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MedReportDesignControl_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MedReportDesignControl_MouseUp);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.ReportDesignControl_DragEnter);
            this.ResumeLayout(false);

        }

        #endregion





























    }
}
