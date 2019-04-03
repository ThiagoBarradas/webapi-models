using System.Net;
using WebApi.Models.Response;

namespace WebApi.Models.Exceptions
{
    public class ExpectationFailedException : ApiException
    {
        private static HttpStatusCode CurrentStatusCode => HttpStatusCode.ExpectationFailed;

        public ExpectationFailedException()
            : base(CurrentStatusCode) { }

        public ExpectationFailedException(string message, string property = null)
            : base(CurrentStatusCode, message, property) { }
        
        public ExpectationFailedException(ErrorsResponse errorsResponse)
            : base(CurrentStatusCode, errorsResponse) { }

        public ExpectationFailedException(ErrorsResponse errorsResponse, string message)
            : base(CurrentStatusCode, errorsResponse, message) { }
    }
}