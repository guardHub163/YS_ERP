using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CZZD.ERP.Common
{
    public class NumberConvert
    {
        private static readonly string[] StrNo = new string[19];
        private static readonly string[] StrTens = new string[9];
        private static readonly string[] Unit = new string[9];//一つを追加する

        /// <summary>
        /// Number  To  Chinese
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string NumberToChinese(double number)
        {

            string s = number.ToString("#L#E#D#C#K#E#D#C#J#E#D#C#I#E#D#C#H#E#D#C#G#E#D#C#F#E#D#C#.0B0A");
            string d = Regex.Replace(s, @"((?<=-|^)[^1-9]*)|((?'z'0)[0A-E]*((?=[1-9])|(?'-z'(?=[F-L\.]|$))))|((?'b'[F-L])(?'z'0)[0A-L]*((?=[1-9])|(?'-z'(?=[\.]|$))))", "${b}${z}");
            return Regex.Replace(d, ".", m => "负元空零壹贰叁肆伍陆柒捌玖空空空空空空空分角拾佰仟萬億兆京垓秭穰"[m.Value[0] - '-'].ToString());


            //string retStr = "";
            //string[] NumberChineseCharacter = new string[] { "零", "壹", "贰", "叁", "肆", "伍", "陸", "柒", "捌", "玫" };
            //for (int i = 0; i < numberStr.Length; i++)
            //{
            //    string n = numberStr.Substring(i, 1);
            //    if (".".Equals(n))
            //    {
            //        retStr += n;
            //    }
            //    else
            //    {
            //        retStr += NumberChineseCharacter[Convert.ToInt32(n)];
            //    }
            //}

            // return retStr;
        }

        /// <summary>
        /// Number To English 
        /// </summary>
        /// <param name="Number">
        /// bCurrency = true 通貨を出力する
        /// bCurrency = false 通貨を出力しない
        /// </param>
        /// <returns></returns>
        public static string NumberToEnglish(string Number, Boolean bCurrency)
        {
            string str;
            string beforePoint;
            string afterPoint;
            string tmpStr;
            int nBit;
            string curString;
            int nNumLen;
            Init();
            str = Number;
            //ZEROの場合を追加する
            try
            {
                if (str == null || str.Equals("") || Convert.ToDecimal(Number) == 0)
                {
                    return "ZERO";
                }
            }
            catch
            {
                return "ZERO";
            }

            if (str.IndexOf(".") == -1)
            {
                beforePoint = str;
                afterPoint = "";
            }
            else
            {
                beforePoint = str.Substring(0, str.IndexOf("."));
                afterPoint = str.Substring(str.IndexOf(".") + 1, str.Length - str.IndexOf(".") - 1);
            }

            if (beforePoint.Length > 12)
            {
                return null;
            }
            str = "";
            while (beforePoint.Length > 0)
            {
                nNumLen = Len(beforePoint);
                if (nNumLen % 3 == 0)
                {
                    curString = Left(beforePoint, 3);
                    beforePoint = Right(beforePoint, nNumLen - 3);
                }
                else
                {
                    curString = Left(beforePoint, (nNumLen % 3));
                    beforePoint = Right(beforePoint, nNumLen - (nNumLen % 3));
                }

                nBit = Len(beforePoint) / 3;
                tmpStr = DecodeHundred(curString);

                if ((beforePoint == Len(beforePoint).ToString() || nBit == 0) && Len(curString) == 3)
                {
                    if (Convert.ToInt32(Left(curString, 1)) != 0 & Convert.ToInt32(Right(curString, 2)) != 0)
                    {
                        tmpStr = Left(tmpStr, tmpStr.IndexOf(Unit[3]) + Len(Unit[3])) + Unit[7] + " " +
                            Right(tmpStr, Len(tmpStr) - (tmpStr.IndexOf(Unit[3]) + Len(Unit[3])));
                    }
                    else
                    {
                        tmpStr = Unit[7] + "" + tmpStr;
                    }
                }

                if (nBit == 0)
                {
                    str = Convert.ToString(str + " " + tmpStr.Trim());
                }
                else
                {
                    str = Convert.ToString(str + " " + tmpStr + " " + Unit[nBit - 1]).Trim();
                }

                if (Left(str, 3) == Unit[7])
                {
                    str = Convert.ToString(Right(str, Len(str) - 3)).Trim();
                }

                if (beforePoint == Len(beforePoint).ToString())
                {
                    return "";
                }
            }
            beforePoint = str;
            if (Len(afterPoint) > 0)
            {
                //ONLYを追加する
                //afterPoint = Unit[5] + " " + DecodeHundred(afterPoint) + " " + Unit[6];
                if (bCurrency)
                {
                    afterPoint = Unit[5] + " " + DecodeHundred(afterPoint) + " " + Unit[6] + " " + Unit[4];
                }
                else
                {
                    afterPoint = DecodeHundred(afterPoint) + " " + Unit[4];
                }
            }
            else
            {
                //整数の場合も通貨を追加する
                if (bCurrency)
                {
                    afterPoint = Unit[8] + " " + Unit[4];
                }
                else
                {
                    afterPoint = Unit[4];
                }
            }
            return (beforePoint + " " + afterPoint).ToUpper();
        }

        private static void Init()
        {
            int i = 0;
            if (StrNo[i] != "One")
            {
                StrNo[i++] = "One";
                StrNo[i++] = "Two";
                StrNo[i++] = "Three";
                StrNo[i++] = "Four";
                StrNo[i++] = "Five";
                StrNo[i++] = "Six";
                StrNo[i++] = "Seven";
                StrNo[i++] = "Eight";
                StrNo[i++] = "Nine";
                StrNo[i++] = "Ten";
                StrNo[i++] = "Eleven";
                StrNo[i++] = "Twelve";
                StrNo[i++] = "Thirteen";
                StrNo[i++] = "Fourteen";
                StrNo[i++] = "Fifteen";
                StrNo[i++] = "SixTeen";
                StrNo[i++] = "Seventeen";
                StrNo[i++] = "EightTeen";
                StrNo[i++] = "Nineteen";

                i = 0;
                StrTens[i++] = "Ten";
                StrTens[i++] = "Twenty";
                StrTens[i++] = "Thirty";
                StrTens[i++] = "Forty";
                StrTens[i++] = "Fifty";
                StrTens[i++] = "Sixty";
                StrTens[i++] = "Seventy";
                StrTens[i++] = "Eighty";
                StrTens[i++] = "Ninety";

                i = 0;
                Unit[i++] = "Thousand";
                Unit[i++] = "Million";
                Unit[i++] = "Billion";
                Unit[i++] = "Hundred";
                Unit[i++] = "Only";
                Unit[i++] = "Baht and";
                Unit[i++] = "Stangs";
                Unit[i++] = "";
                Unit[i++] = "Baht";
                //Unit[i++] = "";
            }
        }

        private static string DecodeHundred(string hundredString)
        {
            int tmp;
            string rtn = "";
            if (Len(hundredString) > 0 && Len(hundredString) <= 3)
            {
                switch (Len(hundredString))
                {
                    case 1:
                        tmp = Convert.ToInt32(hundredString);
                        if (tmp != 0)
                        {
                            rtn = StrNo[tmp - 1];
                        }
                        break;
                    case 2:
                        tmp = Convert.ToInt32(hundredString);
                        if (tmp != 0)
                        {
                            if ((tmp < 20))
                            {
                                rtn = StrNo[tmp - 1];
                            }
                            else
                            {
                                if (Convert.ToInt32(Right(hundredString, 1)) == 0)
                                {
                                    rtn = StrTens[Convert.ToInt32(tmp / 10) - 1];
                                }
                                else
                                {
                                    rtn = Convert.ToString(StrTens[Convert.ToInt32(tmp / 10) - 1] + " " +
                                        StrNo[Convert.ToInt32(Right(hundredString, 1)) - 1]);
                                }
                            }
                        }
                        break;
                    case 3:
                        if (Convert.ToInt32(Left(hundredString, 1)) != 0)
                        {
                            //スベースを追加する
                            if (Right(hundredString, 2).Equals("00"))
                            {
                                rtn = Convert.ToString(StrNo[Convert.ToInt32(Left(hundredString, 1)) - 1] + " " + Unit[3]);
                            }
                            else
                            {
                                rtn = Convert.ToString(StrNo[Convert.ToInt32(Left(hundredString, 1)) - 1] + " " + Unit[3] + " " + "AND" + " " + DecodeHundred(Right(hundredString, 2)));
                            }
                        }
                        else
                        {
                            rtn = DecodeHundred(Right(hundredString, 2));
                        }
                        break;
                    default:
                        break;
                }
            }
            return rtn;
        }

        private static string Left(string str, int n)
        {
            return str.Substring(0, n);
        }

        private static string Right(string str, int n)
        {
            return str.Substring(str.Length - n, n);
        }

        private static int Len(string str)
        {
            return str.Length;
        }
    }

}
