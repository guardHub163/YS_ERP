namespace CZZD.ERP.Main
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.pTitle = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMin = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtLoginPassword = new System.Windows.Forms.TextBox();
            this.txtLoginUserCode = new System.Windows.Forms.TextBox();
            this.cboCompany = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelDBConfig = new System.Windows.Forms.Panel();
            this.cmbAllDataBases = new System.Windows.Forms.TextBox();
            this.cmbSqlServers = new System.Windows.Forms.TextBox();
            this.btnTestConn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDBClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lkSetDB = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pTitle.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelDBConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pTitle
            // 
            this.pTitle.BackColor = System.Drawing.Color.Transparent;
            this.pTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pTitle.Controls.Add(this.btnClose);
            this.pTitle.Controls.Add(this.btnMin);
            this.pTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTitle.Location = new System.Drawing.Point(0, 0);
            this.pTitle.Name = "pTitle";
            this.pTitle.Size = new System.Drawing.Size(700, 30);
            this.pTitle.TabIndex = 10;
            this.pTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pTitle_MouseDown);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::CZZD.ERP.Main.Properties.Resources.close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(671, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(27, 16);
            this.btnClose.TabIndex = 4;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            this.btnClose.Click += new System.EventHandler(this.btnCLose_Click);
            this.btnClose.MouseEnter += new System.EventHandler(this.btnClose_MouseEnter);
            // 
            // btnMin
            // 
            this.btnMin.BackgroundImage = global::CZZD.ERP.Main.Properties.Resources.min;
            this.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMin.FlatAppearance.BorderSize = 0;
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.Location = new System.Drawing.Point(645, 0);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(27, 16);
            this.btnMin.TabIndex = 4;
            this.btnMin.UseVisualStyleBackColor = true;
            this.btnMin.MouseLeave += new System.EventHandler(this.btnMin_MouseLeave);
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            this.btnMin.MouseEnter += new System.EventHandler(this.btnMin_MouseEnter);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.txtLoginPassword);
            this.panel1.Controls.Add(this.txtLoginUserCode);
            this.panel1.Controls.Add(this.cboCompany);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(395, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(282, 143);
            this.panel1.TabIndex = 0;
            // 
            // txtLoginPassword
            // 
            this.txtLoginPassword.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtLoginPassword.Location = new System.Drawing.Point(107, 73);
            this.txtLoginPassword.Name = "txtLoginPassword";
            this.txtLoginPassword.PasswordChar = '*';
            this.txtLoginPassword.Size = new System.Drawing.Size(131, 25);
            this.txtLoginPassword.TabIndex = 3;
            this.txtLoginPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLoginPassword_KeyDown);
            // 
            // txtLoginUserCode
            // 
            this.txtLoginUserCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtLoginUserCode.Location = new System.Drawing.Point(107, 40);
            this.txtLoginUserCode.Name = "txtLoginUserCode";
            this.txtLoginUserCode.Size = new System.Drawing.Size(131, 25);
            this.txtLoginUserCode.TabIndex = 2;
            this.txtLoginUserCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLoginUserCode_KeyDown);
            // 
            // cboCompany
            // 
            this.cboCompany.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompany.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboCompany.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboCompany.FormattingEnabled = true;
            this.cboCompany.Location = new System.Drawing.Point(107, 7);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Size = new System.Drawing.Size(131, 25);
            this.cboCompany.TabIndex = 1;
            this.cboCompany.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = global::CZZD.ERP.Main.Properties.Resources.cancel;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(161, 109);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.MouseLeave += new System.EventHandler(this.btnCancel_MouseLeave);
            this.btnCancel.Click += new System.EventHandler(this.btnCLose_Click);
            this.btnCancel.MouseEnter += new System.EventHandler(this.btnCancel_MouseEnter);
            // 
            // btnLogin
            // 
            this.btnLogin.BackgroundImage = global::CZZD.ERP.Main.Properties.Resources.login;
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Location = new System.Drawing.Point(76, 109);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 25);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.MouseLeave += new System.EventHandler(this.btnLogin_MouseLeave);
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.btnLogin.MouseEnter += new System.EventHandler(this.btnLogin_MouseEnter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(83)))), ((int)(((byte)(166)))));
            this.label3.Location = new System.Drawing.Point(31, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "密   码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(83)))), ((int)(((byte)(166)))));
            this.label2.Location = new System.Drawing.Point(31, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "登录名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9.5F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(83)))), ((int)(((byte)(166)))));
            this.label1.Location = new System.Drawing.Point(31, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "公   司：";
            this.label1.Visible = false;
            // 
            // panelDBConfig
            // 
            this.panelDBConfig.BackColor = System.Drawing.Color.Transparent;
            this.panelDBConfig.Controls.Add(this.cmbAllDataBases);
            this.panelDBConfig.Controls.Add(this.cmbSqlServers);
            this.panelDBConfig.Controls.Add(this.btnTestConn);
            this.panelDBConfig.Controls.Add(this.label4);
            this.panelDBConfig.Controls.Add(this.txtPassword);
            this.panelDBConfig.Controls.Add(this.label5);
            this.panelDBConfig.Controls.Add(this.txtUserName);
            this.panelDBConfig.Controls.Add(this.label6);
            this.panelDBConfig.Controls.Add(this.label7);
            this.panelDBConfig.Controls.Add(this.btnDBClose);
            this.panelDBConfig.Controls.Add(this.btnSave);
            this.panelDBConfig.Location = new System.Drawing.Point(100, 270);
            this.panelDBConfig.Name = "panelDBConfig";
            this.panelDBConfig.Size = new System.Drawing.Size(290, 126);
            this.panelDBConfig.TabIndex = 9;
            this.panelDBConfig.Visible = false;
            // 
            // cmbAllDataBases
            // 
            this.cmbAllDataBases.BackColor = System.Drawing.Color.White;
            this.cmbAllDataBases.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbAllDataBases.Location = new System.Drawing.Point(125, 77);
            this.cmbAllDataBases.Name = "cmbAllDataBases";
            this.cmbAllDataBases.Size = new System.Drawing.Size(160, 21);
            this.cmbAllDataBases.TabIndex = 4;
            // 
            // cmbSqlServers
            // 
            this.cmbSqlServers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbSqlServers.Location = new System.Drawing.Point(125, 3);
            this.cmbSqlServers.Name = "cmbSqlServers";
            this.cmbSqlServers.Size = new System.Drawing.Size(160, 21);
            this.cmbSqlServers.TabIndex = 1;
            // 
            // btnTestConn
            // 
            this.btnTestConn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnTestConn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestConn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnTestConn.Location = new System.Drawing.Point(58, 101);
            this.btnTestConn.Name = "btnTestConn";
            this.btnTestConn.Size = new System.Drawing.Size(75, 23);
            this.btnTestConn.TabIndex = 5;
            this.btnTestConn.Text = "测试连接";
            this.btnTestConn.UseVisualStyleBackColor = true;
            this.btnTestConn.Click += new System.EventHandler(this.btnTestConn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(9, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "数据库名称";
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Location = new System.Drawing.Point(125, 52);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(160, 21);
            this.txtPassword.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(9, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 20;
            this.label5.Text = "数据库管理密码";
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Location = new System.Drawing.Point(125, 28);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(160, 21);
            this.txtUserName.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(9, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "数据库管理员用户";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(9, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "数据库服务器地址";
            // 
            // btnDBClose
            // 
            this.btnDBClose.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnDBClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDBClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDBClose.Location = new System.Drawing.Point(210, 101);
            this.btnDBClose.Name = "btnDBClose";
            this.btnDBClose.Size = new System.Drawing.Size(75, 23);
            this.btnDBClose.TabIndex = 7;
            this.btnDBClose.Text = "关闭";
            this.btnDBClose.UseVisualStyleBackColor = true;
            this.btnDBClose.Click += new System.EventHandler(this.btnDBClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.Location = new System.Drawing.Point(134, 101);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "确定";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lkSetDB
            // 
            this.lkSetDB.AutoSize = true;
            this.lkSetDB.BackColor = System.Drawing.Color.Transparent;
            this.lkSetDB.Font = new System.Drawing.Font("宋体", 10F);
            this.lkSetDB.LinkColor = System.Drawing.Color.DimGray;
            this.lkSetDB.Location = new System.Drawing.Point(80, 398);
            this.lkSetDB.Name = "lkSetDB";
            this.lkSetDB.Size = new System.Drawing.Size(105, 14);
            this.lkSetDB.TabIndex = 1;
            this.lkSetDB.TabStop = true;
            this.lkSetDB.Text = "数据库连接设定";
            this.lkSetDB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lkSetDB.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkSetDB_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::CZZD.ERP.Main.Properties.Resources.conn;
            this.pictureBox1.Location = new System.Drawing.Point(47, 387);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 31);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::CZZD.ERP.Main.Properties.Resources.login_back;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(700, 440);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pTitle);
            this.Controls.Add(this.lkSetDB);
            this.Controls.Add(this.panelDBConfig);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户登录";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmLogin_FormClosed);
            this.pTitle.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelDBConfig.ResumeLayout(false);
            this.panelDBConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel lkSetDB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtLoginPassword;
        private System.Windows.Forms.TextBox txtLoginUserCode;
        private System.Windows.Forms.ComboBox cboCompany;
        private System.Windows.Forms.Panel panelDBConfig;
        private System.Windows.Forms.TextBox cmbAllDataBases;
        private System.Windows.Forms.TextBox cmbSqlServers;
        private System.Windows.Forms.Button btnTestConn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDBClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMin;
    }
}