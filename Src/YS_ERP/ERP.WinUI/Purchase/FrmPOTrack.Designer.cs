namespace CZZD.ERP.WinUI.Purchase
{
    partial class FrmPOTrack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPOTrack));
            this.pBody = new System.Windows.Forms.Panel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExporte = new System.Windows.Forms.Button();
            this.NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLIP_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUPPLIER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAYMENT_STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLIP_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DUE_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DUE_STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DELIVERY_STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ACTUAL_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // pBody
            // 
            this.pBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBody.Controls.Add(this.dgvData);
            this.pBody.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.pBody.Location = new System.Drawing.Point(0, 0);
            this.pBody.Name = "pBody";
            this.pBody.Size = new System.Drawing.Size(883, 524);
            this.pBody.TabIndex = 0;
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
            this.dgvData.ColumnHeadersHeight = 25;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NO,
            this.SLIP_NUMBER,
            this.PRODUCT_CODE,
            this.PRODUCT_NAME,
            this.SPEC,
            this.SUPPLIER_NAME,
            this.QUANTITY,
            this.PRICE,
            this.AMOUNT,
            this.PAYMENT_STATUS,
            this.SLIP_DATE,
            this.DUE_DATE,
            this.DUE_STATUS,
            this.DELIVERY_STATUS,
            this.ACTUAL_AMOUNT});
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.dgvData.RowTemplate.Height = 25;
            this.dgvData.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(882, 519);
            this.dgvData.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnClose.Location = new System.Drawing.Point(793, 526);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 30);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "关　闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExporte
            // 
            this.btnExporte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExporte.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnExporte.Location = new System.Drawing.Point(701, 526);
            this.btnExporte.Name = "btnExporte";
            this.btnExporte.Size = new System.Drawing.Size(90, 30);
            this.btnExporte.TabIndex = 11;
            this.btnExporte.Text = "导　出";
            this.btnExporte.UseVisualStyleBackColor = true;
            this.btnExporte.Click += new System.EventHandler(this.btnExporte_Click);
            // 
            // NO
            // 
            this.NO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NO.DataPropertyName = "NO";
            this.NO.Frozen = true;
            this.NO.HeaderText = "No";
            this.NO.Name = "NO";
            this.NO.ReadOnly = true;
            this.NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NO.Width = 40;
            // 
            // SLIP_NUMBER
            // 
            this.SLIP_NUMBER.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SLIP_NUMBER.DataPropertyName = "SLIP_NUMBER";
            this.SLIP_NUMBER.Frozen = true;
            this.SLIP_NUMBER.HeaderText = "采购订单编号";
            this.SLIP_NUMBER.Name = "SLIP_NUMBER";
            this.SLIP_NUMBER.ReadOnly = true;
            this.SLIP_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SLIP_NUMBER.Width = 120;
            // 
            // PRODUCT_CODE
            // 
            this.PRODUCT_CODE.DataPropertyName = "PRODUCT_CODE";
            this.PRODUCT_CODE.Frozen = true;
            this.PRODUCT_CODE.HeaderText = "产品编号";
            this.PRODUCT_CODE.Name = "PRODUCT_CODE";
            this.PRODUCT_CODE.ReadOnly = true;
            this.PRODUCT_CODE.Width = 120;
            // 
            // PRODUCT_NAME
            // 
            this.PRODUCT_NAME.DataPropertyName = "PRODUCT_NAME";
            this.PRODUCT_NAME.Frozen = true;
            this.PRODUCT_NAME.HeaderText = "产品名称";
            this.PRODUCT_NAME.Name = "PRODUCT_NAME";
            this.PRODUCT_NAME.ReadOnly = true;
            this.PRODUCT_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PRODUCT_NAME.Width = 120;
            // 
            // SPEC
            // 
            this.SPEC.DataPropertyName = "SPEC";
            this.SPEC.HeaderText = "型号规格";
            this.SPEC.Name = "SPEC";
            this.SPEC.ReadOnly = true;
            this.SPEC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SPEC.Width = 120;
            // 
            // SUPPLIER_NAME
            // 
            this.SUPPLIER_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SUPPLIER_NAME.DataPropertyName = "SUPPLIER_NAME";
            this.SUPPLIER_NAME.HeaderText = "供应商";
            this.SUPPLIER_NAME.Name = "SUPPLIER_NAME";
            this.SUPPLIER_NAME.ReadOnly = true;
            this.SUPPLIER_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SUPPLIER_NAME.Width = 120;
            // 
            // QUANTITY
            // 
            this.QUANTITY.DataPropertyName = "QUANTITY";
            this.QUANTITY.HeaderText = "数量";
            this.QUANTITY.Name = "QUANTITY";
            this.QUANTITY.ReadOnly = true;
            this.QUANTITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PRICE
            // 
            this.PRICE.DataPropertyName = "PRICE";
            this.PRICE.HeaderText = "单价";
            this.PRICE.Name = "PRICE";
            this.PRICE.ReadOnly = true;
            this.PRICE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AMOUNT
            // 
            this.AMOUNT.DataPropertyName = "AMOUNT";
            this.AMOUNT.HeaderText = "总价";
            this.AMOUNT.Name = "AMOUNT";
            this.AMOUNT.ReadOnly = true;
            this.AMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PAYMENT_STATUS
            // 
            this.PAYMENT_STATUS.DataPropertyName = "PAYMENT_STATUS";
            this.PAYMENT_STATUS.HeaderText = "货款状况";
            this.PAYMENT_STATUS.Name = "PAYMENT_STATUS";
            this.PAYMENT_STATUS.ReadOnly = true;
            this.PAYMENT_STATUS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SLIP_DATE
            // 
            this.SLIP_DATE.DataPropertyName = "SLIP_DATE";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "yyyy-MM-dd";
            dataGridViewCellStyle2.NullValue = null;
            this.SLIP_DATE.DefaultCellStyle = dataGridViewCellStyle2;
            this.SLIP_DATE.HeaderText = "下单日期";
            this.SLIP_DATE.Name = "SLIP_DATE";
            this.SLIP_DATE.ReadOnly = true;
            this.SLIP_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SLIP_DATE.Width = 99;
            // 
            // DUE_DATE
            // 
            this.DUE_DATE.DataPropertyName = "DUE_DATE";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "yyyy-MM-dd";
            dataGridViewCellStyle3.NullValue = null;
            this.DUE_DATE.DefaultCellStyle = dataGridViewCellStyle3;
            this.DUE_DATE.HeaderText = "交货预期";
            this.DUE_DATE.Name = "DUE_DATE";
            this.DUE_DATE.ReadOnly = true;
            this.DUE_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DUE_STATUS
            // 
            this.DUE_STATUS.DataPropertyName = "DUE_STATUS";
            this.DUE_STATUS.HeaderText = "交货状态";
            this.DUE_STATUS.Name = "DUE_STATUS";
            this.DUE_STATUS.ReadOnly = true;
            this.DUE_STATUS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DELIVERY_STATUS
            // 
            this.DELIVERY_STATUS.DataPropertyName = "DELIVERY_STATUS";
            this.DELIVERY_STATUS.HeaderText = "到货状况";
            this.DELIVERY_STATUS.Name = "DELIVERY_STATUS";
            this.DELIVERY_STATUS.ReadOnly = true;
            // 
            // ACTUAL_AMOUNT
            // 
            this.ACTUAL_AMOUNT.DataPropertyName = "ACTUAL_AMOUNT";
            this.ACTUAL_AMOUNT.HeaderText = "实到数量";
            this.ACTUAL_AMOUNT.Name = "ACTUAL_AMOUNT";
            this.ACTUAL_AMOUNT.ReadOnly = true;
            // 
            // FrmPOTrack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(884, 556);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExporte);
            this.Controls.Add(this.pBody);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPOTrack";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "订单跟踪";
            this.Load += new System.EventHandler(this.FrmPOTrack_Load);
            this.pBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pBody;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnExporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLIP_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPEC;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUPPLIER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUANTITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAYMENT_STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLIP_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DUE_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DUE_STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn DELIVERY_STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACTUAL_AMOUNT;
    }
}