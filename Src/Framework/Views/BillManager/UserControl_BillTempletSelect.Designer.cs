namespace Wis.Anes.Framework.Views.BillManager
{
    partial class UserControl_BillTempletSelect
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
            this.txtName = new Wis.Anes.Framework.Controls.MedTextBox();
            this.btnCancel = new Wis.Anes.Framework.Controls.MedButton();
            this.btnOK = new Wis.Anes.Framework.Controls.MedButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "模板名称：";
            // 
            // txtName
            // 
            this.txtName.BindFieldName = "";
            this.txtName.BindList = "";
            this.txtName.BindTableName = "";
            this.txtName.BorderColor = System.Drawing.Color.LightGray;
            this.txtName.BottomLine = false;
            this.txtName.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtName.CanEdit = true;
            this.txtName.CelerityInputCodeColumnName = "";
            this.txtName.CelerityInputSqlWhere = "";
            this.txtName.CelerityInputTableName = "";
            this.txtName.CelerityInputValueColumnName = "";
            this.txtName.Data = null;
            this.txtName.DefaultPrintText = "";
            this.txtName.DictTableName = "";
            this.txtName.DictValueFieldName = "";
            this.txtName.DictWhereString = "";
            this.txtName.DisplayFieldName = "";
            this.txtName.DotBorder = false;
            this.txtName.DotNumber = 0;
            this.txtName.ExamItemName = null;
            this.txtName.FieldName = "txtOpertionRoom";
            this.txtName.Format = "";
            this.txtName.HasLookUpItems = false;
            this.txtName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtName.InitValue = "";
            this.txtName.InputNeededMessage = "";
            this.txtName.InputType = Wis.Anes.Framework.Controls.MedInputType.General;
            this.txtName.LabItemName = null;
            this.txtName.LimitedString = "~!@#$%^&*()?<>\":";
            this.txtName.Location = new System.Drawing.Point(16, 34);
            this.txtName.LockInput = false;
            this.txtName.Maximum = null;
            this.txtName.MaxLength = 128;
            this.txtName.Minimum = null;
            this.txtName.Multiline = false;
            this.txtName.MultiSelect = false;
            this.txtName.MultiSign = false;
            this.txtName.Name = "txtName";
            this.txtName.NoPrint = false;
            this.txtName.NoPrintText = "";
            this.txtName.NullAble = true;
            this.txtName.OldForeColor = System.Drawing.Color.Black;
            this.txtName.PasswordChar = '\0';
            this.txtName.PrintTail = "";
            this.txtName.PrintXOffSet = 0F;
            this.txtName.PrintYOffSet = 0F;
            this.txtName.ProgramChanging = false;
            this.txtName.Properties.Appearance.Options.UseTextOptions = true;
            this.txtName.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtName.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtName.Properties.MaxLength = 128;
            this.txtName.ReadOnly = false;
            this.txtName.SelfValue = "";
            this.txtName.SelfValueChanged = false;
            this.txtName.Size = new System.Drawing.Size(288, 21);
            this.txtName.SourceFieldName = "";
            this.txtName.SourceTableName = "";
            this.txtName.StoredValue = "";
            this.txtName.TabIndex = 34;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtName.UnderLineOffset = 0F;
            this.txtName.WantValueBeforePrint = "";
            this.txtName.WordWrap = false;
            this.txtName.DoubleClick += new System.EventHandler(this.txtOpertionRoom_DoubleClick);
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
            this.btnCancel.Location = new System.Drawing.Point(181, 71);
            this.btnCancel.MenuIndex = 0;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PageName = null;
            this.btnCancel.Parameters = null;
            this.btnCancel.ShortcutKeys = null;
            this.btnCancel.ShowText = true;
            this.btnCancel.Size = new System.Drawing.Size(63, 25);
            this.btnCancel.TabIndex = 3;
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
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.HasBorder = true;
            this.btnOK.IsMenu = false;
            this.btnOK.IsMouseHover = true;
            this.btnOK.Location = new System.Drawing.Point(61, 71);
            this.btnOK.MenuIndex = 0;
            this.btnOK.Name = "btnOK";
            this.btnOK.PageName = null;
            this.btnOK.Parameters = null;
            this.btnOK.ShortcutKeys = null;
            this.btnOK.ShowText = true;
            this.btnOK.Size = new System.Drawing.Size(63, 25);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确定";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // UserControl_BillTempletSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label1);
            this.Name = "UserControl_BillTempletSelect";
            this.Size = new System.Drawing.Size(322, 118);
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Wis.Anes.Framework.Controls.MedButton btnOK;
        private Wis.Anes.Framework.Controls.MedTextBox txtName;
        private Wis.Anes.Framework.Controls.MedButton btnCancel;
    }
}
