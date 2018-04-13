using Architecture.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.Entities;
using Microsoft.AspNetCore.Http;
using WebAPI.Common;
using Infrastructure.Helper;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IDatabaseFactory _databaseFactory;
        private readonly ILogger _logger;

        public UserController(IDatabaseFactory databaseFactory,
            ILogger<UserController> logger)
        {
            _databaseFactory = databaseFactory;
            _logger = logger;
        }

        [HttpPost]
        public void Login(string accountName, string password)
        {
            ////检查用户信息
            User user = new User();
            //var user = _userAppService.CheckUser(model.UserName, model.Password);
            if (user != null)
            {
                //记录Session
                HttpContext.Session.Set(GlobalConstants.UserSessionKey, ByteConvertHelper.Object2Bytes(user));
            }
        }

        [HttpDelete]
        public void Logout()
        {
            HttpContext.Session.Remove(GlobalConstants.UserSessionKey);
            HttpContext.Session.Clear();
        }
    }
}
