using System.Collections.Generic;
using Infrastructure.Services;

using YYP.Entities;
using YYP.Repository;

namespace YYP.Services
{
	public class ShopService : ServiceBase<Shop>,IShopService
	{
		
		private readonly IShopRepository _shopRepository;
		
		public ShopService(IShopRepository shopRepository)
		{
			this._shopRepository = shopRepository;
		}
        
	}
}

