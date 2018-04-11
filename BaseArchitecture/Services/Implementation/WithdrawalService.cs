using System;
using System.Collections.Generic;
using System.Linq;
using Kingston.ComLib.Logging;
using Kingston.ComLib.DomainModel;
using WebAPI.Entities;
using WebAPI.Data;

namespace WebAPI.Services
{
	public class WithdrawalService : ServiceBase<Withdrawal>,IWithdrawalService
	{
		private readonly ILogger _logger;
		private readonly IWithdrawalRepository _withdrawalRepository;
		
		public WithdrawalService(IWithdrawalRepository withdrawalRepository, ILogger logger)
		{
			this._withdrawalRepository = withdrawalRepository;
			this._logger = logger;
		}
		#region CRUD
		/// <summary>
		/// Add a new Withdrawal
		/// </summary>
		/// <param name="inWithdrawal"></param>
		/// <returns></returns>
		public WithdrawalServiceResult Add(Withdrawal inWithdrawal)
		{
            return ExecuteCommand ( () =>
                                        {
                                            _withdrawalRepository.Add(inWithdrawal);                                            
                                            return new WithdrawalServiceResult();
                                        });			
		}		
		
		/// <summary>
		/// Update Withdrawal 
		/// </summary>
		/// <param name="inWithdrawal"></param>
		/// <returns></returns>
		public WithdrawalServiceResult Update(Withdrawal inWithdrawal)
		{
            return ExecuteCommand ( () =>
                                        {
                                            _withdrawalRepository.Update(inWithdrawal);                                            
                                            return new WithdrawalServiceResult();
                                        });
		}
        
		/// <summary>
		/// delete Withdrawal
		/// </summary>
		/// <param name="inWithdrawalrId"></param>
		/// <returns></returns>
		public WithdrawalServiceResult Delete(int inWithdrawalrId)
		{
            return ExecuteCommand ( () =>
                                        {
                                            _withdrawalRepository.Delete(inWithdrawalrId);
                                            return new WithdrawalServiceResult();
                                        });
		}
        
		/// <summary>
		/// select a Withdrawal by ID
		/// </summary>
		/// <param name="inWithdrawalrId"></param>
		/// <returns></returns>
		public WithdrawalServiceResult GetById(int inWithdrawalrId)
		{
            return ExecuteCommand(() =>
                new WithdrawalServiceResult(_withdrawalRepository.GetById(inWithdrawalrId))
            );
		}
        
		/// <summary>
		/// select all Withdrawal
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Withdrawal> GetAll()
		{
			try
			{
				return _withdrawalRepository.GetAll();
			}
			catch(Exception ex)
			{
				_logger.Error(ex.ToString());
			}
			return Enumerable.Empty<Withdrawal>();
		}

		#endregion
        
        public WithdrawalServiceResult Save(Withdrawal inWithdrawal)
        {
            return ExecuteCommand(() =>
            {
                var result = new WithdrawalServiceResult();
                switch(inWithdrawal.Action)
                {
                    case EntityAction.New:
                        result = Add(inWithdrawal);
                        break;
                    case EntityAction.Updated:
                        result = Update(inWithdrawal);
                        break;
                    case EntityAction.Deleted:
                        result = Delete(inWithdrawal.WithdrawalrId);
                        break;
                    case EntityAction.UnChanged:                        
                    case EntityAction.UnAttach:                        
                        break;
                }
                return result;
            });
        }
        
        public IEnumerable<Withdrawal> GetPagedWithdrawal(int? pageIndex
                                    , int itemsPerPage
                                    , string sortField
                                    , string sort
                                    , out int recordCount)
		{
			return _withdrawalRepository.GetPagedWithdrawal(
				pageIndex, itemsPerPage, sortField, sort, out recordCount);
		}
        
	}
}

