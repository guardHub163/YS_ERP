namespace CZZD.ERP.WinUI.Production
{
    partial class DrawingUpLoad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrawingUpLoad));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.clbDrawing = new System.Windows.Forms.CheckedListBox();
            this.btnUpLoad = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLIP_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DRAWINGNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FILENAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DRAWINGCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTN_DELETE = new System.Windows.Forms.DataGridViewImageColumn();
            this.LOCATION_FILE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSearch.Location = new System.Drawing.Point(372, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 30);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "浏览";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.BackColor = System.Drawing.Color.White;
            this.txtFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFileName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtFileName.Location = new System.Drawing.Point(5, 10);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(356, 25);
            this.txtFileName.TabIndex = 1;
            // 
            // clbDrawing
            // 
            this.clbDrawing.BackColor = System.Drawing.Color.White;
            this.clbDrawing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clbDrawing.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.clbDrawing.FormattingEnabled = true;
            this.clbDrawing.Location = new System.Drawing.Point(5, 55);
            this.clbDrawing.Name = "clbDrawing";
            this.clbDrawing.Size = new System.Drawing.Size(457, 182);
            this.clbDrawing.TabIndex = 3;
            // 
            // btnUpLoad
            // 
            this.btnUpLoad.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnUpLoad.Location = new System.Drawing.Point(372, 255);
            this.btnUpLoad.Name = "btnUpLoad";
            this.btnUpLoad.Size = new System.Drawing.Size(90, 30);
            this.btnUpLoad.TabIndex = 4;
            this.btnUpLoad.Text = "上传";
            this.btnUpLoad.UseVisualStyleBackColor = true;
            this.btnUpLoad.Click += new System.EventHandler(this.btnUpLoad_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.ColumnHeadersHeight = 25;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.SLIP_NUMBER,
            this.DRAWINGNAME,
            this.FILENAME,
            this.DRAWINGCODE,
            this.BTN_DELETE,
            this.LOCATION_FILE_NAME});
            this.dgvData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(5, 291);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 45;
            this.dgvData.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(457, 245);
            this.dgvData.TabIndex = 5;
            this.dgvData.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvData_CellPainting);
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnClose.Location = new System.Drawing.Point(372, 542);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 30);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // No
            // 
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 35;
            // 
            // SLIP_NUMBER
            // 
            this.SLIP_NUMBER.DataPropertyName = "SLIP_NUMBER";
            this.SLIP_NUMBER.HeaderText = "生产工单编号";
            this.SLIP_NUMBER.Name = "SLIP_NUMBER";
            this.SLIP_NUMBER.ReadOnly = true;
            this.SLIP_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SLIP_NUMBER.Width = 150;
            // 
            // DRAWINGNAME
            // 
            this.DRAWINGNAME.DataPropertyName = "NAME";
            this.DRAWINGNAME.HeaderText = "图纸名称";
            this.DRAWINGNAME.Name = "DRAWINGNAME";
            this.DRAWINGNAME.ReadOnly = true;
            this.DRAWINGNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DRAWINGNAME.Width = 90;
            // 
            // FILENAME
            // 
            this.FILENAME.DataPropertyName = "SERVER_FILE_NAME";
            this.FILENAME.HeaderText = "文件名";
            this.FILENAME.Name = "FILENAME";
            this.FILENAME.ReadOnly = true;
            this.FILENAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FILENAME.Width = 250;
            // 
            // DRAWINGCODE
            // 
            this.DRAWINGCODE.DataPropertyName = "DRAWING_CODE";
            this.DRAWINGCODE.HeaderText = "DRAWING_CODE";
            this.DRAWINGCODE.Name = "DRAWINGCODE";
            this.DRAWINGCODE.Visible = false;
            // 
            // BTN_DELETE
            // 
            this.BTN_DELETE.HeaderText = "删除";
            this.BTN_DELETE.Image = global::CZZD.ERP.WinUI.Properties.Resources.line_delete;
            this.BTN_DELETE.Name = "BTN_DELETE";
            this.BTN_DELETE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // LOCATION_FILE_NAME
            // 
            this.LOCATION_FILE_NAME.DataPropertyName = "LOCATION_FILE_NAME";
            this.LOCATION_FILE_NAME.HeaderText = "LOCATION_FILE_NAME";
            this.LOCATION_FILE_NAME.Name = "LOCATION_FILE_NAME";
            this.LOCATION_FILE_NAME.ReadOnly = true;
            this.LOCATION_FILE_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LOCATION_FILE_NAME.Visible = false;
            // 
            // DrawingUpLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 579);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.btnUpLoad);
            this.Controls.Add(this.clbDrawing);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.btnSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DrawingUpLoad";
            this.Text = "图纸上传";
            this.Load += new System.EventHandler(this.DrawingUpLoad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.CheckedListBox clbDrawing;
        private System.Windows.Forms.Button btnUpLoad;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLIP_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn DRAWINGNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn FILENAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn DRAWINGCODE;
        private System.Windows.Forms.DataGridViewImageColumn BTN_DELETE;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOCATION_FILE_NAME;
        //private System.Windows.Forms.DataGridViewTextBoxColumn No;
    }
}