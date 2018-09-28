using System.Linq;
using WebApi.Models.Response;
using Xunit;

namespace WebApi.Models.Tests.Response
{
    public class ErrorsResponseTest
    {
        [Fact]
        public static void Contructor_Empty()
        {
            // arrange & act
            var response = new ErrorsResponse();

            // assert
            Assert.NotNull(response);
            Assert.Empty(response.Errors);
        }

        [Fact]
        public static void AddError_With_Message()
        {
            // arrange 
            var response = new ErrorsResponse();

            // act
            response.AddError("some test");

            // assert
            Assert.NotNull(response);
            Assert.Single(response.Errors);
            Assert.NotNull(response.Errors.FirstOrDefault().Message);
            Assert.Equal("some test", response.Errors.FirstOrDefault().Message);
            Assert.Null(response.Errors.FirstOrDefault().Property);
        }

        [Fact]
        public static void AddError_With_Message_And_Property()
        {
            // arrange 
            var response = new ErrorsResponse();

            // act
            response.AddError("some test", "property");

            // assert
            Assert.NotNull(response);
            Assert.Single(response.Errors);
            Assert.NotNull(response.Errors.FirstOrDefault().Message);
            Assert.Equal("some test", response.Errors.FirstOrDefault().Message);
            Assert.NotNull(response.Errors.FirstOrDefault().Property);
            Assert.Equal("property", response.Errors.FirstOrDefault().Property);
        }

        [Fact]
        public static void AddError_With_ErrorItem()
        {
            // arrange 
            var response = new ErrorsResponse();
            var errorItem = new ErrorItemResponse("some test", "property");

            // act
            response.AddError(errorItem);

            // assert
            Assert.NotNull(response);
            Assert.Single(response.Errors);
            Assert.NotNull(response.Errors.FirstOrDefault().Message);
            Assert.Equal("some test", response.Errors.FirstOrDefault().Message);
            Assert.NotNull(response.Errors.FirstOrDefault().Property);
            Assert.Equal("property", response.Errors.FirstOrDefault().Property);
        }

        [Fact]
        public static void AddError_With_ErrorItem_When_Errors_Is_null()
        {
            // arrange 
            var response = new ErrorsResponse();
            response.Errors = null;
            var errorItem = new ErrorItemResponse("some test", "property");

            // act
            response.AddError(errorItem);

            // assert
            Assert.NotNull(response);
            Assert.Single(response.Errors);
            Assert.NotNull(response.Errors.FirstOrDefault().Message);
            Assert.Equal("some test", response.Errors.FirstOrDefault().Message);
            Assert.NotNull(response.Errors.FirstOrDefault().Property);
            Assert.Equal("property", response.Errors.FirstOrDefault().Property);
        }

        [Fact]
        public static void WithSingleError_With_Message()
        {
            // arrange & act
            var response = ErrorsResponse.WithSingleError("some message");
            
            // assert
            Assert.NotNull(response);
            Assert.Single(response.Errors);
            Assert.NotNull(response.Errors.FirstOrDefault().Message);
            Assert.Equal("some message", response.Errors.FirstOrDefault().Message);
            Assert.Null(response.Errors.FirstOrDefault().Property);
        }

        [Fact]
        public static void WithSingleError_With_Message_And_Property()
        {
            // arrange & act
            var response = ErrorsResponse.WithSingleError("some message", "some property");

            // assert
            Assert.NotNull(response);
            Assert.Single(response.Errors);
            Assert.NotNull(response.Errors.FirstOrDefault().Message);
            Assert.Equal("some message", response.Errors.FirstOrDefault().Message);
            Assert.NotNull(response.Errors.FirstOrDefault().Property);
            Assert.Equal("some property", response.Errors.FirstOrDefault().Property);
        }
    }
}
