using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using WebApi.Models.Exceptions;
using WebApi.Models.Helpers;
using WebApi.Models.Response;
using Xunit;

namespace WebApi.Models.Tests.Exceptions
{
    public static class ApiExceptionTest
    {
        [Fact]
        public static void ToApiResponse_By_Exceptions()
        {
            GenerateTestForException<BadGatewayException>(HttpStatusCode.BadGateway);
            GenerateTestForException<BadRequestException>(HttpStatusCode.BadRequest);
            GenerateTestForException<ConflictException>(HttpStatusCode.Conflict);
            GenerateTestForException<ExpectationFailedException>(HttpStatusCode.ExpectationFailed);
            GenerateTestForException<ForbiddenException>(HttpStatusCode.Forbidden);
            GenerateTestForException<GatewayTimeoutException>(HttpStatusCode.GatewayTimeout);
            GenerateTestForException<GoneException>(HttpStatusCode.Gone);
            GenerateTestForException<HttpVersionNotSupportedException>(HttpStatusCode.HttpVersionNotSupported);
            GenerateTestForException<InternalServerErrorException>(HttpStatusCode.InternalServerError);
            GenerateTestForException<LengthRequiredException>(HttpStatusCode.LengthRequired);
            GenerateTestForException<MethodNotAllowedException>(HttpStatusCode.MethodNotAllowed);
            GenerateTestForException<NotAcceptableException>(HttpStatusCode.NotAcceptable);
            GenerateTestForException<NotFoundException>(HttpStatusCode.NotFound);
            GenerateTestForException<Models.Exceptions.NotImplementedException>(HttpStatusCode.NotImplemented);
            GenerateTestForException<PaymentRequiredException>(HttpStatusCode.PaymentRequired);
            GenerateTestForException<PreconditionFailedException>(HttpStatusCode.PreconditionFailed);
            GenerateTestForException<ProxyAuthenticationRequiredException>(HttpStatusCode.ProxyAuthenticationRequired);
            GenerateTestForException<RequestedRangeNotSatisfiableException>(HttpStatusCode.RequestedRangeNotSatisfiable);
            GenerateTestForException<RequestEntityTooLargeException>(HttpStatusCode.RequestEntityTooLarge);
            GenerateTestForException<RequestTimeoutException>(HttpStatusCode.RequestTimeout);
            GenerateTestForException<RequestUriTooLongException>(HttpStatusCode.RequestUriTooLong);
            GenerateTestForException<ServiceUnavailableException>(HttpStatusCode.ServiceUnavailable);
            GenerateTestForException<UnauthorizedException>(HttpStatusCode.Unauthorized);
            GenerateTestForException<UnsupportedMediaTypeException>(HttpStatusCode.UnsupportedMediaType);
            GenerateTestForException<UpgradeRequiredException>(HttpStatusCode.UpgradeRequired);
        }

