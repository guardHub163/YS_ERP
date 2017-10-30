namespace CZZD.ERP.WinUI
{
    partial class FrmProductionTechnology
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProductionTechnology));
            this.pleft_2 = new System.Windows.Forms.Panel();
            this.btnSlipNumber = new System.Windows.Forms.Button();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.btnSlipType = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtSlipTypeName = new System.Windows.Forms.TextBox();
            this.txtSlipType = new System.Windows.Forms.TextBox();
            this.txtSlipNumber = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.pRight = new System.Windows.Forms.Panel();
            this.pRight_2 = new System.Windows.Forms.Panel();
            this.btnSeaarch = new System.Windows.Forms.Button();
            this.pRight_1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pLeft = new System.Windows.Forms.Panel();
            this.pLeft_1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.pInfo = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SLIP_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TYPE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PARTS_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCTION_PROCESS_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BT_TECHNOLOGY_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTN_DOWN_LOAD = new System.Windows.Forms.DataGridViewLinkColumn();
            this.START_PLAN_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.END_PLAN_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.START_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.END_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WEIGHT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCTION_PROCESS_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PSPP_LINE_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SCHEDULE_LINE_NUNBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PSPP_STATUS_FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PST_STATUS_FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PST_SCHEDULE_LINE_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PST_SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PST_TECHNOLOGY_LINE_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PARTS_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pleft_2.SuspendLayout();
            this.pRight.SuspendLayout();
            this.pRight_2.SuspendLayout();
            this.pLeft.SuspendLayout();
            this.pLeft_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.pInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pleft_2
            // 
            this.pleft_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pleft_2.Controls.Add(this.btnSlipNumber);
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
            // btnSlipNumber
            // 
            this.btnSlipNumber.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnSlipNumber.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSlipNumber.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSlipNumber.FlatAppearance.BorderSize = 0;
            this.btnSlipNumber.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSlipNumber.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSlipNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSlipNumber.Location = new System.Drawing.Point(262, 6);
            this.btnSlipNumber.Name = "btnSlipNumber";
            this.btnSlipNumber.Size = new System.Drawing.Size(25, 25);
            this.btnSlipNumber.TabIndex = 20;
            this.btnSlipNumber.UseVisualStyleBackColor = true;
            this.btnSlipNumber.MouseLeave += new System.EventHandler(this.btnSlipNumber_MouseLeave);
            this.btnSlipNumber.Click += new System.EventHandler(this.btnSlipNumber_Click);
            this.btnSlipNumber.MouseEnter += new System.EventHandler(this.btnSlipNumber_MouseEnter);
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(5, 126);
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
            this.btnSlipType.Location = new System.Drawing.Point(262, 67);
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
            this.label5.Location = new System.Drawing.Point(118, 38);
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
            this.dateTimePicker2.Location = new System.Drawing.Point(141, 36);
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
            this.dateTimePicker1.Location = new System.Drawing.Point(5, 36);
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
            this.txtSlipTypeName.Location = new System.Drawing.Point(6, 96);
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
            this.txtSlipType.Location = new System.Drawing.Point(6, 66);
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
            this.pRight_2.Controls.Add(this.btnSeaarch);
            this.pRight_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRight_2.Location = new System.Drawing.Point(120, 0);
            this.pRight_2.Name = "pRight_2";
            this.pRight_2.Size = new System.Drawing.Size(378, 183);
            this.pRight_2.TabIndex = 4;
            // 
            // btnSeaarch
            // 
            this.btnSeaarch.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSeaarch.Location = new System.Drawing.Point(285, 150);
            this.btnSeaarch.Name = "btnSeaarch";
            this.btnSeaarch.Size = new System.Drawing.Size(90, 30);
            this.btnSeaarch.TabIndex = 6;
            this.btnSeaarch.Text = "查　询";
            this.btnSeaarch.UseVisualStyleBackColor = true;
            this.btnSeaarch.Click += new System.EventHandler(this.btnSeaarch_Click);
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
            // pLeft_1
            // 
            this.pLeft_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pLeft_1.Controls.Add(this.label12);
            this.pLeft_1.Controls.Add(this.label3);
            this.pLeft_1.Controls.Add(this.label1);
            this.pLeft_1.Controls.Add(this.label6);
            this.pLeft_1.Controls.Add(this.label4);
            this.pLeft_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeft_1.Location = new System.Drawing.Point(0, 0);
            this.pLeft_1.Name = "pLeft_1";
            this.pLeft_1.Size = new System.Drawing.Size(120, 183);
            this.pLeft_1.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(5, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 20);
            this.label12.TabIndex = 7;
            this.label12.Text = "计划完成日期";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "模具种类编号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(5, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "状态";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "模具种类名称";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.SLIP_NUMBER,
            this.TYPE_NAME,
            this.PARTS_NAME,
            this.PRODUCTION_PROCESS_NAME,
            this.BT_TECHNOLOGY_NAME,
            this.BTN_DOWN_LOAD,
            this.START_PLAN_DATE,
            this.END_PLAN_DATE,
            this.START_DATE,
            this.END_DATE,
            this.WEIGHT,
            this.PRODUCTION_PROCESS_CODE,
            this.PSPP_LINE_NUMBER,
            this.SCHEDULE_LINE_NUNBER,
            this.PSPP_STATUS_FLAG,
            this.PST_STATUS_FLAG,
            this.PST_SCHEDULE_LINE_NUMBER,
            this.PST_SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER,
            this.PST_TECHNOLOGY_LINE_NUMBER,
            this.PARTS_CODE});
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
            // pInfo
            // 
            this.pInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pInfo.Controls.Add(this.btnExport);
            this.pInfo.Controls.Add(this.btnEnd);
            this.pInfo.Controls.Add(this.pLeft);
            this.pInfo.Controls.Add(this.pRight);
            this.pInfo.Controls.Add(this.btnClose);
            this.pInfo.Controls.Add(this.dgvData);
            this.pInfo.Location = new System.Drawing.Point(0, 0);
            this.pInfo.Name = "pInfo";
            this.pInfo.Size = new System.Drawing.Size(1024, 643);
            this.pInfo.TabIndex = 12;
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnExport.Location = new System.Drawing.Point(737, 607);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(90, 30);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "导　出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnEnd.Location = new System.Drawing.Point(833, 607);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(90, 30);
            this.btnEnd.TabIndex = 9;
            this.btnEnd.Text = "结　束";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn1.HeaderText = "图纸";
            this.dataGridViewImageColumn1.Image = global::CZZD.ERP.WinUI.Properties.Resources.line_download_over;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Width = 50;
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
            this.CHK.DataPropertyName = "CHK";
            this.CHK.HeaderText = "选择";
            this.CHK.Name = "CHK";
            this.CHK.Width = 40;
            // 
            // SLIP_NUMBER
            // 
            this.SLIP_NUMBER.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SLIP_NUMBER.DataPropertyName = "SLIP_NUMBER";
            this.SLIP_NUMBER.HeaderText = "生产工单编号";
            this.SLIP_NUMBER.Name = "SLIP_NUMBER";
            this.SLIP_NUMBER.ReadOnly = true;
            this.SLIP_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SLIP_NUMBER.Width = 110;
            // 
            // TYPE_NAME
            // 
            this.TYPE_NAME.DataPropertyName = "SLIP_TYPE_NAME";
            this.TYPE_NAME.HeaderText = "模具种类";
            this.TYPE_NAME.Name = "TYPE_NAME";
            this.TYPE_NAME.ReadOnly = true;
            this.TYPE_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PARTS_NAME
            // 
            this.PARTS_NAME.DataPropertyName = "PARTS_NAME";
            this.PARTS_NAME.HeaderText = "部件";
            this.PARTS_NAME.Name = "PARTS_NAME";
            this.PARTS_NAME.ReadOnly = true;
            this.PARTS_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PRODUCTION_PROCESS_NAME
            // 
            this.PRODUCTION_PROCESS_NAME.DataPropertyName = "PRODUCTION_PROCESS_NAME";
            this.PRODUCTION_PROCESS_NAME.HeaderText = "工序";
            this.PRODUCTION_PROCESS_NAME.Name = "PRODUCTION_PROCESS_NAME";
            this.PRODUCTION_PROCESS_NAME.ReadOnly = true;
            this.PRODUCTION_PROCESS_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // BT_TECHNOLOGY_NAME
            // 
            this.BT_TECHNOLOGY_NAME.DataPropertyName = "BT_TECHNOLOGY_NAME";
            this.BT_TECHNOLOGY_NAME.HeaderText = "技术";
            this.BT_TECHNOLOGY_NAME.Name = "BT_TECHNOLOGY_NAME";
            this.BT_TECHNOLOGY_NAME.ReadOnly = true;
            this.BT_TECHNOLOGY_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // BTN_DOWN_LOAD
            // 
            this.BTN_DOWN_LOAD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.BTN_DOWN_LOAD.DataPropertyName = "BTN_DOWN_LOAD";
            this.BTN_DOWN_LOAD.HeaderText = "图纸";
            this.BTN_DOWN_LOAD.Name = "BTN_DOWN_LOAD";
            this.BTN_DOWN_LOAD.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BTN_DOWN_LOAD.Width = 50;
            // 
            // START_PLAN_DATE
            // 
            this.START_PLAN_DATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "yyyy-MM-dd";
            dataGridViewCellStyle3.NullValue = null;
            this.START_PLAN_DATE.DefaultCellStyle = dataGridViewCellStyle3;
            this.START_PLAN_DATE.HeaderText = "预定开始日期";
            this.START_PLAN_DATE.Name = "START_PLAN_DATE";
            this.START_PLAN_DATE.ReadOnly = true;
            this.START_PLAN_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.START_PLAN_DATE.Visible = false;
            this.START_PLAN_DATE.Width = 85;
            // 
            // END_PLAN_DATE
            // 
            this.END_PLAN_DATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.END_PLAN_DATE.DataPropertyName = "PST_PLAN_END_DATE";
            dataGridViewCellStyle4.Format = "yyyy-MM-dd";
            this.END_PLAN_DATE.DefaultCellStyle = dataGridViewCellStyle4;
            this.END_PLAN_DATE.HeaderText = "预定完成日期";
            this.END_PLAN_DATE.Name = "END_PLAN_DATE";
            this.END_PLAN_DATE.ReadOnly = true;
            this.END_PLAN_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.END_PLAN_DATE.Width = 85;
            // 
            // START_DATE
            // 
            this.START_DATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Format = "yyyy-MM-dd";
            this.START_DATE.DefaultCellStyle = dataGridViewCellStyle5;
            this.START_DATE.HeaderText = "加工开始日期";
            this.START_DATE.Name = "START_DATE";
            this.START_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.START_DATE.Visible = false;
            this.START_DATE.Width = 85;
            // 
            // END_DATE
            // 
            this.END_DATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.END_DATE.DataPropertyName = "PST_ACTUAL_END_TIME";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle6.Format = "yyyy-MM-dd";
            this.END_DATE.DefaultCellStyle = dataGridViewCellStyle6;
            this.END_DATE.HeaderText = "加工结束时间";
            this.END_DATE.Name = "END_DATE";
            this.END_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.END_DATE.Width = 85;
            // 
            // WEIGHT
            // 
            this.WEIGHT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.WEIGHT.DataPropertyName = "WEIGHT";
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.WEIGHT.DefaultCellStyle = dataGridViewCellStyle7;
            this.WEIGHT.HeaderText = "重量(KG)";
            this.WEIGHT.Name = "WEIGHT";
            this.WEIGHT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.WEIGHT.Visible = false;
            this.WEIGHT.Width = 80;
            // 
            // PRODUCTION_PROCESS_CODE
            // 
            this.PRODUCTION_PROCESS_CODE.DataPropertyName = "PRODUCTION_PROCESS_CODE";
            this.PRODUCTION_PROCESS_CODE.HeaderText = "PRODUCTION_PROCESS_CODE";
            this.PRODUCTION_PROCESS_CODE.Name = "PRODUCTION_PROCESS_CODE";
            this.PRODUCTION_PROCESS_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PRODUCTION_PROCESS_CODE.Visible = false;
            // 
            // PSPP_LINE_NUMBER
            // 
            this.PSPP_LINE_NUMBER.DataPropertyName = "PSPP_LINE_NUMBER";
            this.PSPP_LINE_NUMBER.HeaderText = "PSPP_LINE_NUMBER";
            this.PSPP_LINE_NUMBER.Name = "PSPP_LINE_NUMBER";
            this.PSPP_LINE_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PSPP_LINE_NUMBER.Visible = false;
            // 
            // SCHEDULE_LINE_NUNBER
            // 
            this.SCHEDULE_LINE_NUNBER.DataPropertyName = "SCHEDULE_LINE_NUNBER";
            this.SCHEDULE_LINE_NUNBER.HeaderText = "SCHEDULE_LINE_NUNBER";
            this.SCHEDULE_LINE_NUNBER.Name = "SCHEDULE_LINE_NUNBER";
            this.SCHEDULE_LINE_NUNBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SCHEDULE_LINE_NUNBER.Visible = false;
            // 
            // PSPP_STATUS_FLAG
            // 
            this.PSPP_STATUS_FLAG.DataPropertyName = "PSPP_STATUS_FLAG";
            this.PSPP_STATUS_FLAG.HeaderText = "PSPP_STATUS_FLAG";
            this.PSPP_STATUS_FLAG.Name = "PSPP_STATUS_FLAG";
            this.PSPP_STATUS_FLAG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PSPP_STATUS_FLAG.Visible = false;
            // 
            // PST_STATUS_FLAG
            // 
            this.PST_STATUS_FLAG.DataPropertyName = "PST_STATUS_FLAG";
            this.PST_STATUS_FLAG.HeaderText = "PST_STATUS_FLAG";
            this.PST_STATUS_FLAG.Name = "PST_STATUS_FLAG";
            this.PST_STATUS_FLAG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PST_STATUS_FLAG.Visible = false;
            // 
            // PST_SCHEDULE_LINE_NUMBER
            // 
            this.PST_SCHEDULE_LINE_NUMBER.DataPropertyName = "PST_SCHEDULE_LINE_NUMBER";
            this.PST_SCHEDULE_LINE_NUMBER.HeaderText = "PST_SCHEDULE_LINE_NUMBER";
            this.PST_SCHEDULE_LINE_NUMBER.Name = "PST_SCHEDULE_LINE_NUMBER";
            this.PST_SCHEDULE_LINE_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PST_SCHEDULE_LINE_NUMBER.Visible = false;
            // 
            // PST_SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER
            // 
            this.PST_SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER.DataPropertyName = "PST_SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER";
            this.PST_SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER.HeaderText = "PST_SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER";
            this.PST_SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER.Name = "PST_SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER";
            this.PST_SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PST_SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER.Visible = false;
            // 
            // PST_TECHNOLOGY_LINE_NUMBER
            // 
            this.PST_TECHNOLOGY_LINE_NUMBER.DataPropertyName = "PST_TECHNOLOGY_LINE_NUMBER";
            this.PST_TECHNOLOGY_LINE_NUMBER.HeaderText = "PST_TECHNOLOGY_LINE_NUMBER";
            this.PST_TECHNOLOGY_LINE_NUMBER.Name = "PST_TECHNOLOGY_LINE_NUMBER";
            this.PST_TECHNOLOGY_LINE_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PST_TECHNOLOGY_LINE_NUMBER.Visible = false;
            // 
            // PARTS_CODE
            // 
            this.PARTS_CODE.DataPropertyName = "PARTS_CODE";
            this.PARTS_CODE.HeaderText = "PARTS_CODE";
            this.PARTS_CODE.Name = "PARTS_CODE";
            this.PARTS_CODE.ReadOnly = true;
            this.PARTS_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PARTS_CODE.Visible = false;
            // 
            // FrmProductionTechnology
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1027, 657);
            this.Controls.Add(this.pInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmProductionTechnology";
            this.Text = "技术实绩输入";
            this.Load += new System.EventHandler(this.FrmProductionTechnology_Load);
            this.pleft_2.ResumeLayout(false);
            this.pleft_2.PerformLayout();
            this.pRight.ResumeLayout(false);
            this.pRight_2.ResumeLayout(false);
            this.pLeft.ResumeLayout(false);
            this.pLeft_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.pInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pleft_2;
        private System.Windows.Forms.Button btnSlipType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtSlipTypeName;
        private System.Windows.Forms.TextBox txtSlipType;
        private System.Windows.Forms.TextBox txtSlipNumber;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.Panel pRight_2;
        private System.Windows.Forms.Button btnSeaarch;
        private System.Windows.Forms.Panel pRight_1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.Panel pLeft_1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Panel pInfo;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Button btnSlipNumber;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CHK;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLIP_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn TYPE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PARTS_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCTION_PROCESS_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn BT_TECHNOLOGY_NAME;
        private System.Windows.Forms.DataGridViewLinkColumn BTN_DOWN_LOAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn START_PLAN_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn END_PLAN_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn START_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn END_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn WEIGHT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCTION_PROCESS_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PSPP_LINE_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn SCHEDULE_LINE_NUNBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn PSPP_STATUS_FLAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn PST_STATUS_FLAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn PST_SCHEDULE_LINE_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn PST_SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn PST_TECHNOLOGY_LINE_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn PARTS_CODE;
    }
}