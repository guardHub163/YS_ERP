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
    public partial class FrmStockAdjustmentSearch : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private DataTable _currentDt = new DataTable();
        private bool isSearch = false;

        public FrmStockAdjustmentSearch()
        {
            InitializeComponent();
        }

        private void FrmStockAdjustmentSearch_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;

            init();
            //slipDateFrom.Value = DateTime.Now.AddDays(1 - DateTime.Now.Day);
            //slipDateTo.Value = slipDateFrom.Value.AddMonths(1).AddDays(-1); 
        }

        #region dgvData 初始化
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
                    txtWarehouseCode.Text = Warehouse.CODE;
                    txtWarehouseName.Text = Warehouse.NAME;
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
                    MessageBox.Show("商品编号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtProductCode.Text = "";
                    txtProductName.Text = product.NAME;
                }
            }
            else
            {
                txtProductName.Text = "";
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

        #region 查询分页
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int currentPage = 1;
            int recordCount = bStock.GetRecordCount(GetConduction());
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

        /// <summary>
        /// 数据查询,绑定
        /// </summary>
        private void BindData(int currentPage)
        {
            string strWhere = GetConduction();
            DataSet ds = bStock.GetList(strWhere, "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);
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
            sb.AppendFormat(" STATUS_FLAG <> {0}", CConstant.DELETE);
            if (slipDateFrom.Checked)
            {
                sb.AppendFormat("and SLIP_DATE >= '{0}'", slipDateFrom.Value.ToShortDateString());
            }
            else if (slipDateTo.Checked)
            {
                sb.AppendFormat("and SLIP_DATE < '{0}'", slipDateTo.Value.AddDays(1).ToShortDateString());
            }
            if (txtProductCode.Text.Trim() != "")
            {
                sb.AppendFormat("and PRODUCT_CODE like '{0}%'", txtProductCode.Text.Trim());
            }

            if (txtWarehouseCode.Text.Trim() != "")
            {
                sb.AppendFormat("and WAREHOUSE_CODE like '{0}%'", txtWarehouseCode.Text.Trim());
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

        #region 导出
        private void btnPrint_Click(object sender, EventArgs e)
        {
            _currentDt = bStock.GetPrintList(GetConduction()).Tables[0];
            if (isSearch && _currentDt != null)
            {
                SaveFileDialog sf = new SaveFileDialog();
                sf.FileName = "HD_STOCK_ADJUSTMENT_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
                sf.Filter = "(文件)|*.xls;*.xlsx";
                
                string header = "修改编号\t修改日期\t修改明细行号\t商品编号\t商品名称\t仓库编号\t仓库名称\t单位编号\t单位名称\t" +
                               "处分数\t理由编号\t理由\t公司编号\t公司名称\t状态\t创建人\t创建时间\t最后更新人\t最后更新时间\t\n";
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
    }
}
