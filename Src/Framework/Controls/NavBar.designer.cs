using Wis.Anes.Framework.Properties;

namespace Wis.Anes.Framework.Controls
{
    partial class NavBar
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
            this.navBarItemContainer = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // navBarItemContainer
            // 
            this.navBarItemContainer.AutoScroll = true;
            this.navBarItemContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarItemContainer.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.navBarItemContainer.Location = new System.Drawing.Point(0, 0);
            this.navBarItemContainer.Name = "navBarItemContainer";
            this.navBarItemContainer.Size = new System.Drawing.Size(111, 453);
            this.navBarItemContainer.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.Gainsboro;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Image = Resources.收缩;
            this.label3.Location = new System.Drawing.Point(109, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(8, 37);
            this.label3.TabIndex = 0;
            this.label3.Tag = "<";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(111, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2, 453);
            this.label1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(113, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1, 453);
            this.label2.TabIndex = 2;
            // 
            // NavBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.navBarItemContainer);
            this.DoubleBuffered = true;
            this.Name = "NavBar";
            this.Size = new System.Drawing.Size(117, 453);
            this.SizeChanged += new System.EventHandler(this.NavBar_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel navBarItemContainer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

    }
}
