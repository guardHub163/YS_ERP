namespace CZZD.ERP.WinUI
{
    partial class FrmRolesFunction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRolesFunction));
            this.pInfo = new System.Windows.Forms.Panel();
            this.pTV = new System.Windows.Forms.Panel();
            this.lblRoles = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tvFunction = new System.Windows.Forms.TreeView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnRoles = new System.Windows.Forms.Button();
            this.txtRolesCode = new System.Windows.Forms.TextBox();
            this.txtRolesName = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pInfo.SuspendLayout();
            this.pTV.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // pInfo
            // 
            this.pInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pInfo.Controls.Add(this.pTV);
            this.pInfo.Controls.Add(this.panel3);
            this.pInfo.Controls.Add(this.btnCancel);
            this.pInfo.Controls.Add(this.btnSearch);
            this.pInfo.Controls.Add(this.btnSave);
            this.pInfo.Location = new System.Drawing.Point(0, 0);
            this.pInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pInfo.Name = "pInfo";
            this.pInfo.Size = new System.Drawing.Size(520, 650);
            this.pInfo.TabIndex = 0;
            // 
            // pTV
            // 
            this.pTV.BackColor = System.Drawing.Color.White;
            this.pTV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pTV.Controls.Add(this.lblRoles);
            this.pTV.Controls.Add(this.label3);
            this.pTV.Controls.Add(this.tvFunction);
            this.pTV.Location = new System.Drawing.Point(4, 106);
            this.pTV.Name = "pTV";
            this.pTV.Size = new System.Drawing.Size(509, 504);
            this.pTV.TabIndex = 2;
            // 
            // lblRoles
            // 
            this.lblRoles.AutoSize = true;
            this.lblRoles.Location = new System.Drawing.Point(74, 3);
            this.lblRoles.Name = "lblRoles";
            this.lblRoles.Size = new System.Drawing.Size(0, 20);
            this.lblRoles.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "功能列表";
            // 
            // tvFunction
            // 
            this.tvFunction.CheckBoxes = true;
            this.tvFunction.Location = new System.Drawing.Point(2, 26);
            this.tvFunction.Name = "tvFunction";
            this.tvFunction.Size = new System.Drawing.Size(503, 473);
            this.tvFunction.TabIndex = 4;
            this.tvFunction.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvFunction_AfterCheck);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(510, 67);
            this.panel3.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnRoles);
            this.panel4.Controls.Add(this.txtRolesCode);
            this.panel4.Controls.Add(this.txtRolesName);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(122, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(386, 65);
            this.panel4.TabIndex = 1;
            // 
            // btnRoles
            // 
            this.btnRoles.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnRoles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRoles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRoles.FlatAppearance.BorderSize = 0;
            this.btnRoles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRoles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoles.Location = new System.Drawing.Point(260, 4);
            this.btnRoles.Name = "btnRoles";
            this.btnRoles.Size = new System.Drawing.Size(25, 25);
            this.btnRoles.TabIndex = 2;
            this.btnRoles.UseVisualStyleBackColor = true;
            this.btnRoles.Click += new System.EventHandler(this.btnRoles_Click);
            // 
            // txtRolesCode
            // 
            this.txtRolesCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtRolesCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRolesCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtRolesCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtRolesCode.Location = new System.Drawing.Point(5, 5);
            this.txtRolesCode.MaxLength = 20;
            this.txtRolesCode.Name = "txtRolesCode";
            this.txtRolesCode.Size = new System.Drawing.Size(250, 25);
            this.txtRolesCode.TabIndex = 1;
            this.txtRolesCode.Leave += new System.EventHandler(this.txtRolesCode_Leave);
            this.txtRolesCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRolesCode_KeyPress);
            // 
            // txtRolesName
            // 
            this.txtRolesName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtRolesName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRolesName.Enabled = false;
            this.txtRolesName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtRolesName.Location = new System.Drawing.Point(5, 35);
            this.txtRolesName.MaxLength = 100;
            this.txtRolesName.Name = "txtRolesName";
            this.txtRolesName.ReadOnly = true;
            this.txtRolesName.Size = new System.Drawing.Size(250, 25);
            this.txtRolesName.TabIndex = 8;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SteelBlue;
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(122, 65);
            this.panel5.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = " 角色编号：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = " 名       称：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Location = new System.Drawing.Point(423, 613);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "关　闭";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Location = new System.Drawing.Point(423, 72);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 30);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "详　细";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(327, 613);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保　存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmRolesFunction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 663);
            this.Controls.Add(this.pInfo);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmRolesFunction";
            this.Text = "权限设定";
            this.Load += new System.EventHandler(this.FrmRolesFunctioncs_Load);
            this.pInfo.ResumeLayout(false);
            this.pTV.ResumeLayout(false);
            this.pTV.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pInfo;
        private System.Windows.Forms.TreeView tvFunction;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtRolesCode;
        private System.Windows.Forms.TextBox txtRolesName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRoles;
        private System.Windows.Forms.Panel pTV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRoles;
    }
}