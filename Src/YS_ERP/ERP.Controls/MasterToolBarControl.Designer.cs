namespace CZZD.ERP.ComControls
{
    partial class MasterToolBarControl
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
            this.MasterToolBar = new System.Windows.Forms.ToolStrip();
            this.menuNew = new System.Windows.Forms.ToolStripButton();
            this.menuCopy = new System.Windows.Forms.ToolStripButton();
            this.menuModify = new System.Windows.Forms.ToolStripButton();
            this.menuDelete = new System.Windows.Forms.ToolStripButton();
            this.menuSearch = new System.Windows.Forms.ToolStripButton();
            this.menuExport = new System.Windows.Forms.ToolStripButton();
            this.menuCancel = new System.Windows.Forms.ToolStripButton();
            this.MasterToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // MasterToolBar
            // 
            this.MasterToolBar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MasterToolBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MasterToolBar.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.MasterToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNew,
            this.menuCopy,
            this.menuModify,
            this.menuDelete,
            this.menuSearch,
            this.menuExport,
            this.menuCancel});
            this.MasterToolBar.Location = new System.Drawing.Point(0, 0);
            this.MasterToolBar.Name = "MasterToolBar";
            this.MasterToolBar.Size = new System.Drawing.Size(729, 30);
            this.MasterToolBar.TabIndex = 1;
            this.MasterToolBar.Text = "toolStrip1";
            // 
            // menuNew
            // 
            this.menuNew.AutoSize = false;
            this.menuNew.Image = global::CZZD.ERP.ComControls.Properties.Resources._new;
            this.menuNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuNew.Name = "menuNew";
            this.menuNew.Size = new System.Drawing.Size(50, 27);
            this.menuNew.Text = "新建";
            this.menuNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.menuNew.Click += new System.EventHandler(this.menuNew_Click);
            // 
            // menuCopy
            // 
            this.menuCopy.Enabled = false;
            this.menuCopy.Image = global::CZZD.ERP.ComControls.Properties.Resources.save;
            this.menuCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuCopy.Name = "menuCopy";
            this.menuCopy.Size = new System.Drawing.Size(57, 27);
            this.menuCopy.Text = "复制";
            this.menuCopy.Click += new System.EventHandler(this.menuCopy_Click);
            // 
            // menuModify
            // 
            this.menuModify.Enabled = false;
            this.menuModify.Image = global::CZZD.ERP.ComControls.Properties.Resources.modify;
            this.menuModify.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuModify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuModify.Name = "menuModify";
            this.menuModify.Size = new System.Drawing.Size(57, 27);
            this.menuModify.Text = "修改";
            this.menuModify.Click += new System.EventHandler(this.menuModify_Click);
            // 
            // menuDelete
            // 
            this.menuDelete.Enabled = false;
            this.menuDelete.Image = global::CZZD.ERP.ComControls.Properties.Resources.delete;
            this.menuDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.Size = new System.Drawing.Size(57, 27);
            this.menuDelete.Text = "删除";
            this.menuDelete.Click += new System.EventHandler(this.menuDelete_Click);
            // 
            // menuSearch
            // 
            this.menuSearch.Image = global::CZZD.ERP.ComControls.Properties.Resources.search;
            this.menuSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuSearch.Name = "menuSearch";
            this.menuSearch.Size = new System.Drawing.Size(57, 27);
            this.menuSearch.Text = "查询";
            this.menuSearch.Click += new System.EventHandler(this.menuSearch_Click);
            // 
            // menuExport
            // 
            this.menuExport.Enabled = false;
            this.menuExport.Image = global::CZZD.ERP.ComControls.Properties.Resources.export;
            this.menuExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuExport.Name = "menuExport";
            this.menuExport.Size = new System.Drawing.Size(57, 27);
            this.menuExport.Text = "导出";
            this.menuExport.Visible = false;
            this.menuExport.Click += new System.EventHandler(this.menuExport_Click);
            // 
            // menuCancel
            // 
            this.menuCancel.Image = global::CZZD.ERP.ComControls.Properties.Resources.cancel;
            this.menuCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuCancel.Name = "menuCancel";
            this.menuCancel.Size = new System.Drawing.Size(57, 27);
            this.menuCancel.Text = "关闭";
            this.menuCancel.Click += new System.EventHandler(this.menuCancel_Click);
            // 
            // MasterToolBarControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.MasterToolBar);
            this.Name = "MasterToolBarControl";
            this.Size = new System.Drawing.Size(729, 30);
            this.MasterToolBar.ResumeLayout(false);
            this.MasterToolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip MasterToolBar;
        private System.Windows.Forms.ToolStripButton menuNew;
        private System.Windows.Forms.ToolStripButton menuModify;
        private System.Windows.Forms.ToolStripButton menuDelete;
        private System.Windows.Forms.ToolStripButton menuCopy;
        private System.Windows.Forms.ToolStripButton menuExport;
        private System.Windows.Forms.ToolStripButton menuSearch;
        private System.Windows.Forms.ToolStripButton menuCancel;
    }
}
