namespace CZZD.ERP.WinUI
{
    partial class FrmAlloation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAlloation));
            this.pInfo = new System.Windows.Forms.Panel();
            this.pLeft = new System.Windows.Forms.Panel();
            this.pleft_2 = new System.Windows.Forms.Panel();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtSlipNumber = new System.Windows.Forms.TextBox();
            this.txtEndCustomerName = new System.Windows.Forms.TextBox();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.txtEndCustomerCode = new System.Windows.Forms.TextBox();
            this.txtDeliveryPointName = new System.Windows.Forms.TextBox();
            this.txtDeliveryPointCode = new System.Windows.Forms.TextBox();
            this.pLeft_1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.pRight = new System.Windows.Forms.Panel();
            this.pRight_2 = new System.Windows.Forms.Panel();
            this.txtOwnerPoNumber = new System.Windows.Forms.TextBox();
            this.txtDepartualDate = new System.Windows.Forms.TextBox();
            this.txtSlipDate = new System.Windows.Forms.TextBox();
            this.pRight_1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAlloation = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_SPEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNIT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEPARTUAL_WAREHOUSE = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.REF_STOCK = new System.Windows.Forms.DataGridViewLinkColumn();
            this.STOCK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ALLOATION_QUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IS_ALLOATION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNIT_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDER_LINE_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDER_SLIP_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEFAULT_WAREHOUSE_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.pInfo.Controls.Add(this.btnAlloation);
            this.pInfo.Controls.Add(this.dgvData);
            this.pInfo.Location = new System.Drawing.Point(0, 0);
            this.pInfo.Name = "pInfo";
            this.pInfo.Size = new System.Drawing.Size(1024, 655);
            this.pInfo.TabIndex = 7;
            // 
            // pLeft
            // 
            this.pLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLeft.Controls.Add(this.pleft_2);
            this.pLeft.Controls.Add(this.pLeft_1);
            this.pLeft.Location = new System.Drawing.Point(3, 3);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(510, 218);
            this.pLeft.TabIndex = 8;
            // 
            // pleft_2
            // 
            this.pleft_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pleft_2.Controls.Add(this.txtCustomerName);
            this.pleft_2.Controls.Add(this.txtSlipNumber);
            this.pleft_2.Controls.Add(this.txtEndCustomerName);
            this.pleft_2.Controls.Add(this.txtCustomerCode);
            this.pleft_2.Controls.Add(this.txtEndCustomerCode);
            this.pleft_2.Controls.Add(this.txtDeliveryPointName);
            this.pleft_2.Controls.Add(this.txtDeliveryPointCode);
            this.pleft_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pleft_2.Location = new System.Drawing.Point(120, 0);
            this.pleft_2.Name = "pleft_2";
            this.pleft_2.Size = new System.Drawing.Size(388, 216);
            this.pleft_2.TabIndex = 5;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerName.Enabled = false;
            this.txtCustomerName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCustomerName.Location = new System.Drawing.Point(5, 64);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(250, 25);
            this.txtCustomerName.TabIndex = 0;
            // 
            // txtSlipNumber
            // 
            this.txtSlipNumber.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSlipNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSlipNumber.Enabled = false;
            this.txtSlipNumber.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSlipNumber.Location = new System.Drawing.Point(5, 5);
            this.txtSlipNumber.Name = "txtSlipNumber";
            this.txtSlipNumber.Size = new System.Drawing.Size(250, 25);
            this.txtSlipNumber.TabIndex = 0;
            // 
            // txtEndCustomerName
            // 
            this.txtEndCustomerName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtEndCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEndCustomerName.Enabled = false;
            this.txtEndCustomerName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtEndCustomerName.Location = new System.Drawing.Point(5, 126);
            this.txtEndCustomerName.Name = "txtEndCustomerName";
            this.txtEndCustomerName.Size = new System.Drawing.Size(250, 25);
            this.txtEndCustomerName.TabIndex = 0;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerCode.Enabled = false;
            this.txtCustomerCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCustomerCode.Location = new System.Drawing.Point(5, 35);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(250, 25);
            this.txtCustomerCode.TabIndex = 0;
            // 
            // txtEndCustomerCode
            // 
            this.txtEndCustomerCode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtEndCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEndCustomerCode.Enabled = false;
            this.txtEndCustomerCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtEndCustomerCode.Location = new System.Drawing.Point(5, 96);
            this.txtEndCustomerCode.Name = "txtEndCustomerCode";
            this.txtEndCustomerCode.Size = new System.Drawing.Size(250, 25);
            this.txtEndCustomerCode.TabIndex = 0;
            // 
            // txtDeliveryPointName
            // 
            this.txtDeliveryPointName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDeliveryPointName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeliveryPointName.Enabled = false;
            this.txtDeliveryPointName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtDeliveryPointName.Location = new System.Drawing.Point(5, 184);
            this.txtDeliveryPointName.Name = "txtDeliveryPointName";
            this.txtDeliveryPointName.Size = new System.Drawing.Size(250, 25);
            this.txtDeliveryPointName.TabIndex = 0;
            // 
            // txtDeliveryPointCode
            // 
            this.txtDeliveryPointCode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDeliveryPointCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeliveryPointCode.Enabled = false;
            this.txtDeliveryPointCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtDeliveryPointCode.Location = new System.Drawing.Point(5, 155);
            this.txtDeliveryPointCode.Name = "txtDeliveryPointCode";
            this.txtDeliveryPointCode.Size = new System.Drawing.Size(250, 25);
            this.txtDeliveryPointCode.TabIndex = 0;
            // 
            // pLeft_1
            // 
            this.pLeft_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pLeft_1.Controls.Add(this.label5);
            this.pLeft_1.Controls.Add(this.label6);
            this.pLeft_1.Controls.Add(this.label14);
            this.pLeft_1.Controls.Add(this.label13);
            this.pLeft_1.Controls.Add(this.label15);
            this.pLeft_1.Controls.Add(this.label7);
            this.pLeft_1.Controls.Add(this.label21);
            this.pLeft_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeft_1.Location = new System.Drawing.Point(0, 0);
            this.pLeft_1.Name = "pLeft_1";
            this.pLeft_1.Size = new System.Drawing.Size(120, 216);
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
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(5, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "  代理店";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(5, 126);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(110, 20);
            this.label14.TabIndex = 0;
            this.label14.Text = "  需要家名称";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(5, 64);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(110, 20);
            this.label13.TabIndex = 0;
            this.label13.Text = "  代理代名称";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(5, 188);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(110, 20);
            this.label15.TabIndex = 0;
            this.label15.Text = "  纳入先名称";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(5, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "  需要家";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label21.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(5, 155);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(110, 20);
            this.label21.TabIndex = 0;
            this.label21.Text = "  纳入先";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pRight
            // 
            this.pRight.BackColor = System.Drawing.Color.Transparent;
            this.pRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pRight.Controls.Add(this.pRight_2);
            this.pRight.Controls.Add(this.pRight_1);
            this.pRight.Location = new System.Drawing.Point(515, 3);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(500, 218);
            this.pRight.TabIndex = 7;
            // 
            // pRight_2
            // 
            this.pRight_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pRight_2.Controls.Add(this.txtOwnerPoNumber);
            this.pRight_2.Controls.Add(this.txtDepartualDate);
            this.pRight_2.Controls.Add(this.txtSlipDate);
            this.pRight_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRight_2.Enabled = false;
            this.pRight_2.Location = new System.Drawing.Point(120, 0);
            this.pRight_2.Name = "pRight_2";
            this.pRight_2.Size = new System.Drawing.Size(378, 216);
            this.pRight_2.TabIndex = 4;
            // 
            // txtOwnerPoNumber
            // 
            this.txtOwnerPoNumber.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtOwnerPoNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOwnerPoNumber.Enabled = false;
            this.txtOwnerPoNumber.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtOwnerPoNumber.Location = new System.Drawing.Point(5, 5);
            this.txtOwnerPoNumber.Name = "txtOwnerPoNumber";
            this.txtOwnerPoNumber.Size = new System.Drawing.Size(250, 25);
            this.txtOwnerPoNumber.TabIndex = 0;
            // 
            // txtDepartualDate
            // 
            this.txtDepartualDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDepartualDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDepartualDate.Enabled = false;
            this.txtDepartualDate.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtDepartualDate.Location = new System.Drawing.Point(5, 65);
            this.txtDepartualDate.Name = "txtDepartualDate";
            this.txtDepartualDate.Size = new System.Drawing.Size(250, 25);
            this.txtDepartualDate.TabIndex = 0;
            // 
            // txtSlipDate
            // 
            this.txtSlipDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSlipDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSlipDate.Enabled = false;
            this.txtSlipDate.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSlipDate.Location = new System.Drawing.Point(5, 35);
            this.txtSlipDate.Name = "txtSlipDate";
            this.txtSlipDate.Size = new System.Drawing.Size(250, 25);
            this.txtSlipDate.TabIndex = 0;
            // 
            // pRight_1
            // 
            this.pRight_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pRight_1.Controls.Add(this.label12);
            this.pRight_1.Controls.Add(this.label17);
            this.pRight_1.Controls.Add(this.label20);
            this.pRight_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pRight_1.Location = new System.Drawing.Point(0, 0);
            this.pRight_1.Name = "pRight_1";
            this.pRight_1.Size = new System.Drawing.Size(120, 216);
            this.pRight_1.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(5, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 20);
            this.label12.TabIndex = 0;
            this.label12.Text = "  合同编号";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label17.TabIndex = 0;
            this.label17.Text = "  出库预定日期";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label20.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(5, 35);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(110, 20);
            this.label20.TabIndex = 0;
            this.label20.Text = "  订单日期";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnClose.Location = new System.Drawing.Point(925, 618);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关　闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAlloation
            // 
            this.btnAlloation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlloation.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnAlloation.Location = new System.Drawing.Point(831, 618);
            this.btnAlloation.Name = "btnAlloation";
            this.btnAlloation.Size = new System.Drawing.Size(90, 30);
            this.btnAlloation.TabIndex = 1;
            this.btnAlloation.Text = "引当确认";
            this.btnAlloation.UseVisualStyleBackColor = true;
            this.btnAlloation.Click += new System.EventHandler(this.btnAlloation_Click);
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
            this.dgvData.ColumnHeadersHeight = 25;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.PRODUCT_CODE,
            this.PRODUCT_NAME,
            this.PRODUCT_SPEC,
            this.QUANTITY,
            this.UNIT_NAME,
            this.DEPARTUAL_WAREHOUSE,
            this.REF_STOCK,
            this.STOCK,
            this.ALLOATION_QUANTITY,
            this.IS_ALLOATION,
            this.UNIT_CODE,
            this.ORDER_LINE_NUMBER,
            this.ORDER_SLIP_NUMBER,
            this.DEFAULT_WAREHOUSE_CODE});
            this.dgvData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(3, 228);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 45;
            this.dgvData.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.Size = new System.Drawing.Size(1012, 384);
            this.dgvData.TabIndex = 3;
            this.dgvData.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellValueChanged);
            this.dgvData.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellValidated);
            this.dgvData.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvData_CellPainting);
            this.dgvData.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvData_EditingControlShowing);
            this.dgvData.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvData_CurrentCellDirtyStateChanged);
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentClick);
            // 
            // No
            // 
            this.No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.No.DataPropertyName = "No";
            this.No.Frozen = true;
            this.No.HeaderText = "No.";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.No.Width = 35;
            // 
            // PRODUCT_CODE
            // 
            this.PRODUCT_CODE.Frozen = true;
            this.PRODUCT_CODE.HeaderText = "商品编号";
            this.PRODUCT_CODE.Name = "PRODUCT_CODE";
            this.PRODUCT_CODE.ReadOnly = true;
            this.PRODUCT_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PRODUCT_NAME
            // 
            this.PRODUCT_NAME.Frozen = true;
            this.PRODUCT_NAME.HeaderText = "商品名称";
            this.PRODUCT_NAME.Name = "PRODUCT_NAME";
            this.PRODUCT_NAME.ReadOnly = true;
            this.PRODUCT_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PRODUCT_NAME.Width = 150;
            // 
            // PRODUCT_SPEC
            // 
            this.PRODUCT_SPEC.Frozen = true;
            this.PRODUCT_SPEC.HeaderText = "型号";
            this.PRODUCT_SPEC.Name = "PRODUCT_SPEC";
            this.PRODUCT_SPEC.ReadOnly = true;
            this.PRODUCT_SPEC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PRODUCT_SPEC.Width = 140;
            // 
            // QUANTITY
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.QUANTITY.DefaultCellStyle = dataGridViewCellStyle3;
            this.QUANTITY.HeaderText = "未出库数量";
            this.QUANTITY.Name = "QUANTITY";
            this.QUANTITY.ReadOnly = true;
            this.QUANTITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.QUANTITY.Width = 80;
            // 
            // UNIT_NAME
            // 
            this.UNIT_NAME.HeaderText = "单位";
            this.UNIT_NAME.Name = "UNIT_NAME";
            this.UNIT_NAME.ReadOnly = true;
            this.UNIT_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UNIT_NAME.Width = 80;
            // 
            // DEPARTUAL_WAREHOUSE
            // 
            this.DEPARTUAL_WAREHOUSE.HeaderText = "出库仓库";
            this.DEPARTUAL_WAREHOUSE.Name = "DEPARTUAL_WAREHOUSE";
            this.DEPARTUAL_WAREHOUSE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DEPARTUAL_WAREHOUSE.Width = 170;
            // 
            // REF_STOCK
            // 
            this.REF_STOCK.DataPropertyName = "REF_STOCK";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.REF_STOCK.DefaultCellStyle = dataGridViewCellStyle4;
            this.REF_STOCK.HeaderText = "库存参照";
            this.REF_STOCK.LinkColor = System.Drawing.Color.Blue;
            this.REF_STOCK.Name = "REF_STOCK";
            this.REF_STOCK.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.REF_STOCK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.REF_STOCK.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // STOCK
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.STOCK.DefaultCellStyle = dataGridViewCellStyle5;
            this.STOCK.HeaderText = "利用可能库存数";
            this.STOCK.Name = "STOCK";
            this.STOCK.ReadOnly = true;
            this.STOCK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.STOCK.Width = 112;
            // 
            // ALLOATION_QUANTITY
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Info;
            this.ALLOATION_QUANTITY.DefaultCellStyle = dataGridViewCellStyle6;
            this.ALLOATION_QUANTITY.HeaderText = "引当数";
            this.ALLOATION_QUANTITY.MaxInputLength = 10;
            this.ALLOATION_QUANTITY.Name = "ALLOATION_QUANTITY";
            this.ALLOATION_QUANTITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ALLOATION_QUANTITY.Width = 56;
            // 
            // IS_ALLOATION
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.IS_ALLOATION.DefaultCellStyle = dataGridViewCellStyle7;
            this.IS_ALLOATION.HeaderText = "引当可能";
            this.IS_ALLOATION.Name = "IS_ALLOATION";
            this.IS_ALLOATION.ReadOnly = true;
            this.IS_ALLOATION.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IS_ALLOATION.Width = 70;
            // 
            // UNIT_CODE
            // 
            this.UNIT_CODE.HeaderText = "UNIT_CODE";
            this.UNIT_CODE.Name = "UNIT_CODE";
            this.UNIT_CODE.ReadOnly = true;
            this.UNIT_CODE.Visible = false;
            this.UNIT_CODE.Width = 84;
            // 
            // ORDER_LINE_NUMBER
            // 
            this.ORDER_LINE_NUMBER.HeaderText = "ORDER_LINE_NUMBER";
            this.ORDER_LINE_NUMBER.Name = "ORDER_LINE_NUMBER";
            this.ORDER_LINE_NUMBER.ReadOnly = true;
            this.ORDER_LINE_NUMBER.Visible = false;
            this.ORDER_LINE_NUMBER.Width = 132;
            // 
            // ORDER_SLIP_NUMBER
            // 
            this.ORDER_SLIP_NUMBER.HeaderText = "ORDER_SLIP_NUMBER";
            this.ORDER_SLIP_NUMBER.Name = "ORDER_SLIP_NUMBER";
            this.ORDER_SLIP_NUMBER.ReadOnly = true;
            this.ORDER_SLIP_NUMBER.Visible = false;
            this.ORDER_SLIP_NUMBER.Width = 132;
            // 
            // DEFAULT_WAREHOUSE_CODE
            // 
            this.DEFAULT_WAREHOUSE_CODE.HeaderText = "DEFAULT_WAREHOUSE_CODE";
            this.DEFAULT_WAREHOUSE_CODE.Name = "DEFAULT_WAREHOUSE_CODE";
            this.DEFAULT_WAREHOUSE_CODE.ReadOnly = true;
            this.DEFAULT_WAREHOUSE_CODE.Visible = false;
            // 
            // FrmAlloation
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1028, 659);
            this.Controls.Add(this.pInfo);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAlloation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "在库引当";
            this.Load += new System.EventHandler(this.FrmAlloation_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAlloation_FormClosing);
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
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtSlipNumber;
        private System.Windows.Forms.TextBox txtEndCustomerName;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.TextBox txtEndCustomerCode;
        private System.Windows.Forms.Panel pLeft_1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.Panel pRight_2;
        private System.Windows.Forms.TextBox txtOwnerPoNumber;
        private System.Windows.Forms.TextBox txtSlipDate;
        private System.Windows.Forms.TextBox txtDeliveryPointName;
        private System.Windows.Forms.TextBox txtDeliveryPointCode;
        private System.Windows.Forms.Panel pRight_1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAlloation;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.TextBox txtDepartualDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_SPEC;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUANTITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNIT_NAME;
        private System.Windows.Forms.DataGridViewComboBoxColumn DEPARTUAL_WAREHOUSE;
        private System.Windows.Forms.DataGridViewLinkColumn REF_STOCK;
        private System.Windows.Forms.DataGridViewTextBoxColumn STOCK;
        private System.Windows.Forms.DataGridViewTextBoxColumn ALLOATION_QUANTITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn IS_ALLOATION;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNIT_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDER_LINE_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDER_SLIP_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEFAULT_WAREHOUSE_CODE;
    }
}