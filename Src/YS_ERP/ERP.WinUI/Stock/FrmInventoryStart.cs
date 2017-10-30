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
using System.Collections;
using CZZD.ERP.Common;

namespace CZZD.ERP.WinUI
{
    public partial class FrmInventoryStart : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private BllInventoryTable _inventoryTable = new BllInventoryTable();
        private string slipnumber;
        private bool isSearch = false;
        private Hashtable hashtb = new Hashtable();
        private string status_flag;
        private DataTable _currentdt;

        public string SLIP_NUMBER
        {
            set { slipnumber = value; }
            get { return slipnumber; }
        }

        public BaseUserTable UserInfo
        {
            get { return _userInfo; }
            set { _userInfo = value; }
        }

        public string STATUS_FLAG
        {
            get { return status_flag;}
            set { status_flag = value; }
        }

        public FrmInventoryStart()
        {
            InitializeComponent();
        }

        private void FrmInventoryStart_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;

            if (slipnumber == null)
            {
                initSlipNumber();
                init();
                btnPrint.Text = "导出";
            }
            else if (status_flag == CConstant.INVENTORY_SEARCH)
            {
                setDatagridView(1);
                setStatus(false);
            }
            else if (status_flag == CConstant.INVENTORY_END)
            {
                btnPrint.Text = "盘点结束";
                setDatagridView(1);
                dgvData.Columns["TRUE_QUANTITY"].ReadOnly = false;
                dgvData.Columns["TRUE_QUANTITY"].DefaultCellStyle.BackColor = SystemColors.Info;
                
                setStatus(false);
            }
        }

        #region 订单编号初始化
        public void initSlipNumber()
        {
            string maxSlipNumber = bInventory.GetMaxSlipNumber();
            int number = Convert.ToInt32(maxSlipNumber) + 1;
            string slipNumber = number.ToString().PadLeft(4, '0');
            txtSlipNumber.Text = slipNumber;
        }
        #endregion

        #region dgvDate初始化
        public void init()
        {
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            PageSize = 14;
            dgvData.Rows.Add(PageSize);
            dgvData.Rows[0].Selected = true;
        }

        public void setDatagridView(int currentPage)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" SLIP_NUMBER like '{0}%'", slipnumber);
            _inventoryTable = bInventory.GetInventoryModel(slipnumber);
            DataSet ds = bInventory.GetEndInventoryList(sb.ToString(), "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);
            txtSlipNumber.Text = _inventoryTable.SLIP_NUMBER;
            txtStartDate.Value = _inventoryTable.START_DATE;
            txtWarehouseCode.Text = _inventoryTable.WAREHOUSE_CODE;
            txtWarehouseName.Text = bCommon.GetBaseMaster("WAREHOUSE", _inventoryTable.WAREHOUSE_CODE).Name;

            dgvData.Rows.Clear();
            foreach (DataRow rows in ds.Tables[0].Rows)
            {
                int currentRowIndex = dgvData.Rows.Add(1);
                DataGridViewRow row = dgvData.Rows[currentRowIndex];
                row.Cells[1].Selected = false;

                row.Cells["No"].Value = rows["LINE_NUMBER"];
                row.Cells["PRODUCT_CODE"].Value = rows["PRODUCT_CODE"];

                string code = rows["PRODUCT_CODE"].ToString();
                BaseProductTable productTable = bProduct.GetModel(code);
                if (productTable != null)
                {
                    row.Cells["SPEC"].Value = productTable.SPEC;
                    row.Cells["PRODUCT_NAME"].Value = productTable.NAME;
                }

                BaseStockTable stock = new BaseStockTable();
                stock = bPurchaseOrder.GetStockModel(rows["WAREHOUSE_CODE"].ToString(), rows["PRODUCT_CODE"].ToString());
                if (stock != null)
                {
                    row.Cells["STOCK_QUANTITY"].Value = rows["STOCK_QUANTITY"];
                    row.Cells["TRUE_QUANTITY"].Value = rows["TRUE_QUANTITY"];
                    row.Cells["OLD_TRUE_QUANTITY"].Value = rows["TRUE_QUANTITY"];
                    row.Cells["UNIT_NAME"].Value = bCommon.GetBaseMaster("UNIT", stock.UNIT_CODE).Name;
                }
            }

            if (ds.Tables[0].Rows.Count < 14 * currentPage)
            {
                dgvData.Rows.Add(14 - ds.Tables[0].Rows.Count);
            }

            this.Left = (int)((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2);
            this.Top = (int)((Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
        }

        private void setStatus(bool flag)
        {
            this.txtSlipNumber.Enabled = flag;
            this.txtStartDate.Enabled = flag;
            this.txtWarehouseCode.Enabled = flag;
            this.btnSearch.Enabled = flag;
            this.btnWarehouse.Enabled = flag;
            if (status_flag == CConstant.INVENTORY_SEARCH)
            {
                this.btnSave.Enabled = flag;
                this.btnPrint.Enabled = flag;
            }
        }
        #endregion

        #region 窗口关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要关闭吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                this.Close();
            }
        }
        #endregion

        /// <summary>
        ///　控制空行不能被点击
        /// </summary>
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

        #region 查询
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                int currentPage = 1;
                int recordCount = bInventory.GetStartRecordCount(txtWarehouseCode.Text.Trim());
                if (recordCount < 0)
                {
                    MessageBox.Show("查询的信息不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                isSearch = true;
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
            DataSet ds = bInventory.GetStartList(txtWarehouseCode.Text.Trim(), "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);
            _currentdt = ds.Tables[0];
            dgvData.Rows.Clear();

            if (_currentdt.Rows.Count > 0)
            {
                foreach (DataRow rows in ds.Tables[0].Rows)
                {
                    int currentRowIndex = dgvData.Rows.Add(1);
                    DataGridViewRow row = dgvData.Rows[currentRowIndex];
                    row.Cells[1].Selected = true;
                    row.Cells["No"].Value = rows["Row"];
                    row.Cells["PRODUCT_CODE"].Value = rows["PRODUCT_CODE"];
                    row.Cells["SPEC"].Value = rows["SPEC"];
                    row.Cells["PRODUCT_NAME"].Value = rows["PRODUCT_NAME"];
                    row.Cells["STOCK_QUANTITY"].Value = rows["QUANTITY"];
                    row.Cells["TRUE_QUANTITY"].Value = rows["QUANTITY"];
                    row.Cells["UNIT_NAME"].Value = rows["UNIT_NAME"];
                }
                if (ds.Tables[0].Rows.Count < PageSize * currentPage)
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
        /// 当前页码发生变化时的操作
        /// </summary>
        private void pgControl_PageChanged(object sender, EventArgs e, int currentPage)
        {
            //BindData(currentPage);
            if (slipnumber == null)
            {
                BindData(currentPage);
            }
            else 
            {
                setDatagridView(currentPage);
            }
            //else
            //{
            //    setDatagridView(currentPage);
            //}
        }

        public bool checkInput()
        {
            string strErrorlog = null;
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
                    btnSearch.Focus();
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

        #region 保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (slipnumber == null)
            {
                #region 开始保存
                if (isSearch && _currentdt.Rows.Count > 0)
                {
                    BllInventoryTable BITable = new BllInventoryTable();
                    BllInventoryLineTable BILTable = null;

                    BITable.SLIP_NUMBER = txtSlipNumber.Text.Trim();
                    BITable.START_DATE = txtStartDate.Value;
                    BITable.WAREHOUSE_CODE = txtWarehouseCode.Text.Trim();
                    BITable.CREATE_USER = _userInfo.CODE;
                    BITable.LAST_UPDATE_USER = _userInfo.CODE;

                    foreach (DataGridViewRow row in dgvData.Rows)
                    {
                        if (row.Cells["PRODUCT_CODE"].Value != null)
                        {
                            BILTable = new BllInventoryLineTable();
                            BILTable.SLIP_NUMBER = txtSlipNumber.Text.Trim();
                            BILTable.LINE_NUMBER = row.Index + 1;
                            BILTable.PRODUCT_CODE = row.Cells["PRODUCT_CODE"].Value.ToString();
                            BILTable.WAREHOUSE_CODE = txtWarehouseCode.Text.Trim();
                            BILTable.STOCK_QUANTITY = Convert.ToDecimal(row.Cells["STOCK_QUANTITY"].Value);
                            BILTable.TRUE_QUANTITY = Convert.ToDecimal(row.Cells["STOCK_QUANTITY"].Value);
                            BILTable.CREATE_USER = _userInfo.CODE;
                            BILTable.LAST_UPDATE_USER = _userInfo.CODE;

                            if (BILTable.SLIP_NUMBER != null)
                            {
                                BITable.AddItem(BILTable);
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                    int result = 0;
                    try
                    {
                        result = bInventory.AddInventory(BITable);
                        if (result <= 0)
                        {
                            string errorLog = "保存失败,请重试或与管理员联系.";
                            MessageBox.Show(errorLog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            dgvData.Rows.Clear();
                            initSlipNumber();
                            init();
                            txtWarehouseCode.Text = "";
                            txtWarehouseName.Text = "";
                            txtStartDate.Value = DateTime.Now;
                            MessageBox.Show("保存成功", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("保存失败,系统错误,请与管理员联系.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Logger.Error("盘点失败！", ex);
                    }
                }
                #endregion
            }
            else
            {
                #region 结束保存
                try
                {
                    if (hashtb.Count > 0)
                    {
                        int s = bInventory.UpdataInventory(slipnumber, hashtb, _userInfo.CODE, false);
                        if (s <= 0)
                        {
                            MessageBox.Show("保存失败!");
                        }
                        else
                        {
                            MessageBox.Show("保存成功!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                #endregion
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void dgvData_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dgvData.Rows[e.RowIndex];
                if (e.ColumnIndex == dgvData.Columns["TRUE_QUANTITY"].Index)
                {
                    if (CConvert.ToDecimal(dr.Cells["OLD_TRUE_QUANTITY"].Value) == CConvert.ToDecimal(dr.Cells["TRUE_QUANTITY"].Value))
                    {
                        hashtb.Remove(dr.Cells["PRODUCT_CODE"].Value);
                    }
                    else
                    {
                        hashtb.Add(dr.Cells["PRODUCT_CODE"].Value, dr.Cells["TRUE_QUANTITY"].Value);
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        #endregion

        #region btnPrint
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (slipnumber != null && status_flag == CConstant.INVENTORY_END)
            {
                try
                {
                    //if (hashtb.Count > 0)
                    //{
                    int s = bInventory.UpdataInventory(slipnumber, hashtb, _userInfo.CODE, true);
                    if (s <= 0)
                    {
                        MessageBox.Show("盘点失败!");
                    }
                    else
                    {
                        MessageBox.Show("盘点成功!");
                    }
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (slipnumber == null)
            {
                _currentdt = bInventory.GetStartPrintList(txtWarehouseCode.Text.Trim()).Tables[0];
                if (_currentdt.Rows.Count > 0 && isSearch)
                {
                    SaveFileDialog sf = new SaveFileDialog();
                    sf.FileName = "HD_INVENTORY_START_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
                    sf.Filter = "(文件)|*.xls;*.xlsx";

                    string header = "仓库编号\t仓库名称\t商品编号\t商品名称\t商品规格\t单位编号\t单位名称\t在库数\t实际在库数\t状态\t创建人\t创建时间\t最后更新人\t最后更新时间\t\n";
                    if (sf.ShowDialog(this) == DialogResult.OK)
                    {
                        if (_currentdt != null)
                        {
                            int result = CExport.DataTableToCsv(_currentdt, header, sf.FileName);
                            if (result == 0)
                            {
                                MessageBox.Show("成功!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
        }
        #endregion 
    }
}
