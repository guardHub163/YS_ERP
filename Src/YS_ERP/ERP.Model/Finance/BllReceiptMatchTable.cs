using System;
namespace CZZD.ERP.Model
{
    /// <summary>
    /// 入金
    /// </summary>
    [Serializable]
    public class BllReceiptMatchTable
    {
        public BllReceiptMatchTable()
        { }
        #region Model
        private string _slip_number;
        private DateTime? _slip_date;
        private string _sales_slip_number;
        private int _sales_line_number;
        private decimal? _total_amount;
        private decimal? _deposit_amount;
        private decimal? _other_amount;
        private int _status_flag = 0;
        private string _create_user;
        private DateTime? _create_date_time;
        private DateTime? _last_update_time;
        private string _last_update_user;
        private string _company_code;
        /// <summary>
        /// 入金编号　入金伝票No.
        /// </summary>
        public string SLIP_NUMBER
        {
            set { _slip_number = value; }
            get { return _slip_number; }
        }
        /// <summary>
        /// 入金日期　入金日
        /// </summary>
        public DateTime? SLIP_DATE
        {
            set { _slip_date = value; }
            get { return _slip_date; }
        }
        /// <summary>
        /// 销售发票内部编号　売上伝票No.
        /// </summary>
        public string SALES_SLIP_NUMBER
        {
            set { _sales_slip_number = value; }
            get { return _sales_slip_number; }
        }
        /// <summary>
        /// 销售发票行号　売上明細No.
        /// </summary>
        public int SALES_LINE_NUMBER
        {
            set { _sales_line_number = value; }
            get { return _sales_line_number; }
        }
        /// <summary>
        /// 入金总金额　入金合計金額
        /// </summary>
        public decimal? TOTAL_AMOUNT
        {
            set { _total_amount = value; }
            get { return _total_amount; }
        }
        /// <summary>
        /// 预付款金额　前受金金額
        /// </summary>
        public decimal? DEPOSIT_AMOUNT
        {
            set { _deposit_amount = value; }
            get { return _deposit_amount; }
        }
        /// <summary>
        /// 其他金额　その他金額
        /// </summary>
        public decimal? OTHER_AMOUNT
        {
            set { _other_amount = value; }
            get { return _other_amount; }
        }
        /// <summary>
        /// 1:正常  9:删除　１：新規　９：削除
        /// </summary>
        public int STATUS_FLAG
        {
            set { _status_flag = value; }
            get { return _status_flag; }
        }
        /// <summary>
        /// 　作成担当者
        /// </summary>
        public string CREATE_USER
        {
            set { _create_user = value; }
            get { return _create_user; }
        }
        /// <summary>
        /// 创建时间　作成時間
        /// </summary>
        public DateTime? CREATE_DATE_TIME
        {
            set { _create_date_time = value; }
            get { return _create_date_time; }
        }
        /// <summary>
        /// 最終更新時間
        /// </summary>
        public DateTime? LAST_UPDATE_TIME
        {
            set { _last_update_time = value; }
            get { return _last_update_time; }
        }
        /// <summary>
        /// 最終更新担当者
        /// </summary>
        public string LAST_UPDATE_USER
        {
            set { _last_update_user = value; }
            get { return _last_update_user; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string COMPANY_CODE
        {
            set { _company_code = value; }
            get { return _company_code; }
        }
        #endregion Model

    }
}

