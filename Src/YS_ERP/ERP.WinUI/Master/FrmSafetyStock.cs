using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Bll;
using CZZD.ERP.Model;
using CZZD.ERP.WinUI.Master;
using CZZD.ERP.Common;

namespace CZZD.ERP.WinUI
{
    public partial class FrmSafetyStock : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private DataTable _currentDt = new DataTable();
        private BSafetyStock bSafetyStock = new BSafetyStock();
        private BaseSafetyStockTable _currentSafetyStockTable;
        private bool isSearch = false;

        public FrmSafetyStock()
        {
            InitializeComponent();
        }

        private void FrmProductUnit_Load(object sender, EventArgs e)
        {
            init();
            this.WindowState = FormWindowState.Normal;
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

            _currentDt.Columns.Add("WAREHOUSE_CODE", Type.GetType("System.String"));
            _currentDt.Columns.Add("WAREHOUSE_NAME", Type.GetType("System.String"));
            _currentDt.Columns.Add("PRODUCT_CODE", Type.GetType("System.String"));
            _currentDt.Columns.Add("PRODUCT_NAME", Type.GetType("System.String"));
            _currentDt.Columns.Add("UNIT_CODE", Type.GetType("System.String"));
            _currentDt.Columns.Add("UNIT_NAME", Type.GetType("System.String"));
            _currentDt.Columns.Add("SAFETY_STOCK", Type.GetType("System.String"));
            _currentDt.Columns.Add("MAX_QUANTITY", Type.GetType("System.String"));
            _currentDt.Columns.Add("MIN_PURCHASE_QUANTITY", Type.GetType("System.String"));
            _currentDt.Columns.Add("CREATE_USER", Type.GetType("System.String"));
            _currentDt.Columns.Add("CREATE_DATE_TIME", Type.GetType("System.String"));
            _currentDt.Columns.Add("LAST_UPDATE_USER", Type.GetType("System.String"));
            _currentDt.Columns.Add("LAST_DATE_TIME", Type.GetType("System.String"));

            DataRow row = null;
            for (int i = 1; i <= 20; i++)
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
                    if (_currentSafetyStockTable != null)
                    {
                        bSafetyStock.Delete(_currentSafetyStockTable.WAREHOUSE_CODE,_currentSafetyStockTable.PRODUCT_CODE);
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
                    Logger.Error("安全库存删除失败，请重试或与系统管理员联系。", ex);
                }
                _currentSafetyStockTable = null;
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
            _currentDt = bSafetyStock.GetList(GetConduction()).Tables[0];
            if (isSearch && _currentDt != null)
            {
                foreach (DataRow row in _currentDt.Rows)
                {
                    try
                    {
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
                sf.FileName = "LZ_SAFETY_STOCK_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
                sf.Filter = "(文件)|*.xls;*.xlsx";

                string header = "仓库编号\t仓库名称\t商品编号\t商品名称\t单位编号\t单位名称\t安全在库数\t最大在库数\t最小采购数\t状态\t创建人员\t创建时间\t最后更新人\t最后更新时间\t\n";
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

        #region 查询
        /// <summary>
        /// 查询
        /// </summary>
        private void Search(int currentPage)
        {
            int recordCount = bSafetyStock.GetRecordCount(GetConduction());
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
            if (txtWarehouseCode.Text.Trim() != "")
            {
                sb.AppendFormat(" and WAREHOUSE_CODE like '{0}%'", txtWarehouseCode.Text.Trim());
            }
            if (txtProductCode.Text.Trim() != "")
            {
                sb.AppendFormat(" and PRODUCT_CODE like '{0}%'", txtProductCode.Text.Trim());
            }
            return sb.ToString();
        }

        /// <summary>
        /// 数据查询,绑定
        /// </summary>
        private void BindData(int currentPage)
        {
            string strWhere = GetConduction();
            DataSet ds = bSafetyStock.GetList(strWhere, "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);
            _currentDt = ds.Tables[0];
            foreach (DataRow row in _currentDt.Rows)
            {
                try
                {
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
            if (mode == CConstant.MODE_NEW || _currentSafetyStockTable != null)
            {
                FrmSafetyStockDialog frm = new FrmSafetyStockDialog();
                frm.UserInfo = _userInfo;
                frm.CurrentSafetyStockTable = _currentSafetyStockTable;
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
            _currentSafetyStockTable = null;
        }

        /// <summary>
        /// 获得当前选中的数据
        /// </summary>
        private void GetCurrentSelectedTable()
        {
            try
            {
                string warehousecode = dgvData.SelectedRows[0].Cells["WAREHOUSE_CODE"].Value.ToString();
                string productcode = dgvData.SelectedRows[0].Cells["PRODUCT_CODE"].Value.ToString();
                if (warehousecode != "" && productcode != "")
                {
                    _currentSafetyStockTable = bSafetyStock.GetModel(warehousecode, productcode);
                }
            }
            catch (Exception ex) 
            {
                //MessageBox.Show("获取对象失败!");
            }

            if (_currentSafetyStockTable == null || _currentSafetyStockTable.WAREHOUSE_CODE == null || "".Equals(_currentSafetyStockTable.WAREHOUSE_CODE))
            {
                _currentSafetyStockTable = null;
            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtProductCode.Focused)
                {
                    MasterToolBar_DoSearch_Click(sender, e);
                }
                else
                {
                    //System.Windows.Forms.SendKeys.Send("{Tab}");
                    ProcessTabKey(true);
                }
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
                if (row.Cells["WAREHOUSE_CODE"].Value == null || "".Equals(row.Cells["WAREHOUSE_CODE"].Value.ToString()))
                {
                    row.Selected = false;
                }
            }
        }

    }
}
