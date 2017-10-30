using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Common;
using CZZD.ERP.CacheData;
using CZZD.ERP.Model;
using System.Collections;
using CZZD.ERP.Bll;
using CZZD.ERP.WinUI.Sys;
using CZZD.ERP.WinUI.Properties;

namespace CZZD.ERP.WinUI
{
    public partial class FrmOrdersSearch : FrmBase
    {
        private DataTable _currentDt = new DataTable();
        public BllOrderHeaderTable orderTable = new BllOrderHeaderTable();
        private bool isSearch = false;
        private string _currentConduction = "";

        public FrmOrdersSearch()
        {
            InitializeComponent();
        }

        #region init
        private void FrmOrdersSearch_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;
            btnPrint.Enabled = false;
            btnPrint.Visible = false;

            if (UserTable.LEVEL < 6)
            {
                txtSales.Visible = false;
                txtSalesCode.Visible = false;
                label3.Visible = false;
                label6.Visible = false;
                btnSales.Visible = false;
            }


            #region 订单类型的初始化
            //订单类型的初始化  
            DataTable ostDT = CCacheData.SlipType.Copy();
            DataRow dr = ostDT.NewRow();
            dr["CODE"] = "";
            dr["NAME"] = "全部";
            ostDT.Rows.InsertAt(dr, 0);
            //cboSlipType.ValueMember = "CODE";
            // cboSlipType.DisplayMember = "NAME";
            // cboSlipType.DataSource = ostDT;
            #endregion

            //订单查询 
            if (CConstant.ORDER_SEARCH.Equals(CTag))
            {
                this.Text = "订单查询";
                btnOperate.Text = "详细确认";
                btnPrint.Enabled = true;
                btnPrint.Visible = true;
                //btnExport.Visible = true;
                rdoAllLibrary.Checked = true;
            }
            //在库引当
            //if (CConstant.ORDER_ALLOATION.Equals(CTag))
            //{
            //    this.Text = "在库引当";
            //    btnOperate.Text = "在库引当";
            //    //rdoAllowanceNo.Checked = true;
            //}
            //订单修正    
            else if (CConstant.ORDER_MODIFY.Equals(CTag))
            {
                this.Text = "订单修正";
                btnOperate.Text = "修  正";
                rdoAllLibrary.Checked = true;
                dgvData.Columns["CHECK_DATE"].Visible = false;
            }
            //订单审核  
            else if (CConstant.ORDER_VERIFY.Equals(CTag))
            {
                this.Text = "订单通知";
                btnOperate.Text = "通　知";
                rdoAllLibrary.Checked = true;
            }
            //复制订单     
            else if (CConstant.ORDER_COPY.Equals(CTag))
            {
                this.Text = "复制订单";
                btnOperate.Text = "复制订单";
                rdoAllLibrary.Checked = true;
            }
            //订单查询
            else if (CConstant.ORDER_MASTER_SEARCH.Equals(CTag))
            {
                this.Text = "订单查询";
                btnOperate.Text = "确　认";
                btnPrint.Visible = false;
                rdoAllLibrary.Checked = true;
                dgvData.Columns["UPDATED_COUNT"].Visible = false;
                dgvData.Columns["ATTACHED_NAME"].Visible = false;
            }
            //订单修理输入
            else if (CConstant.ORDER_SERVICE.Equals(CTag))
            {
                this.Text = "售后服务";
                btnOperate.Text = "修　理";
                dgvData.Columns["SERVICE_TITLE"].Visible = true;
                btnPrint.Visible = false;
                rdoAllLibrary.Checked = true;
            }
            //生产确认
            else if (CConstant.PRODUCT_VALIDATION.Equals(CTag))
            {
                this.Text = "生产确认";
                btnPrint.Text = "生产确认";
                btnPrint.Visible = true;
                btnPrint.Enabled = true;
                label4.Text = "  生产状态";
                rdoVerifyOk.Text = "已确认";
                rdoVerifyNo.Text = "未确认";
                dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvData.Columns["PRODUCE_NAME"].Visible = true;
                dgvData.Columns["CUSTOMER_CODE"].Visible = true;
                dgvData.Columns["SLIP_TYPE_NAME"].Visible = true;
                //dgvData.Columns["CHECK"].Visible = true;
                dgvData.Columns["WAREHOUSE_NAME"].Visible = false;
                dgvData.Columns["UPDATED_COUNT"].Visible = false;
                dgvData.Columns["ATTACHED_NAME"].Visible = false;
                dgvData.Columns["VERIFY_NAME"].Visible = false;
                dgvData.Columns["SLIP_NUMBER"].HeaderText = "销售编号";
                dgvData.Columns["SLIP_DATE"].HeaderText = "销售日期";
                btnProduce.Visible = true;
            }

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

