using System.Collections.Generic;
using Kingston.ComLib.DomainModel;
using WebAPI.Entities; 

namespace WebAPI.Services
{
	public interface IShopService : IService<Shop>
	{				
		ShopServiceResult Add(Shop inShop);
		
		ShopServiceResult Update(Shop inShop);
		
		ShopServiceResult Delete(int inShopId);
		
		ShopServiceResult GetById(int inShop);	
		
		IEnumerable<Shop> GetAll();
        
        ShopServiceResult Save(Shop inShop);

        IEnumerable<Shop> GetPagedShop(int? pageIndex
                                         , int itemsPerPage
                                         , string sortField
                                         , string sort
                                         , out int recordCount);
	}
}

