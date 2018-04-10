using System.Collections.Generic;
using Architecture.Repository;
using Infrastructure.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.Common;
using WebAPI.Entities;
using WebAPI.Services.ServiceResult;

namespace WebAPI.Controllers
{
    [Route("api/user/[controller]")]
    public class UserController : Controller
    {
        private readonly IDatabaseFactory _databaseFactory;
        private readonly ILogger _logger;

        public UserController(IDatabaseFactory databaseFactory,
            ILogger<ValuesController> logger)
        {
            _databaseFactory = databaseFactory;
            _logger = logger;
        }

        [HttpPost]
        public UserServiceResult Login([FromBody]string accountName, [FromBody]string password)
        {
            //检查用户信息
            User user = new User();
            //var user = _userAppService.CheckUser(model.UserName, model.Password);
            if (user != null)
            {
                //记录Session
                HttpContext.Session.Set(GlobalConstants.UserSessionKey, ByteConvertHelper.Object2Bytes(user));
            }
            return null;
        }

        [HttpDelete]
        public void Logout()
        {
            HttpContext.Session.Set(GlobalConstants.UserSessionKey, null);
        }
    }
}
