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

        [HttpGet]
        public JsonResult GetPagedGood(string goodsName, string verticalFieldCode, string activityType, int sales, decimal highDailyPrice, decimal lowDailyPrice, decimal commissionRatio, int? pageIndex, int itemsPerPage, string sortField, string sort)
        {
            var recordCount = 0;
            var goods = _goodService.GetPagedGood(goodsName, verticalFieldCode, activityType, sales, highDailyPrice, lowDailyPrice, commissionRatio, pageIndex, itemsPerPage, sortField, sort, out recordCount);

            return Json(new { Goods = goods, RecordCount = recordCount });
        }
    }
}




