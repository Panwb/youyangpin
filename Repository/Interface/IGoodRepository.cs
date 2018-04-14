using System.Data;
using System.Collections.Generic;
using Infrastructure.Repository;
using YYP.Entities;

namespace YYP.Repository
{
    public interface IGoodRepository : IRepository<Good>
	{
        IEnumerable<Good> GetPagedGood(string goodsName, string verticalFieldCode, string activityType, int sales, decimal highDailyPrice, decimal lowDailyPrice, decimal commissionRatio
                                       , int? pageIndex
                                       , int itemsPerPage
                                       , string sortField
                                       , string sort
                                       , out int recordCount);


    }
}
