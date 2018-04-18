
using System;
using Infrastructure.DomainModel;

namespace YYP.Entities
{
	/// <summary>
	/// Order object mapped to table 'TYYP_Order'.
	/// </summary>
	public class Order : EntityBase
	{	
		#region Constructors

		public  Order() { }

		public  Order( string orderId, string studioHostUserId, string merchantUserId, string shopGuid, string checkStatus, string orderNo, string orderStatus, DateTime createTime, DateTime faHuoTime, DateTime daoHuoTime, DateTime tuiHuoTime, DateTime tuiFeiTime, string logisticName, string logisticNo, string tuiHuoLogisticName, string tuiHuoLogisticNo, decimal tuiHuoPostage, string merchantToStudioHos, int merchantGiveStudioHosStars, string studioHosToMerchant, int studioHosGiveMerchantStars, DateTime broadcastScheduling, string directionalPlanStatus, int postageStatisticsMark )
		{
			this.OrderId = orderId;
			this.StudioHostUserId = studioHostUserId;
			this.MerchantUserId = merchantUserId;
			this.ShopGuid = shopGuid;
			this.CheckStatus = checkStatus;
			this.OrderNo = orderNo;
			this.OrderStatus = orderStatus;
			this.CreateTime = createTime;
			this.FaHuoTime = faHuoTime;
			this.DaoHuoTime = daoHuoTime;
			this.TuiHuoTime = tuiHuoTime;
			this.TuiFeiTime = tuiFeiTime;
			this.LogisticName = logisticName;
			this.LogisticNo = logisticNo;
			this.TuiHuoLogisticName = tuiHuoLogisticName;
			this.TuiHuoLogisticNo = tuiHuoLogisticNo;
			this.TuiHuoPostage = tuiHuoPostage;
			this.MerchantToStudioHos = merchantToStudioHos;
			this.MerchantGiveStudioHosStars = merchantGiveStudioHosStars;
			this.StudioHosToMerchant = studioHosToMerchant;
			this.StudioHosGiveMerchantStars = studioHosGiveMerchantStars;
			this.BroadcastScheduling = broadcastScheduling;
			this.DirectionalPlanStatus = directionalPlanStatus;
			this.PostageStatisticsMark = postageStatisticsMark;
		}
		
		#endregion

		#region Public Properties

		public string OrderId { get; set; }
		public string StudioHostUserId { get; set; }
		public string MerchantUserId { get; set; }
		public string ShopGuid { get; set; }
		public string CheckStatus { get; set; }
		public string OrderNo { get; set; }
		public string OrderStatus { get; set; }
		public DateTime? CreateTime { get; set; }
		public DateTime? FaHuoTime { get; set; }
		public DateTime? DaoHuoTime { get; set; }
		public DateTime? TuiHuoTime { get; set; }
		public DateTime? TuiFeiTime { get; set; }
		public string LogisticName { get; set; }
		public string LogisticNo { get; set; }
		public string TuiHuoLogisticName { get; set; }
		public string TuiHuoLogisticNo { get; set; }
		public decimal TuiHuoPostage { get; set; }
		public string MerchantToStudioHos { get; set; }
		public int MerchantGiveStudioHosStars { get; set; }
		public string StudioHosToMerchant { get; set; }
		public int StudioHosGiveMerchantStars { get; set; }
		public DateTime BroadcastScheduling { get; set; }
		public string DirectionalPlanStatus { get; set; }
		public int PostageStatisticsMark { get; set; }
        
		#endregion
	}
}