using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BllPaymentMatchTable
    {
        public BllPaymentMatchTable()
        { }
        #region Model
        private string _slip_number;
        private DateTime _slip_date;
        private string _purchase_slip_number;
        private decimal _total_amount;
        private decimal _deposit_amount;
        private decimal _other_amount;
        private int _status_flag = 0;
        private string _create_user;
        private DateTime _create_date_time;
        private DateTime _last_update_time;
        private string _last_update_user;
        private string _company_code;
        /// <summary>
        /// 出金编号
        /// </summary>
        public string SLIP_NUMBER
        {
            set { _slip_number = value; }
            get { return _slip_number; }
        }
        /// <summary>
        /// 出金日期
        /// </summary>
        public DateTime SLIP_DATE
        {
            set { _slip_date = value; }
            get { return _slip_date; }
        }
        /// <summary>
        /// 采购发票内部编号
        /// </summary>
        public string PURCHASE_SLIP_NUMBER
        {
            set { _purchase_slip_number = value; }
            get { return _purchase_slip_number; }
        }
        /// <summary>
        /// 入金总金额
        /// </summary>
        public decimal TOTAL_AMOUNT
        {
            set { _total_amount = value; }
            get { return _total_amount; }
        }
        /// <summary>
        /// 预付款金额
        /// </summary>
        public decimal DEPOSIT_AMOUNT
        {
            set { _deposit_amount = value; }
            get { return _deposit_amount; }
        }
        /// <summary>
        /// 其他金额
        /// </summary>
        public decimal OTHER_AMOUNT
        {
            set { _other_amount = value; }
            get { return _other_amount; }
        }
        /// <summary>
        /// 0:正常  9:删除
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
        /// 
        /// </summary>
        public DateTime LAST_UPDATE_TIME
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

        public string COMPANY_CODE
        {
            set { _company_code = value; }
            get { return _company_code; }
        }
        #endregion Model
    }
}
