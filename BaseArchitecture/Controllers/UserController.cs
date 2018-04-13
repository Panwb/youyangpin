using System;
using Architecture.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.Entities;
using IdentityServer4.Events;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Http;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IDatabaseFactory _databaseFactory;
        private readonly ILogger _logger;
        private readonly IEventService _events;

        public UserController(IDatabaseFactory databaseFactory,
            ILogger<UserController> logger,
            IEventService events)
        {
            _databaseFactory = databaseFactory;
            _logger = logger;
            _events = events;
        }

        [AllowAnonymous]
        [HttpPost]
        public async void Login([FromBody]string accountName, [FromBody]string password)
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

            //if (user != null)
            //{
            //    ////用户标识
            //    //var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            //    //identity.AddClaim(new Claim(ClaimTypes.Sid, "userName"));
            //    //identity.AddClaim(new Claim(ClaimTypes.Name, "Name"));
            //    //identity.AddClaim(new Claim(ClaimTypes.Role, "Role"));
            //    //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            //    var identityServer = await DiscoveryClient.GetAsync("http://localhost:61106"); //discover the IdentityServer
            //    if (identityServer.IsError)
            //    {
            //        return null;
            //    }

            //    //Get the token
            //    var tokenClient = new TokenClient(identityServer.TokenEndpoint, "Client1", "secret");
            //    var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");
            //    HttpClient client = new HttpClient();
            //    client.SetBearerToken(tokenResponse.AccessToken);
            //    return tokenResponse;
            //}
            //else
            //{
            //    HttpContext.Response.StatusCode = 401; //Unauthorized
            //    return null;
            //}
            await _events.RaiseAsync(new UserLoginSuccessEvent("user.Username", "user.SubjectId", "user.Username"));

            // only set explicit expiration here if user chooses "remember me". 
            // otherwise we rely upon expiration configured in cookie middleware.
            AuthenticationProperties props = null;

            props = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.Add(TimeSpan.FromDays(30))
            };

            // issue authentication cookie with subject ID and username
            await HttpContext.SignInAsync("user.SubjectId", "user.Username", props);

        }

        //[HttpDelete]
        //public void Logout()
        //{
        //    HttpContext.Session.Set(GlobalConstants.UserSessionKey, null);
        //}
        [HttpDelete]
        public async void Logout()
        {
            await HttpContext.SignOutAsync("Cookies");
            await HttpContext.SignOutAsync("oidc");
        }
    }
}
