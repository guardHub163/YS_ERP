using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using CZZD.ERP.Model;
using CZZD.ERP.Common;
using System.Data;
using CZZD.ERP.Bll;

namespace CZZD.ERP.IF
{
    public class ProductReceive : AbstractReceive
    {
        public ProductReceive(string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public ProductReceive(bool anAutoMode, string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(anAutoMode, aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }
        public override void doCheckError()
        {

        }

        public override string[] doUpdateDB()
        {
            BaseProductTable ProductTable = null;
            BProduct bProduct = new BProduct();
            StringBuilder strError = new StringBuilder();
            int successData = 0;
            int failureData = 0;
            string errorFilePath = "";
            string backupFilePath = "";

            //数据导入处理
            foreach (DataRow dr in _csvDataTable.Rows)
            {
                StringBuilder str = new StringBuilder();
                //外购件编号
                if (GetValue(dr, "CODE").ToString().Length > 20)
                {                   
                    if (!string.IsNullOrEmpty(GetValue(dr, "CODE").ToString().Substring(0, 20)))
                    {
                        str.Append(CheckString(GetValue(dr, "CODE"), "外购件编号"));
                    }
                    else
                    {
                        str.Append("外购件编号不能为空!");
                    }
                }
                else 
                {
                    if (!string.IsNullOrEmpty(CConvert.ToString(GetValue(dr, "CODE"))))
                    {
                        str.Append(CheckString(GetValue(dr, "CODE"), "外购件编号"));
                    }
                    else
                    {
                        str.Append("外购件编号不能为空!");
                    }
                }
                //外购件名称
                str.Append(CheckLenght(GetValue(dr, "NAME"), 100, "外购件名称"));
                //外购件规格
                str.Append(CheckLenght(GetValue(dr, "SPEC"), 50, "外购件规格"));
                //外购件类别编号
                if (!string.IsNullOrEmpty(CConvert.ToString(GetValue(dr, "GROUP_CODE"))))
                {
                    str.Append(CheckProductGroup(CConvert.ToString(GetValue(dr, "GROUP_CODE")), "外购件类别编号"));
                }
                //外购件单位
                if (!string.IsNullOrEmpty(CConvert.ToString(GetValue(dr, "BASIC_UNIT_CODE"))))
                {
                    str.Append(CheckUnit(CConvert.ToString(GetValue(dr, "BASIC_UNIT_CODE")), "外购件单位"));
                }
                //外购件销售价格
                str.Append(CheckDecimal(GetValue(dr, "SALES_PRICE", 0), 12, 2, "外购件销售价格"));
                //外购件采购价格
                str.Append(CheckDecimal(GetValue(dr, "PURCHASE_PRICE", 0), 12, 2, "外购件采购价格"));
                //外购件安全库存
                str.Append(CheckDecimal(GetValue(dr, "SAFETY_STOCK", 0), 12, 2, "外购件安全库存"));               

                if (str.ToString().Trim().Length > 0)
                {
                    strError.Append(GetStringBuilder(dr, str.ToString().Trim()));
                    failureData++;
                    continue;
                }
                try
                {
                    int ret = 0;
                    ProductTable = new BaseProductTable();
                    if (GetValue(dr, "CODE").ToString().Length > 20)
                    {
                        ProductTable.CODE = CConvert.ToString(GetValue(dr, "CODE")).Substring(0, 20);
                    }
                    else
                    {
                        ProductTable.CODE = CConvert.ToString(GetValue(dr, "CODE"));
                    }
                    ProductTable.NAME = CConvert.ToString(GetValue(dr, "NAME"));
                    ProductTable.SPEC = CConvert.ToString(GetValue(dr, "SPEC"));
                    ProductTable.GROUP_CODE = CConvert.ToString(GetValue(dr, "GROUP_CODE"));
                    if (!string.IsNullOrEmpty(CConvert.ToString(GetValue(dr, "BASIC_UNIT_CODE"))))
                    {
                        ProductTable.BASIC_UNIT_CODE = CConvert.ToString(GetValue(dr, "BASIC_UNIT_CODE"));
                    }
                    else
                    {
                        ProductTable.BASIC_UNIT_CODE = "01";
                    }
                    ProductTable.SALES_PRICE = Convert.ToDecimal(GetValue(dr, "SALES_PRICE", 0));
                    ProductTable.PURCHASE_PRICE = Convert.ToDecimal(GetValue(dr, "PURCHASE_PRICE", 0));
                    ProductTable.SAFETY_STOCK = CConvert.ToDecimal(GetValue(dr, "SAFETY_STOCK", 0));
                    ProductTable.PRODUCT_FLAG = CConstant.PRODUCT_FLAG_PURCHASE;
                    ProductTable.STATUS_FLAG = CConstant.INIT;  
                    ProductTable.CREATE_USER = _userInfo.CODE;
                    ProductTable.LAST_UPDATE_USER = _userInfo.CODE;

                    if (!bProduct.Exists(ProductTable.CODE))
                    {
                        bProduct.Add(ProductTable);
                    }
                    else
                    {
                        bProduct.Update(ProductTable);
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
