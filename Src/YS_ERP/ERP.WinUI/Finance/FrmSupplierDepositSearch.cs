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
    public partial class FrmSupplierDepositSearch : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private BSupplierDeposit bDeposit = new BSupplierDeposit();

        public FrmSupplierDepositSearch()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        private void FrmDepositSearch_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;

            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            PageSize = 14;
            dgvData.Rows.Add(PageSize);
        }


        #region 供应商
        /// <summary>
        /// 供应商选择
        /// </summary>
        private void btnSupplier_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("SUPPLIER", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtSupplierCode.Text = frm.BaseMasterTable.Code;
                    txtSupplierName.Text = frm.BaseMasterTable.Name;
                    txtSlipDateFrom.Focus();
                }
            }
            frm.Dispose();
            txtBalance.Text = CConvert.ToString(GetSupplierDepositBlanace(txtSupplierCode.Text.Trim()));
        }

        /// <summary>
        /// 供应商CHECK
        /// </summary>
        private void txtSupplierCode_Leave(object sender, EventArgs e)
        {
            string SupplierCode = txtSupplierCode.Text.Trim();
            if (!string.IsNullOrEmpty(SupplierCode))
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("SUPPLIER", SupplierCode);
                if (baseMaster != null)
                {
                    txtSupplierCode.Text = baseMaster.Code;
                    txtSupplierName.Text = baseMaster.Name;
                    txtSlipDateFrom.Focus();
                    txtBalance.Text = CConvert.ToString(GetSupplierDepositBlanace(txtSupplierCode.Text.Trim()));
                }
                else
                {
                    MessageBox.Show("供应商编号不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSupplierCode.Text = "";
                    txtSupplierName.Text = "";
                    txtBalance.Text = "";
                    txtSupplierCode.Focus();
                }
            }
            else 
            {
                txtSupplierName.Text = "";
                txtBalance.Text = "";
            }
           
            
        }
        #endregion

        #region 分页查询
        /// <summary>
        /// 分页查询
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int currentPage = 1;
            int recordCount = bDeposit.GetRecordCount(GetConduction());
            if (recordCount <= 0)
            {
                MessageBox.Show("查询的信息不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //分页标签初始化
            this.pgControl.init(GetTotalPage(recordCount), currentPage);
            //数据绑定
            BindData(currentPage);
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void BindData(int currentPage)
        {
            string strWhere = GetConduction();
            DataSet ds = bDeposit.GetList(strWhere, "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);
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
            if (!string.IsNullOrEmpty(txtSupplierCode.Text.Trim()))
            {
                sb.AppendFormat("and SUPPLIER_CODE = '{0}'", txtSupplierCode.Text.Trim());
            }

            //出库日期From
            if (this.txtSlipDateFrom.Checked)
            {
                sb.AppendFormat(" AND SLIP_DATE >= '{0}'", txtSlipDateFrom.Value.ToString("yyyy-MM-dd"));
            }
            //出库日期To
            if (this.txtSlipDateTo.Checked)
            {
                sb.AppendFormat(" AND SLIP_DATE < '{0}'", txtSlipDateTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
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
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 订单取消
        /// <summary>
        /// 订单取消
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count > 0)
            {
                if (DialogResult.OK == MessageBox.Show("确定要取消吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {

                    string slipNumber = CConvert.ToString(dgvData.SelectedRows[0].Cells["SLIP_NUMBER"].Value);

                    try
                    {
                        if (bDeposit.Delete(slipNumber))
                        {
                            MessageBox.Show("预付款取消成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BindData(pgControl.GetCurrentPage());
                        }
                        else
                        {
                            MessageBox.Show("预付款取消失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("预付款取消失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Logger.Error("预付款取消失败。", ex);
                    }
                }
            }
            else
            {
                MessageBox.Show("请先选择一行。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.TextBox_KeyPress(sender, e);
        }

    }//end class
}
