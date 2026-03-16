using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Wis.Anes.Framework.Configurations;
using System.Data;
using Wis.Anes.Framework.Controls.Base;

namespace Wis.Anes.Utilities
{
    /// <summary>
    /// 类简单工厂
    /// </summary>
    /// <typeparam name="T">类类型</typeparam>
    class SimpleFactory<T>
    {
        /// <summary>
        /// 创建类
        /// </summary>
        /// <param name="accemblyName">程序集名称</param>
        /// <param name="className">类名称</param>
        /// <returns>类</returns>
        public static T CreateClass(string accemblyName, string className)
        {
            return (T)Assembly.Load(accemblyName).CreateInstance(className);
        }

        /// <summary>
        /// 创建一组类
        /// </summary>
        /// <param name="sessionKey">配置节</param>
        /// <returns>一组类</returns>
        public static List<T> CreateClasses(string sessionKey)
        {
            try
            {
                MedConfigurationClassArrayData classes = MedConfiguration.GetClassArray(sessionKey);
                List<T> klasses = new List<T>();
                foreach (string typeName in classes.Items)
                {
                    T x = CreateClass(classes.AssemblyName, typeName);
                    if (x != null)
                    {
                        klasses.Add(x);
                    }
                }
                return klasses;
            }
            catch
            {
                return new List<T>();
            }
        }

        /// <summary>
        /// 创建一组类
        /// </summary>
        /// <param name="sessionKey">配置节</param>
        /// <param name="patientRow">患者信息</param>
        /// <returns>一组类</returns>
        public static List<T> CreateClasses(string sessionKey, DataRow patientRow)
        {
            List<T> klasses = CreateClasses(sessionKey);
            ForeachSetPatientRow(patientRow, klasses);
            return klasses;
        }

        private static void ForeachSetPatientRow(DataRow patientRow, List<T> klasses)
        {
            foreach (T klass in klasses)
            {
                if (klass is BaseControl)
                {
                    (klass as BaseControl).PatientRow = patientRow;
                }
            }
        }

        /// <summary>
        /// 创建类
        /// </summary>
        /// <param name="patientRow">患者信息</param>
        /// <returns>类</returns>
        public static T CreateClass(DataRow patientRow)
        {
            string hospitalAbbreviation = MedConfiguration.HospitalAbbreviation;
            string className = typeof(T).ToString();
            if (!string.IsNullOrEmpty(hospitalAbbreviation))
            {
                int index = className.LastIndexOf('.');
                if (index > -1)
                {
                    className = className.Substring(0, index) + "." + hospitalAbbreviation + className.Substring(index);
                }
                else
                {
                    className = hospitalAbbreviation + "." + className;
                }
            }
            T newClass = CreateClass("IcuApp", className);
            if (newClass is BaseControl)
            {
                (newClass as BaseControl).PatientRow = patientRow;
            }
            return newClass;
        }
    }
}
