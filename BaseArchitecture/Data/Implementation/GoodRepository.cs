using System.Data;
using System.Collections.Specialized;
using System.Collections.Generic;
using Kingston.KCMS.Data;
using WebAPI.Entities;

namespace WebAPI.Data
{
    /// <summary>
    /// Summary description for GoodRepository.
    /// </summary>
    public class GoodRepository : RepositoryBase<Good>, IGoodRepository
	{
        private readonly IWorkContext _workContext;
		public GoodRepository(IWorkContext workContext)
		{
            this._workContext = workContext;
		}

		#region CRUD
		public override int Add(Good inGood)
		{						
			var obj= Database.StoredProcedure("[dbo].[Usp_TYYP_Good_Insert]")
                .AddInputParameter("@UserId", DbType.AnsiString , inGood.UserId)
                .AddInputParameter("@ShopId", DbType.AnsiString , inGood.ShopId)
                .AddInputParameter("@GoodsImgURL", DbType.AnsiString , inGood.GoodsImgURL)
                .AddInputParameter("@GoodsName", DbType.String , inGood.GoodsName)
                .AddInputParameter("@GoodsURL", DbType.AnsiString , inGood.GoodsURL)
                .AddInputParameter("@ActivityType", DbType.String , inGood.ActivityType)
                .AddInputParameter("@DailyPrice", DbType.Decimal , inGood.DailyPrice)
                .AddInputParameter("@LivePrice", DbType.Decimal , inGood.LivePrice)
                .AddInputParameter("@CommissionRatio", DbType.Decimal , inGood.CommissionRatio)
                .AddInputParameter("@CommissionURL", DbType.AnsiString , inGood.CommissionURL)
                .AddInputParameter("@InventoryNum", DbType.Int32 , inGood.InventoryNum)
                .AddInputParameter("@SupplyNum", DbType.Int32 , inGood.SupplyNum)
                .AddInputParameter("@IsProvideMulticolor", DbType.String , inGood.IsProvideMulticolor)
                .AddInputParameter("@ColorNum", DbType.Int32 , inGood.ColorNum)
                .AddInputParameter("@Sales", DbType.Int32 , inGood.Sales)
                .AddInputParameter("@PreferentialWay", DbType.String , inGood.PreferentialWay)
                .AddInputParameter("@NeedSendBack", DbType.String , inGood.NeedSendBack)
                .AddInputParameter("@SellingPointDescribe", DbType.String , inGood.SellingPointDescribe)
                .AddInputParameter("@CouponsURL", DbType.String , inGood.CouponsURL)
                .AddInputParameter("@ActivityBeginTime", DbType.DateTime , inGood.ActivityBeginTime)
                .AddInputParameter("@ActivityEndTime", DbType.DateTime , inGood.ActivityEndTime)
                .AddInputParameter("@FansOrAverageDailyViews", DbType.String , inGood.FansOrAverageDailyViews)
                .AddInputParameter("@AverageDailyViewsHight", DbType.Int32 , inGood.AverageDailyViewsHight)
                .AddInputParameter("@AverageDailyViewsLow", DbType.Int32 , inGood.AverageDailyViewsLow)
                .AddInputParameter("@FansHight", DbType.Int32 , inGood.FansHight)
                .AddInputParameter("@FansLow", DbType.Int32 , inGood.FansLow)
                .AddInputParameter("@CheckStatus", DbType.String , inGood.CheckStatus)
                .AddInputParameter("@DeleteMark", DbType.Int32 , inGood.DeleteMark)
                .ToScalar();

            if (obj == null)
            {
                return 0;
            }
            int returnValue;
            if (int.TryParse(obj.ToString(), out returnValue))
            {
                inGood.GoodsId = returnValue;
            }
            return returnValue;
		}
				
