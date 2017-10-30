using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.CacheData;
using CZZD.ERP.Bll;
using CZZD.ERP.Model;
using CZZD.ERP.Common;

namespace CZZD.ERP.WinUI
{
    public partial class FrmSlipTypeCompositionProducts : FrmBase
    {
        private DataTable _currentDt = new DataTable();
        private BSlipTypeCompositionProducts bSlipTypeCompositionProducts = new BSlipTypeCompositionProducts();
        private BaseSlipTypeCompositionProductsTable _currentSlipTypeCompositionProductsTable;
        private bool isSearch = false;

        public FrmSlipTypeCompositionProducts()
        {
            InitializeComponent();
        }

        private void FrmSlipTypeCompositionProducts_Load(object sender, EventArgs e)
        {
            #region 主机的初始化
            //订单类型的初始化          
            DataTable pstDT = CCacheData.SlipType.Copy();
            DataRow dr = pstDT.NewRow();
            pstDT.Rows.InsertAt(dr, 0);
            dr["CODE"] = "";
            dr["NAME"] = "全部";
            cboSlipType.ValueMember = "CODE";
            cboSlipType.DisplayMember = "NAME";
            cboSlipType.DataSource = pstDT;
            #endregion

            PageSize = 18;
            this.WindowState = FormWindowState.Normal;
            init();
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

            _currentDt.Columns.Add("PRODUCT_CODE", Type.GetType("System.String"));
            _currentDt.Columns.Add("PRODUCT_NAME", Type.GetType("System.String"));
            _currentDt.Columns.Add("PRODUCT_PARTS_CODE", Type.GetType("System.String"));
            _currentDt.Columns.Add("QUANTITY", Type.GetType("System.String"));
            _currentDt.Columns.Add("CREATE_USER", Type.GetType("System.String"));
            _currentDt.Columns.Add("CREATE_DATE_TIME", Type.GetType("System.String"));
            _currentDt.Columns.Add("LAST_UPDATE_USER", Type.GetType("System.String"));
            _currentDt.Columns.Add("LAST_UPDATE_TIME", Type.GetType("System.String"));

            DataRow row = null;
            for (int i = 1; i <= PageSize; i++)
            {
                row = _currentDt.NewRow();
                _currentDt.Rows.Add(row);
            }
            this.dgvData.DataSource = _currentDt;
            #endregion
        }

        #region  页面事件
        /// <summary>
        /// 当前面码发生变化时的操作
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
                    if (_currentSlipTypeCompositionProductsTable != null)
                    {
                        bSlipTypeCompositionProducts.Delete(_currentSlipTypeCompositionProductsTable.SLIP_TYPE_CODE, _currentSlipTypeCompositionProductsTable.COMPOSITION_PRODUCTS_CODE);
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
                _currentSlipTypeCompositionProductsTable = null;
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
            _currentDt = bSlipTypeCompositionProducts.GetList(GetConduction()).Tables[0];
            if (isSearch && _currentDt.Rows.Count > 0)
            {
                int result = CExport.DataTableToExcel(_currentDt, CConstant.MACHINE_HEADER, CConstant.MACHINE_COLUMNS, "MACHINE", "MACHINE");
                if (result == CConstant.EXPORT_SUCCESS)
                {
                    MessageBox.Show("数据已经成功导出!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (result == CConstant.EXPORT_FAILURE)
                {
                    MessageBox.Show("数据导出失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("没有可以导出的数据。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        private void MasterToolBar_DoCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 查询
        /// </summary>
        private void Search(int currentPage)
        {
            int recordCount = bSlipTypeCompositionProducts.GetRecordCount(GetConduction());
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
            //sb.AppendFormat(" STATUS_FLAG <> {0}", CConstant.DELETE_STATUS);
            sb.AppendFormat(" SLIP_TYPE_CODE like '{0}%'", cboSlipType.SelectedValue);
            if (!string.IsNullOrEmpty(txtGroupCode.Text.Trim()))
            {
                sb.AppendFormat(" AND COMPOSITION_PRODUCTS_CODE like '{0}%'", txtGroupCode.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtGroupName.Text.Trim()))
            {
                sb.AppendFormat(" AND COMPOSITION_PRODUCTS_NAME like '{0}%'", txtGroupName.Text.Trim());
            }
            return sb.ToString();
        }

        /// <summary>
        /// 数据查询,绑定
        /// </summary>
        private void BindData(int currentPage)
        {
            string strWhere = GetConduction();
            DataSet ds = bSlipTypeCompositionProducts.GetList(strWhere, "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);
            _currentDt = ds.Tables[0];
            for (int i = _currentDt.Rows.Count; i < PageSize; i++)
            {
                _currentDt.Rows.Add(ds.Tables[0].NewRow());
            }
            this.dgvData.DataSource = _currentDt;
        }

        /// <summary>
        /// 打开新窗口
        /// </summary>
        private void OpenDialogFrm(int mode)
        {
            if (mode == CConstant.MODE_NEW || _currentSlipTypeCompositionProductsTable != null)
            {

                FrmSlipTypeCompositionProductsDialog frm = new FrmSlipTypeCompositionProductsDialog();
                frm.UserInfo = _userInfo;
                frm.CurrentSlipTypeProductGroupTable = _currentSlipTypeCompositionProductsTable;
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
            _currentSlipTypeCompositionProductsTable = null;
        }

        /// <summary>
        /// 获得当前选中的数据
        /// </summary>
        private void GetCurrentSelectedTable()
        {
            try
            {
                string productcode = dgvData.SelectedRows[0].Cells["SLIP_TYPE_CODE"].Value.ToString();
                string unitcode = dgvData.SelectedRows[0].Cells["COMPOSITION_PRODUCTS_CODE"].Value.ToString();
                if (productcode != "")
                {
                    _currentSlipTypeCompositionProductsTable = bSlipTypeCompositionProducts.GetModel(productcode, unitcode);
                }
            }
            catch (Exception ex) { }

            if (_currentSlipTypeCompositionProductsTable == null || _currentSlipTypeCompositionProductsTable.SLIP_TYPE_CODE == null || "".Equals(_currentSlipTypeCompositionProductsTable.SLIP_TYPE_CODE))
            {
                _currentSlipTypeCompositionProductsTable = null;
            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {

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
                if (row.Cells["SLIP_TYPE_CODE"].Value == null || "".Equals(row.Cells["SLIP_TYPE_CODE"].Value.ToString()))
                {
                    row.Selected = false;
                }
            }
        }

        #endregion

    }
}
