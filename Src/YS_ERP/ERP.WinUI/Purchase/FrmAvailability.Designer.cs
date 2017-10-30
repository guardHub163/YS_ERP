namespace CZZD.ERP.WinUI
{
    partial class FrmAvailability
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAvailability));
            this.pLeft = new System.Windows.Forms.Panel();
            this.pLeft_2 = new System.Windows.Forms.Panel();
            this.btnSupplierTo = new System.Windows.Forms.Button();
            this.btnSupplierFrom = new System.Windows.Forms.Button();
            this.btnGroup = new System.Windows.Forms.Button();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.txtGroupCode = new System.Windows.Forms.TextBox();
            this.txtSupplierNameTo = new System.Windows.Forms.TextBox();
            this.txtSupplierCodeTo = new System.Windows.Forms.TextBox();
            this.txtSupplierNameFrom = new System.Windows.Forms.TextBox();
            this.txtSupplierCodeFrom = new System.Windows.Forms.TextBox();
            this.pLeft_1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPOSlipDateTo = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pBody = new System.Windows.Forms.Panel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.pheader = new System.Windows.Forms.Panel();
            this.pRight = new System.Windows.Forms.Panel();
            this.pRight_2 = new System.Windows.Forms.Panel();
            this.txtPOSlipDateFrom = new System.Windows.Forms.DateTimePicker();
            this.pRight_1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.Row = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUPPLIER_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUPPLIER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PURCHASE_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PURCHASE_QUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MAX_PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MIN_PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AVERAGE_PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RECEIPT_QUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RECEIPT_RATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RERECEIPT_QUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RERECEIPT_RATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ON_SCHEDULE_RECEIPT_QUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ON_SCHEDULE_RECEIPT_RATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pLeft.SuspendLayout();
            this.pLeft_2.SuspendLayout();
            this.pLeft_1.SuspendLayout();
            this.pBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.pheader.SuspendLayout();
            this.pRight.SuspendLayout();
            this.pRight_2.SuspendLayout();
            this.pRight_1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pLeft
            // 
            this.pLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLeft.Controls.Add(this.pLeft_2);
            this.pLeft.Controls.Add(this.pLeft_1);
            this.pLeft.Location = new System.Drawing.Point(0, 0);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(510, 195);
            this.pLeft.TabIndex = 100;
            // 
            // pLeft_2
            // 
            this.pLeft_2.BackColor = System.Drawing.Color.White;
            this.pLeft_2.Controls.Add(this.btnSupplierTo);
            this.pLeft_2.Controls.Add(this.btnSupplierFrom);
            this.pLeft_2.Controls.Add(this.btnGroup);
            this.pLeft_2.Controls.Add(this.txtGroupName);
            this.pLeft_2.Controls.Add(this.txtGroupCode);
            this.pLeft_2.Controls.Add(this.txtSupplierNameTo);
            this.pLeft_2.Controls.Add(this.txtSupplierCodeTo);
            this.pLeft_2.Controls.Add(this.txtSupplierNameFrom);
            this.pLeft_2.Controls.Add(this.txtSupplierCodeFrom);
            this.pLeft_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pLeft_2.Location = new System.Drawing.Point(120, 0);
            this.pLeft_2.Name = "pLeft_2";
            this.pLeft_2.Size = new System.Drawing.Size(388, 193);
            this.pLeft_2.TabIndex = 98;
            // 
            // btnSupplierTo
            // 
            this.btnSupplierTo.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnSupplierTo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSupplierTo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSupplierTo.FlatAppearance.BorderSize = 0;
            this.btnSupplierTo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSupplierTo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSupplierTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupplierTo.Location = new System.Drawing.Point(261, 125);
            this.btnSupplierTo.Name = "btnSupplierTo";
            this.btnSupplierTo.Size = new System.Drawing.Size(25, 25);
            this.btnSupplierTo.TabIndex = 28;
            this.btnSupplierTo.UseVisualStyleBackColor = true;
            this.btnSupplierTo.Click += new System.EventHandler(this.btnSupplierTo_Click);
            // 
            // btnSupplierFrom
            // 
            this.btnSupplierFrom.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnSupplierFrom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSupplierFrom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSupplierFrom.FlatAppearance.BorderSize = 0;
            this.btnSupplierFrom.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSupplierFrom.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSupplierFrom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupplierFrom.Location = new System.Drawing.Point(261, 65);
            this.btnSupplierFrom.Name = "btnSupplierFrom";
            this.btnSupplierFrom.Size = new System.Drawing.Size(25, 25);
            this.btnSupplierFrom.TabIndex = 27;
            this.btnSupplierFrom.UseVisualStyleBackColor = true;
            this.btnSupplierFrom.Click += new System.EventHandler(this.btnSupplierFrom_Click);
            // 
            // btnGroup
            // 
            this.btnGroup.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGroup.FlatAppearance.BorderSize = 0;
            this.btnGroup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnGroup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGroup.Location = new System.Drawing.Point(261, 5);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Size = new System.Drawing.Size(25, 25);
            this.btnGroup.TabIndex = 16;
            this.btnGroup.UseVisualStyleBackColor = true;
            this.btnGroup.Click += new System.EventHandler(this.btnGroup_Click);
            // 
            // txtGroupName
            // 
            this.txtGroupName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtGroupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGroupName.Enabled = false;
            this.txtGroupName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtGroupName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtGroupName.Location = new System.Drawing.Point(5, 35);
            this.txtGroupName.MaxLength = 20;
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(251, 25);
            this.txtGroupName.TabIndex = 15;
            // 
            // txtGroupCode
            // 
            this.txtGroupCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtGroupCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGroupCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtGroupCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtGroupCode.Location = new System.Drawing.Point(5, 5);
            this.txtGroupCode.MaxLength = 20;
            this.txtGroupCode.Name = "txtGroupCode";
            this.txtGroupCode.Size = new System.Drawing.Size(251, 25);
            this.txtGroupCode.TabIndex = 15;
            this.txtGroupCode.Leave += new System.EventHandler(this.txtGroupCode_Leave);
            // 
            // txtSupplierNameTo
            // 
            this.txtSupplierNameTo.BackColor = System.Drawing.Color.Gainsboro;
            this.txtSupplierNameTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupplierNameTo.Enabled = false;
            this.txtSupplierNameTo.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSupplierNameTo.Location = new System.Drawing.Point(5, 155);
            this.txtSupplierNameTo.MaxLength = 50;
            this.txtSupplierNameTo.Name = "txtSupplierNameTo";
            this.txtSupplierNameTo.Size = new System.Drawing.Size(250, 25);
            this.txtSupplierNameTo.TabIndex = 14;
            this.txtSupplierNameTo.Leave += new System.EventHandler(this.txtSupplierCodeTo_Leave);
            // 
            // txtSupplierCodeTo
            // 
            this.txtSupplierCodeTo.BackColor = System.Drawing.SystemColors.Info;
            this.txtSupplierCodeTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupplierCodeTo.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSupplierCodeTo.Location = new System.Drawing.Point(5, 125);
            this.txtSupplierCodeTo.MaxLength = 50;
            this.txtSupplierCodeTo.Name = "txtSupplierCodeTo";
            this.txtSupplierCodeTo.Size = new System.Drawing.Size(250, 25);
            this.txtSupplierCodeTo.TabIndex = 14;
            this.txtSupplierCodeTo.Leave += new System.EventHandler(this.txtSupplierCodeTo_Leave);
            // 
            // txtSupplierNameFrom
            // 
            this.txtSupplierNameFrom.BackColor = System.Drawing.Color.Gainsboro;
            this.txtSupplierNameFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupplierNameFrom.Enabled = false;
            this.txtSupplierNameFrom.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSupplierNameFrom.Location = new System.Drawing.Point(5, 95);
            this.txtSupplierNameFrom.MaxLength = 50;
            this.txtSupplierNameFrom.Name = "txtSupplierNameFrom";
            this.txtSupplierNameFrom.Size = new System.Drawing.Size(251, 25);
            this.txtSupplierNameFrom.TabIndex = 4;
            this.txtSupplierNameFrom.Leave += new System.EventHandler(this.txtSupplierCodeFrom_Leave);
            // 
            // txtSupplierCodeFrom
            // 
            this.txtSupplierCodeFrom.BackColor = System.Drawing.SystemColors.Info;
            this.txtSupplierCodeFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupplierCodeFrom.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSupplierCodeFrom.Location = new System.Drawing.Point(5, 65);
            this.txtSupplierCodeFrom.MaxLength = 50;
            this.txtSupplierCodeFrom.Name = "txtSupplierCodeFrom";
            this.txtSupplierCodeFrom.Size = new System.Drawing.Size(251, 25);
            this.txtSupplierCodeFrom.TabIndex = 4;
            this.txtSupplierCodeFrom.Leave += new System.EventHandler(this.txtSupplierCodeFrom_Leave);
            // 
            // pLeft_1
            // 
            this.pLeft_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pLeft_1.Controls.Add(this.label11);
            this.pLeft_1.Controls.Add(this.label7);
            this.pLeft_1.Controls.Add(this.label10);
            this.pLeft_1.Controls.Add(this.label3);
            this.pLeft_1.Controls.Add(this.label9);
            this.pLeft_1.Controls.Add(this.label4);
            this.pLeft_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeft_1.Location = new System.Drawing.Point(0, 0);
            this.pLeft_1.Name = "pLeft_1";
            this.pLeft_1.Size = new System.Drawing.Size(120, 193);
            this.pLeft_1.TabIndex = 97;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.SteelBlue;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(5, 155);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 20);
            this.label11.TabIndex = 83;
            this.label11.Text = "结束供应商名称：";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.SteelBlue;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(5, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 20);
            this.label7.TabIndex = 83;
            this.label7.Text = "结束供应商：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.SteelBlue;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(5, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 20);
            this.label10.TabIndex = 83;
            this.label10.Text = "开始供应商名称：";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 20);
            this.label3.TabIndex = 83;
            this.label3.Text = "开始供应商：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.SteelBlue;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(5, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 20);
            this.label9.TabIndex = 92;
            this.label9.Text = "外购件种类名称：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.SteelBlue;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 20);
            this.label4.TabIndex = 92;
            this.label4.Text = "外购件种类：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPOSlipDateTo
            // 
            this.txtPOSlipDateTo.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.txtPOSlipDateTo.Checked = false;
            this.txtPOSlipDateTo.CustomFormat = "yyyy-MM-dd";
            this.txtPOSlipDateTo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtPOSlipDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtPOSlipDateTo.Location = new System.Drawing.Point(140, 5);
            this.txtPOSlipDateTo.Name = "txtPOSlipDateTo";
            this.txtPOSlipDateTo.ShowCheckBox = true;
            this.txtPOSlipDateTo.Size = new System.Drawing.Size(115, 23);
            this.txtPOSlipDateTo.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(119, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 19);
            this.label8.TabIndex = 19;
            this.label8.Text = "~";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 93;
            this.label1.Text = "采购日期：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSearch.Location = new System.Drawing.Point(287, 156);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 30);
            this.btnSearch.TabIndex = 102;
            this.btnSearch.Text = "查　询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pBody
            // 
            this.pBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBody.Controls.Add(this.dgvData);
            this.pBody.Controls.Add(this.pheader);
            this.pBody.Controls.Add(this.btnCancel);
            this.pBody.Controls.Add(this.btnExport);
            this.pBody.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.pBody.Location = new System.Drawing.Point(0, 0);
            this.pBody.Name = "pBody";
            this.pBody.Size = new System.Drawing.Size(1024, 650);
            this.pBody.TabIndex = 103;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.ColumnHeadersHeight = 28;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Row,
            this.SUPPLIER_CODE,
            this.SUPPLIER_NAME,
            this.PRODUCT_CODE,
            this.PRODUCT_NAME,
            this.PURCHASE_AMOUNT,
            this.PURCHASE_QUANTITY,
            this.MAX_PRICE,
            this.MIN_PRICE,
            this.AVERAGE_PRICE,
            this.RECEIPT_QUANTITY,
            this.RECEIPT_RATE,
            this.RERECEIPT_QUANTITY,
            this.RERECEIPT_RATE,
            this.ON_SCHEDULE_RECEIPT_QUANTITY,
            this.ON_SCHEDULE_RECEIPT_RATE});
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(3, 200);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowTemplate.Height = 25;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1015, 411);
            this.dgvData.TabIndex = 104;
            this.dgvData.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvData_RowStateChanged);
            // 
            // pheader
            // 
            this.pheader.Controls.Add(this.pRight);
            this.pheader.Controls.Add(this.pLeft);
            this.pheader.Location = new System.Drawing.Point(3, 3);
            this.pheader.Name = "pheader";
            this.pheader.Size = new System.Drawing.Size(1014, 195);
            this.pheader.TabIndex = 103;
            // 
            // pRight
            // 
            this.pRight.BackColor = System.Drawing.Color.Transparent;
            this.pRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pRight.Controls.Add(this.pRight_2);
            this.pRight.Controls.Add(this.pRight_1);
            this.pRight.Location = new System.Drawing.Point(514, 0);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(500, 191);
            this.pRight.TabIndex = 101;
            // 
            // pRight_2
            // 
            this.pRight_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pRight_2.Controls.Add(this.txtPOSlipDateFrom);
            this.pRight_2.Controls.Add(this.txtPOSlipDateTo);
            this.pRight_2.Controls.Add(this.btnSearch);
            this.pRight_2.Controls.Add(this.label8);
            this.pRight_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRight_2.Location = new System.Drawing.Point(120, 0);
            this.pRight_2.Name = "pRight_2";
            this.pRight_2.Size = new System.Drawing.Size(378, 189);
            this.pRight_2.TabIndex = 1;
            // 
            // txtPOSlipDateFrom
            // 
            this.txtPOSlipDateFrom.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.txtPOSlipDateFrom.Checked = false;
            this.txtPOSlipDateFrom.CustomFormat = "yyyy-MM-dd";
            this.txtPOSlipDateFrom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtPOSlipDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtPOSlipDateFrom.Location = new System.Drawing.Point(5, 5);
            this.txtPOSlipDateFrom.Name = "txtPOSlipDateFrom";
            this.txtPOSlipDateFrom.ShowCheckBox = true;
            this.txtPOSlipDateFrom.Size = new System.Drawing.Size(115, 23);
            this.txtPOSlipDateFrom.TabIndex = 18;
            // 
            // pRight_1
            // 
            this.pRight_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pRight_1.Controls.Add(this.label1);
            this.pRight_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pRight_1.Location = new System.Drawing.Point(0, 0);
            this.pRight_1.Name = "pRight_1";
            this.pRight_1.Size = new System.Drawing.Size(120, 189);
            this.pRight_1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnCancel.Location = new System.Drawing.Point(929, 617);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 102;
            this.btnCancel.Text = "关　闭";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExport
            // 
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnExport.Location = new System.Drawing.Point(833, 617);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(90, 30);
            this.btnExport.TabIndex = 102;
            this.btnExport.Text = "导　出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // Row
            // 
            this.Row.DataPropertyName = "Row";
            this.Row.Frozen = true;
            this.Row.HeaderText = "No";
            this.Row.Name = "Row";
            this.Row.ReadOnly = true;
            this.Row.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Row.Width = 35;
            // 
            // SUPPLIER_CODE
            // 
            this.SUPPLIER_CODE.DataPropertyName = "SUPPLIER_CODE";
            this.SUPPLIER_CODE.Frozen = true;
            this.SUPPLIER_CODE.HeaderText = "供应商编号";
            this.SUPPLIER_CODE.Name = "SUPPLIER_CODE";
            this.SUPPLIER_CODE.ReadOnly = true;
            this.SUPPLIER_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            // PRODUCT_CODE
            // 
            this.PRODUCT_CODE.DataPropertyName = "PRODUCT_CODE";
            this.PRODUCT_CODE.Frozen = true;
            this.PRODUCT_CODE.HeaderText = "外购件编号";
            this.PRODUCT_CODE.Name = "PRODUCT_CODE";
            this.PRODUCT_CODE.ReadOnly = true;
            this.PRODUCT_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PRODUCT_CODE.Width = 120;
            // 
            // PRODUCT_NAME
            // 
            this.PRODUCT_NAME.DataPropertyName = "PRODUCT_NAME";
            this.PRODUCT_NAME.Frozen = true;
            this.PRODUCT_NAME.HeaderText = "外购件名称";
            this.PRODUCT_NAME.Name = "PRODUCT_NAME";
            this.PRODUCT_NAME.ReadOnly = true;
            this.PRODUCT_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PRODUCT_NAME.Width = 150;
            // 
            // PURCHASE_AMOUNT
            // 
            this.PURCHASE_AMOUNT.DataPropertyName = "PURCHASE_AMOUNT";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.PURCHASE_AMOUNT.DefaultCellStyle = dataGridViewCellStyle3;
            this.PURCHASE_AMOUNT.HeaderText = "采购总额";
            this.PURCHASE_AMOUNT.Name = "PURCHASE_AMOUNT";
            this.PURCHASE_AMOUNT.ReadOnly = true;
            this.PURCHASE_AMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PURCHASE_QUANTITY
            // 
            this.PURCHASE_QUANTITY.DataPropertyName = "PURCHASE_QUANTITY";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.PURCHASE_QUANTITY.DefaultCellStyle = dataGridViewCellStyle4;
            this.PURCHASE_QUANTITY.HeaderText = "采购数量";
            this.PURCHASE_QUANTITY.Name = "PURCHASE_QUANTITY";
            this.PURCHASE_QUANTITY.ReadOnly = true;
            this.PURCHASE_QUANTITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MAX_PRICE
            // 
            this.MAX_PRICE.DataPropertyName = "MAX_PRICE";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.MAX_PRICE.DefaultCellStyle = dataGridViewCellStyle5;
            this.MAX_PRICE.HeaderText = "最高单价";
            this.MAX_PRICE.Name = "MAX_PRICE";
            this.MAX_PRICE.ReadOnly = true;
            this.MAX_PRICE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MIN_PRICE
            // 
            this.MIN_PRICE.DataPropertyName = "MIN_PRICE";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.MIN_PRICE.DefaultCellStyle = dataGridViewCellStyle6;
            this.MIN_PRICE.HeaderText = "最低单价";
            this.MIN_PRICE.Name = "MIN_PRICE";
            this.MIN_PRICE.ReadOnly = true;
            this.MIN_PRICE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AVERAGE_PRICE
            // 
            this.AVERAGE_PRICE.DataPropertyName = "AVERAGE_PRICE";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.AVERAGE_PRICE.DefaultCellStyle = dataGridViewCellStyle7;
            this.AVERAGE_PRICE.HeaderText = "平均单价";
            this.AVERAGE_PRICE.Name = "AVERAGE_PRICE";
            this.AVERAGE_PRICE.ReadOnly = true;
            this.AVERAGE_PRICE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RECEIPT_QUANTITY
            // 
            this.RECEIPT_QUANTITY.DataPropertyName = "RECEIPT_QUANTITY";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            this.RECEIPT_QUANTITY.DefaultCellStyle = dataGridViewCellStyle8;
            this.RECEIPT_QUANTITY.HeaderText = "实际交货数量";
            this.RECEIPT_QUANTITY.Name = "RECEIPT_QUANTITY";
            this.RECEIPT_QUANTITY.ReadOnly = true;
            this.RECEIPT_QUANTITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RECEIPT_RATE
            // 
            this.RECEIPT_RATE.DataPropertyName = "RECEIPT_RATE";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "0%";
            dataGridViewCellStyle9.NullValue = null;
            this.RECEIPT_RATE.DefaultCellStyle = dataGridViewCellStyle9;
            this.RECEIPT_RATE.HeaderText = "实际交货率";
            this.RECEIPT_RATE.Name = "RECEIPT_RATE";
            this.RECEIPT_RATE.ReadOnly = true;
            this.RECEIPT_RATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RERECEIPT_QUANTITY
            // 
            this.RERECEIPT_QUANTITY.DataPropertyName = "RERECEIPT_QUANTITY";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N0";
            this.RERECEIPT_QUANTITY.DefaultCellStyle = dataGridViewCellStyle10;
            this.RERECEIPT_QUANTITY.HeaderText = "不良品数量";
            this.RERECEIPT_QUANTITY.Name = "RERECEIPT_QUANTITY";
            this.RERECEIPT_QUANTITY.ReadOnly = true;
            this.RERECEIPT_QUANTITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RERECEIPT_RATE
            // 
            this.RERECEIPT_RATE.DataPropertyName = "RERECEIPT_RATE";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            this.RERECEIPT_RATE.DefaultCellStyle = dataGridViewCellStyle11;
            this.RERECEIPT_RATE.HeaderText = "不良率";
            this.RERECEIPT_RATE.Name = "RERECEIPT_RATE";
            this.RERECEIPT_RATE.ReadOnly = true;
            this.RERECEIPT_RATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ON_SCHEDULE_RECEIPT_QUANTITY
            // 
            this.ON_SCHEDULE_RECEIPT_QUANTITY.DataPropertyName = "ON_SCHEDULE_RECEIPT_QUANTITY";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N0";
            this.ON_SCHEDULE_RECEIPT_QUANTITY.DefaultCellStyle = dataGridViewCellStyle12;
            this.ON_SCHEDULE_RECEIPT_QUANTITY.HeaderText = "准时交货数量";
            this.ON_SCHEDULE_RECEIPT_QUANTITY.Name = "ON_SCHEDULE_RECEIPT_QUANTITY";
            this.ON_SCHEDULE_RECEIPT_QUANTITY.ReadOnly = true;
            this.ON_SCHEDULE_RECEIPT_QUANTITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ON_SCHEDULE_RECEIPT_RATE
            // 
            this.ON_SCHEDULE_RECEIPT_RATE.DataPropertyName = "ON_SCHEDULE_RECEIPT_RATE";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "0.0000%";
            dataGridViewCellStyle13.NullValue = null;
            this.ON_SCHEDULE_RECEIPT_RATE.DefaultCellStyle = dataGridViewCellStyle13;
            this.ON_SCHEDULE_RECEIPT_RATE.HeaderText = "准时交货率";
            this.ON_SCHEDULE_RECEIPT_RATE.Name = "ON_SCHEDULE_RECEIPT_RATE";
            this.ON_SCHEDULE_RECEIPT_RATE.ReadOnly = true;
            this.ON_SCHEDULE_RECEIPT_RATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FrmAvailability
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1028, 652);
            this.Controls.Add(this.pBody);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAvailability";
            this.Text = "供应商供货表";
            this.Load += new System.EventHandler(this.FrmAvailability_Load);
            this.pLeft.ResumeLayout(false);
            this.pLeft_2.ResumeLayout(false);
            this.pLeft_2.PerformLayout();
            this.pLeft_1.ResumeLayout(false);
            this.pBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.pheader.ResumeLayout(false);
            this.pRight.ResumeLayout(false);
            this.pRight_2.ResumeLayout(false);
            this.pRight_2.PerformLayout();
            this.pRight_1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.Panel pLeft_2;
        private System.Windows.Forms.Panel pLeft_1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSupplierCodeFrom;
        private System.Windows.Forms.TextBox txtSupplierCodeTo;
        private System.Windows.Forms.TextBox txtGroupCode;
        private System.Windows.Forms.Button btnGroup;
        private System.Windows.Forms.DateTimePicker txtPOSlipDateTo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSupplierFrom;
        private System.Windows.Forms.Button btnSupplierTo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pBody;
        private System.Windows.Forms.Panel pheader;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.Panel pRight_2;
        private System.Windows.Forms.Panel pRight_1;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.TextBox txtSupplierNameTo;
        private System.Windows.Forms.TextBox txtSupplierNameFrom;
        private System.Windows.Forms.DateTimePicker txtPOSlipDateFrom;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn Row;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUPPLIER_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUPPLIER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PURCHASE_AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PURCHASE_QUANTITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAX_PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn MIN_PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn AVERAGE_PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn RECEIPT_QUANTITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn RECEIPT_RATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn RERECEIPT_QUANTITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn RERECEIPT_RATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ON_SCHEDULE_RECEIPT_QUANTITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn ON_SCHEDULE_RECEIPT_RATE;
    }
}