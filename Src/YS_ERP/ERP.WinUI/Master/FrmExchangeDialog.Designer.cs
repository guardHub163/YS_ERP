namespace CZZD.ERP.WinUI
{
    partial class FrmExchangeDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExchangeDialog));
            this.pBody = new System.Windows.Forms.Panel();
            this.pRight = new System.Windows.Forms.Panel();
            this.txtExchangeRate = new System.Windows.Forms.TextBox();
            this.btnCurrency = new System.Windows.Forms.Button();
            this.txtCurrencyName = new System.Windows.Forms.TextBox();
            this.txtCurrencyCode = new System.Windows.Forms.TextBox();
            this.ExchangeDate = new System.Windows.Forms.DateTimePicker();
            this.pLeft = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pBody.SuspendLayout();
            this.pRight.SuspendLayout();
            this.pLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // pBody
            // 
            this.pBody.BackColor = System.Drawing.Color.White;
            this.pBody.Controls.Add(this.pRight);
            this.pBody.Controls.Add(this.pLeft);
            this.pBody.Location = new System.Drawing.Point(0, 0);
            this.pBody.Name = "pBody";
            this.pBody.Size = new System.Drawing.Size(440, 180);
            this.pBody.TabIndex = 0;
            // 
            // pRight
            // 
            this.pRight.Controls.Add(this.txtExchangeRate);
            this.pRight.Controls.Add(this.btnCurrency);
            this.pRight.Controls.Add(this.txtCurrencyName);
            this.pRight.Controls.Add(this.txtCurrencyCode);
            this.pRight.Controls.Add(this.ExchangeDate);
            this.pRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRight.Location = new System.Drawing.Point(120, 0);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(320, 180);
            this.pRight.TabIndex = 0;
            // 
            // txtExchangeRate
            // 
            this.txtExchangeRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtExchangeRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExchangeRate.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtExchangeRate.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtExchangeRate.Location = new System.Drawing.Point(5, 92);
            this.txtExchangeRate.MaxLength = 20;
            this.txtExchangeRate.Name = "txtExchangeRate";
            this.txtExchangeRate.Size = new System.Drawing.Size(250, 23);
            this.txtExchangeRate.TabIndex = 5;
            this.txtExchangeRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtExchangeRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // btnCurrency
            // 
            this.btnCurrency.BackgroundImage = global::CZZD.ERP.WinUI.Properties.Resources.find;
            this.btnCurrency.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCurrency.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCurrency.FlatAppearance.BorderSize = 0;
            this.btnCurrency.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCurrency.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCurrency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCurrency.Location = new System.Drawing.Point(261, 35);
            this.btnCurrency.Name = "btnCurrency";
            this.btnCurrency.Size = new System.Drawing.Size(25, 25);
            this.btnCurrency.TabIndex = 3;
            this.btnCurrency.UseVisualStyleBackColor = true;
            this.btnCurrency.MouseLeave += new System.EventHandler(this.btnSearch_MouseLeave);
            this.btnCurrency.Click += new System.EventHandler(this.btnCurrency_Click);
            this.btnCurrency.MouseEnter += new System.EventHandler(this.btnSearch_MouseEnter);
            this.btnCurrency.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // txtCurrencyName
            // 
            this.txtCurrencyName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCurrencyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurrencyName.Enabled = false;
            this.txtCurrencyName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCurrencyName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtCurrencyName.Location = new System.Drawing.Point(5, 65);
            this.txtCurrencyName.MaxLength = 20;
            this.txtCurrencyName.Name = "txtCurrencyName";
            this.txtCurrencyName.Size = new System.Drawing.Size(250, 23);
            this.txtCurrencyName.TabIndex = 4;
            this.txtCurrencyName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtCurrencyName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtCurrencyCode
            // 
            this.txtCurrencyCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtCurrencyCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurrencyCode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCurrencyCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtCurrencyCode.Location = new System.Drawing.Point(5, 35);
            this.txtCurrencyCode.MaxLength = 20;
            this.txtCurrencyCode.Name = "txtCurrencyCode";
            this.txtCurrencyCode.Size = new System.Drawing.Size(250, 23);
            this.txtCurrencyCode.TabIndex = 2;
            this.txtCurrencyCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtCurrencyCode.Leave += new System.EventHandler(this.txtCurrencyCode_Leave);
            this.txtCurrencyCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // ExchangeDate
            // 
            this.ExchangeDate.CustomFormat = "yyyy-MM";
            this.ExchangeDate.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ExchangeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ExchangeDate.Location = new System.Drawing.Point(5, 5);
            this.ExchangeDate.Name = "ExchangeDate";
            this.ExchangeDate.Size = new System.Drawing.Size(250, 23);
            this.ExchangeDate.TabIndex = 1;
            this.ExchangeDate.Leave += new System.EventHandler(this.ReportedDate_Leave);
            this.ExchangeDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.ExchangeDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // pLeft
            // 
            this.pLeft.BackColor = System.Drawing.Color.SteelBlue;
            this.pLeft.Controls.Add(this.label11);
            this.pLeft.Controls.Add(this.label6);
            this.pLeft.Controls.Add(this.label12);
            this.pLeft.Controls.Add(this.label4);
            this.pLeft.Controls.Add(this.label2);
            this.pLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeft.Location = new System.Drawing.Point(0, 0);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(120, 180);
            this.pLeft.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.SteelBlue;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(5, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 20);
            this.label11.TabIndex = 88;
            this.label11.Text = "  货币编号：";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.SteelBlue;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(5, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 20);
            this.label6.TabIndex = 85;
            this.label6.Text = "  汇　　率：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.SteelBlue;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(5, 65);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 20);
            this.label12.TabIndex = 86;
            this.label12.Text = "  货币名称：";
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
            this.label4.Text = "  汇率时间：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 389);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 96;
            this.label2.Text = "  备       注：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnCancel.Location = new System.Drawing.Point(350, 184);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取　消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSave.Location = new System.Drawing.Point(255, 184);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保　存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmExchangeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(445, 216);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pBody);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmExchangeDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmExchangeDialog";
            this.Load += new System.EventHandler(this.FrmExchangeDialog_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmExchangeDialog_FormClosed);
            this.pBody.ResumeLayout(false);
            this.pRight.ResumeLayout(false);
            this.pRight.PerformLayout();
            this.pLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pBody;
        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.DateTimePicker ExchangeDate;
        private System.Windows.Forms.Button btnCurrency;
        private System.Windows.Forms.TextBox txtCurrencyName;
        private System.Windows.Forms.TextBox txtCurrencyCode;
        private System.Windows.Forms.TextBox txtExchangeRate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}