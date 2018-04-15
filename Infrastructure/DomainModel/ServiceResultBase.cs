using Infrastructure.DomainModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Infrastructure.Services
{
    public abstract class ServiceResultBase
    {
        [DebuggerStepThrough]
        protected ServiceResultBase(IEnumerable<RuleViolation> ruleViolations)
        {
            RuleViolations = new List<RuleViolation>(ruleViolations);
            ViolationType = ViolationType.Default;
        }

        public IList<RuleViolation> RuleViolations
        {
            get;
            private set;
        }
        public string MergeErrorMessages()
        {
            return ErrorMessage;
        }

        public bool HasViolation
        {
            get { return RuleViolations.Count > 0; }
        }
        public ViolationType ViolationType
        {
            get;
            set;
        }
        public string ErrorMessage
        {
            get
            {
                string msg = string.Empty;
                if (RuleViolations != null && RuleViolations.Count > 0)
                {
                    foreach (RuleViolation item in RuleViolations)
                    {
                        if (msg != string.Empty)
                            msg += "\r\n";
                        msg += item.ErrorMessage;
                    }
                }
                return msg;
            }
        }
    }

    public enum ViolationType
    {
        Default,
        Validation,
        Exception,
        Operational
    }
}