namespace WebApi.Models.Request
{
    public class ListRequest
    {
        public static int MAX_PAGE_SIZE = 100;

        public static int MAX_PAGE_NUMBER = 1000000;

        public static int MIN_PAGE_SIZE = 1;

        public static int MIN_PAGE_NUMBER = 1;

        public ListRequest() { }

        public ListRequest(int page = 1, int size = 10) 
        {
            this.Page = page;
            this.Size = size;
        }

        private int _page = 1;
        public int Page
        {
            get => this._page;
            set
            {
                if(value >= MIN_PAGE_NUMBER)
                {
                    this._page = value;
                }
                else
                {
                    this._page = MIN_PAGE_NUMBER;
                }

                if (value > MAX_PAGE_NUMBER)
                {
                    this._page = MAX_PAGE_NUMBER;
                }
            }
        }

        private int _size = 10;
        public int Size
        {
            get => this._size;
            set
            {
                if (value >= MIN_PAGE_SIZE)
                {
                    this._size = value;
                }
                else
                {
                    this._size = MIN_PAGE_SIZE;
                }

                if (value > MAX_PAGE_SIZE)
                {
                    this._size = MAX_PAGE_SIZE;
                }
            }
        }
    }
}
