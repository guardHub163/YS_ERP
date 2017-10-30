namespace CZZD.ERP.WinUI
{
    partial class FrmProductionPlan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProductionPlan));
            this.label1 = new System.Windows.Forms.Label();
            this.txtDepartualDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.pleft_2 = new System.Windows.Forms.Panel();
            this.cboSlipType = new System.Windows.Forms.ComboBox();
            this.btnOrderSlipNumber = new System.Windows.Forms.Button();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtOrderQuantity = new System.Windows.Forms.TextBox();
            this.txtSpec = new System.Windows.Forms.TextBox();
            this.txtSlipNumber = new System.Windows.Forms.TextBox();
            this.txtOrderSlipNumber = new System.Windows.Forms.TextBox();
            this.txtSlipDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.pLeft_1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pLeft = new System.Windows.Forms.Panel();
            this.pRight_1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pRight = new System.Windows.Forms.Panel();
            this.pRight_2 = new System.Windows.Forms.Panel();
            this.btnCreatePlan = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.txtProductionQuantity = new System.Windows.Forms.TextBox();
            this.pInfo = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TYPE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PARTS_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PLAN_START_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PLAN_END_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PLAN_QUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TYPE_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PARTS_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROCESS_CHK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BTN_PRODUCTION_PROCESS = new System.Windows.Forms.DataGridViewImageColumn();
            this.BTN_DELETE = new System.Windows.Forms.DataGridViewImageColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvDrawing = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvTechnology = new System.Windows.Forms.DataGridView();
            this.Technology_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMPOSITION_PRODUCTS_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMPOSITION_PROCESS_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TECHNOLOGY_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TECHNOLOGY_PLAN_END_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TECHNOLOGY_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMPOSITION_PRODUCTS_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCTION_PROCESS_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TECHNOLOGYFLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TECHNOLOGY_STATUS_FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TECHNOLOGY_BTN_DELETE = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnAddParts = new System.Windows.Forms.Button();
            this.btnAddDraw = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.DRAWING_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DRAWING_TYPE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DRAWING_PLAN_END_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DRAWING_TYPE_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DRAWINGFLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DRAWING_BTN_DELETE = new System.Windows.Forms.DataGridViewImageColumn();
            this.pleft_2.SuspendLayout();
            this.pLeft_1.SuspendLayout();
            this.pLeft.SuspendLayout();
            this.pRight_1.SuspendLayout();
            this.pRight.SuspendLayout();
            this.pRight_2.SuspendLayout();
            this.pInfo.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDrawing)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTechnology)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(120, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 19);
            this.label1.TabIndex = 15;
            // 
            // txtDepartualDateFrom
            // 
            this.txtDepartualDateFrom.CalendarFont = new System.Drawing.Font("微软雅黑", 10F);
            this.txtDepartualDateFrom.Checked = false;
            this.txtDepartualDateFrom.CustomFormat = "yyyy-MM-dd";
            this.txtDepartualDateFrom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDepartualDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDepartualDateFrom.Location = new System.Drawing.Point(5, 35);
            this.txtDepartualDateFrom.Name = "txtDepartualDateFrom";
            this.txtDepartualDateFrom.Size = new System.Drawing.Size(250, 23);
            this.txtDepartualDateFrom.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(5, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "预定交货日期";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pleft_2
            // 
            this.pleft_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pleft_2.Controls.Add(this.cboSlipType);
            this.pleft_2.Controls.Add(this.btnOrderSlipNumber);
            this.pleft_2.Controls.Add(this.label1);
            this.pleft_2.Controls.Add(this.txtQuantity);
            this.pleft_2.Controls.Add(this.txtOrderQuantity);
            this.pleft_2.Controls.Add(this.txtSpec);
            this.pleft_2.Controls.Add(this.txtSlipNumber);
            this.pleft_2.Controls.Add(this.txtOrderSlipNumber);
            this.pleft_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pleft_2.Location = new System.Drawing.Point(120, 0);
            this.pleft_2.Name = "pleft_2";
            this.pleft_2.Size = new System.Drawing.Size(388, 183);
            this.pleft_2.TabIndex = 5;
            // 
            // cboSlipType
            // 
            this.cboSlipType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSlipType.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cboSlipType.FormattingEnabled = true;
            this.cboSlipType.Location = new System.Drawing.Point(5, 65);
            this.cboSlipType.Name = "cboSlipType";
            this.cboSlipType.Size = new System.Drawing.Size(250, 25);
            this.cboSlipType.TabIndex = 18;
            this.cboSlipType.SelectedIndexChanged += new System.EventHandler(this.cboSlipType_SelectedIndexChanged);
            // 
            // btnOrderSlipNumber
            // 
            this.btnOrderSlipNumber.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnOrderSlipNumber.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOrderSlipNumber.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrderSlipNumber.FlatAppearance.BorderSize = 0;
            this.btnOrderSlipNumber.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnOrderSlipNumber.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOrderSlipNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderSlipNumber.Location = new System.Drawing.Point(261, 35);
            this.btnOrderSlipNumber.Name = "btnOrderSlipNumber";
            this.btnOrderSlipNumber.Size = new System.Drawing.Size(25, 25);
            this.btnOrderSlipNumber.TabIndex = 17;
            this.btnOrderSlipNumber.UseVisualStyleBackColor = true;
            this.btnOrderSlipNumber.MouseLeave += new System.EventHandler(this.btnOrderSlipNumber_MouseLeave);
            this.btnOrderSlipNumber.Click += new System.EventHandler(this.btnOrderSlipNumber_Click);
            this.btnOrderSlipNumber.MouseEnter += new System.EventHandler(this.btnOrderSlipNumber_MouseEnter);
            // 
            // txtQuantity
            // 
            this.txtQuantity.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuantity.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtQuantity.Location = new System.Drawing.Point(5, 155);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.ReadOnly = true;
            this.txtQuantity.Size = new System.Drawing.Size(250, 25);
            this.txtQuantity.TabIndex = 0;
            // 
            // txtOrderQuantity
            // 
            this.txtOrderQuantity.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtOrderQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderQuantity.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtOrderQuantity.Location = new System.Drawing.Point(5, 125);
            this.txtOrderQuantity.Name = "txtOrderQuantity";
            this.txtOrderQuantity.ReadOnly = true;
            this.txtOrderQuantity.Size = new System.Drawing.Size(250, 25);
            this.txtOrderQuantity.TabIndex = 0;
            // 
            // txtSpec
            // 
            this.txtSpec.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtSpec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSpec.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSpec.Location = new System.Drawing.Point(5, 95);
            this.txtSpec.Name = "txtSpec";
            this.txtSpec.ReadOnly = true;
            this.txtSpec.Size = new System.Drawing.Size(250, 25);
            this.txtSpec.TabIndex = 0;
            // 
            // txtSlipNumber
            // 
            this.txtSlipNumber.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtSlipNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSlipNumber.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSlipNumber.Location = new System.Drawing.Point(5, 5);
            this.txtSlipNumber.Name = "txtSlipNumber";
            this.txtSlipNumber.Size = new System.Drawing.Size(250, 25);
            this.txtSlipNumber.TabIndex = 0;
            // 
            // txtOrderSlipNumber
            // 
            this.txtOrderSlipNumber.BackColor = System.Drawing.SystemColors.Info;
            this.txtOrderSlipNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderSlipNumber.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtOrderSlipNumber.Location = new System.Drawing.Point(5, 35);
            this.txtOrderSlipNumber.Name = "txtOrderSlipNumber";
            this.txtOrderSlipNumber.Size = new System.Drawing.Size(250, 25);
            this.txtOrderSlipNumber.TabIndex = 0;
            this.txtOrderSlipNumber.Leave += new System.EventHandler(this.txtOrderSlipNumber_Leave);
            // 
            // txtSlipDateFrom
            // 
            this.txtSlipDateFrom.CalendarFont = new System.Drawing.Font("微软雅黑", 12F);
            this.txtSlipDateFrom.Checked = false;
            this.txtSlipDateFrom.CustomFormat = "yyyy-MM-dd";
            this.txtSlipDateFrom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSlipDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtSlipDateFrom.Location = new System.Drawing.Point(5, 5);
            this.txtSlipDateFrom.Name = "txtSlipDateFrom";
            this.txtSlipDateFrom.Size = new System.Drawing.Size(250, 23);
            this.txtSlipDateFrom.TabIndex = 11;
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
            this.label5.Text = "订单编号";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label17.TabIndex = 0;
            this.label17.Text = "订单日期";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pLeft_1
            // 
            this.pLeft_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pLeft_1.Controls.Add(this.label3);
            this.pLeft_1.Controls.Add(this.label9);
            this.pLeft_1.Controls.Add(this.label2);
            this.pLeft_1.Controls.Add(this.label6);
            this.pLeft_1.Controls.Add(this.label4);
            this.pLeft_1.Controls.Add(this.label5);
            this.pLeft_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeft_1.Location = new System.Drawing.Point(0, 0);
            this.pLeft_1.Name = "pLeft_1";
            this.pLeft_1.Size = new System.Drawing.Size(120, 183);
            this.pLeft_1.TabIndex = 4;
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
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(5, 155);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "己计划数量";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "订单数量";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(5, 95);
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
            this.label4.Location = new System.Drawing.Point(5, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "模具种类";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // pRight_1
            // 
            this.pRight_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pRight_1.Controls.Add(this.label8);
            this.pRight_1.Controls.Add(this.label12);
            this.pRight_1.Controls.Add(this.label11);
            this.pRight_1.Controls.Add(this.label10);
            this.pRight_1.Controls.Add(this.label7);
            this.pRight_1.Controls.Add(this.label17);
            this.pRight_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pRight_1.Location = new System.Drawing.Point(0, 0);
            this.pRight_1.Name = "pRight_1";
            this.pRight_1.Size = new System.Drawing.Size(120, 183);
            this.pRight_1.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(5, 125);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 20);
            this.label12.TabIndex = 0;
            this.label12.Text = "计划完成日期";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(5, 95);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "计划开始日期";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(5, 155);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "备注";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label7.Text = "计划数量";
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
            this.pRight.Size = new System.Drawing.Size(500, 185);
            this.pRight.TabIndex = 7;
            // 
            // pRight_2
            // 
            this.pRight_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pRight_2.Controls.Add(this.btnCreatePlan);
            this.pRight_2.Controls.Add(this.dateTimePicker2);
            this.pRight_2.Controls.Add(this.dateTimePicker1);
            this.pRight_2.Controls.Add(this.txtDepartualDateFrom);
            this.pRight_2.Controls.Add(this.txtMemo);
            this.pRight_2.Controls.Add(this.txtProductionQuantity);
            this.pRight_2.Controls.Add(this.txtSlipDateFrom);
            this.pRight_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRight_2.Location = new System.Drawing.Point(120, 0);
            this.pRight_2.Name = "pRight_2";
            this.pRight_2.Size = new System.Drawing.Size(378, 183);
            this.pRight_2.TabIndex = 4;
            // 
            // btnCreatePlan
            // 
            this.btnCreatePlan.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnCreatePlan.Location = new System.Drawing.Point(285, 150);
            this.btnCreatePlan.Name = "btnCreatePlan";
            this.btnCreatePlan.Size = new System.Drawing.Size(90, 30);
            this.btnCreatePlan.TabIndex = 6;
            this.btnCreatePlan.Text = "生成计划";
            this.btnCreatePlan.UseVisualStyleBackColor = true;
            this.btnCreatePlan.Click += new System.EventHandler(this.btnCreatePlan_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("微软雅黑", 10F);
            this.dateTimePicker2.Checked = false;
            this.dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(5, 125);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(250, 23);
            this.dateTimePicker2.TabIndex = 14;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("微软雅黑", 10F);
            this.dateTimePicker1.Checked = false;
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(5, 95);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(250, 23);
            this.dateTimePicker1.TabIndex = 14;
            // 
            // txtMemo
            // 
            this.txtMemo.BackColor = System.Drawing.SystemColors.Info;
            this.txtMemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMemo.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtMemo.Location = new System.Drawing.Point(5, 155);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(250, 25);
            this.txtMemo.TabIndex = 0;
            // 
            // txtProductionQuantity
            // 
            this.txtProductionQuantity.BackColor = System.Drawing.SystemColors.Info;
            this.txtProductionQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductionQuantity.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtProductionQuantity.Location = new System.Drawing.Point(5, 65);
            this.txtProductionQuantity.Name = "txtProductionQuantity";
            this.txtProductionQuantity.Size = new System.Drawing.Size(250, 25);
            this.txtProductionQuantity.TabIndex = 0;
            this.txtProductionQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtProductionQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // pInfo
            // 
            this.pInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pInfo.Controls.Add(this.tabControl1);
            this.pInfo.Controls.Add(this.btnAddParts);
            this.pInfo.Controls.Add(this.btnAddDraw);
            this.pInfo.Controls.Add(this.btnSave);
            this.pInfo.Controls.Add(this.pLeft);
            this.pInfo.Controls.Add(this.pRight);
            this.pInfo.Controls.Add(this.btnClose);
            this.pInfo.Location = new System.Drawing.Point(1, 2);
            this.pInfo.Name = "pInfo";
            this.pInfo.Size = new System.Drawing.Size(1024, 643);
            this.pInfo.TabIndex = 9;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.tabControl1.Location = new System.Drawing.Point(3, 192);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1010, 407);
            this.tabControl1.TabIndex = 9;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvData);
            this.tabPage1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1002, 375);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "　部件　";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NO,
            this.TYPE_NAME,
            this.PARTS_NAME,
            this.PLAN_START_DATE,
            this.PLAN_END_DATE,
            this.PLAN_QUANTITY,
            this.SPEC,
            this.TYPE_CODE,
            this.PARTS_CODE,
            this.PROCESS_CHK,
            this.BTN_PRODUCTION_PROCESS,
            this.BTN_DELETE});
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvData.Location = new System.Drawing.Point(3, 3);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 45;
            this.dgvData.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(996, 369);
            this.dgvData.TabIndex = 0;
            this.dgvData.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellValidated);
            this.dgvData.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvData_CellPainting);
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);
            this.dgvData.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvData_EditingControlShowing);
            // 
            // NO
            // 
            this.NO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NO.DataPropertyName = "NO";
            dataGridViewCellStyle2.NullValue = null;
            this.NO.DefaultCellStyle = dataGridViewCellStyle2;
            this.NO.Frozen = true;
            this.NO.HeaderText = "No";
            this.NO.Name = "NO";
            this.NO.ReadOnly = true;
            this.NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NO.Width = 35;
            // 
            // TYPE_NAME
            // 
            this.TYPE_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TYPE_NAME.DataPropertyName = "TYPE_NAME";
            this.TYPE_NAME.Frozen = true;
            this.TYPE_NAME.HeaderText = "模具种类";
            this.TYPE_NAME.Name = "TYPE_NAME";
            this.TYPE_NAME.ReadOnly = true;
            this.TYPE_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TYPE_NAME.Width = 200;
            // 
            // PARTS_NAME
            // 
            this.PARTS_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PARTS_NAME.DataPropertyName = "PARTS_NAME";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "yyyy-MM-dd";
            dataGridViewCellStyle3.NullValue = null;
            this.PARTS_NAME.DefaultCellStyle = dataGridViewCellStyle3;
            this.PARTS_NAME.Frozen = true;
            this.PARTS_NAME.HeaderText = "模具部件";
            this.PARTS_NAME.Name = "PARTS_NAME";
            this.PARTS_NAME.ReadOnly = true;
            this.PARTS_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PARTS_NAME.Width = 200;
            // 
            // PLAN_START_DATE
            // 
            this.PLAN_START_DATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PLAN_START_DATE.DataPropertyName = "PLAN_START_DATE";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "yyyy-MM-dd";
            dataGridViewCellStyle4.NullValue = null;
            this.PLAN_START_DATE.DefaultCellStyle = dataGridViewCellStyle4;
            this.PLAN_START_DATE.Frozen = true;
            this.PLAN_START_DATE.HeaderText = "预定开始日期";
            this.PLAN_START_DATE.Name = "PLAN_START_DATE";
            this.PLAN_START_DATE.ReadOnly = true;
            this.PLAN_START_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PLAN_START_DATE.Width = 120;
            // 
            // PLAN_END_DATE
            // 
            this.PLAN_END_DATE.DataPropertyName = "PLAN_END_DATE";
            dataGridViewCellStyle5.Format = "yyyy-MM-dd";
            this.PLAN_END_DATE.DefaultCellStyle = dataGridViewCellStyle5;
            this.PLAN_END_DATE.HeaderText = "预定完成日期";
            this.PLAN_END_DATE.Name = "PLAN_END_DATE";
            this.PLAN_END_DATE.ReadOnly = true;
            this.PLAN_END_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PLAN_QUANTITY
            // 
            this.PLAN_QUANTITY.DataPropertyName = "PLAN_QUANTITY";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.PLAN_QUANTITY.DefaultCellStyle = dataGridViewCellStyle6;
            this.PLAN_QUANTITY.HeaderText = "计划数量";
            this.PLAN_QUANTITY.Name = "PLAN_QUANTITY";
            this.PLAN_QUANTITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SPEC
            // 
            this.SPEC.DataPropertyName = "SPEC";
            this.SPEC.HeaderText = "尺寸";
            this.SPEC.Name = "SPEC";
            this.SPEC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SPEC.Visible = false;
            // 
            // TYPE_CODE
            // 
            this.TYPE_CODE.DataPropertyName = "TYPE_CODE";
            this.TYPE_CODE.HeaderText = "TYPE_CODE";
            this.TYPE_CODE.Name = "TYPE_CODE";
            this.TYPE_CODE.ReadOnly = true;
            this.TYPE_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TYPE_CODE.Visible = false;
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
            // PROCESS_CHK
            // 
            this.PROCESS_CHK.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PROCESS_CHK.DataPropertyName = "PROCESS_CHK";
            this.PROCESS_CHK.HeaderText = "进度跟踪项";
            this.PROCESS_CHK.Name = "PROCESS_CHK";
            this.PROCESS_CHK.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PROCESS_CHK.Width = 80;
            // 
            // BTN_PRODUCTION_PROCESS
            // 
            this.BTN_PRODUCTION_PROCESS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.BTN_PRODUCTION_PROCESS.DataPropertyName = "BTN_PRODUCTION_PROCESS";
            this.BTN_PRODUCTION_PROCESS.HeaderText = "工序编辑";
            this.BTN_PRODUCTION_PROCESS.Name = "BTN_PRODUCTION_PROCESS";
            this.BTN_PRODUCTION_PROCESS.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BTN_PRODUCTION_PROCESS.Width = 80;
            // 
            // BTN_DELETE
            // 
            this.BTN_DELETE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.BTN_DELETE.DataPropertyName = "BTN_DELETE";
            this.BTN_DELETE.HeaderText = "删除";
            this.BTN_DELETE.Name = "BTN_DELETE";
            this.BTN_DELETE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BTN_DELETE.Width = 60;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvDrawing);
            this.tabPage2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1002, 375);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "　图纸　";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvDrawing
            // 
            this.dgvDrawing.AllowUserToAddRows = false;
            this.dgvDrawing.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvDrawing.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDrawing.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDrawing.BackgroundColor = System.Drawing.Color.White;
            this.dgvDrawing.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDrawing.ColumnHeadersHeight = 25;
            this.dgvDrawing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDrawing.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DRAWING_NO,
            this.DRAWING_TYPE_NAME,
            this.DRAWING_PLAN_END_DATE,
            this.DRAWING_TYPE_CODE,
            this.FLAG,
            this.DRAWINGFLAG,
            this.DRAWING_BTN_DELETE});
            this.dgvDrawing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDrawing.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvDrawing.Location = new System.Drawing.Point(3, 3);
            this.dgvDrawing.MultiSelect = false;
            this.dgvDrawing.Name = "dgvDrawing";
            this.dgvDrawing.RowHeadersVisible = false;
            this.dgvDrawing.RowHeadersWidth = 45;
            this.dgvDrawing.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.dgvDrawing.RowTemplate.Height = 23;
            this.dgvDrawing.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDrawing.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDrawing.Size = new System.Drawing.Size(996, 369);
            this.dgvDrawing.TabIndex = 0;
            this.dgvDrawing.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDrawing_CellValidated);
            this.dgvDrawing.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvDrawing_CellPainting);
            this.dgvDrawing.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDrawing_CellClick);
            this.dgvDrawing.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDrawing_CellContentClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvTechnology);
            this.tabPage3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1002, 375);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "　技术　";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvTechnology
            // 
            this.dgvTechnology.AllowUserToAddRows = false;
            this.dgvTechnology.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvTechnology.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvTechnology.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTechnology.BackgroundColor = System.Drawing.Color.White;
            this.dgvTechnology.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvTechnology.ColumnHeadersHeight = 25;
            this.dgvTechnology.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTechnology.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Technology_NO,
            this.COMPOSITION_PRODUCTS_NAME,
            this.COMPOSITION_PROCESS_NAME,
            this.TECHNOLOGY_NAME,
            this.TECHNOLOGY_PLAN_END_DATE,
            this.TECHNOLOGY_CODE,
            this.COMPOSITION_PRODUCTS_CODE,
            this.PRODUCTION_PROCESS_CODE,
            this.TECHNOLOGYFLAG,
            this.TECHNOLOGY_STATUS_FLAG,
            this.TECHNOLOGY_BTN_DELETE});
            this.dgvTechnology.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTechnology.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvTechnology.Location = new System.Drawing.Point(3, 3);
            this.dgvTechnology.MultiSelect = false;
            this.dgvTechnology.Name = "dgvTechnology";
            this.dgvTechnology.RowHeadersVisible = false;
            this.dgvTechnology.RowHeadersWidth = 45;
            this.dgvTechnology.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.dgvTechnology.RowTemplate.Height = 23;
            this.dgvTechnology.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTechnology.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTechnology.Size = new System.Drawing.Size(996, 369);
            this.dgvTechnology.TabIndex = 1;
            this.dgvTechnology.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTechnology_CellValidated);
            this.dgvTechnology.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvTechnology_CellPainting);
            this.dgvTechnology.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTechnology_CellClick);
            // 
            // Technology_NO
            // 
            this.Technology_NO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle11.NullValue = null;
            this.Technology_NO.DefaultCellStyle = dataGridViewCellStyle11;
            this.Technology_NO.Frozen = true;
            this.Technology_NO.HeaderText = "No";
            this.Technology_NO.Name = "Technology_NO";
            this.Technology_NO.ReadOnly = true;
            this.Technology_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Technology_NO.Width = 35;
            // 
            // COMPOSITION_PRODUCTS_NAME
            // 
            this.COMPOSITION_PRODUCTS_NAME.HeaderText = "部件名称";
            this.COMPOSITION_PRODUCTS_NAME.Name = "COMPOSITION_PRODUCTS_NAME";
            this.COMPOSITION_PRODUCTS_NAME.ReadOnly = true;
            this.COMPOSITION_PRODUCTS_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // COMPOSITION_PROCESS_NAME
            // 
            this.COMPOSITION_PROCESS_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.COMPOSITION_PROCESS_NAME.HeaderText = "工序名称";
            this.COMPOSITION_PROCESS_NAME.Name = "COMPOSITION_PROCESS_NAME";
            this.COMPOSITION_PROCESS_NAME.ReadOnly = true;
            this.COMPOSITION_PROCESS_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.COMPOSITION_PROCESS_NAME.Width = 120;
            // 
            // TECHNOLOGY_NAME
            // 
            this.TECHNOLOGY_NAME.DataPropertyName = "TECHNOLOGY_NAME";
            this.TECHNOLOGY_NAME.HeaderText = "技术名称";
            this.TECHNOLOGY_NAME.Name = "TECHNOLOGY_NAME";
            this.TECHNOLOGY_NAME.ReadOnly = true;
            this.TECHNOLOGY_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TECHNOLOGY_PLAN_END_DATE
            // 
            this.TECHNOLOGY_PLAN_END_DATE.DataPropertyName = "PST_PLAN_END_DATE";
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle12.Format = "yyyy-MM-dd";
            this.TECHNOLOGY_PLAN_END_DATE.DefaultCellStyle = dataGridViewCellStyle12;
            this.TECHNOLOGY_PLAN_END_DATE.HeaderText = "预定结束时间";
            this.TECHNOLOGY_PLAN_END_DATE.Name = "TECHNOLOGY_PLAN_END_DATE";
            this.TECHNOLOGY_PLAN_END_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TECHNOLOGY_CODE
            // 
            this.TECHNOLOGY_CODE.DataPropertyName = "TECHNOLOGY_CODE";
            this.TECHNOLOGY_CODE.HeaderText = "TECHNOLOGY_CODE";
            this.TECHNOLOGY_CODE.Name = "TECHNOLOGY_CODE";
            this.TECHNOLOGY_CODE.ReadOnly = true;
            this.TECHNOLOGY_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TECHNOLOGY_CODE.Visible = false;
            // 
            // COMPOSITION_PRODUCTS_CODE
            // 
            this.COMPOSITION_PRODUCTS_CODE.DataPropertyName = "COMPOSITION_PRODUCTS_CODE";
            this.COMPOSITION_PRODUCTS_CODE.HeaderText = "COMPOSITION_PRODUCTS_CODE";
            this.COMPOSITION_PRODUCTS_CODE.Name = "COMPOSITION_PRODUCTS_CODE";
            this.COMPOSITION_PRODUCTS_CODE.ReadOnly = true;
            this.COMPOSITION_PRODUCTS_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.COMPOSITION_PRODUCTS_CODE.Visible = false;
            // 
            // PRODUCTION_PROCESS_CODE
            // 
            this.PRODUCTION_PROCESS_CODE.DataPropertyName = "PRODUCTION_PROCESS_CODE";
            this.PRODUCTION_PROCESS_CODE.HeaderText = "PRODUCTION_PROCESS_CODE";
            this.PRODUCTION_PROCESS_CODE.Name = "PRODUCTION_PROCESS_CODE";
            this.PRODUCTION_PROCESS_CODE.ReadOnly = true;
            this.PRODUCTION_PROCESS_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PRODUCTION_PROCESS_CODE.Visible = false;
            // 
            // TECHNOLOGYFLAG
            // 
            this.TECHNOLOGYFLAG.HeaderText = "TECHNOLOGYFLAG";
            this.TECHNOLOGYFLAG.Name = "TECHNOLOGYFLAG";
            this.TECHNOLOGYFLAG.ReadOnly = true;
            this.TECHNOLOGYFLAG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TECHNOLOGYFLAG.Visible = false;
            // 
            // TECHNOLOGY_STATUS_FLAG
            // 
            this.TECHNOLOGY_STATUS_FLAG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TECHNOLOGY_STATUS_FLAG.HeaderText = "状态";
            this.TECHNOLOGY_STATUS_FLAG.Name = "TECHNOLOGY_STATUS_FLAG";
            this.TECHNOLOGY_STATUS_FLAG.ReadOnly = true;
            this.TECHNOLOGY_STATUS_FLAG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TECHNOLOGY_STATUS_FLAG.Width = 80;
            // 
            // TECHNOLOGY_BTN_DELETE
            // 
            this.TECHNOLOGY_BTN_DELETE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TECHNOLOGY_BTN_DELETE.HeaderText = "删除";
            this.TECHNOLOGY_BTN_DELETE.Name = "TECHNOLOGY_BTN_DELETE";
            this.TECHNOLOGY_BTN_DELETE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TECHNOLOGY_BTN_DELETE.Width = 65;
            // 
            // btnAddParts
            // 
            this.btnAddParts.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnAddParts.Location = new System.Drawing.Point(4, 605);
            this.btnAddParts.Name = "btnAddParts";
            this.btnAddParts.Size = new System.Drawing.Size(104, 30);
            this.btnAddParts.TabIndex = 6;
            this.btnAddParts.Text = "增加部件";
            this.btnAddParts.UseVisualStyleBackColor = true;
            this.btnAddParts.Click += new System.EventHandler(this.btnAddParts_Click);
            // 
            // btnAddDraw
            // 
            this.btnAddDraw.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnAddDraw.Location = new System.Drawing.Point(4, 605);
            this.btnAddDraw.Name = "btnAddDraw";
            this.btnAddDraw.Size = new System.Drawing.Size(104, 30);
            this.btnAddDraw.TabIndex = 6;
            this.btnAddDraw.Text = "增加图纸类型　";
            this.btnAddDraw.UseVisualStyleBackColor = true;
            this.btnAddDraw.Click += new System.EventHandler(this.btnAddDraw_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSave.Location = new System.Drawing.Point(829, 607);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保　存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            // DRAWING_NO
            // 
            this.DRAWING_NO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DRAWING_NO.DataPropertyName = "DRAWING_NO";
            dataGridViewCellStyle8.NullValue = null;
            this.DRAWING_NO.DefaultCellStyle = dataGridViewCellStyle8;
            this.DRAWING_NO.Frozen = true;
            this.DRAWING_NO.HeaderText = "No";
            this.DRAWING_NO.Name = "DRAWING_NO";
            this.DRAWING_NO.ReadOnly = true;
            this.DRAWING_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DRAWING_NO.Width = 35;
            // 
            // DRAWING_TYPE_NAME
            // 
            this.DRAWING_TYPE_NAME.DataPropertyName = "DRAWING_TYPE_NAME";
            this.DRAWING_TYPE_NAME.HeaderText = "图纸类型";
            this.DRAWING_TYPE_NAME.Name = "DRAWING_TYPE_NAME";
            this.DRAWING_TYPE_NAME.ReadOnly = true;
            this.DRAWING_TYPE_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DRAWING_PLAN_END_DATE
            // 
            this.DRAWING_PLAN_END_DATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DRAWING_PLAN_END_DATE.DataPropertyName = "DRAWING_PLAN_END_DATE";
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle9.Format = "yyyy-MM-dd";
            this.DRAWING_PLAN_END_DATE.DefaultCellStyle = dataGridViewCellStyle9;
            this.DRAWING_PLAN_END_DATE.HeaderText = "预定完成日期";
            this.DRAWING_PLAN_END_DATE.Name = "DRAWING_PLAN_END_DATE";
            this.DRAWING_PLAN_END_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DRAWING_PLAN_END_DATE.Width = 120;
            // 
            // DRAWING_TYPE_CODE
            // 
            this.DRAWING_TYPE_CODE.DataPropertyName = "DRAWING_TYPE_CODE";
            this.DRAWING_TYPE_CODE.HeaderText = "DRAWING_TYPE_CODE";
            this.DRAWING_TYPE_CODE.Name = "DRAWING_TYPE_CODE";
            this.DRAWING_TYPE_CODE.ReadOnly = true;
            this.DRAWING_TYPE_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DRAWING_TYPE_CODE.Visible = false;
            // 
            // FLAG
            // 
            this.FLAG.HeaderText = "FLAG";
            this.FLAG.Name = "FLAG";
            this.FLAG.ReadOnly = true;
            this.FLAG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FLAG.Visible = false;
            // 
            // DRAWINGFLAG
            // 
            this.DRAWINGFLAG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DRAWINGFLAG.HeaderText = "状态";
            this.DRAWINGFLAG.Name = "DRAWINGFLAG";
            this.DRAWINGFLAG.ReadOnly = true;
            this.DRAWINGFLAG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DRAWINGFLAG.Width = 80;
            // 
            // DRAWING_BTN_DELETE
            // 
            this.DRAWING_BTN_DELETE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DRAWING_BTN_DELETE.DataPropertyName = "DRAWING_BTN_DELETE";
            this.DRAWING_BTN_DELETE.HeaderText = "删除";
            this.DRAWING_BTN_DELETE.Name = "DRAWING_BTN_DELETE";
            this.DRAWING_BTN_DELETE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DRAWING_BTN_DELETE.Width = 65;
            // 
            // FrmProductionPlan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1027, 647);
            this.Controls.Add(this.pInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmProductionPlan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "生产计划输入";
            this.Load += new System.EventHandler(this.FrmProductionPlan_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmProductionPlan_FormClosed);
            this.pleft_2.ResumeLayout(false);
            this.pleft_2.PerformLayout();
            this.pLeft_1.ResumeLayout(false);
            this.pLeft.ResumeLayout(false);
            this.pRight_1.ResumeLayout(false);
            this.pRight.ResumeLayout(false);
            this.pRight_2.ResumeLayout(false);
            this.pRight_2.PerformLayout();
            this.pInfo.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDrawing)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTechnology)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtDepartualDateFrom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pleft_2;
        private System.Windows.Forms.DateTimePicker txtSlipDateFrom;
        private System.Windows.Forms.TextBox txtOrderSlipNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel pLeft_1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.Panel pRight_1;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.Panel pRight_2;
        private System.Windows.Forms.Panel pInfo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.TextBox txtSlipNumber;
        private System.Windows.Forms.Button btnOrderSlipNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboSlipType;
        private System.Windows.Forms.TextBox txtOrderQuantity;
        private System.Windows.Forms.TextBox txtSpec;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtProductionQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.Button btnAddParts;
        private System.Windows.Forms.DataGridView dgvDrawing;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnCreatePlan;
        private System.Windows.Forms.Button btnAddDraw;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvTechnology;
        private System.Windows.Forms.DataGridViewTextBoxColumn Technology_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMPOSITION_PRODUCTS_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMPOSITION_PROCESS_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn TECHNOLOGY_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn TECHNOLOGY_PLAN_END_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TECHNOLOGY_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMPOSITION_PRODUCTS_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCTION_PROCESS_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TECHNOLOGYFLAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn TECHNOLOGY_STATUS_FLAG;
        private System.Windows.Forms.DataGridViewImageColumn TECHNOLOGY_BTN_DELETE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn TYPE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PARTS_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PLAN_START_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PLAN_END_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PLAN_QUANTITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPEC;
        private System.Windows.Forms.DataGridViewTextBoxColumn TYPE_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PARTS_CODE;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PROCESS_CHK;
        private System.Windows.Forms.DataGridViewImageColumn BTN_PRODUCTION_PROCESS;
        private System.Windows.Forms.DataGridViewImageColumn BTN_DELETE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DRAWING_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DRAWING_TYPE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn DRAWING_PLAN_END_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DRAWING_TYPE_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn FLAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn DRAWINGFLAG;
        private System.Windows.Forms.DataGridViewImageColumn DRAWING_BTN_DELETE;
    }
}