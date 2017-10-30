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
    public partial class FrmInventorySearch : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private DataTable _currentDt = new DataTable();
        private bool isSearch = false;

        public FrmInventorySearch()
        {
            InitializeComponent();
        }

        private void FrmInventorySearch_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;

            btnPrint.Enabled = false;
            btnPrint.Visible = false;
            if (CConstant.INVENTORY_SEARCH.Equals(CTag))
            {
                btnOperate.Text = "详细";
                btnPrint.Enabled = true;
                btnPrint.Visible = true;
            }
            if (CConstant.INVENTORY_END.Equals(CTag))
            {
                btnOperate.Text = "结果输入";
            }

            init();
        }

        #region 初始化
        public void init()
        {
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;

            PageSize = 14;
            dgvData.Rows.Add(PageSize);
            dgvData.Rows[0].Selected = true;

            //txtStartDate.Value = DateTime.Now.AddDays(1 - DateTime.Now.Day);
            //txtEndDate.Value = txtStartDate.Value.AddMonths(1).AddDays(-1); 
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
                    btnSearch.Focus();
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
            else
            {
                txtWarehouseName.Text = "";
            }
        }
        #endregion

        #region 查询分页

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search(1);      
        }

        public void Search(int currentPage)
        {
            int recordCount = bInventory.GetSearchRecordCount(GetConduction());
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
            DataSet ds = bInventory.GetSearchList(strWhere, "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);

            dgvData.Rows.Clear();
            foreach (DataRow rows in ds.Tables[0].Rows)
            {
                int currentRowIndex = dgvData.Rows.Add(1);
                DataGridViewRow row = dgvData.Rows[currentRowIndex];

                row.Cells[1].Selected = false;
                row.Cells["No"].Value = rows["Row"];
                row.Cells["SLIP_NUMBER"].Value = rows["SLIP_NUMBER"];
                row.Cells["START_DATE"].Value = rows["START_DATE"];
                row.Cells["WAREHOUSE_NAME"].Value = bCommon.GetBaseMaster("WAREHOUSE", rows["WAREHOUSE_CODE"].ToString()).Name;
                if (CConvert.ToInt32(rows["STATUE_FLAG"]) == 0)
                {
                    row.Cells["STATUE"].Value = "未盘点";
                }
                else if (CConvert.ToInt32(rows["STATUE_FLAG"]) == 1)
                {
                    row.Cells["STATUE"].Value = "盘点了一部分";
                } else if (CConvert.ToInt32(rows["STATUE_FLAG"]) == 2)
                {
                    row.Cells["STATUE"].Value = "盘点结束";
                }
            }
            if (ds.Tables[0].Rows.Count < PageSize)
            {
                dgvData.Rows.Add(PageSize - ds.Tables[0].Rows.Count);
            }
        }

        /// <summary>
        /// 获得查询条件
        /// </summary>
        private string GetConduction()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" STATUE_FLAG <> {0}", CConstant.DELETE);
            if (txtSlipNumber.Text.Trim() != "")
            {
                sb.AppendFormat(" and SLIP_NUMBER like '{0}%'", txtSlipNumber.Text.Trim());
            }

            if (txtStartDate.Checked && txtEndDate.Checked)
            {
                sb.AppendFormat(" and START_DATE between '{0}' and '{1}'", txtStartDate.Value.ToShortDateString(), txtEndDate.Value.AddDays(1).ToShortDateString());
            }
            else if (txtStartDate.Checked)
            {
                sb.AppendFormat(" and START_DATE > '{0}'", txtStartDate.Value.ToShortDateString());
            }
            else if (txtEndDate.Checked)
            {
                sb.AppendFormat(" and START_DATE <= '{0}'", txtEndDate.Value.AddDays(1).ToShortDateString());
            }

            if (txtWarehouseCode.Text.Trim() != "")
            {
                sb.AppendFormat("and WAREHOUSE_CODE = '{0}'", txtWarehouseCode.Text.Trim());
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

        #region 
        private void btnOperate_Click(object sender, EventArgs e)
        {
            try
            {
                string slipnumber = dgvData.SelectedRows[0].Cells["SLIP_NUMBER"].Value.ToString();
                //BllInventoryTable inventory = bInventory.GetInventoryModel(slipnumber);
                //DataSet ds = bInventory.GetLine(slipnumber);
                if (slipnumber != null)
                {
                    if (CConstant.INVENTORY_SEARCH.Equals(CTag))
                    {
                        FrmInventoryStart frm = new FrmInventoryStart();
                        frm.SLIP_NUMBER = slipnumber;
                        frm.UserInfo = _userInfo;
                        frm.STATUS_FLAG = CConstant.INVENTORY_SEARCH;
                        frm.MaximizeBox = false;
                        frm.MinimizeBox = false;
                        DialogResult resule = frm.ShowDialog(this);

                        frm.Dispose();
                    }
                    if (CConstant.INVENTORY_END.Equals(CTag))
                    {
                        if (!dgvData.SelectedRows[0].Cells["STATUE"].Value.ToString().Equals("盘点结束"))
                        {
                        FrmInventoryStart frm = new FrmInventoryStart();
                        frm.SLIP_NUMBER = slipnumber;
                        frm.UserInfo = _userInfo;
                        frm.STATUS_FLAG = CConstant.INVENTORY_END;
                        frm.MaximizeBox = false;
                        frm.MinimizeBox = false;
                        DialogResult resule = frm.ShowDialog(this);
                        if (resule == DialogResult.OK)
                        {
                            Search(this.pgControl.GetCurrentPage());
                        }
                        frm.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("该仓库已盘点结束，不能再盘点!");
                        }
                    }
                }
            }
            catch {
                MessageBox.Show("请选择正确的行!");
            }
        }
        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
             _currentDt = bInventory.GetEndPrintList(GetConduction()).Tables[0];
             if (_currentDt.Rows.Count > 0 && isSearch)
             {
                 SaveFileDialog sf = new SaveFileDialog();
                 sf.FileName = "HD_INVENTORY_SEARCH_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
                 sf.Filter = "(文件)|*.xls;*.xlsx";

                 string header = "盘点编号\t仓库编号\t仓库名称\t公司编号\t公司名称\t盘点开始日期\t盘点结束日期\t状态\t创建人\t" +
                                 "创建时间\t最后更新人\t最后更新时间\t盘点明细行号\t商品编号\t商品名称\t在库数\t实际在库数\t明细状态\n";
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
    }
}
