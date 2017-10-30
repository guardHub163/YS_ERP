using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Model;
using System.Collections;
using CZZD.ERP.Common;
using CZZD.ERP.Bll;

namespace CZZD.ERP.WinUI
{
    public partial class FrmAppendant : FrmBase
    {
        private DialogResult resutlStatus = DialogResult.Cancel;
        public List<ListItem> resultData = new List<ListItem>();
        private List<DataGridView> dgvList = new List<DataGridView>();
        private BSlipTypeCompositionProducts bSlipTypeProductGroup = new BSlipTypeCompositionProducts();
        private BCompositionProductsProductionProcess bCompositionProductsProductionProcess = new BCompositionProductsProductionProcess();

        public FrmAppendant()
        {
            InitializeComponent();
        }

        /// <summary>
        /// init();
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAppendant_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("SLIP_TYPE_CODE='{0}'", CTag);
            //sb.AppendFormat(" and DISTINCTION = 2");
            DataSet ds = bSlipTypeProductGroup.GetList(sb.ToString());
            DataTable dt = ds.Tables[0];
            TabPage tPage = null;

            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    #region delete
                    //btn = new Button();
                    ////btn.BackgroundImage = global::POS.Properties.Resources.button_1;
                    ////btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    ////btn.Dock = System.Windows.Forms.DockStyle.Left;
                    //btn.FlatAppearance.BorderSize = 0;
                    ////btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    //btn.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
                    //btn.Location = new System.Drawing.Point(75*i+++1, 8);
                    //btn.Name = "btn" + row["CODE"].ToString();
                    //btn.Tag = row["CODE"];
                    //btn.Size = new System.Drawing.Size(75, 30);
                    //btn.TabIndex = 0;
                    //btn.Text = row["NAME"].ToString();
                    //btn.UseVisualStyleBackColor = true;
                    //btn.ForeColor = Color.Black;
                    //btn.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
                    //btn.TextAlign = ContentAlignment.MiddleCenter;
                    //btn.Cursor = System.Windows.Forms.Cursors.Hand;
                    //btn.Click += new System.EventHandler(this.Btn_Group_Click);
                    //pButton.Controls.Add(btn);
                    #endregion

                    // 
                    // tabPage1
                    // 
                    tPage = new TabPage();
                    tPage.Location = new System.Drawing.Point(4, 22);
                    tPage.Name = row["COMPOSITION_PRODUCTS_CODE"].ToString();
                    tPage.Padding = new System.Windows.Forms.Padding(0);
                    tPage.Size = new System.Drawing.Size(736, 411);
                    tPage.TabIndex = 0;
                    //tPage.Text = " " + row["NAME"].ToString() + " ";
                    tPage.Text = " " + row["COMPOSITION_PRODUCTS_NAME"].ToString() + " ";
                    tPage.UseVisualStyleBackColor = true;

                    DataGridView dgv = CreateDataGridView(row["COMPOSITION_PRODUCTS_CODE"].ToString());
                    //将dgv放入内存中
                    dgvList.Add(dgv);

                    tPage.Controls.Add(dgv);
                    tabControls.TabPages.Add(tPage);
                }
            }
        }

        /// <summary>
        /// 创建DataGridView
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private DataGridView CreateDataGridView(string code)
        {
            DataGridView dgv = new DataGridView();

            DataGridViewCheckBoxColumn CHK = new DataGridViewCheckBoxColumn();
            DataGridViewTextBoxColumn CODE = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn NAME = new DataGridViewTextBoxColumn();
            //DataGridViewTextBoxColumn MODEL_NUMBER = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn QUANTITY = new DataGridViewTextBoxColumn();
            // 
            // CHK
            // 
            CHK.FillWeight = 50F;
            CHK.HeaderText = "选择";
            CHK.Name = "CHK";
            CHK.Width = 50;
            CHK.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // CODE
            // 
            CODE.DataPropertyName = "CODE";
            CODE.FillWeight = 130F;
            CODE.HeaderText = "规格型号编号";
            CODE.Name = "CODE";
            CODE.ReadOnly = true;
            CODE.Width = 130;
            CODE.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // NAME
            // 
            NAME.DataPropertyName = "NAME";
            NAME.FillWeight = 150F;
            NAME.HeaderText = "规格型号名称";
            NAME.Name = "NAME";
            NAME.ReadOnly = true;
            NAME.Width = 150;
            NAME.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // MODE_NUMBER
            // 
            //MODEL_NUMBER.DataPropertyName = "MODE_NUMBER";
            //MODEL_NUMBER.FillWeight = 150F;
            //MODEL_NUMBER.HeaderText = "规格型号";
            //MODEL_NUMBER.Name = "MODE_NUMBER";
            //MODEL_NUMBER.ReadOnly = true;
            //MODEL_NUMBER.Width = 150;
            //MODEL_NUMBER.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // QUANTITY
            // 
            QUANTITY.DataPropertyName = "QUANTITY";
            QUANTITY.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            QUANTITY.FillWeight = 100F;
            QUANTITY.HeaderText = "数量";
            QUANTITY.Name = "QUANTITY";
            QUANTITY.Width = 100;
            QUANTITY.MaxInputLength = 6;
            QUANTITY.SortMode = DataGridViewColumnSortMode.NotSortable;
            QUANTITY.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Info;

            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeColumns = true;
            dgv.AllowUserToResizeRows = false;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dgv.BackgroundColor = System.Drawing.Color.White;
            dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            CHK,
            CODE,
            NAME,
            //MODEL_NUMBER,
            QUANTITY});
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            dgv.GridColor = System.Drawing.Color.Gray;
            dgv.Location = new System.Drawing.Point(3, 3);
            dgv.Name = "dgv" + code;
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.Height = 23;
            dgv.Size = new System.Drawing.Size(730, 405);
            dgv.TabIndex = 0;

            dgv.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(dgvData_CellValidated);
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersHeight = 25;
            dgv.EditMode = DataGridViewEditMode.EditOnEnter;

            //数据绑定
            BindData(dgv, code);
            return dgv;

        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="code"></param>
        private void BindData(DataGridView dgv, string code)
        {
            DataTable dtData = bCompositionProductsProductionProcess.GetList("COMPOSITION_PRODUCTS_CODE = '" + code + "'").Tables[0];
            if (dtData != null && dtData.Rows.Count > 0)
            {
                foreach (DataRow row in dtData.Rows)
                {
                    try
                    {
                        object[] obj = { false, row["SPECIFICATION_CODE"], row["SPECIFICATION_NAME"], 1 };
                        dgv.Rows.Add(obj);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }


        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            resutlStatus = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// 窗口关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAppendant_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = resutlStatus;
        }

        /// <summary>
        /// 选择确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            foreach (DataGridView dgv in dgvList)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["CHK"].Value))
                    {
                        resultData.Add(new ListItem(CConvert.ToString(row.Cells["CODE"].Value), "",CConvert.ToDecimal(row.Cells["QUANTITY"].Value)));
                    }
                }
            }
            if (resultData.Count > 0)
            {
                resutlStatus = DialogResult.OK;
            }
            else
            {
                resutlStatus = DialogResult.Cancel;
            }
            this.Close();
        }

        //数据验证
        private void dgvData_CellValidated(object sender, EventArgs e)
        {


        }
    }//end class

}
