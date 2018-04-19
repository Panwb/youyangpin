using System.Collections.Generic;
using Infrastructure.Services;
using YYP.Entities;
using YYP.Repository;
using System.Linq;

namespace YYP.Services
{
	public class OrderService : ServiceBase<Order>, IOrderService
	{
		private readonly IOrderRepository _orderRepository;
		
		public OrderService(IOrderRepository orderRepository)
		{
			this._orderRepository = orderRepository;
		}

        public IEnumerable<OrderDto> GetOrderByUserId(string userId, string orderStatus)
        {
            var outOrders = new List<OrderDto>();
            var orders = _orderRepository.GetOrderByUserId(userId);
            if (orders != null)
            {
                foreach(var order in orders.Where(o => string.IsNullOrEmpty(orderStatus) || o.OrderStatus == orderStatus))
                {
                    order.Goods = _orderRepository.GetGoodsByOrderId(order.OrderID);

                    outOrders.Add(order);
                }
            }

            return outOrders;
        }
    }
}

