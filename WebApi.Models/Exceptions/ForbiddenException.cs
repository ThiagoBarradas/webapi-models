using System.Net;
using WebApi.Models.Response;

namespace WebApi.Models.Exceptions
{
    public class ForbiddenException : ApiException
    {
        private static HttpStatusCode CurrentStatusCode => HttpStatusCode.Forbidden;

        public ForbiddenException()
            : base(CurrentStatusCode) { }

        public ForbiddenException(string message, string property = null)
            : base(CurrentStatusCode, message, property) { }
        
        public ForbiddenException(ErrorsResponse errorsResponse)
            : base(CurrentStatusCode, errorsResponse) { }

        public ForbiddenException(ErrorsResponse errorsResponse, string message)
            : base(CurrentStatusCode, errorsResponse, message) { }
    }
}