using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using CZZD.ERP.Model;
using CZZD.ERP.Bll;
using CZZD.ERP.Common;
using System.Data;

namespace CZZD.ERP.IF
{
    public class MachineReceive : AbstractReceive
    {
        public MachineReceive(string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public MachineReceive(bool anAutoMode, string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(anAutoMode, aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public override void doCheckError()
        {

        }

        public override string[] doUpdateDB()
        {
            BaseSlipTypeCompositionProductsTable SlipTypeProductGroupTable = null;
            BSlipTypeCompositionProducts bSlipTypeProductGroup = new BSlipTypeCompositionProducts();
            StringBuilder strError = new StringBuilder();
            int successData = 0;
            int failureData = 0;
            string errorFilePath = "";
            string backupFilePath = "";

            //数据导入处理
            foreach (DataRow dr in _csvDataTable.Rows)
            {
                StringBuilder str = new StringBuilder();
                 //产线类型编号
                if (!string.IsNullOrEmpty(CConvert.ToString(GetValue(dr, "SLIP_TYPE_CODE"))))
                {
                    str.Append(CheckSlipType(CConvert.ToString(GetValue(dr, "SLIP_TYPE_CODE")), "产线类型编号"));
                }
                else
                {
                    str.Append("产线类型编号不能为空!");
                }
                //材料编号
                if (!string.IsNullOrEmpty(CConvert.ToString(GetValue(dr, "COMPOSITION_PRODUCTS_CODE"))))
                {
                    str.Append(CheckProductGroup(CConvert.ToString(GetValue(dr, "COMPOSITION_PRODUCTS_CODE")), "商品类别编号"));
                }
                else
                {
                    str.Append("材料编号不能为空!");
                }
               
                if (str.ToString().Trim().Length > 0)
                {
                    strError.Append(GetStringBuilder(dr, str.ToString().Trim()));
                    failureData++;
                    continue;
                }
                try
                {
                    SlipTypeProductGroupTable = new BaseSlipTypeCompositionProductsTable();
                    SlipTypeProductGroupTable.SLIP_TYPE_CODE = CConvert.ToString(GetValue(dr, "SLIP_TYPE_CODE"));
                    SlipTypeProductGroupTable.COMPOSITION_PRODUCTS_CODE = CConvert.ToString(GetValue(dr, "COMPOSITION_PRODUCTS_CODE"));

                    if (!bSlipTypeProductGroup.Exists(SlipTypeProductGroupTable.SLIP_TYPE_CODE, SlipTypeProductGroupTable.COMPOSITION_PRODUCTS_CODE))
                    {
                        bSlipTypeProductGroup.Add(SlipTypeProductGroupTable);
                    }
                    else
                    {
                        bSlipTypeProductGroup.Update(SlipTypeProductGroupTable);
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