		public override int Update(Good inGood)
		{	
            return Database.StoredProcedure("[dbo].[Usp_TYYP_Good_Update]")			
                .AddInputParameter("@GoodsId", DbType.AnsiString , inGood.GoodsId)
                .AddInputParameter("@UserId", DbType.AnsiString , inGood.UserId)
                .AddInputParameter("@ShopId", DbType.AnsiString , inGood.ShopId)
                .AddInputParameter("@GoodsImgURL", DbType.AnsiString , inGood.GoodsImgURL)
                .AddInputParameter("@GoodsName", DbType.String , inGood.GoodsName)
                .AddInputParameter("@GoodsURL", DbType.AnsiString , inGood.GoodsURL)
                .AddInputParameter("@ActivityType", DbType.String , inGood.ActivityType)
                .AddInputParameter("@DailyPrice", DbType.Decimal , inGood.DailyPrice)
                .AddInputParameter("@LivePrice", DbType.Decimal , inGood.LivePrice)
                .AddInputParameter("@CommissionRatio", DbType.Decimal , inGood.CommissionRatio)
                .AddInputParameter("@CommissionURL", DbType.AnsiString , inGood.CommissionURL)
                .AddInputParameter("@InventoryNum", DbType.Int32 , inGood.InventoryNum)
                .AddInputParameter("@SupplyNum", DbType.Int32 , inGood.SupplyNum)
                .AddInputParameter("@IsProvideMulticolor", DbType.String , inGood.IsProvideMulticolor)
                .AddInputParameter("@ColorNum", DbType.Int32 , inGood.ColorNum)
                .AddInputParameter("@Sales", DbType.Int32 , inGood.Sales)
                .AddInputParameter("@PreferentialWay", DbType.String , inGood.PreferentialWay)
                .AddInputParameter("@NeedSendBack", DbType.String , inGood.NeedSendBack)
                .AddInputParameter("@SellingPointDescribe", DbType.String , inGood.SellingPointDescribe)
                .AddInputParameter("@CouponsURL", DbType.String , inGood.CouponsURL)
                .AddInputParameter("@ActivityBeginTime", DbType.DateTime , inGood.ActivityBeginTime)
                .AddInputParameter("@ActivityEndTime", DbType.DateTime , inGood.ActivityEndTime)
                .AddInputParameter("@FansOrAverageDailyViews", DbType.String , inGood.FansOrAverageDailyViews)
                .AddInputParameter("@AverageDailyViewsHight", DbType.Int32 , inGood.AverageDailyViewsHight)
                .AddInputParameter("@AverageDailyViewsLow", DbType.Int32 , inGood.AverageDailyViewsLow)
                .AddInputParameter("@FansHight", DbType.Int32 , inGood.FansHight)
                .AddInputParameter("@FansLow", DbType.Int32 , inGood.FansLow)
                .AddInputParameter("@CheckStatus", DbType.String , inGood.CheckStatus)
                .AddInputParameter("@DeleteMark", DbType.Int32 , inGood.DeleteMark)
			    .ExecuteNonQuery();                
		}
				
		public override int Delete(int inGoodsId)
		{            
            return Database.StoredProcedure("[dbo].[Usp_TYYP_Good_Delete]")			
                .AddInputParameter("@GoodsId", DbType.Int32 , inGoodsId)
			    .ExecuteNonQuery(); 			
		}
		
		public override Good GetById(int inGoodsId)
		{
            return Database.StoredProcedure("[dbo].[Usp_TYYP_Good_Select]")
                .AddInputParameter("@GoodsId", DbType.Int32, inGoodsId)
                .ToDataReader()
                .As<Good>();
		}
		
		public override IEnumerable<Good> GetAll()
		{
            return Database.StoredProcedure("[dbo].[Usp_TYYP_Good_SelectAll]")
                .ToDataReader()
                .AsList<Good>();
		}	
		#endregion
        
        
        
        public IEnumerable<Good> GetPagedGood(int? pageIndex
                                       , int itemsPerPage
                                       , string sortField
                                       , string sort
                                       , out int recordCount)
        {
            recordCount = 0;
            ListDictionary outValues;
            var dt = Database.StoredProcedure("[dbo].[Usp_TYYP_Good_Pagination]")
                .AddInputParameter("@PageIndex", DbType.Int32, pageIndex.HasValue ? pageIndex.Value : 1)
                .AddInputParameter("@PageSize", DbType.Int32, itemsPerPage)
                .AddInputParameter("@SortField", DbType.String, sortField)
                .AddInputParameter("@Sort", DbType.String, sort)
                .AddOutputParameter("@RecordCount", DbType.Int32, recordCount)
                .ToDataTable(out outValues);

            var myGood = new List<Good>();
            Converter<,>.DataTableToEntityCollection(dt, myGood);
            recordCount = (int)outValues["RecordCount"];
            return myGood;
        }
        
        public DataTable GetHistoryByColumns(int inGoodsId)
        {
            return Database.StoredProcedure("[dbo].[Usp_TYYP_Good_SelectHistoryColumns]")
                .AddInputParameter("@GoodsId", DbType.Int32, inGoodsId)
                .ToDataTable();
        }
	}
}

