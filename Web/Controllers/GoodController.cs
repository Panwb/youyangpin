using System;
using System.Collections.Generic;
using System.Web.Http;
using YYP.Dto;
using YYP.Services;
using YYP.Web;

namespace YYP.Controllers
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
        public Object Search(string goodsName, string verticalFieldCode, string activityType, int? sales, decimal? lowDailyPrice, decimal? highDailyPrice, decimal? commissionRatio, int? pageIndex, int itemsPerPage, string sortField, string sort)
        {
            var recordCount = 0;
            var goods = _goodService.GetPagedGood(goodsName, verticalFieldCode, activityType, sales, lowDailyPrice, highDailyPrice, commissionRatio, pageIndex, itemsPerPage, sortField, sort, out recordCount);

            return new { Goods = goods, RecordCount = recordCount };
        }

        [HttpGet]
        public IEnumerable<GoodStatistic> GetStatistics()
        {
            return _goodService.GetStatistics();
        }

        [Authorization]
        [HttpGet]
        public GoodDetailDto GetDetail(string goodsId)
        {
            return _goodService.GetDetail(goodsId);
        }

        [HttpGet]
        public IEnumerable<string> GetActivityTypes()
        {
            return _goodService.GetActivityTypes();
        }
    }
}




