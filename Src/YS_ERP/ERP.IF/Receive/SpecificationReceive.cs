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
    public class SpecificationReceive: AbstractReceive
    {
        public SpecificationReceive(string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public SpecificationReceive(bool anAutoMode, string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(anAutoMode, aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public override void doCheckError()
        {

        }

        public override string[] doUpdateDB()
        {
            BaseProductTable SpecificationTable = null;
            BProduct bSpecification = new BProduct();
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
                if (!string.IsNullOrEmpty(CConvert.ToString(GetValue(dr, "CODE"))))
                {
                    str.Append(CheckString(GetValue(dr, "CODE"), 20, "规格型号编号"));
                }
                else
                {
                    str.Append("规格型号编号不能为空!");
                }
                //规格型号名称
                str.Append(CheckLenght(GetValue(dr, "NAME"), 100, "规格型号名称"));
                //规格
                str.Append(CheckLenght(GetValue(dr, "SPEC"), 50, "规格"));
                //单位
                if (!string.IsNullOrEmpty(CConvert.ToString(GetValue(dr, "BASIC_UNIT_CODE"))))
                {
                    str.Append(CheckUnit(CConvert.ToString(GetValue(dr, "BASIC_UNIT_CODE")), "单位编号"));
                }
                //销售单价
                str.Append(CheckDecimal(GetValue(dr, "SALES_PRICE", 0), 12, 2, "销售单价"));

                if (str.ToString().Trim().Length > 0)
                {
                    strError.Append(GetStringBuilder(dr, str.ToString().Trim()));
                    failureData++;
                    continue;
                }
                try
                {
                    SpecificationTable = new BaseProductTable();
                    SpecificationTable.CODE = CConvert.ToString(GetValue(dr, "CODE"));
                    SpecificationTable.NAME = CConvert.ToString(GetValue(dr, "NAME"));
                    SpecificationTable.SPEC = CConvert.ToString(GetValue(dr, "SPEC"));
                    SpecificationTable.BASIC_UNIT_CODE = CConvert.ToString(GetValue(dr, "BASIC_UNIT_CODE"));
                    SpecificationTable.SALES_PRICE = CConvert.ToDecimal(GetValue(dr, "SALES_PRICE"));
                    SpecificationTable.PRODUCT_FLAG = CConstant.PRODUCT_FLAG_SPEC;
                    SpecificationTable.STATUS_FLAG = CConstant.INIT;
                    SpecificationTable.CREATE_USER = _userInfo.CODE;
                    SpecificationTable.LAST_UPDATE_USER = _userInfo.CODE;

                    if (!bSpecification.Exists(SpecificationTable.CODE))
                    {
                        bSpecification.Add(SpecificationTable);
                    }
                    else
                    {
                        bSpecification.Update(SpecificationTable);
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

