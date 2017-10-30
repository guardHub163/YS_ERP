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
using CZZD.ERP.Common;
using CZZD.ERP.CacheData;

namespace CZZD.ERP.WinUI
{
    public partial class FrmProduct : FrmBase
    {
        private DataTable _currentDt = new DataTable();
        private BaseProductTable _currentProductTable;
        private bool isSearch = false;

        public FrmProduct()
        {
            InitializeComponent();
        }

        private void FrmProduct_Load(object sender, EventArgs e)
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

            _currentDt.Columns.Add("CODE", Type.GetType("System.String"));
            _currentDt.Columns.Add("NAME", Type.GetType("System.String"));
            _currentDt.Columns.Add("SPEC", Type.GetType("System.String"));
            _currentDt.Columns.Add("MODEL_NUMBER", Type.GetType("System.String"));
            _currentDt.Columns.Add("GROUP_NAME", Type.GetType("System.String"));
            _currentDt.Columns.Add("UNIT_NAME", Type.GetType("System.String"));
            _currentDt.Columns.Add("PRODUCT_ACCOUTING", Type.GetType("System.String"));
            _currentDt.Columns.Add("HSCODE_NAME", Type.GetType("System.String"));
            _currentDt.Columns.Add("SALES_PRICE", Type.GetType("System.String"));
            _currentDt.Columns.Add("FROMSET", Type.GetType("System.String"));
            _currentDt.Columns.Add("MECHANICAL_DISTINCTION", Type.GetType("System.String"));
            _currentDt.Columns.Add("PRODUCT_STOCK", Type.GetType("System.String"));
            _currentDt.Columns.Add("PRODUCT_PROPERTY", Type.GetType("System.String"));

            DataRow row = null;
            PageSize = 18;
            for (int i = 1; i <= 18; i++)
            {
                row = _currentDt.NewRow();
                _currentDt.Rows.Add(row);
            }
            this.dgvData.DataSource = _currentDt;

            #region 类别区分
            DataTable pstDT = CCacheData.Distinction.Copy();
            DataRow dr = pstDT.NewRow();
            pstDT.Rows.InsertAt(dr, 0);
            dr["CODE"] = "";
            dr["NAME"] = "全部";
            cboDistinction.ValueMember = "CODE";
            cboDistinction.DisplayMember = "NAME";
            cboDistinction.DataSource = pstDT;
            #endregion 
            #endregion
        }
        #endregion

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
                    if (_currentProductTable != null)
                    {
                        bProduct.Delete(_currentProductTable.CODE);
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
                _currentProductTable = null;
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
            _currentDt = bProduct.GetList(GetConduction()).Tables[0];
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
                int result = CExport.DataTableToExcel(_currentDt, CConstant.PRODUCT_HEADER, CConstant.PRODUCT_COLUMNS, "PRODUCT", "PRODUCT");
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
            int recordCount = bProduct.GetRecordCount(GetConduction());
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
            if (txtCode.Text.Trim() != "")
            {
                sb.AppendFormat(" and CODE like '{0}%'", txtCode.Text.Trim());
            }
            if (txtName.Text.Trim() != "")
            {
                sb.AppendFormat(" and NAME like '{0}%'", txtName.Text.Trim());
            }
            if (txtGroupCode.Text.Trim() != "") 
            {
                sb.AppendFormat(" and GROUP_CODE like '{0}%'", txtGroupCode.Text.Trim());
            }
            if (txtGroupName.Text.Trim() != "")
            {
                sb.AppendFormat(" and GROUP_NAME like '{0}%'", txtGroupName.Text.Trim());
            }
            if (!string.IsNullOrEmpty(CConvert.ToString(cboDistinction.SelectedValue)))
            {
                sb.AppendFormat(" and DISTINCTION = '{0}'", CConvert.ToDecimal(cboDistinction.SelectedValue));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 数据查询,绑定
        /// </summary>
        private void BindData(int currentPage)
        {
            string strWhere = GetConduction();
            DataSet ds = bProduct.GetList(strWhere, "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);
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

        /// <summary>
        /// 打开新窗口
        /// </summary>
        private void OpenDialogFrm(int mode)
        {
            if (mode == CConstant.MODE_NEW || _currentProductTable != null)
            {

                FrmProductDialog frm = new FrmProductDialog();
                frm.UserInfo = _userInfo;
                frm.CurrentProductTable = _currentProductTable;
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
            _currentProductTable = null;
        }

        /// <summary>
        /// 获得当前选中的数据
        /// </summary>
        private void GetCurrentSelectedTable()
        {
            try
            {
                string code = dgvData.SelectedRows[0].Cells["CODE"].Value.ToString();
                if (code != "")
                {
                    _currentProductTable = bProduct.GetModel(code);
                }
            }
            catch (Exception ex) { }

            if (_currentProductTable == null || _currentProductTable.CODE == null || "".Equals(_currentProductTable.CODE))
            {
                _currentProductTable = null;
            }
        }


        #endregion

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtName.Focused)
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
                if (row.Cells["CODE"].Value == null || "".Equals(row.Cells["CODE"].Value.ToString()))
                {
                    row.Selected = false;
                }
            }
        }
    }
}
