namespace Wis.Anes.Framework
{
    partial class SetNewEventTemplet
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
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.btnCancel = new Wis.Anes.Framework.Controls.MedButton();
            this.btnOK = new Wis.Anes.Framework.Controls.MedButton();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(33, 31);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "麻醉方法：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(281, 31);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(82, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "模板名(必填)：";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(33, 51);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(211, 21);
            this.textEdit1.TabIndex = 42;
            this.textEdit1.DoubleClick += new System.EventHandler(this.textEdit1_DoubleClick);
            this.textEdit1.TextChanged += new System.EventHandler(this.textEdit1_TextChanged);
            // 
            // textEdit2
            // 
            this.textEdit2.Location = new System.Drawing.Point(281, 51);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new System.Drawing.Size(211, 21);
            this.textEdit2.TabIndex = 42;
            this.textEdit2.TextChanged += new System.EventHandler(this.textEdit2_TextChanged);
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(31, 87);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "是否私有";
            this.checkEdit1.Size = new System.Drawing.Size(75, 19);
            this.checkEdit1.TabIndex = 43;
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
            this.btnCancel.Location = new System.Drawing.Point(417, 89);
            this.btnCancel.MenuIndex = 0;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PageName = null;
            this.btnCancel.Parameters = null;
            this.btnCancel.ShortcutKeys = null;
            this.btnCancel.ShowText = true;
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 41;
            this.btnCancel.Text = "取消";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
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
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.HasBorder = true;
            this.btnOK.IsMenu = false;
            this.btnOK.IsMouseHover = true;
            this.btnOK.Location = new System.Drawing.Point(324, 89);
            this.btnOK.MenuIndex = 0;
            this.btnOK.Name = "btnOK";
            this.btnOK.PageName = null;
            this.btnOK.Parameters = null;
            this.btnOK.ShortcutKeys = null;
            this.btnOK.ShowText = true;
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 40;
            this.btnOK.Text = "确定";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Visible = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // SetNewEventTemplet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkEdit1);
            this.Controls.Add(this.textEdit2);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "SetNewEventTemplet";
            this.Size = new System.Drawing.Size(524, 147);
            this.Load += new System.EventHandler(this.SetNewEventTemplet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private Wis.Anes.Framework.Controls.MedButton btnCancel;
        private Wis.Anes.Framework.Controls.MedButton btnOK;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
    }
}
