using Wis.Anes.Framework;
namespace Wis.Anes.Views
{
    partial class EditTemplet
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
            this.medLabel1 = new Wis.Anes.Framework.Controls.MedLabel();
            this.medPanel1 = new Wis.Anes.Framework.Controls.MedPanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.eventTemplet1 = new Wis.Anes.Framework.EventTemplet();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.documentTemplet1 = new Wis.Anes.Framework.DocumentTemplet();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.bloodGasTemplet1 = new Wis.Anes.Framework.BloodGasTemplet();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.qiXieQingDianTemplet1 = new Wis.Anes.Framework.QiXieQingDianTemplet();
            this.xtraTabPageFee = new DevExpress.XtraTab.XtraTabPage();
            this.feeTemplet1 = new Wis.Anes.Framework.FeeTemplet();
            ((System.ComponentModel.ISupportInitialize)(this.medPanel1)).BeginInit();
            this.medPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.xtraTabPage3.SuspendLayout();
            this.xtraTabPage4.SuspendLayout();
            this.xtraTabPageFee.SuspendLayout();
            this.SuspendLayout();
            // 
            // medLabel1
            // 
            this.medLabel1.Appearance.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.medLabel1.Appearance.Options.UseFont = true;
            this.medLabel1.Appearance.Options.UseTextOptions = true;
            this.medLabel1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.medLabel1.BottomLine = false;
            this.medLabel1.DotBorder = false;
            this.medLabel1.Image = null;
            this.medLabel1.Location = new System.Drawing.Point(2, 10);
            this.medLabel1.MultiLine = false;
            this.medLabel1.Name = "medLabel1";
            this.medLabel1.NoPrint = false;
            this.medLabel1.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.medLabel1.PrintXOffSet = 0F;
            this.medLabel1.PrintYOffSet = 0F;
            this.medLabel1.Size = new System.Drawing.Size(92, 20);
            this.medLabel1.SymbolType = Wis.Anes.Framework.Controls.MedSymbolType.None;
            this.medLabel1.TabIndex = 0;
            this.medLabel1.Text = "模板管理";
            this.medLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.medLabel1.VarKey = null;
            // 
            // medPanel1
            // 
            this.medPanel1.Controls.Add(this.medLabel1);
            this.medPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.medPanel1.Location = new System.Drawing.Point(0, 0);
            this.medPanel1.Name = "medPanel1";
            this.medPanel1.Size = new System.Drawing.Size(1195, 40);
            this.medPanel1.TabIndex = 15;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.xtraTabControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 40);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1195, 557);
            this.panelControl1.TabIndex = 16;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(1195, 557);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3,
            this.xtraTabPage4,
            this.xtraTabPageFee});
            this.xtraTabControl1.SelectedPageChanging += new DevExpress.XtraTab.TabPageChangingEventHandler(this.xtraTabControl1_SelectedPageChanging);
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.eventTemplet1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1188, 527);
            this.xtraTabPage1.Text = "事件模板";
            // 
            // eventTemplet1
            // 
            this.eventTemplet1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventTemplet1.Location = new System.Drawing.Point(0, 0);
            this.eventTemplet1.Name = "eventTemplet1";
            this.eventTemplet1.Size = new System.Drawing.Size(1188, 527);
            this.eventTemplet1.TabIndex = 0;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.documentTemplet1);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(1188, 527);
            this.xtraTabPage2.Text = "文书模板";
            // 
            // documentTemplet1
            // 
            this.documentTemplet1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentTemplet1.Location = new System.Drawing.Point(0, 0);
            this.documentTemplet1.Name = "documentTemplet1";
            this.documentTemplet1.Size = new System.Drawing.Size(1188, 527);
            this.documentTemplet1.TabIndex = 0;
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.bloodGasTemplet1);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(1188, 527);
            this.xtraTabPage3.Text = "血气模板";
            // 
            // bloodGasTemplet1
            // 
            this.bloodGasTemplet1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bloodGasTemplet1.Location = new System.Drawing.Point(0, 0);
            this.bloodGasTemplet1.Name = "bloodGasTemplet1";
            this.bloodGasTemplet1.Size = new System.Drawing.Size(1188, 527);
            this.bloodGasTemplet1.TabIndex = 0;
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Controls.Add(this.qiXieQingDianTemplet1);
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(1188, 527);
            this.xtraTabPage4.Text = "手术清点模板";
            // 
            // qiXieQingDianTemplet1
            // 
            this.qiXieQingDianTemplet1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qiXieQingDianTemplet1.IsApply = false;
            this.qiXieQingDianTemplet1.Location = new System.Drawing.Point(0, 0);
            this.qiXieQingDianTemplet1.Name = "qiXieQingDianTemplet1";
            this.qiXieQingDianTemplet1.Size = new System.Drawing.Size(1188, 527);
            this.qiXieQingDianTemplet1.TabIndex = 0;
            // 
            // xtraTabPageFee
            // 
            this.xtraTabPageFee.Controls.Add(this.feeTemplet1);
            this.xtraTabPageFee.Name = "xtraTabPageFee";
            this.xtraTabPageFee.Size = new System.Drawing.Size(1188, 527);
            this.xtraTabPageFee.Text = "收费模板";
            // 
            // feeTemplet1
            // 
            this.feeTemplet1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feeTemplet1.Location = new System.Drawing.Point(0, 0);
            this.feeTemplet1.Name = "feeTemplet1";
            this.feeTemplet1.Size = new System.Drawing.Size(1188, 527);
            this.feeTemplet1.TabIndex = 0;
            // 
            // EditTemplet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.medPanel1);
            this.Name = "EditTemplet";
            this.Size = new System.Drawing.Size(1195, 597);
            this.Load += new System.EventHandler(this.EditTemplet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.medPanel1)).EndInit();
            this.medPanel1.ResumeLayout(false);
            this.medPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage3.ResumeLayout(false);
            this.xtraTabPage4.ResumeLayout(false);
            this.xtraTabPageFee.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Wis.Anes.Framework.Controls.MedLabel medLabel1;
        private Wis.Anes.Framework.Controls.MedPanel medPanel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DocumentTemplet documentTemplet1;
        private EventTemplet eventTemplet1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private BloodGasTemplet bloodGasTemplet1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        private QiXieQingDianTemplet qiXieQingDianTemplet1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageFee;
        private FeeTemplet feeTemplet1;
    }
}
