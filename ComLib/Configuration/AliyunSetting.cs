using System.Configuration;

namespace YYP.ComLib.Configuration
{
    public static class AliyunSetting
    {
        public static string KeyId
        {
            get
            {
                return ConfigurationManager.AppSettings["Aliyun_KeyId"];
            }
        }
        public static string KeySecret
        {
            get
            {
                return ConfigurationManager.AppSettings["Aliyun_KeySecret"];
            }
        }
        public static string Product
        {
            get
            {
                return ConfigurationManager.AppSettings["Aliyun_Product"];
            }
        }
        public static string Domain
        {
            get
            {
                return ConfigurationManager.AppSettings["Aliyun_Domain"];
            }
        }
        public static string RegionIdForPop
        {
            get
            {
                return ConfigurationManager.AppSettings["Aliyun_RegionIdForPop"];
            }
        }
    }
}
