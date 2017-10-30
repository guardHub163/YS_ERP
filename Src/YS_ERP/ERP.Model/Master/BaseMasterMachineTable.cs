using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BaseMasterMachineTable
    {
        public BaseMasterMachineTable()
        { }
        #region Model
        private string _machine_code;
        private string _machine_name;
        private string _customer_code;
        private string _product_code;
        private string _maintenance_stations;
        private int _status_flag = 1;
        private string _create_user;
        private DateTime _create_date_time;
        private string _last_update_user;
        private DateTime _last_update_time;
        private string _purchase_order_slip_number;
        private string _fanuc_serial_number;
        private string _fanuc_slip_number;
        private DateTime _receipt_date;
        private string _purchase_slip_number;
        private DateTime? _sale_date_time;

        public DateTime? SALE_DATE_TIME
        {
            get { return _sale_date_time; }
            set { _sale_date_time = value; }
        }

        /// <summary>
        /// 采购发票输入
        /// </summary>
        public string PURCHASE_SLIP_NUMBER
        {
            get { return _purchase_slip_number; }
            set { _purchase_slip_number = value; }
        }
        
        /// <summary>
        /// 机械编号
        /// </summary>
        public string MACHINE_CODE
        {
            set { _machine_code = value; }
            get { return _machine_code; }
        }
        public string MACHINE_NAME
        {
            set { _machine_name = value; }
            get { return _machine_name; }
        }
        /// <summary>
        /// 需要家
        /// </summary>
        public string CUSTOMER_CODE
        {
            set { _customer_code = value; }
            get { return _customer_code; }
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
        /// 维修地点
        /// </summary>
        public string MAINTENANCE_STATIONS
        {
            set { _maintenance_stations = value; }
            get { return _maintenance_stations; }
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
        public DateTime CREATE_DATE_TIME
        {
            set { _create_date_time = value; }
            get { return _create_date_time; }
        }
        /// <summary>
        /// 最后更新人员
        /// </summary>
        public string LAST_UPDATE_USER
        {
            set { _last_update_user = value; }
            get { return _last_update_user; }
        }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime LAST_UPDATE_TIME
        {
            set { _last_update_time = value; }
            get { return _last_update_time; }
        }

        public string PURCHASE_ORDER_SLIP_NUMBER
        {
            set { _purchase_order_slip_number = value; }
            get { return _purchase_order_slip_number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FANUC_SERIAL_NUMBER
        {
            set { _fanuc_serial_number = value; }
            get { return _fanuc_serial_number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FANUC_SLIP_NUMBER
        {
            set { _fanuc_slip_number = value; }
            get { return _fanuc_slip_number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime RECEIPT_DATE
        {
            set { _receipt_date = value; }
            get { return _receipt_date; }
        }
        #endregion Model
    }
}
