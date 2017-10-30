using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CZZD.ERP.Common
{
    public class CTools
    {
        /// <summary>
        /// 当字符串中存在汉字，计算出其长度
        /// </summary>
        /// <param name="textboxTextStr"></param>
        /// <returns></returns>
        public static int GetTextBoxLength(string textboxTextStr)
        {
            int nLength = 0;  
            for (int i = 0; i < textboxTextStr.Length; i++)  
            {  
                if (textboxTextStr[i] >= 0x3000 && textboxTextStr[i] <= 0x9FFF)  
                    nLength += 2; 
                else 
                    nLength++;  
            }  
            return nLength;  

        }

        /// <summary>
        /// 截取字符串中的某一段字符
        /// </summary>
        public static string textSpilt(string textboxTextStr, int max)
        {
            int lent = System.Text.ASCIIEncoding.Default.GetByteCount(textboxTextStr);
            
            byte[] bb = System.Text.ASCIIEncoding.Default.GetBytes(textboxTextStr);//得到输入的字符串的数组
            if (lent > max)
            {
                textboxTextStr = System.Text.ASCIIEncoding.Default.GetString(bb, 0, max);//将截断后的字节数组转换成字符串
                
            }
            return textboxTextStr;
        }

    }
}
