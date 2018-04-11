using System.Collections.Generic;
using Kingston.ComLib.DomainModel;
using WebAPI.Entities; 

namespace WebAPI.Services
{
	public interface IOrderGoodService : IService<OrderGood>
	{				
		OrderGoodServiceResult Add(OrderGood inOrderGood);
		
		OrderGoodServiceResult Update(OrderGood inOrderGood);
		
		OrderGoodServiceResult Delete(int inOrderGoodsId);
		
		OrderGoodServiceResult GetById(int inOrderGood);	
		
		IEnumerable<OrderGood> GetAll();
        
        OrderGoodServiceResult Save(OrderGood inOrderGood);

        IEnumerable<OrderGood> GetPagedOrderGood(int? pageIndex
                                         , int itemsPerPage
                                         , string sortField
                                         , string sort
                                         , out int recordCount);
	}
}

