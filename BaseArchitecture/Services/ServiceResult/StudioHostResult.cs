using System.Collections.Generic;
using Kingston.ComLib.DomainModel;
using WebAPI.Entities; 

namespace WebAPI.Services
{
	public class StudioHostServiceResult : ServiceResultBase
	{					
		public StudioHostServiceResult() : this(new List<RuleViolation>())
        { 
        }

        public StudioHostServiceResult(StudioHost studioHost)
            : this()
        {
            this.StudioHost = studioHost;
        }

        public StudioHostServiceResult(IEnumerable<RuleViolation> ruleViolations)
            : base(ruleViolations)
        { 
        }

        public StudioHost StudioHost
        {
            get;
            set;
        }        
	}
}

