using CommonModels.SystemEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinCC.Bll.BllService
{
    public class Logger
    {
        #region 事件

        public static event Delegates.LogWriteEventHandle LogWrite;

        public static void Log(string content, EmLogLevel logLevel, Exception exception = null)
        {
            LogWrite?.Invoke(null, LogEventArgs.GetLogEventArgs(content, logLevel, exception));
        }

        #endregion
    }
    public class Delegates
    {
        public delegate void LogWriteEventHandle(Object sender, LogEventArgs args);

        public delegate void DialogSnackbarEventHandle(Object sender, LogEventArgs args);

    }
    public class LogEventArgs : EventArgs
    {
        public string Content { get; set; }
        public EmLogLevel LogLevel { get; set; }
        public Exception Exception { get; set; }
        public LogEventArgs() : base()
        {

        }
        public static LogEventArgs GetLogEventArgs(string content, EmLogLevel logLevel, Exception exception = null)
        {
            return new LogEventArgs()
            {
                Content = content,
                LogLevel = logLevel,
                Exception = exception
            };
        }
    }
}
