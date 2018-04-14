using System.Collections.Generic;
using Infrastructure.Services;
using YYP.Entities;

namespace YYP.Services
{
    public interface IGoodService : IService<Good>
	{
        IEnumerable<Good> GetPagedGood(string goodsName, string verticalFieldCode, string activityType, int sales, decimal highDailyPrice, decimal lowDailyPrice, decimal commissionRatio
                                       , int? pageIndex
                                       , int itemsPerPage
                                       , string sortField
                                       , string sort
                                       , out int recordCount);
	}
}

