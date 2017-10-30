using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.Model;
using CZZD.ERP.Bll;
using System.Data;
using CZZD.ERP.Common;
using System.Collections;

namespace CZZD.ERP.IF
{
    public class CustomerReceive : AbstractReceive
    {
        public CustomerReceive(string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public CustomerReceive(bool anAutoMode, string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(anAutoMode, aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public override void doCheckError()
        {

        }

        public override string[] doUpdateDB()
        {
            BaseCustomerTable CustomerTable = null;
            BCustomer bCustomer = new BCustomer();
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
                str.Append(CheckLenght(GetValue(dr, "NAME"), 100, "名称"));
                //简称
                str.Append(CheckLenght(GetValue(dr, "NAME_SHORT"), 50, "简称"));
                //英文名称
                str.Append(CheckLenght(GetValue(dr, "NAME_ENGLISH"), 100, "英文名称"));
                //邮编
                str.Append(CheckLenght(GetValue(dr, "ZIP_CODE"), 8, "邮编"));
                //地址1
                str.Append(CheckLenght(GetValue(dr, "ADDRESS_FIRST"), 100, "地址1"));
                //地址2
                str.Append(CheckLenght(GetValue(dr, "ADDRESS_MIDDLE"), 100, "地址2"));
                //地址3
                str.Append(CheckLenght(GetValue(dr, "ADDRESS_LAST"), 100, "地址3"));
                //电话
                str.Append(CheckLenght(GetValue(dr, "PHONE_NUMBER"), 20, "电话"));
                //传真
                str.Append(CheckLenght(GetValue(dr, "FAX_NUMBER"), 20, "传真"));
                //联系人名称
                str.Append(CheckLenght(GetValue(dr, "CONTACT_NAME"), 50, "联系人名称"));
                //联系人电话
                str.Append(CheckLenght(GetValue(dr, "MOBIL_NUMBER"), 20, "联系人电话"));
                //邮箱
                str.Append(CheckLenght(GetValue(dr, "EMIAL"), 50, "邮箱"));
                //网址
                str.Append(CheckLenght(GetValue(dr, "URL"), 50, "网址"));
                //备注
                str.Append(CheckLenght(GetValue(dr, "MEMO"), 255, "备注"));
                //类型
                if (CConvert.ToInt32(GetValue(dr, "TYPE", 1)) != 1 && CConvert.ToInt32(GetValue(dr, "TYPE", 1)) != 2 && CConvert.ToString(GetValue(dr, "TYPE", 1)) != "")
                {
                    str.Append("类型只能为1或2!");
                }
                else
                {
                    str.Append(CheckInt(GetValue(dr, "TYPE", 1), 2, "类型"));
                }
                //是否请款公司
                if (CConvert.ToInt32(GetValue(dr, "CLAIM_FLAG", 1)) != 1 && CConvert.ToInt32(GetValue(dr, "CLAIM_FLAG", 1)) != 2 && CConvert.ToString(GetValue(dr, "CLAIM_FLAG", 1)) != "")
                {
                    str.Append("是否请款公司只能为1或2!");
                }
                else
                {
                    str.Append(CheckInt(GetValue(dr, "CLAIM_FLAG", 1), 2, "是否请款公司"));
                }
                //请款公司编号
                str.Append(CheckLenght(GetValue(dr, "CLAIM_CODE"), 20, "请款公司编号"));
                //货币
                if (!string.IsNullOrEmpty(CConvert.ToString(GetValue(dr, "CURRENCE_CODE"))))
                {
                    str.Append(CheckCurrency(CConvert.ToString(GetValue(dr, "CURRENCE_CODE")), "货币"));
                }
                //状态
                str.Append(CheckInt(GetValue(dr, "STATUS_FLAG", 1), 9, "状态"));
                //备考2
                str.Append(CheckLenght(GetValue(dr, "MEMO2"), 100, "备考2"));
                //日文名称
                str.Append(CheckLenght(GetValue(dr, "NAME_JP"), 100, "日文名称"));

                if (str.ToString().Trim().Length > 0)
                {
                    strError.Append(GetStringBuilder(dr, str.ToString().Trim()));
                    failureData++;
                    continue;
                }
                try
                {
                    CustomerTable = new BaseCustomerTable();
                    CustomerTable.CODE = CConvert.ToString(GetValue(dr, "CODE"));
                    CustomerTable.NAME = CConvert.ToString(GetValue(dr, "NAME"));
                    CustomerTable.NAME_SHORT = CConvert.ToString(GetValue(dr, "NAME_SHORT"));
                    CustomerTable.NAME_ENGLISH = CConvert.ToString(GetValue(dr, "NAME_ENGLISH"));
                    CustomerTable.ZIP_CODE = CConvert.ToString(GetValue(dr, "ZIP_CODE"));
                    CustomerTable.ADDRESS_FIRST = CConvert.ToString(GetValue(dr, "ADDRESS_FIRST"));
                    CustomerTable.ADDRESS_MIDDLE = CConvert.ToString(GetValue(dr, "ADDRESS_MIDDLE"));
                    CustomerTable.ADDRESS_LAST = CConvert.ToString(GetValue(dr, "ADDRESS_LAST"));
                    CustomerTable.PHONE_NUMBER = CConvert.ToString(GetValue(dr, "PHONE_NUMBER"));
                    CustomerTable.FAX_NUMBER = CConvert.ToString(GetValue(dr, "FAX_NUMBER"));
                    CustomerTable.CONTACT_NAME = CConvert.ToString(GetValue(dr, "CONTACT_NAME"));
                    CustomerTable.MOBIL_NUMBER = CConvert.ToString(GetValue(dr, "MOBIL_NUMBER"));
                    CustomerTable.EMAIL = CConvert.ToString(GetValue(dr, "EMIAL"));
                    CustomerTable.URL = CConvert.ToString(GetValue(dr, "URL"));
                    CustomerTable.MEMO = CConvert.ToString(GetValue(dr, "MEMO"));
                    CustomerTable.TYPE = CConvert.ToInt32(GetValue(dr, "TYPE", 1));
                    CustomerTable.CLAIM_FLAG = CConvert.ToInt32(GetValue(dr, "CLAIM_FLAG", 1));
                    CustomerTable.CLAIM_CODE = CConvert.ToString(GetValue(dr, "CLAIM_CODE"));
                    CustomerTable.CURRENCE_CODE = CConvert.ToString(GetValue(dr, "CURRENCE_CODE"));
                    CustomerTable.STATUS_FLAG = CConvert.ToInt32(GetValue(dr, "STATUS_FLAG", CConstant.NORMAL));
                    CustomerTable.MEMO2 = CConvert.ToString(GetValue(dr, "MEMO2"));
                    CustomerTable.NAME_JP = CConvert.ToString(GetValue(dr, "NAME_JP"));
                    CustomerTable.CREATE_USER = _userInfo.CODE;
                    CustomerTable.LAST_UPDATE_USER = _userInfo.CODE;
                                       
                    if (!bCustomer.Exists(CustomerTable.CODE))
                    {
                        bCustomer.Add(CustomerTable);
                    }
                    else
                    {
                        bCustomer.Update(CustomerTable);
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
