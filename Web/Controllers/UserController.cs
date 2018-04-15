using YYP.ComLib;
using Infrastructure.Helper;
using YYP.Services;
using YYP.ComLib.Services;
using System;
using System.Web.Http;
using System.Web;
using System.Web.Security;
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

        public UserServiceResult Login(string accountName, string password)
        {
            ////检查用户信息
            var userResult = _userService.GetUser(accountName, password);
            if (!userResult.HasViolation && userResult.User != null)
            {
                //记录Session
                //HttpContext.Current.Session.Set(GlobalConstants.UserSessionKey, ByteConvertHelper.Object2Bytes(userResult.User));
                FormsAuthentication.SetAuthCookie(userResult.User.Account, true);
            }

            return userResult;
        }

        [HttpGet]
        public SendSmsServiceResult SendSms(string telphone)
        {
            string identifyingCode = new Random().Next(100000, 999999).ToString();//验证码
            var result = _sendSmsService.SendMessage("{'code':'" + identifyingCode + "'}", telphone, telphone, GlobalConstants.AliyunSMSRegisterTempCode, GlobalConstants.AliyunSMSSignname);
            return result;
        }

        [Authorization]
        [HttpDelete]
        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}
