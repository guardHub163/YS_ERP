namespace CZZD.ERP.Main
{
    partial class FrmPwd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPwd));
            this.txtPwdNew2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPwdNew1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPwdOld = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPwdNew2
            // 
            this.txtPwdNew2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtPwdNew2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPwdNew2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtPwdNew2.Location = new System.Drawing.Point(104, 103);
            this.txtPwdNew2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPwdNew2.Name = "txtPwdNew2";
            this.txtPwdNew2.PasswordChar = '*';
            this.txtPwdNew2.Size = new System.Drawing.Size(232, 25);
            this.txtPwdNew2.TabIndex = 2;
            this.txtPwdNew2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.Location = new System.Drawing.Point(12, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "确认新密码";
            // 
            // txtPwdNew1
            // 
            this.txtPwdNew1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtPwdNew1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPwdNew1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtPwdNew1.Location = new System.Drawing.Point(104, 61);
            this.txtPwdNew1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPwdNew1.Name = "txtPwdNew1";
            this.txtPwdNew1.PasswordChar = '*';
            this.txtPwdNew1.Size = new System.Drawing.Size(232, 25);
            this.txtPwdNew1.TabIndex = 1;
            this.txtPwdNew1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "新密码";
            // 
            // txtPwdOld
            // 
            this.txtPwdOld.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtPwdOld.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPwdOld.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtPwdOld.Location = new System.Drawing.Point(104, 19);
            this.txtPwdOld.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPwdOld.Name = "txtPwdOld";
            this.txtPwdOld.PasswordChar = '*';
            this.txtPwdOld.Size = new System.Drawing.Size(232, 25);
            this.txtPwdOld.TabIndex = 0;
            this.txtPwdOld.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "旧密码";
            // 
            // btnCancle
            // 
            this.btnCancle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancle.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnCancle.Location = new System.Drawing.Point(246, 142);
            this.btnCancle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(90, 30);
            this.btnCancle.TabIndex = 4;
            this.btnCancle.Text = "取消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnOK
            // 
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnOK.Location = new System.Drawing.Point(150, 142);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 30);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确认";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FrmPwd
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(355, 181);
            this.Controls.Add(this.txtPwdNew2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPwdNew1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPwdOld);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPwd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "密码修改";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPwdNew2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPwdNew1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPwdOld;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnOK;
    }
}