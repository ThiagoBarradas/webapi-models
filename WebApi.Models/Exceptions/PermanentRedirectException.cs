using System.Net;

namespace WebApi.Models.Exceptions
{
    public class PermanentRedirectException : ApiException
    {
        private static HttpStatusCode CurrentStatusCode => HttpStatusCode.Redirect;

        public string Location { get; set; }

        public PermanentRedirectException(string location)
            : base(CurrentStatusCode) 
        {
            this.Location = location;
        }
    }
}