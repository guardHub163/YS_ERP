namespace CZZD.ERP.WinUI
{
    partial class FrmPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPayment));
            this.pBody = new System.Windows.Forms.Panel();
            this.pHeader = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pLeft = new System.Windows.Forms.Panel();
            this.pleft_2 = new System.Windows.Forms.Panel();
            this.txtPaymentDateTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPaymentDateFrom = new System.Windows.Forms.DateTimePicker();
            this.txtSupplierCode = new System.Windows.Forms.TextBox();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.pLeft_1 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pAmount = new System.Windows.Forms.Panel();
            this.txtTotalNoPayment = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUPPLIER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICE_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PURCHASE_SLIP_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLIP_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICE_NO_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CURRENCY_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UN_PAYMENT_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEPOSIT_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OTHER_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLIP_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pBody.SuspendLayout();
            this.pHeader.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pLeft.SuspendLayout();
            this.pleft_2.SuspendLayout();
            this.pLeft_1.SuspendLayout();
            this.pAmount.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // pBody
            // 
            this.pBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBody.Controls.Add(this.pHeader);
            this.pBody.Controls.Add(this.btnClose);
            this.pBody.Controls.Add(this.btnSave);
            this.pBody.Controls.Add(this.pAmount);
            this.pBody.Controls.Add(this.dgvData);
            this.pBody.Location = new System.Drawing.Point(0, 0);
            this.pBody.Name = "pBody";
            this.pBody.Size = new System.Drawing.Size(1020, 650);
            this.pBody.TabIndex = 0;
            // 
            // pHeader
            // 
            this.pHeader.Controls.Add(this.panel2);
            this.pHeader.Controls.Add(this.pLeft);
            this.pHeader.Location = new System.Drawing.Point(3, 3);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(1012, 192);
            this.pHeader.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Location = new System.Drawing.Point(512, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(500, 190);
            this.panel2.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(120, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(378, 188);
            this.panel3.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnSearch.Location = new System.Drawing.Point(280, 155);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(95, 30);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "查　询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SteelBlue;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(120, 188);
            this.panel4.TabIndex = 4;
            // 
            // pLeft
            // 
            this.pLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLeft.Controls.Add(this.pleft_2);
            this.pLeft.Controls.Add(this.pLeft_1);
            this.pLeft.Location = new System.Drawing.Point(0, 0);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(510, 190);
            this.pLeft.TabIndex = 9;
            // 
            // pleft_2
            // 
            this.pleft_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pleft_2.Controls.Add(this.txtPaymentDateTo);
            this.pleft_2.Controls.Add(this.label2);
            this.pleft_2.Controls.Add(this.txtPaymentDateFrom);
            this.pleft_2.Controls.Add(this.txtSupplierCode);
            this.pleft_2.Controls.Add(this.txtInvoiceNo);
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
            this.txtPaymentDateTo.Location = new System.Drawing.Point(142, 96);
            this.txtPaymentDateTo.Name = "txtPaymentDateTo";
            this.txtPaymentDateTo.ShowCheckBox = true;
            this.txtPaymentDateTo.Size = new System.Drawing.Size(113, 23);
            this.txtPaymentDateTo.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(119, 96);
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
            this.txtPaymentDateFrom.Location = new System.Drawing.Point(5, 95);
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
            this.txtSupplierCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtSupplierCode.Location = new System.Drawing.Point(5, 5);
            this.txtSupplierCode.MaxLength = 20;
            this.txtSupplierCode.Name = "txtSupplierCode";
            this.txtSupplierCode.Size = new System.Drawing.Size(250, 25);
            this.txtSupplierCode.TabIndex = 0;
            this.txtSupplierCode.Leave += new System.EventHandler(this.txtSupplierCode_Leave);
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.BackColor = System.Drawing.SystemColors.Info;
            this.txtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvoiceNo.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtInvoiceNo.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtInvoiceNo.Location = new System.Drawing.Point(5, 65);
            this.txtInvoiceNo.MaxLength = 20;
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(250, 25);
            this.txtInvoiceNo.TabIndex = 11;
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtSupplierName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupplierName.Enabled = false;
            this.txtSupplierName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSupplierName.Location = new System.Drawing.Point(5, 35);
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
            this.btnSupplier.Location = new System.Drawing.Point(261, 6);
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
            this.pLeft_1.Controls.Add(this.label1);
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
            this.label17.Location = new System.Drawing.Point(5, 95);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(110, 20);
            this.label17.TabIndex = 12;
            this.label17.Text = "  付款预定日期";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 65);
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
            this.label4.Location = new System.Drawing.Point(5, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "  供应商编号";
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
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(925, 613);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 30);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "关　闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(828, 613);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "保    存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pAmount
            // 
            this.pAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pAmount.Controls.Add(this.txtTotalNoPayment);
            this.pAmount.Controls.Add(this.panel1);
            this.pAmount.Location = new System.Drawing.Point(658, 580);
            this.pAmount.Name = "pAmount";
            this.pAmount.Size = new System.Drawing.Size(358, 30);
            this.pAmount.TabIndex = 18;
            // 
            // txtTotalNoPayment
            // 
            this.txtTotalNoPayment.BackColor = System.Drawing.SystemColors.Info;
            this.txtTotalNoPayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalNoPayment.Enabled = false;
            this.txtTotalNoPayment.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtTotalNoPayment.Location = new System.Drawing.Point(121, 3);
            this.txtTotalNoPayment.Name = "txtTotalNoPayment";
            this.txtTotalNoPayment.Size = new System.Drawing.Size(235, 23);
            this.txtTotalNoPayment.TabIndex = 15;
            this.txtTotalNoPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 28);
            this.panel1.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(5, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "  本次付款总额";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.ColumnHeadersHeight = 25;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.SUPPLIER_NAME,
            this.INVOICE_NO,
            this.PURCHASE_SLIP_DATE,
            this.SLIP_DATE,
            this.INVOICE_NO_AMOUNT,
            this.CURRENCY_NAME,
            this.UN_PAYMENT_AMOUNT,
            this.DEPOSIT_AMOUNT,
            this.OTHER_AMOUNT,
            this.SLIP_NUMBER});
            this.dgvData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(3, 197);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 25;
            this.dgvData.RowTemplate.Height = 24;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1013, 380);
            this.dgvData.TabIndex = 17;
            this.dgvData.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellValidated);
            this.dgvData.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvData_EditingControlShowing);
            this.dgvData.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvData_RowStateChanged);
            // 
            // No
            // 
            this.No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.No.DataPropertyName = "No";
            this.No.Frozen = true;
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.No.Width = 35;
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
            // INVOICE_NO
            // 
            this.INVOICE_NO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.INVOICE_NO.DataPropertyName = "INVOICE_NO";
            this.INVOICE_NO.Frozen = true;
            this.INVOICE_NO.HeaderText = "发票No";
            this.INVOICE_NO.Name = "INVOICE_NO";
            this.INVOICE_NO.ReadOnly = true;
            this.INVOICE_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.INVOICE_NO.Width = 130;
            // 
            // PURCHASE_SLIP_DATE
            // 
            this.PURCHASE_SLIP_DATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PURCHASE_SLIP_DATE.DataPropertyName = "PURCHASE_SLIP_DATE";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "yyyy-MM-dd";
            this.PURCHASE_SLIP_DATE.DefaultCellStyle = dataGridViewCellStyle3;
            this.PURCHASE_SLIP_DATE.Frozen = true;
            this.PURCHASE_SLIP_DATE.HeaderText = "开票日期";
            this.PURCHASE_SLIP_DATE.Name = "PURCHASE_SLIP_DATE";
            this.PURCHASE_SLIP_DATE.ReadOnly = true;
            this.PURCHASE_SLIP_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PURCHASE_SLIP_DATE.Width = 120;
            // 
            // SLIP_DATE
            // 
            this.SLIP_DATE.DataPropertyName = "SLIP_DATE";
            dataGridViewCellStyle4.Format = "yyyy-MM-dd";
            dataGridViewCellStyle4.NullValue = null;
            this.SLIP_DATE.DefaultCellStyle = dataGridViewCellStyle4;
            this.SLIP_DATE.HeaderText = "付款日期";
            this.SLIP_DATE.Name = "SLIP_DATE";
            this.SLIP_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // INVOICE_NO_AMOUNT
            // 
            this.INVOICE_NO_AMOUNT.DataPropertyName = "INVOICE_NO_AMOUNT";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.INVOICE_NO_AMOUNT.DefaultCellStyle = dataGridViewCellStyle5;
            this.INVOICE_NO_AMOUNT.HeaderText = "发票金额";
            this.INVOICE_NO_AMOUNT.Name = "INVOICE_NO_AMOUNT";
            this.INVOICE_NO_AMOUNT.ReadOnly = true;
            this.INVOICE_NO_AMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CURRENCY_NAME
            // 
            this.CURRENCY_NAME.DataPropertyName = "CURRENCY_NAME";
            this.CURRENCY_NAME.HeaderText = "通货";
            this.CURRENCY_NAME.Name = "CURRENCY_NAME";
            this.CURRENCY_NAME.ReadOnly = true;
            this.CURRENCY_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // UN_PAYMENT_AMOUNT
            // 
            this.UN_PAYMENT_AMOUNT.DataPropertyName = "UN_PAYMENT_AMOUNT";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.UN_PAYMENT_AMOUNT.DefaultCellStyle = dataGridViewCellStyle6;
            this.UN_PAYMENT_AMOUNT.HeaderText = "应付金额";
            this.UN_PAYMENT_AMOUNT.Name = "UN_PAYMENT_AMOUNT";
            this.UN_PAYMENT_AMOUNT.ReadOnly = true;
            this.UN_PAYMENT_AMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UN_PAYMENT_AMOUNT.Width = 130;
            // 
            // DEPOSIT_AMOUNT
            // 
            this.DEPOSIT_AMOUNT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DEPOSIT_AMOUNT.DataPropertyName = "DEPOSIT_AMOUNT";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.DEPOSIT_AMOUNT.DefaultCellStyle = dataGridViewCellStyle7;
            this.DEPOSIT_AMOUNT.FillWeight = 5F;
            this.DEPOSIT_AMOUNT.HeaderText = "预付款金额";
            this.DEPOSIT_AMOUNT.MaxInputLength = 20;
            this.DEPOSIT_AMOUNT.Name = "DEPOSIT_AMOUNT";
            this.DEPOSIT_AMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DEPOSIT_AMOUNT.Width = 124;
            // 
            // OTHER_AMOUNT
            // 
            this.OTHER_AMOUNT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.OTHER_AMOUNT.DataPropertyName = "OTHER_AMOUNT";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.OTHER_AMOUNT.DefaultCellStyle = dataGridViewCellStyle8;
            this.OTHER_AMOUNT.HeaderText = "付款金額";
            this.OTHER_AMOUNT.MaxInputLength = 20;
            this.OTHER_AMOUNT.Name = "OTHER_AMOUNT";
            this.OTHER_AMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OTHER_AMOUNT.Width = 120;
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
            // FrmPayment
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1025, 653);
            this.Controls.Add(this.pBody);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPayment";
            this.Text = "付款输入";
            this.Load += new System.EventHandler(this.FrmPayment_Load);
            this.pBody.ResumeLayout(false);
            this.pHeader.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.pLeft.ResumeLayout(false);
            this.pleft_2.ResumeLayout(false);
            this.pleft_2.PerformLayout();
            this.pLeft_1.ResumeLayout(false);
            this.pAmount.ResumeLayout(false);
            this.pAmount.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pBody;
        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.Panel pleft_2;
        private System.Windows.Forms.TextBox txtSupplierCode;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.Panel pLeft_1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker txtPaymentDateTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker txtPaymentDateFrom;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Panel pAmount;
        private System.Windows.Forms.TextBox txtTotalNoPayment;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUPPLIER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICE_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PURCHASE_SLIP_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLIP_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICE_NO_AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CURRENCY_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn UN_PAYMENT_AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPOSIT_AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn OTHER_AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLIP_NUMBER;
    }
}