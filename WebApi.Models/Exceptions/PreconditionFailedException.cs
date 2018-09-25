using System.Net;
using WebApi.Models.Response;

namespace WebApi.Models.Exceptions
{
    public class PreconditionFailedException : ApiException
    {
        private static HttpStatusCode CurrentStatusCode => HttpStatusCode.PreconditionFailed;

        public PreconditionFailedException()
            : base(CurrentStatusCode) { }

        public PreconditionFailedException(string message)
            : base(CurrentStatusCode, message) { }
        
        public PreconditionFailedException(ErrorsResponse errorsResponse)
            : base(CurrentStatusCode, errorsResponse) { }

        public PreconditionFailedException(ErrorsResponse errorsResponse, string message)
            : base(CurrentStatusCode, errorsResponse, message) { }
    }
}