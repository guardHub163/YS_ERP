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
    public partial class FrmProductBuild : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private int possible = 0;
        private string _slip_number;
        private BCommon bCommon = new BCommon();
        private int status;
        private DataTable _currentDt = new DataTable();
        private bool isSearch = false;

        public string SLIP_NUMBER
        {
            set { _slip_number = value; }
            get { return _slip_number; }
        }

        public int STATUS
        {
            set { status = value; }
            get { return status; }
        }

        public FrmProductBuild()
        {
            InitializeComponent();
        }

        private void FrmProductBuild_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;
            if (string.IsNullOrEmpty(_slip_number))
            {
                init();
            }
            else if (status == CConstant.BUILD_STATUS)
            {
                init();
                OperateInit(1);
                setStatus(false);

                this.Left = (int)((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2);
                this.Top = (int)((Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
            }
            else if (status == CConstant.RELIEVE_STATUS)
            {
                init();
                OperateInit(1);
                setStatus(false);

                label10.Text = "解除数量";
                label12.Text = "解除可能数";
                this.dgvData.Columns[5].HeaderText = "解除数量";
                this.Left = (int)((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2);
                this.Top = (int)((Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
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

        #region 详细
        public void OperateInit(int currentPage)
        {
            BllProductBuildTable PBModel = bProductBuild.GetModel(_slip_number);
            txtWarehouse.Text = PBModel.WAREHOUSE_CODE;
            txtWarehouseName.Text = bCommon.GetBaseMaster("WAREHOUSE", PBModel.WAREHOUSE_CODE).Name;
            txtProduct.Text = PBModel.PRODUCT_CODE;
            txtProductName.Text = bCommon.GetBaseMaster("PRODUCT", PBModel.PRODUCT_CODE).Name;
            txtQuantity.Text = CConvert.ToString(PBModel.QUANTITY);
            txtPossibleQuantity.Text = CConvert.ToString(PBModel.QUANTITY);
            txtFormDate.Value = PBModel.BUILD_DATE;

            dgvData.Rows.Clear();
            //foreach (BllProductBuildLineTable LModel in PBModel.Items)
            //{
            //    int currentRowIndex = dgvData.Rows.Add(1);
            //    DataGridViewRow row = dgvData.Rows[currentRowIndex];
            //    row.Cells[1].Selected = false;
            //    row.Cells["No"].Value = LModel.LINE_NUMBER;
            //    row.Cells["PARTS_CODE"].Value = LModel.PRODUCT_PARTS_CODE;

            //    BaseProductTable product = new BaseProductTable();
            //    BProduct bProduct = new BProduct();
            //    product = bProduct.GetModel(LModel.PRODUCT_PARTS_CODE);
            //    row.Cells["PARTS_NAME"].Value = product.NAME;
            //    row.Cells["SPEC"].Value = product.SPEC;

            //    BAlloation bAlloation = new BAlloation();
            //    decimal alloationQuantity = bAlloation.GetAlloationQuantity(PBModel.WAREHOUSE_CODE, LModel.PRODUCT_PARTS_CODE);
            //    BaseStockTable stock = new BaseStockTable();
            //    stock = bPurchaseOrder.GetStockModel(PBModel.WAREHOUSE_CODE, LModel.PRODUCT_PARTS_CODE);
            //    row.Cells["NO_ALLOATION"].Value = stock.QUANTITY - alloationQuantity;
            //    row.Cells["UNIT_CODE"].Value = PBModel.UNIT_CODE;
            //    row.Cells["UNIT_NAME"].Value = bCommon.GetBaseMaster("UNIT", PBModel.UNIT_CODE).Name;

            //    row.Cells["PURCHASE_QUANTITY"].Value = LModel.PARTS_QUANTITY;

            //    row.Cells["STATUE_FLAG"].Value = "OK";
                
            //}
            for (int i = (currentPage - 1) * PageSize + 1; i <= PBModel.Items.Count && (i - (currentPage - 1) * PageSize) < PageSize; i++)
            {
                int currentRowIndex = dgvData.Rows.Add(1);
                DataGridViewRow row = dgvData.Rows[currentRowIndex];
                row.Cells[1].Selected = false;
                row.Cells["No"].Value = PBModel.Items[i-1].LINE_NUMBER;
                row.Cells["PARTS_CODE"].Value = PBModel.Items[i - 1].PRODUCT_PARTS_CODE;
                row.Cells["MIN_QUANTITY"].Value = PBModel.Items[i - 1].PARTS_QUANTITY / PBModel.QUANTITY;
                BaseProductTable product = new BaseProductTable();
                BProduct bProduct = new BProduct();
                product = bProduct.GetModel(PBModel.Items[i - 1].PRODUCT_PARTS_CODE);
                row.Cells["PARTS_NAME"].Value = product.NAME;
                row.Cells["SPEC"].Value = product.SPEC;

                BAlloation bAlloation = new BAlloation();
                decimal alloationQuantity = bAlloation.GetAlloationQuantity(PBModel.WAREHOUSE_CODE, PBModel.Items[i - 1].PRODUCT_PARTS_CODE);
                BaseStockTable stock = new BaseStockTable();
                stock = bPurchaseOrder.GetStockModel(PBModel.WAREHOUSE_CODE, PBModel.Items[i - 1].PRODUCT_PARTS_CODE);
                row.Cells["NO_ALLOATION"].Value = stock.QUANTITY - alloationQuantity;
                row.Cells["UNIT_CODE"].Value = PBModel.UNIT_CODE;
                row.Cells["UNIT_NAME"].Value = bCommon.GetBaseMaster("UNIT", PBModel.UNIT_CODE).Name;

                row.Cells["PURCHASE_QUANTITY"].Value = PBModel.Items[i - 1].PARTS_QUANTITY;

                row.Cells["STATUE_FLAG"].Value = "OK";
            }

            if (PBModel.Items.Count < PageSize * currentPage)
            {
                dgvData.Rows.Add(PageSize - PBModel.Items.Count);
            }
        }

        public void setStatus(bool flag)
        {
            txtWarehouse.Enabled = flag;
            txtProduct.Enabled = flag;
            txtQuantity.Enabled = flag;
            txtFormDate.Enabled = flag;
            btnSearch.Enabled = flag;
            btnSave.Enabled = flag;
            btnPrint.Enabled = flag;
            btnWarehouse.Enabled = flag;
            btnProduct.Enabled = flag;
        }
        #endregion

        private void txtOwnerPoNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtQuantity.Focused || txtPossibleQuantity.Focused)
            {
                if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
                {
                    e.Handled = true;
                }
            }
        }

        #region 出库仓库
        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("WAREHOUSE", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtWarehouse.Text = frm.BaseMasterTable.Code;
                    txtWarehouseName.Text = frm.BaseMasterTable.Name;
                    txtQuantity.Focus();
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
            string warehouseCode = txtWarehouse.Text.Trim();
            if (warehouseCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("WAREHOUSE", warehouseCode);
                if (baseMaster != null)
                {
                    txtWarehouse.Text = baseMaster.Code;
                    txtWarehouseName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("出库仓库不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtWarehouse.Text = "";
                    txtWarehouseName.Text = "";
                    txtWarehouse.Focus();
                }
            }
            else
            {
                txtWarehouseName.Text = "";
            }

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
                    txtProduct.Text = frm.BaseMasterTable.Code;
                    txtProductName.Text = frm.BaseMasterTable.Name;
                    txtProduct.Focus();
                    txtQuantity.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtProductCode_Leave(object sender, EventArgs e)
        {
            string product = txtProduct.Text.Trim();
            if (product != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("PRODUCT", product);
                if (baseMaster != null)
                {
                    txtProduct.Text = baseMaster.Code;
                    txtProductName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("仓库编号不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtProduct.Text = "";
                    txtProductName.Text = "";
                    txtProduct.Focus();
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
            if (MessageBox.Show("确定要关闭吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                this.Close();
            }
        }
        #endregion

        #region 查询
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                Search(1);
                txtPossibleQuantity.Text = CConvert.ToString(possible);
                isSearch = true;
            }
        }

        public bool checkInput()
        {
            string strErrorlog = null;
            //判断仓库编号不能为空
            if (string.IsNullOrEmpty(this.txtWarehouse.Text.Trim()))
            {
                strErrorlog += "仓库编号不能为空!\r\n";
            }
            //判断组成品编号不能为空
            if (string.IsNullOrEmpty(this.txtProduct.Text.Trim()))
            {
                strErrorlog += "组成品编号不能为空!\r\n";
            }
            //数量不能为空
            if (string.IsNullOrEmpty(this.txtQuantity.Text.Trim()))
            {
                strErrorlog += "组成数量不能为空!\r\n";
            }

            if (strErrorlog != null || "".Equals(strErrorlog))
            {
                MessageBox.Show(strErrorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        public void Search(int currentPage)
        {
            int recordCount = bProductBuild.GetBuildRecordCount(GetConduction());
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
            DataSet ds = bProductBuild.GetBilldList(strWhere, "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);

            dgvData.Rows.Clear();
            
            foreach (DataRow rows in ds.Tables[0].Rows)
            {
                int currentRowIndex = dgvData.Rows.Add(1);
                DataGridViewRow row = dgvData.Rows[currentRowIndex];

                row.Cells[1].Selected = false;
                row.Cells["No"].Value = rows["Row"];
                row.Cells["PARTS_CODE"].Value = rows["PRODUCT_PART_CODE"];
                row.Cells["MIN_QUANTITY"].Value = rows["QUANTITY"];
                row.Cells["PARTS_NAME"].Value = rows["PRODUCT_PART_NAME"];
                row.Cells["SPEC"].Value = rows["SPEC"];
                row.Cells["UNIT_CODE"].Value = rows["UNIT_CODE"];
                row.Cells["UNIT_NAME"].Value = rows["UNIT_NAME"];

                //BAlloation bAlloation = new BAlloation();
                decimal alloationQuantity = bAlloation.GetAlloationQuantity(txtWarehouse.Text.Trim(), CConvert.ToString(rows["PRODUCT_PART_CODE"]));
                BaseStockTable stock = new BaseStockTable();
                stock = bPurchaseOrder.GetStockModel(txtWarehouse.Text.Trim(), CConvert.ToString(rows["PRODUCT_PART_CODE"]));
                row.Cells["NO_ALLOATION"].Value = stock.QUANTITY - alloationQuantity;


                row.Cells["PURCHASE_QUANTITY"].Value = CConvert.ToDecimal(rows["QUANTITY"]) * CConvert.ToDecimal(txtQuantity.Text.Trim());

                if (CConvert.ToDecimal(row.Cells["NO_ALLOATION"].Value) >= CConvert.ToDecimal(row.Cells["PURCHASE_QUANTITY"].Value))
                {
                    row.Cells["STATUE_FLAG"].Value = "OK";
                }
                else
                {
                    row.Cells["STATUE_FLAG"].Value = "NG";
                }
                double p = Convert.ToDouble(CConvert.ToDecimal(row.Cells["NO_ALLOATION"].Value) / CConvert.ToDecimal(row.Cells["MIN_QUANTITY"].Value));
                int old = (int)Math.Floor(p);
                if (CConvert.ToInt32(rows["Row"]) == 1)
                {
                    possible = old;
                }
                else if (possible >= old)
                {
                    possible = old;
                }
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
            if (!string.IsNullOrEmpty(txtProduct.Text.Trim()))
            {
                sb.AppendFormat("and PRODUCT_CODE = '{0}'", txtProduct.Text.Trim());
            }
            return sb.ToString();
        }

        /// <summary>
        /// 当前页码发生变化时的操作
        /// </summary>
        private void pgControl_PageChanged(object sender, EventArgs e, int currentPage)
        {
            if (string.IsNullOrEmpty(_slip_number))
            {
                BindData(currentPage);
            }
            else
            {
                OperateInit(currentPage);
            }
        }

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
                if ("".Equals(CConvert.ToString(row.Cells["PARTS_CODE"].Value)))
                {
                    row.Selected = false;
                }
            }
        }
        #endregion

        #region 保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isSearch)
            {
                if (saveCheck())
                {
                    BllProductBuildTable PBModel = new BllProductBuildTable();
                    BllProductBuildLineTable PBLModel = null;

                    //组成编号
                    PBModel.SLIP_NUMBER = CConvert.ToString(CConvert.ToInt32(bProductBuild.GetBuildMaxSlipNumber()) + 1).PadLeft(4, '0');
                    //仓库
                    PBModel.WAREHOUSE_CODE = txtWarehouse.Text.Trim();
                    PBModel.PRODUCT_CODE = txtProduct.Text.Trim();
                    PBModel.QUANTITY = CConvert.ToDecimal(txtQuantity.Text.Trim());
                    PBModel.BUILD_DATE = txtFormDate.Value;
                    PBModel.COMPANY_CODE = _userInfo.COMPANY_CODE;

                    BaseStockTable stock = new BaseStockTable();
                    stock = bPurchaseOrder.GetStockModel(txtWarehouse.Text.Trim(), txtProduct.Text.Trim());
                    PBModel.UNIT_CODE = stock.UNIT_CODE;
                    PBModel.STATUS_FLAG = CConstant.BUILD_STATUS;
                    PBModel.CREATE_USER = _userInfo.CODE;
                    PBModel.LAST_UPDATE_USER = _userInfo.CODE;

                    foreach (DataGridViewRow row in dgvData.Rows)
                    {
                        if (row.Cells["PARTS_CODE"].Value != null)
                        {
                            PBLModel = new BllProductBuildLineTable();
                            PBLModel.SLIP_NUMBER = PBModel.SLIP_NUMBER;
                            PBLModel.LINE_NUMBER = row.Index + 1;
                            PBLModel.PRODUCT_PARTS_CODE = CConvert.ToString(row.Cells["PARTS_CODE"].Value);
                            PBLModel.PARTS_QUANTITY = CConvert.ToDecimal(row.Cells["MIN_QUANTITY"].Value) * PBModel.QUANTITY;
                            PBLModel.UNIT_CODE = CConvert.ToString(row.Cells["UNIT_CODE"].Value);
                            PBLModel.STATUS_FLAG = CConstant.INIT;
                            if (PBLModel.SLIP_NUMBER != null)
                            {
                                PBModel.AddItem(PBLModel);
                            }
                        }
                    }

                    int result = 0;
                    try
                    {
                        result = bProductBuild.AddBuild(PBModel);
                        if (result <= 0)
                        {
                            string errorLog = "保存失败,请重试或与管理员联系.";
                            MessageBox.Show(errorLog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            dgvData.Rows.Clear();
                            init();
                            txtWarehouse.Text = "";
                            txtWarehouseName.Text = "";
                            txtProduct.Text = "";
                            txtProductName.Text = "";
                            txtQuantity.Text = "";
                            txtPossibleQuantity.Text = "";
                            txtFormDate.Value = DateTime.Now;
                            MessageBox.Show("保存成功", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("保存失败,系统错误,请与管理员联系.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Logger.Error("组成失败！", ex);
                    }
                }
            }
        }

        // 保存前的验证
        public bool saveCheck()
        {
            if (CConvert.ToDecimal(txtQuantity.Text.Trim()) > CConvert.ToDecimal(txtPossibleQuantity.Text.Trim()))
            {
                txtQuantity.Text = txtPossibleQuantity.Text.Trim();
            }
            if (CConvert.ToDecimal(txtPossibleQuantity.Text.Trim()) == 0)
            {
                MessageBox.Show("材料库存不够!");
                return false;
            }
            return true;
        }
        #endregion

        #region 导出
        private void btnPrint_Click(object sender, EventArgs e)
        {
            _currentDt = bProductBuild.GetBuildPrintList(GetConduction()).Tables[0];
            _currentDt.Columns.Add("PURCHASE_QUANTITY");
            _currentDt.Columns.Add("NO_ALLOATION");
            _currentDt.Columns.Add("STATUE_FLAG");

            foreach (DataRow rows in _currentDt.Rows)
            {
                rows["PURCHASE_QUANTITY"] = CConvert.ToDecimal(rows["QUANTITY"]) * CConvert.ToDecimal(txtQuantity.Text.Trim());
                decimal alloationQuantity = bAlloation.GetAlloationQuantity(txtWarehouse.Text.Trim(), CConvert.ToString(rows["PRODUCT_PART_CODE"]));
                BaseStockTable stock = new BaseStockTable();
                stock = bPurchaseOrder.GetStockModel(txtWarehouse.Text.Trim(), CConvert.ToString(rows["PRODUCT_PART_CODE"]));
                rows["NO_ALLOATION"] = stock.QUANTITY - alloationQuantity;
                if (CConvert.ToDecimal(rows["NO_ALLOATION"]) >= CConvert.ToDecimal(rows["PURCHASE_QUANTITY"]))
                {
                    rows["STATUE_FLAG"] = "OK";
                }
                else
                {
                    rows["STATUE_FLAG"] = "NG";
                }
            }
            if (_currentDt.Rows.Count > 0 && isSearch)
            {
                SaveFileDialog sf = new SaveFileDialog();
                sf.FileName = "HD_BUILD_PRINT_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
                sf.Filter = "(文件)|*.xls;*.xlsx";

                string header = "组成品编号\t组成品名称\t材料编号\t材料名称\t材料规格\t单位编号\t单位名称\t最小构成数量\t需求数量\t未引当数量\t状况\t\n";
                if (sf.ShowDialog(this) == DialogResult.OK)
                {
                    if (_currentDt != null)
                    {
                        int result = CExport.DataTableToCsv(_currentDt, header, sf.FileName);
                        if (result == 0)
                        {
                            MessageBox.Show("成功!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }
        #endregion
    }//end class
}
