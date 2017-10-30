namespace CZZD.ERP.WinUI
{
    partial class FrmSlipTypeCompositionProductsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSlipTypeCompositionProductsDialog));
            this.pInfo = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtquantity = new System.Windows.Forms.TextBox();
            this.btnCompositionProducts = new System.Windows.Forms.Button();
            this.txtCompositionProductsName = new System.Windows.Forms.TextBox();
            this.txtSlipTypeName = new System.Windows.Forms.TextBox();
            this.txtSlipTypeCode = new System.Windows.Forms.TextBox();
            this.btnSlipType = new System.Windows.Forms.Button();
            this.txtCompositionProductsCode = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pInfo.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pInfo
            // 
            this.pInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pInfo.Controls.Add(this.panel3);
            this.pInfo.Controls.Add(this.panel2);
            this.pInfo.Location = new System.Drawing.Point(0, 0);
            this.pInfo.Name = "pInfo";
            this.pInfo.Size = new System.Drawing.Size(444, 192);
            this.pInfo.TabIndex = 143;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtquantity);
            this.panel3.Controls.Add(this.btnCompositionProducts);
            this.panel3.Controls.Add(this.txtCompositionProductsName);
            this.panel3.Controls.Add(this.txtSlipTypeName);
            this.panel3.Controls.Add(this.txtSlipTypeCode);
            this.panel3.Controls.Add(this.btnSlipType);
            this.panel3.Controls.Add(this.txtCompositionProductsCode);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(120, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(320, 188);
            this.panel3.TabIndex = 1;
            // 
            // txtquantity
            // 
            this.txtquantity.BackColor = System.Drawing.SystemColors.Info;
            this.txtquantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtquantity.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtquantity.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtquantity.Location = new System.Drawing.Point(5, 125);
            this.txtquantity.MaxLength = 9;
            this.txtquantity.Name = "txtquantity";
            this.txtquantity.Size = new System.Drawing.Size(250, 25);
            this.txtquantity.TabIndex = 8;
            // 
            // btnCompositionProducts
            // 
            this.btnCompositionProducts.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnCompositionProducts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCompositionProducts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompositionProducts.FlatAppearance.BorderSize = 0;
            this.btnCompositionProducts.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCompositionProducts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCompositionProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompositionProducts.Location = new System.Drawing.Point(261, 65);
            this.btnCompositionProducts.Name = "btnCompositionProducts";
            this.btnCompositionProducts.Size = new System.Drawing.Size(25, 25);
            this.btnCompositionProducts.TabIndex = 7;
            this.btnCompositionProducts.UseVisualStyleBackColor = true;
            this.btnCompositionProducts.Click += new System.EventHandler(this.btnProductGroup_Click);
            // 
            // txtCompositionProductsName
            // 
            this.txtCompositionProductsName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCompositionProductsName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompositionProductsName.Enabled = false;
            this.txtCompositionProductsName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCompositionProductsName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtCompositionProductsName.Location = new System.Drawing.Point(5, 95);
            this.txtCompositionProductsName.MaxLength = 9;
            this.txtCompositionProductsName.Name = "txtCompositionProductsName";
            this.txtCompositionProductsName.Size = new System.Drawing.Size(250, 25);
            this.txtCompositionProductsName.TabIndex = 6;
            // 
            // txtSlipTypeName
            // 
            this.txtSlipTypeName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtSlipTypeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSlipTypeName.Enabled = false;
            this.txtSlipTypeName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSlipTypeName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtSlipTypeName.Location = new System.Drawing.Point(5, 35);
            this.txtSlipTypeName.MaxLength = 9;
            this.txtSlipTypeName.Name = "txtSlipTypeName";
            this.txtSlipTypeName.Size = new System.Drawing.Size(250, 25);
            this.txtSlipTypeName.TabIndex = 3;
            // 
            // txtSlipTypeCode
            // 
            this.txtSlipTypeCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtSlipTypeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSlipTypeCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSlipTypeCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtSlipTypeCode.Location = new System.Drawing.Point(5, 5);
            this.txtSlipTypeCode.MaxLength = 20;
            this.txtSlipTypeCode.Name = "txtSlipTypeCode";
            this.txtSlipTypeCode.Size = new System.Drawing.Size(250, 25);
            this.txtSlipTypeCode.TabIndex = 1;
            this.txtSlipTypeCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtSlipTypeCode.Leave += new System.EventHandler(this.txtSlipTypeCode_Leave);
            this.txtSlipTypeCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
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
            this.btnSlipType.Location = new System.Drawing.Point(261, 5);
            this.btnSlipType.Name = "btnSlipType";
            this.btnSlipType.Size = new System.Drawing.Size(25, 25);
            this.btnSlipType.TabIndex = 2;
            this.btnSlipType.UseVisualStyleBackColor = true;
            this.btnSlipType.Click += new System.EventHandler(this.btnSlipType_Click);
            this.btnSlipType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtCompositionProductsCode
            // 
            this.txtCompositionProductsCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtCompositionProductsCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompositionProductsCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCompositionProductsCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtCompositionProductsCode.Location = new System.Drawing.Point(5, 65);
            this.txtCompositionProductsCode.MaxLength = 20;
            this.txtCompositionProductsCode.Name = "txtCompositionProductsCode";
            this.txtCompositionProductsCode.Size = new System.Drawing.Size(250, 25);
            this.txtCompositionProductsCode.TabIndex = 4;
            this.txtCompositionProductsCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtCompositionProductsCode.Leave += new System.EventHandler(this.txtProductGroupCode_Leave);
            this.txtCompositionProductsCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(120, 188);
            this.panel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 143;
            this.label2.Text = "数量";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.SteelBlue;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 142;
            this.label5.Text = "部件名称";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.SteelBlue;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 141;
            this.label4.Text = "模具种类名称";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 136;
            this.label1.Text = "模具种类编号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 140;
            this.label3.Text = "部件编号";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSave.Location = new System.Drawing.Point(257, 192);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 144;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnCancel.Location = new System.Drawing.Point(353, 192);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 145;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmSlipTypeCompositionProductsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(444, 226);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pInfo);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSlipTypeCompositionProductsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新建";
            this.Load += new System.EventHandler(this.FrmMachineDialog_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmSlipTypeCompositionProductsDialog_FormClosed);
            this.pInfo.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pInfo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCompositionProducts;
        private System.Windows.Forms.TextBox txtCompositionProductsName;
        private System.Windows.Forms.TextBox txtSlipTypeName;
        private System.Windows.Forms.TextBox txtSlipTypeCode;
        private System.Windows.Forms.Button btnSlipType;
        private System.Windows.Forms.TextBox txtCompositionProductsCode;
        //private System.Windows.Forms.TextBox txtQUANTITY;        
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtquantity;

    }
}