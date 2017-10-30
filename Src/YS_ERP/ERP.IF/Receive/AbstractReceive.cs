using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using CZZD.ERP.Model;
using CZZD.ERP.Common;
using CZZD.ERP.Bll;
using CZZD.ERP.CacheData;

namespace CZZD.ERP.IF
{
    public abstract class AbstractReceive
    {

        //数据采集 模式 
        //true  自动
        //false 手动
        protected bool _autoMode;

        //文件 路径
        protected string _fileName;

        //导入的文件类型
        protected string _fileType;

        //EXCEL文件指定的Sheet
        protected string _sheet;

        //文件内容 
        protected DataTable _csvDataTable;

        //各表对应的字段的集合
        protected Hashtable _filedsHt = new Hashtable();

        //错误类型
        protected const int errorType = 1;

        //备份类型
        protected const int backupType = 2;

        //NULL ERROR
        protected string ERROR_NULL = ":必须输入项为空;";

        //TYPE ERROR
        protected string ERROR_TYPE = ":数据类型转换错误;";

        //lENGHT EXCEED ERROR
        protected string ERROR_LENGHT = ":数据长度超出;";

        //DO NOT EXIST ERROR
        protected string ERROR_EXIST = ":不存在;";

        //登录用户
        protected BaseUserTable _userInfo;

        //单位
        private Hashtable _unitTable = new Hashtable();

        //货币
        private Hashtable _currencyTable = new Hashtable();

        //产线
        private Hashtable _slipTypeTable = new Hashtable();

        //仓库
        private Hashtable _wasehouseTable = new Hashtable();

        //客户
        private Hashtable _customerTable = new Hashtable();

        //供应商
        private Hashtable _supplierTable = new Hashtable();

        //公司
        private Hashtable _companyTable = new Hashtable();

        //部门
        private Hashtable _departmentTable = new Hashtable();

        //角色
        private Hashtable _rolesTable = new Hashtable();

        //组成品
        private Hashtable _compositionproductsTable = new Hashtable();
        
        
        //构造函数
        public AbstractReceive(bool anAutoMode, string aFileName, string aFileType, string aSheet, Hashtable aFiledsHt, BaseUserTable userInfo)
        {
            this._autoMode = anAutoMode;
            this._fileName = aFileName;
            this._fileType = aFileType;
            this._sheet = aSheet;
            this._filedsHt = aFiledsHt;
            this._csvDataTable = new DataTable();
            this._userInfo = userInfo;
        }


