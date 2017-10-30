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
using CZZD.ERP.WinUI.Properties;
using CZZD.ERP.Bll;

namespace CZZD.ERP.WinUI
{
    public partial class FrmUnPaymentSearch : FrmBase
    {
        private DataTable _currentDt = new DataTable();
        protected BPurchase bPurchase = new BPurchase();
        private bool isSearch = false;

        public FrmUnPaymentSearch()
        {
            InitializeComponent();
        }

        private void FrmUnPaymentSearch_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.CTag = CTag;

            #region dgvData 初始化
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;

            PageSize = 14;
            dgvData.Rows.Add(PageSize);
            dgvData.Rows[0].Selected = true;
            #endregion
        }

        #region 供应商
        private void btnSupplier_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("SUPPLIER", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtSupplierCode.Text = frm.BaseMasterTable.Code;
                    txtSupplierName.Text = frm.BaseMasterTable.Name;
                }
            }
            frm.Dispose();
        }

        private void txtSupplierCode_Leave(object sender, EventArgs e)
        {
            string SupplierCode = txtSupplierCode.Text.Trim();
            if (SupplierCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("SUPPLIER", SupplierCode);
                if (baseMaster != null)
                {
                    txtSupplierCode.Text = baseMaster.Code;
                    txtSupplierName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("出库仓库不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSupplierCode.Text = "";
                    txtSupplierName.Text = "";
                    txtSupplierCode.Focus();
                }
            }
            else
            {
                txtSupplierName.Text = "";
            }
        }

        private void btnCustomer_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Resources.find;
        }

        private void btnCustomer_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Resources.find_over;
        }
        #endregion

        #region 关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确定关闭吗?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                this.Close();
            }
        }
        #endregion

        #region 明细确认
        private void btnOperate_Click(object sender, EventArgs e)
        {
            try
            {
                string slipnumber = CConvert.ToString(dgvData.SelectedRows[0].Cells["SLIP_NUMBER"].Value);
                if (!string.IsNullOrEmpty(slipnumber))
                {
                    FrmPurchase frm = new FrmPurchase();
                    frm.SLIP = slipnumber;
                    frm.ShowDialog();
                    frm.Dispose();
                }
            }
            catch (Exception ex)
            { }
        }
        #endregion

        #region 查询按钮
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int currentPage = 1;
            int recordCount = bPurchase.GetUnPaymentRecordCount(GetCondition());
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
        #endregion

        #region 数据绑定
        /// <summary>
        /// 数据查询,绑定
        /// </summary>
        private void BindData(int currentPage)
        {
            string strWhere = GetCondition();
            DataSet ds = bPurchase.GetUnPaymentList(strWhere, "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);
            _currentDt = ds.Tables[0];
            reSetCurrentDt();
            this.dgvData.DataSource = _currentDt;            
        }

        /// <summary>
        /// 当前页码发生变化时的操作
        /// </summary>
        private void pgControl_PageChanged(object sender, EventArgs e, int currentPage)
        {
            BindData(currentPage);
        }
        #endregion 

        #region 查询条件
        private string GetCondition()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" payment_status <> {0}", 1);
            if (!string.IsNullOrEmpty(txtSupplierCode.Text.Trim()))
            {
                sb.AppendFormat(" and SUPPLIER_CODE = '{0}'", txtSupplierCode.Text);
            }            
            return sb.ToString();
        }
        #endregion

        #region 当前数据集的重新整理(暂不需要)
        /// <summary>
        /// 当前数据集的重新整理
        /// </summary>
        private void reSetCurrentDt()
        {
            //    //for (int i = 0; i < _currentDt.Rows.Count; i++)
            //    //{
            //    //    _currentDt.Rows[i]["NO"] = i + 1;
            //    //}

            for (int i = _currentDt.Rows.Count; i < PageSize; i++)
            {
                _currentDt.Rows.Add(_currentDt.NewRow());
            }
        }
        #endregion

        #region 导出
        private void btnPrint_Click(object sender, EventArgs e)
        {
            int recordCount = bPurchase.GetUnPaymentRecordCount(GetCondition());
            _currentDt = bPurchase.GetUnPaymentList(GetCondition(), "", 1, recordCount).Tables[0];
            if (isSearch && _currentDt.Rows.Count > 0)
            {
                SaveFileDialog sf = new SaveFileDialog();
                sf.FileName = "LZ_UNPAYMENT_MATCH_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
                sf.Filter = "(文件)|*.xls;*.xlsx";

                string header = "画面明细编号\t采购内部编号\t供应商名称\t供应商类型\t发票编号\t发票金额\t付款状态\t未付金额\t开票日期\t付款预定日\t通货\t\n";
                if (sf.ShowDialog(this) == DialogResult.OK)
                {
                    //_currentDt.Columns.Remove("Row");
                    int result = CExport.DataTableToCsv(_currentDt, header, sf.FileName);
                    if (result == 0)
                    {
                        MessageBox.Show("导出成功!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        #endregion

        #region 空行不能被点击
        private void dgvData_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Index >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.Row.Index];
                if (row.Cells["Row"].Value == null || "".Equals(row.Cells["Row"].Value.ToString()))
                {
                    row.Selected = false;
                }
            }
        }
        #endregion

    }
}