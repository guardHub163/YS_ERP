using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BaseDeskTable
    {
        public BaseDeskTable() 
        {

        }

        #region Model
        private string _company_code;
        private string _user_code;
        private string _form_name;
        private string _form_title;
        private byte[] _pic;
        private string _form_args;
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
        public string USER_CODE
        {
            set { _user_code = value; }
            get { return _user_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FORM_NAME
        {
            set { _form_name = value; }
            get { return _form_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FORM_TITLE
        {
            set { _form_title = value; }
            get { return _form_title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public byte[] PIC
        {
            set { _pic = value; }
            get { return _pic; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FORM_ARGS
        {
            set { _form_args = value; }
            get { return _form_args; }
        }
        #endregion Model
    }
}
