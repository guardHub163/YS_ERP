namespace CZZD.ERP.WinUI
{
    partial class FrmProductDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProductDialog));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnGroupCode = new System.Windows.Forms.Button();
            this.txtSpec = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtGroupCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtBasic = new System.Windows.Forms.TextBox();
            this.txtModelNumber = new System.Windows.Forms.TextBox();
            this.pInfo = new System.Windows.Forms.Panel();
            this.pRight = new System.Windows.Forms.Panel();
            this.txtSafetyStock = new System.Windows.Forms.TextBox();
            this.txtBasicName = new System.Windows.Forms.TextBox();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.btnUnit = new System.Windows.Forms.Button();
            this.txtPurchase_Price = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pLeft = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnNew = new System.Windows.Forms.Button();
            this.pInfo.SuspendLayout();
            this.pRight.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnCancel.Location = new System.Drawing.Point(348, 336);
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
            this.btnSave.Location = new System.Drawing.Point(253, 336);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保 存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // btnGroupCode
            // 
            this.btnGroupCode.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnGroupCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGroupCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGroupCode.FlatAppearance.BorderSize = 0;
            this.btnGroupCode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnGroupCode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnGroupCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGroupCode.Location = new System.Drawing.Point(261, 124);
            this.btnGroupCode.Name = "btnGroupCode";
            this.btnGroupCode.Size = new System.Drawing.Size(25, 25);
            this.btnGroupCode.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btnGroupCode, "查询");
            this.btnGroupCode.UseVisualStyleBackColor = true;
            this.btnGroupCode.MouseLeave += new System.EventHandler(this.btnSearch_MouseLeave);
            this.btnGroupCode.Click += new System.EventHandler(this.btnGroupCode_Click);
            this.btnGroupCode.MouseEnter += new System.EventHandler(this.btnSearch_MouseEnter);
            this.btnGroupCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
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
            this.txtSpec.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
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
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtCode.Leave += new System.EventHandler(this.txtCode_Leave);
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtGroupCode
            // 
            this.txtGroupCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtGroupCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGroupCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtGroupCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtGroupCode.Location = new System.Drawing.Point(5, 124);
            this.txtGroupCode.MaxLength = 20;
            this.txtGroupCode.Name = "txtGroupCode";
            this.txtGroupCode.Size = new System.Drawing.Size(250, 25);
            this.txtGroupCode.TabIndex = 5;
            this.txtGroupCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtGroupCode.Leave += new System.EventHandler(this.txtGroupCode_Leave);
            this.txtGroupCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
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
            // txtBasic
            // 
            this.txtBasic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtBasic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBasic.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtBasic.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtBasic.Location = new System.Drawing.Point(5, 184);
            this.txtBasic.MaxLength = 20;
            this.txtBasic.Name = "txtBasic";
            this.txtBasic.Size = new System.Drawing.Size(250, 25);
            this.txtBasic.TabIndex = 7;
            this.txtBasic.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtBasic.Leave += new System.EventHandler(this.txtBasic_Leave);
            this.txtBasic.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtModelNumber
            // 
            this.txtModelNumber.BackColor = System.Drawing.SystemColors.Info;
            this.txtModelNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModelNumber.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtModelNumber.Location = new System.Drawing.Point(5, 95);
            this.txtModelNumber.MaxLength = 100;
            this.txtModelNumber.Name = "txtModelNumber";
            this.txtModelNumber.Size = new System.Drawing.Size(250, 25);
            this.txtModelNumber.TabIndex = 4;
            this.txtModelNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtModelNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // pInfo
            // 
            this.pInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pInfo.Controls.Add(this.pRight);
            this.pInfo.Controls.Add(this.panel1);
            this.pInfo.Location = new System.Drawing.Point(0, 0);
            this.pInfo.Name = "pInfo";
            this.pInfo.Size = new System.Drawing.Size(438, 336);
            this.pInfo.TabIndex = 0;
            // 
            // pRight
            // 
            this.pRight.Controls.Add(this.txtSafetyStock);
            this.pRight.Controls.Add(this.txtBasicName);
            this.pRight.Controls.Add(this.txtGroupName);
            this.pRight.Controls.Add(this.btnUnit);
            this.pRight.Controls.Add(this.txtCode);
            this.pRight.Controls.Add(this.txtName);
            this.pRight.Controls.Add(this.txtGroupCode);
            this.pRight.Controls.Add(this.btnGroupCode);
            this.pRight.Controls.Add(this.txtModelNumber);
            this.pRight.Controls.Add(this.txtPurchase_Price);
            this.pRight.Controls.Add(this.txtPrice);
            this.pRight.Controls.Add(this.txtSpec);
            this.pRight.Controls.Add(this.txtBasic);
            this.pRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRight.Location = new System.Drawing.Point(120, 0);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(314, 332);
            this.pRight.TabIndex = 0;
            // 
            // txtSafetyStock
            // 
            this.txtSafetyStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtSafetyStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSafetyStock.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSafetyStock.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtSafetyStock.Location = new System.Drawing.Point(5, 303);
            this.txtSafetyStock.MaxLength = 9;
            this.txtSafetyStock.Name = "txtSafetyStock";
            this.txtSafetyStock.Size = new System.Drawing.Size(250, 25);
            this.txtSafetyStock.TabIndex = 12;
            // 
            // txtBasicName
            // 
            this.txtBasicName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtBasicName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBasicName.Enabled = false;
            this.txtBasicName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtBasicName.Location = new System.Drawing.Point(5, 214);
            this.txtBasicName.MaxLength = 100;
            this.txtBasicName.Name = "txtBasicName";
            this.txtBasicName.Size = new System.Drawing.Size(250, 25);
            this.txtBasicName.TabIndex = 9;
            // 
            // txtGroupName
            // 
            this.txtGroupName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtGroupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGroupName.Enabled = false;
            this.txtGroupName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtGroupName.Location = new System.Drawing.Point(5, 154);
            this.txtGroupName.MaxLength = 100;
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(250, 25);
            this.txtGroupName.TabIndex = 63;
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
            this.btnUnit.Location = new System.Drawing.Point(261, 182);
            this.btnUnit.Name = "btnUnit";
            this.btnUnit.Size = new System.Drawing.Size(25, 25);
            this.btnUnit.TabIndex = 8;
            this.toolTip1.SetToolTip(this.btnUnit, "查询");
            this.btnUnit.UseVisualStyleBackColor = true;
            this.btnUnit.MouseLeave += new System.EventHandler(this.btnSearch_MouseLeave);
            this.btnUnit.Click += new System.EventHandler(this.btnUnit_Click);
            this.btnUnit.MouseEnter += new System.EventHandler(this.btnSearch_MouseEnter);
            this.btnUnit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // txtPurchase_Price
            // 
            this.txtPurchase_Price.BackColor = System.Drawing.SystemColors.Info;
            this.txtPurchase_Price.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPurchase_Price.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtPurchase_Price.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtPurchase_Price.Location = new System.Drawing.Point(5, 274);
            this.txtPurchase_Price.MaxLength = 10;
            this.txtPurchase_Price.Name = "txtPurchase_Price";
            this.txtPurchase_Price.Size = new System.Drawing.Size(250, 25);
            this.txtPurchase_Price.TabIndex = 11;
            this.txtPurchase_Price.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtPurchase_Price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.SystemColors.Info;
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrice.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtPrice.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtPrice.Location = new System.Drawing.Point(5, 245);
            this.txtPrice.MaxLength = 9;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(250, 25);
            this.txtPrice.TabIndex = 10;
            this.txtPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.pLeft);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 332);
            this.panel1.TabIndex = 58;
            // 
            // pLeft
            // 
            this.pLeft.BackColor = System.Drawing.Color.SteelBlue;
            this.pLeft.Controls.Add(this.label5);
            this.pLeft.Controls.Add(this.label9);
            this.pLeft.Controls.Add(this.label13);
            this.pLeft.Controls.Add(this.label14);
            this.pLeft.Controls.Add(this.label16);
            this.pLeft.Controls.Add(this.label2);
            this.pLeft.Controls.Add(this.label18);
            this.pLeft.Controls.Add(this.label19);
            this.pLeft.Controls.Add(this.label21);
            this.pLeft.Controls.Add(this.label22);
            this.pLeft.Controls.Add(this.label24);
            this.pLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeft.Location = new System.Drawing.Point(0, 0);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(120, 332);
            this.pLeft.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 304);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 60;
            this.label5.Text = " 安全在库数：";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.SteelBlue;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(5, 214);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 20);
            this.label9.TabIndex = 59;
            this.label9.Text = " 单位名称：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.SteelBlue;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(5, 154);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(110, 20);
            this.label13.TabIndex = 58;
            this.label13.Text = " 类别名称：";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.SteelBlue;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(5, 5);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(110, 20);
            this.label14.TabIndex = 53;
            this.label14.Text = " 商品编号：";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.SteelBlue;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(5, 274);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(110, 20);
            this.label16.TabIndex = 51;
            this.label16.Text = " 采购单价：";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 51;
            this.label2.Text = " 默认售价：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.SteelBlue;
            this.label18.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(5, 184);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(110, 20);
            this.label18.TabIndex = 56;
            this.label18.Text = " 基本单位：";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.SteelBlue;
            this.label19.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(5, 64);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(110, 20);
            this.label19.TabIndex = 49;
            this.label19.Text = " 规       格：";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.SteelBlue;
            this.label21.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(5, 94);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(110, 20);
            this.label21.TabIndex = 50;
            this.label21.Text = " 材　　质：";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.SteelBlue;
            this.label22.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(5, 35);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(110, 20);
            this.label22.TabIndex = 43;
            this.label22.Text = " 中文名称：";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.SteelBlue;
            this.label24.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(5, 124);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(110, 20);
            this.label24.TabIndex = 47;
            this.label24.Text = " 类别编号：";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.SteelBlue;
            this.label17.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(5, 274);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(110, 20);
            this.label17.TabIndex = 61;
            this.label17.Text = " 海关名称：";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.SteelBlue;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(5, 214);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(110, 20);
            this.label15.TabIndex = 59;
            this.label15.Text = " 单位名称：";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.SteelBlue;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(5, 154);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 20);
            this.label10.TabIndex = 58;
            this.label10.Text = " 类别名称：";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.SteelBlue;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 53;
            this.label4.Text = " 商品编号：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.SteelBlue;
            this.label20.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(5, 334);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(110, 20);
            this.label20.TabIndex = 51;
            this.label20.Text = " 采购单价：";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.SteelBlue;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(5, 304);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 20);
            this.label7.TabIndex = 51;
            this.label7.Text = " 默认售价：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 56;
            this.label1.Text = " 基本单位：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.SteelBlue;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(5, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 20);
            this.label11.TabIndex = 49;
            this.label11.Text = " 规       格：";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.SteelBlue;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(5, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 20);
            this.label8.TabIndex = 50;
            this.label8.Text = " 材　　质：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 43;
            this.label3.Text = " 中文名称：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.SteelBlue;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(5, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 20);
            this.label6.TabIndex = 46;
            this.label6.Text = " 海关编号：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.SteelBlue;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(5, 124);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 20);
            this.label12.TabIndex = 47;
            this.label12.Text = " 类别编号：";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnNew
            // 
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnNew.Location = new System.Drawing.Point(157, 336);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(90, 30);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "保存并新建";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Visible = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // FrmProductDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(440, 367);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.pInfo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProductDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "商品编辑";
            this.Load += new System.EventHandler(this.FrmproductDialog_Load);
            this.Shown += new System.EventHandler(this.FrmProductDialog_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmUserDialog_FormClosed);
            this.pInfo.ResumeLayout(false);
            this.pRight.ResumeLayout(false);
            this.pRight.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.pLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnGroupCode;
        private System.Windows.Forms.TextBox txtSpec;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtGroupCode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtBasic;
        private System.Windows.Forms.TextBox txtModelNumber;
        private System.Windows.Forms.Panel pInfo;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.Button btnUnit;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.TextBox txtBasicName;
        private System.Windows.Forms.TextBox txtPurchase_Price;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSafetyStock;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox txtPrice;
    }
}