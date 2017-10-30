using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using CZZD.ERP.Model;
using CZZD.ERP.Bll;
using System.Data;
using CZZD.ERP.Common;

namespace CZZD.ERP.IF
{
    public class ProductPartsReceive : AbstractReceive
    {
        public ProductPartsReceive(string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public ProductPartsReceive(bool anAutoMode, string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(anAutoMode, aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public override string[] doUpdateDB()
        {
            BaseProductPartsTable ProductPartsTable = null;
            BProductParts bProductParts = new BProductParts();
            StringBuilder strError = new StringBuilder();
            int successData = 0;
            int failureData = 0;
            string errorFilePath = "";
            string backupFilePath = "";

            //数据导入处理
            foreach (DataRow dr in _csvDataTable.Rows)
            {
                StringBuilder str = new StringBuilder();
                //规格型号编号
                str.Append(CheckProduct(CConvert.ToString(GetValue(dr, "PRODUCT_CODE")), "规格型号编号"));
                //外购件编号
                str.Append(CheckProduct(CConvert.ToString(GetValue(dr, "PRODUCT_PARTS_CODE")), "外购件编号"));
                //数量
                str.Append(CheckDecimal(GetValue(dr, "QUANTITY", 0), 12, 2, "数量"));

                if (str.ToString().Trim().Length > 0)
                {
                    strError.Append(GetStringBuilder(dr, str.ToString().Trim()));
                    failureData++;
                    continue;
                }
                try
                {
                    ProductPartsTable = new BaseProductPartsTable();
                    ProductPartsTable.PRODUCT_CODE = CConvert.ToString(GetValue(dr, "PRODUCT_CODE"));
                    ProductPartsTable.PRODUCT_PARTS_CODE = CConvert.ToString(GetValue(dr, "PRODUCT_PARTS_CODE"));
                    ProductPartsTable.QUANTITY = CConvert.ToDecimal(GetValue(dr, "QUANTITY"));
                    ProductPartsTable.STATUS_FLAG = CConstant.INIT;
                    ProductPartsTable.CREATE_USER = _userInfo.CODE;
                    ProductPartsTable.LAST_UPDATE_USER = _userInfo.CODE;

                    if (!bProductParts.Exists(ProductPartsTable.PRODUCT_CODE, ProductPartsTable.PRODUCT_PARTS_CODE))
                    {
                        bProductParts.Add(ProductPartsTable);
                    }
                    else
                    {
                        bProductParts.Update(ProductPartsTable);
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

        public override void doCheckError()
        {

        }
    }
}
