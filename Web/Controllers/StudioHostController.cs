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
        public UserServiceResult Register(string telphone, string password)
        {
            var user = new User() {Account = telphone, TelPhone = telphone, Pwd = password, UserType = UserType.StudioHost};

            //TODO: 同时插入主播表和用户表
            return _userService.Register(user);
        }
    }
}
