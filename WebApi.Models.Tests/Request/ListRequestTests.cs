using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Models.Request;
using Xunit;

namespace WebApi.Models.Tests.Request
{
    public class ListRequestTests
    {
        [Theory]
        [InlineData(-5, -5, 1, 1)]
        [InlineData(0, 0, 1, 1)]
        [InlineData(1, 1, 1, 1)]
        [InlineData(2, 2, 2, 2)]
        [InlineData(10, 10, 10, 10)]
        [InlineData(100, 100, 100, 100)]
        [InlineData(101, 101, 101, 100)]
        [InlineData(1000000, 1000000, 1000000, 100)]
        [InlineData(1000001, 1000001, 1000000, 100)]
        public static void ListRequest_Must_To_Consider_Min_And_Max(int page, int size, int expectedPage, int expectedSize)
        {
            // arrange & act
            var listRequest = new ListRequest(page, size);

            // assert
            Assert.Equal(expectedPage, listRequest.Page); 
            Assert.Equal(expectedSize, listRequest.Size);
        }

    }
}