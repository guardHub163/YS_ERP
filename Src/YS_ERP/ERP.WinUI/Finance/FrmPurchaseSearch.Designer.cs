namespace CZZD.ERP.WinUI
{
    partial class FrmPurchaseSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPurchaseSearch));
            this.pBody = new System.Windows.Forms.Panel();
            this.pHeader = new System.Windows.Forms.Panel();
            this.pLeft = new System.Windows.Forms.Panel();
            this.pleft_2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPaymentDateTo = new System.Windows.Forms.DateTimePicker();
            this.SlipDateTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.SlipDateFrom = new System.Windows.Forms.DateTimePicker();
            this.txtSupplierCode = new System.Windows.Forms.TextBox();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.txtPurchaseNo = new System.Windows.Forms.TextBox();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.txtPaymentDateFrom = new System.Windows.Forms.DateTimePicker();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.pLeft_1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pRight = new System.Windows.Forms.Panel();
            this.pRight_2 = new System.Windows.Forms.Panel();
            this.PayStates = new System.Windows.Forms.GroupBox();
            this.rbSomePaid = new System.Windows.Forms.RadioButton();
            this.rbNoPaid = new System.Windows.Forms.RadioButton();
            this.rbPaid = new System.Windows.Forms.RadioButton();
            this.rbAllInvoice = new System.Windows.Forms.RadioButton();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pRight_1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.pgControl = new CZZD.ERP.ComControls.PageControl();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOperate = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.Row = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUPPLIER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLIP_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICE_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICE_NO_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CURRENCY_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UN_PAYMENT_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAYMENT_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payment_status_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLIP_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payment_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pBody.SuspendLayout();
            this.pHeader.SuspendLayout();
            this.pLeft.SuspendLayout();
            this.pleft_2.SuspendLayout();
            this.pLeft_1.SuspendLayout();
            this.pRight.SuspendLayout();
            this.pRight_2.SuspendLayout();
            this.PayStates.SuspendLayout();
            this.pRight_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // pBody
            // 
            this.pBody.BackColor = System.Drawing.Color.White;
            this.pBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBody.Controls.Add(this.pHeader);
            this.pBody.Controls.Add(this.pgControl);
            this.pBody.Controls.Add(this.btnCancel);
            this.pBody.Controls.Add(this.btnClose);
            this.pBody.Controls.Add(this.btnOperate);
            this.pBody.Controls.Add(this.btnPrint);
            this.pBody.Controls.Add(this.dgvData);
            this.pBody.Location = new System.Drawing.Point(0, 0);
            this.pBody.Name = "pBody";
            this.pBody.Size = new System.Drawing.Size(1020, 650);
            this.pBody.TabIndex = 0;
            // 
            // pHeader
            // 
            this.pHeader.Controls.Add(this.pLeft);
            this.pHeader.Controls.Add(this.pRight);
            this.pHeader.Location = new System.Drawing.Point(3, 3);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(1012, 195);
            this.pHeader.TabIndex = 0;
            // 
            // pLeft
            // 
            this.pLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLeft.Controls.Add(this.pleft_2);
            this.pLeft.Controls.Add(this.pLeft_1);
            this.pLeft.Location = new System.Drawing.Point(0, 0);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(510, 192);
            this.pLeft.TabIndex = 0;
            // 
            // pleft_2
            // 
            this.pleft_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pleft_2.Controls.Add(this.label10);
            this.pleft_2.Controls.Add(this.txtPaymentDateTo);
            this.pleft_2.Controls.Add(this.SlipDateTo);
            this.pleft_2.Controls.Add(this.label2);
            this.pleft_2.Controls.Add(this.SlipDateFrom);
            this.pleft_2.Controls.Add(this.txtSupplierCode);
            this.pleft_2.Controls.Add(this.txtSupplierName);
            this.pleft_2.Controls.Add(this.txtPurchaseNo);
            this.pleft_2.Controls.Add(this.btnSupplier);
            this.pleft_2.Controls.Add(this.txtPaymentDateFrom);
            this.pleft_2.Controls.Add(this.txtInvoiceNo);
            this.pleft_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pleft_2.Location = new System.Drawing.Point(120, 0);
            this.pleft_2.Name = "pleft_2";
            this.pleft_2.Size = new System.Drawing.Size(388, 190);
            this.pleft_2.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(118, 127);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 19);
            this.label10.TabIndex = 22;
            this.label10.Text = "~";
            // 
            // txtPaymentDateTo
            // 
            this.txtPaymentDateTo.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.txtPaymentDateTo.Checked = false;
            this.txtPaymentDateTo.CustomFormat = "yyyy-MM-dd";
            this.txtPaymentDateTo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtPaymentDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtPaymentDateTo.Location = new System.Drawing.Point(142, 155);
            this.txtPaymentDateTo.Name = "txtPaymentDateTo";
            this.txtPaymentDateTo.ShowCheckBox = true;
            this.txtPaymentDateTo.Size = new System.Drawing.Size(113, 23);
            this.txtPaymentDateTo.TabIndex = 8;
            // 
            // SlipDateTo
            // 
            this.SlipDateTo.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.SlipDateTo.Checked = false;
            this.SlipDateTo.CustomFormat = "yyyy-MM-dd";
            this.SlipDateTo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.SlipDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.SlipDateTo.Location = new System.Drawing.Point(141, 125);
            this.SlipDateTo.Name = "SlipDateTo";
            this.SlipDateTo.ShowCheckBox = true;
            this.SlipDateTo.Size = new System.Drawing.Size(114, 23);
            this.SlipDateTo.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(119, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 19);
            this.label2.TabIndex = 15;
            this.label2.Text = "~";
            // 
            // SlipDateFrom
            // 
            this.SlipDateFrom.CalendarFont = new System.Drawing.Font("微软雅黑", 10F);
            this.SlipDateFrom.Checked = false;
            this.SlipDateFrom.CustomFormat = "yyyy-MM-dd";
            this.SlipDateFrom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.SlipDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.SlipDateFrom.Location = new System.Drawing.Point(5, 125);
            this.SlipDateFrom.Name = "SlipDateFrom";
            this.SlipDateFrom.ShowCheckBox = true;
            this.SlipDateFrom.Size = new System.Drawing.Size(112, 23);
            this.SlipDateFrom.TabIndex = 5;
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
            this.txtSupplierCode.Leave += new System.EventHandler(this.txtSupplierCode_Leave);
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
            // txtPurchaseNo
            // 
            this.txtPurchaseNo.BackColor = System.Drawing.SystemColors.Info;
            this.txtPurchaseNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPurchaseNo.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtPurchaseNo.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtPurchaseNo.Location = new System.Drawing.Point(5, 5);
            this.txtPurchaseNo.MaxLength = 20;
            this.txtPurchaseNo.Name = "txtPurchaseNo";
            this.txtPurchaseNo.Size = new System.Drawing.Size(250, 25);
            this.txtPurchaseNo.TabIndex = 0;
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
            this.btnSupplier.MouseLeave += new System.EventHandler(this.btnCustomer_MouseLeave);
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            this.btnSupplier.MouseEnter += new System.EventHandler(this.btnCustomer_MouseEnter);
            // 
            // txtPaymentDateFrom
            // 
            this.txtPaymentDateFrom.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.txtPaymentDateFrom.Checked = false;
            this.txtPaymentDateFrom.CustomFormat = "yyyy-MM-dd";
            this.txtPaymentDateFrom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtPaymentDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtPaymentDateFrom.Location = new System.Drawing.Point(5, 155);
            this.txtPaymentDateFrom.Name = "txtPaymentDateFrom";
            this.txtPaymentDateFrom.ShowCheckBox = true;
            this.txtPaymentDateFrom.Size = new System.Drawing.Size(113, 23);
            this.txtPaymentDateFrom.TabIndex = 7;
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.BackColor = System.Drawing.SystemColors.Info;
            this.txtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvoiceNo.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtInvoiceNo.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtInvoiceNo.Location = new System.Drawing.Point(5, 35);
            this.txtInvoiceNo.MaxLength = 20;
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(250, 25);
            this.txtInvoiceNo.TabIndex = 1;
            // 
            // pLeft_1
            // 
            this.pLeft_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pLeft_1.Controls.Add(this.label9);
            this.pLeft_1.Controls.Add(this.label1);
            this.pLeft_1.Controls.Add(this.label17);
            this.pLeft_1.Controls.Add(this.label4);
            this.pLeft_1.Controls.Add(this.label5);
            this.pLeft_1.Controls.Add(this.label13);
            this.pLeft_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeft_1.Location = new System.Drawing.Point(0, 0);
            this.pLeft_1.Name = "pLeft_1";
            this.pLeft_1.Size = new System.Drawing.Size(120, 190);
            this.pLeft_1.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(5, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 20);
            this.label9.TabIndex = 4;
            this.label9.Text = "  开票日期";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label1.TabIndex = 0;
            this.label1.Text = "  发票No.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label17.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(5, 154);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(110, 20);
            this.label17.TabIndex = 5;
            this.label17.Text = "  付款预定日期";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label4.TabIndex = 2;
            this.label4.Text = "  供应商";
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
            this.label5.TabIndex = 1;
            this.label5.Text = "  INVOICE No.";
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
            this.label13.TabIndex = 3;
            this.label13.Text = "  供应商名称";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pRight
            // 
            this.pRight.BackColor = System.Drawing.Color.Transparent;
            this.pRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pRight.Controls.Add(this.pRight_2);
            this.pRight.Controls.Add(this.pRight_1);
            this.pRight.Location = new System.Drawing.Point(512, 0);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(500, 192);
            this.pRight.TabIndex = 9;
            // 
            // pRight_2
            // 
            this.pRight_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pRight_2.Controls.Add(this.PayStates);
            this.pRight_2.Controls.Add(this.btnSearch);
            this.pRight_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRight_2.Location = new System.Drawing.Point(120, 0);
            this.pRight_2.Name = "pRight_2";
            this.pRight_2.Size = new System.Drawing.Size(378, 190);
            this.pRight_2.TabIndex = 0;
            // 
            // PayStates
            // 
            this.PayStates.Controls.Add(this.rbSomePaid);
            this.PayStates.Controls.Add(this.rbNoPaid);
            this.PayStates.Controls.Add(this.rbPaid);
            this.PayStates.Controls.Add(this.rbAllInvoice);
            this.PayStates.Location = new System.Drawing.Point(5, -3);
            this.PayStates.Name = "PayStates";
            this.PayStates.Size = new System.Drawing.Size(335, 38);
            this.PayStates.TabIndex = 0;
            this.PayStates.TabStop = false;
            // 
            // rbSomePaid
            // 
            this.rbSomePaid.Location = new System.Drawing.Point(243, 11);
            this.rbSomePaid.Name = "rbSomePaid";
            this.rbSomePaid.Size = new System.Drawing.Size(86, 23);
            this.rbSomePaid.TabIndex = 4;
            this.rbSomePaid.Text = "部分付款";
            this.rbSomePaid.UseVisualStyleBackColor = true;
            // 
            // rbNoPaid
            // 
            this.rbNoPaid.Location = new System.Drawing.Point(173, 11);
            this.rbNoPaid.Name = "rbNoPaid";
            this.rbNoPaid.Size = new System.Drawing.Size(73, 23);
            this.rbNoPaid.TabIndex = 3;
            this.rbNoPaid.Text = "未付款";
            this.rbNoPaid.UseVisualStyleBackColor = true;
            // 
            // rbPaid
            // 
            this.rbPaid.Location = new System.Drawing.Point(90, 11);
            this.rbPaid.Name = "rbPaid";
            this.rbPaid.Size = new System.Drawing.Size(84, 23);
            this.rbPaid.TabIndex = 2;
            this.rbPaid.Text = "已付款";
            this.rbPaid.UseVisualStyleBackColor = true;
            // 
            // rbAllInvoice
            // 
            this.rbAllInvoice.Checked = true;
            this.rbAllInvoice.Location = new System.Drawing.Point(3, 11);
            this.rbAllInvoice.Name = "rbAllInvoice";
            this.rbAllInvoice.Size = new System.Drawing.Size(87, 22);
            this.rbAllInvoice.TabIndex = 1;
            this.rbAllInvoice.TabStop = true;
            this.rbAllInvoice.Text = "全部发票";
            this.rbAllInvoice.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnSearch.Location = new System.Drawing.Point(285, 157);
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
            this.pRight_1.Controls.Add(this.label7);
            this.pRight_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pRight_1.Location = new System.Drawing.Point(0, 0);
            this.pRight_1.Name = "pRight_1";
            this.pRight_1.Size = new System.Drawing.Size(120, 190);
            this.pRight_1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(5, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "  付款状态";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pgControl
            // 
            this.pgControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pgControl.Location = new System.Drawing.Point(3, 583);
            this.pgControl.Name = "pgControl";
            this.pgControl.Size = new System.Drawing.Size(1012, 30);
            this.pgControl.TabIndex = 2;
            this.pgControl.TotalPage = 1;
            this.pgControl.PageChanged += new CZZD.ERP.ComControls.PageControl.BtnClickHandle(this.pgControl_PageChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnCancel.Location = new System.Drawing.Point(832, 615);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取　消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnClose.Location = new System.Drawing.Point(925, 615);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 30);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "关　闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOperate
            // 
            this.btnOperate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOperate.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnOperate.Location = new System.Drawing.Point(739, 615);
            this.btnOperate.Name = "btnOperate";
            this.btnOperate.Size = new System.Drawing.Size(90, 30);
            this.btnOperate.TabIndex = 5;
            this.btnOperate.Text = "详细确认";
            this.btnOperate.UseVisualStyleBackColor = true;
            this.btnOperate.Click += new System.EventHandler(this.btnOperate_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnPrint.Location = new System.Drawing.Point(646, 616);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(90, 30);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "导　出";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
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
            this.dgvData.ColumnHeadersHeight = 31;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Row,
            this.SUPPLIER_NAME,
            this.SLIP_DATE,
            this.INVOICE_NO,
            this.INVOICE_NO_AMOUNT,
            this.CURRENCY_NAME,
            this.UN_PAYMENT_AMOUNT,
            this.PAYMENT_DATE,
            this.payment_status_name,
            this.SLIP_NUMBER,
            this.payment_status});
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(3, 198);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 25;
            this.dgvData.RowTemplate.Height = 25;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1012, 384);
            this.dgvData.TabIndex = 1;
            this.dgvData.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvData_RowStateChanged);
            // 
            // Row
            // 
            this.Row.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Row.DataPropertyName = "Row";
            this.Row.Frozen = true;
            this.Row.HeaderText = "No";
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "yyyy-MM-dd";
            this.SLIP_DATE.DefaultCellStyle = dataGridViewCellStyle3;
            this.SLIP_DATE.Frozen = true;
            this.SLIP_DATE.HeaderText = "开票日期";
            this.SLIP_DATE.Name = "SLIP_DATE";
            this.SLIP_DATE.ReadOnly = true;
            this.SLIP_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SLIP_DATE.Width = 103;
            // 
            // INVOICE_NO
            // 
            this.INVOICE_NO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.INVOICE_NO.DataPropertyName = "INVOICE_NO";
            this.INVOICE_NO.Frozen = true;
            this.INVOICE_NO.HeaderText = "发票No";
            this.INVOICE_NO.MaxInputLength = 12;
            this.INVOICE_NO.Name = "INVOICE_NO";
            this.INVOICE_NO.ReadOnly = true;
            this.INVOICE_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.INVOICE_NO.Width = 120;
            // 
            // INVOICE_NO_AMOUNT
            // 
            this.INVOICE_NO_AMOUNT.DataPropertyName = "INVOICE_NO_AMOUNT";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.INVOICE_NO_AMOUNT.DefaultCellStyle = dataGridViewCellStyle4;
            this.INVOICE_NO_AMOUNT.Frozen = true;
            this.INVOICE_NO_AMOUNT.HeaderText = "发票金额";
            this.INVOICE_NO_AMOUNT.Name = "INVOICE_NO_AMOUNT";
            this.INVOICE_NO_AMOUNT.ReadOnly = true;
            this.INVOICE_NO_AMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.INVOICE_NO_AMOUNT.Width = 110;
            // 
            // CURRENCY_NAME
            // 
            this.CURRENCY_NAME.DataPropertyName = "CURRENCY_NAME";
            this.CURRENCY_NAME.Frozen = true;
            this.CURRENCY_NAME.HeaderText = "通货";
            this.CURRENCY_NAME.Name = "CURRENCY_NAME";
            this.CURRENCY_NAME.ReadOnly = true;
            this.CURRENCY_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // UN_PAYMENT_AMOUNT
            // 
            this.UN_PAYMENT_AMOUNT.DataPropertyName = "UN_PAYMENT_AMOUNT";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.UN_PAYMENT_AMOUNT.DefaultCellStyle = dataGridViewCellStyle5;
            this.UN_PAYMENT_AMOUNT.Frozen = true;
            this.UN_PAYMENT_AMOUNT.HeaderText = "未付金额";
            this.UN_PAYMENT_AMOUNT.Name = "UN_PAYMENT_AMOUNT";
            this.UN_PAYMENT_AMOUNT.ReadOnly = true;
            this.UN_PAYMENT_AMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PAYMENT_DATE
            // 
            this.PAYMENT_DATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PAYMENT_DATE.DataPropertyName = "PAYMENT_DATE";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "yyyy-MM-dd";
            this.PAYMENT_DATE.DefaultCellStyle = dataGridViewCellStyle6;
            this.PAYMENT_DATE.FillWeight = 5F;
            this.PAYMENT_DATE.Frozen = true;
            this.PAYMENT_DATE.HeaderText = "付款预定日期";
            this.PAYMENT_DATE.Name = "PAYMENT_DATE";
            this.PAYMENT_DATE.ReadOnly = true;
            this.PAYMENT_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PAYMENT_DATE.Width = 160;
            // 
            // payment_status_name
            // 
            this.payment_status_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.payment_status_name.DataPropertyName = "payment_status_name";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.payment_status_name.DefaultCellStyle = dataGridViewCellStyle7;
            this.payment_status_name.Frozen = true;
            this.payment_status_name.HeaderText = "付款状态";
            this.payment_status_name.Name = "payment_status_name";
            this.payment_status_name.ReadOnly = true;
            this.payment_status_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.payment_status_name.Width = 135;
            // 
            // SLIP_NUMBER
            // 
            this.SLIP_NUMBER.DataPropertyName = "SLIP_NUMBER";
            this.SLIP_NUMBER.HeaderText = "SLIP_NUMBER";
            this.SLIP_NUMBER.Name = "SLIP_NUMBER";
            this.SLIP_NUMBER.ReadOnly = true;
            this.SLIP_NUMBER.Visible = false;
            // 
            // payment_status
            // 
            this.payment_status.DataPropertyName = "payment_status";
            this.payment_status.HeaderText = "payment_status";
            this.payment_status.Name = "payment_status";
            this.payment_status.ReadOnly = true;
            this.payment_status.Visible = false;
            // 
            // FrmPurchaseSearch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1030, 656);
            this.Controls.Add(this.pBody);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPurchaseSearch";
            this.Text = "采购发票查询";
            this.Load += new System.EventHandler(this.FrmPurchaseSearch_Load);
            this.pBody.ResumeLayout(false);
            this.pHeader.ResumeLayout(false);
            this.pLeft.ResumeLayout(false);
            this.pleft_2.ResumeLayout(false);
            this.pleft_2.PerformLayout();
            this.pLeft_1.ResumeLayout(false);
            this.pRight.ResumeLayout(false);
            this.pRight_2.ResumeLayout(false);
            this.PayStates.ResumeLayout(false);
            this.pRight_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pBody;
        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.Panel pleft_2;
        private System.Windows.Forms.TextBox txtPurchaseNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.TextBox txtSupplierCode;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Panel pLeft_1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.Panel pRight_2;
        private System.Windows.Forms.DateTimePicker txtPaymentDateFrom;
        private System.Windows.Forms.Panel pRight_1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker txtPaymentDateTo;
        private System.Windows.Forms.GroupBox PayStates;
        private System.Windows.Forms.RadioButton rbNoPaid;
        private System.Windows.Forms.RadioButton rbPaid;
        private System.Windows.Forms.RadioButton rbAllInvoice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOperate;
        private System.Windows.Forms.Button btnPrint;
        private CZZD.ERP.ComControls.PageControl pgControl;
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker SlipDateTo;
        private System.Windows.Forms.DateTimePicker SlipDateFrom;
        private System.Windows.Forms.RadioButton rbSomePaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Row;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUPPLIER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLIP_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICE_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICE_NO_AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CURRENCY_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn UN_PAYMENT_AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAYMENT_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn payment_status_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLIP_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn payment_status;
    }
}