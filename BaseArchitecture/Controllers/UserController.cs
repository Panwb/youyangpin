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
using WebAPI.Services;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityModel.Client;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
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

        [AllowAnonymous]
        [HttpPost]
        public async Task<TokenResponse> LoginAsync([FromBody]string accountName, [FromBody]string password)
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
                ////用户标识
                //var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                //identity.AddClaim(new Claim(ClaimTypes.Sid, "userName"));
                //identity.AddClaim(new Claim(ClaimTypes.Name, "Name"));
                //identity.AddClaim(new Claim(ClaimTypes.Role, "Role"));
                //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                var identityServer = await DiscoveryClient.GetAsync("http://localhost:61106"); //discover the IdentityServer
                if (identityServer.IsError)
                {
                    return null;
                }

                //Get the token
                var tokenClient = new TokenClient(identityServer.TokenEndpoint, "Client1", "secret");
                var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");
                return tokenResponse;
            }
            else
            {
                HttpContext.Response.StatusCode = 401; //Unauthorized
                return null;
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
