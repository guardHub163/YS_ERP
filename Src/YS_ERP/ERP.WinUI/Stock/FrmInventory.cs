using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Model;
using CZZD.ERP.Common;
using System.Collections;

namespace CZZD.ERP.WinUI
{
    public partial class FrmInventory : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private Hashtable hashtb = new Hashtable();
        private BllInventoryTable _inventoryTable = new BllInventoryTable();
        private string slipnumber;

        public string SLIP_NUMBER
        {
            set { slipnumber = value; }
            get { return slipnumber; }
        }

        public BaseUserTable UserInfo
        {
            get { return _userInfo; }
            set { _userInfo = value; }
        }

        public FrmInventory()
        {
            InitializeComponent();
        }

        private void FrmInventory_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;

            init();
        }

        #region 初始化
        public void init()
        {
            #region dgvData
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            PageSize = 14;
            dgvData.Rows.Add(PageSize);
            dgvData.Rows[0].Selected = true;
            #endregion

            BindData(1);

            this.Left = (int)((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2);
            this.Top = (int)((Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
            txtSlipNumber.Enabled = false;
            txtStartDate.Enabled = false;
            txtWarehouseCode.Enabled = false;
            btnSearch.Enabled = false;
            btnWarehouse.Enabled = false;
        }

        /// <summary>
        /// 数据查询,绑定
        /// </summary>
        private void BindData(int currentPage)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" SLIP_NUMBER like '{0}%'", slipnumber);
            _inventoryTable = bInventory.GetInventoryModel(slipnumber);
            DataSet ds = bInventory.GetEndInventoryList(sb.ToString(), "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);
            txtSlipNumber.Text = _inventoryTable.SLIP_NUMBER;
            txtStartDate.Value = _inventoryTable.START_DATE;
            txtWarehouseCode.Text = _inventoryTable.WAREHOUSE_CODE;
            txtWarehouseName.Text = bCommon.GetBaseMaster("WAREHOUSE", _inventoryTable.WAREHOUSE_CODE).Name;

            dgvData.Rows.Clear();
            foreach (DataRow rows in ds.Tables[0].Rows)
            {
                int currentRowIndex = dgvData.Rows.Add(1);
                DataGridViewRow row = dgvData.Rows[currentRowIndex];
                row.Cells[1].Selected = false;

                row.Cells["No"].Value = rows["LINE_NUMBER"];
                row.Cells["PRODUCT_CODE"].Value = rows["PRODUCT_CODE"];


                string code = rows["PRODUCT_CODE"].ToString();
                BaseProductTable productTable = bProduct.GetModel(code);
                row.Cells["SPEC"].Value = productTable.SPEC;
                row.Cells["PRODUCT_NAME"].Value = productTable.NAME;

                BaseStockTable stock = new BaseStockTable();
                stock = bPurchaseOrder.GetStockModel(rows["WAREHOUSE_CODE"].ToString(), rows["PRODUCT_CODE"].ToString());
                row.Cells["STOCK_QUANTITY"].Value = rows["STOCK_QUANTITY"];
                row.Cells["TRUE_QUANTITY"].Value = rows["TRUE_QUANTITY"];
                row.Cells["OLD_TRUE_QUANTITY"].Value = rows["TRUE_QUANTITY"];
                row.Cells["UNIT_NAME"].Value = bCommon.GetBaseMaster("UNIT", stock.UNIT_CODE).Name;
            }

            if (ds.Tables[0].Rows.Count < 14 * currentPage)
            {
                dgvData.Rows.Add(14 - ds.Tables[0].Rows.Count);
            }
        }


        /// <summary>
        /// 当前页码发生变化时的操作
        /// </summary>
        private void pgControl_PageChanged(object sender, EventArgs e, int currentPage)
        {
            BindData(currentPage);
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

        /// <summary>
        /// 仓库输入验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtWarehouseCode_Leave(object sender, EventArgs e)
        {
            string warehouseCode = txtWarehouseCode.Text.Trim();
            if (warehouseCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("WAREHOUSE", warehouseCode);
                if (baseMaster != null)
                {
                    txtWarehouseCode.Text = baseMaster.Code;
                    txtWarehouseName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("仓库编号不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtWarehouseCode.Text = "";
                    txtWarehouseName.Text = "";
                    txtWarehouseCode.Focus();
                }
            }
            else
            {
                txtWarehouseName.Text = "";
            }
        }
        #endregion

        #region 窗口关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要关闭吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                this.Close();
            }
        }
        #endregion
        
        #region 查询分页
        /*
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int currentPage = 1;
            int recordCount = bInventory.GetEndInventoryRecordCount(GetConduction());
            if (recordCount < 0)
            {
                MessageBox.Show("查询的信息不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            isSearch = true;

            dgvData.Columns["TRUE_QUANTITY"].ReadOnly = false;

            //分页标签初始化
            this.pgControl.init(GetTotalPage(recordCount), currentPage);
            //数据绑定
            BindData(currentPage);
        }
        
        /// <summary>
        /// 获得查询条件
        /// </summary>
        private string GetConduction()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" STATUS_FLAG <> {0}", CConstant.DELETE_STATUS);
            if (txtSlipNumber.Text.Trim() != "")
            {
                sb.AppendFormat("and SLIP_NUMBER like '{0}%'", txtSlipNumber.Text.Trim());
            }

            if (txtStartDate.Value != null)
            {
                sb.AppendFormat("and START_DATE >= '{0}'", txtStartDate.Value.ToShortDateString());
            }

            if (txtWarehouseCode.Text.Trim() != "")
            {
                sb.AppendFormat("and WAREHOUSE_CODE like '{0}%'", txtWarehouseCode.Text.Trim());
            }
            return sb.ToString();
        }*/
        #endregion

        #region 保存
        private void btnSava_Click(object sender, EventArgs e)
        {
            try
            {
                if (hashtb.Count > 0)
                {
                    int s = bInventory.UpdataInventory(slipnumber, hashtb, _userInfo.CODE, false);
                    if (s <= 0)
                    {
                        MessageBox.Show("保存失败!");
                    }
                    else
                    {
                        MessageBox.Show("保存成功!");
                    }
                }
            }
            catch (Exception ex)
            {
                //log.error
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void dgvData_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dgvData.Rows[e.RowIndex];
                if (e.ColumnIndex == dgvData.Columns["TRUE_QUANTITY"].Index)
                {
                    if (CConvert.ToDecimal(dr.Cells["OLD_TRUE_QUANTITY"].Value) == CConvert.ToDecimal(dr.Cells["TRUE_QUANTITY"].Value))
                    {
                        hashtb.Remove(dr.Cells["PRODUCT_CODE"].Value);
                    }
                    else
                    {
                        hashtb.Add(dr.Cells["PRODUCT_CODE"].Value, dr.Cells["TRUE_QUANTITY"].Value);

                    }
                }
            }
            catch (Exception ex)
            {  }
        }
        #endregion

        #region 盘点结束
        private void btnEnd_Click(object sender, EventArgs e)
        {
            try
            {
                //if (hashtb.Count > 0)
                //{
                    int s = bInventory.UpdataInventory(slipnumber, hashtb, _userInfo.CODE, true);
                    if (s <= 0)
                    {
                        MessageBox.Show("盘点失败!");
                    }
                    else
                    {
                        MessageBox.Show("盘点成功!");
                    }
                //}
            }
            catch (Exception ex)
            {
                //log.error
                MessageBox.Show(ex.Message);
                return;
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
                if (row.Cells["PRODUCT_CODE"].Value == null || "".Equals(row.Cells["PRODUCT_CODE"].Value.ToString()))
                {
                    row.Selected = false;
                }
            }
        }
    }//end class
}
