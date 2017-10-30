using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BaseProductionProcessTable
    {
        public BaseProductionProcessTable()
        { }
        #region Model
        private string _code;
        private string _name;
        private string _englishname;
        private string _deparment_code;
        private string _drawing_type_name1;
        private string _drawing_type_name2;
        private string _drawing_type_name3;
        private string _drawing_type_name4;
        private string _drawing_type_name5;
        private string _drawing_type_name6;
        private string _drawing_type_code1;
        private string _drawing_type_code2;
        private string _drawing_type_code3;
        private string _drawing_type_code4;
        private string _drawing_type_code5;
        private string _drawing_type_code6;
        private decimal? _production_cycle;
        private string _attribute1;
        private string _attribute2;
        private string _attribute3;
        private int? _statue_flag;
        private string _create_user;
        private DateTime? _create_date_time;
        private string _last_update_user;
        private DateTime? _last_update_time;
        private string _create_user_name;
        private string _last_update_user_name;
        private string _department_name;
        private string _technology_code1;
        private string _technology_code2;
        private string _technology_code3;

        private string _technology_name1;
        private string _technology_name2;
        private string _technology_name3;

        private string _judgment;
        public string JUDGMENT
        {
            set { _judgment = value; }
            get { return _judgment; }
        }

        public string TECHNOLOGY_NAME1
        {
            set { _technology_name1 = value; }
            get { return _technology_name1; }
        }

        public string TECHNOLOGY_NAME2
        {
            set { _technology_name2 = value; }
            get { return _technology_name2; }
        }

        public string TECHNOLOGY_NAME3
        {
            set { _technology_name3 = value; }
            get { return _technology_name3; }
        }


        public string TECHNOLOGY_CODE1
        {
            set { _technology_code1 = value; }
            get { return _technology_code1; }
        }
        public string TECHNOLOGY_CODE2
        {
            set { _technology_code2 = value; }
            get { return _technology_code2; }
        }

        public string TECHNOLOGY_CODE3
        {
            set { _technology_code3 = value; }
            get { return _technology_code3; }
        }
        public string DEPARTMENT_CODE
        {
            set { _deparment_code = value; }
            get { return _deparment_code; }
        }
        public string DEPARTMENT_NAME
        {
            set { _department_name = value; }
            get { return _department_name; }
        }

        public string DRAWING_TYPE_NAME1
        {
            set { _drawing_type_name1 = value; }
            get { return _drawing_type_name1; }
        }
        public string DRAWING_TYPE_NAME2
        {
            set { _drawing_type_name2 = value; }
            get { return _drawing_type_name2; }
        }
        public string DRAWING_TYPE_NAME3
        {
            set { _drawing_type_name3 = value; }
            get { return _drawing_type_name3; }
        }
        public string DRAWING_TYPE_NAME4
        {
            set { _drawing_type_name4 = value; }
            get { return _drawing_type_name4; }
        }
        public string DRAWING_TYPE_NAME5
        {
            set { _drawing_type_name5 = value; }
            get { return _drawing_type_name5; }
        }
        public string DRAWING_TYPE_NAME6
        {
            set { _drawing_type_name6 = value; }
            get { return _drawing_type_name6; }
        }


        public string DRAWING_TYPE_CODE1
        {
            set { _drawing_type_code1 = value; }
            get { return _drawing_type_code1; }
        }
        public string DRAWING_TYPE_CODE2
        {
            set { _drawing_type_code2 = value; }
            get { return _drawing_type_code2; }
        }
        public string DRAWING_TYPE_CODE3
        {
            set { _drawing_type_code3 = value; }
            get { return _drawing_type_code3; }
        }
        public string DRAWING_TYPE_CODE4
        {
            set { _drawing_type_code4 = value; }
            get { return _drawing_type_code4; }
        }
        public string DRAWING_TYPE_CODE5
        {
            set { _drawing_type_code5 = value; }
            get { return _drawing_type_code5; }
        }
        public string DRAWING_TYPE_CODE6
        {
            set { _drawing_type_code6 = value; }
            get { return _drawing_type_code6; }
        }


        public decimal? PRODUCTION_CYCLE
        {
            set { _production_cycle = value; }
            get { return _production_cycle; }
        }

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

        public int? STATUE_FLAG
        {
            set { _statue_flag = value; }
            get { return _statue_flag; }
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
