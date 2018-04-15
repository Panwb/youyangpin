using System.Collections.Generic;
using Infrastructure.Services;
using YYP.Entities;
using YYP.Repository;

namespace YYP.Services
{
	public class GoodService : ServiceBase<Good>,IGoodService
	{
		private readonly IGoodRepository _goodRepository;
		
		public GoodService(IGoodRepository goodRepository)
        {
			this._goodRepository = goodRepository;
		}

        public IEnumerable<Good> GetPagedGood(string goodsName, string verticalFieldCode, string activityType, int sales, decimal lowDailyPrice, decimal highDailyPrice, decimal commissionRatio, int? pageIndex, int itemsPerPage, string sortField, string sort, out int recordCount)
        {
            return _goodRepository.GetPagedGood(goodsName, verticalFieldCode, activityType, sales, lowDailyPrice, highDailyPrice, commissionRatio,
                pageIndex, itemsPerPage, sortField, sort, out recordCount);
        }
    }
}

