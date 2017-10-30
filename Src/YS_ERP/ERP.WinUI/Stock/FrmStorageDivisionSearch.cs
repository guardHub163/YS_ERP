using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.CacheData;
using CZZD.ERP.Main;
using CZZD.ERP.Model;
using CZZD.ERP.Common;

namespace CZZD.ERP.WinUI
{
    public partial class FrmStorageDivisionSearch : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private DataTable _currentDt = new DataTable();
        private string _currentConduction = "";
        private bool isSearch = false;
        private string slipNumber = "";

        public FrmStorageDivisionSearch()
        {
            InitializeComponent();
        }

        private void FrmStorageDivisionSearch_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;

            #region 返品类型初始化
            DataTable pstDT = CCacheData.ReverseStorage.Copy();
            DataRow dr = pstDT.NewRow();
            pstDT.Rows.InsertAt(dr, 0);
            dr["CODE"] = "";
            dr["NAME"] = "全部";
            cboReturn.ValueMember = "CODE";
            cboReturn.DisplayMember = "NAME";
            cboReturn.DataSource = pstDT;
            #endregion

            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            PageSize = 18;
            dgvData.Rows.Add(PageSize);
            dgvData.Rows[0].Selected = false;
        }

        #region 关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要关闭吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                this.Close();
            }
        }
        #endregion

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
                    //txtWarehouseCode.Focus();
                }
            }
            frm.Dispose();
        }

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
                }
                else
                {
                    MessageBox.Show("供应商编号不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        #endregion

        #region 采购订单
        private void btnPurchase_Click(object sender, EventArgs e)
        {
            FrmPurchaseOrderSearch frm = new FrmPurchaseOrderSearch();
            frm.CTag = CConstant.PURCHASE_ORDER_MASTER_SEARCH;
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.CurrentPurchaseOrderTable != null)
                {
                    string slipNumber = frm.CurrentPurchaseOrderTable.SLIP_NUMBER;
                    txtPurchaseNumber.Text = slipNumber;
                }
            }
            frm.Dispose();
        }

        private void txtPurchaseNumber_Leave(object sender, EventArgs e)
        {
            string purchase = txtPurchaseNumber.Text.Trim();
            if (!string.IsNullOrEmpty(purchase))
            {
                if (bPurchaseOrder.GetModel(purchase) == null)
                {
                    MessageBox.Show("采购订单编号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPurchaseNumber.Text = "";
                    txtPurchaseNumber.Focus();
                }
            }
        }
        #endregion

        #region 查询
        private void btnSearch_Click(object sender, EventArgs e)
        {
            _currentConduction = GetConduction();
            int currentPage = 1;
            int recordCount = bRerceipt.GetReSearchCount(_currentConduction);
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
            DataSet ds = bRerceipt.GetReList(_currentConduction, "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);
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
            //订单类型
            sb.AppendFormat(" AND RERECEIPT_FLAG like '{0}%'", cboReturn.SelectedValue);

            if (txtSlipNumber.Text.Trim() != "")
            {
                sb.AppendFormat("and SLIP_NUMBER like '{0}%' ", txtSlipNumber.Text.Trim());
            }

            if (txtSupplierCode.Text.Trim() != "")
            {
                sb.AppendFormat("and SUPPLIER_CODE = '{0}' ", txtSupplierCode.Text.Trim());
            }

            if (txtPurchaseNumber.Text.Trim() != "")
            {
                sb.AppendFormat("and PO_SLIP_NUMBER = '{0}' ", txtPurchaseNumber.Text.Trim());
            }

            if (slipDateFrom.Checked)
            {
                sb.AppendFormat("and SLIP_DATE >= '{0}' ", slipDateFrom.Value.ToString("yyyy-MM-dd"));
            }
            else if (slipDateTo.Checked)
            {
                sb.AppendFormat("and SLIP_DATE < '{0}' ", slipDateTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
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

        #region 详细确认
        private void btnOperate_Click(object sender, EventArgs e)
        {
            if (GetCurrentSelectedTable())
            {
                FrmStorageDivision frm = new FrmStorageDivision();
                frm.SLIP_NUMBER = slipNumber;
                //frm.UserTable = _userInfo;
                //frm.CTag = CConstant.PURCHASE_ORDER_SEARCH;
                frm.ShowDialog(this);
                frm.Dispose();
                slipNumber = "";
                //_currentPurchaseOrderTable = null; 
            }
        }

        /// <summary>
        /// 获得当前选中的数据
        /// </summary>
        private bool GetCurrentSelectedTable()
        {
            bool check = false;
            if (dgvData.SelectedRows.Count > 0)
            {
                try
                {
                    slipNumber = dgvData.SelectedRows[0].Cells["SLIP_NUMBER"].Value.ToString();

                    if (!string.IsNullOrEmpty(slipNumber))
                    {
                        check = true;
                    }
                    else
                    {
                        MessageBox.Show("请先选择一行。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error("采购订单查询选择数据错误：", ex);                    
                }
            }
            return check;
        }
        #endregion

        #region 控制空行不能被点击
        /// <summary>
        ///　控制空行不能被点击
        /// </summary>
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
        #endregion
    }
}
