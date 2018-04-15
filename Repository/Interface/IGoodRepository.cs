using System.Data;
using System.Collections.Generic;
using Infrastructure.Repository;
using YYP.Entities;
using YYP.Dto;

namespace YYP.Repository
{
    public interface IGoodRepository : IRepository<Good>
	{
        IEnumerable<GoodStatistic> GetStatistics(string checkStatus);

        IEnumerable<Good> GetPagedGood(string goodsName, string verticalFieldCode, string activityType, int? sales, decimal? lowDailyPrice, decimal? highDailyPrice, decimal? commissionRatio, string checkStatus
                                       , int? pageIndex
                                       , int itemsPerPage
                                       , string sortField
                                       , string sort
                                       , out int recordCount);


    }
}