        private static void GenerateTestForException<T>(HttpStatusCode expectedStatusCode)
            where T : ApiException, new()
        {
            // arrange
            var type = typeof(T);

            var errors = new ErrorsResponse
            {
                Errors = new List<ErrorItemResponse>
                { new ErrorItemResponse("error message", "error property") }
            };

            var exceptionWithEmptyCtor = (T)Activator.CreateInstance(type, new object[] { });
            var exceptionWithMessage = (T)Activator.CreateInstance(type, new object[] { "some message", null });
            var exceptionWithMessageAndProperty = (T)Activator.CreateInstance(type, new object[] { "some message", "property" });
            var exceptionWithErrors = (T)Activator.CreateInstance(type, new object[] { errors });
            var exceptionWithMessageAndErrors = (T)Activator.CreateInstance(type, new object[] { errors, "some message" });

            // act
            var responseByExceptionWithEmptyCtor = exceptionWithEmptyCtor.ToApiResponse();
            var responseByExceptionWithMessage = exceptionWithMessage.ToApiResponse();
            var responseByExceptionWithMessageAndProperty = exceptionWithMessageAndProperty.ToApiResponse();
            var responseByExceptionWithErrors = exceptionWithErrors.ToApiResponse();
            var responseByExceptionWithMessageAndErrors = exceptionWithMessageAndErrors.ToApiResponse();

            // assert with empty 
            Assert.NotNull(exceptionWithEmptyCtor);
            Assert.NotNull(exceptionWithEmptyCtor.Message);
            Assert.Equal(string.Format("An {0} ocurred", expectedStatusCode.ToString()), exceptionWithEmptyCtor.Message);
            Assert.Null(exceptionWithEmptyCtor.ErrorsResponse);
            Assert.NotNull(responseByExceptionWithEmptyCtor);
            Assert.Null(responseByExceptionWithEmptyCtor.Content);
            Assert.Empty(responseByExceptionWithEmptyCtor.Headers);
            Assert.Equal(expectedStatusCode, responseByExceptionWithEmptyCtor.StatusCode);

            // assert with message
            Assert.NotNull(exceptionWithMessage);
            Assert.NotNull(exceptionWithMessage.Message);
            Assert.Equal("some message", exceptionWithMessage.Message);
            Assert.Single(exceptionWithMessage.ErrorsResponse.Errors);
            Assert.Equal("some message", exceptionWithMessage.ErrorsResponse.Errors.First().Message);
            Assert.Null(exceptionWithMessage.ErrorsResponse.Errors.First().Property);
            Assert.NotNull(exceptionWithMessage.ErrorsResponse);
            Assert.NotNull(responseByExceptionWithMessage);
            Assert.NotNull(responseByExceptionWithMessage.Content);
            Assert.Empty(responseByExceptionWithMessage.Headers);
            Assert.Equal(expectedStatusCode, responseByExceptionWithMessage.StatusCode);

            // assert with message and property 
            Assert.NotNull(exceptionWithMessageAndProperty);
            Assert.NotNull(exceptionWithMessageAndProperty.Message);
            Assert.Equal("some message", exceptionWithMessageAndProperty.Message);
            Assert.Single(exceptionWithMessageAndProperty.ErrorsResponse.Errors);
            Assert.Equal("some message", exceptionWithMessageAndProperty.ErrorsResponse.Errors.First().Message);
            Assert.Equal("property", exceptionWithMessageAndProperty.ErrorsResponse.Errors.First().Property);
            Assert.NotNull(responseByExceptionWithMessageAndProperty);
            Assert.NotNull(responseByExceptionWithMessageAndProperty.Content);
            Assert.Single(((ErrorsResponse)responseByExceptionWithMessageAndProperty.Content).Errors);
            Assert.Equal("some message", ((ErrorsResponse)responseByExceptionWithMessageAndProperty.Content).Errors.First().Message);
            Assert.Equal("property", ((ErrorsResponse)responseByExceptionWithMessageAndProperty.Content).Errors.First().Property);
            Assert.Empty(responseByExceptionWithMessageAndProperty.Headers);
            Assert.Equal(expectedStatusCode, responseByExceptionWithMessageAndProperty.StatusCode);

            // assert with errors
            Assert.NotNull(exceptionWithErrors);
            Assert.NotNull(exceptionWithErrors.Message);
            Assert.Equal(string.Format("An {0} ocurred", expectedStatusCode), exceptionWithErrors.Message);
            Assert.Single(exceptionWithErrors.ErrorsResponse.Errors);
            Assert.Equal("error message", exceptionWithErrors.ErrorsResponse.Errors.First().Message);
            Assert.Equal("error property", exceptionWithErrors.ErrorsResponse.Errors.First().Property);
            Assert.NotNull(responseByExceptionWithErrors);
            Assert.NotNull(responseByExceptionWithErrors.Content);
            Assert.Single(((ErrorsResponse)responseByExceptionWithErrors.Content).Errors);
            Assert.Equal("error message", ((ErrorsResponse)responseByExceptionWithErrors.Content).Errors.First().Message);
            Assert.Equal("error property", ((ErrorsResponse)responseByExceptionWithErrors.Content).Errors.First().Property);
            Assert.Empty(responseByExceptionWithErrors.Headers);
            Assert.Equal(expectedStatusCode, responseByExceptionWithErrors.StatusCode);

            // assert with errors and message
            Assert.NotNull(exceptionWithMessageAndErrors);
            Assert.NotNull(exceptionWithMessageAndErrors.Message);
            Assert.Equal("some message", exceptionWithMessageAndErrors.Message);
            Assert.Single(exceptionWithMessageAndErrors.ErrorsResponse.Errors);
            Assert.Equal("error message", exceptionWithMessageAndErrors.ErrorsResponse.Errors.First().Message);
            Assert.Equal("error property", exceptionWithMessageAndErrors.ErrorsResponse.Errors.First().Property);
            Assert.NotNull(responseByExceptionWithMessageAndErrors);
            Assert.NotNull(responseByExceptionWithMessageAndErrors.Content);
            Assert.Single(((ErrorsResponse)responseByExceptionWithMessageAndErrors.Content).Errors);
            Assert.Equal("error message", ((ErrorsResponse)responseByExceptionWithMessageAndErrors.Content).Errors.First().Message);
            Assert.Equal("error property", ((ErrorsResponse)responseByExceptionWithMessageAndErrors.Content).Errors.First().Property);
            Assert.Empty(responseByExceptionWithMessageAndErrors.Headers);
            Assert.Equal(expectedStatusCode, responseByExceptionWithMessageAndErrors.StatusCode);
        }
    }
}
