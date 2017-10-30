namespace CZZD.ERP.WinUI
{
    partial class FrmPurchaseOrderEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPurchaseOrderEntry));
            this.pInfo = new System.Windows.Forms.Panel();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOrderDelete = new System.Windows.Forms.Button();
            this.pAmount = new System.Windows.Forms.Panel();
            this.txtAmountIncludedTax = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnDeleteRow = new System.Windows.Forms.Button();
            this.pHeader = new System.Windows.Forms.Panel();
            this.pRight = new System.Windows.Forms.Panel();
            this.pRight_2 = new System.Windows.Forms.Panel();
            this.btnOrders = new System.Windows.Forms.Button();
            this.cboTax = new System.Windows.Forms.ComboBox();
            this.dueDate = new System.Windows.Forms.DateTimePicker();
            this.txtSupplierOrderCode = new System.Windows.Forms.TextBox();
            this.entryDate = new System.Windows.Forms.DateTimePicker();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.pRight_1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.pLeft = new System.Windows.Forms.Panel();
            this.pLeft_2 = new System.Windows.Forms.Panel();
            this.btnWarehouse = new System.Windows.Forms.Button();
            this.txtPayment = new System.Windows.Forms.TextBox();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.cboPurchaseSlipType = new System.Windows.Forms.ComboBox();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.txtPurchaseSlipNumber = new System.Windows.Forms.TextBox();
            this.txtWarehouseCode = new System.Windows.Forms.TextBox();
            this.txtWarehouseName = new System.Windows.Forms.TextBox();
            this.txtSupplierCode = new System.Windows.Forms.TextBox();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.pLeft_1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnProduct = new System.Windows.Forms.DataGridViewButtonColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNIT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNIT_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AMOUNT_INCLUDED_TAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FROMSET = new System.Windows.Forms.DataGridViewLinkColumn();
            this.FORMSET_FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OLD_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pInfo.SuspendLayout();
            this.pAmount.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.pHeader.SuspendLayout();
            this.pRight.SuspendLayout();
            this.pRight_2.SuspendLayout();
            this.pRight_1.SuspendLayout();
            this.pLeft.SuspendLayout();
            this.pLeft_2.SuspendLayout();
            this.pLeft_1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pInfo
            // 
            this.pInfo.BackColor = System.Drawing.Color.White;
            this.pInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pInfo.Controls.Add(this.btnAddRow);
            this.pInfo.Controls.Add(this.btnSave);
            this.pInfo.Controls.Add(this.btnClose);
            this.pInfo.Controls.Add(this.btnOrderDelete);
            this.pInfo.Controls.Add(this.pAmount);
            this.pInfo.Controls.Add(this.dgvData);
            this.pInfo.Controls.Add(this.btnDeleteRow);
            this.pInfo.Controls.Add(this.pHeader);
            this.pInfo.Location = new System.Drawing.Point(0, 0);
            this.pInfo.Name = "pInfo";
            this.pInfo.Size = new System.Drawing.Size(1020, 641);
            this.pInfo.TabIndex = 0;
            // 
            // btnAddRow
            // 
            this.btnAddRow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddRow.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddRow.Location = new System.Drawing.Point(3, 250);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(90, 30);
            this.btnAddRow.TabIndex = 2;
            this.btnAddRow.Text = "行添加";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSave.Location = new System.Drawing.Point(830, 606);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保　存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnClose.Location = new System.Drawing.Point(925, 606);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 30);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "关　闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // btnOrderDelete
            // 
            this.btnOrderDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrderDelete.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnOrderDelete.Location = new System.Drawing.Point(734, 606);
            this.btnOrderDelete.Name = "btnOrderDelete";
            this.btnOrderDelete.Size = new System.Drawing.Size(90, 30);
            this.btnOrderDelete.TabIndex = 7;
            this.btnOrderDelete.Text = "订单删除";
            this.btnOrderDelete.UseVisualStyleBackColor = true;
            this.btnOrderDelete.Click += new System.EventHandler(this.btnOrderDelete_Click);
            this.btnOrderDelete.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // pAmount
            // 
            this.pAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pAmount.Controls.Add(this.txtAmountIncludedTax);
            this.pAmount.Controls.Add(this.panel1);
            this.pAmount.Location = new System.Drawing.Point(734, 574);
            this.pAmount.Name = "pAmount";
            this.pAmount.Size = new System.Drawing.Size(281, 30);
            this.pAmount.TabIndex = 9;
            // 
            // txtAmountIncludedTax
            // 
            this.txtAmountIncludedTax.BackColor = System.Drawing.Color.Gainsboro;
            this.txtAmountIncludedTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmountIncludedTax.Enabled = false;
            this.txtAmountIncludedTax.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtAmountIncludedTax.Location = new System.Drawing.Point(121, 2);
            this.txtAmountIncludedTax.Name = "txtAmountIncludedTax";
            this.txtAmountIncludedTax.Size = new System.Drawing.Size(157, 25);
            this.txtAmountIncludedTax.TabIndex = 5;
            this.txtAmountIncludedTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.label8.Text = "  含税合计总额";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeColumns = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.PRODUCT_CODE,
            this.btnProduct,
            this.NAME,
            this.SPEC,
            this.QUANTITY,
            this.UNIT_NAME,
            this.UNIT_CODE,
            this.PRICE,
            this.AMOUNT,
            this.AMOUNT_INCLUDED_TAX,
            this.FROMSET,
            this.FORMSET_FLAG,
            this.OLD_CODE});
            this.dgvData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(3, 283);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 25;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.Size = new System.Drawing.Size(1012, 288);
            this.dgvData.TabIndex = 4;
            this.dgvData.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellValidated);
            this.dgvData.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvData_RowsAdded);
            this.dgvData.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvData_CellPainting);
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);
            this.dgvData.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvData_EditingControlShowing);
            this.dgvData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.dgvData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteRow.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnDeleteRow.Location = new System.Drawing.Point(99, 250);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(90, 30);
            this.btnDeleteRow.TabIndex = 3;
            this.btnDeleteRow.Text = "行删除";
            this.btnDeleteRow.UseVisualStyleBackColor = true;
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
            this.btnDeleteRow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.btnDeleteRow.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // pHeader
            // 
            this.pHeader.Controls.Add(this.pRight);
            this.pHeader.Controls.Add(this.pLeft);
            this.pHeader.Location = new System.Drawing.Point(3, 3);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(1010, 245);
            this.pHeader.TabIndex = 1;
            // 
            // pRight
            // 
            this.pRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pRight.Controls.Add(this.pRight_2);
            this.pRight.Controls.Add(this.pRight_1);
            this.pRight.Location = new System.Drawing.Point(512, 1);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(499, 243);
            this.pRight.TabIndex = 2;
            // 
            // pRight_2
            // 
            this.pRight_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pRight_2.Controls.Add(this.btnOrders);
            this.pRight_2.Controls.Add(this.cboTax);
            this.pRight_2.Controls.Add(this.dueDate);
            this.pRight_2.Controls.Add(this.txtSupplierOrderCode);
            this.pRight_2.Controls.Add(this.entryDate);
            this.pRight_2.Controls.Add(this.txtOrderNumber);
            this.pRight_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRight_2.Location = new System.Drawing.Point(120, 0);
            this.pRight_2.Name = "pRight_2";
            this.pRight_2.Size = new System.Drawing.Size(377, 241);
            this.pRight_2.TabIndex = 1;
            // 
            // btnOrders
            // 
            this.btnOrders.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnOrders.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOrders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrders.FlatAppearance.BorderSize = 0;
            this.btnOrders.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnOrders.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrders.Location = new System.Drawing.Point(261, 4);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(25, 25);
            this.btnOrders.TabIndex = 8;
            this.btnOrders.UseVisualStyleBackColor = true;
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // cboTax
            // 
            this.cboTax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTax.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.cboTax.FormattingEnabled = true;
            this.cboTax.Location = new System.Drawing.Point(5, 125);
            this.cboTax.Name = "cboTax";
            this.cboTax.Size = new System.Drawing.Size(250, 27);
            this.cboTax.TabIndex = 5;
            this.cboTax.SelectedIndexChanged += new System.EventHandler(this.cboTax_SelectedIndexChanged);
            this.cboTax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.cboTax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // dueDate
            // 
            this.dueDate.CalendarFont = new System.Drawing.Font("微软雅黑", 10F);
            this.dueDate.CustomFormat = "yyyy-MM-dd";
            this.dueDate.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.dueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dueDate.Location = new System.Drawing.Point(5, 95);
            this.dueDate.Name = "dueDate";
            this.dueDate.Size = new System.Drawing.Size(250, 25);
            this.dueDate.TabIndex = 4;
            this.dueDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.dueDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // txtSupplierOrderCode
            // 
            this.txtSupplierOrderCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtSupplierOrderCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupplierOrderCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSupplierOrderCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtSupplierOrderCode.Location = new System.Drawing.Point(5, 35);
            this.txtSupplierOrderCode.MaxLength = 20;
            this.txtSupplierOrderCode.Name = "txtSupplierOrderCode";
            this.txtSupplierOrderCode.Size = new System.Drawing.Size(250, 25);
            this.txtSupplierOrderCode.TabIndex = 2;
            this.txtSupplierOrderCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtSupplierOrderCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // entryDate
            // 
            this.entryDate.CalendarFont = new System.Drawing.Font("微软雅黑", 10F);
            this.entryDate.CustomFormat = "yyyy-MM-dd";
            this.entryDate.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.entryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.entryDate.Location = new System.Drawing.Point(5, 65);
            this.entryDate.Name = "entryDate";
            this.entryDate.Size = new System.Drawing.Size(250, 25);
            this.entryDate.TabIndex = 3;
            this.entryDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.entryDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.BackColor = System.Drawing.SystemColors.Info;
            this.txtOrderNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderNumber.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtOrderNumber.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtOrderNumber.Location = new System.Drawing.Point(5, 5);
            this.txtOrderNumber.MaxLength = 20;
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(250, 25);
            this.txtOrderNumber.TabIndex = 1;
            this.txtOrderNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtOrderNumber.Leave += new System.EventHandler(this.txtOrderNumber_Leave);
            this.txtOrderNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // pRight_1
            // 
            this.pRight_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pRight_1.Controls.Add(this.label6);
            this.pRight_1.Controls.Add(this.label13);
            this.pRight_1.Controls.Add(this.label2);
            this.pRight_1.Controls.Add(this.label11);
            this.pRight_1.Controls.Add(this.label15);
            this.pRight_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pRight_1.Location = new System.Drawing.Point(0, 0);
            this.pRight_1.Name = "pRight_1";
            this.pRight_1.Size = new System.Drawing.Size(120, 241);
            this.pRight_1.TabIndex = 2;
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
            this.label6.TabIndex = 7;
            this.label6.Text = "  采购日期";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label13.TabIndex = 4;
            this.label13.Text = "  报价单编号";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "  销售订单编号";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(5, 125);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 20);
            this.label11.TabIndex = 6;
            this.label11.Text = "  税       率";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(5, 95);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(110, 20);
            this.label15.TabIndex = 2;
            this.label15.Text = "  预计入库日期";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pLeft
            // 
            this.pLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLeft.Controls.Add(this.pLeft_2);
            this.pLeft.Controls.Add(this.pLeft_1);
            this.pLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeft.Location = new System.Drawing.Point(0, 0);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(510, 245);
            this.pLeft.TabIndex = 0;
            // 
            // pLeft_2
            // 
            this.pLeft_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pLeft_2.Controls.Add(this.btnWarehouse);
            this.pLeft_2.Controls.Add(this.txtPayment);
            this.pLeft_2.Controls.Add(this.btnSupplier);
            this.pLeft_2.Controls.Add(this.cboPurchaseSlipType);
            this.pLeft_2.Controls.Add(this.txtMemo);
            this.pLeft_2.Controls.Add(this.txtPurchaseSlipNumber);
            this.pLeft_2.Controls.Add(this.txtWarehouseCode);
            this.pLeft_2.Controls.Add(this.txtWarehouseName);
            this.pLeft_2.Controls.Add(this.txtSupplierCode);
            this.pLeft_2.Controls.Add(this.txtSupplierName);
            this.pLeft_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pLeft_2.Location = new System.Drawing.Point(120, 0);
            this.pLeft_2.Name = "pLeft_2";
            this.pLeft_2.Size = new System.Drawing.Size(388, 243);
            this.pLeft_2.TabIndex = 1;
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
            this.btnWarehouse.Location = new System.Drawing.Point(261, 125);
            this.btnWarehouse.Name = "btnWarehouse";
            this.btnWarehouse.Size = new System.Drawing.Size(25, 25);
            this.btnWarehouse.TabIndex = 7;
            this.btnWarehouse.UseVisualStyleBackColor = true;
            this.btnWarehouse.Click += new System.EventHandler(this.btnWarehouse_Click);
            // 
            // txtPayment
            // 
            this.txtPayment.BackColor = System.Drawing.SystemColors.Info;
            this.txtPayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPayment.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtPayment.Location = new System.Drawing.Point(5, 185);
            this.txtPayment.MaxLength = 255;
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.Size = new System.Drawing.Size(250, 25);
            this.txtPayment.TabIndex = 9;
            this.txtPayment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtPayment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
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
            this.btnSupplier.TabIndex = 4;
            this.btnSupplier.UseVisualStyleBackColor = true;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            this.btnSupplier.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.btnSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // cboPurchaseSlipType
            // 
            this.cboPurchaseSlipType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPurchaseSlipType.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cboPurchaseSlipType.FormattingEnabled = true;
            this.cboPurchaseSlipType.Location = new System.Drawing.Point(5, 5);
            this.cboPurchaseSlipType.Name = "cboPurchaseSlipType";
            this.cboPurchaseSlipType.Size = new System.Drawing.Size(250, 25);
            this.cboPurchaseSlipType.TabIndex = 1;
            this.cboPurchaseSlipType.SelectedIndexChanged += new System.EventHandler(this.cboPurchaseSlipType_SelectedIndexChanged);
            // 
            // txtMemo
            // 
            this.txtMemo.BackColor = System.Drawing.SystemColors.Info;
            this.txtMemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMemo.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtMemo.Location = new System.Drawing.Point(5, 215);
            this.txtMemo.MaxLength = 255;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(250, 25);
            this.txtMemo.TabIndex = 10;
            this.txtMemo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtMemo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtPurchaseSlipNumber
            // 
            this.txtPurchaseSlipNumber.BackColor = System.Drawing.Color.Gainsboro;
            this.txtPurchaseSlipNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPurchaseSlipNumber.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtPurchaseSlipNumber.Location = new System.Drawing.Point(5, 35);
            this.txtPurchaseSlipNumber.MaxLength = 20;
            this.txtPurchaseSlipNumber.Name = "txtPurchaseSlipNumber";
            this.txtPurchaseSlipNumber.Size = new System.Drawing.Size(250, 25);
            this.txtPurchaseSlipNumber.TabIndex = 2;
            // 
            // txtWarehouseCode
            // 
            this.txtWarehouseCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtWarehouseCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWarehouseCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtWarehouseCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtWarehouseCode.Location = new System.Drawing.Point(5, 125);
            this.txtWarehouseCode.MaxLength = 20;
            this.txtWarehouseCode.Name = "txtWarehouseCode";
            this.txtWarehouseCode.Size = new System.Drawing.Size(250, 25);
            this.txtWarehouseCode.TabIndex = 6;
            this.txtWarehouseCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtWarehouseCode.Leave += new System.EventHandler(this.txtWarehouseCode_Leave);
            this.txtWarehouseCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
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
            this.txtWarehouseName.TabIndex = 8;
            // 
            // txtSupplierCode
            // 
            this.txtSupplierCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtSupplierCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupplierCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSupplierCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtSupplierCode.Location = new System.Drawing.Point(5, 65);
            this.txtSupplierCode.MaxLength = 20;
            this.txtSupplierCode.Name = "txtSupplierCode";
            this.txtSupplierCode.Size = new System.Drawing.Size(250, 25);
            this.txtSupplierCode.TabIndex = 3;
            this.txtSupplierCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtSupplierCode.Leave += new System.EventHandler(this.txtSupplierCode_Leave);
            this.txtSupplierCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
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
            this.txtSupplierName.TabIndex = 5;
            // 
            // pLeft_1
            // 
            this.pLeft_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pLeft_1.Controls.Add(this.label7);
            this.pLeft_1.Controls.Add(this.label5);
            this.pLeft_1.Controls.Add(this.label4);
            this.pLeft_1.Controls.Add(this.label9);
            this.pLeft_1.Controls.Add(this.label3);
            this.pLeft_1.Controls.Add(this.label14);
            this.pLeft_1.Controls.Add(this.label1);
            this.pLeft_1.Controls.Add(this.label10);
            this.pLeft_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeft_1.Location = new System.Drawing.Point(0, 0);
            this.pLeft_1.Name = "pLeft_1";
            this.pLeft_1.Size = new System.Drawing.Size(120, 243);
            this.pLeft_1.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(5, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "  备       注";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "  入库仓库编号";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "  入库仓库名称";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(5, 187);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 20);
            this.label9.TabIndex = 7;
            this.label9.Text = "  付款方式";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "  采购订单类型";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label14.TabIndex = 3;
            this.label14.Text = "  采购订单编号";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "  供应商名称";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label10.TabIndex = 1;
            this.label10.Text = "  供应商编号";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // No
            // 
            this.No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.No.DataPropertyName = "LINE_NUMBER";
            this.No.Frozen = true;
            this.No.HeaderText = "No.";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.No.Width = 35;
            // 
            // PRODUCT_CODE
            // 
            this.PRODUCT_CODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PRODUCT_CODE.DataPropertyName = "PRODUCT_CODE";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.PRODUCT_CODE.DefaultCellStyle = dataGridViewCellStyle1;
            this.PRODUCT_CODE.Frozen = true;
            this.PRODUCT_CODE.HeaderText = "外购件编号";
            this.PRODUCT_CODE.MaxInputLength = 12;
            this.PRODUCT_CODE.Name = "PRODUCT_CODE";
            this.PRODUCT_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnProduct
            // 
            this.btnProduct.DataPropertyName = "btnProduct";
            this.btnProduct.Frozen = true;
            this.btnProduct.HeaderText = "";
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.ReadOnly = true;
            this.btnProduct.Width = 30;
            // 
            // NAME
            // 
            this.NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NAME.DataPropertyName = "NAME";
            this.NAME.Frozen = true;
            this.NAME.HeaderText = "外购件名称";
            this.NAME.Name = "NAME";
            this.NAME.ReadOnly = true;
            this.NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NAME.Width = 120;
            // 
            // SPEC
            // 
            this.SPEC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SPEC.DataPropertyName = "SPEC";
            this.SPEC.Frozen = true;
            this.SPEC.HeaderText = "规格";
            this.SPEC.Name = "SPEC";
            this.SPEC.ReadOnly = true;
            this.SPEC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SPEC.Width = 110;
            // 
            // QUANTITY
            // 
            this.QUANTITY.DataPropertyName = "QUANTITY";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Format = "N0";
            this.QUANTITY.DefaultCellStyle = dataGridViewCellStyle2;
            this.QUANTITY.Frozen = true;
            this.QUANTITY.HeaderText = "数量";
            this.QUANTITY.MaxInputLength = 10;
            this.QUANTITY.Name = "QUANTITY";
            this.QUANTITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.QUANTITY.Width = 80;
            // 
            // UNIT_NAME
            // 
            this.UNIT_NAME.DataPropertyName = "UNIT_NAME";
            this.UNIT_NAME.Frozen = true;
            this.UNIT_NAME.HeaderText = "单位";
            this.UNIT_NAME.Name = "UNIT_NAME";
            this.UNIT_NAME.ReadOnly = true;
            this.UNIT_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UNIT_NAME.Width = 104;
            // 
            // UNIT_CODE
            // 
            this.UNIT_CODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UNIT_CODE.DataPropertyName = "UNIT_CODE";
            this.UNIT_CODE.FillWeight = 5F;
            this.UNIT_CODE.Frozen = true;
            this.UNIT_CODE.HeaderText = "UNIT_CODE";
            this.UNIT_CODE.Name = "UNIT_CODE";
            this.UNIT_CODE.ReadOnly = true;
            this.UNIT_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UNIT_CODE.Visible = false;
            this.UNIT_CODE.Width = 25;
            // 
            // PRICE
            // 
            this.PRICE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PRICE.DataPropertyName = "PRICE";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Format = "N2";
            this.PRICE.DefaultCellStyle = dataGridViewCellStyle3;
            this.PRICE.Frozen = true;
            this.PRICE.HeaderText = "单价";
            this.PRICE.MaxInputLength = 10;
            this.PRICE.Name = "PRICE";
            this.PRICE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PRICE.Width = 120;
            // 
            // AMOUNT
            // 
            this.AMOUNT.DataPropertyName = "AMOUNT";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.AMOUNT.DefaultCellStyle = dataGridViewCellStyle4;
            this.AMOUNT.Frozen = true;
            this.AMOUNT.HeaderText = "金额";
            this.AMOUNT.Name = "AMOUNT";
            this.AMOUNT.ReadOnly = true;
            this.AMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AMOUNT.Width = 120;
            // 
            // AMOUNT_INCLUDED_TAX
            // 
            this.AMOUNT_INCLUDED_TAX.DataPropertyName = "AMOUNT_INCLUDED_TAX";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.AMOUNT_INCLUDED_TAX.DefaultCellStyle = dataGridViewCellStyle5;
            this.AMOUNT_INCLUDED_TAX.Frozen = true;
            this.AMOUNT_INCLUDED_TAX.HeaderText = "含税金额";
            this.AMOUNT_INCLUDED_TAX.Name = "AMOUNT_INCLUDED_TAX";
            this.AMOUNT_INCLUDED_TAX.ReadOnly = true;
            this.AMOUNT_INCLUDED_TAX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AMOUNT_INCLUDED_TAX.Width = 130;
            // 
            // FROMSET
            // 
            this.FROMSET.Frozen = true;
            this.FROMSET.HeaderText = "一式品\n見積書";
            this.FROMSET.Name = "FROMSET";
            this.FROMSET.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FROMSET.Visible = false;
            this.FROMSET.Width = 60;
            // 
            // FORMSET_FLAG
            // 
            this.FORMSET_FLAG.HeaderText = "FORMSET_FLAG";
            this.FORMSET_FLAG.Name = "FORMSET_FLAG";
            this.FORMSET_FLAG.ReadOnly = true;
            this.FORMSET_FLAG.Visible = false;
            // 
            // OLD_CODE
            // 
            this.OLD_CODE.HeaderText = "OLD_CODE";
            this.OLD_CODE.Name = "OLD_CODE";
            this.OLD_CODE.ReadOnly = true;
            this.OLD_CODE.Visible = false;
            // 
            // FrmPurchaseOrderEntry
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1040, 645);
            this.Controls.Add(this.pInfo);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmPurchaseOrderEntry";
            this.Text = "采购订单输入";
            this.Load += new System.EventHandler(this.FrmOrderImport_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPurchaseOrderEntry_FormClosed);
            this.pInfo.ResumeLayout(false);
            this.pAmount.ResumeLayout(false);
            this.pAmount.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.pHeader.ResumeLayout(false);
            this.pRight.ResumeLayout(false);
            this.pRight_2.ResumeLayout(false);
            this.pRight_2.PerformLayout();
            this.pRight_1.ResumeLayout(false);
            this.pLeft.ResumeLayout(false);
            this.pLeft_2.ResumeLayout(false);
            this.pLeft_2.PerformLayout();
            this.pLeft_1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pInfo;
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.Panel pLeft_1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pLeft_2;
        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.TextBox txtSupplierCode;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.TextBox txtWarehouseCode;
        private System.Windows.Forms.TextBox txtWarehouseName;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.ComboBox cboPurchaseSlipType;
        private System.Windows.Forms.Button btnWarehouse;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.Panel pRight_1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker entryDate;
        private System.Windows.Forms.Panel pRight_2;
        private System.Windows.Forms.TextBox txtPurchaseSlipNumber;
        private System.Windows.Forms.TextBox txtSupplierOrderCode;
        private System.Windows.Forms.DateTimePicker dueDate;
        private System.Windows.Forms.ComboBox cboTax;
        private System.Windows.Forms.TextBox txtPayment;
        private System.Windows.Forms.Button btnDeleteRow;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Panel pAmount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAmountIncludedTax;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOrderDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_CODE;
        private System.Windows.Forms.DataGridViewButtonColumn btnProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPEC;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUANTITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNIT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNIT_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn AMOUNT_INCLUDED_TAX;
        private System.Windows.Forms.DataGridViewLinkColumn FROMSET;
        private System.Windows.Forms.DataGridViewTextBoxColumn FORMSET_FLAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn OLD_CODE;
    }
}