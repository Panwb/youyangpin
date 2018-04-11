
using System.Data;
using System.Collections.Specialized;
using System.Collections.Generic;
using Kingston.ComLib;
using Kingston.ComLib.Tools;
using WebAPI.Entities; 

namespace Kingston.KCMS.Data
{
	/// <summary>
	/// Summary description for StudioHostRepository.
	/// </summary>
	public class StudioHostRepository : RepositoryBase<StudioHost>, IStudioHostRepository
	{
        private readonly IWorkContext _workContext;
		public StudioHostRepository(IWorkContext workContext)
		{
            this._workContext = workContext;
		}

		#region CRUD
		public override int Add(StudioHost inStudioHost)
		{						
			var obj= Database.StoredProcedure("[dbo].[Usp_TYYP_StudioHost_Insert]")
                .AddInputParameter("@StudioHostName", DbType.String , inStudioHost.StudioHostName)
                .AddInputParameter("@TKName", DbType.String , inStudioHost.TKName)
                .AddInputParameter("@Height", DbType.Int32 , inStudioHost.Height)
                .AddInputParameter("@Weight", DbType.Int32 , inStudioHost.Weight)
                .AddInputParameter("@ShoeSize", DbType.Int32 , inStudioHost.ShoeSize)
                .AddInputParameter("@ClothesSize", DbType.AnsiString , inStudioHost.ClothesSize)
                .AddInputParameter("@Address", DbType.String , inStudioHost.Address)
                .AddInputParameter("@LinkmanName", DbType.String , inStudioHost.LinkmanName)
                .AddInputParameter("@LinkmanPhone", DbType.AnsiString , inStudioHost.LinkmanPhone)
                .AddInputParameter("@WeChat", DbType.AnsiString , inStudioHost.WeChat)
                .AddInputParameter("@QQ", DbType.AnsiString , inStudioHost.QQ)
                .AddInputParameter("@Email", DbType.AnsiString , inStudioHost.Email)
                .AddInputParameter("@FansNum", DbType.Int32 , inStudioHost.FansNum)
                .AddInputParameter("@AverageDailyViews", DbType.Int32 , inStudioHost.AverageDailyViews)
                .AddInputParameter("@VerticalFieldCode", DbType.String , inStudioHost.VerticalFieldCode)
                .AddInputParameter("@MainPopActivityType", DbType.String , inStudioHost.MainPopActivityType)
                .AddInputParameter("@PerCustomerTransactionHight", DbType.Decimal , inStudioHost.PerCustomerTransactionHight)
                .AddInputParameter("@PerCustomerTransactionLow", DbType.Decimal , inStudioHost.PerCustomerTransactionLow)
                .AddInputParameter("@AlipayAccount", DbType.AnsiString , inStudioHost.AlipayAccount)
                .AddInputParameter("@AccountBalance", DbType.Currency , inStudioHost.AccountBalance)
                .AddInputParameter("@Margin", DbType.Currency , inStudioHost.Margin)
                .AddInputParameter("@CheckStatus", DbType.String , inStudioHost.CheckStatus)
                .AddInputParameter("@Remark", DbType.String , inStudioHost.Remark)
                .AddInputParameter("@DailyBeginTime", DbType.DateTime , inStudioHost.DailyBeginTime)
                .AddInputParameter("@DailyEndTime", DbType.DateTime , inStudioHost.DailyEndTime)
                .AddInputParameter("@DeleteMark", DbType.Int32 , inStudioHost.DeleteMark)
                .ToScalar();

            if (obj == null)
            {
                return 0;
            }
            int returnValue;
            if (int.TryParse(obj.ToString(), out returnValue))
            {
                inStudioHost.UserId = returnValue;
            }
            return returnValue;
		}
				
