using System.Collections.Generic;
using System.Data;
using Dapper;
using Infrastructure.Repository;
using YYP.ComLib;
using YYP.Entities;

namespace YYP.Repository
{
	/// <summary>
	/// Summary description for OrderRepository.
	/// </summary>
	public class OrderRepository : RepositoryBase<Order>, IOrderRepository
	{
		public OrderRepository(IDatabaseFactory db) : base(db)
		{
            
		}

        public IEnumerable<OrderDto> GetOrderByUserId(string userId)
        {
            return Database.Query<OrderDto>("[dbo].[Usp_TYYP_Order_SelectByUserId]", new { UserId = userId }, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<Good> GetGoodsByOrderId(string orderId)
        {
            return Database.Query<Good>("[dbo].[Usp_TYYP_Goods_SelectByOrderId]", new { OrderId = orderId }, commandType: CommandType.StoredProcedure);
        }
    }
}

