using System.Collections.Generic;

namespace WebApi.Models.Response
{
    public class ErrorsResponse
    {
        public List<ErrorItemResponse> Errors { get; set; } = new List<ErrorItemResponse>();

        public ErrorsResponse() {}

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

        public static ErrorsResponse WithSingleError(string message)
        {
            return WithSingleError(message, null);
        }

        public static ErrorsResponse WithSingleError(string message, string property)
        {
            var errorsResponse = new ErrorsResponse();
            errorsResponse.AddError(message, property);
            return errorsResponse;
        }
    }
}
