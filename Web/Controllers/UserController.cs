using YYP.ComLib;
using YYP.Services;
using YYP.ComLib.Services;
using System;
using System.Web.Http;
using System.Web;
using YYP.Web;

namespace WebAPI.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        private readonly ISendSmsService _sendSmsService;

        public UserController(IUserService userService, ISendSmsService sendSmsService)
        {
            _userService = userService;
            _sendSmsService = sendSmsService;
        }

        [HttpGet]
        public UserServiceResult Login(string accountName, string password, string identifyCode)
        {
            var session = HttpContext.Current.Session;
            if (session == null || identifyCode != (string)session[SessionKey.ImageIdentifyCode])
            {
                var result = new UserServiceResult();
                result.RuleViolations.Add(new Infrastructure.DomainModel.RuleViolation("identifyCode", "验证码输入错误"));
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
                result.RuleViolations.Add(new Infrastructure.DomainModel.RuleViolation("", "用户名或密码不正确"));
                return result;
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

        [HttpPut]
        public UserServiceResult ChangePassword(string oldPassword, string newPassword)
        {
            return _userService.ChangePassword(oldPassword, newPassword);
        }

        [Authorization]
        [HttpDelete]
        public void Logout()
        {
            HttpContext.Current.Session.Clear();
        }
    }
}
