using Infrastructure.DomainModel;
using Microsoft.AspNetCore.Mvc;
using YYP.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class GoodController : Controller
    {
        #region Construction
        
        private readonly IGoodService _goodService;
        
        public GoodController(IGoodService goodService)
        {
            this._goodService = goodService;
        }

        #endregion

    }
}




