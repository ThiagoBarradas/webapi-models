using System.Net;
using WebApi.Models.Response;

namespace WebApi.Models.Exceptions
{
    public class RequestTimeoutException : ApiException
    {
        private static HttpStatusCode CurrentStatusCode => HttpStatusCode.RequestTimeout;

        public RequestTimeoutException()
            : base(CurrentStatusCode) { }

        public RequestTimeoutException(string message)
            : base(CurrentStatusCode, message) { }
        
        public RequestTimeoutException(ErrorsResponse errorsResponse)
            : base(CurrentStatusCode, errorsResponse) { }

        public RequestTimeoutException(ErrorsResponse errorsResponse, string message)
            : base(CurrentStatusCode, errorsResponse, message) { }
    }
}