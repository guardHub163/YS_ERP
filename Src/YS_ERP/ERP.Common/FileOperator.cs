using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Data.OleDb;

namespace CZZD.ERP.Common
{
    public class FileOperator
    {
        #region 读取csv文件
        /// <summary>

        /// 读取CVS文件

        /// </summary>

        /// <param name="path">文件路径</param>

        /// <param name="name">文件名称</param>

        /// <returns>DataTable</returns>

        public static DataTable ReadCVS(string fileName,bool isHdr)
        {
            DataTable dt = null;
            using (Microsoft.VisualBasic.FileIO.TextFieldParser tfp = new Microsoft.VisualBasic.FileIO.TextFieldParser(fileName, Encoding.UTF8))
            {
                tfp.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
                tfp.Delimiters = new string[] { "," };

                tfp.HasFieldsEnclosedInQuotes = true;
                tfp.TrimWhiteSpace = true;
                dt = new DataTable();
                DataRow dr;
                DataColumn dc;

                bool b = true;
                while (!tfp.EndOfData)
                {

                    string[] fields = tfp.ReadFields();

                    int fieldCount = fields.Length;
                    if (b)
                    {
                        for (int i = 0; i < fieldCount; i++)
                        {
                            dc = new DataColumn(i.ToString(), typeof(String));
                            dt.Columns.Add(dc);
                        }
                        b = false;
                    }

                    dr = dt.NewRow();

                    for (int i = 0; i < fieldCount; i++)
                    {
                        dr[i.ToString()] = fields[i];
                    }

                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        #endregion

        #region 读取Excel文件
        /// <summary>
        /// 读取Excel文件
        /// </summary> 
        /// <param name="filepath">文件路径</param> 
        /// <returns>DataTable</returns> 
        public static DataTable ReadExcel(string filename, bool isHdR)
        {
            string hdr = "N0";
            if (isHdR)
            {
                hdr = "YEX";
            }
            System.Data.DataSet itemDS = new DataSet();
            if (filename.Trim().ToUpper().EndsWith("XLS") || filename.Trim().ToUpper().EndsWith("XLSX"))
            {
                string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + ";Extended Properties=\"Excel 12.0;HdR=" + hdr + ";\"";
                System.Data.OleDb.OleDbConnection conn = null;
                System.Data.OleDb.OleDbCommand oledbCommd = null;
                try
                {
                    conn = new System.Data.OleDb.OleDbConnection();
                    conn.ConnectionString = connStr;
                    conn.Open();
                    DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    //判断连接Excel sheet名
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];
                        string sqlText = "select * from [" + dr["TABLE_NAME"] + "]";
                        oledbCommd = new System.Data.OleDb.OleDbCommand(sqlText, conn);
                        oledbCommd.CommandTimeout = 100000;
                        //执行
                        System.Data.OleDb.OleDbDataAdapter oledbDA = new System.Data.OleDb.OleDbDataAdapter(oledbCommd);
                        oledbDA.Fill(itemDS);
                    }
                }
                catch
                { }
                finally
                {
                    //释放
                    oledbCommd.Dispose();
                    conn.Close();
                }
                //创建连接
            }
            return itemDS.Tables[0];
        }

        /// <summary>
        /// 读取Excel文件 指定Sheet
        /// </summary> 
        /// <param name="filepath">文件路径</param> 
        /// <returns>DataTable</returns> 
        public static DataTable ReadExcel(string fileName, string sheet, bool isHdR)
        {
            string hdr = "N0";
            if (isHdR)
            {
                hdr = "YES";
            }
            System.Data.DataSet itemDS = new DataSet();
            if (fileName.Trim().ToUpper().EndsWith("XLS") || fileName.Trim().ToUpper().EndsWith("XLSX"))
            {
                string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=\"Excel 12.0;HdR=" + hdr + ";\"";
                System.Data.OleDb.OleDbConnection conn = null;
                System.Data.OleDb.OleDbCommand oledbCommd = null;
                try
                {
                    conn = new System.Data.OleDb.OleDbConnection();
                    conn.ConnectionString = connStr;
                    conn.Open();

                    string sqlText = "select * from [" + sheet + "]";
                    oledbCommd = new System.Data.OleDb.OleDbCommand(sqlText, conn);
                    oledbCommd.CommandTimeout = 100000;
                    //执行
                    System.Data.OleDb.OleDbDataAdapter oledbDA = new System.Data.OleDb.OleDbDataAdapter(oledbCommd);
                    oledbDA.Fill(itemDS);

                }
                catch
                { }
                finally
                {
                    //释放
                    oledbCommd.Dispose();
                    conn.Close();
                }
                //创建连接
            }
            return itemDS.Tables[0];
        }


        /// <summary>
        /// 读取Excel文件的表头 指定Sheet
        /// </summary> 
        /// <param name="filepath">文件路径</param> 
        /// <returns>DataTable</returns> 
        public static DataTable ReadExcelHeader(string fileName, string sheet)
        {   
            System.Data.DataSet itemDS = new DataSet();
            if (fileName.Trim().ToUpper().EndsWith("XLS") || fileName.Trim().ToUpper().EndsWith("XLSX"))
            {
                string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=\"Excel 12.0;HdR=YES;\"";
                System.Data.OleDb.OleDbConnection conn = null;
                System.Data.OleDb.OleDbCommand oledbCommd = null;
                try
                {
                    conn = new System.Data.OleDb.OleDbConnection();
                    conn.ConnectionString = connStr;
                    conn.Open();

                    string sqlText = "select top 1 * from [" + sheet + "]";
                    oledbCommd = new System.Data.OleDb.OleDbCommand(sqlText, conn);
                    oledbCommd.CommandTimeout = 100000;
                    //执行
                    System.Data.OleDb.OleDbDataAdapter oledbDA = new System.Data.OleDb.OleDbDataAdapter(oledbCommd);
                    oledbDA.Fill(itemDS);

                }
                catch
                { }
                finally
                {
                    //释放
                    oledbCommd.Dispose();
                    conn.Close();
                }
                //创建连接
            }
            return itemDS.Tables[0];
        }


        /// <summary>
        /// 读取Excel文件的所有Sheet
        /// </summary> 
        /// <param name="filepath">文件路径</param> 
        /// <param name="filename">文件名称</param> 
        /// <returns>DataTable</returns> 
        public static DataTable ReadExcelSheets(string fileName)
        {
            DataTable dt = new DataTable();
            System.Data.DataSet itemDS = new DataSet();
            if (fileName.Trim().ToUpper().EndsWith("XLS") || fileName.Trim().ToUpper().EndsWith("XLSX"))
            {
                string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=\"Excel 12.0;HdR=NO;\"";
                System.Data.OleDb.OleDbConnection conn = null;
                try
                {
                    conn = new System.Data.OleDb.OleDbConnection();
                    conn.ConnectionString = connStr;
                    conn.Open();
                    dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                }
                catch (Exception ex)
                { }
                finally
                {
                    //释放
                    conn.Close();
                }
                //创建连接
            }
            return dt;
        }

        #endregion

        #region 读取txt文件
        /// <summary>
        /// 读取Txt文本文件
        /// </summary>
        /// <param name="filepath">文件路径</param>
        /// <param name="filename">文件名称</param>
        /// <returns>文本信息</returns>
        public static string ReadTxt(string filepath, string filename)
        {
            StringBuilder sb = new StringBuilder("");
            //StreamReader sr = new StreamReader(filepath + filename); ;
            StreamReader sr = new StreamReader(filepath + filename, Encoding.GetEncoding("GB2312"));
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                sb.AppendLine(line);
            }
            sr.Close();
            sr.Dispose();
            return sb.ToString();
        }
        #endregion

