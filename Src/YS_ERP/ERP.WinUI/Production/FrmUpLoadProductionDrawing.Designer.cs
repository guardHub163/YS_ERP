namespace CZZD.ERP.WinUI
{
    partial class FrmUpLoadProductionDrawing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUpLoadProductionDrawing));
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.pRight = new System.Windows.Forms.Panel();
            this.pRight_2 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pRight_1 = new System.Windows.Forms.Panel();
            this.pLeft = new System.Windows.Forms.Panel();
            this.pleft_2 = new System.Windows.Forms.Panel();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.btnSlipType = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtSlipTypeName = new System.Windows.Forms.TextBox();
            this.txtSlipType = new System.Windows.Forms.TextBox();
            this.txtSlipNumber = new System.Windows.Forms.TextBox();
            this.pLeft_1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEndDrawing = new System.Windows.Forms.Button();
            this.pInfo = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PSDL_SLIP_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TYPE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DrawingName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PSDL_PLAN_END_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PSDL_ACTUAL_END_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PSDL_STATUS_FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PSDL_LINE_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PSDL_DRAWING_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTN_UPLOAD = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.pRight.SuspendLayout();
            this.pRight_2.SuspendLayout();
            this.pLeft.SuspendLayout();
            this.pleft_2.SuspendLayout();
            this.pLeft_1.SuspendLayout();
            this.pInfo.SuspendLayout();
            this.SuspendLayout();
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
            this.PSDL_SLIP_NUMBER,
            this.TYPE_NAME,
            this.DrawingName,
            this.PSDL_PLAN_END_DATE,
            this.PSDL_ACTUAL_END_TIME,
            this.Status,
            this.PSDL_STATUS_FLAG,
            this.PSDL_LINE_NUMBER,
            this.PSDL_DRAWING_CODE,
            this.BTN_UPLOAD});
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
            this.dgvData.Size = new System.Drawing.Size(1012, 412);
            this.dgvData.TabIndex = 0;
            this.dgvData.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellValidated);
            this.dgvData.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvData_CellPainting);
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnClose.Location = new System.Drawing.Point(925, 602);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 30);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关　闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.pRight_2.Controls.Add(this.btnSearch);
            this.pRight_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRight_2.Location = new System.Drawing.Point(120, 0);
            this.pRight_2.Name = "pRight_2";
            this.pRight_2.Size = new System.Drawing.Size(378, 183);
            this.pRight_2.TabIndex = 4;
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
            // pRight_1
            // 
            this.pRight_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pRight_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pRight_1.Location = new System.Drawing.Point(0, 0);
            this.pRight_1.Name = "pRight_1";
            this.pRight_1.Size = new System.Drawing.Size(120, 183);
            this.pRight_1.TabIndex = 3;
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
            this.pleft_2.Controls.Add(this.cboStatus);
            this.pleft_2.Controls.Add(this.btnSlipType);
            this.pleft_2.Controls.Add(this.label5);
            this.pleft_2.Controls.Add(this.dateTimePicker2);
            this.pleft_2.Controls.Add(this.dateTimePicker1);
            this.pleft_2.Controls.Add(this.txtSlipTypeName);
            this.pleft_2.Controls.Add(this.txtSlipType);
            this.pleft_2.Controls.Add(this.txtSlipNumber);
            this.pleft_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pleft_2.Location = new System.Drawing.Point(120, 0);
            this.pleft_2.Name = "pleft_2";
            this.pleft_2.Size = new System.Drawing.Size(388, 183);
            this.pleft_2.TabIndex = 5;
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(5, 125);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(250, 25);
            this.cboStatus.TabIndex = 19;
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
            this.btnSlipType.Location = new System.Drawing.Point(262, 66);
            this.btnSlipType.Name = "btnSlipType";
            this.btnSlipType.Size = new System.Drawing.Size(25, 25);
            this.btnSlipType.TabIndex = 18;
            this.btnSlipType.UseVisualStyleBackColor = true;
            this.btnSlipType.MouseLeave += new System.EventHandler(this.btnSlipType_MouseLeave);
            this.btnSlipType.Click += new System.EventHandler(this.btnSlipType_Click);
            this.btnSlipType.MouseEnter += new System.EventHandler(this.btnSlipType_MouseEnter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(118, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 19);
            this.label5.TabIndex = 12;
            this.label5.Text = "~";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.dateTimePicker2.Checked = false;
            this.dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(141, 35);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.ShowCheckBox = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(113, 23);
            this.dateTimePicker2.TabIndex = 13;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.dateTimePicker1.Checked = false;
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(5, 35);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowCheckBox = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(113, 23);
            this.dateTimePicker1.TabIndex = 11;
            // 
            // txtSlipTypeName
            // 
            this.txtSlipTypeName.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtSlipTypeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSlipTypeName.Enabled = false;
            this.txtSlipTypeName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSlipTypeName.Location = new System.Drawing.Point(6, 95);
            this.txtSlipTypeName.Name = "txtSlipTypeName";
            this.txtSlipTypeName.ReadOnly = true;
            this.txtSlipTypeName.Size = new System.Drawing.Size(250, 25);
            this.txtSlipTypeName.TabIndex = 0;
            // 
            // txtSlipType
            // 
            this.txtSlipType.BackColor = System.Drawing.SystemColors.Info;
            this.txtSlipType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSlipType.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSlipType.Location = new System.Drawing.Point(6, 65);
            this.txtSlipType.Name = "txtSlipType";
            this.txtSlipType.Size = new System.Drawing.Size(250, 25);
            this.txtSlipType.TabIndex = 0;
            this.txtSlipType.Leave += new System.EventHandler(this.txtSlipType_Leave);
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
            // pLeft_1
            // 
            this.pLeft_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pLeft_1.Controls.Add(this.label6);
            this.pLeft_1.Controls.Add(this.label12);
            this.pLeft_1.Controls.Add(this.label3);
            this.pLeft_1.Controls.Add(this.label1);
            this.pLeft_1.Controls.Add(this.label4);
            this.pLeft_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeft_1.Location = new System.Drawing.Point(0, 0);
            this.pLeft_1.Name = "pLeft_1";
            this.pLeft_1.Size = new System.Drawing.Size(120, 183);
            this.pLeft_1.TabIndex = 4;
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
            this.label6.TabIndex = 8;
            this.label6.Text = "模具种类名称";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(5, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 20);
            this.label12.TabIndex = 7;
            this.label12.Text = "计划完成日期";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label1.Text = "模具种类编号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "模具种类名称";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnEndDrawing
            // 
            this.btnEndDrawing.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnEndDrawing.Location = new System.Drawing.Point(833, 602);
            this.btnEndDrawing.Name = "btnEndDrawing";
            this.btnEndDrawing.Size = new System.Drawing.Size(90, 30);
            this.btnEndDrawing.TabIndex = 6;
            this.btnEndDrawing.Text = "结　束";
            this.btnEndDrawing.UseVisualStyleBackColor = true;
            this.btnEndDrawing.Click += new System.EventHandler(this.btnEndDrawing_Click);
            // 
            // pInfo
            // 
            this.pInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pInfo.Controls.Add(this.btnExport);
            this.pInfo.Controls.Add(this.btnEndDrawing);
            this.pInfo.Controls.Add(this.pLeft);
            this.pInfo.Controls.Add(this.pRight);
            this.pInfo.Controls.Add(this.btnClose);
            this.pInfo.Controls.Add(this.dgvData);
            this.pInfo.Location = new System.Drawing.Point(0, 0);
            this.pInfo.Name = "pInfo";
            this.pInfo.Size = new System.Drawing.Size(1024, 643);
            this.pInfo.TabIndex = 11;
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnExport.Location = new System.Drawing.Point(740, 602);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(90, 30);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "导　出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // No
            // 
            this.No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
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
            this.CHK.DataPropertyName = "CHK";
            this.CHK.HeaderText = "选择";
            this.CHK.Name = "CHK";
            this.CHK.Width = 40;
            // 
            // PSDL_SLIP_NUMBER
            // 
            this.PSDL_SLIP_NUMBER.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PSDL_SLIP_NUMBER.DataPropertyName = "PSDL_SLIP_NUMBER";
            this.PSDL_SLIP_NUMBER.HeaderText = "生产工单编号";
            this.PSDL_SLIP_NUMBER.Name = "PSDL_SLIP_NUMBER";
            this.PSDL_SLIP_NUMBER.ReadOnly = true;
            this.PSDL_SLIP_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PSDL_SLIP_NUMBER.Width = 185;
            // 
            // TYPE_NAME
            // 
            this.TYPE_NAME.DataPropertyName = "SLIP_TYPE_NAME";
            this.TYPE_NAME.HeaderText = "模具种类";
            this.TYPE_NAME.Name = "TYPE_NAME";
            this.TYPE_NAME.ReadOnly = true;
            this.TYPE_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DrawingName
            // 
            this.DrawingName.DataPropertyName = "NAME";
            this.DrawingName.HeaderText = "图纸";
            this.DrawingName.Name = "DrawingName";
            this.DrawingName.ReadOnly = true;
            this.DrawingName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PSDL_PLAN_END_DATE
            // 
            this.PSDL_PLAN_END_DATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PSDL_PLAN_END_DATE.DataPropertyName = "PSDL_PLAN_END_DATE";
            dataGridViewCellStyle3.Format = "yyyy-MM-dd";
            this.PSDL_PLAN_END_DATE.DefaultCellStyle = dataGridViewCellStyle3;
            this.PSDL_PLAN_END_DATE.HeaderText = "预定完成日期";
            this.PSDL_PLAN_END_DATE.Name = "PSDL_PLAN_END_DATE";
            this.PSDL_PLAN_END_DATE.ReadOnly = true;
            this.PSDL_PLAN_END_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PSDL_PLAN_END_DATE.Width = 185;
            // 
            // PSDL_ACTUAL_END_TIME
            // 
            this.PSDL_ACTUAL_END_TIME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PSDL_ACTUAL_END_TIME.DataPropertyName = "PSDL_ACTUAL_END_TIME";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.Format = "yyyy-MM-dd";
            this.PSDL_ACTUAL_END_TIME.DefaultCellStyle = dataGridViewCellStyle4;
            this.PSDL_ACTUAL_END_TIME.HeaderText = "结束日期";
            this.PSDL_ACTUAL_END_TIME.Name = "PSDL_ACTUAL_END_TIME";
            this.PSDL_ACTUAL_END_TIME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PSDL_ACTUAL_END_TIME.Width = 185;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "状态";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PSDL_STATUS_FLAG
            // 
            this.PSDL_STATUS_FLAG.DataPropertyName = "PSDL_STATUS_FLAG";
            this.PSDL_STATUS_FLAG.HeaderText = "PSDL_STATUS_FLAG";
            this.PSDL_STATUS_FLAG.Name = "PSDL_STATUS_FLAG";
            this.PSDL_STATUS_FLAG.ReadOnly = true;
            this.PSDL_STATUS_FLAG.Visible = false;
            // 
            // PSDL_LINE_NUMBER
            // 
            this.PSDL_LINE_NUMBER.DataPropertyName = "PSDL_LINE_NUMBER";
            this.PSDL_LINE_NUMBER.HeaderText = "PSDL_LINE_NUMBER";
            this.PSDL_LINE_NUMBER.Name = "PSDL_LINE_NUMBER";
            this.PSDL_LINE_NUMBER.ReadOnly = true;
            this.PSDL_LINE_NUMBER.Visible = false;
            // 
            // PSDL_DRAWING_CODE
            // 
            this.PSDL_DRAWING_CODE.DataPropertyName = "PSDL_DRAWING_CODE";
            this.PSDL_DRAWING_CODE.HeaderText = "PSDL_DRAWING_CODE";
            this.PSDL_DRAWING_CODE.Name = "PSDL_DRAWING_CODE";
            this.PSDL_DRAWING_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PSDL_DRAWING_CODE.Visible = false;
            // 
            // BTN_UPLOAD
            // 
            this.BTN_UPLOAD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.BTN_UPLOAD.HeaderText = "上传";
            this.BTN_UPLOAD.Name = "BTN_UPLOAD";
            this.BTN_UPLOAD.Width = 50;
            // 
            // FrmUpLoadProductionDrawing
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1027, 657);
            this.Controls.Add(this.pInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmUpLoadProductionDrawing";
            this.Text = "生产图纸上传";
            this.Load += new System.EventHandler(this.FrmUpLoadProductionDrawing_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmUpLoadProductionDrawing_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.pRight.ResumeLayout(false);
            this.pRight_2.ResumeLayout(false);
            this.pLeft.ResumeLayout(false);
            this.pleft_2.ResumeLayout(false);
            this.pleft_2.PerformLayout();
            this.pLeft_1.ResumeLayout(false);
            this.pInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.Panel pRight_2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pRight_1;
        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.Panel pleft_2;
        private System.Windows.Forms.Button btnSlipType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtSlipTypeName;
        private System.Windows.Forms.TextBox txtSlipType;
        private System.Windows.Forms.TextBox txtSlipNumber;
        private System.Windows.Forms.Panel pLeft_1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEndDrawing;
        private System.Windows.Forms.Panel pInfo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CHK;
        private System.Windows.Forms.DataGridViewTextBoxColumn PSDL_SLIP_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn TYPE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrawingName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PSDL_PLAN_END_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PSDL_ACTUAL_END_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn PSDL_STATUS_FLAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn PSDL_LINE_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn PSDL_DRAWING_CODE;
        private System.Windows.Forms.DataGridViewImageColumn BTN_UPLOAD;

    }
}