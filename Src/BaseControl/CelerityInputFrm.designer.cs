namespace Com.ICIS.Icu
{
    partial class CelerityInputFrm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtValue = new DevExpress.XtraEditors.TextEdit();
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.lblValue = new DevExpress.XtraEditors.LabelControl();
            this.listValues = new DevExpress.XtraEditors.ListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listValues)).BeginInit();
            this.SuspendLayout();
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(0, 0);
            this.txtValue.Name = "txtValue";
            this.txtValue.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.txtValue.Properties.Appearance.Options.UseBackColor = true;
            this.txtValue.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtValue.Size = new System.Drawing.Size(62, 19);
            this.txtValue.TabIndex = 0;
            this.txtValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValue_KeyPress);
            this.txtValue.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtValue);
            this.panel1.Controls.Add(this.lblValue);
            this.panel1.Controls.Add(this.listValues);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(215, 175);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblValue
            // 
            this.lblValue.Location = new System.Drawing.Point(61, 2);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(0, 14);
            this.lblValue.TabIndex = 4;
            // 
            // listValues
            // 
            this.listValues.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listValues.Appearance.Options.UseFont = true;
            this.listValues.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listValues.ItemHeight = 14;
            this.listValues.Location = new System.Drawing.Point(2, 33);
            this.listValues.Name = "listValues";
            this.listValues.Size = new System.Drawing.Size(211, 140);
            this.listValues.TabIndex = 3;
            this.listValues.DoubleClick += new System.EventHandler(this.listValues_DoubleClick);
            this.listValues.SelectedIndexChanged += new System.EventHandler(this.listValues_SelectedIndexChanged);
            // 
            // CelerityInputFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 175);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CelerityInputFrm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValue_KeyPress);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MedInputFrm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.txtValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listValues)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtValue;
        private DevExpress.XtraEditors.PanelControl panel1;
        private DevExpress.XtraEditors.ListBoxControl listValues;
        private DevExpress.XtraEditors.LabelControl lblValue;
    }
}