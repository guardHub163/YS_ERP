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

namespace CZZD.ERP.WinUI
{
    public partial class FrmPurchaseOrderSupplementEntry : FrmBase
    {
        public FrmPurchaseOrderSupplementEntry()
        {
            InitializeComponent();
        }

        #region 页面初始化
        private void FrmPurchaseEntry_Load(object sender, EventArgs e)
        {
            this.Tag = CTag;
            this.WindowState = FormWindowState.Normal;

            init();
            PageSize = 14;
            dgvData.Rows.Add(PageSize);
            dgvData.Rows[0].Selected = true;
        }

        private void init()
        {
            #region dgvData
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            #endregion
        }
        #endregion

        #region 窗口关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 组成品
        private void btnProduct_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("PRODUCT", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtProductCode.Text = frm.BaseMasterTable.Code;
                    txtProductName.Text = frm.BaseMasterTable.Name;
                    txtProductCode.Focus();
                    txtWarehouseCode.Focus();
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
                if (product == null)
                {
                    txtProductCode.Focus();
                    txtProductCode.Text = "";
                    txtProductName.Text = "";
                    MessageBox.Show("商品编号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtProductName.Text = product.NAME;
                }
            }
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
                    txtQunitity.Focus();
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
                    MessageBox.Show("出库仓库不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (row.Cells["PARTS_CODE"].Value == null || "".Equals(row.Cells["PARTS_CODE"].Value.ToString()))
                {
                    row.Selected = false;
                }
            }
        }

        private void FrmPurchaseOrderSupplementEntry_Shown(object sender, EventArgs e)
        {
            txtProductCode.Focus();
        }

        #region 按键顺序
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                System.Windows.Forms.SendKeys.Send("{Tab}");
                //ProcessTabKey(true);
            }

            if (txtQunitity.Focused)
            {
                //if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
                //{
                //    e.Handled = true;
                //}
                InputInteger(sender, e);
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

        #region 查询
        private void btnDetailsConfirmed_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                int currentPage = 1;
                int recordCount = bPurchaseOrder.GetPartsRecordCount(txtProductCode.Text.Trim());
                if (recordCount < 0)
                {
                    MessageBox.Show("查询的信息不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                //分页标签初始化
                this.pgControl.init(GetTotalPage(recordCount), currentPage);

                //数据绑定
                BindData(currentPage);
            }
        }

        /// <summary>
        /// 数据查询,绑定
        /// </summary>
        private void BindData(int currentPage)
        {
            DataSet ds = bPurchaseOrder.GetPartsList(txtProductCode.Text.Trim(), "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);

            dgvData.Rows.Clear();
            foreach (DataRow rows in ds.Tables[0].Rows)
            {
                int currentRowIndex = dgvData.Rows.Add(1);
                DataGridViewRow row = dgvData.Rows[currentRowIndex];
                row.Cells[1].Selected = true;
                row.Cells["No"].Value = rows["Row"];
                row.Cells["PARTS_CODE"].Value = rows["PRODUCT_PART_CODE"];
                row.Cells["PARTS_NAME"].Value = bCommon.GetBaseMaster("PRODUCT", rows["PRODUCT_PART_CODE"].ToString()).Name;
                row.Cells["MIN_QUANTITY"].Value = rows["QUANTITY"];
                row.Cells["QUANTITY"].Value = Convert.ToDecimal(rows["QUANTITY"]) * Convert.ToDecimal(txtQunitity.Text.Trim());

                BaseStockTable stock = new BaseStockTable();
                stock = bPurchaseOrder.GetStockModel(txtWarehouseCode.Text.Trim(), rows["PRODUCT_PART_CODE"].ToString());
                row.Cells["STOCK_QUANTITY"].Value = stock.QUANTITY;
                row.Cells["UNIT_NAME"].Value = bCommon.GetBaseMaster("UNIT", stock.UNIT_CODE).Name;

                row.Cells["PURCHASE_QUANTITY"].Value = bPurchaseOrder.GetPurchaseQuantity(txtWarehouseCode.Text.Trim(), rows["PRODUCT_PART_CODE"].ToString());

            }
            if (ds.Tables[0].Rows.Count < PageSize * currentPage)
            {
                dgvData.Rows.Add(PageSize - ds.Tables[0].Rows.Count);
            }
        }

        /// <summary>
        /// 当前页码发生变化时的操作
        /// </summary>
        private void pgControl_PageChanged(object sender, EventArgs e, int currentPage)
        {
            BindData(currentPage);
        }

        public bool checkInput()
        {
            string strErrorlog = null;            
            //判断组成品编号不能为空
            if (string.IsNullOrEmpty(this.txtProductCode.Text.Trim()))
            {
                strErrorlog += "组成品编号不能为空!\r\n";
            }
            //数量不能为空
            if (string.IsNullOrEmpty(this.txtQunitity.Text.Trim()))
            {
                strErrorlog += "数量不能为空!\r\n";
            }
            //判断仓库编号不能为空
            if (string.IsNullOrEmpty(this.txtWarehouseCode.Text.Trim()))
            {
                strErrorlog += "仓库编号不能为空!\r\n";
            }
            if (strErrorlog != null || "".Equals(strErrorlog))
            {
                MessageBox.Show(strErrorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        #endregion        
    }
}
