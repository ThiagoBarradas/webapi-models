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

        private int _page = 1;
        public int Page
        {
            get => _page;
            set
            {
                if(value != 0)
                {
                    _page = value;
                }
            }
        }

        private int _size = 10;
        public int Size
        {
            get => _size;
            set
            {
                if (value != 0)
                {
                    _size = value;
                }
            }
        }
    }
}
