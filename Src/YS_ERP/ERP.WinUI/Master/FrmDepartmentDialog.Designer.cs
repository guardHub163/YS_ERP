namespace CZZD.ERP.WinUI
{
    partial class FrmDepartmentDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDepartmentDialog));
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnParent = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtParentCode = new System.Windows.Forms.TextBox();
            this.txtCompanyCode = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.txtParentName = new System.Windows.Forms.TextBox();
            this.btnCompany = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnCancel.Location = new System.Drawing.Point(357, 187);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取 消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            // btnParent
            // 
            this.btnParent.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnParent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnParent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnParent.FlatAppearance.BorderSize = 0;
            this.btnParent.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnParent.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnParent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParent.Location = new System.Drawing.Point(261, 66);
            this.btnParent.Name = "btnParent";
            this.btnParent.Size = new System.Drawing.Size(25, 25);
            this.btnParent.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnParent, "查询");
            this.btnParent.UseVisualStyleBackColor = true;
            this.btnParent.MouseLeave += new System.EventHandler(this.btnSearch_MouseLeave);
            this.btnParent.Click += new System.EventHandler(this.btnParent_Click);
            this.btnParent.MouseEnter += new System.EventHandler(this.btnSearch_MouseEnter);
            this.btnParent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
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
            // txtCompanyCode
            // 
            this.txtCompanyCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtCompanyCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompanyCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCompanyCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtCompanyCode.Location = new System.Drawing.Point(5, 125);
            this.txtCompanyCode.MaxLength = 20;
            this.txtCompanyCode.Name = "txtCompanyCode";
            this.txtCompanyCode.Size = new System.Drawing.Size(250, 25);
            this.txtCompanyCode.TabIndex = 6;
            this.txtCompanyCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtCompanyCode.Leave += new System.EventHandler(this.txtCompanyCode_Leave);
            this.txtCompanyCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(120, 184);
            this.panel2.TabIndex = 108;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 201;
            this.label2.Text = "   公司名称：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 200;
            this.label1.Text = "   上级名称：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.SteelBlue;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 101;
            this.label4.Text = "   部门编号：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 197;
            this.label3.Text = "   名       称：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.SteelBlue;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(0, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 20);
            this.label11.TabIndex = 199;
            this.label11.Text = "   上级编号：";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.SteelBlue;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(0, 125);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(110, 20);
            this.label14.TabIndex = 198;
            this.label14.Text = "   公司编号：";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSave.Location = new System.Drawing.Point(261, 187);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "保 存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(446, 184);
            this.panel1.TabIndex = 110;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtCompanyName);
            this.panel3.Controls.Add(this.txtParentName);
            this.panel3.Controls.Add(this.btnCompany);
            this.panel3.Controls.Add(this.txtCode);
            this.panel3.Controls.Add(this.btnParent);
            this.panel3.Controls.Add(this.txtName);
            this.panel3.Controls.Add(this.txtParentCode);
            this.panel3.Controls.Add(this.txtCompanyCode);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(120, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(326, 184);
            this.panel3.TabIndex = 109;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompanyName.Enabled = false;
            this.txtCompanyName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCompanyName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtCompanyName.Location = new System.Drawing.Point(5, 155);
            this.txtCompanyName.MaxLength = 20;
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(250, 25);
            this.txtCompanyName.TabIndex = 8;
            // 
            // txtParentName
            // 
            this.txtParentName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtParentName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtParentName.Enabled = false;
            this.txtParentName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtParentName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtParentName.Location = new System.Drawing.Point(5, 95);
            this.txtParentName.MaxLength = 20;
            this.txtParentName.Name = "txtParentName";
            this.txtParentName.Size = new System.Drawing.Size(250, 25);
            this.txtParentName.TabIndex = 5;
            // 
            // btnCompany
            // 
            this.btnCompany.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnCompany.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCompany.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompany.FlatAppearance.BorderSize = 0;
            this.btnCompany.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCompany.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompany.Location = new System.Drawing.Point(261, 126);
            this.btnCompany.Name = "btnCompany";
            this.btnCompany.Size = new System.Drawing.Size(25, 25);
            this.btnCompany.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btnCompany, "查询");
            this.btnCompany.UseVisualStyleBackColor = true;
            this.btnCompany.MouseLeave += new System.EventHandler(this.btnSearch_MouseLeave);
            this.btnCompany.Click += new System.EventHandler(this.btnCompany_Click);
            this.btnCompany.MouseEnter += new System.EventHandler(this.btnSearch_MouseEnter);
            this.btnCompany.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // FrmDepartmentDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 218);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDepartmentDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "部门编辑";
            this.Load += new System.EventHandler(this.FrmDepartmentDialog_Load);
            this.Shown += new System.EventHandler(this.FrmDepartmentDialog_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCompanyDialog_FormClosed);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button btnParent;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtParentCode;
        private System.Windows.Forms.TextBox txtCompanyCode;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCompany;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtParentName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCompanyName;

    }
}