using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BaseReasonTable
    {
      
        public BaseReasonTable()
        { }
        #region Model
        private string _code;
        private string _name;
        private string _company_code;
        private int _status_flag;
        private string _create_user;
        private DateTime? _create_date_time;
        private string _last_update_user;
        private DateTime? _last_date_time;
        /// <summary>
        /// 编号
        /// </summary>
        public string CODE
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string NAME
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 公司编号
        /// </summary>
        public string COMPANY_CODE
        {
            set { _company_code = value; }
            get { return _company_code; }
        }
        /// <summary>
        /// 状态
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
        public DateTime? LAST_DATE_TIME
        {
            set { _last_date_time = value; }
            get { return _last_date_time; }
        }
        #endregion Model
        
    }
}
