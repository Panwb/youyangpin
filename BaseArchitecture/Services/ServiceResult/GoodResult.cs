using System.Collections.Generic;
using Infrastructure.DomainModel;
using Infrastructure.Services;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public class GoodServiceResult : ServiceResultBase
	{					
		public GoodServiceResult() : this(new List<RuleViolation>())
        { 
        }

        public GoodServiceResult(Good good)
            : this()
        {
            this.Good = good;
        }

        public GoodServiceResult(IEnumerable<RuleViolation> ruleViolations)
            : base(ruleViolations)
        { 
        }

        public Good Good
        {
            get;
            set;
        }        
	}
}

