using System.Net;
using WebApi.Models.Response;

namespace WebApi.Models.Exceptions
{
    public class BadRequestException : ApiException
    {
        private static HttpStatusCode CurrentStatusCode => HttpStatusCode.BadRequest;

        public BadRequestException()
            : base(CurrentStatusCode) { }

        public BadRequestException(string message)
            : base(CurrentStatusCode, message) { }
        
        public BadRequestException(ErrorsResponse errorsResponse)
            : base(CurrentStatusCode, errorsResponse) { }

        public BadRequestException(ErrorsResponse errorsResponse, string message)
            : base(CurrentStatusCode, errorsResponse, message) { }
    }
}