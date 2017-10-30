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
using CZZD.ERP.Bll;

namespace CZZD.ERP.WinUI
{
    public partial class FrmCProduceBOM : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private DataTable _currentDt = new DataTable();
        private BProduce bProduce = new BProduce();
        private DataTable _bomDt = new DataTable();
        private DataTable _purchasePlanDt = new DataTable();

        #region 页面初始化

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmCProduceBOM()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCProduceBOM_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;

            PageSize = 14;
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            initDgvData();

            #region 生产物料清单
            _bomDt.Columns.Add("序号", Type.GetType("System.String"));
            _bomDt.Columns.Add("规格/参数", Type.GetType("System.String"));
            _bomDt.Columns.Add("名称", Type.GetType("System.String"));
            _bomDt.Columns.Add("数量", Type.GetType("System.Decimal"));
            _bomDt.Columns.Add("备注", Type.GetType("System.String"));
            #endregion

            #region 采购清单用表结构
            _purchasePlanDt.Columns.Add("序号", Type.GetType("System.String"));
            _purchasePlanDt.Columns.Add("规格/参数", Type.GetType("System.String"));
            _purchasePlanDt.Columns.Add("名称", Type.GetType("System.String"));
            _purchasePlanDt.Columns.Add("需求数量", Type.GetType("System.Decimal"));
            _purchasePlanDt.Columns.Add("当前库存量", Type.GetType("System.Decimal"));
            _purchasePlanDt.Columns.Add("警戒库存量", Type.GetType("System.Decimal"));
            _purchasePlanDt.Columns.Add("己分配数量", Type.GetType("System.Decimal"));
            _purchasePlanDt.Columns.Add("采购未入库数量", Type.GetType("System.Decimal"));
            _purchasePlanDt.Columns.Add("建议采购数量", Type.GetType("System.Decimal"));
            #endregion

        }

        /// <summary>
        /// 数据结构的初始化
        /// </summary>
        private void initDgvData()
        {
            _currentDt.Rows.Clear();
            DataRow dr = null;
            for (int i = 0; i < PageSize; i++)
            {
                dr = _currentDt.NewRow();
                _currentDt.Rows.Add(dr);
            }
            dgvData.DataSource = _currentDt;
            dgvData.Columns["CHK"].Visible = false;
        }

        #endregion

        #region 输入验证,页面控制
        #region 客户
        /// <summary>
        /// 客户选择按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEndCustomer_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("CUSTOMER", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtEndCustomerCode.Text = frm.BaseMasterTable.Code;
                    txtEndCustomerName.Text = frm.BaseMasterTable.Name;
                }
            }
            frm.Dispose();
        }

        /// <summary>
        /// 客户输入验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEndCustomerCode_Leave(object sender, EventArgs e)
        {
            string endCustomerCode = txtEndCustomerCode.Text.Trim();
            if (endCustomerCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("CUSTOMER", endCustomerCode);
                if (baseMaster != null)
                {
                    txtEndCustomerCode.Text = baseMaster.Code;
                    txtEndCustomerName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("客户不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEndCustomerCode.Text = "";
                    txtEndCustomerName.Text = "";
                    txtEndCustomerCode.Focus();
                }
            }
            else
            {
                txtEndCustomerName.Text = "";
            }
        }
        #endregion

        #region 出库仓库
        /// <summary>
        /// 仓库选择按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    MessageBox.Show("出库仓库不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        /// <summary>
        /// 控制空行不能被选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Index >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.Row.Index];
                if ("".Equals(CConvert.ToString(row.Cells["SLIP_NUMBER"].Value)))
                {
                    row.Selected = false;
                }
            }
        }
        #endregion

        #endregion

        #region 查询
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string strWhere = GetConduction();
            BinData(strWhere);
        }

        private void BinData(string strWhere)
        {
            DataSet ds = bOrderHeader.GetList(strWhere);
            _currentDt = ds.Tables[0];
            reSetCurrentDt();
            if (_currentDt.Rows.Count > 0)
            {
                dgvData.Columns["CHK"].Visible = true;
                this.dgvData.DataSource = _currentDt;
            }
            else
            {
                initDgvData();
            }
        }

        /// <summary>
        /// 获得查询条件
        /// </summary>
        private string GetConduction()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" STATUS_FLAG <> {0}", CConstant.DELETE);
            sb.AppendFormat(" AND ISNULL(PRODUCE_FLAG, 1) <> {0}", CConstant.AUTO_PURCHASE_COMPLETED);
            sb.AppendFormat(" and VERIFY_FLAG = {0}", CConstant.VERIFY);
            //订单编号
            if (!string.IsNullOrEmpty(txtSlipNumber.Text.Trim()))
            {
                sb.AppendFormat(" AND SLIP_NUMBER = '{0}'", txtSlipNumber.Text.Trim());
                return sb.ToString();
            }
            //客户
            if (!string.IsNullOrEmpty(txtEndCustomerCode.Text.Trim()))
            {
                sb.AppendFormat(" AND ENDER_CUSTOMER_CODE = '{0}'", txtEndCustomerCode.Text.Trim());
            }
            //出库仓库
            if (!string.IsNullOrEmpty(txtWarehouseCode.Text.Trim()))
            {
                sb.AppendFormat(" AND DEPARTUAL_WAREHOUSE_CODE = '{0}'", txtWarehouseCode.Text.Trim());
            }
            //本社订单编号
            if (!string.IsNullOrEmpty(txtOwnerPoNumber.Text.Trim()))
            {
                sb.AppendFormat(" AND OWNER_PO_NUMBER = '{0}'", txtOwnerPoNumber.Text.Trim());
            }
            //合同编号
            if (!string.IsNullOrEmpty(txtCustomerPoNumber.Text.Trim()))
            {
                sb.AppendFormat(" AND CUSTOMER_PO_NUMBER = '{0}'", txtCustomerPoNumber.Text.Trim());
            }
            //订单日期From
            if (this.txtSlipDateFrom.Checked)
            {
                sb.AppendFormat(" AND SLIP_DATE >= '{0}'", txtSlipDateFrom.Value.ToString("yyyy-MM-dd"));
            }
            //订单日期To
            if (this.txtSlipDateTo.Checked)
            {
                sb.AppendFormat(" AND SLIP_DATE < '{0}'", txtSlipDateTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }
            //出库预定日期From
            if (this.txtDepartualDateFrom.Checked)
            {
                sb.AppendFormat(" AND DEPARTUAL_DATE >= '{0}'", txtDepartualDateFrom.Value.ToString("yyyy-MM-dd"));
            }
            //出库预定日期To
            if (this.txtDepartualDateTo.Checked)
            {
                sb.AppendFormat(" AND DEPARTUAL_DATE < '{0}'", txtDepartualDateTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }
            return sb.ToString();
        }


        /// <summary>
        /// 当前数据集的重新整理
        /// </summary>
        private void reSetCurrentDt()
        {
            for (int i = 0; i < _currentDt.Rows.Count; i++)
            {
                _currentDt.Rows[i]["No"] = i + 1;
            }
        }

        #endregion

        #region 　页面操作导出等
        /// <summary>
        /// 详细信息
        /// </summary>
        private void btnOperate_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvData.SelectedRows[0];
                string slipNumber = CConvert.ToString(row.Cells["SLIP_NUMBER"].Value);
                FrmBase frm = new FrmOrdersEntry(slipNumber);
                frm.CTag = CConstant.ORDER_SEARCH;
                frm.UserTable = _userInfo;
                if (DialogResult.OK == frm.ShowDialog())
                {

                }
                frm.Dispose();
            }
            else
            {
                MessageBox.Show("请先选择一张订单。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 页面关闭
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 生产物料清单
        /// </summary>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            string slipNumbers = "";
            foreach (DataGridViewRow dr in dgvData.Rows)
            {
                if (CConvert.ToBoolean(dr.Cells["CHK"].Value))
                {
                    slipNumbers += "'" + CConvert.ToString(dr.Cells["SLIP_NUMBER"].Value) + "',";
                }
            }
            if (slipNumbers.Length > 0)
            {
                slipNumbers = slipNumbers.Substring(0, slipNumbers.Length - 1);
            }
            else
            {
                MessageBox.Show("请先选择订单。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog sf = new SaveFileDialog();
            sf.FileName = "HD_BOM_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            sf.Filter = "(文件)|*.xls;*.xlsx";

            if (sf.ShowDialog(this) == DialogResult.OK)
            {
                DataTable dt = bProduce.GetBomList(slipNumbers).Tables[0];
                int i = 1;
                _bomDt.Rows.Clear();
                DataRow dr = null;
                foreach (DataRow row in dt.Rows)
                {
                    dr = _bomDt.NewRow();
                    dr["序号"] = i++;
                    dr["规格/参数"] = row["CODE"];
                    dr["名称"] = row["NAME"];
                    dr["数量"] = CConvert.ToDecimal(row["QUANTITY"]);
                    dr["备注"] = "";
                    _bomDt.Rows.Add(dr);
                }
                CExport.DataTableToExcel_BOM(sf.FileName, _bomDt);
                MessageBox.Show("导出完成。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region 自动采购
        /// <summary>
        /// 自动采购
        /// </summary>
        private void btnAutoPurchase_Click(object sender, EventArgs e)
        {
            //string slipNumbers = "";
            ////订单编号的取得
            //foreach (DataGridViewRow dr in dgvData.Rows)
            //{
            //    if (CConvert.ToBoolean(dr.Cells["CHK"].Value))
            //    {
            //        slipNumbers += "'" + CConvert.ToString(dr.Cells["SLIP_NUMBER"].Value) + "',";
            //    }
            //}
            //if (slipNumbers.Length > 0)
            //{
            //    slipNumbers = slipNumbers.Substring(0, slipNumbers.Length - 1);
            //}
            //else
            //{
            //    MessageBox.Show("请先选择订单。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            ////采购清单的取得
            //DataTable poDt = bProduce.GetAutoPurchaseList(slipNumbers, rdoNetPurchase.Checked).Tables[0];
            ////数据的整理

            //List<BllPurchaseOrderTable> poList = new List<BllPurchaseOrderTable>();
            //BllPurchaseOrderTable poTable = null;
            //BllPurchaseOrderLineTable polTable = null;
            //DateTime currentTime = DateTime.Now;
            //decimal total = 0;
            //int i = 1;

            //string currentSupplier = "";
            //foreach (DataRow row in poDt.Rows)
            //{

            //    if ("".Equals(currentSupplier) || !currentSupplier.Equals(row["BASIC_SUPPLIER"]))
            //    {
            //        if (!"".Equals(currentSupplier))
            //        {
            //            poTable.TOTAL_AMOUNT = total;
            //            poList.Add(poTable);
            //            total = 0;
            //            i = 1;
            //        }
            //        poTable = new BllPurchaseOrderTable();
            //        poTable.SLIP_TYPE = CConstant.SEQ_PURCHASE_ORDER;
            //        poTable.SLIP_DATE = currentTime;
            //        poTable.DUE_DATE = currentTime.AddDays(CConstant.DEFAULE_LEAD_TIME);
            //        poTable.SUPPLIER_CODE = CConvert.ToString(row["BASIC_SUPPLIER"]);
            //        poTable.ORDER_SLIP_NUMBER = "";
            //        poTable.SUPPLIER_ORDER_NUMBER = "";
            //        poTable.CURRENCY_CODE = CConstant.DEFAULE_CURRENCY_CODE;
            //        poTable.TAX_RATE = CConstant.DEFAULE_RATE;
            //        poTable.RECEIPT_WAREHOUSE_CODE = CConstant.DEFAULE_WAREHOUSE_CODE;
            //        poTable.STATUS_FLAG = CConstant.INIT_STATUS;
            //        poTable.CREATE_USER = _userInfo.CODE;
            //        poTable.LAST_UPDATE_USER = _userInfo.CODE;
            //        poTable.COMPANY_CODE = _userInfo.COMPANY_CODE;
            //    }

            //    currentSupplier = CConvert.ToString(row["BASIC_SUPPLIER"]);

            //    polTable = new BllPurchaseOrderLineTable();
            //    polTable.LINE_NUMBER = i++;
            //    polTable.PRODUCT_CODE = CConvert.ToString(row["PRODUCT_CODE"]);
            //    polTable.QUANTITY = CConvert.ToDecimal(row["QUANTITY"]);
            //    polTable.UNIT_CODE = CConvert.ToString(row["BASIC_UNIT_CODE"]);
            //    polTable.PRICE = CConvert.ToDecimal(row["PURCHASE_PRICE"]);
            //    polTable.AMOUNT_WITHOUT_TAX = polTable.QUANTITY * polTable.PRICE;
            //    polTable.TAX_AMOUNT = CConvert.ToDecimal(poTable.TAX_RATE) * polTable.AMOUNT_WITHOUT_TAX;
            //    polTable.AMOUNT_INCLUDED_TAX = polTable.AMOUNT_WITHOUT_TAX + polTable.TAX_AMOUNT;
            //    polTable.STATUS_FLAG = CConstant.INIT_STATUS;
            //    total += polTable.AMOUNT_INCLUDED_TAX;
            //    poTable.TOTAL_AMOUNT = total;

            //    poTable.AddItem(polTable);
            //}

            //if (poTable != null)
            //{
            //    poList.Add(poTable);
            //}
            ////订单分组采购清单的取得，用于记录本次采购的原材料数量

            //DataTable historyDt = bProduce.GetAutoPurchaseList(slipNumbers).Tables[0];

            //List<BllOrderLineProductPartsTable> olppList = new List<BllOrderLineProductPartsTable>();
            //BllOrderLineProductPartsTable olppTable = null;
            //foreach (DataRow dr in historyDt.Rows)
            //{
            //    olppTable = new BllOrderLineProductPartsTable();
            //    olppTable.ORDER_SLIP_NUMBER = CConvert.ToString(dr["SLIP_NUMBER"]);
            //    olppTable.PRODUCT_CODE = CConvert.ToString(dr["PRODUCT_CODE"]);
            //    olppTable.QUANTITY = CConvert.ToDecimal(dr["QUANTITY"]);
            //    olppTable.STATUS_FLAG = CConstant.INIT_STATUS;
            //    olppTable.CREATE_USER = _userInfo.CODE;
            //    olppTable.LAST_UPDATE_USER = _userInfo.CODE;

            //    olppList.Add(olppTable);
            //}


            ////数据保存
            //try
            //{
            //    if (bPurchaseOrder.AutoPurchase(poList, olppList, slipNumbers) > 0)
            //    {
            //        MessageBox.Show("自动采购成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        btnSearch_Click(null, EventArgs.Empty);
            //    }
            //    else
            //    {
            //        MessageBox.Show("自动采购失败,请重试或与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("自动采购失败,请重试或与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    Logger.Error("自动采购失败。", ex);
            //}
        }
        #endregion

        private string GetSelectSlipNumbers()
        {
            string slipNumbers = "";
            //订单编号的取得
            foreach (DataGridViewRow dr in dgvData.Rows)
            {
                if (CConvert.ToBoolean(dr.Cells["CHK"].Value))
                {
                    slipNumbers += "'" + CConvert.ToString(dr.Cells["SLIP_NUMBER"].Value) + "',";
                }
            }
            if (slipNumbers.Length > 0)
            {
                slipNumbers = slipNumbers.Substring(0, slipNumbers.Length - 1);
            }
            else
            {
                MessageBox.Show("请先选择订单。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return slipNumbers;
        }

        /// <summary>
        /// 采购清单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPurchaseList_Click(object sender, EventArgs e)
        {
            string slipNumbers = "";
            foreach (DataGridViewRow dr in dgvData.Rows)
            {
                if (CConvert.ToBoolean(dr.Cells["CHK"].Value))
                {
                    slipNumbers = CConvert.ToString(dr.Cells["SLIP_NUMBER"].Value) + ",";
                }
            }
            if (slipNumbers.Length > 0)
            {
                slipNumbers = slipNumbers.Substring(0, slipNumbers.Length - 1);
            }
            else
            {
                MessageBox.Show("请先选择订单。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog sf = new SaveFileDialog();
            sf.FileName = "HD_PURCHASE_PLAN_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            sf.Filter = "(文件)|*.xls;*.xlsx";

            if (sf.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        #endregion


    }//end class
}
