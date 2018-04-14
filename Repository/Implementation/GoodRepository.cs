using System.Collections.Generic;
using System.Data;
using Dapper;
using Infrastructure.Repository;
using YYP.Entities;

namespace YYP.Repository
{
    /// <summary>
    /// Summary description for GoodRepository.
    /// </summary>
    public class GoodRepository : RepositoryBase<Good>, IGoodRepository
	{
	    public GoodRepository(IDatabaseFactory db) : base(db)
        {
        }

        public IEnumerable<Good> GetPagedGood(string goodsName, string verticalFieldCode, string activityType, int sales, decimal highDailyPrice, decimal lowDailyPrice, decimal commissionRatio
                                       , int? pageIndex
                                       , int itemsPerPage
                                       , string sortField
                                       , string sort
                                       , out int recordCount)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@GoodsName", goodsName);
            parameters.Add("@VerticalFieldCode", verticalFieldCode);
            parameters.Add("@ActivityType", activityType);
            parameters.Add("@Sales", sales);
            parameters.Add("@HighDailyPrice", highDailyPrice);
            parameters.Add("@LowDailyPrice", lowDailyPrice);
            parameters.Add("@CommissionRatio", commissionRatio);
            parameters.Add("@PageIndex", pageIndex);
            parameters.Add("@PageSize", itemsPerPage);
            parameters.Add("@SortField", sortField);
            parameters.Add("@Sort", sort);
            parameters.Add("@RecordCount", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var goods = Database.Query<Good>("[dbo].[Usp_TYYP_Goods_Pagination]", parameters, commandType: CommandType.StoredProcedure);
            recordCount = parameters.Get<int>("@RecordCount");
            return goods;
        }
	}
}

