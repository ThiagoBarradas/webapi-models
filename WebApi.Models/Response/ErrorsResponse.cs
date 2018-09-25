using System.Collections.Generic;

namespace WebApi.Models.Response
{
    public class ErrorsResponse
    {
        public List<ErrorItemResponse> Errors { get; set; }

        public ErrorsResponse()
        {
            this.Errors = new List<ErrorItemResponse>();
        }

        public void AddError(string message)
        {
            this.AddError(new ErrorItemResponse(message));
        }

        public void AddError(string message, string property)
        {
            this.AddError(new ErrorItemResponse(message, property));
        }

        public void AddError(ErrorItemResponse error)
        {
            if (this.Errors == null)
            {
                this.Errors = new List<ErrorItemResponse>();
            }

            this.Errors.Add(error);
        }
    }
}
