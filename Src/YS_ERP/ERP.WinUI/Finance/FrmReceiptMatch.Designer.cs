namespace CZZD.ERP.WinUI
{
    partial class FrmReceiptMatch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReceiptMatch));
            this.pBody = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTOMER_CLAIM_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICE_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SALES_SLIP_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTOMER_CLAIM_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLIP_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICE_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UN_RECEIPT_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEPOSIT_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OTHER_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SALES_SLIP_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRight = new System.Windows.Forms.Panel();
            this.pRight_2 = new System.Windows.Forms.Panel();
            this.txtDepositAmount = new System.Windows.Forms.TextBox();
            this.DueSalesDateTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.DueSalesDateFrom = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pRight_1 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pLeft = new System.Windows.Forms.Panel();
            this.pleft_2 = new System.Windows.Forms.Panel();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.pLeft_1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.pRight.SuspendLayout();
            this.pRight_2.SuspendLayout();
            this.pRight_1.SuspendLayout();
            this.pLeft.SuspendLayout();
            this.pleft_2.SuspendLayout();
            this.pLeft_1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pBody
            // 
            this.pBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBody.Controls.Add(this.btnClose);
            this.pBody.Controls.Add(this.btnSave);
            this.pBody.Controls.Add(this.dgvData);
            this.pBody.Controls.Add(this.pRight);
            this.pBody.Controls.Add(this.pLeft);
            this.pBody.Location = new System.Drawing.Point(0, 0);
            this.pBody.Name = "pBody";
            this.pBody.Size = new System.Drawing.Size(1020, 650);
            this.pBody.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(926, 614);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 30);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关　闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(832, 614);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保    存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowDrop = true;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeColumns = false;
            this.dgvData.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.ColumnHeadersHeight = 30;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.CUSTOMER_CLAIM_NAME,
            this.INVOICE_NUMBER,
            this.SALES_SLIP_DATE,
            this.CUSTOMER_CLAIM_DATE,
            this.SLIP_DATE,
            this.INVOICE_AMOUNT,
            this.UN_RECEIPT_AMOUNT,
            this.DEPOSIT_AMOUNT,
            this.OTHER_AMOUNT,
            this.SALES_SLIP_NUMBER});
            this.dgvData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(2, 196);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 25;
            this.dgvData.RowTemplate.Height = 25;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1014, 413);
            this.dgvData.TabIndex = 2;
            this.dgvData.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellValidated);
            this.dgvData.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvData_CellPainting);
            this.dgvData.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvData_EditingControlShowing);
            this.dgvData.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvData_RowStateChanged);
            // 
            // No
            // 
            this.No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.No.Frozen = true;
            this.No.HeaderText = "No.";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.No.Width = 35;
            // 
            // CUSTOMER_CLAIM_NAME
            // 
            this.CUSTOMER_CLAIM_NAME.DataPropertyName = "CUSTOMER_CLAIM_NAME";
            this.CUSTOMER_CLAIM_NAME.Frozen = true;
            this.CUSTOMER_CLAIM_NAME.HeaderText = "请款公司名称";
            this.CUSTOMER_CLAIM_NAME.Name = "CUSTOMER_CLAIM_NAME";
            this.CUSTOMER_CLAIM_NAME.ReadOnly = true;
            this.CUSTOMER_CLAIM_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CUSTOMER_CLAIM_NAME.Width = 150;
            // 
            // INVOICE_NUMBER
            // 
            this.INVOICE_NUMBER.DataPropertyName = "INVOICE_NUMBER";
            this.INVOICE_NUMBER.Frozen = true;
            this.INVOICE_NUMBER.HeaderText = "发票No";
            this.INVOICE_NUMBER.Name = "INVOICE_NUMBER";
            this.INVOICE_NUMBER.ReadOnly = true;
            this.INVOICE_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.INVOICE_NUMBER.Width = 150;
            // 
            // SALES_SLIP_DATE
            // 
            this.SALES_SLIP_DATE.DataPropertyName = "SALES_SLIP_DATE";
            dataGridViewCellStyle2.Format = "yyyy-MM-dd";
            dataGridViewCellStyle2.NullValue = null;
            this.SALES_SLIP_DATE.DefaultCellStyle = dataGridViewCellStyle2;
            this.SALES_SLIP_DATE.HeaderText = "开票日期";
            this.SALES_SLIP_DATE.Name = "SALES_SLIP_DATE";
            this.SALES_SLIP_DATE.ReadOnly = true;
            this.SALES_SLIP_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CUSTOMER_CLAIM_DATE
            // 
            this.CUSTOMER_CLAIM_DATE.DataPropertyName = "CUSTOMER_CLAIM_DATE";
            dataGridViewCellStyle3.Format = "yyyy-MM-dd";
            dataGridViewCellStyle3.NullValue = null;
            this.CUSTOMER_CLAIM_DATE.DefaultCellStyle = dataGridViewCellStyle3;
            this.CUSTOMER_CLAIM_DATE.HeaderText = "收款预定日期";
            this.CUSTOMER_CLAIM_DATE.Name = "CUSTOMER_CLAIM_DATE";
            this.CUSTOMER_CLAIM_DATE.ReadOnly = true;
            this.CUSTOMER_CLAIM_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CUSTOMER_CLAIM_DATE.Width = 120;
            // 
            // SLIP_DATE
            // 
            this.SLIP_DATE.DataPropertyName = "SLIP_DATE";
            dataGridViewCellStyle4.Format = "yyyy-MM-dd";
            dataGridViewCellStyle4.NullValue = null;
            this.SLIP_DATE.DefaultCellStyle = dataGridViewCellStyle4;
            this.SLIP_DATE.HeaderText = "收款日期";
            this.SLIP_DATE.MaxInputLength = 10;
            this.SLIP_DATE.Name = "SLIP_DATE";
            this.SLIP_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // INVOICE_AMOUNT
            // 
            this.INVOICE_AMOUNT.DataPropertyName = "INVOICE_AMOUNT";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.INVOICE_AMOUNT.DefaultCellStyle = dataGridViewCellStyle5;
            this.INVOICE_AMOUNT.HeaderText = "发票金额";
            this.INVOICE_AMOUNT.Name = "INVOICE_AMOUNT";
            this.INVOICE_AMOUNT.ReadOnly = true;
            this.INVOICE_AMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // UN_RECEIPT_AMOUNT
            // 
            this.UN_RECEIPT_AMOUNT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UN_RECEIPT_AMOUNT.DataPropertyName = "UN_RECEIPT_AMOUNT";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.UN_RECEIPT_AMOUNT.DefaultCellStyle = dataGridViewCellStyle6;
            this.UN_RECEIPT_AMOUNT.HeaderText = "应收余额";
            this.UN_RECEIPT_AMOUNT.Name = "UN_RECEIPT_AMOUNT";
            this.UN_RECEIPT_AMOUNT.ReadOnly = true;
            this.UN_RECEIPT_AMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DEPOSIT_AMOUNT
            // 
            this.DEPOSIT_AMOUNT.DataPropertyName = "DEPOSIT_AMOUNT";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.DEPOSIT_AMOUNT.DefaultCellStyle = dataGridViewCellStyle7;
            this.DEPOSIT_AMOUNT.HeaderText = "预收款金额";
            this.DEPOSIT_AMOUNT.Name = "DEPOSIT_AMOUNT";
            this.DEPOSIT_AMOUNT.ReadOnly = true;
            this.DEPOSIT_AMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DEPOSIT_AMOUNT.Width = 125;
            // 
            // OTHER_AMOUNT
            // 
            this.OTHER_AMOUNT.DataPropertyName = "OTHER_AMOUNT";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.OTHER_AMOUNT.DefaultCellStyle = dataGridViewCellStyle8;
            this.OTHER_AMOUNT.HeaderText = "收款金額\t\t\t";
            this.OTHER_AMOUNT.Name = "OTHER_AMOUNT";
            this.OTHER_AMOUNT.ReadOnly = true;
            this.OTHER_AMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OTHER_AMOUNT.Width = 130;
            // 
            // SALES_SLIP_NUMBER
            // 
            this.SALES_SLIP_NUMBER.DataPropertyName = "SALES_SLIP_NUMBER";
            this.SALES_SLIP_NUMBER.HeaderText = "销售发票内部编号,不显示";
            this.SALES_SLIP_NUMBER.Name = "SALES_SLIP_NUMBER";
            this.SALES_SLIP_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SALES_SLIP_NUMBER.Visible = false;
            // 
            // pRight
            // 
            this.pRight.BackColor = System.Drawing.Color.Transparent;
            this.pRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pRight.Controls.Add(this.pRight_2);
            this.pRight.Controls.Add(this.pRight_1);
            this.pRight.Location = new System.Drawing.Point(510, 3);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(505, 189);
            this.pRight.TabIndex = 10;
            // 
            // pRight_2
            // 
            this.pRight_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pRight_2.Controls.Add(this.txtDepositAmount);
            this.pRight_2.Controls.Add(this.DueSalesDateTo);
            this.pRight_2.Controls.Add(this.label2);
            this.pRight_2.Controls.Add(this.DueSalesDateFrom);
            this.pRight_2.Controls.Add(this.btnSearch);
            this.pRight_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRight_2.Location = new System.Drawing.Point(120, 0);
            this.pRight_2.Name = "pRight_2";
            this.pRight_2.Size = new System.Drawing.Size(383, 187);
            this.pRight_2.TabIndex = 0;
            // 
            // txtDepositAmount
            // 
            this.txtDepositAmount.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDepositAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDepositAmount.Enabled = false;
            this.txtDepositAmount.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtDepositAmount.Location = new System.Drawing.Point(6, 5);
            this.txtDepositAmount.Name = "txtDepositAmount";
            this.txtDepositAmount.Size = new System.Drawing.Size(250, 25);
            this.txtDepositAmount.TabIndex = 0;
            // 
            // DueSalesDateTo
            // 
            this.DueSalesDateTo.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.DueSalesDateTo.Checked = false;
            this.DueSalesDateTo.CustomFormat = "yyyy-MM-dd";
            this.DueSalesDateTo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.DueSalesDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DueSalesDateTo.Location = new System.Drawing.Point(143, 36);
            this.DueSalesDateTo.Name = "DueSalesDateTo";
            this.DueSalesDateTo.ShowCheckBox = true;
            this.DueSalesDateTo.Size = new System.Drawing.Size(113, 23);
            this.DueSalesDateTo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(120, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 19);
            this.label2.TabIndex = 18;
            this.label2.Text = "~";
            // 
            // DueSalesDateFrom
            // 
            this.DueSalesDateFrom.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.DueSalesDateFrom.Checked = false;
            this.DueSalesDateFrom.CustomFormat = "yyyy-MM-dd";
            this.DueSalesDateFrom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.DueSalesDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DueSalesDateFrom.Location = new System.Drawing.Point(5, 35);
            this.DueSalesDateFrom.Name = "DueSalesDateFrom";
            this.DueSalesDateFrom.ShowCheckBox = true;
            this.DueSalesDateFrom.Size = new System.Drawing.Size(113, 23);
            this.DueSalesDateFrom.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnSearch.Location = new System.Drawing.Point(290, 154);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 30);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "查　询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pRight_1
            // 
            this.pRight_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pRight_1.Controls.Add(this.label17);
            this.pRight_1.Controls.Add(this.label8);
            this.pRight_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pRight_1.Location = new System.Drawing.Point(0, 0);
            this.pRight_1.Name = "pRight_1";
            this.pRight_1.Size = new System.Drawing.Size(120, 187);
            this.pRight_1.TabIndex = 3;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label17.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(1, 35);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(110, 20);
            this.label17.TabIndex = 18;
            this.label17.Text = "收款预定日";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(1, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "预收款未开票余额";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pLeft
            // 
            this.pLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLeft.Controls.Add(this.pleft_2);
            this.pLeft.Controls.Add(this.pLeft_1);
            this.pLeft.Location = new System.Drawing.Point(3, 3);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(505, 189);
            this.pLeft.TabIndex = 0;
            // 
            // pleft_2
            // 
            this.pleft_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pleft_2.Controls.Add(this.txtInvoiceNo);
            this.pleft_2.Controls.Add(this.btnCustomer);
            this.pleft_2.Controls.Add(this.txtCustomerName);
            this.pleft_2.Controls.Add(this.txtCustomerCode);
            this.pleft_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pleft_2.Location = new System.Drawing.Point(120, 0);
            this.pleft_2.Name = "pleft_2";
            this.pleft_2.Size = new System.Drawing.Size(383, 187);
            this.pleft_2.TabIndex = 0;
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.BackColor = System.Drawing.SystemColors.Info;
            this.txtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvoiceNo.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtInvoiceNo.Location = new System.Drawing.Point(5, 66);
            this.txtInvoiceNo.MaxLength = 20;
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(250, 25);
            this.txtInvoiceNo.TabIndex = 3;
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
            this.btnCustomer.Location = new System.Drawing.Point(261, 5);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(25, 25);
            this.btnCustomer.TabIndex = 1;
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.MouseLeave += new System.EventHandler(this.btnCustomer_MouseLeave);
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            this.btnCustomer.MouseEnter += new System.EventHandler(this.btnCustomer_MouseEnter);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerName.Enabled = false;
            this.txtCustomerName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCustomerName.Location = new System.Drawing.Point(5, 35);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(250, 25);
            this.txtCustomerName.TabIndex = 2;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCustomerCode.Location = new System.Drawing.Point(5, 5);
            this.txtCustomerCode.MaxLength = 20;
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(250, 25);
            this.txtCustomerCode.TabIndex = 0;
            this.txtCustomerCode.Leave += new System.EventHandler(this.txtCustomerCode_Leave);
            // 
            // pLeft_1
            // 
            this.pLeft_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pLeft_1.Controls.Add(this.label1);
            this.pLeft_1.Controls.Add(this.label4);
            this.pLeft_1.Controls.Add(this.label13);
            this.pLeft_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeft_1.Location = new System.Drawing.Point(0, 0);
            this.pLeft_1.Name = "pLeft_1";
            this.pLeft_1.Size = new System.Drawing.Size(120, 187);
            this.pLeft_1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "发票No.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(1, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "请款公司编号";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(1, 35);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(110, 20);
            this.label13.TabIndex = 0;
            this.label13.Text = "请款公司名称";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmReceiptMatch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1024, 654);
            this.Controls.Add(this.pBody);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmReceiptMatch";
            this.Text = "收款输入";
            this.Load += new System.EventHandler(this.FrmReceiptMatch_Load);
            this.pBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.pRight.ResumeLayout(false);
            this.pRight_2.ResumeLayout(false);
            this.pRight_2.PerformLayout();
            this.pRight_1.ResumeLayout(false);
            this.pLeft.ResumeLayout(false);
            this.pleft_2.ResumeLayout(false);
            this.pleft_2.PerformLayout();
            this.pLeft_1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pBody;
        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.Panel pleft_2;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.Panel pLeft_1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.Panel pRight_2;
        private System.Windows.Forms.Panel pRight_1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker DueSalesDateTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DueSalesDateFrom;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDepositAmount;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_CLAIM_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICE_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn SALES_SLIP_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_CLAIM_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLIP_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICE_AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn UN_RECEIPT_AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPOSIT_AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn OTHER_AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SALES_SLIP_NUMBER;
    }
}