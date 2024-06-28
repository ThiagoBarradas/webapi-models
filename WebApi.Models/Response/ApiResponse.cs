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

        public static ApiResponse OK(object content = null)
        {
            return new ApiResponse
            {
                Content = content,
                StatusCode = HttpStatusCode.OK
            };
        }

        public static ApiResponse Created()
        {
            return new ApiResponse
            {
                StatusCode = HttpStatusCode.Created
            };
        }

        public static ApiResponse Found(string location)
        {
            var apiResponse = new ApiResponse
            {
                StatusCode = HttpStatusCode.Found
            };

            apiResponse.Headers.Add("Location", location);

            return apiResponse;
        }

        public static ApiResponse Unauthorized()
        {
            return new ApiResponse
            {
                StatusCode = HttpStatusCode.Unauthorized
            };
        }

        public static ApiResponse NotFound()
        {
            return new ApiResponse
            {
                StatusCode = HttpStatusCode.NotFound
            };
        }

        public static ApiResponse BadRequest(string message, string property = null)
        {
            return new ApiResponse
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = ErrorsResponse.WithSingleError(message, property)
            };
        }

        public static ApiResponse BadGateway(object content = null)
        {
            return new ApiResponse
            {
                Content = content,
                StatusCode = HttpStatusCode.BadGateway
            };
        }
    }
}
