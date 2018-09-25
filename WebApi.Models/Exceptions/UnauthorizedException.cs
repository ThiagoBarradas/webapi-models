using System.Net;
using WebApi.Models.Response;

namespace WebApi.Models.Exceptions
{
    public class UnauthorizedException : ApiException
    {
        private static HttpStatusCode CurrentStatusCode => HttpStatusCode.Unauthorized;

        public UnauthorizedException()
            : base(CurrentStatusCode) { }

        public UnauthorizedException(string message)
            : base(CurrentStatusCode, message) { }
        
        public UnauthorizedException(ErrorsResponse errorsResponse)
            : base(CurrentStatusCode, errorsResponse) { }

        public UnauthorizedException(ErrorsResponse errorsResponse, string message)
            : base(CurrentStatusCode, errorsResponse, message) { }
    }
}