using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BllDepositArrLineTable
    {
        public BllDepositArrLineTable()
        { }
        #region Model
        private string _slip_number;
        private int _line_number;
        private string _order_slip_number;
        private decimal? _arr_amount;
        private string _memo;
        private int _status_flag = 0;
        /// <summary>
        /// 预收款分配内部编号
        /// </summary>
        public string SLIP_NUMBER
        {
            set { _slip_number = value; }
            get { return _slip_number; }
        }
        /// <summary>
        /// 分配行号
        /// </summary>
        public int LINE_NUMBER
        {
            set { _line_number = value; }
            get { return _line_number; }
        }
        /// <summary>
        /// 销售订单编号
        /// </summary>
        public string ORDER_SLIP_NUMBER
        {
            set { _order_slip_number = value; }
            get { return _order_slip_number; }
        }
        /// <summary>
        /// 分配金额
        /// </summary>
        public decimal? ARR_AMOUNT
        {
            set { _arr_amount = value; }
            get { return _arr_amount; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string MEMO
        {
            set { _memo = value; }
            get { return _memo; }
        }
        /// <summary>
        /// 0:通常   9:删除
        /// </summary>
        public int STATUS_FLAG
        {
            set { _status_flag = value; }
            get { return _status_flag; }
        }
        #endregion Model
    }
}
