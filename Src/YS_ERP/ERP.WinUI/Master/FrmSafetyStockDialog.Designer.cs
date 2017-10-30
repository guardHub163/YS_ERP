namespace CZZD.ERP.WinUI.Master
{
    partial class FrmSafetyStockDialog
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSafetyStockDialog));
            this.pBody = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtMinPurcahseQuantity = new System.Windows.Forms.TextBox();
            this.txtMaxQuantity = new System.Windows.Forms.TextBox();
            this.txtWarehouseName = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtUnitName = new System.Windows.Forms.TextBox();
            this.btnWarehouse = new System.Windows.Forms.Button();
            this.btnUnit = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.txtSafetyStock = new System.Windows.Forms.TextBox();
            this.txtUnitCode = new System.Windows.Forms.TextBox();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.txtWarehouseCode = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pBody.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pBody
            // 
            this.pBody.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pBody.Controls.Add(this.panel3);
            this.pBody.Controls.Add(this.panel2);
            this.pBody.Location = new System.Drawing.Point(0, 0);
            this.pBody.Name = "pBody";
            this.pBody.Size = new System.Drawing.Size(500, 277);
            this.pBody.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtMinPurcahseQuantity);
            this.panel3.Controls.Add(this.txtMaxQuantity);
            this.panel3.Controls.Add(this.txtWarehouseName);
            this.panel3.Controls.Add(this.txtProductName);
            this.panel3.Controls.Add(this.txtUnitName);
            this.panel3.Controls.Add(this.btnWarehouse);
            this.panel3.Controls.Add(this.btnUnit);
            this.panel3.Controls.Add(this.btnProduct);
            this.panel3.Controls.Add(this.txtSafetyStock);
            this.panel3.Controls.Add(this.txtUnitCode);
            this.panel3.Controls.Add(this.txtProductCode);
            this.panel3.Controls.Add(this.txtWarehouseCode);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(120, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(376, 273);
            this.panel3.TabIndex = 1;
            // 
            // txtMinPurcahseQuantity
            // 
            this.txtMinPurcahseQuantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtMinPurcahseQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMinPurcahseQuantity.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtMinPurcahseQuantity.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtMinPurcahseQuantity.Location = new System.Drawing.Point(5, 245);
            this.txtMinPurcahseQuantity.MaxLength = 9;
            this.txtMinPurcahseQuantity.Name = "txtMinPurcahseQuantity";
            this.txtMinPurcahseQuantity.Size = new System.Drawing.Size(250, 25);
            this.txtMinPurcahseQuantity.TabIndex = 8;
            this.txtMinPurcahseQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtMinPurcahseQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtMaxQuantity
            // 
            this.txtMaxQuantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtMaxQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaxQuantity.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtMaxQuantity.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtMaxQuantity.Location = new System.Drawing.Point(5, 215);
            this.txtMaxQuantity.MaxLength = 9;
            this.txtMaxQuantity.Name = "txtMaxQuantity";
            this.txtMaxQuantity.Size = new System.Drawing.Size(250, 25);
            this.txtMaxQuantity.TabIndex = 7;
            this.txtMaxQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtMaxQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtWarehouseName
            // 
            this.txtWarehouseName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtWarehouseName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWarehouseName.Enabled = false;
            this.txtWarehouseName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtWarehouseName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtWarehouseName.Location = new System.Drawing.Point(5, 35);
            this.txtWarehouseName.MaxLength = 20;
            this.txtWarehouseName.Name = "txtWarehouseName";
            this.txtWarehouseName.Size = new System.Drawing.Size(250, 25);
            this.txtWarehouseName.TabIndex = 138;
            // 
            // txtProductName
            // 
            this.txtProductName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductName.Enabled = false;
            this.txtProductName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtProductName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtProductName.Location = new System.Drawing.Point(5, 95);
            this.txtProductName.MaxLength = 20;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(250, 25);
            this.txtProductName.TabIndex = 137;
            // 
            // txtUnitName
            // 
            this.txtUnitName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtUnitName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnitName.Enabled = false;
            this.txtUnitName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtUnitName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtUnitName.Location = new System.Drawing.Point(5, 155);
            this.txtUnitName.MaxLength = 20;
            this.txtUnitName.Name = "txtUnitName";
            this.txtUnitName.Size = new System.Drawing.Size(250, 25);
            this.txtUnitName.TabIndex = 136;
            // 
            // btnWarehouse
            // 
            this.btnWarehouse.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnWarehouse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnWarehouse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWarehouse.FlatAppearance.BorderSize = 0;
            this.btnWarehouse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnWarehouse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnWarehouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWarehouse.Location = new System.Drawing.Point(261, 5);
            this.btnWarehouse.Name = "btnWarehouse";
            this.btnWarehouse.Size = new System.Drawing.Size(25, 25);
            this.btnWarehouse.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btnWarehouse, "查询");
            this.btnWarehouse.UseVisualStyleBackColor = true;
            this.btnWarehouse.MouseLeave += new System.EventHandler(this.btnSearch_MouseLeave);
            this.btnWarehouse.Click += new System.EventHandler(this.btnWarehouse_Click);
            this.btnWarehouse.MouseEnter += new System.EventHandler(this.btnSearch_MouseEnter);
            this.btnWarehouse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // btnUnit
            // 
            this.btnUnit.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnUnit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUnit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUnit.FlatAppearance.BorderSize = 0;
            this.btnUnit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnUnit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnit.Location = new System.Drawing.Point(261, 125);
            this.btnUnit.Name = "btnUnit";
            this.btnUnit.Size = new System.Drawing.Size(25, 25);
            this.btnUnit.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btnUnit, "查询");
            this.btnUnit.UseVisualStyleBackColor = true;
            this.btnUnit.MouseLeave += new System.EventHandler(this.btnSearch_MouseLeave);
            this.btnUnit.Click += new System.EventHandler(this.btnUnit_Click);
            this.btnUnit.MouseEnter += new System.EventHandler(this.btnSearch_MouseEnter);
            this.btnUnit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // btnProduct
            // 
            this.btnProduct.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProduct.FlatAppearance.BorderSize = 0;
            this.btnProduct.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduct.Location = new System.Drawing.Point(261, 65);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(25, 25);
            this.btnProduct.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnProduct, "查询");
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.MouseLeave += new System.EventHandler(this.btnSearch_MouseLeave);
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            this.btnProduct.MouseEnter += new System.EventHandler(this.btnSearch_MouseEnter);
            this.btnProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // txtSafetyStock
            // 
            this.txtSafetyStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtSafetyStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSafetyStock.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSafetyStock.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtSafetyStock.Location = new System.Drawing.Point(5, 185);
            this.txtSafetyStock.MaxLength = 9;
            this.txtSafetyStock.Name = "txtSafetyStock";
            this.txtSafetyStock.Size = new System.Drawing.Size(250, 25);
            this.txtSafetyStock.TabIndex = 6;
            this.txtSafetyStock.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtSafetyStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtUnitCode
            // 
            this.txtUnitCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtUnitCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnitCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtUnitCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtUnitCode.Location = new System.Drawing.Point(5, 125);
            this.txtUnitCode.MaxLength = 20;
            this.txtUnitCode.Name = "txtUnitCode";
            this.txtUnitCode.Size = new System.Drawing.Size(250, 25);
            this.txtUnitCode.TabIndex = 4;
            this.txtUnitCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtUnitCode.Leave += new System.EventHandler(this.txtUnitCode_Leave);
            this.txtUnitCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtProductCode
            // 
            this.txtProductCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtProductCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtProductCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtProductCode.Location = new System.Drawing.Point(5, 65);
            this.txtProductCode.MaxLength = 20;
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(250, 25);
            this.txtProductCode.TabIndex = 2;
            this.txtProductCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtProductCode.Leave += new System.EventHandler(this.txtProductCode_Leave);
            this.txtProductCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtWarehouseCode
            // 
            this.txtWarehouseCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtWarehouseCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWarehouseCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtWarehouseCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtWarehouseCode.Location = new System.Drawing.Point(5, 5);
            this.txtWarehouseCode.MaxLength = 20;
            this.txtWarehouseCode.Name = "txtWarehouseCode";
            this.txtWarehouseCode.Size = new System.Drawing.Size(250, 25);
            this.txtWarehouseCode.TabIndex = 0;
            this.txtWarehouseCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtWarehouseCode.Leave += new System.EventHandler(this.txtWarehouseCode_Leave);
            this.txtWarehouseCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(120, 273);
            this.panel2.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(2, 245);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "最小采购数：";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(5, 215);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "最大在库数：";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(5, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "仓库名称：";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(5, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "商品名称：";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "单位名称：";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "安全在库数：";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "单位编号：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "商品编号：";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "仓库编号：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSave.Location = new System.Drawing.Point(317, 281);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnCancel.Location = new System.Drawing.Point(408, 281);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmSafetyStockDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(502, 314);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pBody);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSafetyStockDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "安全库存编辑";
            this.Load += new System.EventHandler(this.FrmSafetyStockDialog_Load);
            this.Shown += new System.EventHandler(this.FrmSafetyStockDialog_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmSafetyStockDialog_FormClosed);
            this.pBody.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pBody;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtWarehouseCode;
        private System.Windows.Forms.TextBox txtSafetyStock;
        private System.Windows.Forms.TextBox txtUnitCode;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Button btnWarehouse;
        private System.Windows.Forms.Button btnUnit;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtWarehouseName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtUnitName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMinPurcahseQuantity;
        private System.Windows.Forms.TextBox txtMaxQuantity;
    }
}