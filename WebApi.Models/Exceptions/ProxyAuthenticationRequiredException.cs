using System.Net;
using WebApi.Models.Response;

namespace WebApi.Models.Exceptions
{
    public class ProxyAuthenticationRequiredException : ApiException
    {
        private static HttpStatusCode CurrentStatusCode => HttpStatusCode.ProxyAuthenticationRequired;

        public ProxyAuthenticationRequiredException()
            : base(CurrentStatusCode) { }

        public ProxyAuthenticationRequiredException(string message)
            : base(CurrentStatusCode, message) { }
        
        public ProxyAuthenticationRequiredException(ErrorsResponse errorsResponse)
            : base(CurrentStatusCode, errorsResponse) { }

        public ProxyAuthenticationRequiredException(ErrorsResponse errorsResponse, string message)
            : base(CurrentStatusCode, errorsResponse, message) { }
    }
}