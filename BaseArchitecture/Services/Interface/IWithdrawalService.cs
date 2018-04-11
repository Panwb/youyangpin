using System.Collections.Generic;
using Kingston.ComLib.DomainModel;
using WebAPI.Entities; 

namespace WebAPI.Services
{
	public interface IWithdrawalService : IService<Withdrawal>
	{				
		WithdrawalServiceResult Add(Withdrawal inWithdrawal);
		
		WithdrawalServiceResult Update(Withdrawal inWithdrawal);
		
		WithdrawalServiceResult Delete(int inWithdrawalrId);
		
		WithdrawalServiceResult GetById(int inWithdrawal);	
		
		IEnumerable<Withdrawal> GetAll();
        
        WithdrawalServiceResult Save(Withdrawal inWithdrawal);

        IEnumerable<Withdrawal> GetPagedWithdrawal(int? pageIndex
                                         , int itemsPerPage
                                         , string sortField
                                         , string sort
                                         , out int recordCount);
	}
}

