using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Collections;
using System.IO;

namespace Wis.Anes.ServiceProxies
{
    public class DataBaseConfigHelperProxy
    {

        /// <summary>
        /// 获取本机上配置好的oracle服务名
        /// </summary>
        /// <returns></returns>
        public static string[] GetOracleTnsNames()
        {
            try
            {
                // 查询注册表，获取oracle服务文件路径
                RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("ORACLE");
                if (key != null)
                {
                    string[] subKeys = key.GetSubKeyNames();
                    if (subKeys != null)
                    {
                        string home = (string)key.GetValue("ORACLE_HOME");
                        if (string.IsNullOrEmpty(home))
                        {
                            foreach (string subKey in subKeys)
                            {
                                RegistryKey subRegistryKey = key.OpenSubKey(subKey);
                                if (subRegistryKey != null)
                                {
                                    home = (string)subRegistryKey.GetValue("ORACLE_HOME");
                                    if (!string.IsNullOrEmpty(home))
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(home))
                        {
                            string file = home + @"\network\ADMIN\tnsnames.ora";

                            // 解析文件
                            string line;
                            ArrayList arr = new ArrayList();
                            StreamReader sr = new StreamReader(file);
                            while ((line = sr.ReadLine()) != null)
                            {
                                line = line.Trim();
                                if (line != "")
                                {
                                    char c = line[0];
                                    if (c >= 'A' && c <= 'z')
                                        arr.Add(line.Substring(0, line.IndexOf(' ')));
                                }
                            }
                            sr.Close();

                            // 返回字符串数组
                            return (string[])arr.ToArray(typeof(string));
                        }
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
