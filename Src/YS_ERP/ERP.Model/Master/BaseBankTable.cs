using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model.Master
{
    public class BaseBankTable
    {
        public BaseBankTable()
        { }
        #region Model
        private string _id;
        private string _company_code;
        private string _bank_name;
        private string _full_name_en;
        private string _full_name_cn;
        private string _detail_en;
        private string _detail_cn;
        private int? _status_flag;
        private string _create_user;
        private DateTime? _create_date_time;
        private string _last_update_user;
        private DateTime? _last_update_time;
        private string _company_name;
        /// <summary>
        /// 
        /// </summary>
        public string COMPANY_NAME
        {
            set { _company_name = value; }
            get { return _company_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
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
        public string BANK_NAME
        {
            set { _bank_name = value; }
            get { return _bank_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FULL_NAME_EN
        {
            set { _full_name_en = value; }
            get { return _full_name_en; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FULL_NAME_CN
        {
            set { _full_name_cn = value; }
            get { return _full_name_cn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DETAIL_EN
        {
            set { _detail_en = value; }
            get { return _detail_en; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DETAIL_CN
        {
            set { _detail_cn = value; }
            get { return _detail_cn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? STATUS_FLAG
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
