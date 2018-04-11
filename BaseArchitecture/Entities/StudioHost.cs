
using System;
using Kingston.ComLib.DomainModel;

namespace WebAPI.Entities
{
	#region WebAPI.Entities

	/// <summary>
	/// StudioHost object mapped to table 'TYYP_StudioHost'.
	/// </summary>
	public class StudioHost : EntityBase
	{
		#region Column names
		
		//public const string CN_USERID = "UserId";
		//public const string CN_STUDIOHOSTNAME = "StudioHostName";
		//public const string CN_TKNAME = "TKName";
		//public const string CN_HEIGHT = "Height";
		//public const string CN_WEIGHT = "Weight";
		//public const string CN_SHOESIZE = "ShoeSize";
		//public const string CN_CLOTHESSIZE = "ClothesSize";
		//public const string CN_ADDRESS = "Address";
		//public const string CN_LINKMANNAME = "LinkmanName";
		//public const string CN_LINKMANPHONE = "LinkmanPhone";
		//public const string CN_WECHAT = "WeChat";
		//public const string CN_QQ = "QQ";
		//public const string CN_EMAIL = "Email";
		//public const string CN_FANSNUM = "FansNum";
		//public const string CN_AVERAGEDAILYVIEWS = "AverageDailyViews";
		//public const string CN_VERTICALFIELDCODE = "VerticalFieldCode";
		//public const string CN_MAINPOPACTIVITYTYPE = "MainPopActivityType";
		//public const string CN_PERCUSTOMERTRANSACTIONHIGHT = "PerCustomerTransactionHight";
		//public const string CN_PERCUSTOMERTRANSACTIONLOW = "PerCustomerTransactionLow";
		//public const string CN_ALIPAYACCOUNT = "AlipayAccount";
		//public const string CN_ACCOUNTBALANCE = "AccountBalance";
		//public const string CN_MARGIN = "Margin";
		//public const string CN_CHECKSTATUS = "CheckStatus";
		//public const string CN_REMARK = "Remark";
		//public const string CN_DAILYBEGINTIME = "DailyBeginTime";
		//public const string CN_DAILYENDTIME = "DailyEndTime";
		//public const string CN_DELETEMARK = "DeleteMark";
		
		#endregion
		
		#region Constructors

		public  StudioHost() { }

		public  StudioHost( string userId, string studioHostName, string tKName, int height, int weight, int shoeSize, string clothesSize, string address, string linkmanName, string linkmanPhone, string weChat, string qQ, string email, int fansNum, int averageDailyViews, string verticalFieldCode, string mainPopActivityType, decimal perCustomerTransactionHight, decimal perCustomerTransactionLow, string alipayAccount, decimal accountBalance, decimal margin, string checkStatus, string remark, DateTime dailyBeginTime, DateTime dailyEndTime, int deleteMark )
		{
			this.UserId = userId;
			this.StudioHostName = studioHostName;
			this.TKName = tKName;
			this.Height = height;
			this.Weight = weight;
			this.ShoeSize = shoeSize;
			this.ClothesSize = clothesSize;
			this.Address = address;
			this.LinkmanName = linkmanName;
			this.LinkmanPhone = linkmanPhone;
			this.WeChat = weChat;
			this.QQ = qQ;
			this.Email = email;
			this.FansNum = fansNum;
			this.AverageDailyViews = averageDailyViews;
			this.VerticalFieldCode = verticalFieldCode;
			this.MainPopActivityType = mainPopActivityType;
			this.PerCustomerTransactionHight = perCustomerTransactionHight;
			this.PerCustomerTransactionLow = perCustomerTransactionLow;
			this.AlipayAccount = alipayAccount;
			this.AccountBalance = accountBalance;
			this.Margin = margin;
			this.CheckStatus = checkStatus;
			this.Remark = remark;
			this.DailyBeginTime = dailyBeginTime;
			this.DailyEndTime = dailyEndTime;
			this.DeleteMark = deleteMark;
		}
		
		#endregion

		#region Public Properties

		public string UserId { get; set; }
		public string StudioHostName { get; set; }
		public string TKName { get; set; }
		public int Height { get; set; }
		public int Weight { get; set; }
		public int ShoeSize { get; set; }
		public string ClothesSize { get; set; }
		public string Address { get; set; }
		public string LinkmanName { get; set; }
		public string LinkmanPhone { get; set; }
		public string WeChat { get; set; }
		public string QQ { get; set; }
		public string Email { get; set; }
		public int FansNum { get; set; }
		public int AverageDailyViews { get; set; }
		public string VerticalFieldCode { get; set; }
		public string MainPopActivityType { get; set; }
		public decimal PerCustomerTransactionHight { get; set; }
		public decimal PerCustomerTransactionLow { get; set; }
		public string AlipayAccount { get; set; }
		public decimal AccountBalance { get; set; }
		public decimal Margin { get; set; }
		public string CheckStatus { get; set; }
		public string Remark { get; set; }
		public DateTime DailyBeginTime { get; set; }
		public DateTime DailyEndTime { get; set; }
		public int DeleteMark { get; set; }
        
		#endregion
	}
	#endregion
}