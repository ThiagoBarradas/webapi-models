using System;
using System.Net;
using WebApi.Models.Response;
using Xunit;

namespace WebApi.Models.Tests.Response
{
    public class ErrorItemResponseTest
    {
        [Fact]
        public static void Contructor_Empty()
        {
            // arrange & act
            var errorItem = new ErrorItemResponse();

            // assert
            Assert.NotNull(errorItem);
            Assert.Null(errorItem.Message);
            Assert.Null(errorItem.Property);
        }

        [Fact]
        public static void Contructor_With_Message()
        {
            // arrange & act
            var errorItem = new ErrorItemResponse("some test");

            // assert
            Assert.NotNull(errorItem);
            Assert.NotNull(errorItem.Message);
            Assert.Equal("some test", errorItem.Message);
            Assert.Null(errorItem.Property);
        }

        [Fact]
        public static void Contructor_With_Message_And_Property()
        {
            // arrange & act
            var errorItem = new ErrorItemResponse("some test", "property");

            // assert
            Assert.NotNull(errorItem);
            Assert.NotNull(errorItem.Message);
            Assert.Equal("some test", errorItem.Message);
            Assert.NotNull(errorItem.Property);
            Assert.Equal("property", errorItem.Property);
        }
    }
}
