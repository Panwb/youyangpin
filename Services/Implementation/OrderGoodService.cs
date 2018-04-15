using Infrastructure.Services;
using YYP.Entities;
using YYP.Repository;

namespace YYP.Services
{
    public class OrderGoodService : ServiceBase<OrderGood>,IOrderGoodService
	{
		private readonly IOrderGoodRepository _orderGoodRepository;
		
		public OrderGoodService(IOrderGoodRepository orderGoodRepository)
		{
			this._orderGoodRepository = orderGoodRepository;
		}
        
	}
}

