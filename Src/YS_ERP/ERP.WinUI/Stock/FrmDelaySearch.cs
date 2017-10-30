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
using CZZD.ERP.CacheData;

namespace CZZD.ERP.WinUI
{
    public partial class FrmDelaySearch : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private DataTable _currentDt = new DataTable();
        private bool isSearch = false; 

        public FrmDelaySearch()
        {
            InitializeComponent();
        }

        private void FrmDelaySearch_Load(object sender, EventArgs e)
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

            #region cboDate初始化
            //this.cboDate.Items.Add("90日");
            //this.cboDate.Items.Add("180日");
            //this.cboDate.Items.Add("一年");
            //this.cboDate.SelectedIndex = 0;
            cboDate.ValueMember = "CODE";
            cboDate.DisplayMember = "NAME";
            cboDate.DataSource = CCacheData.Delay;
            #endregion

        }

        #region DataGridView空行不能被点击
        private void dgvData_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Index >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.Row.Index];
                if (row.Cells["CODE"].Value == null || "".Equals(row.Cells["CODE"].Value.ToString()))
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

        #region 调出仓库
        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("WAREHOUSE", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtWarehouse.Text = frm.BaseMasterTable.Code;
                    txtWarehouseName.Text = frm.BaseMasterTable.Name;
                    txtProductGroup.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtWarehouse_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtWarehouse.Text.Trim()))
            {
                BaseWarehouseTable Warehouse = new BaseWarehouseTable();
                BWarehouse bWarehouse = new BWarehouse();
                Warehouse = bWarehouse.GetModel(this.txtWarehouse.Text);
                if (Warehouse == null || "".Equals(Warehouse))
                {
                    txtWarehouse.Focus();
                    txtWarehouse.Text = "";
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

        #region 商品分类
        //btnProductGrou 键点击事件
        private void btnProductGroup_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("PRODUCT_GROUP", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtProductGroup.Text = frm.BaseMasterTable.Code;
                    txtProductGroupName.Text = frm.BaseMasterTable.Name;
                    cboDate.Focus();
                }
            }
            frm.Dispose();
        }
        // txtProductGroup 离开事件
        private void txtProductGroup_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtProductGroup.Text.Trim()))
            {
                BaseProductGroupTable ProductGroup = new BaseProductGroupTable();
                BProductGroup bProductGroup = new BProductGroup();
                ProductGroup = bProductGroup.GetModel(this.txtProductGroup.Text);
                if (ProductGroup == null || "".Equals(ProductGroup))
                {
                    txtProductGroup.Focus();
                    txtProductGroup.Text = "";
                    txtProductGroupName.Text = "";
                    MessageBox.Show("商品分类不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtProductGroupName.Text = ProductGroup.NAME;
                }
            }
            else
            {
                txtProductGroupName.Text = "";
            }
        }
        #endregion

        #region 查询
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int currentPage = 1;
            int recordCount = bStock.GetDelayRecordCount(GetConduction());
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
        /// 绑定数据
        /// </summary>
        /// <param name="currentPage"></param>
        private void BindData(int currentPage)
        {
            string strWhere = GetConduction();
            DataSet ds = bStock.GetDelayList(strWhere, "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);
            _currentDt = ds.Tables[0];
            reSetCurrentDt();
            this.dgvData.DataSource = _currentDt;
        }

        /// <summary>
        /// 获得查询条件
        /// </summary>
        /// <returns></returns>
        private string GetConduction()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" STATUS_FLAG <> {0}", CConstant.DELETE);
            if (cboDate.SelectedValue.ToString() == "1")
            {
                sb.AppendFormat(" and GETDATE() - LAST_SHIPMENT_DATE  >= {0}", 90);
            }
            else if (cboDate.SelectedValue.ToString() == "2")
            {
                sb.AppendFormat(" and GETDATE() - LAST_SHIPMENT_DATE > {0}", 180);
            }
            else if (cboDate.SelectedValue.ToString() == "3")
            {
                sb.AppendFormat(" and GETDATE() - LAST_SHIPMENT_DATE > {0}", 365);
            }
            if (txtWarehouse.Text.Trim() != "")
            {
                sb.AppendFormat("and WAREHOUSE_CODE like '{0}%'", txtWarehouse.Text.Trim());
            }

            if (txtProductGroup.Text.Trim() != null)
            {
                sb.AppendFormat("and GROUP_CODE like '{0}%'", txtProductGroup.Text.Trim());
            }
            return sb.ToString();
        }

        /// <summary>
        /// 页面发生变化时发生事件
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

        #region 导出
        private void btnPrint_Click(object sender, EventArgs e)
        {
            _currentDt = bStock.GetDelayPrintList(GetConduction()).Tables[0];
            if (_currentDt.Rows.Count > 0 && isSearch)
            {
                SaveFileDialog sf = new SaveFileDialog();
                sf.FileName = "HD_DELAY_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
                sf.Filter = "(文件)|*.xls;*.xlsx";

                string header = "商品编号\t商品名称\t商品规格\t单位编号\t单位名称\t商品分类编号\t商品分类名称\t在库数\t" + 
                                "仓库编号\t仓库名称\t最后出库时间\t最后入库时间\t状态\t创建人\t创建时间\t最后更新人\t最后更新时间\t\n";
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
