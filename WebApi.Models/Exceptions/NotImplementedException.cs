using System.Net;
using WebApi.Models.Response;

namespace WebApi.Models.Exceptions
{
    public class NotImplementedException : ApiException
    {
        private static HttpStatusCode CurrentStatusCode => HttpStatusCode.NotImplemented;

        public NotImplementedException()
            : base(CurrentStatusCode) { }

        public NotImplementedException(string message)
            : base(CurrentStatusCode, message) { }
        
        public NotImplementedException(ErrorsResponse errorsResponse)
            : base(CurrentStatusCode, errorsResponse) { }

        public NotImplementedException(ErrorsResponse errorsResponse, string message)
            : base(CurrentStatusCode, errorsResponse, message) { }
    }
}