namespace CZZD.ERP.WinUI
{
    partial class NavigationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NavigationForm));
            this.menuAdd = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuDeskAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuDeskDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.pMain = new System.Windows.Forms.Panel();
            this.menuAdd.SuspendLayout();
            this.menuDelete.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuAdd
            // 
            this.menuAdd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDeskAdd});
            this.menuAdd.Name = "menuAdd";
            this.menuAdd.Size = new System.Drawing.Size(137, 26);
            // 
            // menuDeskAdd
            // 
            this.menuDeskAdd.Name = "menuDeskAdd";
            this.menuDeskAdd.Size = new System.Drawing.Size(136, 22);
            this.menuDeskAdd.Text = "发送到桌面";
            this.menuDeskAdd.Click += new System.EventHandler(this.menuDeskAdd_Click);
            // 
            // menuDelete
            // 
            this.menuDelete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDeskDelete});
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.Size = new System.Drawing.Size(101, 26);
            // 
            // menuDeskDelete
            // 
            this.menuDeskDelete.Name = "menuDeskDelete";
            this.menuDeskDelete.Size = new System.Drawing.Size(100, 22);
            this.menuDeskDelete.Text = "删除";
            this.menuDeskDelete.Click += new System.EventHandler(this.menuDeskDelete_Click);
            // 
            // pMain
            // 
            this.pMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMain.Location = new System.Drawing.Point(0, 0);
            this.pMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(1276, 998);
            this.pMain.TabIndex = 0;
            // 
            // NavigationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 998);
            this.Controls.Add(this.pMain);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NavigationForm";
            this.Load += new System.EventHandler(this.NavigationForm_Load);
            this.menuAdd.ResumeLayout(false);
            this.menuDelete.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.ContextMenuStrip menuAdd;
        private System.Windows.Forms.ToolStripMenuItem menuDeskAdd;
        private System.Windows.Forms.ContextMenuStrip menuDelete;
        private System.Windows.Forms.ToolStripMenuItem menuDeskDelete;
    }
}