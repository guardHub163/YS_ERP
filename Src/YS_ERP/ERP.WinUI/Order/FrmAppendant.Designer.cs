namespace CZZD.ERP.WinUI
{
    partial class FrmAppendant
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAppendant));
            this.pOperater = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tabControls = new System.Windows.Forms.TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pOperater.SuspendLayout();
            this.SuspendLayout();
            // 
            // pOperater
            // 
            this.pOperater.Controls.Add(this.btnCancel);
            this.pOperater.Controls.Add(this.btnOk);
            this.pOperater.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pOperater.Location = new System.Drawing.Point(0, 355);
            this.pOperater.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pOperater.Name = "pOperater";
            this.pOperater.Size = new System.Drawing.Size(577, 42);
            this.pOperater.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnCancel.Location = new System.Drawing.Point(484, 5);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取　消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnOk.Location = new System.Drawing.Point(390, 5);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(90, 30);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "确　定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tabControls
            // 
            this.tabControls.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControls.HotTrack = true;
            this.tabControls.Location = new System.Drawing.Point(0, 2);
            this.tabControls.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControls.Multiline = true;
            this.tabControls.Name = "tabControls";
            this.tabControls.SelectedIndex = 0;
            this.tabControls.Size = new System.Drawing.Size(577, 353);
            this.tabControls.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(577, 2);
            this.panel1.TabIndex = 2;
            // 
            // FrmAppendant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(577, 397);
            this.Controls.Add(this.tabControls);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pOperater);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmAppendant";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "附属品选择";
            this.Load += new System.EventHandler(this.FrmAppendant_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAppendant_FormClosed);
            this.pOperater.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pOperater;
        private System.Windows.Forms.TabControl tabControls;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel panel1;
    }
}