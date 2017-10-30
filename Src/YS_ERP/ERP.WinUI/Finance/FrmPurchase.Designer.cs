namespace CZZD.ERP.WinUI
{
    partial class FrmPurchase
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPurchase));
            this.pLeft = new System.Windows.Forms.Panel();
            this.pleft_2 = new System.Windows.Forms.Panel();
            this.txtInvoiceNoLocal = new System.Windows.Forms.TextBox();
            this.txtInvoiceAmountLocal = new System.Windows.Forms.TextBox();
            this.txtInvoiceAmount = new System.Windows.Forms.TextBox();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.txtSupplierCode = new System.Windows.Forms.TextBox();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.pLeft_1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.pRight = new System.Windows.Forms.Panel();
            this.pRight_2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtReceiptDateTo = new System.Windows.Forms.DateTimePicker();
            this.txtReceiptDateFrom = new System.Windows.Forms.DateTimePicker();
            this.txtPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.txtPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.pRight_1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUPPLIER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PO_SLIP_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLIP_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AMOUNT_INCLUDED_TAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CURRENCY_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UN_INVOICE_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TAX_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PACKAGE_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ALL = new System.Windows.Forms.DataGridViewLinkColumn();
            this.RECEIPT_LINE_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CURRENCY_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUPPLIER_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pBody = new System.Windows.Forms.Panel();
            this.pHeader = new System.Windows.Forms.Panel();
            this.pLeft.SuspendLayout();
            this.pleft_2.SuspendLayout();
            this.pLeft_1.SuspendLayout();
            this.pRight.SuspendLayout();
            this.pRight_2.SuspendLayout();
            this.pRight_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.pBody.SuspendLayout();
            this.pHeader.SuspendLayout();
            this.SuspendLayout();
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
            this.pleft_2.Controls.Add(this.txtInvoiceNoLocal);
            this.pleft_2.Controls.Add(this.txtInvoiceAmountLocal);
            this.pleft_2.Controls.Add(this.txtInvoiceAmount);
            this.pleft_2.Controls.Add(this.btnSupplier);
            this.pleft_2.Controls.Add(this.txtSupplierName);
            this.pleft_2.Controls.Add(this.txtSupplierCode);
            this.pleft_2.Controls.Add(this.txtInvoiceNo);
            this.pleft_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pleft_2.Location = new System.Drawing.Point(120, 0);
            this.pleft_2.Name = "pleft_2";
            this.pleft_2.Size = new System.Drawing.Size(388, 190);
            this.pleft_2.TabIndex = 0;
            // 
            // txtInvoiceNoLocal
            // 
            this.txtInvoiceNoLocal.BackColor = System.Drawing.SystemColors.Info;
            this.txtInvoiceNoLocal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvoiceNoLocal.Enabled = false;
            this.txtInvoiceNoLocal.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtInvoiceNoLocal.Location = new System.Drawing.Point(5, 125);
            this.txtInvoiceNoLocal.MaxLength = 20;
            this.txtInvoiceNoLocal.Name = "txtInvoiceNoLocal";
            this.txtInvoiceNoLocal.Size = new System.Drawing.Size(250, 25);
            this.txtInvoiceNoLocal.TabIndex = 5;
            this.txtInvoiceNoLocal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtInvoiceAmountLocal
            // 
            this.txtInvoiceAmountLocal.BackColor = System.Drawing.SystemColors.Info;
            this.txtInvoiceAmountLocal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvoiceAmountLocal.Enabled = false;
            this.txtInvoiceAmountLocal.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtInvoiceAmountLocal.Location = new System.Drawing.Point(5, 155);
            this.txtInvoiceAmountLocal.MaxLength = 20;
            this.txtInvoiceAmountLocal.Name = "txtInvoiceAmountLocal";
            this.txtInvoiceAmountLocal.Size = new System.Drawing.Size(250, 25);
            this.txtInvoiceAmountLocal.TabIndex = 6;
            this.txtInvoiceAmountLocal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtInvoiceAmount
            // 
            this.txtInvoiceAmount.BackColor = System.Drawing.SystemColors.Info;
            this.txtInvoiceAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvoiceAmount.Enabled = false;
            this.txtInvoiceAmount.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtInvoiceAmount.Location = new System.Drawing.Point(5, 95);
            this.txtInvoiceAmount.MaxLength = 20;
            this.txtInvoiceAmount.Name = "txtInvoiceAmount";
            this.txtInvoiceAmount.Size = new System.Drawing.Size(250, 25);
            this.txtInvoiceAmount.TabIndex = 4;
            this.txtInvoiceAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
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
            this.btnSupplier.Location = new System.Drawing.Point(261, 5);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(25, 25);
            this.btnSupplier.TabIndex = 1;
            this.btnSupplier.UseVisualStyleBackColor = true;
            this.btnSupplier.MouseLeave += new System.EventHandler(this.btnSearch_MouseLeave);
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            this.btnSupplier.MouseEnter += new System.EventHandler(this.btnSearch_MouseEnter);
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
            this.txtSupplierName.TabIndex = 2;
            // 
            // txtSupplierCode
            // 
            this.txtSupplierCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtSupplierCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupplierCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSupplierCode.Location = new System.Drawing.Point(5, 5);
            this.txtSupplierCode.MaxLength = 20;
            this.txtSupplierCode.Name = "txtSupplierCode";
            this.txtSupplierCode.Size = new System.Drawing.Size(250, 25);
            this.txtSupplierCode.TabIndex = 0;
            this.txtSupplierCode.Leave += new System.EventHandler(this.txtSupplierCode_Leave);
            this.txtSupplierCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.BackColor = System.Drawing.SystemColors.Info;
            this.txtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvoiceNo.Enabled = false;
            this.txtInvoiceNo.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtInvoiceNo.Location = new System.Drawing.Point(5, 65);
            this.txtInvoiceNo.MaxLength = 20;
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(250, 25);
            this.txtInvoiceNo.TabIndex = 3;
            this.txtInvoiceNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // pLeft_1
            // 
            this.pLeft_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pLeft_1.Controls.Add(this.label2);
            this.pLeft_1.Controls.Add(this.label1);
            this.pLeft_1.Controls.Add(this.label4);
            this.pLeft_1.Controls.Add(this.label5);
            this.pLeft_1.Controls.Add(this.label13);
            this.pLeft_1.Controls.Add(this.label14);
            this.pLeft_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeft_1.Location = new System.Drawing.Point(0, 0);
            this.pLeft_1.Name = "pLeft_1";
            this.pLeft_1.Size = new System.Drawing.Size(120, 190);
            this.pLeft_1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "  发票金额";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 125);
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
            this.label4.Text = "  供应商";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label5.Text = "  INVOICE No.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label14.Text = "  INV.合计金额";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pRight
            // 
            this.pRight.BackColor = System.Drawing.Color.Transparent;
            this.pRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pRight.Controls.Add(this.pRight_2);
            this.pRight.Controls.Add(this.pRight_1);
            this.pRight.Location = new System.Drawing.Point(512, 0);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(500, 191);
            this.pRight.TabIndex = 0;
            // 
            // pRight_2
            // 
            this.pRight_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pRight_2.Controls.Add(this.label3);
            this.pRight_2.Controls.Add(this.btnSearch);
            this.pRight_2.Controls.Add(this.txtReceiptDateTo);
            this.pRight_2.Controls.Add(this.txtReceiptDateFrom);
            this.pRight_2.Controls.Add(this.txtPaymentDate);
            this.pRight_2.Controls.Add(this.txtPurchaseDate);
            this.pRight_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRight_2.Location = new System.Drawing.Point(120, 0);
            this.pRight_2.Name = "pRight_2";
            this.pRight_2.Size = new System.Drawing.Size(378, 189);
            this.pRight_2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(118, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 19);
            this.label3.TabIndex = 13;
            this.label3.Text = "~";
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnSearch.Location = new System.Drawing.Point(285, 155);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 30);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "查　询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtReceiptDateTo
            // 
            this.txtReceiptDateTo.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.txtReceiptDateTo.Checked = false;
            this.txtReceiptDateTo.CustomFormat = "yyyy-MM-dd";
            this.txtReceiptDateTo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtReceiptDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtReceiptDateTo.Location = new System.Drawing.Point(141, 65);
            this.txtReceiptDateTo.Name = "txtReceiptDateTo";
            this.txtReceiptDateTo.ShowCheckBox = true;
            this.txtReceiptDateTo.Size = new System.Drawing.Size(113, 23);
            this.txtReceiptDateTo.TabIndex = 3;
            this.txtReceiptDateTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtReceiptDateFrom
            // 
            this.txtReceiptDateFrom.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.txtReceiptDateFrom.Checked = false;
            this.txtReceiptDateFrom.CustomFormat = "yyyy-MM-dd";
            this.txtReceiptDateFrom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtReceiptDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtReceiptDateFrom.Location = new System.Drawing.Point(5, 65);
            this.txtReceiptDateFrom.Name = "txtReceiptDateFrom";
            this.txtReceiptDateFrom.ShowCheckBox = true;
            this.txtReceiptDateFrom.Size = new System.Drawing.Size(113, 23);
            this.txtReceiptDateFrom.TabIndex = 2;
            this.txtReceiptDateFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtPaymentDate
            // 
            this.txtPaymentDate.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.txtPaymentDate.CustomFormat = "yyyy-MM-dd";
            this.txtPaymentDate.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtPaymentDate.Location = new System.Drawing.Point(5, 35);
            this.txtPaymentDate.Name = "txtPaymentDate";
            this.txtPaymentDate.Size = new System.Drawing.Size(250, 23);
            this.txtPaymentDate.TabIndex = 1;
            this.txtPaymentDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtPurchaseDate
            // 
            this.txtPurchaseDate.CalendarFont = new System.Drawing.Font("微软雅黑", 10F);
            this.txtPurchaseDate.CustomFormat = "yyyy-MM-dd";
            this.txtPurchaseDate.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtPurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtPurchaseDate.Location = new System.Drawing.Point(5, 5);
            this.txtPurchaseDate.Name = "txtPurchaseDate";
            this.txtPurchaseDate.Size = new System.Drawing.Size(250, 23);
            this.txtPurchaseDate.TabIndex = 0;
            this.txtPurchaseDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // pRight_1
            // 
            this.pRight_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pRight_1.Controls.Add(this.label6);
            this.pRight_1.Controls.Add(this.label17);
            this.pRight_1.Controls.Add(this.label8);
            this.pRight_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pRight_1.Location = new System.Drawing.Point(0, 0);
            this.pRight_1.Name = "pRight_1";
            this.pRight_1.Size = new System.Drawing.Size(120, 189);
            this.pRight_1.TabIndex = 1;
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
            this.label6.Text = "  入库日";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label17.TabIndex = 0;
            this.label17.Text = "  付款预定日";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label8.TabIndex = 0;
            this.label8.Text = "  开票/INV.日";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.No,
            this.SUPPLIER_NAME,
            this.PO_SLIP_NUMBER,
            this.PRODUCT_NAME,
            this.SLIP_NUMBER,
            this.AMOUNT_INCLUDED_TAX,
            this.CURRENCY_NAME,
            this.UN_INVOICE_AMOUNT,
            this.AMOUNT,
            this.TAX_AMOUNT,
            this.PACKAGE_AMOUNT,
            this.ALL,
            this.RECEIPT_LINE_NUMBER,
            this.CURRENCY_CODE,
            this.SUPPLIER_CODE,
            this.PRODUCT_CODE});
            this.dgvData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(3, 198);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 10F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 25;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1013, 411);
            this.dgvData.TabIndex = 1;
            this.dgvData.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellValidated);
            this.dgvData.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvData_CellPainting);
            this.dgvData.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvData_EditingControlShowing);
            this.dgvData.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvData_RowStateChanged);
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentClick);
            // 
            // No
            // 
            this.No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
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
            this.SUPPLIER_NAME.Width = 120;
            // 
            // PO_SLIP_NUMBER
            // 
            this.PO_SLIP_NUMBER.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PO_SLIP_NUMBER.DataPropertyName = "PO_SLIP_NUMBER";
            this.PO_SLIP_NUMBER.Frozen = true;
            this.PO_SLIP_NUMBER.HeaderText = "采购订单";
            this.PO_SLIP_NUMBER.MaxInputLength = 12;
            this.PO_SLIP_NUMBER.Name = "PO_SLIP_NUMBER";
            this.PO_SLIP_NUMBER.ReadOnly = true;
            this.PO_SLIP_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PO_SLIP_NUMBER.Width = 95;
            // 
            // PRODUCT_NAME
            // 
            this.PRODUCT_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PRODUCT_NAME.DataPropertyName = "PRODUCT_NAME";
            this.PRODUCT_NAME.Frozen = true;
            this.PRODUCT_NAME.HeaderText = "商品名称";
            this.PRODUCT_NAME.Name = "PRODUCT_NAME";
            this.PRODUCT_NAME.ReadOnly = true;
            this.PRODUCT_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PRODUCT_NAME.Width = 95;
            // 
            // SLIP_NUMBER
            // 
            this.SLIP_NUMBER.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SLIP_NUMBER.DataPropertyName = "SLIP_NUMBER";
            this.SLIP_NUMBER.Frozen = true;
            this.SLIP_NUMBER.HeaderText = "入库编号";
            this.SLIP_NUMBER.Name = "SLIP_NUMBER";
            this.SLIP_NUMBER.ReadOnly = true;
            this.SLIP_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SLIP_NUMBER.Width = 95;
            // 
            // AMOUNT_INCLUDED_TAX
            // 
            this.AMOUNT_INCLUDED_TAX.DataPropertyName = "AMOUNT_INCLUDED_TAX";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.AMOUNT_INCLUDED_TAX.DefaultCellStyle = dataGridViewCellStyle3;
            this.AMOUNT_INCLUDED_TAX.Frozen = true;
            this.AMOUNT_INCLUDED_TAX.HeaderText = "金额";
            this.AMOUNT_INCLUDED_TAX.Name = "AMOUNT_INCLUDED_TAX";
            this.AMOUNT_INCLUDED_TAX.ReadOnly = true;
            this.AMOUNT_INCLUDED_TAX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AMOUNT_INCLUDED_TAX.Width = 105;
            // 
            // CURRENCY_NAME
            // 
            this.CURRENCY_NAME.DataPropertyName = "CURRENCY_NAME";
            this.CURRENCY_NAME.Frozen = true;
            this.CURRENCY_NAME.HeaderText = "通货";
            this.CURRENCY_NAME.Name = "CURRENCY_NAME";
            this.CURRENCY_NAME.ReadOnly = true;
            this.CURRENCY_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CURRENCY_NAME.Width = 50;
            // 
            // UN_INVOICE_AMOUNT
            // 
            this.UN_INVOICE_AMOUNT.DataPropertyName = "UN_INVOICE_AMOUNT";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.UN_INVOICE_AMOUNT.DefaultCellStyle = dataGridViewCellStyle4;
            this.UN_INVOICE_AMOUNT.Frozen = true;
            this.UN_INVOICE_AMOUNT.HeaderText = "未开票余额";
            this.UN_INVOICE_AMOUNT.Name = "UN_INVOICE_AMOUNT";
            this.UN_INVOICE_AMOUNT.ReadOnly = true;
            this.UN_INVOICE_AMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UN_INVOICE_AMOUNT.Width = 104;
            // 
            // AMOUNT
            // 
            this.AMOUNT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AMOUNT.DataPropertyName = "AMOUNT";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.AMOUNT.DefaultCellStyle = dataGridViewCellStyle5;
            this.AMOUNT.FillWeight = 5F;
            this.AMOUNT.Frozen = true;
            this.AMOUNT.HeaderText = "开票金额";
            this.AMOUNT.MaxInputLength = 15;
            this.AMOUNT.Name = "AMOUNT";
            this.AMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TAX_AMOUNT
            // 
            this.TAX_AMOUNT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TAX_AMOUNT.DataPropertyName = "TAX_AMOUNT";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.TAX_AMOUNT.DefaultCellStyle = dataGridViewCellStyle6;
            this.TAX_AMOUNT.Frozen = true;
            this.TAX_AMOUNT.HeaderText = "关税(RMB)";
            this.TAX_AMOUNT.MaxInputLength = 15;
            this.TAX_AMOUNT.Name = "TAX_AMOUNT";
            this.TAX_AMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TAX_AMOUNT.Width = 90;
            // 
            // PACKAGE_AMOUNT
            // 
            this.PACKAGE_AMOUNT.DataPropertyName = "PACKAGE_AMOUNT";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.PACKAGE_AMOUNT.DefaultCellStyle = dataGridViewCellStyle7;
            this.PACKAGE_AMOUNT.Frozen = true;
            this.PACKAGE_AMOUNT.HeaderText = "包装费";
            this.PACKAGE_AMOUNT.MaxInputLength = 15;
            this.PACKAGE_AMOUNT.Name = "PACKAGE_AMOUNT";
            this.PACKAGE_AMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PACKAGE_AMOUNT.Width = 80;
            // 
            // ALL
            // 
            this.ALL.DataPropertyName = "ALL";
            this.ALL.Frozen = true;
            this.ALL.HeaderText = "";
            this.ALL.LinkColor = System.Drawing.Color.Blue;
            this.ALL.Name = "ALL";
            this.ALL.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ALL.VisitedLinkColor = System.Drawing.Color.Blue;
            this.ALL.Width = 40;
            // 
            // RECEIPT_LINE_NUMBER
            // 
            this.RECEIPT_LINE_NUMBER.HeaderText = "入库明细编号";
            this.RECEIPT_LINE_NUMBER.Name = "RECEIPT_LINE_NUMBER";
            this.RECEIPT_LINE_NUMBER.Visible = false;
            // 
            // CURRENCY_CODE
            // 
            this.CURRENCY_CODE.HeaderText = "货币编号";
            this.CURRENCY_CODE.Name = "CURRENCY_CODE";
            this.CURRENCY_CODE.Visible = false;
            // 
            // SUPPLIER_CODE
            // 
            this.SUPPLIER_CODE.DataPropertyName = "SUPPLIER_CODE";
            this.SUPPLIER_CODE.HeaderText = "SUPPLIER_CODE";
            this.SUPPLIER_CODE.Name = "SUPPLIER_CODE";
            this.SUPPLIER_CODE.ReadOnly = true;
            this.SUPPLIER_CODE.Visible = false;
            // 
            // PRODUCT_CODE
            // 
            this.PRODUCT_CODE.DataPropertyName = "PRODUCT_CODE";
            this.PRODUCT_CODE.HeaderText = "PRODUCT_CODE";
            this.PRODUCT_CODE.Name = "PRODUCT_CODE";
            this.PRODUCT_CODE.ReadOnly = true;
            this.PRODUCT_CODE.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(926, 615);
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
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(832, 615);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保　存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pBody
            // 
            this.pBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBody.Controls.Add(this.pHeader);
            this.pBody.Controls.Add(this.dgvData);
            this.pBody.Controls.Add(this.btnClose);
            this.pBody.Controls.Add(this.btnSave);
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
            // FrmPurchase
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1026, 658);
            this.Controls.Add(this.pBody);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPurchase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "采购发票输入";
            this.Load += new System.EventHandler(this.FrmPurchase_Load);
            this.pLeft.ResumeLayout(false);
            this.pleft_2.ResumeLayout(false);
            this.pleft_2.PerformLayout();
            this.pLeft_1.ResumeLayout(false);
            this.pRight.ResumeLayout(false);
            this.pRight_2.ResumeLayout(false);
            this.pRight_2.PerformLayout();
            this.pRight_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.pBody.ResumeLayout(false);
            this.pHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.Panel pleft_2;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.TextBox txtSupplierCode;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Panel pLeft_1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtInvoiceAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInvoiceNoLocal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.Panel pRight_2;
        private System.Windows.Forms.DateTimePicker txtPaymentDate;
        private System.Windows.Forms.Panel pRight_1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker txtReceiptDateTo;
        private System.Windows.Forms.DateTimePicker txtReceiptDateFrom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtInvoiceAmountLocal;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pBody;
        private System.Windows.Forms.DateTimePicker txtPurchaseDate;
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUPPLIER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PO_SLIP_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLIP_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn AMOUNT_INCLUDED_TAX;
        private System.Windows.Forms.DataGridViewTextBoxColumn CURRENCY_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn UN_INVOICE_AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TAX_AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PACKAGE_AMOUNT;
        private System.Windows.Forms.DataGridViewLinkColumn ALL;
        private System.Windows.Forms.DataGridViewTextBoxColumn RECEIPT_LINE_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn CURRENCY_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUPPLIER_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_CODE;
    }
}