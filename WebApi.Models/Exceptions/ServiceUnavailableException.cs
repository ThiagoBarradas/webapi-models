using System.Net;
using WebApi.Models.Response;

namespace WebApi.Models.Exceptions
{
    public class ServiceUnavailableException : ApiException
    {
        private static HttpStatusCode CurrentStatusCode => HttpStatusCode.ServiceUnavailable;

        public ServiceUnavailableException()
            : base(CurrentStatusCode) { }

        public ServiceUnavailableException(string message)
            : base(CurrentStatusCode, message) { }
        
        public ServiceUnavailableException(ErrorsResponse errorsResponse)
            : base(CurrentStatusCode, errorsResponse) { }

        public ServiceUnavailableException(ErrorsResponse errorsResponse, string message)
            : base(CurrentStatusCode, errorsResponse, message) { }
    }
}