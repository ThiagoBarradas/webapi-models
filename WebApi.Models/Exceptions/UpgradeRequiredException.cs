using System.Net;
using WebApi.Models.Response;

namespace WebApi.Models.Exceptions
{
    public class UpgradeRequiredException : ApiException
    {
        private static HttpStatusCode CurrentStatusCode => HttpStatusCode.UpgradeRequired;

        public UpgradeRequiredException()
            : base(CurrentStatusCode) { }

        public UpgradeRequiredException(string message)
            : base(CurrentStatusCode, message) { }
        
        public UpgradeRequiredException(ErrorsResponse errorsResponse)
            : base(CurrentStatusCode, errorsResponse) { }

        public UpgradeRequiredException(ErrorsResponse errorsResponse, string message)
            : base(CurrentStatusCode, errorsResponse, message) { }
    }
}