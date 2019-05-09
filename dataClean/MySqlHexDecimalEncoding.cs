using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataClean
{
    class MySqlHexDecimalEncoding
    {

        public static string hex(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);

            var builder = new StringBuilder();
            builder.Append("0x");

            foreach (var b in bytes)
            {
                builder.Append(b.ToString("X2"));
            }

            return builder.ToString();
        }

        public static string unhex(string hex)
        {
            //https://stackoverflow.com/questions/24218632/how-to-unhex-mysql-binary-string-in-c-sharp-net
            if (hex.StartsWith("0x"))
            {
                hex = hex.Substring(2);
            }
        
            var byteArr = System.Runtime.Remoting.Metadata.W3cXsd2001.SoapHexBinary.Parse(hex).Value;
            return Encoding.UTF8.GetString(byteArr);
        }

        //    public static string Hex2String(string input)
        //    {
        //        var builder = new StringBuilder();
        //        for (int i = 0; i < input.Length; i += 2)
        //        { //throws an exception if not properly formatted
        //            string hexdec = input.Substring(i, 2);
        //            int number = Int32.Parse(hexdec, NumberStyles.HexNumber);
        //            char charToAdd = (char)number;
        //            builder.Append(charToAdd);
        //        }
        //        return builder.ToString();
        //    }
        //    public static string ToHexString(string str)
        //    {
        //        var builder = new StringBuilder();

        //        builder.Append("0x");

        //        var bytes = Encoding.Unicode.GetBytes(str);
        //        /*if (str.Length == 1)
        //        {
        //            var ch = Char.Parse(str);

        //            Console.WriteLine("Char.IsPunctuation(ch):{0}", Char.IsPunctuation(ch));
        //            Console.WriteLine("Char.IsLetter(ch):{0}", Char.IsLetter(ch));
        //            Console.WriteLine("Char.IsDigit(ch):{0}", Char.IsDigit(ch));
        //            Console.WriteLine("Char.IsSeparator(ch):{0}", Char.IsSeparator(ch));

        //            if ( Char.IsLetter(ch) || Char.IsDigit(ch)
        //                || Char.IsPunctuation(ch) || Char.IsSeparator(ch)
        //                || ch == 32)
        //            {
        //                builder.Append(bytes[0].ToString("X2"));
        //                return builder.ToString();
        //            }
        //        }*/

        //        foreach (var b in bytes)
        //        {
        //            builder.Append(b.ToString("X2"));
        //        }

        //        return builder.ToString();
        //    }

        //    public static string FromHexString(string hexString)
        //    {
        //        var bytes = new byte[hexString.Length / 2];
        //        for (var i = 0; i < bytes.Length; i++)
        //        {
        //            bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
        //        }

        //        return Encoding.Unicode.GetString(bytes); // returns: "Hello world" for "48656C6C6F20776F726C64"
        //    }

        //    public static string ConvertStringToHex(string asciiString)
        //    {
        //        string hex = "";
        //        foreach (char c in asciiString)
        //        {
        //            int tmp = c;
        //            hex += String.Format("{0:x2}", (uint)System.Convert.ToUInt32(tmp.ToString()));
        //        }
        //        return hex;
        //    }

        //    public static string ConvertHexToString(string HexValue)
        //    {
        //        string StrValue = "";
        //        while (HexValue.Length > 0)
        //        {
        //            StrValue += System.Convert.ToChar(System.Convert.ToUInt32(HexValue.Substring(0, 2), 16)).ToString();
        //            HexValue = HexValue.Substring(2, HexValue.Length - 2);
        //        }
        //        return StrValue;
        //    }
    }
}
/***
 * MySQL 5.1支持两种字符集以保存Unicode数据：

·         ucs2，UCS-2 Unicode字符集。

·         utf8，Unicode字符集的UTF8编码。

在UCS-2（二进制Unicode表示法）中，每一个字符用一个双字节的Unicode编码来表示的，第一个字节表示重要的意义。例如："LATIN CAPITAL LETTER A"的Unicode编码是0x0041，它按顺序存储为两个字节：0x00 0x41。"CYRILLIC SMALL LETTER YERU"（Unicode 0x044B）顺序存储为两个字节：0x04 0x4B。对于Unicode字符和它们的编码，请参见Unicode 主页。

当前，UCS-2还不能够用作为客户端字符集，这意味着SET NAMES 'ucs2'不起作用。

UTF8字符集（转换Unicode表示）是存储Unicode数据的一种可选方法。它根据 RFC 3629执行。UTF8字符集的思想是不同Unicode字符采用变长字节序列编码：

·         基本拉丁字母、数字和标点符号使用一个字节。

·         大多数的欧洲和中东手写字母适合两个字节序列：扩展的拉丁字母（包括发音符号、长音符号、重音符号、低音符号和其它音符）、西里尔字母、希腊语、亚美尼亚语、希伯来语、阿拉伯语、叙利亚语和其它语言。

·         韩语、中文和日本象形文字使用三个字节序列。

RFC 3629说明了采用一到四个字节的编码序列。当前，MySQLUTF8不支持四个字节。（UTF8编码的旧标准是由RFC 2279给出，它描述了从一到六个字节的UTF8编码序列。RFC 3629补充了作废的RFC 2279；因此，不再使用5个字节和6个字节的编码序列。）

提示：使用UTF8时为了节省空间，使用VARCHAR而不要用CHAR。否则，MySQL必须为一个CHAR(10) CHARACTER SET utf8列预备30个字节，因为这是可能的最大长度。


全角小写英文字母[ａ,ｂ,ｃ,ｄ,ｅ,ｆ,ｇ,ｈ,ｉ,ｇ,ｋ,ｌ,ｍ,ｎ,ｏ,ｐ,ｑ,ｒ,ｓ,ｔ,ｕ,ｖ,ｗ,ｘ,ｙ,ｚ]
    u'\uff41': 'a', u'\uff42': 'b', u'\uff43': 'c', u'\uff44': 'd',
u'\uff45': 'e', u'\uff46': 'f', u'\uff47': 'g', u'\uff48': 'h',
u'\uff49': 'i', u'\uff47': 'j', u'\uff4b': 'k', u'\uff4c': 'l',
u'\uff4d': 'm', u'\uff4e': 'n', u'\uff4f': 'o', u'\uff50': 'p',
u'\uff51': 'q', u'\uff52': 'r', u'\uff53': 's', u'\uff54': 't',
u'\uff55': 'u', u'\uff56': 'v', u'\uff57': 'w', u'\uff58': 'x',
u'\uff59': 'y', u'\uff5a': 'z',

    全角大写英文字母[Ａ,Ｂ,Ｃ,Ｄ,Ｅ,Ｆ,Ｇ,Ｈ,Ｉ,Ｊ,Ｋ,Ｌ,Ｍ,Ｎ,Ｏ,Ｐ,Ｑ,Ｒ,Ｓ,Ｔ,Ｕ,Ｖ,Ｗ,Ｘ,Ｙ,Ｚ]
    u'\uff21': 'A', u'\uff22': 'B', u'\uff23': 'C', u'\uff24': 'D',
u'\uff25': 'E', u'\uff26': 'F', u'\uff27': 'G', u'\uff28': 'H',
u'\uff29': 'I', u'\uff2a': 'J', u'\uff2b': 'K', u'\uff2c': 'L',
u'\uff2d': 'M', u'\uff2e': 'N', u'\uff2f': 'O', u'\uff30': 'P',
u'\uff31': 'K', u'\uff32': 'R', u'\uff33': 'S', u'\uff35': 'T',
u'\uff35': 'U', u'\uff36': 'V', u'\uff37': 'W', u'\uff38': 'X',
u'\uff39': 'Y', u'\uff3a': 'Z',

全角阿拉伯数字[１,２,３,４,５,６,７,８,９,０]
    u'\uff11': '1', u'\uff12': '2', u'\uff13': '3', u'\uff14': '4',
u'\uff15': '5', u'\uff16': '6', u'\uff17': '7', u'\uff18': '8',
u'\uff19': '9', u'\uff10': '0',

中文数字[一,二,三,四,五,六,七,八,九,零]
    u'\u4e00': '1', u'\u4e8c': '2', u'\u4e09': '3', u'\u56db': '4',
u'\u4e94': '5', u'\u516d': '6', u'\u4e03': '7', u'\u516b': '8',
u'\u4e5d': '9', u'\u96f6': '9'

    https://unicode.org/charts/nameslist/c_FF00.html

    SELECT HEX('（') -- ff08  EFBC88　　
    SELECT HEX('）') -- ff09  EFBC89
    SELECT HEX('　') -- 3000  EEBD80 相差 E38080
    mysql的全角hex与unicode相差EEBD80
    unicode　全角范围　FF01-FF5E
*/
