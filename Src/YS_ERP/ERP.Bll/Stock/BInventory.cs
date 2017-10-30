using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using System.Data;
using CZZD.ERP.Model;
using System.Collections;

namespace CZZD.ERP.Bll
{
    public class BInventory
    {
        IInventory dal = DALFactory.DataAccess.CreateInventoryManage();

        public string GetMaxSlipNumber()
        {
            return dal.GetMaxSlipNumber();
        }

        public DataSet GetStartList(string WAREHOUSE_CODE, string orderby, int startIndex, int endIndex)
        {
            return dal.GetStartList(WAREHOUSE_CODE, orderby, startIndex, endIndex);
        }

        public DataSet GetStartPrintList(string WAREHOUSE_CODE)
        {
            return dal.GetStartPrintList(WAREHOUSE_CODE);
        }

        public int GetStartRecordCount(string WAREHOUSE_CODE)
        {
            return dal.GetStartRecordCount(WAREHOUSE_CODE);
        }

        public int AddInventory(BllInventoryTable BIModel)
        {
            return dal.AddInventory(BIModel);
        }

        public int GetSearchRecordCount(string strWhere)
        {
            return dal.GetSearchRecordCount(strWhere);
        }

        public DataSet GetSearchList(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetSearchList(strWhere, orderby, startIndex, endIndex);
        }

        public BllInventoryTable GetInventoryModel(string SLIP_NUMBER)
        {
            return dal.GetInventoryModel(SLIP_NUMBER);
        }

        public DataSet GetLine(string SLIP_NUMBER)
        {
            return dal.GetLine(SLIP_NUMBER);
        }

        public int GetEndInventoryRecordCount(string strWhere)
        {
            return dal.GetEndInventoryRecordCount(strWhere);
        }

        public DataSet GetEndInventoryList(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetEndInventoryList(strWhere, orderby, startIndex, endIndex);
        }

        public DataSet GetEndPrintList(string strWhere)
        {
            return dal.GetEndPrintList(strWhere);
        }

        public int UpdataInventory(string SLIP_NUMBER, Hashtable ht, string LAST_UPDATE_USER, bool isEnd)
        {
            return dal.UpdataInventory(SLIP_NUMBER, ht, LAST_UPDATE_USER, isEnd);
        }
    }
}
