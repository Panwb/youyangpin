
using System;
using Infrastructure.DomainModel;

namespace YYP.Entities
{
    /// <summary>
    /// Good object mapped to table 'TYYP_Goods'.
    /// </summary>
    public class Good : EntityBase
	{	
		#region Constructors

		public  Good() { }

		public  Good( string goodsId, string userId, string shopId, string goodsImgURL, string goodsName, string goodsURL, string activityType, decimal dailyPrice, decimal livePrice, decimal commissionRatio, string commissionURL, int inventoryNum, int supplyNum, string isProvideMulticolor, int colorNum, int sales, string preferentialWay, string needSendBack, string sellingPointDescribe, string couponsURL, DateTime activityBeginTime, DateTime activityEndTime, string fansOrAverageDailyViews, int averageDailyViewsHight, int averageDailyViewsLow, int fansHight, int fansLow, string checkStatus, int deleteMark )
		{
			this.GoodsId = goodsId;
			this.UserId = userId;
			this.ShopId = shopId;
			this.GoodsImgURL = goodsImgURL;
			this.GoodsName = goodsName;
			this.GoodsURL = goodsURL;
			this.ActivityType = activityType;
			this.DailyPrice = dailyPrice;
			this.LivePrice = livePrice;
			this.CommissionRatio = commissionRatio;
			this.CommissionURL = commissionURL;
			this.InventoryNum = inventoryNum;
			this.SupplyNum = supplyNum;
			this.IsProvideMulticolor = isProvideMulticolor;
			this.ColorNum = colorNum;
			this.Sales = sales;
			this.PreferentialWay = preferentialWay;
			this.NeedSendBack = needSendBack;
			this.SellingPointDescribe = sellingPointDescribe;
			this.CouponsURL = couponsURL;
			this.ActivityBeginTime = activityBeginTime;
			this.ActivityEndTime = activityEndTime;
			this.FansOrAverageDailyViews = fansOrAverageDailyViews;
			this.AverageDailyViewsHight = averageDailyViewsHight;
			this.AverageDailyViewsLow = averageDailyViewsLow;
			this.FansHight = fansHight;
			this.FansLow = fansLow;
			this.CheckStatus = checkStatus;
			this.DeleteMark = deleteMark;
		}
		
		#endregion

		#region Public Properties

		public string GoodsId { get; set; }
		public string UserId { get; set; }
		public string ShopId { get; set; }
		public string GoodsImgURL { get; set; }
		public string GoodsName { get; set; }
		public string GoodsURL { get; set; }
		public string ActivityType { get; set; }
		public decimal DailyPrice { get; set; }
		public decimal LivePrice { get; set; }
		public decimal CommissionRatio { get; set; }
		public string CommissionURL { get; set; }
		public int InventoryNum { get; set; }
		public int SupplyNum { get; set; }
		public string IsProvideMulticolor { get; set; }
		public int ColorNum { get; set; }
		public int Sales { get; set; }
		public string PreferentialWay { get; set; }
		public string NeedSendBack { get; set; }
		public string SellingPointDescribe { get; set; }
		public string CouponsURL { get; set; }
		public DateTime ActivityBeginTime { get; set; }
		public DateTime ActivityEndTime { get; set; }
		public string FansOrAverageDailyViews { get; set; }
		public int AverageDailyViewsHight { get; set; }
		public int AverageDailyViewsLow { get; set; }
		public int FansHight { get; set; }
		public int FansLow { get; set; }
		public string CheckStatus { get; set; }
		public int DeleteMark { get; set; }
        
		#endregion
	}
}