namespace CZZD.ERP.WinUI
{
    partial class FrmProductionPlanDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProductionPlanDetails));
            this.label7 = new System.Windows.Forms.Label();
            this.pInfo = new System.Windows.Forms.Panel();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pLeft = new System.Windows.Forms.Panel();
            this.pleft_2 = new System.Windows.Forms.Panel();
            this.txtDepartualDateFrom = new System.Windows.Forms.DateTimePicker();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtProductionQuantity = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtSlipDateFrom = new System.Windows.Forms.DateTimePicker();
            this.pLeft_1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.pRight = new System.Windows.Forms.Panel();
            this.pRight_2 = new System.Windows.Forms.Panel();
            this.btnAddProductionProcess = new System.Windows.Forms.Button();
            this.pRight_1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCTION_PROCESS_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCTION_PROCESS_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEPARTMENT_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEPARTMENT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.START_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.END_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCTION_CYCLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUS_FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTN_DELETE = new System.Windows.Forms.DataGridViewImageColumn();
            this.pInfo.SuspendLayout();
            this.pLeft.SuspendLayout();
            this.pleft_2.SuspendLayout();
            this.pLeft_1.SuspendLayout();
            this.pRight.SuspendLayout();
            this.pRight_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(5, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "计划数量";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pInfo
            // 
            this.pInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pInfo.Controls.Add(this.btnDown);
            this.pInfo.Controls.Add(this.btnUp);
            this.pInfo.Controls.Add(this.btnSave);
            this.pInfo.Controls.Add(this.pLeft);
            this.pInfo.Controls.Add(this.pRight);
            this.pInfo.Controls.Add(this.btnClose);
            this.pInfo.Controls.Add(this.dgvData);
            this.pInfo.Location = new System.Drawing.Point(0, 0);
            this.pInfo.Name = "pInfo";
            this.pInfo.Size = new System.Drawing.Size(1024, 652);
            this.pInfo.TabIndex = 10;
            // 
            // btnDown
            // 
            this.btnDown.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnDown.Location = new System.Drawing.Point(69, 618);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(50, 30);
            this.btnDown.TabIndex = 10;
            this.btnDown.Text = "下移";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnUp.Location = new System.Drawing.Point(13, 618);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(50, 30);
            this.btnUp.TabIndex = 9;
            this.btnUp.Text = "上移";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSave.Location = new System.Drawing.Point(829, 618);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "确　定";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.pleft_2.Controls.Add(this.txtDepartualDateFrom);
            this.pleft_2.Controls.Add(this.textBox3);
            this.pleft_2.Controls.Add(this.txtProductionQuantity);
            this.pleft_2.Controls.Add(this.textBox2);
            this.pleft_2.Controls.Add(this.textBox1);
            this.pleft_2.Controls.Add(this.txtSlipDateFrom);
            this.pleft_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pleft_2.Location = new System.Drawing.Point(120, 0);
            this.pleft_2.Name = "pleft_2";
            this.pleft_2.Size = new System.Drawing.Size(388, 183);
            this.pleft_2.TabIndex = 5;
            // 
            // txtDepartualDateFrom
            // 
            this.txtDepartualDateFrom.CalendarFont = new System.Drawing.Font("微软雅黑", 10F);
            this.txtDepartualDateFrom.CalendarMonthBackground = System.Drawing.Color.White;
            this.txtDepartualDateFrom.Checked = false;
            this.txtDepartualDateFrom.CustomFormat = "yyyy-MM-dd";
            this.txtDepartualDateFrom.Enabled = false;
            this.txtDepartualDateFrom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDepartualDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDepartualDateFrom.Location = new System.Drawing.Point(5, 155);
            this.txtDepartualDateFrom.Name = "txtDepartualDateFrom";
            this.txtDepartualDateFrom.Size = new System.Drawing.Size(250, 23);
            this.txtDepartualDateFrom.TabIndex = 14;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.textBox3.Location = new System.Drawing.Point(5, 65);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(250, 25);
            this.textBox3.TabIndex = 0;
            // 
            // txtProductionQuantity
            // 
            this.txtProductionQuantity.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtProductionQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductionQuantity.Enabled = false;
            this.txtProductionQuantity.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtProductionQuantity.Location = new System.Drawing.Point(5, 95);
            this.txtProductionQuantity.Name = "txtProductionQuantity";
            this.txtProductionQuantity.Size = new System.Drawing.Size(250, 25);
            this.txtProductionQuantity.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.textBox2.Location = new System.Drawing.Point(5, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(250, 25);
            this.textBox2.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.textBox1.Location = new System.Drawing.Point(5, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(250, 25);
            this.textBox1.TabIndex = 0;
            // 
            // txtSlipDateFrom
            // 
            this.txtSlipDateFrom.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.txtSlipDateFrom.CalendarMonthBackground = System.Drawing.Color.White;
            this.txtSlipDateFrom.Checked = false;
            this.txtSlipDateFrom.CustomFormat = "yyyy-MM-dd";
            this.txtSlipDateFrom.Enabled = false;
            this.txtSlipDateFrom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSlipDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtSlipDateFrom.Location = new System.Drawing.Point(5, 125);
            this.txtSlipDateFrom.Name = "txtSlipDateFrom";
            this.txtSlipDateFrom.Size = new System.Drawing.Size(250, 23);
            this.txtSlipDateFrom.TabIndex = 11;
            // 
            // pLeft_1
            // 
            this.pLeft_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pLeft_1.Controls.Add(this.label8);
            this.pLeft_1.Controls.Add(this.label7);
            this.pLeft_1.Controls.Add(this.label1);
            this.pLeft_1.Controls.Add(this.label6);
            this.pLeft_1.Controls.Add(this.label4);
            this.pLeft_1.Controls.Add(this.label17);
            this.pLeft_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeft_1.Location = new System.Drawing.Point(0, 0);
            this.pLeft_1.Name = "pLeft_1";
            this.pLeft_1.Size = new System.Drawing.Size(120, 183);
            this.pLeft_1.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(5, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "预定完城日期";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "模具部件";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label6.Text = "模具尺寸/描述";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label4.Text = "模具种类";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label17.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(5, 125);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(110, 20);
            this.label17.TabIndex = 0;
            this.label17.Text = "预定开始日期";
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
            this.pRight_2.Controls.Add(this.btnAddProductionProcess);
            this.pRight_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRight_2.Location = new System.Drawing.Point(120, 0);
            this.pRight_2.Name = "pRight_2";
            this.pRight_2.Size = new System.Drawing.Size(378, 183);
            this.pRight_2.TabIndex = 4;
            // 
            // btnAddProductionProcess
            // 
            this.btnAddProductionProcess.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnAddProductionProcess.Location = new System.Drawing.Point(285, 151);
            this.btnAddProductionProcess.Name = "btnAddProductionProcess";
            this.btnAddProductionProcess.Size = new System.Drawing.Size(90, 30);
            this.btnAddProductionProcess.TabIndex = 6;
            this.btnAddProductionProcess.Text = "增加工序";
            this.btnAddProductionProcess.UseVisualStyleBackColor = true;
            this.btnAddProductionProcess.Click += new System.EventHandler(this.btnAddProductionProcess_Click);
            // 
            // pRight_1
            // 
            this.pRight_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pRight_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pRight_1.Location = new System.Drawing.Point(0, 0);
            this.pRight_1.Name = "pRight_1";
            this.pRight_1.Size = new System.Drawing.Size(120, 183);
            this.pRight_1.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnClose.Location = new System.Drawing.Point(925, 618);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 30);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关　闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvData.ColumnHeadersHeight = 25;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.PRODUCTION_PROCESS_CODE,
            this.PRODUCTION_PROCESS_NAME,
            this.DEPARTMENT_CODE,
            this.DEPARTMENT_NAME,
            this.START_DATE,
            this.END_DATE,
            this.FLAG,
            this.PRODUCTION_CYCLE,
            this.STATUS_FLAG,
            this.BTN_DELETE});
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
            this.dgvData.Size = new System.Drawing.Size(1012, 426);
            this.dgvData.TabIndex = 0;
            this.dgvData.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellValidated);
            this.dgvData.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvData_CellPainting);
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);
            this.dgvData.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvData_EditingControlShowing);
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentClick);
            // 
            // No
            // 
            this.No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.No.DataPropertyName = "No";
            dataGridViewCellStyle2.NullValue = null;
            this.No.DefaultCellStyle = dataGridViewCellStyle2;
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.No.Width = 35;
            // 
            // PRODUCTION_PROCESS_CODE
            // 
            this.PRODUCTION_PROCESS_CODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PRODUCTION_PROCESS_CODE.DataPropertyName = "PRODUCTION_PROCESS_CODE";
            this.PRODUCTION_PROCESS_CODE.HeaderText = "工序编号";
            this.PRODUCTION_PROCESS_CODE.Name = "PRODUCTION_PROCESS_CODE";
            this.PRODUCTION_PROCESS_CODE.ReadOnly = true;
            this.PRODUCTION_PROCESS_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PRODUCTION_PROCESS_NAME
            // 
            this.PRODUCTION_PROCESS_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PRODUCTION_PROCESS_NAME.DataPropertyName = "PRODUCTION_PROCESS_NAME";
            this.PRODUCTION_PROCESS_NAME.HeaderText = "工序名称";
            this.PRODUCTION_PROCESS_NAME.Name = "PRODUCTION_PROCESS_NAME";
            this.PRODUCTION_PROCESS_NAME.ReadOnly = true;
            this.PRODUCTION_PROCESS_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PRODUCTION_PROCESS_NAME.Width = 174;
            // 
            // DEPARTMENT_CODE
            // 
            this.DEPARTMENT_CODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DEPARTMENT_CODE.HeaderText = "生产部门编号";
            this.DEPARTMENT_CODE.Name = "DEPARTMENT_CODE";
            this.DEPARTMENT_CODE.ReadOnly = true;
            this.DEPARTMENT_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DEPARTMENT_NAME
            // 
            this.DEPARTMENT_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DEPARTMENT_NAME.DataPropertyName = "DEPARTMENT_NAME";
            dataGridViewCellStyle3.NullValue = null;
            this.DEPARTMENT_NAME.DefaultCellStyle = dataGridViewCellStyle3;
            this.DEPARTMENT_NAME.HeaderText = "生产部门名称";
            this.DEPARTMENT_NAME.Name = "DEPARTMENT_NAME";
            this.DEPARTMENT_NAME.ReadOnly = true;
            this.DEPARTMENT_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DEPARTMENT_NAME.Width = 180;
            // 
            // START_DATE
            // 
            this.START_DATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.START_DATE.DataPropertyName = "START_DATE";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "yyyy-MM-dd";
            dataGridViewCellStyle4.NullValue = null;
            this.START_DATE.DefaultCellStyle = dataGridViewCellStyle4;
            this.START_DATE.HeaderText = "预定开始日期";
            this.START_DATE.Name = "START_DATE";
            this.START_DATE.ReadOnly = true;
            this.START_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.START_DATE.Width = 120;
            // 
            // END_DATE
            // 
            this.END_DATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.END_DATE.DataPropertyName = "END_DATE";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "yyyy-MM-dd";
            this.END_DATE.DefaultCellStyle = dataGridViewCellStyle5;
            this.END_DATE.HeaderText = "预定完成日期";
            this.END_DATE.Name = "END_DATE";
            this.END_DATE.ReadOnly = true;
            this.END_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.END_DATE.Width = 120;
            // 
            // FLAG
            // 
            this.FLAG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FLAG.HeaderText = "FLAG";
            this.FLAG.Name = "FLAG";
            this.FLAG.ReadOnly = true;
            this.FLAG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.FLAG.Visible = false;
            this.FLAG.Width = 80;
            // 
            // PRODUCTION_CYCLE
            // 
            this.PRODUCTION_CYCLE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.PRODUCTION_CYCLE.DefaultCellStyle = dataGridViewCellStyle6;
            this.PRODUCTION_CYCLE.HeaderText = "周期(天)";
            this.PRODUCTION_CYCLE.MaxInputLength = 2;
            this.PRODUCTION_CYCLE.Name = "PRODUCTION_CYCLE";
            this.PRODUCTION_CYCLE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PRODUCTION_CYCLE.Width = 65;
            // 
            // STATUS_FLAG
            // 
            this.STATUS_FLAG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.STATUS_FLAG.HeaderText = "状态";
            this.STATUS_FLAG.Name = "STATUS_FLAG";
            this.STATUS_FLAG.ReadOnly = true;
            this.STATUS_FLAG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.STATUS_FLAG.Width = 80;
            // 
            // BTN_DELETE
            // 
            this.BTN_DELETE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.BTN_DELETE.DataPropertyName = "BTN_DELETE";
            this.BTN_DELETE.HeaderText = "";
            this.BTN_DELETE.Name = "BTN_DELETE";
            this.BTN_DELETE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BTN_DELETE.Width = 35;
            // 
            // FrmProductionPlanDetails
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1028, 654);
            this.Controls.Add(this.pInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProductionPlanDetails";
            this.Text = "工序编辑";
            this.Load += new System.EventHandler(this.FrmProductionPlanDetails_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmProductionPlanDetails_FormClosed);
            this.pInfo.ResumeLayout(false);
            this.pLeft.ResumeLayout(false);
            this.pleft_2.ResumeLayout(false);
            this.pleft_2.PerformLayout();
            this.pLeft_1.ResumeLayout(false);
            this.pRight.ResumeLayout(false);
            this.pRight_2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pInfo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.Panel pleft_2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel pLeft_1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.Panel pRight_2;
        private System.Windows.Forms.Button btnAddProductionProcess;
        private System.Windows.Forms.DateTimePicker txtDepartualDateFrom;
        private System.Windows.Forms.TextBox txtProductionQuantity;
        private System.Windows.Forms.DateTimePicker txtSlipDateFrom;
        private System.Windows.Forms.Panel pRight_1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCTION_PROCESS_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCTION_PROCESS_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPARTMENT_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPARTMENT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn START_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn END_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn FLAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCTION_CYCLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATUS_FLAG;
        private System.Windows.Forms.DataGridViewImageColumn BTN_DELETE;
    }
}