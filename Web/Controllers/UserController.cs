using YYP.ComLib;
using YYP.Services;
using YYP.ComLib.Services;
using System;
using System.Web.Http;
using System.Web;
using YYP.Web;
using Infrastructure.DomainModel;

namespace YYP.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        private readonly ISendSmsService _sendSmsService;
        private readonly IWorkContext _workContext;

        public UserController(IUserService userService, ISendSmsService sendSmsService, IWorkContext workContext)
        {
            _userService = userService;
            _sendSmsService = sendSmsService;
            _workContext = workContext;
        }

        [HttpGet]
        public UserServiceResult Login(string accountName, string password, string identifyCode)
        {
            var session = HttpContext.Current.Session;
            var imageIdentifyCode = (string)session[SessionKey.ImageIdentifyCode];
            if (imageIdentifyCode == null || identifyCode != imageIdentifyCode)
            {
                var result = new UserServiceResult();
                result.RuleViolations.Add(new RuleViolation("identifyCode", "验证码输入错误"));
                return result;
            }

            //检查用户信息
            var userResult = _userService.GetUser(accountName, password);
            if (!userResult.HasViolation && userResult.User != null)
            {
                //记录Session
                HttpContext.Current.Session[SessionKey.LoginUser] = userResult.User;
            }
            else
            {
                var result = new UserServiceResult();
                result.RuleViolations.Add(new RuleViolation("", "用户名或密码不正确"));
                return result;
            }

            if (!userResult.HasViolation) //登陆成功，使原验证码无效
            {
                session[SessionKey.ImageIdentifyCode] = null;
            }

            return userResult;
        }

        [HttpGet]
        public SendSmsServiceResult SendSms(string telphone)
        {
            string identifyCode = new Random().Next(100000, 999999).ToString();//验证码
            HttpContext.Current.Session[SessionKey.SmsIdentifyCode] = identifyCode;
            var result = _sendSmsService.SendMessage("{'code':'" + identifyCode + "'}", telphone, telphone, GlobalConstants.AliyunSMSRegisterTempCode, GlobalConstants.AliyunSMSSignname);
            return result;
        }

        [HttpGet]
        public SendSmsServiceResult ValidateSmsIdentifyCode(string smsIdentifyCode)
        {
            var result = new SendSmsServiceResult();
            var session = HttpContext.Current.Session;
            if (session == null || smsIdentifyCode != (string)session[SessionKey.SmsIdentifyCode])
            {
                result.RuleViolations.Add(new RuleViolation("identifyCode", "短信验证码输入错误"));
                return result;
            }

            return result;
        }

        [HttpGet]
        public UserServiceResult RetrievePassword(string telphone, string imageIdentifyCode)
        {
            var result = new UserServiceResult();
            var session = HttpContext.Current.Session;
            if (session == null || imageIdentifyCode != (string)session[SessionKey.ImageIdentifyCode])
            {
                result.RuleViolations.Add(new RuleViolation("identifyCode", "验证码输入错误"));
                return result;
            }
            var userResult = _userService.GetByAccount(telphone);
            if (userResult.HasViolation)
            {
                return userResult;
            }
            session[SessionKey.RetrievePasswordTelphone] = telphone;
            session[SessionKey.ImageIdentifyCode] = null;
            return result;
        }

        [HttpPut]
        public UserServiceResult ResetPassword(string newPassword)
        {
            var telphone = (string)HttpContext.Current.Session[SessionKey.RetrievePasswordTelphone];
            if(telphone == null) {
                var userResult = new UserServiceResult();
                userResult.RuleViolations.Add(new RuleViolation("telphone", "请在之前步骤中输入手机号"));
                return userResult;
            }

            return _userService.ResetPassword(telphone, newPassword);
        }

        [Authorization]
        [HttpPut]
        public UserServiceResult ChangePassword(string oldPassword, string newPassword)
        {
            var user = _workContext.CurrentUser;
            return _userService.ChangePassword(user.GUID, oldPassword, newPassword);
        }

        [Authorization]
        [HttpDelete]
        public void Logout()
        {
            HttpContext.Current.Session.Clear();
        }
    }
}
