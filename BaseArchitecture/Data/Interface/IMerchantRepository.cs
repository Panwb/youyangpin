using System;
using System.Data;
using System.Collections.Generic;
using Kingston.ComLib.Data; 
using WebAPI.Entities; 

namespace Kingston.KCMS.Data
{
	public interface IMerchantRepository : IRepository<Merchant>
	{
        
    
		IEnumerable<Merchant> GetPagedMerchant(int? pageIndex
                                                        , int itemsPerPage
                                                        , string sortField
                                                        , string sort
                                                        , out int recordCount);
                                                                
        DataTable GetHistoryByColumns(int inUserId);
	}
}
