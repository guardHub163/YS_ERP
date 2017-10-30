namespace CZZD.ERP.WinUI
{
    partial class FrmProductBuild
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProductBuild));
            this.pInfo = new System.Windows.Forms.Panel();
            this.pLeft = new System.Windows.Forms.Panel();
            this.pleft_2 = new System.Windows.Forms.Panel();
            this.btnWarehouse = new System.Windows.Forms.Button();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnProduct = new System.Windows.Forms.Button();
            this.txtPossibleQuantity = new System.Windows.Forms.TextBox();
            this.txtWarehouseName = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtWarehouse = new System.Windows.Forms.TextBox();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.pLeft_1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pRight = new System.Windows.Forms.Panel();
            this.pRight_2 = new System.Windows.Forms.Panel();
            this.txtFormDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pRight_1 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PARTS_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PARTS_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MIN_QUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PURCHASE_QUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NO_ALLOATION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNIT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUE_FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNIT_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.pInfo.BackColor = System.Drawing.Color.White;
            this.pInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pInfo.Controls.Add(this.pLeft);
            this.pInfo.Controls.Add(this.pRight);
            this.pInfo.Controls.Add(this.btnClose);
            this.pInfo.Controls.Add(this.btnSave);
            this.pInfo.Controls.Add(this.btnPrint);
            this.pInfo.Controls.Add(this.dgvData);
            this.pInfo.Controls.Add(this.pgControl);
            this.pInfo.Location = new System.Drawing.Point(0, 0);
            this.pInfo.Name = "pInfo";
            this.pInfo.Size = new System.Drawing.Size(1020, 660);
            this.pInfo.TabIndex = 7;
            // 
            // pLeft
            // 
            this.pLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLeft.Controls.Add(this.pleft_2);
            this.pLeft.Controls.Add(this.pLeft_1);
            this.pLeft.Location = new System.Drawing.Point(3, 3);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(510, 192);
            this.pLeft.TabIndex = 8;
            // 
            // pleft_2
            // 
            this.pleft_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pleft_2.Controls.Add(this.btnWarehouse);
            this.pleft_2.Controls.Add(this.txtQuantity);
            this.pleft_2.Controls.Add(this.btnProduct);
            this.pleft_2.Controls.Add(this.txtPossibleQuantity);
            this.pleft_2.Controls.Add(this.txtWarehouseName);
            this.pleft_2.Controls.Add(this.txtProductName);
            this.pleft_2.Controls.Add(this.txtWarehouse);
            this.pleft_2.Controls.Add(this.txtProduct);
            this.pleft_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pleft_2.Location = new System.Drawing.Point(120, 0);
            this.pleft_2.Name = "pleft_2";
            this.pleft_2.Size = new System.Drawing.Size(388, 190);
            this.pleft_2.TabIndex = 5;
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
            this.btnWarehouse.Location = new System.Drawing.Point(261, 5);
            this.btnWarehouse.Name = "btnWarehouse";
            this.btnWarehouse.Size = new System.Drawing.Size(25, 25);
            this.btnWarehouse.TabIndex = 9;
            this.btnWarehouse.UseVisualStyleBackColor = true;
            this.btnWarehouse.Click += new System.EventHandler(this.btnWarehouse_Click);
            // 
            // txtQuantity
            // 
            this.txtQuantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuantity.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtQuantity.Location = new System.Drawing.Point(5, 125);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(250, 25);
            this.txtQuantity.TabIndex = 0;
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOwnerPoNumber_KeyPress);
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
            // txtPossibleQuantity
            // 
            this.txtPossibleQuantity.BackColor = System.Drawing.Color.Gainsboro;
            this.txtPossibleQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPossibleQuantity.Enabled = false;
            this.txtPossibleQuantity.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtPossibleQuantity.Location = new System.Drawing.Point(5, 155);
            this.txtPossibleQuantity.Name = "txtPossibleQuantity";
            this.txtPossibleQuantity.Size = new System.Drawing.Size(250, 25);
            this.txtPossibleQuantity.TabIndex = 0;
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
            this.txtWarehouse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
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
            this.txtProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProduct.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtProduct.Location = new System.Drawing.Point(5, 65);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(250, 25);
            this.txtProduct.TabIndex = 0;
            this.txtProduct.Leave += new System.EventHandler(this.txtProductCode_Leave);
            // 
            // pLeft_1
            // 
            this.pLeft_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pLeft_1.Controls.Add(this.label4);
            this.pLeft_1.Controls.Add(this.label12);
            this.pLeft_1.Controls.Add(this.label10);
            this.pLeft_1.Controls.Add(this.label5);
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
            this.label12.Text = "  组成可能数";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(5, 125);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "  組成数量";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.pRight.Location = new System.Drawing.Point(515, 3);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(500, 192);
            this.pRight.TabIndex = 7;
            // 
            // pRight_2
            // 
            this.pRight_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pRight_2.Controls.Add(this.txtFormDate);
            this.pRight_2.Controls.Add(this.btnSearch);
            this.pRight_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRight_2.Location = new System.Drawing.Point(120, 0);
            this.pRight_2.Name = "pRight_2";
            this.pRight_2.Size = new System.Drawing.Size(378, 190);
            this.pRight_2.TabIndex = 4;
            // 
            // txtFormDate
            // 
            this.txtFormDate.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.txtFormDate.CustomFormat = "yyyy-MM-dd";
            this.txtFormDate.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtFormDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtFormDate.Location = new System.Drawing.Point(5, 5);
            this.txtFormDate.Name = "txtFormDate";
            this.txtFormDate.Size = new System.Drawing.Size(250, 23);
            this.txtFormDate.TabIndex = 11;
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnSearch.Location = new System.Drawing.Point(285, 156);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 30);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "计　算";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pRight_1
            // 
            this.pRight_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pRight_1.Controls.Add(this.label17);
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
            this.label17.Location = new System.Drawing.Point(5, 5);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(110, 20);
            this.label17.TabIndex = 1;
            this.label17.Text = "  组成日期";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnClose.Location = new System.Drawing.Point(925, 623);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关　闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnSave.Location = new System.Drawing.Point(829, 623);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保　存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnPrint.Location = new System.Drawing.Point(733, 623);
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.ColumnHeadersHeight = 28;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.PARTS_CODE,
            this.PARTS_NAME,
            this.SPEC,
            this.MIN_QUANTITY,
            this.PURCHASE_QUANTITY,
            this.NO_ALLOATION,
            this.UNIT_NAME,
            this.STATUE_FLAG,
            this.UNIT_CODE});
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
            // No
            // 
            this.No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.No.DataPropertyName = "No";
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.No.Width = 35;
            // 
            // PARTS_CODE
            // 
            this.PARTS_CODE.HeaderText = "材料商品编号";
            this.PARTS_CODE.Name = "PARTS_CODE";
            this.PARTS_CODE.ReadOnly = true;
            this.PARTS_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PARTS_NAME
            // 
            this.PARTS_NAME.HeaderText = "材料商品名称";
            this.PARTS_NAME.Name = "PARTS_NAME";
            this.PARTS_NAME.ReadOnly = true;
            this.PARTS_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SPEC
            // 
            this.SPEC.DataPropertyName = "SPEC";
            this.SPEC.HeaderText = "规格";
            this.SPEC.Name = "SPEC";
            this.SPEC.ReadOnly = true;
            this.SPEC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MIN_QUANTITY
            // 
            this.MIN_QUANTITY.DataPropertyName = "MIN_QUANTITY";
            this.MIN_QUANTITY.HeaderText = "最小购成数量";
            this.MIN_QUANTITY.Name = "MIN_QUANTITY";
            this.MIN_QUANTITY.ReadOnly = true;
            this.MIN_QUANTITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PURCHASE_QUANTITY
            // 
            this.PURCHASE_QUANTITY.DataPropertyName = "PURCHASE_QUANTITY";
            this.PURCHASE_QUANTITY.HeaderText = "需求数量";
            this.PURCHASE_QUANTITY.Name = "PURCHASE_QUANTITY";
            this.PURCHASE_QUANTITY.ReadOnly = true;
            this.PURCHASE_QUANTITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NO_ALLOATION
            // 
            this.NO_ALLOATION.DataPropertyName = "NO_ALLOATION";
            this.NO_ALLOATION.HeaderText = "未引当在库数量";
            this.NO_ALLOATION.Name = "NO_ALLOATION";
            this.NO_ALLOATION.ReadOnly = true;
            this.NO_ALLOATION.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // UNIT_NAME
            // 
            this.UNIT_NAME.DataPropertyName = "UNIT_NAME";
            this.UNIT_NAME.HeaderText = "单位";
            this.UNIT_NAME.Name = "UNIT_NAME";
            this.UNIT_NAME.ReadOnly = true;
            this.UNIT_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // STATUE_FLAG
            // 
            this.STATUE_FLAG.DataPropertyName = "STATUE_FLAG";
            this.STATUE_FLAG.HeaderText = "状况";
            this.STATUE_FLAG.Name = "STATUE_FLAG";
            this.STATUE_FLAG.ReadOnly = true;
            this.STATUE_FLAG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // UNIT_CODE
            // 
            this.UNIT_CODE.HeaderText = "UNIT_CODE";
            this.UNIT_CODE.Name = "UNIT_CODE";
            this.UNIT_CODE.ReadOnly = true;
            this.UNIT_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UNIT_CODE.Visible = false;
            // 
            // pgControl
            // 
            this.pgControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pgControl.Location = new System.Drawing.Point(3, 587);
            this.pgControl.Name = "pgControl";
            this.pgControl.Size = new System.Drawing.Size(1012, 30);
            this.pgControl.TabIndex = 4;
            this.pgControl.TotalPage = 1;
            this.pgControl.PageChanged += new CZZD.ERP.ComControls.PageControl.BtnClickHandle(this.pgControl_PageChanged);
            // 
            // FrmProductBuild
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1027, 678);
            this.Controls.Add(this.pInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmProductBuild";
            this.Text = "组成品组成输入";
            this.Load += new System.EventHandler(this.FrmProductBuild_Load);
            this.pInfo.ResumeLayout(false);
            this.pLeft.ResumeLayout(false);
            this.pleft_2.ResumeLayout(false);
            this.pleft_2.PerformLayout();
            this.pLeft_1.ResumeLayout(false);
            this.pRight.ResumeLayout(false);
            this.pRight_2.ResumeLayout(false);
            this.pRight_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pInfo;
        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.Panel pleft_2;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.TextBox txtWarehouseName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Panel pLeft_1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.Panel pRight_2;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtPossibleQuantity;
        private System.Windows.Forms.Panel pRight_1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dgvData;
        private CZZD.ERP.ComControls.PageControl pgControl;
        private System.Windows.Forms.Button btnWarehouse;
        private System.Windows.Forms.TextBox txtWarehouse;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker txtFormDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn PARTS_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PARTS_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPEC;
        private System.Windows.Forms.DataGridViewTextBoxColumn MIN_QUANTITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn PURCHASE_QUANTITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn NO_ALLOATION;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNIT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATUE_FLAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNIT_CODE;
    }
}