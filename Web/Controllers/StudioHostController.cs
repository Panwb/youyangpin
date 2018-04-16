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
            var result = new StudioHostServiceResult();
            var session = HttpContext.Current.Session;
            if (session == null || dto.ImageIdentifyCode != (string)session[SessionKey.ImageIdentifyCode])
            {
                result.RuleViolations.Add(new Infrastructure.DomainModel.RuleViolation("identifyCode", "验证码输入错误"));
                return result;
            }
            if (session == null || dto.SmsIdentifyCode != (string)session[SessionKey.SmsIdentifyCode])
            {
                result.RuleViolations.Add(new Infrastructure.DomainModel.RuleViolation("identifyCode", "短信验证码输入错误"));
                return result;
            }

            result = _studioHostService.Register(dto);
            if (!result.HasViolation) //注册成功，使原验证码无效
            {
                session[SessionKey.ImageIdentifyCode] = null;
                session[SessionKey.SmsIdentifyCode] = null;
            }

            return result;
        }
    }
}
