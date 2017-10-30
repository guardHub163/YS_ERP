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
    public class WarehouseReceive : AbstractReceive
    {
        public WarehouseReceive(string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public WarehouseReceive(bool anAutoMode, string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(anAutoMode, aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public override void doCheckError()
        {

        }

        public override string[] doUpdateDB()
        {
            BaseWarehouseTable WarehouseTable = null;
            BWarehouse bWarehouse = new BWarehouse();
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
                //简称
                str.Append(CheckLenght(GetValue(dr, "NAME_SHORT"), 50, "简称"));
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
                //备注
                str.Append(CheckLenght(GetValue(dr, "MEMO"), 255, "备注"));
                //状态
                str.Append(CheckInt(GetValue(dr, "STATUS_FLAG", 1), 9, "状态"));

                if (str.ToString().Trim().Length > 0)
                {
                    strError.Append(GetStringBuilder(dr, str.ToString().Trim()));
                    failureData++;
                    continue;
                }
                try
                {
                    WarehouseTable = new BaseWarehouseTable();
                    WarehouseTable.CODE = CConvert.ToString(GetValue(dr, "CODE"));
                    WarehouseTable.NAME = CConvert.ToString(GetValue(dr, "NAME"));
                    WarehouseTable.NAME_SHORT = CConvert.ToString(GetValue(dr, "NAME_SHORT"));
                    WarehouseTable.ZIP_CODE = CConvert.ToString(GetValue(dr, "ZIP_CODE"));
                    WarehouseTable.ADDRESS_FIRST = CConvert.ToString(GetValue(dr, "ADDRESS_FIRST"));
                    WarehouseTable.ADDRESS_MIDDLE = CConvert.ToString(GetValue(dr, "ADDRESS_MIDDLE"));
                    WarehouseTable.ADDRESS_LAST = CConvert.ToString(GetValue(dr, "ADDRESS_LAST"));
                    WarehouseTable.PHONE_NUMBER = CConvert.ToString(GetValue(dr, "PHONE_NUMBER"));
                    WarehouseTable.FAX_NUMBER = CConvert.ToString(GetValue(dr, "FAX_NUMBER"));
                    WarehouseTable.CONTACT_NAME = CConvert.ToString(GetValue(dr, "CONTACT_NAME"));
                    WarehouseTable.MOBIL_NUMBER = CConvert.ToString(GetValue(dr, "MOBIL_NUMBER"));
                    WarehouseTable.EMAIL = CConvert.ToString(GetValue(dr, "EMIAL"));
                    WarehouseTable.MEMO = CConvert.ToString(GetValue(dr, "MEMO"));
                    WarehouseTable.STATUS_FLAG = CConvert.ToInt32(GetValue(dr, "STATUS_FLAG", CConstant.NORMAL));
                    WarehouseTable.CREATE_USER = _userInfo.CODE;
                    WarehouseTable.LAST_UPDATE_USER = _userInfo.CODE;

                    if (!bWarehouse.Exists(WarehouseTable.CODE))
                    {
                        WarehouseTable.CREATE_DATE_TIME = DateTime.Now;
                        WarehouseTable.LAST_UPDATE_TIME = DateTime.Now;
                        bWarehouse.Add(WarehouseTable);
                    }
                    else
                    {
                        WarehouseTable.LAST_UPDATE_TIME = DateTime.Now;
                        bWarehouse.Update(WarehouseTable);
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
