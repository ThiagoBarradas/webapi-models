using System.Net;
using WebApi.Models.Response;

namespace WebApi.Models.Exceptions
{
    public class BadGatewayException : ApiException
    {
        private static HttpStatusCode CurrentStatusCode => HttpStatusCode.BadGateway;

        public BadGatewayException()
            : base(CurrentStatusCode) { }

        public BadGatewayException(string message, string property = null)
            : base(CurrentStatusCode, message, property) { }
        
        public BadGatewayException(ErrorsResponse errorsResponse)
            : base(CurrentStatusCode, errorsResponse) { }

        public BadGatewayException(ErrorsResponse errorsResponse, string message)
            : base(CurrentStatusCode, errorsResponse, message) { }
    }
}