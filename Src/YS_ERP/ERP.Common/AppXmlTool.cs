using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Reflection;

namespace CZZD.ERP.Common
{
    public class AppXmlTool
    {
        /// <summary>
        /// read xml files 
        /// </summary>
        /// <returns></returns>
        public static string ReadXmlFiles(string notename)
        {
            string strNoteValue = "";
            try
            {
                if (File.Exists("Config.xml"))
                {
                    XmlDocument doc = new XmlDocument();
                    XmlNodeList nodelist;
                    Module myModal = typeof(AppXmlTool).Module; ;
                    doc.Load(myModal.FullyQualifiedName.Replace(myModal.Name, "Config.xml"));
                    nodelist = doc.GetElementsByTagName(notename);
                    strNoteValue = nodelist[0].InnerText;
                }
            }
            catch (Exception ex)
            {

            }
            return strNoteValue;
        }

        /// <summary>
        /// 
        /// </summary>
        public static void XmlNodeWrite(string fileName, string strNode, string strconn)
        {
            if (File.Exists(fileName))
            {
                FileInfo fi = new FileInfo(fileName);
                if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                {
                    fi.Attributes = FileAttributes.Normal;
                }
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(fileName);
                XmlNode node = xmlDoc.SelectSingleNode(strNode);
                node.InnerText = strconn;
                xmlDoc.Save(fileName);
            }
        }

    }//end class
}
