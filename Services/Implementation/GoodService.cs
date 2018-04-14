using System.Collections.Generic;
using Infrastructure.Services;
using Microsoft.Extensions.Logging;
using YYP.Entities;
using YYP.Repository;

namespace YYP.Services
{
	public class GoodService : ServiceBase<Good>,IGoodService
	{
		private readonly ILogger _logger;
		private readonly IGoodRepository _goodRepository;
		
		public GoodService(IGoodRepository goodRepository, ILogger<GoodService> logger)
		    : base(logger)
        {
			this._goodRepository = goodRepository;
			this._logger = logger;
		}

        public IEnumerable<Good> GetPagedGood(string goodsName, string verticalFieldCode, string activityType, int sales, decimal highDailyPrice, decimal lowDailyPrice, decimal commissionRatio, int? pageIndex, int itemsPerPage, string sortField, string sort, out int recordCount)
        {
            return _goodRepository.GetPagedGood(goodsName, verticalFieldCode, activityType, sales, highDailyPrice, lowDailyPrice, commissionRatio,
                pageIndex, itemsPerPage, sortField, sort, out recordCount);
        }
    }
}

