using System.Net;
using WebApi.Models.Response;

namespace WebApi.Models.Exceptions
{
    public class ConflictException : ApiException
    {
        private static HttpStatusCode CurrentStatusCode => HttpStatusCode.Conflict;

        public ConflictException()
            : base(CurrentStatusCode) { }

        public ConflictException(string message, string property = null)
            : base(CurrentStatusCode, message, property) { }
        
        public ConflictException(ErrorsResponse errorsResponse)
            : base(CurrentStatusCode, errorsResponse) { }

        public ConflictException(ErrorsResponse errorsResponse, string message)
            : base(CurrentStatusCode, errorsResponse, message) { }
    }
}