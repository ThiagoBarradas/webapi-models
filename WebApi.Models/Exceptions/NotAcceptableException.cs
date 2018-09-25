using System.Net;
using WebApi.Models.Response;

namespace WebApi.Models.Exceptions
{
    public class NotAcceptableException : ApiException
    {
        private static HttpStatusCode CurrentStatusCode => HttpStatusCode.NotAcceptable;

        public NotAcceptableException()
            : base(CurrentStatusCode) { }

        public NotAcceptableException(string message)
            : base(CurrentStatusCode, message) { }
        
        public NotAcceptableException(ErrorsResponse errorsResponse)
            : base(CurrentStatusCode, errorsResponse) { }

        public NotAcceptableException(ErrorsResponse errorsResponse, string message)
            : base(CurrentStatusCode, errorsResponse, message) { }
    }
}