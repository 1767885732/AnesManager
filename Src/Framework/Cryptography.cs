using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wis.Anes.Framework
{
    /// <summary>
    /// 一个使用UTF8和Base64String的简单加密/解密类
    /// </summary>
    public class Cryptography
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="source">要加密的字符串</param>
        /// <returns></returns>
        public static string Encrypt(string source)
        {
            if (IsEncrypted(source))
                return source;
            byte[] bytes = UTF8Encoding.Default.GetBytes(source);
            return string.Format("{0}{1}{2}", "-START-", Convert.ToBase64String(bytes), "-END-").Trim();
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="source">要解密的字符串</param>
        /// <returns></returns>
        public static string Decrypt(string source)
        {
            if (!IsEncrypted(source))
                return source;
            source = source.Replace("-START-", string.Empty).Replace("-END-", string.Empty);
            var bytes = Convert.FromBase64String(source);
            return UTF8Encoding.Default.GetString(bytes);
        }
        /// <summary>
        /// 判断字符串是否已经被ICIS.Docare.Common.Cryptography加密
        /// </summary>
        /// <param name="source">字符串</param>
        /// <returns></returns>
        public static bool IsEncrypted(string source)
        {
            if (source.StartsWith("-START-") && source.EndsWith("-END-"))
                return true;
            return false;
        }
    }
}
