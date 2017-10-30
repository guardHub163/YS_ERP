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
    public partial class FrmDepositArrSearch : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private BDepositArr bDepositArr = new BDepositArr();
        private BSales bSales = new BSales();

        public FrmDepositArrSearch()
        {
            InitializeComponent();
        }

        private void FrmDepositArrSearch_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;
          
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            PageSize = 14;
            dgvData.Rows.Add(PageSize);
        }

        #region 客户
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("CUSTOMER", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtCustomerCode.Text = frm.BaseMasterTable.Code;
                    txtCustomerName.Text = frm.BaseMasterTable.Name;
                }
            }
            frm.Dispose();
            txtBalance.Text = CConvert.ToString(GetCustomerDepositBlanace(txtCustomerCode.Text.Trim()));
        }

        private void txtCustomerCode_Leave(object sender, EventArgs e)
        {
            string customerCode = txtCustomerCode.Text.Trim();
            if (customerCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("CUSTOMER", customerCode);
                if (baseMaster != null)
                {
                    txtCustomerCode.Text = baseMaster.Code;
                    txtCustomerName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("客户不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCustomerCode.Text = "";
                    txtCustomerName.Text = "";
                    txtCustomerCode.Focus();
                }
            }
            else
            {
                txtCustomerName.Text = "";              
            }
            txtBalance.Text = CConvert.ToString(GetCustomerDepositBlanace(txtCustomerCode.Text.Trim()));
        }
        #endregion

        #region 分页查询
        /// <summary>
        /// 分页查询
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int currentPage = 1;
            int recordCount = bDepositArr.GetRecordCount(GetConduction());
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
            DataSet ds = bDepositArr.GetList(strWhere, "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);
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
            sb.AppendFormat(" AND LINE_STATUS_FLAG <> {0}", CConstant.DELETE);
            if (!string.IsNullOrEmpty(txtCustomerCode.Text.Trim()))
            {
                sb.AppendFormat("AND CUSTOMER_CLAIM_CODE = '{0}'", txtCustomerCode.Text.Trim());
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

            if (!string.IsNullOrEmpty(txtOrderSlipNumber.Text.Trim()))
            {
                sb.AppendFormat(" AND ORDER_SLIP_NUMBER LIKE  '{0}%'", txtOrderSlipNumber.Text.Trim());
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

        #region 分配解除
        /// <summary>
        /// 分配解除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count > 0)
            {
                if (DialogResult.OK == MessageBox.Show("确定要解除吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                    string slipNumber = CConvert.ToString(dgvData.SelectedRows[0].Cells["SLIP_NUMBER"].Value);

                    string lineNumber = CConvert.ToString(dgvData.SelectedRows[0].Cells["LINE_NUMBER"].Value);

                    try
                    {
                        if (bDepositArr.Delete(slipNumber, lineNumber))
                        {
                            MessageBox.Show("分配解除成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BindData(pgControl.GetCurrentPage());
                        }
                        else
                        {
                            MessageBox.Show("分配解除失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("分配解除失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Logger.Error("分配解除失败。", ex);
                    }
                }
            }
            else
            {
                MessageBox.Show("请先选择一行。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 关闭
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.TextBox_KeyPress(sender, e);
        }

        
    }//end class
}