        #region 文件删除
        /// <summary>
        /// 删除文件操作
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="fileName">文件名称</param>
        public static void DeleteFile(string filePath, string fileName)
        {
            string destinationFile = filePath + fileName;
            //如果文件存在，删除文件
            if (File.Exists(destinationFile))
            {
                FileInfo fi = new FileInfo(destinationFile);
                if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                    fi.Attributes = FileAttributes.Normal;

                File.Delete(destinationFile);
            }
        }
        #endregion

        #region 拷贝文件
        /// <summary>
        /// 拷贝文件
        /// </summary>
        /// <param name="fromFilePath">文件的路径</param>
        /// <param name="toFilePath">文件要拷贝到的路径</param>
        public static bool CopyFile(string fromFullPath, string toFilePath, string fileName)
        {
            try
            {
                if (File.Exists(fromFullPath))
                {
                    if (File.Exists(toFilePath + fileName))
                    {
                        File.Delete(toFilePath + fileName);
                    }
                    if (!Directory.Exists(toFilePath))
                    {
                        Directory.CreateDirectory(toFilePath);
                    }
                    File.Move(fromFullPath, toFilePath + fileName);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }

        }
        #endregion

        #region 写文件
        public static string writeFile(string path, string fileName, string aData)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                FileStream fs = new FileStream(path + fileName, FileMode.Create);
                //byte[] data = new UTF8Encoding().GetBytes(aData);
                StreamWriter wr = new StreamWriter(fs,Encoding.Default);
                wr.Write(aData);
                wr.Flush();
                wr.Close();
                fs.Close();
            }
            catch (Exception)
            {
                return "";
            }
            return path + fileName;
        }
        #endregion


    }//end class
}
