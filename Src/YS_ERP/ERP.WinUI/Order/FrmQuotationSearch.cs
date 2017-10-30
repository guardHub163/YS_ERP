using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.CacheData;
using CZZD.ERP.Model;
using CZZD.ERP.Common;
using System.IO;
using CZZD.ERP.WinUI.Sys;
using CZZD.ERP.WinUI.Properties;


namespace CZZD.ERP.WinUI
{
    public partial class FrmQuotationSearch : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private DataTable _currentDt = new DataTable();
        public BllQuotationTable QTTable = new BllQuotationTable();
        private bool isSearch = false;
        private string _currentConduction = "";

        //private string _tmpAttachedDirectoryName = "T" + DateTime.Now.ToString("yyyyMMddHHmmss");
        //private string _attachedDirectory = CCacheData.GetAttacheDirectory(CConstant.ATTACHE_DIRECTORY_QUOTATION);
        //private int attachedNumber = 0;

        public FrmQuotationSearch()
        {
            InitializeComponent();
        }

        #region 初始化
        private void FrmQuotationSearch_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;
            if (UserTable.LEVEL < 6)
            {
                txtSales.Visible = false;
                txtSalesCode.Visible = false;
                label4.Visible = false;
                label6.Visible = false;
                btnSales.Visible = false;
            }

