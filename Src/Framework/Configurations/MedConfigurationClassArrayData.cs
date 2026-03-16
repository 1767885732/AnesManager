using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Wis.Anes.Framework.Configurations
{
    /// <summary>
    /// 通过配置创建一组类
    /// </summary>
    public class MedConfigurationClassArrayData: ConfigurationSection
    {

        public MedConfigurationClassArrayData() { }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="assemblyName">程序集名称</param>
        /// <param name="classNames">类名称集合</param>
        public MedConfigurationClassArrayData(string assemblyName, string[] classNames)
        {
            AssemblyName = assemblyName;
            ClassNames = string.Join(",",classNames);
        }
        /// <summary>
        /// 程序集名称
        /// </summary>
        [ConfigurationProperty("assemblyName")]
        public string AssemblyName
        {
            get { return (string)this["assemblyName"]; }
            set { this["assemblyName"] = value; }
        }

        /// <summary>
        /// 类名称集合-多个类用逗号分开
        /// </summary>
        [ConfigurationProperty("classNames")]
        public string ClassNames
        {
            get { return (string)this["classNames"]; }
            set { this["classNames"] = value; }
        }
        string[] _items;
        /// <summary>
        /// 类名称集合
        /// </summary>
        public string[] Items
        {
            get
            {
                if (_items == null)
                {
                    _items = ClassNames.Split(',');
                }
                return _items;
            }
        }

    }

}
