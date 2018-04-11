
using System;
using Kingston.ComLib.DomainModel;

namespace WebAPI.Entities
{
	#region WebAPI.Entities

	/// <summary>
	/// OrderGood object mapped to table 'TYYP_OrderGoods'.
	/// </summary>
	public class OrderGood : EntityBase
	{
		#region Column names
		
		//public const string CN_ORDERGOODSID = "OrderGoodsId";
		//public const string CN_ORDERID = "OrderId";
		//public const string CN_GOODSID = "GoodsId";
		
		#endregion
		
		#region Constructors

		public  OrderGood() { }

		public  OrderGood( string orderGoodsId, string orderId, string goodsId )
		{
			this.OrderGoodsId = orderGoodsId;
			this.OrderId = orderId;
			this.GoodsId = goodsId;
		}
		
		#endregion

		#region Public Properties

		public string OrderGoodsId { get; set; }
		public string OrderId { get; set; }
		public string GoodsId { get; set; }
        
		#endregion
	}
	#endregion
}