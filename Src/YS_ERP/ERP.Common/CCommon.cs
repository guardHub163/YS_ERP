using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CZZD.ERP.Common
{
    public class CCommon
    {
        public static string GetFileType(string filePath)
        {
            //int count = 4;
            //byte[] buffer = new byte[count];
            //FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            //fs.Read(buffer, 0, count);
            //fs.Close();
            //string key = "";
            //foreach (byte bt in buffer) 
            //{
            //    key += Convert.ToString(bt, 16);
            //}
            ////string key = BitConverter.ToString(buffer);
            //object obj = FileType.GetFileType()[key];
            //return CConvert.ToString(obj);

            //FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            //BinaryReader r = new BinaryReader(fs);
            //string key = "";
            //byte buffer;
            //try
            //{
            //    buffer = r.ReadByte();
            //    key = Convert.ToString(buffer,16);
            //    buffer = r.ReadByte();
            //    key += Convert.ToString(buffer, 16);
            //    buffer = r.ReadByte();
            //    key += Convert.ToString(buffer, 16);
            //}
            //catch (Exception ex){}
            //r.Close();
            //fs.Close();

            FileInfo file = new FileInfo(filePath);
            object obj = FileType.GetFileType()[file.Extension.ToUpper().Replace(".","")];
            return CConvert.ToString(obj);

        }



    }//end class
}
