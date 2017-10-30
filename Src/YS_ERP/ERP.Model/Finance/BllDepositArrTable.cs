using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BllDepositArrTable
    {
        public BllDepositArrTable()
        { }
        #region Model
        private string _slip_number;
        private DateTime? _slip_date;
        private string _customer_claim_code;
        private int _status_flag = 0;
        private string _create_user;
        private DateTime? _create_date_time;
        private DateTime? _last_update_time;
        private string _last_update_user;
        private List<BllDepositArrLineTable> lineTables = new List<BllDepositArrLineTable>();


        /// <summary>
        /// 预收款分配内部编号
        /// </summary>
        public string SLIP_NUMBER
        {
            set { _slip_number = value; }
            get { return _slip_number; }
        }
        /// <summary>
        /// 预收款分配日期
        /// </summary>
        public DateTime? SLIP_DATE
        {
            set { _slip_date = value; }
            get { return _slip_date; }
        }
        /// <summary>
        /// 收款公司编号
        /// </summary>
        public string CUSTOMER_CLAIM_CODE
        {
            set { _customer_claim_code = value; }
            get { return _customer_claim_code; }
        }
        /// <summary>
        /// 0:通常   9:删除
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

        private string _company_code;

        public string COMPANY_CODE
        {
            set { _company_code = value; }
            get { return _company_code; }
        }

        /// <summary>
        /// 配分明细
        /// </summary>
        public List<BllDepositArrLineTable> LineTable
        {
            get
            {
                return lineTables;
            }
            set
            {
                lineTables = value;
            }
        }

        /// <summary>
        /// 配分明细
        /// </summary>
        public void addLineTable(BllDepositArrLineTable lineTable)
        {
            lineTables.Add(lineTable);
        }
        #endregion Model

    }
}
