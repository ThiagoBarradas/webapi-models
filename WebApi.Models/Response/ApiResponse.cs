using System.Collections.Generic;
using System.Net;

namespace WebApi.Models.Response
{
    public class ApiResponse
    {
        public ApiResponse()
        {
            StatusCode = HttpStatusCode.OK;
            Headers = new Dictionary<string, string>();
        }
        
        public object Content { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public IDictionary<string, string> Headers { get; set; }       
    }
}
