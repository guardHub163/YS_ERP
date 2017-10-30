namespace CZZD.ERP.WinUI
{
    partial class FrmProductTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProductTree));
            this.tv = new System.Windows.Forms.TreeView();
            this.pBody = new System.Windows.Forms.Panel();
            this.pMove = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.contextMenuType = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuAddParts = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuParts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuDeleteParts = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddProductionProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuProductionProcess = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuMoveProductionProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDeleteProductionProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label23 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.txtTechnologyCode1 = new System.Windows.Forms.TextBox();
            this.txtTechnology3 = new System.Windows.Forms.TextBox();
            this.txtTechnologyCode3 = new System.Windows.Forms.TextBox();
            this.txtTechnology2 = new System.Windows.Forms.TextBox();
            this.txtTechnology1 = new System.Windows.Forms.TextBox();
            this.txtTechnologyCode2 = new System.Windows.Forms.TextBox();
            this.txtDrawingTypeCode6 = new System.Windows.Forms.TextBox();
            this.txtDrawingTypeCode5 = new System.Windows.Forms.TextBox();
            this.txtDrawingTypeCode4 = new System.Windows.Forms.TextBox();
            this.txtDrawingTypeCode3 = new System.Windows.Forms.TextBox();
            this.txtDrawingTypeCode2 = new System.Windows.Forms.TextBox();
            this.txtDrawingTypeCode1 = new System.Windows.Forms.TextBox();
            this.txtDepartmentCode = new System.Windows.Forms.TextBox();
            this.txtDrawingType6 = new System.Windows.Forms.TextBox();
            this.txtDrawingType5 = new System.Windows.Forms.TextBox();
            this.txtDrawingType4 = new System.Windows.Forms.TextBox();
            this.txtDrawingType3 = new System.Windows.Forms.TextBox();
            this.txtDrawingType2 = new System.Windows.Forms.TextBox();
            this.txtDrawingType1 = new System.Windows.Forms.TextBox();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.txtproductioncycle = new System.Windows.Forms.TextBox();
            this.txtenglishname = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.drawingtypelbl = new System.Windows.Forms.Label();
            this.departmentlbl = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.pBody.SuspendLayout();
            this.pMove.SuspendLayout();
            this.contextMenuType.SuspendLayout();
            this.contextMenuParts.SuspendLayout();
            this.contextMenuProductionProcess.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tv
            // 
            this.tv.AllowDrop = true;
            this.tv.Location = new System.Drawing.Point(3, 3);
            this.tv.Name = "tv";
            this.tv.Size = new System.Drawing.Size(369, 652);
            this.tv.TabIndex = 0;
            this.tv.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_AfterSelect);
            this.tv.TabIndexChanged += new System.EventHandler(this.tv_TabIndexChanged);
            // 
            // pBody
            // 
            this.pBody.BackColor = System.Drawing.Color.White;
            this.pBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBody.Controls.Add(this.panel1);
            this.pBody.Controls.Add(this.tv);
            this.pBody.Location = new System.Drawing.Point(0, 0);
            this.pBody.Name = "pBody";
            this.pBody.Size = new System.Drawing.Size(1024, 660);
            this.pBody.TabIndex = 2;
            // 
            // pMove
            // 
            this.pMove.Controls.Add(this.btnCancel);
            this.pMove.Controls.Add(this.btnOK);
            this.pMove.Controls.Add(this.btnDown);
            this.pMove.Controls.Add(this.btnUp);
            this.pMove.Location = new System.Drawing.Point(565, 330);
            this.pMove.Name = "pMove";
            this.pMove.Size = new System.Drawing.Size(46, 109);
            this.pMove.TabIndex = 1;
            this.pMove.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Location = new System.Drawing.Point(3, 81);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(40, 25);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.Location = new System.Drawing.Point(3, 55);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(40, 25);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确认";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnDown
            // 
            this.btnDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDown.Location = new System.Drawing.Point(3, 29);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(40, 25);
            this.btnDown.TabIndex = 0;
            this.btnDown.Text = "向下";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUp.Location = new System.Drawing.Point(3, 3);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(40, 25);
            this.btnUp.TabIndex = 0;
            this.btnUp.Text = "向上";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // contextMenuType
            // 
            this.contextMenuType.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddParts});
            this.contextMenuType.Name = "menuType";
            this.contextMenuType.Size = new System.Drawing.Size(125, 26);
            // 
            // menuAddParts
            // 
            this.menuAddParts.Name = "menuAddParts";
            this.menuAddParts.Size = new System.Drawing.Size(124, 22);
            this.menuAddParts.Text = "增加部件";
            // 
            // contextMenuParts
            // 
            this.contextMenuParts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDeleteParts,
            this.menuAddProductionProcess});
            this.contextMenuParts.Name = "menuParts";
            this.contextMenuParts.Size = new System.Drawing.Size(125, 48);
            // 
            // menuDeleteParts
            // 
            this.menuDeleteParts.Name = "menuDeleteParts";
            this.menuDeleteParts.Size = new System.Drawing.Size(124, 22);
            this.menuDeleteParts.Text = "删除部件";
            // 
            // menuAddProductionProcess
            // 
            this.menuAddProductionProcess.Name = "menuAddProductionProcess";
            this.menuAddProductionProcess.Size = new System.Drawing.Size(124, 22);
            this.menuAddProductionProcess.Text = "增加工序";
            // 
            // contextMenuProductionProcess
            // 
            this.contextMenuProductionProcess.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMoveProductionProcess,
            this.menuDeleteProductionProcess});
            this.contextMenuProductionProcess.Name = "menuProductionProcess";
            this.contextMenuProductionProcess.Size = new System.Drawing.Size(125, 48);
            // 
            // menuMoveProductionProcess
            // 
            this.menuMoveProductionProcess.Name = "menuMoveProductionProcess";
            this.menuMoveProductionProcess.Size = new System.Drawing.Size(124, 22);
            this.menuMoveProductionProcess.Text = "调整顺序";
            // 
            // menuDeleteProductionProcess
            // 
            this.menuDeleteProductionProcess.Name = "menuDeleteProductionProcess";
            this.menuDeleteProductionProcess.Size = new System.Drawing.Size(124, 22);
            this.menuDeleteProductionProcess.Text = "删除工序";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtTechnologyCode1);
            this.panel1.Controls.Add(this.cboStatus);
            this.panel1.Controls.Add(this.pMove);
            this.panel1.Controls.Add(this.txtTechnology3);
            this.panel1.Controls.Add(this.txtTechnologyCode3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.txtTechnology2);
            this.panel1.Controls.Add(this.txtCode);
            this.panel1.Controls.Add(this.txtTechnology1);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.txtTechnologyCode2);
            this.panel1.Controls.Add(this.txtenglishname);
            this.panel1.Controls.Add(this.txtDrawingTypeCode6);
            this.panel1.Controls.Add(this.txtDepartment);
            this.panel1.Controls.Add(this.txtDrawingTypeCode5);
            this.panel1.Controls.Add(this.txtDrawingType1);
            this.panel1.Controls.Add(this.txtDrawingType6);
            this.panel1.Controls.Add(this.txtDrawingType5);
            this.panel1.Controls.Add(this.txtDrawingType2);
            this.panel1.Controls.Add(this.txtproductioncycle);
            this.panel1.Controls.Add(this.txtDrawingType3);
            this.panel1.Controls.Add(this.txtDrawingType4);
            this.panel1.Controls.Add(this.txtDrawingTypeCode4);
            this.panel1.Controls.Add(this.txtDrawingTypeCode3);
            this.panel1.Controls.Add(this.txtDrawingTypeCode2);
            this.panel1.Controls.Add(this.txtDrawingTypeCode1);
            this.panel1.Controls.Add(this.txtDepartmentCode);
            this.panel1.Location = new System.Drawing.Point(378, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(638, 652);
            this.panel1.TabIndex = 1;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(5, 605);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(103, 20);
            this.label23.TabIndex = 23;
            this.label23.Text = "是否为备料";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(5, 530);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 20);
            this.label8.TabIndex = 22;
            this.label8.Text = "技术编号3";
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(5, 554);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(103, 20);
            this.label20.TabIndex = 21;
            this.label20.Text = "技术名称3";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(5, 480);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "技术编号2";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(5, 505);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 20);
            this.label7.TabIndex = 19;
            this.label7.Text = "技术名称2";
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(5, 430);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(103, 20);
            this.label22.TabIndex = 18;
            this.label22.Text = "技术编号1";
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(5, 455);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(103, 20);
            this.label21.TabIndex = 17;
            this.label21.Text = "技术名称1";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 405);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "图纸类型名称6";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(5, 380);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 20);
            this.label9.TabIndex = 11;
            this.label9.Text = "图纸编号6";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(5, 355);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 20);
            this.label10.TabIndex = 10;
            this.label10.Text = "图纸类型名称5";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(5, 580);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(103, 20);
            this.label14.TabIndex = 6;
            this.label14.Text = "生产周期(天)";
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(5, 330);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(103, 20);
            this.label18.TabIndex = 2;
            this.label18.Text = "图纸编号5";
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Enabled = false;
            this.cboStatus.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(130, 605);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(250, 25);
            this.cboStatus.TabIndex = 40;
            // 
            // txtTechnologyCode1
            // 
            this.txtTechnologyCode1.BackColor = System.Drawing.SystemColors.Info;
            this.txtTechnologyCode1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTechnologyCode1.Enabled = false;
            this.txtTechnologyCode1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtTechnologyCode1.Location = new System.Drawing.Point(130, 430);
            this.txtTechnologyCode1.Name = "txtTechnologyCode1";
            this.txtTechnologyCode1.Size = new System.Drawing.Size(250, 23);
            this.txtTechnologyCode1.TabIndex = 36;
            // 
            // txtTechnology3
            // 
            this.txtTechnology3.BackColor = System.Drawing.Color.Gainsboro;
            this.txtTechnology3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTechnology3.Enabled = false;
            this.txtTechnology3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtTechnology3.Location = new System.Drawing.Point(130, 555);
            this.txtTechnology3.Name = "txtTechnology3";
            this.txtTechnology3.ReadOnly = true;
            this.txtTechnology3.Size = new System.Drawing.Size(250, 23);
            this.txtTechnology3.TabIndex = 35;
            // 
            // txtTechnologyCode3
            // 
            this.txtTechnologyCode3.BackColor = System.Drawing.SystemColors.Info;
            this.txtTechnologyCode3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTechnologyCode3.Enabled = false;
            this.txtTechnologyCode3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtTechnologyCode3.Location = new System.Drawing.Point(130, 530);
            this.txtTechnologyCode3.Name = "txtTechnologyCode3";
            this.txtTechnologyCode3.Size = new System.Drawing.Size(250, 23);
            this.txtTechnologyCode3.TabIndex = 34;
            // 
            // txtTechnology2
            // 
            this.txtTechnology2.BackColor = System.Drawing.Color.Gainsboro;
            this.txtTechnology2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTechnology2.Enabled = false;
            this.txtTechnology2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtTechnology2.Location = new System.Drawing.Point(130, 505);
            this.txtTechnology2.Name = "txtTechnology2";
            this.txtTechnology2.ReadOnly = true;
            this.txtTechnology2.Size = new System.Drawing.Size(250, 23);
            this.txtTechnology2.TabIndex = 33;
            // 
            // txtTechnology1
            // 
            this.txtTechnology1.BackColor = System.Drawing.Color.Gainsboro;
            this.txtTechnology1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTechnology1.Enabled = false;
            this.txtTechnology1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtTechnology1.Location = new System.Drawing.Point(130, 455);
            this.txtTechnology1.Name = "txtTechnology1";
            this.txtTechnology1.ReadOnly = true;
            this.txtTechnology1.Size = new System.Drawing.Size(250, 23);
            this.txtTechnology1.TabIndex = 32;
            // 
            // txtTechnologyCode2
            // 
            this.txtTechnologyCode2.BackColor = System.Drawing.SystemColors.Info;
            this.txtTechnologyCode2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTechnologyCode2.Enabled = false;
            this.txtTechnologyCode2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtTechnologyCode2.Location = new System.Drawing.Point(130, 480);
            this.txtTechnologyCode2.Name = "txtTechnologyCode2";
            this.txtTechnologyCode2.Size = new System.Drawing.Size(250, 23);
            this.txtTechnologyCode2.TabIndex = 31;
            // 
            // txtDrawingTypeCode6
            // 
            this.txtDrawingTypeCode6.BackColor = System.Drawing.SystemColors.Info;
            this.txtDrawingTypeCode6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDrawingTypeCode6.Enabled = false;
            this.txtDrawingTypeCode6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDrawingTypeCode6.Location = new System.Drawing.Point(130, 380);
            this.txtDrawingTypeCode6.Name = "txtDrawingTypeCode6";
            this.txtDrawingTypeCode6.Size = new System.Drawing.Size(250, 23);
            this.txtDrawingTypeCode6.TabIndex = 30;
            // 
            // txtDrawingTypeCode5
            // 
            this.txtDrawingTypeCode5.BackColor = System.Drawing.SystemColors.Info;
            this.txtDrawingTypeCode5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDrawingTypeCode5.Enabled = false;
            this.txtDrawingTypeCode5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDrawingTypeCode5.Location = new System.Drawing.Point(130, 330);
            this.txtDrawingTypeCode5.Name = "txtDrawingTypeCode5";
            this.txtDrawingTypeCode5.Size = new System.Drawing.Size(250, 23);
            this.txtDrawingTypeCode5.TabIndex = 29;
            // 
            // txtDrawingTypeCode4
            // 
            this.txtDrawingTypeCode4.BackColor = System.Drawing.SystemColors.Info;
            this.txtDrawingTypeCode4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDrawingTypeCode4.Enabled = false;
            this.txtDrawingTypeCode4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDrawingTypeCode4.Location = new System.Drawing.Point(130, 280);
            this.txtDrawingTypeCode4.Name = "txtDrawingTypeCode4";
            this.txtDrawingTypeCode4.Size = new System.Drawing.Size(250, 23);
            this.txtDrawingTypeCode4.TabIndex = 28;
            // 
            // txtDrawingTypeCode3
            // 
            this.txtDrawingTypeCode3.BackColor = System.Drawing.SystemColors.Info;
            this.txtDrawingTypeCode3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDrawingTypeCode3.Enabled = false;
            this.txtDrawingTypeCode3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDrawingTypeCode3.Location = new System.Drawing.Point(130, 230);
            this.txtDrawingTypeCode3.Name = "txtDrawingTypeCode3";
            this.txtDrawingTypeCode3.Size = new System.Drawing.Size(250, 23);
            this.txtDrawingTypeCode3.TabIndex = 27;
            // 
            // txtDrawingTypeCode2
            // 
            this.txtDrawingTypeCode2.BackColor = System.Drawing.SystemColors.Info;
            this.txtDrawingTypeCode2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDrawingTypeCode2.Enabled = false;
            this.txtDrawingTypeCode2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDrawingTypeCode2.Location = new System.Drawing.Point(130, 180);
            this.txtDrawingTypeCode2.Name = "txtDrawingTypeCode2";
            this.txtDrawingTypeCode2.Size = new System.Drawing.Size(250, 23);
            this.txtDrawingTypeCode2.TabIndex = 26;
            // 
            // txtDrawingTypeCode1
            // 
            this.txtDrawingTypeCode1.BackColor = System.Drawing.SystemColors.Info;
            this.txtDrawingTypeCode1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDrawingTypeCode1.Enabled = false;
            this.txtDrawingTypeCode1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDrawingTypeCode1.Location = new System.Drawing.Point(130, 130);
            this.txtDrawingTypeCode1.Name = "txtDrawingTypeCode1";
            this.txtDrawingTypeCode1.Size = new System.Drawing.Size(250, 23);
            this.txtDrawingTypeCode1.TabIndex = 25;
            // 
            // txtDepartmentCode
            // 
            this.txtDepartmentCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtDepartmentCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDepartmentCode.Enabled = false;
            this.txtDepartmentCode.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDepartmentCode.Location = new System.Drawing.Point(130, 80);
            this.txtDepartmentCode.Name = "txtDepartmentCode";
            this.txtDepartmentCode.Size = new System.Drawing.Size(250, 23);
            this.txtDepartmentCode.TabIndex = 24;
            // 
            // txtDrawingType6
            // 
            this.txtDrawingType6.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDrawingType6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDrawingType6.Enabled = false;
            this.txtDrawingType6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDrawingType6.Location = new System.Drawing.Point(130, 405);
            this.txtDrawingType6.Name = "txtDrawingType6";
            this.txtDrawingType6.ReadOnly = true;
            this.txtDrawingType6.Size = new System.Drawing.Size(250, 23);
            this.txtDrawingType6.TabIndex = 17;
            // 
            // txtDrawingType5
            // 
            this.txtDrawingType5.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDrawingType5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDrawingType5.Enabled = false;
            this.txtDrawingType5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDrawingType5.Location = new System.Drawing.Point(130, 355);
            this.txtDrawingType5.Name = "txtDrawingType5";
            this.txtDrawingType5.ReadOnly = true;
            this.txtDrawingType5.Size = new System.Drawing.Size(250, 23);
            this.txtDrawingType5.TabIndex = 16;
            // 
            // txtDrawingType4
            // 
            this.txtDrawingType4.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDrawingType4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDrawingType4.Enabled = false;
            this.txtDrawingType4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDrawingType4.Location = new System.Drawing.Point(130, 305);
            this.txtDrawingType4.Name = "txtDrawingType4";
            this.txtDrawingType4.ReadOnly = true;
            this.txtDrawingType4.Size = new System.Drawing.Size(250, 23);
            this.txtDrawingType4.TabIndex = 15;
            // 
            // txtDrawingType3
            // 
            this.txtDrawingType3.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDrawingType3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDrawingType3.Enabled = false;
            this.txtDrawingType3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDrawingType3.Location = new System.Drawing.Point(130, 255);
            this.txtDrawingType3.Name = "txtDrawingType3";
            this.txtDrawingType3.ReadOnly = true;
            this.txtDrawingType3.Size = new System.Drawing.Size(250, 23);
            this.txtDrawingType3.TabIndex = 14;
            // 
            // txtDrawingType2
            // 
            this.txtDrawingType2.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDrawingType2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDrawingType2.Enabled = false;
            this.txtDrawingType2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDrawingType2.Location = new System.Drawing.Point(130, 205);
            this.txtDrawingType2.Name = "txtDrawingType2";
            this.txtDrawingType2.ReadOnly = true;
            this.txtDrawingType2.Size = new System.Drawing.Size(250, 23);
            this.txtDrawingType2.TabIndex = 13;
            // 
            // txtDrawingType1
            // 
            this.txtDrawingType1.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDrawingType1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDrawingType1.Enabled = false;
            this.txtDrawingType1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDrawingType1.Location = new System.Drawing.Point(130, 155);
            this.txtDrawingType1.Name = "txtDrawingType1";
            this.txtDrawingType1.ReadOnly = true;
            this.txtDrawingType1.Size = new System.Drawing.Size(250, 23);
            this.txtDrawingType1.TabIndex = 12;
            // 
            // txtDepartment
            // 
            this.txtDepartment.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDepartment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDepartment.Enabled = false;
            this.txtDepartment.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDepartment.Location = new System.Drawing.Point(130, 105);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.ReadOnly = true;
            this.txtDepartment.Size = new System.Drawing.Size(250, 23);
            this.txtDepartment.TabIndex = 11;
            // 
            // txtproductioncycle
            // 
            this.txtproductioncycle.BackColor = System.Drawing.SystemColors.Info;
            this.txtproductioncycle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtproductioncycle.Enabled = false;
            this.txtproductioncycle.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtproductioncycle.Location = new System.Drawing.Point(130, 580);
            this.txtproductioncycle.Name = "txtproductioncycle";
            this.txtproductioncycle.Size = new System.Drawing.Size(250, 23);
            this.txtproductioncycle.TabIndex = 7;
            // 
            // txtenglishname
            // 
            this.txtenglishname.BackColor = System.Drawing.SystemColors.Info;
            this.txtenglishname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtenglishname.Enabled = false;
            this.txtenglishname.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtenglishname.Location = new System.Drawing.Point(130, 55);
            this.txtenglishname.Name = "txtenglishname";
            this.txtenglishname.Size = new System.Drawing.Size(250, 23);
            this.txtenglishname.TabIndex = 4;
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.Enabled = false;
            this.txtCode.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtCode.Location = new System.Drawing.Point(130, 5);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(250, 23);
            this.txtCode.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.Info;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Enabled = false;
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtName.Location = new System.Drawing.Point(130, 30);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(250, 23);
            this.txtName.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.drawingtypelbl);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.departmentlbl);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(124, 650);
            this.panel2.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "图纸类型名称2";
            // 
            // drawingtypelbl
            // 
            this.drawingtypelbl.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.drawingtypelbl.ForeColor = System.Drawing.Color.White;
            this.drawingtypelbl.Location = new System.Drawing.Point(5, 130);
            this.drawingtypelbl.Name = "drawingtypelbl";
            this.drawingtypelbl.Size = new System.Drawing.Size(103, 20);
            this.drawingtypelbl.TabIndex = 5;
            this.drawingtypelbl.Text = "图纸编号1";
            // 
            // departmentlbl
            // 
            this.departmentlbl.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.departmentlbl.ForeColor = System.Drawing.Color.White;
            this.departmentlbl.Location = new System.Drawing.Point(5, 105);
            this.departmentlbl.Name = "departmentlbl";
            this.departmentlbl.Size = new System.Drawing.Size(103, 20);
            this.departmentlbl.TabIndex = 4;
            this.departmentlbl.Text = "部门名称";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(5, 305);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 20);
            this.label11.TabIndex = 9;
            this.label11.Text = "图纸类型名称4";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(5, 255);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(103, 20);
            this.label12.TabIndex = 8;
            this.label12.Text = "图纸类型名称3";
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(5, 280);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(103, 20);
            this.label17.TabIndex = 3;
            this.label17.Text = "图纸编号4";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "英文名称 ";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(5, 180);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(103, 20);
            this.label13.TabIndex = 7;
            this.label13.Text = "图纸编号2";
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(5, 230);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(103, 20);
            this.label19.TabIndex = 1;
            this.label19.Text = "图纸编号3";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "名　称 ";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "编　号 ";
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(5, 155);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(103, 20);
            this.label15.TabIndex = 5;
            this.label15.Text = "图纸类型名称1";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(5, 80);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(103, 20);
            this.label16.TabIndex = 4;
            this.label16.Text = "部门编号";
            // 
            // FrmProductTree
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1036, 688);
            this.Controls.Add(this.pBody);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmProductTree";
            this.Text = "模具设定";
            this.Load += new System.EventHandler(this.FrmProductTree_Load);
            this.pBody.ResumeLayout(false);
            this.pMove.ResumeLayout(false);
            this.contextMenuType.ResumeLayout(false);
            this.contextMenuParts.ResumeLayout(false);
            this.contextMenuProductionProcess.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tv;
        private System.Windows.Forms.Panel pBody;
        private System.Windows.Forms.ContextMenuStrip contextMenuType;
        private System.Windows.Forms.ContextMenuStrip contextMenuParts;
        private System.Windows.Forms.ContextMenuStrip contextMenuProductionProcess;
        private System.Windows.Forms.ToolStripMenuItem menuAddParts;
        private System.Windows.Forms.ToolStripMenuItem menuDeleteParts;
        private System.Windows.Forms.ToolStripMenuItem menuAddProductionProcess;
        private System.Windows.Forms.ToolStripMenuItem menuMoveProductionProcess;
        private System.Windows.Forms.ToolStripMenuItem menuDeleteProductionProcess;
        private System.Windows.Forms.Panel pMove;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.TextBox txtTechnologyCode1;
        private System.Windows.Forms.TextBox txtTechnology3;
        private System.Windows.Forms.TextBox txtTechnologyCode3;
        private System.Windows.Forms.TextBox txtTechnology2;
        private System.Windows.Forms.TextBox txtTechnology1;
        private System.Windows.Forms.TextBox txtTechnologyCode2;
        private System.Windows.Forms.TextBox txtDrawingTypeCode6;
        private System.Windows.Forms.TextBox txtDrawingTypeCode5;
        private System.Windows.Forms.TextBox txtDrawingTypeCode4;
        private System.Windows.Forms.TextBox txtDrawingTypeCode3;
        private System.Windows.Forms.TextBox txtDrawingTypeCode2;
        private System.Windows.Forms.TextBox txtDrawingTypeCode1;
        private System.Windows.Forms.TextBox txtDepartmentCode;
        private System.Windows.Forms.TextBox txtDrawingType6;
        private System.Windows.Forms.TextBox txtDrawingType5;
        private System.Windows.Forms.TextBox txtDrawingType4;
        private System.Windows.Forms.TextBox txtDrawingType3;
        private System.Windows.Forms.TextBox txtDrawingType2;
        private System.Windows.Forms.TextBox txtDrawingType1;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.TextBox txtproductioncycle;
        private System.Windows.Forms.TextBox txtenglishname;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label drawingtypelbl;
        private System.Windows.Forms.Label departmentlbl;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
    }
}