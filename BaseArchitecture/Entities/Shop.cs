
using System;
using Kingston.ComLib.DomainModel;

namespace WebAPI.Entities
{
	#region WebAPI.Entities

	/// <summary>
	/// Shop object mapped to table 'TYYP_Shop'.
	/// </summary>
	public class Shop : EntityBase
	{
		#region Column names
		
		//public const string CN_SHOPID = "ShopId";
		//public const string CN_USERID = "UserId";
		//public const string CN_SHOPTYPE = "ShopType";
		//public const string CN_SHOPNAME = "ShopName";
		//public const string CN_VERTICALFIELDCODE = "VerticalFieldCode";
		//public const string CN_SHOPURL = "ShopURL";
		//public const string CN_WANGWANGNO = "WangWangNo";
		//public const string CN_SHOPADDRESS = "ShopAddress";
		//public const string CN_DESCRIPTIONMATCH = "DescriptionMatch";
		//public const string CN_SERVICEATTITUDE = "ServiceAttitude";
		//public const string CN_LOGISTICSSERVICE = "LogisticsService";
		//public const string CN_CHECKSTATUS = "CheckStatus";
		//public const string CN_DELETEMARK = "DeleteMark";
		
		#endregion
		
		#region Constructors

		public  Shop() { }

		public  Shop( string shopId, string userId, string shopType, string shopName, string verticalFieldCode, string shopURL, string wangWangNo, string shopAddress, decimal descriptionMatch, decimal serviceAttitude, decimal logisticsService, string checkStatus, int deleteMark )
		{
			this.ShopId = shopId;
			this.UserId = userId;
			this.ShopType = shopType;
			this.ShopName = shopName;
			this.VerticalFieldCode = verticalFieldCode;
			this.ShopURL = shopURL;
			this.WangWangNo = wangWangNo;
			this.ShopAddress = shopAddress;
			this.DescriptionMatch = descriptionMatch;
			this.ServiceAttitude = serviceAttitude;
			this.LogisticsService = logisticsService;
			this.CheckStatus = checkStatus;
			this.DeleteMark = deleteMark;
		}
		
		#endregion

		#region Public Properties

		public string ShopId { get; set; }
		public string UserId { get; set; }
		public string ShopType { get; set; }
		public string ShopName { get; set; }
		public string VerticalFieldCode { get; set; }
		public string ShopURL { get; set; }
		public string WangWangNo { get; set; }
		public string ShopAddress { get; set; }
		public decimal DescriptionMatch { get; set; }
		public decimal ServiceAttitude { get; set; }
		public decimal LogisticsService { get; set; }
		public string CheckStatus { get; set; }
		public int DeleteMark { get; set; }
        
		#endregion
	}
	#endregion
}