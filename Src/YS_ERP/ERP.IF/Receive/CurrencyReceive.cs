using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.Model;
using CZZD.ERP.Bll;
using CZZD.ERP.Common;
using System.Data;
using System.Collections;

namespace CZZD.ERP.IF
{
    public class CurrencyReceive : AbstractReceive
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);

        public CurrencyReceive(string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public CurrencyReceive(bool anAutoMode, string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(anAutoMode, aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public override string[] doUpdateDB()
        {
            BaseCurrencyTable CurrencyTable = null;
            BCurrency bCurrency = new BCurrency();
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
                    CurrencyTable = new BaseCurrencyTable();
                    CurrencyTable.CODE = CConvert.ToString(GetValue(dr, "CODE"));
                    CurrencyTable.NAME = CConvert.ToString(GetValue(dr, "NAME"));
                    CurrencyTable.CREATE_USER = _userInfo.CODE;
                    CurrencyTable.LAST_UPDATE_USER = _userInfo.CODE;

                    CurrencyTable.STATUS_FLAG = CConvert.ToInt32(GetValue(dr, "STATUS_FLAG", CConstant.NORMAL));

                    if (!bCurrency.Exists(CurrencyTable.CODE))
                    {
                        bCurrency.Add(CurrencyTable);
                    }
                    else
                    {
                        bCurrency.Update(CurrencyTable);
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
