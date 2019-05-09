using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataClean
{
    //https://stackoverflow.com/questions/16999604/convert-string-to-hex-string-in-c-sharp
    public class HexadecimalEncoding
    {
        public virtual string ToHexString(string str)
        {
            var sb = new StringBuilder();

            var bytes = Encoding.Unicode.GetBytes(str);
            foreach (var t in bytes)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString(); // returns: "48656C6C6F20776F726C64" for "Hello world"
        }

        public virtual string FromHexString(string hexString)
        {
            var bytes = new byte[hexString.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return Encoding.Unicode.GetString(bytes); // returns: "Hello world" for "48656C6C6F20776F726C64"
        }

       
            //https://stackoverflow.com/questions/24218632/how-to-unhex-mysql-binary-string-in-c-sharp-net
        //string hex = "E6B0B8";
        //var byteArr = System.Runtime.Remoting.Metadata.W3cXsd2001.SoapHexBinary.Parse(hex).Value;
        //var str = Encoding.UTF8.GetString(byteArr);
        //Console.WriteLine(str);
          
    }
}
