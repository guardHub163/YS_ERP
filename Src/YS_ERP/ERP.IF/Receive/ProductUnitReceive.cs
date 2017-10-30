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
    public class ProductUnitReceive : AbstractReceive
    {
        public ProductUnitReceive(string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public ProductUnitReceive(bool anAutoMode, string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(anAutoMode, aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public override void doCheckError()
        {

        }

        public override string[] doUpdateDB()
        {
            BaseProductUnitTable ProductUnitTable = null;
            BProductUnit bProductUnit = new BProductUnit();
            StringBuilder strError = new StringBuilder();
            int successData = 0;
            int failureData = 0;
            string errorFilePath = "";
            string backupFilePath = "";

            //数据导入处理
            foreach (DataRow dr in _csvDataTable.Rows)
            {
                StringBuilder str = new StringBuilder();
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
                //基础单位Flag
                if (CConvert.ToInt32(GetValue(dr, "BASIC_FLAG", 1)) != 1 && CConvert.ToInt32(GetValue(dr, "BASIC_FLAG", 1)) != 2 && CConvert.ToString(GetValue(dr, "BASIC_FLAG", 1)) != "")
                {
                    str.Append("基础单位Flag只能为1或2!");
                }
                else
                {
                    str.Append(CheckInt(GetValue(dr, "BASIC_FLAG", 1), 9, "基础单位Flag"));
                }
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
                    ProductUnitTable = new BaseProductUnitTable();
                    if (GetValue(dr, "PRODUCT_CODE").ToString().Length > 20)
                    {
                        ProductUnitTable.PRODUCT_CODE = CConvert.ToString(GetValue(dr, "PRODUCT_CODE")).Substring(0, 20);
                    }
                    else
                    {
                        ProductUnitTable.PRODUCT_CODE = CConvert.ToString(GetValue(dr, "PRODUCT_CODE"));
                    }
                    ProductUnitTable.UNIT_CODE = CConvert.ToString(GetValue(dr, "UNIT_CODE", "01"));
                    ProductUnitTable.BASIC_FLAG = CConvert.ToInt32(GetValue(dr, "BASIC_FLAG", 1));
                    ProductUnitTable.STATUS_FLAG = CConvert.ToInt32(GetValue(dr, "STATUS_FLAG", CConstant.NORMAL));
                    ProductUnitTable.CREATE_USER = _userInfo.CODE;
                    ProductUnitTable.LAST_UPDATE_USER = _userInfo.CODE;

                    if (!bProductUnit.Exists(ProductUnitTable.PRODUCT_CODE, ProductUnitTable.UNIT_CODE))
                    {
                        bProductUnit.Add(ProductUnitTable);
                    }
                    else
                    {
                        bProductUnit.Update(ProductUnitTable);
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