            #region 订单类型的初始化
            //订单类型的初始化  
            //DataTable ostDT = CCacheData.SlipType.Copy();
            //DataRow dr = ostDT.NewRow();
            //dr["CODE"] = "";
            //dr["NAME"] = "全部";
            //ostDT.Rows.InsertAt(dr, 0);
            //cboSlipType.ValueMember = "CODE";
            //cboSlipType.DisplayMember = "NAME";
            //cboSlipType.DataSource = ostDT;
            #endregion
            init();
            PageSize = 12;
            dgvData.Rows.Add(PageSize);
            dgvData.Rows[0].Selected = true;
        }

        /// <summary>
        /// 页面初始化
        /// </summary>
        private void init()
        {
            #region dgvData
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            #endregion
        }
        #endregion

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
                    //txtWarehouseCode.Focus();
                }
            }
            frm.Dispose();
        }
        #region datagridview 行点击事件
        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.RowIndex];

                if (e.ColumnIndex == dgvData.Columns["UPDATE_COUNT"].Index)
                {
                    if (CConvert.ToInt32(row.Cells["UPDATE_COUNT"].Value) > 0)
                    {
                        FrmHistoryQuotation frm = new FrmHistoryQuotation(CConvert.ToString(row.Cells["SLIP_NUMBER"].Value));
                        if (DialogResult.OK == frm.ShowDialog(this))
                        {
                            FrmBase frmOrder = new FrmQuotation(frm.historySlipNumber);
                            frmOrder.CTag = CConstant.ORDER_HISTORY;
                            frmOrder.UserTable = _userInfo;
                            frmOrder.ShowDialog();
                        }
                    }
                }

                else if (e.ColumnIndex == dgvData.Columns["ATTACHED_NAME"].Index)
                {
                    if (CConvert.ToString(row.Cells["SLIP_NUMBER"].Value) != "")
                    {
                        Czzd.Common.Library.FTPOperate myftp = new Czzd.Common.Library.FTPOperate("112.82.245.2", "YS_ERP\\quotation\\" + row.Cells["SLIP_NUMBER"].Value, "FTP_user", "czzd", 21);
                        string[] files = myftp.Dir("\\YS_ERP\\quotation\\" + row.Cells["SLIP_NUMBER"].Value);
                        #region　附件
                        if (files.Length > 1)
                        {
                            string attachedDirectory = CCacheData.GetAttacheDirectory(CConstant.ATTACHE_DIRECTORY_QUOTATION);
                            string slipNumber = CConvert.ToString(row.Cells["SLIP_NUMBER"].Value);
                            FrmAttachedQuatation frm = new FrmAttachedQuatation(slipNumber, attachedDirectory, true);
                            frm.CTag = CConstant.QUOTATION_MODIFY;
                            frm.ShowDialog(this);
                            frm.Dispose();
                        }



                    }
                }
            }
        }
                        #endregion
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
                    //txtWarehouseCode.Focus();
                }
                else
                {
                    MessageBox.Show("客户编号不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    //txtWarehouseCode.Text = frm.BaseMasterTable.Code;
                    //txtWarehouseName.Text = frm.BaseMasterTable.Name;
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
            //string warehouseCode = txtWarehouseCode.Text.Trim();
            //if (warehouseCode != "")
            //{
            //    BaseMaster baseMaster = bCommon.GetBaseMaster("WAREHOUSE", warehouseCode);
            //    if (baseMaster != null)
            //    {
            //        txtWarehouseCode.Text = baseMaster.Code;
            //        txtWarehouseName.Text = baseMaster.Name;
            //    }
            //    else
            //    {
            //        MessageBox.Show("出库仓库不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        txtWarehouseCode.Text = "";
            //        txtWarehouseName.Text = "";
            //        txtWarehouseCode.Focus();
            //    }
            //}
            //else
            //{
            //    txtWarehouseName.Text = "";
            //}

        }
        #endregion

        #region 窗口关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 控制空行不能被点击
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

        #region 查询分页
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>    
        private void btnSearch_Click(object sender, EventArgs e)
        {
            _currentConduction = GetConduction();
            int currentPage = 1;
            int recordCount = bQuotation.GetRecordCount(_currentConduction);
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
            DataSet ds = bQuotation.GetList(_currentConduction, "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);
            _currentDt = ds.Tables[0];
            _currentDt.Columns.Add("ORDER_NAME", Type.GetType("System.String"));
            _currentDt.Columns.Add("ATTACHED_NAME", Type.GetType("System.String"));

            for (int i = 0; i < _currentDt.Rows.Count; i++)
            {
                if (_currentDt.Rows[i]["SLIP_NUMBER"].ToString() != "")
                {
                    //    Czzd.Common.Library.FTPOperate myftp = new Czzd.Common.Library.FTPOperate("112.82.245.2", "YS_ERP\\quotation\\" + _currentDt.Rows[i]["SLIP_NUMBER"], "FTP_user", "czzd", 21);
                    //    string[] files = myftp.Dir("\\YS_ERP\\quotation\\" + _currentDt.Rows[i]["SLIP_NUMBER"]);
                    //    #region　附件
                    //    if (files.Length > 1)
                    //    {
                    //        _currentDt.Rows[i]["ATTACHED_NAME"] = "有";
                    //    }
                    //    else
                    //    {
                    //        _currentDt.Rows[i]["ATTACHED_NAME"] = "无";
                    //    }

                    if (CConstant.EXIST_ATTACHED.Equals(_currentDt.Rows[i]["ORDER_FLAG"]))
                    {
                        _currentDt.Rows[i]["ATTACHED_NAME"] = "有";
                    }
                    else
                    {
                        _currentDt.Rows[i]["ATTACHED_NAME"] = "无";
                    }
                }
            }
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
            if (UserTable.LEVEL < 6)
            {
                sb.AppendFormat(" AND CREATE_USER = '{0}'", UserTable.CODE);
            }
            //报价单类型
            //if (cboSlipType.SelectedIndex > 0)
            //{
            //    sb.AppendFormat(" AND SLIP_TYPE = '{0}'", cboSlipType.SelectedValue);
            //}
            //报价单编号
            if (!string.IsNullOrEmpty(txtSlipNumber.Text.Trim()))
            {
                sb.AppendFormat(" AND SLIP_NUMBER = '{0}'", txtSlipNumber.Text.Trim());
            }
            //客户
            if (!string.IsNullOrEmpty(txtEndCustomerCode.Text.Trim()))
            {
                sb.AppendFormat(" AND CUSTOMER_CODE = '{0}'", txtEndCustomerCode.Text.Trim());
            }
            //出库仓库
            //if (!string.IsNullOrEmpty(txtWarehouseCode.Text.Trim()))
            //{
            //    sb.AppendFormat(" AND DEPARTUAL_WAREHOUSE_CODE = '{0}'", txtWarehouseCode.Text.Trim());
            //}
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
            if (this.txtEnquiryDate.Checked)
            {
                sb.AppendFormat(" AND ENQUIRY_DATE = '{0}'", txtEnquiryDate.Text.Trim());
            }

            if (!string.IsNullOrEmpty(txtSalesCode.Text.Trim()))
            {
                sb.AppendFormat(" AND CREATE_USER = '{0}'", txtSalesCode.Text.Trim());
                //return sb.ToString();
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
            for (int i = 0; i < _currentDt.Rows.Count; i++)
            {
                #region 是否生成销售订单

                #endregion
            }

            for (int i = _currentDt.Rows.Count; i < PageSize; i++)
            {
                _currentDt.Rows.Add(_currentDt.NewRow());
            }
        }
        #endregion

        #region 详细
        /// <summary>
        /// 执行操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperate_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvData.CurrentRow;
            string slipNumber = CConvert.ToString(row.Cells["SLIP_NUMBER"].Value);
            if (!string.IsNullOrEmpty(slipNumber))
            {
                FrmBase frm = new FrmQuotation(slipNumber);
                frm.CTag = CConstant.QUOTATION_OPERATE;
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
        #endregion

        #region 修改
        private void btnModify_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvData.CurrentRow;
            //if (CConvert.ToInt32(row.Cells["ORDER_FLAG"].Value) <= 0)
           // {
                string slipNumber = CConvert.ToString(row.Cells["SLIP_NUMBER"].Value);
                if (!string.IsNullOrEmpty(slipNumber))
                {
                    FrmBase frm = new FrmQuotation(slipNumber);
                    frm.CTag = CConstant.QUOTATION_MODIFY;
                    frm.UserTable = _userInfo;
                    if (DialogResult.OK == frm.ShowDialog())
                    {
                        BindData(this.pgControl.GetCurrentPage());
                    }
                    frm.Dispose();
                }
                else
                {
                    MessageBox.Show("请先选择一张订单。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
           // else
           // {
             //   MessageBox.Show("报价单已生成销售订单不能修改。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
           // }
        //}
        #endregion

        #region 生成销售订单
        private void btnOrder_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvData.CurrentRow;
            string slipNumber = CConvert.ToString(row.Cells["SLIP_NUMBER"].Value);
            if (!string.IsNullOrEmpty(slipNumber))
            {
                FrmOrdersEntry frm = new FrmOrdersEntry(slipNumber);
                frm.CTag = CConstant.ORDER_QOUTATION;
                frm.UserTable = _userInfo;
                if (DialogResult.OK == frm.ShowDialog())
                {
                    BindData(this.pgControl.GetCurrentPage());
                }
                frm.Dispose();
            }
            else
            {
                MessageBox.Show("请先选择一张订单。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {

            DataGridViewRow row = dgvData.CurrentRow;
            string slipNumber = CConvert.ToString(row.Cells["SLIP_NUMBER"].Value);
            if (!string.IsNullOrEmpty(slipNumber))
            {
                PrintSetting frm = new PrintSetting(slipNumber);
                //frm.CTag = CConstant.QUOTATION_OPERATE;
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

        private void btnEndCustomer_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find_over);
        }

        private void btnEndCustomer_MouseLeave(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find);
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("USER", " DEPARTMENT_CODE='D01'");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtSalesCode.Text = frm.BaseMasterTable.Code.Substring(2);
                    txtSales.Text = frm.BaseMasterTable.Name;

                    //txtWarehouseCode.Focus();
                }
            }
            frm.Dispose();
        }



        private void btnSales_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find_over);
        }

        private void btnSales_MouseLeave(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find);

        }

        private void txtSalesCode_Leave(object sender, EventArgs e)
        {
            string SalesCode = CConstant.DEFAULT_COMPANY_CODE + txtSalesCode.Text.Trim();
            if (SalesCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("USER", SalesCode);
                if (baseMaster != null)
                {
                    txtSalesCode.Text = baseMaster.Code.Substring(2);
                    txtSales.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("销售人员编号不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSalesCode.Text = "";
                    txtSales.Text = "";
                    txtSalesCode.Focus();
                }
            }
            else
            {
                txtSales.Text = "";
            }
        }
    }
}
        #endregion