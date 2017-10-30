namespace CZZD.ERP.WinUI
{
    partial class FrmSpecificationDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSpecificationDialog));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtSpec = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.pInfo = new System.Windows.Forms.Panel();
            this.pRight = new System.Windows.Forms.Panel();
            this.pLeft = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtBasicName = new System.Windows.Forms.TextBox();
            this.btnUnit = new System.Windows.Forms.Button();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtBasic = new System.Windows.Forms.TextBox();
            this.pInfo.SuspendLayout();
            this.pRight.SuspendLayout();
            this.pLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnCancel.Location = new System.Drawing.Point(349, 190);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取 消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSave.Location = new System.Drawing.Point(254, 190);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保 存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtSpec
            // 
            this.txtSpec.BackColor = System.Drawing.SystemColors.Info;
            this.txtSpec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSpec.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSpec.Location = new System.Drawing.Point(5, 65);
            this.txtSpec.MaxLength = 100;
            this.txtSpec.Name = "txtSpec";
            this.txtSpec.Size = new System.Drawing.Size(250, 25);
            this.txtSpec.TabIndex = 3;
            this.txtSpec.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtCode.Location = new System.Drawing.Point(5, 5);
            this.txtCode.MaxLength = 20;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(250, 25);
            this.txtCode.TabIndex = 1;
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtName.Location = new System.Drawing.Point(5, 35);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(250, 25);
            this.txtName.TabIndex = 2;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // pInfo
            // 
            this.pInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pInfo.Controls.Add(this.pRight);
            this.pInfo.Controls.Add(this.pLeft);
            this.pInfo.Location = new System.Drawing.Point(3, 3);
            this.pInfo.Name = "pInfo";
            this.pInfo.Size = new System.Drawing.Size(438, 186);
            this.pInfo.TabIndex = 0;
            // 
            // pRight
            // 
            this.pRight.Controls.Add(this.txtBasicName);
            this.pRight.Controls.Add(this.btnUnit);
            this.pRight.Controls.Add(this.txtPrice);
            this.pRight.Controls.Add(this.txtBasic);
            this.pRight.Controls.Add(this.txtCode);
            this.pRight.Controls.Add(this.txtName);
            this.pRight.Controls.Add(this.txtSpec);
            this.pRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRight.Location = new System.Drawing.Point(120, 0);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(314, 182);
            this.pRight.TabIndex = 0;
            // 
            // pLeft
            // 
            this.pLeft.BackColor = System.Drawing.Color.SteelBlue;
            this.pLeft.Controls.Add(this.label9);
            this.pLeft.Controls.Add(this.label2);
            this.pLeft.Controls.Add(this.label18);
            this.pLeft.Controls.Add(this.label14);
            this.pLeft.Controls.Add(this.label19);
            this.pLeft.Controls.Add(this.label22);
            this.pLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeft.Location = new System.Drawing.Point(0, 0);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(120, 182);
            this.pLeft.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.SteelBlue;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(5, 5);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(115, 20);
            this.label14.TabIndex = 53;
            this.label14.Text = "规格/型号编号：";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.SteelBlue;
            this.label19.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(5, 65);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(110, 20);
            this.label19.TabIndex = 49;
            this.label19.Text = "规格：";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.SteelBlue;
            this.label22.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(5, 35);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(115, 20);
            this.label22.TabIndex = 43;
            this.label22.Text = "规格/型号名称：";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.SteelBlue;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(5, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 20);
            this.label9.TabIndex = 62;
            this.label9.Text = "单位名称：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 60;
            this.label2.Text = "默认售价：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.SteelBlue;
            this.label18.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(5, 95);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(110, 20);
            this.label18.TabIndex = 61;
            this.label18.Text = "单位编号：";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBasicName
            // 
            this.txtBasicName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtBasicName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBasicName.Enabled = false;
            this.txtBasicName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtBasicName.Location = new System.Drawing.Point(5, 125);
            this.txtBasicName.MaxLength = 100;
            this.txtBasicName.Name = "txtBasicName";
            this.txtBasicName.Size = new System.Drawing.Size(250, 25);
            this.txtBasicName.TabIndex = 13;
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
            this.btnUnit.Location = new System.Drawing.Point(261, 96);
            this.btnUnit.Name = "btnUnit";
            this.btnUnit.Size = new System.Drawing.Size(25, 25);
            this.btnUnit.TabIndex = 12;
            this.btnUnit.UseVisualStyleBackColor = true;
            this.btnUnit.Click += new System.EventHandler(this.btnUnit_Click);
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.SystemColors.Info;
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrice.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtPrice.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtPrice.Location = new System.Drawing.Point(5, 154);
            this.txtPrice.MaxLength = 9;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(250, 25);
            this.txtPrice.TabIndex = 14;
            // 
            // txtBasic
            // 
            this.txtBasic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtBasic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBasic.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtBasic.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtBasic.Location = new System.Drawing.Point(5, 95);
            this.txtBasic.MaxLength = 20;
            this.txtBasic.Name = "txtBasic";
            this.txtBasic.Size = new System.Drawing.Size(250, 25);
            this.txtBasic.TabIndex = 11;
            this.txtBasic.Leave += new System.EventHandler(this.txtBasic_Leave);
            // 
            // FrmSpecificationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(441, 221);
            this.Controls.Add(this.pInfo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSpecificationDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "规格/型号编辑";
            this.Load += new System.EventHandler(this.FrmproductDialog_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmUserDialog_FormClosed);
            this.pInfo.ResumeLayout(false);
            this.pRight.ResumeLayout(false);
            this.pRight.PerformLayout();
            this.pLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtSpec;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Panel pInfo;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtBasicName;
        private System.Windows.Forms.Button btnUnit;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtBasic;
    }
}