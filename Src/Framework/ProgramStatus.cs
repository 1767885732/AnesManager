using System;
using System.Collections.Generic;
using System.Text;

namespace Wis.Anes.Framework
{
    /// 程序状态
    /// </summary>
    public enum ProgramStatus
    {
        /// <summary>
        /// 无患者操作
        /// </summary>
        NoPatient,
        /// <summary>
        /// 选中患者操作
        /// </summary>
        SelectPatient,
        /// <summary>
        /// 麻醉单
        /// </summary>
        AnesthesiaRecord,
        /// <summary>
        /// 复苏单
        /// </summary>
        PACURecord,
        /// <summary>
        /// 体外循环报告单
        /// </summary>
        CPBReport,
    }
}
