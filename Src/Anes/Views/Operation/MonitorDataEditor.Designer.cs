namespace Wis.Anes.Views
{
    partial class MonitorDataEditor
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.txtInterval = new Wis.Anes.Framework.Controls.MedTextBox();
            this.btnCancel = new Wis.Anes.Framework.Controls.MedButton();
            this.btnOK = new Wis.Anes.Framework.Controls.MedButton();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterval.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 18);
            this.label1.TabIndex = 29;
            this.label1.Text = "开始时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(287, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 18);
            this.label2.TabIndex = 31;
            this.label2.Text = "结束时间";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 18);
            this.label3.TabIndex = 32;
            this.label3.Text = "时间间隔";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(287, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 18);
            this.label4.TabIndex = 34;
            this.label4.Text = "秒";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(24, 553);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 18);
            this.lblMessage.TabIndex = 45;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(118, 13);
            this.dateEdit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.dateEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit1.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm";
            this.dateEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateEdit1.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.dateEdit1.Size = new System.Drawing.Size(161, 24);
            this.dateEdit1.TabIndex = 0;
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(366, 13);
            this.dateEdit2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit2.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.dateEdit2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit2.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm";
            this.dateEdit2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateEdit2.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.dateEdit2.Size = new System.Drawing.Size(161, 24);
            this.dateEdit2.TabIndex = 1;
            // 
            // txtInterval
            // 
            this.txtInterval.BindFieldName = "";
            this.txtInterval.BindList = "";
            this.txtInterval.BindTableName = "";
            this.txtInterval.BorderColor = System.Drawing.Color.LightGray;
            this.txtInterval.BottomLine = false;
            this.txtInterval.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtInterval.CanEdit = true;
            this.txtInterval.CelerityInputCodeColumnName = "";
            this.txtInterval.CelerityInputSqlWhere = "";
            this.txtInterval.CelerityInputTableName = "";
            this.txtInterval.CelerityInputValueColumnName = "";
            this.txtInterval.Data = null;
            this.txtInterval.DefaultPrintText = "";
            this.txtInterval.DictTableName = "";
            this.txtInterval.DictValueFieldName = "";
            this.txtInterval.DictWhereString = "";
            this.txtInterval.DisplayFieldName = "";
            this.txtInterval.DisplayMutiColFieldName = "";
            this.txtInterval.DotBorder = false;
            this.txtInterval.DotNumber = 0;
            this.txtInterval.EditValue = "300";
            this.txtInterval.ExamItemName = null;
            this.txtInterval.FieldName = "txtInterval";
            this.txtInterval.Format = "";
            this.txtInterval.HasLookUpItems = false;
            this.txtInterval.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtInterval.InitValue = "";
            this.txtInterval.InputNeededMessage = "";
            this.txtInterval.InputType = Wis.Anes.Framework.Controls.MedInputType.Integer;
            this.txtInterval.LabItemName = null;
            this.txtInterval.LimitedString = "";
            this.txtInterval.Location = new System.Drawing.Point(118, 55);
            this.txtInterval.LockInput = false;
            this.txtInterval.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtInterval.Maximum = null;
            this.txtInterval.MaxLength = 0;
            this.txtInterval.Minimum = null;
            this.txtInterval.Multiline = false;
            this.txtInterval.MultiSelect = false;
            this.txtInterval.MultiSign = false;
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.NoPrint = false;
            this.txtInterval.NoPrintText = "";
            this.txtInterval.NullAble = true;
            this.txtInterval.OldForeColor = System.Drawing.Color.Black;
            this.txtInterval.PasswordChar = '\0';
            this.txtInterval.PrintTail = "";
            this.txtInterval.PrintXOffSet = 0F;
            this.txtInterval.PrintYOffSet = 0F;
            this.txtInterval.ProgramChanging = false;
            this.txtInterval.Properties.Appearance.Options.UseTextOptions = true;
            this.txtInterval.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtInterval.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtInterval.SelfValue = "";
            this.txtInterval.SelfValueChanged = false;
            this.txtInterval.Size = new System.Drawing.Size(161, 24);
            this.txtInterval.SourceFieldName = "";
            this.txtInterval.SourceTableName = "";
            this.txtInterval.StoredValue = "";
            this.txtInterval.TabIndex = 2;
            this.txtInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtInterval.UnderLineOffset = 0F;
            this.txtInterval.WantValueBeforePrint = "";
            this.txtInterval.WordWrap = false;
            // 
            // btnCancel
            // 
            this.btnCancel.ActionName = null;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoImage = false;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.BindControl = null;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.HasBorder = true;
            this.btnCancel.IsMenu = false;
            this.btnCancel.IsMouseHover = true;
            this.btnCancel.Location = new System.Drawing.Point(539, 553);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.MenuIndex = 0;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PageName = null;
            this.btnCancel.Parameters = null;
            this.btnCancel.ShortcutKeys = null;
            this.btnCancel.ShowText = true;
            this.btnCancel.Size = new System.Drawing.Size(99, 35);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "取消";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.ActionName = null;
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnOK.Location = new System.Drawing.Point(419, 553);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.MenuIndex = 0;
            this.btnOK.Name = "btnOK";
            this.btnOK.PageName = null;
            this.btnOK.Parameters = null;
            this.btnOK.ShortcutKeys = null;
            this.btnOK.ShowText = true;
            this.btnOK.Size = new System.Drawing.Size(99, 35);
            this.btnOK.TabIndex = 26;
            this.btnOK.Text = "确定";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(363, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 18);
            this.label5.TabIndex = 46;
            // 
            // MonitorDataEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateEdit2);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtInterval);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MonitorDataEditor";
            this.Size = new System.Drawing.Size(673, 666);
            this.Load += new System.EventHandler(this.MonitorDataEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterval.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wis.Anes.Framework.Controls.MedButton btnOK;
        private Wis.Anes.Framework.Controls.MedButton btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Wis.Anes.Framework.Controls.MedTextBox txtInterval;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMessage;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private System.Windows.Forms.Label label5;
    }
}
