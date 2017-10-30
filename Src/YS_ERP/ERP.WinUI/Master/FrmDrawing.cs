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
using CZZD.ERP.WinUI.Master;

namespace CZZD.ERP.WinUI
{
    public partial class FrmDrawing : FrmBase
    {
         private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private DataTable _currentDt = new DataTable();
        private BDrawing bDrawing = new BDrawing();
        private BaseDrawingTable _currentDrawingTable;   


        private bool isSearch = false;

        public FrmDrawing()
        {
            InitializeComponent();
        }

        private void FrmDrawing_Load(object sender, EventArgs e)
        {
            PageSize = 17;
            this.WindowState = FormWindowState.Normal;
            init();
        }

        private void init()
        {
            #region dgvData
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            //_currentDt.Columns.Add("CODE", Type.GetType("System.String"));
            //_currentDt.Columns.Add("NAME", Type.GetType("System.String"));
            //  _currentDt.Columns.Add("DEPARTMENT_CODE", Type.GetType("System.String"));
            //_currentDt.Columns.Add("DEPARTMENT_NAME", Type.GetType("System.String"));
            //_currentDt.Columns.Add("CREATE_USER_NAME", Type.GetType("System.String"));
            //_currentDt.Columns.Add("CREATE_DATE_TIME", Type.GetType("System.DateTime"));
            //_currentDt.Columns.Add("LAST_UPDATE_USER_NAME", Type.GetType("System.String"));
            //_currentDt.Columns.Add("LAST_UPDATE_TIME", Type.GetType("System.DateTime"));
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
                    if (_currentDrawingTable != null)
                    {
                        bDrawing.Delete(_currentDrawingTable.CODE);
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
                    Logger.Error("订单类型删除失败", ex);
                }
                _currentDrawingTable = null;
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
            //_currentDt = bSlipType.GetList(GetConduction()).Tables[0];
            //if (isSearch && _currentDt.Rows.Count > 0)
            //{                
            //    int result = CommonExport.DataTableToExcel(_currentDt, CConstant.SLIP_TYPE_HEADER, CConstant.SLIP_TYPE_COLUMNS, "SLIP_TYPE", "SLIP_TYPE");
            //    if (result == CConstant.EXPORT_SUCCESS)
            //    {
            //        MessageBox.Show("数据已经成功导出!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else if (result == CConstant.EXPORT_FAILURE)
            //    {
            //        MessageBox.Show("数据导出失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("没有可以导出的数据。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
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
            int recordCount = bDrawing.GetRecordCount(GetConduction());
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
            if (!string.IsNullOrEmpty(txtDrawingCode.Text.Trim()))
            {
                sb.AppendFormat(" and CODE like '{0}%'", txtDrawingCode.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtDrawingName.Text.Trim()))
            {
                sb.AppendFormat(" and NAME like '{0}%'", txtDrawingName.Text.Trim());
            }

            return sb.ToString();
        }

        /// <summary>
        /// 数据查询,绑定
        /// </summary>
        private void BindData(int currentPage)
        {
            string strWhere = GetConduction();
            DataSet ds = bDrawing.GetList(strWhere, "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);
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
            if (mode == CConstant.MODE_NEW || _currentDrawingTable != null)
            {

                FrmDrawingDialog frm = new FrmDrawingDialog();
                frm.UserInfo = _userInfo;
                frm.CurrentDrawingTable = _currentDrawingTable;
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
            _currentDrawingTable = null;
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
                    _currentDrawingTable = bDrawing.GetModel(code);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("订单类型中获取当前数据失败!", ex);
            }

            if (_currentDrawingTable == null || _currentDrawingTable.CODE == null || "".Equals(_currentDrawingTable.CODE))
            {
                _currentDrawingTable = null;
            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtDrawingCode.Focused)
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
                if (row.Cells["CODE"].Value == null || "".Equals(row.Cells["CODE"].Value.ToString()))
                {
                    row.Selected = false;
                }
            }
        }
    }
}
