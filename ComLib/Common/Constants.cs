namespace YYP.ComLib
{
    public static class GlobalConstants
    {
        public const string UserSessionKey = "LOGIN_INFORMATION";
        public const string AliyunSMSSignname = "优样品";
        public const string AliyunSMSRegisterTempCode = "SMS_117521192"; //注册业务短信模板
        public const string AliyunSMSReviewTempCode = "SMS_117511584"; //审核业务短信模板
    }



    public static class UserType
    {
        public const string System = "系统管理员";
        public const string Admin = "管理员用户";
        public const string Business = "商家用户";
        public const string StudioHost = "主播用户";

    }
}