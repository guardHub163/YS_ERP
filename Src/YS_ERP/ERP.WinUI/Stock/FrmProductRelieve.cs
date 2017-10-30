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
    public partial class FrmProductRelieve : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);

        public FrmProductRelieve()
        {
            InitializeComponent();
        }

        private void FrmProductRelieve_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;
        }

        #region 关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要关闭吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                this.Close();
            }
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
                    txtWarehouse.Text = frm.BaseMasterTable.Code;
                    txtWarehouseName.Text = frm.BaseMasterTable.Name;
                }
            }
            frm.Dispose();
        }

        private void txtWarehouse_Leave(object sender, EventArgs e)
        {
            string warehouseCode = txtWarehouse.Text.Trim();
            if (warehouseCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("WAREHOUSE", warehouseCode);
                if (baseMaster != null)
                {
                    txtWarehouse.Text = baseMaster.Code;
                    txtWarehouseName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("仓库编号不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtWarehouse.Text = "";
                    txtWarehouseName.Text = "";
                    txtWarehouse.Focus();
                }
            }
            else
            {
                txtWarehouseName.Text = "";
            }
        }
        #endregion

        #region 组成品
        private void btnProduct_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("PRODUCT", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtProduct.Text = frm.BaseMasterTable.Code;
                    txtProductName.Text = frm.BaseMasterTable.Name;
                }
            }
        }

        private void txtProduct_Leave(object sender, EventArgs e)
        {
            string product = txtProduct.Text.Trim();
            if (product != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("PRODUCT", product);
                if (baseMaster != null)
                {
                    txtProduct.Text = baseMaster.Code;
                    txtProductName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("仓库编号不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtProduct.Text = "";
                    txtProductName.Text = "";
                    txtProduct.Focus();
                }
            }
            else
            {
                txtProductName.Text = "";
            }
        }
        #endregion

        #region 解除
        private void btnRelieve_Click(object sender, EventArgs e)
        {
            if (RelieveCheck())
            {
                BllProductBuildTable PBModel = new BllProductBuildTable();
                BllProductBuildLineTable PBLModel = null;
                int i = 1;

                PBModel.SLIP_NUMBER = CConvert.ToString(CConvert.ToInt32(bProductBuild.GetBuildMaxSlipNumber()) + 1).PadLeft(4, '0');
                BaseProductTable product = bProduct.GetModel(txtProduct.Text.Trim());
                PBModel.PRODUCT_CODE = txtProduct.Text.Trim();
                PBModel.WAREHOUSE_CODE = txtWarehouse.Text.Trim();
                PBModel.QUANTITY = CConvert.ToDecimal(txtRelieveQuantity.Text.Trim());
                PBModel.COMPANY_CODE = _userInfo.COMPANY_CODE;
                PBModel.BUILD_DATE = txtSlipDate.Value;

                BaseStockTable stock = new BaseStockTable();
                stock = bPurchaseOrder.GetStockModel(txtWarehouse.Text.Trim(), txtProduct.Text.Trim());
                PBModel.UNIT_CODE = stock.UNIT_CODE;
                PBModel.STATUS_FLAG = CConstant.RELIEVE_STATUS;
                PBModel.CREATE_USER = _userInfo.CODE;
                PBModel.LAST_UPDATE_USER = _userInfo.CODE;

                DataSet ds = bProductBuild.getParts(txtProduct.Text.Trim());
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    PBLModel = new BllProductBuildLineTable();
                    PBLModel.SLIP_NUMBER = PBModel.SLIP_NUMBER;
                    PBLModel.LINE_NUMBER = i;
                    PBLModel.PRODUCT_PARTS_CODE = CConvert.ToString(row["PRODUCT_PART_CODE"]);
                    PBLModel.PARTS_QUANTITY = CConvert.ToDecimal(row["QUANTITY"]) * PBModel.QUANTITY;
                    BaseStockTable stock1 = new BaseStockTable();
                    stock1 = bPurchaseOrder.GetStockModel(txtWarehouse.Text.Trim(), PBLModel.PRODUCT_PARTS_CODE);
                    PBLModel.UNIT_CODE = stock1.UNIT_CODE;
                    PBLModel.STATUS_FLAG = CConstant.INIT;

                    if (PBLModel.SLIP_NUMBER != null)
                    {
                        PBModel.AddItem(PBLModel);
                    }
                    i++;
                }

                int result = 0;
                try
                {
                    result = bProductBuild.AddRelieve(PBModel);
                    if (result <= 0)
                    {
                        string errorLog = "解除失败,请重试或与管理员联系.";
                        MessageBox.Show(errorLog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        txtWarehouse.Text = "";
                        txtWarehouseName.Text = "";
                        txtProduct.Text = "";
                        txtProductName.Text = "";
                        txtNoAlloation.Text = "";
                        txtRelieveQuantity.Text = "";
                        txtSlipDate.Value = DateTime.Now;
                        MessageBox.Show("保存成功", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败,系统错误,请与管理员联系.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logger.Error("组成失败！", ex);
                }
            }
        }

        public bool RelieveCheck()
        { 
            string strErrlog = null;
            if (string.IsNullOrEmpty(txtWarehouse.Text.Trim()))
            {
                strErrlog += "仓库编号不能为空!\r\n";
            }
        
            if (string.IsNullOrEmpty(txtProduct.Text.Trim()))
            {
                strErrlog += "组成品编号不能为空!\r\n";
            }

            if (string.IsNullOrEmpty(txtRelieveQuantity.Text.Trim()))
            {
                strErrlog += "解除数不能为空!\r\n";
            }

            if (string.IsNullOrEmpty(txtNoAlloation.Text.Trim()))
            {
                strErrlog += "为引当数量不能为空!\r\n";
            }

            if (strErrlog != null)
            {
                MessageBox.Show(strErrlog);
                return false;
            }
            return true;
        }
        #endregion

        #region 计算
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (CalculateCheck())
            {
                BAlloation bAlloation = new BAlloation();
                decimal alloationQuantity = bAlloation.GetAlloationQuantity(txtWarehouse.Text.Trim(), txtProduct.Text.Trim());
                BaseStockTable stock = new BaseStockTable();
                stock = bPurchaseOrder.GetStockModel(txtWarehouse.Text.Trim(), txtProduct.Text.Trim());
                txtNoAlloation.Text = CConvert.ToString(stock.QUANTITY - alloationQuantity);
            }
        }

        public bool CalculateCheck()
        {
            string strErrlog = null;
            if (string.IsNullOrEmpty(txtWarehouse.Text.Trim()))
            {
                strErrlog += "仓库编号不能为空!\r\n";
            }

            if (string.IsNullOrEmpty(txtProduct.Text.Trim()))
            {
                strErrlog += "组成品编号不能为空!\r\n";
            }

            if (strErrlog != null)
            {
                MessageBox.Show(strErrlog);
                return false;
            }
            return true;
        }
        #endregion
    }//end class
}
