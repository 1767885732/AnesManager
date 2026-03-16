namespace Wis.Anes.Framework.Views.Process
{
    partial class PacuRoomStatus
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
            this.pnlBody = new DevExpress.XtraEditors.PanelControl();
            this.label18 = new System.Windows.Forms.Label();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelControlMain = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).BeginInit();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlBody.Controls.Add(this.label18);
            this.pnlBody.Controls.Add(this.pictureBox10);
            this.pnlBody.Controls.Add(this.label2);
            this.pnlBody.Controls.Add(this.pictureBox2);
            this.pnlBody.Controls.Add(this.dateEdit1);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1600, 60);
            this.pnlBody.TabIndex = 7;
            this.pnlBody.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBody_Paint);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(312, 7);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(31, 14);
            this.label18.TabIndex = 106;
            this.label18.Text = "带管";
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.pictureBox10.Location = new System.Drawing.Point(200, 5);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(24, 18);
            this.pictureBox10.TabIndex = 105;
            this.pictureBox10.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 14);
            this.label2.TabIndex = 104;
            this.label2.Text = "不带管";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.pictureBox2.Location = new System.Drawing.Point(285, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 18);
            this.pictureBox2.TabIndex = 103;
            this.pictureBox2.TabStop = false;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(7, 5);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(129, 21);
            this.dateEdit1.TabIndex = 93;
            this.dateEdit1.EditValueChanged += new System.EventHandler(this.dateEdit1_EditValueChanged);
            // 
            // timerRefresh
            // 
            this.timerRefresh.Enabled = true;
            this.timerRefresh.Interval = 60000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1600F));
            this.tableLayoutPanel1.Controls.Add(this.pnlBody, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelControlMain, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1500, 363);
            this.tableLayoutPanel1.TabIndex = 9;
            this.tableLayoutPanel1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.tableLayoutPanel1_Scroll);
            // 
            // panelControlMain
            // 
            this.panelControlMain.AutoScroll = true;
            this.panelControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlMain.Location = new System.Drawing.Point(0, 60);
            this.panelControlMain.Margin = new System.Windows.Forms.Padding(0);
            this.panelControlMain.Name = "panelControlMain";
            this.panelControlMain.Size = new System.Drawing.Size(1600, 303);
            this.panelControlMain.TabIndex = 8;
            // 
            // PacuRoomStatus
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Caption = "实时状态";
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PacuRoomStatus";
            this.Size = new System.Drawing.Size(1500, 363);
            this.Load += new System.EventHandler(this.OperationRoomStatus2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlBody;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelControlMain;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;

    }
}
