using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace dataClean
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            //string str = "　 121　2 1　 ";
            //var sss = str.ToCharArray();
            //var len = str.Length;
            ////0xE38080
            ////0x20
            //int step = 0, start = -1, end = -1;
            //do
            //{
            //    var hex = (UInt32)(sss[step]);
            //    if (!(hex == 0x20 || hex == 0x3000))
            //    {
            //        start = step;
            //        step = 0;
            //        break;
            //    }
            //} while (step++ < len);

            //Array.Reverse(sss);

            //do
            //{
            //    var hex = (UInt32)(sss[step]);
            //    if (!(hex == 0x20 || hex == 0x3000))
            //    {
            //        end = len - step - 1;
            //        break;
            //    }
            //} while (step++ < len);
            //StringBuilder builder = new StringBuilder();
            //builder.Append(str.Substring(0,start));
            //for (int i = start; i < end - start; i++)
            //{
            //    char ch = sss[i];
            //    var hex = (UInt32)(ch);
            //    if (!(hex == 0x20 || hex == 0x3000))
            //    {
            //        builder.Append(ch);
            //    }
            //}
            //builder.Append(str.Substring(end));
            //Console.WriteLine(builder);
            //while ((UInt32)(sss[step++]) != 0x20 || (UInt32)(sss[step++]) != 0x3000)
            //{
            //    start = step;
            //    //if (start == -1)
            //    //{
            //    //    start = step;
            //    //    Array.Reverse(sss);
            //    //    step = 0;
            //    //}
            //    //else
            //    //{
            //    //    end = sss.Length - step;

            //    //}
            //    //if (step != -1 && end != -1) break;
            //}
            //System.Text.StringBuilder builder = new System.Text.StringBuilder();
            //builder.Append(str.Substring(0, start-1));
            //Console.WriteLine("left:{0},right:{1} #{2}#", start, end, str.Substring(start,len-end));
            //builder.Append(str.Substring(end));

            //Console.WriteLine(builder);

            //foreach (char ch in sss)
            //{
            //    //Console.WriteLine("{0} {1} {2}", ch, MySqlHexDecimalEncoding.hex(new string(new char[] { ch })), Convert.ToUInt32(ch));
            //    Console.WriteLine("{0},{1}",(UInt32)ch,(((UInt32)ch==0x20) ||((UInt32)ch==0x3000)));

            //}
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmDataClean());
        }
    }
}
