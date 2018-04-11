
using System;
using Kingston.ComLib.DomainModel;

namespace WebAPI.Entities
{
	#region WebAPI.Entities

	/// <summary>
	/// Withdrawal object mapped to table 'TYYP_Withdrawal'.
	/// </summary>
	public class Withdrawal : EntityBase
	{
		#region Column names
		
		//public const string CN_WITHDRAWALRID = "WithdrawalrId";
		//public const string CN_WITHDRAWALRUSERID = "WithdrawalrUserId";
		//public const string CN_WITHDRAWALRMONEY = "WithdrawalrMoney";
		//public const string CN_APPLYTIME = "ApplyTime";
		//public const string CN_HANDLESTATUS = "HandleStatus";
		//public const string CN_HANDLETIME = "HandleTime";
		//public const string CN_HANDLEUSERID = "HandleUserId";
		
		#endregion
		
		#region Constructors

		public  Withdrawal() { }

		public  Withdrawal( string withdrawalrId, string withdrawalrUserId, decimal withdrawalrMoney, DateTime applyTime, string handleStatus, DateTime handleTime, string handleUserId )
		{
			this.WithdrawalrId = withdrawalrId;
			this.WithdrawalrUserId = withdrawalrUserId;
			this.WithdrawalrMoney = withdrawalrMoney;
			this.ApplyTime = applyTime;
			this.HandleStatus = handleStatus;
			this.HandleTime = handleTime;
			this.HandleUserId = handleUserId;
		}
		
		#endregion

		#region Public Properties

		public string WithdrawalrId { get; set; }
		public string WithdrawalrUserId { get; set; }
		public decimal WithdrawalrMoney { get; set; }
		public DateTime ApplyTime { get; set; }
		public string HandleStatus { get; set; }
		public DateTime HandleTime { get; set; }
		public string HandleUserId { get; set; }
        
		#endregion
	}
	#endregion
}