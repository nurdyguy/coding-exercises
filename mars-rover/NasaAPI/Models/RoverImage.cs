using Newtonsoft.Json;
using System;
using System.IO;

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
        [JsonProperty("earth_date")]
        public DateTime EarthDate { get; set; }
        [JsonProperty("rover")]
        public Rover Rover { get; set; }
        public string ImageFilename { get; set; }
        public byte[] ImageBytes
        {
            get
            {
                try
                {
                    return File.ReadAllBytes($"../NasaAPI/Repositories/Images/{ImageFilename}");
                }
                catch(Exception ex)
                {
                    // log exception here
                    return new byte[0];
                }
            }            
        }
    }
}
