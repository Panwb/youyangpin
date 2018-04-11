
using System.Data;
using System.Collections.Specialized;
using System.Collections.Generic;
using Kingston.ComLib;
using Kingston.ComLib.Tools;
using WebAPI.Entities; 

namespace Kingston.KCMS.Data
{
	/// <summary>
	/// Summary description for OrderGoodRepository.
	/// </summary>
	public class OrderGoodRepository : RepositoryBase<OrderGood>, IOrderGoodRepository
	{
        private readonly IWorkContext _workContext;
		public OrderGoodRepository(IWorkContext workContext)
		{
            this._workContext = workContext;
		}

		#region CRUD
		public override int Add(OrderGood inOrderGood)
		{						
			var obj= Database.StoredProcedure("[dbo].[Usp_TYYP_OrderGood_Insert]")
                .AddInputParameter("@OrderId", DbType.AnsiString , inOrderGood.OrderId)
                .AddInputParameter("@GoodsId", DbType.AnsiString , inOrderGood.GoodsId)
                .ToScalar();

            if (obj == null)
            {
                return 0;
            }
            int returnValue;
            if (int.TryParse(obj.ToString(), out returnValue))
            {
                inOrderGood.OrderGoodsId = returnValue;
            }
            return returnValue;
		}
				
		public override int Update(OrderGood inOrderGood)
		{	
            return Database.StoredProcedure("[dbo].[Usp_TYYP_OrderGood_Update]")			
                .AddInputParameter("@OrderGoodsId", DbType.AnsiString , inOrderGood.OrderGoodsId)
                .AddInputParameter("@OrderId", DbType.AnsiString , inOrderGood.OrderId)
                .AddInputParameter("@GoodsId", DbType.AnsiString , inOrderGood.GoodsId)
			    .ExecuteNonQuery();                
		}
				
		public override int Delete(int inOrderGoodsId)
		{            
            return Database.StoredProcedure("[dbo].[Usp_TYYP_OrderGood_Delete]")			
                .AddInputParameter("@OrderGoodsId", DbType.Int32 , inOrderGoodsId)
			    .ExecuteNonQuery(); 			
		}
		
		public override OrderGood GetById(int inOrderGoodsId)
		{
            return Database.StoredProcedure("[dbo].[Usp_TYYP_OrderGood_Select]")
                .AddInputParameter("@OrderGoodsId", DbType.Int32, inOrderGoodsId)
                .ToDataReader()
                .As<OrderGood>();
		}
		
		public override IEnumerable<OrderGood> GetAll()
		{
            return Database.StoredProcedure("[dbo].[Usp_TYYP_OrderGood_SelectAll]")
                .ToDataReader()
                .AsList<OrderGood>();
		}	
		#endregion
        
        
        
        public IEnumerable<OrderGood> GetPagedOrderGood(int? pageIndex
                                       , int itemsPerPage
                                       , string sortField
                                       , string sort
                                       , out int recordCount)
        {
            recordCount = 0;
            ListDictionary outValues;
            var dt = Database.StoredProcedure("[dbo].[Usp_TYYP_OrderGood_Pagination]")
                .AddInputParameter("@PageIndex", DbType.Int32, pageIndex.HasValue ? pageIndex.Value : 1)
                .AddInputParameter("@PageSize", DbType.Int32, itemsPerPage)
                .AddInputParameter("@SortField", DbType.String, sortField)
                .AddInputParameter("@Sort", DbType.String, sort)
                .AddOutputParameter("@RecordCount", DbType.Int32, recordCount)
                .ToDataTable(out outValues);

            var myOrderGood = new List<OrderGood>();
            Converter.DataTableToEntityCollection(dt, myOrderGood);
            recordCount = (int)outValues["RecordCount"];
            return myOrderGood;
        }
        
        public DataTable GetHistoryByColumns(int inOrderGoodsId)
        {
            return Database.StoredProcedure("[dbo].[Usp_TYYP_OrderGood_SelectHistoryColumns]")
                .AddInputParameter("@OrderGoodsId", DbType.Int32, inOrderGoodsId)
                .ToDataTable();
        }
	}
}

