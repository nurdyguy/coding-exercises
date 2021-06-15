using Newtonsoft.Json;
using System;

namespace NasaAPI.Models
{
    public class Rover
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("landing_date")]
        public DateTime LandingDate { get; set; }
        [JsonProperty("launch_date")]
        public DateTime LaunchDate { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
