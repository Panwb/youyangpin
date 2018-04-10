using System.Diagnostics;
using System.Runtime.Serialization;

namespace Infrastructure.DomainModel
{
    [DataContract]
    public class RuleViolation
    {
        [DebuggerStepThrough]
        public RuleViolation(string parameterName, string errorMessage)
        {
            ParameterName = parameterName;
            ErrorMessage = errorMessage;
        }
        [DataMember]
        public string ParameterName
        {
            get;
            private set;
        }
        [DataMember]
        public string ErrorMessage
        {
            get;
            private set;
        }
    }
}