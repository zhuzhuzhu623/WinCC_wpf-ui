using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinCC.Models.SystemEnums
{
    public enum EmLogLevel
    {
        /// <summary>
        /// 最常见的记录信息，一般用于普通输出
        /// </summary>
        TRACE = 0,
        /// <summary>
        /// 记录信息，，一般用来调试程序
        /// </summary>
        DEBUG,
        /// <summary>
        /// 信息类型的消息
        /// </summary>
        INFO,
        /// <summary>
        /// 警告信息
        /// </summary>
        WARN,
        /// <summary>
        /// 错误信息
        /// </summary>
        ERROR,
    }
}

