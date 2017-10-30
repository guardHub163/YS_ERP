using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.Model;
using CZZD.ERP.Bll;
using System.Collections;
using CZZD.ERP.Common;
using System.Data;

namespace CZZD.ERP.IF.Receive
{
    public class MasterMachineReceive : AbstractReceive
    {
        public MasterMachineReceive(string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public MasterMachineReceive(bool anAutoMode, string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(anAutoMode, aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public override void doCheckError()
        {
            
        }

        public override string[] doUpdateDB()
        {
            BaseMasterMachineTable MachineTable = null;
            BMasterMachine bMasterMachine = new BMasterMachine();
            StringBuilder strError = new StringBuilder();
            int successData = 0;
            int failureData = 0;
            string errorFilePath = "";
            string backupFilePath = "";

            //数据导入处理
            foreach (DataRow dr in _csvDataTable.Rows)
            {
                StringBuilder str = new StringBuilder();
                //机械编号
                if (!string.IsNullOrEmpty(CConvert.ToString(GetValue(dr, "MACHINE_CODE"))))
                {
                    str.Append(CheckString(GetValue(dr, "MACHINE_CODE"), 20, "机械编号"));
                }
                else
                {
                    str.Append("机械编号不能为空!");
                }
                //机械名称
                str.Append(CheckLenght(GetValue(dr, "MACHINE_NAME"), 100, "机械名称"));
                //需要家
                str.Append(CheckLenght(GetValue(dr, "CUSTOMER_CODE"), 50, "需要家"));
                //商品编号
                str.Append(CheckLenght(GetValue(dr, "PRODUCT_CODE"), 50, "商品编号"));
                //维修地点
                str.Append(CheckLenght(GetValue(dr, "MAINTENANCE_STATIONS"), 50, "维修地点"));
                //采购编号
                str.Append(CheckLenght(GetValue(dr, "PURCHASE_ORDER_SLIP_NUMBER"), 20, "采购编号"));
                //FANUC序列号
                str.Append(CheckLenght(GetValue(dr, "FANUC_SERIAL_NUMBER"), 20, "FANUC序列号"));
                //FANUC编号
                str.Append(CheckLenght(GetValue(dr, "FANUC_SLIP_NUMBER"), 20, "FANUC编号"));
                //采购日期
                if (GetValue(dr, "RECEIPT_DATE") != null)
                {
                    str.Append(CheckDateTime(GetValue(dr, "RECEIPT_DATE"), "采购日期"));
                }
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
                    MachineTable = new BaseMasterMachineTable();
                    MachineTable.MACHINE_CODE = CConvert.ToString(GetValue(dr, "MACHINE_CODE"));
                    MachineTable.MACHINE_NAME = CConvert.ToString(GetValue(dr, "MACHINE_NAME"));
                    MachineTable.CUSTOMER_CODE = CConvert.ToString(GetValue(dr, "CUSTOMER_CODE"));
                    MachineTable.PRODUCT_CODE = CConvert.ToString(GetValue(dr, "PRODUCT_CODE"));
                    MachineTable.MAINTENANCE_STATIONS = CConvert.ToString(GetValue(dr, "MAINTENANCE_STATIONS"));
                    MachineTable.PURCHASE_ORDER_SLIP_NUMBER = CConvert.ToString(GetValue(dr, "PURCHASE_ORDER_SLIP_NUMBER"));
                    MachineTable.FANUC_SERIAL_NUMBER = CConvert.ToString(GetValue(dr, "FANUC_SERIAL_NUMBER"));
                    MachineTable.FANUC_SLIP_NUMBER = CConvert.ToString(GetValue(dr, "FANUC_SLIP_NUMBER"));
                    MachineTable.RECEIPT_DATE = CConvert.ToDateTime(GetValue(dr, "RECEIPT_DATE"));
                    MachineTable.STATUS_FLAG = CConvert.ToInt32(GetValue(dr, "STATUS_FLAG", CConstant.NORMAL));
                    MachineTable.CREATE_USER = _userInfo.CODE;
                    MachineTable.LAST_UPDATE_USER = _userInfo.CODE;

                    if (!bMasterMachine.Exists(MachineTable.MACHINE_CODE))
                    {
                        bMasterMachine.Add(MachineTable);
                    }
                    else
                    {
                        bMasterMachine.Update(MachineTable);
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
