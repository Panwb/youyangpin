using Infrastructure.Services;
using System.Collections.Generic;
using YYP.Entities;

namespace YYP.Services
{
	public interface IOrderService : IService<Order>
	{
        IEnumerable<OrderDto> GetOrderByUserId(string userId, string orderStatus);
    }
}

