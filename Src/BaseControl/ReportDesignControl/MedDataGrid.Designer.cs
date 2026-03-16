namespace Com.ICIS.Common.Controls
{
    partial class MedDataGrid
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNextPage = new Com.MedicalSystem.Common.Controls.MedButton();
            this.btnPreviousPage = new Com.MedicalSystem.Common.Controls.MedButton();
            this.lbalPageNo = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnNextPage);
            this.panel1.Controls.Add(this.btnPreviousPage);
            this.panel1.Controls.Add(this.lbalPageNo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 341);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(545, 33);
            this.panel1.TabIndex = 1;
            // 
            // btnNextPage
            // 
            this.btnNextPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            //this.btnNextPage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNextPage.Location = new System.Drawing.Point(491, 5);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(51, 23);
            this.btnNextPage.TabIndex = 3;
            this.btnNextPage.Text = "下一页";
            //this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            //this.btnPreviousPage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPreviousPage.Location = new System.Drawing.Point(440, 5);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Size = new System.Drawing.Size(51, 23);
            this.btnPreviousPage.TabIndex = 2;
            this.btnPreviousPage.Text = "上一页";
            //this.btnPreviousPage.UseVisualStyleBackColor = true;
            this.btnPreviousPage.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbalPageNo
            // 
            this.lbalPageNo.AutoSize = true;
            this.lbalPageNo.Location = new System.Drawing.Point(51, 10);
            this.lbalPageNo.Name = "lbalPageNo";
            this.lbalPageNo.Size = new System.Drawing.Size(0, 12);
            this.lbalPageNo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "页码：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(545, 341);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
            this.dataGridView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseMove);
            this.dataGridView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseUp);
            this.dataGridView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragEnter);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            this.dataGridView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragDrop);
            // 
            // MedDataGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "MedDataGridView";
            this.Size = new System.Drawing.Size(545, 374);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Com.MedicalSystem.Common.Controls.MedButton btnNextPage;
        private Com.MedicalSystem.Common.Controls.MedButton btnPreviousPage;
        private DevExpress.XtraEditors.LabelControl lbalPageNo;
        private DevExpress.XtraEditors.LabelControl label1;
        public System.Windows.Forms.DataGridView dataGridView1;



    }
}
