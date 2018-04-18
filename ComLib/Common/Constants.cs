namespace YYP.ComLib
{
    public static class GlobalConstants
    {
        public const string AliyunSMSSignname = "优样品";
        public const string AliyunSMSRegisterTempCode = "SMS_117521192"; //注册业务短信模板
        public const string AliyunSMSReviewTempCode = "SMS_117511584"; //审核业务短信模板
    }

    public static class SessionKey
    {
        public const string LoginUser = "LoginUser";
        public const string ImageIdentifyCode = "ImageIdentifyCode"; //图片验证码SessionKey
        public const string SmsIdentifyCode = "SmsIdentifyCode"; //短信验证码SessionKey
        public const string RetrievePasswordTelphone = "RetrievePasswordTelphone"; //找回密码手机号
    }

    public static class CheckStatus
    {
        public const string Pass = "已审核";
        public const string Waiting = "待审核";
        public const string Failed = "审核不通过";
    }

    public static class UserType
    {
        public const string System = "系统管理员";
        public const string Admin = "管理员用户";
        public const string Business = "商家用户";
        public const string StudioHost = "主播用户";

    }
}