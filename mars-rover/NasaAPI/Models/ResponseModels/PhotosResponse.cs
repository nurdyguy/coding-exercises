using Newtonsoft.Json;
using System.Collections.Generic;

namespace NasaAPI.Models.ResponseModels
{
    public class PhotosResponse
    {
        [JsonProperty("photos")]
        public IEnumerable<RoverImage> RoverImages { get; set; }
    }
}
