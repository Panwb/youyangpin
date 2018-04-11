using System.Collections.Generic;
using Kingston.ComLib.DomainModel;
using WebAPI.Entities; 

namespace WebAPI.Services
{
	public class MerchantServiceResult : ServiceResultBase
	{					
		public MerchantServiceResult() : this(new List<RuleViolation>())
        { 
        }

        public MerchantServiceResult(Merchant merchant)
            : this()
        {
            this.Merchant = merchant;
        }

        public MerchantServiceResult(IEnumerable<RuleViolation> ruleViolations)
            : base(ruleViolations)
        { 
        }

        public Merchant Merchant
        {
            get;
            set;
        }        
	}
}

