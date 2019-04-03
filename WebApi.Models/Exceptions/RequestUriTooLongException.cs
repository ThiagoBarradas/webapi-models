using System.Net;
using WebApi.Models.Response;

namespace WebApi.Models.Exceptions
{
    public class RequestUriTooLongException : ApiException
    {
        private static HttpStatusCode CurrentStatusCode => HttpStatusCode.RequestUriTooLong;

        public RequestUriTooLongException()
            : base(CurrentStatusCode) { }

        public RequestUriTooLongException(string message, string property = null)
            : base(CurrentStatusCode, message, property) { }
        
        public RequestUriTooLongException(ErrorsResponse errorsResponse)
            : base(CurrentStatusCode, errorsResponse) { }

        public RequestUriTooLongException(ErrorsResponse errorsResponse, string message)
            : base(CurrentStatusCode, errorsResponse, message) { }
    }
}