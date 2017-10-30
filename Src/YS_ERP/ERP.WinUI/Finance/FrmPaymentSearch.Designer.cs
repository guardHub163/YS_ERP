namespace CZZD.ERP.WinUI
{
    partial class FrmPaymentSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPaymentSearch));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pRight = new System.Windows.Forms.Panel();
            this.pRight_2 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pRight_1 = new System.Windows.Forms.Panel();
            this.pLeft = new System.Windows.Forms.Panel();
            this.pleft_2 = new System.Windows.Forms.Panel();
            this.txtPaymentDateTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPaymentDateFrom = new System.Windows.Forms.DateTimePicker();
            this.txtSupplierCode = new System.Windows.Forms.TextBox();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.pLeft_1 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pgControl = new CZZD.ERP.ComControls.PageControl();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.Row = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUPPLIER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLIP_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICE_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICE_NO_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CURRENCY_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEPOSIT_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OTHER_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLIP_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pRight.SuspendLayout();
            this.pRight_2.SuspendLayout();
            this.pLeft.SuspendLayout();
            this.pleft_2.SuspendLayout();
            this.pLeft_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pgControl);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.dgvData);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1020, 650);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pRight);
            this.panel2.Controls.Add(this.pLeft);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1012, 195);
            this.panel2.TabIndex = 27;
            // 
            // pRight
            // 
            this.pRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pRight.Controls.Add(this.pRight_2);
            this.pRight.Controls.Add(this.pRight_1);
            this.pRight.Location = new System.Drawing.Point(512, 1);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(500, 190);
            this.pRight.TabIndex = 14;
            // 
            // pRight_2
            // 
            this.pRight_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pRight_2.Controls.Add(this.btnSearch);
            this.pRight_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRight_2.Location = new System.Drawing.Point(120, 0);
            this.pRight_2.Name = "pRight_2";
            this.pRight_2.Size = new System.Drawing.Size(378, 188);
            this.pRight_2.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnSearch.Location = new System.Drawing.Point(280, 155);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(95, 30);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "查　询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pRight_1
            // 
            this.pRight_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pRight_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pRight_1.Location = new System.Drawing.Point(0, 0);
            this.pRight_1.Name = "pRight_1";
            this.pRight_1.Size = new System.Drawing.Size(120, 188);
            this.pRight_1.TabIndex = 4;
            // 
            // pLeft
            // 
            this.pLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLeft.Controls.Add(this.pleft_2);
            this.pLeft.Controls.Add(this.pLeft_1);
            this.pLeft.Location = new System.Drawing.Point(0, 0);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(510, 190);
            this.pLeft.TabIndex = 13;
            // 
            // pleft_2
            // 
            this.pleft_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pleft_2.Controls.Add(this.txtPaymentDateTo);
            this.pleft_2.Controls.Add(this.label2);
            this.pleft_2.Controls.Add(this.txtPaymentDateFrom);
            this.pleft_2.Controls.Add(this.txtSupplierCode);
            this.pleft_2.Controls.Add(this.txtSupplierName);
            this.pleft_2.Controls.Add(this.btnSupplier);
            this.pleft_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pleft_2.Location = new System.Drawing.Point(120, 0);
            this.pleft_2.Name = "pleft_2";
            this.pleft_2.Size = new System.Drawing.Size(388, 188);
            this.pleft_2.TabIndex = 5;
            // 
            // txtPaymentDateTo
            // 
            this.txtPaymentDateTo.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.txtPaymentDateTo.Checked = false;
            this.txtPaymentDateTo.CustomFormat = "yyyy-MM-dd";
            this.txtPaymentDateTo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtPaymentDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtPaymentDateTo.Location = new System.Drawing.Point(143, 69);
            this.txtPaymentDateTo.Name = "txtPaymentDateTo";
            this.txtPaymentDateTo.ShowCheckBox = true;
            this.txtPaymentDateTo.Size = new System.Drawing.Size(113, 23);
            this.txtPaymentDateTo.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(120, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 19);
            this.label2.TabIndex = 18;
            this.label2.Text = "~";
            // 
            // txtPaymentDateFrom
            // 
            this.txtPaymentDateFrom.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.txtPaymentDateFrom.Checked = false;
            this.txtPaymentDateFrom.CustomFormat = "yyyy-MM-dd";
            this.txtPaymentDateFrom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtPaymentDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtPaymentDateFrom.Location = new System.Drawing.Point(6, 68);
            this.txtPaymentDateFrom.Name = "txtPaymentDateFrom";
            this.txtPaymentDateFrom.ShowCheckBox = true;
            this.txtPaymentDateFrom.Size = new System.Drawing.Size(113, 23);
            this.txtPaymentDateFrom.TabIndex = 17;
            // 
            // txtSupplierCode
            // 
            this.txtSupplierCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtSupplierCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupplierCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSupplierCode.Location = new System.Drawing.Point(6, 8);
            this.txtSupplierCode.MaxLength = 20;
            this.txtSupplierCode.Name = "txtSupplierCode";
            this.txtSupplierCode.Size = new System.Drawing.Size(250, 25);
            this.txtSupplierCode.TabIndex = 0;
            this.txtSupplierCode.Leave += new System.EventHandler(this.txtSupplierCode_Leave);
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtSupplierName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupplierName.Enabled = false;
            this.txtSupplierName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSupplierName.Location = new System.Drawing.Point(6, 37);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(250, 25);
            this.txtSupplierName.TabIndex = 0;
            // 
            // btnSupplier
            // 
            this.btnSupplier.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnSupplier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSupplier.FlatAppearance.BorderSize = 0;
            this.btnSupplier.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSupplier.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupplier.Location = new System.Drawing.Point(262, 8);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(25, 25);
            this.btnSupplier.TabIndex = 9;
            this.btnSupplier.UseVisualStyleBackColor = true;
            this.btnSupplier.MouseLeave += new System.EventHandler(this.btnCustomer_MouseLeave);
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            this.btnSupplier.MouseEnter += new System.EventHandler(this.btnCustomer_MouseEnter);
            // 
            // pLeft_1
            // 
            this.pLeft_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pLeft_1.Controls.Add(this.label17);
            this.pLeft_1.Controls.Add(this.label4);
            this.pLeft_1.Controls.Add(this.label13);
            this.pLeft_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeft_1.Location = new System.Drawing.Point(0, 0);
            this.pLeft_1.Name = "pLeft_1";
            this.pLeft_1.Size = new System.Drawing.Size(120, 188);
            this.pLeft_1.TabIndex = 4;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label17.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(5, 65);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(110, 20);
            this.label17.TabIndex = 12;
            this.label17.Text = "  付款日期";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "  供应商";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(5, 35);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(110, 20);
            this.label13.TabIndex = 0;
            this.label13.Text = "  供应商名称";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pgControl
            // 
            this.pgControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pgControl.Location = new System.Drawing.Point(3, 582);
            this.pgControl.Name = "pgControl";
            this.pgControl.Size = new System.Drawing.Size(1012, 30);
            this.pgControl.TabIndex = 26;
            this.pgControl.TotalPage = 1;
            this.pgControl.PageChanged += new CZZD.ERP.ComControls.PageControl.BtnClickHandle(this.pgControl_PageChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnCancel.Location = new System.Drawing.Point(717, 615);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 30);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "取    消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnClose.Location = new System.Drawing.Point(920, 615);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 30);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "关　闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnPrint.Location = new System.Drawing.Point(819, 615);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(95, 30);
            this.btnPrint.TabIndex = 23;
            this.btnPrint.Text = "导　出";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeColumns = false;
            this.dgvData.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.ColumnHeadersHeight = 32;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Row,
            this.SUPPLIER_NAME,
            this.SLIP_DATE,
            this.INVOICE_No,
            this.INVOICE_NO_AMOUNT,
            this.CURRENCY_NAME,
            this.DEPOSIT_AMOUNT,
            this.OTHER_AMOUNT,
            this.SLIP_NUMBER});
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(3, 197);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 25;
            this.dgvData.RowTemplate.Height = 25;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1012, 385);
            this.dgvData.TabIndex = 18;
            this.dgvData.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvData_RowStateChanged);
            // 
            // Row
            // 
            this.Row.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Row.DataPropertyName = "Row";
            this.Row.Frozen = true;
            this.Row.HeaderText = "No.";
            this.Row.Name = "Row";
            this.Row.ReadOnly = true;
            this.Row.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Row.Width = 35;
            // 
            // SUPPLIER_NAME
            // 
            this.SUPPLIER_NAME.DataPropertyName = "SUPPLIER_NAME";
            this.SUPPLIER_NAME.Frozen = true;
            this.SUPPLIER_NAME.HeaderText = "供应商名称";
            this.SUPPLIER_NAME.Name = "SUPPLIER_NAME";
            this.SUPPLIER_NAME.ReadOnly = true;
            this.SUPPLIER_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SUPPLIER_NAME.Width = 150;
            // 
            // SLIP_DATE
            // 
            this.SLIP_DATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SLIP_DATE.DataPropertyName = "SLIP_DATE";
            dataGridViewCellStyle2.Format = "yyyy-MM-dd";
            this.SLIP_DATE.DefaultCellStyle = dataGridViewCellStyle2;
            this.SLIP_DATE.Frozen = true;
            this.SLIP_DATE.HeaderText = "付款日期";
            this.SLIP_DATE.Name = "SLIP_DATE";
            this.SLIP_DATE.ReadOnly = true;
            this.SLIP_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SLIP_DATE.Width = 150;
            // 
            // INVOICE_No
            // 
            this.INVOICE_No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.INVOICE_No.DataPropertyName = "INVOICE_No";
            this.INVOICE_No.Frozen = true;
            this.INVOICE_No.HeaderText = "发票No";
            this.INVOICE_No.MaxInputLength = 12;
            this.INVOICE_No.Name = "INVOICE_No";
            this.INVOICE_No.ReadOnly = true;
            this.INVOICE_No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.INVOICE_No.Width = 150;
            // 
            // INVOICE_NO_AMOUNT
            // 
            this.INVOICE_NO_AMOUNT.DataPropertyName = "INVOICE_NO_AMOUNT";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.INVOICE_NO_AMOUNT.DefaultCellStyle = dataGridViewCellStyle3;
            this.INVOICE_NO_AMOUNT.Frozen = true;
            this.INVOICE_NO_AMOUNT.HeaderText = "采购金额";
            this.INVOICE_NO_AMOUNT.Name = "INVOICE_NO_AMOUNT";
            this.INVOICE_NO_AMOUNT.ReadOnly = true;
            this.INVOICE_NO_AMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.INVOICE_NO_AMOUNT.Width = 120;
            // 
            // CURRENCY_NAME
            // 
            this.CURRENCY_NAME.DataPropertyName = "CURRENCY_NAME";
            this.CURRENCY_NAME.Frozen = true;
            this.CURRENCY_NAME.HeaderText = "通货";
            this.CURRENCY_NAME.Name = "CURRENCY_NAME";
            this.CURRENCY_NAME.ReadOnly = true;
            this.CURRENCY_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CURRENCY_NAME.Width = 120;
            // 
            // DEPOSIT_AMOUNT
            // 
            this.DEPOSIT_AMOUNT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DEPOSIT_AMOUNT.DataPropertyName = "DEPOSIT_AMOUNT";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DEPOSIT_AMOUNT.DefaultCellStyle = dataGridViewCellStyle4;
            this.DEPOSIT_AMOUNT.FillWeight = 5F;
            this.DEPOSIT_AMOUNT.Frozen = true;
            this.DEPOSIT_AMOUNT.HeaderText = "预付款金额";
            this.DEPOSIT_AMOUNT.Name = "DEPOSIT_AMOUNT";
            this.DEPOSIT_AMOUNT.ReadOnly = true;
            this.DEPOSIT_AMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DEPOSIT_AMOUNT.Width = 140;
            // 
            // OTHER_AMOUNT
            // 
            this.OTHER_AMOUNT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.OTHER_AMOUNT.DataPropertyName = "OTHER_AMOUNT";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.OTHER_AMOUNT.DefaultCellStyle = dataGridViewCellStyle5;
            this.OTHER_AMOUNT.Frozen = true;
            this.OTHER_AMOUNT.HeaderText = "付款金额";
            this.OTHER_AMOUNT.Name = "OTHER_AMOUNT";
            this.OTHER_AMOUNT.ReadOnly = true;
            this.OTHER_AMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OTHER_AMOUNT.Width = 143;
            // 
            // SLIP_NUMBER
            // 
            this.SLIP_NUMBER.DataPropertyName = "SLIP_NUMBER";
            this.SLIP_NUMBER.HeaderText = "SLIP_NUMBER";
            this.SLIP_NUMBER.Name = "SLIP_NUMBER";
            this.SLIP_NUMBER.ReadOnly = true;
            this.SLIP_NUMBER.Visible = false;
            // 
            // FrmPaymentSearch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1025, 652);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPaymentSearch";
            this.Text = "付款查询";
            this.Load += new System.EventHandler(this.FrmPaymentSearch_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pRight.ResumeLayout(false);
            this.pRight_2.ResumeLayout(false);
            this.pLeft.ResumeLayout(false);
            this.pleft_2.ResumeLayout(false);
            this.pleft_2.PerformLayout();
            this.pLeft_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.Panel pleft_2;
        private System.Windows.Forms.DateTimePicker txtPaymentDateTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker txtPaymentDateFrom;
        private System.Windows.Forms.TextBox txtSupplierCode;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.Panel pLeft_1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private CZZD.ERP.ComControls.PageControl pgControl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.Panel pRight_2;
        private System.Windows.Forms.Panel pRight_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Row;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUPPLIER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLIP_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICE_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICE_NO_AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CURRENCY_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPOSIT_AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn OTHER_AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLIP_NUMBER;
    }
}