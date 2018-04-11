
using System.Data;
using System.Collections.Specialized;
using System.Collections.Generic;
using Kingston.ComLib;
using Kingston.ComLib.Tools;
using WebAPI.Entities; 

namespace Kingston.KCMS.Data
{
	/// <summary>
	/// Summary description for OrderRepository.
	/// </summary>
	public class OrderRepository : RepositoryBase<Order>, IOrderRepository
	{
        private readonly IWorkContext _workContext;
		public OrderRepository(IWorkContext workContext)
		{
            this._workContext = workContext;
		}

		#region CRUD
		public override int Add(Order inOrder)
		{						
			var obj= Database.StoredProcedure("[dbo].[Usp_TYYP_Order_Insert]")
                .AddInputParameter("@StudioHostUserId", DbType.AnsiString , inOrder.StudioHostUserId)
                .AddInputParameter("@MerchantUserId", DbType.AnsiString , inOrder.MerchantUserId)
                .AddInputParameter("@ShopGuid", DbType.AnsiString , inOrder.ShopGuid)
                .AddInputParameter("@CheckStatus", DbType.String , inOrder.CheckStatus)
                .AddInputParameter("@OrderNo", DbType.AnsiString , inOrder.OrderNo)
                .AddInputParameter("@OrderStatus", DbType.String , inOrder.OrderStatus)
                .AddInputParameter("@CreateTime", DbType.DateTime , inOrder.CreateTime)
                .AddInputParameter("@FaHuoTime", DbType.DateTime , inOrder.FaHuoTime)
                .AddInputParameter("@DaoHuoTime", DbType.DateTime , inOrder.DaoHuoTime)
                .AddInputParameter("@TuiHuoTime", DbType.DateTime , inOrder.TuiHuoTime)
                .AddInputParameter("@TuiFeiTime", DbType.DateTime , inOrder.TuiFeiTime)
                .AddInputParameter("@LogisticName", DbType.String , inOrder.LogisticName)
                .AddInputParameter("@LogisticNo", DbType.AnsiString , inOrder.LogisticNo)
                .AddInputParameter("@TuiHuoLogisticName", DbType.String , inOrder.TuiHuoLogisticName)
                .AddInputParameter("@TuiHuoLogisticNo", DbType.AnsiString , inOrder.TuiHuoLogisticNo)
                .AddInputParameter("@TuiHuoPostage", DbType.Currency , inOrder.TuiHuoPostage)
                .AddInputParameter("@MerchantToStudioHos", DbType.String , inOrder.MerchantToStudioHos)
                .AddInputParameter("@MerchantGiveStudioHosStars", DbType.Int32 , inOrder.MerchantGiveStudioHosStars)
                .AddInputParameter("@StudioHosToMerchant", DbType.String , inOrder.StudioHosToMerchant)
                .AddInputParameter("@StudioHosGiveMerchantStars", DbType.Int32 , inOrder.StudioHosGiveMerchantStars)
                .AddInputParameter("@BroadcastScheduling", DbType.DateTime , inOrder.BroadcastScheduling)
                .AddInputParameter("@DirectionalPlanStatus", DbType.String , inOrder.DirectionalPlanStatus)
                .AddInputParameter("@PostageStatisticsMark", DbType.Int32 , inOrder.PostageStatisticsMark)
                .ToScalar();

            if (obj == null)
            {
                return 0;
            }
            int returnValue;
            if (int.TryParse(obj.ToString(), out returnValue))
            {
                inOrder.OrderId = returnValue;
            }
            return returnValue;
		}
				
