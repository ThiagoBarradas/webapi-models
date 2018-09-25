using System.Net;
using WebApi.Models.Response;

namespace WebApi.Models.Exceptions
{
    public class PaymentRequiredException : ApiException
    {
        private static HttpStatusCode CurrentStatusCode => HttpStatusCode.PaymentRequired;

        public PaymentRequiredException()
            : base(CurrentStatusCode) { }

        public PaymentRequiredException(string message)
            : base(CurrentStatusCode, message) { }
        
        public PaymentRequiredException(ErrorsResponse errorsResponse)
            : base(CurrentStatusCode, errorsResponse) { }

        public PaymentRequiredException(ErrorsResponse errorsResponse, string message)
            : base(CurrentStatusCode, errorsResponse, message) { }
    }
}