        //构造函数
        public AbstractReceive(string aFileName, string aFileType, string aSheet, Hashtable aFiledsHt, BaseUserTable userInfo)
        {
            this._autoMode = false;
            this._fileName = aFileName;
            this._fileType = aFileType;
            this._sheet = aSheet;
            this._filedsHt = aFiledsHt;
            this._csvDataTable = new DataTable();
            this._userInfo = userInfo;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string[] DoReceiveJob()
        {
            //读取CSV文件，并保存到DATATABLE
            ReadCsv();
            //内容check`
            doCheckError();
            //DB更新
            string[] importInfo = doUpdateDB();
            try
            {
                BllReceiveLogTable receiveLogTable = new BllReceiveLogTable();
                receiveLogTable.AUTO_MODE = this._autoMode;
                receiveLogTable.SOURCE_FILE = this._fileName;
                receiveLogTable.SUCCESS_NUMBER = int.Parse(importInfo[0]);
                receiveLogTable.FAILURE_NUMBER = int.Parse(importInfo[1]);
                receiveLogTable.ERROR_FILE = importInfo[2];
                receiveLogTable.BACK_FILE = importInfo[3];
                if (receiveLogTable.ERROR_FILE == "")
                {
                    receiveLogTable.STATUS_FLAG = CConstant.INIT;
                }
                //new BCommon().InsertReceiveLog(receiveLogTable);
            }
            catch (Exception ex) { }
            return importInfo;
        }

        /// <summary>
        /// 读取文件，并保存到DATATABLE
        /// </summary>
        public void ReadCsv()
        {
            if ("EXCEL".Equals(this._fileType))
            {
                this._csvDataTable = FileOperator.ReadExcel(this._fileName, this._sheet, true);
            }
            else if ("CSV".Equals(this._fileType))
            {
                //this._csvDataTable = FileOperator.ReadExcel(this._fileName, false);
            }
            else if ("TXT".Equals(this._fileType))
            {
                //this._csvDataTable = FileOperator.ReadExcel(this._fileName, false);
            }
        }

        //内容check
        public abstract void doCheckError();

        //DB更新
        public abstract string[] doUpdateDB();

        /// <summary>
        /// 错误记录文件的保存
        /// </summary>
        protected string WriteFile(string txtMsg)
        {
            string path = _fileName.Substring(0, _fileName.LastIndexOf('\\')+1);
            if (_autoMode)
            {
                //从数据库中取得自动连携路径
            }
            string fileName = "Error_" + _fileName.Substring(_fileName.LastIndexOf('\\')+1);
            return FileOperator.writeFile(path, fileName, txtMsg);
        }

        /// <summary>
        /// 文件备份
        /// </summary>
        protected string BackupFile()
        {
            //string path = "";
            //if (_autoMode)
            //{
            //    //从数据库中取得自动连携路径
            //    //path = "c:\\auto\\backupPath\\";
            //    try
            //    {
            //        //path = new BSysWithPortable().SysWithPortableTableDispByStr(" where 1=1 ").BACKUP_PATH + "\\";
            //    }
            //    catch
            //    {
            //        path = this.filePath + "\\backup\\";
            //    }
            //}
            //else
            //{
            //    path = this.filePath + "\\backup\\";
            //}
            //string backFile = "back_" + this._fileName;
            //if (FileOperator.CopyFile(this.filePath + "\\" + this._fileName, path, backFile))
            //{
            //    return path + "\\" + backFile;
            //}
            return "";
        }

        #region 数据验证
        /// <summary>
        /// 表更新异常信息记录
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected StringBuilder GetStringBuilder(DataRow dr, string errorMsg)
        {
            StringBuilder strError = new StringBuilder();
            strError.Append(dr[0].ToString());
            for (int i = 1; i < 100; i++)
            {
                try
                {
                    strError.Append("," + dr[i].ToString());
                }
                catch
                {
                    break;
                }
            }
            strError.Append("  " + errorMsg);
            strError.Append("\r\n");

            return strError;
        }



        /// <summary>
        /// Decimal类型数据Check
        /// </summary>
        protected string CheckDecimal(Object obj, Object maxLength, Object maxDecimalLength, string title)
        {
            //NULL Check
            if (obj == null)
            {
                return title + ERROR_NULL;
            }

            //""
            if ("".Equals(obj.ToString()))
            {
                return "";
            }

            //数据类型
            try
            {
                decimal.Parse(obj.ToString());
            }
            catch
            {
                return title + ERROR_TYPE;
            }

            //数据长度Check
            string[] str = obj.ToString().Split('.');
            if (str.Length > 2
                || (maxLength != null && str[0].Length > int.Parse(maxLength.ToString()))
                || (maxDecimalLength != null && str.Length > 1 && str[1].Length > int.Parse(maxDecimalLength.ToString())))
            {
                return title + ERROR_LENGHT;
            }

            return "";
        }

        /// <summary>
        /// Int类型数据Check
        /// </summary>
        protected string CheckInt(object obj, object maxValue, string title)
        {
            //NULL Check
            if (obj == null)
            {
                return title + ERROR_NULL;
            }

            //""
            if ("".Equals(obj.ToString()))
            {
                return "";
            }

            //数据类型Check
            try
            {
                int.Parse(obj.ToString());
            }
            catch
            {
                return title + ERROR_TYPE;
            }

            //数据长度Check
            if (maxValue != null && int.Parse(obj.ToString()) > int.Parse(maxValue.ToString()))
            {
                return title + ERROR_LENGHT;
            }
            return "";
        }

        /// <summary>
        /// String类型数据Check
        /// </summary>
        protected string CheckString(object obj, int maxLength, string title)
        {
            //NULL Check
            if (obj == null)
            {
                return title + ERROR_NULL;
            }

            //数据长度Check
            if (obj.ToString().Length > maxLength)
            {
                return title + ERROR_LENGHT;
            }
            return "";
        }

        /// <summary>
        /// String类型数据Check
        /// </summary>
        protected string CheckString(object obj, string title)
        {
            //NULL Check
            if (obj == null)
            {
                return title + ERROR_NULL;
            }
            return "";
        }

        /// <summary>
        /// String lenght数据Check
        /// </summary>
        protected string CheckLenght(object obj, int maxLength, string title)
        {
            //NULL Check
            if (obj == null)
            {
                return "";
            }

            //数据长度Check
            if (obj.ToString().Length > maxLength)
            {
                return title + ERROR_LENGHT;
            }
            return "";
        }


        /// <summary>
        /// Char类型数据Check
        /// </summary>
        protected string CheckChar(Object obj, string title)
        {
            //NULL Check
            if (obj == null)
            {
                return title + ERROR_NULL;
            }

            //数据类型Check
            try
            {
                char.Parse(obj.ToString());
            }
            catch
            {
                return title + ERROR_TYPE;
            }

            return "";
        }

        /// <summary>
        /// 日期Check
        /// </summary>
        protected string CheckDateTime(Object obj, string title)
        {
            //NULL Check
            if (obj == null)
            {
                return title + ERROR_NULL;
            }

            //""
            if ("".Equals(obj.ToString()))
            {
                return "";
            }

            //数据类型Check
            try
            {
                DateTime.Parse(obj.ToString());
            }
            catch
            {
                return title + ERROR_TYPE;
            }
            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        protected object GetValue(DataRow dr, string key)
        {
            object ret = null;
            if (!"".Equals(_filedsHt[key]))
            {
                try
                {
                    ret = dr[CConvert.ToString(_filedsHt[key])];
                }
                catch
                {
                    ret = null;
                }
            }
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        protected object GetValue(DataRow dr, string key, object defaultValue)
        {
            object ret = defaultValue;
            if (!"".Equals(_filedsHt[key]))
            {
                try
                {
                    ret = dr[CConvert.ToString(_filedsHt[key])];
                }
                catch
                {
                    ret = defaultValue;
                }
            }
            return ret;
        }


        #region 单位编号存在CHECK
        /// <summary>
        /// 单位编号存在CHECK
        /// </summary>
        protected string CheckUnit(string unitCode, string title)
        {
            if (unitCode == null || "".Equals(unitCode.ToString()))
            {
                return title + ERROR_NULL;
            }

            if (_unitTable[unitCode.ToString()] != null)
            {
                return "";
            }
            BUnit bUnit = new BUnit();
            if (bUnit.Exists(unitCode))
            {
                _unitTable.Add(unitCode, unitCode);
                return "";
            }

            return title + ERROR_EXIST;
        }

        #endregion

        #region 商品种类的Check
        protected string CheckProductGroup(string productGroup, string title)
        {
            if ((productGroup == null || "".Equals(productGroup.ToString())))
            {
                return title + ERROR_NULL;
            }
            BProductGroup bProductGroup = new BProductGroup();
            if (bProductGroup.Exists(productGroup))
            {
                return "";
            }
            return title + ERROR_EXIST;
        }

        #endregion

        #region 货币存在的CHECK
        protected string CheckCurrency(string currencyCode, string title)
        {
            if (currencyCode == null || "".Equals(currencyCode.ToString()))
            {
                return title + ERROR_NULL;
            }

            if (_currencyTable[currencyCode] != null)
            {
                return "";
            }
            BCurrency bCurrency = new BCurrency();
            if (bCurrency.Exists(currencyCode))
            {
                _currencyTable.Add(currencyCode, currencyCode);
                return "";
            }
            return title + ERROR_EXIST;
        }

        #endregion

        #region 货位存在的Check
        public string CheckLocation(string location, string title)
        {
            if (location == null || "".Equals(location))
            {
                return title + ERROR_NULL;
            }
            BLocation bLocation = new BLocation();
            if (bLocation.Exists(location))
            {
                return "";
            }
            return title + ERROR_EXIST;
        }
        #endregion

        #region 海关存在的Check
        public string CheckHsCode(string hsCode, string title)
        {
            if (hsCode == null || "".Equals(hsCode))
            {
                return title + ERROR_NULL;
            }
            BHsCode bHsCode = new BHsCode();
            if (bHsCode.Exists(hsCode))
            {
                return "";
            }
            return title + ERROR_EXIST;
        }
        #endregion

        #region 商品存在的Check
        public string CheckProduct(string product, string title)
        {
            if (product == null || "".Equals(product))
            {
                return title + ERROR_NULL;
            }
            BProduct bProuduct = new BProduct();
            if (bProuduct.Exists(product))
            {
                return "";
            }
            return title + ERROR_EXIST;
        }
        #endregion

        #region 仓库存在的CHECK
        protected string CheckWarehouse(string warehouseCode, string title)
        {
            if (warehouseCode == null || "".Equals(warehouseCode.ToString()))
            {
                return title + ERROR_NULL;
            }

            if (_wasehouseTable[warehouseCode] != null)
            {
                return "";
            }
            BCurrency bCurrency = new BCurrency();
            if (bCurrency.Exists(warehouseCode))
            {
                _wasehouseTable.Add(warehouseCode, warehouseCode);
                return "";
            }
            return title + ERROR_EXIST;
        }
        #endregion

        #region 客户存在的Check
        public string CheckCustomer(string customer, string title)
        {
            if (customer == null || "".Equals(customer))
            {
                return title + ERROR_NULL;
            }
            if (_customerTable[customer.ToString()] != null)
            {
                return "";
            }
            BCustomer bCustomer = new BCustomer();
            if (bCustomer.Exists(customer))
            {
                _customerTable.Add(customer, customer);
                return "";
            }
            return title + ERROR_EXIST;
        }
        #endregion

        #region 供应商存在的Check
        public string CheckSupplier(string supplier, string title)
        {
            if (supplier == null || "".Equals(supplier))
            {
                return title + ERROR_NULL;
            }
            if (_supplierTable[supplier.ToString()] != null)
            {
                return "";
            }
            BSupplier bSupplier = new BSupplier();
            if (bSupplier.Exists(supplier))
            {
                _supplierTable.Add(supplier, supplier);
                return "";
            }
            return title + ERROR_EXIST;
        }
        #endregion

        #region 产线存在的Check
        public string CheckSlipType(string typecode, string title)
        {
            if (typecode == null || "".Equals(typecode))
            {
                return title + ERROR_NULL;
            }
            if (_slipTypeTable[typecode.ToString()] != null)
            {
                return "";
            }
            BSlipType bSlipType = new BSlipType();
            if (bSlipType.Exists(typecode))
            {
                _slipTypeTable.Add(typecode, typecode);
                return "";
            }
            return title + ERROR_EXIST;
        }
        #endregion

        #region 公司存在的Check
        public string CheckCompany(string company, string title)
        {
            if (company == null || "".Equals(company))
            {
                return title + ERROR_NULL;
            }
            if (_companyTable[company.ToString()] != null)
            {
                return "";
            }
            BCompany bCompany = new BCompany();
            if (bCompany.Exists(company))
            {
                _companyTable.Add(company, company);
                return "";
            }
            return title + ERROR_EXIST;
        }
        #endregion

        #region 部门存在的Check
        public string CheckDepartment(string department, string title)
        {
            if (department == null || "".Equals(department))
            {
                return title + ERROR_NULL;
            }
            if (_departmentTable[department.ToString()] != null)
            {
                return "";
            }
            BDepartment bDepartment = new BDepartment();
            if (bDepartment.Exists(department))
            {
                _departmentTable.Add(department, department);
                return "";
            }
            return title + ERROR_EXIST;
        }
        #endregion

        #region 角色存在的Check
        public string CheckRoles(string roles, string title)
        {
            if (roles == null || "".Equals(roles))
            {
                return title + ERROR_NULL;
            }
            if (_rolesTable[roles.ToString()] != null)
            {
                return "";
            }
            BRoles bRoles = new BRoles();
            if (bRoles.Exists(roles))
            {
                _rolesTable.Add(roles, roles);
                return "";
            }
            return title + ERROR_EXIST;
        }
        #endregion

        //#region 单据类型存在的Check
        //public string CheckSlipType(string sliptype, string title)
        //{
        //    bool isExsit = false;
        //    if (sliptype == null || "".Equals(sliptype))
        //    {
        //        return title + ERROR_NULL;
        //    }
        //    foreach (DataRow row in CCacheData.SlipType.Rows)
        //    {
        //        if (CConvert.ToString(row["CODE"]) == sliptype)
        //        {
        //            isExsit = true;
        //        }
        //    }
        //    if (isExsit)
        //    {
        //        return "";
        //    }
        //    else
        //    {
        //        return title + ERROR_EXIST;
        //    }
        //    return title + ERROR_EXIST;
        //}
        //#endregion

        #region 组成品存在的Check
        public string CheckCompositionProducts(string composition, string title)
        {
            if (composition == null || "".Equals(composition))
            {
                return title + ERROR_NULL;
            }
            if (_compositionproductsTable[composition.ToString()] != null)
            {
                return "";
            }
            BCompositionProducts bCompositionProducts = new BCompositionProducts();
            if (bCompositionProducts.Exists(composition))
            {
                _compositionproductsTable.Add(composition, composition);
                return "";
            }
            return title + ERROR_EXIST;
        }
        #endregion
        #endregion
    }//end class
}
