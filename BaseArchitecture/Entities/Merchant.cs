
using System;
using Kingston.ComLib.DomainModel;

namespace WebAPI.Entities
{
	#region WebAPI.Entities

	/// <summary>
	/// Merchant object mapped to table 'TYYP_Merchant'.
	/// </summary>
	public class Merchant : EntityBase
	{
		#region Column names
		
		//public const string CN_USERID = "UserId";
		//public const string CN_LINKMANNAME = "LinkmanName";
		//public const string CN_LINKMANPHONE = "LinkmanPhone";
		//public const string CN_WECHAT = "WeChat";
		//public const string CN_QQ = "QQ";
		//public const string CN_EMAIL = "Email";
		//public const string CN_ACCOUNTBALANCE = "AccountBalance";
		//public const string CN_DELETEMARK = "DeleteMark";
		
		#endregion
		
		#region Constructors

		public  Merchant() { }

		public  Merchant( string userId, string linkmanName, string linkmanPhone, string weChat, string qQ, string email, decimal accountBalance, int deleteMark )
		{
			this.UserId = userId;
			this.LinkmanName = linkmanName;
			this.LinkmanPhone = linkmanPhone;
			this.WeChat = weChat;
			this.QQ = qQ;
			this.Email = email;
			this.AccountBalance = accountBalance;
			this.DeleteMark = deleteMark;
		}
		
		#endregion

		#region Public Properties

		public string UserId { get; set; }
		public string LinkmanName { get; set; }
		public string LinkmanPhone { get; set; }
		public string WeChat { get; set; }
		public string QQ { get; set; }
		public string Email { get; set; }
		public decimal AccountBalance { get; set; }
		public int DeleteMark { get; set; }
        
		#endregion
	}
	#endregion
}