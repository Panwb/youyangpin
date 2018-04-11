using System.Collections.Generic;
using Infrastructure.DomainModel;
using Infrastructure.Services;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public class OrderServiceResult : ServiceResultBase
	{					
		public OrderServiceResult() : this(new List<RuleViolation>())
        { 
        }

        public OrderServiceResult(Order order)
            : this()
        {
            this.Order = order;
        }

        public OrderServiceResult(IEnumerable<RuleViolation> ruleViolations)
            : base(ruleViolations)
        { 
        }

        public Order Order
        {
            get;
            set;
        }        
	}
}

