using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using Microsoft.Office.Interop.Word;
using System.Reflection;

namespace dataClean
{
    public class Converter
    {
        private string m_name;

        private string m_from;
        private bool m_isEncode;

        public Converter(string m_name)
        {
            this.m_name = m_name;
        }

        public Converter(string m_name, bool m_isEncode)
        {
            this.m_name = m_name;
            this.m_isEncode = m_isEncode;
        }

        public static List<Converter> Instance(string[] m_names)
        {
            List<Converter> list = new List<Converter>();
            foreach (string m_name in m_names)
            {
                list.Add(new Converter(m_name));
            }
            return list;
        }

        public string Name { get => m_name; set => m_name = value; }
        public string From { get => m_from; set => m_from = value; }
        public string To
        {

            get
            {
                var delims = new List<string>(new string[] { " ==> ", " --> ", "=>", "->" });
                m_isEncode = delims.Any(item => m_name.Contains(item));
                if (m_isEncode)
                {
                    var codeNames = m_name.Split(new string[] { " ==> ", " --> ", "=>", "->" }, StringSplitOptions.None);

                    var fromCode = codeNames[0].Trim();
                    var toCode = codeNames[1].Trim();
                    return EncodingConvert(m_from, Encoding.GetEncoding(fromCode), Encoding.GetEncoding(toCode));
                }


                var listOfAlgorithm = new List<string>(new string[] { "md5", "sha256" });
                if (listOfAlgorithm.Any(item => m_name.Contains(item)))
                {
                    return CryptFactory.ComputeHash(new Cryptor.CryptBuilder(m_name, m_from));
                }

                switch (m_name)
                {
                    case "html Entity":
                        return HttpUtility.HtmlDecode(m_from);
                    case "trim":
                        return m_from.Trim();
                    case "trimAll":
                        return m_from.Replace(" "/*普通空格*/, "").Replace("　"/*全角空格*/, "");
                    case "trimLeft":
                        return m_from.TrimStart();
                    case "trimRight":
                        return m_from.TrimEnd();
                    case "upper":
                        return m_from.ToUpper();
                    case "lower":
                        return m_from.ToLower();
                    case "简转繁":
                        return CHSToCHT(m_from);
                    case "繁转简":
                        return CHTToCHS(m_from);

                }
                return m_from;
            }
        }

        /// <summary>
        /// 简体转繁体
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string CHSToCHT(string src)
        {
            string des = "";
            _Application appWord = new Application();
            object template = Missing.Value;
            object newTemplate = Missing.Value;
            object docType = Missing.Value;
            object visible = true;
            Document doc = appWord.Documents.Add(ref template, ref newTemplate, ref docType, ref visible);
            appWord.Selection.TypeText(src);
            appWord.Selection.Range.TCSCConverter(WdTCSCConverterDirection.wdTCSCConverterDirectionSCTC, false, false);
            appWord.ActiveDocument.Select();
            des = appWord.Selection.Text.Trim();
            object saveChange = 0;
            object originalFormat = Missing.Value;
            object routeDocument = Missing.Value;
            appWord.Quit(ref saveChange, ref originalFormat, ref routeDocument);
            doc = null;
            appWord = null;
            GC.Collect();//进程资源释放
            return des;
        }
        /// <summary>
        /// 繁体转简体
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string CHTToCHS(string src)
        {
            string des = "";
            _Application appWord = new Microsoft.Office.Interop.Word.Application();
            object template = Missing.Value;
            object newTemplate = Missing.Value;
            object docType = Missing.Value;
            object visible = true;
            Document doc = appWord.Documents.Add(ref template, ref newTemplate, ref docType, ref visible);
            appWord.Selection.TypeText(src);
            appWord.Selection.Range.TCSCConverter(WdTCSCConverterDirection.wdTCSCConverterDirectionTCSC, false, false);
            appWord.ActiveDocument.Select();
            des = appWord.Selection.Text.Trim();
            object saveChange = 0;
            object originalFormat = Missing.Value;
            object routeDocument = Missing.Value;
            appWord.Quit(ref saveChange, ref originalFormat, ref routeDocument);
            doc = null;
            appWord = null;
            GC.Collect();//进程资源释放
            return des;
        }

        ///
        /// 使用系統 kernel32.dll 進行轉換
        ///
        private const int LocaleSystemDefault = 0x0800;
        private const int LcmapSimplifiedChinese = 0x02000000;
        private const int LcmapTraditionalChinese = 0x04000000;

        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int LCMapString(int locale, int dwMapFlags, string lpSrcStr, int cchSrc,
                                              [Out] string lpDestStr, int cchDest);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int LCMapStringEx(
                   string lpLocaleName,        //  LPCWSTR      lpLocaleName
                   uint dwMapFlags,        //  DWORD        dwMapFlags
                   string lpSrcStr,        //  LPCWSTR      lpSrcStr
                   int cchSrc,             //  int          cchSrc
                   [Out]
                 string lpDestStr,           //  LPWSTR       lpDestStr
                   int cchDest,            //  int          cchDest
                   IntPtr lpVersionInformation,    //  LPNLSVERSIONINFO lpVersionInformation
                   IntPtr lpReserved,          //  LPVOID       lpReserved
                   IntPtr sortHandle);         //  LPARAM       sortHandle

        //https://coolong124220.nidbox.com/diary/read/8045380
        //云转繁体有问题？ bug？
        public static string ToSimplified(string argSource)
        {
            var t = new String(' ', argSource.Length);
            LCMapString(LocaleSystemDefault, LcmapSimplifiedChinese, argSource, argSource.Length, t, argSource.Length);
            return t;
        }

        public static string ToSimplifiedEx(string argSource)
        {
            var t = new String(' ', argSource.Length);
            //var t = new StringBuilder(argSource.Length);
            LCMapStringEx("zh-CN", LcmapSimplifiedChinese, argSource, argSource.Length, t, argSource.Length, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
            return t;
        }

        public static string ToTraditional(string argSource)
        {
            var t = new String(' ', argSource.Length);
            LCMapString(LocaleSystemDefault, LcmapTraditionalChinese, argSource, argSource.Length, t, argSource.Length);
            return t;
        }

        public static string ToTraditionalEx(string argSource)
        {
            var t = new String(' ', argSource.Length);
            LCMapStringEx("zh-CN", LcmapTraditionalChinese, argSource, argSource.Length, t, argSource.Length, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
            return t.ToString();
        }

        public string EncodingConvert(string fromString, Encoding fromEncoding, Encoding toEncoding)
        {
            byte[] fromBytes = fromEncoding.GetBytes(fromString);
            byte[] toBytes = Encoding.Convert(fromEncoding, toEncoding, fromBytes);

            string toString = toEncoding.GetString(toBytes);
            return toString;
        }

        public override string ToString()
        {
            return m_name;
        }
    }
}
