using Newtonsoft.Json;
using System;

namespace NasaAPI.Models
{
    public class RoverImage
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("sol")]
        public int Sol { get; set; }
        [JsonProperty("camera")]
        public RoverCamera Camera { get; set; }
        [JsonProperty("img_src")]
        public string ImageSource { get; set; }
        [JsonProperty("earch_date")]
        public DateTime EarthDate { get; set; }
        [JsonProperty("rover")]
        public Rover Rover { get; set; }
    }
}
