using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using CZZD.ERP.Model;
using System.Data;
using CZZD.ERP.Bll;
using CZZD.ERP.Common;

namespace CZZD.ERP.IF
{
    public class SlipTypeCompositionProductsReceive: AbstractReceive
    {
        public SlipTypeCompositionProductsReceive(string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public SlipTypeCompositionProductsReceive(bool anAutoMode, string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(anAutoMode, aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public override void doCheckError()
        {

        }

        public override string[] doUpdateDB()
        {
            BaseSlipTypeCompositionProductsTable SlipTypeCompositionProductsTable = null;
            BSlipTypeCompositionProducts bSlipTypeCompositionProducts = new BSlipTypeCompositionProducts();
            StringBuilder strError = new StringBuilder();
            int successData = 0;
            int failureData = 0;
            string errorFilePath = "";
            string backupFilePath = "";

            //数据导入处理
            foreach (DataRow dr in _csvDataTable.Rows)
            {
                StringBuilder str = new StringBuilder();
                //订单类型编号
                str.Append(CheckSlipType(CConvert.ToString(GetValue(dr, "SLIP_TYPE_CODE")), "产线编号"));
                //组成品编号
                str.Append(CheckCompositionProducts(CConvert.ToString(GetValue(dr, "COMPOSITION_PRODUCTS_CODE")), "组成品编号"));
               
                if (str.ToString().Trim().Length > 0)
                {
                    strError.Append(GetStringBuilder(dr, str.ToString().Trim()));
                    failureData++;
                    continue;
                }
                try
                {
                    SlipTypeCompositionProductsTable = new BaseSlipTypeCompositionProductsTable();
                    SlipTypeCompositionProductsTable.SLIP_TYPE_CODE = CConvert.ToString(GetValue(dr, "SLIP_TYPE_CODE"));
                    SlipTypeCompositionProductsTable.COMPOSITION_PRODUCTS_CODE = CConvert.ToString(GetValue(dr, "COMPOSITION_PRODUCTS_CODE"));


                    if (!bSlipTypeCompositionProducts.Exists(SlipTypeCompositionProductsTable.SLIP_TYPE_CODE, SlipTypeCompositionProductsTable.COMPOSITION_PRODUCTS_CODE))
                    {
                        bSlipTypeCompositionProducts.Add(SlipTypeCompositionProductsTable);
                    }
                    else
                    {
                        bSlipTypeCompositionProducts.Update(SlipTypeCompositionProductsTable);
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
