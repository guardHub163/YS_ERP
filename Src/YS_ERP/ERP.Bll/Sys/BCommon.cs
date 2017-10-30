using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using System.Data;
using CZZD.ERP.Model;

namespace CZZD.ERP.Bll
{
    public class BCommon
    {
        ICommon dal = DALFactory.DataAccess.CreateCommonManage();

        #region 数据库连接测试
        public bool IsDBConn(string strconn, string strsql)
        {
            return dal.IsDBConn(strconn, strsql);
        }
        #endregion

        #region 基础数据的处理
        /// <summary>
        /// 
        /// </summary>
        public string GetSeqNumber(string blltype)
        {
            return dal.GetSeqNumber(blltype);
        }

        /// <summary>
        /// 
        /// </summary>
        public DataSet GetMasterList(string tableName, string code, string name, string strWhere)
        {
            return dal.GetMasterList(tableName, code, name, strWhere);
        }

        /// <summary>
        /// 
        /// </summary>
        public BaseMaster GetBaseMaster(string tableName, string code)
        {
            return dal.GetBaseMaster(tableName, code);
        }

        /// <summary>
        /// 
        /// </summary>
        public BaseMaster GetBaseMaster(string tableName, string code, string strWhere)
        {
            return dal.GetBaseMaster(tableName, code, strWhere);
        }

        /// <summary>
        /// 
        /// </summary>
        public DataSet GetNames(string codeType)
        {
            return dal.getNames(codeType);
        }

        /// <summary>
        /// 
        /// </summary>
        public int GetMasterRecordCount(string tableName, string code, string name, string _strWhere)
        {
            return dal.GetMasterRecordCount(tableName, code, name, _strWhere);
        }

        /// <summary>
        /// 
        /// </summary>
        public DataSet GetMasterDataList(string tableName, string code, string name, string strWhere, int startIndex, int endIndex)
        {
            return dal.GetMasterDataList(tableName, code, name, strWhere, startIndex, endIndex);
        }
        #endregion

        #region 我的桌面处理
        public DataSet GetDeskDatas(string companyCode, string userCode)
        {
            return dal.GetDeskDatas(companyCode, userCode);
        }

        public bool Exists(BaseDeskTable deskTable)
        {
            return dal.Exists(deskTable);
        }

        public bool InsertDesk(BaseDeskTable deskTable)
        {
            return dal.InsertDesk(deskTable);
        }

        public bool DeleteDesk(BaseDeskTable deskTable)
        {
            return dal.DeleteDesk(deskTable);
        }
        #endregion

        #region 引当状态的重新计算
        /// <summary>
        /// 引当状态的重新计算
        /// </summary>
        /// <param name="orderSlipNumber"></param>
        public void ReSetAlloation(string orderSlipNumber)
        {
            dal.ReSetAlloation(orderSlipNumber);
        }
        #endregion

        #region  用户权限管理
        /// <summary>
        /// 系统功能列表的取得
        /// </summary>
        public DataSet GetFunctionList()
        {
            return dal.GetFunctionList();
        }

        /// <summary>
        /// 获得当前角色的所有权限
        /// </summary>
        public DataSet GetRoles(string rolesCode)
        {
            return dal.GetRoles(rolesCode);
        }

        /// <summary>
        /// 权限更新
        /// </summary>
        public int UpdateRoles(DataTable rolesDt, string rolesCode)
        {
            return dal.UpdateRoles(rolesDt, rolesCode);
        }

        /// <summary>
        /// 用户权限变更后我的桌面重置处理
        /// </summary>
        public void ReSetMyDesk(string companyCode, string userCode, string rolesCode)
        {
            dal.ReSetMyDesk(companyCode, userCode, rolesCode);
        }
        #endregion

        #region 单表字段更新
        /// <summary>
        /// 单表字段更新
        /// </summary>
        public int Update_Table_Fileds(string Table, string Table_FiledsValue, string Wheres)
        {
            return dal.Update_Table_Fileds(Table, Table_FiledsValue, Wheres);
        }
        #endregion

        #region 数据库表结构的取得
        /// <summary>
        /// 数据库表结构的取得
        /// </summary>
        public DataSet GetTableStruct(string tableName)
        {
            return dal.GetTableStruct(tableName);
        }
        #endregion

        #region 数据导入的日志记录
        /// <summary>
        ///  插入数据导入日志
        /// </summary>
        public int InsertReceiveLog(BllReceiveLogTable receiveLogTable)
        {
            return dal.InsertReceiveLog(receiveLogTable);
        }

        /// <summary>
        /// 导入日志的记录条数
        /// </summary>
        public int GetReceiveLogCount(string strWhere)
        {
            return dal.GetReceiveLogCount(strWhere);
        }

        /// <summary>
        /// 获得导入日志数据
        /// </summary>
        public DataSet GetReceiveLogList(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetReceiveLogList(strWhere, orderby, startIndex, endIndex);
        }
        #endregion


        #region 常用输入内容的处理
        /// <summary>
        /// 常用输入内容是否存在该记录
        /// </summary>
        public bool ExistsBaseNames(string code, string name)
        {
            return dal.ExistsBaseNames(code, name);
        }

        /// <summary>
        /// 
        /// </summary>
        public DataSet GetBaseNames(string strWhere)
        {
            return dal.GetBaseNames(strWhere);
        }

        /// <summary>
        /// 常用输入内容数据保存
        /// </summary>
        public int SaveBaseNmaes(string code, string name)
        {
            return dal.SaveBaseNmaes(code, name);
        }
        #endregion

        public DataSet GetModel(string code)
        {
            return dal.GetModel(code);
        }


    }//end class
}
