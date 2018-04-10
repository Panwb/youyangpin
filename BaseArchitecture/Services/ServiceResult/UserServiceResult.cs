using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.DomainModel;
using Infrastructure.Services;
using WebAPI.Entities;

namespace WebAPI.Services.ServiceResult
{
    public class UserServiceResult : ServiceResultBase
    {
        public UserServiceResult() : this(new List<RuleViolation>())
        {
        }

        public UserServiceResult(User user)
            : this()
        {
            this.User = user;
        }

        public UserServiceResult(IEnumerable<RuleViolation> ruleViolations)
            : base(ruleViolations)
        {
        }

        public User User
        {
            get;
            set;
        }
    }
}
