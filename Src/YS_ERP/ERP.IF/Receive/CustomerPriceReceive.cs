using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.Model;
using CZZD.ERP.Bll;
using CZZD.ERP.Common;
using System.Collections;
using System.Data;

namespace CZZD.ERP.IF
{
    public class CustomerPriceReceive : AbstractReceive
    {
        public CustomerPriceReceive(string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public CustomerPriceReceive(bool anAutoMode, string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(anAutoMode, aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public override void doCheckError()
        {

        }

        public override string[] doUpdateDB()
        {
            BaseCustomerPriceTable CustomerPriceTable = null;
            BCustomerPrice bCustomerPrice = new BCustomerPrice();
            StringBuilder strError = new StringBuilder();
            int successData = 0;
            int failureData = 0;
            string errorFilePath = "";
            string backupFilePath = "";

            //数据导入处理
            foreach (DataRow dr in _csvDataTable.Rows)
            {
                StringBuilder str = new StringBuilder();
                //客户编号
                str.Append(CheckCustomer(CConvert.ToString(GetValue(dr, "CUSTOMER_CODE")), "客户编号"));
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
                str.Append(CheckUnit(CConvert.ToString(GetValue(dr, "UNIT_CODE")), "单位编号"));
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
                    CustomerPriceTable = new BaseCustomerPriceTable();
                    CustomerPriceTable.CUSTOMER_CODE = CConvert.ToString(GetValue(dr, "CUSTOMER_CODE"));
                    if (GetValue(dr, "PRODUCT_CODE").ToString().Length > 20)
                    {
                        CustomerPriceTable.PRODUCT_CODE = CConvert.ToString(GetValue(dr, "PRODUCT_CODE")).Substring(0, 20);
                    }
                    else
                    {
                        CustomerPriceTable.PRODUCT_CODE = CConvert.ToString(GetValue(dr, "PRODUCT_CODE"));
                    }
                    CustomerPriceTable.UNIT_CODE = CConvert.ToString(GetValue(dr, "UNIT_CODE"));
                    CustomerPriceTable.PRICE = CConvert.ToDecimal(GetValue(dr, "PRICE", 0));
                    CustomerPriceTable.STATUS_FLAG = CConvert.ToInt32(GetValue(dr, "STATUS_FLAG", CConstant.NORMAL));
                    CustomerPriceTable.CREATE_USER = _userInfo.CODE;
                    CustomerPriceTable.LAST_UPDATE_USER = _userInfo.CODE;

                    if (!bCustomerPrice.Exists(CustomerPriceTable.CUSTOMER_CODE, CustomerPriceTable.PRODUCT_CODE, CustomerPriceTable.UNIT_CODE))
                    {
                        bCustomerPrice.Add(CustomerPriceTable);
                    }
                    else
                    {
                        bCustomerPrice.Update(CustomerPriceTable);
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
