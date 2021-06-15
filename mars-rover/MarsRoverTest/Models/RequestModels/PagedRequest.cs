namespace MarsRoverTest.Models.RequestModels
{
    public class PagedRequest
    {
        private int? _page { get; set; }
        private int? _perPage { get; set; }
        public int Page 
        {
            get { return _page ?? 1; } 
            set { _page = value; } 
        }
        public int PerPage 
        {
            get { return _perPage ?? 10; }
            set { _perPage = value; } 
        }
    }
}
