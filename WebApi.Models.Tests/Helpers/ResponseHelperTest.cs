using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using WebApi.Models.Helpers;
using Xunit;

namespace WebApi.Models.Tests.Helpers
{
    public static class ResponseHelperTest
    {
        [Fact]
        public static void ToApiResponse_With_Object_And_StatusCode()
        {
            // arrange 
            var model = new MyModel { MyProperty = "test" };

            // act
            var apiResponse = model.ToApiResponse(HttpStatusCode.Accepted);

            // assert
            Assert.NotNull(apiResponse);
            Assert.Empty(apiResponse.Headers);
            Assert.Equal("test", ((MyModel)apiResponse.Content).MyProperty);
            Assert.Equal(HttpStatusCode.Accepted, apiResponse.StatusCode);
        }

        [Fact]
        public static void ToApiResponse_With_StatusCode()
        {
            // arrange & act
            var apiResponse = ResponseHelper.ToApiResponse(HttpStatusCode.OK);

            // assert
            Assert.NotNull(apiResponse);
            Assert.Empty(apiResponse.Headers);
            Assert.Null(apiResponse.Content);
            Assert.Equal(HttpStatusCode.OK, apiResponse.StatusCode);
        }

        [Fact]
        public static void ToApiResponse_With_Object_StatusCode_And_Headers()
        {
            // arrange 
            var model = new MyModel { MyProperty = "test" };
            var headers = new Dictionary<string, string> { { "X-Test", "testheader" } };

            // act
            var apiResponse = model.ToApiResponse(HttpStatusCode.Accepted, headers);

            // assert
            Assert.NotNull(apiResponse);
            Assert.Single(apiResponse.Headers);
            Assert.Equal("X-Test", apiResponse.Headers.First().Key);
            Assert.Equal("testheader", apiResponse.Headers.First().Value);
            Assert.Equal("test", ((MyModel)apiResponse.Content).MyProperty);
            Assert.Equal(HttpStatusCode.Accepted, apiResponse.StatusCode);
        }


        [Fact]
        public static void ToRedirectResponse_With_StatusCode_And_Location()
        {
            // arrange & act
            var redirectResponse = ResponseHelper.ToRedirectResponse(HttpStatusCode.Moved, "http://www.google.com");

            // assert
            Assert.NotNull(redirectResponse);
            Assert.Single(redirectResponse.Headers);
            Assert.Equal("Location", redirectResponse.Headers.First().Key);
            Assert.Equal("http://www.google.com", redirectResponse.Headers.First().Value);
            Assert.Null(redirectResponse.Content);
            Assert.Equal(HttpStatusCode.Moved, redirectResponse.StatusCode);
        }

        [Fact]
        public static void ToRedirectResponse_With_Location()
        {
            // arrange & act
            var redirectResponse = ResponseHelper.ToRedirectResponse("http://www.google.com");

            // assert
            Assert.NotNull(redirectResponse);
            Assert.Single(redirectResponse.Headers);
            Assert.Equal("Location", redirectResponse.Headers.First().Key);
            Assert.Equal("http://www.google.com", redirectResponse.Headers.First().Value);
            Assert.Null(redirectResponse.Content);
            Assert.Equal(HttpStatusCode.Found, redirectResponse.StatusCode);
        }

        [Fact]
        public static void ToRedirectResponse_With_Less_StatusCode_Should_Throws_Exception()
        {
            // arrange & act
            Exception ex =
                Assert.Throws<ArgumentOutOfRangeException>(() =>
                ResponseHelper.ToRedirectResponse(HttpStatusCode.OK, "http://www.google.com"));

            // assert
            Assert.Equal("Specified argument was out of the range of valid values.\nParameter name: statusCode", ex.Message.Replace("\r", ""));
        }

        [Fact]
        public static void ToRedirectResponse_With_Greater_StatusCode_Should_Throws_Exception()
        {
            // arrange & act
            Exception ex =
                Assert.Throws<ArgumentOutOfRangeException>(() =>
                ResponseHelper.ToRedirectResponse(HttpStatusCode.InternalServerError, "http://www.google.com"));

            // assert
            Assert.Equal("Specified argument was out of the range of valid values.\nParameter name: statusCode", ex.Message.Replace("\r",""));
        }
    }

    public class MyModel
    {
        public string MyProperty { get; set; }
    }
}
