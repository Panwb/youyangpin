using System.Collections.Generic;
using Kingston.ComLib.DomainModel;
using WebAPI.Entities; 

namespace WebAPI.Services
{
	public class WithdrawalServiceResult : ServiceResultBase
	{					
		public WithdrawalServiceResult() : this(new List<RuleViolation>())
        { 
        }

        public WithdrawalServiceResult(Withdrawal withdrawal)
            : this()
        {
            this.Withdrawal = withdrawal;
        }

        public WithdrawalServiceResult(IEnumerable<RuleViolation> ruleViolations)
            : base(ruleViolations)
        { 
        }

        public Withdrawal Withdrawal
        {
            get;
            set;
        }        
	}
}