		public override int Update(StudioHost inStudioHost)
		{	
            return Database.StoredProcedure("[dbo].[Usp_TYYP_StudioHost_Update]")			
                .AddInputParameter("@UserId", DbType.AnsiString , inStudioHost.UserId)
                .AddInputParameter("@StudioHostName", DbType.String , inStudioHost.StudioHostName)
                .AddInputParameter("@TKName", DbType.String , inStudioHost.TKName)
                .AddInputParameter("@Height", DbType.Int32 , inStudioHost.Height)
                .AddInputParameter("@Weight", DbType.Int32 , inStudioHost.Weight)
                .AddInputParameter("@ShoeSize", DbType.Int32 , inStudioHost.ShoeSize)
                .AddInputParameter("@ClothesSize", DbType.AnsiString , inStudioHost.ClothesSize)
                .AddInputParameter("@Address", DbType.String , inStudioHost.Address)
                .AddInputParameter("@LinkmanName", DbType.String , inStudioHost.LinkmanName)
                .AddInputParameter("@LinkmanPhone", DbType.AnsiString , inStudioHost.LinkmanPhone)
                .AddInputParameter("@WeChat", DbType.AnsiString , inStudioHost.WeChat)
                .AddInputParameter("@QQ", DbType.AnsiString , inStudioHost.QQ)
                .AddInputParameter("@Email", DbType.AnsiString , inStudioHost.Email)
                .AddInputParameter("@FansNum", DbType.Int32 , inStudioHost.FansNum)
                .AddInputParameter("@AverageDailyViews", DbType.Int32 , inStudioHost.AverageDailyViews)
                .AddInputParameter("@VerticalFieldCode", DbType.String , inStudioHost.VerticalFieldCode)
                .AddInputParameter("@MainPopActivityType", DbType.String , inStudioHost.MainPopActivityType)
                .AddInputParameter("@PerCustomerTransactionHight", DbType.Decimal , inStudioHost.PerCustomerTransactionHight)
                .AddInputParameter("@PerCustomerTransactionLow", DbType.Decimal , inStudioHost.PerCustomerTransactionLow)
                .AddInputParameter("@AlipayAccount", DbType.AnsiString , inStudioHost.AlipayAccount)
                .AddInputParameter("@AccountBalance", DbType.Currency , inStudioHost.AccountBalance)
                .AddInputParameter("@Margin", DbType.Currency , inStudioHost.Margin)
                .AddInputParameter("@CheckStatus", DbType.String , inStudioHost.CheckStatus)
                .AddInputParameter("@Remark", DbType.String , inStudioHost.Remark)
                .AddInputParameter("@DailyBeginTime", DbType.DateTime , inStudioHost.DailyBeginTime)
                .AddInputParameter("@DailyEndTime", DbType.DateTime , inStudioHost.DailyEndTime)
                .AddInputParameter("@DeleteMark", DbType.Int32 , inStudioHost.DeleteMark)
			    .ExecuteNonQuery();                
		}
				
		public override int Delete(int inUserId)
		{            
            return Database.StoredProcedure("[dbo].[Usp_TYYP_StudioHost_Delete]")			
                .AddInputParameter("@UserId", DbType.Int32 , inUserId)
			    .ExecuteNonQuery(); 			
		}
		
		public override StudioHost GetById(int inUserId)
		{
            return Database.StoredProcedure("[dbo].[Usp_TYYP_StudioHost_Select]")
                .AddInputParameter("@UserId", DbType.Int32, inUserId)
                .ToDataReader()
                .As<StudioHost>();
		}
		
		public override IEnumerable<StudioHost> GetAll()
		{
            return Database.StoredProcedure("[dbo].[Usp_TYYP_StudioHost_SelectAll]")
                .ToDataReader()
                .AsList<StudioHost>();
		}	
		#endregion
        
        
        
        public IEnumerable<StudioHost> GetPagedStudioHost(int? pageIndex
                                       , int itemsPerPage
                                       , string sortField
                                       , string sort
                                       , out int recordCount)
        {
            recordCount = 0;
            ListDictionary outValues;
            var dt = Database.StoredProcedure("[dbo].[Usp_TYYP_StudioHost_Pagination]")
                .AddInputParameter("@PageIndex", DbType.Int32, pageIndex.HasValue ? pageIndex.Value : 1)
                .AddInputParameter("@PageSize", DbType.Int32, itemsPerPage)
                .AddInputParameter("@SortField", DbType.String, sortField)
                .AddInputParameter("@Sort", DbType.String, sort)
                .AddOutputParameter("@RecordCount", DbType.Int32, recordCount)
                .ToDataTable(out outValues);

            var myStudioHost = new List<StudioHost>();
            Converter.DataTableToEntityCollection(dt, myStudioHost);
            recordCount = (int)outValues["RecordCount"];
            return myStudioHost;
        }
        
        public DataTable GetHistoryByColumns(int inUserId)
        {
            return Database.StoredProcedure("[dbo].[Usp_TYYP_StudioHost_SelectHistoryColumns]")
                .AddInputParameter("@UserId", DbType.Int32, inUserId)
                .ToDataTable();
        }
	}
}

