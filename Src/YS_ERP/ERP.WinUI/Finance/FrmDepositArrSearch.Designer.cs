namespace CZZD.ERP.WinUI
{
    partial class FrmDepositArrSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDepositArrSearch));
            this.pBody = new System.Windows.Forms.Panel();
            this.pgControl = new CZZD.ERP.ComControls.PageControl();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLIP_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLIP_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDER_SLIP_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTOMER_CLAIM_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTOMER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AMOUNT_INCLUDED_TAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ARR_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MEMO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LINE_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRight = new System.Windows.Forms.Panel();
            this.panle2 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pLeft = new System.Windows.Forms.Panel();
            this.pleft_2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSlipDateTo = new System.Windows.Forms.DateTimePicker();
            this.txtSlipDateFrom = new System.Windows.Forms.DateTimePicker();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.txtOrderSlipNumber = new System.Windows.Forms.TextBox();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.pLeft_1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.pRight.SuspendLayout();
            this.panle2.SuspendLayout();
            this.pLeft.SuspendLayout();
            this.pleft_2.SuspendLayout();
            this.pLeft_1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pBody
            // 
            this.pBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBody.Controls.Add(this.pgControl);
            this.pBody.Controls.Add(this.btnDelete);
            this.pBody.Controls.Add(this.btnCancel);
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
            this.pgControl.Location = new System.Drawing.Point(3, 586);
            this.pgControl.Name = "pgControl";
            this.pgControl.Size = new System.Drawing.Size(1013, 30);
            this.pgControl.TabIndex = 32;
            this.pgControl.TotalPage = 1;
            this.pgControl.PageChanged += new CZZD.ERP.ComControls.PageControl.BtnClickHandle(this.pgControl_PageChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnDelete.Location = new System.Drawing.Point(833, 617);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 30);
            this.btnDelete.TabIndex = 31;
            this.btnDelete.Text = "分配解除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnCancel.Location = new System.Drawing.Point(926, 617);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "关　闭";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnPrint.Location = new System.Drawing.Point(740, 617);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(90, 30);
            this.btnPrint.TabIndex = 29;
            this.btnPrint.Text = "导　出";
            this.btnPrint.UseVisualStyleBackColor = true;
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
            this.SLIP_NUMBER,
            this.SLIP_DATE,
            this.ORDER_SLIP_NUMBER,
            this.CUSTOMER_CLAIM_CODE,
            this.CUSTOMER_NAME,
            this.AMOUNT_INCLUDED_TAX,
            this.ARR_AMOUNT,
            this.MEMO,
            this.LINE_NUMBER});
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(3, 200);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 25;
            this.dgvData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvData.RowTemplate.Height = 25;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1012, 385);
            this.dgvData.TabIndex = 19;
            this.dgvData.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvData_RowStateChanged);
            // 
            // No
            // 
            this.No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.No.DataPropertyName = "ROW";
            this.No.Frozen = true;
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.No.Width = 35;
            // 
            // SLIP_NUMBER
            // 
            this.SLIP_NUMBER.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SLIP_NUMBER.DataPropertyName = "SLIP_NUMBER";
            this.SLIP_NUMBER.Frozen = true;
            this.SLIP_NUMBER.HeaderText = "分配编号";
            this.SLIP_NUMBER.Name = "SLIP_NUMBER";
            this.SLIP_NUMBER.ReadOnly = true;
            this.SLIP_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SLIP_NUMBER.Width = 85;
            // 
            // SLIP_DATE
            // 
            this.SLIP_DATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SLIP_DATE.DataPropertyName = "SLIP_DATE";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "yyyy-MM-dd";
            this.SLIP_DATE.DefaultCellStyle = dataGridViewCellStyle3;
            this.SLIP_DATE.Frozen = true;
            this.SLIP_DATE.HeaderText = "分配日期";
            this.SLIP_DATE.Name = "SLIP_DATE";
            this.SLIP_DATE.ReadOnly = true;
            this.SLIP_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ORDER_SLIP_NUMBER
            // 
            this.ORDER_SLIP_NUMBER.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ORDER_SLIP_NUMBER.DataPropertyName = "ORDER_SLIP_NUMBER";
            this.ORDER_SLIP_NUMBER.Frozen = true;
            this.ORDER_SLIP_NUMBER.HeaderText = "订单编号";
            this.ORDER_SLIP_NUMBER.Name = "ORDER_SLIP_NUMBER";
            this.ORDER_SLIP_NUMBER.ReadOnly = true;
            this.ORDER_SLIP_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CUSTOMER_CLAIM_CODE
            // 
            this.CUSTOMER_CLAIM_CODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CUSTOMER_CLAIM_CODE.DataPropertyName = "CUSTOMER_CLAIM_CODE";
            this.CUSTOMER_CLAIM_CODE.HeaderText = "客户编号";
            this.CUSTOMER_CLAIM_CODE.Name = "CUSTOMER_CLAIM_CODE";
            this.CUSTOMER_CLAIM_CODE.ReadOnly = true;
            this.CUSTOMER_CLAIM_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CUSTOMER_NAME
            // 
            this.CUSTOMER_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CUSTOMER_NAME.DataPropertyName = "CUSTOMER_NAME";
            this.CUSTOMER_NAME.HeaderText = "客户名称";
            this.CUSTOMER_NAME.Name = "CUSTOMER_NAME";
            this.CUSTOMER_NAME.ReadOnly = true;
            this.CUSTOMER_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CUSTOMER_NAME.Width = 150;
            // 
            // AMOUNT_INCLUDED_TAX
            // 
            this.AMOUNT_INCLUDED_TAX.DataPropertyName = "AMOUNT_INCLUDED_TAX";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.AMOUNT_INCLUDED_TAX.DefaultCellStyle = dataGridViewCellStyle4;
            this.AMOUNT_INCLUDED_TAX.HeaderText = "订单金额";
            this.AMOUNT_INCLUDED_TAX.Name = "AMOUNT_INCLUDED_TAX";
            this.AMOUNT_INCLUDED_TAX.ReadOnly = true;
            this.AMOUNT_INCLUDED_TAX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ARR_AMOUNT
            // 
            this.ARR_AMOUNT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ARR_AMOUNT.DataPropertyName = "ARR_AMOUNT";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.ARR_AMOUNT.DefaultCellStyle = dataGridViewCellStyle5;
            this.ARR_AMOUNT.HeaderText = "分配金額";
            this.ARR_AMOUNT.Name = "ARR_AMOUNT";
            this.ARR_AMOUNT.ReadOnly = true;
            this.ARR_AMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ARR_AMOUNT.Width = 130;
            // 
            // MEMO
            // 
            this.MEMO.DataPropertyName = "MEMO";
            this.MEMO.HeaderText = "备注";
            this.MEMO.Name = "MEMO";
            this.MEMO.ReadOnly = true;
            this.MEMO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LINE_NUMBER
            // 
            this.LINE_NUMBER.DataPropertyName = "LINE_NUMBER";
            this.LINE_NUMBER.HeaderText = "LINE_NUMBER";
            this.LINE_NUMBER.Name = "LINE_NUMBER";
            this.LINE_NUMBER.ReadOnly = true;
            this.LINE_NUMBER.Visible = false;
            // 
            // pRight
            // 
            this.pRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pRight.Controls.Add(this.panle2);
            this.pRight.Controls.Add(this.panel3);
            this.pRight.Location = new System.Drawing.Point(510, 3);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(505, 195);
            this.pRight.TabIndex = 15;
            // 
            // panle2
            // 
            this.panle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panle2.Controls.Add(this.btnSearch);
            this.panle2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panle2.Location = new System.Drawing.Point(120, 0);
            this.panle2.Name = "panle2";
            this.panle2.Size = new System.Drawing.Size(383, 193);
            this.panle2.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSearch.Location = new System.Drawing.Point(292, 162);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 30);
            this.btnSearch.TabIndex = 16;
            this.btnSearch.Text = "查　询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(120, 193);
            this.panel3.TabIndex = 4;
            // 
            // pLeft
            // 
            this.pLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLeft.Controls.Add(this.pleft_2);
            this.pLeft.Controls.Add(this.pLeft_1);
            this.pLeft.Location = new System.Drawing.Point(3, 3);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(505, 195);
            this.pLeft.TabIndex = 15;
            // 
            // pleft_2
            // 
            this.pleft_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pleft_2.Controls.Add(this.label1);
            this.pleft_2.Controls.Add(this.txtSlipDateTo);
            this.pleft_2.Controls.Add(this.txtSlipDateFrom);
            this.pleft_2.Controls.Add(this.txtBalance);
            this.pleft_2.Controls.Add(this.txtOrderSlipNumber);
            this.pleft_2.Controls.Add(this.txtCustomerCode);
            this.pleft_2.Controls.Add(this.txtCustomerName);
            this.pleft_2.Controls.Add(this.btnCustomer);
            this.pleft_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pleft_2.Location = new System.Drawing.Point(120, 0);
            this.pleft_2.Name = "pleft_2";
            this.pleft_2.Size = new System.Drawing.Size(383, 193);
            this.pleft_2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.Location = new System.Drawing.Point(120, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "~";
            // 
            // txtSlipDateTo
            // 
            this.txtSlipDateTo.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.txtSlipDateTo.Checked = false;
            this.txtSlipDateTo.CustomFormat = "yyyy-MM-dd";
            this.txtSlipDateTo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSlipDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtSlipDateTo.Location = new System.Drawing.Point(142, 95);
            this.txtSlipDateTo.Name = "txtSlipDateTo";
            this.txtSlipDateTo.ShowCheckBox = true;
            this.txtSlipDateTo.Size = new System.Drawing.Size(113, 23);
            this.txtSlipDateTo.TabIndex = 20;
            this.txtSlipDateTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtSlipDateFrom
            // 
            this.txtSlipDateFrom.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.txtSlipDateFrom.Checked = false;
            this.txtSlipDateFrom.CustomFormat = "yyyy-MM-dd";
            this.txtSlipDateFrom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSlipDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtSlipDateFrom.Location = new System.Drawing.Point(5, 95);
            this.txtSlipDateFrom.Name = "txtSlipDateFrom";
            this.txtSlipDateFrom.ShowCheckBox = true;
            this.txtSlipDateFrom.Size = new System.Drawing.Size(113, 23);
            this.txtSlipDateFrom.TabIndex = 19;
            this.txtSlipDateFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtBalance
            // 
            this.txtBalance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBalance.Enabled = false;
            this.txtBalance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtBalance.Location = new System.Drawing.Point(5, 65);
            this.txtBalance.MaxLength = 20;
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(250, 25);
            this.txtBalance.TabIndex = 15;
            // 
            // txtOrderSlipNumber
            // 
            this.txtOrderSlipNumber.BackColor = System.Drawing.SystemColors.Info;
            this.txtOrderSlipNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderSlipNumber.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtOrderSlipNumber.Location = new System.Drawing.Point(5, 125);
            this.txtOrderSlipNumber.MaxLength = 1;
            this.txtOrderSlipNumber.Name = "txtOrderSlipNumber";
            this.txtOrderSlipNumber.Size = new System.Drawing.Size(250, 25);
            this.txtOrderSlipNumber.TabIndex = 0;
            this.txtOrderSlipNumber.Leave += new System.EventHandler(this.txtCustomerCode_Leave);
            this.txtOrderSlipNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
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
            this.txtCustomerCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerName.Enabled = false;
            this.txtCustomerName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCustomerName.Location = new System.Drawing.Point(5, 35);
            this.txtCustomerName.MaxLength = 100;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(250, 25);
            this.txtCustomerName.TabIndex = 3;
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
            this.btnCustomer.Location = new System.Drawing.Point(261, 3);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(25, 25);
            this.btnCustomer.TabIndex = 9;
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // pLeft_1
            // 
            this.pLeft_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pLeft_1.Controls.Add(this.label2);
            this.pLeft_1.Controls.Add(this.label6);
            this.pLeft_1.Controls.Add(this.label17);
            this.pLeft_1.Controls.Add(this.label4);
            this.pLeft_1.Controls.Add(this.label13);
            this.pLeft_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeft_1.Location = new System.Drawing.Point(0, 0);
            this.pLeft_1.Name = "pLeft_1";
            this.pLeft_1.Size = new System.Drawing.Size(120, 193);
            this.pLeft_1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "  订单编号";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(5, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "  分配日期";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label17.TabIndex = 1;
            this.label17.Text = "  预收款余额\t\t\t\t";
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
            this.label4.Text = "  客户编号";
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
            this.label13.Text = "  客户名称";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmDepositArrSearch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1023, 652);
            this.Controls.Add(this.pBody);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDepositArrSearch";
            this.Text = "预收款分配查询";
            this.Load += new System.EventHandler(this.FrmDepositArrSearch_Load);
            this.pBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.pRight.ResumeLayout(false);
            this.panle2.ResumeLayout(false);
            this.pLeft.ResumeLayout(false);
            this.pleft_2.ResumeLayout(false);
            this.pleft_2.PerformLayout();
            this.pLeft_1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pBody;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.Panel pleft_2;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Panel pLeft_1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrint;
        private CZZD.ERP.ComControls.PageControl pgControl;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.Panel panle2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtSlipDateTo;
        private System.Windows.Forms.DateTimePicker txtSlipDateFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOrderSlipNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLIP_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLIP_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDER_SLIP_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_CLAIM_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn AMOUNT_INCLUDED_TAX;
        private System.Windows.Forms.DataGridViewTextBoxColumn ARR_AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEMO;
        private System.Windows.Forms.DataGridViewTextBoxColumn LINE_NUMBER;
    }
}