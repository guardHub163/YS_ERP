using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Collections;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;

namespace CZZD.ERP.Common
{
    public class CExport
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        /// <summary>
        /// 将DataTable数据写入CSV文件
        /// </summary>
        public static int DataTableToCsv(DataTable dt, string headerTitle, string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(new BufferedStream(fs), System.Text.Encoding.Default);
            sw.Write(headerTitle);

            foreach (DataRow row in dt.Rows)
            {
                string line = "";
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    line += row[i].ToString().Trim() + "\t"; //内容：自动跳到下一单元格
                }
                line = line.Substring(0, line.Length - 1) + "\r\n";
                sw.Write(line);
            }
            sw.Flush();
            sw.Close();
            sw.Dispose();
            fs.Close();
            return 0;
        }

        #region 导出Excel文件
        /// <summary>
        /// 导出Excel文件
        /// </summary>
        public static int DataTableToExcel(DataTable dt, string title, string columns, string sheetName, string fileName)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "导出Excel (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.Title = "导出文件保存路径";
            saveFileDialog.FileName = "YS_" + fileName + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string strName = saveFileDialog.FileName;
                if (strName.Length != 0)
                {
                    System.Reflection.Missing miss = System.Reflection.Missing.Value;
                    Microsoft.Office.Interop.Excel.ApplicationClass excel = new Microsoft.Office.Interop.Excel.ApplicationClass();
                    excel.Application.Workbooks.Add(true); ;
                    excel.Visible = false;//若是true，则在导出的时候会显示EXcel界面。
                    if (excel == null)
                    {
                        Logger.Error("Excel文件保存失败。", null);
                        return CConstant.EXPORT_FAILURE;
                    }
                    Microsoft.Office.Interop.Excel.Workbooks books = (Microsoft.Office.Interop.Excel.Workbooks)excel.Workbooks;
                    Microsoft.Office.Interop.Excel.Workbook book = (Microsoft.Office.Interop.Excel.Workbook)(books.Add(miss));
                    Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)book.ActiveSheet;
                    sheet.Name = sheetName;
                    int m = 0, n = 0;
                    //生成列名称 这里i是从1开始的 因为我第0列是个隐藏列ID 没必要写进去
                    string[] strHeader = title.Split(',');
                    string[] strColumns = columns.Split(',');
                    for (int i = 0; i < strHeader.Length; i++)
                    {
                        excel.Cells[1, i + 1] = strHeader[i].ToString();
                    }
                    //填充数据
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];
                        //j也是从1开始 原因如上 每个人需求不一样
                        int j = 1;
                        foreach (string str in strColumns)
                        {
                            try
                            {
                                if (dr[str.Trim()].GetType() == typeof(string))
                                {
                                    excel.Cells[i + 2, j] = "'" + dr[str.Trim()].ToString();
                                    j++;
                                }
                                else
                                {
                                    excel.Cells[i + 2, j] = dr[str.Trim()].ToString();
                                    j++;
                                }
                            }
                            catch
                            {
                                j++;
                                continue;
                            }
                        }
                    }
                    try
                    {
                        sheet.SaveAs(strName, miss, miss, miss, miss, miss, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, miss, miss, miss);
                        book.Close(false, miss, miss);
                        books.Close();
                        excel.Quit();
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(book);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(books);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                        GC.Collect();
                        //MessageBox.Show("数据已经成功导出!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //System.Diagnostics.Process.Start(strName);
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Excel文件保存失败。", null);                        
                        return CConstant.EXPORT_FAILURE;
                    }
                }
                return CConstant.EXPORT_SUCCESS;
            }
            else
            {
                return CConstant.EXPORT_CANCEL;
            }
            return CConstant.EXPORT_SUCCESS;
        }
        #endregion

        /// <summary>
        /// 导出审查表
        /// </summary>
        public static int ExportReView(string templetFile, string outFile, Hashtable ht)
        {
            object missing = Missing.Value;
            DateTime beforeTime;
            DateTime afterTime;

            #region Excel文件初始化
            //只读属性的变更
            FileInfo fi = new FileInfo(templetFile);
            if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
            {
                fi.Attributes = FileAttributes.Normal;
            }
            //拷贝模版文件生成新文件
            if (File.Exists(templetFile))
            {
                try
                {
                    File.Copy(templetFile, outFile, true);
                }
                catch (Exception ex)
                {
                    Logger.Error("文件正在运行，重新生成文件失败。", ex);
                    return CConstant.EXPORT_RUNNING;
                }
            }
            else
            {
                Logger.Error("模版文件不存在。", null);
                return CConstant.EXPORT_TEMPLETE_FILE_NOT_EXIST;
            }

            beforeTime = DateTime.Now;

            //创建一个Application对象并使其可见            
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.ApplicationClass();
            app.Visible = false;
            afterTime = DateTime.Now;

            //打开模板文件，得到WorkBook对象
            Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Open(outFile, missing, missing, missing, missing, missing, missing,
                               missing, missing, missing, missing, missing, missing, missing, missing);

            //得到WorkSheet对象
            Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Sheets.get_Item(1);

            //特定内容的替换
            foreach (DictionaryEntry de in ht)
            {
                try
                {
                    workSheet.Cells.Replace(de.Key, de.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                }
                catch
                {
                    continue;
                }
            }
            #endregion

            #region 输出Excel文件并退出
            //输出Excel文件并退出
            try
            {
                workBook.Save();
                workBook.Close(null, null, null);
                app.Workbooks.Close();
                app.Application.Quit();
                app.Quit();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

                workSheet = null;
                workBook = null;
                app = null;

                GC.Collect();
            }
            catch (Exception ex)
            {
                try
                {
                    File.Delete(outFile);
                }
                catch (Exception e)
                {
                    Logger.Error("Excel文件保存,失败后复制文件的删除。", e);
                }
                Logger.Error("Excel文件保存失败。", null);
                return CConstant.EXPORT_FAILURE;
            }
            finally
            {
                Process[] myProcesses;
                DateTime startTime;
                myProcesses = Process.GetProcessesByName("Excel");

                //得不到Excel进程ID，暂时只能判断进程启动时间
                foreach (Process myProcess in myProcesses)
                {
                    startTime = myProcess.StartTime;

                    if (startTime > beforeTime && startTime < afterTime)
                    {
                        myProcess.Kill();
                    }
                }
            }
            #endregion

            return CConstant.EXPORT_SUCCESS;
        }

        #region Purchase注文书国内
        /// <summary>
        /// 采购注文书国内
        /// </summary>
        public static int ExportPurchase(string templetFile, string outFile, DataTable dt, Hashtable ht)
        {
            object missing = Missing.Value;
            DateTime beforeTime;
            DateTime afterTime;

            //拷贝模版文件生成新文件
            if (File.Exists(templetFile))
            {
                try
                {
                    File.Copy(templetFile, outFile, true);
                }
                catch (Exception ex)
                {
                    Logger.Error("文件正在运行，重新生成文件失败。", ex);
                    return CConstant.EXPORT_RUNNING;
                }
            }
            else
            {
                Logger.Error("模版文件不存在。", null);
                return CConstant.EXPORT_TEMPLETE_FILE_NOT_EXIST;
            }

            beforeTime = DateTime.Now;

            //创建一个Application对象并使其可见            
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.ApplicationClass();
            app.Visible = false;
            afterTime = DateTime.Now;

            //打开模板文件，得到WorkBook对象
            Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Open(outFile, missing, missing, missing, missing, missing, missing,
                               missing, missing, missing, missing, missing, missing, missing, missing);

            //得到WorkSheet对象
            Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Sheets.get_Item(1);

            //特定内容的替换
            foreach (DictionaryEntry de in ht)
            {
                try
                {
                    workSheet.Cells.Replace(de.Key, de.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                }
                catch
                {
                    continue;
                }
            }

            //数据
            int startRow = 11;
            int endRow = dt.Rows.Count + startRow;

            for (int i = startRow; i < endRow; i++)
            {
                if (i >= 22 && i < endRow - 1)
                {
                    Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)workSheet.Rows[i, Type.Missing];
                    range.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlDirection.xlDown,
                        Microsoft.Office.Interop.Excel.XlInsertFormatOrigin.xlFormatFromLeftOrAbove);
                }
                DataRow dr = dt.Rows[i - startRow];

                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (dr[j].GetType() == typeof(string))
                    {
                        workSheet.Cells[i, j + 2] = "'" + Convert.ToString(dr[j]);
                    }
                    else
                    {
                        workSheet.Cells[i, j + 2] = Convert.ToString(dr[j]);
                    }
                }
            }

            //输出Excel文件并退出
            try
            {
                workBook.Save();
                //workBook.SaveAs(outFile, missing, missing, missing, missing, missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, missing, missing, missing, missing, missing);
                workBook.Close(null, null, null);
                app.Workbooks.Close();
                app.Application.Quit();
                app.Quit();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

                workSheet = null;
                workBook = null;
                app = null;

                GC.Collect();
            }
            catch (Exception ex)
            {
                try
                {
                    File.Delete(outFile);
                }
                catch (Exception e)
                {
                    Logger.Error("Excel文件保存,失败后复制文件的删除。", e);
                }
                Logger.Error("Excel文件保存失败。", null);
                return CConstant.EXPORT_FAILURE;
            }
            finally
            {
                Process[] myProcesses;
                DateTime startTime;
                myProcesses = Process.GetProcessesByName("Excel");

                //得不到Excel进程ID，暂时只能判断进程启动时间
                foreach (Process myProcess in myProcesses)
                {
                    startTime = myProcess.StartTime;

                    if (startTime > beforeTime && startTime < afterTime)
                    {
                        myProcess.Kill();
                    }
                }
            }

            return CConstant.EXPORT_SUCCESS;
        }
        #endregion

        #region Purchase注文书国外
        /// <summary>
        /// 采购注文书国外
        /// </summary>
        public static int ExportPurchaseOverseas(string templetFile, string outFile, DataTable dt, Hashtable ht)
        {
            object missing = Missing.Value;
            DateTime beforeTime;
            DateTime afterTime;

            #region Excel文件初始化
            //只读属性的变更
            FileInfo fi = new FileInfo(templetFile);
            if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
            {
                fi.Attributes = FileAttributes.Normal;
            }
            //拷贝模版文件生成新文件
            if (File.Exists(templetFile))
            {
                try
                {
                    File.Copy(templetFile, outFile, true);
                }
                catch (Exception ex)
                {
                    Logger.Error("文件正在运行，重新生成文件失败。", ex);
                    return CConstant.EXPORT_RUNNING;
                }
            }
            else
            {
                Logger.Error("模版文件不存在。", null);
                return CConstant.EXPORT_TEMPLETE_FILE_NOT_EXIST;
            }

            beforeTime = DateTime.Now;

            //创建一个Application对象并使其可见            
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.ApplicationClass();
            app.Visible = false;
            afterTime = DateTime.Now;

            //打开模板文件，得到WorkBook对象
            Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Open(outFile, missing, missing, missing, missing, missing, missing,
                               missing, missing, missing, missing, missing, missing, missing, missing);

            //得到WorkSheet对象
            Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Sheets.get_Item(1);

            //特定内容的替换
            foreach (DictionaryEntry de in ht)
            {
                try
                {
                    workSheet.Cells.Replace(de.Key, de.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                }
                catch
                {
                    continue;
                }
            }
            #endregion

            //数据
            int startRow = 19;
            int endRow = dt.Rows.Count + startRow;

            for (int i = startRow; i < endRow; i++)
            {
                if (i >= 36 && i < endRow - 1)
                {
                    Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)workSheet.Rows[i, Type.Missing];
                    range.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlDirection.xlDown,
                        Microsoft.Office.Interop.Excel.XlInsertFormatOrigin.xlFormatFromLeftOrAbove);
                }
                DataRow dr = dt.Rows[i - startRow];

                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (dt.Columns[j].ColumnName.Contains("X_"))
                    {
                        continue;
                    }
                    if (dr[j].GetType() == typeof(string))
                    {
                        workSheet.Cells[i, j + 1] = "'" + Convert.ToString(dr[j]);
                    }
                    else
                    {
                        workSheet.Cells[i, j + 1] = Convert.ToString(dr[j]);
                    }
                }
            }

            #region  输出Excel文件并退出
            //输出Excel文件并退出
            try
            {
                workBook.Save();
                workBook.Close(null, null, null);
                app.Workbooks.Close();
                app.Application.Quit();
                app.Quit();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

                workSheet = null;
                workBook = null;
                app = null;

                GC.Collect();
            }
            catch (Exception ex)
            {
                try
                {
                    File.Delete(outFile);
                }
                catch (Exception e)
                {
                    Logger.Error("Excel文件保存,失败后复制文件的删除。", e);
                }
                Logger.Error("Excel文件保存失败。", null);
                return CConstant.EXPORT_FAILURE;
            }
            finally
            {
                Process[] myProcesses;
                DateTime startTime;
                myProcesses = Process.GetProcessesByName("Excel");

                //得不到Excel进程ID，暂时只能判断进程启动时间
                foreach (Process myProcess in myProcesses)
                {
                    startTime = myProcess.StartTime;

                    if (startTime > beforeTime && startTime < afterTime)
                    {
                        myProcess.Kill();
                    }
                }
            }
            #endregion

            return CConstant.EXPORT_SUCCESS;
        }
        #endregion

        #region 机械部件纳品书
        /// <summary>
        /// 机械部件纳品书
        /// </summary>
        public static int ExportShipmentAccessories(string templetFile, string outFile, DataTable dt, Hashtable ht)
        {
            object missing = Missing.Value;
            DateTime beforeTime;
            DateTime afterTime;

            #region Excel文件初始化
            //只读属性的变更
            FileInfo fi = new FileInfo(templetFile);
            if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
            {
                fi.Attributes = FileAttributes.Normal;
            }
            //拷贝模版文件生成新文件
            if (File.Exists(templetFile))
            {
                try
                {
                    File.Copy(templetFile, outFile, true);
                }
                catch (Exception ex)
                {
                    Logger.Error("文件正在运行，重新生成文件失败。", ex);
                    return CConstant.EXPORT_RUNNING;
                }
            }
            else
            {
                Logger.Error("模版文件不存在。", null);
                return CConstant.EXPORT_TEMPLETE_FILE_NOT_EXIST;
            }

            beforeTime = DateTime.Now;

            //创建一个Application对象并使其可见            
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.ApplicationClass();
            app.Visible = false;
            afterTime = DateTime.Now;

            //打开模板文件，得到WorkBook对象
            Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Open(outFile, missing, missing, missing, missing, missing, missing,
                               missing, missing, missing, missing, missing, missing, missing, missing);

            //得到WorkSheet对象
            Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Sheets.get_Item(1);

            //特定内容的替换
            foreach (DictionaryEntry de in ht)
            {
                try
                {
                    workSheet.Cells.Replace(de.Key, de.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                }
                catch
                {
                    continue;
                }
            }
            #endregion

            //数据
            int startRow = 15;
            int endRow = dt.Rows.Count + startRow;

            if (endRow >= 26)
            {
                endRow = 26;
            }
            for (int i = startRow; i < endRow; i++)
            {
                DataRow dr = dt.Rows[i - startRow];

                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (dt.Columns[j].ColumnName.Contains("X_"))
                    {
                        continue;
                    }
                    if (dr[j].GetType() == typeof(string))
                    {
                        workSheet.Cells[i, j + 1] = "'" + Convert.ToString(dr[j]);
                    }
                    else
                    {
                        workSheet.Cells[i, j + 1] = Convert.ToString(dr[j]);
                    }
                }
            }


            #region
            //输出Excel文件并退出
            try
            {
                workBook.Save();
                //workBook.SaveAs(outFile, missing, missing, missing, missing, missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, missing, missing, missing, missing, missing);
                workBook.Close(null, null, null);
                app.Workbooks.Close();
                app.Application.Quit();
                app.Quit();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

                workSheet = null;
                workBook = null;
                app = null;

                GC.Collect();
            }
            catch (Exception ex)
            {
                try
                {
                    File.Delete(outFile);
                }
                catch (Exception e)
                {
                    Logger.Error("Excel文件保存,失败后复制文件的删除。", e);
                }
                Logger.Error("Excel文件保存失败。", null);
                return CConstant.EXPORT_FAILURE;
            }
            finally
            {
                Process[] myProcesses;
                DateTime startTime;
                myProcesses = Process.GetProcessesByName("Excel");

                //得不到Excel进程ID，暂时只能判断进程启动时间
                foreach (Process myProcess in myProcesses)
                {
                    startTime = myProcess.StartTime;

                    if (startTime > beforeTime && startTime < afterTime)
                    {
                        myProcess.Kill();
                    }
                }
            }
            #endregion

            return CConstant.EXPORT_SUCCESS;
        }
        #endregion

        #region 含机械本体纳品书
        /// <summary>
        /// 含机械本体纳品书
        /// </summary>
        public static int ExportShipmentBody(string templetFile, string outFile, DataTable dt, Hashtable ht)
        {
            object missing = Missing.Value;
            DateTime beforeTime;
            DateTime afterTime;

            #region Excel文件初始化
            //只读属性的变更
            FileInfo fi = new FileInfo(templetFile);
            if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
            {
                fi.Attributes = FileAttributes.Normal;
            }
            //拷贝模版文件生成新文件
            if (File.Exists(templetFile))
            {
                try
                {
                    File.Copy(templetFile, outFile, true);
                }
                catch (Exception ex)
                {
                    Logger.Error("文件正在运行，重新生成文件失败。", ex);
                    return CConstant.EXPORT_RUNNING;
                }
            }
            else
            {
                Logger.Error("模版文件不存在。", null);
                return CConstant.EXPORT_TEMPLETE_FILE_NOT_EXIST;
            }

            beforeTime = DateTime.Now;

            //创建一个Application对象并使其可见            
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.ApplicationClass();
            app.Visible = false;
            afterTime = DateTime.Now;
            //打开模板文件，得到WorkBook对象
            Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Open(outFile, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            //得到WorkSheet对象
            Microsoft.Office.Interop.Excel.Worksheet workSheet = null;
            #endregion

            try
            {
                for (int ii = 1; ii <= 5; ii++)
                {
                    workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Sheets.get_Item(ii);
                    //特定内容的替换
                    foreach (DictionaryEntry de in ht)
                    {
                        try
                        {
                            workSheet.Cells.Replace(de.Key, de.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    //
                    int[] X = { 1, 2, 6, 9, 10, 12 };
                    //dt数据
                    int startRow = 16;
                    int endRow = dt.Rows.Count + startRow;
                    for (int i = startRow; i < endRow; i++)
                    {
                        DataRow dr = dt.Rows[i - startRow];

                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            if (dr[j].GetType() == typeof(string))
                            {
                                workSheet.Cells[i, X[j]] = "'" + Convert.ToString(dr[j]);
                            }
                            else
                            {
                                workSheet.Cells[i, X[j]] = Convert.ToString(dr[j]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            #region
            //输出Excel文件并退出
            try
            {
                workBook.Save();
                //workBook.SaveAs(outFile, missing, missing, missing, missing, missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, missing, missing, missing, missing, missing);
                workBook.Close(null, null, null);
                app.Workbooks.Close();
                app.Application.Quit();
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                workSheet = null;
                workBook = null;
                app = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                try
                {
                    File.Delete(outFile);
                }
                catch (Exception e)
                {
                    Logger.Error("Excel文件保存,失败后复制文件的删除。", e);
                }
                Logger.Error("Excel文件保存失败。", null);
                return CConstant.EXPORT_FAILURE;
            }
            finally
            {
                Process[] myProcesses;
                DateTime startTime;
                myProcesses = Process.GetProcessesByName("Excel");

                //得不到Excel进程ID，暂时只能判断进程启动时间
                foreach (Process myProcess in myProcesses)
                {
                    startTime = myProcess.StartTime;

                    if (startTime > beforeTime && startTime < afterTime)
                    {
                        myProcess.Kill();
                    }
                }
            }
            #endregion

            return CConstant.EXPORT_SUCCESS;
        }
        #endregion

        #region OEM销售成绩表
        /// <summary>
        ///  OEM销售成绩表
        /// </summary>
        public static int ExportOEMSales(string templetFile, string outFile, DataTable dt, Hashtable ht)
        {
            object missing = Missing.Value;
            DateTime beforeTime;
            DateTime afterTime;

            #region Excel文件初始化
            //只读属性的变更
            FileInfo fi = new FileInfo(templetFile);
            if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
            {
                fi.Attributes = FileAttributes.Normal;
            }
            //拷贝模版文件生成新文件
            if (File.Exists(templetFile))
            {
                try
                {
                    File.Copy(templetFile, outFile, true);
                }
                catch (Exception ex)
                {
                    Logger.Error("文件正在运行，重新生成文件失败。", ex);
                    return CConstant.EXPORT_RUNNING;
                }
            }
            else
            {
                Logger.Error("模版文件不存在。", null);
                return CConstant.EXPORT_TEMPLETE_FILE_NOT_EXIST;
            }

            beforeTime = DateTime.Now;

            //创建一个Application对象并使其可见            
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.ApplicationClass();
            app.Visible = false;
            afterTime = DateTime.Now;

            //打开模板文件，得到WorkBook对象
            Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Open(outFile, missing, missing, missing, missing, missing, missing,
                               missing, missing, missing, missing, missing, missing, missing, missing);

            //得到WorkSheet对象
            Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Sheets.get_Item(1);

            //特定内容的替换
            foreach (DictionaryEntry de in ht)
            {
                try
                {
                    workSheet.Cells.Replace(de.Key, de.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                }
                catch
                {
                    continue;
                }
            }
            #endregion

            //数据
            int startRow = 8;
            int endRow = dt.Rows.Count + startRow;

            int[] str = { 1, 2, 3, 5, 4, 6, 7, 10, 13, 14, 20 };

            for (int i = startRow; i < endRow; i++)
            {
                DataRow dr = dt.Rows[i - startRow];
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    workSheet.Cells[i, str[j]] = dr[j];
                }
            }

            //输出Excel文件并退出
            try
            {
                workBook.Save();
                workBook.Close(null, null, null);
                app.Workbooks.Close();
                app.Application.Quit();
                app.Quit();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

                workSheet = null;
                workBook = null;
                app = null;

                GC.Collect();
            }
            catch (Exception ex)
            {
                try
                {
                    File.Delete(outFile);
                }
                catch (Exception e)
                {
                    Logger.Error("Excel文件保存,失败后复制文件的删除。", e);
                }
                Logger.Error("Excel文件保存失败。", null);
                return CConstant.EXPORT_FAILURE;
            }
            finally
            {
                Process[] myProcesses;
                DateTime startTime;
                myProcesses = Process.GetProcessesByName("Excel");

                //得不到Excel进程ID，暂时只能判断进程启动时间
                foreach (Process myProcess in myProcesses)
                {
                    startTime = myProcess.StartTime;

                    if (startTime > beforeTime && startTime < afterTime)
                    {
                        myProcess.Kill();
                    }
                }
            }

            return CConstant.EXPORT_SUCCESS;
        }
        #endregion

        #region OEM制品管理表
        /// <summary>
        /// OEM制品管理表
        /// </summary>
        public static int ExportOEMProduct(string templetFile, string outFile, DataTable dt, Hashtable ht)
        {
            object missing = Missing.Value;
            DateTime beforeTime;
            DateTime afterTime;

            #region Excel文件初始化
            //只读属性的变更
            FileInfo fi = new FileInfo(templetFile);
            if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
            {
                fi.Attributes = FileAttributes.Normal;
            }
            //拷贝模版文件生成新文件
            if (File.Exists(templetFile))
            {
                try
                {
                    File.Copy(templetFile, outFile, true);
                }
                catch (Exception ex)
                {
                    Logger.Error("文件正在运行，重新生成文件失败。", ex);
                    return CConstant.EXPORT_RUNNING;
                }
            }
            else
            {
                Logger.Error("模版文件不存在。", null);
                return CConstant.EXPORT_TEMPLETE_FILE_NOT_EXIST;
            }

            beforeTime = DateTime.Now;

            //创建一个Application对象并使其可见            
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.ApplicationClass();
            app.Visible = false;
            afterTime = DateTime.Now;

            //打开模板文件，得到WorkBook对象
            Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Open(outFile, missing, missing, missing, missing, missing, missing,
                               missing, missing, missing, missing, missing, missing, missing, missing);

            //得到WorkSheet对象
            Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Sheets.get_Item(1);

            //特定内容的替换
            foreach (DictionaryEntry de in ht)
            {
                try
                {
                    workSheet.Cells.Replace(de.Key, de.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                }
                catch
                {
                    continue;
                }
            }
            #endregion

            //数据
            int startRow = 8;
            int endRow = dt.Rows.Count + startRow;

            int[] str = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 34, 37, 38, 44, 50, 51 };

            for (int i = startRow; i < endRow; i++)
            {
                DataRow dr = dt.Rows[i - startRow];
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    workSheet.Cells[i, str[j]] = dr[j];
                }
            }

            #region 输出Excel文件并退出
            //输出Excel文件并退出
            try
            {
                workBook.Save();
                workBook.Close(null, null, null);
                app.Workbooks.Close();
                app.Application.Quit();
                app.Quit();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

                workSheet = null;
                workBook = null;
                app = null;

                GC.Collect();
            }
            catch (Exception ex)
            {
                try
                {
                    File.Delete(outFile);
                }
                catch (Exception e)
                {
                    Logger.Error("Excel文件保存,失败后复制文件的删除。", e);
                }
                Logger.Error("Excel文件保存失败。", null);
                return CConstant.EXPORT_FAILURE;
            }
            finally
            {
                Process[] myProcesses;
                DateTime startTime;
                myProcesses = Process.GetProcessesByName("Excel");

                //得不到Excel进程ID，暂时只能判断进程启动时间
                foreach (Process myProcess in myProcesses)
                {
                    startTime = myProcess.StartTime;

                    if (startTime > beforeTime && startTime < afterTime)
                    {
                        myProcess.Kill();
                    }
                }
            }
            #endregion

            return CConstant.EXPORT_SUCCESS;
        }
        #endregion

        #region 应收账款管理表
        /// <summary>
        /// 应收账款管理表
        /// </summary>
        public static int ExportReceivables(string templetFile, string outFile, DataTable machineDt, DataTable partsDt, Hashtable ht, string[] headerTitles)
        {
            object missing = Missing.Value;
            DateTime beforeTime;
            DateTime afterTime;

            #region Excel文件初始化
            //只读属性的变更
            FileInfo fi = new FileInfo(templetFile);
            if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
            {
                fi.Attributes = FileAttributes.Normal;
            }
            //拷贝模版文件生成新文件
            if (File.Exists(templetFile))
            {
                try
                {
                    File.Copy(templetFile, outFile, true);
                }
                catch (Exception ex)
                {
                    Logger.Error("文件正在运行，重新生成文件失败。", ex);
                    return CConstant.EXPORT_RUNNING;
                }
            }
            else
            {
                Logger.Error("模版文件不存在。", null);
                return CConstant.EXPORT_TEMPLETE_FILE_NOT_EXIST;
            }

            beforeTime = DateTime.Now;

            //创建一个Application对象并使其可见            
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.ApplicationClass();
            app.Visible = false;
            afterTime = DateTime.Now;

            //打开模板文件，得到WorkBook对象
            Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Open(outFile, missing, missing, missing, missing, missing, missing,
                               missing, missing, missing, missing, missing, missing, missing, missing);

            //得到WorkSheet对象
            Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Sheets.get_Item(1);

            //特定内容的替换
            foreach (DictionaryEntry de in ht)
            {
                try
                {
                    workSheet.Cells.Replace(de.Key, de.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                }
                catch
                {
                    continue;
                }
            }
            #endregion

            //机械本体的数据
            int machineStartRow = 9;
            int machineEndRow = machineStartRow;
            if (machineDt != null && machineDt.Rows.Count > 0)
            {
                machineEndRow = machineDt.Rows.Count + machineStartRow;
                workSheet.Cells[machineStartRow, 1] = "机械本体";
                for (int i = 1; i < headerTitles.Length; i++)
                {
                    workSheet.Cells[machineStartRow - 1, i + 1] = headerTitles[i];
                }

                for (int i = machineStartRow; i < machineEndRow; i++)
                {
                    DataRow dr = machineDt.Rows[i - machineStartRow];
                    for (int j = 1; j < machineDt.Columns.Count; j++)
                    {
                        workSheet.Cells[i, j + 1] = dr[j];
                    }
                }
            }

            //机械部件的数据
            if (partsDt != null && partsDt.Rows.Count > 0)
            {
                int partsStartRow = machineEndRow + 3;
                int partsEndRow = partsDt.Rows.Count + partsStartRow;
                workSheet.Cells[partsStartRow, 1] = "机械部件";
                for (int i = 1; i < headerTitles.Length; i++)
                {
                    workSheet.Cells[partsStartRow - 1, i + 1] = headerTitles[i];
                }

                for (int i = partsStartRow; i < partsEndRow; i++)
                {
                    DataRow dr = partsDt.Rows[i - partsStartRow];
                    for (int j = 1; j < partsDt.Columns.Count; j++)
                    {
                        workSheet.Cells[i, j + 1] = dr[j];
                    }
                }
            }


            #region 输出Excel文件并退出
            //输出Excel文件并退出
            try
            {
                workBook.Save();
                workBook.Close(null, null, null);
                app.Workbooks.Close();
                app.Application.Quit();
                app.Quit();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

                workSheet = null;
                workBook = null;
                app = null;

                GC.Collect();
            }
            catch (Exception ex)
            {
                try
                {
                    File.Delete(outFile);
                }
                catch (Exception e)
                {
                    Logger.Error("Excel文件保存,失败后复制文件的删除。", e);
                }
                Logger.Error("Excel文件保存失败。", null);
                return CConstant.EXPORT_FAILURE;
            }
            finally
            {
                Process[] myProcesses;
                DateTime startTime;
                myProcesses = Process.GetProcessesByName("Excel");

                //得不到Excel进程ID，暂时只能判断进程启动时间
                foreach (Process myProcess in myProcesses)
                {
                    startTime = myProcess.StartTime;

                    if (startTime > beforeTime && startTime < afterTime)
                    {
                        myProcess.Kill();
                    }
                }
            }
            #endregion

            return CConstant.EXPORT_SUCCESS;
        }
        #endregion

        /// <summary>
        /// 将DataTable数据写入Excel文件
        /// </summary>
        /// <param name="p"></param>
        /// <param name="dt"></param>
        public static int DataTableToExcel_BOM(string fileName, DataTable dt)
        {
            object missing = Missing.Value;
            DateTime beforeTime;
            DateTime afterTime;

            beforeTime = DateTime.Now;

            //实例化一个Excel.Application对象
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            afterTime = DateTime.Now;
            Microsoft.Office.Interop.Excel.Workbooks workBooks = app.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workBook = workBooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Worksheets[1];

            //生成Excel中列头名称
            int i = 1;
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                workSheet.Cells[i, j + 1] = dt.Columns[j].ColumnName;
            }

            i++;
            //把DataGridView当前页的数据保存在Excel中
            foreach (DataRow dr in dt.Rows)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (dr[j].GetType() == typeof(string))
                    {
                        workSheet.Cells[i, j + 1] = "'" + CConvert.ToString(dr[j]);
                    }
                    else
                    {
                        workSheet.Cells[i, j + 1] = CConvert.ToString(dr[j]);
                    }
                }
                i++;
            }

            //输出Excel文件并退出
            try
            {
                workBook.SaveAs(fileName, missing, missing, missing, missing, missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, missing, missing, missing, missing, missing);
                workBook.Close(null, null, null);
                app.Workbooks.Close();
                app.Application.Quit();
                app.Quit();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

                workSheet = null;
                workBook = null;
                app = null;

                GC.Collect();
            }
            catch (Exception e)
            {
                Logger.Error("导出生产物料清单失败。", e);
                return CConstant.EXPORT_FAILURE;
            }
            finally
            {
                Process[] myProcesses;
                DateTime startTime;
                myProcesses = Process.GetProcessesByName("Excel");

                //得不到Excel进程ID，暂时只能判断进程启动时间
                foreach (Process myProcess in myProcesses)
                {
                    startTime = myProcess.StartTime;

                    if (startTime > beforeTime && startTime < afterTime)
                    {
                        myProcess.Kill();
                    }
                }
            }

            return CConstant.EXPORT_SUCCESS;
        }

        #region 报价单
        /// <summary>
        /// 将DataTable数据写入Excel文件（套用模板）
        /// <summary>
        /// <param name="templetFile">模版文件</param>
        /// <param name="outFile">输出文件</param>
        /// <param name="dt">数据集</param>
        /// <param name="ht">替换的特定内容</param>
        /// <returns></returns>
        public static int DataTableToExcel_Quotation(string templetFile, string outFile, DataTable dt, Hashtable ht)
        {
            object missing = Missing.Value;
            DateTime beforeTime;
            DateTime afterTime;

            //拷贝模版文件生成新文件
            if (File.Exists(templetFile))
            {
                try
                {
                    File.Copy(templetFile, outFile, true);
                }
                catch (Exception ex)
                {
                    Logger.Error("文件正在运行，重新生成文件失败。", ex);
                    return CConstant.EXPORT_RUNNING;
                }
            }
            else
            {
                Logger.Error("模版文件不存在。", null);
                return CConstant.EXPORT_TEMPLETE_FILE_NOT_EXIST;
            }

            beforeTime = DateTime.Now;

            //创建一个Application对象并使其可见            
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.ApplicationClass();
            app.Visible = false;
            afterTime = DateTime.Now;

            //打开模板文件，得到WorkBook对象
            Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Open(outFile, missing, missing, missing, missing, missing, missing,
                               missing, missing, missing, missing, missing, missing, missing, missing);

            //得到WorkSheet对象
            Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Sheets.get_Item(1);

            //特定内容的替换
            foreach (DictionaryEntry de in ht)
            {
                try
                {
                    workSheet.Cells.Replace(de.Key, de.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                }
                catch
                {
                    continue;
                }
            }

            //数据
            int startRow = 14;
            int endRow = dt.Rows.Count + startRow;

            for (int i = startRow; i < endRow; i++)
            {
                if (i >= 18 && i < endRow - 1)
                {
                    Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)workSheet.Rows[i, Type.Missing];
                    range.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlDirection.xlDown,
                        Microsoft.Office.Interop.Excel.XlInsertFormatOrigin.xlFormatFromLeftOrAbove);

                    workSheet.get_Range(workSheet.Cells[i, 2], workSheet.Cells[i, 4]).MergeCells = true;
                    workSheet.get_Range(workSheet.Cells[i, 9], workSheet.Cells[i, 10]).MergeCells = true;
                }
                DataRow dr = dt.Rows[i - startRow];

                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (dt.Columns[j].ColumnName.Contains("X_"))
                    {
                        continue;
                    }
                    if (dr[j].GetType() == typeof(string))
                    {
                        workSheet.Cells[i, j + 1] = "'" + Convert.ToString(dr[j]);
                    }
                    else
                    {
                        workSheet.Cells[i, j + 1] = Convert.ToString(dr[j]);
                    }
                }
            }

            //输出Excel文件并退出
            try
            {
                workBook.Save();
                //workBook.SaveAs(outFile, missing, missing, missing, missing, missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, missing, missing, missing, missing, missing);
                workBook.Close(null, null, null);
                app.Workbooks.Close();
                app.Application.Quit();
                app.Quit();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

                workSheet = null;
                workBook = null;
                app = null;

                GC.Collect();
            }
            catch (Exception ex)
            {
                try
                {
                    File.Delete(outFile);
                }
                catch (Exception e)
                {
                    Logger.Error("Excel文件保存,失败后复制文件的删除。", e);
                }
                Logger.Error("Excel文件保存失败。", null);
                return CConstant.EXPORT_FAILURE;
            }
            finally
            {
                Process[] myProcesses;
                DateTime startTime;
                myProcesses = Process.GetProcessesByName("Excel");

                //得不到Excel进程ID，暂时只能判断进程启动时间
                foreach (Process myProcess in myProcesses)
                {
                    startTime = myProcess.StartTime;

                    if (startTime > beforeTime && startTime < afterTime)
                    {
                        myProcess.Kill();
                    }
                }
            }

            return CConstant.EXPORT_SUCCESS; 

        }
        #endregion

        #region 采购订单跟踪
        public static int DataTableToExcel_Purchase_Order_Track(string templetFile, string outFile, DataTable dt, Hashtable ht)
        {
            object missing = Missing.Value;
            DateTime beforeTime;
            DateTime afterTime;

            //拷贝模版文件生成新文件
            if (File.Exists(templetFile))
            {
                try
                {
                    File.Copy(templetFile, outFile, true);
                }
                catch (Exception ex)
                {
                    Logger.Error("文件正在运行，重新生成文件失败。", ex);
                    return CConstant.EXPORT_RUNNING;
                }
            }
            else
            {
                Logger.Error("模版文件不存在。", null);
                return CConstant.EXPORT_TEMPLETE_FILE_NOT_EXIST;
            }

            beforeTime = DateTime.Now;

            //创建一个Application对象并使其可见            
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.ApplicationClass();
            app.Visible = false;
            afterTime = DateTime.Now;

            //打开模板文件，得到WorkBook对象
            Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Open(outFile, missing, missing, missing, missing, missing, missing,
                               missing, missing, missing, missing, missing, missing, missing, missing);

            //得到WorkSheet对象
            Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Sheets.get_Item(1);

            //特定内容的替换
            foreach (DictionaryEntry de in ht)
            {
                try
                {
                    workSheet.Cells.Replace(de.Key, de.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                }
                catch
                {
                    continue;
                }
            }

            //数据
            int startRow = 2;
            int endRow = dt.Rows.Count + startRow;

            for (int i = startRow; i < endRow; i++)
            {
                if (i >= 2 && i < endRow - 1)
                {
                    Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)workSheet.Rows[i, Type.Missing];
                    range.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlDirection.xlDown,
                        Microsoft.Office.Interop.Excel.XlInsertFormatOrigin.xlFormatFromLeftOrAbove);

                    //workSheet.get_Range(workSheet.Cells[i, 2], workSheet.Cells[i, 4]).MergeCells = true;
                    //workSheet.get_Range(workSheet.Cells[i, 9], workSheet.Cells[i, 10]).MergeCells = true;
                }
                DataRow dr = dt.Rows[i - startRow];

                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (dt.Columns[j].ColumnName.Contains("X_"))
                    {
                        continue;
                    }
                    if (dr[j].GetType() == typeof(string))
                    {
                        workSheet.Cells[i, j + 1] = "'" + Convert.ToString(dr[j]);
                    }
                    else
                    {
                        workSheet.Cells[i, j + 1] = Convert.ToString(dr[j]);
                    }
                }
            }

            //输出Excel文件并退出
            try
            {
                workBook.Save();
                //workBook.SaveAs(outFile, missing, missing, missing, missing, missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, missing, missing, missing, missing, missing);
                workBook.Close(null, null, null);
                app.Workbooks.Close();
                app.Application.Quit();
                app.Quit();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

                workSheet = null;
                workBook = null;
                app = null;

                GC.Collect();
            }
            catch (Exception ex)
            {
                try
                {
                    File.Delete(outFile);
                }
                catch (Exception e)
                {
                    Logger.Error("Excel文件保存,失败后复制文件的删除。", e);
                }
                Logger.Error("Excel文件保存失败。", null);
                return CConstant.EXPORT_FAILURE;
            }
            finally
            {
                Process[] myProcesses;
                DateTime startTime;
                myProcesses = Process.GetProcessesByName("Excel");

                //得不到Excel进程ID，暂时只能判断进程启动时间
                foreach (Process myProcess in myProcesses)
                {
                    startTime = myProcess.StartTime;

                    if (startTime > beforeTime && startTime < afterTime)
                    {
                        myProcess.Kill();
                    }
                }
            }

            return CConstant.EXPORT_SUCCESS;
        }

        #endregion

        #region 外购件订单
        public static int DataTableToExcel_SF(string templetFile, string outFile, DataTable dt,Hashtable ht)
        {
            object missing = Missing.Value;
            DateTime beforeTime;
            DateTime afterTime;

            //只读属性的变更
            FileInfo fi = new FileInfo(templetFile);
            if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
            {
                fi.Attributes = FileAttributes.Normal;
            }
            //拷贝模版文件，生成新文件
            if (File.Exists(templetFile))
            {
                try 
                {
                    File.Copy(templetFile, outFile, true);
                }
                catch(Exception ex)
                {
                    Logger.Error("文件正在运行，重新生成文件失败。", ex);
                    return CConstant.EXPORT_RUNNING;
                }
            }
            else
            {
                Logger.Error("模版文件不存在。", null);
                return CConstant.EXPORT_TEMPLETE_FILE_NOT_EXIST;
            }

            beforeTime = DateTime.Now;

            //创建一个Application对象并使其可见            
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.ApplicationClass();
            app.Visible = false;
            afterTime = DateTime.Now;

            //打开模板文件，得到WorkBook对象
            Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Open(outFile, missing, missing, missing, missing, missing, missing,
                               missing, missing, missing, missing, missing, missing, missing, missing);

            //得到WorkSheet对象
            Microsoft.Office.Interop.Excel.Worksheet workSheet = null;

            try
            {                
                workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Sheets.get_Item(1);
                //特定内容的替换
                foreach (DictionaryEntry de in ht)
                {
                    try
                    {
                        workSheet.Cells.Replace(de.Key, de.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                    }
                    catch
                    {
                        continue;
                    }
                }

                //数据
                int startRow = 23;
                int addRow = 29;
                int endRow = dt.Rows.Count + startRow;

                for (int i = startRow; i < endRow; i++)
                {
                    if (i >= addRow && i < endRow - 1)
                    {
                        Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)workSheet.Rows[i, Type.Missing];
                        range.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlDirection.xlDown,
                            Microsoft.Office.Interop.Excel.XlInsertFormatOrigin.xlFormatFromLeftOrAbove);

                        //workSheet.get_Range(workSheet.Cells[i, 2], workSheet.Cells[i, 4]).MergeCells = true;
                        //workSheet.get_Range(workSheet.Cells[i, 9], workSheet.Cells[i, 10]).MergeCells = true;
                    }
                    DataRow dr = dt.Rows[i - startRow];

                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (dr[j].GetType() == typeof(string))
                        {
                            workSheet.Cells[i, j + 1] = "'" + Convert.ToString(dr[j]);
                        }
                        else
                        {
                            workSheet.Cells[i, j + 1] = Convert.ToString(dr[j]);
                        }
                    }
                }

                //输出Excel文件并退出            
                workBook.Save();
                //workBook.SaveAs(outFile, missing, missing, missing, missing, missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, missing, missing, missing, missing, missing);
                workBook.Close(null, null, null);
                app.Workbooks.Close();
                app.Application.Quit();
                app.Quit();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

                workSheet = null;
                workBook = null;
                app = null;

                GC.Collect();
            }
            catch (Exception ex)
            {
                try
                {
                    File.Delete(outFile);
                }
                catch (Exception e)
                {
                    Logger.Error("Excel文件保存,失败后复制文件的删除。", e);
                }
                Logger.Error("Excel文件保存失败。", null);
                return CConstant.EXPORT_FAILURE;
            }
            finally
            {
                Process[] myProcesses;
                DateTime startTime;
                myProcesses = Process.GetProcessesByName("Excel");

                //得不到Excel进程ID，暂时只能判断进程启动时间
                foreach (Process myProcess in myProcesses)
                {
                    startTime = myProcess.StartTime;

                    if (startTime > beforeTime && startTime < afterTime)
                    {
                        myProcess.Kill();
                    }
                }
            }

            return CConstant.EXPORT_SUCCESS;
        }
        #endregion

        #region 询价单
        public static int DataTableToExcel_IS(string templetFile, string outFile, DataTable dt, Hashtable ht)
        {
            object missing = Missing.Value;
            DateTime beforeTime;
            DateTime afterTime;

            //只读属性的变更
            FileInfo fi = new FileInfo(templetFile);
            if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
            {
                fi.Attributes = FileAttributes.Normal;
            }
            //拷贝模版文件，生成新文件
            if (File.Exists(templetFile))
            {
                try
                {
                    File.Copy(templetFile, outFile, true);
                }
                catch (Exception ex)
                {
                    Logger.Error("文件正在运行，重新生成文件失败。", ex);
                    return CConstant.EXPORT_RUNNING;
                }
            }
            else
            {
                Logger.Error("模版文件不存在。", null);
                return CConstant.EXPORT_TEMPLETE_FILE_NOT_EXIST;
            }

            beforeTime = DateTime.Now;

            //创建一个Application对象并使其可见            
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.ApplicationClass();
            app.Visible = false;
            afterTime = DateTime.Now;

            //打开模板文件，得到WorkBook对象
            Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Open(outFile, missing, missing, missing, missing, missing, missing,
                               missing, missing, missing, missing, missing, missing, missing, missing);

            //得到WorkSheet对象
            Microsoft.Office.Interop.Excel.Worksheet workSheet = null;

            try
            {
                workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Sheets.get_Item(1);
                //特定内容的替换
                foreach (DictionaryEntry de in ht)
                {
                    try
                    {
                        workSheet.Cells.Replace(de.Key, de.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                    }
                    catch
                    {
                        continue;
                    }
                }

                //数据
                int startRow = 21;
                int addRow = 27;
                int endRow = dt.Rows.Count + startRow;

                for (int i = startRow; i < endRow; i++)
                {
                    if (i >= addRow && i < endRow - 1)
                    {
                        Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)workSheet.Rows[i, Type.Missing];
                        range.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlDirection.xlDown,
                            Microsoft.Office.Interop.Excel.XlInsertFormatOrigin.xlFormatFromLeftOrAbove);

                        //workSheet.get_Range(workSheet.Cells[i, 2], workSheet.Cells[i, 4]).MergeCells = true;
                        //workSheet.get_Range(workSheet.Cells[i, 9], workSheet.Cells[i, 10]).MergeCells = true;
                    }
                    DataRow dr = dt.Rows[i - startRow];

                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (dr[j].GetType() == typeof(string))
                        {
                            workSheet.Cells[i, j + 1] = "'" + Convert.ToString(dr[j]);
                        }
                        else
                        {
                            workSheet.Cells[i, j + 1] = Convert.ToString(dr[j]);
                        }
                    }
                }

                //输出Excel文件并退出            
                workBook.Save();
                //workBook.SaveAs(outFile, missing, missing, missing, missing, missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, missing, missing, missing, missing, missing);
                workBook.Close(null, null, null);
                app.Workbooks.Close();
                app.Application.Quit();
                app.Quit();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

                workSheet = null;
                workBook = null;
                app = null;

                GC.Collect();
            }
            catch (Exception ex)
            {
                try
                {
                    File.Delete(outFile);
                }
                catch (Exception e)
                {
                    Logger.Error("Excel文件保存,失败后复制文件的删除。", e);
                }
                Logger.Error("Excel文件保存失败。", null);
                return CConstant.EXPORT_FAILURE;
            }
            finally
            {
                Process[] myProcesses;
                DateTime startTime;
                myProcesses = Process.GetProcessesByName("Excel");

                //得不到Excel进程ID，暂时只能判断进程启动时间
                foreach (Process myProcess in myProcesses)
                {
                    startTime = myProcess.StartTime;

                    if (startTime > beforeTime && startTime < afterTime)
                    {
                        myProcess.Kill();
                    }
                }
            }

            return CConstant.EXPORT_SUCCESS;
        }
        #endregion

        #region 生产通知单
        public static int DataTableToExcel_Production_Orders(string templetFile, string outFile, DataTable dt, List<DataTable> list, List<Hashtable> hashTable)
        {
            object missing = Missing.Value;
            DateTime beforeTime;
            DateTime afterTime;

            //只读属性的变更
            FileInfo fi = new FileInfo(templetFile);
            if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
            {
                fi.Attributes = FileAttributes.Normal;
            }
            //拷贝模版文件，生成新文件
            if (File.Exists(templetFile))
            {
                try
                {
                    File.Copy(templetFile, outFile, true);
                }
                catch (Exception ex)
                {
                    Logger.Error("文件正在运行，重新生成文件失败。", ex);
                    return CConstant.EXPORT_RUNNING;
                }
            }
            else
            {
                Logger.Error("模版文件不存在。", null);
                return CConstant.EXPORT_TEMPLETE_FILE_NOT_EXIST;
            }

            beforeTime = DateTime.Now;

            //创建一个Application对象并使其可见            
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.ApplicationClass();
            app.Visible = false;
            afterTime = DateTime.Now;

            //打开模板文件，得到WorkBook对象
            Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Open(outFile, missing, missing, missing, missing, missing, missing,
                               missing, missing, missing, missing, missing, missing, missing, missing);

            //得到WorkSheet对象
            Microsoft.Office.Interop.Excel.Worksheet workSheet = null;
            try
            {
                workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Sheets.get_Item(2);
                for (int n = 1; n < list.Count; n++)
                {
                    workSheet.Copy(Type.Missing, workBook.Sheets[2]);
                }
                for (int n = 1; n <= workBook.Sheets.Count; n++)
                {
                    workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Sheets.get_Item(n);
                    if (n == 1)
                    {
                        #region 目录
                        //数据
                        int startRow = 3;
                        int addRow = 4;
                        int endRow = dt.Rows.Count + startRow;

                        for (int i = startRow; i < endRow; i++)
                        {
                            if (i >= addRow && i < endRow - 1)
                            {
                                Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)workSheet.Rows[i, Type.Missing];
                                range.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlDirection.xlDown,
                                    Microsoft.Office.Interop.Excel.XlInsertFormatOrigin.xlFormatFromLeftOrAbove);

                                workSheet.get_Range(workSheet.Cells[i, 3], workSheet.Cells[i, 5]).MergeCells = true;
                                //workSheet.get_Range(workSheet.Cells[i, 9], workSheet.Cells[i, 10]).MergeCells = true;
                            }
                            DataRow dr = dt.Rows[i - startRow];

                            for (int j = 0; j < dt.Columns.Count; j++)
                            {
                                if (dt.Columns[j].ColumnName.Contains("X_"))
                                {
                                    continue;
                                }
                                if (dr[j].GetType() == typeof(string))
                                {
                                    workSheet.Cells[i, j + 2] = "'" + Convert.ToString(dr[j]);
                                }
                                else
                                {
                                    workSheet.Cells[i, j + 2] = Convert.ToString(dr[j]);
                                }
                            }
                        }
                        #endregion
                    }
                    else if (n > 1)
                    {
                        #region 插单
                        string name = "";
                        //workSheet.Name = hashTable[n - 2]["&NAME"];
                        //特定内容的替换
                        foreach (DictionaryEntry de in hashTable[n-2])
                        {
                            try
                            {
                                workSheet.Cells.Replace(de.Key, de.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                                if (de.Key.ToString() == "&NAME")
                                {
                                    name = de.Value.ToString();
                                }
                            }
                            catch
                            {
                                continue;
                            }
                        }
                        workSheet.Name =name;

                        DataTable Dt = list[n - 2];
                        //数据
                        int startRow = 6;
                        int addRow = 22;
                        int endRow = Dt.Rows.Count + startRow;

                        for (int i = startRow; i < endRow; i++)
                        {
                            if (i >= addRow && i < endRow - 1)
                            {
                                Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)workSheet.Rows[i, Type.Missing];
                                range.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlDirection.xlDown,
                                    Microsoft.Office.Interop.Excel.XlInsertFormatOrigin.xlFormatFromLeftOrAbove);

                                workSheet.get_Range(workSheet.Cells[i, 3], workSheet.Cells[i, 5]).MergeCells = true;
                                //workSheet.get_Range(workSheet.Cells[i, 9], workSheet.Cells[i, 10]).MergeCells = true;
                            }
                            DataRow dr = Dt.Rows[i - startRow];

                            for (int j = 0; j < Dt.Columns.Count; j++)
                            {
                                if (Dt.Columns[j].ColumnName.Contains("X_"))
                                {
                                    continue;
                                }
                                if (dr[j].GetType() == typeof(string))
                                {
                                    workSheet.Cells[i, j + 1] = "'" + Convert.ToString(dr[j]);
                                }
                                else
                                {
                                    workSheet.Cells[i, j + 1] = Convert.ToString(dr[j]);
                                }
                            }
                        }
                        #endregion
                    }
                }

                //app.DisplayAlerts = false; //如果想删除某个sheet页，首先要将此项设为fasle。
                //(app.ActiveWorkbook.Sheets[2] as Microsoft.Office.Interop.Excel.Worksheet).Delete();

                //输出Excel文件并退出            
                workBook.Save();
                //workBook.SaveAs(outFile, missing, missing, missing, missing, missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, missing, missing, missing, missing, missing);
                workBook.Close(null, null, null);
                app.Workbooks.Close();
                app.Application.Quit();
                app.Quit();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

                workSheet = null;
                workBook = null;
                app = null;

                GC.Collect();
            }
            catch (Exception ex)
            {
                try
                {
                    File.Delete(outFile);
                }
                catch (Exception e)
                {
                    Logger.Error("Excel文件保存,失败后复制文件的删除。", e);
                }
                Logger.Error("Excel文件保存失败。", null);
                return CConstant.EXPORT_FAILURE;
            }
            finally
            {
                Process[] myProcesses;
                DateTime startTime;
                myProcesses = Process.GetProcessesByName("Excel");

                //得不到Excel进程ID，暂时只能判断进程启动时间
                foreach (Process myProcess in myProcesses)
                {
                    startTime = myProcess.StartTime;

                    if (startTime > beforeTime && startTime < afterTime)
                    {
                        myProcess.Kill();
                    }
                }
            }

            return CConstant.EXPORT_SUCCESS;
        }

        #endregion 
    }//end class
}
