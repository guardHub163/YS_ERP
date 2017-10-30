using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Common;
using CZZD.ERP.Model;
using CZZD.ERP.Bll;
using CZZD.ERP.WinUI.Properties;

namespace CZZD.ERP.WinUI
{
    public partial class FrmTransferReceiptSearch : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private DataTable _currentDt = new DataTable();
        private bool isSearch = false;

        public FrmTransferReceiptSearch()
        {
            InitializeComponent();
        }

        private void FrmTransferReceiptSearch_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;

            #region dgvData 初始化
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;

            PageSize = 14;
            dgvData.Rows.Add(PageSize);
            dgvData.Rows[0].Selected = true;
            #endregion

            //txtSlipDateFrom.Value = DateTime.Now.AddDays(1 - DateTime.Now.Day);
            //txtSlipDateTo.Value = txtSlipDateFrom.Value.AddMonths(1).AddDays(-1); 
        }

        #region 调出仓库
        private void btnDepartual_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("WAREHOUSE", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtDepartualCode.Text = frm.BaseMasterTable.Code;
                    txtDepartualName.Text = frm.BaseMasterTable.Name;
                    txtArrivalCode.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtDepartualCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtDepartualCode.Text.Trim()))
            {
                BaseWarehouseTable Warehouse = new BaseWarehouseTable();
                BWarehouse bWarehouse = new BWarehouse();
                Warehouse = bWarehouse.GetModel(this.txtDepartualCode.Text);
                if (Warehouse == null || "".Equals(Warehouse))
                {
                    txtDepartualCode.Focus();
                    txtDepartualCode.Text = "";
                    txtDepartualName.Text = "";
                    MessageBox.Show("仓库编号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtDepartualCode.Text = Warehouse.CODE;
                    txtDepartualName.Text = Warehouse.NAME;
                }
            }
            else
            {
                txtDepartualName.Text = "";
            }
        }
        #endregion

        #region 调入仓库
        private void btnArrival_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("WAREHOUSE", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtArrivalCode.Text = frm.BaseMasterTable.Code;
                    txtArrivalName.Text = frm.BaseMasterTable.Name;
                    btnSearch.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtArrivalCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtArrivalCode.Text.Trim()))
            {
                BaseWarehouseTable Warehouse = new BaseWarehouseTable();
                BWarehouse bWarehouse = new BWarehouse();
                Warehouse = bWarehouse.GetModel(this.txtArrivalCode.Text);
                if (Warehouse == null || "".Equals(Warehouse))
                {
                    txtArrivalCode.Focus();
                    txtArrivalCode.Text = "";
                    txtArrivalName.Text = "";
                    MessageBox.Show("仓库编号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtArrivalCode.Text = Warehouse.CODE;
                    txtArrivalName.Text = Warehouse.NAME;
                }
            }
            else
            {
                txtArrivalName.Text = "";
            }
        }
        #endregion

        #region 查询分页
        private void btnSearch_Click(object sender, EventArgs e)
        {            
            int currentPage = 1;
            int recordCount = bTransfer.GetRecordCount(GetConduction());
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
            DataSet ds = bTransfer.GetList(strWhere, "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);
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
            if (txtSlipNumber.Text.Trim() != "")
            {
                sb.AppendFormat(" and SLIP_NUMBER like '{0}%'", txtSlipNumber.Text.Trim());
            }

            if (txtSlipDateFrom.Checked)
            {
                sb.AppendFormat(" and SLIP_DATE >= '{0}'", txtSlipDateFrom.Value.ToShortDateString());
            }
            else if (txtSlipDateTo.Checked)
            {
                sb.AppendFormat(" and SLIP_DATE < '{0}'", txtSlipDateTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }

            if (txtDepartualCode.Text.Trim() != "")
            {
                sb.AppendFormat(" and DEPARTUAL_WAREHOUSE_CODE like '{0}%'", txtDepartualCode.Text.Trim());
            }

            if (txtArrivalCode.Text.Trim() != "")
            {
                sb.AppendFormat(" and ARRIVAL_WAREHOUSE_CODE like '{0}%'", txtArrivalCode.Text.Trim());
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

        #region 关闭
        private void button4_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确定要关闭吗？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                this.Close();
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

        #region 控制空行不能被点击
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

        #region 导出
        private void btnPrint_Click(object sender, EventArgs e)
        {
            _currentDt = bTransfer.GetPrintList(GetConduction()).Tables[0];
            if (isSearch && _currentDt != null)
            {
                SaveFileDialog sf = new SaveFileDialog();
                sf.FileName = "HD_TRANSFER_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
                sf.Filter = "(文件)|*.xls;*.xlsx";

                string header = "调拨编号\t调拨日期\t调拨明细行号\t商品编号\t商品名称\t调出仓库编号\t调出仓库名称\t调入仓库编号\t调入仓库名称\t" +
                                 "调拨数量\t单位编号\t单位名称\t公司编号\t公司名称\t状态\t创建人\t创建时间\t最后更新人\t最后更新时间\t\n";
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
    }//end class
}
