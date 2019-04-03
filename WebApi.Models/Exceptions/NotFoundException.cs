using System.Net;
using WebApi.Models.Response;

namespace WebApi.Models.Exceptions
{
    public class NotFoundException : ApiException
    {
        private static HttpStatusCode CurrentStatusCode => HttpStatusCode.NotFound;

        public NotFoundException()
            : base(CurrentStatusCode) { }

        public NotFoundException(string message, string property = null)
            : base(CurrentStatusCode, message, property) { }
        
        public NotFoundException(ErrorsResponse errorsResponse)
            : base(CurrentStatusCode, errorsResponse) { }

        public NotFoundException(ErrorsResponse errorsResponse, string message)
            : base(CurrentStatusCode, errorsResponse, message) { }
    }
}