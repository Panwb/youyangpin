using Microsoft.AspNetCore.Mvc;
using YYP.ComLib;
using Infrastructure.Helper;
using YYP.Entities;
using YYP.Services;
using YYP.ComLib.Services;
using System;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ISendSmsService _sendSmsService;

        public UserController(IUserService userService, ISendSmsService sendSmsService)
        {
            _userService = userService;
            _sendSmsService = sendSmsService;
        }

        [HttpPost]
        public UserServiceResult Login(string accountName, string password)
        {
            ////检查用户信息
            var userResult = _userService.GetUser(accountName, password);
            if (!userResult.HasViolation && userResult.User != null)
            {
                //记录Session
                HttpContext.Session.Set(GlobalConstants.UserSessionKey, ByteConvertHelper.Object2Bytes(userResult.User));
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

        [HttpDelete]
        public void Logout()
        {
            HttpContext.Session.Remove(GlobalConstants.UserSessionKey);
            HttpContext.Session.Clear();
        }
    }
}
