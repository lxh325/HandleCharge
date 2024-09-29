using log4net;

namespace DAL.Helper
{
    public class LogHelper
    {
        private static readonly ILog logComm = LogManager.GetLogger("LogHelper");//获取一个日志记录器
        static LogHelper()
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo("App.config"));

        }
        private static void WriteLog(string msg, Action<object> action)
        {
            action(msg);
        }

        public static void WriteError(string msg)
        {
            WriteLog(msg, logComm.Error);
        }
        public static void WriteInfo(string msg)
        {
            WriteLog(msg, logComm.Info);
        }
        public static void WriteWarn(string msg)
        {
            WriteLog(msg, logComm.Warn);
        }
    }
}
