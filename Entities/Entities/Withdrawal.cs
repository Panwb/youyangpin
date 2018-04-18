
using System;
using Infrastructure.DomainModel;

namespace YYP.Entities
{

    /// <summary>
    /// Withdrawal object mapped to table 'TYYP_Withdrawal'.
    /// </summary>
    public class Withdrawal : EntityBase
	{
		
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
		public DateTime? ApplyTime { get; set; }
		public string HandleStatus { get; set; }
		public DateTime? HandleTime { get; set; }
		public string HandleUserId { get; set; }
        
		#endregion
	}

}