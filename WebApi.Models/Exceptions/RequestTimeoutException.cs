﻿using System.Net;
using WebApi.Models.Response;

namespace WebApi.Models.Exceptions
{
    public class RequestTimeoutException : ApiException
    {
        private static HttpStatusCode CurrentStatusCode => HttpStatusCode.RequestTimeout;

        public RequestTimeoutException()
            : base(CurrentStatusCode) { }

        public RequestTimeoutException(string message, string property = null)
            : base(CurrentStatusCode, message, property) { }
        
        public RequestTimeoutException(ErrorsResponse errorsResponse)
            : base(CurrentStatusCode, errorsResponse) { }

        public RequestTimeoutException(ErrorsResponse errorsResponse, string message)
            : base(CurrentStatusCode, errorsResponse, message) { }
    }
}