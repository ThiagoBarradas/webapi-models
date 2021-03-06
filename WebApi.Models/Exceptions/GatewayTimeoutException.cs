﻿using System.Net;
using WebApi.Models.Response;

namespace WebApi.Models.Exceptions
{
    public class GatewayTimeoutException : ApiException
    {
        private static HttpStatusCode CurrentStatusCode => HttpStatusCode.GatewayTimeout;

        public GatewayTimeoutException()
            : base(CurrentStatusCode) { }

        public GatewayTimeoutException(string message, string property = null)
            : base(CurrentStatusCode, message, property) { }
        
        public GatewayTimeoutException(ErrorsResponse errorsResponse)
            : base(CurrentStatusCode, errorsResponse) { }

        public GatewayTimeoutException(ErrorsResponse errorsResponse, string message)
            : base(CurrentStatusCode, errorsResponse, message) { }
    }
}