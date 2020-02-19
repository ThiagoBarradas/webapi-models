namespace WebApi.Models.Request
{
    public class ListRequest
    {
        public ListRequest() { }

        public ListRequest(int page = 1, int size = 10) 
        {
            this.Page = page;
            this.Size = size;
        }

        public int Page { get; set; } = 1;

        public int Size { get; set; } = 10;
    }
}
