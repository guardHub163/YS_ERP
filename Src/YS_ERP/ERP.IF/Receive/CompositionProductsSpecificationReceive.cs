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
    public class CompositionProductsSpecificationReceive: AbstractReceive
    {
        public CompositionProductsSpecificationReceive(string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public CompositionProductsSpecificationReceive(bool anAutoMode, string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(anAutoMode, aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public override void doCheckError()
        {

        }

        public override string[] doUpdateDB()
        {
            BaseCompositionProductsProductionProcessTable CompositionProductsSpecificationTable = null;
            BCompositionProductsProductionProcess bCompositionProductsSpecification = new BCompositionProductsProductionProcess();
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
                str.Append(CheckCompositionProducts(CConvert.ToString(GetValue(dr, "COMPOSITION_PRODUCTS_CODE")), "组成品编号"));
                //订单类型名称
                str.Append(CheckProduct(CConvert.ToString(GetValue(dr, "SPECIFICATION_CODE")), "规格型号编号"));
               
                if (str.ToString().Trim().Length > 0)
                {
                    strError.Append(GetStringBuilder(dr, str.ToString().Trim()));
                    failureData++;
                    continue;
                }
                try
                {
                    CompositionProductsSpecificationTable = new BaseCompositionProductsProductionProcessTable();
                    CompositionProductsSpecificationTable.COMPOSITION_PRODUCTS_CODE = CConvert.ToString(GetValue(dr, "COMPOSITION_PRODUCTS_CODE"));
                    CompositionProductsSpecificationTable.PRODUCTION_PROCESS_CODE = CConvert.ToString(GetValue(dr, "SPECIFICATION_CODE"));

                    if (!bCompositionProductsSpecification.Exists(CompositionProductsSpecificationTable.COMPOSITION_PRODUCTS_CODE, CompositionProductsSpecificationTable.PRODUCTION_PROCESS_CODE))
                    {
                        bCompositionProductsSpecification.Add(CompositionProductsSpecificationTable);
                    }
                    else
                    {
                        bCompositionProductsSpecification.Update(CompositionProductsSpecificationTable);
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
