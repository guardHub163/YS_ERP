namespace CZZD.ERP.WinUI
{
    partial class FrmSales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSales));
            this.pBody = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOperate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTOMER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDER_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SERIAL_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDER_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHIPMENT_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHIPMENT_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CURRENCY_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UN_INVOICE_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ALL = new System.Windows.Forms.DataGridViewLinkColumn();
            this.CURRENCY_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTOMER_CLAIM_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRight = new System.Windows.Forms.Panel();
            this.pRight_2 = new System.Windows.Forms.Panel();
            this.txtContractNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtShipmentDateTo = new System.Windows.Forms.DateTimePicker();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.txtShipmentDateFrom = new System.Windows.Forms.DateTimePicker();
            this.pRight_1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.pLeft = new System.Windows.Forms.Panel();
            this.pleft_2 = new System.Windows.Forms.Panel();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.txtCustomerClaimDate = new System.Windows.Forms.DateTimePicker();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.txtInvoiceAmount = new System.Windows.Forms.TextBox();
            this.txtSalesDate = new System.Windows.Forms.DateTimePicker();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.pLeft_1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
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
            this.pBody.Controls.Add(this.btnOperate);
            this.pBody.Controls.Add(this.btnSave);
            this.pBody.Controls.Add(this.dgvData);
            this.pBody.Controls.Add(this.pRight);
            this.pBody.Controls.Add(this.pLeft);
            this.pBody.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.pBody.Location = new System.Drawing.Point(0, 0);
            this.pBody.Name = "pBody";
            this.pBody.Size = new System.Drawing.Size(1020, 650);
            this.pBody.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(925, 615);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 30);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关　闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOperate
            // 
            this.btnOperate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOperate.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnOperate.Location = new System.Drawing.Point(733, 615);
            this.btnOperate.Name = "btnOperate";
            this.btnOperate.Size = new System.Drawing.Size(90, 30);
            this.btnOperate.TabIndex = 5;
            this.btnOperate.Text = "明细确认";
            this.btnOperate.UseVisualStyleBackColor = true;
            this.btnOperate.Click += new System.EventHandler(this.btnOperate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(829, 615);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保　存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
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
            this.CUSTOMER_NAME,
            this.ORDER_NUMBER,
            this.SERIAL_NUMBER,
            this.ORDER_AMOUNT,
            this.SHIPMENT_NUMBER,
            this.SHIPMENT_AMOUNT,
            this.CURRENCY_NAME,
            this.UN_INVOICE_AMOUNT,
            this.AMOUNT,
            this.ALL,
            this.CURRENCY_CODE,
            this.CUSTOMER_CLAIM_CODE});
            this.dgvData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(2, 200);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 25;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1012, 412);
            this.dgvData.TabIndex = 2;
            this.dgvData.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvData_EditingControlShowing);
            this.dgvData.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvData_RowStateChanged);
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentClick);
            // 
            // No
            // 
            this.No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.No.DataPropertyName = "No";
            this.No.FillWeight = 93.24873F;
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.No.Width = 30;
            // 
            // CUSTOMER_NAME
            // 
            this.CUSTOMER_NAME.DataPropertyName = "CUSTOMER_NAME";
            this.CUSTOMER_NAME.FillWeight = 93.24873F;
            this.CUSTOMER_NAME.HeaderText = "请款公司名称";
            this.CUSTOMER_NAME.Name = "CUSTOMER_NAME";
            this.CUSTOMER_NAME.ReadOnly = true;
            this.CUSTOMER_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CUSTOMER_NAME.Width = 105;
            // 
            // ORDER_NUMBER
            // 
            this.ORDER_NUMBER.DataPropertyName = "ORDER_NUMBER";
            this.ORDER_NUMBER.FillWeight = 93.24873F;
            this.ORDER_NUMBER.HeaderText = "订单编号";
            this.ORDER_NUMBER.MaxInputLength = 20;
            this.ORDER_NUMBER.Name = "ORDER_NUMBER";
            this.ORDER_NUMBER.ReadOnly = true;
            this.ORDER_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ORDER_NUMBER.Width = 106;
            // 
            // SERIAL_NUMBER
            // 
            this.SERIAL_NUMBER.DataPropertyName = "SERIAL_NUMBER";
            this.SERIAL_NUMBER.FillWeight = 93.24873F;
            this.SERIAL_NUMBER.HeaderText = "机械番号";
            this.SERIAL_NUMBER.Name = "SERIAL_NUMBER";
            this.SERIAL_NUMBER.ReadOnly = true;
            this.SERIAL_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SERIAL_NUMBER.Width = 105;
            // 
            // ORDER_AMOUNT
            // 
            this.ORDER_AMOUNT.DataPropertyName = "ORDER_AMOUNT";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.ORDER_AMOUNT.DefaultCellStyle = dataGridViewCellStyle3;
            this.ORDER_AMOUNT.FillWeight = 93.24873F;
            this.ORDER_AMOUNT.HeaderText = "订单金额";
            this.ORDER_AMOUNT.Name = "ORDER_AMOUNT";
            this.ORDER_AMOUNT.ReadOnly = true;
            this.ORDER_AMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ORDER_AMOUNT.Width = 106;
            // 
            // SHIPMENT_NUMBER
            // 
            this.SHIPMENT_NUMBER.DataPropertyName = "SHIPMENT_NUMBER";
            this.SHIPMENT_NUMBER.FillWeight = 93.24873F;
            this.SHIPMENT_NUMBER.HeaderText = "出库编号";
            this.SHIPMENT_NUMBER.Name = "SHIPMENT_NUMBER";
            this.SHIPMENT_NUMBER.ReadOnly = true;
            this.SHIPMENT_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SHIPMENT_NUMBER.Width = 105;
            // 
            // SHIPMENT_AMOUNT
            // 
            this.SHIPMENT_AMOUNT.DataPropertyName = "SHIPMENT_AMOUNT";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.SHIPMENT_AMOUNT.DefaultCellStyle = dataGridViewCellStyle4;
            this.SHIPMENT_AMOUNT.FillWeight = 93.24873F;
            this.SHIPMENT_AMOUNT.HeaderText = "出库金额";
            this.SHIPMENT_AMOUNT.Name = "SHIPMENT_AMOUNT";
            this.SHIPMENT_AMOUNT.ReadOnly = true;
            this.SHIPMENT_AMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SHIPMENT_AMOUNT.Width = 106;
            // 
            // CURRENCY_NAME
            // 
            this.CURRENCY_NAME.DataPropertyName = "CURRENCY_NAME";
            this.CURRENCY_NAME.FillWeight = 93.24873F;
            this.CURRENCY_NAME.HeaderText = "通货";
            this.CURRENCY_NAME.Name = "CURRENCY_NAME";
            this.CURRENCY_NAME.ReadOnly = true;
            this.CURRENCY_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CURRENCY_NAME.Width = 80;
            // 
            // UN_INVOICE_AMOUNT
            // 
            this.UN_INVOICE_AMOUNT.DataPropertyName = "UN_INVOICE_AMOUNT";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.UN_INVOICE_AMOUNT.DefaultCellStyle = dataGridViewCellStyle5;
            this.UN_INVOICE_AMOUNT.FillWeight = 93.24873F;
            this.UN_INVOICE_AMOUNT.HeaderText = "未开票金额";
            this.UN_INVOICE_AMOUNT.Name = "UN_INVOICE_AMOUNT";
            this.UN_INVOICE_AMOUNT.ReadOnly = true;
            this.UN_INVOICE_AMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UN_INVOICE_AMOUNT.Width = 106;
            // 
            // AMOUNT
            // 
            this.AMOUNT.DataPropertyName = "AMOUNT";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.AMOUNT.DefaultCellStyle = dataGridViewCellStyle6;
            this.AMOUNT.FillWeight = 93.24873F;
            this.AMOUNT.HeaderText = "开票金额";
            this.AMOUNT.MaxInputLength = 20;
            this.AMOUNT.Name = "AMOUNT";
            this.AMOUNT.ReadOnly = true;
            this.AMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AMOUNT.Width = 105;
            // 
            // ALL
            // 
            this.ALL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ALL.DataPropertyName = "ALL";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ALL.DefaultCellStyle = dataGridViewCellStyle7;
            this.ALL.FillWeight = 167.5127F;
            this.ALL.HeaderText = "";
            this.ALL.LinkColor = System.Drawing.Color.Blue;
            this.ALL.Name = "ALL";
            this.ALL.VisitedLinkColor = System.Drawing.Color.Blue;
            this.ALL.Width = 40;
            // 
            // CURRENCY_CODE
            // 
            this.CURRENCY_CODE.DataPropertyName = "CURRENCY_CODE";
            this.CURRENCY_CODE.HeaderText = "CURRENCY_CODE";
            this.CURRENCY_CODE.Name = "CURRENCY_CODE";
            this.CURRENCY_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CURRENCY_CODE.Visible = false;
            // 
            // CUSTOMER_CLAIM_CODE
            // 
            this.CUSTOMER_CLAIM_CODE.DataPropertyName = "CUSTOMER_CLAIM_CODE";
            this.CUSTOMER_CLAIM_CODE.HeaderText = "CUSTOMER_CLAIM_CODE";
            this.CUSTOMER_CLAIM_CODE.Name = "CUSTOMER_CLAIM_CODE";
            this.CUSTOMER_CLAIM_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CUSTOMER_CLAIM_CODE.Visible = false;
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
            this.pRight.TabIndex = 1;
            // 
            // pRight_2
            // 
            this.pRight_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pRight_2.Controls.Add(this.txtContractNumber);
            this.pRight_2.Controls.Add(this.label3);
            this.pRight_2.Controls.Add(this.btnSearch);
            this.pRight_2.Controls.Add(this.txtShipmentDateTo);
            this.pRight_2.Controls.Add(this.txtOrderNumber);
            this.pRight_2.Controls.Add(this.txtShipmentDateFrom);
            this.pRight_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRight_2.Location = new System.Drawing.Point(120, 0);
            this.pRight_2.Name = "pRight_2";
            this.pRight_2.Size = new System.Drawing.Size(383, 193);
            this.pRight_2.TabIndex = 0;
            // 
            // txtContractNumber
            // 
            this.txtContractNumber.BackColor = System.Drawing.SystemColors.Info;
            this.txtContractNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContractNumber.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtContractNumber.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtContractNumber.Location = new System.Drawing.Point(5, 35);
            this.txtContractNumber.MaxLength = 20;
            this.txtContractNumber.Name = "txtContractNumber";
            this.txtContractNumber.Size = new System.Drawing.Size(250, 25);
            this.txtContractNumber.TabIndex = 1;
            this.txtContractNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(117, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 19);
            this.label3.TabIndex = 13;
            this.label3.Text = "~";
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnSearch.Location = new System.Drawing.Point(290, 160);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 30);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "查　询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtShipmentDateTo
            // 
            this.txtShipmentDateTo.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.txtShipmentDateTo.Checked = false;
            this.txtShipmentDateTo.CustomFormat = "yyyy-MM-dd";
            this.txtShipmentDateTo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtShipmentDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtShipmentDateTo.Location = new System.Drawing.Point(140, 65);
            this.txtShipmentDateTo.Name = "txtShipmentDateTo";
            this.txtShipmentDateTo.ShowCheckBox = true;
            this.txtShipmentDateTo.Size = new System.Drawing.Size(113, 23);
            this.txtShipmentDateTo.TabIndex = 3;
            this.txtShipmentDateTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.BackColor = System.Drawing.SystemColors.Info;
            this.txtOrderNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderNumber.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtOrderNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtOrderNumber.Location = new System.Drawing.Point(5, 5);
            this.txtOrderNumber.MaxLength = 20;
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(250, 25);
            this.txtOrderNumber.TabIndex = 0;
            this.txtOrderNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtShipmentDateFrom
            // 
            this.txtShipmentDateFrom.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.txtShipmentDateFrom.Checked = false;
            this.txtShipmentDateFrom.CustomFormat = "yyyy-MM-dd";
            this.txtShipmentDateFrom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtShipmentDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtShipmentDateFrom.Location = new System.Drawing.Point(5, 65);
            this.txtShipmentDateFrom.Name = "txtShipmentDateFrom";
            this.txtShipmentDateFrom.ShowCheckBox = true;
            this.txtShipmentDateFrom.Size = new System.Drawing.Size(113, 23);
            this.txtShipmentDateFrom.TabIndex = 2;
            this.txtShipmentDateFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // pRight_1
            // 
            this.pRight_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pRight_1.Controls.Add(this.label5);
            this.pRight_1.Controls.Add(this.label6);
            this.pRight_1.Controls.Add(this.label14);
            this.pRight_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pRight_1.Location = new System.Drawing.Point(0, 0);
            this.pRight_1.Name = "pRight_1";
            this.pRight_1.Size = new System.Drawing.Size(120, 193);
            this.pRight_1.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "  订单编号";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(5, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "  出库日期";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(5, 35);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(110, 20);
            this.label14.TabIndex = 0;
            this.label14.Text = "  合同编号";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pLeft
            // 
            this.pLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLeft.Controls.Add(this.pleft_2);
            this.pLeft.Controls.Add(this.pLeft_1);
            this.pLeft.Location = new System.Drawing.Point(3, 3);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(505, 195);
            this.pLeft.TabIndex = 0;
            // 
            // pleft_2
            // 
            this.pleft_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pleft_2.Controls.Add(this.btnCustomer);
            this.pleft_2.Controls.Add(this.txtCustomerClaimDate);
            this.pleft_2.Controls.Add(this.txtInvoiceNo);
            this.pleft_2.Controls.Add(this.txtInvoiceAmount);
            this.pleft_2.Controls.Add(this.txtSalesDate);
            this.pleft_2.Controls.Add(this.txtCustomerCode);
            this.pleft_2.Controls.Add(this.txtCustomerName);
            this.pleft_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pleft_2.Location = new System.Drawing.Point(120, 0);
            this.pleft_2.Name = "pleft_2";
            this.pleft_2.Size = new System.Drawing.Size(383, 193);
            this.pleft_2.TabIndex = 0;
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
            this.btnCustomer.Location = new System.Drawing.Point(261, 95);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(25, 25);
            this.btnCustomer.TabIndex = 4;
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.MouseLeave += new System.EventHandler(this.btnCustomer_MouseLeave);
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            this.btnCustomer.MouseEnter += new System.EventHandler(this.btnCustomer_MouseEnter);
            // 
            // txtCustomerClaimDate
            // 
            this.txtCustomerClaimDate.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.txtCustomerClaimDate.CustomFormat = "yyyy-MM-dd";
            this.txtCustomerClaimDate.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCustomerClaimDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtCustomerClaimDate.Location = new System.Drawing.Point(5, 65);
            this.txtCustomerClaimDate.Name = "txtCustomerClaimDate";
            this.txtCustomerClaimDate.Size = new System.Drawing.Size(250, 25);
            this.txtCustomerClaimDate.TabIndex = 2;
            this.txtCustomerClaimDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvoiceNo.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtInvoiceNo.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtInvoiceNo.Location = new System.Drawing.Point(5, 5);
            this.txtInvoiceNo.MaxLength = 50;
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(250, 25);
            this.txtInvoiceNo.TabIndex = 0;
            this.txtInvoiceNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtInvoiceAmount
            // 
            this.txtInvoiceAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtInvoiceAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvoiceAmount.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtInvoiceAmount.Location = new System.Drawing.Point(5, 35);
            this.txtInvoiceAmount.MaxLength = 12;
            this.txtInvoiceAmount.Name = "txtInvoiceAmount";
            this.txtInvoiceAmount.Size = new System.Drawing.Size(250, 25);
            this.txtInvoiceAmount.TabIndex = 1;
            this.txtInvoiceAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtSalesDate
            // 
            this.txtSalesDate.CalendarFont = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSalesDate.CustomFormat = "yyyy-MM-dd";
            this.txtSalesDate.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSalesDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtSalesDate.Location = new System.Drawing.Point(5, 155);
            this.txtSalesDate.Name = "txtSalesDate";
            this.txtSalesDate.Size = new System.Drawing.Size(250, 25);
            this.txtSalesDate.TabIndex = 6;
            this.txtSalesDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCustomerCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtCustomerCode.Location = new System.Drawing.Point(5, 95);
            this.txtCustomerCode.MaxLength = 20;
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(250, 25);
            this.txtCustomerCode.TabIndex = 3;
            this.txtCustomerCode.Leave += new System.EventHandler(this.txtCustomerCode_Leave);
            this.txtCustomerCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerName.Enabled = false;
            this.txtCustomerName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCustomerName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtCustomerName.Location = new System.Drawing.Point(5, 125);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(250, 25);
            this.txtCustomerName.TabIndex = 5;
            // 
            // pLeft_1
            // 
            this.pLeft_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pLeft_1.Controls.Add(this.label1);
            this.pLeft_1.Controls.Add(this.label4);
            this.pLeft_1.Controls.Add(this.label13);
            this.pLeft_1.Controls.Add(this.label8);
            this.pLeft_1.Controls.Add(this.label2);
            this.pLeft_1.Controls.Add(this.label17);
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
            this.label4.Location = new System.Drawing.Point(5, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "  请款公司编号";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(5, 125);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(110, 20);
            this.label13.TabIndex = 0;
            this.label13.Text = "  请款公司名称";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(7, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "  开票日期";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "  发票合计金额";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label17.TabIndex = 0;
            this.label17.Text = "  收款预定日";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmSales
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1027, 657);
            this.Controls.Add(this.pBody);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "销售发票输入";
            this.Load += new System.EventHandler(this.FrmSales_Load);
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
        private System.Windows.Forms.TextBox txtContractNumber;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.Panel pLeft_1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.Panel pRight_2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker txtShipmentDateTo;
        private System.Windows.Forms.DateTimePicker txtShipmentDateFrom;
        private System.Windows.Forms.DateTimePicker txtCustomerClaimDate;
        private System.Windows.Forms.DateTimePicker txtSalesDate;
        private System.Windows.Forms.Panel pRight_1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtInvoiceAmount;
        private System.Windows.Forms.Button btnOperate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDER_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn SERIAL_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDER_AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SHIPMENT_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn SHIPMENT_AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CURRENCY_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn UN_INVOICE_AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn AMOUNT;
        private System.Windows.Forms.DataGridViewLinkColumn ALL;
        private System.Windows.Forms.DataGridViewTextBoxColumn CURRENCY_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_CLAIM_CODE;
    }
}