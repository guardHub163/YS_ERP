namespace CZZD.ERP.WinUI
{
    partial class FrmCompositionProductsProductionProcessDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCompositionProductsProductionProcessDialog));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pInfo = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtOrder = new System.Windows.Forms.TextBox();
            this.btnCompositionProducts = new System.Windows.Forms.Button();
            this.txtCompositionProductsName = new System.Windows.Forms.TextBox();
            this.txtProductionProcessName = new System.Windows.Forms.TextBox();
            this.txtProductionProcessCode = new System.Windows.Forms.TextBox();
            this.btnProductionProcess = new System.Windows.Forms.Button();
            this.txtCompositionProductsCode = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pInfo.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSave.Location = new System.Drawing.Point(257, 192);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 1;
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
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pInfo
            // 
            this.pInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pInfo.Controls.Add(this.panel3);
            this.pInfo.Controls.Add(this.panel2);
            this.pInfo.Location = new System.Drawing.Point(0, 0);
            this.pInfo.Name = "pInfo";
            this.pInfo.Size = new System.Drawing.Size(444, 192);
            this.pInfo.TabIndex = 146;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtOrder);
            this.panel3.Controls.Add(this.btnCompositionProducts);
            this.panel3.Controls.Add(this.txtCompositionProductsName);
            this.panel3.Controls.Add(this.txtProductionProcessName);
            this.panel3.Controls.Add(this.txtProductionProcessCode);
            this.panel3.Controls.Add(this.btnProductionProcess);
            this.panel3.Controls.Add(this.txtCompositionProductsCode);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(120, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(320, 188);
            this.panel3.TabIndex = 0;
            // 
            // txtOrder
            // 
            this.txtOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrder.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtOrder.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtOrder.Location = new System.Drawing.Point(5, 125);
            this.txtOrder.MaxLength = 20;
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.Size = new System.Drawing.Size(250, 25);
            this.txtOrder.TabIndex = 6;
            //this.txtOrder.Leave += new System.EventHandler(this.txtOrder_Leave);
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
            this.btnCompositionProducts.Location = new System.Drawing.Point(261, 5);
            this.btnCompositionProducts.Name = "btnCompositionProducts";
            this.btnCompositionProducts.Size = new System.Drawing.Size(25, 25);
            this.btnCompositionProducts.TabIndex = 1;
            this.btnCompositionProducts.UseVisualStyleBackColor = true;
            this.btnCompositionProducts.Click += new System.EventHandler(this.btnCompositionProducts_Click);
            // 
            // txtCompositionProductsName
            // 
            this.txtCompositionProductsName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCompositionProductsName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompositionProductsName.Enabled = false;
            this.txtCompositionProductsName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCompositionProductsName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtCompositionProductsName.Location = new System.Drawing.Point(5, 34);
            this.txtCompositionProductsName.MaxLength = 9;
            this.txtCompositionProductsName.Name = "txtCompositionProductsName";
            this.txtCompositionProductsName.Size = new System.Drawing.Size(250, 25);
            this.txtCompositionProductsName.TabIndex = 2;
            this.txtCompositionProductsName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtCompositionProductsName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtProductionProcessName
            // 
            this.txtProductionProcessName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtProductionProcessName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductionProcessName.Enabled = false;
            this.txtProductionProcessName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtProductionProcessName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtProductionProcessName.Location = new System.Drawing.Point(5, 95);
            this.txtProductionProcessName.MaxLength = 9;
            this.txtProductionProcessName.Name = "txtProductionProcessName";
            this.txtProductionProcessName.Size = new System.Drawing.Size(250, 25);
            this.txtProductionProcessName.TabIndex = 5;
            this.txtProductionProcessName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtProductionProcessName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtProductionProcessCode
            // 
            this.txtProductionProcessCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtProductionProcessCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductionProcessCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtProductionProcessCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtProductionProcessCode.Location = new System.Drawing.Point(5, 65);
            this.txtProductionProcessCode.MaxLength = 20;
            this.txtProductionProcessCode.Name = "txtProductionProcessCode";
            this.txtProductionProcessCode.Size = new System.Drawing.Size(250, 25);
            this.txtProductionProcessCode.TabIndex = 3;
            this.txtProductionProcessCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtProductionProcessCode.Leave += new System.EventHandler(this.txtProductionProcessCode_Leave);
            this.txtProductionProcessCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // btnProductionProcess
            // 
            this.btnProductionProcess.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnProductionProcess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProductionProcess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProductionProcess.FlatAppearance.BorderSize = 0;
            this.btnProductionProcess.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnProductionProcess.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnProductionProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductionProcess.Location = new System.Drawing.Point(261, 66);
            this.btnProductionProcess.Name = "btnProductionProcess";
            this.btnProductionProcess.Size = new System.Drawing.Size(25, 25);
            this.btnProductionProcess.TabIndex = 4;
            this.btnProductionProcess.UseVisualStyleBackColor = true;
            this.btnProductionProcess.Click += new System.EventHandler(this.btnProductionProcess_Click);
            // 
            // txtCompositionProductsCode
            // 
            this.txtCompositionProductsCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtCompositionProductsCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompositionProductsCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCompositionProductsCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtCompositionProductsCode.Location = new System.Drawing.Point(5, 5);
            this.txtCompositionProductsCode.MaxLength = 20;
            this.txtCompositionProductsCode.Name = "txtCompositionProductsCode";
            this.txtCompositionProductsCode.Size = new System.Drawing.Size(250, 25);
            this.txtCompositionProductsCode.TabIndex = 0;
            this.txtCompositionProductsCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtCompositionProductsCode.Leave += new System.EventHandler(this.txtCompositionProductsCode_Leave);
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
            this.label2.Text = "序　　号";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.SteelBlue;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 35);
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
            this.label4.Location = new System.Drawing.Point(5, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 141;
            this.label4.Text = "工序名称";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 136;
            this.label1.Text = "工序编号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 140;
            this.label3.Text = "部件编号";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmCompositionProductsProductionProcessDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(444, 223);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCompositionProductsProductionProcessDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新建";
            this.Load += new System.EventHandler(this.FrmCompositionProductsProductionProcessDialog_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCompositionProductsProductionProcessDialog_FormClosed);
            this.pInfo.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pInfo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCompositionProducts;
        private System.Windows.Forms.TextBox txtCompositionProductsName;
        private System.Windows.Forms.TextBox txtProductionProcessName;
        private System.Windows.Forms.TextBox txtProductionProcessCode;
        private System.Windows.Forms.Button btnProductionProcess;
        private System.Windows.Forms.TextBox txtCompositionProductsCode;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOrder;
        private System.Windows.Forms.Label label2;

    }
}