using System;
using System.Configuration;
using CZZD.ERP.Common;
namespace CZZD.ERP.DBUtility
{
    
    public class PubConstant
    {        
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionString
        {           
            get 
            {
                string _connectionString = AppXmlTool.ReadXmlFiles("ConnectionString");    
                string ConStringEncrypt = AppXmlTool.ReadXmlFiles("ConStringEncrypt");
                if (ConStringEncrypt == "true")
                {
                    _connectionString = CZZD.ERP.Common.DESEncrypt.Decrypt(_connectionString);
                }
                return _connectionString; 
            }
        }

        /// <summary>
        /// 得到web.config里配置项的数据库连接字符串。
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string configName)
        {
            string connectionString = AppXmlTool.ReadXmlFiles(configName);
            string ConStringEncrypt = AppXmlTool.ReadXmlFiles("ConStringEncrypt");
            if (ConStringEncrypt == "true")
            {
                connectionString = CZZD.ERP.Common.DESEncrypt.Decrypt(connectionString);
            }
            return connectionString;
        }


    }
}
