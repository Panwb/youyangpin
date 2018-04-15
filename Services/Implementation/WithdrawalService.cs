using System.Collections.Generic;
using Infrastructure.Services;

using YYP.Entities;
using YYP.Repository;

namespace YYP.Services
{
	public class WithdrawalService : ServiceBase<Withdrawal>,IWithdrawalService
	{
		
		private readonly IWithdrawalRepository _withdrawalRepository;
		
		public WithdrawalService(IWithdrawalRepository withdrawalRepository)
		{
			this._withdrawalRepository = withdrawalRepository;
			
		}
        
	}
}

