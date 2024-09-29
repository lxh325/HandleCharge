using Nancy.Json;
using System.Text;

namespace DAL.Helper
{
    public class ObjectToJson
    {
        /// <summary>
        /// 对象转字节发送流
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] GetObjectToBytes(object data)
        {
            byte[]? buffer = null;
            try
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                buffer = Encoding.UTF8.GetBytes(jss.Serialize(data));
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("ObjectToJson/GetObjectToBytes:转字节流失败，" + ex.Message);
            }
            return buffer;
        }

        /// <summary>
        /// 对象转json
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string GetObjectToJson(object data)
        {
            string str = "";
            try
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                str = jss.Serialize(data);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("ObjectToJson/GetObjectToJson:转JSON失败，" + ex.Message);
            }
            return str;
        }
        public static T CopyObjectProperty<T>(T tSource, string jsonstr) where T : class
        {
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                tSource = serializer.Deserialize<T>(jsonstr);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("ObjectToJson/CopyObjectProperty:转实体失败，" + ex.Message);
            }
            return tSource;
        }
    }
}
