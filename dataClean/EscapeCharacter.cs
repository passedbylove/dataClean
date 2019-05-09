using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataClean
{
    public class EscapeCharacter
    {
        public static char ch1 = '\\';
        public static char ch2 = '%'; //mysql
        public static char ch3 = '_';
        public static char ch4 = '\'';
        public static char ch5 = '\"';

        /*referencesMap.put("_", "\\_");
        referencesMap.put("'", "\\'");
        referencesMap.put("%", "\\%");
        referencesMap.put("\"", "\\\"");
        referencesMap.put("\\", "\\\\");


        referencesMap.put("\n", "\\\n");
        referencesMap.put("\0", "\\\0");
        referencesMap.put("\b", "\\\b");
        referencesMap.put("\r", "\\\r");
        referencesMap.put("\t", "\\\t");
        referencesMap.put("\f", "\\\f");*/
        private static string stringOfBackslashChars = "\u005c\u00a5\u0160\u20a9\u2216\ufe68\uff3c";//0xE38080全角 //0x20半角//https://www.jianshu.com/p/4317e3749a13
        //https://stackoverflow.com/questions/5828364/what-would-be-a-sql-query-to-remove-n-r-from-the-text
        private static string stringOfQuoteChars =
            "\u0022\u0027\u0060\u00b4\u02b9\u02ba\u02bb\u02bc\u02c8\u02ca\u02cb\u02d9\u0300\u0301\u2018\u2019\u201a\u2032\u2035\u275b\u275c\uff07";
        //https://blog.csdn.net/allen_cn/article/details/5186832

//        select 'drop table '+a.name+';' from sysobjects a
// inner join sysindexes b on a.id = b.id
// where a.type = 'u'
//   and b.indid in (0, 1) and b.rows=0
//order by a.name
    }
}
