namespace CZZD.ERP.WinUI
{
    partial class FrmCProduceBOM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCProduceBOM));
            this.pInfo = new System.Windows.Forms.Panel();
            this.btnAutoPurchase = new System.Windows.Forms.Button();
            this.pLeft = new System.Windows.Forms.Panel();
            this.pleft_2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEndCustomer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnWarehouse = new System.Windows.Forms.Button();
            this.txtSlipNumber = new System.Windows.Forms.TextBox();
            this.txtEndCustomerName = new System.Windows.Forms.TextBox();
            this.txtSlipDateTo = new System.Windows.Forms.DateTimePicker();
            this.txtCustomerPoNumber = new System.Windows.Forms.TextBox();
            this.txtSlipDateFrom = new System.Windows.Forms.DateTimePicker();
            this.txtDepartualDateFrom = new System.Windows.Forms.DateTimePicker();
            this.txtEndCustomerCode = new System.Windows.Forms.TextBox();
            this.txtDepartualDateTo = new System.Windows.Forms.DateTimePicker();
            this.txtWarehouseCode = new System.Windows.Forms.TextBox();
            this.txtWarehouseName = new System.Windows.Forms.TextBox();
            this.pLeft_1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.pRight = new System.Windows.Forms.Panel();
            this.pRight_2 = new System.Windows.Forms.Panel();
            this.rdoNetPurchase = new System.Windows.Forms.RadioButton();
            this.rdoGrossPurchase = new System.Windows.Forms.RadioButton();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtOwnerPoNumber = new System.Windows.Forms.TextBox();
            this.pRight_1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOperate = new System.Windows.Forms.Button();
            this.btnPurchaseList = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.CHK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLIP_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SERIAL_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLIP_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTOMER_PO_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTOMER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ENDER_CUSTOMER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DELIVERY_POINT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WAREHOUSE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEPARTUAL_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UPDATED_COUNT = new System.Windows.Forms.DataGridViewLinkColumn();
            this.VERIFY_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHIPMENT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ALLOATION_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ATTACHED_NAME = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ATTACHED_FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ALLOATION_FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHIPMENT_FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VERIFY_FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMPANY_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pInfo.SuspendLayout();
            this.pLeft.SuspendLayout();
            this.pleft_2.SuspendLayout();
            this.pLeft_1.SuspendLayout();
            this.pRight.SuspendLayout();
            this.pRight_2.SuspendLayout();
            this.pRight_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // pInfo
            // 
            this.pInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pInfo.Controls.Add(this.btnAutoPurchase);
            this.pInfo.Controls.Add(this.pLeft);
            this.pInfo.Controls.Add(this.pRight);
            this.pInfo.Controls.Add(this.btnClose);
            this.pInfo.Controls.Add(this.btnOperate);
            this.pInfo.Controls.Add(this.btnPurchaseList);
            this.pInfo.Controls.Add(this.btnPrint);
            this.pInfo.Controls.Add(this.dgvData);
            this.pInfo.Location = new System.Drawing.Point(0, 0);
            this.pInfo.Name = "pInfo";
            this.pInfo.Size = new System.Drawing.Size(1024, 655);
            this.pInfo.TabIndex = 7;
            // 
            // btnAutoPurchase
            // 
            this.btnAutoPurchase.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnAutoPurchase.Location = new System.Drawing.Point(735, 621);
            this.btnAutoPurchase.Name = "btnAutoPurchase";
            this.btnAutoPurchase.Size = new System.Drawing.Size(90, 30);
            this.btnAutoPurchase.TabIndex = 9;
            this.btnAutoPurchase.Text = "自动采购";
            this.btnAutoPurchase.UseVisualStyleBackColor = true;
            this.btnAutoPurchase.Click += new System.EventHandler(this.btnAutoPurchase_Click);
            // 
            // pLeft
            // 
            this.pLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLeft.Controls.Add(this.pleft_2);
            this.pLeft.Controls.Add(this.pLeft_1);
            this.pLeft.Location = new System.Drawing.Point(3, 3);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(510, 245);
            this.pLeft.TabIndex = 8;
            // 
            // pleft_2
            // 
            this.pleft_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pleft_2.Controls.Add(this.label2);
            this.pleft_2.Controls.Add(this.btnEndCustomer);
            this.pleft_2.Controls.Add(this.label1);
            this.pleft_2.Controls.Add(this.btnWarehouse);
            this.pleft_2.Controls.Add(this.txtSlipNumber);
            this.pleft_2.Controls.Add(this.txtEndCustomerName);
            this.pleft_2.Controls.Add(this.txtSlipDateTo);
            this.pleft_2.Controls.Add(this.txtCustomerPoNumber);
            this.pleft_2.Controls.Add(this.txtSlipDateFrom);
            this.pleft_2.Controls.Add(this.txtDepartualDateFrom);
            this.pleft_2.Controls.Add(this.txtEndCustomerCode);
            this.pleft_2.Controls.Add(this.txtDepartualDateTo);
            this.pleft_2.Controls.Add(this.txtWarehouseCode);
            this.pleft_2.Controls.Add(this.txtWarehouseName);
            this.pleft_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pleft_2.Location = new System.Drawing.Point(120, 0);
            this.pleft_2.Name = "pleft_2";
            this.pleft_2.Size = new System.Drawing.Size(388, 243);
            this.pleft_2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(118, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "~";
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
            this.btnEndCustomer.Location = new System.Drawing.Point(260, 35);
            this.btnEndCustomer.Name = "btnEndCustomer";
            this.btnEndCustomer.Size = new System.Drawing.Size(25, 25);
            this.btnEndCustomer.TabIndex = 5;
            this.btnEndCustomer.UseVisualStyleBackColor = true;
            this.btnEndCustomer.Click += new System.EventHandler(this.btnEndCustomer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(119, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "~";
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
            this.btnWarehouse.Location = new System.Drawing.Point(260, 94);
            this.btnWarehouse.Name = "btnWarehouse";
            this.btnWarehouse.Size = new System.Drawing.Size(25, 25);
            this.btnWarehouse.TabIndex = 9;
            this.btnWarehouse.UseVisualStyleBackColor = true;
            this.btnWarehouse.Click += new System.EventHandler(this.btnWarehouse_Click);
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
            // txtEndCustomerName
            // 
            this.txtEndCustomerName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtEndCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEndCustomerName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtEndCustomerName.Location = new System.Drawing.Point(5, 65);
            this.txtEndCustomerName.Name = "txtEndCustomerName";
            this.txtEndCustomerName.Size = new System.Drawing.Size(250, 25);
            this.txtEndCustomerName.TabIndex = 6;
            // 
            // txtSlipDateTo
            // 
            this.txtSlipDateTo.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.txtSlipDateTo.Checked = false;
            this.txtSlipDateTo.CustomFormat = "yyyy-MM-dd";
            this.txtSlipDateTo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSlipDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtSlipDateTo.Location = new System.Drawing.Point(141, 188);
            this.txtSlipDateTo.Name = "txtSlipDateTo";
            this.txtSlipDateTo.ShowCheckBox = true;
            this.txtSlipDateTo.Size = new System.Drawing.Size(113, 23);
            this.txtSlipDateTo.TabIndex = 10;
            // 
            // txtCustomerPoNumber
            // 
            this.txtCustomerPoNumber.BackColor = System.Drawing.SystemColors.Info;
            this.txtCustomerPoNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerPoNumber.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCustomerPoNumber.Location = new System.Drawing.Point(5, 157);
            this.txtCustomerPoNumber.Name = "txtCustomerPoNumber";
            this.txtCustomerPoNumber.Size = new System.Drawing.Size(250, 25);
            this.txtCustomerPoNumber.TabIndex = 1;
            // 
            // txtSlipDateFrom
            // 
            this.txtSlipDateFrom.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.txtSlipDateFrom.Checked = false;
            this.txtSlipDateFrom.CustomFormat = "yyyy-MM-dd";
            this.txtSlipDateFrom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSlipDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtSlipDateFrom.Location = new System.Drawing.Point(5, 188);
            this.txtSlipDateFrom.Name = "txtSlipDateFrom";
            this.txtSlipDateFrom.ShowCheckBox = true;
            this.txtSlipDateFrom.Size = new System.Drawing.Size(113, 23);
            this.txtSlipDateFrom.TabIndex = 8;
            // 
            // txtDepartualDateFrom
            // 
            this.txtDepartualDateFrom.CalendarFont = new System.Drawing.Font("微软雅黑", 10F);
            this.txtDepartualDateFrom.Checked = false;
            this.txtDepartualDateFrom.CustomFormat = "yyyy-MM-dd";
            this.txtDepartualDateFrom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDepartualDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDepartualDateFrom.Location = new System.Drawing.Point(5, 218);
            this.txtDepartualDateFrom.Name = "txtDepartualDateFrom";
            this.txtDepartualDateFrom.ShowCheckBox = true;
            this.txtDepartualDateFrom.Size = new System.Drawing.Size(113, 23);
            this.txtDepartualDateFrom.TabIndex = 11;
            // 
            // txtEndCustomerCode
            // 
            this.txtEndCustomerCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtEndCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEndCustomerCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtEndCustomerCode.Location = new System.Drawing.Point(5, 35);
            this.txtEndCustomerCode.Name = "txtEndCustomerCode";
            this.txtEndCustomerCode.Size = new System.Drawing.Size(250, 25);
            this.txtEndCustomerCode.TabIndex = 4;
            this.txtEndCustomerCode.Leave += new System.EventHandler(this.txtEndCustomerCode_Leave);
            // 
            // txtDepartualDateTo
            // 
            this.txtDepartualDateTo.CalendarFont = new System.Drawing.Font("微软雅黑", 10F);
            this.txtDepartualDateTo.Checked = false;
            this.txtDepartualDateTo.CustomFormat = "yyyy-MM-dd";
            this.txtDepartualDateTo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDepartualDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDepartualDateTo.Location = new System.Drawing.Point(142, 218);
            this.txtDepartualDateTo.Name = "txtDepartualDateTo";
            this.txtDepartualDateTo.ShowCheckBox = true;
            this.txtDepartualDateTo.Size = new System.Drawing.Size(113, 23);
            this.txtDepartualDateTo.TabIndex = 13;
            // 
            // txtWarehouseCode
            // 
            this.txtWarehouseCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtWarehouseCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWarehouseCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtWarehouseCode.Location = new System.Drawing.Point(5, 96);
            this.txtWarehouseCode.Name = "txtWarehouseCode";
            this.txtWarehouseCode.Size = new System.Drawing.Size(250, 25);
            this.txtWarehouseCode.TabIndex = 4;
            this.txtWarehouseCode.Leave += new System.EventHandler(this.txtWarehouseCode_Leave);
            // 
            // txtWarehouseName
            // 
            this.txtWarehouseName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtWarehouseName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWarehouseName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtWarehouseName.Location = new System.Drawing.Point(5, 126);
            this.txtWarehouseName.Name = "txtWarehouseName";
            this.txtWarehouseName.Size = new System.Drawing.Size(250, 25);
            this.txtWarehouseName.TabIndex = 5;
            // 
            // pLeft_1
            // 
            this.pLeft_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pLeft_1.Controls.Add(this.label5);
            this.pLeft_1.Controls.Add(this.label17);
            this.pLeft_1.Controls.Add(this.label8);
            this.pLeft_1.Controls.Add(this.label12);
            this.pLeft_1.Controls.Add(this.label16);
            this.pLeft_1.Controls.Add(this.label14);
            this.pLeft_1.Controls.Add(this.label7);
            this.pLeft_1.Controls.Add(this.label20);
            this.pLeft_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeft_1.Location = new System.Drawing.Point(0, 0);
            this.pLeft_1.Name = "pLeft_1";
            this.pLeft_1.Size = new System.Drawing.Size(120, 243);
            this.pLeft_1.TabIndex = 4;
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
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label17.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(5, 184);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(110, 20);
            this.label17.TabIndex = 0;
            this.label17.Text = "  订单日期";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(5, 214);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "  预定出库日期";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(5, 155);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 20);
            this.label12.TabIndex = 0;
            this.label12.Text = "  合同编号";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(5, 126);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(110, 20);
            this.label16.TabIndex = 0;
            this.label16.Text = "  仓库名称";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(5, 65);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(110, 20);
            this.label14.TabIndex = 0;
            this.label14.Text = "  客户名称";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(5, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "  客户编号";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label20.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(5, 96);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(110, 20);
            this.label20.TabIndex = 0;
            this.label20.Text = "  出库仓库";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pRight
            // 
            this.pRight.BackColor = System.Drawing.Color.Transparent;
            this.pRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pRight.Controls.Add(this.pRight_2);
            this.pRight.Controls.Add(this.pRight_1);
            this.pRight.Location = new System.Drawing.Point(515, 3);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(500, 245);
            this.pRight.TabIndex = 7;
            // 
            // pRight_2
            // 
            this.pRight_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pRight_2.Controls.Add(this.rdoNetPurchase);
            this.pRight_2.Controls.Add(this.rdoGrossPurchase);
            this.pRight_2.Controls.Add(this.btnSearch);
            this.pRight_2.Controls.Add(this.txtOwnerPoNumber);
            this.pRight_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRight_2.Location = new System.Drawing.Point(120, 0);
            this.pRight_2.Name = "pRight_2";
            this.pRight_2.Size = new System.Drawing.Size(378, 243);
            this.pRight_2.TabIndex = 4;
            // 
            // rdoNetPurchase
            // 
            this.rdoNetPurchase.AutoSize = true;
            this.rdoNetPurchase.Location = new System.Drawing.Point(138, 36);
            this.rdoNetPurchase.Name = "rdoNetPurchase";
            this.rdoNetPurchase.Size = new System.Drawing.Size(69, 24);
            this.rdoNetPurchase.TabIndex = 8;
            this.rdoNetPurchase.Text = "净采购";
            this.rdoNetPurchase.UseVisualStyleBackColor = true;
            // 
            // rdoGrossPurchase
            // 
            this.rdoGrossPurchase.AutoSize = true;
            this.rdoGrossPurchase.Checked = true;
            this.rdoGrossPurchase.Location = new System.Drawing.Point(22, 35);
            this.rdoGrossPurchase.Name = "rdoGrossPurchase";
            this.rdoGrossPurchase.Size = new System.Drawing.Size(69, 24);
            this.rdoGrossPurchase.TabIndex = 7;
            this.rdoGrossPurchase.TabStop = true;
            this.rdoGrossPurchase.Text = "毛采购";
            this.rdoGrossPurchase.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSearch.Location = new System.Drawing.Point(286, 212);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 30);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "查　询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtOwnerPoNumber
            // 
            this.txtOwnerPoNumber.BackColor = System.Drawing.SystemColors.Info;
            this.txtOwnerPoNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOwnerPoNumber.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtOwnerPoNumber.Location = new System.Drawing.Point(5, 5);
            this.txtOwnerPoNumber.Name = "txtOwnerPoNumber";
            this.txtOwnerPoNumber.Size = new System.Drawing.Size(250, 25);
            this.txtOwnerPoNumber.TabIndex = 0;
            // 
            // pRight_1
            // 
            this.pRight_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pRight_1.Controls.Add(this.label3);
            this.pRight_1.Controls.Add(this.label10);
            this.pRight_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pRight_1.Location = new System.Drawing.Point(0, 0);
            this.pRight_1.Name = "pRight_1";
            this.pRight_1.Size = new System.Drawing.Size(120, 243);
            this.pRight_1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 61;
            this.label3.Text = "  自动采购区分";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(5, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "  公司订单编号";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnClose.Location = new System.Drawing.Point(925, 621);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 30);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关　闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOperate
            // 
            this.btnOperate.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnOperate.Location = new System.Drawing.Point(830, 621);
            this.btnOperate.Name = "btnOperate";
            this.btnOperate.Size = new System.Drawing.Size(90, 30);
            this.btnOperate.TabIndex = 3;
            this.btnOperate.Text = "详细确认";
            this.btnOperate.UseVisualStyleBackColor = true;
            this.btnOperate.Click += new System.EventHandler(this.btnOperate_Click);
            // 
            // btnPurchaseList
            // 
            this.btnPurchaseList.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnPurchaseList.Location = new System.Drawing.Point(3, 621);
            this.btnPurchaseList.Name = "btnPurchaseList";
            this.btnPurchaseList.Size = new System.Drawing.Size(90, 30);
            this.btnPurchaseList.TabIndex = 2;
            this.btnPurchaseList.Text = "采购清单";
            this.btnPurchaseList.UseVisualStyleBackColor = true;
            this.btnPurchaseList.Visible = false;
            this.btnPurchaseList.Click += new System.EventHandler(this.btnPurchaseList_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnPrint.Location = new System.Drawing.Point(620, 621);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(110, 30);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "生产物料清单";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvData.ColumnHeadersHeight = 25;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CHK,
            this.No,
            this.SLIP_NUMBER,
            this.SERIAL_NUMBER,
            this.SLIP_DATE,
            this.CUSTOMER_PO_NUMBER,
            this.CUSTOMER_NAME,
            this.ENDER_CUSTOMER_NAME,
            this.DELIVERY_POINT_NAME,
            this.WAREHOUSE_NAME,
            this.DEPARTUAL_DATE,
            this.UPDATED_COUNT,
            this.VERIFY_NAME,
            this.SHIPMENT_NAME,
            this.ALLOATION_NAME,
            this.ATTACHED_NAME,
            this.ATTACHED_FLAG,
            this.ALLOATION_FLAG,
            this.SHIPMENT_FLAG,
            this.VERIFY_FLAG,
            this.COMPANY_CODE});
            this.dgvData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(3, 250);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 45;
            this.dgvData.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1012, 370);
            this.dgvData.TabIndex = 0;
            this.dgvData.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvData_RowStateChanged);
            // 
            // CHK
            // 
            this.CHK.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CHK.DataPropertyName = "CHK";
            this.CHK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CHK.Frozen = true;
            this.CHK.HeaderText = "选择";
            this.CHK.Name = "CHK";
            this.CHK.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CHK.Width = 45;
            // 
            // No
            // 
            this.No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.No.DataPropertyName = "No";
            dataGridViewCellStyle2.Format = "yyyy-MM-dd";
            dataGridViewCellStyle2.NullValue = null;
            this.No.DefaultCellStyle = dataGridViewCellStyle2;
            this.No.Frozen = true;
            this.No.HeaderText = "No.";
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
            this.SLIP_NUMBER.HeaderText = "订单编号";
            this.SLIP_NUMBER.Name = "SLIP_NUMBER";
            this.SLIP_NUMBER.ReadOnly = true;
            this.SLIP_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SLIP_NUMBER.Width = 150;
            // 
            // SERIAL_NUMBER
            // 
            this.SERIAL_NUMBER.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SERIAL_NUMBER.DataPropertyName = "SERIAL_NUMBER";
            this.SERIAL_NUMBER.Frozen = true;
            this.SERIAL_NUMBER.HeaderText = "机械番号";
            this.SERIAL_NUMBER.Name = "SERIAL_NUMBER";
            this.SERIAL_NUMBER.ReadOnly = true;
            this.SERIAL_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SERIAL_NUMBER.Visible = false;
            // 
            // SLIP_DATE
            // 
            this.SLIP_DATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SLIP_DATE.DataPropertyName = "SLIP_DATE";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "yyyy-MM-dd";
            dataGridViewCellStyle3.NullValue = null;
            this.SLIP_DATE.DefaultCellStyle = dataGridViewCellStyle3;
            this.SLIP_DATE.Frozen = true;
            this.SLIP_DATE.HeaderText = "订单日期";
            this.SLIP_DATE.Name = "SLIP_DATE";
            this.SLIP_DATE.ReadOnly = true;
            this.SLIP_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SLIP_DATE.Width = 120;
            // 
            // CUSTOMER_PO_NUMBER
            // 
            this.CUSTOMER_PO_NUMBER.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CUSTOMER_PO_NUMBER.DataPropertyName = "CUSTOMER_PO_NUMBER";
            this.CUSTOMER_PO_NUMBER.HeaderText = "合同编号";
            this.CUSTOMER_PO_NUMBER.Name = "CUSTOMER_PO_NUMBER";
            this.CUSTOMER_PO_NUMBER.ReadOnly = true;
            this.CUSTOMER_PO_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CUSTOMER_PO_NUMBER.Width = 120;
            // 
            // CUSTOMER_NAME
            // 
            this.CUSTOMER_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CUSTOMER_NAME.DataPropertyName = "CUSTOMER_NAME";
            this.CUSTOMER_NAME.HeaderText = "代理店";
            this.CUSTOMER_NAME.Name = "CUSTOMER_NAME";
            this.CUSTOMER_NAME.ReadOnly = true;
            this.CUSTOMER_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CUSTOMER_NAME.Visible = false;
            this.CUSTOMER_NAME.Width = 150;
            // 
            // ENDER_CUSTOMER_NAME
            // 
            this.ENDER_CUSTOMER_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ENDER_CUSTOMER_NAME.DataPropertyName = "ENDER_CUSTOMER_NAME";
            this.ENDER_CUSTOMER_NAME.HeaderText = "客户名称";
            this.ENDER_CUSTOMER_NAME.Name = "ENDER_CUSTOMER_NAME";
            this.ENDER_CUSTOMER_NAME.ReadOnly = true;
            this.ENDER_CUSTOMER_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ENDER_CUSTOMER_NAME.Width = 200;
            // 
            // DELIVERY_POINT_NAME
            // 
            this.DELIVERY_POINT_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DELIVERY_POINT_NAME.DataPropertyName = "DELIVERY_POINT_NAME";
            this.DELIVERY_POINT_NAME.HeaderText = "纳入先";
            this.DELIVERY_POINT_NAME.Name = "DELIVERY_POINT_NAME";
            this.DELIVERY_POINT_NAME.ReadOnly = true;
            this.DELIVERY_POINT_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DELIVERY_POINT_NAME.Visible = false;
            this.DELIVERY_POINT_NAME.Width = 150;
            // 
            // WAREHOUSE_NAME
            // 
            this.WAREHOUSE_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.WAREHOUSE_NAME.DataPropertyName = "WAREHOUSE_NAME";
            this.WAREHOUSE_NAME.HeaderText = "出库仓库";
            this.WAREHOUSE_NAME.Name = "WAREHOUSE_NAME";
            this.WAREHOUSE_NAME.ReadOnly = true;
            this.WAREHOUSE_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.WAREHOUSE_NAME.Width = 150;
            // 
            // DEPARTUAL_DATE
            // 
            this.DEPARTUAL_DATE.DataPropertyName = "DEPARTUAL_DATE";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "yyyy-MM-dd";
            dataGridViewCellStyle4.NullValue = null;
            this.DEPARTUAL_DATE.DefaultCellStyle = dataGridViewCellStyle4;
            this.DEPARTUAL_DATE.HeaderText = "预定出库日期";
            this.DEPARTUAL_DATE.Name = "DEPARTUAL_DATE";
            this.DEPARTUAL_DATE.ReadOnly = true;
            this.DEPARTUAL_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // UPDATED_COUNT
            // 
            this.UPDATED_COUNT.DataPropertyName = "UPDATED_COUNT";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.UPDATED_COUNT.DefaultCellStyle = dataGridViewCellStyle5;
            this.UPDATED_COUNT.HeaderText = "更新回数";
            this.UPDATED_COUNT.Name = "UPDATED_COUNT";
            this.UPDATED_COUNT.ReadOnly = true;
            this.UPDATED_COUNT.Visible = false;
            this.UPDATED_COUNT.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // VERIFY_NAME
            // 
            this.VERIFY_NAME.DataPropertyName = "VERIFY_NAME";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.VERIFY_NAME.DefaultCellStyle = dataGridViewCellStyle6;
            this.VERIFY_NAME.HeaderText = "承认状况";
            this.VERIFY_NAME.Name = "VERIFY_NAME";
            this.VERIFY_NAME.ReadOnly = true;
            this.VERIFY_NAME.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.VERIFY_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.VERIFY_NAME.Visible = false;
            // 
            // SHIPMENT_NAME
            // 
            this.SHIPMENT_NAME.DataPropertyName = "SHIPMENT_NAME";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SHIPMENT_NAME.DefaultCellStyle = dataGridViewCellStyle7;
            this.SHIPMENT_NAME.HeaderText = "出荷状况";
            this.SHIPMENT_NAME.Name = "SHIPMENT_NAME";
            this.SHIPMENT_NAME.ReadOnly = true;
            this.SHIPMENT_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SHIPMENT_NAME.Visible = false;
            // 
            // ALLOATION_NAME
            // 
            this.ALLOATION_NAME.DataPropertyName = "ALLOATION_NAME";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ALLOATION_NAME.DefaultCellStyle = dataGridViewCellStyle8;
            this.ALLOATION_NAME.HeaderText = "引当状况";
            this.ALLOATION_NAME.Name = "ALLOATION_NAME";
            this.ALLOATION_NAME.ReadOnly = true;
            this.ALLOATION_NAME.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ALLOATION_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ALLOATION_NAME.Visible = false;
            // 
            // ATTACHED_NAME
            // 
            this.ATTACHED_NAME.DataPropertyName = "ATTACHED_NAME";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ATTACHED_NAME.DefaultCellStyle = dataGridViewCellStyle9;
            this.ATTACHED_NAME.HeaderText = "添付资料";
            this.ATTACHED_NAME.Name = "ATTACHED_NAME";
            this.ATTACHED_NAME.ReadOnly = true;
            this.ATTACHED_NAME.Visible = false;
            this.ATTACHED_NAME.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // ATTACHED_FLAG
            // 
            this.ATTACHED_FLAG.DataPropertyName = "ATTACHED_FLAG";
            this.ATTACHED_FLAG.HeaderText = "ATTACHED_FLAG";
            this.ATTACHED_FLAG.Name = "ATTACHED_FLAG";
            this.ATTACHED_FLAG.ReadOnly = true;
            this.ATTACHED_FLAG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ATTACHED_FLAG.Visible = false;
            // 
            // ALLOATION_FLAG
            // 
            this.ALLOATION_FLAG.DataPropertyName = "ALLOATION_FLAG";
            this.ALLOATION_FLAG.HeaderText = "ALLOATION_FLAG";
            this.ALLOATION_FLAG.Name = "ALLOATION_FLAG";
            this.ALLOATION_FLAG.ReadOnly = true;
            this.ALLOATION_FLAG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ALLOATION_FLAG.Visible = false;
            // 
            // SHIPMENT_FLAG
            // 
            this.SHIPMENT_FLAG.DataPropertyName = "SHIPMENT_FLAG";
            this.SHIPMENT_FLAG.HeaderText = "SHIPMENT_FLAG";
            this.SHIPMENT_FLAG.Name = "SHIPMENT_FLAG";
            this.SHIPMENT_FLAG.ReadOnly = true;
            this.SHIPMENT_FLAG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SHIPMENT_FLAG.Visible = false;
            // 
            // VERIFY_FLAG
            // 
            this.VERIFY_FLAG.DataPropertyName = "VERIFY_FLAG";
            this.VERIFY_FLAG.HeaderText = "VERIFY_FLAG";
            this.VERIFY_FLAG.Name = "VERIFY_FLAG";
            this.VERIFY_FLAG.ReadOnly = true;
            this.VERIFY_FLAG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.VERIFY_FLAG.Visible = false;
            // 
            // COMPANY_CODE
            // 
            this.COMPANY_CODE.DataPropertyName = "COMPANY_CODE";
            this.COMPANY_CODE.HeaderText = "COMPANY_CODE";
            this.COMPANY_CODE.Name = "COMPANY_CODE";
            this.COMPANY_CODE.ReadOnly = true;
            this.COMPANY_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.COMPANY_CODE.Visible = false;
            // 
            // FrmCProduceBOM
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1029, 658);
            this.Controls.Add(this.pInfo);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCProduceBOM";
            this.Text = "生产物料清单";
            this.Load += new System.EventHandler(this.FrmCProduceBOM_Load);
            this.pInfo.ResumeLayout(false);
            this.pLeft.ResumeLayout(false);
            this.pleft_2.ResumeLayout(false);
            this.pleft_2.PerformLayout();
            this.pLeft_1.ResumeLayout(false);
            this.pRight.ResumeLayout(false);
            this.pRight_2.ResumeLayout(false);
            this.pRight_2.PerformLayout();
            this.pRight_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pInfo;
        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.Panel pleft_2;
        private System.Windows.Forms.Button btnEndCustomer;
        private System.Windows.Forms.TextBox txtSlipNumber;
        private System.Windows.Forms.TextBox txtEndCustomerName;
        private System.Windows.Forms.TextBox txtEndCustomerCode;
        private System.Windows.Forms.Panel pLeft_1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.Panel pRight_2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnWarehouse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtOwnerPoNumber;
        private System.Windows.Forms.TextBox txtCustomerPoNumber;
        private System.Windows.Forms.DateTimePicker txtSlipDateTo;
        private System.Windows.Forms.TextBox txtWarehouseName;
        private System.Windows.Forms.DateTimePicker txtSlipDateFrom;
        private System.Windows.Forms.TextBox txtWarehouseCode;
        private System.Windows.Forms.DateTimePicker txtDepartualDateFrom;
        private System.Windows.Forms.DateTimePicker txtDepartualDateTo;
        private System.Windows.Forms.Panel pRight_1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOperate;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnPurchaseList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CHK;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLIP_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn SERIAL_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLIP_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_PO_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ENDER_CUSTOMER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn DELIVERY_POINT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn WAREHOUSE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPARTUAL_DATE;
        private System.Windows.Forms.DataGridViewLinkColumn UPDATED_COUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn VERIFY_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn SHIPMENT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ALLOATION_NAME;
        private System.Windows.Forms.DataGridViewLinkColumn ATTACHED_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ATTACHED_FLAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn ALLOATION_FLAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn SHIPMENT_FLAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn VERIFY_FLAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMPANY_CODE;
        private System.Windows.Forms.Button btnAutoPurchase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdoNetPurchase;
        private System.Windows.Forms.RadioButton rdoGrossPurchase;
    }
}