using System.Collections.Generic;
using Kingston.ComLib.DomainModel;
using WebAPI.Entities; 

namespace WebAPI.Services
{
	public interface IOrderService : IService<Order>
	{				
		OrderServiceResult Add(Order inOrder);
		
		OrderServiceResult Update(Order inOrder);
		
		OrderServiceResult Delete(int inOrderId);
		
		OrderServiceResult GetById(int inOrder);	
		
		IEnumerable<Order> GetAll();
        
        OrderServiceResult Save(Order inOrder);

        IEnumerable<Order> GetPagedOrder(int? pageIndex
                                         , int itemsPerPage
                                         , string sortField
                                         , string sort
                                         , out int recordCount);
	}
}

