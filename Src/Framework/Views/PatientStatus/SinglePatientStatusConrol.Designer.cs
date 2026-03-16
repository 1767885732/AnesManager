namespace Wis.Anes.Framework.Views
{
    partial class SinglePatientStatusConrol
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
            this.picLight = new System.Windows.Forms.PictureBox();
            this.lbStatusName = new System.Windows.Forms.Label();
            this.toolTipStatusTime = new System.Windows.Forms.ToolTip(this.components);
            this.dtpStatusDateTime = new DevExpress.XtraEditors.DateEdit();
            this.panelMain = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picLight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStatusDateTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStatusDateTime.Properties)).BeginInit();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // picLight
            // 
            this.picLight.Location = new System.Drawing.Point(108, 7);
            this.picLight.Name = "picLight";
            this.picLight.Size = new System.Drawing.Size(30, 30);
            this.picLight.TabIndex = 3;
            this.picLight.TabStop = false;
            this.picLight.Click += new System.EventHandler(this.picLight_Click);
            this.picLight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picLight_MouseDown);
            // 
            // lbStatusName
            // 
            this.lbStatusName.AutoSize = true;
            this.lbStatusName.Enabled = false;
            this.lbStatusName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbStatusName.Location = new System.Drawing.Point(24, 25);
            this.lbStatusName.Name = "lbStatusName";
            this.lbStatusName.Size = new System.Drawing.Size(57, 12);
            this.lbStatusName.TabIndex = 4;
            this.lbStatusName.Text = "手术开始";
            this.lbStatusName.Click += new System.EventHandler(this.picLight_Click);
            this.lbStatusName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picLight_MouseDown);
            this.lbStatusName.Cursor = System.Windows.Forms.Cursors.Hand;
            // 
            // dtpStatusDateTime
            // 
            this.dtpStatusDateTime.EditValue = new System.DateTime(2019, 10, 29, 0, 0, 0, 0);
            this.dtpStatusDateTime.Location = new System.Drawing.Point(0, 0);
            this.dtpStatusDateTime.Name = "dtpStatusDateTime";
            this.dtpStatusDateTime.Size = new System.Drawing.Size(100, 21);
            this.dtpStatusDateTime.Properties.Appearance.Options.UseTextOptions = true;
            this.dtpStatusDateTime.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dtpStatusDateTime.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.dtpStatusDateTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpStatusDateTime.Properties.DisplayFormat.FormatString = "MM-dd HH:mm";
            this.dtpStatusDateTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpStatusDateTime.Properties.Mask.EditMask = "t";
            this.dtpStatusDateTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtpStatusDateTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpStatusDateTime.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.dtpStatusDateTime_Properties_ButtonClick);
            this.dtpStatusDateTime.Properties.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.dtpStatusDateTime_Properties_ButtonPressed);
            this.dtpStatusDateTime.Properties.Click += new System.EventHandler(this.dtpStatusDateTime_Properties_Click);
            this.dtpStatusDateTime.Properties.DoubleClick += new System.EventHandler(this.dtpStatusDateTime_Properties_DoubleClick);
            this.dtpStatusDateTime.Properties.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpStatusDateTime_Properties_KeyDown);
            this.dtpStatusDateTime.Properties.Validating += new System.ComponentModel.CancelEventHandler(this.dtpStatusDateTime_Properties_Validating);
            this.dtpStatusDateTime.TabIndex = 0;
            this.dtpStatusDateTime.EditValueChanged += new System.EventHandler(this.dtpStatusDateTime_EditValueChanged);
            this.dtpStatusDateTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpStatusDateTime_KeyPress);
            this.dtpStatusDateTime.Validated += new System.EventHandler(this.dtpStatusDateTime_Validated);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.dtpStatusDateTime);
            this.panelMain.Controls.Add(this.picLight);
            this.panelMain.Controls.Add(this.lbStatusName);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(100, 50);
            this.panelMain.TabIndex = 83;
            // 
            // SinglePatientStatusConrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "SinglePatientStatusConrol";
            this.Size = new System.Drawing.Size(132, 50);
            this.Load += new System.EventHandler(this.SinglePatientStatusConrol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStatusDateTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStatusDateTime.Properties)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbStatusName;
        private System.Windows.Forms.ToolTip toolTipStatusTime;
        private DevExpress.XtraEditors.DateEdit dtpStatusDateTime;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.PictureBox picLight;

    }
}
