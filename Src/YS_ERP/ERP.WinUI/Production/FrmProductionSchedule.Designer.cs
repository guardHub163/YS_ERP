namespace CZZD.ERP.WinUI
{
    partial class FrmProductionSchedule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProductionSchedule));
            this.pInfo = new System.Windows.Forms.Panel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PRODUCTION_STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDER_SLIP_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTOMER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLIP_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.END_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLIP_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLIP_TYPE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PLAN_START_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PLAN_END_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PSPP_ACTUAL_END_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHECK_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExprotExcel = new System.Windows.Forms.Button();
            this.btnDrExport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnDetails = new System.Windows.Forms.Button();
            this.pLeft = new System.Windows.Forms.Panel();
            this.pleft_2 = new System.Windows.Forms.Panel();
            this.btnSlipType = new System.Windows.Forms.Button();
            this.btnCustmer = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSlipDateTo = new System.Windows.Forms.DateTimePicker();
            this.txtSlipTypeName = new System.Windows.Forms.TextBox();
            this.txtCustmerName = new System.Windows.Forms.TextBox();
            this.txtSlipDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustmerCode = new System.Windows.Forms.TextBox();
            this.txtSlipType = new System.Windows.Forms.TextBox();
            this.txtOrderSlipNumber = new System.Windows.Forms.TextBox();
            this.pLeft_1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.pRight = new System.Windows.Forms.Panel();
            this.pRight_2 = new System.Windows.Forms.Panel();
            this.txtSales = new System.Windows.Forms.TextBox();
            this.btnSales = new System.Windows.Forms.Button();
            this.txtSalesCode = new System.Windows.Forms.TextBox();
            this.btnSlipNumber = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSlipNumber = new System.Windows.Forms.TextBox();
            this.pRight_1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pgControl = new CZZD.ERP.ComControls.PageControl();
            this.btnClose = new System.Windows.Forms.Button();
            this.pInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.pLeft.SuspendLayout();
            this.pleft_2.SuspendLayout();
            this.pLeft_1.SuspendLayout();
            this.pRight.SuspendLayout();
            this.pRight_2.SuspendLayout();
            this.pRight_1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pInfo
            // 
            this.pInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pInfo.Controls.Add(this.dgvData);
            this.pInfo.Controls.Add(this.btnExprotExcel);
            this.pInfo.Controls.Add(this.btnDrExport);
            this.pInfo.Controls.Add(this.btnExport);
            this.pInfo.Controls.Add(this.btnDetails);
            this.pInfo.Controls.Add(this.pLeft);
            this.pInfo.Controls.Add(this.pRight);
            this.pInfo.Controls.Add(this.pgControl);
            this.pInfo.Controls.Add(this.btnClose);
            this.pInfo.Location = new System.Drawing.Point(1, 3);
            this.pInfo.Name = "pInfo";
            this.pInfo.Size = new System.Drawing.Size(1024, 643);
            this.pInfo.TabIndex = 10;
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
            this.No,
            this.CHK,
            this.PRODUCTION_STATUS,
            this.ORDER_SLIP_NUMBER,
            this.CUSTOMER_NAME,
            this.SLIP_DATE,
            this.END_DATE,
            this.SLIP_NUMBER,
            this.SLIP_TYPE_NAME,
            this.PLAN_START_DATE,
            this.PLAN_END_DATE,
            this.PSPP_ACTUAL_END_TIME,
            this.CHECK_DATE});
            this.dgvData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(3, 189);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 45;
            this.dgvData.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1012, 377);
            this.dgvData.TabIndex = 0;
            this.dgvData.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvData_RowStateChanged);
            // 
            // No
            // 
            this.No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.No.DataPropertyName = "row";
            dataGridViewCellStyle2.NullValue = null;
            this.No.DefaultCellStyle = dataGridViewCellStyle2;
            this.No.Frozen = true;
            this.No.HeaderText = "No.";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.No.Width = 35;
            // 
            // CHK
            // 
            this.CHK.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CHK.Frozen = true;
            this.CHK.HeaderText = "选择";
            this.CHK.Name = "CHK";
            this.CHK.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CHK.Width = 45;
            // 
            // PRODUCTION_STATUS
            // 
            this.PRODUCTION_STATUS.DataPropertyName = "PRODUCTION_STATUS";
            this.PRODUCTION_STATUS.HeaderText = "生产状况";
            this.PRODUCTION_STATUS.Name = "PRODUCTION_STATUS";
            this.PRODUCTION_STATUS.ReadOnly = true;
            this.PRODUCTION_STATUS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ORDER_SLIP_NUMBER
            // 
            this.ORDER_SLIP_NUMBER.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ORDER_SLIP_NUMBER.DataPropertyName = "ORDER_SLIP_NUNBER";
            this.ORDER_SLIP_NUMBER.HeaderText = "订单编号";
            this.ORDER_SLIP_NUMBER.Name = "ORDER_SLIP_NUMBER";
            this.ORDER_SLIP_NUMBER.ReadOnly = true;
            this.ORDER_SLIP_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ORDER_SLIP_NUMBER.Width = 200;
            // 
            // CUSTOMER_NAME
            // 
            this.CUSTOMER_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CUSTOMER_NAME.DataPropertyName = "BC_NAME";
            dataGridViewCellStyle3.NullValue = null;
            this.CUSTOMER_NAME.DefaultCellStyle = dataGridViewCellStyle3;
            this.CUSTOMER_NAME.HeaderText = "客户名称";
            this.CUSTOMER_NAME.Name = "CUSTOMER_NAME";
            this.CUSTOMER_NAME.ReadOnly = true;
            this.CUSTOMER_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CUSTOMER_NAME.Width = 200;
            // 
            // SLIP_DATE
            // 
            this.SLIP_DATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SLIP_DATE.DataPropertyName = "OH_SLIP_DATE";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "yyyy-MM-dd";
            dataGridViewCellStyle4.NullValue = null;
            this.SLIP_DATE.DefaultCellStyle = dataGridViewCellStyle4;
            this.SLIP_DATE.HeaderText = "订单日期";
            this.SLIP_DATE.Name = "SLIP_DATE";
            this.SLIP_DATE.ReadOnly = true;
            this.SLIP_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SLIP_DATE.Width = 120;
            // 
            // END_DATE
            // 
            this.END_DATE.DataPropertyName = "DEPARTUAL_DATE";
            dataGridViewCellStyle5.Format = "yyyy-MM-dd";
            this.END_DATE.DefaultCellStyle = dataGridViewCellStyle5;
            this.END_DATE.HeaderText = "交货日期";
            this.END_DATE.Name = "END_DATE";
            this.END_DATE.ReadOnly = true;
            this.END_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SLIP_NUMBER
            // 
            this.SLIP_NUMBER.DataPropertyName = "SLIP_NUMBER";
            this.SLIP_NUMBER.HeaderText = "生产工单编号";
            this.SLIP_NUMBER.Name = "SLIP_NUMBER";
            this.SLIP_NUMBER.ReadOnly = true;
            this.SLIP_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SLIP_TYPE_NAME
            // 
            this.SLIP_TYPE_NAME.DataPropertyName = "ST_NAME";
            this.SLIP_TYPE_NAME.HeaderText = "模具种类";
            this.SLIP_TYPE_NAME.Name = "SLIP_TYPE_NAME";
            this.SLIP_TYPE_NAME.ReadOnly = true;
            this.SLIP_TYPE_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PLAN_START_DATE
            // 
            this.PLAN_START_DATE.DataPropertyName = "PLAN_START_DATE";
            this.PLAN_START_DATE.HeaderText = "计划开始时间";
            this.PLAN_START_DATE.Name = "PLAN_START_DATE";
            this.PLAN_START_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PLAN_START_DATE.Visible = false;
            // 
            // PLAN_END_DATE
            // 
            this.PLAN_END_DATE.DataPropertyName = "PLAN_END_DATE";
            this.PLAN_END_DATE.HeaderText = "计划结束时间";
            this.PLAN_END_DATE.Name = "PLAN_END_DATE";
            this.PLAN_END_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PLAN_END_DATE.Visible = false;
            // 
            // PSPP_ACTUAL_END_TIME
            // 
            this.PSPP_ACTUAL_END_TIME.DataPropertyName = "PSPP_ACTUAL_END_TIME";
            dataGridViewCellStyle6.Format = "yyyy-MM-dd";
            this.PSPP_ACTUAL_END_TIME.DefaultCellStyle = dataGridViewCellStyle6;
            this.PSPP_ACTUAL_END_TIME.HeaderText = "实际结束时间";
            this.PSPP_ACTUAL_END_TIME.Name = "PSPP_ACTUAL_END_TIME";
            this.PSPP_ACTUAL_END_TIME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PSPP_ACTUAL_END_TIME.Visible = false;
            // 
            // CHECK_DATE
            // 
            this.CHECK_DATE.DataPropertyName = "CHECK_DATE";
            dataGridViewCellStyle7.Format = "yyyy-MM-dd";
            this.CHECK_DATE.DefaultCellStyle = dataGridViewCellStyle7;
            this.CHECK_DATE.HeaderText = "通知时间";
            this.CHECK_DATE.Name = "CHECK_DATE";
            this.CHECK_DATE.ReadOnly = true;
            this.CHECK_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CHECK_DATE.Visible = false;
            // 
            // btnExprotExcel
            // 
            this.btnExprotExcel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnExprotExcel.Location = new System.Drawing.Point(525, 607);
            this.btnExprotExcel.Name = "btnExprotExcel";
            this.btnExprotExcel.Size = new System.Drawing.Size(105, 30);
            this.btnExprotExcel.TabIndex = 18;
            this.btnExprotExcel.Text = "生产进度导出";
            this.btnExprotExcel.UseVisualStyleBackColor = true;
            this.btnExprotExcel.Click += new System.EventHandler(this.btnExprotExcel_Click);
            // 
            // btnDrExport
            // 
            this.btnDrExport.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnDrExport.Location = new System.Drawing.Point(636, 607);
            this.btnDrExport.Name = "btnDrExport";
            this.btnDrExport.Size = new System.Drawing.Size(90, 30);
            this.btnDrExport.TabIndex = 17;
            this.btnDrExport.Text = "图纸导出";
            this.btnDrExport.UseVisualStyleBackColor = true;
            this.btnDrExport.Click += new System.EventHandler(this.btnDrExport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnExport.Location = new System.Drawing.Point(733, 607);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(90, 30);
            this.btnExport.TabIndex = 16;
            this.btnExport.Text = "工序导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnDetails
            // 
            this.btnDetails.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnDetails.Location = new System.Drawing.Point(829, 607);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(90, 30);
            this.btnDetails.TabIndex = 6;
            this.btnDetails.Text = "详　细";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // pLeft
            // 
            this.pLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLeft.Controls.Add(this.pleft_2);
            this.pLeft.Controls.Add(this.pLeft_1);
            this.pLeft.Location = new System.Drawing.Point(3, 3);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(510, 185);
            this.pLeft.TabIndex = 8;
            // 
            // pleft_2
            // 
            this.pleft_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pleft_2.Controls.Add(this.btnSlipType);
            this.pleft_2.Controls.Add(this.btnCustmer);
            this.pleft_2.Controls.Add(this.label2);
            this.pleft_2.Controls.Add(this.txtSlipDateTo);
            this.pleft_2.Controls.Add(this.txtSlipTypeName);
            this.pleft_2.Controls.Add(this.txtCustmerName);
            this.pleft_2.Controls.Add(this.txtSlipDate);
            this.pleft_2.Controls.Add(this.label1);
            this.pleft_2.Controls.Add(this.txtCustmerCode);
            this.pleft_2.Controls.Add(this.txtSlipType);
            this.pleft_2.Controls.Add(this.txtOrderSlipNumber);
            this.pleft_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pleft_2.Location = new System.Drawing.Point(120, 0);
            this.pleft_2.Name = "pleft_2";
            this.pleft_2.Size = new System.Drawing.Size(388, 183);
            this.pleft_2.TabIndex = 5;
            // 
            // btnSlipType
            // 
            this.btnSlipType.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnSlipType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSlipType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSlipType.FlatAppearance.BorderSize = 0;
            this.btnSlipType.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSlipType.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSlipType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSlipType.Location = new System.Drawing.Point(262, 125);
            this.btnSlipType.Name = "btnSlipType";
            this.btnSlipType.Size = new System.Drawing.Size(25, 25);
            this.btnSlipType.TabIndex = 19;
            this.btnSlipType.UseVisualStyleBackColor = true;
            this.btnSlipType.MouseLeave += new System.EventHandler(this.btnSlipType_MouseLeave);
            this.btnSlipType.Click += new System.EventHandler(this.btnSlipType_Click);
            this.btnSlipType.MouseEnter += new System.EventHandler(this.btnSlipType_MouseEnter);
            // 
            // btnCustmer
            // 
            this.btnCustmer.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnCustmer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCustmer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCustmer.FlatAppearance.BorderSize = 0;
            this.btnCustmer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCustmer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCustmer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustmer.Location = new System.Drawing.Point(262, 65);
            this.btnCustmer.Name = "btnCustmer";
            this.btnCustmer.Size = new System.Drawing.Size(25, 25);
            this.btnCustmer.TabIndex = 19;
            this.btnCustmer.UseVisualStyleBackColor = true;
            this.btnCustmer.MouseLeave += new System.EventHandler(this.btnCustmer_MouseLeave);
            this.btnCustmer.Click += new System.EventHandler(this.btnCustmer_Click);
            this.btnCustmer.MouseEnter += new System.EventHandler(this.btnCustmer_MouseEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(119, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 19);
            this.label2.TabIndex = 17;
            this.label2.Text = "~";
            // 
            // txtSlipDateTo
            // 
            this.txtSlipDateTo.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.txtSlipDateTo.Checked = false;
            this.txtSlipDateTo.CustomFormat = "yyyy-MM-dd";
            this.txtSlipDateTo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSlipDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtSlipDateTo.Location = new System.Drawing.Point(142, 36);
            this.txtSlipDateTo.Name = "txtSlipDateTo";
            this.txtSlipDateTo.ShowCheckBox = true;
            this.txtSlipDateTo.Size = new System.Drawing.Size(113, 23);
            this.txtSlipDateTo.TabIndex = 18;
            // 
            // txtSlipTypeName
            // 
            this.txtSlipTypeName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtSlipTypeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSlipTypeName.Enabled = false;
            this.txtSlipTypeName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSlipTypeName.Location = new System.Drawing.Point(5, 155);
            this.txtSlipTypeName.Name = "txtSlipTypeName";
            this.txtSlipTypeName.ReadOnly = true;
            this.txtSlipTypeName.Size = new System.Drawing.Size(250, 25);
            this.txtSlipTypeName.TabIndex = 0;
            // 
            // txtCustmerName
            // 
            this.txtCustmerName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCustmerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustmerName.Enabled = false;
            this.txtCustmerName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCustmerName.Location = new System.Drawing.Point(5, 95);
            this.txtCustmerName.Name = "txtCustmerName";
            this.txtCustmerName.ReadOnly = true;
            this.txtCustmerName.Size = new System.Drawing.Size(250, 25);
            this.txtCustmerName.TabIndex = 0;
            // 
            // txtSlipDate
            // 
            this.txtSlipDate.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.txtSlipDate.Checked = false;
            this.txtSlipDate.CustomFormat = "yyyy-MM-dd";
            this.txtSlipDate.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSlipDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtSlipDate.Location = new System.Drawing.Point(6, 36);
            this.txtSlipDate.Name = "txtSlipDate";
            this.txtSlipDate.ShowCheckBox = true;
            this.txtSlipDate.Size = new System.Drawing.Size(113, 23);
            this.txtSlipDate.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(121, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 19);
            this.label1.TabIndex = 15;
            // 
            // txtCustmerCode
            // 
            this.txtCustmerCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtCustmerCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustmerCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCustmerCode.Location = new System.Drawing.Point(5, 65);
            this.txtCustmerCode.Name = "txtCustmerCode";
            this.txtCustmerCode.Size = new System.Drawing.Size(250, 25);
            this.txtCustmerCode.TabIndex = 0;
            this.txtCustmerCode.Leave += new System.EventHandler(this.txtCustmerCode_Leave);
            // 
            // txtSlipType
            // 
            this.txtSlipType.BackColor = System.Drawing.SystemColors.Info;
            this.txtSlipType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSlipType.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSlipType.Location = new System.Drawing.Point(5, 125);
            this.txtSlipType.Name = "txtSlipType";
            this.txtSlipType.Size = new System.Drawing.Size(250, 25);
            this.txtSlipType.TabIndex = 0;
            this.txtSlipType.Leave += new System.EventHandler(this.txtSlipType_Leave);
            // 
            // txtOrderSlipNumber
            // 
            this.txtOrderSlipNumber.BackColor = System.Drawing.SystemColors.Info;
            this.txtOrderSlipNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderSlipNumber.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtOrderSlipNumber.Location = new System.Drawing.Point(5, 5);
            this.txtOrderSlipNumber.Name = "txtOrderSlipNumber";
            this.txtOrderSlipNumber.Size = new System.Drawing.Size(250, 25);
            this.txtOrderSlipNumber.TabIndex = 0;
            // 
            // pLeft_1
            // 
            this.pLeft_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pLeft_1.Controls.Add(this.label4);
            this.pLeft_1.Controls.Add(this.label5);
            this.pLeft_1.Controls.Add(this.label13);
            this.pLeft_1.Controls.Add(this.label9);
            this.pLeft_1.Controls.Add(this.label6);
            this.pLeft_1.Controls.Add(this.label17);
            this.pLeft_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeft_1.Location = new System.Drawing.Point(0, 0);
            this.pLeft_1.Name = "pLeft_1";
            this.pLeft_1.Size = new System.Drawing.Size(120, 183);
            this.pLeft_1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "模具种类";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label5.Text = "订单编号";
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
            this.label13.Text = "模具种类名称";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(5, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "客户名称";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label6.TabIndex = 0;
            this.label6.Text = "客户编号";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label17.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(3, 35);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(110, 20);
            this.label17.TabIndex = 0;
            this.label17.Text = "订单日期";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pRight
            // 
            this.pRight.BackColor = System.Drawing.Color.Transparent;
            this.pRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pRight.Controls.Add(this.pRight_2);
            this.pRight.Controls.Add(this.pRight_1);
            this.pRight.Location = new System.Drawing.Point(515, 3);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(500, 185);
            this.pRight.TabIndex = 7;
            // 
            // pRight_2
            // 
            this.pRight_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pRight_2.Controls.Add(this.txtSales);
            this.pRight_2.Controls.Add(this.btnSales);
            this.pRight_2.Controls.Add(this.txtSalesCode);
            this.pRight_2.Controls.Add(this.btnSlipNumber);
            this.pRight_2.Controls.Add(this.radioButton2);
            this.pRight_2.Controls.Add(this.radioButton3);
            this.pRight_2.Controls.Add(this.radioButton1);
            this.pRight_2.Controls.Add(this.btnSearch);
            this.pRight_2.Controls.Add(this.txtSlipNumber);
            this.pRight_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRight_2.Location = new System.Drawing.Point(120, 0);
            this.pRight_2.Name = "pRight_2";
            this.pRight_2.Size = new System.Drawing.Size(378, 183);
            this.pRight_2.TabIndex = 4;
            // 
            // txtSales
            // 
            this.txtSales.BackColor = System.Drawing.Color.Gainsboro;
            this.txtSales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSales.Enabled = false;
            this.txtSales.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSales.Location = new System.Drawing.Point(5, 95);
            this.txtSales.Name = "txtSales";
            this.txtSales.Size = new System.Drawing.Size(250, 25);
            this.txtSales.TabIndex = 23;
            // 
            // btnSales
            // 
            this.btnSales.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnSales.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSales.FlatAppearance.BorderSize = 0;
            this.btnSales.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSales.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSales.Location = new System.Drawing.Point(260, 65);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(25, 25);
            this.btnSales.TabIndex = 22;
            this.btnSales.UseVisualStyleBackColor = true;
            this.btnSales.MouseLeave += new System.EventHandler(this.btnSales_MouseLeave);
            this.btnSales.Click += new System.EventHandler(this.btnSales_Click);
            this.btnSales.MouseEnter += new System.EventHandler(this.btnSales_MouseEnter);
            // 
            // txtSalesCode
            // 
            this.txtSalesCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtSalesCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSalesCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSalesCode.Location = new System.Drawing.Point(5, 65);
            this.txtSalesCode.Name = "txtSalesCode";
            this.txtSalesCode.Size = new System.Drawing.Size(250, 25);
            this.txtSalesCode.TabIndex = 21;
            this.txtSalesCode.Leave += new System.EventHandler(this.txtSalesCode_Leave);
            // 
            // btnSlipNumber
            // 
            this.btnSlipNumber.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnSlipNumber.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSlipNumber.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSlipNumber.FlatAppearance.BorderSize = 0;
            this.btnSlipNumber.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSlipNumber.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSlipNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSlipNumber.Location = new System.Drawing.Point(260, 6);
            this.btnSlipNumber.Name = "btnSlipNumber";
            this.btnSlipNumber.Size = new System.Drawing.Size(25, 25);
            this.btnSlipNumber.TabIndex = 20;
            this.btnSlipNumber.UseVisualStyleBackColor = true;
            this.btnSlipNumber.MouseLeave += new System.EventHandler(this.btnSlipNumber_MouseLeave);
            this.btnSlipNumber.Click += new System.EventHandler(this.btnSlipNumber_Click);
            this.btnSlipNumber.MouseEnter += new System.EventHandler(this.btnSlipNumber_MouseEnter);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(100, 35);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 16);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "未延期";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(5, 35);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(47, 16);
            this.radioButton3.TabIndex = 7;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "全部";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(207, 35);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 16);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "延期";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSearch.Location = new System.Drawing.Point(285, 150);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 30);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "查　询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSlipNumber
            // 
            this.txtSlipNumber.BackColor = System.Drawing.SystemColors.Info;
            this.txtSlipNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSlipNumber.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSlipNumber.Location = new System.Drawing.Point(6, 5);
            this.txtSlipNumber.Name = "txtSlipNumber";
            this.txtSlipNumber.Size = new System.Drawing.Size(250, 25);
            this.txtSlipNumber.TabIndex = 0;
            // 
            // pRight_1
            // 
            this.pRight_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pRight_1.Controls.Add(this.label10);
            this.pRight_1.Controls.Add(this.label8);
            this.pRight_1.Controls.Add(this.label7);
            this.pRight_1.Controls.Add(this.label3);
            this.pRight_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pRight_1.Location = new System.Drawing.Point(0, 0);
            this.pRight_1.Name = "pRight_1";
            this.pRight_1.Size = new System.Drawing.Size(120, 183);
            this.pRight_1.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(5, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 20);
            this.label10.TabIndex = 2;
            this.label10.Text = "销售人";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(5, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "销售人编号";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label7.Text = "生产状况";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label3.TabIndex = 0;
            this.label3.Text = "生产工单编号";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pgControl
            // 
            this.pgControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pgControl.Location = new System.Drawing.Point(3, 572);
            this.pgControl.Name = "pgControl";
            this.pgControl.Size = new System.Drawing.Size(1012, 30);
            this.pgControl.TabIndex = 15;
            this.pgControl.TotalPage = 1;
            this.pgControl.PageChanged += new CZZD.ERP.ComControls.PageControl.BtnClickHandle(this.pgControl_PageChanged);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnClose.Location = new System.Drawing.Point(925, 607);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 30);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关　闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmProductionSchedule
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1027, 648);
            this.Controls.Add(this.pInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmProductionSchedule";
            this.Text = "生产进度查询";
            this.Load += new System.EventHandler(this.FrmProductionSchedule_Load);
            this.pInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.pLeft.ResumeLayout(false);
            this.pleft_2.ResumeLayout(false);
            this.pleft_2.PerformLayout();
            this.pLeft_1.ResumeLayout(false);
            this.pRight.ResumeLayout(false);
            this.pRight_2.ResumeLayout(false);
            this.pRight_2.PerformLayout();
            this.pRight_1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pInfo;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.Panel pleft_2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSlipType;
        private System.Windows.Forms.TextBox txtSlipNumber;
        private System.Windows.Forms.TextBox txtOrderSlipNumber;
        private System.Windows.Forms.Panel pLeft_1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.Panel pRight_2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtCustmerName;
        private System.Windows.Forms.Panel pRight_1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker txtSlipDateTo;
        private System.Windows.Forms.DateTimePicker txtSlipDate;
        private System.Windows.Forms.TextBox txtCustmerCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSlipType;
        private System.Windows.Forms.Button btnCustmer;
        private System.Windows.Forms.TextBox txtSlipTypeName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioButton3;
        private CZZD.ERP.ComControls.PageControl pgControl;
        private System.Windows.Forms.Button btnSlipNumber;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnDrExport;
        private System.Windows.Forms.Button btnExprotExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CHK;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCTION_STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDER_SLIP_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLIP_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn END_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLIP_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLIP_TYPE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PLAN_START_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PLAN_END_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PSPP_ACTUAL_END_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHECK_DATE;
        private System.Windows.Forms.Button btnSales;
        private System.Windows.Forms.TextBox txtSalesCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSales;
        private System.Windows.Forms.Label label10;
    }
}