using System;
using System.Runtime.Serialization;

namespace Chinook.Operations.Application.Services
{

    [Serializable]
    public class ApplicationServiceException : Exception
    {
        public ApplicationServiceException() { }
        public ApplicationServiceException(string message) : base(message) { }
        public ApplicationServiceException(string message, Exception inner) : base(message, inner) { }
        protected ApplicationServiceException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
