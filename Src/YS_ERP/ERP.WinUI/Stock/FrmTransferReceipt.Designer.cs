namespace CZZD.ERP.WinUI
{
    partial class FrmTransferReceipt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTransferReceipt));
            this.pBody = new System.Windows.Forms.Panel();
            this.pHeader = new System.Windows.Forms.Panel();
            this.pLeft = new System.Windows.Forms.Panel();
            this.pleft_2 = new System.Windows.Forms.Panel();
            this.txtSlipDate = new System.Windows.Forms.DateTimePicker();
            this.btnArrival = new System.Windows.Forms.Button();
            this.btnDepartual = new System.Windows.Forms.Button();
            this.txtSlipNumber = new System.Windows.Forms.TextBox();
            this.txtDepartualName = new System.Windows.Forms.TextBox();
            this.txtArrivalName = new System.Windows.Forms.TextBox();
            this.txtDepartualCode = new System.Windows.Forms.TextBox();
            this.txtArrivalCode = new System.Windows.Forms.TextBox();
            this.pLeft_1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.btnDeleteRow = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnProduct = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PRODUCT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNIT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNIT_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRANSFER_QUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pBody.SuspendLayout();
            this.pHeader.SuspendLayout();
            this.pLeft.SuspendLayout();
            this.pleft_2.SuspendLayout();
            this.pLeft_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // pBody
            // 
            this.pBody.BackColor = System.Drawing.Color.White;
            this.pBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBody.Controls.Add(this.pHeader);
            this.pBody.Controls.Add(this.btnClose);
            this.pBody.Controls.Add(this.btnSave);
            this.pBody.Controls.Add(this.btnAddRow);
            this.pBody.Controls.Add(this.btnDeleteRow);
            this.pBody.Controls.Add(this.dgvData);
            this.pBody.Location = new System.Drawing.Point(0, 0);
            this.pBody.Name = "pBody";
            this.pBody.Size = new System.Drawing.Size(1024, 660);
            this.pBody.TabIndex = 0;
            // 
            // pHeader
            // 
            this.pHeader.Controls.Add(this.pLeft);
            this.pHeader.Controls.Add(this.dateTimePicker2);
            this.pHeader.Location = new System.Drawing.Point(3, 3);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(1014, 187);
            this.pHeader.TabIndex = 0;
            // 
            // pLeft
            // 
            this.pLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLeft.Controls.Add(this.pleft_2);
            this.pLeft.Controls.Add(this.pLeft_1);
            this.pLeft.Location = new System.Drawing.Point(0, 0);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(510, 187);
            this.pLeft.TabIndex = 1;
            // 
            // pleft_2
            // 
            this.pleft_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pleft_2.Controls.Add(this.txtSlipDate);
            this.pleft_2.Controls.Add(this.btnArrival);
            this.pleft_2.Controls.Add(this.btnDepartual);
            this.pleft_2.Controls.Add(this.txtSlipNumber);
            this.pleft_2.Controls.Add(this.txtDepartualName);
            this.pleft_2.Controls.Add(this.txtArrivalName);
            this.pleft_2.Controls.Add(this.txtDepartualCode);
            this.pleft_2.Controls.Add(this.txtArrivalCode);
            this.pleft_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pleft_2.Location = new System.Drawing.Point(120, 0);
            this.pleft_2.Name = "pleft_2";
            this.pleft_2.Size = new System.Drawing.Size(388, 185);
            this.pleft_2.TabIndex = 0;
            // 
            // txtSlipDate
            // 
            this.txtSlipDate.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.txtSlipDate.CustomFormat = "yyyy-MM-dd";
            this.txtSlipDate.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSlipDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtSlipDate.Location = new System.Drawing.Point(5, 155);
            this.txtSlipDate.Name = "txtSlipDate";
            this.txtSlipDate.Size = new System.Drawing.Size(250, 25);
            this.txtSlipDate.TabIndex = 7;
            this.txtSlipDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.txtSlipDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // btnArrival
            // 
            this.btnArrival.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnArrival.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnArrival.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnArrival.FlatAppearance.BorderSize = 0;
            this.btnArrival.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnArrival.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnArrival.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArrival.Location = new System.Drawing.Point(261, 95);
            this.btnArrival.Name = "btnArrival";
            this.btnArrival.Size = new System.Drawing.Size(25, 25);
            this.btnArrival.TabIndex = 5;
            this.btnArrival.UseVisualStyleBackColor = true;
            this.btnArrival.MouseLeave += new System.EventHandler(this.btnSearch_MouseLeave);
            this.btnArrival.Click += new System.EventHandler(this.btnArrival_Click);
            this.btnArrival.MouseEnter += new System.EventHandler(this.btnSearch_MouseEnter);
            this.btnArrival.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // btnDepartual
            // 
            this.btnDepartual.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnDepartual.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDepartual.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDepartual.FlatAppearance.BorderSize = 0;
            this.btnDepartual.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDepartual.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDepartual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDepartual.Location = new System.Drawing.Point(261, 35);
            this.btnDepartual.Name = "btnDepartual";
            this.btnDepartual.Size = new System.Drawing.Size(25, 25);
            this.btnDepartual.TabIndex = 2;
            this.btnDepartual.UseVisualStyleBackColor = true;
            this.btnDepartual.MouseLeave += new System.EventHandler(this.btnSearch_MouseLeave);
            this.btnDepartual.Click += new System.EventHandler(this.btnDepartual_Click);
            this.btnDepartual.MouseEnter += new System.EventHandler(this.btnSearch_MouseEnter);
            this.btnDepartual.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // txtSlipNumber
            // 
            this.txtSlipNumber.BackColor = System.Drawing.Color.Gainsboro;
            this.txtSlipNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSlipNumber.Enabled = false;
            this.txtSlipNumber.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSlipNumber.Location = new System.Drawing.Point(5, 5);
            this.txtSlipNumber.Name = "txtSlipNumber";
            this.txtSlipNumber.Size = new System.Drawing.Size(250, 25);
            this.txtSlipNumber.TabIndex = 0;
            this.txtSlipNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtSlipNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtDepartualName
            // 
            this.txtDepartualName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDepartualName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDepartualName.Enabled = false;
            this.txtDepartualName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtDepartualName.Location = new System.Drawing.Point(5, 65);
            this.txtDepartualName.Name = "txtDepartualName";
            this.txtDepartualName.Size = new System.Drawing.Size(250, 25);
            this.txtDepartualName.TabIndex = 3;
            this.txtDepartualName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtDepartualName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtArrivalName
            // 
            this.txtArrivalName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtArrivalName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtArrivalName.Enabled = false;
            this.txtArrivalName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtArrivalName.Location = new System.Drawing.Point(5, 125);
            this.txtArrivalName.Name = "txtArrivalName";
            this.txtArrivalName.Size = new System.Drawing.Size(250, 25);
            this.txtArrivalName.TabIndex = 6;
            this.txtArrivalName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtArrivalName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtDepartualCode
            // 
            this.txtDepartualCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtDepartualCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDepartualCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtDepartualCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtDepartualCode.Location = new System.Drawing.Point(5, 35);
            this.txtDepartualCode.MaxLength = 20;
            this.txtDepartualCode.Name = "txtDepartualCode";
            this.txtDepartualCode.Size = new System.Drawing.Size(250, 25);
            this.txtDepartualCode.TabIndex = 1;
            this.txtDepartualCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtDepartualCode.Leave += new System.EventHandler(this.txtDepartualCode_Leave);
            this.txtDepartualCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtArrivalCode
            // 
            this.txtArrivalCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtArrivalCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtArrivalCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtArrivalCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtArrivalCode.Location = new System.Drawing.Point(5, 95);
            this.txtArrivalCode.MaxLength = 20;
            this.txtArrivalCode.Name = "txtArrivalCode";
            this.txtArrivalCode.Size = new System.Drawing.Size(250, 25);
            this.txtArrivalCode.TabIndex = 4;
            this.txtArrivalCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtArrivalCode.Leave += new System.EventHandler(this.txtArrivalCode_Leave);
            this.txtArrivalCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // pLeft_1
            // 
            this.pLeft_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pLeft_1.Controls.Add(this.label3);
            this.pLeft_1.Controls.Add(this.label4);
            this.pLeft_1.Controls.Add(this.label5);
            this.pLeft_1.Controls.Add(this.label6);
            this.pLeft_1.Controls.Add(this.label13);
            this.pLeft_1.Controls.Add(this.label14);
            this.pLeft_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeft_1.Location = new System.Drawing.Point(0, 0);
            this.pLeft_1.Name = "pLeft_1";
            this.pLeft_1.Size = new System.Drawing.Size(120, 185);
            this.pLeft_1.TabIndex = 1;
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
            this.label3.Text = "  调拨编号";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "  调出仓库";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "  调入仓库";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(5, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "  调拨日期";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(5, 65);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(110, 20);
            this.label13.TabIndex = 0;
            this.label13.Text = "  调出仓库名称";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(5, 125);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(110, 20);
            this.label14.TabIndex = 0;
            this.label14.Text = "  调入仓库名称";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.dateTimePicker2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.dateTimePicker2.Location = new System.Drawing.Point(1289, 522);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(250, 29);
            this.dateTimePicker2.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(927, 623);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 30);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "关　闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(832, 623);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保　存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddRow.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddRow.Location = new System.Drawing.Point(3, 191);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(95, 30);
            this.btnAddRow.TabIndex = 1;
            this.btnAddRow.Text = "行添加";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            this.btnAddRow.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteRow.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDeleteRow.Location = new System.Drawing.Point(105, 191);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(95, 30);
            this.btnDeleteRow.TabIndex = 2;
            this.btnDeleteRow.Text = "行删除";
            this.btnDeleteRow.UseVisualStyleBackColor = true;
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
            this.btnDeleteRow.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeColumns = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.ColumnHeadersHeight = 28;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.PRODUCT_CODE,
            this.BtnProduct,
            this.PRODUCT_NAME,
            this.QUANTITY,
            this.UNIT_NAME,
            this.UNIT_CODE,
            this.TRANSFER_QUANTITY});
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(3, 223);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 25;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.Size = new System.Drawing.Size(1015, 396);
            this.dgvData.TabIndex = 3;
            this.dgvData.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellValidated);
            this.dgvData.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvData_RowsAdded);
            this.dgvData.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvData_CellPainting);
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);
            this.dgvData.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvData_EditingControlShowing);
            this.dgvData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // No
            // 
            this.No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.No.DefaultCellStyle = dataGridViewCellStyle1;
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.No.Width = 35;
            // 
            // PRODUCT_CODE
            // 
            this.PRODUCT_CODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PRODUCT_CODE.DataPropertyName = "PRODUCT_CODE";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.PRODUCT_CODE.DefaultCellStyle = dataGridViewCellStyle2;
            this.PRODUCT_CODE.HeaderText = "商品编号";
            this.PRODUCT_CODE.MaxInputLength = 12;
            this.PRODUCT_CODE.Name = "PRODUCT_CODE";
            this.PRODUCT_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // BtnProduct
            // 
            this.BtnProduct.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.BtnProduct.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnProduct.HeaderText = "";
            this.BtnProduct.Name = "BtnProduct";
            this.BtnProduct.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BtnProduct.ToolTipText = "查询";
            this.BtnProduct.Width = 30;
            // 
            // PRODUCT_NAME
            // 
            this.PRODUCT_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.PRODUCT_NAME.DefaultCellStyle = dataGridViewCellStyle3;
            this.PRODUCT_NAME.HeaderText = "商品名称";
            this.PRODUCT_NAME.Name = "PRODUCT_NAME";
            this.PRODUCT_NAME.ReadOnly = true;
            this.PRODUCT_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PRODUCT_NAME.Width = 150;
            // 
            // QUANTITY
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.QUANTITY.DefaultCellStyle = dataGridViewCellStyle4;
            this.QUANTITY.HeaderText = "库存数量";
            this.QUANTITY.Name = "QUANTITY";
            this.QUANTITY.ReadOnly = true;
            this.QUANTITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.QUANTITY.Width = 232;
            // 
            // UNIT_NAME
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.UNIT_NAME.DefaultCellStyle = dataGridViewCellStyle5;
            this.UNIT_NAME.HeaderText = "单位";
            this.UNIT_NAME.Name = "UNIT_NAME";
            this.UNIT_NAME.ReadOnly = true;
            this.UNIT_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UNIT_NAME.Width = 233;
            // 
            // UNIT_CODE
            // 
            this.UNIT_CODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UNIT_CODE.DataPropertyName = "UNIT_CODE";
            this.UNIT_CODE.FillWeight = 5F;
            this.UNIT_CODE.HeaderText = "UNIT_CODE";
            this.UNIT_CODE.Name = "UNIT_CODE";
            this.UNIT_CODE.ReadOnly = true;
            this.UNIT_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UNIT_CODE.Visible = false;
            this.UNIT_CODE.Width = 5;
            // 
            // TRANSFER_QUANTITY
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.TRANSFER_QUANTITY.DefaultCellStyle = dataGridViewCellStyle6;
            this.TRANSFER_QUANTITY.HeaderText = "调拨数量";
            this.TRANSFER_QUANTITY.Name = "TRANSFER_QUANTITY";
            this.TRANSFER_QUANTITY.Width = 232;
            // 
            // FrmTransferReceipt
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1028, 662);
            this.Controls.Add(this.pBody);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmTransferReceipt";
            this.Text = "仓库间调拨";
            this.Load += new System.EventHandler(this.FrmTransferReceipt_Load);
            this.pBody.ResumeLayout(false);
            this.pHeader.ResumeLayout(false);
            this.pLeft.ResumeLayout(false);
            this.pleft_2.ResumeLayout(false);
            this.pleft_2.PerformLayout();
            this.pLeft_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pBody;
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.Panel pleft_2;
        private System.Windows.Forms.Button btnArrival;
        private System.Windows.Forms.Button btnDepartual;
        private System.Windows.Forms.TextBox txtSlipNumber;
        private System.Windows.Forms.TextBox txtDepartualName;
        private System.Windows.Forms.TextBox txtArrivalName;
        private System.Windows.Forms.TextBox txtDepartualCode;
        private System.Windows.Forms.TextBox txtArrivalCode;
        private System.Windows.Forms.Panel pLeft_1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.Button btnDeleteRow;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DateTimePicker txtSlipDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_CODE;
        private System.Windows.Forms.DataGridViewButtonColumn BtnProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUANTITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNIT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNIT_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TRANSFER_QUANTITY;
    }
}