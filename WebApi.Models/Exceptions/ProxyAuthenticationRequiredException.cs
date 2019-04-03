using System.Net;
using WebApi.Models.Response;

namespace WebApi.Models.Exceptions
{
    public class ProxyAuthenticationRequiredException : ApiException
    {
        private static HttpStatusCode CurrentStatusCode => HttpStatusCode.ProxyAuthenticationRequired;

        public ProxyAuthenticationRequiredException()
            : base(CurrentStatusCode) { }

        public ProxyAuthenticationRequiredException(string message, string property = null)
            : base(CurrentStatusCode, message, property) { }
        
        public ProxyAuthenticationRequiredException(ErrorsResponse errorsResponse)
            : base(CurrentStatusCode, errorsResponse) { }

        public ProxyAuthenticationRequiredException(ErrorsResponse errorsResponse, string message)
            : base(CurrentStatusCode, errorsResponse, message) { }
    }
}