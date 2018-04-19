using System.Collections.Generic;
using Infrastructure.Repository;
using YYP.ComLib;
using YYP.Entities;

namespace YYP.Repository
{
	public interface IOrderRepository : IRepository<Order>
	{
        IEnumerable<OrderDto> GetOrderByUserId(string userId);
        IEnumerable<Good> GetGoodsByOrderId(string orderId);
    }
}
