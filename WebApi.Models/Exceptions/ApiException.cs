using System;
using System.Net;
using WebApi.Models.Response;

namespace WebApi.Models.Exceptions
{
    public abstract class ApiException : Exception
    {
        private static string DefaultMessage = "An {0} ocurred";

        public ApiException(HttpStatusCode statusCode)
            : base(string.Format(DefaultMessage, statusCode.ToString()))
        {
            this.StatusCode = statusCode;
        }

        public ApiException(HttpStatusCode statusCode, string message, string property = null)
            : base(message)
        {
            this.StatusCode = statusCode;
            this.ErrorsResponse = ErrorsResponse.WithSingleError(message, property);
        }

        public ApiException(HttpStatusCode statusCode, ErrorsResponse errorResponse)
            : base(string.Format(DefaultMessage, statusCode.ToString()))
        {
            this.StatusCode = statusCode;
            this.ErrorsResponse = errorResponse;
        }

        public ApiException(HttpStatusCode statusCode, ErrorsResponse errorResponse, string message)
            : base(message)
        {
            this.StatusCode = statusCode;
            this.ErrorsResponse = errorResponse;
        }

        public HttpStatusCode StatusCode { get; set; }

        public ErrorsResponse ErrorsResponse { get; set; }
    }
}
