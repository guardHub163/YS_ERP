namespace CZZD.ERP.WinUI
{
    partial class FrmBaseReceive
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBaseReceive));
            this.pInfo = new System.Windows.Forms.Panel();
            this.pBody = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lExcelname = new System.Windows.Forms.ListBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TABLE_FILED = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXCEL_FILED = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SELECT = new System.Windows.Forms.DataGridViewButtonColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rdoCustomer = new System.Windows.Forms.RadioButton();
            this.rdoDefault = new System.Windows.Forms.RadioButton();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.cboExcelSheet = new System.Windows.Forms.ComboBox();
            this.cboBaseTable = new System.Windows.Forms.ComboBox();
            this.cboFileType = new System.Windows.Forms.ComboBox();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.pInfo.SuspendLayout();
            this.pBody.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // pInfo
            // 
            this.pInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pInfo.Controls.Add(this.pBody);
            this.pInfo.Controls.Add(this.btnCancel);
            this.pInfo.Controls.Add(this.btnImport);
            this.pInfo.Location = new System.Drawing.Point(0, 0);
            this.pInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pInfo.Name = "pInfo";
            this.pInfo.Size = new System.Drawing.Size(631, 650);
            this.pInfo.TabIndex = 1;
            // 
            // pBody
            // 
            this.pBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBody.Controls.Add(this.panel4);
            this.pBody.Controls.Add(this.panel5);
            this.pBody.Location = new System.Drawing.Point(3, 3);
            this.pBody.Name = "pBody";
            this.pBody.Size = new System.Drawing.Size(623, 604);
            this.pBody.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lExcelname);
            this.panel4.Controls.Add(this.dgvData);
            this.panel4.Controls.Add(this.rdoCustomer);
            this.panel4.Controls.Add(this.rdoDefault);
            this.panel4.Controls.Add(this.btnSelectFile);
            this.panel4.Controls.Add(this.cboExcelSheet);
            this.panel4.Controls.Add(this.cboBaseTable);
            this.panel4.Controls.Add(this.cboFileType);
            this.panel4.Controls.Add(this.txtFilePath);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(122, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(499, 602);
            this.panel4.TabIndex = 1;
            // 
            // lExcelname
            // 
            this.lExcelname.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lExcelname.FormattingEnabled = true;
            this.lExcelname.ItemHeight = 19;
            this.lExcelname.Location = new System.Drawing.Point(365, 5);
            this.lExcelname.Name = "lExcelname";
            this.lExcelname.Size = new System.Drawing.Size(131, 118);
            this.lExcelname.TabIndex = 14;
            this.lExcelname.Visible = false;
            this.lExcelname.DoubleClick += new System.EventHandler(this.lExcelname_DoubleClick);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.ColumnHeadersHeight = 25;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NO,
            this.TABLE_FILED,
            this.EXCEL_FILED,
            this.SELECT,
            this.NAME});
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(3, 155);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.Size = new System.Drawing.Size(493, 444);
            this.dgvData.TabIndex = 12;
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);
            // 
            // NO
            // 
            this.NO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NO.DataPropertyName = "NO";
            this.NO.HeaderText = "NO";
            this.NO.Name = "NO";
            this.NO.ReadOnly = true;
            this.NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NO.Width = 35;
            // 
            // TABLE_FILED
            // 
            this.TABLE_FILED.DataPropertyName = "TABLE_FILED";
            this.TABLE_FILED.HeaderText = "数据字段";
            this.TABLE_FILED.Name = "TABLE_FILED";
            this.TABLE_FILED.ReadOnly = true;
            this.TABLE_FILED.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // EXCEL_FILED
            // 
            this.EXCEL_FILED.DataPropertyName = "EXCEL_FILED";
            this.EXCEL_FILED.HeaderText = "源字段";
            this.EXCEL_FILED.Name = "EXCEL_FILED";
            this.EXCEL_FILED.ReadOnly = true;
            this.EXCEL_FILED.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EXCEL_FILED.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SELECT
            // 
            this.SELECT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SELECT.DataPropertyName = "SELECT";
            this.SELECT.HeaderText = "";
            this.SELECT.Name = "SELECT";
            this.SELECT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SELECT.Width = 30;
            // 
            // NAME
            // 
            this.NAME.DataPropertyName = "NAME";
            this.NAME.HeaderText = "NAME";
            this.NAME.Name = "NAME";
            this.NAME.ReadOnly = true;
            this.NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NAME.Visible = false;
            // 
            // rdoCustomer
            // 
            this.rdoCustomer.AutoSize = true;
            this.rdoCustomer.Location = new System.Drawing.Point(142, 125);
            this.rdoCustomer.Name = "rdoCustomer";
            this.rdoCustomer.Size = new System.Drawing.Size(97, 24);
            this.rdoCustomer.TabIndex = 11;
            this.rdoCustomer.Text = "自定义格式";
            this.rdoCustomer.UseVisualStyleBackColor = true;
            this.rdoCustomer.Click += new System.EventHandler(this.rdoCustomer_Click);
            // 
            // rdoDefault
            // 
            this.rdoDefault.AutoSize = true;
            this.rdoDefault.Checked = true;
            this.rdoDefault.Location = new System.Drawing.Point(5, 125);
            this.rdoDefault.Name = "rdoDefault";
            this.rdoDefault.Size = new System.Drawing.Size(83, 24);
            this.rdoDefault.TabIndex = 11;
            this.rdoDefault.TabStop = true;
            this.rdoDefault.Text = "标准格式";
            this.rdoDefault.UseVisualStyleBackColor = true;
            this.rdoDefault.Click += new System.EventHandler(this.rdoDefault_Click);
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSelectFile.Location = new System.Drawing.Point(320, 35);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(39, 25);
            this.btnSelectFile.TabIndex = 10;
            this.btnSelectFile.Text = "选择";
            this.btnSelectFile.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // cboExcelSheet
            // 
            this.cboExcelSheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExcelSheet.FormattingEnabled = true;
            this.cboExcelSheet.Location = new System.Drawing.Point(5, 65);
            this.cboExcelSheet.Name = "cboExcelSheet";
            this.cboExcelSheet.Size = new System.Drawing.Size(310, 27);
            this.cboExcelSheet.TabIndex = 9;
            this.cboExcelSheet.SelectedIndexChanged += new System.EventHandler(this.cboExcelSheet_SelectedIndexChanged);
            // 
            // cboBaseTable
            // 
            this.cboBaseTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBaseTable.FormattingEnabled = true;
            this.cboBaseTable.Location = new System.Drawing.Point(5, 95);
            this.cboBaseTable.Name = "cboBaseTable";
            this.cboBaseTable.Size = new System.Drawing.Size(310, 27);
            this.cboBaseTable.TabIndex = 9;
            this.cboBaseTable.SelectedIndexChanged += new System.EventHandler(this.cboBaseTable_SelectedIndexChanged);
            // 
            // cboFileType
            // 
            this.cboFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFileType.FormattingEnabled = true;
            this.cboFileType.Location = new System.Drawing.Point(5, 5);
            this.cboFileType.Name = "cboFileType";
            this.cboFileType.Size = new System.Drawing.Size(310, 27);
            this.cboFileType.TabIndex = 9;
            // 
            // txtFilePath
            // 
            this.txtFilePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilePath.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtFilePath.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtFilePath.Location = new System.Drawing.Point(5, 35);
            this.txtFilePath.MaxLength = 20;
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(310, 25);
            this.txtFilePath.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SteelBlue;
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(122, 602);
            this.panel5.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = " 文件类型：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.SteelBlue;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = " 字段匹配：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = " 目标位置：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.SteelBlue;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = " SHEET：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = " 文件路径：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Location = new System.Drawing.Point(535, 612);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "关　闭";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnImport
            // 
            this.btnImport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImport.Location = new System.Drawing.Point(439, 612);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(90, 30);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "导　入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // FrmBaseReceive
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(638, 659);
            this.Controls.Add(this.pInfo);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmBaseReceive";
            this.Text = "基础数据导入";
            this.Load += new System.EventHandler(this.FrmBaseReceive_Load);
            this.pInfo.ResumeLayout(false);
            this.pBody.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pInfo;
        private System.Windows.Forms.Panel pBody;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ComboBox cboFileType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.ComboBox cboBaseTable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboExcelSheet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.RadioButton rdoCustomer;
        private System.Windows.Forms.RadioButton rdoDefault;
        private System.Windows.Forms.DataGridViewTextBoxColumn NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn TABLE_FILED;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXCEL_FILED;
        private System.Windows.Forms.DataGridViewButtonColumn SELECT;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
        private System.Windows.Forms.ListBox lExcelname;
    }
}