using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.Model;
using CZZD.ERP.Bll;
using CZZD.ERP.Common;
using System.Data;
using System.Collections;

namespace CZZD.ERP.IF
{
    public class SupplierPriceReceive : AbstractReceive
    {
        public SupplierPriceReceive(string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public SupplierPriceReceive(bool anAutoMode, string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(anAutoMode, aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public override void doCheckError()
        {

        }

        public override string[] doUpdateDB()
        {
            BaseSupplierPriceTable SupplierPriceTable = null;
            BSupplierPrice bSupplierPrice = new BSupplierPrice();
            StringBuilder strError = new StringBuilder();
            int successData = 0;
            int failureData = 0;
            string errorFilePath = "";
            string backupFilePath = "";

            //数据导入处理
            foreach (DataRow dr in _csvDataTable.Rows)
            {
                StringBuilder str = new StringBuilder();
                //供应商编号
                str.Append(CheckSupplier(CConvert.ToString(GetValue(dr, "SUPPLIER_CODE")), "供应商编号"));
                //商品编号
                if (CConvert.ToString(GetValue(dr, "PRODUCT_CODE")).Length > 20)
                {
                    string product = GetValue(dr, "PRODUCT_CODE").ToString().Substring(0, 20);
                    str.Append(CheckProduct(product, "商品编号"));
                }
                else
                {
                    str.Append(CheckProduct(CConvert.ToString(GetValue(dr, "PRODUCT_CODE")), "商品编号"));
                }
                //单位
                str.Append(CheckUnit(CConvert.ToString(GetValue(dr, "UNIT_CODE")), "单位"));
                //货币
                str.Append(CheckCurrency(CConvert.ToString(GetValue(dr, "CURRENCY_CODE")), "货币"));
                //单价
                str.Append(CheckDecimal(GetValue(dr, "PRICE", 0), 12, 3, "单价"));
                //状态
                str.Append(CheckInt(GetValue(dr, "STATUS_FLAG", CConstant.NORMAL), 9, "状态"));
                if (str.ToString().Trim().Length > 0)
                {
                    strError.Append(GetStringBuilder(dr, str.ToString().Trim()));
                    failureData++;
                    continue;
                }
                try
                {
                    SupplierPriceTable = new BaseSupplierPriceTable();
                    SupplierPriceTable.SUPPLIER_CODE = CConvert.ToString(GetValue(dr, "SUPPLIER_CODE"));
                    SupplierPriceTable.PRODUCT_CODE = CConvert.ToString(GetValue(dr, "PRODUCT_CODE"));
                    SupplierPriceTable.UNIT_CODE = CConvert.ToString(GetValue(dr, "UNIT_CODE"));
                    SupplierPriceTable.CURRENCY_CODE = CConvert.ToString(GetValue(dr, "CURRENCY_CODE"));
                    SupplierPriceTable.PRICE = CConvert.ToDecimal(GetValue(dr, "PRICE", 0));
                    SupplierPriceTable.STATUS_FLAG = CConvert.ToInt32(GetValue(dr, "STATUS_FLAG", CConstant.NORMAL));
                    SupplierPriceTable.CREATE_USER = _userInfo.CODE;
                    SupplierPriceTable.LAST_UPDATE_USER = _userInfo.CODE;

                    if (!bSupplierPrice.Exists(SupplierPriceTable.SUPPLIER_CODE, SupplierPriceTable.PRODUCT_CODE, SupplierPriceTable.UNIT_CODE, SupplierPriceTable.CURRENCY_CODE))
                    {
                        bSupplierPrice.Add(SupplierPriceTable);
                    }
                    else
                    {
                        bSupplierPrice.Update(SupplierPriceTable);
                    }
                    successData++;
                }
                catch
                {
                    strError.Append(GetStringBuilder(dr, " 数据导入失败，请与系统管理员联系！").ToString());
                    failureData++;
                }
            }
            //错误记录处理
            if (strError.Length > 0)
            {
                errorFilePath = WriteFile(strError.ToString());
            }

            //备份处理
            backupFilePath = BackupFile();

            return new string[] { successData.ToString(), failureData.ToString(), errorFilePath, backupFilePath };
        }
    }
}
