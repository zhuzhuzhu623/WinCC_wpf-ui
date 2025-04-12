using CommonModels.SystemEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinCC.Bll.BllService
{
    public class DialogSnack
    {
        public static event Delegates.LogWriteEventHandle DialogSnackbar;

        public static void View(string content, EmLogLevel logLevel, Exception exception = null)
        {
            DialogSnackbar?.Invoke(null, LogEventArgs.GetLogEventArgs(content, logLevel, exception));
        }

    }
}
