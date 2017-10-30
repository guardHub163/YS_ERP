namespace CZZD.ERP.WinUI
{
    partial class FrmProductGroupDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProductGroupDialog));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtParentCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnParentCode = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtThirdSupplierName = new System.Windows.Forms.TextBox();
            this.txtthirdSupplier = new System.Windows.Forms.TextBox();
            this.btnThirdSupplier = new System.Windows.Forms.Button();
            this.txtSecondSupplierName = new System.Windows.Forms.TextBox();
            this.txtSecondSupplier = new System.Windows.Forms.TextBox();
            this.btnSecondSupplier = new System.Windows.Forms.Button();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.txtSupplierCode = new System.Windows.Forms.TextBox();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.txtParentName = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnCancel.Location = new System.Drawing.Point(358, 306);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSave.Location = new System.Drawing.Point(262, 306);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = " 种类名称：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtParentCode
            // 
            this.txtParentCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtParentCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtParentCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtParentCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtParentCode.Location = new System.Drawing.Point(5, 65);
            this.txtParentCode.MaxLength = 20;
            this.txtParentCode.Name = "txtParentCode";
            this.txtParentCode.Size = new System.Drawing.Size(250, 25);
            this.txtParentCode.TabIndex = 3;
            this.txtParentCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtParentCode.Leave += new System.EventHandler(this.txtParentCode_Leave);
            this.txtParentCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = " 上级编号：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtCode.Leave += new System.EventHandler(this.txtCode_Leave);
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = " 种类编号：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnParentCode
            // 
            this.btnParentCode.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnParentCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnParentCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnParentCode.FlatAppearance.BorderSize = 0;
            this.btnParentCode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnParentCode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnParentCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParentCode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnParentCode.Location = new System.Drawing.Point(261, 65);
            this.btnParentCode.Name = "btnParentCode";
            this.btnParentCode.Size = new System.Drawing.Size(25, 25);
            this.btnParentCode.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnParentCode, "查询");
            this.btnParentCode.UseVisualStyleBackColor = true;
            this.btnParentCode.MouseLeave += new System.EventHandler(this.btnSearch_MouseLeave);
            this.btnParentCode.Click += new System.EventHandler(this.btnParentCode_Click);
            this.btnParentCode.MouseEnter += new System.EventHandler(this.btnSearch_MouseEnter);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 306);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtThirdSupplierName);
            this.panel3.Controls.Add(this.txtthirdSupplier);
            this.panel3.Controls.Add(this.btnThirdSupplier);
            this.panel3.Controls.Add(this.txtSecondSupplierName);
            this.panel3.Controls.Add(this.txtSecondSupplier);
            this.panel3.Controls.Add(this.btnSecondSupplier);
            this.panel3.Controls.Add(this.txtSupplierName);
            this.panel3.Controls.Add(this.txtSupplierCode);
            this.panel3.Controls.Add(this.btnSupplier);
            this.panel3.Controls.Add(this.txtParentName);
            this.panel3.Controls.Add(this.txtCode);
            this.panel3.Controls.Add(this.btnParentCode);
            this.panel3.Controls.Add(this.txtParentCode);
            this.panel3.Controls.Add(this.txtName);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(126, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(320, 302);
            this.panel3.TabIndex = 1;
            // 
            // txtThirdSupplierName
            // 
            this.txtThirdSupplierName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtThirdSupplierName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtThirdSupplierName.Enabled = false;
            this.txtThirdSupplierName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtThirdSupplierName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtThirdSupplierName.Location = new System.Drawing.Point(5, 271);
            this.txtThirdSupplierName.MaxLength = 9;
            this.txtThirdSupplierName.Name = "txtThirdSupplierName";
            this.txtThirdSupplierName.Size = new System.Drawing.Size(250, 25);
            this.txtThirdSupplierName.TabIndex = 18;
            // 
            // txtthirdSupplier
            // 
            this.txtthirdSupplier.BackColor = System.Drawing.SystemColors.Info;
            this.txtthirdSupplier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtthirdSupplier.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtthirdSupplier.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtthirdSupplier.Location = new System.Drawing.Point(5, 243);
            this.txtthirdSupplier.MaxLength = 20;
            this.txtthirdSupplier.Name = "txtthirdSupplier";
            this.txtthirdSupplier.Size = new System.Drawing.Size(250, 25);
            this.txtthirdSupplier.TabIndex = 16;
            this.txtthirdSupplier.Leave += new System.EventHandler(this.txtthirdSupplier_Leave);
            // 
            // btnThirdSupplier
            // 
            this.btnThirdSupplier.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnThirdSupplier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnThirdSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThirdSupplier.FlatAppearance.BorderSize = 0;
            this.btnThirdSupplier.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnThirdSupplier.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnThirdSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThirdSupplier.Location = new System.Drawing.Point(261, 244);
            this.btnThirdSupplier.Name = "btnThirdSupplier";
            this.btnThirdSupplier.Size = new System.Drawing.Size(25, 25);
            this.btnThirdSupplier.TabIndex = 17;
            this.toolTip1.SetToolTip(this.btnThirdSupplier, "查询");
            this.btnThirdSupplier.UseVisualStyleBackColor = true;
            this.btnThirdSupplier.Click += new System.EventHandler(this.btnThirdSupplier_Click);
            // 
            // txtSecondSupplierName
            // 
            this.txtSecondSupplierName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtSecondSupplierName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSecondSupplierName.Enabled = false;
            this.txtSecondSupplierName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSecondSupplierName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtSecondSupplierName.Location = new System.Drawing.Point(5, 214);
            this.txtSecondSupplierName.MaxLength = 9;
            this.txtSecondSupplierName.Name = "txtSecondSupplierName";
            this.txtSecondSupplierName.Size = new System.Drawing.Size(250, 25);
            this.txtSecondSupplierName.TabIndex = 15;
            // 
            // txtSecondSupplier
            // 
            this.txtSecondSupplier.BackColor = System.Drawing.SystemColors.Info;
            this.txtSecondSupplier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSecondSupplier.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSecondSupplier.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtSecondSupplier.Location = new System.Drawing.Point(5, 184);
            this.txtSecondSupplier.MaxLength = 20;
            this.txtSecondSupplier.Name = "txtSecondSupplier";
            this.txtSecondSupplier.Size = new System.Drawing.Size(250, 25);
            this.txtSecondSupplier.TabIndex = 13;
            this.txtSecondSupplier.Leave += new System.EventHandler(this.txtSecondSupplier_Leave);
            // 
            // btnSecondSupplier
            // 
            this.btnSecondSupplier.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnSecondSupplier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSecondSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSecondSupplier.FlatAppearance.BorderSize = 0;
            this.btnSecondSupplier.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSecondSupplier.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSecondSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSecondSupplier.Location = new System.Drawing.Point(262, 184);
            this.btnSecondSupplier.Name = "btnSecondSupplier";
            this.btnSecondSupplier.Size = new System.Drawing.Size(25, 25);
            this.btnSecondSupplier.TabIndex = 14;
            this.toolTip1.SetToolTip(this.btnSecondSupplier, "查询");
            this.btnSecondSupplier.UseVisualStyleBackColor = true;
            this.btnSecondSupplier.Click += new System.EventHandler(this.btnSecondSupplier_Click);
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtSupplierName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupplierName.Enabled = false;
            this.txtSupplierName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSupplierName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtSupplierName.Location = new System.Drawing.Point(5, 155);
            this.txtSupplierName.MaxLength = 9;
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(250, 25);
            this.txtSupplierName.TabIndex = 12;
            // 
            // txtSupplierCode
            // 
            this.txtSupplierCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtSupplierCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupplierCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSupplierCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtSupplierCode.Location = new System.Drawing.Point(5, 125);
            this.txtSupplierCode.MaxLength = 20;
            this.txtSupplierCode.Name = "txtSupplierCode";
            this.txtSupplierCode.Size = new System.Drawing.Size(250, 25);
            this.txtSupplierCode.TabIndex = 10;
            this.txtSupplierCode.Leave += new System.EventHandler(this.txtSupplierCode_Leave);
            // 
            // btnSupplier
            // 
            this.btnSupplier.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnSupplier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSupplier.FlatAppearance.BorderSize = 0;
            this.btnSupplier.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSupplier.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupplier.Location = new System.Drawing.Point(261, 126);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(25, 25);
            this.btnSupplier.TabIndex = 11;
            this.toolTip1.SetToolTip(this.btnSupplier, "查询");
            this.btnSupplier.UseVisualStyleBackColor = true;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // txtParentName
            // 
            this.txtParentName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtParentName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtParentName.Enabled = false;
            this.txtParentName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtParentName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtParentName.Location = new System.Drawing.Point(5, 94);
            this.txtParentName.MaxLength = 20;
            this.txtParentName.Name = "txtParentName";
            this.txtParentName.Size = new System.Drawing.Size(250, 25);
            this.txtParentName.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(126, 302);
            this.panel2.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.SteelBlue;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(5, 275);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 20);
            this.label10.TabIndex = 149;
            this.label10.Text = " 供应商3名称：";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.SteelBlue;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(5, 245);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 20);
            this.label11.TabIndex = 148;
            this.label11.Text = " 供应商3编号：";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.SteelBlue;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(5, 215);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 20);
            this.label8.TabIndex = 147;
            this.label8.Text = " 供应商2名称：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.SteelBlue;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(5, 185);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 20);
            this.label9.TabIndex = 146;
            this.label9.Text = " 供应商2编号：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.SteelBlue;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 20);
            this.label5.TabIndex = 145;
            this.label5.Text = " 供应商名称：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.SteelBlue;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(5, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 20);
            this.label7.TabIndex = 144;
            this.label7.Text = " 默认供应商：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.SteelBlue;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = " 上级名称：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmProductGroupDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(450, 338);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProductGroupDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "种类编辑";
            this.Load += new System.EventHandler(this.FrmProductGroupDialog_Load);
            this.Shown += new System.EventHandler(this.FrmProductGroupDialog_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmProductGroupDialog_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtParentCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnParentCode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtParentName;
        private System.Windows.Forms.TextBox txtThirdSupplierName;
        private System.Windows.Forms.TextBox txtthirdSupplier;
        private System.Windows.Forms.Button btnThirdSupplier;
        private System.Windows.Forms.TextBox txtSecondSupplierName;
        private System.Windows.Forms.TextBox txtSecondSupplier;
        private System.Windows.Forms.Button btnSecondSupplier;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.TextBox txtSupplierCode;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
    }
}