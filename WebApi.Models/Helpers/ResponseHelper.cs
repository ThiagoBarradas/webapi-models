using System;
using System.Collections.Generic;
using System.Net;
using WebApi.Models.Exceptions;
using WebApi.Models.Response;

namespace WebApi.Models.Helpers
{
    public static class ResponseHelper
    {
        public static ApiResponse ToApiResponse(this object content, HttpStatusCode statusCode, IDictionary<string, string> headers)
        {
            return new ApiResponse
            {
                StatusCode = statusCode,
                Content = content,
                Headers = headers ?? new Dictionary<string, string>()
            };
        }

        public static ApiResponse ToApiResponse(this object content, HttpStatusCode statusCode)
        {
            return ToApiResponse(content, statusCode, null);
        }

        public static ApiResponse ToApiResponse(HttpStatusCode statusCode)
        {
            return ToApiResponse(null, statusCode, null);
        }

        public static ApiResponse ToRedirectResponse(HttpStatusCode statusCode, string location)
        {
            var intStatusCode = (int)statusCode;
            if (intStatusCode < 300 || intStatusCode >= 400)
            {
                throw new ArgumentOutOfRangeException(nameof(statusCode));
            }

            var headers = new Dictionary<string, string>
                {{ "Location", location }};

            return ToApiResponse(null, statusCode, headers);
        }

        public static ApiResponse ToRedirectResponse(string location)
        {
            return ToRedirectResponse(HttpStatusCode.Found, location);
        }

        public static ApiResponse ToApiResponse(this ApiException exception)
        {
            return ToApiResponse(exception.ErrorsResponse, exception.StatusCode, null);
        }
    }
}
