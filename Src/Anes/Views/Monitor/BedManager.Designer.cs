namespace Wis.Anes.Views
{
    partial class BedManager
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnAllRoom = new Wis.Anes.Framework.Controls.MedButton();
            this.dateTimePickerQuery = new System.Windows.Forms.DateTimePicker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnAllRoom);
            this.panel4.Controls.Add(this.dateTimePickerQuery);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(596, 26);
            this.panel4.TabIndex = 165;
            this.panel4.Visible = false;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // btnAllRoom
            // 
            this.btnAllRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAllRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllRoom.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAllRoom.Location = new System.Drawing.Point(191, 3);
            this.btnAllRoom.Name = "btnAllRoom";
            this.btnAllRoom.Size = new System.Drawing.Size(90, 21);
            this.btnAllRoom.TabIndex = 157;
            this.btnAllRoom.Text = "所有手术间";
            this.btnAllRoom.UseVisualStyleBackColor = true;
            this.btnAllRoom.Visible = false;
            // 
            // dateTimePickerQuery
            // 
            this.dateTimePickerQuery.CustomFormat = "yyyy-MM-dd";
            this.dateTimePickerQuery.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePickerQuery.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerQuery.Location = new System.Drawing.Point(70, 3);
            this.dateTimePickerQuery.Name = "dateTimePickerQuery";
            this.dateTimePickerQuery.Size = new System.Drawing.Size(91, 21);
            this.dateTimePickerQuery.TabIndex = 36;
            this.dateTimePickerQuery.ValueChanged += new System.EventHandler(this.dateTimePickerQuery_ValueChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BedManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel4);
            this.Name = "BedManager";
            this.Size = new System.Drawing.Size(596, 435);
            this.Load += new System.EventHandler(this.BedManager_Load);
            this.Resize += new System.EventHandler(this.BedManager_Resize);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private Wis.Anes.Framework.Controls.MedButton btnAllRoom;
        private System.Windows.Forms.DateTimePicker dateTimePickerQuery;
        private System.Windows.Forms.Timer timer1;

    }
}
