namespace CZZD.ERP.WinUI
{
    partial class FrmCompanyDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCompanyDialog));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtNameShort = new System.Windows.Forms.TextBox();
            this.txtZipCode = new System.Windows.Forms.TextBox();
            this.txtAddressFirst = new System.Windows.Forms.TextBox();
            this.txtAddressLast = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.txtAddressMiddle = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.txtEnglishName = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtLogo = new System.Windows.Forms.TextBox();
            this.txtCompanyPicture = new System.Windows.Forms.TextBox();
            this.btnLogo = new System.Windows.Forms.Button();
            this.btnCompanyPicture = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.picCompany = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCompany)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(438, 577);
            this.panel1.TabIndex = 98;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.picCompany);
            this.panel3.Controls.Add(this.picLogo);
            this.panel3.Controls.Add(this.btnCompanyPicture);
            this.panel3.Controls.Add(this.btnLogo);
            this.panel3.Controls.Add(this.txtCompanyPicture);
            this.panel3.Controls.Add(this.txtLogo);
            this.panel3.Controls.Add(this.txtCode);
            this.panel3.Controls.Add(this.txtNameShort);
            this.panel3.Controls.Add(this.txtZipCode);
            this.panel3.Controls.Add(this.txtAddressFirst);
            this.panel3.Controls.Add(this.txtAddressLast);
            this.panel3.Controls.Add(this.txtPhone);
            this.panel3.Controls.Add(this.txtEmail);
            this.panel3.Controls.Add(this.txtMemo);
            this.panel3.Controls.Add(this.txtAddressMiddle);
            this.panel3.Controls.Add(this.txtName);
            this.panel3.Controls.Add(this.txtFax);
            this.panel3.Controls.Add(this.txtURL);
            this.panel3.Controls.Add(this.txtEnglishName);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(120, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(314, 573);
            this.panel3.TabIndex = 98;
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtCode.Location = new System.Drawing.Point(5, 5);
            this.txtCode.MaxLength = 2;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(250, 25);
            this.txtCode.TabIndex = 1;
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtCode.Leave += new System.EventHandler(this.txtCode_Leave);
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtNameShort
            // 
            this.txtNameShort.BackColor = System.Drawing.SystemColors.Info;
            this.txtNameShort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNameShort.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtNameShort.Location = new System.Drawing.Point(5, 65);
            this.txtNameShort.MaxLength = 50;
            this.txtNameShort.Name = "txtNameShort";
            this.txtNameShort.Size = new System.Drawing.Size(250, 25);
            this.txtNameShort.TabIndex = 3;
            this.txtNameShort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtNameShort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtZipCode
            // 
            this.txtZipCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtZipCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtZipCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtZipCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtZipCode.Location = new System.Drawing.Point(5, 125);
            this.txtZipCode.MaxLength = 8;
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(250, 25);
            this.txtZipCode.TabIndex = 5;
            this.txtZipCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtZipCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtAddressFirst
            // 
            this.txtAddressFirst.BackColor = System.Drawing.SystemColors.Info;
            this.txtAddressFirst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddressFirst.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtAddressFirst.Location = new System.Drawing.Point(5, 155);
            this.txtAddressFirst.MaxLength = 100;
            this.txtAddressFirst.Name = "txtAddressFirst";
            this.txtAddressFirst.Size = new System.Drawing.Size(250, 25);
            this.txtAddressFirst.TabIndex = 6;
            this.txtAddressFirst.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtAddressFirst.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtAddressLast
            // 
            this.txtAddressLast.BackColor = System.Drawing.SystemColors.Info;
            this.txtAddressLast.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddressLast.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtAddressLast.Location = new System.Drawing.Point(5, 215);
            this.txtAddressLast.MaxLength = 100;
            this.txtAddressLast.Name = "txtAddressLast";
            this.txtAddressLast.Size = new System.Drawing.Size(250, 25);
            this.txtAddressLast.TabIndex = 8;
            this.txtAddressLast.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtAddressLast.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.SystemColors.Info;
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtPhone.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtPhone.Location = new System.Drawing.Point(5, 245);
            this.txtPhone.MaxLength = 20;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ShortcutsEnabled = false;
            this.txtPhone.Size = new System.Drawing.Size(250, 25);
            this.txtPhone.TabIndex = 9;
            this.txtPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.SystemColors.Info;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtEmail.Location = new System.Drawing.Point(5, 305);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(250, 25);
            this.txtEmail.TabIndex = 11;
            this.txtEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            this.txtEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtMemo
            // 
            this.txtMemo.BackColor = System.Drawing.SystemColors.Info;
            this.txtMemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMemo.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtMemo.Location = new System.Drawing.Point(5, 365);
            this.txtMemo.MaxLength = 255;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(250, 25);
            this.txtMemo.TabIndex = 13;
            this.txtMemo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtMemo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtAddressMiddle
            // 
            this.txtAddressMiddle.BackColor = System.Drawing.SystemColors.Info;
            this.txtAddressMiddle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddressMiddle.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtAddressMiddle.Location = new System.Drawing.Point(5, 185);
            this.txtAddressMiddle.MaxLength = 100;
            this.txtAddressMiddle.Name = "txtAddressMiddle";
            this.txtAddressMiddle.Size = new System.Drawing.Size(250, 25);
            this.txtAddressMiddle.TabIndex = 7;
            this.txtAddressMiddle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtAddressMiddle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
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
            // txtFax
            // 
            this.txtFax.BackColor = System.Drawing.SystemColors.Info;
            this.txtFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFax.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtFax.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtFax.Location = new System.Drawing.Point(5, 275);
            this.txtFax.MaxLength = 20;
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(250, 25);
            this.txtFax.TabIndex = 10;
            this.txtFax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtFax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtURL
            // 
            this.txtURL.BackColor = System.Drawing.SystemColors.Info;
            this.txtURL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtURL.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtURL.Location = new System.Drawing.Point(5, 335);
            this.txtURL.MaxLength = 50;
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(250, 25);
            this.txtURL.TabIndex = 12;
            this.txtURL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtURL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtEnglishName
            // 
            this.txtEnglishName.BackColor = System.Drawing.SystemColors.Info;
            this.txtEnglishName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEnglishName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtEnglishName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtEnglishName.Location = new System.Drawing.Point(5, 95);
            this.txtEnglishName.MaxLength = 50;
            this.txtEnglishName.Name = "txtEnglishName";
            this.txtEnglishName.Size = new System.Drawing.Size(250, 25);
            this.txtEnglishName.TabIndex = 4;
            this.txtEnglishName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtEnglishName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(120, 573);
            this.panel2.TabIndex = 97;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 83;
            this.label3.Text = "名称";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.SteelBlue;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 87;
            this.label5.Text = "地址1";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.SteelBlue;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(5, 305);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 20);
            this.label8.TabIndex = 89;
            this.label8.Text = "公司邮箱";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.SteelBlue;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(5, 275);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 20);
            this.label9.TabIndex = 82;
            this.label9.Text = "公司传真";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.SteelBlue;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(5, 95);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(110, 20);
            this.label14.TabIndex = 84;
            this.label14.Text = "英文名称";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.SteelBlue;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(5, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 20);
            this.label11.TabIndex = 88;
            this.label11.Text = "简称";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.SteelBlue;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(5, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 20);
            this.label6.TabIndex = 85;
            this.label6.Text = "地址2：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.SteelBlue;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(5, 125);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 20);
            this.label12.TabIndex = 86;
            this.label12.Text = "邮政编码";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.SteelBlue;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 92;
            this.label4.Text = "公司编号";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 335);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 95;
            this.label1.Text = "公司网址";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.SteelBlue;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(5, 245);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(110, 20);
            this.label13.TabIndex = 91;
            this.label13.Text = "公司电话";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 365);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 96;
            this.label2.Text = "备注";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.SteelBlue;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(5, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 20);
            this.label7.TabIndex = 90;
            this.label7.Text = "地址3";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnCancel.Location = new System.Drawing.Point(348, 580);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 94;
            this.btnCancel.Text = "取 消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSave.Location = new System.Drawing.Point(250, 580);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 93;
            this.btnSave.Text = "保 存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.SteelBlue;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(5, 395);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 20);
            this.label10.TabIndex = 97;
            this.label10.Text = "LOGO图片";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.SteelBlue;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(3, 487);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(110, 20);
            this.label15.TabIndex = 98;
            this.label15.Text = "公司名称图片";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLogo
            // 
            this.txtLogo.BackColor = System.Drawing.SystemColors.Info;
            this.txtLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLogo.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtLogo.Location = new System.Drawing.Point(5, 395);
            this.txtLogo.MaxLength = 255;
            this.txtLogo.Name = "txtLogo";
            this.txtLogo.Size = new System.Drawing.Size(250, 25);
            this.txtLogo.TabIndex = 14;
            // 
            // txtCompanyPicture
            // 
            this.txtCompanyPicture.BackColor = System.Drawing.SystemColors.Info;
            this.txtCompanyPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompanyPicture.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCompanyPicture.Location = new System.Drawing.Point(5, 485);
            this.txtCompanyPicture.MaxLength = 255;
            this.txtCompanyPicture.Name = "txtCompanyPicture";
            this.txtCompanyPicture.Size = new System.Drawing.Size(250, 25);
            this.txtCompanyPicture.TabIndex = 15;
            // 
            // btnLogo
            // 
            this.btnLogo.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogo.FlatAppearance.BorderSize = 0;
            this.btnLogo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnLogo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnLogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogo.Location = new System.Drawing.Point(261, 396);
            this.btnLogo.Name = "btnLogo";
            this.btnLogo.Size = new System.Drawing.Size(25, 25);
            this.btnLogo.TabIndex = 16;
            this.btnLogo.UseVisualStyleBackColor = true;
            this.btnLogo.Click += new System.EventHandler(this.btnLogo_Click);
            // 
            // btnCompanyPicture
            // 
            this.btnCompanyPicture.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnCompanyPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCompanyPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompanyPicture.FlatAppearance.BorderSize = 0;
            this.btnCompanyPicture.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCompanyPicture.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCompanyPicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompanyPicture.Location = new System.Drawing.Point(261, 486);
            this.btnCompanyPicture.Name = "btnCompanyPicture";
            this.btnCompanyPicture.Size = new System.Drawing.Size(25, 25);
            this.btnCompanyPicture.TabIndex = 17;
            this.btnCompanyPicture.UseVisualStyleBackColor = true;
            this.btnCompanyPicture.Click += new System.EventHandler(this.btnCompanyPicture_Click);
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(5, 425);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(249, 55);
            this.picLogo.TabIndex = 18;
            this.picLogo.TabStop = false;
            // 
            // picCompany
            // 
            this.picCompany.Location = new System.Drawing.Point(5, 515);
            this.picCompany.Name = "picCompany";
            this.picCompany.Size = new System.Drawing.Size(249, 55);
            this.picCompany.TabIndex = 19;
            this.picCompany.TabStop = false;
            // 
            // FrmCompanyDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(438, 615);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCompanyDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "公司编辑";
            this.Load += new System.EventHandler(this.FrmCompanyDialog_Load);
            this.Shown += new System.EventHandler(this.FrmCompanyDialog_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCompanyDialog_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCompany)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtNameShort;
        private System.Windows.Forms.TextBox txtZipCode;
        private System.Windows.Forms.TextBox txtAddressFirst;
        private System.Windows.Forms.TextBox txtAddressLast;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.TextBox txtAddressMiddle;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.TextBox txtEnglishName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCompanyPicture;
        private System.Windows.Forms.TextBox txtLogo;
        private System.Windows.Forms.Button btnCompanyPicture;
        private System.Windows.Forms.Button btnLogo;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.PictureBox picCompany;

    }
}