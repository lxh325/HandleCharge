using System.Configuration;
using System.Text.RegularExpressions;

namespace DAL.Helper
{
    public class ConfigHelper
    {
        public static readonly string StartTaskCode = GetStringConfigValue("StartTaskCode");//起始任务编码，前14位为年月日时分秒。从当前起始任务编码开始扫库
        public static readonly int pollingTime = GetInt32ConfigValue("pollingTime");//处理轮询间隔时间

        public static readonly string DBType = GetStringConfigValue("DBType");
        public static readonly string MainConnectionString = GetStringConfigValue("MainConnectionString");

        #region 通用方法
        private static string GetStringConfigValue(string keyName)
        {
            try
            {
                return ConfigurationManager.AppSettings[keyName].ToString();
            }
            catch
            {
                LogHelper.WriteError("ConfigHelper/GetStringConfigValue():【" + keyName + "】Config配置有误");
                return "";
            }
        }
        private static bool GetBoolConfigValue(string keyName)
        {
            try
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings[keyName]);
            }
            catch
            {
                LogHelper.WriteError("ConfigHelper/GetBoolConfigValue():【\"+ keyName + \"】Config配置有误：");
                return false;
            }
        }
        private static int GetInt32ConfigValue(string keyName)
        {
            Regex regex = new Regex("^\\d*$");
            string tempStr;
            try
            {
                tempStr = ConfigurationManager.AppSettings[keyName].ToString();
                if (regex.IsMatch(tempStr))
                {
                    return Convert.ToInt32(tempStr);
                }

                return 0;
            }
            catch
            {
                LogHelper.WriteError("ConfigHelper/GetInt32ConfigValue():【\"+ keyName + \"】Config配置有误");
                return 0;
            }
        }
        #endregion
    }
}
