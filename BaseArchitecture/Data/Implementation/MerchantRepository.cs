
using System.Data;
using System.Collections.Specialized;
using System.Collections.Generic;
using Kingston.ComLib;
using Kingston.ComLib.Tools;
using WebAPI.Entities; 

namespace Kingston.KCMS.Data
{
	/// <summary>
	/// Summary description for MerchantRepository.
	/// </summary>
	public class MerchantRepository : RepositoryBase<Merchant>, IMerchantRepository
	{
        private readonly IWorkContext _workContext;
		public MerchantRepository(IWorkContext workContext)
		{
            this._workContext = workContext;
		}

		#region CRUD
		public override int Add(Merchant inMerchant)
		{						
			var obj= Database.StoredProcedure("[dbo].[Usp_TYYP_Merchant_Insert]")
                .AddInputParameter("@LinkmanName", DbType.String , inMerchant.LinkmanName)
                .AddInputParameter("@LinkmanPhone", DbType.AnsiString , inMerchant.LinkmanPhone)
                .AddInputParameter("@WeChat", DbType.AnsiString , inMerchant.WeChat)
                .AddInputParameter("@QQ", DbType.AnsiString , inMerchant.QQ)
                .AddInputParameter("@Email", DbType.AnsiString , inMerchant.Email)
                .AddInputParameter("@AccountBalance", DbType.Currency , inMerchant.AccountBalance)
                .AddInputParameter("@DeleteMark", DbType.Int32 , inMerchant.DeleteMark)
                .ToScalar();

            if (obj == null)
            {
                return 0;
            }
            int returnValue;
            if (int.TryParse(obj.ToString(), out returnValue))
            {
                inMerchant.UserId = returnValue;
            }
            return returnValue;
		}
				
		public override int Update(Merchant inMerchant)
		{	
            return Database.StoredProcedure("[dbo].[Usp_TYYP_Merchant_Update]")			
                .AddInputParameter("@UserId", DbType.AnsiString , inMerchant.UserId)
                .AddInputParameter("@LinkmanName", DbType.String , inMerchant.LinkmanName)
                .AddInputParameter("@LinkmanPhone", DbType.AnsiString , inMerchant.LinkmanPhone)
                .AddInputParameter("@WeChat", DbType.AnsiString , inMerchant.WeChat)
                .AddInputParameter("@QQ", DbType.AnsiString , inMerchant.QQ)
                .AddInputParameter("@Email", DbType.AnsiString , inMerchant.Email)
                .AddInputParameter("@AccountBalance", DbType.Currency , inMerchant.AccountBalance)
                .AddInputParameter("@DeleteMark", DbType.Int32 , inMerchant.DeleteMark)
			    .ExecuteNonQuery();                
		}
				
		public override int Delete(int inUserId)
		{            
            return Database.StoredProcedure("[dbo].[Usp_TYYP_Merchant_Delete]")			
                .AddInputParameter("@UserId", DbType.Int32 , inUserId)
			    .ExecuteNonQuery(); 			
		}
		
		public override Merchant GetById(int inUserId)
		{
            return Database.StoredProcedure("[dbo].[Usp_TYYP_Merchant_Select]")
                .AddInputParameter("@UserId", DbType.Int32, inUserId)
                .ToDataReader()
                .As<Merchant>();
		}
		
		public override IEnumerable<Merchant> GetAll()
		{
            return Database.StoredProcedure("[dbo].[Usp_TYYP_Merchant_SelectAll]")
                .ToDataReader()
                .AsList<Merchant>();
		}	
		#endregion
        
        
        
        public IEnumerable<Merchant> GetPagedMerchant(int? pageIndex
                                       , int itemsPerPage
                                       , string sortField
                                       , string sort
                                       , out int recordCount)
        {
            recordCount = 0;
            ListDictionary outValues;
            var dt = Database.StoredProcedure("[dbo].[Usp_TYYP_Merchant_Pagination]")
                .AddInputParameter("@PageIndex", DbType.Int32, pageIndex.HasValue ? pageIndex.Value : 1)
                .AddInputParameter("@PageSize", DbType.Int32, itemsPerPage)
                .AddInputParameter("@SortField", DbType.String, sortField)
                .AddInputParameter("@Sort", DbType.String, sort)
                .AddOutputParameter("@RecordCount", DbType.Int32, recordCount)
                .ToDataTable(out outValues);

            var myMerchant = new List<Merchant>();
            Converter.DataTableToEntityCollection(dt, myMerchant);
            recordCount = (int)outValues["RecordCount"];
            return myMerchant;
        }
        
        public DataTable GetHistoryByColumns(int inUserId)
        {
            return Database.StoredProcedure("[dbo].[Usp_TYYP_Merchant_SelectHistoryColumns]")
                .AddInputParameter("@UserId", DbType.Int32, inUserId)
                .ToDataTable();
        }
	}
}

