using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BllAlloationTable
    {
        public BllAlloationTable()
        { }
        #region Model
        private string _slip_number;
        private string _order_slip_number;
        private int? _order_line_number;
        private string _warehouse_code;
        private string _product_code;
        private decimal? _quantity;
        private string _unit_code;
        private int _status_flag;
        private string _create_user;
        private DateTime? _create_date_time;
        private string _last_update_user;
        private DateTime? _last_update_time;
        
        /// <summary>
        /// 引当编号
        /// </summary>
        public string SLIP_NUMBER
        {
            set { _slip_number = value; }
            get { return _slip_number; }
        }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string ORDER_SLIP_NUMBER
        {
            set { _order_slip_number = value; }
            get { return _order_slip_number; }
        }
        /// <summary>
        /// 订单明细编号
        /// </summary>
        public int? ORDER_LINE_NUMBER
        {
            set { _order_line_number = value; }
            get { return _order_line_number; }
        }
        /// <summary>
        /// 仓库编号
        /// </summary>
        public string WAREHOUSE_CODE
        {
            set { _warehouse_code = value; }
            get { return _warehouse_code; }
        }
        /// <summary>
        /// 商品编号
        /// </summary>
        public string PRODUCT_CODE
        {
            set { _product_code = value; }
            get { return _product_code; }
        }
        /// <summary>
        /// 引当数量
        /// </summary>
        public decimal? QUANTITY
        {
            set { _quantity = value; }
            get { return _quantity; }
        }
        /// <summary>
        /// 单位编号
        /// </summary>
        public string UNIT_CODE
        {
            set { _unit_code = value; }
            get { return _unit_code; }
        }
        /// <summary>
        /// 0: 引当 1:出库  9:删除
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
        #endregion Model

    }
}
