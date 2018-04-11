using System.Collections.Generic;
using Kingston.ComLib.DomainModel;
using WebAPI.Entities; 

namespace WebAPI.Services
{
	public class ShopServiceResult : ServiceResultBase
	{					
		public ShopServiceResult() : this(new List<RuleViolation>())
        { 
        }

        public ShopServiceResult(Shop shop)
            : this()
        {
            this.Shop = shop;
        }

        public ShopServiceResult(IEnumerable<RuleViolation> ruleViolations)
            : base(ruleViolations)
        { 
        }

        public Shop Shop
        {
            get;
            set;
        }        
	}
}

