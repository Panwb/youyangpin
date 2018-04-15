using YYP.ComLib;
using YYP.Entities;
using YYP.Services;
using System.Web.Http;

namespace WebAPI.Controllers
{
    //主播用户管理
    public class StudioHostController : ApiController
    {
        private readonly IUserService _userService;

        public StudioHostController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public UserServiceResult Register(string telphone, string pwd)
        {
            var user = new User() {Account = telphone, TelPhone = telphone, Pwd = pwd, UserType = UserType.StudioHost};
            return _userService.Register(user);
        }
    }
}