		public override int Update(Order inOrder)
		{	
            return Database.StoredProcedure("[dbo].[Usp_TYYP_Order_Update]")			
                .AddInputParameter("@OrderId", DbType.AnsiString , inOrder.OrderId)
                .AddInputParameter("@StudioHostUserId", DbType.AnsiString , inOrder.StudioHostUserId)
                .AddInputParameter("@MerchantUserId", DbType.AnsiString , inOrder.MerchantUserId)
                .AddInputParameter("@ShopGuid", DbType.AnsiString , inOrder.ShopGuid)
                .AddInputParameter("@CheckStatus", DbType.String , inOrder.CheckStatus)
                .AddInputParameter("@OrderNo", DbType.AnsiString , inOrder.OrderNo)
                .AddInputParameter("@OrderStatus", DbType.String , inOrder.OrderStatus)
                .AddInputParameter("@CreateTime", DbType.DateTime , inOrder.CreateTime)
                .AddInputParameter("@FaHuoTime", DbType.DateTime , inOrder.FaHuoTime)
                .AddInputParameter("@DaoHuoTime", DbType.DateTime , inOrder.DaoHuoTime)
                .AddInputParameter("@TuiHuoTime", DbType.DateTime , inOrder.TuiHuoTime)
                .AddInputParameter("@TuiFeiTime", DbType.DateTime , inOrder.TuiFeiTime)
                .AddInputParameter("@LogisticName", DbType.String , inOrder.LogisticName)
                .AddInputParameter("@LogisticNo", DbType.AnsiString , inOrder.LogisticNo)
                .AddInputParameter("@TuiHuoLogisticName", DbType.String , inOrder.TuiHuoLogisticName)
                .AddInputParameter("@TuiHuoLogisticNo", DbType.AnsiString , inOrder.TuiHuoLogisticNo)
                .AddInputParameter("@TuiHuoPostage", DbType.Currency , inOrder.TuiHuoPostage)
                .AddInputParameter("@MerchantToStudioHos", DbType.String , inOrder.MerchantToStudioHos)
                .AddInputParameter("@MerchantGiveStudioHosStars", DbType.Int32 , inOrder.MerchantGiveStudioHosStars)
                .AddInputParameter("@StudioHosToMerchant", DbType.String , inOrder.StudioHosToMerchant)
                .AddInputParameter("@StudioHosGiveMerchantStars", DbType.Int32 , inOrder.StudioHosGiveMerchantStars)
                .AddInputParameter("@BroadcastScheduling", DbType.DateTime , inOrder.BroadcastScheduling)
                .AddInputParameter("@DirectionalPlanStatus", DbType.String , inOrder.DirectionalPlanStatus)
                .AddInputParameter("@PostageStatisticsMark", DbType.Int32 , inOrder.PostageStatisticsMark)
			    .ExecuteNonQuery();                
		}
				
		public override int Delete(int inOrderId)
		{            
            return Database.StoredProcedure("[dbo].[Usp_TYYP_Order_Delete]")			
                .AddInputParameter("@OrderId", DbType.Int32 , inOrderId)
			    .ExecuteNonQuery(); 			
		}
		
		public override Order GetById(int inOrderId)
		{
            return Database.StoredProcedure("[dbo].[Usp_TYYP_Order_Select]")
                .AddInputParameter("@OrderId", DbType.Int32, inOrderId)
                .ToDataReader()
                .As<Order>();
		}
		
		public override IEnumerable<Order> GetAll()
		{
            return Database.StoredProcedure("[dbo].[Usp_TYYP_Order_SelectAll]")
                .ToDataReader()
                .AsList<Order>();
		}	
		#endregion
        
        
        
        public IEnumerable<Order> GetPagedOrder(int? pageIndex
                                       , int itemsPerPage
                                       , string sortField
                                       , string sort
                                       , out int recordCount)
        {
            recordCount = 0;
            ListDictionary outValues;
            var dt = Database.StoredProcedure("[dbo].[Usp_TYYP_Order_Pagination]")
                .AddInputParameter("@PageIndex", DbType.Int32, pageIndex.HasValue ? pageIndex.Value : 1)
                .AddInputParameter("@PageSize", DbType.Int32, itemsPerPage)
                .AddInputParameter("@SortField", DbType.String, sortField)
                .AddInputParameter("@Sort", DbType.String, sort)
                .AddOutputParameter("@RecordCount", DbType.Int32, recordCount)
                .ToDataTable(out outValues);

            var myOrder = new List<Order>();
            Converter.DataTableToEntityCollection(dt, myOrder);
            recordCount = (int)outValues["RecordCount"];
            return myOrder;
        }
        
        public DataTable GetHistoryByColumns(int inOrderId)
        {
            return Database.StoredProcedure("[dbo].[Usp_TYYP_Order_SelectHistoryColumns]")
                .AddInputParameter("@OrderId", DbType.Int32, inOrderId)
                .ToDataTable();
        }
	}
}

