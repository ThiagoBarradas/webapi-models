using System.Net;
using WebApi.Models.Response;

namespace WebApi.Models.Exceptions
{
    public class MethodNotAllowedException : ApiException
    {
        private static HttpStatusCode CurrentStatusCode => HttpStatusCode.MethodNotAllowed;

        public MethodNotAllowedException()
            : base(CurrentStatusCode) { }

        public MethodNotAllowedException(string message, string property = null)
            : base(CurrentStatusCode, message, property) { }
        
        public MethodNotAllowedException(ErrorsResponse errorsResponse)
            : base(CurrentStatusCode, errorsResponse) { }

        public MethodNotAllowedException(ErrorsResponse errorsResponse, string message)
            : base(CurrentStatusCode, errorsResponse, message) { }
    }
}