        #region 窗口关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
            int recordCount = bOrderHeader.GetRecordCount(_currentConduction);
            if (recordCount <= 0)
            {
                MessageBox.Show("查询的信息不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //分页标签初始化
            this.pgControl.init(GetTotalPage(recordCount), currentPage);

            //数据绑定
            BindData(currentPage);
            isSearch = true;
            //foreach (DataGridViewRow dr in dgvData.Rows) 
            //{
            //    if (dr.Cells["VERIFY_FLAG"].Value.Equals(0)) 
            //    {
            //        dr.Cells["CHECK_DATE"].Value = null;

            //    }
            //}

            if (CConstant.PRODUCT_VALIDATION.Equals(CTag))
            {
                dgvData.Columns["CHECK"].Visible = true;
                //dgvData.Rows[0].Selected = false;
            }
        }

        /// <summary>
        /// 数据查询,绑定
        /// </summary>
        private void BindData(int currentPage)
        {
            DataSet ds = bOrderHeader.GetList(_currentConduction, "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);
            _currentDt = ds.Tables[0];

            _currentDt.Columns.Add("VERIFY_NAME", Type.GetType("System.String"));
            _currentDt.Columns.Add("PRODUCE_NAME", Type.GetType("System.String"));
            _currentDt.Columns.Add("ATTACHED_NAME", Type.GetType("System.String"));
            _currentDt.Columns.Add("ALLOATION_NAME", Type.GetType("System.String"));
            _currentDt.Columns.Add("SHIPMENT_NAME", Type.GetType("System.String"));
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
            if (!CConstant.ORDER_MASTER_SEARCH.Equals(CTag))
            {
                if (UserTable.LEVEL < 6)
                {
                    sb.AppendFormat(" AND CREATE_USER = '{0}'", UserTable.CODE);
                }
            }
            if (!string.IsNullOrEmpty(txtSalesCode.Text.Trim()))
            {
                sb.AppendFormat(" AND CREATE_USER = '{0}'", txtSalesCode.Text.Trim());
                //return sb.ToString();
            }
            if (CConstant.PRODUCT_VALIDATION.Equals(CTag))
            {
                sb.AppendFormat("AND VERIFY_FLAG = {0}", CConstant.VERIFY);
            }
            //订单类型
            //if (cboSlipType.SelectedIndex > 0) 
            //{
            //    sb.AppendFormat(" AND SLIP_TYPE = '{0}'", cboSlipType.SelectedValue);
            //}
            //订单编号
            if (!string.IsNullOrEmpty(txtSlipNumber.Text.Trim()))
            {
                sb.AppendFormat(" AND SLIP_NUMBER = '{0}'", txtSlipNumber.Text.Trim());
                //return sb.ToString();
            }
            //代理店
            //if (!string.IsNullOrEmpty(txtCustomerCode.Text.Trim()))
            //{
            //    sb.AppendFormat(" AND CUSTOMER_CODE = '{0}'", txtCustomerCode.Text.Trim());
            //}
            //客户
            if (!string.IsNullOrEmpty(txtEndCustomerCode.Text.Trim()))
            {
                sb.AppendFormat(" AND ENDER_CUSTOMER_CODE = '{0}'", txtEndCustomerCode.Text.Trim());
            }
            //纳入先
            //if (!string.IsNullOrEmpty(txtDeliveryPointCode.Text.Trim()))
            //{
            //    sb.AppendFormat(" AND DELIVERY_POINT_CODE = '{0}'", txtDeliveryPointCode.Text.Trim());
            //}
            //出库仓库
            //if (!string.IsNullOrEmpty(txtWarehouseCode.Text.Trim()))
            //{
            //    sb.AppendFormat(" AND DEPARTUAL_WAREHOUSE_CODE = '{0}'", txtWarehouseCode.Text.Trim());
            //}
            //机品编号
            //if (!string.IsNullOrEmpty(txtSerialNumber.Text.Trim()))
            //{
            //    sb.AppendFormat(" AND SERIAL_NUMBER = '{0}'", txtSerialNumber.Text.Trim());
            //}
            //公司订单编号
            if (!string.IsNullOrEmpty(txtOwnerPoNumber.Text.Trim()))
            {
                sb.AppendFormat(" AND OWNER_PO_NUMBER = '{0}'", txtOwnerPoNumber.Text.Trim());
            }
            //合同编号
            if (!string.IsNullOrEmpty(txtCustomerPoNumber.Text.Trim()))
            {
                sb.AppendFormat(" AND CUSTOMER_PO_NUMBER = '{0}'", txtCustomerPoNumber.Text.Trim());
            }
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
            //出库预定日期From
            if (this.txtDepartualDateFrom.Checked)
            {
                sb.AppendFormat(" AND DEPARTUAL_DATE >= '{0}'", txtDepartualDateFrom.Value.ToString("yyyy-MM-dd"));
            }
            //出库预定日期To
            if (this.txtDepartualDateTo.Checked)
            {
                sb.AppendFormat(" AND DEPARTUAL_DATE < '{0}'", txtDepartualDateTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }
            //审核状况
            if (CConstant.PRODUCT_VALIDATION.Equals(CTag))
            {
                if (rdoVerifyNo.Checked)
                {
                    sb.AppendFormat(" AND PRODUCE_FLAG = {0}", CConstant.PRODUCE_DEFAULT);
                }
                else if (rdoVerifyOk.Checked)
                {
                    sb.AppendFormat(" AND PRODUCE_FLAG <> {0}", CConstant.PRODUCE_DEFAULT);
                }
            }
            else
            {
                if (rdoVerifyNo.Checked)
                {
                    sb.AppendFormat(" AND VERIFY_FLAG = {0}", CConstant.UN_VERIFY);
                }
                else if (rdoVerifyOk.Checked)
                {
                    sb.AppendFormat(" AND (VERIFY_FLAG = {0} OR VERIFY_FLAG= {1})", CConstant.VERIFY, CConstant.NO_VERIFY);
                }
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
            _currentDt.Columns.Add("SHIPMENT_FLAG", Type.GetType("System.Int32"));

            for (int i = 0; i < _currentDt.Rows.Count; i++)
            {
                _currentDt.Rows[i]["No"] = _currentDt.Rows[i]["ROW"];

                #region　审核
                if (CConstant.VERIFY.Equals(_currentDt.Rows[i]["VERIFY_FLAG"]))
                {
                    _currentDt.Rows[i]["VERIFY_NAME"] = "已通知";
                }
                else if (CConstant.NO_VERIFY.Equals(_currentDt.Rows[i]["VERIFY_FLAG"]))
                {
                    _currentDt.Rows[i]["VERIFY_NAME"] = "通知未过";
                }
                else
                {
                    _currentDt.Rows[i]["VERIFY_NAME"] = "未通知";
                }
                #endregion

                #region　附件
                if (CConstant.EXIST_ATTACHED.Equals(_currentDt.Rows[i]["ATTACHED_FLAG"]))
                {
                    _currentDt.Rows[i]["ATTACHED_NAME"] = "有";
                }
                else
                {
                    _currentDt.Rows[i]["ATTACHED_NAME"] = "无";
                }
                #endregion

                #region　引当
                if (CConstant.ALLOATION_COMPLETE.Equals(_currentDt.Rows[i]["ALLOATION_FLAG"]))
                {
                    _currentDt.Rows[i]["ALLOATION_NAME"] = "完了";
                }
                else if (CConstant.ALLOATION_PART.Equals(_currentDt.Rows[i]["ALLOATION_FLAG"]))
                {
                    _currentDt.Rows[i]["ALLOATION_NAME"] = "欠品";
                }
                else
                {
                    _currentDt.Rows[i]["ALLOATION_NAME"] = "未引当";
                }
                #endregion

                #region　出库
                if (CConvert.ToDecimal(_currentDt.Rows[i]["SHIPMENT_QUANTITY"]) == 0)
                {
                    _currentDt.Rows[i]["SHIPMENT_NAME"] = "未出库";
                    _currentDt.Rows[i]["SHIPMENT_FLAG"] = CConstant.UN_SHIPMENT;
                }
                else if (CConvert.ToDecimal(_currentDt.Rows[i]["QUANTITY"]) != CConvert.ToDecimal(_currentDt.Rows[i]["SHIPMENT_QUANTITY"]))
                {
                    _currentDt.Rows[i]["SHIPMENT_NAME"] = "欠品";
                    _currentDt.Rows[i]["SHIPMENT_FLAG"] = CConstant.PART_SHIPMENT;
                }
                else
                {
                    _currentDt.Rows[i]["SHIPMENT_NAME"] = "完了";
                    _currentDt.Rows[i]["SHIPMENT_FLAG"] = CConstant.COMPLETE_SHIPMENT;
                }
                #endregion

                #region 生产
                if (CConstant.PRODUCE_DEFAULT.Equals(_currentDt.Rows[i]["PRODUCE_FLAG"]))
                {
                    _currentDt.Rows[i]["PRODUCE_NAME"] = "未确认";
                }
                else
                {
                    _currentDt.Rows[i]["PRODUCE_NAME"] = "已确认";
                }
                #endregion
            }

            if (!CConstant.PRODUCT_VALIDATION.Equals(CTag))
            {
                for (int i = _currentDt.Rows.Count; i < PageSize; i++)
                {
                    _currentDt.Rows.Add(_currentDt.NewRow());
                }
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
                string companyCode = CConvert.ToString(row.Cells["COMPANY_CODE"].Value);
                decimal amountIncludedTax = CConvert.ToDecimal(row.Cells["AMOUNT_INCLUDED_TAX"].Value);
                DateTime slipDate = CConvert.ToDateTime(row.Cells["SLIP_DATE"].Value);

                //在库引当
                if (CConstant.ORDER_ALLOATION.Equals(CTag) && companyCode.Equals(_userInfo.COMPANY_CODE))
                {
                    FrmBase frm = new FrmAlloation(slipNumber);
                    frm.UserTable = _userInfo;
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        BindData(this.pgControl.GetCurrentPage());
                    }
                    frm.Dispose();
                }
                //修理输入
                else if (CConstant.ORDER_SERVICE.Equals(CTag) && companyCode.Equals(_userInfo.COMPANY_CODE))
                {
                    FrmBase frm = new FrmOrderService(slipNumber);
                    frm.UserTable = _userInfo;
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        BindData(this.pgControl.GetCurrentPage());
                    }
                    frm.Dispose();
                }
                else
                {
                    FrmBase frm = new FrmOrdersEntry(slipNumber);
                    frm.CTag = CTag;
                    frm.UserTable = _userInfo;
                    //详细信息
                    if (CConstant.ORDER_SEARCH.Equals(CTag) || CConstant.PRODUCT_VALIDATION.Equals(CTag))
                    {
                        if (DialogResult.OK == frm.ShowDialog())
                        {

                        }
                        frm.Dispose();
                    }

                    //订单修正    
                    else if (CConstant.ORDER_MODIFY.Equals(CTag) && companyCode.Equals(_userInfo.COMPANY_CODE))
                    {
                        //承认后不能修改
                        if (CConstant.VERIFY.Equals(CConvert.ToInt32(row.Cells["VERIFY_FLAG"].Value)))
                        {
                            MessageBox.Show("订单已通知，不能修改。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (CConstant.COMPLETE_SHIPMENT.Equals(CConvert.ToInt32(row.Cells["SHIPMENT_FLAG"].Value)))
                        {
                            MessageBox.Show("订单已经出库完了，不能修改。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (CConstant.PART_SHIPMENT.Equals(CConvert.ToInt32(row.Cells["SHIPMENT_FLAG"].Value)))
                        {
                            MessageBox.Show("订单已经有出库，不能修改。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (DialogResult.OK == frm.ShowDialog())
                            {
                                BindData(this.pgControl.GetCurrentPage());
                            }
                            frm.Dispose();
                        }
                    }
                    //订单承认        
                    else if (CConstant.ORDER_VERIFY.Equals(CTag) && companyCode.Equals(_userInfo.COMPANY_CODE))
                    {
                        if (CConstant.COMPLETE_SHIPMENT.Equals(CConvert.ToInt32(row.Cells["SHIPMENT_FLAG"].Value)))
                        {
                            MessageBox.Show("订单己经出库完了，不能修改承认状态。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (CConstant.PART_SHIPMENT.Equals(CConvert.ToInt32(row.Cells["SHIPMENT_FLAG"].Value)))
                        {
                            MessageBox.Show("订单己经有出库，不能修改承认状态。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (CConstant.VERIFY.Equals(CConvert.ToInt32(row.Cells["VERIFY_FLAG"].Value)))
                        {
                            MessageBox.Show("订单已通知，不能重复通知。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (DialogResult.OK == frm.ShowDialog())
                        {
                            BindData(this.pgControl.GetCurrentPage());
                        }
                        frm.Dispose();
                    }
                    //复制订单     
                    else if (CConstant.ORDER_COPY.Equals(CTag))
                    {
                        if (DialogResult.OK == frm.ShowDialog())
                        {
                            BindData(this.pgControl.GetCurrentPage());
                        }
                        frm.Dispose();
                    }
                    //详细信息
                    else if (CConstant.ORDER_MASTER_SEARCH.Equals(CTag))
                    {
                        string a = row.Cells["VERIFY_NAME"].Value.ToString();
                        if (a.Equals("未通知"))
                        {
                            MessageBox.Show("请选择一张已通知订单。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            orderTable.SLIP_NUMBER = slipNumber;
                            orderTable.AMOUNT_INCLUDED_TAX = amountIncludedTax;
                            orderTable.SLIP_DATE = slipDate;
                            this.DialogResult = DialogResult.OK;
                        }
                        frm.Dispose();
                    }
                }
            }
            else
            {
                MessageBox.Show("请先选择一张订单。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if ("".Equals(CConvert.ToString(row.Cells["SLIP_NUMBER"].Value)))
                {
                    row.Selected = false;
                }
            }
        }

        #region datagridview 行点击事件
        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.RowIndex];
                if (e.ColumnIndex == dgvData.Columns["ATTACHED_NAME"].Index)
                {
                    //if (CConvert.ToInt32(row.Cells["ATTACHED_FLAG"].Value) > 0)
                    //{
                    //    string attachedDirectory = CCacheData.GetAttacheDirectory(CConstant.ATTACHE_DIRECTORY_ORDER);
                    //    string slipNumber = CConvert.ToString(row.Cells["SLIP_NUMBER"].Value);
                    //    FrmAttached frm = new FrmAttached(slipNumber, attachedDirectory, true);
                    //    frm.ShowDialog(this);
                    //    frm.Dispose();
                    //}

                    if (CConvert.ToString(row.Cells["SLIP_NUMBER"].Value) != "")
                    {
                        Czzd.Common.Library.FTPOperate myftp = new Czzd.Common.Library.FTPOperate("112.82.245.2", "YS_ERP\\order\\" + row.Cells["SLIP_NUMBER"].Value, "FTP_user", "czzd", 21);
                        string[] files = myftp.Dir("\\YS_ERP\\order\\" + row.Cells["SLIP_NUMBER"].Value);
                    //　附件
                        if (files.Length > 1)
                        {
                            string attachedDirectory = CCacheData.GetAttacheDirectory(CConstant.ATTACHE_DIRECTORY_ORDER);
                            string slipNumber = CConvert.ToString(row.Cells["SLIP_NUMBER"].Value);
                            FrmAttached frm = new FrmAttached(slipNumber, attachedDirectory, true);
                            frm.CTag = CConstant.ORDER_MODIFY;
                            frm.ShowDialog(this);
                            frm.Dispose();
                        }



                    }
                }
                else if (e.ColumnIndex == dgvData.Columns["UPDATED_COUNT"].Index)
                {
                    if (CConvert.ToInt32(row.Cells["UPDATED_COUNT"].Value) > 0)
                    {
                        FrmHistoryOrderList frm = new FrmHistoryOrderList(CConvert.ToString(row.Cells["SLIP_NUMBER"].Value));
                        if (DialogResult.OK == frm.ShowDialog(this))
                        {
                            FrmBase frmOrder = new FrmOrdersEntry(frm.historySlipNumber);
                            frmOrder.CTag = CConstant.ORDER_HISTORY;
                            frmOrder.UserTable = _userInfo;
                            frmOrder.ShowDialog();
                        }
                    }
                }
                else if (e.ColumnIndex == dgvData.Columns["CHECK"].Index)
                {
                    if (Convert.ToBoolean(dgvData.Rows[e.RowIndex].Cells["CHECK"].Value))
                    {
                        dgvData.Rows[e.RowIndex].Cells["CHECK"].Value = false;
                    }
                    else
                    {
                        dgvData.Rows[e.RowIndex].Cells["CHECK"].Value = true;
                    }
                }
            }
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

        #region 打印
        /// <summary>
        /// 
        /// </summary>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            #region delete
            //if (CConstant.PRODUCT_VALIDATION.Equals(CTag))
            //{
            //    if (CheckUnSure())
            //    {
            //        List<BllOrderHeaderTable> orderList = new List<BllOrderHeaderTable>();
            //        foreach (DataGridViewRow dgvr in dgvData.Rows)
            //        {
            //            if (Convert.ToBoolean(dgvr.Cells["CHECK"].Value) )
            //            {
            //                orderTable = bOrderHeader.GetModel(CConvert.ToString(dgvr.Cells["SLIP_NUMBER"].Value));
            //                if (orderTable != null)
            //                {
            //                    orderTable.PRODUCE_FLAG = CConstant.PRODUCE_SURE;
            //                }
            //                orderList.Add(orderTable);
            //            }
            //        }
            //        if (orderList.Count > 0)
            //        {
            //            if (DialogResult.OK == MessageBox.Show("确定要生产吗，确定后不能返回？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            //            {
            //                int result = bOrderHeader.UpdateProduce(orderList);
            //                 if (result <= 0)
            //                 {
            //                     MessageBox.Show("生产确定失败。", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            //                 }
            //                 else
            //                 {
            //                     BindData(this.pgControl.GetCurrentPage());
            //                 }
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("请先选择一张订单。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //    }
            //}
            //else
            //{
            //    _currentDt = bOrderHeader.GetPrintList(_currentConduction).Tables[0];
            //    for (int i = 0; i < _currentDt.Rows.Count; i++)
            //    {
            //        #region　审核
            //        if (CConstant.VERIFY.Equals(_currentDt.Rows[i]["VERIFY_FLAG"]))
            //        {
            //            _currentDt.Rows[i]["VERIFY_NAME"] = "审核通过";
            //        }
            //        else if (CConstant.NO_VERIFY.Equals(_currentDt.Rows[i]["VERIFY_FLAG"]))
            //        {
            //            _currentDt.Rows[i]["VERIFY_NAME"] = "审核未过";
            //        }
            //        else
            //        {
            //            _currentDt.Rows[i]["VERIFY_NAME"] = "未审核";
            //        }
            //        #endregion

            //        #region　附件
            //        if (CConstant.EXIST_ATTACHED.Equals(_currentDt.Rows[i]["ATTACHED_FLAG"]))
            //        {
            //            _currentDt.Rows[i]["ATTACHED_NAME"] = "有";
            //        }
            //        else
            //        {
            //            _currentDt.Rows[i]["ATTACHED_NAME"] = "无";
            //        }
            //        #endregion

            //        #region　引当
            //        if (CConstant.ALLOATION_COMPLETE.Equals(_currentDt.Rows[i]["ALLOATION_FLAG"]))
            //        {
            //            _currentDt.Rows[i]["ALLOATION_NAME"] = "完了";
            //        }
            //        else if (CConstant.ALLOATION_PART.Equals(_currentDt.Rows[i]["ALLOATION_FLAG"]))
            //        {
            //            _currentDt.Rows[i]["ALLOATION_NAME"] = "欠品";
            //        }
            //        else
            //        {
            //            _currentDt.Rows[i]["ALLOATION_NAME"] = "未引当";
            //        }
            //        #endregion

            //        #region　出库
            //        if (CConvert.ToDecimal(_currentDt.Rows[i]["SHIPMENT_QUANTITY"]) == 0)
            //        {
            //            _currentDt.Rows[i]["SHIPMENT_NAME"] = "未出库";
            //        }
            //        else if (CConvert.ToDecimal(_currentDt.Rows[i]["QUANTITY"]) != CConvert.ToDecimal(_currentDt.Rows[i]["SHIPMENT_QUANTITY"]))
            //        {
            //            _currentDt.Rows[i]["SHIPMENT_NAME"] = "欠品";
            //        }
            //        else
            //        {
            //            _currentDt.Rows[i]["SHIPMENT_NAME"] = "完了";
            //        }
            //        #endregion
            //    }
            //    if (isSearch && _currentDt != null)
            //    {
            //        int result = CExport.DataTableToExcel(_currentDt, CConstant.ORDER_HEADER, CConstant.ORDER_COLUMNS, "ORDER", "ORDER");
            //        if (result == CConstant.EXPORT_SUCCESS)
            //        {
            //            MessageBox.Show("数据已经成功导出!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //        else if (result == CConstant.EXPORT_FAILURE)
            //        {
            //            MessageBox.Show("数据导出失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("没有可以导出的数据。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            #endregion

            DataGridViewRow row = dgvData.CurrentRow;
            string slipNumber = CConvert.ToString(row.Cells["SLIP_NUMBER"].Value);
            if (!string.IsNullOrEmpty(slipNumber))
            {
                OrderPrintSetting frm = new OrderPrintSetting(slipNumber);
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

        public bool CheckUnSure()
        {
            string Errorlog = "";
            foreach (DataGridViewRow dgvr in dgvData.Rows)
            {
                if (Convert.ToBoolean(dgvr.Cells["CHECK"].Value))
                {
                    int produce = CConvert.ToInt32(dgvr.Cells["PRODUCE_FLAG"].Value);
                    if (produce == CConstant.PRODUCE_SURE)
                    {
                        Errorlog += "订单" + CConvert.ToString(dgvr.Cells["SLIP_NUMBER"].Value) + "已确认生产。\r\n";
                    }
                }
            }
            if (!string.IsNullOrEmpty(Errorlog))
            {
                MessageBox.Show(Errorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        #endregion

        #region 生产通知单
        private void btnProduce_Click(object sender, EventArgs e)
        {
            if (CheckSure())
            {
                List<DataTable> orderList = new List<DataTable>();
                List<Hashtable> hashTable = new List<Hashtable>();
                DataTable dt = new DataTable();
                string[] a = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N" };
                dt.Columns.Add("NO");
                dt.Columns.Add("SLIPTYPE");
                dt.Columns.Add("X_1");
                dt.Columns.Add("X_2");
                dt.Columns.Add("SLIPNUMBER");
                dt.Columns.Add("CUSTOMER");
                dt.Columns.Add("DATE");
                dt.Columns.Add("MEMO");
                //dt.Columns.Add("QUANTITY");
                int i = 1;

                foreach (DataGridViewRow dgvr in dgvData.Rows)
                {
                    if (Convert.ToBoolean(dgvr.Cells["CHECK"].Value))
                    {
                        orderTable = bOrderHeader.GetModel(CConvert.ToString(dgvr.Cells["SLIP_NUMBER"].Value));

                        if (orderTable != null)
                        {
                            DataRow row = dt.NewRow();
                            row["NO"] = i;
                            row["SLIPTYPE"] = bCommon.GetBaseMaster("SLIP_TYPE", orderTable.SLIP_TYPE).Name;
                            row["SLIPNUMBER"] = orderTable.SLIP_NUMBER;
                            row["CUSTOMER"] = orderTable.ENDER_CUSTOMER_NAME;
                            row["DATE"] = orderTable.DUE_DATE;
                            row["MEMO"] = orderTable.MEMO;
                            //row["QUANTITY"]= orderTable.
                            dt.Rows.Add(row);

                            DataTable dt2 = new DataTable();
                            dt2.Columns.Add("NO");
                            dt2.Columns.Add("PRODUCT_NAME");
                            dt2.Columns.Add("X_1");
                            dt2.Columns.Add("X_2");
                            dt2.Columns.Add("QUANTITY");
                            dt2.Columns.Add("X_3");
                            dt2.Columns.Add("X_4");
                            dt2.Columns.Add("X_5");
                            dt2.Columns.Add("X_6");
                            dt2.Columns.Add("X_7");
                            dt2.Columns.Add("X_8");
                            dt2.Columns.Add("MEMO");

                            int j = 1;
                            foreach (BllOrderLineTable line in orderTable.Items)
                            {
                                DataRow dr = dt2.NewRow();
                                dr["NO"] = j++;
                                dr["PRODUCT_NAME"] = line.PRODUCT_NAME;
                                dr["QUANTITY"] = (int)line.QUANTITY / orderTable.QUANTITY;
                                dr["MEMO"] = line.MEMO;
                                dt2.Rows.Add(dr);
                            }
                            orderList.Add(dt2);

                            Hashtable ht = new Hashtable();
                            ht.Add("&SLIP_TYPE", bCommon.GetBaseMaster("SLIP_TYPE", orderTable.SLIP_TYPE).Name);
                            ht.Add("&QUANTITY", ((int)orderTable.QUANTITY).ToString() + "套");
                            //ht.Add("&YEAR", CConvert.ToDateTime(orderTable.SLIP_DATE).ToString("yyyy"));
                            //ht.Add("&MONTH", CConvert.ToDateTime(orderTable.SLIP_DATE).ToString("MM"));
                            ht.Add("&NAME", "生产通知单" + a[i - 1]);
                            ht.Add("&PONUMBER", orderTable.CUSTOMER_PO_NUMBER);
                            ht.Add("&DUEDATE", CConvert.ToDateTime(orderTable.DUE_DATE).ToString("yyyy") + "月" + CConvert.ToDateTime(orderTable.DUE_DATE).ToString("MM") + "日");
                            ht.Add("&SLIPNUMBER", orderTable.SLIP_NUMBER);
                            ht.Add("&CUSTOMER", orderTable.ENDER_CUSTOMER_NAME);
                            hashTable.Add(ht);
                            i++;
                        }
                    }
                }

                if (dt.Rows.Count > 0)
                {
                    SaveFileDialog sf = new SaveFileDialog();
                    sf.FileName = "HD_PRODUCTION_ORDERS_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                    sf.Filter = "(文件)|*.xls;*.xlsx";
                    if (sf.ShowDialog(this) == DialogResult.OK)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            int ret = CExport.DataTableToExcel_Production_Orders(@"rpt\HD_PRODUCTION_ORDERS.xls", sf.FileName, dt, orderList, hashTable);
                            if (CConstant.EXPORT_FAILURE.Equals(ret))
                            {
                                MessageBox.Show("导出失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else if (CConstant.EXPORT_SUCCESS.Equals(ret))
                            {
                                MessageBox.Show("导出成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (CConstant.EXPORT_RUNNING.Equals(ret))
                            {
                                MessageBox.Show("文件正在运行，重新生成文件失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else if (CConstant.EXPORT_TEMPLETE_FILE_NOT_EXIST.Equals(ret))
                            {
                                MessageBox.Show("模版文件不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBox.Show("明细信息不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请先选择一张订单。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public bool CheckSure()
        {
            string Errorlog = "";
            foreach (DataGridViewRow dgvr in dgvData.Rows)
            {
                if (Convert.ToBoolean(dgvr.Cells["CHECK"].Value))
                {
                    string produce = CConvert.ToString(dgvr.Cells["PRODUCE_NAME"].Value);
                    if (produce == "未生产")
                    {
                        Errorlog += "订单" + CConvert.ToString(dgvr.Cells["SLIP_NUMBER"].Value) + "还未确定生产。\r\n";
                    }
                }
            }
            if (!string.IsNullOrEmpty(Errorlog))
            {
                MessageBox.Show(Errorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        #endregion

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
                    txtSales.Text = frm.BaseMasterTable.Name;
                    txtSalesCode.Text = frm.BaseMasterTable.Code.Substring(2);
                    //txtWarehouseCode.Focus();
                }
            }
            frm.Dispose();
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

        private void btnSales_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find_over);

        }

        private void btnSales_MouseLeave(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find);
        }

    }//end class
}
