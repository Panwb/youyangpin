using System;
using System.Web.Http;
using YYP.Services;

namespace WebAPI.Controllers
{
    public class GoodController : ApiController
    {
        #region Construction
        
        private readonly IGoodService _goodService;
        
        public GoodController(IGoodService goodService)
        {
            this._goodService = goodService;
        }

        #endregion

        [HttpGet]
        public Object GetPagedGood(string goodsName, string verticalFieldCode, string activityType, int sales, decimal lowDailyPrice, decimal highDailyPrice, decimal commissionRatio, int? pageIndex, int itemsPerPage, string sortField, string sort)
        {
            var recordCount = 0;
            var goods = _goodService.GetPagedGood(goodsName, verticalFieldCode, activityType, sales, lowDailyPrice, highDailyPrice, commissionRatio, pageIndex, itemsPerPage, sortField, sort, out recordCount);

            return new { Goods = goods, RecordCount = recordCount };
        }
    }
}




