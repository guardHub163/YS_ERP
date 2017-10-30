using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Model;
using CZZD.ERP.Bll;
using CZZD.ERP.Common;

namespace CZZD.ERP.WinUI
{
    public partial class FrmStockNotify : FrmBase
    {
        public FrmStockNotify()
        {
            InitializeComponent();
        }

        private void FrmStockNotify_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;

            #region dgvData初始化
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            PageSize = 14;
            #endregion

            btnSearch_Click(null, null);
        }

        #region 仓库
        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("WAREHOUSE", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtWarehouseCode.Text = frm.BaseMasterTable.Code;
                    txtWarehouseName.Text = frm.BaseMasterTable.Name;
                    txtWarehouseCode.Focus();
                    txtProductCode.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtWarehouseCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtWarehouseCode.Text.Trim()))
            {
                BaseWarehouseTable Warehouse = new BaseWarehouseTable();
                BWarehouse bWarehouse = new BWarehouse();
                Warehouse = bWarehouse.GetModel(this.txtWarehouseCode.Text);
                if (Warehouse == null || "".Equals(Warehouse))
                {
                    txtWarehouseCode.Focus();
                    txtWarehouseCode.Text = "";
                    txtWarehouseName.Text = "";
                    MessageBox.Show("仓库编号不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtWarehouseName.Text = Warehouse.NAME;
                }
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
            if (!string.IsNullOrEmpty(this.txtProductCode.Text.Trim()))
            {
                BaseProductTable product = new BaseProductTable();
                BProduct bProduct = new BProduct();
                product = bProduct.GetModel(this.txtProductCode.Text);
                if (product == null || "".Equals(product))
                {
                    txtProductCode.Focus();
                    txtProductCode.Text = "";
                    txtProductName.Text = "";
                    MessageBox.Show("商品编号不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtProductName.Text = product.NAME;
                }
            }
        }
        #endregion

        #region 查询分页
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int currentPage = 1;
            int recordCount = bStock.GetStockNotifyRecordCount(GetConduction());
            if (recordCount < 0)
            {
                MessageBox.Show("查询的信息不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //分页标签初始化
            this.pgControl.init(GetTotalPage(recordCount), currentPage);
            //数据绑定
            BindData(currentPage);
        }

        /// <summary>
        /// 数据查询,绑定
        /// </summary>
        private void BindData(int currentPage)
        {
            string strWhere = GetConduction();
            DataSet ds = bStock.GetStockNotifyList(strWhere, "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);
            for (int i = ds.Tables[0].Rows.Count; i < PageSize; i++)
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            }
            dgvData.DataSource = ds.Tables[0];
        }

        /// <summary>
        /// 获得查询条件
        /// </summary>
        private string GetConduction()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" STATUS_FLAG <> {0}", CConstant.DELETE);
            sb.Append(" and QUANTITY < SAFETY_STOCK ");
            if (!string.IsNullOrEmpty(txtProductCode.Text.Trim()))
            {
                sb.AppendFormat("and PRODUCT_CODE = '{0}'", txtProductCode.Text.Trim());
            }

            if (!string.IsNullOrEmpty(txtWarehouseCode.Text.Trim()))
            {
                sb.AppendFormat("and WAREHOUSE_CODE = '{0}'", txtWarehouseCode.Text.Trim());
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

        #region 控制空行不能被点击
        /// <summary>
        /// 控制空行不能被点击
        /// </summary>
        private void dgvData_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Index >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.Row.Index];
                if (row.Cells["NO"].Value == null || "".Equals(row.Cells["NO"].Value.ToString()))
                {
                    row.Selected = false;
                }
            }
        }
        #endregion

        #region 关闭
        /// <summary>
        /// 关闭
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
