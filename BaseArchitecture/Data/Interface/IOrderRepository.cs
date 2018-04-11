using System;
using System.Data;
using System.Collections.Generic;
using Kingston.ComLib.Data; 
using WebAPI.Entities; 

namespace Kingston.KCMS.Data
{
	public interface IOrderRepository : IRepository<Order>
	{
        
    
		IEnumerable<Order> GetPagedOrder(int? pageIndex
                                                        , int itemsPerPage
                                                        , string sortField
                                                        , string sort
                                                        , out int recordCount);
                                                                
        DataTable GetHistoryByColumns(int inOrderId);
	}
}
