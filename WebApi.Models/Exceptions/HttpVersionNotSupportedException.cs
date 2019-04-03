using System.Net;
using WebApi.Models.Response;

namespace WebApi.Models.Exceptions
{
    public class HttpVersionNotSupportedException : ApiException
    {
        private static HttpStatusCode CurrentStatusCode => HttpStatusCode.HttpVersionNotSupported;

        public HttpVersionNotSupportedException()
            : base(CurrentStatusCode) { }

        public HttpVersionNotSupportedException(string message, string property = null)
            : base(CurrentStatusCode, message, property) { }
        
        public HttpVersionNotSupportedException(ErrorsResponse errorsResponse)
            : base(CurrentStatusCode, errorsResponse) { }

        public HttpVersionNotSupportedException(ErrorsResponse errorsResponse, string message)
            : base(CurrentStatusCode, errorsResponse, message) { }
    }
}