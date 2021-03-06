﻿using System.Net;
using WebApi.Models.Response;

namespace WebApi.Models.Exceptions
{
    public class GoneException : ApiException
    {
        private static HttpStatusCode CurrentStatusCode => HttpStatusCode.Gone;

        public GoneException()
            : base(CurrentStatusCode) { }

        public GoneException(string message, string property = null)
            : base(CurrentStatusCode, message, property) { }
        
        public GoneException(ErrorsResponse errorsResponse)
            : base(CurrentStatusCode, errorsResponse) { }

        public GoneException(ErrorsResponse errorsResponse, string message)
            : base(CurrentStatusCode, errorsResponse, message) { }
    }
}