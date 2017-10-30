using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace CZZD.ERP.Common
{
    public class FileType
    {
        private static Hashtable _fileType = null;

        public static Hashtable GetFileType()
        {
            if (_fileType == null)
            {
                _fileType = new Hashtable();
                _fileType.Add("JPG", "JPEG　图片文件(jpg)");
                _fileType.Add("PNG", "PNG　图片文件(png)");
                _fileType.Add("GIF", "GIF 图片文件(gif)");
                _fileType.Add("TIFF", "TIFF 图片文件(tif)");
                _fileType.Add("BMP", "Windows Bitmap 图片文件(bmp)");
                _fileType.Add("DWG", "CAD 绘图文件(dwg)");
                _fileType.Add("PSD", "Adobe Photoshop 图片文件(psd)");
                _fileType.Add("RTF", "Rich Text Format (rtf)");
                _fileType.Add("XML", "XML 文本文件(xml)");
                _fileType.Add("HTML", "HTML (html)");
                _fileType.Add("EML", "Email [thorough only] (eml)");
                _fileType.Add("DBX", "Outlook Express (dbx)");
                _fileType.Add("PST", "Outlook (pst)");
                _fileType.Add("XLS", "MS Word/Excel (xls.or.doc)");
                _fileType.Add("DOC", "MS Word/Excel (xls.or.doc)");
                _fileType.Add("XLSX", "MS Word/Excel (xlsx.or.docx)");
                _fileType.Add("DOCX", "MS Word/Excel (xlsx.or.docx)");
                _fileType.Add("MDB", "MS Access (mdb)");
                _fileType.Add("WPD", "WordPerfect (wpd)");                
                _fileType.Add("PDF", "Adobe Acrobat (pdf)");
                _fileType.Add("ZIP", "ZIP Archive (zip)");
                _fileType.Add("RAR", "RAR Archive (rar)");
                _fileType.Add("WAV", "Wave (wav)");
                _fileType.Add("AVI", "AVI (avi)");
                _fileType.Add("RAM", "Real Audio (ram)");
                _fileType.Add("RM", "Real Media (rm)");
                _fileType.Add("TXT", "文本文件(txt)");
                _fileType.Add("DAT", "数据文件 (dat)");
                _fileType.Add("EXE", "可执行文件 (EXE)");

            }
            return _fileType;
        }
    }//end class
}
