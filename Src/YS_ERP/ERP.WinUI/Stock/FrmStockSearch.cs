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
using CZZD.ERP.WinUI.Properties;

namespace CZZD.ERP.WinUI
{
    public partial class FrmStockSearch : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private DataTable _currentDt = new DataTable();
        private bool isSearch = false;
        private string oldGetCondition = "";
        private string _warehouseCode = "";
        private string _productCode = "";

        public FrmStockSearch()
        {
            InitializeComponent();
        }

        public FrmStockSearch(string warehouseCode, string productCode)
        {
            _warehouseCode = warehouseCode;
            _productCode = productCode;
            InitializeComponent();
        }

        private void FrmStockSearch_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;
            init();

            if (_productCode != "" || _warehouseCode != "")
            {
                this.txtWarehouseCode.Text = _warehouseCode;
                txtWarehouseCode_Leave(txtWarehouseCode, EventArgs.Empty);
                this.txtProductCode.Text = _productCode;
                txtProductCode_Leave(txtProductCode, EventArgs.Empty);
                this.btnWarehouse.Enabled = false;
                this.txtWarehouseCode.Enabled = false;
                this.btnProduct.Enabled = false;
                this.txtProductCode.Enabled = false;
                this.btnSearch.Enabled = false;

                int currentPage = 1;
                int recordCount = bStock.GetStockRecordCount(GetConduction());

                if (recordCount > 0)
                {
                    //分页标签初始化
                    this.pgControl.init(GetTotalPage(recordCount), currentPage);
                    //数据绑定
                    BindData(currentPage);
                    isSearch = true;
                }
            }
        }

        #region dgvData初始化
        public void init()
        {
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;

            PageSize = 14;
            dgvData.Rows.Add(PageSize);
            dgvData.Rows[0].Selected = true;
        }
        #endregion

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
            //initLocation();
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
                    MessageBox.Show("仓库编号不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtWarehouseName.Text = Warehouse.NAME;
                }
            }
            else 
            {
                txtWarehouseName.Text = "";
            }
            //initLocation();
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
            //initLocation();
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
                    MessageBox.Show("商品编号不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtProductName.Text = product.NAME;
                }
            }
            else 
            {
                txtProductName.Text = "";
            }
            //initLocation();
        }
        #endregion

        #region 查询分页
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int currentPage = 1;
            int recordCount = bStock.GetStockRecordCount(GetConduction());
            if (recordCount < 0)
            {
                MessageBox.Show("查询的信息不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //分页标签初始化
            this.pgControl.init(GetTotalPage(recordCount), currentPage);
            //数据绑定
            BindData(currentPage);
            isSearch = true;
            oldGetCondition = GetConduction();
        }

        /// <summary>
        /// 数据查询,绑定
        /// </summary>
        private void BindData(int currentPage)
        {
            string strWhere = GetConduction();
            DataSet ds = bStock.GetStockList(strWhere, "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);
            _currentDt = ds.Tables[0];
            dgvData.Rows.Clear();

            if (_currentDt.Rows.Count > 0)
            {
                foreach (DataRow rows in ds.Tables[0].Rows)
                {
                    int currentRowIndex = dgvData.Rows.Add(1);
                    DataGridViewRow row = dgvData.Rows[currentRowIndex];
                    row.Cells[1].Selected = true;
                    row.Cells["No"].Value = rows["Row"];
                    row.Cells["PRODUCT_CODE"].Value = rows["PRODUCT_CODE"];
                    row.Cells["PRODUCT_NAME"].Value = rows["PRODUCT_NAME"];
                    row.Cells["WAREHOUSE_NAME"].Value = rows["WAREHOUSE_NAME"];
                    row.Cells["QUANTITY"].Value = rows["QUANTITY"];
                    row.Cells["WAREHOUSE_CODE"].Value = rows["WAREHOUSE_CODE"];
                    row.Cells["SPEC"].Value = rows["SPEC"];
                    row.Cells["LOCATION_NAME"].Value = rows["LOCATION_NAME"];
                    decimal alloationQuantity = bAlloation.GetAlloationQuantity(CConvert.ToString(rows["WAREHOUSE_CODE"]), CConvert.ToString(rows["PRODUCT_CODE"]));
                    row.Cells["ALLOATION_QUANTITY"].Value = Convert.ToString(alloationQuantity);
                    row.Cells["NO_ALLOATION"].Value = Convert.ToDecimal(row.Cells["QUANTITY"].Value) - Convert.ToDecimal(row.Cells["ALLOATION_QUANTITY"].Value);

                    row.Cells["RECEIPT_PLAN_QUANTITY"].Value = bStock.GetPurchaseQuantity(rows["WAREHOUSE_CODE"].ToString(), rows["PRODUCT_CODE"].ToString());
                }
                if (ds.Tables[0].Rows.Count < PageSize)
                {
                    dgvData.Rows.Add(PageSize - ds.Tables[0].Rows.Count);
                }
            }
            else
            {
                init();
            }

        }

        /// <summary>
        /// 获得查询条件
        /// </summary>
        private string GetConduction()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" 1=1 ");
            if (!string.IsNullOrEmpty(txtProductCode.Text.Trim()))
            {
                sb.AppendFormat("and PRODUCT_CODE = '{0}'", txtProductCode.Text.Trim());
            }

            if (!string.IsNullOrEmpty(txtWarehouseCode.Text.Trim()))
            {
                sb.AppendFormat("and WAREHOUSE_CODE = '{0}'", txtWarehouseCode.Text.Trim());
            }

            if (!string.IsNullOrEmpty(txtProduct_Group_Code.Text.Trim())) 
            {
                sb.AppendFormat("and PRODUCT_GROUP_CODE = '{0}'", txtProduct_Group_Code.Text.Trim());
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
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要关闭吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                this.Close();
            }
        }
        #endregion

        #region 按键顺序
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //System.Windows.Forms.SendKeys.Send("{Tab}");
                //ProcessTabKey(true);
                this.SelectNextControl(this.ActiveControl, true, true, true, false);
            }
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                //System.Windows.Forms.SendKeys.Send("+{Tab}");
                this.SelectNextControl(this.ActiveControl, false, true, true, false);
            }
            if (e.KeyCode == Keys.Down)
            {
                //System.Windows.Forms.SendKeys.Send("{Tab}");
                this.SelectNextControl(this.ActiveControl, true, true, true, false);
            }
        }

        private void btnSearch_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Resources.find;
        }

        private void btnSearch_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Resources.find_over;
        }
        #endregion

        #region 入库一览
        private void btnReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                string warehousecode = dgvData.SelectedRows[0].Cells["WAREHOUSE_CODE"].Value.ToString();
                string productcode = dgvData.SelectedRows[0].Cells["PRODUCT_CODE"].Value.ToString();
                if (warehousecode != null && productcode != null)
                {
                    FrmStockReView frm = new FrmStockReView();
                    frm.WAREHOUSE = warehousecode;
                    frm.PRODUCT = productcode;
                    frm.TYPE = CConstant.STOCK_RECEIVING_PLAN_LIST;
                    DialogResult resule = frm.ShowDialog(this);
                    frm.Enabled = false;
                    frm.Dispose();
                }
                else
                {
                    MessageBox.Show("请选择正确的行!");
                }
            }
            catch
            {
                MessageBox.Show("请选择正确的行!");
            }
        }
        #endregion

        #region 引当一览
        //private void btnAlloation_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string warehousecode = dgvData.SelectedRows[0].Cells["WAREHOUSE_CODE"].Value.ToString();
        //        string productcode = dgvData.SelectedRows[0].Cells["PRODUCT_CODE"].Value.ToString();
        //        if (warehousecode != null && productcode != null)
        //        {
        //            FrmStockReView frm = new FrmStockReView();
        //            frm.WAREHOUSE = warehousecode;
        //            frm.PRODUCT = productcode;
        //            frm.TYPE = CConstant.STOCK_ALLOATION_LIST;
        //            DialogResult resule = frm.ShowDialog(this);
        //            frm.Enabled = false;
        //            frm.Dispose();
        //        }
        //        else
        //        {
        //            MessageBox.Show("请选择正确的行!");
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("请先选择一行!");
        //    }

        //}
        #endregion

        #region 导出
        private void btnPrint_Click(object sender, EventArgs e)
        {
            _currentDt = bStock.GetStockPrintList(oldGetCondition).Tables[0];
            if (_currentDt.Rows.Count > 0 && isSearch)
            {
                int result = CExport.DataTableToExcel(_currentDt, CConstant.STOCK_HEADER, CConstant.STOCK_COLUMNS, "STOCK", "STOCK");
                if (result == CConstant.EXPORT_SUCCESS)
                {
                    MessageBox.Show("数据已经成功导出!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (result == CConstant.EXPORT_FAILURE)
                {
                    MessageBox.Show("数据导出失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region 货位的取得
        /// <summary>
        /// 
        /// </summary>
        private void initLocation() 
        {
            //if (!string.IsNullOrEmpty(txtWarehouseCode.Text.Trim()) && !string.IsNullOrEmpty(txtProductCode.Text.Trim()))
            //{
            //    BLocation bLocation = new BLocation();
            //    DataSet ds = bLocation.GetList(" WAREHOUSE_CODE='" + txtWarehouseCode.Text.Trim() + "' and PRODUCT_CODE='" + txtProductCode.Text.Trim() + "'");
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        txtProduct_Group_Code.Text = CConvert.ToString(ds.Tables[0].Rows[0]["CODE"]);
            //        txtProduct_Group_Name.Text = CConvert.ToString(ds.Tables[0].Rows[0]["NAME"]);
            //    }
            //}
            //else 
            //{
            //    txtProduct_Group_Code.Text = "";
            //    txtProduct_Group_Name.Text = "";
            //}
        }
        #endregion

        #region 种类
        private void btnProduct_Group_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("PRODUCT_GROUP", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtProduct_Group_Code.Text = frm.BaseMasterTable.Code;
                    txtProduct_Group_Name.Text = frm.BaseMasterTable.Name;
                    btnProduct_Group.Focus();
                }
            }
            frm.Dispose();
            //initLocation();
        }

        private void txtProduct_Group_Code_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtProduct_Group_Code.Text.Trim()))
            {
                BaseProductGroupTable product = new BaseProductGroupTable();
                BProductGroup bProduct = new BProductGroup();
                product = bProduct.GetModel(this.txtProduct_Group_Code.Text);
                if (product == null || "".Equals(product))
                {
                    txtProduct_Group_Code.Focus();
                    txtProduct_Group_Code.Text = "";
                    txtProduct_Group_Name.Text = "";
                    MessageBox.Show("商品种类不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtProduct_Group_Code.Text = product.CODE;
                    txtProduct_Group_Name.Text = product.NAME;
                }
            }
            else
            {
                txtProduct_Group_Name.Text = "";
            }
        }
        #endregion
    }
}
