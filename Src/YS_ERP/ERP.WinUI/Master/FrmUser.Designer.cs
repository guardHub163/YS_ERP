namespace CZZD.ERP.WinUI
{
    partial class FrmUser
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUser));
            this.MasterToolBar = new CZZD.ERP.ComControls.MasterToolBarControl();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.pgControl = new CZZD.ERP.ComControls.PageControl();
            this.pInfo = new System.Windows.Forms.Panel();
            this.pSearch = new System.Windows.Forms.Panel();
            this.pLeft = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cboCompany = new System.Windows.Forms.ComboBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DISP_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PHONE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMAIL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEPARTMENT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMPANY_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ROLES_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INT_COMMUNITY_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OUT_COMMUNITY_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CREATE_USER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CREATE_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LAST_UPDATE_USER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LAST_UPDATE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.pInfo.SuspendLayout();
            this.pSearch.SuspendLayout();
            this.pLeft.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // MasterToolBar
            // 
            this.MasterToolBar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MasterToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.MasterToolBar.Location = new System.Drawing.Point(0, 0);
            this.MasterToolBar.Name = "MasterToolBar";
            this.MasterToolBar.Size = new System.Drawing.Size(1015, 30);
            this.MasterToolBar.TabIndex = 5;
            this.MasterToolBar.DoCancel_Click += new CZZD.ERP.ComControls.MasterToolBarControl.BtnClickHandle(this.MasterToolBar_DoCancel_Click);
            this.MasterToolBar.DoModify_Click += new CZZD.ERP.ComControls.MasterToolBarControl.BtnClickHandle(this.MasterToolBar_DoModify_Click);
            this.MasterToolBar.DoExport_Click += new CZZD.ERP.ComControls.MasterToolBarControl.BtnClickHandle(this.MasterToolBar_DoExport_Click);
            this.MasterToolBar.DoNew_Click += new CZZD.ERP.ComControls.MasterToolBarControl.BtnClickHandle(this.MasterToolBar_DoNew_Click);
            this.MasterToolBar.DoDelete_Click += new CZZD.ERP.ComControls.MasterToolBarControl.BtnClickHandle(this.MasterToolBar_DoDelete_Click);
            this.MasterToolBar.DoSearch_Click += new CZZD.ERP.ComControls.MasterToolBarControl.BtnClickHandle(this.MasterToolBar_DoSearch_Click);
            this.MasterToolBar.DoCopy_Click += new CZZD.ERP.ComControls.MasterToolBarControl.BtnClickHandle(this.MasterToolBar_DoCopy_Click);
            // 
            // dgvData
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvData.ColumnHeadersHeight = 30;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DISP_CODE,
            this.NAME,
            this.PHONE,
            this.EMAIL,
            this.DEPARTMENT_NAME,
            this.COMPANY_NAME,
            this.ROLES_NAME,
            this.INT_COMMUNITY_DATE,
            this.OUT_COMMUNITY_DATE,
            this.Level,
            this.CREATE_USER,
            this.CREATE_DATE,
            this.LAST_UPDATE_USER,
            this.LAST_UPDATE_TIME,
            this.CODE});
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(0, 127);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 45;
            this.dgvData.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.dgvData.RowTemplate.Height = 21;
            this.dgvData.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1009, 450);
            this.dgvData.TabIndex = 3;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            this.dgvData.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvData_RowStateChanged);
            // 
            // pgControl
            // 
            this.pgControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pgControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pgControl.Location = new System.Drawing.Point(0, 577);
            this.pgControl.Name = "pgControl";
            this.pgControl.Size = new System.Drawing.Size(1009, 30);
            this.pgControl.TabIndex = 4;
            this.pgControl.TotalPage = 1;
            this.pgControl.PageChanged += new CZZD.ERP.ComControls.PageControl.BtnClickHandle(this.pgControl_PageChanged);
            // 
            // pInfo
            // 
            this.pInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pInfo.Controls.Add(this.pSearch);
            this.pInfo.Controls.Add(this.MasterToolBar);
            this.pInfo.Location = new System.Drawing.Point(0, 0);
            this.pInfo.Name = "pInfo";
            this.pInfo.Size = new System.Drawing.Size(1017, 648);
            this.pInfo.TabIndex = 5;
            // 
            // pSearch
            // 
            this.pSearch.Controls.Add(this.pLeft);
            this.pSearch.Controls.Add(this.dgvData);
            this.pSearch.Controls.Add(this.pgControl);
            this.pSearch.Location = new System.Drawing.Point(3, 33);
            this.pSearch.Name = "pSearch";
            this.pSearch.Size = new System.Drawing.Size(1009, 607);
            this.pSearch.TabIndex = 0;
            // 
            // pLeft
            // 
            this.pLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLeft.Controls.Add(this.panel4);
            this.pLeft.Controls.Add(this.panel3);
            this.pLeft.Location = new System.Drawing.Point(0, 0);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(440, 125);
            this.pLeft.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.cboCompany);
            this.panel4.Controls.Add(this.txtCode);
            this.panel4.Controls.Add(this.txtName);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(118, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(320, 123);
            this.panel4.TabIndex = 1;
            // 
            // cboCompany
            // 
            this.cboCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompany.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.cboCompany.FormattingEnabled = true;
            this.cboCompany.Location = new System.Drawing.Point(5, 5);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Size = new System.Drawing.Size(250, 27);
            this.cboCompany.TabIndex = 3;
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtCode.Location = new System.Drawing.Point(5, 35);
            this.txtCode.MaxLength = 20;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(250, 25);
            this.txtCode.TabIndex = 1;
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.Info;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtName.Location = new System.Drawing.Point(5, 65);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(250, 25);
            this.txtName.TabIndex = 2;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(118, 123);
            this.panel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = " 用户名：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = " 公　司：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = " 姓　名：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DISP_CODE
            // 
            this.DISP_CODE.DataPropertyName = "DISP_CODE";
            this.DISP_CODE.FillWeight = 102.5575F;
            this.DISP_CODE.HeaderText = "用户名";
            this.DISP_CODE.Name = "DISP_CODE";
            this.DISP_CODE.ReadOnly = true;
            this.DISP_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NAME
            // 
            this.NAME.DataPropertyName = "NAME";
            this.NAME.FillWeight = 96.85981F;
            this.NAME.HeaderText = "姓名";
            this.NAME.Name = "NAME";
            this.NAME.ReadOnly = true;
            this.NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PHONE
            // 
            this.PHONE.DataPropertyName = "PHONE";
            this.PHONE.FillWeight = 96.32172F;
            this.PHONE.HeaderText = "电话";
            this.PHONE.Name = "PHONE";
            this.PHONE.ReadOnly = true;
            this.PHONE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // EMAIL
            // 
            this.EMAIL.DataPropertyName = "EMAIL";
            this.EMAIL.FillWeight = 95.73277F;
            this.EMAIL.HeaderText = "邮箱";
            this.EMAIL.Name = "EMAIL";
            this.EMAIL.ReadOnly = true;
            this.EMAIL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DEPARTMENT_NAME
            // 
            this.DEPARTMENT_NAME.DataPropertyName = "DEPARTMENT_NAME";
            this.DEPARTMENT_NAME.FillWeight = 95.08823F;
            this.DEPARTMENT_NAME.HeaderText = "部门";
            this.DEPARTMENT_NAME.Name = "DEPARTMENT_NAME";
            this.DEPARTMENT_NAME.ReadOnly = true;
            this.DEPARTMENT_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // COMPANY_NAME
            // 
            this.COMPANY_NAME.DataPropertyName = "COMPANY_NAME";
            this.COMPANY_NAME.FillWeight = 95.36153F;
            this.COMPANY_NAME.HeaderText = "公司";
            this.COMPANY_NAME.Name = "COMPANY_NAME";
            this.COMPANY_NAME.ReadOnly = true;
            this.COMPANY_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ROLES_NAME
            // 
            this.ROLES_NAME.DataPropertyName = "ROLES_NAME";
            this.ROLES_NAME.FillWeight = 94.68192F;
            this.ROLES_NAME.HeaderText = "角色";
            this.ROLES_NAME.Name = "ROLES_NAME";
            this.ROLES_NAME.ReadOnly = true;
            this.ROLES_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // INT_COMMUNITY_DATE
            // 
            this.INT_COMMUNITY_DATE.DataPropertyName = "INT_COMMUNITY_DATE";
            this.INT_COMMUNITY_DATE.HeaderText = "入职日期";
            this.INT_COMMUNITY_DATE.Name = "INT_COMMUNITY_DATE";
            // 
            // OUT_COMMUNITY_DATE
            // 
            this.OUT_COMMUNITY_DATE.DataPropertyName = "OUT_COMMUNITY_DATE";
            this.OUT_COMMUNITY_DATE.HeaderText = "离职日期";
            this.OUT_COMMUNITY_DATE.Name = "OUT_COMMUNITY_DATE";
            // 
            // Level
            // 
            this.Level.DataPropertyName = "LEVEL";
            this.Level.HeaderText = "等级";
            this.Level.Name = "Level";
            this.Level.ReadOnly = true;
            this.Level.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CREATE_USER
            // 
            this.CREATE_USER.DataPropertyName = "CREATE_USER";
            this.CREATE_USER.FillWeight = 93.93812F;
            this.CREATE_USER.HeaderText = "创建人";
            this.CREATE_USER.Name = "CREATE_USER";
            this.CREATE_USER.ReadOnly = true;
            this.CREATE_USER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CREATE_DATE
            // 
            this.CREATE_DATE.DataPropertyName = "CREATE_DATE";
            this.CREATE_DATE.FillWeight = 117.6501F;
            this.CREATE_DATE.HeaderText = "创建时间";
            this.CREATE_DATE.Name = "CREATE_DATE";
            this.CREATE_DATE.ReadOnly = true;
            this.CREATE_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LAST_UPDATE_USER
            // 
            this.LAST_UPDATE_USER.DataPropertyName = "LAST_UPDATE_USER";
            this.LAST_UPDATE_USER.FillWeight = 94.54949F;
            this.LAST_UPDATE_USER.HeaderText = "最后更新人";
            this.LAST_UPDATE_USER.Name = "LAST_UPDATE_USER";
            this.LAST_UPDATE_USER.ReadOnly = true;
            this.LAST_UPDATE_USER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LAST_UPDATE_TIME
            // 
            this.LAST_UPDATE_TIME.DataPropertyName = "LAST_UPDATE_TIME";
            this.LAST_UPDATE_TIME.FillWeight = 117.2589F;
            this.LAST_UPDATE_TIME.HeaderText = "最后更新时间";
            this.LAST_UPDATE_TIME.Name = "LAST_UPDATE_TIME";
            this.LAST_UPDATE_TIME.ReadOnly = true;
            this.LAST_UPDATE_TIME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CODE
            // 
            this.CODE.DataPropertyName = "CODE";
            this.CODE.HeaderText = "CODE";
            this.CODE.Name = "CODE";
            this.CODE.ReadOnly = true;
            this.CODE.Visible = false;
            // 
            // FrmUser
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1028, 663);
            this.Controls.Add(this.pInfo);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmUser";
            this.RightToLeftLayout = true;
            this.Text = "用户设定";
            this.Load += new System.EventHandler(this.FrmUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.pInfo.ResumeLayout(false);
            this.pSearch.ResumeLayout(false);
            this.pLeft.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CZZD.ERP.ComControls.MasterToolBarControl MasterToolBar;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Panel pInfo;
        private CZZD.ERP.ComControls.PageControl pgControl;
        private System.Windows.Forms.Panel pSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn DISP_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PHONE;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMAIL;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPARTMENT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMPANY_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROLES_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn INT_COMMUNITY_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn OUT_COMMUNITY_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn Level;
        private System.Windows.Forms.DataGridViewTextBoxColumn CREATE_USER;
        private System.Windows.Forms.DataGridViewTextBoxColumn CREATE_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn LAST_UPDATE_USER;
        private System.Windows.Forms.DataGridViewTextBoxColumn LAST_UPDATE_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODE;
    }


}