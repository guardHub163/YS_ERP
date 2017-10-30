namespace CZZD.ERP.WinUI
{
    partial class FrmCompositionProductsProductionProcess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCompositionProductsProductionProcess));
            this.pBody = new System.Windows.Forms.Panel();
            this.pSearch = new System.Windows.Forms.Panel();
            this.pgControl = new CZZD.ERP.ComControls.PageControl();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.pConditiion = new System.Windows.Forms.Panel();
            this.pright = new System.Windows.Forms.Panel();
            this.txtProductionProcessName = new System.Windows.Forms.TextBox();
            this.txtProductionProcessCode = new System.Windows.Forms.TextBox();
            this.txtCompositionProductsName = new System.Windows.Forms.TextBox();
            this.txtCompositionProductsCode = new System.Windows.Forms.TextBox();
            this.pleft = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MasterToolBar = new CZZD.ERP.ComControls.MasterToolBarControl();
            this.COMPOSITION_PRODUCTS_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMPOSITION_PRODUCTS_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCTION_PROCESS_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCTION_PROCESS_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCTION_SEQUENCE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pBody.SuspendLayout();
            this.pSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.pConditiion.SuspendLayout();
            this.pright.SuspendLayout();
            this.pleft.SuspendLayout();
            this.SuspendLayout();
            // 
            // pBody
            // 
            this.pBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBody.Controls.Add(this.pSearch);
            this.pBody.Controls.Add(this.MasterToolBar);
            this.pBody.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.pBody.Location = new System.Drawing.Point(0, 0);
            this.pBody.Name = "pBody";
            this.pBody.Size = new System.Drawing.Size(1020, 650);
            this.pBody.TabIndex = 1;
            // 
            // pSearch
            // 
            this.pSearch.Controls.Add(this.pgControl);
            this.pSearch.Controls.Add(this.dgvData);
            this.pSearch.Controls.Add(this.pConditiion);
            this.pSearch.Location = new System.Drawing.Point(3, 33);
            this.pSearch.Name = "pSearch";
            this.pSearch.Size = new System.Drawing.Size(1012, 610);
            this.pSearch.TabIndex = 11;
            // 
            // pgControl
            // 
            this.pgControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pgControl.Location = new System.Drawing.Point(0, 580);
            this.pgControl.Name = "pgControl";
            this.pgControl.Size = new System.Drawing.Size(1012, 30);
            this.pgControl.TabIndex = 6;
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
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvData.ColumnHeadersHeight = 30;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COMPOSITION_PRODUCTS_CODE,
            this.COMPOSITION_PRODUCTS_NAME,
            this.PRODUCTION_PROCESS_CODE,
            this.PRODUCTION_PROCESS_NAME,
            this.PRODUCTION_SEQUENCE});
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(0, 129);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 45;
            this.dgvData.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1012, 450);
            this.dgvData.TabIndex = 5;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            this.dgvData.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvData_RowStateChanged);
            // 
            // pConditiion
            // 
            this.pConditiion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pConditiion.Controls.Add(this.pright);
            this.pConditiion.Controls.Add(this.pleft);
            this.pConditiion.Location = new System.Drawing.Point(0, 0);
            this.pConditiion.Name = "pConditiion";
            this.pConditiion.Size = new System.Drawing.Size(510, 125);
            this.pConditiion.TabIndex = 4;
            // 
            // pright
            // 
            this.pright.Controls.Add(this.txtProductionProcessName);
            this.pright.Controls.Add(this.txtProductionProcessCode);
            this.pright.Controls.Add(this.txtCompositionProductsName);
            this.pright.Controls.Add(this.txtCompositionProductsCode);
            this.pright.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pright.Location = new System.Drawing.Point(118, 0);
            this.pright.Name = "pright";
            this.pright.Size = new System.Drawing.Size(390, 123);
            this.pright.TabIndex = 1;
            // 
            // txtProductionProcessName
            // 
            this.txtProductionProcessName.BackColor = System.Drawing.SystemColors.Info;
            this.txtProductionProcessName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductionProcessName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtProductionProcessName.Location = new System.Drawing.Point(5, 95);
            this.txtProductionProcessName.MaxLength = 20;
            this.txtProductionProcessName.Name = "txtProductionProcessName";
            this.txtProductionProcessName.Size = new System.Drawing.Size(250, 25);
            this.txtProductionProcessName.TabIndex = 11;
            // 
            // txtProductionProcessCode
            // 
            this.txtProductionProcessCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtProductionProcessCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductionProcessCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtProductionProcessCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtProductionProcessCode.Location = new System.Drawing.Point(5, 65);
            this.txtProductionProcessCode.MaxLength = 20;
            this.txtProductionProcessCode.Name = "txtProductionProcessCode";
            this.txtProductionProcessCode.Size = new System.Drawing.Size(250, 25);
            this.txtProductionProcessCode.TabIndex = 10;
            // 
            // txtCompositionProductsName
            // 
            this.txtCompositionProductsName.BackColor = System.Drawing.SystemColors.Info;
            this.txtCompositionProductsName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompositionProductsName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCompositionProductsName.Location = new System.Drawing.Point(5, 35);
            this.txtCompositionProductsName.MaxLength = 20;
            this.txtCompositionProductsName.Name = "txtCompositionProductsName";
            this.txtCompositionProductsName.Size = new System.Drawing.Size(250, 25);
            this.txtCompositionProductsName.TabIndex = 9;
            // 
            // txtCompositionProductsCode
            // 
            this.txtCompositionProductsCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtCompositionProductsCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompositionProductsCode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtCompositionProductsCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtCompositionProductsCode.Location = new System.Drawing.Point(5, 5);
            this.txtCompositionProductsCode.MaxLength = 20;
            this.txtCompositionProductsCode.Name = "txtCompositionProductsCode";
            this.txtCompositionProductsCode.Size = new System.Drawing.Size(250, 25);
            this.txtCompositionProductsCode.TabIndex = 8;
            // 
            // pleft
            // 
            this.pleft.BackColor = System.Drawing.Color.SteelBlue;
            this.pleft.Controls.Add(this.label1);
            this.pleft.Controls.Add(this.label3);
            this.pleft.Controls.Add(this.label4);
            this.pleft.Controls.Add(this.label2);
            this.pleft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pleft.Location = new System.Drawing.Point(0, 0);
            this.pleft.Name = "pleft";
            this.pleft.Size = new System.Drawing.Size(118, 123);
            this.pleft.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 28;
            this.label1.Text = "工序名称：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 27;
            this.label3.Text = "工序编号：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.SteelBlue;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "部件名称：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "部件编号：";
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
            // COMPOSITION_PRODUCTS_CODE
            // 
            this.COMPOSITION_PRODUCTS_CODE.DataPropertyName = "COMPOSITION_PRODUCTS_CODE";
            this.COMPOSITION_PRODUCTS_CODE.HeaderText = "部件编号";
            this.COMPOSITION_PRODUCTS_CODE.Name = "COMPOSITION_PRODUCTS_CODE";
            this.COMPOSITION_PRODUCTS_CODE.ReadOnly = true;
            this.COMPOSITION_PRODUCTS_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // COMPOSITION_PRODUCTS_NAME
            // 
            this.COMPOSITION_PRODUCTS_NAME.DataPropertyName = "COMPOSITION_PRODUCTS_NAME";
            this.COMPOSITION_PRODUCTS_NAME.HeaderText = "部件名称";
            this.COMPOSITION_PRODUCTS_NAME.Name = "COMPOSITION_PRODUCTS_NAME";
            this.COMPOSITION_PRODUCTS_NAME.ReadOnly = true;
            this.COMPOSITION_PRODUCTS_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PRODUCTION_PROCESS_CODE
            // 
            this.PRODUCTION_PROCESS_CODE.DataPropertyName = "PRODUCTION_PROCESS_CODE";
            this.PRODUCTION_PROCESS_CODE.HeaderText = "工序编号";
            this.PRODUCTION_PROCESS_CODE.Name = "PRODUCTION_PROCESS_CODE";
            this.PRODUCTION_PROCESS_CODE.ReadOnly = true;
            this.PRODUCTION_PROCESS_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PRODUCTION_PROCESS_NAME
            // 
            this.PRODUCTION_PROCESS_NAME.DataPropertyName = "PRODUCTION_PROCESS_NAME";
            this.PRODUCTION_PROCESS_NAME.HeaderText = "工序名称";
            this.PRODUCTION_PROCESS_NAME.Name = "PRODUCTION_PROCESS_NAME";
            this.PRODUCTION_PROCESS_NAME.ReadOnly = true;
            this.PRODUCTION_PROCESS_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PRODUCTION_SEQUENCE
            // 
            this.PRODUCTION_SEQUENCE.DataPropertyName = "PRODUCTION_SEQUENCE";
            this.PRODUCTION_SEQUENCE.HeaderText = "序号";
            this.PRODUCTION_SEQUENCE.Name = "PRODUCTION_SEQUENCE";
            this.PRODUCTION_SEQUENCE.ReadOnly = true;
            // 
            // FrmCompositionProductsProductionProcess
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1030, 658);
            this.Controls.Add(this.pBody);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCompositionProductsProductionProcess";
            this.Text = "部件工序构成";
            this.Load += new System.EventHandler(this.FrmCompositionProductsSpecification_Load);
            this.pBody.ResumeLayout(false);
            this.pSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.pConditiion.ResumeLayout(false);
            this.pright.ResumeLayout(false);
            this.pright.PerformLayout();
            this.pleft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pBody;
        private System.Windows.Forms.Panel pSearch;
        private CZZD.ERP.ComControls.PageControl pgControl;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Panel pConditiion;
        private System.Windows.Forms.Panel pright;
        private System.Windows.Forms.TextBox txtCompositionProductsName;
        private System.Windows.Forms.TextBox txtCompositionProductsCode;
        private System.Windows.Forms.Panel pleft;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private CZZD.ERP.ComControls.MasterToolBarControl MasterToolBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProductionProcessName;
        private System.Windows.Forms.TextBox txtProductionProcessCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMPOSITION_PRODUCTS_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMPOSITION_PRODUCTS_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCTION_PROCESS_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCTION_PROCESS_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCTION_SEQUENCE;
    }
}