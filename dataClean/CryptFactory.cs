using System;
using System.Security.Cryptography;
using System.Text;

namespace dataClean
{
    public class CryptFactory
    {

        public static String ComputeHash(Cryptor.CryptBuilder builder)
        {
            string hash = string.Empty;
            switch (builder.m_algorithm)
            {

                case "md5(lower 16)":
                    hash = ComputeMd5_16Char(builder.m_plainText);
                    break;

                case "md5(upper 16)":
                    hash = ComputeMd5_16Char(builder.m_plainText).ToUpper();
                    break;

                case "md5(lower 32)":
                    hash = ComputeMd5_32Char(builder.m_plainText).ToLower();
                    break;

                case "md5(upper 32)":
                    hash = ComputeMd5_32Char(builder.m_plainText);
                    break;
                case "sha256(lower)":
                    hash = ComputeSha256Hash(builder.m_plainText);
                    break;

                case "sha256(upper)":
                    hash = ComputeSha256Hash(builder.m_plainText).ToUpper();
                    break;

            }
            return new Cryptor(builder).setHash(hash).Hash;
        }


        //md5(16)
        /// <summary>
        /// MD5 16位加密 加密后密码为小写
        /// </summary>
        /// <param name="ConvertString"></param>
        /// <returns></returns>
        public static string ComputeMd5_16Char(string ConvertString)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(ConvertString)), 4, 8);
            t2 = t2.Replace("-", "");

            t2 = t2.ToLower();

            return t2;
        }

        /// <summary>
        /// MD5　32位加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ComputeMd5_32Char(string str)
        {
            string cl = str;
            string pwd = "";
            MD5 md5 = MD5.Create();//实例化一个md5对像
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 

                pwd = pwd + s[i].ToString("X");

            }
            return pwd;
        }

        /// <summary>
        /// Computes the sha256 hash.
        /// </summary>
        /// <returns>The sha256 hash.</returns>
        /// <param name="plainText">Plain text.</param>
        public static string ComputeSha256Hash(string plainText)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(plainText));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}