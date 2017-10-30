namespace CZZD.ERP.WinUI
{
    partial class FrmCustomerReportedDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomerReportedDialog));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnReported = new System.Windows.Forms.Button();
            this.EffectiveDate = new System.Windows.Forms.DateTimePicker();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtReportedName = new System.Windows.Forms.TextBox();
            this.ReportedDate = new System.Windows.Forms.DateTimePicker();
            this.txtReported = new System.Windows.Forms.TextBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(442, 185);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnCustomer);
            this.panel3.Controls.Add(this.btnReported);
            this.panel3.Controls.Add(this.EffectiveDate);
            this.panel3.Controls.Add(this.txtCustomerName);
            this.panel3.Controls.Add(this.txtReportedName);
            this.panel3.Controls.Add(this.ReportedDate);
            this.panel3.Controls.Add(this.txtReported);
            this.panel3.Controls.Add(this.txtCustomer);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(120, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(318, 181);
            this.panel3.TabIndex = 1;
            // 
            // btnCustomer
            // 
            this.btnCustomer.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCustomer.FlatAppearance.BorderSize = 0;
            this.btnCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomer.Location = new System.Drawing.Point(261, 3);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(25, 25);
            this.btnCustomer.TabIndex = 8;
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.MouseLeave += new System.EventHandler(this.btnSearch_MouseLeave);
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            this.btnCustomer.MouseEnter += new System.EventHandler(this.btnSearch_MouseEnter);
            // 
            // btnReported
            // 
            this.btnReported.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnReported.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReported.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReported.FlatAppearance.BorderSize = 0;
            this.btnReported.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnReported.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnReported.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReported.Location = new System.Drawing.Point(261, 63);
            this.btnReported.Name = "btnReported";
            this.btnReported.Size = new System.Drawing.Size(25, 25);
            this.btnReported.TabIndex = 7;
            this.btnReported.UseVisualStyleBackColor = true;
            this.btnReported.MouseLeave += new System.EventHandler(this.btnSearch_MouseLeave);
            this.btnReported.Click += new System.EventHandler(this.btnReported_Click);
            this.btnReported.MouseEnter += new System.EventHandler(this.btnSearch_MouseEnter);
            // 
            // EffectiveDate
            // 
            this.EffectiveDate.CustomFormat = "yyyy-MM-dd";
            this.EffectiveDate.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EffectiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EffectiveDate.Location = new System.Drawing.Point(5, 155);
            this.EffectiveDate.Name = "EffectiveDate";
            this.EffectiveDate.Size = new System.Drawing.Size(250, 23);
            this.EffectiveDate.TabIndex = 6;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerName.Enabled = false;
            this.txtCustomerName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCustomerName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtCustomerName.Location = new System.Drawing.Point(5, 35);
            this.txtCustomerName.MaxLength = 20;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(250, 23);
            this.txtCustomerName.TabIndex = 5;
            // 
            // txtReportedName
            // 
            this.txtReportedName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtReportedName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReportedName.Enabled = false;
            this.txtReportedName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtReportedName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtReportedName.Location = new System.Drawing.Point(5, 95);
            this.txtReportedName.MaxLength = 20;
            this.txtReportedName.Name = "txtReportedName";
            this.txtReportedName.Size = new System.Drawing.Size(250, 23);
            this.txtReportedName.TabIndex = 4;
            // 
            // ReportedDate
            // 
            this.ReportedDate.CustomFormat = "yyyy-MM-dd";
            this.ReportedDate.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ReportedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ReportedDate.Location = new System.Drawing.Point(5, 125);
            this.ReportedDate.Name = "ReportedDate";
            this.ReportedDate.Size = new System.Drawing.Size(250, 23);
            this.ReportedDate.TabIndex = 3;
            this.ReportedDate.Leave += new System.EventHandler(this.ReportedDate_Leave);
            this.ReportedDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.ReportedDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // txtReported
            // 
            this.txtReported.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtReported.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReported.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtReported.Location = new System.Drawing.Point(5, 65);
            this.txtReported.MaxLength = 20;
            this.txtReported.Name = "txtReported";
            this.txtReported.Size = new System.Drawing.Size(250, 23);
            this.txtReported.TabIndex = 1;
            this.txtReported.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtReported.Leave += new System.EventHandler(this.txtReported_Leave);
            this.txtReported.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomer.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCustomer.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtCustomer.Location = new System.Drawing.Point(5, 5);
            this.txtCustomer.MaxLength = 20;
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(250, 23);
            this.txtCustomer.TabIndex = 0;
            this.txtCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtCustomer.Leave += new System.EventHandler(this.txtCustomer_Leave);
            this.txtCustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(120, 181);
            this.panel2.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(5, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "客户报备名称：";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "报  备   时  间：";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "代 理 店名 称：";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "有  效   时  间：";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "客户报备编号：";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "代     理     店：";
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnCancel.Location = new System.Drawing.Point(350, 186);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 109;
            this.btnCancel.Text = "取 消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSave.Location = new System.Drawing.Point(255, 186);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 108;
            this.btnSave.Text = "保 存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmCustomerReportedDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(442, 219);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCustomerReportedDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "客户报备编辑";
            this.Load += new System.EventHandler(this.FrmCustomerReportedDialog_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCustomerReportedDialog_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.TextBox txtReported;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker ReportedDate;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtReportedName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker EffectiveDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnReported;
    }
}