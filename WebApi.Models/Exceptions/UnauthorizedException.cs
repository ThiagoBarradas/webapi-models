using System.Net;
using WebApi.Models.Response;

namespace WebApi.Models.Exceptions
{
    public class UnauthorizedException : ApiException
    {
        private static HttpStatusCode CurrentStatusCode => HttpStatusCode.Unauthorized;

        public UnauthorizedException()
            : base(CurrentStatusCode) { }

        public UnauthorizedException(string message, string property = null)
            : base(CurrentStatusCode, message, property) { }
        
        public UnauthorizedException(ErrorsResponse errorsResponse)
            : base(CurrentStatusCode, errorsResponse) { }

        public UnauthorizedException(ErrorsResponse errorsResponse, string message)
            : base(CurrentStatusCode, errorsResponse, message) { }
    }
}