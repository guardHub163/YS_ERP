namespace CZZD.ERP.WinUI
{
    partial class FrmProductionProcess
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProductionProcess));
            this.pInfo = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pgControl = new CZZD.ERP.ComControls.PageControl();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtOrderCode = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MasterToolBar = new CZZD.ERP.ComControls.MasterToolBarControl();
            this.CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ENGLISH_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEPARTMENT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DRAWING_TYPE_NAME1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DRAWING_TYPE_NAME2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DRAWING_TYPE_NAME3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DRAWING_TYPE_NAME4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DRAWING_TYPE_NAME5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DRAWING_TYPE_NAME6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TECHNOLOGY_NAME1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TECHNOLOGY_NAME2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TECHNOLOGY_NAME3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCTION_CYCLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROCESS_STATUS_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROCESS_STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CREATE_USER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CREATE_DATE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LAST_UPDATE_USER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LAST_UPDATE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pInfo
            // 
            this.pInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pInfo.Controls.Add(this.panel1);
            this.pInfo.Controls.Add(this.MasterToolBar);
            this.pInfo.Location = new System.Drawing.Point(0, 0);
            this.pInfo.Name = "pInfo";
            this.pInfo.Size = new System.Drawing.Size(1020, 650);
            this.pInfo.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pgControl);
            this.panel1.Controls.Add(this.dgvData);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(3, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1011, 609);
            this.panel1.TabIndex = 11;
            // 
            // pgControl
            // 
            this.pgControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pgControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pgControl.Location = new System.Drawing.Point(0, 579);
            this.pgControl.Name = "pgControl";
            this.pgControl.Size = new System.Drawing.Size(1011, 30);
            this.pgControl.TabIndex = 28;
            this.pgControl.TotalPage = 1;
            this.pgControl.PageChanged += new CZZD.ERP.ComControls.PageControl.BtnClickHandle(this.pgControl_PageChanged);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvData.ColumnHeadersHeight = 30;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CODE,
            this.NAME,
            this.ENGLISH_NAME,
            this.DEPARTMENT_NAME,
            this.DRAWING_TYPE_NAME1,
            this.DRAWING_TYPE_NAME2,
            this.DRAWING_TYPE_NAME3,
            this.DRAWING_TYPE_NAME4,
            this.DRAWING_TYPE_NAME5,
            this.DRAWING_TYPE_NAME6,
            this.TECHNOLOGY_NAME1,
            this.TECHNOLOGY_NAME2,
            this.TECHNOLOGY_NAME3,
            this.PRODUCTION_CYCLE,
            this.PROCESS_STATUS_NAME,
            this.PROCESS_STATUS,
            this.CREATE_USER,
            this.CREATE_DATE_TIME,
            this.LAST_UPDATE_USER,
            this.LAST_UPDATE_TIME});
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(0, 128);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 45;
            this.dgvData.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1011, 445);
            this.dgvData.TabIndex = 27;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            this.dgvData.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvData_RowStateChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(510, 125);
            this.panel2.TabIndex = 26;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtName);
            this.panel4.Controls.Add(this.txtOrderCode);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(118, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(390, 123);
            this.panel4.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.Info;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtName.Location = new System.Drawing.Point(5, 34);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(250, 25);
            this.txtName.TabIndex = 23;
            // 
            // txtOrderCode
            // 
            this.txtOrderCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtOrderCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtOrderCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtOrderCode.Location = new System.Drawing.Point(5, 5);
            this.txtOrderCode.MaxLength = 20;
            this.txtOrderCode.Name = "txtOrderCode";
            this.txtOrderCode.Size = new System.Drawing.Size(250, 25);
            this.txtOrderCode.TabIndex = 22;
            this.txtOrderCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.Controls.Add(this.label1);
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
            this.label1.TabIndex = 22;
            this.label1.Text = " 名           称：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = " 编          号 ：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MasterToolBar
            // 
            this.MasterToolBar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MasterToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.MasterToolBar.Location = new System.Drawing.Point(0, 0);
            this.MasterToolBar.Name = "MasterToolBar";
            this.MasterToolBar.Size = new System.Drawing.Size(1018, 30);
            this.MasterToolBar.TabIndex = 10;
            this.MasterToolBar.DoCancel_Click += new CZZD.ERP.ComControls.MasterToolBarControl.BtnClickHandle(this.MasterToolBar_DoCancel_Click);
            this.MasterToolBar.DoModify_Click += new CZZD.ERP.ComControls.MasterToolBarControl.BtnClickHandle(this.MasterToolBar_DoModify_Click);
            this.MasterToolBar.DoExport_Click += new CZZD.ERP.ComControls.MasterToolBarControl.BtnClickHandle(this.MasterToolBar_DoExport_Click);
            this.MasterToolBar.DoNew_Click += new CZZD.ERP.ComControls.MasterToolBarControl.BtnClickHandle(this.MasterToolBar_DoNew_Click);
            this.MasterToolBar.DoDelete_Click += new CZZD.ERP.ComControls.MasterToolBarControl.BtnClickHandle(this.MasterToolBar_DoDelete_Click);
            this.MasterToolBar.DoSearch_Click += new CZZD.ERP.ComControls.MasterToolBarControl.BtnClickHandle(this.MasterToolBar_DoSearch_Click);
            this.MasterToolBar.DoCopy_Click += new CZZD.ERP.ComControls.MasterToolBarControl.BtnClickHandle(this.MasterToolBar_DoCopy_Click);
            // 
            // CODE
            // 
            this.CODE.DataPropertyName = "CODE";
            this.CODE.HeaderText = "编号";
            this.CODE.Name = "CODE";
            this.CODE.ReadOnly = true;
            this.CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CODE.Width = 101;
            // 
            // NAME
            // 
            this.NAME.DataPropertyName = "NAME";
            this.NAME.HeaderText = "名称";
            this.NAME.Name = "NAME";
            this.NAME.ReadOnly = true;
            this.NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NAME.Width = 150;
            // 
            // ENGLISH_NAME
            // 
            this.ENGLISH_NAME.DataPropertyName = "ENGLISH_NAME";
            this.ENGLISH_NAME.HeaderText = "英文名字";
            this.ENGLISH_NAME.Name = "ENGLISH_NAME";
            this.ENGLISH_NAME.ReadOnly = true;
            this.ENGLISH_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ENGLISH_NAME.Width = 150;
            // 
            // DEPARTMENT_NAME
            // 
            this.DEPARTMENT_NAME.DataPropertyName = "DEPARTMENT_NAME";
            this.DEPARTMENT_NAME.HeaderText = "部门";
            this.DEPARTMENT_NAME.Name = "DEPARTMENT_NAME";
            this.DEPARTMENT_NAME.ReadOnly = true;
            this.DEPARTMENT_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DRAWING_TYPE_NAME1
            // 
            this.DRAWING_TYPE_NAME1.DataPropertyName = "DRAWING_TYPE_NAME1";
            this.DRAWING_TYPE_NAME1.HeaderText = "图纸1";
            this.DRAWING_TYPE_NAME1.Name = "DRAWING_TYPE_NAME1";
            this.DRAWING_TYPE_NAME1.ReadOnly = true;
            this.DRAWING_TYPE_NAME1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DRAWING_TYPE_NAME2
            // 
            this.DRAWING_TYPE_NAME2.DataPropertyName = "DRAWING_TYPE_NAME2";
            this.DRAWING_TYPE_NAME2.HeaderText = "图纸2";
            this.DRAWING_TYPE_NAME2.Name = "DRAWING_TYPE_NAME2";
            // 
            // DRAWING_TYPE_NAME3
            // 
            this.DRAWING_TYPE_NAME3.DataPropertyName = "DRAWING_TYPE_NAME3";
            this.DRAWING_TYPE_NAME3.HeaderText = "图纸3";
            this.DRAWING_TYPE_NAME3.Name = "DRAWING_TYPE_NAME3";
            // 
            // DRAWING_TYPE_NAME4
            // 
            this.DRAWING_TYPE_NAME4.DataPropertyName = "DRAWING_TYPE_NAME4";
            this.DRAWING_TYPE_NAME4.HeaderText = "图纸4";
            this.DRAWING_TYPE_NAME4.Name = "DRAWING_TYPE_NAME4";
            // 
            // DRAWING_TYPE_NAME5
            // 
            this.DRAWING_TYPE_NAME5.DataPropertyName = "DRAWING_TYPE_NAME5";
            this.DRAWING_TYPE_NAME5.HeaderText = "图纸5";
            this.DRAWING_TYPE_NAME5.Name = "DRAWING_TYPE_NAME5";
            // 
            // DRAWING_TYPE_NAME6
            // 
            this.DRAWING_TYPE_NAME6.DataPropertyName = "DRAWING_TYPE_NAME6";
            this.DRAWING_TYPE_NAME6.HeaderText = "图纸6";
            this.DRAWING_TYPE_NAME6.Name = "DRAWING_TYPE_NAME6";
            // 
            // TECHNOLOGY_NAME1
            // 
            this.TECHNOLOGY_NAME1.DataPropertyName = "TECHNOLOGY_NAME1";
            this.TECHNOLOGY_NAME1.HeaderText = "技术1";
            this.TECHNOLOGY_NAME1.Name = "TECHNOLOGY_NAME1";
            this.TECHNOLOGY_NAME1.ReadOnly = true;
            // 
            // TECHNOLOGY_NAME2
            // 
            this.TECHNOLOGY_NAME2.DataPropertyName = "TECHNOLOGY_NAME2";
            this.TECHNOLOGY_NAME2.HeaderText = "技术2";
            this.TECHNOLOGY_NAME2.Name = "TECHNOLOGY_NAME2";
            this.TECHNOLOGY_NAME2.ReadOnly = true;
            // 
            // TECHNOLOGY_NAME3
            // 
            this.TECHNOLOGY_NAME3.DataPropertyName = "TECHNOLOGY_NAME3";
            this.TECHNOLOGY_NAME3.HeaderText = "技术3";
            this.TECHNOLOGY_NAME3.Name = "TECHNOLOGY_NAME3";
            this.TECHNOLOGY_NAME3.ReadOnly = true;
            // 
            // PRODUCTION_CYCLE
            // 
            this.PRODUCTION_CYCLE.DataPropertyName = "PRODUCTION_CYCLE";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.PRODUCTION_CYCLE.DefaultCellStyle = dataGridViewCellStyle2;
            this.PRODUCTION_CYCLE.HeaderText = "工艺周期(天)";
            this.PRODUCTION_CYCLE.Name = "PRODUCTION_CYCLE";
            this.PRODUCTION_CYCLE.ReadOnly = true;
            this.PRODUCTION_CYCLE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PROCESS_STATUS_NAME
            // 
            this.PROCESS_STATUS_NAME.HeaderText = "是否为备料";
            this.PROCESS_STATUS_NAME.Name = "PROCESS_STATUS_NAME";
            this.PROCESS_STATUS_NAME.ReadOnly = true;
            // 
            // PROCESS_STATUS
            // 
            this.PROCESS_STATUS.DataPropertyName = "PROCESS_STATUS";
            this.PROCESS_STATUS.HeaderText = "PROCESS_STATUS";
            this.PROCESS_STATUS.Name = "PROCESS_STATUS";
            this.PROCESS_STATUS.ReadOnly = true;
            this.PROCESS_STATUS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PROCESS_STATUS.Visible = false;
            // 
            // CREATE_USER
            // 
            this.CREATE_USER.DataPropertyName = "CREATE_USER";
            this.CREATE_USER.HeaderText = "创建人";
            this.CREATE_USER.Name = "CREATE_USER";
            this.CREATE_USER.ReadOnly = true;
            this.CREATE_USER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CREATE_USER.Width = 101;
            // 
            // CREATE_DATE_TIME
            // 
            this.CREATE_DATE_TIME.DataPropertyName = "CREATE_DATE_TIME";
            this.CREATE_DATE_TIME.HeaderText = "创建时间";
            this.CREATE_DATE_TIME.Name = "CREATE_DATE_TIME";
            this.CREATE_DATE_TIME.ReadOnly = true;
            this.CREATE_DATE_TIME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CREATE_DATE_TIME.Width = 150;
            // 
            // LAST_UPDATE_USER
            // 
            this.LAST_UPDATE_USER.DataPropertyName = "LAST_UPDATE_USER";
            this.LAST_UPDATE_USER.HeaderText = "最后更新人";
            this.LAST_UPDATE_USER.Name = "LAST_UPDATE_USER";
            this.LAST_UPDATE_USER.ReadOnly = true;
            this.LAST_UPDATE_USER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LAST_UPDATE_USER.Width = 101;
            // 
            // LAST_UPDATE_TIME
            // 
            this.LAST_UPDATE_TIME.DataPropertyName = "LAST_UPDATE_TIME";
            this.LAST_UPDATE_TIME.HeaderText = "最后更新时间";
            this.LAST_UPDATE_TIME.Name = "LAST_UPDATE_TIME";
            this.LAST_UPDATE_TIME.ReadOnly = true;
            this.LAST_UPDATE_TIME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LAST_UPDATE_TIME.Width = 150;
            // 
            // FrmProductionProcess
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1025, 671);
            this.Controls.Add(this.pInfo);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmProductionProcess";
            this.Text = "工序设定";
            this.Load += new System.EventHandler(this.FrmProductionProcess_Load);
            this.pInfo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pInfo;
        private CZZD.ERP.ComControls.MasterToolBarControl MasterToolBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtOrderCode;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvData;
        private CZZD.ERP.ComControls.PageControl pgControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ENGLISHNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn CREATE_USER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn LAST_UPDATE_USER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ENGLISH_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPARTMENT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn DRAWING_TYPE_NAME1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DRAWING_TYPE_NAME2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DRAWING_TYPE_NAME3;
        private System.Windows.Forms.DataGridViewTextBoxColumn DRAWING_TYPE_NAME4;
        private System.Windows.Forms.DataGridViewTextBoxColumn DRAWING_TYPE_NAME5;
        private System.Windows.Forms.DataGridViewTextBoxColumn DRAWING_TYPE_NAME6;
        private System.Windows.Forms.DataGridViewTextBoxColumn TECHNOLOGY_NAME1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TECHNOLOGY_NAME2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TECHNOLOGY_NAME3;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCTION_CYCLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROCESS_STATUS_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROCESS_STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn CREATE_USER;
        private System.Windows.Forms.DataGridViewTextBoxColumn CREATE_DATE_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn LAST_UPDATE_USER;
        private System.Windows.Forms.DataGridViewTextBoxColumn LAST_UPDATE_TIME;
    }
}