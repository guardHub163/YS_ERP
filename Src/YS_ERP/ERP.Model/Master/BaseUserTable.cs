using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    /// <summary>
    /// 用户信息表
    /// </summary>
    [Serializable]
    public class BaseUserTable
    {
        public BaseUserTable()
        { }
        #region Model
        private string _code;
        private string _password;
        private string _name;
        private string _phone;
        private string _email;
        private string _department_code;
        private string _company_code;
        private string _roles_code;
        private byte[] _photo;
        private int _status_flag;
        private string _create_user;
        private DateTime? _create_date;
        private string _last_update_user;
        private DateTime? _last_update_time;
        private string _department_name;
        private string _company_name;
        private string _roles_name;
        private DateTime? _int_community_date;
        private DateTime? _out_community_date;
        private int? _level;
        private string _info;

        public string INFO
        {
            set { _info = value; }
            get { return _info; }
        }
        public int? LEVEL
        {
            set { _level = value; }
            get { return _level; }
        }
     
        /// <summary>
        /// 用户编号
        /// </summary>
        public string CODE
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string PASSWORD
        {
            set { _password = value; }
            get { return _password; }
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
        /// 电话
        /// </summary>
        public string PHONE
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string EMAIL
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 部门编号
        /// </summary>
        public string DEPARTMENT_CODE
        {
            set { _department_code = value; }
            get { return _department_code; }
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
        /// 角色编号
        /// </summary>
        public string ROLES_CODE
        {
            set { _roles_code = value; }
            get { return _roles_code; }
        }
        /// <summary>
        /// 照片
        /// </summary>
        public byte[] PHOTO
        {
            set { _photo = value; }
            get { return _photo; }
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
        public DateTime? CREATE_DATE
        {
            set { _create_date = value; }
            get { return _create_date; }
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
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DEPARTMENT_NAME
        {
            get { return _department_name; }
            set { _department_name = value; }
        }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string COMPANY_NAME
        {
            get { return _company_name; }
            set { _company_name = value; }
        }

        /// <summary>
        /// 用户角色
        /// </summary>
        public string ROLES_NAME
        {
            get { return _roles_name; }
            set { _roles_name = value; }
        }

        /// <summary>
        /// 入社日期
        /// </summary>
        public DateTime? INT_COMMUNITY_DATE
        {
            get { return _int_community_date; }
            set { _int_community_date = value; }
        }

        /// <summary>
        /// 出社日期
        /// </summary>
        public DateTime? OUT_COMMUNITY_DATE
        {
            get { return _out_community_date; }
            set { _out_community_date = value; }
        }

        #endregion Model


    }
}
