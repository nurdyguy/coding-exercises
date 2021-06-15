using System;

namespace NasaAPI.Models.RequestModels
{
    public class SearchImagesRequest : PagedRequest
    {
        public DateTime Date { get; set; }
        public string RoverName { get; set; }
    }
}
