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
    public partial class FrmProductBuildSearch : FrmBase
    {
        private DataTable _currentDt = new DataTable();
        private bool isSearch = false;

        public FrmProductBuildSearch()
        {
            InitializeComponent();
        }

        private void FrmProductBuildSearch_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;

            init();
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

        #region 材料
        private void btnProductParts_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("PRODUCT", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtProductParts.Text = frm.BaseMasterTable.Code;
                    txtProductPartsName.Text = frm.BaseMasterTable.Name;
                    txtProduct.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtProductParts_Leave(object sender, EventArgs e)
        {
            string partsCode = txtProductParts.Text.Trim();
            if (partsCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("PRODUCT", partsCode);
                if (baseMaster != null)
                {
                    txtProductParts.Text = baseMaster.Code;
                    txtProductPartsName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("出库仓库不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtProductParts.Text = "";
                    txtProductPartsName.Text = "";
                    txtProduct.Focus();
                }
            }
            else
            {
                txtProductPartsName.Text = "";
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
            if (SearchCheck())
            {
                int currentPage = 1;
                int recordCount = bProductBuild.GetBuildSearchRecordCount(GetConduction());
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

        public bool SearchCheck()
        {
            bool check = true;
            if (txtFormDateFrom.Checked && txtFormDateTo.Checked && (txtFormDateFrom.Value > txtFormDateTo.Value))
            {
                check = false;
                MessageBox.Show("组成日期范围错误!");
            }
            return check;
        }

        /// <summary>
        /// 数据查询,绑定
        /// </summary>
        private void BindData(int currentPage)
        {
            string strWhere = GetConduction();
            DataSet ds = bProductBuild.GetBuildSearchList(strWhere, "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);
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
            sb.AppendFormat(" STATUS_FLAG <> {0}", CConstant.RELIEVE_STATUS);
            if (!string.IsNullOrEmpty(txtWarehouse.Text.Trim()))
            {
                sb.AppendFormat(" and WAREHOUSE_CODE = '{0}'", txtWarehouse.Text.Trim());
            }

            if (txtFormDateFrom.Checked && txtFormDateTo.Checked)
            {
                sb.AppendFormat(" and BUILD_DATE between '{0}' and '{1}'", txtFormDateFrom.Value.ToShortDateString(), txtFormDateTo.Value.AddDays(1).ToShortDateString());
            }

            if (!string.IsNullOrEmpty(txtProduct.Text.Trim()))
            {
                sb.AppendFormat(" and PRODUCT_CODE = '{0}'", txtProduct.Text.Trim());
            }

            if (!string.IsNullOrEmpty(txtProductParts.Text.Trim()))
            {
                sb.AppendFormat(" and PRODUCT_PARTS_CODE = '{0}'", txtProductParts.Text.Trim());
            }

            if (!string.IsNullOrEmpty(txtQuantity.Text.Trim()))
            {
                sb.AppendFormat(" and QUANTITY = '{0}'", txtQuantity.Text.Trim());
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

        #region 详细
        private void btnOperate_Click(object sender, EventArgs e)
        {
            try
            {
                string slipnumber = CConvert.ToString(dgvData.SelectedRows[0].Cells["SLIP_NUMBER"].Value);
                if (!string.IsNullOrEmpty(slipnumber))
                {
                    FrmProductBuild frm = new FrmProductBuild();
                    frm.SLIP_NUMBER = slipnumber;
                    frm.STATUS = CConstant.BUILD_STATUS;
                    DialogResult resule = frm.ShowDialog(this);
                    frm.Enabled = false;
                    frm.Dispose();
                }
                else
                {
                    MessageBox.Show("请选择正确的行!");
                }
            }
            catch { }
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
                if (row.Cells["PRODUCT_CODE"].Value == null || "".Equals(row.Cells["PRODUCT_CODE"].Value.ToString()))
                {
                    row.Selected = false;
                }
            }
        }

        #region 导出
        private void btnPrint_Click(object sender, EventArgs e)
        {
            _currentDt = bProductBuild.GetBuildSearchPrintList(GetConduction()).Tables[0];
            _currentDt.Columns.Add("STATUS");
            foreach (DataRow row in _currentDt.Rows)
            {
                if (CConvert.ToInt32(row["STATUS_FLAG"]) == CConstant.BUILD_STATUS)
                {
                    row["STATUS"] = "组成";
                }
            }
            _currentDt.Columns.Remove("STATUS_FLAG");
            if (_currentDt.Rows.Count > 0 && isSearch)
            {
                SaveFileDialog sf = new SaveFileDialog();
                sf.FileName = "HD_BUILD_SEARCH_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
                sf.Filter = "(文件)|*.xls;*.xlsx";

                string header = "组成编号\t仓库编号\t仓库名称\t组成品编号\t组成品名称\t组成数量\t组成时间\t公司编号\t公司名称\t组成品单位编号\t组成品单位名称\t创建人\t创建时间\t最后更新人\t最后更新时间\t" +
                                "材料明细\t材料编号\t材料名称\t材料数量\t材料单位编号\t材料单位名称\t状态\t\n";
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
