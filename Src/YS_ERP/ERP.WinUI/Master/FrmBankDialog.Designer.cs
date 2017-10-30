namespace CZZD.ERP.WinUI
{
    partial class FrmBankDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBankDialog));
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtId = new System.Windows.Forms.TextBox();
            this.rtxtDetialCn = new System.Windows.Forms.RichTextBox();
            this.rtxtDetialEn = new System.Windows.Forms.RichTextBox();
            this.txtFullNameEn = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnCompany = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtBankName = new System.Windows.Forms.TextBox();
            this.txtFullNameCn = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnCancel.Location = new System.Drawing.Point(453, 512);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取 消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(120, 505);
            this.panel2.TabIndex = 108;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.SteelBlue;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(5, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 20);
            this.label6.TabIndex = 203;
            this.label6.Text = "编号";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.SteelBlue;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 340);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 202;
            this.label5.Text = "中文信息";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 201;
            this.label2.Text = "英文信息";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 200;
            this.label1.Text = "英文全拼";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.SteelBlue;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 101;
            this.label4.Text = "公司编号";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 197;
            this.label3.Text = "公司名称";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.SteelBlue;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(5, 90);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 20);
            this.label11.TabIndex = 199;
            this.label11.Text = "银行中文名称";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.SteelBlue;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(5, 150);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(110, 20);
            this.label14.TabIndex = 198;
            this.label14.Text = "中文全拼";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSave.Location = new System.Drawing.Point(357, 512);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "保 存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(544, 505);
            this.panel1.TabIndex = 110;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtId);
            this.panel3.Controls.Add(this.rtxtDetialCn);
            this.panel3.Controls.Add(this.rtxtDetialEn);
            this.panel3.Controls.Add(this.txtFullNameEn);
            this.panel3.Controls.Add(this.txtCode);
            this.panel3.Controls.Add(this.btnCompany);
            this.panel3.Controls.Add(this.txtName);
            this.panel3.Controls.Add(this.txtBankName);
            this.panel3.Controls.Add(this.txtFullNameCn);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(120, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(424, 505);
            this.panel3.TabIndex = 109;
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtId.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtId.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtId.Location = new System.Drawing.Point(5, 5);
            this.txtId.MaxLength = 20;
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(340, 25);
            this.txtId.TabIndex = 10;
            this.txtId.Leave += new System.EventHandler(this.txtId_Leave);
            // 
            // rtxtDetialCn
            // 
            this.rtxtDetialCn.Location = new System.Drawing.Point(5, 345);
            this.rtxtDetialCn.Name = "rtxtDetialCn";
            this.rtxtDetialCn.Size = new System.Drawing.Size(405, 150);
            this.rtxtDetialCn.TabIndex = 9;
            this.rtxtDetialCn.Text = "";
            // 
            // rtxtDetialEn
            // 
            this.rtxtDetialEn.Location = new System.Drawing.Point(5, 185);
            this.rtxtDetialEn.Name = "rtxtDetialEn";
            this.rtxtDetialEn.Size = new System.Drawing.Size(405, 150);
            this.rtxtDetialEn.TabIndex = 8;
            this.rtxtDetialEn.Text = "";
            // 
            // txtFullNameEn
            // 
            this.txtFullNameEn.BackColor = System.Drawing.SystemColors.Info;
            this.txtFullNameEn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFullNameEn.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtFullNameEn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtFullNameEn.Location = new System.Drawing.Point(5, 125);
            this.txtFullNameEn.MaxLength = 20;
            this.txtFullNameEn.Name = "txtFullNameEn";
            this.txtFullNameEn.Size = new System.Drawing.Size(340, 25);
            this.txtFullNameEn.TabIndex = 5;
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtCode.Location = new System.Drawing.Point(5, 35);
            this.txtCode.MaxLength = 20;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(340, 25);
            this.txtCode.TabIndex = 1;
            this.txtCode.Leave += new System.EventHandler(this.txtCode_Leave);
            // 
            // btnCompany
            // 
            this.btnCompany.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnCompany.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCompany.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompany.FlatAppearance.BorderSize = 0;
            this.btnCompany.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCompany.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompany.Location = new System.Drawing.Point(350, 36);
            this.btnCompany.Name = "btnCompany";
            this.btnCompany.Size = new System.Drawing.Size(25, 25);
            this.btnCompany.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnCompany, "查询");
            this.btnCompany.UseVisualStyleBackColor = true;
            this.btnCompany.MouseLeave += new System.EventHandler(this.btnCompany_MouseLeave);
            this.btnCompany.Click += new System.EventHandler(this.btnCompany_Click);
            this.btnCompany.MouseEnter += new System.EventHandler(this.btnCompany_MouseEnter);
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Enabled = false;
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtName.Location = new System.Drawing.Point(5, 65);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(340, 25);
            this.txtName.TabIndex = 2;
            // 
            // txtBankName
            // 
            this.txtBankName.BackColor = System.Drawing.SystemColors.Info;
            this.txtBankName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBankName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtBankName.Location = new System.Drawing.Point(5, 95);
            this.txtBankName.MaxLength = 20;
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Size = new System.Drawing.Size(340, 25);
            this.txtBankName.TabIndex = 3;
            // 
            // txtFullNameCn
            // 
            this.txtFullNameCn.BackColor = System.Drawing.SystemColors.Info;
            this.txtFullNameCn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFullNameCn.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtFullNameCn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtFullNameCn.Location = new System.Drawing.Point(5, 155);
            this.txtFullNameCn.MaxLength = 20;
            this.txtFullNameCn.Name = "txtFullNameCn";
            this.txtFullNameCn.Size = new System.Drawing.Size(340, 25);
            this.txtFullNameCn.TabIndex = 6;
            // 
            // FrmBankDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 549);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBankDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "银行信息编辑";
            this.Load += new System.EventHandler(this.FrmBankDialog_Load);
            this.Shown += new System.EventHandler(this.FrmBankDialog_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmBankDialog_FormClosed);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RichTextBox rtxtDetialCn;
        private System.Windows.Forms.RichTextBox rtxtDetialEn;
        private System.Windows.Forms.TextBox txtFullNameEn;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button btnCompany;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtBankName;
        private System.Windows.Forms.TextBox txtFullNameCn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtId;

    }
}