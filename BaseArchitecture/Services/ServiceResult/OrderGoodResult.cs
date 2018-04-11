using System.Collections.Generic;
using Kingston.ComLib.DomainModel;
using WebAPI.Entities; 

namespace WebAPI.Services
{
	public class OrderGoodServiceResult : ServiceResultBase
	{					
		public OrderGoodServiceResult() : this(new List<RuleViolation>())
        { 
        }

        public OrderGoodServiceResult(OrderGood orderGood)
            : this()
        {
            this.OrderGood = orderGood;
        }

        public OrderGoodServiceResult(IEnumerable<RuleViolation> ruleViolations)
            : base(ruleViolations)
        { 
        }

        public OrderGood OrderGood
        {
            get;
            set;
        }        
	}
}

