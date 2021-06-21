namespace NasaAPI.Models.ResponseModels
{
    public class PagedResponse
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
        public int Total { get; set; }
    }
}
