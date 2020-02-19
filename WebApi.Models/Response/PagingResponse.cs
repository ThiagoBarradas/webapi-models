﻿using WebApi.Models.Request;

namespace WebApi.Models.Response
{
    public class PagingResponse
    {
        public PagingResponse()
        {
        }

        public PagingResponse(ListRequest request, int totalItems = 0)
        {
            if (request != null)
            {
                this.Page = request.Page;
                this.Size = request.Size;
            }

            if (totalItems > 0 && this.Size > 0)
            {
                this.TotalItems = totalItems;
                this.TotalPages = (totalItems + this.Size - 1) / this.Size;
            }
        }

        public int Page { get; set; } = 1;

        public int Size { get; set; } = 10;

        public long TotalItems { get; set; }

        public long TotalPages { get; set; }

        public bool HasNextPage => this.TotalPages > this.Page;
    }
}
