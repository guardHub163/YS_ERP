using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CZZD.ERP.IDAL
{
    public interface ICommon
    {
        bool IsDBConn(string strconn, string strsql);

        string GetSeqNumber(string blltype);

        DataSet GetMasterList(string tableName, string code, string name, string strWhere);

        CZZD.ERP.Model.BaseMaster GetBaseMaster(string tableName, string code);
        CZZD.ERP.Model.BaseMaster GetBaseMaster(string tableName, string code, string strWhere);

        DataSet getNames(string codeType);

        int GetMasterRecordCount(string _tableName, string code, string name, string _strWhere);

        DataSet GetMasterDataList(string tableName, string code, string name, string strWhere, int startIndex, int endIndex);

        DataSet GetDeskDatas(string companyCode, string userCode);

        bool Exists(CZZD.ERP.Model.BaseDeskTable deskTable);

        bool InsertDesk(CZZD.ERP.Model.BaseDeskTable deskTable);

        bool DeleteDesk(CZZD.ERP.Model.BaseDeskTable deskTable);

        void ReSetAlloation(string orderSlipNumber);

        DataSet GetFunctionList();

        DataSet GetRoles(string rolesCode);

        int UpdateRoles(DataTable rolesDt, string rolesCode);

        void ReSetMyDesk(string companyCode, string userCode, string rolesCode);

        int Update_Table_Fileds(string Table, string Table_FiledsValue, string Wheres);

        DataSet GetTableStruct(string tableName);

        int InsertReceiveLog(CZZD.ERP.Model.BllReceiveLogTable receiveLogTable);

        int GetReceiveLogCount(string strWhere);

        DataSet GetReceiveLogList(string strWhere, string orderby, int startIndex, int endIndex);        

        bool ExistsBaseNames(string code, string name);

        int SaveBaseNmaes(string code, string name);

        DataSet GetBaseNames(string strWhere);

        DataSet GetModel(string code);
    }//end class
}
