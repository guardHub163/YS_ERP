namespace CZZD.ERP.WinUI
{
    partial class FrmChoseReceipt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChoseReceipt));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rNoInstallments = new System.Windows.Forms.RadioButton();
            this.DueData = new System.Windows.Forms.DateTimePicker();
            this.rInstallments = new System.Windows.Forms.RadioButton();
            this.btnSava = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 200);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.rNoInstallments);
            this.panel3.Controls.Add(this.DueData);
            this.panel3.Controls.Add(this.rInstallments);
            this.panel3.Controls.Add(this.btnSava);
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(139, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(359, 198);
            this.panel3.TabIndex = 60;
            // 
            // rNoInstallments
            // 
            this.rNoInstallments.AutoSize = true;
            this.rNoInstallments.Location = new System.Drawing.Point(116, 5);
            this.rNoInstallments.Name = "rNoInstallments";
            this.rNoInstallments.Size = new System.Drawing.Size(83, 24);
            this.rNoInstallments.TabIndex = 1;
            this.rNoInstallments.Text = "残数删除";
            this.rNoInstallments.UseVisualStyleBackColor = true;
            // 
            // DueData
            // 
            this.DueData.CalendarFont = new System.Drawing.Font("微软雅黑", 10F);
            this.DueData.CustomFormat = "yyyy-MM-dd";
            this.DueData.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.DueData.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DueData.Location = new System.Drawing.Point(5, 35);
            this.DueData.Name = "DueData";
            this.DueData.Size = new System.Drawing.Size(208, 25);
            this.DueData.TabIndex = 60;
            this.DueData.Value = new System.DateTime(2013, 5, 11, 17, 49, 49, 0);
            // 
            // rInstallments
            // 
            this.rInstallments.AutoSize = true;
            this.rInstallments.Checked = true;
            this.rInstallments.Location = new System.Drawing.Point(5, 5);
            this.rInstallments.Name = "rInstallments";
            this.rInstallments.Size = new System.Drawing.Size(83, 24);
            this.rInstallments.TabIndex = 0;
            this.rInstallments.TabStop = true;
            this.rInstallments.Text = "分期入库";
            this.rInstallments.UseVisualStyleBackColor = true;
            // 
            // btnSava
            // 
            this.btnSava.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSava.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSava.Location = new System.Drawing.Point(170, 165);
            this.btnSava.Name = "btnSava";
            this.btnSava.Size = new System.Drawing.Size(90, 30);
            this.btnSava.TabIndex = 1;
            this.btnSava.Text = "确   定";
            this.btnSava.UseVisualStyleBackColor = true;
            this.btnSava.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnCancel.Location = new System.Drawing.Point(266, 165);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取   消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(139, 198);
            this.panel2.TabIndex = 59;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.SteelBlue;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(5, 5);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(114, 20);
            this.label16.TabIndex = 60;
            this.label16.Text = " 残数处理：";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.SteelBlue;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(5, 35);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(114, 20);
            this.label13.TabIndex = 52;
            this.label13.Text = " 预定入库日期：";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.SteelBlue;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(3, 461);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 20);
            this.label9.TabIndex = 40;
            this.label9.Text = " 是否组成品：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.SteelBlue;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(3, 492);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(110, 20);
            this.label14.TabIndex = 44;
            this.label14.Text = " 安全在库数：";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmChoseReceipt
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(500, 200);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChoseReceipt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "分期选择";
            this.Load += new System.EventHandler(this.FrmChoseReceipt_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmChoseReceipt_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rNoInstallments;
        private System.Windows.Forms.RadioButton rInstallments;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSava;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker DueData;
        private System.Windows.Forms.Panel panel3;
    }
}