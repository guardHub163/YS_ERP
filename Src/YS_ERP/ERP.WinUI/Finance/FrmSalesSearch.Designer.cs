namespace CZZD.ERP.WinUI
{
    partial class FrmSalesSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSalesSearch));
            this.pBody = new System.Windows.Forms.Panel();
            this.pgControl = new CZZD.ERP.ComControls.PageControl();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDetails = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.Row = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTOMER_CLAIM_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLIP_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICE_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAYMENT_STATUS_NAME_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICE_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UN_RECEIPT_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CURRENCY_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTOMER_CLAIM_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDER_SLIP_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDER_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LINE_INVOICE_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHIPMENT_SLIP_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHIPMENT_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLIP_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LINE_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAYMENT_STATUS_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRight = new System.Windows.Forms.Panel();
            this.pRight_2 = new System.Windows.Forms.Panel();
            this.NoPayment = new System.Windows.Forms.RadioButton();
            this.SalesDateTo = new System.Windows.Forms.DateTimePicker();
            this.NoPaid = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.FullPayment = new System.Windows.Forms.RadioButton();
            this.SalesDateFrom = new System.Windows.Forms.DateTimePicker();
            this.DueSalesDateTo = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.DueSalesDateFrom = new System.Windows.Forms.DateTimePicker();
            this.pRight_1 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pLeft = new System.Windows.Forms.Panel();
            this.pleft_2 = new System.Windows.Forms.Panel();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.pLeft_1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
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
            this.pBody.Controls.Add(this.pgControl);
            this.pBody.Controls.Add(this.btnCancel);
            this.pBody.Controls.Add(this.btnClose);
            this.pBody.Controls.Add(this.btnDetails);
            this.pBody.Controls.Add(this.btnPrint);
            this.pBody.Controls.Add(this.dgvData);
            this.pBody.Controls.Add(this.pRight);
            this.pBody.Controls.Add(this.pLeft);
            this.pBody.Location = new System.Drawing.Point(0, 0);
            this.pBody.Name = "pBody";
            this.pBody.Size = new System.Drawing.Size(1020, 650);
            this.pBody.TabIndex = 0;
            // 
            // pgControl
            // 
            this.pgControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pgControl.Location = new System.Drawing.Point(1, 586);
            this.pgControl.Name = "pgControl";
            this.pgControl.Size = new System.Drawing.Size(1014, 30);
            this.pgControl.TabIndex = 26;
            this.pgControl.TotalPage = 1;
            this.pgControl.PageChanged += new CZZD.ERP.ComControls.PageControl.BtnClickHandle(this.pgControl_PageChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnCancel.Location = new System.Drawing.Point(736, 617);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "取    消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnClose.Location = new System.Drawing.Point(924, 617);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 30);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "关　闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDetails
            // 
            this.btnDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetails.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnDetails.Location = new System.Drawing.Point(830, 617);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(90, 30);
            this.btnDetails.TabIndex = 23;
            this.btnDetails.Text = "详细确认";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnPrint.Location = new System.Drawing.Point(642, 617);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(90, 30);
            this.btnPrint.TabIndex = 23;
            this.btnPrint.Text = "导　出";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
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
            this.Row,
            this.CUSTOMER_CLAIM_NAME,
            this.SLIP_DATE,
            this.INVOICE_NUMBER,
            this.PAYMENT_STATUS_NAME_C,
            this.INVOICE_AMOUNT,
            this.UN_RECEIPT_AMOUNT,
            this.CURRENCY_NAME,
            this.CUSTOMER_CLAIM_DATE,
            this.ORDER_SLIP_NUMBER,
            this.ORDER_AMOUNT,
            this.LINE_INVOICE_AMOUNT,
            this.SHIPMENT_SLIP_NUMBER,
            this.SHIPMENT_AMOUNT,
            this.SLIP_NUMBER,
            this.LINE_NUMBER,
            this.PAYMENT_STATUS_C});
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(2, 200);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 25;
            this.dgvData.RowTemplate.Height = 24;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1013, 385);
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
            this.Row.Width = 30;
            // 
            // CUSTOMER_CLAIM_NAME
            // 
            this.CUSTOMER_CLAIM_NAME.DataPropertyName = "CUSTOMER_CLAIM_NAME";
            this.CUSTOMER_CLAIM_NAME.Frozen = true;
            this.CUSTOMER_CLAIM_NAME.HeaderText = "请款公司名称";
            this.CUSTOMER_CLAIM_NAME.Name = "CUSTOMER_CLAIM_NAME";
            this.CUSTOMER_CLAIM_NAME.ReadOnly = true;
            this.CUSTOMER_CLAIM_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SLIP_DATE
            // 
            this.SLIP_DATE.DataPropertyName = "SLIP_DATE";
            dataGridViewCellStyle2.Format = "yyyy-MM-dd";
            dataGridViewCellStyle2.NullValue = null;
            this.SLIP_DATE.DefaultCellStyle = dataGridViewCellStyle2;
            this.SLIP_DATE.Frozen = true;
            this.SLIP_DATE.HeaderText = "开票日期";
            this.SLIP_DATE.Name = "SLIP_DATE";
            this.SLIP_DATE.ReadOnly = true;
            this.SLIP_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SLIP_DATE.Width = 115;
            // 
            // INVOICE_NUMBER
            // 
            this.INVOICE_NUMBER.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.INVOICE_NUMBER.DataPropertyName = "INVOICE_NUMBER";
            this.INVOICE_NUMBER.Frozen = true;
            this.INVOICE_NUMBER.HeaderText = "发票No.";
            this.INVOICE_NUMBER.MaxInputLength = 12;
            this.INVOICE_NUMBER.Name = "INVOICE_NUMBER";
            this.INVOICE_NUMBER.ReadOnly = true;
            this.INVOICE_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PAYMENT_STATUS_NAME_C
            // 
            this.PAYMENT_STATUS_NAME_C.HeaderText = "收款状态";
            this.PAYMENT_STATUS_NAME_C.Name = "PAYMENT_STATUS_NAME_C";
            this.PAYMENT_STATUS_NAME_C.ReadOnly = true;
            // 
            // INVOICE_AMOUNT
            // 
            this.INVOICE_AMOUNT.DataPropertyName = "INVOICE_AMOUNT";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.INVOICE_AMOUNT.DefaultCellStyle = dataGridViewCellStyle3;
            this.INVOICE_AMOUNT.HeaderText = "发票总金额";
            this.INVOICE_AMOUNT.Name = "INVOICE_AMOUNT";
            this.INVOICE_AMOUNT.ReadOnly = true;
            this.INVOICE_AMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // UN_RECEIPT_AMOUNT
            // 
            this.UN_RECEIPT_AMOUNT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UN_RECEIPT_AMOUNT.DataPropertyName = "UN_RECEIPT_AMOUNT";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.UN_RECEIPT_AMOUNT.DefaultCellStyle = dataGridViewCellStyle4;
            this.UN_RECEIPT_AMOUNT.HeaderText = "应收金额";
            this.UN_RECEIPT_AMOUNT.Name = "UN_RECEIPT_AMOUNT";
            this.UN_RECEIPT_AMOUNT.ReadOnly = true;
            this.UN_RECEIPT_AMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CURRENCY_NAME
            // 
            this.CURRENCY_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CURRENCY_NAME.DataPropertyName = "CURRENCY_NAME";
            this.CURRENCY_NAME.FillWeight = 5F;
            this.CURRENCY_NAME.HeaderText = "通货";
            this.CURRENCY_NAME.Name = "CURRENCY_NAME";
            this.CURRENCY_NAME.ReadOnly = true;
            this.CURRENCY_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CURRENCY_NAME.Width = 80;
            // 
            // CUSTOMER_CLAIM_DATE
            // 
            this.CUSTOMER_CLAIM_DATE.DataPropertyName = "CUSTOMER_CLAIM_DATE";
            dataGridViewCellStyle5.Format = "yyyy-MM-dd";
            dataGridViewCellStyle5.NullValue = null;
            this.CUSTOMER_CLAIM_DATE.DefaultCellStyle = dataGridViewCellStyle5;
            this.CUSTOMER_CLAIM_DATE.HeaderText = "收款预定日";
            this.CUSTOMER_CLAIM_DATE.Name = "CUSTOMER_CLAIM_DATE";
            this.CUSTOMER_CLAIM_DATE.ReadOnly = true;
            this.CUSTOMER_CLAIM_DATE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CUSTOMER_CLAIM_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CUSTOMER_CLAIM_DATE.Width = 115;
            // 
            // ORDER_SLIP_NUMBER
            // 
            this.ORDER_SLIP_NUMBER.DataPropertyName = "ORDER_SLIP_NUMBER";
            this.ORDER_SLIP_NUMBER.HeaderText = "订单编号";
            this.ORDER_SLIP_NUMBER.Name = "ORDER_SLIP_NUMBER";
            this.ORDER_SLIP_NUMBER.ReadOnly = true;
            this.ORDER_SLIP_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ORDER_AMOUNT
            // 
            this.ORDER_AMOUNT.DataPropertyName = "ORDER_AMOUNT";
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.ORDER_AMOUNT.DefaultCellStyle = dataGridViewCellStyle6;
            this.ORDER_AMOUNT.HeaderText = "订单金额";
            this.ORDER_AMOUNT.Name = "ORDER_AMOUNT";
            this.ORDER_AMOUNT.ReadOnly = true;
            this.ORDER_AMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LINE_INVOICE_AMOUNT
            // 
            this.LINE_INVOICE_AMOUNT.DataPropertyName = "LINE_INVOICE_AMOUNT";
            this.LINE_INVOICE_AMOUNT.HeaderText = "明细开票金额";
            this.LINE_INVOICE_AMOUNT.Name = "LINE_INVOICE_AMOUNT";
            this.LINE_INVOICE_AMOUNT.ReadOnly = true;
            this.LINE_INVOICE_AMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LINE_INVOICE_AMOUNT.Width = 110;
            // 
            // SHIPMENT_SLIP_NUMBER
            // 
            this.SHIPMENT_SLIP_NUMBER.DataPropertyName = "SHIPMENT_SLIP_NUMBER";
            this.SHIPMENT_SLIP_NUMBER.HeaderText = "出库编号";
            this.SHIPMENT_SLIP_NUMBER.Name = "SHIPMENT_SLIP_NUMBER";
            this.SHIPMENT_SLIP_NUMBER.ReadOnly = true;
            this.SHIPMENT_SLIP_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SHIPMENT_AMOUNT
            // 
            this.SHIPMENT_AMOUNT.DataPropertyName = "SHIPMENT_AMOUNT";
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.SHIPMENT_AMOUNT.DefaultCellStyle = dataGridViewCellStyle7;
            this.SHIPMENT_AMOUNT.HeaderText = "出库金额";
            this.SHIPMENT_AMOUNT.Name = "SHIPMENT_AMOUNT";
            this.SHIPMENT_AMOUNT.ReadOnly = true;
            this.SHIPMENT_AMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SLIP_NUMBER
            // 
            this.SLIP_NUMBER.DataPropertyName = "SLIP_NUMBER";
            this.SLIP_NUMBER.HeaderText = "SLIP_NUMBER";
            this.SLIP_NUMBER.Name = "SLIP_NUMBER";
            this.SLIP_NUMBER.ReadOnly = true;
            this.SLIP_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SLIP_NUMBER.Visible = false;
            // 
            // LINE_NUMBER
            // 
            this.LINE_NUMBER.DataPropertyName = "LINE_NUMBER";
            this.LINE_NUMBER.HeaderText = "LINE_NUMBER";
            this.LINE_NUMBER.Name = "LINE_NUMBER";
            this.LINE_NUMBER.ReadOnly = true;
            this.LINE_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LINE_NUMBER.Visible = false;
            // 
            // PAYMENT_STATUS_C
            // 
            this.PAYMENT_STATUS_C.HeaderText = "PAYMENT_STATUS_C";
            this.PAYMENT_STATUS_C.Name = "PAYMENT_STATUS_C";
            this.PAYMENT_STATUS_C.ReadOnly = true;
            this.PAYMENT_STATUS_C.Visible = false;
            // 
            // pRight
            // 
            this.pRight.BackColor = System.Drawing.Color.Transparent;
            this.pRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pRight.Controls.Add(this.pRight_2);
            this.pRight.Controls.Add(this.pRight_1);
            this.pRight.Location = new System.Drawing.Point(510, 3);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(505, 195);
            this.pRight.TabIndex = 2;
            // 
            // pRight_2
            // 
            this.pRight_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pRight_2.Controls.Add(this.NoPayment);
            this.pRight_2.Controls.Add(this.SalesDateTo);
            this.pRight_2.Controls.Add(this.NoPaid);
            this.pRight_2.Controls.Add(this.label8);
            this.pRight_2.Controls.Add(this.FullPayment);
            this.pRight_2.Controls.Add(this.SalesDateFrom);
            this.pRight_2.Controls.Add(this.DueSalesDateTo);
            this.pRight_2.Controls.Add(this.btnSearch);
            this.pRight_2.Controls.Add(this.label2);
            this.pRight_2.Controls.Add(this.DueSalesDateFrom);
            this.pRight_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRight_2.Location = new System.Drawing.Point(120, 0);
            this.pRight_2.Name = "pRight_2";
            this.pRight_2.Size = new System.Drawing.Size(383, 193);
            this.pRight_2.TabIndex = 0;
            // 
            // NoPayment
            // 
            this.NoPayment.AutoSize = true;
            this.NoPayment.Location = new System.Drawing.Point(182, 61);
            this.NoPayment.Name = "NoPayment";
            this.NoPayment.Size = new System.Drawing.Size(69, 24);
            this.NoPayment.TabIndex = 7;
            this.NoPayment.Text = "未收款";
            this.NoPayment.UseVisualStyleBackColor = true;
            // 
            // SalesDateTo
            // 
            this.SalesDateTo.CalendarFont = new System.Drawing.Font("微软雅黑", 10F);
            this.SalesDateTo.Checked = false;
            this.SalesDateTo.CustomFormat = "yyyy-MM-dd";
            this.SalesDateTo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.SalesDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.SalesDateTo.Location = new System.Drawing.Point(142, 6);
            this.SalesDateTo.Name = "SalesDateTo";
            this.SalesDateTo.ShowCheckBox = true;
            this.SalesDateTo.Size = new System.Drawing.Size(113, 23);
            this.SalesDateTo.TabIndex = 2;
            // 
            // NoPaid
            // 
            this.NoPaid.AutoSize = true;
            this.NoPaid.Location = new System.Drawing.Point(104, 61);
            this.NoPaid.Name = "NoPaid";
            this.NoPaid.Size = new System.Drawing.Size(69, 24);
            this.NoPaid.TabIndex = 6;
            this.NoPaid.Text = "已收款";
            this.NoPaid.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(119, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 19);
            this.label8.TabIndex = 19;
            this.label8.Text = "~";
            // 
            // FullPayment
            // 
            this.FullPayment.AutoSize = true;
            this.FullPayment.Checked = true;
            this.FullPayment.Location = new System.Drawing.Point(7, 61);
            this.FullPayment.Name = "FullPayment";
            this.FullPayment.Size = new System.Drawing.Size(83, 24);
            this.FullPayment.TabIndex = 5;
            this.FullPayment.TabStop = true;
            this.FullPayment.Text = "全部发票";
            this.FullPayment.UseVisualStyleBackColor = true;
            // 
            // SalesDateFrom
            // 
            this.SalesDateFrom.CalendarFont = new System.Drawing.Font("微软雅黑", 10F);
            this.SalesDateFrom.Checked = false;
            this.SalesDateFrom.CustomFormat = "yyyy-MM-dd";
            this.SalesDateFrom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.SalesDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.SalesDateFrom.Location = new System.Drawing.Point(5, 5);
            this.SalesDateFrom.Name = "SalesDateFrom";
            this.SalesDateFrom.ShowCheckBox = true;
            this.SalesDateFrom.Size = new System.Drawing.Size(113, 23);
            this.SalesDateFrom.TabIndex = 1;
            // 
            // DueSalesDateTo
            // 
            this.DueSalesDateTo.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.DueSalesDateTo.Checked = false;
            this.DueSalesDateTo.CustomFormat = "yyyy-MM-dd";
            this.DueSalesDateTo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.DueSalesDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DueSalesDateTo.Location = new System.Drawing.Point(142, 36);
            this.DueSalesDateTo.Name = "DueSalesDateTo";
            this.DueSalesDateTo.ShowCheckBox = true;
            this.DueSalesDateTo.Size = new System.Drawing.Size(113, 23);
            this.DueSalesDateTo.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnSearch.Location = new System.Drawing.Point(290, 160);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 30);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "查　询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(119, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 19);
            this.label2.TabIndex = 15;
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
            this.DueSalesDateFrom.TabIndex = 3;
            // 
            // pRight_1
            // 
            this.pRight_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pRight_1.Controls.Add(this.label17);
            this.pRight_1.Controls.Add(this.label9);
            this.pRight_1.Controls.Add(this.label7);
            this.pRight_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pRight_1.Location = new System.Drawing.Point(0, 0);
            this.pRight_1.Name = "pRight_1";
            this.pRight_1.Size = new System.Drawing.Size(120, 193);
            this.pRight_1.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label17.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(5, 35);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(110, 20);
            this.label17.TabIndex = 17;
            this.label17.Text = "  收款预定日";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(7, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 20);
            this.label9.TabIndex = 16;
            this.label9.Text = "  开票日期";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(5, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "  收款状态";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pLeft
            // 
            this.pLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLeft.Controls.Add(this.pleft_2);
            this.pLeft.Controls.Add(this.pLeft_1);
            this.pLeft.Location = new System.Drawing.Point(3, 3);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(505, 195);
            this.pLeft.TabIndex = 1;
            // 
            // pleft_2
            // 
            this.pleft_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pleft_2.Controls.Add(this.txtCustomerCode);
            this.pleft_2.Controls.Add(this.txtCustomerName);
            this.pleft_2.Controls.Add(this.txtInvoiceNo);
            this.pleft_2.Controls.Add(this.btnCustomer);
            this.pleft_2.Controls.Add(this.txtOrderNumber);
            this.pleft_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pleft_2.Location = new System.Drawing.Point(120, 0);
            this.pleft_2.Name = "pleft_2";
            this.pleft_2.Size = new System.Drawing.Size(383, 193);
            this.pleft_2.TabIndex = 0;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCustomerCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtCustomerCode.Location = new System.Drawing.Point(5, 65);
            this.txtCustomerCode.MaxLength = 20;
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(250, 25);
            this.txtCustomerCode.TabIndex = 2;
            this.txtCustomerCode.Click += new System.EventHandler(this.txtCustomer_Leave);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerName.Enabled = false;
            this.txtCustomerName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCustomerName.Location = new System.Drawing.Point(5, 95);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(250, 25);
            this.txtCustomerName.TabIndex = 4;
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.BackColor = System.Drawing.SystemColors.Info;
            this.txtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvoiceNo.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtInvoiceNo.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtInvoiceNo.Location = new System.Drawing.Point(5, 5);
            this.txtInvoiceNo.MaxLength = 50;
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(250, 25);
            this.txtInvoiceNo.TabIndex = 0;
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
            this.btnCustomer.Location = new System.Drawing.Point(261, 66);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(25, 25);
            this.btnCustomer.TabIndex = 3;
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.MouseLeave += new System.EventHandler(this.btnCustomer_MouseLeave);
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            this.btnCustomer.MouseEnter += new System.EventHandler(this.btnCustomer_MouseEnter);
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.BackColor = System.Drawing.SystemColors.Info;
            this.txtOrderNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderNumber.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtOrderNumber.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtOrderNumber.Location = new System.Drawing.Point(5, 35);
            this.txtOrderNumber.MaxLength = 20;
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(250, 25);
            this.txtOrderNumber.TabIndex = 1;
            // 
            // pLeft_1
            // 
            this.pLeft_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pLeft_1.Controls.Add(this.label1);
            this.pLeft_1.Controls.Add(this.label4);
            this.pLeft_1.Controls.Add(this.label5);
            this.pLeft_1.Controls.Add(this.label13);
            this.pLeft_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeft_1.Location = new System.Drawing.Point(0, 0);
            this.pLeft_1.Name = "pLeft_1";
            this.pLeft_1.Size = new System.Drawing.Size(120, 193);
            this.pLeft_1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "  发票No.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "  请款公司编号";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "  销售订单编号";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(5, 95);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(110, 20);
            this.label13.TabIndex = 0;
            this.label13.Text = "  请款公司名称";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmSalesSearch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.pBody);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSalesSearch";
            this.Text = "销售发票查询";
            this.Load += new System.EventHandler(this.FrmSalesSearch_Load);
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
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.Panel pLeft_1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.Panel pRight_2;
        private System.Windows.Forms.RadioButton NoPayment;
        private System.Windows.Forms.RadioButton NoPaid;
        private System.Windows.Forms.RadioButton FullPayment;
        private System.Windows.Forms.DateTimePicker DueSalesDateTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DueSalesDateFrom;
        private System.Windows.Forms.Panel pRight_1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker SalesDateFrom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker SalesDateTo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private CZZD.ERP.ComControls.PageControl pgControl;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn payment_status_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn payment_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Row;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_CLAIM_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLIP_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICE_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAYMENT_STATUS_NAME_C;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICE_AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn UN_RECEIPT_AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CURRENCY_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_CLAIM_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDER_SLIP_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDER_AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn LINE_INVOICE_AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SHIPMENT_SLIP_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn SHIPMENT_AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLIP_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn LINE_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAYMENT_STATUS_C;
    }
}