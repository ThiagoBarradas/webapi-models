using System.Net;
using WebApi.Models.Response;

namespace WebApi.Models.Exceptions
{
    public class UnsupportedMediaTypeException : ApiException
    {
        private static HttpStatusCode CurrentStatusCode => HttpStatusCode.UnsupportedMediaType;

        public UnsupportedMediaTypeException()
            : base(CurrentStatusCode) { }

        public UnsupportedMediaTypeException(string message)
            : base(CurrentStatusCode, message) { }
        
        public UnsupportedMediaTypeException(ErrorsResponse errorsResponse)
            : base(CurrentStatusCode, errorsResponse) { }

        public UnsupportedMediaTypeException(ErrorsResponse errorsResponse, string message)
            : base(CurrentStatusCode, errorsResponse, message) { }
    }
}