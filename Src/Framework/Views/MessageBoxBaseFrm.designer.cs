
using Wis.Anes.Framework.Controls;
using Wis.Anes.Framework.Properties;

namespace Wis.Anes.Framework.Views
{
    partial class MessageBoxBaseFrm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageBoxBaseFrm));
            this.toolTipBase = new System.Windows.Forms.ToolTip(this.components);
            this.btnClose = new MedButtonEx();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.picTop = new System.Windows.Forms.PictureBox();
            this.picRight = new System.Windows.Forms.PictureBox();
            this.picLeft = new System.Windows.Forms.PictureBox();
            this.picBottom = new System.Windows.Forms.PictureBox();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBottom)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnClose.Location = new System.Drawing.Point(618, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(20, 21);
            this.btnClose.TabIndex = 11;
            this.btnClose.TabStop = false;
            this.toolTipBase.SetToolTip(this.btnClose, "关闭");
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.BackgroundImage = Resources.top_bg;
            this.pnlTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlTop.Controls.Add(this.btnClose);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlTop.Location = new System.Drawing.Point(2, 2);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(648, 31);
            this.pnlTop.TabIndex = 1;
            this.pnlTop.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTop_Paint);
            this.pnlTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseMove);
            this.pnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);
            this.pnlTop.Resize += new System.EventHandler(this.pnlTop_Resize);
            this.pnlTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseUp);
            // 
            // picTop
            // 
            this.picTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.picTop.Image = ((System.Drawing.Image)(resources.GetObject("picTop.Image")));
            this.picTop.Location = new System.Drawing.Point(2, 0);
            this.picTop.Name = "picTop";
            this.picTop.Size = new System.Drawing.Size(648, 2);
            this.picTop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTop.TabIndex = 21;
            this.picTop.TabStop = false;
            // 
            // picRight
            // 
            this.picRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.picRight.Image = ((System.Drawing.Image)(resources.GetObject("picRight.Image")));
            this.picRight.Location = new System.Drawing.Point(650, 0);
            this.picRight.Name = "picRight";
            this.picRight.Size = new System.Drawing.Size(2, 343);
            this.picRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRight.TabIndex = 20;
            this.picRight.TabStop = false;
            // 
            // picLeft
            // 
            this.picLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.picLeft.Image = ((System.Drawing.Image)(resources.GetObject("picLeft.Image")));
            this.picLeft.Location = new System.Drawing.Point(0, 0);
            this.picLeft.Name = "picLeft";
            this.picLeft.Size = new System.Drawing.Size(2, 343);
            this.picLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLeft.TabIndex = 19;
            this.picLeft.TabStop = false;
            // 
            // picBottom
            // 
            this.picBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.picBottom.Image = ((System.Drawing.Image)(resources.GetObject("picBottom.Image")));
            this.picBottom.Location = new System.Drawing.Point(2, 341);
            this.picBottom.Name = "picBottom";
            this.picBottom.Size = new System.Drawing.Size(648, 2);
            this.picBottom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBottom.TabIndex = 22;
            this.picBottom.TabStop = false;
            // 
            // MessageBoxBaseFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(652, 343);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.picBottom);
            this.Controls.Add(this.picTop);
            this.Controls.Add(this.picRight);
            this.Controls.Add(this.picLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MessageBoxBaseFrm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MessageBoxBaseFrm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.BaseFrm_Load);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBottom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTipBase;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.PictureBox picTop;
        private System.Windows.Forms.PictureBox picRight;
        private System.Windows.Forms.PictureBox picLeft;
        private MedButtonEx btnClose;
        private System.Windows.Forms.PictureBox picBottom;

    }
}