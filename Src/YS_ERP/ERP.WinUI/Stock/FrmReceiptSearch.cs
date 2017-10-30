using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Common;
using CZZD.ERP.Bll;
using CZZD.ERP.CacheData;
using CZZD.ERP.Model;

namespace CZZD.ERP.WinUI
{
    public partial class FrmReceiptSearch : FrmBase
    {
        private DataTable _currentDt = new DataTable();
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private bool isSearch = false;
        public FrmReceiptSearch()
        {
            InitializeComponent();
        }

        private void FrmReceiptSearch_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;

            #region dgvData初始化
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;

            PageSize = 14;
            dgvData.Rows.Add(PageSize);
            dgvData.Rows[0].Selected = true;
            #endregion

            #region 入库类型初始化
            DataTable pstDT = CCacheData.Receipt.Copy();
            DataRow dr = pstDT.NewRow();
            pstDT.Rows.InsertAt(dr, 0);
            dr["CODE"] = "";
            dr["NAME"] = "全部";
            cboReceipt.ValueMember = "CODE";
            cboReceipt.DisplayMember = "NAME";
            cboReceipt.DataSource = pstDT;
            #endregion
        }

        #region 查询

        private void btnSearch_Click(object sender, EventArgs e)
        {            
            int currentPage = 1;
            int recordCount = bRerceipt.GetSearchRecordCount(GetConduction());
            if (recordCount <= 0)
            {
                MessageBox.Show("查询的信息不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //分页标签初始化
            this.pgControl.init(GetTotalPage(recordCount), currentPage);
            //数据绑定
            BindData(currentPage);
            isSearch = true;           
        }

        /// <summary>
        /// 数据查询,绑定
        /// </summary>
        private void BindData(int currentPage)
        {
            string strWhere = GetConduction();
            DataSet ds = bRerceipt.GetSearchList(strWhere, "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);
            _currentDt = ds.Tables[0];
            reSetCurrentDt();
            this.dgvData.DataSource = _currentDt;
        }

        /// <summary>
        /// 获得查询条件
        /// </summary>
        private string GetConduction()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" STATUS_FLAG <> {0} ", CConstant.DELETE);
            sb.AppendFormat(" AND RECEIPT_FLAG like '{0}%'", cboReceipt.SelectedValue);

            if (txtSlipNumber.Text.Trim() != "")
            {
                sb.AppendFormat("and PO_SLIP_NUMBER like '{0}%'", txtSlipNumber.Text.Trim());
            }

            if (txtSupplierCode.Text.Trim() != "")
            {
                sb.AppendFormat("and SUPPLIER_CODE = '{0}'", txtSupplierCode.Text.Trim());
            }

            if (txtWarehouseCode.Text.Trim() != "")
            {
                sb.AppendFormat("and RECEIPT_WAREHOUSE_CODE = '{0}'", txtWarehouseCode.Text.Trim());
            }

            //采购日期From
            if (this.txtPOSlipDateFrom.Checked)
            {
                sb.AppendFormat(" AND PO_SLIP_DATE >= '{0}'", txtPOSlipDateFrom.Value.ToString("yyyy-MM-dd"));
            }
            //采购日期To
            if (this.txtPOSlipDateTo.Checked)
            {
                sb.AppendFormat(" AND PO_SLIP_DATE < '{0}'", txtPOSlipDateTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }
            //入库日期From
            if (this.txtReceiptDateFrom.Checked)
            {
                sb.AppendFormat(" AND RECEIPT_SLIP_DATE >= '{0}'", txtReceiptDateFrom.Value.ToString("yyyy-MM-dd"));
            }
            //入库日期To
            if (this.txtReceiptDateTo.Checked)
            {
                sb.AppendFormat(" AND RECEIPT_SLIP_DATE < '{0}'", txtReceiptDateTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
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

        /// <summary>
        /// 当前数据集的重新整理
        /// </summary>
        private void reSetCurrentDt()
        {
            for (int i = _currentDt.Rows.Count; i < PageSize; i++)
            {
                _currentDt.Rows.Add(_currentDt.NewRow());
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
                if (row.Cells["SLIP_NUMBER"].Value == null || "".Equals(row.Cells["SLIP_NUMBER"].Value.ToString()))
                {
                    row.Selected = false;
                }
            }
        }

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
        #endregion

        #region 供应商
        private void btnSupplier_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("Supplier", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtSupplierCode.Text = frm.BaseMasterTable.Code;
                    txtSupplierName.Text = frm.BaseMasterTable.Name;
                    txtWarehouseCode.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtSupplierCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtSupplierCode.Text.Trim()))
            {
                BaseSupplierTable SupplierCode = new BaseSupplierTable();
                BSupplier bSupplier = new BSupplier();
                SupplierCode = bSupplier.GetModel(txtSupplierCode.Text);
                if (SupplierCode == null)
                {
                    txtSupplierCode.Focus();
                    txtSupplierCode.Text = "";
                    txtSupplierName.Text = "";
                    MessageBox.Show("供应商编号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtSupplierName.Text = SupplierCode.NAME;
                }
            }
            else
            {
                txtSupplierCode.Text = "";
                txtSupplierName.Text = "";
            }
        }

        #endregion

        #region 入库仓库
        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("WAREHOUSE", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtWarehouseCode.Text = frm.BaseMasterTable.Code;
                    txtWarehouseName.Text = frm.BaseMasterTable.Name;
                    txtReceiptDateFrom.Focus();
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
                    MessageBox.Show("仓库编号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtWarehouseName.Text = Warehouse.NAME;
                }
            }
        }
        #endregion

        #region 导出
        private void btnPrint_Click(object sender, EventArgs e)
        {
            _currentDt = bRerceipt.GetPrintList(GetConduction()).Tables[0];
            if (_currentDt.Rows.Count > 0 && isSearch)
            {
                //SaveFileDialog sf = new SaveFileDialog();
                //sf.FileName = "LZ_RECEIPT_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
                //sf.Filter = "(文件)|*.xls;*.xlsx";

                //string header = "入库编号\t采购订单编号\t入库行号\t供应商编号\t供应商名称\t入库仓库编号\t入库仓库名称\t" +
                //                "公司编号\t公司名称\t货币编号\t货币名称\t商品编号\t商品名称\t采购数量\t入库预定数量\t入库数量\t" +
                //                "入库日期\t发票编号\t单位编号\t单位名称\t单价\t不含税金额\t税率\t税金\t含税金额\t明细状态\t创建人\t创建时间\t最后更新人\t最后更新时间\t\n";
                //if (sf.ShowDialog(this) == DialogResult.OK)
                //{
                //    if (_currentDt != null)
                //    {
                //        int result = CommonExport.DataTableToCsv(_currentDt, header, sf.FileName);
                //        if (result == 0)
                //        {
                //            MessageBox.Show("成功!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        }
                //    }
                //}
                int result = CExport.DataTableToExcel(_currentDt, CConstant.RECEIPT_HEADER, CConstant.RECEIPT_COLUMNS, "RECEIPT", "RECEIPT");
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

        #region 入库取消
        private void btnReceiptCancel_Click(object sender, EventArgs e)
        {
            if (isSearch && dgvData.SelectedRows.Count > 0)
            {
                DataGridViewRow dgvr = dgvData.SelectedRows[0];

                if (MessageBox.Show("确定要入库取消吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    //if (CConvert.ToInt32(dgvr.Cells["STATUS_FLAG"].Value) == CConstant.NORMAL_STATUS)
                    //{
                    //    MessageBox.Show("采购发票已开，不能进行入库取消。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    return;
                    //}

                    try
                    {
                        string slipNumber = CConvert.ToString(dgvData.SelectedRows[0].Cells["SLIP_NUMBER"].Value);
                        int flag = CConvert.ToInt32(dgvData.SelectedRows[0].Cells["RECEIPT_FLAG"].Value);
                        if (!string.IsNullOrEmpty(slipNumber))
                        {
                            int i = 0;
                            if (flag == 1)
                            {
                                i = bRerceipt.UnReceipt(slipNumber);
                            }
                            else
                            {
                                i = bRerceipt.DeleteOtherReceipt(slipNumber);
                            }
                            if (i < 0)
                            {
                                MessageBox.Show("入库订单取消失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                BindData(this.pgControl.GetCurrentPage());
                                MessageBox.Show("订单取消成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("入库订单取消失败,系统错误。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Logger.Error("入库订单取消失败,系统错误：", ex);
                    }
                }
            }
        }
   
        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dr = dgvData.Rows[e.RowIndex];
                if (e.ColumnIndex == dgvData.Columns["FROMSET"].Index)
                {
                    if (CConvert.ToString(dr.Cells["FROMSET"].Value) == "是")
                    {
                        string attachedDirectory = CCacheData.GetAttacheDirectory(CConstant.ATTACHE_DIRECTORY_PURCHASE);
                        string slipNumber = txtSlipNumber.Text;
                        string product = CConvert.ToString(dr.Cells["PRODUCT_CODE"].Value);
                        FrmPOAttached frm = null;
                        frm = new FrmPOAttached(dr.Cells["PO_SLIP_NUMBER"].Value.ToString(), dr.Cells["PRODUCT_CODE"].Value.ToString(), attachedDirectory, CConstant.PURCHASE_NEW);
                        frm.ShowDialog(this);
                        frm.Dispose();
                    }
                }
            }
        }
        #endregion

        #region　修改
        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                int flag = CConvert.ToInt32(dgvData.SelectedRows[0].Cells["RECEIPT_FLAG"].Value);
                if (flag == 1)
                {
                    MessageBox.Show("不能修改!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (flag == 2)
                {
                    string slipnumber = CConvert.ToString(dgvData.SelectedRows[0].Cells["SLIP_NUMBER"].Value);
                    FrmOtherReceipt frm = new FrmOtherReceipt();
                    frm.SLIP_NUMBER = slipnumber;
                    frm.USER = UserTable;
                    frm.ShowDialog(this);
                    frm.Dispose();
                    BindData(this.pgControl.GetCurrentPage());
                    slipnumber = "";
                }
            }
            catch(Exception ex)
            {
                
            }
        }
        #endregion
    }//end class
}
