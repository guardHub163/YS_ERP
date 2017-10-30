namespace CZZD.ERP.WinUI
{
    partial class FrmShipment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShipment));
            this.pBody = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.pHeader = new System.Windows.Forms.Panel();
            this.pRight = new System.Windows.Forms.Panel();
            this.pRight_2 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pRight_1 = new System.Windows.Forms.Panel();
            this.pLeft = new System.Windows.Forms.Panel();
            this.pleft_2 = new System.Windows.Forms.Panel();
            this.btnEndCustomer = new System.Windows.Forms.Button();
            this.txtDepartualDateFrom = new System.Windows.Forms.DateTimePicker();
            this.txtSlipNumber = new System.Windows.Forms.TextBox();
            this.txtDepartualDateTo = new System.Windows.Forms.DateTimePicker();
            this.txtCustomerPoNumber = new System.Windows.Forms.TextBox();
            this.txtSlipDateTo = new System.Windows.Forms.DateTimePicker();
            this.txtEndCustomerName = new System.Windows.Forms.TextBox();
            this.txtSlipDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEndCustomerCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pLeft_1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHIPMENT_CHK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SLIP_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.END_CUSTOMER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WAREHOUSE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEPARTUAL_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ARRIVAL_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTOMER_PO_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDER_QUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHIPMENT_QUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNIT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SERIAL_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHECK_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ALLOATION_QUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRUE_SLIP_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LINE_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LINE_MEMO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNIT_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WAREHOUSE_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CURRENCY_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TAX_RATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHIPMENT_DEPOSIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AMOUNT_INCLUDED_TAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHIPMENT_FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.pHeader.SuspendLayout();
            this.pRight.SuspendLayout();
            this.pRight_2.SuspendLayout();
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
            this.pBody.Controls.Add(this.pHeader);
            this.pBody.Location = new System.Drawing.Point(0, 0);
            this.pBody.Name = "pBody";
            this.pBody.Size = new System.Drawing.Size(1024, 650);
            this.pBody.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Location = new System.Drawing.Point(929, 615);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 30);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关　闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Location = new System.Drawing.Point(838, 615);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "出库确定";
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
            this.dgvData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvData.ColumnHeadersHeight = 25;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NO,
            this.SHIPMENT_CHK,
            this.SLIP_NUMBER,
            this.END_CUSTOMER_NAME,
            this.WAREHOUSE_NAME,
            this.DEPARTUAL_DATE,
            this.ARRIVAL_DATE,
            this.CUSTOMER_PO_NUMBER,
            this.PRODUCT_CODE,
            this.PRODUCT_NAME,
            this.ORDER_QUANTITY,
            this.SHIPMENT_QUANTITY,
            this.QUANTITY,
            this.UNIT_NAME,
            this.SERIAL_NUMBER,
            this.CHECK_NUMBER,
            this.ALLOATION_QUANTITY,
            this.TRUE_SLIP_NUMBER,
            this.LINE_NUMBER,
            this.LINE_MEMO,
            this.UNIT_CODE,
            this.WAREHOUSE_CODE,
            this.CURRENCY_CODE,
            this.PRICE,
            this.TAX_RATE,
            this.SHIPMENT_DEPOSIT,
            this.AMOUNT_INCLUDED_TAX,
            this.SHIPMENT_FLAG});
            this.dgvData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(3, 200);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            this.dgvData.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.Size = new System.Drawing.Size(1015, 412);
            this.dgvData.TabIndex = 2;
            this.dgvData.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellValidated);
            this.dgvData.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvData_CellPainting);
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);
            this.dgvData.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvData_EditingControlShowing);
            this.dgvData.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvData_RowStateChanged);
            // 
            // pHeader
            // 
            this.pHeader.Controls.Add(this.pRight);
            this.pHeader.Controls.Add(this.pLeft);
            this.pHeader.Controls.Add(this.dateTimePicker2);
            this.pHeader.Location = new System.Drawing.Point(3, 3);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(1021, 195);
            this.pHeader.TabIndex = 1;
            // 
            // pRight
            // 
            this.pRight.BackColor = System.Drawing.Color.Transparent;
            this.pRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pRight.Controls.Add(this.pRight_2);
            this.pRight.Controls.Add(this.pRight_1);
            this.pRight.Location = new System.Drawing.Point(515, 0);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(500, 191);
            this.pRight.TabIndex = 2;
            // 
            // pRight_2
            // 
            this.pRight_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pRight_2.Controls.Add(this.btnSearch);
            this.pRight_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRight_2.Location = new System.Drawing.Point(120, 0);
            this.pRight_2.Name = "pRight_2";
            this.pRight_2.Size = new System.Drawing.Size(378, 189);
            this.pRight_2.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Location = new System.Drawing.Point(285, 155);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 30);
            this.btnSearch.TabIndex = 5;
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
            this.pRight_1.Size = new System.Drawing.Size(120, 189);
            this.pRight_1.TabIndex = 1;
            // 
            // pLeft
            // 
            this.pLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLeft.Controls.Add(this.pleft_2);
            this.pLeft.Controls.Add(this.pLeft_1);
            this.pLeft.Location = new System.Drawing.Point(0, 0);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(510, 191);
            this.pLeft.TabIndex = 1;
            // 
            // pleft_2
            // 
            this.pleft_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pleft_2.Controls.Add(this.btnEndCustomer);
            this.pleft_2.Controls.Add(this.txtDepartualDateFrom);
            this.pleft_2.Controls.Add(this.txtSlipNumber);
            this.pleft_2.Controls.Add(this.txtDepartualDateTo);
            this.pleft_2.Controls.Add(this.txtCustomerPoNumber);
            this.pleft_2.Controls.Add(this.txtSlipDateTo);
            this.pleft_2.Controls.Add(this.txtEndCustomerName);
            this.pleft_2.Controls.Add(this.txtSlipDateFrom);
            this.pleft_2.Controls.Add(this.label1);
            this.pleft_2.Controls.Add(this.txtEndCustomerCode);
            this.pleft_2.Controls.Add(this.label6);
            this.pleft_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pleft_2.Location = new System.Drawing.Point(120, 0);
            this.pleft_2.Name = "pleft_2";
            this.pleft_2.Size = new System.Drawing.Size(388, 189);
            this.pleft_2.TabIndex = 0;
            // 
            // btnEndCustomer
            // 
            this.btnEndCustomer.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnEndCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEndCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEndCustomer.FlatAppearance.BorderSize = 0;
            this.btnEndCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEndCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEndCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEndCustomer.Location = new System.Drawing.Point(261, 65);
            this.btnEndCustomer.Name = "btnEndCustomer";
            this.btnEndCustomer.Size = new System.Drawing.Size(25, 25);
            this.btnEndCustomer.TabIndex = 5;
            this.btnEndCustomer.UseVisualStyleBackColor = true;
            this.btnEndCustomer.Click += new System.EventHandler(this.btnEndCustomer_Click);
            // 
            // txtDepartualDateFrom
            // 
            this.txtDepartualDateFrom.CalendarFont = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDepartualDateFrom.Checked = false;
            this.txtDepartualDateFrom.CustomFormat = "yyyy-MM-dd";
            this.txtDepartualDateFrom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDepartualDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDepartualDateFrom.Location = new System.Drawing.Point(5, 157);
            this.txtDepartualDateFrom.Name = "txtDepartualDateFrom";
            this.txtDepartualDateFrom.ShowCheckBox = true;
            this.txtDepartualDateFrom.Size = new System.Drawing.Size(113, 23);
            this.txtDepartualDateFrom.TabIndex = 3;
            // 
            // txtSlipNumber
            // 
            this.txtSlipNumber.BackColor = System.Drawing.SystemColors.Info;
            this.txtSlipNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSlipNumber.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSlipNumber.Location = new System.Drawing.Point(5, 5);
            this.txtSlipNumber.Name = "txtSlipNumber";
            this.txtSlipNumber.Size = new System.Drawing.Size(250, 25);
            this.txtSlipNumber.TabIndex = 0;
            // 
            // txtDepartualDateTo
            // 
            this.txtDepartualDateTo.CalendarFont = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDepartualDateTo.Checked = false;
            this.txtDepartualDateTo.CustomFormat = "yyyy-MM-dd";
            this.txtDepartualDateTo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDepartualDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDepartualDateTo.Location = new System.Drawing.Point(141, 157);
            this.txtDepartualDateTo.Name = "txtDepartualDateTo";
            this.txtDepartualDateTo.ShowCheckBox = true;
            this.txtDepartualDateTo.Size = new System.Drawing.Size(113, 23);
            this.txtDepartualDateTo.TabIndex = 4;
            // 
            // txtCustomerPoNumber
            // 
            this.txtCustomerPoNumber.BackColor = System.Drawing.SystemColors.Info;
            this.txtCustomerPoNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerPoNumber.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCustomerPoNumber.Location = new System.Drawing.Point(5, 35);
            this.txtCustomerPoNumber.Name = "txtCustomerPoNumber";
            this.txtCustomerPoNumber.Size = new System.Drawing.Size(250, 25);
            this.txtCustomerPoNumber.TabIndex = 1;
            // 
            // txtSlipDateTo
            // 
            this.txtSlipDateTo.CalendarFont = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSlipDateTo.Checked = false;
            this.txtSlipDateTo.CustomFormat = "yyyy-MM-dd";
            this.txtSlipDateTo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSlipDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtSlipDateTo.Location = new System.Drawing.Point(141, 127);
            this.txtSlipDateTo.Name = "txtSlipDateTo";
            this.txtSlipDateTo.ShowCheckBox = true;
            this.txtSlipDateTo.Size = new System.Drawing.Size(113, 23);
            this.txtSlipDateTo.TabIndex = 2;
            // 
            // txtEndCustomerName
            // 
            this.txtEndCustomerName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtEndCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEndCustomerName.Enabled = false;
            this.txtEndCustomerName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtEndCustomerName.Location = new System.Drawing.Point(5, 95);
            this.txtEndCustomerName.Name = "txtEndCustomerName";
            this.txtEndCustomerName.Size = new System.Drawing.Size(250, 25);
            this.txtEndCustomerName.TabIndex = 0;
            // 
            // txtSlipDateFrom
            // 
            this.txtSlipDateFrom.CalendarFont = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSlipDateFrom.Checked = false;
            this.txtSlipDateFrom.CustomFormat = "yyyy-MM-dd";
            this.txtSlipDateFrom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSlipDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtSlipDateFrom.Location = new System.Drawing.Point(5, 127);
            this.txtSlipDateFrom.Name = "txtSlipDateFrom";
            this.txtSlipDateFrom.ShowCheckBox = true;
            this.txtSlipDateFrom.Size = new System.Drawing.Size(113, 23);
            this.txtSlipDateFrom.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(123, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 19);
            this.label1.TabIndex = 11;
            this.label1.Text = "~";
            // 
            // txtEndCustomerCode
            // 
            this.txtEndCustomerCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtEndCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEndCustomerCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtEndCustomerCode.Location = new System.Drawing.Point(5, 65);
            this.txtEndCustomerCode.Name = "txtEndCustomerCode";
            this.txtEndCustomerCode.Size = new System.Drawing.Size(250, 25);
            this.txtEndCustomerCode.TabIndex = 4;
            this.txtEndCustomerCode.Leave += new System.EventHandler(this.txtEndCustomerCode_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(123, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "~";
            // 
            // pLeft_1
            // 
            this.pLeft_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pLeft_1.Controls.Add(this.label9);
            this.pLeft_1.Controls.Add(this.label2);
            this.pLeft_1.Controls.Add(this.label7);
            this.pLeft_1.Controls.Add(this.label3);
            this.pLeft_1.Controls.Add(this.label5);
            this.pLeft_1.Controls.Add(this.label14);
            this.pLeft_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeft_1.Location = new System.Drawing.Point(0, 0);
            this.pLeft_1.Name = "pLeft_1";
            this.pLeft_1.Size = new System.Drawing.Size(120, 189);
            this.pLeft_1.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(5, 157);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "  出库预定日期";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "  销售单号";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(5, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "  销售日期";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label3.TabIndex = 0;
            this.label3.Text = "  合同编号";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "  客户编号";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(5, 95);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(110, 20);
            this.label14.TabIndex = 0;
            this.label14.Text = "  客户名称";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.dateTimePicker2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.dateTimePicker2.Location = new System.Drawing.Point(1289, 522);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(250, 29);
            this.dateTimePicker2.TabIndex = 2;
            // 
            // NO
            // 
            this.NO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NO.FillWeight = 40F;
            this.NO.Frozen = true;
            this.NO.HeaderText = "No";
            this.NO.Name = "NO";
            this.NO.ReadOnly = true;
            this.NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NO.Width = 40;
            // 
            // SHIPMENT_CHK
            // 
            this.SHIPMENT_CHK.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SHIPMENT_CHK.FillWeight = 50F;
            this.SHIPMENT_CHK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.SHIPMENT_CHK.Frozen = true;
            this.SHIPMENT_CHK.HeaderText = "选择";
            this.SHIPMENT_CHK.Name = "SHIPMENT_CHK";
            this.SHIPMENT_CHK.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SHIPMENT_CHK.Width = 50;
            // 
            // SLIP_NUMBER
            // 
            this.SLIP_NUMBER.FillWeight = 80F;
            this.SLIP_NUMBER.Frozen = true;
            this.SLIP_NUMBER.HeaderText = "销售单号";
            this.SLIP_NUMBER.Name = "SLIP_NUMBER";
            this.SLIP_NUMBER.ReadOnly = true;
            this.SLIP_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SLIP_NUMBER.Width = 120;
            // 
            // END_CUSTOMER_NAME
            // 
            this.END_CUSTOMER_NAME.DataPropertyName = "END_CUSTOMER_NAME";
            this.END_CUSTOMER_NAME.Frozen = true;
            this.END_CUSTOMER_NAME.HeaderText = "客户名称";
            this.END_CUSTOMER_NAME.Name = "END_CUSTOMER_NAME";
            this.END_CUSTOMER_NAME.ReadOnly = true;
            this.END_CUSTOMER_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.END_CUSTOMER_NAME.Width = 130;
            // 
            // WAREHOUSE_NAME
            // 
            this.WAREHOUSE_NAME.HeaderText = "出库仓库";
            this.WAREHOUSE_NAME.Name = "WAREHOUSE_NAME";
            this.WAREHOUSE_NAME.ReadOnly = true;
            this.WAREHOUSE_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.WAREHOUSE_NAME.Width = 150;
            // 
            // DEPARTUAL_DATE
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.Format = "yyyy-MM-dd";
            dataGridViewCellStyle2.NullValue = null;
            this.DEPARTUAL_DATE.DefaultCellStyle = dataGridViewCellStyle2;
            this.DEPARTUAL_DATE.HeaderText = "出库日期";
            this.DEPARTUAL_DATE.MaxInputLength = 10;
            this.DEPARTUAL_DATE.Name = "DEPARTUAL_DATE";
            this.DEPARTUAL_DATE.ReadOnly = true;
            this.DEPARTUAL_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ARRIVAL_DATE
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle3.Format = "yyyy-MM-dd";
            dataGridViewCellStyle3.NullValue = null;
            this.ARRIVAL_DATE.DefaultCellStyle = dataGridViewCellStyle3;
            this.ARRIVAL_DATE.HeaderText = "预定到达日期";
            this.ARRIVAL_DATE.MaxInputLength = 10;
            this.ARRIVAL_DATE.Name = "ARRIVAL_DATE";
            this.ARRIVAL_DATE.ReadOnly = true;
            this.ARRIVAL_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CUSTOMER_PO_NUMBER
            // 
            this.CUSTOMER_PO_NUMBER.DataPropertyName = "CUSTOMER_PO_NUMBER";
            this.CUSTOMER_PO_NUMBER.HeaderText = "合同编号";
            this.CUSTOMER_PO_NUMBER.Name = "CUSTOMER_PO_NUMBER";
            this.CUSTOMER_PO_NUMBER.ReadOnly = true;
            // 
            // PRODUCT_CODE
            // 
            this.PRODUCT_CODE.HeaderText = "商品编号";
            this.PRODUCT_CODE.Name = "PRODUCT_CODE";
            this.PRODUCT_CODE.ReadOnly = true;
            this.PRODUCT_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PRODUCT_CODE.Width = 120;
            // 
            // PRODUCT_NAME
            // 
            this.PRODUCT_NAME.HeaderText = "商品名称";
            this.PRODUCT_NAME.Name = "PRODUCT_NAME";
            this.PRODUCT_NAME.ReadOnly = true;
            this.PRODUCT_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PRODUCT_NAME.Width = 150;
            // 
            // ORDER_QUANTITY
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.ORDER_QUANTITY.DefaultCellStyle = dataGridViewCellStyle4;
            this.ORDER_QUANTITY.HeaderText = "销售数量";
            this.ORDER_QUANTITY.Name = "ORDER_QUANTITY";
            this.ORDER_QUANTITY.ReadOnly = true;
            this.ORDER_QUANTITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ORDER_QUANTITY.Width = 70;
            // 
            // SHIPMENT_QUANTITY
            // 
            this.SHIPMENT_QUANTITY.DataPropertyName = "SHIPMENT_QUANTITY";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            this.SHIPMENT_QUANTITY.DefaultCellStyle = dataGridViewCellStyle5;
            this.SHIPMENT_QUANTITY.HeaderText = "已出库数量";
            this.SHIPMENT_QUANTITY.Name = "SHIPMENT_QUANTITY";
            this.SHIPMENT_QUANTITY.ReadOnly = true;
            // 
            // QUANTITY
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle6.Format = "N0";
            this.QUANTITY.DefaultCellStyle = dataGridViewCellStyle6;
            this.QUANTITY.HeaderText = "本次出库数量";
            this.QUANTITY.MaxInputLength = 10;
            this.QUANTITY.Name = "QUANTITY";
            this.QUANTITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.QUANTITY.Width = 70;
            // 
            // UNIT_NAME
            // 
            this.UNIT_NAME.HeaderText = "单位";
            this.UNIT_NAME.Name = "UNIT_NAME";
            this.UNIT_NAME.ReadOnly = true;
            this.UNIT_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UNIT_NAME.Width = 42;
            // 
            // SERIAL_NUMBER
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info;
            this.SERIAL_NUMBER.DefaultCellStyle = dataGridViewCellStyle7;
            this.SERIAL_NUMBER.HeaderText = "机械番号";
            this.SERIAL_NUMBER.MaxInputLength = 50;
            this.SERIAL_NUMBER.Name = "SERIAL_NUMBER";
            this.SERIAL_NUMBER.ReadOnly = true;
            this.SERIAL_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SERIAL_NUMBER.Visible = false;
            // 
            // CHECK_NUMBER
            // 
            this.CHECK_NUMBER.DataPropertyName = "CHECK_NUMBER";
            this.CHECK_NUMBER.HeaderText = "审查编号";
            this.CHECK_NUMBER.Name = "CHECK_NUMBER";
            this.CHECK_NUMBER.ReadOnly = true;
            this.CHECK_NUMBER.Visible = false;
            // 
            // ALLOATION_QUANTITY
            // 
            this.ALLOATION_QUANTITY.HeaderText = "引当数量";
            this.ALLOATION_QUANTITY.Name = "ALLOATION_QUANTITY";
            this.ALLOATION_QUANTITY.ReadOnly = true;
            this.ALLOATION_QUANTITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ALLOATION_QUANTITY.Visible = false;
            this.ALLOATION_QUANTITY.Width = 70;
            // 
            // TRUE_SLIP_NUMBER
            // 
            this.TRUE_SLIP_NUMBER.HeaderText = "TRUE_SLIP_NUMBER";
            this.TRUE_SLIP_NUMBER.Name = "TRUE_SLIP_NUMBER";
            this.TRUE_SLIP_NUMBER.ReadOnly = true;
            this.TRUE_SLIP_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TRUE_SLIP_NUMBER.Visible = false;
            // 
            // LINE_NUMBER
            // 
            this.LINE_NUMBER.HeaderText = "LINE_NUMBER";
            this.LINE_NUMBER.Name = "LINE_NUMBER";
            this.LINE_NUMBER.ReadOnly = true;
            this.LINE_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LINE_NUMBER.Visible = false;
            // 
            // LINE_MEMO
            // 
            this.LINE_MEMO.HeaderText = "LINE_MEMO";
            this.LINE_MEMO.Name = "LINE_MEMO";
            this.LINE_MEMO.ReadOnly = true;
            this.LINE_MEMO.Visible = false;
            // 
            // UNIT_CODE
            // 
            this.UNIT_CODE.HeaderText = "UNIT_CODE";
            this.UNIT_CODE.Name = "UNIT_CODE";
            this.UNIT_CODE.ReadOnly = true;
            this.UNIT_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UNIT_CODE.Visible = false;
            this.UNIT_CODE.Width = 111;
            // 
            // WAREHOUSE_CODE
            // 
            this.WAREHOUSE_CODE.HeaderText = "WAREHOUSE_CODE";
            this.WAREHOUSE_CODE.Name = "WAREHOUSE_CODE";
            this.WAREHOUSE_CODE.ReadOnly = true;
            this.WAREHOUSE_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.WAREHOUSE_CODE.Visible = false;
            this.WAREHOUSE_CODE.Width = 167;
            // 
            // CURRENCY_CODE
            // 
            this.CURRENCY_CODE.HeaderText = "CURRENCY_CODE";
            this.CURRENCY_CODE.Name = "CURRENCY_CODE";
            this.CURRENCY_CODE.ReadOnly = true;
            this.CURRENCY_CODE.Visible = false;
            // 
            // PRICE
            // 
            this.PRICE.HeaderText = "PRICE";
            this.PRICE.Name = "PRICE";
            this.PRICE.Visible = false;
            // 
            // TAX_RATE
            // 
            this.TAX_RATE.HeaderText = "TAX_RATE";
            this.TAX_RATE.Name = "TAX_RATE";
            this.TAX_RATE.ReadOnly = true;
            this.TAX_RATE.Visible = false;
            // 
            // SHIPMENT_DEPOSIT
            // 
            this.SHIPMENT_DEPOSIT.DataPropertyName = "SHIPMENT_DEPOSIT";
            this.SHIPMENT_DEPOSIT.HeaderText = "SHIPMENT_DEPOSIT";
            this.SHIPMENT_DEPOSIT.Name = "SHIPMENT_DEPOSIT";
            this.SHIPMENT_DEPOSIT.Visible = false;
            // 
            // AMOUNT_INCLUDED_TAX
            // 
            this.AMOUNT_INCLUDED_TAX.HeaderText = "AMOUNT_INCLUDED_TAX";
            this.AMOUNT_INCLUDED_TAX.Name = "AMOUNT_INCLUDED_TAX";
            this.AMOUNT_INCLUDED_TAX.Visible = false;
            // 
            // SHIPMENT_FLAG
            // 
            this.SHIPMENT_FLAG.DataPropertyName = "SHIPMENT_FLAG";
            this.SHIPMENT_FLAG.HeaderText = "SHIPMENT_FLAG";
            this.SHIPMENT_FLAG.Name = "SHIPMENT_FLAG";
            this.SHIPMENT_FLAG.ReadOnly = true;
            this.SHIPMENT_FLAG.Visible = false;
            // 
            // FrmShipment
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1027, 658);
            this.Controls.Add(this.pBody);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmShipment";
            this.Text = "出库输入";
            this.Load += new System.EventHandler(this.FrmShipment_Load);
            this.pBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.pHeader.ResumeLayout(false);
            this.pRight.ResumeLayout(false);
            this.pRight_2.ResumeLayout(false);
            this.pLeft.ResumeLayout(false);
            this.pleft_2.ResumeLayout(false);
            this.pleft_2.PerformLayout();
            this.pLeft_1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pBody;
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.Panel pRight_2;
        private System.Windows.Forms.DateTimePicker txtSlipDateTo;
        private System.Windows.Forms.DateTimePicker txtSlipDateFrom;
        private System.Windows.Forms.Panel pRight_1;
        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.Panel pleft_2;
        private System.Windows.Forms.Button btnEndCustomer;
        private System.Windows.Forms.TextBox txtEndCustomerName;
        private System.Windows.Forms.TextBox txtEndCustomerCode;
        private System.Windows.Forms.Panel pLeft_1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtCustomerPoNumber;
        private System.Windows.Forms.DateTimePicker txtDepartualDateFrom;
        private System.Windows.Forms.DateTimePicker txtDepartualDateTo;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSlipNumber;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn NO;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SHIPMENT_CHK;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLIP_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn END_CUSTOMER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn WAREHOUSE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPARTUAL_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ARRIVAL_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_PO_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDER_QUANTITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn SHIPMENT_QUANTITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUANTITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNIT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn SERIAL_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHECK_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn ALLOATION_QUANTITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn TRUE_SLIP_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn LINE_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn LINE_MEMO;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNIT_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn WAREHOUSE_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CURRENCY_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TAX_RATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SHIPMENT_DEPOSIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn AMOUNT_INCLUDED_TAX;
        private System.Windows.Forms.DataGridViewTextBoxColumn SHIPMENT_FLAG;
    }
}