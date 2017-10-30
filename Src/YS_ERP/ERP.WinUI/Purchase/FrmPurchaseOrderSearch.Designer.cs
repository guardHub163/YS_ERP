namespace CZZD.ERP.WinUI
{
    partial class FrmPurchaseOrderSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPurchaseOrderSearch));
            this.pInfo = new System.Windows.Forms.Panel();
            this.btnPurchasedPart = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOperate = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pgControl = new CZZD.ERP.ComControls.PageControl();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.Row = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLIP_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUPPLIER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WAREHOUSE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLIP_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DUE_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RECEIPT_CONDITION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CURRENCY_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUPPLIER_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRight = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdolibraryNo = new System.Windows.Forms.RadioButton();
            this.rdolibraryOk = new System.Windows.Forms.RadioButton();
            this.rdoAllLibrary = new System.Windows.Forms.RadioButton();
            this.slipDateTo = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dueDateTo = new System.Windows.Forms.DateTimePicker();
            this.slipDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dueDateFrom = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pRight_1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pLeft = new System.Windows.Forms.Panel();
            this.pLeft_2 = new System.Windows.Forms.Panel();
            this.cboPurchaseSlipType = new System.Windows.Forms.ComboBox();
            this.txtWarehouseName = new System.Windows.Forms.TextBox();
            this.txtWarehouseCode = new System.Windows.Forms.TextBox();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.btnWarehouse = new System.Windows.Forms.Button();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.txtSupplierCode = new System.Windows.Forms.TextBox();
            this.txtPurchaseOrderCode = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnInquirySheet = new System.Windows.Forms.Button();
            this.pInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.pRight.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pRight_1.SuspendLayout();
            this.pLeft.SuspendLayout();
            this.pLeft_2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pInfo
            // 
            this.pInfo.BackColor = System.Drawing.Color.White;
            this.pInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pInfo.Controls.Add(this.btnInquirySheet);
            this.pInfo.Controls.Add(this.btnPurchasedPart);
            this.pInfo.Controls.Add(this.btnModify);
            this.pInfo.Controls.Add(this.btnClose);
            this.pInfo.Controls.Add(this.btnOperate);
            this.pInfo.Controls.Add(this.btnPrint);
            this.pInfo.Controls.Add(this.pgControl);
            this.pInfo.Controls.Add(this.dgvData);
            this.pInfo.Controls.Add(this.pRight);
            this.pInfo.Controls.Add(this.pLeft);
            this.pInfo.Location = new System.Drawing.Point(0, 0);
            this.pInfo.Name = "pInfo";
            this.pInfo.Size = new System.Drawing.Size(1020, 650);
            this.pInfo.TabIndex = 0;
            // 
            // btnPurchasedPart
            // 
            this.btnPurchasedPart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPurchasedPart.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnPurchasedPart.Location = new System.Drawing.Point(553, 615);
            this.btnPurchasedPart.Name = "btnPurchasedPart";
            this.btnPurchasedPart.Size = new System.Drawing.Size(90, 30);
            this.btnPurchasedPart.TabIndex = 11;
            this.btnPurchasedPart.Text = "外购件订单";
            this.btnPurchasedPart.UseVisualStyleBackColor = true;
            this.btnPurchasedPart.Click += new System.EventHandler(this.btnSupplierFax_Click);
            // 
            // btnModify
            // 
            this.btnModify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModify.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnModify.Location = new System.Drawing.Point(740, 615);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(90, 30);
            this.btnModify.TabIndex = 8;
            this.btnModify.Text = "修　改";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnClose.Location = new System.Drawing.Point(925, 615);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 30);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "关　闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOperate
            // 
            this.btnOperate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOperate.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnOperate.Location = new System.Drawing.Point(833, 615);
            this.btnOperate.Name = "btnOperate";
            this.btnOperate.Size = new System.Drawing.Size(90, 30);
            this.btnOperate.TabIndex = 9;
            this.btnOperate.Text = "详细确认";
            this.btnOperate.UseVisualStyleBackColor = true;
            this.btnOperate.Click += new System.EventHandler(this.btnOperate_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnPrint.Location = new System.Drawing.Point(647, 615);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(90, 30);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "订单跟踪";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // pgControl
            // 
            this.pgControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pgControl.Location = new System.Drawing.Point(3, 583);
            this.pgControl.Name = "pgControl";
            this.pgControl.Size = new System.Drawing.Size(1012, 30);
            this.pgControl.TabIndex = 5;
            this.pgControl.TotalPage = 1;
            this.pgControl.PageChanged += new CZZD.ERP.ComControls.PageControl.BtnClickHandle(this.pgControl_PageChanged);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvData.ColumnHeadersHeight = 25;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Row,
            this.SLIP_NUMBER,
            this.SUPPLIER_NAME,
            this.WAREHOUSE_NAME,
            this.SLIP_DATE,
            this.DUE_DATE,
            this.TOTAL_AMOUNT,
            this.RECEIPT_CONDITION,
            this.CURRENCY_NAME,
            this.SUPPLIER_CODE});
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(3, 197);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.dgvData.RowTemplate.Height = 25;
            this.dgvData.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1012, 385);
            this.dgvData.TabIndex = 4;
            this.dgvData.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvData_RowStateChanged);
            // 
            // Row
            // 
            this.Row.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Row.DataPropertyName = "Row";
            this.Row.HeaderText = "No";
            this.Row.Name = "Row";
            this.Row.ReadOnly = true;
            this.Row.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Row.Width = 40;
            // 
            // SLIP_NUMBER
            // 
            this.SLIP_NUMBER.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SLIP_NUMBER.DataPropertyName = "SLIP_NUMBER";
            this.SLIP_NUMBER.HeaderText = "订单编号";
            this.SLIP_NUMBER.Name = "SLIP_NUMBER";
            this.SLIP_NUMBER.ReadOnly = true;
            this.SLIP_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SLIP_NUMBER.Width = 120;
            // 
            // SUPPLIER_NAME
            // 
            this.SUPPLIER_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SUPPLIER_NAME.DataPropertyName = "SUPPLIER_NAME";
            this.SUPPLIER_NAME.HeaderText = "供应商";
            this.SUPPLIER_NAME.Name = "SUPPLIER_NAME";
            this.SUPPLIER_NAME.ReadOnly = true;
            this.SUPPLIER_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SUPPLIER_NAME.Width = 120;
            // 
            // WAREHOUSE_NAME
            // 
            this.WAREHOUSE_NAME.DataPropertyName = "WAREHOUSE_NAME";
            this.WAREHOUSE_NAME.HeaderText = "入库仓库";
            this.WAREHOUSE_NAME.Name = "WAREHOUSE_NAME";
            this.WAREHOUSE_NAME.ReadOnly = true;
            this.WAREHOUSE_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SLIP_DATE
            // 
            this.SLIP_DATE.DataPropertyName = "SLIP_DATE";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "yyyy-MM-dd";
            dataGridViewCellStyle2.NullValue = null;
            this.SLIP_DATE.DefaultCellStyle = dataGridViewCellStyle2;
            this.SLIP_DATE.HeaderText = "采购日期";
            this.SLIP_DATE.Name = "SLIP_DATE";
            this.SLIP_DATE.ReadOnly = true;
            this.SLIP_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DUE_DATE
            // 
            this.DUE_DATE.DataPropertyName = "DUE_DATE";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "yyyy-MM-dd";
            dataGridViewCellStyle3.NullValue = null;
            this.DUE_DATE.DefaultCellStyle = dataGridViewCellStyle3;
            this.DUE_DATE.HeaderText = "预计入库日期";
            this.DUE_DATE.Name = "DUE_DATE";
            this.DUE_DATE.ReadOnly = true;
            this.DUE_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TOTAL_AMOUNT
            // 
            this.TOTAL_AMOUNT.DataPropertyName = "TOTAL_AMOUNT";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.TOTAL_AMOUNT.DefaultCellStyle = dataGridViewCellStyle4;
            this.TOTAL_AMOUNT.HeaderText = "金额";
            this.TOTAL_AMOUNT.Name = "TOTAL_AMOUNT";
            this.TOTAL_AMOUNT.ReadOnly = true;
            this.TOTAL_AMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RECEIPT_CONDITION
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.RECEIPT_CONDITION.DefaultCellStyle = dataGridViewCellStyle5;
            this.RECEIPT_CONDITION.HeaderText = "入库状况";
            this.RECEIPT_CONDITION.Name = "RECEIPT_CONDITION";
            this.RECEIPT_CONDITION.ReadOnly = true;
            this.RECEIPT_CONDITION.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CURRENCY_NAME
            // 
            this.CURRENCY_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CURRENCY_NAME.DataPropertyName = "CURRENCY_NAME";
            this.CURRENCY_NAME.HeaderText = "通货";
            this.CURRENCY_NAME.Name = "CURRENCY_NAME";
            this.CURRENCY_NAME.ReadOnly = true;
            this.CURRENCY_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CURRENCY_NAME.Visible = false;
            // 
            // SUPPLIER_CODE
            // 
            this.SUPPLIER_CODE.DataPropertyName = "SUPPLIER_CODE";
            this.SUPPLIER_CODE.HeaderText = "SUPPLIER_CODE";
            this.SUPPLIER_CODE.Name = "SUPPLIER_CODE";
            this.SUPPLIER_CODE.ReadOnly = true;
            this.SUPPLIER_CODE.Visible = false;
            // 
            // pRight
            // 
            this.pRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pRight.Controls.Add(this.panel2);
            this.pRight.Controls.Add(this.pRight_1);
            this.pRight.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pRight.Location = new System.Drawing.Point(514, 3);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(500, 191);
            this.pRight.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.slipDateTo);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.dueDateTo);
            this.panel2.Controls.Add(this.slipDateFrom);
            this.panel2.Controls.Add(this.dueDateFrom);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(120, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(378, 189);
            this.panel2.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(117, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 23);
            this.label5.TabIndex = 16;
            this.label5.Text = "~";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rdolibraryNo);
            this.panel3.Controls.Add(this.rdolibraryOk);
            this.panel3.Controls.Add(this.rdoAllLibrary);
            this.panel3.Location = new System.Drawing.Point(5, 59);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(370, 31);
            this.panel3.TabIndex = 20;
            // 
            // rdolibraryNo
            // 
            this.rdolibraryNo.AutoSize = true;
            this.rdolibraryNo.Location = new System.Drawing.Point(187, 4);
            this.rdolibraryNo.Name = "rdolibraryNo";
            this.rdolibraryNo.Size = new System.Drawing.Size(62, 21);
            this.rdolibraryNo.TabIndex = 0;
            this.rdolibraryNo.Text = "未入库";
            this.rdolibraryNo.UseVisualStyleBackColor = true;
            // 
            // rdolibraryOk
            // 
            this.rdolibraryOk.AutoSize = true;
            this.rdolibraryOk.Location = new System.Drawing.Point(91, 4);
            this.rdolibraryOk.Name = "rdolibraryOk";
            this.rdolibraryOk.Size = new System.Drawing.Size(62, 21);
            this.rdolibraryOk.TabIndex = 0;
            this.rdolibraryOk.Text = "已入库";
            this.rdolibraryOk.UseVisualStyleBackColor = true;
            // 
            // rdoAllLibrary
            // 
            this.rdoAllLibrary.AutoSize = true;
            this.rdoAllLibrary.Checked = true;
            this.rdoAllLibrary.Location = new System.Drawing.Point(3, 4);
            this.rdoAllLibrary.Name = "rdoAllLibrary";
            this.rdoAllLibrary.Size = new System.Drawing.Size(50, 21);
            this.rdoAllLibrary.TabIndex = 0;
            this.rdoAllLibrary.TabStop = true;
            this.rdoAllLibrary.Text = "全部";
            this.rdoAllLibrary.UseVisualStyleBackColor = true;
            // 
            // slipDateTo
            // 
            this.slipDateTo.CalendarFont = new System.Drawing.Font("微软雅黑", 10F);
            this.slipDateTo.Checked = false;
            this.slipDateTo.CustomFormat = "yyyy-MM-dd";
            this.slipDateTo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.slipDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.slipDateTo.Location = new System.Drawing.Point(143, 5);
            this.slipDateTo.Name = "slipDateTo";
            this.slipDateTo.ShowCheckBox = true;
            this.slipDateTo.Size = new System.Drawing.Size(112, 23);
            this.slipDateTo.TabIndex = 9;
            this.slipDateTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.slipDateTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(117, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 23);
            this.label9.TabIndex = 19;
            this.label9.Text = "~";
            this.label9.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // dueDateTo
            // 
            this.dueDateTo.CalendarFont = new System.Drawing.Font("微软雅黑", 10F);
            this.dueDateTo.Checked = false;
            this.dueDateTo.CustomFormat = "yyyy-MM-dd";
            this.dueDateTo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dueDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dueDateTo.Location = new System.Drawing.Point(143, 35);
            this.dueDateTo.Name = "dueDateTo";
            this.dueDateTo.ShowCheckBox = true;
            this.dueDateTo.Size = new System.Drawing.Size(112, 23);
            this.dueDateTo.TabIndex = 2;
            this.dueDateTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.dueDateTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // slipDateFrom
            // 
            this.slipDateFrom.CalendarFont = new System.Drawing.Font("微软雅黑", 10F);
            this.slipDateFrom.Checked = false;
            this.slipDateFrom.CustomFormat = "yyyy-MM-dd";
            this.slipDateFrom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.slipDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.slipDateFrom.Location = new System.Drawing.Point(5, 5);
            this.slipDateFrom.Name = "slipDateFrom";
            this.slipDateFrom.ShowCheckBox = true;
            this.slipDateFrom.Size = new System.Drawing.Size(112, 23);
            this.slipDateFrom.TabIndex = 8;
            this.slipDateFrom.Value = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.slipDateFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.slipDateFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // dueDateFrom
            // 
            this.dueDateFrom.CalendarFont = new System.Drawing.Font("微软雅黑", 10F);
            this.dueDateFrom.Checked = false;
            this.dueDateFrom.CustomFormat = "yyyy-MM-dd";
            this.dueDateFrom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dueDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dueDateFrom.Location = new System.Drawing.Point(5, 35);
            this.dueDateFrom.Name = "dueDateFrom";
            this.dueDateFrom.ShowCheckBox = true;
            this.dueDateFrom.Size = new System.Drawing.Size(112, 23);
            this.dueDateFrom.TabIndex = 1;
            this.dueDateFrom.Value = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.dueDateFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.dueDateFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnSearch.Location = new System.Drawing.Point(285, 156);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 30);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查   询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // pRight_1
            // 
            this.pRight_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pRight_1.Controls.Add(this.label4);
            this.pRight_1.Controls.Add(this.label10);
            this.pRight_1.Controls.Add(this.label8);
            this.pRight_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pRight_1.Location = new System.Drawing.Point(0, 0);
            this.pRight_1.Name = "pRight_1";
            this.pRight_1.Size = new System.Drawing.Size(120, 189);
            this.pRight_1.TabIndex = 2;
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
            this.label4.TabIndex = 8;
            this.label4.Text = "  采购日期";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(5, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 20);
            this.label10.TabIndex = 10;
            this.label10.Text = "  入库状况";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(5, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 20);
            this.label8.TabIndex = 9;
            this.label8.Text = "  预计入库日期";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pLeft
            // 
            this.pLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLeft.Controls.Add(this.pLeft_2);
            this.pLeft.Controls.Add(this.panel1);
            this.pLeft.Location = new System.Drawing.Point(3, 3);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(510, 191);
            this.pLeft.TabIndex = 1;
            // 
            // pLeft_2
            // 
            this.pLeft_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pLeft_2.Controls.Add(this.cboPurchaseSlipType);
            this.pLeft_2.Controls.Add(this.txtWarehouseName);
            this.pLeft_2.Controls.Add(this.txtWarehouseCode);
            this.pLeft_2.Controls.Add(this.txtSupplierName);
            this.pLeft_2.Controls.Add(this.btnWarehouse);
            this.pLeft_2.Controls.Add(this.btnSupplier);
            this.pLeft_2.Controls.Add(this.txtSupplierCode);
            this.pLeft_2.Controls.Add(this.txtPurchaseOrderCode);
            this.pLeft_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pLeft_2.Location = new System.Drawing.Point(120, 0);
            this.pLeft_2.Name = "pLeft_2";
            this.pLeft_2.Size = new System.Drawing.Size(388, 189);
            this.pLeft_2.TabIndex = 0;
            // 
            // cboPurchaseSlipType
            // 
            this.cboPurchaseSlipType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPurchaseSlipType.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cboPurchaseSlipType.FormattingEnabled = true;
            this.cboPurchaseSlipType.Location = new System.Drawing.Point(5, 5);
            this.cboPurchaseSlipType.Name = "cboPurchaseSlipType";
            this.cboPurchaseSlipType.Size = new System.Drawing.Size(250, 25);
            this.cboPurchaseSlipType.TabIndex = 8;
            // 
            // txtWarehouseName
            // 
            this.txtWarehouseName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtWarehouseName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWarehouseName.Enabled = false;
            this.txtWarehouseName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtWarehouseName.Location = new System.Drawing.Point(5, 155);
            this.txtWarehouseName.Name = "txtWarehouseName";
            this.txtWarehouseName.Size = new System.Drawing.Size(250, 25);
            this.txtWarehouseName.TabIndex = 7;
            // 
            // txtWarehouseCode
            // 
            this.txtWarehouseCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtWarehouseCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWarehouseCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtWarehouseCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtWarehouseCode.Location = new System.Drawing.Point(5, 125);
            this.txtWarehouseCode.MaxLength = 20;
            this.txtWarehouseCode.Name = "txtWarehouseCode";
            this.txtWarehouseCode.Size = new System.Drawing.Size(250, 25);
            this.txtWarehouseCode.TabIndex = 5;
            this.txtWarehouseCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtWarehouseCode.Leave += new System.EventHandler(this.txtWarehouseCode_Leave);
            this.txtWarehouseCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtSupplierName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupplierName.Enabled = false;
            this.txtSupplierName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSupplierName.Location = new System.Drawing.Point(5, 95);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(250, 25);
            this.txtSupplierName.TabIndex = 4;
            // 
            // btnWarehouse
            // 
            this.btnWarehouse.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnWarehouse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnWarehouse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWarehouse.FlatAppearance.BorderSize = 0;
            this.btnWarehouse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnWarehouse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnWarehouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWarehouse.Location = new System.Drawing.Point(261, 126);
            this.btnWarehouse.Name = "btnWarehouse";
            this.btnWarehouse.Size = new System.Drawing.Size(25, 25);
            this.btnWarehouse.TabIndex = 6;
            this.btnWarehouse.UseVisualStyleBackColor = true;
            this.btnWarehouse.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btnWarehouse.Click += new System.EventHandler(this.btnWarehouse_Click);
            this.btnWarehouse.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
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
            this.btnSupplier.Location = new System.Drawing.Point(261, 65);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(25, 25);
            this.btnSupplier.TabIndex = 3;
            this.btnSupplier.UseVisualStyleBackColor = true;
            this.btnSupplier.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            this.btnSupplier.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            // 
            // txtSupplierCode
            // 
            this.txtSupplierCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtSupplierCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupplierCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSupplierCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtSupplierCode.Location = new System.Drawing.Point(5, 65);
            this.txtSupplierCode.MaxLength = 20;
            this.txtSupplierCode.Name = "txtSupplierCode";
            this.txtSupplierCode.Size = new System.Drawing.Size(250, 25);
            this.txtSupplierCode.TabIndex = 2;
            this.txtSupplierCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtSupplierCode.Leave += new System.EventHandler(this.txtSupplierCode_Leave);
            this.txtSupplierCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtPurchaseOrderCode
            // 
            this.txtPurchaseOrderCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtPurchaseOrderCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPurchaseOrderCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtPurchaseOrderCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtPurchaseOrderCode.Location = new System.Drawing.Point(5, 35);
            this.txtPurchaseOrderCode.MaxLength = 20;
            this.txtPurchaseOrderCode.Name = "txtPurchaseOrderCode";
            this.txtPurchaseOrderCode.Size = new System.Drawing.Size(250, 25);
            this.txtPurchaseOrderCode.TabIndex = 1;
            this.txtPurchaseOrderCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtPurchaseOrderCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 189);
            this.panel1.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(5, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 20);
            this.label11.TabIndex = 9;
            this.label11.Text = "  采购订单类型";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(5, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "  入库仓库名称";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "  供应商名称";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(5, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "  入库仓库编号";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label1.TabIndex = 6;
            this.label1.Text = "  供应商编号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "  订单编号";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnInquirySheet
            // 
            this.btnInquirySheet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInquirySheet.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnInquirySheet.Location = new System.Drawing.Point(457, 615);
            this.btnInquirySheet.Name = "btnInquirySheet";
            this.btnInquirySheet.Size = new System.Drawing.Size(90, 30);
            this.btnInquirySheet.TabIndex = 12;
            this.btnInquirySheet.Text = "询价单";
            this.btnInquirySheet.UseVisualStyleBackColor = true;
            this.btnInquirySheet.Click += new System.EventHandler(this.btnInquirySheet_Click);
            // 
            // FrmPurchaseOrderSearch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1028, 652);
            this.Controls.Add(this.pInfo);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmPurchaseOrderSearch";
            this.Text = "采购订单查询";
            this.Load += new System.EventHandler(this.FrmPurchaseSearch_Load);
            this.pInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.pRight.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pRight_1.ResumeLayout(false);
            this.pLeft.ResumeLayout(false);
            this.pLeft_2.ResumeLayout(false);
            this.pLeft_2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pInfo;
        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pLeft_2;
        private System.Windows.Forms.TextBox txtPurchaseOrderCode;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.TextBox txtSupplierCode;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.DateTimePicker slipDateFrom;
        private System.Windows.Forms.DateTimePicker slipDateTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.Panel pRight_1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtWarehouseName;
        private System.Windows.Forms.TextBox txtWarehouseCode;
        private System.Windows.Forms.Button btnWarehouse;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dueDateTo;
        private System.Windows.Forms.DateTimePicker dueDateFrom;
        private System.Windows.Forms.Button btnSearch;
        private CZZD.ERP.ComControls.PageControl pgControl;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOperate;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rdolibraryNo;
        private System.Windows.Forms.RadioButton rdolibraryOk;
        private System.Windows.Forms.RadioButton rdoAllLibrary;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboPurchaseSlipType;
        private System.Windows.Forms.Button btnPurchasedPart;
        private System.Windows.Forms.DataGridViewTextBoxColumn Row;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLIP_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUPPLIER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn WAREHOUSE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLIP_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DUE_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL_AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn RECEIPT_CONDITION;
        private System.Windows.Forms.DataGridViewTextBoxColumn CURRENCY_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUPPLIER_CODE;
        private System.Windows.Forms.Button btnInquirySheet;
    }
}