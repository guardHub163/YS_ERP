using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Model;
using CZZD.ERP.Common;

namespace CZZD.ERP.WinUI
{
    public partial class FrmPurchaseOrderSupplementSearch : FrmBase
    {
        private DataTable _currentDt = new DataTable();
        private bool isSearch = false;
        private string oldGetCondition = "";

        public FrmPurchaseOrderSupplementSearch()
        {
            InitializeComponent();
        }

        #region
        private void FrmListSupplemental_Load(object sender, EventArgs e)
        {
            this.Tag = CTag;
            this.WindowState = FormWindowState.Normal;

            init();
            PageSize = 14;
            dgvData.Rows.Add(PageSize);
            dgvData.Rows[0].Selected = true;
        }

        /// <summary>
        /// 页面初始化
        /// </summary>
        private void init()
        {
            #region dgvData
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            #endregion
        }
        #endregion

        #region 出库仓库
        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("WAREHOUSE", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtWarehouseCode.Text = frm.BaseMasterTable.Code;
                    txtWarehouseName.Text = frm.BaseMasterTable.Name;
                }
            }
            frm.Dispose();
        }

        /// <summary>
        /// 仓库输入验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtWarehouseCode_Leave(object sender, EventArgs e)
        {
            string warehouseCode = txtWarehouseCode.Text.Trim();
            if (warehouseCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("WAREHOUSE", warehouseCode);
                if (baseMaster != null)
                {
                    txtWarehouseCode.Text = baseMaster.Code;
                    txtWarehouseName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("仓库编号不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtWarehouseCode.Text = "";
                    txtWarehouseName.Text = "";
                    txtWarehouseCode.Focus();
                }
            }
            else
            {
                txtWarehouseName.Text = "";
            }
        }
        #endregion

        #region 商品
        private void btnProduct_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("PRODUCT", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtProductCode.Text = frm.BaseMasterTable.Code;
                    txtProductName.Text = frm.BaseMasterTable.Name;
                    btnSearch.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtProductCode_Leave(object sender, EventArgs e)
        {
            string ProductCode = txtProductCode.Text.Trim();
            if (ProductCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("PRODUCT", ProductCode);
                if (baseMaster != null)
                {
                    txtProductCode.Text = baseMaster.Code;
                    txtProductName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("商品不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtProductCode.Text = "";
                    txtProductName.Text = "";
                    txtProductCode.Focus();
                }
            }
            else
            {
                txtProductName.Text = "";
            }
        }

        #endregion

        #region 关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确定要关闭吗？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                this.Close();
            }
        }
        #endregion

        #region 控制空行不能被点击
        /// <summary>
        ///　控制空行不能被点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Index >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.Row.Index];
                if (row.Cells["PRODUCT_CODE"].Value == null || "".Equals(row.Cells["PRODUCT_CODE"].Value.ToString()))
                {
                    row.Selected = false;
                }
            }
        }
        #endregion

        #region 查询分页
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>    
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtWarehouseCode.Text.Trim()))
            {
                 MessageBox.Show("仓库编号不能为空!",this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int currentPage = 1;
                int recordCount = bPurchaseOrder.GetPurchaseSupplementRecordCount(GetConduction());
                if (recordCount < 0)
                {
                    MessageBox.Show("查询的信息不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                //分页标签初始化
                this.pgControl.init(GetTotalPage(recordCount), currentPage);

                //数据绑定
                BindData(currentPage);
                isSearch = true;
            }
        }

        /// <summary>
        /// 数据查询,绑定
        /// </summary>
        private void BindData(int currentPage)
        {
            string strWhere = GetConduction();
            DataSet ds = bPurchaseOrder.GetPurchaseSupplementList(strWhere, "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);

            dgvData.Rows.Clear();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow rows in ds.Tables[0].Rows)
                {
                    int currentRowIndex = dgvData.Rows.Add(1);
                    DataGridViewRow row = dgvData.Rows[currentRowIndex];
                    row.Cells[1].Selected = true;
                    row.Cells["No"].Value = rows["Row"];
                    row.Cells["PRODUCT_CODE"].Value = rows["PRODUCT_CODE"];
                    row.Cells["PRODUCT_NAME"].Value = rows["PRODUCT_NAME"];
                    row.Cells["UNIT_NAME"].Value = rows["UNIT_NAME"];
                    row.Cells["QUANTITY"].Value = rows["QUANTITY"];
                    row.Cells["PRODUCT_GROUP_NAME"].Value = rows["PRODUCT_GROUP_NAME"];
                    row.Cells["MODEL_NUMBER"].Value = CConvert.ToString(rows["SPEC"]) + CConvert.ToString(rows["MODEL_NUMBER"]);
                    row.Cells["SAFETY_STOCK"].Value = rows["SAFETY_STOCK"];
                    row.Cells["MAX_QUANTITY"].Value = rows["MAX_QUANTITY"];
                    row.Cells["MIN_PURCHASE_QUANTITY"].Value = rows["MIN_PURCHASE_QUANTITY"];

                    if ((CConvert.ToDecimal(rows["MAX_QUANTITY"]) - CConvert.ToDecimal(rows["QUANTITY"])) > CConvert.ToDecimal(rows["MIN_PURCHASE_QUANTITY"]))
                    {
                        row.Cells["NO_WORTH_QUANTITY"].Value = CConvert.ToDecimal(rows["MAX_QUANTITY"]) - CConvert.ToDecimal(rows["QUANTITY"]);
                    }
                    else
                    {
                        row.Cells["NO_WORTH_QUANTITY"].Value = rows["MIN_PURCHASE_QUANTITY"];
                    }

                    row.Cells["PURCHASE_QUANTITY"].Value = bPurchaseOrder.GetPurchaseQuantity(txtWarehouseCode.Text.Trim(), rows["PRODUCT_CODE"].ToString());
                }
            }
            else 
            {
                MessageBox.Show("查询的数据不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (ds.Tables[0].Rows.Count < PageSize * currentPage)
            {
                dgvData.Rows.Add(PageSize - ds.Tables[0].Rows.Count);
            }
        }

        /// <summary>
        /// 获得查询条件
        /// </summary>
        private string GetConduction()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" STATUS_FLAG <> {0}", CConstant.DELETE);
            if (txtProductCode.Text.Trim() != "")
            {
                sb.AppendFormat(" and PRODUCT_CODE = '{0}'", txtProductCode.Text.Trim());
            }

            if (txtWarehouseCode.Text.Trim() != "")
            {
                sb.AppendFormat(" and WAREHOUSE_CODE = '{0}'", txtWarehouseCode.Text.Trim());
            }

            return sb.ToString();
        }

        /// <summary>
        /// 当前页码发生变化时的操作
        /// </summary>
        private void pgControl_PageChanged(object sender, EventArgs e, int currentPage)
        {
            BindData(currentPage);
        }
        #endregion

        #region 按键顺序
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                System.Windows.Forms.SendKeys.Send("{Tab}");
                //ProcessTabKey(true);
            }
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                System.Windows.Forms.SendKeys.Send("+{Tab}");
            }
            if (e.KeyCode == Keys.Down)
            {
                System.Windows.Forms.SendKeys.Send("{Tab}");
            }
        }
        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {            
            _currentDt = bPurchaseOrder.GetPurchaseSupplementList(oldGetCondition).Tables[0];           
            if (isSearch && _currentDt.Rows.Count > 0)
            {
                int result = CExport.DataTableToExcel(_currentDt, CConstant.PO_SUPPLEMENT_HEADER, CConstant.PO_SUPPLEMENT_COLUMNS, "PO_SUPPLEMENT", "PO_SUPPLEMENT");
                if (result == CConstant.EXPORT_SUCCESS)
                {
                    MessageBox.Show("导出成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
