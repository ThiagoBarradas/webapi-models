using System.Net;
using WebApi.Models.Response;

namespace WebApi.Models.Exceptions
{
    public class LengthRequiredException : ApiException
    {
        private static HttpStatusCode CurrentStatusCode => HttpStatusCode.LengthRequired;

        public LengthRequiredException()
            : base(CurrentStatusCode) { }

        public LengthRequiredException(string message)
            : base(CurrentStatusCode, message) { }
        
        public LengthRequiredException(ErrorsResponse errorsResponse)
            : base(CurrentStatusCode, errorsResponse) { }

        public LengthRequiredException(ErrorsResponse errorsResponse, string message)
            : base(CurrentStatusCode, errorsResponse, message) { }
    }
}