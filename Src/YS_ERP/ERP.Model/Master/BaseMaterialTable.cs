using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BaseMaterialTable
    {
        public BaseMaterialTable()
        { }
        #region Model
        private string _code;
        private string _name;
        private string _name_short;
        private string _name_english;
        private string _zip_code;
        private string _address_first;
        private string _address_middle;
        private string _address_last;
        private string _phone_number;
        private string _fax_number;
        private string _mobil_number;
        private string _contact_name;
        private string _email;
        private string _url;
        private string _memo1;
        private string _memo2;
        private int? _type;
        private string _customer_type;
        private int? _claim_flag;
        private string _customer_claim;
        private string _claim_code;
        private string _currence_code;
        private int _status_flag = 1;
        private string _create_user;
        private DateTime? _create_date_time;
        private string _last_update_user;
        private DateTime? _last_update_time;
        private string _currence_name;
        private string _type_name;
        private string _claim_flag_name;
        private string _name_jp;
        private string _memo3;
        private string _company_code;

        public string COMPANYCODE
        {
            set { _company_code = value; }
            get { return _company_code; }
        }

        /// <summary>
        /// 日本名称
        /// </summary>
        public string NAME_JP
        {
            get { return _name_jp; }
            set { _name_jp = value; }
        }
        /// <summary>
        /// 客户编码
        /// </summary>
        public string CODE
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string NAME
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 客户简称
        /// </summary>
        public string NAME_SHORT
        {
            set { _name_short = value; }
            get { return _name_short; }
        }
        /// <summary>
        /// 客户英语名称
        /// </summary>
        public string NAME_ENGLISH
        {
            set { _name_english = value; }
            get { return _name_english; }
        }
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string ZIP_CODE
        {
            set { _zip_code = value; }
            get { return _zip_code; }
        }
        /// <summary>
        /// 地址1
        /// </summary>
        public string ADDRESS_FIRST
        {
            set { _address_first = value; }
            get { return _address_first; }
        }
        /// <summary>
        /// 地址2
        /// </summary>
        public string ADDRESS_MIDDLE
        {
            set { _address_middle = value; }
            get { return _address_middle; }
        }
        /// <summary>
        /// 地址3
        /// </summary>
        public string ADDRESS_LAST
        {
            set { _address_last = value; }
            get { return _address_last; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string PHONE_NUMBER
        {
            set { _phone_number = value; }
            get { return _phone_number; }
        }
        /// <summary>
        /// 传真
        /// </summary>
        public string FAX_NUMBER
        {
            set { _fax_number = value; }
            get { return _fax_number; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string MOBIL_NUMBER
        {
            set { _mobil_number = value; }
            get { return _mobil_number; }
        }
        /// <summary>
        /// 客户联系人
        /// </summary>
        public string CONTACT_NAME
        {
            set { _contact_name = value; }
            get { return _contact_name; }
        }
        /// <summary>
        /// 联系人邮箱
        /// </summary>
        public string EMAIL
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 客户网址
        /// </summary>
        public string URL
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string MEMO1
        {
            set { _memo1 = value; }
            get { return _memo1; }
        }

        public string MEMO2
        {
            set { _memo2 = value; }
            get { return _memo2; }
        }

        public string MEMO3
        {
            set { _memo3 = value; }
            get { return _memo3; }
        }

        /// <summary>
        /// 1：代理店   2：最终客户
        /// </summary>
        public int? TYPE
        {
            set { _type = value; }
            get { return _type; }
        }

        public string CUSTOMER_TYPE
        {
            set { _customer_type = value; }
            get { return _customer_type; }
        }

        /// <summary>
        /// 1：请款公司  2：非请款公司
        /// </summary>
        public int? CLAIM_FLAG
        {
            set { _claim_flag = value; }
            get { return _claim_flag; }
        }

        public string CUSTOMER_CLAIM
        {
            set { _customer_claim = value; }
            get { return _customer_claim; }
        }

        /// <summary>
        /// 请款公司编号（多家客户可以对应一个请款公司）
        /// </summary>
        public string CLAIM_CODE
        {
            set { _claim_code = value; }
            get { return _claim_code; }
        }
        /// <summary>
        /// 默认货币编号
        /// </summary>
        public string CURRENCE_CODE
        {
            set { _currence_code = value; }
            get { return _currence_code; }
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

        public string CURRENCE_NAME
        {
            set { _currence_name = value; }
            get { return _currence_name; }
        }

        public string TYPE_NAME
        {
            set { _type_name = value; }
            get { return _type_name; }
        }

        public string CLAIM_FLAG_NAME
        {
            set { _claim_flag_name = value; }
            get { return _claim_flag_name; }
        }

        #endregion Model

    }
}
