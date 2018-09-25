using System.Net;
using WebApi.Models.Response;

namespace WebApi.Models.Exceptions
{
    public class InternalServerErrorException : ApiException
    {
        private static HttpStatusCode CurrentStatusCode => HttpStatusCode.InternalServerError;


        public InternalServerErrorException()
            : base(CurrentStatusCode) { }

        public InternalServerErrorException(string message)
            : base(CurrentStatusCode, message) { }
        
        public InternalServerErrorException(ErrorsResponse errorsResponse)
            : base(CurrentStatusCode, errorsResponse) { }

        public InternalServerErrorException(ErrorsResponse errorsResponse, string message)
            : base(CurrentStatusCode, errorsResponse, message) { }
    }
}