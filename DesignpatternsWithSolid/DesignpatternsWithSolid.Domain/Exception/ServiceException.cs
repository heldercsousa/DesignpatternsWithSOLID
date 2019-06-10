namespace DesignpatternsWithSolid.Domain.Exception
{
    using System;
    [Serializable]
    public class ServiceException : System.Exception
    {
        public ServiceException() { }
        public ServiceException(string message) : base(message) { }
        public ServiceException(string message, System.Exception inner) : base(message, inner) { }
        protected ServiceException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

}
