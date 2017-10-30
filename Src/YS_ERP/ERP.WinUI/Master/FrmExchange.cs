﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.CacheData;
using CZZD.ERP.Common;
using CZZD.ERP.Bll;
using CZZD.ERP.Model;

namespace CZZD.ERP.WinUI
{
    public partial class FrmExchange : FrmBase
    {
        private BExchange bExchange = new BExchange();
        private DataTable _currentDt = new DataTable();
        private BaseExchangeTable _currentExchangeTable;
        private bool isSearch = false;

        public FrmExchange()
        {
            InitializeComponent();
        }

        private void FrmExchange_Load(object sender, EventArgs e)
        {
            init();
            this.WindowState = FormWindowState.Normal;
        }

        #region 页面初始化
        private void init()
        {
            #region dgvData
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;

            _currentDt.Columns.Add("EXCHANGE_DATE", Type.GetType("System.String"));
            _currentDt.Columns.Add("FROM_CURRENCY_CODE", Type.GetType("System.String"));
            _currentDt.Columns.Add("FROM_CURRENCY_NAME", Type.GetType("System.String"));
            _currentDt.Columns.Add("EXCHANGE_RATE", Type.GetType("System.String"));
            _currentDt.Columns.Add("STATUS_FLAG", Type.GetType("System.String"));
            _currentDt.Columns.Add("CREATE_USER", Type.GetType("System.String"));
            _currentDt.Columns.Add("CREATE_DATE_TIME", Type.GetType("System.String"));
            _currentDt.Columns.Add("LAST_UPDATE_USER", Type.GetType("System.String"));
            _currentDt.Columns.Add("LAST_UPDATE_TIME", Type.GetType("System.String"));
            DataRow row = null;
            for (int i = 1; i <= 20; i++)
            {
                row = _currentDt.NewRow();
                _currentDt.Rows.Add(row);
            }
            this.dgvData.DataSource = _currentDt;
            #endregion

            #region 通货的初始化
            //通货的初始化
            cboCurrency.ValueMember = "CODE";
            cboCurrency.DisplayMember = "NAME";
            cboCurrency.DataSource = CCacheData.Currency;
            #endregion
        }

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
                if (row.Cells["FROM_CURRENCY_CODE"].Value == null || "".Equals(row.Cells["FROM_CURRENCY_CODE"].Value.ToString()))
                {
                    row.Selected = false;
                }
            }
        }
        #endregion

        #region  页面事件
        /// <summary>
        /// 当前页码发生变化时的操作
        /// </summary>
        private void pgControl_PageChanged(object sender, EventArgs e, int currentPage)
        {
            BindData(currentPage);
        }

        /// <summary>
        /// gridView双击事件
        /// </summary>
        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            GetCurrentSelectedTable();
            OpenDialogFrm(CConstant.MODE_MODIFY);
        }
        #endregion

        #region 工具条事件
        /// <summary>
        /// 新建
        /// </summary>
        private void MasterToolBar_DoNew_Click(object sender, EventArgs e)
        {
            OpenDialogFrm(CConstant.MODE_NEW);
        }

        /// <summary>
        /// 复制
        /// </summary>
        private void MasterToolBar_DoCopy_Click(object sender, EventArgs e)
        {
            GetCurrentSelectedTable();
            OpenDialogFrm(CConstant.MODE_COPY);
        }

        /// <summary>
        /// 删除
        /// </summary>
        private void MasterToolBar_DoDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要删除吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                try
                {
                    GetCurrentSelectedTable();
                    if (_currentExchangeTable != null)
                    {
                        bExchange.Delete(_currentExchangeTable.EXCHANGE_DATE, _currentExchangeTable.FROM_CURRENCY_CODE);
                        Search(this.pgControl.GetCurrentPage());
                    }
                    else
                    {
                        MessageBox.Show("请选择正确的行!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("删除失败，请重试或与系统管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                _currentExchangeTable = null;
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        private void MasterToolBar_DoModify_Click(object sender, EventArgs e)
        {
            GetCurrentSelectedTable();
            OpenDialogFrm(CConstant.MODE_MODIFY);
        }

        /// <summary>
        /// 查询
        /// </summary>
        private void MasterToolBar_DoSearch_Click(object sender, EventArgs e)
        {
            isSearch = true;
            Search(1);
        }

        /// <summary>
        /// 导出
        /// </summary>
        private void MasterToolBar_DoExport_Click(object sender, EventArgs e)
        {
            _currentDt = bExchange.GetList(GetConduction()).Tables[0];
            if (isSearch && _currentDt != null)
            {
                foreach (DataRow row in _currentDt.Rows)
                {
                    try
                    {
                        if (row["FROM_CURRENCY_CODE"] != null && bCommon.GetBaseMaster("CURRENCY", CConvert.ToString(row["FROM_CURRENCY_CODE"])) != null)
                        {
                            row["FROM_CURRENCY_NAME"] = bCommon.GetBaseMaster("CURRENCY", CConvert.ToString(row["FROM_CURRENCY_CODE"])).Name;
                        }
                        if (row["CREATE_USER"] != null && bCommon.GetBaseMaster("USER", CConvert.ToString(row["CREATE_USER"])) != null)
                        {
                            row["CREATE_USER"] = bCommon.GetBaseMaster("USER", CConvert.ToString(row["CREATE_USER"])).Name;
                        }
                        if (row["LAST_UPDATE_USER"] != null && bCommon.GetBaseMaster("USER", CConvert.ToString(row["LAST_UPDATE_USER"])) != null)
                        {
                            row["LAST_UPDATE_USER"] = bCommon.GetBaseMaster("USER", CConvert.ToString(row["LAST_UPDATE_USER"])).Name;
                        }
                    }
                    catch { }
                }
                SaveFileDialog sf = new SaveFileDialog();
                sf.FileName = "LZ_EXCHANGE_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
                sf.Filter = "(文件)|*.xls;*.xlsx";

                string header = "汇率时间\t货币编号\t货币名称\t汇率\t状态\t创建人员\t创建时间\t最后更新人\t最后更新时间\t\n";
                if (sf.ShowDialog(this) == DialogResult.OK)
                {
                    int result = CExport.DataTableToCsv(_currentDt, header, sf.FileName);
                    if (result == 0)
                    {
                        MessageBox.Show("导出成功!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        private void MasterToolBar_DoCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 查询
        /// <summary>
        /// 查询
        /// </summary>
        private void Search(int currentPage)
        {
            int recordCount = bExchange.GetRecordCount(GetConduction());
            if (recordCount < 0)
            {
                MessageBox.Show("查询的信息不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //分页标签初始化
            this.pgControl.init(GetTotalPage(recordCount), currentPage);

            //数据绑定
            BindData(currentPage);

            //初始化工具条
            this.MasterToolBar.SetMasterToolsBar(GetDataTabelRowsCount(_currentDt));
        }

        /// <summary>
        /// 获得查询条件
        /// </summary>
        private string GetConduction()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" STATUS_FLAG <> {0}", CConstant.DELETE);
            if (Exchangedate.Checked)
            {
                sb.AppendFormat(" and EXCHANGE_DATE = '{0}'", CConvert.ToDateTime(Exchangedate.Value.ToString("yyyy-MM")));
            }
            sb.AppendFormat(" and FROM_CURRENCY_CODE = '{0}'", cboCurrency.SelectedValue);
           
            return sb.ToString();
        }

        /// <summary>
        /// 数据查询,绑定
        /// </summary>
        private void BindData(int currentPage)
        {
            string strWhere = GetConduction();
            DataSet ds = bExchange.GetList(strWhere, "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);
            _currentDt = ds.Tables[0];
            _currentDt.Columns.Add("FROM_CURRENCY_NAME", Type.GetType("System.String"));
            foreach (DataRow row in _currentDt.Rows)
            {
                try
                {
                    if (row["FROM_CURRENCY_CODE"] != null && bCommon.GetBaseMaster("CURRENCY", CConvert.ToString(row["FROM_CURRENCY_CODE"])) != null)
                    {
                        row["FROM_CURRENCY_NAME"] = bCommon.GetBaseMaster("CURRENCY", CConvert.ToString(row["FROM_CURRENCY_CODE"])).Name;
                    }
                    if (row["CREATE_USER"] != null && bCommon.GetBaseMaster("USER", CConvert.ToString(row["CREATE_USER"])) != null)
                    {
                        row["CREATE_USER"] = bCommon.GetBaseMaster("USER", CConvert.ToString(row["CREATE_USER"])).Name;
                    }
                    if (row["LAST_UPDATE_USER"] != null && bCommon.GetBaseMaster("USER", CConvert.ToString(row["LAST_UPDATE_USER"])) != null)
                    {
                        row["LAST_UPDATE_USER"] = bCommon.GetBaseMaster("USER", CConvert.ToString(row["LAST_UPDATE_USER"])).Name;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            for (int i = _currentDt.Rows.Count; i < PageSize; i++)
            {
                _currentDt.Rows.Add(ds.Tables[0].NewRow());
            }
            this.dgvData.DataSource = _currentDt;
        }
        #endregion

        /// <summary>
        /// 打开新窗口
        /// </summary>
        private void OpenDialogFrm(int mode)
        {
            if (mode == CConstant.MODE_NEW || _currentExchangeTable != null)
            {
                FrmExchangeDialog frm = new FrmExchangeDialog();
                frm.UserInfo = _userInfo;
                frm.CurrentExchangeTable = _currentExchangeTable;
                frm.Mode = mode;
                DialogResult resule = frm.ShowDialog(this);
                if (resule == DialogResult.OK && isSearch)
                {
                    Search(this.pgControl.GetCurrentPage());
                }
                frm.Dispose();
            }
            else
            {
                //MessageBox.Show("请选择正确的行!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            _currentExchangeTable = null;

        }

        /// <summary>
        /// 获得当前选中的数据
        /// </summary>
        private void GetCurrentSelectedTable()
        {
            try
            {
                DateTime date = CConvert.ToDateTime(CConvert.ToDateTime(dgvData.SelectedRows[0].Cells["EXCHANGE_DATE"].Value).ToString("yyyy-MM"));
                string currency = CConvert.ToString(dgvData.SelectedRows[0].Cells["FROM_CURRENCY_CODE"].Value);
                if (date != null && !string.IsNullOrEmpty(currency ))
                {
                    _currentExchangeTable = bExchange.GetModel(date, currency);
                }
            }
            catch (Exception ex) { }

            if (_currentExchangeTable == null || _currentExchangeTable.FROM_CURRENCY_CODE == null || "".Equals(_currentExchangeTable.FROM_CURRENCY_CODE))
            {
                _currentExchangeTable = null;
            }
        }        
    }
}
