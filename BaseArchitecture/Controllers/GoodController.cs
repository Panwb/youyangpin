using Infrastructure.DomainModel;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
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




