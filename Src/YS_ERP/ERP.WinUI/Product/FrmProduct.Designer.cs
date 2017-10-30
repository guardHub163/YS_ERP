﻿namespace CZZD.ERP.WinUI
{
    partial class FrmProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProduct));
            this.pBody = new System.Windows.Forms.Panel();
            this.pSearch = new System.Windows.Forms.Panel();
            this.pRight = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cboDistinction = new System.Windows.Forms.ComboBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pLeft = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.txtGroupCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pgControl = new CZZD.ERP.ComControls.PageControl();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME_JP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODEL_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GROUP_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNIT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_ACCOUTING = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SALES_PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PURCHASE_PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SAFETY_STOCK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_STOCK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SELL_LOCATION_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PACKAGE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_PROPERTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FROMSET = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MECHANICAL_DISTINCTION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CREATE_USER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CREATE_DATE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LAST_UPDATE_USER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LAST_UPDATE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HSCODE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUPPLIER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MasterToolBar = new CZZD.ERP.ComControls.MasterToolBarControl();
            this.pBody.SuspendLayout();
            this.pSearch.SuspendLayout();
            this.pRight.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.pLeft.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // pBody
            // 
            this.pBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBody.Controls.Add(this.pSearch);
            this.pBody.Controls.Add(this.MasterToolBar);
            this.pBody.Location = new System.Drawing.Point(0, 0);
            this.pBody.Name = "pBody";
            this.pBody.Size = new System.Drawing.Size(1020, 650);
            this.pBody.TabIndex = 0;
            // 
            // pSearch
            // 
            this.pSearch.Controls.Add(this.pRight);
            this.pSearch.Controls.Add(this.pLeft);
            this.pSearch.Controls.Add(this.pgControl);
            this.pSearch.Controls.Add(this.dgvData);
            this.pSearch.Location = new System.Drawing.Point(3, 33);
            this.pSearch.Name = "pSearch";
            this.pSearch.Size = new System.Drawing.Size(1013, 614);
            this.pSearch.TabIndex = 14;
            // 
            // pRight
            // 
            this.pRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pRight.Controls.Add(this.panel5);
            this.pRight.Controls.Add(this.panel6);
            this.pRight.Location = new System.Drawing.Point(507, 0);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(506, 125);
            this.pRight.TabIndex = 18;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cboDistinction);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(118, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(386, 123);
            this.panel5.TabIndex = 1;
            // 
            // cboDistinction
            // 
            this.cboDistinction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDistinction.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.cboDistinction.FormattingEnabled = true;
            this.cboDistinction.Location = new System.Drawing.Point(5, 5);
            this.cboDistinction.Name = "cboDistinction";
            this.cboDistinction.Size = new System.Drawing.Size(250, 27);
            this.cboDistinction.TabIndex = 17;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.SteelBlue;
            this.panel6.Controls.Add(this.label5);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(118, 123);
            this.panel6.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.SteelBlue;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = " 类别区分：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pLeft
            // 
            this.pLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLeft.Controls.Add(this.panel4);
            this.pLeft.Controls.Add(this.panel3);
            this.pLeft.Location = new System.Drawing.Point(0, 0);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(506, 125);
            this.pLeft.TabIndex = 17;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtCode);
            this.panel4.Controls.Add(this.txtGroupName);
            this.panel4.Controls.Add(this.txtGroupCode);
            this.panel4.Controls.Add(this.txtName);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(118, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(386, 123);
            this.panel4.TabIndex = 1;
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtCode.Location = new System.Drawing.Point(5, 5);
            this.txtCode.MaxLength = 20;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(250, 25);
            this.txtCode.TabIndex = 10;
            // 
            // txtGroupName
            // 
            this.txtGroupName.BackColor = System.Drawing.SystemColors.Info;
            this.txtGroupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGroupName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtGroupName.Location = new System.Drawing.Point(5, 95);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(250, 25);
            this.txtGroupName.TabIndex = 12;
            // 
            // txtGroupCode
            // 
            this.txtGroupCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtGroupCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGroupCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtGroupCode.Location = new System.Drawing.Point(5, 65);
            this.txtGroupCode.Name = "txtGroupCode";
            this.txtGroupCode.Size = new System.Drawing.Size(250, 25);
            this.txtGroupCode.TabIndex = 12;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.Info;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtName.Location = new System.Drawing.Point(5, 35);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(250, 25);
            this.txtName.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(118, 123);
            this.panel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = " 商品编号：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.SteelBlue;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = " 类别名称：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = " 类别编号：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = " 商品名称：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pgControl
            // 
            this.pgControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pgControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pgControl.Location = new System.Drawing.Point(0, 584);
            this.pgControl.Name = "pgControl";
            this.pgControl.Size = new System.Drawing.Size(1013, 30);
            this.pgControl.TabIndex = 15;
            this.pgControl.TotalPage = 1;
            this.pgControl.PageChanged += new CZZD.ERP.ComControls.PageControl.BtnClickHandle(this.pgControl_PageChanged);
            // 
            // dgvData
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvData.ColumnHeadersHeight = 26;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CODE,
            this.NAME,
            this.NAME_JP,
            this.SPEC,
            this.MODEL_NUMBER,
            this.GROUP_NAME,
            this.UNIT_NAME,
            this.PRODUCT_ACCOUTING,
            this.SALES_PRICE,
            this.PURCHASE_PRICE,
            this.SAFETY_STOCK,
            this.PRODUCT_STOCK,
            this.SELL_LOCATION_NAME,
            this.PACKAGE_NAME,
            this.PRODUCT_PROPERTY,
            this.FROMSET,
            this.MECHANICAL_DISTINCTION,
            this.CREATE_USER,
            this.CREATE_DATE_TIME,
            this.LAST_UPDATE_USER,
            this.LAST_UPDATE_TIME,
            this.HSCODE_NAME,
            this.SUPPLIER_NAME});
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(0, 127);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1013, 457);
            this.dgvData.TabIndex = 14;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            this.dgvData.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvData_RowStateChanged);
            // 
            // CODE
            // 
            this.CODE.DataPropertyName = "CODE";
            this.CODE.FillWeight = 78.08133F;
            this.CODE.Frozen = true;
            this.CODE.HeaderText = "编号";
            this.CODE.Name = "CODE";
            this.CODE.ReadOnly = true;
            this.CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NAME
            // 
            this.NAME.DataPropertyName = "NAME";
            this.NAME.FillWeight = 78.37878F;
            this.NAME.Frozen = true;
            this.NAME.HeaderText = "名称";
            this.NAME.Name = "NAME";
            this.NAME.ReadOnly = true;
            this.NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NAME.Width = 120;
            // 
            // NAME_JP
            // 
            this.NAME_JP.DataPropertyName = "NAME_JP";
            this.NAME_JP.Frozen = true;
            this.NAME_JP.HeaderText = "日文名称";
            this.NAME_JP.Name = "NAME_JP";
            this.NAME_JP.Visible = false;
            // 
            // SPEC
            // 
            this.SPEC.DataPropertyName = "SPEC";
            this.SPEC.FillWeight = 77.93555F;
            this.SPEC.Frozen = true;
            this.SPEC.HeaderText = "规格";
            this.SPEC.Name = "SPEC";
            this.SPEC.ReadOnly = true;
            this.SPEC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SPEC.Width = 120;
            // 
            // MODEL_NUMBER
            // 
            this.MODEL_NUMBER.DataPropertyName = "MODEL_NUMBER";
            this.MODEL_NUMBER.FillWeight = 98.71358F;
            this.MODEL_NUMBER.HeaderText = "材质";
            this.MODEL_NUMBER.Name = "MODEL_NUMBER";
            this.MODEL_NUMBER.ReadOnly = true;
            this.MODEL_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MODEL_NUMBER.Width = 120;
            // 
            // GROUP_NAME
            // 
            this.GROUP_NAME.DataPropertyName = "GROUP_NAME";
            this.GROUP_NAME.FillWeight = 98.77917F;
            this.GROUP_NAME.HeaderText = "类别名称";
            this.GROUP_NAME.Name = "GROUP_NAME";
            this.GROUP_NAME.ReadOnly = true;
            this.GROUP_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // UNIT_NAME
            // 
            this.UNIT_NAME.DataPropertyName = "UNIT_NAME";
            this.UNIT_NAME.FillWeight = 98.353F;
            this.UNIT_NAME.HeaderText = "单位";
            this.UNIT_NAME.Name = "UNIT_NAME";
            this.UNIT_NAME.ReadOnly = true;
            this.UNIT_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UNIT_NAME.Width = 80;
            // 
            // PRODUCT_ACCOUTING
            // 
            this.PRODUCT_ACCOUTING.DataPropertyName = "PRODUCT_ACCOUTING";
            this.PRODUCT_ACCOUTING.FillWeight = 131.4457F;
            this.PRODUCT_ACCOUTING.HeaderText = "原价计算对象";
            this.PRODUCT_ACCOUTING.Name = "PRODUCT_ACCOUTING";
            this.PRODUCT_ACCOUTING.ReadOnly = true;
            this.PRODUCT_ACCOUTING.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PRODUCT_ACCOUTING.Visible = false;
            this.PRODUCT_ACCOUTING.Width = 102;
            // 
            // SALES_PRICE
            // 
            this.SALES_PRICE.DataPropertyName = "SALES_PRICE";
            this.SALES_PRICE.FillWeight = 98.85871F;
            this.SALES_PRICE.HeaderText = "默认售价";
            this.SALES_PRICE.Name = "SALES_PRICE";
            this.SALES_PRICE.ReadOnly = true;
            this.SALES_PRICE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PURCHASE_PRICE
            // 
            this.PURCHASE_PRICE.DataPropertyName = "PURCHASE_PRICE";
            this.PURCHASE_PRICE.HeaderText = "采购单价";
            this.PURCHASE_PRICE.Name = "PURCHASE_PRICE";
            this.PURCHASE_PRICE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SAFETY_STOCK
            // 
            this.SAFETY_STOCK.DataPropertyName = "SAFETY_STOCK";
            this.SAFETY_STOCK.HeaderText = "安全在库数";
            this.SAFETY_STOCK.Name = "SAFETY_STOCK";
            this.SAFETY_STOCK.ReadOnly = true;
            // 
            // PRODUCT_STOCK
            // 
            this.PRODUCT_STOCK.DataPropertyName = "PRODUCT_STOCK";
            this.PRODUCT_STOCK.FillWeight = 78.38911F;
            this.PRODUCT_STOCK.HeaderText = "在库";
            this.PRODUCT_STOCK.Name = "PRODUCT_STOCK";
            this.PRODUCT_STOCK.ReadOnly = true;
            this.PRODUCT_STOCK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PRODUCT_STOCK.Visible = false;
            this.PRODUCT_STOCK.Width = 80;
            // 
            // SELL_LOCATION_NAME
            // 
            this.SELL_LOCATION_NAME.DataPropertyName = "SELL_LOCATION_NAME";
            this.SELL_LOCATION_NAME.HeaderText = "销售地点";
            this.SELL_LOCATION_NAME.Name = "SELL_LOCATION_NAME";
            this.SELL_LOCATION_NAME.Visible = false;
            // 
            // PACKAGE_NAME
            // 
            this.PACKAGE_NAME.DataPropertyName = "PACKAGE_NAME";
            this.PACKAGE_NAME.HeaderText = "包装方式";
            this.PACKAGE_NAME.Name = "PACKAGE_NAME";
            this.PACKAGE_NAME.Visible = false;
            // 
            // PRODUCT_PROPERTY
            // 
            this.PRODUCT_PROPERTY.DataPropertyName = "PRODUCT_PROPERTY";
            this.PRODUCT_PROPERTY.FillWeight = 117.7031F;
            this.PRODUCT_PROPERTY.HeaderText = "是否组成品";
            this.PRODUCT_PROPERTY.Name = "PRODUCT_PROPERTY";
            this.PRODUCT_PROPERTY.ReadOnly = true;
            this.PRODUCT_PROPERTY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PRODUCT_PROPERTY.Visible = false;
            // 
            // FROMSET
            // 
            this.FROMSET.DataPropertyName = "FROMSET";
            this.FROMSET.HeaderText = "是否一式品";
            this.FROMSET.Name = "FROMSET";
            this.FROMSET.ReadOnly = true;
            this.FROMSET.Visible = false;
            // 
            // MECHANICAL_DISTINCTION
            // 
            this.MECHANICAL_DISTINCTION.DataPropertyName = "MECHANICAL_DISTINCTION";
            this.MECHANICAL_DISTINCTION.HeaderText = "机械区分";
            this.MECHANICAL_DISTINCTION.Name = "MECHANICAL_DISTINCTION";
            this.MECHANICAL_DISTINCTION.ReadOnly = true;
            this.MECHANICAL_DISTINCTION.Visible = false;
            // 
            // CREATE_USER
            // 
            this.CREATE_USER.DataPropertyName = "CREATE_USER";
            this.CREATE_USER.HeaderText = "创建人";
            this.CREATE_USER.Name = "CREATE_USER";
            this.CREATE_USER.ReadOnly = true;
            this.CREATE_USER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CREATE_DATE_TIME
            // 
            this.CREATE_DATE_TIME.DataPropertyName = "CREATE_DATE_TIME";
            this.CREATE_DATE_TIME.HeaderText = "创建时间";
            this.CREATE_DATE_TIME.Name = "CREATE_DATE_TIME";
            this.CREATE_DATE_TIME.ReadOnly = true;
            this.CREATE_DATE_TIME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CREATE_DATE_TIME.Width = 130;
            // 
            // LAST_UPDATE_USER
            // 
            this.LAST_UPDATE_USER.DataPropertyName = "LAST_UPDATE_USER";
            this.LAST_UPDATE_USER.HeaderText = "最后更新人";
            this.LAST_UPDATE_USER.Name = "LAST_UPDATE_USER";
            this.LAST_UPDATE_USER.ReadOnly = true;
            this.LAST_UPDATE_USER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LAST_UPDATE_TIME
            // 
            this.LAST_UPDATE_TIME.DataPropertyName = "LAST_UPDATE_TIME";
            this.LAST_UPDATE_TIME.HeaderText = "最后更新时间";
            this.LAST_UPDATE_TIME.Name = "LAST_UPDATE_TIME";
            this.LAST_UPDATE_TIME.ReadOnly = true;
            this.LAST_UPDATE_TIME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LAST_UPDATE_TIME.Width = 130;
            // 
            // HSCODE_NAME
            // 
            this.HSCODE_NAME.DataPropertyName = "HSCODE_NAME";
            this.HSCODE_NAME.FillWeight = 131.9797F;
            this.HSCODE_NAME.HeaderText = "海关名称";
            this.HSCODE_NAME.Name = "HSCODE_NAME";
            this.HSCODE_NAME.ReadOnly = true;
            this.HSCODE_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.HSCODE_NAME.Visible = false;
            this.HSCODE_NAME.Width = 102;
            // 
            // SUPPLIER_NAME
            // 
            this.SUPPLIER_NAME.DataPropertyName = "SUPPLIER_NAME";
            this.SUPPLIER_NAME.HeaderText = "默认供应商";
            this.SUPPLIER_NAME.Name = "SUPPLIER_NAME";
            this.SUPPLIER_NAME.ReadOnly = true;
            this.SUPPLIER_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SUPPLIER_NAME.Visible = false;
            this.SUPPLIER_NAME.Width = 140;
            // 
            // MasterToolBar
            // 
            this.MasterToolBar.BackColor = System.Drawing.Color.White;
            this.MasterToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.MasterToolBar.Location = new System.Drawing.Point(0, 0);
            this.MasterToolBar.Name = "MasterToolBar";
            this.MasterToolBar.Size = new System.Drawing.Size(1018, 30);
            this.MasterToolBar.TabIndex = 13;
            this.MasterToolBar.DoCancel_Click += new CZZD.ERP.ComControls.MasterToolBarControl.BtnClickHandle(this.MasterToolBar_DoCancel_Click);
            this.MasterToolBar.DoModify_Click += new CZZD.ERP.ComControls.MasterToolBarControl.BtnClickHandle(this.MasterToolBar_DoModify_Click);
            this.MasterToolBar.DoExport_Click += new CZZD.ERP.ComControls.MasterToolBarControl.BtnClickHandle(this.MasterToolBar_DoExport_Click);
            this.MasterToolBar.DoNew_Click += new CZZD.ERP.ComControls.MasterToolBarControl.BtnClickHandle(this.MasterToolBar_DoNew_Click);
            this.MasterToolBar.DoDelete_Click += new CZZD.ERP.ComControls.MasterToolBarControl.BtnClickHandle(this.MasterToolBar_DoDelete_Click);
            this.MasterToolBar.DoSearch_Click += new CZZD.ERP.ComControls.MasterToolBarControl.BtnClickHandle(this.MasterToolBar_DoSearch_Click);
            this.MasterToolBar.DoCopy_Click += new CZZD.ERP.ComControls.MasterToolBarControl.BtnClickHandle(this.MasterToolBar_DoCopy_Click);
            // 
            // FrmProduct
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1034, 659);
            this.Controls.Add(this.pBody);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmProduct";
            this.Text = "FrmProduct";
            this.Load += new System.EventHandler(this.FrmProduct_Load);
            this.pBody.ResumeLayout(false);
            this.pSearch.ResumeLayout(false);
            this.pRight.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.pLeft.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pBody;
        private CZZD.ERP.ComControls.MasterToolBarControl MasterToolBar;
        private System.Windows.Forms.Panel pSearch;
        private System.Windows.Forms.DataGridView dgvData;
        private CZZD.ERP.ComControls.PageControl pgControl;
        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.TextBox txtGroupCode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME_JP;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPEC;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODEL_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn GROUP_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNIT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_ACCOUTING;
        private System.Windows.Forms.DataGridViewTextBoxColumn SALES_PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PURCHASE_PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SAFETY_STOCK;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_STOCK;
        private System.Windows.Forms.DataGridViewTextBoxColumn SELL_LOCATION_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PACKAGE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_PROPERTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn FROMSET;
        private System.Windows.Forms.DataGridViewTextBoxColumn MECHANICAL_DISTINCTION;
        private System.Windows.Forms.DataGridViewTextBoxColumn CREATE_USER;
        private System.Windows.Forms.DataGridViewTextBoxColumn CREATE_DATE_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn LAST_UPDATE_USER;
        private System.Windows.Forms.DataGridViewTextBoxColumn LAST_UPDATE_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn HSCODE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUPPLIER_NAME;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboDistinction;
    }
}