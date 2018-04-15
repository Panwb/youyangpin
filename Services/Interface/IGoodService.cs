using System.Collections.Generic;
using Infrastructure.Services;
using YYP.Dto;
using YYP.Entities;

namespace YYP.Services
{
    public interface IGoodService : IService<Good>
	{
        IEnumerable<GoodStatistic> GetStatistics();

        IEnumerable<Good> GetPagedGood(string goodsName, string verticalFieldCode, string activityType, int? sales, decimal? lowDailyPrice, decimal? highDailyPrice, decimal? commissionRatio
                                       , int? pageIndex
                                       , int itemsPerPage
                                       , string sortField
                                       , string sort
                                       , out int recordCount);
	}
}

