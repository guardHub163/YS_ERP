namespace CZZD.ERP.WinUI
{
    partial class FrmDelivery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDelivery));
            this.pBody = new System.Windows.Forms.Panel();
            this.pSearch = new System.Windows.Forms.Panel();
            this.pgControl = new CZZD.ERP.ComControls.PageControl();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.CUSTOMER_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTOMER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DELIVERY_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADDRESS_FIRST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADDRESS_MIDDLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADDRESS_LAST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZIP_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PHONE_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FAX_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MOBIL_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONTACT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CREATE_USER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CREATE_DATE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LAST_UPDATE_USER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LAST_UPDATE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pLeft = new System.Windows.Forms.Panel();
            this.pLeft_2 = new System.Windows.Forms.Panel();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.txtDeliveryCode = new System.Windows.Forms.TextBox();
            this.pLeft_1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MasterToolBar = new CZZD.ERP.ComControls.MasterToolBarControl();
            this.pBody.SuspendLayout();
            this.pSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.pLeft.SuspendLayout();
            this.pLeft_2.SuspendLayout();
            this.pLeft_1.SuspendLayout();
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
            this.pSearch.Controls.Add(this.pgControl);
            this.pSearch.Controls.Add(this.dgvData);
            this.pSearch.Controls.Add(this.pLeft);
            this.pSearch.Location = new System.Drawing.Point(3, 33);
            this.pSearch.Name = "pSearch";
            this.pSearch.Size = new System.Drawing.Size(1017, 616);
            this.pSearch.TabIndex = 14;
            // 
            // pgControl
            // 
            this.pgControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pgControl.Location = new System.Drawing.Point(0, 584);
            this.pgControl.Name = "pgControl";
            this.pgControl.Size = new System.Drawing.Size(1011, 30);
            this.pgControl.TabIndex = 21;
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
            this.CUSTOMER_CODE,
            this.CUSTOMER_NAME,
            this.DELIVERY_CODE,
            this.ADDRESS_FIRST,
            this.ADDRESS_MIDDLE,
            this.ADDRESS_LAST,
            this.ZIP_CODE,
            this.PHONE_NUMBER,
            this.FAX_NUMBER,
            this.MOBIL_NUMBER,
            this.CONTACT_NAME,
            this.CREATE_USER,
            this.CREATE_DATE_TIME,
            this.LAST_UPDATE_USER,
            this.LAST_UPDATE_TIME});
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(0, 127);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1011, 457);
            this.dgvData.TabIndex = 20;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            this.dgvData.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvData_RowStateChanged);
            // 
            // CUSTOMER_CODE
            // 
            this.CUSTOMER_CODE.DataPropertyName = "CUSTOMER_CODE";
            this.CUSTOMER_CODE.HeaderText = "CUSTOMER_CODE";
            this.CUSTOMER_CODE.Name = "CUSTOMER_CODE";
            this.CUSTOMER_CODE.ReadOnly = true;
            this.CUSTOMER_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CUSTOMER_CODE.Visible = false;
            // 
            // CUSTOMER_NAME
            // 
            this.CUSTOMER_NAME.DataPropertyName = "CUSTOMER_NAME";
            this.CUSTOMER_NAME.FillWeight = 85.89412F;
            this.CUSTOMER_NAME.HeaderText = "客户名称";
            this.CUSTOMER_NAME.Name = "CUSTOMER_NAME";
            this.CUSTOMER_NAME.ReadOnly = true;
            this.CUSTOMER_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CUSTOMER_NAME.Width = 150;
            // 
            // DELIVERY_CODE
            // 
            this.DELIVERY_CODE.DataPropertyName = "DELIVERY_CODE";
            this.DELIVERY_CODE.HeaderText = "DELIVERY_CODE";
            this.DELIVERY_CODE.Name = "DELIVERY_CODE";
            this.DELIVERY_CODE.ReadOnly = true;
            this.DELIVERY_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DELIVERY_CODE.Visible = false;
            // 
            // ADDRESS_FIRST
            // 
            this.ADDRESS_FIRST.DataPropertyName = "ADDRESS_FIRST";
            this.ADDRESS_FIRST.FillWeight = 80.79253F;
            this.ADDRESS_FIRST.HeaderText = "地址1";
            this.ADDRESS_FIRST.Name = "ADDRESS_FIRST";
            this.ADDRESS_FIRST.ReadOnly = true;
            this.ADDRESS_FIRST.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ADDRESS_FIRST.Width = 140;
            // 
            // ADDRESS_MIDDLE
            // 
            this.ADDRESS_MIDDLE.DataPropertyName = "ADDRESS_MIDDLE";
            this.ADDRESS_MIDDLE.FillWeight = 79.42719F;
            this.ADDRESS_MIDDLE.HeaderText = "地址2";
            this.ADDRESS_MIDDLE.Name = "ADDRESS_MIDDLE";
            this.ADDRESS_MIDDLE.ReadOnly = true;
            this.ADDRESS_MIDDLE.Width = 140;
            // 
            // ADDRESS_LAST
            // 
            this.ADDRESS_LAST.DataPropertyName = "ADDRESS_LAST";
            this.ADDRESS_LAST.FillWeight = 77.96539F;
            this.ADDRESS_LAST.HeaderText = "地址3";
            this.ADDRESS_LAST.Name = "ADDRESS_LAST";
            this.ADDRESS_LAST.ReadOnly = true;
            this.ADDRESS_LAST.Width = 140;
            // 
            // ZIP_CODE
            // 
            this.ZIP_CODE.DataPropertyName = "ZIP_CODE";
            this.ZIP_CODE.FillWeight = 83.22223F;
            this.ZIP_CODE.HeaderText = "邮编";
            this.ZIP_CODE.Name = "ZIP_CODE";
            this.ZIP_CODE.ReadOnly = true;
            this.ZIP_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PHONE_NUMBER
            // 
            this.PHONE_NUMBER.DataPropertyName = "PHONE_NUMBER";
            this.PHONE_NUMBER.FillWeight = 80.62725F;
            this.PHONE_NUMBER.HeaderText = "电话";
            this.PHONE_NUMBER.Name = "PHONE_NUMBER";
            this.PHONE_NUMBER.ReadOnly = true;
            this.PHONE_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FAX_NUMBER
            // 
            this.FAX_NUMBER.DataPropertyName = "FAX_NUMBER";
            this.FAX_NUMBER.FillWeight = 80.22876F;
            this.FAX_NUMBER.HeaderText = "传真";
            this.FAX_NUMBER.Name = "FAX_NUMBER";
            this.FAX_NUMBER.ReadOnly = true;
            this.FAX_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MOBIL_NUMBER
            // 
            this.MOBIL_NUMBER.DataPropertyName = "MOBIL_NUMBER";
            this.MOBIL_NUMBER.FillWeight = 108.7399F;
            this.MOBIL_NUMBER.HeaderText = "联系人手机";
            this.MOBIL_NUMBER.Name = "MOBIL_NUMBER";
            this.MOBIL_NUMBER.ReadOnly = true;
            this.MOBIL_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MOBIL_NUMBER.Width = 120;
            // 
            // CONTACT_NAME
            // 
            this.CONTACT_NAME.DataPropertyName = "CONTACT_NAME";
            this.CONTACT_NAME.FillWeight = 109.607F;
            this.CONTACT_NAME.HeaderText = "联系人名称";
            this.CONTACT_NAME.Name = "CONTACT_NAME";
            this.CONTACT_NAME.ReadOnly = true;
            this.CONTACT_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CONTACT_NAME.Width = 120;
            // 
            // CREATE_USER
            // 
            this.CREATE_USER.DataPropertyName = "CREATE_USER";
            this.CREATE_USER.FillWeight = 100.1172F;
            this.CREATE_USER.HeaderText = "创建人";
            this.CREATE_USER.Name = "CREATE_USER";
            this.CREATE_USER.ReadOnly = true;
            this.CREATE_USER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CREATE_DATE_TIME
            // 
            this.CREATE_DATE_TIME.DataPropertyName = "CREATE_DATE_TIME";
            this.CREATE_DATE_TIME.FillWeight = 100.1172F;
            this.CREATE_DATE_TIME.HeaderText = "创建时间";
            this.CREATE_DATE_TIME.Name = "CREATE_DATE_TIME";
            this.CREATE_DATE_TIME.ReadOnly = true;
            this.CREATE_DATE_TIME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LAST_UPDATE_USER
            // 
            this.LAST_UPDATE_USER.DataPropertyName = "LAST_UPDATE_USER";
            this.LAST_UPDATE_USER.FillWeight = 110.5613F;
            this.LAST_UPDATE_USER.HeaderText = "最后更新人";
            this.LAST_UPDATE_USER.Name = "LAST_UPDATE_USER";
            this.LAST_UPDATE_USER.ReadOnly = true;
            this.LAST_UPDATE_USER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LAST_UPDATE_TIME
            // 
            this.LAST_UPDATE_TIME.DataPropertyName = "LAST_UPDATE_TIME";
            this.LAST_UPDATE_TIME.FillWeight = 130.9279F;
            this.LAST_UPDATE_TIME.HeaderText = "最后更新时间";
            this.LAST_UPDATE_TIME.Name = "LAST_UPDATE_TIME";
            this.LAST_UPDATE_TIME.ReadOnly = true;
            this.LAST_UPDATE_TIME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LAST_UPDATE_TIME.Width = 107;
            // 
            // pLeft
            // 
            this.pLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLeft.Controls.Add(this.pLeft_2);
            this.pLeft.Controls.Add(this.pLeft_1);
            this.pLeft.Location = new System.Drawing.Point(0, 0);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(440, 125);
            this.pLeft.TabIndex = 17;
            // 
            // pLeft_2
            // 
            this.pLeft_2.Controls.Add(this.txtCustomerCode);
            this.pLeft_2.Controls.Add(this.txtDeliveryCode);
            this.pLeft_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pLeft_2.Location = new System.Drawing.Point(118, 0);
            this.pLeft_2.Name = "pLeft_2";
            this.pLeft_2.Size = new System.Drawing.Size(320, 123);
            this.pLeft_2.TabIndex = 15;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerCode.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtCustomerCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtCustomerCode.Location = new System.Drawing.Point(5, 5);
            this.txtCustomerCode.MaxLength = 20;
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(250, 23);
            this.txtCustomerCode.TabIndex = 6;
            this.txtCustomerCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtDeliveryCode
            // 
            this.txtDeliveryCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtDeliveryCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeliveryCode.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDeliveryCode.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtDeliveryCode.Location = new System.Drawing.Point(5, 35);
            this.txtDeliveryCode.MaxLength = 100;
            this.txtDeliveryCode.Name = "txtDeliveryCode";
            this.txtDeliveryCode.Size = new System.Drawing.Size(250, 23);
            this.txtDeliveryCode.TabIndex = 8;
            this.txtDeliveryCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // pLeft_1
            // 
            this.pLeft_1.BackColor = System.Drawing.Color.SteelBlue;
            this.pLeft_1.Controls.Add(this.label1);
            this.pLeft_1.Controls.Add(this.label2);
            this.pLeft_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeft_1.Location = new System.Drawing.Point(0, 0);
            this.pLeft_1.Name = "pLeft_1";
            this.pLeft_1.Size = new System.Drawing.Size(118, 123);
            this.pLeft_1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = " 客户编号：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = " 地址编号：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // FrmDelivery
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1027, 652);
            this.Controls.Add(this.pBody);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDelivery";
            this.Text = "客户地址设定";
            this.Load += new System.EventHandler(this.FrmDelivery_Load);
            this.pBody.ResumeLayout(false);
            this.pSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.pLeft.ResumeLayout(false);
            this.pLeft_2.ResumeLayout(false);
            this.pLeft_2.PerformLayout();
            this.pLeft_1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pBody;
        private CZZD.ERP.ComControls.MasterToolBarControl MasterToolBar;
        private System.Windows.Forms.Panel pSearch;
        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.Panel pLeft_2;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.TextBox txtDeliveryCode;
        private System.Windows.Forms.Panel pLeft_1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvData;
        private CZZD.ERP.ComControls.PageControl pgControl;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn DELIVERY_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADDRESS_FIRST;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADDRESS_MIDDLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADDRESS_LAST;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZIP_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PHONE_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn FAX_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn MOBIL_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONTACT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn CREATE_USER;
        private System.Windows.Forms.DataGridViewTextBoxColumn CREATE_DATE_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn LAST_UPDATE_USER;
        private System.Windows.Forms.DataGridViewTextBoxColumn LAST_UPDATE_TIME;
    }
}