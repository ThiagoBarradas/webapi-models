using System.Net;
using WebApi.Models.Response;

namespace WebApi.Models.Exceptions
{
    public class UpgradeRequiredException : ApiException
    {
        private static HttpStatusCode CurrentStatusCode => HttpStatusCode.UpgradeRequired;

        public UpgradeRequiredException()
            : base(CurrentStatusCode) { }

        public UpgradeRequiredException(string message, string property = null)
            : base(CurrentStatusCode, message, property) { }
        
        public UpgradeRequiredException(ErrorsResponse errorsResponse)
            : base(CurrentStatusCode, errorsResponse) { }

        public UpgradeRequiredException(ErrorsResponse errorsResponse, string message)
            : base(CurrentStatusCode, errorsResponse, message) { }
    }
}