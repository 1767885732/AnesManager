namespace Wis.Anes.Framework
{
    partial class TimePointItemsEditor
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageEvent = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPageBloodGas = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPageDrug = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPageLiquid = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPageVitalSign = new DevExpress.XtraTab.XtraTabPage();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.panel5 = new System.Windows.Forms.Panel();
            this.medButton8 = new Wis.Anes.Framework.Controls.MedButton();
            this.medButton9 = new Wis.Anes.Framework.Controls.MedButton();
            this.medButton10 = new Wis.Anes.Framework.Controls.MedButton();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "时间";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 35);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPageEvent;
            this.xtraTabControl1.Size = new System.Drawing.Size(748, 477);
            this.xtraTabControl1.TabIndex = 3;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageEvent,
            this.xtraTabPageBloodGas,
            this.xtraTabPageDrug,
            this.xtraTabPageLiquid,
            this.xtraTabPageVitalSign});
            // 
            // xtraTabPageEvent
            // 
            this.xtraTabPageEvent.Name = "xtraTabPageEvent";
            this.xtraTabPageEvent.Size = new System.Drawing.Size(741, 447);
            this.xtraTabPageEvent.Text = "事件";
            // 
            // xtraTabPageBloodGas
            // 
            this.xtraTabPageBloodGas.Name = "xtraTabPageBloodGas";
            this.xtraTabPageBloodGas.Size = new System.Drawing.Size(741, 447);
            this.xtraTabPageBloodGas.Text = "血气分析";
            // 
            // xtraTabPageDrug
            // 
            this.xtraTabPageDrug.Name = "xtraTabPageDrug";
            this.xtraTabPageDrug.Size = new System.Drawing.Size(741, 447);
            this.xtraTabPageDrug.Text = "药物";
            // 
            // xtraTabPageLiquid
            // 
            this.xtraTabPageLiquid.Name = "xtraTabPageLiquid";
            this.xtraTabPageLiquid.Size = new System.Drawing.Size(741, 447);
            this.xtraTabPageLiquid.Text = "液体和氧气";
            // 
            // xtraTabPageVitalSign
            // 
            this.xtraTabPageVitalSign.Name = "xtraTabPageVitalSign";
            this.xtraTabPageVitalSign.Size = new System.Drawing.Size(741, 447);
            this.xtraTabPageVitalSign.Text = "采集数据(监护仪/麻醉机)";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(43, 9);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(100, 21);
            this.textEdit1.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(13, 12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(24, 14);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "氧气";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(47, 7);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.dateEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit1.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.dateEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit1.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm";
            this.dateEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(225, 21);
            this.dateEdit1.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.labelControl1);
            this.panel5.Controls.Add(this.dateEdit1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(748, 35);
            this.panel5.TabIndex = 5;
            // 
            // medButton8
            // 
            this.medButton8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.medButton8.AutoImage = false;
            this.medButton8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.medButton8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.medButton8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.medButton8.HasBorder = true;
            this.medButton8.IsMenu = false;
            this.medButton8.IsMouseHover = true;
            this.medButton8.Location = new System.Drawing.Point(405, 6);
            this.medButton8.MenuIndex = 0;
            this.medButton8.Name = "medButton8";
            this.medButton8.PageName = null;
            this.medButton8.Parameters = null;
            this.medButton8.ShortcutKeys = null;
            this.medButton8.ShowText = true;
            this.medButton8.Size = new System.Drawing.Size(87, 25);
            this.medButton8.TabIndex = 39;
            this.medButton8.Text = "清  空";
            this.medButton8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.medButton8.UseVisualStyleBackColor = true;
            // 
            // medButton9
            // 
            this.medButton9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.medButton9.AutoImage = false;
            this.medButton9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.medButton9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.medButton9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.medButton9.HasBorder = true;
            this.medButton9.IsMenu = false;
            this.medButton9.IsMouseHover = true;
            this.medButton9.Location = new System.Drawing.Point(632, 6);
            this.medButton9.MenuIndex = 0;
            this.medButton9.Name = "medButton9";
            this.medButton9.PageName = null;
            this.medButton9.Parameters = null;
            this.medButton9.ShortcutKeys = null;
            this.medButton9.ShowText = true;
            this.medButton9.Size = new System.Drawing.Size(87, 25);
            this.medButton9.TabIndex = 38;
            this.medButton9.Text = "取  消";
            this.medButton9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.medButton9.UseVisualStyleBackColor = true;
            // 
            // medButton10
            // 
            this.medButton10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.medButton10.AutoImage = false;
            this.medButton10.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.medButton10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.medButton10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.medButton10.HasBorder = true;
            this.medButton10.IsMenu = false;
            this.medButton10.IsMouseHover = true;
            this.medButton10.Location = new System.Drawing.Point(539, 6);
            this.medButton10.MenuIndex = 0;
            this.medButton10.Name = "medButton10";
            this.medButton10.PageName = null;
            this.medButton10.Parameters = null;
            this.medButton10.ShortcutKeys = null;
            this.medButton10.ShowText = true;
            this.medButton10.Size = new System.Drawing.Size(87, 25);
            this.medButton10.TabIndex = 37;
            this.medButton10.Text = "确  认";
            this.medButton10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.medButton10.UseVisualStyleBackColor = true;
            // 
            // WHYX_TimePointItemsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.panel5);
            this.Name = "WHYX_TimePointItemsEditor";
            this.Size = new System.Drawing.Size(748, 512);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageEvent;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageBloodGas;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageDrug;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageLiquid;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private System.Windows.Forms.Panel panel5;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageVitalSign;
        private Wis.Anes.Framework.Controls.MedButton medButton8;
        private Wis.Anes.Framework.Controls.MedButton medButton9;
        private Wis.Anes.Framework.Controls.MedButton medButton10;
    }
}
