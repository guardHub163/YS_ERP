namespace CZZD.ERP.ComControls
{
    partial class PageControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageControl));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.menuFirst = new System.Windows.Forms.ToolStripButton();
            this.menuPrev = new System.Windows.Forms.ToolStripButton();
            this.menuNext = new System.Windows.Forms.ToolStripButton();
            this.menuLast = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.lblCurrentPage = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.lblTotalPage = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.txtCurrentPage = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.menuGoto = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFirst,
            this.menuPrev,
            this.menuNext,
            this.menuLast,
            this.toolStripLabel1,
            this.lblCurrentPage,
            this.toolStripLabel3,
            this.lblTotalPage,
            this.toolStripLabel5,
            this.txtCurrentPage,
            this.toolStripLabel6,
            this.menuGoto});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 3, 1, 0);
            this.toolStrip1.Size = new System.Drawing.Size(784, 33);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // menuFirst
            // 
            this.menuFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuFirst.Enabled = false;
            this.menuFirst.Image = ((System.Drawing.Image)(resources.GetObject("menuFirst.Image")));
            this.menuFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuFirst.Name = "menuFirst";
            this.menuFirst.Size = new System.Drawing.Size(53, 27);
            this.menuFirst.Text = " 首 页 ";
            this.menuFirst.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menuPrev
            // 
            this.menuPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuPrev.Enabled = false;
            this.menuPrev.Image = ((System.Drawing.Image)(resources.GetObject("menuPrev.Image")));
            this.menuPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuPrev.Name = "menuPrev";
            this.menuPrev.Size = new System.Drawing.Size(71, 27);
            this.menuPrev.Text = " 上 一 页 ";
            this.menuPrev.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menuNext
            // 
            this.menuNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuNext.Enabled = false;
            this.menuNext.Image = ((System.Drawing.Image)(resources.GetObject("menuNext.Image")));
            this.menuNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuNext.Name = "menuNext";
            this.menuNext.Size = new System.Drawing.Size(71, 27);
            this.menuNext.Text = " 下 一 页 ";
            this.menuNext.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menuLast
            // 
            this.menuLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuLast.Enabled = false;
            this.menuLast.Image = ((System.Drawing.Image)(resources.GetObject("menuLast.Image")));
            this.menuLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuLast.Name = "menuLast";
            this.menuLast.Size = new System.Drawing.Size(53, 27);
            this.menuLast.Text = " 尾 页 ";
            this.menuLast.Click += new System.EventHandler(this.Menu_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(43, 27);
            this.toolStripLabel1.Text = "     第";
            // 
            // lblCurrentPage
            // 
            this.lblCurrentPage.AutoSize = false;
            this.lblCurrentPage.Name = "lblCurrentPage";
            this.lblCurrentPage.Size = new System.Drawing.Size(40, 22);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(73, 27);
            this.toolStripLabel3.Text = "页         共";
            // 
            // lblTotalPage
            // 
            this.lblTotalPage.AutoSize = false;
            this.lblTotalPage.Name = "lblTotalPage";
            this.lblTotalPage.Size = new System.Drawing.Size(40, 22);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(79, 27);
            this.toolStripLabel5.Text = "页      跳到 ";
            // 
            // txtCurrentPage
            // 
            this.txtCurrentPage.BackColor = System.Drawing.SystemColors.Info;
            this.txtCurrentPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurrentPage.Name = "txtCurrentPage";
            this.txtCurrentPage.Size = new System.Drawing.Size(100, 30);
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(17, 27);
            this.toolStripLabel6.Text = "  ";
            // 
            // menuGoto
            // 
            this.menuGoto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuGoto.Image = ((System.Drawing.Image)(resources.GetObject("menuGoto.Image")));
            this.menuGoto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuGoto.Name = "menuGoto";
            this.menuGoto.Size = new System.Drawing.Size(46, 27);
            this.menuGoto.Text = "Goto";
            this.menuGoto.Click += new System.EventHandler(this.Menu_Click);
            // 
            // PageControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.toolStrip1);
            this.Name = "PageControl";
            this.Size = new System.Drawing.Size(784, 33);
            this.Load += new System.EventHandler(this.PageControl_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton menuFirst;
        private System.Windows.Forms.ToolStripButton menuPrev;
        private System.Windows.Forms.ToolStripButton menuNext;
        private System.Windows.Forms.ToolStripButton menuLast;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel lblCurrentPage;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel lblTotalPage;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripTextBox txtCurrentPage;
        private System.Windows.Forms.ToolStripButton menuGoto;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
    }
}
