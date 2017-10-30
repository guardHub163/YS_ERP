namespace CZZD.ERP.WinUI
{
    partial class FrmProductBuildSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProductBuildSearch));
            this.pInfo = new System.Windows.Forms.Panel();
            this.pLeft = new System.Windows.Forms.Panel();
            this.pleft_2 = new System.Windows.Forms.Panel();
            this.txtProductPartsName = new System.Windows.Forms.TextBox();
            this.btnWarehouse = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.txtWarehouseName = new System.Windows.Forms.TextBox();
            this.btnProductParts = new System.Windows.Forms.Button();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtWarehouse = new System.Windows.Forms.TextBox();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.txtProductParts = new System.Windows.Forms.TextBox();
            this.pLeft_1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pRight = new System.Windows.Forms.Panel();
            this.pRight_2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFormDateTo = new System.Windows.Forms.DateTimePicker();
            this.txtFormDateFrom = new System.Windows.Forms.DateTimePicker();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pRight_1 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOperate = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.Row = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLIP_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WAREHOUSE_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WAREHOUSE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_PARTS_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_PARTS_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BUILD_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pgControl = new CZZD.ERP.ComControls.PageControl();
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
            this.pInfo.Controls.Add(this.pLeft);
            this.pInfo.Controls.Add(this.pRight);
            this.pInfo.Controls.Add(this.btnClose);
            this.pInfo.Controls.Add(this.btnOperate);
            this.pInfo.Controls.Add(this.btnPrint);
            this.pInfo.Controls.Add(this.dgvData);
            this.pInfo.Controls.Add(this.pgControl);
            this.pInfo.Location = new System.Drawing.Point(0, 0);
            this.pInfo.Name = "pInfo";
            this.pInfo.Size = new System.Drawing.Size(1020, 655);
            this.pInfo.TabIndex = 8;
            // 
            // pLeft
            // 
            this.pLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLeft.Controls.Add(this.pleft_2);
            this.pLeft.Controls.Add(this.pLeft_1);
            this.pLeft.Location = new System.Drawing.Point(3, 3);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(505, 192);
            this.pLeft.TabIndex = 8;
            // 
            // pleft_2
            // 
            this.pleft_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pleft_2.Controls.Add(this.txtProductPartsName);
            this.pleft_2.Controls.Add(this.btnWarehouse);
            this.pleft_2.Controls.Add(this.btnProduct);
            this.pleft_2.Controls.Add(this.txtWarehouseName);
            this.pleft_2.Controls.Add(this.btnProductParts);
            this.pleft_2.Controls.Add(this.txtProductName);
            this.pleft_2.Controls.Add(this.txtWarehouse);
            this.pleft_2.Controls.Add(this.txtProduct);
            this.pleft_2.Controls.Add(this.txtProductParts);
            this.pleft_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pleft_2.Location = new System.Drawing.Point(120, 0);
            this.pleft_2.Name = "pleft_2";
            this.pleft_2.Size = new System.Drawing.Size(383, 190);
            this.pleft_2.TabIndex = 5;
            // 
            // txtProductPartsName
            // 
            this.txtProductPartsName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtProductPartsName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductPartsName.Enabled = false;
            this.txtProductPartsName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtProductPartsName.Location = new System.Drawing.Point(5, 155);
            this.txtProductPartsName.Name = "txtProductPartsName";
            this.txtProductPartsName.Size = new System.Drawing.Size(250, 25);
            this.txtProductPartsName.TabIndex = 0;
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
            this.btnWarehouse.Location = new System.Drawing.Point(261, 4);
            this.btnWarehouse.Name = "btnWarehouse";
            this.btnWarehouse.Size = new System.Drawing.Size(25, 25);
            this.btnWarehouse.TabIndex = 9;
            this.btnWarehouse.UseVisualStyleBackColor = true;
            this.btnWarehouse.Click += new System.EventHandler(this.btnWarehouse_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProduct.FlatAppearance.BorderSize = 0;
            this.btnProduct.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduct.Location = new System.Drawing.Point(261, 65);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(25, 25);
            this.btnProduct.TabIndex = 9;
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // txtWarehouseName
            // 
            this.txtWarehouseName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtWarehouseName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWarehouseName.Enabled = false;
            this.txtWarehouseName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtWarehouseName.Location = new System.Drawing.Point(5, 35);
            this.txtWarehouseName.Name = "txtWarehouseName";
            this.txtWarehouseName.Size = new System.Drawing.Size(250, 25);
            this.txtWarehouseName.TabIndex = 0;
            // 
            // btnProductParts
            // 
            this.btnProductParts.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnProductParts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProductParts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProductParts.FlatAppearance.BorderSize = 0;
            this.btnProductParts.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnProductParts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnProductParts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductParts.Location = new System.Drawing.Point(261, 123);
            this.btnProductParts.Name = "btnProductParts";
            this.btnProductParts.Size = new System.Drawing.Size(25, 25);
            this.btnProductParts.TabIndex = 9;
            this.btnProductParts.UseVisualStyleBackColor = true;
            this.btnProductParts.Click += new System.EventHandler(this.btnProductParts_Click);
            // 
            // txtProductName
            // 
            this.txtProductName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductName.Enabled = false;
            this.txtProductName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtProductName.Location = new System.Drawing.Point(5, 95);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(250, 25);
            this.txtProductName.TabIndex = 0;
            // 
            // txtWarehouse
            // 
            this.txtWarehouse.BackColor = System.Drawing.SystemColors.Info;
            this.txtWarehouse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWarehouse.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtWarehouse.Location = new System.Drawing.Point(5, 5);
            this.txtWarehouse.Name = "txtWarehouse";
            this.txtWarehouse.Size = new System.Drawing.Size(250, 25);
            this.txtWarehouse.TabIndex = 0;
            this.txtWarehouse.Leave += new System.EventHandler(this.txtWarehouseCode_Leave);
            // 
            // txtProduct
            // 
            this.txtProduct.BackColor = System.Drawing.SystemColors.Info;
            this.txtProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProduct.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtProduct.Location = new System.Drawing.Point(5, 65);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(250, 25);
            this.txtProduct.TabIndex = 0;
            this.txtProduct.Leave += new System.EventHandler(this.txtProductCode_Leave);
            // 
            // txtProductParts
            // 
            this.txtProductParts.BackColor = System.Drawing.SystemColors.Info;
            this.txtProductParts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductParts.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtProductParts.Location = new System.Drawing.Point(5, 125);
            this.txtProductParts.Name = "txtProductParts";
            this.txtProductParts.Size = new System.Drawing.Size(250, 25);
            this.txtProductParts.TabIndex = 0;
            this.txtProductParts.Leave += new System.EventHandler(this.txtProductParts_Leave);
            // 
            // pLeft_1
            // 
            this.pLeft_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pLeft_1.Controls.Add(this.label4);
            this.pLeft_1.Controls.Add(this.label5);
            this.pLeft_1.Controls.Add(this.label13);
            this.pLeft_1.Controls.Add(this.label6);
            this.pLeft_1.Controls.Add(this.label14);
            this.pLeft_1.Controls.Add(this.label7);
            this.pLeft_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeft_1.Location = new System.Drawing.Point(0, 0);
            this.pLeft_1.Name = "pLeft_1";
            this.pLeft_1.Size = new System.Drawing.Size(120, 190);
            this.pLeft_1.TabIndex = 4;
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
            this.label4.Text = "  仓库编号";
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
            this.label5.TabIndex = 0;
            this.label5.Text = "  仓库名称";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(5, 155);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(110, 20);
            this.label13.TabIndex = 0;
            this.label13.Text = "  材料商品名称";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label6.TabIndex = 0;
            this.label6.Text = "  材料商品编号";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label14.Text = "  组成品名称";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(5, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "  组成品编号";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pRight
            // 
            this.pRight.BackColor = System.Drawing.Color.Transparent;
            this.pRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pRight.Controls.Add(this.pRight_2);
            this.pRight.Controls.Add(this.pRight_1);
            this.pRight.Location = new System.Drawing.Point(510, 3);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(505, 192);
            this.pRight.TabIndex = 7;
            // 
            // pRight_2
            // 
            this.pRight_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pRight_2.Controls.Add(this.label9);
            this.pRight_2.Controls.Add(this.txtFormDateTo);
            this.pRight_2.Controls.Add(this.txtFormDateFrom);
            this.pRight_2.Controls.Add(this.txtQuantity);
            this.pRight_2.Controls.Add(this.btnSearch);
            this.pRight_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRight_2.Location = new System.Drawing.Point(120, 0);
            this.pRight_2.Name = "pRight_2";
            this.pRight_2.Size = new System.Drawing.Size(383, 190);
            this.pRight_2.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(123, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "~";
            this.label9.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtFormDateTo
            // 
            this.txtFormDateTo.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.txtFormDateTo.Checked = false;
            this.txtFormDateTo.CustomFormat = "yyyy-MM-dd";
            this.txtFormDateTo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtFormDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtFormDateTo.Location = new System.Drawing.Point(143, 35);
            this.txtFormDateTo.Name = "txtFormDateTo";
            this.txtFormDateTo.ShowCheckBox = true;
            this.txtFormDateTo.Size = new System.Drawing.Size(112, 23);
            this.txtFormDateTo.TabIndex = 11;
            // 
            // txtFormDateFrom
            // 
            this.txtFormDateFrom.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.txtFormDateFrom.Checked = false;
            this.txtFormDateFrom.CustomFormat = "yyyy-MM-dd";
            this.txtFormDateFrom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtFormDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtFormDateFrom.Location = new System.Drawing.Point(5, 35);
            this.txtFormDateFrom.Name = "txtFormDateFrom";
            this.txtFormDateFrom.ShowCheckBox = true;
            this.txtFormDateFrom.Size = new System.Drawing.Size(112, 23);
            this.txtFormDateFrom.TabIndex = 11;
            // 
            // txtQuantity
            // 
            this.txtQuantity.BackColor = System.Drawing.SystemColors.Info;
            this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuantity.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtQuantity.Location = new System.Drawing.Point(5, 5);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(250, 25);
            this.txtQuantity.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnSearch.Location = new System.Drawing.Point(290, 155);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 30);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "查　询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pRight_1
            // 
            this.pRight_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pRight_1.Controls.Add(this.label17);
            this.pRight_1.Controls.Add(this.label10);
            this.pRight_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pRight_1.Location = new System.Drawing.Point(0, 0);
            this.pRight_1.Name = "pRight_1";
            this.pRight_1.Size = new System.Drawing.Size(120, 190);
            this.pRight_1.TabIndex = 3;
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
            this.label17.TabIndex = 1;
            this.label17.Text = "  组成日期";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label10.Text = "  组成数量";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnClose.Location = new System.Drawing.Point(925, 620);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关　闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOperate
            // 
            this.btnOperate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOperate.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnOperate.Location = new System.Drawing.Point(829, 620);
            this.btnOperate.Name = "btnOperate";
            this.btnOperate.Size = new System.Drawing.Size(90, 30);
            this.btnOperate.TabIndex = 1;
            this.btnOperate.Text = "详　细";
            this.btnOperate.UseVisualStyleBackColor = true;
            this.btnOperate.Click += new System.EventHandler(this.btnOperate_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnPrint.Location = new System.Drawing.Point(733, 620);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(90, 30);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "导　出";
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
            this.dgvData.ColumnHeadersHeight = 26;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Row,
            this.SLIP_NUMBER,
            this.WAREHOUSE_CODE,
            this.WAREHOUSE_NAME,
            this.PRODUCT_CODE,
            this.PRODUCT_NAME,
            this.PRODUCT_PARTS_CODE,
            this.PRODUCT_PARTS_NAME,
            this.QUANTITY,
            this.BUILD_DATE});
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(3, 199);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 45;
            this.dgvData.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.dgvData.RowTemplate.Height = 25;
            this.dgvData.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1012, 385);
            this.dgvData.TabIndex = 3;
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
            this.Row.Width = 35;
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
            // WAREHOUSE_CODE
            // 
            this.WAREHOUSE_CODE.DataPropertyName = "WAREHOUSE_CODE";
            this.WAREHOUSE_CODE.HeaderText = "仓库编号";
            this.WAREHOUSE_CODE.Name = "WAREHOUSE_CODE";
            this.WAREHOUSE_CODE.ReadOnly = true;
            this.WAREHOUSE_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // WAREHOUSE_NAME
            // 
            this.WAREHOUSE_NAME.DataPropertyName = "WAREHOUSE_NAME";
            this.WAREHOUSE_NAME.HeaderText = "仓库名称";
            this.WAREHOUSE_NAME.Name = "WAREHOUSE_NAME";
            this.WAREHOUSE_NAME.ReadOnly = true;
            this.WAREHOUSE_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PRODUCT_CODE
            // 
            this.PRODUCT_CODE.DataPropertyName = "PRODUCT_CODE";
            this.PRODUCT_CODE.HeaderText = "组成品编号";
            this.PRODUCT_CODE.Name = "PRODUCT_CODE";
            this.PRODUCT_CODE.ReadOnly = true;
            this.PRODUCT_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PRODUCT_NAME
            // 
            this.PRODUCT_NAME.DataPropertyName = "PRODUCT_NAME";
            this.PRODUCT_NAME.HeaderText = "组成品名称";
            this.PRODUCT_NAME.Name = "PRODUCT_NAME";
            this.PRODUCT_NAME.ReadOnly = true;
            this.PRODUCT_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PRODUCT_PARTS_CODE
            // 
            this.PRODUCT_PARTS_CODE.DataPropertyName = "PRODUCT_PARTS_CODE";
            this.PRODUCT_PARTS_CODE.HeaderText = "材料商品编号";
            this.PRODUCT_PARTS_CODE.Name = "PRODUCT_PARTS_CODE";
            this.PRODUCT_PARTS_CODE.ReadOnly = true;
            this.PRODUCT_PARTS_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PRODUCT_PARTS_NAME
            // 
            this.PRODUCT_PARTS_NAME.DataPropertyName = "PRODUCT_PARTS_NAME";
            this.PRODUCT_PARTS_NAME.HeaderText = "材料商品名称";
            this.PRODUCT_PARTS_NAME.Name = "PRODUCT_PARTS_NAME";
            this.PRODUCT_PARTS_NAME.ReadOnly = true;
            this.PRODUCT_PARTS_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // QUANTITY
            // 
            this.QUANTITY.DataPropertyName = "QUANTITY";
            this.QUANTITY.HeaderText = "组成数量";
            this.QUANTITY.Name = "QUANTITY";
            this.QUANTITY.ReadOnly = true;
            this.QUANTITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // BUILD_DATE
            // 
            this.BUILD_DATE.DataPropertyName = "BUILD_DATE";
            dataGridViewCellStyle2.Format = "yyyy-MM-dd";
            this.BUILD_DATE.DefaultCellStyle = dataGridViewCellStyle2;
            this.BUILD_DATE.HeaderText = "组成日期";
            this.BUILD_DATE.Name = "BUILD_DATE";
            this.BUILD_DATE.ReadOnly = true;
            this.BUILD_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // pgControl
            // 
            this.pgControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pgControl.Location = new System.Drawing.Point(3, 587);
            this.pgControl.Name = "pgControl";
            this.pgControl.Size = new System.Drawing.Size(1012, 30);
            this.pgControl.TabIndex = 4;
            this.pgControl.TotalPage = 1;
            // 
            // FrmProductBuildSearch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1030, 668);
            this.Controls.Add(this.pInfo);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmProductBuildSearch";
            this.Text = "组成品组成查询";
            this.Load += new System.EventHandler(this.FrmProductBuildSearch_Load);
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
        private System.Windows.Forms.TextBox txtProductPartsName;
        private System.Windows.Forms.Button btnWarehouse;
        private System.Windows.Forms.Button btnProductParts;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.TextBox txtWarehouseName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtWarehouse;
        private System.Windows.Forms.TextBox txtProductParts;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Panel pLeft_1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.Panel pRight_2;
        private System.Windows.Forms.DateTimePicker txtFormDateFrom;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pRight_1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOperate;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dgvData;
        private CZZD.ERP.ComControls.PageControl pgControl;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker txtFormDateTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Row;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLIP_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn WAREHOUSE_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn WAREHOUSE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_PARTS_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_PARTS_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUANTITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn BUILD_DATE;
        private System.Windows.Forms.Label label9;
    }
}