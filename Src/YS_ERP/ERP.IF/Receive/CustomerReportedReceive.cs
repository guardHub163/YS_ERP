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
    public class CustomerReportedReceive : AbstractReceive
    {
        public CustomerReportedReceive(string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public CustomerReportedReceive(bool anAutoMode, string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(anAutoMode, aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public override void doCheckError()
        {

        }

        public override string[] doUpdateDB()
        {
            BaseCustomerReportedTable CustomerReportedTable = null;
            BCustomerReported bCustomerReported = new BCustomerReported();
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
                //报备客户名称
                str.Append(CheckCustomer(CConvert.ToString(GetValue(dr, "CUSTOMER_REPORTED_CODE")), "报备客户名称"));
                //报备日期
                str.Append(CheckDateTime(GetValue(dr, "REPORTED_DATE", DateTime.Now), "报备日期"));
                //有效日期
                str.Append(CheckDateTime(GetValue(dr, "EFFECTIVE_DATE", DateTime.Now.AddMonths(3)), "有效日期"));
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
                    CustomerReportedTable = new BaseCustomerReportedTable();
                    CustomerReportedTable.CUSTOMER_CODE = CConvert.ToString(GetValue(dr, "CUSTOMER_CODE"));
                    CustomerReportedTable.CUSTOMER_REPORTED_CODE = CConvert.ToString(GetValue(dr, "CUSTOMER_REPORTED_CODE"));
                    CustomerReportedTable.REPORTED_DATE = CConvert.ToDateTime(GetValue(dr, "REPORTED_DATE", DateTime.Now));
                    CustomerReportedTable.CREATE_USER = _userInfo.CODE;
                    CustomerReportedTable.LAST_UPDATE_USER = _userInfo.CODE;
                    if (CConvert.ToDateTime(GetValue(dr, "REPORTED_DATE", DateTime.Now)) != DateTime.Now)
                    {
                        CustomerReportedTable.EFFECTIVE_DATE = CConvert.ToDateTime(GetValue(dr, "REPORTED_DATE", DateTime.Now)).AddMonths(3);
                    }
                    else
                    {
                        CustomerReportedTable.EFFECTIVE_DATE = CConvert.ToDateTime(GetValue(dr, "EFFECTIVE_DATE", DateTime.Now.AddMonths(3)));
                    }
                    CustomerReportedTable.STATUS_FLAG = CConvert.ToInt32(GetValue(dr, "STATUS_FLAG", CConstant.NORMAL));

                    if (!bCustomerReported.Exists(CustomerReportedTable.CUSTOMER_CODE, CustomerReportedTable.CUSTOMER_REPORTED_CODE))
                    {
                        bCustomerReported.Add(CustomerReportedTable);
                    }
                    else
                    {
                        bCustomerReported.Update(CustomerReportedTable);
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
