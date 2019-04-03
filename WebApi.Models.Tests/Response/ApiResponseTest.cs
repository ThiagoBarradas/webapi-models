using System.Linq;
using System.Net;
using WebApi.Models.Response;
using Xunit;

namespace WebApi.Models.Tests.Response
{
    public class ApiResponseTest
    {
        [Fact]
        public static void OK_Should_Return_OKResponse()
        {
            // arrange & act
            var response = ApiResponse.OK();

            // assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Null(response.Content);
            Assert.Empty(response.Headers);
        }

        [Fact]
        public static void Created_Should_Return_CreatedResponse()
        {
            // arrange & act
            var response = ApiResponse.Created();

            // assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Null(response.Content);
            Assert.Empty(response.Headers);
        }

        [Fact]
        public static void NotFound_Should_Return_NotFoundResponse()
        {
            // arrange & act
            var response = ApiResponse.NotFound();

            // assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.Null(response.Content);
            Assert.Empty(response.Headers);
        }

        [Fact]
        public static void Unauthorized_Should_Return_UnauthorizedResponse()
        {
            // arrange & act
            var response = ApiResponse.Unauthorized();

            // assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.Null(response.Content);
            Assert.Empty(response.Headers);
        }

        [Fact]
        public static void Found_Should_Return_FoundResponse()
        {
            // arrange & act
            var response = ApiResponse.Found("http://www.google.com");

            // assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.Found, response.StatusCode);
            Assert.Null(response.Content);
            Assert.Single(response.Headers);
            Assert.Equal("http://www.google.com", response.Headers["Location"]);
        }

        [Fact]
        public static void BadRequest_Should_Return_BadRequestResponse()
        {
            // arrange & act
            var response = ApiResponse.BadRequest("message", "property");

            // assert
            var errors = (ErrorsResponse) response.Content;
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.NotNull(response.Content);
            Assert.Single(errors.Errors);
            Assert.Equal("message", errors.Errors.First().Message);
            Assert.Equal("property", errors.Errors.First().Property);
            Assert.Empty(response.Headers);
        }
    }
}
