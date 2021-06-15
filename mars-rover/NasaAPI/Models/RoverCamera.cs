using Newtonsoft.Json;

namespace NasaAPI.Models
{
    public class RoverCamera
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("full_name")]
        public string Name { get; set; }
        [JsonProperty("name")]
        public string Abbreviation { get; set; }
        [JsonProperty("rover_id")]
        public int RoverId { get; set; }
    }
}
