using System.Collections.Generic;

namespace NasaAPI.Models.ResponseModels
{
    public class SearchImagesResponse : PagedResponse
    {
        public IEnumerable<RoverImage> RoverImages { get; set; }
    }
}
