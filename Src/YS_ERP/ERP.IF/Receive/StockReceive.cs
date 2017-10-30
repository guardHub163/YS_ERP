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
    public class StockReceive : AbstractReceive
    {
        public StockReceive(string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public StockReceive(bool anAutoMode, string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(anAutoMode, aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public override void doCheckError()
        {
        }

        public override string[] doUpdateDB()
        {
            BaseStockTable StockTable = null;
            BStock bStock = new BStock();
            StringBuilder strError = new StringBuilder();
            int successData = 0;
            int failureData = 0;
            string errorFilePath = "";
            string backupFilePath = "";

            //数据导入处理
            foreach (DataRow dr in _csvDataTable.Rows)
            {
                StringBuilder str = new StringBuilder();
                //仓库编号
                str.Append(CheckWarehouse(CConvert.ToString(GetValue(dr, "WAREHOUSE_CODE")), "仓库编号"));
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
                if (!string.IsNullOrEmpty(CConvert.ToString(GetValue(dr, "UNIT_CODE"))))
                {
                    str.Append(CheckUnit(CConvert.ToString(GetValue(dr, "UNIT_CODE")), "单位"));
                }
                //数量
                str.Append(CheckDecimal(GetValue(dr, "QUANTITY", 0), 12, 2, "数量"));
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
                    int ret = 0;
                    StockTable = new BaseStockTable();
                    StockTable.WAREHOUSE_CODE = CConvert.ToString(GetValue(dr, "WAREHOUSE_CODE"));
                    if (GetValue(dr, "PRODUCT_CODE").ToString().Length > 20)
                    {
                        StockTable.PRODUCT_CODE = CConvert.ToString(GetValue(dr, "PRODUCT_CODE")).Substring(0, 20);
                    }
                    else
                    {
                        StockTable.PRODUCT_CODE = CConvert.ToString(GetValue(dr, "PRODUCT_CODE"));
                    }
                    StockTable.UNIT_CODE = CConvert.ToString(GetValue(dr, "UNIT_CODE"));
                    StockTable.QUANTITY = CConvert.ToDecimal(GetValue(dr, "QUANTITY", 0));
                    StockTable.STATUS_FLAG = CConvert.ToInt32(GetValue(dr, "STATUS_FLAG", CConstant.NORMAL));
                    StockTable.CREATE_USER = _userInfo.CODE;
                    StockTable.LAST_UPDATE_USER = _userInfo.CODE;

                    if (!bStock.Exists(StockTable.WAREHOUSE_CODE, StockTable.PRODUCT_CODE))
                    {
                        bStock.Add(StockTable);
                    }
                    else
                    {
                        bStock.UpdateStock(StockTable);
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
