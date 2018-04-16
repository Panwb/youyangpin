using YYP.ComLib;
using YYP.Entities;
using YYP.Services;
using System.Web.Http;
using YYP.Dto;
using System.Web;

namespace WebAPI.Controllers
{
    //主播用户管理
    public class StudioHostController : ApiController
    {
        private readonly IStudioHostService _studioHostService;

        public StudioHostController(IStudioHostService studioHostService)
        {
            _studioHostService = studioHostService;
        }

        [HttpPost]
        public StudioHostServiceResult Register([FromUri]RegisterDto dto)
        {
            var session = HttpContext.Current.Session;
            if (session == null || dto.IdentifyCode != (string)session[SessionKey.ImageIdentifyCode])
            {
                var result = new StudioHostServiceResult();
                result.RuleViolations.Add(new Infrastructure.DomainModel.RuleViolation("identifyCode", "验证码输入错误"));
                return result;
            }
            if (session == null || dto.SmsIdentifyCode != (string)session[SessionKey.SmsIdentifyCode])
            {
                var result = new StudioHostServiceResult();
                result.RuleViolations.Add(new Infrastructure.DomainModel.RuleViolation("identifyCode", "短信验证码输入错误"));
                return result;
            }

            return _studioHostService.Register(dto);
        }
    }
}
