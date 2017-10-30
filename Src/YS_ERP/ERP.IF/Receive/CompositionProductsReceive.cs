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
    public class CompositionProductsReceive : AbstractReceive
    {
        public CompositionProductsReceive(string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public CompositionProductsReceive(bool anAutoMode, string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(anAutoMode, aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public override void doCheckError()
        {

        }

        public override string[] doUpdateDB()
        {
            BaseCompositionProductsTable CompositionProductsTable = null;
            BCompositionProducts bCompositionProducts = new BCompositionProducts();
            StringBuilder strError = new StringBuilder();
            int successData = 0;
            int failureData = 0;
            string errorFilePath = "";
            string backupFilePath = "";

            //数据导入处理
            foreach (DataRow dr in _csvDataTable.Rows)
            {
                StringBuilder str = new StringBuilder();
                //组成品编号
                if (!string.IsNullOrEmpty(CConvert.ToString(GetValue(dr, "CODE"))))
                {
                    str.Append(CheckString(GetValue(dr, "CODE"), 20, "组成品编号"));
                }
                else
                {
                    str.Append("组成品编号不能为空!");
                }
                //组成品名称
                str.Append(CheckLenght(GetValue(dr, "NAME"), 100, "组成品名称"));
                if (str.ToString().Trim().Length > 0)
                {
                    strError.Append(GetStringBuilder(dr, str.ToString().Trim()));
                    failureData++;
                    continue;
                }
                try
                {
                    CompositionProductsTable = new BaseCompositionProductsTable();
                    CompositionProductsTable.CODE = CConvert.ToString(GetValue(dr, "CODE"));
                    CompositionProductsTable.NAME = CConvert.ToString(GetValue(dr, "NAME"));
                    CompositionProductsTable.COMPANY_CODE = _userInfo.COMPANY_CODE;
                    CompositionProductsTable.STATUS_FLAG = CConstant.INIT;
                    CompositionProductsTable.CREATE_USER = _userInfo.CODE;
                    CompositionProductsTable.LAST_UPDATE_USER = _userInfo.CODE;

                    if (!bCompositionProducts.Exists(CompositionProductsTable.CODE))
                    {
                        bCompositionProducts.Add(CompositionProductsTable);
                    }
                    else
                    {
                        bCompositionProducts.Update(CompositionProductsTable);
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
