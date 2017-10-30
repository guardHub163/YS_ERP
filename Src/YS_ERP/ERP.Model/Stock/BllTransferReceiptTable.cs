using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BllTransferReceiptTable
    {
        public BllTransferReceiptTable()
        { }
        #region Model
        private string _slip_number;
        private string _departual_warehouse_code;
        private string _arrival_warehouse_code;
        private DateTime? _slip_date;
        private string _company_code;
        private int _status_flag = 1;
        private string _create_user;
        private DateTime? _create_date_time;
        private string _last_update_user;
        private DateTime? _last_update_time;

        private List<BllTransferReceiptLineTable> _items = new List<BllTransferReceiptLineTable>();

        /// <summary>
        /// 调拨编号
        /// </summary>
        public string SLIP_NUMBER
        {
            set { _slip_number = value; }
            get { return _slip_number; }
        }
        /// <summary>
        /// 调出仓库
        /// </summary>
        public string DEPARTUAL_WAREHOUSE_CODE
        {
            set { _departual_warehouse_code = value; }
            get { return _departual_warehouse_code; }
        }
        /// <summary>
        /// 调入仓库
        /// </summary>
        public string ARRIVAL_WAREHOUSE_CODE
        {
            set { _arrival_warehouse_code = value; }
            get { return _arrival_warehouse_code; }
        }
        /// <summary>
        /// 调拨日期
        /// </summary>
        public DateTime? SLIP_DATE
        {
            set { _slip_date = value; }
            get { return _slip_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string COMPANY_CODE
        {
            set { _company_code = value; }
            get { return _company_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int STATUS_FLAG
        {
            set { _status_flag = value; }
            get { return _status_flag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CREATE_USER
        {
            set { _create_user = value; }
            get { return _create_user; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CREATE_DATE_TIME
        {
            set { _create_date_time = value; }
            get { return _create_date_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LAST_UPDATE_USER
        {
            set { _last_update_user = value; }
            get { return _last_update_user; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LAST_UPDATE_TIME
        {
            set { _last_update_time = value; }
            get { return _last_update_time; }
        }

        public List<BllTransferReceiptLineTable> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void AddItem(BllTransferReceiptLineTable model)
        {
            _items.Add(model);
        }
        #endregion Model

    }
}
