namespace Wis.Anes.Framework.Documents
{
    partial class BaseDoc
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
            this.ToolBarLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.DesignButton = new DevExpress.XtraEditors.SimpleButton();
            this.SaveButton = new DevExpress.XtraEditors.SimpleButton();
            this.RefreshButton = new DevExpress.XtraEditors.SimpleButton();
            this.ApplyDataTemplate = new DevExpress.XtraEditors.SimpleButton();
            this.SaveDataTemplate = new DevExpress.XtraEditors.SimpleButton();
            this.SaveAllDataTemplate = new DevExpress.XtraEditors.SimpleButton();
            this.ApplyAllDataTemplate = new DevExpress.XtraEditors.SimpleButton();
            this.exportPDF = new DevExpress.XtraEditors.SimpleButton();
            this.CancelButton = new DevExpress.XtraEditors.SimpleButton();
            this.printCurrent = new DevExpress.XtraEditors.SimpleButton();
            this.PrintButton = new DevExpress.XtraEditors.SimpleButton();
            this.LastPageButton = new DevExpress.XtraEditors.SimpleButton();
            this.NextPageButton = new DevExpress.XtraEditors.SimpleButton();
            this.PreviousPageButton = new DevExpress.XtraEditors.SimpleButton();
            this.FirstPageButton = new DevExpress.XtraEditors.SimpleButton();
            this.PageDesc = new System.Windows.Forms.Label();
            this.btnMultiPrint = new DevExpress.XtraEditors.SimpleButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.MedReportView = new Wis.Anes.Framework.Controls.MedReportView();
            this.btnBackPrint = new DevExpress.XtraEditors.SimpleButton();
            this.ToolBarLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.xtraScrollableControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBarLayoutPanel
            // 
            this.ToolBarLayoutPanel.Controls.Add(this.DesignButton);
            this.ToolBarLayoutPanel.Controls.Add(this.SaveButton);
            this.ToolBarLayoutPanel.Controls.Add(this.RefreshButton);
            this.ToolBarLayoutPanel.Controls.Add(this.ApplyDataTemplate);
            this.ToolBarLayoutPanel.Controls.Add(this.SaveDataTemplate);
            this.ToolBarLayoutPanel.Controls.Add(this.SaveAllDataTemplate);
            this.ToolBarLayoutPanel.Controls.Add(this.ApplyAllDataTemplate);
            this.ToolBarLayoutPanel.Controls.Add(this.exportPDF);
            this.ToolBarLayoutPanel.Controls.Add(this.CancelButton);
            this.ToolBarLayoutPanel.Controls.Add(this.printCurrent);
            this.ToolBarLayoutPanel.Controls.Add(this.PrintButton);
            this.ToolBarLayoutPanel.Controls.Add(this.LastPageButton);
            this.ToolBarLayoutPanel.Controls.Add(this.NextPageButton);
            this.ToolBarLayoutPanel.Controls.Add(this.PreviousPageButton);
            this.ToolBarLayoutPanel.Controls.Add(this.FirstPageButton);
            this.ToolBarLayoutPanel.Controls.Add(this.PageDesc);
            this.ToolBarLayoutPanel.Controls.Add(this.btnMultiPrint);
            this.ToolBarLayoutPanel.Controls.Add(this.btnBackPrint);
            this.ToolBarLayoutPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ToolBarLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.ToolBarLayoutPanel.Location = new System.Drawing.Point(0, 526);
            this.ToolBarLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ToolBarLayoutPanel.Name = "ToolBarLayoutPanel";
            this.ToolBarLayoutPanel.Size = new System.Drawing.Size(1390, 105);
            this.ToolBarLayoutPanel.TabIndex = 0;
            // 
            // DesignButton
            // 
            this.DesignButton.Location = new System.Drawing.Point(1274, 5);
            this.DesignButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DesignButton.Name = "DesignButton";
            this.DesignButton.Size = new System.Drawing.Size(112, 38);
            this.DesignButton.TabIndex = 12;
            this.DesignButton.Text = "配 置(&D)";
            this.DesignButton.Visible = false;
            this.DesignButton.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(1154, 5);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(112, 38);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "保 存(&S)";
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(1034, 5);
            this.RefreshButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(112, 38);
            this.RefreshButton.TabIndex = 1;
            this.RefreshButton.Text = "刷 新(&R)";
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // ApplyDataTemplate
            // 
            this.ApplyDataTemplate.Location = new System.Drawing.Point(914, 5);
            this.ApplyDataTemplate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ApplyDataTemplate.Name = "ApplyDataTemplate";
            this.ApplyDataTemplate.Size = new System.Drawing.Size(112, 38);
            this.ApplyDataTemplate.TabIndex = 11;
            this.ApplyDataTemplate.Text = "应用模版(&A)";
            this.ApplyDataTemplate.Visible = false;
            this.ApplyDataTemplate.Click += new System.EventHandler(this.ApplyDataTemplate_Click);
            // 
            // SaveDataTemplate
            // 
            this.SaveDataTemplate.Location = new System.Drawing.Point(794, 5);
            this.SaveDataTemplate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SaveDataTemplate.Name = "SaveDataTemplate";
            this.SaveDataTemplate.Size = new System.Drawing.Size(112, 38);
            this.SaveDataTemplate.TabIndex = 10;
            this.SaveDataTemplate.Text = "保存模版(&T)";
            this.SaveDataTemplate.Visible = false;
            this.SaveDataTemplate.Click += new System.EventHandler(this.SaveDataTemplate_Click);
            // 
            // SaveAllDataTemplate
            // 
            this.SaveAllDataTemplate.Location = new System.Drawing.Point(638, 5);
            this.SaveAllDataTemplate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SaveAllDataTemplate.Name = "SaveAllDataTemplate";
            this.SaveAllDataTemplate.Size = new System.Drawing.Size(148, 38);
            this.SaveAllDataTemplate.TabIndex = 20;
            this.SaveAllDataTemplate.Text = "保存整套模版(&N)";
            this.SaveAllDataTemplate.Visible = false;
            this.SaveAllDataTemplate.Click += new System.EventHandler(this.SaveAllDataTemplate_Click);
            // 
            // ApplyAllDataTemplate
            // 
            this.ApplyAllDataTemplate.Location = new System.Drawing.Point(482, 5);
            this.ApplyAllDataTemplate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ApplyAllDataTemplate.Name = "ApplyAllDataTemplate";
            this.ApplyAllDataTemplate.Size = new System.Drawing.Size(148, 38);
            this.ApplyAllDataTemplate.TabIndex = 19;
            this.ApplyAllDataTemplate.Text = "应用整套模版(&M)";
            this.ApplyAllDataTemplate.Visible = false;
            this.ApplyAllDataTemplate.Click += new System.EventHandler(this.ApplyAllDataTemplate_Click);
            // 
            // exportPDF
            // 
            this.exportPDF.Location = new System.Drawing.Point(362, 5);
            this.exportPDF.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.exportPDF.Name = "exportPDF";
            this.exportPDF.Size = new System.Drawing.Size(112, 38);
            this.exportPDF.TabIndex = 13;
            this.exportPDF.Text = "导出PDF(&E)";
            this.exportPDF.Visible = false;
            this.exportPDF.Click += new System.EventHandler(this.exportPDF_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(242, 5);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(112, 38);
            this.CancelButton.TabIndex = 8;
            this.CancelButton.Text = "取 消(&C)";
            this.CancelButton.Visible = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // printCurrent
            // 
            this.printCurrent.Location = new System.Drawing.Point(105, 5);
            this.printCurrent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.printCurrent.Name = "printCurrent";
            this.printCurrent.Size = new System.Drawing.Size(129, 38);
            this.printCurrent.TabIndex = 14;
            this.printCurrent.Text = "当前页打印(&C)";
            this.printCurrent.Visible = false;
            this.printCurrent.Click += new System.EventHandler(this.printCurrent_Click);
            // 
            // PrintButton
            // 
            this.PrintButton.Location = new System.Drawing.Point(1274, 53);
            this.PrintButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(112, 38);
            this.PrintButton.TabIndex = 2;
            this.PrintButton.Text = "打 印(&P)";
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // LastPageButton
            // 
            this.LastPageButton.Location = new System.Drawing.Point(1154, 53);
            this.LastPageButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LastPageButton.Name = "LastPageButton";
            this.LastPageButton.Size = new System.Drawing.Size(112, 38);
            this.LastPageButton.TabIndex = 4;
            this.LastPageButton.Text = "末 页(&L)";
            this.LastPageButton.Visible = false;
            this.LastPageButton.Click += new System.EventHandler(this.LastPageButton_Click);
            // 
            // NextPageButton
            // 
            this.NextPageButton.Location = new System.Drawing.Point(1034, 53);
            this.NextPageButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NextPageButton.Name = "NextPageButton";
            this.NextPageButton.Size = new System.Drawing.Size(112, 38);
            this.NextPageButton.TabIndex = 5;
            this.NextPageButton.Text = "下一页(&N)";
            this.NextPageButton.Visible = false;
            this.NextPageButton.Click += new System.EventHandler(this.NextPageButton_Click);
            // 
            // PreviousPageButton
            // 
            this.PreviousPageButton.Location = new System.Drawing.Point(914, 53);
            this.PreviousPageButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PreviousPageButton.Name = "PreviousPageButton";
            this.PreviousPageButton.Size = new System.Drawing.Size(112, 38);
            this.PreviousPageButton.TabIndex = 6;
            this.PreviousPageButton.Text = " 上一页(&E)";
            this.PreviousPageButton.Visible = false;
            this.PreviousPageButton.Click += new System.EventHandler(this.PreviousPageButton_Click);
            // 
            // FirstPageButton
            // 
            this.FirstPageButton.Location = new System.Drawing.Point(794, 53);
            this.FirstPageButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FirstPageButton.Name = "FirstPageButton";
            this.FirstPageButton.Size = new System.Drawing.Size(112, 38);
            this.FirstPageButton.TabIndex = 7;
            this.FirstPageButton.Text = "首 页(&F)";
            this.FirstPageButton.Visible = false;
            this.FirstPageButton.Click += new System.EventHandler(this.FirstPageButton_Click);
            // 
            // PageDesc
            // 
            this.PageDesc.Location = new System.Drawing.Point(636, 48);
            this.PageDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PageDesc.Name = "PageDesc";
            this.PageDesc.Size = new System.Drawing.Size(150, 38);
            this.PageDesc.TabIndex = 9;
            this.PageDesc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnMultiPrint
            // 
            this.btnMultiPrint.Location = new System.Drawing.Point(516, 53);
            this.btnMultiPrint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMultiPrint.Name = "btnMultiPrint";
            this.btnMultiPrint.Size = new System.Drawing.Size(112, 38);
            this.btnMultiPrint.TabIndex = 21;
            this.btnMultiPrint.Text = "集中打印";
            this.btnMultiPrint.Visible = false;
            this.btnMultiPrint.Click += new System.EventHandler(this.btnMultiPrint_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.AlwaysScrollActiveControlIntoView = false;
            this.xtraScrollableControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.xtraScrollableControl1.Appearance.Options.UseBackColor = true;
            this.xtraScrollableControl1.Controls.Add(this.MedReportView);
            this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl1.FireScrollEventOnMouseWheel = true;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraScrollableControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(1390, 526);
            this.xtraScrollableControl1.TabIndex = 1;
            // 
            // MedReportView
            // 
            this.MedReportView.Location = new System.Drawing.Point(0, 0);
            this.MedReportView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MedReportView.Name = "MedReportView";
            this.MedReportView.Size = new System.Drawing.Size(1112, 438);
            this.MedReportView.TabIndex = 0;
            this.MedReportView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MedReportView_MouseDown);
            // 
            // btnBackPrint
            // 
            this.btnBackPrint.Location = new System.Drawing.Point(396, 53);
            this.btnBackPrint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBackPrint.Name = "btnBackPrint";
            this.btnBackPrint.Size = new System.Drawing.Size(112, 38);
            this.btnBackPrint.TabIndex = 22;
            this.btnBackPrint.Text = "退回打印";
            this.btnBackPrint.Visible = false;
            this.btnBackPrint.Click += new System.EventHandler(this.btnBackPrint_Click);
            // 
            // BaseDoc
            // 
            this.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraScrollableControl1);
            this.Controls.Add(this.ToolBarLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "BaseDoc";
            this.Size = new System.Drawing.Size(1390, 631);
            this.Resize += new System.EventHandler(this.BaseDoc_Resize);
            this.ToolBarLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.xtraScrollableControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.FlowLayoutPanel ToolBarLayoutPanel;
        protected  DevExpress.XtraEditors.SimpleButton SaveButton;
        protected DevExpress.XtraEditors.SimpleButton RefreshButton;
        protected DevExpress.XtraEditors.SimpleButton PrintButton;
        protected DevExpress.XtraEditors.SimpleButton LastPageButton;
        protected DevExpress.XtraEditors.SimpleButton NextPageButton;
        protected DevExpress.XtraEditors.SimpleButton PreviousPageButton;
        protected DevExpress.XtraEditors.SimpleButton FirstPageButton;
        protected DevExpress.XtraEditors.SimpleButton CancelButton;
        protected System.Windows.Forms.ErrorProvider errorProvider1;
        protected System.Windows.Forms.Label PageDesc;
        protected DevExpress.XtraEditors.SimpleButton SaveDataTemplate;
        protected DevExpress.XtraEditors.SimpleButton ApplyDataTemplate;
        protected DevExpress.XtraEditors.SimpleButton DesignButton;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private Wis.Anes.Framework.Controls.MedReportView MedReportView;
        protected DevExpress.XtraEditors.SimpleButton exportPDF;
        protected DevExpress.XtraEditors.SimpleButton printCurrent;
        protected DevExpress.XtraEditors.SimpleButton SaveAllDataTemplate;
        protected DevExpress.XtraEditors.SimpleButton ApplyAllDataTemplate;
        protected DevExpress.XtraEditors.SimpleButton btnMultiPrint;
        protected DevExpress.XtraEditors.SimpleButton btnBackPrint;
    }
}
