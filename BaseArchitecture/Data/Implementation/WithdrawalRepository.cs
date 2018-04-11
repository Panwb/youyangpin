
using System.Data;
using System.Collections.Specialized;
using System.Collections.Generic;
using Kingston.ComLib;
using Kingston.ComLib.Tools;
using WebAPI.Entities; 

namespace Kingston.KCMS.Data
{
	/// <summary>
	/// Summary description for WithdrawalRepository.
	/// </summary>
	public class WithdrawalRepository : RepositoryBase<Withdrawal>, IWithdrawalRepository
	{
        private readonly IWorkContext _workContext;
		public WithdrawalRepository(IWorkContext workContext)
		{
            this._workContext = workContext;
		}

		#region CRUD
		public override int Add(Withdrawal inWithdrawal)
		{						
			var obj= Database.StoredProcedure("[dbo].[Usp_TYYP_Withdrawal_Insert]")
                .AddInputParameter("@WithdrawalrUserId", DbType.AnsiString , inWithdrawal.WithdrawalrUserId)
                .AddInputParameter("@WithdrawalrMoney", DbType.Currency , inWithdrawal.WithdrawalrMoney)
                .AddInputParameter("@ApplyTime", DbType.DateTime , inWithdrawal.ApplyTime)
                .AddInputParameter("@HandleStatus", DbType.String , inWithdrawal.HandleStatus)
                .AddInputParameter("@HandleTime", DbType.DateTime , inWithdrawal.HandleTime)
                .AddInputParameter("@HandleUserId", DbType.AnsiString , inWithdrawal.HandleUserId)
                .ToScalar();

            if (obj == null)
            {
                return 0;
            }
            int returnValue;
            if (int.TryParse(obj.ToString(), out returnValue))
            {
                inWithdrawal.WithdrawalrId = returnValue;
            }
            return returnValue;
		}
				
		public override int Update(Withdrawal inWithdrawal)
		{	
            return Database.StoredProcedure("[dbo].[Usp_TYYP_Withdrawal_Update]")			
                .AddInputParameter("@WithdrawalrId", DbType.AnsiString , inWithdrawal.WithdrawalrId)
                .AddInputParameter("@WithdrawalrUserId", DbType.AnsiString , inWithdrawal.WithdrawalrUserId)
                .AddInputParameter("@WithdrawalrMoney", DbType.Currency , inWithdrawal.WithdrawalrMoney)
                .AddInputParameter("@ApplyTime", DbType.DateTime , inWithdrawal.ApplyTime)
                .AddInputParameter("@HandleStatus", DbType.String , inWithdrawal.HandleStatus)
                .AddInputParameter("@HandleTime", DbType.DateTime , inWithdrawal.HandleTime)
                .AddInputParameter("@HandleUserId", DbType.AnsiString , inWithdrawal.HandleUserId)
			    .ExecuteNonQuery();                
		}
				
		public override int Delete(int inWithdrawalrId)
		{            
            return Database.StoredProcedure("[dbo].[Usp_TYYP_Withdrawal_Delete]")			
                .AddInputParameter("@WithdrawalrId", DbType.Int32 , inWithdrawalrId)
			    .ExecuteNonQuery(); 			
		}
		
		public override Withdrawal GetById(int inWithdrawalrId)
		{
            return Database.StoredProcedure("[dbo].[Usp_TYYP_Withdrawal_Select]")
                .AddInputParameter("@WithdrawalrId", DbType.Int32, inWithdrawalrId)
                .ToDataReader()
                .As<Withdrawal>();
		}
		
		public override IEnumerable<Withdrawal> GetAll()
		{
            return Database.StoredProcedure("[dbo].[Usp_TYYP_Withdrawal_SelectAll]")
                .ToDataReader()
                .AsList<Withdrawal>();
		}	
		#endregion
        
        
        
        public IEnumerable<Withdrawal> GetPagedWithdrawal(int? pageIndex
                                       , int itemsPerPage
                                       , string sortField
                                       , string sort
                                       , out int recordCount)
        {
            recordCount = 0;
            ListDictionary outValues;
            var dt = Database.StoredProcedure("[dbo].[Usp_TYYP_Withdrawal_Pagination]")
                .AddInputParameter("@PageIndex", DbType.Int32, pageIndex.HasValue ? pageIndex.Value : 1)
                .AddInputParameter("@PageSize", DbType.Int32, itemsPerPage)
                .AddInputParameter("@SortField", DbType.String, sortField)
                .AddInputParameter("@Sort", DbType.String, sort)
                .AddOutputParameter("@RecordCount", DbType.Int32, recordCount)
                .ToDataTable(out outValues);

            var myWithdrawal = new List<Withdrawal>();
            Converter.DataTableToEntityCollection(dt, myWithdrawal);
            recordCount = (int)outValues["RecordCount"];
            return myWithdrawal;
        }
        
        public DataTable GetHistoryByColumns(int inWithdrawalrId)
        {
            return Database.StoredProcedure("[dbo].[Usp_TYYP_Withdrawal_SelectHistoryColumns]")
                .AddInputParameter("@WithdrawalrId", DbType.Int32, inWithdrawalrId)
                .ToDataTable();
        }
	}
}

