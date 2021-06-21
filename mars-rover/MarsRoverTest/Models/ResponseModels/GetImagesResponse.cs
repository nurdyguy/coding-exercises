using System.Collections.Generic;

namespace MarsRoverTest.Models.ResponseModels
{
    public class GetImagesResponse : PagedResponse
    {
        public IEnumerable<RoverImage> RoverImages { get; set; }
    }
}
