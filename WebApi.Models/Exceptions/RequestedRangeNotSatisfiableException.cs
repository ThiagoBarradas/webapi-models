using System.Net;
using WebApi.Models.Response;

namespace WebApi.Models.Exceptions
{
    public class RequestedRangeNotSatisfiableException : ApiException
    {
        private static HttpStatusCode CurrentStatusCode => HttpStatusCode.RequestedRangeNotSatisfiable;

        public RequestedRangeNotSatisfiableException()
            : base(CurrentStatusCode) { }

        public RequestedRangeNotSatisfiableException(string message, string property = null)
            : base(CurrentStatusCode, message, property) { }
        
        public RequestedRangeNotSatisfiableException(ErrorsResponse errorsResponse)
            : base(CurrentStatusCode, errorsResponse) { }

        public RequestedRangeNotSatisfiableException(ErrorsResponse errorsResponse, string message)
            : base(CurrentStatusCode, errorsResponse, message) { }
    }
}