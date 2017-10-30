namespace CZZD.ERP.WinUI.Sys
{
    partial class PrintSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintSetting));
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.txtCompanyCode = new System.Windows.Forms.TextBox();
            this.cboLanguage = new System.Windows.Forms.ComboBox();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.btnFileName = new System.Windows.Forms.Button();
            this.btnCompany = new System.Windows.Forms.Button();
            this.pTitle = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.drawingtypelbl = new System.Windows.Forms.Label();
            this.departmentlbl = new System.Windows.Forms.Label();
            this.txtDepartmentCode = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtDrawingTypeCode1 = new System.Windows.Forms.TextBox();
            this.txtDrawingTypeCode2 = new System.Windows.Forms.TextBox();
            this.txtDrawingTypeCode3 = new System.Windows.Forms.TextBox();
            this.txtDrawingTypeCode4 = new System.Windows.Forms.TextBox();
            this.txtDrawingTypeCode5 = new System.Windows.Forms.TextBox();
            this.txtDrawingTypeCode6 = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            this.pTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtFilePath);
            this.panel3.Controls.Add(this.txtCompanyCode);
            this.panel3.Controls.Add(this.cboLanguage);
            this.panel3.Controls.Add(this.txtCompanyName);
            this.panel3.Controls.Add(this.btnFileName);
            this.panel3.Controls.Add(this.btnCompany);
            this.panel3.Location = new System.Drawing.Point(120, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(424, 287);
            this.panel3.TabIndex = 1;
            // 
            // txtFilePath
            // 
            this.txtFilePath.BackColor = System.Drawing.Color.White;
            this.txtFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilePath.Enabled = false;
            this.txtFilePath.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtFilePath.Location = new System.Drawing.Point(5, 95);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(250, 25);
            this.txtFilePath.TabIndex = 13;
            // 
            // txtCompanyCode
            // 
            this.txtCompanyCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtCompanyCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompanyCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCompanyCode.Location = new System.Drawing.Point(5, 5);
            this.txtCompanyCode.Name = "txtCompanyCode";
            this.txtCompanyCode.Size = new System.Drawing.Size(250, 25);
            this.txtCompanyCode.TabIndex = 13;
            // 
            // cboLanguage
            // 
            this.cboLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLanguage.FormattingEnabled = true;
            this.cboLanguage.Location = new System.Drawing.Point(5, 65);
            this.cboLanguage.Name = "cboLanguage";
            this.cboLanguage.Size = new System.Drawing.Size(250, 27);
            this.cboLanguage.TabIndex = 12;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.BackColor = System.Drawing.Color.White;
            this.txtCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompanyName.Enabled = false;
            this.txtCompanyName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCompanyName.Location = new System.Drawing.Point(5, 35);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(250, 25);
            this.txtCompanyName.TabIndex = 11;
            // 
            // btnFileName
            // 
            this.btnFileName.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnFileName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFileName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFileName.FlatAppearance.BorderSize = 0;
            this.btnFileName.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnFileName.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnFileName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFileName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFileName.Location = new System.Drawing.Point(261, 95);
            this.btnFileName.Name = "btnFileName";
            this.btnFileName.Size = new System.Drawing.Size(25, 25);
            this.btnFileName.TabIndex = 10;
            this.btnFileName.UseVisualStyleBackColor = true;
            this.btnFileName.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btnFileName.Click += new System.EventHandler(this.btnFileName_Click);
            this.btnFileName.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
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
            this.btnCompany.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCompany.Location = new System.Drawing.Point(261, 5);
            this.btnCompany.Name = "btnCompany";
            this.btnCompany.Size = new System.Drawing.Size(25, 25);
            this.btnCompany.TabIndex = 10;
            this.btnCompany.UseVisualStyleBackColor = true;
            this.btnCompany.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btnCompany.Click += new System.EventHandler(this.btnCompany_Click);
            this.btnCompany.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            // 
            // pTitle
            // 
            this.pTitle.BackColor = System.Drawing.Color.SteelBlue;
            this.pTitle.Controls.Add(this.label1);
            this.pTitle.Controls.Add(this.label2);
            this.pTitle.Controls.Add(this.drawingtypelbl);
            this.pTitle.Controls.Add(this.departmentlbl);
            this.pTitle.Location = new System.Drawing.Point(0, 0);
            this.pTitle.Name = "pTitle";
            this.pTitle.Size = new System.Drawing.Size(120, 287);
            this.pTitle.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "公司编号 ";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "保存路径";
            // 
            // drawingtypelbl
            // 
            this.drawingtypelbl.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.drawingtypelbl.ForeColor = System.Drawing.Color.White;
            this.drawingtypelbl.Location = new System.Drawing.Point(5, 65);
            this.drawingtypelbl.Name = "drawingtypelbl";
            this.drawingtypelbl.Size = new System.Drawing.Size(110, 20);
            this.drawingtypelbl.TabIndex = 5;
            this.drawingtypelbl.Text = "语　　言";
            // 
            // departmentlbl
            // 
            this.departmentlbl.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.departmentlbl.ForeColor = System.Drawing.Color.White;
            this.departmentlbl.Location = new System.Drawing.Point(5, 35);
            this.departmentlbl.Name = "departmentlbl";
            this.departmentlbl.Size = new System.Drawing.Size(110, 20);
            this.departmentlbl.TabIndex = 4;
            this.departmentlbl.Text = "公司名称";
            // 
            // txtDepartmentCode
            // 
            this.txtDepartmentCode.Location = new System.Drawing.Point(0, 0);
            this.txtDepartmentCode.Name = "txtDepartmentCode";
            this.txtDepartmentCode.Size = new System.Drawing.Size(100, 21);
            this.txtDepartmentCode.TabIndex = 0;
            this.txtDepartmentCode.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnCancel.Location = new System.Drawing.Point(454, 290);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnExport.Location = new System.Drawing.Point(362, 290);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(90, 30);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtDrawingTypeCode1
            // 
            this.txtDrawingTypeCode1.Location = new System.Drawing.Point(0, 0);
            this.txtDrawingTypeCode1.Name = "txtDrawingTypeCode1";
            this.txtDrawingTypeCode1.Size = new System.Drawing.Size(100, 21);
            this.txtDrawingTypeCode1.TabIndex = 0;
            this.txtDrawingTypeCode1.Visible = false;
            // 
            // txtDrawingTypeCode2
            // 
            this.txtDrawingTypeCode2.Location = new System.Drawing.Point(0, 0);
            this.txtDrawingTypeCode2.Name = "txtDrawingTypeCode2";
            this.txtDrawingTypeCode2.Size = new System.Drawing.Size(100, 21);
            this.txtDrawingTypeCode2.TabIndex = 0;
            this.txtDrawingTypeCode2.Visible = false;
            // 
            // txtDrawingTypeCode3
            // 
            this.txtDrawingTypeCode3.Location = new System.Drawing.Point(0, 0);
            this.txtDrawingTypeCode3.Name = "txtDrawingTypeCode3";
            this.txtDrawingTypeCode3.Size = new System.Drawing.Size(100, 21);
            this.txtDrawingTypeCode3.TabIndex = 0;
            this.txtDrawingTypeCode3.Visible = false;
            // 
            // txtDrawingTypeCode4
            // 
            this.txtDrawingTypeCode4.Location = new System.Drawing.Point(0, 0);
            this.txtDrawingTypeCode4.Name = "txtDrawingTypeCode4";
            this.txtDrawingTypeCode4.Size = new System.Drawing.Size(100, 21);
            this.txtDrawingTypeCode4.TabIndex = 0;
            this.txtDrawingTypeCode4.Visible = false;
            // 
            // txtDrawingTypeCode5
            // 
            this.txtDrawingTypeCode5.Location = new System.Drawing.Point(0, 0);
            this.txtDrawingTypeCode5.Name = "txtDrawingTypeCode5";
            this.txtDrawingTypeCode5.Size = new System.Drawing.Size(100, 21);
            this.txtDrawingTypeCode5.TabIndex = 0;
            this.txtDrawingTypeCode5.Visible = false;
            // 
            // txtDrawingTypeCode6
            // 
            this.txtDrawingTypeCode6.Location = new System.Drawing.Point(0, 0);
            this.txtDrawingTypeCode6.Name = "txtDrawingTypeCode6";
            this.txtDrawingTypeCode6.Size = new System.Drawing.Size(100, 21);
            this.txtDrawingTypeCode6.TabIndex = 0;
            this.txtDrawingTypeCode6.Visible = false;
            // 
            // PrintSetting
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(544, 322);
            this.Controls.Add(this.pTitle);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnExport);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrintSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "报价单导出设定";
            this.Load += new System.EventHandler(this.PrintSetting_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pTitle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label departmentlbl;
        private System.Windows.Forms.Label drawingtypelbl;
        private System.Windows.Forms.Button btnCompany;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.TextBox txtDepartmentCode;
        private System.Windows.Forms.TextBox txtDrawingTypeCode6;
        private System.Windows.Forms.TextBox txtDrawingTypeCode5;
        private System.Windows.Forms.TextBox txtDrawingTypeCode4;
        private System.Windows.Forms.TextBox txtDrawingTypeCode3;
        private System.Windows.Forms.TextBox txtDrawingTypeCode2;
        private System.Windows.Forms.TextBox txtDrawingTypeCode1;
        private System.Windows.Forms.ComboBox cboLanguage;
        private System.Windows.Forms.TextBox txtCompanyCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnFileName;
    }
}