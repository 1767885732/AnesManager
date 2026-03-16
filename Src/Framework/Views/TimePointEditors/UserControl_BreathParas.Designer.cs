namespace Wis.Anes.Framework
{
    partial class UserControl_BreathParas
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
            this.txtCode1 = new DevExpress.XtraEditors.TextEdit();
            this.lblCode1 = new DevExpress.XtraEditors.LabelControl();
            this.txtCode2 = new DevExpress.XtraEditors.TextEdit();
            this.lblCode2 = new DevExpress.XtraEditors.LabelControl();
            this.txtCode3 = new DevExpress.XtraEditors.TextEdit();
            this.lblCode3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.BtnDele = new Wis.Anes.Framework.Controls.MedButton();
            this.btnCancel = new Wis.Anes.Framework.Controls.MedButton();
            this.btnOK = new Wis.Anes.Framework.Controls.MedButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCode1
            // 
            this.txtCode1.Location = new System.Drawing.Point(70, 46);
            this.txtCode1.Name = "txtCode1";
            this.txtCode1.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCode1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtCode1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtCode1.Size = new System.Drawing.Size(149, 21);
            this.txtCode1.TabIndex = 2;
            this.txtCode1.TextChanged += new System.EventHandler(this.txtCode1_TextChanged);
            // 
            // lblCode1
            // 
            this.lblCode1.Location = new System.Drawing.Point(16, 47);
            this.lblCode1.Name = "lblCode1";
            this.lblCode1.Size = new System.Drawing.Size(0, 14);
            this.lblCode1.TabIndex = 11;
            // 
            // txtCode2
            // 
            this.txtCode2.Location = new System.Drawing.Point(70, 75);
            this.txtCode2.Name = "txtCode2";
            this.txtCode2.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCode2.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtCode2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtCode2.Size = new System.Drawing.Size(149, 21);
            this.txtCode2.TabIndex = 3;
            this.txtCode2.TextChanged += new System.EventHandler(this.txtCode1_TextChanged);
            // 
            // lblCode2
            // 
            this.lblCode2.Location = new System.Drawing.Point(16, 76);
            this.lblCode2.Name = "lblCode2";
            this.lblCode2.Size = new System.Drawing.Size(0, 14);
            this.lblCode2.TabIndex = 13;
            // 
            // txtCode3
            // 
            this.txtCode3.Location = new System.Drawing.Point(70, 105);
            this.txtCode3.Name = "txtCode3";
            this.txtCode3.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCode3.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtCode3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtCode3.Size = new System.Drawing.Size(149, 21);
            this.txtCode3.TabIndex = 4;
            this.txtCode3.TextChanged += new System.EventHandler(this.txtCode1_TextChanged);
            // 
            // lblCode3
            // 
            this.lblCode3.Location = new System.Drawing.Point(16, 106);
            this.lblCode3.Name = "lblCode3";
            this.lblCode3.Size = new System.Drawing.Size(0, 14);
            this.lblCode3.TabIndex = 15;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(16, 14);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(24, 14);
            this.labelControl4.TabIndex = 41;
            this.labelControl4.Text = "时间";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Enabled = false;
            this.dateEdit1.Location = new System.Drawing.Point(70, 11);
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
            this.dateEdit1.Size = new System.Drawing.Size(149, 21);
            this.dateEdit1.TabIndex = 1;
            // 
            // BtnDele
            // 
            this.BtnDele.ActionName = null;
            this.BtnDele.AutoImage = false;
            this.BtnDele.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnDele.BindControl = null;
            this.BtnDele.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDele.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnDele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDele.HasBorder = true;
            this.BtnDele.IsMenu = false;
            this.BtnDele.IsMouseHover = true;
            this.BtnDele.Location = new System.Drawing.Point(180, 143);
            this.BtnDele.MenuIndex = 0;
            this.BtnDele.Name = "BtnDele";
            this.BtnDele.PageName = null;
            this.BtnDele.Parameters = null;
            this.BtnDele.ShortcutKeys = null;
            this.BtnDele.ShowText = true;
            this.BtnDele.Size = new System.Drawing.Size(70, 25);
            this.BtnDele.TabIndex = 43;
            this.BtnDele.Text = "删除";
            this.BtnDele.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnDele.UseVisualStyleBackColor = true;
            this.BtnDele.Click += new System.EventHandler(this.BtnDele_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ActionName = null;
            this.btnCancel.AutoImage = false;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.BindControl = null;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.HasBorder = true;
            this.btnCancel.IsMenu = false;
            this.btnCancel.IsMouseHover = true;
            this.btnCancel.Location = new System.Drawing.Point(104, 143);
            this.btnCancel.MenuIndex = 0;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PageName = null;
            this.btnCancel.Parameters = null;
            this.btnCancel.ShortcutKeys = null;
            this.btnCancel.ShowText = true;
            this.btnCancel.Size = new System.Drawing.Size(70, 25);
            this.btnCancel.TabIndex = 40;
            this.btnCancel.Text = "取消";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.ActionName = null;
            this.btnOK.AutoImage = false;
            this.btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOK.BindControl = null;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.HasBorder = true;
            this.btnOK.IsMenu = false;
            this.btnOK.IsMouseHover = true;
            this.btnOK.Location = new System.Drawing.Point(28, 143);
            this.btnOK.MenuIndex = 0;
            this.btnOK.Name = "btnOK";
            this.btnOK.PageName = null;
            this.btnOK.Parameters = null;
            this.btnOK.ShortcutKeys = null;
            this.btnOK.ShowText = true;
            this.btnOK.Size = new System.Drawing.Size(70, 25);
            this.btnOK.TabIndex = 39;
            this.btnOK.Text = "确定";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // UserControl_BreathParas
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.BtnDele);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtCode3);
            this.Controls.Add(this.lblCode3);
            this.Controls.Add(this.txtCode2);
            this.Controls.Add(this.lblCode2);
            this.Controls.Add(this.txtCode1);
            this.Controls.Add(this.lblCode1);
            this.Name = "UserControl_BreathParas";
            this.Size = new System.Drawing.Size(265, 225);
            this.Load += new System.EventHandler(this.UserControl_BreathParas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtCode1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtCode1;
        private DevExpress.XtraEditors.LabelControl lblCode1;
        private DevExpress.XtraEditors.TextEdit txtCode2;
        private DevExpress.XtraEditors.LabelControl lblCode2;
        private DevExpress.XtraEditors.TextEdit txtCode3;
        private DevExpress.XtraEditors.LabelControl lblCode3;
        private Wis.Anes.Framework.Controls.MedButton btnCancel;
        private Wis.Anes.Framework.Controls.MedButton btnOK;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private Wis.Anes.Framework.Controls.MedButton BtnDele;
    }
}
