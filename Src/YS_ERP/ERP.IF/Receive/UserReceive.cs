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
    public class UserReceive : AbstractReceive
    {
        public UserReceive(string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public UserReceive(bool anAutoMode, string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(anAutoMode, aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public override void doCheckError()
        {
            
        }

        public override string[] doUpdateDB()
        {
            BaseUserTable UserTable = null;
            BUser bUser = new BUser();
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
                    str.Append(CheckString(GetValue(dr, "CODE"), 18, "编号"));
                }
                else
                {
                    str.Append("编号不能为空!");
                }
                //名称
                str.Append(CheckLenght(GetValue(dr, "NAME"), 100, "名称"));
                //密码
                if (!string.IsNullOrEmpty(CConvert.ToString(GetValue(dr, "PASSWORD"))))
                {
                    str.Append(CheckString(GetValue(dr, "PASSWORD"), 50 , "密码"));
                }
                //电话
                str.Append(CheckLenght(GetValue(dr, "PHONE"), 20, "电话"));
                //邮箱
                str.Append(CheckLenght(GetValue(dr, "EMIAL"), 50, "邮箱"));
                if (!string.IsNullOrEmpty(CConvert.ToString(GetValue(dr, "DEPARTMENT_CODE"))))
                {
                    str.Append(CheckDepartment(CConvert.ToString(GetValue(dr, "DEPARTMENT_CODE")), "部门"));
                }
                str.Append(CheckCompany(CConvert.ToString(GetValue(dr, "COMPANY_CODE")), "公司"));
                if (!string.IsNullOrEmpty(CConvert.ToString(GetValue(dr, "ROLES_CODE"))))
                {
                    str.Append(CheckRoles(CConvert.ToString(GetValue(dr, "ROLES_CODE")), "角色"));
                }
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
                    UserTable = new BaseUserTable();
                    UserTable.CODE = CConvert.ToString(GetValue(dr, "COMPANY_CODE")) + CConvert.ToString(GetValue(dr, "CODE"));
                    UserTable.NAME = CConvert.ToString(GetValue(dr, "NAME"));
                    UserTable.PASSWORD = CConvert.ToString(GetValue(dr, "PASSWORD"));
                    UserTable.PHONE = CConvert.ToString(GetValue(dr, "PHONE"));
                    UserTable.EMAIL = CConvert.ToString(GetValue(dr, "EMAIL"));
                    UserTable.DEPARTMENT_CODE = CConvert.ToString(GetValue(dr, "DEPARTMENT_CODE"));
                    UserTable.COMPANY_CODE = CConvert.ToString(GetValue(dr, "COMPANY_CODE"));
                    UserTable.ROLES_CODE = CConvert.ToString(GetValue(dr, "ROLES_CODE"));
                    UserTable.CREATE_USER = _userInfo.CODE;
                    UserTable.LAST_UPDATE_USER = _userInfo.CODE;

                    UserTable.STATUS_FLAG = CConvert.ToInt32(GetValue(dr, "STATUS_FLAG", CConstant.NORMAL));

                    if (!bUser.Exists(UserTable.CODE, UserTable.COMPANY_CODE))
                    {
                        bUser.Add(UserTable);
                    }
                    else
                    {
                        bUser.Update(UserTable);
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
