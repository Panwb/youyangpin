using YYP.ComLib;
using YYP.Entities;
using YYP.Services;
using System.Web.Http;
using YYP.Dto;

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
            //TODO: 同时插入主播表和用户表
            return _studioHostService.Register(dto);
        }
    }
}
