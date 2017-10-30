using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using CZZD.ERP.Model;
using CZZD.ERP.Bll;
using CZZD.ERP.Common;

namespace CZZD.ERP.IF
{
    public class DeliveryReceive : AbstractReceive
    {
        public DeliveryReceive(string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public DeliveryReceive(bool anAutoMode, string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(anAutoMode, aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public override void doCheckError()
        {

        }

        public override string[] doUpdateDB()
        {
            BaseDeliveryTable DeliveryTable = null;
            BDelivery bDelivery = new BDelivery();
            StringBuilder strError = new StringBuilder();
            int successData = 0;
            int failureData = 0;
            string errorFilePath = "";
            string backupFilePath = "";

            //数据导入处理
            foreach (DataRow dr in _csvDataTable.Rows)
            {
                StringBuilder str = new StringBuilder();
                //客户编号
                str.Append(CheckCustomer(CConvert.ToString(GetValue(dr, "CUSTOMER_CODE")), "客户编号"));
                //地址编号
                if (!string.IsNullOrEmpty(CConvert.ToString(GetValue(dr, "DELIVERY_CODE"))))
                {
                    str.Append(CheckString(GetValue(dr, "DELIVERY_CODE"), 20, "地址编号"));
                }
                else
                {
                    str.Append("地址编号不能为空!");
                }
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
                    DeliveryTable = new BaseDeliveryTable();
                    DeliveryTable.CUSTOMER_CODE = CConvert.ToString(GetValue(dr, "CUSTOMER_CODE"));
                    DeliveryTable.DELIVERY_CODE = CConvert.ToString(GetValue(dr, "DELIVERY_CODE"));
                    DeliveryTable.ZIP_CODE = CConvert.ToString(GetValue(dr, "ZIP_CODE"));
                    DeliveryTable.ADDRESS_FIRST = CConvert.ToString(GetValue(dr, "ADDRESS_FIRST"));
                    DeliveryTable.ADDRESS_MIDDLE = CConvert.ToString(GetValue(dr, "ADDRESS_MIDDLE"));
                    DeliveryTable.ADDRESS_LAST = CConvert.ToString(GetValue(dr, "ADDRESS_LAST"));
                    DeliveryTable.PHONE_NUMBER = CConvert.ToString(GetValue(dr, "PHONE_NUMBER"));
                    DeliveryTable.FAX_NUMBER = CConvert.ToString(GetValue(dr, "FAX_NUMBER"));
                    DeliveryTable.CONTACT_NAME = CConvert.ToString(GetValue(dr, "CONTACT_NAME"));
                    DeliveryTable.MOBIL_NUMBER = CConvert.ToString(GetValue(dr, "MOBIL_NUMBER"));
                    DeliveryTable.STATUS_FLAG = CConvert.ToInt32(GetValue(dr, "STATUS_FLAG", CConstant.NORMAL));
                    DeliveryTable.CREATE_USER = _userInfo.CODE;
                    DeliveryTable.LAST_UPDATE_USER = _userInfo.CODE;

                    if (!bDelivery.Exists(DeliveryTable.CUSTOMER_CODE, DeliveryTable.DELIVERY_CODE))
                    {
                        bDelivery.Add(DeliveryTable);
                    }
                    else
                    {
                        bDelivery.Update(DeliveryTable);
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
