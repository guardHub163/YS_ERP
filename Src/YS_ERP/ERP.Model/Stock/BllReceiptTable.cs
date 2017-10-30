using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BllReceiptTable
    {
        public BllReceiptTable()
        { }
        #region Model
        private string _slip_number;
        private string _po_slip_number;
        private int _status_flag = 0;
        private string _create_user;
        private DateTime? _create_date_time;
        private DateTime? _last_update_time;
        private string _last_update_user;
        private string _company_code;
        private List<BllReceiptLineTable> _items = new List<BllReceiptLineTable>();
        private int? _receipt_flag;
        /// <summary>
        /// 入库编号
        /// </summary>
        public string SLIP_NUMBER
        {
            set { _slip_number = value; }
            get { return _slip_number; }
        }
        /// <summary>
        /// 采购订单
        /// </summary>
        public string PO_SLIP_NUMBER
        {
            set { _po_slip_number = value; }
            get { return _po_slip_number; }
        }
        /// <summary>
        /// 0:入库  1: 已开发票  9:删除
        /// </summary>
        public int STATUS_FLAG
        {
            set { _status_flag = value; }
            get { return _status_flag; }
        }
        /// <summary>
        /// 创建人员
        /// </summary>
        public string CREATE_USER
        {
            set { _create_user = value; }
            get { return _create_user; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CREATE_DATE_TIME
        {
            set { _create_date_time = value; }
            get { return _create_date_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LAST_UPDATE_TIME
        {
            set { _last_update_time = value; }
            get { return _last_update_time; }
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
        public List<BllReceiptLineTable> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void AddItem(BllReceiptLineTable model)
        {
            _items.Add(model);
        }

        public string COMPANY_CODE
        {
            get { return _company_code; }
            set { _company_code = value; }
        }

        /// <summary>
        /// 入库区分：1  入库    2  临时入库   
        /// </summary>
        public int? RECEIPT_FLAG
        {
            set { _receipt_flag = value; }
            get { return _receipt_flag; }
        }
        #endregion Model
    }
}
