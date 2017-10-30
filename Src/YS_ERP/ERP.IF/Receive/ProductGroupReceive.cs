using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.Common;
using CZZD.ERP.Model;
using CZZD.ERP.Bll;
using System.Data;
using System.Collections;

namespace CZZD.ERP.IF
{
    public class ProductGroupReceive : AbstractReceive
    {
        public ProductGroupReceive(string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public ProductGroupReceive(bool anAutoMode, string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(anAutoMode, aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }


        public override void doCheckError()
        {

        }

        public override string[] doUpdateDB()
        {
            BaseProductGroupTable productGroupTable = null;
            BProductGroup bProductGroup = new BProductGroup();
            StringBuilder strError = new StringBuilder();
            int successData = 0;
            int failureData = 0;
            string errorFilePath = "";
            string backupFilePath = "";

            //数据导入处理
            foreach (DataRow dr in _csvDataTable.Rows)
            {
                StringBuilder str = new StringBuilder();
                //外购件种类编号
                if (!string.IsNullOrEmpty(CConvert.ToString(GetValue(dr, "CODE"))))
                {
                    str.Append(CheckString(GetValue(dr, "CODE"), 20, "编号"));
                }
                else
                {
                    str.Append("编号不能为空!");
                }
                //外购件种类名称
                str.Append(CheckLenght(GetValue(dr, "NAME"), 100, "名称"));
                //上级名称
                if (!string.IsNullOrEmpty(CConvert.ToString(GetValue(dr, "PARENT_CODE"))))
                {
                    str.Append(CheckProductGroup(CConvert.ToString(GetValue(dr, "PARENT_CODE")), "上级名称"));
                }
                //默认供应商
                str.Append(CheckSupplier(CConvert.ToString(GetValue(dr, "BASIC_SUPPLIER")), "默认供应商"));
                //供应商2
                if (!string.IsNullOrEmpty(CConvert.ToString(GetValue(dr, "SECOND_SUPPLIER_CODE"))))
                {
                    str.Append(CheckSupplier(CConvert.ToString(GetValue(dr, "SECOND_SUPPLIER_CODE")), "供应商2"));
                }
                //供应商3
                if (!string.IsNullOrEmpty(CConvert.ToString(GetValue(dr, "THIRD_SUPPLIER_CODE"))))
                {
                    str.Append(CheckSupplier(CConvert.ToString(GetValue(dr, "THIRD_SUPPLIER_CODE")), "供应商3"));
                }

                if (str.ToString().Trim().Length > 0)
                {
                    strError.Append(GetStringBuilder(dr, str.ToString().Trim()));
                    failureData++;
                    continue;
                }
                try
                {
                    productGroupTable = new BaseProductGroupTable();
                    productGroupTable.CODE = CConvert.ToString(GetValue(dr, "CODE"));
                    productGroupTable.NAME = CConvert.ToString(GetValue(dr, "NAME"));
                    productGroupTable.PARENT_CODE = CConvert.ToString(GetValue(dr, "PARENT_CODE"));
                    productGroupTable.BASIC_SUPPLIER = CConvert.ToString(GetValue(dr, "BASIC_SUPPLIER"));
                    productGroupTable.SECOND_SUPPLIER_CODE = CConvert.ToString(GetValue(dr, "SECOND_SUPPLIER_CODE"));
                    productGroupTable.THIRD_SUPPLIER_CODE = CConvert.ToString(GetValue(dr, "THIRD_SUPPLIER_CODE"));
                    productGroupTable.STATUS_FLAG =  CConstant.INIT;
                    productGroupTable.CREATE_USER = _userInfo.CODE;
                    productGroupTable.LAST_UPDATE_USER = _userInfo.CODE;

                    if (!bProductGroup.Exists(productGroupTable.CODE))
                    {
                        bProductGroup.Add(productGroupTable);
                    }
                    else
                    {
                        bProductGroup.Update(productGroupTable);
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
