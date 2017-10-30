using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BaseSlipTypeTable
    {
        public BaseSlipTypeTable()
        { }
        #region Model
        private string _code;
        private string _name;
        private string _company_code;
        private int? _statue_flag;
        private string _company_name;
        private string _create_user;
        private DateTime? _create_date_time;
        private string _last_update_user;
        private DateTime? _last_update_time;
        private string _create_user_name;
        private string _last_update_user_name;
        private string _englishname;
        private string _attribute1;
        private string _attribute2;
        private string _attribute3;

        public string ATTRIBUTE1
        {
            set { _attribute1 = value; }
            get { return _attribute1; }
        }
        public string ATTRIBUTE2
        {
            set { _attribute2 = value; }
            get { return _attribute2; }
        }
        public string ATTRIBUTE3
        {
            set { _attribute3 = value; }
            get { return _attribute3; }
        }

        public string ENGLISHNAME
        {
            set { _englishname = value; }
            get { return _englishname; }
        }

        public string CODE
        {
            set { _code = value; }
            get { return _code; }
        }

        public string NAME
        {
            set { _name = value; }
            get { return _name; }
        }

        public string COMPANY_CODE
        {
            set { _company_code = value; }
            get { return _company_code; }
        }

        public int? STATUE_FLAG
        {
            set { _statue_flag = value; }
            get { return _statue_flag; }
        }

        public string COMPANY_NAME
        {
            set { _company_name = value; }
            get { return _company_name; }
        }

        public string CREATE_USER
        {
            set { _create_user = value; }
            get { return _create_user; }
        }

        public DateTime? CREATE_DATE_TIME
        {
            set { _create_date_time = value; }
            get { return _create_date_time; }
        }

        public string LAST_UPDATE_USER
        {
            set { _last_update_user = value; }
            get { return _last_update_user; }
        }

        public DateTime? LAST_UPDATE_TIME
        {
            set { _last_update_time = value; }
            get { return _last_update_time; }
        }

        public string CREATE_USER_NAME
        {
            get { return _create_user_name; }
            set { _create_user_name = value; }
        }

        public string LAST_UPDATE_USER_NAME
        {
            get { return _last_update_user_name; }
            set { _last_update_user_name = value; }
        }

        #endregion Model
    }
}
