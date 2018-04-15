using System.Collections.Generic;
using Infrastructure.Services;
using YYP.Entities;
using YYP.Repository;

namespace YYP.Services
{
	public class OrderService : ServiceBase<Order>,IOrderService
	{
		private readonly IOrderRepository _orderRepository;
		
		public OrderService(IOrderRepository orderRepository)
		{
			this._orderRepository = orderRepository;
		}
        
	}
}

