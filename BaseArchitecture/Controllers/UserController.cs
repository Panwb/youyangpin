using Microsoft.AspNetCore.Mvc;
using YYP.ComLib;
using Infrastructure.Helper;
using YYP.Entities;
using YYP.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public UserServiceResult Register(User user)
        {
            return _userService.Register(user);
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

        [HttpDelete]
        public void Logout()
        {
            HttpContext.Session.Remove(GlobalConstants.UserSessionKey);
            HttpContext.Session.Clear();
        }
    }
}
