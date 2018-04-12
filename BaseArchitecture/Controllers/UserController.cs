using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Architecture.Repository;
using Infrastructure.Helper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.Common;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Authorize]
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

        [AllowAnonymous]
        [HttpPost]
        public async void LoginAsync([FromBody]string accountName, [FromBody]string password)
        {
            ////检查用户信息
            User user = new User();
            ////var user = _userAppService.CheckUser(model.UserName, model.Password);
            //if (user != null)
            //{
            //    //记录Session
            //    HttpContext.Session.Set(GlobalConstants.UserSessionKey, ByteConvertHelper.Object2Bytes(user));
            //}
            //return null;

            if (user != null)
            {
                //用户标识
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Sid, "userName"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Name"));
                identity.AddClaim(new Claim(ClaimTypes.Role, "Role"));
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            }
            else
            {
                HttpContext.Response.StatusCode = 401; //Unauthorized
            }
        }

        //[HttpDelete]
        //public void Logout()
        //{
        //    HttpContext.Session.Set(GlobalConstants.UserSessionKey, null);
        //}
        [HttpDelete]
        public async void Logout()
        {
            await HttpContext.SignOutAsync("Cookie");
        }
    }
}
