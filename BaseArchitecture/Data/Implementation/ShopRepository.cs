
using System.Data;
using System.Collections.Specialized;
using System.Collections.Generic;
using Kingston.ComLib;
using Kingston.ComLib.Tools;
using WebAPI.Entities; 

namespace Kingston.KCMS.Data
{
	/// <summary>
	/// Summary description for ShopRepository.
	/// </summary>
	public class ShopRepository : RepositoryBase<Shop>, IShopRepository
	{
        private readonly IWorkContext _workContext;
		public ShopRepository(IWorkContext workContext)
		{
            this._workContext = workContext;
		}

		#region CRUD
		public override int Add(Shop inShop)
		{						
			var obj= Database.StoredProcedure("[dbo].[Usp_TYYP_Shop_Insert]")
                .AddInputParameter("@UserId", DbType.AnsiString , inShop.UserId)
                .AddInputParameter("@ShopType", DbType.String , inShop.ShopType)
                .AddInputParameter("@ShopName", DbType.String , inShop.ShopName)
                .AddInputParameter("@VerticalFieldCode", DbType.String , inShop.VerticalFieldCode)
                .AddInputParameter("@ShopURL", DbType.AnsiString , inShop.ShopURL)
                .AddInputParameter("@WangWangNo", DbType.String , inShop.WangWangNo)
                .AddInputParameter("@ShopAddress", DbType.String , inShop.ShopAddress)
                .AddInputParameter("@DescriptionMatch", DbType.Decimal , inShop.DescriptionMatch)
                .AddInputParameter("@ServiceAttitude", DbType.Decimal , inShop.ServiceAttitude)
                .AddInputParameter("@LogisticsService", DbType.Decimal , inShop.LogisticsService)
                .AddInputParameter("@CheckStatus", DbType.String , inShop.CheckStatus)
                .AddInputParameter("@DeleteMark", DbType.Int32 , inShop.DeleteMark)
                .ToScalar();

            if (obj == null)
            {
                return 0;
            }
            int returnValue;
            if (int.TryParse(obj.ToString(), out returnValue))
            {
                inShop.ShopId = returnValue;
            }
            return returnValue;
		}
				
		public override int Update(Shop inShop)
		{	
            return Database.StoredProcedure("[dbo].[Usp_TYYP_Shop_Update]")			
                .AddInputParameter("@ShopId", DbType.AnsiString , inShop.ShopId)
                .AddInputParameter("@UserId", DbType.AnsiString , inShop.UserId)
                .AddInputParameter("@ShopType", DbType.String , inShop.ShopType)
                .AddInputParameter("@ShopName", DbType.String , inShop.ShopName)
                .AddInputParameter("@VerticalFieldCode", DbType.String , inShop.VerticalFieldCode)
                .AddInputParameter("@ShopURL", DbType.AnsiString , inShop.ShopURL)
                .AddInputParameter("@WangWangNo", DbType.String , inShop.WangWangNo)
                .AddInputParameter("@ShopAddress", DbType.String , inShop.ShopAddress)
                .AddInputParameter("@DescriptionMatch", DbType.Decimal , inShop.DescriptionMatch)
                .AddInputParameter("@ServiceAttitude", DbType.Decimal , inShop.ServiceAttitude)
                .AddInputParameter("@LogisticsService", DbType.Decimal , inShop.LogisticsService)
                .AddInputParameter("@CheckStatus", DbType.String , inShop.CheckStatus)
                .AddInputParameter("@DeleteMark", DbType.Int32 , inShop.DeleteMark)
			    .ExecuteNonQuery();                
		}
				
		public override int Delete(int inShopId)
		{            
            return Database.StoredProcedure("[dbo].[Usp_TYYP_Shop_Delete]")			
                .AddInputParameter("@ShopId", DbType.Int32 , inShopId)
			    .ExecuteNonQuery(); 			
		}
		
		public override Shop GetById(int inShopId)
		{
            return Database.StoredProcedure("[dbo].[Usp_TYYP_Shop_Select]")
                .AddInputParameter("@ShopId", DbType.Int32, inShopId)
                .ToDataReader()
                .As<Shop>();
		}
		
		public override IEnumerable<Shop> GetAll()
		{
            return Database.StoredProcedure("[dbo].[Usp_TYYP_Shop_SelectAll]")
                .ToDataReader()
                .AsList<Shop>();
		}	
		#endregion
        
        
        
        public IEnumerable<Shop> GetPagedShop(int? pageIndex
                                       , int itemsPerPage
                                       , string sortField
                                       , string sort
                                       , out int recordCount)
        {
            recordCount = 0;
            ListDictionary outValues;
            var dt = Database.StoredProcedure("[dbo].[Usp_TYYP_Shop_Pagination]")
                .AddInputParameter("@PageIndex", DbType.Int32, pageIndex.HasValue ? pageIndex.Value : 1)
                .AddInputParameter("@PageSize", DbType.Int32, itemsPerPage)
                .AddInputParameter("@SortField", DbType.String, sortField)
                .AddInputParameter("@Sort", DbType.String, sort)
                .AddOutputParameter("@RecordCount", DbType.Int32, recordCount)
                .ToDataTable(out outValues);

            var myShop = new List<Shop>();
            Converter.DataTableToEntityCollection(dt, myShop);
            recordCount = (int)outValues["RecordCount"];
            return myShop;
        }
        
        public DataTable GetHistoryByColumns(int inShopId)
        {
            return Database.StoredProcedure("[dbo].[Usp_TYYP_Shop_SelectHistoryColumns]")
                .AddInputParameter("@ShopId", DbType.Int32, inShopId)
                .ToDataTable();
        }
	}
}

