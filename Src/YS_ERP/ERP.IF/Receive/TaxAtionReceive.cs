using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.Model;
using CZZD.ERP.Bll;
using System.Data;
using System.Collections;
using CZZD.ERP.Common;

namespace CZZD.ERP.IF
{
    public class TaxAtionReceive : AbstractReceive
    {
        public TaxAtionReceive(string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public TaxAtionReceive(bool anAutoMode, string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(anAutoMode, aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public override void doCheckError()
        {

        }

        public override string[] doUpdateDB()
        {
            BaseTaxAtionTable TaxAtionTable = null;
            BTaxAtion bTaxAtion = new BTaxAtion();
            StringBuilder strError = new StringBuilder();
            int successData = 0;
            int failureData = 0;
            string errorFilePath = "";
            string backupFilePath = "";

            //数据导入处理
            foreach (DataRow dr in _csvDataTable.Rows)
            {
                StringBuilder str = new StringBuilder();
                //编号
                if (!string.IsNullOrEmpty(CConvert.ToString(GetValue(dr, "CODE"))))
                {
                    str.Append(CheckString(GetValue(dr, "CODE"), 20, "编号"));
                }
                else
                {
                    str.Append("编号不能为空!");
                }
                //名称
                str.Append(CheckLenght(GetValue(dr, "NAME"), 100, "名称"));
                //税率(注:数据库值为17 时表示17%)
                str.Append(CheckDecimal(GetValue(dr, "TAX_RATE", 0), 3, 2, "税率"));
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
                    TaxAtionTable = new BaseTaxAtionTable();
                    TaxAtionTable.CODE = CConvert.ToString(GetValue(dr, "CODE"));
                    TaxAtionTable.NAME = CConvert.ToString(GetValue(dr, "NAME"));
                    TaxAtionTable.TAX_RATE = CConvert.ToDecimal(GetValue(dr, "TAX_RATE", 0));
                    TaxAtionTable.STATUS_FLAG = CConvert.ToInt32(GetValue(dr, "STATUS_FLAG", CConstant.NORMAL));
                    TaxAtionTable.CREATE_USER = _userInfo.CODE;
                    TaxAtionTable.LAST_UPDATE_USER = _userInfo.CODE;

                    if (!bTaxAtion.Exists(TaxAtionTable.CODE))
                    {
                        bTaxAtion.Add(TaxAtionTable);
                    }
                    else
                    {
                        bTaxAtion.Update(TaxAtionTable);
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
