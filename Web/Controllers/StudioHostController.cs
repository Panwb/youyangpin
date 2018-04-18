using YYP.ComLib;
using YYP.Entities;
using YYP.Services;
using System.Web.Http;
using YYP.Dto;
using System.Web;
using YYP.ComLib.Services;
using Infrastructure.DomainModel;
using YYP.Web;

namespace WebAPI.Controllers
{
    //主播用户管理
    public class StudioHostController : ApiController
    {
        private readonly IStudioHostService _studioHostService;
        private readonly IWorkContext _workContext;

        public StudioHostController(IStudioHostService studioHostService, IWorkContext workContext)
        {
            _studioHostService = studioHostService;
            _workContext = workContext;
        }

        [HttpPost]
        public StudioHostServiceResult Register([FromUri]RegisterDto dto)
        {
            var result = new StudioHostServiceResult();
            var session = HttpContext.Current.Session;
            var imageIdentifyCode = (string)session[SessionKey.ImageIdentifyCode];
            var smsIdentifyCode = (string)session[SessionKey.SmsIdentifyCode];
            if (imageIdentifyCode == null || dto.ImageIdentifyCode != imageIdentifyCode)
            {
                result.RuleViolations.Add(new RuleViolation("identifyCode", "验证码输入错误"));
                return result;
            }
            if (smsIdentifyCode == null || dto.SmsIdentifyCode != smsIdentifyCode)
            {
                result.RuleViolations.Add(new RuleViolation("identifyCode", "短信验证码输入错误"));
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

        [Authorization]
        [HttpGet]
        public StudioHostServiceResult GetDetail()
        {
            var user = _workContext.CurrentUser;

            return _studioHostService.GetById(user.GUID);
        }

        [Authorization]
        [HttpPost]
        public StudioHostServiceResult Update([FromUri]StudioHostDto dto)
        {
            return _studioHostService.Update(dto);
        }
    }
}
