using System.Collections.Generic;
using Kingston.ComLib.DomainModel;
using WebAPI.Entities; 

namespace WebAPI.Services
{
	public interface IMerchantService : IService<Merchant>
	{				
		MerchantServiceResult Add(Merchant inMerchant);
		
		MerchantServiceResult Update(Merchant inMerchant);
		
		MerchantServiceResult Delete(int inUserId);
		
		MerchantServiceResult GetById(int inMerchant);	
		
		IEnumerable<Merchant> GetAll();
        
        MerchantServiceResult Save(Merchant inMerchant);

        IEnumerable<Merchant> GetPagedMerchant(int? pageIndex
                                         , int itemsPerPage
                                         , string sortField
                                         , string sort
                                         , out int recordCount);
	}
}

