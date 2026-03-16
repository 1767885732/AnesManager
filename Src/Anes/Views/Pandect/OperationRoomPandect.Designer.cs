using Wis.Anes.Framework.Controls;
namespace Wis.Anes.Views
{
    partial class OperationRoomPandect
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
            if (timer_Refresh != null)
            {
                timer_Refresh.Dispose();
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
            this.medPanelMain = new Wis.Anes.Framework.Controls.MedPanel();
            this.timer_Refresh = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.medPanelMain)).BeginInit();
            this.SuspendLayout();
            // 
            // medPanelMain
            // 
            this.medPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.medPanelMain.FireScrollEventOnMouseWheel = true;
            this.medPanelMain.Location = new System.Drawing.Point(0, 0);
            this.medPanelMain.Name = "medPanelMain";
            this.medPanelMain.Size = new System.Drawing.Size(1065, 441);
            this.medPanelMain.TabIndex = 20;
            // 
            // timer_Refresh
            // 
            this.timer_Refresh.Interval = 60000;
            this.timer_Refresh.Tick += new System.EventHandler(this.timer_Refresh_Tick);
            // 
            // OperationRoomPandect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.medPanelMain);
            this.Name = "OperationRoomPandect";
            this.Size = new System.Drawing.Size(1065, 441);
            this.Load += new System.EventHandler(this.OperationRoomPandect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.medPanelMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MedPanel medPanelMain;
        private System.Windows.Forms.Timer timer_Refresh;
    }
}
