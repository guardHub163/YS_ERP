namespace CZZD.ERP.WinUI
{
    partial class FrmSpecificationProductDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSpecificationProductDialog));
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtPartsCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.pInfo = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnParts = new System.Windows.Forms.Button();
            this.txtPartsName = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnSaveAndNew = new System.Windows.Forms.Button();
            this.pInfo.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
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
            this.btnProduct.Location = new System.Drawing.Point(261, 5);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(25, 25);
            this.btnProduct.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnProduct, "查询");
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.MouseLeave += new System.EventHandler(this.btnSearch_MouseLeave);
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            this.btnProduct.MouseEnter += new System.EventHandler(this.btnSearch_MouseEnter);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnCancel.Location = new System.Drawing.Point(348, 196);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSave.Location = new System.Drawing.Point(252, 196);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtPartsCode
            // 
            this.txtPartsCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtPartsCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPartsCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtPartsCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtPartsCode.Location = new System.Drawing.Point(5, 65);
            this.txtPartsCode.MaxLength = 20;
            this.txtPartsCode.Name = "txtPartsCode";
            this.txtPartsCode.Size = new System.Drawing.Size(250, 25);
            this.txtPartsCode.TabIndex = 4;
            this.txtPartsCode.Leave += new System.EventHandler(this.txtPartsCode_Leave);
            this.txtPartsCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 20);
            this.label3.TabIndex = 140;
            this.label3.Text = "构成件编号：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 139;
            this.label2.Text = "组成数量：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtProductCode
            // 
            this.txtProductCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtProductCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtProductCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtProductCode.Location = new System.Drawing.Point(5, 5);
            this.txtProductCode.MaxLength = 20;
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(250, 25);
            this.txtProductCode.TabIndex = 1;
            this.txtProductCode.Leave += new System.EventHandler(this.txtProductCode_Leave);
            this.txtProductCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 136;
            this.label1.Text = "规格/型号编号：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQuantity
            // 
            this.txtQuantity.BackColor = System.Drawing.SystemColors.Info;
            this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuantity.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtQuantity.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtQuantity.Location = new System.Drawing.Point(5, 124);
            this.txtQuantity.MaxLength = 9;
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(250, 25);
            this.txtQuantity.TabIndex = 5;
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // pInfo
            // 
            this.pInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pInfo.Controls.Add(this.panel3);
            this.pInfo.Controls.Add(this.panel2);
            this.pInfo.Location = new System.Drawing.Point(0, 0);
            this.pInfo.Name = "pInfo";
            this.pInfo.Size = new System.Drawing.Size(440, 194);
            this.pInfo.TabIndex = 142;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnParts);
            this.panel3.Controls.Add(this.txtPartsName);
            this.panel3.Controls.Add(this.txtProductName);
            this.panel3.Controls.Add(this.txtQuantity);
            this.panel3.Controls.Add(this.txtProductCode);
            this.panel3.Controls.Add(this.btnProduct);
            this.panel3.Controls.Add(this.txtPartsCode);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(120, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(316, 190);
            this.panel3.TabIndex = 1;
            // 
            // btnParts
            // 
            this.btnParts.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnParts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnParts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnParts.FlatAppearance.BorderSize = 0;
            this.btnParts.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnParts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnParts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParts.Location = new System.Drawing.Point(261, 65);
            this.btnParts.Name = "btnParts";
            this.btnParts.Size = new System.Drawing.Size(25, 25);
            this.btnParts.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btnParts, "查询");
            this.btnParts.UseVisualStyleBackColor = true;
            this.btnParts.Click += new System.EventHandler(this.btnParts_Click);
            // 
            // txtPartsName
            // 
            this.txtPartsName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtPartsName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPartsName.Enabled = false;
            this.txtPartsName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtPartsName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtPartsName.Location = new System.Drawing.Point(5, 95);
            this.txtPartsName.MaxLength = 9;
            this.txtPartsName.Name = "txtPartsName";
            this.txtPartsName.Size = new System.Drawing.Size(250, 25);
            this.txtPartsName.TabIndex = 6;
            // 
            // txtProductName
            // 
            this.txtProductName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductName.Enabled = false;
            this.txtProductName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtProductName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtProductName.Location = new System.Drawing.Point(5, 35);
            this.txtProductName.MaxLength = 9;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(250, 25);
            this.txtProductName.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(120, 190);
            this.panel2.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.SteelBlue;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 20);
            this.label5.TabIndex = 142;
            this.label5.Text = "构成件名称：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.SteelBlue;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.TabIndex = 141;
            this.label4.Text = "规格/型号名称：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSaveAndNew
            // 
            this.btnSaveAndNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveAndNew.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSaveAndNew.Location = new System.Drawing.Point(156, 196);
            this.btnSaveAndNew.Name = "btnSaveAndNew";
            this.btnSaveAndNew.Size = new System.Drawing.Size(90, 30);
            this.btnSaveAndNew.TabIndex = 143;
            this.btnSaveAndNew.Text = "保存并新建";
            this.btnSaveAndNew.UseVisualStyleBackColor = true;
            this.btnSaveAndNew.Visible = false;
            this.btnSaveAndNew.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmSpecificationProductDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(449, 231);
            this.Controls.Add(this.btnSaveAndNew);
            this.Controls.Add(this.pInfo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSpecificationProductDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "规格/型号构成编辑";
            this.Load += new System.EventHandler(this.FrmProductPartsDialog_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmProductPartsDialog_FormClosed);
            this.pInfo.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtPartsCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Panel pInfo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPartsName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnParts;
        private System.Windows.Forms.Button btnSaveAndNew;
    }
}