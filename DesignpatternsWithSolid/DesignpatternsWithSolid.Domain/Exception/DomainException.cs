using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignpatternsWithSolid.Domain.Exception
{

    [Serializable]
    public class DomainException : System.Exception
    {
        public DomainException() { }
        public DomainException(string message) : base(message) { }
        public DomainException(string message, System.Exception inner) : base(message, inner) { }
        protected DomainException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
