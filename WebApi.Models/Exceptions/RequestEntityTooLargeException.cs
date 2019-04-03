using System.Net;
using WebApi.Models.Response;

namespace WebApi.Models.Exceptions
{
    public class RequestEntityTooLargeException : ApiException
    {
        private static HttpStatusCode CurrentStatusCode => HttpStatusCode.RequestEntityTooLarge;

        public RequestEntityTooLargeException()
            : base(CurrentStatusCode) { }

        public RequestEntityTooLargeException(string message, string property = null)
            : base(CurrentStatusCode, message, property) { }
        
        public RequestEntityTooLargeException(ErrorsResponse errorsResponse)
            : base(CurrentStatusCode, errorsResponse) { }

        public RequestEntityTooLargeException(ErrorsResponse errorsResponse, string message)
            : base(CurrentStatusCode, errorsResponse, message) { }
    }
}